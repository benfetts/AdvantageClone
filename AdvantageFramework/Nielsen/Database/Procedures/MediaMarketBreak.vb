Namespace Nielsen.Database.Procedures.MediaMarketBreak

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

        Public Function LoadByBroadcastTypeIDAndRatingsServiceID(DbContext As Nielsen.Database.DbContext,
                                                                 BroadcastTypeID As AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID,
                                                                 RatingsServiceID As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.MediaMarketBreak)

            LoadByBroadcastTypeIDAndRatingsServiceID = From MediaMarketBreak In DbContext.GetQuery(Of Nielsen.Database.Entities.MediaMarketBreak)
                                                       Where MediaMarketBreak.BroadcastTypeID = BroadcastTypeID AndAlso
                                                             MediaMarketBreak.RatingsServiceID = RatingsServiceID
                                                       Select MediaMarketBreak

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.MediaMarketBreak)

            Load = From MediaMarketBreak In DbContext.GetQuery(Of Nielsen.Database.Entities.MediaMarketBreak)
                   Select MediaMarketBreak

        End Function

#End Region

    End Module

End Namespace
