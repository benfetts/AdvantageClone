Namespace Reporting.Presentation

    Public Class EmployeeHoursAllocationInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadDepartments()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectDepartments_Departments.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                                        Select [Code] = Entity.Code,
                                                                               [Name] = Entity.Description).ToList

                DataGridViewSelectDepartments_Departments.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadRoles()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectRoles_Roles.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                                                            Select [Code] = Entity.Code,
                                                                   [Name] = Entity.Description).ToList

                DataGridViewSelectRoles_Roles.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadEmployees()

            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridViewSelectEmployees_Employees.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                          .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)

                DataGridViewSelectEmployees_Employees.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Function IsDailyAllowed(ByVal StartDate As Date, ByVal EndDate As Date) As Boolean

            Return Not (DateDiff(DateInterval.Day, StartDate, EndDate) >= 32)

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim EmployeeHoursAllocationInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EmployeeHoursAllocationInitialLoadingDialog = Nothing

            EmployeeHoursAllocationInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EmployeeHoursAllocationInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = EmployeeHoursAllocationInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EmployeeHoursAllocationInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeHoursAllocationInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            Me.RadioButtonControl_Day.Checked = True


        End Sub
        Private Sub EmployeeHoursAllocationInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim ErrorMessage As String = Nothing

            Dim StartDate As DateTime
            Dim EndDate As DateTime

            StartDate = DateTimePickerForm_From.Value
            EndDate = DateTimePickerForm_To.Value

            If RadioButtonControl_Day.Checked Then
                If IsDailyAllowed(StartDate, EndDate) = False Then
                    AdvantageFramework.WinForm.MessageBox.Show("The Day option is limited to 30 days.")
                    Exit Sub
                End If
            End If

            If RadioButtonControl_Week.Checked Or RadioButtonControl_Month.Checked Then
                Dim day_ct As Long = DateDiff(DateInterval.Day, StartDate, EndDate)
                If day_ct >= 366 Then
                    AdvantageFramework.WinForm.MessageBox.Show("The Month and week options are limited to 1 year.")
                    Exit Sub
                End If
            End If

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportType.ToString) = 1
                If RadioButtonControl_Day.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 1
                ElseIf RadioButtonControl_Week.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 2
                ElseIf RadioButtonControl_Month.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 3
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.OmitBeginning.ToString) = If(CheckBoxForm_Actualized.Checked, 0, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.IncludeActuals.ToString) = If(CheckBox_IncludeActuals.Checked, 1, 0)

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.EndDate.ToString) = DateTimePickerForm_To.Value


                If RadioButtonSelectOffices_AllOffices.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedOffices.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonSelectDepartments_AllDepartments.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedDepartments.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedDepartments.ToString) = DataGridViewSelectDepartments_Departments.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonSelectRoles_AllRoles.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedRoles.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedRoles.ToString) = DataGridViewSelectRoles_Roles.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonSelectEmployees_AllEmployees.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedEmployees.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedEmployees.ToString) = DataGridViewSelectEmployees_Employees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                End If

            End If

        End Sub

        Private Sub RadioButtonSelectDepartments_AllDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectDepartments_AllDepartments.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectDepartments_AllDepartments.Checked Then

                    DataGridViewSelectDepartments_Departments.Enabled = False

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectDepartments_ChooseDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectDepartments_ChooseDepartments.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectDepartments_ChooseDepartments.Checked Then

                    If DataGridViewSelectDepartments_Departments.HasRows = False Then

                        LoadDepartments()

                    End If

                    DataGridViewSelectDepartments_Departments.Enabled = True

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectRoles_AllRoles_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectRoles_AllRoles.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectRoles_AllRoles.Checked Then

                    DataGridViewSelectRoles_Roles.Enabled = False

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectRoles_ChooseRoles_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectRoles_ChooseRoles.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectRoles_ChooseRoles.Checked Then

                    If DataGridViewSelectRoles_Roles.HasRows = False Then

                        LoadRoles()

                    End If

                    DataGridViewSelectRoles_Roles.Enabled = True

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectEmployees_AllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectEmployees_AllEmployees.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectEmployees_AllEmployees.Checked Then

                    DataGridViewSelectEmployees_Employees.Enabled = False

                End If

            End If
        End Sub

        Private Sub RadioButtonSelectEmployees_ChooseEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectEmployees_ChooseEmployees.CheckedChanged
            If Me.FormShown Then

                If RadioButtonSelectEmployees_ChooseEmployees.Checked Then

                    If DataGridViewSelectEmployees_Employees.HasRows = False Then

                        LoadEmployees()

                    End If

                    DataGridViewSelectEmployees_Employees.Enabled = True

                End If

            End If
        End Sub

        Private Sub RadioButtonControl_Week_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_Week.CheckedChanged

        End Sub

        Private Sub RadioButtonControl_Month_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_Month.CheckedChanged

        End Sub

        Private Sub CheckBoxForm_Actualized_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_Actualized.CheckedChanged
            If CheckBoxForm_Actualized.Checked Then
                DateTimePickerForm_From.Enabled = False
                DateTimePickerForm_From.Value = Now
            Else
                DateTimePickerForm_From.Enabled = True
            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace
