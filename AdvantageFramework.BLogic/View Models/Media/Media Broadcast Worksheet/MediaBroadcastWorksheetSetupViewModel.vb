Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property AddEnabled As Boolean
		Public Property RefreshEnabled As Boolean
		Public ReadOnly Property UpdateEnabled As Boolean
			Get
				UpdateEnabled = Me.HasASelectedWorksheet
			End Get
		End Property
		Public ReadOnly Property DeleteEnabled As Boolean
            Get

                Dim CanDelete As Boolean = False

                If Me.HasASelectedWorksheet Then

                    If Me.SelectedWorksheet.IsCanadianWorksheet Then

                        If Me.SelectedWorksheetMarkets.Count = 1 AndAlso
                                Me.SelectedWorksheetMarket.HasData = False Then

                            CanDelete = True

                        ElseIf Me.SelectedWorksheetMarkets.Count = 0 Then

                            CanDelete = True

                        End If

                    Else

                        CanDelete = (Me.SelectedWorksheetMarkets.Count = 0)

                    End If

                End If

                DeleteEnabled = CanDelete

            End Get
        End Property
		Public ReadOnly Property CopyEnabled As Boolean
			Get
                CopyEnabled = Me.HasASelectedWorksheet
            End Get
		End Property

        Public ReadOnly Property ManageMarketsEnabled As Boolean
            Get
                ManageMarketsEnabled = Me.HasASelectedWorksheet
            End Get
        End Property
        Public ReadOnly Property ViewMarketGoalsEnabled As Boolean
			Get
				ViewMarketGoalsEnabled = Me.HasASelectedWorksheetMarket
			End Get
		End Property
		Public ReadOnly Property ViewMarketDetailsEnabled As Boolean
			Get
				ViewMarketDetailsEnabled = Me.HasASelectedWorksheetMarket
			End Get
		End Property

		Public Property DashboardEditEnabled As Boolean

		Public Property Worksheets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)
		Public Property SelectedWorksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet

		Public Property SelectedWorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
		Public Property SelectedWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket

		Public ReadOnly Property HasASelectedWorksheet As Boolean
			Get
				HasASelectedWorksheet = (Me.SelectedWorksheet IsNot Nothing AndAlso Me.Worksheets.Count > 0)
			End Get
		End Property
        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.SelectedWorksheetMarket IsNot Nothing AndAlso Me.SelectedWorksheetMarkets.Count > 0)
            End Get
        End Property
        Public ReadOnly Property IsCanadianWorksheet As Boolean
            Get
                IsCanadianWorksheet = (Me.SelectedWorksheet IsNot Nothing AndAlso Me.SelectedWorksheet.IsCanadianWorksheet)
            End Get
        End Property

        Public Property WorksheetPrintOptions As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetPrintOptions

		Public Property Dashboard As AdvantageFramework.DTO.Dashboard
		Public Property DashboardDataSource As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SetupFormDashboardDataSource)

		Public Property IsNielsenSetup As Boolean

        Public Property WorksheetGridLayout As AdvantageFramework.DTO.GridAdvantage
        'Public Property WorksheetScheduleGridLayout As AdvantageFramework.DTO.GridAdvantage
        Public Property NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property ComscoreTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

        Public Property WorksheetIDsWithMissingTrafficInstructions As IEnumerable(Of Integer)
        Public Property WorksheetMarketIDsWithMissingTrafficInstructions As IEnumerable(Of Integer)
        Public Property UserHasAccessToMediaTraffic As Boolean

        Public Property ShowPendingMakegoods As Boolean
        Public Property WorksheetMarketPendingMakegoods As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketPendingMakegood)
        Public Property FilterBeforeShowingPendingMakegoods As String

#End Region

#Region " Methods "

        Public Sub New()

			Me.AddEnabled = True
			Me.RefreshEnabled = True
			Me.DashboardEditEnabled = True

			Me.Worksheets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet)
			Me.SelectedWorksheet = Nothing

			Me.SelectedWorksheetMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
			Me.SelectedWorksheetMarket = Nothing

			Me.WorksheetPrintOptions = Nothing

			Me.Dashboard = Nothing
			Me.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.SetupFormDashboardDataSource)

			Me.IsNielsenSetup = False

            Me.WorksheetGridLayout = Nothing
            Me.NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            Me.ComscoreTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            Me.NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)
            'Me.WorksheetScheduleGridLayout = Nothing

            Me.WorksheetIDsWithMissingTrafficInstructions = Nothing
            Me.WorksheetMarketIDsWithMissingTrafficInstructions = Nothing
            Me.UserHasAccessToMediaTraffic = False

            Me.ShowPendingMakegoods = False
            Me.WorksheetMarketPendingMakegoods = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketPendingMakegood)
            Me.FilterBeforeShowingPendingMakegoods = String.Empty

        End Sub

#End Region

	End Class

End Namespace
