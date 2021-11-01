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

    Public Class TaskController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectSchedule/Task"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.ProjectSchedule.TaskSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.ProjectSchedule.TaskSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectSchedule_Task")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel = Nothing

            TaskSetupViewModel = _Controller.Load()

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/project-schedule/task/task"
            'AureliaModel.ViewModel = TaskSetupViewModel.Tasks.Select(Function(dt) New AdvantageFramework.DTO.Maintenance.Accounting.Task(dt)).ToList

            ViewBag.Title = "Task Maintenance"

            Return Aurelia(AureliaModel)

        End Function

#End Region


#Region " API "

        Public Function GetTasks() As System.Web.Mvc.JsonResult

            Dim Tasks As IEnumerable = Nothing

            Tasks = _Controller.GetTasks().Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task.FromEntity(t)).ToList

            Return Json(Tasks, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteTasks(ByVal Tasks As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(Tasks.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateTasks(ByVal Tasks As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(Tasks.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function CreateTasks(ByVal Tasks As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.Add(Tasks.ToList)

            Return Json(Created)

        End Function
        Public Function GetTask(ByVal Code As String) As System.Web.Mvc.JsonResult

            'objects
            Dim Task As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task = Nothing

            Try

                Task = _Controller.GetTasks().Where(Function(t) t.Code = Code).Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task.FromEntity(t)).SingleOrDefault

            Catch ex As Exception
                Task = Nothing
            End Try

            Return Json(Task, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetFunctionCodes() As Mvc.JsonResult

            'objects
            Dim FunctionCodes As IEnumerable = Nothing

            FunctionCodes = (From Item In _Controller.LoadFunctionCodes
                             Order By Item.Description Ascending
                             Select New With {.Code = Item.Code,
                                              .Description = Item.Description}).ToList

            Return Json(FunctionCodes, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetRoles() As Mvc.JsonResult

            'objects
            Dim Roles As IEnumerable = Nothing

            Roles = (From Item In _Controller.LoadRoles
                     Order By Item.Description Ascending
                     Select New With {.Code = Item.Code,
                                      .Description = Item.Description}).ToList

            Return Json(Roles, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetStatusCodes() As Mvc.JsonResult

            'objects
            Dim Statuses As IEnumerable = Nothing

            Statuses = (From Item In _Controller.LoadStatuses
                        Order By Item.Description Ascending
                        Select New With {.Code = Item.Code,
                                                .Description = Item.Description}).ToList

            Return Json(Statuses, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function TaskExists(ByVal Code As String) As Boolean

            Dim result As Boolean
            Dim Task As IEnumerable(Of AdvantageFramework.Database.Entities.Task) = Nothing

            Task = (From Item In _Controller.Load.Tasks
                    Where Item.Code.ToLower() = Code.ToLower()).ToList

            If Task.Count > 0 Then
                result = True
            End If

            Return result

        End Function
        Public Function InitTaskMaintenance() As Mvc.JsonResult

            'objects
            Dim Functions As IEnumerable = Nothing
            Dim Statuses As IEnumerable = Nothing

            Functions = (From Item In _Controller.LoadFunctionCodes
                         Order By Item.Description Ascending
                         Select New With {.value = Item.Code,
                                          .text = Item.Description}).ToList

            Statuses = (From Item In _Controller.LoadStatuses
                        Order By Item.Description Ascending
                        Select New With {.value = Item.Code,
                                         .text = Item.Description}).ToList.ToList

            Return Json(New With {.Functions = Functions, .Statuses = Statuses}, Mvc.JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

    End Class

End Namespace
