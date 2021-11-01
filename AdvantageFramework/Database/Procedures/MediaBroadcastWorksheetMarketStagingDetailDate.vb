Namespace Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate

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

        Public Function LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketStagingDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)

            LoadByMediaBroadcastWorksheetMarketStagingDetailID = From MediaBroadcastWorksheetMarketStagingDetailDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)
                                                                 Where MediaBroadcastWorksheetMarketStagingDetailDate.MediaBroadcastWorksheetMarketStagingDetailID = MediaBroadcastWorksheetMarketStagingDetailID
                                                                 Select MediaBroadcastWorksheetMarketStagingDetailDate

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)

            Load = From MediaBroadcastWorksheetMarketStagingDetailDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)
                   Select MediaBroadcastWorksheetMarketStagingDetailDate

        End Function

#End Region

    End Module

End Namespace
