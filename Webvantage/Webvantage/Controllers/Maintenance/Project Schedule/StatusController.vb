Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc

Namespace Controllers.Maintenance.ProjectSchedule

    Public Class StatusController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectSchedule/Status"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.ProjectSchedule.StatusSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.ProjectSchedule.StatusSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectSchedule_Status")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel = Nothing

            StatusSetupViewModel = _Controller.Load()

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/project-schedule/status/status"
            'AureliaModel.ViewModel = StatusSetupViewModel.Statuses.Select(Function(dt) New AdvantageFramework.DTO.Maintenance.Accounting.Status(dt)).ToList

            ViewBag.Title = "Status Maintenance"

            Return Aurelia(AureliaModel)

        End Function

#End Region


#Region " API "

        Public Function GetStatuses() As System.Web.Mvc.JsonResult

            Dim Statuses As IEnumerable = Nothing

            Statuses = _Controller.GetStatuses().Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status.FromEntity(t)).ToList

            Return Json(Statuses, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteStatuses(ByVal Statuses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(Statuses.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateStatuses(ByVal Statuses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(Statuses.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function CreateStatuses(ByVal Statuses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.Add(Statuses.ToList)

            Return Json(Created)

        End Function
        Public Function GetStatus(ByVal Code As String) As System.Web.Mvc.JsonResult

            'objects
            Dim Status As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status = Nothing

            Try

                Status = _Controller.GetStatuses().Where(Function(t) t.Code = Code).Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status.FromEntity(t)).SingleOrDefault

            Catch ex As Exception
                Status = Nothing
            End Try

            Return Json(Status, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        Public Function StatusExists(ByVal Code As String) As Boolean

            Dim result As Boolean
            Dim Status As IEnumerable(Of AdvantageFramework.Database.Entities.Status) = Nothing

            Status = (From Item In _Controller.Load.Statuses
                      Where Item.Code.ToLower() = Code.ToLower()).ToList

            If Status.Count > 0 Then
                result = True
            End If

            Return result

        End Function
        'Public Function InitStatusMaintenance() As Mvc.JsonResult

        '    'objects
        '    Dim Functions As IEnumerable = Nothing
        '    Dim Statuses As IEnumerable = Nothing

        '    Functions = (From Item In _Controller.LoadFunctionCodes
        '                 Order By Item.Description Ascending
        '                 Select New With {.value = Item.Code,
        '                                  .text = Item.Description}).ToList

        '    Statuses = (From Item In _Controller.LoadStatuses
        '                Order By Item.Description Ascending
        '                Select New With {.value = Item.Code,
        '                                 .text = Item.Description}).ToList.ToList

        '    Return Json(New With {.Functions = Functions, .Statuses = Statuses}, Mvc.JsonRequestBehavior.AllowGet)

        'End Function

#End Region

#End Region

    End Class

End Namespace
