Imports System.Collections.ProjectSchedule
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc

Namespace Controllers.Maintenance.ProjectSchedule

    Public Class SettingController
        Inherits Controllers.Utilities.SettingsController

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectSchedule/Setting"

#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            _SettingModuleID = 0

            MyBase.Initialize(requestContext)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectSchedule_Settings")>
        Public Function Index() As System.Web.Mvc.ActionResult

            Return SettingsPage()

        End Function

#End Region


#Region " API "


#End Region

#End Region

    End Class

End Namespace
