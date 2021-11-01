Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing
Imports MvcCodeRouting.Web.Mvc

Namespace Controllers.Maintenance.ProjectManagement

    Public Class JobTypeController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectManagement/JobType"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.ProjectManagement.JobTypeSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.ProjectManagement.JobTypeSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectManagement_JobType")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel = Nothing

            JobTypeSetupViewModel = _Controller.Load()

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/project-management/jobtype/jobtype"
            'AureliaModel.ViewModel = JobTypeSetupViewModel.JobTypes.Select(Function(dt) New AdvantageFramework.DTO.Maintenance.Accounting.JobType(dt)).ToList

            ViewBag.Title = "Job Type Maintenance"

            Return Aurelia(AureliaModel)

        End Function

#End Region


#Region " API "

        Public Function GetJobTypes() As System.Web.Mvc.JsonResult

            Dim JobTypes As IEnumerable = Nothing

            JobTypes = _Controller.GetJobTypes().Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType.FromEntity(t)).ToList

            Return Json(JobTypes, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteJobTypes(ByVal JobTypes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(JobTypes.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateJobTypes(ByVal JobTypes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(JobTypes.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function CreateJobTypes(ByVal JobTypes As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.Add(JobTypes.ToList)

            Return Json(Created)

        End Function
        Public Function GetJobType(ByVal Code As String) As System.Web.Mvc.JsonResult

            'objects
            Dim JobType As AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType = Nothing

            Try

                JobType = _Controller.GetJobTypes().Where(Function(t) t.Code = Code).Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType.FromEntity(t)).SingleOrDefault

            Catch ex As Exception
                JobType = Nothing
            End Try

            Return Json(JobType, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        Public Function JobTypeExists(ByVal Code As String) As Boolean

            Dim result As Boolean
            Dim JobType As IEnumerable(Of AdvantageFramework.Database.Entities.JobType) = Nothing

            JobType = (From Item In _Controller.Load.JobTypes
                       Where Item.Code.ToLower() = Code.ToLower()).ToList

            If JobType.Count > 0 Then
                result = True
            End If

            Return result

        End Function
        Public Function InitJobTypeMaintenance() As Mvc.JsonResult

            'objects
            Dim SalesClassCodes As IEnumerable = Nothing


            SalesClassCodes = (From Item In _Controller.LoadSalesClasses
                               Order By Item.Description Ascending
                               Select New With {.value = Item.Code,
                                                .text = Item.Description}).ToList


            Return Json(New With {.SalesClassCodes = SalesClassCodes}, Mvc.JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

    End Class

End Namespace
