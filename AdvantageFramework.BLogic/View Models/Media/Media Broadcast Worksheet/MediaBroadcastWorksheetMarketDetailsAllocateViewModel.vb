Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketDetailsAllocateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheetID As Integer
		Public Property MediaBroadcastWorksheetMarketID As Integer
		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
		Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket

		Public Property WorksheetDates As Generic.List(Of Date) = Nothing

		Public Property StartDate As Date
		Public Property Spots As Integer

		Public Property EveryDate As Boolean
		Public Property EveryOtherDate As Boolean
		Public Property Every3rdDate As Boolean
		Public Property Every4thDate As Boolean

		Public Property IsBookend As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

			Me.WorksheetDates = New Generic.List(Of Date)

			Me.StartDate = Date.MinValue
			Me.Spots = 0

			Me.EveryDate = True
			Me.EveryOtherDate = False
			Me.Every3rdDate = False
			Me.Every4thDate = False

			Me.IsBookend = False

		End Sub

#End Region

	End Class

End Namespace
