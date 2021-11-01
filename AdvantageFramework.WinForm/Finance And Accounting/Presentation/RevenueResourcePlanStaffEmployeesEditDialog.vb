Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanStaffEmployeesEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel = Nothing
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

            DataGridViewForm_AvailableEmployees.DataSource = _ViewModel.AvailablePlanStaffEmployees
            DataGridViewForm_Employees.DataSource = _ViewModel.PlanStaffEmployees

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonForm_AddEmployees.Enabled = _ViewModel.AddEnabled
            ButtonForm_DeleteEmployees.Enabled = _ViewModel.DeleteEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_AvailableEmployees.OptionsBehavior.Editable = False
            DataGridViewForm_Employees.OptionsBehavior.Editable = False

            DataGridViewForm_AvailableEmployees.MultiSelect = True
            DataGridViewForm_Employees.MultiSelect = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanStaffEmployeesEditDialog As RevenueResourcePlanStaffEmployeesEditDialog = Nothing

            RevenueResourcePlanStaffEmployeesEditDialog = New RevenueResourcePlanStaffEmployeesEditDialog(RevenueResourcePlanID)

            ShowFormDialog = RevenueResourcePlanStaffEmployeesEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanStaffEmployeesEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.StaffEmployeesEdit_Load(_RevenueResourcePlanID)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_AvailableEmployees.CurrentView.BestFitColumns()
            DataGridViewForm_Employees.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanStaffEmployeesEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_AvailableEmployees.GridViewSelectionChanged()
            DataGridViewForm_Employees.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                _Controller.StaffEmployeesEdit_Save(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_AddEmployees_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddEmployees.Click

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                _Controller.StaffEmployeesEdit_AddEmployees(_ViewModel, DataGridViewForm_AvailableEmployees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee).ToList)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewForm_AvailableEmployees.CurrentView.RefreshData()
                DataGridViewForm_Employees.CurrentView.RefreshData()

                DataGridViewForm_AvailableEmployees.CurrentView.BestFitColumns()
                DataGridViewForm_Employees.CurrentView.BestFitColumns()

                DataGridViewForm_AvailableEmployees.GridViewSelectionChanged()
                DataGridViewForm_Employees.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonForm_DeleteEmployees_Click(sender As Object, e As EventArgs) Handles ButtonForm_DeleteEmployees.Click

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting

                _Controller.StaffEmployeesEdit_DeleteEmployees(_ViewModel, DataGridViewForm_Employees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee).ToList)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewForm_AvailableEmployees.CurrentView.RefreshData()
                DataGridViewForm_Employees.CurrentView.RefreshData()

                DataGridViewForm_AvailableEmployees.CurrentView.BestFitColumns()
                DataGridViewForm_Employees.CurrentView.BestFitColumns()

                DataGridViewForm_AvailableEmployees.GridViewSelectionChanged()
                DataGridViewForm_Employees.GridViewSelectionChanged()

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_AvailableEmployees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AvailableEmployees.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_AvailableEmployees.CurrentView.OptionsView.ShowIndicator Then

                _Controller.StaffEmployeesEdit_SelectedAvailablePlanStaffEmployeeChanged(_ViewModel, DataGridViewForm_AvailableEmployees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee).ToList)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Employees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Employees.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_Employees.CurrentView.OptionsView.ShowIndicator Then

                _Controller.StaffEmployeesEdit_SelectedPlanStaffEmployeeChanged(_ViewModel, DataGridViewForm_Employees.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee).ToList)

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
