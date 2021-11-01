Namespace Media.Presentation

	Public Class MediaBroadcastWorksheetMarketNielsenTVBooksDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketNielsenTVBooksViewModel = Nothing
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

			_ViewModel = _Controller.MarketNielsenTVBooks_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID)

		End Sub
		Private Sub LoadGrid()

			DataGridViewForm_NielsenTVBooks.DataSource = _ViewModel.WorksheetNielsenTVBooks

		End Sub
		Private Sub FormatGrid()

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			For Each GridColumn In DataGridViewForm_NielsenTVBooks.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

				If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook.Properties.Selected.ToString Then

					GridColumn.OptionsColumn.AllowEdit = True

				Else

					GridColumn.OptionsColumn.AllowEdit = False

					If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook.Properties.NielsenTVBookID.ToString Then

						GridColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText

					End If

				End If

			Next

		End Sub
		Private Sub RefreshViewModel(LoadGrid As Boolean)

			If LoadGrid Then

				DataGridViewForm_NielsenTVBooks.CurrentView.RefreshData()

			End If

			ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
			ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

		End Sub
		Private Sub SetControlPropertySettings()

			DataGridViewForm_NielsenTVBooks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			DataGridViewForm_NielsenTVBooks.OptionsBehavior.Editable = True

			DataGridViewForm_NielsenTVBooks.OptionsDetail.EnableMasterViewMode = False
			DataGridViewForm_NielsenTVBooks.OptionsSelection.MultiSelect = True

			DataGridViewForm_NielsenTVBooks.ShowSelectDeselectAllButtons = True
			DataGridViewForm_NielsenTVBooks.OptionsFilter.AllowFilterEditor = True
			DataGridViewForm_NielsenTVBooks.OptionsFind.AlwaysVisible = True

			Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaBroadcastWorksheetMarketNielsenTVBooksDialog As MediaBroadcastWorksheetMarketNielsenTVBooksDialog = Nothing

			MediaBroadcastWorksheetMarketNielsenTVBooksDialog = New MediaBroadcastWorksheetMarketNielsenTVBooksDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID)

			ShowFormDialog = MediaBroadcastWorksheetMarketNielsenTVBooksDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaBroadcastWorksheetMarketNielsenTVBooksDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
			ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

			_Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub MediaBroadcastWorksheetMarketNielsenTVBooksDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

			LoadViewModel()

			LoadGrid()

			FormatGrid()

			RefreshViewModel(False)

			RibbonBarFilePanel_Actions.ResetCachedContentSize()

			RibbonBarFilePanel_Actions.Refresh()

			RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

			RibbonBarFilePanel_Actions.Refresh()

			Me.Text = _ViewModel.WorksheetMarket.MarketDescription & " Book Selection"

			Me.ClearChanged()

			DataGridViewForm_NielsenTVBooks.CurrentView.BestFitColumns()

			Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

			Me.CloseWaitForm()

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

			'objects
			Dim ErrorMessage As String = String.Empty

			If DataGridViewForm_NielsenTVBooks.HasASelectedRow Then

				DataGridViewForm_NielsenTVBooks.CurrentView.CloseEditorForUpdating()

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

				_Controller.MarketNielsenTVBooks_Add(_ViewModel)

				RefreshViewModel(True)

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			End If

		End Sub
		Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

			'objects
			Dim ErrorMessage As String = String.Empty

			If DataGridViewForm_NielsenTVBooks.HasASelectedRow Then

				DataGridViewForm_NielsenTVBooks.CurrentView.CloseEditorForUpdating()

				'If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

				_Controller.MarketNielsenTVBooks_Delete(_ViewModel)

				RefreshViewModel(True)

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

				'End If

			End If

		End Sub
		Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub DataGridViewForm_NielsenTVBooks_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_NielsenTVBooks.SelectionChangedEvent

			_Controller.MarketNielsenTVBooks_NielsenTVBookSelectionChanged(_ViewModel, DataGridViewForm_NielsenTVBooks.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook).ToList)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_NielsenTVBooks_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_NielsenTVBooks.ShowingEditorEvent

			If DataGridViewForm_NielsenTVBooks.HasMultipleSelectedRows Then

				e.Cancel = True

			End If

		End Sub
		Private Sub DataGridViewForm_NielsenTVBooks_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewForm_NielsenTVBooks.ColumnEditValueChangingEvent

			If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewForm_NielsenTVBooks.HasMultipleSelectedRows = False Then

				If e.NewValue = True Then

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

					_Controller.MarketNielsenTVBooks_Add(_ViewModel)

					RefreshViewModel(True)

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

				Else

					'If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

					_Controller.MarketNielsenTVBooks_Delete(_ViewModel)

					RefreshViewModel(True)

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

					'Else

					'	e.Cancel = True

					'End If

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_NielsenTVBooks_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_NielsenTVBooks.RepositoryDataSourceLoadingEvent

			If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook.Properties.NielsenTVBookID.ToString Then

				Datasource = _ViewModel.NielsenTVBooks.ToList

			End If

		End Sub
		Private Sub DataGridViewForm_NielsenTVBooks_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_NielsenTVBooks.CustomColumnDisplayTextEvent

			If e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenTVBook.Properties.Month.ToString Then

				e.DisplayText = MonthName(e.Value, True)

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
