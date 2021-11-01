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

    Public Class NielsenTVAudienceController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, BookID As Integer, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience)

            'Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience) = Nothing
            Dim PageSize As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Try

                PageSize = My.Settings.Item("PageSize")

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                    'Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience).Where(Function(Entity) Entity.NielsenTVBookID = BookID AndAlso
                    '                                                                                                                     Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                    'TotalCount = Query.Count()

                    TotalCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.NIELSEN_TV_AUDIENCE WITH (FORCESEEK, INDEX(NIELSEN_TV_AUDIENCE_UNIQUE)) WHERE NIELSEN_TV_BOOK_ID = {0} AND NIELSEN_TV_AUDIENCE_ID > {1}", BookID, IDGreaterThan)).First

                    TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                    Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                    System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                    'Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenTVAudience(s))

                    Results = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience)(String.Format("exec [advsp_webapi_get_nielsen_tv_audience] {0}, {1}, {2}, {3}", IDGreaterThan, BookID, PageSize, Page)).ToList
                               Select New AdvantageFramework.DTO.Nielsen.NielsenTVAudience(Entity)).ToList

                End Using

            Catch ex As Exception

                ProcessException(ex, "APINielsen")

                ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                    If ex.InnerException.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                    End If

                End If

                Results = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience)

            End Try

            Return Results

        End Function
        <HttpGet>
        <Route("api/NielsenTVAudience/Get2")>
        Public Function [Get2](IDGreaterThan As Long, BookID As Integer, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience)

            Dim Query As IEnumerable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenTVAudience) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVAudience)(String.Format("exec advsp_api_get_tv_audience {0}, {1}", BookID, IDGreaterThan))

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.AsQueryable.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenTVAudience(s))

            End Using

            Return Results

        End Function

    End Class

End Namespace
