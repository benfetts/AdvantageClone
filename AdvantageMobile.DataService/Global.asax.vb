Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        AdvantageMobile.DataService.CorsSupport.HandlePreflightRequest(HttpContext.Current)

    End Sub
    Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        AdvantageMobile.DataService.Application.AddToEventLog("DataServices Started", Diagnostics.EventLogEntryType.Information)

    End Sub
    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Try

            Dim ex As Exception = HttpContext.Current.Server.GetLastError()

            If ex IsNot Nothing Then

                AdvantageMobile.DataService.Application.ErrorToEventLog(ex)

            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
