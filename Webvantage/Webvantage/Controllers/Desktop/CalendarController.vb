Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MvcCodeRouting.Web.Mvc
Imports System.Data.SqlClient

Namespace Controllers.Desktop

    <Serializable()>
    Public Class CalendarController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Desktop/Calendar/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Desktop.CalendarController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Aurelia Views "

#End Region
#Region " Razor Views "
        Public Function Index() As ActionResult

            Return View()

        End Function

#End Region

#Region "API"

#Region " Get "
        'Http Get methods
#End Region
#Region " Post "
        'Http post methods
#End Region

#End Region

#Region " Private "
        'Private methods
#End Region

#Region " Classes "
        'class classes
#End Region

#Region " Initialize "
        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

            MyBase.Initialize(requestContext)

            ' _Controller = New Object ' New AdvantageFramework.Controller.ProjectManagement.JobJacketController(Me.SecuritySession)

        End Sub

#End Region

#End Region

    End Class

End Namespace

