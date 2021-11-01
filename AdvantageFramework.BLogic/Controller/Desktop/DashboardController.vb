
Namespace Controller.Dashboard

    Public Class DashboardController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Public Const DashBoardAppVarKey = "NEWAPP_DASH"

#End Region

#Region " Enum "

        Public Enum DashboardType

            Alerts = 0
            Assignments = 1
            Tasks = 2
            Reviews = 3
            Appointments = 4
            Bookmarks = 5
            Time = 6

        End Enum

        Public Enum GroupByOption

            dflt

        End Enum

        Public Enum DashboardAppVars

            settings
            dflt_wkspc_sort
            dflt_wkspc_sort_tasks
            last_dash_type

        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property _IsClientPortal As Boolean

#End Region

#Region " Methods "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function LoadDashboard() As Object

            'objects
            Dim Dashboard As AdvantageFramework.DTO.Desktop.Dashboard = Nothing

            Dashboard = LoadDashboard(GetLastDashboardTypeForUser())

            Return Dashboard

        End Function
        Public Function LoadDashboard(ByVal DashboardType As DashboardType) As Object

            'objects
            Dim Dashboard As AdvantageFramework.DTO.Desktop.Dashboard = Nothing

            Try

                Dashboard = New AdvantageFramework.DTO.Desktop.Dashboard(DashboardType)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    LoadDashboard(DbContext, Dashboard)

                End Using

            Catch ex As Exception
                Dashboard = Nothing
            End Try

            If Dashboard Is Nothing Then Dashboard = New DTO.Desktop.Dashboard

            Return Dashboard

        End Function
        Public Function GetDashboardCardGroups(ByVal DashboardType As DashboardType, ByVal GroupBy As String,
                                               ByVal Search As String,
                                               ByVal IsProofingToolActive As Boolean,
                                               ByVal IsConceptShareActive As Boolean,
                                               ByVal IsClientPortal As Boolean,
                                               ByVal PageSize As Integer,
                                               ByVal PageNumber As Integer,
                                               ByRef AssignmentsCount As Integer,
                                               ByRef AlertsCount As Integer,
                                               ByRef ReviewsCount As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

            Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing

            Try

                CardGroups = LoadDashboardCardGroups(DashboardType,
                                                     GroupBy,
                                                     Search,
                                                     IsProofingToolActive,
                                                     IsConceptShareActive,
                                                     IsClientPortal,
                                                     PageSize,
                                                     PageNumber,
                                                     AssignmentsCount,
                                                     AlertsCount,
                                                     ReviewsCount)

            Catch ex As Exception
                CardGroups = Nothing
            End Try

            If CardGroups Is Nothing Then CardGroups = New List(Of DTO.Desktop.Dashboard.CardGroup)

            Return CardGroups

        End Function
        Public Function GetDashboardItemCount(ByVal Type As DashboardType, Optional ByVal IsClientPortal As Boolean = False) As Integer

            Try

                Return Me.LoadDashboardItemCount(Type, IsClientPortal)

            Catch ex As Exception
                Return 0
            End Try

        End Function
        Public Function SaveDashboardDefaultGroupBy(ByVal DashboardType As DashboardType, ByVal GroupBy As String) As Boolean

            'objects
            Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim AppVar As Database.Entities.AppVars = Nothing
            Dim VariableName As String = DashboardController.DashboardAppVars.dflt_wkspc_sort.ToString
            Dim Saved As Boolean = False

            Dim app As String = String.Empty

            Select Case DashboardType
                Case DashboardType.Alerts

                    app = "ALERT_CARDS"

                Case DashboardType.Assignments

                    app = "ASSIGNMENT_CARDS"

                Case DashboardType.Reviews

                    app = "REVIEW_CARDS"

            End Select

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, app).ToList

                'If Dashboard.DashboardType = DashboardType.Tasks Then

                '    VariableName = DashboardController.DashboardAppVars.dflt_wkspc_sort_tasks.ToString

                'End If

                If AppVars.Where(Function(av) av.Name = VariableName).Any Then

                    AppVar = AppVars.Where(Function(av) av.Name = VariableName).SingleOrDefault

                    AppVar.Value = GroupBy

                    Saved = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                Else

                    AppVar = New Database.Entities.AppVars

                    AppVar.UserCode = Session.UserCode
                    AppVar.Application = app
                    AppVar.Group = 0
                    AppVar.Name = VariableName
                    AppVar.Type = "String"
                    AppVar.Value = GroupBy

                    Saved = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                End If

            End Using

            SaveDashboardDefaultGroupBy = Saved

        End Function
        Public Function GetDashboardCardMaintenanceOptions(ByVal IsClientPortal As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard)

            'objects
            Dim Dashboards As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard) = Nothing
            Dim Dashboard As AdvantageFramework.DTO.Desktop.Dashboard = Nothing
            Dim ConceptShareAccountUser As AdvantageFramework.ConceptShareAPI.AccountUser = Nothing
            Dim ConceptShareUser As AdvantageFramework.ConceptShareAPI.User = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IsReviewsActive As Boolean = False
            Dim ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser

            Dashboards = New Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboards.Add(New DTO.Desktop.Dashboard(DashboardType.Assignments))
                Dashboards.Add(New DTO.Desktop.Dashboard(DashboardType.Alerts))
                Dashboards.Add(New DTO.Desktop.Dashboard(DashboardType.Tasks))

                If DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'CS_ENABLED';").FirstOrDefault Then

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If Not IsClientPortal Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                                If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID IsNot Nothing AndAlso Employee.ConceptShareUserID > 0 Then

                                    ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, Employee, ConceptShareUser)

                                    If ConceptShareAccountUser IsNot Nothing AndAlso ConceptShareAccountUser.IsActive = True Then

                                        IsReviewsActive = True

                                    End If

                                End If

                            Else

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    ClientPortalUser = New AdvantageFramework.Security.Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(SecurityDbContext, Session.UserCode))

                                    If ClientPortalUser IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID > 0 Then

                                        ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, SecurityDbContext, ClientPortalUser, ConceptShareUser)

                                        If ConceptShareAccountUser IsNot Nothing AndAlso ConceptShareAccountUser.IsActive = True Then

                                            IsReviewsActive = True

                                        End If

                                    End If

                                End Using

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                End If

                If IsReviewsActive Then

                    Dashboards.Add(New DTO.Desktop.Dashboard(DashboardType.Reviews))

                End If

                For Each Dashboard In Dashboards

                    LoadDashboardAppVars(DbContext, Dashboard)

                Next

            End Using

            Return Dashboards

        End Function

#Region "  Private "

        Private Function SetLastDashboardTypeForUser(ByVal Type As DashboardType) As Boolean

            Dim Success As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

                Try

                    AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                                 Me.Session.UserCode,
                                                                                                                 DashboardController.DashBoardAppVarKey,
                                                                                                                 DashboardController.DashboardAppVars.last_dash_type.ToString)

                Catch ex As Exception
                    AppVar = Nothing
                End Try

                If AppVar IsNot Nothing Then

                    AppVar.Value = CType(Type, Integer).ToString

                    Success = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                Else

                    AppVar.UserCode = Me.Session.UserCode
                    AppVar.Application = DashboardController.DashBoardAppVarKey
                    AppVar.Name = DashboardController.DashboardAppVars.last_dash_type.ToString
                    AppVar.Type = "Integer"

                End If

            End Using

            Return Success

        End Function
        Private Function GetLastDashboardTypeForUser() As DashboardType

            Dim Type As DashboardType = DashboardType.Assignments

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

                    Try

                        AppVar = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext,
                                                                                                                 Me.Session.UserCode,
                                                                                                                 DashboardController.DashBoardAppVarKey,
                                                                                                                 DashboardController.DashboardAppVars.last_dash_type.ToString)

                    Catch ex As Exception
                        AppVar = Nothing
                    End Try

                    If AppVar IsNot Nothing AndAlso IsNumeric(AppVar.Value) Then

                        Type = CType(CType(AppVar.Value, Integer), DashboardType)

                    Else

                        Type = DashboardType.Assignments

                    End If

                    'If _IsClientPortal = True Then

                    '    Type = DashboardType.Alerts

                    'End If

                End Using

            Catch ex As Exception
                Type = DashboardType.Assignments
            End Try

            Return Type

        End Function
        Private Sub LoadDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)

            Try

                LoadDashboardAppVars(DbContext, Dashboard)
                Dashboard.GroupByOptions = GetGroupByOptions(Dashboard.DashboardType)

                Select Case Dashboard.DashboardType

                    Case DashboardType.Alerts

                        LoadAlertsDashboard(DbContext, Dashboard)

                    Case DashboardType.Assignments

                        LoadAssignmentsDashboard(Dashboard)

                    Case DashboardType.Reviews

                        LoadReviewsDashboard(Dashboard)

                    Case DashboardType.Tasks

                        LoadTasksDashboard(Dashboard)

                End Select

            Catch ex As Exception
            End Try

        End Sub
        Private Function LoadAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard) As Generic.List(Of AdvantageFramework.Database.Entities.AppVars)

            'objects
            Dim ApplicationName As String = Nothing

            ApplicationName = GetAppVarApplicationName(Dashboard)

            If Not String.IsNullOrWhiteSpace(ApplicationName) Then

                Return AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, ApplicationName).ToList

            Else

                Return Nothing

            End If

        End Function
        Private Function GetAppVarApplicationName(ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard) As String

            'objects
            Dim ApplicationName As String = Nothing

            Select Case Dashboard.DashboardType

                Case DashboardType.Alerts

                    ApplicationName = "ALERT_CARDS"

                Case DashboardType.Assignments

                    ApplicationName = "ASSIGNMENT_CARDS"

                Case DashboardType.Reviews

                    ApplicationName = "REVIEW_CARDS"

                Case DashboardType.Tasks

                    ApplicationName = "TASK_CARDS"

            End Select

            Return ApplicationName

        End Function
        Private Sub LoadDashboardAppVars(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)

            'objects
            Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim CardSettings As AdvantageFramework.DTO.Desktop.Dashboard.CardSettings = Nothing
            Dim GroupBy As String = ""

            AppVars = LoadAppVars(DbContext, Dashboard)

            If AppVars IsNot Nothing Then

                If AppVars.Where(Function(av) av.Name = DashboardAppVars.settings.ToString).Any Then

                    Try

                        If Dashboard.DashboardType = DashboardType.Reviews Then

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.ReviewCardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        ElseIf Dashboard.DashboardType = DashboardType.Tasks Then

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.TaskCardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        Else

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.CardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        End If

                    Catch ex As Exception
                        CardSettings = Nothing
                    End Try

                End If
                If AppVars.Where(Function(av) av.Name = DashboardAppVars.dflt_wkspc_sort.ToString).Any Then

                    GroupBy = AppVars.Where(Function(av) av.Name = DashboardAppVars.dflt_wkspc_sort.ToString).First.Value

                End If
                If Dashboard.DashboardType = DashboardType.Tasks Then

                    If AppVars.Where(Function(av) av.Name = DashboardAppVars.dflt_wkspc_sort_tasks.ToString).Any Then

                        GroupBy = AppVars.Where(Function(av) av.Name = DashboardAppVars.dflt_wkspc_sort_tasks.ToString).First.Value

                    End If

                End If

            End If
            If CardSettings Is Nothing Then

                If Dashboard.DashboardType = DashboardType.Reviews Then

                    CardSettings = New AdvantageFramework.DTO.Desktop.Dashboard.ReviewCardSettings

                ElseIf Dashboard.DashboardType = DashboardType.Tasks Then

                    CardSettings = New AdvantageFramework.DTO.Desktop.Dashboard.TaskCardSettings

                Else

                    CardSettings = New AdvantageFramework.DTO.Desktop.Dashboard.CardSettings

                End If

            End If
            If String.IsNullOrWhiteSpace(GroupBy) Then

                GroupBy = ""

            End If

            Dashboard.GroupBy = GroupBy
            Dashboard.Settings = CardSettings

        End Sub
        Private Function GetGroupByOptions(ByVal DashboardType As DashboardType) As Object

            'objects
            Dim GroupByOptions As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption) = Nothing

            GroupByOptions = New List(Of DTO.Desktop.Dashboard.GroupByOption)

            GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("", "Custom"))

            Select Case DashboardType

                Case DashboardType.Alerts

                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("NEW_UNREAD", "Read Status"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CAT", "Category"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("PRIORITY", "Priority"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE", "Due Date (Desc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE_ASC", "Due Date (Asc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("LAST_UPD", "Last Updated"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("C", "Client"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CD", "Division"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDP", "Product"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJ", "Job"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJC", "Job/Component"))

                Case DashboardType.Assignments

                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("NEW_UNREAD", "Read Status"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CAT", "Category"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("PRIORITY", "Priority"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE", "Due Date (Desc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE_ASC", "Due Date (Asc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("VER_BLD", "Version/Build"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("STATE", "State"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("LAST_UPD", "Last Updated"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("C", "Client"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CD", "Division"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDP", "Product"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJ", "Job"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJC", "Job/Component"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("TS", "Task Status"))

                Case DashboardType.Tasks

                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("PRIORITY", "Priority"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE", "Due Date (Desc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE_ASC", "Due Date (Asc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("START_DATE", "Start Date"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("TASK_STATUS", "Task Status"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("PERCENT_COMPLETE", "Gut % Complete"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("STARTED", "Started"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CLIENT", "Client"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJ", "Job"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJC", "Job/Component"))

                Case Else

                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("NEW_UNREAD", "Read Status"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CAT", "Category"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("PRIORITY", "Priority"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE", "Due Date (Desc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("DUE_DATE_ASC", "Due Date (Asc)"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("VER_BLD", "Version/Build"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("STATE", "State"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("LAST_UPD", "Last Updated"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("C", "Client"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CD", "Division"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDP", "Product"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJ", "Job"))
                    GroupByOptions.Add(New AdvantageFramework.DTO.Desktop.Dashboard.GroupByOption("CDPJC", "Job/Component"))

            End Select

            Return GroupByOptions

        End Function

#End Region

#End Region

#Region "   Alerts Dashboard "

        Private Sub LoadAlertsDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)



        End Sub

        Public Function SortAlertCards(ByVal AlertId As Integer, ByVal NewPosition As Integer) As String

            Dim UserCode As String = Me.Session.UserCode
            Dim EmployeeCode As String = Me.Session.User.EmployeeCode
            Dim ConnectionString As String = Me.Session.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_alerts] '{0}', {1}, {2};",
                                                     EmployeeCode, AlertId, NewPosition))

                End Using

                Return ""

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function

#End Region
#Region "   Assignments Dashboard "

        Private Sub LoadAssignmentsDashboard(ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)



        End Sub

        Public Function SortAssignmentTaskCards(ByVal AlertId As Integer, ByVal NewPosition As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal TaskSequenceNumber As Integer) As Boolean

            Dim UserCode As String = Me.Session.UserCode
            Dim EmployeeCode As String = Me.Session.User.EmployeeCode
            Dim ConnectionString As String = Me.Session.ConnectionString

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_assignments] '{0}', '{1}', {2}, {3}, {4}, {5}, {6};",
                                                     UserCode, EmployeeCode, AlertId, JobNumber, JobComponentNumber, TaskSequenceNumber, NewPosition))

                End Using

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function

        Public Function GetAppointmentCount(ByVal IsClientPortal As Boolean) As String

            Dim UserCode As String = Me.Session.UserCode
            Dim EmployeeCode As String = Me.Session.User.EmployeeCode
            Dim ConnectionString As String = Me.Session.ConnectionString
            Dim StartDate As DateTime = Today.Date
            Dim EndDate As DateTime = Today.Date
            Dim Type As String = ""
            Dim Count As Integer = 0

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Count = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[usp_wv_nontask_GetTasks] '{0}', '{1}', '{2}', '{3}', '{4}', '', '','','','','','','','','';",
                                                     StartDate.ToShortDateString, EndDate.ToShortDateString, EmployeeCode, Type, UserCode)).SingleOrDefault




                End Using

                Return Count

            Catch ex As Exception

                Return ex.Message.ToString()

            End Try

        End Function


#End Region
#Region "   Reviews Dashboard "

        Private Sub LoadReviewsDashboard(ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)



        End Sub

#End Region

#Region " Shared Dashboard "

        Private Function LoadDashboardCardGroups(ByVal DashboardType As DashboardType,
                                                 ByVal GroupBy As String,
                                                 ByVal Search As String,
                                                 ByVal IsProofingToolActive As Boolean,
                                                 ByVal IsConceptShareActive As Boolean,
                                                 ByVal IsClientPortal As Boolean,
                                                 ByVal PageSize As Integer,
                                                 ByVal PageNumber As Integer,
                                                 ByRef AssignmentsCount As Integer,
                                                 ByRef AlertsCount As Integer,
                                                 ByRef ReviewsCount As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

            'objects
            Dim CardGroups As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup) = Nothing
            Dim LoadType As String = String.Empty
            Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim TaskStatus As String = String.Empty
            Dim TaskShow As String = String.Empty
            Dim TaskOnlyStartDue As String = String.Empty
            Dim ShowChecklist As Boolean = False
            Dim CardSettings As AdvantageFramework.DTO.Desktop.Dashboard.CardSettings = Nothing
            Dim AlertSettings As AdvantageFramework.ViewModels.Desktop.AlertSettingsViewModel

            AssignmentsCount = 0
            AlertsCount = 0

            Select Case DashboardType
                Case DashboardType.Alerts

                    LoadType = "myalerts"

                Case DashboardType.Assignments

                    LoadType = "myalertassignments"

                Case DashboardType.Reviews

                    LoadType = "myreviews"

                Case Else

                    CardGroups = New List(Of DTO.Desktop.Dashboard.CardGroup)
                    Return CardGroups

            End Select

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "MyTasks").ToList

                Try

                    TaskStatus = AppVars.Where(Function(av) av.Name = "ddType").First.Value
                    TaskShow = AppVars.Where(Function(av) av.Name = "StartToday").First.Value
                    TaskOnlyStartDue = AppVars.Where(Function(av) av.Name = "TodayOnlyStartDue").First.Value

                Catch ex As Exception
                    TaskStatus = String.Empty
                End Try

                Select Case DashboardType

                    Case DashboardType.Alerts

                        AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "ALERT_CARDS").ToList

                        Try

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.CardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        Catch ex As Exception
                            CardSettings = Nothing
                        End Try

                    Case DashboardType.Assignments

                        AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "ASSIGNMENT_CARDS").ToList

                        Try

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.CardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        Catch ex As Exception
                            CardSettings = Nothing
                        End Try

                    Case DashboardType.Reviews

                        AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REVIEW_CARDS").ToList

                        Try

                            CardSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.DTO.Desktop.Dashboard.ReviewCardSettings)(AppVars.Where(Function(av) av.Name = "settings").First.Value)

                        Catch ex As Exception
                            CardSettings = Nothing
                        End Try

                End Select

                Try

                    Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(Me.Session)
                    Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
                    Dim IncludeBoardLevelItems As Boolean = True
                    Dim ErrorMessage As String = ""
                    Dim StartDateString As String = "1/1/1950"
                    Dim EndDateString As String = Today.Date.ToShortDateString

                    If CardSettings Is Nothing Then CardSettings = New DTO.Desktop.Dashboard.CardSettings

                    If Session.Application = AdvantageFramework.Security.Methods.Application.Client_Portal = True OrElse IsClientPortal = True Then

                        If Session.ClientPortalUser IsNot Nothing Then

                            Alerts = AlertController.LoadAlertsCPNew(DbContext, Session.ClientPortalUser.ClientContactID.ToString, TaskShow, TaskOnlyStartDue, TaskStatus, GroupBy)

                        End If

                    Else

                        Alerts = AlertController.LoadAlerts(DbContext, Session.User.EmployeeCode, TaskShow, TaskOnlyStartDue, TaskStatus, GroupBy)

                    End If

                    If String.IsNullOrWhiteSpace(Search) = False Then

                        Alerts = Alerts.Where(Function(a) If(a.Subject Is Nothing, "", a.Subject).ToUpper.Contains(Search.ToUpper) OrElse
                                                        If(a.JobDescription Is Nothing, "", a.JobDescription).ToUpper.Contains(Search.ToUpper) OrElse
                                                        If(a.JobComponentDescription Is Nothing, "", a.JobComponentDescription).ToUpper.Contains(Search.ToUpper) OrElse
                                                        If(a.ClientName Is Nothing, "", a.ClientName).ToUpper.Contains(Search.ToUpper) OrElse
                                                        If(a.JobNumber Is Nothing, "", a.JobNumber.ToString).Contains(Search.ToUpper)).ToList

                    End If

                    Select Case DashboardType
                        Case DashboardType.Alerts

                            AssignmentsCount = GetByType(Alerts.ToList, DashboardType.Assignments, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count
                            ReviewsCount = GetByType(Alerts.ToList, DashboardType.Reviews, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count

                            Alerts = GetByType(Alerts.ToList, DashboardType.Alerts, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true")
                            AlertsCount = Alerts.Count

                        Case DashboardType.Assignments

                            AlertsCount = GetByType(Alerts.ToList, DashboardType.Alerts, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count
                            ReviewsCount = GetByType(Alerts.ToList, DashboardType.Reviews, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count

                            Alerts = GetByType(Alerts.ToList, DashboardType.Assignments, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true")
                            AssignmentsCount = Alerts.Count

                        Case DashboardType.Reviews

                            AssignmentsCount = GetByType(Alerts.ToList, DashboardType.Assignments, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count
                            AlertsCount = GetByType(Alerts.ToList, DashboardType.Alerts, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true").Count

                            Alerts = GetByType(Alerts.ToList, DashboardType.Reviews, IsProofingToolActive, IsConceptShareActive, TaskStatus, TaskShow.ToLower = "true", TaskOnlyStartDue.ToLower = "true")
                            ReviewsCount = Alerts.Count

                    End Select

                    AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "ALERT_VIEW").ToList

                    Try

                        ShowChecklist = AppVars.Where(Function(av) av.Name = "ShowChecklistsOnCards").First.Value

                    Catch ex As Exception
                        ShowChecklist = False
                        AlertSettings = Nothing
                    End Try

                    'Paging before grouping
                    If PageSize > 0 Then

                        If DashboardType = DashboardType.Assignments AndAlso AssignmentsCount > PageSize OrElse
                                    DashboardType = DashboardType.Alerts AndAlso AlertsCount > PageSize Then

                            Alerts = Alerts.Skip(PageNumber * PageSize).Take(PageSize).ToList

                        End If

                    End If
                    If Session.Application = AdvantageFramework.Security.Methods.Application.Client_Portal = True OrElse IsClientPortal = True Then

                        If GroupBy = "PRIORITY" Then

                            CardGroups = (From item In Alerts.GroupBy(Function(c) c.GroupKey)
                                          Select New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup With {.Key = If(item.Key.Contains(","), item.Key.Split(",")(1), item.Key), .Cards = item.Select(Function(c) New AdvantageFramework.DTO.Desktop.Dashboard.Card With {.Title = c.Subject,
                                                                                                                                                                                                                            .JobNumber = c.JobNumber,
                                                                                                                                                                                                                            .StartDate = c.StartDate,
                                                                                                                                                                                                                            .DueDate = c.DueDate,
                                                                                                                                                                                                                            .Priority = c.PriorityLevel,
                                                                                                                                                                                                                            .TimeDue = c.TimeDue,
                                                                                                                                                                                                                            .JobDescription = c.JobDescription,
                                                                                                                                                                                                                            .JobComponentNumber = c.JobComponentNumber,
                                                                                                                                                                                                                            .JobComponentDescription = c.JobComponentDescription,
                                                                                                                                                                                                                            .TaskFunctionDescription = c.TaskFunctionDescription,
                                                                                                                                                                                                                            .AlertTypeID = c.AlertTypeID,
                                                                                                                                                                                                                            .AlertTypeDescription = c.AlertTypeDescription,
                                                                                                                                                                                                                            .ClientName = c.ClientName,
                                                                                                                                                                                                                            .AlertCategoryDescription = c.AlertCategoryDescription,
                                                                                                                                                                                                                            .AlertCategoryID = c.AlertCategoryID,
                                                                                                                                                                                                                            .AlertID = c.ID,
                                                                                                                                                                                                                            .SprintID = If(c.SprintID Is Nothing, 0, c.SprintID),
                                                                                                                                                                                                                            .Data = SetJobInfoForControl(DashboardType, c.ClientName, c.JobNumber, c.JobComponentNumber, c.JobDescription, c.JobComponentDescription, c.TaskSequenceNumber, True, CardSettings, c.TaskComment, c.AlertStateName),
                                                                                                                                                                                                                            .IsAlertAssignment = If(c.IsAlertAssignment = True, "true", "false"),
                                                                                                                                                                                                                            .IsWorkItem = If(c.IsWorkItem = True, "true", "false"),
                                                                                                                                                                                                                            .TaskSequenceNumber = c.TaskSequenceNumber,
                                                                                                                                                                                                                            .CheckListCompleted = c.CheckListCompleted,
                                                                                                                                                                                                                            .CheckListTotal = c.CheckListTotal,
                                                                                                                                                                                                                            .CSProjectID = c.CSProjectID,
                                                                                                                                                                                                                            .CSReviewID = c.CSReviewID,
                                                                                                                                                                                                                            .TaskComment = c.TaskComment,
                                                                                                                                                                                                                            .ShowChecklistsOnCards = If(ShowChecklist = True, "true", "false"),
                                                                                                                                                                                                                            .IsMyTaskTempComplete = c.IsMyTaskTempComplete,
                                                                                                                                                                                                                            .TempCompleteString = If(c.IsMyTaskTempComplete = True, "text-decoration:line-through", ""),
                                                                                                                                                                                                                            .EstimateNumber = c.EstimateNumber,
                                                                                                                                                                                                                            .IsAlertCC = c.IsAlertCC,
                                                                                                                                                                                                                            .ReadAlert = c.ReadAlert,
                                                                                                                                                                                                                            .ReadAlertText = c.ReadAlertText,
                                                                                                                                                                                                                            .EstimateComponentNumber = c.EstimateComponentNumber,
                                                                                                                                                                                                                            .AlertStateName = c.AlertStateName,
                                                                                                                                                                                                                            .ShowState = If(CardSettings IsNot Nothing, If(CardSettings.ShowState = True, "true", "false"), "false"),
                                                                                                                                                                                                                            .TaskStatus = c.TaskStatus,
                                                                                                                                                                                                                            .IsAutoRoute = c.IsAutoRoute,
                                                                                                                                                                                                                            .TaskStatusDescription = If(c.TaskStatus IsNot Nothing, If(c.TaskStatus = "A", "Active", "Projected"), "")}).ToList}).ToList

                        Else

                            CardGroups = (From item In Alerts.GroupBy(Function(c) c.GroupKey)
                                          Select New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup With {.Key = If(item.Key Is Nothing, "None", item.Key), .Cards = item.Select(Function(c) New AdvantageFramework.DTO.Desktop.Dashboard.Card With {.Title = c.Subject,
                                                                                                                                                                                                                            .JobNumber = c.JobNumber,
                                                                                                                                                                                                                            .StartDate = c.StartDate,
                                                                                                                                                                                                                            .DueDate = c.DueDate,
                                                                                                                                                                                                                            .Priority = c.PriorityLevel,
                                                                                                                                                                                                                            .TimeDue = c.TimeDue,
                                                                                                                                                                                                                            .JobDescription = c.JobDescription,
                                                                                                                                                                                                                            .JobComponentNumber = c.JobComponentNumber,
                                                                                                                                                                                                                            .JobComponentDescription = c.JobComponentDescription,
                                                                                                                                                                                                                            .TaskFunctionDescription = c.TaskFunctionDescription,
                                                                                                                                                                                                                            .AlertTypeID = c.AlertTypeID,
                                                                                                                                                                                                                            .AlertTypeDescription = c.AlertTypeDescription,
                                                                                                                                                                                                                            .ClientName = c.ClientName,
                                                                                                                                                                                                                            .AlertCategoryDescription = c.AlertCategoryDescription,
                                                                                                                                                                                                                            .AlertCategoryID = c.AlertCategoryID,
                                                                                                                                                                                                                            .AlertID = c.ID,
                                                                                                                                                                                                                            .SprintID = If(c.SprintID Is Nothing, 0, c.SprintID),
                                                                                                                                                                                                                            .Data = SetJobInfoForControl(DashboardType, c.ClientName, c.JobNumber, c.JobComponentNumber, c.JobDescription, c.JobComponentDescription, c.TaskSequenceNumber, True, CardSettings, c.TaskComment, c.AlertStateName),
                                                                                                                                                                                                                            .IsAlertAssignment = If(c.IsAlertAssignment = True, "true", "false"),
                                                                                                                                                                                                                            .IsWorkItem = If(c.IsWorkItem = True, "true", "false"),
                                                                                                                                                                                                                            .TaskSequenceNumber = c.TaskSequenceNumber,
                                                                                                                                                                                                                            .CheckListCompleted = 0,
                                                                                                                                                                                                                            .CheckListTotal = 0,
                                                                                                                                                                                                                            .CSProjectID = c.CSProjectID,
                                                                                                                                                                                                                            .CSReviewID = c.CSReviewID,
                                                                                                                                                                                                                            .TaskComment = c.TaskComment,
                                                                                                                                                                                                                            .ShowChecklistsOnCards = "false",
                                                                                                                                                                                                                            .IsMyTaskTempComplete = c.IsMyTaskTempComplete,
                                                                                                                                                                                                                            .TempCompleteString = If(c.IsMyTaskTempComplete = True, "text-decoration:line-through", ""),
                                                                                                                                                                                                                            .EstimateNumber = 0,
                                                                                                                                                                                                                            .ReadAlert = c.ReadAlert,
                                                                                                                                                                                                                            .ReadAlertText = c.ReadAlertText,
                                                                                                                                                                                                                            .EstimateComponentNumber = 0,
                                                                                                                                                                                                                            .IsAlertCC = c.IsAlertCC,
                                                                                                                                                                                                                            .AlertStateName = c.AlertStateName,
                                                                                                                                                                                                                            .ShowState = If(CardSettings IsNot Nothing, If(CardSettings.ShowState = True, "true", "false"), "false"),
                                                                                                                                                                                                                            .TaskStatus = c.TaskStatus,
                                                                                                                                                                                                                            .IsAutoRoute = c.IsAutoRoute,
                                                                                                                                                                                                                            .TaskStatusDescription = If(c.TaskStatus IsNot Nothing, If(c.TaskStatus = "A", "Active", "Projected"), "")}).ToList}).ToList

                        End If

                    Else

                        If GroupBy = "PRIORITY" Then

                            CardGroups = (From item In Alerts.GroupBy(Function(c) c.GroupKey)
                                          Select New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup With {.Key = If(item.Key.Contains(","), item.Key.Split(",")(1), item.Key), .Cards = item.Select(Function(c) New AdvantageFramework.DTO.Desktop.Dashboard.Card With {.Title = c.Subject,
                                                                                                                                                                                                                            .JobNumber = c.JobNumber,
                                                                                                                                                                                                                            .StartDate = c.StartDate,
                                                                                                                                                                                                                            .DueDate = c.DueDate,
                                                                                                                                                                                                                            .Priority = c.PriorityLevel,
                                                                                                                                                                                                                            .TimeDue = c.TimeDue,
                                                                                                                                                                                                                            .JobDescription = c.JobDescription,
                                                                                                                                                                                                                            .JobComponentNumber = c.JobComponentNumber,
                                                                                                                                                                                                                            .JobComponentDescription = c.JobComponentDescription,
                                                                                                                                                                                                                            .TaskFunctionDescription = c.TaskFunctionDescription,
                                                                                                                                                                                                                            .AlertTypeID = c.AlertTypeID,
                                                                                                                                                                                                                            .AlertTypeDescription = c.AlertTypeDescription,
                                                                                                                                                                                                                            .ClientName = c.ClientName,
                                                                                                                                                                                                                            .AlertCategoryDescription = c.AlertCategoryDescription,
                                                                                                                                                                                                                            .AlertCategoryID = c.AlertCategoryID,
                                                                                                                                                                                                                            .AlertID = c.ID,
                                                                                                                                                                                                                            .SprintID = If(c.SprintID Is Nothing, 0, c.SprintID),
                                                                                                                                                                                                                            .Data = SetJobInfoForControl(DashboardType, c.ClientName, c.JobNumber, c.JobComponentNumber, c.JobDescription, c.JobComponentDescription, c.TaskSequenceNumber, True, CardSettings, c.TaskComment, c.AlertStateName),
                                                                                                                                                                                                                            .IsAlertAssignment = If(c.IsAlertAssignment = True, "true", "false"),
                                                                                                                                                                                                                            .IsWorkItem = If(c.IsWorkItem = True, "true", "false"),
                                                                                                                                                                                                                            .TaskSequenceNumber = c.TaskSequenceNumber,
                                                                                                                                                                                                                            .CheckListCompleted = c.CheckListCompleted,
                                                                                                                                                                                                                            .CheckListTotal = c.CheckListTotal,
                                                                                                                                                                                                                            .CSProjectID = c.CSProjectID,
                                                                                                                                                                                                                            .CSReviewID = c.CSReviewID,
                                                                                                                                                                                                                            .TaskComment = c.TaskComment,
                                                                                                                                                                                                                            .ShowChecklistsOnCards = If(ShowChecklist = True, "true", "false"),
                                                                                                                                                                                                                            .IsMyTaskTempComplete = c.IsMyTaskTempComplete,
                                                                                                                                                                                                                            .TempCompleteString = If(c.IsMyTaskTempComplete = True, "text-decoration:line-through", ""),
                                                                                                                                                                                                                            .EstimateNumber = c.EstimateNumber,
                                                                                                                                                                                                                            .ReadAlert = c.ReadAlert,
                                                                                                                                                                                                                            .ReadAlertText = c.ReadAlertText,
                                                                                                                                                                                                                            .EstimateComponentNumber = c.EstimateComponentNumber,
                                                                                                                                                                                                                            .IsAlertCC = c.IsAlertCC,
                                                                                                                                                                                                                            .AlertStateName = c.AlertStateName,
                                                                                                                                                                                                                            .ShowState = If(CardSettings IsNot Nothing, If(CardSettings.ShowState = True, "true", "false"), "false"),
                                                                                                                                                                                                                            .TaskStatus = c.TaskStatus,
                                                                                                                                                                                                                            .IsAutoRoute = c.IsAutoRoute,
                                                                                                                                                                                                                            .TaskStatusDescription = If(c.TaskStatus IsNot Nothing, If(c.TaskStatus = "A", "Active", "Projected"), "")}).ToList}).ToList

                        Else

                            CardGroups = (From item In Alerts.GroupBy(Function(c) c.GroupKey)
                                          Select New AdvantageFramework.DTO.Desktop.Dashboard.CardGroup With {.Key = If(item.Key Is Nothing, "None", item.Key), .Cards = item.Select(Function(c) New AdvantageFramework.DTO.Desktop.Dashboard.Card With {.Title = c.Subject,
                                                                                                                                                                                                                            .JobNumber = c.JobNumber,
                                                                                                                                                                                                                            .StartDate = c.StartDate,
                                                                                                                                                                                                                            .DueDate = c.DueDate,
                                                                                                                                                                                                                            .Priority = c.PriorityLevel,
                                                                                                                                                                                                                            .TimeDue = c.TimeDue,
                                                                                                                                                                                                                            .JobDescription = c.JobDescription,
                                                                                                                                                                                                                            .JobComponentNumber = c.JobComponentNumber,
                                                                                                                                                                                                                            .JobComponentDescription = c.JobComponentDescription,
                                                                                                                                                                                                                            .TaskFunctionDescription = c.TaskFunctionDescription,
                                                                                                                                                                                                                            .AlertTypeID = c.AlertTypeID,
                                                                                                                                                                                                                            .AlertTypeDescription = c.AlertTypeDescription,
                                                                                                                                                                                                                            .ClientName = c.ClientName,
                                                                                                                                                                                                                            .AlertCategoryDescription = c.AlertCategoryDescription,
                                                                                                                                                                                                                            .AlertCategoryID = c.AlertCategoryID,
                                                                                                                                                                                                                            .AlertID = c.ID,
                                                                                                                                                                                                                            .SprintID = If(c.SprintID Is Nothing, 0, c.SprintID),
                                                                                                                                                                                                                            .Data = SetJobInfoForControl(DashboardType, c.ClientName, c.JobNumber, c.JobComponentNumber, c.JobDescription, c.JobComponentDescription, c.TaskSequenceNumber, True, CardSettings, c.TaskComment, c.AlertStateName),
                                                                                                                                                                                                                            .IsAlertAssignment = If(c.IsAlertAssignment = True, "true", "false"),
                                                                                                                                                                                                                            .IsWorkItem = If(c.IsWorkItem = True, "true", "false"),
                                                                                                                                                                                                                            .TaskSequenceNumber = c.TaskSequenceNumber,
                                                                                                                                                                                                                            .CheckListCompleted = c.CheckListCompleted,
                                                                                                                                                                                                                            .CheckListTotal = c.CheckListTotal,
                                                                                                                                                                                                                            .CSProjectID = c.CSProjectID,
                                                                                                                                                                                                                            .CSReviewID = c.CSReviewID,
                                                                                                                                                                                                                            .TaskComment = c.TaskComment,
                                                                                                                                                                                                                            .ShowChecklistsOnCards = If(ShowChecklist = True, "true", "false"),
                                                                                                                                                                                                                            .IsMyTaskTempComplete = c.IsMyTaskTempComplete,
                                                                                                                                                                                                                            .TempCompleteString = If(c.IsMyTaskTempComplete = True, "text-decoration:line-through", ""),
                                                                                                                                                                                                                            .EstimateNumber = c.EstimateNumber,
                                                                                                                                                                                                                            .ReadAlert = c.ReadAlert,
                                                                                                                                                                                                                            .ReadAlertText = c.ReadAlertText,
                                                                                                                                                                                                                            .EstimateComponentNumber = c.EstimateComponentNumber,
                                                                                                                                                                                                                            .IsAlertCC = c.IsAlertCC,
                                                                                                                                                                                                                            .AlertStateName = c.AlertStateName,
                                                                                                                                                                                                                            .ShowState = If(CardSettings IsNot Nothing, If(CardSettings.ShowState = True, "true", "false"), "false"),
                                                                                                                                                                                                                            .TaskStatus = c.TaskStatus,
                                                                                                                                                                                                                            .IsAutoRoute = c.IsAutoRoute,
                                                                                                                                                                                                                            .TaskStatusDescription = If(c.TaskStatus IsNot Nothing, If(c.TaskStatus = "A", "Active", "Projected"), "")}).ToList}).ToList

                        End If

                    End If

                Catch ex As Exception
                    CardGroups = Nothing
                End Try

            End Using

            If CardGroups Is Nothing Then CardGroups = New List(Of DTO.Desktop.Dashboard.CardGroup)

            Return CardGroups

        End Function
        'Separate function to make sure always get counts from same base list 
        Private Function GetByType(ByVal BaseList As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert),
                                   ByVal DashType As DashboardType,
                                   ByVal IsProofingToolActive As Boolean,
                                   ByVal IsConceptShareActive As Boolean,
                                   ByVal AssignmentTaskStatus As String,
                                   ByVal AssignmentTaskShow As Boolean,
                                   ByVal AssignmentTaskOnlyStartDue As Boolean) As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert)

            Dim List As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing

            If BaseList IsNot Nothing Then

                List = BaseList

                Select Case DashType
                    Case DashboardType.Alerts

                        'List = List.Where(Function(A) (A.IsProof Is Nothing OrElse A.IsProof = False) AndAlso A.AlertCategoryID <> 79 AndAlso A.AlertTypeID <> 15).ToList
                        List = List.Where(Function(F) F.IsAlertCC = True).ToList

                    Case DashboardType.Assignments

                        List = List.Where(Function(A) (A.IsProof Is Nothing OrElse A.IsProof = False) AndAlso A.AlertCategoryID <> 79 AndAlso A.AlertTypeID <> 15).ToList
                        List = List.Where(Function(F) F.IsAlertCC = False).ToList

                        Try

                            Select Case AssignmentTaskStatus
                                Case "Active"

                                    List = List.Where(Function(a) a.TaskStatus = "A" OrElse a.TaskStatus = "H" OrElse a.TaskStatus = "L" OrElse a.TaskStatus Is Nothing).ToList

                                Case "Projected"

                                    List = List.Where(Function(a) a.TaskStatus = "P" OrElse a.TaskStatus Is Nothing).ToList

                                Case "H"

                                    List = List.Where(Function(a) a.TaskStatus = "H" OrElse a.TaskStatus Is Nothing).ToList

                                Case "L"

                                    List = List.Where(Function(a) a.TaskStatus = "L" OrElse a.TaskStatus Is Nothing).ToList

                            End Select
                            If AssignmentTaskShow = True Then

                                List = List.Where(Function(a) a.StartDate <= Today() OrElse a.StartDate Is Nothing).ToList

                            End If
                            If AssignmentTaskOnlyStartDue = True Then

                                List = List.Where(Function(a) (a.StartDate IsNot Nothing AndAlso a.DueDate IsNot Nothing)).ToList

                            End If

                        Catch ex As Exception
                        End Try

                    Case DashboardType.Reviews

                        If IsProofingToolActive = True AndAlso IsConceptShareActive = True Then

                            List = List.Where(Function(A) (A.IsProof Is Nothing AndAlso A.IsProof = True) OrElse
                                                  A.AlertCategoryID = 79 OrElse
                                                  A.AlertTypeID = 15).ToList

                        ElseIf IsProofingToolActive = True AndAlso IsConceptShareActive = False Then

                            List = List.Where(Function(A) (A.AlertCategoryID = 79)).ToList

                        ElseIf IsProofingToolActive = False AndAlso IsConceptShareActive = True Then

                            List = List.Where(Function(A) (A.AlertTypeID = 15)).ToList

                        End If

                        List = List.Where(Function(F) F.IsAlertCC = False).Distinct.ToList

                End Select

        End If

        Return List

        End Function
        Private Function LoadDashboardItemCount(ByVal Type As DashboardType, Optional ByVal IsClientPortal As Boolean = False) As Integer

            Dim Count As Integer = 0
            Dim LoadType As String = "myalertassignments"

            Try

                Select Case Type
                    Case DashboardType.Alerts

                        LoadType = "myalerts"

                    Case DashboardType.Assignments

                        LoadType = "myalertassignments"

                    Case DashboardType.Reviews

                        LoadType = "myreviews"

                    Case Else

                        Return 0

                End Select

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        Dim AlertController As New AdvantageFramework.Controller.Desktop.AlertController(Me.Session)
                        Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
                        Dim IncludeBoardLevelItems As Boolean = True
                        Dim ErrorMessage As String = ""
                        Dim StartDateString As String = "1/1/1950"
                        Dim EndDateString As String = Today.Date.ToShortDateString

                        If Session.Application = AdvantageFramework.Security.Methods.Application.Client_Portal = True OrElse IsClientPortal = True Then

                            If Session.ClientPortalUser IsNot Nothing Then

                                Alerts = AlertController.LoadAlertsCP(DbContext,
                                                                      Session.ClientPortalUser.ClientContactID, "inbox", "", "", "", "", "", "", "", 0, 0, 0, 0,
                                                                      StartDateString, EndDateString, "", "", 0, 0, "", "", 0, LoadType, 0, "", False, False, 0, "", "", "", "", 0, 0, True, Count, False, False, ErrorMessage)

                            End If

                        Else

                            Alerts = AlertController.LoadAlerts(DbContext,
                                                            Session.User.EmployeeCode,
                                                            "inbox",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            0,
                                                            0,
                                                            0,
                                                            0,
                                                            StartDateString,
                                                            EndDateString,
                                                            "",
                                                            "",
                                                            0,
                                                            0,
                                                            "",
                                                            "",
                                                            0,
                                                            LoadType,
                                                            0,
                                                            "",
                                                            False,
                                                            False,
                                                            0,
                                                            "",
                                                            "",
                                                            "",
                                                            "",
                                                            0,
                                                            0,
                                                            True,
                                                            Count,
                                                            False,
                                                            IncludeBoardLevelItems,
                                                            ErrorMessage)

                        End If



                    Catch ex As Exception
                        Count = -1
                    End Try

                End Using

            Catch ex As Exception
                Count = 0
            End Try

            Return Count

        End Function
        Public Function SetJobInfoForControl(ByVal DashboardType As DashboardType, ByVal ClientName As String, ByVal JobNumber As Integer?, ByVal JobComponentNumber As Short?,
                                             ByVal JobDescription As String, ByVal JobComponentDescription As String, ByVal TaskSeqNumber As Integer?,
                                             ByVal Truncate As Boolean?, ByVal CardSettings As AdvantageFramework.DTO.Desktop.Dashboard.CardSettings, ByVal TaskComment As String, ByVal State As String) As List(Of String)

            Dim data As New List(Of String)

            Try

                Dim TextStringBuilder As New System.Text.StringBuilder
                Dim ToolTipStringBuilder As New System.Text.StringBuilder
                Dim ControlText As String = String.Empty
                Dim ControlToolTip As String = String.Empty

                If CardSettings Is Nothing Then

                    CardSettings = New DTO.Desktop.Dashboard.CardSettings

                End If

                If CardSettings.ShowState = True AndAlso String.IsNullOrWhiteSpace(State) = False Then

                    'data.Add(State)

                End If
                If CardSettings.ShowTaskComment = True AndAlso String.IsNullOrWhiteSpace(TaskComment) = False Then

                    data.Add(TaskComment)

                End If
                If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                    If CardSettings.ShowJobNumber = True Then

                        TextStringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                    End If

                    ToolTipStringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                End If
                If CardSettings.ShowJobComponentNumber = False And CardSettings.ShowJobDescription = False AndAlso CardSettings.ShowJobComponentDescription = False Then

                    data.Add(TextStringBuilder.ToString)

                End If
                If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                    If CardSettings.ShowJobComponentNumber = True Then

                        If CardSettings.ShowJobNumber = True Then

                            TextStringBuilder.Append("/")

                        End If

                        TextStringBuilder.Append(JobComponentNumber.ToString.PadLeft(2, "0"))

                    End If

                    If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                        ToolTipStringBuilder.Append("/")

                    End If

                    ToolTipStringBuilder.Append(JobComponentNumber.ToString.PadLeft(2, "0"))

                End If
                If CardSettings.ShowJobComponentNumber = True And CardSettings.ShowJobDescription = False AndAlso CardSettings.ShowJobComponentDescription = False Then

                    data.Add(TextStringBuilder.ToString)

                End If
                If (CardSettings.ShowJobNumber = True OrElse CardSettings.ShowJobComponentNumber = True) AndAlso (CardSettings.ShowJobDescription = True OrElse CardSettings.ShowJobComponentDescription = True) Then

                    TextStringBuilder.Append(" - ")

                End If
                If String.IsNullOrWhiteSpace(JobDescription) = False AndAlso String.IsNullOrWhiteSpace(JobComponentDescription) = False Then

                    ToolTipStringBuilder.Append(" - ")

                    If CardSettings.ShowJobDescription = True AndAlso CardSettings.ShowJobComponentDescription = True Then

                        If String.Equals(JobDescription.ToUpper.Trim, JobComponentDescription.ToUpper.Trim) = True Then

                            TextStringBuilder.Append(JobComponentDescription)

                            data.Add(TextStringBuilder.ToString)

                        Else

                            If String.IsNullOrEmpty(JobDescription) = False Then

                                TextStringBuilder.Append(JobDescription)

                            End If
                            If String.IsNullOrEmpty(JobComponentDescription) = False Then

                                If CardSettings.ShowJobDescription = True Then

                                    data.Add(TextStringBuilder.ToString)

                                End If

                                data.Add(JobComponentDescription)

                            End If

                        End If

                    Else

                        If CardSettings.ShowJobDescription = True AndAlso String.IsNullOrEmpty(JobDescription) = False Then

                            TextStringBuilder.Append(JobDescription)

                            data.Add(TextStringBuilder.ToString)

                        End If
                        If CardSettings.ShowJobComponentDescription = True AndAlso String.IsNullOrEmpty(JobComponentDescription) = False Then

                            TextStringBuilder.Append(JobComponentDescription)

                            data.Add(TextStringBuilder.ToString)

                        End If

                    End If

                ElseIf String.IsNullOrWhiteSpace(JobDescription) = False AndAlso String.IsNullOrWhiteSpace(JobComponentDescription) = True Then

                    If CardSettings.ShowJobDescription = True AndAlso String.IsNullOrEmpty(JobDescription) = False Then

                        TextStringBuilder.Append(JobDescription)

                        data.Add(TextStringBuilder.ToString)

                    End If

                End If
                If String.IsNullOrWhiteSpace(ClientName) = False AndAlso CardSettings.ShowClientName = True Then

                    data.Add(ClientName)

                End If
                If String.IsNullOrEmpty(JobDescription) = False AndAlso String.IsNullOrEmpty(JobComponentDescription) = False Then

                    If String.Equals(JobDescription.ToUpper.Trim, JobComponentDescription.ToUpper.Trim) = True Then

                        ToolTipStringBuilder.Append(JobComponentDescription)

                    Else

                        If String.IsNullOrEmpty(JobDescription) = False Then

                            ToolTipStringBuilder.Append(JobDescription)

                        End If
                        If String.IsNullOrEmpty(JobComponentDescription) = False Then

                            ToolTipStringBuilder.Append(", ")
                            ToolTipStringBuilder.Append(JobComponentDescription)

                        End If

                    End If

                End If

                ControlText = TextStringBuilder.ToString
                ControlToolTip = ToolTipStringBuilder.ToString

                If Truncate = True Then

                    ControlText = AdvantageFramework.StringUtilities.Truncate(ControlText, 35)

                End If

            Catch ex As Exception
                If data Is Nothing Then data = New List(Of String)
                'data.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
            End Try

            Return data

        End Function

#End Region

#Region "   Tasks Dashboard "

        Private Sub LoadTasksDashboard(ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard)



        End Sub
        Private Function LoadTasksDashboardCardGroups(ByVal Dashboard As AdvantageFramework.DTO.Desktop.Dashboard) As Generic.List(Of AdvantageFramework.DTO.Desktop.Dashboard.CardGroup)

            Return Nothing

        End Function
        Private Function LoadTasks(ByVal UserID As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal TaskStatus As String,
                                   Optional ByVal TaskShow As String = "",
                                   Optional ByVal search As String = "",
                                   Optional ByVal CP As Boolean = False,
                                   Optional ByVal CPID As Integer = 0,
                                   Optional ByVal Sort As String = "") As DataTable

            Return Nothing
            ''objects
            'Dim SqlParameters As Generic.List(Of System.Data.SqlClient.SqlParameter) = Nothing
            'Dim UserIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim TaskStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim TaskShowSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim SearchSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim ClientPortalSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim ClientPortalIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim SortSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            'Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            'Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            'Dim DataTable As System.Data.DataTable = Nothing

            'SqlParameters = New List(Of SqlClient.SqlParameter)

            'UserIDSqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 100)
            'UserIDSqlParameter.Value = UserID

            'EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            'EmployeeCodeSqlParameter.Value = EmpCode

            'StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.DateTime, 0)
            'StartDateSqlParameter.Value = StartDate

            'TaskStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@TaskStatus", SqlDbType.VarChar, 10)
            'TaskStatusSqlParameter.Value = TaskStatus

            'TaskShowSqlParameter = New System.Data.SqlClient.SqlParameter("@TaskShow", SqlDbType.VarChar, 10)
            'TaskShowSqlParameter.Value = TaskShow

            'SearchSqlParameter = New System.Data.SqlClient.SqlParameter("@Search", SqlDbType.VarChar, 500)
            'SearchSqlParameter.Value = search

            'ClientPortalSqlParameter = New System.Data.SqlClient.SqlParameter("@CP", SqlDbType.Int)

            'If CP = True Then

            '    ClientPortalSqlParameter.Value = 1

            'Else
            '    ClientPortalSqlParameter.Value = 0

            'End If

            'ClientPortalIDSqlParameter = New System.Data.SqlClient.SqlParameter("@CPID", SqlDbType.Int)
            'ClientPortalIDSqlParameter.Value = CPID

            'SortSqlParameter = New System.Data.SqlClient.SqlParameter("@SORT", SqlDbType.VarChar, 50)

            'If Sort = "" Then

            '    SortSqlParameter.Value = System.DBNull.Value

            'Else

            '    SortSqlParameter.Value = Sort

            'End If

            'SqlParameters.Add(UserIDSqlParameter)
            'SqlParameters.Add(EmployeeCodeSqlParameter)
            'SqlParameters.Add(StartDateSqlParameter)
            'SqlParameters.Add(TaskStatusSqlParameter)
            'SqlParameters.Add(TaskShowSqlParameter)
            'SqlParameters.Add(SearchSqlParameter)
            'SqlParameters.Add(ClientPortalSqlParameter)
            'SqlParameters.Add(ClientPortalIDSqlParameter)
            'SqlParameters.Add(SortSqlParameter)

            'Try

            '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '        SqlConnection = DbContext.Database.Connection
            '        SqlCommand = New SqlClient.SqlCommand("[dbo].[advsp_tasks_get_by_employee]", SqlConnection)
            '        SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

            '        Using SqlCommand

            '            SqlCommand.CommandType = CommandType.StoredProcedure

            '            SqlCommand.Parameters.AddRange(SqlParameters.ToArray)

            '            DataTable = New DataTable

            '            SqlDataAdapter.Fill(DataTable)

            '        End Using

            '        Return DataTable

            '    End Using

            'Catch
            '    Return Nothing
            'End Try

        End Function
        Private Function LoadTasksDashboardItemCount() As Integer

            Return 0
            ''objects
            'Dim Count As Integer = Nothing
            'Dim TaskType As String = ""
            'Dim TaskShow As String = ""
            'Dim SearchValue As String = ""
            'Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            'Dim ClientContactID As Integer = Nothing
            'Dim Sort As String = ""
            'Dim IsClientPortal As Boolean = False

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "MyTasks").ToList

            '    If AppVars.Where(Function(av) av.Name = "ddType").Any Then

            '        TaskType = AppVars.Where(Function(av) av.Name = "ddType").First.Value

            '    End If

            '    If AppVars.Where(Function(av) av.Name = "ddTaskShow").Any Then

            '        TaskShow = AppVars.Where(Function(av) av.Name = "ddTaskShow").First.Value

            '    End If

            '    If String.IsNullOrWhiteSpace(TaskShow) Then

            '        TaskShow = "ALL"

            '    End If

            '    If AppVars.Where(Function(av) av.Name = "sSearch").Any Then

            '        SearchValue = AppVars.Where(Function(av) av.Name = "sSearch").First.Value

            '    End If

            '    Select Case (TaskType.ToUpper)

            '        Case "PROJECTED"

            '            TaskType = "P"

            '        Case "ACTIVE"

            '            TaskType = "A"

            '        Case "H"

            '            TaskType = "H"

            '        Case "L"

            '            TaskType = "L"

            '        Case "EVENT_TASKS"

            '            TaskType = "E"

            '        Case "ALL"

            '            TaskType = ""

            '        Case Else

            '            TaskType = ""

            '    End Select

            'End Using

            'Try

            '    If Session.ClientPortalUser IsNot Nothing Then

            '        ClientContactID = Session.ClientPortalUser.ClientContactID
            '        IsClientPortal = True

            '    End If

            'Catch ex As Exception
            '    ClientContactID = 0
            'End Try

            'Count = LoadTasks(Session.UserCode, Me.Session.User.EmployeeCode, Today(), TaskType, TaskShow, SearchValue, IsClientPortal, ClientContactID, Sort).Rows.Count

            'Return Count

        End Function

#End Region

    End Class

End Namespace
