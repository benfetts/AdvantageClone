Namespace Database.Procedures.MediaBroadcastWorksheetMarketGoalDate

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

		Public Function LoadByMediaBroadcastWorksheetMarketGoalID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketGoalID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)

			LoadByMediaBroadcastWorksheetMarketGoalID = From MediaBroadcastWorksheetMarketGoalDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)
														Where MediaBroadcastWorksheetMarketGoalDate.MediaBroadcastWorksheetMarketGoalID = MediaBroadcastWorksheetMarketGoalID
														Select MediaBroadcastWorksheetMarketGoalDate

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)

			Load = From MediaBroadcastWorksheetMarketGoalDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)
				   Select MediaBroadcastWorksheetMarketGoalDate

		End Function

#End Region

	End Module

End Namespace
