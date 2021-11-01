Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting
Imports Newtonsoft.Json
Imports Webvantage.ViewModels

Namespace Controllers.SignIn

    Public Class SignInController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "SignIn/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Views "

        Public Function Index() As ActionResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Success = MiscFN.SignOutOfWebvantage(SecuritySession, ErrorMessage)

            Return View()

        End Function

#End Region

#End Region

    End Class

End Namespace
