Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketGoalsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public ReadOnly Property CopyToAnotherMarketEnabled As Boolean
            Get
                CopyToAnotherMarketEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property
        Public ReadOnly Property CopyFromAnotherMarketEnabled As Boolean
            Get
                CopyFromAnotherMarketEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public Property AddEnabled As Boolean
		Public Property DeleteEnabled As Boolean
        Public Property CopyEnabled As Boolean
        Public Property EnterByPercentageEnabled As Boolean

        Public Property MediaBroadcastWorksheetID As Integer
		'Public Property MediaBroadcastWorksheetMarketID As Integer
		Public Property DemoName As String

		Public Property Dayparts As Generic.List(Of AdvantageFramework.DTO.Daypart)
		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
		Public Property WorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
		Public Property SelectedWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket

		Public Property DataTable As System.Data.DataTable

		Public Property HiatusDataTable As System.Data.DataTable
		Public Property CPPDataTable As System.Data.DataTable

		Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
			Get
				HasASelectedWorksheetMarket = (Me.SelectedWorksheetMarket IsNot Nothing AndAlso Me.WorksheetMarkets.Count > 0)
			End Get
		End Property

		Public Property GoalDates As Hashtable

		Public Property HasGoalsBeenModified As Boolean
		Public Property MediaPlan_LoadGoalsEnabled As Boolean
        Public Property TotalGRPs As Decimal
        Public Property TotalBudget As Decimal
        Public Property VarianceGRPs As Decimal
        Public Property VarianceBudget As Decimal

        Public Property EnterByPercentageChecked As Boolean
        Public Property HasBeenImportFromMediaPlan As Boolean

#End Region

#Region " Methods "

        Public Sub New()

			Me.SaveEnabled = False
			Me.CancelEnabled = False

			Me.AddEnabled = True
			Me.DeleteEnabled = False
            Me.CopyEnabled = False
            Me.EnterByPercentageEnabled = False

            Me.MediaBroadcastWorksheetID = 0
			'Me.MediaBroadcastWorksheetMarketID = 0
			Me.DemoName = String.Empty

			Me.Dayparts = New Generic.List(Of AdvantageFramework.DTO.Daypart)
			Me.Worksheet = Nothing
			Me.WorksheetMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
			Me.SelectedWorksheetMarket = Nothing
			Me.DataTable = New System.Data.DataTable
			Me.HiatusDataTable = New System.Data.DataTable
			Me.CPPDataTable = New System.Data.DataTable

			Me.GoalDates = New Hashtable

			Me.HasGoalsBeenModified = False
			Me.MediaPlan_LoadGoalsEnabled = False
            Me.TotalGRPs = 0
            Me.TotalBudget = 0

            Me.EnterByPercentageChecked = False
            Me.HasBeenImportFromMediaPlan = False

        End Sub

#End Region

	End Class

End Namespace
