Namespace Media.Presentation

	Public Class MediaBroadcastWorksheetMarketRevisionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketRevisionsViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
		Protected _MediaBroadcastWorksheetID As Integer = 0
		Protected _MediaBroadcastWorksheetMarketID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer)

			' This call is required by the Windows Form Designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
			_MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

		End Sub
		Private Sub LoadViewModel()

			_ViewModel = _Controller.MarketRevisions_Load(_MediaBroadcastWorksheetID, _MediaBroadcastWorksheetMarketID)

		End Sub
		Private Sub LoadGrid()

			DataGridViewForm_Revisions.DataSource = _ViewModel.WorksheetMarketRevisions

		End Sub
		Private Sub FormatGrid()

			For Each GridColumn In DataGridViewForm_Revisions.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

				GridColumn.Visible = False

			Next

			DataGridViewForm_Revisions.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketRevision.Properties.Comment.ToString).Visible = True
			DataGridViewForm_Revisions.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketRevision.Properties.CreatedDate.ToString).Visible = True
			DataGridViewForm_Revisions.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketRevision.Properties.CreatedByUserCode.ToString).Visible = True
			DataGridViewForm_Revisions.Columns(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketRevision.Properties.RevisionNumber.ToString).Visible = True

		End Sub
		Private Sub RefreshViewModel()

			ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
			ButtonItemActions_Cancel.Enabled = _ViewModel.SaveEnabled

		End Sub
		Private Sub SetControlPropertySettings()

			DataGridViewForm_Revisions.SetupForEditableGrid()

			DataGridViewForm_Revisions.MultiSelect = False

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaBroadcastWorksheetMarketRevisionsDialog As Media.Presentation.MediaBroadcastWorksheetMarketRevisionsDialog = Nothing

			MediaBroadcastWorksheetMarketRevisionsDialog = New Media.Presentation.MediaBroadcastWorksheetMarketRevisionsDialog(MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketID)

			ShowFormDialog = MediaBroadcastWorksheetMarketRevisionsDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaBroadcastWorksheetMarketRevisionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
			ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

			_Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub MediaBroadcastWorksheetMarketRevisionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

			LoadViewModel()

			DataGridViewForm_Revisions.CurrentView.BeginUpdate()

			LoadGrid()

			FormatGrid()

			RefreshViewModel()

			DataGridViewForm_Revisions.CurrentView.EndUpdate()

			DataGridViewForm_Revisions.CurrentView.BestFitColumns()

			Me.ClearChanged()

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

		End Sub
		Private Sub MediaBroadcastWorksheetMarketRevisionsDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

			If _ViewModel IsNot Nothing Then

				_Controller.MarketRevisions_UserEntryChanged(_ViewModel)

				RefreshViewModel()

			End If

		End Sub
		Private Sub MediaBroadcastWorksheetMarketRevisionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

			If _ViewModel IsNot Nothing Then

				_Controller.MarketRevisions_ClearChanged(_ViewModel)

				RefreshViewModel()

			End If

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

			Me.DialogResult = Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

			If DataGridViewForm_Revisions.CurrentView.PostEditor() Then

				DataGridViewForm_Revisions.CurrentView.UpdateCurrentRow()

			End If

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

			_Controller.MarketRevisions_Save(_ViewModel)

			RefreshViewModel()

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			Me.ClearChanged()

			Me.RaiseClearChanged()

		End Sub
		Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

			If DataGridViewForm_Revisions.CurrentView.PostEditor() Then

				DataGridViewForm_Revisions.CurrentView.UpdateCurrentRow()

			End If

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

			_Controller.MarketRevisions_LoadWorksheetMarketRevisions(_ViewModel)

			LoadGrid()

			_Controller.MarketRevisions_ClearChanged(_ViewModel)

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			RefreshViewModel()

			Me.ClearChanged()

			Me.RaiseClearChanged()

		End Sub

#End Region

#End Region

	End Class

End Namespace