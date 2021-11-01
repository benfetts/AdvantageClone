Namespace Database.Procedures.MediaBroadcastWorksheet

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

        Public Function LoadByMediaBroadcastWorksheetID(DbContext As Database.DbContext, MediaBroadcastWorksheetID As Integer) As Database.Entities.MediaBroadcastWorksheet

            LoadByMediaBroadcastWorksheetID = (From MediaBroadcastWorksheet In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheet).Include("PrimaryMediaDemographic")
                                               Where MediaBroadcastWorksheet.ID = MediaBroadcastWorksheetID
                                               Select MediaBroadcastWorksheet).SingleOrDefault

        End Function
        Public Function LoadAllActive(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheet)

            LoadAllActive = From MediaBroadcastWorksheet In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheet)
                            Where MediaBroadcastWorksheet.IsInactive = False
                            Select MediaBroadcastWorksheet

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheet)

			Load = From MediaBroadcastWorksheet In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheet)
				   Select MediaBroadcastWorksheet

		End Function

#End Region

	End Module

End Namespace
