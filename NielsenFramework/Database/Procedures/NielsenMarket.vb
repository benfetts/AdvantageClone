Namespace Database.Procedures.NielsenMarket

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

        Public Function LoadAllSpotTVMarkets(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenMarket)

            LoadAllSpotTVMarkets = From NielsenMarket In DbContext.GetQuery(Of Database.Entities.NielsenMarket)
                                   Where NielsenMarket.NielsenTVCode IsNot Nothing AndAlso
                                         NielsenMarket.NielsenTVCode <> ""
                                   Select NielsenMarket

        End Function
        Public Function LoadAllSpotTVMarketsExcludingMarketNumbers(DbContext As Database.NielsenDbContext, MarketNumbers As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenMarket)

            LoadAllSpotTVMarketsExcludingMarketNumbers = From NielsenMarket In DbContext.GetQuery(Of Database.Entities.NielsenMarket)
                                                         Where NielsenMarket.NielsenTVCode IsNot Nothing AndAlso
                                                               NielsenMarket.NielsenTVCode <> "" AndAlso
                                                               MarketNumbers.Contains(CInt(NielsenMarket.NielsenTVCode)) = False
                                                         Select NielsenMarket

        End Function
        Public Function Load(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenMarket)

            Load = From NielsenMarket In DbContext.GetQuery(Of Database.Entities.NielsenMarket)
                   Select NielsenMarket

        End Function

#End Region

    End Module

End Namespace
