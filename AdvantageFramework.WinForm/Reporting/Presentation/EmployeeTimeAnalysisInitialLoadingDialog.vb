Namespace Reporting.Presentation

    Public Class EmployeeTimeAnalysisInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))
            'Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            '_ReportType = ReportType
            '_DynamicReport = DynamicReport
            '_ShowReportOption = ShowReportOption

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult
            'Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeAnalysisInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EmployeeTimeAnalysisInitialLoadingDialog = Nothing

            EmployeeTimeAnalysisInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EmployeeTimeAnalysisInitialLoadingDialog(ParameterDictionary)
            'DynamicReport, ShowReportOption, ReportType, ParameterDictionary

            ShowFormDialog = EmployeeTimeAnalysisInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EmployeeTimeAnalysisInitialLoadingDialog.ParameterDictionary

            End If

        End Function

        Private Sub EnableOrDisableActions()

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
        Private Sub LoadEmployees()

            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridViewSelectEmployees_Employees.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                          .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)

                DataGridViewSelectEmployees_Employees.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False
            Me.CheckBoxForm_Actualized.Checked = True

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            Me.RadioButtonControl_Day.Checked = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            'Dim ClientCodeList As Generic.List(Of String) = Nothing
            'Dim DivisionCodeList As Generic.List(Of String) = Nothing
            'Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                'If _ShowReportOption Then

                '    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                'Else

                'End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.UserID.ToString) = Session.UserCode

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.EndDate.ToString) = DateTimePickerForm_To.Value

                If RadioButtonSelectOffices_AllOffices.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedOffices.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonSelectDepartments_AllDepartments.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedDepartments.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedDepartments.ToString) = DataGridViewSelectDepartments_Departments.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonSelectEmployees_AllEmployees.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedEmployees.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.SelectedEmployees.ToString) = DataGridViewSelectEmployees_Employees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If RadioButtonControl_Day.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.FeeTimeOption.ToString) = 1
                ElseIf RadioButtonControl_Month.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.FeeTimeOption.ToString) = 0
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeAnalysisInitialParameters.IncludeInactiveEmployees.ToString) = If(CheckBoxForm_Actualized.Checked, 0, 1)

                'AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)
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




#End Region

#End Region

    End Class

End Namespace
