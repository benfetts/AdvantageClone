Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketManageVendorsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property MediaBroadcastWorksheetID As Integer
		Public Property MediaBroadcastWorksheetMarketID As Integer
		Public Property SelectedWorksheetMarketRevisionNumber As Integer

		Public ReadOnly Property AddEnabled As Boolean
			Get
				AddEnabled = (Me.HasASelectedWorksheetMarketDetailVendor AndAlso Me.SelectedWorksheetMarketDetailVendors.Any(Function(WMDV) WMDV.Selected = False))
			End Get
		End Property
		Public ReadOnly Property DeleteEnabled As Boolean
			Get
				DeleteEnabled = (Me.HasASelectedWorksheetMarketDetailVendor AndAlso Me.SelectedWorksheetMarketDetailVendors.Any(Function(WMDV) WMDV.Selected = True) AndAlso Me.SelectedWorksheetMarketDetailVendors.All(Function(WMDV) WMDV.HasOrders = False))
			End Get
		End Property

		Public ReadOnly Property HasASelectedWorksheetMarketDetailVendor As Boolean
			Get
				HasASelectedWorksheetMarketDetailVendor = (Me.SelectedWorksheetMarketDetailVendors IsNot Nothing AndAlso Me.SelectedWorksheetMarketDetailVendors.Count > 0)
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

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
		Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing
		Public Property WorksheetMarketDetailVendors As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)
        Public Property SelectedWorksheetMarketDetailVendors As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)
        Public Property HasVendorsBeenModified As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.SelectedWorksheetMarketRevisionNumber = 0

			Me.WorksheetMarketDetailVendors = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)
			Me.SelectedWorksheetMarketDetailVendors = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)
			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

			Me.HasVendorsBeenModified = False

		End Sub

#End Region

	End Class

End Namespace
