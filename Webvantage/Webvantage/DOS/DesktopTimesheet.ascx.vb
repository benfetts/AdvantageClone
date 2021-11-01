Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Partial Public Class DesktopTimesheet
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private TotalWeekHours As Decimal = CType(0.0, Decimal)

#End Region

#Region " Properties "

    Private ReadOnly Property StartWeekOn As DayOfWeek
        Get
            Try

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim c As New cTimeSheet(Session("ConnString"))

                TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                Return TsSettings.StartTimesheetOnDayOfWeek

            Catch ex As Exception
                Return DayOfWeek.Sunday
            End Try
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butRefresh.Click

        Me.TimeSheetRadGrid.Rebind()

    End Sub
    Private Sub ImageButtonNew_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonNew.Click
        Dim q As New AdvantageFramework.Web.QueryString()
        Dim ts As New wvTimeSheet.cTimeSheet(_Session.ConnectionString)
        With q
            .Page = "Timesheet_CommentsView.aspx"
            .EmployeeCode = Session("EmpCode")
            .StartDate = ts.FirstDayOfWeek(Now).ToShortDateString()
            .Add("Display", "0")
            .Add("Type", "New")
            .Add("caller", "MainMenu")
            .Add("single", "1")
            .Build()
        End With
        Me.OpenWindow("", q.ToString(True))
    End Sub

    Private Sub TimeSheetRadGrid_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles TimeSheetRadGrid.ItemCommand

        Session("TimesheetEmpCode") = Session("EmpCode")

        Dim URL As String = ""

        Select Case e.CommandName
            Case "OpenTimesheetDay"

                Dim DayOfWeek As Integer = CType(e.CommandArgument, Date).DayOfWeek
                Dim DateToOpen As Date = CType(e.CommandArgument, Date)

                'Select Case StartWeekOn
                '    Case System.DayOfWeek.Saturday

                '        If DayOfWeek <> StartWeekOn Then

                '            DateToOpen = DateToOpen.AddDays(1)
                '            DayOfWeek = DayOfWeek + 1

                '        End If

                '    Case System.DayOfWeek.Monday

                '        If DayOfWeek <> StartWeekOn Then

                '            DateToOpen = DateToOpen.AddDays(-1)
                '            DayOfWeek = DayOfWeek - 1

                '        End If

                'End Select

                'DayOfWeek = DateToOpen.DayOfWeek

                Session("TimesheetStartDate") = DateToOpen.ToShortDateString()
                Session("TimesheetMain_SingleViewDayOfWeek") = DayOfWeek
                Session("TimesheetCommentView_SingleViewDayOfWeek") = DayOfWeek
                Session("TimesheetMain_UserHasMadeASelection") = DayOfWeek

                URL = "Timesheet.aspx?FromWindow=CurrentDTObject&tsdate=" & DateToOpen.ToShortDateString()
                Me.OpenWindow("", URL)

            Case "OpenTimesheetWeek"

                Session("TimesheetStartDate") = Now.ToShortDateString()
                Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
                Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing

                Dim Show As Integer = 7
                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim c As New cTimeSheet(Session("ConnString"))

                TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                Show = CType(TsSettings.DaysToDisplay, Integer)

                If Show = 5 Then

                    Session("TimesheetMain_UserHasMadeASelection") = "all5"

                Else

                    Session("TimesheetMain_UserHasMadeASelection") = "all7"

                End If

                URL = "Timesheet.aspx?FromWindow=CurrentDTObject&tsdate=" & Now.ToShortDateString()
                Me.OpenWindow("", URL)

            Case "StopStopwatch"

                Dim EtId As Integer = 0
                Dim EtDtlId As Integer = 0
                Dim ar() As String

                ar = e.CommandArgument.ToString().Split("|")
                EtId = CType(ar(0), Integer)
                EtDtlId = CType(ar(1), Integer)

                If EtId > 0 And EtDtlId > 0 Then

                    Dim row As Telerik.Web.UI.GridDataItem = CType(e.Item, Telerik.Web.UI.GridDataItem)
                    Dim TheDate As Date = CType(row.GetDataKeyValue("DayDisplay"), Date)

                    'Dim t As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
                    Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))

                    Dim s As String = ""
                    Dim h As Decimal = 0
                    Dim Comment As String = ""
                    Dim Description As String = ""

                    If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Session("UserCode"), Session("EmpCode"), EtId, EtDtlId, TheDate, Comment, Description) = True Then

                        If Comment = "" And ts.CommentsRequired = True Then

                            Me.OpenTimesheetStopwatchNotificationWindow()

                        Else

                            If AdvantageFramework.Timesheet.StopwatchStop(Session("ConnString"), Session("EmpCode"), Session("EmpCode"), EtId, EtDtlId, h, "", s) = True Then

                                Webvantage.TimesheetPage.ProcessMissingTime(Session("EmpCode"), row.GetDataKeyValue("DayDisplay"))
                                Me.OpenTimesheetStopwatchNotificationWindow()
                                Me.TimeSheetRadGrid.Rebind()

                            Else

                                Me.ShowMessage(s)

                            End If

                        End If

                    End If


                End If
        End Select


    End Sub
    Private Sub TimeSheetRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles TimeSheetRadGrid.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
            TotalWeekHours += CType(dataItem.DataItem("Hours"), Decimal)
            Try
                Dim hl As System.Web.UI.WebControls.LinkButton
                hl = e.Item.FindControl("LinkButtonDayDisplay")
                If CType(e.Item.DataItem("DayDisplay"), Date).ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then
                    hl.Text = "<strong>" & LoGlo.FormatLongDateTime(e.Item.DataItem("DayDisplay")) & "</strong>"
                Else
                    hl.Text = LoGlo.FormatLongDateTime(e.Item.DataItem("DayDisplay"))
                End If
            Catch ex As Exception
            End Try
            Try
                Dim StopwatchImageButton As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("ImageButtonStopwatch"), ImageButton)
                If CType(e.Item.DataItem("HAS_STOPWATCH"), Integer) = 1 Then
                    With StopwatchImageButton
                        .Visible = True
                        .CommandArgument = e.Item.DataItem("STOPWATCH_ET_ID") & "|" & e.Item.DataItem("STOPWATCH_ET_DTL_ID")
                    End With
                Else
                    With StopwatchImageButton
                        .Visible = False
                        .CommandArgument = "0|0"
                    End With
                End If
            Catch ex As Exception
            End Try
        End If
        If (TypeOf e.Item Is Telerik.Web.UI.GridFooterItem) Then
            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(e.Item, Telerik.Web.UI.GridFooterItem)
            footerItem("ColHours").Text = TotalWeekHours.ToString()
        End If
    End Sub
    Private Sub TimeSheetRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles TimeSheetRadGrid.NeedDataSource

        Dim dto As New cDesktopObjects(Session("ConnString"))
        Me.TimeSheetRadGrid.DataSource = dto.GetTimesheetDTO(Session("EmpCode"))

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Me.DivTimeWarnings.Visible = oTS.LoadTimeWarning(Me.DivMissingTime, Me.ImageButtonMissingTime)

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

        Else

            Select Case Me.EventTarget
                Case "RebindGrid", "UpdatePanelRadDock"
                    Me.TimeSheetRadGrid.Rebind()

            End Select

        End If
    End Sub

#End Region

#End Region

End Class