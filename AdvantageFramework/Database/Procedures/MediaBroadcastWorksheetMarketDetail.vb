Namespace Database.Procedures.MediaBroadcastWorksheetMarketDetail

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

        Public Function LoadByMediaBroadcastWorksheetMarketDetailIDs(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)

            LoadByMediaBroadcastWorksheetMarketDetailIDs = From MediaBroadcastWorksheetMarketDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)
                                                           Where MediaBroadcastWorksheetMarketDetailIDs.Contains(MediaBroadcastWorksheetMarketDetail.ID)
                                                           Select MediaBroadcastWorksheetMarketDetail

        End Function
        Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)

			LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)
													Where MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
													Select MediaBroadcastWorksheetMarketDetail

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)

			Load = From MediaBroadcastWorksheetMarketDetail In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)
				   Select MediaBroadcastWorksheetMarketDetail

		End Function

#End Region

	End Module

End Namespace
