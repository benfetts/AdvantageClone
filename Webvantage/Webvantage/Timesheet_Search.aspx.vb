Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Public Class Timesheet_Search
    Inherits Webvantage.BaseChildPage

#Region " Variables "

    Protected WithEvents RadDatePickerStartDate As Telerik.Web.UI.RadDatePicker
    Protected WithEvents RadDatePickerEndDate As Telerik.Web.UI.RadDatePicker
    Protected WithEvents RadComboBoxStatus As Telerik.Web.UI.RadComboBox

    Private StartDate As Date = Nothing
    Private EndDate As Date = Nothing
    Private TimesheetEmpCode As String = ""

    Private ThisEmpFullName As String = ""

    Private emp As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

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

#Region " Page "

    Private Sub Timesheet_Search_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)

        Me.RadDatePickerStartDate = CType(Me.RadToolbarTimesheetSearch.Items.FindItemByValue("StartDate").FindControl("RadDatePickerStartDate"), Telerik.Web.UI.RadDatePicker)
        Me.RadDatePickerEndDate = CType(Me.RadToolbarTimesheetSearch.Items.FindItemByValue("EndDate").FindControl("RadDatePickerEndDate"), Telerik.Web.UI.RadDatePicker)
        Me.RadComboBoxStatus = CType(Me.RadToolbarTimesheetSearch.Items.FindItemByValue("Status").FindControl("RadComboBoxStatus"), Telerik.Web.UI.RadComboBox)

        If Not Session("TimesheetEmpCode") Is Nothing Then
            Me.TimesheetEmpCode = Session("TimesheetEmpCode")
        Else
            Me.TimesheetEmpCode = Session("EmpCode")
            Session("TimesheetEmpCode") = Me.TimesheetEmpCode
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.SetRadDatePicker(Me.RadDatePickerStartDate)
            Me.SetRadDatePicker(Me.RadDatePickerEndDate)

            Me.RadDatePickerStartDate.SelectedDate = New Date(Now.Year, Now.Month, 1)
            Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday.Date

            Me.LoadStatus()

            Me.SetEmployeeStart()

        End If

    End Sub

    Private Sub SetEmployeeStart()

        If Session("TimesheetEmpCode") Is Nothing Then Session("TimesheetEmpCode") = Session("EmpCode")

        If emp Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("TimesheetEmpCode"))

            End Using

        End If
        If emp IsNot Nothing AndAlso emp.StartDate IsNot Nothing AndAlso Me.RadDatePickerStartDate.SelectedDate IsNot Nothing Then

            If emp.StartDate > Me.RadDatePickerStartDate.SelectedDate Then

                Me.RadDatePickerStartDate.SelectedDate = emp.StartDate

            End If

            Me.RadDatePickerStartDate.MinDate = emp.StartDate

        End If

    End Sub
#End Region

#Region " Controls "

    Private Sub RadToolbarTimesheetSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarTimesheetSearch.ButtonClick
        Select Case e.Item.Value
            Case "Refresh", "Search"
                Me.RadGridTimesheetSearch.Rebind()
        End Select
    End Sub

    Private Sub RadComboBoxStatus_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxStatus.SelectedIndexChanged

        Me.RadGridTimesheetSearch.Rebind()

    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        Me.RadGridTimesheetSearch.Rebind()

    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged

        Me.RadGridTimesheetSearch.Rebind()

    End Sub

    Private Sub RadGridTimesheetSearch_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTimesheetSearch.ItemCommand
        Dim URL As String = ""
        Dim s As String = ""
        Select Case e.CommandName
            Case "OpenTimesheetDay"

                Session("TimesheetStartDate") = CType(e.CommandArgument, DateTime).ToShortDateString()

                Dim DayOfWeek As Integer = CType(CType(e.CommandArgument, Date).DayOfWeek, Integer)

                If DayOfWeek <> StartWeekOn Then

                    Select Case StartWeekOn
                        Case System.DayOfWeek.Saturday
                            DayOfWeek += 1
                        Case System.DayOfWeek.Sunday

                        Case System.DayOfWeek.Monday
                            DayOfWeek -= 1
                    End Select

                End If

                Session("TimesheetMain_SingleViewDayOfWeek") = DayOfWeek
                Session("TimesheetCommentView_SingleViewDayOfWeek") = DayOfWeek
                Session("TimesheetMain_UserHasMadeASelection") = DayOfWeek

                'URL = "Timesheet.aspx?FromWindow=CurrentDTObject&tsdate=" & CType(e.CommandArgument, DateTime).ToShortDateString()
                URL = "Employee/Timesheet?emp=&dtd=1&nav=4&isdd=1&sd=" & CType(e.CommandArgument, DateTime).ToShortDateString()
                Me.OpenWindow("", URL, 0, 0, True)


            Case "Submit"
                If Me.SetApproval(CType(e.CommandArgument, Date), True, s) = True Then
                    Me.RadGridTimesheetSearch.Rebind()
                Else
                    Me.ShowMessage(s)
                End If
            Case "Unsubmit"
                If Me.SetApproval(CType(e.CommandArgument, Date), False, s) = True Then
                    Me.RadGridTimesheetSearch.Rebind()
                Else
                    Me.ShowMessage(s)
                End If
        End Select
    End Sub
    Private Sub RadGridTimesheetSearch_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTimesheetSearch.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then

            Dim StatusLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelStatus")
            Dim StatusLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("LinkButtonStatus")

            Dim ThisDay As New AdvantageFramework.Timesheet._TimesheetDay
            ThisDay = CType(e.Item.DataItem, AdvantageFramework.Timesheet._TimesheetDay)

            If ThisDay.PostPeriodIsClosed = False Then
                Select Case ThisDay.Status
                    Case AdvantageFramework.Timesheet.TimesheetApprovalType.Pending
                        With StatusLinkButton
                            .CommandName = "Unsubmit"
                            .ToolTip = "Click to Un-submit"
                        End With
                    Case AdvantageFramework.Timesheet.TimesheetApprovalType.NotSubmitted
                        With StatusLinkButton
                            .CommandName = "Submit"
                            .ToolTip = "Click to Submit"
                        End With
                    Case Else
                        StatusLinkButton.Visible = False
                End Select
                If ThisDay.TotalHours = 0 Then
                    StatusLinkButton.Visible = False
                End If
            Else
                StatusLinkButton.Visible = False
            End If

            StatusLabel.Visible = Not StatusLinkButton.Visible

        End If

    End Sub
    Private Sub RadGridTimesheetSearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTimesheetSearch.NeedDataSource

        If MiscFN.StartIsBeforeEnd(cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate), cGlobals.wvCDate(Me.RadDatePickerEndDate.SelectedDate)) = False Then

            Me.ShowMessage("Invalid date range.")
            Exit Sub

        End If

        Me.RadGridTimesheetSearch.MasterTableView.Caption = ""

        If Session("TimesheetEmpCode") Is Nothing Then

            Session("TimesheetEmpCode") = Session("EmpCode")

        End If

        If emp Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("TimesheetEmpCode"))

            End Using

        End If

        If emp IsNot Nothing AndAlso emp.StartDate IsNot Nothing AndAlso Me.RadDatePickerStartDate.SelectedDate IsNot Nothing Then

            If emp.StartDate > Me.RadDatePickerStartDate.SelectedDate Then

                Me.RadDatePickerStartDate.SelectedDate = emp.StartDate

            End If

            Me.RadDatePickerStartDate.MinDate = emp.StartDate

        End If
        Me.RadGridTimesheetSearch.DataSource = AdvantageFramework.Timesheet.GetDaysByApprovalType(Session("ConnString"), Session("TimesheetEmpCode"), Me.RadDatePickerStartDate.SelectedDate,
                                                                       Me.RadDatePickerEndDate.SelectedDate, Me.RadComboBoxStatus.SelectedValue)

        If Not emp Is Nothing Then

            Me.RadGridTimesheetSearch.MasterTableView.Caption = "Time for " & emp.ToString

        Else

            Me.RadGridTimesheetSearch.MasterTableView.Caption = "Time for " & Session("TimesheetEmpCode")

        End If

    End Sub

#End Region

#Region " Methods "

#Region " Approval "

    Private Function SetApproval(ByVal ThisDate As Date, ByVal Approval As Boolean, ByRef ErrorMessage As String) As Boolean
        Try

            'Dim m As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

            If AdvantageFramework.Timesheet.HasStopWatch(Session("ConnString"), Me.TimesheetEmpCode, ThisDate, ThisDate) = True Then

                ErrorMessage = "You have a stopwatch running.  Please stop it before proceeding."
                Return False

            End If

            If AdvantageFramework.Timesheet.DayIsMissingComment(Session("ConnString"), Session("UserCode"), Me.TimesheetEmpCode, ThisDate) = True And Approval = True Then

                ErrorMessage = ThisDate.DayOfWeek.ToString() & " is missing comment(s) and cannot be submitted for approval."
                Return False

            End If

            If ThisEmpFullName = "" Then

                ThisEmpFullName = GetEmpFullName(Me.TimesheetEmpCode)

            End If

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            oTS.SubmitForApproval(Me.TimesheetEmpCode, ThisDate, Approval)

            If GetSendAlertSuper() = True And Approval = True Then

                'Dim Alert As New Alert(Session("ConnString"))
                Dim agy As New cAgency(HttpContext.Current.Session("ConnString"))
                Dim NowDate As Date = Now
                Dim url As String = agy.WebvantageURL

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                    With FxAlert

                        .AlertTypeID = 3
                        .AlertCategoryID = 43
                        .Subject = "Timesheet Approval Request for " & ThisEmpFullName & " for " & cGlobals.wvCDate(ThisDate).ToShortDateString()
                        .Body = AdvantageFramework.EmployeeTimesheet.WriteTimesheetSuperviorApprovalLink(url, cGlobals.wvCDate(ThisDate).ToShortDateString(), Me.TimesheetEmpCode, False)
                        .EmailBody = .Body
                        .GeneratedDate = NowDate
                        .LastUpdated = NowDate
                        .PriorityLevel = 3
                        .EmployeeCode = Me.TimesheetEmpCode
                        .UserCode = Session("UserCode")

                    End With

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        Dim Alert As New Alert(Session("ConnString"))

                        Alert.LoadByPrimaryKey(FxAlert.ID)
                        Alert.AddAlertRecipient(GetEmpSuper(Me.TimesheetEmpCode))
                        SendEmailAlert(Alert.ALERT_ID)

                    Else

                        Me.ShowMessage("Alert failed to save")

                    End If

                End Using

            End If

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function
    Private Function GetEmpFullName(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String

        SQL_STR = "SELECT ISNULL(EMP_FML,'') FROM V_ACTIVE_EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)

            Return value

        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function
    Private Function SendEmailAlert(ByVal AlertID As Integer) As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .AppName = "Timesheet"
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Alert Email not Sent.  " & ex.Message.ToString())
            SendEmailAlert = False

        End Try
    End Function
    Private Function GetSendAlertSuper() As Boolean
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As Integer
        SQL_STR = "SELECT ISNULL(AUTO_ALERT_SUPER,0) FROM AGENCY"
        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetInt16(0)
            If value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function
    Private Function GetEmpSuper(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String
        SQL_STR = "SELECT ISNULL(SUPERVISOR_CODE,'') FROM EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"
        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)
            Return value
        Catch
            Err.Raise(Err.Number, "Class:Timesheet.aspx Routine:GetSendAlertSuper", Err.Description)
        End Try
    End Function

#End Region

    Private Sub LoadStatus()

        Dim t As New cTimeSheet(Session("ConnString"))


        With Me.RadComboBoxStatus.Items

            .Add(New Telerik.Web.UI.RadComboBoxItem("All Time", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.AllTime, Integer).ToString()))

            If t.IsApprovalActive(Me.TimesheetEmpCode) = True Then

                .Add(New Telerik.Web.UI.RadComboBoxItem("Not Submitted", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.NotSubmitted, Integer).ToString()))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Pending Approval", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Pending, Integer).ToString()))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Denied", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Denied, Integer).ToString()))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Approved", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Approved, Integer).ToString()))

            Else

                .Add(New Telerik.Web.UI.RadComboBoxItem("Entered", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Entered, Integer).ToString()))

            End If

            .Add(New Telerik.Web.UI.RadComboBoxItem("Missing", CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Missing, Integer).ToString()))

        End With

        If Request.QueryString("type") = "missing" Then
            Me.RadComboBoxStatus.SelectedValue = 5
        End If

    End Sub

#End Region

End Class
