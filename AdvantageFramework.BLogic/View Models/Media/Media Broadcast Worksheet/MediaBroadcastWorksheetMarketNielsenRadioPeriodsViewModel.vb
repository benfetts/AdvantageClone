Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketNielsenRadioPeriodsViewModel

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
				AddEnabled = (Me.HasASelectedNielsenRadioPeriod AndAlso Me.SelectedNielsenRadioPeriods.Any(Function(NTVB) NTVB.Selected = False))
			End Get
		End Property
		Public ReadOnly Property DeleteEnabled As Boolean
			Get
				DeleteEnabled = (Me.HasASelectedNielsenRadioPeriod AndAlso Me.SelectedNielsenRadioPeriods.Any(Function(NTVB) NTVB.Selected = True))
			End Get
		End Property

		Public ReadOnly Property HasASelectedNielsenRadioPeriod As Boolean
			Get
				HasASelectedNielsenRadioPeriod = (Me.SelectedNielsenRadioPeriods IsNot Nothing AndAlso Me.SelectedNielsenRadioPeriods.Count > 0)
			End Get
		End Property

		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
		Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
		Public Property NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
		Public Property WorksheetNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioPeriod)
		Public Property SelectedNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioPeriod)

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0

			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

			Me.NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
			Me.WorksheetNielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioPeriod)
			Me.SelectedNielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioPeriod)

		End Sub

#End Region

	End Class

End Namespace
