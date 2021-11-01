Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace Controllers

    Public Class HomeController
        Inherits Webvantage.MVCControllerBase

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.ApplicationController = Nothing

#End Region

#Region " Views "

        Function Index() As ActionResult
            Dim webFormsRoot As String = String.Format("{0}://{1}{2}default.aspx", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"))
            Response.Redirect(webFormsRoot)

            Return View()
        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/NewApp")>
        Public Function App() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New ViewModels.AureliaModel

            AureliaModel.App = "app"

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.ApplicationController(Me.SecuritySession, MiscFN.IsClientPortal(), Me.IsProofingToolActive(SecuritySession))

            _Controller.ApplicationPath = Request.ApplicationPath

        End Sub

#End Region

#Region " API "

        <HttpGet>
        Public Function ApplicationInit() As JsonResult

            'objects
            Dim Application As AdvantageFramework.DTO.Application = Nothing

            Application = _Controller.Load()

            If Application IsNot Nothing Then

                SetupSessionStateSecurityForLegacyPages()

            End If

            Return Json(Application, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function SignOut() As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Success = MiscFN.SignOutOfWebvantage(SecuritySession, ErrorMessage)

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function
        <HttpGet>
        Public Function DecryptDeepLink(ByVal Link As String) As JsonResult

            Dim PageName As String = String.Empty

            Try

                PageName = AdvantageFramework.Web.DecryptDeepLinkString(Link)

            Catch ex As Exception
                PageName = String.Empty
            End Try

            Return Json(PageName, JsonRequestBehavior.AllowGet)

        End Function


#Region " Legacy "

        Private IsClientPortal As Boolean = False
        Private Sub SetupSessionStateSecurityForLegacyPages()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission) = Nothing

                If Me.SecuritySession.Application <> AdvantageFramework.Security.Application.Client_Portal Then

                    UserPermissionList = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, Me.SecuritySession.Application, Me.SecuritySession.User.ID).ToList

                End If

                If UserPermissionList IsNot Nothing Then

                    For Each UserPermission In UserPermissionList

                        Me.CheckAndSaveAllSecurityForModule(UserPermission)

                    Next

                End If

            End Using

        End Sub

        Public Sub CheckAndSaveAllSecurityForModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission)

            CheckModuleAccess(UserPermission, True)
            UserHasAccessToAddNew(UserPermission, True)

            UserCanPrintInModule(UserPermission, True)
            UserCanUpdateInModule(UserPermission, True)
            UserCanAddInModule(UserPermission, True)
            UserCanCustom1Module(UserPermission, True)
            UserCanCustom2Module(UserPermission, True)

        End Sub
        Public Overloads Function CheckModuleAccess(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            'objects
            Dim ModuleAccess As Integer = 0
            Dim SessionKey As String = "CheckModuleAccess" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    ModuleAccess = CType(Session(SessionKey), Integer)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(UserPermission)

                Catch ex As Exception
                    ModuleAccess = 0
                End Try

                If ModuleAccess = -1 Then

                    ModuleAccess = 1

                End If

                If SaveValueToSession Then

                    Session(SessionKey) = ModuleAccess

                End If

            End If

            CheckModuleAccess = ModuleAccess

        End Function
        Public Overloads Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

            Dim ModuleAccess As Integer = 1

            ModuleAccess = CheckModuleAccess([Module].ToString, TransferToNoAccessPage)

            Return ModuleAccess

        End Function
        Public Overloads Function CheckModuleAccess(ByVal ModuleCode As String, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

            Dim ModuleAccess As Integer = 1
            Dim SessionKey As String = "CheckModuleAccess" & ModuleCode

            If Session(SessionKey) Is Nothing Then

                If Me.IsClientPortal Then

                    Try
                        ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(Me.SecuritySession, ModuleCode)
                    Catch ex As Exception
                        ModuleAccess = 1
                    End Try

                Else

                    Try

                        ModuleAccess = CheckModuleAccess(Me.SecuritySession.User, ModuleCode, False)

                    Catch ex As Exception
                        ModuleAccess = 1
                    End Try

                End If

                Session(SessionKey) = ModuleAccess
            Else
                ModuleAccess = CType(Session(SessionKey), Integer)
            End If

            If ModuleAccess = 0 And TransferToNoAccessPage = True Then
                Server.Transfer("NoAccess.aspx")
            End If

            If ModuleAccess = -1 Then ModuleAccess = 1

            Return ModuleAccess

        End Function
        Public Overloads Function CheckModuleAccess(ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

            Dim ModuleAccess As Integer = 0
            Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    ModuleAccess = CType(Session(SessionKey), Integer)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(Me.SecuritySession, ModuleCode)

                Catch ex As Exception
                    ModuleAccess = 0
                End Try

                If ModuleAccess = -1 Then

                    ModuleAccess = 1

                End If

                If SaveValueToSession Then

                    Session(SessionKey) = ModuleAccess

                End If

            End If

            Return ModuleAccess

        End Function
        Public Overloads Function CheckModuleAccess(ByVal User As AdvantageFramework.Security.Classes.User, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

            Dim ModuleAccess As Integer = 0
            Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    ModuleAccess = CType(Session(SessionKey), Integer)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.SecuritySession, ModuleCode, User)

                Catch ex As Exception
                    ModuleAccess = 0
                End Try

                If ModuleAccess = -1 Then

                    ModuleAccess = 1

                End If

                If SaveValueToSession Then

                    Session(SessionKey) = ModuleAccess

                End If

            End If

            Return ModuleAccess

        End Function
        Public Overloads Function CheckAdvantageModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, ByVal TransferToNoAccessPage As Boolean) As Integer

            Dim ModuleAccess As Integer = 0
            Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

            If Session(SessionKey) IsNot Nothing Then

                ModuleAccess = CType(Session(SessionKey), Integer)

            Else

                Try

                    Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(DbContext, 1, [Module].ToString(), Me.SecuritySession.User.ID)

                    End Using

                Catch ex As Exception

                    ModuleAccess = 0

                End Try

                If ModuleAccess = -1 Then ModuleAccess = 1

                Session(SessionKey) = ModuleAccess

                If ModuleAccess = 0 And TransferToNoAccessPage = True Then Server.Transfer("NoAccess.aspx")

            End If

            Return ModuleAccess

        End Function
        Public Overloads Function CheckAdvantageModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules) As Integer

            Dim ModuleAccess As Integer = 0
            Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

            If Session(SessionKey) IsNot Nothing Then

                ModuleAccess = CType(Session(SessionKey), Integer)

            Else

                Try

                    Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(DbContext, 1, [Module].ToString(), Me.SecuritySession.User.ID)

                    End Using

                Catch ex As Exception

                    ModuleAccess = 0

                End Try

                If ModuleAccess = -1 Then ModuleAccess = 1

                Session(SessionKey) = ModuleAccess

            End If

            Return ModuleAccess

        End Function
        Public Function UserHasAccessToAddNew(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            ''bypass
            'Return True
            Dim UserDoesHaveAccess As Boolean = False
            Dim SessionKey As String = "UserHasAccessToAddNew" & SecurityModule.ToString()
            If Session(SessionKey) Is Nothing Then
                If Me.CheckModuleAccess(SecurityModule.ToString(), False) = 1 _
               And Me.UserCanAddInModule(SecurityModule) = True Then
                    UserDoesHaveAccess = True
                Else
                    UserDoesHaveAccess = False
                End If
                Session(SessionKey) = UserDoesHaveAccess
            Else
                UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
            End If
            Return UserDoesHaveAccess
        End Function
        Public Function UserHasAccessToAddNew(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Boolean

            Dim UserDoesHaveAccess As Boolean = False
            Dim SessionKey As String = "UserHasAccessToAddNew" & UserPermission.ModuleCode
            If Session(SessionKey) Is Nothing Then
                If Me.CheckModuleAccess(UserPermission, True) = 1 _
               And Me.UserCanAddInModule(UserPermission, True) = True Then
                    UserDoesHaveAccess = True
                Else
                    UserDoesHaveAccess = False
                End If
                Session(SessionKey) = UserDoesHaveAccess
            Else
                UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
            End If
            Return UserDoesHaveAccess

        End Function
        Public Function UserCanPrintInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanPrint As Boolean = False
            Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanPrint = UserCanPrintInModule(Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanPrint = False
                End Try

                Session(SessionKey) = CanPrint

            Else
                CanPrint = CType(Session(SessionKey), Boolean)
            End If
            Return CanPrint
        End Function
        Public Function UserCanPrintInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanPrint As Boolean = False
            Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanPrint = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanPrint = AdvantageFramework.Security.CanUserPrintInModule(Me.SecuritySession, SecurityModule, User)

                Catch ex As Exception
                    CanPrint = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanPrint

                End If

            End If

            Return CanPrint

        End Function
        Public Function UserCanPrintInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanPrint As Boolean = False
            Dim SessionKey As String = "UserCanPrintInModule" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanPrint = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanPrint = AdvantageFramework.Security.CanUserPrintInModule(UserPermission)

                Catch ex As Exception
                    CanPrint = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanPrint

                End If

            End If

            Return CanPrint

        End Function
        Public Function UserCanUpdateInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanUpdate As Boolean = False
            Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanUpdate = UserCanUpdateInModule(Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanUpdate = False
                End Try

                Session(SessionKey) = CanUpdate

            Else
                CanUpdate = CType(Session(SessionKey), Boolean)
            End If
            Return CanUpdate
        End Function
        Public Function UserCanUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanUpdate As Boolean = False
            Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanUpdate = UserCanUpdateInModule(DbContext, ApplicationID, Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanUpdate = False
                End Try

                Session(SessionKey) = CanUpdate

            Else
                CanUpdate = CType(Session(SessionKey), Boolean)
            End If
            Return CanUpdate
        End Function
        Public Function UserCanUpdateInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanUpdate As Boolean = False
            Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanUpdate = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule, User)

                Catch ex As Exception
                    CanUpdate = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanUpdate

                End If

            End If

            Return CanUpdate

        End Function
        Public Function UserCanUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanUpdate As Boolean = False
            Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanUpdate = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(DbContext, ApplicationID, SecurityModule.ToString, User.UserCode)

                Catch ex As Exception
                    CanUpdate = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanUpdate

                End If

            End If

            Return CanUpdate

        End Function
        Public Function UserCanUpdateInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanUpdate As Boolean = False
            Dim SessionKey As String = "UserCanUpdateInModule" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanUpdate = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(UserPermission)

                Catch ex As Exception
                    CanUpdate = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanUpdate

                End If

            End If

            Return CanUpdate

        End Function
        Public Function UserCanAddInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanAdd As Boolean = False
            Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanAdd = UserCanAddInModule(Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanAdd = False
                End Try

                Session(SessionKey) = CanAdd

            Else
                CanAdd = CType(Session(SessionKey), Boolean)
            End If
            Return CanAdd
        End Function
        Public Function UserCanAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanAdd As Boolean = False
            Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanAdd = UserCanAddInModule(DbContext, ApplicationID, Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanAdd = False
                End Try

                Session(SessionKey) = CanAdd

            Else
                CanAdd = CType(Session(SessionKey), Boolean)
            End If
            Return CanAdd
        End Function
        Public Function UserCanAddInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanAdd As Boolean = False
            Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanAdd = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanAdd = AdvantageFramework.Security.CanUserAddInModule(Me.SecuritySession, SecurityModule, User)

                Catch ex As Exception
                    CanAdd = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanAdd

                End If

            End If

            Return CanAdd

        End Function
        Public Function UserCanAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanAdd As Boolean = False
            Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanAdd = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanAdd = AdvantageFramework.Security.CanUserAddInModule(DbContext, ApplicationID, SecurityModule.ToString, User.UserCode)

                Catch ex As Exception
                    CanAdd = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanAdd

                End If

            End If

            Return CanAdd

        End Function
        Public Function UserCanAddInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanAdd As Boolean = False
            Dim SessionKey As String = "UserCanAddInModule" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanAdd = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanAdd = AdvantageFramework.Security.CanUserAddInModule(UserPermission)

                Catch ex As Exception
                    CanAdd = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanAdd

                End If

            End If

            Return CanAdd

        End Function
        Public Function UserCanCustom1Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

            Dim CanCustom1 As Boolean = False
            Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanCustom1 = UserCanCustom1Module(Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanCustom1 = False
                End Try

                Session(SessionKey) = CanCustom1

            Else

                CanCustom1 = CType(Session(SessionKey), Boolean)

            End If

            UserCanCustom1Module = CanCustom1

        End Function
        Public Function UserCanCustom1Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanCustom1 As Boolean = False
            Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanCustom1 = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.SecuritySession, SecurityModule)

                Catch ex As Exception
                    CanCustom1 = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanCustom1

                End If

            End If

            UserCanCustom1Module = CanCustom1

        End Function
        Public Function UserCanCustom1Module(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanCustom1 As Boolean = False
            Dim SessionKey As String = "UserCanCustom1Module" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanCustom1 = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(UserPermission)

                Catch ex As Exception
                    CanCustom1 = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanCustom1

                End If

            End If

            Return CanCustom1

        End Function
        Public Function UserCanCustom2Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
            Dim CanCustom2 As Boolean = False
            Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    CanCustom2 = UserCanCustom2Module(Me.SecuritySession.User, SecurityModule, False)

                Catch ex As Exception
                    CanCustom2 = False
                End Try

                Session(SessionKey) = CanCustom2

            Else
                CanCustom2 = CType(Session(SessionKey), Boolean)
            End If
            Return CanCustom2
        End Function
        Public Function UserCanCustom2Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanCustom2 As Boolean = False
            Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanCustom2 = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(Me.SecuritySession, SecurityModule, User)

                Catch ex As Exception
                    CanCustom2 = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanCustom2

                End If

            End If

            Return CanCustom2

        End Function
        Public Function UserCanCustom2Module(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

            Dim CanCustom2 As Boolean = False
            Dim SessionKey As String = "UserCanCustom2Module" & UserPermission.ModuleCode
            Dim FoundExistingValue As Boolean = False

            If SaveValueToSession Then

                If Session(SessionKey) IsNot Nothing Then

                    FoundExistingValue = True

                    CanCustom2 = CType(Session(SessionKey), Boolean)

                End If

            End If

            If FoundExistingValue = False Then

                Try

                    CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(UserPermission)

                Catch ex As Exception
                    CanCustom2 = False
                End Try

                If SaveValueToSession Then

                    Session(SessionKey) = CanCustom2

                End If

            End If

            Return CanCustom2

        End Function
        Public Function LoadUserGroupSettingAccess(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
            Dim i As Integer = 0
            Dim SessionKey As String = "LoadUserGroupSettingAccess" & GroupSetting.ToString()
            If Session(SessionKey) Is Nothing Then
                i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(Me.SecuritySession, GroupSetting).Any(Function(SettingValue) SettingValue = True))
                Session(SessionKey) = i
            Else
                i = CType(Session(SessionKey), Integer)
            End If
            Return i
        End Function
        Public Function LoadUserSetting(ByVal Setting As AdvantageFramework.Security.UserSettings) As Boolean

            Dim IsValid As Boolean = False
            Dim SessionKey As String = "LoadUserSetting" & Setting.ToString()

            If Session(SessionKey) Is Nothing Then

                Try

                    If AdvantageFramework.Security.LoadUserSetting(Me.SecuritySession, Me.SecuritySession.User.ID, Setting) Then

                        IsValid = True

                    Else

                        IsValid = False

                    End If

                Catch ex As Exception

                    IsValid = False

                End Try

                Session(SessionKey) = IsValid

            Else

                IsValid = CType(Session(SessionKey), Boolean)

            End If

            Return IsValid

        End Function
        Public Function CheckUserGroupSetting(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
            Dim SessionKey As String = "CheckUserGroupSetting" & GroupSetting.ToString()
            Dim i As Integer = 0
            If Session(SessionKey) Is Nothing Then
                Try
                    i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(Me.SecuritySession, GroupSetting).Any(Function(SettingValue) SettingValue = True))
                Catch ex As Exception
                    i = 0
                End Try
            Else
                i = CType(Session(SessionKey), Integer)
            End If
            Return i
        End Function
        Public Function CheckEmployeeAccess(ByVal EmpCode As String) As Boolean
            If Me.HasAccessToEmployee(EmpCode) = False Then
                Server.Transfer("NoAccess.aspx")
            End If
        End Function
        Public Function HasAccessToEmployee(ByVal EmpCode As String) As Boolean
            Dim SessionKey As String = "HasAccessToEmployee" & EmpCode.Trim()
            Dim HasAccess As Boolean = False
            If Session(SessionKey) Is Nothing Then
                Try
                    Dim arP(2) As SqlParameter

                    Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                    pUserId.Value = Session("UserCode").ToString()
                    arP(0) = pUserId

                    Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode.Trim()
                    arP(1) = pEmpCode

                    If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_SEC_EMP_CHECK_ACCESS", arP), Integer) = 0 Then
                        HasAccess = False
                    Else
                        HasAccess = True
                    End If

                Catch ex As Exception
                    HasAccess = False
                End Try
            Else
                HasAccess = CType(Session(SessionKey), Boolean)
            End If
            Return HasAccess
        End Function
        Public Function AccessOnlyToSelf(ByRef SingleEmpCode As String, ByRef SingleEmpFML As String) As Boolean
            Dim UserDoesHaveAccess As Boolean = False
            Dim SessionKey As String = "AccessOnlyToSelf" & SingleEmpCode
            If Session(SessionKey) Is Nothing Then
                Try

                    Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                    pUserId.Value = Session("UserCode").ToString()

                    Dim dt As New DataTable
                    dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_SEC_EMP_RESTRICTED_TO_SELF", "dt", pUserId)
                    If dt.Rows.Count > 0 AndAlso dt(0)("EMP_CODE").ToString().Trim() <> "" Then
                        SingleEmpCode = dt(0)("EMP_CODE")
                        SingleEmpFML = dt(0)("EMP_FML")
                        UserDoesHaveAccess = True
                    End If
                Catch ex As Exception
                    UserDoesHaveAccess = False
                End Try
            Else
                UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
            End If
            Return UserDoesHaveAccess
        End Function

        Private Function CheckForDeepLink() As String

            Dim _LoadPageName As String = String.Empty

            Try

                If Request.QueryString("link") IsNot Nothing Then

                    _LoadPageName = Request.QueryString.ToString.Replace("link=", "")
                    _LoadPageName = Server.UrlDecode(_LoadPageName)
                    _LoadPageName = _LoadPageName.Replace("$", "?").Replace("alert=", "AlertID=")
                    _LoadPageName = _LoadPageName & "&openasassign=False&SprintID=0"

                End If

            Catch ex As Exception
                _LoadPageName = String.Empty
            End Try
            If String.IsNullOrWhiteSpace(_LoadPageName) = True Then

                Try

                    If String.IsNullOrWhiteSpace(Me.CurrentQueryString.DeepLink) = False Then

                        _LoadPageName = AdvantageFramework.Web.DecryptDeepLinkString(Me.CurrentQueryString.DeepLink)

                    End If

                Catch ex As Exception
                    _LoadPageName = String.Empty
                End Try

            End If

            Return _LoadPageName

        End Function

#End Region

#End Region

    End Class

End Namespace


