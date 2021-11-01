Namespace GeneralLedger.Processing.Presentation

    Public Class UnpostedJournalEntryDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel = Nothing
        'Protected _Controller As AdvantageFramework.Controller.GeneralLedger.Processing.UpdateToSummaryController = Nothing
        'Protected _PostPeriodCode As String
        'Protected _GLSource As String
        Protected _UnpostedJournalEntryList As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(UnpostedJournalEntryList As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            '_PostPeriodCode = PostPeriodCode
            '_GLSource = GLSource

            _UnpostedJournalEntryList = UnpostedJournalEntryList

        End Sub
        'Private Sub LoadViewModel()

        '    '_ViewModel = _Controller.JournalEntry_Load(_PostPeriodCode, _GLSource)

        '    'SearchableComboBoxForm_PostPeriodFrom.DataSource = _ViewModel.OpenGLPostPeriodList
        '    'SearchableComboBoxForm_PostPeriodFrom.SelectedValue = _ViewModel.JournalEntry_PostPeriodFromCode

        '    'SearchableComboBoxForm_PostPeriodTo.DataSource = _ViewModel.OpenGLPostPeriodList
        '    'SearchableComboBoxForm_PostPeriodTo.SelectedValue = _ViewModel.JournalEntry_PostPeriodToCode

        '    LoadGrid()

        'End Sub
        Private Sub LoadGrid()

            DataGridViewForm_UnpostedJournalEntries.DataSource = _UnpostedJournalEntryList
            DataGridViewForm_UnpostedJournalEntries.CurrentView.BestFitColumns()

        End Sub
        'Private Sub SaveViewModel()

        '    _ViewModel.JournalEntry_PostPeriodFromCode = SearchableComboBoxForm_PostPeriodFrom.GetSelectedValue
        '    _ViewModel.JournalEntry_PostPeriodToCode = SearchableComboBoxForm_PostPeriodTo.GetSelectedValue

        'End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(UnpostedJournalEntryList As Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry)) As System.Windows.Forms.DialogResult

            'objects
            Dim UnpostedJournalEntryDialog As AdvantageFramework.GeneralLedger.Processing.Presentation.UnpostedJournalEntryDialog = Nothing

            UnpostedJournalEntryDialog = New AdvantageFramework.GeneralLedger.Processing.Presentation.UnpostedJournalEntryDialog(UnpostedJournalEntryList)

            ShowFormDialog = UnpostedJournalEntryDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub UnpostedJournalEntryDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewForm_UnpostedJournalEntries.OptionsBehavior.Editable = False

            'SearchableComboBoxForm_PostPeriodFrom.SetRequired(True)
            'SearchableComboBoxForm_PostPeriodTo.SetRequired(True)

            '_Controller = New AdvantageFramework.Controller.GeneralLedger.Processing.UpdateToSummaryController(Me.Session)

        End Sub
        Private Sub UnpostedJournalEntryDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            'LoadViewModel()
            LoadGrid()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        'Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

        '    Dim ErrorMessage As String = String.Empty

        '    If Me.Validator Then

        '        'SaveViewModel()

        '        _Controller.JournalEntry_RefreshUnpostedJournalEntryList(_ViewModel)

        '        LoadGrid()

        '    Else

        '        For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

        '            ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

        '        Next

        '        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

        '    End If

        'End Sub
        Private Sub DataGridViewForm_UnpostedJournalEntries_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_UnpostedJournalEntries.RowDoubleClickEvent

            Dim GLTransaction As Integer = Nothing

            If DataGridViewForm_UnpostedJournalEntries.HasASelectedRow Then

                GLTransaction = DataGridViewForm_UnpostedJournalEntries.CurrentView.GetRowCellValue(DataGridViewForm_UnpostedJournalEntries.CurrentView.FocusedRowHandle, DataGridViewForm_UnpostedJournalEntries.Columns(AdvantageFramework.DTO.GeneralLedger.Processing.UnpostedJournalEntry.Properties.Transaction.ToString))

                AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog.ShowFormDialog(GLTransaction)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
