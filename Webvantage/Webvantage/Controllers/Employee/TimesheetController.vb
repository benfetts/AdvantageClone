Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Webvantage.Controllers
Imports Webvantage.ViewModels
Imports Webvantage.ViewModels.LookupObjects
Imports System.Threading
Imports System.Globalization
Imports System.IO
Imports AdvantageFramework.Timesheet.Methods

Namespace Controllers.Employee

    <Serializable()>
    Public Class TimesheetController
        Inherits MVCControllerBase

#Region " Constants "

        Private Const _DefaultUserTimesheetSort As String = "clientAsc"
        Public Const BaseRoute As String = "Employee/Timesheet/"
        Public Const UserSettingSessionKey As String = "LOLT20150321USSK"
        Public Const MyEmployeesSessionKey As String = "PBTT20071002MESK"
        Public Const AgencyAssignmentRequiredSessionKey As String = "LOLT20150321AARSK"
        Public Const CurrentEmployeeFunctionListSessionKey As String = "PBTT20071002CEFLSK"
        Public Const AgencyIndirectTimeCategoriesSessionKey As String = "LOLT20150321AITCSK"
        Public Const AgencyTimesheetOptionsSessionKey As String = "PBTT2007102ATSOSK"
        Public Const IsApprovalActiveSessionKey As String = "LOLT20150321IAASK"
        Public Const RequiredHoursBeforeApprovalSessionKey As String = "PBTT2007102RHBASK"
        Public Const RequiredHoursBeforeApprovalTypeSessionKey As String = "LOLT20150321RHBATSK"
        Public Const UserTimesheetSortSessionKey As String = "PBTT2007102UTSSSK"
        Public Const UserTimesheetGroupBySessionKey As String = "LOLT20150321UTSGBNSK"

#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Employee.TimesheetController = Nothing
        Private _MvcController As AdvantageFramework.Controller.Employee.TimesheetMvcController = Nothing

#End Region

#Region " Properties "

        Private Property PanelCSS As String
            Get
                If Session("PanelCSS_" & Me.SecuritySession.UserCode) Is Nothing Then Session("PanelCSS_" & Me.SecuritySession.UserCode) = "display: none;"
                Return Session("PanelCSS_" & Me.SecuritySession.UserCode)
            End Get
            Set(value As String)
                Session("PanelCSS_" & Me.SecuritySession.UserCode) = value
            End Set
        End Property

#End Region

#Region " Aurelia "

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Employee_Timesheet")>
        Public Function EmployeeTimesheet(ByVal EmployeeCode As String, ByVal Start As Date?) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/employee/timesheet/timesheet"
            AureliaModel.Parameters.Add("EmployeeCode", EmployeeCode)
            AureliaModel.Parameters.Add("Start", Start)

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " MVC Views "

        Public Function Index() As ActionResult

            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim NavType As AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation = AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.None
            Dim EmployeeCode As String = String.Empty
            Dim StartDate As Date = Today
            Dim DaysToDisplay As Integer = 0
            Dim CurrentCopyType As Integer? = -1
            Dim IsViewingSingleDay As Boolean = False
            Dim SortValue As String = String.Empty
            Dim GroupValue As String = String.Empty
            Dim SavedGroupValue As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)


                If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                    EmployeeCode = CurrentQueryString.EmployeeCode

                Else

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.StartDate) = False AndAlso IsDate(CurrentQueryString.StartDate) = True Then

                    StartDate = CDate(CurrentQueryString.StartDate)

                Else

                    StartDate = Today.Date

                End If

                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("dtd")) = False Then DaysToDisplay = CType(CurrentQueryString.Get("dtd"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("nav")) = False Then NavType = CType(CType(CurrentQueryString.Get("nav"), Integer), AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("cct")) = False Then CurrentCopyType = CType(CurrentQueryString.Get("cct"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("isdd")) = False Then IsViewingSingleDay = CType(CurrentQueryString.Get("isdd"), Integer) = 1
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("sort")) = False Then SortValue = CurrentQueryString.Get("sort")
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("grp")) = False Then GroupValue = CurrentQueryString.Get("grp")

                Try

                    If String.IsNullOrWhiteSpace(GroupValue) = True Then

                        GroupValue = Me.GetUserGroup(DbContext)

                    End If
                    ''''SavedGroupValue = GetUserGroup(DbContext)

                    ''''If Request.QueryString("grp") IsNot Nothing Then

                    ''''    GroupValue = CurrentQueryString.Get("grp")

                    ''''    'If SavedGroupValue <> GroupValue Then

                    ''''    '    SaveUserGroup(DbContext, GroupValue)

                    ''''    'End If

                    ''''Else

                    ''''    GroupValue = SavedGroupValue

                    ''''End If

                Catch ex As Exception
                    GroupValue = ""
                End Try

                If CurrentCopyType Is Nothing OrElse CurrentCopyType = -1 Then

                    PanelCSS = "display: none;"

                Else

                    PanelCSS = ""

                End If

                If String.IsNullOrWhiteSpace(SortValue) = True Then

                    SortValue = Me.GetUserSort(DbContext)

                End If

                Timesheet = Me.GetTimesheet(DbContext, EmployeeCode, StartDate, DaysToDisplay, NavType, IsViewingSingleDay, SortValue, GroupValue, False)

                ViewData("PanelCSS") = PanelCSS
                Timesheet.IsViewingSingleDay = IsViewingSingleDay
                If Timesheet.Days IsNot Nothing AndAlso Timesheet.Days.Count = 1 Then

                    Timesheet.IsViewingSingleDay = True

                End If

                Try
                    ViewData("SettingsDaysToDisplay") = Timesheet.UserSettings.DaysToDisplay
                Catch ex As Exception
                    ViewData("SettingsDaysToDisplay") = 5
                End Try

                ViewData("SortValue") = SortValue
                ViewData("GroupValue") = GroupValue

            End Using

            Return View(Timesheet)

        End Function
        Public Function _Timesheet(ByVal emp As String, ByVal sd As Date, ByVal dtd As Integer, ByVal nav As Short, ByVal cct As Short, ByVal isdd As Short) As ActionResult

            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim EmployeeCode As String = emp
                Dim StartDate As Date = sd
                Dim DaysToDisplay As Integer = dtd
                Dim NavType As AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation = AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Today
                Dim CurrentCopyType As Integer? = -1
                Dim IsViewingSingleDay As Boolean = False
                Dim SortValue As String = String.Empty
                Dim GroupValue As String = String.Empty
                Dim SavedGroupValue As String = String.Empty

                If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                    EmployeeCode = CurrentQueryString.EmployeeCode

                Else

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.StartDate) = False AndAlso IsDate(CurrentQueryString.StartDate) = True Then

                    StartDate = CDate(CurrentQueryString.StartDate)

                Else

                    StartDate = Today.Date

                End If

                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("dtd")) = False Then DaysToDisplay = CType(CurrentQueryString.Get("dtd"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("nav")) = False Then NavType = CType(CType(CurrentQueryString.Get("nav"), Integer), AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("cct")) = False Then CurrentCopyType = CType(CurrentQueryString.Get("cct"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("isdd")) = False Then IsViewingSingleDay = CType(CurrentQueryString.Get("isdd"), Integer) = 1
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("sort")) = False Then SortValue = CurrentQueryString.Get("sort")
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("grp")) = False Then GroupValue = CurrentQueryString.Get("grp")

                Try

                    If String.IsNullOrWhiteSpace(GroupValue) = True Then

                        GroupValue = Me.GetUserGroup(DbContext)

                    End If
                    ''SavedGroupValue = GetUserGroup(DbContext)

                    ''If Request.QueryString("grp") IsNot Nothing Then

                    ''    GroupValue = CurrentQueryString.Get("grp")

                    ''    'If SavedGroupValue <> GroupValue Then

                    ''    '    SaveUserGroup(DbContext, GroupValue)

                    ''    'End If

                    ''Else

                    ''    GroupValue = SavedGroupValue

                    ''End If

                Catch ex As Exception
                    GroupValue = ""
                End Try

                If CurrentCopyType Is Nothing OrElse CurrentCopyType = -1 Then

                    PanelCSS = "display: none;"

                Else

                    PanelCSS = ""

                End If
                If String.IsNullOrWhiteSpace(SortValue) = True Then

                    SortValue = Me.GetUserSort(DbContext)

                End If

                Timesheet = Me.GetTimesheet(DbContext, EmployeeCode, StartDate, DaysToDisplay, NavType, IsViewingSingleDay, SortValue, GroupValue, False)

                ViewData("PanelCSS") = PanelCSS
                Timesheet.IsViewingSingleDay = IsViewingSingleDay
                If Timesheet.Days IsNot Nothing AndAlso Timesheet.Days.Count = 1 Then

                    Timesheet.IsViewingSingleDay = True

                End If

                ViewData("SortValue") = SortValue
                ViewData("GroupValue") = GroupValue

            End Using

            Return PartialView(Timesheet)

        End Function
        Public Function Test() As ActionResult

            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim EmployeeCode As String = String.Empty
                Dim StartDate As Date
                Dim DaysToDisplay As Integer = 7
                Dim NavType As AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation = AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Today
                Dim CurrentCopyType As Integer? = -1
                Dim IsViewingSingleDay As Boolean = False
                Dim SortValue As String = String.Empty
                Dim GroupValue As String = String.Empty
                Dim SavedGroupValue As String = String.Empty

                If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                    EmployeeCode = CurrentQueryString.EmployeeCode

                Else

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.StartDate) = False AndAlso IsDate(CurrentQueryString.StartDate) = True Then

                    StartDate = CDate(CurrentQueryString.StartDate)

                Else

                    StartDate = Today.Date

                End If

                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("dtd")) = False Then DaysToDisplay = CType(CurrentQueryString.Get("dtd"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("nav")) = False Then NavType = CType(CType(CurrentQueryString.Get("nav"), Integer), AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("cct")) = False Then CurrentCopyType = CType(CurrentQueryString.Get("cct"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("isdd")) = False Then IsViewingSingleDay = CType(CurrentQueryString.Get("isdd"), Integer) = 1
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("sort")) = False Then SortValue = CurrentQueryString.Get("sort")
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("grp")) = False Then GroupValue = CurrentQueryString.Get("grp")

                Try

                    If String.IsNullOrWhiteSpace(GroupValue) = True Then

                        GroupValue = Me.GetUserGroup(DbContext)

                    End If

                Catch ex As Exception
                    GroupValue = ""
                End Try
                If CurrentCopyType Is Nothing OrElse CurrentCopyType = -1 Then

                    PanelCSS = "display: none;"

                Else

                    PanelCSS = ""

                End If
                If String.IsNullOrWhiteSpace(SortValue) = True Then

                    SortValue = Me.GetUserSort(DbContext)

                End If

                Timesheet = Me.GetTimesheet(DbContext, EmployeeCode, StartDate, DaysToDisplay, NavType, IsViewingSingleDay, SortValue, GroupValue, True)

                ViewData("PanelCSS") = PanelCSS
                Timesheet.IsViewingSingleDay = IsViewingSingleDay

                If Timesheet.Days IsNot Nothing AndAlso Timesheet.Days.Count = 1 Then

                    Timesheet.IsViewingSingleDay = True

                End If

                ViewData("SortValue") = SortValue
                ViewData("GroupValue") = GroupValue

            End Using

            Return View(Timesheet)

        End Function
        Public Function _Grid(ByVal emp As String,
                              ByVal sd As Date,
                              ByVal dtd As Integer,
                              ByVal nav As Short,
                              ByVal cct As Short,
                              ByVal isdd As Short) As ActionResult

            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim EmployeeCode As String = emp
                Dim StartDate As Date = sd
                Dim DaysToDisplay As Integer = dtd
                Dim NavType As AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation = AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Today
                Dim CurrentCopyType As Integer? = -1
                Dim IsViewingSingleDay As Boolean = False
                Dim SortValue As String = String.Empty
                Dim GroupValue As String = String.Empty
                Dim SavedGroupValue As String = String.Empty

                If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                    EmployeeCode = CurrentQueryString.EmployeeCode

                Else

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.StartDate) = False AndAlso IsDate(CurrentQueryString.StartDate) = True Then

                    StartDate = CDate(CurrentQueryString.StartDate)

                Else

                    StartDate = Today.Date

                End If

                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("dtd")) = False Then DaysToDisplay = CType(CurrentQueryString.Get("dtd"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("nav")) = False Then NavType = CType(CType(CurrentQueryString.Get("nav"), Integer), AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("cct")) = False Then CurrentCopyType = CType(CurrentQueryString.Get("cct"), Integer)
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("isdd")) = False Then IsViewingSingleDay = CType(CurrentQueryString.Get("isdd"), Integer) = 1
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("sort")) = False Then SortValue = CurrentQueryString.Get("sort")
                If String.IsNullOrWhiteSpace(CurrentQueryString.Get("grp")) = False Then GroupValue = CurrentQueryString.Get("grp")

                Try

                    If String.IsNullOrWhiteSpace(GroupValue) = True Then

                        GroupValue = Me.GetUserGroup(DbContext)

                    End If
                    ''SavedGroupValue = GetUserGroup(DbContext)

                    ''If Request.QueryString("grp") IsNot Nothing Then

                    ''    GroupValue = CurrentQueryString.Get("grp")

                    ''    'If SavedGroupValue <> GroupValue Then

                    ''    '    SaveUserGroup(DbContext, GroupValue)

                    ''    'End If

                    ''Else

                    ''    GroupValue = SavedGroupValue

                    ''End If

                Catch ex As Exception
                    GroupValue = ""
                End Try

                If CurrentCopyType Is Nothing OrElse CurrentCopyType = -1 Then

                    PanelCSS = "display: none;"

                Else

                    PanelCSS = ""

                End If
                If String.IsNullOrWhiteSpace(SortValue) = True Then

                    SortValue = Me.GetUserSort(DbContext)

                End If

                Timesheet = Me.GetTimesheet(DbContext, EmployeeCode, StartDate, DaysToDisplay, NavType, IsViewingSingleDay, SortValue, GroupValue, True)

                ViewData("PanelCSS") = PanelCSS
                Timesheet.IsViewingSingleDay = IsViewingSingleDay
                If Timesheet.Days IsNot Nothing AndAlso Timesheet.Days.Count = 1 Then

                    Timesheet.IsViewingSingleDay = True

                End If

                ViewData("SortValue") = SortValue
                ViewData("GroupValue") = GroupValue

            End Using

            Return PartialView(Timesheet)

        End Function

        Public Function Entry() As ActionResult

            Dim NewEntry As New AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim EmployeeCode As String = String.Empty
                Dim StartDate As Date = Today
                Dim TimeType As String = String.Empty
                Dim SearchText As String = String.Empty
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0
                Dim AlertID As Integer = 0
                Dim EmployeeDefaultFunctionCode As String = String.Empty

                If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                    EmployeeCode = CurrentQueryString.EmployeeCode

                Else

                    EmployeeCode = Me.SecuritySession.User.EmployeeCode

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.StartDate) = False AndAlso IsDate(CurrentQueryString.StartDate) Then

                    StartDate = CDate(CurrentQueryString.StartDate)

                Else

                    'StartDate = Today.Date
                    StartDate = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmployeeCode)

                End If
                If String.IsNullOrWhiteSpace(CurrentQueryString.TimeType) = False Then

                    TimeType = CurrentQueryString.TimeType

                Else

                    TimeType = "D"

                End If

                If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
                If CurrentQueryString.JobNumber > 0 Then JobNumber = CurrentQueryString.JobNumber
                If CurrentQueryString.JobComponentNumber > 0 Then JobComponentNumber = CurrentQueryString.JobComponentNumber
                If CurrentQueryString.AlertID > 0 Then AlertID = CurrentQueryString.AlertID

                NewEntry.Entry.Date = StartDate
                NewEntry.AssignmentIsRequired = Me.AssignmentRequired
                NewEntry.Entry.CommentsRequired = NewEntry.CommentIsRequired

                If JobNumber > 0 Then

                    NewEntry.CommentIsRequired = Me._MvcController.IsCommentRequiredJob(DbContext, JobNumber)
                    NewEntry.Entry.CommentsRequired = NewEntry.CommentIsRequired

                End If

                ViewData("EmployeeCode") = EmployeeCode
                ViewData("EmployeeDefaultFunctionCode") = _EmployeeDefaultFunction(EmployeeCode)
                ViewData("TimeType") = TimeType.ToUpper
                ViewData("IsDirectTime") = (TimeType.ToUpper = "D").ToString.ToLower
                ViewData("CommentIsRequired") = NewEntry.CommentIsRequired.ToString.ToLower

            End Using
            Return View(NewEntry)

        End Function
        Public Function Day() As ActionResult

        End Function
        Public Function Line() As ActionResult

        End Function
        Public Function LineDetails() As ActionResult

        End Function
        Public Function Settings() As ActionResult

            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing
            Dim AgencyOverride As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If Session(UserSettingSessionKey) IsNot Nothing Then

                    UserSettings = CType(Session(UserSettingSessionKey), AdvantageFramework.ViewModels.Employee.Timesheet.Settings)

                Else

                    UserSettings = LoadAllUserSettings(DbContext)
                    Session(UserSettingSessionKey) = UserSettings

                End If

                Try

                    AgencyOverride = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = '{0}';",
                                                                                           AdvantageFramework.Agency.Settings.TS_AGY_OVRRDE.ToString)).SingleOrDefault

                Catch ex As Exception
                    AgencyOverride = False
                End Try

            End Using

            ViewData("AgencyOverride") = AgencyOverride

            Return View(UserSettings)

        End Function

        Public Function TimeTemplates() As ActionResult

            Return View(GetEmployeeTimeTemplatesView())

        End Function
        Public Function _TimeTemplatesGrid() As ActionResult

            'If String.IsNullOrWhiteSpace(CurrentQueryString.Get("refresh")) = False AndAlso
            '    CType(CurrentQueryString.Get("refresh"), Short) = 1 Then


            'End If
            Return PartialView(GetEmployeeTimeTemplatesView())

        End Function

#End Region

#Region " API "

#Region " Get "

#Region " Active "
        Private Function GetUserGroup(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim GroupValue As String = ""

            If Session(UserTimesheetGroupBySessionKey) Is Nothing Then

                Try

                    GroupValue = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(VARIABLE_VALUE, '') FROM APP_VARS WITH(NOLOCK) WHERE USERID = '{0}' AND [APPLICATION] = 'TIMESHEET' AND VARIABLE_NAME = 'GROUP';", Me.SecuritySession.UserCode)).SingleOrDefault

                Catch ex As Exception
                    GroupValue = _DefaultUserTimesheetSort
                End Try

                Session(UserTimesheetGroupBySessionKey) = GroupValue

            Else

                GroupValue = Session(UserTimesheetGroupBySessionKey)

            End If

            If String.IsNullOrWhiteSpace(GroupValue) = True Then GroupValue = ""

            Return GroupValue

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveUserGroup(ByVal GroupBy As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Me._SaveUserGroup(DbContext, GroupBy)

                    If Success = True Then

                        ReturnObject = New With {.GroupBy = GroupBy}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        Private Function _SaveUserGroup(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal GroupBy As String) As Boolean

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)

            Try

                av.getAllAppVars()
                av.setAppVar("GROUP", GroupBy, "String")
                av.SaveAllAppVars()
                Success = True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try
            If Success = True Then

                Session(UserTimesheetGroupBySessionKey) = GroupBy

            Else

                Session(UserTimesheetGroupBySessionKey) = ""

            End If

        End Function
        Private Function GetUserSort(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim SortValue As String = _DefaultUserTimesheetSort

            If Session(UserTimesheetSortSessionKey) Is Nothing Then

                Try

                    SortValue = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(VARIABLE_VALUE, '') FROM APP_VARS WITH(NOLOCK) WHERE USERID = '{0}' AND [APPLICATION] = 'TIMESHEET' AND VARIABLE_NAME = 'SORT';", Me.SecuritySession.UserCode)).SingleOrDefault

                Catch ex As Exception
                    SortValue = _DefaultUserTimesheetSort
                End Try

                Session(UserTimesheetSortSessionKey) = SortValue

            Else

                SortValue = Session(UserTimesheetSortSessionKey)

            End If

            If String.IsNullOrWhiteSpace(SortValue) = True Then SortValue = _DefaultUserTimesheetSort

            Return SortValue

        End Function

        <HttpGet>
        Public Function GetUserTimesheetSort() As JsonResult

            Dim SortValue As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                SortValue = GetUserSort(DbContext)

            End Using

            Return Json(SortValue, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetStartOfWeekOn() As JsonResult

            Dim LoGlo As New Webvantage.LoGlo
            Dim c As CultureInfo = LoGlo.GetCultureInfo()
            Dim Days As String()

            Days = c.CurrentCulture.DateTimeFormat.DayNames

            Dim StartOfWeek As New Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.SettingsOptions.StartWeekDay)

            Dim TheDay As AdvantageFramework.ViewModels.Employee.Timesheet.SettingsOptions.StartWeekDay = Nothing

            TheDay = New AdvantageFramework.ViewModels.Employee.Timesheet.SettingsOptions.StartWeekDay
            TheDay.DayOfWeek = CType(DayOfWeek.Sunday, Integer)
            TheDay.Day = Days(TheDay.DayOfWeek)
            StartOfWeek.Add(TheDay)
            TheDay = Nothing

            TheDay = New AdvantageFramework.ViewModels.Employee.Timesheet.SettingsOptions.StartWeekDay
            TheDay.DayOfWeek = CType(DayOfWeek.Monday, Integer)
            TheDay.Day = Days(TheDay.DayOfWeek)
            StartOfWeek.Add(TheDay)
            TheDay = Nothing

            TheDay = New AdvantageFramework.ViewModels.Employee.Timesheet.SettingsOptions.StartWeekDay
            TheDay.DayOfWeek = CType(DayOfWeek.Saturday, Integer)
            TheDay.Day = Days(TheDay.DayOfWeek)
            StartOfWeek.Add(TheDay)
            TheDay = Nothing

            Return Json(StartOfWeek, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsCurrentWeek(ByVal StartDate As Date) As JsonResult

            Return Json(_IsCurrentWeek(StartDate), JsonRequestBehavior.AllowGet)

        End Function
        Public Function _IsCurrentWeek(ByVal StartDate As Date) As Boolean

            Dim CurrentWeek As Boolean = False
            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing
            Dim FirstDayOfCurrentWeek As Date
            Dim FirstDayOfSelectedWeek As Date

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If Session(UserSettingSessionKey) IsNot Nothing Then

                    UserSettings = CType(Session(UserSettingSessionKey), AdvantageFramework.ViewModels.Employee.Timesheet.Settings)

                Else

                    UserSettings = LoadAllUserSettings(DbContext)
                    Session(UserSettingSessionKey) = UserSettings

                End If

            End Using

            If UserSettings IsNot Nothing Then

                FirstDayOfCurrentWeek = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(Today.Date, UserSettings, 7)
                FirstDayOfSelectedWeek = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, 7)

            End If

            CurrentWeek = FirstDayOfCurrentWeek = FirstDayOfSelectedWeek

            Return CurrentWeek

        End Function

        <HttpGet>
        Public Function GetEntryDetailsFromAlertID(ByVal AlertID As Integer) As JsonResult

            Dim NewEntry As New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            If CurrentQueryString.AlertID > 0 Then AlertID = CurrentQueryString.AlertID

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    NewEntry.AlertID = Alert.ID
                    NewEntry.JobNumber = Alert.JobNumber
                    NewEntry.JobComponentNumber = Alert.JobComponentNumber

                End If

            End Using

            NewEntry.FunctionCategoryCode = _EmployeeDefaultFunction(SecuritySession.User.EmployeeCode)
            NewEntry.TimeType = "D"

            Return MaxJson(NewEntry, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimesheetDashboard() As JsonResult

            Dim TimesheetDashboard As AdvantageFramework.ViewModels.Employee.Timesheet.DashboardViewModel = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim LegacyDesktopObjects As New cDesktopObjects(SecuritySession.ConnectionString)
                Dim LegacyTimesheetClass As Webvantage.wvTimeSheet.cTimeSheet = New Webvantage.wvTimeSheet.cTimeSheet(SecuritySession.ConnectionString)
                Dim TimesheetDataTable As New DataTable
                Dim HoursByTypeDataTable As New DataTable
                Dim HoursToday As Double = 0.0
                Dim HoursThisWeek As Double = 0.0
                Dim RequiredHoursToday As Double = 0.0
                Dim RequiredHoursThisWeek As Double = 0.0
                Dim HasMissingOrDeniedTime As Boolean = False
                Dim AgencyHoursThisWeek As Double = 0.0
                Dim ClientHoursThisWeek As Double = 0.0
                Dim NewBusinessHoursThisWeek As Double = 0.0
                Dim IndirectHoursThisWeek As Double = 0.0
                Dim DirectHoursGoal As Double = 0.0
                Dim UC As UserColors = Nothing

                TimesheetDataTable = LegacyDesktopObjects.GetTimesheetDTO(CurrentEmployeeCode)
                HoursByTypeDataTable = LegacyDesktopObjects.GetHoursByTypeDTO(CurrentEmployeeCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, CurrentEmployeeCode)

                If TimesheetDataTable IsNot Nothing Then

                    Try

                        For i As Integer = 0 To TimesheetDataTable.Rows.Count - 1

                            If CType(TimesheetDataTable.Rows(i)("DayDisplay"), Date).ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then

                                HoursToday = CType(TimesheetDataTable.Rows(i)("Hours"), Double)
                                RequiredHoursToday = CType(TimesheetDataTable.Rows(i)("HoursGoal"), Double)
                                Exit For

                            End If

                        Next

                        HoursThisWeek = TimesheetDataTable.Compute("Sum(Hours)", "")
                        RequiredHoursThisWeek = TimesheetDataTable.Compute("Sum(HoursGoal)", "")

                    Catch ex As Exception
                    End Try

                End If

                If HoursByTypeDataTable IsNot Nothing AndAlso HoursByTypeDataTable.Rows.Count > 0 Then

                    Try
                        ClientHoursThisWeek = HoursByTypeDataTable.Rows(0)("Client")
                        AgencyHoursThisWeek = HoursByTypeDataTable.Rows(0)("Agency")
                        NewBusinessHoursThisWeek = HoursByTypeDataTable.Rows(0)("New Business")
                        IndirectHoursThisWeek = HoursByTypeDataTable.Rows(0)("Indirect")
                    Catch ex As Exception

                    End Try

                End If

                If Employee IsNot Nothing Then

                    If Employee.DirectHours IsNot Nothing Then
                        DirectHoursGoal = RequiredHoursThisWeek * (Employee.DirectHours / 100)
                    End If

                End If

                Try

                    HasMissingOrDeniedTime = LegacyTimesheetClass.HasMissingOrDeniedTime()

                Catch ex As Exception
                    HasMissingOrDeniedTime = False
                End Try

                HoursToday = FormatNumber(HoursToday, 2)
                HoursThisWeek = FormatNumber(HoursThisWeek, 2)

                TimesheetDashboard = New AdvantageFramework.ViewModels.Employee.Timesheet.DashboardViewModel

                TimesheetDashboard.GoalHoursToday = RequiredHoursToday
                TimesheetDashboard.HoursToday = HoursToday
                TimesheetDashboard.GoalHoursThisWeek = DirectHoursGoal
                TimesheetDashboard.AgencyHoursThisWeek = AgencyHoursThisWeek
                TimesheetDashboard.NewBusinessHoursThisWeek = NewBusinessHoursThisWeek
                TimesheetDashboard.ClientHoursThisWeek = ClientHoursThisWeek
                TimesheetDashboard.IndirectHoursThisWeek = IndirectHoursThisWeek
                TimesheetDashboard.RequiredHoursThisWeek = RequiredHoursThisWeek

                If AgencyHoursThisWeek = 0 And NewBusinessHoursThisWeek = 0 And ClientHoursThisWeek = 0 And IndirectHoursThisWeek = 0 Then

                    TimesheetDashboard.RequiredHoursThisWeekByType = RequiredHoursThisWeek

                Else

                    TimesheetDashboard.RequiredHoursThisWeekByType = 0.0

                End If

                TimesheetDashboard.HoursThisWeek = HoursThisWeek

                Try

                    UC = GetUserColors(DbContext)

                Catch ex As Exception
                    UC = Nothing
                End Try

                If UC IsNot Nothing AndAlso TimesheetDashboard IsNot Nothing Then

                    TimesheetDashboard.Color = UC.Primary
                    TimesheetDashboard.DarkColor = UC.AltPrimary

                End If

            End Using

            Return MaxJson(TimesheetDashboard, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimeEntry(ByVal IsDirectTime As Boolean, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short) As JsonResult

            Dim Entry As New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Entry = _MvcController.GetTimeEntry(DbContext, IsDirectTime, EmployeeTimeID, EmployeeTimeDetailID)

            End Using

            Return Json(Entry, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimeEntryCommentHTML() As JsonResult

            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim Comment As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Try

                EmployeeTimeComment = GetTimeEntryCommentObject()
                Comment = EmployeeTimeComment.EmployeeComments

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(System.Net.WebUtility.HtmlEncode(Comment), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimeEntryCommentText() As String

            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim Comment As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Try

                EmployeeTimeComment = GetTimeEntryCommentObject()
                Comment = EmployeeTimeComment.EmployeeComments.Replace(vbLf, "<br/>").Replace(vbCrLf, "<br/>").Replace(Environment.NewLine, "<br/>")

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Comment

        End Function
        <HttpGet>
        Public Function GetTimeEntryComment(ByVal IsDirectTime As Boolean, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short) As JsonResult

            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                EmployeeTimeComment = _MvcController.GetTimeEntryComment(DbContext, IsDirectTime, EmployeeTimeID, EmployeeTimeDetailID)

            End Using

            Return MaxJson(EmployeeTimeComment, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetJobDisplay(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim JobDisplay As String = String.Empty
            Dim ClientDivisionProductDisplay As String = String.Empty
            Dim ClientName As String = String.Empty
            Dim DivisionName As String = String.Empty
            Dim ProductName As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                JobDisplay = _MvcController.GetJobDisplay(DbContext, JobNumber, JobComponentNumber)
                ClientDivisionProductDisplay = _MvcController.GetClientDivisionProductDisplay(DbContext, JobNumber, ClientName, DivisionName, ProductName)

            End Using

            Return Json(New With {.JobDisplay = JobDisplay,
                                  .ClientDivisionProductDisplay = ClientDivisionProductDisplay,
                                  .ClientName = ClientName,
                                  .DivisionName = DivisionName,
                                  .ProductName = ProductName}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAssignmentSubject(ByVal AlertID As Integer) As JsonResult

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Return Json(_MvcController.GetAssignmentSubject(DbContext, AlertID), JsonRequestBehavior.AllowGet)

            End Using

        End Function
        <HttpGet>
        Public Function GetClientDivisionProductDisplay(ByVal JobNumber As Integer) As JsonResult

            Dim ClientName As String = String.Empty
            Dim DivisionName As String = String.Empty
            Dim ProductName As String = String.Empty
            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Return Json(_MvcController.GetClientDivisionProductDisplay(DbContext, JobNumber, ClientName, DivisionName, ProductName), JsonRequestBehavior.AllowGet)

            End Using

        End Function
        <HttpGet>
        Public Function GetFunctionCategoryDescription(ByVal FunctionCategoryCode As String, ByVal IsFunction As Boolean) As JsonResult

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Return Json(_MvcController.GetFunctionCategoryDescription(DbContext, FunctionCategoryCode, IsFunction), JsonRequestBehavior.AllowGet)

            End Using

        End Function
        <HttpGet>
        Public Function GetMonthlyHours() As JsonResult

            Dim MonthlyHours As AdvantageFramework.ViewModels.Employee.Timesheet.MonthlyHoursViewModel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Try

                    MonthlyHours = _MvcController.GetMonthlyHours(DbContext, SecuritySession.User.EmployeeCode)

                Catch ex As Exception
                    MonthlyHours = Nothing
                End Try

            End Using

            If MonthlyHours Is Nothing Then MonthlyHours = New AdvantageFramework.ViewModels.Employee.Timesheet.MonthlyHoursViewModel

            Return Json(MonthlyHours, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimeSummary() As JsonResult

            Dim Summaries As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Summaries = _MvcController.GetTimeSummary(DbContext, SecuritySession.User.EmployeeCode, Nothing, Nothing)

            End Using

            Return Json(Summaries, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimesheetDayHeader(ByVal EmployeeCode As String, ByVal ActiveDate As Date, ByVal StartDate As Date) As JsonResult

            Dim Summaries As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel) = Nothing

            If String.IsNullOrWhiteSpace(EmployeeCode) = True Then EmployeeCode = SecuritySession.User.EmployeeCode


            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Summaries = _MvcController.GetTimeSummary(DbContext, EmployeeCode, 7, ActiveDate)

                If Summaries IsNot Nothing Then

                    Dim LoGlo As New Webvantage.LoGlo

                    For Each TimeSummary As AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel In Summaries

                        If TimeSummary.DayDisplay IsNot Nothing Then

                            LoGlo.MvcTimesheetHeader(TimeSummary.DayDisplay, TimeSummary.ShortDayOfWeek, TimeSummary.DayMonthDisplay)

                        End If

                    Next

                Else

                    Summaries = New List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimeSummaryViewModel)

                End If

            End Using

            Return Json(Summaries, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function UserLimited() As JsonResult

            Dim IsLimited As Boolean = False
            Dim SessionKey As String = "UserLimited" & Me.SecuritySession.UserCode

            If HttpContext.Session(SessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Dim myReturn As String = ""
                    Try

                        myReturn = DbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[usp_wv_ts_check_emp] '{0}';", Me.SecuritySession.UserCode)).SingleOrDefault

                    Catch
                        myReturn = ""
                    End Try

                    If myReturn.ToUpper().Trim() = "Y" Then

                        IsLimited = True

                    Else

                        IsLimited = False

                    End If

                    HttpContext.Session(SessionKey) = IsLimited

                End Using

            Else

                IsLimited = CType(HttpContext.Session(SessionKey), Boolean)

            End If

            Return MaxJson(IsLimited, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetFunctionsAndCategories(ByVal EmployeeCode As String, ByVal TimeType As String,
                                                  ByVal JobNumber As Integer?, ByVal ClientCode As String) As JsonResult

            Dim FunctionCategories As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory)
            Dim SearchText As String = String.Empty
            Dim IsMe As Boolean = False

            If JobNumber Is Nothing Then JobNumber = 0

            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            IsMe = EmployeeCode = Me.SecuritySession.User.EmployeeCode

            If TimeType = "D" Then 'Direct Time

                If IsMe = True Then

                    If Session(CurrentEmployeeFunctionListSessionKey) Is Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                            FunctionCategories = _MvcController.GetFunctionsAndCategories(DbContext, EmployeeCode, True, False, "")

                            'If IncludePleaseSelect = True Then

                            '    PleaseSelectFunctionCategoryLookupEntry.Code = ""
                            '    PleaseSelectFunctionCategoryLookupEntry.Description = "[Please select]"
                            '    FunctionCategories.Insert(0, PleaseSelectFunctionCategoryLookupEntry)

                            'End If

                        End Using

                        Session(CurrentEmployeeFunctionListSessionKey) = FunctionCategories

                    Else

                        FunctionCategories = CType(Session(CurrentEmployeeFunctionListSessionKey), Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory))

                    End If

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        FunctionCategories = _MvcController.GetFunctionsAndCategories(DbContext, EmployeeCode, True, False, SearchText)

                        'If IncludePleaseSelect = True Then

                        '    PleaseSelectFunctionCategoryLookupEntry.Code = ""
                        '    PleaseSelectFunctionCategoryLookupEntry.Description = "[Please select]"
                        '    FunctionCategories.Insert(0, PleaseSelectFunctionCategoryLookupEntry)

                        'End If

                    End Using

                End If

                If JobNumber > 0 OrElse String.IsNullOrWhiteSpace(ClientCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Dim LimitFunctionsByBillingRate As Boolean = False
                        Dim BillingRestrictedFunctionCodes As Generic.List(Of String) = Nothing

                        If String.IsNullOrWhiteSpace(ClientCode) = True Then

                            Try

                                ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = {0};", JobNumber)).SingleOrDefault

                            Catch ex As Exception
                                ClientCode = String.Empty
                            End Try

                        End If
                        If String.IsNullOrWhiteSpace(ClientCode) = False Then

                            Try

                                LimitFunctionsByBillingRate = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault

                            Catch ex As Exception
                                LimitFunctionsByBillingRate = False
                            End Try

                        End If
                        If LimitFunctionsByBillingRate = True Then

                            Try

                                BillingRestrictedFunctionCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_CODE FROM BILLING_RATE WHERE CL_CODE = '{0}' AND NOT FNC_CODE IS NULL;", ClientCode)).ToList

                            Catch ex As Exception
                                BillingRestrictedFunctionCodes = Nothing
                            End Try

                            If BillingRestrictedFunctionCodes Is Nothing Then BillingRestrictedFunctionCodes = New List(Of String)

                            If BillingRestrictedFunctionCodes IsNot Nothing Then

                                Dim RestrictedList As New Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory)
                                Dim RestrictedListCreated As Boolean = False

                                Try

                                    RestrictedList = (From Entity In FunctionCategories
                                                      Where Entity.Code = "" Or BillingRestrictedFunctionCodes.Contains(Entity.Code)
                                                      Select Entity).ToList
                                    RestrictedListCreated = True

                                Catch ex As Exception
                                    RestrictedListCreated = False
                                End Try

                                If RestrictedListCreated = False Then

                                    For Each Fn In FunctionCategories

                                        If String.IsNullOrWhiteSpace(Fn.Code) = True OrElse BillingRestrictedFunctionCodes.Contains(Fn.Code) = True Then

                                            RestrictedList.Add(Fn)

                                        End If

                                    Next

                                End If

                                FunctionCategories = RestrictedList

                            End If

                        End If

                    End Using

                End If

            Else 'Category

                If Session(AgencyIndirectTimeCategoriesSessionKey) Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        FunctionCategories = _MvcController.GetFunctionsAndCategories(DbContext, EmployeeCode, False, True, "")

                        'If IncludePleaseSelect = True Then

                        '    PleaseSelectFunctionCategoryLookupEntry.Code = ""
                        '    PleaseSelectFunctionCategoryLookupEntry.Description = "[Please select]"
                        '    FunctionCategories.Insert(0, PleaseSelectFunctionCategoryLookupEntry)

                        'End If

                    End Using

                    Session(AgencyIndirectTimeCategoriesSessionKey) = FunctionCategories

                Else

                    FunctionCategories = CType(Session(AgencyIndirectTimeCategoriesSessionKey), Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel.FunctionCategory))

                End If

            End If

            If String.IsNullOrWhiteSpace(SearchText) = False Then

                Return MaxJson((From Entity In FunctionCategories
                                Where Entity.Code.ToLower.Contains(SearchText.ToLower) Or Entity.Description.ToLower.Contains(SearchText.ToLower)
                                Select Entity).ToList, JsonRequestBehavior.AllowGet)

            Else

                Return MaxJson(FunctionCategories, JsonRequestBehavior.AllowGet)

            End If

        End Function

        <HttpGet>
        Public Function GetClientsForEmployee() As JsonResult

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            'Dim PleaseSelectClientLookupEntry As New AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem
            Dim EmployeeCode As String = String.Empty
            Dim SearchText As String = String.Empty
            Dim ClientCode As String = String.Empty
            Dim DivisionCode As String = String.Empty
            Dim ProductCode As String = String.Empty

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If

            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.DivisionCode) = False Then DivisionCode = CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.ProductCode) = False Then ProductCode = CurrentQueryString.ProductCode

            Results = _MvcController.LoadClientsForEmployee(Me.SecuritySession, EmployeeCode, SearchText, ClientCode, DivisionCode, ProductCode)

            'PleaseSelectClientLookupEntry.Key = ""
            'PleaseSelectClientLookupEntry.CDP = "[Please select]"

            'Results.Insert(0, PleaseSelectClientLookupEntry)

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetClients(ByVal EmployeeCode As String,
                                   ByVal ClientCode As String,
                                   ByVal Text As String) As JsonResult

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            'Dim PleaseSelectClientLookupEntry As New AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem
            Dim SearchText As String = String.Empty

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If
            If String.IsNullOrWhiteSpace(Text) = False Then

                SearchText = Text

            End If
            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode

            Results = _MvcController.LoadClients(Me.SecuritySession, EmployeeCode, SearchText, ClientCode, "")

            'PleaseSelectClientLookupEntry.Key = ""
            'PleaseSelectClientLookupEntry.CDP = "[Please select]"

            'Results.Insert(0, PleaseSelectClientLookupEntry)

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetDivisions(ByVal EmployeeCode As String,
                                     ByVal ClientCode As String,
                                     ByVal DivisionCode As String,
                                     ByVal ProductCode As String) As JsonResult

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            'Dim PleaseSelectDivisionLookupEntry As New AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem
            Dim SearchText As String = String.Empty

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If

            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.DivisionCode) = False Then DivisionCode = CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.ProductCode) = False Then ProductCode = CurrentQueryString.ProductCode

            Results = _MvcController.LoadDivisions(Me.SecuritySession, EmployeeCode, SearchText, ClientCode, DivisionCode)

            'PleaseSelectDivisionLookupEntry.Key = ""
            'PleaseSelectDivisionLookupEntry.CDP = "[Please select]"

            'Results.Insert(0, PleaseSelectDivisionLookupEntry)

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetProducts(ByVal EmployeeCode As String,
                                    ByVal ClientCode As String,
                                    ByVal DivisionCode As String,
                                    ByVal ProductCode As String) As JsonResult

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem) = Nothing
            'Dim PleaseSelectProductLookupEntry As New AdvantageFramework.Controller.Employee.ClientDivisionProductLookupItem
            Dim SearchText As String = String.Empty

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If

            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.DivisionCode) = False Then DivisionCode = CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.ProductCode) = False Then ProductCode = CurrentQueryString.ProductCode

            Results = _MvcController.LoadProducts(Me.SecuritySession, EmployeeCode, SearchText, ClientCode, DivisionCode, ProductCode)

            'PleaseSelectProductLookupEntry.Key = ""
            'PleaseSelectProductLookupEntry.CDP = "[Please select]"

            'Results.Insert(0, PleaseSelectProductLookupEntry)

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function

        '<HttpGet>
        'Public Function GetJobsForEmployeeVirtualScrolling(ByVal Value As Syncfusion.JavaScript.DataManager) As JsonResult

        '    Dim Query As Generic.List(Of Syncfusion.JavaScript.WhereFilter) = Nothing
        '    Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.LookupItem) = Nothing
        '    Dim Result As Generic.List(Of AdvantageFramework.Controller.Employee.LookupItem) = Nothing
        '    Dim PleaseSelectJobLookupEntry As New AdvantageFramework.Controller.Employee.LookupItem
        '    Dim EmployeeCode As String = String.Empty
        '    Dim SearchText As String = String.Empty
        '    Dim ClientCode As String = String.Empty
        '    Dim DivisionCode As String = String.Empty
        '    Dim ProductCode As String = String.Empty
        '    Dim JobNumber As Integer = 0
        '    Dim Skip As Integer = 0
        '    Dim Take As Integer = 0
        '    Dim ReturnObject As Object = Nothing
        '    Dim HasQuery As Boolean = False
        '    Dim HasQueryDescription As Boolean = False
        '    Dim QueryDescription As String = String.Empty

        '    If Value IsNot Nothing Then

        '        Skip = Value.Skip
        '        Take = Value.Take

        '        If Value.Where IsNot Nothing Then

        '            Query = Value.Where

        '            If Query IsNot Nothing AndAlso Query.Any Then

        '                HasQuery = True

        '                For Each Item As Syncfusion.JavaScript.WhereFilter In Query

        '                    If HasQueryDescription = False Then

        '                        Try

        '                            QueryDescription = Item.value
        '                            HasQueryDescription = True

        '                        Catch ex As Exception
        '                            HasQueryDescription = False
        '                            QueryDescription = String.Empty
        '                        End Try

        '                    End If

        '                Next

        '            End If

        '        End If

        '    End If
        '    Try
        '        If Skip = 0 AndAlso Request.QueryString("$skip") IsNot Nothing Then
        '            Skip = Request.QueryString("$skip")
        '        End If
        '    Catch ex As Exception
        '        Skip = 0
        '    End Try
        '    Try
        '        If Take = 0 AndAlso Request.QueryString("$top") IsNot Nothing Then
        '            Take = Request.QueryString("$top")
        '        End If
        '    Catch ex As Exception
        '        Take = 0
        '    End Try
        '    If Take = 0 Then Take = 200
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.EmpCode) = False Then

        '        EmployeeCode = CurrentQueryString.EmpCode

        '    Else

        '        EmployeeCode = Me.SecuritySession.User.EmployeeCode

        '    End If
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.ClCode) = False Then ClientCode = CurrentQueryString.ClCode
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.DivCode) = False Then DivisionCode = CurrentQueryString.DivCode
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.PrdCode) = False Then ProductCode = CurrentQueryString.PrdCode
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.JobNumber) = False AndAlso IsNumeric(CurrentQueryString.JobNumber) AndAlso CType(CurrentQueryString.JobNumber, Integer) > 0 Then JobNumber = CurrentQueryString.JobNumber
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.Skip) = False AndAlso IsNumeric(CurrentQueryString.Skip) AndAlso CType(CurrentQueryString.Skip, Integer) > 0 Then Skip = CurrentQueryString.Skip
        '    If String.IsNullOrWhiteSpace(CurrentQueryString.Take) = False AndAlso IsNumeric(CurrentQueryString.Take) AndAlso CType(CurrentQueryString.Take, Integer) > 0 Then Take = CurrentQueryString.Take

        '    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

        '        Results = _MvcController.LoadJobsForEmployeeFast(DbContext, EmployeeCode, ClientCode, DivisionCode, ProductCode, JobNumber)
        '        If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.LookupItem)

        '        If HasQueryDescription = True Then

        '            If Skip > 0 Then

        '                Result = (From Entity In Results
        '                          Where Entity.Description.ToUpper.Contains(QueryDescription)
        '                          Select Entity).Skip(Skip).Take(Take).ToList

        '            Else

        '                Result = (From Entity In Results
        '                          Where Entity.Description.ToUpper.Contains(QueryDescription)
        '                          Select Entity).Take(Take).ToList

        '            End If

        '        Else

        '            If Skip > 0 Then

        '                Result = (From Entity In Results
        '                          Select Entity).Skip(Skip).Take(Take).ToList

        '            Else

        '                Result = Results

        '            End If

        '        End If

        '        PleaseSelectJobLookupEntry.Key = ""

        '        If Results.LongCount = 0 Then

        '            PleaseSelectJobLookupEntry.Description = "[No jobs available]"

        '        ElseIf Results.LongCount > 0 Then

        '            If Skip = 0 Then

        '                PleaseSelectJobLookupEntry.Description = "[Please select]"

        '            End If

        '        End If

        '        Result.Insert(0, PleaseSelectJobLookupEntry)

        '    End Using

        '    ReturnObject = New With {.result = Result, .count = Result.LongCount}

        '    Return MaxJson(ReturnObject, JsonRequestBehavior.AllowGet)

        'End Function
        <HttpGet>
        Public Function GetJobsForEmployee(ByVal Text As String) As JsonResult

            Dim Results As Generic.List(Of AdvantageFramework.Controller.Employee.LookupItem) = Nothing
            'Dim PleaseSelectJobLookupEntry As New AdvantageFramework.Controller.Employee.LookupItem
            Dim EmployeeCode As String = String.Empty
            Dim SearchText As String = String.Empty
            Dim ClientCode As String = String.Empty
            Dim DivisionCode As String = String.Empty
            Dim ProductCode As String = String.Empty
            Dim JobNumber As Integer = 0

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If
            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.DivisionCode) = False Then DivisionCode = CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.ProductCode) = False Then ProductCode = CurrentQueryString.ProductCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.JobNumber) = False AndAlso IsNumeric(CurrentQueryString.JobNumber) AndAlso CType(CurrentQueryString.JobNumber, Integer) > 0 Then JobNumber = CurrentQueryString.JobNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Results = _MvcController.LoadJobsForEmployeeFast(DbContext, EmployeeCode, ClientCode, DivisionCode, ProductCode, JobNumber, Text)
                If Results Is Nothing Then Results = New List(Of AdvantageFramework.Controller.Employee.LookupItem)

                'PleaseSelectJobLookupEntry.Key = ""

                ''If Results.LongCount = 0 Then

                ''    PleaseSelectJobLookupEntry.Description = "[No jobs available]"

                ''ElseIf Results.LongCount > 0 Then

                'PleaseSelectJobLookupEntry.Description = "[Please select]"

                ''End If

                'Results.Insert(0, PleaseSelectJobLookupEntry)

            End Using

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetJobsForEmployeeCount() As JsonResult

            Dim Results As Integer = 0
            Dim EmployeeCode As String = String.Empty
            Dim SearchText As String = String.Empty
            Dim ClientCode As String = String.Empty
            Dim DivisionCode As String = String.Empty
            Dim ProductCode As String = String.Empty
            Dim JobNumber As Integer = 0

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If
            If String.IsNullOrWhiteSpace(CurrentQueryString.SearchText) = False Then SearchText = CurrentQueryString.SearchText
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) = False Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.DivisionCode) = False Then DivisionCode = CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.ProductCode) = False Then ProductCode = CurrentQueryString.ProductCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.JobNumber) = False AndAlso IsNumeric(CurrentQueryString.JobNumber) AndAlso CType(CurrentQueryString.JobNumber, Integer) > 0 Then JobNumber = CurrentQueryString.JobNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Results = _MvcController.LoadJobsForEmployeeFastCount(DbContext, EmployeeCode, ClientCode, DivisionCode, ProductCode, JobNumber)

            End Using

            Return Json(Results, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetMyEmployees() As JsonResult

            Dim List As Generic.List(Of AdvantageFramework.Controller.Employee.SearchResult)

            If Session(MyEmployeesSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        List = _MvcController.GetMyEmployees(DbContext, SecurityContext, SecuritySession.User.EmployeeCode)

                    End Using

                End Using

                Session(MyEmployeesSessionKey) = List

            Else

                List = CType(Session(MyEmployeesSessionKey), Generic.List(Of AdvantageFramework.Controller.Employee.SearchResult))

            End If

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetMyProjects() As JsonResult

            Dim EmployeeCode As String = String.Empty
            Dim MyProjects As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.CopyFrom.MyProject)

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                MyProjects = _MvcController.GetProjectsForEmployee(DbContext, EmployeeCode)

            End Using

            Return MaxJson(MyProjects, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetMyCalendar() As JsonResult

            Dim List As IEnumerable(Of Object)

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)


            End Using

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetMyAssignments() As JsonResult

            Dim EmployeeCode As String = String.Empty
            Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
            Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
            Dim IncludeBoardLevelItems As Boolean = True
            Dim ErrorMessage As String = ""
            Dim StartDateString As String = "1/1/1950"
            Dim EndDateString As String = Today.Date.ToShortDateString
            Dim GroupBy As String = ""

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then

                EmployeeCode = CurrentQueryString.EmployeeCode

            Else

                EmployeeCode = Me.SecuritySession.User.EmployeeCode

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
                Dim TaskStatus As String = String.Empty
                Dim TaskShow As String = String.Empty
                Dim TaskOnlyStartDue As String = String.Empty


                Try

                    AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.SecuritySession.UserCode, "MyTasks").ToList
                    TaskStatus = AppVars.Where(Function(av) av.Name = "ddType").First.Value
                    TaskShow = AppVars.Where(Function(av) av.Name = "StartToday").First.Value
                    TaskOnlyStartDue = AppVars.Where(Function(av) av.Name = "TodayOnlyStartDue").First.Value

                Catch ex As Exception
                    TaskStatus = String.Empty
                End Try

                Try

                    Alerts = (From Entity In AlertController.LoadAlerts(DbContext, EmployeeCode,
                                                                    TaskShow, TaskOnlyStartDue, TaskStatus, GroupBy)
                              Where Entity.IsAlertCC = False AndAlso Entity.JobNumber IsNot Nothing AndAlso Entity.JobNumber > 0 AndAlso
                              Entity.JobComponentNumber IsNot Nothing AndAlso Entity.JobComponentNumber > 0 AndAlso Entity.IsWorkItem = True
                              Order By Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.JobNumber
                              Select Entity).Distinct.ToList

                Catch ex As Exception
                    Alerts = Nothing
                End Try

                If Alerts IsNot Nothing Then

                    Select Case TaskStatus
                        Case "Active"

                            Alerts = Alerts.Where(Function(a) a.TaskStatus = "A" OrElse a.TaskStatus = "H" OrElse a.TaskStatus = "L" OrElse a.TaskStatus Is Nothing).ToList

                        Case "Projected"

                            Alerts = Alerts.Where(Function(a) a.TaskStatus = "P" OrElse a.TaskStatus Is Nothing).ToList

                        Case "H"

                            Alerts = Alerts.Where(Function(a) a.TaskStatus = "H" OrElse a.TaskStatus Is Nothing).ToList

                        Case "L"

                            Alerts = Alerts.Where(Function(a) a.TaskStatus = "L" OrElse a.TaskStatus Is Nothing).ToList

                    End Select
                    If TaskShow = "True" Then

                        Alerts = Alerts.Where(Function(a) a.StartDate <= Today() OrElse a.StartDate Is Nothing).ToList

                    End If
                    If TaskOnlyStartDue = "True" Then

                        Alerts = Alerts.Where(Function(a) (a.StartDate IsNot Nothing AndAlso a.DueDate IsNot Nothing)).ToList

                    End If

                End If

            End Using

            If Alerts Is Nothing Then

                Alerts = New List(Of AdvantageFramework.DTO.Desktop.Alert)

            End If

            Return MaxJson(Alerts, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetMyRecentAssignments() As JsonResult

            Return MaxJson(Webvantage.Recents.GetRecentAssignments, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetMyRecentJobs() As JsonResult

            Return MaxJson(Webvantage.Recents.GetRecentJobs, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function HasApprovalComment() As JsonResult

            Dim HasComment As Boolean

            Try

                Dim Comment As String = String.Empty
                Dim EmployeeCode As String = String.Empty
                Dim EmployeeDate As Date? = Nothing

                EmployeeCode = Me.CurrentQueryString.EmployeeCode
                If IsDate(Me.CurrentQueryString.StartDate) = True Then EmployeeDate = CType(Me.CurrentQueryString.StartDate, Date)

                If String.IsNullOrWhiteSpace(EmployeeCode) = False AndAlso EmployeeDate IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Comment = AdvantageFramework.EmployeeTimesheet.LoadDayApprovalComment(DbContext, EmployeeCode, EmployeeDate)

                    End Using

                End If

                If String.IsNullOrWhiteSpace(Comment) = False Then

                    HasComment = True

                End If

            Catch ex As Exception
                HasComment = False
            End Try

            Return MaxJson(HasComment, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetApprovalComment() As JsonResult

            Dim Comment As String = String.Empty
            Dim EmployeeCode As String = String.Empty
            Dim EmployeeDate As Date? = Nothing

            EmployeeCode = Me.CurrentQueryString.EmployeeCode
            If IsDate(Me.CurrentQueryString.StartDate) = True Then EmployeeDate = CType(Me.CurrentQueryString.StartDate, Date)

            If String.IsNullOrWhiteSpace(EmployeeCode) = False AndAlso EmployeeDate IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Comment = AdvantageFramework.EmployeeTimesheet.LoadDayApprovalComment(DbContext, EmployeeCode, EmployeeDate)

                End Using

            End If

            'If String.IsNullOrWhiteSpace(Comment) = True Then Comment = "No approval comments from supervisor."

            Return MaxJson(Comment, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTaskFunctionCode() As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim TaskSequenceNumber As Short = -1
            Dim FunctionCode As String = String.Empty

            JobNumber = Me.CurrentQueryString.JobNumber
            JobComponentNumber = Me.CurrentQueryString.JobComponentNumber
            TaskSequenceNumber = Me.CurrentQueryString.TaskSequenceNumber

            If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso TaskSequenceNumber > -1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    FunctionCode = _GetTaskFunctionCode(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

                    If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                        Success = True

                    End If

                End Using

            End If

            ReturnObject = New With {.FunctionCode = FunctionCode}

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <HttpGet>
        Public Function GetTaskFunctionCodeForTaskTimeEntry(ByVal JobNumber As Integer,
                                                            ByVal JobComponentNumber As Short,
                                                            ByVal TaskSequenceNumber As Short) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim FunctionCode As String = String.Empty

            If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso TaskSequenceNumber > -1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    FunctionCode = _GetTaskFunctionCode(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

                    If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                        Success = True

                    End If

                End Using

            End If

            If String.IsNullOrWhiteSpace(FunctionCode) = True Then

                FunctionCode = ""

            End If

            ReturnObject = New With {.FunctionCode = FunctionCode}

            Return Json(FunctionCode, JsonRequestBehavior.AllowGet)

        End Function
        Private Function _GetTaskFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer,
                                              ByVal JobComponentNumber As Short,
                                              ByVal TaskSequenceNumber As Short) As String

            Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim FunctionCode As String = String.Empty

            Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

            If Task IsNot Nothing Then

                FunctionCode = Task.FuctionCode

            End If

            Return FunctionCode

        End Function

        <HttpGet>
        Public Function CheckDayEditStatus(ByVal EmployeeCode As String, ByVal EntryDate As Date) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim DayIsAvailable As Boolean = True
            Dim CurrentDayEditStatus As AdvantageFramework.Timesheet.TimesheetEditType = TimesheetEditType.Edit

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    EntryDate = New Date(EntryDate.Year, EntryDate.Month, EntryDate.Day)

                    CurrentDayEditStatus = AdvantageFramework.EmployeeTimesheet.CheckEditStatus(DbContext, EmployeeCode, EntryDate)

                    If AdvantageFramework.EmployeeTimesheet.CheckApprovalStatus(DbContext, EmployeeCode, EntryDate) = True AndAlso
                                        CurrentDayEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                        DayIsAvailable = False
                        ErrorMessage = "This day has already been approved/pending.  No time will be added to this day."

                    Else

                        If CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Then

                            DayIsAvailable = True
                            ErrorMessage = String.Empty

                        Else

                            DayIsAvailable = False
                            ErrorMessage = "Edit status does not allow adding/editing."

                        End If

                    End If

                End Using

            Catch ex As Exception
                CurrentDayEditStatus = TimesheetEditType.Edit
                DayIsAvailable = True
                ErrorMessage = String.Empty
            End Try

            ReturnObject = New With {.DayIsAvailable = DayIsAvailable,
                                     .ErrorMessage = ErrorMessage}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CheckIfPostPeriodIsAvailable(ByVal EntryDate As Date) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim PostPeriodIsAvailable As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    EntryDate = New Date(EntryDate.Year, EntryDate.Month, EntryDate.Day)

                    PostPeriodIsAvailable = AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate)

                    If PostPeriodIsAvailable = False Then

                        Success = False
                        ErrorMessage = "Post period for this day is closed."

                    End If

                    ReturnObject = New With {.PostPeriodIsAvailable = PostPeriodIsAvailable}

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimesheetAgencySettings() As JsonResult

            Return MaxJson(LoadTimesheetAgencySettings(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsCommentRequiredClient(ByVal ClientCode As String) As JsonResult

            Dim IsRequired As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                IsRequired = Me._MvcController.IsCommentRequiredClient(DbContext, ClientCode)

            End Using

            Return Json(IsRequired, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsCommentRequiredJob(ByVal JobNumber As Integer) As JsonResult

            Dim IsRequired As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                IsRequired = Me._MvcController.IsCommentRequiredJob(DbContext, JobNumber)

            End Using

            Return Json(IsRequired, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsApprovalActive(ByVal EmployeeCode As String) As JsonResult

            Return Json(_IsApprovalActive(EmployeeCode), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function JobsDropDownValueMapper(ByVal Values As Integer()) As JsonResult

            Dim Indices As New Generic.List(Of Integer)

            If Values IsNot Nothing AndAlso Values.Any Then

                Dim Index = 0


            End If

            Return MaxJson(Indices, JsonRequestBehavior.AllowGet)

        End Function


#Region " Drag and Drop Copy "

        <HttpGet>
        Public Function GetJobAssignments() As JsonResult

            Dim List As Generic.List(Of ViewModels.LookupDisplayObject.WorkItemDisplayObject)
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim IsAssignmentRequired As Boolean = False
            Dim IncludePleaseSelect As Boolean = False
            Dim HasAssignments As Boolean = False
            Dim HasPleaseSelect As Boolean = False

            If CurrentQueryString.JobNumber > 0 Then JobNumber = CurrentQueryString.JobNumber
            If CurrentQueryString.JobComponentNumber > 0 Then JobComponentNumber = CurrentQueryString.JobComponentNumber
            IncludePleaseSelect = CurrentQueryString.Get("inclps") = "1"

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    List = DbContext.Database.SqlQuery(Of ViewModels.LookupDisplayObject.WorkItemDisplayObject)(String.Format("EXEC [dbo].[advsp_agile_get_emp_work_items] NULL, {1}, {2}, 0;",
                                                                                                                             SecuritySession.User.EmployeeCode,
                                                                                                                             JobNumber,
                                                                                                                             JobComponentNumber)).ToList

                    If List IsNot Nothing AndAlso List.Count > 0 Then

                        HasAssignments = True

                    End If

                End Using

            End If

            If List Is Nothing Then List = New List(Of LookupDisplayObject.WorkItemDisplayObject)

            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                If IsAssignmentRequired = False AndAlso IncludePleaseSelect = True AndAlso HasAssignments = True Then

                    'Dim PleaseSelectItem As New ViewModels.LookupDisplayObject.WorkItemDisplayObject

                    'PleaseSelectItem.AlertID = 0
                    'PleaseSelectItem.Description = "[Please select]"

                    'List.Insert(0, PleaseSelectItem)

                    'HasPleaseSelect = True

                End If
                'If HasAssignments = False AndAlso HasPleaseSelect = False Then

                '    Dim NoAssignmentsItem As New ViewModels.LookupDisplayObject.WorkItemDisplayObject

                '    NoAssignmentsItem.AlertID = 0
                '    NoAssignmentsItem.Description = "[No assignments available]"

                '    List.Insert(0, NoAssignmentsItem)

                'End If

            End If

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetRecentAssignments() As JsonResult

            Return MaxJson(Webvantage.Recents.GetRecentAssignments, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetRecentJobs() As JsonResult

            Return MaxJson(Webvantage.Recents.GetRecentJobs, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmployeeTimeTemplates(ByVal EmployeeCode As String) As JsonResult

            Dim EmployeeTimeTemplates As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                EmployeeTimeTemplates = AdvantageFramework.EmployeeTimesheet.LoadEmployeeTimeTemplates(DbContext, SecuritySession.UserCode, EmployeeCode)

            End Using

            Return MaxJson(EmployeeTimeTemplates, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmployeeCalendarItems(ByVal EmployeeCode As String,
                                                 ByVal StartDate As Date) As JsonResult

            Dim List As Generic.List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim EmployeeTimeStagings As Generic.List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)
                Dim EndDate As Date
                Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

                If String.IsNullOrWhiteSpace(EmployeeCode) = True Then EmployeeCode = Me.SecuritySession.User.EmployeeCode

                If Session(UserSettingSessionKey) IsNot Nothing Then

                    UserSettings = CType(Session(UserSettingSessionKey), AdvantageFramework.ViewModels.Employee.Timesheet.Settings)

                Else

                    UserSettings = LoadAllUserSettings(DbContext)
                    Session(UserSettingSessionKey) = UserSettings

                End If

                EmployeeTimeStagings = AdvantageFramework.EmployeeCalendarTime.LoadEmployeeTimeStaging(DbContext, EmployeeCode).ToList

                If EmployeeTimeStagings IsNot Nothing Then

                    StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, 7)
                    EndDate = StartDate.AddDays(6)

                    List = (From Entity In EmployeeTimeStagings
                            Where Entity.StartDate >= StartDate And Entity.EndDate <= EndDate
                            Order By Entity.StartDate).ToList

                End If

            End Using

            If List Is Nothing Then List = New List(Of AdvantageFramework.EmployeeCalendarTime.Classes.EmployeeTimeStaging)

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " Report "

        <HttpGet>
        Public Function GetReport(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal DaysToGet As Integer,
                                  ByVal [Sort] As TimesheetSort) As FileResult

            Dim Workbook As Aspose.Cells.Workbook = Nothing
            Dim Report As New AdvantageFramework.EmployeeTimesheet.Classes.ExcelReport(Me.SecuritySession)
            Dim ErrorMessage As String = String.Empty
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim ByteFile As Byte() = Nothing

            If Report IsNot Nothing Then

                Workbook = Report.BuildReport(EmployeeCode, StartDate, DaysToGet, Sort, ErrorMessage)

                If Workbook IsNot Nothing Then

                    Using MemoryStream = New System.IO.MemoryStream

                        Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
                        XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Xlsx)

                        Workbook.Save(MemoryStream, XlsSaveOptions)

                        ByteFile = MemoryStream.ToArray

                    End Using

                    If ByteFile IsNot Nothing Then

                        FileContentResult = Me.File(ByteFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")

                    End If

                    FileContentResult.FileDownloadName = Workbook.FileName

                End If

            End If

            Return FileContentResult

        End Function

#End Region

#Region " Inactive "

        <HttpGet>
        Public Function GetFunctionsCategories() As JsonResult

            Dim List As Generic.List(Of Object)
            Dim TimeType As String = "D"

            If String.IsNullOrWhiteSpace(CurrentQueryString.TimeType) = False Then TimeType = CurrentQueryString.TimeType.ToUpper

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)


            End Using

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function InitTimesheet(ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Timesheet As AdvantageFramework.DTO.Employee.Timesheet = Nothing
            Dim tm As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings

            Timesheet = New AdvantageFramework.DTO.Employee.Timesheet

            Timesheet.EmployeeCode = EmployeeCode

            'Timesheet.StartDate = If(Start Is Nothing, Today, Start)
            Timesheet.StartDate = Today
            Try

                TsSettings = tm.GetSettings(Me.SecuritySession.UserCode)

                Timesheet.UserSettings.DaysToDisplay = TsSettings.DaysToDisplay
                Timesheet.UserSettings.StartTimesheetOnDayOfWeek = TsSettings.StartTimesheetOnDayOfWeek
                Timesheet.UserSettings.ShowCommentsUsing = TsSettings.ShowCommentsUsing
                Timesheet.UserSettings.DivisionLabel = TsSettings.Labels.Division
                Timesheet.UserSettings.ProductLabel = TsSettings.Labels.Product
                Timesheet.UserSettings.ProductCategoryLabel = TsSettings.Labels.ProdCat
                Timesheet.UserSettings.JobLabel = TsSettings.Labels.Job
                Timesheet.UserSettings.JobComponentLabel = TsSettings.Labels.JobComponent
                Timesheet.UserSettings.FunctionCategoryLabel = TsSettings.Labels.FuncCat

            Catch ex As Exception
            End Try

            Return Json(Timesheet, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function InitAddTimesheetRow() As JsonResult

            Dim TimesheetEntry As AdvantageFramework.DTO.Employee.Timesheet.Entry = Nothing

            Return Json(TimesheetEntry, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTimesheetRows(ByVal EmployeeCode As String, ByVal StartDate As Date?) As JsonResult

            'objects
            Dim Rows As IEnumerable = Nothing

            Rows = _Controller.GetTimesheetRows(EmployeeCode, StartDate)

            Return Json(Rows, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

#End Region

#Region " Post "

#Region " Active "

        <AcceptVerbs("POST")>
        Public Function DeleteEntries(ByVal Deletes As Generic.List(Of DeleteInfo)) As JsonResult

            Dim Successes As Integer = 0
            Dim Fails As Integer = 0
            Dim Success As Boolean = False
            Dim ErrorMessages As Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty

            If Deletes IsNot Nothing AndAlso Deletes.Count > 0 Then

                ErrorMessages = New List(Of String)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        For Each Delete As DeleteInfo In Deletes

                            Success = False
                            ErrorMessage = String.Empty

                            If Delete.EmployeeTimeID IsNot Nothing AndAlso Delete.EmployeeTimeID > 0 AndAlso
                               Delete.EmployeeTimeID IsNot Nothing AndAlso Delete.EmployeeTimeID > 0 AndAlso
                               String.IsNullOrWhiteSpace(Delete.TimeType) = False Then

                                Success = Me._MvcController.DeleteEntry(DbContext,
                                                                        Delete.EmployeeTimeID,
                                                                        Delete.EmployeeTimeDetailID,
                                                                        Delete.TimeType, ErrorMessage)

                                If Success = True Then

                                    Successes += 1

                                Else

                                    Fails += 1

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        ErrorMessages.Add(ErrorMessage)

                                    End If

                                End If

                            End If

                        Next

                    Catch ex As Exception
                        Fails += 1
                        ErrorMessages.Add(ex.Message.ToString)
                    End Try

                End Using

            End If

            Success = True

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, "", New With {.Successes = Successes,
                                                                                                   .Fails = Fails,
                                                                                                   .ErrorMessages = ErrorMessages}))

        End Function

        <AcceptVerbs("POST")>
        Public Function DeleteEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal TimeType As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            'Dim ReturnObject As Object = Nothing
            'Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = Me._MvcController.DeleteEntry(DbContext, EmployeeTimeID, EmployeeTimeDetailID, TimeType, ErrorMessage)

                    'If Success = True Then

                    '    ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    'End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

        <AcceptVerbs("POST")>
        Public Function CopySelectedRows(ByVal EmployeeCode As String,
                                         ByVal SourceDate As Date, ByVal TargetDate As Date,
                                         ByVal IncludeHours As Boolean, IncludeComments As Boolean,
                                         ByVal Entries As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim EntriesObject As Generic.List(Of SelectRowForCopy) = Nothing
            Dim Added As Integer = 0
            Dim Failed As Integer = 0
            Dim ErrorMessages As New Generic.List(Of String)
            Dim ReturnMessages As New Generic.List(Of String)
            Dim SourceDateStartOfWeek As Date
            Dim TargetDateStartOfWeek As Date
            Dim DateOffset As Integer = 0
            Dim SourceEmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim SourceEmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing
            Dim UserStartWeekOn As DayOfWeek = DayOfWeek.Sunday
            Dim Hours As Decimal = 0.0
            Dim NewEmployeeTimeID As Integer
            Dim NewEmployeeTimeDetailID As Integer
            Dim Saved As Boolean = False

            Try

                EntriesObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of SelectRowForCopy))(Entries)

            Catch ex As Exception
                EntriesObject = Nothing
            End Try

            If EntriesObject IsNot Nothing AndAlso EntriesObject.Count > 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        UserStartWeekOn = AdvantageFramework.EmployeeTimesheet.GetUserStartWeekOn(DbContext)
                        SourceDateStartOfWeek = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(SourceDate, UserStartWeekOn)
                        TargetDateStartOfWeek = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(TargetDate, UserStartWeekOn)
                        DateOffset = DateDiff(DateInterval.Day, SourceDateStartOfWeek, TargetDateStartOfWeek)

                        For Each Entry As SelectRowForCopy In EntriesObject

                            SourceEmployeeTimeDetail = Nothing
                            SourceEmployeeTimeIndirect = Nothing
                            Hours = 0.0
                            ErrorMessage = String.Empty
                            NewEmployeeTimeID = 0
                            NewEmployeeTimeDetailID = 0

                            If IncludeHours = True Then

                                Hours = Entry.Hours

                            Else

                                Hours = 0.0

                            End If
                            If Entry.TimeType = "D" Then

                                SourceEmployeeTimeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeIDAndEmployeeTimeDetailID(DbContext,
                                                                                                                                                                 Entry.EmployeeTimeID,
                                                                                                                                                                 Entry.EmployeeTimeDetailID)

                                If SourceEmployeeTimeDetail IsNot Nothing Then

                                    Saved = SaveTimeSheetDay(0, 0, EmployeeCode, DateAdd(DateInterval.Day, DateOffset, Entry.EntryDate), Hours, "",
                                                             SourceEmployeeTimeDetail.FunctionCode, SourceEmployeeTimeDetail.DepartmentTeamCode,
                                                             SourceEmployeeTimeDetail.JobNumber, SourceEmployeeTimeDetail.JobComponentNumber,
                                                             If(SourceEmployeeTimeDetail.AlertID Is Nothing, 0, SourceEmployeeTimeDetail.AlertID),
                                                             False, False, ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                                    If Saved = True Then

                                        Added += 1

                                    Else

                                        Failed += 1

                                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            ErrorMessages.Add(ErrorMessage)

                                        End If

                                    End If

                                End If

                            Else

                                SourceEmployeeTimeIndirect = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByEmployeeTimeIDAndEmployeeTimeIndirectID(DbContext,
                                                                                                                                                                       Entry.EmployeeTimeID,
                                                                                                                                                                       Entry.EmployeeTimeDetailID)
                                If SourceEmployeeTimeIndirect IsNot Nothing Then

                                    If AdvantageFramework.EmployeeTimesheet.CopyTimeEntry(DbContext, SecuritySession.UserCode,
                                                                                          Entry.EmployeeTimeID, Entry.EmployeeTimeDetailID,
                                                                                          Entry.TimeType, DateAdd(DateInterval.Day, DateOffset, Entry.EntryDate),
                                                                                          EmployeeCode, IncludeHours, ErrorMessage) = False Then

                                    End If
                                    'Saved = SaveTimeSheetDay(0, 0, EmployeeCode, DateAdd(DateInterval.Day, DateOffset, Entry.EntryDate), Hours, "",
                                    '                         SourceEmployeeTimeIndirect.Category, SourceEmployeeTimeIndirect.DepartmentTeamCode,
                                    '                         0, 0,
                                    '                         0, False, False, ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                                    If Saved = True Then

                                            Added += 1

                                        Else

                                            Failed += 1

                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                ErrorMessages.Add(ErrorMessage)

                                            End If

                                        End If

                                    End If

                                End If

                        Next

                    End Using

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString
                End Try

            End If

            ErrorMessage = String.Empty
            If Failed = 0 Then Success = True

            ReturnObject = New With {.Saved = Added,
                                     .Failed = Failed,
                                     .CopiedToDate = TargetDate.ToShortDateString,
                                     .ErrorMessages = (From Entity In ErrorMessages
                                                       Select Entity).Distinct}

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function CopyRow(ByVal EmployeeCode As String, ByVal StartDate As Date,
                                ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                ByVal FunctionCategoryCode As String, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.CopyRow(DbContext, EmployeeCode, StartDate, JobNumber, JobComponentNumber, FunctionCategoryCode, AlertID, ErrorMessage)

                    'If Success = True Then

                    '    ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    'End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        'Only used on main timesheet!

        <AcceptVerbs("POST")>
        Public Function SaveTimesheetWeekViewChanges(ByVal Inserts As Generic.List(Of EntryInfo),
                                                     ByVal Updates As Generic.List(Of EntryInfo),
                                                     ByVal Deletes As Generic.List(Of EntryInfo)) As JsonResult

            Dim InsertTotal As Integer = 0
            Dim InsertSuccesses As Integer = 0
            Dim InsertFails As Integer = 0
            Dim UpdateTotal As Integer = 0
            Dim UpdateSuccesses As Integer = 0
            Dim UpdateFails As Integer = 0
            Dim DeleteTotal As Integer = 0
            Dim DeleteSuccesses As Integer = 0
            Dim DeleteFails As Integer = 0
            Dim Success As Boolean = False
            Dim HasEstimateWarning As Boolean = False
            Dim EstimateWarning As String = String.Empty
            Dim BlockedByExceedOption As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0
                Dim ErrorMessage As String = String.Empty

                If Inserts IsNot Nothing Then

                    InsertTotal = Inserts.Count

                    For Each Insert As EntryInfo In Inserts

                        Success = False
                        NewEmployeeTimeID = 0
                        NewEmployeeTimeDetailID = 0

                        If String.IsNullOrWhiteSpace(Insert.EmployeeCode) = False AndAlso Insert.EntryDate IsNot Nothing Then

                            If Insert.EmployeeTimeID Is Nothing Then Insert.EmployeeTimeID = 0
                            If Insert.EmployeeTimeDetailID Is Nothing Then Insert.EmployeeTimeDetailID = 0
                            If Insert.Hours Is Nothing Then Insert.Hours = 0
                            If Insert.JobNumber Is Nothing Then Insert.JobNumber = 0
                            If Insert.JobComponentNumber Is Nothing Then Insert.JobComponentNumber = 0
                            If Insert.AlertID Is Nothing Then Insert.AlertID = 0

                            Success = Me.SaveTimeSheetDay(Insert.EmployeeTimeID,
                                                          Insert.EmployeeTimeDetailID,
                                                          Insert.EmployeeCode,
                                                          Insert.EntryDate,
                                                          Insert.Hours,
                                                          Insert.Comment,
                                                          Insert.FunctionCategoryCode,
                                                          Insert.DepartmentTeamCode,
                                                          Insert.JobNumber,
                                                          Insert.JobComponentNumber,
                                                          Insert.AlertID,
                                                          True,
                                                          True,
                                                          ErrorMessage,
                                                          NewEmployeeTimeID,
                                                          NewEmployeeTimeDetailID)

                            If Success = True Then

                                InsertSuccesses += 1

                            Else

                                InsertFails += 1

                            End If
                            If HasEstimateWarning = False Then

                                HasEstimateWarning = CheckForEstimateWarning(ErrorMessage, EstimateWarning, BlockedByExceedOption)

                            End If

                        Else

                            InsertFails += 1

                        End If

                    Next

                End If
                If Updates IsNot Nothing Then

                    UpdateTotal = Updates.Count

                    For Each Update As EntryInfo In Updates

                        Success = False
                        NewEmployeeTimeID = 0
                        NewEmployeeTimeDetailID = 0

                        If Update.EmployeeTimeID IsNot Nothing AndAlso Update.EmployeeTimeID > 0 AndAlso
                            Update.EmployeeTimeDetailID IsNot Nothing AndAlso Update.EmployeeTimeDetailID > 0 Then

                            If String.IsNullOrWhiteSpace(Update.TimeType) = True Then

                                If Update.JobNumber IsNot Nothing AndAlso Update.JobNumber > 0 AndAlso
                                       Update.JobComponentNumber IsNot Nothing AndAlso Update.JobComponentNumber > 0 Then

                                    Update.TimeType = "D"

                                Else

                                    Update.TimeType = "N"

                                End If

                            End If
                            If String.IsNullOrWhiteSpace(Update.Comment) = True AndAlso Update.Hours <> 0 Then

                                Update.Comment = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CAST(EMP_COMMENT AS VARCHAR(MAX)) FROM EMP_TIME_DTL_CMTS WITH(NOLOCK) WHERE ET_ID = {0} And ET_DTL_ID = {1} And ET_SOURCE = '{2}';",
                                                                                        Update.EmployeeTimeID,
                                                                                        Update.EmployeeTimeDetailID,
                                                                                        Update.TimeType)).SingleOrDefault

                            End If

                            If Update.Hours Is Nothing Then Update.Hours = 0
                            If Update.JobNumber Is Nothing Then Update.JobNumber = 0
                            If Update.JobComponentNumber Is Nothing Then Update.JobComponentNumber = 0
                            If Update.AlertID Is Nothing Then Update.AlertID = 0

                            Success = Me.SaveTimeSheetDay(Update.EmployeeTimeID,
                                                          Update.EmployeeTimeDetailID,
                                                          Update.EmployeeCode,
                                                          Update.EntryDate,
                                                          Update.Hours,
                                                          Update.Comment,
                                                          Update.FunctionCategoryCode,
                                                          Update.DepartmentTeamCode,
                                                          Update.JobNumber,
                                                          Update.JobComponentNumber,
                                                          Update.AlertID,
                                                          True,
                                                          True,
                                                          ErrorMessage,
                                                          NewEmployeeTimeID,
                                                          NewEmployeeTimeDetailID)

                            If Success = True Then

                                UpdateSuccesses += 1

                            Else

                                UpdateFails += 1

                            End If
                            If HasEstimateWarning = False Then

                                HasEstimateWarning = CheckForEstimateWarning(ErrorMessage, EstimateWarning, BlockedByExceedOption)

                            End If

                        Else

                            UpdateFails += 1

                        End If

                    Next

                End If
                If Deletes IsNot Nothing Then

                    DeleteTotal = Deletes.Count

                    For Each Delete As EntryInfo In Deletes

                        Success = False

                        If Delete.EmployeeTimeID IsNot Nothing AndAlso Delete.EmployeeTimeID > 0 AndAlso
                           Delete.EmployeeTimeDetailID IsNot Nothing AndAlso Delete.EmployeeTimeDetailID > 0 Then

                            If String.IsNullOrWhiteSpace(Delete.TimeType) = True Then

                                If Delete.JobNumber IsNot Nothing AndAlso Delete.JobNumber > 0 AndAlso
                                       Delete.JobComponentNumber IsNot Nothing AndAlso Delete.JobComponentNumber > 0 Then

                                    Delete.TimeType = "D"

                                Else

                                    Delete.TimeType = "N"

                                End If

                            End If

                            Success = Me._MvcController.DeleteEntry(DbContext,
                                                                    Delete.EmployeeTimeID,
                                                                    Delete.EmployeeTimeDetailID,
                                                                    Delete.TimeType,
                                                                    ErrorMessage)

                            If Success = True Then

                                DeleteSuccesses += 1

                            Else

                                DeleteFails += 1

                            End If
                            If HasEstimateWarning = False Then

                                HasEstimateWarning = CheckForEstimateWarning(ErrorMessage, EstimateWarning, BlockedByExceedOption)

                            End If

                        Else

                            DeleteFails += 1

                        End If

                    Next

                End If

                If InsertSuccesses > 0 OrElse UpdateSuccesses > 0 OrElse DeleteSuccesses > 0 Then

                    Success = True

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, "", New With {.InsertTotal = InsertTotal,
                                                                                                   .InsertSuccesses = InsertSuccesses,
                                                                                                   .InsertFails = InsertFails,
                                                                                                   .UpdateTotal = UpdateTotal,
                                                                                                   .UpdateSuccesses = UpdateSuccesses,
                                                                                                   .UpdateFails = UpdateFails,
                                                                                                   .DeleteTotal = DeleteTotal,
                                                                                                   .DeleteSuccesses = DeleteSuccesses,
                                                                                                   .DeleteFails = DeleteFails,
                                                                                                   .HasEstimateWarning = HasEstimateWarning,
                                                                                                   .EstimateWarning = EstimateWarning,
                                                                                                   .BlockedByExceedOption = BlockedByExceedOption}))

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveEntryInfoObject(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer,
                                            ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                            ByVal FunctionCategoryCode As String, ByVal DepartmentTeamCode As String,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0

                Success = Me.SaveTimeSheetDay(EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode,
                                              EntryDate, Hours, Comment, FunctionCategoryCode, DepartmentTeamCode,
                                              JobNumber, JobComponentNumber, AlertID, True, True, ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                If Success = True Then

                    'Try

                    '    Dim PostActions As New AdvantageFramework.Controller.Employee.PostTimeSaveActions(Me.SecuritySession, EmployeeCode, EntryDate)
                    '    PostActions.Run()

                    'Catch ex As Exception
                    'End Try

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = Me.FullErrorMessageToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveEntryInfoObjectWeekView(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer,
                                                    ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                                    ByVal FunctionCategoryCode As String, ByVal DepartmentTeamCode As String,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0

                If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 AndAlso String.IsNullOrWhiteSpace(Comment) Then

                    Try

                        Dim TimeType As String = String.Empty

                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            TimeType = "D"

                        Else

                            TimeType = "N"

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Comment = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CAST(EMP_COMMENT AS VARCHAR(MAX)) FROM EMP_TIME_DTL_CMTS WITH(NOLOCK) WHERE ET_ID = {0} And ET_DTL_ID = {1} And ET_SOURCE = '{2}';",
                                                                                           EmployeeTimeID, EmployeeTimeDetailID, TimeType)).SingleOrDefault

                        End Using

                    Catch ex As Exception
                    End Try

                End If

                Success = Me.SaveTimeSheetDay(EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode,
                                              EntryDate, Hours, Comment, FunctionCategoryCode, DepartmentTeamCode,
                                              JobNumber, JobComponentNumber, AlertID, True, True, ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                If Success = True Then

                    'Try

                    '    Dim PostActions As New AdvantageFramework.Controller.Employee.PostTimeSaveActions(Me.SecuritySession, EmployeeCode, EntryDate)
                    '    PostActions.Run()

                    'Catch ex As Exception
                    'End Try

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = Me.FullErrorMessageToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        Private Function CheckForEstimateWarning(ByVal ErrorMessage As String, ByRef MessageText As String, ByRef BlockedByExceedOption As Boolean) As Boolean

            Dim HasEstimateWarning As Boolean = False

            MessageText = String.Empty
            BlockedByExceedOption = False

            Try

                Dim parts As String()
                parts = ErrorMessage.Split("|")

                If parts IsNot Nothing AndAlso parts.Length > 0 Then
                    If ErrorMessage.Contains("SUCCESS") = True Then

                        If (parts(parts.Length - 2) * 1 = -15) Then

                            HasEstimateWarning = True

                            MessageText = parts(parts.Length - 1).ToString

                        End If

                    ElseIf ErrorMessage.Contains("FAIL") = True Then

                        If (parts(parts.Length - 2) * 1 = -16) Then

                            HasEstimateWarning = True

                            MessageText = parts(parts.Length - 1).ToString
                            'MessageText = "Hours exceed the approved quote and will not be saved"
                            BlockedByExceedOption = True

                        End If

                    End If

                End If

            Catch ex As Exception
                HasEstimateWarning = False
                MessageText = String.Empty
            End Try

            Return HasEstimateWarning

        End Function

        <AcceptVerbs("POST")>
        Public Function AddEntryFromCopyFromMyTimeTemplates(ByVal EmployeeCode As String, ByVal EntryDate As Date,
                                                            ByVal EmployeeTimeTemplateID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessages As Generic.List(Of String) = New List(Of String)
            Dim ErrorMessage As String = String.Empty

            Try

                Dim FunctionCategoryCode As String = String.Empty
                Dim CategoryCode As String = String.Empty
                Dim DepartmentTeamCode As String = String.Empty
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0
                Dim Defaults As AdvantageFramework.Controller.Employee.EmployeeDefaults = Nothing
                Dim EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate = Nothing
                Dim IsUsingDefaultFunction As Boolean = False
                Dim IsUsingDefaultDepartment As Boolean = False
                Dim IsDirectTime As Boolean = False
                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0
                Dim IsValid = True
                Dim Hours As Decimal = 0.00
                Dim StartOfWeekDate As Date = CType(EntryDate.ToShortDateString, Date)
                Dim DateToday As Date = CType(Date.Today.ToShortDateString, Date)
                Dim DaysToApplyString As String = String.Empty
                Dim CanInsert As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    EmployeeTimeTemplate = AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.LoadByID(DbContext, EmployeeTimeTemplateID)

                    If EmployeeTimeTemplate IsNot Nothing Then

                        If EmployeeTimeTemplate.JobNumber IsNot Nothing AndAlso EmployeeTimeTemplate.JobNumber > 0 Then

                            JobNumber = EmployeeTimeTemplate.JobNumber

                            If EmployeeTimeTemplate.JobComponentNumber IsNot Nothing AndAlso EmployeeTimeTemplate.JobComponentNumber > 0 Then

                                JobComponentNumber = EmployeeTimeTemplate.JobComponentNumber
                                IsDirectTime = True

                            End If

                        End If
                        If String.IsNullOrWhiteSpace(EmployeeTimeTemplate.ApplyToDays) = False Then

                            DaysToApplyString = EmployeeTimeTemplate.ApplyToDays

                        End If

                        Defaults = New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode, JobNumber, JobComponentNumber)

                        If Defaults IsNot Nothing Then

                            FunctionCategoryCode = Defaults.FunctionCode
                            DepartmentTeamCode = Defaults.DepartmentCode
                            IsUsingDefaultFunction = True
                            IsUsingDefaultDepartment = True

                        End If
                        If IsDirectTime = True AndAlso String.IsNullOrWhiteSpace(EmployeeTimeTemplate.FunctionCode) = False Then

                            FunctionCategoryCode = EmployeeTimeTemplate.FunctionCode
                            IsUsingDefaultFunction = False

                        End If
                        If IsDirectTime = False Then

                            FunctionCategoryCode = EmployeeTimeTemplate.FunctionCode

                        End If
                        If String.IsNullOrWhiteSpace(EmployeeTimeTemplate.DepartmentTeamCode) = False Then

                            DepartmentTeamCode = EmployeeTimeTemplate.DepartmentTeamCode
                            IsUsingDefaultDepartment = False

                        End If
                        If EmployeeTimeTemplate.EmployeeHours IsNot Nothing Then

                            Hours = EmployeeTimeTemplate.EmployeeHours

                        End If

                        'Override date
                        Dim SetDateToToday = False

                        If _IsCurrentWeek(EntryDate) = True Then

                            EntryDate = DateToday

                        End If

                        If String.IsNullOrWhiteSpace(FunctionCategoryCode) = False AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = False Then

                            IsValid = ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(DbContext, EmployeeCode, IsDirectTime,
                                                                                          FunctionCategoryCode, IsUsingDefaultFunction,
                                                                                          DepartmentTeamCode, IsUsingDefaultDepartment,
                                                                                          ErrorMessage)
                            If IsValid = True Then

                                If String.IsNullOrWhiteSpace(DaysToApplyString) = True Then

                                    CanInsert = False

                                    If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate) = True Then

                                        CanInsert = True

                                    Else

                                        CanInsert = False
                                        Success = False
                                        ErrorMessage = String.Format("Post period is closed for {0}.", EntryDate.DayOfWeek.ToString)
                                        ErrorMessages.Add(ErrorMessage)

                                    End If
                                    If CanInsert = True Then

                                        Success = _AddEntry(EmployeeCode, EntryDate, Hours,
                                                            EmployeeTimeTemplate.DefaultComment,
                                                            FunctionCategoryCode, DepartmentTeamCode,
                                                            JobNumber, JobComponentNumber, 0,
                                                            ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                                    End If

                                    If Success = True Then

                                        If String.IsNullOrWhiteSpace(ErrorMessage) OrElse (NewEmployeeTimeID = 0 AndAlso NewEmployeeTimeDetailID = 0) Then

                                            ErrorMessages.Clear()
                                            ErrorMessage = String.Format("Item already on timesheet for {0}.", EntryDate.DayOfWeek.ToString)
                                            ErrorMessages.Add(ErrorMessage)

                                        End If
                                        If ErrorMessage.Contains("SUCCESS") Then

                                            ErrorMessage = String.Empty
                                            ErrorMessages.Clear()

                                        End If

                                    End If

                                Else

                                    Try

                                        Dim SuccessCount As Integer = 0
                                        Dim ar() As String

                                        ErrorMessages.Clear()

                                        ar = DaysToApplyString.Split(",")

                                        For i As Integer = 0 To ar.Length - 1 'Account for user's custom start of week

                                            Dim DayOfWeekToApplyTo As DayOfWeek = CType(CType(ar(i), Integer), DayOfWeek)

                                            For j As Integer = 0 To 6

                                                If DateAdd(DateInterval.Day, j, StartOfWeekDate).DayOfWeek = DayOfWeekToApplyTo Then

                                                    CanInsert = False

                                                    If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, DateAdd(DateInterval.Day, j, StartOfWeekDate)) = True Then

                                                        CanInsert = True

                                                    Else

                                                        CanInsert = False
                                                        Success = False
                                                        ErrorMessage = String.Format("Post period is closed for {0}.", DateAdd(DateInterval.Day, j, StartOfWeekDate).DayOfWeek.ToString)
                                                        ErrorMessages.Add(ErrorMessage)

                                                    End If

                                                    If CanInsert = True Then

                                                        Success = _AddEntry(EmployeeCode, DateAdd(DateInterval.Day, j, StartOfWeekDate), Hours,
                                                                            EmployeeTimeTemplate.DefaultComment,
                                                                            FunctionCategoryCode, DepartmentTeamCode,
                                                                            JobNumber, JobComponentNumber, 0,
                                                                            ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                                                    End If
                                                    If Success = True Then

                                                        SuccessCount += 1

                                                        If String.IsNullOrWhiteSpace(ErrorMessage) OrElse (NewEmployeeTimeID = 0 AndAlso NewEmployeeTimeDetailID = 0) Then

                                                            ErrorMessage = String.Format("Item already on timesheet for {0}.", DateAdd(DateInterval.Day, j, StartOfWeekDate).DayOfWeek.ToString)
                                                            ErrorMessages.Add(ErrorMessage)

                                                        End If
                                                        If ErrorMessage.Contains("SUCCESS") Then

                                                            ErrorMessage = String.Empty

                                                        End If

                                                        Success = False

                                                    End If

                                                    Exit For

                                                End If

                                            Next

                                        Next

                                    Catch ex As Exception
                                        ErrorMessage = ex.Message.ToString
                                        ErrorMessages.Add(ErrorMessage)
                                    End Try

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                ErrorMessages.Add(ErrorMessage)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ErrorMessages))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddEntryFromCopyFromMyRecents(ByVal EmployeeCode As String, ByVal EntryDate As Date,
                                                      ByVal AlertID As Integer,
                                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim FunctionCode As String = String.Empty
                Dim DepartmentTeamCode As String = String.Empty
                Dim Defaults As New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode, JobNumber, JobComponentNumber)
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim IsUsingDefaultFunction As Boolean = False
                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0
                Dim IsValid = True

                If Defaults IsNot Nothing Then

                    FunctionCode = Defaults.FunctionCode
                    DepartmentTeamCode = Defaults.DepartmentCode
                    IsUsingDefaultFunction = True

                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If AlertID > 0 Then

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing Then

                            If Alert.JobNumber IsNot Nothing AndAlso Alert.JobComponentNumber IsNot Nothing Then

                                JobNumber = Alert.JobNumber
                                JobComponentNumber = Alert.JobComponentNumber

                                If Alert.TaskSequenceNumber IsNot Nothing AndAlso Alert.TaskSequenceNumber > -1 Then

                                    Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                                    Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, Alert.TaskSequenceNumber)

                                    If Task IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Task.FuctionCode) = False Then

                                        FunctionCode = Task.FuctionCode
                                        IsUsingDefaultFunction = False

                                    End If

                                End If

                            End If

                        End If

                    End If
                    If String.IsNullOrWhiteSpace(FunctionCode) = False AndAlso String.IsNullOrWhiteSpace(DepartmentTeamCode) = False AndAlso
                        JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                        IsValid = ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(DbContext, EmployeeCode, True,
                                                                                      FunctionCode, IsUsingDefaultFunction,
                                                                                      DepartmentTeamCode, True,
                                                                                      ErrorMessage)

                        If IsValid = True Then

                            If _IsCurrentWeek(EntryDate) = True Then

                                EntryDate = CType(Date.Today.ToShortDateString, Date)

                            End If
                            If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate) = True Then

                                Success = _AddEntry(EmployeeCode, EntryDate, 0, "", FunctionCode, DepartmentTeamCode, JobNumber, JobComponentNumber, AlertID,
                                                ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                            Else

                                ErrorMessage = String.Format("Post period is closed for {0}.", EntryDate.DayOfWeek.ToString)

                            End If

                        End If
                        If Success = True Then

                            If String.IsNullOrWhiteSpace(ErrorMessage) OrElse (NewEmployeeTimeID = 0 AndAlso NewEmployeeTimeDetailID = 0) Then

                                ErrorMessage = "Item already on timesheet."

                            End If
                            If ErrorMessage.Contains("SUCCESS") Then

                                ErrorMessage = String.Empty

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddEntryFromCopyFromMyProjects(ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                                       ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                       ByVal TaskSequenceNumber As Short, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0
            Dim IsUsingDefaultFunction As Boolean = False
            Dim IsUsingTaskFunction As Boolean = False
            Dim IsUsingDefaultDepartment As Boolean = False
            Dim IsValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso TaskSequenceNumber > -1 Then

                    Dim TaskFunctionEstimateCode As String = String.Empty

                    Try

                        TaskFunctionEstimateCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_EST FROM JOB_TRAFFIC_DET WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};",
                                                                                                            JobNumber, JobComponentNumber, TaskSequenceNumber)).SingleOrDefault

                    Catch ex As Exception
                        TaskFunctionEstimateCode = String.Empty
                    End Try

                    If String.IsNullOrWhiteSpace(TaskFunctionEstimateCode) = False Then

                        FunctionOrCategoryCode = TaskFunctionEstimateCode

                    End If

                End If
                If String.IsNullOrWhiteSpace(FunctionOrCategoryCode) = True OrElse String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                    Dim DefaultFunctionCode As String = String.Empty
                    Dim DefaultDepartmentCode As String = String.Empty
                    Dim Defaults As New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode)

                    If Defaults IsNot Nothing Then

                        DefaultFunctionCode = Defaults.FunctionCode
                        DefaultDepartmentCode = Defaults.DepartmentCode

                    End If
                    If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso String.IsNullOrWhiteSpace(FunctionOrCategoryCode) = True Then

                        FunctionOrCategoryCode = DefaultFunctionCode
                        IsUsingDefaultFunction = True

                    End If
                    If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                        DepartmentTeamCode = DefaultDepartmentCode
                        IsUsingDefaultDepartment = True

                    End If

                End If

                IsValid = ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(DbContext, EmployeeCode, True,
                                                                              FunctionOrCategoryCode, IsUsingDefaultFunction,
                                                                              DepartmentTeamCode, IsUsingDefaultDepartment, ErrorMessage)

                If IsValid = True Then

                    If _IsCurrentWeek(EntryDate) = True Then

                        EntryDate = CType(Date.Today.ToShortDateString, Date)

                    End If
                    If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate) = True Then

                        Success = _AddEntry(EmployeeCode, EntryDate, Hours, Comment, FunctionOrCategoryCode, DepartmentTeamCode, JobNumber, JobComponentNumber, AlertID,
                                        ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                    Else

                        ErrorMessage = String.Format("Post period is closed for {0}.", EntryDate.DayOfWeek.ToString)

                    End If

                End If
                If Success = True Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) OrElse (NewEmployeeTimeID = 0 AndAlso NewEmployeeTimeDetailID = 0) Then

                        ErrorMessage = "Job already on timesheet."

                    End If
                    If ErrorMessage.Contains("SUCCESS") Then

                        ErrorMessage = String.Empty

                    End If

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddEntry(ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                 ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                 ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer?) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0
            Dim IsValid As Boolean = False

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            '    If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

            '        IsValid = ValidateFunctionCode(DbContext, EmployeeCode, FunctionOrCategoryCode, ErrorMessage)

            '    Else

            '        IsValid = True

            '    End If

            'End Using
            'If IsValid = True Then

            Success = _AddEntry(EmployeeCode, EntryDate, Hours, Comment, FunctionOrCategoryCode, DepartmentTeamCode, JobNumber, JobComponentNumber, AlertID,
                                ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

            'Else

            '    Success = False

            'End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function AddEntryFromCopyFromCalendar(ByVal EmployeeCode As String, ByVal EntryDate As Date,
                                                     ByVal EmployeeTimeStagingID As Integer,
                                                     ByVal FunctionCode As String, ByVal DepartmentCode As String,
                                                     ByVal Hours As Decimal, ByVal Comment As String,
                                                     ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                     ByVal TimeType As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Dim CategoryCode As String = String.Empty
                Dim Defaults As AdvantageFramework.Controller.Employee.EmployeeDefaults = Nothing
                Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
                Dim EmployeetimeStagingIDs As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim IsUsingDefaultFunction As Boolean = False
                Dim IsUsingDefaultDepartment As Boolean = False
                Dim IsDirectTime As Boolean = False
                Dim NewEmployeeTimeID As Integer = 0
                Dim NewEmployeeTimeDetailID As Integer = 0
                Dim IsValid = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If EmployeeTimeStagingID > 0 Then

                        EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, EmployeeTimeStagingID)

                        If EmployeeTimeStaging IsNot Nothing Then

                            EntryDate = EmployeeTimeStaging.StartDate

                            ''If EmployeeTimeStaging.StartDate IsNot Nothing AndAlso EmployeeTimeStaging.EndDate IsNot Nothing Then

                            ''    If CType(EmployeeTimeStaging.StartDate, Date).ToShortDateString = CType(EmployeeTimeStaging.EndDate, Date).ToShortDateString Then

                            ''        EntryDate = EmployeeTimeStaging.StartDate

                            ''    Else

                            ''        IsValid = False
                            ''        ErrorMessage = "Appointment cannot span multiple days for time entry."

                            ''    End If

                            ''ElseIf EmployeeTimeStaging.StartDate IsNot Nothing AndAlso EmployeeTimeStaging.EndDate Is Nothing Then

                            ''    EntryDate = EmployeeTimeStaging.StartDate

                            ''ElseIf EmployeeTimeStaging.StartDate Is Nothing AndAlso EmployeeTimeStaging.EndDate IsNot Nothing Then

                            ''    EntryDate = EmployeeTimeStaging.EndDate

                            ''End If
                            If IsValid = True Then

                                If EmployeeTimeStaging.JobNumber IsNot Nothing Then

                                    JobNumber = EmployeeTimeStaging.JobNumber

                                End If
                                If EmployeeTimeStaging.JobComponentNumber IsNot Nothing Then

                                    JobComponentNumber = EmployeeTimeStaging.JobComponentNumber

                                End If
                                If String.IsNullOrWhiteSpace(FunctionCode) = True AndAlso String.IsNullOrWhiteSpace(EmployeeTimeStaging.FunctionCode) = False Then

                                    FunctionCode = EmployeeTimeStaging.FunctionCode

                                End If
                                If String.IsNullOrWhiteSpace(DepartmentCode) = True AndAlso String.IsNullOrWhiteSpace(EmployeeTimeStaging.DepartmentCode) = False Then

                                    DepartmentCode = EmployeeTimeStaging.DepartmentCode

                                End If
                                If String.IsNullOrWhiteSpace(TimeType) = False AndAlso TimeType = "D" Then

                                    IsDirectTime = True

                                End If
                                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                                    IsDirectTime = True

                                End If
                                If String.IsNullOrWhiteSpace(FunctionCode) = True OrElse String.IsNullOrWhiteSpace(DepartmentCode) = True Then

                                    Defaults = New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode, JobNumber, JobComponentNumber)

                                    If Defaults IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(FunctionCode) = True Then

                                            FunctionCode = Defaults.FunctionCode
                                            IsUsingDefaultFunction = True

                                        End If
                                        If String.IsNullOrWhiteSpace(DepartmentCode) = True Then

                                            DepartmentCode = Defaults.DepartmentCode
                                            IsUsingDefaultDepartment = True

                                        End If

                                    End If

                                End If
                                If String.IsNullOrWhiteSpace(FunctionCode) = False AndAlso String.IsNullOrWhiteSpace(DepartmentCode) = False Then

                                    IsValid = ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(DbContext, EmployeeCode, IsDirectTime,
                                                                                                  FunctionCode, IsUsingDefaultFunction,
                                                                                                  DepartmentCode, IsUsingDefaultDepartment,
                                                                                                  ErrorMessage)

                                End If

                            End If
                            If IsValid = True Then

                                'If _IsCurrentWeek(EntryDate) = True Then

                                '    EntryDate = CType(Date.Today.ToShortDateString, Date)

                                'End If
                                If AdvantageFramework.EmployeeTimesheet.CheckIfPostPeriodIsAvailable(DbContext, EntryDate) = True Then

                                    Success = _AddEntry(EmployeeCode, EntryDate, Hours, EmployeeTimeStaging.Comments, FunctionCode, DepartmentCode, JobNumber, JobComponentNumber, 0,
                                                        ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                                Else

                                    ErrorMessage = String.Format("Post period is closed for {0}.", EntryDate.DayOfWeek.ToString)

                                End If

                            End If

                        End If

                    End If
                    If Success = True Then

                        'Delete record and store id, so the same record can not be added again.
                        If EmployeeTimeStaging IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                EmployeetimeStagingIDs = New AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

                                If Employee.CalendarTimeType = 1 Then

                                    EmployeetimeStagingIDs.GoogleID = EmployeeTimeStaging.GoogleID

                                ElseIf Employee.CalendarTimeType = 2 Then

                                    EmployeetimeStagingIDs.OutlookID = EmployeeTimeStaging.OutlookID

                                ElseIf Employee.CalendarTimeType = 3 Then

                                    EmployeetimeStagingIDs.OutlookID = EmployeeTimeStaging.OutlookID

                                End If

                                AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.Insert(DbContext, EmployeetimeStagingIDs)

                            End If
                        End If

                        ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveEntryAsTimeTemplate(ByVal EmployeeCode As String, ByVal Hours As Decimal?, ByVal Comment As String,
                                                ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                                ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0
            Dim IsValid As Boolean = False
            Dim IsDirectTime As Boolean = False
            Dim DefaultFunctionCode As String = String.Empty
            Dim DefaultDepartmentCode As String = String.Empty
            Dim Defaults As New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode, JobNumber, JobComponentNumber)
            Dim IsUsingDefaultFunction As Boolean = False
            Dim IsUsingDefaultDepartment As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If Hours Is Nothing Then Hours = 0

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    IsDirectTime = True

                End If
                If Defaults IsNot Nothing Then

                    DefaultFunctionCode = Defaults.FunctionCode
                    DefaultDepartmentCode = Defaults.DepartmentCode

                End If
                If IsDirectTime = True Then

                    If String.IsNullOrWhiteSpace(FunctionOrCategoryCode) = True Then

                        IsUsingDefaultFunction = True
                        FunctionOrCategoryCode = DefaultFunctionCode

                    End If

                End If
                If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                    IsUsingDefaultDepartment = True
                    DepartmentTeamCode = DefaultDepartmentCode

                End If

                IsValid = ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(DbContext, EmployeeCode, IsDirectTime,
                                                                              FunctionOrCategoryCode, IsUsingDefaultFunction,
                                                                              DepartmentTeamCode, IsUsingDefaultDepartment, ErrorMessage)

                If IsValid = True Then

                    Dim EmployeeTimeTemplate As New AdvantageFramework.Database.Entities.EmployeeTimeTemplate

                    EmployeeTimeTemplate.EmployeeCode = EmployeeCode
                    If JobNumber > 0 Then EmployeeTimeTemplate.JobNumber = JobNumber
                    If JobComponentNumber > 0 Then EmployeeTimeTemplate.JobComponentNumber = JobComponentNumber
                    EmployeeTimeTemplate.FunctionCode = FunctionOrCategoryCode
                    EmployeeTimeTemplate.DefaultComment = Comment
                    EmployeeTimeTemplate.DepartmentTeamCode = DepartmentTeamCode
                    EmployeeTimeTemplate.EmployeeHours = Hours

                    Success = AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.Insert(DbContext, EmployeeTimeTemplate)

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

        <AcceptVerbs("POST")>
        Public Function UpdateEntry(ByVal IsDirectTime As Boolean, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short,
                                    ByVal Hours As Decimal, ByVal Comment As String, ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                    ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0

            Dim RecordFound As Boolean = False

            Dim EmployeeCode As String = String.Empty
            Dim EntryDate As Date
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If IsDirectTime = True Then

                    Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing

                    EmployeeTimeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeIDAndEmployeeTimeDetailID(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                    If EmployeeTimeDetail IsNot Nothing Then

                        EmployeeCode = EmployeeTimeDetail.EmployeeTime.EmployeeCode
                        EntryDate = EmployeeTimeDetail.EmployeeTime.Date
                        JobNumber = EmployeeTimeDetail.JobNumber
                        JobComponentNumber = EmployeeTimeDetail.JobComponentNumber

                        RecordFound = True

                    End If

                Else

                    Dim EmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing

                    EmployeeTimeIndirect = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByEmployeeTimeIDAndEmployeeTimeIndirectID(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                    If EmployeeTimeIndirect IsNot Nothing Then

                        EmployeeCode = EmployeeTimeIndirect.EmployeeTime.EmployeeCode
                        EntryDate = EmployeeTimeIndirect.EmployeeTime.Date

                        RecordFound = True

                    End If

                End If

                If RecordFound = True Then

                    Success = Me.SaveTimeSheetDay(EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, EntryDate, Hours, Comment,
                                                  FunctionOrCategoryCode, DepartmentTeamCode, JobNumber, JobComponentNumber,
                                                  AlertID, False, False, ErrorMessage, NewEmployeeTimeID, NewEmployeeTimeDetailID)

                    If Success = True Then

                        'Try

                        '    Dim PostActions As New AdvantageFramework.Controller.Employee.PostTimeSaveActions(Me.SecuritySession, EmployeeCode, EntryDate)
                        '    PostActions.Run()

                        'Catch ex As Exception
                        'End Try

                    End If

                End If

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function CopyTimesheet(ByVal Type As Integer, ByVal EmployeeCode As String, ByVal SourceDate As Date, ByVal TargetDate As Date,
                                      ByVal IncludeHours As Boolean, ByVal IncludeComments As Boolean, ByVal SingleDay As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim CopyType As AdvantageFramework.Controller.Employee.TimesheetMvcController.CopyToType? = Nothing
            Dim RowsSaved As Integer = 0
            Dim RowsFailed As Integer = 0

            CopyType = CType(Type, AdvantageFramework.Controller.Employee.TimesheetMvcController.CopyToType)
            If CopyType Is Nothing Then CopyType = AdvantageFramework.Controller.Employee.TimesheetMvcController.CopyToType.EntireTimesheet

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.CopyTimesheet(DbContext, CopyType, EmployeeCode, SourceDate, TargetDate, IncludeHours, IncludeComments, SingleDay, ErrorMessage, RowsSaved, RowsFailed)

                    If Success = True Then

                        If SingleDay = False Then

                            TargetDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeekUser(DbContext, TargetDate)

                        End If

                        ReturnObject = New With {.TargetDate = TargetDate.ToShortDateString,
                                                 .RowsSaved = RowsSaved,
                                                 .RowsFailed = RowsFailed}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function SubmitForApproval(ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByVal Approve As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim RequiredHoursBeforeApproval As Boolean = _RequiredHoursBeforeApproval()
            Dim RequiredHoursBeforeApprovalType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType = _RequiredHoursBeforeApprovalType()
            Dim AllowApproval As Boolean = True
            Dim MissingHours As Decimal = 0

            Try

                If RequiredHoursBeforeApproval = True Then

                    If RequiredHoursBeforeApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByWeek Then

                        AllowApproval = False
                        Success = False
                        ErrorMessage = "Must submit entire week for approval"

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If Employee IsNot Nothing Then

                                AllowApproval = CheckRequiredHoursBeforeApproval(DbContext, Employee, EmployeeDate, MissingHours, ErrorMessage)

                            End If

                        End Using

                    End If

                End If
                If AllowApproval = True Then

                    Success = Me._MvcController.SubmitForApproval(Me.SecuritySession, EmployeeCode, EmployeeDate, Approve, True, ErrorMessage)

                Else

                    Success = False

                    If MissingHours = 1 Then

                        ErrorMessage = String.Format("{0} is missing one hour.", EmployeeDate.DayOfWeek)

                    Else

                        ErrorMessage = String.Format("{0} is missing {1} hours.", EmployeeDate.DayOfWeek, FormatNumber(MissingHours))

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function SubmitWeekForApproval(ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ConcatErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim RequiredHoursBeforeApproval As Boolean = _RequiredHoursBeforeApproval()
            Dim RequiredHoursBeforeApprovalType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType = _RequiredHoursBeforeApprovalType()
            Dim AllowApproval As Boolean = True
            Dim HoursText As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If RequiredHoursBeforeApproval = True Then

                        Dim StartWeekOn As DayOfWeek = AdvantageFramework.EmployeeTimesheet.GetEmployeeStartWeekOn(DbContext, EmployeeCode)
                        Dim FirstOfWeek As Date = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(CType(EmployeeDate.ToShortDateString, Date), StartWeekOn)
                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                        Dim TotalHoursMissing As Decimal = 0
                        Dim DayHoursMissing As Decimal = 0
                        Dim CheckingDate As Date
                        Dim HasMissingDay As Boolean = False
                        Dim WeeklyGoal As Decimal = 0
                        Dim WeeklyTotal As Decimal = 0
                        Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            If RequiredHoursBeforeApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.ByDay Then

                                For i As Integer = 0 To 6

                                    EmployeeTime = Nothing
                                    CheckingDate = DateAdd(DateInterval.Day, i, FirstOfWeek)
                                    DayHoursMissing = 0

                                    AllowApproval = CheckRequiredHoursBeforeApproval(DbContext, Employee, CheckingDate, DayHoursMissing, ErrorMessage)

                                    If AllowApproval = False Then

                                        If DayHoursMissing = 1 Then

                                            ConcatErrorMessage += String.Format("{0} is missing one hour.|", CheckingDate.DayOfWeek)

                                        Else

                                            ConcatErrorMessage += String.Format("{0} is missing {1} hours.|", CheckingDate.DayOfWeek, FormatNumber(DayHoursMissing, 2))

                                        End If
                                        If HasMissingDay = False Then

                                            HasMissingDay = True

                                        End If

                                    End If

                                    TotalHoursMissing += DayHoursMissing

                                Next
                                If HasMissingDay = True Then

                                    AllowApproval = False
                                    ErrorMessage = MiscFN.RemoveTrailingDelimiter(ConcatErrorMessage, "|")

                                End If

                            Else

                                Dim HolidayHours As AdvantageFramework.Timesheet.Settings.HolidayHours = Nothing

                                WeeklyGoal = 0
                                WeeklyTotal = 0

                                For i As Integer = 0 To 6

                                    EmployeeTime = Nothing
                                    HolidayHours = Nothing

                                    CheckingDate = DateAdd(DateInterval.Day, i, FirstOfWeek)

                                    EmployeeTime = AdvantageFramework.Database.Procedures.EmployeeTime.LoadByEmployeeCodeAndDate(DbContext, Employee.Code, CheckingDate)
                                    HolidayHours = AdvantageFramework.Database.Procedures.EmployeeTime.GetHolidayHours(DbContext, CheckingDate)

                                    If EmployeeTime IsNot Nothing Then

                                        If EmployeeTime.TotalHours IsNot Nothing Then

                                            WeeklyTotal += EmployeeTime.TotalHours

                                        End If

                                    End If
                                    Select Case CheckingDate.DayOfWeek
                                        Case DayOfWeek.Sunday

                                            If Employee.SundayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.SundayHours = 0

                                                    Else

                                                        Employee.SundayHours = Employee.SundayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.SundayHours

                                            End If

                                        Case DayOfWeek.Monday

                                            If Employee.MondayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.MondayHours = 0

                                                    Else

                                                        Employee.MondayHours = Employee.MondayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.MondayHours

                                            End If

                                        Case DayOfWeek.Tuesday

                                            If Employee.TuesdayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.TuesdayHours = 0

                                                    Else

                                                        Employee.TuesdayHours = Employee.TuesdayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.TuesdayHours

                                            End If

                                        Case DayOfWeek.Wednesday

                                            If Employee.WednesdayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.WednesdayHours = 0

                                                    Else

                                                        Employee.WednesdayHours = Employee.WednesdayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.WednesdayHours

                                            End If

                                        Case DayOfWeek.Thursday

                                            If Employee.ThursdayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.ThursdayHours = 0

                                                    Else

                                                        Employee.ThursdayHours = Employee.ThursdayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.ThursdayHours

                                            End If

                                        Case DayOfWeek.Friday

                                            If Employee.FridayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.FridayHours = 0

                                                    Else

                                                        Employee.FridayHours = Employee.FridayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.FridayHours

                                            End If

                                        Case DayOfWeek.Saturday

                                            If Employee.SaturdayHours IsNot Nothing Then

                                                If HolidayHours IsNot Nothing Then

                                                    If HolidayHours.IsAllDay = True Then

                                                        Employee.SaturdayHours = 0

                                                    Else

                                                        Employee.SaturdayHours = Employee.SaturdayHours - HolidayHours.Hours

                                                    End If

                                                End If

                                                WeeklyGoal += Employee.SaturdayHours

                                            End If

                                    End Select

                                Next

                                TotalHoursMissing = WeeklyGoal - WeeklyTotal

                                If TotalHoursMissing > 0 Then

                                    AllowApproval = False

                                    If TotalHoursMissing = 1 Then

                                        HoursText = "one more hour"

                                    Else

                                        HoursText = FormatNumber(TotalHoursMissing, 2) & " more hours"

                                    End If

                                    ErrorMessage = String.Format("You must enter {0} for the week before you can submit your time for approval.", HoursText)

                                End If

                            End If

                        End If

                    End If
                    If AllowApproval = True Then

                        Success = AdvantageFramework.EmployeeTimesheet.SubmitWeekForApproval(Me.SecuritySession, DbContext, EmployeeCode, EmployeeDate, ErrorMessage)

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <AcceptVerbs("POST")>
        Public Function UnSubmitWeekForApproval(ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = AdvantageFramework.EmployeeTimesheet.UnSubmitWeekForApproval(Me.SecuritySession, DbContext, EmployeeCode, EmployeeDate, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function


        <AcceptVerbs("POST")>
        Public Function NotifySupervisorOfApproval(ByVal EmployeeCode As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    If DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AUTO_ALERT_SUPER, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault() = 1 Then

                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.SupervisorEmployeeCode) = False Then

                            ''Webvantage.SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Employee.SupervisorEmployeeCode)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveUserTimesheetSort(ByVal SortValue As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String
            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)

            Try

                av.getAllAppVars()
                av.setAppVar("SORT", SortValue, "String")
                av.SaveAllAppVars()
                Success = True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Success = False
            End Try

            If Success = True Then

                Session(UserTimesheetSortSessionKey) = SortValue

            Else

                Session(UserTimesheetSortSessionKey) = _DefaultUserTimesheetSort

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

        <AcceptVerbs("POST")>
        Public Function SaveUserTimesheetSettings(ByVal StartWeekOnDay As Short, ByVal DaysToDisplay As Short,
                                                  ByVal ShowJobName As Boolean, ByVal ShowComponentName As Boolean, ByVal ShowJobComponentNumber As Boolean,
                                                  ByVal ShowClient As Boolean, ByVal ShowDivision As Boolean, ByVal ShowProduct As Boolean,
                                                  ByVal ShowFunctionCategory As Boolean, ByVal ShowAssignment As Boolean,
                                                  ByVal AddUniqueRowWhenComment As Boolean,
                                                  ByVal ShowProgressBar As Boolean,
                                                  ByVal ShowHoursRemaining As Boolean,
                                                  ByVal RepeatRowForAllDays As Boolean) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String
            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

            Try

                ShowJobName = True

                UserSettings = New AdvantageFramework.ViewModels.Employee.Timesheet.Settings

                UserSettings.StartTimesheetOnDayOfWeek = StartWeekOnDay
                UserSettings.DaysToDisplay = DaysToDisplay
                UserSettings.ShowJobName = ShowJobName
                UserSettings.ShowComponentName = ShowComponentName
                UserSettings.ShowJobAndComponentNumber = ShowJobComponentNumber
                UserSettings.ShowClientName = ShowClient
                UserSettings.ShowDivisionName = ShowDivision
                UserSettings.ShowProductName = ShowProduct
                UserSettings.ShowFunctionCategory = ShowFunctionCategory
                UserSettings.ShowAssignment = ShowAssignment
                UserSettings.AddUniqueRowWhenComment = AddUniqueRowWhenComment
                UserSettings.ShowProgressBar = ShowProgressBar
                UserSettings.ShowHoursRemaining = ShowHoursRemaining
                UserSettings.RepeatRowForAllDays = RepeatRowForAllDays

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.SaveUserSettings(DbContext, UserSettings)

                    If Success = True Then

                        Session(UserSettingSessionKey) = Nothing

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function

#Region " Stopwatch "

        <AcceptVerbs("POST")>
        Public Function StartStopwatch(ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comments As String,
                                       ByVal FunctionCode As String, ByVal DepartmentTeamCode As String,
                                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim SavedHours As Decimal = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                EntryDate = Now

                If AdvantageFramework.EmployeeTimesheet.TimeEntryExists(DbContext, EmployeeCode, EntryDate, Hours, JobNumber, JobComponentNumber, FunctionCode, AlertID,
                                                                        EmployeeTimeID, EmployeeTimeDetailID, SavedHours, Comments, ErrorMessage) Then

                    If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                        Success = True

                        If SavedHours + Hours >= 24 Then

                            Success = False
                            ErrorMessage = String.Format("Already {0} hours on this entry.", Hours)

                        End If

                    End If

                Else

                    Success = Me.SaveTimeSheetDay(0, 0, EmployeeCode, EntryDate, Hours, Comments, FunctionCode, "",
                                                  JobNumber, JobComponentNumber, AlertID, False, False, ErrorMessage, EmployeeTimeID, EmployeeTimeDetailID)

                End If

            End Using

            If Success = True Then

                If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                    Try

                        Success = AdvantageFramework.EmployeeTimesheet.StopwatchStart(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode,
                                                                                  EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID, ErrorMessage)

                    Catch ex As Exception
                        ErrorMessage = Me.FullErrorMessageToString(ex)
                        Success = False
                    End Try

                Else

                    Success = False
                    ErrorMessage = "Could not find entry to start stopwatch."

                End If

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function StartStopwatchFromRow(ByVal EmployeeCode As String, ByVal EntryDate As Date,
                                              ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                              ByVal FunctionCode As String, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim Hours As Decimal = 0
            Dim Comments As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                If AdvantageFramework.EmployeeTimesheet.TimeEntryExists(DbContext, EmployeeCode, EntryDate, 0, JobNumber, JobComponentNumber, FunctionCode, AlertID,
                                                                        EmployeeTimeID, EmployeeTimeDetailID, Hours, Comments, ErrorMessage) Then

                    If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                        Success = True

                        If Hours >= 24 Then

                            Success = False
                            ErrorMessage = String.Format("Already {0} hours on this entry.", Hours)

                        End If

                    End If

                Else

                    Success = Me.SaveTimeSheetDay(0, 0, EmployeeCode, EntryDate, Hours, Comments, FunctionCode, "",
                                                  JobNumber, JobComponentNumber, AlertID, False, False, ErrorMessage, EmployeeTimeID, EmployeeTimeDetailID)

                End If

            End Using

            If Success = True AndAlso EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                Try

                    Success = AdvantageFramework.EmployeeTimesheet.StopwatchStart(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode,
                                                                                  EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID, ErrorMessage)

                Catch ex As Exception
                    ErrorMessage = Me.FullErrorMessageToString(ex)
                    Success = False
                End Try

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function HasStopwatch(ByVal EmployeeCode As String) As JsonResult

            Dim StopwatchIsRunning As Boolean = False
            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim StopwatchStartDate As Date
            Dim Comment As String = String.Empty
            Dim Description As String = String.Empty
            Dim TimeType As String = String.Empty
            Dim StopwatchServerTime As Date
            Dim IsOverTwentyFourHours As Boolean = False
            Dim RunningTime As New TimeSpan
            Dim DateString As String = String.Empty
            Dim IsCommentRequired As Boolean = False
            Dim TimesheetSettings As New AdvantageFramework.Timesheet.TimesheetSettings(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
            Dim HasComments As Boolean = False

            If AdvantageFramework.Timesheet.HasStopWatch(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.CurrentEmployeeCode,
                                                         EmployeeTimeID, EmployeeTimeDetailID, StopwatchStartDate, Comment, Description, TimeType, StopwatchServerTime) = True Then

                StopwatchIsRunning = True
                RunningTime = Me.TimeZoneToday.Subtract(StopwatchStartDate)
                IsOverTwentyFourHours = RunningTime.TotalHours > 24
                DateString = StopwatchStartDate.ToString("MMMM dd, yyyy H:mm:ss")

                If TimesheetSettings.CommentsRequired = True AndAlso Comment = "" AndAlso TimeType = "D" AndAlso TimesheetSettings.TimeEntryCommentRequired(EmployeeTimeID, EmployeeTimeDetailID) = True Then

                    IsCommentRequired = True

                End If
                If String.IsNullOrWhiteSpace(Comment) = False Then

                    HasComments = True

                End If

            End If

            Return MaxJson(New With {.StopwatchIsRunning = StopwatchIsRunning,
                                     .DateString = DateString,
                                     .ServerTime = StopwatchServerTime,
                                     .Description = Description,
                                     .CommentsRequired = IsCommentRequired,
                                     .HasComments = HasComments})

        End Function
        <AcceptVerbs("POST")>
        Public Function StopStopwatch(ByVal EmployeeCode As String) As JsonResult

            Dim StopWatch As Boolean = False
            Dim EtId As Integer = 0
            Dim EtDtlId As Integer = 0
            Dim StopwatchStartDate As Date = Nothing
            Dim Comment As String = ""
            Dim Description As String = ""
            Dim StopwatchServerTime As Date
            Dim TimeType As String = ""
            Dim stopped As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If AdvantageFramework.Timesheet.HasStopWatch(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.CurrentEmployeeCode, EtId, EtDtlId, StopwatchStartDate, Comment, Description, TimeType, StopwatchServerTime) = True Then

                StopWatch = True

                If EtId > 0 And EtDtlId > 0 Then

                    Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Dim Hours As Decimal = 0.0
                    Dim s As String = ""

                    If ts.CommentsRequired = True And Comment = "" And TimeType = "D" And ts.TimeEntryCommentRequired(EtId, EtDtlId) = True Then

                        ErrorMessage = "Comment is required."
                        stopped = False

                    Else

                        stopped = AdvantageFramework.Timesheet.StopwatchStop(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.CurrentEmployeeCode, EtId, EtDtlId, Hours, "", s)

                    End If

                End If

            End If

            Return MaxJson(New With {.Success = stopped, .Message = ErrorMessage})

        End Function

#End Region

#End Region

        <HttpPost>
        Public Function SaveTimesheetUserSettings(ByVal Settings As AdvantageFramework.DTO.Employee.Timesheet.Settings) As JsonResult

            Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
            av.getAllAppVars()
            av.setAppVar("DAYS_TO_DISPLAY", Settings.DaysToDisplay, "Integer")
            av.setAppVar("SHOW_CMNT_USING", Settings.ShowCommentsUsing, "String")
            av.setAppVar("START_WEEK_ON", Settings.StartTimesheetOnDayOfWeek, "Integer")
            'av.setAppVar("MAIN_TS_NO_PAGING", Settings.DisablePagingOnMainGrid.ToString(), "Boolean")
            'av.setAppVar("REPEAT_ROWS", Settings.RepeatRowForAllDays.ToString(), "Boolean")
            'av.setAppVar("ONLY_SHOW_MY_PROGRESS", Settings.OnlyShowMyProgress.ToString(), "Boolean")

            av.setAppVar("DIVISION", Settings.DivisionLabel, "String")
            av.setAppVar("PRODUCT", Settings.ProductLabel, "String")
            av.setAppVar("PROD_CAT", Settings.ProductCategoryLabel, "String")
            av.setAppVar("JOB", Settings.JobLabel, "String")
            av.setAppVar("JOB_COMP", Settings.JobComponentLabel, "String")
            av.setAppVar("FUNC_CAT", Settings.FunctionCategoryLabel, "String")

            av.SaveAllAppVars()

            Return Json(Settings)

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateCategory(ByVal Entries As String, ByVal CategoryCode As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.UpdateCategory(DbContext, Entries, CategoryCode, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateFunction(ByVal Entries As String, ByVal FunctionCode As String, ByVal EmployeeCode As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.UpdateFunction(DbContext, Me.SecuritySession, EmployeeCode, Entries, FunctionCode, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdateAssignment(ByVal Entries As String, ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = _MvcController.UpdateAssignment(DbContext, Entries, AlertID, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <AcceptVerbs("Post")>
        Function FunctionCategories(SearchCriteriaText As String) As ActionResult
            Dim Results As List(Of FunctionCategorySearchResult) = Nothing
            Dim SearchCriteria As FunctionCategory = Nothing
            Dim EmployeeRepo As Interfaces.IEmployeeRepository = Nothing

            SearchCriteria = New FunctionCategory()
            Results = New List(Of FunctionCategorySearchResult)

            Try
                If (SearchCriteriaText.Length > 0) Then
                    SearchCriteria = Newtonsoft.Json.JsonConvert.DeserializeObject(Of FunctionCategory)(SearchCriteriaText)
                    SearchCriteria.SearchText = SearchCriteria.SearchText.Trim()
                End If

                If SecuritySession IsNot Nothing Then
                    EmployeeRepo = New Repositories.EmployeeRepository(SecuritySession)
                    Results = EmployeeRepo.SearchFunctionCategories(SearchCriteria)
                End If
            Catch ex As Exception
                Results = New List(Of FunctionCategorySearchResult)
                LogError(ex)
            End Try

            FunctionCategories = Json(Results)
        End Function
        <AcceptVerbs("Post")>
        Function Settings(SearchCriteriaText As String) As ActionResult
            Dim Results As ViewModels.TimesheetSettings = Nothing
            Dim TimesheetRepo As Interfaces.ITimesheetRepository = Nothing

            Dim searchCriteria As ViewModels.LookupSearchCriteria = Nothing

            Try
                If (SearchCriteriaText.Length > 0) Then
                    searchCriteria = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ViewModels.LookupSearchCriteria)(SearchCriteriaText)
                Else
                    searchCriteria = New ViewModels.LookupSearchCriteria()
                End If

                Results = New ViewModels.TimesheetSettings


                If SecuritySession IsNot Nothing Then
                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)
                        TimesheetRepo = New Repositories.TimesheetRepository(DataContext, SecuritySession)

                        Results.CommentsDisplayMode = TimesheetRepo.CommentsDisplayMode
                        Results.CommentsRequired = TimesheetRepo.CommentsRequired
                        Results.CommentsRequiredAgencyLevel = TimesheetRepo.CommentsRequiredAgencyLevel

                        If searchCriteria.JobComponent.JobNumber.HasValue Then
                            Results.CommentsRequiredForJob = TimesheetRepo.CommentsRequiredForJob(searchCriteria.JobComponent.JobNumber)
                        End If

                        Results.CommentsRequiredForApproval = TimesheetRepo.CommentsRequiredForApproval
                    End Using
                End If
            Catch ex As Exception
                Results = New ViewModels.TimesheetSettings
                LogError(ex)
            End Try

            Settings = Json(Results)
        End Function
        <AcceptVerbs("Post")>
        Function ValidateEntry(ValidationRequestText As String) As ActionResult
            Dim Results As TimesheetValidationResult = Nothing
            Dim ValidationRequest As TimesheetValidationRequest = Nothing
            Dim TimesheetRepo As Interfaces.ITimesheetRepository = Nothing

            ValidationRequest = New TimesheetValidationRequest()
            Results = New TimesheetValidationResult()

            Try
                If (ValidationRequestText.Length > 0) Then
                    ValidationRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of TimesheetValidationRequest)(ValidationRequestText)
                End If

                If SecuritySession IsNot Nothing Then
                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)
                        TimesheetRepo = New Repositories.TimesheetRepository(DataContext, SecuritySession)
                        Results = TimesheetRepo.ValidateTimesheetEntry(ValidationRequest)
                    End Using
                End If
            Catch ex As Exception
                Results = New TimesheetValidationResult()
                Results.ErrorMessage = ex.Message
                Results.ValidationPassed = False
                LogError(ex)
            End Try

            ValidateEntry = Json(Results)
        End Function
        <AcceptVerbs("Post")>
        Function ValidateEntryAccount(ValidationRequestText As String) As ActionResult
            Dim Results As TimesheetValidationResult = Nothing
            Dim ValidationRequest As TimesheetValidationRequest = Nothing
            Dim TimesheetRepo As Interfaces.ITimesheetRepository = Nothing

            ValidationRequest = New TimesheetValidationRequest()
            Results = New TimesheetValidationResult()

            Try
                If (ValidationRequestText.Length > 0) Then
                    ValidationRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of TimesheetValidationRequest)(ValidationRequestText)
                End If

                If SecuritySession IsNot Nothing Then
                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)
                        TimesheetRepo = New Repositories.TimesheetRepository(DataContext, SecuritySession)
                        Results = TimesheetRepo.ValidateAccountSetupEntry(ValidationRequest)
                    End Using
                End If
            Catch ex As Exception
                Results = New TimesheetValidationResult()
                Results.ErrorMessage = ex.Message
                Results.ValidationPassed = False
                LogError(ex)
            End Try

            ValidateEntryAccount = Json(Results)
        End Function
        <AcceptVerbs("Post")>
        Function EmployeeDefaultFunction(EmployeeCode As String) As ActionResult

            Dim JSON As String

            JSON = String.Format("{{ ""EmployeeDefaultFunction"" : ""{0}"" }}", _EmployeeDefaultFunction(EmployeeCode))

            Response.Clear()
            Response.ContentType = "application/json; charset=utf-8"
            Response.Write(JSON)

        End Function
        <AcceptVerbs("Post")>
        Function CheckForMissingDeniedTime() As String

            Dim LegacyTimesheetClass As New Webvantage.wvTimeSheet.cTimeSheet(SecuritySession.ConnectionString)
            Dim HasMissingTime As Boolean = False
            Dim HasDeniedTime As Boolean = False
            Dim TimeMessage As String = String.Empty

            LegacyTimesheetClass.LoadMissingDeniedTimeMessage(SecuritySession.ConnectionString, SecuritySession.UserCode, HasMissingTime, HasDeniedTime, TimeMessage)

            Return TimeMessage

        End Function
        <HttpPost>
        Function Bookmark(ByVal PageURL As String, ByVal Name As String) As String
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_TimeSheet
                .UserCode = Session("UserCode")
                .Name = Name
                .PageURL = PageURL

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

            Return s
        End Function

#End Region

#Region " Private "
        Private Function GetUserColors(ByVal DbContext As AdvantageFramework.Database.DbContext) As UserColors

            Dim UC As New UserColors
            Dim Color As String = String.Empty
            Dim SQL As String = " SELECT AV.VARIABLE_VALUE FROM APP_VARS AV WITH(NOLOCK) WHERE AV.[USERID] = '{0}' 
                                  AND AV.[VARIABLE_NAME] = 'SMPL_BG_COLOR' AND AV.[APPLICATION] = 'MY_SETTINGS'; "

            Try

                Color = DbContext.Database.SqlQuery(Of String)(String.Format(SQL, DbContext.UserCode)).SingleOrDefault

            Catch ex As Exception
                Color = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(Color) = True Then

                Color = "#808080"

            End If

            UC.Primary = Color.ToUpper

            Select Case UC.Primary
                Case "#2A579A"

                    UC.AltPrimary = "#B2EBF2"

                Case "#FFC107"

                    UC.AltPrimary = "#FF8F00"

                Case "#000000"

                    UC.AltPrimary = "#424242"

                Case "#2196F3"

                    UC.AltPrimary = "#1565C0"

                Case "#607D8B"

                    UC.AltPrimary = "#37474F"

                Case "#795548"

                    UC.AltPrimary = "#4E342E"

                Case "#00BCD4"

                    UC.AltPrimary = "#00838F"

                Case "#FF5722"

                    UC.AltPrimary = "#D84315"

                Case "#673AB7"

                    UC.AltPrimary = "#4527A0"

                Case "#9E9E9E" 'gray

                    UC.AltPrimary = "#424242"

                Case "#4CAF50"

                    UC.AltPrimary = "#2E7D32"

                Case "#3F51B5"

                    UC.AltPrimary = "#283593"

                Case "#03A9F4"

                    UC.AltPrimary = "#0277BD"

                Case "#8BC34A"

                    UC.AltPrimary = "#558B2F"

                Case "#C0CA33"

                    UC.AltPrimary = "#9E9D24"

                Case "#FF9800"

                    UC.AltPrimary = "#EF6C00"

                Case "#EFC1B4"

                    UC.AltPrimary = "#895B4E"

                Case "#E91E63"

                    UC.AltPrimary = "#AD1457"

                Case "#9C27B0"

                    UC.AltPrimary = "#6A1B9A"

                Case "#F44336"

                    UC.AltPrimary = "#C62828"

                Case "#009688"

                    UC.AltPrimary = "#00695C"

                Case "#E0E0E0"

                    UC.AltPrimary = "#616161"

                Case "#FFEB3B"

                    UC.AltPrimary = "#F9A825"

                Case Else

                    UC.Primary = "#808080"
                    UC.AltPrimary = "#474747"

            End Select

            Return UC

        End Function
        Private Function CheckRequiredHoursBeforeApproval(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                          ByVal EmployeeDate As Date,
                                                          ByRef HoursNeeded As Decimal,
                                                          ByRef ErrorMessage As String) As Boolean


            Dim AllowApproval As Boolean = True
            Dim RequiredHoursBeforeApproval As Boolean = _RequiredHoursBeforeApproval()
            Dim RequiredHoursBeforeApprovalType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType = _RequiredHoursBeforeApprovalType()

            HoursNeeded = 0

            Try

                If RequiredHoursBeforeApproval = True Then

                    Dim SelectedDayOfWeek As DayOfWeek = EmployeeDate.DayOfWeek
                    Dim EmployeeDayRequiredHours As Decimal = 0
                    Dim EmployeeCurrentTotalHours As Decimal = 0
                    Dim HolidayHours As AdvantageFramework.Timesheet.Settings.HolidayHours = Nothing

                    If Employee IsNot Nothing Then

                        Select Case SelectedDayOfWeek
                            Case DayOfWeek.Sunday

                                If Employee.SundayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.SundayHours

                            Case DayOfWeek.Monday

                                If Employee.MondayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.MondayHours

                            Case DayOfWeek.Tuesday

                                If Employee.TuesdayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.TuesdayHours

                            Case DayOfWeek.Wednesday

                                If Employee.WednesdayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.WednesdayHours

                            Case DayOfWeek.Thursday

                                If Employee.ThursdayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.ThursdayHours

                            Case DayOfWeek.Friday

                                If Employee.FridayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.FridayHours

                            Case DayOfWeek.Saturday

                                If Employee.SaturdayHours IsNot Nothing Then EmployeeDayRequiredHours = Employee.SaturdayHours

                        End Select

                        If EmployeeDayRequiredHours > 0 Then

                            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

                            EmployeeTime = AdvantageFramework.Database.Procedures.EmployeeTime.LoadByEmployeeCodeAndDate(DbContext, Employee.Code, EmployeeDate)

                            If EmployeeTime IsNot Nothing Then

                                If EmployeeTime.TotalHours IsNot Nothing Then

                                    EmployeeCurrentTotalHours = EmployeeTime.TotalHours

                                End If

                            End If

                            HolidayHours = AdvantageFramework.Database.Procedures.EmployeeTime.GetHolidayHours(DbContext, EmployeeDate)

                            If HolidayHours IsNot Nothing Then

                                If HolidayHours.IsAllDay = True Then

                                    EmployeeDayRequiredHours = 0

                                Else

                                    EmployeeDayRequiredHours = EmployeeDayRequiredHours - HolidayHours.Hours

                                End If

                            End If

                            If EmployeeCurrentTotalHours >= EmployeeDayRequiredHours Then

                                AllowApproval = True

                            Else

                                HoursNeeded = EmployeeDayRequiredHours - EmployeeCurrentTotalHours
                                'ErrorMessage = String.Format("You are submitting {0} hours.  At least {1} hours are required.",
                                '                             FormatNumber(EmployeeCurrentTotalHours, 2),
                                '                             FormatNumber(EmployeeDayRequiredHours, 2))
                                ErrorMessage = String.Format("You must enter a total of {0} hours before you can submit your time for approval.",
                                                             FormatNumber(HoursNeeded, 2))
                                AllowApproval = False

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                AllowApproval = True
            End Try

            Return AllowApproval

        End Function
        Private Function GetEmployeeTimeTemplatesView() As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)

            Dim EmployeeCode As String = String.Empty
            Dim EmployeeTimeTemplates As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate) = Nothing

            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = False Then EmployeeCode = CurrentQueryString.EmployeeCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.EmployeeCode) = True Then EmployeeCode = Me.CurrentEmployeeCode

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                EmployeeTimeTemplates = AdvantageFramework.EmployeeTimesheet.LoadEmployeeTimeTemplates(DbContext, SecuritySession.UserCode, EmployeeCode)

            End Using

            If EmployeeTimeTemplates Is Nothing Then EmployeeTimeTemplates = New Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)

            ViewData("EmployeeCode") = EmployeeCode

            Return EmployeeTimeTemplates

        End Function
        Private Function LoadAllUserSettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ViewModels.Employee.Timesheet.Settings

            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing

            Try

                UserSettings = _MvcController.GetUserSettings(DbContext)

                If UserSettings IsNot Nothing Then

                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.SecuritySession.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        If Employee.SundayHours IsNot Nothing Then UserSettings.SundayHoursGoal = Employee.SundayHours
                        If Employee.MondayHours IsNot Nothing Then UserSettings.MondayHoursGoal = Employee.MondayHours
                        If Employee.TuesdayHours IsNot Nothing Then UserSettings.TuesdayHoursGoal = Employee.TuesdayHours
                        If Employee.WednesdayHours IsNot Nothing Then UserSettings.WednesdayHoursGoal = Employee.WednesdayHours
                        If Employee.ThursdayHours IsNot Nothing Then UserSettings.ThursdayHoursGoal = Employee.ThursdayHours
                        If Employee.FridayHours IsNot Nothing Then UserSettings.FridayHoursGoal = Employee.FridayHours
                        If Employee.SaturdayHours IsNot Nothing Then UserSettings.SaturdayHoursGoal = Employee.SaturdayHours

                    End If

                End If

            Catch ex As Exception
            End Try

            If UserSettings Is Nothing Then UserSettings = New AdvantageFramework.ViewModels.Employee.Timesheet.Settings

            Return UserSettings

        End Function
        Private Function _EmployeeDefaultFunction(EmployeeCode As String) As String

            Dim Key As String = "_eDF_" & EmployeeCode
            Dim CurrentEmployeeDefaultFunction As String = String.Empty

            If Session(Key) IsNot Nothing Then

                CurrentEmployeeDefaultFunction = Session(Key)

            Else

                Dim EmployeeRepository As Repositories.EmployeeRepository = Nothing

                Try
                    If SecuritySession IsNot Nothing Then

                        EmployeeRepository = New Repositories.EmployeeRepository(SecuritySession)
                        CurrentEmployeeDefaultFunction = EmployeeRepository.GetDefaultEmployeeFunction(EmployeeCode)
                        Session(Key) = CurrentEmployeeDefaultFunction

                    End If
                Catch ex As Exception
                    CurrentEmployeeDefaultFunction = String.Empty
                End Try

            End If

            Return CurrentEmployeeDefaultFunction

        End Function
        Private Function _RequiredHoursBeforeApproval() As Boolean

            Dim RequireHours As Boolean = False

            If HttpContext.Session(RequiredHoursBeforeApprovalSessionKey) Is Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        RequireHours = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS BIT) FROM AGY_SETTINGS WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_HRS_MET_APPR';")).SingleOrDefault

                    End Using

                Catch ex As Exception
                    RequireHours = False
                End Try

                HttpContext.Session(RequiredHoursBeforeApprovalSessionKey) = RequireHours

            Else

                RequireHours = CType(HttpContext.Session(RequiredHoursBeforeApprovalSessionKey), Boolean)

            End If

            Return RequireHours

        End Function
        Private Function _RequiredHoursBeforeApprovalType() As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType

            Dim SubmitType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.None

            If HttpContext.Session(RequiredHoursBeforeApprovalTypeSessionKey) Is Nothing Then

                Dim i As Short = 0

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        i = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) FROM AGY_SETTINGS WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_REQ_HRS_APPR_TYPE';")).SingleOrDefault

                    End Using

                Catch ex As Exception
                    i = 0
                End Try

                SubmitType = CType(i, AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType)
                Session(RequiredHoursBeforeApprovalTypeSessionKey) = SubmitType

            Else

                SubmitType = CType(Session(RequiredHoursBeforeApprovalTypeSessionKey), AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType)

            End If

            Return SubmitType

        End Function
        Private Function _IsApprovalActive(ByVal EmployeeCode As String) As Boolean

            Dim ApprovalActive As Boolean = False

            If EmployeeCode = SecuritySession.User.EmployeeCode Then

                If HttpContext.Session(IsApprovalActiveSessionKey) Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        ApprovalActive = AdvantageFramework.EmployeeTimesheet.CheckIfApprovalRequired(DbContext, EmployeeCode)
                        HttpContext.Session(IsApprovalActiveSessionKey) = ApprovalActive

                    End Using

                Else

                    ApprovalActive = CType(HttpContext.Session(IsApprovalActiveSessionKey), Boolean)

                End If

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    ApprovalActive = AdvantageFramework.EmployeeTimesheet.CheckIfApprovalRequired(DbContext, EmployeeCode)

                End Using

            End If

            Return ApprovalActive

        End Function
        Private Function ValidateFunctionCodeOrCategoryCodeAndDepartmentCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                             ByVal EmployeeCode As String, ByVal IsDirectTime As Boolean,
                                                                             ByVal FunctionCategoryCode As String, ByVal IsUsingDefaultFunction As Boolean,
                                                                             ByVal DepartmentCode As String, ByVal IsUsingDefaultDepartment As Boolean,
                                                                             ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True

            If IsDirectTime = True Then

                If String.IsNullOrWhiteSpace(FunctionCategoryCode) = False Then

                    If AdvantageFramework.EmployeeTimesheet.IsFunctionValid(DbContext, EmployeeCode, FunctionCategoryCode) = False Then

                        IsValid = False

                        If EmployeeCode = Me.SecuritySession.User.EmployeeCode Then

                            If IsUsingDefaultFunction = True Then

                                ErrorMessage = "You do not have access to your default function."

                            Else

                                ErrorMessage = "You do not have access to this function."

                            End If

                        Else

                            If IsUsingDefaultFunction = True Then

                                ErrorMessage = "This employee does not have access to his/her default function."

                            Else

                                ErrorMessage = "This emloyee does not have access to this function."

                            End If

                        End If

                    End If

                Else

                    If IsUsingDefaultFunction = True Then

                        ErrorMessage = "No default function."
                        IsValid = False

                    Else

                        ErrorMessage = "No function."
                        IsValid = False

                    End If

                End If

            Else

                If String.IsNullOrWhiteSpace(FunctionCategoryCode) = False Then

                    If AdvantageFramework.EmployeeTimesheet.IsCategoryValid(DbContext, FunctionCategoryCode) = False Then

                        IsValid = False
                        ErrorMessage = "Invalid category."

                    End If

                Else

                    IsValid = False
                    ErrorMessage = "No category code."

                End If

            End If
            If String.IsNullOrWhiteSpace(DepartmentCode) = True Then

                IsValid = False

                If IsUsingDefaultDepartment = True Then

                    ErrorMessage = "No default department."

                Else

                    ErrorMessage = "No department code."

                End If

            End If

            Return IsValid

        End Function
        Private Function ValidateFunctionCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal EmployeeCode As String, ByVal FunctionCode As String,
                                              ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = False
            Dim IsUsingDefaultFunction As Boolean = False
            ErrorMessage = String.Empty

            If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                If AdvantageFramework.EmployeeTimesheet.IsFunctionValid(DbContext, EmployeeCode, FunctionCode) = False Then

                    IsValid = False

                    If EmployeeCode = Me.SecuritySession.User.EmployeeCode Then

                        If IsUsingDefaultFunction = True Then

                            ErrorMessage = "You do not have access to your default function."

                        Else

                            ErrorMessage = "You do not have access to this function."

                        End If

                    Else

                        If IsUsingDefaultFunction = True Then

                            ErrorMessage = "This employee does not have access to his/her default function."

                        Else

                            ErrorMessage = "This emloyee does not have access to this function."

                        End If

                    End If

                Else

                    IsValid = True
                    ErrorMessage = String.Empty

                End If

            Else

                IsValid = True
                ErrorMessage = String.Empty

            End If

            Return IsValid

        End Function
        Private Function _AddEntry(ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                   ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                   ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer,
                                   ByRef ErrorMessage As String, ByRef NewEmployeeTimeID As Integer, ByRef NewEmployeeTimeDetailID As Integer) As Boolean

            Dim Success As Boolean = False
            ErrorMessage = String.Empty

            If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

                DepartmentTeamCode = ""

            End If

            Try

                Success = Me.SaveTimeSheetDay(0, 0, EmployeeCode, EntryDate, Hours, Comment,
                                              FunctionOrCategoryCode, DepartmentTeamCode,
                                              JobNumber, JobComponentNumber, AlertID,
                                              False, False,
                                              ErrorMessage,
                                              NewEmployeeTimeID, NewEmployeeTimeDetailID)

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If Success = True Then


            End If

            Return Success

        End Function
        Private Function SaveTimeSheetDay(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer,
                                          ByVal EmployeeCode As String, ByVal EntryDate As Date, ByVal Hours As Decimal, ByVal Comment As String,
                                          ByVal FunctionOrCategoryCode As String, ByVal DepartmentTeamCode As String,
                                          ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal AlertID As Integer,
                                          ByVal ForceDefaultFunction As Boolean, ByVal ForceDefaultDepartment As Boolean,
                                          ByRef ErrorMessage As String, ByRef NewEmployeeTimeID As Integer, ByRef NewEmployeeTimeDetailID As Integer) As Boolean

            Dim Success As Boolean = False
            Dim ProductCategory As String = "" 'Do wee need this anymore?
            Dim IsNewEntry As Boolean = False
            Dim IsDirectTime As Boolean = False
            Dim DefaultFunctionCode As String = String.Empty
            Dim DefaultDepartmentCode As String = String.Empty
            Dim Defaults As New AdvantageFramework.Controller.Employee.EmployeeDefaults(Me.SecuritySession, EmployeeCode, JobNumber, JobComponentNumber)
            Dim CurrentDayEditStatus As AdvantageFramework.Timesheet.TimesheetEditType

            If EmployeeTimeID = 0 AndAlso EmployeeTimeDetailID = 0 Then IsNewEntry = True
            If JobNumber > 0 AndAlso JobComponentNumber > 0 Then IsDirectTime = True
            If Defaults IsNot Nothing Then

                DefaultFunctionCode = Defaults.FunctionCode
                DefaultDepartmentCode = Defaults.DepartmentCode

            End If
            If IsNewEntry = True Then

                If IsDirectTime = True Then

                    If String.IsNullOrWhiteSpace(FunctionOrCategoryCode) = True Then FunctionOrCategoryCode = DefaultFunctionCode

                End If

                If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then DepartmentTeamCode = DefaultDepartmentCode

            End If
            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                CurrentDayEditStatus = AdvantageFramework.EmployeeTimesheet.CheckEditStatus(DbContext, EmployeeCode, EntryDate)

                If AdvantageFramework.EmployeeTimesheet.CheckApprovalStatus(DbContext, EmployeeCode, EntryDate) = True AndAlso
                    CurrentDayEditStatus <> AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                    Success = False
                    ErrorMessage = "This day has already been approved/pending.  No time will be added to this day."

                Else

                    If CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit OrElse
                        CurrentDayEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then

                        Success = AdvantageFramework.EmployeeTimesheet.SaveDay(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, EmployeeTimeID, EmployeeTimeDetailID,
                                                                               EmployeeCode, EntryDate, FunctionOrCategoryCode, ProductCategory, Hours, JobNumber, JobComponentNumber, DepartmentTeamCode,
                                                                               Me.SecuritySession.UserCode, ErrorMessage, Comment, NewEmployeeTimeID, NewEmployeeTimeDetailID, AlertID, False)

                        If Success = True AndAlso AlertID > 0 Then

                            Webvantage.SignalR.Classes.NotificationHub.RefreshAlertHours(DbContext, AlertID, Me.SecuritySession.UserCode, True)

                        End If

                    Else

                        Success = False
                        ErrorMessage = "Edit status does not allow adding/editing."

                    End If

                End If

            End Using

            Return Success

        End Function
        Private Function GetTimesheet(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal DaysToDisplay As Short,
                                      ByVal NavigationType As AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation,
                                      ByVal IsViewingSingleDay As Boolean,
                                      ByVal Sort As String,
                                      ByVal Group As String,
                                      ByVal ForGrid As Boolean) As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel

            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(EmployeeCode) = True Then EmployeeCode = Me.SecuritySession.User.EmployeeCode

            If Session(UserSettingSessionKey) IsNot Nothing Then

                UserSettings = CType(Session(UserSettingSessionKey), AdvantageFramework.ViewModels.Employee.Timesheet.Settings)

            Else

                UserSettings = LoadAllUserSettings(DbContext)
                Session(UserSettingSessionKey) = UserSettings

            End If

            Try

                If EmployeeCode <> Me.SecuritySession.User.EmployeeCode Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        If Employee.SundayHours IsNot Nothing Then UserSettings.SundayHoursGoal = Employee.SundayHours
                        If Employee.MondayHours IsNot Nothing Then UserSettings.MondayHoursGoal = Employee.MondayHours
                        If Employee.TuesdayHours IsNot Nothing Then UserSettings.TuesdayHoursGoal = Employee.TuesdayHours
                        If Employee.WednesdayHours IsNot Nothing Then UserSettings.WednesdayHoursGoal = Employee.WednesdayHours
                        If Employee.ThursdayHours IsNot Nothing Then UserSettings.ThursdayHoursGoal = Employee.ThursdayHours
                        If Employee.FridayHours IsNot Nothing Then UserSettings.FridayHoursGoal = Employee.FridayHours
                        If Employee.SaturdayHours IsNot Nothing Then UserSettings.SaturdayHoursGoal = Employee.SaturdayHours

                    End If

                End If

            Catch ex As Exception
            End Try

            If DaysToDisplay <= 0 AndAlso UserSettings IsNot Nothing Then DaysToDisplay = UserSettings.DaysToDisplay
            If IsViewingSingleDay = True Then DaysToDisplay = 1

            If IsViewingSingleDay = False Then

                Select Case NavigationType
                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Today

                        If DaysToDisplay = 1 Then

                            StartDate = Today.Date

                        Else

                            StartDate = Today.Date
                            StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, DaysToDisplay)

                        End If

                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Next

                        StartDate = DateAdd(DateInterval.Day, 7, StartDate)
                        StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, DaysToDisplay)

                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Previous

                        StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, DaysToDisplay)
                        StartDate = DateAdd(DateInterval.Day, -7, StartDate)
                        StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, DaysToDisplay)

                    Case Else

                        StartDate = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, DaysToDisplay)

                End Select

            Else

                Dim StartOfWeek As Date = AdvantageFramework.EmployeeTimesheet.FirstDayOfWeek(StartDate, UserSettings, 7)

                Select Case NavigationType
                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Today

                        StartDate = Today.Date

                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Next

                        StartDate = DateAdd(DateInterval.Day, 1, StartDate)

                    Case AdvantageFramework.Controller.Employee.TimesheetMvcController.Navigation.Previous

                        StartDate = DateAdd(DateInterval.Day, -1, StartDate)

                End Select

            End If

            Dim SortBy As AdvantageFramework.Timesheet.TimesheetSort = TimesheetSort.NewestFirst
            Dim GroupBy As AdvantageFramework.Timesheet.TimesheetGroupBy = TimesheetGroupBy.None

            Try

                If String.IsNullOrWhiteSpace(Sort) = False Then

                    Select Case Sort.ToUpper
                        Case "ClientAsc".ToUpper

                            SortBy = TimesheetSort.ClientAsc

                        Case "ClientDesc".ToUpper

                            SortBy = TimesheetSort.ClientDesc

                        Case "JobAsc".ToUpper

                            SortBy = TimesheetSort.JobAsc

                        Case "JobDesc".ToUpper

                            SortBy = TimesheetSort.JobDesc

                    End Select

                End If

            Catch ex As Exception
                SortBy = TimesheetSort.NewestFirst
            End Try
            Try

                If String.IsNullOrWhiteSpace(Group) = False Then

                    Select Case Group.ToUpper
                        Case TimesheetGroupBy.ClientDivision.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.ClientDivision

                        Case TimesheetGroupBy.ClientDivisionJob.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.ClientDivisionJob

                        Case TimesheetGroupBy.ClientDivisionProduct.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.ClientDivisionProduct

                        Case TimesheetGroupBy.ClientDivisionProductJob.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.ClientDivisionProductJob

                        Case TimesheetGroupBy.ClientJob.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.ClientJob

                        Case TimesheetGroupBy.Client.ToString.ToUpper

                            GroupBy = TimesheetGroupBy.Client

                        Case Else

                            GroupBy = TimesheetGroupBy.None

                    End Select

                End If

            Catch ex As Exception
                GroupBy = TimesheetGroupBy.None
            End Try

            If ForGrid = False Then

                Timesheet = _MvcController.GetTimeSheet(DbContext, EmployeeCode, StartDate, DaysToDisplay, SortBy, GroupBy, UserSettings, ErrorMessage)

            Else

                Timesheet = _MvcController.GetTimeSheetGrid(DbContext, EmployeeCode, StartDate, DaysToDisplay, SortBy, GroupBy, UserSettings, ErrorMessage)

            End If

            If Timesheet Is Nothing Then Timesheet = New AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel

            Timesheet.UserSettings = UserSettings

            Timesheet.IsApprovalActive = _IsApprovalActive(EmployeeCode)
            Timesheet.RequireHoursBeforeSubmit = _RequiredHoursBeforeApproval()
            Timesheet.RequireHoursBeforeSubmitType = _RequiredHoursBeforeApprovalType()

            Return Timesheet

        End Function
        Private Function GetTimeEntryCommentObject() As AdvantageFramework.Database.Entities.EmployeeTimeComment

            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim IsDirectTime As Boolean = True
            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Short = 0

            If Me.CurrentQueryString.EmployeeTimeID > 0 Then EmployeeTimeID = Me.CurrentQueryString.EmployeeTimeID
            If Me.CurrentQueryString.EmployeeTimeDetailID > 0 Then EmployeeTimeDetailID = Me.CurrentQueryString.EmployeeTimeDetailID
            If Me.CurrentQueryString.TimeType = "N" Then IsDirectTime = False

            If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    EmployeeTimeComment = _MvcController.GetTimeEntryComment(DbContext, IsDirectTime, EmployeeTimeID, EmployeeTimeDetailID)

                End Using

            End If

            If EmployeeTimeComment Is Nothing Then EmployeeTimeComment = New AdvantageFramework.Database.Entities.EmployeeTimeComment

            Return EmployeeTimeComment

        End Function
        Private Function LoadTimesheetAgencySettings() As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings

            Dim AgencySettings As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings = Nothing

            'If Session(AgencyTimesheetOptionsSessionKey) Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                AgencySettings = _MvcController.GetAgencySettings(DbContext)

                'If AgencySettings IsNot Nothing Then

                '    Session(AgencyTimesheetOptionsSessionKey) = AgencySettings

                'End If

            End Using

            'Else

            '    AgencySettings = CType(Session(AgencyTimesheetOptionsSessionKey), AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings)

            'End If

            If AgencySettings Is Nothing Then AgencySettings = New AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings

            Return AgencySettings

        End Function
        Private Function AssignmentRequired() As Boolean

            Dim AssignmentIsRequired As Boolean = False

            Try

                If Session(AgencyAssignmentRequiredSessionKey) Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Try

                            AssignmentIsRequired = AdvantageFramework.EmployeeTimesheet.CheckIfAssignmentIsRequired(DbContext)

                        Catch ex As Exception
                            AssignmentIsRequired = False
                        End Try

                        Session(AgencyAssignmentRequiredSessionKey) = AssignmentIsRequired

                    End Using

                Else

                    AssignmentIsRequired = CType(Session(AgencyAssignmentRequiredSessionKey), Boolean)

                End If

            Catch ex As Exception
                AssignmentIsRequired = False
            End Try

            Return AssignmentIsRequired

        End Function

#End Region

#End Region

#Region " Classes "
        <Serializable> Public Class SelectRowForCopy
            Public Property EmployeeTimeID As Integer
            Public Property EmployeeTimeDetailID As Integer
            Public Property TimeType As String
            Public Property EntryDate As Date
            Public Property Hours As Decimal
            Public Property Comment As String
            Sub New()

            End Sub

        End Class
        <Serializable()>
        Public Class UserColors
            Public Property Primary As String = String.Empty
            Public Property AltPrimary As String = String.Empty
            Sub New()

            End Sub

        End Class
        <Serializable()> Public Class DeleteInfo

            Public Property EmployeeTimeID As Integer? = 0
            Public Property EmployeeTimeDetailID As Integer? = 0
            Public Property TimeType As String = String.Empty

            Sub New()

            End Sub

        End Class
        <Serializable()>
        Public Class EntryInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property EmployeeCode As String = String.Empty
            Public Property FunctionCategoryCode As String = String.Empty
            Public Property DepartmentTeamCode As String = String.Empty
            Public Property JobNumber As Integer? = 0
            Public Property JobComponentNumber As Short? = 0
            Public Property EmployeeTimeID As Integer? = 0
            Public Property EmployeeTimeDetailID As Integer? = 0
            Public Property EditFlag As Short? = 0
            Public Property TimeType As String = String.Empty
            Public Property EntryDate As Date? = Nothing
            Public Property CommentsRequired As Boolean? = False
            Public Property HasComments As Boolean? = False
            Public Property Hours As Decimal? = 0
            Public Property AlertID As Integer? = 0
            Public Property Comment As String = String.Empty

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region


        End Class
        <Serializable()>
        Public Class TimesheetEmployee

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property EmployeeCode
            Public Property FullName

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region
        End Class

#End Region
        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Employee.TimesheetController(Me.SecuritySession)
            _MvcController = New AdvantageFramework.Controller.Employee.TimesheetMvcController(Me.SecuritySession)

        End Sub

    End Class

End Namespace

