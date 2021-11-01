Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public ReadOnly Property AddVisible As Boolean
			Get
				AddVisible = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.ID = 0)
			End Get
		End Property
		Public ReadOnly Property UpdateVisible As Boolean
			Get
				UpdateVisible = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.ID > 0)
			End Get
		End Property
		Public Property CancelEnabled As Boolean
		Public Property DefaultToLatestSharebookEnabled As Boolean
		Public Property ProrateSecondaryDemosToPrimaryEnabled As Boolean

		Public Property MediaTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property Clients As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property Divisions As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property Products As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property SalesClasses As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property Campaigns As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property MediaPlans As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property DateTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property CalendarTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property RatingsServiceList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property Countries As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
		Public Property WorksheetSecondaryDemos As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
		Public Property SelectedWorksheetSecondaryDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo


        Public ReadOnly Property SecondaryDemoEnabled As Boolean
            Get
                SecondaryDemoEnabled = (Me.Worksheet IsNot Nothing AndAlso Me.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) > 0)
            End Get
        End Property
        Public Property SecondaryDemo_IsNewItemRow As Boolean
		Public Property SecondaryDemo_DeleteEnabled As Boolean
		Public Property SecondaryDemo_CancelEnabled As Boolean

		Public ReadOnly Property HasASelectedWorksheetSecondaryDemo As Boolean
			Get
				HasASelectedWorksheetSecondaryDemo = (Me.SelectedWorksheetSecondaryDemo IsNot Nothing)
			End Get
		End Property

		Public Property MediaDemographics As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

		Public Property HasRevisionBeenCreatedInAnyMarketSchedules As Boolean
		Public Property HasDataBeenEnteredInAnyMarketSchedules As Boolean
		Public Property ClearGoalGRPAndMarketScheduleSpotsData As Boolean
		Public Property HasOrdersBeenCreated As Boolean
		Public Property HasPrimaryDemographicChanged As Boolean
        Public Property DateRangeWarningBypassed As Boolean
        Public Property MediaRequireCampaign As Boolean

        Public Property UserHasAccessToMatchingTab As Boolean
        Public Property MediaBroadcastWorksheetSpotMatchingSettings As Generic.List(Of AdvantageFramework.DTO.Media.SpotMatchingSetting)

#End Region

#Region " Methods "

        Public Sub New()

			Me.CancelEnabled = True

			Me.MediaTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.Clients = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.Divisions = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.Products = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.SalesClasses = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.Campaigns = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.MediaPlans = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.DateTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
			Me.CalendarTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.Countries = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            Me.Worksheet = Nothing
			Me.WorksheetSecondaryDemos = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)
			Me.SelectedWorksheetSecondaryDemo = Nothing

			Me.MediaDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

			Me.SecondaryDemo_IsNewItemRow = False
			Me.SecondaryDemo_DeleteEnabled = False
			Me.SecondaryDemo_CancelEnabled = False

			Me.HasRevisionBeenCreatedInAnyMarketSchedules = False
			Me.HasDataBeenEnteredInAnyMarketSchedules = False
			Me.ClearGoalGRPAndMarketScheduleSpotsData = False
			Me.HasOrdersBeenCreated = False
			Me.HasPrimaryDemographicChanged = False
            Me.DateRangeWarningBypassed = False
            Me.MediaRequireCampaign = False

            Me.DefaultToLatestSharebookEnabled = False
			Me.ProrateSecondaryDemosToPrimaryEnabled = False

            Me.UserHasAccessToMatchingTab = False
            Me.MediaBroadcastWorksheetSpotMatchingSettings = New List(Of AdvantageFramework.DTO.Media.SpotMatchingSetting)

        End Sub

#End Region

	End Class

End Namespace
