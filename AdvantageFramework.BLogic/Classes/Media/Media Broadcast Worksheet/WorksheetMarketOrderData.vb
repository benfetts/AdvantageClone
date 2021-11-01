Namespace Classes.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketOrderData

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MediaBroadcastWorksheet
			MediaBroadcastWorksheetMarket
			MediaBroadcastWorksheetMarketDetail
			WorksheetMarketOrderDate
			MediaBroadcastWorksheetMarketDetailDates
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet
		Public Property MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket
		Public Property MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail
		Public Property WorksheetMarketOrderDate As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDate

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheet = Nothing
			Me.MediaBroadcastWorksheetMarket = Nothing
			Me.MediaBroadcastWorksheetMarketDetail = Nothing
			Me.WorksheetMarketOrderDate = Nothing

		End Sub

#End Region

	End Class

End Namespace
