Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class RecurringJournalEntrySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

            LoadControl()

        End Sub
        Private Sub RefreshViewModel()

            If RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.Details_IsNewRow Then

                ButtonItemActions_Add.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Print.Enabled = False

            Else

                ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
                ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
                ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
                ButtonItemActions_Copy.Enabled = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.CopyEnabled
                ButtonItemActions_Print.Enabled = _ViewModel.PrintEnabled

            End If

            ButtonItemDetails_Delete.Enabled = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.Details_DeleteEnabled
            ButtonItemDetails_Cancel.Enabled = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.Details_CancelEnabled
            ButtonItemDetails_CopyFrom.Enabled = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.Details_CopyFromEnabled
            ButtonItemDetails_ReverseDebitCredit.Enabled = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.Details_ReverseDebitCreditsEnabled

            RecurringJournalEntryControlRightSection_RecurringJournalEntry.Enabled = (_ViewModel.SelectedRecurringJournalEntry IsNot Nothing)

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_RecurringJournalEntries.OptionsBehavior.Editable = False
            DataGridViewLeftSection_RecurringJournalEntries.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_RecurringJournalEntries.ItemDescription = "Entry(s)"

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_RecurringJournalEntries.DataSource = _ViewModel.RecurringJournalEntries

        End Sub
        Private Sub FormatGrid()

            DataGridViewLeftSection_RecurringJournalEntries.CurrentView.BestFitColumns()

            DataGridViewLeftSection_RecurringJournalEntries.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub LoadControl()

            RecurringJournalEntryControlRightSection_RecurringJournalEntry.ClearControl()

            If _ViewModel.HasASelectedRecurringJournalEntry Then

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.Enabled = True

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.LoadControl(_ViewModel.SelectedRecurringJournalEntry.ControlNumber)

            Else

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.Enabled = False

            End If

        End Sub
        Public Sub RefreshForm()

            Dim ControlNumber As Integer = 0

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            If _ViewModel.HasASelectedRecurringJournalEntry Then

                ControlNumber = _ViewModel.SelectedRecurringJournalEntry.ControlNumber

            End If

            _Controller.RefreshRecurringJournalEntries(_ViewModel)

            LoadGrid()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewLeftSection_RecurringJournalEntries.SelectRow(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem.Properties.ControlNumber.ToString, ControlNumber, True)

            DataGridViewLeftSection_RecurringJournalEntries.GridViewSelectionChanged()

            Me.ClearChanged()

            Me.RaiseClearChanged()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RecurringJournalEntrySetupForm As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm = Nothing

            RecurringJournalEntrySetupForm = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm

            RecurringJournalEntrySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RecurringJournalEntrySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_ReverseDebitCredit.Image = AdvantageFramework.My.Resources.ReplaceImage

            ButtonItemRecurringJournalEntries_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntrySetupController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RecurringJournalEntrySetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewLeftSection_RecurringJournalEntries.GridViewSelectionChanged()

        End Sub
        Private Sub RecurringJournalEntrySetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub RecurringJournalEntrySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ControlNumber As Integer = 0

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Save(ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

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

                Else

                    [Continue] = False

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryEditDialog.ShowFormDialog(ControlNumber) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.RefreshRecurringJournalEntries(_ViewModel)

                    LoadGrid()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_RecurringJournalEntries.SelectRow(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem.Properties.ControlNumber.ToString, ControlNumber, True)

                    DataGridViewLeftSection_RecurringJournalEntries.GridViewSelectionChanged()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim ReselectGridRow As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Save(ErrorMessage) Then

                        If _ViewModel.SelectedRecurringJournalEntry.IsInactive <> RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.RecurringJournalEntry.IsInactive AndAlso
                                RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.RecurringJournalEntry.IsInactive = True Then

                            ReselectGridRow = True

                        End If

                        _ViewModel.SelectedRecurringJournalEntry.Description = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.RecurringJournalEntry.Description
                        _ViewModel.SelectedRecurringJournalEntry.IsInactive = RecurringJournalEntryControlRightSection_RecurringJournalEntry.ViewModel.RecurringJournalEntry.IsInactive

                        DataGridViewLeftSection_RecurringJournalEntries.CurrentView.RefreshData()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        If DataGridViewLeftSection_RecurringJournalEntries.CurrentView.GetFocusedRow Is Nothing OrElse ReselectGridRow Then

                            DataGridViewLeftSection_RecurringJournalEntries.GridViewSelectionChanged()

                        End If

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

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                _Controller.RecurringJournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_RecurringJournalEntries.GetFirstSelectedRowDataBoundItem())

                LoadControl()

                RefreshViewModel()

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ControlNumber As Integer = 0

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Save(ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

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

                Else

                    [Continue] = False

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                If AdvantageFramework.WinForm.MessageBox.Show("Please confirm you want to copy this Recurring Journal Entry?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OKCancel, "Copy?") = AdvantageFramework.WinForm.MessageBox.DialogResults.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

                    If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Copy(ControlNumber, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.RefreshRecurringJournalEntries(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewLeftSection_RecurringJournalEntries.SelectRow(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem.Properties.ControlNumber.ToString, ControlNumber, True)

                        DataGridViewLeftSection_RecurringJournalEntries.GridViewSelectionChanged()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ControlNumber As Integer = 0
            Dim RecurringJournalEntryReport As AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.RecurringJournalEntryReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim AgencyImportPath As String = String.Empty

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Save(ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

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

                Else

                    [Continue] = False

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Printing)

                ControlNumber = DataGridViewLeftSection_RecurringJournalEntries.GetFirstSelectedRowCellValue(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryItem.Properties.ControlNumber.ToString)

                RecurringJournalEntryReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.RecurringJournalEntryReport

                RecurringJournalEntryReport.Session = Me.Session
                RecurringJournalEntryReport.ControlNumber = ControlNumber

                ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(RecurringJournalEntryReport)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedRecurringJournalEntry.ControlNumber)
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedRecurringJournalEntry.ControlNumber), False))

                        ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    Else

                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedRecurringJournalEntry.ControlNumber)

                    End If

                End Using

                RecurringJournalEntryReport.CreateDocument()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                ReportPrintTool.ShowRibbonPreviewDialog()

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.Details_CancelNewItemRow()

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.Details_Delete()

            End If

        End Sub
        Private Sub ButtonItemDetails_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_CopyFrom.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Transaction As Integer = 0

            'If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

            '    If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog.ShowFormDialog(True, Transaction) = Windows.Forms.DialogResult.OK Then

            '        If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Details_CopyFrom(Transaction, ErrorMessage) = False Then

            '            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            '        End If

            '    End If

            'End If

        End Sub
        Private Sub ButtonItemDetails_ReverseDebitCredit_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_ReverseDebitCredit.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to reverse the debits and credits for this transaction?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                RecurringJournalEntryControlRightSection_RecurringJournalEntry.ReverseDebitCredit()

            End If

        End Sub
        Private Sub ButtonItemRecurringJournalEntries_Post_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRecurringJournalEntries_Post.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Try

                    If Me.MdiParent IsNot Nothing Then

                        If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm)) = False Then

                            AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm.ShowForm()

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewLeftSection_RecurringJournalEntries_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_RecurringJournalEntries.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If RecurringJournalEntryControlRightSection_RecurringJournalEntry.Save(ErrorMessage) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                            DataGridViewLeftSection_RecurringJournalEntries.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_RecurringJournalEntries.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.RecurringJournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_RecurringJournalEntries.GetFirstSelectedRowDataBoundItem())

                    LoadControl()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub RecurringJournalEntryControlRightSection_RecurringJournalEntry_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RecurringJournalEntryControlRightSection_RecurringJournalEntry.Details_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub RecurringJournalEntryControlRightSection_RecurringJournalEntry_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles RecurringJournalEntryControlRightSection_RecurringJournalEntry.Details_SelectionChangedEvent

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace
