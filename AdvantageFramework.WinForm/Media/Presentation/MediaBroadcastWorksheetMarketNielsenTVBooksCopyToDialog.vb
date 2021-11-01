Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketNielsenTVBooksCopyToViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.MarketNielsenTVBooksCopyTo_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID)

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Markets.DataSource = _ViewModel.CopyToMarkets

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_Markets.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.Selected.ToString Then

                    GridColumn.OptionsColumn.AllowEdit = True

                Else

                    GridColumn.OptionsColumn.AllowEdit = False

                End If

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.MediaBroadcastWorksheetMarketRadioEthnicityID.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_CopyTo.Enabled = _ViewModel.HasAtleastOneMarketSelected

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_Markets.OptionsBehavior.Editable = True

            DataGridViewForm_Markets.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_Markets.OptionsSelection.MultiSelect = False

            DataGridViewForm_Markets.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Protected Sub RepositoryItemCheckEdit_EditValueChanged(sender As Object, e As EventArgs)

            DataGridViewForm_Markets.CurrentView.PostEditor()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog As MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog = Nothing

            MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog = New MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_CopyTo.Image = AdvantageFramework.My.Resources.NielsenBookCopyToImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketNielsenTVBooksCopyToDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            RefreshViewModel()

            RibbonBarFilePanel_Actions.ResetCachedContentSize()

            RibbonBarFilePanel_Actions.Refresh()

            RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

            RibbonBarFilePanel_Actions.Refresh()

            Me.ClearChanged()

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_CopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_CopyTo.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

            If _ViewModel.HasAtleastOneMarketSelected Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.MarketNielsenTVBooksCopyTo_CopyTo(_ViewModel)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Markets_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Markets.CellValueChangedEvent

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.MarketCode.ToString Then

                Datasource = _ViewModel.Markets.ToList

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_SelectAllEvent() Handles DataGridViewForm_Markets.SelectAllEvent

            For RowHandle As Integer = 0 To DataGridViewForm_Markets.CurrentView.RowCount - 1

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.Selected.ToString, True)

            Next

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Markets_DeselectAllEvent() Handles DataGridViewForm_Markets.DeselectAllEvent

            For RowHandle As Integer = 0 To DataGridViewForm_Markets.CurrentView.RowCount - 1

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.Selected.ToString, False)

            Next

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Markets_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Markets.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenBookCopyTo.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanged, AddressOf RepositoryItemCheckEdit_EditValueChanged

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
