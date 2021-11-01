Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardClientTime
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

        Dashboard.InitializePieChart(RadHtmlChartHoursPieChart, "")
        Dashboard.InitializePieChart(RadHtmlChartDollarsPieChart, "")

        Try
            Me.DropMonth = Me.RadToolbarDashProject.Items(5).FindControl("DropDownListMonth")
            Me.DropWeek = Me.RadToolbarDashProject.Items(7).FindControl("DropDownListWeek")
            Me.DropLevel = Me.RadToolbarPE.Items(1).FindControl("DropDownListLevel")
            Me.CheckBoxPrintAll = Me.RadToolbarPE.Items(5).FindControl("CheckBoxPrintAll")
            'Me.CancelledStatus = Me.RadToolbarFilter.Items(13).FindControl("TextBoxCancelStatus")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Try
            If Not Me.IsPostBack Then
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_ClientTimeAnalysisDQ) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                End If
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
                    Me.DropWeek.SelectedValue = HttpContext.Current.Server.UrlDecode(q.GetValue("week"))
                End If
                If q.GetValue("option") <> "" Then
                    project = q.GetValue("option").Replace("_", " ")
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
            taskVar = otask.getAppVars(Session("UserCode"), "DashboardClient", "Level")
            If taskVar <> "" Then
                Me.DropLevel.SelectedValue = taskVar
            End If
            LoadData(type)
            Me.LabelProject.Text = project & " Hours By " & Me.DropLevel.SelectedItem.Text
            Me.LabelByLevel.Text = project & " Dollars By " & Me.DropLevel.SelectedItem.Text

            Me.Title = "Client Time Analysis"

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

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            Dim printall As Integer = 0
            qs = qs.FromCurrent()
            With Response
                dash = "Hours"
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
            If Me.CheckBoxPrintAll.Checked = True Then
                printall = 1
            End If

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?db=client&From=dashclienttime&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&printall=" & printall & "&datatype=Hours', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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
            'Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Month", "", Me.DropMonth.SelectedValue)
            Me.LoadData(type)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            'Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Week", "", Me.DropWeek.SelectedValue)
            Me.LoadData(type)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            ' Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            otask.setAppVars(Session("UserCode"), "DashboardClient", "Level", "", Me.DropLevel.SelectedValue)
            Me.LoadData(type)
            Me.LabelProject.Text = project & " Hours By " & Me.DropLevel.SelectedItem.Text
            Me.LabelByLevel.Text = project & " Dollars By " & Me.DropLevel.SelectedItem.Text
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                        If rtb.Checked = True And rtb.Value = "Month" Then
                            type = rtb.Value
                        End If
                        If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                            type = rtb.Value
                        End If
                    Next
                    LoadData(type)
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
                    LoadData("Month")
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardClient", "Range", "", e.Item.Value)
                    LoadData("YeartoDate")
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
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("option", project)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
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
                Case "ProjectDetail"
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
                        .Page = "DashboardClientTimeCompDetail.aspx"
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
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxPrintAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxPrintAll.CheckedChanged
        Try
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            With Response
                project = qs.GetValue("option").Replace("_", " ")
            End With
            Me.LoadData(type)
            Me.LabelProject.Text = project & " Hours By " & Me.DropLevel.SelectedItem.Text
            Me.LabelByLevel.Text = project & " Dollars By " & Me.DropLevel.SelectedItem.Text
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
        Dim dtWeek As DataView
        Dim iscancel As Boolean = False
        Dim count As Integer = 0
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        With Response
            project = qs.GetValue("option").Replace("_", " ")
        End With
        For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
            If rtb.Checked = True Then
                year = rtb.Text
                count += 1
            End If
        Next
        If cancel <> "" Then
            iscancel = True
        End If
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If type = "Month" Then
                ds = dash.GetHoursByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project, count)
            Else
                ds = dash.GetHoursByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project, count)
            End If
            Session("ds_DASH_Comps_Pie_ByHours") = ds
            If type = "Month" Then
                ds = dash.GetDollarsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project, count)
            Else
                ds = dash.GetDollarsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project, count)
            End If
            Session("ds_DASH_Comps_Pie_ByDollars") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        LoadCharts()

    End Sub

    Private Sub LoadCharts()

        LoadHoursPieChart()
        LoadDollarsPieChart()

    End Sub
    Private Sub LoadHoursPieChart()

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        DataSet = Session("ds_DASH_Comps_Pie_ByHours")

        ToolTipPrefix = "Hours: "
        Caption = ""

        NameField = GetNameField()
        ValueField = "HOURS"

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelClient(RadHtmlChartHoursPieChart, DataSet, NameField, ValueField, Caption, ToolTipPrefix)

    End Sub
    Private Sub LoadDollarsPieChart()

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim NameField As String = Nothing
        Dim ValueField As String = Nothing
        Dim Caption As String = ""
        Dim ToolTipPrefix As String = Nothing

        DataSet = Session("ds_DASH_Comps_Pie_ByDollars")

        ToolTipPrefix = "Amount: "
        Caption = ""

        NameField = GetNameField()
        ValueField = "AMOUNT"

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.GetPieChart_ByLevelClient(RadHtmlChartDollarsPieChart, DataSet, NameField, ValueField, Caption, ToolTipPrefix)

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

#End Region

End Class