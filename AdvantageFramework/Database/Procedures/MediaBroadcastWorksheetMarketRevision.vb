Namespace Database.Procedures.MediaBroadcastWorksheetMarketRevision

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

		Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)

			LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketRevision In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)
													Where MediaBroadcastWorksheetMarketRevision.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
													Select MediaBroadcastWorksheetMarketRevision

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)

			Load = From MediaBroadcastWorksheetMarketRevision In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)
				   Select MediaBroadcastWorksheetMarketRevision

		End Function

#End Region

	End Module

End Namespace
