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

    Public Class NielsenRadioCountyPeriodController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenRadioCountyPeriod/GetByPeriodID")>
        Public Function [Get](PeriodID As Integer) As AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod

            Dim NielsenRadioCountyPeriodEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod = Nothing
            Dim NielsenRadioCountyPeriod As AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioCountyPeriodEntity = DbContext.NielsenRadioCountyPeriods.Find(PeriodID)

                NielsenRadioCountyPeriod = New AdvantageFramework.DTO.Nielsen.NielsenRadioCountyPeriod(NielsenRadioCountyPeriodEntity)

            End Using

            Return NielsenRadioCountyPeriod

        End Function

        <HttpGet>
        <Route("api/NielsenRadioCountyPeriod/GetPeriodRowCount")>
        Public Function [GetBookRowCount](PeriodID As Integer) As Int64

            Dim NielsenRadioPeriodRowCount As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioPeriodRowCount = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_radio_county_rowcount_by_period]({0})", PeriodID)).First

            End Using

            Return NielsenRadioPeriodRowCount

        End Function

        <HttpGet>
        <Route("api/NielsenRadioCountyPeriod/GetByClientCode")>
        Public Function [Get](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod)

            Dim ClientNielsenRadioCountyPeriods As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenRadioCountyPeriods = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioCountyPeriod)(String.Format("exec [advsp_nielsen_radio_county_get_periods] '{0}'", ClientCode)).ToList

            End Using

            Return ClientNielsenRadioCountyPeriods

        End Function

    End Class

End Namespace