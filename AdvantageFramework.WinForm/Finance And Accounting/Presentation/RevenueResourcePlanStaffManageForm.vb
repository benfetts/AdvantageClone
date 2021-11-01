Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanStaffManageForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_Staff.DataSource = _ViewModel.PlanStaffs

        End Sub
        Private Sub SaveViewModel()

            '_ViewModel.Worksheet.Name = TextBoxForm_Description.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemEmployees_Manage.Enabled = _ViewModel.ManageEmployeesEnabled
            ButtonItemEmployees_AddAltEmployee.Enabled = _ViewModel.AddAlternateEmployeeEnabled
            ButtonItemEmployees_UpdateAltEmployee.Enabled = _ViewModel.UpdateAlternateEmployeeEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemClients_Assignments.Enabled = _ViewModel.ViewDetailsEnabled

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_Staff.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Staff.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Staff.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub SetControlDataSources()

            'ComboBoxForm_Owner.DataSource = _ViewModel.Clients.ToList
            'ComboBoxForm_StartMonth.DataSource = _ViewModel.Divisions.ToList

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Staff.SetupForEditableGrid()

            DataGridViewForm_Staff.MultiSelect = False
            DataGridViewForm_Staff.SetBookmarkColumnIndex(0)

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(RevenueResourcePlanID As Integer)

            'objects
            Dim RevenueResourcePlanStaffManageForm As RevenueResourcePlanStaffManageForm = Nothing

            RevenueResourcePlanStaffManageForm = New RevenueResourcePlanStaffManageForm(RevenueResourcePlanID)

            RevenueResourcePlanStaffManageForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanStaffManageForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemEmployees_Manage.Image = AdvantageFramework.My.Resources.EmployeeAddImage
            ButtonItemEmployees_AddAltEmployee.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemEmployees_UpdateAltEmployee.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemClients_Assignments.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.StaffManage_Load(_RevenueResourcePlanID)

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_Staff.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanStaffManageForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_Staff.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

            _Controller.StaffManage_LoadPlanStaff(_ViewModel)

            LoadViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_Staff.GridViewSelectionChanged()

            DataGridViewForm_Staff.CurrentView.BestFitColumns()

        End Sub
        Private Sub ButtonItemEmployees_Manage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_Manage.Click

            DataGridViewForm_Staff.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanStaffEmployeesEditDialog.ShowFormDialog(_ViewModel.Plan.ID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.StaffManage_LoadPlanStaff(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Staff.GridViewSelectionChanged()

                DataGridViewForm_Staff.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ButtonItemEmployees_AddAltEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_AddAltEmployee.Click

            DataGridViewForm_Staff.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanStaffAltEmployeeEditDialog.ShowFormDialog(_ViewModel.Plan.ID, 0) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.StaffManage_LoadPlanStaff(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Staff.GridViewSelectionChanged()

                DataGridViewForm_Staff.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ButtonItemEmployees_UpdateAltEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_UpdateAltEmployee.Click

            'objects
            Dim RevenueResourcePlanStaffID As Integer = 0

            DataGridViewForm_Staff.CloseGridEditorAndSaveValueToDataSource()

            RevenueResourcePlanStaffID = DataGridViewForm_Staff.GetFirstSelectedRowBookmarkValue()

            If AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanStaffAltEmployeeEditDialog.ShowFormDialog(_ViewModel.Plan.ID, RevenueResourcePlanStaffID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.StaffManage_LoadPlanStaff(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Staff.GridViewSelectionChanged()

                DataGridViewForm_Staff.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            DataGridViewForm_Staff.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this staff from the plan?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                _Controller.StaffManage_DeletePlanStaff(_ViewModel, DataGridViewForm_Staff.GetRowDataBoundItem(DataGridViewForm_Staff.CurrentView.FocusedRowHandle))

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Staff.RefreshDataSource()

                DataGridViewForm_Staff.GridViewSelectionChanged()

                DataGridViewForm_Staff.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ButtonItemClients_Assignments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemClients_Assignments.Click

            DataGridViewForm_Staff.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanStaffClientAssignmentDialog.ShowFormDialog(_ViewModel.Plan.ID, _ViewModel.SelectedPlanStaff.ID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.StaffManage_LoadPlanStaff(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Staff.GridViewSelectionChanged()

                DataGridViewForm_Staff.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_Staff_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Staff.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_Staff.CurrentView.OptionsView.ShowIndicator Then

                _Controller.StaffManage_SelectedStaffChanged(_ViewModel, DataGridViewForm_Staff.GetFirstSelectedRowDataBoundItem())

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Staff_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Staff.ShowingEditorEvent

            If DataGridViewForm_Staff.CurrentView.FocusedColumn IsNot Nothing Then

                If DataGridViewForm_Staff.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff.Properties.Notes.ToString AndAlso
                        DataGridViewForm_Staff.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff.Properties.DirectPercentGoal.ToString Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Staff_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Staff.CellValueChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_Staff.CurrentView.OptionsView.ShowIndicator Then

                If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff.Properties.Notes.ToString Then

                    _Controller.StaffManage_SavePlanStaff(_ViewModel, DataGridViewForm_Staff.GetRowDataBoundItem(e.RowHandle))

                    RefreshViewModel()

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff.Properties.DirectPercentGoal.ToString Then

                    _Controller.StaffManage_SaveDirectPercentGoal(_ViewModel, DataGridViewForm_Staff.GetRowDataBoundItem(e.RowHandle))

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Staff_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_Staff.RowDoubleClickEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                ButtonItemClients_Assignments.RaiseClick()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
