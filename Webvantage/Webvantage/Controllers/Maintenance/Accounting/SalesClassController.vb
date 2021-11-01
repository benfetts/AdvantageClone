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

    Public Class SalesClassController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/Accounting/SalesClass"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Accounting.SalesClassSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.SalesClassSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        <CustomRoute("~/Maintenance_Accounting_SalesClass")>
        Public Function Index() As System.Web.Mvc.ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New AureliaModel

            AureliaModel.App = "modules/maintenance/accounting/sales-class/sales-class"

            ViewBag.Title = "Sales Class Maintenance"

            Return Aurelia(AureliaModel)

        End Function

#End Region


#Region " API "

        Public Function GetSalesClasses() As System.Web.Mvc.JsonResult

            Dim SalesClasses As IEnumerable = Nothing

            SalesClasses = _Controller.GetSalesClasses().Select(Function(t) AdvantageFramework.DTO.Maintenance.Accounting.SalesClass.FromEntity(t)).ToList

            Return Json(SalesClasses, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteSalesClasses(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(SalesClasses.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function UpdateSalesClasses(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.Save(SalesClasses.ToList)

            Return Json(Updated)

        End Function
        <Mvc.HttpPost>
        Public Function CreateSalesClasses(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.DTO.Maintenance.Accounting.SalesClass)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.Add(SalesClasses.ToList)

            Return Json(Created)

        End Function
        Public Function GetSalesClass(ByVal Code As String) As System.Web.Mvc.JsonResult

            'objects
            Dim SalesClass As AdvantageFramework.DTO.Maintenance.Accounting.SalesClass = Nothing

            Try

                SalesClass = _Controller.GetSalesClasses().Where(Function(t) t.Code = Code).Select(Function(t) AdvantageFramework.DTO.Maintenance.Accounting.SalesClass.FromEntity(t)).SingleOrDefault

            Catch ex As Exception
                SalesClass = Nothing
            End Try

            Return Json(SalesClass, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetSalesClassTypes() As Mvc.JsonResult

            'objects
            Dim SalesClassTypes As IEnumerable = Nothing

            SalesClassTypes = _Controller.LoadSalesClassTypes.ToList

            Return Json(SalesClassTypes, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function SalesClassExists(ByVal Code As String) As Boolean

            Dim result As Boolean
            Dim SalesClass As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

            SalesClass = (From Item In _Controller.Load.SalesClasses
                          Where Item.Code.ToLower() = Code.ToLower()).ToList

            If SalesClass.Count > 0 Then
                result = True
            End If

            Return result

        End Function
        <Mvc.HttpGet>
        Public Function InitSalesClassMaintenance() As Mvc.JsonResult

            'objects
            Dim SalesClassTypes As IEnumerable = Nothing

            SalesClassTypes = (From Item In _Controller.LoadSalesClassTypes.ToList
                               Select New With {.value = Item.Code,
                                                .text = Item.Description}).ToList

            Return Json(New With {.SalesClassTypes = SalesClassTypes}, Mvc.JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

    End Class

End Namespace
