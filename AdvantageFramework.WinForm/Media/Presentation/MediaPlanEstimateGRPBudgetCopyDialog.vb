Namespace Media.Presentation

    Public Class MediaPlanEstimateGRPBudgetCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _Available As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget) = Nothing
        Protected _HasSpotLengths As Boolean = False
        Protected _Selected As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Selected As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)
            Get
                Selected = DataGridViewForm_SelectedMarkets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(Available As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget), HasSpotLengths As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Available = Available
            _HasSpotLengths = HasSpotLengths

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Available As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget), HasSpotLengths As Boolean,
                                              ByRef Selected As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanEstimateGRPBudgetCopyDialog As AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetCopyDialog = Nothing

            MediaPlanEstimateGRPBudgetCopyDialog = New AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetCopyDialog(Available, HasSpotLengths)

            ShowFormDialog = MediaPlanEstimateGRPBudgetCopyDialog.ShowDialog()

            Selected = MediaPlanEstimateGRPBudgetCopyDialog.Selected

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEstimateGRPBudgetCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim DistinctMarketSpotLengths As IEnumerable(Of String) = Nothing
            Dim MarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing

            MarketSpotLengths = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)

            If _HasSpotLengths Then

                DistinctMarketSpotLengths = (From Entity In _Available
                                             Select Entity.MarketCode & "|" & Entity.SpotLength.Value).Distinct.ToArray

                For Each DistinctMarketSpotLength In DistinctMarketSpotLengths

                    MarketSpotLengths.Add(New DTO.Media.MarketSpotLength(_Available.Where(Function(M) DistinctMarketSpotLength = M.MarketCode & "|" & M.SpotLength.Value).First))

                Next

                DataGridViewForm_AvailableMarkets.DataSource = MarketSpotLengths.ToList

                DataGridViewForm_SelectedMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)

            Else

                DistinctMarketSpotLengths = (From Entity In _Available
                                             Select Entity.MarketCode).Distinct.ToArray

                For Each DistinctMarketSpotLength In DistinctMarketSpotLengths

                    MarketSpotLengths.Add(New DTO.Media.MarketSpotLength(_Available.Where(Function(M) DistinctMarketSpotLength = M.MarketCode).First))

                Next

                DataGridViewForm_AvailableMarkets.DataSource = MarketSpotLengths.ToList

                DataGridViewForm_SelectedMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)

                If DataGridViewForm_AvailableMarkets.CurrentView.Columns(AdvantageFramework.DTO.Media.MarketSpotLength.Properties.SpotLength.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableMarkets.CurrentView.Columns(AdvantageFramework.DTO.Media.MarketSpotLength.Properties.SpotLength.ToString).Visible = False

                End If

                If DataGridViewForm_SelectedMarkets.CurrentView.Columns(AdvantageFramework.DTO.Media.MarketSpotLength.Properties.SpotLength.ToString) IsNot Nothing Then

                    DataGridViewForm_SelectedMarkets.CurrentView.Columns(AdvantageFramework.DTO.Media.MarketSpotLength.Properties.SpotLength.ToString).Visible = False

                End If

            End If

            DataGridViewForm_AvailableMarkets.CurrentView.BestFitColumns()
            DataGridViewForm_SelectedMarkets.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonRightSection_AddMarket_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddMarket.Click

            Dim MarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing
            Dim AvailableMarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing
            Dim SelectedMarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing

            MarketSpotLengths = DataGridViewForm_AvailableMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList

            AvailableMarketSpotLengths = DataGridViewForm_AvailableMarkets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList
            SelectedMarketSpotLengths = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList

            For Each MarketSpotLength In MarketSpotLengths

                SelectedMarketSpotLengths.Add(MarketSpotLength)
                AvailableMarketSpotLengths.Remove(MarketSpotLength)

            Next

            DataGridViewForm_SelectedMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)
            DataGridViewForm_AvailableMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)

            DataGridViewForm_SelectedMarkets.DataSource = SelectedMarketSpotLengths
            DataGridViewForm_AvailableMarkets.DataSource = AvailableMarketSpotLengths

        End Sub
        Private Sub ButtonRightSection_RemoveMarket_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveMarket.Click

            Dim MarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing
            Dim AvailableMarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing
            Dim SelectedMarketSpotLengths As Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing

            MarketSpotLengths = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList

            AvailableMarketSpotLengths = DataGridViewForm_AvailableMarkets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList
            SelectedMarketSpotLengths = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MarketSpotLength).ToList

            For Each MarketSpotLength In MarketSpotLengths

                SelectedMarketSpotLengths.Remove(MarketSpotLength)
                AvailableMarketSpotLengths.Add(MarketSpotLength)

            Next

            DataGridViewForm_SelectedMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)
            DataGridViewForm_AvailableMarkets.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MarketSpotLength)

            DataGridViewForm_SelectedMarkets.DataSource = SelectedMarketSpotLengths
            DataGridViewForm_AvailableMarkets.DataSource = AvailableMarketSpotLengths

        End Sub

#End Region

#End Region

    End Class

End Namespace
