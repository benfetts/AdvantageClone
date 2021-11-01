Imports Telerik.Web.UI
Imports DayPilot.Web.Ui.Events
Imports DayPilot.Web.Ui.Events.Bubble
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Imports Webvantage.cGlobals.Globals
Imports Telerik.Web.UI.Calendar

Public Class Calendar_MonthView
    Inherits Webvantage.BaseChildPage

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

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private dtThisDate As Date
    Private JCs() As String
    Public RandomClass As New Random()
    Private calView As String = ""
    Private StartDate As DateTime
    Private EndDate As DateTime
    Private GroupBy As String = ""
    Private Duration As Integer = -1
    Private dtScheduler As DataTable
    Private Cals As Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem) = Nothing
    Private clr As System.Drawing.Color
    Private clrt As System.Drawing.ColorTranslator
    Public ShowDuration As Boolean = True
    Protected WithEvents txtAssignments As System.Web.UI.WebControls.TextBox

    Protected reporttype As Webvantage.ReportTypeUC
    Private intClient As Int32
    Private OffSet As Integer = 2
    Private intDiv As Int32
    Private Wind_wth As Int32
    Private wind_wth_str As String
    Public ib_available As Boolean = False
    Public Event ReFresh()
    Private IsExport As Boolean = False

    Private _IsJobDashboard As Boolean = False
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0

    Private Structure ExportStructure

        Public UID As String
        Public Title As String
        Public Description As String
        Public StartTime As String
        Public EndTime As String
        Public Location As String
        Public priority As String
        Public Category As String
        Public Method As String

    End Structure

    Private oAppVars As cAppVars


#End Region

#Region " Properties "

    Private Property CalendarPageView() As Integer
        Get
            If ViewState("CalendarPageView") Is Nothing Then
                ViewState("CalendarPageView") = 0
            End If
            Return CType(ViewState("CalendarPageView"), Integer)
        End Get
        Set(value As Integer)
            ViewState("CalendarPageView") = value
        End Set
    End Property
    Private Property CalendarPage() As String
        Get
            If ViewState("CalendarPage") Is Nothing Then
                ViewState("CalendarPage") = "Month"
            End If
            Return ViewState("CalendarPage")
        End Get
        Set(value As String)
            ViewState("CalendarPage") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Function BoolToYN(ByVal input As Boolean) As String
        Try
            If input = True Then
                Return "Y"
            Else
                Return "N"
            End If
        Catch ex As Exception
            Return "N"
        End Try
    End Function
    Private Function BoolToNum(ByVal input As Boolean) As Integer
        Try
            If input = True Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Shared Sub ResetSessionVariables()

        HttpContext.Current.Session("TaskCalendarSelectedDate") = Nothing

    End Sub
    Private Function IsDailyAllowed(ByVal StartDate As Date, ByVal EndDate As Date) As Boolean

        Return Not (DateDiff(DateInterval.Day, StartDate, EndDate) >= 32)

    End Function
    Private Sub EnableOrDisableAvailabilityOptions()

        Dim StartDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
        Dim EndDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

        Me.RblAvailabilitySummaryLevel.Items(0).Enabled = IsDailyAllowed(StartDate, EndDate)

    End Sub
    Private Sub EnableOrDisableAllocationOptions()

        Dim StartDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
        Dim EndDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

        Me.RadioButtonListAllocationLevel.Items(0).Enabled = IsDailyAllowed(StartDate, EndDate)

    End Sub
    Private Sub EnableOrDisableActualizationOptions()

        Dim StartDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
        Dim EndDate As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

        'Me.RblActualizationSummaryLevel.Items(0).Enabled = IsDailyAllowed(StartDate, EndDate)

    End Sub

    Private Sub SetAppVarsApplication()

        If Me.CurrentQuerystring.IsJobDashboard = True Then

            oAppVars = New cAppVars(cAppVars.Application.PMD_CALENDAR)

        Else

            oAppVars = New cAppVars(cAppVars.Application.CALENDAR)

        End If

    End Sub
    Private Sub SetSessionDefaults()

        SetAppVarsApplication()

        oAppVars.getAllAppVars()

        If oAppVars.HasAppVar("tcal_tclientcode") = False Then
            oAppVars.setAppVar("tcal_tclientcode", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_tjobnum") = False Then
            oAppVars.setAppVar("tcal_tjobnum", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_ttaskdesc") = False Then
            oAppVars.setAppVar("tcal_ttaskdesc", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_hasubject") = False Then
            oAppVars.setAppVar("tcal_hasubject", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_hatimes") = False Then
            oAppVars.setAppVar("tcal_hatimes", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_emp") = False Then
            oAppVars.setAppVar("tcal_emp", Session("EmpCode"))
        End If
        If oAppVars.HasAppVar("tcal_duration") = False Then
            Me.RadToolBarButtonDuration.Text = "Duration View"
        Else
            If BoolToNum(CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean)) = 0 Then
                RadToolBarButtonDuration.Text = "Duration View"
            Else
                RadToolBarButtonDuration.Text = "Due Date View"
            End If
        End If
        If oAppVars.HasAppVar("tcal_groupby") = False Then
            RadToolBarButtonGroupBy.Text = "Group by Job"
        Else
            If oAppVars.getAppVar("tcal_groupby") = "emp" Then
                RadToolBarButtonGroupBy.Text = "Group by Job"
            Else
                RadToolBarButtonGroupBy.Text = "Group by Employee"
            End If
        End If
        If oAppVars.HasAppVar("tcal_startdate") = False Then
            oAppVars.setAppVar("tcal_startdate", Now.AddDays(-15).ToShortDateString())
        End If
        If oAppVars.HasAppVar("tcal_enddate") = False Then
            oAppVars.setAppVar("tcal_enddate", Now.AddDays(15).ToShortDateString())
        End If
        If oAppVars.HasAppVar("tcal_office") = False Then
            oAppVars.setAppVar("tcal_office", "")
        End If
        If oAppVars.HasAppVar("tcal_client") = False Then
            oAppVars.setAppVar("tcal_client", "")
        End If
        If oAppVars.HasAppVar("tcal_div") = False Then
            oAppVars.setAppVar("tcal_div", "")
        End If
        If oAppVars.HasAppVar("tcal_prod") = False Then
            oAppVars.setAppVar("tcal_prod", "")
        End If
        If oAppVars.HasAppVar("tcal_jobno") = False Then
            oAppVars.setAppVar("tcal_jobno", "")
        End If
        If oAppVars.HasAppVar("tcal_jobcomp") = False Then
            oAppVars.setAppVar("tcal_jobcomp", "")
        End If
        If oAppVars.HasAppVar("tcal_roles") = False Then
            oAppVars.setAppVar("tcal_roles", "")
        End If
        If oAppVars.HasAppVar("tcal_roles_checked") = False Then
            oAppVars.setAppVar("tcal_roles_checked", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_taskstatus") = False Then
            oAppVars.setAppVar("tcal_taskstatus", "")
        End If
        If oAppVars.HasAppVar("tcal_excludetempcomplete") = False Then
            oAppVars.setAppVar("tcal_excludetempcomplete", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_manager") = False Then
            oAppVars.setAppVar("tcal_manager", "")
        End If

        If oAppVars.HasAppVar("tcal_showtasks") = False Then
            oAppVars.setAppVar("tcal_showtasks", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_showassignments") = False Then
            oAppVars.setAppVar("tcal_showassignments", "True", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_showholidays") = False Then
            oAppVars.setAppVar("tcal_showholidays", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_showappointments") = False Then
            oAppVars.setAppVar("tcal_showappointments", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_includeunassigned") = False Then
            oAppVars.setAppVar("tcal_includeunassigned", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_showevent") = False Then
            oAppVars.setAppVar("tcal_showevent", "False", "Boolean")
        ElseIf oAppVars.getAppVar("tcal_showevent", "Boolean") = "True" Then
            oAppVars.setAppVar("tcal_showevent", "False", "Boolean")
        End If
        If oAppVars.HasAppVar("tcal_showeventtasks") = False Then
            oAppVars.setAppVar("tcal_showeventtasks", "False", "Boolean")
        ElseIf oAppVars.getAppVar("tcal_showeventtasks", "Boolean") = "True" Then
            oAppVars.setAppVar("tcal_showeventtasks", "False", "Boolean")
        End If

        oAppVars.SaveAllAppVars()

    End Sub
    Private Sub LoadScheduler(ByVal DateSelected As DateTime, ByVal view As String, Optional ByVal timeline As Integer = 0, Optional ByVal resource As Integer = 0)
        Try
            'objects
            Dim JobsList As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
            Dim CalendarItems As Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem) = Nothing
            Dim CalendarItemsJC As Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem) = Nothing
            Dim StartOfSelectedMonth As DateTime
            Dim EndOfSelectedMonth As DateTime
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim count As Integer = 0
            Dim same As Boolean = False
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            Dim strtest As String = Me.RadSchedulerProjectSchedule.TimelineView.StartTime.ToString()
            Dim strtest2 As String = Me.RadSchedulerProjectSchedule.WeekView.DayStartTime.ToString()
            If view = "M" Or view = "2" Then
                StartOfSelectedMonth = New DateTime(DateSelected.Year, DateSelected.Month, 1)
                EndOfSelectedMonth = New DateTime(DateSelected.Year, DateSelected.Month, Date.DaysInMonth(DateSelected.Year, DateSelected.Month))
                Me.CalendarPage = "Month"
                Me.RadToolBarButtonGroupBy.Visible = False
                Me.RadToolbarCalendar.Items(5).Visible = True
                Me.RadToolbarCalendar.Items(7).Visible = True
                Me.RadToolbarCalendar.Items(8).Visible = True
                Me.RadToolbarCalendar.Items(9).Visible = True
            ElseIf view = "D" Or view = "0" Then
                StartOfSelectedMonth = DateSelected
                EndOfSelectedMonth = DateSelected
                Me.CalendarPage = "Day"
                Me.RadToolBarButtonGroupBy.Visible = False
                Me.RadToolbarCalendar.Items(5).Visible = True
                Me.RadToolbarCalendar.Items(7).Visible = False
                Me.RadToolbarCalendar.Items(8).Visible = False
                Me.RadToolbarCalendar.Items(9).Visible = True
            ElseIf view = "W" Or view = "1" Then
                StartOfSelectedMonth = DayPilot.Utils.Week.FirstDayOfWeek(DateSelected)
                EndOfSelectedMonth = StartOfSelectedMonth.AddDays(6)
                Me.CalendarPage = "Week"
                Me.RadToolBarButtonGroupBy.Visible = False
                Me.RadToolbarCalendar.Items(5).Visible = True
                Me.RadToolbarCalendar.Items(7).Visible = False
                Me.RadToolbarCalendar.Items(8).Visible = False
                Me.RadToolbarCalendar.Items(9).Visible = True
            ElseIf view = "T" Or view = "4" Then
                StartOfSelectedMonth = DateSelected
                EndOfSelectedMonth = DateSelected.AddDays(13)
                Me.CalendarPage = "Timeline"
                Me.RadToolBarButtonGroupBy.Visible = True
                Me.RadToolbarCalendar.Items(5).Visible = False
                Me.RadToolbarCalendar.Items(7).Visible = False
                Me.RadToolbarCalendar.Items(8).Visible = False
                Me.RadToolbarCalendar.Items(9).Visible = False
            End If
            calView = view
            StartDate = StartOfSelectedMonth
            EndDate = EndOfSelectedMonth
            ViewState("ThisDate") = DateSelected

            Try
                If oAppVars.getAppVar("tcal_showtasks") <> "" Then
                    Me.CheckBoxIncludeTasks.Checked = oAppVars.getAppVar("tcal_showtasks", "Boolean")
                End If
            Catch ex As Exception
            End Try
            Try
                If oAppVars.getAppVar("tcal_showassignments") <> "" Then
                    Me.CheckBoxIncludeAssignments.Checked = oAppVars.getAppVar("tcal_showassignments", "Boolean")
                End If
            Catch ex As Exception
            End Try
            Try
                If oAppVars.getAppVar("tcal_showholidays") <> "" Then
                    Me.CheckBoxIncludeHolidays.Checked = oAppVars.getAppVar("tcal_showholidays", "Boolean")
                End If
            Catch ex As Exception
            End Try
            Try
                If oAppVars.getAppVar("tcal_showappointments") <> "" Then
                    Me.CheckBoxIncludeAppointments.Checked = oAppVars.getAppVar("tcal_showappointments", "Boolean")
                End If
            Catch ex As Exception
            End Try
            Try
                If oAppVars.getAppVar("tcal_showevent") <> "" Then
                    Me.CheckBoxIncludeEvents.Checked = oAppVars.getAppVar("tcal_showevent", "Boolean")
                End If
            Catch ex As Exception
            End Try
            Try
                If oAppVars.getAppVar("tcal_showeventtasks") <> "" Then
                    Me.CheckBoxIncludeEventTasks.Checked = oAppVars.getAppVar("tcal_showeventtasks", "Boolean")
                End If
            Catch ex As Exception
            End Try

            Dim NonTaskType As String = ""
            If Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = True Then
                NonTaskType = ""
            ElseIf Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = False Then
                NonTaskType = "H"
            ElseIf Me.CheckBoxIncludeHolidays.Checked = False And Me.CheckBoxIncludeAppointments.Checked = True Then
                NonTaskType = "A"
            Else
                NonTaskType = "N"
            End If

            If Request.QueryString("FromApp") = "PS" Then
                '' Being set in QS class in page init
                If Me._JobNumber = 0 Then
                    Me._JobNumber = oAppVars.getAppVar("tcal_jobno")
                End If
                If Me._JobComponentNumber = 0 Then
                    _JobComponentNumber = oAppVars.getAppVar("tcal_jobcomp")
                End If

                oAppVars.setAppVar("FromApp", "PS")
                oAppVars.SaveAllAppVars()

            ElseIf Request.QueryString("FromApp") = "PSMV" Then

                oAppVars.setAppVar("tcal_jobno", "")
                oAppVars.setAppVar("tcal_jobcomp", "")
                oAppVars.setAppVar("FromApp", "PSMV")
                oAppVars.SaveAllAppVars()

            Else

                oAppVars.setAppVar("FromApp", "")
                oAppVars.SaveAllAppVars()

            End If
            GroupBy = oAppVars.getAppVar("tcal_groupby")
            If GroupBy = "" Then
                GroupBy = "emp"
            End If
            Duration = BoolToNum(CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean))
            If Duration = -1 Then
                Duration = 0
            End If
            Dim nt As Integer = 0
            If oAppVars.getAppVar("tcal_appts") <> "" Then
                Me.RadSchedulerProjectSchedule.MonthView.VisibleAppointmentsPerDay = oAppVars.getAppVar("tcal_appts")
                Me.txtAssignments.Text = oAppVars.getAppVar("tcal_appts")
            Else
                Me.RadSchedulerProjectSchedule.MonthView.VisibleAppointmentsPerDay = 5
                Me.txtAssignments.Text = 5
            End If
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                CalendarItemsJC = New Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem)
                'From Project Schedule with one Job to display.
                If Request.QueryString("FromApp") = "PS" Then
                    If timeline = 1 Then
                        CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"), oAppVars.getAppVar("tcal_div"), oAppVars.getAppVar("tcal_prod"), Me._JobNumber, _JobComponentNumber,
                                         oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                         BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), "T", NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                         1, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean)).ToList
                    Else
                        CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"), oAppVars.getAppVar("tcal_div"), oAppVars.getAppVar("tcal_prod"), Me._JobNumber, _JobComponentNumber,
                                         oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                         BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), view, NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                         Duration, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean)).ToList
                    End If
                    If CalendarItems.Count > 0 Then
                        'For j As Integer = 0 To CalendarItems.Count - 1
                        '    If CalendarItems(j).IS_NON_TASK = 0 Then
                        '        CalendarItemsJC.Add(CalendarItems(j))
                        '    End If
                        'Next
                        If CalendarItems.Count > 0 Then
                            For j As Integer = 0 To CalendarItems.Count - 1
                                If nt > 0 Then
                                    If CalendarItems(j).IS_NON_TASK = 0 Then
                                        CalendarItemsJC.Add(CalendarItems(j))
                                    End If
                                Else
                                    CalendarItemsJC.Add(CalendarItems(j))
                                End If
                            Next
                            nt = 1
                        End If
                    End If
                    'From Project Schedule - Multiview with a list of Jobs to display.
                ElseIf Request.QueryString("FromApp") = "PSMV" Then

                    If Request.QueryString("jcs") <> "" Then
                        JCs = Request.QueryString("jcs").ToString.Split("|")
                    End If

                    If Not Session("TrafficScheduleMVJobs") Is Nothing Then
                        If Session("TrafficScheduleMVJobs") <> "" Then
                            JCs = Session("TrafficScheduleMVJobs").ToString.Split("|")
                        End If
                    End If
                    If JCs.Length > 0 Then
                        For i As Integer = 0 To JCs.Length - 1
                            Dim strJC() As String = JCs(i).Split(",")
                            If strJC(0) <> "" Then
                                If timeline = 1 Then
                                    CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                                 strJC(2), strJC(3), strJC(4), strJC(0), strJC(1),
                                                 oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                                 BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), "T", NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                                 1, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean)).ToList
                                Else
                                    CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                                     strJC(2), strJC(3), strJC(4), strJC(0), strJC(1),
                                                     oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                                     BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), view, NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                                     Duration, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean)).ToList
                                End If
                                If CalendarItems.Count > 0 Then
                                    For j As Integer = 0 To CalendarItems.Count - 1
                                        If nt > 0 Then
                                            If CalendarItems(j).IS_NON_TASK = 1 Then
                                                For x As Integer = 0 To CalendarItemsJC.Count - 1
                                                    If CalendarItemsJC(x).NON_TASK_ID = CalendarItems(j).NON_TASK_ID Then
                                                        same = True
                                                        Exit For
                                                    End If
                                                Next
                                                If same = False Then
                                                    CalendarItemsJC.Add(CalendarItems(j))
                                                End If
                                                same = False
                                            Else
                                                CalendarItemsJC.Add(CalendarItems(j))
                                            End If
                                        Else
                                            CalendarItemsJC.Add(CalendarItems(j))
                                        End If
                                    Next
                                    nt = 1
                                End If
                            End If
                        Next
                    End If
                Else
                    If timeline = 1 Then
                        CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                                                     oAppVars.getAppVar("tcal_client"), oAppVars.getAppVar("tcal_div"), oAppVars.getAppVar("tcal_prod"), oAppVars.getAppVar("tcal_jobno"), oAppVars.getAppVar("tcal_jobcomp"),
                                                                     oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                                                     BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), "T", NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                                                     1, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), oAppVars.getAppVar("tcal_includeunassigned")).OrderBy(Function(CalendarItem) CalendarItem.JOB_NUMBER).ToList

                    Else
                        CalendarItems = AdvantageFramework.Database.Procedures.CalendarItemComplexType.Load(DbContext, Session("UserCode"), If(Request.QueryString("from") = "dash", Session("EmpCode"), oAppVars.getAppVar("tcal_emp")), oAppVars.getAppVar("tcal_office"),
                                                     oAppVars.getAppVar("tcal_client"), oAppVars.getAppVar("tcal_div"), oAppVars.getAppVar("tcal_prod"), oAppVars.getAppVar("tcal_jobno"), oAppVars.getAppVar("tcal_jobcomp"),
                                                     oAppVars.getAppVar("tcal_roles"), StartOfSelectedMonth, EndOfSelectedMonth, oAppVars.getAppVar("tcal_taskstatus"), BoolToYN(CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)).Trim,
                                                     BoolToYN(CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)).Trim, oAppVars.getAppVar("tcal_manager"), view, NonTaskType, BoolToNum(Me.CheckBoxIncludeTasks.Checked),
                                                     Duration, BoolToNum(Me.CheckBoxIncludeEvents.Checked), BoolToNum(Me.CheckBoxIncludeEventTasks.Checked), oAppVars.getAppVar("tcal_departs"), oAppVars.getAppVar("tcal_trafficstatuscode"), BoolToNum(Me.CheckBoxIncludeAssignments.Checked), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), CType(oAppVars.getAppVar("tcal_includeunassigned"), Boolean)).ToList
                    End If
                End If

                If Request.QueryString("FromApp") = "PS" Or Request.QueryString("FromApp") = "PSMV" Then
                    If timeline = 1 Then
                        Dim row As DataRow
                        Dim row2 As DataRow
                        Dim c As String = ""
                        dt = New DataTable("calItems")
                        dt2 = New DataTable("calItems2")
                        Dim jobn As DataColumn = New DataColumn("JOB_NUMBER")
                        Dim comp As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                        Dim sdate As DataColumn = New DataColumn("START_DATE")
                        Dim edate As DataColumn = New DataColumn("END_DATE")
                        Dim dk As DataColumn = New DataColumn("DATA_KEY")
                        Dim empcol As DataColumn = New DataColumn("EMPLOYEE")
                        Dim remind As DataColumn = New DataColumn("REMINDER")
                        Dim tasktype As DataColumn = New DataColumn("RESOURCE_TYPE")
                        Dim allday As DataColumn = New DataColumn("ALL_DAY")
                        Dim stime As DataColumn = New DataColumn("START_TIME")
                        Dim etime As DataColumn = New DataColumn("END_TIME")
                        Dim isnontask As DataColumn = New DataColumn("IS_NON_TASK")
                        Dim ntasktype As DataColumn = New DataColumn("NON_TASK_TYPE")
                        Dim icalid As DataColumn = New DataColumn("ICAL_ID")
                        Dim nontaskid As DataColumn = New DataColumn("NON_TASK_ID")
                        Dim adnbrcolor As DataColumn = New DataColumn("AD_NBR_COLOR")
                        Dim recurrence As DataColumn = New DataColumn("RECURRENCE")
                        Dim jnum As DataColumn = New DataColumn("JOB_NUMBER")
                        Dim jnum2 As DataColumn = New DataColumn("JOB_NBR")
                        Dim jdesc As DataColumn = New DataColumn("JOB_DESC")
                        Dim jcnum As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                        Dim jcdesc As DataColumn = New DataColumn("JOB_COMP_DESC")
                        Dim taskseqnbr As DataColumn = New DataColumn("TASK_SEQ_NBR")
                        Dim clcode As DataColumn = New DataColumn("CL_CODE")
                        Dim divcode As DataColumn = New DataColumn("DIV_CODE")
                        Dim prdcode As DataColumn = New DataColumn("PRD_CODE")
                        Dim clname As DataColumn = New DataColumn("CL_NAME")
                        Dim divname As DataColumn = New DataColumn("DIV_NAME")
                        Dim prdname As DataColumn = New DataColumn("PRD_DESCRIPTION")
                        Dim taskstatus As DataColumn = New DataColumn("TASK_STATUS")
                        Dim empcode As DataColumn = New DataColumn("EMP_CODE")
                        Dim numdays As DataColumn = New DataColumn("NUM_DAYS")
                        Dim priority As DataColumn = New DataColumn("PRIORITY")
                        Dim resourcecode As DataColumn = New DataColumn("RESOURCE_CODE")
                        Dim adnbr As DataColumn = New DataColumn("AD_NBR")
                        Dim recurrenceparent As DataColumn = New DataColumn("RECURRENCE_PARENT")
                        Dim tasknontaskdisplay As DataColumn = New DataColumn("TASK_NON_TASK_DISPLAY")
                        Dim nontaskcategory As DataColumn = New DataColumn("NON_TASK_CATEGORY")
                        Dim nontaskhours As DataColumn = New DataColumn("NON_TASK_HOURS")
                        Dim trfcode As DataColumn = New DataColumn("TRF_CODE")
                        Dim taskdescription As DataColumn = New DataColumn("TASK_DESCRIPTION")
                        Dim hoursallowed As DataColumn = New DataColumn("HoursAllowed")
                        Dim empdeschrs As DataColumn = New DataColumn("EMP_DESC_HRS")
                        Dim duetime As DataColumn = New DataColumn("DUE_TIME")
                        Dim taskHoursAllowed As DataColumn = New DataColumn("TASK_HOURS_ALLOWED")
                        Dim empNameHours As DataColumn = New DataColumn("EMP_NAME_HOURS")
                        Dim alertid As DataColumn = New DataColumn("ALERT_ID")
                        Dim sprintid As DataColumn = New DataColumn("SPRINT_ID")
                        If GroupBy = "job" Then
                            dt.Columns.Add(jobn)
                            dt.Columns.Add(comp)
                            dt.Columns.Add(sdate)
                            dt.Columns.Add(edate)
                            dt.Columns.Add(dk)
                            dt.Columns.Add(remind)
                            dt.Columns.Add(tasktype)
                            dt.Columns.Add(allday)
                            dt.Columns.Add(stime)
                            dt.Columns.Add(etime)
                            dt.Columns.Add(isnontask)
                            dt.Columns.Add(ntasktype)
                            dt.Columns.Add(icalid)
                            dt.Columns.Add(nontaskid)
                            dt.Columns.Add(adnbrcolor)
                            dt.Columns.Add(recurrence)
                            dt.Columns.Add(jnum2)
                            dt.Columns.Add(jdesc)
                            dt.Columns.Add(jcdesc)
                            dt.Columns.Add(taskseqnbr)
                            dt.Columns.Add(clcode)
                            dt.Columns.Add(divcode)
                            dt.Columns.Add(prdcode)
                            dt.Columns.Add(clname)
                            dt.Columns.Add(divname)
                            dt.Columns.Add(prdname)
                            dt.Columns.Add(taskstatus)
                            dt.Columns.Add(empcode)
                            dt.Columns.Add(numdays)
                            dt.Columns.Add(priority)
                            dt.Columns.Add(resourcecode)
                            dt.Columns.Add(adnbr)
                            dt.Columns.Add(recurrenceparent)
                            dt.Columns.Add(tasknontaskdisplay)
                            dt.Columns.Add(nontaskcategory)
                            dt.Columns.Add(nontaskhours)
                            dt.Columns.Add(trfcode)
                            dt.Columns.Add(taskdescription)
                            dt.Columns.Add(hoursallowed)
                            dt.Columns.Add(empdeschrs)
                            dt.Columns.Add(duetime)
                            dt.Columns.Add(taskHoursAllowed)
                            dt.Columns.Add(empNameHours)
                            dt.Columns.Add(alertid)
                            dt.Columns.Add(sprintid)
                            For Each CalendarItem In CalendarItemsJC
                                row = dt.NewRow
                                row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                row.Item("START_DATE") = CalendarItem.START_DATE
                                row.Item("END_DATE") = CalendarItem.END_DATE
                                row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID
                                row.Item("REMINDER") = CalendarItem.REMINDER
                                row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                row.Item("START_TIME") = CalendarItem.START_TIME
                                row.Item("END_TIME") = CalendarItem.END_TIME
                                row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                row.Item("JOB_NBR") = CalendarItem.JOB_NUMBER
                                row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                row.Item("CL_CODE") = CalendarItem.CL_CODE
                                row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                row.Item("CL_NAME") = CalendarItem.CL_NAME
                                row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                row.Item("PRIORITY") = CalendarItem.PRIORITY
                                row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                row.Item("AD_NBR") = CalendarItem.AD_NBR
                                row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                dt.Rows.Add(row)
                            Next
                            Dim jobn2 As DataColumn = New DataColumn("JOB_NUMBER")
                            Dim comp2 As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                            Dim desc As DataColumn = New DataColumn("JOB_DESC")
                            dt2.Columns.Add(jobn2)
                            dt2.Columns.Add(comp2)
                            dt2.Columns.Add(desc)
                            For Each CalendarItem In CalendarItemsJC.OrderBy(Function(MyData) MyData.JOB_NUMBER).ThenBy(Function(MyData) MyData.JOB_COMPONENT_NBR)
                                row2 = dt2.NewRow
                                If c <> CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR Then
                                    row2.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                    row2.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                    row2.Item("JOB_DESC") = CalendarItem.JOB_NUMBER & " - " & CalendarItem.JOB_DESC
                                    c = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                    dt2.Rows.Add(row2)
                                End If
                            Next
                            Dim rstype As New ResourceType
                            rstype.DataSource = dt2
                            rstype.Name = "JobNum"
                            rstype.KeyField = "JOB_NUMBER"
                            rstype.TextField = "JOB_NUMBER"
                            rstype.ForeignKeyField = "JOB_NUMBER"
                            Dim rstype2 As New ResourceType
                            rstype2.DataSource = CalendarItems
                            rstype2.Name = "Type"
                            rstype2.KeyField = "RESOURCE_TYPE"
                            rstype2.TextField = "RESOURCE_TYPE"
                            rstype2.ForeignKeyField = "RESOURCE_TYPE"
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype2)
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupBy = "JobNum"
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupingDirection = GroupingDirection.Vertical
                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "MM/dd"
                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd/MM"
                            Else
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd.MM"
                            End If
                            Me.RadSchedulerProjectSchedule.DataKeyField = "DATA_KEY"
                            Me.RadSchedulerProjectSchedule.DataSubjectField = "JOB_NUMBER"
                        ElseIf GroupBy = "emp" Then
                            dt.Columns.Add(empcol)
                            dt.Columns.Add(sdate)
                            dt.Columns.Add(edate)
                            dt.Columns.Add(dk)
                            dt.Columns.Add(remind)
                            dt.Columns.Add(tasktype)
                            dt.Columns.Add(allday)
                            dt.Columns.Add(stime)
                            dt.Columns.Add(etime)
                            dt.Columns.Add(isnontask)
                            dt.Columns.Add(ntasktype)
                            dt.Columns.Add(icalid)
                            dt.Columns.Add(nontaskid)
                            dt.Columns.Add(adnbrcolor)
                            dt.Columns.Add(recurrence)
                            dt.Columns.Add(jnum)
                            dt.Columns.Add(jdesc)
                            dt.Columns.Add(jcnum)
                            dt.Columns.Add(jcdesc)
                            dt.Columns.Add(taskseqnbr)
                            dt.Columns.Add(clcode)
                            dt.Columns.Add(divcode)
                            dt.Columns.Add(prdcode)
                            dt.Columns.Add(clname)
                            dt.Columns.Add(divname)
                            dt.Columns.Add(prdname)
                            dt.Columns.Add(taskstatus)
                            dt.Columns.Add(empcode)
                            dt.Columns.Add(numdays)
                            dt.Columns.Add(priority)
                            dt.Columns.Add(resourcecode)
                            dt.Columns.Add(adnbr)
                            dt.Columns.Add(recurrenceparent)
                            dt.Columns.Add(tasknontaskdisplay)
                            dt.Columns.Add(nontaskcategory)
                            dt.Columns.Add(nontaskhours)
                            dt.Columns.Add(trfcode)
                            dt.Columns.Add(taskdescription)
                            dt.Columns.Add(hoursallowed)
                            dt.Columns.Add(empdeschrs)
                            dt.Columns.Add(duetime)
                            dt.Columns.Add(taskHoursAllowed)
                            dt.Columns.Add(empNameHours)
                            dt.Columns.Add(alertid)
                            dt.Columns.Add(sprintid)
                            For Each CalendarItem In CalendarItemsJC
                                If CalendarItem.EMP_CODE Is Nothing Then
                                    row = dt.NewRow
                                    row.Item("EMPLOYEE") = "N/A"
                                    row.Item("START_DATE") = CalendarItem.START_DATE
                                    row.Item("END_DATE") = CalendarItem.END_DATE
                                    row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID & "|" & count
                                    row.Item("REMINDER") = CalendarItem.REMINDER
                                    row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                    row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                    row.Item("START_TIME") = CalendarItem.START_TIME
                                    row.Item("END_TIME") = CalendarItem.END_TIME
                                    row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                    row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                    row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                    row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                    row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                    row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                    row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER
                                    row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                    row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                    row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                    row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                    row.Item("CL_CODE") = CalendarItem.CL_CODE
                                    row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                    row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                    row.Item("CL_NAME") = CalendarItem.CL_NAME
                                    row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                    row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                    row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                    row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                    row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                    row.Item("PRIORITY") = CalendarItem.PRIORITY
                                    row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                    row.Item("AD_NBR") = CalendarItem.AD_NBR
                                    row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                    row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                    row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                    row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                    row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                    row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                    row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                    row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                    row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                    row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                    row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                    row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                    row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                    dt.Rows.Add(row)
                                    count += 1
                                Else
                                    Dim empstr() As String = CalendarItem.EMP_FML_NAME_GROUP.Split(",")
                                    For i As Integer = 0 To empstr.Length - 1
                                        row = dt.NewRow
                                        If CalendarItem.IS_NON_TASK = 0 Then
                                            row.Item("EMPLOYEE") = empstr(i).Trim 'empfml(1).Trim
                                        Else
                                            row.Item("EMPLOYEE") = CalendarItem.EMP_CODE & " - " & empstr(i).Trim
                                        End If
                                        row.Item("START_DATE") = CalendarItem.START_DATE
                                        row.Item("END_DATE") = CalendarItem.END_DATE
                                        row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID & "|" & i
                                        row.Item("REMINDER") = CalendarItem.REMINDER
                                        row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                        row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                        row.Item("START_TIME") = CalendarItem.START_TIME
                                        row.Item("END_TIME") = CalendarItem.END_TIME
                                        row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                        row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                        row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                        row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                        row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                        row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                        row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER
                                        row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                        row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                        row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                        row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                        row.Item("CL_CODE") = CalendarItem.CL_CODE
                                        row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                        row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                        row.Item("CL_NAME") = CalendarItem.CL_NAME
                                        row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                        row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                        row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                        row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                        row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                        row.Item("PRIORITY") = CalendarItem.PRIORITY
                                        row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                        row.Item("AD_NBR") = CalendarItem.AD_NBR
                                        row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                        row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                        row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                        row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                        row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                        row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                        row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                        row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                        row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                        row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                        row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                        row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                        row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                        dt.Rows.Add(row)
                                    Next
                                End If
                            Next
                            Dim emplstr As String = ""
                            Dim dv As DataView = dt.DefaultView
                            dv.Sort = "EMPLOYEE"
                            dt = dv.ToTable
                            dt2 = New DataTable("calItems2")
                            Dim empcol2 As DataColumn = New DataColumn("EMPLOYEE")
                            dt2.Columns.Add(empcol2)
                            For Each CalendarItem In CalendarItemsJC
                                If Not CalendarItem.EMP_CODE Is Nothing And CalendarItem.EMP_CODE <> "" Then
                                    If Not CalendarItem.EMP_CODE Is Nothing Then
                                        Dim empstr2() As String = CalendarItem.EMP_FML_NAME_GROUP.Split(",")
                                        For i As Integer = 0 To empstr2.Length - 1
                                            row2 = dt2.NewRow
                                            Dim empfml2() As String = empstr2(i).Trim.Split("-")
                                            If CalendarItem.IS_NON_TASK = 0 Then
                                                If emplstr.Contains(empfml2(1).Trim) = False Then
                                                    row2.Item("EMPLOYEE") = empstr2(i).Trim 'empfml2(1).Trim
                                                    emplstr &= empstr2(i).Trim & ","
                                                    dt2.Rows.Add(row2)
                                                End If
                                            Else
                                                If emplstr.Contains(empfml2(0).Trim) = False Then
                                                    row2.Item("EMPLOYEE") = CalendarItem.EMP_CODE & " - " & empstr2(i).Trim 'empfml2(0).Trim
                                                    emplstr &= empstr2(i).Trim & ","
                                                    dt2.Rows.Add(row2)
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                            Dim dv2 As DataView = dt2.DefaultView
                            dv2.Sort = "EMPLOYEE"
                            dt2 = dv2.ToTable
                            If count > 0 Then
                                row2 = dt2.NewRow
                                row2.Item("EMPLOYEE") = "N/A"
                                dt2.Rows.Add(row2)
                            End If
                            Dim rstype As New ResourceType
                            rstype.DataSource = dt2
                            rstype.Name = "Employee"
                            rstype.KeyField = "EMPLOYEE"
                            rstype.TextField = "EMPLOYEE"
                            rstype.ForeignKeyField = "EMPLOYEE"
                            Dim rstype2 As New ResourceType
                            rstype2.DataSource = CalendarItems
                            rstype2.Name = "Type"
                            rstype2.KeyField = "RESOURCE_TYPE"
                            rstype2.TextField = "RESOURCE_TYPE"
                            rstype2.ForeignKeyField = "RESOURCE_TYPE"
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype2)
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupBy = "Employee"
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupingDirection = GroupingDirection.Vertical
                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "MM/dd"
                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd/MM"
                            Else
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd.MM"
                            End If
                            Me.RadSchedulerProjectSchedule.DataKeyField = "DATA_KEY"
                            Me.RadSchedulerProjectSchedule.DataSubjectField = "EMPLOYEE"
                        End If

                        Me.dtScheduler = dt
                        RadSchedulerProjectSchedule.DataSource = dt
                        RadSchedulerProjectSchedule.DataBind()
                    Else
                        Me.RadSchedulerProjectSchedule.DataKeyField = "ID"
                        Me.RadSchedulerProjectSchedule.DataSubjectField = "JOB_NUMBER"
                        Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                        If CalendarItemsJC IsNot Nothing Then
                            Me.Cals = CalendarItemsJC
                            Dim rstype As New ResourceType
                            rstype.DataSource = CalendarItems
                            rstype.Name = "Type"
                            rstype.KeyField = "RESOURCE_TYPE"
                            rstype.TextField = "RESOURCE_TYPE"
                            rstype.ForeignKeyField = "RESOURCE_TYPE"
                            RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            RadSchedulerProjectSchedule.DataSource = CalendarItemsJC
                            RadSchedulerProjectSchedule.DataBind()
                        End If
                    End If
                Else
                    If timeline = 1 Then
                        Dim row As DataRow
                        Dim row2 As DataRow
                        dt = New DataTable("calItems")
                        dt2 = New DataTable("calItems2")
                        Dim c As String = ""
                        Dim ep As String = ""
                        Dim jobn As DataColumn = New DataColumn("JOB_NUMBER")
                        Dim comp As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                        Dim sdate As DataColumn = New DataColumn("START_DATE")
                        Dim edate As DataColumn = New DataColumn("END_DATE")
                        Dim dk As DataColumn = New DataColumn("DATA_KEY")
                        Dim empcol As DataColumn = New DataColumn("EMPLOYEE")
                        Dim remind As DataColumn = New DataColumn("REMINDER")
                        Dim tasktype As DataColumn = New DataColumn("RESOURCE_TYPE")
                        Dim allday As DataColumn = New DataColumn("ALL_DAY")
                        Dim stime As DataColumn = New DataColumn("START_TIME")
                        Dim etime As DataColumn = New DataColumn("END_TIME")
                        Dim isnontask As DataColumn = New DataColumn("IS_NON_TASK")
                        Dim ntasktype As DataColumn = New DataColumn("NON_TASK_TYPE")
                        Dim icalid As DataColumn = New DataColumn("ICAL_ID")
                        Dim nontaskid As DataColumn = New DataColumn("NON_TASK_ID")
                        Dim adnbrcolor As DataColumn = New DataColumn("AD_NBR_COLOR")
                        Dim recurrence As DataColumn = New DataColumn("RECURRENCE")
                        Dim jnum As DataColumn = New DataColumn("JOB_NUMBER")
                        Dim jnum2 As DataColumn = New DataColumn("JOB_NBR")
                        Dim jdesc As DataColumn = New DataColumn("JOB_DESC")
                        Dim jcnum As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                        Dim jcdesc As DataColumn = New DataColumn("JOB_COMP_DESC")
                        Dim taskseqnbr As DataColumn = New DataColumn("TASK_SEQ_NBR")
                        Dim clcode As DataColumn = New DataColumn("CL_CODE")
                        Dim divcode As DataColumn = New DataColumn("DIV_CODE")
                        Dim prdcode As DataColumn = New DataColumn("PRD_CODE")
                        Dim clname As DataColumn = New DataColumn("CL_NAME")
                        Dim divname As DataColumn = New DataColumn("DIV_NAME")
                        Dim prdname As DataColumn = New DataColumn("PRD_DESCRIPTION")
                        Dim taskstatus As DataColumn = New DataColumn("TASK_STATUS")
                        Dim empcode As DataColumn = New DataColumn("EMP_CODE")
                        Dim numdays As DataColumn = New DataColumn("NUM_DAYS")
                        Dim priority As DataColumn = New DataColumn("PRIORITY")
                        Dim resourcecode As DataColumn = New DataColumn("RESOURCE_CODE")
                        Dim adnbr As DataColumn = New DataColumn("AD_NBR")
                        Dim recurrenceparent As DataColumn = New DataColumn("RECURRENCE_PARENT")
                        Dim tasknontaskdisplay As DataColumn = New DataColumn("TASK_NON_TASK_DISPLAY")
                        Dim nontaskcategory As DataColumn = New DataColumn("NON_TASK_CATEGORY")
                        Dim nontaskhours As DataColumn = New DataColumn("NON_TASK_HOURS")
                        Dim trfcode As DataColumn = New DataColumn("TRF_CODE")
                        Dim taskdescription As DataColumn = New DataColumn("TASK_DESCRIPTION")
                        Dim hoursallowed As DataColumn = New DataColumn("HoursAllowed")
                        Dim empdeschrs As DataColumn = New DataColumn("EMP_DESC_HRS")
                        Dim duetime As DataColumn = New DataColumn("DUE_TIME")
                        Dim taskHoursAllowed As DataColumn = New DataColumn("TASK_HOURS_ALLOWED")
                        Dim empNameHours As DataColumn = New DataColumn("EMP_NAME_HOURS")
                        Dim alertid As DataColumn = New DataColumn("ALERT_ID")
                        Dim sprintid As DataColumn = New DataColumn("SPRINT_ID")
                        If GroupBy = "job" Then
                            dt.Columns.Add(jobn)
                            dt.Columns.Add(comp)
                            dt.Columns.Add(sdate)
                            dt.Columns.Add(edate)
                            dt.Columns.Add(dk)
                            dt.Columns.Add(remind)
                            dt.Columns.Add(tasktype)
                            dt.Columns.Add(allday)
                            dt.Columns.Add(stime)
                            dt.Columns.Add(etime)
                            dt.Columns.Add(isnontask)
                            dt.Columns.Add(ntasktype)
                            dt.Columns.Add(icalid)
                            dt.Columns.Add(nontaskid)
                            dt.Columns.Add(adnbrcolor)
                            dt.Columns.Add(recurrence)
                            dt.Columns.Add(jnum2)
                            dt.Columns.Add(jdesc)
                            dt.Columns.Add(jcdesc)
                            dt.Columns.Add(taskseqnbr)
                            dt.Columns.Add(clcode)
                            dt.Columns.Add(divcode)
                            dt.Columns.Add(prdcode)
                            dt.Columns.Add(clname)
                            dt.Columns.Add(divname)
                            dt.Columns.Add(prdname)
                            dt.Columns.Add(taskstatus)
                            dt.Columns.Add(empcode)
                            dt.Columns.Add(numdays)
                            dt.Columns.Add(priority)
                            dt.Columns.Add(resourcecode)
                            dt.Columns.Add(adnbr)
                            dt.Columns.Add(recurrenceparent)
                            dt.Columns.Add(tasknontaskdisplay)
                            dt.Columns.Add(nontaskcategory)
                            dt.Columns.Add(nontaskhours)
                            dt.Columns.Add(trfcode)
                            dt.Columns.Add(taskdescription)
                            dt.Columns.Add(hoursallowed)
                            dt.Columns.Add(empdeschrs)
                            dt.Columns.Add(duetime)
                            dt.Columns.Add(taskHoursAllowed)
                            dt.Columns.Add(empNameHours)
                            dt.Columns.Add(alertid)
                            dt.Columns.Add(sprintid)
                            For Each CalendarItem In CalendarItems
                                row = dt.NewRow
                                row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                row.Item("START_DATE") = CalendarItem.START_DATE
                                row.Item("END_DATE") = CalendarItem.END_DATE
                                row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID
                                row.Item("REMINDER") = CalendarItem.REMINDER
                                row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                row.Item("START_TIME") = CalendarItem.START_TIME
                                row.Item("END_TIME") = CalendarItem.END_TIME
                                row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                row.Item("JOB_NBR") = CalendarItem.JOB_NUMBER
                                row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                row.Item("CL_CODE") = CalendarItem.CL_CODE
                                row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                row.Item("CL_NAME") = CalendarItem.CL_NAME
                                row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                row.Item("PRIORITY") = CalendarItem.PRIORITY
                                row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                row.Item("AD_NBR") = CalendarItem.AD_NBR
                                row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                dt.Rows.Add(row)
                            Next
                            dt2 = New DataTable("calItems2")
                            Dim jobn2 As DataColumn = New DataColumn("JOB_NUMBER")
                            Dim comp2 As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                            Dim desc As DataColumn = New DataColumn("JOB_DESC")
                            dt2.Columns.Add(jobn2)
                            dt2.Columns.Add(comp2)
                            dt2.Columns.Add(desc)
                            For Each CalendarItem In CalendarItems.OrderBy(Function(MyData) MyData.JOB_NUMBER).ThenBy(Function(MyData) MyData.JOB_COMPONENT_NBR)
                                row2 = dt2.NewRow
                                If c <> CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR Then
                                    row2.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                    row2.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                    row2.Item("JOB_DESC") = CalendarItem.JOB_NUMBER & " - " & CalendarItem.JOB_DESC
                                    c = CalendarItem.JOB_NUMBER & "/" & CalendarItem.JOB_COMPONENT_NBR
                                    dt2.Rows.Add(row2)
                                End If
                            Next
                            Dim rstype As New ResourceType
                            rstype.DataSource = dt2
                            rstype.Name = "JobNum"
                            rstype.KeyField = "JOB_NUMBER"
                            rstype.TextField = "JOB_NUMBER"
                            rstype.ForeignKeyField = "JOB_NUMBER"
                            Dim rstype2 As New ResourceType
                            rstype2.DataSource = CalendarItems
                            rstype2.Name = "Type"
                            rstype2.KeyField = "RESOURCE_TYPE"
                            rstype2.TextField = "RESOURCE_TYPE"
                            rstype2.ForeignKeyField = "RESOURCE_TYPE"
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype2)
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupBy = "JobNum"
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupingDirection = GroupingDirection.Vertical
                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "MM/dd"
                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd/MM"
                            Else
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd.MM"
                            End If
                            Me.RadSchedulerProjectSchedule.DataKeyField = "DATA_KEY"
                            Me.RadSchedulerProjectSchedule.DataSubjectField = "JOB_NUMBER"
                        ElseIf GroupBy = "emp" Then
                            dt.Columns.Add(empcol)
                            dt.Columns.Add(sdate)
                            dt.Columns.Add(edate)
                            dt.Columns.Add(dk)
                            dt.Columns.Add(remind)
                            dt.Columns.Add(tasktype)
                            dt.Columns.Add(allday)
                            dt.Columns.Add(stime)
                            dt.Columns.Add(etime)
                            dt.Columns.Add(isnontask)
                            dt.Columns.Add(ntasktype)
                            dt.Columns.Add(icalid)
                            dt.Columns.Add(nontaskid)
                            dt.Columns.Add(adnbrcolor)
                            dt.Columns.Add(recurrence)
                            dt.Columns.Add(jnum)
                            dt.Columns.Add(jdesc)
                            dt.Columns.Add(jcnum)
                            dt.Columns.Add(jcdesc)
                            dt.Columns.Add(taskseqnbr)
                            dt.Columns.Add(clcode)
                            dt.Columns.Add(divcode)
                            dt.Columns.Add(prdcode)
                            dt.Columns.Add(clname)
                            dt.Columns.Add(divname)
                            dt.Columns.Add(prdname)
                            dt.Columns.Add(taskstatus)
                            dt.Columns.Add(empcode)
                            dt.Columns.Add(numdays)
                            dt.Columns.Add(priority)
                            dt.Columns.Add(resourcecode)
                            dt.Columns.Add(adnbr)
                            dt.Columns.Add(recurrenceparent)
                            dt.Columns.Add(tasknontaskdisplay)
                            dt.Columns.Add(nontaskcategory)
                            dt.Columns.Add(nontaskhours)
                            dt.Columns.Add(trfcode)
                            dt.Columns.Add(taskdescription)
                            dt.Columns.Add(hoursallowed)
                            dt.Columns.Add(empdeschrs)
                            dt.Columns.Add(duetime)
                            dt.Columns.Add(taskHoursAllowed)
                            dt.Columns.Add(empNameHours)
                            dt.Columns.Add(alertid)
                            dt.Columns.Add(sprintid)
                            For Each CalendarItem In CalendarItems
                                If CalendarItem.EMP_CODE Is Nothing Or CalendarItem.EMP_CODE = "" Then
                                    row = dt.NewRow
                                    row.Item("EMPLOYEE") = "N/A"
                                    row.Item("START_DATE") = CalendarItem.START_DATE
                                    row.Item("END_DATE") = CalendarItem.END_DATE
                                    row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID & "|" & count
                                    row.Item("REMINDER") = CalendarItem.REMINDER
                                    row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                    row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                    row.Item("START_TIME") = CalendarItem.START_TIME
                                    row.Item("END_TIME") = CalendarItem.END_TIME
                                    row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                    row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                    row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                    row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                    row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                    row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                    row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER
                                    row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                    row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                    row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                    row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                    row.Item("CL_CODE") = CalendarItem.CL_CODE
                                    row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                    row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                    row.Item("CL_NAME") = CalendarItem.CL_NAME
                                    row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                    row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                    row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                    row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                    row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                    row.Item("PRIORITY") = CalendarItem.PRIORITY
                                    row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                    row.Item("AD_NBR") = CalendarItem.AD_NBR
                                    row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                    row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                    row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                    row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                    row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                    row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                    row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                    row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                    row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                    row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                    row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                    row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                    row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                    dt.Rows.Add(row)
                                    count += 1
                                Else
                                    Dim empstr() As String = CalendarItem.EMP_FML_NAME_GROUP.Split(", ")
                                    For i As Integer = 0 To empstr.Length - 1
                                        row = dt.NewRow
                                        'Dim empfml() As String = empstr(i).Trim.Split(" - ")
                                        If CalendarItem.IS_NON_TASK = 0 Then
                                            row.Item("EMPLOYEE") = empstr(i).Trim 'empfml(1).Trim
                                        Else
                                            row.Item("EMPLOYEE") = CalendarItem.EMP_CODE & " - " & empstr(i).Trim
                                        End If
                                        row.Item("START_DATE") = CalendarItem.START_DATE
                                        row.Item("END_DATE") = CalendarItem.END_DATE
                                        row.Item("DATA_KEY") = CalendarItem.JOB_NUMBER & "|" & CalendarItem.JOB_COMPONENT_NBR & "|" & CalendarItem.TASK_SEQ_NBR & "|" & CalendarItem.CL_CODE & "|" & CalendarItem.DIV_CODE & "|" & CalendarItem.PRD_CODE & "|" & CalendarItem.IS_NON_TASK & "|" & CalendarItem.NON_TASK_ID & "|" & CalendarItem.NON_TASK_TYPE & "|" & CalendarItem.ALL_DAY & "|" & CalendarItem.ID & "|" & i
                                        row.Item("REMINDER") = CalendarItem.REMINDER
                                        row.Item("RESOURCE_TYPE") = CalendarItem.RESOURCE_TYPE
                                        row.Item("ALL_DAY") = CalendarItem.ALL_DAY
                                        row.Item("START_TIME") = CalendarItem.START_TIME
                                        row.Item("END_TIME") = CalendarItem.END_TIME
                                        row.Item("IS_NON_TASK") = CalendarItem.IS_NON_TASK
                                        row.Item("NON_TASK_TYPE") = CalendarItem.NON_TASK_TYPE
                                        row.Item("ICAL_ID") = CalendarItem.ICAL_ID
                                        row.Item("NON_TASK_ID") = CalendarItem.NON_TASK_ID
                                        row.Item("AD_NBR_COLOR") = CalendarItem.AD_NBR_COLOR
                                        row.Item("RECURRENCE") = CalendarItem.RECURRENCE
                                        row.Item("JOB_NUMBER") = CalendarItem.JOB_NUMBER
                                        row.Item("JOB_DESC") = CalendarItem.JOB_DESC
                                        row.Item("JOB_COMPONENT_NBR") = CalendarItem.JOB_COMPONENT_NBR
                                        row.Item("JOB_COMP_DESC") = CalendarItem.JOB_COMP_DESC
                                        row.Item("TASK_SEQ_NBR") = CalendarItem.TASK_SEQ_NBR
                                        row.Item("CL_CODE") = CalendarItem.CL_CODE
                                        row.Item("DIV_CODE") = CalendarItem.DIV_CODE
                                        row.Item("PRD_CODE") = CalendarItem.PRD_CODE
                                        row.Item("CL_NAME") = CalendarItem.CL_NAME
                                        row.Item("DIV_NAME") = CalendarItem.DIV_NAME
                                        row.Item("PRD_DESCRIPTION") = CalendarItem.PRD_DESCRIPTION
                                        row.Item("TASK_STATUS") = CalendarItem.TASK_STATUS
                                        row.Item("EMP_CODE") = CalendarItem.EMP_CODE
                                        row.Item("NUM_DAYS") = CalendarItem.NUM_DAYS
                                        row.Item("PRIORITY") = CalendarItem.PRIORITY
                                        row.Item("RESOURCE_CODE") = CalendarItem.RESOURCE_CODE
                                        row.Item("AD_NBR") = CalendarItem.AD_NBR
                                        row.Item("RECURRENCE_PARENT") = CalendarItem.RECURRENCE_PARENT
                                        row.Item("TASK_NON_TASK_DISPLAY") = CalendarItem.TASK_NON_TASK_DISPLAY
                                        row.Item("NON_TASK_CATEGORY") = CalendarItem.NON_TASK_CATEGORY
                                        row.Item("NON_TASK_HOURS") = CalendarItem.NON_TASK_HOURS
                                        row.Item("TRF_CODE") = CalendarItem.TRF_CODE
                                        row.Item("TASK_DESCRIPTION") = CalendarItem.TASK_DESCRIPTION
                                        row.Item("HoursAllowed") = CalendarItem.HoursAllowed
                                        row.Item("EMP_DESC_HRS") = CalendarItem.EMP_DESC_HRS
                                        row.Item("DUE_TIME") = CalendarItem.DUE_TIME
                                        row.Item("TASK_HOURS_ALLOWED") = CalendarItem.TASK_HOURS_ALLOWED
                                        row.Item("EMP_NAME_HOURS") = CalendarItem.EMP_NAME_HOURS
                                        row.Item("ALERT_ID") = CalendarItem.ALERT_ID
                                        row.Item("SPRINT_ID") = CalendarItem.SPRINT_ID
                                        dt.Rows.Add(row)
                                    Next
                                End If
                            Next
                            Dim emplstr As String = ""
                            Dim dv As DataView = dt.DefaultView
                            dv.Sort = "EMPLOYEE"
                            'dv.RowFilter = "START_DATE >= " & StartOfSelectedMonth.ToShortDateString & " And START_DATE <= " & EndOfSelectedMonth.ToShortDateString
                            dt = dv.ToTable
                            dt2 = New DataTable("calItems2")
                            Dim empcol2 As DataColumn = New DataColumn("EMPLOYEE")
                            dt2.Columns.Add(empcol2)
                            For Each CalendarItem In CalendarItems
                                If Not CalendarItem.EMP_CODE Is Nothing And CalendarItem.EMP_CODE <> "" Then
                                    Dim empstr2() As String = CalendarItem.EMP_FML_NAME_GROUP.Split(", ")
                                    For i As Integer = 0 To empstr2.Length - 1
                                        row2 = dt2.NewRow
                                        Dim empfml2() As String = empstr2(i).Trim.Split("-")
                                        If CalendarItem.IS_NON_TASK = 0 Then
                                            If emplstr.Contains(empfml2(1).Trim) = False Then
                                                row2.Item("EMPLOYEE") = empstr2(i).Trim 'empfml2(1).Trim
                                                emplstr &= empstr2(i).Trim & ", "
                                                dt2.Rows.Add(row2)
                                            End If
                                        Else
                                            If emplstr.Contains(empfml2(0).Trim) = False Then
                                                row2.Item("EMPLOYEE") = CalendarItem.EMP_CODE & " - " & empstr2(i).Trim 'empfml2(0).Trim
                                                emplstr &= empstr2(i).Trim & ", "
                                                dt2.Rows.Add(row2)
                                            End If
                                        End If

                                    Next
                                End If
                            Next
                            Dim dv2 As DataView = dt2.DefaultView
                            dv2.Sort = "EMPLOYEE"
                            'dv2.RowFilter = "START_DATE >= '" & StartOfSelectedMonth.ToShortDateString & "' AND START_DATE <= '" & EndOfSelectedMonth.ToShortDateString & "'"
                            dt2 = dv2.ToTable
                            If count > 0 Then
                                row2 = dt2.NewRow
                                row2.Item("EMPLOYEE") = "N/A"
                                dt2.Rows.Add(row2)
                            End If
                            Dim rstype As New ResourceType
                            rstype.DataSource = dt2
                            rstype.Name = "Employee"
                            rstype.KeyField = "EMPLOYEE"
                            rstype.TextField = "EMPLOYEE"
                            rstype.ForeignKeyField = "EMPLOYEE"
                            Dim rstype2 As New ResourceType
                            rstype2.DataSource = CalendarItems
                            rstype2.Name = "Type"
                            rstype2.KeyField = "RESOURCE_TYPE"
                            rstype2.TextField = "RESOURCE_TYPE"
                            rstype2.ForeignKeyField = "RESOURCE_TYPE"
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            Me.RadSchedulerProjectSchedule.ResourceTypes.Add(rstype2)
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupBy = "Employee"
                            Me.RadSchedulerProjectSchedule.TimelineView.GroupingDirection = GroupingDirection.Vertical
                            If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "MM/dd"
                            ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd/MM"
                            Else
                                Me.RadSchedulerProjectSchedule.TimelineView.ColumnHeaderDateFormat = "dd.MM"
                            End If
                            Me.RadSchedulerProjectSchedule.DataKeyField = "DATA_KEY"
                            Me.RadSchedulerProjectSchedule.DataSubjectField = "EMPLOYEE"
                        End If

                        Me.dtScheduler = dt
                        RadSchedulerProjectSchedule.DataSource = dt
                        RadSchedulerProjectSchedule.DataBind()
                        'If GridViewData.Visible = True Then
                        '    With GridViewData
                        '        .DataSource = dt
                        '        .DataBind()
                        '    End With
                        'End If
                        'If GridViewEmp.Visible = True Then
                        '    With GridViewEmp
                        '        .DataSource = dt2
                        '        .DataBind()
                        '    End With
                        'End If
                    Else
                        Me.RadSchedulerProjectSchedule.DataKeyField = "ID"
                        Me.RadSchedulerProjectSchedule.DataSubjectField = "JOB_NUMBER"
                        'Me.RadSchedulerProjectSchedule.DataReminderField = "REMINDER"
                        Me.RadSchedulerProjectSchedule.ResourceTypes.Clear()
                        If CalendarItems IsNot Nothing Then
                            Me.Cals = CalendarItems
                            Dim rstype As New ResourceType
                            rstype.DataSource = CalendarItems
                            rstype.Name = "Type"
                            rstype.KeyField = "RESOURCE_TYPE"
                            rstype.TextField = "RESOURCE_TYPE"
                            rstype.ForeignKeyField = "RESOURCE_TYPE"
                            RadSchedulerProjectSchedule.ResourceTypes.Add(rstype)
                            RadSchedulerProjectSchedule.DataSource = CalendarItems
                            RadSchedulerProjectSchedule.DataBind()
                        End If
                    End If
                End If
                Me.RadSchedulerProjectSchedule.AppointmentComparer = New CustomAppointmentComparer()
                Session("TaskCalendarSelectedDate") = DateSelected
            End Using
        Catch ex As Exception
            Me.ShowMessage(ex.InnerException.ToString)
        End Try
    End Sub
    Public Shared Function RenderEventsRS(ByVal CalendarItem As AdvantageFramework.Database.Classes.CalendarItem, ByVal IsJobCalendar As Boolean, ByVal IsNonTask As Integer, ByVal IsAllDay As Integer, ByVal IsTaskDayPage As Boolean) As String
        Try

            Dim oAppVars As cAppVars

            If IsJobCalendar = True Then

                oAppVars = New cAppVars(cAppVars.Application.PMD_CALENDAR)

            Else

                oAppVars = New cAppVars(cAppVars.Application.CALENDAR)

            End If

            oAppVars.getAllAppVars()

            Dim SbDetails As New System.Text.StringBuilder

            With SbDetails

                If IsNonTask = 1 Then 'Appointment or holiday
                    Dim NonTaskType As String = ""
                    Try
                        If CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.NON_TASK_TYPE) = False Then
                                NonTaskType = CalendarItem.NON_TASK_TYPE.ToString().Trim()
                                If NonTaskType = "H" Then
                                    .Append("H")
                                ElseIf NonTaskType = "A" Then
                                    .Append("A")
                                ElseIf NonTaskType = "C" Then
                                    .Append("C")
                                ElseIf NonTaskType = "M" Then
                                    .Append("M")
                                ElseIf NonTaskType = "TD" Then
                                    .Append("TD")
                                ElseIf NonTaskType = "EL" Then
                                    .Append("EL")
                                ElseIf NonTaskType = "NA" Then
                                    .Append("NA")
                                End If
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean) = True Then
                            If IsDBNull(CalendarItem.TASK_NON_TASK_DISPLAY) = False Then
                                .Append(CalendarItem.TASK_NON_TASK_DISPLAY.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean) = True Or IsTaskDayPage = True) And IsAllDay = 0 Then
                            If IsDBNull(CalendarItem.START_TIME) = False And IsDBNull(CalendarItem.END_TIME) = False Then
                                If IsDBNull(CalendarItem.NUM_DAYS) = False Then
                                    Dim DayCount As Integer = CType(CalendarItem.NUM_DAYS, Integer)
                                    If DayCount > 1 Then
                                        .Append(CType(CalendarItem.START_TIME, Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(CalendarItem.START_TIME, Date).ToShortTimeString())
                                        .Append(" - ")
                                        .Append(CType(CalendarItem.END_TIME, Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(CalendarItem.END_TIME, Date).ToShortTimeString())
                                        .Append("|")
                                    Else 'one day event:
                                        If CType(CalendarItem.START_TIME, Date).ToShortTimeString() <> CType(CalendarItem.END_TIME, Date).ToShortTimeString() Then
                                            .Append(CType(CalendarItem.START_TIME, Date).ToShortTimeString())
                                            .Append(" - ")
                                            .Append(CType(CalendarItem.END_TIME, Date).ToShortTimeString())
                                            .Append("|")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CalendarItem.NON_TASK_TYPE.ToString().Trim() = "C" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "M" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "TD" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "EL" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "NA" Then
                            If CType(oAppVars.getAppVar("tcal_haclientcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                                If IsDBNull(CalendarItem.CL_CODE) = False Then
                                    If CalendarItem.CL_CODE <> "" Then
                                        .Append(CalendarItem.CL_CODE.ToString())
                                        .Append("|")
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.NON_TASK_CATEGORY) = False Then
                                .Append(CalendarItem.NON_TASK_CATEGORY.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(CalendarItem.NON_TASK_TYPE) = False Then
                            If CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean) = True Then
                                If CalendarItem.NON_TASK_TYPE.ToString().Trim() = "A" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "C" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "M" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "TD" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "EL" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "NA" Then
                                    Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(HttpContext.Current.Session("ConnString")))
                                    Dim ds As DataSet
                                    Dim strEmps As String
                                    ds = oCalendar.GetNonTaskDataDS(CalendarItem.NON_TASK_ID, HttpContext.Current.Session("UserCode"))
                                    If ds.Tables(1).Rows.Count > 0 Then
                                        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                            strEmps += (ds.Tables(1).Rows(i)("EMP_CODE").ToString) & ","
                                        Next
                                    End If
                                    'If IsDBNull(Dt1.EMP_CODE_LIST) = False Then
                                    '.Append(MiscFN.RemoveTrailingDelimiter(Dt1.EMP_CODE_LIST, ","))
                                    .Append(MiscFN.RemoveTrailingDelimiter(strEmps, ","))
                                    .Append("|")
                                    'End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean) = True Then
                            If CalendarItem.NON_TASK_TYPE.ToString().Trim() = "A" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "C" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "M" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "TD" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "EL" Or CalendarItem.NON_TASK_TYPE.ToString().Trim() = "NA" Then
                                Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(HttpContext.Current.Session("ConnString")))
                                Dim ds As DataSet
                                Dim strEmps As String
                                ds = oCalendar.GetNonTaskDataDS(CalendarItem.NON_TASK_ID, HttpContext.Current.Session("UserCode"))
                                If ds.Tables(1).Rows.Count > 0 Then
                                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                        strEmps += (ds.Tables(1).Rows(i)("EMP_NAME").ToString) & ","
                                    Next
                                End If
                                'If IsDBNull(Dt1.EMP_CODE_LIST) = False Then
                                '    .Append(MiscFN.RemoveTrailingDelimiter(Dt1.EMP_NAME_LIST, ","))
                                .Append(MiscFN.RemoveTrailingDelimiter(strEmps, ","))
                                .Append("|")
                                'End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.NON_TASK_HOURS) = False Then
                                If NonTaskType = "H" Then
                                    If CType(CalendarItem.NON_TASK_HOURS, Decimal) > 0 Then
                                        .Append(FormatNumber(CalendarItem.NON_TASK_HOURS, 2, True, False, True))
                                        .Append("|")
                                    End If
                                Else
                                    .Append(FormatNumber(CalendarItem.NON_TASK_HOURS, 2, True, False, True))
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try


                ElseIf IsNonTask = 0 Then 'real task

                    Try
                        If MiscFN.IsClientPortal = True Then
                            If IsDBNull(CalendarItem.CL_CODE) = False Then
                                .Append(CalendarItem.CL_CODE.ToString())
                                .Append("|")
                            End If
                        Else
                            If CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                                If IsDBNull(CalendarItem.CL_CODE) = False Then
                                    .Append(CalendarItem.CL_CODE.ToString())
                                    .Append("|")
                                End If
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean) = True Then
                            If IsDBNull(CalendarItem.CL_NAME) = False Then
                                .Append(CalendarItem.CL_NAME.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.DIV_CODE) = False Then
                                .Append(CalendarItem.DIV_CODE.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean) = True Then
                            If IsDBNull(CalendarItem.DIV_NAME) = False Then
                                .Append(CalendarItem.DIV_NAME.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.PRD_CODE) = False Then
                                .Append(CalendarItem.PRD_CODE.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean) = True Then
                            If IsDBNull(CalendarItem.PRD_DESCRIPTION) = False Then
                                .Append(CalendarItem.PRD_DESCRIPTION.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.JOB_NUMBER) = False Then
                                If CalendarItem.JOB_NUMBER <> -1 Then
                                    .Append(CalendarItem.JOB_NUMBER.ToString())
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.JOB_DESC) = False Then
                                .Append(CalendarItem.JOB_DESC.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.JOB_COMPONENT_NBR) = False Then
                                If CalendarItem.JOB_COMPONENT_NBR <> -1 Then
                                    .Append(CalendarItem.JOB_COMPONENT_NBR.ToString())
                                    .Append("|")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.JOB_COMP_DESC) = False Then
                                .Append(CalendarItem.JOB_COMP_DESC.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.TRF_CODE) = False Then
                                .Append(CalendarItem.TRF_CODE.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.TASK_DESCRIPTION) = False Then
                                .Append(CalendarItem.TASK_DESCRIPTION.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                                If IsDBNull(CalendarItem.TASK_HOURS_ALLOWED) = False Then
                                    If CalendarItem.TASK_HOURS_ALLOWED.ToString.Trim() <> "" Then
                                        .Append(CalendarItem.EMP_CODE_HOURS.ToString())
                                        .Append("|")
                                    End If
                                End If
                            Else
                                If IsDBNull(CalendarItem.EMP_CODE) = False Then
                                    If CalendarItem.EMP_CODE.ToString.Trim() <> "" Then
                                        .Append(CalendarItem.EMP_CODE.ToString())
                                        .Append("|")
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean) = True Then
                            If (CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean) = True Or IsTaskDayPage = True) Then
                                If IsDBNull(CalendarItem.TASK_HOURS_ALLOWED) = False Then
                                    If CalendarItem.TASK_HOURS_ALLOWED.ToString.Trim() <> "" Then
                                        .Append(CalendarItem.EMP_NAME_HOURS.ToString())
                                        .Append("|")
                                    End If
                                End If

                            Else
                                If IsDBNull(CalendarItem.EMP_FML_NAME) = False Then
                                    Dim emp As String
                                    Dim str() As String = CalendarItem.EMP_FML_NAME.Split(",")
                                    For j As Integer = 0 To str.Count - 1
                                        If str(j) <> "" Then
                                            Dim stremp() As String = str(j).Split("-")
                                            If stremp(1) <> "" Then
                                                emp &= stremp(1) & ","
                                            End If
                                        End If
                                    Next
                                    emp = MiscFN.RemoveTrailingDelimiter(emp, ",")
                                    .Append(emp)
                                    .Append("|")
                                End If
                            End If

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If CType(oAppVars.getAppVar("tcal_ttimedue", "Boolean"), Boolean) = True Or IsTaskDayPage = True Then
                            If IsDBNull(CalendarItem.DUE_TIME) = False Then
                                .Append(CalendarItem.DUE_TIME.ToString())
                                .Append("|")
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                ElseIf IsNonTask = 2 Then 'it is an event
                    Try
                        If IsDBNull(CalendarItem.CL_CODE) = False Then
                            .Append(CalendarItem.CL_CODE.ToString())
                            .Append("|")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(CalendarItem.RESOURCE_CODE) = False Then
                            .Append(CalendarItem.RESOURCE_CODE.ToString())
                            .Append("|")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(CalendarItem.START_TIME) = False And IsDBNull(CalendarItem.END_TIME) = False Then
                            .Append(CType(CalendarItem.START_TIME, DateTime).ToShortTimeString())
                            .Append("-")
                            .Append(CType(CalendarItem.END_TIME, DateTime).ToShortTimeString())
                        End If
                    Catch ex As Exception
                    End Try
                ElseIf IsNonTask = 3 Then 'an event task
                    Try
                        If IsDBNull(CalendarItem.RESOURCE_CODE) = False Then
                            .Append(CalendarItem.RESOURCE_CODE.ToString())
                            .Append("|")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(CalendarItem.TRF_CODE) = False Then
                            .Append(CalendarItem.TRF_CODE.ToString())
                            .Append("|")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(CalendarItem.START_TIME) = False And IsDBNull(CalendarItem.END_TIME) = False Then
                            .Append(CType(CalendarItem.START_TIME, DateTime).ToShortTimeString())
                            .Append("-")
                            .Append(CType(CalendarItem.END_TIME, DateTime).ToShortTimeString())
                        End If
                    Catch ex As Exception
                    End Try




                End If
            End With
            Dim s As String = MiscFN.RemoveTrailingDelimiter(SbDetails.ToString().Trim(), "|")
            s = MiscFN.RemoveTrailingDelimiter(s, "|")
            s = MiscFN.RemoveTrailingDelimiter(s, ",")
            SbDetails = Nothing
            Return s

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function SetAppointmentSubject(ByVal CalendarItem As AdvantageFramework.Database.Classes.CalendarItem, ByVal isNonTask As Integer, ByVal isAllDay As Integer, ByVal IsTaskDayPage As Boolean) As String
        Try

            Dim SbSubject As New System.Text.StringBuilder
            Dim TotalHoursText As String = ""

            With SbSubject

                '.Append("<div class='calendar-appt-desc'>")
                '.Append(CalendarItem.TASK_NON_TASK_DISPLAY)
                '.Append("</div>")

                '.Append("<div class='calendar-appt-time-span'>")
                '.Append(AdvantageFramework.Web.Presentation.Controls.SetCalenderItemTimeSpan(CalendarItem, TotalHoursText))
                '.Append("</div>")

                '.Append("<div class='calendar-appt-desc-string'>")
                .Append(RenderEventsRS(CalendarItem, Me.CurrentQuerystring.IsJobDashboard, isNonTask, isAllDay, IsTaskDayPage))
                '.Append("</div>")

                '.Append("<div class='calendar-appt-total-hours'>")
                '.Append(TotalHoursText)
                '.Append("</div>")


            End With

            Dim s As String = SbSubject.ToString()
            SbSubject = Nothing
            Return s

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try
    End Function
    Private Function RenderToolTip(ByVal Dt1 As AdvantageFramework.Database.Classes.CalendarItem, ByVal isNonTask As Integer, ByVal NonTaskType As String, ByVal IsAllDay As Integer)
        Try
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            Dim SbDetails As New System.Text.StringBuilder

            With SbDetails
                If isNonTask = 1 Then
                    Dim ShowEmpCode As Boolean = False
                    Dim ShowEmpDescript As Boolean = False
                    If CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean) = True And NonTaskType = "A" Then
                        If IsDBNull(Dt1.EMP_CODE) = False Then
                            .Append("<strong>Employee: </strong> ")
                            .Append(Dt1.EMP_CODE.ToString())
                            ShowEmpCode = True
                        End If
                    End If
                    If CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean) = True And NonTaskType = "A" Then
                        If ShowEmpCode = True Then
                            If IsDBNull(Dt1.EMP_FML_NAME) = False Then
                                .Append(" - ")
                                .Append(Dt1.EMP_FML_NAME.ToString())
                            End If
                            ShowEmpDescript = True
                        Else
                            .Append("<strong>Employee: </strong> ")
                            .Append(Dt1.EMP_FML_NAME.ToString())
                        End If

                    End If
                    If ShowEmpCode = True Or ShowEmpDescript = True Then
                        .Append("<br />")
                    End If

                    If CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean) = True Then
                        If IsDBNull(Dt1.NON_TASK_TYPE) = False Then
                            .Append("<strong>Type:</strong> ")
                            If Dt1.NON_TASK_TYPE.ToString().Trim() = "H" Then
                                .Append("Holiday (H)")
                            ElseIf Dt1.NON_TASK_TYPE.ToString().Trim() = "A" Then
                                .Append("Appointment (A)")
                            End If
                            .Append("<br />")
                        End If
                    End If
                    If CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean) = True Then
                        If IsDBNull(Dt1.TASK_NON_TASK_DISPLAY) = False Then
                            .Append("<strong>Subject: </strong> ")
                            .Append(Dt1.TASK_NON_TASK_DISPLAY.ToString())
                            .Append("<br />")
                        End If
                    End If
                    If CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean) = True And IsAllDay = 0 Then
                        If IsDBNull(Dt1.START_TIME) = False And IsDBNull(Dt1.END_TIME) = False Then
                            .Append("<strong>Time: </strong> ")
                            If IsDBNull(Dt1.NUM_DAYS) = False Then
                                Dim DayCount As Integer = CType(Dt1.NUM_DAYS, Integer)
                                Dim HasTime As Boolean = False
                                If IsDBNull(Dt1.HAS_TIME) = False Then
                                    If CType(Dt1.HAS_TIME, Integer) = 1 Then
                                        HasTime = True
                                    End If
                                End If
                                If HasTime = True Then
                                    If DayCount > 1 Then
                                        .Append(CType(Dt1.START_TIME, Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(Dt1.START_TIME, Date).ToShortTimeString())
                                        .Append(" - ")
                                        .Append(CType(Dt1.END_TIME, Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(Dt1.END_TIME, Date).ToShortTimeString())
                                    Else 'one day event:
                                        .Append(CType(Dt1.START_TIME, Date).ToShortDateString())
                                        .Append(" ")
                                        .Append(CType(Dt1.START_TIME, Date).ToShortTimeString())
                                        .Append(" - ")
                                        .Append(CType(Dt1.END_TIME, Date).ToShortTimeString())
                                    End If
                                Else
                                    If DayCount > 1 Then
                                        .Append(CType(Dt1.START_TIME, Date).ToShortDateString())
                                        .Append(" - ")
                                        .Append(CType(Dt1.END_TIME, Date).ToShortDateString())
                                    Else 'one day event:
                                        .Append(CType(Dt1.START_TIME, Date).ToShortDateString())
                                    End If
                                End If
                            End If
                            .Append("<br />")
                        End If
                    End If
                    If CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean) = True Then
                        If IsDBNull(Dt1.NON_TASK_HOURS) = False Then
                            .Append("<strong>Hours: </strong> ")
                            .Append(FormatNumber(Dt1.NON_TASK_HOURS, 2, True, False, True))
                            .Append("<br />")
                        End If
                    End If
                    If CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean) = True Then
                        If IsDBNull(Dt1.NON_TASK_CATEGORY) = False Then
                            .Append("<strong>Category: </strong> ")
                            .Append(Dt1.NON_TASK_CATEGORY.ToString())
                            .Append("<br />")
                        End If
                    End If
                ElseIf isNonTask = 0 Then 'Real task!
                    Dim ShowCliCode As Boolean = False
                    Dim ShowDivCode As Boolean = False
                    Dim ShowPrdCode As Boolean = False
                    Dim ShowJobNum As Boolean = False
                    Dim ShowJobCompNum As Boolean = False
                    Dim ShowTaskCode As Boolean = False
                    Dim ShowEmpCode As Boolean = False
                    Dim ShowCliDesc As Boolean = False
                    Dim ShowDivDesc As Boolean = False
                    Dim ShowPrdDesc As Boolean = False
                    Dim ShowJobDesc As Boolean = False
                    Dim ShowJobCompDesc As Boolean = False
                    Dim ShowTaskDesc As Boolean = False
                    Dim ShowEmpDesc As Boolean = False

                    Try
                        If IsDBNull(Dt1.CL_CODE) = False Then
                            .Append("<strong>Client: </strong> ")
                            .Append(Dt1.CL_CODE.ToString())
                            ShowCliCode = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowCliCode = True Then
                            .Append(" - ")
                            .Append(Dt1.CL_NAME.ToString())
                        Else
                            If IsDBNull(Dt1.CL_NAME) = False Then
                                .Append("Client: ")
                                .Append(Dt1.CL_NAME.ToString())
                                ShowCliDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowCliCode = True Or ShowCliDesc = True Then
                        .Append("<br />")
                    End If


                    Try
                        If IsDBNull(Dt1.DIV_CODE) = False Then
                            .Append("<strong>Division: </strong> ")
                            .Append(Dt1.DIV_CODE.ToString())
                            ShowDivCode = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowDivCode = True Then
                            .Append(" - ")
                            .Append(Dt1.DIV_NAME.ToString())
                        Else
                            If IsDBNull(Dt1.DIV_NAME) = False Then
                                .Append("<strong>Division: </strong> ")
                                .Append(Dt1.DIV_NAME.ToString())
                                ShowDivDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowDivCode = True Or ShowDivDesc = True Then
                        .Append("<br />")
                    End If

                    Try
                        If IsDBNull(Dt1.PRD_CODE) = False Then
                            .Append("<strong>Product: </strong> ")
                            .Append(Dt1.PRD_CODE.ToString())
                            ShowPrdCode = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowPrdCode = True Then
                            .Append(" - ")
                            .Append(Dt1.PRD_DESCRIPTION.ToString())
                        Else
                            If IsDBNull(Dt1.PRD_DESCRIPTION) = False Then
                                .Append("<strong>Product: </strong> ")
                                .Append(Dt1.PRD_DESCRIPTION.ToString())
                                ShowPrdDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowPrdCode = True Or ShowPrdDesc = True Then
                        .Append("<br />")
                    End If
                    Try
                        If IsDBNull(Dt1.JOB_NUMBER) = False Then
                            .Append("<strong>Job: </strong> ")
                            .Append(Dt1.JOB_NUMBER.ToString().PadLeft(6, "0"))
                            ShowJobNum = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowJobNum = True Then
                            .Append(" - ")
                            .Append(Dt1.JOB_DESC.ToString())
                        Else
                            If IsDBNull(Dt1.JOB_DESC) = False Then
                                .Append("<strong>Job: </strong> ")
                                .Append(Dt1.JOB_DESC.ToString())
                                ShowJobDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowJobNum = True Or ShowJobDesc = True Then
                        .Append("<br />")
                    End If
                    Try
                        If IsDBNull(Dt1.JOB_COMPONENT_NBR) = False Then
                            .Append("<strong>Component: </strong> ")
                            .Append(Dt1.JOB_COMPONENT_NBR.ToString().PadLeft(2, "0"))
                            ShowJobCompNum = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowJobCompNum = True Then
                            .Append(" - ")
                            .Append(Dt1.JOB_COMP_DESC.ToString())
                        Else
                            If IsDBNull(Dt1.JOB_COMP_DESC) = False Then
                                .Append("<strong>Component: </strong> ")
                                .Append(Dt1.JOB_COMP_DESC.ToString())
                                ShowJobCompDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowJobCompNum = True Or ShowJobCompDesc = True Then
                        .Append("<br />")
                    End If
                    Try
                        If IsDBNull(Dt1.FNC_CODE) = False Then
                            .Append("<strong>Task: </strong> ")
                            .Append(Dt1.FNC_CODE.ToString())
                            ShowTaskCode = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If ShowTaskCode = True Then
                            .Append(" - ")
                            .Append(Dt1.TASK_DESCRIPTION.ToString())
                        Else
                            If IsDBNull(Dt1.TASK_DESCRIPTION) = False Then
                                .Append("<strong>Task: </strong> ")
                                .Append(Dt1.TASK_DESCRIPTION.ToString())
                                ShowTaskDesc = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    If ShowTaskCode = True Or ShowTaskDesc = True Then
                        .Append("<br />")
                    End If

                    Try
                        If IsDBNull(Dt1.NUM_DAYS) = False Then
                            Dim DayCount As Integer = CType(Dt1.NUM_DAYS, Integer)
                            If DayCount > 1 Then
                                .Append("<strong>Dates: </strong> ")
                                .Append(CType(Dt1.START_TIME, Date).ToShortDateString())
                                .Append(" - ")
                                .Append(CType(Dt1.END_TIME, Date).ToShortDateString())
                                .Append("<br />")
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    ShowEmpCode = True
                    ShowEmpDesc = True

                    If ShowEmpCode = True Or ShowEmpDesc = True Then
                        .Append("<strong>Employee(s): </strong> ")
                    End If
                    If ShowEmpCode = True And ShowEmpDesc = False Then
                        .Append(Dt1.EMP_CODE.ToString())
                    ElseIf ShowEmpCode = False And ShowEmpDesc = True Then
                        .Append(Dt1.EMP_FML_NAME.ToString().Replace(",", "<br />"))
                    ElseIf ShowEmpCode = True And ShowEmpDesc = True Then
                        .Append((Dt1.HoursAllowed).Replace(",", "<br />"))
                    End If
                    If ShowEmpCode = True Or ShowEmpDesc = True Then
                        .Append("<br />")
                    End If
                ElseIf isNonTask = 2 Then 'event
                    Try
                        If IsDBNull(Dt1.JOB_NUMBER) = False Then
                            .Append("<strong>Job Number: </strong> ")
                            .Append(Dt1.JOB_NUMBER.ToString().PadLeft(6, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.JOB_COMPONENT_NBR) = False Then
                            .Append("<strong>Component Number: </strong> ")
                            .Append(Dt1.JOB_COMPONENT_NBR.ToString().PadLeft(2, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.NON_TASK_ID) = False Then
                            .Append("<strong>Event ID: </strong> ")
                            .Append(Dt1.NON_TASK_ID.ToString().PadLeft(6, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.TASK_NON_TASK_DISPLAY) = False Then
                            .Append("<strong>Event Description: </strong> ")
                            .Append(Dt1.TASK_NON_TASK_DISPLAY.ToString())
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try

                ElseIf isNonTask = 3 Then 'an event task
                    Try
                        If IsDBNull(Dt1.JOB_NUMBER) = False Then
                            .Append("<strong>Job Number: </strong> ")
                            .Append(Dt1.JOB_NUMBER.ToString().PadLeft(6, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.JOB_COMPONENT_NBR) = False Then
                            .Append("<strong>Component Number: </strong> ")
                            .Append(Dt1.JOB_COMPONENT_NBR.ToString().PadLeft(2, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.TASK_SEQ_NBR) = False Then
                            .Append("<strong>Event ID: </strong> ")
                            .Append(Dt1.TASK_SEQ_NBR.ToString().PadLeft(6, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Dt1.NON_TASK_TYPE = "E" Then
                            .Append("<strong>Event Description: </strong> ")
                            .Append(Dt1.NON_TASK_ID.ToString.PadLeft(6, "0") & "-" & Dt1.TASK_NON_TASK_DISPLAY)
                            .Append("<br />")
                        End If
                        If Dt1.NON_TASK_TYPE = "ET" Then
                            .Append("<strong>Event Description: </strong> ")
                            .Append(Dt1.NON_TASK_ID.ToString.PadLeft(6, "0") & "-" & Dt1.TASK_NON_TASK_DISPLAY)
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.NON_TASK_ID) = False Then
                            .Append("<strong>Event Task ID: </strong> ")
                            .Append(Dt1.NON_TASK_ID.ToString().PadLeft(6, "0"))
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(Dt1.TRF_CODE) = False Then
                            .Append("<strong>Task Description: </strong> ")
                            .Append(Dt1.TRF_CODE.ToString() & "-" & Dt1.TRF_DESCRIPTION)
                            .Append("<br />")
                        End If
                    Catch ex As Exception
                    End Try
                    '
                End If
            End With

            Return SbDetails.ToString

        Catch ex As Exception

        End Try
    End Function
    Private Sub ExportCalendarItems()

        Try

            'objects
            Dim oFileStream As System.IO.FileStream = Nothing
            Dim byteICSFileBytes() As Byte = Nothing
            Dim oAgency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim oEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim sFileName As String = ""
            Dim ev As iCal.Events.cEvent
            Dim oICal As iCal.Events.cICalendar = New iCal.Events.cICalendar()
            Dim oDataTable As New Data.DataTable
            Dim CalendarItems As Generic.List(Of AdvantageFramework.Database.Classes.CalendarItem) = Nothing
            Dim EmpNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing

            If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                oDataTable = Me.dtScheduler
            Else
                CalendarItems = Me.Cals
            End If


            If oDataTable.Rows.Count > 0 Then
                For i As Integer = 0 To oDataTable.Rows.Count - 1

                    Dim aIcalID As String() = Split(oDataTable.Rows(i).Item("ICAL_ID"), "|")

                    ev = New iCal.Events.cEvent
                    Select Case aIcalID(0).ToString 'Mid(oDataTable.Rows(i).Item("ICAL_ID"), 1, 1)
                        Case "T"
                            ev.Title = oDataTable.Rows(i).Item("CL_CODE").ToString() + " " + oDataTable.Rows(i).Item("JOB_NUMBER").ToString() + " " + oDataTable.Rows(i).Item("TASK_DESCRIPTION").ToString() 'aka subject
                            ev.Description = "Client Code: " + oDataTable.Rows(i).Item("CL_CODE").ToString() + "=0D=0AClient Description: " + oDataTable.Rows(i).Item("CL_NAME").ToString() + "=0D=0ADivision Code: " + oDataTable.Rows(i).Item("DIV_CODE").ToString() + "=0D=0ADivision Description: " + oDataTable.Rows(i).Item("DIV_NAME").ToString() + "=0D=0AProduct Code:" + oDataTable.Rows(i).Item("PRD_CODE").ToString() + "=0D=0AProduct Description: " + oDataTable.Rows(i).Item("PRD_DESCRIPTION").ToString() + "=0D=0AJob Code: " + oDataTable.Rows(i).Item("JOB_NUMBER").ToString() + "=0D=0AJob Description: " + oDataTable.Rows(i).Item("JOB_DESC").ToString() + "=0D=0AComponent Number: " + oDataTable.Rows(i).Item("JOB_COMPONENT_NBR").ToString() + "=0D=0AComponent Description: " + oDataTable.Rows(i).Item("JOB_COMP_DESC").ToString() + "=0D=0ATask Info: " + oDataTable.Rows(i).Item("TASK_AND_DESCRIPT").ToString() + "=0D=0AEmployee Code: " + oDataTable.Rows(i).Item("EMP_CODE").ToString() + "=0D=0AEmployee Description " + oDataTable.Rows(i).Item("EMP_FML_NAME").ToString
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1) + aIcalID(2) + aIcalID(3) + aIcalID(4)

                        Case "A"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "H"
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "C"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "M"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "TD"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "EL"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = oDataTable.Rows(i).Item("TASK_NON_TASK_DISPLAY").ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                    End Select

                    ev.UseAlarm = True
                    If oDataTable.Rows(i).Item("HAS_TIME").ToString() = "1" Then
                        ev.StartTime = (CDate(oDataTable.Rows(i).Item("START_DATE").ToString()).ToString("MM/dd/yyyy") + " " + CDate(oDataTable.Rows(i).Item("START_TIME").ToString()).ToString("hh:mm:ss tt")).ToString
                        ev.EndTime = (CDate(oDataTable.Rows(i).Item("END_DATE").ToString()).ToString("MM/dd/yyyy") + " " + CDate(oDataTable.Rows(i).Item("END_TIME").ToString()).ToString("hh:mm:ss tt")).ToString
                    Else
                        ev.StartTime = oDataTable.Rows(i).Item("START_DATE").ToString() 'DateTime.Parse(Now.ToString())
                        ev.EndTime = oDataTable.Rows(i).Item("END_DATE").ToString() 'DateTime.Parse(Now.AddDays(1).ToString())
                    End If

                    ev.Priority = iCal.Events.PriorityLevel.Normal
                    ev.Category = " "
                    ev.SEQUENCE = RandomClass.Next(1, 1000).ToString() '(Now.Ticks / 100).ToString

                    oICal.cEvents.Add(ev)

                Next
            ElseIf CalendarItems.Count > 0 Then
                For j As Integer = 0 To CalendarItems.Count - 1
                    'ICAL Breakout
                    Dim aIcalID As String() = Split(CalendarItems(j).ICAL_ID, "|")
                    Dim empcode As String = ""
                    Dim empfml As String = ""
                    If Not CalendarItems(j).EMP_CODE Is Nothing Then
                        empcode = CalendarItems(j).EMP_CODE.ToString
                    End If
                    If Not CalendarItems(j).EMP_FML_NAME Is Nothing Then
                        empfml = CalendarItems(j).EMP_FML_NAME.ToString
                    End If

                    ev = New iCal.Events.cEvent
                    Select Case aIcalID(0).ToString 'Mid(CalendarItems(j).ICAL_ID, 1, 1)
                        Case "T"
                            ev.Title = CalendarItems(j).CL_CODE.ToString() + " " + CalendarItems(j).JOB_NUMBER.ToString() + " " + CalendarItems(j).TASK_DESCRIPTION.ToString() 'aka subject
                            ev.Description = "Client Code: " + CalendarItems(j).CL_CODE.ToString() + "=0D=0AClient Description: " + CalendarItems(j).CL_NAME.ToString() + "=0D=0ADivision Code: " + CalendarItems(j).DIV_CODE.ToString() + "=0D=0ADivision Description: " + CalendarItems(j).DIV_NAME.ToString() + "=0D=0AProduct Code:" + CalendarItems(j).PRD_CODE.ToString() + "=0D=0AProduct Description: " + CalendarItems(j).PRD_DESCRIPTION.ToString() + "=0D=0AJob Code: " + CalendarItems(j).JOB_NUMBER.ToString() + "=0D=0AJob Description: " + CalendarItems(j).JOB_DESC.ToString() + "=0D=0AComponent Number: " + CalendarItems(j).JOB_COMPONENT_NBR.ToString() + "=0D=0AComponent Description: " + CalendarItems(j).JOB_COMP_DESC.ToString() + "=0D=0ATask Info: " + CalendarItems(j).FNC_CODE.ToString() + " - " + CalendarItems(j).TASK_DESCRIPTION + "=0D=0AEmployee Code: " + empcode + "=0D=0AEmployee Description " + empfml
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1) + aIcalID(2) + aIcalID(3) + aIcalID(4)

                        Case "A"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "H"
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "C"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "M"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "TD"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                        Case "EL"
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                EmpNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, aIcalID(1))
                            End Using
                            ev.Title = CalendarItems(j).TASK_NON_TASK_DISPLAY.ToString() 'aka subject
                            ev.Description = EmpNonTask.NontaskDescription
                            ev.Location = "" 'oDataTable.Rows(i).Item("")
                            ev.UID = aIcalID(0) + aIcalID(1)

                    End Select

                    ev.UseAlarm = True
                    If CalendarItems(j).HAS_TIME.ToString() = "1" Then
                        ev.StartTime = CDate(CalendarItems(j).START_DATE.ToString()).ToShortDateString + " " + CDate(CalendarItems(j).START_TIME.ToString()).ToLongTimeString
                        ev.EndTime = CDate(CalendarItems(j).END_DATE.ToString()).ToShortDateString + " " + CDate(CalendarItems(j).END_TIME.ToString()).ToLongTimeString
                    Else
                        ev.StartTime = CalendarItems(j).START_DATE.ToString() 'DateTime.Parse(Now.ToString())
                        ev.EndTime = CalendarItems(j).END_DATE.ToString() 'DateTime.Parse(Now.AddDays(1).ToString())
                    End If

                    ev.Priority = iCal.Events.PriorityLevel.Normal
                    ev.Category = " "
                    ev.SEQUENCE = RandomClass.Next(1, 1000).ToString() '(Now.Ticks / 100).ToString

                    oICal.cEvents.Add(ev)
                Next
            End If
            Response.ContentType = "text/calendar"
            Response.AddHeader("content-disposition", "inline;filename=AdvantageCal.ics")
            Response.BinaryWrite(New System.Text.ASCIIEncoding().GetBytes(oICal.Output))
            Response.End()

        Catch ex As Exception
            Me.ShowMessage("Failed to export calendar")
        End Try

    End Sub
    Private Function GetGridColumnsToDisplay() As DataTable
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = s.GetScheduleColumns(Session("EmpCode"), False, False, False)
        Return dt
    End Function
    Private Sub imgbtnExport_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgbtnExport.Click
        Try
            Dim str As String = ""
            str = "EmployeeAssigments_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAssignments, str)

            RadGridAssignments.MasterTableView.GetColumn("ColPS").Visible = False
            RadGridAssignments.MasterTableView.ExportToExcel()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ImageButtonExport_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExport.Click
        Try
            Dim str As String = ""
            str = "EmployeeJobs_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAllocationJob, str)
            RadGridAllocationJob.MasterTableView.ExportToExcel()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckBoxIncludeTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeTasks.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showtasks", Me.CheckBoxIncludeTasks.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub
    Private Sub CheckBoxIncludeAssignments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeAssignments.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showassignments", Me.CheckBoxIncludeAssignments.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub
    Private Sub CheckBoxIncludeHolidays_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeHolidays.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showholidays", Me.CheckBoxIncludeHolidays.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub
    Private Sub CheckBoxIncludeAppointments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeAppointments.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showappointments", Me.CheckBoxIncludeAppointments.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub
    Private Sub CheckBoxIncludeEvents_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeEvents.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showevent", Me.CheckBoxIncludeEvents.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub
    Private Sub CheckBoxIncludeEventTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeEventTasks.CheckedChanged
        SetAppVarsApplication()
        oAppVars.setAppVarDB("tcal_showeventtasks", Me.CheckBoxIncludeEventTasks.Checked, "Boolean")
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If
    End Sub

#Region "  Form Event Handlers "

    Private Sub Calendar_MonthView_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Calendar)

        If Request.QueryString("JobNum") IsNot Nothing Then
            Me._JobNumber = Request.QueryString("JobNum")
        End If
        If Request.QueryString("JobCompNum") IsNot Nothing Then
            Me._JobComponentNumber = Request.QueryString("JobCompNum")
        End If
        If Request.QueryString("calView") IsNot Nothing Then
            Me.CalendarPage = Request.QueryString("calView")
        End If
        'let qs class override
        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent()
        Me._IsJobDashboard = qs.IsJobDashboard
        If Me._JobNumber = 0 AndAlso qs.JobNumber > 0 Then Me._JobNumber = qs.JobNumber
        If Me._JobComponentNumber = 0 AndAlso qs.JobComponentNumber > 0 Then Me._JobComponentNumber = qs.JobComponentNumber
        If Me.CalendarPage = "" AndAlso Session("PMD_Calendar_View") IsNot Nothing Then Me.CalendarPage = Session("PMD_Calendar_View")

        Me.RadToolbarCalendar.FindItemByValue("RadToolBarButtonIncludeTooltip").Attributes.Add("id", "RadToolBarButtonIncludeTooltip")
        Me.txtAssignments = CType(Me.RadToolbarCalendar.FindItemByValue("RadToolBarButtonTxtAssignments").FindControl("TextboxAssignments"), TextBox)


    End Sub
    Private Sub Calendar_MonthView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                Dim sd As DateTime
                Dim ed As DateTime
                SetAppVarsApplication()
                oAppVars.setAppVarDB("CalView", "month")
                oAppVars.getAllAppVars()

                LoGlo.PageCultureSet(Me.Page)

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    If Request.QueryString("CalendarPageView") IsNot Nothing Then
                        Me.CalendarPageView = Request.QueryString("CalendarPageView")
                    End If

                    If Request.QueryString("from") = "dash" Then
                        Me.RadTabStripTaskCalendar.Visible = False
                        Me.RadToolbarCalendar.Visible = False
                        Me.RadSchedulerProjectSchedule.ShowViewTabs = False
                    End If

                    Me.RadSchedulerProjectSchedule.Culture = LoGlo.GetCultureInfo
                    'Me.RadSchedulerProjectSchedule.TimeZoneID = AdvantageFramework.Database.Procedures.Generic.LoadEmployeeTimeZoneID(DbContext, Session("EmpCode"))

                    If Me.CurrentQuerystring.IsJobDashboard = True Then

                        Me.DivJobInformation.Visible = False

                    End If


                    Dim AllowGroupToViewOtherEmployees As Boolean = False
                    Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

                    Try

                        UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

                        For Each UserGroupSettingValue In UserGroupSettingValues

                            Try

                                If UserGroupSettingValue = True Then

                                    AllowGroupToViewOtherEmployees = True
                                    Exit For

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                    Catch ex As Exception
                        AllowGroupToViewOtherEmployees = False
                    End Try

                    If AllowGroupToViewOtherEmployees = False Then
                        oAppVars.setAppVar("tcal_emp", Session("EmpCode"))
                        oAppVars.SaveAllAppVars()
                    End If

                    Select Case CalendarPageView
                        Case 0
                            Me.RadMultiPageCalendar.SelectedIndex = 0
                            Me.RadTabStripTaskCalendar.SelectedIndex = 0
                        Case 1
                            Me.RadMultiPageCalendar.SelectedIndex = 1
                            Me.RadTabStripTaskCalendar.SelectedIndex = 1
                            Me.LoadCalendarListView()
                        Case 2
                            Me.RadMultiPageCalendar.SelectedIndex = 2
                            Me.RadTabStripTaskCalendar.SelectedIndex = 2
                            Me.PageTitle = "Workload"
                            LoadTasksWorkload()
                        Case 3
                            Me.RadMultiPageCalendar.SelectedIndex = 3
                            Me.RadTabStripTaskCalendar.SelectedIndex = 3
                            Me.txtTasks.Visible = False
                            Me.TextBox1.Visible = False
                            Me.TextBox6.Visible = False
                            Me.TextBox7.Visible = False
                            Me.TextBoxAllocationTasks.Visible = False
                            Me.TextBoxAllocationAppointments.Visible = False
                            Me.TextBoxAllocationHours.Visible = False
                            Me.TextBoxAllocationEvent.Visible = False
                            Me.Label1.Visible = False
                            Me.Label2.Visible = False
                            Me.Label11.Visible = False
                            Me.Label19.Visible = False
                            Me.LabelAllocationTasks.Visible = False
                            Me.LabelAllocationAppointments.Visible = False
                            Me.LabelAllocationHours.Visible = False
                            Me.LabelAllocationEvent.Visible = False
                            LoadEmployeeList()
                            Me.ddEmployee.SelectedValue = Session("CalendarPageViewEmpDrop")
                            EnableOrDisableAvailabilityOptions()
                        Case 4
                            Me.RadMultiPageCalendar.SelectedIndex = 4
                            Me.RadTabStripTaskCalendar.SelectedIndex = 4
                            Me.PageTitle = "Task Filter"
                            SetLookUps()
                            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Calendar)
                            Dim oReports As New cReports(Session("ConnString"))
                            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
                            If str <> "" Or Not str Is Nothing Then
                                Me.hlManager.Text = str & ":"
                            End If
                            SetLookUps()
                            LoadLengths()
                            LoadDeptList()
                            Me.LoadRoles(Me.LbRoles)
                            Me.LoadRoles(Me.lbFunctionRoles)
                            LoadSettings()
                            LoadTasksFilter(oAppVars.getAppVar("tcal_emp"))
                            Me.FocusControl(Me.txtOffice)
                            Page.Form.DefaultButton = Me.butSave.UniqueID
                        Case 5
                            Me.RadMultiPageCalendar.SelectedIndex = 6
                            Me.RadTabStripTaskCalendar.SelectedIndex = 6
                            Me.PageTitle = "Print Options"
                        Case 6
                            Me.RadMultiPageCalendar.SelectedIndex = 5
                            Me.RadTabStripTaskCalendar.SelectedIndex = 5
                            Me.txtTasks.Visible = False
                            Me.TextBox1.Visible = False
                            Me.TextBox6.Visible = False
                            Me.TextBox7.Visible = False
                            Me.TextBoxAllocationTasks.Visible = False
                            Me.TextBoxAllocationAppointments.Visible = False
                            Me.TextBoxAllocationHours.Visible = False
                            Me.TextBoxAllocationEvent.Visible = False
                            Me.Label1.Visible = False
                            Me.Label2.Visible = False
                            Me.Label11.Visible = False
                            Me.Label19.Visible = False
                            Me.LabelAllocationTasks.Visible = False
                            Me.LabelAllocationAppointments.Visible = False
                            Me.LabelAllocationHours.Visible = False
                            Me.LabelAllocationEvent.Visible = False
                            LoadEmployeeList()
                            Me.ddEmployee.SelectedValue = Session("CalendarPageViewEmpDrop")
                            EnableOrDisableAllocationOptions()
                        Case 7
                            Me.RadMultiPageCalendar.SelectedIndex = 7
                            Me.RadTabStripTaskCalendar.SelectedIndex = 4
                            Me.txtTasksAct.Visible = False
                            Me.TextBox3.Visible = False
                            Me.TextBox4.Visible = False
                            Me.TextBox5.Visible = False
                            Me.TextBoxAllocationTasks.Visible = False
                            Me.TextBoxAllocationAppointments.Visible = False
                            Me.TextBoxAllocationHours.Visible = False
                            Me.TextBoxAllocationEvent.Visible = False
                            Me.Label20.Visible = False
                            Me.Label21.Visible = False
                            Me.Label22.Visible = False
                            Me.Label23.Visible = False
                            Me.LabelAllocationTasks.Visible = False
                            Me.LabelAllocationAppointments.Visible = False
                            Me.LabelAllocationHours.Visible = False
                            Me.LabelAllocationEvent.Visible = False
                            LoadEmployeeListAct()
                            Me.ddEmployeeAct.SelectedValue = Session("CalendarPageViewEmpDrop")
                            EnableOrDisableActualizationOptions()
                            Dim otask As cTasks = New cTasks(Session("ConnString"))
                            Dim taskVar As String

                            LoadActualizationOptions()

                            Try
                                If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning") <> "" Then
                                    Me.CheckBoxOmit.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning"), Boolean)
                                End If
                                If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent") <> "" Then
                                    Me.CheckBoxShowPercent.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent"), Boolean)
                                End If
                            Catch ex As Exception

                            End Try
                        Case Else
                            Me.RadTabStripTaskCalendar.SelectedIndex = 0
                    End Select

                    If Session("TaskCalendarSelectedDate") Is Nothing Then
                        Session("TaskCalendarSelectedDate") = cEmployee.TimeZoneToday
                        dtThisDate = cEmployee.TimeZoneToday
                    Else
                        dtThisDate = CType(Session("TaskCalendarSelectedDate"), Date)
                    End If
                    Me.RadSchedulerProjectSchedule.SelectedDate = dtThisDate
                    If Not Me.CalendarPage Is Nothing Then
                        If Me.CalendarPage = "Week" Then
                            Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView
                            Me.RadToolbarCalendar.Items(7).Visible = False
                            Me.RadToolbarCalendar.Items(8).Visible = False
                            Me.RadToolbarCalendar.Items(9).Visible = True
                        End If
                        If Me.CalendarPage = "Day" Then
                            Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.DayView
                            Me.RadToolbarCalendar.Items(7).Visible = False
                            Me.RadToolbarCalendar.Items(8).Visible = False
                            Me.RadToolbarCalendar.Items(9).Visible = True
                        End If
                        If Me.CalendarPage = "Timeline" Then
                            Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView
                            Me.RadToolBarButtonGroupBy.Visible = True
                            Me.RadToolbarCalendar.Items(5).Visible = False
                            Me.RadToolbarCalendar.Items(7).Visible = False
                            Me.RadToolbarCalendar.Items(8).Visible = False
                            Me.RadToolbarCalendar.Items(9).Visible = False
                            Me.RadToolBarButtonGroupBy.Visible = True
                        End If
                        If Me.CalendarPage = "Month" Then
                            Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.MonthView
                            Me.RadToolbarCalendar.Items(7).Visible = True
                            Me.RadToolbarCalendar.Items(8).Visible = True
                            Me.RadToolbarCalendar.Items(9).Visible = True
                        End If
                    Else
                        Me.RadSchedulerProjectSchedule.SelectedView = 2
                    End If
                    'If Session("tcal_emp") Is Nothing Then
                    '    Session("tcal_emp") = Session("EmpCode")
                    'End If
                    'If Request.QueryString("FromApp") = "PS" Or Request.QueryString("FromApp") = "PSMV" Then
                    '    Session("tcal_emp") = ""
                    'End If
                    SetSessionDefaults()

                    Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
                    Dim JobComponentTasksList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing
                    If Request.QueryString("FromApp") = "PS" Then

                        If Me._JobNumber > 0 Then
                            JobComponentTasksList = AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext).ToList.Where(Function(JobComponentTask) JobComponentTask.JobNumber = Me._JobNumber And
                                                                                                                                                 JobComponentTask.JobComponentNumber = Me._JobComponentNumber).ToList
                        ElseIf oAppVars.getAppVar("tcal_jobno") <> "" Then
                            JobComponentTasksList = AdvantageFramework.Database.Procedures.JobComponentTask.Load(DbContext).ToList.Where(Function(JobComponentTask) JobComponentTask.JobNumber = CInt(oAppVars.getAppVar("tcal_jobno")) And JobComponentTask.JobComponentNumber = CInt(oAppVars.getAppVar("tcal_jobcomp"))).ToList
                        End If
                        For Each JobComponentTask In JobComponentTasksList
                            If JobComponentTask.CompletedDate Is Nothing AndAlso JobComponentTask.CompletedDate.HasValue = False Then
                                If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.StartDate.HasValue Then
                                    If cGlobals.wvIsDate(JobComponentTask.StartDate) Then
                                        If sd <> Nothing Then
                                            If sd > JobComponentTask.StartDate Then
                                                sd = JobComponentTask.StartDate
                                            End If
                                        Else
                                            sd = JobComponentTask.StartDate
                                        End If
                                    End If
                                End If
                                If JobComponentTask.DueDate IsNot Nothing AndAlso JobComponentTask.DueDate.HasValue Then
                                    If cGlobals.wvIsDate(JobComponentTask.DueDate) Then
                                        If ed <> Nothing Then
                                            If ed < JobComponentTask.DueDate Then
                                                ed = JobComponentTask.DueDate
                                            End If
                                        Else
                                            ed = JobComponentTask.DueDate
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        If sd <> Nothing Then
                            RadSchedulerProjectSchedule.SelectedDate = sd
                            oAppVars.setAppVarDB("tcal_startdate", sd, "Date")
                        End If
                        If ed <> Nothing Then
                            oAppVars.setAppVarDB("tcal_enddate", ed, "Date")
                        Else
                            If sd <> Nothing Then
                                oAppVars.setAppVarDB("tcal_enddate", CDate(sd).AddMonths(1), "Date")
                            End If
                        End If

                        'Me.RadToolBarButtonNew.Visible = False
                        'Me.RadToolBarButtonTasks.Visible = False
                        'Me.RadToolBarButtonAppointments.Visible = False
                        'Me.RadToolBarButtonEvents.Visible = False
                        'Me.RadToolBarButtonEventTasks.Visible = False
                        'Me.RadToolBarButtonHolidays.Visible = False
                    ElseIf Request.QueryString("FromApp") = "PSMV" Then
                        If Request.QueryString("jcs") <> "" Then
                            JCs = Request.QueryString("jcs").ToString.Split("|")
                        End If

                        If Not Session("TrafficScheduleMVJobs") Is Nothing Then
                            If Session("TrafficScheduleMVJobs") <> "" Then
                                JCs = Session("TrafficScheduleMVJobs").ToString.Split("|")
                            End If
                        End If
                        If JCs.Length > 0 Then
                            For i As Integer = 0 To JCs.Length - 1
                                Dim strJC() As String = JCs(i).Split(",")
                                If strJC(0) <> "" Then
                                    'JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, strJC(0), strJC(1))
                                    JobComponentTasksList = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, CInt(strJC(0)), CInt(strJC(1))).ToList
                                    For Each JobComponentTask In JobComponentTasksList
                                        If JobComponentTask.CompletedDate Is Nothing AndAlso JobComponentTask.CompletedDate.HasValue = False Then
                                            If JobComponentTask.StartDate IsNot Nothing AndAlso JobComponentTask.StartDate.HasValue Then
                                                If cGlobals.wvIsDate(JobComponentTask.StartDate) Then
                                                    If sd <> Nothing Then
                                                        If sd > JobComponentTask.StartDate Then
                                                            sd = JobComponentTask.StartDate
                                                        End If
                                                    Else
                                                        sd = JobComponentTask.StartDate
                                                    End If
                                                End If
                                            End If
                                            If JobComponentTask.DueDate IsNot Nothing AndAlso JobComponentTask.DueDate.HasValue Then
                                                If cGlobals.wvIsDate(JobComponentTask.DueDate) Then
                                                    If ed <> Nothing Then
                                                        If ed < JobComponentTask.DueDate Then
                                                            ed = JobComponentTask.DueDate
                                                        End If
                                                    Else
                                                        ed = JobComponentTask.DueDate
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                        If sd <> Nothing Then
                            RadSchedulerProjectSchedule.SelectedDate = sd
                            oAppVars.setAppVarDB("tcal_startdate", sd, "Date")
                        End If
                        If ed <> Nothing Then
                            oAppVars.setAppVarDB("tcal_enddate", ed, "Date")
                        Else
                            If sd <> Nothing Then
                                oAppVars.setAppVarDB("tcal_enddate", sd.AddMonths(1), "Date")
                            End If
                        End If
                    End If

                    If Not Me.CalendarPage Is Nothing Then
                        If Me.CalendarPage = "Week" Then
                            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "W")
                        End If
                        If Me.CalendarPage = "Day" Then
                            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "D")
                        End If
                        If Me.CalendarPage = "Timeline" Then
                            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "T", 1)
                            Me.RadToolBarButtonGroupBy.Visible = True
                        End If
                        If Me.CalendarPage = "Month" Then
                            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                        End If
                    Else
                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                    End If

                    If Me.IsClientPortal = True Then
                        Me.RadTabStripTaskCalendar.Tabs(1).Visible = False
                        Me.RadTabStripTaskCalendar.Tabs(2).Visible = False
                        Me.RadTabStripTaskCalendar.Tabs(3).Visible = False
                        Me.RadTabStripTaskCalendar.Tabs(4).Visible = False
                        Me.RadTabStripTaskCalendar.Tabs(5).Visible = False
                        Me.RadTabStripTaskCalendar.Tabs(6).Visible = False
                        Me.RadToolBarButtonExport.Visible = True
                        Me.RadToolBarButtonGroupBy.Visible = False
                        Me.RadToolBarButtonNew.Visible = False
                        'Me.RadToolBarButtonPdf.Visible = False
                        'Me.RadToolBarButtonPrint.Visible = False

                        'Me.RadToolBarButtonAppointments.Visible = False
                        'Me.RadToolBarButtonEvents.Visible = False
                        'Me.RadToolBarButtonEventTasks.Visible = False
                        'Me.RadToolBarButtonHolidays.Visible = False
                        'Me.RadToolBarButtonTasks.Visible = False
                        Me.RadToolTipIncludeItems.TargetControlID = Nothing
                        Me.RadToolbarCalendar.FindItemByValue("RadToolBarButtonIncludeTooltip").Visible = False
                        Me.RadToolbarCalendar.FindItemByValue("Bookmark").Visible = False

                        Me.RadToolbarCalendar.Items(2).Visible = False
                        Me.RadToolbarCalendar.Items(1).Visible = False
                        Me.RadSchedulerProjectSchedule.AllowEdit = False
                        Me.RadSchedulerProjectSchedule.AllowInsert = False
                    End If

                    'Me.RadSchedulerProjectSchedule.AdvancedForm.Enabled = False
                Else
                    'Me.RadSchedulerProjectSchedule.AdvancedForm.Enabled = False
                    dtThisDate = CDate(ViewState("ThisDate"))
                    Select Case Me.EventArgument
                        Case "Refresh"
                            If Not Me.CalendarPage Is Nothing Then

                                Select Case Me.CalendarPage
                                    Case "Week"

                                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "W")
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)

                                    Case "Day"

                                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "D")

                                    Case "Timeline"

                                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "T", 1)
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(45)
                                        Me.RadToolBarButtonGroupBy.Visible = True

                                    Case "Month"

                                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)

                                End Select

                            Else

                                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                                Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)

                            End If
                        Case Else

                            If Me.RadTabStripTaskCalendar.SelectedTab Is Nothing Then

                                Me.RadTabStripTaskCalendar.SelectedIndex = 0

                            End If

                            If Not Me.CalendarPage Is Nothing Then

                                Select Case Me.CalendarPage
                                    Case "Week"

                                        Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView
                                        Me.RadToolbarCalendar.Items(7).Visible = False
                                        Me.RadToolbarCalendar.Items(8).Visible = False
                                        Me.RadToolbarCalendar.Items(9).Visible = True
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)

                                    Case "Day"

                                        Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.DayView
                                        Me.RadToolbarCalendar.Items(7).Visible = False
                                        Me.RadToolbarCalendar.Items(8).Visible = False
                                        Me.RadToolbarCalendar.Items(9).Visible = True

                                    Case "Timeline"

                                        Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView
                                        Me.RadToolBarButtonGroupBy.Visible = True
                                        Me.RadToolbarCalendar.Items(5).Visible = False
                                        Me.RadToolbarCalendar.Items(7).Visible = False
                                        Me.RadToolbarCalendar.Items(8).Visible = False
                                        Me.RadToolbarCalendar.Items(9).Visible = False
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(45)
                                        Me.RadToolBarButtonGroupBy.Visible = True

                                    Case "Month"

                                        Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.MonthView
                                        Me.RadToolbarCalendar.Items(7).Visible = True
                                        Me.RadToolbarCalendar.Items(8).Visible = True
                                        Me.RadToolbarCalendar.Items(9).Visible = True
                                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)

                                End Select

                            Else

                                Me.RadSchedulerProjectSchedule.SelectedView = 2

                            End If

                    End Select

                End If

                If Me.CurrentQuerystring.IsJobDashboard = True Then

                    Me.RadTabStripTaskCalendar.FindTabByValue("2").Visible = False 'Hide workload
                    Me.RadTabStripTaskCalendar.FindTabByValue("3").Visible = False 'Hide availability
                    'Me.RadTabStripTaskCalendar.FindTabByValue("4").Visible = False 'Hide filter
                    Me.RadTabStripTaskCalendar.FindTabByValue("6").Visible = False 'Hide allocation

                End If

            Catch ex As Exception
            End Try

        End Using
    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Try
            RadSchedulerProjectSchedule.Skin = RadSkinManager.GetCurrent(Me.Page).Skin
            'RadSchedulerProjectSchedule.Skin = "Simple"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Calendar_MonthView_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(45)

            Dim menu As RadSchedulerContextMenu = RadSchedulerProjectSchedule.FindControl("SchedulerAppointmentContextMenuTask")
            Dim access As Integer
            access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False)
            If access = 0 Then
                menu.Items.FindItemByValue("Edit").Enabled = False
                menu.Items.FindItemByValue("PS").Enabled = False
            End If
            access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, False)
            If access = 0 Then
                menu.Items.FindItemByValue("JC").Enabled = False
            End If
            menu.Items.FindItemByValue("EditAssignment").Enabled = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit)
            If Me.IsClientPortal = True Then
                menu.Items.FindItemByValue("Calculate").Enabled = False
                menu.Items.FindItemByValue("Edit").Text = "Show Task"
            End If
        Catch ex As Exception

        End Try
        If Me.Page.IsPostBack = True And Me.RblAvailabilitySummaryLevel.Visible = True Then
            Dim HasChecked As Boolean = False
            For i As Integer = 0 To Me.RblAvailabilitySummaryLevel.Items.Count - 1
                If Me.RblAvailabilitySummaryLevel.Items(i).Selected = True Then
                    HasChecked = True
                End If
            Next
            If HasChecked = True Then
                Me.RadGridAvailability.Visible = True
            End If
        End If
        If Me.txtEmpCode.Text = "" Then
            Me.lbDept.Enabled = True
        Else
            Me.lbDept.Enabled = False
        End If
        If Me.ChkRoles.Checked = True Then
            Me.LbRoles.Enabled = True
        Else
            Me.LbRoles.Enabled = False
        End If
        If Me.ChkFunctionRoles.Checked = True Then
            Me.lbFunctionRoles.Enabled = True
        Else
            Me.lbFunctionRoles.Enabled = False
        End If

        ScriptManager.GetCurrent(Page).RegisterPostBackControl(ButtonExportAct)
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(imgbtnExportAct)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadSchedulerProjectSchedule_AppointmentClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerEventArgs) Handles RadSchedulerProjectSchedule.AppointmentClick
        Try
            Dim str() As String = e.Appointment.Description.Split("|")
            Dim str2() As String = e.Appointment.Subject.Split("|")
            Dim StrEditURL As String
            Dim qs As New AdvantageFramework.Web.QueryString
            If str(6) = 0 Then

                If str(8) = "T" Then
                    'qs.Page = "TrafficSchedule_TaskDetail.aspx"
                    'qs.JobNumber = str(0)
                    'qs.JobComponentNbr = str(1)
                    'qs.TaskSeqNbr = str(2)
                    'qs.ClCode = str(3)
                    'qs.DivCode = str(4)
                    'qs.PrdCode = str(5)
                    'qs.Add("pop", 0)
                    'qs.Add("JobNum", str(0))
                    'qs.Add("JobComp", str(1))
                    'qs.Add("SeqNum", str(2))
                    'qs.Add("Client", str(3))
                    'qs.Add("Division", str(4))
                    'qs.Add("Product", str(5))

                    StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & str(0) & "&JobComp=" & str(1) & "&SeqNum=" & str(2) & "&Client=" & str(3) & "&Division=" & str(4) & "&Product=" & str(5)

                    Dim task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, str(0), str(1), str(2))

                        If task IsNot Nothing Then
                            Me.OpenWindow(If(str(16) = "", task.Description.Replace("'", "\'"), str(16).Replace("'", "\'")), StrEditURL, 650, 860, False, True, "RefreshPage")
                        Else
                            Me.OpenWindow("Task", StrEditURL, 650, 860, False, True, "RefreshPage")
                        End If

                    End Using

                    'Me.OpenWindow(str(16), StrEditURL, 650, 860, False, True, "RefreshPage")

                End If
                If str(8) = "AS" Or str(8) = "ASO" Then
                    qs.Page = "Desktop_AlertView"
                    qs.Add("AlertID", str(17))
                    qs.Add("SprintID", str(18))

                    Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, str(17))

                        If alert IsNot Nothing Then
                            Me.OpenWindow(qs, If(str(16) = "", alert.Subject.Replace("'", "\'"), str(16).Replace("'", "\'")), , , , True, "RefreshPage")
                        Else
                            Me.OpenWindow(qs, "Assignment", , , , True, "RefreshPage")
                        End If

                    End Using

                    'Me.OpenWindow(qs, str2(5).Replace("'", "\'"), , , , True, "RefreshPage")
                End If


            ElseIf str(6) = 1 Then
                Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, str(7))
                End Using
                Session("CalendarNonTaskNo") = Nothing
                If task.Recurrence <> "" Or Not task.RecurrenceParent Is Nothing Then
                    Me.OpenWindow("Appointment", "Calendar_AppointmentCheck.aspx?TaskNo=" & str(7) & "&state=edit", 200, 400, False, True, "RefreshPage")
                Else
                    StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & str(7) & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & str(0) & "&JobComponentNbr=" & str(1)
                    Me.OpenWindow("New Activity", StrEditURL, 1000, 1500, False, False, "RefreshPage")
                End If
            ElseIf str(6) = 2 Then
                StrEditURL = "Event_Detail.aspx?et=0&j=" & str(0) & "&jc=" & str(1) & "&evt=" & str(7) & "&cli=" & str(3) & "&from=1"
                Me.OpenWindow("Event Detail", StrEditURL,,,,, "RefreshPage")
            ElseIf str(6) = 3 Then
                StrEditURL = "Event_Task_Detail.aspx?etid=" & str(7) & "&f=c"
                Me.OpenWindow("Event Task Edit", StrEditURL, 620, 670, False, True, "RefreshPage")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentCommandEventArgs) Handles RadSchedulerProjectSchedule.AppointmentCommand
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentContextMenuItemClicked(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentContextMenuItemClickedEventArgs) Handles RadSchedulerProjectSchedule.AppointmentContextMenuItemClicked

        Try
            'Me.RadSchedulerProjectSchedule.SelectedDate = e.Appointment.End
            'Session("TaskCalendarSelectedDate") = e.Appointment.End
            Dim str() As String = e.Appointment.Description.Split("|")
            Dim str2() As String = e.Appointment.Subject.Split("|")
            'Dim StrEditURL As String
            Me.CalendarPageView = 0
            Dim qs As New AdvantageFramework.Web.QueryString

            If e.MenuItem.Value = "Edit" Then
                If str(6) = 0 Then
                    If str(8) = "T" Then
                        qs.Page = "TrafficSchedule_TaskDetail.aspx"
                        qs.JobNumber = str(0)
                        qs.JobComponentNumber = str(1)
                        qs.TaskSequenceNumber = str(2)
                        qs.ClientCode = str(3)
                        qs.DivisionCode = str(4)
                        qs.ProductCode = str(5)
                        qs.Add("pop", 0)
                        qs.Add("JobNum", str(0))
                        qs.Add("JobComp", str(1))
                        qs.Add("SeqNum", str(2))
                        qs.Add("Client", str(3))
                        qs.Add("Division", str(4))
                        qs.Add("Product", str(5))

                        Dim task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, str(0), str(1), str(2))

                            If task IsNot Nothing Then
                                Me.OpenWindow(qs, If(str(16) = "", task.Description.Replace("'", "\'"), str(16).Replace("'", "\'")), , , , True, "RefreshPage")
                            Else
                                Me.OpenWindow(qs, "Task", , , , True, "RefreshPage")
                            End If

                        End Using

                    End If
                    If str(8) = "AS" Or str(8) = "ASO" Then
                        qs.Page = "Desktop_AlertView"
                        qs.Add("AlertID", str(17))
                        qs.Add("SprintID", str(18))

                        Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, str(17))

                            If alert IsNot Nothing Then
                                Me.OpenWindow(qs, If(str(16) = "", alert.Subject.Replace("'", "\'"), str(16).Replace("'", "\'")), , , , True, "RefreshPage")
                            Else
                                Me.OpenWindow(qs, "Assignment", , , , True, "RefreshPage")
                            End If

                        End Using

                    End If

                ElseIf str(6) = 1 Then

                    Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, str(7))

                    End Using
                    Session("CalendarNonTaskNo") = Nothing

                    qs.TaskSequenceNumber = str(7)
                    qs.Add("TaskNo", str(7))

                    If task.Recurrence <> "" Or Not task.RecurrenceParent Is Nothing Then
                        qs.Page = "Calendar_AppointmentCheck.aspx"
                        qs.Add("state", "edit")

                        Me.OpenWindow(qs, If(str(16) = "", str2(5), str(16)), 200, 400)

                    Else
                        qs.Page = "Calendar_NewActivity.aspx"
                        qs.Add("calView", Me.CalendarPage)
                        qs.Add("FromApp", Request.QueryString("FromApp"))
                        qs.JobNumber = str(0)
                        qs.JobComponentNumber = str(1)

                        Me.OpenWindow(qs, "New Activity", 1000, 1300,,, "RefreshPage")

                    End If

                ElseIf str(6) = 2 Then

                    qs.Page = "Event_Detail.aspx"
                    qs.JobNumber = str(0)
                    qs.JobComponentNumber = str(1)
                    qs.EventID = str(7)
                    qs.ClientCode = str(3)
                    qs.Add("from", "1")
                    qs.Add("et", "0")
                    qs.Add("cl", str(3))

                    Me.OpenWindow(qs, If(str(16) = "", str2(5), str(16)), 0, 0,,, "RefreshPage")

                ElseIf str(6) = 3 Then

                    qs.Page = "Event_Task_Detail.aspx"
                    qs.EventTaskID = str(7)
                    qs.Add("", str(7))
                    qs.Add("f", "c")

                    Me.OpenWindow(qs, "Event Task Edit", 650, 700,,, "RefreshPage")

                End If
            End If
            If e.MenuItem.Value = "PS" Then

                qs.Page = "Content.aspx"
                qs.JobNumber = str(0)
                qs.JobComponentNumber = str(1)
                qs.Add("JobNum", str(0))
                qs.Add("JobComp", str(1))
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                Me.OpenWindow(qs, If(str(16) = "", str2(2), str(16)), 0, 0,,, "RefreshPage")

            End If
            If e.MenuItem.Value = "JC" Then

                qs.Page = "Content.aspx"
                qs.JobNumber = str(0)
                qs.JobComponentNumber = str(1)
                qs.Add("JobNum", str(0))
                qs.Add("JobComp", str(1))
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate

                Me.OpenWindow(qs, If(str(16) = "", str2(2), str(16)), 0, 0,,, "RefreshPage")

            End If
            If e.MenuItem.Value = "EditAssignment" Then

                Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
                oTask.Where.JOB_NUMBER.Value = str(0)
                oTask.Where.JOB_COMPONENT_NBR.Value = str(1)
                oTask.Where.SEQ_NBR.Value = str(2)

                Dim taskcode As String

                If oTask.Query.Load Then

                    taskcode = oTask.FNC_CODE

                End If

                qs.Page = "TrafficSchedule_TaskEmployees.aspx"
                qs.Add("From", "cal")
                qs.Add("FromApp", Me.CurrentQuerystring.Get("FromApp"))
                qs.JobNumber = str(0)
                qs.JobComponentNumber = str(1)
                qs.TaskSequenceNumber = str(2)
                qs.TaskCode = taskcode

                qs.Add("JobNum", str(0))
                qs.Add("JobComp", str(1))
                qs.Add("SeqNum", str(2))
                qs.Add("TaskCode", taskcode)

                Me.OpenWindow(qs, "Edit Assignee", 600, 650, False, True)

            End If
            If e.MenuItem.Value = "Calculate" Then
                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim dt As DataTable = Me.GetGridColumnsToDisplay
                Dim pred As Integer = 0
                Dim msg As String = ""
                Me._JobNumber = str(0)
                Me._JobComponentNumber = str(1)
                If Me._JobNumber > 0 And Me._JobComponentNumber > 0 Then
                    Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
                    If access = 1 Then
                        Dim dtHeader As DataTable = s.GetScheduleHeader(Me._JobNumber, Me._JobComponentNumber, Session("UserCode").ToString(), False).Tables(0)
                        Dim BoolCalcByDueDate As Boolean = False
                        Dim CalcBy As Integer = 0 '1 is start, zero/null is due
                        If IsDBNull(dtHeader.Rows(0)("TRF_SCHEDULE_BY")) = False Then
                            CalcBy = CType(dtHeader.Rows(0)("TRF_SCHEDULE_BY"), Integer)
                            If CalcBy = 0 Then
                                BoolCalcByDueDate = True
                            Else
                                BoolCalcByDueDate = False
                            End If
                        Else
                            BoolCalcByDueDate = True
                        End If
                        If BoolCalcByDueDate = True Then
                            If IsDBNull(dtHeader.Rows(0)("JOB_FIRST_USE_DATE")) = True Then
                                msg = "Due Date required."
                                Me.ShowMessage(msg)
                                Exit Sub
                            End If
                        Else
                            If IsDBNull(dtHeader.Rows(0)("START_DATE")) = True Then
                                msg = "Start Date required."
                                Me.ShowMessage(msg)
                                Exit Sub
                            End If
                        End If
                        If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                            pred = 1
                        ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                            pred = 0
                        Else
                            For j As Integer = 0 To dt.Rows.Count - 1
                                If dt.Rows(j)("COLUMN_NAME") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(j)("SHOW_ON_GRID") = "True" Then
                                    pred = 1
                                End If
                            Next
                        End If

                        'runt calc sp:
                        Dim i As Integer = 0
                        Dim strCalc As String = ""
                        If pred = 1 Then
                            i = s.CalculateDueDatesPred(Me._JobNumber, Me._JobComponentNumber, 1)
                        Else
                            i = s.CalculateDueDates(Me._JobNumber, Me._JobComponentNumber, 0)
                        End If
                        Select Case i
                            Case -1
                                strCalc = "Could Not Get start Date."
                            Case -2
                                strCalc = "Schedule Is Not feasible For calculation."
                        End Select
                        If i = -1 Or i = -2 Then
                            Me.ShowMessage(strCalc)
                            Exit Sub
                        End If

                        Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, Me._JobNumber, Me._JobComponentNumber).ToList
                            If JobPred.Count > 0 Then
                                i = s.CalculateJobPreds(Me._JobNumber, Me._JobComponentNumber, 0, Session("EmpCode"))
                            End If
                        End Using

                        Me.ShowMessage("Re-calculation Is complete.")
                    Else
                        Me.ShowMessage("You Do Not have permission To edit tasks")
                    End If
                End If
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_TimeSlotContextMenuItemClicked(ByVal sender As Object, ByVal e As Telerik.Web.UI.TimeSlotContextMenuItemClickedEventArgs) Handles RadSchedulerProjectSchedule.TimeSlotContextMenuItemClicked
        Try
            If e.MenuItem.Text = "New Activity" Then
                Session("CalendarNonTaskNo") = Nothing
                Dim strURL As String = "Calendar_NewActivity.aspx?thisdate=" & e.TimeSlot.Start.ToShortDateString & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & Me._JobNumber & "&JobComponentNbr=" & Me._JobComponentNumber
                Me.OpenWindow("New Holiday/Appointment", strURL, 1000, 1500, False, False, "RefreshPage")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerEventArgs) Handles RadSchedulerProjectSchedule.AppointmentDataBound

        Dim s As String
        Dim str2 As String = e.Appointment.Subject
        Dim str3 As String = e.Appointment.ToString
        Dim str6 As String = e.Appointment.Description
        Dim clr As System.Drawing.Color
        Dim clrt As System.Drawing.ColorTranslator
        Dim lab As System.Web.UI.WebControls.Label
        SetAppVarsApplication()
        Dim StartOfSelectedMonth As DateTime = StartDate
        Dim EndOfSelectedMonth As DateTime = EndDate
        Dim NonTaskType As String = ""
        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim ds As DataSet
        Dim EmpReminder As Boolean = False

        oAppVars.getAllAppVars()

        If Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = True Then

            NonTaskType = ""

        ElseIf Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = False Then

            NonTaskType = "H"

        ElseIf Me.CheckBoxIncludeHolidays.Checked = False And Me.CheckBoxIncludeAppointments.Checked = True Then

            NonTaskType = "A"

        Else

            NonTaskType = "N"

        End If

        Try
            Dim type As String = e.Appointment.DataItem.GetType.ToString

            If type = "System.Data.DataRowView" Then

                Dim d As DataRowView = e.Appointment.DataItem
                Dim col As Integer

                If GroupBy = "job" Then

                    col = 4

                ElseIf GroupBy = "emp" Then

                    col = 3

                End If

                Dim key() As String = d.Row(col).ToString.Split("|")
                Dim calitem As AdvantageFramework.Database.Classes.CalendarItem = Nothing

                calitem = New AdvantageFramework.Database.Classes.CalendarItem
                If IsDBNull(d.Item("ALL_DAY")) = False Then
                    calitem.ALL_DAY = CInt(d.Item("ALL_DAY"))
                End If
                If IsDBNull(d.Item("START_DATE")) = False Then
                    calitem.START_DATE = CDate(d.Item("START_DATE"))
                End If
                If IsDBNull(d.Item("END_DATE")) = False Then
                    calitem.END_DATE = CDate(d.Item("END_DATE"))
                End If
                If IsDBNull(d.Item("REMINDER")) = False Then
                    calitem.REMINDER = d.Item("REMINDER")
                End If
                If IsDBNull(d.Item("RESOURCE_TYPE")) = False Then
                    calitem.RESOURCE_TYPE = d.Item("RESOURCE_TYPE")
                End If
                If IsDBNull(d.Item("START_TIME")) = False Then
                    calitem.START_TIME = CDate(d.Item("START_TIME"))
                End If
                If IsDBNull(d.Item("END_TIME")) = False Then
                    calitem.END_TIME = CDate(d.Item("END_TIME"))
                End If
                If IsDBNull(d.Item("IS_NON_TASK")) = False Then
                    calitem.IS_NON_TASK = CShort(d.Item("IS_NON_TASK"))
                End If
                If IsDBNull(d.Item("NON_TASK_TYPE")) = False Then
                    calitem.NON_TASK_TYPE = d.Item("NON_TASK_TYPE")
                End If
                If IsDBNull(d.Item("ICAL_ID")) = False Then
                    calitem.ICAL_ID = d.Item("ICAL_ID")
                End If
                If IsDBNull(d.Item("NON_TASK_ID")) = False Then
                    calitem.NON_TASK_ID = CInt(d.Item("NON_TASK_ID"))
                End If
                If IsDBNull(d.Item("AD_NBR_COLOR")) = False Then
                    calitem.AD_NBR_COLOR = d.Item("AD_NBR_COLOR")
                End If
                If IsDBNull(d.Item("RECURRENCE")) = False Then
                    calitem.RECURRENCE = d.Item("RECURRENCE")
                End If
                If GroupBy = "job" Then

                    If IsDBNull(d.Item("JOB_NBR")) = False Then
                        calitem.JOB_NUMBER = CInt(d.Item("JOB_NBR"))
                    End If

                ElseIf GroupBy = "emp" Then

                    If IsDBNull(d.Item("JOB_NUMBER")) = False Then
                        calitem.JOB_NUMBER = CInt(d.Item("JOB_NUMBER"))
                    End If

                End If

                If IsDBNull(d.Item("JOB_DESC")) = False Then
                    calitem.JOB_DESC = d.Item("JOB_DESC")
                End If
                If IsDBNull(d.Item("JOB_COMPONENT_NBR")) = False Then
                    calitem.JOB_COMPONENT_NBR = CShort(d.Item("JOB_COMPONENT_NBR"))
                End If
                If IsDBNull(d.Item("JOB_COMP_DESC")) = False Then
                    calitem.JOB_COMP_DESC = d.Item("JOB_COMP_DESC")
                End If
                If IsDBNull(d.Item("TASK_SEQ_NBR")) = False Then
                    calitem.TASK_SEQ_NBR = CInt(d.Item("TASK_SEQ_NBR"))
                End If
                If IsDBNull(d.Item("CL_CODE")) = False Then
                    calitem.CL_CODE = d.Item("CL_CODE")
                End If
                If IsDBNull(d.Item("DIV_CODE")) = False Then
                    calitem.DIV_CODE = d.Item("DIV_CODE")
                End If
                If IsDBNull(d.Item("PRD_CODE")) = False Then
                    calitem.PRD_CODE = d.Item("PRD_CODE")
                End If
                If IsDBNull(d.Item("CL_NAME")) = False Then
                    calitem.CL_NAME = d.Item("CL_NAME")
                End If
                If IsDBNull(d.Item("DIV_NAME")) = False Then
                    calitem.DIV_NAME = d.Item("DIV_NAME")
                End If
                If IsDBNull(d.Item("PRD_DESCRIPTION")) = False Then
                    calitem.PRD_DESCRIPTION = d.Item("PRD_DESCRIPTION")
                End If
                If IsDBNull(d.Item("TASK_STATUS")) = False Then
                    calitem.TASK_STATUS = d.Item("TASK_STATUS")
                End If
                If IsDBNull(d.Item("EMP_CODE")) = False Then
                    calitem.EMP_CODE = d.Item("EMP_CODE")
                End If
                If IsDBNull(d.Item("NUM_DAYS")) = False Then
                    calitem.NUM_DAYS = CInt(d.Item("NUM_DAYS"))
                End If
                If IsDBNull(d.Item("PRIORITY")) = False Then
                    calitem.PRIORITY = d.Item("PRIORITY")
                End If
                If IsDBNull(d.Item("RESOURCE_CODE")) = False Then
                    calitem.AD_NBR_COLOR = d.Item("RESOURCE_CODE")
                End If
                If IsDBNull(d.Item("AD_NBR")) = False Then
                    calitem.AD_NBR = d.Item("AD_NBR")
                End If
                If IsDBNull(d.Item("RECURRENCE_PARENT")) = False Then
                    calitem.RECURRENCE_PARENT = CInt(d.Item("RECURRENCE_PARENT"))
                End If
                If IsDBNull(d.Item("TASK_NON_TASK_DISPLAY")) = False Then
                    calitem.TASK_NON_TASK_DISPLAY = d.Item("TASK_NON_TASK_DISPLAY")
                End If
                If IsDBNull(d.Item("NON_TASK_CATEGORY")) = False Then
                    calitem.NON_TASK_CATEGORY = d.Item("NON_TASK_CATEGORY")
                End If
                If IsDBNull(d.Item("NON_TASK_HOURS")) = False Then
                    calitem.NON_TASK_HOURS = CDec(d.Item("NON_TASK_HOURS"))
                End If
                If IsDBNull(d.Item("TRF_CODE")) = False Then
                    calitem.TRF_CODE = d.Item("TRF_CODE")
                End If
                If IsDBNull(d.Item("TASK_DESCRIPTION")) = False Then
                    calitem.TASK_DESCRIPTION = d.Item("TASK_DESCRIPTION")
                End If
                If IsDBNull(d.Item("HoursAllowed")) = False Then
                    calitem.HoursAllowed = d.Item("HoursAllowed")
                End If
                If IsDBNull(d.Item("EMP_DESC_HRS")) = False Then
                    calitem.EMP_DESC_HRS = d.Item("EMP_DESC_HRS")
                End If
                If IsDBNull(d.Item("DUE_TIME")) = False Then
                    calitem.DUE_TIME = d.Item("DUE_TIME")
                End If
                If IsDBNull(d.Item("TASK_HOURS_ALLOWED")) = False Then
                    calitem.TASK_HOURS_ALLOWED = CDec(d.Item("TASK_HOURS_ALLOWED"))
                End If
                If IsDBNull(d.Item("EMP_NAME_HOURS")) = False Then
                    calitem.EMP_NAME_HOURS = d.Item("EMP_NAME_HOURS")
                End If
                If IsDBNull(d.Item("ALERT_ID")) = False Then
                    calitem.ALERT_ID = CInt(d.Item("ALERT_ID"))
                End If
                If IsDBNull(d.Item("SPRINT_ID")) = False Then
                    calitem.SPRINT_ID = CInt(d.Item("SPRINT_ID"))
                End If

                If GroupBy = "emp" Then

                    If IsDBNull(d.Item("EMPLOYEE")) = False Then
                        calitem.EMP_FML_NAME = d.Item("EMPLOYEE")
                    End If

                End If




                If Not calitem.ALL_DAY Is Nothing Then

                    's = Me.RenderEventsRS(calitem, calitem.IS_NON_TASK, calitem.ALL_DAY, False)
                    s = Me.SetAppointmentSubject(calitem, calitem.IS_NON_TASK, calitem.ALL_DAY, False)

                Else

                    's = Me.RenderEventsRS(calitem, calitem.IS_NON_TASK, 0, False)
                    s = Me.SetAppointmentSubject(calitem, calitem.IS_NON_TASK, 0, False)

                End If
                e.Appointment.Subject = s
                'e.Appointment.CssClass = "calendar-Default"
                If (calitem.ALL_DAY = 0 Or calitem.IS_NON_TASK = 2 Or calitem.IS_NON_TASK = 3) And e.Appointment.RecurrenceState <> RecurrenceState.Occurrence Then

                    e.Appointment.Start = calitem.START_TIME
                    e.Appointment.End = calitem.END_TIME

                Else

                    If calitem.NON_TASK_TYPE <> "A" And calitem.NON_TASK_TYPE <> "C" And calitem.NON_TASK_TYPE <> "TD" And calitem.NON_TASK_TYPE <> "M" And calitem.NON_TASK_TYPE <> "EL" And calitem.NON_TASK_TYPE <> "NA" Then

                        e.Appointment.End = CDate(e.Appointment.End).AddHours(24).ToShortDateString

                    End If

                End If

                If calitem.NON_TASK_TYPE = "A" Or calitem.NON_TASK_TYPE = "C" Or calitem.NON_TASK_TYPE = "TD" Or calitem.NON_TASK_TYPE = "M" Or calitem.NON_TASK_TYPE = "EL" Or calitem.NON_TASK_TYPE = "NA" Then

                    If calitem.ICAL_ID <> "" Then

                        Dim strICal() As String = calitem.ICAL_ID.Split("|")

                        If strICal(2) > 0 Then

                            e.Appointment.AllowDelete = True

                        Else

                            e.Appointment.AllowDelete = True

                        End If
                        If calitem.REMINDER <> "" Then
                            ds = oCalendar.GetNonTaskDataDS(calitem.NON_TASK_ID, HttpContext.Current.Session("UserCode"))

                            If ds.Tables(1).Rows.Count > 0 Then

                                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1

                                    If ds.Tables(1).Rows(i)("EMP_CODE").ToString = HttpContext.Current.Session("EmpCode") Then

                                        EmpReminder = True

                                    End If

                                Next

                            End If
                            If calitem.NON_TASK_TYPE = "A" Then

                                If strICal(3) <> "" And EmpReminder = True Then

                                    e.Appointment.Reminders.Add(New Reminder(calitem.REMINDER))

                                End If

                            Else

                                If strICal(5) <> "" And EmpReminder = True Then

                                    e.Appointment.Reminders.Add(New Reminder(calitem.REMINDER))

                                End If

                            End If
                        End If

                    Else

                        e.Appointment.AllowDelete = True

                    End If

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf calitem.NON_TASK_TYPE = "H" Then

                    e.Appointment.AllowDelete = True
                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf calitem.NON_TASK_TYPE = "E" Then

                    clr = clrt.FromHtml(calitem.AD_NBR_COLOR)
                    e.Appointment.BackColor = clr
                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf calitem.NON_TASK_TYPE = "ET" Then

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf calitem.NON_TASK_TYPE = "T" Then

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenuTask"

                    Select Case calitem.TASK_STATUS
                        Case "A"

                                'e.Appointment.CssClass = "calendar-appt calendar-task-active"


                        Case "P"

                                'e.Appointment.CssClass = "calendar-appt calendar-task-pending-calendar"

                        Case "N"

                            'e.Appointment.CssClass = "calendar-appt calendar-task-pending"

                    End Select

                ElseIf calitem.NON_TASK_TYPE = "AS" Then

                    If calitem.JOB_NUMBER > 0 Then
                        e.Appointment.ContextMenuID = "RadSchedulerContextMenuAssignment"
                    Else
                        e.Appointment.ContextMenuID = "RadSchedulerContextMenuAssignmentNoJob"
                    End If

                ElseIf calitem.NON_TASK_TYPE = "ASO" Then

                    e.Appointment.ContextMenuID = "RadSchedulerContextMenuOfficeAssignment"

                End If

                If Not calitem.ALL_DAY Is Nothing Then

                    e.Appointment.ToolTip = ""

                Else

                    e.Appointment.ToolTip = ""

                End If

                If calitem.RECURRENCE.ToString = "" Then

                    e.Appointment.Description = calitem.JOB_NUMBER & "|" & calitem.JOB_COMPONENT_NBR & "|" & calitem.TASK_SEQ_NBR & "|" & calitem.CL_CODE & "|" & calitem.DIV_CODE & "|" & calitem.PRD_CODE & "|" & calitem.IS_NON_TASK & "|" & calitem.NON_TASK_ID & "|" & calitem.NON_TASK_TYPE & "|" & calitem.ALL_DAY & "|" & calitem.TASK_STATUS & "|" & calitem.EMP_CODE & "|" & calitem.NUM_DAYS & "|" & calitem.PRIORITY & calitem.RESOURCE_CODE & CDate(calitem.START_TIME.ToString).ToString("MMM dd yyyy HH: mm tt") & calitem.AD_NBR & calitem.JOB_NUMBER.ToString.PadLeft(6, "0") & "| |" & calitem.RECURRENCE_PARENT & "|" & calitem.TASK_NON_TASK_DISPLAY & "|" & calitem.ALERT_ID & "|" & calitem.SPRINT_ID

                Else

                    e.Appointment.Description = calitem.JOB_NUMBER & "|" & calitem.JOB_COMPONENT_NBR & "|" & calitem.TASK_SEQ_NBR & "|" & calitem.CL_CODE & "|" & calitem.DIV_CODE & "|" & calitem.PRD_CODE & "|" & calitem.IS_NON_TASK & "|" & calitem.NON_TASK_ID & "|" & calitem.NON_TASK_TYPE & "|" & calitem.ALL_DAY & "|" & calitem.TASK_STATUS & "|" & calitem.EMP_CODE & "|" & calitem.NUM_DAYS & "|" & calitem.PRIORITY & calitem.RESOURCE_CODE & CDate(calitem.START_TIME.ToString).ToString("MMM dd yyyy HH:mm tt") & calitem.AD_NBR & calitem.JOB_NUMBER.ToString.PadLeft(6, "0") & "|" & calitem.RECURRENCE.ToString & "|" & calitem.RECURRENCE_PARENT & "|" & calitem.TASK_NON_TASK_DISPLAY & "|" & calitem.ALERT_ID & "|" & calitem.SPRINT_ID

                End If

            Else

                Dim app As AdvantageFramework.Database.Classes.CalendarItem = e.Appointment.DataItem

                If Not app.ALL_DAY Is Nothing Then

                    's = Me.RenderEventsRS(app, app.IS_NON_TASK, app.ALL_DAY, False)
                    s = Me.SetAppointmentSubject(app, app.IS_NON_TASK, app.ALL_DAY, False)

                Else

                    's = Me.RenderEventsRS(app, app.IS_NON_TASK, 0, False)
                    s = Me.SetAppointmentSubject(app, app.IS_NON_TASK, 0, False)

                End If

                e.Appointment.Subject = s

                If (app.ALL_DAY = 0 Or app.IS_NON_TASK = 2 Or app.IS_NON_TASK = 3) And e.Appointment.RecurrenceState <> RecurrenceState.Occurrence Then

                    e.Appointment.Start = app.START_TIME
                    e.Appointment.End = app.END_TIME

                Else

                    e.Appointment.End = CDate(e.Appointment.End).AddHours(24).ToShortDateString

                End If

                Select Case app.NON_TASK_TYPE
                    Case "A"

                        'e.Appointment.CssClass = "calendar-appt calendar-activity"

                    Case "C"

                        'e.Appointment.CssClass = "calendar-appt calendar-activity-c"

                    Case "TD"

                        'e.Appointment.CssClass = "calendar-appt calendar-activity-td"

                    Case "M"

                        'e.Appointment.CssClass = "calendar-appt calendar-activity-m"

                    Case "H"

                        'e.Appointment.CssClass = "calendar-appt calendar-holiday"

                    Case "E"

                        'e.Appointment.CssClass = "calendar-appt calendar-event"

                    Case "ET"

                        'e.Appointment.CssClass = "calendar-appt calendar-event-task"

                    Case "T"

                        Select Case app.TASK_STATUS

                            Case "A"

                                'e.Appointment.CssClass = "calendar-appt calendar-task-active"


                            Case "P"

                                'e.Appointment.CssClass = "calendar-appt calendar-task-pending-calendar"

                            Case "N"

                                'e.Appointment.CssClass = "calendar-appt calendar-task-pending"

                        End Select

                End Select
                If app.NON_TASK_TYPE = "A" Or app.NON_TASK_TYPE = "C" Or app.NON_TASK_TYPE = "TD" Or app.NON_TASK_TYPE = "M" Or app.NON_TASK_TYPE = "EL" Or app.NON_TASK_TYPE = "NA" Then

                    If app.ICAL_ID <> "" Then

                        Dim strICal() As String = app.ICAL_ID.Split("|")
                        If strICal(2) > 0 Then

                            e.Appointment.AllowDelete = True

                        Else

                            e.Appointment.AllowDelete = True

                        End If
                        If app.REMINDER <> "" Then
                            ds = oCalendar.GetNonTaskDataDS(app.NON_TASK_ID, HttpContext.Current.Session("UserCode"))
                            If ds.Tables(1).Rows.Count > 0 Then

                                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1

                                    If ds.Tables(1).Rows(i)("EMP_CODE").ToString = HttpContext.Current.Session("EmpCode") Then

                                        EmpReminder = True

                                    End If

                                Next

                            End If
                            If app.NON_TASK_TYPE = "A" Then

                                If strICal(3) <> "" And EmpReminder = True Then

                                    e.Appointment.Reminders.Add(New Reminder(app.REMINDER))

                                End If

                            Else

                                If strICal(5) <> "" And EmpReminder = True Then

                                    e.Appointment.Reminders.Add(New Reminder(app.REMINDER))

                                End If

                            End If
                        End If

                    Else

                        e.Appointment.AllowDelete = True

                    End If

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf app.NON_TASK_TYPE = "H" Then

                    e.Appointment.AllowDelete = True
                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf app.NON_TASK_TYPE = "E" Then

                    clr = clrt.FromHtml(app.AD_NBR_COLOR)
                    e.Appointment.BackColor = clr
                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf app.NON_TASK_TYPE = "ET" Then

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenu"

                ElseIf app.NON_TASK_TYPE = "T" Then

                    e.Appointment.ContextMenuID = "SchedulerAppointmentContextMenuTask"

                ElseIf app.NON_TASK_TYPE = "AS" Then

                    If app.JOB_NUMBER > 0 Then
                        e.Appointment.ContextMenuID = "RadSchedulerContextMenuAssignment"
                    Else
                        e.Appointment.ContextMenuID = "RadSchedulerContextMenuAssignmentNoJob"
                    End If

                ElseIf app.NON_TASK_TYPE = "ASO" Then

                    e.Appointment.ContextMenuID = "RadSchedulerContextMenuOfficeAssignment"

                End If

                If Not app.ALL_DAY Is Nothing Then

                    e.Appointment.ToolTip = ""

                Else

                    e.Appointment.ToolTip = ""

                End If
                If app.RECURRENCE.ToString = "" Then

                    e.Appointment.Description = app.JOB_NUMBER & "|" & app.JOB_COMPONENT_NBR & "|" & app.TASK_SEQ_NBR & "|" & app.CL_CODE & "|" & app.DIV_CODE & "|" & app.PRD_CODE & "|" & app.IS_NON_TASK & "|" & app.NON_TASK_ID & "|" & app.NON_TASK_TYPE & "|" & app.ALL_DAY & "|" & app.TASK_STATUS & "|" & app.EMP_CODE & "|" & app.NUM_DAYS & "|" & app.PRIORITY & app.RESOURCE_CODE & CDate(app.START_TIME.ToString).ToString("MMM dd yyyy HH:mm tt") & app.AD_NBR & app.JOB_NUMBER.ToString.PadLeft(6, "0") & "| |" & app.RECURRENCE_PARENT & "|" & app.TASK_NON_TASK_DISPLAY & "|" & app.ALERT_ID & "|" & app.SPRINT_ID

                Else

                    e.Appointment.Description = app.JOB_NUMBER & "|" & app.JOB_COMPONENT_NBR & "|" & app.TASK_SEQ_NBR & "|" & app.CL_CODE & "|" & app.DIV_CODE & "|" & app.PRD_CODE & "|" & app.IS_NON_TASK & "|" & app.NON_TASK_ID & "|" & app.NON_TASK_TYPE & "|" & app.ALL_DAY & "|" & app.TASK_STATUS & "|" & app.EMP_CODE & "|" & app.NUM_DAYS & "|" & app.PRIORITY & app.RESOURCE_CODE & CDate(app.START_TIME.ToString).ToString("MMM dd yyyy HH:mm tt") & app.AD_NBR & app.JOB_NUMBER.ToString.PadLeft(6, "0") & "|" & app.RECURRENCE.ToString & "|" & app.RECURRENCE_PARENT & "|" & app.TASK_NON_TASK_DISPLAY & "|" & app.ALERT_ID & "|" & app.SPRINT_ID

                End If

                '''''''''''''''''''

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentInsert(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentInsertEventArgs) Handles RadSchedulerProjectSchedule.AppointmentInsert
        Try
            Session("CalendarNonTaskNo") = Nothing
            Dim strURL As String = "Calendar_NewActivity.aspx?thisdate=" & dtThisDate & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & Me._JobNumber & "&JobComponentNbr=" & Me._JobComponentNumber
            Me.OpenWindow("New Holiday/Appointment", strURL,,,,, "RefreshPage")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentUpdate(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentUpdateEventArgs) Handles RadSchedulerProjectSchedule.AppointmentUpdate

        'objects
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing

        Try
            Dim ar() As String
            ar = e.Appointment.Description.Split("|")

            Dim IsNonTask As Integer = 0
            Dim NonTaskType As String = ""
            Dim IsAllDay As Integer = 0
            Dim TaskStatus As String = ""

            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = 0
            Dim NonTaskId As Integer = 0
            Dim EmpCode As String = ""
            Dim AlertID As Integer = 0

            IsNonTask = CType(ar(6), Integer)
            NonTaskType = ar(8).ToString().Trim()
            If ar(9) <> "" Then
                IsAllDay = CType(ar(9), Integer)
            End If
            TaskStatus = ar(10).ToString().Trim()

            JobNumber = CType(ar(0), Integer)
            JobComponentNbr = CType(ar(1), Integer)
            If ar(2) <> "" Then
                SeqNbr = CType(ar(2), Integer)
            End If
            NonTaskId = CType(ar(7), Integer)
            EmpCode = ar(11).ToString().Trim()
            AlertID = CType(ar(17), Integer)

            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = JobComponentNbr
            oTask.Where.SEQ_NBR.Value = SeqNbr

            Dim NewStart As DateTime = e.ModifiedAppointment.Start ' Convert.ToDateTime(e.NewStart.ToShortDateString() & " 12:00:00 AM")
            Dim NewEnd As DateTime = Convert.ToDateTime(e.ModifiedAppointment.End.AddHours(-24).ToShortDateString() & " 12:00:00 AM")
            If IsAllDay = 1 Then
                NewEnd = Convert.ToDateTime(e.ModifiedAppointment.End.AddHours(-24).ToShortDateString() & " 12:00:00 AM")
            Else
                NewEnd = e.ModifiedAppointment.End
            End If
            Dim jobdays As Integer
            Dim daysdiff As Integer = 0
            Dim wkenddays As Integer = 0
            If e.Appointment.Start <> e.ModifiedAppointment.Start Then
                oTask.Query.Load()
                daysdiff = e.ModifiedAppointment.End.Subtract(e.ModifiedAppointment.Start).Days
                For i As Integer = 0 To daysdiff - 1
                    If e.ModifiedAppointment.Start.AddDays(i).DayOfWeek = DayOfWeek.Sunday Then
                        wkenddays += 1
                    End If
                    If e.ModifiedAppointment.Start.AddDays(i).DayOfWeek = DayOfWeek.Saturday Then
                        wkenddays += 1
                    End If
                Next
                jobdays = daysdiff - wkenddays
            ElseIf e.Appointment.End <> e.ModifiedAppointment.End Then
                If e.Appointment.End > e.ModifiedAppointment.End Then
                    daysdiff = e.Appointment.End.Subtract(e.ModifiedAppointment.End).Days
                    If oTask.Query.Load Then
                        For i As Integer = 1 To daysdiff
                            If e.Appointment.End.AddDays(-i).DayOfWeek = DayOfWeek.Sunday Then
                                wkenddays += 1
                            End If
                            If e.Appointment.End.AddDays(-i).DayOfWeek = DayOfWeek.Saturday Then
                                wkenddays += 1
                            End If
                        Next
                        jobdays = oTask.JOB_DAYS - daysdiff + wkenddays
                    End If
                ElseIf e.Appointment.End < e.ModifiedAppointment.End Then
                    daysdiff = e.ModifiedAppointment.End.Subtract(e.Appointment.End).Days
                    If oTask.Query.Load Then
                        For i As Integer = 0 To daysdiff - 1
                            If e.Appointment.End.AddDays(i).DayOfWeek = DayOfWeek.Sunday Then
                                wkenddays += 1
                            End If
                            If e.Appointment.End.AddDays(i).DayOfWeek = DayOfWeek.Saturday Then
                                wkenddays += 1
                            End If
                        Next
                        jobdays = oTask.JOB_DAYS + daysdiff - wkenddays
                    End If
                End If
            Else
                If oTask.Query.Load Then
                    jobdays = oTask.JOB_DAYS
                End If
            End If



            Dim d As New cDayPilot
            If IsNonTask = 0 Then 'a real task
                If NonTaskType = "AS" And AlertID <> 0 Then
                    Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString())
                        alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                        If alert IsNot Nothing Then
                            alert.StartDate = NewStart
                            alert.DueDate = NewEnd

                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, alert)
                        End If
                    End Using
                Else
                    Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
                    If access = 1 Then
                        If oTask.s_DUE_DATE_LOCK <> "" AndAlso oTask.DUE_DATE_LOCK = 1 Then
                            e.Cancel = True
                            Me.ShowMessage("Task is locked and cannot be edited.")
                        Else
                            d.Task_UpdateDates(JobNumber, JobComponentNbr, SeqNbr, NewStart, NewEnd, Session("UserCode"), jobdays)
                        End If
                    Else

                        e.Cancel = True
                        Me.ShowMessage("You do not have permission to edit tasks")

                    End If
                End If
            ElseIf IsNonTask = 1 Then 'a holiday or appointment
                Dim m As String = ""
                m = d.NonTask_UpdateDates(NonTaskId, NewStart, NewEnd, True)
                If m <> "" Then
                    Me.ShowMessage(m)
                Else
                    Me.CalendarSync(NonTaskId, (NonTaskType = "H"), False)
                End If
            ElseIf IsNonTask = 2 Then 'an event
                Dim Original_Start As DateTime = e.Appointment.Start
                Dim Original_End As DateTime = e.Appointment.End
                Dim New_Start As DateTime = e.ModifiedAppointment.Start
                Dim New_End As DateTime = e.ModifiedAppointment.End
                Dim EventId As Integer = NonTaskId
                Dim m As String = ""
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    New_End = Convert.ToDateTime(e.ModifiedAppointment.End.AddHours(-24).ToShortDateString() & " 12:00:00 AM")
                    m = d.Event_UpdateDates(EventId, New_Start, New_End, False, Session("UserCode"))
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView Or Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.DayView Then
                    m = d.Event_UpdateDates(EventId, New_Start, New_End, True, Session("UserCode"))
                Else
                    m = d.Event_UpdateDates(EventId, New_Start, New_End, False, Session("UserCode"))
                End If
                If m <> "" Then
                    Me.ShowMessage(m)
                End If
            ElseIf IsNonTask = 3 Then 'an event task
                Dim Original_Start As DateTime = e.Appointment.Start
                Dim Original_End As DateTime = e.Appointment.End
                Dim New_Start As DateTime = e.ModifiedAppointment.Start
                Dim New_End As DateTime = e.ModifiedAppointment.End
                Dim EventTaskId As Integer = NonTaskId
                Dim m As String = ""
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    New_End = Convert.ToDateTime(e.ModifiedAppointment.End.AddHours(-24).ToShortDateString() & " 12:00:00 AM")
                    m = d.EventTask_UpdateDates(EventTaskId, New_Start, New_End, False, Session("UserCode"))
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView Or Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.DayView Then
                    m = d.EventTask_UpdateDates(EventTaskId, New_Start, New_End, True, Session("UserCode"))
                Else
                    m = d.EventTask_UpdateDates(EventTaskId, New_Start, New_End, False, Session("UserCode"))
                End If
                If m <> "" Then
                    Me.ShowMessage(m)
                End If
            End If

            If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                MiscFN.ResponseRedirect("Calendar_MonthView.aspx?tab=0")
            Else
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_AppointmentDelete(ByVal sender As Object, ByVal e As Telerik.Web.UI.AppointmentDeleteEventArgs) Handles RadSchedulerProjectSchedule.AppointmentDelete

        'objects
        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim SyncWithOutlook As Boolean = False
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim save As Boolean = False
        Dim str() As String = e.Appointment.Description.Split("|")
        Dim IsHoliday As Boolean = False
        Dim SqlDataReader As SqlClient.SqlDataReader = Nothing

        Try

            str = e.Appointment.Description.Split("|")

            If str(14) = " " And str(15) = "0" Then

                Try

                    SqlDataReader = oCalendar.GetNonTaskData(str(7), _Session.UserCode)

                    While SqlDataReader.Read

                        If SqlDataReader.GetString(1) = "H" Then

                            IsHoliday = True

                        ElseIf SqlDataReader.GetString(1) = "A" Then

                            IsHoliday = False

                        End If

                    End While

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString())

                        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, str(7))

                    End Using

                Catch ex As Exception

                End Try

                save = oCalendar.DeleteTask(str(7))

                If save = True Then
                    'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), EmployeeNonTask, IsHoliday, True)

                    If EmployeeNonTask IsNot Nothing Then

                        Session("EmployeeNonTask_CalendarObject") = EmployeeNonTask.ID
                        Me.CalendarSync(EmployeeNonTask.ID, IsHoliday, True)

                        Session("TaskCalendarSelectedDate") = e.Appointment.Start

                    End If

                Else

                    Me.ShowMessage("Delete Failed.")

                End If

            End If

        Catch ex As Exception
            Response.Write("Error with Deleting Task: " & ex.Message.ToString())
        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_FormCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerFormCreatedEventArgs) Handles RadSchedulerProjectSchedule.FormCreated
        Try
            Select Case e.Container.Mode
                Case SchedulerFormMode.Edit
                    e.Container.Visible = False
                Case SchedulerFormMode.Insert
                    e.Container.Visible = False
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_NavigationCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.SchedulerNavigationCommandEventArgs) Handles RadSchedulerProjectSchedule.NavigationCommand
        Try
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            If oAppVars.HasAppVar("tcal_groupby") = False Then
                RadToolBarButtonGroupBy.Text = "Group by Job"
            Else
                If oAppVars.getAppVar("tcal_groupby") = "emp" Then
                    RadToolBarButtonGroupBy.Text = "Group by Job"
                Else
                    RadToolBarButtonGroupBy.Text = "Group by Employee"
                End If
            End If
            If e.Command = Telerik.Web.UI.SchedulerNavigationCommand.NavigateToNextPeriod Then
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.MonthView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddMonths(1), Me.RadSchedulerProjectSchedule.SelectedView)
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(14), Me.RadSchedulerProjectSchedule.SelectedView, 1)
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(6), Me.RadSchedulerProjectSchedule.SelectedView)
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(1), Me.RadSchedulerProjectSchedule.SelectedView)
                End If
            End If
            If e.Command = Telerik.Web.UI.SchedulerNavigationCommand.NavigateToPreviousPeriod Then
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.MonthView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddMonths(-1), Me.RadSchedulerProjectSchedule.SelectedView)
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(-14), Me.RadSchedulerProjectSchedule.SelectedView, 1)
                ElseIf Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.WeekView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(-6), Me.RadSchedulerProjectSchedule.SelectedView)
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate.AddDays(-1), Me.RadSchedulerProjectSchedule.SelectedView)
                End If
            End If
            If e.Command = SchedulerNavigationCommand.NavigateToSelectedDate Then
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(e.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
                Else
                    LoadScheduler(e.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
                End If
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToTimelineView Then
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "T", 1)
                If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                    Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(45)
                Else
                    Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(25)
                End If
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToMonthView Then
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToWeekView Then
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "W")
                Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToDayView Then
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "D")
                Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(25)
            End If
            If e.Command = SchedulerNavigationCommand.SwitchToSelectedDay Then
                Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.DayView
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(e.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
                Else
                    LoadScheduler(e.SelectedDate, "D")
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    <Serializable()> Public Class EmployeeImage
        Public Property EMP_PICTURE_ID As Integer? = 0
        Public Property EMP_CODE As String = String.Empty
        Public Property EMP_IMAGE As Byte()
        Public Property EMP_NAME As String = String.Empty
        Public Property EMP_FNAME As String = String.Empty
        Public Property EMP_MI As String = String.Empty
        Public Property EMP_LNAME As String = String.Empty
        Public Property EMP_NICKNAME As String = String.Empty
        Public Property EMP_WALLPAPER As Byte()
        Sub New()

        End Sub
    End Class
    Public Property EmployeeImages As Generic.List(Of EmployeeImage) = Nothing

    Private Sub RadSchedulerProjectSchedule_ResourceHeaderCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.ResourceHeaderCreatedEventArgs) Handles RadSchedulerProjectSchedule.ResourceHeaderCreated
        Try

            If EmployeeImages Is Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        EmployeeImages = DbContext.Database.SqlQuery(Of EmployeeImage)(String.Format("EXEC [dbo].[usp_wv_GetEmpProfileData] '', '{0}';",
                                                                                                     Me._Session.UserCode)).ToList()

                    End Using

                Catch ex As Exception
                    EmployeeImages = Nothing
                End Try

            End If

            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            GroupBy = oAppVars.getAppVar("tcal_groupby")
            If GroupBy = "" Then
                GroupBy = "emp"
            End If

            Dim labEmp As System.Web.UI.WebControls.Label = TryCast(e.Container.FindControl("LabelEmployee"), Label)
            Dim labJob As System.Web.UI.WebControls.Label = TryCast(e.Container.FindControl("LabelJob"), Label)
            Dim panelEmp As Panel = TryCast(e.Container.FindControl("ResourceImageWrapperEmp"), Panel)
            Dim panelJob As Panel = TryCast(e.Container.FindControl("ResourceImageWrapperJob"), Panel)

            If e.Container.Resource.Text <> "N/A" Then
                If GroupBy = "emp" Then

                    panelJob.Visible = False

                    Dim img As DevExpress.Web.ASPxBinaryImage = TryCast(e.Container.FindControl("ASPxBinaryImageEmp"), DevExpress.Web.ASPxBinaryImage)
                    Dim img2 As DevExpress.Web.ASPxImage = TryCast(e.Container.FindControl("ASPxImageEmp"), DevExpress.Web.ASPxImage)
                    Dim EmpText() As String = e.Container.Resource.Text.Split("-")
                    Dim cEmp As New cEmployee(Session("ConnString"))
                    Dim CurrentEmployee As EmployeeImage = Nothing

                    If EmployeeImages IsNot Nothing Then 'Let's not call DB query on every loop iterartion plz!

                        CurrentEmployee = Nothing

                        Try

                            CurrentEmployee = (From Entity In EmployeeImages
                                               Where Entity.EMP_CODE = EmpText(0).Trim()).SingleOrDefault

                        Catch ex As Exception
                            CurrentEmployee = Nothing
                        End Try

                        If CurrentEmployee IsNot Nothing Then

                            If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then

                                If CurrentEmployee.EMP_IMAGE IsNot Nothing Then

                                    Dim FileBytes() As Byte = CurrentEmployee.EMP_IMAGE
                                    img.Value = FileBytes

                                Else

                                    img.Visible = False
                                    img2.Visible = True

                                End If

                            Else

                                img.Visible = False

                            End If
                            If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then

                                labEmp.Text = CurrentEmployee.EMP_FNAME

                            ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then

                                labEmp.Text = CurrentEmployee.EMP_NAME

                            Else

                                labEmp.Text = CurrentEmployee.EMP_FNAME '& " " & CurrentEmployee.EMP_LNAME.ToString().Substring(0, 1) & "."

                            End If

                        End If

                    Else

                        Dim dr As SqlClient.SqlDataReader = cEmp.GetEmployeeProfile(EmpText(0).Trim)
                        If dr.HasRows Then
                            dr.Read()
                            If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                                If IsDBNull(dr("EMP_IMAGE")) = False Then
                                    Dim FileBytes() As Byte = CType(dr("EMP_IMAGE"), Byte())
                                    img.Value = FileBytes
                                Else
                                    img.Visible = False
                                    img2.Visible = True
                                End If
                            Else
                                img.Visible = False
                            End If
                            If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then
                                labEmp.Text = dr("EMP_FNAME")
                            ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then
                                labEmp.Text = dr("EMP_NICKNAME")
                            Else
                                labEmp.Text = dr("EMP_FNAME")
                            End If
                            dr.Close()
                        End If

                    End If

                ElseIf GroupBy = "job" Then
                    panelEmp.Visible = False
                    If e.Container.Resource.Text = "-1/-1" Then
                        labJob.Text = "N/A"
                    Else
                        labJob.Text = e.Container.Resource.Text
                    End If
                Else
                    'lab.Text = e.Container.Resource.Text
                End If
            Else
                panelJob.Visible = False
                labEmp.Text = e.Container.Resource.Text
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_ReminderDismiss(sender As Object, e As ReminderDismissEventArgs) Handles RadSchedulerProjectSchedule.ReminderDismiss
        Try
            Dim str() As String = e.Appointment.Description.Split("|")
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString())

                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, str(7))

                EmployeeNonTask.Reminder = Nothing

                AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask)

            End Using


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadSchedulerProjectSchedule_ReminderSnooze(sender As Object, e As ReminderSnoozeEventArgs) Handles RadSchedulerProjectSchedule.ReminderSnooze
        Try
            Dim str() As String = e.Appointment.Description.Split("|")
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString())

                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, str(7))

                If e.SnoozeMinutes < 0 Then
                    EmployeeNonTask.Reminder = e.SnoozeMinutes * -1
                Else
                    EmployeeNonTask.Reminder = e.Reminder.Trigger.TotalMinutes - e.SnoozeMinutes
                End If

                AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask)

            End Using


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadToolbarCalendar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCalendar.ButtonClick

        'objects
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        SetAppVarsApplication()

        Select Case e.Item.Value
            Case "NewTask"
                Session("CalendarNonTaskNo") = Nothing
                Dim strURL As String = "Calendar_NewActivity.aspx?thisdate=" & dtThisDate & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & Me._JobNumber & "&JobComponentNbr=" & Me._JobComponentNumber
                Me.OpenWindow("New Holiday/Appointment", strURL, 550, 1000,,, "RefreshPage")
            Case "ExportCalendar"
                If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
                End If
                Me.ExportCalendarItems()
            Case "ExportPDF"
                Me.RadSchedulerProjectSchedule.MonthView.VisibleAppointmentsPerDay = 30
                Me.RadSchedulerProjectSchedule.ExportToPdf()
            Case "PrintCalendar"
                Try
                    Dim NonTaskType As String = ""
                    If Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = True Then
                        NonTaskType = ""
                    ElseIf Me.CheckBoxIncludeHolidays.Checked = True And Me.CheckBoxIncludeAppointments.Checked = False Then
                        NonTaskType = "H"
                    ElseIf Me.CheckBoxIncludeHolidays.Checked = False And Me.CheckBoxIncludeAppointments.Checked = True Then
                        NonTaskType = "A"
                    Else
                        NonTaskType = "N"
                    End If

                    Duration = BoolToNum(CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean))
                    If Duration = -1 Then
                        Duration = 0
                    End If

                    Session("CalendaReportPrintApp") = Request.QueryString("FromApp")

                    If Request.QueryString("FromApp") = "PS" Then

                        Session("CalendaReportPrintJob") = Me._JobNumber
                        Session("CalendaReportPrintComp") = Me._JobComponentNumber

                    End If

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.Page = "Calendar_Report.aspx"
                    'qs.Page = "Calendar_QuickPrint.aspx"
                    qs.Add("Date", dtThisDate)
                    qs.Add("FromApp", Request.QueryString("FromApp"))
                    qs.Add("JobNum", Me._JobNumber)
                    qs.Add("JobCompNum", Me._JobComponentNumber)
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.Add("view", calView)
                    qs.Add("nontasktype", NonTaskType)
                    qs.Add("duration", Duration)
                    qs.Add("mode", "print")

                    Me.OpenPrintSendSilently(qs)

                    'Me.OpenWindow("Calendar Print", qs.ToString(True), 300, 700)

                Catch ex As Exception
                    MemoryStream = Nothing
                End Try
            Case "GroupBy"
                If e.Item.Text = "Group by Job" Then
                    Me.GroupBy = "job"
                    oAppVars.setAppVarDB("tcal_groupby", "job")
                    e.Item.Text = "Group by Employee"
                ElseIf e.Item.Text = "Group by Employee" Then
                    Me.GroupBy = "emp"
                    oAppVars.setAppVarDB("tcal_groupby", "emp")
                    e.Item.Text = "Group by Job"
                End If
            Case "Duration"
                If e.Item.Text = "Duration View" Then
                    Me.Duration = 1
                    oAppVars.setAppVarDB("tcal_duration", 1)
                    e.Item.Text = "Due Date View"
                ElseIf e.Item.Text = "Due Date View" Then
                    Me.Duration = 0
                    oAppVars.setAppVarDB("tcal_duration", 0)
                    e.Item.Text = "Duration View"
                End If
            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                qs.Page = "Calendar_MonthView.aspx"

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Calendar
                    .UserCode = Session("UserCode")
                    .Name = "Calendar"
                    .Description = "Calendar"
                    .PageURL = qs.ToString(True)

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    ' Me.RefreshBookmarksDesktopObject()

                End If

            Case "RefreshCalendar"

        End Select
        If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
        Else
            LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
        End If

    End Sub

    Private Sub txtAssignments_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAssignments.TextChanged
        Try
            SetAppVarsApplication()
            oAppVars.setAppVarDB("tcal_appts", Me.txtAssignments.Text)
            If Me.RadSchedulerProjectSchedule.SelectedView = SchedulerViewType.TimelineView Then
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView, 1)
            Else
                LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, Me.RadSchedulerProjectSchedule.SelectedView)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadTabStripTaskCalendar_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripTaskCalendar.TabClick
        Try
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            'List view
            If e.Tab.Value = "0" Then
                If Not Me.CalendarPage Is Nothing Then
                    If Me.CalendarPage = "Week" Then
                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "W")
                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)
                    End If
                    If Me.CalendarPage = "Day" Then
                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "D")
                    End If
                    If Me.CalendarPage = "Timeline" Then
                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "T", 1)
                        If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                            Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(45)
                        Else
                            Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(25)
                        End If
                        Me.RadToolBarButtonGroupBy.Visible = True
                    End If
                    If Me.CalendarPage = "Month" Then
                        LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                        Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)
                    End If
                Else
                    LoadScheduler(Me.RadSchedulerProjectSchedule.SelectedDate, "M")
                    Me.RadSchedulerProjectSchedule.RowHeight = Unit.Pixel(35)
                End If
            End If
            If e.Tab.Value = "1" Then
                LoadCalendarListView()
            End If
            'Workload
            If e.Tab.Value = "2" Then
                Me.RadGridWorkload.Rebind()
            End If
            'Availability
            If e.Tab.Value = "3" Then

                Me.txtTasks.Visible = False
                Me.TextBox1.Visible = False
                Me.TextBox6.Visible = False
                Me.TextBox7.Visible = False
                Me.TextBoxAllocationTasks.Visible = False
                Me.TextBoxAllocationAppointments.Visible = False
                Me.TextBoxAllocationHours.Visible = False
                Me.TextBoxAllocationEvent.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False
                Me.Label11.Visible = False
                Me.Label19.Visible = False
                Me.LabelAllocationTasks.Visible = False
                Me.LabelAllocationAppointments.Visible = False
                Me.LabelAllocationHours.Visible = False
                Me.LabelAllocationEvent.Visible = False
                Me.RblAvailabilitySummaryLevel.Items(1).Selected = True
                LoadEmployeeList()
                LoadTasks()
                LoadLegend()
                oAppVars.setAppVar("Assignments", "True", "Boolean")
                oAppVars.setAppVar("Available", "True", "Boolean")
                oAppVars.SaveAllAppVars()

                EnableOrDisableAvailabilityOptions()

            End If

            'Allocation
            If e.Tab.Value = "6" Then

                Me.txtTasks.Visible = False
                Me.TextBox1.Visible = False
                Me.TextBox6.Visible = False
                Me.TextBox7.Visible = False
                Me.TextBoxAllocationTasks.Visible = False
                Me.TextBoxAllocationAppointments.Visible = False
                Me.TextBoxAllocationHours.Visible = False
                Me.TextBoxAllocationEvent.Visible = False
                Me.Label1.Visible = False
                Me.Label2.Visible = False
                Me.Label11.Visible = False
                Me.Label19.Visible = False
                Me.LabelAllocationTasks.Visible = False
                Me.LabelAllocationAppointments.Visible = False
                Me.LabelAllocationHours.Visible = False
                Me.LabelAllocationEvent.Visible = False
                Me.RadioButtonListAllocationLevel.Items(1).Selected = True
                LoadEmployeeList()
                LoadTasks()
                oAppVars.setAppVar("Assignments", "True", "Boolean")
                oAppVars.setAppVar("Available", "True", "Boolean")
                oAppVars.SaveAllAppVars()

                EnableOrDisableAllocationOptions()

                Me.CollapsablePanel1.TitleText = "&nbsp;&nbsp;&nbsp;&nbsp;Allocation for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
                    Me.RadDatePickerAllocationStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
                Else
                    Me.RadDatePickerAllocationStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
                End If

                If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
                    Me.RadDatePickerAllocationEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
                Else
                    Me.RadDatePickerAllocationEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
                End If
            End If
            'Actualization
            If e.Tab.Value = "7" Then

                Me.txtTasksAct.Visible = False
                Me.TextBox3.Visible = False
                Me.TextBox4.Visible = False
                Me.TextBox5.Visible = False
                Me.TextBoxAllocationTasks.Visible = False
                Me.TextBoxAllocationAppointments.Visible = False
                Me.TextBoxAllocationHours.Visible = False
                Me.TextBoxAllocationEvent.Visible = False
                Me.Label20.Visible = False
                Me.Label21.Visible = False
                Me.Label22.Visible = False
                Me.Label23.Visible = False
                Me.LabelAllocationTasks.Visible = False
                Me.LabelAllocationAppointments.Visible = False
                Me.LabelAllocationHours.Visible = False
                Me.LabelAllocationEvent.Visible = False
                Me.RblAvailabilitySummaryLevel.Items(1).Selected = True
                LoadEmployeeListAct()
                LoadTasksAct()
                LoadLegendAct()
                oAppVars.setAppVar("Assignments", "True", "Boolean")
                oAppVars.setAppVar("Available", "True", "Boolean")
                oAppVars.SaveAllAppVars()

                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String

                Try
                    If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning") <> "" Then
                        Me.CheckBoxOmit.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning"), Boolean)
                    End If
                    If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent") <> "" Then
                        Me.CheckBoxShowPercent.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent"), Boolean)
                    End If
                Catch ex As Exception

                End Try
                EnableOrDisableActualizationOptions()

                Me.CollapsablePanel2.TitleText = "&nbsp;&nbsp;&nbsp;&nbsp;Availability for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

            End If
            'Filter
            If e.Tab.Value = "4" Then

                SetLookUps()

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Calendar)
                Dim oReports As New cReports(Session("ConnString"))
                Dim str As String = oReports.GetManagerLabel(Session("UserCode"))

                If str <> "" Or Not str Is Nothing Then

                    Me.hlManager.Text = str & ":"

                End If

                SetLookUps()
                LoadLengths()
                LoadDeptList()

                Me.LoadRoles(Me.LbRoles)
                Me.LoadRoles(Me.lbFunctionRoles)
                LoadSettings()
                LoadTasksFilter(oAppVars.getAppVar("tcal_emp"))

                Me.FocusControl(Me.txtOffice)
                Page.Form.DefaultButton = Me.butSave.UniqueID

                If Me.IsClientPortal = True Then

                    Me.DivOffice.Visible = False
                    Me.DivClient.Visible = False
                    Me.DivManager.Visible = False
                    Me.DivTrafficStatus.Visible = False
                    Me.DivTaskStatus.Visible = False
                    Me.DivRoles.Visible = False
                    Me.DivDepartment.Visible = False
                    Me.DivEmployeeCode.Visible = False

                    Me.FieldSetDateRange.Visible = False
                    Me.PanelEmployee.Visible = False
                    Me.DivDisplayEmployeeOptions.Visible = False

                    Me.chkClientCode.Visible = False
                    Me.chkClientDesc.Visible = False
                    Me.chkEmpCodeDispl.Visible = False
                    Me.chkEmpDescDispl.Visible = False
                    Me.chkHoursAllowed.Visible = False

                    Me.DivNonClientPortalSettings.Visible = False

                End If

            End If

            'Report
            If e.Tab.Value = "5" Then

                Session("CalendaReportPrintApp") = Request.QueryString("FromApp")

                If Request.QueryString("FromApp") = "PS" Then

                    Session("CalendaReportPrintJob") = Me._JobNumber
                    Session("CalendaReportPrintComp") = Me._JobComponentNumber

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    'Private Sub RadSchedulerProjectSchedule_AppointmentCreated(sender As Object, e As AppointmentCreatedEventArgs) Handles RadSchedulerProjectSchedule.AppointmentCreated
    '    Try
    '        Dim label As Label = e.Container.FindControl("LabelTaskDescription")
    '        Dim label2 As Label = e.Container.FindControl("LabelHeaderText")
    '        Dim str() As String = e.Appointment.Description.Split("|")
    '        If str(8).ToString = "TD" Then
    '            label.Text = "To Do"
    '        ElseIf str(8).ToString = "C" Then
    '            label.Text = "Call"
    '        ElseIf str(8).ToString = "M" Then
    '            label.Text = "Meeting"
    '        ElseIf str(8).ToString = "T" Or str(8).ToString = "A" Or str(8).ToString = "H" Then
    '            label.Text = str(16)
    '        End If

    '        label2.Text = e.Appointment.Subject

    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region "List View"

    Private Sub LoadCalendarListView()
        Try
            SetAppVarsApplication()
            Dim intDaysInMonth As Integer
            Try
                'SetSessionDefaults()
            Catch ex As Exception
            End Try

            oAppVars.getAllAppVars()

            'Me.ShowDuration = Session("tcal_duration")
            Try
                Me.ShowDuration = oAppVars.getAppVar("tcal_duration")
            Catch ex As Exception
                Me.ShowDuration = False
            End Try

            Dim strEmpCode As String = ""

            If Not Session("TaskCalendarSelectedDate") Is Nothing Then
                dtThisDate = CType(Session("TaskCalendarSelectedDate"), Date)
            Else
                dtThisDate = Today.Date
            End If
            'If oAppVars.getAppVar("TaskCalendarSelectedDate", "Date") <> "1/1/1900" Then
            '    dtThisDate = CType(oAppVars.getAppVar("TaskCalendarSelectedDate", "Date"), Date)
            'Else
            '    dtThisDate = Today.Date
            'End If

            Dim dStart As Date
            Dim dEnd As Date

            'Select Case Session("CalView")
            Select Case Me.CalendarPage

                Case "Month" 'month
                    intDaysInMonth = dtThisDate.DaysInMonth(dtThisDate.Year, dtThisDate.Month)
                    'dStart = CDate(CStr(dtThisDate.Month) & "/" & CStr(1) & "/" & CStr(dtThisDate.Year))
                    'dEnd = CDate(CStr(dtThisDate.Month) & "/" & CStr(intDaysInMonth) & "/" & CStr(dtThisDate.Year))
                    dStart = LoGlo.FirstOfMonth(dtThisDate)
                    dEnd = LoGlo.LastOfMonth(dtThisDate)
                    Me.PageTitle = "Month of: " & dStart.ToString("MMMM") & " " & dStart.ToString("yyyy")
                Case "Week"
                    dStart = DayPilot.Utils.Week.FirstDayOfWeek(dtThisDate)
                    dEnd = dStart.AddDays(6)
                    Me.PageTitle = "Week of: " & dStart.ToLongDateString() & " - " & dEnd.ToLongDateString()
                Case "Day"
                    dStart = dtThisDate
                    dEnd = dtThisDate
                    Me.PageTitle = "Day of: " & dStart.ToLongDateString()
                Case "Timeline"
                    dStart = dtThisDate
                    dEnd = dtThisDate.AddDays(13)
                    Me.PageTitle = "Timeline of: " & dStart.ToLongDateString() & " - " & dEnd.ToLongDateString()
                Case Else
                    dStart = dtThisDate
                    dEnd = dtThisDate
                    Me.PageTitle = "Day of: " & dStart.ToLongDateString()
            End Select

            Dim sStart As String = dStart.ToShortDateString()
            Dim sEnd As String = dEnd.ToShortDateString()

            Dim Dt As New DataTable
            Dim c As New cDayPilot()

            If Request.QueryString("FromApp") = "PS" Then
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         Me._JobNumber,
                                         Me._JobComponentNumber,
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         True,
                                         True,
                                         True,
                                         True,
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"),
                                         sStart,
                                         sEnd, False, False, oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"),
                                         Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), oAppVars.getAppVar("tcal_includeunassigned"))
            Else
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         oAppVars.getAppVar("tcal_jobno"),
                                         oAppVars.getAppVar("tcal_jobcomp"),
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         True,
                                         True,
                                         True,
                                         True,
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"),
                                         sStart,
                                         sEnd, False, False, oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"),
                                         Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"), oAppVars.getAppVar("tcal_includeunassigned"))

            End If
            Dim rg As RadGrid
            'dataviews to bind separate repeaters
            If Dt.Rows.Count > 0 Then
                Dim DvTasks As DataView = New DataView(Dt)
                Dim DvAssignments As DataView = New DataView(Dt)
                Dim DvApptHolidays As DataView = New DataView(Dt)
                Dim DvEvents As DataView = New DataView(Dt)
                Dim DvEventTasks As DataView = New DataView(Dt)

                DvTasks.RowFilter = "(IS_NON_TASK = 0 AND NON_TASK_TYPE <> 'ASO')"
                'DvAssignments.RowFilter = "IS_NON_TASK = 0 AND NON_TASK_TYPE = 'AS'"
                DvApptHolidays.RowFilter = "(IS_NON_TASK = 1 OR NON_TASK_TYPE = 'ASO')"
                DvEvents.RowFilter = "IS_NON_TASK = 2"
                DvEventTasks.RowFilter = "IS_NON_TASK = 3"

                'bind to repeaters
                Dim bHasData As Boolean = False
                Try
                    If DvTasks.ToTable().Rows.Count > 0 Then
                        Me.RadGridTasks.DataSource = DvTasks
                        Me.RadGridTasks.DataBind()
                        'Me.RptrTasks.DataSource = DvTasks
                        'Me.RptrTasks.DataBind()
                        bHasData = True
                        Me.PanelTasks.Visible = True
                    Else
                        Me.PanelTasks.Visible = False
                        'Me.RptrTasks.Visible = False
                    End If
                Catch ex As Exception
                End Try
                'Try
                '    If DvAssignments.ToTable().Rows.Count > 0 Then
                '        Me.RadGridListViewAssignments.DataSource = DvAssignments
                '        Me.RadGridListViewAssignments.DataBind()
                '        'Me.RptrTasks.DataSource = DvTasks
                '        'Me.RptrTasks.DataBind()
                '        bHasData = True
                '        Me.PanelAssignments.Visible = True
                '    Else
                '        Me.PanelAssignments.Visible = False
                '        'Me.RptrTasks.Visible = False
                '    End If
                'Catch ex As Exception
                'End Try
                Try
                    If DvApptHolidays.ToTable().Rows.Count > 0 Then
                        Me.RadGridAppointmentHolidays.DataSource = DvApptHolidays
                        Me.RadGridAppointmentHolidays.DataBind()
                        'Me.RptrAppointmentsHolidays.DataSource = DvApptHolidays
                        'Me.RptrAppointmentsHolidays.DataBind()
                        bHasData = True
                        Me.PanelAppointmentHolidays.Visible = True
                    Else
                        Me.PanelAppointmentHolidays.Visible = False
                        'Me.RptrAppointmentsHolidays.Visible = False
                    End If
                Catch ex As Exception
                End Try
                Try
                    If DvEvents.ToTable().Rows.Count > 0 Then
                        Me.RadGridEvents.DataSource = DvEvents
                        Me.RadGridEvents.DataBind()
                        'Me.RptrEvents.DataSource = DvEvents
                        'Me.RptrEvents.DataBind()
                        bHasData = True
                        Me.PanelEvents.Visible = True
                    Else
                        Me.PanelEvents.Visible = False
                        'Me.RptrEvents.Visible = False
                    End If
                Catch ex As Exception
                End Try
                Try
                    If DvEventTasks.ToTable().Rows.Count > 0 Then
                        Me.RadGridEventTasks.DataSource = DvEventTasks
                        Me.RadGridEventTasks.DataBind()
                        'Me.RptrEventTask.DataSource = DvEventTasks
                        'Me.RptrEventTask.DataBind()
                        bHasData = True
                        Me.PanelEventTasks.Visible = True
                    Else
                        Me.PanelEventTasks.Visible = False
                        'Me.RptrEventTask.Visible = False
                    End If
                Catch ex As Exception
                End Try
                'Me.NoDataHTMLTable(bHasData)
            Else
                Me.PanelTasks.Visible = False
                'Me.PanelAssignments.Visible = False
                Me.PanelEventTasks.Visible = False
                Me.PanelAppointmentHolidays.Visible = False
                Me.PanelEvents.Visible = False
                'Me.NoDataHTMLTable(False)
            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
    Public Function SetColor(ByVal RecType As Object) As String
        Try
            Select Case RecType.ToString()
                Case "M", "TD", "C", "EL"
                    Return "#78A1CA" '"#BBD0EC"
                Case "A", "ASO"
                    Return "#F2D9A8"
                Case "H"
                    Return "#F5C7A1"
                Case Else
                    Return "#FFFFFF"
            End Select
        Catch ex As Exception
            Return "#FFFFFF"
        End Try
    End Function
    Public Function SetEventColor(ByVal HexCode As Object) As String
        Try
            If HexCode.ToString().Length = 7 Then 'valid ad number color
                Return HexCode.ToString()
            Else 'set to white
                Return "#FFFFFF"
            End If
        Catch ex As Exception
            Return "#FFFFFF"
        End Try
    End Function
    Public Function SetEventTaskColor() As String
        Return "#FFFFFF"
    End Function
    Public Function SetDate(ByVal IsAllDay As String, ByVal DayCount As String, ByVal HasTime As String, ByVal TheStartDate As String, ByVal TheEndDate As String) As String
        Try
            'If CType(IsAllDay, Integer) = 1 Then
            '    Return CType(TheEndDate, Date).ToShortDateString
            'ElseIf CType(DayCount, Integer) > 1 Then
            '    If (CType(TheStartDate, Date).ToShortDateString = CType(TheEndDate, Date).ToShortDateString) And (CType(TheStartDate, Date).ToShortTimeString <> CType(TheEndDate, Date).ToShortTimeString) Then
            '        Return CType(TheStartDate, Date).ToShortDateString & " " & CType(TheStartDate, Date).ToShortTimeString & " - " & CType(TheEndDate, Date).ToShortTimeString
            '    Else
            '        Return CType(TheStartDate, Date).ToShortDateString & " " & CType(TheStartDate, Date).ToShortTimeString & " - " & CType(TheEndDate, Date).ToShortDateString & " " & CType(TheEndDate, Date).ToShortTimeString
            '    End If
            'Else
            '    Return TheEndDate
            'End If
            Dim ThisHasTime As Boolean = False
            If IsNumeric(HasTime) = True Then
                If CType(HasTime, Integer) = 1 Then
                    ThisHasTime = True
                End If
            End If
            Dim ThisIsAllDay As Boolean = False
            If IsNumeric(IsAllDay) = True Then
                If CType(IsAllDay, Integer) = 1 Then
                    ThisIsAllDay = True
                End If
            End If
            Dim ThisDayCount As Integer = 0
            If IsNumeric(ThisDayCount) = True Then
                ThisDayCount = CType(DayCount, Integer)
            End If
            Dim ThisStartDate As Date = CType(TheStartDate, Date)
            Dim ThisEndDate As Date = CType(TheEndDate, Date)

            Dim sb As New System.Text.StringBuilder
            With sb
                If Me.ShowDuration = True Then


                    If ThisHasTime = True Then
                        If ThisDayCount > 1 And ThisIsAllDay = False Then
                            .Append(ThisStartDate.ToShortDateString)
                            .Append(" ")
                            .Append(ThisStartDate.ToShortTimeString)
                            .Append(" - ")
                            .Append(ThisEndDate.ToShortDateString)
                            .Append(" ")
                            .Append(ThisEndDate.ToShortTimeString)
                        Else
                            .Append(ThisStartDate.ToShortDateString)
                            .Append(" ")
                            .Append(ThisStartDate.ToShortTimeString)
                            .Append(" - ")
                            .Append(ThisEndDate.ToShortTimeString)
                        End If
                    Else
                        If ThisDayCount > 1 Then
                            .Append(ThisStartDate.ToShortDateString)
                            .Append(" - ")
                            .Append(ThisEndDate.ToShortDateString)
                        Else
                            .Append(ThisEndDate.ToShortDateString)
                        End If
                    End If


                Else


                    If ThisHasTime = True Then
                        .Append(ThisEndDate.ToShortDateString)
                        .Append(" ")
                        .Append(ThisEndDate.ToShortTimeString)
                    Else
                        .Append(ThisEndDate.ToShortDateString)
                    End If



                End If
            End With

            Return sb.ToString()

        Catch ex As Exception
            Return TheEndDate
        End Try
    End Function
    Public Shared Function SetTextCSS(ByVal TheDataKey As Object) As String
        Try
            Dim ar() As String
            ar = TheDataKey.ToString().Split("|")
            Dim TaskStatus As String = ""
            TaskStatus = ar(4).ToString().Trim()
            Select Case TaskStatus
                Case "A"
                    Return "calendarActive"
                Case "P"
                    Return "calendarPending"
                Case "N"
                    Return "calendarNormal"
                Case Else
                    Return "calendarRowBorderBottom"
            End Select
        Catch ex As Exception
            Return "calendarRowBorderBottom"
        End Try
    End Function
    Private Sub RadGridTasks_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTasks.ItemCommand
        Try
            Select Case e.CommandName
                Case "DetailRow"
                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                    Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                    Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                    'If dataItem.GetDataKeyValue("REC_TYPE").ToString = "Assignment" Then

                    QsViewDetails.Page = "Desktop_AlertView"
                    QsViewDetails.Add("AlertID", dataItem.GetDataKeyValue("ALERT_ID").ToString)
                    QsViewDetails.Add("SprintID", dataItem.GetDataKeyValue("SPRINT_ID").ToString)
                    Me.OpenWindow(dataItem("colTask").Text.Replace("'", "\'"), QsViewDetails.ToString(True))

                    'Else

                    'Dim strURL As String = "TrafficSchedule_TaskDetail.aspx?pop=1&form=" + datakey(0) + "&JobNum=" + datakey(5) + "&JobComp=" + datakey(6) + "&SeqNum=" + datakey(7) + "&EmpCode=" + datakey(9) + "&Client=" + datakey(10) + "&Division=" + datakey(11) + "&Product=" + datakey(12) + "&tab=3"
                    'Me.OpenWindow(dataItem("colTask").Text, strURL)

                    'End If

                    CalendarPageView = 1
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridTasks_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTasks.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                dataItem("colSTART_DATE").Text = Me.SetDate(dataItem.GetDataKeyValue("ALL_DAY"), dataItem.GetDataKeyValue("NUM_DAYS"), dataItem.GetDataKeyValue("HAS_TIME"), dataItem.GetDataKeyValue("START_TIME"), dataItem.GetDataKeyValue("END_TIME"))
                'dataItem.CssClass = SetTextCSS(dataItem.GetDataKeyValue("DATA_KEY"))
                clr = clrt.FromHtml("#CAE0DA")
                dataItem.BackColor = clr

                Dim ar() As String
                ar = dataItem.GetDataKeyValue("DATA_KEY").ToString().Split("|")
                Dim TaskStatus As String = ""
                TaskStatus = ar(4).ToString().Trim()
                Select Case TaskStatus
                    Case "A"
                        dataItem.ForeColor = Color.Maroon
                    Case "P"
                        dataItem.Font.Strikeout = True
                    Case "N"
                        dataItem.ForeColor = Color.Black
                    Case Else
                        dataItem.ForeColor = Color.Black
                End Select

                'Try
                '    Dim strName() As String = dataItem("colEMP_CODE_FML_NAME").Text.Split("-")

                '    dataItem("colEMP_CODE_FML_NAME").Text = strName(1)

                'Catch ex As Exception

                'End Try

                'Dim imgbtn As System.Web.UI.WebControls.ImageButton
                'Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                'imgbtn = e.Item.FindControl("imgbtnDetailTasks")
                'imgbtn.Attributes.Add("onclick", "OpenRadWindow('','TrafficSchedule_TaskDetail.aspx?pop=1&form=" + datakey(0) + "&JobNum=" + datakey(5) + "&JobComp=" + datakey(6) + "&SeqNum=" + datakey(7) + "&EmpCode=" + datakey(9) + "&Client=" + datakey(10) + "&Division=" + datakey(11) + "&Product=" + datakey(12) & "', '400','700');return false;")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEvents_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEvents.ItemCommand
        Try
            Select Case e.CommandName
                Case "DetailRow"
                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                    Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                    Dim strURL As String = "Event_Detail.aspx?et=0&j=" + datakey(5) + "&jc=" + datakey(6) + "&evt=" + datakey(8) + "&cli=" + datakey(10) + "&from=1"
                    Me.OpenWindow("Event Detail", strURL)
                    CalendarPageView = 1
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEvents_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEvents.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                'dataItem.CssClass = SetTextCSS(dataItem.GetDataKeyValue("DATA_KEY"))
                clr = clrt.FromHtml(SetEventColor(dataItem.GetDataKeyValue("AD_NBR_COLOR")))
                dataItem.BackColor = clr

                Dim ar() As String
                ar = dataItem.GetDataKeyValue("DATA_KEY").ToString().Split("|")
                Dim TaskStatus As String = ""
                TaskStatus = ar(4).ToString().Trim()
                Select Case TaskStatus
                    Case "A"
                        dataItem.ForeColor = Color.Maroon
                    Case "P"
                        dataItem.Font.Strikeout = True
                    Case "N"
                        dataItem.ForeColor = Color.Black
                    Case Else
                        dataItem.ForeColor = Color.Black
                End Select

                Dim imgbtn As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("imgbtnDetailEvents"), ImageButton)
                imgbtn.Attributes.Add("onclick", "openDetailWindow('" & dataItem.GetDataKeyValue("DATA_KEY") & "');return false;")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEventTasks_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEventTasks.ItemCommand
        Try
            Select Case e.CommandName
                Case "DetailRow"
                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                    Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                    Dim strURL As String = "Event_Task_Detail.aspx?etid=" + datakey(8) + "&f=" + datakey(6)
                    Me.OpenWindow("Event Task Detail", strURL)
                    CalendarPageView = 1
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEventTasks_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEventTasks.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                clr = clrt.FromHtml("#F7D5DB")
                dataItem.BackColor = clr

                Dim imgbtn As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("imgbtnDetailEventTasks"), ImageButton)
                imgbtn.Attributes.Add("onclick", "openDetailWindow('" & dataItem.GetDataKeyValue("DATA_KEY") & "');return false;")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridAppointmentHolidays_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAppointmentHolidays.ItemCommand
        Try
            Select Case e.CommandName
                Case "DetailRow"
                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                    Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                    Dim strURL As String = "Calendar_NewActivity.aspx?TaskNo=" + datakey(8) & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & Me._JobNumber & "&JobComponentNbr=" & Me._JobComponentNumber
                    Me.OpenWindow("Activity", strURL)
                    CalendarPageView = 1
                Case "Contacts"
                    Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                    Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")
                    Me.OpenWindow("Contacts", "popContacts.aspx?From=jj&client=" & datakey(10) & "&division=" & datakey(11) & "&product=" & datakey(12) & "','1200', '400'", 1200, 400)
                    CalendarPageView = 1
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridAppointmentHolidays_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAppointmentHolidays.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                dataItem("colSTART_DATE").Text = Me.SetDate(dataItem.GetDataKeyValue("ALL_DAY"), dataItem.GetDataKeyValue("NUM_DAYS"), dataItem.GetDataKeyValue("HAS_TIME"), dataItem.GetDataKeyValue("START_TIME"), dataItem.GetDataKeyValue("END_TIME"))
                'dataItem.CssClass = SetTextCSS(dataItem.GetDataKeyValue("DATA_KEY"))
                clr = clrt.FromHtml(SetColor(dataItem.GetDataKeyValue("NON_TASK_TYPE")))
                dataItem.BackColor = clr

                Dim ar() As String
                ar = dataItem.GetDataKeyValue("DATA_KEY").ToString().Split("|")
                Dim TaskStatus As String = ""
                TaskStatus = ar(4).ToString().Trim()
                Select Case TaskStatus
                    Case "A"
                        dataItem.ForeColor = Color.Maroon
                    Case "P"
                        dataItem.Font.Strikeout = True
                    Case "N"
                        dataItem.ForeColor = Color.Black
                    Case Else
                        dataItem.ForeColor = Color.Black
                End Select

                If dataItem("colNON_TASK_CATEGORY").Text = "no" Then
                    dataItem("colNON_TASK_CATEGORY").Text = ""
                End If

                Dim imgbtn As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("imgbtnDetailAppointmentHolidays"), ImageButton)
                'imgbtn.Attributes.Add("onclick", "openDetailWindow('" & dataItem.GetDataKeyValue("DATA_KEY") & "');return false;")

                imgbtn = CType(dataItem.FindControl("imgbtnContacts"), ImageButton)
                If dataItem.GetDataKeyValue("CDP_CONTACT_ID") = 0 Then
                    imgbtn.Visible = False
                End If

                Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
                Dim ds As DataSet
                ds = oCalendar.GetNonTaskDataDS(ar(8), HttpContext.Current.Session("UserCode"))

                Dim emps As String = ""
                If ds.Tables(1).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                        If IsDBNull(ds.Tables(1).Rows(i)("EMP_NAME")) = False Then
                            emps = emps & ds.Tables(1).Rows(i)("EMP_NAME").ToString & ","
                        End If
                    Next
                End If

                dataItem("colEMP_CODE_NAME").Text = MiscFN.RemoveTrailingDelimiter(emps, ",")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButtonListViewTasksRefresh_Click(sender As Object, e As EventArgs) Handles RadButtonListViewTasksRefresh.Click

        Try

            LoadCalendarListView()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridTasks_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridTasks.SortCommand
        Try
            LoadCalendarListView()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridAppointmentHolidays_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridAppointmentHolidays.SortCommand
        Try
            LoadCalendarListView()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEvents_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridEvents.SortCommand
        Try
            LoadCalendarListView()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridEventTasks_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridEventTasks.SortCommand
        Try
            LoadCalendarListView()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridListViewAssignments_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridListViewAssignments.ItemDataBound
    '    Try
    '        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
    '            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
    '            dataItem("colSTART_DATE").Text = Me.SetDate(dataItem.GetDataKeyValue("ALL_DAY"), dataItem.GetDataKeyValue("NUM_DAYS"), dataItem.GetDataKeyValue("HAS_TIME"), dataItem.GetDataKeyValue("START_TIME"), dataItem.GetDataKeyValue("END_TIME"))
    '            'dataItem.CssClass = SetTextCSS(dataItem.GetDataKeyValue("DATA_KEY"))
    '            clr = clrt.FromHtml("#CAE0DA")
    '            dataItem.BackColor = clr

    '            'Dim ar() As String
    '            'ar = dataItem.GetDataKeyValue("DATA_KEY").ToString().Split("|")
    '            'Dim TaskStatus As String = ""
    '            'TaskStatus = ar(4).ToString().Trim()
    '            'Select Case TaskStatus
    '            '    Case "A"
    '            '        dataItem.ForeColor = Color.Maroon
    '            '    Case "P"
    '            '        dataItem.Font.Strikeout = True
    '            '    Case "N"
    '            '        dataItem.ForeColor = Color.Black
    '            '    Case Else
    '            '        dataItem.ForeColor = Color.Black
    '            'End Select

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub RadGridListViewAssignments_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridListViewAssignments.ItemCommand
    '    Try
    '        Select Case e.CommandName
    '            Case "DetailRow"
    '                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
    '                Dim datakey() As String = dataItem.GetDataKeyValue("DATA_KEY").ToString.Split("|")

    '                Dim QsViewDetails As New AdvantageFramework.Web.QueryString

    '                QsViewDetails.Page = "Desktop_AlertView"
    '                QsViewDetails.Add("AlertID", dataItem.GetDataKeyValue("ALERT_ID").ToString)
    '                QsViewDetails.Add("SprintID", dataItem.GetDataKeyValue("SPRINT_ID").ToString)

    '                ''Dim strURL As String = "TrafficSchedule_TaskDetail.aspx?pop=1&form=" + datakey(0) + "&JobNum=" + datakey(5) + "&JobComp=" + datakey(6) + "&SeqNum=" + datakey(7) + "&EmpCode=" + datakey(9) + "&Client=" + datakey(10) + "&Division=" + datakey(11) + "&Product=" + datakey(12) + "&tab=3"
    '                Me.OpenWindow("Edit Assignment", QsViewDetails.ToString(True))
    '                CalendarPageView = 1
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub RadButtonLiistViewAssignmentsRefresh_Click(sender As Object, e As EventArgs) Handles RadButtonLiistViewAssignmentsRefresh.Click
    '    Try

    '        LoadCalendarListView()

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ImageButtonListView_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonListView.Click
        Dim str As String = ""
        str = "ListView_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
        'AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridTasks, str)
        'RadGridTasks.MasterTableView.ExportToExcel()

        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Client")
        DataTable.Columns.Add("Division")
        DataTable.Columns.Add("Product")
        DataTable.Columns.Add("Job/Component")
        DataTable.Columns.Add("Task")
        DataTable.Columns.Add("Date")
        DataTable.Columns.Add("Hours", System.Type.GetType("System.Decimal"))
        DataTable.Columns.Add("Employee")

        LoadCalendarListView()

        For Each GridDataItem In RadGridTasks.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem("colCL_NAME").Text
            NewDataRow(1) = GridDataItem("colDIV_NAME").Text
            NewDataRow(2) = GridDataItem("colPRD_DESCRIPTION").Text
            NewDataRow(3) = GridDataItem("colJOB_NUMBER").Text
            NewDataRow(4) = GridDataItem("colTask").Text
            NewDataRow(5) = GridDataItem("colSTART_DATE").Text
            NewDataRow(6) = GridDataItem("colTASK_HOURS_ALLOWED").Text
            NewDataRow(7) = GridDataItem("colEMP_CODE_FML_NAME").Text

        Next

        Me.DeliverGrid(DataTable, "Tasks") '<--- This does, please don't change unless you test!!!!

    End Sub

    'Private Sub ImageButtonListViewAssignments_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonListViewAssignments.Click
    '    Dim str As String = ""
    '    str = "ListView_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
    '    'AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridTasks, str)
    '    'RadGridTasks.MasterTableView.ExportToExcel()

    '    Dim DataTable As DataTable = Nothing
    '    Dim NewDataRow As DataRow = Nothing

    '    DataTable = New DataTable

    '    DataTable.Columns.Add("Client")
    '    DataTable.Columns.Add("Division")
    '    DataTable.Columns.Add("Product")
    '    DataTable.Columns.Add("Job/Component")
    '    DataTable.Columns.Add("Task")
    '    DataTable.Columns.Add("Date")
    '    DataTable.Columns.Add("Hours", System.Type.GetType("System.Decimal"))
    '    DataTable.Columns.Add("Employee")

    '    LoadCalendarListView()

    '    For Each GridDataItem In RadGridListViewAssignments.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

    '        NewDataRow = DataTable.Rows.Add()

    '        NewDataRow(0) = GridDataItem("colCL_NAME").Text
    '        NewDataRow(1) = GridDataItem("colDIV_NAME").Text
    '        NewDataRow(2) = GridDataItem("colPRD_DESCRIPTION").Text
    '        NewDataRow(3) = GridDataItem("colJOB_NUMBER").Text
    '        NewDataRow(4) = GridDataItem("colTask").Text
    '        NewDataRow(5) = GridDataItem("colSTART_DATE").Text
    '        NewDataRow(6) = GridDataItem("colTASK_HOURS_ALLOWED").Text
    '        NewDataRow(7) = GridDataItem("colEMP_CODE_FML_NAME").Text

    '    Next

    '    Me.DeliverGrid(DataTable, "Assignments") '<--- This does, please don't change unless you test!!!!
    'End Sub

    Private Sub ImageButtonAppointments_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAppointments.Click
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        DataTable = New DataTable

        DataTable.Columns.Add("Subject")
        DataTable.Columns.Add("Employee")
        DataTable.Columns.Add("Type")
        DataTable.Columns.Add("All Day")
        DataTable.Columns.Add("Date")
        DataTable.Columns.Add("Hours", System.Type.GetType("System.Decimal"))
        DataTable.Columns.Add("Category")
        DataTable.Columns.Add("Client")
        DataTable.Columns.Add("Division")
        DataTable.Columns.Add("Product")
        DataTable.Columns.Add("Contact")

        LoadCalendarListView()

        For Each GridDataItem In RadGridAppointmentHolidays.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem("colTASK_NON_TASK_DISPLAY").Text
            NewDataRow(1) = GridDataItem("colEMP_CODE_NAME").Text
            NewDataRow(2) = GridDataItem("colREC_TYPE").Text
            NewDataRow(3) = GridDataItem("colALL_DAY_YN").Text
            NewDataRow(4) = GridDataItem("colSTART_DATE").Text
            NewDataRow(5) = GridDataItem("colNON_TASK_HOURS").Text
            NewDataRow(6) = GridDataItem("colNON_TASK_CATEGORY").Text
            NewDataRow(7) = GridDataItem("colCL_NAME").Text
            NewDataRow(8) = GridDataItem("colDIV_NAME").Text
            NewDataRow(9) = GridDataItem("colPRD_DESCRIPTION").Text
            NewDataRow(10) = GridDataItem("colCONT_FML").Text

        Next

        Me.DeliverGrid(DataTable, "Appointments/Holidays") '<--- This does, please don't change unless you test!!!!
    End Sub
    Private Sub ImageButtonListViewEvents_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonListViewEvents.Click
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Client")
        DataTable.Columns.Add("Division")
        DataTable.Columns.Add("Product")
        DataTable.Columns.Add("Job/Component")
        DataTable.Columns.Add("Event")
        DataTable.Columns.Add("Resource")
        DataTable.Columns.Add("Ad Number")
        DataTable.Columns.Add("Start")
        DataTable.Columns.Add("End")
        DataTable.Columns.Add("Hours", GetType(Decimal))

        LoadCalendarListView()

        For Each GridDataItem In RadGridEvents.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem("colCL_NAME").Text
            NewDataRow(1) = GridDataItem("colDIV_NAME").Text
            NewDataRow(2) = GridDataItem("colPRD_DESCRIPTION").Text
            NewDataRow(3) = GridDataItem("colJOB_NUMBER").Text
            NewDataRow(4) = GridDataItem("colEVENT_AND_DESCRIPT").Text
            NewDataRow(5) = GridDataItem("colRESOURCE_AND_DESCRIPT").Text
            NewDataRow(6) = GridDataItem("colAD_NBR_AND_DESCRIPT").Text
            NewDataRow(7) = GridDataItem("colSTART_TIME").Text
            NewDataRow(8) = GridDataItem("colEND_TIME").Text
            NewDataRow(9) = GridDataItem("colTASK_HOURS_ALLOWED").Text

        Next

        Me.DeliverGrid(DataTable, "Events") '<--- This does, please don't change unless you test!!!!
    End Sub
    Private Sub ImageButtonListViewEventTask_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonListViewEventTask.Click
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Client")
        DataTable.Columns.Add("Division")
        DataTable.Columns.Add("Product")
        DataTable.Columns.Add("Job/Component")
        DataTable.Columns.Add("Task")
        DataTable.Columns.Add("Employee")
        DataTable.Columns.Add("Start")
        DataTable.Columns.Add("End")
        DataTable.Columns.Add("Hours", GetType(Decimal))

        LoadCalendarListView()

        For Each GridDataItem In RadGridEventTasks.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem("colCL_NAME").Text
            NewDataRow(1) = GridDataItem("colDIV_NAME").Text
            NewDataRow(2) = GridDataItem("colPRD_DESCRIPTION").Text
            NewDataRow(3) = GridDataItem("colJOB_NUMBER").Text
            NewDataRow(4) = GridDataItem("colTRF_AND_DESCRIPT").Text
            NewDataRow(5) = GridDataItem("colEMP_CODE_NAME").Text
            NewDataRow(6) = GridDataItem("colSTART_TIME").Text
            NewDataRow(7) = GridDataItem("colEND_TIME").Text
            NewDataRow(8) = GridDataItem("colNON_TASK_HOURS").Text

        Next

        Me.DeliverGrid(DataTable, "Event Tasks") '<--- This does, please don't change unless you test!!!!
    End Sub

    'Public Sub RadGridTasksGrid_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
    '    Dim rg As RadGrid
    '    rg = sender
    '    rg.DataSource = Me.RadGridTasks.DataSource
    '    rg.DataBind()
    'End Sub

    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Dim dt As DataTable
    '    dt = New DataTable
    '    dt.Columns.Add("ID")
    '    dt.Rows.Add("")
    '    RadGrid1.DataSource = dt
    'End Sub



#End Region

#Region "Workload"

    Public Sub LoadTasksWorkload(Optional ByVal Selected As String = "")
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim empsPerDept As String
        Dim dt As DataTable
        Dim empl As String
        SetAppVarsApplication()

        oAppVars.getAllAppVars()

        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            oAppVars.setAppVar("tcal_startdate", CType(Now.AddDays(-15).ToShortDateString, String), "Date")
        End If
        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            oAppVars.setAppVar("tcal_enddate", CType(Now.AddDays(15).ToShortDateString, String), "Date")
        End If

        empsPerDept = oTasks.GetEmpsPerDept(oAppVars.getAppVar("tcal_departs"))

        dt = oTasks.GetWorkload(CStr(Session("UserCode")),
                                oAppVars.getAppVar("tcal_emp"),
                                 Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))),
                                Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))),
                                oAppVars.getAppVar("tcal_office"),
                                oAppVars.getAppVar("tcal_client"),
                                oAppVars.getAppVar("tcal_div"),
                                oAppVars.getAppVar("tcal_prod"),
                                oAppVars.getAppVar("tcal_jobno"),
                                oAppVars.getAppVar("tcal_jobcomp"),
                                oAppVars.getAppVar("tcal_roles"),
                                oAppVars.getAppVar("tcal_taskstatus"),
                                CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                oAppVars.getAppVar("tcal_departs"),
                                empsPerDept,
                                oAppVars.getAppVar("tcal_manager"))


        'Me.lblWorkloadAnalysis.Text = "Workload Analysis for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
        'End If
        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            Me.RadDatePickerWorkloadStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        Else
            Me.RadDatePickerWorkloadStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        End If

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerWorkloadEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerWorkloadEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
        End If

        Me.lblTotalJobsDueNum.Text = dt.Rows(0).Item(0).ToString
        Me.lblTotalJobsOpenTasksNum.Text = dt.Rows(0).Item(1).ToString
        Me.lblOpenTaskNum.Text = dt.Rows(0).Item(2).ToString
        'If CStr(Session("tcal_emp")) = "" Then
        If oAppVars.getAppVar("tcal_emp") = "" Then
            Me.lblTotalHoursNeededNum.Text = dt.Rows(0).Item(3).ToString
        Else
            Me.lblTotalHoursNeededNum.Text = "N/A"
        End If

        Dim totalavailable As Decimal = Convert.ToDecimal(dt.Rows(0).Item(4)) - Convert.ToDecimal(dt.Rows(0).Item(7))
        Me.lblTotalHoursAvailableNum.Text = totalavailable.ToString("###0.00")
        Me.lblHoursAllocatedNum.Text = dt.Rows(0).Item(5).ToString
        Me.lblHoursOffNum.Text = dt.Rows(0).Item(6).ToString
        Me.lblAppointmentHoursNum.Text = dt.Rows(0).Item(8).ToString

        Dim total As Decimal = totalavailable - (Convert.ToDecimal(dt.Rows(0).Item(5)) + Convert.ToDecimal(dt.Rows(0).Item(6)) + Convert.ToDecimal(dt.Rows(0).Item(8)))
        Me.lblTotalHoursAllocatedNum.Text = total.ToString("###0.00")
        total = total - Convert.ToDecimal(dt.Rows(0).Item(3).ToString)

        If oAppVars.getAppVar("tcal_emp") = "" Then
            'If oAppVars.getAppVar("tcal_emp") = "" Then
            Me.lblVarianceNum.Text = total.ToString("###0.00")
            If total < 0.0 Then
                Me.lblVarianceNum.ForeColor = Color.Red
            End If
        Else
            Me.lblVarianceNum.Text = "N/A"
        End If

    End Sub

    Dim lab As System.Web.UI.WebControls.Label
    Dim lab2 As System.Web.UI.WebControls.Label


    Private TotalAssignementsDue As Integer = 0
    Private TotalHoursAssigned As Decimal = CType(0.0, Decimal)
    Private TotalHoursUnassigned As Decimal = CType(0.0, Decimal)
    Private TotalAdjustedHoursAssigned As Decimal = CType(0.0, Decimal)
    Private TotalTaskHours As Decimal = CType(0.0, Decimal)
    Private RowCount As Integer = 0
    Private DtHeaderInfo As New DataTable
    Private Sub GoToSchedule(ByRef CurrentGridRow As Telerik.Web.UI.GridDataItem)
        Try

            Dim q As New AdvantageFramework.Web.QueryString()

            With q

                .Page = "Content.aspx"
                .ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                .JobNumber = CurrentGridRow.GetDataKeyValue("JOB_NUMBER")
                .JobComponentNumber = CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")

            End With

            If Me.CurrentQuerystring.IsJobDashboard = True Then

                MiscFN.ResponseRedirect(q.ToString(True))

            Else

                Me.OpenWindow(q, "Schedule")

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridWorkload_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridWorkload.ItemCommand
        Try
            Select Case e.CommandName
                Case "GoToSchedule"
                    Try

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridWorkload.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)

                        If CurrentGridRow IsNot Nothing Then

                            GoToSchedule(CurrentGridRow)

                        End If

                    Catch ex As Exception
                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridWorkload_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridWorkload.ItemDataBound
        Try
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                RowCount += 1
                If IsNumeric(e.Item.Cells(11 + OffSet).Text) = True Then
                    TotalAssignementsDue += CType(e.Item.Cells(11 + OffSet).Text, Integer)
                Else
                    e.Item.Cells(11 + OffSet).Text = "0"
                End If
                If IsNumeric(e.Item.Cells(12 + OffSet).Text) = True Then
                    TotalHoursAssigned += CType(e.Item.Cells(12 + OffSet).Text, Decimal)
                Else
                    e.Item.Cells(12 + OffSet).Text = "0.00"
                End If
                If IsNumeric(e.Item.Cells(13 + OffSet).Text) = True Then
                    TotalHoursUnassigned += CType(e.Item.Cells(13 + OffSet).Text, Decimal)
                Else
                    e.Item.Cells(13 + OffSet).Text = "0.00"
                End If
                If IsNumeric(e.Item.Cells(14 + OffSet).Text) = True Then
                    TotalAdjustedHoursAssigned += CType(e.Item.Cells(14 + OffSet).Text, Decimal)
                Else
                    e.Item.Cells(14 + OffSet).Text = "0.00"
                End If
                If IsNumeric(e.Item.Cells(15 + OffSet).Text) = True Then
                    TotalTaskHours += CType(e.Item.Cells(15 + OffSet).Text, Decimal)
                Else
                    e.Item.Cells(15 + OffSet).Text = "0.00"
                End If

                If e.Item.Cells(10).Text <> "" Or e.Item.Cells(10).Text <> "&nbsp;" Then
                    e.Item.Cells(10).Text = LoGlo.FormatDate(e.Item.Cells(10).Text)
                End If
                If e.Item.Cells(11).Text <> "" Or e.Item.Cells(11).Text <> "&nbsp;" Then
                    e.Item.Cells(11).Text = LoGlo.FormatDate(e.Item.Cells(11).Text)
                End If
            End If
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Footer Then
                e.Item.Cells(11 + OffSet).Text = FormatNumber(Me.TotalAssignementsDue, 0, TriState.True, TriState.False, TriState.False)
                e.Item.Cells(12 + OffSet).Text = FormatNumber(Me.TotalHoursAssigned, 2, TriState.True, TriState.False, TriState.False)
                e.Item.Cells(13 + OffSet).Text = FormatNumber(Me.TotalHoursUnassigned, 2, TriState.True, TriState.False, TriState.False)
                e.Item.Cells(14 + OffSet).Text = FormatNumber(Me.TotalAdjustedHoursAssigned, 2, TriState.True, TriState.False, TriState.False)
                e.Item.Cells(15 + OffSet).Text = FormatNumber(Me.TotalTaskHours, 2, TriState.True, TriState.False, TriState.False)

                ''''redo header totals...
                Me.lblTotalJobsDueNum.Text = CType(Me.DtHeaderInfo.Rows(0)("TOTAL_JOB_DUE"), Integer)
                Me.lblTotalJobsOpenTasksNum.Text = Me.RowCount.ToString() 'Total Jobs with Open Tasks (in range)
                Me.lblOpenTaskNum.Text = FormatNumber(Me.TotalAssignementsDue, 0, TriState.True, TriState.False, TriState.False) 'Open Task Assignments Due

                Dim StdHrs As Decimal = 0.0
                Dim HrsOff As Decimal = 0.0
                Dim ApptHrs As Decimal = 0.0
                Dim AdjHrs As Decimal = 0.0
                Dim Variance As Decimal = 0.0
                Dim TaskHrsUnassigned As Decimal = 0.0
                Dim ShowUnassignedColumn As Boolean = False

                Try
                    StdHrs = CType(Me.DtHeaderInfo.Rows(0)("STD_HRS_AVAIL"), Decimal)
                    Me.lblTotalHoursAvailableNum.Text = FormatNumber(StdHrs, 2, TriState.True, TriState.False, TriState.False) 'Standard Hours available
                Catch ex As Exception
                End Try
                Try
                    ApptHrs = CType(Me.DtHeaderInfo.Rows(0)("APPT_HRS"), Decimal)
                    Me.lblAppointmentHoursNum.Text = FormatNumber(ApptHrs, 2, TriState.True, TriState.False, TriState.False)  'Hours Off
                Catch ex As Exception
                End Try
                Try
                    HrsOff = CType(Me.DtHeaderInfo.Rows(0)("HRS_OFF"), Decimal)
                    Me.lblHoursOffNum.Text = FormatNumber(HrsOff, 2, TriState.True, TriState.False, TriState.False)  'Hours Off
                Catch ex As Exception
                End Try
                Try
                    AdjHrs = CType(Me.DtHeaderInfo.Rows(0)("HRS_ASSIGNED_TASK"), Decimal)
                    Me.lblHoursAllocatedNum.Text = FormatNumber(AdjHrs, 2, TriState.True, TriState.False, TriState.False)  'Hours assigned to task
                Catch ex As Exception
                End Try
                Try
                    If CType(Me.DtHeaderInfo.Rows(0)("SHOW_UNASSIGNED"), Integer) = 1 Then
                        ShowUnassignedColumn = True
                    Else
                        ShowUnassignedColumn = False
                    End If
                Catch ex As Exception
                    ShowUnassignedColumn = False
                End Try

                If ShowUnassignedColumn = True Then
                    Try
                        'TaskHrsUnassigned = CType(Me.DtHeaderInfo.Rows(0)("GRAND_TOTAL_UNASSIGNED_HOURS"), Decimal)
                        Me.lblTotalHoursNeededNum.Text = FormatNumber(TotalHoursUnassigned, 2, TriState.True, TriState.False, TriState.False)  'Hours un assigned
                    Catch ex As Exception
                    End Try
                Else
                    Me.lblTotalHoursNeededNum.Text = "N/A"
                End If
                Me.RadGridWorkload.MasterTableView.GetColumn("colTOTAL_HRS_UNASSIGNED").Display = ShowUnassignedColumn


                Me.lblTotalHoursAllocatedNum.Text = FormatNumber(StdHrs - HrsOff - AdjHrs - ApptHrs, 2, TriState.True, TriState.False, TriState.False) 'hours available balance

                '''Me.lblTotalHoursNeededNum.Text = "" 'task hours unassigned
                Variance = StdHrs - HrsOff - AdjHrs - TotalHoursUnassigned - ApptHrs


                If oAppVars.getAppVar("tcal_emp") = "" Then
                    'If oAppVars.getAppVar("tcal_emp") = "" Then
                    Me.lblVarianceNum.Text = Variance.ToString("###0.00")
                    If Variance < 0 Then
                        Me.lblTotalHoursAllocatedNum.ForeColor = Color.Red
                    End If
                Else
                    Me.lblVarianceNum.Text = "N/A"
                End If
                TotalHoursUnassigned = 0.0
                RowCount = 0

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridWorkload_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridWorkload.NeedDataSource
        SetAppVarsApplication()
        oAppVars.getAllAppVars()
        Me.CollapsablePanelWorkloadAnalysis.TitleText = "Workload Analysis for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            Me.RadDatePickerWorkloadStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        Else
            Me.RadDatePickerWorkloadStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        End If

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerWorkloadEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerWorkloadEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
        End If

        Try
            Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
            Dim ds As New DataSet
            Dim r As New cResources
            If Me.RadTabStripTaskCalendar.SelectedTab.Value = 2 Then
                ds = oTasks.GetWorkloadDetails(CStr(Session("UserCode")),
                                                               Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))),
                                                               Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))),
                                                               oAppVars.getAppVar("tcal_office"),
                                                               oAppVars.getAppVar("tcal_client"),
                                                               oAppVars.getAppVar("tcal_div"),
                                                               oAppVars.getAppVar("tcal_prod"),
                                                               oAppVars.getAppVar("tcal_jobno"),
                                                               oAppVars.getAppVar("tcal_jobcomp"),
                                                               oAppVars.getAppVar("tcal_roles"),
                                                               oAppVars.getAppVar("tcal_taskstatus"),
                                                               CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                               oAppVars.getAppVar("tcal_emp"),
                                                               oAppVars.getAppVar("tcal_manager"), oAppVars.getAppVar("tcal_departs"))
                Me.RadGridWorkload.DataSource = ds.Tables(0)

                Me.DtHeaderInfo = r.GetAvailabilityDataSet(oAppVars.getAppVar("tcal_emp"), Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))),
                                                             Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))),
                                                             1, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True, "",
                                                             oAppVars.getAppVar("tcal_office"),
                                                               oAppVars.getAppVar("tcal_client"),
                                                               oAppVars.getAppVar("tcal_div"),
                                                               oAppVars.getAppVar("tcal_prod"),
                                                               oAppVars.getAppVar("tcal_jobno"),
                                                               oAppVars.getAppVar("tcal_jobcomp"),
                                                               oAppVars.getAppVar("tcal_taskstatus"),
                                                               CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                                               oAppVars.getAppVar("tcal_manager")).Tables(5)
                'Me.DtHeaderInfo = ds.Tables(1)
                'If ds.Tables(1).Rows.Count > 0 Then
                '    'redo header totals...
                '    If IsDBNull(ds.Tables(1).Rows(0)("")) = False Then

                '    End If
                '    Me.lblTotalJobsOpenTasksNum.Text = Me.RowCount.ToString() 'Total Jobs with Open Tasks (in range)
                '    Me.lblOpenTaskNum.Text = FormatNumber(Me.TotalAssignementsDue, 2, TriState.True, TriState.False, TriState.False) 'Open Task Assignments Due
                '    Me.lblTotalHoursAvailableNum.Text = "" 'Standard Hours available
                '    'Me.lblHoursOffNum.Text = "" 'Hours Off
                '    Me.lblHoursAllocatedNum.Text = FormatNumber(Me.TotalHoursAssigned, 2, TriState.True, TriState.False, TriState.False) 'Hours assigned to task
                '    Me.lblTotalHoursAllocatedNum.Text = "" 'hours available balance
                '    Me.lblTotalHoursNeededNum.Text = "" 'task hours unassigned
                '    Me.lblVarianceNum.Text = "" 'variance

                'End If
            End If


        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        'Me.RadGridWorkload.Visible = Me.IsPostBack
    End Sub

#End Region

#Region "Availability"

    Private _ZeroHoursColorCSS As String = "standard-white"
    Private _LessThanHoursColorCSS As String = "standard-light-green"
    Private _LessThanAndGreaterThanHoursColorCSS As String = "standard-yellow-100"
    Private _GreaterThanHoursColorCSS As String = "standard-red-100"

    Private Sub LoadLegend()

        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivZeroHoursColor, _ZeroHoursColorCSS)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLessThanHoursColor, _LessThanHoursColorCSS)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLessThanAndGreaterThanHoursColor, _LessThanAndGreaterThanHoursColorCSS)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivGreaterThanHoursColor, _GreaterThanHoursColorCSS)

        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_UNDER_PCT_DIRECT';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanPercentage.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanPercentage.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_PROP_PCT_DIRECT';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThan.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThan.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_PROP_PCT_TOTAL';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThan.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThan.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_OVER_PCT_TOTAL';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxGreaterThanHours.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxGreaterThanHours.Value = 0
        Finally
            dr.Close()
        End Try

    End Sub
    Private Sub LoadEmployeeList()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim SQL_FROM As String
        Dim SQL_WHERE As String
        Dim dr As SqlDataReader
        Dim restrictions As Integer
        Dim userid, roles, depts, empcode As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        userid = Session("UserCode")
        roles = oAppVars.getAppVar("tcal_roles")      'Session("tcal_role")
        empcode = oAppVars.getAppVar("tcal_emp")    '
        depts = oAppVars.getAppVar("tcal_departs")
        'depts = oAppVars.getAppVarDB("tcal_departs")  '

        SQL_STRING = "Select Count(*) FROM SEC_EMP Where USER_ID = '" & userid & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:taskassignments Routine:LoadEmployeeList", Err.Description)
        Finally

        End Try

        Do While dr.Read
            restrictions = dr.GetInt32(0)
        Loop

        dr.Close()


        Dim Employeeoffice As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList
        End Using

        SQL_STRING = "SELECT DISTINCT EMPLOYEE.EMP_CODE as Code, EMPLOYEE.EMP_CODE " & " + ' - ' + " & " isnull(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE) + " & "', '" & " + isnull(EMPLOYEE.EMP_FNAME, '') AS Description "
        SQL_FROM = " FROM EMPLOYEE "
        SQL_WHERE = " Where (EMP_TERM_DATE Is NULL) "

        If restrictions > 0 Then
            SQL_FROM = SQL_FROM & "Inner JOIN SEC_EMP On EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE "
            SQL_WHERE = SQL_WHERE & " And SEC_EMP.USER_ID = '" & userid & "'"
        End If

        If roles <> Nothing Then
            SQL_FROM = SQL_FROM & "Inner JOIN EMP_TRAFFIC_ROLE ON EMPLOYEE.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE "
            SQL_WHERE = SQL_WHERE & " AND EMP_TRAFFIC_ROLE.ROLE_CODE IN (" & roles & ")"
        End If

        If Employeeoffice IsNot Nothing AndAlso Employeeoffice.Count > 0 Then
            SQL_FROM = SQL_FROM & "Inner JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & _Session.User.EmployeeCode & "'"
        End If

        If empcode <> Nothing Then
            SQL_WHERE = SQL_WHERE & " And EMPLOYEE.EMP_CODE = '" & empcode & "' "
        End If

        If depts <> Nothing Then
            SQL_WHERE = SQL_WHERE & " And EMPLOYEE.DP_TM_CODE IN (" & depts & ") "
        End If

        SQL_STRING = SQL_STRING & SQL_FROM & SQL_WHERE

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:taskassignments Routine:LoadEmployeeList", Err.Description)
        Finally

        End Try

        Me.ddEmployee.Items.Clear()
        Me.ddEmployee.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Employees", "%"))
        Me.RadComboBoxEmployeeAllocation.Items.Clear()
        Me.RadComboBoxEmployeeAllocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Employees", "%"))

        Dim idx As Integer
        Dim empdesc As String
        idx = 0
        Do While dr.Read
            idx = idx + 1
            empcode = dr.GetString(0)
            empdesc = dr.GetString(1)
            Me.ddEmployee.Items.Insert(idx, New Telerik.Web.UI.RadComboBoxItem(empdesc, empcode))
            Me.RadComboBoxEmployeeAllocation.Items.Insert(idx, New Telerik.Web.UI.RadComboBoxItem(empdesc, empcode))
        Loop

        dr.Close()



        'Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        'If CStr(Session("tcal_role")) = "" Then
        '    Me.ddEmployee.DataSource = oDropDowns.GetEmployees(Session("UserCode"))
        'Else
        '    Me.ddEmployee.DataSource = oDropDowns.GetEmployeesByRole(Session("UserCode"), Session("tcal_role"))
        'End If

        'Me.ddEmployee.DataTextField = "Description"
        'Me.ddEmployee.DataValueField = "Code"
        'Me.ddEmployee.DataBind()


    End Sub
    Public Sub LoadTasks(Optional ByVal Selected As String = "")

        'objects
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        SetAppVarsApplication()
        Dim AllowGroupToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        oAppVars.getAllAppVars()

        Try

            UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

            For Each UserGroupSettingValue In UserGroupSettingValues

                Try

                    If UserGroupSettingValue = True Then

                        AllowGroupToViewOtherEmployees = True
                        Exit For

                    End If

                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            AllowGroupToViewOtherEmployees = False
        End Try

        If AllowGroupToViewOtherEmployees = False Then
            Me.ddEmployee.SelectedValue = Session("EmpCode")
            Me.ddEmployee.Visible = False
            Me.RadComboBoxEmployeeAllocation.SelectedValue = Session("EmpCode")
            Me.RadComboBoxEmployeeAllocation.Visible = False
        Else
            Me.ddEmployee.SelectedValue = oAppVars.getAppVar("tcal_emp")
            Me.ddEmployee.Visible = True
            Me.RadComboBoxEmployeeAllocation.SelectedValue = oAppVars.getAppVar("tcal_emp")
            Me.RadComboBoxEmployeeAllocation.Visible = True
        End If

        'If Session("tcal_startdate") Is Nothing Then
        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            'Session("tcal_startdate") = Now.AddDays(-15).ToShortDateString
            oAppVars.setAppVar("tcal_startdate", CType(Now.AddDays(-15).ToShortDateString, String), "Date")
        End If
        'If Session("tcal_enddate") Is Nothing Then
        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            'Session("tcal_enddate") = Now.AddDays(15).ToShortDateString
            oAppVars.setAppVar("tcal_enddate", CType(Now.AddDays(15).ToShortDateString, String), "Date")
        End If

        Dim empsPerDept As String
        Dim dt As DataTable
        'If CStr(Session("tcal_tclientcode")) = "" Then
        'dt = oTasks.GetWorkload(CStr(Session("UserCode")), CStr(Session("tcal_emp")), Now.Date.AddDays(-15.0), Now.Date.AddDays(15.0), "", "", "", "", "", "", "", "", False)
        'Me.lblWorkloadAnalysis.Text = "Workload Analysis for " & Now.Date.AddDays(-15.0) & " through " & Now.Date.AddDays(15.0)
        'Else
        empsPerDept = oTasks.GetEmpsPerDept(Session("tcal_depts"))

        'dt = oTasks.GetWorkload(CStr(Session("UserCode")), _
        '                        CStr(Session("tcal_emp")), _
        '                        Convert.ToDateTime(Session("tcal_startdate")), _
        '                        Convert.ToDateTime(Session("tcal_enddate")), _
        '                        CStr(Session("tcal_office")), _
        '                        CStr(Session("tcal_client")), _
        '                        CStr(Session("tcal_div")), _
        '                        CStr(Session("tcal_prod")), _
        '                        CStr(Session("tcal_jobno")), _
        '                        CStr(Session("tcal_jobcomp")), _
        '                        CStr(Session("tcal_role")), _
        '                        CStr(Session("tcal_taskstatus")), _
        '                        Session("tcal_excludetempcomplete"), _
        '                        CStr(Session("tcal_departs")), _
        '                        empsPerDept, _
        '                        CStr(Session("tcal_manager")))

        '''dt = oTasks.GetWorkload(CStr(Session("UserCode")), _
        '''                        CStr(Session("tcal_emp")), _
        '''                        Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), _
        '''                        Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")), _
        '''                        oAppVars.getAppVar("tcal_office"), _
        '''                        oAppVars.getAppVar("tcal_client"), _
        '''                        oAppVars.getAppVar("tcal_div"), _
        '''                        oAppVars.getAppVar("tcal_prod"), _
        '''                        oAppVars.getAppVar("tcal_jobno"), _
        '''                        oAppVars.getAppVar("tcal_jobcomp"), _
        '''                        oAppVars.getAppVar("tcal_role"), _
        '''                        oAppVars.getAppVar("tcal_taskstatus"), _
        '''                        oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean", "False"), _
        '''                        CStr(Session("tcal_departs")), _
        '''                        empsPerDept, _
        '''                        oAppVars.getAppVar("tcal_manager"))

        'Me.lblWorkloadAnalysis.Text = "Workload Analysis for " & Convert.ToDateTime(Session("tcal_startdate")) & " through " & Convert.ToDateTime(Session("tcal_enddate"))
        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            Me.RadDatePickerAvailabilityStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        Else
            Me.RadDatePickerAvailabilityStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        End If

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerAvailabilityEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerAvailabilityEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
        End If
        'End If
        RefreshAvailabilityPanelHeaderTitle()

        '''Dim totalavailable As Decimal = Convert.ToDecimal(dt.Rows(0).Item(4)) - Convert.ToDecimal(dt.Rows(0).Item(7))

    End Sub
    Private Sub RefreshAvailabilityPanelHeaderTitle()

        Me.CollapsablePanelHeader.TitleText = "&nbsp;&nbsp;&nbsp;&nbsp;Availability Analysis for " & Convert.ToDateTime(LoGlo.FormatDate(RadDatePickerAvailabilityStartDate.SelectedDate)) & " through " & Convert.ToDateTime(LoGlo.FormatDate(RadDatePickerAvailabilityEndDate.SelectedDate))

    End Sub
    Private Function GetDetailColumns(ByVal startdate As Date, ByVal enddate As Date) As Integer

        Dim sum_level As String
        Dim idx_range As Integer

        ''''If Me.RadioButton1.Checked = True Then
        ''''    sum_level = "w"
        ''''End If

        ''''If Me.RadioButton2.Checked = True Then
        ''''    sum_level = "m"
        ''''End If

        If sum_level = "m" Then
            idx_range = DateDiff(DateInterval.Month, startdate, enddate)
        Else
            idx_range = DateDiff(DateInterval.WeekOfYear, startdate, enddate)
        End If

        Return idx_range


    End Function
    Public Function CreateHeaderTextAct()

        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim sum_level As String = "w"
        Dim uname As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        ''''If Me.RadioButton1.Checked Then
        ''''    sum_level = "w"
        ''''End If
        ''''If Me.RadioButton2.Checked Then
        ''''    sum_level = "m"
        ''''End If

        ''''detail_count = Me.RadGrid2.Columns.Count

        If detail_count > 0 Then

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("OFFICE_CODE")
            boundColumn.DataField = "OFFICE_CODE"
            boundColumn.HeaderText = "Office"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("EMP_DESC")
            boundColumn.DataField = "EMP_DESC"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Employee"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DP_TM_CODE")
            boundColumn.DataField = "DP_TM_CODE"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Dept"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DIRECT_HRS_PER")
            boundColumn.DataField = "DIRECT_HRS_PER"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Direct Hours Goal %"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("HOURS_AVAIL")
            boundColumn.DataField = "HOURS_AVAIL"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Hours Available"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DIR_HRS_GOAL")
            boundColumn.DataField = "DIR_HRS_GOAL"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Direct Hours Goal"

            'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
            'column_date = Convert.ToDateTime(Session("tcal_startdate"))
            'start_date = Convert.ToDateTime(Session("tcal_startdate"))
            detail_count = GetDetailColumns(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
            column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
            start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

            'Dim aname As String
            'For idx = 1 To detail_count
            '    aname = Me.RadGrid2.MasterTableView.Columns.Item(idx).UniqueName
            '    aname = Me.RadGrid2.Columns.Item(idx).UniqueName
            'Next

            For idx = 1 To detail_count
                column_header = ""
                'boundColumn = New GridBoundColumn
                If sum_level = "w" Then
                    If idx > 1 Then
                        column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                    End If
                    date_day = DatePart(DateInterval.Day, column_date)
                    date_month = DatePart(DateInterval.Month, column_date)
                    date_year = DatePart(DateInterval.Year, column_date)
                    date_week = DatePart(DateInterval.WeekOfYear, column_date)

                    If (date_year > start_year And date_month = 1 And date_week = 1) Or idx = 1 Then
                        column_header = CStr(date_year) & Chr(13) & Chr(10)
                        start_year = date_year
                    End If
                    column_header = column_header & CStr(date_month) & "/" & CStr(date_day)

                    'boundColumn.HeaderText = CStr(column_header)

                Else
                    If idx > 1 Then
                        column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                    End If

                    date_day = DatePart(DateInterval.Day, column_date)
                    date_month = DatePart(DateInterval.Month, column_date)
                    date_year = DatePart(DateInterval.Year, column_date)

                    If (date_year > start_year And date_month = 1) Or idx = 1 Then
                        column_header = CStr(date_year) & Chr(13) & Chr(10)
                        start_year = date_year
                    End If

                    If idx = 1 Then
                        column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                    Else
                        column_header = column_header & CStr(date_month) & "/1"
                    End If

                    'boundColumn.HeaderText = CStr(column_header)
                End If

                'boundColumn.HeaderStyle.Width = Unit.Pixel(25)
                'boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                'boundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Bottom
                'boundColumn.ItemStyle.Width = Unit.Pixel(25)
                'boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left

                Column_UniqueName = "col" & CStr(idx)
                'boundColumn.DataField = Column_UniqueName
                boundColumn.ReadOnly = True
                ''''boundColumn = Me.RadGrid2.Columns.FindByDataField(Column_UniqueName)
                boundColumn.HeaderText = CStr(column_header)

            Next
        End If
    End Function
    Private Function DBStr(ByRef dr As SqlDataReader, ByVal Name As String) As String
        If IsDBNull(dr(Name)) = True Then
            Return ""
        Else
            Return CStr(dr(Name))
        End If
    End Function
    Public Function LoadAssignmentsGrid(ByVal empcode As String, ByVal empname As String)
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim Emp_lbl As String = Me.ddEmployee.SelectedItem.Text
        Dim r As New cResources
        Dim ThisLevel As cResources.SummaryLevel

        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        SetAppVarsApplication()

        oAppVars.getAllAppVars()

        'If Session("Assignments") = True Then
        If CType(oAppVars.getAppVar("Assignments"), Boolean) = True Then

            Dim ds As New DataSet
            Dim dsTotals As DataSet
            Dim DtTotals As New DataTable
            ThisLevel = cResources.SummaryLevel.Day
            dsTotals = r.GetAvailabilityDataSet(empcode, Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))), Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))), ThisLevel, "", oAppVars.getAppVar("tcal_departs"), True)
            DtTotals = dsTotals.Tables(1)

            With Me.RadGridAssignments
                .DataSource = dsTotals.Tables(4).DefaultView
                '  .DataBind()
            End With




            boundColumn = New Telerik.Web.UI.GridBoundColumn
            boundColumn = Me.RadGridAssignments.Columns.FindByDataField("EMP_CODE")

            If Emp_lbl = "%" Or Emp_lbl = "All Employees" Then
                Me.lblEmployee.Text = "Employee Assignments for " & empname & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                boundColumn.Visible = True
            Else
                Me.lblEmployee.Text = "Employee Assignments for " & Emp_lbl & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                boundColumn.Visible = True
            End If

            'redo the header total...
            Try
                If DtTotals.Rows.Count > 0 Then
                    Dim StdHrsAvail As Decimal = CType(0.0, Decimal)
                    Dim HrsAppts As Decimal = CType(0.0, Decimal)
                    Dim HrsOff As Decimal = CType(0.0, Decimal)
                    Dim HrsAssignedToTasks As Decimal = CType(0.0, Decimal)
                    Dim TotalAssignmentsHours As Decimal = CType(0.0, Decimal)
                    Dim Variance As Decimal = CType(0.0, Decimal)
                    Dim DirectHours As Decimal = CType(0.0, Decimal)
                    Dim PercDirect As Decimal = CType(0.0, Decimal)
                    If Not IsDBNull(DtTotals.Rows(0)("STD_HRS_AVAIL")) Then
                        If IsNumeric(DtTotals.Rows(0)("STD_HRS_AVAIL")) = True Then
                            StdHrsAvail = CType(DtTotals.Rows(0)("STD_HRS_AVAIL"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursEmpAvailableNum.Text = FormatNumber(StdHrsAvail, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_APPTS")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_APPTS")) = True Then
                            HrsAppts = CType(DtTotals.Rows(0)("HRS_APPTS"), Decimal)
                        End If
                    End If
                    Me.lblTotalAppointmentHoursNum.Text = FormatNumber(HrsAppts, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_USED_NON_TASK")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_USED_NON_TASK")) = True Then
                            HrsOff = CType(DtTotals.Rows(0)("HRS_USED_NON_TASK"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursOffEmpNum.Text = FormatNumber(HrsOff, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) = True Then
                            TotalAssignmentsHours = CType(DtTotals.Rows(0)("HRS_ASSIGNED_TASK"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursAssignedNum.Text = FormatNumber(TotalAssignmentsHours, 2, TriState.True, TriState.True, TriState.False)

                    Variance = StdHrsAvail - HrsOff - TotalAssignmentsHours - HrsAppts
                    Me.lblVarianceEmpNum.Text = FormatNumber(Variance, 2, TriState.True, TriState.True, TriState.False)
                    If Variance < 0 Then
                        Me.lblVarianceEmpNum.ForeColor = Color.Red
                    End If

                    If Not IsDBNull(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) Then
                        If IsNumeric(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) = True Then
                            DirectHours = CType(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                        End If
                    End If

                    If DirectHours > 0 Then
                        PercDirect = (TotalAssignmentsHours / DirectHours) * 100
                        Me.lblDirectHoursGoalNum.Text = FormatNumber(PercDirect, 2, TriState.True, TriState.True, TriState.False)
                    End If

                End If
            Catch ex As Exception
            End Try


        Else

        End If
    End Function

    'This is the "Assignments" button:
    Private Sub btnAssignments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssignments.Click

        SetAppVarsApplication()

        Me.RblAvailabilitySummaryLevel.Visible = False
        Me.RadGridAvailability.Visible = False

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim Emp_lbl As String = Me.ddEmployee.SelectedItem.Text
        Dim idx As Integer
        Dim total As Decimal
        Dim totalavailable As Decimal

        oAppVars.setAppVarDB("Assignments", "True", "Boolean")
        oAppVars.setAppVarDB("Available", "False", "Boolean")

        Me.RadGridAssignments.Visible = True
        Me.lblTotalHoursEmpAvailable.Visible = True
        Me.lblTotalHoursAssigned.Visible = True
        Me.lblTotalHoursOffEmp.Visible = True
        Me.lblVarianceEmp.Visible = True
        Me.lblTotalHoursEmpAvailableNum.Visible = True
        Me.lblTotalHoursAssignedNum.Visible = True
        Me.lblTotalHoursOffEmpNum.Visible = True
        Me.lblVarianceEmpNum.Visible = True
        Me.lblDirectHoursGoal.Visible = True
        Me.lblDirectHoursGoalNum.Visible = True
        Me.imgbtnExport.Visible = True

        Me.txtTasks.Visible = True
        Me.TextBox1.Visible = True
        Me.TextBox6.Visible = True
        Me.TextBox7.Visible = True
        Me.Label1.Visible = True
        Me.Label2.Visible = True
        Me.Label11.Visible = True
        Me.Label19.Visible = True
        Me.CheckBox1.Visible = False
        Me.DivSummaryLevel.Visible = False
        Me.ButtonRefresh.Visible = False
        Me.DivLessThanHours.Visible = False
        Me.DivZeroHours.Visible = False
        Me.DivLessThanAndGreaterThanHours.Visible = False
        Me.DivGreaterThanHours.Visible = False
        Me.ButtonExport.Visible = False


        Dim empcode As String
        empcode = Me.ddEmployee.SelectedValue.ToString
        If empcode = "%" Then
            empcode = ""
        End If

        oAppVars.getAllAppVars()

        Me.RadGridAssignments.Visible = True
        Me.RadGridAvailability.Visible = False
        Me.RadGridAssignments.Rebind()

    End Sub

    'This is the "Availability" button:
    Private Sub btnAvail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvail.Click

        SetAppVarsApplication()

        oAppVars.setAppVarDB("Assignments", "False", "Boolean")
        oAppVars.setAppVarDB("Available", "True", "Boolean")

        Me.RblAvailabilitySummaryLevel.Visible = True
        For i As Integer = 0 To Me.RblAvailabilitySummaryLevel.Items.Count - 1
            Me.RblAvailabilitySummaryLevel.Items(i).Selected = False
        Next
        Me.RblAvailabilitySummaryLevel.Items(1).Selected = True 'pre-select weekly

        Me.RadGridAssignments.Visible = False
        Me.lblTotalHoursEmpAvailable.Visible = False
        Me.lblTotalHoursAssigned.Visible = False
        Me.lblTotalHoursOffEmp.Visible = False
        Me.lblVarianceEmp.Visible = False
        Me.lblTotalHoursEmpAvailableNum.Visible = False
        Me.lblTotalHoursAssignedNum.Visible = False
        Me.lblTotalHoursOffEmpNum.Visible = False
        Me.lblVarianceEmpNum.Visible = False
        Me.lblDirectHoursGoal.Visible = False
        Me.lblDirectHoursGoalNum.Visible = False
        Me.imgbtnExport.Visible = False
        Me.txtTasks.Visible = False
        Me.TextBox1.Visible = False
        Me.TextBox6.Visible = False
        Me.TextBox7.Visible = False
        Me.Label1.Visible = False
        Me.Label2.Visible = False
        Me.Label11.Visible = False
        Me.Label19.Visible = False
        Me.DivSummaryLevel.Visible = True
        Me.ButtonRefresh.Visible = True

        Me.RadGridAvailability.Visible = False

        Me.RefreshAvailability()


    End Sub

    Private SumTotalTaskHours As Decimal = CType(0.0, Decimal)
    Private SumAdjustedHoursAssigned As Decimal = CType(0.0, Decimal)

    Private Sub RadGridAssignments_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAssignments.ItemCommand
        Try
            Select Case e.CommandName
                Case "GoToSchedule"
                    Try

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAssignments.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)

                        If CurrentGridRow IsNot Nothing Then

                            GoToSchedule(CurrentGridRow)

                        End If

                    Catch ex As Exception
                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridAssignments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAssignments.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.AlternatingItem, GridItemType.Item

                Dim CurrentGridRow As GridDataItem = e.Item
                Dim DivGoToSchedule As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivGoToSchedule")

                Try

                    Select Case e.Item.DataItem("REC_TYPE").ToString()
                        Case "T"

                            e.Item.BackColor = ColorTranslator.FromHtml("#CAE0DA")

                        Case "ET"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F7D5DB")

                        Case "A", "ADA", "C", "M", "TD", "EL"

                            e.Item.BackColor = ColorTranslator.FromHtml("#B2C9E0")

                        Case "AHO", "ADHO"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F6E3BC")

                        Case "H"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F9DEC7")

                    End Select

                Catch ex As Exception
                End Try

                Try
                    Select Case e.Item.DataItem("REC_TYPE").ToString()
                        Case "T", "ET", "A", "ADA", "AHO", "ADHO", "C", "M", "TD", "EL"

                            Try
                                If IsNumeric(e.Item.Cells(13 + OffSet).Text) = True Then 'Total Task Hours column

                                    SumTotalTaskHours = SumTotalTaskHours + CType(e.Item.Cells(13 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try
                            Try

                                If IsNumeric(e.Item.Cells(16 + OffSet).Text) = True Then 'Adjusted Hours Assigned column

                                    SumAdjustedHoursAssigned = SumAdjustedHoursAssigned + CType(e.Item.Cells(16 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try

                    End Select
                    If e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then

                        e.Item.Cells(13).Text = LoGlo.FormatDate(e.Item.Cells(13).Text)

                    End If
                    If e.Item.Cells(14).Text <> "" And e.Item.Cells(14).Text <> "&nbsp;" Then

                        e.Item.Cells(14).Text = LoGlo.FormatDate(e.Item.Cells(14).Text)

                    End If

                Catch ex As Exception
                End Try

                Try
                    Dim JobNumber As Integer = 0
                    Dim JobComponentNumber As Short = 0

                    If CurrentGridRow.GetDataKeyValue("JOB_NUMBER") IsNot Nothing AndAlso IsNumeric(CurrentGridRow.GetDataKeyValue("JOB_NUMBER")) = True Then

                        JobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)

                    End If
                    If CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR") IsNot Nothing AndAlso IsNumeric(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")) = True Then

                        JobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)

                    End If
                    If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                        e.Item.Cells(8).Text = CurrentGridRow.GetDataKeyValue("JOB_NUMBER").ToString.PadLeft(6, "0") & "/" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0") & " - " & CurrentGridRow.GetDataKeyValue("JOB_COMP_DESC").ToString

                    Else

                        If DivGoToSchedule IsNot Nothing Then

                            AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToSchedule)

                        End If

                    End If

                Catch ex As Exception
                End Try

            Case GridItemType.Footer

                Try

                    e.Item.Cells(13 + OffSet).Text = SumTotalTaskHours.ToString()
                    e.Item.Cells(16 + OffSet).Text = SumAdjustedHoursAssigned.ToString()

                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadGridAssignments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAssignments.NeedDataSource
        Try
            Dim empcode As String = ""
            Dim empname As String = ""
            Dim dr As SqlDataReader
            Dim cEmp As New cEmployee(Session("ConnString"))
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            If Me.IsPostBack Or Me.IsCallback Then
                Me.RadGridAssignments.Visible = True
                'If Me.RadGridAssignments.Visible = True And Me.RadGridAvailability.Visible = False Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvailability.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        empcode = gridDataItem.Cells(2).Text
                        empname = gridDataItem.Cells(4).Text
                        Session("CalendarPageViewEmpCode") = empcode
                    End If
                Next
                If empcode = "" Then
                    Me.LoadAssignmentsGrid("%", "All Employees")
                    Me.DivEmployeePicture.Visible = False
                Else
                    Me.LoadAssignmentsGrid(empcode, empname)
                    Me.DivEmployeePicture.Visible = True
                    Me.LabelEmployee.Visible = True
                    Me.RadBinaryImage1.Visible = True
                    dr = cEmp.GetEmployeeProfile(empcode)
                    If dr.HasRows Then
                        dr.Read()
                        If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                            If IsDBNull(dr("EMP_IMAGE")) = False Then
                                Dim FileBytes() As Byte = CType(dr("EMP_IMAGE"), Byte())
                                Me.RadBinaryImage1.DataValue = FileBytes
                            Else
                                Me.RadBinaryImage1.ImageUrl = "Images/NoImage.png"
                            End If
                        Else
                            Me.RadBinaryImage1.Visible = False
                        End If
                        If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then
                            If IsDBNull(dr("EMP_FNAME")) = False Then
                                Me.LabelEmployee.Text = dr("EMP_FNAME")
                            Else
                                Me.LabelEmployee.Text = ""
                            End If
                        ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then
                            If IsDBNull(dr("EMP_NICKNAME")) = False Then
                                Me.LabelEmployee.Text = dr("EMP_NICKNAME")
                            Else
                                Me.LabelEmployee.Text = ""
                            End If
                        End If
                        dr.Close()
                    End If
                End If

                Me.lblTotalHoursEmpAvailable.Visible = True
                Me.lblTotalHoursAssigned.Visible = True
                Me.lblTotalHoursOffEmp.Visible = True
                Me.lblVarianceEmp.Visible = True
                Me.lblTotalHoursEmpAvailableNum.Visible = True
                Me.lblTotalHoursAssignedNum.Visible = True
                Me.lblTotalHoursOffEmpNum.Visible = True
                Me.lblTotalAppointmentHours.Visible = True
                Me.lblTotalAppointmentHoursNum.Visible = True
                Me.lblVarianceEmpNum.Visible = True
                Me.lblDirectHoursGoal.Visible = True
                Me.lblDirectHoursGoalNum.Visible = True
                Me.imgbtnExport.Visible = True

                Me.txtTasks.Visible = True
                Me.TextBox1.Visible = True
                Me.TextBox6.Visible = True
                Me.TextBox7.Visible = True
                'Me.TextBoxAllocationTasks.Visible = True
                'Me.TextBoxAllocationAppointments.Visible = True
                'Me.TextBoxAllocationHours.Visible = True
                'Me.TextBoxAllocationEvent.Visible = True
                Me.Label1.Visible = True
                Me.Label2.Visible = True
                Me.Label11.Visible = True
                Me.Label19.Visible = True
                'Me.LabelAllocationTasks.Visible = True
                'Me.LabelAllocationAppointments.Visible = True
                'Me.LabelAllocationHours.Visible = True
                'Me.LabelAllocationEvent.Visible = True
                Me.LabelEmployee.ViewStateMode = True
                Me.RadBinaryImage1.Visible = True
                'End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        SaveDateSettings(RadDatePickerAvailabilityStartDate.SelectedDate, RadDatePickerAvailabilityEndDate.SelectedDate)
        Me.RefreshAvailability()
    End Sub

    Private Sub RefreshAvailability()
        'LoadGrid()
        ''''Me.RadGrid2.Visible = True
        Me.DivLessThanHours.Visible = True
        Me.DivZeroHours.Visible = True
        Me.DivLessThanAndGreaterThanHours.Visible = True
        Me.DivGreaterThanHours.Visible = True
        Me.ButtonExport.Visible = True

        Me.RadGridAssignments.Visible = False
        Me.lblTotalHoursEmpAvailable.Visible = False
        Me.lblTotalHoursAssigned.Visible = False
        Me.lblTotalHoursOffEmp.Visible = False
        Me.lblVarianceEmp.Visible = False
        Me.lblTotalHoursEmpAvailableNum.Visible = False
        Me.lblTotalHoursAssignedNum.Visible = False
        Me.lblTotalHoursOffEmpNum.Visible = False
        Me.lblVarianceEmpNum.Visible = False
        Me.DivEmployeePicture.Visible = False
        Me.lblTotalAppointmentHours.Visible = False
        Me.lblTotalAppointmentHoursNum.Visible = False
        Me.lblDirectHoursGoal.Visible = False
        Me.lblDirectHoursGoalNum.Visible = False
        Me.imgbtnExport.Visible = False

        Me.txtTasks.Visible = False
        Me.TextBox1.Visible = False
        Me.TextBox6.Visible = False
        Me.TextBox7.Visible = False
        Me.TextBoxAllocationTasks.Visible = False
        Me.TextBoxAllocationAppointments.Visible = False
        Me.TextBoxAllocationHours.Visible = False
        Me.TextBoxAllocationEvent.Visible = False
        Me.Label1.Visible = False
        Me.Label2.Visible = False
        Me.Label11.Visible = False
        Me.Label19.Visible = False
        Me.LabelAllocationTasks.Visible = False
        Me.LabelAllocationAppointments.Visible = False
        Me.LabelAllocationHours.Visible = False
        Me.LabelAllocationEvent.Visible = False
        Me.lblEmployee.Text = ""

        EnableOrDisableAvailabilityOptions()

        'If Me.RadioButton3.Checked = True Then
        If Me.RblAvailabilitySummaryLevel.Visible = True Then
            'LoadLegend()
            Me.RadGridAvailability.Rebind()
        End If
        'End If
        RefreshAvailabilityPanelHeaderTitle()

    End Sub

    Public Function Convert2xel(ByVal ds As SqlDataReader, ByVal response As HttpResponse, Optional ByVal filename As String = "")
        Dim svalue As String
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim header_txt As String
        Dim header_cols As String
        Dim rowidx As Integer = 0
        Dim str_file As String
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim sHeader As String
        Dim builder As New System.Text.StringBuilder
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        If filename = "" Then filename = "WebvantageToExcel"

        response.Clear()
        response.Charset = ""
        response.ContentType = "application/excel"
        response.AddHeader("content-disposition", "inline;filename=" & filename & ".xls")

        If ds.HasRows Then
            header_cols = ""
            Do While ds.Read
                rowidx = rowidx + 1
                svalue = DBStr(ds, ("OFFICE_CODE")) & vbTab
                svalue = svalue & DBStr(ds, ("EMP_DESC")) & vbTab
                svalue = svalue & DBStr(ds, ("DP_TM_CODE")) & vbTab
                svalue = svalue & DBStr(ds, ("DIRECT_HRS_PER")) & vbTab
                svalue = svalue & DBStr(ds, ("HOURS_AVAIL")) & vbTab
                svalue = svalue & DBStr(ds, ("DIR_HRS_GOAL")) & vbTab


                'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
                'column_date = Convert.ToDateTime(Session("tcal_startdate"))
                'start_date = Convert.ToDateTime(Session("tcal_startdate"))
                detail_count = GetDetailColumns(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
                column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
                start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

                For idx = 1 To detail_count + 1
                    column_header = ""

                    If sum_level = "w" Then
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                        End If
                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)
                        date_week = DatePart(DateInterval.WeekOfYear, column_date)

                        If rowidx = 1 Then
                            column_header = column_header & CStr(date_month) & "/" & CStr(date_day) & "/" & CStr(date_year)
                            header_cols = header_cols & CStr(column_header) & vbTab
                        End If

                    Else
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                        End If

                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)

                        If rowidx = 1 Then
                            If idx = 1 Then
                                column_header = column_header & CStr(date_month) & "/" & CStr(date_day) & "/" & CStr(date_year)
                            Else
                                column_header = column_header & CStr(date_month) & "/1"
                            End If

                            header_cols = header_cols & CStr(column_header) & vbTab
                        End If

                    End If

                    Column_UniqueName = "col" & CStr(idx)
                    svalue = svalue & DBStr(ds, (Column_UniqueName)) & vbTab
                Next
            Loop
        End If

        sHeader = filename & vbCrLf
        sHeader = sHeader & "Office" & vbTab & "Employee" & ControlChars.Tab & "Dept" & vbTab & "Direct Hours Goal %" & vbTab & "Hours Available" & vbTab & "Direct Hours Goal" & vbTab & header_cols
        'builder.Append(sHeader)

        str_file = sHeader & vbCrLf & svalue
        htmlWrite.WriteLine(str_file)

        response.Write(stringWrite.ToString())
        response.End()
    End Function

    Public Function CreateHeader(ByVal ds As SqlDataReader) As String
        Dim svalue As String
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim start_workweek_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim header_txt As String
        Dim header_cols As String
        Dim rowidx As Integer = 0
        Dim sHeader As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()
        ''''If Me.RadioButton1.Checked Then
        ''''    sum_level = "w"
        ''''End If
        ''''If Me.RadioButton2.Checked Then
        ''''    sum_level = "m"
        ''''End If

        If Me.CheckBox1.Checked Then
            actualize = 1
        End If

        If ds.HasRows Then
            header_cols = ""
            Do While ds.Read
                rowidx = rowidx + 1
                svalue = " <td> " & DBStr(ds, ("OFFICE_CODE")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("EMP_DESC")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DP_TM_CODE")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DIRECT_HRS_PER")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("HOURS_AVAIL")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DIR_HRS_GOAL")) & " </td> "

                'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
                'column_date = Convert.ToDateTime(Session("tcal_startdate"))
                'start_date = Convert.ToDateTime(Session("tcal_startdate"))
                detail_count = GetDetailColumns(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
                column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
                start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

                'Need to determine whcih day of week and set to start of work week
                Dim dayofweek As Integer
                dayofweek = DatePart(DateInterval.Weekday, start_date)

                For idx = 1 To detail_count + 1
                    column_header = ""

                    If sum_level = "w" Then
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                        End If
                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)
                        date_week = DatePart(DateInterval.WeekOfYear, column_date)

                        If rowidx = 1 Then
                            column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                            header_cols = header_cols & " <td> " & CStr(column_header) & " </td> "
                        End If

                    Else
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                        End If

                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)

                        If rowidx = 1 Then
                            If idx = 1 Then
                                column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                            Else
                                column_header = column_header & CStr(date_month) & "/1"
                            End If

                            header_cols = header_cols & " <td> " & CStr(column_header) & " </td> "
                        End If

                    End If
                Next
            Loop
        End If
        'sHeader = sHeader & "Office" & vbTab & "Employee" & ControlChars.Tab & "Dept" & vbTab & "Direct Hours Goal %" & vbTab & "Hours Available" & vbTab & "Direct Hours Goal" & vbTab & header_cols & ControlChars.CrLf
        sHeader = "<table><tr style='font-weight:bold;border-style:solid '> <td> Office </td> <td> Employee </td> <td> Dept </td>  <td> Direct Hours Goal % </td>  <td> Hours Available </td>  <td> Direct Hours Goal </td> " & header_cols & " </tr> </table> "

        Return sHeader

    End Function

    Protected Sub ButtonExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click
        Try

            IsExport = True
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAvailability, "")
            Me.RadGridAvailability.MasterTableView.ExportToExcel()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridAvailability_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGridAvailability.ColumnCreated
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString() = ("Employee") Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.ItemStyle.CssClass = "radgrid-employee-name-column"
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Total") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("/") > -1 Then

                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right

                Try
                    boundColumn.DataFormatString = "{0:0.00}"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridAvailability_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAvailability.ItemDataBound
        'hide emp_code
        Try
            e.Item.Cells(2).Visible = False
        Catch ex As Exception
        End Try

        'Multiplier to use:
        Dim LessThanDirectHoursGoal As Decimal = 0.0 'Less than ___% of the direct Hours Goal
        Dim GreaterEqualToDirectHoursGoal As Decimal = 0.0 'Greater than or equal to ___% of direct hours goal
        Dim LessThanHrsAvailable As Decimal = 0.0 'and less than ___% of the hours available
        Dim GreaterEqualToHrsAvailable As Decimal = 0.0 'greater than or equal to 90% of hours available

        If IsNumeric(Me.RadNumericTextBoxLessThanPercentage.Value) = True Then
            LessThanDirectHoursGoal = CType(Me.RadNumericTextBoxLessThanPercentage.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThan.Value) = True Then
            GreaterEqualToDirectHoursGoal = CType(Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThan.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThan.Value) = True Then
            LessThanHrsAvailable = CType(Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThan.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxGreaterThanHours.Value) = True Then
            GreaterEqualToHrsAvailable = CType(Me.RadNumericTextBoxGreaterThanHours.Value, Decimal) / 100.0
        End If


        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim CurrCell As Integer = 10
            Do While CurrCell <= e.Item.Cells.Count - 1 'odd number columns are hrs available, add one and that is the corresponding hours available column
                Dim CurrTaskHours As Decimal = 0.0
                Dim CurrAvailHours As Decimal = 0.0
                Dim CurrDirectGoalHours As Decimal = 0.0
                Dim OverBooked As Integer = 0
                Try
                    If IsNumeric(e.Item.Cells(CurrCell).Text) = True Then
                        CurrTaskHours = CType(e.Item.Cells(CurrCell).Text, Decimal)
                    Else
                        e.Item.Cells(CurrCell).Text = "0.00"
                    End If
                Catch ex As Exception
                    CurrTaskHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 1).Text) = True Then
                        CurrAvailHours = CType(e.Item.Cells(CurrCell + 1).Text, Decimal)
                    End If
                Catch ex As Exception
                    CurrAvailHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 2).Text) = True Then
                        CurrDirectGoalHours = CType(e.Item.Cells(CurrCell + 2).Text, Decimal)
                    End If
                Catch ex As Exception
                    CurrDirectGoalHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 3).Text) = True Then
                        OverBooked = CType(e.Item.Cells(CurrCell + 3).Text, Integer)
                    End If
                Catch ex As Exception
                    OverBooked = 0
                End Try

                '''just a test:
                ''If CurrTaskHours < CurrAvailHours Then
                ''    e.Item.Cells(CurrCell).CssClass = "standard-red"
                ''End If
                'let one override the next...

                If CurrCell < (e.Item.Cells.Count - 1) Then

                    Try
                        If CurrTaskHours < (CurrAvailHours * LessThanDirectHoursGoal) Then
                            e.Item.Cells(CurrCell).CssClass = _LessThanHoursColorCSS
                        End If
                        If (CurrTaskHours >= (CurrAvailHours * LessThanDirectHoursGoal)) And (CurrTaskHours < (CurrAvailHours * LessThanHrsAvailable)) Then
                            e.Item.Cells(CurrCell).CssClass = _LessThanAndGreaterThanHoursColorCSS
                        End If
                        If (CurrTaskHours > (CurrAvailHours * GreaterEqualToHrsAvailable)) Then
                            e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                        End If
                        If CurrTaskHours = 0.0 Then
                            e.Item.Cells(CurrCell).CssClass = _ZeroHoursColorCSS
                        End If
                        If OverBooked = 1 Then
                            e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                        End If
                    Catch ex As Exception
                    End Try

                End If
                If CurrCell = (e.Item.Cells.Count - 1) Then
                    'THIS IS THE TOTAL ROW?
                    Try
                        e.Item.Cells(CurrCell).CssClass = _ZeroHoursColorCSS
                        e.Item.Cells(CurrCell).Text = "<strong>" & e.Item.Cells(CurrCell).Text & "</strong>"
                    Catch ex As Exception
                    End Try
                End If


                CurrCell += 4
            Loop

        End If


    End Sub
    Private Sub RadGridAvailability_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvailability.NeedDataSource
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RblAvailabilitySummaryLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select
                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                If ThisLevel = cResources.SummaryLevel.Day AndAlso Not IsDailyAllowed(st, et) Then

                    ThisLevel = cResources.SummaryLevel.Week
                    Me.RblAvailabilitySummaryLevel.Items(1).Selected = True

                End If

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 3 Then
                    LoadIt = False
                End If

                If LoadIt = True Then

                    oAppVars.getAllAppVars()



                    Dim dt As New DataTable
                    dt = r.GetAvailabilityDatatable(Me.ddEmployee.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            Me.RadGridAvailability.DataSource = dt
                            Me.ButtonExport.Enabled = True
                            If Me.ddEmployee.SelectedValue = "%" Then
                                Me.ButtonAll.Visible = True
                            Else
                                Me.ButtonAll.Visible = False
                            End If
                        Else
                            Me.ButtonExport.Enabled = False
                        End If
                    Else
                        Me.ButtonExport.Enabled = False
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub RadGridAvailability_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAvailability.SelectedIndexChanged
        Try
            Me.RadGridAssignments.Rebind()
            Me.RadGridAssignments.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAll.Click
        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvailability.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    gridDataItem.Selected = False
                End If
            Next
            Me.RadGridAssignments.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            Dim Description As String = "Edit Task"
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAssignments.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_NUMBER")) = False Then
                        job = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                        comp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    End If
                    rectype = gridDataItem.GetDataKeyValue("REC_TYPE")
                    client = gridDataItem.GetDataKeyValue("CL_CODE")
                    division = gridDataItem.GetDataKeyValue("DIV_CODE")
                    product = gridDataItem.GetDataKeyValue("PRD_CODE")
                    seqnum = gridDataItem.GetDataKeyValue("SEQ_NBR")
                    nontaskid = gridDataItem.GetDataKeyValue("NON_TASK_ID")
                    Description = gridDataItem("column5").Text
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)
                Case "PS"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)
                Case "Task"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployee.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    If rectype = "T" Then
                        StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & job & "&JobComp=" & comp & "&SeqNum=" & seqnum & "&Client=" & client & "&Division=" & division & "&Product=" & product
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal1", "Edit Task", StrEditURL, 650, 860, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                        Me.OpenWindow(Description, StrEditURL, 650, 860, False, True)
                    ElseIf rectype = "H" Or rectype = "A" Or rectype = "ADA" Or rectype = "AHO" Or rectype = "ADAHO" Then
                        StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & nontaskid & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & job & "&JobComponentNbr=" & comp
                        Me.OpenWindow("New Activity", StrEditURL, 1000, 1500)
                        'ElseIf Str(6) = 2 Then
                        '    StrEditURL = "Event_Detail.aspx?et=0&j=" & Str(0) & "&jc=" & Str(1) & "&evt=" & Str(7) & "&cli=" & Str(3) & "&from=1"
                        '    Me.OpenWindow("Event Detail", StrEditURL, 745, 525, False, True)
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal2", "Event Detail", StrEditURL, 745, 325, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    ElseIf rectype = "ET" Then
                        StrEditURL = "Event_Task_Detail.aspx?etid=" & nontaskid & "&f=c"
                        Me.OpenWindow("Event Task Edit", StrEditURL, 620, 670, False, True)
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal3", "Event Task Edit", StrEditURL, 620, 670, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    End If
                Case "EditAssignment"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployee.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
                    oTask.Where.JOB_NUMBER.Value = job
                    oTask.Where.JOB_COMPONENT_NBR.Value = comp
                    oTask.Where.SEQ_NBR.Value = seqnum
                    Dim taskcode As String
                    If oTask.Query.Load Then
                        taskcode = oTask.FNC_CODE
                    End If
                    StrEditURL = "TrafficSchedule_TaskEmployees.aspx?From=cal&FromApp=" & Request.QueryString("FromApp") & "&JobNum=" & job & "&JobComp=" & comp & "&SeqNum=" & seqnum & "&TaskCode=" & taskcode
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal1", "Edit Task", StrEditURL, 600, 650, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    Me.OpenWindow("Edit Assignment", StrEditURL, 600, 650, False, True)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadMenu2_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu2.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAssignments.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_NUMBER")) = False Then
                        job = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                        comp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    End If
                    rectype = gridDataItem.GetDataKeyValue("REC_TYPE")
                    If IsDBNull(gridDataItem.GetDataKeyValue("CL_CODE")) = False Then
                        client = gridDataItem.GetDataKeyValue("CL_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("DIV_CODE")) = False Then
                        division = gridDataItem.GetDataKeyValue("DIV_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("PRD_CODE")) = False Then
                        product = gridDataItem.GetDataKeyValue("PRD_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("SEQ_NBR")) = False Then
                        seqnum = gridDataItem.GetDataKeyValue("SEQ_NBR")
                    End If
                    nontaskid = gridDataItem.GetDataKeyValue("NON_TASK_ID")
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)
                Case "PS"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)
                Case "Task"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployee.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    'If rectype = "H" Or rectype = "A" Or rectype = "ADA" Or rectype = "AHO" Or rectype = "ADAHO" Then
                    StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & nontaskid & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & job & "&JobComponentNbr=" & comp
                    Me.OpenWindow("New Activity", StrEditURL, 1000, 1500)
                    'End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Allocation"

    Private Sub ButtonRefreshAllocation_Click(sender As Object, e As EventArgs) Handles ButtonRefreshAllocation.Click
        Try
            SaveDateSettings(RadDatePickerAllocationStartDate.SelectedDate, RadDatePickerAllocationEndDate.SelectedDate)

            Dim message As String = ""
            If Not Me.RadDatePickerAllocationStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerAllocationEndDate.SelectedDate Is Nothing Then
                If wvCDate(Me.RadDatePickerAllocationStartDate.SelectedDate) > wvCDate(Me.RadDatePickerAllocationEndDate.SelectedDate) Then
                    message = "End Date must be greater than Start Date."
                    Me.ShowMessage(message)
                    Exit Sub
                End If
                If wvCDate(Me.RadDatePickerAllocationEndDate.SelectedDate).Subtract(wvCDate(Me.RadDatePickerAllocationStartDate.SelectedDate)).Days > 365 Then
                    message = "Date range must be less than one year."
                    Me.ShowMessage(message)
                    Exit Sub
                End If
            End If

            Me.RefreshAllocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshAllocation()
        'LoadGrid()
        SetAppVarsApplication()
        oAppVars.getAllAppVars()
        ''''Me.RadGrid2.Visible = True
        Me.ButtonExportAllocation.Visible = True

        Me.RadGridAllocationJob.Visible = False
        Me.lblTotalHoursEmpAvailableAllocation.Visible = False
        Me.lblTotalHoursAssignedAllocation.Visible = False
        Me.lblTotalHoursOffEmpAllocation.Visible = False
        Me.lblVarianceEmpAllocation.Visible = False
        Me.lblTotalHoursEmpAvailableAllocationNum.Visible = False
        Me.lblTotalHoursAssignedAllocationNum.Visible = False
        Me.lblTotalHoursOffEmpAllocationNum.Visible = False
        Me.lblVarianceEmpAllocationNum.Visible = False
        Me.PanelEmployeeAllocation.Visible = False
        Me.lblTotalAppointmentHoursAllocation.Visible = False
        Me.lblTotalAppointmentHoursAllocationNum.Visible = False
        Me.lblDirectHoursGoalAllocation.Visible = False
        Me.lblDirectHoursGoalAllocationNum.Visible = False
        Me.ImageButtonExport.Visible = False
        Me.lblEmployeeAllocation.Visible = False

        Me.TextBoxAllocationTasks.Visible = False
        Me.TextBoxAllocationAppointments.Visible = False
        Me.TextBoxAllocationHours.Visible = False
        Me.TextBoxAllocationEvent.Visible = False
        Me.LabelAllocationTasks.Visible = False
        Me.LabelAllocationAppointments.Visible = False
        Me.LabelAllocationHours.Visible = False
        Me.LabelAllocationEvent.Visible = False
        Me.lblEmployee.Text = ""

        EnableOrDisableAllocationOptions()

        'If Me.RadioButton3.Checked = True Then
        If Me.RadioButtonListAllocationLevel.Visible = True Then
            Me.PanelAllocation.Visible = True
            Me.PanelAllocationEmployee.Visible = False
            'LoadLegend()
            Me.RadGridAllocationDepartment.Rebind()
            Me.RadGridWrapper.Rebind()
        End If
        'End If
        Me.CollapsablePanel1.TitleText = "&nbsp;&nbsp;&nbsp;&nbsp;Allocation for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            Me.RadDatePickerAllocationStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        Else
            Me.RadDatePickerAllocationStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        End If

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerAllocationEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerAllocationEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
        End If

    End Sub

    Private Sub RadGridAllocation_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGridAllocation.ColumnCreated
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("/") > -1 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                Try
                    boundColumn.DataFormatString = "{0:0.00}%"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadGridAllocation_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAllocation.ItemDataBound
        'hide emp_code
        Try
            e.Item.Cells(2).Visible = False
        Catch ex As Exception
        End Try
        Try
            'Multiplier to use:
            Dim LessThanDirectHoursGoal As Decimal = 0.0 'Less than ___% of the direct Hours Goal
            Dim GreaterEqualToDirectHoursGoal As Decimal = 0.0 'Greater than or equal to ___% of direct hours goal
            Dim LessThanHrsAvailable As Decimal = 0.0 'and less than ___% of the hours available
            Dim GreaterEqualToHrsAvailable As Decimal = 0.0 'greater than or equal to 90% of hours available

            'If IsNumeric(Me.legendBox1.Text) = True Then
            '    LessThanDirectHoursGoal = CType(Me.legendBox1.Text, Decimal) / 100.0
            'End If
            'If IsNumeric(Me.legendBox2.Text) = True Then
            '    GreaterEqualToDirectHoursGoal = CType(Me.legendBox2.Text, Decimal) / 100.0
            'End If
            'If IsNumeric(Me.legendBox3.Text) = True Then
            '    LessThanHrsAvailable = CType(Me.legendBox3.Text, Decimal) / 100.0
            'End If
            'If IsNumeric(Me.legendBox4.Text) = True Then
            '    GreaterEqualToHrsAvailable = CType(Me.legendBox4.Text, Decimal) / 100.0
            'End If


            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim CurrCell As Integer = 9
                For i As Integer = 9 To e.Item.Cells.Count - 1 'odd number columns are hrs available, add one and that is the corresponding hours available column
                    Dim CurrTaskHours As Decimal = 0.0
                    Dim CurrAvailHours As Decimal = 0.0
                    Dim CurrDirectGoalHours As Decimal = 0.0
                    Dim OverBooked As Integer = 0
                    Try
                        If IsNumeric(e.Item.Cells(CurrCell).Text) = True Then
                            CurrTaskHours = CType(e.Item.Cells(CurrCell).Text, Decimal)
                        Else
                            'e.Item.Cells(CurrCell).Text = "0.00"
                        End If
                    Catch ex As Exception
                        CurrTaskHours = 0.0
                    End Try
                    Try
                        If IsNumeric(e.Item.Cells(CurrCell + 1).Text) = True Then
                            CurrAvailHours = CType(e.Item.Cells(CurrCell + 1).Text, Decimal)
                        End If
                    Catch ex As Exception
                        CurrAvailHours = 0.0
                    End Try
                    Try
                        If IsNumeric(e.Item.Cells(CurrCell + 2).Text) = True Then
                            CurrDirectGoalHours = CType(e.Item.Cells(CurrCell + 2).Text, Decimal)
                        End If
                    Catch ex As Exception
                        CurrDirectGoalHours = 0.0
                    End Try
                    Try
                        If IsNumeric(e.Item.Cells(CurrCell + 3).Text) = True Then
                            OverBooked = CType(e.Item.Cells(CurrCell + 3).Text, Integer)
                        End If
                    Catch ex As Exception
                        OverBooked = 0
                    End Try

                    '''just a test:
                    ''If CurrTaskHours < CurrAvailHours Then
                    ''    e.Item.Cells(CurrCell).CssClass = "standard-red"
                    ''End If
                    'let one override the next...

                    'If CurrCell < (e.Item.Cells.Count - 1) Then


                    '    If CurrTaskHours < (CurrAvailHours * LessThanDirectHoursGoal) Then
                    '        Try
                    '            e.Item.Cells(CurrCell).CssClass = "standard-light-orange"
                    '        Catch ex As Exception
                    '        End Try
                    '    End If
                    '    If (CurrTaskHours >= (CurrAvailHours * LessThanDirectHoursGoal)) And (CurrTaskHours < (CurrAvailHours * LessThanHrsAvailable)) Then
                    '        Try
                    '            e.Item.Cells(CurrCell).CssClass = "standard-light-blue"
                    '        Catch ex As Exception
                    '        End Try
                    '    End If
                    '    If (CurrTaskHours > (CurrAvailHours * GreaterEqualToHrsAvailable)) Then
                    '        Try
                    '            e.Item.Cells(CurrCell).CssClass = "standard-pink"
                    '        Catch ex As Exception
                    '        End Try
                    '    End If
                    '    If CurrTaskHours = 0.0 Then
                    '        Try
                    '            e.Item.Cells(CurrCell).CssClass = "standardWhite"
                    '        Catch ex As Exception
                    '        End Try
                    '    End If
                    '    If OverBooked = 1 Then
                    '        Try
                    '            e.Item.Cells(CurrCell).CssClass = "standard-pink"
                    '        Catch ex As Exception
                    '        End Try
                    '    End If


                    'End If
                    'If CurrCell = (e.Item.Cells.Count - 1) Then
                    '    'THIS IS THE TOTAL ROW?
                    '    Try
                    '        e.Item.Cells(CurrCell).CssClass = "standardWhite"
                    '        e.Item.Cells(CurrCell).Text = "<strong>" & e.Item.Cells(CurrCell).Text & "</strong>"
                    '    Catch ex As Exception
                    '    End Try
                    'End If


                    'CurrCell += 4
                Next

            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridAllocation_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAllocation.NeedDataSource
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                Dim deptcode As String = ""
                Dim deptdesc As String = ""
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RadioButtonListAllocationLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select
                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                If ThisLevel = cResources.SummaryLevel.Day AndAlso Not IsDailyAllowed(st, et) Then

                    Me.RadioButtonListAllocationLevel.Items(1).Selected = True
                    ThisLevel = cResources.SummaryLevel.Week

                End If

                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocationDepartment.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        deptcode = "'" & gridDataItem.Cells(2).Text & "'"
                        deptdesc = gridDataItem.Cells(4).Text
                    End If
                Next

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 6 And deptcode = "" Then
                    LoadIt = False
                End If

                If LoadIt = True Then

                    oAppVars.getAllAppVars()



                    Dim dt As New DataTable
                    dt = r.GetAllocationDatatable(Me.RadComboBoxEmployeeAllocation.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), deptcode, True)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            Me.RadGridAllocation.DataSource = dt
                            Me.ButtonExportAllocation.Enabled = True
                            Me.LabelAllocation.Visible = False
                            If Me.RadComboBoxEmployeeAllocation.SelectedValue = "%" Then
                                Me.ButtonAll.Visible = True
                            End If
                        Else
                            Me.ButtonExportAllocation.Enabled = False
                            Me.LabelAllocation.Visible = True
                        End If
                    Else
                        Me.ButtonExportAllocation.Enabled = False
                        Me.LabelAllocation.Visible = True
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridAllocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAllocation.SelectedIndexChanged
        Try
            Me.RadGridAllocationJob.Visible = True
            Me.RadGridAllocationJob.Rebind()
            Me.RadGridAllocationJob.Focus()

            Me.lblTotalHoursEmpAvailableAllocation.Visible = True
            Me.lblTotalHoursAssignedAllocation.Visible = True
            Me.lblTotalHoursOffEmpAllocation.Visible = True
            Me.lblVarianceEmpAllocation.Visible = True
            Me.lblTotalHoursEmpAvailableAllocationNum.Visible = True
            Me.lblTotalHoursAssignedAllocationNum.Visible = True
            Me.lblTotalHoursOffEmpAllocationNum.Visible = True
            Me.lblTotalAppointmentHoursAllocation.Visible = True
            Me.lblTotalAppointmentHoursAllocationNum.Visible = True
            Me.lblVarianceEmpAllocationNum.Visible = True
            Me.lblDirectHoursGoalAllocation.Visible = True
            Me.lblDirectHoursGoalAllocationNum.Visible = True
            Me.ImageButtonExport.Visible = True


            'Me.TextBoxAllocationTasks.Visible = True
            'Me.TextBoxAllocationAppointments.Visible = True
            'Me.TextBoxAllocationHours.Visible = True
            'Me.TextBoxAllocationEvent.Visible = True
            'Me.LabelAllocationTasks.Visible = True
            'Me.LabelAllocationAppointments.Visible = True
            'Me.LabelAllocationHours.Visible = True
            'Me.LabelAllocationEvent.Visible = True
            Me.LabelEmployeeAllocation.Visible = True
            Me.lblEmployeeAllocation.Visible = True
            Me.RadBinaryImage2.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridAll_NeedDataSource(sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                Dim deptcode As String = ""
                Dim deptdesc As String = ""
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RadioButtonListAllocationLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select
                'End If
                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocationDepartment.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        deptcode = "'" & gridDataItem.Cells(2).Text & "'"
                        deptdesc = gridDataItem.Cells(4).Text
                    End If
                Next

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 6 And deptcode = "" Then
                    LoadIt = False
                End If

                If LoadIt = True Then

                    oAppVars.getAllAppVars()
                    Dim dt As New DataTable
                    dt = r.GetAllocationDatatable(Me.RadComboBoxEmployeeAllocation.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), deptcode, True)
                    sender.DataSource = dt
                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

    Public Sub RadGridAll_ItemDataBound(sender As Object, e As GridItemEventArgs)
        Try
            e.Item.Cells(2).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RadGridAll_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs)
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("Hours Assigned") > -1 Or e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 Or e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 Or e.Column.UniqueName.ToString().IndexOf("Total") > -1 Or e.Column.UniqueName.ToString().IndexOf("/") > -1 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                Try
                    boundColumn.DataFormatString = "{0:0.00}"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RadGridAll_OnExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs)
        Try
            Dim boundColumn As Telerik.Web.UI.GridBoundColumn
            If e.FormattedColumn.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.FormattedColumn, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAllocationJob_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGridAllocationJob.ColumnCreated

        If TypeOf e.Column Is Telerik.Web.UI.GridBoundColumn Then

            Dim boundColumn As Telerik.Web.UI.GridBoundColumn
            Try
                If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.Display = False
                End If
            Catch ex As Exception
            End Try
            Try
                If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.Display = False
                End If
            Catch ex As Exception
            End Try
            Try
                If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.Display = False
                End If
            Catch ex As Exception
            End Try
            Try
                If e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") > 0 Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.Display = False
                End If
            Catch ex As Exception
            End Try
            Try
                If e.Column.UniqueName.ToString() = "Job" Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.Display = False
                End If
            Catch ex As Exception
            End Try
            Try
                If e.Column.UniqueName.ToString().IndexOf("Hours Assigned") > -1 Or e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 Or e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 Or e.Column.UniqueName.ToString().IndexOf("Total") > -1 Or e.Column.UniqueName.ToString().IndexOf("/") > -1 Then
                    boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                    boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                    boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    boundColumn.FooterStyle.HorizontalAlign = HorizontalAlign.Right
                    Try
                        boundColumn.DataFormatString = "{0:0.00}"
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
            End Try
            Try
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                If boundColumn.Display = True And boundColumn.UniqueName <> "Project" And boundColumn.UniqueName <> "Project Start Date" And boundColumn.UniqueName <> "Project End Date" And boundColumn.UniqueName <> "Status" _
                        And boundColumn.UniqueName <> "Job" And boundColumn.UniqueName <> "Component" And boundColumn.UniqueName <> "EMP_CODE" And boundColumn.UniqueName <> "Employee" And boundColumn.UniqueName <> "Office" And boundColumn.UniqueName <> "Department" And boundColumn.UniqueName <> "Hours Available (Adj)" _
                        And e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") <= 0 And e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") <= 0 And e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") <= 0 _
                        And e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") <= 0 Then
                    boundColumn.Aggregate = GridAggregateFunction.Sum
                    boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    boundColumn.FooterStyle.HorizontalAlign = HorizontalAlign.Right
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub RadGridAllocationJob_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAllocationJob.ItemDataBound
        'hide emp_code
        Try
            ' e.Item.Cells(2).Visible = False
            e.Item.Cells(3).Visible = False
            e.Item.Cells(4).Visible = False
            e.Item.Cells(5).Visible = False
            e.Item.Cells(6).Visible = False
            e.Item.Cells(7).Visible = False
            e.Item.Cells(8).Visible = False
            e.Item.Cells(9).Visible = False
        Catch ex As Exception
        End Try
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                If e.Item.Cells(11).Text <> "" Then
                    e.Item.Cells(11).Text = LoGlo.FormatDate(e.Item.Cells(11).Text)
                End If
                If e.Item.Cells(12).Text <> "" Then
                    e.Item.Cells(12).Text = LoGlo.FormatDate(e.Item.Cells(12).Text)
                End If
                'If e.Item.Cells(2).Text <> "" Then
                '    e.Item.Cells(2).Text = e.Item.Cells(2).Text.PadLeft(6, "0")
                'End If
                'If e.Item.Cells(3).Text <> "" Then
                '    e.Item.Cells(3).Text = e.Item.Cells(3).Text.PadLeft(2, "0")
                'End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridAllocationJob_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAllocationJob.NeedDataSource
        Try
            Dim empcode As String = ""
            Dim empname As String = ""
            Dim dr As SqlDataReader
            Dim cEmp As New cEmployee(Session("ConnString"))
            SetAppVarsApplication()
            Dim r As New cResources
            Dim ThisLevel As cResources.SummaryLevel
            Dim LoadIt As Boolean = True
            oAppVars.getAllAppVars()
            If Me.IsPostBack Or Me.IsCallback Then
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                Select Case RadioButtonListAllocationLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select
                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocation.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        empcode = gridDataItem.Cells(2).Text
                        empname = gridDataItem.Cells(3).Text
                        Session("CalendarPageViewEmpCode") = empcode
                    End If
                Next

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 6 Or empcode = "" Then
                    LoadIt = False
                End If

                If LoadIt = True Then
                    oAppVars.getAllAppVars()
                    Dim dt As New DataTable
                    dt = r.GetAllocationDatatableJob(empcode, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            Me.RadGridAllocationJob.DataSource = dt
                            Me.ButtonExportAllocation.Enabled = True
                            Me.LabelAllocation.Visible = False
                            'Me.GridView1.DataSource = dt
                            'Me.GridView1.DataBind()
                            If Me.RadComboBoxEmployeeAllocation.SelectedValue = "%" Then
                                Me.ButtonAll.Visible = True
                            End If
                        Else
                            Me.ButtonExportAllocation.Enabled = False
                            Me.LabelAllocation.Visible = True
                        End If
                    Else
                        Me.ButtonExportAllocation.Enabled = False
                        Me.LabelAllocation.Visible = True
                    End If
                    If empcode = "" Then
                        Me.PanelEmployeeAllocation.Visible = False
                    Else
                        Me.PanelEmployeeAllocation.Visible = True
                        Me.LabelEmployeeAllocation.Visible = True
                        Me.RadBinaryImage2.Visible = True
                        dr = cEmp.GetEmployeeProfile(empcode)
                        If dr.HasRows Then
                            dr.Read()
                            If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                                If IsDBNull(dr("EMP_IMAGE")) = False Then
                                    Dim FileBytes() As Byte = CType(dr("EMP_IMAGE"), Byte())
                                    Me.RadBinaryImage2.DataValue = FileBytes
                                Else
                                    Me.RadBinaryImage2.ImageUrl = "Images/NoImage.png"
                                End If
                            Else
                                Me.RadBinaryImage2.Visible = False
                            End If
                            If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then
                                If IsDBNull(dr("EMP_FNAME")) = False Then
                                    Me.LabelEmployeeAllocation.Text = dr("EMP_FNAME")
                                Else
                                    Me.LabelEmployeeAllocation.Text = ""
                                End If
                            ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then
                                If IsDBNull(dr("EMP_NICKNAME")) = False Then
                                    Me.LabelEmployeeAllocation.Text = dr("EMP_NICKNAME")
                                Else
                                    Me.LabelEmployeeAllocation.Text = ""
                                End If
                            End If
                            dr.Close()
                        End If
                    End If

                    Dim dsTotals As DataSet
                    Dim DtTotals As New DataTable
                    ThisLevel = cResources.SummaryLevel.Day
                    dsTotals = r.GetAvailabilityDataSet(empcode, Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))), Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))), ThisLevel, "", oAppVars.getAppVar("tcal_departs"), True)
                    DtTotals = dsTotals.Tables(1)
                    Try
                        If DtTotals.Rows.Count > 0 Then
                            Dim StdHrsAvail As Decimal = CType(0.0, Decimal)
                            Dim HrsAppts As Decimal = CType(0.0, Decimal)
                            Dim HrsOff As Decimal = CType(0.0, Decimal)
                            Dim HrsAssignedToTasks As Decimal = CType(0.0, Decimal)
                            Dim TotalAssignmentsHours As Decimal = CType(0.0, Decimal)
                            Dim Variance As Decimal = CType(0.0, Decimal)
                            Dim DirectHours As Decimal = CType(0.0, Decimal)
                            Dim PercDirect As Decimal = CType(0.0, Decimal)
                            If Not IsDBNull(DtTotals.Rows(0)("STD_HRS_AVAIL")) Then
                                If IsNumeric(DtTotals.Rows(0)("STD_HRS_AVAIL")) = True Then
                                    StdHrsAvail = CType(DtTotals.Rows(0)("STD_HRS_AVAIL"), Decimal)
                                End If
                            End If
                            Me.lblTotalHoursEmpAvailableAllocationNum.Text = FormatNumber(StdHrsAvail, 2, TriState.True, TriState.True, TriState.False)

                            If Not IsDBNull(DtTotals.Rows(0)("HRS_APPTS")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_APPTS")) = True Then
                                    HrsAppts = CType(DtTotals.Rows(0)("HRS_APPTS"), Decimal)
                                End If
                            End If
                            Me.lblTotalAppointmentHoursAllocationNum.Text = FormatNumber(HrsAppts, 2, TriState.True, TriState.True, TriState.False)

                            If Not IsDBNull(DtTotals.Rows(0)("HRS_USED_NON_TASK")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_USED_NON_TASK")) = True Then
                                    HrsOff = CType(DtTotals.Rows(0)("HRS_USED_NON_TASK"), Decimal)
                                End If
                            End If
                            Me.lblTotalHoursOffEmpAllocationNum.Text = FormatNumber(HrsOff, 2, TriState.True, TriState.True, TriState.False)

                            If Not IsDBNull(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) Then
                                If IsNumeric(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) = True Then
                                    TotalAssignmentsHours = CType(DtTotals.Rows(0)("HRS_ASSIGNED_TASK"), Decimal)
                                End If
                            End If
                            Me.lblTotalHoursAssignedAllocationNum.Text = FormatNumber(TotalAssignmentsHours, 2, TriState.True, TriState.True, TriState.False)

                            Variance = StdHrsAvail - HrsOff - TotalAssignmentsHours - HrsAppts
                            Me.lblVarianceEmpAllocationNum.Text = FormatNumber(Variance, 2, TriState.True, TriState.True, TriState.False)
                            If Variance < 0 Then
                                Me.lblVarianceEmpAllocationNum.ForeColor = Color.Red
                            End If

                            If Not IsDBNull(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) Then
                                If IsNumeric(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) = True Then
                                    DirectHours = CType(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                                End If
                            End If

                            If DirectHours > 0 Then
                                PercDirect = (TotalAssignmentsHours / DirectHours) * 100
                                Me.lblDirectHoursGoalAllocationNum.Text = FormatNumber(PercDirect, 2, TriState.True, TriState.True, TriState.False)
                            End If

                        End If
                    Catch ex As Exception
                    End Try

                    Dim Emp_lbl As String = Me.ddEmployee.SelectedItem.Text
                    If Emp_lbl = "%" Or Emp_lbl = "All Employees" Then
                        Me.lblEmployeeAllocation.Text = "Employee Jobs for " & empname & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                    Else
                        Me.lblEmployeeAllocation.Text = "Employee Jobs for " & Emp_lbl & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                    End If

                End If
                'End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridAllocationDepartment_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridAllocationDepartment.ColumnCreated
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("Hours Assigned") > -1 Or e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 Or e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 Or e.Column.UniqueName.ToString().IndexOf("Total") > -1 Or e.Column.UniqueName.ToString().IndexOf("/") > -1 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                Try
                    boundColumn.DataFormatString = "{0:0.00}"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridAllocationDepartment_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridAllocationDepartment.ItemDataBound
        Try
            Try
                e.Item.Cells(2).Visible = False
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAllocationDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridAllocationDepartment.SelectedIndexChanged
        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocation.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    gridDataItem.Selected = False
                End If
            Next
            Me.RadGridAllocation.Visible = True
            Me.PanelAllocationEmployee.Visible = True
            Me.RadGridAllocationJob.Visible = False

            Me.lblTotalHoursEmpAvailableAllocation.Visible = False
            Me.lblTotalHoursAssignedAllocation.Visible = False
            Me.lblTotalHoursOffEmpAllocation.Visible = False
            Me.lblVarianceEmpAllocation.Visible = False
            Me.lblTotalHoursEmpAvailableAllocationNum.Visible = False
            Me.lblTotalHoursAssignedAllocationNum.Visible = False
            Me.lblTotalHoursOffEmpAllocationNum.Visible = False
            Me.lblTotalAppointmentHoursAllocation.Visible = False
            Me.lblTotalAppointmentHoursAllocationNum.Visible = False
            Me.lblVarianceEmpAllocationNum.Visible = False
            Me.lblDirectHoursGoalAllocation.Visible = False
            Me.lblDirectHoursGoalAllocationNum.Visible = False
            Me.ImageButtonExport.Visible = False
            Me.LabelEmployeeAllocation.Visible = False
            Me.lblEmployeeAllocation.Visible = False
            Me.RadBinaryImage2.Visible = False

            Me.RadGridAllocation.Rebind()
            Me.RadGridAllocation.Focus()
            Me.RadGridWrapper.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAllocationDepartment_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridAllocationDepartment.NeedDataSource
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RadioButtonListAllocationLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select

                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 6 Then
                    LoadIt = False
                End If
                If LoadIt = True Then

                    oAppVars.getAllAppVars()

                    Dim dt As New DataTable
                    dt = r.GetAllocationDatatableDept(Me.RadComboBoxEmployeeAllocation.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            Me.RadGridAllocationDepartment.DataSource = dt
                            Me.ButtonExportAllocation.Enabled = True
                            Me.LabelAllocation.Visible = False
                            'Me.GridView1.DataSource = dt
                            'Me.GridView1.DataBind()
                            If Me.RadComboBoxEmployeeAllocation.SelectedValue = "%" Then
                                Me.ButtonAllAllocation.Visible = True
                            End If
                        Else
                            Me.ButtonExportAllocation.Enabled = False
                            Me.LabelAllocation.Visible = True
                        End If
                    Else
                        Me.ButtonExportAllocation.Enabled = False
                        Me.LabelAllocation.Visible = True
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridAllDept_NeedDataSource(sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date")))
                Dim et As Date = Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RadioButtonListAllocationLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select

                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 6 Then
                    LoadIt = False
                End If
                If LoadIt = True Then

                    oAppVars.getAllAppVars()

                    Dim dt As New DataTable
                    dt = r.GetAllocationDatatableDept(Me.RadComboBoxEmployeeAllocation.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True)
                    sender.Datasource = dt
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub RadGridAllDept_ItemDataBound(sender As Object, e As GridItemEventArgs)
        Try
            Try
                e.Item.Cells(2).Visible = False
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridAllDept_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs)
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_PERC_WORKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("Hours Assigned") > -1 Or e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 Or e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 Or e.Column.UniqueName.ToString().IndexOf("Total") > -1 Or e.Column.UniqueName.ToString().IndexOf("/") > -1 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                Try
                    boundColumn.DataFormatString = "{0:0.00}"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RadGridAllDept_OnExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs)
        Try
            Dim boundColumn As Telerik.Web.UI.GridBoundColumn
            If e.FormattedColumn.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.FormattedColumn, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridWrapper_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridWrapper.NeedDataSource
        Try
            RadGridWrapper.DataSource = New String() {" "}
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ButtonExportAllocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportAllocation.Click
        Try
            IsExport = True
            If Me.RadGridAllocation.Visible = False Then

                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAssignments, "")
                Me.RadGridAllocationDepartment.MasterTableView.ExportToExcel()

            Else

                Me.Panel1.Visible = True
                Me.RadGridWrapper.Rebind()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridWrapper, "")
                Me.RadGridWrapper.MasterTableView.ExportToExcel()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonAllAllocation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAllAllocation.Click
        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocationDepartment.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    gridDataItem.Selected = False
                End If
            Next
            Me.PanelAllocationEmployee.Visible = True
            Me.RadGridAllocation.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadContextMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadContextMenu1.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex2"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAllocationJob.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("Job")) = False Then
                        job = gridDataItem.GetDataKeyValue("Job")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("Component")) = False Then
                        comp = gridDataItem.GetDataKeyValue("Component")
                    End If
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"

                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)

                Case "PS"

                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Filter"

    Private Sub SetLookUps()
        If Me.IsClientPortal = True Then
            Me.hlDivision.Attributes.Add("onclick", "FocusTB('" & Me.txtDivision.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "FocusTB('" & Me.txtProduct.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?cp=1&calledfrom=custom&form=calendarfilter&type=product&control=" & Me.txtProduct.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

            Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtJobComp.ClientID & "');OpenRadWindowLookup('LookUp.aspx?cp=1&form=taskfilter&type=job&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
            Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?cp=1&form=taskfilter&type=jobcompjj&control=" & Me.txtJobComp.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
        Else
            Me.hlDivision.Attributes.Add("onclick", "FocusTB('" & Me.txtDivision.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "FocusTB('" & Me.txtProduct.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=calendarfilter&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

            Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtJobComp.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=taskfilter&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=taskfilter&type=jobcompjj&control=" & Me.txtJobComp.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
        End If
        Me.hlOffice.Attributes.Add("onclick", "FocusTB('" & Me.txtOffice.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=office&control=" & Me.txtOffice.ClientID & "&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
        Me.hlClient.Attributes.Add("onclick", "FocusTB('" & Me.txtClient.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=client&control=" & Me.txtClient.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value);return false;")


        Me.hlManager.Attributes.Add("onclick", "FocusTB('" & Me.txtManager.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtManager.ClientID & "&type=managers');return false;")
        Me.HlTrafficStatus.Attributes.Add("onclick", "FocusTB('" & Me.TxtTrafficStatusCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtTrafficStatusCode.ClientID & "&type=statuscodes');return false;")
        'MiscFN.AddCalendarIcon(Me.txtStartDate, Me.LitStartDate)
        'MiscFN.AddCalendarIcon(Me.txtEndDate, Me.LitEndDate)
    End Sub

    Private Sub SaveSettings(ByRef message As String)

        SetAppVarsApplication()
        oAppVars.getAllAppVars() 'All may not be in database

        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Try
            'If wvIsDate(Me.txtStartDate.Text.ToString()) = False Then
            '    Me.ShowMessage("Please enter a valid date for Start Date.")
            '    Exit Sub
            'End If
            'If wvIsDate(Me.txtEndDate.Text.ToString()) = False Then
            '    Me.ShowMessage("Please enter a valid date for End Date")
            '    Exit Sub
            'End If

            If Me.IsClientPortal = True Then
                oAppVars.setAppVar("tcal_emp", "")
            End If

            'If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
            '    If wvCDate(Me.RadDatePickerStartDate.SelectedDate) > wvCDate(Me.RadDatePickerEndDate.SelectedDate) Then
            '        message = "End Date must be greater than Start Date."
            '        Exit Sub
            '    End If
            '    If wvCDate(Me.RadDatePickerEndDate.SelectedDate).Subtract(wvCDate(Me.RadDatePickerStartDate.SelectedDate)).Days > 365 Then
            '        message = "Date range must be less than one year."
            '        Exit Sub
            '    End If
            'End If

            If Me.txtEmpCode.Text <> "" Then
                If oSec.CheckEmployees(Session("UserCode"), Me.txtEmpCode.Text) = False Then
                    message = "Access to this employee is not allowed."
                    Exit Sub
                End If
            End If
            If Me.txtManager.Text <> "" Then
                If oSec.CheckManagers(Session("UserCode"), Me.txtManager.Text) = False Then
                    message = "Access to this manager is not allowed."
                    Exit Sub
                End If
            End If

            'Filter Options
            oAppVars.setAppVar("tcal_office", Me.txtOffice.Text)
            oAppVars.setAppVar("tcal_client", Me.txtClient.Text)
            oAppVars.setAppVar("tcal_div", Me.txtDivision.Text)
            oAppVars.setAppVar("tcal_prod", Me.txtProduct.Text)
            oAppVars.setAppVar("tcal_jobno", Me.txtJob.Text)
            oAppVars.setAppVar("tcal_jobcomp", Me.txtJobComp.Text)

            oAppVars.setAppVar("tcal_roles_checked", Me.ChkRoles.Checked)
            oAppVars.setAppVar("tcal_roles_checked_func", Me.ChkFunctionRoles.Checked)
            Dim sSaveRoles As String = ""
            If Me.ChkRoles.Checked = True Then
                Try
                    sSaveRoles = Me.SaveRoles(Me.LbRoles)
                    'If sSaveRoles <> "" Then
                    '    sSaveRoles = sSaveRoles.Replace("'", "''")
                    'End If
                    oAppVars.setAppVar("tcal_roles", sSaveRoles)
                Catch ex As Exception
                    oAppVars.setAppVar("tcal_roles", "")
                End Try
            Else
                oAppVars.setAppVar("tcal_roles", "")
            End If

            If Me.ChkFunctionRoles.Checked = True Then
                Try
                    sSaveRoles = Me.SaveRoles(Me.lbFunctionRoles)
                    'If sSaveRoles <> "" Then
                    '    sSaveRoles = sSaveRoles.Replace("'", "''")
                    'End If
                    oAppVars.setAppVar("tcal_roles_func", sSaveRoles)
                Catch ex As Exception
                    oAppVars.setAppVar("tcal_roles_func", "")
                End Try
            Else
                oAppVars.setAppVar("tcal_roles_func", "")
            End If


            If Me.txtEmpCode.Text.Trim() = "" Then
                oAppVars.setAppVar("tcal_emp", "")
                'Session("tcal_emp") = ""
            Else
                oAppVars.setAppVar("tcal_emp", Me.txtEmpCode.Text.Trim())
                'Session("tcal_emp") = Me.txtEmpCode.Text
            End If

            oAppVars.setAppVar("tcal_includeunassigned", CStr(Me.CheckBoxIncludeUnassigned.Checked), "Boolean")

            oAppVars.setAppVar("tcal_taskstatus", Me.ddTaskStatus.SelectedValue)
            oAppVars.setAppVar("tcal_excludetempcomplete", CStr(Me.chkExcludeTempComplete.Checked), "Boolean")
            oAppVars.setAppVar("tcal_manager", Me.txtManager.Text)
            oAppVars.setAppVar("tcal_len", Me.ddSize.SelectedValue, "Number")
            oAppVars.setAppVar("show_client", CStr(Me.cbShowClient.Checked), "Boolean")
            'oAppVars.setAppVar("tcal_duration", CStr(Me.chkTaskDuration.Checked), "Boolean")
            oAppVars.setAppVar("tcal_milestone", CStr(Me.chkMilestone.Checked), "Boolean")
            oAppVars.setAppVar("tcal_trafficstatuscode", Me.TxtTrafficStatusCode.Text)

            'Display Options
            oAppVars.setAppVar("tcal_tclientcode", CStr(Me.chkClientCode.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tclientdesc", CStr(Me.chkClientDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tdivcode", CStr(Me.chkDivisionCode.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tdivdesc", CStr(Me.chkDivisionDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tprodcode", CStr(Me.chkProductCode.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tproddesc", CStr(Me.chkProductDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tjobnum", CStr(Me.chkJobNumber.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tjobdesc", CStr(Me.chkJobDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tjobcompnum", CStr(Me.chkComponentNumber.Checked), "Boolean")
            oAppVars.setAppVar("tcal_tjobcompdesc", CStr(Me.chkComponentDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_ttaskcode", CStr(Me.chkTaskCode.Checked), "Boolean")
            oAppVars.setAppVar("tcal_ttaskdesc", CStr(Me.chkTaskDesc.Checked), "Boolean")
            oAppVars.setAppVar("tcal_thoursallowed", CStr(Me.chkHoursAllowed.Checked), "Boolean")
            oAppVars.setAppVar("tcal_ttimedue", CStr(Me.chkTimeDue.Checked), "Boolean")
            oAppVars.setAppVar("tcal_empcodedispl", CStr(Me.chkEmpCodeDispl.Checked), "Boolean")
            oAppVars.setAppVar("tcal_empdescdispl", CStr(Me.chkEmpDescDispl.Checked), "Boolean")
            oAppVars.setAppVar("tcal_haemployeecode", CStr(Me.chkEmployeeCode.Checked), "Boolean")
            oAppVars.setAppVar("tcal_haemployeedesc", CStr(Me.chkEmployeeName.Checked), "Boolean")
            oAppVars.setAppVar("tcal_hatype", CStr(Me.chkType.Checked), "Boolean")
            oAppVars.setAppVar("tcal_hasubject", CStr(Me.chkSubject.Checked), "Boolean")
            oAppVars.setAppVar("tcal_hatimes", CStr(Me.chkTimes.Checked), "Boolean")
            oAppVars.setAppVar("tcal_hahours", CStr(Me.chkHours.Checked), "Boolean")
            oAppVars.setAppVar("tcal_hatimecat", CStr(Me.chkTimeCategory.Checked), "Boolean")
            oAppVars.setAppVar("tcal_haclientcode", CStr(Me.chkClientCodeHA.Checked), "Boolean")

            'Employee Display Options
            If Me.RadioButtonFirstName.Checked Then
                oAppVars.setAppVar("tcal_empdisplayname", "first")
            ElseIf Me.RadioButtonFullName.Checked Then
                oAppVars.setAppVar("tcal_empdisplayname", "full")
            End If
            oAppVars.setAppVar("tcal_empIncludeImage", CStr(Me.CheckBoxImage.Checked), "Boolean")

            'Workload options
            'If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing Then
            '    oAppVars.setAppVar("tcal_startdate", CStr(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), "Date")
            'End If
            'If Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
            '    oAppVars.setAppVar("tcal_enddate", CStr(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), "Date")
            'End If

            'Group Options
            'If Me.RadioButtonEmp.Checked = True Then
            '    oAppVars.setAppVar("tcal_groupby", "emp")
            'ElseIf Me.RadioButtonJob.Checked = True Then
            '    oAppVars.setAppVar("tcal_groupby", "job")
            'End If

            'oAppVars.setAppVar("tcal_appts", Me.TextBoxAppointments.Text)

            Dim i As Integer
            Dim count As Integer
            Dim depts As String
            Dim dept, departs As String
            For i = 0 To Me.lbDept.Items.Count - 1
                If Me.lbDept.Items(i).Selected = True Then
                    Session("tcal_dept" & i) = Me.lbDept.Items(i).Text
                    depts &= Me.lbDept.Items(i).Value & ","
                    count += 1
                Else
                    Session("tcal_dept" & i) = Nothing
                End If
            Next
            If Me.txtEmpCode.Text = "" Then
                Session("tcal_depts") = depts
            Else
                Session("tcal_depts") = ""
            End If

            departs = ""
            For i = 0 To Me.lbDept.Items.Count - 1
                If Me.lbDept.Items(i).Selected = True Then
                    dept = "'" & Me.lbDept.Items(i).Value & "'"
                    departs &= dept & ","
                End If
            Next

            ' take off last comma
            If departs <> "" Then
                departs = departs.Substring(0, departs.Length - 1)
            End If


            If Me.txtEmpCode.Text = "" And departs <> "'%'" Then
                'Session("tcal_departs") = departs
                oAppVars.setAppVar("tcal_departs", departs)
            Else
                'Session("tcal_departs") = ""
                oAppVars.setAppVar("tcal_departs", "")
            End If

            'Session("tcal_count") = count
            oAppVars.setAppVar("tcal_count", CStr(count), "Number")

            'Save all vars to database
            oAppVars.SaveAllAppVars()

            Me.SaveRoles(Me.LbRoles)
        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub SaveDateSettings(ByVal StartDate As Date?, ByVal EndDate As Date?)

        'objects
        Dim Security As Webvantage.cSecurity = Nothing

        SetAppVarsApplication()
        oAppVars.getAllAppVars() 'All may not be in database

        Security = New Webvantage.cSecurity(CStr(Session("ConnString")))

        Try

            If Not StartDate Is Nothing Then

                oAppVars.setAppVar("tcal_startdate", CStr(wvCDate(StartDate)), "Date")

            End If

            If Not EndDate Is Nothing Then

                oAppVars.setAppVar("tcal_enddate", CStr(wvCDate(EndDate)), "Date")

            End If

            'Save all vars to database
            oAppVars.SaveAllAppVars()

        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub LoadSettings()
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        Me.txtOffice.Text = oAppVars.getAppVar("tcal_office") 'Session("tcal_office")
        Me.txtClient.Text = oAppVars.getAppVar("tcal_client") 'Session("tcal_client")
        Me.txtDivision.Text = oAppVars.getAppVar("tcal_div") 'Session("tcal_div")
        Me.txtProduct.Text = oAppVars.getAppVar("tcal_prod") 'Session("tcal_prod")
        Me.txtJob.Text = oAppVars.getAppVar("tcal_jobno") 'Session("tcal_jobno")
        Me.txtJobComp.Text = oAppVars.getAppVar("tcal_jobcomp") 'Session("tcal_jobcomp")
        Try
            'If oAppVars.getAppVar("tcal_emp") = "" Then
            '    oAppVars.setAppVar("tcal_emp", Session("EmpCode"))
            'End If
            'If Session("tcal_emp") Is Nothing Then
            '    If Not Session("EmpCode") Is Nothing Then
            '        'Session("tcal_emp") = Session("EmpCode")
            '    Else
            '        'st: do we need to set both session vars here possibly?
            '        'ideally, yes, to be safe, but if existing code in other parts of application will log user out
            '        'then, don't need this "else" block
            '    End If
            'End If
        Catch ex As Exception
            Me.ShowMessage("Error: " & ex.Message.ToString())
        End Try

        Me.txtEmpCode.Text = oAppVars.getAppVar("tcal_emp") 'Session("tcal_emp")
        Me.CheckBoxIncludeUnassigned.Checked = CType(oAppVars.getAppVar("tcal_includeunassigned", "Boolean"), Boolean)

        Me.ddTaskStatus.SelectedValue = oAppVars.getAppVar("tcal_taskstatus")
        Me.chkExcludeTempComplete.Checked = CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean)
        Me.txtManager.Text = oAppVars.getAppVar("tcal_manager")
        Me.ddSize.SelectedValue = oAppVars.getAppVar("tcal_len", "Number")
        Me.cbShowClient.Checked = CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean)
        'Me.chkTaskDuration.Checked = CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean)
        Me.chkMilestone.Checked = CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean)
        Me.chkClientCode.Checked = CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean)
        Me.chkClientDesc.Checked = CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean)
        Me.chkDivisionCode.Checked = CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean)
        Me.chkDivisionDesc.Checked = CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean)
        Me.chkProductCode.Checked = CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean)
        Me.chkProductDesc.Checked = CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean)
        Me.chkJobNumber.Checked = CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean)
        Me.chkJobDesc.Checked = CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean)
        Me.chkComponentNumber.Checked = CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean)
        Me.chkComponentDesc.Checked = CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean)
        Me.chkTaskCode.Checked = CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean)
        Me.chkTaskDesc.Checked = CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean)
        Me.chkHoursAllowed.Checked = CType(oAppVars.getAppVar("tcal_thoursallowed", "Boolean"), Boolean)
        Me.chkTimeDue.Checked = CType(oAppVars.getAppVar("tcal_ttimedue", "Boolean"), Boolean)
        Me.chkEmpCodeDispl.Checked = CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean)
        Me.chkEmpDescDispl.Checked = CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean)
        Me.chkEmployeeCode.Checked = CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean)
        Me.chkEmployeeName.Checked = CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean)
        Me.chkType.Checked = CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean)
        Me.chkSubject.Checked = CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean)
        Me.chkTimes.Checked = CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean)
        Me.chkHours.Checked = CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean)
        Me.chkTimeCategory.Checked = CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean)
        Me.chkClientCodeHA.Checked = CType(oAppVars.getAppVar("tcal_haclientcode", "Boolean"), Boolean)
        Me.ChkRoles.Checked = CType(oAppVars.getAppVar("tcal_roles_checked", "Boolean"), Boolean)
        Me.CheckBoxImage.Checked = CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)
        'If oAppVars.getAppVar("tcal_groupby") = "emp" Then
        '    Me.RadioButtonEmp.Checked = True
        'ElseIf oAppVars.getAppVar("tcal_groupby") = "job" Then
        '    Me.RadioButtonJob.Checked = True
        'Else
        '    Me.RadioButtonEmp.Checked = True
        'End If
        If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then
            Me.RadioButtonFirstName.Checked = True
        ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then
            Me.RadioButtonFullName.Checked = True
        Else
            Me.RadioButtonFirstName.Checked = True
        End If

        Me.TxtTrafficStatusCode.Text = oAppVars.getAppVar("tcal_trafficstatuscode")
        'Me.TextBoxAppointments.Text = oAppVars.getAppVar("tcal_appts")
        'If Me.TextBoxAppointments.Text = "" Then
        '    Me.TextBoxAppointments.Text = "5"
        'End If

        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        Else
            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        End If

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))
        End If

        Dim i As Integer
        Dim count As Integer = oAppVars.getAppVar("tcal_count", "Number")

        'For i = 0 To Me.lbDept.Items.Count - 1
        '    If Not Session("tcal_Dept" & i) Is Nothing Then
        '        Me.lbDept.Items(i).Selected = True
        '    Else
        '        'Me.lbDept.Items(0).Selected = True
        '    End If
        'Next
        Try
            Dim dpts As String = ""
            dpts = oAppVars.getAppVar("tcal_departs")
            If dpts = "" Then
                Me.lbDept.Items(0).Selected = True
            Else
                dpts = dpts.Replace("'", "")
                Dim ar2() As String
                ar2 = dpts.Split(",")
                For w As Integer = 0 To ar2.Length - 1
                    Try
                        Me.lbDept.FindItemByValue(ar2(w)).Selected = True
                    Catch ex As Exception
                    End Try
                Next
                Me.lbDept.Items(0).Selected = False
            End If
        Catch ex As Exception

        End Try

        Try
            Dim rolescsv As String = ""
            rolescsv = oAppVars.getAppVar("tcal_roles")
            If Me.LbRoles.Items.Count > 0 Then
                If rolescsv = "" Then
                    Me.LbRoles.Items(0).Selected = True
                Else
                    rolescsv = rolescsv.Replace("'", "")
                    Dim ar() As String
                    ar = rolescsv.Split(",")
                    For h As Integer = 0 To ar.Length - 1
                        Try
                            Me.LbRoles.FindItemByValue(ar(h)).Selected = True
                        Catch ex As Exception
                        End Try
                    Next
                    Me.LbRoles.Items(0).Selected = False
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            Dim rolescsvfunc As String = ""
            rolescsvfunc = oAppVars.getAppVar("tcal_roles_func")
            If Me.lbFunctionRoles.Items.Count > 0 Then
                If rolescsvfunc = "" Then
                    Me.lbFunctionRoles.Items(0).Selected = True
                Else
                    rolescsvfunc = rolescsvfunc.Replace("'", "")
                    Dim ar() As String
                    ar = rolescsvfunc.Split(",")
                    For h As Integer = 0 To ar.Length - 1
                        Try
                            Me.lbFunctionRoles.FindItemByValue(ar(h)).Selected = True
                        Catch ex As Exception
                        End Try
                    Next
                    Me.lbFunctionRoles.Items(0).Selected = False
                End If
            End If
        Catch ex As Exception
        End Try

        Me.ChkRoles.Checked = oAppVars.getAppVar("tcal_roles_checked", "Boolean", "False")
        Me.ChkFunctionRoles.Checked = oAppVars.getAppVar("tcal_roles_checked_func", "Boolean", "False")
    End Sub

    Public Sub LoadLengths(Optional ByVal Selected As String = "500")
        Try
            Me.ddSize.Items.Clear()
            Me.ddSize.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("N/A", "500"))
            Me.ddSize.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("12", "12"))
            Me.ddSize.Items.Insert(2, New Telerik.Web.UI.RadComboBoxItem("18", "18"))
            Me.ddSize.Items.Insert(3, New Telerik.Web.UI.RadComboBoxItem("24", "24"))
            Me.ddSize.Items.Insert(4, New Telerik.Web.UI.RadComboBoxItem("30", "30"))
            Me.ddSize.SelectedValue = Selected
        Catch ex As Exception
            Me.ShowMessage("Error with LoadLengths: " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadDeptList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.lbDept.DataSource = oDropDowns.ddDepts()
        Me.lbDept.DataTextField = "Description"
        Me.lbDept.DataValueField = "Code"
        Me.lbDept.DataBind()
        Me.lbDept.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Depts", "%"))
        Me.lbDept.SelectionMode = ListSelectionMode.Multiple
    End Sub

    Private Sub ButtonFilterSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFilterSave.Click
        Dim ErrorMessage As String
        Try
            SaveSettings(ErrorMessage)

            If ErrorMessage <> "" Then
                Me.ShowMessage(ErrorMessage)
            End If

        Catch ex As Exception
            Me.ShowMessage("Error with Settings: " & ex.Message.ToString())
        End Try
    End Sub

    Public Sub LoadTasksFilter(Optional ByVal Selected As String = "")

        'objects
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        SetAppVarsApplication()
        oAppVars.getAllAppVars()
        Dim AllowGroupToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        Try

            UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

            For Each UserGroupSettingValue In UserGroupSettingValues

                Try

                    If UserGroupSettingValue = True Then

                        AllowGroupToViewOtherEmployees = True
                        Exit For

                    End If

                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            AllowGroupToViewOtherEmployees = False
        End Try

        If AllowGroupToViewOtherEmployees = False And oSec.GetEmpSecurity(Session("UserCode")) = 0 Then

            Me.txtEmpCode.Text = Session("EmpCode")
            Me.DivEmployeeCode.Visible = False
            Me.lbDept.Enabled = False

        Else

            Me.txtEmpCode.Text = Selected
            Me.DivEmployeeCode.Visible = True
            Me.butEmpCodeLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & txtEmpCode.ClientID.ToString() & "');return false;")

        End If

        If oAppVars.getAppVar("tcal_tclientcode") = "" Then

            Me.chkClientCode.Checked = True
            Me.chkJobNumber.Checked = True
            Me.chkTaskDesc.Checked = True
            Me.chkSubject.Checked = True
            Me.chkTimes.Checked = True

        End If

    End Sub

    Private Sub SetManagerLable()
        Dim SQL_STRING, MGR_CODE, MGR_TITLE As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper


        SQL_STRING = "Select AGY_SETTINGS_VALUE FROM AGY_SETTINGS Where AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            MGR_CODE = dr.GetValue(0).ToString
            dr.Close()

            SQL_STRING = "Select AGY_SETTINGS_VALUE FROM AGY_SETTINGS Where AGY_SETTINGS_CODE = '" & MGR_CODE & "'"
            dr.Read()
            MGR_TITLE = dr.GetValue(0).ToString
            dr.Close()

        Catch
            Err.Raise(Err.Number, "Class:taskassignments Routine:LoadLegend", Err.Description)
        Finally

        End Try

        If MGR_TITLE = "" Or MGR_TITLE Is Nothing Then
            MGR_TITLE = "Manager:"
        Else
            MGR_TITLE = MGR_TITLE & ":"
        End If

        Me.hlManager.Text = MGR_TITLE
    End Sub

    Public Function GetChecked(ByVal blnChecked As Boolean) As String
        If blnChecked = True Then
            Return False
        Else
            Return True
        End If
    End Function

    'Private Sub ShowMessage(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
    'Dim strScript As String
    'strScript = "<script type=""text/javascript"">alert ('" & strMessage & "');</script>"
    'If Not Page.IsStartupScriptRegistered("JSAlert") Then
    '    Page.RegisterStartupScript("JSAlert", strScript)
    'End If
    'End Sub

    Private Sub butClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butClear.Click
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        'Session.Remove("tcal_emp")
        oAppVars.setAppVar("tcal_office", "")
        oAppVars.setAppVar("tcal_client", "")
        oAppVars.setAppVar("tcal_div", "")
        oAppVars.setAppVar("tcal_prod", "")
        oAppVars.setAppVar("tcal_jobno", "")
        oAppVars.setAppVar("tcal_jobcomp", "")
        oAppVars.setAppVar("tcal_manager", "")
        oAppVars.setAppVar("tcal_taskstatus", "")
        oAppVars.setAppVar("tcal_trafficstatuscode", "")
        oAppVars.setAppVar("tcal_excludetempcomplete", "False", "Boolean")
        oAppVars.setAppVar("tcal_milestone", "False", "Boolean")
        ''oAppVars.setAppVar("tcal_role", "")
        'oAppVars.setAppVar("tcal_roles", "")
        'oAppVars.setAppVar("tcal_roles_checked", "False", "Boolean")
        'oAppVars.setAppVar("tcal_len", "0", "Number")
        'oAppVars.setAppVar("show_client", "False", "Boolean")
        'oAppVars.setAppVar("tcal_duration", "False", "Boolean")

        ' ''Display Options
        'oAppVars.setAppVar("tcal_tclientcode", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tclientdesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tdivcode", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tdivdesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tprodcode", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tproddesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tjobnum", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tjobdesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tjobcompnum", "False", "Boolean")
        'oAppVars.setAppVar("tcal_tjobcompdesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_ttaskcode", "False", "Boolean")
        'oAppVars.setAppVar("tcal_ttaskdesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_empcodedispl", "False", "Boolean")
        'oAppVars.setAppVar("tcal_empdescdispl", "False", "Boolean")
        'oAppVars.setAppVar("tcal_haemployeecode", "False", "Boolean")
        'oAppVars.setAppVar("tcal_haemployeedesc", "False", "Boolean")
        'oAppVars.setAppVar("tcal_hatype", "False", "Boolean")
        'oAppVars.setAppVar("tcal_hasubject", "False", "Boolean")
        'oAppVars.setAppVar("tcal_hatimes", "False", "Boolean")
        'oAppVars.setAppVar("tcal_hahours", "False", "Boolean")
        'oAppVars.setAppVar("tcal_hatimecat", "False", "Boolean")
        'oAppVars.setAppVar("tcal_thoursallowed", "False", "Boolean")
        'oAppVars.setAppVar("tcal_ttimedue", "False", "Boolean")
        'oAppVars.setAppVar("tcal_roles", "")
        'oAppVars.setAppVar("tcal_roles_func", "")
        oAppVars.SaveAllAppVars()

        'Workload options
        'Session.Remove("tcal_depts")

        'Dim i As Integer
        'For i = 0 To Me.lbDept.Items.Count - 1
        '    If Not Session("tcal_Dept" & i) Is Nothing Then
        '        Session.Remove("tcal_Dept" & i)
        '    End If
        'Next

        'Me.lbDept.SelectedIndex = 0
        'Me.LbRoles.SelectedIndex = 0
        'Me.lbFunctionRoles.SelectedIndex = 0

        Me.txtOffice.Text = ""
        Me.txtClient.Text = ""
        Me.txtDivision.Text = ""
        Me.txtProduct.Text = ""
        Me.txtJob.Text = ""
        Me.txtJobComp.Text = ""
        Me.txtManager.Text = ""
        'Me.txtEmpCode.Text = ""
        Me.chkExcludeTempComplete.Checked = False
        'Me.chkTaskDuration.Checked = False
        'Me.cbShowClient.Checked = False
        Me.chkMilestone.Checked = False
        'Me.ChkRoles.Checked = False
        'Me.ChkFunctionRoles.Checked = False
        Me.TxtTrafficStatusCode.Text = ""
        Me.ddTaskStatus.SelectedValue = ""

        'Me.chkClientCode.Checked = False
        'Me.chkClientDesc.Checked = False
        'Me.chkDivisionCode.Checked = False
        'Me.chkDivisionDesc.Checked = False
        'Me.chkProductCode.Checked = False
        'Me.chkProductDesc.Checked = False
        'Me.chkJobNumber.Checked = False
        'Me.chkJobDesc.Checked = False
        'Me.chkComponentNumber.Checked = False
        'Me.chkComponentDesc.Checked = False
        'Me.chkTaskCode.Checked = False
        'Me.chkTaskDesc.Checked = False
        'Me.chkEmpCodeDispl.Checked = False
        'Me.chkEmpDescDispl.Checked = False
        'Me.chkEmployeeCode.Checked = False
        'Me.chkEmployeeName.Checked = False
        'Me.chkHoursAllowed.Checked = False
        'Me.chkTimeDue.Checked = False
        'Me.chkType.Checked = False
        'Me.chkSubject.Checked = False
        'Me.chkTimes.Checked = False
        'Me.chkHours.Checked = False
        'Me.chkTimeCategory.Checked = False
        'Me.chkClientCodeHA.Checked = False



    End Sub

    Private Sub txtEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpCode.TextChanged
        SetAppVarsApplication()
        Try
            'Session("tcal_emp") = Me.txtEmpCode.Text.Trim()
            oAppVars.setAppVarDB("tcal_emp", Me.txtEmpCode.Text.Trim())
        Catch ex As Exception
            'Session("tcal_emp") = Session("EmpCode")
            oAppVars.setAppVarDB("tcal_emp", Session("EmpCode"))
        End Try

        If Me.txtEmpCode.Text = "" Then
            Me.lbDept.Enabled = True
            Me.lbDept.Items(0).Selected = True
        Else
            Me.lbDept.Enabled = False
            For i As Integer = 0 To Me.lbDept.Items.Count - 1
                Me.lbDept.Items(i).Selected = False
            Next
        End If
    End Sub


    Private Sub LoadRoles(ByRef RolesListBox As Telerik.Web.UI.RadListBox)
        Dim d As New cDropDowns(Session("ConnString"))
        With RolesListBox
            .DataSource = d.GetRolesByDesc()
            .DataTextField = "ROLE_DESC"
            .DataValueField = "Code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Roles", ""))
        End With
    End Sub

    Private Function SaveRoles(ByRef RolesListBox As Telerik.Web.UI.RadListBox) As String
        Dim SbRoles As New System.Text.StringBuilder
        Dim str As String = ""
        If RolesListBox.Items(0).Selected = True Then
            str = ""
        Else
            For i As Integer = 0 To RolesListBox.Items.Count - 1
                If i > 0 And RolesListBox.Items(i).Selected = True Then
                    With SbRoles
                        .Append("'")
                        .Append(RolesListBox.Items(i).Value)
                        .Append("',")
                    End With
                End If
            Next
            str = SbRoles.ToString()
            str = MiscFN.CleanStringForSplit(str, ",")
        End If
        Return str
    End Function

    Private Sub ChkRoles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkRoles.CheckedChanged
        'Session("tcal_roles_checked") = Me.ChkRoles.Checked
        If Me.ChkRoles.Checked = True Then
            Me.LbRoles.Enabled = True
            Me.lbFunctionRoles.Enabled = True
        Else
            Me.LbRoles.Enabled = False
            Me.lbFunctionRoles.Enabled = False
            For i As Integer = 0 To Me.LbRoles.Items.Count - 1
                Me.LbRoles.Items(i).Selected = False
            Next
            For i As Integer = 0 To Me.lbFunctionRoles.Items.Count - 1
                Me.lbFunctionRoles.Items(i).Selected = False
            Next
            'Session("tcal_roles") = ""
        End If
    End Sub

    Private Sub ChkFunctionRoles_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkFunctionRoles.CheckedChanged
        If Me.ChkFunctionRoles.Checked = True Then
            Me.lbFunctionRoles.Enabled = True
        Else
            Me.lbFunctionRoles.Enabled = False
            For i As Integer = 0 To Me.lbFunctionRoles.Items.Count - 1
                Me.lbFunctionRoles.Items(i).Selected = False
            Next
            'Session("tcal_roles") = ""
        End If
    End Sub

    Private Sub RadButtonWorkloadRefreshDates_Click(sender As Object, e As EventArgs) Handles RadButtonWorkloadRefreshDates.Click

        SaveDateSettings(Me.RadDatePickerWorkloadStartDate.SelectedDate, Me.RadDatePickerWorkloadEndDate.SelectedDate)

        Dim message As String = ""
        If Not Me.RadDatePickerWorkloadStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerWorkloadEndDate.SelectedDate Is Nothing Then
            If wvCDate(Me.RadDatePickerWorkloadStartDate.SelectedDate) > wvCDate(Me.RadDatePickerWorkloadEndDate.SelectedDate) Then
                message = "End Date must be greater than Start Date."
                Me.ShowMessage(message)
                Exit Sub
            End If
            If wvCDate(Me.RadDatePickerWorkloadEndDate.SelectedDate).Subtract(wvCDate(Me.RadDatePickerWorkloadStartDate.SelectedDate)).Days > 365 Then
                message = "Date range must be less than one year."
                Me.ShowMessage(message)
                Exit Sub
            End If
        End If

        RadGridWorkload.Rebind()

    End Sub

    Private Sub RadGridAvailability_ExcelExportCellFormatting(sender As Object, e As ExcelExportCellFormattingEventArgs) Handles RadGridAvailability.ExcelExportCellFormatting

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        GridDataItem = DirectCast(e.Cell.Parent, Telerik.Web.UI.GridDataItem)

        If GridDataItem.ItemType = GridItemType.Item OrElse GridDataItem.ItemType = GridItemType.AlternatingItem Then

            If Not String.IsNullOrWhiteSpace(e.Cell.CssClass) Then

                Select Case e.Cell.CssClass.ToUpper

                    Case "standard-green-100".ToUpper

                        e.Cell.Style("background-color") = "#C8E6C9"

                    Case "standard-red-100".ToUpper

                        e.Cell.Style("background-color") = "#FFCDD2"

                    Case "standard-yellow-100".ToUpper

                        e.Cell.Style("background-color") = "#FFF9C4"

                End Select

            End If

        End If

    End Sub



#End Region

#Region "Actualization"

    Private _ZeroHoursColorCSSAct As String = "standard-white"
    Private _LessThanHoursColorCSSAct As String = "standard-light-green"
    Private _LessThanAndGreaterThanHoursColorCSSAct As String = "standard-yellow-100"
    Private _GreaterThanHoursColorCSSAct As String = "standard-red-100"

    Private Sub LoadActualizationOptions()
        Me.txtTasksAct.Visible = False
        Me.TextBox3.Visible = False
        Me.TextBox4.Visible = False
        Me.TextBox5.Visible = False
        Me.TextBoxAllocationTasks.Visible = False
        Me.TextBoxAllocationAppointments.Visible = False
        Me.TextBoxAllocationHours.Visible = False
        Me.TextBoxAllocationEvent.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.LabelAllocationTasks.Visible = False
        Me.LabelAllocationAppointments.Visible = False
        Me.LabelAllocationHours.Visible = False
        Me.LabelAllocationEvent.Visible = False
        Me.RblAvailabilitySummaryLevel.Items(1).Selected = True
        LoadEmployeeListAct()
        LoadTasksAct()
        LoadLegendAct()
        oAppVars.setAppVar("Assignments", "True", "Boolean")
        oAppVars.setAppVar("Available", "True", "Boolean")
        oAppVars.SaveAllAppVars()

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String

        Try
            If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning") <> "" Then
                Me.CheckBoxOmit.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning"), Boolean)
            End If
            If otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent") <> "" Then
                Me.CheckBoxShowPercent.Checked = CType(otask.getAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent"), Boolean)
            End If
        Catch ex As Exception

        End Try
        EnableOrDisableActualizationOptions()
    End Sub

    Private Sub LoadLegendAct()

        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivZeroHoursColorAct, _ZeroHoursColorCSSAct)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLessThanHoursColorAct, _LessThanHoursColorCSSAct)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivLessThanAndGreaterThanHoursColorAct, _LessThanAndGreaterThanHoursColorCSSAct)
        AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(Me.DivGreaterThanHoursColorAct, _GreaterThanHoursColorCSSAct)

        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_UNDER_PCT_DIRECT';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanPercentageAct.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanPercentageAct.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_PROP_PCT_DIRECT';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThanAct.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThanAct.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_PROP_PCT_TOTAL';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThanAct.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThanAct.Value = 0
        Finally
            dr.Close()
        End Try

        SQL_STRING = "SELECT ISNULL(AGY_SETTINGS_VALUE,'0') FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'EAG_OVER_PCT_TOTAL';"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            dr.Read()
            Me.RadNumericTextBoxGreaterThanHoursAct.Value = CType(dr.GetValue(0), Double)
        Catch
            Me.RadNumericTextBoxGreaterThanHoursAct.Value = 0
        Finally
            dr.Close()
        End Try

    End Sub
    Private Sub LoadEmployeeListAct()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim SQL_FROM As String
        Dim SQL_WHERE As String
        Dim dr As SqlDataReader
        Dim restrictions As Integer
        Dim userid, roles, depts, empcode As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        userid = Session("UserCode")
        roles = oAppVars.getAppVar("tcal_roles")      'Session("tcal_role")
        empcode = oAppVars.getAppVar("tcal_emp")    '
        depts = oAppVars.getAppVar("tcal_departs")
        'depts = oAppVars.getAppVarDB("tcal_departs")  '

        SQL_STRING = "Select Count(*) FROM SEC_EMP Where USER_ID = '" & userid & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:taskassignments Routine:LoadEmployeeList", Err.Description)
        Finally

        End Try

        Do While dr.Read
            restrictions = dr.GetInt32(0)
        Loop

        dr.Close()


        Dim Employeeoffice As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList
        End Using

        SQL_STRING = "SELECT DISTINCT EMPLOYEE.EMP_CODE as Code, EMPLOYEE.EMP_CODE " & " + ' - ' + " & " isnull(EMPLOYEE.EMP_LNAME, EMPLOYEE.EMP_CODE) + " & "', '" & " + isnull(EMPLOYEE.EMP_FNAME, '') AS Description "
        SQL_FROM = " FROM EMPLOYEE "
        SQL_WHERE = " Where (EMP_TERM_DATE Is NULL) "

        If restrictions > 0 Then
            SQL_FROM = SQL_FROM & "Inner JOIN SEC_EMP On EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE "
            SQL_WHERE = SQL_WHERE & " And SEC_EMP.USER_ID = '" & userid & "'"
        End If

        If roles <> Nothing Then
            SQL_FROM = SQL_FROM & "Inner JOIN EMP_TRAFFIC_ROLE ON EMPLOYEE.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE "
            SQL_WHERE = SQL_WHERE & " AND EMP_TRAFFIC_ROLE.ROLE_CODE IN (" & roles & ")"
        End If

        If Employeeoffice IsNot Nothing AndAlso Employeeoffice.Count > 0 Then
            SQL_FROM = SQL_FROM & "Inner JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & _Session.User.EmployeeCode & "'"
        End If

        If empcode <> Nothing Then
            SQL_WHERE = SQL_WHERE & " And EMPLOYEE.EMP_CODE = '" & empcode & "' "
        End If

        If depts <> Nothing Then
            SQL_WHERE = SQL_WHERE & " And EMPLOYEE.DP_TM_CODE IN (" & depts & ") "
        End If

        SQL_STRING = SQL_STRING & SQL_FROM & SQL_WHERE

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:taskassignments Routine:LoadEmployeeList", Err.Description)
        Finally

        End Try

        Me.ddEmployeeAct.Items.Clear()
        Me.ddEmployeeAct.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Employees", "%"))
        Me.RadComboBoxEmployeeAllocation.Items.Clear()
        Me.RadComboBoxEmployeeAllocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Employees", "%"))

        Dim idx As Integer
        Dim empdesc As String
        idx = 0
        Do While dr.Read
            idx = idx + 1
            empcode = dr.GetString(0)
            empdesc = dr.GetString(1)
            Me.ddEmployeeAct.Items.Insert(idx, New Telerik.Web.UI.RadComboBoxItem(empdesc, empcode))
            Me.RadComboBoxEmployeeAllocation.Items.Insert(idx, New Telerik.Web.UI.RadComboBoxItem(empdesc, empcode))
        Loop

        dr.Close()

    End Sub
    Public Sub LoadTasksAct(Optional ByVal Selected As String = "")

        'objects
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        SetAppVarsApplication()
        Dim AllowGroupToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        oAppVars.getAllAppVars()

        Try

            UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

            For Each UserGroupSettingValue In UserGroupSettingValues

                Try

                    If UserGroupSettingValue = True Then

                        AllowGroupToViewOtherEmployees = True
                        Exit For

                    End If

                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            AllowGroupToViewOtherEmployees = False
        End Try

        If AllowGroupToViewOtherEmployees = False Then
            Me.ddEmployeeAct.SelectedValue = Session("EmpCode")
            Me.ddEmployeeAct.Visible = False
            Me.RadComboBoxEmployeeAllocation.SelectedValue = Session("EmpCode")
            Me.RadComboBoxEmployeeAllocation.Visible = False
        Else
            Me.ddEmployeeAct.SelectedValue = oAppVars.getAppVar("tcal_emp")
            Me.ddEmployeeAct.Visible = True
            Me.RadComboBoxEmployeeAllocation.SelectedValue = oAppVars.getAppVar("tcal_emp")
            Me.RadComboBoxEmployeeAllocation.Visible = True
        End If

        'If Session("tcal_startdate") Is Nothing Then
        If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
            'Session("tcal_startdate") = Now.AddDays(-15).ToShortDateString
            oAppVars.setAppVar("tcal_startdate", CType(Now.AddDays(-15).ToShortDateString, String), "Date")
        End If
        'If Session("tcal_enddate") Is Nothing Then
        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            'Session("tcal_enddate") = Now.AddDays(15).ToShortDateString
            oAppVars.setAppVar("tcal_enddate", CType(Now.AddDays(15).ToShortDateString, String), "Date")
        End If

        Dim empsPerDept As String
        Dim dt As DataTable
        'If CStr(Session("tcal_tclientcode")) = "" Then
        'dt = oTasks.GetWorkload(CStr(Session("UserCode")), CStr(Session("tcal_emp")), Now.Date.AddDays(-15.0), Now.Date.AddDays(15.0), "", "", "", "", "", "", "", "", False)
        'Me.lblWorkloadAnalysis.Text = "Workload Analysis for " & Now.Date.AddDays(-15.0) & " through " & Now.Date.AddDays(15.0)
        'Else
        empsPerDept = oTasks.GetEmpsPerDept(Session("tcal_depts"))

        'dt = oTasks.GetWorkload(CStr(Session("UserCode")), _
        '                        CStr(Session("tcal_emp")), _
        '                        Convert.ToDateTime(Session("tcal_startdate")), _
        '                        Convert.ToDateTime(Session("tcal_enddate")), _
        '                        CStr(Session("tcal_office")), _
        '                        CStr(Session("tcal_client")), _
        '                        CStr(Session("tcal_div")), _
        '                        CStr(Session("tcal_prod")), _
        '                        CStr(Session("tcal_jobno")), _
        '                        CStr(Session("tcal_jobcomp")), _
        '                        CStr(Session("tcal_role")), _
        '                        CStr(Session("tcal_taskstatus")), _
        '                        Session("tcal_excludetempcomplete"), _
        '                        CStr(Session("tcal_departs")), _
        '                        empsPerDept, _
        '                        CStr(Session("tcal_manager")))

        '''dt = oTasks.GetWorkload(CStr(Session("UserCode")), _
        '''                        CStr(Session("tcal_emp")), _
        '''                        Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), _
        '''                        Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")), _
        '''                        oAppVars.getAppVar("tcal_office"), _
        '''                        oAppVars.getAppVar("tcal_client"), _
        '''                        oAppVars.getAppVar("tcal_div"), _
        '''                        oAppVars.getAppVar("tcal_prod"), _
        '''                        oAppVars.getAppVar("tcal_jobno"), _
        '''                        oAppVars.getAppVar("tcal_jobcomp"), _
        '''                        oAppVars.getAppVar("tcal_role"), _
        '''                        oAppVars.getAppVar("tcal_taskstatus"), _
        '''                        oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean", "False"), _
        '''                        CStr(Session("tcal_departs")), _
        '''                        empsPerDept, _
        '''                        oAppVars.getAppVar("tcal_manager"))

        'Me.lblWorkloadAnalysis.Text = "Workload Analysis for " & Convert.ToDateTime(Session("tcal_startdate")) & " through " & Convert.ToDateTime(Session("tcal_enddate"))
        'If oAppVars.getAppVar("tcal_startdate", "Date") = "1/1/1900" Then
        '    Me.RadDatePickerActualizationStartDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(-15).ToShortDateString)
        'Else
        '    Me.RadDatePickerActualizationStartDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))
        'End If

        Dim FirstDayOfWeekDate As Date

        RadDatePickerActualizationStartDate.SelectedDate = Date.Now

        For i As Integer = 0 To 6 Step 1

            FirstDayOfWeekDate = CDate(RadDatePickerActualizationStartDate.SelectedDate).AddDays(-i)

            If FirstDayOfWeekDate.DayOfWeek = DayOfWeek.Sunday Then

                Exit For

            End If

        Next

        'Me.RadDatePickerActualizationStartDate.SelectedDate = FirstDayOfWeekDate

        ''RadDatePickerActualizationStartDate.MinDate = Date.Now 'PJH 08/12/2019 - Allow any dates

        If oAppVars.getAppVar("tcal_enddate", "Date") = "1/1/1900" Then
            Me.RadDatePickerActualizationEndDate.SelectedDate = LoGlo.FormatDate(Now.AddDays(15).ToShortDateString)
        Else
            Me.RadDatePickerActualizationEndDate.SelectedDate = LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))

            If Me.RadDatePickerActualizationEndDate.SelectedDate < Me.RadDatePickerActualizationStartDate.SelectedDate Then
                Me.RadDatePickerActualizationEndDate.SelectedDate = LoGlo.FormatDate(CDate(Me.RadDatePickerActualizationStartDate.SelectedDate).AddDays(15).ToShortDateString)
            End If
        End If
        'End If
        RefreshActualizationPanelHeaderTitle()

        '''Dim totalavailable As Decimal = Convert.ToDecimal(dt.Rows(0).Item(4)) - Convert.ToDecimal(dt.Rows(0).Item(7))

    End Sub
    Private Sub RefreshActualizationPanelHeaderTitle()

        Me.CollapsablePanel2.TitleText = "&nbsp;&nbsp;&nbsp;&nbsp;Actualization Analysis for " & Convert.ToDateTime(LoGlo.FormatDate(RadDatePickerActualizationStartDate.SelectedDate)) & " through " & Convert.ToDateTime(LoGlo.FormatDate(RadDatePickerActualizationEndDate.SelectedDate))

    End Sub
    Private Function GetDetailColumnsAct(ByVal startdate As Date, ByVal enddate As Date) As Integer

        Dim sum_level As String
        Dim idx_range As Integer

        ''''If Me.RadioButton1.Checked = True Then
        ''''    sum_level = "w"
        ''''End If

        ''''If Me.RadioButton2.Checked = True Then
        ''''    sum_level = "m"
        ''''End If

        If sum_level = "m" Then
            idx_range = DateDiff(DateInterval.Month, startdate, enddate)
        Else
            idx_range = DateDiff(DateInterval.WeekOfYear, startdate, enddate)
        End If

        Return idx_range


    End Function
    Public Function CreateHeaderText()

        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim sum_level As String = "w"
        Dim uname As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        ''''If Me.RadioButton1.Checked Then
        ''''    sum_level = "w"
        ''''End If
        ''''If Me.RadioButton2.Checked Then
        ''''    sum_level = "m"
        ''''End If

        ''''detail_count = Me.RadGrid2.Columns.Count

        If detail_count > 0 Then

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("OFFICE_CODE")
            boundColumn.DataField = "OFFICE_CODE"
            boundColumn.HeaderText = "Office"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("EMP_DESC")
            boundColumn.DataField = "EMP_DESC"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Employee"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DP_TM_CODE")
            boundColumn.DataField = "DP_TM_CODE"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Dept"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DIRECT_HRS_PER")
            boundColumn.DataField = "DIRECT_HRS_PER"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Direct Hours Goal %"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("HOURS_AVAIL")
            boundColumn.DataField = "HOURS_AVAIL"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Hours Available"

            ''''boundColumn = Me.RadGrid2.Columns.FindByDataField("DIR_HRS_GOAL")
            boundColumn.DataField = "DIR_HRS_GOAL"
            boundColumn.ReadOnly = True
            boundColumn.HeaderText = "Direct Hours Goal"

            'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
            'column_date = Convert.ToDateTime(Session("tcal_startdate"))
            'start_date = Convert.ToDateTime(Session("tcal_startdate"))
            detail_count = GetDetailColumnsAct(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
            column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
            start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

            'Dim aname As String
            'For idx = 1 To detail_count
            '    aname = Me.RadGrid2.MasterTableView.Columns.Item(idx).UniqueName
            '    aname = Me.RadGrid2.Columns.Item(idx).UniqueName
            'Next

            For idx = 1 To detail_count
                column_header = ""
                'boundColumn = New GridBoundColumn
                If sum_level = "w" Then
                    If idx > 1 Then
                        column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                    End If
                    date_day = DatePart(DateInterval.Day, column_date)
                    date_month = DatePart(DateInterval.Month, column_date)
                    date_year = DatePart(DateInterval.Year, column_date)
                    date_week = DatePart(DateInterval.WeekOfYear, column_date)

                    If (date_year > start_year And date_month = 1 And date_week = 1) Or idx = 1 Then
                        column_header = CStr(date_year) & Chr(13) & Chr(10)
                        start_year = date_year
                    End If
                    column_header = column_header & CStr(date_month) & "/" & CStr(date_day)

                    'boundColumn.HeaderText = CStr(column_header)

                Else
                    If idx > 1 Then
                        column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                    End If

                    date_day = DatePart(DateInterval.Day, column_date)
                    date_month = DatePart(DateInterval.Month, column_date)
                    date_year = DatePart(DateInterval.Year, column_date)

                    If (date_year > start_year And date_month = 1) Or idx = 1 Then
                        column_header = CStr(date_year) & Chr(13) & Chr(10)
                        start_year = date_year
                    End If

                    If idx = 1 Then
                        column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                    Else
                        column_header = column_header & CStr(date_month) & "/1"
                    End If

                    'boundColumn.HeaderText = CStr(column_header)
                End If

                'boundColumn.HeaderStyle.Width = Unit.Pixel(25)
                'boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                'boundColumn.HeaderStyle.VerticalAlign = VerticalAlign.Bottom
                'boundColumn.ItemStyle.Width = Unit.Pixel(25)
                'boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Left

                Column_UniqueName = "col" & CStr(idx)
                'boundColumn.DataField = Column_UniqueName
                boundColumn.ReadOnly = True
                ''''boundColumn = Me.RadGrid2.Columns.FindByDataField(Column_UniqueName)
                boundColumn.HeaderText = CStr(column_header)

            Next
        End If
    End Function
    Private Function DBStrAct(ByRef dr As SqlDataReader, ByVal Name As String) As String
        If IsDBNull(dr(Name)) = True Then
            Return ""
        Else
            Return CStr(dr(Name))
        End If
    End Function
    Public Function LoadAssignmentsActGrid(ByVal empcode As String, ByVal empname As String)
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim Emp_lbl As String = Me.ddEmployeeAct.SelectedItem.Text
        Dim r As New cResources
        Dim ThisLevel As cResources.SummaryLevel

        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        SetAppVarsApplication()

        oAppVars.getAllAppVars()

        'If Session("Assignments") = True Then
        If CType(oAppVars.getAppVar("Assignments"), Boolean) = True Then

            Dim ds As New DataSet
            Dim dsTotals As DataSet
            Dim DtTotals As New DataTable
            ThisLevel = cResources.SummaryLevel.Day
            dsTotals = r.GetActualizationDataSet(empcode, Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))), Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date"))), ThisLevel, "", oAppVars.getAppVar("tcal_departs"), True, "", "", "", "", "", "", "", "", False, "", "", 0, 0, "", False, Me.CheckBoxOmit.Checked)
            DtTotals = dsTotals.Tables(1)

            With Me.RadGridActAssignments
                .DataSource = dsTotals.Tables(4).DefaultView
                '  .DataBind()
            End With




            boundColumn = New Telerik.Web.UI.GridBoundColumn
            boundColumn = Me.RadGridActAssignments.Columns.FindByDataField("EMP_CODE")

            If Emp_lbl = "%" Or Emp_lbl = "All Employees" Then
                Me.lblEmployeeAct.Text = "Employee Assignments for " & empname & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                boundColumn.Visible = True
            Else
                Me.lblEmployeeAct.Text = "Employee Assignments for " & Emp_lbl & " for " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_startdate", "Date"))) & " through " & Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))
                boundColumn.Visible = True
            End If

            'redo the header total...
            Try
                If DtTotals.Rows.Count > 0 Then
                    Dim StdHrsAvail As Decimal = CType(0.0, Decimal)
                    Dim HrsAppts As Decimal = CType(0.0, Decimal)
                    Dim HrsOff As Decimal = CType(0.0, Decimal)
                    Dim HrsAssignedToTasks As Decimal = CType(0.0, Decimal)
                    Dim TotalAssignmentsHours As Decimal = CType(0.0, Decimal)
                    Dim Variance As Decimal = CType(0.0, Decimal)
                    Dim DirectHours As Decimal = CType(0.0, Decimal)
                    Dim PercDirect As Decimal = CType(0.0, Decimal)
                    If Not IsDBNull(DtTotals.Rows(0)("STD_HRS_AVAIL")) Then
                        If IsNumeric(DtTotals.Rows(0)("STD_HRS_AVAIL")) = True Then
                            StdHrsAvail = CType(DtTotals.Rows(0)("STD_HRS_AVAIL"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursEmpAvailableNumAct.Text = FormatNumber(StdHrsAvail, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_APPTS")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_APPTS")) = True Then
                            HrsAppts = CType(DtTotals.Rows(0)("HRS_APPTS"), Decimal)
                        End If
                    End If
                    Me.lblTotalAppointmentHoursNumAct.Text = FormatNumber(HrsAppts, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_USED_NON_TASK")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_USED_NON_TASK")) = True Then
                            HrsOff = CType(DtTotals.Rows(0)("HRS_USED_NON_TASK"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursOffEmpNumAct.Text = FormatNumber(HrsOff, 2, TriState.True, TriState.True, TriState.False)

                    If Not IsDBNull(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) Then
                        If IsNumeric(DtTotals.Rows(0)("HRS_ASSIGNED_TASK")) = True Then
                            TotalAssignmentsHours = CType(DtTotals.Rows(0)("HRS_ASSIGNED_TASK"), Decimal)
                        End If
                    End If
                    Me.lblTotalHoursAssignedNumAct.Text = FormatNumber(TotalAssignmentsHours, 2, TriState.True, TriState.True, TriState.False)

                    Variance = StdHrsAvail - HrsOff - TotalAssignmentsHours - HrsAppts
                    Me.lblVarianceEmpNumAct.Text = FormatNumber(Variance, 2, TriState.True, TriState.True, TriState.False)
                    If Variance < 0 Then
                        Me.lblVarianceEmpNum.ForeColor = Color.Red
                    End If

                    If Not IsDBNull(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) Then
                        If IsNumeric(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS")) = True Then
                            DirectHours = CType(DtTotals.Rows(0)("EMP_DIRECT_HRS_GOAL_HOURS"), Decimal)
                        End If
                    End If

                    If DirectHours > 0 Then
                        PercDirect = (TotalAssignmentsHours / DirectHours) * 100
                        Me.lblDirectHoursGoalNumAct.Text = FormatNumber(PercDirect, 2, TriState.True, TriState.True, TriState.False)
                    End If

                End If
            Catch ex As Exception
            End Try


        Else

        End If
    End Function

    'This is the "Assignments" button:
    Private Sub btnAssignmentsAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssignmentsAct.Click

        SetAppVarsApplication()

        Me.RblAvailabilitySummaryLevel.Visible = False
        Me.RadGridActualization.Visible = False

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        Dim Emp_lbl As String = Me.ddEmployeeAct.SelectedItem.Text
        Dim idx As Integer
        Dim total As Decimal
        Dim totalavailable As Decimal

        oAppVars.setAppVarDB("Assignments", "True", "Boolean")
        oAppVars.setAppVarDB("Available", "False", "Boolean")

        Me.RadGridActAssignments.Visible = True
        Me.lblTotalHoursEmpAvailableAct.Visible = True
        Me.lblTotalHoursAssignedAct.Visible = True
        Me.lblTotalHoursOffEmpAct.Visible = True
        Me.lblVarianceEmpAct.Visible = True
        Me.lblTotalHoursEmpAvailableNumAct.Visible = True
        Me.lblTotalHoursAssignedNumAct.Visible = True
        Me.lblTotalHoursOffEmpNumAct.Visible = True
        Me.lblVarianceEmpNumAct.Visible = True
        Me.lblDirectHoursGoalAct.Visible = True
        Me.lblDirectHoursGoalNumAct.Visible = True
        Me.imgbtnExport.Visible = True

        Me.txtTasksAct.Visible = False
        Me.TextBox3.Visible = True
        Me.TextBox4.Visible = True
        Me.TextBox5.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = True
        Me.Label22.Visible = True
        Me.Label23.Visible = False
        Me.CheckBox1.Visible = False
        Me.DivSummaryLevel.Visible = False
        Me.ButtonRefresh.Visible = False
        Me.DivLessThanHoursAct.Visible = False
        Me.DivZeroHoursAct.Visible = False
        Me.DivLessThanAndGreaterThanHoursAct.Visible = False
        Me.DivGreaterThanHoursAct.Visible = False
        Me.ButtonExportAct.Visible = False


        Dim empcode As String
        empcode = Me.ddEmployeeAct.SelectedValue.ToString
        If empcode = "%" Then
            empcode = ""
        End If

        oAppVars.getAllAppVars()

        Me.RadGridActAssignments.Visible = True
        Me.RadGridActualization.Visible = False
        Me.RadGridActAssignments.Rebind()

    End Sub

    'This is the "Availability" button:
    Private Sub btnAvailAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvailAct.Click

        SetAppVarsApplication()

        oAppVars.setAppVarDB("Assignments", "False", "Boolean")
        oAppVars.setAppVarDB("Available", "True", "Boolean")

        Me.RblActualizationSummaryLevel.Visible = True
        Me.RblActualizationSummaryLevel.Items(1).Selected = True 'pre-select weekly

        Me.RadGridActAssignments.Visible = False
        Me.lblTotalHoursEmpAvailableAct.Visible = False
        Me.lblTotalHoursAssignedAct.Visible = False
        Me.lblTotalHoursOffEmpAct.Visible = False
        Me.lblVarianceEmpAct.Visible = False
        Me.lblTotalHoursEmpAvailableNumAct.Visible = False
        Me.lblTotalHoursAssignedNumAct.Visible = False
        Me.lblTotalHoursOffEmpNumAct.Visible = False
        Me.lblVarianceEmpNumAct.Visible = False
        Me.lblDirectHoursGoalAct.Visible = False
        Me.lblDirectHoursGoalNumAct.Visible = False
        Me.imgbtnExport.Visible = False
        Me.txtTasksAct.Visible = False
        Me.TextBox3.Visible = False
        Me.TextBox4.Visible = False
        Me.TextBox5.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.DivSummaryLevel.Visible = True
        Me.ButtonRefreshAct.Visible = True

        Me.RadGridActualization.Visible = False

        Me.RefreshActualization()


    End Sub

    Private SumTotalTaskHoursAct As Decimal = CType(0.0, Decimal)
    Private SumAdjustedHoursAssignedAct As Decimal = CType(0.0, Decimal)
    Private SumHoursPostedAct As Decimal = CType(0.0, Decimal)
    Private SumHoursLeftAct As Decimal = CType(0.0, Decimal)
    Private SumHoursBeginAct As Decimal = CType(0.0, Decimal)
    Private SumHoursDistributedAct As Decimal = CType(0.0, Decimal)

    Private Sub RadGridActAssignments_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridActAssignments.ItemCommand
        Try
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            Dim alertid As Integer = 0
            Dim newValues As New Hashtable()

            Select Case e.CommandName
                Case "GoToTask"
                    Try

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridActAssignments.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)

                        If CurrentGridRow IsNot Nothing Then

                            If IsDBNull(CurrentGridRow.GetDataKeyValue("ALERT_ID")) = False Then
                                alertid = CurrentGridRow.GetDataKeyValue("ALERT_ID")
                            End If
                            Me.CalendarPageView = 3

                            If alertid = 0 Then
                                Dim StrEditURL As String

                                Session("CalendarPageViewEmpDrop") = Me.ddEmployeeAct.SelectedValue
                                Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                                If IsDBNull(CurrentGridRow.GetDataKeyValue("JOB_NUMBER")) = False Then
                                    job = CurrentGridRow.GetDataKeyValue("JOB_NUMBER")
                                End If
                                If IsDBNull(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                                    comp = CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
                                End If
                                rectype = CurrentGridRow.GetDataKeyValue("REC_TYPE")
                                client = CurrentGridRow.GetDataKeyValue("CL_CODE")
                                division = CurrentGridRow.GetDataKeyValue("DIV_CODE")
                                product = CurrentGridRow.GetDataKeyValue("PRD_CODE")
                                seqnum = CurrentGridRow.GetDataKeyValue("SEQ_NBR")
                                nontaskid = CurrentGridRow.GetDataKeyValue("NON_TASK_ID")
                                If CurrentGridRow.GetDataKeyValue("REC_TYPE") = "T" Then
                                    StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & job & "&JobComp=" & comp & "&SeqNum=" & seqnum & "&Client=" & client & "&Division=" & division & "&Product=" & product
                                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal1", "Edit Task", StrEditURL, 650, 860, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                                    Me.OpenWindow(newValues("TASK_DESCRIPTION").Replace("'", "\'"), StrEditURL, 650, 860, False, True)

                                End If
                            Else
                                Dim qs As New AdvantageFramework.Web.QueryString
                                qs.Page = "Desktop_AlertView"
                                If IsDBNull(CurrentGridRow.GetDataKeyValue("ALERT_ID")) = False Then
                                    qs.Add("AlertID", CurrentGridRow.GetDataKeyValue("ALERT_ID"))
                                End If
                                If IsDBNull(CurrentGridRow.GetDataKeyValue("SPRINT_ID")) = False Then
                                    qs.Add("SprintID", CurrentGridRow.GetDataKeyValue("SPRINT_ID"))
                                Else
                                    qs.Add("SprintID", 0)
                                End If
                                CurrentGridRow.ExtractValues(newValues)

                                'CurrentGridRow.GetDataKeyValue("JOB_NUMBER").PadLeft(6, "0") & "-" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR").PadLeft(2, "0") &

                                Me.OpenWindow(qs, newValues("TASK_DESCRIPTION").Replace("'", "\'"))
                            End If

                        End If

                    Catch ex As Exception
                    End Try

                Case "GoToAssignment"
                    Try

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridActAssignments.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)

                        If CurrentGridRow IsNot Nothing Then

                            Dim qs As New AdvantageFramework.Web.QueryString
                            qs.Page = "Desktop_AlertView"
                            If IsDBNull(CurrentGridRow.GetDataKeyValue("ALERT_ID")) = False Then
                                qs.Add("AlertID", CurrentGridRow.GetDataKeyValue("ALERT_ID"))
                            End If
                            If IsDBNull(CurrentGridRow.GetDataKeyValue("SPRINT_ID")) = False Then
                                qs.Add("SprintID", CurrentGridRow.GetDataKeyValue("SPRINT_ID"))
                            Else
                                qs.Add("SprintID", 0)
                            End If

                            CurrentGridRow.ExtractValues(newValues)
                            ' CurrentGridRow.GetDataKeyValue("JOB_NUMBER").PadLeft(6, "0") & "-" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR").PadLeft(2, "0") &

                            Me.OpenWindow(qs, newValues("TASK_DESCRIPTION"))

                        End If

                    Catch ex As Exception
                    End Try

                Case "GoToActivity"

                    Try
                        Dim StrEditURL As String

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridActAssignments.Items(e.Item.ItemIndex), Telerik.Web.UI.GridDataItem)

                        If CurrentGridRow IsNot Nothing Then
                            If IsDBNull(CurrentGridRow.GetDataKeyValue("JOB_NUMBER")) = False Then
                                job = CurrentGridRow.GetDataKeyValue("JOB_NUMBER")
                            End If
                            If IsDBNull(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                                comp = CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
                            End If
                            nontaskid = CurrentGridRow.GetDataKeyValue("NON_TASK_ID")

                            StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & nontaskid & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & job & "&JobComponentNbr=" & comp
                            Me.OpenWindow("New Activity", StrEditURL, 1000, 1500)

                        End If

                    Catch ex As Exception

                    End Try

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridActAssignments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridActAssignments.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.AlternatingItem, GridItemType.Item

                Dim CurrentGridRow As GridDataItem = e.Item
                Dim DivGoToTask As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivGoToTask")
                Dim DivGoToAssignment As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivGoToAssignment")
                Dim DivGoToActivity As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivGoToActivity")
                Dim LinkButton As LinkButton

                Try

                    Select Case e.Item.DataItem("REC_TYPE").ToString()
                        Case "T", "AS"

                            'e.Item.BackColor = ColorTranslator.FromHtml("#CAE0DA")
                            'e.Item.BackColor = ColorTranslator.FromHtml("#76D276")

                        Case "ET"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F7D5DB")

                        Case "A", "ADA", "C", "M", "TD", "EL", "ASO"

                            e.Item.BackColor = ColorTranslator.FromHtml("#B2C9E0")

                        Case "AHO", "ADHO"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F6E3BC")

                        Case "H"

                            e.Item.BackColor = ColorTranslator.FromHtml("#F9DEC7")

                    End Select

                Catch ex As Exception
                End Try

                Try
                    Select Case e.Item.DataItem("REC_TYPE").ToString()
                        Case "T", "ET", "A", "ADA", "AHO", "ADHO", "C", "M", "TD", "EL", "AS", "ASO"

                            Try
                                If IsNumeric(e.Item.Cells(13 + OffSet).Text) = True Then 'Total Task Hours column

                                    SumTotalTaskHours = SumTotalTaskHours + CType(e.Item.Cells(13 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try
                            Try

                                If IsNumeric(e.Item.Cells(17 + OffSet).Text) = True Then 'Adjusted Hours Assigned column

                                    SumHoursDistributedAct = SumHoursDistributedAct + CType(e.Item.Cells(17 + OffSet).Text, Decimal)

                                    Dim distributedHours As Decimal = CType(e.Item.Cells(17 + OffSet).Text, Decimal)

                                    If distributedHours < 0 Then
                                        e.Item.Cells(17 + OffSet).Text = "0.00"
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                            Try

                                If IsNumeric(e.Item.Cells(14 + OffSet).Text) = True Then 'Hours Posted column

                                    SumHoursBeginAct = SumHoursBeginAct + CType(e.Item.Cells(14 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try
                            Try

                                If IsNumeric(e.Item.Cells(15 + OffSet).Text) = True Then 'Hours Posted column

                                    SumHoursPostedAct = SumHoursPostedAct + CType(e.Item.Cells(15 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try
                            Try

                                If IsNumeric(e.Item.Cells(16 + OffSet).Text) = True Then 'Hours Left column

                                    SumHoursLeftAct = SumHoursLeftAct + CType(e.Item.Cells(16 + OffSet).Text, Decimal)

                                End If
                            Catch ex As Exception
                            End Try

                    End Select
                    If e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then

                        e.Item.Cells(13).Text = LoGlo.FormatDate(e.Item.Cells(13).Text)

                    End If
                    If e.Item.Cells(14).Text <> "" And e.Item.Cells(14).Text <> "&nbsp;" Then

                        e.Item.Cells(14).Text = LoGlo.FormatDate(e.Item.Cells(14).Text)

                    End If

                Catch ex As Exception
                End Try

                Try
                    Dim JobNumber As Integer = 0
                    Dim JobComponentNumber As Short = 0

                    If CurrentGridRow.GetDataKeyValue("JOB_NUMBER") IsNot Nothing AndAlso IsNumeric(CurrentGridRow.GetDataKeyValue("JOB_NUMBER")) = True Then

                        JobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)

                    End If
                    If CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR") IsNot Nothing AndAlso IsNumeric(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")) = True Then

                        JobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)

                    End If
                    If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                        e.Item.Cells(8).Text = CurrentGridRow.GetDataKeyValue("JOB_NUMBER").ToString.PadLeft(6, "0") & "/" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0") & " - " & CurrentGridRow.GetDataKeyValue("JOB_COMP_DESC").ToString

                    Else

                        'If DivGoToSchedule IsNot Nothing Then

                        '    AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToSchedule)

                        'End If

                    End If

                Catch ex As Exception
                End Try

                Try

                    If CurrentGridRow.GetDataKeyValue("CL_NAME") IsNot Nothing AndAlso e.Item.Cells(5).Text <> "&nbsp;" Then

                        e.Item.Cells(5).Text = CurrentGridRow.GetDataKeyValue("CL_NAME").ToString & "(" & CurrentGridRow.GetDataKeyValue("DIV_CODE") & "/" & CurrentGridRow.GetDataKeyValue("PRD_CODE") & ")"

                    End If

                    If e.Item.DataItem("REC_TYPE").ToString() = "AS" Or e.Item.DataItem("REC_TYPE").ToString() = "ASO" Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToTask)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToActivity)
                        LinkButton = CurrentGridRow.FindControl("LinkButtonAssignment")

                        If CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "49" Then
                            LinkButton.Text = "I"
                        ElseIf CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "70" Then
                            LinkButton.Text = "S"
                        ElseIf CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "24" Then
                            LinkButton.Text = "E"
                        ElseIf CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "27" Then
                            LinkButton.Text = "R"
                        ElseIf CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "26" Then
                            LinkButton.Text = "D"
                        Else
                            LinkButton.Text = "A"
                        End If

                    ElseIf e.Item.DataItem("REC_TYPE").ToString() = "T" Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToAssignment)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToActivity)
                        LinkButton = CurrentGridRow.FindControl("LinkButtonTask")

                        If CurrentGridRow.GetDataKeyValue("ALERT_CAT_ID").ToString = "71" Then
                            LinkButton.Text = "T"
                        Else
                            LinkButton.Text = "T"
                        End If

                        If IsDBNull(CurrentGridRow.GetDataKeyValue("ALERT_ID")) = True Then
                            AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToTask)
                        End If

                    ElseIf e.Item.DataItem("REC_TYPE").ToString() = "A" Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToTask)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToAssignment)

                        LinkButton = CurrentGridRow.FindControl("LinkButtonActivity")

                        LinkButton.Text = "A"

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToTask)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToAssignment)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivGoToActivity)

                    End If

                Catch ex As Exception

                End Try

            Case GridItemType.Footer

                Try

                    e.Item.Cells(13 + OffSet).Text = SumTotalTaskHours.ToString()
                    e.Item.Cells(14 + OffSet).Text = SumHoursBeginAct.ToString()
                    e.Item.Cells(15 + OffSet).Text = SumHoursPostedAct.ToString()
                    e.Item.Cells(16 + OffSet).Text = SumHoursLeftAct.ToString()
                    e.Item.Cells(17 + OffSet).Text = SumHoursDistributedAct.ToString()
                    'Dim hoursleft As Decimal = SumHoursBeginAct - SumHoursPostedAct
                    'If hoursleft < 0 Then
                    '    e.Item.Cells(16 + OffSet).Text = "0.00"
                    'Else
                    '    e.Item.Cells(16 + OffSet).Text = hoursleft.ToString()
                    'End If

                    'If SumHoursDistributedAct < 0 Then
                    '    e.Item.Cells(17 + OffSet).Text = "0.00"
                    'Else
                    '    e.Item.Cells(17 + OffSet).Text = SumHoursDistributedAct.ToString()
                    'End If



                Catch ex As Exception
                End Try

        End Select

    End Sub
    Private Sub RadGridActAssignments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridActAssignments.NeedDataSource
        Try
            Dim empcode As String = ""
            Dim empname As String = ""
            Dim dr As SqlDataReader
            Dim cEmp As New cEmployee(Session("ConnString"))
            SetAppVarsApplication()
            oAppVars.getAllAppVars()
            If Me.IsPostBack Or Me.IsCallback Then
                Me.RadGridActAssignments.Visible = True
                'If Me.RadGridAssignments.Visible = True And Me.RadGridAvailability.Visible = False Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridActualization.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        empcode = gridDataItem.Cells(2).Text
                        empname = gridDataItem.Cells(4).Text
                        Session("CalendarPageViewEmpCode") = empcode
                    End If
                Next
                If empcode = "" Then
                    Me.LoadAssignmentsActGrid("%", "All Employees")
                    Me.DivEmployeePictureAct.Visible = False
                Else
                    Me.LoadAssignmentsActGrid(empcode, empname)
                    Me.DivEmployeePictureAct.Visible = True
                    Me.LabelEmployeeAct.Visible = True
                    Me.RadBinaryImage3.Visible = True
                    dr = cEmp.GetEmployeeProfile(empcode)
                    If dr.HasRows Then
                        dr.Read()
                        If BoolToYN(CType(oAppVars.getAppVar("tcal_empIncludeImage", "Boolean"), Boolean)).Trim = "Y" Then
                            If IsDBNull(dr("EMP_IMAGE")) = False Then
                                Dim FileBytes() As Byte = CType(dr("EMP_IMAGE"), Byte())
                                Me.RadBinaryImage3.DataValue = FileBytes
                            Else
                                Me.RadBinaryImage3.ImageUrl = "Images/NoImage.png"
                            End If
                        Else
                            Me.RadBinaryImage3.Visible = False
                        End If
                        If oAppVars.getAppVar("tcal_empdisplayname") = "first" Then
                            If IsDBNull(dr("EMP_FNAME")) = False Then
                                Me.LabelEmployeeAct.Text = dr("EMP_FNAME")
                            Else
                                Me.LabelEmployeeAct.Text = ""
                            End If
                        ElseIf oAppVars.getAppVar("tcal_empdisplayname") = "full" Then
                            If IsDBNull(dr("EMP_NICKNAME")) = False Then
                                Me.LabelEmployeeAct.Text = dr("EMP_NICKNAME")
                            Else
                                Me.LabelEmployeeAct.Text = ""
                            End If
                        End If
                        dr.Close()
                    End If
                End If

                Me.lblTotalHoursEmpAvailableAct.Visible = True
                Me.lblTotalHoursAssignedAct.Visible = True
                Me.lblTotalHoursOffEmpAct.Visible = True
                Me.lblVarianceEmpAct.Visible = True
                Me.lblTotalHoursEmpAvailableNumAct.Visible = True
                Me.lblTotalHoursAssignedNumAct.Visible = True
                Me.lblTotalHoursOffEmpNumAct.Visible = True
                Me.lblTotalAppointmentHoursAct.Visible = True
                Me.lblTotalAppointmentHoursNumAct.Visible = True
                Me.lblVarianceEmpNumAct.Visible = True
                Me.lblDirectHoursGoalAct.Visible = True
                Me.lblDirectHoursGoalNumAct.Visible = True
                Me.imgbtnExportAct.Visible = True

                Me.txtTasksAct.Visible = False
                Me.TextBox3.Visible = True
                Me.TextBox4.Visible = True
                Me.TextBox5.Visible = False
                'Me.TextBoxAllocationTasks.Visible = True
                'Me.TextBoxAllocationAppointments.Visible = True
                'Me.TextBoxAllocationHours.Visible = True
                'Me.TextBoxAllocationEvent.Visible = True
                Me.Label20.Visible = False
                Me.Label21.Visible = True
                Me.Label22.Visible = True
                Me.Label23.Visible = False
                'Me.LabelAllocationTasks.Visible = True
                'Me.LabelAllocationAppointments.Visible = True
                'Me.LabelAllocationHours.Visible = True
                'Me.LabelAllocationEvent.Visible = True
                Me.LabelEmployeeAct.ViewStateMode = True
                Me.RadBinaryImage3.Visible = True
                'End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ButtonRefreshAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefreshAct.Click
        SaveDateSettings(RadDatePickerActualizationStartDate.SelectedDate, RadDatePickerActualizationEndDate.SelectedDate)

        Dim message As String = ""
        If Not Me.RadDatePickerActualizationStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerActualizationEndDate.SelectedDate Is Nothing Then
            If wvCDate(Me.RadDatePickerActualizationStartDate.SelectedDate) > wvCDate(Me.RadDatePickerActualizationEndDate.SelectedDate) Then
                message = "End Date must be greater than Start Date."
                Me.ShowMessage(message)
                Exit Sub
            End If
            If wvCDate(Me.RadDatePickerActualizationEndDate.SelectedDate).Subtract(wvCDate(Me.RadDatePickerActualizationStartDate.SelectedDate)).Days > 365 Then
                message = "Date range must be less than one year."
                Me.ShowMessage(message)
                Exit Sub
            End If
        End If

        Dim st As Date = Me.RadDatePickerActualizationStartDate.SelectedDate
        Dim et As Date = Me.RadDatePickerActualizationEndDate.SelectedDate

        If RblActualizationSummaryLevel.SelectedValue = "daily" AndAlso Not IsDailyAllowed(st, et) Then
            message = "Daily summary date range must be less than 33 days"
            Me.ShowMessage(message)
            Exit Sub
        End If

        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning", "", Me.CheckBoxOmit.Checked)
            otask.setAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent", "", Me.CheckBoxShowPercent.Checked)
        Catch ex As Exception

        End Try

        Me.RefreshActualization()
    End Sub

    Private Sub RefreshActualization()
        'LoadGrid()
        ''''Me.RadGrid2.Visible = True
        '''


        If Not Me.RadDatePickerActualizationStartDate.SelectedDate Is Nothing Then
            oAppVars.setAppVar("tcal_startdate", CStr(wvCDate(Me.RadDatePickerActualizationStartDate.SelectedDate)), "Date")
        End If
        If Not Me.RadDatePickerActualizationEndDate.SelectedDate Is Nothing Then
            oAppVars.setAppVar("tcal_enddate", CStr(wvCDate(Me.RadDatePickerActualizationEndDate.SelectedDate)), "Date")
        End If

        oAppVars.SaveAllAppVars()

        Me.DivLessThanHours.Visible = True
        Me.DivZeroHours.Visible = True
        Me.DivLessThanAndGreaterThanHours.Visible = True
        Me.DivGreaterThanHours.Visible = True
        Me.ButtonExportAct.Visible = True

        Me.RadGridActAssignments.Visible = False
        Me.lblTotalHoursEmpAvailableAct.Visible = False
        Me.lblTotalHoursAssignedAct.Visible = False
        Me.lblTotalHoursOffEmpAct.Visible = False
        Me.lblVarianceEmpAct.Visible = False
        Me.lblTotalHoursEmpAvailableNumAct.Visible = False
        Me.lblTotalHoursAssignedNumAct.Visible = False
        Me.lblTotalHoursOffEmpNumAct.Visible = False
        Me.lblVarianceEmpNumAct.Visible = False
        Me.DivEmployeePicture.Visible = False
        Me.lblTotalAppointmentHoursAct.Visible = False
        Me.lblTotalAppointmentHoursNumAct.Visible = False
        Me.lblDirectHoursGoalAct.Visible = False
        Me.lblDirectHoursGoalNumAct.Visible = False
        Me.imgbtnExportAct.Visible = False

        Me.txtTasksAct.Visible = False
        Me.TextBox3.Visible = False
        Me.TextBox4.Visible = False
        Me.TextBox5.Visible = False
        Me.TextBoxAllocationTasks.Visible = False
        Me.TextBoxAllocationAppointments.Visible = False
        Me.TextBoxAllocationHours.Visible = False
        Me.TextBoxAllocationEvent.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.LabelAllocationTasks.Visible = False
        Me.LabelAllocationAppointments.Visible = False
        Me.LabelAllocationHours.Visible = False
        Me.LabelAllocationEvent.Visible = False
        Me.lblEmployeeAct.Text = ""

        EnableOrDisableActualizationOptions()

        'If Me.RadioButton3.Checked = True Then
        If Me.RblActualizationSummaryLevel.Visible = True Then
            'LoadLegend()
            Me.RadGridActualization.Rebind()
        End If
        'End If
        RefreshActualizationPanelHeaderTitle()

    End Sub

    Public Function Convert2xelAct(ByVal ds As SqlDataReader, ByVal response As HttpResponse, Optional ByVal filename As String = "")
        Dim svalue As String
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_str As String
        Dim column_base As String
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim header_txt As String
        Dim header_cols As String
        Dim rowidx As Integer = 0
        Dim str_file As String
        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)
        Dim sHeader As String
        Dim builder As New System.Text.StringBuilder
        SetAppVarsApplication()
        oAppVars.getAllAppVars()

        If filename = "" Then filename = "WebvantageToExcel"

        response.Clear()
        response.Charset = ""
        response.ContentType = "application/excel"
        response.AddHeader("content-disposition", "inline;filename=" & filename & ".xls")

        If ds.HasRows Then
            header_cols = ""
            Do While ds.Read
                rowidx = rowidx + 1
                svalue = DBStr(ds, ("OFFICE_CODE")) & vbTab
                svalue = svalue & DBStr(ds, ("EMP_DESC")) & vbTab
                svalue = svalue & DBStr(ds, ("DP_TM_CODE")) & vbTab
                svalue = svalue & DBStr(ds, ("DIRECT_HRS_PER")) & vbTab
                svalue = svalue & DBStr(ds, ("HOURS_AVAIL")) & vbTab
                svalue = svalue & DBStr(ds, ("DIR_HRS_GOAL")) & vbTab


                'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
                'column_date = Convert.ToDateTime(Session("tcal_startdate"))
                'start_date = Convert.ToDateTime(Session("tcal_startdate"))
                detail_count = GetDetailColumns(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
                column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
                start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

                For idx = 1 To detail_count + 1
                    column_header = ""

                    If sum_level = "w" Then
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                        End If
                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)
                        date_week = DatePart(DateInterval.WeekOfYear, column_date)

                        If rowidx = 1 Then
                            column_header = column_header & CStr(date_month) & "/" & CStr(date_day) & "/" & CStr(date_year)
                            header_cols = header_cols & CStr(column_header) & vbTab
                        End If

                    Else
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                        End If

                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)

                        If rowidx = 1 Then
                            If idx = 1 Then
                                column_header = column_header & CStr(date_month) & "/" & CStr(date_day) & "/" & CStr(date_year)
                            Else
                                column_header = column_header & CStr(date_month) & "/1"
                            End If

                            header_cols = header_cols & CStr(column_header) & vbTab
                        End If

                    End If

                    Column_UniqueName = "col" & CStr(idx)
                    svalue = svalue & DBStr(ds, (Column_UniqueName)) & vbTab
                Next
            Loop
        End If

        sHeader = filename & vbCrLf
        sHeader = sHeader & "Office" & vbTab & "Employee" & ControlChars.Tab & "Dept" & vbTab & "Direct Hours Goal %" & vbTab & "Hours Available" & vbTab & "Direct Hours Goal" & vbTab & header_cols
        'builder.Append(sHeader)

        str_file = sHeader & vbCrLf & svalue
        htmlWrite.WriteLine(str_file)

        response.Write(stringWrite.ToString())
        response.End()
    End Function

    Public Function CreateHeaderAct(ByVal ds As SqlDataReader) As String
        Dim svalue As String
        Dim sum_level As String = "w"
        Dim actualize As String = "0"
        Dim detail_count As Integer
        Dim idx As Integer
        Dim column_nbr_str As String
        Dim column_header As String
        Dim column_len As Int16
        Dim start_date As Date
        Dim start_workweek_date As Date
        Dim column_date As Date
        Dim date_day As Int16
        Dim date_week As Int16
        Dim date_month As Int16
        Dim date_year As Int16
        Dim start_year As Int16
        Dim Column_UniqueName As String
        Dim header_txt As String
        Dim header_cols As String
        Dim rowidx As Integer = 0
        Dim sHeader As String
        SetAppVarsApplication()
        oAppVars.getAllAppVars()
        ''''If Me.RadioButton1.Checked Then
        ''''    sum_level = "w"
        ''''End If
        ''''If Me.RadioButton2.Checked Then
        ''''    sum_level = "m"
        ''''End If

        If Me.CheckBox1.Checked Then
            actualize = 1
        End If

        If ds.HasRows Then
            header_cols = ""
            Do While ds.Read
                rowidx = rowidx + 1
                svalue = " <td> " & DBStr(ds, ("OFFICE_CODE")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("EMP_DESC")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DP_TM_CODE")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DIRECT_HRS_PER")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("HOURS_AVAIL")) & " </td> "
                svalue = svalue & " <td> " & DBStr(ds, ("DIR_HRS_GOAL")) & " </td> "

                'detail_count = GetDetailColumns(Convert.ToDateTime(Session("tcal_startdate")), Convert.ToDateTime(Session("tcal_enddate")))
                'column_date = Convert.ToDateTime(Session("tcal_startdate"))
                'start_date = Convert.ToDateTime(Session("tcal_startdate"))
                detail_count = GetDetailColumns(Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date")), Convert.ToDateTime(oAppVars.getAppVar("tcal_enddate", "Date")))
                column_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))
                start_date = Convert.ToDateTime(oAppVars.getAppVar("tcal_startdate", "Date"))

                'Need to determine whcih day of week and set to start of work week
                Dim dayofweek As Integer
                dayofweek = DatePart(DateInterval.Weekday, start_date)

                For idx = 1 To detail_count + 1
                    column_header = ""

                    If sum_level = "w" Then
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.WeekOfYear, idx - 1, start_date)
                        End If
                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)
                        date_week = DatePart(DateInterval.WeekOfYear, column_date)

                        If rowidx = 1 Then
                            column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                            header_cols = header_cols & " <td> " & CStr(column_header) & " </td> "
                        End If

                    Else
                        If idx > 1 Then
                            column_date = DateAdd(DateInterval.Month, idx - 1, start_date)
                        End If

                        date_day = DatePart(DateInterval.Day, column_date)
                        date_month = DatePart(DateInterval.Month, column_date)
                        date_year = DatePart(DateInterval.Year, column_date)

                        If rowidx = 1 Then
                            If idx = 1 Then
                                column_header = column_header & CStr(date_month) & "/" & CStr(date_day)
                            Else
                                column_header = column_header & CStr(date_month) & "/1"
                            End If

                            header_cols = header_cols & " <td> " & CStr(column_header) & " </td> "
                        End If

                    End If
                Next
            Loop
        End If
        'sHeader = sHeader & "Office" & vbTab & "Employee" & ControlChars.Tab & "Dept" & vbTab & "Direct Hours Goal %" & vbTab & "Hours Available" & vbTab & "Direct Hours Goal" & vbTab & header_cols & ControlChars.CrLf
        sHeader = "<table><tr style='font-weight:bold;border-style:solid '> <td> Office </td> <td> Employee </td> <td> Dept </td>  <td> Direct Hours Goal % </td>  <td> Hours Available </td>  <td> Direct Hours Goal </td> " & header_cols & " </tr> </table> "

        Return sHeader

    End Function

    Protected Sub ButtonExportAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportAct.Click
        Try

            IsExport = True
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridActualization, "")

            Me.RadGridActualization.MasterTableView.ExportToExcel()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridActualization_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGridActualization.ColumnCreated
        Dim boundColumn As Telerik.Web.UI.GridBoundColumn
        Try
            If e.Column.UniqueName.ToString().IndexOf("_HRS_AVAIL") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_EMP_DIRECT_HRS_GOAL_HRS") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("_OVER_BOOKED") > 0 Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.Display = False
            End If
        Catch ex As Exception
        End Try
        'Try
        '    If e.Column.UniqueName.ToString().IndexOf("_PERCENT_UTIL") > 0 Then
        '        boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
        '        boundColumn.Display = False
        '    End If
        'Catch ex As Exception
        'End Try
        Try
            If e.Column.UniqueName.ToString() = ("Employee") Then
                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.ItemStyle.CssClass = "radgrid-employee-name-column"
            End If
        Catch ex As Exception
        End Try
        Try
            If e.Column.UniqueName.ToString().IndexOf("Hours Available") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Direct Hours Goal") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Total") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Beginning Balance") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Hours Posted") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Hours Left") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("Hours (No Date)") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf("/") > -1 OrElse
                e.Column.UniqueName.ToString().IndexOf(".") > -1 Then

                boundColumn = CType(e.Column, Telerik.Web.UI.GridBoundColumn)
                boundColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                boundColumn.ItemStyle.HorizontalAlign = HorizontalAlign.Right

                Try
                    boundColumn.DataFormatString = "{0:0.00}"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridActualization_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridActualization.ItemDataBound
        'hide emp_code
        Try
            e.Item.Cells(2).Visible = False
        Catch ex As Exception
        End Try

        'Multiplier to use:
        Dim LessThanDirectHoursGoal As Decimal = 0.0 'Less than ___% of the direct Hours Goal
        Dim GreaterEqualToDirectHoursGoal As Decimal = 0.0 'Greater than or equal to ___% of direct hours goal
        Dim LessThanHrsAvailable As Decimal = 0.0 'and less than ___% of the hours available
        Dim GreaterEqualToHrsAvailable As Decimal = 0.0 'greater than or equal to 90% of hours available

        If IsNumeric(Me.RadNumericTextBoxLessThanPercentageAct.Value) = True Then
            LessThanDirectHoursGoal = CType(Me.RadNumericTextBoxLessThanPercentageAct.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThanAct.Value) = True Then
            GreaterEqualToDirectHoursGoal = CType(Me.RadNumericTextBoxLessThanAndGreaterThanHours_GreaterThanAct.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThanAct.Value) = True Then
            LessThanHrsAvailable = CType(Me.RadNumericTextBoxLessThanAndGreaterThanHours_LessThanAct.Value, Decimal) / 100.0
        End If
        If IsNumeric(Me.RadNumericTextBoxGreaterThanHoursAct.Value) = True Then
            GreaterEqualToHrsAvailable = CType(Me.RadNumericTextBoxGreaterThanHoursAct.Value, Decimal) / 100.0
        End If


        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim CurrCell As Integer = 13
            Do While CurrCell <= e.Item.Cells.Count - 1 'odd number columns are hrs available, add one and that is the corresponding hours available column
                Dim CurrTaskHours As Decimal = 0.0
                Dim CurrAvailHours As Decimal = 0.0
                Dim CurrDirectGoalHours As Decimal = 0.0
                Dim CurrHoursLeft As Decimal = 0.0
                Dim OverBooked As Integer = 0
                Try
                    If IsNumeric(e.Item.Cells(CurrCell).Text) = True Then
                        CurrTaskHours = CType(e.Item.Cells(CurrCell).Text, Decimal)
                    Else
                        e.Item.Cells(CurrCell).Text = "0.00"
                    End If
                Catch ex As Exception
                    CurrTaskHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 1).Text) = True Then
                        CurrAvailHours = CType(e.Item.Cells(CurrCell + 1).Text, Decimal)
                    End If
                Catch ex As Exception
                    CurrAvailHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 2).Text) = True Then
                        CurrDirectGoalHours = CType(e.Item.Cells(CurrCell + 2).Text, Decimal)
                    End If
                Catch ex As Exception
                    CurrDirectGoalHours = 0.0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 3).Text) = True Then
                        OverBooked = CType(e.Item.Cells(CurrCell + 3).Text, Integer)
                    End If
                Catch ex As Exception
                    OverBooked = 0
                End Try
                Try
                    If IsNumeric(e.Item.Cells(CurrCell + 4).Text) = True Then
                        CurrHoursLeft = CType(e.Item.Cells(CurrCell + 4).Text, Integer)
                    End If
                Catch ex As Exception
                    CurrHoursLeft = 0
                End Try

                '''just a test:
                ''If CurrTaskHours < CurrAvailHours Then
                ''    e.Item.Cells(CurrCell).CssClass = "standard-red"
                ''End If
                'let one override the next...

                If CurrCell < (e.Item.Cells.Count - 1) Then

                    If Me.CheckBoxShowPercent.Checked = True Then
                        Try
                            If CurrTaskHours < (LessThanDirectHoursGoal * 100) Then
                                e.Item.Cells(CurrCell).CssClass = _LessThanHoursColorCSS
                            End If
                            If (CurrTaskHours >= (LessThanDirectHoursGoal * 100)) And (CurrTaskHours < (LessThanHrsAvailable * 100)) Then
                                e.Item.Cells(CurrCell).CssClass = _LessThanAndGreaterThanHoursColorCSS
                            End If
                            If (CurrTaskHours >= (GreaterEqualToHrsAvailable * 100)) Then
                                e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                            End If
                            If CurrTaskHours = 0.0 Then
                                e.Item.Cells(CurrCell).CssClass = _ZeroHoursColorCSS
                            End If
                            If OverBooked = 1 Then
                                e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            If CurrTaskHours < (CurrAvailHours * LessThanDirectHoursGoal) Then
                                e.Item.Cells(CurrCell).CssClass = _LessThanHoursColorCSS
                            End If
                            If (CurrTaskHours >= (CurrAvailHours * LessThanDirectHoursGoal)) And (CurrTaskHours < (CurrAvailHours * LessThanHrsAvailable)) Then
                                e.Item.Cells(CurrCell).CssClass = _LessThanAndGreaterThanHoursColorCSS
                            End If
                            If (CurrTaskHours >= (CurrAvailHours * GreaterEqualToHrsAvailable)) Then
                                e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                            End If
                            If CurrTaskHours = 0.0 Then
                                e.Item.Cells(CurrCell).CssClass = _ZeroHoursColorCSS
                            End If
                            If OverBooked = 1 Then
                                e.Item.Cells(CurrCell).CssClass = _GreaterThanHoursColorCSS
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                End If
                If CurrCell = (e.Item.Cells.Count - 1) Then
                    'THIS IS THE TOTAL ROW?
                    Try
                        e.Item.Cells(CurrCell).CssClass = _ZeroHoursColorCSS
                        e.Item.Cells(CurrCell).Text = "<strong>" & e.Item.Cells(CurrCell).Text & "</strong>"
                    Catch ex As Exception
                    End Try
                End If


                CurrCell += 4
            Loop

        End If


    End Sub
    Private Sub RadGridActualization_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridActualization.NeedDataSource
        Try
            If Me.Page.IsPostBack = True Then
                Dim r As New cResources
                Dim ThisLevel As cResources.SummaryLevel
                Dim LoadIt As Boolean = True
                SetAppVarsApplication()
                oAppVars.getAllAppVars()
                Dim st As Date = Me.RadDatePickerActualizationStartDate.SelectedDate
                Dim et As Date = Me.RadDatePickerActualizationEndDate.SelectedDate 'Convert.ToDateTime(LoGlo.FormatDate(oAppVars.getAppVar("tcal_enddate", "Date")))

                Select Case RblActualizationSummaryLevel.SelectedValue
                    Case "daily"
                        ThisLevel = cResources.SummaryLevel.Day
                    Case "weekly"
                        ThisLevel = cResources.SummaryLevel.Week
                    Case "monthly"
                        ThisLevel = cResources.SummaryLevel.Month
                    Case Else
                        LoadIt = False
                End Select
                Dim day_ct As Long = DateDiff(DateInterval.Day, st, et)
                If day_ct >= 366 Then
                    ThisLevel = cResources.SummaryLevel.Year
                End If

                If ThisLevel = cResources.SummaryLevel.Day AndAlso Not IsDailyAllowed(st, et) Then

                    ThisLevel = cResources.SummaryLevel.Week
                    Me.RblActualizationSummaryLevel.Items(1).Selected = True

                End If

                If Me.RadTabStripTaskCalendar.SelectedTab.Value <> 7 Then
                    LoadIt = False
                End If

                If LoadIt = True Then

                    oAppVars.getAllAppVars()



                    Dim dt As New DataTable
                    dt = r.GetActualizationDatatable(Me.ddEmployeeAct.SelectedValue, st, et, ThisLevel, oAppVars.getAppVar("tcal_roles"), oAppVars.getAppVar("tcal_departs"), True, "", "", "", "", "", "", "", "", False, "", "", 0, 0, "", False, Me.CheckBoxOmit.Checked, Me.CheckBoxShowPercent.Checked)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            Me.RadGridActualization.DataSource = dt
                            Me.ButtonExportAct.Enabled = True
                            If Me.ddEmployeeAct.SelectedValue = "%" Then
                                Me.ButtonAllAct.Visible = True
                            Else
                                Me.ButtonAllAct.Visible = False
                            End If
                        Else
                            Me.ButtonExportAct.Enabled = False
                        End If
                    Else
                        Me.ButtonExportAct.Enabled = False
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub RadGridActualization_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridActualization.SelectedIndexChanged
        Try
            Me.RadGridActAssignments.Rebind()
            Me.RadGridActAssignments.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonAllAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAllAct.Click
        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridActualization.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    gridDataItem.Selected = False
                End If
            Next
            Me.RadGridActAssignments.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadMenu1Act_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1Act.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            Dim Description As String = "Edit Task"
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridActAssignments.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_NUMBER")) = False Then
                        job = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                        comp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    End If
                    rectype = gridDataItem.GetDataKeyValue("REC_TYPE")
                    client = gridDataItem.GetDataKeyValue("CL_CODE")
                    division = gridDataItem.GetDataKeyValue("DIV_CODE")
                    product = gridDataItem.GetDataKeyValue("PRD_CODE")
                    seqnum = gridDataItem.GetDataKeyValue("SEQ_NBR")
                    nontaskid = gridDataItem.GetDataKeyValue("NON_TASK_ID")
                    Description = gridDataItem("column5").Text
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)
                Case "PS"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)
                Case "Task"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployeeAct.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    If rectype = "T" Then
                        StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & job & "&JobComp=" & comp & "&SeqNum=" & seqnum & "&Client=" & client & "&Division=" & division & "&Product=" & product
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal1", "Edit Task", StrEditURL, 650, 860, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                        Me.OpenWindow(Description, StrEditURL, 650, 860, False, True)
                    ElseIf rectype = "H" Or rectype = "A" Or rectype = "ADA" Or rectype = "AHO" Or rectype = "ADAHO" Then
                        StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & nontaskid & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & job & "&JobComponentNbr=" & comp
                        Me.OpenWindow("New Activity", StrEditURL, 1000, 1500)
                        'ElseIf Str(6) = 2 Then
                        '    StrEditURL = "Event_Detail.aspx?et=0&j=" & Str(0) & "&jc=" & Str(1) & "&evt=" & Str(7) & "&cli=" & Str(3) & "&from=1"
                        '    Me.OpenWindow("Event Detail", StrEditURL, 745, 525, False, True)
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal2", "Event Detail", StrEditURL, 745, 325, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    ElseIf rectype = "ET" Then
                        StrEditURL = "Event_Task_Detail.aspx?etid=" & nontaskid & "&f=c"
                        Me.OpenWindow("Event Task Edit", StrEditURL, 620, 670, False, True)
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal3", "Event Task Edit", StrEditURL, 620, 670, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    End If
                Case "EditAssignment"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployeeAct.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
                    oTask.Where.JOB_NUMBER.Value = job
                    oTask.Where.JOB_COMPONENT_NBR.Value = comp
                    oTask.Where.SEQ_NBR.Value = seqnum
                    Dim taskcode As String
                    If oTask.Query.Load Then
                        taskcode = oTask.FNC_CODE
                    End If
                    StrEditURL = "TrafficSchedule_TaskEmployees.aspx?From=cal&FromApp=" & Request.QueryString("FromApp") & "&JobNum=" & job & "&JobComp=" & comp & "&SeqNum=" & seqnum & "&TaskCode=" & taskcode
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerCalendar, "EditRowWindowCal1", "Edit Task", StrEditURL, 600, 650, True, Telerik.Web.UI.WindowBehaviors.Maximize)
                    Me.OpenWindow("Edit Assignment", StrEditURL, 600, 650, False, True)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadMenu2Act_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu2Act.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridActAssignments.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_NUMBER")) = False Then
                        job = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                        comp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    End If
                    rectype = gridDataItem.GetDataKeyValue("REC_TYPE")
                    If IsDBNull(gridDataItem.GetDataKeyValue("CL_CODE")) = False Then
                        client = gridDataItem.GetDataKeyValue("CL_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("DIV_CODE")) = False Then
                        division = gridDataItem.GetDataKeyValue("DIV_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("PRD_CODE")) = False Then
                        product = gridDataItem.GetDataKeyValue("PRD_CODE")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("SEQ_NBR")) = False Then
                        seqnum = gridDataItem.GetDataKeyValue("SEQ_NBR")
                    End If
                    nontaskid = gridDataItem.GetDataKeyValue("NON_TASK_ID")
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)
                Case "PS"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)
                Case "Task"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    Session("CalendarPageViewEmpDrop") = Me.ddEmployeeAct.SelectedValue
                    Session("CalendarPageViewSummaryLevel") = Me.RblAvailabilitySummaryLevel.SelectedValue
                    'If rectype = "H" Or rectype = "A" Or rectype = "ADA" Or rectype = "AHO" Or rectype = "ADAHO" Then
                    StrEditURL = "Calendar_NewActivity.aspx?TaskNo=" & nontaskid & "&calView=" & Me.CalendarPage & "&FromApp=" & Request.QueryString("FromApp") & "&JobNumber=" & job & "&JobComponentNbr=" & comp
                    Me.OpenWindow("New Activity", StrEditURL, 1000, 1500)
                    'End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadMenu3Act_ItemClick(sender As Object, e As RadMenuEventArgs) Handles RadMenu3Act.ItemClick
        Try
            Dim radGridClickedRowIndex As Integer
            radGridClickedRowIndex = Convert.ToInt32(MiscFN.RemoveTrailingDelimiter(Request.Form("radGridClickedRowIndex"), ","))
            Dim datarow As GridDataItem
            Dim job As Integer
            Dim comp As Integer
            Dim rectype As String
            Dim client As String
            Dim division As String
            Dim product As String
            Dim seqnum As Integer
            Dim nontaskid As Integer
            Dim alertid As Integer
            Dim sprintid As Integer
            Dim Description As String
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridActAssignments.MasterTableView.Items
                If gridDataItem.ItemIndexHierarchical = radGridClickedRowIndex Then
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_NUMBER")) = False Then
                        job = gridDataItem.GetDataKeyValue("JOB_NUMBER")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")) = False Then
                        comp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    End If
                    rectype = gridDataItem.GetDataKeyValue("REC_TYPE")
                    client = gridDataItem.GetDataKeyValue("CL_CODE")
                    division = gridDataItem.GetDataKeyValue("DIV_CODE")
                    product = gridDataItem.GetDataKeyValue("PRD_CODE")
                    'seqnum = gridDataItem.GetDataKeyValue("SEQ_NBR")
                    'nontaskid = gridDataItem.GetDataKeyValue("NON_TASK_ID")
                    If IsDBNull(gridDataItem.GetDataKeyValue("ALERT_ID")) = False Then
                        alertid = gridDataItem.GetDataKeyValue("ALERT_ID")
                    End If
                    If IsDBNull(gridDataItem.GetDataKeyValue("SPRINT_ID")) = False Then
                        sprintid = gridDataItem.GetDataKeyValue("SPRINT_ID")
                    End If
                    Try
                        Description = gridDataItem("column5").Text
                    Catch
                        Description = gridDataItem("colTask").Text
                    End Try

                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.Page = "Content.aspx"
            qs.JobNumber = job
            qs.JobComponentNumber = comp
            Select Case e.Item.Value
                Case "Job"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("PageMode", "Edit")
                    qs.Add("JobNum", job)
                    qs.Add("JobCompNum", comp)
                    qs.Add("NewComp", 0)
                    Me.OpenWindow(qs)
                Case "PS"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    qs.Add("JobNum", job)
                    qs.Add("JobComp", comp)
                    Me.OpenWindow(qs)
                Case "Assignment"
                    Dim StrEditURL As String
                    Me.CalendarPageView = 3
                    qs.Page = "Desktop_AlertView"
                    qs.Add("AlertID", alertid)
                    qs.Add("SprintID", sprintid)
                    Me.OpenWindow(qs, Description)
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub RadDatePickerActualizationEndDate_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerActualizationEndDate.SelectedDateChanged

        Dim StartDate As Date = Me.RadDatePickerActualizationStartDate.SelectedDate
        Dim EndDate As Date = Me.RadDatePickerActualizationEndDate.SelectedDate

        Me.RblActualizationSummaryLevel.Items(0).Enabled = IsDailyAllowed(StartDate, EndDate)

    End Sub

    Private Sub imgbtnExportAct_Click(sender As Object, e As ImageClickEventArgs) Handles imgbtnExportAct.Click
        Try
            Dim str As String = ""
            str = "EmployeeAssigments_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridActAssignments, str)

            RadGridActAssignments.MasterTableView.GetColumn("ColPS").Visible = False
            RadGridActAssignments.MasterTableView.ExportToExcel()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxOmit_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOmit.CheckedChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "CalendarAvailability", "OmitBeginning", "", Me.CheckBoxOmit.Checked)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckBoxShowPercent_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowPercent.CheckedChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "CalendarAvailability", "ShowPercent", "", Me.CheckBoxShowPercent.Checked)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()
            qs.Add("CalendarPageView", 7)
            qs.Add("bm", "1")

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Calendar_Availability
                .UserCode = Session("UserCode")
                .Name = "Calendar Availability"
                .Description = "Calendar Availability"
                .PageURL = "Calendar_MonthView.aspx" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                'Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
Public Class CustomAppointmentComparer
    Implements System.Collections.Generic.IComparer(Of Telerik.Web.UI.Appointment)

    Public Function Compare(ByVal first As Telerik.Web.UI.Appointment, ByVal second As Telerik.Web.UI.Appointment) As Integer Implements System.Collections.Generic.IComparer(Of Telerik.Web.UI.Appointment).Compare

        Try

            If IsDBNull(first) = True OrElse IsDBNull(second) = True Then Exit Function
            If first Is Nothing OrElse second Is Nothing Then Exit Function

            If first Is second Then Return 0

            Dim key1 As String() = first.Description.Split("|")
            Dim key2 As String() = second.Description.Split("|")

            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If key1.Length >= 14 AndAlso Not key1(13) Is Nothing Then

                Value1 = key1(13).Trim().Replace(" ", "").ToUpper()

            End If
            If key2.Length >= 14 AndAlso Not key2(13) Is Nothing Then

                Value2 = key2(13).Trim().Replace(" ", "").ToUpper()

            End If

            If Value1 = Value2 Then Return 0
            If Value1 < Value2 Then Return -1
            If Value1 > Value2 Then Return 1

        Catch ex As Exception
        End Try

    End Function

End Class
