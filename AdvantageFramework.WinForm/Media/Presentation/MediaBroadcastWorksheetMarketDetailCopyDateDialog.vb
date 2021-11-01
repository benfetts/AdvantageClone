Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailCopyDateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsCopyDateViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketDetailsCopyDateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsCopyDateViewModel,
                        ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketDetailsCopyDateViewModel
            _MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketVendorDateCopyList
            DataGridViewForm_Weeks.DataSource = _ViewModel.WorksheetMarketDetailDateCopyList

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_Vendors.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorDateCopy.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

            For Each GridColumn In DataGridViewForm_Weeks.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy.Properties.DateColumnCaption.ToString Then

                    GridColumn.Caption = _ViewModel.DateColumnCaption

                End If

            Next

            DataGridViewForm_Weeks.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy.Properties.DateColumnName.ToString)

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Vendors.CurrentView.RefreshData()
                DataGridViewForm_Weeks.CurrentView.RefreshData()

            End If

            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Vendors.OptionsBehavior.Editable = True

            DataGridViewForm_Vendors.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Vendors.OptionsSelection.MultiSelect = True

            DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = False

            DataGridViewForm_Weeks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Weeks.OptionsBehavior.Editable = True

            DataGridViewForm_Weeks.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Weeks.OptionsSelection.MultiSelect = True

            DataGridViewForm_Weeks.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Weeks.SelectRowsWhenSelectDeselectAllButtonClicked = False

            DataGridViewForm_Weeks.ItemDescription = _ViewModel.DateColumnCaption & "(s)"

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub RepositoryItemVendorSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorDateCopy).Selected = e.NewValue

            RefreshViewModel(True)

        End Sub
        Private Sub RepositoryItemDateSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            DirectCast(DataGridViewForm_Weeks.CurrentView.GetRow(DataGridViewForm_Weeks.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy).Selected = e.NewValue

            RefreshViewModel(True)

        End Sub
        Private Sub RepositoryItemSelected_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

            'objects
            Dim CheckEdit As DevExpress.XtraEditors.CheckEdit = Nothing
            Dim CheckEditViewInfo As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim EditorRectangle As System.Drawing.Rectangle = Nothing

            CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
            CheckEditViewInfo = CType(CheckEdit.GetViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
            Rectangle = CheckEditViewInfo.CheckInfo.GlyphRect

            EditorRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), CheckEdit.Size)

            If (Not Rectangle.Contains(e.Location)) AndAlso EditorRectangle.Contains(e.Location) Then

                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketDetailsCopyDateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsCopyDateViewModel,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketDetailCopyDateDialog As MediaBroadcastWorksheetMarketDetailCopyDateDialog = Nothing

            MediaBroadcastWorksheetMarketDetailCopyDateDialog = New MediaBroadcastWorksheetMarketDetailCopyDateDialog(MediaBroadcastWorksheetMarketDetailsCopyDateViewModel, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketDetailCopyDateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailCopyDateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemOptions_CopySpots.Image = AdvantageFramework.My.Resources.DateTimeImage
            ButtonItemOptions_CopyRates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailCopyDateDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            FormatGrid()

            RefreshViewModel(False)

            ButtonItemOptions_CopySpots.Checked = _ViewModel.CopySpots
            ButtonItemOptions_CopyRates.Checked = _ViewModel.CopyRates

            Me.ClearChanged()

            DataGridViewForm_Weeks.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            _ViewModel.CopySpots = ButtonItemOptions_CopySpots.Checked
            _ViewModel.CopyRates = ButtonItemOptions_CopyRates.Checked

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Vendors_SelectAllEvent() Handles DataGridViewForm_Vendors.SelectAllEvent

            _Controller.MarketDetailsCopyDate_VendorSelectDeselectAll(_ViewModel, True)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Vendors_DeselectAllEvent() Handles DataGridViewForm_Vendors.DeselectAllEvent

            _Controller.MarketDetailsCopyDate_VendorSelectDeselectAll(_ViewModel, False)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Vendors_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Weeks.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorDateCopy.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemVendorSelected_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemSelected_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub
        Private Sub DataGridViewForm_Weeks_SelectAllEvent() Handles DataGridViewForm_Weeks.SelectAllEvent

            _Controller.MarketDetailsCopyDate_DateSelectDeselectAll(_ViewModel, True)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Weeks_DeselectAllEvent() Handles DataGridViewForm_Weeks.DeselectAllEvent

            _Controller.MarketDetailsCopyDate_DateSelectDeselectAll(_ViewModel, False)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Weeks_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Weeks.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateCopy.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemDateSelected_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemSelected_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace