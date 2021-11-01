Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheetID As Integer
		Public Property IsNewRow As Boolean
		Public Property SaveEnabled As Boolean
		Public Property DeleteEnabled As Boolean
		Public Property CancelEnabled As Boolean
		Public Property Books_AddEnabled As Boolean
		Public Property Books_CopyToEnabled As Boolean

		Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
			Get
				HasASelectedWorksheetMarket = (Me.SelectedWorksheetMarket IsNot Nothing)
			End Get
		End Property
		Public ReadOnly Property MediaPlan_LoadMarketsEnabled As Boolean
			Get
				MediaPlan_LoadMarketsEnabled = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.MediaPlanID.GetValueOrDefault(0) > 0)
			End Get
		End Property
        Public ReadOnly Property HasPrimaryDemographic As Boolean
            Get
                HasPrimaryDemographic = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) > 0)
            End Get
        End Property
        Public ReadOnly Property IsCanadianWorksheet As Boolean
            Get
                IsCanadianWorksheet = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.IsCanadianWorksheet)
            End Get
        End Property
        Public ReadOnly Property DoesWorksheetAllowSubmarkets As Boolean
            Get
                DoesWorksheetAllowSubmarkets = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.DoesWorksheetAllowSubmarkets)
            End Get
        End Property
        Public ReadOnly Property BookTooltip As String
            Get

                If Me.HasPrimaryDemographic Then

                    BookTooltip = String.Empty

                Else

                    BookTooltip = "Primary Demographic must be assigned to worksheet in order to pull Nielsen ratings."

                End If

            End Get
        End Property

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
        Public Property WorksheetSecondaryDemos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Market)
		Public Property BuyerEmployees As Generic.List(Of AdvantageFramework.DTO.Media.BuyerEmployee)
		Public Property NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
		Public Property NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
		Public Property WorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
		Public Property SelectedWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket
		Public Property SelectedNielsenRadioMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioMarket
		Public Property NielsenRadioMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioMarket)

		Public Property HasMarketsModified As Boolean
        Public Property ShowWarningForChangingNielsenData As Boolean
        Public Property HasDataBeenEnteredInAnyMarketSchedules As Boolean

#End Region

#Region " Methods "

        Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.IsNewRow = False
			Me.SaveEnabled = False
			Me.DeleteEnabled = False
			Me.CancelEnabled = False
			Me.Books_AddEnabled = False
			Me.Books_CopyToEnabled = False

            Me.Worksheet = Nothing
            Me.WorksheetSecondaryDemos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Market)
			Me.BuyerEmployees = New Generic.List(Of AdvantageFramework.DTO.Media.BuyerEmployee)
			Me.NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
			Me.NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
			Me.WorksheetMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
			Me.SelectedWorksheetMarket = Nothing
			Me.SelectedNielsenRadioMarket = Nothing
			Me.NielsenRadioMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioMarket)

			Me.HasMarketsModified = False
			Me.ShowWarningForChangingNielsenData = True
            Me.HasDataBeenEnteredInAnyMarketSchedules = False

        End Sub

#End Region

	End Class

End Namespace
