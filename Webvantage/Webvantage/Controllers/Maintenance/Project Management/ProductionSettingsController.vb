Imports System.Collections.ProjectSchedule
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc

Namespace Controllers.Maintenance.ProjectManagement

    Public Class ProductionSettingsController
        Inherits Controllers.Utilities.SettingsController

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectManagement/ProductionSettings"

#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            _SettingModuleID = 2

            MyBase.Initialize(requestContext)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectManagement_ProductionSettings")>
        Public Function Index() As System.Web.Mvc.ActionResult

            Return SettingsPage()

        End Function

#End Region


#Region " API "


#End Region

#End Region

    End Class

End Namespace
