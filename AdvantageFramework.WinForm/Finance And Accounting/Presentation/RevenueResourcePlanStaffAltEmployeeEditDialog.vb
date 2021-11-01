Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanStaffAltEmployeeEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0
        Protected _RevenueResourcePlanStaffID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanStaffID = RevenueResourcePlanStaffID

        End Sub
        Private Sub LoadViewModel()

            TextBoxForm_Name.Text = _ViewModel.PlanStaffAltEmployee.AltEmployeeName

            ComboBoxForm_Office.SelectedValue = _ViewModel.PlanStaffAltEmployee.OfficeCode
            ComboBoxForm_EmployeeTitle.SelectedValue = _ViewModel.PlanStaffAltEmployee.EmployeeTitleID.GetValueOrDefault(-1).ToString
            ComboBoxForm_DeptTeam.SelectedValue = _ViewModel.PlanStaffAltEmployee.DepartmentTeamCode
            ComboBoxForm_StaffType.SelectedValue = _ViewModel.PlanStaffAltEmployee.RevenueResourcePlanStaffTypeID.GetValueOrDefault(2).ToString

            NumericInputForm_MonthlyHours.EditValue = _ViewModel.PlanStaffAltEmployee.AltEmployeeMonthlyHours.GetValueOrDefault(0)
            NumericInputForm_DirectHoursGoal.EditValue = _ViewModel.PlanStaffAltEmployee.AltEmployeeDirectHoursGoal.GetValueOrDefault(0)
            NumericInputForm_BillableRate.EditValue = _ViewModel.PlanStaffAltEmployee.AltEmployeeHourlyBillableRate.GetValueOrDefault(0)
            NumericInputForm_CostRate.EditValue = _ViewModel.PlanStaffAltEmployee.AltEmployeeHourlyCostRate.GetValueOrDefault(0)

            TextBoxForm_Notes.Text = _ViewModel.PlanStaffAltEmployee.Notes

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.PlanStaffAltEmployee.AltEmployeeName = TextBoxForm_Name.Text

            _ViewModel.PlanStaffAltEmployee.OfficeCode = ComboBoxForm_Office.GetSelectedValue
            _ViewModel.PlanStaffAltEmployee.EmployeeTitleID = ComboBoxForm_EmployeeTitle.GetSelectedValue
            _ViewModel.PlanStaffAltEmployee.DepartmentTeamCode = ComboBoxForm_DeptTeam.GetSelectedValue
            _ViewModel.PlanStaffAltEmployee.RevenueResourcePlanStaffTypeID = ComboBoxForm_StaffType.GetSelectedValue

            _ViewModel.PlanStaffAltEmployee.AltEmployeeMonthlyHours = NumericInputForm_MonthlyHours.EditValue
            _ViewModel.PlanStaffAltEmployee.AltEmployeeDirectHoursGoal = NumericInputForm_DirectHoursGoal.EditValue
            _ViewModel.PlanStaffAltEmployee.AltEmployeeHourlyBillableRate = NumericInputForm_BillableRate.EditValue
            _ViewModel.PlanStaffAltEmployee.AltEmployeeHourlyCostRate = NumericInputForm_CostRate.EditValue

            _ViewModel.PlanStaffAltEmployee.Notes = TextBoxForm_Notes.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Visible = _ViewModel.AddVisible
            ButtonItemActions_Update.Visible = _ViewModel.UpdateVisible
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Office.DataSource = _ViewModel.Offices.ToList
            ComboBoxForm_EmployeeTitle.DataSource = _ViewModel.EmployeeTitles.ToList
            ComboBoxForm_DeptTeam.DataSource = _ViewModel.DepartmentTeams.ToList
            ComboBoxForm_StaffType.DataSource = _ViewModel.RevenueResourcePlanStaffTypes.ToList

        End Sub
        Private Sub SetControlPropertySettings()

            TextBoxForm_Name.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.AltEmployeeName)

            ComboBoxForm_Office.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.OfficeCode)
            ComboBoxForm_EmployeeTitle.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.EmployeeTitleID)
            ComboBoxForm_DeptTeam.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.DepartmentTeamCode)
            ComboBoxForm_StaffType.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.RevenueResourcePlanStaffTypeID)

            NumericInputForm_MonthlyHours.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Decimal
            NumericInputForm_DirectHoursGoal.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Percent
            NumericInputForm_BillableRate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Currency
            NumericInputForm_CostRate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Currency

            NumericInputForm_MonthlyHours.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.AltEmployeeMonthlyHours)
            NumericInputForm_DirectHoursGoal.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.AltEmployeeDirectHoursGoal)
            NumericInputForm_BillableRate.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.AltEmployeeHourlyBillableRate)
            NumericInputForm_CostRate.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.AltEmployeeHourlyCostRate)

            TextBoxForm_Notes.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee.Properties.Notes)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanStaffAltEmployeeEditDialog As RevenueResourcePlanStaffAltEmployeeEditDialog = Nothing

            RevenueResourcePlanStaffAltEmployeeEditDialog = New RevenueResourcePlanStaffAltEmployeeEditDialog(RevenueResourcePlanID, RevenueResourcePlanStaffID)

            ShowFormDialog = RevenueResourcePlanStaffAltEmployeeEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanStaffAltEmployeeEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.StaffAltEmployeeEdit_Load(_RevenueResourcePlanID, _RevenueResourcePlanStaffID)

            SetControlDataSources()

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RevenueResourcePlanStaffAltEmployeeEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                SaveViewModel()

                If _Controller.StaffAltEmployeeEdit_Validate(_ViewModel, ErrorMessage) Then

                    _Controller.StaffAltEmployeeEdit_Add(_ViewModel)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        _RevenueResourcePlanID = _ViewModel.Plan.ID

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

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
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                If _Controller.StaffAltEmployeeEdit_Validate(_ViewModel, ErrorMessage) Then

                    _Controller.StaffAltEmployeeEdit_Update(_ViewModel)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

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
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
