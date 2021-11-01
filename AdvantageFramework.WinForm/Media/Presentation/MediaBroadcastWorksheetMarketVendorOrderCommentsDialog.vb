Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketVendorOrderCommentsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel,
                        ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel
            _MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetMarketDetailsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_OrderComments.DataSource = _ViewModel.WorksheetMarketVendorOrderCommentsList

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_OrderComments.CurrentView.RefreshData()

            End If

            ButtonItemActions_Update.Enabled = _ViewModel.UpdateEnabled
            ButtonItemCopyTo_CopyTo.Enabled = DataGridViewForm_OrderComments.HasOnlyOneSelectedRow

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_OrderComments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_OrderComments.OptionsBehavior.Editable = True

            DataGridViewForm_OrderComments.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_OrderComments.OptionsSelection.MultiSelect = False

            DataGridViewForm_OrderComments.ShowSelectDeselectAllButtons = False
            DataGridViewForm_OrderComments.SelectRowsWhenSelectDeselectAllButtonClicked = False

            DataGridViewForm_OrderComments.ItemDescription = "Order Comment(s)"

            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketVendorOrderCommentsDialog As MediaBroadcastWorksheetMarketVendorOrderCommentsDialog = Nothing

            MediaBroadcastWorksheetMarketVendorOrderCommentsDialog = New MediaBroadcastWorksheetMarketVendorOrderCommentsDialog(MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketVendorOrderCommentsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemCopyTo_CopyTo.Image = AdvantageFramework.My.Resources.CopyImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_OrderComments.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketVendorOrderComments_UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketVendorOrderCommentsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.MarketVendorOrderComments_ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Update.Click

            If DataGridViewForm_OrderComments.CurrentView.PostEditor() Then

                DataGridViewForm_OrderComments.CurrentView.UpdateCurrentRow()

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemCopyTo_CopyTo_Click(sender As Object, e As EventArgs) Handles ButtonItemCopyTo_CopyTo.Click

            'objects
            Dim CopyFromVendorCode As String = String.Empty

            If DataGridViewForm_OrderComments.CurrentView.PostEditor() Then

                DataGridViewForm_OrderComments.CurrentView.UpdateCurrentRow()

            End If

            If DataGridViewForm_OrderComments.HasOnlyOneSelectedRow Then

                CopyFromVendorCode = DataGridViewForm_OrderComments.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorOrderComments.Properties.VendorCode.ToString)

                If String.IsNullOrWhiteSpace(CopyFromVendorCode) = False Then

                    If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorDialog.ShowFormDialog(_ViewModel, CopyFromVendorCode) = Windows.Forms.DialogResult.OK Then

                        RefreshViewModel(True)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_OrderComments_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_OrderComments.FocusedRowChangedEvent

            RefreshViewModel(False)

        End Sub

#End Region

#End Region

    End Class

End Namespace