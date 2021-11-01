Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class RecurringJournalEntryEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController = Nothing
        Protected _ControlNumber As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property ControlNumber As Integer
            Get
                ControlNumber = _ControlNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ControlNumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _ControlNumber = ControlNumber

        End Sub
        Private Sub SetupViewModel()

            RecurringJournalEntryForm_JournalEntry.LoadControl(_ControlNumber)

        End Sub
        Private Sub RefreshViewModel()

            If RecurringJournalEntryForm_JournalEntry.ViewModel.Details_IsNewRow Then

                ButtonItemActions_Add.Enabled = False
                ButtonItemActions_Update.Enabled = False
                ButtonItemActions_Cancel.Enabled = False

            Else

                ButtonItemActions_Add.Enabled = True
                ButtonItemActions_Update.Enabled = True
                ButtonItemActions_Cancel.Enabled = True

            End If

            ButtonItemActions_Add.Visible = RecurringJournalEntryForm_JournalEntry.ViewModel.AddEnabled
            ButtonItemActions_Update.Visible = RecurringJournalEntryForm_JournalEntry.ViewModel.UpdateEnabled

            ButtonItemDetails_Cancel.Enabled = RecurringJournalEntryForm_JournalEntry.ViewModel.Details_CancelEnabled
            ButtonItemDetails_Delete.Enabled = RecurringJournalEntryForm_JournalEntry.ViewModel.Details_DeleteEnabled
            ButtonItemDetails_CopyFrom.Enabled = RecurringJournalEntryForm_JournalEntry.ViewModel.Details_CopyFromEnabled
            ButtonItemDetails_ReverseDebitCredit.Enabled = RecurringJournalEntryForm_JournalEntry.ViewModel.Details_ReverseDebitCreditsEnabled

        End Sub
        Private Sub SetControlPropertySettings()



        End Sub
        Private Sub SetControlDataSources()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ControlNumber As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RecurringJournalEntryEditDialog As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryEditDialog = Nothing

            RecurringJournalEntryEditDialog = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryEditDialog(ControlNumber)

            ShowFormDialog = RecurringJournalEntryEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ControlNumber = RecurringJournalEntryEditDialog.ControlNumber

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RecurringJournalEntryEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_ReverseDebitCredit.Image = AdvantageFramework.My.Resources.ReplaceImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            '_Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController(Me.Session)

            SetupViewModel()

            SetControlDataSources()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RecurringJournalEntryEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            'SetupViewModel()

            'SetControlDataSources()

            'RefreshViewModel()

            'Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

            RecurringJournalEntryForm_JournalEntry.ComboBoxControl_Cycle.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    If RecurringJournalEntryForm_JournalEntry.Add(ErrorMessage) Then

                        _ControlNumber = RecurringJournalEntryForm_JournalEntry.ViewModel.RecurringJournalEntry.ControlNumber

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If RecurringJournalEntryForm_JournalEntry.Save(ErrorMessage) Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            RecurringJournalEntryForm_JournalEntry.Details_CancelNewItemRow()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            RecurringJournalEntryForm_JournalEntry.Details_Delete()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_CopyFrom.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim ControlNumber As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog.ShowFormDialog(True, ControlNumber) = Windows.Forms.DialogResult.OK Then

                    If RecurringJournalEntryForm_JournalEntry.Details_CopyFrom(ControlNumber, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_ReverseDebitCredit_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_ReverseDebitCredit.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to reverse the debits and credits for this transaction?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                RecurringJournalEntryForm_JournalEntry.ReverseDebitCredit()

            End If

        End Sub
        Private Sub RecurringJournalEntryForm_JournalEntry_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RecurringJournalEntryForm_JournalEntry.Details_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub RecurringJournalEntryForm_JournalEntry_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles RecurringJournalEntryForm_JournalEntry.Details_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace