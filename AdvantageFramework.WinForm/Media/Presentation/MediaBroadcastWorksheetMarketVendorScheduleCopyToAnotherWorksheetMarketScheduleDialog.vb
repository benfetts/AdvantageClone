Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel,
                        ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel
            _MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Worksheet.DataSource = _ViewModel.Worksheets

        End Sub
        Private Sub LoadWorksheetMarketsGrid()

            DataGridViewForm_Markets.DataSource = _ViewModel.WorksheetMarketVendorWorksheetMarketScheduleCopyTos

        End Sub
        Private Sub FormatWorksheetMarketsGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewForm_Markets.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                    GridColumn.Visible = (_ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio)

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo.Properties.IsCable.ToString Then

                    GridColumn.Visible = (_ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV)

                End If

            Next

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString) IsNot Nothing AndAlso
                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).Visible Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_GetRepositoryMarketRadioEthnicity(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Markets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Worksheet.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Worksheet.OptionsBehavior.Editable = False

            DataGridViewForm_Worksheet.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Worksheet.OptionsSelection.MultiSelect = False

            DataGridViewForm_Worksheet.ShowSelectDeselectAllButtons = False
            DataGridViewForm_Worksheet.SelectRowsWhenSelectDeselectAllButtonClicked = False
            DataGridViewForm_Worksheet.FocusToFindPanel(False)

            DataGridViewForm_Worksheet.ItemDescription = "Worksheet(s)"

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Markets.OptionsBehavior.Editable = True

            DataGridViewForm_Markets.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Markets.OptionsSelection.MultiSelect = True

            DataGridViewForm_Markets.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = False
            DataGridViewForm_Markets.FocusToFindPanel(False)

            DataGridViewForm_Markets.ItemDescription = "Market(s)"

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub RepositoryItemSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorWorksheetMarketScheduleCopyTo).Selected = e.NewValue

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

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog As MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog = Nothing

            MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog = New MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog(MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleViewModel, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemOptions_CopySpots.Image = AdvantageFramework.My.Resources.DateTimeImage
            ButtonItemOptions_CopyRates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketVendorScheduleCopyToAnotherWorksheetMarketScheduleDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            LoadWorksheetMarketsGrid()

            FormatWorksheetMarketsGrid()

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

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
        Private Sub DataGridViewForm_Worksheet_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Worksheet.FocusedRowChangedEvent

            _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_WorksheetSelectionChanged(_ViewModel, DataGridViewForm_Worksheet.CurrentView.GetFocusedRow)

            _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_LoadWorksheetMarkets(_ViewModel)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Worksheet_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Worksheet.RowCountChangedEvent

            DataGridViewForm_Worksheet.GridViewSelectionChanged()

        End Sub
        Private Sub DataGridViewForm_Markets_SelectAllEvent() Handles DataGridViewForm_Markets.SelectAllEvent

            _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_SelectDeselectAll(_ViewModel, True)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Markets_DeselectAllEvent() Handles DataGridViewForm_Markets.DeselectAllEvent

            _Controller.MarketVendorScheduleCopyToAnotherWorksheetMarketSchedule_SelectDeselectAll(_ViewModel, False)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorScheduleCopyTo.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemSelected_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemSelected_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
