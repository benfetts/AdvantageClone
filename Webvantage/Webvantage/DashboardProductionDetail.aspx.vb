Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProductionDetail
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

#Region " Variables and Properties "

    Public OfficeCode As String = ""
    Public DeptCode As String = ""
    Public EmpCode As String = ""
    Public month As String = ""
    Public month2 As String = ""
    Public year As String = ""
    Public include As Integer = 0


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

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.InitializePieChart(RadHtmlChartIndirectHoursVsDirectPieChart, "")
        Dashboard.InitializePieChart(RadHtmlChartDirectHourByTypePieChart, "")
        Dashboard.InitializePieChart(RadHtmlChartNonDirectHoursByCategoryPieChart, "")
        Dashboard.InitializePieChart(RadHtmlChartDirectHoursByClientPieChart, "")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not Me.IsPostBack Then
                Dim oSec As New cSecurity(Session("ConnString"))
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Me.RadToolbarDashDetail.Items(3).Enabled = False
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                    Server.Transfer("NoAccess.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
        Me.EmpCode = Request.QueryString("EmpCode")
        Me.OfficeCode = Request.QueryString("Office")
        Me.DeptCode = Request.QueryString("Dept")

        If Not Me.IsPostBack Then
            loadyears()
            If Request.QueryString("year") <> "" Then
                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                    If rtb.Group = "Year" Then
                        If rtb.Value = Request.QueryString("year") Then
                            rtb.Checked = True
                        End If
                    End If
                Next
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                    If rtb.Group = "Year" Then
                        rtb.Checked = True
                        Exit For
                    End If
                Next
            End If
            loadMenus()
            If Request.QueryString("month") <> "" Then
                If Request.QueryString("month2") = "0" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value = Request.QueryString("month") Then
                                rtb.Checked = True
                            End If
                        End If
                    Next
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value >= Request.QueryString("month") And rtb.Value <= Request.QueryString("month2") Then
                                rtb.Checked = True
                            Else
                                rtb.Checked = False
                            End If
                        End If
                    Next
                End If
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                    If rtb.Text = "All" Then
                        rtb.Checked = True
                    End If
                Next
            End If
            loadOtherButtons()
            LoadData()
            If Me.OfficeCode = "" Then
                Me.Title = "Productivity Detail for All Offices\"
            Else
                Me.Title = "Productivity Detail for " & Request.QueryString("OName") & "\"
            End If
            If Me.DeptCode = "" Then
                Me.Title = Me.Title & "All Depts\"
            Else
                Me.Title = Me.Title & Request.QueryString("DName") & "\"
            End If
            If Me.EmpCode = "" Then
                Me.Title = Me.Title & "All Employees"
            Else
                Me.Title = Me.Title & Request.QueryString("EmpName")
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()
                Case "HidePopups"

            End Select
        End If

        'Clear off sessions from quote page
        Try
            If Not Me.IsPostBack Then
                'Session("DT_EST_QUOTE_FNC") = Nothing
                'Session("EstimateGridSort") = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

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

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dt As DataTable
            Dim btn As RadToolBarButton
            dt = dash.GetYearDescriptions()
            ds = dash.GetPostPeriods(Now.Date.Year)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("FIELD_NAME").ToString = "YEAR_1" Then
                        If IsDBNull(dt.Rows(i)("FIELD_DESCRIPTION")) = False AndAlso dt.Rows(i)("FIELD_DESCRIPTION").ToString <> "" Then
                            btn = New RadToolBarButton(dt.Rows(i)("FIELD_DESCRIPTION"))
                            btn.Value = ds.Tables(0).Rows(i)("Year")
                            btn.Group = "Year"
                            btn.AllowSelfUnCheck = False
                            btn.CheckOnClick = True
                            Me.RadToolbarDashDetail.Items.Add(btn)
                        End If
                    End If
                    If dt.Rows(i)("FIELD_NAME").ToString = "YEAR_2" Then
                        If IsDBNull(dt.Rows(i)("FIELD_DESCRIPTION")) = False AndAlso dt.Rows(i)("FIELD_DESCRIPTION").ToString <> "" Then
                            btn = New RadToolBarButton(dt.Rows(i)("FIELD_DESCRIPTION"))
                            btn.Value = ds.Tables(0).Rows(i)("Year")
                            btn.Group = "Year"
                            btn.AllowSelfUnCheck = False
                            btn.CheckOnClick = True
                            Me.RadToolbarDashDetail.Items.Add(btn)
                        End If
                    End If
                Next
            Else
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        btn = New RadToolBarButton(ds.Tables(0).Rows(i)("Year"))
                        btn.Value = ds.Tables(0).Rows(i)("Year")
                        btn.Group = "Year"
                        btn.AllowSelfUnCheck = False
                        btn.CheckOnClick = True
                        Me.RadToolbarDashDetail.Items.Add(btn)
                    Next
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadMenus()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim SortedPostPeriods As DataTable = Nothing
            Dim btn As RadToolBarButton
            For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            ds = dash.GetPostPeriods(year)
            If ds.Tables(1).Rows.Count > 0 Then

                With ds.Tables(1).DefaultView

                    .Sort = "PPGLMONTH asc"
                    SortedPostPeriods = .ToTable

                End With

                For i As Integer = 0 To SortedPostPeriods.Rows.Count - 1
                    btn = New RadToolBarButton(SortedPostPeriods.Rows(i)("PPDESC"))
                    btn.Value = SortedPostPeriods.Rows(i)("PPPERIOD")
                    btn.Group = SortedPostPeriods.Rows(i)("PPDESC")
                    btn.CommandName = SortedPostPeriods.Rows(i)("MONTH")
                    btn.AllowSelfUnCheck = True
                    btn.CheckOnClick = True
                    Me.RadToolbarDashDetail.Items.Add(btn)
                Next
            End If
            btn = New RadToolBarButton("All")
            btn.Value = ""
            btn.Group = "All"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDashDetail.Items.Add(btn)

            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                For i As Integer = 0 To SortedPostPeriods.Rows.Count - 1
                    If rtb.Value = SortedPostPeriods.Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, SortedPostPeriods.Rows(i)("MONTH"), 1)
                        rtb.Text = String.Format(c, "{0:MMM}", d)
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadOtherButtons()
        Try
            Dim btn As RadToolBarButton
            btn = New RadToolBarButton()
            btn.IsSeparator = True
            btn.Value = "Separator"
            Me.RadToolbarDashDetail.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDashDetail.Items.Add(btn)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashDetail_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashDetail.ButtonClick
        Try
            Dim rb As RadToolBarButton
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", year)
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                    If rtb.Checked = True Then
                        If count = 0 Then
                            count += 1
                            min = rtb.Value
                        Else
                            count += 1
                            max = rtb.Value
                        End If
                    End If
                End If
            Next
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            Select Case e.Item.Value
                Case "Selection"
                    MiscFN.ResponseRedirect("Dashboard.aspx?month=" & min & "&year=" & year & "&include=" & include & "&month2=" & max)
                Case "Summary"
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Detail"
                    MiscFN.ResponseRedirect("DashboardProductionDetail.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Employee"
                    MiscFN.ResponseRedirect("DashboardProductionEmployee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Print"
                    Dim empname As String = Request.QueryString("EmpName")
                    Dim officename As String = Request.QueryString("OName")
                    Dim deptname As String = Request.QueryString("DName")
                    Dim period As Integer
                    Dim dash As String
                    count = 0

                    If IsNumeric(Request.QueryString("include")) = True Then
                        include = CInt(Request.QueryString("include"))
                    End If

                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                        If rtb.Group = "Year" Then
                            If rtb.Checked = True Then
                                year = rtb.Value
                            End If
                        End If
                    Next

                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Checked = True Then
                                If count = 0 Then
                                    month = rtb.Value
                                    count += 1
                                Else
                                    month2 = rtb.Value
                                    count += 1
                                End If
                            End If
                        End If
                    Next

                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashproddetail&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&monthCount=" & count & "&month2=" & month2)
                Case Else
                    Dim y As String
                    Dim m As String
                    Dim countyear As Integer = 0
                    count = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                If rtb.Checked = True Then
                                    rtb.Checked = False
                                End If
                            End If
                        Next
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Min", "", "")
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Max", "", "")
                    End If
                    If e.Item.Value.Length = 6 Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                If rtb.Checked = True Then
                                    If count = 0 Then
                                        count += 1
                                        min = rtb.Value
                                    Else
                                        count += 1
                                        max = rtb.Value
                                    End If
                                End If
                            End If
                        Next
                        If count > 0 Then
                            For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                If rtb.Group = "All" Then
                                    If rtb.Checked = True Then
                                        rtb.Checked = False
                                    End If
                                End If
                            Next
                        End If
                        If count > 1 Then
                            If rb.Checked = False And CInt(e.Item.Value) < max And CInt(e.Item.Value) > min Then
                                max = e.Item.Value
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                        If CInt(rtb.Value) >= min And CInt(rtb.Value) < max Then
                                            rtb.Checked = True
                                        Else
                                            rtb.Checked = False
                                        End If
                                    End If
                                Next
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                        If CInt(rtb.Value) >= min And CInt(rtb.Value) <= max Then
                                            rtb.Checked = True
                                        Else
                                            rtb.Checked = False
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Min", "", min)
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Max", "", max)
                    End If
                    If IsNumeric(e.Item.Text) = True Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                If rtb.Checked = True Then
                                    If count = 0 Then
                                        count += 1
                                        min = rtb.Value
                                    Else
                                        count += 1
                                        max = rtb.Value
                                    End If
                                End If
                            End If
                        Next
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                            If rtb.Group = "Year" Then
                                If rtb.Checked = True Then
                                    y = rtb.Value
                                    Exit For
                                End If
                                countyear += 1
                            End If
                        Next
                        If min <> 0 Then
                            If countyear = 0 Then
                                min = min - 100
                            Else
                                min = min + 100
                            End If
                        End If
                        If max <> 0 Then
                            If countyear = 0 Then
                                max = max - 100
                            Else
                                max = max + 100
                            End If
                        End If
                        If e.Item.Text.Length = 4 Then
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("1"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("2"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("3"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("4"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("5"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("6"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("7"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("8"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("9"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("10"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("11"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindButtonByCommandName("12"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindItemByText("All"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindItemByValue("Data"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindItemByValue("Print"))
                            Me.RadToolbarDashDetail.Items.Remove(Me.RadToolbarDashDetail.FindItemByValue("Separator"))
                            loadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                                            If CInt(rtb.Value) >= min And CInt(rtb.Value) <= max Then
                                                rtb.Checked = True
                                            Else
                                                rtb.Checked = False
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
                                    If rtb.Text = "All" Then
                                        rtb.Checked = True
                                    End If
                                Next
                            End If

                        End If
                        LoadData()
                    Else
                        LoadData()
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Public Function WriteXMLDirectHoursByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectHoursByClient"), "CL_NAME", "BILLABLE", "", True)
    End Function

    Public Function WriteXMLAgency() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectHoursWithAgency"), "", "agency")
    End Function

    Public Function WriteXMLNewBusiness() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectHoursWithNewBusiness"), "", "newbusiness")
    End Function

    Public Function WriteXMLHours() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_PieDirectHours(Session("ds_DASH_DetailHours"), "", "", "", True)
    End Function

    Public Function WriteXMLDirectvsNondirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectvsNondirect"), "COL", "HOURS", "", True)
    End Function

    Private Sub LoadData()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
            If rtb.Group = "Year" Then
                If rtb.Checked = True Then
                    year = rtb.Value
                End If
            End If
        Next
        Dim count As Integer = 0

        For Each rtb As RadToolBarButton In Me.RadToolbarDashDetail.Items
            If rtb.Value.Length = 6 And rtb.Text <> "Detail" Then
                If rtb.Checked = True Then
                    If count = 0 Then
                        month = rtb.Value
                        count += 1
                    Else
                        month2 = rtb.Value
                        count += 1
                    End If
                End If
            End If
            If rtb.Text = "All" Then
                If rtb.Checked = True Then
                    month = rtb.Value
                End If
            End If
        Next

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetNonDirectHours(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_NonDirect") = ds
            ds = dash.GetBillableHoursByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectHoursByClient") = ds
            'ds = dash.GetDirectHoursWithAgency(EmpCode, 0, month, year)
            'Session("ds_DASH_DirectHoursWithAgency") = ds
            'ds = dash.GetDirectHoursWithNewBusiness(EmpCode, 0, month, year)
            'Session("ds_DASH_DirectHoursWithNewBusiness") = ds
            ds = dash.GetDirectWithNonDirect(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsNondirect") = ds
            ds = dash.GetDetailHours(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DetailHours") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        CreatePieCharts()

    End Sub
    Private Sub CreatePieCharts()

        CreatePieChart(RadHtmlChartIndirectHoursVsDirectPieChart, Session("ds_DASH_DirectvsNondirect"), "COL", "HOURS", "")
        CreateDirectHoursPieChart(RadHtmlChartDirectHourByTypePieChart, Session("ds_DASH_DetailHours"), "")
        CreatePieChart(RadHtmlChartNonDirectHoursByCategoryPieChart, Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "")
        CreatePieChart(RadHtmlChartDirectHoursByClientPieChart, Session("ds_DASH_DirectHoursByClient"), "CL_NAME", "BILLABLE", "")

    End Sub
    Private Sub CreatePieChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal NameField As String, ByVal ValueField As String, ByVal Caption As String)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

        If RadHtmlChart IsNot Nothing Then

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetPieChart(RadHtmlChart, DataSet, NameField, ValueField, Caption)

        End If

    End Sub
    Private Sub CreateDirectHoursPieChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal Caption As String)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

        If RadHtmlChart IsNot Nothing Then

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetPieChart_DirectHours(RadHtmlChart, DataSet, Caption)

        End If

    End Sub

#End Region
    
End Class