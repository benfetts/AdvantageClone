Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketGoalsCopyFromDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsCopyFromViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketGoalsCopyFromViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsCopyFromViewModel,
                        MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketGoalsCopyFromViewModel
            _MediaBroadcastWorksheetMarketGoalsViewModel = MediaBroadcastWorksheetMarketGoalsViewModel

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Markets.DataSource = _ViewModel.CopyFromMarkets

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewForm_Markets.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                    GridColumn.Visible = (_ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio)

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.IsCable.ToString Then

                    GridColumn.Visible = (_ViewModel.Worksheet.MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV)

                End If

            Next

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString) IsNot Nothing AndAlso
                    DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).Visible Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing
                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Name"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                SubItemGridLookUpEditControl.DataSource = _Controller.MarketGoalsCopyFrom_GetRepositoryMarketRadioEthnicity(_ViewModel)

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewForm_Markets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Markets.OptionsBehavior.Editable = True

            DataGridViewForm_Markets.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Markets.OptionsSelection.MultiSelect = False

            DataGridViewForm_Markets.ShowSelectDeselectAllButtons = False
            DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub RepositoryItemSelected_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            For Each WorksheetMarketGoalsCopy In _ViewModel.CopyFromMarkets

                If WorksheetMarketGoalsCopy Is DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle) Then

                    WorksheetMarketGoalsCopy.Selected = e.NewValue

                Else

                    WorksheetMarketGoalsCopy.Selected = False

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

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketGoalsCopyFromViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsCopyFromViewModel,
                                              MediaBroadcastWorksheetMarketGoalsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketGoalsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketGoalsCopyFromDialog As MediaBroadcastWorksheetMarketGoalsCopyFromDialog = Nothing

            MediaBroadcastWorksheetMarketGoalsCopyFromDialog = New MediaBroadcastWorksheetMarketGoalsCopyFromDialog(MediaBroadcastWorksheetMarketGoalsCopyFromViewModel, MediaBroadcastWorksheetMarketGoalsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketGoalsCopyFromDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketGoalsCopyFromDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketGoalsCopyFromDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadGrid()

            FormatGrid()

            RefreshViewModel(False)

            Me.ClearChanged()

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Markets_SelectAllEvent() Handles DataGridViewForm_Markets.SelectAllEvent

            _Controller.MarketGoalsCopyFrom_SelectDeselectAll(_ViewModel, True)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Markets_DeselectAllEvent() Handles DataGridViewForm_Markets.DeselectAllEvent

            _Controller.MarketGoalsCopyFrom_SelectDeselectAll(_ViewModel, False)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketGoalsCopy.Properties.Selected.ToString Then

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
