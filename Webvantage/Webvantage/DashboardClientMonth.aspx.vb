Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal



Partial Public Class DashboardClientMonth
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
    Public iscancel As Boolean = False
    Public datatype As String = ""

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
        
        Try
            Me.DropMonth = Me.RadToolbarDashProject.Items(5).FindControl("DropDownListMonth")
            Me.DropWeek = Me.RadToolbarDashProject.Items(7).FindControl("DropDownListWeek")
            Me.DropLevel = Me.RadToolbarPE.Items(1).FindControl("DropDownListLevel")
            'Me.CancelledStatus = Me.RadToolbarFilter.Items(13).FindControl("TextBoxCancelStatus")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.IsPostBack Then
                'Dim oSec As New cSecurity(Session("ConnString"))
                'If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                '    Server.Transfer("NoAccess.aspx")
                'ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                '    Server.Transfer("NoAccess.aspx")
                'ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                '    'Me.RadToolbarDash.Items(3).Enabled = False
                'End If
            End If
        Catch ex As Exception
        End Try

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "OfficeCode")
        If taskVar <> "" Then
            OfficeCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "DeptCode")
        If taskVar <> "" Then
            DeptCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "AECode")
        If taskVar <> "" Then
            ae = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "ClientCode")
        If taskVar <> "" Then
            client = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "SCCode")
        If taskVar <> "" Then
            sc = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "JobType")
        If taskVar <> "" Then
            jt = taskVar
        End If

        If Not Me.IsPostBack Then
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                If q.GetValue("range") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarDashProject.Items.Count - 1
                        If Me.RadToolbarDashProject.Items(i).Value = q.GetValue("range") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(1)
                    rtb.Checked = True
                End If
                loadyears()
                If q.GetValue("year") <> "" Then
                    Dim stryear() As String = q.GetValue("year").Split("-")
                    For i As Integer = 0 To Me.RadToolbarData.Items.Count - 1
                        For j As Integer = 0 To stryear.Length - 1
                            If Me.RadToolbarData.Items(i).Text = stryear(j) Then
                                Dim rtb As RadToolBarButton = Me.RadToolbarData.Items(i)
                                rtb.Checked = True
                            End If
                        Next
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarData.Items(1)
                    rtb.Checked = True
                End If
                loadmonths()
                If q.GetValue("month") <> "" Then
                    Me.DropMonth.SelectedValue = q.GetValue("month")
                End If
                loadweeks()
                Dim test As String = HttpContext.Current.Server.UrlDecode(q.GetValue("week"))
                If q.GetValue("week") <> "" Then
                    Me.DropWeek.SelectedValue = q.GetValue("week")
                End If
                If q.GetValue("option") <> "" Then
                    project = q.GetValue("option").Replace("_", " ")
                End If
                If q.GetValue("dt") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarDataType.Items.Count - 1
                        If Me.RadToolbarDataType.Items(i).Value = q.GetValue("dt") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarDataType.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarDataType.Items(1)
                    rtb.Checked = True
                End If
            End With

            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            'For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
            '    If rtb.Value = "Hours" Then
            '        rtb.Checked = True
            '    End If
            'Next

            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Level")
            If taskVar <> "" Then
                Me.DropLevel.SelectedValue = taskVar
            End If
            If datatype = "Hours" Then
                Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Month"
            End If
            If datatype = "Dollars" Then
                Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Month"
            End If
            LoadData()
        Else
            Select Case Me.EventArgument
                Case "Refresh"

            End Select
        End If


    End Sub

    Private Function ResetForm()


        Me.Session("_ds") = Nothing
    End Function

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                dash = qs.GetValue("dash")
            End With
            Dim iscancel As Boolean = False
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next

            If cancel <> "" Then
                iscancel = True
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?db=client&From=dashclientmonth&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "&datatype=" & datatype & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    'Private Sub RadGridComps_ColumnCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridColumnCreatedEventArgs) Handles RadGridComps.ColumnCreated
    '    Try
    '        cols = Me.RadGridComps.MasterTableView.Columns.Count
    '        'Dim col As GridBoundColumn
    '        'If e.Column.ColumnType = "GridBoundColumn" Then
    '        '    col = e.Column
    '        '    If e.Column.HeaderText = "Total" Then
    '        '        'col.DataType = System.Type.GetType("System.Int32")
    '        '        col.Aggregate = GridAggregateFunction.Sum
    '        '    End If
    '        'End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridComps_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComps.ItemDataBound
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)
    '        Dim total As Integer
    '        Dim count As Integer
    '        Dim fourweektotal As Integer
    '        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then


    '        ElseIf e.Item.ItemType = GridItemType.Footer Then
    '            e.Item.Cells(3).Text = "Totals:"
    '            For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
    '                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                    If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
    '                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                        total += ds.Tables(3).Rows(j)("COMPS")
    '                    End If
    '                    If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                        e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
    '                    End If
    '                Next
    '            Next

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridComps_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComps.NeedDataSource
    '    Try
    '        If Me.DropLevel.SelectedValue = "dept" Then
    '            Me.RadGridComps.DataSource = BuildWeekDT()
    '        End If
    '        If Me.DropLevel.SelectedValue = "SC" Then
    '            Me.RadGridComps.DataSource = BuildWeekDTSalesClass()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridMonth_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMonth.ItemDataBound
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)
    '        Dim total As Integer
    '        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

    '        ElseIf e.Item.ItemType = GridItemType.Footer Then
    '            e.Item.Cells(2).Text = "Totals:"
    '            For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
    '                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
    '                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                        total += ds.Tables(3).Rows(j)("COMPS")
    '                    End If
    '                    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
    '                    End If
    '                Next
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridMonth_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMonth.NeedDataSource
    '    Try
    '        If Me.DropLevel.SelectedValue = "dept" Then
    '            Me.RadGridMonth.DataSource = BuildMonthDT()
    '        End If
    '        If Me.DropLevel.SelectedValue = "SC" Then
    '            Me.RadGridMonth.DataSource = BuildMonthDTSalesClass()
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridYear_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridYear.ItemDataBound
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)
    '        Dim total As Integer
    '        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

    '        ElseIf e.Item.ItemType = GridItemType.Footer Then
    '            e.Item.Cells(2).Text = "Totals:"
    '            For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
    '                For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
    '                    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
    '                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
    '                        total += ds.Tables(3).Rows(j)("COMPS")
    '                    End If
    '                    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
    '                        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
    '                    End If
    '                Next
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadGridYear_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridYear.NeedDataSource
    '    Try
    '        If Me.DropLevel.SelectedValue = "dept" Then
    '            Me.RadGridYear.DataSource = BuildYearDT()
    '        End If
    '        If Me.DropLevel.SelectedValue = "SC" Then
    '            Me.RadGridYear.DataSource = BuildYearDTSalesClass()
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Function BuildWeekDT()
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        'For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
    '        '    If MenuItem.Selected = True Then
    '        '        year = MenuItem.Text
    '        '    End If
    '        'Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Date Opened")
    '        Dim dateRange As DataColumn = New DataColumn("Range")
    '        Dim ws As DataColumn = New DataColumn("WS")
    '        dtComps.Columns.Add(dateOpened)
    '        dtComps.Columns.Add(dateRange)
    '        dtComps.Columns.Add(ws)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"), System.Type.GetType("System.Int32"))
    '                dtComps.Columns.Add(dc)

    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
    '                dtComps.Columns.Add(dc)

    '            Next
    '        End If

    '        Dim dtWeek As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
    '            Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
    '            Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
    '            newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
    '            dtWeek = ds.Tables(2).DefaultView
    '            dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
    '            dt = dtWeek.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 3 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Dim dsAvg As DataSet
    '        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", ds.Tables(1).Rows(i)("DP_TM_CODE"), "", 0, 1, Me.DropLevel.SelectedValue)
    '                For p As Integer = 0 To dtComps.Rows.Count - 1
    '                    dtWeek = dsAvg.Tables(0).DefaultView
    '                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
    '                    dt = dtWeek.ToTable
    '                    For j As Integer = 0 To dt.Rows.Count - 1
    '                        For q As Integer = 0 To dtComps.Columns.Count - 1
    '                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("DP_TM_DESC").ToString()Then
    '                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
    '                            End If
    '                        Next
    '                    Next
    '            Next
    '        Next



    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function BuildWeekDTSalesClass()
    '    Try

    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next

    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Date Opened")
    '        Dim dateRange As DataColumn = New DataColumn("Range")
    '        Dim ws As DataColumn = New DataColumn("WS")
    '        dtComps.Columns.Add(dateOpened)
    '        dtComps.Columns.Add(dateRange)
    '        dtComps.Columns.Add(ws)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"), System.Type.GetType("System.Int32"))
    '                dtComps.Columns.Add(dc)

    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
    '                dtComps.Columns.Add(dc)

    '            Next
    '        End If

    '        Dim dtWeek As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
    '            Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
    '            Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
    '            newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
    '            dtWeek = ds.Tables(2).DefaultView
    '            dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
    '            dt = dtWeek.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 3 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Dim dsAvg As DataSet
    '        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '            dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("SC_CODE"), 0, 1, Me.DropLevel.SelectedValue)
    '            For p As Integer = 0 To dtComps.Rows.Count - 1
    '                dtWeek = dsAvg.Tables(0).DefaultView
    '                dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
    '                dt = dtWeek.ToTable
    '                For j As Integer = 0 To dt.Rows.Count - 1
    '                    For q As Integer = 0 To dtComps.Columns.Count - 1
    '                        If dtComps.Columns(q).ColumnName = dt.Rows(j)("SC_DESCRIPTION").ToString()Then
    '                            dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
    '                        End If
    '                    Next
    '                Next
    '            Next
    '        Next



    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function BuildMonthDT()
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Month Opened")
    '        dtComps.Columns.Add(dateOpened)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"))
    '                dtComps.Columns.Add(dc)
    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        Dim dtMonth As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Month Opened") = ds.Tables(0).Rows(j)("MONTH_OPENED")
    '            'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
    '            'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
    '            'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            dtMonth = ds.Tables(2).DefaultView
    '            dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
    '            dt = dtMonth.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 1 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function BuildMonthDTSalesClass()
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Month Opened")
    '        dtComps.Columns.Add(dateOpened)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"))
    '                dtComps.Columns.Add(dc)
    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        Dim dtMonth As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Month Opened") = ds.Tables(0).Rows(j)("MONTH_OPENED")
    '            'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
    '            'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
    '            'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            dtMonth = ds.Tables(2).DefaultView
    '            dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
    '            dt = dtMonth.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 1 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function BuildYearDT()
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Year Opened")
    '        dtComps.Columns.Add(dateOpened)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"))
    '                dtComps.Columns.Add(dc)
    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        Dim dtMonth As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
    '            'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
    '            'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
    '            'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            dtMonth = ds.Tables(2).DefaultView
    '            dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
    '            dt = dtMonth.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 1 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function BuildYearDTSalesClass()
    '    Try
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        Dim dtComps As DataTable
    '        dtComps = New DataTable("comps")
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim dateOpened As DataColumn = New DataColumn("Year Opened")
    '        dtComps.Columns.Add(dateOpened)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"))
    '                dtComps.Columns.Add(dc)
    '            Next
    '        End If

    '        dtComps.Columns.Add("Total")

    '        Dim dtMonth As DataView
    '        Dim dt As DataTable
    '        Dim newrow As DataRow
    '        Dim total As Integer = 0
    '        For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            newrow = dtComps.NewRow
    '            newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
    '            'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
    '            'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
    '            'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
    '            dtMonth = ds.Tables(2).DefaultView
    '            dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
    '            dt = dtMonth.ToTable
    '            For w As Integer = 0 To dt.Rows.Count - 1
    '                For x As Integer = 1 To dtComps.Columns.Count - 1
    '                    If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString()Then
    '                        newrow.Item(x) = dt.Rows(w)("COMPS")
    '                        total += CInt(dt.Rows(w)("COMPS"))
    '                    End If
    '                Next
    '            Next
    '            newrow.Item("Total") = total
    '            total = 0
    '            dtComps.Rows.Add(newrow)
    '        Next

    '        For p As Integer = 0 To dtComps.Rows.Count - 1
    '            For q As Integer = 0 To dtComps.Columns.Count - 1
    '                If dtComps.Rows(p)(q).ToString()= "" Then
    '                    dtComps.Rows(p)(q) = 0
    '                End If
    '            Next
    '        Next

    '        Return dtComps
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRG()
    '    Try
    '        Me.RadGridComps.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Date Opened"
    '        boundColumn.HeaderText = "Date Opened"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Range"
    '        boundColumn.HeaderText = "Range"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If


    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)

    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)"
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)"
    '                boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRGMonth()
    '    Try
    '        Me.RadGridMonth.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Month Opened"
    '        boundColumn.HeaderText = "Month Opened"
    '        RadGridMonth.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridMonth.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If

    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        RadGridMonth.MasterTableView.Columns.Add(boundColumn)


    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRGYear()
    '    Try
    '        Me.RadGridYear.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Year Opened"
    '        boundColumn.HeaderText = "Year Opened"
    '        RadGridYear.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridYear.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If

    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        RadGridYear.MasterTableView.Columns.Add(boundColumn)


    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRGSalesClass()
    '    Try
    '        Me.RadGridComps.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Date Opened"
    '        boundColumn.HeaderText = "Date Opened"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Range"
    '        boundColumn.HeaderText = "Range"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If


    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
    '        RadGridComps.MasterTableView.Columns.Add(boundColumn)

    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)"
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)"
    '                boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridComps.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRGMonthSalesClass()
    '    Try
    '        Me.RadGridMonth.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Month Opened"
    '        boundColumn.HeaderText = "Month Opened"
    '        RadGridMonth.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridMonth.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If

    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        RadGridMonth.MasterTableView.Columns.Add(boundColumn)


    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Function buildRGYearSalesClass()
    '    Try
    '        Me.RadGridYear.MasterTableView.Columns.Clear()
    '        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
    '            If rtb.Checked = True Then
    '                year = rtb.Text
    '            End If
    '        Next
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet
    '        ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", 0, 1, Me.DropLevel.SelectedValue)

    '        Dim boundColumn As GridBoundColumn
    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Year Opened"
    '        boundColumn.HeaderText = "Year Opened"
    '        RadGridYear.MasterTableView.Columns.Add(boundColumn)

    '        Dim dc As DataColumn
    '        If ds.Tables(1).Rows.Count > 0 Then
    '            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
    '                boundColumn = New GridBoundColumn
    '                boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION")
    '                boundColumn.DataType = System.Type.GetType("System.Int32")
    '                RadGridYear.MasterTableView.Columns.Add(boundColumn)
    '            Next
    '        End If

    '        boundColumn = New GridBoundColumn
    '        boundColumn.DataField = "Total"
    '        boundColumn.HeaderText = "Total"
    '        RadGridYear.MasterTableView.Columns.Add(boundColumn)


    '    Catch ex As Exception

    '    End Try
    'End Function

    'Private Sub RadGridProjects_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjects.NeedDataSource
    '    Try
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        Dim ds As DataSet

    '        ds = dash.GetProjectsByWeek("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, "", "", 0, 1)
    '        RadGridProjects.DataSource = ds.Tables(1)
    '    Catch ex As Exception

    '    End Try
    'End Sub


#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet

            ds = dash.GetPostPeriods(Now.Date.Year)
            'Me.radMenu2.DataSource = ds.Tables(0)
            'Me.radMenu2.DataTextField = "Year"
            'Me.radMenu2.DataValueField = "Value"
            'Me.radMenu2.DataBind()

            Dim tbButton As RadToolBarButton
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tbButton = New RadToolBarButton(ds.Tables(0).Rows(i)("Year"))
                tbButton.Value = ds.Tables(0).Rows(i)("Value")
                tbButton.AllowSelfUnCheck = True
                tbButton.CheckOnClick = True
                tbButton.Group = "Year" & ds.Tables(0).Rows(i)("Value").ToString
                Me.RadToolbarData.Items.Insert(i, tbButton)
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadmonths()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim SortedPostPeriods As DataTable = Nothing
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim month As String = Me.DropMonth.SelectedValue
            ds = dash.GetPostPeriodsProject(year)

            With ds.Tables(1).DefaultView

                .Sort = "PPGLMONTH asc"
                SortedPostPeriods = .ToTable

            End With

            With Me.DropMonth
                .DataSource = SortedPostPeriods
                .DataTextField = "PPDESC"
                .DataValueField = "PPPERIOD"
                .DataBind()
            End With
            Me.DropMonth.SelectedValue = month
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To Me.DropMonth.Items.Count - 1
                For i As Integer = 0 To SortedPostPeriods.Rows.Count - 1
                    If Me.DropMonth.Items(i).Value = SortedPostPeriods.Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, SortedPostPeriods.Rows(i)("MONTH"), 1)
                        Me.DropMonth.Items(i).Text = String.Format(c, "{0:MMM}", d)
                    End If
                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadweeks()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim week As String = Me.DropWeek.SelectedValue
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 1, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = ds.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With
            Me.DropWeek.SelectedValue = ds.Tables(0).AsEnumerable.Last()("WEEK_END")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropMonth.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Month", "", Me.DropMonth.SelectedValue)
            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Week", "", Me.DropWeek.SelectedValue)
            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Level", "", Me.DropLevel.SelectedValue)
            Me.LoadData()
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If datatype = "Hours" Then
                Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Month"
            End If
            If datatype = "Dollars" Then
                Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Month"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case ""

                Case Else
                    For Each radtb As RadToolBarButton In Me.RadToolbarData.Items
                        If radtb.Checked = True And radtb.Text <> "Print" Then
                            year &= radtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Year", "", year)
                    loadmonths()
                    loadweeks()
                    LoadData()
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    LoadData()
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    LoadData()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarNav_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarNav.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option")
            End With
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case "Summary"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientTime.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
                Case "Year"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientYear.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                Case "Month"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    If cancel <> "" Then
                        iscancel = True
                    End If
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardClientMonth.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                Case "Week"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardClientTimeGraph.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectCompGraph.aspx")
                Case "Filter"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardClient.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProject.aspx")
                Case "Detail"
                    Dim q As New AdvantageFramework.Web.QueryString()
                    Dim iscancel As Boolean = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year &= rtb.Text & "-"
                        End If
                    Next
                    year = MiscFN.RemoveTrailingDelimiter(year, "-")
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardClientTimeDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("dash", "M")
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Add("dt", datatype)
                        .Go()
                    End With
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDataType_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDataType.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            Select Case e.Item.Value
                Case "Hours"
                    LoadData()
                    Me.Title = project & " Hours by " & Me.DropLevel.SelectedItem.Text & " by Month"
                Case "Dollars"
                    LoadData()
                    Me.Title = project & " Dollars by " & Me.DropLevel.SelectedItem.Text & " by Month"
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Function CreateChart() As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        For Each RadToolBarButton In Me.RadToolbarDashProject.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "Month" Then

                type = RadToolBarButton.Value

            End If

            If RadToolBarButton.Checked = True AndAlso RadToolBarButton.Value = "YeartoDate" Then

                type = RadToolBarButton.Value

            End If

        Next

        year = ""

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year &= RadToolBarButton.Text & "-"

            End If

        Next

        year = MiscFN.RemoveTrailingDelimiter(year, "-")

        For Each RadToolBarButton In Me.RadToolbarDataType.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                datatype = RadToolBarButton.Value

            End If

        Next

        Select Case Me.DropLevel.SelectedValue

            Case "C"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByClient"), Session("DB_Client_Caption"), "month", datatype, "month")

            Case "CD"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByCD"), Session("DB_CD_Caption"), "month", datatype, "month")

            Case "CDP"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByCDP"), Session("DB_CDP_Caption"), "month", datatype, "month")

            Case "dept"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByDept"), Session("DB_Dept_Caption"), "month", datatype, "month")

            Case "SC"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), "month", datatype, "month")

            Case "AE"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), "month", datatype, "month")

            Case "JT"

                RadHtmlChart = Dashboard.GetColumnChart_CompsClient(Session("ds_DASH_CompsByJobType"), Session("DB_JobType_Caption"), "month", datatype, "month")

        End Select

        If RadHtmlChart IsNot Nothing Then

            RadHtmlChart.Width = System.Web.UI.WebControls.Unit.Pixel(1100)
            RadHtmlChart.Height = System.Web.UI.WebControls.Unit.Pixel(300)

        End If

        Return RadHtmlChart

    End Function

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
            If rtb.Checked = True And rtb.Value = "Month" Then
                type = rtb.Value
            End If
            If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                type = rtb.Value
            End If
        Next
        year = ""
        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
            If rtb.Checked = True Then
                year &= rtb.Text & "-"
            End If
        Next
        year = MiscFN.RemoveTrailingDelimiter(year, "-")
        For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
            If rtb.Checked = True Then
                datatype = rtb.Value
            End If
        Next
        If Me.DropLevel.SelectedValue = "C" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByClient"), Session("DB_Client_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByCD"), Session("DB_CD_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByCDP"), Session("DB_CDP_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByDept"), Session("DB_Dept_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return dash.getFCXMLData_Bar3D_CompsClient(Session("ds_DASH_CompsByJobType"), Session("DB_JobType_Caption"), "month", datatype, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, "", type, "month")
        End If
    End Function

    Private Function BuildMonthDT(ByVal dept As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If


            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTSalesClass(ByVal sccode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTClient(ByVal clientcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCD(ByVal clientcode As String, ByVal divisioncode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString())
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCDP(ByVal clientcode As String, ByVal divisioncode As String, ByVal productcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode, productcode)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode, productcode)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString())
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() & "/" & dt.Rows(w)("PRD_DESCRIPTION").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTAccountExecutive(ByVal aecode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            If cancel <> "" Then
                iscancel = True
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("ACCT_NAME"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("ACCT_NAME").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTJobType(ByVal jtcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            If cancel <> "" Then
                iscancel = True
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDataType.Items
                If rtb.Checked = True Then
                    datatype = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            If datatype = "Hours" Then
                ds = dash.GetHoursByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If
            If datatype = "Dollars" Then
                ds = dash.GetDollarsByMonth("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
            End If

            Dim dateOpened As DataColumn = New DataColumn("Month Opened")
            Dim ms As DataColumn = New DataColumn("MS")
            Dim mend As DataColumn = New DataColumn("ME")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(ms)
            dtComps.Columns.Add(mend)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("JT_DESC"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                Dim str() As String = ds.Tables(0).Rows(j)("MONTH_OPENED").ToString.Split("-")
                Dim d As New DateTime(str(1), ds.Tables(0).Rows(j)("MTH"), 1)
                newrow.Item("Month Opened") = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "MONTH_OPENED = '" & ds.Tables(0).Rows(j)("MONTH_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("JT_DESC").ToString() Then
                            If datatype = "Hours" Then
                                newrow.Item(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                            If datatype = "Dollars" Then
                                newrow.Item(x) = dt.Rows(w)("DOLLARS")
                                total += CDec(dt.Rows(w)("DOLLARS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            Next

            For p As Integer = 0 To dtComps.Rows.Count - 1
                For q As Integer = 0 To dtComps.Columns.Count - 1
                    If dtComps.Rows(p)(q).ToString() = "" Then
                        dtComps.Rows(p)(q) = 0
                    End If
                Next
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Sub LoadData()

        'objects
        Dim Literal As System.Web.UI.WebControls.Literal = Nothing
        Dim Dashboard As Webvantage.cDashboard = Nothing

        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year = RadToolBarButton.Text

            End If

        Next

        Me.PlaceHolderGraph.Controls.Clear()

        Try

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Select Case Me.DropLevel.SelectedValue

                Case "C"

                    CreateCharts_Client(Dashboard)

                Case "CD"

                    CreateCharts_Division(Dashboard)

                Case "CDP"

                    CreateCharts_Product(Dashboard)

                Case "dept"

                    CreateCharts_Department(Dashboard)

                Case "SC"

                    CreateCharts_SalesClass(Dashboard)

                Case "AE"

                    CreateCharts_AccountExecutive(Dashboard)

                Case "JT"

                    CreateCharts_JobType(Dashboard)

            End Select

            If Me.PlaceHolderGraph.Controls.Count = 0 Then

                Literal = New Literal
                Literal.ID = "lit1"
                Literal.Text = "No data to display."
                Me.PlaceHolderGraph.Controls.Add(Literal)

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub
    Private Sub CreateCharts_Department(ByVal Dashboard As Webvantage.cDashboard)

        Dim DepartmentList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataSet As System.Data.DataSet = Nothing

        If DeptCode <> "" Then

            DepartmentList = DeptCode.Split(",")

            For Each Department In DepartmentList

                DataTable = BuildMonthDT(Department.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByDept") = DataTable

                If datatype = "Hours" Then

                    Session("DB_Dept_Caption") = DataTable.Columns(3).ColumnName

                End If

                If datatype = "Dollars" Then

                    Session("DB_Dept_Caption") = DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & Department.ToString.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDepts("", Session("UserCode"))

            If DataSet.Tables(0).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildMonthDT("'" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "") & "'")
                    Session("ds_DASH_CompsByDept") = DataTable

                    If datatype = "Hours" Then

                        Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "literal" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateCharts_SalesClass(ByVal Dashboard As Webvantage.cDashboard)

        Dim SalesClassList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing
        Dim DescriptionString As String() = Nothing

        If sc <> "" Then

            SalesClassList = sc.Split(",")

            For Each SalesClass In SalesClassList

                DataTable = BuildMonthDTSalesClass(SalesClass.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsBySalesClass") = DataTable

                If datatype = "Hours" Then
                    Session("DB_SalesClass_Caption") = DataTable.Columns(3).ColumnName
                End If

                If datatype = "Dollars" Then
                    Session("DB_SalesClass_Caption") = DataTable.Columns(3).ColumnName
                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & SalesClass.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetSalesClass()

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildMonthDTSalesClass(SqlDataReader("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsBySalesClass") = DataTable

                    DescriptionString = SqlDataReader("description").ToString.Split("-")

                    If datatype = "Hours" Then

                        Session("DB_SalesClass_Caption") = DescriptionString(1).Trim

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_SalesClass_Caption") = DescriptionString(1).Trim

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Client(ByVal Dashboard As Webvantage.cDashboard)

        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim DescriptionString As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildMonthDTClient(ClientCode.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByClient") = DataTable

                If datatype = "Hours" Then

                    Session("DB_Client_Caption") = DataTable.Columns(3).ColumnName

                End If

                If datatype = "Dollars" Then

                    Session("DB_Client_Caption") = DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetClientList(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildMonthDTClient(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByClient") = DataTable

                    DescriptionString = SqlDataReader("Description").ToString.Split("-")

                    If datatype = "Hours" Then

                        Session("DB_Client_Caption") = DescriptionString(1).Trim

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_Client_Caption") = DescriptionString(1).Trim

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "literal" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If
                Loop
            End If
        End If

    End Sub
    Private Sub CreateCharts_Division(ByVal Dashboard As Webvantage.cDashboard)

        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim DescriptionString As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildMonthDTCD(ClientCode.Replace("&", "").Replace("@", ""), "")
                Session("ds_DASH_CompsByCD") = DataTable

                If datatype = "Hours" Then

                    Session("DB_CD_Caption") = DataTable.Columns(3).ColumnName

                End If

                If datatype = "Dollars" Then

                    Session("DB_CD_Caption") = DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New Webvantage.cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetDivisionsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")

                    DataTable = BuildMonthDTCD(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByCD") = DataTable

                    If datatype = "Hours" Then

                        Session("DB_CD_Caption") = SqlDataReader("Description")

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_CD_Caption") = SqlDataReader("Description")

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Product(ByVal Dashboard As Webvantage.cDashboard)

        Dim ClientList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim DescriptionString As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildMonthDTCDP(ClientCode.Replace("&", "").Replace("@", ""), "", "")
                Session("ds_DASH_CompsByCDP") = DataTable

                If datatype = "Hours" Then

                    Session("DB_CDP_Caption") = DataTable.Columns(3).ColumnName

                End If

                If datatype = "Dollars" Then

                    Session("DB_CDP_Caption") = DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If
            Next

        Else

            DropDowns = New Webvantage.cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetProductsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")

                    DataTable = BuildMonthDTCDP(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), ClientList(2).ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByCDP") = DataTable

                    If datatype = "Hours" Then

                        Session("DB_CDP_Caption") = SqlDataReader("Description")

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_CDP_Caption") = SqlDataReader("Description")

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_AccountExecutive(ByVal Dashboard As Webvantage.cDashboard)

        Dim AEList As String() = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If ae <> "" Then

            AEList = ae.Split(",")

            For Each AccountExec In AEList

                If AccountExec <> "" Then

                    If AccountExec.Length = 1 Then

                        AccountExec = AccountExec & ","

                    End If

                    DataTable = BuildMonthDTAccountExecutive(AccountExec.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable

                    If datatype = "Hours" Then

                        Session("DB_AccountExecutive_Caption") = DataTable.Columns(3).ColumnName

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_AccountExecutive_Caption") = DataTable.Columns(3).ColumnName

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & AccountExec.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetAccountExecutive("", "", "", Session("UserCodE"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildMonthDTAccountExecutive(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable

                    AEList = SqlDataReader("Description").ToString.Split("-")

                    If datatype = "Hours" Then

                        Session("DB_AccountExecutive_Caption") = AEList(1).Trim

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_AccountExecutive_Caption") = AEList(1).Trim

                    End If
                    
                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_JobType(ByVal Dashboard As Webvantage.cDashboard)

        Dim JobTypeList As String() = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim JobTypeDataTable As System.Data.DataTable = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If jt <> "" Then

            JobTypeList = jt.Split(",")

            For Each JobType In JobTypeList

                DataTable = BuildMonthDTJobType(JobType.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByJobType") = DataTable

                If datatype = "Hours" Then

                    Session("DB_JobType_Caption") = DataTable.Columns(3).ColumnName

                End If

                If datatype = "Dollars" Then

                    Session("DB_JobType_Caption") = DataTable.Columns(3).ColumnName

                End If

                RadHtmlChart = CreateChart()

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & JobType.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New Webvantage.cDropDowns(_Session.ConnectionString)

            JobTypeDataTable = DropDowns.ddJobName()

            If JobTypeDataTable.Rows.Count > 0 Then

                For Each DataRow In JobTypeDataTable.Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildMonthDTJobType(DataRow("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByJobType") = DataTable

                    If datatype = "Hours" Then

                        Session("DB_JobType_Caption") = DataRow("description").ToString

                    End If

                    If datatype = "Dollars" Then

                        Session("DB_JobType_Caption") = DataRow("description").ToString

                    End If

                    RadHtmlChart = CreateChart()

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If
                Next
            End If
        End If

    End Sub

#End Region

End Class