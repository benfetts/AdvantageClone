Namespace Database.Procedures.MediaBroadcastWorksheetSecondaryDemo

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

		Public Function LoadByMediaBroadcastWorksheetSecondaryDemoID(DbContext As Database.DbContext, MediaBroadcastWorksheetSecondaryDemoID As Integer) As Database.Entities.MediaBroadcastWorksheetSecondaryDemo

			LoadByMediaBroadcastWorksheetSecondaryDemoID = (From MediaBroadcastWorksheetSecondaryDemo In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)
															Where MediaBroadcastWorksheetSecondaryDemo.ID = MediaBroadcastWorksheetSecondaryDemoID
															Select MediaBroadcastWorksheetSecondaryDemo).SingleOrDefault

		End Function
		Public Function LoadByMediaBroadcastWorksheetID(DbContext As Database.DbContext, MediaBroadcastWorksheetID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)

			LoadByMediaBroadcastWorksheetID = From MediaBroadcastWorksheetSecondaryDemo In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)
											  Where MediaBroadcastWorksheetSecondaryDemo.MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
											  Select MediaBroadcastWorksheetSecondaryDemo

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)

			Load = From MediaBroadcastWorksheetSecondaryDemo In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetSecondaryDemo)
				   Select MediaBroadcastWorksheetSecondaryDemo

		End Function

#End Region

	End Module

End Namespace
