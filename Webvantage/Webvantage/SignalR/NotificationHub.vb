Imports System
Imports System.Web
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Hubs
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Newtonsoft
Imports System.Threading

Namespace SignalR.Classes

    <Authorize>
    Public Class NotificationHub
        Inherits SignalR.Classes.BaseHub

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AssignmentPageUpdateType

            Full = 0
            Comments = 1
            Checklists = 2
            AssigneesAndCCs = 3
            Hours = 4
            Proofing = 5

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Public Shared Sub Blast()

        '    Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
        '    NotificationHubContext.Clients.All.testMessage()

        'End Sub

#Region " Sprint related "

        Public Shared Sub MessageUser(ByVal UserCode As String,
                                      ByVal Message As String)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                NotificationHubContext.Clients.User(UserCode).messageUser(UserCode, Message)

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub RefreshDashboardWorkItemsForAllSprintUsers(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal SprintID As Integer, ByVal IncludeSelf As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshDashboardWorkItemsForAllSprintUsers(ThreadedDbContext, SprintID, IncludeSelf))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshDashboardWorkItemsForAllSprintUsers(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal SprintID As Integer, ByVal IncludeSelf As Boolean)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                For Each OnlineUserCode As String In GetUsersBySprintID(DbContext, SprintID, IncludeSelf)

                    NotificationHubContext.Clients.User(OnlineUserCode).refreshDashboardWorkItems()

                Next

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub RefreshDashboardWorkItems(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshDashboardWorkItems(ThreadedDbContext))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshDashboardWorkItems(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                'NotificationHubContext.Clients.All.refreshDashboardWorkItems() <-- Don't use all because of hosted
                For Each OnlineUserCode As String In GetUsersByWebID(DbContext)

                    NotificationHubContext.Clients.User(OnlineUserCode).refreshDashboardWorkItems()

                Next

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub RefreshSprint(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SprintID As Integer, ByVal UpdateDashboard As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshSprint(ThreadedDbContext, SprintID, UpdateDashboard))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshSprint(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal SprintID As Integer, ByVal UpdateDashboard As Boolean)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
                Dim Employee As AdvantageFramework.Database.Views.Employee

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, DbContext.UserCode)

                If Employee IsNot Nothing Then

                    Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    Sprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                    If Sprint IsNot Nothing Then

                        Dim IsActive As Boolean = False
                        Dim IsComplete As Boolean = False

                        If Sprint.IsActive IsNot Nothing AndAlso Sprint.IsActive = True Then IsActive = True
                        If Sprint.IsComplete IsNot Nothing AndAlso Sprint.IsComplete = True Then IsComplete = True

                        For Each OnlineUserCode As String In GetUsersByWebID(DbContext)

                            If OnlineUserCode <> DbContext.UserCode Then 'Don't refresh for user making the change because the controller returns the update/refresh

                                NotificationHubContext.Clients.User(OnlineUserCode).refreshSprint(SprintID, IsActive.ToString.ToLower, IsComplete.ToString.ToLower, Employee.ToString)

                            End If
                            If UpdateDashboard = True Then

                                NotificationHubContext.Clients.User(OnlineUserCode).refreshDashboardWorkItems()
                                NotificationHubContext.Clients.User(OnlineUserCode).refreshAlerts()

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
            End Try

        End Sub

#End Region

        Public Shared Sub RefreshTaskAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal SprintID As Integer, ByVal UserCode As String)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshTaskAssignment(ThreadedDbContext, AlertID, SprintID, UserCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshTaskAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal SprintID As Integer, ByVal UserCode As String)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                NotificationHubContext.Clients.User(UserCode).refreshDashboardWorkItems()

                If SprintID = 0 Then

                    Try

                        DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SH.ID FROM SPRINT_DTL SD INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID WHERE ALERT_ID = {0} ORDER BY SH.IS_ACTIVE DESC, SH.IS_COMPLETE;", AlertID))

                    Catch ex As Exception
                        SprintID = 0
                    End Try

                End If

                If SprintID > 0 Then

                    RefreshSprint(DbContext, SprintID, False)

                End If

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub NotifyRecipientsAll(ByVal AlertID As Integer, ByVal ConnectionString As String, ByVal UserCode As String)

            Dim SeparateThread = New Thread(Sub() _NotifyRecipientsAll(AlertID, ConnectionString, UserCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _NotifyRecipientsAll(ByVal AlertID As Integer, ByVal ConnectionString As String, ByVal UserCode As String)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    NotifyRecipientsAll(DbContext, AlertID)

                End Using

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub NotifyRecipientsAll(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _NotifyRecipientsAll(ThreadedDbContext, AlertID))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _NotifyRecipientsAll(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer)

            Try

                Dim AlertUserCodes As New List(Of String)
                Dim SQL As String = String.Format("SELECT DISTINCT SU.USER_CODE FROM [dbo].[advtf_alert_recipient_get]({0}) AS AR INNER JOIN SEC_USER SU ON AR.EmployeeCode = SU.EMP_CODE WHERE NOT SU.WEB_ID IS NULL;", AlertID)

                AlertUserCodes = DbContext.Database.SqlQuery(Of String)(SQL).ToList()

                If AlertUserCodes IsNot Nothing Then

                    Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                    For Each AlertUserCode As String In AlertUserCodes

                        NotificationHubContext.Clients.User(AlertUserCode).refreshAlerts()

                    Next

                End If

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub NotifyRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer)

            NotifyRecipients(AlertID, DbContext.ConnectionString, DbContext.UserCode)

        End Sub
        Public Shared Sub NotifyRecipients(ByVal AlertID As Integer, ByVal ConnectionString As String, ByVal UserCode As String)

            Dim SeparateThread = New Thread(Sub() _NotifyRecipients(AlertID, ConnectionString, UserCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _NotifyRecipients(ByVal AlertID As Integer, ByVal ConnectionString As String, ByVal UserCode As String)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Dim AlertUserCodes As New List(Of String)
                    Dim SQL As String = String.Format("SELECT DISTINCT SU.USER_CODE FROM [dbo].[advtf_alert_recipient_get]({0}) AS AR INNER JOIN SEC_USER SU ON AR.EmployeeCode = SU.EMP_CODE WHERE AR.IsTaskEmployee = 0;", AlertID)

                    AlertUserCodes = DbContext.Database.SqlQuery(Of String)(SQL).ToList()

                    If AlertUserCodes IsNot Nothing Then

                        Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()

                        For Each AlertUserCode As String In AlertUserCodes

                            If UserCode <> AlertUserCode Then NotificationHubContext.Clients.User(AlertUserCode).refreshAlerts()

                        Next

                    End If

                End Using

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub RefreshAlertsForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAlertsForEmployee(ThreadedDbContext, EmployeeCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshAlertsForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String)

            Try

                Dim UserCodesToRefresh As Generic.List(Of String) = Nothing

                Dim SQL As String = String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WITH(NOLOCK) WHERE EMP_CODE = '{0}' ORDER BY USER_CODE DESC;", EmployeeCode)

                UserCodesToRefresh = DbContext.Database.SqlQuery(Of String)(SQL).ToList

                If UserCodesToRefresh IsNot Nothing Then

                    For Each UserCode As String In UserCodesToRefresh

                        RefreshAlertsForUser(UserCode)

                    Next

                End If

            Catch ex As Exception
            End Try

        End Sub
        Public Shared Sub RefreshAlertsForEmployee(ByVal EmployeeCode As String, ByVal ConnectionString As String, ByVal UserCode As String)

            Dim SeparateThread = New Thread(Sub() _RefreshAlertsForEmployee(EmployeeCode, ConnectionString, UserCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshAlertsForEmployee(ByVal EmployeeCode As String, ByVal ConnectionString As String, ByVal UserCode As String)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    RefreshAlertsForEmployee(DbContext, EmployeeCode)

                End Using

            Catch ex As Exception
            End Try

        End Sub

        Public Shared Sub RefreshAlertsForUser(ByVal UserCode As String)

            Dim SeparateThread = New Thread(Sub() _RefreshAlertsForUser(UserCode))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshAlertsForUser(ByVal UserCode As String)

            Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
            NotificationHubContext.Clients.User(UserCode).refreshAlerts()

        End Sub

#Region " Dashboard specific "

        Public Shared Sub RefreshMyAssignmentsBecauseIamTheAssignee(ByVal ConnectionString As String,
                                                                    ByVal EmployeeCode As String, ByVal UserCode As String,
                                                                    ByVal AlertID As Integer)

            Dim SeparateThread = New Thread(Sub() _RefreshMyAssignmentsBecauseIamTheAssignee(ConnectionString, EmployeeCode, UserCode, AlertID))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshMyAssignmentsBecauseIamTheAssignee(ByVal ConnectionString As String,
                                                                     ByVal EmployeeCode As String, ByVal UserCode As String,
                                                                     ByVal AlertID As Integer)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Dim Update As Boolean = False
                    Dim AssigneeCount As Integer = 0
                    Dim IsAssigneeSQL As String = String.Format("SELECT CAST(COUNT(1) AS INT) AS CT FROM ALERT A WITH(NOLOCK) INNER JOIN ALERT_RCPT R WITH(NOLOCK) ON A.ALERT_ID = R.ALERT_ID" &
                                                                " WHERE A.ALERT_ID = {0} AND (R.EMP_CODE = '{1}' OR A.ASSIGNED_EMP_CODE = '{1}');", AlertID, EmployeeCode)

                    AssigneeCount = DbContext.Database.SqlQuery(Of Integer)(IsAssigneeSQL).SingleOrDefault

                    Update = AssigneeCount > 0

                    If Update = True Then

                        Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
                        NotificationHubContext.Clients.User(UserCode).refreshMyAssignmentsNotificationsAndCounts()

                    End If


                End Using

            Catch ex As Exception
            End Try

        End Sub

#End Region

#Region " Assignment page and parts "

        Public Shared Sub RefreshAlertProof(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer,
                                            ByVal UserCode As String, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, AssignmentPageUpdateType.Proofing, "", UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub RefreshNewAlertView(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer, ByVal SprintID As Integer?,
                                              ByVal UserCode As String, ByVal RemovedUserCode As String,
                                              ByVal IncludeUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshNewAlertView(ThreadedDbContext, AlertID, SprintID,
                                                                       UserCode, RemovedUserCode,
                                                                       IncludeUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub _RefreshNewAlertView(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal AlertID As Integer, ByVal SprintID As Integer?,
                                               ByVal UserCode As String, ByVal RemovedUserCode As String,
                                               ByVal IncludeUser As Boolean)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
                Dim Employee As AdvantageFramework.Database.Views.Employee
                Dim SprintIsActive As Boolean = False
                Dim SprintIsComplete As Boolean = False

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, UserCode)

                If Employee IsNot Nothing Then

                    Dim AlertUserCodes As New List(Of String)
                    Dim OnlineUserCodes As New List(Of String)
                    Dim SQL As String = String.Format("SELECT DISTINCT SU.USER_CODE FROM [dbo].[advtf_alert_recipient_get]({0}) AS AR INNER JOIN SEC_USER SU ON AR.EmployeeCode = SU.EMP_CODE WHERE NOT SU.WEB_ID IS NULL;", AlertID)
                    Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing

                    AlertUserCodes = DbContext.Database.SqlQuery(Of String)(SQL).ToList()
                    OnlineUserCodes = GetUsersByWebID(DbContext)

                    If SprintID IsNot Nothing AndAlso SprintID > 0 Then

                        Sprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                        If Sprint IsNot Nothing Then

                            If Sprint.IsActive IsNot Nothing AndAlso Sprint.IsActive = True Then SprintIsActive = True
                            If Sprint.IsComplete IsNot Nothing AndAlso Sprint.IsComplete = True Then SprintIsComplete = True

                        End If

                    End If
                    If AlertUserCodes.Contains(UserCode) = False AndAlso IncludeUser = True Then

                        AlertUserCodes.Add(UserCode)

                    End If
                    If String.IsNullOrWhiteSpace(RemovedUserCode) = False Then

                        AlertUserCodes.Add(RemovedUserCode)

                    End If
                    For Each OnlineUserCode As String In OnlineUserCodes

                        If (OnlineUserCode <> UserCode) OrElse (OnlineUserCode = UserCode AndAlso IncludeUser = True) Then

                            NotificationHubContext.Clients.User(OnlineUserCode).refreshNewAlertView(AlertID, SprintID, Employee.ToString)
                            NotificationHubContext.Clients.User(OnlineUserCode).refreshDashboardWorkItems()

                        End If

                        Try

                            If Sprint Is Nothing AndAlso SprintID > 0 Then

                                Sprint = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintID)

                            End If
                            If Sprint IsNot Nothing Then 'refresh sprint for anyone that has it open

                                NotificationHubContext.Clients.User(OnlineUserCode).refreshSprint(SprintID, SprintIsActive.ToString.ToLower, SprintIsComplete.ToString.ToLower, Employee.ToString)

                            End If

                        Catch ex As Exception
                        End Try

                    Next

                End If

            Catch ex As Exception
            End Try

        End Sub
        Public Shared Sub RefreshAlertComments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer,
                                               ByVal UserCode As String, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, AssignmentPageUpdateType.Comments, "", UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub RefreshAlertChecklists(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, AssignmentPageUpdateType.Checklists, "", UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub RefreshAlertAssigneesAndCCs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal RemovedUserCode As String, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, AssignmentPageUpdateType.AssigneesAndCCs, RemovedUserCode, UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub RefreshAlertHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, AssignmentPageUpdateType.Hours, "", UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        Public Shared Sub RefreshAssignmentTab(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String, ByVal UpdateType As AssignmentPageUpdateType, ByVal UpdateUser As Boolean)

            Dim ThreadedDbContext = New AdvantageFramework.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)
            Dim SeparateThread = New Thread(Sub() _RefreshAssignmentTab(ThreadedDbContext, AlertID, UserCode, UpdateType, "", UpdateUser))

            Try

                SeparateThread.CurrentCulture = LoGlo.GetCultureInfo
                SeparateThread.CurrentUICulture = LoGlo.GetCultureInfo

            Catch ex As Exception
            End Try

            SeparateThread.Start()

        End Sub
        'Public Shared Sub _RefreshAlertComments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal UserCode As String)

        '    Try

        '        Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
        '        Dim Employee As AdvantageFramework.Database.Views.Employee
        '        Dim SprintIsActive As Boolean = False
        '        Dim SprintIsComplete As Boolean = False

        '        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, UserCode)

        '        If Employee IsNot Nothing Then

        '            Dim AlertUserCodes As New List(Of String)
        '            Dim OnlineUserCodes As New List(Of String)
        '            Dim SQL As String = String.Format("SELECT DISTINCT SU.USER_CODE FROM [dbo].[advtf_alert_recipient_get]({0}) AS AR INNER JOIN SEC_USER SU ON AR.EmployeeCode = SU.EMP_CODE WHERE NOT SU.WEB_ID IS NULL;", AlertID)
        '            Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing

        '            AlertUserCodes = DbContext.Database.SqlQuery(Of String)(SQL).ToList()
        '            OnlineUserCodes = GetUsersByWebID(DbContext)

        '            If AlertUserCodes.Contains(UserCode) = False Then

        '                AlertUserCodes.Add(UserCode)

        '            End If
        '            For Each OnlineUserCode As String In OnlineUserCodes

        '                If OnlineUserCode <> UserCode Then 'only refresh the actual alert page for everyone except user that triggered it

        '                    NotificationHubContext.Clients.User(OnlineUserCode).refreshAlertComments(AlertID, Employee.ToString)

        '                End If

        '            Next

        '        End If

        '    Catch ex As Exception
        '    End Try

        'End Sub

        Public Shared Sub _RefreshAssignmentTab(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal AlertID As Integer, ByVal UserCode As String,
                                                ByVal UpdateType As AssignmentPageUpdateType,
                                                ByVal RemovedUserCode As String,
                                                ByVal UpdateUser As Boolean)

            Try

                Dim NotificationHubContext = GlobalHost.ConnectionManager.GetHubContext(Of NotificationHub)()
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim SprintIsActive As Boolean = False
                Dim SprintIsComplete As Boolean = False

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, UserCode)

                If Employee IsNot Nothing Then

                    Dim AlertUserCodes As New List(Of String)
                    Dim OnlineUserCodes As New List(Of String)
                    Dim SQL As String = String.Format("SELECT DISTINCT SU.USER_CODE FROM [dbo].[advtf_alert_recipient_get]({0}) AS AR INNER JOIN SEC_USER SU ON AR.EmployeeCode = SU.EMP_CODE WHERE NOT SU.WEB_ID IS NULL;", AlertID)
                    Dim Sprint As AdvantageFramework.Database.Entities.SprintHeader = Nothing
                    Dim SprintID As Integer = 0
                    Dim ShowingChecklistsOnCards As Boolean = False

                    AlertUserCodes = DbContext.Database.SqlQuery(Of String)(SQL).ToList()
                    OnlineUserCodes = GetUsersByWebID(DbContext)

                    If AlertUserCodes.Contains(UserCode) = False Then

                        AlertUserCodes.Add(UserCode)

                    End If
                    If String.IsNullOrWhiteSpace(RemovedUserCode) = False AndAlso AlertUserCodes.Contains(RemovedUserCode) = False Then

                        AlertUserCodes.Add(RemovedUserCode)

                    End If
                    For Each OnlineUserCode As String In OnlineUserCodes

                        If AlertUserCodes.Contains(OnlineUserCode) = True Then

                            If OnlineUserCode <> UserCode OrElse UpdateUser = True Then 'only refresh the actual alert page for everyone except user that triggered it

                                Select Case UpdateType
                                    Case AssignmentPageUpdateType.Comments

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAlertComments(AlertID, Employee.ToString)

                                    Case AssignmentPageUpdateType.Checklists

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAlertChecklists(AlertID, Employee.ToString)

                                    Case AssignmentPageUpdateType.AssigneesAndCCs

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAlertAssigneesAndCCs(AlertID, Employee.ToString)

                                    Case AssignmentPageUpdateType.Hours

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAlertHours(AlertID, Employee.ToString)

                                    Case AssignmentPageUpdateType.Proofing

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAssignmentTab(AlertID, SprintID, Employee.ToString, CType(AssignmentPageUpdateType.Proofing, Integer))

                                    Case Else

                                        NotificationHubContext.Clients.User(OnlineUserCode).refreshAssignmentTab(AlertID, SprintID, Employee.ToString, CType(AssignmentPageUpdateType.Full, Integer))

                                End Select

                            End If

                            ShowingChecklistsOnCards = False

                            Try

                                ShowingChecklistsOnCards = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT TOP 1 CASE WHEN UPPER([VARIABLE_VALUE]) = 'TRUE' THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) " &
                                                                                                             " END FROM APP_VARS WITH(NOLOCK) WHERE [APPLICATION] = 'ALERT_VIEW' AND [VARIABLE_NAME] = " &
                                                                                                             " 'ShowChecklistsOnCards' AND [USERID] = '{0}';", OnlineUserCode)).SingleOrDefault

                            Catch ex As Exception
                                ShowingChecklistsOnCards = False
                            End Try

                            If ShowingChecklistsOnCards = True Then

                                NotificationHubContext.Clients.User(OnlineUserCode).refreshDashboardWorkItems()

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception
            End Try

        End Sub


#End Region

#Region " Helpers "

        Public Shared Function GetUsersBySprintID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintID As Integer, ByVal IncludeSelf As Boolean) As Generic.List(Of String)

            Dim UserCodes As Generic.List(Of String) = Nothing

            Try

                UserCodes = DbContext.Database.SqlQuery(Of String)(String.Format("[dbo].[advsp_agile_load_sprint_users] {0}, '{1}', {2}, {3};",
                                                                                 SprintID,
                                                                                 DbContext.UserCode,
                                                                                 If(IncludeSelf = True, "1", "0"),
                                                                                 "1")).ToList

            Catch ex As Exception
                UserCodes = Nothing
            End Try

            If UserCodes Is Nothing Then UserCodes = New List(Of String)

            GetUsersBySprintID = UserCodes

        End Function
        Public Shared Function GetUsersByWebID(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of String)

            Dim UserCodes As Generic.List(Of String) = Nothing

            Try

                UserCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DISTINCT USER_CODE FROM SEC_USER WHERE NOT WEB_ID IS NULL;")).ToList

            Catch ex As Exception
                UserCodes = Nothing
            End Try

            If UserCodes Is Nothing Then UserCodes = New List(Of String)

            GetUsersByWebID = UserCodes

        End Function
        Public Shared Function GetLastAssignedEmpCode() As String

            Return String.Empty

        End Function

#End Region

#End Region

    End Class

End Namespace
