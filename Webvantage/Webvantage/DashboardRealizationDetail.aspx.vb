Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal.InfoSoftGlobal



Partial Public Class DashboardRealizationDetail
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
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public include As Integer = 0
    Public period As Integer = 0


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

    Private Sub DashboardRealizationDetail_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.InitializeColumnChart_ClientTotals(RadHtmlChartClientTotalsChart, "")
        Dashboard.InitializePieChart(RadHtmlChartPercentBilledByClientPieChart, "")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            If Not Me.IsPostBack Then
                Dim oSec As New cSecurity(Session("ConnString"))
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                    Me.RadToolbarDash.Items(3).Enabled = False
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
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Group = "Year" Then
                        If rtb.Value = Request.QueryString("year") Then
                            rtb.Checked = True
                        End If
                    End If
                Next
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Group = "Year" Then
                        rtb.Checked = True
                        Exit For
                    End If
                Next
            End If
            loadMenus()
            If Request.QueryString("month") <> "" Then
                If Request.QueryString("month2") = "0" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                            If rtb.Value = Request.QueryString("month") Then
                                rtb.Checked = True
                            End If
                        End If
                    Next
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                            If rtb.Value >= Request.QueryString("month") And rtb.Value <= Request.QueryString("month2") Then
                                rtb.Checked = True
                            Else
                                rtb.Checked = False
                            End If
                        End If
                    Next
                End If
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Text = "All" Then
                        rtb.Checked = True
                    End If
                Next
            End If
            loadOtherButtons()
            LoadData()
            'updateChart()
            'LoadGrid()
            Me.RadGridAvgHourlyPrd.Visible = False
            If Me.OfficeCode = "" Then
                Me.Title = "Realization Detail for All Offices\"
            Else
                Me.Title = "Realization Detail for " & Request.QueryString("OName") & "\"
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

            LoadData()

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
            Dim empname As String = Request.QueryString("EmpName")
            Dim officename As String = Request.QueryString("OName")
            Dim deptname As String = Request.QueryString("DName")
            Dim period As Integer
            Dim dash As String
            Dim clname As String
            Dim grid As String = ""
            Dim count As Integer = 0
            Dim max As Integer = 0

            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If

            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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

            If Me.cbShowProducts.Checked = True Then
                grid = "product"
            End If

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvgHourly.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    clname = gridDataItem.GetDataKeyValue("CL_NAME")
                End If
            Next

            Me.butExport.Attributes.Add("onclick", "window.open('DashboardPrint.aspx?From=dashrealdetail&export=1&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&grid=" & grid & "&monthCount=" & count & "&month2=" & month2 & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    Private Sub RadGridAvgHourly_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAvgHourly.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAvgHourly_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvgHourly.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridAvgHourly.DataSource = dash.GetAvgHourlyRateByClient(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAvgHourly_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAvgHourly.SelectedIndexChanged
        Try
            Dim clname As String
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvgHourly.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    clname = gridDataItem.GetDataKeyValue("CL_NAME")
                    'division = gridDataItem.GetDataKeyValue("DIVISION")
                    'product = gridDataItem.GetDataKeyValue("PRODUCT")
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                    If rtb.Checked = True Then
                        month = rtb.Value
                    End If
                End If
            Next
            LoadData()
            Me.lblClient.Text = "Client Totals (Amounts) for " & clname
            'updateChart()
            'MiscFN.ResponseRedirect("DashboardRealizationJob.aspx?client=" & client & "&division=" & division & "&product=" & product & "&month=" & month & "&year=" & year)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAvgHourlyPrd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvgHourlyPrd.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridAvgHourlyPrd.DataSource = dash.GetAvgHourlyRateByProduct(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAvgHourlyPrd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAvgHourlyPrd.SelectedIndexChanged
        Try
            'Dim client As String
            'Dim division As String
            'Dim product As String
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvgHourlyPrd.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    division = gridDataItem.GetDataKeyValue("DIVISION")
                    product = gridDataItem.GetDataKeyValue("PRODUCT")
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                    If rtb.Checked = True Then
                        month = rtb.Value
                    End If
                End If
            Next
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            LoadData()
            'MiscFN.ResponseRedirect("DashboardRealizationClient.aspx?EmpCode=" & Me.EmpCode & "&client=" & client & "&division=" & division & "&product=" & product & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&EmpName=" & Request.QueryString("EmpName") & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName"))

        Catch ex As Exception

        End Try
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
                            Me.RadToolbarDash.Items.Add(btn)
                        End If
                    End If
                    If dt.Rows(i)("FIELD_NAME").ToString = "YEAR_2" Then
                        If IsDBNull(dt.Rows(i)("FIELD_DESCRIPTION")) = False AndAlso dt.Rows(i)("FIELD_DESCRIPTION").ToString <> "" Then
                            btn = New RadToolBarButton(dt.Rows(i)("FIELD_DESCRIPTION"))
                            btn.Value = ds.Tables(0).Rows(i)("Year")
                            btn.Group = "Year"
                            btn.AllowSelfUnCheck = False
                            btn.CheckOnClick = True
                            Me.RadToolbarDash.Items.Add(btn)
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
                        Me.RadToolbarDash.Items.Add(btn)
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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
                    Me.RadToolbarDash.Items.Add(btn)
                Next
            End If
            btn = New RadToolBarButton("All")
            btn.Value = ""
            btn.Group = "All"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)

            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDash_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDash.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim rb As RadToolBarButton
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", year)
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Select Case e.Item.Value
                Case "Selection"
                    MiscFN.ResponseRedirect("Dashboard.aspx?month=" & min & "&year=" & year & "&include=" & include & "&month2=" & max)
                Case "Summary"
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Detail"
                    MiscFN.ResponseRedirect("DashboardRealizationDetail.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Client"
                    MiscFN.ResponseRedirect("DashboardRealizationClient.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Employee"
                    MiscFN.ResponseRedirect("DashboardRealizationEmployee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Fee"
                    MiscFN.ResponseRedirect("DashboardRealizationFee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Print"
                    Dim empname As String = Request.QueryString("EmpName")
                    Dim officename As String = Request.QueryString("OName")
                    Dim deptname As String = Request.QueryString("DName")
                    Dim period As Integer
                    Dim dash As String
                    Dim clname As String
                    Dim grid As String = ""
                    count = 0

                    If IsNumeric(Request.QueryString("include")) = True Then
                        include = CInt(Request.QueryString("include"))
                    End If

                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Group = "Year" Then
                            If rtb.Checked = True Then
                                year = rtb.Value
                            End If
                        End If
                    Next
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAvgHourly.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("CLIENT")
                            clname = gridDataItem.GetDataKeyValue("CL_NAME")
                        End If
                    Next

                    If Me.cbShowProducts.Checked = True Then
                        grid = "product"
                    End If

                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashrealdetail&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&grid=" & grid & "&monthCount=" & count & "&month2=" & month2)
                Case Else
                    Dim y As String
                    Dim m As String
                    count = 0
                    Dim countyear As Integer = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                                If rtb.Checked = True Then
                                    rtb.Checked = False
                                End If
                            End If
                        Next
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Min", "", "")
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Max", "", "")
                    End If
                    If e.Item.Value.Length = 6 Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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
                                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                                        If CInt(rtb.Value) >= min And CInt(rtb.Value) < max Then
                                            rtb.Checked = True
                                        Else
                                            rtb.Checked = False
                                        End If
                                    End If
                                Next
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
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
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("1"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("2"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("3"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("4"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("5"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("6"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("7"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("8"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("9"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("10"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("11"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindButtonByCommandName("12"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByText("All"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Data"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Print"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Separator"))
                            loadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                                            If CInt(rtb.Value) >= min And CInt(rtb.Value) <= max Then
                                                rtb.Checked = True
                                            Else
                                                rtb.Checked = False
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                    If rtb.Text = "All" Then
                                        rtb.Checked = True
                                    End If
                                Next
                            End If

                        End If
                        LoadData()
                        Me.RadGridAvgHourly.Rebind()
                        Me.RadGridAvgHourlyPrd.Rebind()
                    Else
                        LoadData()
                        Me.RadGridAvgHourly.Rebind()
                        Me.RadGridAvgHourlyPrd.Rebind()
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbShowProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowProducts.CheckedChanged
        Try
            If Me.cbShowProducts.Checked = True Then
                Me.RadGridAvgHourly.Visible = False
                Me.RadGridAvgHourlyPrd.Visible = True
            Else
                Me.RadGridAvgHourly.Visible = True
                Me.RadGridAvgHourlyPrd.Visible = False
            End If
            Me.RadGridAvgHourly.Rebind()
            Me.RadGridAvgHourlyPrd.Rebind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXMLDirectvsNondirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectvsNondirect"), "COL", "HOURS", "", True)
    End Function

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarPie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Public Function WriteXMLAvgHourlyRate() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Bar(Session("ds_DASH_AvgHourlyRateByClient"), "CL_NAME", "AVG_RATE", "", False)
    End Function

    Public Function WriteXMLClientTotals() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarClientTotals(Session("ds_DASH_ClientTotals"), "", "", "", False)
    End Function

    Public Function WriteXMLPercentBilledByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Dim count As Integer = 0
        Dim max As Integer = 0
        Dim min As Integer = 0
        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
            If rtb.Group = "Year" Then
                If rtb.Checked = True Then
                    year = rtb.Value
                End If
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If
        Return dash.getFCXMLData_PieRealization(Session("ds_DASH_PercentBilledByClient"), "CL_NAME", "PERCENT_BILLED", "", True, "", max, year, Me.EmpCode, min)
    End Function

    Private Sub LoadData()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
            If rtb.Group = "Year" Then
                If rtb.Checked = True Then
                    year = rtb.Value
                End If
            End If
        Next
        Dim count As Integer = 0
        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetAvgHourlyRateByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_AvgHourlyRateByClient") = ds
            ds = dash.GetDirectWithNonDirect(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsNondirect") = ds
            ds = dash.GetPercentBilledByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Me.period, Session("UserCode"), month2)
            Session("ds_DASH_PercentBilledByClient") = ds
            ds = dash.GetClientTotals(EmpCode, month, year, client, Me.OfficeCode, Me.DeptCode, Me.period, Session("UserCode"), month2)
            Session("ds_DASH_ClientTotals") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        CreateCharts()

    End Sub

    Private Sub CreateCharts()

        CreateChart(RadHtmlChartClientTotalsChart, Session("ds_DASH_ClientTotals"), "")
        CreatePieChart(RadHtmlChartPercentBilledByClientPieChart, Session("ds_DASH_PercentBilledByClient"), "")

    End Sub
    Private Sub CreateChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal Caption As String)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

        If RadHtmlChart IsNot Nothing Then

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetColumnChart_ClientTotals(RadHtmlChart, DataSet, Caption)

        End If

    End Sub
    Private Sub CreatePieChart(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal Caption As String)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim Month As String = Nothing
        Dim Month2 As String = Nothing
        Dim Year As String = Nothing
        Dim Count As Integer = 0

        For Each RadToolBarButton In Me.RadToolbarDash.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Group = "Year" Then

                If RadToolBarButton.Checked = True Then

                    Year = RadToolBarButton.Value

                End If

            End If

            If RadToolBarButton.Value.Length = 6 AndAlso RadToolBarButton.Text <> "Detail" AndAlso RadToolBarButton.Text <> "Client" Then

                If RadToolBarButton.Checked = True Then

                    If Count = 0 Then

                        Count += 1
                        Month = RadToolBarButton.Value

                    Else

                        Count += 1
                        Month2 = RadToolBarButton.Value

                    End If

                End If

            End If

        Next
        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If

        If RadHtmlChart IsNot Nothing Then

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetPieChart_Realization(RadHtmlChart, DataSet, "CL_NAME", "PERCENT_BILLED", "", Month, Year, Me.EmpCode, Month2)

            HiddenFieldEmployeeCode.Value = Me.EmpCode
            HiddenFieldMonth.Value = Month
            HiddenFieldMonth2.Value = Month2
            HiddenFieldYear.Value = Year
            HiddenFieldPeriod.Value = period

        End If

    End Sub

    'Private Sub updateChart()
    '    Try
    '        Dim strXML As String
    '        Dim output As String

    '        strXML = WriteXMLClientTotals()

    '        If Not Me.IsPostBack Then
    '            output = FusionCharts.RenderChartHTML("../Flash/Column3D.swf", "", strXML.ToString(), "chart" & Now.Millisecond.ToString(), "400", "350", False)
    '        Else
    '            output = FusionCharts.RenderChart("../Flash/Column3D.swf", "", strXML.ToString(), "chart" & Now.Millisecond.ToString(), "400", "350", False, False)
    '        End If

    '        Me.lit.Text = output

    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

End Class
