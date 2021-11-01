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

    Public Class NielsenRadioStationHistoryController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenRadioStationHistory/Get")>
        <Route("api/NielsenRadioStationHistory")>
        Public Function [Get](IDGreaterThan As Long, MarketNumber As Integer, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory).Where(Function(Entity) Entity.NielsenRadioMarketNumber = MarketNumber AndAlso
                                                                                                                                              Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NielsenRadioStationHistory/GetByMarketNumberSource")>
        Public Function [Get](IDGreaterThan As Long, MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStationHistory).Where(Function(Entity) Entity.NielsenRadioMarketNumber = MarketNumber AndAlso
                                                                                                                                              Entity.ID > IDGreaterThan AndAlso
                                                                                                                                              Entity.Source = Source).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenRadioStationHistory(s))

            End Using

            Return Results

        End Function

    End Class

End Namespace