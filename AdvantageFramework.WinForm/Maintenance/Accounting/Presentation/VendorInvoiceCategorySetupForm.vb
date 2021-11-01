Namespace Maintenance.Accounting.Presentation

	Public Class VendorInvoiceCategorySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel = Nothing
		Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.VendorInvoiceCategoryController = Nothing


#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New()

			' This call is required by the designer.
			InitializeComponent()

		End Sub
		Private Sub LoadViewModel()

			_ViewModel = _Controller.Load()

		End Sub
		Private Sub LoadGrid()

			DataGridViewForm_VendorInvoiceCategory.DataSource = _ViewModel.VendorInvoiceCategories

		End Sub
		Private Sub RefreshViewModel(LoadGrid As Boolean)

			If LoadGrid Then

				DataGridViewForm_VendorInvoiceCategory.CurrentView.RefreshData()

			End If

			ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
			ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
			ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

		End Sub
		Private Sub SetControlPropertySettings()

			DataGridViewForm_VendorInvoiceCategory.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
			DataGridViewForm_VendorInvoiceCategory.SetupForEditableGrid()

			DataGridViewForm_VendorInvoiceCategory.OptionsView.ColumnAutoWidth = True
			DataGridViewForm_VendorInvoiceCategory.OptionsCustomization.AllowColumnMoving = False
			DataGridViewForm_VendorInvoiceCategory.OptionsCustomization.AllowQuickHideColumns = False
			DataGridViewForm_VendorInvoiceCategory.OptionsMenu.EnableColumnMenu = False

			DataGridViewForm_VendorInvoiceCategory.OptionsDetail.EnableMasterViewMode = False

		End Sub
		Private Sub AddNewRow(VendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory)

			Dim ErrorMessage As String = Nothing

			If VendorInvoiceCategory IsNot Nothing Then

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

				If _Controller.Add(_ViewModel, VendorInvoiceCategory, ErrorMessage) = False Then

					AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

				Else

					DataGridViewForm_VendorInvoiceCategory.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
					DataGridViewForm_VendorInvoiceCategory.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

					RefreshViewModel(True)

				End If

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

			End If

		End Sub

#Region "  Show Form Methods "

		Public Shared Sub ShowForm()

			'objects
			Dim VendorServiceTaxSetupForm As VendorInvoiceCategorySetupForm = Nothing

			VendorServiceTaxSetupForm = New VendorInvoiceCategorySetupForm()

			VendorServiceTaxSetupForm.Show()

		End Sub

#End Region

#Region "  Form Event Handlers "

		Private Sub VendorInvoiceCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
			ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
			ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

			_Controller = New AdvantageFramework.Controller.Maintenance.Accounting.VendorInvoiceCategoryController(Me.Session)

			SetControlPropertySettings()

		End Sub
		Private Sub VendorInvoiceCategorySetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

			Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading)

			LoadViewModel()

			LoadGrid()

			RefreshViewModel(False)

			Me.ClearChanged()

			DataGridViewForm_VendorInvoiceCategory.CurrentView.BestFitColumns()

			Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

			Me.CloseWaitForm()

		End Sub
		Private Sub VendorInvoiceCategorySetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

			If _ViewModel IsNot Nothing Then

				_Controller.UserEntryChanged(_ViewModel)

				RefreshViewModel(False)

			End If

		End Sub
		Private Sub VendorInvoiceCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

			If _ViewModel IsNot Nothing Then

				_Controller.ClearChanged(_ViewModel)

				RefreshViewModel(False)

			End If

		End Sub


#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

			DataGridViewForm_VendorInvoiceCategory.CurrentView.CloseEditorForUpdating()

			If _ViewModel.VendorInvoiceCategories.Any(Function(Entity) Entity.HasError) = False Then

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

				_Controller.Save(_ViewModel)

				RefreshViewModel(False)

				Me.ClearChanged()

				Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

			Else

				AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before saving.")

			End If

		End Sub
		Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

			'objects
			Dim ErrorMessage As String = String.Empty

			If DataGridViewForm_VendorInvoiceCategory.HasASelectedRow Then

				DataGridViewForm_VendorInvoiceCategory.CurrentView.CloseEditorForUpdating()

				If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

					If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

						AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

					End If

					RefreshViewModel(True)

					Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

					_Controller.SelectionChanged(_ViewModel, DataGridViewForm_VendorInvoiceCategory.IsNewItemRow, DataGridViewForm_VendorInvoiceCategory.GetFirstSelectedRowDataBoundItem)

				End If

			End If

		End Sub
		Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

			DataGridViewForm_VendorInvoiceCategory.CancelNewItemRow()

			_Controller.CancelNewItemRow(_ViewModel)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_VendorInvoiceCategory_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_VendorInvoiceCategory.FocusedRowChangedEvent

			_Controller.SelectionChanged(_ViewModel, DataGridViewForm_VendorInvoiceCategory.IsNewItemRow, DataGridViewForm_VendorInvoiceCategory.GetFirstSelectedRowDataBoundItem)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_VendorInvoiceCategory_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorInvoiceCategory.InitNewRowEvent

			_Controller.InitNewRowEvent(_ViewModel)

			RefreshViewModel(False)

		End Sub
		Private Sub DataGridViewForm_VendorInvoiceCategory_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_VendorInvoiceCategory.ValidateRowEvent

			If e.Row IsNot Nothing Then

				e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

				If DataGridViewForm_VendorInvoiceCategory.CurrentView.IsNewItemRow(e.RowHandle) = False Then

					e.Valid = True

				Else

					DataGridViewForm_VendorInvoiceCategory.CurrentView.NewItemRowText = e.ErrorText

					If e.Valid Then

						AddNewRow(e.Row)

					End If

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_VendorInvoiceCategory_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_VendorInvoiceCategory.ValidatingEditorEvent

			'objects
			Dim FocusedRow As AdvantageFramework.DTO.VendorInvoiceCategory = Nothing
			Dim ErrorText As String = String.Empty

			FocusedRow = DataGridViewForm_VendorInvoiceCategory.CurrentView.GetFocusedRow

			If FocusedRow IsNot Nothing Then

				ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_VendorInvoiceCategory.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

				e.Valid = True

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace