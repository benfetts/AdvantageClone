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

Namespace Controllers.Maintenance.Accounting

    Public Class DepartmentTeamController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/Accounting/DepartmentTeam"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_Accounting_DepartmentTeam")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/accounting/department-team/department-team"

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region "  API "

        Public Function GetDepartmentTeams() As JsonResult

            'objects
            Dim DepartmentTeams As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam) = Nothing

            DepartmentTeams = _Controller.GetDepartmentTeamsDTO()

            Return Json(DepartmentTeams, JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateDepartmentTeams(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(DepartmentTeams.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteDepartmentTeams(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(DepartmentTeams.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function CreateDepartmentTeams(ByVal DepartmentTeams As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.DepartmentTeam)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.Add(DepartmentTeams.ToList)

            Return Json(Created)

        End Function
        Public Function GetPurchaseOrderApprovalRules() As Mvc.JsonResult

            'objects
            Dim POApprovalRules As IEnumerable = Nothing

            POApprovalRules = (From Item In _Controller.LoadPurchaseOrderApprovalRules
                               Select New With {.Code = Item.Code,
                                                .Description = Item.Description}).ToList

            Return Json(POApprovalRules, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetServiceFeeTypes() As Mvc.JsonResult

            'objects
            Dim ServiceFeeTypes As IEnumerable = Nothing

            ServiceFeeTypes = (From Item In _Controller.LoadServiceFeeTypes
                               Select New With {.Code = Item.Code,
                                                .Description = Item.Description}).ToList

            Return Json(ServiceFeeTypes, Mvc.JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

    End Class

End Namespace
