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

    Public Class PhaseController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/ProjectSchedule/Phase"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.ProjectSchedule.PhaseSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.ProjectSchedule.PhaseSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_ProjectSchedule_Phase")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel = Nothing

            PhaseSetupViewModel = _Controller.Load()

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/project-schedule/phase/phase"
            'AureliaModel.ViewModel = PhaseSetupViewModel.Phases.Select(Function(dt) New AdvantageFramework.DTO.Maintenance.Accounting.Phase(dt)).ToList

            ViewBag.Title = "Phase Maintenance"

            Return Aurelia(AureliaModel)

        End Function

#End Region


#Region " API "

        Public Function GetPhases() As System.Web.Mvc.JsonResult

            Dim Phases As IEnumerable = Nothing

            Phases = _Controller.GetPhases().Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase.FromEntity(t)).ToList

            Return Json(Phases, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeletePhases(ByVal Phases As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(Phases.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function UpdatePhases(ByVal Phases As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(Phases.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function CreatePhases(ByVal Phases As IEnumerable(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Mvc.JsonResult

            'objects
            Dim Created As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)

            Created = _Controller.Add(Phases.ToList).Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase.FromEntity(t)).ToList

            Return Json(Created)

        End Function
        Public Function GetPhase(ByVal ID As Integer) As System.Web.Mvc.JsonResult

            'objects
            Dim Phase As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase = Nothing

            Try

                Phase = _Controller.GetPhases().Where(Function(t) t.ID = ID).Select(Function(t) AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase.FromEntity(t)).SingleOrDefault

            Catch ex As Exception
                Phase = Nothing
            End Try

            Return Json(Phase, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        Public Function PhaseExists(ByVal ID As Integer, ByVal Description As String) As Boolean

            Dim result As Boolean
            Dim Phase As IEnumerable(Of AdvantageFramework.Database.Entities.Phase) = Nothing

            Phase = (From Item In _Controller.Load.Phases
                     Where Item.Description.ToLower = Description.ToLower
                     Where Not Item.ID = ID).ToList

            If Phase.Count > 0 Then
                result = True
            End If

            Return result

        End Function

        'Public Function InitPhaseMaintenance() As Mvc.JsonResult

        '    'objects
        '    Dim Functions As IEnumerable = Nothing
        '    Dim Phases As IEnumerable = Nothing

        '    Functions = (From Item In _Controller.LoadFunctionCodes
        '                 Order By Item.Description Ascending
        '                 Select New With {.value = Item.Code,
        '                                  .text = Item.Description}).ToList

        '    Phases = (From Item In _Controller.LoadPhases
        '                Order By Item.Description Ascending
        '                Select New With {.value = Item.Code,
        '                                 .text = Item.Description}).ToList.ToList

        '    Return Json(New With {.Functions = Functions, .Phases = Phases}, Mvc.JsonRequestBehavior.AllowGet)

        'End Function

#End Region

#End Region

    End Class

End Namespace
