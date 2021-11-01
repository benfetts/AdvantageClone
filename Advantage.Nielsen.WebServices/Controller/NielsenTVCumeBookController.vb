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

    Public Class NielsenTVCumeBookController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenTVCumeBook/GetByBookID")>
        Public Function [GetByBookID](BookID As Integer) As AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook

            Dim NielsenTVCumeBookEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook = Nothing
            Dim NielsenTVCumeBook As AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVCumeBookEntity = DbContext.NielsenTVCumeBooks.Find(BookID)

                NielsenTVCumeBook = New AdvantageFramework.DTO.Nielsen.NielsenTVCumeBook(NielsenTVCumeBookEntity)

            End Using

            Return NielsenTVCumeBook

        End Function

        <HttpGet>
        <Route("api/NielsenTVCumeBook/GetBookRowCount")>
        Public Function [GetBookRowCount](BookID As Integer) As Int64

            Dim NielsenTVCumeBookRowCount As Int64 = 0

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenTVCumeBookRowCount = DbContext.Database.SqlQuery(Of Int64)(String.Format("SELECT dbo.[advfn_nielsen_spot_tv_cume_rowcount]({0})", BookID)).First

            End Using

            Return NielsenTVCumeBookRowCount

        End Function

        <HttpGet>
        <Route("api/NielsenTVCumeBook/GetByClientCode")>
        Public Function [GetByClientCode](ClientCode As String) As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook)

            Dim ClientNielsenTVCumeBooks As IEnumerable(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                ClientNielsenTVCumeBooks = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenTVCumeBook)(String.Format("exec [advsp_nielsen_spot_tv_cume_get_client_books] '{0}'", ClientCode)).ToList

            End Using

            Return ClientNielsenTVCumeBooks

        End Function

    End Class

End Namespace