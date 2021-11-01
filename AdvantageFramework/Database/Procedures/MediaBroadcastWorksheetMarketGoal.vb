Namespace Database.Procedures.MediaBroadcastWorksheetMarketGoal

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

		Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)

			LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketGoal In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)
													Where MediaBroadcastWorksheetMarketGoal.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
													Select MediaBroadcastWorksheetMarketGoal

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)

			Load = From MediaBroadcastWorksheetMarketGoal In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)
				   Select MediaBroadcastWorksheetMarketGoal

		End Function

#End Region

	End Module

End Namespace
