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

    Public Class NielsenTVUniverseController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, MarketNumber As Integer, Year As Short, Month As Short, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse).Where(Function(Entity) Entity.NielsenMarketNumber = MarketNumber AndAlso
                                                                                                                                     Entity.Year = Year AndAlso
                                                                                                                                     Entity.Month = Month AndAlso
                                                                                                                                     Entity.ReportingService = "1" AndAlso
                                                                                                                                     Entity.Exclusion = "" AndAlso
                                                                                                                                     Entity.Ethnicity = "" AndAlso
                                                                                                                                     Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenTVUniverse(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NielsenTVUniverse/GetUniverse")>
        Public Function [GetSingleUniverse](MarketNumber As Integer, Year As Short, Month As Short, ReportingService As String, Exclusion As String, Ethnicity As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse)

            Dim Universe As AdvantageFramework.Nielsen.Database.Entities.NielsenTVUniverse = Nothing
            Dim NielsenTVUniverses As Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse) = Nothing
            Dim LocalExclusion As String = String.Empty
            Dim LocalEthnicity As String = String.Empty

            If String.IsNullOrWhiteSpace(Exclusion) = False Then

                LocalExclusion = Exclusion

            End If

            If String.IsNullOrWhiteSpace(Ethnicity) = False Then

                LocalEthnicity = Ethnicity

            End If

            NielsenTVUniverses = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVUniverse)

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Universe = (From Entity In DbContext.NielsenTVUniverses
                            Where Entity.NielsenMarketNumber = MarketNumber AndAlso
                                  Entity.Year = Year AndAlso
                                  Entity.Month = Month AndAlso
                                  Entity.ReportingService = ReportingService AndAlso
                                  Entity.Exclusion = LocalExclusion AndAlso
                                  Entity.Ethnicity = LocalEthnicity
                            Select Entity).SingleOrDefault

                If Universe IsNot Nothing Then

                    NielsenTVUniverses.Add(New AdvantageFramework.DTO.Nielsen.NielsenTVUniverse(Universe))

                End If

            End Using

            Return NielsenTVUniverses

        End Function

    End Class

End Namespace