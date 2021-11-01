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

    Public Class NielsenTVBookController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenTVBook/GetByBookID")>
        Public Function [GetByBookID](BookID As Integer) As AdvantageFramework.DTO.Nielsen.NielsenTVBook

            Dim NielsenTVBookEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim NielsenTVBook As AdvantageFramework.DTO.Nielsen.NielsenTVBook = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVBookEntity = DbContext.NielsenTVBooks.Find(BookID)

                NielsenTVBook = New AdvantageFramework.DTO.Nielsen.NielsenTVBook(NielsenTVBookEntity)

            End Using

            Return NielsenTVBook

        End Function

        <HttpGet>
        <Route("api/NielsenTVBook/GetBookRowCount")>
        Public Function [GetBookRowCount](BookID As Integer) As Int64

            Dim NielsenTVBookRowCount As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVBookRowCount = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_tv_rowcount]({0})", BookID)).First

            End Using

            Return NielsenTVBookRowCount

        End Function

        <HttpGet>
        <Route("api/NielsenTVBook/GetByClientCode")>
        Public Function [GetByClientCode](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook)

            Dim ClientNielsenTVBooks As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenTVBooks = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook)(String.Format("exec [advsp_nielsen_spot_tv_get_client_books] '{0}'", ClientCode)).ToList
                                        Where Entity.ReportingService = "1" AndAlso
                                              Entity.Exclusion = "" AndAlso
                                              Entity.Ethnicity = ""
                                        Select Entity).ToList

            End Using

            Return ClientNielsenTVBooks

        End Function

        ''this is for 6.70.05.06+ so that clients can also get Impact data, etc.
        <HttpGet>
        <Route("api/NielsenTVBook/GetByClientCodev2")>
        Public Function [GetByClientCodev2](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook)

            Dim ClientNielsenTVBooks As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenTVBooks = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVBook)(String.Format("exec [advsp_nielsen_spot_tv_get_client_books] '{0}'", ClientCode)).ToList

            End Using

            Return ClientNielsenTVBooks

        End Function

    End Class

End Namespace