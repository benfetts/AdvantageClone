Namespace Maintenance.Media.Presentation

    Public Class MarketGroupSelectMarketsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _MarketGroupID As Integer = 0
        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSelectMarketsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MarketGroupSelectMarketsController = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MarketGroupID As Integer
            Get
                MarketGroupID = _MarketGroupID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef MarketGroupID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MarketGroupID = MarketGroupID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_Markets.DataSource = _ViewModel.Markets

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_Add.Enabled = _ViewModel.SelectEnabled
            ButtonForm_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.ShowRowSelectionIfHidden = False

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.Code.ToString).OptionsColumn.ReadOnly = True
            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.Description.ToString).OptionsColumn.ReadOnly = True
            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.IsInactive.ToString).OptionsColumn.ReadOnly = True
            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.Country.ToString).OptionsColumn.ReadOnly = True
            DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.State.ToString).OptionsColumn.ReadOnly = True

            DataGridViewForm_Markets.CurrentView.AFActiveFilterString = "[IsInactive] = False"
            DataGridViewForm_Markets.OptionsView.ShowIndicator = False
            DataGridViewForm_Markets.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MarketGroupID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MarketGroupSelectMarketsDialog As AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSelectMarketsDialog = Nothing

            MarketGroupSelectMarketsDialog = New AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSelectMarketsDialog(MarketGroupID)

            ShowFormDialog = MarketGroupSelectMarketsDialog.ShowDialog()

            MarketGroupID = MarketGroupSelectMarketsDialog.MarketGroupID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MarketGroupSelectMarketsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MarketGroupSelectMarketsController(Me.Session)

            _ViewModel = _Controller.Load(_MarketGroupID)

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                If _Controller.Update(_ViewModel, ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_SelectAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_SelectAll.Click

            'objects
            Dim Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market) = Nothing

            Markets = DataGridViewForm_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market).ToList

            _Controller.SelectAll(_ViewModel, Markets)

            DataGridViewForm_Markets.CurrentView.RefreshData()
            DataGridViewForm_Markets.CurrentView.RefreshEditor(True)

        End Sub
        Private Sub ButtonForm_DeselectAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_DeselectAll.Click

            'objects
            Dim Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market) = Nothing

            Markets = DataGridViewForm_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market).ToList

            _Controller.DeselectAll(_ViewModel, Markets)

            DataGridViewForm_Markets.CurrentView.RefreshData()
            DataGridViewForm_Markets.CurrentView.RefreshEditor(True)

        End Sub

#End Region

#End Region

    End Class

End Namespace