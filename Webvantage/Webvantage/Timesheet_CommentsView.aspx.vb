Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Timesheet_CommentsView
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Public StartDate As Date = Nothing
    Public EndDate As Date = Nothing

    Public EmpCode As String = ""
    Public PageType As String = ""
    Public IsNewEntry As Boolean = False
    Public IsUpdateEntry As Boolean = True
    Public CommentsRequired As Boolean = False

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public AlertID As Integer = 0

    Public SunDate As Date = Nothing
    Public MonDate As Date = Nothing
    Public TueDate As Date = Nothing
    Public WedDate As Date = Nothing
    Public ThuDate As Date = Nothing
    Public FriDate As Date = Nothing
    Public SatDate As Date = Nothing

    Public SunEdit As Boolean = False
    Public MonEdit As Boolean = False
    Public TueEdit As Boolean = False
    Public WedEdit As Boolean = False
    Public ThuEdit As Boolean = False
    Public FriEdit As Boolean = False
    Public SatEdit As Boolean = False

    Public MonClosedPP As Boolean = False
    Public TueClosedPP As Boolean = False
    Public WedClosedPP As Boolean = False
    Public ThuClosedPP As Boolean = False
    Public FriClosedPP As Boolean = False
    Public SatClosedPP As Boolean = False
    Public SunClosedPP As Boolean = False

    Public SunHasStopwatch As Boolean = False
    Public MonHasStopwatch As Boolean = False
    Public TueHasStopwatch As Boolean = False
    Public WedHasStopwatch As Boolean = False
    Public ThuHasStopwatch As Boolean = False
    Public FriHasStopwatch As Boolean = False
    Public SatHasStopwatch As Boolean = False

    Public EditMessage As String = ""
    Public Caller As String = ""

    Public LoadSingleDay As Boolean = False
    Public SingleDayDayOfWeek As DayOfWeek = Nothing
    Public ActivityStartDate As Date = Nothing
    Public TaskNo As Integer = 0
    Public FunctionCode As String = ""

#End Region

#Region " Properties "

    Public Property SecurityModule As Integer = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.Employee_Timesheet))

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

    Private ReadOnly Property DaysToDisplay As Integer
        Get
            Dim i As Integer = 7

            Try


                If cEmployee.TimeZoneToday.DayOfWeek = DayOfWeek.Saturday Or cEmployee.TimeZoneToday.DayOfWeek = DayOfWeek.Sunday Then

                    i = 7

                Else

                    Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                    Dim c As New cTimeSheet(Session("ConnString"))

                    TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                    i = TsSettings.DaysToDisplay

                End If

                Try

                    If Request.QueryString("Display") IsNot Nothing AndAlso IsNumeric(Request.QueryString("Display")) = True Then

                        i = CType(Request.QueryString("Display"), Integer)

                    End If

                Catch ex As Exception

                End Try

                Try

                    If Request.QueryString("Type") = "New" And Request.QueryString("caller") = "Timesheet" Then

                        i = 7

                    End If

                Catch ex As Exception

                End Try

            Catch ex As Exception

                i = 7

            End Try

            Return i

        End Get

    End Property
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
    Private ReadOnly Property DayToShow() As String
        Get
            Try
                If Not Session("TimesheetMain_SingleViewDayOfWeek") Is Nothing Then
                    If IsNumeric(Session("TimesheetMain_SingleViewDayOfWeek")) = True Then
                        Return Session("TimesheetMain_SingleViewDayOfWeek").ToString()
                    Else
                        Return "all7"
                    End If
                Else
                    Return "all7"
                End If
            Catch ex As Exception
                Return "all7"
            End Try
        End Get
    End Property
    'Private ReadOnly Property AlertID As Integer
    '    Get
    '        Dim _AlertID As Integer = 0
    '        Try

    '            Dim qs As New AdvantageFramework.Web.QueryString
    '            qs.FromCurrent()
    '            _AlertID = qs.AlertId
    '        Catch ex As Exception
    '            _AlertID = 0
    '        End Try
    '        If _AlertID = 0 Then
    '            Try
    '                If Request.QueryString("AlertID") IsNot Nothing Then
    '                    _AlertID = CInt(Request.QueryString("AlertID"))
    '                End If
    '            Catch ex As Exception
    '                _AlertID = 0
    '            End Try
    '        End If
    '        Return _AlertID
    '    End Get
    'End Property

#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim t As New cTimeSheet(Session("ConnString"))
        Dim q As New AdvantageFramework.Web.QueryString()
        q = q.FromCurrent()

        With q

            Me.PageType = .GetValue("Type")
            Me.Caller = .GetValue("caller")
            Me.JobNumber = .JobNumber
            Me.JobComponentNbr = .JobComponentNumber

            If Not .StartDate = "" AndAlso IsDate(.StartDate) Then

                Me.ActivityStartDate = .StartDate

            End If
            If IsNumeric(.GetValue("TaskNo")) = True Then

                Me.TaskNo = .GetValue("TaskNo")

            End If
            If Not .FunctionCode = "" Then

                Me.FunctionCode = .FunctionCode

            End If

            Me.AlertID = .AlertID

        End With

        If Me.AlertID = 0 Then

            Try

                If Request.QueryString("AlertID") IsNot Nothing Then

                    Me.AlertID = CInt(Request.QueryString("AlertID"))

                End If

            Catch ex As Exception
                Me.AlertID = 0
            End Try

        End If

        If Me.PageType = "New" Then

            Me.PageTitle = "Add New Row to Timesheet"

        End If

        Select Case Me.Caller

            Case "MainMenu"

                Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(cEmployee.TimeZoneToday.DayOfWeek, Integer)
                Session("TimesheetEmpCode") = Session("EmpCode")
                t.GetDateRange(cEmployee.TimeZoneToday, Me.StartDate, Me.EndDate)
                Session("TimesheetStartDate") = Me.StartDate

            Case "AlertView", "BoardCard"

                Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(cEmployee.TimeZoneToday.DayOfWeek, Integer)
                Session("TimesheetEmpCode") = Session("EmpCode")
                t.GetDateRange(cEmployee.TimeZoneToday, Me.StartDate, Me.EndDate)
                Session("TimesheetStartDate") = Me.StartDate
                If Me.FunctionCode <> "" Then
                    Me.TextBoxFunctionCategoryCode.Text = Me.FunctionCode
                End If

            Case "Calendar_NewActivity"

                Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(ActivityStartDate.DayOfWeek, Integer)
                Session("TimesheetEmpCode") = Session("EmpCode")
                t.GetDateRange(ActivityStartDate.Date, Me.StartDate, Me.EndDate)
                Session("TimesheetStartDate") = Me.StartDate
                LoadActivityInformation(Session("TimesheetCommentView_SingleViewDayOfWeek"))
                Me.TextBoxFunctionCategoryCode.Text = Me.FunctionCode

        End Select
        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Me.TextBoxJobNumber.Text = Me.JobNumber.ToString()
            Me.TextBoxJobComponentNbr.Text = Me.JobComponentNbr.ToString()

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, Me.TextBoxJobDescription.Text, Me.TextBoxJobComponentDescription.Text,
                                     , Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text)

            Me.SetCommentRequired()

        End If
        If Me.EmpCode = "" And Session("TimesheetEmpCode") IsNot Nothing Then

            Me.EmpCode = Session("TimesheetEmpCode")

        End If
        If Me.EmpCode = "" And Session("EmpCode") IsNot Nothing Then

            Me.EmpCode = Session("EmpCode")

        End If
        If Me.Caller <> "Calendar_NewActivity" Then

            If Me.StartDate = Nothing And Session("TimesheetStartDate") IsNot Nothing Then
                Me.StartDate = CType(Session("TimesheetStartDate"), Date)
            Else
                'reset?
                t.GetDateRange(cEmployee.TimeZoneToday, Me.StartDate, Me.EndDate)
            End If

        End If
        If Not Session("TimesheetCommentView_SingleViewDayOfWeek") Is Nothing Then

            If IsNumeric(Session("TimesheetCommentView_SingleViewDayOfWeek")) = True Then

                Me.SingleDayDayOfWeek = CType(CType(Session("TimesheetCommentView_SingleViewDayOfWeek"), Integer), DayOfWeek)
                Me.LoadSingleDay = True

            End If

        End If
        If RequireAssignment() = True Then
            Me.TextBoxAlertID.CssClass = "RequiredInput"
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        oTS.GetDateRange(StartDate, SunDate, SatDate)

        StartDate = SunDate
        MonDate = StartDate.AddDays(1)
        TueDate = StartDate.AddDays(2)
        WedDate = StartDate.AddDays(3)
        ThuDate = StartDate.AddDays(4)
        FriDate = StartDate.AddDays(5)
        SatDate = StartDate.AddDays(6)

        If Not Me.IsPostBack Then
            Try

                Me.LblSundayHeader.Text = LoGlo.FormatLongDateTime(SunDate)
                Me.LblMondayHeader.Text = LoGlo.FormatLongDateTime(MonDate)
                Me.LblTuesdayHeader.Text = LoGlo.FormatLongDateTime(TueDate)
                Me.LblWednesdayHeader.Text = LoGlo.FormatLongDateTime(WedDate)
                Me.LblThursdayHeader.Text = LoGlo.FormatLongDateTime(ThuDate)
                Me.LblFridayHeader.Text = LoGlo.FormatLongDateTime(FriDate)
                Me.LblSaturdayHeader.Text = LoGlo.FormatLongDateTime(SatDate)

                Me.HiddenFieldSundayDate.Value = SunDate.ToShortDateString()
                Me.HiddenFieldMondayDate.Value = MonDate.ToShortDateString()
                Me.HiddenFieldTuesdayDate.Value = TueDate.ToShortDateString()
                Me.HiddenFieldWednesdayDate.Value = WedDate.ToShortDateString()
                Me.HiddenFieldThursdayDate.Value = ThuDate.ToShortDateString()
                Me.HiddenFieldFridayDate.Value = FriDate.ToShortDateString()
                Me.HiddenFieldSaturdayDate.Value = SatDate.ToShortDateString()

                BindDropDept()

                If PageType = "New" Then

                    IsNewEntry = True
                    IsUpdateEntry = False

                    Me.TextBoxFunctionCategoryCode.Text = oTS.GetDefaultFunction(EmpCode)

                    Me.SetStopwatchImageButton(False, SunDate, Me.ImageButtonSundayStopWatch)
                    Me.SetStopwatchImageButton(False, MonDate, Me.ImageButtonMondayStopWatch)
                    Me.SetStopwatchImageButton(False, TueDate, Me.ImageButtonTuesdayStopWatch)
                    Me.SetStopwatchImageButton(False, WedDate, Me.ImageButtonWednesdayStopWatch)
                    Me.SetStopwatchImageButton(False, ThuDate, Me.ImageButtonThursdayStopWatch)
                    Me.SetStopwatchImageButton(False, FriDate, Me.ImageButtonFridayStopWatch)
                    Me.SetStopwatchImageButton(False, SatDate, Me.ImageButtonSaturdayStopWatch)

                ElseIf PageType = "Update" Then

                    IsNewEntry = False
                    IsUpdateEntry = True
                    LoadUpdate() '

                End If

                LoadLookups()

                SetForm()

            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try
        Else
            CheckForRowInsert()
        End If

        'force override
        If Me.LoadSingleDay = True Then

            Dim t As New cTimeSheet(Session("ConnString"))
            Select Case Me.Caller
                Case "MainMenu", "AlertView", "Stopwatch", "BoardCard"

                    t.GetDateRange(cEmployee.TimeZoneToday, Me.StartDate, Me.EndDate)

                    Dim DateToUse As Date = cEmployee.TimeZoneToday

                    Select Case StartWeekOn
                        Case DayOfWeek.Saturday

                            DateToUse = DateToUse.AddDays(1)

                        Case DayOfWeek.Monday

                            DateToUse = DateToUse.AddDays(-1)

                    End Select

                    Me.SetSingleDayToday(DateToUse.DayOfWeek)

                Case Else

                    t.GetDateRange(Me.StartDate, Me.StartDate, Me.EndDate)
                    Me.SetSingleDayToday(SingleDayDayOfWeek)

            End Select

        End If

        InitializeAngularSettings()

    End Sub

    Public Sub InitializeAngularSettings()
        Dim templateStringBuilder As New System.Text.StringBuilder()

        templateStringBuilder.AppendLine("$(document).ready(function () {{")
        templateStringBuilder.AppendLine("var timesheetSelectorScope = angular.element($('#TextBoxClientCode')).scope();")
        templateStringBuilder.AppendLine("timesheetSelectorScope.SundayDate = '{0}'; timesheetSelectorScope.currentSecurityModule = {1};")
        templateStringBuilder.AppendLine("timesheetSelectorScope.$apply();")
        templateStringBuilder.AppendLine("}});")

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "InitializeAngularSettings", String.Format(templateStringBuilder.ToString(), Me.SunDate, Me.SecurityModule), True)
    End Sub

    Private Sub CheckForRowInsert()
        If Me.IsPostBack Then
            If Request.Form("__EVENTTARGET") = "InsertTimesheetRow" AndAlso Request.Form("__EVENTARGUMENT") = "angularjs" Then
                Dim s As String = ""
                If Me.SaveAll(s) = False Then
                    Me.SetMessageLabel(s)
                Else
                    Dim c As New TimesheetCommentView
                    c.ClearSession()

                    Me.CloseThisWindow()

                End If
            End If
        End If
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If Me.IsPostBack = False AndAlso Me.IsCallback = False AndAlso Me.Caller = "Calendar_NewActivity" AndAlso String.IsNullOrWhiteSpace(Me.FunctionCode) = False Then

            Me.TextBoxFunctionCategoryCode.Text = Me.FunctionCode

            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ClientCode) = False Then Me.TextBoxClientCode.Text = Me.CurrentQuerystring.ClientCode
            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.DivisionCode) = False Then Me.TextBoxDivisionCode.Text = Me.CurrentQuerystring.DivisionCode
            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ProductCode) = False Then Me.TextBoxProductCode.Text = Me.CurrentQuerystring.ProductCode

            If Me.CurrentQuerystring.JobNumber > 0 OrElse Me.CurrentQuerystring.JobComponentNumber > 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.CurrentQuerystring.JobNumber > 0 Then

                        Me.TextBoxJobNumber.Text = Me.CurrentQuerystring.JobNumber

                        Dim Job As AdvantageFramework.Database.Entities.Job

                        Job = Nothing
                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.CurrentQuerystring.JobNumber)

                        If Job IsNot Nothing Then

                            Me.TextBoxJobDescription.Text = Job.Description

                        End If

                    End If
                    If Me.CurrentQuerystring.JobComponentNumber > 0 Then

                        Me.TextBoxJobComponentNbr.Text = Me.CurrentQuerystring.JobComponentNumber

                        Dim Component As AdvantageFramework.Database.Entities.JobComponent

                        Component = Nothing
                        Component = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.CurrentQuerystring.JobNumber, Me.CurrentQuerystring.JobComponentNumber)

                        If Component IsNot Nothing Then

                            Me.TextBoxJobComponentDescription.Text = Component.Description

                        End If

                    End If

                End Using

            End If

        End If

        InitializeAngularValues(Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text, Me.TextBoxJobNumber.Text,
                                Me.TextBoxJobComponentNbr.Text, Me.TextBoxJobDescription.Text, Me.TextBoxJobComponentDescription.Text, Me.TextBoxFunctionCategoryCode.Text, Me.TextBoxAlertID.Text)


    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadToolBarTimesheetCommentsView_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTimesheetCommentsView.ButtonClick
        Select Case e.Item.Value
            Case "Save"

                Dim s As String = ""
                If Me.SaveAll(s) = False Then

                    Me.SetMessageLabel(s)
                    Me.LoadUpdate()
                    Exit Sub

                Else

                    Dim c As New TimesheetCommentView
                    c.ClearSession()

                    Me.CloseThisWindow()

                End If

            Case "Cancel"

                Me.CloseThisWindow()

        End Select
    End Sub
    Private Sub ImageButtonSundayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSundayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Sunday, Me.TxtSundayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonMondayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonMondayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Monday, Me.TxtMondayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonTuesdayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonTuesdayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Tuesday, Me.TxtTuesdayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonWednesdayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonWednesdayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Wednesday, Me.TxtWednesdayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonThursdayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonThursdayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Thursday, Me.TxtThursdayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonFridayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonFridayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Friday, Me.TxtFridayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub
    Private Sub ImageButtonSaturdayStopWatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSaturdayStopWatch.Click

        Dim s As String = ""
        If Me.Stopwatch(DayOfWeek.Saturday, Me.TxtSaturdayComments.Text, s) = False Then

            Me.ShowMessage(s)

        Else

            Me.OpenTimesheetStopwatchNotificationWindow()

        End If

    End Sub

#End Region

#Region " Methods "

    Private Function RequireAssignment() As Boolean

        If Session("RequireAssignment") Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Session("RequireAssignment") = AdvantageFramework.EmployeeTimesheet.CheckIfAssignmentIsRequired(DbContext)

            End Using

        End If
        If Session("RequireAssignment") IsNot Nothing Then

            Return CType(Session("RequireAssignment"), Boolean)

        Else

            Return False

        End If

    End Function
    Private Sub SetSingleDayToday(ByVal TheDayOfTheWeek As DayOfWeek)

        Me.PanelSunday.Visible = False
        Me.PanelMonday.Visible = False
        Me.PanelTuesday.Visible = False
        Me.PanelWednesday.Visible = False
        Me.PanelThursday.Visible = False
        Me.PanelFriday.Visible = False
        Me.PanelSaturday.Visible = False

        If Me.Caller = "Calendar_NewActivity" Then

            Select Case Me.StartWeekOn
                Case DayOfWeek.Saturday

                    'TheDayOfTheWeek = CType(CType(TheDayOfTheWeek, Integer) + 1, DayOfWeek)
                    Select Case TheDayOfTheWeek
                        Case DayOfWeek.Saturday
                            Me.PanelSunday.Visible = True
                        Case DayOfWeek.Sunday
                            Me.PanelMonday.Visible = True
                        Case DayOfWeek.Monday
                            Me.PanelTuesday.Visible = True
                        Case DayOfWeek.Tuesday
                            Me.PanelWednesday.Visible = True
                        Case DayOfWeek.Wednesday
                            Me.PanelThursday.Visible = True
                        Case DayOfWeek.Thursday
                            Me.PanelFriday.Visible = True
                        Case DayOfWeek.Friday
                            Me.PanelSaturday.Visible = True
                    End Select

                Case DayOfWeek.Sunday

                    Select Case TheDayOfTheWeek
                        Case DayOfWeek.Sunday
                            Me.PanelSunday.Visible = True
                        Case DayOfWeek.Monday
                            Me.PanelMonday.Visible = True
                        Case DayOfWeek.Tuesday
                            Me.PanelTuesday.Visible = True
                        Case DayOfWeek.Wednesday
                            Me.PanelWednesday.Visible = True
                        Case DayOfWeek.Thursday
                            Me.PanelThursday.Visible = True
                        Case DayOfWeek.Friday
                            Me.PanelFriday.Visible = True
                        Case DayOfWeek.Saturday
                            Me.PanelSaturday.Visible = True
                    End Select

                Case DayOfWeek.Monday

                    Select Case TheDayOfTheWeek
                        Case DayOfWeek.Monday
                            Me.PanelSunday.Visible = True
                        Case DayOfWeek.Tuesday
                            Me.PanelMonday.Visible = True
                        Case DayOfWeek.Wednesday
                            Me.PanelTuesday.Visible = True
                        Case DayOfWeek.Thursday
                            Me.PanelWednesday.Visible = True
                        Case DayOfWeek.Friday
                            Me.PanelThursday.Visible = True
                        Case DayOfWeek.Saturday
                            Me.PanelFriday.Visible = True
                        Case DayOfWeek.Sunday
                            Me.PanelSaturday.Visible = True
                    End Select

            End Select

        Else

            Select Case TheDayOfTheWeek
                Case DayOfWeek.Sunday
                    Me.PanelSunday.Visible = True
                Case DayOfWeek.Monday
                    Me.PanelMonday.Visible = True
                Case DayOfWeek.Tuesday
                    Me.PanelTuesday.Visible = True
                Case DayOfWeek.Wednesday
                    Me.PanelWednesday.Visible = True
                Case DayOfWeek.Thursday
                    Me.PanelThursday.Visible = True
                Case DayOfWeek.Friday
                    Me.PanelFriday.Visible = True
                Case DayOfWeek.Saturday
                    Me.PanelSaturday.Visible = True
            End Select

        End If

    End Sub
    Private Sub SetForm()

        If ProductCategoryIsVisible() = True Then

            Me.TextBoxProductCategory.Enabled = IsNewEntry

        End If

        Me.HiddenField_EmployeeCode.Value = Me.EmpCode

        Me.TextBoxClientCode.Enabled = IsNewEntry
        Me.TextBoxDivisionCode.Enabled = IsNewEntry
        Me.TextBoxProductCode.Enabled = IsNewEntry
        Me.TextBoxJobNumber.Enabled = IsNewEntry
        Me.TextBoxJobComponentNbr.Enabled = IsNewEntry
        Me.TextBoxJobDescription.Enabled = IsNewEntry
        Me.TextBoxJobComponentDescription.Enabled = IsNewEntry
        Me.TextBoxFunctionCategoryCode.Enabled = IsNewEntry
        Me.TextBoxProductCategory.Enabled = IsNewEntry
        Me.TextBoxAlertID.Enabled = IsNewEntry

        Me.TxtSundayHours.Enabled = True
        Me.TxtMondayHours.Enabled = True
        Me.TxtTuesdayHours.Enabled = True
        Me.TxtWednesdayHours.Enabled = True
        Me.TxtThursdayHours.Enabled = True
        Me.TxtFridayHours.Enabled = True
        Me.TxtSaturdayHours.Enabled = True

        Me.RadComboBoxDepartment.Enabled = IsNewEntry

        If RadComboBoxDepartment.Items.Count <= 1 Then

            RadComboBoxDepartment.Enabled = False

        End If

        Dim DaysToShow As Integer = 0
        Dim ShowCommentUsing As String = ""
        Dim DivisionLabel As String = ""
        Dim ProductLabel As String = ""
        Dim ProductCategoryLabel As String = ""
        Dim JobLabel As String = ""
        Dim JobComponentLabel As String = ""
        Dim FunctionCategoryLabel As String = ""
        Dim c As New cTimeSheet(Session("ConnString"))
        Dim s As String = ""

        If c.GetTimesheetSettings(Session("UserCode"), DaysToShow, StartWeekOn, ShowCommentUsing,
                DivisionLabel, ProductLabel, ProductCategoryLabel, JobLabel, JobComponentLabel, FunctionCategoryLabel, s) = True Then

            Me.Label_Division.Text = DivisionLabel
            Me.Label_Product.Text = ProductLabel
            Me.Label_Job.Text = JobLabel
            Me.Label_JobComp.Text = JobComponentLabel
            Me.Label_FuncCat.Text = FunctionCategoryLabel
            Me.Label_ProdCat.Text = ProductCategoryLabel

        Else

            Me.Label_Division.Text = "Division"
            Me.Label_Product.Text = "Product"
            Me.Label_Job.Text = "Job"
            Me.Label_JobComp.Text = "Job Comp"
            Me.Label_FuncCat.Text = "Function/Category"
            Me.Label_ProdCat.Text = "Product Category"

        End If

        If ProductCategoryIsVisible() = False Then

            Me.Label_ProdCat.Visible = False
            Me.TextBoxProductCategory.Visible = False

        End If

        Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType
        Dim ClosedMsg As String = "&nbsp;<span class=""CssRequired"">(Timesheet has been submitted for approval and cannot be edited.)</span>"
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        Dim SunHideStopwatch As Boolean = False
        Dim MonHideStopwatch As Boolean = False
        Dim TueHideStopwatch As Boolean = False
        Dim WedHideStopwatch As Boolean = False
        Dim ThuHideStopwatch As Boolean = False
        Dim FriHideStopwatch As Boolean = False
        Dim SatHideStopwatch As Boolean = False

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, SunDate)
        If oTS.CheckApprovalStatus(EmpCode, SunDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblSundayHeader.Text &= ClosedMsg
            Me.TxtSundayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtSundayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtSundayHours.Text = "0.00" Then
                Me.TxtSundayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtSundayHours.Text <> "0.00" Then
                Me.TxtSundayComments.Enabled = True
            End If
            SunHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtSundayHours.Enabled = True
            If IsUpdateEntry And Me.TxtSundayHours.Text <> "0.00" Then
                Me.TxtSundayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, MonDate)
        If oTS.CheckApprovalStatus(EmpCode, MonDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblMondayHeader.Text &= ClosedMsg
            Me.TxtMondayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtMondayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtMondayHours.Text = "0.00" Then
                Me.TxtMondayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtMondayHours.Text <> "0.00" Then
                Me.TxtMondayComments.Enabled = True
            End If
            MonHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtMondayHours.Enabled = True
            If IsUpdateEntry And Me.TxtMondayHours.Text <> "0.00" Then
                Me.TxtMondayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, TueDate)
        If oTS.CheckApprovalStatus(EmpCode, TueDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblTuesdayHeader.Text &= ClosedMsg
            Me.TxtTuesdayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtTuesdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtTuesdayHours.Text = "0.00" Then
                Me.TxtTuesdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtTuesdayHours.Text <> "0.00" Then
                Me.TxtTuesdayComments.Enabled = True
            End If
            TueHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtTuesdayHours.Enabled = True
            If IsUpdateEntry And Me.TxtTuesdayHours.Text <> "0.00" Then
                Me.TxtTuesdayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, WedDate)
        If oTS.CheckApprovalStatus(EmpCode, WedDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblWednesdayHeader.Text &= ClosedMsg
            Me.TxtWednesdayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtWednesdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtWednesdayHours.Text = "0.00" Then
                Me.TxtWednesdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtWednesdayHours.Text <> "0.00" Then
                Me.TxtWednesdayComments.Enabled = True
            End If
            WedHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtWednesdayHours.Enabled = True
            If IsUpdateEntry And Me.TxtWednesdayHours.Text <> "0.00" Then
                Me.TxtWednesdayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, ThuDate)
        If oTS.CheckApprovalStatus(EmpCode, ThuDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblThursdayHeader.Text &= ClosedMsg
            Me.TxtThursdayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtThursdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtThursdayHours.Text = "0.00" Then
                Me.TxtThursdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtThursdayHours.Text <> "0.00" Then
                Me.TxtThursdayComments.Enabled = True
            End If
            ThuHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtThursdayHours.Enabled = True
            If IsUpdateEntry And Me.TxtThursdayHours.Text <> "0.00" Then
                Me.TxtThursdayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, FriDate)
        If oTS.CheckApprovalStatus(EmpCode, FriDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblFridayHeader.Text &= ClosedMsg
            Me.TxtFridayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtFridayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtFridayHours.Text = "0.00" Then
                Me.TxtFridayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtFridayHours.Text <> "0.00" Then
                Me.TxtFridayComments.Enabled = True
            End If
            FriHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtFridayHours.Enabled = True
            If IsUpdateEntry And Me.TxtFridayHours.Text <> "0.00" Then
                Me.TxtFridayComments.Enabled = True
            End If
        End If

        CurrEditStatus = oTS.CheckEditStatus(EmpCode, SatDate)
        If oTS.CheckApprovalStatus(EmpCode, SatDate) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.LblSaturdayHeader.Text &= ClosedMsg
            Me.TxtSaturdayHours.Enabled = False
            If IsNewEntry Then
                Me.TxtSaturdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtSaturdayHours.Text = "0.00" Then
                Me.TxtSaturdayComments.Enabled = False
            ElseIf IsUpdateEntry And Me.TxtSaturdayHours.Text <> "0.00" Then
                Me.TxtSaturdayComments.Enabled = True
            End If
            SatHideStopwatch = True
        ElseIf CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
            Me.TxtSaturdayHours.Enabled = True
            If IsUpdateEntry And Me.TxtSaturdayHours.Text <> "0.00" Then
                Me.TxtSaturdayComments.Enabled = True
            End If
        End If

        SunClosedPP = oTS.PostPeriodClosed(SunDate)
        MonClosedPP = oTS.PostPeriodClosed(MonDate)
        TueClosedPP = oTS.PostPeriodClosed(TueDate)
        WedClosedPP = oTS.PostPeriodClosed(WedDate)
        ThuClosedPP = oTS.PostPeriodClosed(ThuDate)
        FriClosedPP = oTS.PostPeriodClosed(FriDate)
        SatClosedPP = oTS.PostPeriodClosed(SatDate)

        If SunClosedPP = True AndAlso MonClosedPP = True AndAlso TueClosedPP = True AndAlso WedClosedPP = True AndAlso ThuClosedPP = True AndAlso FriClosedPP = True AndAlso SatClosedPP = True Then

            Me.LblMessage.Text = "This Posting Period is Closed"
            Me.RadToolBarTimesheetCommentsView.FindItemByValue("Save").Enabled = False
            Me.TxtSundayHours.Enabled = False
            Me.TxtSundayComments.Enabled = False
            Me.TxtMondayHours.Enabled = False
            Me.TxtMondayComments.Enabled = False
            Me.TxtTuesdayHours.Enabled = False
            Me.TxtTuesdayComments.Enabled = False
            Me.TxtWednesdayHours.Enabled = False
            Me.TxtWednesdayComments.Enabled = False
            Me.TxtThursdayHours.Enabled = False
            Me.TxtThursdayComments.Enabled = False
            Me.TxtFridayHours.Enabled = False
            Me.TxtFridayComments.Enabled = False
            Me.TxtSaturdayHours.Enabled = False
            Me.TxtSaturdayComments.Enabled = False

            SunHideStopwatch = True
            MonHideStopwatch = True
            TueHideStopwatch = True
            WedHideStopwatch = True
            ThuHideStopwatch = True
            FriHideStopwatch = True
            SatHideStopwatch = True

        ElseIf SunClosedPP = True OrElse MonClosedPP = True OrElse TueClosedPP = True OrElse WedClosedPP = True OrElse ThuClosedPP = True OrElse FriClosedPP = True OrElse SatClosedPP = True Then

            Me.LblMessage.Text = "This week has days where the posting period is closed"
            Me.RadToolBarTimesheetCommentsView.FindItemByValue("Save").Enabled = True

            If SunClosedPP = True Then
                Me.TxtSundayHours.Enabled = False
                Me.TxtSundayComments.Enabled = False
                SunHideStopwatch = True
            End If
            If MonClosedPP = True Then
                Me.TxtMondayHours.Enabled = False
                Me.TxtMondayComments.Enabled = False
                MonHideStopwatch = True
            End If
            If TueClosedPP = True Then
                Me.TxtTuesdayHours.Enabled = False
                Me.TxtTuesdayComments.Enabled = False
                TueHideStopwatch = True
            End If
            If WedClosedPP = True Then
                Me.TxtWednesdayHours.Enabled = False
                Me.TxtWednesdayComments.Enabled = False
                WedHideStopwatch = True
            End If
            If ThuClosedPP = True Then
                Me.TxtThursdayHours.Enabled = False
                Me.TxtThursdayComments.Enabled = False
                ThuHideStopwatch = True
            End If
            If FriClosedPP = True Then
                Me.TxtFridayHours.Enabled = False
                Me.TxtFridayComments.Enabled = False
                FriHideStopwatch = True
            End If
            If SatClosedPP = True Then
                Me.TxtSaturdayHours.Enabled = False
                Me.TxtSaturdayComments.Enabled = False
                SatHideStopwatch = True
            End If

        End If

        Dim cvs As New TimesheetCommentView
        cvs.FromSession()

        If Not cvs Is Nothing Then

            EditMessage = cvs.CVData.EditMessage

            If EditMessage <> "" Then

                Me.LblMessage.Text = EditMessage
                Me.TxtSundayHours.Enabled = False
                Me.TxtMondayHours.Enabled = False
                Me.TxtTuesdayHours.Enabled = False
                Me.TxtWednesdayHours.Enabled = False
                Me.TxtThursdayHours.Enabled = False
                Me.TxtFridayHours.Enabled = False
                Me.TxtSaturdayHours.Enabled = False
                Me.TxtSundayComments.Enabled = False
                Me.TxtMondayComments.Enabled = False
                Me.TxtTuesdayComments.Enabled = False
                Me.TxtWednesdayComments.Enabled = False
                Me.TxtThursdayComments.Enabled = False
                Me.TxtFridayComments.Enabled = False
                Me.TxtSaturdayComments.Enabled = False

                SunHideStopwatch = True
                MonHideStopwatch = True
                TueHideStopwatch = True
                WedHideStopwatch = True
                ThuHideStopwatch = True
                FriHideStopwatch = True
                SatHideStopwatch = True

                Me.RadToolBarTimesheetCommentsView.FindItemByValue("Save").Enabled = False

            End If

            SetEditFlagEnable(Me.TxtSundayHours, Me.TxtSundayComments, cvs.CVData.SunEditFlag)
            SetEditFlagEnable(Me.TxtMondayHours, Me.TxtMondayComments, cvs.CVData.MonEditFlag)
            SetEditFlagEnable(Me.TxtTuesdayHours, Me.TxtTuesdayComments, cvs.CVData.TueEditFlag)
            SetEditFlagEnable(Me.TxtWednesdayHours, Me.TxtWednesdayComments, cvs.CVData.WedEditFlag)
            SetEditFlagEnable(Me.TxtThursdayHours, Me.TxtThursdayComments, cvs.CVData.ThuEditFlag)
            SetEditFlagEnable(Me.TxtFridayHours, Me.TxtFridayComments, cvs.CVData.FriEditFlag)
            SetEditFlagEnable(Me.TxtSaturdayHours, Me.TxtSaturdayComments, cvs.CVData.SatEditFlag)

        End If

        If SunHideStopwatch = False AndAlso Me.TxtSundayHours.Enabled = False Then
            SunHideStopwatch = True
        End If
        If MonHideStopwatch = False AndAlso Me.TxtMondayHours.Enabled = False Then
            MonHideStopwatch = True
        End If
        If TueHideStopwatch = False AndAlso Me.TxtTuesdayHours.Enabled = False Then
            TueHideStopwatch = True
        End If
        If WedHideStopwatch = False AndAlso Me.TxtWednesdayHours.Enabled = False Then
            WedHideStopwatch = True
        End If
        If ThuHideStopwatch = False AndAlso Me.TxtThursdayHours.Enabled = False Then
            ThuHideStopwatch = True
        End If
        If FriHideStopwatch = False AndAlso Me.TxtFridayHours.Enabled = False Then
            FriHideStopwatch = True
        End If
        If SatHideStopwatch = False AndAlso Me.TxtSaturdayHours.Enabled = False Then
            SatHideStopwatch = True
        End If

        Me.SetStopwatchImageButton(Me.SunHasStopwatch, SunDate, Me.ImageButtonSundayStopWatch, SunHideStopwatch)
        Me.SetStopwatchImageButton(Me.MonHasStopwatch, MonDate, Me.ImageButtonMondayStopWatch, MonHideStopwatch)
        Me.SetStopwatchImageButton(Me.TueHasStopwatch, TueDate, Me.ImageButtonTuesdayStopWatch, TueHideStopwatch)
        Me.SetStopwatchImageButton(Me.WedHasStopwatch, WedDate, Me.ImageButtonWednesdayStopWatch, WedHideStopwatch)
        Me.SetStopwatchImageButton(Me.ThuHasStopwatch, ThuDate, Me.ImageButtonThursdayStopWatch, ThuHideStopwatch)
        Me.SetStopwatchImageButton(Me.FriHasStopwatch, FriDate, Me.ImageButtonFridayStopWatch, FriHideStopwatch)
        Me.SetStopwatchImageButton(Me.SatHasStopwatch, SatDate, Me.ImageButtonSaturdayStopWatch, SatHideStopwatch)

        'disable hours and comments when stopwatch is running
        If Me.SunHasStopwatch = True And Me.TxtSundayHours.Enabled = True Then
            Me.TxtSundayHours.Enabled = False
            'Me.TxtSundayComments.Enabled = False
        End If
        If Me.MonHasStopwatch = True And Me.TxtMondayHours.Enabled = True Then
            Me.TxtMondayHours.Enabled = False
            'Me.TxtMondayComments.Enabled = False
        End If
        If Me.TueHasStopwatch = True And Me.TxtTuesdayHours.Enabled = True Then
            Me.TxtTuesdayHours.Enabled = False

        End If
        If Me.WedHasStopwatch = True And Me.TxtWednesdayHours.Enabled = True Then
            Me.TxtWednesdayHours.Enabled = False
        End If
        If Me.ThuHasStopwatch = True And Me.TxtThursdayHours.Enabled = True Then
            Me.TxtThursdayHours.Enabled = False
        End If
        If Me.FriHasStopwatch = True And Me.TxtFridayHours.Enabled = True Then
            Me.TxtFridayHours.Enabled = False
        End If
        If Me.SatHasStopwatch = True And Me.TxtSaturdayHours.Enabled = True Then
            Me.TxtSaturdayHours.Enabled = False
        End If

        If IsNumeric(Me.TxtSundayHours.Text) = True Then
            Me.TxtSundayHours.Text = FormatNumber(Me.TxtSundayHours.Text, 2)
        End If
        If IsNumeric(Me.TxtMondayHours.Text) = True Then
            Me.TxtMondayHours.Text = FormatNumber(Me.TxtMondayHours.Text, 2)
        End If
        If IsNumeric(Me.TxtTuesdayHours.Text) = True Then
            Me.TxtTuesdayHours.Text = FormatNumber(Me.TxtTuesdayHours.Text, 2)
        End If
        If IsNumeric(Me.TxtWednesdayHours.Text) = True Then
            Me.TxtWednesdayHours.Text = FormatNumber(Me.TxtWednesdayHours.Text, 2)
        End If
        If IsNumeric(Me.TxtThursdayHours.Text) = True Then
            Me.TxtThursdayHours.Text = FormatNumber(Me.TxtThursdayHours.Text, 2)
        End If
        If IsNumeric(Me.TxtFridayHours.Text) = True Then
            Me.TxtFridayHours.Text = FormatNumber(Me.TxtFridayHours.Text, 2)
        End If
    End Sub
    Private Sub SetStopwatchImageButton(ByVal HasStopwatch As Boolean, ByVal [Date] As Date, ByRef StopwatchImageButton As System.Web.UI.WebControls.ImageButton, Optional ByVal HideStopwatch As Boolean = False)
        If HasStopwatch = True Then
            With StopwatchImageButton
                .ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                .ToolTip = "Stop Stopwatch"
            End With
        Else
            With StopwatchImageButton
                .ImageUrl = "~/Images/Icons/Grey/256/stopwatch.png"
                .ToolTip = "Start Stopwatch"
            End With
        End If

        If HideStopwatch = True Then

            StopwatchImageButton.Visible = False

        Else

            If HasStopwatch = True OrElse [Date].ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then
                StopwatchImageButton.Visible = True
            Else
                StopwatchImageButton.Visible = False
            End If

        End If

    End Sub
    Private Sub LoadLookups()
        Dim StringBuilder_Script As System.Text.StringBuilder = New System.Text.StringBuilder

        If Me.IsNewEntry Then

            StringBuilder_Script.AppendLine("$(document).ready(function () {{")
            StringBuilder_Script.AppendLine(" setTimeout(function(){{")
            StringBuilder_Script.AppendLine("	var currentScope = angular.element($('#TextBoxClientCode')).scope();")
            StringBuilder_Script.AppendLine("	currentScope.EmployeeCode = '{0}';")
            StringBuilder_Script.AppendLine("   currentScope.$apply();")

            Dim FirstDayOfWeek = New Date(cEmployee.TimeZoneToday.Year, cEmployee.TimeZoneToday.Month, cEmployee.TimeZoneToday.Day)

            If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                    FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                    If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                        FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                        If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                            FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                            If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                                FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                                If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                                    FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                                    If (FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday) Then
                                        FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If (Me.JobNumber > 0 AndAlso Me.JobComponentNbr > 0) Then

                StringBuilder_Script.AppendLine("	currentScope.fillJobAndComponent({1}, {2});")

            End If

            StringBuilder_Script.AppendLine("	currentScope.currentSecurityModule = {3};")
            StringBuilder_Script.AppendLine("	currentScope.firstDayOfWeek = '{4}';")

            If Me.IsPostBack = False AndAlso Me.IsCallback = False AndAlso Me.Caller = "Calendar_NewActivity" AndAlso String.IsNullOrWhiteSpace(Me.FunctionCode) = False Then

                'Me.TextBoxFunctionCategoryCode.Text = Me.FunctionCode
                'InitializeAngularValues(Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text, Me.TextBoxJobNumber.Text,
                '                        Me.TextBoxJobComponentNbr.Text, Me.TextBoxJobDescription.Text, Me.TextBoxJobComponentDescription.Text, Me.TextBoxFunctionCategoryCode.Text)

            Else

                StringBuilder_Script.AppendLine("   currentScope.getEmployeeDefaultFunction();")

            End If

            StringBuilder_Script.AppendLine(" }}, 500);")
            StringBuilder_Script.AppendLine("}});")

            Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "SetCurrentEmployeeCode", String.Format(StringBuilder_Script.ToString(), Me.EmpCode, Me.JobNumber, Me.JobComponentNbr, Me.SecurityModule, FirstDayOfWeek), True)

        Else

            Dim cvs As New TimesheetCommentView
            cvs.FromSession()

            StringBuilder_Script.AppendLine("$(document).ready(function () {{")
            StringBuilder_Script.AppendLine("  disableSearch();")
            StringBuilder_Script.AppendLine("	var currentScope = angular.element($('#TextBoxClientCode')).scope();")
            StringBuilder_Script.AppendLine("	currentScope.suppressDefaultDivision = true;")
            StringBuilder_Script.AppendLine("	currentScope.suppressDefaultProduct = true;")
            StringBuilder_Script.AppendLine("	currentScope.EmployeeCode = '{0}';")
            StringBuilder_Script.AppendLine("	currentScope.currentSecurityModule = {1};")
            StringBuilder_Script.AppendLine("   currentScope.$apply();")
            StringBuilder_Script.AppendLine("}});")

            Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "disable-angular-search", String.Format(StringBuilder_Script.ToString(), Me.EmpCode, Me.SecurityModule), True)
        End If
    End Sub

    Public Sub InitializeAngularValues(ClientCode As String, DivisionCode As String, ProductCode As String, JobNumber As String, JobComponentNumber As String,
                                       JobDescription As String, JobComponentDescription As String, FunctionCategory As String, AlertID As String)

        Dim StringBuilder_Script As System.Text.StringBuilder = New System.Text.StringBuilder

        StringBuilder_Script.AppendLine("$(document).ready(function () {{")
        StringBuilder_Script.AppendLine(" setTimeout(function(){{")
        StringBuilder_Script.AppendLine("	var currentScope = angular.element($('#TextBoxClientCode')).scope();")
        StringBuilder_Script.AppendLine("	currentScope.ClientCode = '{0}';")
        StringBuilder_Script.AppendLine("	currentScope.DivisionCode = '{1}';")
        StringBuilder_Script.AppendLine("	currentScope.ProductCode = '{2}';")
        StringBuilder_Script.AppendLine("	currentScope.JobNumber = '{3}';")
        StringBuilder_Script.AppendLine("	currentScope.JobComponentNumber = '{4}';")
        StringBuilder_Script.AppendLine("	currentScope.JobDescription = '{5}';")
        StringBuilder_Script.AppendLine("	currentScope.JobComponentDescription = '{6}';")
        StringBuilder_Script.AppendLine("   currentScope.FunctionCategory = '{7}';")
        StringBuilder_Script.AppendLine("   currentScope.AlertID = '{8}';")
        StringBuilder_Script.AppendLine("   currentScope.$apply();")
        StringBuilder_Script.AppendLine(" }}, 500);")
        StringBuilder_Script.AppendLine("}});")

        Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "InitializeAngularValues", String.Format(StringBuilder_Script.ToString(), ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber,
                                                                                                            JobDescription, JobComponentDescription, FunctionCategory, AlertID), True)

    End Sub

    Private Sub LoadUpdate()

        Dim cvs As New TimesheetCommentView
        cvs.FromSession()

        Me.TextBoxClientCode.Text = cvs.CVData.ClCode
        Me.TextBoxDivisionCode.Text = cvs.CVData.DivCode
        Me.TextBoxProductCode.Text = cvs.CVData.PrdCode
        Try
            If cvs.CVData.AlertID > 0 Then
                Me.TextBoxAlertID.Text = cvs.CVData.AlertID
            End If
        Catch ex As Exception
        End Try

        If cvs.CVData.JobNumber > 0 Then

            Me.TextBoxJobNumber.Text = cvs.CVData.JobNumber
            Me.SetCommentRequired()

        Else

            Me.TextBoxJobNumber.Text = ""

        End If

        If cvs.CVData.JobComponentNbr > 0 Then

            Me.TextBoxJobComponentNbr.Text = cvs.CVData.JobComponentNbr

        Else

            Me.TextBoxJobComponentNbr.Text = ""

        End If

        If cvs.CVData.JobNumber > 0 And cvs.CVData.JobComponentNbr > 0 Then

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            oTS.GetJobComponentInfo(cvs.CVData.JobNumber, cvs.CVData.JobComponentNbr, Me.TextBoxJobDescription.Text, Me.TextBoxJobComponentDescription.Text)

        End If

        Me.TextBoxFunctionCategoryCode.Text = cvs.CVData.FuncCat

        Try

            If cvs.CVData.Dept <> "" Then

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDepartment, cvs.CVData.Dept, False, True)

            End If

        Catch ex As Exception
        End Try

        Me.TextBoxProductCategory.Text = cvs.CVData.ProdCat

        Dim oComments As cComments = New cComments(CStr(Session("ConnString")))
        Select Case Me.StartWeekOn
            Case DayOfWeek.Saturday

                Me.TxtSundayHours.Text = cvs.CVData.SatSavedHours
                Me.TxtMondayHours.Text = cvs.CVData.SunSavedHours
                Me.TxtTuesdayHours.Text = cvs.CVData.MonSavedHours
                Me.TxtWednesdayHours.Text = cvs.CVData.TueSavedHours
                Me.TxtThursdayHours.Text = cvs.CVData.WedSavedHours
                Me.TxtFridayHours.Text = cvs.CVData.ThuSavedHours
                Me.TxtSaturdayHours.Text = cvs.CVData.FriSavedHours

                Me.TxtSundayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SatTimeType, cvs.CVData.SatEtId, cvs.CVData.SatEtDtlId)
                Me.TxtMondayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SunTimeType, cvs.CVData.SunEtId, cvs.CVData.SunEtDtlId)
                Me.TxtTuesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.MonTimeType, cvs.CVData.MonEtId, cvs.CVData.MonEtDtlId)
                Me.TxtWednesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.TueTimeType, cvs.CVData.TueEtId, cvs.CVData.TueEtDtlId)
                Me.TxtThursdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.WedTimeType, cvs.CVData.WedEtId, cvs.CVData.WedEtDtlId)
                Me.TxtFridayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.ThuTimeType, cvs.CVData.ThuEtId, cvs.CVData.ThuEtDtlId)
                Me.TxtSaturdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.FriTimeType, cvs.CVData.FriEtId, cvs.CVData.FriEtDtlId)

                Me.SunHasStopwatch = cvs.CVData.SatHasStopWatch
                Me.MonHasStopwatch = cvs.CVData.SunHasStopWatch
                Me.TueHasStopwatch = cvs.CVData.MonHasStopWatch
                Me.WedHasStopwatch = cvs.CVData.TueHasStopWatch
                Me.ThuHasStopwatch = cvs.CVData.WedHasStopWatch
                Me.FriHasStopwatch = cvs.CVData.ThuHasStopWatch
                Me.SatHasStopwatch = cvs.CVData.FriHasStopWatch

            Case DayOfWeek.Sunday

                Me.TxtSundayHours.Text = cvs.CVData.SunSavedHours
                Me.TxtMondayHours.Text = cvs.CVData.MonSavedHours
                Me.TxtTuesdayHours.Text = cvs.CVData.TueSavedHours
                Me.TxtWednesdayHours.Text = cvs.CVData.WedSavedHours
                Me.TxtThursdayHours.Text = cvs.CVData.ThuSavedHours
                Me.TxtFridayHours.Text = cvs.CVData.FriSavedHours
                Me.TxtSaturdayHours.Text = cvs.CVData.SatSavedHours

                Me.TxtSundayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SunTimeType, cvs.CVData.SunEtId, cvs.CVData.SunEtDtlId)
                Me.TxtMondayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.MonTimeType, cvs.CVData.MonEtId, cvs.CVData.MonEtDtlId)
                Me.TxtTuesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.TueTimeType, cvs.CVData.TueEtId, cvs.CVData.TueEtDtlId)
                Me.TxtWednesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.WedTimeType, cvs.CVData.WedEtId, cvs.CVData.WedEtDtlId)
                Me.TxtThursdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.ThuTimeType, cvs.CVData.ThuEtId, cvs.CVData.ThuEtDtlId)
                Me.TxtFridayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.FriTimeType, cvs.CVData.FriEtId, cvs.CVData.FriEtDtlId)
                Me.TxtSaturdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SatTimeType, cvs.CVData.SatEtId, cvs.CVData.SatEtDtlId)

                Me.SunHasStopwatch = cvs.CVData.SunHasStopWatch
                Me.MonHasStopwatch = cvs.CVData.MonHasStopWatch
                Me.TueHasStopwatch = cvs.CVData.TueHasStopWatch
                Me.WedHasStopwatch = cvs.CVData.WedHasStopWatch
                Me.ThuHasStopwatch = cvs.CVData.ThuHasStopWatch
                Me.FriHasStopwatch = cvs.CVData.FriHasStopWatch
                Me.SatHasStopwatch = cvs.CVData.SatHasStopWatch

            Case DayOfWeek.Monday

                Me.TxtSundayHours.Text = cvs.CVData.MonSavedHours
                Me.TxtMondayHours.Text = cvs.CVData.TueSavedHours
                Me.TxtTuesdayHours.Text = cvs.CVData.WedSavedHours
                Me.TxtWednesdayHours.Text = cvs.CVData.ThuSavedHours
                Me.TxtThursdayHours.Text = cvs.CVData.FriSavedHours
                Me.TxtFridayHours.Text = cvs.CVData.SatSavedHours
                Me.TxtSaturdayHours.Text = cvs.CVData.SunSavedHours

                Me.TxtSundayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.MonTimeType, cvs.CVData.MonEtId, cvs.CVData.MonEtDtlId)
                Me.TxtMondayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.TueTimeType, cvs.CVData.TueEtId, cvs.CVData.TueEtDtlId)
                Me.TxtTuesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.WedTimeType, cvs.CVData.WedEtId, cvs.CVData.WedEtDtlId)
                Me.TxtWednesdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.ThuTimeType, cvs.CVData.ThuEtId, cvs.CVData.ThuEtDtlId)
                Me.TxtThursdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.FriTimeType, cvs.CVData.FriEtId, cvs.CVData.FriEtDtlId)
                Me.TxtFridayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SatTimeType, cvs.CVData.SatEtId, cvs.CVData.SatEtDtlId)
                Me.TxtSaturdayComments.Text = oComments.GetEmpTimeComments(cvs.CVData.SunTimeType, cvs.CVData.SunEtId, cvs.CVData.SunEtDtlId)

                Me.SunHasStopwatch = cvs.CVData.MonHasStopWatch
                Me.MonHasStopwatch = cvs.CVData.TueHasStopWatch
                Me.TueHasStopwatch = cvs.CVData.WedHasStopWatch
                Me.WedHasStopwatch = cvs.CVData.ThuHasStopWatch
                Me.ThuHasStopwatch = cvs.CVData.FriHasStopWatch
                Me.FriHasStopwatch = cvs.CVData.SatHasStopWatch
                Me.SatHasStopwatch = cvs.CVData.SunHasStopWatch

        End Select

        Me.TxtSundayHours.Text = FormatNumber(TxtSundayHours.Text, 2, True)
        Me.TxtMondayHours.Text = FormatNumber(TxtMondayHours.Text, 2, True)
        Me.TxtTuesdayHours.Text = FormatNumber(TxtTuesdayHours.Text, 2, True)
        Me.TxtWednesdayHours.Text = FormatNumber(TxtWednesdayHours.Text, 2, True)
        Me.TxtThursdayHours.Text = FormatNumber(TxtThursdayHours.Text, 2, True)
        Me.TxtFridayHours.Text = FormatNumber(TxtFridayHours.Text, 2, True)
        Me.TxtSaturdayHours.Text = FormatNumber(TxtSaturdayHours.Text, 2, True)

        Me.HfSundayHours.Value = Me.TxtSundayHours.Text
        Me.HfMondayHours.Value = Me.TxtMondayHours.Text
        Me.HfTuesdayHours.Value = Me.TxtTuesdayHours.Text
        Me.HfWednesdayHours.Value = Me.TxtWednesdayHours.Text
        Me.HfThursdayHours.Value = Me.TxtThursdayHours.Text
        Me.HfFridayHours.Value = Me.TxtFridayHours.Text
        Me.HfSaturdayHours.Value = Me.TxtSaturdayHours.Text

        Me.HfMondayComments.Value = Me.TxtMondayComments.Text
        Me.HfTuesdayComments.Value = Me.TxtTuesdayComments.Text
        Me.HfWednesdayComments.Value = Me.TxtWednesdayComments.Text
        Me.HfThursdayComments.Value = Me.TxtThursdayComments.Text
        Me.HfFridayComments.Value = Me.TxtFridayComments.Text
        Me.HfSundayComments.Value = Me.TxtSundayComments.Text
        Me.HfSaturdayComments.Value = Me.TxtSaturdayComments.Text

        Me.PanelSunday.Visible = False
        Me.PanelMonday.Visible = False
        Me.PanelTuesday.Visible = False
        Me.PanelWednesday.Visible = False
        Me.PanelThursday.Visible = False
        Me.PanelFriday.Visible = False
        Me.PanelSaturday.Visible = False

        If Me.DaysToDisplay = 7 Then

            Me.PanelSunday.Visible = True
            Me.PanelMonday.Visible = True
            Me.PanelTuesday.Visible = True
            Me.PanelWednesday.Visible = True
            Me.PanelThursday.Visible = True
            Me.PanelFriday.Visible = True
            Me.PanelSaturday.Visible = True

        ElseIf Me.DaysToDisplay = 5 Then

            Select Case Me.StartWeekOn
                Case DayOfWeek.Saturday

                    Me.PanelTuesday.Visible = True
                    Me.PanelWednesday.Visible = True
                    Me.PanelThursday.Visible = True
                    Me.PanelFriday.Visible = True
                    Me.PanelSaturday.Visible = True

                Case DayOfWeek.Sunday

                    Me.PanelMonday.Visible = True
                    Me.PanelTuesday.Visible = True
                    Me.PanelWednesday.Visible = True
                    Me.PanelThursday.Visible = True
                    Me.PanelFriday.Visible = True

                Case DayOfWeek.Monday

                    Me.PanelSunday.Visible = True
                    Me.PanelMonday.Visible = True
                    Me.PanelTuesday.Visible = True
                    Me.PanelWednesday.Visible = True
                    Me.PanelThursday.Visible = True

            End Select

        End If

        InitializeAngularValues(Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text, Me.TextBoxJobNumber.Text,
                                Me.TextBoxJobComponentNbr.Text, Me.TextBoxJobDescription.Text, Me.TextBoxJobComponentDescription.Text, Me.TextBoxFunctionCategoryCode.Text, Me.TextBoxAlertID.Text)

    End Sub
    Private Function SaveDay(ByRef TextBox_Comments As System.Web.UI.WebControls.TextBox, ByRef TextBox_Hours As System.Web.UI.WebControls.TextBox, ByRef HiddenField_Hours As System.Web.UI.WebControls.HiddenField, ByRef HiddenField_Comments As System.Web.UI.WebControls.HiddenField,
                             ByVal BypassCommentsReq As Boolean, Optional ByRef ErrorMessage As String = "",
                             Optional ByRef ReturnEtId As Integer = 0, Optional ByRef ReturnEtDtlId As Short = 0) As Boolean

        Try

            Dim cvs As New TimesheetCommentView
            cvs.FromSession()

            Dim oComments As cComments = New cComments(CStr(Session("ConnString")))
            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

            Dim CurrETID As Integer = 0
            Dim CurrETDID As Short = 0
            Dim CurrTimeType As String = ""
            Dim Suffix As String = ""
            Dim ThisDate As Date = Nothing
            Dim AllowZero As Boolean = False

            If IsNumeric(TextBoxAlertID.Text) = True Then

                AlertID = CType(TextBoxAlertID.Text, Integer)

            Else

                AlertID = 0

            End If

            Select Case Me.StartWeekOn
                Case DayOfWeek.Saturday

                    If TextBox_Comments.ID.IndexOf("Sunday") > 0 Then
                        Suffix = "Sunday"
                        ThisDate = SunDate
                        CurrTimeType = cvs.CVData.SatTimeType
                        Try
                            CurrETID = cvs.CVData.SatEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SatEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Monday") > 0 Then
                        Suffix = "Monday"
                        ThisDate = MonDate
                        CurrTimeType = cvs.CVData.SunTimeType
                        Try
                            CurrETID = cvs.CVData.SunEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SunEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                        AllowZero = True
                    ElseIf TextBox_Comments.ID.IndexOf("Tuesday") > 0 Then
                        Suffix = "Tuesday"
                        ThisDate = TueDate
                        CurrTimeType = cvs.CVData.MonTimeType
                        Try
                            CurrETID = cvs.CVData.MonEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.MonEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Wednesday") > 0 Then
                        Suffix = "Wednesday"
                        ThisDate = WedDate
                        CurrTimeType = cvs.CVData.TueTimeType
                        Try
                            CurrETID = cvs.CVData.TueEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.TueEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Thursday") > 0 Then
                        Suffix = "Thursday"
                        ThisDate = ThuDate
                        CurrTimeType = cvs.CVData.WedTimeType
                        Try
                            CurrETID = cvs.CVData.WedEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.WedEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Friday") > 0 Then
                        Suffix = "Friday"
                        ThisDate = FriDate
                        CurrTimeType = cvs.CVData.ThuTimeType
                        Try
                            CurrETID = cvs.CVData.ThuEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.ThuEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Saturday") > 0 Then
                        Suffix = "Saturday"
                        ThisDate = SatDate
                        CurrTimeType = cvs.CVData.FriTimeType
                        Try
                            CurrETID = cvs.CVData.FriEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.FriEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    End If

                Case DayOfWeek.Sunday

                    If TextBox_Comments.ID.IndexOf("Sunday") > 0 Then
                        Suffix = "Sunday"
                        ThisDate = SunDate
                        CurrTimeType = cvs.CVData.SunTimeType
                        Try
                            CurrETID = cvs.CVData.SunEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SunEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Monday") > 0 Then
                        Suffix = "Monday"
                        ThisDate = MonDate
                        CurrTimeType = cvs.CVData.MonTimeType
                        Try
                            CurrETID = cvs.CVData.MonEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.MonEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                        AllowZero = True
                    ElseIf TextBox_Comments.ID.IndexOf("Tuesday") > 0 Then
                        Suffix = "Tuesday"
                        ThisDate = TueDate
                        CurrTimeType = cvs.CVData.TueTimeType
                        Try
                            CurrETID = cvs.CVData.TueEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.TueEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Wednesday") > 0 Then
                        Suffix = "Wednesday"
                        ThisDate = WedDate
                        CurrTimeType = cvs.CVData.WedTimeType
                        Try
                            CurrETID = cvs.CVData.WedEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.WedEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Thursday") > 0 Then
                        Suffix = "Thursday"
                        ThisDate = ThuDate
                        CurrTimeType = cvs.CVData.ThuTimeType
                        Try
                            CurrETID = cvs.CVData.ThuEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.ThuEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Friday") > 0 Then
                        Suffix = "Friday"
                        ThisDate = FriDate
                        CurrTimeType = cvs.CVData.FriTimeType
                        Try
                            CurrETID = cvs.CVData.FriEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.FriEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Saturday") > 0 Then
                        Suffix = "Saturday"
                        ThisDate = SatDate
                        CurrTimeType = cvs.CVData.SatTimeType
                        Try
                            CurrETID = cvs.CVData.SatEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SatEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    End If

                Case DayOfWeek.Monday

                    If TextBox_Comments.ID.IndexOf("Sunday") > 0 Then
                        Suffix = "Sunday"
                        ThisDate = SunDate
                        CurrTimeType = cvs.CVData.MonTimeType
                        Try
                            CurrETID = cvs.CVData.MonEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.MonEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Monday") > 0 Then
                        Suffix = "Monday"
                        ThisDate = MonDate
                        CurrTimeType = cvs.CVData.TueTimeType
                        Try
                            CurrETID = cvs.CVData.TueEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.TueEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                        AllowZero = True
                    ElseIf TextBox_Comments.ID.IndexOf("Tuesday") > 0 Then
                        Suffix = "Tuesday"
                        ThisDate = TueDate
                        CurrTimeType = cvs.CVData.WedTimeType
                        Try
                            CurrETID = cvs.CVData.WedEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.WedEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Wednesday") > 0 Then
                        Suffix = "Wednesday"
                        ThisDate = WedDate
                        CurrTimeType = cvs.CVData.ThuTimeType
                        Try
                            CurrETID = cvs.CVData.ThuEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.ThuEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Thursday") > 0 Then
                        Suffix = "Thursday"
                        ThisDate = ThuDate
                        CurrTimeType = cvs.CVData.FriTimeType
                        Try
                            CurrETID = cvs.CVData.FriEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.FriEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Friday") > 0 Then
                        Suffix = "Friday"
                        ThisDate = FriDate
                        CurrTimeType = cvs.CVData.SatTimeType
                        Try
                            CurrETID = cvs.CVData.SatEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SatEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    ElseIf TextBox_Comments.ID.IndexOf("Saturday") > 0 Then
                        Suffix = "Saturday"
                        ThisDate = SatDate
                        CurrTimeType = cvs.CVData.SunTimeType
                        Try
                            CurrETID = cvs.CVData.SunEtId
                        Catch ex As Exception
                            CurrETID = 0
                        End Try
                        Try
                            CurrETDID = cvs.CVData.SunEtDtlId
                        Catch ex As Exception
                            CurrETDID = 0
                        End Try
                    End If

            End Select

            Dim culureInfo As System.Globalization.CultureInfo
            Dim lg As New LoGlo()

            culureInfo = lg.GetCultureInfo

            Try
                If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                    ThisDate = lg.SetDate(culureInfo, ThisDate)
                Else
                    ErrorMessage = "Invalid date."
                    Return False
                End If
            Catch ex As Exception
                ErrorMessage = "Invalid date."
                Return False
            End Try

            Dim ThisJob As Integer = 0
            Try
                ThisJob = CType(Me.TextBoxJobNumber.Text, Integer)
            Catch ex As Exception
                ThisJob = 0
            End Try
            Dim ThisJobComp As Integer = 0
            Try
                ThisJobComp = CType(Me.TextBoxJobComponentNbr.Text, Integer)
            Catch ex As Exception
                ThisJobComp = 0
            End Try

            Dim ThisFuncCat As String = Me.TextBoxFunctionCategoryCode.Text
            Dim ThisDept As String = Me.RadComboBoxDepartment.SelectedValue
            Dim ThisProdCat As String = Me.TextBoxProductCategory.Text.Trim.Replace("&nbsp;", "")

            If ValidateHours(TextBox_Hours) = False Then
                ErrorMessage = "Invalid hours for " & Suffix
                Return False
            End If

            'If tbHours.Text.Trim = "" Then
            '    tbHours.Text = "0.0"
            'End If

            If TextBox_Hours.Enabled = True AndAlso TextBox_Hours.Text <> HiddenField_Hours.Value Then

                If TextBox_Comments.Text.Trim() <> "" And (IsNumeric(TextBox_Hours.Text) = False OrElse CType(TextBox_Hours.Text, Decimal) = 0) Then

                    TextBox_Hours.Text = "0.0"
                    AllowZero = True

                End If

                If CommentsRequired = True And BypassCommentsReq = False Then

                    If IsNumeric(TextBox_Hours.Text) = True Then

                        If CType(TextBox_Hours.Text, Decimal) > 0 Then

                            If MiscFN.IsEmptyTextbox(TextBox_Comments) = True Then

                                TextBox_Comments.CssClass = "RequiredInput"
                                ErrorMessage = "Comment required for " & Suffix
                                Return False

                            End If

                        End If

                    Else

                        TextBox_Hours.Text = "0.0"

                    End If

                End If

                Dim ThisHours As Decimal = 0

                If IsNumeric(TextBox_Hours.Text) = True Then ThisHours = CType(TextBox_Hours.Text, Decimal)

                If AllowZero = False And CurrETID = 0 And CurrETDID = 0 And ThisHours = 0 Then

                    ErrorMessage = ""
                    Return True

                End If

                Dim Result As AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult = Nothing
                Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

                CurrEditStatus = oTS.CheckEditStatus(CurrETID, CurrETDID)
                If CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    'Dim AdvantageFramework.Timesheet As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

                    If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), CurrETID, CurrETDID, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept,
                                                CStr(Session("UserCode")), ErrorMessage, TextBox_Comments.Text, ReturnEtId, ReturnEtDtlId,, AlertID) = True Then

                        'oTS.DeleteMissingTimeDtl(EmpCode)

                        Try
                            If TextBox_Comments.Text.Trim = "" Then
                                oComments.SaveEmpTimeComments(CurrTimeType, CurrETID, CurrETDID, "")
                            End If
                        Catch ex As Exception
                        End Try

                        With cvs.CVData

                            .FuncCat = ThisFuncCat
                            .ProdCat = ThisProdCat
                            .Dept = ThisDept
                            .JobNumber = ThisJob
                            .JobComponentNbr = ThisJobComp

                            Select Case ThisDate.DayOfWeek
                                Case DayOfWeek.Sunday

                                    .SunEtId = ReturnEtId
                                    .SunEtDtlId = ReturnEtDtlId
                                    .SunDate = ThisDate
                                    .SunSavedHours = ThisHours
                                    .SunTextboxHours = ThisHours
                                    .SunTimeType = CurrTimeType

                                Case DayOfWeek.Monday

                                    .MonEtId = ReturnEtId
                                    .MonEtDtlId = ReturnEtDtlId
                                    .MonDate = ThisDate
                                    .MonSavedHours = ThisHours
                                    .MonTextboxHours = ThisHours
                                    .MonTimeType = CurrTimeType

                                Case DayOfWeek.Tuesday

                                    .TueEtId = ReturnEtId
                                    .TueEtDtlId = ReturnEtDtlId
                                    .TueDate = ThisDate
                                    .TueSavedHours = ThisHours
                                    .TueTextboxHours = ThisHours
                                    .TueTimeType = CurrTimeType

                                Case DayOfWeek.Wednesday

                                    .WedEtId = ReturnEtId
                                    .WedEtDtlId = ReturnEtDtlId
                                    .WedDate = ThisDate
                                    .WedSavedHours = ThisHours
                                    .WedTextboxHours = ThisHours
                                    .WedTimeType = CurrTimeType

                                Case DayOfWeek.Thursday

                                    .ThuEtId = ReturnEtId
                                    .ThuEtDtlId = ReturnEtDtlId
                                    .ThuDate = ThisDate
                                    .ThuSavedHours = ThisHours
                                    .ThuTextboxHours = ThisHours
                                    .ThuTimeType = CurrTimeType

                                Case DayOfWeek.Friday

                                    .FriEtId = ReturnEtId
                                    .FriEtDtlId = ReturnEtDtlId
                                    .FriDate = ThisDate
                                    .FriSavedHours = ThisHours
                                    .FriTextboxHours = ThisHours
                                    .FriTimeType = CurrTimeType

                                Case DayOfWeek.Saturday

                                    .SatEtId = ReturnEtId
                                    .SatEtDtlId = ReturnEtDtlId
                                    .SatDate = ThisDate
                                    .SatSavedHours = ThisHours
                                    .SatTextboxHours = ThisHours
                                    .SatTimeType = CurrTimeType

                            End Select
                        End With

                        cvs.ToSession()

                        Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                        If Result IsNot Nothing Then

                            Select Case Result.ErrorCode
                                Case -15

                                    Me.ShowMessage(Result.WarningMessage)

                                Case -16, -17

                                    Me.ShowMessage(Result.WarningMessage)
                                    Return False

                            End Select

                            Result = Nothing

                        End If

                    Else

                        'If ErrorMessage.Trim() = "" Then ErrorMessage = "Error saving day"
                        Return False

                    End If

                End If

            End If

            If TextBox_Comments.Enabled AndAlso TextBox_Comments.Text <> HiddenField_Comments.Value Then

                Try
                    oComments.SaveEmpTimeComments(CurrTimeType, CurrETID, CurrETDID, TextBox_Comments.Text.Trim())
                Catch ex As Exception
                End Try

            End If

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

        'End If

    End Function
    Private Function DayNeedsComment(ByVal tb As System.Web.UI.WebControls.TextBox) As Boolean
        If tb.Text <> "" And tb.Enabled = True Then
            If IsNumeric(tb.Text) Then
                If CType(tb.Text, Double) <> 0 Then
                    Return True
                End If
            End If
        Else
            Return False
        End If
    End Function
    Private Function DayCommentInLimit(ByVal tb As System.Web.UI.WebControls.TextBox) As Boolean
        If tb.Text <> "" Then
            If tb.Text.Length > 32000 And tb.Enabled = True Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Private Sub SetCommentRequired()
        If IsNumeric(Me.TextBoxJobNumber.Text) = False And IsNumeric(Me.TextBoxJobComponentNbr.Text) = False Then

            CommentsRequired = False

        End If
        If IsNumeric(Me.TextBoxJobNumber.Text) = True Then

            Dim t As New cTimeSheet(Session("ConnString"))
            CommentsRequired = t.JobCommentRequired(CType(Me.TextBoxJobNumber.Text, Integer))

        End If

        If CommentsRequired = True Then

            Me.TxtSundayComments.CssClass = "RequiredInput"
            Me.TxtMondayComments.CssClass = "RequiredInput"
            Me.TxtTuesdayComments.CssClass = "RequiredInput"
            Me.TxtWednesdayComments.CssClass = "RequiredInput"
            Me.TxtThursdayComments.CssClass = "RequiredInput"
            Me.TxtFridayComments.CssClass = "RequiredInput"
            Me.TxtSaturdayComments.CssClass = "RequiredInput"

        End If
    End Sub

    Private Function SaveAll(Optional ByRef ErrorMessage As String = "", Optional ByVal StopwatchDay As DayOfWeek = Nothing,
                             Optional ByRef StopwatchEtId As Integer = 0, Optional ByRef StopwatchEtDtlId As Integer = 0) As Boolean
        'Check comment requirement
        Dim HasAllComments As Boolean = True

        SetCommentRequired()

        If CommentsRequired = True Then
            If Me.PanelSunday.Visible = True AndAlso DayNeedsComment(Me.TxtSundayHours) = True Then
                If Me.TxtSundayComments.Text = "" Then
                    Me.TxtSundayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtSundayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelMonday.Visible = True AndAlso DayNeedsComment(Me.TxtMondayHours) = True Then
                If Me.TxtMondayComments.Text = "" Then
                    Me.TxtMondayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtMondayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelTuesday.Visible = True AndAlso DayNeedsComment(Me.TxtTuesdayHours) = True Then
                If Me.TxtTuesdayComments.Text = "" Then
                    Me.TxtTuesdayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtTuesdayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelWednesday.Visible = True AndAlso DayNeedsComment(Me.TxtWednesdayHours) = True Then
                If Me.TxtWednesdayComments.Text = "" Then
                    Me.TxtWednesdayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtWednesdayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelThursday.Visible = True AndAlso DayNeedsComment(Me.TxtThursdayHours) = True Then
                If Me.TxtThursdayComments.Text = "" Then
                    Me.TxtThursdayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtThursdayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelFriday.Visible = True AndAlso DayNeedsComment(Me.TxtFridayHours) = True Then
                If Me.TxtFridayComments.Text = "" Then
                    Me.TxtFridayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtFridayComments.CssClass = "RequiredInput"
                End If
            End If
            If Me.PanelSaturday.Visible = True AndAlso DayNeedsComment(Me.TxtSaturdayHours) = True Then
                If Me.TxtSaturdayComments.Text = "" Then
                    Me.TxtSaturdayComments.CssClass = "standard-red"
                    HasAllComments = False
                Else
                    Me.TxtSaturdayComments.CssClass = "RequiredInput"
                End If
            End If

        End If

        If HasAllComments = False Then
            ErrorMessage = "Comments are required for all days where time is entered."
            Return False
        End If

        'Check Comment length
        Dim LimitMessage As String = ""
        If Me.DaysToDisplay = 7 Then
            If DayCommentInLimit(Me.TxtSundayComments) = False Then
                LimitMessage &= "Sunday comment exceeded limit of 32,000 characters.<br/>"
            End If
        End If
        If DayCommentInLimit(Me.TxtMondayComments) = False Then
            LimitMessage &= "Monday comment exceeded limit of 32,000 characters.<br/>"
        End If
        If DayCommentInLimit(Me.TxtTuesdayComments) = False Then
            LimitMessage &= "Tuesday comment exceeded limit of 32,000 characters.<br/>"
        End If
        If DayCommentInLimit(Me.TxtWednesdayComments) = False Then
            LimitMessage &= "Wednesday comment exceeded limit of 32,000 characters.<br/>"
        End If
        If DayCommentInLimit(Me.TxtThursdayComments) = False Then
            LimitMessage &= "Thursday comment exceeded limit of 32,000 characters.<br/>"
        End If
        If DayCommentInLimit(Me.TxtFridayComments) = False Then
            LimitMessage &= "Friday comment exceeded limit of 32,000 characters.<br/>"
        End If
        If Me.DaysToDisplay = 7 Then
            If DayCommentInLimit(Me.TxtSaturdayComments) = False Then
                LimitMessage &= "Saturday comment exceeded limit of 32,000 characters.<br/>"
            End If
        End If

        If LimitMessage <> "" Then

            ErrorMessage = LimitMessage
            Return False

        End If

        If PageType = "New" Then

            If SaveNewRow(ErrorMessage, StopwatchDay, StopwatchEtId, StopwatchEtDtlId) = False Then

                Return False

            Else

                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                oTS.DeleteMissingTimeDtl(EmpCode)
                TimesheetPage.ProcessMissingTime(Me.EmpCode, Me.StartDate)

            End If


        ElseIf PageType = "Update" Then

            Dim TimeSaved As Boolean = False
            Dim TempMessage As String = ""

            If Me.PanelSunday.Visible = True Then
                If SaveDay(Me.TxtSundayComments, Me.TxtSundayHours, Me.HfSundayHours, Me.HfSundayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelMonday.Visible = True Then
                If SaveDay(Me.TxtMondayComments, Me.TxtMondayHours, Me.HfMondayHours, Me.HfMondayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelTuesday.Visible = True Then
                If SaveDay(Me.TxtTuesdayComments, Me.TxtTuesdayHours, Me.HfTuesdayHours, Me.HfTuesdayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelWednesday.Visible = True Then
                If SaveDay(Me.TxtWednesdayComments, Me.TxtWednesdayHours, Me.HfWednesdayHours, Me.HfWednesdayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelThursday.Visible = True Then
                If SaveDay(Me.TxtThursdayComments, Me.TxtThursdayHours, Me.HfThursdayHours, Me.HfThursdayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelFriday.Visible = True Then
                If SaveDay(Me.TxtFridayComments, Me.TxtFridayHours, Me.HfFridayHours, Me.HfFridayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If
            If Me.PanelSaturday.Visible = True Then
                If SaveDay(Me.TxtSaturdayComments, Me.TxtSaturdayHours, Me.HfSaturdayHours, Me.HfSaturdayComments, False, TempMessage) = False Then
                    If ErrorMessage.Contains(TempMessage) = False AndAlso TempMessage.Contains("|") = False Then ErrorMessage &= TempMessage & "<br/>"
                Else
                    TimeSaved = True
                End If
            End If

            If TimeSaved = True Then

                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                oTS.DeleteMissingTimeDtl(EmpCode)
                TimesheetPage.ProcessMissingTime(Me.EmpCode, Me.StartDate)

            End If

        End If

        If ErrorMessage <> "" Then

            Return False

        Else 'success

            Return True

        End If

    End Function
    Private Function SaveNewRow(Optional ByRef ErrorMessage As String = "", Optional ByVal StopwatchDay As DayOfWeek = Nothing,
                                Optional ByRef StopwatchEtId As Integer = 0, Optional ByRef StopwatchEtDtlId As Integer = 0) As Boolean

        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

        Dim ThisClient As String
        Dim ThisDiv As String
        Dim ThisProd As String
        Dim ThisJob As String
        Dim ThisJobComp As String
        Dim ThisFuncCat As String
        Dim ThisDept As String
        Dim ThisProdCat As String
        Dim ThisHours As String
        Dim strError As String
        Dim thisStartDate As Date

        If Me.EmpCode = "" Then
            Exit Function
        End If

        If IsNumeric(TextBoxAlertID.Text) = True Then

            AlertID = CType(TextBoxAlertID.Text, Integer)

        Else

            AlertID = 0

        End If

        Dim oTraffic As cTraffic = New cTraffic(CStr(Session("ConnString")), CStr(Session("UserCode")))
        If oTraffic.IsEmpTerminated(EmpCode) Then
            ErrorMessage = "This employee code is inactive."
            Return False
        End If
        If oTraffic.ValidateEmpCode(EmpCode) = False Then
            ErrorMessage = "Invalid employee code."
            Return False
        End If

        thisStartDate = Webvantage.cGlobals.wvCDate(StartDate)
        'Validate
        If Me.TextBoxJobNumber.Text.Trim = "" Then
            ThisJob = 0
        Else
            If IsNumeric(Me.TextBoxJobNumber.Text) Then
                ThisJob = CInt(Me.TextBoxJobNumber.Text)
            End If
        End If

        If Me.TextBoxJobComponentNbr.Text.Trim = "" Then
            ThisJobComp = 0
        Else
            If IsNumeric(Me.TextBoxJobComponentNbr.Text) Then
                ThisJobComp = CInt(Me.TextBoxJobComponentNbr.Text)
            End If
        End If

        If ThisJob > 0 And ThisJobComp = 0 Then
            Me.TextBoxJobComponentNbr.Focus()
            ErrorMessage = "Job selected without a component."
            Return False
        End If

        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "Invalid Job and Job Component."
                Return False
            End If
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If myVal.ValidateJobIsOpen(ThisJob, ThisJobComp) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "This job/comp is closed."
                Return False
            End If
            If myVal.ValidateJobCompIsEditable(ThisJob, ThisJobComp) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "Job/comp process control does not allow access."
                Return False
            End If
        End If

        If Me.PanelSunday.Visible = True Then
            If ValidateHours(Me.TxtSundayHours) = False Then
                Me.TxtSundayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & SunDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtSundayHours, Me.TxtSundayComments) = False Then
                Me.TxtSundayComments.Focus()
                ErrorMessage = "Comments are required for " & SunDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If

        If Me.PanelMonday.Visible = True Then
            If ValidateHours(Me.TxtMondayHours) = False Then
                Me.TxtMondayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & MonDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtMondayHours, Me.TxtMondayComments) = False Then
                Me.TxtMondayComments.Focus()
                ErrorMessage = "Comments are required for " & MonDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If

        If Me.PanelTuesday.Visible = True Then
            If ValidateHours(Me.TxtTuesdayHours) = False Then
                Me.TxtTuesdayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & TueDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtTuesdayHours, Me.TxtTuesdayComments) = False Then
                Me.TxtTuesdayComments.Focus()
                ErrorMessage = "Comments are required for " & TueDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If
        If Me.PanelWednesday.Visible = True Then
            If ValidateHours(Me.TxtWednesdayHours) = False Then
                Me.TxtWednesdayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & WedDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtWednesdayHours, Me.TxtWednesdayComments) = False Then
                Me.TxtWednesdayComments.Focus()
                ErrorMessage = "Comments are required for " & WedDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If
        If Me.PanelThursday.Visible = True Then
            If ValidateHours(Me.TxtThursdayHours) = False Then
                Me.TxtThursdayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & ThuDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtThursdayHours, Me.TxtThursdayComments) = False Then
                Me.TxtThursdayComments.Focus()
                ErrorMessage = "Comments are required for " & ThuDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If
        If Me.PanelFriday.Visible = True Then
            If ValidateHours(Me.TxtFridayHours) = False Then
                Me.TxtFridayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & FriDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtFridayHours, Me.TxtFridayComments) = False Then
                Me.TxtFridayComments.Focus()
                ErrorMessage = "Comments are required for " & FriDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If
        If Me.PanelSaturday.Visible = True Then
            If ValidateHours(Me.TxtSaturdayHours) = False Then
                Me.TxtSaturdayHours.Focus()
                ErrorMessage = "Invalid hours entry for " & SatDate.DayOfWeek.ToString() & "."
                Return False
            End If
            If ValidateHoursAndRequiredComments(Me.TxtSaturdayHours, Me.TxtSaturdayComments) = False Then
                Me.TxtSaturdayComments.Focus()
                ErrorMessage = "Comments are required for " & SatDate.DayOfWeek.ToString() & "."
                Return False
            End If
        End If

        ThisFuncCat = Me.TextBoxFunctionCategoryCode.Text.Trim

        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
        If Me.TextBoxClientCode.Text <> "" Then
            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TextBoxClientCode.Text.Trim, "", "", "ts") = False Then
                Me.TextBoxClientCode.Focus()
                ErrorMessage = "Access to this client is denied."
                Return False
            End If
        End If
        If Me.TextBoxClientCode.Text <> "" And Me.TextBoxDivisionCode.Text <> "" Then
            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TextBoxClientCode.Text.Trim, Me.TextBoxDivisionCode.Text.Trim, "", "ts") = False Then
                Me.TextBoxDivisionCode.Focus()
                ErrorMessage = "Access to this division is denied."
                Return False
            End If
        End If
        If Me.TextBoxClientCode.Text <> "" And Me.TextBoxDivisionCode.Text <> "" And Me.TextBoxProductCode.Text <> "" Then
            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TextBoxClientCode.Text.Trim, Me.TextBoxDivisionCode.Text.Trim, Me.TextBoxProductCode.Text.Trim, "ts") = False Then
                Me.TextBoxProductCode.Focus()
                ErrorMessage = "Access to this product is denied."
                Return False
            End If
        End If
        If Me.TextBoxJobNumber.Text <> "" Then
            If IsNumeric(Me.TextBoxJobNumber.Text.Trim) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "Job number is not a number."
                Return False
            End If
            If oValidation.ValidateJobNumber(Me.TextBoxJobNumber.Text) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "This job does not exist."
                Return False
            End If
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TextBoxJobNumber.Text)
                If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TextBoxJobNumber.Text) = False AndAlso
                                AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                    ErrorMessage = "Access to this job is denied."
                    Return False
                End If
            End Using
        End If
        If Me.TextBoxJobComponentNbr.Text <> "" Then
            If IsNumeric(Me.TextBoxJobComponentNbr.Text.Trim) = False Then
                Me.TextBoxJobComponentNbr.Focus()
                ErrorMessage = "Job component number is not a number."
                Return False
            End If
        End If
        If Me.TextBoxJobNumber.Text = "" And Me.TextBoxJobComponentNbr.Text <> "" Then
            Me.TextBoxJobNumber.Focus()
            ErrorMessage = "You cannot enter a component number without a job number."
            Return False
        End If
        If Me.TextBoxJobNumber.Text <> "" And Me.TextBoxJobComponentNbr.Text <> "" Then
            If oValidation.ValidateJobCompNumber(Me.TextBoxJobNumber.Text, Me.TextBoxJobComponentNbr.Text) = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "This is not a valid job/component!"
                Return False
            End If
            If oValidation.ValidateJobCompIsViewable(Session("UserCode"), Me.TextBoxJobNumber.Text.Trim, Me.TextBoxJobComponentNbr.Text.Trim, "ts") = False Then
                Me.TextBoxJobNumber.Focus()
                ErrorMessage = "Access to this job/comp is denied."
                Return False
            End If
        End If
        If ThisFuncCat = "" Then
            Me.TextBoxFunctionCategoryCode.Focus()
            ErrorMessage = "Function is a required field."
            Return False
        End If

        Dim j As Integer = 0
        Dim jc As Integer = 0
        If IsNumeric(Me.TextBoxJobNumber.Text) = True Then
            j = CType(Me.TextBoxJobNumber.Text, Integer)
        End If
        If IsNumeric(Me.TextBoxJobComponentNbr.Text) = True Then
            jc = CType(Me.TextBoxJobComponentNbr.Text, Integer)
        End If
        If j > 0 And jc > 0 And ThisFuncCat.Length > 6 Then
            ThisFuncCat = ThisFuncCat.Substring(0, 6)
        End If

        If Me.TextBoxJobNumber.Text = "" And Me.TextBoxJobComponentNbr.Text = "" And Me.TextBoxFunctionCategoryCode.Text <> "" Then
            'it is a category and not a function
            If oValidation.ValidateFunctionCategoryAll(EmpCode, ThisFuncCat, "V", True) = False Then
                Me.TextBoxFunctionCategoryCode.Focus()
                ErrorMessage = ThisFuncCat & " is an invalid category."
                Return False
            End If
        End If

        Dim CurrDefaultFN As String = oTS.GetDefaultFunction(EmpCode)
        If Me.TextBoxFunctionCategoryCode.Text = CurrDefaultFN Then
            If oValidation.ValidateFunctionTSAddNew(EmpCode, CurrDefaultFN) = False Then
                Me.TextBoxFunctionCategoryCode.Focus()
                ErrorMessage = "This employee does not have access to his/her own default function."
                Return False
            End If
        End If
        If Me.TextBoxJobNumber.Text <> "" And Me.TextBoxJobComponentNbr.Text <> "" And Me.TextBoxFunctionCategoryCode.Text <> "" And Me.TextBoxFunctionCategoryCode.Text <> CurrDefaultFN Then
            If oValidation.ValidateFunctionTSAddNew(EmpCode, ThisFuncCat) = False Then
                Me.TextBoxFunctionCategoryCode.Focus()
                ErrorMessage = ThisFuncCat & " is an invalid function."
                Return False
            End If
        End If

        ThisDept = Me.RadComboBoxDepartment.SelectedValue

        If oValidation.ValidateDeptTeam(ThisDept) = False Then
            Me.RadComboBoxDepartment.Focus()
            ErrorMessage = "Invalid Department"
            Return False
        End If

        If ProductCategoryIsVisible() = True Then
            ThisProdCat = Me.TextBoxProductCategory.Text.Trim
            If ThisProdCat = "" Then
                If RequiredProductCategory(ThisClient) = True Then
                    Me.TextBoxProductCategory.Focus()
                    ErrorMessage = "Product Category is required."
                    Return False
                End If
            Else
                If ValidateProductCategory(ThisProdCat, ThisClient, ThisDiv, ThisProd) = False Then
                    Me.TextBoxProductCategory.Focus()
                    ErrorMessage = "Product Category is not valid."
                    Return False
                End If
            End If
        End If

        Dim ApprovalMessage As String = ""
        Dim ThisEtId As Integer = 0
        Dim ThisEtDtlId As Integer = 0
        Dim TimeSaved As Boolean = False
        Dim DaysToDisplay As Integer = Me.DaysToDisplay

        If Me.LoadSingleDay = True Then DaysToDisplay = 1
        If DaysToDisplay <> 1 And Me.PanelMonday.Visible = True And Me.TxtMondayHours.Text.Trim() = "" Then

            Me.TxtMondayHours.Text = "0.00"

        End If
        Dim culureInfo As System.Globalization.CultureInfo
        Dim lg As New LoGlo()
        culureInfo = lg.GetCultureInfo

        Dim ThisDate As Date

        Dim Result As AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult = Nothing

        If Me.PanelSunday.Visible = True AndAlso Me.TxtSundayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtSundayHours.Text.Trim() = "" Then Me.TxtSundayHours.Text = "0"
            If IsNumeric(Me.TxtSundayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(0)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtSundayHours.Text.Trim, ThisJob, ThisJobComp,
                                               ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtSundayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True

                    If StopwatchDay = DayOfWeek.Sunday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If

                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If

            End If
        End If

        If Me.PanelMonday.Visible = True AndAlso Me.TxtMondayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtMondayHours.Text.Trim() = "" Then Me.TxtMondayHours.Text = "0.00"
            If IsNumeric(Me.TxtMondayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(1)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtMondayHours.Text.Trim, ThisJob, ThisJobComp,
                                                     ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtMondayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Monday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If

                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        If Me.PanelTuesday.Visible = True AndAlso Me.TxtTuesdayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtTuesdayHours.Text.Trim() = "" Then Me.TxtTuesdayHours.Text = "0.00"
            If IsNumeric(Me.TxtTuesdayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(2)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtTuesdayHours.Text.Trim, ThisJob, ThisJobComp,
                                                     ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtTuesdayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Tuesday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If


                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        If Me.PanelWednesday.Visible = True AndAlso Me.TxtWednesdayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtWednesdayHours.Text.Trim() = "" Then Me.TxtWednesdayHours.Text = "0.00"
            If IsNumeric(Me.TxtWednesdayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(3)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtWednesdayHours.Text.Trim, ThisJob, ThisJobComp,
                                                          ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtWednesdayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Wednesday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If


                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        If Me.PanelThursday.Visible = True AndAlso Me.TxtThursdayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtThursdayHours.Text.Trim() = "" Then Me.TxtThursdayHours.Text = "0.00"
            If IsNumeric(Me.TxtThursdayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(4)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtThursdayHours.Text.Trim, ThisJob, ThisJobComp,
                                                        ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtThursdayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Thursday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If


                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        If Me.PanelFriday.Visible = True AndAlso Me.TxtFridayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtFridayHours.Text.Trim() = "" Then Me.TxtFridayHours.Text = "0.00"
            If IsNumeric(Me.TxtFridayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(5)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtFridayHours.Text.Trim, ThisJob, ThisJobComp,
                                                         ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtFridayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Friday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If


                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        If Me.PanelSaturday.Visible = True AndAlso Me.TxtSaturdayHours.Enabled = True Then
            If DaysToDisplay = 1 And Me.TxtSaturdayHours.Text.Trim() = "" Then Me.TxtSaturdayHours.Text = "0.00"
            If IsNumeric(Me.TxtSaturdayHours.Text.Trim) Then
                Try
                    ThisDate = thisStartDate.AddDays(6)
                    If Date.TryParse(ThisDate, culureInfo, Globalization.DateTimeStyles.None, ThisDate) = True Then
                        ThisDate = lg.SetDate(culureInfo, ThisDate)
                    Else
                        ErrorMessage = "Invalid date"
                        Return False
                    End If
                Catch ex As Exception
                    ErrorMessage = "Invalid date"
                    Return False
                End Try
                If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Me.EmpCode, ThisDate, ThisFuncCat, ThisProdCat, Me.TxtSaturdayHours.Text.Trim, ThisJob, ThisJobComp,
                                                           ThisDept, CStr(Session("UserCode")), ErrorMessage, Me.TxtSaturdayComments.Text, ThisEtId, ThisEtDtlId,, AlertID) = True Then

                    TimeSaved = True
                    If StopwatchDay = DayOfWeek.Saturday Then

                        StopwatchEtId = ThisEtId
                        StopwatchEtDtlId = ThisEtDtlId

                    End If

                    Result = New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)

                    If Result IsNot Nothing Then

                        Select Case Result.ErrorCode
                            Case -15

                                Me.ShowMessage(Result.WarningMessage)

                            Case -16, -17

                                Me.ShowMessage(Result.WarningMessage)
                                Return False

                        End Select

                        Result = Nothing

                    End If

                Else

                    If ErrorMessage.Trim() <> "" Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If
            End If
        End If

        ErrorMessage = ""
        Return True

    End Function
    Private Function ValidateHoursAndRequiredComments(ByRef tbHours As System.Web.UI.WebControls.TextBox, ByRef tbComments As System.Web.UI.WebControls.TextBox) As Boolean
        Try
            If tbHours.Enabled = False And tbComments.Enabled = False Then
                Return True
            End If
            If IsNumeric(tbHours.Text) = True Then
                If CType(tbHours.Text, Decimal) = 0 Then
                    Return True
                End If
            End If
            If CommentsRequired Then
                If tbHours.Text <> "" Then
                    If IsNumeric(tbHours.Text) And tbComments.Text <> "" Then
                        If MiscFN.IsEmptyTextbox(tbComments) = True Then
                            Return False
                        Else
                            Return True
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function ValidateHours(ByRef ThisTextBox As System.Web.UI.WebControls.TextBox) As Boolean
        Try
            If ThisTextBox.Text.Trim = "" Or ThisTextBox.Enabled = False Then
                Return True
            End If
            If IsNumeric(ThisTextBox.Text) = False Then
                ThisTextBox.CssClass = "RequiredInput"
                Return False
            End If
            If CDbl(ThisTextBox.Text) < 24 Then
                Return True
            Else
                ThisTextBox.CssClass = "RequiredInput"
                Return False
            End If
        Catch
            ThisTextBox.CssClass = "RequiredInput"
            Return False
        End Try
    End Function
    Private Sub BindDropDept()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.RadComboBoxDepartment
            .DataSource = odd.GetDeptsByEmpCodeWithDefault(EmpCode)
            .DataTextField = "Description"
            .DataValueField = "Code"
            .DataBind()
        End With
        Try
            For i As Integer = 0 To RadComboBoxDepartment.Items.Count - 1
                If RadComboBoxDepartment.Items(i).Text.IndexOf("*") > -1 Then
                    RadComboBoxDepartment.Items(i).Selected = True
                    RadComboBoxDepartment.Items(i).Text = RadComboBoxDepartment.Items(i).Text.Replace("*", "")
                End If
            Next
            If RadComboBoxDepartment.Items.Count <= 1 Then
                RadComboBoxDepartment.Enabled = False
            Else
                RadComboBoxDepartment.Enabled = True
            End If
        Catch ex As Exception
        End Try

    End Sub
#Region " Product Category Functions"

    Private Function ProductCategoryIsVisible() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()
    End Function

    Private Function RequiredProductCategory(ByVal ClientCode As String) As Boolean
        Dim oReq As cRequired = New cRequired(CStr(Session("ConnString")))
        Return oReq.ProductCategoryRequired(ClientCode)
    End Function

    Private Function ValidateProductCategory(ByVal ProductCategory As String, ByVal Client As String, ByVal Division As String, ByVal Product As String) As Boolean
        Dim oVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Return oVal.ValidateProductCategory(ProductCategory, Client, Division, Product)
    End Function

#End Region
    Private Sub SetMessageLabel(ByVal str As String)
        'Me.LblMessage.Text = str
        Me.ShowMessage(str.Replace("<br/>", "\n"))
    End Sub
    Private Sub SetEditFlagEnable(ByRef HoursTextBox As System.Web.UI.WebControls.TextBox, ByRef CommentsTextBox As System.Web.UI.WebControls.TextBox, ByVal EditFlag As Integer)
        If EditFlag > 0 And EditFlag <> 7 Then
            HoursTextBox.Enabled = False
            CommentsTextBox.Enabled = False
        End If
    End Sub
    Private Function Stopwatch(ByVal [Day] As DayOfWeek, ByVal Comment As String, ByRef ErrorMessage As String) As Boolean

        Comment = Comment.Trim()

        ' Dim AdvantageFramework.Timesheet As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
        Dim cvs As New TimesheetCommentView
        Dim Message As String = ""
        Dim EtId As Integer = 0
        Dim EtDtlId As Short = 0
        Dim DayHasStopWatch As Boolean = False
        Dim NeedsReload As Boolean = False
        Dim Close As Boolean = True
        Dim TimeEntrySaved As Boolean = False
        Dim TheDate As Date = Nothing

        cvs.FromSession()

        Select Case [Day]

            Case DayOfWeek.Sunday

                EtId = cvs.CVData.SunEtId
                EtDtlId = cvs.CVData.SunEtDtlId
                DayHasStopWatch = cvs.CVData.SunHasStopWatch
                TheDate = cvs.CVData.SunDate

            Case DayOfWeek.Monday

                EtId = cvs.CVData.MonEtId
                EtDtlId = cvs.CVData.MonEtDtlId
                DayHasStopWatch = cvs.CVData.MonHasStopWatch
                TheDate = cvs.CVData.MonDate

            Case DayOfWeek.Tuesday

                EtId = cvs.CVData.TueEtId
                EtDtlId = cvs.CVData.TueEtDtlId
                DayHasStopWatch = cvs.CVData.TueHasStopWatch
                TheDate = cvs.CVData.TueDate

            Case DayOfWeek.Wednesday

                EtId = cvs.CVData.WedEtId
                EtDtlId = cvs.CVData.WedEtDtlId
                DayHasStopWatch = cvs.CVData.WedHasStopWatch
                TheDate = cvs.CVData.WedDate

            Case DayOfWeek.Thursday

                EtId = cvs.CVData.ThuEtId
                EtDtlId = cvs.CVData.ThuEtDtlId
                DayHasStopWatch = cvs.CVData.ThuHasStopWatch
                TheDate = cvs.CVData.ThuDate

            Case DayOfWeek.Friday

                EtId = cvs.CVData.FriEtId
                EtDtlId = cvs.CVData.FriEtDtlId
                DayHasStopWatch = cvs.CVData.FriHasStopWatch
                TheDate = cvs.CVData.FriDate

            Case DayOfWeek.Saturday

                EtId = cvs.CVData.SatEtId
                EtDtlId = cvs.CVData.SatEtDtlId
                DayHasStopWatch = cvs.CVData.SatHasStopWatch
                TheDate = cvs.CVData.SatDate

        End Select

        If DayHasStopWatch = True Then 'stop the timer (time record exists)

            If EtId > 0 And EtDtlId > 0 Then

                If Me.CommentsRequired = True And Comment = "" Then

                    ErrorMessage = "Please enter a comment."
                    Return False

                End If

                Dim Hours As Double = 0.0

                If AdvantageFramework.Timesheet.StopwatchStop(Session("ConnString"), Session("UserCode"), Session("EmpCode"), EtId, EtDtlId, Hours, Comment, Message) = False Then

                    ErrorMessage = Message
                    Return False

                Else

                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.DeleteMissingTimeDtl(Me.EmpCode)
                    Webvantage.TimesheetPage.ProcessMissingTime(Session("EmpCode"), TheDate)

                    Select Case [Day]

                        Case DayOfWeek.Sunday

                            cvs.CVData.SunSavedHours = Hours
                            cvs.CVData.SunTextboxHours = Hours
                            cvs.CVData.SunHasStopWatch = False

                        Case DayOfWeek.Monday

                            cvs.CVData.MonSavedHours = Hours
                            cvs.CVData.MonTextboxHours = Hours
                            cvs.CVData.MonHasStopWatch = False

                        Case DayOfWeek.Tuesday

                            cvs.CVData.TueSavedHours = Hours
                            cvs.CVData.TueTextboxHours = Hours
                            cvs.CVData.TueHasStopWatch = False

                        Case DayOfWeek.Wednesday

                            cvs.CVData.WedSavedHours = Hours
                            cvs.CVData.WedTextboxHours = Hours
                            cvs.CVData.WedHasStopWatch = False

                        Case DayOfWeek.Thursday

                            cvs.CVData.ThuSavedHours = Hours
                            cvs.CVData.ThuTextboxHours = Hours
                            cvs.CVData.ThuHasStopWatch = False

                        Case DayOfWeek.Friday

                            cvs.CVData.FriSavedHours = Hours
                            cvs.CVData.FriTextboxHours = Hours
                            cvs.CVData.FriHasStopWatch = False

                        Case DayOfWeek.Saturday

                            cvs.CVData.SatSavedHours = Hours
                            cvs.CVData.SatTextboxHours = Hours
                            cvs.CVData.SatHasStopWatch = False

                    End Select

                    cvs.ToSession()
                    NeedsReload = True

                End If

            End If

        Else 'start the timer

            Dim HoursHiddenField As System.Web.UI.WebControls.HiddenField
            Dim HoursTextbox As System.Web.UI.WebControls.TextBox
            Dim CommentHiddenField As System.Web.UI.WebControls.HiddenField
            Dim CommentTextbox As System.Web.UI.WebControls.TextBox

            Dim IsNew As Boolean = False
            Dim CurrentHours As Decimal = 0.0
            Dim NewRecordSaved As Boolean = False

            Select Case [Day]

                Case DayOfWeek.Sunday

                    HoursHiddenField = Me.HfSundayHours
                    HoursTextbox = Me.TxtSundayHours
                    CommentHiddenField = Me.HfSundayComments
                    CommentTextbox = Me.TxtSundayComments

                Case DayOfWeek.Monday

                    HoursHiddenField = Me.HfMondayHours
                    HoursTextbox = Me.TxtMondayHours
                    CommentHiddenField = Me.HfMondayComments
                    CommentTextbox = Me.TxtMondayComments

                Case DayOfWeek.Tuesday

                    HoursHiddenField = Me.HfTuesdayHours
                    HoursTextbox = Me.TxtTuesdayHours
                    CommentHiddenField = Me.HfTuesdayComments
                    CommentTextbox = Me.TxtTuesdayComments

                Case DayOfWeek.Wednesday

                    HoursHiddenField = Me.HfWednesdayHours
                    HoursTextbox = Me.TxtWednesdayHours
                    CommentHiddenField = Me.HfWednesdayComments
                    CommentTextbox = Me.TxtWednesdayComments

                Case DayOfWeek.Thursday

                    HoursHiddenField = Me.HfThursdayHours
                    HoursTextbox = Me.TxtThursdayHours
                    CommentHiddenField = Me.HfThursdayComments
                    CommentTextbox = Me.TxtThursdayComments

                Case DayOfWeek.Friday

                    HoursHiddenField = Me.HfFridayHours
                    HoursTextbox = Me.TxtFridayHours
                    CommentHiddenField = Me.HfFridayComments
                    CommentTextbox = Me.TxtFridayComments

                Case DayOfWeek.Saturday

                    HoursHiddenField = Me.HfSaturdayHours
                    HoursTextbox = Me.TxtSaturdayHours
                    CommentHiddenField = Me.HfSaturdayComments
                    CommentTextbox = Me.TxtSaturdayComments

            End Select

            If IsNumeric(HoursHiddenField.Value) = True Then

                CurrentHours = CType(HoursHiddenField.Value, Decimal)

            End If

            HoursTextbox.Text = CurrentHours.ToString()

            If EtId = 0 Or EtDtlId = 0 Then 'create time record if doesn't exist

                If PageType = "New" Then

                    IsNew = True

                    If Me.SaveAll(Message, [Day], EtId, EtDtlId) = False Then

                        ErrorMessage = Message
                        Return False

                    End If

                Else

                    TimeEntrySaved = Me.SaveDay(CommentTextbox, HoursTextbox, HoursHiddenField, CommentHiddenField, True, ErrorMessage, EtId, EtDtlId)
                    ErrorMessage = Message

                    If TimeEntrySaved = False Then

                        Return False

                    End If

                End If

            End If

            Message = Message.Trim()

            If Message = "" Then

                If EtId > 0 And EtDtlId > 0 Then

                    Dim Saved As Boolean = AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"),
                                                                                       EtId, EtDtlId, Message)

                    ErrorMessage = Message

                    If Saved = False Then

                        Return False

                    Else

                        Select Case [Day]
                            Case DayOfWeek.Sunday
                                Me.ImageButtonSundayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.SunHasStopWatch = True
                            Case DayOfWeek.Monday
                                Me.ImageButtonMondayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.MonHasStopWatch = True
                            Case DayOfWeek.Tuesday
                                Me.ImageButtonTuesdayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.TueHasStopWatch = True
                            Case DayOfWeek.Wednesday
                                Me.ImageButtonWednesdayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.WedHasStopWatch = True
                            Case DayOfWeek.Thursday
                                Me.ImageButtonThursdayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.ThuHasStopWatch = True
                            Case DayOfWeek.Friday
                                Me.ImageButtonFridayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.FriHasStopWatch = True
                            Case DayOfWeek.Saturday
                                Me.ImageButtonSaturdayStopWatch.ImageUrl = "~/Images/Icons/Grey/256/stopwatch2.png"
                                cvs.CVData.SatHasStopWatch = True
                        End Select

                        cvs.ToSession()
                        NeedsReload = True
                        If ErrorMessage <> "" Then

                            Me.ShowMessage(ErrorMessage)

                        End If

                        Me.OpenTimesheetStopwatchNotificationWindow()

                    End If

                End If

            Else

                ErrorMessage = Message
                Return False

            End If

            If IsNew = True Then

                NeedsReload = False

            End If


        End If

        'If NeedsReload = True Then

        '    Me.LoadUpdate()

        'Else

        Me.CloseThisWindow()

        'End If

        Return True

    End Function
    Private Sub LoadActivityInformation(ByVal TheDayOfTheWeek As DayOfWeek)
        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Activity As AdvantageFramework.Database.Entities.EmployeeNonTask

                Activity = Nothing
                Activity = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Me.TaskNo)

                If Activity IsNot Nothing Then

                    Dim ActivityComment As New System.Text.StringBuilder

                    If String.IsNullOrWhiteSpace(Activity.Description) = False Then

                        ActivityComment.Append(Activity.Description)
                        ActivityComment.Append(":")
                        ActivityComment.Append(Environment.NewLine)

                    End If
                    If String.IsNullOrWhiteSpace(Activity.NontaskDescription) = False Then

                        ActivityComment.Append(Activity.NontaskDescription)
                        ActivityComment.Append(Environment.NewLine)

                    End If

                    Select Case Me.StartWeekOn

                        Case DayOfWeek.Saturday

                            Select Case TheDayOfTheWeek

                                Case DayOfWeek.Saturday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSundayHours.Text = Activity.Hours
                                    Me.TxtSundayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Sunday

                                    If Activity.Hours IsNot Nothing Then Me.TxtMondayHours.Text = Activity.Hours
                                    Me.TxtMondayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Monday

                                    If Activity.Hours IsNot Nothing Then Me.TxtTuesdayHours.Text = Activity.Hours
                                    Me.TxtTuesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Tuesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtWednesdayHours.Text = Activity.Hours
                                    Me.TxtWednesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Wednesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtThursdayHours.Text = Activity.Hours
                                    Me.TxtThursdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Thursday

                                    If Activity.Hours IsNot Nothing Then Me.TxtFridayHours.Text = Activity.Hours
                                    Me.TxtFridayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Friday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSaturdayHours.Text = Activity.Hours
                                    Me.TxtSaturdayComments.Text = ActivityComment.ToString()

                            End Select

                        Case DayOfWeek.Sunday

                            Select Case TheDayOfTheWeek

                                Case DayOfWeek.Sunday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSundayHours.Text = Activity.Hours
                                    Me.TxtSundayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Monday

                                    If Activity.Hours IsNot Nothing Then Me.TxtMondayHours.Text = Activity.Hours
                                    Me.TxtMondayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Tuesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtTuesdayHours.Text = Activity.Hours
                                    Me.TxtTuesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Wednesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtWednesdayHours.Text = Activity.Hours
                                    Me.TxtWednesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Thursday

                                    If Activity.Hours IsNot Nothing Then Me.TxtThursdayHours.Text = Activity.Hours
                                    Me.TxtThursdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Friday

                                    If Activity.Hours IsNot Nothing Then Me.TxtFridayHours.Text = Activity.Hours
                                    Me.TxtFridayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Saturday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSaturdayHours.Text = Activity.Hours
                                    Me.TxtSaturdayComments.Text = ActivityComment.ToString()

                            End Select

                        Case DayOfWeek.Monday

                            Select Case TheDayOfTheWeek

                                Case DayOfWeek.Monday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSundayHours.Text = Activity.Hours
                                    Me.TxtSundayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Tuesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtMondayHours.Text = Activity.Hours
                                    Me.TxtMondayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Wednesday

                                    If Activity.Hours IsNot Nothing Then Me.TxtTuesdayHours.Text = Activity.Hours
                                    Me.TxtTuesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Thursday

                                    If Activity.Hours IsNot Nothing Then Me.TxtWednesdayHours.Text = Activity.Hours
                                    Me.TxtWednesdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Friday

                                    If Activity.Hours IsNot Nothing Then Me.TxtThursdayHours.Text = Activity.Hours
                                    Me.TxtThursdayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Saturday

                                    If Activity.Hours IsNot Nothing Then Me.TxtFridayHours.Text = Activity.Hours
                                    Me.TxtFridayComments.Text = ActivityComment.ToString()

                                Case DayOfWeek.Sunday

                                    If Activity.Hours IsNot Nothing Then Me.TxtSaturdayHours.Text = Activity.Hours
                                    Me.TxtSaturdayComments.Text = ActivityComment.ToString()

                            End Select

                    End Select

                End If

            End Using

        Catch ex As Exception
        End Try

    End Sub

#End Region

End Class
