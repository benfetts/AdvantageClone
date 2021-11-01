Namespace Database.Procedures.NielsenTVBook

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

        Public Function LoadByMarketCode(DbContext As Database.DbContext, MarketCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVBook)

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

            If Market IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Market.NielsenTVCode) Then

                LoadByMarketCode = From NielsenTVBook In DbContext.GetQuery(Of Database.Entities.NielsenTVBook)
                                   Where NielsenTVBook.NielsenMarketNumber = CInt(Market.NielsenTVCode)
                                   Select NielsenTVBook

            Else

                LoadByMarketCode = Nothing

            End If

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVBook)

            Load = From NielsenTVBook In DbContext.GetQuery(Of Database.Entities.NielsenTVBook)
                   Select NielsenTVBook

        End Function

#End Region

    End Module

End Namespace
