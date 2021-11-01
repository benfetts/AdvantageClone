Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc

Namespace Controllers.Maintenance.General

    Public Class IntegrationSettingController
        Inherits Controllers.Utilities.SettingsController

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/General/IntegrationSetting"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            _SettingModuleID = 7

            MyBase.Initialize(requestContext)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_General_IntegrationSettings")>
        Public Function Index() As System.Web.Mvc.ActionResult

            Return Me.SettingsPage()

        End Function

#End Region

#End Region

    End Class

End Namespace
