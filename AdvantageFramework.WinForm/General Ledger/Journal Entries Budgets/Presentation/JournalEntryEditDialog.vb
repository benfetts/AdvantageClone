Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class JournalEntryEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController = Nothing
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

        Private Sub New(ByRef Transaction As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _Transaction = Transaction

        End Sub
        Private Sub SetupViewModel()

            JournalEntryControlForm_JournalEntry.LoadControl(_Transaction)

        End Sub
        Private Sub RefreshViewModel()

            If JournalEntryControlForm_JournalEntry.ViewModel.Details_IsNewRow Then

                ButtonItemActions_Add.Enabled = False
                ButtonItemActions_Update.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ComboBoxItemOffice_Offices.Enabled = False

            Else

                ButtonItemActions_Add.Enabled = True
                ButtonItemActions_Update.Enabled = True
                ButtonItemActions_Cancel.Enabled = True
                ComboBoxItemOffice_Offices.Enabled = True

            End If

            ButtonItemActions_Add.Visible = JournalEntryControlForm_JournalEntry.ViewModel.AddEnabled
            ButtonItemActions_Update.Visible = JournalEntryControlForm_JournalEntry.ViewModel.UpdateEnabled

            RibbonBarOptions_Office.Visible = ButtonItemActions_Add.Visible

            ButtonItemDetails_Cancel.Enabled = JournalEntryControlForm_JournalEntry.ViewModel.Details_CancelEnabled
            ButtonItemDetails_Delete.Enabled = JournalEntryControlForm_JournalEntry.ViewModel.Details_DeleteEnabled
            ButtonItemDetails_CopyFrom.Enabled = JournalEntryControlForm_JournalEntry.ViewModel.Details_CopyFromEnabled
            ButtonItemDetails_ReverseDebitCredit.Enabled = JournalEntryControlForm_JournalEntry.ViewModel.Details_ReverseDebitCreditsEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxItemOffice_Offices.ComboBoxEx.DisplayMember = "Display"
            ComboBoxItemOffice_Offices.ComboBoxEx.ValueMember = "Value"

        End Sub
        Private Sub SetControlDataSources()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From Office In JournalEntryControlForm_JournalEntry.ViewModel.Offices
                                        Select Display = Office.Display,
                                               Value = Office.Value).ToList

            ComboBoxItemOffice_Offices.ComboBoxEx.DataSource = BindingSource

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Display", "Value", "[Please select]", "", True, False, Nothing)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Transaction As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim JournalEntryEditDialog As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryEditDialog = Nothing

            JournalEntryEditDialog = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryEditDialog(Transaction)

            ShowFormDialog = JournalEntryEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Transaction = JournalEntryEditDialog.Transaction

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JournalEntryEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_ReverseDebitCredit.Image = AdvantageFramework.My.Resources.ReplaceImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            '_Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController(Me.Session)

            SetupViewModel()

            SetControlDataSources()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub JournalEntryEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            'SetupViewModel()

            'SetControlDataSources()

            'RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

            JournalEntryControlForm_JournalEntry.GridLookUpEditControl_PostPeriod.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    If JournalEntryControlForm_JournalEntry.Add(ErrorMessage) Then

                        _Transaction = JournalEntryControlForm_JournalEntry.ViewModel.JournalEntry.Transaction

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
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If JournalEntryControlForm_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        If RefreshOnAlreadyPostedError Then

                            SetupViewModel()

                        End If

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

            JournalEntryControlForm_JournalEntry.Details_CancelNewItemRow()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            JournalEntryControlForm_JournalEntry.Details_Delete()

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDetails_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_CopyFrom.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Transaction As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog.ShowFormDialog(True, Transaction) = Windows.Forms.DialogResult.OK Then

                    If JournalEntryControlForm_JournalEntry.Details_CopyFrom(Transaction, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_ReverseDebitCredit_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_ReverseDebitCredit.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to reverse the debits and credits for this transaction?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                JournalEntryControlForm_JournalEntry.ReverseDebitCredit()

            End If

        End Sub
        Private Sub JournalEntryControlForm_JournalEntry_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles JournalEntryControlForm_JournalEntry.Details_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub JournalEntryControlForm_JournalEntry_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles JournalEntryControlForm_JournalEntry.Details_SelectionChangedEvent

            RefreshViewModel()

        End Sub
        Private Sub ComboBoxItemOffice_Offices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemOffice_Offices.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                JournalEntryControlForm_JournalEntry.SelectedOfficeChanged(ComboBoxItemOffice_Offices.ComboBoxEx.SelectedValue)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
