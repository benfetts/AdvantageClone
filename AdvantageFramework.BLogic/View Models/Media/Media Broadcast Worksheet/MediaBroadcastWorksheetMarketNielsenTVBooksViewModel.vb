Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketNielsenTVBooksViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheetID As Integer
		Public Property MediaBroadcastWorksheetMarketID As Integer

		Public ReadOnly Property AddEnabled As Boolean
			Get
				AddEnabled = (Me.HasASelectedNielsenTVBook AndAlso Me.SelectedNielsenTVBooks.Any(Function(NTVB) NTVB.Selected = False))
			End Get
		End Property
		Public ReadOnly Property DeleteEnabled As Boolean
			Get
				DeleteEnabled = (Me.HasASelectedNielsenTVBook AndAlso Me.SelectedNielsenTVBooks.Any(Function(NTVB) NTVB.Selected = True))
			End Get
		End Property

		Public ReadOnly Property HasASelectedNielsenTVBook As Boolean
			Get
				HasASelectedNielsenTVBook = (Me.SelectedNielsenTVBooks IsNot Nothing AndAlso Me.SelectedNielsenTVBooks.Count > 0)
			End Get
		End Property

		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
		Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
		Public Property NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
		Public Property WorksheetNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)
		Public Property SelectedNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0

			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

			Me.NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
			Me.WorksheetNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)
			Me.SelectedNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook)

		End Sub

#End Region

	End Class

End Namespace
