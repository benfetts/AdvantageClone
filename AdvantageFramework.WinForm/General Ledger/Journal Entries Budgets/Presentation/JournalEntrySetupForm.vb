Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class JournalEntrySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupController = Nothing

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

            GridLookUpEditLeftSection_PostPeriodFrom.SelectedValue = _ViewModel.PostPeriodCodeFrom
            GridLookUpEditLeftSection_PostPeriodTo.SelectedValue = _ViewModel.PostPeriodCodeTo
            NumericInputLeftSections_Transaction.EditValue = Nothing

            LoadGrid()

            LoadControl()

        End Sub
        Private Sub RefreshViewModel()

            If JournalEntryControlRightSection_JournalEntry.ViewModel.Details_IsNewRow Then

                ButtonItemActions_Add.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Void.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Print.Enabled = False
                ButtonItemActions_Refresh.Enabled = False

                ButtonItemDocuments_View.Enabled = False
                ButtonItemDocuments_Upload.Enabled = False

                ButtonItemRecurringJournalEntries_Setup.Enabled = False
                ButtonItemRecurringJournalEntries_Post.Enabled = False

            Else

                ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
                ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
                ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
                ButtonItemActions_Void.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.VoidEnabled
                ButtonItemActions_Copy.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.CopyEnabled
                ButtonItemActions_Print.Enabled = _ViewModel.PrintEnabled
                ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

                ButtonItemDocuments_View.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.Documents_ViewEnabled
                ButtonItemDocuments_Upload.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.Documents_UploadEnabled

                ButtonItemRecurringJournalEntries_Setup.Enabled = True
                ButtonItemRecurringJournalEntries_Post.Enabled = True

            End If

            ButtonItemDetails_Delete.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.Details_DeleteEnabled
            ButtonItemDetails_Cancel.Enabled = JournalEntryControlRightSection_JournalEntry.ViewModel.Details_CancelEnabled
            ButtonItemDetails_CopyFrom.Enabled = (JournalEntryControlRightSection_JournalEntry.ViewModel.Details_CopyFromEnabled AndAlso _ViewModel.SelectedJournalEntry IsNot Nothing)
            ButtonItemDetails_ReverseDebitCredit.Enabled = (JournalEntryControlRightSection_JournalEntry.ViewModel.Details_ReverseDebitCreditsEnabled AndAlso _ViewModel.SelectedJournalEntry IsNot Nothing)

            JournalEntryControlRightSection_JournalEntry.Enabled = (_ViewModel.SelectedJournalEntry IsNot Nothing)

            NumericInputLeftSections_Transaction.Enabled = (_ViewModel.SaveEnabled = False)

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_JournalEntries.OptionsBehavior.Editable = False
            DataGridViewLeftSection_JournalEntries.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_JournalEntries.ItemDescription = "Entry(s)"

            GridLookUpEditLeftSection_PostPeriodFrom.ByPassUserEntryChanged = True
            GridLookUpEditLeftSection_PostPeriodFrom.Properties.ImmediatePopup = False
            GridLookUpEditLeftSection_PostPeriodFrom.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoComplete
            GridLookUpEditLeftSection_PostPeriodFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
            GridLookUpEditLeftSection_PostPeriodFrom.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup

            GridLookUpEditLeftSection_PostPeriodTo.ByPassUserEntryChanged = True
            GridLookUpEditLeftSection_PostPeriodTo.Properties.ImmediatePopup = False
            GridLookUpEditLeftSection_PostPeriodTo.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoComplete
            GridLookUpEditLeftSection_PostPeriodTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
            GridLookUpEditLeftSection_PostPeriodTo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            NumericInputLeftSections_Transaction.ByPassUserEntryChanged = True

        End Sub
        Private Sub SetControlDataSources()

            GridLookUpEditLeftSection_PostPeriodFrom.DataSource = _ViewModel.AllPostPeriods

            GridLookUpEditLeftSection_PostPeriodTo.DataSource = _ViewModel.AllPostPeriods

        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_JournalEntries.DataSource = _ViewModel.JournalEntries

        End Sub
        Private Sub FormatGrid()

            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText
            RepositoryItemCheckEdit.DisplayValueChecked = "Yes"
            RepositoryItemCheckEdit.DisplayValueUnchecked = "No"
            RepositoryItemCheckEdit.DisplayValueGrayed = "No"
            RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

            RepositoryItemCheckEdit.ImageOptions.ImageChecked = AdvantageFramework.My.Resources.DocumentsImage

            RepositoryItemCheckEdit.ImageOptions.ImageUnchecked = Nothing
            RepositoryItemCheckEdit.ImageOptions.ImageGrayed = Nothing
            RepositoryItemCheckEdit.ValueChecked = True
            RepositoryItemCheckEdit.ValueUnchecked = False
            RepositoryItemCheckEdit.ValueGrayed = Nothing
            RepositoryItemCheckEdit.NullText = "No"
            RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
            RepositoryItemCheckEdit.AllowFocused = False

            DataGridViewLeftSection_JournalEntries.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            DataGridViewLeftSection_JournalEntries.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.HasDocuments.ToString).ColumnEdit = RepositoryItemCheckEdit

            DataGridViewLeftSection_JournalEntries.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.HasDocuments.ToString).MaxWidth = 25

            DataGridViewLeftSection_JournalEntries.CurrentView.BestFitColumns()

            'DataGridViewLeftSection_JournalEntries.FocusToFindPanel(True)

            'DataGridViewLeftSection_JournalEntries.HideRowSelection()

        End Sub
        Private Sub LoadControl()

            JournalEntryControlRightSection_JournalEntry.ClearControl()

            If _ViewModel.HasASelectedJournalEntry Then

                JournalEntryControlRightSection_JournalEntry.Enabled = True

                JournalEntryControlRightSection_JournalEntry.LoadControl(_ViewModel.SelectedJournalEntry.Transaction)

            Else

                JournalEntryControlRightSection_JournalEntry.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim JournalEntrySetupForm As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntrySetupForm = Nothing

            JournalEntrySetupForm = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntrySetupForm

            JournalEntrySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JournalEntrySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Void.Image = AdvantageFramework.My.Resources.InvoiceVoidImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_ReverseDebitCredit.Image = AdvantageFramework.My.Resources.ReplaceImage

            ButtonItemDocuments_View.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage

            ButtonItemRecurringJournalEntries_Setup.Image = AdvantageFramework.My.Resources.AccountsPayableCreateRecurringImage
            ButtonItemRecurringJournalEntries_Post.Image = AdvantageFramework.My.Resources.AccountsPayablePostRecurringImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntrySetupController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            'DataGridViewLeftSection_JournalEntries.CurrentView.AFActiveFilterString = "[IsVoided] = False"

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub JournalEntrySetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

            GridLookUpEditLeftSection_PostPeriodFrom.Focus()

        End Sub
        Private Sub JournalEntrySetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub JournalEntrySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

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
            Dim Transaction As Integer = 0
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

                If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryEditDialog.ShowFormDialog(Transaction) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.RefreshJournalEntries(_ViewModel)

                    LoadGrid()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_JournalEntries.SelectRow(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.Transaction.ToString, Transaction, True)

                    DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                        _ViewModel.SelectedJournalEntry.Description = JournalEntryControlRightSection_JournalEntry.ViewModel.JournalEntry.Description
                        _ViewModel.SelectedJournalEntry.PostPeriodCode = JournalEntryControlRightSection_JournalEntry.ViewModel.JournalEntry.PostPeriodCode

                        DataGridViewLeftSection_JournalEntries.CurrentView.RefreshData()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        If DataGridViewLeftSection_JournalEntries.CurrentView.GetFocusedRow Is Nothing Then

                            DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                        If RefreshOnAlreadyPostedError Then

                            _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                            LoadControl()

                            RefreshViewModel()

                            Me.ClearChanged()

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

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                LoadControl()

                RefreshViewModel()

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Void_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Void.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to void this entry?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    If JournalEntryControlRightSection_JournalEntry.Void(ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        _Controller.RefreshJournalEntries(_ViewModel)

                        LoadGrid()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                        RefreshViewModel()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Transaction As Integer = 0
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to copy this Journal Entry?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Copy?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

                    If JournalEntryControlRightSection_JournalEntry.Copy(Transaction, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.RefreshJournalEntries(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewLeftSection_JournalEntries.SelectRow(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.Transaction.ToString, Transaction, True)

                        DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                        AdvantageFramework.WinForm.MessageBox.Show("JE " & Transaction & " has been created!")

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
            Dim Transaction As Integer = 0
            Dim JournalEntryReport As AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.JournalEntryReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim AgencyImportPath As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

                Transaction = DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowCellValue(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.Transaction.ToString)

                JournalEntryReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.JournalEntryReport

                JournalEntryReport.Session = Me.Session
                JournalEntryReport.Transaction = Transaction

                ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(JournalEntryReport)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedJournalEntry.Transaction)
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedJournalEntry.Transaction), False))

                        ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    Else

                        ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_ViewModel.SelectedJournalEntry.Transaction)

                    End If

                End Using

                JournalEntryReport.CreateDocument()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                ReportPrintTool.ShowRibbonPreviewDialog()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.RefreshJournalEntries(_ViewModel)

                LoadGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                Me.ClearChanged()

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                JournalEntryControlRightSection_JournalEntry.Details_CancelNewItemRow()

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                JournalEntryControlRightSection_JournalEntry.Details_Delete()

            End If

        End Sub
        Private Sub ButtonItemDetails_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_CopyFrom.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Transaction As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntryDetailsCopyDialog.ShowFormDialog(True, Transaction) = Windows.Forms.DialogResult.OK Then

                    If JournalEntryControlRightSection_JournalEntry.Details_CopyFrom(Transaction, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_ReverseDebitCredit_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_ReverseDebitCredit.Click

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to reverse the debits and credits for this transaction?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                JournalEntryControlRightSection_JournalEntry.ReverseDebitCredit()

            End If

        End Sub
        Private Sub ButtonItemDocuments_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDocuments_View.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                JournalEntryControlRightSection_JournalEntry.ViewDocuments()

                _Controller.RefreshSelectedJournalEntry(_ViewModel)

                DataGridViewLeftSection_JournalEntries.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDocuments_Upload.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If JournalEntryControlRightSection_JournalEntry.UploadDocument() Then

                    _ViewModel.SelectedJournalEntry.HasDocuments = True

                    DataGridViewLeftSection_JournalEntries.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                JournalEntryControlRightSection_JournalEntry.SendASPUploadEmail()

            End If

        End Sub
        Private Sub ButtonItemRecurringJournalEntries_Setup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRecurringJournalEntries_Setup.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Try

                    If Me.MdiParent IsNot Nothing Then

                        If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm)) = False Then

                            AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm.ShowForm()

                        End If

                    End If

                Catch ex As Exception

                End Try

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
        Private Sub DataGridViewLeftSection_JournalEntries_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_JournalEntries.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JournalEntries_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_JournalEntries.FocusedRowChangedEvent

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                            DataGridViewLeftSection_JournalEntries.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

                        End If

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DataGridViewLeftSection_JournalEntries.CurrentView.FocusedRowHandle = e.PrevFocusedRowHandle

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                    LoadControl()

                    RefreshViewModel()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub GridLookUpEditLeftSection_PostPeriodFrom_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles GridLookUpEditLeftSection_PostPeriodFrom.EditValueChanging

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

            e.Cancel = ([Continue] = False)

        End Sub
        Private Sub GridLookUpEditLeftSection_PostPeriodFrom_EditValueChanged(sender As Object, e As EventArgs) Handles GridLookUpEditLeftSection_PostPeriodFrom.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.SetPostPeriodFrom(_ViewModel, GridLookUpEditLeftSection_PostPeriodFrom.EditValue)

                LoadGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub
        Private Sub GridLookUpEditLeftSection_PostPeriodTo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles GridLookUpEditLeftSection_PostPeriodTo.EditValueChanging

            'objects
            Dim [Continue] As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim RefreshOnAlreadyPostedError As Boolean = False

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes.  Do you want to save changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        If JournalEntryControlRightSection_JournalEntry.Save(ErrorMessage, RefreshOnAlreadyPostedError) Then

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        Else

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                            If RefreshOnAlreadyPostedError Then

                                _Controller.JournalEntrySelectionChanged(_ViewModel, DataGridViewLeftSection_JournalEntries.GetFirstSelectedRowDataBoundItem())

                                LoadControl()

                                RefreshViewModel()

                                Me.ClearChanged()

                            End If

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

            e.Cancel = ([Continue] = False)

        End Sub
        Private Sub GridLookUpEditLeftSection_PostPeriodTo_EditValueChanged(sender As Object, e As EventArgs) Handles GridLookUpEditLeftSection_PostPeriodTo.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                _Controller.SetPostPeriodTo(_ViewModel, GridLookUpEditLeftSection_PostPeriodTo.GetSelectedValue)

                LoadGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_JournalEntries.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub
        Private Sub JournalEntryControlRightSection_JournalEntry_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles JournalEntryControlRightSection_JournalEntry.Details_InitNewRowEvent

            RefreshViewModel()

        End Sub
        Private Sub JournalEntryControlRightSection_JournalEntry_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles JournalEntryControlRightSection_JournalEntry.Details_SelectionChangedEvent

            RefreshViewModel()

        End Sub
        Private Sub NumericInputLeftSections_Transaction_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputLeftSections_Transaction.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                e.NewValue = Nothing
                e.Cancel = True

            End If

        End Sub
        Private Sub NumericInputLeftSections_Transaction_Leave(sender As Object, e As EventArgs) Handles NumericInputLeftSections_Transaction.Leave

            'objects
            Dim Transaction As Integer = Nothing
            Dim MediaManagerSearchResult As AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult = Nothing
            Dim OrderNumberFound As Boolean = False

            If NumericInputLeftSections_Transaction.EditValue IsNot Nothing Then

                Transaction = NumericInputLeftSections_Transaction.EditValue

                If _Controller.LoadSingleTransaction(_ViewModel, Transaction) Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                    GridLookUpEditLeftSection_PostPeriodFrom.SelectedValue = _ViewModel.PostPeriodCodeFrom
                    GridLookUpEditLeftSection_PostPeriodTo.SelectedValue = _ViewModel.PostPeriodCodeTo

                    LoadGrid()

                    DataGridViewLeftSection_JournalEntries.SelectAllRowsByValue(1, Transaction, True)

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    DataGridViewLeftSection_JournalEntries.CurrentView.GridViewSelectionChanged()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Transaction '" & Transaction & "' was not found.")

                End If

                NumericInputLeftSections_Transaction.EditValue = Nothing
                NumericInputLeftSections_Transaction.Focus()

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
