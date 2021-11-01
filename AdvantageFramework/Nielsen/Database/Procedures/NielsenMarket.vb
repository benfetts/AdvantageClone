Namespace Nielsen.Database.Procedures.NielsenMarket

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

        Public Function LoadByCode(DbContext As Nielsen.Database.DbContext, Code As String) As Nielsen.Database.Entities.NielsenMarket

            LoadByCode = (From NielsenMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenMarket)
                          Where NielsenMarket.Code = Code
                          Select NielsenMarket).SingleOrDefault

        End Function
        Public Function LoadByNielsenTVCode(DbContext As Nielsen.Database.DbContext, NielsenTVCode As String) As Nielsen.Database.Entities.NielsenMarket

            LoadByNielsenTVCode = (From NielsenMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenMarket)
                                   Where NielsenMarket.NielsenTVCode = NielsenTVCode
                                   Select NielsenMarket).SingleOrDefault

        End Function
        Public Function LoadTVMarkets(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenMarket)

            LoadTVMarkets = From NielsenMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenMarket)
                            Where NielsenMarket.NielsenTVCode IsNot Nothing AndAlso
                                  NielsenMarket.NielsenTVCode <> ""
                            Select NielsenMarket

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenMarket)

            Load = From NielsenMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenMarket)
                   Select NielsenMarket

        End Function

#End Region

    End Module

End Namespace
