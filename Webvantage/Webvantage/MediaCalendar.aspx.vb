Imports DayPilot.Web.Ui.Events
Imports DayPilot.Web.Ui.Events.Bubble
Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports Telerik.Web.UI

Imports Webvantage.TaskCalendar

Public Class MediaCalendar
    Inherits Webvantage.BaseChildPage

    Dim dtThisDate As Date

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_MediaCalendar)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'SessionDefaults()
            Dim c As New cDayPilot
            c.LoadMediaTabs(Me.RadTabStrip)

            LoGlo.PageCultureSet(Me.Page)

            If Me.IsClientPortal = True Then
                Me.RadToolBarMediaCalendar.FindItemByValue("Bookmark").Visible = False
            End If

            If Page.IsPostBack = True Or Page.IsCallback = True Then
                dtThisDate = CDate(ViewState("ThisDate"))
                'LoadCalendar()                
                Select Case Me.EventArgument
                    Case "Refresh"
                        If Not Session("MediaCalendarPage") Is Nothing Then
                            If Session("MediaCalendarPage") = "Week" Then
                                Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.WeekView
                                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "W")
                            End If
                            If Session("MediaCalendarPage") = "Day" Then
                                Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.DayView
                                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "D")
                            End If
                            If Session("MediaCalendarPage") = "Timeline" Then
                                Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView
                                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "T", 1)
                            End If
                            If Session("MediaCalendarPage") = "Month" Then
                                Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView
                                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "M")
                            End If
                        Else
                            Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView
                            LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "M")
                        End If
                    Case Else



                End Select
            Else
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Me.RadSchedulerProjectMediaCalendar.Culture = LoGlo.GetCultureInfo
                    'Me.RadSchedulerProjectMediaCalendar.TimeZoneID = AdvantageFramework.Database.Procedures.Generic.LoadEmployeeTimeZoneID(DbContext, Session("EmpCode"))
                End Using

                If Session("MediaCalendarSelectedDate") Is Nothing Then
                    Session("MediaCalendarSelectedDate") = cEmployee.TimeZoneToday
                    dtThisDate = cEmployee.TimeZoneToday
                Else
                    dtThisDate = CType(Session("MediaCalendarSelectedDate"), Date)
                End If
                Me.RadSchedulerProjectMediaCalendar.SelectedDate = dtThisDate
                'LoadDropDown(dtThisDate)
                If Not Session("MediaCalendarPage") Is Nothing Then
                    If Session("MediaCalendarPage") = "Week" Then
                        Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.WeekView
                        LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "W")
                    End If
                    If Session("MediaCalendarPage") = "Day" Then
                        Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.DayView
                        LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "D")
                    End If
                    If Session("MediaCalendarPage") = "Timeline" Then
                        Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView
                        LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "T", 1)
                    End If
                    If Session("MediaCalendarPage") = "Month" Then
                        Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView
                        LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "M")
                    End If
                Else
                    Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "M")
                End If
                Me.RadSchedulerProjectMediaCalendar.AdvancedForm.Enabled = False
                If Me.IsClientPortal = True Then
                    Me.RadSchedulerProjectMediaCalendar.AllowEdit = False
                    Me.RadSchedulerProjectMediaCalendar.AllowInsert = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolBarMediaCalendar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMediaCalendar.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"
                dtThisDate = CDate(ViewState("ThisDate"))
            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "MediaCalendar.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Media_MediaCalendar
                    .UserCode = Session("UserCode")
                    .Name = "Media Calendar"
                    .Description = "Media Calendar"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If

        End Select
    End Sub


    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(45)
        Catch ex As Exception

        End Try
    End Sub

#Region "Functions"

    Private Sub LoadCalendar(ByVal DateSelected As DateTime, ByVal view As String, Optional ByVal timeline As Integer = 0, Optional ByVal resource As Integer = 0)
        Dim c As New cDayPilot
        Dim DtCalendar As New DataTable
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim intDaysInMonth As Integer
        Dim dtFirst As Date
        Dim dtLast As Date
        Dim strEmpCode As String = ""
        Dim CP As Integer = 0
        If Me.IsClientPortal = True Then
            CP = 1
        End If
        ''Me.MonthViewCalendar.VisibleDate = dtThisDate
        'mediacalendar = New ClientMediaCalendar(CStr(Session("Connstring")))
        dtThisDate = DateSelected
        ViewState("ThisDate") = dtThisDate

        Dim oAppVars As cAppVars
        oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
        oAppVars.getAllAppVars()

        If view = "M" Or view = "2" Then
            dtFirst = LoGlo.FirstOfMonth(DateSelected)
            dtLast = LoGlo.LastOfMonth(DateSelected)
            Session("MediaCalendarPage") = "Month"
        ElseIf view = "D" Or view = "0" Then
            dtFirst = DateSelected
            dtLast = DateSelected
            Session("MediaCalendarPage") = "Day"
        ElseIf view = "W" Or view = "1" Then
            dtFirst = DayPilot.Utils.Week.FirstDayOfWeek(DateSelected)
            dtLast = dtFirst.AddDays(6)
            Session("MediaCalendarPage") = "Week"
        ElseIf view = "T" Or view = "4" Then
            dtFirst = DateSelected
            dtLast = DateSelected.AddDays(13)
            Session("MediaCalendarPage") = "Timeline"
        End If
        ' Set Up for navigation links
        intDaysInMonth = dtThisDate.DaysInMonth(dtThisDate.Year, dtThisDate.Month)

        If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") <> "" Then
            If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then
                DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                  oAppVars.getAppVar("mtfSClient"),
                                                                  oAppVars.getAppVar("mtfSDivision"),
                                                                  oAppVars.getAppVar("mtfSProduct"),
                                                                  oAppVars.getAppVar("mtfSMediaType"),
                                                                  oAppVars.getAppVar("mtfSCampaign"),
                                                                  oAppVars.getAppVar("mtfSClientPO"),
                                                                  oAppVars.getAppVar("mtfSVendor"),
                                                                  oAppVars.getAppVar("mtfSBuyer"),
                                                                  oAppVars.getAppVar("mtfIMagazine"),
                                                                  oAppVars.getAppVar("mtfINewspaper"),
                                                                  oAppVars.getAppVar("mtfIInternet"),
                                                                  oAppVars.getAppVar("mtfIOutOfHome"),
                                                                  oAppVars.getAppVar("mtfITelevision"),
                                                                  oAppVars.getAppVar("mtfIRadio"),
                                                                  oAppVars.getAppVar("mtfIAcceptedOrders"),
                                                                  oAppVars.getAppVar("mtfICancelledOrders"),
                                                                  oAppVars.getAppVar("mtfDClient"),
                                                                  oAppVars.getAppVar("mtfDDivision"),
                                                                  oAppVars.getAppVar("mtfDProduct"),
                                                                  oAppVars.getAppVar("mtfDType"),
                                                                  oAppVars.getAppVar("mtfDMediaType"),
                                                                  oAppVars.getAppVar("mtfDInsertionLine"),
                                                                  oAppVars.getAppVar("mtfDVendorCode"),
                                                                  oAppVars.getAppVar("mtfDVendorName"),
                                                                  oAppVars.getAppVar("mtfDJobComp"),
                                                                  oAppVars.getAppVar("mtfDCampaignCode"),
                                                                  oAppVars.getAppVar("mtfDCampaignName"),
                                                                  oAppVars.getAppVar("mtfDMarketCode"),
                                                                  oAppVars.getAppVar("mtfDMarketName"),
                                                                  oAppVars.getAppVar("mtfDAdSizeLength"),
                                                                  oAppVars.getAppVar("mtfDHeadlineProg"),
                                                                  oAppVars.getAppVar("mtfDExtMatDate"),
                                                                  oAppVars.getAppVar("mtfDCloseDate"),
                                                                  oAppVars.getAppVar("mtfDExtCloseDate"),
                                                                  oAppVars.getAppVar("mtfDRunDate"),
                                                                  oAppVars.getAppVar("mtfDBillingAmount"),
                                                                  oAppVars.getAppVar("mtfDSpots"),
                                                                  oAppVars.getAppVar("mtfDBMatDueDate"),
                                                                  oAppVars.getAppVar("mtfDBExtMatDueDate"),
                                                                  oAppVars.getAppVar("mtfDBCloseDate"),
                                                                  oAppVars.getAppVar("mtfDBExtCloseDate"),
                                                                  oAppVars.getAppVar("mtfDBRunInsertionDate"), False,
                                                                  otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint"),
                                                                  oAppVars.getAppVar("mtfSOffice"), dtFirst, dtLast, CP, Session("UserID"))
            ElseIf otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" Then
                DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                   oAppVars.getAppVar("msfSClient"),
                                                                   oAppVars.getAppVar("msfSDivision"),
                                                                   oAppVars.getAppVar("msfSProduct"),
                                                                   oAppVars.getAppVar("msfSMediaType"),
                                                                   oAppVars.getAppVar("msfSCampaign"),
                                                                   oAppVars.getAppVar("msfSClientPO"),
                                                                   oAppVars.getAppVar("msfSVendor"),
                                                                   oAppVars.getAppVar("msfSBuyer"),
                                                                   oAppVars.getAppVar("msfIMagazine"),
                                                                   oAppVars.getAppVar("msfINewspaper"),
                                                                   oAppVars.getAppVar("msfIInternet"),
                                                                   oAppVars.getAppVar("msfIOutOfHome"),
                                                                   oAppVars.getAppVar("msfITelevision"),
                                                                   oAppVars.getAppVar("msfIRadio"),
                                                                   oAppVars.getAppVar("msfIAcceptedOrders"),
                                                                   oAppVars.getAppVar("msfICancelledOrders"),
                                                                   oAppVars.getAppVar("msfDClient"),
                                                                   oAppVars.getAppVar("msfDDivision"),
                                                                   oAppVars.getAppVar("msfDProduct"),
                                                                   oAppVars.getAppVar("msfDType"),
                                                                   oAppVars.getAppVar("msfDMediaType"),
                                                                   oAppVars.getAppVar("msfDInsertionLine"),
                                                                   oAppVars.getAppVar("msfDVendorCode"),
                                                                   oAppVars.getAppVar("msfDVendorName"),
                                                                   oAppVars.getAppVar("msfDJobComp"),
                                                                   oAppVars.getAppVar("msfDCampaignCode"),
                                                                   oAppVars.getAppVar("msfDCampaignName"),
                                                                   oAppVars.getAppVar("msfDMarketCode"),
                                                                   oAppVars.getAppVar("msfDMarketName"),
                                                                   oAppVars.getAppVar("msfDAdSizeLength"),
                                                                   oAppVars.getAppVar("msfDHeadlineProg"),
                                                                   oAppVars.getAppVar("msfDExtMatDate"),
                                                                   oAppVars.getAppVar("msfDCloseDate"),
                                                                   oAppVars.getAppVar("msfDExtCloseDate"),
                                                                   oAppVars.getAppVar("msfDRunDate"),
                                                                   oAppVars.getAppVar("msfDBillingAmount"),
                                                                   oAppVars.getAppVar("msfDSpots"),
                                                                   oAppVars.getAppVar("msfDBMatDueDate"),
                                                                   oAppVars.getAppVar("msfDBExtMatDueDate"),
                                                                   oAppVars.getAppVar("msfDBCloseDate"),
                                                                   oAppVars.getAppVar("msfDBExtCloseDate"),
                                                                   oAppVars.getAppVar("msfDBRunInsertionDate"),
                                                                   oAppVars.getAppVar("msfDBDisplayFlight"),
                                                                   otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint"),
                                                                   oAppVars.getAppVar("msfSOffice"), dtFirst, dtLast, CP, Session("UserID"))
            Else
                DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month,
                                                                  dtThisDate.Year,
                                                                  CStr(Session("UserCode")),
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  True,
                                                                  False,
                                                                  True,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  True,
                                                                  False,
                                                                  True,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  True,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  False,
                                                                  "", dtFirst, dtLast, CP, Session("UserID"))
            End If
        Else
            DtCalendar = c.GetMediaCalendarDisplay("", dtThisDate.Month, dtThisDate.Year, CStr(Session("UserCode")), "", "", "", "", "", "", "", "", True, True, True, True, True, True, False, True, True, False, False, True, False, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, True, False, False, False, False, False, False, "", dtFirst, dtLast, CP, Session("UserID"))
        End If

        'If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") <> "" Then
        '    If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then
        '        DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month, _
        '                                                          dtThisDate.Year, _
        '                                                          CStr(Session("UserCode")), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSClient"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSDivision"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSProduct"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSMediaType"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSCampaign"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSClientPO"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSVendor"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSBuyer"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIMagazine"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfINewspaper"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIInternet"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIOutOfHome"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfITelevision"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIRadio"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfIAcceptedOrders"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfICancelledOrders"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDClient"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDDivision"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDProduct"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDType"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDMediaType"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDInsertionLine"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDVendorCode"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDVendorName"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDJobComp"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDCampaignCode"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDCampaignName"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDMarketCode"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDMarketName"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDAdSizeLength"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDHeadlineProg"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDExtMatDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDCloseDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDExtCloseDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDRunDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBillingAmount"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDSpots"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBMatDueDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBExtMatDueDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBCloseDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBExtCloseDate"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfDBRunInsertionDate"), False, _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint"), _
        '                                                          otask.getAppVars(Session("UserCode"), "MediaFilter", "mtfSOffice"), dtFirst, dtLast, CP, Session("UserID"))
        '    ElseIf otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" Then
        '        DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month, _
        '                                                          dtThisDate.Year, _
        '                                                          CStr(Session("UserCode")), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSClient"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSDivision"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSProduct"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSMediaType"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSCampaign"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSClientPO"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSVendor"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSBuyer"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIMagazine"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfINewspaper"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIInternet"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIOutOfHome"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfITelevision"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIRadio"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfIAcceptedOrders"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfICancelledOrders"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDClient"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDDivision"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDProduct"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDType"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDMediaType"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDInsertionLine"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDVendorCode"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDVendorName"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDJobComp"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDCampaignCode"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDCampaignName"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDMarketCode"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDMarketName"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDAdSizeLength"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDHeadlineProg"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDExtMatDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDCloseDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDExtCloseDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDRunDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBillingAmount"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDSpots"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBMatDueDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBExtMatDueDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBCloseDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBExtCloseDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBRunInsertionDate"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfDBDisplayFlight"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalPrint"), _
        '                                                           otask.getAppVars(Session("UserCode"), "MediaFilter", "msfSOffice"), dtFirst, dtLast, CP, Session("UserID"))
        '    Else
        '        DtCalendar = c.GetMediaCalendarDisplay(otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType"), dtThisDate.Month, _
        '                                                          dtThisDate.Year, _
        '                                                          CStr(Session("UserCode")), _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          "", _
        '                                                          True, _
        '                                                          True, _
        '                                                          True, _
        '                                                          True, _
        '                                                          True, _
        '                                                          True, _
        '                                                          False, _
        '                                                          True, _
        '                                                          True, _
        '                                                          False, _
        '                                                          False, _
        '                                                          True, _
        '                                                          False, _
        '                                                          True, _
        '                                                          True, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          True, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          False, _
        '                                                          "", dtFirst, dtLast, CP, Session("UserID"))
        '    End If
        'Else
        '    DtCalendar = c.GetMediaCalendarDisplay("", dtThisDate.Month, dtThisDate.Year, CStr(Session("UserCode")), "", "", "", "", "", "", "", "", True, True, True, True, True, True, False, True, True, False, False, True, False, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, True, False, False, False, False, False, False, "", dtFirst, dtLast, CP, Session("UserID"))
        'End If

        If timeline = 1 Then
            Dim dt As DataTable
            Dim row As DataRow
            dt = New DataTable("MediaType")
            Dim typecol As DataColumn = New DataColumn("TYPE")
            dt.Columns.Add(typecol)
            Dim type As String = ""
            For i As Integer = 0 To DtCalendar.Rows.Count - 1
                If type = "" Then
                    row = dt.NewRow
                    row.Item("TYPE") = DtCalendar.Rows(i)("TYPE").ToString
                    dt.Rows.Add(row)
                    type = DtCalendar.Rows(i)("TYPE").ToString
                ElseIf type <> DtCalendar.Rows(i)("TYPE").ToString Then
                    row = dt.NewRow
                    row.Item("TYPE") = DtCalendar.Rows(i)("TYPE").ToString
                    dt.Rows.Add(row)
                    type = DtCalendar.Rows(i)("TYPE").ToString
                End If
            Next

            Dim rstype As New ResourceType
            rstype.DataSource = dt
            rstype.Name = "Type"
            rstype.KeyField = "TYPE"
            rstype.TextField = "TYPE"
            rstype.ForeignKeyField = "TYPE"
            Me.RadSchedulerProjectMediaCalendar.ResourceTypes.Clear()
            Me.RadSchedulerProjectMediaCalendar.ResourceTypes.Add(rstype)
            Me.RadSchedulerProjectMediaCalendar.TimelineView.GroupBy = "Type"
            Me.RadSchedulerProjectMediaCalendar.TimelineView.GroupingDirection = GroupingDirection.Vertical
            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                Me.RadSchedulerProjectMediaCalendar.TimelineView.ColumnHeaderDateFormat = "MM/dd"
            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                Me.RadSchedulerProjectMediaCalendar.TimelineView.ColumnHeaderDateFormat = "dd/MM"
            Else
                Me.RadSchedulerProjectMediaCalendar.TimelineView.ColumnHeaderDateFormat = "dd.MM"
            End If
            Me.RadSchedulerProjectMediaCalendar.DataKeyField = "ID"
            Me.RadSchedulerProjectMediaCalendar.DataSubjectField = "TYPE"
        Else
            Me.RadSchedulerProjectMediaCalendar.DataKeyField = "ID"
            Me.RadSchedulerProjectMediaCalendar.DataSubjectField = "DATA_KEY"
            Me.RadSchedulerProjectMediaCalendar.ResourceTypes.Clear()
            Dim rstype As New ResourceType
            rstype.DataSource = DtCalendar
            rstype.Name = "Type"
            rstype.KeyField = "TYPE"
            rstype.TextField = "TYPE"
            rstype.ForeignKeyField = "TYPE"
            RadSchedulerProjectMediaCalendar.ResourceTypes.Add(rstype)
        End If

        'Me.GridView1.DataSource = DtCalendar
        'Me.GridView1.DataBind()

        Me.RadSchedulerProjectMediaCalendar.DataSource = DtCalendar
        Me.RadSchedulerProjectMediaCalendar.DataBind()
        Me.RadSchedulerProjectMediaCalendar.AppointmentComparer = New CustomAppointmentComparer()
        Session("MediaCalendarSelectedDate") = DateSelected

        Session("MediaMonthView") = DtCalendar

        'Try
        '    If Not Session("MediaCalendarSelectedDate") = Nothing Then
        '        If cGlobals.wvIsDate(Session("MediaCalendarSelectedDate")) = True Then
        '            Me.ddMonth.SelectedValue = CType(Session("MediaCalendarSelectedDate"), Date).Month.ToString()
        '            Me.ddYear.SelectedValue = CType(Session("MediaCalendarSelectedDate"), Date).Year.ToString()
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try

        'Me.GridView1.DataSource = DtCalendar
        'Me.GridView1.DataBind()

    End Sub

    Private Sub SessionDefaults()
        If Session("MediaCalendarSelectedDate") Is Nothing Then
            Session("MediaCalendarSelectedDate") = Date.Today
        End If
        If Session("MediaCalType") Is Nothing Then
            Session("MediaCalType") = "Traffic"
        End If


        If Session("mtfSClient") Is Nothing Then
            Session("mtfSClient") = ""
        End If
        If Session("mtfSDivision") Is Nothing Then
            Session("mtfSDivision") = ""
        End If
        If Session("mtfSProduct") Is Nothing Then
            Session("mtfSProduct") = ""
        End If
        If Session("mtfSClientText") Is Nothing Then
            Session("mtfSClientText") = ""
        End If
        If Session("mtfSDivisionText") Is Nothing Then
            Session("mtfSDivisionText") = ""
        End If
        If Session("mtfSProductText") Is Nothing Then
            Session("mtfSProductText") = ""
        End If
        If Session("mtfSCampaign") Is Nothing Then
            Session("mtfSCampaign") = ""
        End If
        If Session("mtfSMediaType") Is Nothing Then
            Session("mtfSMediaType") = ""
        End If
        If Session("mtfSClientPO") Is Nothing Then
            Session("mtfSClientPO") = ""
        End If
        If Session("mtfSVendor") Is Nothing Then
            Session("mtfSVendor") = ""
        End If
        If Session("mtfSBuyer") Is Nothing Then
            Session("mtfSBuyer") = ""
        End If
        If Session("mtfSOffice") Is Nothing Then
            Session("mtfSOffice") = ""
        End If


        If Session("mtfIMagazine") Is Nothing Then
            Session("mtfIMagazine") = True
        End If
        If Session("mtfINewspaper") Is Nothing Then
            Session("mtfINewspaper") = True
        End If
        If Session("mtfIInternet") Is Nothing Then
            Session("mtfIInternet") = True
        End If
        If Session("mtfIOutOfHome") Is Nothing Then
            Session("mtfIOutOfHome") = True
        End If
        If Session("mtfITelevision") Is Nothing Then
            Session("mtfITelevision") = True
        End If
        If Session("mtfIRadio") Is Nothing Then
            Session("mtfIRadio") = True
        End If
        If Session("mtfIAcceptedOrders") Is Nothing Then
            Session("mtfIAcceptedOrders") = False
        End If
        If Session("mtfICancelledOrders") Is Nothing Then
            Session("mtfICancelledOrders") = True
        End If


        If Session("mtfDClient") Is Nothing Then
            Session("mtfDClient") = True
        End If
        If Session("mtfDType") Is Nothing Then
            Session("mtfDType") = True
        End If
        If Session("mtfDInsertionLine") Is Nothing Then
            Session("mtfDInsertionLine") = True
        End If
        If Session("mtfDVendorCode") Is Nothing Then
            Session("mtfDVendorCode") = True
        End If
        If Session("mtfDBMatDueDate") Is Nothing Then
            Session("mtfDBMatDueDate") = True
        End If
        If Session("mtfDBExtMatDueDate") Is Nothing Then
            Session("mtfDBExtMatDueDate") = False
        End If
        If Session("mtfDBCloseDate") Is Nothing Then
            Session("mtfDBCloseDate") = False
        End If
        If Session("mtfDBExtCloseDate") Is Nothing Then
            Session("mtfDBExtCloseDate") = False
        End If
        If Session("mtfDBRunInsertionDate") Is Nothing Then
            Session("mtfDBRunInsertionDate") = False
        End If

        If Session("mtfDDivision") Is Nothing Then
            Session("mtfDDivision") = False
        End If
        If Session("mtfDProduct") Is Nothing Then
            Session("mtfDProduct") = False
        End If
        If Session("mtfDMediaType") Is Nothing Then
            Session("mtfDMediaType") = False
        End If
        If Session("mtfDVendorName") Is Nothing Then
            Session("mtfDVendorName") = False
        End If
        If Session("mtfDJobComp") Is Nothing Then
            Session("mtfDJobComp") = False
        End If
        If Session("mtfDCampaignCode") Is Nothing Then
            Session("mtfDCampaignCode") = False
        End If
        If Session("mtfDCampaignName") Is Nothing Then
            Session("mtfDCampaignName") = False
        End If
        If Session("mtfDMarketCode") Is Nothing Then
            Session("mtfDMarketCode") = False
        End If
        If Session("mtfDMarketName") Is Nothing Then
            Session("mtfDMarketName") = False
        End If
        If Session("mtfDAdSizeLength") Is Nothing Then
            Session("mtfDAdSizeLength") = False
        End If
        If Session("mtfDHeadlineProg") Is Nothing Then
            Session("mtfDHeadlineProg") = False
        End If
        If Session("mtfDExtMatDate") Is Nothing Then
            Session("mtfDExtMatDate") = False
        End If
        If Session("mtfDCloseDate") Is Nothing Then
            Session("mtfDCloseDate") = False
        End If
        If Session("mtfDExtCloseDate") Is Nothing Then
            Session("mtfDExtCloseDate") = False
        End If
        If Session("mtfDRunDate") Is Nothing Then
            Session("mtfDRunDate") = False
        End If
        If Session("mtfDBillingAmount") Is Nothing Then
            Session("mtfDBillingAmount") = False
        End If
        If Session("mtfDSpots") Is Nothing Then
            Session("mtfDSpots") = False
        End If


    End Sub

    Private Function RenderEventMC(ByVal data As System.Data.DataRowView)
        Try
            Dim SbDetails As New System.Text.StringBuilder
            Dim otask As cTasks = New cTasks(Session("ConnString"))

            Dim oAppVars As cAppVars
            oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
            oAppVars.getAllAppVars()

            'set text string to display
            If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") <> "" Then
                If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then
                    With SbDetails
                        If oAppVars.getAppVar("mtfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
                            .Append(data.Item("CL_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
                            .Append(data.Item("DIV_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
                            .Append(data.Item("PRD_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDType") = True And data.Item("TYPE").ToString() <> "" Then
                            .Append(data.Item("TYPE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
                            .Append(data.Item("MEDIA_TYPE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDInsertionLine") = True Then
                            .Append(data.Item("ORDER_NBR"))
                            .Append("-")
                            .Append(data.Item("LINE_NBR"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
                            .Append(data.Item("VN_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
                            .Append(data.Item("VN_NAME"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDJobComp") = True Then
                            .Append(data.Item("JOB_NUMBER"))
                            .Append("-")
                            .Append(data.Item("JOB_COMPONENT_NBR"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
                            .Append(data.Item("CMP_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
                            .Append(data.Item("CMP_NAME"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
                            .Append(data.Item("MARKET_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("mtfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
                            .Append(data.Item("MARKET_DESC"))
                            .Append("|")
                        End If

                        Dim strshow As String = ""
                        If oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
                            strshow = strshow & data.Item("LENGTH").ToString() & "|"
                        ElseIf oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
                            strshow = strshow & data.Item("SIZE_DESC").ToString() & "|"
                        ElseIf oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
                            strshow = strshow & data.Item("SIZE").ToString() & "|"
                        End If

                        If oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
                            strshow = strshow & data.Item("PROGRAMMING").ToString() & "|"
                        ElseIf oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
                            strshow = strshow & data.Item("HEADLINE").ToString() & "|"
                        End If
                        If oAppVars.getAppVar("mtfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        If oAppVars.getAppVar("mtfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        If oAppVars.getAppVar("mtfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        'If ( oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "") Or ( oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "") Then
                        '    strshow = strshow & data.Item("FLIGHT_DATES").ToString() & "|"
                        If oAppVars.getAppVar("mtfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        .Append(strshow)

                    End With
                ElseIf otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" Then
                    With SbDetails
                        If oAppVars.getAppVar("msfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
                            .Append(data.Item("CL_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
                            .Append(data.Item("DIV_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
                            .Append(data.Item("PRD_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDType") = True And data.Item("TYPE").ToString() <> "" Then
                            .Append(data.Item("TYPE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
                            .Append(data.Item("MEDIA_TYPE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDInsertionLine") = True Then
                            .Append(data.Item("ORDER_NBR"))
                            .Append("-")
                            .Append(data.Item("LINE_NBR"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
                            .Append(data.Item("VN_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
                            .Append(data.Item("VN_NAME"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDJobComp") = True Then
                            .Append(data.Item("JOB_NUMBER"))
                            .Append("-")
                            .Append(data.Item("JOB_COMPONENT_NBR"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
                            .Append(data.Item("CMP_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
                            .Append(data.Item("CMP_NAME"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
                            .Append(data.Item("MARKET_CODE"))
                            .Append("|")
                        End If
                        If oAppVars.getAppVar("msfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
                            .Append(data.Item("MARKET_DESC"))
                            .Append("|")
                        End If

                        Dim strshow As String = ""
                        If oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
                            strshow = strshow & data.Item("LENGTH").ToString() & "|"
                        ElseIf oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
                            strshow = strshow & data.Item("SIZE_DESC").ToString() & "|"
                        ElseIf oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
                            strshow = strshow & data.Item("SIZE").ToString() & "|"
                        End If
                        If oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
                            strshow = strshow & data.Item("PROGRAMMING").ToString() & "|"
                        ElseIf oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
                            strshow = strshow & data.Item("HEADLINE").ToString() & "|"
                        End If
                        If oAppVars.getAppVar("msfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        If oAppVars.getAppVar("msfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        If oAppVars.getAppVar("msfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        'If ( oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "") Or ( oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "") Then
                        '    strshow = strshow & data.Item("FLIGHT_DATES").ToString() & "|"
                        If oAppVars.getAppVar("msfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                            'strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
                            strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "|"
                        End If
                        .Append(strshow)

                    End With
                Else
                    'default:
                    With SbDetails
                        .Append(data.Item("CL_CODE"))
                        .Append("|")
                        .Append(data.Item("TYPE"))
                        .Append("|")
                        .Append(data.Item("ORDER_NBR"))
                        .Append("-")
                        .Append(data.Item("LINE_NBR"))
                        .Append("|")
                        .Append(data.Item("VN_CODE"))
                    End With
                End If
            Else
                'default:
                With SbDetails
                    .Append(data.Item("CL_CODE"))
                    .Append("|")
                    .Append(data.Item("TYPE"))
                    .Append("|")
                    .Append(data.Item("ORDER_NBR"))
                    .Append("-")
                    .Append(data.Item("LINE_NBR"))
                    .Append("|")
                    .Append(data.Item("VN_CODE"))
                End With
            End If



            'If Not Session("MediaCalType") Is Nothing Then
            '    If Session("MediaCalType") = "Traffic" Then
            '        With SbDetails
            '            If Session("mtfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
            '                .Append(data.Item("CL_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
            '                .Append(data.Item("DIV_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
            '                .Append(data.Item("PRD_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDType") = True And data.Item("TYPE").ToString() <> "" Then
            '                .Append(data.Item("TYPE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
            '                .Append(data.Item("MEDIA_TYPE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDInsertionLine") = True Then
            '                .Append(data.Item("ORDER_NBR"))
            '                .Append("-")
            '                .Append(data.Item("LINE_NBR"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
            '                .Append(data.Item("VN_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
            '                .Append(data.Item("VN_NAME"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDJobComp") = True Then
            '                .Append(data.Item("JOB_NUMBER"))
            '                .Append("-")
            '                .Append(data.Item("JOB_COMPONENT_NBR"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
            '                .Append(data.Item("CMP_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
            '                .Append(data.Item("CMP_NAME"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
            '                .Append(data.Item("MARKET_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("mtfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
            '                .Append(data.Item("MARKET_DESC"))
            '                .Append("|")
            '            End If

            '            Dim strshow As String = ""
            '            If Session("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or Session("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
            '                strshow = strshow & data.Item("LENGTH").ToString() & "|"
            '            ElseIf Session("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
            '                strshow = strshow & data.Item("SIZE_DESC").ToString() & "|"
            '            ElseIf Session("mtfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
            '                strshow = strshow & data.Item("SIZE").ToString() & "|"
            '            End If

            '            If Session("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or Session("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
            '                strshow = strshow & data.Item("PROGRAMMING").ToString() & "|"
            '            ElseIf Session("mtfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
            '                strshow = strshow & data.Item("HEADLINE").ToString() & "|"
            '            End If
            '            If Session("mtfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            If Session("mtfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            If Session("mtfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            'If (Session("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "") Or (Session("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "") Then
            '            '    strshow = strshow & data.Item("FLIGHT_DATES").ToString() & "|"
            '            If Session("mtfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            .Append(strshow)

            '        End With
            '    ElseIf Session("MediaCalType") = "Schedule" Then
            '        With SbDetails
            '            If Session("msfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
            '                .Append(data.Item("CL_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
            '                .Append(data.Item("DIV_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
            '                .Append(data.Item("PRD_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDType") = True And data.Item("TYPE").ToString() <> "" Then
            '                .Append(data.Item("TYPE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
            '                .Append(data.Item("MEDIA_TYPE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDInsertionLine") = True Then
            '                .Append(data.Item("ORDER_NBR"))
            '                .Append("-")
            '                .Append(data.Item("LINE_NBR"))
            '                .Append("|")
            '            End If
            '            If Session("msfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
            '                .Append(data.Item("VN_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
            '                .Append(data.Item("VN_NAME"))
            '                .Append("|")
            '            End If
            '            If Session("msfDJobComp") = True Then
            '                .Append(data.Item("JOB_NUMBER"))
            '                .Append("-")
            '                .Append(data.Item("JOB_COMPONENT_NBR"))
            '                .Append("|")
            '            End If
            '            If Session("msfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
            '                .Append(data.Item("CMP_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
            '                .Append(data.Item("CMP_NAME"))
            '                .Append("|")
            '            End If
            '            If Session("msfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
            '                .Append(data.Item("MARKET_CODE"))
            '                .Append("|")
            '            End If
            '            If Session("msfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
            '                .Append(data.Item("MARKET_DESC"))
            '                .Append("|")
            '            End If

            '            Dim strshow As String = ""
            '            If Session("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or Session("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
            '                strshow = strshow & data.Item("LENGTH").ToString() & "|"
            '            ElseIf Session("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
            '                strshow = strshow & data.Item("SIZE_DESC").ToString() & "|"
            '            ElseIf Session("msfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
            '                strshow = strshow & data.Item("SIZE").ToString() & "|"
            '            End If
            '            If Session("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or Session("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
            '                strshow = strshow & data.Item("PROGRAMMING").ToString() & "|"
            '            ElseIf Session("msfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
            '                strshow = strshow & data.Item("HEADLINE").ToString() & "|"
            '            End If
            '            If Session("mtfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            If Session("mtfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            If Session("mtfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            'If (Session("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "") Or (Session("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "") Then
            '            '    strshow = strshow & data.Item("FLIGHT_DATES").ToString() & "|"
            '            If Session("mtfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
            '                'strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "|"
            '                strshow = strshow & LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "|"
            '            End If
            '            .Append(strshow)

            '        End With
            '    Else
            '        'default:
            '        With SbDetails
            '            .Append(data.Item("CL_CODE"))
            '            .Append("|")
            '            .Append(data.Item("TYPE"))
            '            .Append("|")
            '            .Append(data.Item("ORDER_NBR"))
            '            .Append("-")
            '            .Append(data.Item("LINE_NBR"))
            '            .Append("|")
            '            .Append(data.Item("VN_CODE"))
            '        End With
            '    End If
            'Else
            '    'default:
            '    With SbDetails
            '        .Append(data.Item("CL_CODE"))
            '        .Append("|")
            '        .Append(data.Item("TYPE"))
            '        .Append("|")
            '        .Append(data.Item("ORDER_NBR"))
            '        .Append("-")
            '        .Append(data.Item("LINE_NBR"))
            '        .Append("|")
            '        .Append(data.Item("VN_CODE"))
            '    End With
            'End If
            'clean up text:
            Dim s As String = MiscFN.RemoveTrailingDelimiter(SbDetails.ToString().Trim(), "|")
            s = MiscFN.RemoveTrailingDelimiter(s, "|")
            's = s.Replace("|", "<strong>|</strong>")
            'e.InnerHTML = s
            Return s
            SbDetails = Nothing


            'end set background color
        Catch ex As Exception

        End Try
    End Function

    Private Function RenderEventToolTip(ByVal data As System.Data.DataRowView)
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim oAppVars As cAppVars
            oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
            oAppVars.getAllAppVars()

            Dim SbDetails As New System.Text.StringBuilder
            With SbDetails
                If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then

                    If oAppVars.getAppVar("mtfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
                        .Append("Client: ")
                        .Append(data.Item("CL_CODE").ToString())
                        .Append(" - ")
                        .Append(data.Item("CL_NAME").ToString())
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
                        .Append("Division: ")
                        .Append(data.Item("DIV_CODE").ToString())
                        .Append(" - ")
                        .Append(data.Item("DIV_NAME").ToString())
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
                        .Append("Product: ")
                        .Append(data.Item("PRD_CODE").ToString())
                        .Append(" - ")
                        .Append(data.Item("PRD_DESCRIPTION").ToString())
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDType") = True And data.Item("TYPE").ToString() <> "" Then
                        .Append("Type: ")
                        .Append(data.Item("TYPE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
                        .Append("Media Type: ")
                        .Append(data.Item("MEDIA_TYPE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDInsertionLine") = True Then
                        .Append("Insertion Order/Line Number:  ")
                        .Append(data.Item("ORDER_NBR"))
                        .Append("-")
                        .Append(data.Item("LINE_NBR"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
                        .Append("Vendor Code: ")
                        .Append(data.Item("VN_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
                        .Append("Vendor Name: ")
                        .Append(data.Item("VN_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDJobComp") = True Then
                        .Append("Job/Component Number: ")
                        .Append(data.Item("JOB_NUMBER").ToString().PadLeft(6, "0"))
                        .Append(" - ")
                        .Append(data.Item("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
                        .Append("Campaign Code: ")
                        .Append(data.Item("CMP_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
                        .Append("Campaign Name: ")
                        .Append(data.Item("CMP_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
                        .Append("Market Code: ")
                        .Append(data.Item("MARKET_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("mtfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
                        .Append("Market Name: ")
                        .Append(data.Item("MARKET_DESC"))
                        .Append("<br />")
                    End If

                    Dim strshow As String = ""
                    If oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("LENGTH").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("SIZE_DESC").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("mtfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("SIZE").ToString() & "<br />"
                    End If

                    If oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
                        strshow &= "Headline/Programming: "
                        strshow &= data.Item("PROGRAMMING").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("mtfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
                        strshow &= "Headline/Programming: "
                        strshow &= data.Item("HEADLINE").ToString() & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Extended Material Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Close Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Extended Close Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "" Or oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "" Then
                        strshow &= "Run Date: "
                        strshow &= data.Item("FLIGHT_DATES").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("mtfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Run Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    .Append(strshow)




                Else


                    If oAppVars.getAppVar("msfDClient") = True And data.Item("CL_CODE").ToString() <> "" Then
                        .Append("Client: ")
                        .Append(data.Item("CL_CODE"))
                        .Append(" - ")
                        .Append(data.Item("CL_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDDivision") = True And data.Item("DIV_CODE").ToString() <> "" Then
                        .Append("Division: ")
                        .Append(data.Item("DIV_CODE"))
                        .Append(" - ")
                        .Append(data.Item("DIV_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDProduct") = True And data.Item("PRD_CODE").ToString() <> "" Then
                        .Append("Product: ")
                        .Append(data.Item("PRD_CODE"))
                        .Append(" - ")
                        .Append(data.Item("PRD_DESCRIPTION"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDType") = True And data.Item("TYPE").ToString() <> "" Then
                        .Append("Type: ")
                        .Append(data.Item("TYPE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDMediaType") = True And data.Item("MEDIA_TYPE").ToString() <> "" Then
                        .Append("Media Type: ")
                        .Append(data.Item("MEDIA_TYPE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDInsertionLine") = True Then
                        .Append("Insertion Order/Line Number:  ")
                        .Append(data.Item("ORDER_NBR"))
                        .Append("-")
                        .Append(data.Item("LINE_NBR"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDVendorCode") = True And data.Item("VN_CODE").ToString() <> "" Then
                        .Append("Vendor Code: ")
                        .Append(data.Item("VN_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDVendorName") = True And data.Item("VN_NAME").ToString() <> "" Then
                        .Append("Vendor Name: ")
                        .Append(data.Item("VN_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDJobComp") = True Then
                        .Append("Job/Component Number: ")
                        .Append(data.Item("JOB_NUMBER").ToString().PadLeft(6, "0"))
                        .Append(" - ")
                        .Append(data.Item("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDCampaignCode") = True And data.Item("CMP_CODE").ToString() <> "" Then
                        .Append("Campaign Code: ")
                        .Append(data.Item("CMP_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDCampaignName") = True And data.Item("CMP_NAME").ToString() <> "" Then
                        .Append("Campaign Name: ")
                        .Append(data.Item("CMP_NAME"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDMarketCode") = True And data.Item("MARKET_CODE").ToString() <> "" Then
                        .Append("Market Code: ")
                        .Append(data.Item("MARKET_CODE"))
                        .Append("<br />")
                    End If
                    If oAppVars.getAppVar("msfDMarketName") = True And data.Item("MARKET_DESC").ToString() <> "" Then
                        .Append("Market Name: ")
                        .Append(data.Item("MARKET_DESC"))
                        .Append("<br />")
                    End If

                    Dim strshow As String = ""
                    If oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "R" And data.Item("LENGTH").ToString() <> "" Or oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "T" And data.Item("LENGTH").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("LENGTH").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("TYPE").ToString() = "O" And data.Item("SIZE_DESC").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("SIZE_DESC").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("msfDAdSizeLength") = True And data.Item("SIZE").ToString() <> "" Then
                        strshow = "Ad Size/Length: "
                        strshow &= data.Item("SIZE").ToString() & "<br />"
                    End If

                    If oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "R" And data.Item("PROGRAMMING").ToString() <> "" Or oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("TYPE").ToString() = "T" And data.Item("PROGRAMMING").ToString() <> "" Then
                        strshow &= "Headline/Programming: "
                        strshow &= data.Item("PROGRAMMING").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("msfDHeadlineProg") = True And data.Item("HEADLINE").ToString() <> "" Then
                        strshow &= "Headline/Programming: "
                        strshow &= data.Item("HEADLINE").ToString() & "<br />"
                    End If

                    If oAppVars.getAppVar("mtfDExtMatDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Extended Material Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_MATL_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("EXT_MATL_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDCloseDate") = True And LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Close Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("CLOSE_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDExtCloseDate") = True And LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Extended Close Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("EXT_CLOSE_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("EXT_CLOSE_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    If oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "R" And data.Item("FLIGHT_DATES").ToString() <> "" Or oAppVars.getAppVar("mtfDRunDate") = True And data.Item("TYPE").ToString() = "T" And data.Item("FLIGHT_DATES").ToString() <> "" Then
                        strshow &= "Run Date: "
                        strshow &= data.Item("FLIGHT_DATES").ToString() & "<br />"
                    ElseIf oAppVars.getAppVar("mtfDRunDate") = True And LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) <> LoGlo.FormatDate("1/1/1900") Then
                        strshow &= "Run Date: "
                        'strshow &= LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.Month.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Day.ToString() & "/" & CType(data.Item("START_DATE"), Date).Date.Year.ToString.Substring(2)) & "<br />"
                        strshow &= LoGlo.FormatDate(CType(data.Item("START_DATE"), Date).Date.ToShortDateString) & "<br />"
                    End If
                    .Append(strshow)
                End If
            End With

            Return SbDetails.ToString
            SbDetails = Nothing

        Catch ex As Exception

        End Try
    End Function

#End Region

    Public Class CustomAppointmentComparer
        Inherits Webvantage.BaseChildPage : Implements System.Collections.Generic.IComparer(Of Telerik.Web.UI.Appointment)

        Public Function Compare(ByVal first As Appointment, ByVal second As Appointment) As Integer Implements System.Collections.Generic.IComparer(Of Telerik.Web.UI.Appointment).Compare
            Try
                If IsDBNull(first) = True Or IsDBNull(second) = True Then
                    Exit Function
                End If

                Dim key1 As String() = first.Description.Split("|")
                Dim key2 As String() = second.Description.Split("|")

                Dim key3 As String() = key1(1).Split("|")
                Dim key4 As String() = key2(1).Split("|")

                If Session("CalendarPage") = "Timeline" Then
                    If key1(1) < key2(1) Then
                        Return -1
                    End If

                    If key1(1) > key2(1) Then
                        Return 1
                    End If
                Else
                    If key1(1) < key2(1) Then
                        Return -1
                    End If

                    If key1(1) > key2(1) Then
                        Return 1
                    End If
                End If


            Catch ex As Exception

            End Try
        End Function

    End Class

#Region "Scheduler"

    Private Sub RadSchedulerProjectMediaCalendar_AppointmentClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerEventArgs) Handles RadSchedulerProjectMediaCalendar.AppointmentClick
        Try
            Dim str() As String = e.Appointment.Description.Split("|")
            Dim str2() As String = e.Appointment.Subject.Split("|")
            Dim url As String = "MediaCalendar_OrderDetail.aspx?OrdNo=" & str(2) & "&LineNo=" & str(3) & "&MediaType=" & str(1) & "&RevNo=" & str(4) & "&Year=" & str(5)
            Me.OpenWindow(str2(0), url, 700, 650, False, True, "RefreshPage")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_AppointmentCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentCommandEventArgs) Handles RadSchedulerProjectMediaCalendar.AppointmentCommand


        Dim str() As String = e.Container.Appointment.Description.Split("|")
        Dim MediaType As String = str(1)
        Dim OrderNumber As Integer = str(2)

        If e.CommandName = "Docs" Then
            Try
                Dim documentsMagazine As Generic.List(Of AdvantageFramework.Database.Entities.MagazineDocument) = Nothing
                Dim documentsNewspaper As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperDocument) = Nothing
                Dim documentsOutofHome As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeDocument) = Nothing
                Dim documentsInternet As Generic.List(Of AdvantageFramework.Database.Entities.InternetDocument) = Nothing
                Dim documentsRadio As Generic.List(Of AdvantageFramework.Database.Entities.RadioDocument) = Nothing
                Dim documentsTelevision As Generic.List(Of AdvantageFramework.Database.Entities.TVDocument) = Nothing

                Dim DtRecs As New DataTable
                Dim zip As New Ionic.Zip.ZipFile

                Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
                COL_DOC_ID.DataType = GetType(Int32)

                Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
                COL_MIME_TYPE.DataType = GetType(String)

                Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
                COL_FILENAME.DataType = GetType(String)

                Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
                COL_REPOSITORY_FILENAME.DataType = GetType(String)

                Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
                COL_UPLOADED_DATE.DataType = GetType(DateTime)

                With DtRecs.Columns

                    .Add(COL_DOC_ID)
                    .Add(COL_FILENAME)
                    .Add(COL_REPOSITORY_FILENAME)
                    .Add(COL_UPLOADED_DATE)

                End With

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If MediaType = "M" Then
                        documentsMagazine = AdvantageFramework.Database.Procedures.MagazineDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsMagazine IsNot Nothing Then
                            Select Case documentsMagazine.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsMagazine.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsMagazine
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If
                    If MediaType = "N" Then
                        documentsNewspaper = AdvantageFramework.Database.Procedures.NewspaperDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsNewspaper IsNot Nothing Then
                            Select Case documentsNewspaper.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsNewspaper.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsNewspaper
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If
                    If MediaType = "I" Then
                        documentsInternet = AdvantageFramework.Database.Procedures.InternetDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsInternet IsNot Nothing Then
                            Select Case documentsInternet.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsInternet.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsInternet
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If
                    If MediaType = "O" Then
                        documentsOutofHome = AdvantageFramework.Database.Procedures.OutOfHomeDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsOutofHome IsNot Nothing Then
                            Select Case documentsOutofHome.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsOutofHome.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsOutofHome
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If
                    If MediaType = "R" Then
                        documentsRadio = AdvantageFramework.Database.Procedures.RadioDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsRadio IsNot Nothing Then
                            Select Case documentsRadio.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsRadio.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsRadio
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If
                    If MediaType = "T" Then
                        documentsTelevision = AdvantageFramework.Database.Procedures.TVDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                        If documentsTelevision IsNot Nothing Then
                            Select Case documentsTelevision.Count
                                Case 0
                                    Me.ShowMessage("No file(s)")
                                Case 1
                                    Dim DocumentId As Integer = documentsTelevision.Item(0).DocumentID
                                    Me.DeliverFile(DocumentId)
                                Case > 1
                                    For Each magazineDoc In documentsTelevision
                                        Dim DocumentId As Integer = magazineDoc.DocumentID
                                        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                        If Document IsNot Nothing Then

                                            Dim r As DataRow

                                            r = DtRecs.NewRow()

                                            r("DocId") = Document.ID
                                            r("Filename") = Document.FileName
                                            r("RepositoryFilename") = Document.FileSystemFileName
                                            r("UploadedDate") = Document.UploadedDate

                                            DtRecs.Rows.Add(r)

                                        End If

                                    Next

                                    If Not DtRecs Is Nothing Then

                                        If DtRecs.Rows.Count > 0 Then

                                            Dim rep As New DocumentRepository(_Session.ConnectionString)
                                            rep.GetDocuments(DtRecs, zip)
                                        End If

                                    End If

                                    zip.Save(Response.OutputStream)

                                    With Response

                                        .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                        .ContentType = "application/zip"
                                        .End()

                                    End With

                            End Select
                        End If

                    End If

                End Using






            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_AppointmentContextMenuItemClicked(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentContextMenuItemClickedEventArgs) Handles RadSchedulerProjectMediaCalendar.AppointmentContextMenuItemClicked
        Try

            Dim str() As String = e.Appointment.Description.Split("|")
            Dim str2() As String = e.Appointment.Subject.Split("|")
            Dim MediaType As String = str(1)
            Dim OrderNumber As Integer = str(2)

            If e.MenuItem.Value = "Edit" Then
                Dim StrEditURL As String = "MediaCalendar_OrderDetail.aspx?OrdNo=" & str(2) & "&LineNo=" & str(3) & "&MediaType=" & str(1) & "&RevNo=" & str(4) & "&Year=" & str(5)
                If e.MenuItem.Value = "Edit" Then
                    Me.OpenWindow(str2(0), StrEditURL, 700, 650, False, True, "RefreshPage")
                End If
            End If

            If e.MenuItem.Value = "Docs" Then
                Try
                    Dim documentsMagazine As Generic.List(Of AdvantageFramework.Database.Entities.MagazineDocument) = Nothing
                    Dim documentsNewspaper As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperDocument) = Nothing
                    Dim documentsOutofHome As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeDocument) = Nothing
                    Dim documentsInternet As Generic.List(Of AdvantageFramework.Database.Entities.InternetDocument) = Nothing
                    Dim documentsRadio As Generic.List(Of AdvantageFramework.Database.Entities.RadioDocument) = Nothing
                    Dim documentsTelevision As Generic.List(Of AdvantageFramework.Database.Entities.TVDocument) = Nothing

                    Dim DtRecs As New DataTable
                    Dim zip As New Ionic.Zip.ZipFile

                    Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
                    COL_DOC_ID.DataType = GetType(Int32)

                    Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
                    COL_MIME_TYPE.DataType = GetType(String)

                    Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
                    COL_FILENAME.DataType = GetType(String)

                    Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
                    COL_REPOSITORY_FILENAME.DataType = GetType(String)

                    Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
                    COL_UPLOADED_DATE.DataType = GetType(DateTime)

                    With DtRecs.Columns

                        .Add(COL_DOC_ID)
                        .Add(COL_FILENAME)
                        .Add(COL_REPOSITORY_FILENAME)
                        .Add(COL_UPLOADED_DATE)

                    End With

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If MediaType = "M" Then
                            documentsMagazine = AdvantageFramework.Database.Procedures.MagazineDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsMagazine IsNot Nothing Then
                                Select Case documentsMagazine.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsMagazine.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsMagazine
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If
                        If MediaType = "N" Then
                            documentsNewspaper = AdvantageFramework.Database.Procedures.NewspaperDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsNewspaper IsNot Nothing Then
                                Select Case documentsNewspaper.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsNewspaper.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsNewspaper
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If
                        If MediaType = "I" Then
                            documentsInternet = AdvantageFramework.Database.Procedures.InternetDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsInternet IsNot Nothing Then
                                Select Case documentsInternet.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsInternet.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsInternet
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If
                        If MediaType = "O" Then
                            documentsOutofHome = AdvantageFramework.Database.Procedures.OutOfHomeDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsOutofHome IsNot Nothing Then
                                Select Case documentsOutofHome.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsOutofHome.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsOutofHome
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If
                        If MediaType = "R" Then
                            documentsRadio = AdvantageFramework.Database.Procedures.RadioDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsRadio IsNot Nothing Then
                                Select Case documentsRadio.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsRadio.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsRadio
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If
                        If MediaType = "T" Then
                            documentsTelevision = AdvantageFramework.Database.Procedures.TVDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                            If documentsTelevision IsNot Nothing Then
                                Select Case documentsTelevision.Count
                                    Case 0
                                        Me.ShowMessage("No file(s)")
                                    Case 1
                                        Dim DocumentId As Integer = documentsTelevision.Item(0).DocumentID
                                        Me.DeliverFile(DocumentId)
                                    Case > 1
                                        For Each magazineDoc In documentsTelevision
                                            Dim DocumentId As Integer = magazineDoc.DocumentID
                                            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                            If Document IsNot Nothing Then

                                                Dim r As DataRow

                                                r = DtRecs.NewRow()

                                                r("DocId") = Document.ID
                                                r("Filename") = Document.FileName
                                                r("RepositoryFilename") = Document.FileSystemFileName
                                                r("UploadedDate") = Document.UploadedDate

                                                DtRecs.Rows.Add(r)

                                            End If

                                        Next

                                        If Not DtRecs Is Nothing Then

                                            If DtRecs.Rows.Count > 0 Then

                                                Dim rep As New DocumentRepository(_Session.ConnectionString)
                                                rep.GetDocuments(DtRecs, zip)
                                            End If

                                        End If

                                        zip.Save(Response.OutputStream)

                                        With Response

                                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                            .ContentType = "application/zip"
                                            .End()

                                        End With

                                End Select
                            End If

                        End If

                    End Using






                Catch ex As Exception

                End Try
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_AppointmentDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerEventArgs) Handles RadSchedulerProjectMediaCalendar.AppointmentDataBound
        Try
            Dim data As System.Data.DataRowView = e.Appointment.DataItem
            e.Appointment.Subject = Me.RenderEventMC(data)

            Try

                If data.Item("LINE_CANCELLED").ToString() = "1" Then

                    e.Appointment.ForeColor = Color.Red

                End If

            Catch ex As Exception
            End Try

            Try

                If LoGlo.FormatDate(CType(data.Item("MAT_COMP"), Date).ToShortDateString()) <> LoGlo.FormatDate("1/1/1900") Then

                    e.Appointment.CssClass = "calendarPending"

                End If

            Catch ex As Exception
            End Try

            Try

                Select Case data.Item("TYPE").ToString().ToUpper()

                    Case "M"

                        'e.Appointment.CssClass = "media-magazine"

                    Case "N"

                        'e.Appointment.CssClass = "media-newspaper"

                    Case "I"

                        'e.Appointment.CssClass = "media-internet"

                    Case "O"

                        'e.Appointment.CssClass = "media-out-of-home"

                    Case "R"

                        'e.Appointment.CssClass = "media-radio"

                    Case "T"

                        'e.Appointment.CssClass = "media-tv"

                End Select

            Catch ex As Exception
            End Try

            Try

                If data.Item("DOCUMENT_COUNT") > 0 Then
                    e.Appointment.ContextMenuID = "RadSchedulerContextMenuDocuments"
                Else
                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"
                End If

                e.Appointment.Description = data.Item("DATA_KEY")
                'e.Appointment.Start = CDate(data.Item("DISPLAY_START_DATE")).ToShortDateString
                'e.Appointment.End = CDate(data.Item("DISPLAY_END_DATE")).ToShortDateString

            Catch ex As Exception
            End Try



        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_FormCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerFormCreatedEventArgs) Handles RadSchedulerProjectMediaCalendar.FormCreated
        Try
            If e.Container.Mode = SchedulerFormMode.Edit Then
                e.Container.Visible = False
                'Dim basic As Panel = CType(e.Container.FindControl("BasicControlsPanel"), Panel)
                'basic.Enabled = False
                'Dim advanced As Panel = CType(e.Container.FindControl("AdvancedControlsPanel"), Panel)
                'advanced.Enabled = False
            ElseIf e.Container.Mode = SchedulerFormMode.Insert Then
                e.Container.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_NavigationCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerNavigationCommandEventArgs) Handles RadSchedulerProjectMediaCalendar.NavigationCommand
        Try
            'Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
            'oAppVars.getAllAppVars()
            If e.Command = Telerik.Web.UI.SchedulerNavigationCommand.NavigateToNextPeriod Then
                If Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddMonths(1), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                ElseIf Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(14), Me.RadSchedulerProjectMediaCalendar.SelectedView, 1)
                ElseIf Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.WeekView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(6), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                Else
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(1), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                End If
            End If
            If e.Command = Telerik.Web.UI.SchedulerNavigationCommand.NavigateToPreviousPeriod Then
                If Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.MonthView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddMonths(-1), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                ElseIf Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(-14), Me.RadSchedulerProjectMediaCalendar.SelectedView, 1)
                ElseIf Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.WeekView Then
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(-6), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                Else
                    LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate.AddDays(-1), Me.RadSchedulerProjectMediaCalendar.SelectedView)
                End If
            End If
            If e.Command = SchedulerNavigationCommand.NavigateToSelectedDate Then
                If Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView Then
                    LoadCalendar(e.SelectedDate, Me.RadSchedulerProjectMediaCalendar.SelectedView, 1)
                Else
                    LoadCalendar(e.SelectedDate, Me.RadSchedulerProjectMediaCalendar.SelectedView)
                End If
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToTimelineView Then
                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "T", 1)
                'If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                '    Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(45)
                'Else
                '    Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(25)
                'End If
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToMonthView Then
                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "M")
                Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(35)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToWeekView Then
                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "W")
                Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(35)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToDayView Then
                LoadCalendar(Me.RadSchedulerProjectMediaCalendar.SelectedDate, "D")
                Me.RadSchedulerProjectMediaCalendar.RowHeight = Unit.Pixel(25)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToSelectedDay Then
                Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.DayView
                If Me.RadSchedulerProjectMediaCalendar.SelectedView = SchedulerViewType.TimelineView Then
                    LoadCalendar(e.SelectedDate, Me.RadSchedulerProjectMediaCalendar.SelectedView, 1)
                Else
                    LoadCalendar(e.SelectedDate, "D")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_ResourceHeaderCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.ResourceHeaderCreatedEventArgs) Handles RadSchedulerProjectMediaCalendar.ResourceHeaderCreated
        Try
            Dim labType As System.Web.UI.WebControls.Label = TryCast(e.Container.FindControl("LabelType"), Label)
            Dim panelType As Panel = TryCast(e.Container.FindControl("ResourceImageWrapperType"), Panel)
            If e.Container.Resource.Text = "N" Then
                labType.Text = "Newspaper"
            End If
            If e.Container.Resource.Text = "I" Then
                labType.Text = "Internet"
            End If
            If e.Container.Resource.Text = "M" Then
                labType.Text = "Magazine"
            End If
            If e.Container.Resource.Text = "O" Then
                labType.Text = "Outdoor"
            End If
            If e.Container.Resource.Text = "R" Then
                labType.Text = "Radio"
            End If
            If e.Container.Resource.Text = "T" Then
                labType.Text = "Television"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadSchedulerProjectMediaCalendar_AppointmentCreated(sender As Object, e As AppointmentCreatedEventArgs) Handles RadSchedulerProjectMediaCalendar.AppointmentCreated
        Try
            Dim oAppVars As cAppVars
            oAppVars = New cAppVars(cAppVars.Application.CALENDAR_MEDIA, Session("UserCode"))
            oAppVars.getAllAppVars()

            Dim str() As String = e.Appointment.Description.Split("|")

            Dim otask As cTasks = New cTasks(Session("ConnString"))

            If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") <> "" Then
                If otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Traffic" Then
                    If oAppVars.getAppVar("mtfDDocuments") = True And str(6) > 0 Then
                        e.Container.FindControl("divDocumentsMagazine").Visible = True
                    End If
                ElseIf otask.getAppVars(Session("UserCode"), "MediaFilter", "MediaCalType") = "Schedule" Then
                    If oAppVars.getAppVar("msfDDocuments") = True And str(6) > 0 Then
                        e.Container.FindControl("divDocumentsMagazine").Visible = True
                    End If
                Else
                    'default:
                    e.Container.FindControl("divDocumentsMagazine").Visible = False
                End If
            Else
                'default:
                e.Container.FindControl("divDocumentsMagazine").Visible = False
            End If


        Catch ex As Exception

        End Try
    End Sub

#End Region




End Class
