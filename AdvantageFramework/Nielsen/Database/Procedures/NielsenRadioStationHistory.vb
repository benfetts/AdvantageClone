Namespace Nielsen.Database.Procedures.NielsenRadioStationHistory

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetMaxIDByMarketNumber(DbContext As Nielsen.Database.DbContext, MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As Integer

            Try

                GetMaxIDByMarketNumber = (From NielsenRadioStationHistory In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStationHistory)
                                          Where NielsenRadioStationHistory.NielsenRadioMarketNumber = MarketNumber AndAlso
                                                NielsenRadioStationHistory.Source = Source
                                          Select NielsenRadioStationHistory.ID).Max

            Catch ex As Exception
                GetMaxIDByMarketNumber = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioStationHistory)

            Load = From NielsenRadioStationHistory In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStationHistory)
                   Select NielsenRadioStationHistory

        End Function

#End Region

    End Module

End Namespace
