Imports System.Web.Mvc
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc
Imports Webvantage.Controllers
Imports System.Globalization

Namespace Controllers.Maintenance.General

    <Serializable()>
    Public Class EmailSettingsController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/General/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.General.EmailSettingsController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.General.EmailSettingsController(Me.SecuritySession)

        End Sub
        Public Function Index() As System.Web.Mvc.ActionResult

            Dim EmailSettingsViewModel As AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel = Nothing

            EmailSettingsViewModel = _Controller.Load()

            Return View(EmailSettingsViewModel)

        End Function
        <AcceptVerbs("POST")>
        Public Function Save(EmailSettingsViewModel As AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel) As System.Web.Mvc.ActionResult

            Dim Saved As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Saved = _Controller.Save(EmailSettingsViewModel, ErrorMessage)

            Return RedirectToAction("Index")

        End Function
        <AcceptVerbs("POST")>
        Public Function SaveSMTPAuthenticationMethodType(SMTPAuthenticationMethodType As String) As JsonResult

            Dim ReturnObject As Object = Nothing

            Try

                _Controller.SaveSMTPAuthenticationMethodType(SMTPAuthenticationMethodType)

            Catch ex As Exception

            End Try

            If ReturnObject Is Nothing Then

                ReturnObject = False

            End If

            Return Json(ReturnObject)

        End Function
        Public Function DisableOAuth2() As System.Web.Mvc.ActionResult

            _Controller.DisableOAuth2()

            Return RedirectToAction("Index")

        End Function
        'Public Async Function EnableOAuth2() As Threading.Tasks.Task(Of System.Web.Mvc.ActionResult)

        '    Dim JavaScriptResult As System.Web.Mvc.JavaScriptResult = Nothing
        '    Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
        '    Dim AuthorizationUri As System.Uri = Nothing
        '    Dim AuthorizationURL As String = String.Empty

        '    'Service = InitializeGoogleService()

        '    'If Service IsNot Nothing Then

        '    '    EmailSettingsViewModel.GoogleOAuth2Uri = AuthorizationUri.ToString

        '    'End If

        '    'Service = _Controller.InitializeGoogleService

        '    'If Service IsNot Nothing Then

        '    '    Service.Authorize()

        '    'End If

        '    'EmailSettingsViewModel.GoogleOAuth2Uri = "OAuth2Enable(""" & AuthorizationURL & """)"

        '    Return RedirectToAction("Index")

        'End Function

#End Region

    End Class

End Namespace
