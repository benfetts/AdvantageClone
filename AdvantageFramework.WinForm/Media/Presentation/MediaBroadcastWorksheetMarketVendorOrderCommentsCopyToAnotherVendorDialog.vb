Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel = Nothing
        Protected _CopyFromVendorCode As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel,
                        CopyFromVendorCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel = MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel
            _CopyFromVendorCode = CopyFromVendorCode

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketVendorOrderCommentsCopyToAnotherVendor_Load(_MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel, _CopyFromVendorCode)

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

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

            DataGridViewForm_Vendors.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.HasOrders.ToString)
            DataGridViewForm_Vendors.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketCode.ToString)
            DataGridViewForm_Vendors.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.MarketDescription.ToString)
            DataGridViewForm_Vendors.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.VendorCategory.ToString)
            DataGridViewForm_Vendors.MakeColumnNotVisible(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.IsInactive.ToString)

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Vendors.CurrentView.RefreshData()

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
            DataGridViewForm_Vendors.FocusToFindPanel(False)

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub RepositoryItemSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            DirectCast(DataGridViewForm_Vendors.CurrentView.GetRow(DataGridViewForm_Vendors.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor).Selected = e.NewValue

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

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel,
                                              CopyFromVendorCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog As MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog = Nothing

            MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog = New MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog(MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel, CopyFromVendorCode)

            ShowFormDialog = MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            _Controller.MarketVendorOrderCommentsCopyToAnotherVendor_CopyTo(_ViewModel, _MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Vendors_SelectAllEvent() Handles DataGridViewForm_Vendors.SelectAllEvent

            _Controller.MarketVendorOrderCommentsCopyToAnotherVendor_SelectDeselectAll(_ViewModel, True)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Vendors_DeselectAllEvent() Handles DataGridViewForm_Vendors.DeselectAllEvent

            _Controller.MarketVendorOrderCommentsCopyToAnotherVendor_SelectDeselectAll(_ViewModel, False)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Vendors_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Vendors.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor.Properties.Selected.ToString Then

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