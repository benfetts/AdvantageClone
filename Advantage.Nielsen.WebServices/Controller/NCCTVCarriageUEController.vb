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

    Public Class NCCTVCarriageUEController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, NCCTVCarriageUELogID As Integer, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVCarriageUE).Where(Function(Entity) Entity.NCCTVCarriageUELogID = NCCTVCarriageUELogID AndAlso
                                                                                                                                   Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NCCTVCarriageUE(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NCCTVCarriageUE/GetCountByNCCTVCarriageUELogID")>
        Public Function [GetCountByNCCTVAIUELogID](NCCTVCarriageUELogID As Long) As Int64

            Dim NCCCountByID As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NCCCountByID = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT CAST(COALESCE(COUNT(1), 0) as bigint) FROM dbo.NCC_TV_CARRIAGE_UE WHERE NCC_TV_CARRIAGE_UE_LOG_ID = {0}", NCCTVCarriageUELogID)).First

            End Using

            Return NCCCountByID

        End Function

    End Class

End Namespace