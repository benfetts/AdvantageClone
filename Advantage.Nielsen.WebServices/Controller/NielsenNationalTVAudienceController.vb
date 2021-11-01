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

    Public Class NielsenNationalTVAudienceController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenNationalTVAudience)

            'objects
            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            'Dim UrlHelper As System.Web.Http.Routing.UrlHelper = Nothing
            'Dim RouteValues As Dictionary(Of String, Object) = Nothing
            'Dim PrevLink As String = ""
            'Dim NextLink As String = ""
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenNationalTVAudience) = Nothing
            Dim PageSize As Integer = 0

            PageSize = My.Settings.Item("PageSize")

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience).Where(Function(Entity) Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                TotalCount = Query.Count()

                TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                'UrlHelper = New System.Web.Http.Routing.UrlHelper(Request)

                'If Page > 0 Then

                '    RouteValues = New Dictionary(Of String, Object)
                '    RouteValues.Add("Page", Page - 1)
                '    'RouteValues.Add("PageSize", PageSize)

                '    PrevLink = UrlHelper.Link("NielsenNationalTVAudience", RouteValues) 'New With {.controller = "NielsenNationalTVAudience", .page = Page - 1})

                'End If

                'If Page < TotalPages - 1 Then

                '    RouteValues = New Dictionary(Of String, Object)
                '    RouteValues.Add("Page", Page + 1)
                '    'RouteValues.Add("PageSize", PageSize)

                '    NextLink = UrlHelper.Link("NielsenNationalTVAudience", RouteValues)

                'End If

                Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenNationalTVAudience(s))

            End Using

            Return Results

        End Function

    End Class

End Namespace