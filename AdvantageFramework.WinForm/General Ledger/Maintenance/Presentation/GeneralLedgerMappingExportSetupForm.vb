Imports DevExpress.XtraGrid.Views.Base

Namespace GeneralLedger.Maintenance.Views

    Public Class GeneralLedgerMappingExportSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Maintenance.GeneralLedgerMappingExportViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerMappingExportController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean, LoadDetailGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_TargetAccounts.RefreshDataSource()

            End If

            If LoadDetailGrid Then

                DataGridViewForm_GeneralLedgerAccounts.RefreshDataSource()
                DataGridViewForm_GeneralLedgerAccounts.CurrentView.BestFitColumns()

            End If

            DataGridViewForm_TargetAccounts.Enabled = _ViewModel.HasASelectedRecordSource
            DataGridViewForm_GeneralLedgerAccounts.Enabled = _ViewModel.HasASelectedSourceAccount

            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Sync.Enabled = _ViewModel.SyncEnabled
            ButtonItemActions_Export.Enabled = _ViewModel.ExportEnabled

            ButtonItemDetails_Cancel.Enabled = _ViewModel.DetailCancelEnabled
            ButtonItemDetails_Delete.Enabled = _ViewModel.DetailDeleteEnabled

        End Sub
        Private Sub AddNewRow(RowObject As Object)

            Dim ErrorMessage As String = Nothing

            Me.ShowWaitForm("Processing...")

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount Then

                If Not _Controller.AddDetail(_ViewModel, RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    _Controller.GeneralLedgerAccountSelectionChanged(_ViewModel, DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow, DataGridViewForm_GeneralLedgerAccounts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount).ToList)

                    RefreshViewModel(False, True)

                End If

            ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount Then

                If Not _Controller.Add(_ViewModel, RowObject, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewForm_TargetAccounts.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    _Controller.GeneralLedgerMappingExportTargetAccountSelectionChanged(_ViewModel, DataGridViewForm_TargetAccounts.IsNewItemRow, DataGridViewForm_TargetAccounts.GetRowDataBoundItem(DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle))

                    RefreshViewModel(True, True)

                End If

            End If

            Me.CloseWaitForm()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim GeneralLedgerMappingExportSetupForm As GeneralLedger.Maintenance.Views.GeneralLedgerMappingExportSetupForm = Nothing

            GeneralLedgerMappingExportSetupForm = New GeneralLedger.Maintenance.Views.GeneralLedgerMappingExportSetupForm()

            GeneralLedgerMappingExportSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerMappingExportSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemRecordSource_Manage.Image = AdvantageFramework.My.Resources.RecordSourceImage

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Sync.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            DataGridViewForm_TargetAccounts.OptionsView.ColumnAutoWidth = True
            DataGridViewForm_TargetAccounts.MultiSelect = False

            _Controller = New AdvantageFramework.Controller.GeneralLedger.Maintenance.GeneralLedgerMappingExportController(Me.Session)

            _ViewModel = _Controller.Load()

            ComboBoxRecordSource_RecordSource.DataSource = _ViewModel.RecordSources

        End Sub
        Private Sub GeneralLedgerMappingExportSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_TargetAccounts.DataSource = _ViewModel.GeneralLedgerMappingExportTargetAccounts
            DataGridViewForm_GeneralLedgerAccounts.DataSource = _ViewModel.GeneralLedgerMappingExportGLAccounts

            RefreshViewModel(False, False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_TargetAccounts.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False, False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewForm_TargetAccounts.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    If Not _Controller.Delete(_ViewModel, ErrorMessage) Then

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                    End If

                    RefreshViewModel(True, False)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_TargetAccounts.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                DataTable = _Controller.Export(_ViewModel)

                DataGridView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView

                DataGridView.OptionsView.ShowViewCaption = False
                DataGridView.OptionsPrint.AutoWidth = False
                DataGridView.DataSource = DataTable
                DataGridView.CurrentView.BestFitColumns()

                DataGridView.Print(Me.Session, DefaultLookAndFeel.LookAndFeel, "GL Mapping Export Report")

            End If

        End Sub
        Private Sub ButtonItemActions_Sync_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Sync.Click

            'objects
            Dim ForceViewRefresh As Boolean = True

            If AdvantageFramework.Navigation.ShowMessageBox("Syncing will add all missing Source Accounts from General Ledger Mapping. Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing, "Processing...")

                _Controller.SyncMappingExportAccounts(_ViewModel)

                RefreshViewModel(True, False)

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

                If _ViewModel.SelectedGeneralLedgerMappingExportTargetAccount IsNot Nothing Then

                    For I = 0 To DataGridViewForm_TargetAccounts.CurrentView.RowCount - 1

                        If DirectCast(DataGridViewForm_TargetAccounts.GetRowDataBoundItem(I), AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount).ID = _ViewModel.SelectedGeneralLedgerMappingExportTargetAccount.ID Then

                            If I <> DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle Then

                                DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle = I

                                ForceViewRefresh = False 'focused row changing will take care of the rest

                            End If

                            Exit For

                        End If

                    Next

                End If

                If ForceViewRefresh Then

                    DataGridViewForm_TargetAccounts.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            DataGridViewForm_GeneralLedgerAccounts.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False, False)

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            'objects
            Dim ErrorMessage As String = ""

            If _ViewModel.SelectedGeneralLedgerMappingExportGLAccounts IsNot Nothing AndAlso _ViewModel.SelectedGeneralLedgerMappingExportGLAccounts.Count > 0 Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    If Not _Controller.DeleteDetail(_ViewModel, ErrorMessage) Then

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.GeneralLedgerAccountSelectionChanged(_ViewModel, DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow, DataGridViewForm_GeneralLedgerAccounts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount).ToList)

                    RefreshViewModel(False, True)

                End If

            End If

        End Sub
        Private Sub ButtonItemRecordSource_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemRecordSource_Manage.Click

            'objects
            Dim RecordSourceID As Integer = 0
            Dim IsOkay As Boolean = True

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.RecordSource, False, False, Title:="Manage Record Sources") = Windows.Forms.DialogResult.OK Then

                If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                    RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

                End If

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Loading, "Loading...")

                _Controller.LoadRecordSources(_ViewModel)

                ComboBoxRecordSource_RecordSource.DataSource = _ViewModel.RecordSources

                If RecordSourceID <> 0 Then

                    ComboBoxRecordSource_RecordSource.SelectedValue = RecordSourceID

                End If

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxRecordSource_RecordSource_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxRecordSource_RecordSource.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Loading, "Loading...")

                _Controller.SelectedRecordSourceChanged(_ViewModel, CInt(ComboBoxRecordSource_RecordSource.GetSelectedValue))

                RefreshViewModel(True, True)

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.InitNewRowEvent

            DataGridViewForm_TargetAccounts.CancelNewItemRow()
            DataGridViewForm_GeneralLedgerAccounts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount.Properties.SourceAccountID.ToString, _ViewModel.SelectedGeneralLedgerMappingExportTargetAccount.ID)

            _Controller.InitNewRowEvent(_ViewModel, True)

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_GeneralLedgerAccounts.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount.Properties.GeneralLedgerAccountCode.ToString Then

                Datasource = _ViewModel.RepositoryGeneralLedgerAccounts

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.SelectionChangedEvent

            _Controller.GeneralLedgerAccountSelectionChanged(_ViewModel, DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow, DataGridViewForm_GeneralLedgerAccounts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount).ToList)

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.ShowingEditorEvent

            'If DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow = False Then

            '    e.Cancel = True

            'End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(DirectCast(e.Row, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount), e.Valid)

                If DataGridViewForm_GeneralLedgerAccounts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_GeneralLedgerAccounts.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.ValidatingEditorEvent

            'objects
            Dim FocusedRow As Object = Nothing
            Dim ErrorText As String = Nothing

            FocusedRow = DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount Then

                ErrorText = _Controller.ValidateProperty(DirectCast(FocusedRow, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount), DataGridViewForm_GeneralLedgerAccounts.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewForm_GeneralLedgerAccounts.CurrentView.SetColumnError(DataGridViewForm_GeneralLedgerAccounts.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_TargetAccounts.InitNewRowEvent

            DataGridViewForm_GeneralLedgerAccounts.CancelNewItemRow()
            DataGridViewForm_TargetAccounts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount.Properties.RecordSourceID.ToString, _ViewModel.SelectedRecordSource.ID)

            _Controller.InitNewRowEvent(_ViewModel, False)

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_TargetAccounts.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.GeneralLedgerMappingExportTargetAccountSelectionChanged(_ViewModel, DataGridViewForm_TargetAccounts.IsNewItemRow, DataGridViewForm_TargetAccounts.GetRowDataBoundItem(DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle))

                RefreshViewModel(False, True)

                DataGridViewForm_GeneralLedgerAccounts.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TargetAccounts.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.GeneralLedgerMappingExportTargetAccountSelectionChanged(_ViewModel, DataGridViewForm_TargetAccounts.IsNewItemRow, DataGridViewForm_TargetAccounts.GetRowDataBoundItem(DataGridViewForm_TargetAccounts.CurrentView.FocusedRowHandle))

                RefreshViewModel(False, True)

                DataGridViewForm_GeneralLedgerAccounts.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_TargetAccounts.ShowingEditorEvent

            If DataGridViewForm_TargetAccounts.IsNewItemRow = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_TargetAccounts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(DirectCast(e.Row, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount), e.Valid)

                If DataGridViewForm_TargetAccounts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_TargetAccounts.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TargetAccounts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_TargetAccounts.ValidatingEditorEvent

            'objects
            Dim FocusedRow As Object = Nothing
            Dim ErrorText As String = Nothing

            FocusedRow = DataGridViewForm_TargetAccounts.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount Then

                ErrorText = _Controller.ValidateProperty(DirectCast(FocusedRow, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportTargetAccount), DataGridViewForm_TargetAccounts.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewForm_TargetAccounts.CurrentView.SetColumnError(DataGridViewForm_TargetAccounts.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_GeneralLedgerAccounts.QueryPopupNeedDatasourceEvent

            'objects
            Dim CurrentGLACode As String = ""

            If FieldName = AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount.Properties.GeneralLedgerAccountCode.ToString Then

                If DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow = False Then

                    CurrentGLACode = DirectCast(DataGridViewForm_GeneralLedgerAccounts.CurrentView.GetFocusedRow, AdvantageFramework.Database.Entities.GeneralLedgerMappingExportGLAccount).GeneralLedgerAccountCode

                End If

                Datasource = _ViewModel.AvailableGeneralLedgerAccounts(CurrentGLACode)
                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_GeneralLedgerAccounts_CellValueChangedEvent(sender As Object, e As CellValueChangedEventArgs) Handles DataGridViewForm_GeneralLedgerAccounts.CellValueChangedEvent

            If DataGridViewForm_GeneralLedgerAccounts.IsNewItemRow = False Then

                _Controller.GeneralLedgerAccountValueChanged(_ViewModel, e.Value)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace