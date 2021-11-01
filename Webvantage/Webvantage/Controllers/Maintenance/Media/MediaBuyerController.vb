'Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports System.Web.Routing

Namespace Controllers.Maintenance.Media

    Public Class MediaBuyerController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/Media/MediaBuyer/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(RequestContext As RequestContext)

            MyBase.Initialize(RequestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaBuyerSetupController(Me.SecuritySession)

        End Sub

#Region " Views "

        Public Function Index() As System.Web.Mvc.ActionResult

            Return View()

        End Function

#End Region

        Public Function EmployeeListRead(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As System.Web.Mvc.JsonResult

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

            ViewModel = _Controller.Load()

            DataSourceResult = ViewModel.RepositoryEmployeeList.ToDataSourceResult(DataSourceRequest)

            Return Json(DataSourceResult, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function MediaBuyerCreate(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
                                         ByVal MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel) As System.Web.Mvc.JsonResult

            'objects
            Dim ErrorMessage As String = Nothing

            If _Controller.Add(MediaBuyerSetupDetailViewModel, ErrorMessage) Then

            End If

            Return Json(MediaBuyerSetupDetailViewModel)

        End Function
        Public Function MediaBuyerRead(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As System.Web.Mvc.JsonResult

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel = Nothing
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

            ViewModel = _Controller.Load()

            'ViewData("Employees") = ViewModel.RepositoryEmployeeList

            DataSourceResult = ViewModel.MediaBuyers.ToDataSourceResult(DataSourceRequest)

            Return Json(DataSourceResult, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function MediaBuyerUpdate(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
                                         ByVal MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel) As System.Web.Mvc.JsonResult

            'objects
            Dim ErrorMessage As String = Nothing

            'If _Controller.UpdateInactiveFlag(MediaBuyerSetupDetailViewModel, ErrorMessage) Then

            'End If

            Return Json(MediaBuyerSetupDetailViewModel)

        End Function
        Public Function MediaBuyerDelete(ID As Integer) As System.Web.Mvc.JsonResult

            'objects
            Dim ErrorMessage As String = Nothing

            'If _Controller.Delete(MediaBuyerSetupDetailViewModel, ErrorMessage) Then

            'End If

            'Return Json(MediaBuyerSetupDetailViewModel)

        End Function

#End Region

    End Class

End Namespace
