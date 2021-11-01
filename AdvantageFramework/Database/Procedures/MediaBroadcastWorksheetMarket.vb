Namespace Database.Procedures.MediaBroadcastWorksheetMarket

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

		Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As Database.Entities.MediaBroadcastWorksheetMarket

			LoadByMediaBroadcastWorksheetMarketID = (From MediaBroadcastWorksheetMarket In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarket)
													 Where MediaBroadcastWorksheetMarket.ID = MediaBroadcastWorksheetMarketID
													 Select MediaBroadcastWorksheetMarket).SingleOrDefault

		End Function
		Public Function LoadByMediaBroadcastWorksheetID(DbContext As Database.DbContext, MediaBroadcastWorksheetID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarket)

			LoadByMediaBroadcastWorksheetID = From MediaBroadcastWorksheetMarket In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarket)
											  Where MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
											  Select MediaBroadcastWorksheetMarket

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarket)

			Load = From MediaBroadcastWorksheetMarket In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarket)
				   Select MediaBroadcastWorksheetMarket

		End Function

#End Region

	End Module

End Namespace
