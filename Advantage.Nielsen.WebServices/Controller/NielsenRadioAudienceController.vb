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

    Public Class NielsenRadioAudienceController
        Inherits ApiController

        Public Function [Get](IDGreaterThan As Long, <FromUri> SegmentParentIDs As Generic.List(Of Integer), Optional Page As Integer = 0) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience) = Nothing
            Dim TotalCount As Integer = 0
            Dim TotalPages As Integer = 0
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience) = Nothing
            Dim PageSize As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Try

                PageSize = My.Settings.Item("PageSize")

                Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                    Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioAudience).Where(Function(Entity) SegmentParentIDs.Contains(Entity.SegmentParentID) AndAlso
                                                                                                                                            Entity.ID > IDGreaterThan).OrderBy(Function(Entity) Entity.ID)

                    TotalCount = Query.Count()

                    TotalPages = CInt(Math.Ceiling(CDbl(TotalCount) / PageSize))

                    Dim PaginationHeader = New With {
                                Key .TotalCount = TotalCount,
                                Key .TotalPages = TotalPages,
                                Key .NextPage = If(Page < TotalPages, Page + 1, -1)
                            }

                    System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(PaginationHeader))

                    Results = Query.Skip(PageSize * Page).Take(PageSize).ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenRadioAudience(s)).ToList

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

                Results = New Generic.List(Of AdvantageFramework.DTO.Nielsen.NielsenRadioAudience)

            End Try

            Return Results

        End Function

    End Class

End Namespace
