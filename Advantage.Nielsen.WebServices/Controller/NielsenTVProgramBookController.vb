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

    Public Class NielsenTVProgramBookController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenTVProgramBook/GetByBookID")>
        Public Function [GetByBookID](BookID As Integer) As AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook

            Dim NielsenTVProgramBookEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBook = Nothing
            Dim NielsenTVProgramBook As AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVProgramBookEntity = DbContext.NielsenTVProgramBooks.Find(BookID)

                NielsenTVProgramBook = New AdvantageFramework.DTO.Nielsen.NielsenTVProgramBook(NielsenTVProgramBookEntity)

            End Using

            Return NielsenTVProgramBook

        End Function

        <HttpGet>
        <Route("api/NielsenTVProgramBook/GetBookRowCount")>
        Public Function [GetBookRowCount](BookID As Integer) As Int64

            Dim NielsenTVBookRowCount As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVBookRowCount = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT CAST(COALESCE(COUNT(1), 0) as bigint) FROM dbo.NIELSEN_TV_PROGRAM WHERE NIELSEN_TV_PROGRAM_BOOK_ID = {0}", BookID)).First

            End Using

            Return NielsenTVBookRowCount

        End Function

        <HttpGet>
        <Route("api/NielsenTVProgramBook/GetByClientCode")>
        Public Function [GetByClientCode](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook)

            Dim ClientNielsenTVProgramBooks As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenTVProgramBooks = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook)(String.Format("exec [advsp_nielsen_spot_tv_get_client_program_books] '{0}'", ClientCode)).ToList
                                               Where Entity.ReportingService = "1" AndAlso
                                                     Entity.Exclusion = "" AndAlso
                                                     Entity.Ethnicity = ""
                                               Select Entity).ToList

            End Using

            Return ClientNielsenTVProgramBooks

        End Function

        ''this is for 6.70.05.06+ so that clients can also get Impact data, etc.
        <HttpGet>
        <Route("api/NielsenTVProgramBook/GetByClientCodev2")>
        Public Function [GetByClientCodev2](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook)

            Dim ClientNielsenTVProgramBooks As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenTVProgramBooks = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVProgramBook)(String.Format("exec [advsp_nielsen_spot_tv_get_client_program_books] '{0}'", ClientCode)).ToList

            End Using

            Return ClientNielsenTVProgramBooks

        End Function

    End Class

End Namespace