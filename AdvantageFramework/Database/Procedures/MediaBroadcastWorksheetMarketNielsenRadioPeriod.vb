Namespace Database.Procedures.MediaBroadcastWorksheetMarketNielsenRadioPeriod

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

		Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketNielsenRadioPeriod In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)
													Where MediaBroadcastWorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
													Select MediaBroadcastWorksheetMarketNielsenRadioPeriod

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			Load = From MediaBroadcastWorksheetMarketNielsenRadioPeriod In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)
				   Select MediaBroadcastWorksheetMarketNielsenRadioPeriod

		End Function

#End Region

	End Module

End Namespace
