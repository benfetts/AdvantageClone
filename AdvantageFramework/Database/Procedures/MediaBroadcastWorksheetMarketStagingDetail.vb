Namespace Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaBroadcastWorksheetMarketStagingDetail

            LoadByID = (From MediaBroadcastWorksheetMarketStagingDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)
                        Where MediaBroadcastWorksheetMarketStagingDetail.ID = ID
                        Select MediaBroadcastWorksheetMarketStagingDetail).SingleOrDefault

        End Function
        Public Function LoadByMediaBroadcastWorksheetMarketDetailID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)

            LoadByMediaBroadcastWorksheetMarketDetailID = From MediaBroadcastWorksheetMarketStagingDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)
                                                          Where MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID
                                                          Select MediaBroadcastWorksheetMarketStagingDetail

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)

            Load = From MediaBroadcastWorksheetMarketStagingDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)
                   Select MediaBroadcastWorksheetMarketStagingDetail

        End Function

#End Region

    End Module

End Namespace
