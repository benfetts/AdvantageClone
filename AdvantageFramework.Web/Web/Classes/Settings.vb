Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Web.UI
Imports System.IO
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Web.SessionState

Namespace Web

    <Serializable()> _
    Public Class Settings

        Public Property ConnString_Pooling As Boolean = False
        Public Property ConnString_Timeout As Integer = 120
        Public Property ConnString_Lifetime As Integer = 15
        Public Property ConnString_Reset As Boolean = True
        Public Property ConnString_MaxPoolSize As Integer = 1
        Public Property ConnString_MinPoolSize As Integer = 0

        Public Property IsNTAuth As Boolean = False
        Public Property UpperCaseUserCode As Boolean = True
        Public Property UpperCaseDatabaseName As Boolean = True
        Public Property ChooseDatabaseServer As Boolean = True
        Public Property SQLControlledAdmin As Boolean = False
        Public Property NTAuth_IgnoreCase As Boolean = False
        Public Property VersionControlKey As String = ""
        Public Property ClientPortal_VersionControlKey As String = ""
        Public Property ActiveReportsLicense As String = ""
        Public Property MailBeeLicense As String = ""
        Public Property RestrictMobilePlatforms As String = ""
        Public Property EnableDocumentRepositorySize As Boolean = False
        Public Property AlertRefreshTimeout As Integer = -1
        Public Property CacheDependencyDirectory As String = ""

        Sub New()

            If Not System.Configuration.ConfigurationManager.AppSettings("CS_Pooling") Is Nothing Then
                Me.ConnString_Pooling = System.Configuration.ConfigurationManager.AppSettings("CS_Pooling")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CS_Timeout") Is Nothing Then
                Me.ConnString_Timeout = System.Configuration.ConfigurationManager.AppSettings("CS_Timeout")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CS_Lifetime") Is Nothing Then
                Me.ConnString_Lifetime = System.Configuration.ConfigurationManager.AppSettings("CS_Lifetime")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CS_Reset") Is Nothing Then
                Me.ConnString_Reset = System.Configuration.ConfigurationManager.AppSettings("CS_Reset")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CS_MaxPoolSize") Is Nothing Then
                Me.ConnString_MaxPoolSize = System.Configuration.ConfigurationManager.AppSettings("CS_MaxPoolSize")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CS_MinPoolSize") Is Nothing Then
                Me.ConnString_MinPoolSize = System.Configuration.ConfigurationManager.AppSettings("CS_MinPoolSize")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("Authentication") Is Nothing Then
                If System.Configuration.ConfigurationManager.AppSettings("Authentication") = "Forms" Then
                    Me.IsNTAuth = False
                Else
                    Me.IsNTAuth = True
                End If
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("VCtrl") Is Nothing Then
                Me.VersionControlKey = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("VCtrlCP") Is Nothing Then
                Me.ClientPortal_VersionControlKey = System.Configuration.ConfigurationManager.AppSettings("VCtrlCP")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("ActiveReportsLicense") Is Nothing Then
                Me.ActiveReportsLicense = System.Configuration.ConfigurationManager.AppSettings("ActiveReportsLicense")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("MailBee.Global.LicenseKey") Is Nothing Then
                Me.MailBeeLicense = System.Configuration.ConfigurationManager.AppSettings("MailBee.Global.LicenseKey")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("RestrictMobile") Is Nothing Then
                Me.RestrictMobilePlatforms = System.Configuration.ConfigurationManager.AppSettings("RestrictMobile")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize") Is Nothing Then
                If System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize") = "1" Then
                    Me.EnableDocumentRepositorySize = True
                End If
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("AlertRefresh") Is Nothing Then
                Me.AlertRefreshTimeout = System.Configuration.ConfigurationManager.AppSettings("AlertRefresh")
            End If
            If Not System.Configuration.ConfigurationManager.AppSettings("CacheDependencyDirectory") Is Nothing Then
                Me.CacheDependencyDirectory = System.Configuration.ConfigurationManager.AppSettings("CacheDependencyDirectory")
            End If

        End Sub

    End Class

End Namespace
