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

    Public Class NielsenRadioMarketController
        Inherits ApiController

        <HttpGet>
        <Route("api/NielsenRadioMarket/Get")>
        <Route("api/NielsenRadioMarket")>
        Public Function [Get](MarketNumber As Integer) As AdvantageFramework.DTO.Nielsen.NielsenRadioMarket

            Dim NielsenRadioMarketEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing
            Dim NielsenRadioMarket As AdvantageFramework.DTO.Nielsen.NielsenRadioMarket = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioMarketEntity = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Load(DbContext)
                                            Where Entity.Number = MarketNumber
                                            Select Entity).FirstOrDefault

                NielsenRadioMarket = New AdvantageFramework.DTO.Nielsen.NielsenRadioMarket(NielsenRadioMarketEntity)

            End Using

            Return NielsenRadioMarket

        End Function

        <HttpGet>
        <Route("api/NielsenRadioMarket/GetByMarketNumberSource")>
        Public Function [Get](MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As AdvantageFramework.DTO.Nielsen.NielsenRadioMarket

            Dim NielsenRadioMarketEntity As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket = Nothing
            Dim NielsenRadioMarket As AdvantageFramework.DTO.Nielsen.NielsenRadioMarket = Nothing

            Using DbContext As New AdvantageFramework.Nielsen.Database.DbContext(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString, "SYSADM")

                NielsenRadioMarketEntity = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioMarket.Load(DbContext)
                                            Where Entity.Number = MarketNumber AndAlso
                                                  Entity.Source = Source
                                            Select Entity).SingleOrDefault

                NielsenRadioMarket = New AdvantageFramework.DTO.Nielsen.NielsenRadioMarket(NielsenRadioMarketEntity)

            End Using

            Return NielsenRadioMarket

        End Function

    End Class

End Namespace