Namespace Reporting.Presentation

    Public Class EmployeeUtilizationInitialLoadingDialog

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

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim EmployeeUtilizationInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EmployeeUtilizationInitialLoadingDialog = Nothing

            EmployeeUtilizationInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EmployeeUtilizationInitialLoadingDialog(0)

            ShowFormDialog = EmployeeUtilizationInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EmployeeUtilizationInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeUtilizationInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            Me.CheckBoxForm_LimitWIP.Checked = True

            If _ParameterDictionary IsNot Nothing Then

                Try

                    DateTimePickerForm_From.Value = _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.StartDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    DateTimePickerForm_To.Value = _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.EndDate.ToString)

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateTimePickerForm_From.Value <= DateTimePickerForm_To.Value Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.EndDate.ToString) = DateTimePickerForm_To.Value
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.UserID.ToString) = Session.UserCode
                    If RadioButtonForm_Employee.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "emp"
                    ElseIf RadioButtonForm_EmployeeDate.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "empdate"
                    ElseIf RadioButtonForm_EmployeePeriod.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.Groupby.ToString) = "empperiod"
                    End If
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.LimitWIP.ToString) = CheckBoxForm_LimitWIP.Checked

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) = Nothing
                        _ParameterDictionary("SelectedOfficeDescriptions") = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                        _ParameterDictionary("SelectedOfficeDescriptions") = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(1).OfType(Of String).ToList

                    End If

                    If RadioButtonSelectDepartments_AllDepartments.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) = DataGridViewSelectDepartments_Departments.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a start date that is before the end date.")

                End If
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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

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

                    LoadDepartments()

                    DataGridViewSelectDepartments_Departments.Enabled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace