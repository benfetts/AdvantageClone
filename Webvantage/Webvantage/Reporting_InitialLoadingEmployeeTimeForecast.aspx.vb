Imports Telerik.Web.UI

Public Class Reporting_InitialLoadingEmployeeTimeForecast
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
    'Private Sub LoadEmployees()

    '    Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, _Session).ToList

    '        RadGridEmployees.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
    '                                                                                      .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)

    '        'DataGridView_Employees.CurrentView.BestFitColumns()

    '    End Using

    'End Sub
    'Private Sub LoadOffices()

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
    '        RadGridOffice.DataBind()

    '    End Using

    'End Sub
    'Private Sub LoadDepartments()

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        RadGridDepartmentTeams.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
    '                                             Select [Code] = Entity.Code,
    '                                                                           [Name] = Entity.Description).ToList

    '        RadGridDepartmentTeams.DataBind()

    '    End Using

    'End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                RadComboBoxStart.DataBind()

                Try

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                AdvantageFramework.Web.Presentation.SetRadComboBoxRequired(RadComboBoxStart)


                Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, _Session).ToList

                RadComboBoxEmployees.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                        .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)
                RadComboBoxEmployees.DataTextField = "Name"
                RadComboBoxEmployees.DataValueField = "Code"
                RadComboBoxEmployees.DataBind()

                RadComboBoxEmployees.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All Employees]", ""))

                RadComboBoxEmployees.SelectedValue = ""


                Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing

                OfficeList = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList

                RadComboBoxOffices.DataSource = OfficeList.Select(Function(Office) New With {.Code = Office.Code,
                                                                                        .Name = Office.ToString}).OrderBy(Function(Office) Office.Name)
                RadComboBoxOffices.DataTextField = "Name"
                RadComboBoxOffices.DataValueField = "Code"
                RadComboBoxOffices.DataBind()

                RadComboBoxOffices.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All Offices]", ""))

                RadComboBoxOffices.SelectedValue = ""


            End Using

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.EmployeeTimeForecast Then

                'RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ClientPLParameters), False)

            Else

                'Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing


                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.UserID.ToString) = Session("UserCode")
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.PostPeriod.ToString) = RadComboBoxStart.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.OfficeCode.ToString) = RadComboBoxOffices.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.EmployeeCode.ToString) = RadComboBoxEmployees.SelectedValue

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


#End Region

#End Region

End Class
