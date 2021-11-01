Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel,
                        MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel
            _MediaBroadcastWorksheetMarketGoalsViewModel = MediaBroadcastWorksheetMarketGoalsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_MediaPlanEstimates.DataSource = _ViewModel.WorksheetMarketGoalsMediaPlanEstimates

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewForm_MediaPlanEstimates.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsMediaPlanEstimate.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

            Next

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_MediaPlanEstimates.CurrentView.RefreshData()

            End If

            ButtonItemActions_Select.Enabled = _ViewModel.SelectEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_MediaPlanEstimates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_MediaPlanEstimates.OptionsBehavior.Editable = True

            DataGridViewForm_MediaPlanEstimates.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_MediaPlanEstimates.OptionsSelection.MultiSelect = False

            DataGridViewForm_MediaPlanEstimates.ShowSelectDeselectAllButtons = False
            DataGridViewForm_MediaPlanEstimates.SelectRowsWhenSelectDeselectAllButtonClicked = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub RepositoryItemSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            For Each WorksheetMarketGoalsMediaPlanEstimate In _ViewModel.WorksheetMarketGoalsMediaPlanEstimates

                If WorksheetMarketGoalsMediaPlanEstimate Is DataGridViewForm_MediaPlanEstimates.CurrentView.GetRow(DataGridViewForm_MediaPlanEstimates.CurrentView.FocusedRowHandle) Then

                    WorksheetMarketGoalsMediaPlanEstimate.Selected = e.NewValue

                Else

                    WorksheetMarketGoalsMediaPlanEstimate.Selected = False

                End If

            Next

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

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel,
                                              MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog As MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog = Nothing

            MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog = New MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog(MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateViewModel, MediaBroadcastWorksheetMarketGoalsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Select.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalsSelectMediaPlanEstimateDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            FormatGrid()

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_MediaPlanEstimates.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Select_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Select.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_MediaPlanEstimates.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsMediaPlanEstimate.Properties.Selected.ToString Then

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
