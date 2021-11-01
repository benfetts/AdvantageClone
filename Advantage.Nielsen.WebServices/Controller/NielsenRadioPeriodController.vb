Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.Hosting
Imports System.Web.Http
Imports System.Web.Http.Filters

Namespace Controller

    Public Class NielsenRadioPeriodController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenRadioPeriod/GetByPeriodID")>
        Public Function [Get](PeriodID As Integer) As AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod

            Dim NielsenRadioPeriodEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim ClientNielsenRadioPeriod As AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioPeriodEntity = DbContext.NielsenRadioPeriods.Find(PeriodID)

                ClientNielsenRadioPeriod = New AdvantageFramework.DTO.Nielsen.NielsenRadioPeriod(NielsenRadioPeriodEntity)

            End Using

            Return ClientNielsenRadioPeriod

        End Function

        <HttpGet>
        <Route("api/NielsenRadioPeriod/GetPeriodRowCount")>
        Public Function [GetBookRowCount](PeriodID As Integer) As Int64

            Dim NielsenRadioPeriodRowCount As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioPeriodRowCount = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_radio_rowcount]({0})", PeriodID)).First

            End Using

            Return NielsenRadioPeriodRowCount

        End Function

        <HttpGet>
        <Route("api/NielsenRadioPeriod/GetByClientCode")>
        Public Function [Get](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)

            Dim ClientNielsenRadioPeriods As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenRadioPeriods = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)(String.Format("exec [advsp_nielsen_radio_get_periods] '{0}'", ClientCode)).ToList

            End Using

            Return ClientNielsenRadioPeriods

        End Function

        <HttpGet>
        <Route("api/NielsenRadioPeriod/GetEastlanRadioPeriods")>
        Public Function [GetEastlanRadioPeriods]() As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)

            Dim ClientNielsenRadioPeriods As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenRadioPeriods = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)("exec [advsp_eastlan_radio_get_periods]").ToList

            End Using

            Return ClientNielsenRadioPeriods

        End Function

    End Class

End Namespace