Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketNielsenTVBooksCopyToViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheetID As Integer
		Public Property MediaBroadcastWorksheetMarketID As Integer

		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
		Public Property CopyFromWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
		Public Property CopyFromWorksheetNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)
		Public Property CopyToMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo)
		Public Property NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
		Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Market)

		Public ReadOnly Property HasAtleastOneMarketSelected As Boolean
			Get
				HasAtleastOneMarketSelected = (Me.CopyToMarkets IsNot Nothing AndAlso Me.CopyToMarkets.Any(Function(Entity) Entity.Selected = True))
			End Get
		End Property

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0

			Me.Worksheet = Nothing
			Me.CopyFromWorksheetMarket = Nothing

			Me.CopyFromWorksheetNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)
			Me.CopyToMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo)
			Me.NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
			Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Market)

		End Sub

#End Region

	End Class

End Namespace
