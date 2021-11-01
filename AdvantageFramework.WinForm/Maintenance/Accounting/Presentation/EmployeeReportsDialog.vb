Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Private _SelectedEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
        Private _AvailableEmployeeCodes() As String = Nothing
        Private _SelectedEmployeeCodes() As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal AvailableEmployeeCodes() As String, ByVal SelectedEmployeeCodes() As String)

            ' This call is required by the designer.
            InitializeComponent()

            _AvailableEmployeeCodes = AvailableEmployeeCodes
            _SelectedEmployeeCodes = SelectedEmployeeCodes

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Classes.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Include("DepartmentTeam").Include("Office")
                             Select Employee.Code,
                                    Employee.FirstName,
                                    Employee.LastName,
                                    Employee.MiddleInitial,
                                    [OfficeCode] = Employee.OfficeCode,
                                    [OfficeName] = If(Employee.Office Is Nothing, "", Employee.Office.Name),
                                    [DepartmentTeamCode] = Employee.DepartmentTeamCode,
                                    [DepartmentTeamName] = If(Employee.DepartmentTeam Is Nothing, "", Employee.DepartmentTeam.Description),
                                    Employee.TerminationDate,
                                    Employee.Freelance,
                                    Employee.IsActiveFreelance
                             Order By Code).ToList _
                            .Select(Function(Employee) New AdvantageFramework.Database.Classes.Employee With {.Code = Employee.Code,
                                                                                                              .Name = Employee.FirstName & " " &
                                                                                                                      If(String.IsNullOrWhiteSpace(Employee.MiddleInitial) = False, Employee.MiddleInitial & ". ", "") &
                                                                                                                      Employee.LastName,
                                                                                                              .OfficeCode = Employee.OfficeCode,
                                                                                                              .OfficeName = Employee.OfficeName,
                                                                                                              .DepartmentTeamCode = Employee.DepartmentTeamCode,
                                                                                                              .DepartmentTeamName = Employee.DepartmentTeamName,
                                                                                                              .Terminated = If(Employee.TerminationDate Is Nothing, False, True),
                                                                                                              .Freelance = CBool(Employee.Freelance.GetValueOrDefault(0)),
                                                                                                              .IsActiveFreelance = Employee.IsActiveFreelance}).ToList

                If _AvailableEmployeeCodes IsNot Nothing Then

                    DataGridViewForm_SelectedEmployees.DataSource = (From Employee In Employees
                                                                     Where _AvailableEmployeeCodes.Contains(Employee.Code)
                                                                     Select Employee).ToList

                Else

                    DataGridViewForm_SelectedEmployees.DataSource = Employees

                End If

            End Using

            DataGridViewForm_SelectedEmployees.CurrentView.BestFitColumns()

        End Sub
        Private Sub SelectGridRows()

            If _SelectedEmployeeCodes IsNot Nothing Then

                DataGridViewForm_SelectedEmployees.CurrentView.BeginSelection()

                DataGridViewForm_SelectedEmployees.CurrentView.ClearSelection()

                For Each EmployeeCode In _SelectedEmployeeCodes

                    DataGridViewForm_SelectedEmployees.SelectRow(0, EmployeeCode, False)

                Next

            End If

        End Sub
        Private Sub LoadReports()

            Dim ReportList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Report) = Nothing
            Dim Report As AdvantageFramework.Security.Database.Entities.Report = Nothing
            Dim DoesUserHaveAccessEmployeeMaintenance As Boolean = False
            Dim CanUserCustom1 As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ReportList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Report)

                DoesUserHaveAccessEmployeeMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString, Me.Session.User.ID)
                CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.Session, Security.Modules.Maintenance_Accounting_Employee)

                For Each Report In AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 109).ToList

                    If DoesUserHaveAccessEmployeeMaintenance OrElse AdvantageFramework.Security.DoesUserHaveAccessToReport(Me.Session, Report.Code) Then

                        If Report.Code = "d_employee_general_info_hr_rpt" OrElse Report.Code = "Employee Rate History" Then

                            If CanUserCustom1 = False Then

                                ReportList.Add(Report)

                            End If

                        Else

                            ReportList.Add(Report)

                        End If

                    End If

                Next

                ListBoxForm_Reports.DataSource = ReportList

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal AvailableEmployeeCodes() As String = Nothing, Optional ByVal SelectedEmployeeCodes() As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeReportsDialog As AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeReportsDialog = Nothing

            EmployeeReportsDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeReportsDialog(AvailableEmployeeCodes, SelectedEmployeeCodes)

            ShowFormDialog = EmployeeReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ' Objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ListBoxForm_Reports.SelectionMode = Windows.Forms.SelectionMode.One
            RadioButtonControlPrimarySort_Office.Checked = True
            RadioButtonControlSecondarySort_ByEmployeeCode.Checked = True

            Try

                LoadReports()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            DataGridViewForm_SelectedEmployees.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim EmployeeCodes() As String = Nothing

            If Me.Validator Then

                If DataGridViewForm_SelectedEmployees.HasASelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        EmployeeCodes = (From Entity In DataGridViewForm_SelectedEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of String)()
                                         Select Entity).ToArray

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        Select Case ListBoxForm_Reports.SelectedValue

                            Case "d_employee_name_addr_rpt"

                                ReportType = Reporting.ReportTypes.EmployeeAddressListing

                            Case "d_employee_general_info_rpt"

                                ReportType = Reporting.ReportTypes.EmployeeDetailListing

                            Case "d_employee_general_info_hr_rpt"

                                ReportType = Reporting.ReportTypes.EmployeeDetailListingWithHR

                            Case "Employee Rate History"

                                ReportType = Reporting.ReportTypes.EmployeeRateHistory

                        End Select

                        If RadioButtonControlPrimarySort_NoOffice.Checked Then

                            If RadioButtonControlSecondarySort_ByEmployeeCode.Checked Then

                                EmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                Where EmployeeCodes.Contains(Entity.Code)
                                                Select Entity
                                                Order By Entity.Code).ToList

                                ParameterList.Add("SortedBy", "Sorted by Employee Code")

                            ElseIf RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Checked Then

                                EmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                Where EmployeeCodes.Contains(Entity.Code)
                                                Select Entity
                                                Order By Entity.LastName,
                                                         Entity.FirstName).ToList

                                ParameterList.Add("SortedBy", "Sorted by Employee Last Name, Employee First Name")

                            End If

                        ElseIf RadioButtonControlPrimarySort_Office.Checked Then

                            If RadioButtonControlSecondarySort_ByEmployeeCode.Checked Then

                                EmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                Where EmployeeCodes.Contains(Entity.Code)
                                                Select Entity
                                                Order By Entity.OfficeCode,
                                                         Entity.Code).ToList

                                ParameterList.Add("SortedBy", "Sorted by Office, Employee Code")

                            ElseIf RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Checked Then

                                EmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                Where EmployeeCodes.Contains(Entity.Code)
                                                Select Entity
                                                Order By Entity.OfficeCode,
                                                         Entity.LastName,
                                                         Entity.FirstName).ToList

                                ParameterList.Add("SortedBy", "Sorted by Office, Employee Last Name, Employee First Name")

                            End If

                        End If

                        If EmployeeList IsNot Nothing AndAlso EmployeeList.Count > 0 Then

                            ParameterList.Add("DataSource", EmployeeList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one employee.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace