Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardETF
    Inherits Webvantage.BaseChildPage
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

#Region " Controls "
    Protected WithEvents DropMonth As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropWeek As Telerik.Web.UI.RadComboBox
    Protected WithEvents DropLevel As Telerik.Web.UI.RadComboBox
    Protected WithEvents CheckBoxPrintAll As CheckBox
#End Region

#Region " Variables and Properties "

    Public OfficeCode As String = ""
    Public DeptCode As String = ""
    Public EmpCode As String = ""
    Public month As String = ""
    Public year As String = ""
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public include As Integer = 0
    Public period As Integer = 0
    Public yearValue As String = ""
    Public cols As Integer
    Public cancel As String = ""
    Public cancelDesc As String = ""
    Public project As String = ""
    Public type As String = ""
    Public dash As String = ""
    Public ae As String = ""
    Public sc As String = ""
    Public jt As String = ""

    Private View As Integer = 0

    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                Dim res As Object = Me.Session("_ds")
                If res Is Nothing Then

                End If
                Dim dt As DataTable = DirectCast(Me.Session("_ds"), DataTable)
                'RowCount = dt.Rows.Count
                Return dt
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function
#End Region

#Region " Page Functions "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Try
            If qs.GetValue("View") <> "" Then
                View = CInt(qs.GetValue("View"))
            End If
        Catch ex As Exception
            View = 0
        End Try

        If View = 0 Or View = 3 Then
            Dashboard.InitializePieChart(RadHtmlChartHoursPieChart, "")
            Dashboard.InitializeLineChart(RadHtmlChartLineChart, "")
            Dashboard.InitializeDirectAndNonDirectBarChart(RadHtmlChartStackBudgetComparison, "")
        ElseIf View = 1 Or View = 2 Or View = 4 Then
            Dashboard.InitializePieChart(RadHtmlChartDirectHoursByClient, "")
            Dashboard.InitializePieChart(RadHtmlChartDirectHoursByType, "")
            Dashboard.InitializeDirectAndNonDirectBarChart(RadHtmlChartDirectIndirect, "")
            Dashboard.InitializeDirectAndNonDirectBarChart(RadHtmlChartRequiredActual, "")
        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Try
        '    If Not Me.IsPostBack Then
        '        If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_ClientTimeAnalysisDQ) = 0 Then
        '            Server.Transfer("NoAccess.aspx")
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try

        'Dim otask As cTasks = New cTasks(Session("ConnString"))
        'Dim taskVar As String
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "OfficeCode")
        'If taskVar <> "" Then
        '    OfficeCode = taskVar
        'End If
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "DeptCode")
        'If taskVar <> "" Then
        '    DeptCode = taskVar
        'End If
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "AECode")
        'If taskVar <> "" Then
        '    ae = taskVar
        'End If
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "ClientCode")
        'If taskVar <> "" Then
        '    client = taskVar
        'End If
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "SCCode")
        'If taskVar <> "" Then
        '    sc = taskVar
        'End If
        'taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "JobType")
        'If taskVar <> "" Then
        '    jt = taskVar
        'End If

        If Not Me.IsPostBack Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                'DropDownListPostPeriodYear.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                '                                         Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList

                DropDownListPostPeriodYear.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                         Select New With {.[Year] = CInt(Entity.Year)}).Distinct.ToList.OrderByDescending(Function(Entity) Entity.Year).ToList
                DropDownListPostPeriodYear.DataBind()

                DropDownListMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                DropDownListMonth.DataBind()

                DropDownListPostPeriodYear.SelectedValue = Now.Year
                DropDownListMonth.SelectedValue = Now.Month

                'RadComboBoxYearTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                '                                Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList

                RadComboBoxYearTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                                Select New With {.[Year] = CInt(Entity.Year)}).Distinct.ToList.OrderByDescending(Function(Entity) Entity.Year).ToList
                RadComboBoxYearTo.DataBind()

                RadComboBoxMonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                RadComboBoxMonthTo.DataBind()

                RadComboBoxYearTo.SelectedValue = Now.Year
                RadComboBoxMonthTo.SelectedValue = Now.Month

                RadComboBoxDepartment.DataSource = (From DepartmentTeam In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                    Select DepartmentTeam.Code,
                                                               DepartmentTeam.Description).ToList
                RadComboBoxDepartment.DataBind()

                RadComboBoxDepartment.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                Me.DropDownListMonth.SelectedValue = qs.GetValue("FromMonth")
                Me.DropDownListPostPeriodYear.SelectedValue = qs.GetValue("FromYear")
                Me.RadComboBoxMonthTo.SelectedValue = qs.GetValue("ToMonth")
                Me.RadComboBoxYearTo.SelectedValue = qs.GetValue("ToYear")

                If qs.GetValue("Dept") <> "" Then
                    Me.RadComboBoxDepartment.SelectedValue = qs.GetValue("Dept")
                End If

                If qs.GetValue("View") <> "" Then
                    View = qs.GetValue("View")
                End If

            End Using

            If View = 0 Or View = 3 Then
                Me.PanelETF.Visible = True
                Me.PanelEmployeeUtilization.Visible = False
            ElseIf View = 1 Or View = 2 Or View = 4 Then
                Me.PanelETF.Visible = False
                Me.PanelEmployeeUtilization.Visible = True
            Else
                Me.PanelETF.Visible = True
                Me.PanelEmployeeUtilization.Visible = False
            End If

            LoadUserSettings()

            LoadData(type)

            'Me.LabelByLevel.Text = project & " Dollars By " & Me.DropLevel.SelectedItem.Text

            Me.Title = "Employee Time Dashboard"

        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    Me.RefreshGrid()
            End Select
        End If

        'Clear off sessions from quote page
        Try
            If Not Me.IsPostBack Then

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

    Private Sub LoadUserSettings()

        Try

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            If Request.QueryString("DO") = "All" Then
                Try
                    If otask.getAppVars(Session("UserCode"), "EmployeeTimeForecast", "AlternateEmployee") <> "" Then
                        Me.CheckboxAlternateEmployee.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee"), Boolean)
                    End If
                Catch ex As Exception

                End Try

                Try
                    If otask.getAppVars(Session("UserCode"), "EmployeeTimeForecast", "ForecastOnly") <> "" Then
                        Me.CheckboxForecastOnly.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly"), Boolean)
                    End If
                Catch ex As Exception

                End Try
                Me.trIncludeSupervisorEmployees.Visible = False
                If View = 1 Or View = 2 Or View = 4 Then
                    Me.CheckboxAlternateEmployee.Checked = False
                    Me.CheckboxForecastOnly.Checked = False
                    Me.trAlternateEmployee.Visible = False
                    Me.trForecastOnly.Visible = False
                End If

            Else
                Try
                    If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee") <> "" Then
                        Me.CheckboxAlternateEmployee.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "AlternateEmployee"), Boolean)
                    End If
                Catch ex As Exception

                End Try

                Try
                    If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees") <> "" Then
                        Me.CheckboxIncludeSupervisorEmployees.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "SupervisedEmployees"), Boolean)
                    End If
                Catch ex As Exception

                End Try

                Try
                    If otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly") <> "" Then
                        Me.CheckboxForecastOnly.Checked = CType(otask.getAppVars(Session("UserCode"), "MyEmployeeTimeForecast", "ForecastOnly"), Boolean)
                    End If
                Catch ex As Exception

                End Try
                If View = 1 Or View = 2 Or View = 4 Then
                    Me.CheckboxAlternateEmployee.Checked = False
                    Me.CheckboxForecastOnly.Checked = False
                    Me.trAlternateEmployee.Visible = False
                    Me.trForecastOnly.Visible = False
                End If
            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub DropDownListMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListMonth.SelectedIndexChanged

        'LoadData()

    End Sub
    Private Sub DropDownListPostPeriodYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListPostPeriodYear.SelectedIndexChanged

        'LoadData()

    End Sub
    Private Sub RadComboBoxYearTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxYearTo.SelectedIndexChanged

        'LoadData()

    End Sub
    Private Sub RadComboBoxMonthTo_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMonthTo.SelectedIndexChanged

        'LoadData()

    End Sub
    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.NeedDataSource
        Try
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing

            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Me.DropDownListMonth.SelectedValue, Me.DropDownListPostPeriodYear.SelectedValue)
                ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, RadComboBoxMonthTo.SelectedValue, RadComboBoxYearTo.SelectedValue)

                If Request.QueryString("DO") = "All" Then

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, False, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)
                Else

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, False, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)
                End If

            End Using

            Me.RadGridEmployeeTimeForecastOfficeDetailJobComponents.DataSource = (From Entity In EmployeeTimeForecastDetail
                                                                                  Where Entity.ClientCode <> ""
                                                                                  Group Entity By Entity.ClientCode,
                                                                                       Entity.ClientName Into ETFD = Group
                                                                                  Select New AdvantageFramework.Dashboard.Classes.EmployeeTimeForcastDashboard(
                                                                                        ClientCode,
                                                                                        ClientName,
                                                                                        ETFD.Sum(Function(MPC) MPC.ForecastedHours),
                                                                                        ETFD.Sum(Function(MPC) MPC.ForecastedAmount),
                                                                                        ETFD.Sum(Function(MPC) MPC.ActualHours),
                                                                                        ETFD.Sum(Function(MPC) MPC.ActualAmount),
                                                                                        (ETFD.Sum(Function(MPC) MPC.ActualHours) - ETFD.Sum(Function(MPC) MPC.ForecastedHours)))).ToList

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_JobStatistics(Session("ds_DASH_Comps"), "")
    End Function

    Public Function WriteXMLPie() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_PieProjects(Session("ds_DASH_Comps_Pie"), "", "", "", True)
    End Function

    Public Function WriteXMLPieSelectionHours() As String
        Dim das As New cDashboard(Session("ConnString"), Session("UserCode"))
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        With Response
            dash = qs.GetValue("dash")
        End With
        'For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
        '    If rtb.Checked = True And rtb.Value = "Month" Then
        '        type = rtb.Value
        '    End If
        '    If rtb.Checked = True And rtb.Value = "YeartoDate" Then
        '        type = rtb.Value
        '    End If
        'Next
        'year = ""
        'For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
        '    If rtb.Checked = True Then
        '        year &= rtb.Text & "-"
        '    End If
        'Next
        year = MiscFN.RemoveTrailingDelimiter(year, "-")
        If Me.DropLevel.SelectedValue = "C" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "CL_NAME", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "DIV_NAME", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "PRD_DESCRIPTION", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "ACCT_NAME", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "DP_TM_DESC", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "SC_DESCRIPTION", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByHours"), "JT_DESC", "HOURS", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Hours: ", "H")
        End If

    End Function

    Public Function WriteXMLPieSelectionDollars() As String
        Dim das As New cDashboard(Session("ConnString"), Session("UserCode"))
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        With Response
            dash = qs.GetValue("dash")
        End With
        'For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
        '    If rtb.Checked = True And rtb.Value = "Month" Then
        '        type = rtb.Value
        '    End If
        '    If rtb.Checked = True And rtb.Value = "YeartoDate" Then
        '        type = rtb.Value
        '    End If
        'Next
        'year = ""
        'For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
        '    If rtb.Checked = True Then
        '        year &= rtb.Text & "-"
        '    End If
        'Next
        year = MiscFN.RemoveTrailingDelimiter(year, "-")
        If Me.DropLevel.SelectedValue = "C" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "CL_NAME", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "DIV_NAME", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "PRD_DESCRIPTION", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "ACCT_NAME", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "DP_TM_DESC", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "SC_DESCRIPTION", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return das.getFCXMLData_PieByLevelClient(Session("ds_DASH_Comps_Pie_ByDollars"), "JT_DESC", "AMOUNT", "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, dash, "Amount: $", "D")
        End If

    End Function

    Private Sub LoadData(Optional ByVal type As String = "Month")
        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable



        'Try
        '    Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        '    If type = "Month" Then
        '        ds = dash.GetHoursByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project, count)
        '    Else
        '        ds = dash.GetHoursByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project, count)
        '    End If
        '    Session("ds_DASH_Comps_Pie_ByHours") = ds
        '    If type = "Month" Then
        '        ds = dash.GetDollarsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project, count)
        '    Else
        '        ds = dash.GetDollarsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project, count)
        '    End If
        '    Session("ds_DASH_Comps_Pie_ByDollars") = ds
        'Catch ex As Exception
        '    Me.ShowMessage(ex.Message.ToString())
        'End Try

        If View = 0 Or View = 3 Then
            LoadCharts()
        ElseIf View = 1 Or View = 2 Or View = 4 Then
            LoadChartsUtilization()
        End If


    End Sub

    Private Sub LoadCharts()
        Try
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim EmployeeTimeForecastDetailMonth As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing

            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Me.DropDownListMonth.SelectedValue, Me.DropDownListPostPeriodYear.SelectedValue)
                ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, RadComboBoxMonthTo.SelectedValue, RadComboBoxYearTo.SelectedValue)

                'JobAmountsList = AdvantageFramework.Database.Procedures.JobAmountComplexType.Load(DbContext, False, True, False, False, False, False, False, FromPostPeriod.StartDate, ToPostPeriod.EndDate, True).ToList

                If Request.QueryString("DO") = "All" Then

                    EmployeeTimeForecastDetailMonth = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, True, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, False, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)
                Else

                    EmployeeTimeForecastDetailMonth = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, True, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, False, 0, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)

                End If

            End Using

            If RadComboBoxHoursChart.SelectedValue = "Hours" Then
                LoadHoursPieChart(EmployeeTimeForecastDetail)
            ElseIf RadComboBoxHoursChart.SelectedValue = "Dollars" Then
                LoadDollarsPieChart(EmployeeTimeForecastDetail)
            End If

            If RadComboBoxByEmployee.SelectedValue <> "" Then
                LoadETFEmployee(EmployeeTimeForecastDetailMonth)
            End If

            LoadETFBudgetActual(EmployeeTimeForecastDetail)
            RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadChartsUtilization()
        Try
            Dim EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim EmployeeTimeForecastDetailClient As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim EmployeeTimeForecastDetailType As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard) = Nothing
            Dim JobAmountsList As Generic.List(Of AdvantageFramework.Database.Classes.JobAmount) = Nothing

            Dim FromPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ToPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                FromPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Me.DropDownListMonth.SelectedValue, Me.DropDownListPostPeriodYear.SelectedValue)
                ToPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, RadComboBoxMonthTo.SelectedValue, RadComboBoxYearTo.SelectedValue)

                'JobAmountsList = AdvantageFramework.Database.Procedures.JobAmountComplexType.Load(DbContext, False, True, False, False, False, False, False, FromPostPeriod.StartDate, ToPostPeriod.EndDate, True).ToList

                If Request.QueryString("DO") = "All" Then

                    EmployeeTimeForecastDetailClient = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, False, View, _Session.UserCode, True, False, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetailType = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, False, View, _Session.UserCode, False, True, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         "", Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, False, False, View, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)
                Else

                    EmployeeTimeForecastDetailClient = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, False, View, _Session.UserCode, True, False, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetailType = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, False, View, _Session.UserCode, False, True, Me.CheckboxForecastOnly.Checked)

                    EmployeeTimeForecastDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastDashboard(DbContext, DropDownListPostPeriodYear.SelectedValue, DropDownListMonth.SelectedValue, RadComboBoxYearTo.SelectedValue, RadComboBoxMonthTo.SelectedValue,
                                                                                                                                                         Session("EmpCode"), Me.CheckboxAlternateEmployee.Checked, False, 0, "", Me.RadComboBoxDepartment.SelectedValue, False, Me.CheckboxIncludeSupervisorEmployees.Checked, False, View, _Session.UserCode, False, False, Me.CheckboxForecastOnly.Checked)

                End If

            End Using

            If View = 0 Or View = 3 Then

                If RadComboBoxHoursChart.SelectedValue = "Hours" Then
                    LoadHoursPieChart(EmployeeTimeForecastDetail)
                ElseIf RadComboBoxHoursChart.SelectedValue = "Dollars" Then
                    LoadDollarsPieChart(EmployeeTimeForecastDetail)
                End If

                If RadComboBoxByEmployee.SelectedValue <> "" Then
                    LoadETFEmployee(EmployeeTimeForecastDetailClient)
                End If

                LoadETFBudgetActual(EmployeeTimeForecastDetail)
                RadGridEmployeeTimeForecastOfficeDetailJobComponents.Rebind()

            ElseIf View = 1 Or View = 2 Or View = 4 Then

                LoadHoursPieChartbyClient(EmployeeTimeForecastDetailClient)
                LoadHoursPieChartbyType(EmployeeTimeForecastDetailType)
                LoadETFDirectIndirect(EmployeeTimeForecastDetail)
                LoadETFRequiredActual(EmployeeTimeForecastDetail)

            End If



        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadHoursPieChart(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        ToolTipPrefix = "Hours: "
        Caption = ""

        NameField = "ClientName"
        ValueField = "Hours"

        Me.LabelProject.Text = "Actual Hours" '& Me.DropLevel.SelectedItem.Text

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelClientETF(RadHtmlChartHoursPieChart, EmployeeTimeForecastDetail, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub
    Private Sub LoadDollarsPieChart(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        ToolTipPrefix = "Amount: "
        Caption = ""

        NameField = "ClientName"
        ValueField = "Amount"

        Me.LabelProject.Text = "Actual Dollars"

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelClientETF(RadHtmlChartHoursPieChart, EmployeeTimeForecastDetail, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub
    Private Sub LoadETFBudgetActual(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetBudgetComparsionStackChart(RadHtmlChartStackBudgetComparison, EmployeeTimeForecastDetail)

    End Sub
    Private Sub LoadETFEmployee(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Me.LabelByLevel.Text = Me.RadComboBoxByEmployee.SelectedItem.Text

        Dashboard.GetChart_EmployeeByMonth(RadHtmlChartLineChart, EmployeeTimeForecastDetail, Me.RadComboBoxByEmployee.SelectedValue)

    End Sub
    Private Sub LoadHoursPieChartEmployee(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        ToolTipPrefix = "Hours: "
        Caption = ""

        NameField = "Employee"
        ValueField = "Hours"

        Me.LabelProject.Text = Me.RadComboBoxByEmployee.SelectedItem.Text & " (3 months)"

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByEmployeeETF(RadHtmlChartHoursPieChart, EmployeeTimeForecastDetail, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub

    Private Sub LoadHoursPieChartbyClient(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        ToolTipPrefix = "Hours: "
        Caption = ""

        NameField = "ClientName"
        ValueField = "ActualHours"

        'Me.LabelProject.Text = "Actual Hours" '& Me.DropLevel.SelectedItem.Text

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelClientEmployeeUtilization(RadHtmlChartDirectHoursByClient, EmployeeTimeForecastDetail, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub
    Private Sub LoadHoursPieChartbyType(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        ToolTipPrefix = "Hours: "
        Caption = ""

        NameField = "HoursType"
        ValueField = "Hours"

        'Me.LabelProject.Text = "Actual Hours" '& Me.DropLevel.SelectedItem.Text

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelTypeEmployeeUtilization(RadHtmlChartDirectHoursByType, EmployeeTimeForecastDetail, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub
    Private Sub LoadETFDirectIndirect(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Me.LabelByLevel.Text = Me.RadComboBoxByEmployee.SelectedItem.Text

        Dashboard.GetDirectIndirectColumnChartETF(RadHtmlChartDirectIndirect, EmployeeTimeForecastDetail)

    End Sub
    Private Sub LoadETFRequiredActual(ByVal EmployeeTimeForecastDetail As Generic.List(Of AdvantageFramework.EmployeeTimeForecast.Classes.EmployeeTimeDashboard))

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Me.LabelByLevel.Text = Me.RadComboBoxByEmployee.SelectedItem.Text

        Dashboard.GetRequiredActualColumnChartETF(RadHtmlChartRequiredActual, EmployeeTimeForecastDetail)

    End Sub

    Private Function GetNameField() As String

        Dim NameField As String = Nothing

        Select Case Me.DropLevel.SelectedValue

            Case "C"
                NameField = "CL_NAME"

            Case "CD"
                NameField = "DIV_NAME"

            Case "CDP"
                NameField = "PRD_DESCRIPTION"

            Case "AE"
                NameField = "ACCT_NAME"

            Case "dept"
                NameField = "DP_TM_DESC"

            Case "SC"
                NameField = "SC_DESCRIPTION"

            Case "JT"
                NameField = "JT_DESC"

        End Select

        GetNameField = NameField

    End Function

    Private Sub RadComboBoxHoursChart_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxHoursChart.SelectedIndexChanged
        LoadData()
    End Sub
    Private Sub RadComboBoxDepartment_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDepartment.SelectedIndexChanged
        'LoadData()
    End Sub

    Private Sub RadComboBoxByEmployee_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxByEmployee.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub RadGridEmployeeTimeForecastOfficeDetailJobComponents_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEmployeeTimeForecastOfficeDetailJobComponents.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Footer Then

                Dim footeritem As GridFooterItem = e.Item
                footeritem("GridBoundColumnForecastedHours").Text = footeritem("GridBoundColumnForecastedHours").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnActualHours").Text = footeritem("GridBoundColumnActualHours").Text.Replace("Sum :", "")
                'footeritem("GridBoundColumnForecastedAmount").Text = footeritem("GridBoundColumnForecastedAmount").Text.Replace("Sum :", "")
                'footeritem("GridBoundColumnActualAmount").Text = footeritem("GridBoundColumnActualAmount").Text.Replace("Sum :", "")
                footeritem("GridBoundColumnVarianceHours").Text = footeritem("GridBoundColumnVarianceHours").Text.Replace("Sum :", "")
                'footeritem("GridBoundColumnVarianceAmount").Text = footeritem("GridBoundColumnVarianceAmount").Text.Replace("Sum :", "")

                footeritem("GridBoundColumnClient").Text = "All Clients"

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        LoadData()
    End Sub



#End Region

End Class
