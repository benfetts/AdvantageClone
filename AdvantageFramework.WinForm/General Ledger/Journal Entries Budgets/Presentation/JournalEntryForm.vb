Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class JournalEntryForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_GLs.DataSource = _ViewModel.JournalEntries

            DataGridViewLeftSection_GLs.CurrentView.BestFitColumns()

            DataGridViewLeftSection_GLs.FocusToFindPanel(True)

            JournalEntryControlRightSection_JournalEntryControl.ClearControl()
            JournalEntryControlRightSection_JournalEntryControl.Enabled = False

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load()

            SearchableComboBoxLeftSection_PostPeriodFrom.DataSource = _ViewModel.AllPostPeriods

            SearchableComboBoxLeftSection_PostPeriodTo.DataSource = _ViewModel.AllPostPeriods

            SearchableComboBoxLeftSection_PostPeriodFrom.SelectedValue = _ViewModel.PostPeriodCodeFrom

            SearchableComboBoxLeftSection_PostPeriodTo.SelectedValue = _ViewModel.PostPeriodCodeTo

        End Sub
        Private Sub RefreshJournalEntries()

            Me.ShowWaitForm("Refreshing...")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

            _Controller.RefreshJournalEntries(_ViewModel)

            LoadGrid()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadSelectedJournalEntry()

            JournalEntryControlRightSection_JournalEntryControl.ClearControl()

            If DataGridViewLeftSection_GLs.HasASelectedRow Then

                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_GLs.GetRowDataBoundItem(DataGridViewLeftSection_GLs.CurrentView.FocusedRowHandle))

                If JournalEntryControlRightSection_JournalEntryControl.LoadControl(_ViewModel.SelectedJournalEntry.Transaction) = False Then

                    JournalEntryControlRightSection_JournalEntryControl.ClearControl()
                    JournalEntryControlRightSection_JournalEntryControl.Enabled = False

                Else

                    ClearChanged()
                    ClearValidations()
                    JournalEntryControlRightSection_JournalEntryControl.Enabled = True

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim JournalEntryForm As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryForm = Nothing

            JournalEntryForm = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryForm

            JournalEntryForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JournalEntryForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JournalEntryForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing



        End Sub
        Private Sub JournalEntryForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Void.Image = AdvantageFramework.My.Resources.InvoiceVoidImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            'ButtonItemRecurAP_Setup.Image = AdvantageFramework.My.Resources.AccountsPayableCreateRecurringImage
            'ButtonItemRecurAP_Setup.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_CreateRecurringAP)

            'ButtonItemRecurAP_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage
            'ButtonItemRecurAP_Post.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.FinanceAccounting_PostRecurringAP)

            'ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            'ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            'ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            'ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            'ButtonItemView_Documents.Image = AdvantageFramework.My.Resources.DocumentManagerImage

            _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController(Me.Session)

        End Sub
        Private Sub JournalEntryForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadViewModel()

            LoadGrid()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub JournalEntryForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim Transaction As Integer = 0

            'If CheckForUnsavedChanges() Then

            If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryEditDialog.ShowFormDialog(Transaction) = Windows.Forms.DialogResult.OK Then



            End If

            'End If

        End Sub
        Private Sub DataGridViewLeftSection_GLs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_GLs.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedJournalEntry()

            End If

        End Sub
        Private Sub SearchableComboBoxLeftSection_PostPeriodFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxLeftSection_PostPeriodFrom.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.SetPostPeriodFrom(_ViewModel, SearchableComboBoxLeftSection_PostPeriodFrom.GetSelectedValue)

                If _ViewModel.PostPeriodCodeFrom <= _ViewModel.PostPeriodCodeTo Then

                    RefreshJournalEntries()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxLeftSection_PostPeriodTo_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxLeftSection_PostPeriodTo.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.SetPostPeriodTo(_ViewModel, SearchableComboBoxLeftSection_PostPeriodTo.GetSelectedValue)

                If _ViewModel.PostPeriodCodeFrom <= _ViewModel.PostPeriodCodeTo Then

                    RefreshJournalEntries()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
