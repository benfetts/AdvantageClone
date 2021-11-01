Namespace Maintenance.Accounting.Views

	Public Class DepartmentTeamSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.DepartmentTeamSetupViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New()

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.

		End Sub
		Private Sub RefreshViewModel(LoadGrid As Boolean)

			If LoadGrid Then

				DataGridViewForm_DepartmentTeam.CurrentView.RefreshData()

			End If

			ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
			ButtonItemActions_Save.Enabled = If(_ViewModel.IsNewRow, False, Me.UserEntryChanged)
			ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled

		End Sub

#Region "  Show Form Methods "

		Public Shared Sub ShowForm()

			'objects
			Dim DepartmentTeamSetupForm As Maintenance.Accounting.Views.DepartmentTeamSetupForm = Nothing

			DepartmentTeamSetupForm = New Maintenance.Accounting.Views.DepartmentTeamSetupForm()

			DepartmentTeamSetupForm.Show()

		End Sub

#End Region

#Region "  Form Event Handlers "

		Private Sub DepartmentTeamSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
			ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
			ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
			ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

			_Controller = New AdvantageFramework.Controller.Maintenance.Accounting.DepartmentTeamSetupController(Me.Session)

			_ViewModel = _Controller.Load()

		End Sub
		Private Sub DepartmentTeamSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			DataGridViewForm_DepartmentTeam.DataSource = _ViewModel.DepartmentTeams

			RefreshViewModel(True)

			DataGridViewForm_DepartmentTeam.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

			DataGridViewForm_DepartmentTeam.CurrentView.BestFitColumns()

		End Sub
		Private Sub DepartmentTeamSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

			ButtonItemActions_Save.Enabled = Me.UserEntryChanged

		End Sub
		Private Sub DepartmentTeamSetupForm_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

			ButtonItemActions_Save.Enabled = Me.UserEntryChanged

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

			DataGridViewForm_DepartmentTeam.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

		End Sub
		Private Sub ButtonItemActions_Save_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

			'objects
			Dim DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing

			If DataGridViewForm_DepartmentTeam.HasRows Then

				DataGridViewForm_DepartmentTeam.CurrentView.CloseEditorForUpdating()

				DepartmentTeams = DataGridViewForm_DepartmentTeam.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DepartmentTeam)().ToList

				Me.ShowWaitForm()
				Me.ShowWaitForm("Saving...")
				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

				Try

					_Controller.Save(_ViewModel)

				Catch ex As Exception

				End Try

				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

				Try

					DataGridViewForm_DepartmentTeam.ValidateAllRowsAndClearChanged(True)

				Catch ex As Exception

				End Try

				Me.CloseWaitForm()

			End If

		End Sub
		Private Sub ButtonItemActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

			'objects
			Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
			Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

			If DataGridViewForm_DepartmentTeam.HasASelectedRow Then

				DataGridViewForm_DepartmentTeam.CurrentView.CloseEditorForUpdating()

				If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

					Try

						_Controller.Delete(_ViewModel)

					Catch ex As Exception

					End Try

					RefreshViewModel(True)

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

					If DataGridViewForm_DepartmentTeam.CheckForModifiedRows = False Then

						Me.ClearChanged()

					End If

				End If

			End If

		End Sub
		Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

			DataGridViewForm_DepartmentTeam.CancelNewItemRow()

			_Controller.CancelNewItemRow(_ViewModel)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_DepartmentTeam_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_DepartmentTeam.InitNewRowEvent

			_Controller.InitNewRowEvent(_ViewModel)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_DepartmentTeam_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_DepartmentTeam.AddNewRowEvent

			If TypeOf RowObject Is AdvantageFramework.Database.Entities.DepartmentTeam Then

				Me.ShowWaitForm("Processing...")

				_Controller.Add(_ViewModel, RowObject)

				DataGridViewForm_DepartmentTeam.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
				DataGridViewForm_DepartmentTeam.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

				RefreshViewModel(False)

				Me.CloseWaitForm()

			End If

		End Sub
		Private Sub DataGridViewForm_DepartmentTeam_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_DepartmentTeam.CellValueChangingEvent

			'objects
			Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

			If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso
					e.Column.FieldName = AdvantageFramework.Database.Entities.DepartmentTeam.Properties.IsInactive.ToString Then

				Try

					DepartmentTeam = DataGridViewForm_DepartmentTeam.GetFirstSelectedRowDataBoundItem

				Catch ex As Exception
					DepartmentTeam = Nothing
				End Try

				If DepartmentTeam IsNot Nothing Then

					Saved = _Controller.UpdateInactiveFlag(DepartmentTeam, e.Value)

					RefreshViewModel(Saved)

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_DepartmentTeam_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_DepartmentTeam.SelectionChangedEvent

			_Controller.DepartmentTeamSelectionChanged(_ViewModel, DataGridViewForm_DepartmentTeam.IsNewItemRow,
													   DataGridViewForm_DepartmentTeam.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DepartmentTeam).ToList)

			RefreshViewModel(False)

		End Sub

#End Region

#End Region

	End Class

End Namespace