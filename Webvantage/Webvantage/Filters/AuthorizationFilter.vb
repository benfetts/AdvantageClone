Public Class AuthorizationFilter
    Inherits System.Web.Mvc.AuthorizeAttribute

#Region " Variables "

    Private _SecuritySession As AdvantageFramework.Security.Session = Nothing
    Private _HttpContext As HttpContextBase = Nothing

#End Region

#Region " Properties "

    Public Property SecurityModuleCode As String
    Public Property CheckCanPrint As Boolean
    Public Property CheckCanUpdate As Boolean
    Public Property CheckCanAdd As Boolean
    Public Property CheckCanCustom1 As Boolean
    Public Property CheckCanCustom2 As Boolean
    Public Property TransferToNoAccessPage As Boolean

#End Region

#Region " Methods "

    Private Function GetSecuritySession(ByVal HttpContext As HttpContextBase) As AdvantageFramework.Security.Session

        'objects
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing

        If HttpContext.Session("Security_Session") Is Nothing AndAlso Not HttpContext.Session("ConnString") Is Nothing AndAlso Not HttpContext.Session("UserCode") Is Nothing Then

            If IsNothing(HttpContext.Session("UserGUID")) Then

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Session("ConnString"), HttpContext.Session("UserCode"), CInt(HttpContext.Session("AdvantageUserLicenseInUseID")), HttpContext.Session("ConnString"))
                HttpContext.Session("Security_Session") = SecuritySession

            Else

                SecuritySession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, HttpContext.Session("ConnString"), HttpContext.Session("UserCode"), CInt(HttpContext.Session("AdvantageUserLicenseInUseID")), HttpContext.Session("ConnString"))
                HttpContext.Session("Security_Session") = SecuritySession

            End If

        Else

            SecuritySession = HttpContext.Session("Security_Session")

        End If

        Return SecuritySession

    End Function
    Protected Overrides Sub HandleUnauthorizedRequest(filterContext As System.Web.Mvc.AuthorizationContext)

        'objects
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing
        Dim RedirectToPage As String = ""

        SecuritySession = GetSecuritySession(filterContext.HttpContext)

        If SecuritySession Is Nothing Then

            RedirectToPage = "~/SignIn.aspx"

        Else

            RedirectToPage = "~/NoAccess.aspx"

        End If

        filterContext.Result = New System.Web.Mvc.RedirectResult(RedirectToPage)

    End Sub
    Protected Overrides Function AuthorizeCore(httpContext As HttpContextBase) As Boolean

        'objects
        Dim SecurityModule As AdvantageFramework.Security.Modules = Nothing

        If Not String.IsNullOrWhiteSpace(Me.SecurityModuleCode) Then

            _HttpContext = httpContext
            _SecuritySession = GetSecuritySession(httpContext)

            If System.Enum.TryParse(Of AdvantageFramework.Security.Modules)(Me.SecurityModuleCode, SecurityModule) Then

                If CheckModuleAccess(SecurityModule) = 0 Then

                    Return False

                End If

                If CheckCanPrint Then

                    If Not UserCanPrintInModule(SecurityModule) Then

                        Return False

                    End If

                End If

                If CheckCanUpdate Then

                    If Not UserCanUpdateInModule(SecurityModule) Then

                        Return False

                    End If

                End If

                If CheckCanAdd Then

                    If Not UserCanAddInModule(SecurityModule) Then

                        Return False

                    End If

                End If

                If CheckCanCustom1 Then

                    If Not UserCanCustom1Module(SecurityModule) Then

                        Return False

                    End If

                End If

                If CheckCanCustom2 Then

                    If Not UserCanCustom2Module(SecurityModule) Then

                        Return False

                    End If

                End If

            End If

        End If

        Return MyBase.AuthorizeCore(httpContext)

    End Function
    Private Function CheckModuleAccess(ByVal User As AdvantageFramework.Security.Classes.User, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(_HttpContext.Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(_SecuritySession, ModuleCode, User)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = ModuleAccess

            End If

        End If

        Return ModuleAccess

    End Function
    Private Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules) As Integer

        Dim ModuleAccess As Integer = 1

        ModuleAccess = CheckModuleAccess([Module].ToString)

        Return ModuleAccess

    End Function
    Private Function CheckModuleAccess(ByVal ModuleCode As String) As Integer

        Dim ModuleAccess As Integer = 1
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode

        If _HttpContext.Session(SessionKey) Is Nothing Then

            If Webvantage.MiscFN.IsClientPortal() Then

                Try
                    ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(_SecuritySession, ModuleCode)
                Catch ex As Exception
                    ModuleAccess = 1
                End Try

            Else

                Try

                    ModuleAccess = CheckModuleAccess(_SecuritySession.User, ModuleCode, False)

                Catch ex As Exception
                    ModuleAccess = 1
                End Try

            End If

            _HttpContext.Session(SessionKey) = ModuleAccess

        Else

            ModuleAccess = CType(_HttpContext.Session(SessionKey), Integer)

        End If

        'If ModuleAccess = 0 And TransferToNoAccessPage = True Then

        '    Server.Transfer("NoAccess.aspx")

        'End If

        If ModuleAccess = -1 Then ModuleAccess = 1

        Return ModuleAccess

    End Function
    Private Function UserCanPrintInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()

        If _HttpContext.Session(SessionKey) Is Nothing Then

            Try

                CanPrint = UserCanPrintInModule(_SecuritySession.User, SecurityModule, False)

            Catch ex As Exception
                CanPrint = False
            End Try

            _HttpContext.Session(SessionKey) = CanPrint

        Else

            CanPrint = CType(_HttpContext.Session(SessionKey), Boolean)

        End If

        Return CanPrint

    End Function
    Private Function UserCanPrintInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanPrint = CType(_HttpContext.Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanPrint = AdvantageFramework.Security.CanUserPrintInModule(_SecuritySession, SecurityModule, User)

            Catch ex As Exception
                CanPrint = False
            End Try

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = CanPrint

            End If

        End If

        Return CanPrint

    End Function
    Private Function UserCanUpdateInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

        If _HttpContext.Session(SessionKey) Is Nothing Then

            Try

                CanUpdate = UserCanUpdateInModule(_SecuritySession.User, SecurityModule, False)

            Catch ex As Exception
                CanUpdate = False
            End Try

            _HttpContext.Session(SessionKey) = CanUpdate

        Else

            CanUpdate = CType(_HttpContext.Session(SessionKey), Boolean)

        End If

        Return CanUpdate

    End Function
    Private Function UserCanUpdateInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanUpdate = CType(_HttpContext.Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_SecuritySession, SecurityModule, User)

            Catch ex As Exception
                CanUpdate = False
            End Try

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = CanUpdate

            End If

        End If

        Return CanUpdate

    End Function
    Private Function UserCanAddInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

        If _HttpContext.Session(SessionKey) Is Nothing Then

            Try

                CanAdd = UserCanAddInModule(_SecuritySession.User, SecurityModule, False)

            Catch ex As Exception
                CanAdd = False
            End Try

            _HttpContext.Session(SessionKey) = CanAdd

        Else

            CanAdd = CType(_HttpContext.Session(SessionKey), Boolean)

        End If

        Return CanAdd

    End Function
    Private Function UserCanAddInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanAdd = CType(_HttpContext.Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanAdd = AdvantageFramework.Security.CanUserAddInModule(_SecuritySession, SecurityModule, User)

            Catch ex As Exception
                CanAdd = False
            End Try

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = CanAdd

            End If

        End If

        Return CanAdd

    End Function
    Private Function UserCanCustom1Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()

        If _HttpContext.Session(SessionKey) Is Nothing Then

            Try

                CanCustom1 = UserCanCustom1Module(_SecuritySession.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            _HttpContext.Session(SessionKey) = CanCustom1

        Else

            CanCustom1 = CType(_HttpContext.Session(SessionKey), Boolean)

        End If

        UserCanCustom1Module = CanCustom1

    End Function
    Private Function UserCanCustom1Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom1 = CType(_HttpContext.Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_SecuritySession, SecurityModule)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = CanCustom1

            End If

        End If

        UserCanCustom1Module = CanCustom1

    End Function
    Private Function UserCanCustom2Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()

        If _HttpContext.Session(SessionKey) Is Nothing Then

            Try

                CanCustom2 = UserCanCustom2Module(_SecuritySession.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            _HttpContext.Session(SessionKey) = CanCustom2

        Else

            CanCustom2 = CType(_HttpContext.Session(SessionKey), Boolean)

        End If

        Return CanCustom2

    End Function
    Private Function UserCanCustom2Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If _HttpContext.Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom2 = CType(_HttpContext.Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(_SecuritySession, SecurityModule, User)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            If SaveValueToSession Then

                _HttpContext.Session(SessionKey) = CanCustom2

            End If

        End If

        Return CanCustom2

    End Function

#End Region

End Class
