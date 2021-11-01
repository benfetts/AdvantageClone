Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class JournalEntryDetailsCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyController = Nothing
        Protected _CopyFrom As Boolean = True
        Protected _Transaction As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property Transaction As Integer
            Get
                Transaction = _Transaction
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(CopyFrom As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _CopyFrom = CopyFrom

        End Sub
        Private Sub LoadViewModel()

            SearchableComboBoxForm_PostPeriodFrom.SelectedValue = _ViewModel.PostPeriodCodeFrom
            SearchableComboBoxForm_PostPeriodTo.SelectedValue = _ViewModel.PostPeriodCodeTo

            LoadGrid()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Copy.Enabled = _ViewModel.HasASelectedJournalEntry

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_JournalEntries.OptionsBehavior.Editable = False
            DataGridViewForm_JournalEntries.OptionsSelection.MultiSelect = False

            DataGridViewForm_JournalEntries.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_JournalEntries.OptionsCustomization.AllowGroup = False
            DataGridViewForm_JournalEntries.OptionsCustomization.AllowQuickHideColumns = False

            DataGridViewForm_JournalEntries.ItemDescription = "Entry(s)"

            SearchableComboBoxForm_PostPeriodFrom.ByPassUserEntryChanged = True
            SearchableComboBoxForm_PostPeriodTo.ByPassUserEntryChanged = True

        End Sub
        Private Sub SetControlDataSources()

            SearchableComboBoxForm_PostPeriodFrom.DataSource = _ViewModel.AllPostPeriods

            SearchableComboBoxForm_PostPeriodTo.DataSource = _ViewModel.AllPostPeriods

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_JournalEntries.DataSource = _ViewModel.JournalEntries

        End Sub
        Private Sub FormatGrid()

            If DataGridViewForm_JournalEntries.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.HasDocuments.ToString) IsNot Nothing Then

                DataGridViewForm_JournalEntries.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.HasDocuments.ToString).Visible = False

            End If

            DataGridViewForm_JournalEntries.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(CopyFrom As Boolean, ByRef Transaction As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim JournalEntryDetailsCopyDialog As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog = Nothing

            JournalEntryDetailsCopyDialog = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog(CopyFrom)

            ShowFormDialog = JournalEntryDetailsCopyDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Transaction = JournalEntryDetailsCopyDialog.Transaction

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JournalEntryDetailsCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.ByPassUserEntryChanged = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryDetailCopyController(Me.Session)

            _ViewModel = _Controller.Load(_CopyFrom)

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub JournalEntryDetailsCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewForm_JournalEntries.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            If _ViewModel.HasASelectedJournalEntry Then

                _Transaction = _ViewModel.SelectedJournalEntry.Transaction

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_JournalEntries_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_JournalEntries.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewForm_JournalEntries.GetFirstSelectedRowDataBoundItem())

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_JournalEntries_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_JournalEntries.ColumnFilterChangedEvent

            DataGridViewForm_JournalEntries.GridViewSelectionChanged()

        End Sub
        Private Sub SearchableComboBoxForm_PostPeriodFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_PostPeriodFrom.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.SetPostPeriodFrom(_ViewModel, SearchableComboBoxForm_PostPeriodFrom.GetSelectedValue)

                LoadGrid()

                FormatGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_JournalEntries.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_PostPeriodTo_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_PostPeriodTo.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.SetPostPeriodTo(_ViewModel, SearchableComboBoxForm_PostPeriodTo.GetSelectedValue)

                LoadGrid()

                FormatGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_JournalEntries.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub


#End Region

#End Region

    End Class

End Namespace
