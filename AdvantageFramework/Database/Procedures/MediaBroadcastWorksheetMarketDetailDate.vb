Namespace Database.Procedures.MediaBroadcastWorksheetMarketDetailDate

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

        Public Function LoadByMediaBroadcastWorksheetMarketDetailID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketDetailID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

            LoadByMediaBroadcastWorksheetMarketDetailID = From MediaBroadcastWorksheetMarketDetailDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)
                                                          Where MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID
                                                          Select MediaBroadcastWorksheetMarketDetailDate

        End Function
        Public Function LoadByMediaBroadcastWorksheetMarketID(DbContext As Database.DbContext, MediaBroadcastWorksheetMarketID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

            LoadByMediaBroadcastWorksheetMarketID = From MediaBroadcastWorksheetMarketDetailDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate).Include("MediaBroadcastWorksheetMarketDetail")
                                                    Where MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                                    Select MediaBroadcastWorksheetMarketDetailDate

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

			Load = From MediaBroadcastWorksheetMarketDetailDate In DbContext.GetQuery(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)
				   Select MediaBroadcastWorksheetMarketDetailDate

		End Function

#End Region

	End Module

End Namespace
