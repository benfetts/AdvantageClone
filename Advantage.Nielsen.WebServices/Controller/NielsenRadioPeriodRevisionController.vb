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

    Public Class NielsenRadioPeriodRevisionController
        Inherits ApiController

        Public Function [Get]() As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision)

            Dim Query As IQueryable(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriodRevision) = Nothing
            Dim Results As IEnumerable(Of AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision) = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                Query = DbContext.GetQuery(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriodRevision)

                Results = Query.ToList().[Select](Function(s) New AdvantageFramework.DTO.Nielsen.NielsenRadioPeriodRevision(s))

            End Using

            Return Results

        End Function

    End Class

End Namespace