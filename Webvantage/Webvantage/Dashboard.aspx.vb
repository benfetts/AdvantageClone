Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal.InfoSoftGlobal

Partial Public Class Dashboard
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

#Region " Variables "



#End Region

#Region " Properties "

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
    Public Property DeptCode As String = ""
    Public Property OfficeCode As String = ""
    Public Property Year As String = ""
    Public Property Month As String = ""
    Public Property Month2 As String = ""
    Public Property EmpCode As String = ""
    Public Property dashboard As String = ""
    Public Property include As Integer = 0

#End Region

#Region " Methods "

    Private Sub LoadData()

        'objects
        Dim DataSet As System.Data.DataSet = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim Tasks As Webvantage.cTasks = Nothing
        Dim TaskVar As String = Nothing
        Dim Counter As Integer = 0

        Session("ds_DASH_Departments") = ""
        Session("ds_DASH_Departments") = Nothing
        Session("ds_DASH_Employees") = ""
        Session("ds_DASH_Employees") = Nothing

        For Each RadToolBarButton In Me.RadToolbarDash.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Group = "Year" Then

                If RadToolBarButton.Checked = True Then

                    Me.Year = RadToolBarButton.Value

                End If

            End If

            If RadToolBarButton.Value.Length = 6 Then

                If RadToolBarButton.Checked = True Then

                    If Counter = 0 Then

                        Month = RadToolBarButton.Value

                    Else

                        Month2 = RadToolBarButton.Value

                    End If

                    Counter += 1

                End If

            End If

        Next

        Tasks = New Webvantage.cTasks(_Session.ConnectionString)

        TaskVar = Tasks.getAppVars(Session("UserCode"), "DashboardEmp", "DeptCode")

        If Not String.IsNullOrWhiteSpace(TaskVar) Then

            Me.DeptCode = TaskVar

        End If

        TaskVar = Tasks.getAppVars(Session("UserCode"), "DashboardEmp", "OfficeCode")

        If Not String.IsNullOrWhiteSpace(TaskVar) Then

            Me.OfficeCode = TaskVar

        End If

        Try

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            DataSet = Dashboard.GetOfficeData(Me.OfficeCode, Month, Me.Year, Session("UserCode"), Month2)
            Session("ds_DASH_Offices") = DataSet
            LoadOfficeChart(DataSet)

            DataSet = Dashboard.GetDeptData(Me.OfficeCode, Month, Me.Year, Me.DeptCode, Session("UserCode"), Month2)
            Session("ds_DASH_Departments") = DataSet
            LoadDepartmentTeamChart(DataSet)

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub
    Private Sub LoadOfficeChart(ByVal DataSet As System.Data.DataSet)

        'objects
        Dim cDashboard As Webvantage.cDashboard = Nothing

        cDashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        cDashboard.GetDirectAndNonDirectColumnChart(RadHtmlChartOffice, DataSet, "")

    End Sub
    Private Sub LoadDepartmentTeamChart(ByVal DataSet As System.Data.DataSet)

        'objects
        Dim cDashboard As Webvantage.cDashboard = Nothing

        cDashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        cDashboard.GetDirectAndNonDirectBarChart(RadHtmlChartDepartmentTeamChart, DataSet, "", "dept")

    End Sub
    Private Function getSecurityOffice()
        Try
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper

            SQL_STRING = " SELECT OFFICE.OFFICE_CODE, OFFICE_NAME "
            SQL_STRING += " FROM OFFICE INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE"
            SQL_STRING += " WHERE ((INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG = 0)) AND EMP_OFFICE.EMP_CODE = '" & Session("EmpCode") & "'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:dash.ascx Routine:AddControl", Err.Description)
            Finally

            End Try
            Dim office As String
            If dr.HasRows = True Then
                Do While dr.Read
                    office &= dr("OFFICE_CODE") & ","
                Loop
            End If
            Return MiscFN.RemoveTrailingDelimiter(office, ",")
        Catch ex As Exception

        End Try
    End Function
    Private Sub LoadYears()
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
    Private Sub LoadMenus()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim btn As RadToolBarButton
            Dim SortedPostPeriods As DataTable = Nothing
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        Year = rtb.Value
                    End If
                End If
            Next
            ds = dash.GetPostPeriods(Year)
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
                'Else
                '    Me.ShowMessage("Two years of posting periods are required to view the data correctly.")
                '    Exit Sub
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
            btn = New RadToolBarButton("Refresh Data")
            btn.Value = "Data"
            btn.Group = "Data"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonBookmark"
            btn.Value = "Bookmark"
            btn.Group = "Bookmark"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub
    Private Function ResetForm()
        Me.Session("_ds") = Nothing
    End Function
    Private Sub LoadDateTime()
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Try
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value = "Data" Then
                    rtb.ToolTip = "Data last updated on " & dash.GetTime()
                End If
            Next
            'Me.lblUpdate.Text = "Data last updated on " & dash.GetTime()
        Catch ex As Exception

        End Try
    End Sub

#Region " Page Methods "

    Private Sub Dashboard_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.InitializeDirectAndNonDirectColumnChart(RadHtmlChartOffice, "")
        Dashboard.InitializeDirectAndNonDirectBarChart(RadHtmlChartDepartmentTeamChart, "")

    End Sub
    Protected Sub Dashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Dim taskVar As String
        Dim taskVar2 As String
        Dim check As Boolean = False
        Try
            If Not Me.IsPostBack Then
                Dim oSec As New cSecurity(Session("ConnString"))
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Productivity" Then
                            rtb.Checked = True
                        End If
                        If rtb.Value = "Realization" Then
                            rtb.Checked = False
                            rtb.Enabled = False
                        End If
                    Next
                    Me.rbDateEntered.Visible = False
                    Me.rbPeriodBilled.Visible = False
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Productivity" Then
                            rtb.Checked = False
                            rtb.Enabled = False
                        End If
                        If rtb.Value = "Realization" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.rbDateEntered.Visible = True
                    Me.rbPeriodBilled.Visible = True
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Productivity" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.rbDateEntered.Visible = False
                    Me.rbPeriodBilled.Visible = False
                End If
                Dim dsYears As DataSet
                dsYears = dash.GetPostPeriods(Now.Date.Year)
                If dsYears.Tables(0).Rows.Count = 0 Then
                    Me.ShowMessage("No post periods for current year were found.")
                    Me.RadComboEmps.Enabled = False
                    Me.RadGridOffice.Enabled = False
                    Me.RadGridOffice.ClientSettings.Selecting.AllowRowSelect = False
                    Me.RadGrid1.Enabled = False
                    Me.RadGrid1.ClientSettings.Selecting.AllowRowSelect = False
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
        If Not Me.IsPostBack Then
            LoadYears()
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "Year")
            If Request.QueryString("year") <> "" Then
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Group = "Year" Then
                        If rtb.Value = Request.QueryString("year") Then
                            rtb.Checked = True
                        End If
                    End If
                Next
            ElseIf taskVar <> "" Then
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Group = "Year" Then
                        If rtb.Value = taskVar Then
                            rtb.Checked = True
                            check = True
                        End If
                    End If
                Next
                If check = False Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Group = "Year" Then
                            rtb.Checked = True
                            Exit For
                        End If
                    Next
                End If
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                    If rtb.Group = "Year" Then
                        rtb.Checked = True
                        Exit For
                    End If
                Next
            End If
            LoadMenus()
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "Min")
            taskVar2 = otask.getAppVars(Session("UserCode"), "DashboardEmp", "Max")
            If Request.QueryString("month") <> "" Then
                If Request.QueryString("month2") = "0" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value = Request.QueryString("month") Then
                                rtb.Checked = True
                            End If
                        End If
                    Next
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value >= Request.QueryString("month") And rtb.Value <= Request.QueryString("month2") Then
                                rtb.Checked = True
                            Else
                                rtb.Checked = False
                            End If
                        End If
                    Next
                End If
            ElseIf taskVar <> "" Then
                If taskVar2 = "0" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value = taskVar Then
                                rtb.Checked = True
                            End If
                        End If
                    Next
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value >= taskVar And rtb.Value <= taskVar2 Then
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
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
                If include = 1 Then
                    Me.cbEmp.Checked = True
                End If
            End If
            loadOtherButtons()

            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "OfficeCode")
            If taskVar <> "" Then
                Me.OfficeCode = taskVar
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "DeptCode")
            If taskVar <> "" Then
                Me.DeptCode = taskVar
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "DateEntered")
            If taskVar <> "" Then
                Me.rbDateEntered.Checked = taskVar
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "PeriodBilled")
            If taskVar <> "" Then
                Me.rbPeriodBilled.Checked = taskVar
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "IncludeTerminated")
            If taskVar <> "" Then
                Me.cbEmp.Checked = taskVar
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "Dash")
            If taskVar <> "" Then
                If taskVar = "Productivity" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Productivity" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.rbDateEntered.Visible = False
                    Me.rbPeriodBilled.Visible = False
                End If
                If taskVar = "Realization" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Realization" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.rbDateEntered.Visible = True
                    Me.rbPeriodBilled.Visible = True
                End If
            End If

            LoadData()
            'updateChart()
            LoadDateTime()

        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    'Me.RadWindowManagerEstimate.Windows(0).VisibleOnPageLoad = False
                    'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()
                Case "Data"
                    'Dim download As Boolean
                    ''If e.Item.Value = "Data" Then                    
                    'download = dash.GetDataRefresh(Me.radMenu2.Items(0).Text, Me.radMenu2.Items(1).Text, Session("UserCode"))
                    ''End If
                    'Me.radMenu4.Items(0).Selected = False
                    'Me.RadGridOffice.Rebind()
                    'Me.RadGrid1.Rebind()
                    ''Me.RadGridEmps.Rebind()
                    'LoadData()
                    'LoadDateTime()
                Case "Prt"
                    'Me.radMenu4.Items(0).Selected = False
                    'Me.radMenu5.Items(0).Selected = False
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

#End Region

#Region " Control Event Handlers "

    Private Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet = dash.GetDepts(Me.OfficeCode, Session("UserCode"))
            Dim newrow As DataRow
            newrow = ds.Tables(0).NewRow
            newrow.Item("DP_TM_CODE") = ""
            newrow.Item("DP_TM_DESC") = "All Departments"
            ds.Tables(0).Rows.InsertAt(newrow, 0)
            Me.RadGrid1.DataSource = ds
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "DeptCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem.GetDataKeyValue("DP_TM_CODE") = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode &= gridDataItem.GetDataKeyValue("DP_TM_CODE") & ","
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode &= gridDataItem.GetDataKeyValue("OFFICE_CODE") & ","
                End If
            Next
            OfficeCode = MiscFN.RemoveTrailingDelimiter(OfficeCode, ",")
            DeptCode = MiscFN.RemoveTrailingDelimiter(DeptCode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "OfficeCode", "", OfficeCode)
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "DeptCode", "", DeptCode)
            LoadData()

            'Me.RadGridEmps.Rebind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridOffice_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridOffice.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet = dash.GetOffices(Session("UserCode"))
            Dim newrow As DataRow
            newrow = ds.Tables(0).NewRow
            newrow.Item("OFFICE_CODE") = ""
            newrow.Item("OFFICE_NAME") = "All Offices"
            ds.Tables(0).Rows.InsertAt(newrow, 0)
            Me.RadGridOffice.DataSource = ds


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridOffice_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridOffice.PreRender
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardEmp", "OfficeCode")
            If taskVar <> "" Then
                Dim str() As String = taskVar.Split(",")
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                    For i As Integer = 0 To str.Count - 1
                        If gridDataItem.GetDataKeyValue("OFFICE_CODE") = str(i) Then
                            gridDataItem.Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridOffice.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode &= gridDataItem.GetDataKeyValue("OFFICE_CODE") & ","
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode &= gridDataItem.GetDataKeyValue("DP_TM_CODE") & ","
                End If
            Next
            OfficeCode = MiscFN.RemoveTrailingDelimiter(OfficeCode, ",")
            DeptCode = MiscFN.RemoveTrailingDelimiter(DeptCode, ",")
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "OfficeCode", "", OfficeCode)
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "DeptCode", "", DeptCode)
            LoadData()
            Me.RadGrid1.Rebind()

            'Me.RadGridEmps.Rebind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadToolbarDash_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDash.ButtonClick
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim rb As RadToolBarButton
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            Select Case e.Item.Value
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    Me.rbDateEntered.Visible = False
                    Me.rbPeriodBilled.Visible = False
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    Me.rbDateEntered.Visible = True
                    Me.rbPeriodBilled.Visible = True
                Case "Bookmark"
                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()

                    qs.Page = "Dashboard.aspx"

                    qs.Add("bm", "1")

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_EmployeeUtilization
                        .UserCode = Session("UserCode")
                        .Name = "Employee Utilization"
                        .Description = "Employee Utilization"
                        .PageURL = qs.ToString(True)

                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then

                        Me.ShowMessage(s)

                    Else

                        ' Me.RefreshBookmarksDesktopObject()

                    End If
                Case "Data"
                    Dim download As Boolean
                    Dim year1 As String
                    Dim year2 As String
                    download = dash.GetDataRefresh(Me.RadToolbarDash.Items(3).Value, Me.RadToolbarDash.Items(4).Value, Session("UserCode"))
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Data" Then
                            rtb.Checked = False
                        End If
                    Next
                    Me.RadGridOffice.Rebind()
                    Me.RadGrid1.Rebind()
                    LoadData()
                    LoadDateTime()
                Case "Print"
                    Dim empname As String
                    Dim officename As String
                    Dim deptname As String
                    Dim period As Integer
                    Dim dashb As String
                    Dim countOffice As Integer = 0
                    Dim countDept As Integer = 0
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            DeptCode &= gridDataItem.GetDataKeyValue("DP_TM_CODE") & ","
                            deptname = gridDataItem.GetDataKeyValue("DP_TM_DESC")
                            countDept += 1
                        End If
                    Next
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            OfficeCode &= gridDataItem.GetDataKeyValue("OFFICE_CODE") & ","
                            officename = gridDataItem.GetDataKeyValue("OFFICE_NAME")
                            countOffice += 1
                        End If
                    Next
                    OfficeCode = MiscFN.RemoveTrailingDelimiter(OfficeCode, ",")
                    DeptCode = MiscFN.RemoveTrailingDelimiter(DeptCode, ",")

                    If countOffice > 1 Then
                        officename = "Multiple Offices"
                    End If
                    If countDept > 1 Then
                        deptname = "Multiple Departments"
                    End If

                    If EmpCode = "All" Then
                        EmpCode = ""
                    End If
                    If Me.cbEmp.Checked = True Then
                        include = 1
                    Else
                        include = 0
                    End If
                    If Me.rbDateEntered.Checked = True Then
                        period = 0
                    End If
                    If Me.rbPeriodBilled.Checked = True Then
                        period = 1
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Group = "Dash" Then
                            If rtb.Checked = True Then
                                dashb = rtb.Value
                            End If
                        End If
                    Next
                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dash&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dashb & "&month2=" & month2)
                Case Else
                    Dim y As String
                    Dim m As String
                    Dim countyear As Integer = 0
                    count = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 Then
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
                            If rtb.Value.Length = 6 Then
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
                                    If rtb.Value.Length = 6 Then
                                        If CInt(rtb.Value) >= min And CInt(rtb.Value) < max Then
                                            rtb.Checked = True
                                        Else
                                            rtb.Checked = False
                                        End If
                                    End If
                                Next
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                    If rtb.Value.Length = 6 Then
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
                            If rtb.Value.Length = 6 Then
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
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Bookmark"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Separator"))
                            LoadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 Then
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
                    Else
                        LoadData()
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Group = "Year" Then
                            If rtb.Checked = True Then
                                y = rtb.Value
                                otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", y)
                                Exit For
                            End If
                        End If
                    Next
                    Me.RadGrid1.Rebind()
                    Me.RadGridOffice.Rebind()
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbEmp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEmp.CheckedChanged
        Try
            If Me.cbEmp.Checked = True Then
                include = 1
            Else
                include = 0
            End If
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode = gridDataItem.GetDataKeyValue("OFFICE_CODE")
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode = gridDataItem.GetDataKeyValue("DP_TM_CODE")
                End If
            Next
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "IncludeTerminated", "", Me.cbEmp.Checked)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ddEmps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddEmps.SelectedIndexChanged
        Try
            Dim empname As String
            Dim officename As String
            Dim deptname As String
            Dim period As Integer
            'For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEmps.MasterTableView.Items
            '    If gridDataItem.Selected = True Then
            '        EmpCode = gridDataItem.GetDataKeyValue("EMP_CODE")
            '        empname = gridDataItem.GetDataKeyValue("EMP_DESC")
            '    End If
            'Next
            EmpCode = Me.ddEmps.SelectedValue
            empname = Me.ddEmps.SelectedItem.Text
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode = gridDataItem.GetDataKeyValue("DP_TM_CODE")
                    deptname = gridDataItem.GetDataKeyValue("DP_TM_DESC")
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode = gridDataItem.GetDataKeyValue("OFFICE_CODE")
                    officename = gridDataItem.GetDataKeyValue("OFFICE_NAME")
                End If
            Next
            If EmpCode = "All" Then
                EmpCode = ""
            End If
            If Me.cbEmp.Checked = True Then
                include = 1
            Else
                include = 0
            End If
            If Me.rbDateEntered.Checked = True Then
                period = 0
            End If
            If Me.rbPeriodBilled.Checked = True Then
                period = 1
            End If
            LoadData()
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Text = "Productivity" Then
                    If rtb.Checked = True Then
                        Me.CloseThisWindowAndOpenNewWindow("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & Month & "&year=" & Year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname)
                    End If
                End If
                If rtb.Text = "Realization" Then
                    If rtb.Checked = True Then
                        Me.CloseThisWindowAndOpenNewWindow("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & Month & "&year=" & Year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadListEmps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListEmps.SelectedIndexChanged
        Try
            Dim empname As String
            Dim officename As String
            Dim deptname As String
            Dim period As Integer
            EmpCode = Me.RadListEmps.SelectedItem.Value
            empname = Me.RadListEmps.SelectedItem.Text
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode = gridDataItem.GetDataKeyValue("DP_TM_CODE")
                    deptname = gridDataItem.GetDataKeyValue("DP_TM_DESC")
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode = gridDataItem.GetDataKeyValue("OFFICE_CODE")
                    officename = gridDataItem.GetDataKeyValue("OFFICE_NAME")
                End If
            Next
            If EmpCode = "All" Then
                EmpCode = ""
            End If
            If Me.cbEmp.Checked = True Then
                include = 1
            Else
                include = 0
            End If
            If Me.rbDateEntered.Checked = True Then
                period = 0
            End If
            If Me.rbPeriodBilled.Checked = True Then
                period = 1
            End If
            LoadData()
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Text = "Productivity" Then
                    If rtb.Checked = True Then
                        Me.CloseThisWindowAndOpenNewWindow("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname)
                    End If
                End If
                If rtb.Text = "Realization" Then
                    If rtb.Checked = True Then
                        Me.CloseThisWindowAndOpenNewWindow("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadComboEmps_ItemsRequested(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboEmps.ItemsRequested
        Try
            Me.RadComboEmps.Items.Clear()
            Dim count As Integer = 0
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet = dash.GetEmps(Me.DeptCode, Me.OfficeCode, Me.cbEmp.Checked, e.Text, Session("UserCode"))
            Dim newRow As DataRow
            newRow = ds.Tables(0).NewRow
            With newRow
                .Item("EMP_CODE") = "All"
                .Item("EMP_DESC") = "All Employees"
            End With
            ds.Tables(0).Rows.InsertAt(newRow, 0)
            Dim itemsPerRequest As Integer = 100
            Dim itemOffset As Integer = e.NumberOfItems - 1
            Dim endoffset As Integer = itemOffset + itemsPerRequest
            If endoffset > ds.Tables(0).Rows.Count Then
                endoffset = ds.Tables(0).Rows.Count
            End If
            Dim i As Integer = itemOffset
            While i < endoffset
                Me.RadComboEmps.Items.Add(New RadComboBoxItem(ds.Tables(0).Rows(i)("EMP_DESC"), ds.Tables(0).Rows(i)("EMP_CODE")))
                i += 1
            End While
            If ds.Tables(0).Rows.Count > 0 Then
                e.Message = [String].Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>",
                                            endoffset.ToString(), ds.Tables(0).Rows.Count.ToString())
            Else
                e.Message = "No matches"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadComboEmps_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboEmps.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim empname As String
            Dim officename As String
            Dim deptname As String
            Dim period As Integer
            Dim offices As String
            Dim countOffice As Integer = 0
            Dim countDept As Integer = 0
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            EmpCode = e.Value
            empname = e.Text
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    DeptCode &= gridDataItem.GetDataKeyValue("DP_TM_CODE") & ","
                    deptname = gridDataItem.GetDataKeyValue("DP_TM_DESC")
                    countDept += 1
                End If
            Next
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    OfficeCode &= gridDataItem.GetDataKeyValue("OFFICE_CODE") & ","
                    officename = gridDataItem.GetDataKeyValue("OFFICE_NAME")
                    countOffice += 1
                End If
            Next
            OfficeCode = MiscFN.RemoveTrailingDelimiter(OfficeCode, ",")
            DeptCode = MiscFN.RemoveTrailingDelimiter(DeptCode, ",")

            If countOffice > 1 Then
                officename = "Multiple Offices"
            End If
            If countDept > 1 Then
                deptname = "Multiple Departments"
            End If

            If EmpCode = "All" Then
                EmpCode = ""
            End If
            If Me.cbEmp.Checked = True Then
                include = 1
            Else
                include = 0
            End If
            If Me.rbDateEntered.Checked = True Then
                period = 0
            End If
            If Me.rbPeriodBilled.Checked = True Then
                period = 1
            End If
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "DateEntered", "", Me.rbDateEntered.Checked)
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "PeriodBilled", "", Me.rbPeriodBilled.Checked)
            LoadData()
            offices = Me.getSecurityOffice
            If Me.OfficeCode = "" And offices <> "" Then
                Me.OfficeCode = offices
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 Then
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
                If rtb.Text = "Productivity" Then
                    If rtb.Checked = True Then
                        MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&month2=" & max)
                        Exit Sub
                    End If
                End If
                If rtb.Text = "Realization" Then
                    If rtb.Checked = True Then
                        MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&month2=" & max)
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rbDateEntered_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDateEntered.CheckedChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "DateEntered", "", Me.rbDateEntered.Checked)
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "PeriodBilled", "", Me.rbPeriodBilled.Checked)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rbPeriodBilled_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPeriodBilled.CheckedChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "DateEntered", "", Me.rbDateEntered.Checked)
            otask.setAppVars(Session("UserCode"), "DashboardEmp", "PeriodBilled", "", Me.rbPeriodBilled.Checked)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
