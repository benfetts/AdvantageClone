Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing

Namespace Controllers.Dashboard

    Public Class DashboardController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Dashboard.DashboardController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Initialize "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Dashboard.DashboardController(Me.SecuritySession)

        End Sub

#End Region

#Region " Views "

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Dashboard_Main")>
        Public Function Main() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/dashboard/dashboard"

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " Methods "

        <HttpGet>
        Public Function InitDashboard() As JsonResult

            'objects
            Dim Dashboard As AdvantageFramework.DTO.Desktop.Dashboard = Nothing
            _Controller._IsClientPortal = MiscFN.IsClientPortal

            Dashboard = _Controller.LoadDashboard()

            If Dashboard Is Nothing Then Dashboard = New AdvantageFramework.DTO.Desktop.Dashboard

            Return Json(Dashboard, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function InitBookmarkEdit(ByVal BookmarkID As Integer) As JsonResult

            'objects
            Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Bookmark = BmMethods.GetBookmarkByID(BookmarkID)

            Return Json(Bookmark, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function ShowProofingIcon() As JsonResult

            Dim ClientPortal As Boolean = IsClientPortalActive()
            Dim Timesheet As Boolean = HasAccessToTimesheet(SecuritySession)
            Dim Proofing As Boolean = IsProofingToolActive(SecuritySession)
            Dim ConceptShare As Boolean = IsConceptShareToolActive(SecuritySession)
            Dim ProofingDashboardIcon As Boolean = False

            If Proofing = True OrElse ConceptShare = True Then

                ProofingDashboardIcon = True

            End If
            If ClientPortal = True Then

                ProofingDashboardIcon = False

            End If

            Return Json(New With {.ProofingActive = Proofing,
                                  .TimesheetActive = Timesheet,
                                  .ConceptShareActive = ConceptShare,
                                  .ClientPortalActive = ClientPortal,
                                  .ShowIcon = ProofingDashboardIcon}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsProofingActive() As JsonResult

            Return Json(IsProofingToolActive(Me.SecuritySession), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsConceptShareActive() As JsonResult

            Return Json(IsConceptShareToolActive(Me.SecuritySession), JsonRequestBehavior.AllowGet)

        End Function
        '<HttpGet>
        <HttpGet>
        Public Function HasAccessToTimesheet() As JsonResult

            Dim HasAccess As Boolean = False

            HasAccess = Me.HasAccessToTimesheet(Me.SecuritySession)

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function isClientPortal() As JsonResult

            Return Json(IsClientPortalActive(), JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function GetHoursCount() As JsonResult

            Dim ReturnObject As Object = Nothing

            Dim LegacyDesktopObjects As New cDesktopObjects(SecuritySession.ConnectionString)
            Dim LegacyTimesheetClass As Webvantage.wvTimeSheet.cTimeSheet = New Webvantage.wvTimeSheet.cTimeSheet(SecuritySession.ConnectionString)
            Dim ThisWeek As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DailyHours) = Nothing


            Dim HoursToday As Double = 0.0
            Dim HoursThisWeek As Double = 0.0
            Dim HasMissingTime As Boolean = False
            Dim HasDeniedTime As Boolean = False
            Dim TimeMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ThisWeek = AdvantageFramework.EmployeeTimesheet.GetThisWeekHours(DbContext, CurrentEmployeeCode)

                If ThisWeek IsNot Nothing Then

                    For Each Day As AdvantageFramework.EmployeeTimesheet.Classes.DailyHours In ThisWeek

                        HoursThisWeek += Day.Hours

                        If Day.DayDisplay.ToShortDateString = cEmployee.TimeZoneToday.ToShortDateString Then

                            HoursToday = Day.Hours

                        End If

                    Next

                End If

            End Using

            Try

                LegacyTimesheetClass.LoadMissingDeniedTimeMessage(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, HasMissingTime, HasDeniedTime, TimeMessage)

            Catch ex As Exception
                HasMissingTime = False
                HasDeniedTime = False
                TimeMessage = String.Empty
            End Try

            HoursToday = FormatNumber(HoursToday, 2)
            HoursThisWeek = FormatNumber(HoursThisWeek, 2)

            ReturnObject = New With {.HoursToday = HoursToday,
                                     .HoursThisWeek = HoursThisWeek,
                                     .HasMissingTime = HasMissingTime,
                                     .HasDeniedTime = HasDeniedTime,
                                     .TimeMessage = TimeMessage}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function SwitchDashboard(ByVal DashboardType As Integer) As JsonResult

            Dim Dashboard As AdvantageFramework.DTO.Desktop.Dashboard = Nothing

            Try

                Dashboard = _Controller.LoadDashboard(DashboardType)

            Catch ex As Exception
                Dashboard = Nothing
            End Try

            If Dashboard Is Nothing Then Dashboard = New AdvantageFramework.DTO.Desktop.Dashboard

            Return Json(Dashboard, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function GetCards(ByVal DashboardType As Integer, ByVal GroupBy As String, ByVal Search As String,
                                 ByVal PageSize As Integer, ByVal PageNumber As Integer) As JsonResult

            Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
            Dim Cards As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.Card) = Nothing
            Dim ReturnCardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
            Dim ReturnCardGroup As AdvantageFramework.DTO.Desktop.Dashboard.CardGroup = Nothing
            Dim ReturnObject As Object = Nothing
            Dim AlertCount As Integer = 0
            Dim AssignmentCount As Integer = 0
            Dim ReviewCount As Integer = 0

            CardGroups = _Controller.GetDashboardCardGroups(DashboardType,
                                                            GroupBy,
                                                            Search,
                                                            IsProofingToolActive(Me.SecuritySession),
                                                            IsConceptShareToolActive(Me.SecuritySession),
                                                            MiscFN.IsClientPortal,
                                                            PageSize,
                                                            PageNumber,
                                                            AssignmentCount,
                                                            AlertCount,
                                                            ReviewCount)

            Cards = New Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.Card)

            ReturnCardGroups = New Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

            For Each CardGroup In CardGroups

                If CardGroup.Cards IsNot Nothing AndAlso CardGroup.Cards.Count > 0 Then

                    Cards.AddRange(CardGroup.Cards.ToList)

                    ReturnCardGroup = New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup

                    ReturnCardGroup.Key = CardGroup.Key
                    ReturnCardGroup.Cards = CardGroup.Cards

                    ReturnCardGroups.Add(ReturnCardGroup)

                End If

            Next

            ReturnObject = New With {.cardGroups = ReturnCardGroups,
                                     .alertCount = AlertCount,
                                     .assignmentCount = AssignmentCount,
                                     .reviewCount = ReviewCount}

            Return Json(ReturnObject, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function SaveDashboardDefaultGroupBy(ByVal DashboardType As Integer, ByVal GroupBy As String) As JsonResult

            'objects
            Dim Saved As Boolean = False

            Saved = _Controller.SaveDashboardDefaultGroupBy(DashboardType, GroupBy)

            Return Json(Saved, JsonRequestBehavior.DenyGet)

        End Function
        <HttpGet>
        Public Function DashboardsCardSettingsMaintenance(ByVal DashboardType As Integer) As JsonResult

            Dim Settings As DesktopCardSettings = New DesktopCardSettings

            If DashboardType = 0 Then
                Dim AlertAppVars As New cAppVars(cAppVars.Application.ALERT_CARDS)
                AlertAppVars.getAllAppVars()

                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(AlertAppVars.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

            End If

            If DashboardType = 1 Then
                Dim AlertAppVars As New cAppVars(cAppVars.Application.ASSIGNMENT_CARDS)
                AlertAppVars.getAllAppVars()

                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(AlertAppVars.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

            End If

            If DashboardType = 3 Then
                Dim AlertAppVars As New cAppVars(cAppVars.Application.REVIEW_CARDS)
                AlertAppVars.getAllAppVars()

                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(AlertAppVars.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

            End If

            Return Json(Settings, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTaskDashboardsCardSettings(ByVal DashboardType As Integer, ByVal Settingtype As String) As JsonResult

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim setting As String = ""

            If Settingtype = "TaskStatus" Then
                setting = otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")
                If setting = "" Then
                    setting = "A"
                End If
            End If

            If Settingtype = "StartToday" Then
                setting = otask.getAppVars(Session("UserCode"), "MyTasks", "StartToday")
            End If

            If Settingtype = "OnlyTasksWithDates" Then
                setting = otask.getAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue")
            End If

            Return Json(setting, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function SaveDashboardCardSettings(ByVal DashboardType As Integer, ByVal CardSetting As String, ByVal value As String) As JsonResult

            'objects
            Dim Saved As Boolean = False
            Dim Settings As DesktopCardSettings

            If DashboardType = 1 Then

                Dim av As New cAppVars(cAppVars.Application.ASSIGNMENT_CARDS)
                av.getAllAppVars()
                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

                If Settings Is Nothing Then Settings = New DesktopCardSettings

                If CardSetting = "ShowClientNameAssignment" Then
                    Settings.ShowClientName = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobNumberAssignment" Then
                    Settings.ShowJobNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentNumberAssignment" Then
                    Settings.ShowJobComponentNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobDescriptionAssignment" Then
                    Settings.ShowJobDescription = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentDescriptionAssignment" Then
                    Settings.ShowJobComponentDescription = If(value = "True", True, False)
                End If
                If CardSetting = "ShowTaskCommentAssignment" Then
                    Settings.ShowTaskComment = If(value = "True", True, False)
                End If
                If CardSetting = "ShowStateAssignment" Then
                    Settings.ShowState = If(value = "True", True, False)
                End If

                av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
                av.SaveAllAppVars()

                Dim otask As cTasks = New cTasks(Session("ConnString"))

                If CardSetting = "TaskStatus" Then
                    otask.setAppVars(Session("UserCode"), "MyTasks", "ddType", "", value)
                End If

                If CardSetting = "StartToday" Then
                    otask.setAppVars(Session("UserCode"), "MyTasks", "StartToday", "", If(value = "True", True, False))
                End If

                If CardSetting = "TasksOnlyWithStartAndDueDates" Then
                    otask.setAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue", "", If(value = "True", True, False))
                End If


            ElseIf DashboardType = 0 Then

                Dim av As New cAppVars(cAppVars.Application.ALERT_CARDS)
                av.getAllAppVars()
                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

                If Settings Is Nothing Then Settings = New DesktopCardSettings

                If CardSetting = "ShowClientNameAlert" Then
                    Settings.ShowClientName = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobNumberAlert" Then
                    Settings.ShowJobNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentNumberAlert" Then
                    Settings.ShowJobComponentNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobDescriptionAlert" Then
                    Settings.ShowJobDescription = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentDescriptionAlert" Then
                    Settings.ShowJobComponentDescription = If(value = "True", True, False)
                End If
                If CardSetting = "ShowTaskCommentAlert" Then
                    Settings.ShowTaskComment = If(value = "True", True, False)
                End If
                If CardSetting = "ShowStateAlert" Then
                    Settings.ShowState = If(value = "True", True, False)
                End If

                av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
                av.SaveAllAppVars()

            ElseIf DashboardType = 3 Then

                Dim av As New cAppVars(cAppVars.Application.REVIEW_CARDS)
                av.getAllAppVars()
                Try

                    Settings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DesktopCardSettings)(av.getAppVar("settings", "String", ""))

                Catch ex As Exception
                    Settings = Nothing
                End Try

                If Settings Is Nothing Then Settings = New DesktopCardSettings

                If CardSetting = "ShowClientNameReview" Then
                    Settings.ShowClientName = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobNumberReview" Then
                    Settings.ShowJobNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentNumberReview" Then
                    Settings.ShowJobComponentNumber = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobDescriptionReview" Then
                    Settings.ShowJobDescription = If(value = "True", True, False)
                End If
                If CardSetting = "ShowJobComponentDescriptionReview" Then
                    Settings.ShowJobComponentDescription = If(value = "True", True, False)
                End If

                av.setAppVar("settings", Newtonsoft.Json.JsonConvert.SerializeObject(Settings), "String")
                av.SaveAllAppVars()

            End If

            Return Json(Saved, JsonRequestBehavior.DenyGet)

        End Function

        <HttpPost>
        Public Function UpdateBookmark(ByVal BookmarkID As Integer, ByVal Name As String, ByVal Description As String) As JsonResult

            'objects
            Dim Saved As Boolean = False

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Saved = BmMethods.UpdateBookmarkNameAndDescription(BookmarkID, Name, Description)

            Return Json(Saved, JsonRequestBehavior.DenyGet)

        End Function

        <HttpPost>
        Public Function UpdateCardsOrder(ByVal AlertId As Integer, ByVal NewPosition As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal TaskSequenceNumber As Integer) As JsonResult

            Dim Saved As Boolean = False

            Saved = _Controller.SortAssignmentTaskCards(AlertId, NewPosition, JobNumber, JobComponentNumber, TaskSequenceNumber)

            Return Json(Saved, JsonRequestBehavior.DenyGet)

        End Function

        <HttpPost>
        Public Function UpdateCardsOrderAlerts(ByVal AlertId As Integer, ByVal NewPosition As Integer) As JsonResult

            Dim Saved As Boolean = False

            Saved = _Controller.SortAlertCards(AlertId, NewPosition)

            Return Json(Saved, JsonRequestBehavior.DenyGet)

        End Function

        <HttpPost>
        Public Function BookMarkPage(ByVal Dashboard As String) As JsonResult

            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            With b

                If Dashboard = "executive" Then
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_ExecutiveDashboard
                    .UserCode = Session("UserCode")
                    .Name = "Executive Dashboard"
                    .PageURL = "ExecutiveDashboard"
                End If
                If Dashboard = "acctcash" Then
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_AccountingCashDashboard
                    .UserCode = Session("UserCode")
                    .Name = "Accounting-Cash Dashboard"
                    .PageURL = "AcctFinanceCashDashboard"
                End If
                If Dashboard = "acct" Then
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_AccountingDashboard
                    .UserCode = Session("UserCode")
                    .Name = "Accounting Dashboard"
                    .PageURL = "AcctFinanceDashboard"
                End If

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <HttpPost>
        Public Function UpdateCardPriority(ByVal AlertID As Integer, ByVal Priority As Integer) As JsonResult

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Updated As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    Alert.PriorityLevel = Priority

                    Updated = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                End If

            End Using

            Return Json(Updated)

        End Function

        <HttpGet>
        Public Function CanAddJobJacket() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False
            Dim SecuritySession As AdvantageFramework.Security.Session = Nothing

            If Me.SecuritySession Is Nothing Then

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))

            Else

                SecuritySession = Me.SecuritySession

            End If

            If MiscFN.IsClientPortal = False Then

                Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_JobJacket.ToString("F"),
                                                                                                                     SecuritySession.User.ID)

                    If UserPermission IsNot Nothing Then
                        HasAccess = UserPermission.CanAdd
                    End If



                End Using

            End If

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function HasAccessJobJacket() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False
            Dim SecuritySession As AdvantageFramework.Security.Session = Nothing

            If Me.SecuritySession Is Nothing Then

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))

            Else

                SecuritySession = Me.SecuritySession

            End If

            If MiscFN.IsClientPortal = False Then

                Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_JobJacket.ToString("F"),
                                                                                                                     SecuritySession.User.ID)
                    If UserPermission IsNot Nothing Then
                        HasAccess = If(UserPermission.IsBlocked = False, True, False)
                    End If

                End Using

            End If

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " FOR DEMO ONLY "

        Public Function GetSampleChartData() As JsonResult

            'objects
            Dim Data As Object = Nothing

            Data = New With {
                .ProjectsDueByClient = ProjectsDueByClient(),
                .ProjectsPendingByClient = ProjectsPendingByClient(),
                .JobStatisticByOffice = JobStatisticByOffice()
            }

            Return Json(Data, JsonRequestBehavior.AllowGet)

        End Function
        Private Function ProjectsDueByClient() As IEnumerable

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As System.Data.DataSet = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Data As IEnumerable = Nothing

            DataSet = dash.GetProjectsByLevel("", "1", "2018", "01-06-2018", "", "", "", "", "", "", 0, 1, "C", "", False, Session("UserCode"), "YeartoDate", "Due", 2)

            DataTable = DataSet.Tables(0)

            Data = DataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(dr) New With {.ClientCode = dr("CL_CODE"), .ClientName = dr("CL_NAME"), .Value = dr("Due")}).ToList

            Return Data

        End Function
        Private Function ProjectsPendingByClient() As IEnumerable

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim DataSet As System.Data.DataSet = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Data As IEnumerable = Nothing

            DataSet = dash.GetProjectsByLevel("", "1", "2018", "01-06-2018", "", "", "", "", "", "", 0, 1, "C", "", False, Session("UserCode"), "YeartoDate", "Pending", 2)

            DataTable = DataSet.Tables(0)

            Data = DataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(dr) New With {.ClientCode = dr("CL_CODE"), .ClientName = dr("CL_NAME"), .Value = dr("Pending")}).ToList

            Return Data

        End Function
        Private Function JobStatisticByOffice() As IEnumerable

            Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Data As IEnumerable = Nothing

            DataTable = oDTO.GetOfficeStatistics(Session("UserCode"), "1/1/2016", "12/31/2018", "none", True, "All", "All")

            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow).ToList

                If DataRow("OFFICE_CODE").ToString <> "ALL_OFFICES" Then

                    DataRow("OFFICE_DESCRIPT") = DataRow("OFFICE_DESCRIPT").ToString().Split("-")(1).Trim

                End If

            Next

            Data = DataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(dr) New With {.OfficeCode = dr("OFFICE_CODE"), .OfficeName = dr("OFFICE_DESCRIPT"), .Created = CShort(dr("JOBS_CREATED")), .Completed = CShort(dr("JOBS_COMPLETED")), .Due = CShort(dr("JOBS_DUE")), .InProgress = CShort(dr("JOBS_IN_PROGRESS")), .Cancelled = CShort(dr("JOBS_CANCELLED"))}).ToList

            Return Data

        End Function

#End Region

#Region " Private "

        Private Function HasAccessToTimesheet(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

            Dim HasAccess As Boolean = False

            If Session(AdvantageFramework.Proofing.TimesheetSessionKey) Is Nothing Then

                Try

                    If MiscFN.IsClientPortal = False Then

                        HasAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecuritySession,
                                                                                           AdvantageFramework.Security.Modules.Employee_Timesheet.ToString,
                                                                                           SecuritySession.User)

                    End If

                Catch ex As Exception
                    HasAccess = False
                End Try

                Session(AdvantageFramework.Proofing.TimesheetSessionKey) = HasAccess

            Else

                HasAccess = CType(Session(AdvantageFramework.Proofing.TimesheetSessionKey), Boolean)

            End If

            Return HasAccess

        End Function

#End Region

    End Class

End Namespace
