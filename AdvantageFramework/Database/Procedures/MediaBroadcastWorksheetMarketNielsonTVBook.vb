Namespace Database.Procedures.MediaBroadcastWorksheetMarketNielsenTVBook

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

		Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketNielsenTVBook In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)
													Where MediaBroadcastWorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
													Select MediaBroadcastWorksheetMarketNielsenTVBook

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			Load = From MediaBroadcastWorksheetMarketNielsenTVBook In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)
				   Select MediaBroadcastWorksheetMarketNielsenTVBook

		End Function

#End Region

	End Module

End Namespace
