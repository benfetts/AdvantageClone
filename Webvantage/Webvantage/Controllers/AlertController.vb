Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels

Namespace Controllers

    Public Class AlertController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Index(ByVal AlertID As Integer) As ActionResult

            Dim AlertModel As New Webvantage.Models.AlertModel(Me.SecuritySession, AlertID)
            Return View(AlertModel)

        End Function

#End Region

    End Class

End Namespace