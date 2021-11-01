Namespace Classes.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketOrderDateData

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			[Date]
			Month
			Year
			Week
			MediaBroadcastWorksheetMarketDetailDates
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property [Date] As Date
		Public Property Month As Integer
		Public Property Year As Integer
		Public Property Week As Integer
		Public Property MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

#End Region

#Region " Methods "

		Public Sub New()

			Me.[Date] = Date.MinValue
			Me.Month = Date.MinValue.Month
			Me.Year = Date.MinValue.Year
			Me.Week = 1
			Me.MediaBroadcastWorksheetMarketDetailDates = New Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

		End Sub

#End Region

	End Class

End Namespace
