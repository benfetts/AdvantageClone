Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketOrderDataViewModel

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
		Public Property WorksheetMarketDetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)
		Public Property RevisionWorksheetMarketDetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)
		Public Property SelectedWorksheetMarketDetail As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail
		Public Property SelectedWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate)

		Public Property SelectedWorksheetMarketRevisionNumbers As Generic.List(Of Integer)
		Public Property SelectedWorksheetMarketRevisionNumber As Integer

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0

			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing
			Me.WorksheetMarketDetails = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)
			Me.RevisionWorksheetMarketDetails = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)
			Me.SelectedWorksheetMarketDetail = Nothing
			Me.SelectedWorksheetMarketDetailDates = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDate)

			Me.SelectedWorksheetMarketRevisionNumbers = New Generic.List(Of Integer)
			Me.SelectedWorksheetMarketRevisionNumber = 0

		End Sub

#End Region

	End Class

End Namespace
