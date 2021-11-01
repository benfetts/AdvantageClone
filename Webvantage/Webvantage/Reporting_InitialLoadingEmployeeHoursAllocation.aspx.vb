Public Class Reporting_InitialLoadingEmployeeHoursAllocation
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Protected _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = Session("DRPT_Type")

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
            RadGridOffice.DataBind()

        End Using

    End Sub
    Private Sub LoadDepartments()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridDepartment.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                            Select [Code] = Entity.Code,
                                                                               [Name] = Entity.Description).ToList

            RadGridDepartment.DataBind()

        End Using

    End Sub
    Private Sub LoadRoles()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridRole.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                                      Select [Code] = Entity.Code,
                                                                   [Name] = Entity.Description).ToList

            RadGridRole.DataBind()

        End Using

    End Sub
    Private Sub LoadEmployees()

        Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, _Session).ToList

            RadGridEmployee.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                          .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)

            RadGridEmployee.DataBind()

        End Using

    End Sub
    Private Function IsDailyAllowed(ByVal StartDate As Date, ByVal EndDate As Date) As Boolean

        Return Not (DateDiff(DateInterval.Day, StartDate, EndDate) >= 32)

    End Function

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingMediaCurrentStatusSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridDepartment.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

            RadGridRole.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Role)

            RadGridEmployee.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        'objects
        Dim OfficeCodesList As Generic.List(Of String) = Nothing
        Dim DepartmentCodesList As Generic.List(Of String) = Nothing
        Dim RoleCodesList As Generic.List(Of String) = Nothing
        Dim EmployeeCodesList As Generic.List(Of String) = Nothing

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Dim StartDate As DateTime
                Dim EndDate As DateTime

                StartDate = RadDatePickerFrom.SelectedDate
                EndDate = RadDatePickerTo.SelectedDate

                If RadioButtonDay.Checked Then
                    If IsDailyAllowed(StartDate, EndDate) = False Then
                        Me.ShowMessage("The Day option is limited to 30 days.")
                        Exit Sub
                    End If
                End If

                If RadioButtonWeek.Checked Or RadioButtonMonth.Checked Then
                    Dim day_ct As Long = DateDiff(DateInterval.Day, StartDate, EndDate)
                    If day_ct >= 366 Then
                        Me.ShowMessage("The Month and week options are limited to 1 year.")
                        Exit Sub
                    End If
                End If

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.StartDate.ToString) = RadDatePickerFrom.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.EndDate.ToString) = RadDatePickerTo.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportType.ToString) = 1
                If RadioButtonDay.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 1
                ElseIf RadioButtonWeek.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 2
                ElseIf RadioButtonMonth.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.ReportBy.ToString) = 3
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.OmitBeginning.ToString) = If(CheckBoxActualized.Checked, 0, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.IncludeActuals.ToString) = If(CheckBoxIncludeActuals.Checked, 1, 0)

                If RadioButtonAllOffices.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedOffices.ToString) = Nothing

                Else

                    If RadGridOffice.Items.Count > 0 Then

                        OfficeCodesList = New Generic.List(Of String)

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items

                            If gridDataItem.Selected = True Then
                                OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If

                        Next

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedOffices.ToString) = OfficeCodesList

                End If

                If RadioButtonAllDepartments.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedDepartments.ToString) = Nothing

                Else

                    If RadGridDepartment.Items.Count > 0 Then

                        DepartmentCodesList = New Generic.List(Of String)

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDepartment.MasterTableView.Items

                            If gridDataItem.Selected = True Then
                                DepartmentCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If

                        Next

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedDepartments.ToString) = DepartmentCodesList

                End If

                If RadioButtonAllRoles.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedRoles.ToString) = Nothing

                Else

                    If RadGridRole.Items.Count > 0 Then

                        RoleCodesList = New Generic.List(Of String)

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridRole.MasterTableView.Items

                            If gridDataItem.Selected = True Then
                                RoleCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If

                        Next

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedRoles.ToString) = RoleCodesList

                End If

                If RadioButtonAllEmployees.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedEmployees.ToString) = Nothing

                Else

                    If RadGridEmployee.Items.Count > 0 Then

                        EmployeeCodesList = New Generic.List(Of String)

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEmployee.MasterTableView.Items

                            If gridDataItem.Selected = True Then
                                EmployeeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If

                        Next

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeHoursAllocationParameters.SelectedEmployees.ToString) = EmployeeCodesList

                End If



                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = _ParameterDictionary

                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub
    Private Sub RadioButtonAllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOffices.CheckedChanged

        If RadioButtonAllOffices.Checked Then

            RadGridOffice.Enabled = False
            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
            RadGridOffice.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOffices.CheckedChanged

        If RadioButtonChooseOffices.Checked Then

            If RadGridOffice.Items.Count = 0 Then

                LoadOffices()

            End If

            RadGridOffice.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonAllDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllDepartments.CheckedChanged

        If RadioButtonAllDepartments.Checked Then

            RadGridDepartment.Enabled = False
            RadGridDepartment.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)
            RadGridDepartment.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseDepartments.CheckedChanged

        If RadioButtonChooseDepartments.Checked Then

            If RadGridDepartment.Items.Count = 0 Then

                LoadDepartments()

            End If

            RadGridDepartment.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonAllRoles_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllRoles.CheckedChanged

        If RadioButtonAllRoles.Checked Then

            RadGridRole.Enabled = False
            RadGridRole.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Role)
            RadGridRole.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseRoles_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseRoles.CheckedChanged

        If RadioButtonChooseRoles.Checked Then

            If RadGridRole.Items.Count = 0 Then

                LoadRoles()

            End If

            RadGridRole.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllEmployees.CheckedChanged

        If RadioButtonAllEmployees.Checked Then

            RadGridEmployee.Enabled = False
            RadGridEmployee.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
            RadGridEmployee.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseEmployees.CheckedChanged

        If RadioButtonChooseEmployees.Checked Then

            If RadGridEmployee.Items.Count = 0 Then

                LoadEmployees()

            End If

            RadGridEmployee.Enabled = True

        End If

    End Sub

    Private Sub CheckBoxActualized_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxActualized.CheckedChanged
        If CheckBoxActualized.Checked Then
            RadDatePickerFrom.Enabled = False
            RadDatePickerFrom.SelectedDate = Now
        Else
            RadDatePickerFrom.Enabled = True
        End If
    End Sub

#End Region

#End Region

End Class
