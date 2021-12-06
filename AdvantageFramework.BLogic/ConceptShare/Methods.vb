Imports System.Threading

Namespace ConceptShare

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const ThumbnailHeight As Integer = 100
        Public Const ThumbnailWidth As Integer = 100
        Public Const CardThumbnailHeight As Integer = 50
        Public Const CardThumbnailWidth As Integer = 50
        Public Const ClientPortalRoleName As String = "Client Portal"

#End Region

#Region " Enum "

        Private Enum RoleCodes

            ACCOUNT_ADMINISTRATOR
            GENERAL_USER
            ACCOUNT_CP_USER

        End Enum
        Private Enum ProjectRoleCodes

            COMMENTATOR
            WORKSPACE_ADMINISTRATOR
            VIEW_ONLY
            PROJECT_CP_USER

        End Enum

        Private Enum AccountRolePermissions

            ACCOUNT_CALLBACK_MANAGE
            ACCOUNT_WORKFLOW_MANAGE
            PROJECT_CREATE
            PROJECT_DELETE
            PROJECT_VIEW_ALL
            RESOURCES_USERS_ADD
            RESOURCES_USERS_EDIT
            RESOURCES_USERS_CHANGE_PASSWORD
            RESOURCES_USERS_CHANGE_EMAIL
            RESOURCES_USERS_DELETE
            RESOURCES_TEAMS_ADD
            RESOURCES_TEAMS_EDIT
            RESOURCES_TEAMS_DELETE
            ACCOUNT_SETTINGS_MANAGE
            ACCOUNT_ROLES_MANAGE
            ACCOUNT_BRANDING_MANAGE
            ACCOUNT_STATUSES_MANAGE
            WORKFLOW_TEMPLATE_MANAGE
            PROJECT_TEMPLATE_MANAGE
            SMART_FOLDER_MANAGE
            SMART_FOLDER_ADD
            ACCOUNT_METAFORMS_MANAGE
            ACCOUNT_SAML_MANAGE
            FEED_POST
            ACCOUNT_USER_PREFERENCES_MANAGE
            ELECTRONIC_SIGNATURES_MANAGE

        End Enum
        Private Enum ProjectRolePermissions

            PROJECT_EDIT
            PROJECT_WORKFLOW_MANAGE
            PROJECT_MEMBERS_VIEW
            PROJECT_MEMBERS_MANAGE
            FOLDER_VIEW
            FOLDER_EDIT
            FOLDER_CONTENT_ADD
            FOLDER_DELETE
            ASSET_VIEW
            ASSET_EDIT
            ASSET_DELETE
            ASSET_DOWNLOAD
            ASSET_COMMENT_VIEW
            ASSET_COMMENT_ADD
            ASSET_COMMENT_EDIT
            ASSET_COMMENT_EDIT_ANY
            ASSET_COMMENT_DELETE
            ASSET_COMMENT_DELETE_ANY
            ASSET_COMMENT_REPLY_VIEW
            ASSET_COMMENT_REPLY_ADD
            ASSET_COMMENT_REPLY_EDIT
            ASSET_COMMENT_REPLY_EDIT_ANY
            TODO_ADD
            TODO_EDIT
            TODO_DELETE
            TODO_VIEW_ALL
            TASK_ADD
            TASK_EDIT
            TASK_DELETE
            TASK_VIEW_ALL
            REVIEW_ADD
            REVIEW_EDIT
            REVIEW_DELETE
            REVIEW_VIEW_ALL
            REVIEW_EDIT_ALL
            REVIEW_DELETE_ALL
            REVIEW_GLOBAL_APPROVE_REJECT
            FEED_POST

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Private Property AdminReviewRoleID As Integer? = Nothing

#End Region

#Region " Methods "

#Region " Application "

        Public Function UpdateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext, UserID As Integer, IsActive As Boolean) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Updated As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.User = Nothing

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    User = APIServiceClient.GetUserProfile(APIContext, UserID)

                    If User IsNot Nothing Then

                        Dim RoleID As Integer = 0
                        Dim ProjectRoleID As Integer = 0

                        RoleID = LoadAccountAdministratorRoleID(DataContext, APIServiceClient, APIContext)
                        ProjectRoleID = LoadWorkspaceAdministratorProjectRoleID(DataContext, APIServiceClient, APIContext)

                        If APIServiceClient.UpdateAccountUser(APIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID) IsNot Nothing Then

                            Updated = True

                        Else

                            Throw New Exception("Failed to update user in conceptshare.")

                        End If

                    Else

                        Throw New Exception("User is not found in conceptshare instance.")

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Updated

            UpdateConceptShareUser = APIReponse

        End Function
        Private Function UpdateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext, User As ConceptShareAPI.User, IsActive As Boolean) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                If User IsNot Nothing Then

                    Dim RoleID As Integer = 0
                    Dim ProjectRoleID As Integer = 0

                    RoleID = LoadAccountAdministratorRoleID(DataContext, APIServiceClient, APIContext)
                    ProjectRoleID = LoadWorkspaceAdministratorProjectRoleID(DataContext, APIServiceClient, APIContext)

                    If APIServiceClient.UpdateAccountUser(APIContext, User.UserId, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID) IsNot Nothing Then

                        Updated = True

                    Else

                        Throw New Exception("Failed to update user in conceptshare.")

                    End If

                Else

                    Throw New Exception("User is not found in conceptshare instance.")

                End If

            End If

            UpdateConceptShareUser = Updated

        End Function
        Public Sub SetEmployeesRoles(DataContext As AdvantageFramework.Database.DataContext)
            'objects
            Dim Updated As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                Dim RoleID As Integer = 0
                Dim ProjectRoleID As Integer = 0

                Dim AccountUsers As Generic.List(Of ConceptShareAPI.AccountUser)

                RoleID = LoadAccountAdministratorRoleID(DataContext, APIServiceClient, APIContext)
                ProjectRoleID = LoadWorkspaceAdministratorProjectRoleID(DataContext, APIServiceClient, APIContext)
                AccountUsers = Nothing

                AccountUsers = APIServiceClient.GetAccountUserList(APIContext).ToList

                If AccountUsers IsNot Nothing AndAlso AccountUsers.Count > 0 Then

                    For Each AccountUser As ConceptShareAPI.AccountUser In AccountUsers

                        APIServiceClient.UpdateAccountUser(APIContext, AccountUser.UserId, RoleID, ProjectRoleID, AccountUser.IsActive, AdminReviewRoleID)

                    Next

                End If

            End If

        End Sub

#Region "Client Portal Functions"

        Public Function CreateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
                                               FirstName As String, LastName As String,
                                               UserName As String, Password As String,
                                               IsActive As Boolean) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Created As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.AccountUser = Nothing
            Dim UserID As Integer = 0
            Dim RoleID As Integer = 0
            Dim ProjectRoleID As Integer = 0
            Dim HasClientPortalAccountRole As Boolean = False
            Dim HasClientPortalProjectRole As Boolean = False

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    Try

                        UserID = APIServiceClient.GetUserId(APIContext, UserName)

                    Catch ex As Exception
                        UserID = 0
                    End Try

                    If UserID = 0 Then

                        User = APIServiceClient.AddAccountUserNew(APIContext, UserName, FirstName, LastName, Nothing, Nothing, Nothing, Nothing, AdminReviewRoleID)

                        If User IsNot Nothing Then

                            UserID = User.UserId

                        End If

                    End If

                    If UserID > 0 Then

                        CheckForClientPortalRoles(DataContext, HasClientPortalAccountRole, HasClientPortalProjectRole, RoleID, ProjectRoleID)

                        If RoleID > 0 AndAlso ProjectRoleID > 0 Then

                            If APIServiceClient.GetAccountUserList(APIContext).Any(Function(CSEntity) CSEntity.UserId = UserID) = False Then

                                APIServiceClient.AddAccountUser(APIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID)

                            Else

                                APIServiceClient.UpdateAccountUser(APIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID)

                            End If

                            ChangeConceptShareUserPassword(APIServiceClient, APIContext, UserID, Password)

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.CP_USER SET CS_PASSWORD = '{0}', CS_USERID = {1} WHERE USER_GUID = '{2}'", AdvantageFramework.Security.Encryption.Encrypt(Password), UserID, ClientPortalUser.ID))
                            Created = True

                        End If

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Created

            CreateConceptShareUser = APIReponse

        End Function
        Public Function UpdateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
                                               UserID As Integer, FirstName As String, LastName As String,
                                               UserName As String, Password As String,
                                               IsActive As Boolean) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Updated As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.User = Nothing
            Dim HasClientPortalAccountRole As Boolean = False
            Dim HasClientPortalProjectRole As Boolean = False

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateUserConecptShareConnection(DataContext, SecurityDbContext, ClientPortalUser, APIServiceClient, APIContext, User) Then

                    User = APIServiceClient.UpdateMyProfile(APIContext, FirstName, LastName, User.Username, User.LdapName, Password, 15, 1)

                    If User IsNot Nothing Then

                        If ChangeConceptShareUserPassword(APIServiceClient, APIContext, UserID, Password) Then

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.CP_USER SET CS_PASSWORD = '{0}', CS_USERID = {1} WHERE USER_GUID = '{2}'", AdvantageFramework.Security.Encryption.Encrypt(Password), User.UserId, ClientPortalUser.ID))
                            Updated = True

                        End If

                        Dim AdminAPIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
                        Dim AdminAPIContext As ConceptShareAPI.APIContext = Nothing
                        Dim RoleID As Integer = 0
                        Dim ProjectRoleID As Integer = 0

                        CheckForClientPortalRoles(DataContext, HasClientPortalAccountRole, HasClientPortalProjectRole, RoleID, ProjectRoleID)

                        If RoleID > 0 AndAlso ProjectRoleID > 0 Then

                            If CreateSystemAccountConecptShareConnection(DataContext, AdminAPIServiceClient, AdminAPIContext) Then

                                AdminAPIServiceClient.UpdateAccountUser(AdminAPIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID)

                            End If

                        End If

                    Else

                        Throw New Exception("User is not found in conceptshare instance.")

                    End If

                End If

                If Updated Then

                    Updated = UpdateConceptShareUser(DataContext, User, IsActive)

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Updated

            UpdateConceptShareUser = APIReponse

        End Function
        Public Function RemoveConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Removed As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    If APIServiceClient.GetAccountUserList(APIContext).Any(Function(CSEntity) CSEntity.UserId = ClientPortalUser.ConceptShareUserID) Then

                        If APIServiceClient.RemoveAccountUser(APIContext, ClientPortalUser.ConceptShareUserID) IsNot Nothing Then

                            Try

                                DataContext.ExecuteCommand(String.Format("DELETE CP_ALERT_RCPT FROM CP_ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN CP_USER E ON AR.CDP_CONTACT_ID = E.CDP_CONTACT_ID WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE CP_ALERT_RCPT_DISMISSED FROM CP_ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN CP_USER E ON AR.CDP_CONTACT_ID = E.CDP_CONTACT_ID WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", ClientPortalUser.ConceptShareUserID))

                            Catch ex As Exception
                            End Try

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.CP_USER SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE USER_GUID = '{0}'", ClientPortalUser.ID))
                            Removed = True

                        End If

                    Else

                        Try

                            DataContext.ExecuteCommand(String.Format("DELETE CP_ALERT_RCPT FROM CP_ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN CP_USER E ON AR.CDP_CONTACT_ID = E.CDP_CONTACT_ID WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE CP_ALERT_RCPT_DISMISSED FROM CP_ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN CP_USER E ON AR.CDP_CONTACT_ID = E.CDP_CONTACT_ID WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", ClientPortalUser.ConceptShareUserID))

                        Catch ex As Exception
                        End Try

                        DataContext.ExecuteCommand(String.Format("UPDATE dbo.CP_USER SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE USER_GUID = '{0}'", ClientPortalUser.ID))
                        Removed = True

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Removed

            RemoveConceptShareUser = APIReponse

        End Function
        Public Function CreateUserConecptShareConnection(DataContext As AdvantageFramework.Database.DataContext,
                                                         SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                          ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
                                                          ByRef APIServiceClient As ConceptShareAPI.APIServiceClient,
                                                          ByRef APIContext As ConceptShareAPI.APIContext,
                                                          ByRef User As ConceptShareAPI.User) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim URL As String = ""
            Dim PartnerKey As String = ""
            Dim PartnerPassword As String = ""

            APIServiceClient = Nothing
            APIContext = Nothing

            If IsConceptShareEnabled(DataContext) Then

                If LoadURL(DataContext, URL) AndAlso String.IsNullOrWhiteSpace(URL) = False Then

                    Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact

                    ClientContact = Nothing
                    ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, ClientPortalUser.ClientContactID)

                    If ClientContact IsNot Nothing Then

                        If (String.IsNullOrWhiteSpace(ClientContact.EmailAddress) = False AndAlso String.IsNullOrWhiteSpace(ClientPortalUser.ConceptSharePassword) = False) Then

                            If LoadPartnerKeyAndPassword(DataContext, PartnerKey, PartnerPassword) AndAlso
                                (String.IsNullOrWhiteSpace(PartnerKey) = False AndAlso String.IsNullOrWhiteSpace(PartnerPassword) = False) Then

                                APIServiceClient = CreateAPIServiceClient(URL)

                                User = APIServiceClient.Authorize(ClientContact.EmailAddress, AdvantageFramework.Security.Encryption.Decrypt(ClientPortalUser.ConceptSharePassword))

                                If User IsNot Nothing Then

                                    APIContext = New ConceptShareAPI.APIContext

                                    APIContext.PartnerPassword = PartnerPassword
                                    APIContext.PartnerToken = PartnerKey
                                    APIContext.UserToken = User.ApiToken

                                    Created = True

                                End If

                            End If

                        End If

                    End If

                End If

            End If

            CreateUserConecptShareConnection = Created

        End Function

#End Region

#Region "Employee Functions"

        Public Function CreateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               EmployeeCode As String,
                                               FirstName As String, LastName As String,
                                               UserName As String, Password As String,
                                               IsActive As Boolean) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Created As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.AccountUser = Nothing
            Dim UserID As Integer = 0
            Dim RoleID As Integer = 0
            Dim ProjectRoleID As Integer = 0

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    Try

                        UserID = APIServiceClient.GetUserId(APIContext, UserName)

                    Catch ex As Exception
                        UserID = 0
                    End Try

                    If UserID = 0 Then

                        'User = APIServiceClient.AddUser(APIContext, IsActive, FirstName, LastName, UserName, Password, 15, 1)
                        User = APIServiceClient.AddAccountUserNew(APIContext, UserName, FirstName, LastName, Nothing, Nothing, Nothing, Nothing, AdminReviewRoleID)

                        If User IsNot Nothing Then

                            UserID = User.UserId

                        End If

                    End If

                    If UserID > 0 Then

                        RoleID = LoadAccountAdministratorRoleID(DataContext, APIServiceClient, APIContext)
                        ProjectRoleID = LoadWorkspaceAdministratorProjectRoleID(DataContext, APIServiceClient, APIContext)

                        If APIServiceClient.GetAccountUserList(APIContext).Any(Function(CSEntity) CSEntity.UserId = UserID) = False Then

                            APIServiceClient.AddAccountUser(APIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID)

                        Else

                            APIServiceClient.UpdateAccountUser(APIContext, UserID, RoleID, ProjectRoleID, IsActive, AdminReviewRoleID)

                        End If

                        ChangeConceptShareUserPassword(APIServiceClient, APIContext, UserID, Password)

                        DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = '{0}', CS_USERID = {1} WHERE EMP_CODE = '{2}'", AdvantageFramework.Security.Encryption.Encrypt(Password), UserID, EmployeeCode))
                        Created = True

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Created

            CreateConceptShareUser = APIReponse

        End Function
        Public Function UpdateConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               Employee As AdvantageFramework.Database.Views.Employee,
                                               UserID As Integer, FirstName As String, LastName As String,
                                               UserName As String, Password As String, IsActive As Boolean) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Updated As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.User = Nothing

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateUserConecptShareConnection(DataContext, Employee, APIServiceClient, APIContext, User) Then

                    User = APIServiceClient.UpdateMyProfile(APIContext, FirstName, LastName, User.Username, User.LdapName, Password, 15, 1)

                    If User IsNot Nothing Then

                        If ChangeConceptShareUserPassword(APIServiceClient, APIContext, UserID, Password) Then

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = '{0}', CS_USERID = {1} WHERE EMP_CODE = '{2}'", AdvantageFramework.Security.Encryption.Encrypt(Password), User.UserId, Employee.Code))
                            Updated = True

                        End If

                    Else

                        Throw New Exception("User is not found in conceptshare instance.")

                    End If

                End If

                If Updated Then

                    Updated = UpdateConceptShareUser(DataContext, User, IsActive)

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Updated

            UpdateConceptShareUser = APIReponse

        End Function
        Public Function RemoveConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               Employee As AdvantageFramework.Database.Views.Employee) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Removed As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    If APIServiceClient.GetAccountUserList(APIContext).Any(Function(CSEntity) CSEntity.UserId = Employee.ConceptShareUserID) Then

                        If APIServiceClient.RemoveAccountUser(APIContext, Employee.ConceptShareUserID) IsNot Nothing Then

                            Try

                                DataContext.ExecuteCommand(String.Format("DELETE ALERT_RCPT FROM ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE ALERT_RCPT_DISMISSED FROM ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", Employee.ConceptShareUserID))

                            Catch ex As Exception
                            End Try

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE EMP_CODE = '{0}'", Employee.Code))
                            Removed = True

                        End If

                    Else

                        Try

                            DataContext.ExecuteCommand(String.Format("DELETE ALERT_RCPT FROM ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE ALERT_RCPT_DISMISSED FROM ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", Employee.ConceptShareUserID))

                        Catch ex As Exception
                        End Try

                        DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE EMP_CODE = '{0}'", Employee.Code))
                        Removed = True

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Removed

            RemoveConceptShareUser = APIReponse

        End Function
        Public Function RemoveConceptShareUser(DataContext As AdvantageFramework.Database.DataContext,
                                               EmployeeCode As String, ConceptShareUserID As Integer) As AdvantageFramework.ConceptShare.Classes.APIResponse

            'objects
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim Removed As Boolean = False
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            APIReponse = New AdvantageFramework.ConceptShare.Classes.APIResponse

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    If APIServiceClient.GetAccountUserList(APIContext).Any(Function(CSEntity) CSEntity.UserId = ConceptShareUserID) Then

                        If APIServiceClient.RemoveAccountUser(APIContext, ConceptShareUserID) IsNot Nothing Then

                            Try

                                DataContext.ExecuteCommand(String.Format("DELETE ALERT_RCPT FROM ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE ALERT_RCPT_DISMISSED FROM ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", ConceptShareUserID))

                            Catch ex As Exception
                            End Try

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE EMP_CODE = '{0}'", EmployeeCode))
                            Removed = True

                        End If

                    Else

                        Try

                            DataContext.ExecuteCommand(String.Format("DELETE ALERT_RCPT FROM ALERT_RCPT AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};DELETE ALERT_RCPT_DISMISSED FROM ALERT_RCPT_DISMISSED AR INNER JOIN ALERT A ON AR.ALERT_ID = A.ALERT_ID INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE A.IS_CS_REVIEW = 1 AND E.CS_USERID = {0};", ConceptShareUserID))

                        Catch ex As Exception
                        End Try

                        DataContext.ExecuteCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = NULL, CS_USERID = NULL WHERE EMP_CODE = '{0}'", EmployeeCode))
                        Removed = True

                    End If

                End If

            Catch ex As System.ServiceModel.FaultException
                APIReponse.ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
            Catch ex As Exception
                APIReponse.ErrorMessage = ex.Message
            End Try

            APIReponse.CompletedSuccessfully = Removed

            RemoveConceptShareUser = APIReponse

        End Function
        Public Function CreateUserConecptShareConnection(DataContext As AdvantageFramework.Database.DataContext,
                                                         Employee As AdvantageFramework.Database.Views.Employee,
                                                         ByRef APIServiceClient As ConceptShareAPI.APIServiceClient,
                                                         ByRef APIContext As ConceptShareAPI.APIContext,
                                                         ByRef User As ConceptShareAPI.User) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim URL As String = ""
            Dim PartnerKey As String = ""
            Dim PartnerPassword As String = ""

            APIServiceClient = Nothing
            APIContext = Nothing

            If IsConceptShareEnabled(DataContext) Then

                If LoadURL(DataContext, URL) AndAlso String.IsNullOrWhiteSpace(URL) = False Then

                    If (String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso String.IsNullOrWhiteSpace(Employee.ConceptSharePassword) = False) Then

                        If LoadPartnerKeyAndPassword(DataContext, PartnerKey, PartnerPassword) AndAlso
                                (String.IsNullOrWhiteSpace(PartnerKey) = False AndAlso String.IsNullOrWhiteSpace(PartnerPassword) = False) Then

                            APIServiceClient = CreateAPIServiceClient(URL)

                            User = APIServiceClient.Authorize(Employee.Email, AdvantageFramework.Security.Encryption.Decrypt(Employee.ConceptSharePassword))

                            If User IsNot Nothing Then

                                APIContext = New ConceptShareAPI.APIContext

                                APIContext.PartnerPassword = PartnerPassword
                                APIContext.PartnerToken = PartnerKey
                                APIContext.UserToken = User.ApiToken

                                Created = True

                            End If

                        End If

                    End If

                End If

            End If

            CreateUserConecptShareConnection = Created

        End Function

#End Region

#Region " Roles "

        Public Function LoadAccountRoles(DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of ConceptShareAPI.Role)

            Dim AccountRoles As Generic.List(Of ConceptShareAPI.Role) = Nothing
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                AccountRoles = APIServiceClient.GetAccountRoleList(APIContext).ToList

            End If

            Return AccountRoles

        End Function
        Public Function LoadProjectRoles(DataContext As AdvantageFramework.Database.DataContext) As Generic.List(Of ConceptShareAPI.Role)

            Dim ProjectRoles As Generic.List(Of ConceptShareAPI.Role) = Nothing
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                ProjectRoles = APIServiceClient.GetProjectRoleList(APIContext).ToList

            End If

            Return ProjectRoles

        End Function
        Public Function LoadClientPortalPermissions(DataContext As AdvantageFramework.Database.DataContext, Type As Integer) As Generic.List(Of ConceptShareAPI.RolePermission)

            Dim RolePermissions As Generic.List(Of ConceptShareAPI.RolePermission) = Nothing
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim RoleID As Integer = 0
            Dim ProjectRoleID As Integer = 0

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                Select Case Type
                    Case 1

                        RoleID = LoadClientPortalUserRoleID(DataContext, APIServiceClient, APIContext)
                        RolePermissions = APIServiceClient.GetAccountRolePermissionList(APIContext, RoleID).ToList

                    Case 2

                        ProjectRoleID = LoadClientPortalUserProjectRoleID(DataContext, APIServiceClient, APIContext)
                        RolePermissions = APIServiceClient.GetProjectRolePermissionList(APIContext, ProjectRoleID).ToList

                End Select

            End If

            Return RolePermissions

        End Function

        Private Sub CheckForClientPortalRoles(DataContext As AdvantageFramework.Database.DataContext,
                                             ByRef HasClientPortalAccountRole As Boolean,
                                             ByRef HasClientPortalProjectRole As Boolean,
                                             ByRef ClientPortalAccountRoleID As Integer,
                                             ByRef ClientPortalProjectRoleID As Integer)

            HasClientPortalAccountRole = False
            HasClientPortalProjectRole = False
            ClientPortalAccountRoleID = 0
            ClientPortalProjectRoleID = 0

            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                Try

                    ClientPortalAccountRoleID = LoadClientPortalUserRoleID(DataContext, APIServiceClient, APIContext)

                Catch ex As Exception
                    ClientPortalAccountRoleID = 0
                End Try
                Try

                    ClientPortalProjectRoleID = LoadClientPortalUserProjectRoleID(DataContext, APIServiceClient, APIContext)

                Catch ex As Exception
                    ClientPortalProjectRoleID = 0
                End Try

                HasClientPortalAccountRole = ClientPortalAccountRoleID > 0
                HasClientPortalProjectRole = ClientPortalProjectRoleID > 0

                If HasClientPortalAccountRole = False Then

                    Dim ClientPortalAccountRole As AdvantageFramework.ConceptShareAPI.Role

                    ClientPortalAccountRole = Nothing

                    Try

                        ClientPortalAccountRole = APIServiceClient.AddAccountRole(APIContext, ClientPortalRoleName, RoleCodes.ACCOUNT_CP_USER.ToString())

                    Catch ex As Exception
                        ClientPortalAccountRole = Nothing
                    End Try

                    If ClientPortalAccountRole IsNot Nothing Then

                        ClientPortalAccountRoleID = ClientPortalAccountRole.Id

                        If ClientPortalAccountRoleID > 0 Then

                            HasClientPortalAccountRole = True

                            Dim AccountRolePermissionsList As Generic.List(Of ConceptShareAPI.RolePermission) = Nothing
                            Dim AccountRoleID As Integer = 0

                            Try

                                AccountRoleID = LoadAccountAdministratorRoleID(DataContext, APIServiceClient, APIContext)

                            Catch ex As Exception
                                AccountRoleID = 0
                            End Try

                            If AccountRoleID > 0 Then

                                Try

                                    AccountRolePermissionsList = APIServiceClient.GetAccountRolePermissionList(APIContext, AccountRoleID).ToList

                                Catch ex As Exception
                                    AccountRolePermissionsList = Nothing
                                End Try

                                If AccountRolePermissionsList IsNot Nothing AndAlso AccountRolePermissionsList.Count > 0 Then

                                    'Add permissions
                                    Dim RolePermission As AdvantageFramework.ConceptShareAPI.RolePermission = Nothing
                                    Dim RolePermissionID As Integer = 0


                                    'Grants the role the ability to view ALL projects
                                    Try

                                        RolePermissionID = (From Entity In AccountRolePermissionsList
                                                            Where Entity.Code = AccountRolePermissions.PROJECT_VIEW_ALL.ToString
                                                            Select Entity.Id).FirstOrDefault

                                    Catch ex As Exception
                                        RolePermissionID = 0
                                    End Try
                                    If RolePermissionID > 0 Then

                                        RolePermission = APIServiceClient.AddAccountRolePermission(APIContext, ClientPortalAccountRoleID, RolePermissionID)

                                    End If
                                    RolePermission = Nothing
                                    RolePermissionID = 0

                                    'Grants the role the ability to post/comment on a feed.
                                    Try

                                        RolePermissionID = (From Entity In AccountRolePermissionsList
                                                            Where Entity.Code = AccountRolePermissions.FEED_POST.ToString
                                                            Select Entity.Id).FirstOrDefault

                                    Catch ex As Exception
                                        RolePermissionID = 0
                                    End Try
                                    If RolePermissionID > 0 Then

                                        RolePermission = APIServiceClient.AddAccountRolePermission(APIContext, ClientPortalAccountRoleID, RolePermissionID)

                                    End If
                                    RolePermission = Nothing
                                    RolePermissionID = 0

                                End If

                            End If

                        End If

                    End If

                End If
                If HasClientPortalProjectRole = False Then

                    Dim ClientPortalProjectRole As AdvantageFramework.ConceptShareAPI.Role

                    ClientPortalProjectRole = Nothing
                    ClientPortalProjectRole = APIServiceClient.AddProjectRole(APIContext, ClientPortalRoleName, ProjectRoleCodes.PROJECT_CP_USER.ToString())

                    If ClientPortalProjectRole IsNot Nothing Then

                        ClientPortalProjectRoleID = ClientPortalProjectRole.Id

                        If ClientPortalProjectRoleID > 0 Then

                            HasClientPortalProjectRole = True

                            Dim ProjectRolePermissionsList As Generic.List(Of ConceptShareAPI.RolePermission) = Nothing
                            Dim ProjectRoleID As Integer = 0

                            Try

                                ProjectRoleID = LoadWorkspaceAdministratorProjectRoleID(DataContext, APIServiceClient, APIContext)

                            Catch ex As Exception
                                ProjectRoleID = 0
                            End Try

                            If ProjectRoleID > 0 Then

                                Try

                                    ProjectRolePermissionsList = APIServiceClient.GetProjectRolePermissionList(APIContext, ProjectRoleID).ToList

                                Catch ex As Exception
                                    ProjectRolePermissionsList = Nothing
                                End Try

                                If ProjectRolePermissionsList IsNot Nothing AndAlso ProjectRolePermissionsList.Count > 0 Then

                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.PROJECT_EDIT)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.PROJECT_MEMBERS_VIEW)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.FOLDER_VIEW)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_VIEW)

                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_VIEW)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_ADD)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_EDIT)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_DELETE)

                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_REPLY_VIEW)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_REPLY_ADD)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.ASSET_COMMENT_REPLY_EDIT)

                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.TODO_VIEW_ALL)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.TASK_VIEW_ALL)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.REVIEW_VIEW_ALL)
                                    AddPermissionToProjectRole(APIServiceClient, APIContext, ClientPortalProjectRoleID, ProjectRolePermissionsList, ProjectRolePermissions.FEED_POST)

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub AddPermissionToProjectRole(ByRef APIServiceClient As ConceptShareAPI.APIServiceClient,
                                               ByRef APIContext As ConceptShareAPI.APIContext,
                                               ByVal ClientPortalProjectRoleID As Integer,
                                               ByRef ProjectRolePermissionsList As Generic.List(Of ConceptShareAPI.RolePermission),
                                               ByVal ProjectRolePermission As ProjectRolePermissions)

            Dim RolePermission As AdvantageFramework.ConceptShareAPI.RolePermission = Nothing
            Dim RolePermissionID As Integer = 0

            'Grants the role the ability to view comment replies on the asset.
            Try

                RolePermissionID = (From Entity In ProjectRolePermissionsList
                                    Where Entity.Code = ProjectRolePermission.ToString
                                    Select Entity.Id).FirstOrDefault

            Catch ex As Exception
                RolePermissionID = 0
            End Try
            If RolePermissionID > 0 Then

                RolePermission = APIServiceClient.AddProjectRolePermission(APIContext, ClientPortalProjectRoleID, RolePermissionID)

            End If
            RolePermission = Nothing
            RolePermissionID = 0

        End Sub
#End Region

        Private Function CreateAPIServiceClient(URL As String) As AdvantageFramework.ConceptShareAPI.APIServiceClient

            'objects
            Dim APIServiceClient As AdvantageFramework.ConceptShareAPI.APIServiceClient = Nothing
            Dim BasicHttpBinding As System.ServiceModel.BasicHttpBinding = Nothing
            Dim EndpointAddress As System.ServiceModel.EndpointAddress = Nothing

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

            BasicHttpBinding = New System.ServiceModel.BasicHttpBinding

            BasicHttpBinding.Security.Mode = ServiceModel.SecurityMode.Transport
            BasicHttpBinding.Security.Transport.ClientCredentialType = ServiceModel.HttpClientCredentialType.None
            BasicHttpBinding.SendTimeout = New TimeSpan(0, 5, 0)
            BasicHttpBinding.MaxBufferPoolSize = 2147483647
            BasicHttpBinding.MaxBufferSize = 2147483647
            BasicHttpBinding.MaxReceivedMessageSize = 2147483647

            EndpointAddress = New System.ServiceModel.EndpointAddress(URL)

            APIServiceClient = New AdvantageFramework.ConceptShareAPI.APIServiceClient(BasicHttpBinding, EndpointAddress)

            CreateAPIServiceClient = APIServiceClient

        End Function
        Public Function CreateSystemAccountConecptShareConnection(DataContext As AdvantageFramework.Database.DataContext,
                                                                   ByRef APIServiceClient As ConceptShareAPI.APIServiceClient,
                                                                   ByRef APIContext As ConceptShareAPI.APIContext) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim URL As String = ""
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim PartnerKey As String = ""
            Dim PartnerPassword As String = ""
            Dim User As ConceptShareAPI.User = Nothing

            APIServiceClient = Nothing
            APIContext = Nothing

            If IsConceptShareEnabled(DataContext) Then

                If LoadURL(DataContext, URL) AndAlso String.IsNullOrWhiteSpace(URL) = False Then

                    If LoadSystemAccountUserNameAndPassword(DataContext, UserName, Password) AndAlso
                            (String.IsNullOrWhiteSpace(UserName) = False AndAlso String.IsNullOrWhiteSpace(Password) = False) Then

                        If LoadPartnerKeyAndPassword(DataContext, PartnerKey, PartnerPassword) AndAlso
                                (String.IsNullOrWhiteSpace(PartnerKey) = False AndAlso String.IsNullOrWhiteSpace(PartnerPassword) = False) Then

                            APIServiceClient = CreateAPIServiceClient(URL)

                            User = APIServiceClient.Authorize(UserName, Password)

                            If User IsNot Nothing Then

                                APIContext = New ConceptShareAPI.APIContext

                                APIContext.PartnerPassword = PartnerPassword
                                APIContext.PartnerToken = PartnerKey
                                APIContext.UserToken = User.ApiToken

                                Created = True

                            End If

                        End If

                    End If

                End If

            End If

            CreateSystemAccountConecptShareConnection = Created

        End Function
        Public Function IsConceptShareEnabled(DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim ConceptShareIsEnabled As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_ENABLED.ToString)

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) AndAlso Setting.Value = 1 Then

                    ConceptShareIsEnabled = True

                End If

            End If

            IsConceptShareEnabled = ConceptShareIsEnabled

        End Function
        Public Function IsConceptShareEnabled(Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim ConceptShareIsEnabled As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ConceptShareIsEnabled = IsConceptShareEnabled(DataContext)

            End Using

            IsConceptShareEnabled = ConceptShareIsEnabled

        End Function
        Public Function LoadURL(DataContext As AdvantageFramework.Database.DataContext, ByRef URL As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim URLSetting As AdvantageFramework.Database.Entities.Setting = Nothing

            URLSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_URL.ToString)

            If URLSetting IsNot Nothing Then

                URL = URLSetting.Value

            Else

                Loaded = False

            End If

            LoadURL = Loaded

        End Function
        Public Function LoadSystemAccountUserNameAndPassword(DataContext As AdvantageFramework.Database.DataContext, ByRef UserName As String, ByRef Password As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim UserNameSetting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PasswordSetting As AdvantageFramework.Database.Entities.Setting = Nothing

            UserNameSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_SA_USERNAME.ToString)

            If UserNameSetting IsNot Nothing Then

                UserName = UserNameSetting.Value

            Else

                Loaded = False

            End If

            PasswordSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_SA_PASSWORD.ToString)

            If PasswordSetting IsNot Nothing Then

                Password = PasswordSetting.Value

            Else

                Loaded = False

            End If

            LoadSystemAccountUserNameAndPassword = Loaded

        End Function
        Public Function LoadPartnerKeyAndPassword(DataContext As AdvantageFramework.Database.DataContext, ByRef PartnerKey As String, ByRef PartnerPassword As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim PartnerKeySetting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PartnerPasswordSetting As AdvantageFramework.Database.Entities.Setting = Nothing

            PartnerKeySetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_PARTNER_KEY.ToString)

            If PartnerKeySetting IsNot Nothing Then

                PartnerKey = PartnerKeySetting.Value

            Else

                Loaded = False

            End If

            PartnerPasswordSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CS_PARTNER_PW.ToString)

            If PartnerPasswordSetting IsNot Nothing Then

                PartnerPassword = PartnerPasswordSetting.Value

            Else

                Loaded = False

            End If

            LoadPartnerKeyAndPassword = Loaded

        End Function
        Private Function ChangeConceptShareUserPassword(APIServiceClient As ConceptShareAPI.APIServiceClient,
                                                        APIContext As ConceptShareAPI.APIContext,
                                                        ConceptShareUserID As Integer,
                                                        Password As String) As Boolean

            'objects
            Dim PasswordChanged As Boolean = False

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing AndAlso ConceptShareUserID > 0 Then

                If APIServiceClient.ChangeAccountUserPassword(APIContext, ConceptShareUserID, Password) Then

                    PasswordChanged = True

                End If

            End If

            ChangeConceptShareUserPassword = PasswordChanged

        End Function
        Private Function LoadGeneralUserRoleID(DataContext As AdvantageFramework.Database.DataContext,
                                               APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim GeneralUserRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    GeneralUserRoleID = LoadRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(Role) Role.Code = RoleCodes.GENERAL_USER.ToString).Id

                Catch ex As Exception
                    GeneralUserRoleID = 0
                End Try

            End If

            LoadGeneralUserRoleID = GeneralUserRoleID

        End Function
        Private Function LoadClientPortalUserRoleID(DataContext As AdvantageFramework.Database.DataContext,
                                                    APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim ClientPortalUserRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    ClientPortalUserRoleID = LoadRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(Role) Role.Code = RoleCodes.ACCOUNT_CP_USER.ToString).Id

                Catch ex As Exception
                    ClientPortalUserRoleID = 0
                End Try

                If ClientPortalUserRoleID = 0 Then

                    APIServiceClient.AddAccountRole(APIContext, "Client Portal User", RoleCodes.ACCOUNT_CP_USER.ToString)

                End If

            End If

            LoadClientPortalUserRoleID = ClientPortalUserRoleID

        End Function
        Private Function LoadCommentatorProjectRoleID(DataContext As AdvantageFramework.Database.DataContext,
                                                           APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim CommentatorProjectRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    CommentatorProjectRoleID = LoadProjectRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(ProjectRole) ProjectRole.Code = ProjectRoleCodes.COMMENTATOR.ToString).Id

                Catch ex As Exception
                    CommentatorProjectRoleID = 0
                End Try

            End If

            LoadCommentatorProjectRoleID = CommentatorProjectRoleID

        End Function

        Private Function LoadClientPortalUserProjectRoleID(DataContext As AdvantageFramework.Database.DataContext,
                                                           APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim ClientPortalUserProjectRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    ClientPortalUserProjectRoleID = LoadProjectRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(ProjectRole) ProjectRole.Code = ProjectRoleCodes.PROJECT_CP_USER.ToString).Id

                Catch ex As Exception
                    ClientPortalUserProjectRoleID = 0
                End Try

            End If

            LoadClientPortalUserProjectRoleID = ClientPortalUserProjectRoleID

        End Function
        Public Function LoadAllProjectRoles(DataContext As AdvantageFramework.Database.DataContext,
                                            ByRef ErrorMessage As String) As Generic.List(Of ConceptShareAPI.Role)

            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim AccountHasProjectRole As Boolean = False
            Dim RolesList As Generic.List(Of ConceptShareAPI.Role)

            ErrorMessage = String.Empty
            RolesList = Nothing

            Try

                If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                    RolesList = APIServiceClient.GetProjectRoleList(APIContext).ToList

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                AccountHasProjectRole = False
            End Try

            Return RolesList

        End Function

#End Region

#Region " Agency Account "

        Public Function LoadUploadParameters(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                             ByRef ErrorMessage As String) As Generic.List(Of String)

            Try

                Return ConceptShareConnection.APIServiceClient.GetKnownAssetUploadParameters(ConceptShareConnection.APIContext).ToList

            Catch ex As Exception
                Return New Generic.List(Of String)
            End Try

        End Function

#End Region
#Region " User "

        'Public Function RemoveAccountUser(DataContext As AdvantageFramework.Database.DataContext, UserID As Integer) As ConceptShareAPI.AccountUser

        '    'objects
        '    Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
        '    Dim APIContext As ConceptShareAPI.APIContext = Nothing

        '    If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

        '        RemoveAccountUser = APIServiceClient.RemoveAccountUser(APIContext, UserID)

        '    Else

        '        RemoveAccountUser = Nothing

        '    End If

        'End Function
        Public Function LoadUser(DataContext As AdvantageFramework.Database.DataContext,
                                 SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                 ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser, ByRef User As ConceptShareAPI.User) As ConceptShareAPI.AccountUser

            'objects
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateUserConecptShareConnection(DataContext, SecurityDbContext, ClientPortalUser, APIServiceClient, APIContext, User) Then

                LoadUser = APIServiceClient.GetAccountUserList(APIContext).ToList.SingleOrDefault(Function(AU) AU.UserId = ClientPortalUser.ConceptShareUserID)

            Else

                LoadUser = Nothing

            End If

        End Function
        Public Function LoadUser(DataContext As AdvantageFramework.Database.DataContext, Employee As Database.Views.Employee, ByRef User As ConceptShareAPI.User) As ConceptShareAPI.AccountUser

            'objects
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing

            If CreateUserConecptShareConnection(DataContext, Employee, APIServiceClient, APIContext, User) Then

                LoadUser = APIServiceClient.GetAccountUserList(APIContext).ToList.SingleOrDefault(Function(AU) AU.UserId = Employee.ConceptShareUserID)

            Else

                LoadUser = Nothing

            End If

        End Function
        Public Function LoadUsers(DataContext As AdvantageFramework.Database.DataContext, Employee As Database.Views.Employee) As Generic.List(Of ConceptShareAPI.AccountUser)

            'objects
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim User As ConceptShareAPI.User = Nothing

            If CreateUserConecptShareConnection(DataContext, Employee, APIServiceClient, APIContext, User) Then

                LoadUsers = APIServiceClient.GetAccountUserList(APIContext).ToList

            Else

                LoadUsers = New List(Of ConceptShareAPI.AccountUser)

            End If

        End Function
        Public Function LoadEmployeeCodeByConceptShareUserID(DataContext As AdvantageFramework.Database.DataContext, ConceptShareUserID As Integer) As String

            Try

                LoadEmployeeCodeByConceptShareUserID = DataContext.ExecuteQuery(Of String)(String.Format("SELECT EMP_CODE FROM EMPLOYEE WITH(NOLOCK) WHERE CS_USERID = {0};", ConceptShareUserID)).FirstOrDefault

            Catch ex As Exception
                LoadEmployeeCodeByConceptShareUserID = String.Empty
            End Try

        End Function
        Public Function LoadClientContactIDByConceptShareUserID(DataContext As AdvantageFramework.Database.DataContext, ConceptShareUserID As Integer) As Integer

            Try

                LoadClientContactIDByConceptShareUserID = DataContext.ExecuteQuery(Of String)(String.Format("SELECT CDP_CONTACT_ID FROM CP_USER WITH(NOLOCK) WHERE CS_USERID = {0};", ConceptShareUserID)).FirstOrDefault

            Catch ex As Exception
                LoadClientContactIDByConceptShareUserID = 0
            End Try

        End Function

#End Region

#Region " Project "

        Public Function LoadProjectByJobAndComponentNumber(DataContext As AdvantageFramework.Database.DataContext, ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                           JobNumber As Integer, JobComponentNumber As Short, CreateProjectIfNotExists As Boolean) As ConceptShareAPI.Project

            Dim Project As ConceptShareAPI.Project
            Dim ProjectID As Integer = 0

            Project = Nothing

            Try

                ProjectID = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT ISNULL(CS_PROJECT_ID, 0) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};",
                                                                               JobNumber, JobComponentNumber)).FirstOrDefault

            Catch ex As Exception
                ProjectID = 0
            End Try

            If ConceptShareConnection.Loaded Then

                If ProjectID > 0 Then

                    Try

                        Project = ConceptShareConnection.APIServiceClient.GetProjectProfile(ConceptShareConnection.APIContext, ProjectID)

                    Catch ex As Exception
                        Project = Nothing
                    End Try

                Else

                    If CreateProjectIfNotExists = True Then

                        Dim Info As New AdvantageFramework.AlertSystem.Classes.BasicJobInfo(DataContext.Connection.ConnectionString, JobNumber, JobComponentNumber)
                        Dim Text As String = String.Format("Reviews for job: {0}, {1}", JobNumber.ToString, JobComponentNumber.ToString)

                        If Info IsNot Nothing AndAlso Info.HasData = True Then

                            Dim AutoTags() As String = {JobNumber.ToString & "/" & JobComponentNumber.ToString, Info.ClientName, Info.DivisionName, Info.ProductDescription, Info.ClientCode, Info.DivisionCode, Info.ProductCode, Info.JobAndComponentDescription}
                            Text = Info.JobAndComponentDescription

                            Project = ConceptShareConnection.APIServiceClient.AddProject(ConceptShareConnection.APIContext, ConceptShareConnection.ConceptShareUserID, Nothing, Nothing, Nothing, Nothing, Nothing, Text, Text, AutoTags, Nothing)

                            If Project IsNot Nothing AndAlso Project.Id > 0 Then

                                ProjectID = Project.Id

                                DataContext.ExecuteCommand(String.Format("UPDATE JOB_COMPONENT WITH(ROWLOCK) SET CS_PROJECT_ID = {0} WHERE JOB_NUMBER = {1} AND JOB_COMPONENT_NBR = {2};",
                                                             ProjectID, JobNumber, JobComponentNumber))

                            End If

                        End If

                    End If

                End If

            End If

            LoadProjectByJobAndComponentNumber = Project

        End Function
        Public Function LoadProjectByConceptShareProjectID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                           ConceptShareProjectID As Integer) As ConceptShareAPI.Project

            Dim Project As ConceptShareAPI.Project

            Project = Nothing

            If ConceptShareConnection.Loaded Then

                If ConceptShareProjectID > 0 Then

                    Try

                        Project = ConceptShareConnection.APIServiceClient.GetProjectProfile(ConceptShareConnection.APIContext, ConceptShareProjectID)

                    Catch ex As Exception
                        Project = Nothing
                    End Try

                End If

            End If

            LoadProjectByConceptShareProjectID = Project

        End Function
        Private Function LoadProjectRoles(DataContext As AdvantageFramework.Database.DataContext, APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Generic.List(Of ConceptShareAPI.Role)

            'objects
            Dim ProjectRoles As Generic.List(Of ConceptShareAPI.Role) = Nothing

            ProjectRoles = New Generic.List(Of ConceptShareAPI.Role)

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                ProjectRoles = APIServiceClient.GetProjectRoleList(APIContext).ToList

            End If

            LoadProjectRoles = ProjectRoles

        End Function
        Private Function LoadRoles(DataContext As AdvantageFramework.Database.DataContext, APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Generic.List(Of ConceptShareAPI.Role)

            'objects
            Dim Roles As Generic.List(Of ConceptShareAPI.Role) = Nothing

            Roles = New Generic.List(Of ConceptShareAPI.Role)

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Roles = APIServiceClient.GetAccountRoleList(APIContext).ToList

            End If

            LoadRoles = Roles

        End Function
        Private Function LoadAccountAdministratorRoleID(DataContext As AdvantageFramework.Database.DataContext, APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim AccountAdministratorRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    AccountAdministratorRoleID = LoadRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(Role) Role.Code = RoleCodes.ACCOUNT_ADMINISTRATOR.ToString).Id

                Catch ex As Exception
                    AccountAdministratorRoleID = 0
                End Try

            End If

            LoadAccountAdministratorRoleID = AccountAdministratorRoleID

        End Function
        Private Function LoadWorkspaceAdministratorProjectRoleID(DataContext As AdvantageFramework.Database.DataContext, APIServiceClient As ConceptShareAPI.APIServiceClient, APIContext As ConceptShareAPI.APIContext) As Integer

            'objects
            Dim WorkspaceAdministratorProjectRoleID As Integer = 0

            If APIServiceClient IsNot Nothing AndAlso APIContext IsNot Nothing Then

                Try

                    WorkspaceAdministratorProjectRoleID = LoadProjectRoles(DataContext, APIServiceClient, APIContext).FirstOrDefault(Function(ProjectRole) ProjectRole.Code = ProjectRoleCodes.WORKSPACE_ADMINISTRATOR.ToString).Id

                Catch ex As Exception
                    WorkspaceAdministratorProjectRoleID = 0
                End Try

            End If

            LoadWorkspaceAdministratorProjectRoleID = WorkspaceAdministratorProjectRoleID

        End Function
        Public Function LoadProjects(ByRef DataContext As AdvantageFramework.Database.DataContext,
                                     ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection) As Generic.List(Of ConceptShareAPI.Project)

            If ConceptShareConnection.Loaded Then

                LoadProjects = ConceptShareConnection.APIServiceClient.GetProjectList(ConceptShareConnection.APIContext).ToList

            Else

                LoadProjects = New Generic.List(Of ConceptShareAPI.Project)

            End If

        End Function

#End Region

#Region " Review "

        Public Function ApproveAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                        ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                        ByVal UserCode As String,
                                        ByVal EmployeeCode As String,
                                        ByRef Message As String) As Boolean

            Dim Success As Boolean = True
            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing

            Try

                CompleteResult = AdvantageFramework.AlertSystem.CompleteAssignment(DbContext, Alert, EmployeeCode, UserCode, Nothing, Nothing)

                If CompleteResult IsNot Nothing Then

                    Try

                        'reload
                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                    Catch ex As Exception
                        Alert = Nothing
                    End Try
                    Try

                        If Alert IsNot Nothing Then

                            Dim UpdateAlert As Boolean = False

                            If CompleteResult.AutoRouteChangedState IsNot Nothing AndAlso CompleteResult.AutoRouteChangedState = True Then

                                If Alert.AlertStateID IsNot Nothing AndAlso CompleteResult.FinalAlertStateID IsNot Nothing Then

                                    If Alert.AlertStateID <> CompleteResult.FinalAlertStateID Then

                                        Alert.AlertStateID = CompleteResult.FinalAlertStateID

                                        UpdateAlert = True

                                    End If

                                End If
                                If CompleteResult.CurrentAssigneesList IsNot Nothing AndAlso CompleteResult.CurrentAssigneesList.Count > 0 Then

                                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                                    Dim ReviewMember As AdvantageFramework.ConceptShareAPI.ReviewMember = Nothing

                                    'Find the differences
                                    'Get reviewers list
                                    'assume reviewers won't overlap???
                                    For Each AssigneeEmployeeCode As String In CompleteResult.CurrentAssigneesList

                                        Employee = Nothing
                                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AssigneeEmployeeCode)
                                        ReviewMember = Nothing

                                        If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID IsNot Nothing Then

                                            'add reviewer
                                            ReviewMember = ConceptShareConnection.APIServiceClient.AddUpdateReviewMember(ConceptShareConnection.APIContext,
                                                                                                                             Alert.ConceptShareReviewID,
                                                                                                                             Employee.ConceptShareUserID,
                                                                                                                             CType(AdvantageFramework.ConceptShareAPI.ReferenceType.User, Integer),
                                                                                                                             Nothing,
                                                                                                                             "",
                                                                                                                             Nothing,
                                                                                                                             AdminReviewRoleID, Nothing)

                                            If ReviewMember IsNot Nothing Then

                                            End If

                                        End If

                                    Next

                                End If

                            End If
                            If CompleteResult.AssignmentFullyCompleted IsNot Nothing AndAlso CompleteResult.AssignmentFullyCompleted = True Then

                                If Alert.AssignmentCompleted Is Nothing OrElse Alert.AssignmentCompleted = False Then

                                    Alert.AssignmentCompleted = True
                                    UpdateAlert = True

                                End If

                                'Complete the review:
                                SetReviewComplete(DbContext, ConceptShareConnection, Alert, Message)

                            End If
                            If UpdateAlert = True Then

                                If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert) = True Then


                                End If

                            End If

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, "[Review Updated]",
                                                                                  "", "", "", "", False, False, False, True, "", "", Message, True, False)

                        End Using

                    Catch ex As Exception
                    End Try

                End If

            Catch ex As Exception
                CompleteResult.Success = False
                CompleteResult.Message = Message
            End Try

            Message = CompleteResult.Message

            Return CompleteResult.Success

        End Function

        Public Function LoadStatus(DataContext As AdvantageFramework.Database.DataContext, StatusType As ConceptShareAPI.StatusType) As Generic.List(Of ConceptShareAPI.Status)

            'objects
            Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
            Dim APIContext As ConceptShareAPI.APIContext = Nothing
            Dim OrderedList As Generic.List(Of ConceptShareAPI.Status) = Nothing
            Dim DbList As Generic.List(Of ConceptShareAPI.Status) = Nothing
            Dim Status As ConceptShareAPI.Status = Nothing

            OrderedList = New List(Of ConceptShareAPI.Status)

            If CreateSystemAccountConecptShareConnection(DataContext, APIServiceClient, APIContext) Then

                Try
                    'No "order" from CS side.  ID's are different depending on when acct created
                    DbList = APIServiceClient.GetStatusList(APIContext, StatusType).ToList

                Catch ex As Exception
                    DbList = Nothing
                End Try
                'Must re-ordered
                If DbList IsNot Nothing Then

                    Status = Nothing
                    Status = (From Entity In DbList
                              Where Entity.Code = "NOT_STARTED"
                              Select Entity).SingleOrDefault
                    If Status IsNot Nothing Then

                        OrderedList.Add(Status)

                    End If
                    Status = Nothing
                    Status = (From Entity In DbList
                              Where Entity.Code = "IN_PROGRESS"
                              Select Entity).SingleOrDefault
                    If Status IsNot Nothing Then

                        OrderedList.Add(Status)

                    End If
                    Status = Nothing
                    Status = (From Entity In DbList
                              Where Entity.Code = "COMPLETED"
                              Select Entity).SingleOrDefault
                    If Status IsNot Nothing Then

                        OrderedList.Add(Status)

                    End If

                End If

            End If

            Return OrderedList

        End Function
        Public Function LoadReviewStatusList(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.ConceptShareAPI.Status)

            Dim ReviewStatusList As Generic.List(Of AdvantageFramework.ConceptShareAPI.Status) = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                ReviewStatusList = AdvantageFramework.ConceptShare.LoadStatus(DataContext, AdvantageFramework.ConceptShareAPI.StatusType.Review)

            End Using

            Return ReviewStatusList.OrderByDescending(Function(Entity) Entity.Id).ToList

        End Function
        Public Function SetReviewComplete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                          ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                          ByRef ErrorMessage As String) As Boolean

            Dim ThisReview As ConceptShareAPI.Review = Nothing

            ThisReview = LoadReviewByReviewID(ConceptShareConnection, Alert.ConceptShareReviewID, ErrorMessage)

            If ThisReview IsNot Nothing Then

                Dim CompleteStatusID As Integer? = Nothing 'Different for different agencies on CS side

                Try

                    CompleteStatusID = (From Entity In LoadReviewStatusList(DbContext)
                                        Where Entity.Code = "COMPLETED"
                                        Select Entity.Id).SingleOrDefault


                Catch ex As Exception
                    CompleteStatusID = Nothing
                End Try

                If CompleteStatusID IsNot Nothing AndAlso ThisReview.StatusId <> CompleteStatusID Then

                    ThisReview.StatusId = CompleteStatusID

                    Dim AutoTags As Generic.List(Of String) = LoadJobInfoForTagListDbContext(DbContext, Alert.JobNumber, Alert.JobComponentNumber)
                    Dim ReviewItems As Generic.List(Of ConceptShareAPI.ReviewItem) = LoadReviewItemsByReviewID(ConceptShareConnection, Alert.ConceptShareReviewID)
                    Dim ReviewMembers As Generic.List(Of ConceptShareAPI.ReviewMember) = LoadReviewMembersByReviewID(ConceptShareConnection, Alert.ConceptShareReviewID)
                    Dim ExternalReviewers As Generic.List(Of ConceptShareAPI.ExternalReviewer) = New List(Of ConceptShareAPI.ExternalReviewer)

                    UpdateReview(ConceptShareConnection, ThisReview, AutoTags, ReviewItems, ReviewMembers, ExternalReviewers, ErrorMessage)

                End If

            End If

            Return True

        End Function
        Public Function LoadReviewByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ReviewID As Integer,
                                             ByRef ErrorMessage As String) As ConceptShareAPI.Review

            Try

                LoadReviewByReviewID = ConceptShareConnection.APIServiceClient.GetReviewProfile(ConceptShareConnection.APIContext, ReviewID)
                ErrorMessage = String.Empty

            Catch ex As Exception
                LoadReviewByReviewID = Nothing
                ErrorMessage = ex.Message.ToString()
            End Try

        End Function
        Public Function LoadReviewItemsByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ReviewID As Integer) As Generic.List(Of ConceptShareAPI.ReviewItem)

            If ReviewID > 0 Then

                If ConceptShareConnection.Loaded Then

                    LoadReviewItemsByReviewID = ConceptShareConnection.APIServiceClient.GetReviewItemList(ConceptShareConnection.APIContext, ReviewID, Nothing).ToList

                Else

                    LoadReviewItemsByReviewID = New Generic.List(Of ConceptShareAPI.ReviewItem)

                End If

            Else

                LoadReviewItemsByReviewID = New Generic.List(Of ConceptShareAPI.ReviewItem)

            End If

        End Function
        Public Function LoadReviews(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ByVal ProjectID As Integer) As Generic.List(Of ConceptShareAPI.Review)

            Try

                If ConceptShareConnection.Loaded Then

                    LoadReviews = ConceptShareConnection.APIServiceClient.GetReviewList(ConceptShareConnection.APIContext, ProjectID, Nothing).ToList

                Else

                    LoadReviews = New Generic.List(Of ConceptShareAPI.Review)

                End If

            Catch ex As Exception
                LoadReviews = New Generic.List(Of ConceptShareAPI.Review)
            End Try

        End Function
        Public Function LoadReviewSummaries(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ByVal ProjectID As Integer,
                                            ByVal ThumbnailHeight As Integer, ByVal ThumbnailWidth As Integer) As Generic.List(Of AdvantageFramework.ConceptShare.Classes.ReviewSummary)

            Dim ReviewSummaries As New List(Of Classes.ReviewSummary)
            Try

                If ConceptShareConnection.Loaded Then

                    Dim Reviews As Generic.List(Of ConceptShareAPI.Review)

                    Reviews = Nothing
                    Reviews = ConceptShareConnection.APIServiceClient.GetReviewList(ConceptShareConnection.APIContext, ProjectID, Nothing).ToList

                    If Reviews IsNot Nothing Then

                        Dim ReviewSummary As ConceptShare.Classes.ReviewSummary

                        For Each Review As ConceptShareAPI.Review In Reviews

                            ReviewSummary = Nothing
                            ReviewSummary = LoadReviewSummary(ConceptShareConnection, Review.Id)

                            If ReviewSummary IsNot Nothing Then

                                ReviewSummaries.Add(ReviewSummary)

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                ReviewSummaries = New List(Of Classes.ReviewSummary)
            End Try

            LoadReviewSummaries = ReviewSummaries

        End Function
        Public Function LoadReviewSummary(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ByVal ReviewID As Integer) As AdvantageFramework.ConceptShare.Classes.ReviewSummary

            Dim ReviewSummary As ConceptShare.Classes.ReviewSummary = Nothing

            Try

                If ConceptShareConnection.Loaded Then

                    Dim Review As ConceptShareAPI.Review
                    Review = Nothing

                    Review = ConceptShareConnection.APIServiceClient.GetReviewProfile(ConceptShareConnection.APIContext, ReviewID)

                    If Review IsNot Nothing Then

                        Dim ReviewMembers As Generic.List(Of ConceptShareAPI.ReviewMember)
                        Dim ReviewResponses As Generic.List(Of ConceptShareAPI.ReviewResponse)

                        ReviewMembers = Nothing
                        ReviewResponses = Nothing

                        ReviewSummary = New Classes.ReviewSummary

                        ReviewSummary.Review = Review
                        ReviewSummary.BaseImage = DownloadReviewBaseAssetImage(ConceptShareConnection, Review.Id, 40, 40)

                        ReviewMembers = Nothing
                        Try

                            ReviewMembers = ConceptShareConnection.APIServiceClient.GetReviewMemberList(ConceptShareConnection.APIContext, Review.Id).ToList

                        Catch ex As Exception
                            ReviewMembers = Nothing
                        End Try

                        If ReviewMembers IsNot Nothing Then

                            ReviewSummary.ReviewerCount = ReviewMembers.Count

                        End If

                        ReviewResponses = Nothing
                        Try

                            ReviewResponses = ConceptShareConnection.APIServiceClient.GetReviewResponses(ConceptShareConnection.APIContext, Review.Id, Nothing, Nothing, Nothing).ToList

                        Catch ex As Exception
                            ReviewResponses = Nothing
                        End Try

                        If ReviewResponses IsNot Nothing Then

                            Try

                                ReviewSummary.ApprovedReviewerCount = (From Entity In ReviewResponses
                                                                       Where Entity.StatusCode = "APPROVED").Count

                            Catch ex As Exception
                                ReviewSummary.ApprovedReviewerCount = 0
                            End Try
                            Try

                                ReviewSummary.RejectedReviewerCount = (From Entity In ReviewResponses
                                                                       Where Entity.StatusCode = "REJECTED").Count

                            Catch ex As Exception
                                ReviewSummary.RejectedReviewerCount = 0
                            End Try
                            Try

                                ReviewSummary.DeferredReviewerCount = (From Entity In ReviewResponses
                                                                       Where Entity.StatusCode = "DEFERRED").Count

                            Catch ex As Exception
                                ReviewSummary.DeferredReviewerCount = 0
                            End Try
                            Try

                                ReviewSummary.CompletedReviewerCount = (From Entity In ReviewResponses
                                                                        Where Entity.StatusCode = "APPROVED" OrElse
                                                                                Entity.StatusCode = "REJECTED" OrElse
                                                                                Entity.StatusCode = "DEFERRED" OrElse
                                                                                Entity.StatusCode = "COMPLETED").Count

                            Catch ex As Exception
                                ReviewSummary.CompletedReviewerCount = 0
                            End Try

                        Else

                            If ReviewMembers IsNot Nothing Then

                                Try

                                    ReviewSummary.ApprovedReviewerCount = (From Entity In ReviewMembers
                                                                           Where Entity.StatusCode = "APPROVED").Count

                                Catch ex As Exception
                                    ReviewSummary.ApprovedReviewerCount = 0
                                End Try
                                Try

                                    ReviewSummary.RejectedReviewerCount = (From Entity In ReviewMembers
                                                                           Where Entity.StatusCode = "REJECTED").Count

                                Catch ex As Exception
                                    ReviewSummary.RejectedReviewerCount = 0
                                End Try
                                Try

                                    ReviewSummary.DeferredReviewerCount = (From Entity In ReviewMembers
                                                                           Where Entity.StatusCode = "DEFERRED").Count

                                Catch ex As Exception
                                    ReviewSummary.DeferredReviewerCount = 0
                                End Try
                                ReviewSummary.CompletedReviewerCount = (From Entity In ReviewMembers
                                                                        Where Entity.StatusCode = "APPROVED" OrElse
                                                                                Entity.StatusCode = "REJECTED" OrElse
                                                                                Entity.StatusCode = "DEFERRED" OrElse
                                                                                Entity.StatusCode = "COMPLETED").Count

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ReviewSummary = Nothing
            End Try

            LoadReviewSummary = ReviewSummary

        End Function
        Public Function AddReview(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                        ByRef Review As ConceptShareAPI.Review,
                                        ByRef AutoTags As Generic.List(Of String),
                                        ByRef ReviewItems As Generic.List(Of ConceptShareAPI.ReviewItem),
                                        ByRef ReviewMembers As Generic.List(Of ConceptShareAPI.ReviewMember),
                                        ByRef ExternalReviewers As Generic.List(Of ConceptShareAPI.ExternalReviewer),
                                        ByRef ErrorMessage As String) As ConceptShareAPI.Review

            If ConceptShareConnection.Loaded Then

                'If ConceptShareConnection.ConceptShareUser IsNot Nothing Then

                '    Dim ReviewMember As New ConceptShareAPI.ReviewMember

                '    ReviewMember.ReferenceId = ConceptShareConnection.ConceptShareUser.UserId
                '    ReviewMember.ReferenceType = CType(ConceptShareAPI.ReferenceType.User, Integer)
                '    ReviewMembers.Add(ReviewMember)

                'End If

                Try

                    Review = ConceptShareConnection.APIServiceClient.AddUpdateReviewFull(ConceptShareConnection.APIContext,
                                                                                         Nothing,
                                                                                         Review.ProjectId,
                                                                                         Review.ReferenceId,
                                                                                         Review.ReferenceType,
                                                                                         Review.ReviewType,
                                                                                         Review.StatusId,
                                                                                         If(Review.IsHighPriority = True, 1, 0),
                                                                                         Review.AutoApproveMethod,
                                                                                         Review.ReviewCommentsOnly,
                                                                                         Review.AllowFeedback,
                                                                                         Review.AllowNotes,
                                                                                         Review.AllowMembersToView,
                                                                                         Review.Title,
                                                                                         Review.Description,
                                                                                         Review.Code,
                                                                                         AutoTags.ToArray,
                                                                                         Review.DueDate,
                                                                                         ReviewMembers.ToArray,
                                                                                         ReviewItems.ToArray,
                                                                                         Review.RequireResourceOnDeferral,
                                                                                         Review.AllowDeferralResponses,
                                                                                         Review.ElectronicSignatureRequired,
                                                                                         If(ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0, ExternalReviewers.ToArray, Nothing))

                    ErrorMessage = String.Empty

                Catch ex As System.ServiceModel.FaultException
                    ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
                End Try

            End If

            Return Review

        End Function
        Public Function UpdateReview(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                     ByRef Review As ConceptShareAPI.Review,
                                     ByRef AutoTags As Generic.List(Of String),
                                     ByRef ReviewItems As Generic.List(Of ConceptShareAPI.ReviewItem),
                                     ByRef ReviewMembers As Generic.List(Of ConceptShareAPI.ReviewMember),
                                     ByRef ExternalReviewers As Generic.List(Of ConceptShareAPI.ExternalReviewer),
                                     ByRef ErrorMessage As String) As ConceptShareAPI.Review

            If ConceptShareConnection.Loaded Then

                'If ConceptShareConnection.ConceptShareUser IsNot Nothing Then

                '    Dim ReviewMember As New ConceptShareAPI.ReviewMember

                '    ReviewMember.Id = ConceptShareConnection.ConceptShareUser.UserId
                '    ReviewMember.Name = ConceptShareConnection.ConceptShareUser.FullName
                '    ReviewMember.ReferenceType = 3
                '    ReviewMembers.Add(ReviewMember)

                'End If

                Try

                    Review = ConceptShareConnection.APIServiceClient.AddUpdateReviewFull(ConceptShareConnection.APIContext,
                                                                                         Review.Id,
                                                                                         Review.ProjectId,
                                                                                         Review.ReferenceId,
                                                                                         Review.ReferenceType,
                                                                                         Review.ReviewType,
                                                                                         Review.StatusId,
                                                                                         If(Review.IsHighPriority = True, 1, 0),
                                                                                         Review.AutoApproveMethod,
                                                                                         Review.ReviewCommentsOnly,
                                                                                         Review.AllowFeedback,
                                                                                         Review.AllowNotes,
                                                                                         Review.AllowMembersToView,
                                                                                         Review.Title,
                                                                                         Review.Description,
                                                                                         Review.Code,
                                                                                         If(AutoTags.ToArray IsNot Nothing AndAlso AutoTags.Count > 0, AutoTags.ToArray, Nothing),
                                                                                         If(Review.DueDate IsNot Nothing AndAlso IsDate(Review.DueDate) = True, Review.DueDate, Nothing),
                                                                                         ReviewMembers.ToArray,
                                                                                         ReviewItems.ToArray,
                                                                                         Review.RequireResourceOnDeferral,
                                                                                         Review.AllowDeferralResponses,
                                                                                         Review.ElectronicSignatureRequired,
                                                                                         If(ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0, ExternalReviewers.ToArray, Nothing))

                    ErrorMessage = String.Empty

                Catch ex As System.ServiceModel.FaultException
                    ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
                End Try

            End If

            Return Review

        End Function
        Public Function LoadJobInfoForTagList(ByRef SecuritySession As AdvantageFramework.Security.Session,
                                              ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of String)

            Dim Tags As New Generic.List(Of String)
            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Tags = LoadJobInfoForTagListDbContext(DbContext, JobNumber, JobComponentNumber)

            End Using

            LoadJobInfoForTagList = Tags

        End Function
        Public Function LoadJobInfoForTagListDbContext(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of String)

            Dim Tags As New Generic.List(Of String)

            Dim Query = (From JobComponent In DbContext.JobComponents
                         Join Job In DbContext.Jobs On JobComponent.JobNumber Equals Job.Number
                         Join Client In DbContext.Clients On Job.ClientCode Equals Client.Code
                         Join Division In DbContext.Divisions On Job.ClientCode Equals Division.ClientCode And Job.DivisionCode Equals Division.Code
                         Join Product In DbContext.Products On Job.ClientCode Equals Product.ClientCode And Job.DivisionCode Equals Product.DivisionCode And Job.ProductCode Equals Product.Code
                         Where JobComponent.JobNumber = JobNumber And JobComponent.Number = JobComponentNumber).FirstOrDefault

            If Query IsNot Nothing Then

                Tags.Add(String.Format("Client:  {0} - {1}", Query.Client.Code, Query.Client.Name))
                Tags.Add(String.Format("Division:  {0} - {1}", Query.Division.Code, Query.Division.Name))
                Tags.Add(String.Format("Product:  {0} - {1}", Query.Product.Code, Query.Product.Name))
                Tags.Add(String.Format("Job:  {0}/{1} - {2}", JobNumber.ToString.PadLeft(6, "0"), JobComponentNumber.ToString.PadLeft(2, "0"), Query.JobComponent.Description))

            End If

            Return Tags

        End Function

        Public Function AddReviewItem(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                      ByVal ReviewID As Integer, ByVal AssetID As Integer) As ConceptShareAPI.ReviewItem

            If ConceptShareConnection.Loaded Then

                AddReviewItem = ConceptShareConnection.APIServiceClient.AddReviewItem(ConceptShareConnection.APIContext, ReviewID, AssetID)

            Else

                AddReviewItem = Nothing

            End If

        End Function

        Public Function DeleteReview(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                     ByVal ReviewID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            If ConceptShareConnection.Loaded Then

                Try
                    'TODO:  NEED TO REMOVE ALERT
                    ConceptShareConnection.APIServiceClient.RemoveReview(ConceptShareConnection.APIContext, ReviewID)
                    Deleted = True

                Catch ex As Exception
                    Deleted = False
                End Try

            End If

            DeleteReview = Deleted

        End Function

        Public Function LoadReviewAssets(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                         ByVal ReviewID As Integer) As Generic.List(Of ConceptShareAPI.Asset)

            'objects
            Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset)

            Assets = Nothing
            If ConceptShareConnection.Loaded Then

                Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset

                BaseAsset = AdvantageFramework.ConceptShare.LoadReviewBaseAsset(ConceptShareConnection, ReviewID)

                If BaseAsset IsNot Nothing Then

                    Assets = AdvantageFramework.ConceptShare.GetAssetWithRevisions(ConceptShareConnection, BaseAsset.Id)

                End If

            End If

            If Assets Is Nothing Then Assets = New List(Of ConceptShareAPI.Asset)

            LoadReviewAssets = Assets

        End Function

#Region " Job Info "

        Public Function LoadJobInfoByJobAndJobComponentNumber(DataContext As AdvantageFramework.Database.DataContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As AdvantageFramework.ConceptShare.Classes.JobInfo

            Try

                Return DataContext.ExecuteQuery(Of AdvantageFramework.ConceptShare.Classes.JobInfo)(String.Format("EXEC [dbo].[advsp_cs_load_basic_job_info] {0}, {1}, 0, 0, 0;", JobNumber, JobComponentNumber)).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadJobInfoByByAlertID(DataContext As AdvantageFramework.Database.DataContext, ByVal AlertID As Integer) As AdvantageFramework.ConceptShare.Classes.JobInfo

            Try

                Return DataContext.ExecuteQuery(Of AdvantageFramework.ConceptShare.Classes.JobInfo)(String.Format("EXEC [dbo].[advsp_cs_load_basic_job_info] 0, 0, {0}, 0, 0;", AlertID)).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadJobInfoByByConceptShareProjectID(DataContext As AdvantageFramework.Database.DataContext, ByVal ProjectID As Integer) As AdvantageFramework.ConceptShare.Classes.JobInfo

            Try

                Return DataContext.ExecuteQuery(Of AdvantageFramework.ConceptShare.Classes.JobInfo)(String.Format("EXEC [dbo].[advsp_cs_load_basic_job_info] 0, 0, 0, {0}, 0;", ProjectID)).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadJobInfoByByConceptShareReviewID(DataContext As AdvantageFramework.Database.DataContext, ByVal ReviewID As Integer) As AdvantageFramework.ConceptShare.Classes.JobInfo

            Try

                Return DataContext.ExecuteQuery(Of AdvantageFramework.ConceptShare.Classes.JobInfo)(String.Format("EXEC [dbo].[advsp_cs_load_basic_job_info] 0, 0, 0, 0, {0};", ReviewID)).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

#End Region

#End Region

#Region " Review Assets "

        Public Function LoadProjectFolderItems(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                               ProjectID As Integer) As Generic.List(Of ConceptShareAPI.FolderItem)

            'objects
            Dim FolderItems As Generic.List(Of ConceptShareAPI.FolderItem)

            FolderItems = Nothing
            If ConceptShareConnection.Loaded Then

                Dim Project As ConceptShareAPI.Project

                Project = Nothing

                Project = ConceptShareConnection.APIServiceClient.GetProjectProfile(ConceptShareConnection.APIContext, ProjectID)

                If Project IsNot Nothing Then


                    FolderItems = ConceptShareConnection.APIServiceClient.GetFolderItemList(ConceptShareConnection.APIContext, Project.FolderId).ToList

                End If

            End If

            If FolderItems Is Nothing Then FolderItems = New List(Of ConceptShareAPI.FolderItem)

            LoadProjectFolderItems = FolderItems

        End Function

        Public Function GetReviewProofingURLForExternalUser(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                            ProjectID As Integer, ReviewID As Integer, ConceptShareUserID As Integer) As String

            If ConceptShareConnection.Loaded Then

                Dim Options As New ConceptShareAPI.ResourceUrlOptions
                Options.PreAuthenticateUser = True
                Options.ProjectId = ProjectID
                Options.ReferenceType = ConceptShareAPI.ReferenceType.Review
                Options.ReferenceId = ReviewID
                Options.UrlType = ConceptShareAPI.ResourceUrlType.Reference
                Options.SecureUrl = True

                GetReviewProofingURLForExternalUser = ConceptShareConnection.APIServiceClient.GetResourceUrlForUser(ConceptShareConnection.APIContext, ConceptShareUserID, Options)

            Else

                GetReviewProofingURLForExternalUser = String.Empty

            End If

        End Function
        Public Function GetReviewProofingURL(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                             ProjectID As Integer, ReviewID As Integer) As String

            If ConceptShareConnection.Loaded Then

                Dim Options As New ConceptShareAPI.ResourceUrlOptions
                Options.PreAuthenticateUser = True
                Options.ProjectId = ProjectID
                Options.ReferenceType = ConceptShareAPI.ReferenceType.Review
                Options.ReferenceId = ReviewID
                Options.UrlType = ConceptShareAPI.ResourceUrlType.Reference
                Options.SecureUrl = True

                GetReviewProofingURL = ConceptShareConnection.APIServiceClient.GetResourceUrl(ConceptShareConnection.APIContext, Options)

            Else

                GetReviewProofingURL = String.Empty

            End If

        End Function
        Public Function LoadAssetByAssetID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                           AssetID As Integer) As ConceptShareAPI.Asset
            If ConceptShareConnection.Loaded Then

                LoadAssetByAssetID = ConceptShareConnection.APIServiceClient.GetAssetProfile(ConceptShareConnection.APIContext, AssetID, Nothing)

            Else

                LoadAssetByAssetID = Nothing

            End If

        End Function

        Public Function DownloadAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, AssetID As Integer) As Byte()

            Dim Asset As Byte()
            If ConceptShareConnection.Loaded Then

                Asset = ConceptShareConnection.APIServiceClient.DownloadAsset(ConceptShareConnection.APIContext, AssetID)

            Else

                Asset = Nothing

            End If

            DownloadAsset = Asset

        End Function
        Public Function UploadAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                    Name As String, Filename As String, FolderID As Nullable(Of Integer), ProjectID As Integer, FileData As Byte(),
                                    IsReferenceFile As Boolean, UploadParameters() As ConceptShareAPI.AssetUploadParameter) As ConceptShareAPI.Asset

            If ConceptShareConnection.Loaded Then

                UploadAsset = ConceptShareConnection.APIServiceClient.AddProjectAsset(ConceptShareConnection.APIContext, Name, Filename, Nothing, ProjectID, FileData, IsReferenceFile, UploadParameters)

            Else

                UploadAsset = Nothing

            End If

        End Function
        Public Function UploadAssetVersion(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                           PreviousAssetID As Integer, Name As String, Filename As String, FileData As Byte(),
                                           IsReferenceFile As Boolean, UploadParameters() As ConceptShareAPI.AssetUploadParameter) As ConceptShareAPI.Asset

            If ConceptShareConnection.Loaded Then

                UploadAssetVersion = ConceptShareConnection.APIServiceClient.AddVersionedAsset(ConceptShareConnection.APIContext, PreviousAssetID, Name, Filename, FileData, IsReferenceFile, UploadParameters)

            Else

                UploadAssetVersion = Nothing

            End If

        End Function

        'Public Function LoadReviewBaseAsset(DataContext As AdvantageFramework.Database.DataContext,
        '                                    ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
        '                                    ReviewID As Integer) As ConceptShareAPI.Asset

        '    'objects
        '    Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset
        '    Dim s As String = String.Empty

        '    BaseAsset = Nothing

        '    Dim Review As AdvantageFramework.ConceptShareAPI.Review

        '    Review = Nothing
        '    Review = LoadReviewByReviewID(DataContext, ConceptShareConnection, ReviewID, s)

        '    If Review IsNot Nothing Then

        '        Dim ReviewItems As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)

        '        ReviewItems = Nothing
        '        ReviewItems = AdvantageFramework.ConceptShare.LoadReviewItemsByReviewID(DataContext, ConceptShareConnection, ReviewID)

        '        If ReviewItems IsNot Nothing AndAlso ReviewItems.Count > 0 Then

        '            Dim BaseReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem

        '            BaseReviewItem = Nothing

        '            Try

        '                BaseReviewItem = (From Entity In ReviewItems
        '                                  Order By Entity.Id Ascending
        '                                  Select Entity).FirstOrDefault

        '            Catch ex As Exception
        '                BaseReviewItem = Nothing
        '            End Try

        '            If BaseReviewItem IsNot Nothing Then

        '                BaseAsset = AdvantageFramework.ConceptShare.LoadAssetByAssetID(DataContext, ConceptShareConnection, BaseReviewItem.AssetId)

        '            End If

        '        End If

        '    End If


        '    LoadReviewBaseAsset = BaseAsset

        'End Function
        Public Function GetLastAssetID(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                       ByVal ReviewID As Integer) As Integer

            Dim ReviewItems As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)
            Dim ID As Integer = 0

            ReviewItems = Nothing

            ReviewItems = AdvantageFramework.ConceptShare.LoadReviewItemsByReviewID(ConceptShareConnection, ReviewID)

            If ReviewItems IsNot Nothing AndAlso ReviewItems.Count > 0 Then

                Dim LastReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem

                LastReviewItem = Nothing

                Try

                    LastReviewItem = (From Entity In ReviewItems
                                      Order By Entity.Id Descending
                                      Select Entity).FirstOrDefault

                Catch ex As Exception
                    LastReviewItem = Nothing
                End Try

                If LastReviewItem IsNot Nothing Then

                    ID = LastReviewItem.AssetId

                End If

            End If

            Return ID

        End Function

        Public Function LoadReviewBaseAsset(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                            ReviewID As Integer) As ConceptShareAPI.Asset

            'objects
            Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset
            Dim s As String = String.Empty

            BaseAsset = Nothing

            Dim Review As AdvantageFramework.ConceptShareAPI.Review

            Review = Nothing
            Review = LoadReviewByReviewID(ConceptShareConnection, ReviewID, s)

            If Review IsNot Nothing Then

                Dim ReviewItems As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewItem)

                ReviewItems = Nothing
                ReviewItems = AdvantageFramework.ConceptShare.LoadReviewItemsByReviewID(ConceptShareConnection, ReviewID)

                If ReviewItems IsNot Nothing AndAlso ReviewItems.Count > 0 Then

                    Dim BaseReviewItem As AdvantageFramework.ConceptShareAPI.ReviewItem

                    BaseReviewItem = Nothing

                    Try

                        BaseReviewItem = (From Entity In ReviewItems
                                          Order By Entity.Id Ascending
                                          Select Entity).FirstOrDefault

                    Catch ex As Exception
                        BaseReviewItem = Nothing
                    End Try

                    If BaseReviewItem IsNot Nothing Then

                        BaseAsset = AdvantageFramework.ConceptShare.LoadAssetByAssetID(ConceptShareConnection, BaseReviewItem.AssetId)

                    End If

                End If

            End If

            LoadReviewBaseAsset = BaseAsset

        End Function

        Public Function DownloadReviewBaseAssetImage(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                     ByVal ReviewID As Integer, ByVal Width As Integer, ByVal Height As Integer) As Byte()

            Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset

            BaseAsset = Nothing
            BaseAsset = LoadReviewBaseAsset(ConceptShareConnection, ReviewID)

            If BaseAsset IsNot Nothing Then

                If Width = 0 Then Width = ThumbnailWidth
                If Height = 0 Then Height = ThumbnailHeight
                DownloadReviewBaseAssetImage = ConceptShareConnection.APIServiceClient.DownloadAssetImage(ConceptShareConnection.APIContext, BaseAsset.Id, Width, Height)

            Else

                DownloadReviewBaseAssetImage = Nothing

            End If

        End Function
        Public Function DownloadReviewBaseAssetImage(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, ReviewID As Integer) As Byte()

            If ConceptShareConnection.Loaded Then

                Dim BaseAsset As AdvantageFramework.ConceptShareAPI.Asset

                BaseAsset = Nothing
                BaseAsset = LoadReviewBaseAsset(ConceptShareConnection, ReviewID)

                If BaseAsset IsNot Nothing Then

                    DownloadReviewBaseAssetImage = ConceptShareConnection.APIServiceClient.DownloadAssetImage(ConceptShareConnection.APIContext, BaseAsset.Id, ThumbnailWidth, ThumbnailHeight)

                Else

                    DownloadReviewBaseAssetImage = Nothing

                End If

            Else

                DownloadReviewBaseAssetImage = Nothing

            End If

        End Function

        Public Function DownloadAssetImage(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, AssetID As Integer) As Byte()

            If ConceptShareConnection.Loaded Then

                Try

                    DownloadAssetImage = ConceptShareConnection.APIServiceClient.DownloadAssetImage(ConceptShareConnection.APIContext, AssetID, ThumbnailWidth, ThumbnailHeight)

                Catch ex As Exception
                    DownloadAssetImage = Nothing
                End Try

            Else

                DownloadAssetImage = Nothing

            End If

        End Function
        Public Function DownloadMarkupImage(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection, CommentID As Integer,
                                            Optional Width As Integer = 0, Optional Height As Integer = 0) As Byte()

            If ConceptShareConnection.Loaded Then

                If Width = 0 Then Width = ThumbnailWidth
                If Height = 0 Then Height = ThumbnailHeight

                Try

                    DownloadMarkupImage = ConceptShareConnection.APIServiceClient.DownloadMarkupImage(ConceptShareConnection.APIContext, CommentID, Width, Height)

                Catch ex As Exception
                    DownloadMarkupImage = Nothing
                End Try

            Else

                DownloadMarkupImage = Nothing

            End If

        End Function

        Public Function GetAssetWithRevisions(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                              AssetID As Integer) As Generic.List(Of ConceptShareAPI.Asset)

            Dim Assets As New Generic.List(Of ConceptShareAPI.Asset)

            GetPreviousAsset(ConceptShareConnection, AssetID, Assets)

            GetAssetWithRevisions = Assets

        End Function

        Private Sub GetPreviousAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                     ByVal AssetID As Integer, ByRef AssetList As Generic.List(Of ConceptShareAPI.Asset))

            'objects
            Dim Asset As ConceptShareAPI.Asset

            Asset = Nothing

            If ConceptShareConnection.Loaded Then

                Asset = ConceptShareConnection.APIServiceClient.GetAssetProfile(ConceptShareConnection.APIContext, AssetID, Nothing)

                If Asset IsNot Nothing Then

                    AssetList.Add(Asset)

                    If Asset.PreviousAssetId IsNot Nothing AndAlso Asset.PreviousAssetId > 0 Then

                        GetPreviousAsset(ConceptShareConnection, Asset.PreviousAssetId, AssetList)

                    End If

                End If

            End If

        End Sub
        Public Function CaptureWebPageAsAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                              ProjectID As Integer, AssetID As Integer, URL As String, Title As String,
                                              Width As Integer, Height As Integer, CaptureDelay As Integer, MaxWaitDelay As Integer) As ConceptShareAPI.Asset

            'objects
            Dim Asset As ConceptShareAPI.Asset

            Asset = Nothing
            If ConceptShareConnection.Loaded Then

                Dim FileBytes(0) As Byte
                Dim UploadParameters As Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)
                Dim UploadParameter As AdvantageFramework.ConceptShareAPI.AssetUploadParameter

                UploadParameters = New Generic.List(Of AdvantageFramework.ConceptShareAPI.AssetUploadParameter)

                UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
                UploadParameter.Key = "WEBSITE_URL"
                UploadParameter.Value = URL
                UploadParameters.Add(UploadParameter)

                If Width > 0 Then

                    UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
                    UploadParameter.Key = "WEBSITE_WIDTH"
                    UploadParameter.Value = Width
                    UploadParameters.Add(UploadParameter)

                End If
                If Height > 0 Then

                    UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
                    UploadParameter.Key = "WEBSITE_HEIGHT"
                    UploadParameter.Value = Height
                    UploadParameters.Add(UploadParameter)

                End If
                If CaptureDelay > 0 Then

                    UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
                    UploadParameter.Key = "WEBSITE_CAPTURE_DELAY"
                    UploadParameter.Value = CaptureDelay
                    UploadParameters.Add(UploadParameter)

                End If
                If MaxWaitDelay > 0 Then

                    UploadParameter = New AdvantageFramework.ConceptShareAPI.AssetUploadParameter
                    UploadParameter.Key = "WEBSITE_MAXIMUM_DELAY"
                    UploadParameter.Value = MaxWaitDelay
                    UploadParameters.Add(UploadParameter)

                End If

                If AssetID = 0 Then

                    Asset = ConceptShareConnection.APIServiceClient.AddProjectAsset(ConceptShareConnection.APIContext, Title, "webpage.html", Nothing, ProjectID, FileBytes, False, UploadParameters.ToArray)

                Else

                    Asset = ConceptShareConnection.APIServiceClient.AddVersionedAsset(ConceptShareConnection.APIContext, AssetID, Title, "webpage.html", FileBytes, False, UploadParameters.ToArray)

                End If


            End If

            CaptureWebPageAsAsset = Asset

        End Function

        Public Function ByteArrayImageToImageURL(ByVal BinaryImage As Byte()) As String

            Dim Base64String As String = String.Empty
            Dim ImageAsURL As String = String.Empty

            Try

                Base64String = Convert.ToBase64String(BinaryImage)

            Catch ex As Exception
                Base64String = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(Base64String) = False Then

                ImageAsURL = String.Format("data:image/jpeg;base64,{0}", Base64String)

            End If

            ByteArrayImageToImageURL = ImageAsURL

        End Function

        Public Function RemoveAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                    AssetID As Integer) As Object

            If ConceptShareConnection.Loaded Then

                RemoveAsset = ConceptShareConnection.APIServiceClient.RemoveAsset(ConceptShareConnection.APIContext, AssetID)

            Else

                RemoveAsset = Nothing

            End If

        End Function

#End Region

#Region " Review Comments "

        Public Function LoadCommentReplies(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                           AssetID As Integer, CommentID As Integer) As Generic.List(Of ConceptShareAPI.CommentThread)

            If ConceptShareConnection.Loaded Then

                LoadCommentReplies = (From Entity In ConceptShareConnection.APIServiceClient.GetCommentThread(ConceptShareConnection.APIContext, AssetID, CommentID).ToList
                                      Where Entity.CommentReplyId > 0
                                      Order By Entity.CommentReplyId Descending
                                      Select Entity).ToList

            Else

                LoadCommentReplies = New List(Of ConceptShareAPI.CommentThread)

            End If

        End Function
        Public Function LoadFullComment(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                   ProjectID As Integer, ReviewID As Integer, AssetID As Integer, CommentID As Integer,
                                   ByRef Comment As AdvantageFramework.ConceptShareAPI.Comment,
                                   ByRef Replies As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread),
                                   ByRef MarkupImage As Byte()) As Boolean

            Dim Success As Boolean = False
            If ConceptShareConnection.Loaded Then

                Comment = (From Entity In ConceptShareConnection.APIServiceClient.GetCommentList(ConceptShareConnection.APIContext, AssetID, ReviewID).ToList
                           Where Entity.Id = CommentID).FirstOrDefault

                If Comment IsNot Nothing Then

                    Replies = (From Entity In ConceptShareConnection.APIServiceClient.GetCommentThread(ConceptShareConnection.APIContext, AssetID, CommentID).ToList
                               Where Entity.CommentReplyId > 0
                               Select Entity).ToList

                    MarkupImage = ConceptShareConnection.APIServiceClient.DownloadMarkupImage(ConceptShareConnection.APIContext, CommentID, 500, 500)
                    Success = True

                End If

            End If

            LoadFullComment = Success

        End Function
        Public Function LoadCommentByCommentID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                               ProjectID As Integer, ReviewID As Integer, AssetID As Integer, CommentID As Integer) As AdvantageFramework.ConceptShareAPI.Comment

            'objects
            Dim ConceptShareComment As AdvantageFramework.ConceptShareAPI.Comment

            ConceptShareComment = Nothing

            If ConceptShareConnection.Loaded Then

                ConceptShareComment = (From Entity In ConceptShareConnection.APIServiceClient.GetCommentList(ConceptShareConnection.APIContext, AssetID, ReviewID).ToList
                                       Where Entity.Id = CommentID).FirstOrDefault

            End If

            LoadCommentByCommentID = ConceptShareComment

        End Function
        Public Function LoadAllReviewResponses(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                               ReviewID As Integer) As Generic.List(Of ConceptShareAPI.ReviewResponse)

            If ConceptShareConnection.Loaded Then

                LoadAllReviewResponses = ConceptShareConnection.APIServiceClient.GetReviewResponses(ConceptShareConnection.APIContext, ReviewID, Nothing, Nothing, Nothing).ToList

            Else

                Return Nothing

            End If

        End Function

        Public Function LoadCommentsForReviewAsset(ByVal ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                   ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal AlertID As Integer,
                                                   ByVal ReviewID As Integer,
                                                   ByVal AssetID As Integer,
                                                   ByVal Offset As Integer) As Generic.List(Of ConceptShareAPI.Comment)

            'objects
            Dim Comments As New Generic.List(Of ConceptShareAPI.Comment)
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim InfoLoaded As Boolean = False
            Dim UserCode As String = String.Empty
            Dim EmployeeCode As String = String.Empty
            Dim IsClientPortalUser As Boolean = False
            Dim ClientContactID As Integer = 0
            Dim ConceptShareUsers As Generic.List(Of ConceptShareUser) = Nothing
            Dim CommentConceptShareUser As ConceptShareUser = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AssetComments As Generic.List(Of ConceptShareAPI.Comment) = Nothing
            Dim StatusComments As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment) = Nothing

            If ConceptShareConnection.Loaded Then

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    Try

                        AssetComments = Nothing
                        AssetComments = (From Comment In ConceptShareConnection.APIServiceClient.GetCommentList(ConceptShareConnection.APIContext, AssetID, ReviewID).ToList
                                         Select Comment
                                         Order By Comment.DateCreated Descending).ToList

                        If AssetComments IsNot Nothing AndAlso AssetComments.Count > 0 Then

                            For Each AssetComment As ConceptShareAPI.Comment In AssetComments

                                If AssetComment.IsDraft = False OrElse (AssetComment.IsDraft = True AndAlso AssetComment.ReferenceId = ConceptShareConnection.ConceptShareUserID) Then

                                    Comments.Add(AssetComment)

                                    If InfoLoaded = False Then

                                        Try

                                            ConceptShareUsers = DbContext.Database.SqlQuery(Of ConceptShareUser)("EXEC [dbo].[advsp_cs_get_users];").ToList

                                        Catch ex As Exception
                                            ConceptShareUsers = Nothing
                                        End Try

                                        InfoLoaded = True

                                    End If

                                    AlertComment = Nothing
                                    AlertComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByConceptShareCommentID(DbContext, AssetComment.Id)

                                    CommentConceptShareUser = Nothing

                                    Try

                                        CommentConceptShareUser = (From Entity In ConceptShareUsers
                                                                   Where Entity.ConceptShareUserID = AssetComment.CreatedBy
                                                                   Select Entity).FirstOrDefault

                                    Catch ex As Exception
                                        CommentConceptShareUser = Nothing
                                    End Try
                                    If AlertComment Is Nothing And CommentConceptShareUser IsNot Nothing Then

                                        AlertComment = New AdvantageFramework.Database.Entities.AlertComment

                                        AlertComment.AlertID = Alert.ID

                                        If CommentConceptShareUser.IsClientContact IsNot Nothing AndAlso CommentConceptShareUser.IsClientContact = True Then

                                            AlertComment.UserCode = CommentConceptShareUser.UserCode

                                        Else

                                            If CommentConceptShareUser.ClientContactID IsNot Nothing Then

                                                AlertComment.ClientContactID = CommentConceptShareUser.ClientContactID

                                            End If

                                        End If

                                        AlertComment.GeneratedDate = AssetComment.DateCreated
                                        AlertComment.Comment = AssetComment.CommentData
                                        AlertComment.HasEmailBeenSent = False
                                        AlertComment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                                        AlertComment.AlertStateID = Alert.AlertStateID
                                        AlertComment.ConceptShareProjectID = Alert.ConceptShareProjectID
                                        AlertComment.ConceptShareReviewID = Alert.ConceptShareReviewID
                                        AlertComment.ConceptShareCommentID = AssetComment.Id

                                        AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

                                    End If

                                End If

                            Next

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        StatusComments = AdvantageFramework.Database.Procedures.AlertComment.LoadConceptShareStatusCommentsByAlertID(DbContext, Alert.ID).ToList

                        If StatusComments IsNot Nothing AndAlso StatusComments.Count > 0 Then

                            Dim CsComment As ConceptShareAPI.Comment = Nothing

                            For Each StatusComment As AdvantageFramework.Database.Entities.AlertComment In StatusComments

                                CsComment = Nothing
                                CsComment = New ConceptShareAPI.Comment

                                CsComment.CommentData = StatusComment.Comment
                                CsComment.DateCreated = StatusComment.GeneratedDate

                                Comments.Add(CsComment)

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                End If

            End If

            If Comments Is Nothing Then

                Comments = New List(Of ConceptShareAPI.Comment)

            Else

                Comments = (From Entity In Comments
                            Select Entity
                            Order By Entity.DateCreated Descending).ToList

            End If

            LoadCommentsForReviewAsset = Comments

        End Function


        'Public Function SyncLoadCommentsForReviewAsset(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
        '                                               ReviewID As Integer, AssetID As Integer) As Generic.List(Of ConceptShareAPI.Comment)

        '    'objects
        '    Dim Comments As New Generic.List(Of ConceptShareAPI.Comment)
        '    If ConceptShareConnection.Loaded Then

        '        Dim AssetComments As Generic.List(Of ConceptShareAPI.Comment)

        '        AssetComments = Nothing
        '        AssetComments = (From Comment In ConceptShareConnection.APIServiceClient.GetCommentList(ConceptShareConnection.APIContext, AssetID, ReviewID).ToList
        '                         Select Comment
        '                         Order By Comment.DateCreated Descending).ToList

        '        If AssetComments IsNot Nothing AndAlso AssetComments.Count > 0 Then

        '            For Each AssetComment As ConceptShareAPI.Comment In AssetComments

        '                If AssetComment.IsDraft = False OrElse (AssetComment.IsDraft = True AndAlso AssetComment.ReferenceId = ConceptShareConnection.ConceptShareUserID) Then

        '                    Comments.Add(AssetComment)

        '                End If

        '            Next

        '        End If

        '    End If

        '    SyncLoadCommentsForReviewAsset = Comments

        'End Function


        Public Function LoadAllReviewComments(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                              ReviewID As Integer) As Generic.List(Of ConceptShareAPI.Comment)

            'objects
            Dim Comments As New Generic.List(Of ConceptShareAPI.Comment)
            If ConceptShareConnection.Loaded Then

                Dim Assets As Generic.List(Of ConceptShareAPI.Asset)

                Assets = Nothing
                Assets = LoadReviewAssets(ConceptShareConnection, ReviewID)

                If Assets IsNot Nothing AndAlso Assets.Count > 0 Then

                    Dim AssetComments As Generic.List(Of ConceptShareAPI.Comment)

                    For Each Asset As ConceptShareAPI.Asset In Assets

                        AssetComments = Nothing
                        AssetComments = (From Comment In ConceptShareConnection.APIServiceClient.GetCommentList(ConceptShareConnection.APIContext, Asset.Id, ReviewID).ToList
                                         Select Comment
                                         Order By Comment.DateCreated Descending).ToList

                        If AssetComments IsNot Nothing AndAlso AssetComments.Count > 0 Then

                            For Each AssetComment As ConceptShareAPI.Comment In AssetComments

                                If AssetComment.IsDraft = False OrElse (AssetComment.IsDraft = True AndAlso AssetComment.ReferenceId = ConceptShareConnection.ConceptShareUserID) Then

                                    Comments.Add(AssetComment)

                                End If

                            Next

                        End If

                    Next

                End If

            End If

            LoadAllReviewComments = Comments

        End Function
        Public Function LoadDraftCommentsForEmployeeByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                               ReviewID As Integer) As Generic.List(Of ConceptShareAPI.CommentThread)

            Dim CommentThreads As Generic.List(Of ConceptShareAPI.CommentThread)

            CommentThreads = Nothing

            Try

                CommentThreads = (From Thread In LoadReviewCommentThreadListByReviewID(ConceptShareConnection, ReviewID)
                                  Where Thread.CreatedBy = ConceptShareConnection.ConceptShareUserID AndAlso Thread.IsDraft = True).ToList

            Catch ex As Exception
                CommentThreads = Nothing
            End Try

            LoadDraftCommentsForEmployeeByReviewID = CommentThreads

        End Function
        Public Function LoadReviewCommentThreadListByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                              ReviewID As Integer) As Generic.List(Of ConceptShareAPI.CommentThread)

            'objects
            Dim CommentThreads As New Generic.List(Of ConceptShareAPI.CommentThread)
            If ConceptShareConnection.Loaded Then

                Dim Assets As Generic.List(Of ConceptShareAPI.ReviewItem)

                Assets = Nothing
                Assets = ConceptShareConnection.APIServiceClient.GetReviewItemList(ConceptShareConnection.APIContext, ReviewID, Nothing).ToList

                If Assets IsNot Nothing AndAlso Assets.Count > 0 Then

                    Dim AssetIDs As Generic.List(Of Integer)

                    AssetIDs = (From Asset In Assets
                                Select Asset.AssetId).Distinct.ToList

                    If AssetIDs IsNot Nothing AndAlso AssetIDs.Count > 0 Then

                        Dim AssetCommentThreads As Generic.List(Of ConceptShareAPI.CommentThread)

                        For Each ID As Integer In AssetIDs

                            AssetCommentThreads = Nothing
                            AssetCommentThreads = ConceptShareConnection.APIServiceClient.GetCommentThreadList(ConceptShareConnection.APIContext, ID).OrderByDescending(Function(t) t.Id).ToList

                            If AssetCommentThreads IsNot Nothing AndAlso AssetCommentThreads.Count > 0 Then

                                For Each AssetCommentThread As ConceptShareAPI.CommentThread In AssetCommentThreads

                                    CommentThreads.Add(AssetCommentThread)

                                Next

                            End If

                        Next

                    End If

                End If

            End If

            LoadReviewCommentThreadListByReviewID = CommentThreads

        End Function

        Public Function SyncReviewToAlert(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                          ByVal ProjectID As Integer, ByVal ReviewID As Integer, ByVal AlertID As Integer,
                                          ByRef NewCommentCount As Integer, ByRef NewReplyCount As Integer,
                                          ByRef Session As AdvantageFramework.Security.Session,
                                          ByRef DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim ThreadableSync As New ThreadableSync(Session.ConnectionString, Session.UserCode)

            ThreadableSync.ConceptShareConnection = ConceptShareConnection
            ThreadableSync.ProjectID = ProjectID
            ThreadableSync.ReviewID = ReviewID
            ThreadableSync.AlertID = AlertID

            If Session.User IsNot Nothing Then
                ThreadableSync.EmployeeCode = Session.User.EmployeeCode
                ThreadableSync.EmployeeTimeOffset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Session.User.EmployeeCode)
            End If

            Dim SimpleConceptShareEmployeeList As Generic.List(Of AdvantageFramework.ConceptShare.SimpleConceptShareEmployee)

            Try

                SimpleConceptShareEmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadActiveConceptShareEmployees(DbContext, Session)
                                                  Select New AdvantageFramework.ConceptShare.SimpleConceptShareEmployee With {.EmployeeCode = Entity.Code,
                                                                                                                              .ConceptShareUserID = Entity.ConceptShareUserID}).ToList

            Catch ex As Exception
                SimpleConceptShareEmployeeList = Nothing
            End Try
            ThreadableSync.SimpleConceptShareEmployeeList = SimpleConceptShareEmployeeList

            ThreadableSync.SyncReviewToAlert()

            Return False

        End Function
        Public Function SyncReviewToAlert(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                          ByVal ProjectID As Integer, ByVal ReviewID As Integer, ByVal AlertID As Integer,
                                          ByRef NewCommentCount As Integer, ByRef NewReplyCount As Integer,
                                          ByRef Session As AdvantageFramework.Security.Session,
                                          ByRef DbContext As AdvantageFramework.Database.DbContext,
                                          ByRef ListOfConceptShareReviewers As Generic.List(Of AdvantageFramework.ConceptShare.SimpleConceptShareEmployee)) As Boolean

            Dim ThreadableSync As New ThreadableSync(Session.ConnectionString, Session.UserCode)

            ThreadableSync.ConceptShareConnection = ConceptShareConnection
            ThreadableSync.ProjectID = ProjectID
            ThreadableSync.ReviewID = ReviewID
            ThreadableSync.AlertID = AlertID
            ThreadableSync.SimpleConceptShareEmployeeList = ListOfConceptShareReviewers
            ThreadableSync.EmployeeCode = Session.User.EmployeeCode
            ThreadableSync.EmployeeTimeOffset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Session.User.EmployeeCode)

            ThreadableSync.SyncReviewToAlert()

            Return False

        End Function

        Public Sub SyncReviewToAlertComments(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                             ByVal ProjectID As Integer, ByVal ReviewID As Integer, ByVal AlertID As Integer,
                                             ByRef Session As AdvantageFramework.Security.Session,
                                             ByRef DbContext As AdvantageFramework.Database.DbContext)

            Dim ThreadableSync As New ThreadableSync(Session.ConnectionString, Session.UserCode)

            ThreadableSync.ConceptShareConnection = ConceptShareConnection
            ThreadableSync.ProjectID = ProjectID
            ThreadableSync.ReviewID = ReviewID
            ThreadableSync.AlertID = AlertID
            ThreadableSync.EmployeeCode = Session.User.EmployeeCode
            ThreadableSync.EmployeeTimeOffset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Session.User.EmployeeCode)

            ThreadableSync.SyncReviewCommentsByID()

        End Sub

        Public Function EmailExternalUsers(ByRef ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                           ByVal ProjectID As Integer, ByVal ReviewID As Integer, ByVal AlertID As Integer,
                                           ByRef NewCommentCount As Integer, ByRef NewReplyCount As Integer,
                                           ByRef Session As AdvantageFramework.Security.Session,
                                           ByRef DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim ThreadableSync As New ThreadableSync(Session.ConnectionString, Session.UserCode)

            ThreadableSync.ConceptShareConnection = ConceptShareConnection
            ThreadableSync.ProjectID = ProjectID
            ThreadableSync.ReviewID = ReviewID
            ThreadableSync.AlertID = AlertID
            ThreadableSync.EmployeeCode = Session.User.EmployeeCode
            ThreadableSync.EmployeeTimeOffset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Session.User.EmployeeCode)

            ThreadableSync.SyncReviewToAlert()

            Return False

        End Function

        Public Function CheckForReply(ByVal CommentID As Integer, ByRef CommentThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)) As Boolean

            Try

                Return (From Entity In CommentThreads Where Entity.Id = CommentID AndAlso Entity.CommentReplyId > 0).Count > 0

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function AddCommentReply(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                        CommentID As Integer, IsDraft As Boolean, Comment As String) As AdvantageFramework.ConceptShareAPI.CommentReply

            If ConceptShareConnection.Loaded Then

                AddCommentReply = ConceptShareConnection.APIServiceClient.AddCommentReply(ConceptShareConnection.APIContext, CommentID, IsDraft, Comment)

            Else

                AddCommentReply = Nothing

            End If

        End Function

        'Public Function CheckForApprovedResponses(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '                                          ByVal ReviewResponses As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewResponse),
        '                                          ByRef Alert As AdvantageFramework.Database.Entities.Alert,
        '                                          ByVal ConceptShareUsers As Generic.List(Of ConceptShareUser)) As Boolean

        '    Dim HasApproved As Boolean = False
        '    Dim CurrentRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
        '    Dim CommentConceptShareUser As ConceptShareUser = Nothing
        '    Dim Message As String = String.Empty

        '    If ReviewResponses IsNot Nothing AndAlso ReviewResponses.Count > 0 Then

        '        Dim ApprovedReviewResponses As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewResponse) = Nothing

        '        ApprovedReviewResponses = (From Entity In ReviewResponses
        '                                   Where Entity.StatusCode = "APPROVED"
        '                                   Select Entity).ToList

        '        If ApprovedReviewResponses IsNot Nothing AndAlso ApprovedReviewResponses.Count > 0 Then


        '            For Each ApprovedResponse As AdvantageFramework.ConceptShareAPI.ReviewResponse In ApprovedReviewResponses

        '                CurrentRecipient = Nothing
        '                CommentConceptShareUser = Nothing

        '                Try

        '                    If ConceptShareUsers IsNot Nothing Then

        '                        CommentConceptShareUser = (From Entity In ConceptShareUsers
        '                                                   Where Entity.ConceptShareUserID = ApprovedResponse.ReferenceId
        '                                                   Select Entity).FirstOrDefault

        '                    End If

        '                Catch ex As Exception
        '                    CommentConceptShareUser = Nothing
        '                End Try
        '                If CommentConceptShareUser IsNot Nothing Then

        '                    CurrentRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDEmployeeCodeTemplateState(DbContext, Alert, CommentConceptShareUser.EmployeeCode)

        '                    If CurrentRecipient IsNot Nothing Then

        '                        AdvantageFramework.ConceptShare.ApproveAssignee(DbContext, con
        '                                                                        Alert,
        '                                                                        CommentConceptShareUser.UserCode,
        '                                                                        CommentConceptShareUser.EmployeeCode,
        '                                                                        Message)
        '                        HasApproved = True

        '                    End If

        '                End If

        '            Next

        '        End If

        '    End If

        '    Return HasApproved

        'End Function

#End Region

#Region " Review Members "

        'Public Function LoadProjectResources()

        'End Function
        Public Function LoadReviewResponses(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                   ReviewID As Integer) As Generic.List(Of ConceptShareAPI.ReviewResponse)
            If ConceptShareConnection.Loaded Then

                LoadReviewResponses = ConceptShareConnection.APIServiceClient.GetReviewResponses(ConceptShareConnection.APIContext, ReviewID, Nothing, Nothing, Nothing).ToList

            Else

                LoadReviewResponses = Nothing

            End If

        End Function
        Public Function LoadReviewMembersByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                   ReviewID As Integer) As Generic.List(Of ConceptShareAPI.ReviewMember)

            If ConceptShareConnection.Loaded Then

                LoadReviewMembersByReviewID = ConceptShareConnection.APIServiceClient.GetReviewMemberList(ConceptShareConnection.APIContext, ReviewID).ToList

            Else

                LoadReviewMembersByReviewID = Nothing

            End If

        End Function
        Public Function LoadExternalReviewMembersByReviewID(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                   ReviewID As Integer) As Generic.List(Of ConceptShareAPI.ReviewMember)

            If ConceptShareConnection.Loaded Then

                LoadExternalReviewMembersByReviewID = ConceptShareConnection.APIServiceClient.GetReviewMemberList(ConceptShareConnection.APIContext, ReviewID).ToList

                LoadExternalReviewMembersByReviewID = (From Entity In LoadExternalReviewMembersByReviewID
                                                       Where Entity.ExternalReviewer = True).ToList

            Else

                LoadExternalReviewMembersByReviewID = Nothing

            End If

        End Function

        Public Function LoadReviewMembersByReviewIDWithImage(Session As AdvantageFramework.Security.Session, EmployeeCode As String,
                                                             ReviewID As Integer) As Generic.IEnumerable(Of Object)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Dim Employee As AdvantageFramework.Database.Views.Employee

                    Employee = Nothing
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        'objects
                        Dim APIServiceClient As ConceptShareAPI.APIServiceClient = Nothing
                        Dim APIContext As ConceptShareAPI.APIContext = Nothing
                        Dim User As ConceptShareAPI.User = Nothing

                        If CreateUserConecptShareConnection(DataContext, Employee, APIServiceClient, APIContext, User) Then

                            Dim ReviewMembers As Generic.List(Of ConceptShareAPI.ReviewMember)

                            ReviewMembers = Nothing
                            ReviewMembers = APIServiceClient.GetReviewMemberList(APIContext, ReviewID).ToList

                            LoadReviewMembersByReviewIDWithImage = (From Entity In ReviewMembers
                                                                    Join Emps In DbContext.Employees On Entity.Id Equals Emps.ConceptShareUserID
                                                                    Join EmpPics In DbContext.EmployeePictures On Emps.Code Equals EmpPics.EmployeeCode
                                                                    Select New With {.FullName = Entity.Name,
                                                                         .Picture = EmpPics.Image,
                                                                         .Status = Entity.StatusName})


                        Else

                            LoadReviewMembersByReviewIDWithImage = Nothing

                        End If

                    Else

                        LoadReviewMembersByReviewIDWithImage = Nothing

                    End If

                End Using
            End Using

        End Function
        Public Function AddUpdateReviewMember(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                              ReviewID As Integer, UserID As Integer) As ConceptShareAPI.ReviewMember

            If ConceptShareConnection.Loaded AndAlso ConceptShareConnection.IsClientPortalUser = False Then

                Try

                    AddUpdateReviewMember = ConceptShareConnection.APIServiceClient.AddUpdateReviewMember(ConceptShareConnection.APIContext, ReviewID,
                                                                                                          UserID, ConceptShareAPI.ReferenceType.User,
                                                                                                          Nothing,
                                                                                                          ConceptShareConnection.AdvantageEmployeeCodeOrClientPortalUserID,
                                                                                                          Nothing, AdminReviewRoleID, Nothing)

                Catch ex As Exception
                    AddUpdateReviewMember = Nothing
                End Try

            Else

                AddUpdateReviewMember = Nothing

            End If

        End Function
        Public Function RemoveReviewMember(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                           ReviewID As Integer, UserID As Integer) As ConceptShareAPI.ReviewMember

            Dim ErrorMessage As String = String.Empty
            Try

                If ConceptShareConnection.Loaded AndAlso ConceptShareConnection.IsClientPortalUser = False Then

                    RemoveReviewMember = ConceptShareConnection.APIServiceClient.RemoveReviewMember(ConceptShareConnection.APIContext, ReviewID,
                                                                                                    UserID, ConceptShareAPI.ReferenceType.User)

                Else

                    RemoveReviewMember = Nothing

                End If

            Catch ex As System.ServiceModel.FaultException
                ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
                Return Nothing
            End Try

        End Function


#End Region

#Region " Activity Feed "

        Public Function GenerateReviewFeedbackSummary(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                      ProjectID As Integer,
                                                      ReviewID As Integer,
                                                      EmailAddress As String,
                                                      Subject As String, AlertID As Integer) As Byte()

            Dim FeedBackSummary As Byte()
            Dim EmailReports As New Generic.List(Of ConceptShareAPI.EmailReport)
            Dim FeedbackSummaryOptions As New ConceptShareAPI.FeedbackSummaryOptions
            Dim SummaryOptions As New ConceptShareAPI.SummaryOptions
            Dim AssetOptions As New ConceptShareAPI.AssetOptions
            Dim FeedbackOptions As New ConceptShareAPI.FeedbackOptions
            Dim EmailReport As New ConceptShareAPI.EmailReport
            Dim EmailReportAddress As New ConceptShareAPI.EmailReportAddress

            EmailReportAddress.EmailAddress = EmailAddress
            EmailReportAddress.Name = EmailAddress

            EmailReport.Subject = String.Format("[ReviewID:  {0}] - {1}", ReviewID, Subject)
            'EmailReport.Message = String.Format("Filename:  {0}<br/><br/>AlertID:  {1}<br/><br/>ReviewID:  {2}", Subject, AlertID, ReviewID)
            EmailReport.Message = String.Format("AlertID:  {0}" & Environment.NewLine, AlertID)
            EmailReport.Message &= String.Format("ReviewID:  {0}" & Environment.NewLine, ReviewID)
            EmailReport.Message &= String.Format("Filename:  {0}" & Environment.NewLine, Subject)

            EmailReport.Recipients = {EmailReportAddress}

            EmailReports.Add(EmailReport)

            SummaryOptions.BreakPageOnAsset = True
            SummaryOptions.IncludeAssetsWithoutFeedback = True
            SummaryOptions.IncludeCoverPage = False
            SummaryOptions.IncludeDeletedAssets = False
            SummaryOptions.IncludePageNumbers = True

            FeedbackOptions.OnlyFeedbackWithReferenceLinks = False
            FeedbackOptions.OnlyFeedbackWithReplies = False
            FeedbackOptions.OnlyUnreadFeedback = False

            AssetOptions.BreakPageOnFeedback = True
            AssetOptions.IncludeGeneralComments = True
            AssetOptions.IncludeReviews = True
            AssetOptions.IncludeUploadInformation = True
            AssetOptions.IncludeVersions = True
            'AssetOptions.IncludeChangeRequests = False
            AssetOptions.IncludeCustomForms = False
            AssetOptions.IncludeFolderPath = False

            FeedbackSummaryOptions.ProjectId = ProjectID
            FeedbackSummaryOptions.ReviewId = ReviewID
            FeedbackSummaryOptions.SummaryOptions = SummaryOptions
            FeedbackSummaryOptions.AssetOptions = AssetOptions
            FeedbackSummaryOptions.DeliveryOptions = ConceptShareAPI.DeliveryOptions.EmailMe
            FeedbackSummaryOptions.SortFeedbackBy = ConceptShareAPI.FeedbackSortType.DateCreated
            FeedbackSummaryOptions.FeedbackEmails = EmailReports.ToArray
            FeedbackSummaryOptions.FeedbackOptions = FeedbackOptions

            FeedBackSummary = ConceptShareConnection.APIServiceClient.GenerateFeedbackSummary(ConceptShareConnection.APIContext, FeedbackSummaryOptions)

            Return FeedBackSummary

        End Function
        Public Function GenerateReviewFeedbackSummary(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                      ProjectID As Integer, ReviewID As Integer) As Byte()

            Dim FeedBackSummary As Byte()

            Dim EmailReports As New Generic.List(Of ConceptShareAPI.EmailReport)
            Dim FeedbackSummaryOptions As New ConceptShareAPI.FeedbackSummaryOptions
            Dim SummaryOptions As New ConceptShareAPI.SummaryOptions
            Dim AssetOptions As New ConceptShareAPI.AssetOptions
            Dim FeedbackOptions As New ConceptShareAPI.FeedbackOptions

            SummaryOptions.BreakPageOnAsset = True
            SummaryOptions.IncludeAssetsWithoutFeedback = True
            SummaryOptions.IncludeCoverPage = False
            SummaryOptions.IncludeDeletedAssets = False
            SummaryOptions.IncludePageNumbers = True

            FeedbackOptions.OnlyFeedbackWithReferenceLinks = False
            FeedbackOptions.OnlyFeedbackWithReplies = False
            FeedbackOptions.OnlyUnreadFeedback = False

            AssetOptions.BreakPageOnFeedback = True
            AssetOptions.IncludeGeneralComments = True
            AssetOptions.IncludeReviews = True
            AssetOptions.IncludeUploadInformation = True
            AssetOptions.IncludeVersions = True
            'AssetOptions.IncludeChangeRequests = False
            AssetOptions.IncludeCustomForms = False
            AssetOptions.IncludeFolderPath = False

            FeedbackSummaryOptions.ProjectId = ProjectID
            FeedbackSummaryOptions.ReviewId = ReviewID
            FeedbackSummaryOptions.SummaryOptions = SummaryOptions
            FeedbackSummaryOptions.AssetOptions = AssetOptions
            FeedbackSummaryOptions.DeliveryOptions = ConceptShareAPI.DeliveryOptions.Download
            FeedbackSummaryOptions.SortFeedbackBy = ConceptShareAPI.FeedbackSortType.DateCreated
            FeedbackSummaryOptions.FeedbackEmails = EmailReports.ToArray
            FeedbackSummaryOptions.FeedbackOptions = FeedbackOptions

            FeedBackSummary = ConceptShareConnection.APIServiceClient.GenerateFeedbackSummary(ConceptShareConnection.APIContext, FeedbackSummaryOptions)

            Return FeedBackSummary

        End Function

#End Region

#Region " External Users "

        Public Function AddUpdateExternalReviewer(ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                                  ReviewID As Integer,
                                                  EmailAddress As String, FirstName As String, LastName As String,
                                                  ByRef ErrorMessage As String) As ConceptShareAPI.ReviewMember
            Try

                If ConceptShareConnection.Loaded = True Then

                    EmailAddress = EmailAddress.Trim
                    FirstName = FirstName.Trim
                    LastName = LastName.Trim

                    AddUpdateExternalReviewer = ConceptShareConnection.APIServiceClient.AddUpdateExternalReviewer(ConceptShareConnection.APIContext, ReviewID, EmailAddress, FirstName, LastName, AdminReviewRoleID)

                Else

                    AddUpdateExternalReviewer = Nothing

                End If

            Catch ex As System.ServiceModel.FaultException
                ErrorMessage = String.Format("API ERROR!  CODE:{0}:ERROR:{1}", ex.Code.Name, ex.Message)
                Return Nothing
            End Try

        End Function
        Public Sub AddUpdateEmailExternalReviewer(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer, ByVal AlertID As Integer,
                                                  ByRef ExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember,
                                                  ByVal EmailSent As Boolean)

            Dim ConceptShareExternalReviewer As AdvantageFramework.Database.Entities.ConceptShareExternalReviewer = Nothing

            ConceptShareExternalReviewer = AdvantageFramework.Database.Procedures.ConceptShareExternalReviewer.LoadByEmailAddressAndReviewID(DbContext, ConceptShareReviewID, ExternalReviewer.UserName)

            If ConceptShareExternalReviewer IsNot Nothing Then

                If EmailSent = True Then ConceptShareExternalReviewer.LastEmailed = CType(Now.Date, DateTime)
                AdvantageFramework.Database.Procedures.ConceptShareExternalReviewer.Update(DbContext, ConceptShareExternalReviewer)

            Else

                Dim FirstName As String = String.Empty
                Dim LastName As String = String.Empty

                ConceptShareExternalReviewer = New AdvantageFramework.Database.Entities.ConceptShareExternalReviewer

                ConceptShareExternalReviewer.AlertID = AlertID
                ConceptShareExternalReviewer.ConceptShareReviewID = ConceptShareReviewID

                If ExternalReviewer IsNot Nothing Then

                    ConceptShareExternalReviewer.ConceptShareUserID = ExternalReviewer.ReferenceId
                    ConceptShareExternalReviewer.EmailAddress = ExternalReviewer.UserName

                End If

                ParseFirstAndLastName(ExternalReviewer.Name, FirstName, LastName)

                ConceptShareExternalReviewer.FirstName = FirstName
                ConceptShareExternalReviewer.LastName = LastName
                If EmailSent = True Then ConceptShareExternalReviewer.LastEmailed = CType(Now.Date, DateTime)

                AdvantageFramework.Database.Procedures.ConceptShareExternalReviewer.Insert(DbContext, ConceptShareExternalReviewer)

            End If

        End Sub
        Public Sub ParseFirstAndLastName(ByVal FullName As String, ByRef FirstName As String, ByRef LastName As String)

            Dim Name As Generic.List(Of String)
            Dim i As Integer = 0

            Name = Nothing

            Try

                Name = FullName.Split(" ").ToList

            Catch ex As Exception
                Name = Nothing
            End Try
            Try

                If Name IsNot Nothing AndAlso Name.Count > 0 Then

                    For Each NamePiece As String In Name

                        If i = 0 Then

                            FirstName = NamePiece

                        ElseIf i = 1 Then

                            LastName = NamePiece

                        ElseIf i > 1 Then

                            LastName &= " " & NamePiece

                        End If

                        i += 1

                    Next

                End If

            Catch ex As Exception
                FirstName = "External Reviewer"
                LastName = "External Reviewer"
            End Try

        End Sub

#End Region

        Public Function LoadFeedbackSummaryLog(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog)

            Dim Log As Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog) = Nothing

            Try

                Log = DbContext.Database.SqlQuery(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog)(String.Format("EXEC [dbo].[advsp_proofing_get_cs_feedback_log];")).ToList()

            Catch ex As Exception
                Log = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If Log Is Nothing Then Log = New List(Of ConceptShareFeedbackLog)

            Return Log

        End Function
        Public Function LoadAssetBackupStats(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SecuritySession As AdvantageFramework.Security.Session,
                                             ByRef ErrorMessage As String) As BackupStats

            Dim Stats As BackupStats = Nothing
            Dim AssetCount As Integer = 0

            Try

                Stats = DbContext.Database.SqlQuery(Of BackupStats)(String.Format("EXEC [dbo].[advsp_proofing_load_cs_backup_counts];")).SingleOrDefault()

            Catch ex As Exception
                Stats = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If Stats Is Nothing Then Stats = New BackupStats

            Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim ReviewInfos As Generic.List(Of ReviewInfo) = Nothing

                Try

                    ReviewInfos = DbContext.Database.SqlQuery(Of ReviewInfo)(String.Format("SELECT [AlertID] = ALERT_ID, [ProjectID] = CS_PROJECT_ID, [ReviewID] = CS_REVIEW_ID FROM ALERT A WITH(NOLOCK) WHERE IS_CS_REVIEW = 1;")).ToList()

                Catch ex As Exception
                    ReviewInfos = Nothing
                End Try
                If ReviewInfos IsNot Nothing AndAlso ReviewInfos.Count > 0 Then

                    Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                    Dim Result As BackupReviewResult = Nothing
                    Dim BackupSuccess As Boolean = False
                    Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset) = Nothing

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    ConceptShareConnection = Nothing
                    ConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext)

                    If ConceptShareConnection IsNot Nothing Then

                        For Each Review As ReviewInfo In ReviewInfos

                            Assets = Nothing

                            Try

                                Assets = AdvantageFramework.ConceptShare.LoadReviewAssets(ConceptShareConnection, Review.ReviewID)

                            Catch ex As Exception
                                Assets = Nothing
                            End Try

                            If Assets IsNot Nothing AndAlso Assets.Count > 0 Then

                                AssetCount += Assets.Count

                            End If

                        Next

                        Stats.TotalAssetsCS = AssetCount

                    End If

                End If

            End Using

            Return Stats

        End Function

#End Region

    End Module

    <Serializable()>
    Public Class ThreadableAssetBackup

        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing


        Public Sub BackupAllReviews()

            Dim SyncThreadStart As New ParameterizedThreadStart(AddressOf Me._BackupAllReviews)
            Dim SyncThread As New Thread(SyncThreadStart)
            SyncThread.Start()

        End Sub
        Private Sub _BackupAllReviews()

            Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    Dim ReviewInfos As Generic.List(Of ReviewInfo) = Nothing

                    Try

                        ReviewInfos = DbContext.Database.SqlQuery(Of ReviewInfo)(String.Format("SELECT [AlertID] = ALERT_ID, [ProjectID] = CS_PROJECT_ID, [ReviewID] = CS_REVIEW_ID FROM ALERT A WITH(NOLOCK) WHERE IS_CS_REVIEW = 1;")).ToList()

                    Catch ex As Exception
                        ReviewInfos = Nothing
                    End Try

                    If ReviewInfos IsNot Nothing AndAlso ReviewInfos.Count > 0 Then

                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                        Dim Result As BackupReviewResult = Nothing
                        Dim BackupSuccess As Boolean = False

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = New AdvantageFramework.ConceptShare.Classes.ConceptShareConnection(DataContext)

                        If ConceptShareConnection IsNot Nothing Then

                            For Each Review As ReviewInfo In ReviewInfos

                                Result = Nothing
                                Result = New BackupReviewResult

                                BackupReviewAssetByID(DbContext, DataContext, ConceptShareConnection, Agency, Review, Result)

                            Next

                        End If

                    End If

                End Using

            End Using

        End Sub
        Private Sub BackupReviewAssetByID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal DataContext As AdvantageFramework.Database.DataContext,
                                          ByVal ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection,
                                          ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                          ByVal Review As ReviewInfo,
                                          ByRef Result As BackupReviewResult)

            Dim Success As Boolean = False
            Dim Assets As Generic.List(Of AdvantageFramework.ConceptShareAPI.Asset) = Nothing
            Dim OkayToUpload As Boolean = True
            Dim AlertController = New AdvantageFramework.Controller.Desktop.AlertController(_SecuritySession)
            Dim FinalLevel As String = "Job,Job Component"
            Dim FinalLevelDetail As String = "Job,Job Component:{0},{1}"
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            If Result Is Nothing Then Result = New BackupReviewResult

            Result.Review = Review

            Try

                Assets = AdvantageFramework.ConceptShare.LoadReviewAssets(ConceptShareConnection, Review.ReviewID)

            Catch ex As Exception
                Assets = Nothing
            End Try
            If Assets IsNot Nothing Then

                For Each Asset As AdvantageFramework.ConceptShareAPI.Asset In Assets

                    If BackItUp(DbContext, Review.AlertID, Review.ReviewID, Asset.Id) = True Then

                        Success = False

                        Try

                            Dim FileBytes() As Byte = AdvantageFramework.ConceptShare.DownloadAsset(ConceptShareConnection, Asset.Id)
                            Dim FullPathToRepositoryDoc As String = String.Empty
                            Dim RepositoryFilename As String = String.Empty
                            Dim Filename As String = String.Empty

                            If FileBytes IsNot Nothing AndAlso FileBytes.Length > 0 Then

                                If AdvantageFramework.FileSystem.Add(Agency, "", Asset.FileName, "", _SecuritySession.UserCode,
                                                             FinalLevel, String.Format(FinalLevelDetail, Review.JobNumber, Review.JobComponentNumber),
                                                             AdvantageFramework.FileSystem.Methods.DocumentSource.Alert,
                                                             FullPathToRepositoryDoc, FileBytes, RepositoryFilename, Nothing) Then

                                    Dim FileInfo = New System.IO.FileInfo(FullPathToRepositoryDoc)

                                    'Add to document table
                                    Document = New AdvantageFramework.Database.Entities.Document

                                    Document.FileSystemFileName = RepositoryFilename
                                    Document.FileName = Asset.FileName
                                    Document.Description = Nothing
                                    Document.Keywords = Nothing
                                    Document.MIMEType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(Asset.OriginalExtension)
                                    Document.UploadedDate = Now
                                    Document.UserCode = _SecuritySession.UserCode
                                    Document.FileSize = FileInfo.Length
                                    Document.IsPrivate = Nothing
                                    Document.DocumentTypeID = 2 'file

                                    Try

                                        Document.ID = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                       Select Entity.ID).Max + 1

                                    Catch ex As Exception
                                        Document.ID = 1
                                    End Try
                                    If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                        If Document.FileName.ToLower.EndsWith("png") OrElse Document.FileName.ToLower.EndsWith("bmp") OrElse
                                                    Document.FileName.ToLower.EndsWith("tiff") OrElse Document.FileName.ToLower.EndsWith("gif") OrElse
                                                    Document.FileName.ToLower.EndsWith("jpeg") OrElse Document.FileName.ToLower.EndsWith("jpg") Then

                                            AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, Document.ID, Nothing)

                                        End If

                                        If AdvantageFramework.DocumentManager.AddAlertAttachment(DbContext, Review.AlertID, Document.ID) = True Then

                                            Try
                                                AdvantageFramework.DocumentManager.AddJobComponentDocument(DataContext, Review.JobNumber,
                                                                                                   Review.JobComponentNumber, Document.ID)
                                            Catch ex As Exception
                                            End Try

                                        End If

                                    End If

                                End If

                            End If

                            Success = True

                        Catch ex As Exception
                            Success = False
                        End Try

                        LogBackup(DbContext, Review.AlertID, Review.ProjectID, Review.ReviewID, Asset.Id, Document.ID, Asset.FileName, Success)

                    End If

                Next

            End If

        End Sub
        Private Function BackItUp(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                  ByVal AlertID As Integer,
                                  ByVal ReviewID As Integer,
                                  ByVal AssetID As Integer) As Boolean

            Dim YesBackItUp As Boolean = False
            Dim RecExists As Integer = 0

            Try

                RecExists = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM CS_BACKUP_LOG C WITH(NOLOCK) WHERE C.AlertID = {0} AND C.ReviewID = {1} AND C.AssetID = {2};",
                                                                                  AlertID, ReviewID, AssetID)).SingleOrDefault()

            Catch ex As Exception
                RecExists = -1
            End Try

            If RecExists = 0 Then

                YesBackItUp = True

            End If

            Return YesBackItUp

        End Function
        Private Sub LogBackup(ByVal DbContext As AdvantageFramework.Database.DbContext,
                              ByVal AlertID As Integer, ByVal ProjectID As Integer, ByVal ReviewID As Integer,
                              ByVal AssetID As Integer, ByVal DocumentID As Integer,
                              ByVal Filename As String,
                              ByVal BackedUp As Boolean)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO CS_BACKUP_LOG (AlertID, ProjectID, ReviewID, AssetID, DocumentID, Filename, BackedUp) VALUES ({0}, {1}, {2}, {3}, {4}, '{5}', {6});",
                                                                   AlertID,
                                                                   ProjectID,
                                                                   ReviewID,
                                                                   AssetID,
                                                                   DocumentID,
                                                                   Filename,
                                                                   If(BackedUp = True, 1, 0)))

            Catch ex As Exception
            End Try

        End Sub
        Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession

        End Sub

    End Class

    <Serializable()>
    Public Class ThreadableSync

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _DbContext As AdvantageFramework.Database.DbContext
        Private Property _ConnectionString As String
        Private Property _UserCode As String

        Public Property EmployeeCode As String
        Public Property EmployeeTimeOffset As Decimal = 0.0

        Public Property ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        Public Property ProjectID As Integer = 0
        Public Property ReviewID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property NewCommentCount As Integer = 0
        Public Property NewReplyCount As Integer = 0

        Public Property SimpleConceptShareEmployeeList As Generic.List(Of AdvantageFramework.ConceptShare.SimpleConceptShareEmployee)

        Public Property ER_Subject As String = "Request Review"
        Public Property ER_Body As String = "Here's your stupid link:  {0}"
        Public Property ER_CC As String = ""
        Public Property ER_BCC As String = ""

#End Region

#Region " Methods "

#Region " Sync "

        Public Sub SyncFromCard(ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                ByRef ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary)

            Dim Offset As Decimal = 0

            _SyncReviewComments(Alert, ReviewSummary, Offset)

        End Sub
        Public Sub SyncReviewToAlert()

            'Dim SyncThreadStart As New ParameterizedThreadStart(AddressOf Me._SyncReviewToAlert)
            'Dim SyncThread As New Thread(SyncThreadStart)
            'SyncThread.Start()
            _SyncReviewToAlert()

        End Sub
        Private Sub _SyncReviewToAlert()

            Try

                Dim CommentsUpdated As Boolean = False
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary = Nothing

                Alert = Nothing
                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(_DbContext, AlertID)

                ReviewSummary = Nothing
                ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(ConceptShareConnection, ReviewID)

                CommentsUpdated = _SyncReviewComments(Alert, ReviewSummary, EmployeeTimeOffset)

                Dim SyncImage As Boolean = False
                Dim AlertSynced As Boolean = False
                Dim Sent As Boolean = False

                If Alert IsNot Nothing AndAlso ReviewSummary IsNot Nothing Then

                    SyncImage = _SyncReviewImage(Alert, ReviewSummary)

                    'Sync stats
                    Try
                        If (ReviewSummary.Review.StatusId IsNot Nothing AndAlso Alert.ConceptShareReviewStatusID IsNot Nothing AndAlso ReviewSummary.Review.StatusId <> Alert.ConceptShareReviewStatusID) OrElse
                                               (ReviewSummary.Review.StatusId Is Nothing AndAlso Alert.ConceptShareReviewStatusID IsNot Nothing) OrElse
                                               (ReviewSummary.Review.StatusId IsNot Nothing AndAlso Alert.ConceptShareReviewStatusID Is Nothing) Then

                            Alert.ConceptShareReviewStatusID = ReviewSummary.Review.StatusId
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (Alert.ConceptShareNumberOfReviewers IsNot Nothing AndAlso ReviewSummary.ReviewerCount <> Alert.ConceptShareNumberOfReviewers) OrElse
                                           (ReviewSummary.ReviewerCount <> 0 AndAlso Alert.ConceptShareNumberOfReviewers Is Nothing) Then

                            Alert.ConceptShareNumberOfReviewers = ReviewSummary.ReviewerCount
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (Alert.ConceptShareNumberOfCompletedReviewers IsNot Nothing AndAlso ReviewSummary.CompletedReviewerCount <> Alert.ConceptShareNumberOfCompletedReviewers) OrElse
                                           (ReviewSummary.CompletedReviewerCount <> 0 AndAlso Alert.ConceptShareNumberOfCompletedReviewers Is Nothing) Then

                            Alert.ConceptShareNumberOfCompletedReviewers = ReviewSummary.CompletedReviewerCount
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (Alert.ConceptShareNumberOfApprovedReviewers IsNot Nothing AndAlso ReviewSummary.ApprovedReviewerCount <> Alert.ConceptShareNumberOfApprovedReviewers) OrElse
                                           (ReviewSummary.ApprovedReviewerCount <> 0 AndAlso Alert.ConceptShareNumberOfApprovedReviewers Is Nothing) Then

                            Alert.ConceptShareNumberOfApprovedReviewers = ReviewSummary.ApprovedReviewerCount
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (Alert.ConceptShareNumberOfRejectedReviewers IsNot Nothing AndAlso ReviewSummary.RejectedReviewerCount <> Alert.ConceptShareNumberOfRejectedReviewers) OrElse
                                           (ReviewSummary.RejectedReviewerCount <> 0 AndAlso Alert.ConceptShareNumberOfRejectedReviewers Is Nothing) Then

                            Alert.ConceptShareNumberOfRejectedReviewers = ReviewSummary.RejectedReviewerCount
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If (Alert.ConceptShareNumberOfDeferredReviewers IsNot Nothing AndAlso ReviewSummary.DeferredReviewerCount <> Alert.ConceptShareNumberOfDeferredReviewers) OrElse
                                           (ReviewSummary.DeferredReviewerCount <> 0 AndAlso Alert.ConceptShareNumberOfDeferredReviewers Is Nothing) Then

                            Alert.ConceptShareNumberOfDeferredReviewers = ReviewSummary.DeferredReviewerCount
                            AlertSynced = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try

                        If ReviewSummary.ReviewerCount = ReviewSummary.ApprovedReviewerCount Then

                            If Alert.AssignmentCompleted Is Nothing OrElse Alert.AssignmentCompleted = False Then

                                Alert.AssignmentCompleted = True
                                AlertSynced = True

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                    'Update alert record
                    If AlertSynced = True OrElse SyncImage = True Then

                        Alert.AlertCategoryID = 67

                        If AdvantageFramework.Database.Procedures.Alert.Update(_DbContext, Alert) = True Then


                        End If

                    End If

                    SyncReviewReviewersToAlertRecipients(Alert.ID)

                End If

            Catch ex As Exception
            End Try

        End Sub

        Public Sub SyncReviewCommentsByID()

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary = Nothing

            Alert = Nothing
            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(_DbContext, AlertID)

            ReviewSummary = Nothing
            ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(ConceptShareConnection, ReviewID)

            Dim SyncReviewCommentsThread = New Thread(Sub() Me._SyncReviewComments(Alert, ReviewSummary, EmployeeTimeOffset))

        End Sub
        Public Sub SyncReviewComments(ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                      ByVal ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary)

            Dim SyncReviewCommentsThread = New Thread(Sub() Me._SyncReviewComments(Alert, ReviewSummary, EmployeeTimeOffset))

        End Sub
        Private Function _SyncReviewComments(ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByRef ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary,
                                             ByVal Offset As Decimal) As Boolean

            Dim CommentsUpdated As Boolean = False

            If Alert IsNot Nothing AndAlso ReviewSummary IsNot Nothing Then

                Dim ConceptShareComments As Generic.List(Of AdvantageFramework.ConceptShareAPI.Comment)
                Dim ConceptShareThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread) = Nothing
                Dim AlertComments As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment) = Nothing
                Dim CommentStatus As String = String.Empty
                Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
                Dim AlertCommentConceptShareCommentIDs As Generic.List(Of Integer?) = Nothing
                Dim ConceptShareCommentIDs As Generic.List(Of Integer) = Nothing
                Dim UserCode As String = String.Empty
                Dim EmployeeCode As String = String.Empty
                Dim IsClientPortalUser As Boolean = False
                Dim ClientContactID As Integer = 0
                Dim IsExternalUser As Boolean = False
                Dim ReviewResponses As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewResponse) = Nothing
                Dim MissingComments As Generic.List(Of AdvantageFramework.ConceptShareAPI.Comment) = Nothing
                Dim CommentIDs As String = String.Empty
                Dim ConceptShareUsers As Generic.List(Of ConceptShareUser) = Nothing
                Dim CommentConceptShareUser As ConceptShareUser = Nothing
                Dim HasDismissed As Boolean = False
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim OpenRecord As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                Dim DismissedRecord As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
                Dim StatusText = String.Empty
                Dim Message As String = String.Empty
                Dim CommentEntity As AdvantageFramework.Database.Entities.AlertComment = Nothing
                Dim RightNow As DateTime = Now
                Dim ResponseActionTaken As Boolean = False

                ConceptShareComments = New List(Of ConceptShareAPI.Comment)
                ReviewResponses = Nothing

                Try

                    ReviewResponses = ConceptShareConnection.APIServiceClient.GetReviewResponses(ConceptShareConnection.APIContext,
                                                                                                 ReviewID, Nothing, Nothing, Nothing).ToList

                Catch ex As Exception
                    ReviewResponses = Nothing
                End Try
                If ReviewResponses IsNot Nothing Then

                    For Each Response As AdvantageFramework.ConceptShareAPI.ReviewResponse In ReviewResponses

                        Try

                            Employee = Nothing
                            OpenRecord = Nothing
                            DismissedRecord = Nothing
                            CommentEntity = Nothing

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByConceptShareUserID(_DbContext, Response.ReferenceId)

                            If Employee IsNot Nothing Then

                                OpenRecord = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDAndEmployeeCode(_DbContext, Alert.ID, Employee.Code)
                                DismissedRecord = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadAssigneeByAlertIDAndEmployeeCode(_DbContext, Alert.ID, Employee.Code)

                                Select Case Response.StatusName.ToUpper
                                    Case "APPROVED"

                                        If OpenRecord IsNot Nothing AndAlso DismissedRecord Is Nothing Then 'Close

                                            If Alert.AlertStateID IsNot Nothing AndAlso
                                                Alert.AlertStateID > 0 AndAlso
                                                OpenRecord.AlertStateID IsNot Nothing AndAlso
                                                Alert.AlertStateID = OpenRecord.AlertStateID Then

                                                ApproveAssignee(_DbContext, ConceptShareConnection, Alert, _DbContext.UserCode, Employee.Code, Message)
                                                ResponseActionTaken = True

                                            End If

                                        End If

                                    Case "REJECTED"

                                        If OpenRecord Is Nothing AndAlso DismissedRecord IsNot Nothing Then 'Re-open

                                            'If Alert.AlertStateID IsNot Nothing AndAlso
                                            '    Alert.AlertStateID > 0 AndAlso
                                            '    DismissedRecord.AlertStateID IsNot Nothing AndAlso
                                            '    Alert.AlertStateID = DismissedRecord.AlertStateID Then

                                            ApproveAssignee(_DbContext, ConceptShareConnection, Alert, _DbContext.UserCode, Employee.Code, Message)
                                            ResponseActionTaken = True

                                            'End If

                                        End If

                                    Case "DEFERRED"

                                        If OpenRecord IsNot Nothing AndAlso DismissedRecord Is Nothing Then

                                            If Alert.AlertStateID IsNot Nothing AndAlso
                                                Alert.AlertStateID > 0 AndAlso
                                                OpenRecord.AlertStateID IsNot Nothing AndAlso
                                                Alert.AlertStateID = OpenRecord.AlertStateID Then

                                                ApproveAssignee(_DbContext, ConceptShareConnection, Alert, _DbContext.UserCode, Employee.Code, Message)
                                                ResponseActionTaken = True

                                            End If

                                        End If

                                End Select

                                If ResponseActionTaken = True Then

                                    CommentEntity = New AdvantageFramework.Database.Entities.AlertComment

                                    CommentEntity.AlertID = Alert.ID
                                    CommentEntity.UserCode = _DbContext.UserCode
                                    CommentEntity.GeneratedDate = RightNow
                                    CommentEntity.Comment = String.Format("{0} | {1}", Response.StatusName.ToUpper, Employee.ToString)
                                    CommentEntity.HasEmailBeenSent = False
                                    CommentEntity.AssignedEmployeeCode = Employee.Code
                                    CommentEntity.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                                    CommentEntity.AlertStateID = Alert.AlertStateID
                                    CommentEntity.CustodyStart = CommentEntity.GeneratedDate
                                    CommentEntity.ConceptShareProjectID = Alert.ConceptShareProjectID
                                    CommentEntity.ConceptShareReviewID = Alert.ConceptShareReviewID

                                    AdvantageFramework.Database.Procedures.AlertComment.Insert(_DbContext, CommentEntity)

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    Next

                End If
                If ConceptShareComments.Count > 0 Then

                    Try

                        For Each Comment As ConceptShareAPI.Comment In ConceptShareComments

                            CommentIDs &= Comment.Id.ToString & ","

                        Next

                        CommentIDs = AdvantageFramework.StringUtilities.CleanStringForSplit(CommentIDs, ",")

                        _DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_COMMENT WHERE ALERT_ID = {0} AND CS_REPLY_ID IS NULL AND CS_COMMENT_ID NOT IN ({1});", AlertID, CommentIDs))

                    Catch ex As Exception
                    End Try

                End If

                AlertComments = Nothing
                AlertComments = AdvantageFramework.Database.Procedures.AlertComment.LoadByConceptShareID(_DbContext, AlertID, ProjectID, ReviewID).ToList

                ConceptShareThreads = Nothing
                ConceptShareThreads = AdvantageFramework.ConceptShare.LoadReviewCommentThreadListByReviewID(ConceptShareConnection, ReviewID)

                If AlertComments Is Nothing Then AlertComments = New List(Of Database.Entities.AlertComment)
                If ConceptShareThreads Is Nothing Then ConceptShareThreads = New List(Of ConceptShareAPI.CommentThread)

                If (ReviewResponses IsNot Nothing AndAlso ReviewResponses.Count > 0) OrElse
                    (ConceptShareThreads.Count <> AlertComments.Count) Then

                    Try

                        ConceptShareUsers = _DbContext.Database.SqlQuery(Of ConceptShareUser)("EXEC [dbo].[advsp_cs_get_users];").ToList

                    Catch ex As Exception
                        ConceptShareUsers = Nothing
                    End Try

                End If
                If ConceptShareThreads.Count <> AlertComments.Count Then

                    AlertComment = Nothing
                    AlertCommentConceptShareCommentIDs = (From Entity In AlertComments
                                                          Select Entity.ConceptShareCommentID).ToList

                    ConceptShareCommentIDs = (From Entity In ConceptShareComments
                                              Select Entity.Id).ToList

                    MissingComments = (From Entity In ConceptShareComments
                                       Where AlertCommentConceptShareCommentIDs.Contains(Entity.Id) = False).ToList

                    If ConceptShareCommentIDs IsNot Nothing Then

                        If MissingComments IsNot Nothing AndAlso MissingComments.Count > 0 Then

                            NewCommentCount += MissingComments.Count

                            For Each Comment In MissingComments

                                IsClientPortalUser = False
                                CommentConceptShareUser = Nothing

                                Try

                                    If ConceptShareUsers IsNot Nothing Then

                                        CommentConceptShareUser = (From Entity In ConceptShareUsers
                                                                   Where Entity.ConceptShareUserID = Comment.CreatedBy
                                                                   Select Entity).FirstOrDefault

                                    End If

                                Catch ex As Exception
                                    CommentConceptShareUser = Nothing
                                End Try

                                If CommentConceptShareUser IsNot Nothing Then

                                    Try

                                        If CommentConceptShareUser.IsClientContact IsNot Nothing AndAlso CommentConceptShareUser.IsClientContact = True Then

                                            ClientContactID = CommentConceptShareUser.ClientContactID
                                            IsClientPortalUser = True

                                        Else

                                            UserCode = CommentConceptShareUser.UserCode
                                            EmployeeCode = CommentConceptShareUser.EmployeeCode

                                        End If

                                    Catch ex As Exception
                                        ClientContactID = 0
                                    End Try

                                End If
                                If String.IsNullOrWhiteSpace(UserCode) = True AndAlso IsClientPortalUser = False Then

                                    IsExternalUser = True

                                End If
                                If String.IsNullOrWhiteSpace(UserCode) = False OrElse IsClientPortalUser = True OrElse IsExternalUser = True Then

                                    AlertComment = New Database.Entities.AlertComment

                                    If IsExternalUser = False Then

                                        If IsClientPortalUser = False Then

                                            AlertComment.UserCode = UserCode

                                        Else

                                            AlertComment.ClientContactID = ClientContactID

                                        End If

                                    Else

                                        AlertComment.UserCode = Comment.CreatedByName

                                    End If

                                    AlertComment.AlertID = AlertID
                                    AlertComment.GeneratedDate = DateAdd(DateInterval.Hour, Offset, CType(Comment.DateCreated, DateTime))
                                    AlertComment.HasEmailBeenSent = False
                                    AlertComment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                                    AlertComment.AlertStateID = Alert.AlertStateID
                                    AlertComment.ConceptShareProjectID = ProjectID
                                    AlertComment.ConceptShareReviewID = ReviewID
                                    AlertComment.ConceptShareCommentID = Comment.Id

                                    Try

                                        If ReviewResponses Is Nothing Then

                                            AlertComment.Comment = Comment.CommentData

                                        Else

                                            CommentStatus = String.Empty

                                            Try

                                                CommentStatus = (From Entity In ReviewResponses
                                                                 Where Entity.ReferenceId = Comment.CreatedBy
                                                                 Select Entity.StatusName).FirstOrDefault

                                            Catch ex As Exception
                                                CommentStatus = String.Empty
                                            End Try
                                            If String.IsNullOrWhiteSpace(CommentStatus) = False Then

                                                StatusText = String.Empty
                                                Message = String.Empty

                                                If CommentStatus.ToLower.Contains("approved") = True Then

                                                    StatusText = "APPROVED"
                                                    'AdvantageFramework.ConceptShare.ApproveAssignee(_DbContext, Alert,
                                                    '                                                CommentConceptShareUser.UserCode,
                                                    '                                                CommentConceptShareUser.EmployeeCode,
                                                    '                                                Message)
                                                    HasDismissed = True

                                                ElseIf CommentStatus.ToLower.Contains("reject") = True Then

                                                    StatusText = "REJECTED"

                                                ElseIf CommentStatus.ToLower.Contains("defer") = True Then

                                                    StatusText = "DEFERRED"

                                                End If
                                                If String.IsNullOrWhiteSpace(StatusText) = False Then

                                                    AlertComment.Comment = String.Format("{0} | {1} | {2}", StatusText, CommentConceptShareUser.FullName, Comment.CommentData)

                                                Else

                                                    AlertComment.Comment = String.Format("{0}", Comment.CommentData)

                                                End If

                                            Else

                                                AlertComment.Comment = String.Format("{0}", Comment.CommentData)

                                            End If

                                        End If

                                    Catch ex As Exception
                                        AlertComment.Comment = Comment.CommentData
                                    End Try
                                    If AdvantageFramework.Database.Procedures.AlertComment.Insert(_DbContext, AlertComment) = True Then

                                        CommentsUpdated = True

                                    End If

                                    AlertComment = Nothing

                                End If

                            Next

                        End If

                    End If

                    SyncCommentRepliesToAlertComments(AlertID, ConceptShareComments, ConceptShareThreads, Offset, NewReplyCount)

                End If

                ''Check ReviewResponses for approved (?)
                'HasDismissed = CheckForApprovedResponses(_DbContext, ReviewResponses, Alert, ConceptShareUsers)
                'If HasDismissed = True Then

                '    If AdvantageFramework.AlertSystem.AssignmentStillHasAssignees(_DbContext, Alert.ID) = False Then

                '        Alert.AssignmentCompleted = True

                '        If AdvantageFramework.Database.Procedures.Alert.Update(_DbContext, Alert) = True Then

                '            AdvantageFramework.ProjectManagement.Agile.ClearAllocatedHours(_DbContext, Alert.ID, EmployeeCode, False)

                '        End If

                '    End If

                'End If

            End If

            Return CommentsUpdated

        End Function
        Private Function _SyncReviewImage(ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByRef ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary) As Boolean

            Dim SyncImage As Boolean = False

            Try

                If ReviewSummary.BaseImage IsNot Nothing AndAlso ReviewSummary.BaseImage.Length > 0 Then

                    If Alert.ConceptShareAssetImage Is Nothing Then

                        SyncImage = True

                    ElseIf Alert.ConceptShareAssetImage IsNot Nothing AndAlso
                           Alert.ConceptShareAssetImage.Length > 0 AndAlso
                           Alert.ConceptShareAssetImage.SequenceEqual(ReviewSummary.BaseImage) = False Then

                        SyncImage = True

                    End If

                    If SyncImage = True Then

                        Alert.ConceptShareAssetImage = ReviewSummary.BaseImage

                    End If

                End If

            Catch ex As Exception
                SyncImage = False
            End Try

            Return SyncImage

        End Function

        Private Function AlertRecipients(ByRef Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_ConnectionString, _UserCode)

                Return AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, _DbContext, Alert, "[Review Request]", IncludeOriginator:=False)

            End Using

        End Function
        Private Function SyncReviewReviewersToAlertRecipients(AlertID As Integer) As Boolean

            Dim AlertRecipientAdded As Boolean = False
            Try

                Dim ConceptShareReviewerIDs As New Generic.List(Of Integer)
                Dim AlertRecipientReviewersIDs As New Generic.List(Of Integer)

                ConceptShareReviewerIDs = (From Entity In LoadReviewMembersByReviewID(ConceptShareConnection, ReviewID)
                                           Select Entity.ReferenceId).ToList

                AlertRecipientReviewersIDs = _DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT E.CS_USERID FROM ALERT_RCPT AR INNER JOIN EMPLOYEE E ON AR.EMP_CODE = E.EMP_CODE WHERE AR.ALERT_ID = {0} UNION SELECT E.CS_USERID FROM ALERT_RCPT_DISMISSED ARD INNER JOIN EMPLOYEE E ON ARD.EMP_CODE = E.EMP_CODE WHERE ARD.ALERT_ID = {0};", AlertID)).ToList

                If AlertRecipientReviewersIDs Is Nothing Then AlertRecipientReviewersIDs = New List(Of Integer)
                If ConceptShareReviewerIDs Is Nothing Then ConceptShareReviewerIDs = New List(Of Integer)

                If ConceptShareReviewerIDs.Count <> AlertRecipientReviewersIDs.Count Then

                    If ConceptShareReviewerIDs.Count > AlertRecipientReviewersIDs.Count Then

                        Dim ConceptShareIDsToAddToAlertRecipients As Generic.List(Of Integer)

                        ConceptShareIDsToAddToAlertRecipients = (From ReviewerID In ConceptShareReviewerIDs
                                                                 Where AlertRecipientReviewersIDs.Contains(ReviewerID) = False).ToList

                        If ConceptShareIDsToAddToAlertRecipients IsNot Nothing Then

                            For Each ConceptShareUserID As Integer In ConceptShareIDsToAddToAlertRecipients

                                Dim ReviewerEmployeeCode As String = String.Empty

                                If SimpleConceptShareEmployeeList IsNot Nothing AndAlso SimpleConceptShareEmployeeList.Count > 0 Then

                                    Try

                                        ReviewerEmployeeCode = (From Entity In SimpleConceptShareEmployeeList
                                                                Where Entity.ConceptShareUserID = ConceptShareUserID
                                                                Select Entity.EmployeeCode).SingleOrDefault

                                    Catch ex As Exception
                                        ReviewerEmployeeCode = String.Empty
                                    End Try

                                End If

                                If String.IsNullOrWhiteSpace(ReviewerEmployeeCode) = True Then

                                    Try

                                        ReviewerEmployeeCode = _DbContext.Database.SqlQuery(Of String)(String.Format("SELECT E.EMP_CODE FROM EMPLOYEE E WHERE CS_USERID = {0}", ConceptShareUserID)).FirstOrDefault

                                    Catch ex As Exception
                                        ReviewerEmployeeCode = String.Empty
                                    End Try

                                End If

                                If String.IsNullOrWhiteSpace(ReviewerEmployeeCode) = False Then

                                    Dim AddEmployee As AdvantageFramework.Database.Views.Employee

                                    AddEmployee = Nothing
                                    AddEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(_DbContext, ReviewerEmployeeCode)

                                    If AddEmployee IsNot Nothing Then

                                        If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(AddEmployee) = True Then

                                            Dim AlertRecipient As New AdvantageFramework.Database.Entities.AlertRecipient

                                            AlertRecipient.DbContext = _DbContext
                                            AlertRecipient.AlertID = AlertID
                                            AlertRecipient.EmployeeCode = ReviewerEmployeeCode
                                            AlertRecipient.EmployeeEmail = AddEmployee.Email
                                            AlertRecipient.IsNewAlert = 1

                                            If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(_DbContext, AlertRecipient) = True AndAlso AlertRecipientAdded = False Then

                                                AlertRecipientAdded = True

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        End If

                    End If
                    If AlertRecipientReviewersIDs.Count > ConceptShareReviewerIDs.Count Then

                        Dim ConceptShareIDsToRemoveFromAlertRecipients As Generic.List(Of Integer)
                        ConceptShareIDsToRemoveFromAlertRecipients = (From ReviewerID In AlertRecipientReviewersIDs
                                                                      Where ConceptShareReviewerIDs.Contains(ReviewerID) = False).ToList

                        If ConceptShareIDsToRemoveFromAlertRecipients IsNot Nothing AndAlso ConceptShareIDsToRemoveFromAlertRecipients.Count > 0 Then

                            Dim Script As String = String.Empty

                            For Each ConceptShareUserID As Integer In ConceptShareIDsToRemoveFromAlertRecipients

                                Dim ReviewerEmployeeCode As String = String.Empty

                                If SimpleConceptShareEmployeeList IsNot Nothing AndAlso SimpleConceptShareEmployeeList.Count > 0 Then

                                    Try

                                        ReviewerEmployeeCode = (From Entity In SimpleConceptShareEmployeeList
                                                                Where Entity.ConceptShareUserID = ConceptShareUserID
                                                                Select Entity.EmployeeCode).SingleOrDefault

                                    Catch ex As Exception
                                        ReviewerEmployeeCode = String.Empty
                                    End Try

                                End If
                                If String.IsNullOrWhiteSpace(ReviewerEmployeeCode) = True Then

                                    Try

                                        ReviewerEmployeeCode = _DbContext.Database.SqlQuery(Of String)(String.Format("SELECT E.EMP_CODE FROM EMPLOYEE E WHERE CS_USERID = {0}", ConceptShareUserID)).FirstOrDefault

                                    Catch ex As Exception
                                        ReviewerEmployeeCode = String.Empty
                                    End Try

                                End If
                                If String.IsNullOrWhiteSpace(ReviewerEmployeeCode) = False Then

                                    Try

                                        _DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM ALERT_RCPT WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';DELETE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", AlertID, ReviewerEmployeeCode))
                                        ''Script &= String.Format("DELETE FROM ALERT_RCPT WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';DELETE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", AlertID, ReviewerEmployeeCode)

                                    Catch ex As Exception
                                    End Try

                                End If

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception
                AlertRecipientAdded = False
            End Try

            SyncReviewReviewersToAlertRecipients = AlertRecipientAdded

        End Function
        Private Function SyncCommentRepliesToAlertComments(ByVal AlertID As Integer,
                                                          ByRef Comments As Generic.List(Of AdvantageFramework.ConceptShareAPI.Comment),
                                                          ByRef CommentThreads As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread),
                                                          ByVal TimeOffset As Integer, ByRef NewReplyCount As Integer) As Boolean

            Dim RepliesAdded As Boolean = False

            Try

                If Comments IsNot Nothing AndAlso Comments.Count > 0 AndAlso CommentThreads IsNot Nothing AndAlso CommentThreads.Count > 0 Then

                    Dim ReplyCount As Integer = 0
                    ReplyCount = (From Entity In CommentThreads Where Entity.CommentReplyId > 0).Count

                    If ReplyCount > 0 Then

                        Dim Replies As Generic.List(Of AdvantageFramework.ConceptShareAPI.CommentThread)
                        Replies = Nothing

                        For Each Comment As AdvantageFramework.ConceptShareAPI.Comment In Comments

                            Replies = Nothing
                            Replies = (From Entity In CommentThreads Where Entity.Id = Comment.Id AndAlso Entity.CommentReplyId > 0).ToList

                            If Replies IsNot Nothing Then

                                Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment
                                Dim UserCode As String = String.Empty

                                AlertComment = Nothing

                                For Each Reply As AdvantageFramework.ConceptShareAPI.CommentThread In Replies

                                    AlertComment = Nothing
                                    AlertComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByConceptShareCommentIDAndReplyID(_DbContext, Reply.Id, Reply.CommentReplyId)

                                    If AlertComment Is Nothing Then

                                        Try

                                            UserCode = _DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 ISNULL(SU.USER_CODE, '') FROM SEC_USER SU INNER JOIN EMPLOYEE E ON SU.EMP_CODE = E.EMP_CODE WHERE E.CS_USERID = {0} ORDER BY SU.USER_CODE DESC;", Reply.CreatedBy)).FirstOrDefault

                                        Catch ex As Exception
                                            UserCode = String.Empty
                                        End Try

                                        If String.IsNullOrEmpty(UserCode) = False Then

                                            AlertComment = New Database.Entities.AlertComment

                                            AlertComment.AlertID = AlertID
                                            AlertComment.UserCode = UserCode
                                            AlertComment.GeneratedDate = DateAdd(DateInterval.Hour, TimeOffset, CType(Reply.CreatedDate, DateTime))
                                            AlertComment.Comment = Reply.Comment
                                            AlertComment.HasEmailBeenSent = False
                                            AlertComment.ConceptShareProjectID = ProjectID
                                            AlertComment.ConceptShareReviewID = ReviewID
                                            AlertComment.ConceptShareCommentID = Comment.Id
                                            AlertComment.ConceptShareReplyID = Reply.CommentReplyId

                                            If AdvantageFramework.Database.Procedures.AlertComment.Insert(_DbContext, AlertComment) = True Then

                                                RepliesAdded = True
                                                NewReplyCount += 1

                                            End If

                                        End If

                                    End If

                                Next

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                RepliesAdded = False
            End Try

            Return RepliesAdded

        End Function

#End Region

#Region " Email External Reviewers "

        Public Sub EmailExternalReviewers()

            Dim SyncThreadStart As New ParameterizedThreadStart(AddressOf Me._EmailExternalReviewers)
            Dim SyncThread As New Thread(SyncThreadStart)
            SyncThread.Start()

        End Sub
        Private Sub _EmailExternalReviewers()

            If ConceptShareConnection IsNot Nothing Then

                Dim ExternalReviewers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

                ExternalReviewers = AdvantageFramework.ConceptShare.LoadExternalReviewMembersByReviewID(ConceptShareConnection, ReviewID)

                If ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0 Then

                    Dim URL As String = String.Empty
                    Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus
                    Dim Subject As String = "Request Review"
                    Dim Body As String = "Here's your stupid link:  {0}"
                    Dim ErrorMessage As String = ""
                    Dim CC As String = ""
                    Dim BCC As String = ""

                    Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_ConnectionString, _UserCode)

                            For Each ExternalReviewer As AdvantageFramework.ConceptShareAPI.ReviewMember In ExternalReviewers

                                URL = String.Empty

                                Try

                                    URL = AdvantageFramework.ConceptShare.GetReviewProofingURLForExternalUser(ConceptShareConnection, ProjectID, ReviewID, ExternalReviewer.ReferenceId)

                                Catch ex As Exception
                                    URL = String.Empty
                                End Try

                                If String.IsNullOrWhiteSpace(URL) = False AndAlso String.IsNullOrWhiteSpace(ExternalReviewer.UserName) = False AndAlso
                                        AdvantageFramework.StringUtilities.IsValidEmailAddress(ExternalReviewer.UserName) = True Then

                                    AdvantageFramework.Email.Send(DbContext,
                                                                  SecurityDbContext,
                                                                  ExternalReviewer.UserName,
                                                                  Subject,
                                                                  String.Format(Body, URL),
                                                                  0,
                                                                  Nothing, SendingEmailStatus,
                                                                  ErrorMessage, CC, BCC)


                                End If

                            Next

                        End Using

                    End Using

                End If

            End If

        End Sub
#End Region

        Sub New(ByVal Session As AdvantageFramework.Security.Session)

            _ConnectionString = Session.ConnectionString
            _UserCode = Session.UserCode
            _DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

        End Sub
        Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            _ConnectionString = ConnectionString
            _UserCode = UserCode
            _DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

        End Sub

#End Region

        End Class

    <Serializable()>
    Public Class SimpleConceptShareEmployee

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public EmployeeCode As String
        Public ConceptShareUserID As Integer

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class ConceptShareUser

        Public Property EmployeeCode As String = String.Empty
        Public Property UserCode As String = String.Empty
        Public Property FullName As String = String.Empty
        Public Property ConceptShareUserID As Integer? = 0
        Public Property IsClientContact As Boolean? = False
        Public Property ClientContactID As Integer? = 0

        Sub New()

        End Sub

    End Class
    <Serializable()> Public Class BackupReviewResult
        Public Property Review As ReviewInfo = Nothing
        Public Property Success As Boolean = False
        Public Property ErrorMessage As String = String.Empty
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class ReviewInfo
        Public Property AlertID As Integer = 0
        Public Property ProjectID As Integer = 0
        Public Property ReviewID As Integer = 0
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class ConceptShareBackupLog
        Public Property ID As Integer?
        Public Property AlertID As Integer?
        Public Property ProjectID As Integer?
        Public Property ReviewID As Integer?
        Public Property AssetID As Integer?
        Public Property DocumentID As Integer?
        Public Property BackedUp As Boolean?
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class ConceptShareFeedbackLog
        Public Property ID As Integer?
        Public Property AlertID As Integer?
        Public Property ProjectID As Integer?
        Public Property ReviewID As Integer?
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property Title As String
        Public Property Filename As String
        Public Property EmployeeCode As String
        Public Property BackupDate As Date?
        Public Property BackedUp As Boolean?
        Public Property BackUpFailed As Boolean?
        Public Property FailReason As String
        Sub New()

        End Sub
    End Class
    <Serializable()> Public Class BackupStats
        Public Property TotalReviewsDB As Integer? = 0
        Public Property TotalAssetsDB As Integer? = 0
        Public Property TotalBackedUpDB As Integer? = 0
        Public Property TotalFailedDB As Integer? = 0
        Public Property TotalAssetsCS As Integer? = 0

    End Class

End Namespace
