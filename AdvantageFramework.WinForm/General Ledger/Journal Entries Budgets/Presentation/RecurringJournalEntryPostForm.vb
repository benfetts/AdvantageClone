Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    Public Class RecurringJournalEntryPostForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostController = Nothing

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

            GridLookUpEditForm_PostPeriod.EditValue = _ViewModel.SelectedPostPeriodCode
            ComboBoxForm_Cycle.SelectedValue = _ViewModel.SelectedCycleCode
            DateEditForm_TransactionDate.EditValue = _ViewModel.SelectedTransactionDate

            LoadGrid()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Post.Enabled = _ViewModel.PostEnabled
            ButtonItemActions_Print.Enabled = _ViewModel.PrintEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_RecurringEntries.OptionsBehavior.Editable = True
            DataGridViewForm_RecurringEntries.OptionsSelection.MultiSelect = False
            DataGridViewForm_RecurringEntries.OptionsCustomization.AllowGroup = False
            DataGridViewForm_RecurringEntries.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_RecurringEntries.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_RecurringEntries.OptionsMenu.EnableColumnMenu = False

            DataGridViewForm_RecurringEntries.ItemDescription = "Entry(ies)"

            DateEditForm_TransactionDate.SetRequired(True)
            DateEditForm_TransactionDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            ComboBoxForm_Cycle.SetRequired(True)
            ComboBoxForm_Cycle.DisplayMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle.Properties.Name.ToString
            ComboBoxForm_Cycle.ValueMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle.Properties.Code.ToString

            GridLookUpEditForm_PostPeriod.SetRequired(True)
            GridLookUpEditForm_PostPeriod.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            GridLookUpEditForm_PostPeriod.Properties.DisplayMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod.Properties.Description.ToString
            GridLookUpEditForm_PostPeriod.Properties.ValueMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod.Properties.Code.ToString
            GridLookUpEditForm_PostPeriod.Properties.ImmediatePopup = False
            GridLookUpEditForm_PostPeriod.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoComplete
            GridLookUpEditForm_PostPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
            GridLookUpEditForm_PostPeriod.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Cycle.DataSource = _ViewModel.Cycles

            'ComboBoxControl_StartingPostPeriod.SetRequired(True)

            GridLookUpEditForm_PostPeriod.DataSource = _ViewModel.PostPeriods


        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_RecurringEntries.DataSource = _ViewModel.RecurringJournalEntryPosts

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_RecurringEntries.CurrentView.BestFitColumns()

        End Sub
        Private Sub RefreshSetupForm()

            Try

                For Each MdiChild In Me.ParentForm.MdiChildren

                    If TypeOf MdiChild Is AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm Then

                        DirectCast(MdiChild, AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntrySetupForm).RefreshForm()
                        Exit For

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RecurringJournalEntryPostForm As AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm = Nothing

            RecurringJournalEntryPostForm = New AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm

            RecurringJournalEntryPostForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RecurringJournalEntryPostForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Post.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryPostController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RecurringJournalEntryPostForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewForm_RecurringEntries.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Post_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Post.Click

            Dim [Continue] As Boolean = True
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.RecurringJournalEntryPosts.Any(Function(Entity) Entity.CreateJournalEntry AndAlso Entity.JournalEntryCreatedForPostPeriod) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("One or more recurring journal entries has already been posted for the posted period selected.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                        [Continue] = False

                    End If

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If _Controller.Post(_ViewModel, ErrorMessage) Then

                        RefreshSetupForm()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show("Recurring journal entries have been posted.")

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        _Controller.LoadRecurringJournalEntries(_ViewModel)

                        _Controller.EnableDisableActions(_ViewModel)

                        LoadGrid()

                        FormatGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Print.Click

            'objects
            Dim RecurringJournalEntryPostReport As AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.RecurringJournalEntryPostReport = Nothing
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
            Dim PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing
            Dim AgencyImportPath As String = String.Empty

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Printing)

            RecurringJournalEntryPostReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.JournalEntry.RecurringJournalEntryPostReport

            RecurringJournalEntryPostReport.Session = Me.Session
            RecurringJournalEntryPostReport.CycleCode = ComboBoxForm_Cycle.SelectedValue
            RecurringJournalEntryPostReport.PostPeriodCode = GridLookUpEditForm_PostPeriod.EditValue

            ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(RecurringJournalEntryPostReport)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                        If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                            My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                        End If

                    End If

                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Recurring Journal Entries - Batch Report - " & _ViewModel.SelectedPostPeriodCode)
                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                    ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), AdvantageFramework.FileSystem.CreateValidFileName("Recurring Journal Entries - Batch Report - " & _ViewModel.SelectedPostPeriodCode), False))

                    ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                Else

                    ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName("Recurring Journal Entries - Batch Report - " & _ViewModel.SelectedPostPeriodCode)

                End If

            End Using

            RecurringJournalEntryPostReport.CreateDocument()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            ReportPrintTool.ShowRibbonPreviewDialog()

        End Sub
        Private Sub GridLookUpEditForm_PostPeriod_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles GridLookUpEditForm_PostPeriod.EditValueChanging

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.PostPeriodChanged(_ViewModel, e.NewValue)

                _Controller.LoadRecurringJournalEntries(_ViewModel)

                _Controller.EnableDisableActions(_ViewModel)

                LoadGrid()

                FormatGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub GridLookUpEditForm_PostPeriod_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GridLookUpEditForm_PostPeriod.Validating

            If GridLookUpEditForm_PostPeriod.EditValue <> _ViewModel.SelectedPostPeriodCode Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.PostPeriodChanged(_ViewModel, GridLookUpEditForm_PostPeriod.EditValue)

                _Controller.LoadRecurringJournalEntries(_ViewModel)

                _Controller.EnableDisableActions(_ViewModel)

                LoadGrid()

                FormatGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If String.IsNullOrWhiteSpace(GridLookUpEditForm_PostPeriod.EditValue) Then

                    GridLookUpEditForm_PostPeriod.Text = String.Empty

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_Cycle_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Cycle.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.CycleChanged(_ViewModel, ComboBoxForm_Cycle.SelectedValue)

                _Controller.LoadRecurringJournalEntries(_ViewModel)

                _Controller.EnableDisableActions(_ViewModel)

                LoadGrid()

                FormatGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxForm_Cycle_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBoxForm_Cycle.Validating

            If ComboBoxForm_Cycle.SelectedValue <> _ViewModel.SelectedCycleCode Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.CycleChanged(_ViewModel, ComboBoxForm_Cycle.SelectedValue)

                _Controller.LoadRecurringJournalEntries(_ViewModel)

                _Controller.EnableDisableActions(_ViewModel)

                LoadGrid()

                FormatGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub DateEditForm_TransactionDate_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DateEditForm_TransactionDate.EditValueChanging

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.TransactionDateChanged(_ViewModel, DateEditForm_TransactionDate.EditValue)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub DataGridViewForm_RecurringEntries_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_RecurringEntries.CellValueChangingEvent

            'objects
            Dim RecurringJournalEntryPost As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost.Properties.CreateJournalEntry.ToString Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                RecurringJournalEntryPost = DirectCast(DataGridViewForm_RecurringEntries.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost)

                _Controller.CreateJournalEntryChanged(_ViewModel, RecurringJournalEntryPost, e.Value)

                _Controller.EnableDisableActions(_ViewModel)

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Saved = True

            End If

        End Sub
        Private Sub DataGridViewForm_RecurringEntries_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_RecurringEntries.ShowingEditorEvent

            If DataGridViewForm_RecurringEntries.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost.Properties.CreateJournalEntry.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_RecurringEntries_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_RecurringEntries.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryPost.Properties.NumberRemaining.ToString Then

                If e.Value = Integer.MaxValue Then

                    e.DisplayText = String.Empty

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
