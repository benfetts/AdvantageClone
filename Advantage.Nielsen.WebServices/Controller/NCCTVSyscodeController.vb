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

    Public Class NCCTVSyscodeController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode).Where(Function(Entity) Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NCCTVSyscode(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NCCTVSyscode/GetExisting")>
        Public Function GetExisting(IDLessThanEqualTo As Long, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NCCTVSyscode) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode).Where(Function(Entity) Entity.ID <= IDLessThanEqualTo).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NCCTVSyscode(s))

            End Using

            Return Results

        End Function

        <HttpGet>
        <Route("api/NCCTVSyscode/IsNCCSubscribed")>
        Public Function IsNCCSubscribed(ClientCode As String) As Boolean

            Dim IsSubscribed As Boolean = False

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                IsSubscribed = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT IS_NCC_SUBSCRIBED FROM dbo.CLIENT WHERE CODE = '{0}'", ClientCode)).FirstOrDefault

            End Using

            Return IsSubscribed

        End Function

    End Class

End Namespace