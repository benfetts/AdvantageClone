Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketManageVendorsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketManageVendorsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0
        Protected _RevisionNumber As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer, RevisionNumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
            _RevisionNumber = RevisionNumber

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketManageVendors_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID, _RevisionNumber)

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketDetailVendors

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_Vendors.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                    GridColumn.Visible = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketCode.ToString Then

                        If _ViewModel.IsCanadianWorksheet Then

                            GridColumn.Visible = False

                        Else

                            GridColumn.Visible = True

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketDescription.ToString Then

                        If _ViewModel.IsCanadianWorksheet Then

                            GridColumn.Visible = False

                        Else

                            GridColumn.Visible = True

                        End If

                    End If

                End If

            Next

            If _ViewModel.IsCanadianWorksheet = False AndAlso DataGridViewForm_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketCode.ToString) IsNot Nothing Then

                GridColumn = DataGridViewForm_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketCode.ToString)

                DataGridViewForm_Vendors.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketCode.ToString).FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(GridColumn, CType(_ViewModel.WorksheetMarket.MarketCode, Object))

            End If

        End Sub
        'Private Sub AddSubItemGridLookupToStationIDColumn()

        '    Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        '    Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

        '    SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

        '    'SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
        '    SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
        '    'SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
        '    SubItemGridLookUpEditControl.DisplayMember = "Name"
        '    SubItemGridLookUpEditControl.ValueMember = "ID"

        '    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
        '    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("CallLetters"))
        '    SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

        '    BindingSource = New System.Windows.Forms.BindingSource

        '    BindingSource.DataSource = _ViewModel.Stations.Select(Function(Entity) New With {.ID = Entity.ID, .CallLetters = Entity.CallLetters, .Name = Entity.Name}).ToList

        '    SubItemGridLookUpEditControl.DataSource = BindingSource

        '    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Name", "ID", "[None]", "0", True, False, Nothing)

        '    AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup

        '    AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf SubItemGridLookUpEditControl_EditValueChanging

        '    DataGridViewForm_Vendors.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

        '    DataGridViewForm_Vendors.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.StationID.ToString).ColumnEdit = SubItemGridLookUpEditControl

        'End Sub
        'Protected Sub SubItemGridLookUpEditControl_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

        '    'objects
        '    Dim ErrorMessage As String = String.Empty
        '    Dim Selected As Boolean = False
        '    Dim VendorCode As String = String.Empty
        '    Dim StationID As Integer = 0

        '    Try

        '        StationID = e.NewValue

        '    Catch ex As Exception
        '        StationID = 0
        '    End Try

        '    VendorCode = DataGridViewForm_Vendors.CurrentView.GetRowCellValue(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.VendorCode.ToString)

        '    Selected = DataGridViewForm_Vendors.CurrentView.GetRowCellValue(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.Selected.ToString)

        '    If Selected Then

        '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

        '        If _Controller.MarketManageVendors_StationIDChangedForSelected(_ViewModel, VendorCode, StationID, ErrorMessage) Then

        '            '_Controller.MarketManageVendors_StationIDChanged(_ViewModel, VendorCode, StationID)

        '        End If

        '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '    Else

        '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

        '        _Controller.MarketManageVendors_StationIDChanged(_ViewModel, VendorCode, StationID)

        '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        '    End If

        '    DataGridViewForm_Vendors.CurrentView.RefreshData()

        'End Sub
        'Protected Sub SubItemGridLookUpEditControl_QueryPopup(sender As Object, e As System.ComponentModel.CancelEventArgs)

        '    'objects
        '    Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
        '    Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
        '    Dim VendorCode As String = String.Empty
        '    Dim Stations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Station) = Nothing
        '    Dim Station As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Station = Nothing

        '    If TypeOf DataGridViewForm_Vendors.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

        '        GridLookUpEdit = DataGridViewForm_Vendors.CurrentView.ActiveEditor

        '        VendorCode = DataGridViewForm_Vendors.CurrentView.GetRowCellValue(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.VendorCode.ToString)

        '        BindingSource = New System.Windows.Forms.BindingSource

        '        BindingSource.DataSource = _Controller.MarketManageVendors_LoadStations(_ViewModel, VendorCode).Select(Function(Entity) New With {.ID = Entity.ID, .CallLetters = Entity.CallLetters, .Name = Entity.Name}).ToList

        '        GridLookUpEdit.Properties.DataSource = BindingSource

        '        AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Name", "ID", "[None]", "0", True, False, Nothing)

        '    End If

        'End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Vendors.CurrentView.RefreshData()

            End If

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Vendors.OptionsBehavior.Editable = True

            DataGridViewForm_Vendors.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Vendors.OptionsSelection.MultiSelect = True

            DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Vendors.FocusToFindPanel(False)

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer, RevisionNumber As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketManageVendorsDialog As MediaBroadcastWorksheetMarketManageVendorsDialog = Nothing

            MediaBroadcastWorksheetMarketManageVendorsDialog = New MediaBroadcastWorksheetMarketManageVendorsDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID, RevisionNumber)

            ShowFormDialog = MediaBroadcastWorksheetMarketManageVendorsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketManageVendorsDialog_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            If Me.DialogResult = System.Windows.Forms.DialogResult.Cancel AndAlso _ViewModel.HasVendorsBeenModified Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketManageVendorsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketManageVendorsDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            RefreshViewModel(False)

            RibbonBarFilePanel_Actions.ResetCachedContentSize()

            RibbonBarFilePanel_Actions.Refresh()

            RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

            RibbonBarFilePanel_Actions.Refresh()

            Me.ClearChanged()

            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewForm_Vendors.HasASelectedRow Then

                DataGridViewForm_Vendors.CurrentView.CloseEditorForUpdating()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.MarketManageVendors_Add(_ViewModel, ErrorMessage)

                RefreshViewModel(True)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewForm_Vendors.HasASelectedRow Then

                DataGridViewForm_Vendors.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Deleting vendors will also delete the lines in the market schedule." & System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.MarketManageVendors_Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Vendors.SelectionChangedEvent

            _Controller.MarketManageVendors_VendorSelectionChanged(_ViewModel, DataGridViewForm_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor).ToList)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewForm_Vendors_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Vendors.ShowingEditorEvent

            If DataGridViewForm_Vendors.HasMultipleSelectedRows Then

                e.Cancel = True

            Else

                If CType(DataGridViewForm_Vendors.CurrentView.GetFocusedRow, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor).HasOrders Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Vendors_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewForm_Vendors.ColumnEditValueChangingEvent

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Selected As Boolean = False
            Dim VendorCode As String = String.Empty
            Dim StationID As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewForm_Vendors.HasMultipleSelectedRows = False Then

                If DataGridViewForm_Vendors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.Selected.ToString Then

                    If e.NewValue = True Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                        _Controller.MarketManageVendors_Add(_ViewModel, ErrorMessage)

                        RefreshViewModel(True)

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Else

                        If AdvantageFramework.WinForm.MessageBox.Show("Deleting vendors will also delete the lines in the market schedule." & System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                            If _Controller.MarketManageVendors_Delete(_ViewModel, ErrorMessage) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                            End If

                            RefreshViewModel(True)

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Else

                            e.Cancel = True

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace