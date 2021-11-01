Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI
Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports Webvantage.ViewModels
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.Threading

Public Class TimesheetPage
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum CopyType

        EntireTimesheet = 0
        SelectedRows = 1

    End Enum
    Public Enum CopyTo

        CurrentWeek = 0
        SelectedWeek = 1

    End Enum

#End Region

#Region " Variables"

    Private MonTotal As Double = CType(0, Double)
    Private TueTotal As Double = CType(0, Double)
    Private WedTotal As Double = CType(0, Double)
    Private ThuTotal As Double = CType(0, Double)
    Private FriTotal As Double = CType(0, Double)
    Private SatTotal As Double = CType(0, Double)
    Private WeekTotal As Double = CType(0, Double)
    Private SunTotal As Double = CType(0, Double)

    Public JSArray As String = String.Empty

    Private MonPend As Boolean = False
    Private TuePend As Boolean = False
    Private WedPend As Boolean = False
    Private ThuPend As Boolean = False
    Private FriPend As Boolean = False
    Private SatPend As Boolean = False
    Private SunPend As Boolean = False

    Private MonEdit As Boolean = True
    Private TueEdit As Boolean = True
    Private WedEdit As Boolean = True
    Private ThuEdit As Boolean = True
    Private FriEdit As Boolean = True
    Private SatEdit As Boolean = True
    Private SunEdit As Boolean = True

    Private Property _PostPeriodClosedForAllDays As Boolean
        Get
            If ViewState("_PostPeriodClosedForAllDays") IsNot Nothing Then
                Return ViewState("_PostPeriodClosedForAllDays")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_PostPeriodClosedForAllDays") = value
        End Set
    End Property
    Private Property _HasDayWithClosedPostPeriod As Boolean
        Get
            If ViewState("_HasDayWithClosedPostPeriod") IsNot Nothing Then
                Return ViewState("_HasDayWithClosedPostPeriod")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_HasDayWithClosedPostPeriod") = value
        End Set
    End Property
    Private Property SunClosedPP As Boolean
        Get
            If ViewState("SunClosedPP") IsNot Nothing Then
                Return ViewState("SunClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("SunClosedPP") = value
        End Set
    End Property
    Private Property MonClosedPP As Boolean
        Get
            If ViewState("MonClosedPP") IsNot Nothing Then
                Return ViewState("MonClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("MonClosedPP") = value
        End Set
    End Property
    Private Property TueClosedPP As Boolean
        Get
            If ViewState("TueClosedPP") IsNot Nothing Then
                Return ViewState("TueClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("TueClosedPP") = value
        End Set
    End Property
    Private Property WedClosedPP As Boolean
        Get
            If ViewState("WedClosedPP") IsNot Nothing Then
                Return ViewState("WedClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("WedClosedPP") = value
        End Set
    End Property
    Private Property ThuClosedPP As Boolean
        Get
            If ViewState("ThuClosedPP") IsNot Nothing Then
                Return ViewState("ThuClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("ThuClosedPP") = value
        End Set
    End Property
    Private Property FriClosedPP As Boolean
        Get
            If ViewState("FriClosedPP") IsNot Nothing Then
                Return ViewState("FriClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("FriClosedPP") = value
        End Set
    End Property
    Private Property SatClosedPP As Boolean
        Get
            If ViewState("SatClosedPP") IsNot Nothing Then
                Return ViewState("SatClosedPP")
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("SatClosedPP") = value
        End Set
    End Property

    Public AllowQvAQuery As Boolean = False

    Private DtTimeCategories As New DataTable
    Private DtFunctions As New DataTable

    Public TimesheetStartDate As Date = Nothing
    Private TimesheetEndDate As Date = Nothing
    Public TimesheetEmpCode As String = String.Empty

    Private FromDesktopObject As Boolean = False

    Private _TodayOffset As Integer = 0
    Private _LoadingDatasource As Boolean = False

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

    Public Property CollapsedHeaders() As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
        Get
            If IsNothing(Session.Item("CollapsedGroupHeaders")) Then
                Session.Item("CollapsedGroupHeaders") = New AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
            End If
            Return Session.Item("CollapsedGroupHeaders")
        End Get
        Set(ByVal value As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection)
            Session.Item("CollapsedGroupHeaders") = value
        End Set
    End Property

    Private ReadOnly Property GroupingIndex As Integer
        Get
            Try
                Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
                av.getAllAppVars()
                Return CType(av.getAppVar("DropGroupByIndex", "Integer", "0"), Integer)
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Private ReadOnly Property DaysToDisplay As Integer
        Get
            Dim Show As Integer = 7

            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            Dim c As New cTimeSheet(Session("ConnString"))

            TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

            Show = CType(TsSettings.DaysToDisplay, Integer)

            Try

                If Me.RadComboBoxDayToShow.Items.Count > 0 Then

                    If Me.RadComboBoxDayToShow.SelectedValue.Contains("all7") Then Show = 7
                    If Me.RadComboBoxDayToShow.SelectedValue.Contains("all5") Then Show = 5
                    If IsNumeric(Me.RadComboBoxDayToShow.SelectedValue) = True Then

                        Show = 1

                    End If

                End If

            Catch ex As Exception

                Show = 7

            End Try
            Try
                If cEmployee.TimeZoneToday.DayOfWeek = DayOfWeek.Saturday Or cEmployee.TimeZoneToday.DayOfWeek = DayOfWeek.Sunday Or Show = 7 Then

                    Return 7

                ElseIf Show = 5 Then

                    Return 5

                ElseIf Show = 1 Then

                    Return 1

                Else

                    Return Show

                End If

            Catch ex As Exception

                Return 7

            End Try
        End Get
    End Property

    Private Property DayToShow() As String
        Get
            Try
                If Not Session("TimesheetMain_SingleViewDayOfWeek") Is Nothing Then
                    If IsNumeric(Session("TimesheetMain_SingleViewDayOfWeek")) = True Then
                        Me.IsSingleDayView = True
                        Return Session("TimesheetMain_SingleViewDayOfWeek").ToString()
                    Else
                        Me.IsSingleDayView = False
                        Return "all7"
                    End If
                Else
                    Me.IsSingleDayView = False
                    Return "all7"
                End If
            Catch ex As Exception
                Me.IsSingleDayView = False
                Return "all7"
            End Try
        End Get
        Set(value As String)
            If value <> String.Empty And IsNumeric(value) Then
                Session("TimesheetMain_SingleViewDayOfWeek") = value
            Else
                Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
            End If
        End Set
    End Property

    Private ReadOnly Property AllowCopyHours As Boolean
        Get
            Try

                If Session("TimesheetMain_AllowCopyHours") Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Session("TimesheetMain_AllowCopyHours") = CType(DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(TS_COPY_HRS, 0) AS BIT) FROM AGENCY WITH(NOLOCK);").FirstOrDefault, Boolean)

                    End Using

                End If
                If Session("TimesheetMain_AllowCopyHours") IsNot Nothing Then

                    Return CType(Session("TimesheetMain_AllowCopyHours"), Boolean)

                Else

                    Return False

                End If

            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Private ReadOnly Property ShowCommentsUsing As String
        Get
            Try

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim c As New cTimeSheet(Session("ConnString"))

                TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                Return TsSettings.ShowCommentsUsing

            Catch ex As Exception
                Return "icon"
            End Try
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
    Private ReadOnly Property DisablePagingOnMainGrid As Boolean
        Get
            Try
                Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
                av.getAllAppVars()
                Return CType(av.getAppVar("MAIN_TS_NO_PAGING", , "False"), Boolean)
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Private ReadOnly Property RepeatRowForAllDays As Boolean
        Get
            Try
                If ViewState("RepeatRowForAllDays") Is Nothing Then
                    Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                    Dim c As New cTimeSheet(Session("ConnString"))
                    TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))
                    'If TsSettings.StartTimesheetOnDayOfWeek = DayOfWeek.Sunday Then
                    ViewState("RepeatRowForAllDays") = TsSettings.RepeatRowForAllDays
                    'Else
                    '    ViewState("RepeatRowForAllDays") = True
                    'End If
                End If
                Return CType(ViewState("RepeatRowForAllDays"), Boolean)
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    Private _CurrentTimesheet As AdvantageFramework.Timesheet.TimeSheet
    Private ReadOnly Property CurrentTimesheet As AdvantageFramework.Timesheet.TimeSheet
        Get

            If Me._CurrentTimesheet Is Nothing Then

                If Me.ValidateEmployeeCode(Me.txtEmpCode.Text) = False OrElse Me.ValidDate() = False Then

                    Return Nothing

                Else

                    Dim s As String = String.Empty

                    If Not Me.IsPostBack AndAlso Request.QueryString("FromWindow") IsNot Nothing AndAlso
                        Request.QueryString("FromWindow") = "uix" Then

                        Me.TimesheetStartDate = cEmployee.TimeZoneToday
                        Me.SetDates(Me.TimesheetStartDate)

                    End If

                    _CurrentTimesheet = AdvantageFramework.Timesheet.GetTimeSheet(Session("ConnString"), Session("UserCode"), Me.txtEmpCode.Text, Me.TimesheetStartDate, Me.TimesheetEndDate, , s)

                    If Me._CurrentTimesheet Is Nothing And s <> String.Empty Then

                        Me.ShowMessage(s)
                        Return Nothing

                    Else

                        Return _CurrentTimesheet

                    End If

                End If

            Else

                Return Me._CurrentTimesheet

            End If

        End Get
    End Property
    Private Property TimesheetIsMissingComments() As Boolean
        Get
            Return Me.HiddenFieldTimesheetIsMissingComments.Value
        End Get
        Set(value As Boolean)
            Me.HiddenFieldTimesheetIsMissingComments.Value = value
        End Set
    End Property

    Public ReadOnly Property TextBox_SundayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_SundayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_MondayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_MondayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_TuesdayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_TuesdayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_WednesdayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_WednesdayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_ThursdayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ThursdayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_FridayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_FridayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_SaturdayComments() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_SaturdayComments")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemSunday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemSunday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemMonday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemMonday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemTuesday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemTuesday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemWednesday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemWednesday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemThursday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemThursday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemFriday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemFriday")
        End Get
    End Property

    Public ReadOnly Property TextBox_NewItemSaturday() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_NewItemSaturday")
        End Get
    End Property


    Public ReadOnly Property TextBox_ClientCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ClientCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_DivisionCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_DivisionCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_ProductCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ProductCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_JobCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_JobCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_ComponentCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ComponentCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_FunctionCategory() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_FunctionCategory")
        End Get
    End Property

    Public ReadOnly Property TextBox_ProductCategory() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ProductCategory")
        End Get
    End Property

    Public ReadOnly Property TextBox_FunctionCategoryDescription() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_FunctionCategoryDescription")
        End Get
    End Property
    Public ReadOnly Property TextBox_Assignment() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_Assignment")
        End Get
    End Property

    Public ReadOnly Property ComboBox_Department() As Telerik.Web.UI.RadComboBox
        Get
            Return FindControlRecursive(Master, "ComboBox_Department")
        End Get
    End Property

    Public ReadOnly Property ImageButton_SaveNewRow() As ImageButton
        Get
            Return FindControlRecursive(Master, "ImageButton_SaveNewRow")
        End Get
    End Property

    Public ReadOnly Property ImageButton_CancelNewRow() As ImageButton
        Get
            Return FindControlRecursive(Master, "ImageButton_CancelNewRow")
        End Get
    End Property

    Public ReadOnly Property DivisionCode_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "DivisionCode_DialogLink")
        End Get
    End Property

    Public ReadOnly Property ProductCode_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "ProductCode_DialogLink")
        End Get
    End Property

    Public ReadOnly Property JobCode_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "JobCode_DialogLink")
        End Get
    End Property

    Public ReadOnly Property ComponentCode_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "ComponentCode_DialogLink")
        End Get
    End Property

    Public ReadOnly Property ProductCategory_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "ProductCategory_DialogLink")
        End Get
    End Property

    Public ReadOnly Property FuncCat_DialogLink() As System.Web.UI.HtmlControls.HtmlAnchor
        Get
            Return FindControlRecursive(Master, "FuncCat_DialogLink")
        End Get
    End Property

    Private Sub ClearCurrentTimesheet()
        Me._CurrentTimesheet = Nothing
    End Sub

#End Region

#Region " Page Events "

    Protected Overrides Sub InitializeCulture()

        Dim UserCurrentCulture As CultureInfo = LoGlo.GetCultureInfo

        If UserCurrentCulture.DateTimeFormat.FirstDayOfWeek <> Me.StartWeekOn Then

            Dim CurrentCultureCode = LoGlo.UserCultureGet

            UICulture = CurrentCultureCode
            Culture = CurrentCultureCode

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(CurrentCultureCode)

            Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek = Me.StartWeekOn

            Dim ModifiedCulture = New CultureInfo(CurrentCultureCode)
            ModifiedCulture.DateTimeFormat.FirstDayOfWeek = Me.StartWeekOn

            Thread.CurrentThread.CurrentUICulture = ModifiedCulture

        End If

        MyBase.InitializeCulture()

    End Sub

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)

        AddHandler RadGridTimesheetNew.HeaderContextMenu.ItemCreated, AddressOf TimesheetContextMenuItemCreated

        Me.RadToolbarButtonDelete.ToolTip = "Delete selected row(s)"

        'Set the employee
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                If Not Session("TimesheetEmpCode") Is Nothing Then
                    Me.TimesheetEmpCode = Session("TimesheetEmpCode").ToString()
                Else
                    Me.TimesheetEmpCode = Session("EmpCode")
                End If
            Catch ex As Exception
                Me.TimesheetEmpCode = Session("EmpCode")
            End Try
            Try
                If Not Request.QueryString("from") Is Nothing Then 'allow objects to override 
                    Select Case Request.QueryString("from").ToString()
                        Case "MissingTime", "DeniedTime"
                            Me.TimesheetEmpCode = Session("EmpCode")
                            Session("TimesheetEmpCode") = Me.TimesheetEmpCode
                    End Select
                End If
            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.StartDate) = False AndAlso IsDate(Me.CurrentQuerystring.StartDate) Then

                    Me.TimesheetEmpCode = Session("EmpCode")
                    Session("TimesheetEmpCode") = Me.TimesheetEmpCode

                End If

            Catch ex As Exception
            End Try
        Else
            If Me.txtEmpCode.Text.Trim() <> String.Empty Then
                Me.TimesheetEmpCode = Me.txtEmpCode.Text.Trim()
            Else
                Me.TimesheetEmpCode = Session("EmpCode")
            End If
        End If

        Me.txtEmpCode.Text = Me.TimesheetEmpCode

        'set date
        Dim DateSet As Boolean = False
        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim FromWindow As String = String.Empty

            If Request.QueryString("FromWindow") IsNot Nothing Then

                FromWindow = Request.QueryString("FromWindow")

            End If
            If String.IsNullOrWhiteSpace(FromWindow) AndAlso Request.QueryString("from") IsNot Nothing Then

                FromWindow = Request.QueryString("from")

            End If
            Select Case FromWindow
                Case "CurrentDTObject"

                    Me.FromDesktopObject = True

                Case "MissingTime", "DeniedTime"

                    If Not Request.QueryString("TSdate") Is Nothing Then

                        Dim ThisDate As Date = CType(Request.QueryString("TSdate"), Date)
                        Me.TimesheetStartDate = wvCDate(ThisDate.AddDays(-ThisDate.DayOfWeek)).ToShortDateString()
                        DateSet = True

                    End If

            End Select

        End If

        If Not Session("TimesheetStartDate") = Nothing AndAlso IsDate(Session("TimesheetStartDate")) = True Then

            Me.TimesheetStartDate = wvCDate(Session("TimesheetStartDate"))
            DateSet = True

        End If

        Me.SetDates(Me.TimesheetStartDate)

        If Not Me.IsPostBack AndAlso Not Me.IsCallback AndAlso DateSet = False AndAlso DaysToDisplay = 1 Then

            'Me.TimesheetStartDate = cEmployee.TimeZoneToday
            Session("TimesheetStartDate") = Me.TimesheetStartDate
            Me.TimesheetEndDate = Me.TimesheetStartDate
            Me.DayToShow = CType(cEmployee.TimeZoneToday.DayOfWeek, Integer).ToString()
            Me.IsSingleDayView = True

        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback AndAlso
            String.IsNullOrWhiteSpace(Me.CurrentQuerystring.StartDate) = False AndAlso IsDate(Me.CurrentQuerystring.StartDate) Then

            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.GetValue("flwk")) = False Then

                Me.TimesheetStartDate = CDate(Me.CurrentQuerystring.StartDate)
                Session("TimesheetStartDate") = Me.TimesheetStartDate.ToShortDateString

                If Me.CurrentQuerystring.GetValue("flwk") = "true" Then

                    Me.SetDates(Me.TimesheetStartDate)
                    DateSet = True

                Else

                    Me.RadDatePickerStartDate.SelectedDate = Me.TimesheetStartDate
                    Session("TimesheetStartDate") = Me.TimesheetStartDate
                    Me.TimesheetEndDate = Me.TimesheetStartDate
                    Session("TimesheetMain_SingleViewDayOfWeek") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
                    Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
                    Session("TimesheetMain_UserHasMadeASelection") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
                    Me.DayToShow = CType(Me.TimesheetStartDate.DayOfWeek, Integer).ToString()
                    Me.IsSingleDayView = True

                End If

            End If

        End If

        Me.RadToolbarTimesheetButtons.FindItemByValue("RadToolBarButtonCopyFromTooltip").Attributes.Add("id", "RadToolBarButtonCopyFromTooltip")
        Me.RadToolbarTimesheetButtons.FindItemByValue("RadToolBarButtonCopyToTooltip").Attributes.Add("id", "RadToolBarButtonCopyToTooltip")

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridTimesheetNew)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim GridSettings As New GridSettingsPersister(Me.RadGridTimesheetNew)
            GridSettings.LoadFromDatabase()

            'Try

            '    If HttpContext.Current.Session("DeletePriorZeroHours_" & Me.TimesheetEmpCode) Is Nothing Then

            '        Dim errorMessage As String = String.Empty
            '        AdvantageFramework.EmployeeTimesheet.DeletePriorZeroHours(_Session, Me.TimesheetEmpCode, Me.TimesheetStartDate, errorMessage)
            '        HttpContext.Current.Session("DeletePriorZeroHours_" & Me.TimesheetEmpCode) = True

            '    End If

            'Catch ex As Exception
            'End Try

        End If

    End Sub
    'Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

    '    Me.AllowFloat = False
    '    Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)

    '    'Set the employee
    '    If Not Me.IsPostBack And Not Me.IsCallback Then
    '        Try
    '            If Not Session("TimesheetEmpCode") Is Nothing Then
    '                Me.TimesheetEmpCode = Session("TimesheetEmpCode").ToString()
    '            Else
    '                Me.TimesheetEmpCode = Session("EmpCode")
    '            End If
    '        Catch ex As Exception
    '            Me.TimesheetEmpCode = Session("EmpCode")
    '        End Try
    '        Try
    '            If Not Request.QueryString("from") Is Nothing Then 'allow objects to override 
    '                Select Case Request.QueryString("from").ToString()
    '                    Case "MissingTime", "DeniedTime"
    '                        Me.TimesheetEmpCode = Session("EmpCode")
    '                        Session("TimesheetEmpCode") = Me.TimesheetEmpCode
    '                End Select
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try

    '            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.StartDate) = False AndAlso IsDate(Me.CurrentQuerystring.StartDate) Then

    '                Me.TimesheetEmpCode = Session("EmpCode")
    '                Session("TimesheetEmpCode") = Me.TimesheetEmpCode

    '            End If

    '        Catch ex As Exception
    '        End Try
    '    Else
    '        If Me.txtEmpCode.Text.Trim() <> String.Empty Then
    '            Me.TimesheetEmpCode = Me.txtEmpCode.Text.Trim()
    '        Else
    '            Me.TimesheetEmpCode = Session("EmpCode")
    '        End If
    '    End If

    '    Me.txtEmpCode.Text = Me.TimesheetEmpCode

    '    'set date
    '    Dim DateSet As Boolean = False
    '    If Not Me.IsPostBack And Not Me.IsCallback Then

    '        Dim FromWindow As String = String.Empty

    '        If Request.QueryString("FromWindow") IsNot Nothing Then

    '            FromWindow = Request.QueryString("FromWindow")

    '        End If
    '        If String.IsNullOrWhiteSpace(FromWindow) AndAlso Request.QueryString("from") IsNot Nothing Then

    '            FromWindow = Request.QueryString("from")

    '        End If
    '        Select Case FromWindow
    '            Case "CurrentDTObject"

    '                Me.FromDesktopObject = True

    '            Case "MissingTime", "DeniedTime"

    '                If Not Request.QueryString("TSdate") Is Nothing Then

    '                    Dim ThisDate As Date = CType(Request.QueryString("TSdate"), Date)
    '                    Me.TimesheetStartDate = wvCDate(ThisDate.AddDays(-ThisDate.DayOfWeek)).ToShortDateString()
    '                    DateSet = True

    '                End If

    '        End Select

    '    End If

    '    If Not Session("TimesheetStartDate") = Nothing AndAlso IsDate(Session("TimesheetStartDate")) = True Then

    '        Me.TimesheetStartDate = wvCDate(Session("TimesheetStartDate"))
    '        DateSet = True

    '    End If

    '    Me.SetDates(Me.TimesheetStartDate)

    '    If Not Me.IsPostBack AndAlso Not Me.IsCallback AndAlso DateSet = False AndAlso DaysToDisplay = 1 Then

    '        'Me.TimesheetStartDate = cEmployee.TimeZoneToday
    '        Session("TimesheetStartDate") = Me.TimesheetStartDate
    '        Me.TimesheetEndDate = Me.TimesheetStartDate
    '        Me.DayToShow = CType(cEmployee.TimeZoneToday.DayOfWeek, Integer).ToString()
    '        Me.IsSingleDayView = True

    '    End If
    '    If Not Me.IsPostBack AndAlso Not Me.IsCallback AndAlso
    '        String.IsNullOrWhiteSpace(Me.CurrentQuerystring.StartDate) = False AndAlso IsDate(Me.CurrentQuerystring.StartDate) Then

    '        If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.GetValue("flwk")) = False Then

    '            Me.TimesheetStartDate = CDate(Me.CurrentQuerystring.StartDate)
    '            Session("TimesheetStartDate") = Me.TimesheetStartDate.ToShortDateString

    '            If Me.CurrentQuerystring.GetValue("flwk") = "true" Then

    '                Me.SetDates(Me.TimesheetStartDate)
    '                DateSet = True

    '            Else

    '                Me.RadDatePickerStartDate.SelectedDate = Me.TimesheetStartDate
    '                Session("TimesheetStartDate") = Me.TimesheetStartDate
    '                Me.TimesheetEndDate = Me.TimesheetStartDate
    '                Session("TimesheetMain_SingleViewDayOfWeek") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
    '                Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
    '                Session("TimesheetMain_UserHasMadeASelection") = CType(Me.TimesheetStartDate.DayOfWeek, Integer)
    '                Me.DayToShow = CType(Me.TimesheetStartDate.DayOfWeek, Integer).ToString()
    '                Me.IsSingleDayView = True

    '            End If

    '        End If

    '    End If

    '    'Dim qs As New AdvantageFramework.Web.QueryString

    '    'qs.Page = "Employee/Timesheet"
    '    'qs.StartDate = Me.TimesheetStartDate.ToShortDateString
    '    'qs.EmpCode = Me.TimesheetEmpCode

    '    'If IsSingleDayView = True Then

    '    '    qs.Add("dtd", "1")
    '    '    qs.Add("nav", "4")
    '    '    qs.Add("isdd", "1")

    '    'End If

    '    'Response.Redirect(qs.ToString(True), True)

    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Me.ImageButton_SaveNewRow) = False Then

            Me.RadScriptManagerParent.RegisterPostBackControl(Me.ImageButton_SaveNewRow)
            Me.RadScriptManagerParent.RegisterPostBackControl(Me.ImageButton_CancelNewRow)

        End If

        Me.RadScriptManagerParent.RegisterPostBackControl(Me.RadToolbarButtonAddNewCV)
        Me.RadScriptManagerParent.RegisterPostBackControl(Me.RadToolbarButtonRefresh)

        LimitUser()

        If Not Me.IsPostBack And Not Me.IsCallback Then

            ' Me.lbtnEmpCode.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.txtEmpCode.ClientID & "');return false;")
            Try
                Dim cal As RadCalendar
                cal = RadToolCopyTo.FindControl("RadCalendarCopyToSelectedWeek")

                If cal IsNot Nothing Then

                    Dim Today As New RadCalendarDay
                    Today.Date = Me.TimeZoneToday
                    Today.ItemStyle.CssClass = "radcalendar-today"
                    cal.SpecialDays.Add(Today)

                End If
            Catch ex As Exception
            End Try
            Me.SetRadDatePicker(Me.RadDatePickerStartDate)

            Me.LoadDaysToShow()
            Me.LoadGroupBy()
            'Me.LoadCopySettings()
            Me.RadCalendarCopyToSelectedWeek.SelectedDate = cEmployee.TimeZoneToday

            Me.BodyTag.Attributes.Add("ondragstart", "return false;")
            Me.BodyTag.Attributes.Add("draggable", "false")

            Me.DivCopyHours.Visible = Me.AllowCopyHours

        Else 'It is a postback/callback

            CheckForRowInsert()

            Select Case Me.EventTarget
                Case "RebindGrid"
                    Me.RadGridTimesheetNew.Rebind()

            End Select

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridTimesheetNew)

        'Legacy sessions
        Session("LookupForm") = "ts"
        Session("FromForm") = "TS"

        Me.LoadFunctions()
        Me.LoadTimeCategories()



    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If IsNothing(Session.Item("CollapsedGroupHeaders")) = False Then
            Dim groupHeaders As List(Of GridItem) = Me.RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

            Dim expanded As List(Of GridItem) = (From g In groupHeaders
                                                 Where g.Expanded
                                                 Select g).ToList()


            For Each expandedItem As GridItem In expanded
                If Me.CollapsedHeaders.GroupCaptions.Contains(expandedItem.Cells(1).Text) Then
                    expandedItem.Expanded = False
                End If
            Next

        End If

        Me.InitializeAngularSettings()

    End Sub
    Private Sub Timesheet_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        Try

            Me.SetDayColumnsToShow()

        Catch ex As Exception
        End Try

        Try

            If Me._ResetDayToShowRadComboBox = True Then

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDayToShow, Me._DayOfTheWeekFromQuerystring, False)
                SetDayToShowSession()

            End If

        Catch ex As Exception
        End Try
        Try

            If Not Me.IsPostBack And Not Me.IsCallback Then

                Dim timeSheet As New cTimeSheet(Session("ConnString"))
                If timeSheet.IsApprovalActive(Me.TimesheetEmpCode) = True Then

                    Me.RadToolbarTimesheetButtons.FindItemByValue("SetApproval").Visible = True
                    Me.RadToolbarTimesheetButtons.FindItemByValue("RadToolBarButtonApprovalSeparator").Visible = True

                Else

                    Me.RadToolbarTimesheetButtons.FindItemByValue("SetApproval").Visible = False
                    Me.RadToolbarTimesheetButtons.FindItemByValue("RadToolBarButtonApprovalSeparator").Visible = False

                End If

                Dim a As New cAgency(Session("ConnString"))
                Me.RadToolbarTimesheetButtons.FindItemByValue("RadToolBarButtonCopyToTooltip").Visible = a.CheckCopyTimeSheet()

            End If

        Catch ex As Exception
        End Try
        'Try

        '    Dim head As GridHeaderItem
        '    If Not Me.RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.Header) Is Nothing Then

        '        head = TryCast(Me.RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)

        '    End If

        'Catch ex As Exception
        'End Try
        Try

            If Me._MissingCommentFocusSet = False AndAlso Me.TextBox_JobCode IsNot Nothing AndAlso Me.TextBox_JobCode.Visible = True Then

                Me.TextBox_JobCode.Focus()

            End If

        Catch ex As Exception
        End Try

        CheckMyCalendarSettings()

    End Sub

#End Region

#Region " Control Events "

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        If IsNumeric(RadGridTimesheetNew.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNumber")) = True AndAlso
           IsNumeric(RadGridTimesheetNew.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComponentNbr")) = True Then

            Me.MyUnityContextMenu.JobNumber = RadGridTimesheetNew.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNumber")
            Me.MyUnityContextMenu.JobComponentNumber = RadGridTimesheetNew.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComponentNbr")

        End If

    End Sub

    Private Sub SetSingleDaySession()
        Try
            If Me.DaysToDisplay = 1 AndAlso IsNumeric(Me.RadComboBoxDayToShow.SelectedValue) = True Then
                Session("TimesheetCommentView_SingleViewDayOfWeek") = Me.RadComboBoxDayToShow.SelectedValue
            Else
                Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing
            End If

        Catch ex As Exception
            Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing
        End Try
    End Sub
    Private Sub RadToolbarTimesheetButtons_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarTimesheetButtons.ButtonClick

        If ValidDate() = False Then Exit Sub
        If ValidateEmployeeCode(Me.txtEmpCode.Text) = False Then Exit Sub
        Me.TimesheetEmpCode = Me.txtEmpCode.Text

        Dim NeedsCommentsRequiredRefresh = True

        Session("TimesheetMain_UserHasMadeASelection") = Me.RadComboBoxDayToShow.SelectedValue

        Select Case e.Item.Value
            Case "refresh"

                Me.RadGridTimesheetNew.Rebind()
                Me.RefreshTimesheetDesktopObject(False)
                NeedsCommentsRequiredRefresh = False

            Case "addnewcv"

                Dim cvs As New TimesheetCommentView
                cvs.ClearSession()

                SetSingleDaySession()
                Dim URL As String = "Timesheet_CommentsView.aspx?Type=New&caller=Timesheet&emp=&sd=&display=" & Me.DaysToDisplay.ToString()
                Me.OpenWindow(String.Empty, URL, , , , False)

            Case "print"

                If MiscFN.ValidDate(Me.RadDatePickerStartDate) Then

                    Me.OpenWindow("Print Timesheet", "Timesheet_QuickPrintSettings.aspx?empcode=" & Me.TimesheetEmpCode & "&tsdate=" & CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString() & "&sortkey=&Type=1&Report=timesheetprint", 220, 365)

                End If

            Case "SetApproval"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Timesheet_SupervisorApproval.aspx"
                qs.StartDate = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()
                qs.EmployeeCode = Me.txtEmpCode.Text.ToString()

                Me.OpenWindow("Set Approval", qs.ToString(True), 375, 550, False, True)

            Case "DeleteSelected"

                Dim itemCheckBox As CheckBox = Nothing
                Dim currentRowCount As Integer = Me.RadGridTimesheetNew.MasterTableView.Items().Count
                Dim gridDataItem As Telerik.Web.UI.GridDataItem = Nothing
                Dim UndeletableRowsSelected = False
                Dim HiddenField_RowIsDeleteable As HiddenField

                For rowIndex As Integer = currentRowCount To 1 Step -1

                    gridDataItem = Me.RadGridTimesheetNew.MasterTableView.Items(rowIndex - 1)

                    If gridDataItem.Selected Then

                        HiddenField_RowIsDeleteable = gridDataItem.FindControl("HiddenField_RowIsDeleteable")

                        If (CBool(HiddenField_RowIsDeleteable.Value) = False) Then

                            UndeletableRowsSelected = True

                        End If

                        DeleteGridRow(gridDataItem, gridDataItem.ItemIndex, False)

                    End If

                Next

                Me.RadGridTimesheetNew.Rebind()
                NeedsCommentsRequiredRefresh = False

                If UndeletableRowsSelected Then

                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "AlertCannotDelete", "ShowMessage('One or more rows could not be deleted.');", True)

                End If

        End Select

        Dim required As New cRequired(Session("ConnString"))
        If required.RequiredTimesheetComments = True AndAlso NeedsCommentsRequiredRefresh = True Then

            Me.RadGridTimesheetNew.Rebind()

        End If

    End Sub

    Private Sub ButtonCopyFromMyTimesheets_Click(sender As Object, e As EventArgs) Handles ButtonCopyFromMyTimesheets.Click

        SetSingleDaySession()

        Dim queryString As New AdvantageFramework.Web.QueryString
        queryString.Page = "Timesheet_CopyFrom.aspx"
        queryString.Add("v", "0")
        queryString.Add("dts", Me.RadComboBoxDayToShow.SelectedValue.ToString())

        Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

    End Sub
    Private Sub ButtonCopyFromMyProjects_Click(sender As Object, e As EventArgs) Handles ButtonCopyFromMyProjects.Click

        SetSingleDaySession()

        Dim queryString As New AdvantageFramework.Web.QueryString
        queryString.Page = "Timesheet_CopyFrom.aspx"
        queryString.Add("v", "1")
        queryString.Add("dts", Me.RadComboBoxDayToShow.SelectedValue.ToString())

        Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

    End Sub
    Private Sub ButtonCopyFromMyTemplates_Click(sender As Object, e As EventArgs) Handles ButtonCopyFromMyTemplates.Click

        SetSingleDaySession()

        Dim queryString As New AdvantageFramework.Web.QueryString
        queryString.Page = "Timesheet_CopyFrom.aspx"
        queryString.Add("v", "2")
        queryString.Add("dts", Me.RadComboBoxDayToShow.SelectedValue.ToString())

        Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

    End Sub
    Private Sub ButtonCopyFromTimesheetStaging_Click(sender As Object, e As EventArgs) Handles ButtonCopyFromTimesheetStaging.Click

        SetSingleDaySession()

        Try
            'Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            'Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim queryString As New AdvantageFramework.Web.QueryString

            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
            '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.txtEmpCode.Text)

            '    If Employee.CalendarTimeType = 1 Then

            '        If Employee.CalendarTimeEmailAddress Is Nothing And Employee.GoogleToken Is Nothing Then

            '            queryString.Page = "Maintenance_CalendarTime.aspx"
            '            Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

            '        Else

            queryString.Page = "Timesheet_CopyFrom.aspx"
            queryString.Add("v", "3")
            queryString.Add("dts", Me.RadComboBoxDayToShow.SelectedValue.ToString())

            Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

            '        End If

            '    Else

            '        queryString.Page = "Maintenance_CalendarTime.aspx"
            '        Me.OpenWindow(String.Empty, queryString.ToString(True), , , , True)

            '    End If

            'End Using
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ButtonCopyToCurrentWeek_Click(sender As Object, e As EventArgs) Handles ButtonCopyToCurrentWeek.Click

        Dim ts As New cTimeSheet(_Session.ConnectionString)
        Dim FirstDayOfWeek As Date = ts.FirstDayOfWeek(cEmployee.TimeZoneToday)

        'Me.SetCopySettings()
        CopyTimesheet(CType(CType(Me.RadioButtonListCopyType.SelectedItem.Value, Integer), CopyType), FirstDayOfWeek)

        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then

            Me.RadDatePickerStartDate.SelectedDate = FirstDayOfWeek
            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then

                Dim selectedDate As Date = Me.RadDatePickerStartDate.SelectedDate
                Me.SetDates(selectedDate)
                Me.RadGridTimesheetNew.Rebind()

            End If

        Else

            'single day, need to get the day of week viwing, then go to date of same day in current week...

            Dim selectedDate As Date = Me.RadDatePickerStartDate.SelectedDate
            Me.SetDates(selectedDate)
            Me.DayToShow = Me.RadComboBoxDayToShow.SelectedValue
            Me.RadGridTimesheetNew.Rebind()

        End If

    End Sub
    Private Sub ButtonCopyToSelectedWeek_Click(sender As Object, e As EventArgs) Handles ButtonCopyToSelectedWeek.Click

        If Me.RadCalendarCopyToSelectedWeek.SelectedDate = Nothing Then

            Me.ShowMessage("Please select a date")
            Exit Sub

        Else

            'Me.SetCopySettings()

            Dim ts As New cTimeSheet(Session("ConnString"))
            If ts.IsInWeek(Me.RadCalendarCopyToSelectedWeek.SelectedDate, Me.TimesheetStartDate, Me.TimesheetEndDate) = True Then

                Me.ShowMessage("Cannot copy timesheet to itself")
                Exit Sub

            End If

            Dim SelectedCopyType As CopyType = CType(CType(Me.RadioButtonListCopyType.SelectedItem.Value, Integer), CopyType)

            If SelectedCopyType = CopyType.EntireTimesheet Then

                Me.RadGridTimesheetNew.AllowPaging = False
                CopyRebind(ts.FirstDayOfWeek(Me.RadDatePickerStartDate.SelectedDate))

            End If

            CopyTimesheet(SelectedCopyType, ts.FirstDayOfWeek(Me.RadCalendarCopyToSelectedWeek.SelectedDate))

            If SelectedCopyType = CopyType.EntireTimesheet Then

                'Me.RadGridTimesheetNew.AllowPaging = True
                Me.SetDates(Me.RadCalendarCopyToSelectedWeek.SelectedDate)
                Dim qs As New AdvantageFramework.Web.QueryString
                qs = qs.FromCurrent()
                qs.Go()

            Else

                CopyRebind(Me.RadCalendarCopyToSelectedWeek.SelectedDate)

            End If

        End If

    End Sub

    Private Function CopyTimesheet(ByVal Type As CopyType, ByVal StartDate As Date, Optional ByRef ReturnMessage As String = Nothing,
                                   Optional ByRef RowsSaved As Integer = 0, Optional ByRef RowsFailed As Integer = 0) As Boolean

        Dim Copied As Boolean = False
        Dim SbError As New System.Text.StringBuilder

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim s As String = String.Empty

            Select Case Type
                Case CopyType.EntireTimesheet

                    For Each Row As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetNew.MasterTableView.Items

                        If CopyGridRow(DbContext, Row, StartDate, s) = False Then

                            If s IsNot String.Empty AndAlso s.Length > 0 AndAlso SbError.ToString().Contains(s) = False Then

                                SbError.Append(s)
                                SbError.Append("\n")

                            End If

                            RowsFailed += 1

                        Else

                            RowsSaved += 1

                        End If

                    Next

                Case CopyType.SelectedRows

                    For Each Row As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetNew.MasterTableView.Items

                        If Row.Selected = True Then

                            If CopyGridRow(DbContext, Row, StartDate, s) = False Then

                                If s IsNot String.Empty AndAlso s.Length > 0 AndAlso SbError.ToString().Contains(s) = False Then

                                    SbError.Append(s)
                                    SbError.Append("\n")

                                End If

                                RowsFailed += 1

                            Else

                                RowsSaved += 1

                            End If

                        End If

                    Next

            End Select

        End Using

        If RowsSaved > 0 Then

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            oTS.DeleteMissingTimeDtl(Me.TimesheetEmpCode)
            ProcessMissingTime(Me.TimesheetEmpCode, cEmployee.TimeZoneToday)

        End If
        If RowsFailed > 0 Then

            ReturnMessage = SbError.ToString()
            Me.ShowMessage(ReturnMessage)

        End If

        SbError = Nothing

        Return Copied

    End Function
    Private Function CopyGridRow(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GridRow As Telerik.Web.UI.GridDataItem,
                                 ByVal StartDate As Date, Optional ByRef RowMessage As String = "") As Boolean

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim EmployeeCode As String = Me.txtEmpCode.Text
        Dim DayAbbreviation As String = String.Empty
        Dim FullDayName As String = String.Empty
        Dim DayDatakey() As String

        Dim DayTimeType As String = String.Empty
        Dim DayET_ID As Integer = 0
        Dim DayETD_ID As Integer = 0

        Dim EntryMessage As String = ""
        Dim sb As New System.Text.StringBuilder

        Dim SuccessCounter As Integer = 0
        Dim FailCounter As Integer = 0

        Dim TargetDate As Date

        For i = 0 To 6

            TargetDate = StartDate.AddDays(i)
            oTS.GetDayNameStrings(TargetDate, DayAbbreviation, FullDayName, Me.StartWeekOn)

            DayET_ID = 0
            DayETD_ID = 0

            If Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumn" & FullDayName).Visible = True Then

                DayDatakey = CType(GridRow.FindControl(DayAbbreviation & "Datakey"), HiddenField).Value.Split("|")

                DayET_ID = CType(DayDatakey(7), Integer)
                DayETD_ID = CType(DayDatakey(8), Integer)
                DayTimeType = DayDatakey(10)

                If DayET_ID > 0 AndAlso DayETD_ID > 0 Then

                    If AdvantageFramework.EmployeeTimesheet.CopyTimeEntry(DbContext, _Session.UserCode, DayET_ID, DayETD_ID, DayTimeType, TargetDate,
                                                                          Me.txtEmpCode.Text.Trim(), Me.CheckBoxCopyWithHours.Checked, EntryMessage) = False Then

                        If sb.ToString().Contains(EntryMessage) = False Then

                            sb.Append(EntryMessage)
                            sb.Append(Environment.NewLine)

                        End If

                        FailCounter += 1

                    Else

                        SuccessCounter += 1

                    End If

                End If

            End If

        Next

        RowMessage = sb.ToString()
        sb = Nothing

        Return SuccessCounter > 0

    End Function
    Private Sub CopyRebind(ByVal SelectedDate As Date)

        Me.RadDatePickerStartDate.SelectedDate = SelectedDate

        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then

            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then

                Me.SetDates(SelectedDate)
                Me.RadGridTimesheetNew.Rebind()

            End If

        Else

            If Me.ValidDate() = True Then

                Me.SetDates(SelectedDate)
                Me.DayToShow = Me.RadComboBoxDayToShow.SelectedValue
                Me.RadGridTimesheetNew.Rebind()

            End If

        End If

    End Sub

    ''''Private Sub SetCopySettings()

    ''''    ''734-2-839-Timesheet - Option to copy hours defaults to TRUE and is freaking some clients out.
    ''''    ''Per call with Ellen, don't save this setting
    ''''    'Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
    ''''    'av.getAllAppVars()

    ''''    'av.setAppVar(Me.RadioButtonListCopyType.ID, Me.RadioButtonListCopyType.SelectedIndex, "Integer")
    ''''    ' av.setAppVar(Me.CheckBoxCopyWithHours.ID, Me.CheckBoxCopyWithHours.Checked.ToString().ToLower(), "Boolean")

    ''''    'av.SaveAllAppVars()

    ''''End Sub
    ''''Private Sub LoadCopySettings()

    ''''    ''734-2-839-Timesheet - Option to copy hours defaults to TRUE and is freaking some clients out.
    ''''    ''Per call with Ellen, don't save this setting
    ''''    'Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
    ''''    'av.getAllAppVars()

    ''''    'If av.HasAppVar(Me.RadioButtonListCopyType.ID) Then

    ''''    '    Me.RadioButtonListCopyType.SelectedIndex = CType(av.getAppVar(Me.RadioButtonListCopyType.ID, "Integer", "0"), Integer)

    ''''    'End If
    ''''    'If av.HasAppVar(Me.CheckBoxCopyWithHours.ID) Then

    ''''    '    Me.CheckBoxCopyWithHours.Checked = av.getAppVar(Me.CheckBoxCopyWithHours.ID, "Boolean", "false").ToLower() = "true"

    ''''    'Else

    ''''    '    Me.CheckBoxCopyWithHours.Checked = False

    ''''    'End If

    ''''End Sub

    Private Function SaveGridRow(ByVal GridRow As Telerik.Web.UI.GridDataItem, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim RowEmpCode As String = Me.txtEmpCode.Text
            Dim RowOldFuncCat As String = String.Empty
            Dim RowNewFuncCat As String = String.Empty
            Dim RowProdCat As String = String.Empty
            Dim RowJobNum As Integer = 0
            Dim RowJobCompNum As Integer = 0
            Dim RowDeptTeam As String = String.Empty
            Dim RowTimeType As String = "D"
            Dim RowUserID As String = String.Empty

            Dim OldVal As String = String.Empty
            Dim NewVal As String = String.Empty

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim HasSaved As Boolean
            Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

            Dim BoolDeleteZero As Boolean = True

            Dim SundayEditMessageAdded As Boolean = False
            Dim MondayEditMessageAdded As Boolean = False
            Dim TuesdayEditMessageAdded As Boolean = False
            Dim WednesdayEditMessageAdded As Boolean = False
            Dim ThursdayIsEditMessageAdded As Boolean = False
            Dim FridayEditMessageAdded As Boolean = False
            Dim SaturdayEditMessageAdded As Boolean = False
            Dim ReturnMessage As String = String.Empty

            Dim RowDatakey() As String

            RowDatakey = GridRow.GetDataKeyValue("LineIdentifier").ToString().Split("|")

            'Values common for the row:
            RowEmpCode = Me.txtEmpCode.Text

            Try
                RowNewFuncCat = RowDatakey(6)
            Catch ex As Exception
                RowNewFuncCat = String.Empty
            End Try
            Try
                RowOldFuncCat = RowDatakey(6)
            Catch ex As Exception
                RowOldFuncCat = String.Empty
            End Try

            RowProdCat = RowDatakey(8)

            Try
                RowJobNum = CType(RowDatakey(4), Integer)
            Catch ex As Exception
                RowJobNum = 0
            End Try
            Try
                RowJobCompNum = CType(RowDatakey(5), Integer)
            Catch ex As Exception
                RowJobCompNum = 0
            End Try

            If RowJobNum = 0 And RowJobCompNum = 0 Then
                RowTimeType = "N"
            End If

            RowDeptTeam = RowDatakey(7)
            RowUserID = Session("UserCode")

            Dim EverythingSavedOK As Boolean = True
            Dim CommentMethods As New cComments(Session("ConnString"))
            Dim HoursTextBox As New TextBox
            Dim CommentsTextBox As New System.Web.UI.WebControls.TextBox

            For i = 0 To 6

                Dim DayET_ID As Integer = 0
                Dim DayETD_ID As Integer = 0
                Dim DayEmpDate As Date = Nothing
                Dim DayError As String = String.Empty
                Dim DayTimeType As String = String.Empty
                Dim DayHours As Decimal = 0.0
                Dim DayComment As String = String.Empty
                Dim InputHours As Decimal = 0.0
                Dim InputComment As String = String.Empty
                Dim DayDatakey() As String
                Dim DayAbbreviation As String = String.Empty
                Dim FullDay As String = String.Empty
                Dim ColumnDate As Date = Nothing

                ColumnDate = Me.TimesheetStartDate.AddDays(i)

                oTS.GetDayNameStrings(ColumnDate, DayAbbreviation, FullDay, Me.StartWeekOn)

                HoursTextBox = Nothing
                CommentsTextBox = Nothing
                HoursTextBox = CType(GridRow.FindControl("Txt" & FullDay), TextBox)
                CommentsTextBox = CType(GridRow.FindControl(DayAbbreviation & "TextBoxComment"), TextBox)

                If HoursTextBox.Enabled = True And CommentsTextBox.Visible = True And CommentsTextBox.Enabled = True Then

                    DayET_ID = 0
                    DayETD_ID = 0
                    DayEmpDate = Nothing
                    DayError = String.Empty
                    DayTimeType = String.Empty

                    DayHours = 0.0
                    DayComment = String.Empty

                    DayDatakey = Nothing

                    DayDatakey = CType(GridRow.FindControl(DayAbbreviation & "Datakey"), HiddenField).Value.Split("|")

                    DayET_ID = CType(DayDatakey(7), Integer)
                    DayETD_ID = CType(DayDatakey(8), Integer)
                    DayEmpDate = CType(DayDatakey(9), Date)
                    DayHours = CType(DayDatakey(14), Decimal)
                    DayTimeType = DayDatakey(10)

                    InputHours = 0.0
                    InputComment = String.Empty

                    CurrEditStatus = oTS.CheckEditStatus(DayET_ID, DayETD_ID)

                    If CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                        NewVal = HoursTextBox.Text.Trim()
                        DayComment = CommentsTextBox.Text.Trim()

                        If IsNumeric(NewVal) = True Then

                            InputHours = CType(NewVal, Double)

                            If InputHours > 24.0 Then

                                HoursTextBox.BorderColor = Color.DarkRed
                                ErrorMessage = "Invalid hours"
                                EverythingSavedOK = False

                            ElseIf InputHours > 0.0 And DayComment = String.Empty And RowTimeType = "D" And oTS.JobCommentRequired(RowJobNum) = True Then
                                CommentsTextBox.BorderColor = Color.DarkRed
                                ErrorMessage = "Missing comments"
                                EverythingSavedOK = False
                            Else

                                If DayHours <> InputHours Then 'handle inserts and updates of time with comments

                                    Dim NewEtId As Integer = 0
                                    Dim NewEtDtlId As Integer = 0

                                    If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), DayET_ID, DayETD_ID, RowEmpCode, DayEmpDate, RowNewFuncCat, RowProdCat, InputHours, RowJobNum, RowJobCompNum, RowDeptTeam,
                                                                RowUserID, DayError, DayComment, NewEtId, NewEtDtlId) = True Then

                                        If DayET_ID = 0 And NewEtId > 0 Then DayET_ID = NewEtId
                                        If DayETD_ID = 0 And NewEtDtlId > 0 Then DayETD_ID = NewEtDtlId

                                        CommentMethods.SaveEmpTimeComments(DayTimeType, DayET_ID, DayETD_ID, DayComment)

                                    Else

                                        ErrorMessage &= "\r\n" & DayError
                                        EverythingSavedOK = False

                                    End If

                                ElseIf DayHours = InputHours And DayET_ID > 0 And DayETD_ID > 0 Then 'only update the comment

                                    CommentMethods.SaveEmpTimeComments(DayTimeType, DayET_ID, DayETD_ID, DayComment)

                                End If

                                CommentsTextBox.BorderColor = Nothing
                                HoursTextBox.BorderColor = Nothing

                            End If

                        Else

                            HoursTextBox.BorderColor = Color.DarkRed
                            ErrorMessage = "Invalid hours"
                            EverythingSavedOK = False

                        End If

                    End If

                End If


            Next

            'Sunday/Sun:
            If EverythingSavedOK = True Then
                ErrorMessage = String.Empty
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function

    'RESOURCE:  http://weblog.west-wind.com/posts/2006/Apr/09/ASPNET-20-MasterPages-and-FindControl
    Public Shared Function FindControlRecursive(Root As System.Web.UI.Control, Id As String) As System.Web.UI.Control

        If Root.ID = Id Then
            Return Root
        End If

        For Each Ctl As System.Web.UI.Control In Root.Controls


            Dim FoundCtl As System.Web.UI.Control = FindControlRecursive(Ctl, Id)

            If FoundCtl IsNot Nothing Then

                Return FoundCtl

            End If
        Next

        Return Nothing

    End Function

    Private Sub DropGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropGroupBy.SelectedIndexChanged
        Try
            If ValidDate() = False Then Exit Sub
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("DropGroupByIndex", Me.DropGroupBy.SelectedIndex, "Integer")
            av.SaveAllAppVars()
            Me.RadGridTimesheetNew.Rebind()

            If DropGroupBy.Text <> Me.CollapsedHeaders.GroupName Then
                Me.CollapsedHeaders.GroupName = DropGroupBy.Text
                Me.CollapsedHeaders.GroupCaptions.Clear()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetGrouping()
        Try
            If GroupingIndex > 0 Then
                If Me.DropGroupBy.Items.Count = 0 Then
                    Me.LoadGroupBy()
                End If
                Me.DropGroupBy.SelectedIndex = GroupingIndex
                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse(Me.DropGroupBy.SelectedValue)
                With Me.RadGridTimesheetNew
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                End With
            Else
                Me.RadGridTimesheetNew.MasterTableView.GroupByExpressions.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SaveDaysToDisplay(ByVal DisplayDays As Integer)
        Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
        av.getAllAppVars()
        av.setAppVar("DaysToDisplay", DisplayDays.ToString(), "Integer")
        av.SaveAllAppVars()
    End Sub

    Private Sub imgbtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnRefresh.Click
        If ValidDate() = False Then Exit Sub
        If ValidateEmployeeCode(Me.txtEmpCode.Text) = False Then Exit Sub
        Me.RadGridTimesheetNew.Rebind()
    End Sub
    Private Sub RadDatePickerStartDate_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        If ValidDate() = False Then Exit Sub
        Me.RadGridTimesheetNew.Rebind()

    End Sub
    Private Sub RadComboBoxDayToShow_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDayToShow.SelectedIndexChanged

        If Me.ValidateEmployeeCode(Me.txtEmpCode.Text) = True And Me.ValidDate() = True Then

            SetDayToShowSession()

            Me.DayToShow = Me.RadComboBoxDayToShow.SelectedValue
            Me.RadGridTimesheetNew.Rebind()

        End If
    End Sub
    Private Sub SetDayToShowSession()

        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then

            Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
            Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing

        Else

            Session("TimesheetMain_SingleViewDayOfWeek") = Me.RadComboBoxDayToShow.SelectedValue
            Session("TimesheetCommentView_SingleViewDayOfWeek") = Me.RadComboBoxDayToShow.SelectedValue

        End If

        Session("TimesheetMain_UserHasMadeASelection") = Me.RadComboBoxDayToShow.SelectedValue

    End Sub
    Private Sub ImageButtonPreviousWeek_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonPreviousWeek.Click
        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then 'move through weeks

            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then

                Dim ts As New cTimeSheet(_Session.ConnectionString)
                Dim selectedDate As Date = Me.RadDatePickerStartDate.SelectedDate

                selectedDate = ts.FirstDayOfWeek(selectedDate)
                selectedDate = selectedDate.AddDays(-7)
                selectedDate = ts.FirstDayOfWeek(selectedDate)

                Me.SetDates(selectedDate)
                Me.RadGridTimesheetNew.Rebind()

            End If

        Else 'move through days of the week in single view

            If Me.ValidDate() = True Then

                Me.SetPreviousDay()
                Me.DayToShow = Me.RadComboBoxDayToShow.SelectedValue
                Me.RadGridTimesheetNew.Rebind()

            End If

        End If

        Session("TimesheetMain_UserHasMadeASelection") = Me.RadComboBoxDayToShow.SelectedValue

    End Sub
    Private Sub ImageButtonCurrentWeek_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCurrentWeek.Click

        Dim ts As New cTimeSheet(_Session.ConnectionString)
        Dim currentDate As Date = cEmployee.TimeZoneToday
        currentDate = ts.FirstDayOfWeek(currentDate)

        Me.SetDates(currentDate)

        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then 'move through weeks

            Me.RadGridTimesheetNew.Rebind()

        Else 'move through days of the week in single view

            Me.DayToShow = CType(cEmployee.TimeZoneToday.DayOfWeek, Integer).ToString()
            Select Case Me.StartWeekOn
                Case DayOfWeek.Saturday
                    Me.DayToShow += 1
                Case DayOfWeek.Monday
                    Me.DayToShow -= 1
            End Select
            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDayToShow, Me.DayToShow, False)
            SetDayToShowSession()
            Me.RadGridTimesheetNew.Rebind()

        End If

    End Sub
    Private Sub ImageButtonNextWeek_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonNextWeek.Click
        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then 'move through weeks
            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then
                Dim selectedDate As Date = Me.RadDatePickerStartDate.SelectedDate
                selectedDate = selectedDate.AddDays(8)
                Me.SetDates(selectedDate)
                Me.RadGridTimesheetNew.Rebind()
            End If
        Else 'move through days of the week in single view
            If Me.ValidDate() = True Then
                Me.SetNextDay()
                Me.DayToShow = Me.RadComboBoxDayToShow.SelectedValue
                Me.RadGridTimesheetNew.Rebind()
            End If
        End If

        Session("TimesheetMain_UserHasMadeASelection") = Me.RadComboBoxDayToShow.SelectedValue

    End Sub

    '<System.Web.Services.WebMethod()> _
    'Public Shared Function SearchContracts(searchCriteriaText As String) As List(Of OfficeToProductContractSearchResult)
    '    Dim results As New List(Of OfficeToProductContractSearchResult)
    '    Dim searchCriteria As ContractSearchCriteria = JsonConvert.DeserializeObject(Of ContractSearchCriteria)(searchCriteriaText)
    '    searchCriteria.SearchText = searchCriteria.SearchText.Trim()

    '    If (IsNothing(HttpContext.Current.Session("ConnString")) = False AndAlso IsNothing(HttpContext.Current.Session("UserCode")) = False) Then
    '        Using DataContext = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
    '            Dim documentRepo As Interfaces.IContractRepository = New Repositories.ContractRepository(DataContext)
    '            results = documentRepo.SearchContracts(searchCriteria)
    '        End Using
    '    End If

    '    Return results.ToList()

    '    'Dim json As String = JsonConvert.SerializeObject(results)

    '    'HttpContext.Current.Response.Clear()
    '    'HttpContext.Current.Response.ContentType = "application/json;"
    '    'HttpContext.Current.Response.Write(json)

    'End Function

    '<System.Web.Services.WebMethod()> _
    'Public Shared Function SearchContractsTest() As List(Of OfficeToProductContractSearchResult)
    '    Dim results As New List(Of OfficeToProductContractSearchResult)
    '    Dim searchCriteria As ContractSearchCriteria = New ContractSearchCriteria()
    '    searchCriteria.SearchLevel = "Office"
    '    searchCriteria.SearchText = searchCriteria.SearchText.Trim()

    '    If (IsNothing(HttpContext.Current.Session("ConnString")) = False AndAlso IsNothing(HttpContext.Current.Session("UserCode")) = False) Then
    '        Using DataContext = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
    '            Dim documentRepo As Interfaces.IContractRepository = New Repositories.ContractRepository(DataContext)
    '            results = documentRepo.SearchContracts(searchCriteria)
    '        End Using
    '    End If

    '    Return results.ToList()

    '    'Dim json As String = JsonConvert.SerializeObject(results)

    '    'HttpContext.Current.Response.Clear()
    '    'HttpContext.Current.Response.ContentType = "application/json;"
    '    'HttpContext.Current.Response.Write(json)

    'End Function

#Region " RadGrid Functions"

    Private Property CurrentGridPageIndex As Integer = 0
    Private IsSingleDayView As Boolean = False
    Private ArrayCounter As Integer = 0
    Private _HasPostedProgress As Boolean = False


    Private Sub RadGridTimesheetNew_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridTimesheetNew.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridTimesheetNew.Rebind()
    End Sub
    Private Sub RadGridTimesheetNew_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridTimesheetNew.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridTimesheetNew.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub RadGridTimesheetNew_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTimesheetNew.NeedDataSource

        _LoadingDatasource = True

        Me.ClearCurrentTimesheet()

        If Not Me.CurrentTimesheet Is Nothing Then

            Dim oA As cAgency = New cAgency(CStr(Session("ConnString")))

            'check posting period (it sets the posting period vars):
            CheckPostPeriod()

            'Set the label in the header:
            If oA.CheckTimeSupervisorApproval = True Then

                SetApprovals(Me.CurrentTimesheet)

            End If

            'Set the datasource:
            Me.RadGridTimesheetNew.DataSource = Me.CurrentTimesheet ' FilterTimesheetLines() this almost works, but some rebinds negate this logic
            Me.TimesheetIsMissingComments = Me.CurrentTimesheet.IsMissingComments

            'Show/hide Product Category Column
            If ProductCategoryIsVisible() = True Then

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnProductCategorySortable").Display = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnProductCategory").Display = True

            Else

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnProductCategorySortable").Display = False
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnProductCategory").Display = False

            End If

            If RequireAssignment() = True Then

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnAlertSubject").Display = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnAlertSubject").HeaderAbbr = "FIXED"

            Else

                'Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnAlertSubject").Display = False
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnAlertSubject").HeaderAbbr = Nothing

            End If

            Dim cAgency As New cAgency(Session("ConnString"))
            AllowQvAQuery = cAgency.QvAQueryCheck

            Me.RadGridTimesheetNew.CurrentPageIndex = Me.CurrentGridPageIndex

            If Not Me.IsPostBack And Not Me.IsCallback Then

                If Me.DisablePagingOnMainGrid = True Then

                    Me.RadGridTimesheetNew.AllowPaging = False

                Else

                    Me.RadGridTimesheetNew.PageSize = MiscFN.LoadPageSize(Me.RadGridTimesheetNew.ID)

                End If

            End If

            Me.SetGrouping()

            Me.RadGridTimesheetNew.MasterTableView.IsItemInserted = Not _PostPeriodClosedForAllDays

        End If

        _LoadingDatasource = False

    End Sub
    Private Sub RadGridTimesheetNew_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTimesheetNew.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then

            'Select Case Me.StartWeekOn
            '    Case DayOfWeek.Saturday
            '        Me._TodayOffset = cEmployee.TimeZoneToday.DayOfWeek + 1
            '    Case DayOfWeek.Sunday
            '        Me._TodayOffset = cEmployee.TimeZoneToday.DayOfWeek
            '    Case DayOfWeek.Monday
            '        Me._TodayOffset = cEmployee.TimeZoneToday.DayOfWeek - 1
            'End Select

        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then

            'If Me.CommentsRequired = True Then

            '    Me.TextBox_SaturdayComments = e.Item.FindControl("TextBox_SaturdayComments")
            '    Me.TextBox_SundayComments.CssClass = "RequiredInput"
            '    Me.TextBox_MondayComments.CssClass = "RequiredInput"
            '    Me.TextBox_TuesdayComments.CssClass = "RequiredInput"
            '    Me.TextBox_WednesdayComments.CssClass = "RequiredInput"
            '    Me.TextBox_ThursdayComments.CssClass = "RequiredInput"
            '    Me.TextBox_FridayComments.CssClass = "RequiredInput"
            '    Me.TextBox_SaturdayComments.CssClass = "RequiredInput"

            'End If
            Dim TimeTextBox As TextBox
            Dim CommentTextBox As TextBox
            Try
                If SunClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemSunday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_SundayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If MonClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemMonday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_MondayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If TueClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemTuesday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_TuesdayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If WedClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemWednesday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_WednesdayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If ThuClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemThursday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_ThursdayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If FriClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemFriday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_FridayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try
            Try
                If SatClosedPP = True Then
                    TimeTextBox = e.Item.FindControl("TextBox_NewItemSaturday")
                    If TimeTextBox IsNot Nothing Then TimeTextBox.Enabled = False
                    CommentTextBox = e.Item.FindControl("TextBox_SaturdayComments")
                    If CommentTextBox IsNot Nothing Then CommentTextBox.Enabled = False
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.ShowCommentsUsing = "none" Then

                    Dim EditItemTemplateDiv As HtmlControls.HtmlControl

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateSunday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateMonday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateTuesday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateWednesday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateThursday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateFriday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                    EditItemTemplateDiv = e.Item.FindControl("DivEditItemTemplateSaturday")
                    If EditItemTemplateDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivSetCssClass(EditItemTemplateDiv, "timesheet-day-edit-item-template-container-no-comment")

                End If
            Catch ex As Exception
            End Try

            Try

                If RequireAssignment() = True Then

                    CType(e.Item.FindControl("TextBox_Assignment"), TextBox).CssClass = "RequiredInput"

                End If

            Catch ex As Exception
            End Try

        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
            If TypeOf (CurrentGridRow.DataItem) Is Telerik.Web.UI.GridInsertionObject Then

                Exit Sub

            End If

            Dim StartDate As Date = Me.TimesheetStartDate

            Dim TotalsControl As Label = e.Item.FindControl("lblTotalHours")

            Dim SundayControlID As String = e.Item.FindControl("TxtSunday").ClientID
            Dim MondayControlID As String = e.Item.FindControl("TxtMonday").ClientID
            Dim TuesdayControlID As String = e.Item.FindControl("TxtTuesday").ClientID
            Dim WednesdayControlID As String = e.Item.FindControl("TxtWednesday").ClientID
            Dim ThursdayControlID As String = e.Item.FindControl("TxtThursday").ClientID
            Dim FridayControlID As String = e.Item.FindControl("TxtFriday").ClientID
            Dim SaturdayControlID As String = e.Item.FindControl("TxtSaturday").ClientID
            Dim TotalsControlID As String = TotalsControl.ClientID

            Dim LineTotalJavascript As String = String.Format("setLineTotal('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", SundayControlID, MondayControlID, TuesdayControlID, WednesdayControlID, ThursdayControlID, FridayControlID, SaturdayControlID, TotalsControlID)

            If Not StartDate = Nothing Then

                For i = 0 To 6

                    'Set each "cell" (TimesheetDay) in the row
                    Me.SetGridCell(CurrentGridRow, StartDate.AddDays(i), LineTotalJavascript)

                Next

            End If


            Dim TimesheetRow As AdvantageFramework.Timesheet.TimesheetLine
            TimesheetRow = CType(CurrentGridRow.DataItem, AdvantageFramework.Timesheet.TimesheetLine)

            Dim ThisJobNum As Integer = 0
            Try

                If Not TimesheetRow Is Nothing Then

                    ThisJobNum = TimesheetRow.JobNumber

                End If

            Catch ex As Exception

                ThisJobNum = 0

            End Try

            If (ThisJobNum = 0) Then

                e.Item.FindControl("LabelJob").Visible = False

            End If

            If (TimesheetRow.JobComponentNbr = 0) Then

                e.Item.FindControl("LabelComponent").Visible = False

            End If


            Dim QuerystringTimesheetDetails As New AdvantageFramework.Web.QueryString
            If ThisJobNum = 0 Then

                CType(CurrentGridRow("GridTemplateColumnViewDetails").FindControl("ImageButtonViewDetails"), ImageButton).Visible = False
                CurrentGridRow("GridTemplateColumnViewDetails").Text = "&nbsp;"

            Else

                If AllowQvAQuery = True Then

                    QuerystringTimesheetDetails.Page = "Timesheet_Details.aspx"
                    QuerystringTimesheetDetails.JobNumber = TimesheetRow.JobNumber
                    QuerystringTimesheetDetails.JobComponentNumber = TimesheetRow.JobComponentNbr
                    QuerystringTimesheetDetails.Add("fn", TimesheetRow.FuncCat)
                    QuerystringTimesheetDetails.Add("emp", Me.TimesheetEmpCode)

                    CType(CurrentGridRow.FindControl("ImageButtonViewDetails"), ImageButton).Attributes.Add("onclick", "return showTimesheetDetails('" & QuerystringTimesheetDetails.ToString(True) & "');")
                    CType(CurrentGridRow("GridTemplateColumnViewDetails").FindControl("ImageButtonViewDetails"), ImageButton).Visible = True

                Else

                    CType(CurrentGridRow("GridTemplateColumnViewDetails").FindControl("ImageButtonViewDetails"), ImageButton).Visible = False
                    CurrentGridRow("GridTemplateColumnViewDetails").Text = "&nbsp;"

                End If

            End If

            Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = CType(CurrentGridRow.FindControl("ImageButtonDelete"), ImageButton)
            Dim DeleteDiv As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivDelete")
            Dim CanDelete As Boolean = False

            CanDelete = Not TimesheetRow.CannotEditDueToProcessingControl

            If Me.DayToShow.Contains("all") = True Then

                Me.IsSingleDayView = False

            End If

            If CanDelete = True Then

                If Me.IsSingleDayView = False Then

                    CanDelete = Me.SetDelete(TimesheetRow)

                Else

                    Dim TsCell As AdvantageFramework.Timesheet.TimesheetEntry

                    Select Case StartWeekOn
                        Case DayOfWeek.Saturday

                            Select Case CType(Me.DayToShow, Integer)
                                Case 0
                                    TsCell = TimesheetRow.Saturday
                                Case 1
                                    TsCell = TimesheetRow.Sunday
                                Case 2
                                    TsCell = TimesheetRow.Monday
                                Case 3
                                    TsCell = TimesheetRow.Tuesday
                                Case 4
                                    TsCell = TimesheetRow.Wednesday
                                Case 5
                                    TsCell = TimesheetRow.Thursday
                                Case 6
                                    TsCell = TimesheetRow.Friday
                            End Select

                        Case DayOfWeek.Sunday

                            Select Case CType(Me.DayToShow, Integer)
                                Case 0
                                    TsCell = TimesheetRow.Sunday
                                Case 1
                                    TsCell = TimesheetRow.Monday
                                Case 2
                                    TsCell = TimesheetRow.Tuesday
                                Case 3
                                    TsCell = TimesheetRow.Wednesday
                                Case 4
                                    TsCell = TimesheetRow.Thursday
                                Case 5
                                    TsCell = TimesheetRow.Friday
                                Case 6
                                    TsCell = TimesheetRow.Saturday
                            End Select

                        Case DayOfWeek.Monday

                            Select Case CType(Me.DayToShow, Integer)
                                Case 0
                                    TsCell = TimesheetRow.Monday
                                Case 1
                                    TsCell = TimesheetRow.Tuesday
                                Case 2
                                    TsCell = TimesheetRow.Wednesday
                                Case 3
                                    TsCell = TimesheetRow.Thursday
                                Case 4
                                    TsCell = TimesheetRow.Friday
                                Case 5
                                    TsCell = TimesheetRow.Saturday
                                Case 6
                                    TsCell = TimesheetRow.Sunday
                            End Select

                    End Select

                    If Not TsCell Is Nothing Then

                        Try

                            If TsCell.Hours = 0 AndAlso TsCell.Comments.Trim() = "" Then ' AndAlso CType(Me.DayToShow, Integer) <> Me._TodayOffset Then

                                CurrentGridRow.Display = Me.RepeatRowForAllDays

                            End If

                            CanDelete = TsCell.CanDelete

                            If TotalsControl IsNot Nothing Then TotalsControl.Text = FormatNumber(TsCell.Hours, 2)

                        Catch ex As Exception
                        End Try

                    Else

                        CurrentGridRow.Display = Me.RepeatRowForAllDays

                    End If

                End If

            End If

            If CanDelete = True Then

                If (IsNothing(DeleteImageButton) = False) Then

                    DeleteImageButton.Attributes("onclick") = "return confirm('Are you sure you want to delete this row?')"
                    DeleteImageButton.Enabled = True
                    DeleteImageButton.ToolTip = "Delete row"

                End If

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

            End If

            Dim HiddenField_RowIsDeleteable As HiddenField = e.Item.FindControl("HiddenField_RowIsDeleteable")

            HiddenField_RowIsDeleteable.Value = CanDelete

            Dim HoursRemainLabel As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LabelHoursRemain"), Label)
            Dim HoursRemaining As Double = 0.0
            Dim DisplayHoursRemaining As Boolean = False
            Dim QvaProgressLiteral As Literal = CType(e.Item.FindControl("LiteralQvaProgress"), Literal)

            If QvaProgressLiteral IsNot Nothing Then

                Dim Progress As Double = 0.0
                Dim ToolTip As String = String.Empty
                Dim QuotedOrTraffic As String = String.Empty
                Dim CustomProgress As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator()

                CustomProgress.Width = 80

                If TimesheetRow.ProgressIsShowingTrafficHours = True Then

                    QuotedOrTraffic = "traffic"

                Else

                    QuotedOrTraffic = "quoted"

                End If

                If TimesheetRow.QuotedHours > 0 Then

                    HoursRemaining = TimesheetRow.QuotedHours - TimesheetRow.ActualHours
                    Progress = (TimesheetRow.ActualHours / TimesheetRow.QuotedHours) * 100

                    Dim RemainingText As String = String.Empty

                    If HoursRemaining > 0 Then

                        RemainingText = "remaining:  " & FormatNumber(HoursRemaining, 2) & " hours"

                    ElseIf HoursRemaining < 0 Then

                        RemainingText = "over by:  " & FormatNumber(HoursRemaining * -1, 2) & " hours"

                    End If

                    ToolTip = FormatNumber(TimesheetRow.ActualHours, 2) & " posted hours of " & FormatNumber(TimesheetRow.QuotedHours, 2) & " " & QuotedOrTraffic & " hours, " & RemainingText

                    If TimesheetRow.IsOverThreshold = True Then

                        CustomProgress.Color = "#DC3545"

                    Else

                        CustomProgress.Color = "#5CB85C"

                    End If

                    DisplayHoursRemaining = True

                    Try

                        If TimesheetRow.Threshold > 0 Then

                            ToolTip &= String.Format(", threshold:  {0} hours ({1}%)", (TimesheetRow.QuotedHours * (TimesheetRow.Threshold * 0.01)), TimesheetRow.Threshold)

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    Progress = 100
                    ToolTip = FormatNumber(TimesheetRow.ActualHours, 2) & " posted hours"
                    CustomProgress.Color = "#FFC107"
                    Me._HasPostedProgress = True

                End If


                CustomProgress.ToolTip = ToolTip
                CustomProgress.Value = Progress

                If ThisJobNum > 0 AndAlso AllowQvAQuery = True Then

                    CustomProgress.OnClick = "OpenRadWindow('','" & QuerystringTimesheetDetails.ToString(True) & "');"

                End If

                QvaProgressLiteral.Text = CustomProgress.DrawHTML()

            End If
            If HoursRemainLabel IsNot Nothing Then

                If DisplayHoursRemaining = True Then

                    Dim HoursRemainingText As String = String.Empty

                    If TimesheetRow.IsOverThreshold = True Then

                        HoursRemainLabel.Text = "<span style=""color:#DC3545 !important;cursor: pointer;"">" & FormatNumber(HoursRemaining, 2) & "</span>"

                    Else

                        HoursRemainLabel.Text = "<span style=""color:#5CB85C !important;cursor: pointer;"">" & FormatNumber(HoursRemaining, 2) & "</span>"

                    End If

                Else

                    HoursRemainLabel.Text = FormatNumber(TimesheetRow.ActualHours, 2) & "*"

                End If

                If ThisJobNum > 0 AndAlso AllowQvAQuery = True Then

                    HoursRemainLabel.Attributes.Add("onclick", "OpenRadWindow('','" & QuerystringTimesheetDetails.ToString(True) & "');")
                    HoursRemainLabel.Text = "<span style = ""cursor: pointer;"">" & HoursRemainLabel.Text & "</span>"

                End If

            End If

        End If

        If (TypeOf e.Item Is Telerik.Web.UI.GridFooterItem) Then

            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(e.Item, Telerik.Web.UI.GridFooterItem)

            If footerItem IsNot Nothing Then

                Dim culureInfo As System.Globalization.CultureInfo
                Dim lg As New LoGlo()
                culureInfo = lg.GetCultureInfo

                AdvantageFramework.Timesheet.GetTotalsFromTimesheet(Me.CurrentTimesheet, SunTotal, MonTotal, TueTotal, WedTotal, ThuTotal, FriTotal, SatTotal, WeekTotal)

                footerItem("CommentsView").Text = "Total"

                Dim ColumnName As String = ""

                Select Case Me.StartWeekOn
                    Case DayOfWeek.Saturday

                        footerItem("GridBoundColumnSunday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SundayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SatTotal, 2).ToString())
                        footerItem("GridBoundColumnMonday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='MondayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SunTotal, 2).ToString())
                        footerItem("GridBoundColumnTuesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='TuesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(MonTotal, 2).ToString())
                        footerItem("GridBoundColumnWednesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='WednesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(TueTotal, 2).ToString())
                        footerItem("GridBoundColumnThursday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='ThursdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(WedTotal, 2).ToString())
                        footerItem("GridBoundColumnFriday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='FridayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(ThuTotal, 2).ToString())
                        footerItem("GridBoundColumnSaturday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SaturdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(FriTotal, 2).ToString())

                        ColumnName = "GridBoundColumnMonday"
                        If SunTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnTuesday"
                        If MonTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnWednesday"
                        If TueTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnThursday"
                        If WedTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnFriday"
                        If ThuTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnSaturday"
                        If FriTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnSunday"
                        If SatTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If


                    Case DayOfWeek.Sunday

                        footerItem("GridBoundColumnSunday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SundayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SunTotal, 2).ToString())
                        footerItem("GridBoundColumnMonday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='MondayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(MonTotal, 2).ToString())
                        footerItem("GridBoundColumnTuesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='TuesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(TueTotal, 2).ToString())
                        footerItem("GridBoundColumnWednesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='WednesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(WedTotal, 2).ToString())
                        footerItem("GridBoundColumnThursday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='ThursdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(ThuTotal, 2).ToString())
                        footerItem("GridBoundColumnFriday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='FridayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(FriTotal, 2).ToString())
                        footerItem("GridBoundColumnSaturday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SaturdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SatTotal, 2).ToString())

                        ColumnName = "GridBoundColumnSunday"
                        If SunTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnMonday"
                        If MonTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnTuesday"
                        If TueTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnWednesday"
                        If WedTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnThursday"
                        If ThuTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnFriday"
                        If FriTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnSaturday"
                        If SatTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If

                    Case DayOfWeek.Monday

                        footerItem("GridBoundColumnSunday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SundayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(MonTotal, 2).ToString())
                        footerItem("GridBoundColumnMonday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='MondayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(TueTotal, 2).ToString())
                        footerItem("GridBoundColumnTuesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='TuesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(WedTotal, 2).ToString())
                        footerItem("GridBoundColumnWednesday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='WednesdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(ThuTotal, 2).ToString())
                        footerItem("GridBoundColumnThursday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='ThursdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(FriTotal, 2).ToString())
                        footerItem("GridBoundColumnFriday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='FridayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SatTotal, 2).ToString())
                        footerItem("GridBoundColumnSaturday").Text = String.Format("&nbsp;&nbsp;&nbsp;<span id='SaturdayFooterTotal' {0}>{1}</span>", "#CLASS#", Microsoft.VisualBasic.FormatNumber(SunTotal, 2).ToString())

                        ColumnName = "GridBoundColumnSaturday"
                        If SunTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnSunday"
                        If MonTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnMonday"
                        If TueTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnTuesday"
                        If WedTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnWednesday"
                        If ThuTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnThursday"
                        If FriTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If
                        ColumnName = "GridBoundColumnFriday"
                        If SatTotal > 24 Then
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "class='warning'")
                        Else
                            footerItem(ColumnName).Text = footerItem(ColumnName).Text.Replace("#CLASS#", "")
                        End If

                End Select

                footerItem("colTotalHours").Text = "<span id='WeekGrandTotal'>" & Microsoft.VisualBasic.FormatNumber(WeekTotal, 2).ToString() & "</span>"
                footerItem("colTotalHours").ToolTip = "Grand Total For All Days, All Rows"
                footerItem("colTotalHours").Attributes.Add("style", "cursor: help !important;")

                If Me._HasPostedProgress = True Then

                    CType(footerItem.FindControl("LabelHoursRemainFooter"), Label).Text = "<span style=""font-size:x-small"">* Indicates Posted</span>"

                End If

            End If

        End If

    End Sub
    Private Sub RadGridTimesheetNew_PreRender(sender As Object, e As System.EventArgs) Handles RadGridTimesheetNew.PreRender
        Me.SetLookUps()
        Me.SetGridDescriptionHeaders()

        Me.SetGridDayHeaders()

        Dim GridSettings As New GridSettingsPersister(Me.RadGridTimesheetNew)
        GridSettings.SaveToDatabase()

        For Each groupheader As GridGroupHeaderItem In Me.RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.GroupHeader)

            Dim flag As New Boolean

            For Each I As GridItem In groupheader.GetChildItems()
                If I.Display Then
                    flag = True
                    Exit For
                End If
            Next

            groupheader.Visible = flag

        Next

        Dim HeaderCssClass As String = String.Format("timesheet-day-radgrid-column-{0}", Me.ShowCommentsUsing)

        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").HeaderStyle.CssClass = HeaderCssClass
        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").HeaderStyle.CssClass = HeaderCssClass

        Dim TodayDayOfWeek As Date = cEmployee.TimeZoneToday

        Select Case Me.StartWeekOn
            Case DayOfWeek.Saturday
                TodayDayOfWeek = TodayDayOfWeek.AddDays(1)
            Case DayOfWeek.Monday
                TodayDayOfWeek = TodayDayOfWeek.AddDays(-1)
        End Select

        Dim HeaderCssClassToday As String = String.Format("timesheet-day-radgrid-column-{0}-today", Me.ShowCommentsUsing)

        Select Case TodayDayOfWeek.DayOfWeek

            Case DayOfWeek.Sunday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Monday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Tuesday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Wednesday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Thursday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Friday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").HeaderStyle.CssClass = HeaderCssClassToday

            Case DayOfWeek.Saturday

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").HeaderStyle.CssClass = HeaderCssClassToday

        End Select

    End Sub
    Private Sub RadGridTimesheetNew_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTimesheetNew.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        If Me.ValidateEmployeeCode(Me.txtEmpCode.Text) = False Then Exit Sub
        If ValidDate() = False Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then

            index = e.Item.ItemIndex

        Else

            Exit Sub

        End If

        If index = -1 Then 'command item

            MiscFN.SavePageSize(Me.RadGridTimesheetNew.ID, Me.RadGridTimesheetNew.PageSize)

        End If

        Select Case e.CommandName
            Case "Page"

                PreserveHeaderRowSelectorsAfterPostback()

            Case "ExpandCollapse"

                If (Me.DropGroupBy.SelectedIndex <> -1) Then

                    Dim groupHeaders As List(Of GridItem) = Me.RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

                    Dim captions As List(Of String) = (From g In groupHeaders
                                                       Where g.Expanded = False
                                                       Select g.Cells(1).Text).ToList()

                    If (e.Item.Expanded) Then

                        captions.Add(e.Item.Cells(1).Text)

                    Else

                        If (captions.Contains(e.Item.Cells(1).Text)) Then

                            captions.Remove(e.Item.Cells(1).Text)

                        End If

                    End If

                    Me.CollapsedHeaders.GroupName = DropGroupBy.SelectedItem.Text
                    Me.CollapsedHeaders.GroupCaptions = captions

                End If
            Case "NewRowCancel"

                Me.SetLookUps()
                Me.ClearAddNewTextboxes()

            Case "NewRowCommitInsert"



            Case "AddToTimesheetTemplate"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                Dim RowFuncCat As String = String.Empty
                Dim RowJobNum As Integer = 0
                Dim RowJobCompNum As Integer = 0

                Dim Datakey As String = CurrentGridRow.GetDataKeyValue("LineIdentifier")

                Dim ar() As String
                ar = Datakey.Split("|")
                Try
                    RowFuncCat = ar(6).ToString()
                Catch ex As Exception
                    RowFuncCat = String.Empty
                End Try
                Try
                    RowJobNum = CType(ar(4), Integer)
                Catch ex As Exception
                    RowJobNum = 0
                End Try
                Try
                    RowJobCompNum = CType(ar(5), Integer)
                Catch ex As Exception
                    RowJobCompNum = 0
                End Try

                If RowJobNum > 0 AndAlso RowJobCompNum > 0 AndAlso RowFuncCat <> String.Empty Then

                    Dim tt As New wvTimeSheet.TimeSheetTemplate()
                    tt.SaveToTemplate(RowJobNum, RowJobCompNum, RowFuncCat, String.Empty, String.Empty)

                End If

            Case RadGridTimesheetNew.DeleteCommandName, "RowDelete"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                DeleteGridRow(CurrentGridRow, index)

            Case "ViewDetails"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                Dim Datakey As String = CurrentGridRow.GetDataKeyValue("LineIdentifier")
                Dim ar() As String
                ar = Datakey.Split("|")

                'Used to show details:
                Dim JobNum As Integer = 0
                Dim JobComp As Integer = 0
                Try
                    JobNum = CType(ar(4), Integer)
                Catch ex As Exception
                    JobNum = 0
                End Try
                Try
                    JobComp = CType(ar(5), Integer)
                Catch ex As Exception
                    JobComp = 0
                End Try
                If JobNum = 0 Or JobComp = 0 Then
                    Exit Sub
                End If

                Dim FncCode As String = ar(6).ToString()
                Me.OpenWindow("Timesheet Details", "Timesheet_Details.aspx?j=" & JobNum.ToString() & "&jc=" & JobComp.ToString() & "&fn= " & FncCode & "&emp=" & Me.TimesheetEmpCode, 610, 945)
                Dim PreviousPageIndex As Integer = Me.RadGridTimesheetNew.CurrentPageIndex
                Me.CurrentGridPageIndex = PreviousPageIndex
                Me.RadGridTimesheetNew.Rebind()

            Case "StopStopwatch"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                Dim Datakey As String = CType(CurrentGridRow.FindControl(e.CommandArgument & "Datakey"), HiddenField).Value
                Dim ar() As String
                Dim EtId As Integer = 0
                Dim EtDtlId As Integer = 0
                Dim TimeType As String = String.Empty
                Dim ClientCommentRequired As Boolean = False

                ar = Datakey.Split("|")

                Try

                    EtId = ar(7)

                Catch ex As Exception

                    EtId = 0

                End Try
                Try

                    EtDtlId = ar(8)

                Catch ex As Exception

                    EtDtlId = 0

                End Try
                Try

                    TimeType = ar(10).ToString()

                Catch ex As Exception

                    TimeType = String.Empty

                End Try

                If EtId > 0 And EtDtlId > 0 Then

                    Dim t As New cTimeSheet(Session("ConnString"))
                    Dim full As String = String.Empty
                    Dim abbr As String = String.Empty
                    Dim Comment As String = String.Empty
                    Dim CommentTextbox As New System.Web.UI.WebControls.TextBox
                    Dim Hrs As Double = 0.0
                    Dim m As String = String.Empty
                    Dim Stopped As Boolean = False

                    t.GetDayNameStrings(CType(ar(9), Date), abbr, full, Me.StartWeekOn)

                    CommentTextbox = CType(CurrentGridRow.FindControl(abbr & "TextBoxComment"), TextBox)

                    If Not CommentTextbox Is Nothing Then

                        Comment = CommentTextbox.Text.Trim()

                    End If
                    If ClientCommentRequired = True AndAlso TimeType = "D" AndAlso String.IsNullOrWhiteSpace(Comment) Then

                        Me.ShowMessage("Please enter a comment.")
                        Exit Sub

                    End If

                    Stopped = AdvantageFramework.Timesheet.StopwatchStop(Session("ConnString"), Session("UserCode"), Session("EmpCode"), EtId, EtDtlId, Hrs, Comment, m)

                    If Stopped = True Then

                        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                        oTS.DeleteMissingTimeDtl(Me.TimesheetEmpCode)

                        Me.ProcessMissingTime(Me.TimesheetEmpCode, CType(ar(9), Date))

                        If m.Trim() <> "" Then

                            Me.ShowMessage(m)

                        End If

                        Me.OpenTimesheetStopwatchNotificationWindow()

                    Else

                        Me.ShowMessage(m)
                        Exit Sub

                    End If

                End If
            Case "StartStopwatch"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                Dim Datakey As String = CType(CurrentGridRow.FindControl(e.CommandArgument & "Datakey"), HiddenField).Value
                Dim dataKeyArray() As String
                Dim EtId As Integer = 0
                Dim EtDtlId As Integer = 0

                dataKeyArray = Datakey.Split("|")

                Try

                    EtId = dataKeyArray(7)

                Catch ex As Exception

                    EtId = 0

                End Try
                Try

                    EtDtlId = dataKeyArray(8)

                Catch ex As Exception

                    EtDtlId = 0

                End Try
                If EtId = 0 And EtDtlId = 0 Then

                    Dim DoW As DayOfWeek
                    Dim DoWString As String = String.Empty
                    Dim HrsTb As TextBox
                    Dim HrsVal As Decimal = 0.0

                    Select Case e.CommandArgument
                        Case "Sun"

                            DoW = DayOfWeek.Sunday
                            DoWString = "Sunday"

                        Case "Mon"

                            DoW = DayOfWeek.Monday
                            DoWString = "Monday"

                        Case "Tue"

                            DoW = DayOfWeek.Tuesday
                            DoWString = "Tuesday"

                        Case "Wed"

                            DoW = DayOfWeek.Wednesday
                            DoWString = "Wednesday"

                        Case "Thu"

                            DoW = DayOfWeek.Thursday
                            DoWString = "Thursday"

                        Case "Fri"

                            DoW = DayOfWeek.Friday
                            DoWString = "Friday"

                        Case "Sat"

                            DoW = DayOfWeek.Saturday
                            DoWString = "Saturday"

                    End Select

                    HrsTb = CType(CurrentGridRow.FindControl("Txt" & DoWString), TextBox)
                    If IsNumeric(HrsTb.Text) = False Then

                        HrsVal = 0.0

                    Else

                        HrsVal = CType(HrsTb.Text, Decimal)

                    End If

                    HrsTb.Text = HrsVal

                    Dim returnValue As String = Me.SaveTime(Datakey, HrsTb.ClientID, HrsVal, True)

                    If returnValue.IndexOf("SUCCESS") > -1 Then

                        Dim returnValueArray() As String

                        returnValueArray = returnValue.Split("|")
                        EtId = returnValueArray(1)
                        EtDtlId = returnValueArray(2)

                    End If

                End If

                Dim errorMessage As String = String.Empty
                Dim Started As Boolean = AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), EtId, EtDtlId, errorMessage)

                If EtId > 0 And EtDtlId > 0 Then

                    If Started = True Then

                        If errorMessage <> "" Then

                            Me.ShowMessage(errorMessage)

                        End If

                        Me.RadGridTimesheetNew.Rebind()
                        Me.OpenTimesheetStopwatchNotificationWindow()

                    Else

                        Me.ShowMessage(errorMessage)

                    End If

                End If

            Case "CommentsView"

                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then

                    Dim ts As New wvTimeSheet.cTimeSheet(_Session.ConnectionString)
                    Dim StartOfWeek As Date = ts.FirstDayOfWeek(Me.RadDatePickerStartDate.SelectedDate)
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridTimesheetNew.Items(index), Telerik.Web.UI.GridDataItem)
                    Dim commentView As New TimesheetCommentView
                    Dim timeSheet As New cTimeSheet(Session("ConnString"))
                    Dim Datakey As String = CurrentGridRow.GetDataKeyValue("LineIdentifier")
                    Dim s As String = String.Empty
                    Dim queryString As New AdvantageFramework.Web.QueryString()

                    _CurrentTimesheet = Nothing
                    _CurrentTimesheet = AdvantageFramework.Timesheet.GetTimeSheet(Session("ConnString"), Session("UserCode"), Me.txtEmpCode.Text, Me.TimesheetStartDate, Me.TimesheetEndDate, , s)
                    commentView = timeSheet.GetCommentViewFromTimesheetLine(_CurrentTimesheet, Me.TimesheetStartDate, Datakey)
                    commentView.ToSession()

                    With queryString

                        .Page = "Timesheet_CommentsView.aspx"
                        .EmployeeCode = Me.txtEmpCode.Text.Trim()
                        .StartDate = StartOfWeek.ToShortDateString()
                        .Add("Display", Me.DaysToDisplay.ToString())
                        .Add("Type", "Update")
                        .Add("caller", "Timesheet")

                        If Me.RadComboBoxDayToShow.SelectedIndex > 1 Then 'still needed to set js window size

                            .Add("single", "1")

                        Else

                            .Add("single", "0")

                        End If

                        .Build()

                    End With

                    If Me.RadComboBoxDayToShow.SelectedIndex > 1 Then

                        Session("TimesheetMain_SingleViewDayOfWeek") = Me.RadComboBoxDayToShow.SelectedValue
                        Session("TimesheetCommentView_SingleViewDayOfWeek") = Me.RadComboBoxDayToShow.SelectedValue

                    Else

                        Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
                        Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing

                    End If

                    Me.OpenWindow(String.Empty, queryString.ToString(True))

                End If

            Case "Sort"

                PreserveHeaderRowSelectorsAfterPostback()

        End Select
    End Sub

    Private Function FilterTimesheetLines() As List(Of AdvantageFramework.Timesheet.TimesheetLine)
        Dim Lines As List(Of AdvantageFramework.Timesheet.TimesheetLine) = Nothing
        Dim Trigger As String = DayToShow
        Lines = New List(Of AdvantageFramework.Timesheet.TimesheetLine)()
        For LineIndex = 0 To Me.CurrentTimesheet.Count - 1
            If (Me.IsSingleDayView AndAlso Me.RepeatRowForAllDays = False) Then
                If (Me.CurrentTimesheet.Item(LineIndex).TotalHours > 0) Then
                    Lines.Add(Me.CurrentTimesheet.Item(LineIndex))
                End If
            Else
                Lines.Add(Me.CurrentTimesheet.Item(LineIndex))
            End If

        Next

        Return Lines
    End Function

    Private Sub GetCVDatakeyData(ByRef GridRow As Telerik.Web.UI.GridDataItem, ByVal [Date] As Date, ByVal DayIteration As Integer,
                                 ByRef EtId As Integer, ByRef EtDtlId As Integer, ByRef EditFlag As Integer, ByRef TimeType As String,
                                 ByRef Hours As Double, ByRef HasStopWatch As Boolean,
                                 Optional ByVal ErrorMessage As String = "")
        Dim DayPrefix As String = String.Empty
        Dim Day As String = String.Empty
        Select Case DayIteration
            Case 0
                DayPrefix = "Sun"
                Day = "Sunday"
            Case 1
                DayPrefix = "Mon"
                Day = "Monday"
            Case 2
                DayPrefix = "Tue"
                Day = "Tuesday"
            Case 3
                DayPrefix = "Wed"
                Day = "Wednesday"
            Case 4
                DayPrefix = "Thu"
                Day = "Thursday"
            Case 5
                DayPrefix = "Fri"
                Day = "Friday"
            Case 6
                DayPrefix = "Sat"
                Day = "Saturday"
        End Select

        Dim Datakey As String = CType(GridRow.FindControl(DayPrefix & "Datakey"), HiddenField).Value
        Dim JobNumber As Integer = 0

        Dim dataKeyArray() As String
        dataKeyArray = Datakey.Split("|")

        If IsNumeric(dataKeyArray(7)) = True Then
            EtId = dataKeyArray(7)
        Else
            EtId = 0
        End If
        If IsNumeric(dataKeyArray(8)) = True Then
            EtDtlId = dataKeyArray(8)
        Else
            EtDtlId = 0
        End If
        If IsNumeric(dataKeyArray(11)) = True Then
            EditFlag = dataKeyArray(11)
        Else
            EditFlag = 0
        End If
        If dataKeyArray(10).ToString().Trim() <> String.Empty Then
            TimeType = dataKeyArray(10).ToString().Trim()
        Else
            If IsNumeric(dataKeyArray(5)) = True Then
                If CType(dataKeyArray(5), Integer) > 0 Then
                    TimeType = "D"
                Else
                    TimeType = "N"
                End If
            End If
        End If
        If IsNumeric(dataKeyArray(14)) = True Then
            Hours = dataKeyArray(14)
        Else
            Hours = CType(0, Double)
        End If

        Dim StopwatchImageButton As System.Web.UI.WebControls.ImageButton = CType(GridRow.FindControl(DayPrefix & "StopWatchImageButton"), ImageButton)
        If StopwatchImageButton.Visible = True And StopwatchImageButton.ImageUrl.IndexOf("stopwatch2") > -1 Then
            HasStopWatch = True
        End If

    End Sub

    Public Sub PreserveHeaderRowSelectorsAfterPostback()

        Dim templateStringBuilder As New System.Text.StringBuilder()

        templateStringBuilder.AppendLine("$(document).ready(function () {{")
        ' templateStringBuilder.AppendLine("alert('PreserveHeaderRowSelectorsAfterPostback()');")
        templateStringBuilder.AppendLine("var timesheetSelectorScope = angular.element($('#TextBox_ClientCode')).scope();")
        templateStringBuilder.AppendLine("timesheetSelectorScope.ClientCode = '{0}'; timesheetSelectorScope.DivisionCode = '{1}'; timesheetSelectorScope.ProductCode = '{2}'; timesheetSelectorScope.JobCode = '{3}'; timesheetSelectorScope.ComponentCode = '{4}';")
        templateStringBuilder.AppendLine("timesheetSelectorScope.$apply()")
        templateStringBuilder.AppendLine("}});")

        Try

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PreserveHeaderRowSelectorsAfterPostback", String.Format(templateStringBuilder.ToString(), TextBox_ClientCode.Text.Trim(), Me.TextBox_DivisionCode.Text.Trim(), Me.TextBox_ProductCode.Text.Trim(), Me.TextBox_JobCode.Text.Trim(), Me.TextBox_ComponentCode.Text.Trim()), True)

        Catch ex As Exception
        End Try

    End Sub

    Public Sub InitializeAngularSettings()
        Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
            SunClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(0))
            MonClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(1))
            TueClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(2))
            WedClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(3))
            ThuClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(4))
            FriClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(5))
            SatClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(6))

            Dim SunActive As Boolean = SunClosedPP = False AndAlso SunPend = False
            Dim MonActive As Boolean = MonClosedPP = False AndAlso MonPend = False
            Dim TueActive As Boolean = TueClosedPP = False AndAlso TuePend = False
            Dim WedActive As Boolean = WedClosedPP = False AndAlso WedPend = False
            Dim ThuActive As Boolean = ThuClosedPP = False AndAlso ThuPend = False
            Dim FriActive As Boolean = FriClosedPP = False AndAlso FriPend = False
            Dim SatActive As Boolean = SatClosedPP = False AndAlso SatPend = False


            Dim templateStringBuilder As New System.Text.StringBuilder()

            templateStringBuilder.AppendLine("$(document).ready(function () {{")
            ' templateStringBuilder.AppendLine("  setTimeout(function () {{")
            templateStringBuilder.AppendLine("var timesheetSelectorScope = angular.element($('#TextBox_ClientCode')).scope();")
            'templateStringBuilder.AppendLine("timesheetSelectorScope.SundayActive = {0}; timesheetSelectorScope.MondayActive = {1}; timesheetSelectorScope.TuesdayActive = {2}; timesheetSelectorScope.WednesdayActive = {3}; timesheetSelectorScope.ThursdayActive = {4};timesheetSelectorScope.FridayActive = {5}; timesheetSelectorScope.SaturdayActive = {6}; timesheetSelectorScope.currentSecurityModule = {7}; ")
            templateStringBuilder.AppendLine("timesheetSelectorScope.currentSecurityModule = {7}; ")
            templateStringBuilder.AppendLine("timesheetSelectorScope.$apply();")
            templateStringBuilder.AppendLine("timesheetSelectorScope.setDayVisibility();")
            ' templateStringBuilder.AppendLine(", 1000}});")
            templateStringBuilder.AppendLine("}});")

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "InitializeAngularSettings", String.Format(templateStringBuilder.ToString(), (SunActive).ToString.ToLower, (MonActive).ToString.ToLower, (TueActive).ToString.ToLower, (WedActive).ToString.ToLower, (ThuActive).ToString.ToLower, (FriActive).ToString.ToLower, (SatActive).ToString.ToLower, Me.SecurityModule), True)
        End If
    End Sub

    Private Sub SetGridDayHeaders()

        If Me.CurrentTimesheet IsNot Nothing Then

            Dim header As GridHeaderItem = TryCast(RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)

            If header IsNot Nothing Then

                Dim Date1 As Date = Me.TimesheetStartDate
                Dim Date2 As Date = Me.TimesheetStartDate.AddDays(1)
                Dim Date3 As Date = Me.TimesheetStartDate.AddDays(2)
                Dim Date4 As Date = Me.TimesheetStartDate.AddDays(3)
                Dim Date5 As Date = Me.TimesheetStartDate.AddDays(4)
                Dim Date6 As Date = Me.TimesheetStartDate.AddDays(5)
                Dim Date7 As Date = Me.TimesheetStartDate.AddDays(6)

                Me.SetApprovalHeaderLabel(Date1,
                                      CType(header.FindControl("LabelSunApproval"), Label), CType(header.FindControl("ImageButtonSunApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageSunPostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date2,
                                      CType(header.FindControl("LabelMonApproval"), Label), CType(header.FindControl("ImageButtonMonApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageMonPostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date3,
                                      CType(header.FindControl("LabelTueApproval"), Label), CType(header.FindControl("ImageButtonTueApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageTuePostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date4,
                                      CType(header.FindControl("LabelWedApproval"), Label), CType(header.FindControl("ImageButtonWedApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageWedPostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date5,
                                      CType(header.FindControl("LabelThuApproval"), Label), CType(header.FindControl("ImageButtonThuApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageThuPostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date6,
                                      CType(header.FindControl("LabelFriApproval"), Label), CType(header.FindControl("ImageButtonFriApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageFriPostPeriodClosed"), WebControls.Image))
                Me.SetApprovalHeaderLabel(Date7,
                                      CType(header.FindControl("LabelSatApproval"), Label), CType(header.FindControl("ImageButtonSatApprovalComment"), ImageButton),
                                      CType(header.FindControl("ImageSatPostPeriodClosed"), WebControls.Image))

                Dim lg As New LoGlo()

                CType(header.FindControl("LabelSunHeader"), Label).Text = lg.TimesheetHeader(Date1, False)
                CType(header.FindControl("LabelMonHeader"), Label).Text = lg.TimesheetHeader(Date2, False)
                CType(header.FindControl("LabelTueHeader"), Label).Text = lg.TimesheetHeader(Date3, False)
                CType(header.FindControl("LabelWedHeader"), Label).Text = lg.TimesheetHeader(Date4, False)
                CType(header.FindControl("LabelThuHeader"), Label).Text = lg.TimesheetHeader(Date5, False)
                CType(header.FindControl("LabelFriHeader"), Label).Text = lg.TimesheetHeader(Date6, False)
                CType(header.FindControl("LabelSatHeader"), Label).Text = lg.TimesheetHeader(Date7, False)

                CType(header.FindControl("HiddenFieldSunDate"), HiddenField).Value = Date1.ToShortDateString()
                CType(header.FindControl("HiddenFieldSatDate"), HiddenField).Value = Date2.ToShortDateString()
                CType(header.FindControl("HiddenFieldTueDate"), HiddenField).Value = Date3.ToShortDateString()
                CType(header.FindControl("HiddenFieldWedDate"), HiddenField).Value = Date4.ToShortDateString()
                CType(header.FindControl("HiddenFieldThuDate"), HiddenField).Value = Date5.ToShortDateString()
                CType(header.FindControl("HiddenFieldFriDate"), HiddenField).Value = Date6.ToShortDateString()
                CType(header.FindControl("HiddenFieldSatDate"), HiddenField).Value = Date7.ToShortDateString()

            End If

        End If

    End Sub
    Private Sub SetGridDescriptionHeaders()
        If Not Me.CurrentTimesheet Is Nothing Then
            Dim DaysToShow As Integer = 0
            Dim StartWeekOn As String = String.Empty
            Dim ShowCommentUsing As String = String.Empty
            Dim DivisionLabel As String = String.Empty
            Dim ProductLabel As String = String.Empty
            Dim ProductCategoryLabel As String = String.Empty
            Dim JobLabel As String = String.Empty
            Dim JobComponentLabel As String = String.Empty
            Dim FunctionCategoryLabel As String = String.Empty

            Dim connectionString As New cTimeSheet(Session("ConnString"))
            Dim errorMessage As String = String.Empty
            If connectionString.GetTimesheetSettings(Session("UserCode"), DaysToShow, StartWeekOn, ShowCommentUsing,
                            DivisionLabel, ProductLabel, ProductCategoryLabel, JobLabel, JobComponentLabel, FunctionCategoryLabel, errorMessage) = True Then

                Dim header As GridHeaderItem = TryCast(RadGridTimesheetNew.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
                If Not header Is Nothing Then

                    CType(header("GridTemplateColumnDivision").Controls(0), LinkButton).Text = DivisionLabel & " Code"
                    CType(header("GridTemplateColumnProduct").Controls(0), LinkButton).Text = ProductLabel & " Code"
                    CType(header("GridTemplateColumnDivisionDesc").Controls(0), LinkButton).Text = DivisionLabel & " Name"
                    CType(header("GridTemplateColumnProductDesc").Controls(0), LinkButton).Text = ProductLabel & " Name"
                    CType(header("GridTemplateColumnJobNumber").Controls(0), LinkButton).Text = JobLabel
                    CType(header("GridTemplateColumnJobDescription").Controls(0), LinkButton).Text = JobLabel & " Description"
                    CType(header("GridTemplateColumnJobComponentNumber").Controls(0), LinkButton).Text = JobComponentLabel
                    CType(header("GridTemplateColumnJobComponentDescription").Controls(0), LinkButton).Text = JobComponentLabel & " Description"
                    CType(header("GridBoundColumnProductCategory").Controls(0), System.Web.UI.LiteralControl).Text = ProductCategoryLabel
                    CType(header("GridTemplateColumnFunctionCategory").Controls(0), LinkButton).Text = FunctionCategoryLabel
                    CType(header("GridBoundColumnFunctionCategoryDesc").Controls(0), System.Web.UI.LiteralControl).Text = FunctionCategoryLabel + " Desc"
                End If
            End If
        End If
    End Sub

    Private Sub SetApprovalHeaderLabel(ByVal dt As Date, ByRef ApprovalLabel As System.Web.UI.WebControls.Label, ByRef ApprovalCommentImageButton As System.Web.UI.WebControls.ImageButton, ByRef PostPeriodClosedImage As WebControls.Image)

        Dim agency As cAgency = New cAgency(CStr(Session("ConnString")))
        Dim timeSheetDay As AdvantageFramework.Timesheet._TimesheetDay
        timeSheetDay = AdvantageFramework.Timesheet.GetTimesheetDayByDate(Me.CurrentTimesheet, dt)

        If timeSheetDay IsNot Nothing Then

            ApprovalLabel.Text = String.Empty
            ApprovalLabel.Visible = False
            ApprovalCommentImageButton.Visible = False
            PostPeriodClosedImage.Visible = False

            If agency.CheckTimeSupervisorApproval() = True Then

                Dim t As New cTimeSheet(Session("ConnString"))

                If timeSheetDay.IsApproved = True Then

                    ApprovalLabel.Text = "Approved<br />"
                    ApprovalLabel.Visible = True

                End If
                If timeSheetDay.IsPendingApproval = True Then

                    ApprovalLabel.Text = "Pending<br />"
                    ApprovalLabel.Visible = True

                End If
                If timeSheetDay.IsDenied = True Then

                    ApprovalLabel.Text = "Denied<br />"
                    ApprovalLabel.Visible = True

                End If
                If ApprovalLabel.Visible = True Then

                    With ApprovalCommentImageButton

                        .Visible = True
                        .OnClientClick = "OpenRadWindow('','popcomments.aspx?empcode=" & Me.TimesheetEmpCode & "&type=timeapproval&id=" & Me.TimesheetEmpCode & "|" & dt.ToShortDateString() & "',0,0,false);return false;"

                    End With

                End If

            End If

            PostPeriodClosedImage.Visible = timeSheetDay.PostPeriodIsClosed

        End If

    End Sub
    Private Function DeleteGridRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem, ByVal TheGridRowIndex As Integer, Optional ByVal RebindGrid As Boolean = True) As String
        If ValidDate() = False Then Exit Function

        Dim DeleteSun As Boolean = False
        Dim DeleteMon As Boolean = False
        Dim DeleteTue As Boolean = False
        Dim DeleteWed As Boolean = False
        Dim DeleteThu As Boolean = False
        Dim DeleteFri As Boolean = False
        Dim DeleteSat As Boolean = False

        Dim ET_ID As Integer = 0
        Dim ETD_ID As Integer = 0
        Dim TimeType As String = String.Empty
        Dim TheDay As String = String.Empty
        Dim dayPrefix As String = String.Empty
        Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        Dim DayCount As Integer = 0

        Me.IsSingleDayView = Me.RadComboBoxDayToShow.SelectedIndex > 1

        If Me.IsSingleDayView = False AndAlso Session("TimesheetMain_SingleViewDayOfWeek") IsNot Nothing Then
            If CType(Session("TimesheetMain_SingleViewDayOfWeek"), Integer) > 0 Then
                Me.IsSingleDayView = True
            End If
        End If
        If Me.IsSingleDayView = False Then
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = False) OrElse
                (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = False) OrElse
                (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = False) OrElse
                (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = False) OrElse
                (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = False) Then
                Me.IsSingleDayView = True
            End If
        End If
        If Me.IsSingleDayView = False Then
            DeleteSun = True
            DeleteMon = True
            DeleteTue = True
            DeleteWed = True
            DeleteThu = True
            DeleteFri = True
            DeleteSat = True
        Else
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = True) Then

                DeleteSun = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True) Then

                DeleteMon = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True) Then

                DeleteTue = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True) Then

                DeleteWed = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True) Then

                DeleteThu = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True) Then

                DeleteFri = True

            End If
            If (Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = True) Then

                DeleteSat = True

            End If

        End If

        'Sunday
        If DeleteSun = True Then

            TheDay = "Sunday"
            dayPrefix = "Sun"
            DayCount = 0
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        'Monday
        If DeleteMon = True Then

            TheDay = "Monday"
            dayPrefix = "Mon"
            DayCount = 1
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        'Tuesday
        If DeleteTue = True Then

            TheDay = "Tuesday"
            dayPrefix = "Tue"
            DayCount = 2
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        'Wednesday
        If DeleteWed = True Then

            TheDay = "Wednesday"
            dayPrefix = "Wed"
            DayCount = 3
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        'Thursday
        If DeleteThu = True Then

            TheDay = "Thursday"
            dayPrefix = "Thu"
            DayCount = 4
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        'Friday
        If DeleteFri = True Then

            TheDay = "Friday"
            dayPrefix = "Fri"
            DayCount = 5
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If
        If DeleteSat = True Then

            'Saturday
            TheDay = "Saturday"
            dayPrefix = "Sat"
            DayCount = 6
            Me.GetInfoForDelete(CType(TheGridRow.FindControl(dayPrefix & "Datakey"), HiddenField).Value, ET_ID, ETD_ID, TimeType)
            If ET_ID > 0 And ETD_ID > 0 Then
                If timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or timeSheet.CheckEditStatus(ET_ID, ETD_ID) = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                    timeSheet.DeleteTime(ET_ID, ETD_ID, TimeType)
                End If
            End If

        End If

        If (RebindGrid) Then
            Me.RadGridTimesheetNew.Rebind()
        End If
    End Function

    Private Sub GetInfoForDelete(ByVal Datakey As String, ByRef EtId As Integer, ByRef EtDtlId As Integer, ByRef TimeType As String)
        Dim dataKeyArray() As String
        dataKeyArray = Datakey.Split("|")
        Try
            If IsNumeric(dataKeyArray(7)) = True Then
                EtId = CType(dataKeyArray(7), Integer)
            Else
                EtId = 0
            End If
        Catch ex As Exception
            EtId = 0
        End Try
        Try
            If IsNumeric(dataKeyArray(8)) = True Then
                EtDtlId = CType(dataKeyArray(8), Integer)
            Else
                EtDtlId = 0
            End If
        Catch ex As Exception
            EtDtlId = 0
        End Try
        Try
            TimeType = dataKeyArray(10)
        Catch ex As Exception
            TimeType = "D"
        End Try
    End Sub

    Private Function EditFlagMessage(ByVal TheDay As String, ByVal EditFlag As Integer) As String
        Select Case EditFlag
            Case 1
                Return "Item has been billed"
            Case 2
                Return "Item has been summarizedYou must insert a new row to adjust your time" '"The item is a summary valueYou must insert a new row to adjust your time."
                'Case 3
                '    Return TheDay & " has been billed"
            Case 4
                Return "Item is in billing"
            Case 5
                Return "Item is pending"
            Case 6
                Return "Item has been approved"
        End Select
    End Function

    Private Sub LoadFunctions()
        Dim dropDowns As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.DtFunctions = dropDowns.GetFunctionsByEmpCodeDatatable(Session("EmpCode"))
    End Sub

    Private Sub LoadTimeCategories()
        Dim dropDowns As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.DtTimeCategories = dropDowns.GetCategoriesDT()
    End Sub

    Private _ResetDayToShowRadComboBox As Boolean = False
    Private _DayOfTheWeekFromQuerystring As DayOfWeek

    Private Sub SetDayColumnsToShow()

        Try

            Dim ForceLoadSingle As Boolean = False

            'This will allow only the session variable to get user off of single day view...
            If Not Session("TimesheetMain_SingleViewDayOfWeek") Is Nothing Then

                If IsNumeric(Session("TimesheetMain_SingleViewDayOfWeek")) = True Then

                    Me.DayToShow = Session("TimesheetMain_SingleViewDayOfWeek").ToString()

                    If Me.FromDesktopObject = True AndAlso Request.QueryString("tsdate") IsNot Nothing Then

                        Me._DayOfTheWeekFromQuerystring = CType(Request.QueryString("tsdate"), Date).DayOfWeek
                        Me._ResetDayToShowRadComboBox = True

                        Select Case StartWeekOn
                            Case DayOfWeek.Monday

                                If Me._DayOfTheWeekFromQuerystring = 0 Then

                                    Me._DayOfTheWeekFromQuerystring = 6

                                Else

                                    Me._DayOfTheWeekFromQuerystring = Me._DayOfTheWeekFromQuerystring - 1

                                End If

                            Case DayOfWeek.Saturday

                                If Me._DayOfTheWeekFromQuerystring = 6 Then

                                    Me._DayOfTheWeekFromQuerystring = 0

                                Else

                                    Me._DayOfTheWeekFromQuerystring = Me._DayOfTheWeekFromQuerystring + 1

                                End If

                        End Select

                    End If

                    ForceLoadSingle = True
                    IsSingleDayView = True

                End If

            End If

            'for default user setting when first coming in
            If Not Me.IsPostBack And Not Me.IsCallback Then

                If Me.DaysToDisplay = 1 And ForceLoadSingle = False And Session("TimesheetMain_UserHasMadeASelection") Is Nothing Then

                    If RadComboBoxDayToShow.Items IsNot Nothing AndAlso RadComboBoxDayToShow.Items.Count > 0 Then

                        For Each item As RadComboBoxItem In RadComboBoxDayToShow.Items

                            If item.Text.Contains(cEmployee.TimeZoneToday.DayOfWeek.ToString()) = True Then

                                item.Selected = True
                                Exit For

                            End If

                        Next
                    End If
                    If RadComboBoxDayToShow.SelectedItem IsNot Nothing AndAlso IsNumeric(RadComboBoxDayToShow.SelectedItem.Value) = True Then

                        Me.DayToShow = CType(RadComboBoxDayToShow.SelectedItem.Value, Integer)

                    End If

                    IsSingleDayView = True

                End If

            End If

            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = False
            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = False

            If Me.DaysToDisplay = 1 OrElse ForceLoadSingle = True Then

                IsSingleDayView = True
                Dim DayToShowInt As Integer = CType(Me.DayToShow, Integer)

                If IsNumeric(Me.DayToShow) = True Then

                    If Me.FromDesktopObject = True Then

                        Select Case StartWeekOn
                            Case DayOfWeek.Monday

                                If DayToShowInt = 0 Then

                                    DayToShowInt = 6

                                Else

                                    DayToShowInt = DayToShowInt - 1

                                End If

                            Case DayOfWeek.Saturday

                                If DayToShowInt = 6 Then

                                    DayToShowInt = 0

                                Else

                                    DayToShowInt = DayToShowInt + 1

                                End If

                        End Select


                    End If

                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDayToShow, Me.DayToShow, False)
                    SetDayToShowSession()

                    Select Case DayToShowInt

                        Case 0

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Sunday)

                        Case 1

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Monday)

                        Case 2

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Tuesday)

                        Case 3

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Wednesday)

                        Case 4

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Thursday)

                        Case 5

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Friday)

                        Case 6

                            Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = True
                            Me.AddNewRowColumn_HideAllExcept(DayOfWeek.Saturday)

                    End Select

                Else

                    IsSingleDayView = False

                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True
                    Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = True

                    Me.AddNewRowColumn_ShowAll7()

                End If

            ElseIf Me.DaysToDisplay = 5 Then

                Select Case Me.StartWeekOn
                    Case DayOfWeek.Saturday

                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = True

                    Case DayOfWeek.Sunday

                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True

                    Case DayOfWeek.Monday

                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                        Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True

                End Select

                Me.AddNewRowColumn_ShowAll5()

            ElseIf Me.DaysToDisplay = 7 Then

                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSunday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnMonday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnTuesday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnWednesday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnThursday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnFriday").Visible = True
                Me.RadGridTimesheetNew.MasterTableView.GetColumn("GridBoundColumnSaturday").Visible = True

                Me.AddNewRowColumn_ShowAll7()

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub AddNewRowColumn_HideAllExcept(ByVal Day As DayOfWeek)

        If Me.ImageButton_SaveNewRow Is Nothing Then Exit Sub

        If Me.ImageButton_SaveNewRow.Visible Then

            Me.AddNewRowColumn_HideAll()

            Select Case Day
                Case DayOfWeek.Sunday
                    Me.TextBox_NewItemSunday.Visible = True
                Case DayOfWeek.Monday

                    Me.TextBox_NewItemMonday.Visible = True
                Case DayOfWeek.Tuesday

                    Me.TextBox_NewItemTuesday.Visible = True
                Case DayOfWeek.Wednesday

                    Me.TextBox_NewItemWednesday.Visible = True
                Case DayOfWeek.Thursday

                    Me.TextBox_NewItemThursday.Visible = True
                Case DayOfWeek.Friday

                    Me.TextBox_NewItemFriday.Visible = True
                Case DayOfWeek.Saturday

                    Me.TextBox_NewItemSaturday.Visible = True
            End Select
        End If

    End Sub

    Private Sub AddNewRowColumn_HideAll()
        If (Me.RadGridTimesheetNew.MasterTableView.IsItemInserted) Then
            Me.TextBox_NewItemSunday.Visible = False
            Me.TextBox_NewItemMonday.Visible = False
            Me.TextBox_NewItemTuesday.Visible = False
            Me.TextBox_NewItemWednesday.Visible = False
            Me.TextBox_NewItemThursday.Visible = False
            Me.TextBox_NewItemFriday.Visible = False
            Me.TextBox_NewItemSaturday.Visible = False
        End If

    End Sub

    Private Sub AddNewRowColumn_ShowAll7()
        If (Me.RadGridTimesheetNew.MasterTableView.IsItemInserted) Then
            Me.TextBox_NewItemSunday.Visible = True
            Me.TextBox_NewItemMonday.Visible = True
            Me.TextBox_NewItemTuesday.Visible = True
            Me.TextBox_NewItemWednesday.Visible = True
            Me.TextBox_NewItemThursday.Visible = True
            Me.TextBox_NewItemFriday.Visible = True
            Me.TextBox_NewItemSaturday.Visible = True
        End If
    End Sub

    Private Sub AddNewRowColumn_ShowAll5()
        If (Me.RadGridTimesheetNew.MasterTableView.IsItemInserted) Then

            Me.TextBox_NewItemSunday.Visible = False
            Me.TextBox_NewItemMonday.Visible = False
            Me.TextBox_NewItemTuesday.Visible = False
            Me.TextBox_NewItemWednesday.Visible = False
            Me.TextBox_NewItemThursday.Visible = False
            Me.TextBox_NewItemFriday.Visible = False
            Me.TextBox_NewItemSaturday.Visible = False

            Select Case Me.StartWeekOn
                Case DayOfWeek.Saturday

                    Me.TextBox_NewItemTuesday.Visible = True
                    Me.TextBox_NewItemWednesday.Visible = True
                    Me.TextBox_NewItemThursday.Visible = True
                    Me.TextBox_NewItemFriday.Visible = True
                    Me.TextBox_NewItemSaturday.Visible = True

                Case DayOfWeek.Sunday

                    Me.TextBox_NewItemMonday.Visible = True
                    Me.TextBox_NewItemTuesday.Visible = True
                    Me.TextBox_NewItemWednesday.Visible = True
                    Me.TextBox_NewItemThursday.Visible = True
                    Me.TextBox_NewItemFriday.Visible = True

                Case DayOfWeek.Monday

                    Me.TextBox_NewItemSunday.Visible = True
                    Me.TextBox_NewItemMonday.Visible = True
                    Me.TextBox_NewItemTuesday.Visible = True
                    Me.TextBox_NewItemWednesday.Visible = True
                    Me.TextBox_NewItemThursday.Visible = True

            End Select

        End If
    End Sub

    Private _MissingCommentFocusSet As Boolean = False
    Private Function SetGridCell(ByRef Row As Telerik.Web.UI.GridDataItem, ByVal ColumnDate As Date, ByVal LineTotalJavascriptString As String,
                                 Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim TimesheetRow As AdvantageFramework.Timesheet.TimesheetLine
            Dim TimesheetCell As AdvantageFramework.Timesheet.TimesheetEntry
            Dim TimesheetColumn As AdvantageFramework.Timesheet._TimesheetDay

            Dim timeSheet As New cTimeSheet(Session("ConnString").ToString())
            Dim DayAbbreviation As String = String.Empty
            Dim FullDay As String = String.Empty
            Dim Pending As Boolean = False

            TimesheetRow = CType(Row.DataItem, AdvantageFramework.Timesheet.TimesheetLine)

            timeSheet.GetDayNameStrings(ColumnDate, DayAbbreviation, FullDay, Me.StartWeekOn)

            TimesheetColumn = Me.CurrentTimesheet.Days.ToList().Find(Function(value As AdvantageFramework.Timesheet._TimesheetDay)
                                                                         Return value.Date = ColumnDate
                                                                     End Function)

            Select Case ColumnDate.DayOfWeek 'compensate for locale and shifiting days to diff columns
                Case DayOfWeek.Sunday
                    Pending = Me.SunPend
                    TimesheetCell = TimesheetRow.Sunday
                Case DayOfWeek.Monday
                    Pending = Me.MonPend
                    TimesheetCell = TimesheetRow.Monday
                Case DayOfWeek.Tuesday
                    Pending = Me.TuePend
                    TimesheetCell = TimesheetRow.Tuesday
                Case DayOfWeek.Wednesday
                    Pending = Me.WedPend
                    TimesheetCell = TimesheetRow.Wednesday
                Case DayOfWeek.Thursday
                    Pending = Me.ThuPend
                    TimesheetCell = TimesheetRow.Thursday
                Case DayOfWeek.Friday
                    Pending = Me.FriPend
                    TimesheetCell = TimesheetRow.Friday
                Case DayOfWeek.Saturday
                    Pending = Me.SatPend
                    TimesheetCell = TimesheetRow.Saturday
            End Select

            Dim HoursTextbox As TextBox = CType(Row.FindControl("Txt" & FullDay), TextBox)
            Dim DivComment As HtmlControls.HtmlControl = CType(Row.FindControl(DayAbbreviation & "DivComment"), HtmlControls.HtmlControl)
            Dim CommentImageButton As System.Web.UI.WebControls.ImageButton = CType(Row.FindControl(DayAbbreviation & "ImageButtonComment"), ImageButton)
            Dim CommentTextbox As System.Web.UI.WebControls.TextBox = CType(Row.FindControl(DayAbbreviation & "TextBoxComment"), TextBox)
            Dim DatakeyHiddenField As System.Web.UI.WebControls.HiddenField = CType(Row.FindControl(DayAbbreviation & "Datakey"), HiddenField)
            Dim CannotEditDueToProcessControlImage As WebControls.Image = CType(Row.FindControl("ImageProcessControlWarning"), WebControls.Image)

            Dim PostPeriodClosed As Boolean = False
            Dim EditFlag As Integer = 0
            Dim EditType As AdvantageFramework.Timesheet.TimesheetEditType = 0
            Dim NonEditMessage As String = String.Empty
            Dim HasComments As Boolean = False

            Dim EtId As Integer = 0
            Dim EtDtlId As Integer = 0
            Dim TimeType As String = String.Empty
            Dim CellDate As String = ColumnDate.ToShortDateString()

            'set edit for time entry
            Dim CanEdit As Boolean = False
            Dim CannotEditDueToProcessingControl As Boolean = False
            Dim Hours As Double = CType(0, Double)
            Dim HasStopWatch As Boolean = False
            Dim CanDelete As Boolean = False

            Dim ClientPrefix As String = DatakeyHiddenField.ClientID.Replace("Datakey", String.Empty)
            Dim WebDataKey As String = String.Empty
            Dim CommentRequired As Boolean = False
            Dim CellShowCommentUsing As String = Me.ShowCommentsUsing

            CannotEditDueToProcessingControl = TimesheetRow.NonEditMessage.Trim() <> String.Empty

            PostPeriodClosed = TimesheetColumn.PostPeriodIsClosed

            If Not TimesheetCell Is Nothing Then

                EditFlag = TimesheetCell.EditFlag
                EditType = CType(EditFlag, AdvantageFramework.Timesheet.TimesheetEditType)
                NonEditMessage = TimesheetRow.NonEditMessage
                EtId = TimesheetCell.ETID
                EtDtlId = TimesheetCell.ETDTLID
                TimeType = TimesheetCell.TimeType
                If TimesheetCell.Comments.Trim() <> String.Empty Then
                    HasComments = True
                End If
                Hours = TimesheetCell.Hours
                HasStopWatch = TimesheetCell.HasStopwatch
                WebDataKey = TimesheetCell.WebDataKey
                CommentRequired = TimesheetCell.CommentsRequired
                CanDelete = TimesheetCell.CanDelete

            End If

            Dim dataKeyStringBuilder As New System.Text.StringBuilder
            With dataKeyStringBuilder

                .Append(ClientPrefix) '0
                .Append("|")

                If WebDataKey.Trim() <> String.Empty Then

                    .Append(WebDataKey)

                Else

                    .Append(Session("TimesheetEmpCode"))
                    .Append("|")
                    .Append(TimesheetRow.FuncCat)
                    .Append("|")
                    .Append(TimesheetRow.Dept)
                    .Append("|")
                    .Append(TimesheetRow.ProductCategory)
                    .Append("|")
                    .Append(TimesheetRow.JobNumber)
                    .Append("|")
                    .Append(TimesheetRow.JobComponentNbr)
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    .Append(ColumnDate.ToShortDateString())
                    .Append("|")
                    .Append(TimesheetRow.TimeType)
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    .Append(TimesheetRow.ClientCommentRequired.ToString().ToLower())
                    .Append("|")
                    .Append("false")
                    .Append("|")
                    .Append(Hours.ToString())

                End If

            End With

            DatakeyHiddenField.Value = dataKeyStringBuilder.ToString()

            HoursTextbox.Text = Microsoft.VisualBasic.FormatNumber(Hours, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)

            Select Case EditType
                Case AdvantageFramework.Timesheet.TimesheetEditType.Edit, AdvantageFramework.Timesheet.TimesheetEditType.Denied
                    CanEdit = True
            End Select
            If CanEdit = True And EditType = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Then
                CanEdit = False
            End If
            If CanEdit = True And CannotEditDueToProcessingControl = True Then
                CanEdit = False
            End If
            If CanEdit = True Then
                CanEdit = Not PostPeriodClosed
            End If

            If EtId = 0 And EtDtlId = 0 AndAlso Not TimesheetColumn Is Nothing Then
                If TimesheetColumn.IsApproved Or TimesheetColumn.IsPendingApproval Then
                    CanEdit = False
                End If
            End If

            HoursTextbox.Enabled = CanEdit
            CommentTextbox.Enabled = CanEdit

            CannotEditDueToProcessControlImage.Visible = CannotEditDueToProcessingControl

            Dim StopwatchImageButton As System.Web.UI.WebControls.ImageButton = CType(Row.FindControl(DayAbbreviation & "StopWatchImageButton"), ImageButton)
            StopwatchImageButton.Visible = HasStopWatch

            Dim StopwatchDiv As HtmlControls.HtmlControl = CType(Row.FindControl(DayAbbreviation & "DivStopwatch"), HtmlControls.HtmlControl)

            If HasStopWatch = True Then

                StopwatchImageButton.Visible = True
                StopwatchImageButton.CommandName = "StopStopwatch"
                StopwatchImageButton.ImageUrl = "~/Images/Icons/White/256/stopwatch2.png"
                StopwatchImageButton.ToolTip = "Stop Stopwatch"

                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StopwatchDiv, "standard-red")

            ElseIf HasStopWatch = False AndAlso ColumnDate.ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then

                StopwatchImageButton.Visible = True
                StopwatchImageButton.CommandName = "StartStopwatch"
                StopwatchImageButton.ImageUrl = "~/Images/Icons/White/256/stopwatch.png"
                StopwatchImageButton.ToolTip = "Start Stopwatch"

            Else

                StopwatchImageButton.Visible = False
                StopwatchImageButton.CommandName = "StopStopwatch"
                StopwatchImageButton.ImageUrl = "~/Images/Icons/White/256/stopwatch2.png"
                StopwatchImageButton.ToolTip = "Stop Stopwatch"

                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StopwatchDiv, "standard-red")

            End If

            If StopwatchImageButton.Visible = True Then

                StopwatchImageButton.Visible = CanEdit

                If CanEdit = False Then

                    AdvantageFramework.Web.Presentation.Controls.DivHide(StopwatchDiv)

                End If

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(StopwatchDiv)

            End If

            HoursTextbox.Attributes.Remove("onblur")
            CommentTextbox.Attributes.Remove("onblur")

            If CanEdit = True Then

                Dim CommentCheckJavasriptString As String = ""
                If TimesheetRow.ClientCommentRequired = True Then

                    CommentCheckJavasriptString = String.Format("checkForComment('{0}', '{1}');", HoursTextbox.ClientID, CommentTextbox.ClientID)

                End If

                HoursTextbox.Attributes.Add("onblur", String.Format("DataChangeSaveTime({0}, this.id, this.value, false);setFooterTotals('{1}','{2}','{3}');{4}{5}return false;",
                                                                        DatakeyHiddenField.ClientID, Me.TimesheetEmpCode, Me.TimesheetStartDate.ToShortDateString(), Me.TimesheetEndDate.ToShortDateString(), LineTotalJavascriptString, CommentCheckJavasriptString))
                CommentTextbox.Attributes.Add("onblur", String.Format("DataChangeSaveComment({0}, this.id, this.value, false);setFooterTotals('{1}','{2}','{3}');{4}{5}return false;",
                                                                          DatakeyHiddenField.ClientID, Me.TimesheetEmpCode, Me.TimesheetStartDate.ToShortDateString(), Me.TimesheetEndDate.ToShortDateString(), LineTotalJavascriptString, CommentCheckJavasriptString))


            End If

            CellShowCommentUsing = Me.ShowCommentsUsing

            If TimesheetRow.ClientCommentRequired = True Then

                CellShowCommentUsing = "textbox"

            End If

            If CellShowCommentUsing = "none" AndAlso Me.DaysToDisplay <> 1 Then

                CommentTextbox.Visible = False
                CommentImageButton.Visible = False
                AdvantageFramework.Web.Presentation.Controls.DivHide(DivComment)
                HoursTextbox.Attributes.Remove("ondblclick")

            Else

                If CellShowCommentUsing = "textbox" OrElse Me.RadComboBoxDayToShow.SelectedIndex > 1 OrElse TimesheetRow.ClientCommentRequired = True OrElse (IsNumeric(Me.DayToShow)) Then

                    If HasComments = True Then CommentTextbox.Text = TimesheetCell.Comments

                    CommentTextbox.Visible = True

                    'set text box
                    With CommentTextbox

                        If CanEdit = True AndAlso TimeType = "D" AndAlso TimesheetRow.ClientCommentRequired = True Then

                            .CssClass = "timesheet-day-comments-textbox RequiredInput"

                            If Hours <> 0.0 Then

                                If HasComments = False Then

                                    .CssClass = "timesheet-day-comments-textbox standard-red"

                                    If _MissingCommentFocusSet = False Then

                                        CommentTextbox.Focus()
                                        _MissingCommentFocusSet = True

                                    End If

                                End If

                            End If

                        Else

                            .BorderColor = Color.Empty
                            .BackColor = Color.Empty

                        End If

                        .Attributes.Remove("style")
                        .Height = New Unit(22, UnitType.Pixel)

                        If Me.RadComboBoxDayToShow.SelectedIndex = 0 Or Me.RadComboBoxDayToShow.SelectedIndex = 1 Then

                            .Attributes.Add("style", "min-width: 115px; width: 115px;")
                            .Width = New Unit(110, UnitType.Pixel)

                        Else
                            .Attributes.Add("style", "min-width: 300px; width: 300px;")
                            .Width = New Unit(300, UnitType.Pixel)

                        End If

                        If IsNumeric(Me.DayToShow) = True Then

                            .Attributes.Add("style", "min-width: 300px; width: 300px;")
                            .Width = New Unit(300, UnitType.Pixel)

                        End If

                    End With

                    If HasStopWatch = True Then

                        HoursTextbox.Enabled = False

                    End If

                Else

                    CommentTextbox.Visible = False
                    'set icon
                    With CommentImageButton

                        'If Hours = 0 Then

                        '    .Visible = True
                        '    AdvantageFramework.Web.Presentation.Controls.DivHide(DivComment)

                        'Else

                        .Visible = True

                        If CanEdit = False Then

                            .ToolTip = "Comment is locked"
                            .AlternateText = "Comment is locked"

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivComment, "standard-yellow")

                        Else

                            If HasComments = True Then

                                .ToolTip = "Edit Comment"
                                .AlternateText = "Edit Comment"

                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivComment, "standard-green")

                            Else

                                If TimesheetRow.ClientCommentRequired = True And Hours > 0 Then

                                    .ToolTip = "Comment is missing; click to add"
                                    .AlternateText = "Comment is missing; click to add"

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivComment, "standard-red")

                                Else

                                    .ToolTip = "Add Comment"
                                    .AlternateText = "Add Comment"

                                End If

                            End If

                        End If

                        .OnClientClick = String.Format("OpenCommentWindow('{0}', {1}, {2}, '{3}'); return false;",
                                                       Me.TimesheetEmpCode, DatakeyHiddenField.ClientID, CanEdit.ToString().ToLower(), DivComment.ClientID)

                        'End If

                    End With

                End If

                CommentImageButton.Visible = Not CommentTextbox.Visible

                If CommentImageButton.Visible = False Then AdvantageFramework.Web.Presentation.Controls.DivHide(DivComment)

            End If

            Me.JSArray &= "try {myArray[" & Me.ArrayCounter.ToString() & "] = '" &
                                TimesheetRow.ClientCommentRequired.ToString().ToLower() & "|" &
                                CellShowCommentUsing.ToString().ToLower() & "|" &
                                DatakeyHiddenField.ClientID & "|" &
                                HoursTextbox.ClientID & "|" &
                                CommentTextbox.ClientID & "|" &
                                CommentImageButton.ClientID &
                                "'} catch (err) {}" & Environment.NewLine

            Me.ArrayCounter += 1


            If HasStopWatch = True Then

                HoursTextbox.Enabled = False

            End If

            ErrorMessage = String.Empty
            Return True

        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function

    Private Function SaveGrid(ByVal RebindGrid As Boolean)

        Dim RowCount As Integer = Me.RadGridTimesheetNew.MasterTableView.Items.Count
        Dim msg As String = String.Empty
        If RowCount > 0 Then

            Dim EverythingSavedOK As Boolean = True
            For Each GridRow As GridDataItem In Me.RadGridTimesheetNew.MasterTableView.Items
                Dim s As String = String.Empty
                If Me.SaveGridRow(GridRow, s) = False Then
                    If s <> String.Empty Then
                        msg &= s
                        EverythingSavedOK = False
                    End If
                End If
            Next

            If EverythingSavedOK = True Then

                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                oTS.DeleteMissingTimeDtl(Me.TimesheetEmpCode)
                ProcessMissingTime(Me.TimesheetEmpCode, Me.TimesheetStartDate)

            End If

            If EverythingSavedOK = True And RebindGrid = True Then

                Me.RadGridTimesheetNew.Rebind()

            End If

            If EverythingSavedOK = False And msg.Trim() <> String.Empty Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(msg))

            End If

        Else

            Me.ShowMessage("Timesheet has no rows to save")
            Exit Function

        End If

    End Function

    Private Function CheckGridForInputErrors() As Boolean

        Return False

        'If Me.CommentsRequired = False Then Return False

        'Dim GridHasErrors As Boolean = False

        'Dim NonNumericHoursCount As Integer = 0
        'Dim HoursGreaterThan24Count As Integer = 0
        'Dim MissingCommentsCount As Integer = 0

        'Dim HoursTextBox As New TextBox
        'Dim CommentsTextBox As New System.Web.UI.WebControls.TextBox
        'Dim Day As String = String.Empty
        'Dim DayAbbr As String = String.Empty
        'Dim t As New cTimeSheet(Session("ConnString"))

        'For Each GridRow As GridDataItem In Me.RadGridTimesheetNew.MasterTableView.Items

        '    Dim RowDatakey() As String
        '    Dim RowTimeType As String = "D"
        '    Dim RowJobNum As Integer = 0
        '    Dim RowJobCompNum As Integer = 0

        '    RowDatakey = GridRow.GetDataKeyValue("LineIdentifier").ToString().Split("|")
        '    Try
        '        RowJobNum = CType(RowDatakey(4), Integer)
        '    Catch ex As Exception
        '        RowJobNum = 0
        '    End Try
        '    Try
        '        RowJobCompNum = CType(RowDatakey(5), Integer)
        '    Catch ex As Exception
        '        RowJobCompNum = 0
        '    End Try

        '    If RowJobNum = 0 And RowJobCompNum = 0 Then
        '        RowTimeType = "N"
        '    End If

        '    If RowJobNum > 0 Then

        '        If t.JobCommentRequired(RowJobNum) = False Then Return False

        '    End If

        '    For i = 0 To 6

        '        t.GetDayNameStrings(Me.TimesheetStartDate.AddDays(i), DayAbbr, Day, Me.StartWeekOn)

        '        HoursTextBox = Nothing
        '        CommentsTextBox = Nothing

        '        HoursTextBox = CType(GridRow.FindControl("Txt" & Day), TextBox)
        '        CommentsTextBox = CType(GridRow.FindControl(DayAbbr & "TextBoxComment"), TextBox)

        '        If Not HoursTextBox Is Nothing And Not CommentsTextBox Is Nothing Then

        '            If CommentsTextBox.Visible = True And CommentsTextBox.Enabled = True Then

        '                Dim HoursString As String = HoursTextBox.Text.Trim()
        '                Dim Hours As Decimal = 0.0
        '                Dim SavedHours As Decimal = 0.0
        '                Dim Comments As String = CommentsTextBox.Text.Trim()
        '                Dim HoursError As Boolean = False
        '                Dim MissingComment As Boolean = False

        '                If HoursString = String.Empty Then

        '                    HoursString = "0.00"
        '                    HoursTextBox.Text = HoursString

        '                End If

        '                If IsNumeric(HoursString) = True Then

        '                    Hours = CType(HoursString, Decimal)

        '                Else

        '                    NonNumericHoursCount += 1
        '                    HoursError = True
        '                    GridHasErrors = True

        '                End If

        '                If HoursTextBox.Enabled = True And (Hours > 24) Then

        '                    HoursGreaterThan24Count += 1
        '                    HoursError = True
        '                    GridHasErrors = True

        '                End If

        '                If Hours > 0 And Hours <= 24 And Comments = String.Empty And RowTimeType = "D" Then

        '                    MissingCommentsCount += 1
        '                    MissingComment = True
        '                    GridHasErrors = True

        '                End If


        '                If MissingComment = True Then

        '                    CommentsTextBox.BorderColor = Color.DarkRed
        '                    HoursTextBox.BorderColor = Color.DarkRed

        '                ElseIf HoursError = True Then

        '                    HoursTextBox.BorderColor = Color.DarkRed

        '                Else

        '                    CommentsTextBox.BorderColor = Color.Empty
        '                    HoursTextBox.BorderColor = Color.Empty

        '                End If

        '            End If

        '        End If

        '    Next

        'Next

        'If GridHasErrors = True Then

        '    Dim SbError As New System.Text.StringBuilder

        '    SbError.Append("Input errors detected.\n\n")

        '    If HoursGreaterThan24Count > 0 Then

        '        If HoursGreaterThan24Count = 1 Then

        '            SbError.Append("One entry has hours that is greater than 24.\n")

        '        Else

        '            SbError.Append(HoursGreaterThan24Count.ToString())
        '            SbError.Append(" entries have hours that are greater than 24.\n")

        '        End If

        '    End If
        '    If NonNumericHoursCount > 0 Then

        '        If NonNumericHoursCount = 1 Then

        '            SbError.Append("One entry has hours that is not a number.\n")

        '        Else

        '            SbError.Append(NonNumericHoursCount.ToString())
        '            SbError.Append(" entries have hours that are not a number.\n")

        '        End If

        '    End If
        '    If MissingCommentsCount > 0 Then

        '        If MissingCommentsCount = 1 Then

        '            SbError.Append("One entry is missing comments.\n")

        '        Else

        '            SbError.Append(MissingCommentsCount.ToString())
        '            SbError.Append(" entries are missing comments.\n")

        '        End If

        '    End If

        '    Me.ShowMessage(SbError.ToString())

        'End If

        'Return GridHasErrors

    End Function

#Region " Code Blocks for Grid"

    Public Function SetDelete(ByRef Thisline As AdvantageFramework.Timesheet.TimesheetLine) As Boolean
        If Not Thisline Is Nothing Then
            If Not Thisline.Monday Is Nothing Then
                If MonClosedPP = True And Thisline.Monday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Tuesday Is Nothing Then
                If TueClosedPP = True And Thisline.Tuesday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Wednesday Is Nothing Then
                If WedClosedPP = True And Thisline.Wednesday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Thursday Is Nothing Then
                If ThuClosedPP = True And Thisline.Thursday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Friday Is Nothing Then
                If FriClosedPP = True And Thisline.Friday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Saturday Is Nothing Then
                If SatClosedPP = True And Thisline.Saturday.Hours > 0 Then
                    Return False
                End If
            End If
            If Not Thisline.Sunday Is Nothing Then
                If SunClosedPP = True And Thisline.Sunday.Hours > 0 Then
                    Return False
                End If
            End If
            If SetDayDelete(Thisline.Monday, "Monday") = False Or
                SetDayDelete(Thisline.Tuesday, "Tuesday") = False Or
                SetDayDelete(Thisline.Wednesday, "Wednesday") = False Or
                SetDayDelete(Thisline.Thursday, "Thursday") = False Or
                SetDayDelete(Thisline.Friday, "Friday") = False Or
                SetDayDelete(Thisline.Saturday, "Saturday") = False Or
                SetDayDelete(Thisline.Sunday, "Sunday") = False Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Function SetDayDelete(ByRef ThisDay As AdvantageFramework.Timesheet.TimesheetEntry, ByVal DayOfTheWeek As String) As Boolean
        If Not ThisDay Is Nothing Then
            Select Case ThisDay.tDate.DayOfWeek
                Case DayOfWeek.Monday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Tuesday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Wednesday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Thursday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Friday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Saturday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
                Case DayOfWeek.Sunday
                    If ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisDay.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        Return True
                    Else
                        Return False
                    End If
            End Select
        Else
            Select Case DayOfTheWeek
                Case DayOfWeek.Monday.ToString
                    Return Not MonPend
                Case DayOfWeek.Tuesday.ToString
                    Return Not TuePend
                Case DayOfWeek.Wednesday.ToString
                    Return Not WedPend
                Case DayOfWeek.Thursday.ToString
                    Return Not ThuPend
                Case DayOfWeek.Friday.ToString
                    Return Not FriPend
                Case DayOfWeek.Saturday.ToString
                    Return Not SatPend
                Case DayOfWeek.Sunday.ToString
                    Return Not SunPend
            End Select
        End If
    End Function

    'used in add new header only
    Public Function SetAddNewDayHeaders() As String
        Dim lg As New LoGlo()

        Dim timeSheet As New cTimeSheet(Session("ConnString"))
        Dim errorMessage As String = String.Empty

        Dim DaysToShow As Integer = 0
        Dim StartWeekOn As String = String.Empty
        Dim ShowCommentUsing As String = String.Empty
        Dim DivisionLabel As String = String.Empty
        Dim ProductLabel As String = String.Empty
        Dim ProductCategoryLabel As String = String.Empty
        Dim JobLabel As String = String.Empty
        Dim JobComponentLabel As String = String.Empty
        Dim FunctionCategoryLabel As String = String.Empty
    End Function

#End Region

#End Region

#End Region

#Region " Methods "

#Region " Add New / Add New Panel Code"

    Private Sub ClearAddNewTextboxes()
        Try

            Me.TextBox_ClientCode.Text = String.Empty
            Me.TextBox_DivisionCode.Text = String.Empty
            Me.TextBox_ProductCode.Text = String.Empty
            Me.TextBox_JobCode.Text = String.Empty
            Me.TextBox_ComponentCode.Text = String.Empty
            Me.TextBox_FunctionCategory.Text = String.Empty
            Me.TextBox_FunctionCategory.Text = String.Empty
            Me.TextBox_NewItemMonday.Text = "0.00"
            Me.TextBox_NewItemTuesday.Text = "0.00"
            Me.TextBox_NewItemWednesday.Text = "0.00"
            Me.TextBox_NewItemThursday.Text = "0.00"
            Me.TextBox_NewItemFriday.Text = "0.00"
            Me.TextBox_NewItemSaturday.Text = "0.00"
            Me.TextBox_NewItemSunday.Text = "0.00"

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetLookUps()

        If RadGridTimesheetNew.MasterTableView.IsItemInserted Then
            Dim dropDowns As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

            Me.ComboBox_Department.DataSource = dropDowns.GetDept(CStr(Me.txtEmpCode.Text), True)
            Me.ComboBox_Department.DataTextField = "Description"
            Me.ComboBox_Department.DataValueField = "Code"
            Me.ComboBox_Department.DataBind()

            With ComboBox_Department
                .DataSource = dropDowns.GetDeptsByEmpCodeWithDefault(CStr(Me.txtEmpCode.Text))
                .DataTextField = "Description"
                .DataValueField = "Code"
                .DataBind()
            End With
            Try
                For departmentIndex As Integer = 0 To ComboBox_Department.Items.Count - 1
                    If ComboBox_Department.Items(departmentIndex).Text.IndexOf("*") > -1 Then
                        ComboBox_Department.Items(departmentIndex).Selected = True
                        ComboBox_Department.Items(departmentIndex).Text = ComboBox_Department.Items(departmentIndex).Text.Replace("*", String.Empty)
                    End If
                Next
                If ComboBox_Department.Items.Count <= 1 Then
                    ComboBox_Department.Enabled = False
                Else
                    ComboBox_Department.Enabled = True
                End If
            Catch ex As Exception
            End Try

            Me.TextBox_FunctionCategory.Text = timeSheet.GetDefaultFunction(CStr(Me.txtEmpCode.Text))
        End If
    End Sub

#End Region

#Region " Product Category Functions"

    Private Function ProductCategoryIsVisible() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()
    End Function
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
    Private Function RequiredProductCategory(ByVal ClientCode As String) As Boolean
        Dim oReq As cRequired = New cRequired(CStr(Session("ConnString")))
        Return oReq.ProductCategoryRequired(ClientCode)
    End Function

    Private Function ValidateProductCategory(ByVal ProductCategory As String, ByVal Client As String, ByVal Division As String, ByVal Product As String) As Boolean
        Dim oVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Return oVal.ValidateProductCategory(ProductCategory, Client, Division, Product)
    End Function

#End Region

#Region " Supervisor Approval"

    Private Sub SetApprovals(ByVal ThisTS As AdvantageFramework.Timesheet.TimeSheet)
        If ThisTS Is Nothing Then Exit Sub

        Dim ThisLine As AdvantageFramework.Timesheet.TimesheetLine

        For Each ThisLine In ThisTS
            If Not ThisLine.Monday Is Nothing Then
                If MonPend = False Then
                    If ThisLine.Monday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Monday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Monday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        MonPend = True
                    End If
                End If
            End If
            If Not ThisLine.Tuesday Is Nothing Then
                If TuePend = False Then
                    If ThisLine.Tuesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Tuesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Tuesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        TuePend = True
                    End If
                End If
            End If
            If Not ThisLine.Wednesday Is Nothing Then
                If WedPend = False Then
                    If ThisLine.Wednesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Wednesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Wednesday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        WedPend = True
                    End If
                End If
            End If
            If Not ThisLine.Thursday Is Nothing Then
                If ThuPend = False Then
                    If ThisLine.Thursday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Thursday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Thursday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        ThuPend = True
                    End If
                End If
            End If
            If Not ThisLine.Friday Is Nothing Then
                If FriPend = False Then
                    If ThisLine.Friday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Friday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Friday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        FriPend = True
                    End If
                End If
            End If
            If Not ThisLine.Saturday Is Nothing Then
                If SatPend = False Then
                    If ThisLine.Saturday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Saturday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Saturday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        SatPend = True
                    End If
                End If
            End If
            If Not ThisLine.Sunday Is Nothing Then
                If SunPend = False Then
                    If ThisLine.Sunday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Or ThisLine.Sunday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Approved Or ThisLine.Sunday.EditFlag = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        SunPend = True
                    End If
                End If
            End If
        Next
        For Each ThisLine In ThisTS
            If Not ThisLine.Monday Is Nothing Then
                If MonEdit = True Then
                    If ThisLine.Monday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        MonEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Tuesday Is Nothing Then
                If TueEdit = True Then
                    If ThisLine.Tuesday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        TueEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Wednesday Is Nothing Then
                If WedEdit = True Then
                    If ThisLine.Wednesday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        WedEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Thursday Is Nothing Then
                If ThuEdit = True Then
                    If ThisLine.Thursday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        ThuEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Friday Is Nothing Then
                If FriEdit = True Then
                    If ThisLine.Friday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        FriEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Saturday Is Nothing Then
                If SatEdit = True Then
                    If ThisLine.Saturday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        SatEdit = False
                    End If
                End If
            End If
            If Not ThisLine.Sunday Is Nothing Then
                If SunEdit = True Then
                    If ThisLine.Sunday.EditFlag <> AdvantageFramework.Timesheet.TimesheetEditType.Edit Then
                        SunEdit = False
                    End If
                End If
            End If
        Next
    End Sub

    Private Function SendEmailAlert(ByVal AlertID As Integer) As Boolean
        Try

            Dim emailSession As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With emailSession
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
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "GetSendAlertSuper"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim sqlQuery As String
                Dim value As Integer

                sqlQuery = "SELECT ISNULL(AUTO_ALERT_SUPER,0) FROM AGENCY WITH(NOLOCK);"

                IsValid = MiscFN.IntToBool(SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, sqlQuery))

            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Private Function GetEmpSuper(ByVal emp_code As String) As String
        Dim SessionKey As String = "GetEmpSuper" & emp_code
        Dim ReturnString As String = String.Empty
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim sqlQuery As String

            sqlQuery = "SELECT ISNULL(SUPERVISOR_CODE,'') FROM EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"

            Try
                ReturnString = SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, sqlQuery)
            Catch
                ReturnString = String.Empty
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Private Function GetEmpFullName(ByVal emp_code As String) As String
        Dim SessionKey As String = "GetEmpFullName" & emp_code
        Dim ReturnString As String = String.Empty
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim sqlQuery As String
            sqlQuery = "SELECT ISNULL(EMP_FML,'') FROM V_ACTIVE_EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"
            Try
                ReturnString = SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, sqlQuery)
            Catch
                ReturnString = String.Empty
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

#End Region
#Region " Validations"

    Private Function ValidDate() As Boolean

        If Me.RadDatePickerStartDate.SelectedDate = Nothing Then
            Me.ShowMessage(MiscFN.InvalidDateMessage)
            Me.RadDatePickerStartDate.DateInput.Focus()
            Return False
        End If

        If Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then
            Me.ShowMessage(MiscFN.InvalidDateMessage)
            Me.RadDatePickerStartDate.DateInput.Focus()
            Return False
        End If

        Return Me.SetDates(Me.RadDatePickerStartDate.SelectedDate)

    End Function

    Private Function SetDates(ByVal TheDate As Date) As Boolean

        Dim errorMessage As String = String.Empty
        Dim timeSheet As New cTimeSheet(Session("ConnString"))

        If timeSheet.GetDateRange(TheDate, Me.TimesheetStartDate, Me.TimesheetEndDate, errorMessage) = True Then

            Me.RadDatePickerStartDate.SelectedDate = Me.TimesheetStartDate
            Session("TimesheetStartDate") = Me.TimesheetStartDate
            Return True

        Else

            Me.ShowMessage(errorMessage)
            Return False

        End If

    End Function

    Private Sub LimitUser()

        Try

            Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

            If Me.txtEmpCode.Text = String.Empty Then

                Me.txtEmpCode.Text = Session("EmpCode")

            End If
            If timeSheet.UserLimited(Session("UserCode")) = True Then

                Me.lbtnEmpCode.Visible = False
                Me.litEmpCode.Visible = True
                Me.txtEmpCode.Visible = True
                Me.txtEmpCode.Enabled = False

                AdvantageFramework.Web.Presentation.Controls.DivHide(Me.DivEmployee)

            Else

                Me.lbtnEmpCode.Visible = True
                Me.litEmpCode.Visible = False
                Me.txtEmpCode.Visible = True
                Me.txtEmpCode.Enabled = True

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Private Function ValidateHours(ByRef ThisTextBox As TextBox) As Boolean
        Try
            If ThisTextBox.Text.Trim = String.Empty Then
                Return True
            End If
            If IsNumeric(ThisTextBox.Text) = False Then
                ThisTextBox.CssClass = "RequiredInput"
                Return False
            End If
            If CDbl(ThisTextBox.Text) <= 24 Then
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

    Private Function ValidateSupApproval(ByVal TheDate As Date) As Boolean
        Dim agency As cAgency = New cAgency(CStr(Session("ConnString")))
        Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        If agency.CheckTimeSupervisorApproval = True Then
            Return timeSheet.CheckApprovalStatus(Me.txtEmpCode.Text, TheDate)
        Else
            Return True
        End If
    End Function

    Private Function CheckPostPeriod() As Boolean

        Dim BoolReturn As Boolean = False
        Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then

            SunClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(0))
            MonClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(1))
            TueClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(2))
            WedClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(3))
            ThuClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(4))
            FriClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(5))
            SatClosedPP = timeSheet.PostPeriodClosed(CDate(Me.RadDatePickerStartDate.SelectedDate).AddDays(6))

            If SunClosedPP = True And MonClosedPP = True And TueClosedPP = True And WedClosedPP = True And ThuClosedPP = True And FriClosedPP = True And SatClosedPP = True Then

                Me.RadGridTimesheetNew.MasterTableView.Caption = "This posting period is closed."
                Me.RadToolbarButtonAddNewCV.Enabled = False
                Me.ButtonCopyFromMyTimesheets.Enabled = False
                Me.ButtonCopyFromMyProjects.Enabled = False
                Me.ButtonCopyFromMyTemplates.Enabled = False

                _PostPeriodClosedForAllDays = True
                BoolReturn = True

            ElseIf SunClosedPP = True Or MonClosedPP = True Or TueClosedPP = True Or WedClosedPP = True Or ThuClosedPP = True Or FriClosedPP = True Or SatClosedPP = True Then

                Me.RadGridTimesheetNew.MasterTableView.Caption = "This week has days where the posting period is closed."
                Me.RadToolbarButtonAddNewCV.Enabled = True
                Me.ButtonCopyFromMyTimesheets.Enabled = True
                Me.ButtonCopyFromMyProjects.Enabled = True
                Me.ButtonCopyFromMyTemplates.Enabled = True

                _PostPeriodClosedForAllDays = False
                BoolReturn = True

            Else

                Me.RadGridTimesheetNew.MasterTableView.Caption = String.Empty
                Me.RadToolbarButtonAddNewCV.Enabled = True
                Me.ButtonCopyFromMyTimesheets.Enabled = True
                Me.ButtonCopyFromMyProjects.Enabled = True
                Me.ButtonCopyFromMyTemplates.Enabled = True

                _PostPeriodClosedForAllDays = False
                BoolReturn = False

            End If

        End If

        Return BoolReturn

    End Function

    Private Sub CheckMyCalendarSettings()
        Try
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.txtEmpCode.Text)

                If Employee.CalendarTimeType = 1 Then

                    If Employee.CalendarTimeEmailAddress Is Nothing And Employee.GoogleToken Is Nothing Then
                        'Me.ButtonCopyFromTimesheetStaging.Attributes.Add("onclick", "return confirm('Must select Calendar Type and related settings before use.  Enter now?.');")
                        'Me.ShowMessage("Must select Calendar Type and related settings before use.  Enter now Y/N?.")
                    End If

                Else
                    ' Me.ButtonCopyFromTimesheetStaging.Attributes.Add("onclick", "return confirm('Must select Calendar Type and related settings before use.  Enter now?.');")
                    'Me.ShowMessage("Must select Calendar Type and related settings before use.  Enter now Y/N?.")

                End If

            End Using
        Catch ex As Exception

        End Try
    End Sub

#End Region
    Private Sub TimesheetContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        'objects
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim ColumnValues() As String = Nothing
        Dim ColumnNameIndex As Integer = 0

        If TypeOf e.Item.Parent Is Telerik.Web.UI.RadMenuItem AndAlso DirectCast(e.Item.Parent, Telerik.Web.UI.RadMenuItem).Value = "ColumnsContainer" AndAlso
                e.Item.Controls.Count = 1 AndAlso TypeOf e.Item.Controls(0) Is System.Web.UI.WebControls.CheckBox Then

            If e.Item.Value.ToString().IndexOf("|") > -1 Then
                ColumnValues = Split(e.Item.Value, "|")
                ColumnNameIndex = ColumnValues.Length - 1
            End If

            Try

                GridColumn = (From Column In DirectCast(sender.parent, Telerik.Web.UI.RadGrid).Columns.OfType(Of Telerik.Web.UI.GridColumn)()
                              Where Column.UniqueName = ColumnValues(ColumnNameIndex)
                              Select Column).Single

            Catch ex As Exception
                GridColumn = Nothing
            Finally

                If GridColumn IsNot Nothing Then
                    If GridColumn.UniqueName = "GridBoundColumnProductCategory" OrElse GridColumn.UniqueName = "GridBoundColumnProductCategorySortable" Then
                        e.Item.Visible = False
                    End If
                End If

            End Try
        End If
    End Sub

    Private Sub CheckForRowInsert()

        If Me.IsPostBack Then

            If Me.EventTarget = "InsertTimesheetRow" AndAlso Me.EventArgument = "angularjs" Then

                Me.SaveNewRow()

            End If

        End If

    End Sub
    Private Sub SaveNewRow()

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
        Dim ThisAlertID As Integer = 0
        Dim strError As String
        Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

        If Me.ValidateEmployeeCode(Me.txtEmpCode.Text) = False Then

            Exit Sub

        End If

        If ValidDate() = False Then

            Exit Sub

        End If

        Try

            If Me.TextBox_JobCode.Text.Trim = String.Empty Then

                ThisJob = 0

            Else

                If IsNumeric(Me.TextBox_JobCode.Text) Then

                    ThisJob = CInt(Me.TextBox_JobCode.Text)

                End If

            End If

            If Me.TextBox_ComponentCode.Text.Trim = String.Empty Then

                ThisJobComp = 0

            Else

                If IsNumeric(Me.TextBox_ComponentCode.Text) Then

                    ThisJobComp = CInt(Me.TextBox_ComponentCode.Text)

                End If

            End If

            If ThisJob > 0 And ThisJobComp = 0 Then

                Me.FocusControl(Me.TextBox_ComponentCode)
                Me.ShowMessage("Job selected without a Component.")
                Exit Sub

            End If

            If ThisJob > 0 And ThisJobComp > 0 Then

                If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then

                    Me.FocusControl(Me.TextBox_JobCode)
                    Me.ShowMessage("Invalid Job and Component.")
                    Exit Sub

                End If

                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

                If myVal.ValidateJobIsOpen(ThisJob, ThisJobComp) = False Then

                    Me.FocusControl(Me.TextBox_JobCode)
                    Me.ShowMessage("This Job/Component is closed.")
                    Exit Sub

                End If

            End If

            If String.IsNullOrWhiteSpace(TextBox_Assignment.Text) = False AndAlso IsNumeric(TextBox_Assignment.Text) Then

                ThisAlertID = CType(TextBox_Assignment.Text, Integer)

            End If

            Dim TimesheetStartDateStartWeekOnOffset As Date
            TimesheetStartDateStartWeekOnOffset = Me.TimesheetStartDate

            'Select Case Me.StartWeekOn

            '    Case DayOfWeek.Saturday

            '        TimesheetStartDateStartWeekOnOffset = Me.TimesheetStartDate.AddDays(1)

            '    Case DayOfWeek.Sunday

            '        TimesheetStartDateStartWeekOnOffset = Me.TimesheetStartDate

            '    Case DayOfWeek.Monday

            '        TimesheetStartDateStartWeekOnOffset = Me.TimesheetStartDate.AddDays(-1)

            'End Select

            If Me.TextBox_NewItemSunday.Visible = True And Me.TextBox_NewItemSunday.Enabled = True And ValidateHours(Me.TextBox_NewItemSunday) = False Then

                Me.FocusControl(Me.TextBox_NewItemSunday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemMonday.Visible = True And Me.TextBox_NewItemMonday.Enabled = True And ValidateHours(Me.TextBox_NewItemMonday) = False Then

                Me.FocusControl(Me.TextBox_NewItemMonday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(1).DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemTuesday.Visible = True And Me.TextBox_NewItemTuesday.Enabled = True And ValidateHours(Me.TextBox_NewItemTuesday) = False Then

                Me.FocusControl(Me.TextBox_NewItemTuesday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(2).DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemWednesday.Visible = True And Me.TextBox_NewItemWednesday.Enabled = True And ValidateHours(Me.TextBox_NewItemWednesday) = False Then

                Me.FocusControl(Me.TextBox_NewItemWednesday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(3).DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemThursday.Visible = True And Me.TextBox_NewItemThursday.Enabled = True And ValidateHours(Me.TextBox_NewItemThursday) = False Then

                Me.FocusControl(Me.TextBox_NewItemThursday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(4).DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemFriday.Visible = True And Me.TextBox_NewItemFriday.Enabled = True And ValidateHours(Me.TextBox_NewItemFriday) = False Then

                Me.FocusControl(Me.TextBox_NewItemFriday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(5).DayOfWeek.ToString() & ".")
                Exit Sub

            End If
            If Me.TextBox_NewItemSaturday.Visible = True And Me.TextBox_NewItemSaturday.Enabled = True And ValidateHours(Me.TextBox_NewItemSaturday) = False Then

                Me.FocusControl(Me.TextBox_NewItemSaturday)
                Me.ShowMessage("Invalid hours for " & TimesheetStartDateStartWeekOnOffset.AddDays(6).DayOfWeek.ToString() & ".")
                Exit Sub

            End If

            ThisFuncCat = Me.TextBox_FunctionCategory.Text.Trim

            Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
            If Me.TextBox_ClientCode.Text <> String.Empty Then
                If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, String.Empty, String.Empty, "ts") = False Then
                    Me.TextBox_ClientCode.Focus()
                    Me.ShowMessage("Access to this Client is denied.")

                    Exit Sub
                End If
            End If
            If Me.TextBox_ClientCode.Text <> String.Empty And Me.TextBox_DivisionCode.Text <> String.Empty Then
                If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, String.Empty, "ts") = False Then
                    Me.TextBox_DivisionCode.Focus()
                    Me.ShowMessage("Access to this Division is denied.")

                    Exit Sub
                End If
            End If
            If Me.TextBox_ClientCode.Text <> String.Empty And Me.TextBox_DivisionCode.Text <> String.Empty And Me.TextBox_ProductCode.Text <> String.Empty Then
                If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, Me.TextBox_ProductCode.Text.Trim, "ts") = False Then
                    Me.TextBox_ProductCode.Focus()
                    Me.ShowMessage("Access to this Product is denied.")

                    Exit Sub
                End If
            End If
            If Me.TextBox_JobCode.Text <> String.Empty Then
                If IsNumeric(Me.TextBox_JobCode.Text.Trim) = False Then
                    Me.TextBox_JobCode.Focus()
                    Me.ShowMessage("Job number is not a number.")

                    Exit Sub
                End If
                If oValidation.ValidateJobNumber(Me.TextBox_JobCode.Text) = False Then
                    Me.TextBox_JobCode.Focus()
                    Me.ShowMessage("This Job does not exist.")

                    Exit Sub
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TextBox_JobCode.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TextBox_JobCode.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this job is denied.")
                        Exit Sub
                    End If
                End Using
            End If
            If Me.TextBox_ComponentCode.Text <> String.Empty Then
                If IsNumeric(Me.TextBox_ComponentCode.Text.Trim) = False Then
                    Me.TextBox_ComponentCode.Focus()
                    Me.ShowMessage("Job Component number is not a number.")

                    Exit Sub
                End If
            End If
            If Me.TextBox_JobCode.Text = String.Empty And Me.TextBox_ComponentCode.Text <> String.Empty Then
                Me.TextBox_JobCode.Focus()
                Me.ShowMessage("You cannot enter a Component number without a Job number.")

                Exit Sub
            End If
            If Me.TextBox_JobCode.Text <> String.Empty And Me.TextBox_ComponentCode.Text <> String.Empty Then
                If oValidation.ValidateJobCompNumber(Me.TextBox_JobCode.Text, Me.TextBox_ComponentCode.Text) = False Then
                    Me.TextBox_JobCode.Focus()
                    Me.ShowMessage("This is not a valid Job/Component.")

                    Exit Sub
                End If
                If oValidation.ValidateJobCompIsEditable(Me.TextBox_JobCode.Text.Trim, Me.TextBox_ComponentCode.Text.Trim) = False Then
                    Me.TextBox_JobCode.Focus()
                    Me.ShowMessage("Job/Component Process Control does not allow access.")

                    Exit Sub
                End If
                If oValidation.ValidateJobCompIsViewable(Session("UserCode"), Me.TextBox_JobCode.Text.Trim, Me.TextBox_ComponentCode.Text.Trim, "ts") = False Then
                    Me.TextBox_JobCode.Focus()
                    Me.ShowMessage("Access to this Job/Component is denied.")

                    Exit Sub
                End If
            End If
            If ThisFuncCat = String.Empty Then
                Me.TextBox_FunctionCategory.Focus()
                Me.ShowMessage("Function/Category is a required field.")

                Exit Sub
            End If
            Dim j As Integer = 0
            Dim jc As Integer = 0
            If IsNumeric(Me.TextBox_JobCode.Text) = True Then
                j = CType(Me.TextBox_JobCode.Text, Integer)
            End If
            If IsNumeric(Me.TextBox_ComponentCode.Text) = True Then
                jc = CType(Me.TextBox_ComponentCode.Text, Integer)
            End If
            If j > 0 And jc > 0 And ThisFuncCat.Length > 6 Then
                ThisFuncCat = ThisFuncCat.Substring(0, 6)
            End If
            If Me.TextBox_JobCode.Text = String.Empty And Me.TextBox_ComponentCode.Text = String.Empty And Me.TextBox_FunctionCategory.Text <> String.Empty Then
                'it is a category and not a function
                If oValidation.ValidateFunctionCategoryAll(Me.txtEmpCode.Text.Trim, ThisFuncCat, "V", True) = False Then
                    Me.TextBox_FunctionCategory.Focus()
                    Me.ShowMessage(ThisFuncCat & " is an invalid Category.")

                    Exit Sub
                End If
            End If

            Dim CurrDefaultFN As String = oTS.GetDefaultFunction(CStr(Me.txtEmpCode.Text))
            If Me.TextBox_FunctionCategory.Text = CurrDefaultFN Then
                If oValidation.ValidateFunctionTSAddNew(Me.txtEmpCode.Text.Trim, CurrDefaultFN) = False Then
                    Me.TextBox_FunctionCategory.Focus()
                    Me.ShowMessage("This Employee does not have access to his/her own default Function.")

                    Exit Sub
                End If
            End If
            If Me.TextBox_JobCode.Text <> String.Empty And Me.TextBox_ComponentCode.Text <> String.Empty And Me.TextBox_FunctionCategory.Text <> String.Empty And Me.TextBox_FunctionCategory.Text <> CurrDefaultFN Then
                If oValidation.ValidateFunctionTSAddNew(Me.txtEmpCode.Text.Trim, ThisFuncCat) = False Then
                    Me.TextBox_FunctionCategory.Focus()
                    Me.ShowMessage(ThisFuncCat & " is an invalid Function.")

                    Exit Sub
                End If
            End If

            ThisDept = Me.ComboBox_Department.SelectedValue

            If oValidation.ValidateDeptTeam(ThisDept) = False Then
                Me.ComboBox_Department.Focus()
                Me.ShowMessage("Invalid Department.")

                Exit Sub
            End If

            If ProductCategoryIsVisible() = True Then
                ThisProdCat = Me.TextBox_ProductCategory.Text.Trim
                If ThisProdCat = String.Empty Then
                    If RequiredProductCategory(ThisClient) = True Then
                        Me.TextBox_ProductCategory.Focus()
                        Me.ShowMessage("Product Category is required.")

                        Exit Sub
                    End If
                Else
                    If ValidateProductCategory(ThisProdCat, ThisClient, ThisDiv, ThisProd) = False Then
                        Me.TextBox_ProductCategory.Focus()
                        Me.ShowMessage("Product Category is not valid.")

                        Exit Sub
                    End If
                End If
            End If

            Dim ApprovalMessage As String = String.Empty
            Dim TimeSaved As Boolean = False
            Dim NewEtId As Integer = 0
            Dim NewEtDtlId As Integer = 0
            Dim ShowEstimateApprovalMessage As Boolean = False
            Dim EstimateApprovalMessage As String = ""

            If DaysToDisplay <> 1 And Me.TextBox_NewItemMonday.Visible = True And Me.TextBox_NewItemMonday.Text.Trim() = String.Empty Then

                Me.TextBox_NewItemMonday.Text = "0.00"

            End If

            If Me.TextBox_NewItemSunday.Visible = True And Me.TextBox_NewItemSunday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemSunday.Text.Trim() = String.Empty Then Me.TextBox_NewItemSunday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemSunday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(0))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(0)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemSunday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(0), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemSunday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_SundayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemMonday.Visible = True And Me.TextBox_NewItemMonday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemMonday.Text.Trim() = String.Empty Then Me.TextBox_NewItemMonday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemMonday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(1))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(1)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemMonday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(1).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(1), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemMonday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_MondayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemTuesday.Visible = True And Me.TextBox_NewItemTuesday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemTuesday.Text.Trim() = String.Empty Then Me.TextBox_NewItemTuesday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemTuesday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(2))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(2)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemTuesday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(2).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(2), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemTuesday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_TuesdayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemWednesday.Visible = True And Me.TextBox_NewItemWednesday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemWednesday.Text.Trim() = String.Empty Then Me.TextBox_NewItemWednesday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemWednesday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(3))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(3)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemWednesday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(3).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(3), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemWednesday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_WednesdayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemThursday.Visible = True And Me.TextBox_NewItemThursday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemThursday.Text.Trim() = String.Empty Then Me.TextBox_NewItemThursday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemThursday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(4))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(4)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemThursday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(4).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(4), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemThursday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_ThursdayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemFriday.Visible = True And Me.TextBox_NewItemFriday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemFriday.Text.Trim() = String.Empty Then Me.TextBox_NewItemFriday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemFriday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(5))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(5)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemFriday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(5).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(5), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemFriday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_FridayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If Me.TextBox_NewItemSaturday.Visible = True And Me.TextBox_NewItemSaturday.Enabled = True Then
                If DaysToDisplay = 1 And Me.TextBox_NewItemSaturday.Text.Trim() = String.Empty Then Me.TextBox_NewItemSaturday.Text = "0.00"
                If IsNumeric(Me.TextBox_NewItemSaturday.Text) Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(6))
                    If oTS.CheckApprovalStatus(Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(6)) = True And CurrEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                        If CDbl(TextBox_NewItemSaturday.Text) <> 0 Then
                            ApprovalMessage &= TimesheetStartDateStartWeekOnOffset.AddDays(6).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    Else
                        If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), 0, 0, Me.txtEmpCode.Text, TimesheetStartDateStartWeekOnOffset.AddDays(6), ThisFuncCat, ThisProdCat, Me.TextBox_NewItemSaturday.Text.Trim,
                                                            ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Me.TextBox_SaturdayComments.Text.Trim(), NewEtId, NewEtDtlId, False, ThisAlertID) = True Then
                            TimeSaved = True
                        End If
                    End If
                End If
            End If

            If ShowEstimateApprovalMessage = False Then

                ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

            End If

            If TimeSaved = True Then

                oTS.DeleteMissingTimeDtl(Me.txtEmpCode.Text)
                ProcessMissingTime(Me.txtEmpCode.Text, Me.TimesheetStartDate)
                If Me.IsDefaultWorkspace = False Then Me.RefreshTimesheetDesktopObject(False)

            Else

                If String.IsNullOrWhiteSpace(strError) = False AndAlso ShowEstimateApprovalMessage = False Then

                    Me.ShowMessage(strError)

                End If

            End If

            Me.RadGridTimesheetNew.Rebind()
            Me.ClearAddNewTextboxes()

            If ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(EstimateApprovalMessage) = False Then

                Me.ShowMessage(EstimateApprovalMessage)

            End If
            If String.IsNullOrWhiteSpace(ApprovalMessage) = False Then

                Me.ShowMessage(ApprovalMessage)

            End If

        Catch ex As Exception
            Me.ShowMessage(("Error saving new row"))
        End Try


    End Sub

    Private Function ShowNewEntryMessage(ByVal DataKey As String, ByRef Message As String) As Boolean
        Dim ReturnValue As Boolean = False

        Try

            If DataKey.Contains("|") = True Then

                Dim ar() As String

                ar = DataKey.Split("|") '"INSERT_SUCCESS|4129|1|8.000|120.000|0|-15|Warning, your time entry will cause the total hours posted to exceed the approved estimate amount for the function."

                If ar IsNot Nothing AndAlso ar.Length > 7 Then
                    If ar(6) IsNot Nothing AndAlso ar(7) IsNot Nothing Then

                        Select Case CType(ar(6), Integer)
                            Case -15, -16, -17

                                ReturnValue = True
                                Message = ar(7)

                        End Select

                    End If
                End If

            End If

        Catch ex As Exception
        End Try

        Return ReturnValue

    End Function

    Private Sub SetNextDay()
        If IsNumeric(Me.RadComboBoxDayToShow.SelectedValue) = True Then
            Dim CurrentIndex As Integer = Me.RadComboBoxDayToShow.SelectedIndex
            Dim NextIndex As Integer = CurrentIndex + 1
            If NextIndex >= Me.RadComboBoxDayToShow.Items.Count Or NextIndex = 0 Or NextIndex = 1 Then
                NextIndex = 2
            End If
            Me.RadComboBoxDayToShow.SelectedIndex = NextIndex
        End If
    End Sub
    Private Sub SetPreviousDay()
        If IsNumeric(Me.RadComboBoxDayToShow.SelectedValue) = True Then
            Dim CurrentIndex As Integer = Me.RadComboBoxDayToShow.SelectedIndex
            Dim NextIndex As Integer = CurrentIndex - 1
            If NextIndex = 0 Or NextIndex = 1 Then
                NextIndex = Me.RadComboBoxDayToShow.Items.Count - 1
            End If
            Me.RadComboBoxDayToShow.SelectedIndex = NextIndex
        End If
    End Sub

    <System.Web.Services.WebMethod(True)>
    Public Shared Function SaveTime(ByVal DataKey As String, ByVal ControlId As String, ByVal ControlValue As String, ByVal IsStopwatch As Boolean) As String

        Dim culureInfo As System.Globalization.CultureInfo
        Dim lg As New LoGlo()
        culureInfo = lg.GetCultureInfo

        Dim ReturnMessage As String = String.Empty

        Dim EtId As Integer = 0
        Dim EtDtlId As Integer = 0
        Dim EmpCode As String = String.Empty
        Dim EditFlag As String = String.Empty
        Dim TimeType As String = String.Empty
        Dim CellDate As Date = Nothing
        Dim FuncCatCode As String = String.Empty
        Dim ProdCatCode As String = String.Empty
        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim DeptTeamCode As String = String.Empty
        Dim ClientControlPrefix As String = String.Empty
        Dim UserCode As String = HttpContext.Current.Session("UserCode").ToString()
        Dim Hours As Decimal = CType(0, Decimal)
        Dim EnDate As Date = Nothing '734-1-2480 - time entry error/issue when using non-English US locale
        Dim AlertID As Integer = 0

        ControlValue = ControlValue.Trim()

        If ControlValue <> String.Empty And IsNumeric(ControlValue) = False Then
            Return "ERROR|Invalid hours" & "|" & ControlId
        End If

        If ControlValue <> String.Empty And IsNumeric(ControlValue) = True Then
            ControlValue = ControlValue.Replace(culureInfo.NumberFormat.NumberDecimalSeparator, ".") 'force US decimal
            Hours = CType(ControlValue, Decimal)
            If Hours > 24 Then
                Return "ERROR|Invalid hours|" & ControlId
            End If
        End If

        If ControlValue = String.Empty Then
            Hours = 0
        End If

        Dim dataKeyArray() As String
        dataKeyArray = DataKey.Split("|")

        Try
            EtId = dataKeyArray(7)
        Catch ex As Exception
            EtId = 0
        End Try
        Try
            EtDtlId = dataKeyArray(8)
        Catch ex As Exception
            EtDtlId = 0
        End Try

        If IsStopwatch = False And Hours = 0 And EtId = 0 And EtDtlId = 0 Then Exit Function

        Try
            EmpCode = dataKeyArray(1)
        Catch ex As Exception
            EmpCode = String.Empty
        End Try
        Try
            EditFlag = dataKeyArray(11)
        Catch ex As Exception
            EditFlag = String.Empty
        End Try
        Try
            TimeType = dataKeyArray(10)
        Catch ex As Exception
            TimeType = String.Empty
        End Try
        Try
            AlertID = dataKeyArray(15)
        Catch ex As Exception
            AlertID = 0
        End Try

        'If DateTime.TryParseExact(DateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, dataKeyArray(9)) Then
        '    'In the format expected
        'Else
        '    'NOT in the format expected
        'End If

        'Try
        '    If IsDate(dataKeyArray(9)) = True Then
        '        CellDate = CType(LoGlo.FormatDate(dataKeyArray(9)), Date)
        '    Else
        '        Return "ERROR|Cannot get date|" & ControlId
        '    End If
        'Catch ex As Exception
        '    Return "ERROR|Cannot get date|" & ControlId
        'End Try
        Try
            If Date.TryParse(dataKeyArray(9), culureInfo, Globalization.DateTimeStyles.None, CellDate) = True Then
                'CellDate = CType(LoGlo.FormatDate(dataKeyArray(9)), Date)
                CellDate = lg.SetDate(culureInfo, dataKeyArray(9))
            Else
                'Return "ERROR|Cannot get date|" & ControlId
            End If
        Catch ex As Exception
            'Return "ERROR|Cannot get date|" & ControlId
        End Try
        Try

            '734-1-2480 - time entry error/issue when using non-English US locale
            EnDate = DateTime.Parse(CellDate)
            EnDate = CType(EnDate.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), Date)

        Catch ex As Exception
        End Try

        Try
            FuncCatCode = dataKeyArray(2)
        Catch ex As Exception
            FuncCatCode = String.Empty
        End Try
        Try
            ProdCatCode = dataKeyArray(4)
        Catch ex As Exception
            ProdCatCode = String.Empty
        End Try
        Try
            JobNumber = dataKeyArray(5)
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            JobComponentNbr = dataKeyArray(6)
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            DeptTeamCode = dataKeyArray(3)
        Catch ex As Exception
            DeptTeamCode = String.Empty
        End Try
        Try
            ClientControlPrefix = dataKeyArray(0)
        Catch ex As Exception
            ClientControlPrefix = String.Empty
        End Try

        Dim timeSheet As New cTimeSheet(HttpContext.Current.Session("ConnString"))
        Dim CurrentDayEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

        If LoGlo.IsEnglish = False Then  '734-1-2480 - time entry error/issue when using non-English US locale

            Try

                If EnDate = CellDate Then

                    Dim ar() As String

                    If EnDate.ToShortDateString.Contains("/") Then

                        ar = EnDate.ToShortDateString.Split("/")

                    ElseIf EnDate.ToShortDateString.Contains(".") Then

                        ar = EnDate.ToShortDateString.Split(".")

                    ElseIf EnDate.ToShortDateString.Contains("-") Then

                        ar = EnDate.ToShortDateString.Split("-")

                    ElseIf EnDate.ToShortDateString.Contains(",") Then

                        ar = EnDate.ToShortDateString.Split(",")

                    End If

                    If ar.Count = 3 Then

                        EnDate = CDate(ar(1) & "/" & ar(0) & "/" & ar(2))

                    End If

                End If

            Catch ex As Exception
            End Try

            CurrentDayEditStatus = timeSheet.CheckEditStatus(EmpCode, EnDate)

            If timeSheet.CheckApprovalStatus(EmpCode, EnDate) = True And CurrentDayEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                Return "ERROR|This day has already been approved/pending.  No time will be added to this day|" & ControlId

            End If

        Else

            CurrentDayEditStatus = timeSheet.CheckEditStatus(EmpCode, CellDate)

            If timeSheet.CheckApprovalStatus(EmpCode, CellDate) = True And CurrentDayEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                Return "ERROR|This day has already been approved/pending.  No time will be added to this day|" & ControlId

            End If

        End If

        Dim NewEtId As Integer = 0
        Dim NewEtDtlId As Integer = 0
        Dim required As New cRequired(HttpContext.Current.Session("ConnString"))

        If CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

            Try
                If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), EtId, EtDtlId, EmpCode, CellDate, FuncCatCode, ProdCatCode,
                                                        Hours, JobNumber, JobComponentNbr, DeptTeamCode, UserCode, ReturnMessage, , NewEtId, NewEtDtlId, True, AlertID) = True Then

                    timeSheet.DeleteMissingTimeDtl(EmpCode)
                    ProcessMissingTime(EmpCode, CellDate)

                Else

                    If ReturnMessage.Trim() <> "" Then

                        If ReturnMessage.Contains("UPDATE_FAIL|") Then

                            ReturnMessage &= "|" & Microsoft.VisualBasic.FormatNumber(Hours, 2).Replace(".", culureInfo.NumberFormat.NumberDecimalSeparator) & "|" & ClientControlPrefix & "|" & ControlId & "|" &
                                    required.RequiredTimesheetComments.ToString().ToLower() & "|" & timeSheet.GetSessionTimesheetSettings(HttpContext.Current.Session("UserCode")).ShowCommentsUsing

                            Return ReturnMessage

                        Else

                            Return "ERROR|" & ReturnMessage & "|" & ControlId

                        End If

                    End If

                End If
            Catch ex As Exception
                Return "ERROR|" & MiscFN.JavascriptSafe(ex.Message.ToString()) & "|" & ControlId
            End Try

        Else

            ReturnMessage = "ERROR|Edit status does not allow adding/editing" & "|" & ControlId

        End If

        ReturnMessage &= "|" & Microsoft.VisualBasic.FormatNumber(Hours, 2).Replace(".", culureInfo.NumberFormat.NumberDecimalSeparator) & "|" & ClientControlPrefix & "|" & ControlId & "|" &
            required.RequiredTimesheetComments.ToString().ToLower() & "|" & timeSheet.GetSessionTimesheetSettings(HttpContext.Current.Session("UserCode")).ShowCommentsUsing

        'final datakey positions:
        '0 = success/fail message
        '1 = etid
        '2 = etdtlid
        '3 = hours formatted
        '4 = cell prefix
        '5 = hours textbox name
        '6 = comment required
        '7 = comment type (textbox or icon)
        Return ReturnMessage

    End Function

    <System.Web.Services.WebMethod(True)>
    Public Shared Function SaveComment(ByVal DataKey As String, ByVal ControlName As String, ByVal ControlValue As String) As String

        Dim culureInfo As System.Globalization.CultureInfo
        Dim lg As New LoGlo()
        culureInfo = lg.GetCultureInfo

        Dim ReturnMessage As String = String.Empty
        Dim EtId As Integer = 0
        Dim EtDtlId As Integer = 0
        Dim TimeType As String = String.Empty
        Dim EmpCode As String = String.Empty
        Dim CellDate As Date = Nothing
        Dim EnDate As Date = Nothing
        Dim ClientControlPrefix As String = String.Empty
        Dim UserCode As String = HttpContext.Current.Session("UserCode").ToString()
        Dim ControlClientId As String = ControlName.Replace("$", "_")

        Dim EditFlag As String = String.Empty
        Dim FuncCatCode As String = String.Empty
        Dim ProdCatCode As String = String.Empty
        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim DeptTeamCode As String = String.Empty


        Dim Comment = ControlValue.Trim()

        Dim dataKeyArray() As String
        dataKeyArray = DataKey.Split("|")

        Try
            EtId = dataKeyArray(7)
        Catch ex As Exception
            EtId = 0
        End Try
        Try
            EtDtlId = dataKeyArray(8)
        Catch ex As Exception
            EtDtlId = 0
        End Try

        If Comment = String.Empty And EtId = 0 And EtDtlId = 0 Then Exit Function

        Try
            TimeType = dataKeyArray(10)
        Catch ex As Exception
            TimeType = String.Empty
        End Try
        Try
            EditFlag = dataKeyArray(11)
        Catch ex As Exception
            EditFlag = String.Empty
        End Try
        Try
            If Date.TryParse(dataKeyArray(9), culureInfo, Globalization.DateTimeStyles.None, CellDate) = True Then
                'CellDate = CType(LoGlo.FormatDate(dataKeyArray(9)), Date)
                CellDate = lg.SetDate(culureInfo, dataKeyArray(9))
            Else
                'Return "ERROR|Cannot get date|" & ControlId
            End If
        Catch ex As Exception
            'Return "ERROR|Cannot get date|" & ControlId
        End Try
        Try

            '734-1-2480 - time entry error/issue when using non-English US locale
            EnDate = DateTime.Parse(CellDate)
            EnDate = CType(EnDate.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), Date)

        Catch ex As Exception
        End Try
        If LoGlo.IsEnglish = False Then

            Try

                If EnDate = CellDate Then

                    Dim ar() As String

                    If EnDate.ToShortDateString.Contains("/") Then

                        ar = EnDate.ToShortDateString.Split("/")

                    ElseIf EnDate.ToShortDateString.Contains(".") Then

                        ar = EnDate.ToShortDateString.Split(".")

                    ElseIf EnDate.ToShortDateString.Contains("-") Then

                        ar = EnDate.ToShortDateString.Split("-")

                    ElseIf EnDate.ToShortDateString.Contains(",") Then

                        ar = EnDate.ToShortDateString.Split(",")

                    End If

                    If ar.Count = 3 Then

                        EnDate = CDate(ar(1) & "/" & ar(0) & "/" & ar(2))

                    End If

                End If

            Catch ex As Exception
            End Try

        End If
        Try
            EmpCode = dataKeyArray(1)
        Catch ex As Exception
            EmpCode = String.Empty
        End Try
        Try
            FuncCatCode = dataKeyArray(2)
        Catch ex As Exception
            FuncCatCode = String.Empty
        End Try
        Try
            ProdCatCode = dataKeyArray(4)
        Catch ex As Exception
            ProdCatCode = String.Empty
        End Try
        Try
            JobNumber = dataKeyArray(5)
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            JobComponentNbr = dataKeyArray(6)
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            DeptTeamCode = dataKeyArray(3)
        Catch ex As Exception
            DeptTeamCode = String.Empty
        End Try
        Try
            ClientControlPrefix = dataKeyArray(0)
        Catch ex As Exception
            ClientControlPrefix = String.Empty
        End Try

        Dim timeSheet As New cTimeSheet(HttpContext.Current.Session("ConnString"))
        Dim NewEtId As Integer = 0
        Dim NewEtDtlId As Integer = 0
        Dim CurrentDayEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

        CurrentDayEditStatus = timeSheet.CheckEditStatus(EmpCode, CellDate)

        If timeSheet.CheckApprovalStatus(EmpCode, CType(CellDate, Date)) = True And timeSheet.CheckEditStatus(EmpCode, CType(CellDate, Date)) <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

            Return "ERROR|This day has already been approved/pending.  No changes can be made|" & ControlClientId

        End If

        If EtId = 0 Or EtDtlId = 0 Then

            If CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                Try
                    If AdvantageFramework.Timesheet.SaveDay(HttpContext.Current.Session("ConnString"), EtId, EtDtlId, EmpCode, CellDate, FuncCatCode, ProdCatCode, 0.0, JobNumber, JobComponentNbr,
                                                 DeptTeamCode, UserCode, ReturnMessage, , NewEtId, NewEtDtlId) = True Then

                    End If
                Catch ex As Exception

                End Try

            End If

        Else

            NewEtId = EtId
            NewEtDtlId = EtDtlId

        End If

        If NewEtId = 0 Or NewEtDtlId = 0 Then

            Return "ERROR|Cannot save time|" & ControlClientId

        End If

        Dim comments As New cComments(HttpContext.Current.Session("ConnString"))
        Dim HasComment As Boolean = False

        If comments.SaveEmpTimeComments(TimeType, NewEtId, NewEtDtlId, Comment, ReturnMessage) = True Then

            If Comment.Trim() <> String.Empty Then HasComment = True
            Dim required As New cRequired(HttpContext.Current.Session("ConnString"))
            ReturnMessage &= "|" & ClientControlPrefix & "|" & ControlName.Replace("$", "_") & "|" & NewEtId.ToString() & "|" & NewEtDtlId.ToString() &
                            "|" & HasComment.ToString().ToLower() & "|" & required.RequiredTimesheetComments.ToString().ToLower()

        Else

            Return "ERROR|" & ReturnMessage & "|" & ControlClientId

        End If

        'final datakey positions:
        '0 = success/fail message
        '1 = cell prefix
        '2 = comment textbox name
        '3 = et id
        '4 = et dtl id
        '5 = has comment
        '6 = comment req
        Return ReturnMessage

    End Function
    <System.Web.Services.WebMethod(True)>
    Public Overloads Shared Function ProcessMissingTime(ByVal EmpCode As String, ByVal CurrentDate As Date) As String

        Dim Session As AdvantageFramework.Security.Session = Nothing

        Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                          HttpContext.Current.Session("ConnString"),
                                                          HttpContext.Current.Session("UserCode"),
                                                          CInt(HttpContext.Current.Session("AdvantageUserLicenseInUseID")), HttpContext.Current.Session("ConnString"))

        If Session IsNot Nothing Then

            AdvantageFramework.EmployeeTimesheet.ProcessMissingTime(Session, EmpCode, CurrentDate)

        End If

    End Function

    <System.Web.Services.WebMethod(True)>
    Public Shared Function SaveTimeAndCommentRequired(ByVal DataKey As String, ByVal HoursControlName As String, ByVal HoursControlValue As String,
                                              ByVal CommentControlName As String, ByVal CommentControlValue As String) As String
        Dim ReturnMessage As String = String.Empty

        Dim Hours As Decimal = CType(0, Decimal)

        If HoursControlValue <> String.Empty And IsNumeric(HoursControlValue) = False Then
            Return "ERROR|Invalid hours" & "|" & HoursControlName
        End If
        If HoursControlValue <> String.Empty And IsNumeric(HoursControlValue) = True Then
            Hours = CType(HoursControlValue, Decimal)
            If Hours > 24 Then
                Return "ERROR|Invalid hours|" & HoursControlName
            End If
        End If

        If HoursControlValue = String.Empty Then
            Hours = 0.0
        End If

        Dim EtId As Integer = 0
        Dim EtDtlId As Integer = 0
        Dim TimeType As String = String.Empty
        Dim ar() As String
        ar = DataKey.Split("|")

        Try
            EtId = ar(7)
        Catch ex As Exception
            EtId = 0
        End Try
        Try
            EtDtlId = ar(8)
        Catch ex As Exception
            EtDtlId = 0
        End Try

        If EtId = 0 And EtDtlId = 0 And Hours = 0 Then
            Return String.Empty
        End If

        Try
            TimeType = ar(10)
        Catch ex As Exception
            TimeType = String.Empty
        End Try

        If TimeType = "D" And Hours > 0 And CommentControlValue = String.Empty Then
            Return "ERROR|Please enter a comment|" & CommentControlName
        Else
            ReturnMessage = SaveTime(DataKey, HoursControlName, HoursControlValue, False)
            If ReturnMessage.IndexOf("_SUCCESS") > -1 Then
                Dim arNewKey() As String
                arNewKey = ReturnMessage.Split("|")

                ReturnMessage = SaveComment(DataKey, CommentControlName, CommentControlValue)
            End If
        End If

        Return ReturnMessage

    End Function

    <System.Web.Services.WebMethod(True)>
    Public Shared Function GetFooterTotals(ByVal EmployeeCode As String, ByVal StartDate As String, ByVal EndDate As String) As String

        Dim cultureInfo As System.Globalization.CultureInfo
        Dim lg As New LoGlo()
        Dim DateStartDate As Date
        Dim DateEndDate As Date
        Dim Sun As Double = CType(0, Double)
        Dim Mon As Double = CType(0, Double)
        Dim Tue As Double = CType(0, Double)
        Dim Wed As Double = CType(0, Double)
        Dim Thu As Double = CType(0, Double)
        Dim Fri As Double = CType(0, Double)
        Dim Sat As Double = CType(0, Double)
        Dim Tot As Double = CType(0, Double)
        Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
        Dim c As New cTimeSheet(HttpContext.Current.Session("ConnString"))

        cultureInfo = lg.GetCultureInfo

        Try

            If Date.TryParse(StartDate, cultureInfo, DateTimeStyles.None, DateStartDate) = True AndAlso Date.TryParse(EndDate, cultureInfo, DateTimeStyles.None, DateEndDate) = True Then

                Dim CurrentTimesheet As AdvantageFramework.Timesheet.TimeSheet
                Dim s As String = ""
                CurrentTimesheet = AdvantageFramework.Timesheet.GetTimeSheet(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"),
                                                                             EmployeeCode, DateStartDate, DateEndDate, , s)

                AdvantageFramework.Timesheet.GetTotalsFromTimesheet(CurrentTimesheet, Sun, Mon, Tue, Wed, Thu, Fri, Sat, Tot)


                TsSettings = c.GetSessionTimesheetSettings(HttpContext.Current.Session("UserCode"))


            End If

        Catch ex As Exception
        End Try

        Return FormatNumber(Sun, 2) & "|" &
               FormatNumber(Mon, 2) & "|" &
               FormatNumber(Tue, 2) & "|" &
               FormatNumber(Wed, 2) & "|" &
               FormatNumber(Thu, 2) & "|" &
               FormatNumber(Fri, 2) & "|" &
               FormatNumber(Sat, 2) & "|" &
               FormatNumber(Tot, 2) & "|" &
               CType(TsSettings.StartTimesheetOnDayOfWeek, Integer).ToString()

    End Function

    Private Function ValidateEmployeeCode(ByVal EmpCode As String) As Boolean
        If EmpCode.Trim() <> String.Empty Then
            Me.TimesheetEmpCode = EmpCode
        Else
            Me.ShowMessage("Please select an Employee code.  If you are adding a new item, press the Cancel button first to re-enable the Employee Lookup")
            Me.txtEmpCode.Focus()
            Return False
        End If

        'Validate
        Dim oTraffic As cTraffic = New cTraffic(CStr(Session("ConnString")), CStr(Session("UserCode")))
        If oTraffic.IsEmpTerminated(Me.TimesheetEmpCode) Then
            Me.ShowMessage("This Employee code is inactive")
            Me.txtEmpCode.Focus()
            Return False
        End If
        If oTraffic.ValidateEmpCode(Me.TimesheetEmpCode) = False Then
            Me.ShowMessage("Invalid Employee code")
            Me.txtEmpCode.Focus()
            Return False
        End If

        Dim oEmp As cEmployee = New cEmployee(CStr(Session("ConnString")))
        If oEmp.GetName(Me.TimesheetEmpCode) <> String.Empty Then
            Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
            If oSec.CheckEmployees(Session("UserCode"), Me.TimesheetEmpCode, False, True) = False Then
                Me.txtEmpCode.Focus()
                Me.ShowMessage("Access to this Employee (" & Me.TimesheetEmpCode & ") is not allowed")
                Return False
            Else
                Session("TimesheetEmpCode") = Me.TimesheetEmpCode
                If Me.TimesheetEmpCode <> Session("EmpCode") Then
                    Me.txtEmpCode.BackColor = Color.LightSalmon
                Else
                    Me.txtEmpCode.CssClass = "RequiredInput"
                End If
                Return True
            End If
        Else
            Me.ShowMessage("Invalid Employee code")
            Me.txtEmpCode.Focus()
            Return False
        End If

    End Function
    Private Sub LoadDaysToShow()

        Me.RadComboBoxDayToShow.Items.Clear()

        'Me.RadComboBoxDayToShow.Items.Add(New RadComboBoxItem("All days", "all"))
        Me.RadComboBoxDayToShow.Items.Add(New RadComboBoxItem("7 days", "all7"))
        Me.RadComboBoxDayToShow.Items.Add(New RadComboBoxItem("5 days", "all5"))

        Dim TodayDayOfWeekForDefaultFirstEntry As Integer = 0

        For i As Integer = 0 To 6

            Dim DisplayText As String = Me.TimesheetStartDate.AddDays(i).ToString("dddd")

            If Me.TimesheetStartDate.AddDays(i) = cEmployee.TimeZoneToday Then

                DisplayText &= "*"

            End If

            Me.RadComboBoxDayToShow.Items.Add(New RadComboBoxItem(DisplayText, i.ToString()))

        Next

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Session("TimesheetMain_UserHasMadeASelection") Is Nothing Then 'First time opening timesheet since sign on

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim c As New cTimeSheet(Session("ConnString"))

                TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                Select Case TsSettings.DaysToDisplay

                    Case AdvantageFramework.Timesheet.TimesheetSettings.DaysToShow.Seven

                        Me.RadComboBoxDayToShow.SelectedIndex = 0

                    Case AdvantageFramework.Timesheet.TimesheetSettings.DaysToShow.Five

                        Me.RadComboBoxDayToShow.SelectedIndex = 1

                    Case AdvantageFramework.Timesheet.TimesheetSettings.DaysToShow.One

                        Me.RadComboBoxDayToShow.FindItemByValue(CType(cEmployee.TimeZoneToday.DayOfWeek, Integer).ToString()).Selected = True

                End Select

            Else

                If IsNumeric(Session("TimesheetMain_UserHasMadeASelection")) = True Then

                    Me.RadComboBoxDayToShow.FindItemByValue(Session("TimesheetMain_UserHasMadeASelection"))

                Else

                    Select Case Session("TimesheetMain_UserHasMadeASelection")

                        Case "all7"

                            Me.RadComboBoxDayToShow.SelectedIndex = 0

                        Case "all5"

                            Me.RadComboBoxDayToShow.SelectedIndex = 1

                    End Select

                End If

            End If

        End If

    End Sub

    Private Sub LoadGroupBy()
        Dim DaysToShow As Integer = 0
        Dim StartWeekOn As String = String.Empty
        Dim ShowCommentUsing As String = String.Empty
        Dim DivisionLabel As String = String.Empty
        Dim ProductLabel As String = String.Empty
        Dim ProductCategoryLabel As String = String.Empty
        Dim JobLabel As String = String.Empty
        Dim JobComponentLabel As String = String.Empty
        Dim FunctionCategoryLabel As String = String.Empty
        Dim c As New cTimeSheet(Session("ConnString"))
        Dim s As String = String.Empty

        Me.DropGroupBy.Items.Clear()

        Me.DropGroupBy.Items.Add(New RadComboBoxItem("[None]", String.Empty))
        Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client", "ClientName Client Group By ClientName"))
        If c.GetTimesheetSettings(Session("UserCode"), DaysToShow, StartWeekOn, ShowCommentUsing,
                        DivisionLabel, ProductLabel, ProductCategoryLabel, JobLabel, JobComponentLabel, FunctionCategoryLabel, s) = True Then
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/" & DivisionLabel, "ClientName Client, DivisionName [" & DivisionLabel & "] Group By ClientName, DivisionName"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/" & DivisionLabel & "/" & ProductLabel, "ClientName Client, DivisionName [" & DivisionLabel & "], ProductDescription [" & ProductLabel & "] Group By ClientName, DivisionName, ProductDescription"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/" & JobLabel, "ClientName Client, JobNumber [" & JobLabel & "] Group By ClientName, JobNumber"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/" & DivisionLabel & "/" & JobLabel, "ClientName Client, DivisionName [" & DivisionLabel & "], JobNumber [" & JobLabel & "] Group By ClientName, DivisionName, JobNumber"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/" & DivisionLabel & "/" & ProductLabel & "/" & JobLabel, "ClientName Client, DivisionName [" & DivisionLabel & "], ProductDescription [" & ProductLabel & "], JobNumber [" & JobLabel & "] Group By ClientName, DivisionName, ProductDescription, JobNumber"))
        Else
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/Division", "ClientName Client, DivisionName Division Group By ClientName, DivisionName"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/Division/Product", "ClientName Client, DivisionName Division, ProductDescription Product Group By ClientName, DivisionName, ProductDescription"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/Job", "ClientName Client, JobNumber Job Group By ClientName, JobNumber"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/Division/Job", "ClientName Client, DivisionName Division, JobNumber Job Group By ClientName, DivisionName, JobNumber"))
            Me.DropGroupBy.Items.Add(New RadComboBoxItem("Client/Division/Product/Job", "ClientName Client, DivisionName Division, ProductDescription Product, JobNumber Job Group By ClientName, DivisionName, ProductDescription, JobNumber"))
        End If

    End Sub

#End Region

End Class
