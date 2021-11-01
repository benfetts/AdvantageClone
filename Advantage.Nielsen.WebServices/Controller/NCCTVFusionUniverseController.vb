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

    Public Class NCCTVFusionUniverseController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVFusionUniverse).Where(Function(Entity) Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NCCTVFusionUniverse/GetByClientCode")>
        Public Function [GetByClientCode](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse)

            Dim NCCTVFusionUniverses As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NCCTVFusionUniverses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.NCCTVFusionUniverse)(String.Format("exec [advsp_ncc_get_fusion_tv_ue_ids_by_client_code] '{0}'", ClientCode)).ToList

            End Using

            Return NCCTVFusionUniverses

        End Function

        <HttpGet>
        <Route("api/NCCTVFusionUniverse/GetCountByID")>
        Public Function [GetCountByID](NCCTVFusionUniverseID As Long) As Int64

            Dim NCCCountByID As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NCCCountByID = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_ncc_rowcount_by_fusion_ue_id]({0})", NCCTVFusionUniverseID)).First

            End Using

            Return NCCCountByID

        End Function

    End Class

End Namespace