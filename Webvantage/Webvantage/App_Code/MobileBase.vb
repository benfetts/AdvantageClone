Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Webvantage.cGlobals
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Security
Imports Microsoft.Win32
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls

<Serializable()> Public Class MobileBase
    Inherits System.Web.UI.Page

    Protected _Session As AdvantageFramework.Security.Session = Nothing

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
    End Sub

    Public Sub New()

    End Sub
   
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init
        If Session("ConnString") Is Nothing Then
            Server.Transfer("~/mobile/login.aspx?message=sessionend")
            Exit Sub
        End If
        If Session("ConnString") = "" Then
            Server.Transfer("~/mobile/login.aspx?message=sessionend")
            Exit Sub
        End If
        If Session("UserCode") Is Nothing Then
            Server.Transfer("~/Mobile/login.aspx?message=sessionend")
            Exit Sub
        End If
        If Session("UserCode") = "" Then
            Server.Transfer("~/Mobile/login.aspx?message=sessionend")
            Exit Sub
        End If
        Dim s As New cSecurity(Session("ConnString"))
        Dim m As AdvantageFramework.Security.ErrorMessages.SystemMessageType
        Dim s1 As String
        Dim s2 As String = Session("CurrentSessionId")
        If s.ValidSessionId(m, s1, s2) = False Then
            Server.Transfer("~/mobile/login.aspx?message=userloggedin")
            Exit Sub
        End If

        If _Session Is Nothing Then

            _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))

        End If

    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
       
    End Sub

    Protected Overloads Overrides Sub OnPreInit(ByVal e As EventArgs)
        MyBase.OnPreInit(e)
    End Sub
    Public Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

        'objects
        Dim ModuleAccess As Integer = 1

        Try

            If AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, [Module]) = False Then

                ModuleAccess = 0

                If TransferToNoAccessPage Then

                    Server.Transfer("~/mobile/NoAccess.aspx")

                End If

            End If

        Catch ex As Exception
            ModuleAccess = 1
        End Try

        CheckModuleAccess = ModuleAccess

    End Function

    Public Sub SignOut()

        If Session("NewLicenseKey") IsNot Nothing AndAlso Session("NewLicenseKey") = True AndAlso Session("CurrentSessionId") IsNot Nothing AndAlso _Session IsNot Nothing Then

            AdvantageFramework.Security.LicenseKey.Clear(_Session, "", Session("CurrentSessionId"), "")

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE SEC_USER_ID = " & _Session.User.ID)

                End Using

            Catch ex As Exception

            End Try

        Else

            Try

                If _Session IsNot Nothing AndAlso Session("CurrentSessionId") IsNot Nothing Then

                    _Session.UnregisterSecuritySession(Session("CurrentSessionId"))

                End If

            Catch ex As Exception

            End Try

        End If

        cSecurity.DeleteCacheDependencyFile(Session("CurrentSessionId"))
        System.Web.Security.FormsAuthentication.SignOut()
        MiscFN.ResponseRedirect("~/mobile/Login.aspx")
        Exit Sub

    End Sub

End Class
