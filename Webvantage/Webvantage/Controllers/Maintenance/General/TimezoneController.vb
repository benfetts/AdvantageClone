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
Imports Webvantage.Controllers
Imports System.Globalization

Namespace Controllers.Maintenance.General

    <Serializable()>
    Public Class TimezoneController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Maintenance/General/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.General.TimezoneController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Views "

        Public Function Index() As System.Web.Mvc.ActionResult

            Dim TzVm As New AdvantageFramework.ViewModels.Maintenance.General.TimezoneSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Timezones As Generic.List(Of TimeZoneInfo) = Nothing

                Timezones = AdvantageFramework.Database.Procedures.TimeZone.LoadSystemTimeZones()

                If Timezones IsNot Nothing Then

                    Dim ThisTimezone As AdvantageFramework.ViewModels.Maintenance.General.TimezoneViewModel = Nothing

                    For Each tz In Timezones

                        ThisTimezone = New AdvantageFramework.ViewModels.Maintenance.General.TimezoneViewModel

                        ThisTimezone.Id = tz.Id
                        ThisTimezone.StandardName = tz.StandardName

                        TzVm.Timezones.Add(ThisTimezone)

                        ThisTimezone = Nothing

                    Next

                End If

                Dim agy As New AdvantageFramework.Database.Entities.Agency
                agy = Nothing

                agy = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Not agy Is Nothing Then

                    If Not agy.DatabaseServerTimeZoneID Is Nothing AndAlso String.IsNullOrWhiteSpace(agy.DatabaseServerTimeZoneID) = False Then

                        TzVm.DatabaseServerTimezoneID = agy.DatabaseServerTimeZoneID

                    Else

                        TzVm.DatabaseServerTimezoneID = ""

                    End If
                    If Not agy.TimeZoneID Is Nothing AndAlso String.IsNullOrWhiteSpace(agy.TimeZoneID) = False Then

                        TzVm.AgencyTimezoneID = agy.TimeZoneID

                    Else

                        TzVm.DatabaseServerTimezoneID = ""


                    End If

                End If

                If String.IsNullOrWhiteSpace(TzVm.AgencyTimezoneID) = True Then TzVm.AgencyTimezoneID = "-1"
                If String.IsNullOrWhiteSpace(TzVm.DatabaseServerTimezoneID) = True Then TzVm.DatabaseServerTimezoneID = "-1"

            End Using

            Return View(TzVm)

        End Function

#End Region

#Region " Methods "

        <AcceptVerbs("POST")>
        Public Function SaveTimezone(ByVal DatabaseServerTimeZoneID As String,
                                     ByVal AgencyTimeZoneID As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing
            Dim SomeReturnProperty As String

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Agency As New AdvantageFramework.Database.Entities.Agency
                    Agency = Nothing

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If AgencyTimeZoneID <> "-1" Then

                            Agency.TimeZoneID = AgencyTimeZoneID

                        Else

                            Agency.TimeZoneID = Nothing

                        End If
                        If DatabaseServerTimeZoneID <> "-1" Then

                            Agency.DatabaseServerTimeZoneID = DatabaseServerTimeZoneID

                        Else

                            Agency.DatabaseServerTimeZoneID = Nothing

                        End If

                        Success = AdvantageFramework.Database.Procedures.Agency.Update(DbContext, Agency)

                    End If

                    If Success = True Then

                        ReturnObject = New With {.SomeJsProperty = SomeReturnProperty}

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function


        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Maintenance.General.TimezoneController(Me.SecuritySession)

        End Sub

#End Region

    End Class

End Namespace
