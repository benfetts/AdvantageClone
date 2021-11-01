Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal



Partial Public Class DashboardProjectYear
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
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_ProjectStatisticsDQ) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                End If
            End If
        Catch ex As Exception
        End Try

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "OfficeCode")
        If taskVar <> "" Then
            OfficeCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "DeptCode")
        If taskVar <> "" Then
            DeptCode = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "AECode")
        If taskVar <> "" Then
            ae = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "ClientCode")
        If taskVar <> "" Then
            client = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "SCCode")
        If taskVar <> "" Then
            sc = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "JobType")
        If taskVar <> "" Then
            jt = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "CancelCode")
        If taskVar <> "" Then
            cancel = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "IsCancelled")
        If taskVar <> "" Then
            iscancel = taskVar
        End If
        taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "CancelDesc")
        If taskVar <> "" Then
            cancelDesc = taskVar
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
                If q.GetValue("project") <> "" Then
                    For i As Integer = 0 To Me.RadToolbarProject.Items.Count - 1
                        If Me.RadToolbarProject.Items(i).Value = q.GetValue("project") Then
                            Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(i)
                            rtb.Checked = True
                        End If
                    Next
                Else
                    Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(1)
                    rtb.Checked = True
                End If
                taskVar = otask.getAppVars(Session("UserCode"), "DashboardProject", "Level")
                If taskVar <> "" Then
                    Me.DropLevel.SelectedValue = taskVar
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
            Me.RadToolbarProject.Items(7).Enabled = False
            LoadData()
            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
                Me.RadToolbarProject.Items(9).Enabled = False
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Year"
                Else
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " by Year"
                End If
            Else
                Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text & " by Year"
            End If
        Else
            Select Case Me.EventArgument

            End Select
        End If


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
            qs = qs.FromCurrent()
            With Response
                dash = qs.GetValue("dash")
            End With
            Dim count As Integer = 0
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojyear&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojyear&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RadGridYear_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridYear.ItemDataBound
        Try
            Dim countyear As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    countyear += 1
                End If
            Next

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
            Dim total As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.Cells(2).Text = "Totals:"
                If Me.DropLevel.SelectedValue = "dept" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            Dim str As String = Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "")
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridYear_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridYear.NeedDataSource
        Try
            'If Me.DropLevel.SelectedValue = "dept" Then
            '    Me.RadGridYear.DataSource = BuildYearDT()
            'End If
            'If Me.DropLevel.SelectedValue = "SC" Then
            '    Me.RadGridYear.DataSource = BuildYearDTSalesClass()
            'End If
            'If Me.DropLevel.SelectedValue = "C" Then
            '    Me.RadGridYear.DataSource = BuildYearDTClient()
            'End If
            'If Me.DropLevel.SelectedValue = "CD" Then
            '    Me.RadGridYear.DataSource = BuildYearDTCD()
            'End If
            'If Me.DropLevel.SelectedValue = "CDP" Then
            '    Me.RadGridYear.DataSource = BuildYearDTCDP()
            'End If
            'If Me.DropLevel.SelectedValue = "AE" Then
            '    Me.RadGridYear.DataSource = BuildYearDTAccountExecutive()
            'End If
            'If Me.DropLevel.SelectedValue = "JT" Then
            '    Me.RadGridYear.DataSource = BuildYearDTJobType()
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function BuildYearDT(ByVal dept As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, dept, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTSalesClass(ByVal sccode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sccode, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTClient(ByVal clientcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTCD(ByVal clientcode As String, ByVal divisioncode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTCDP(ByVal clientcode As String, ByVal divisioncode As String, ByVal productcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, clientcode, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count, divisioncode, productcode)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("CL_NAME").ToString() & "/" & dt.Rows(w)("DIV_NAME").ToString() & "/" & dt.Rows(w)("PRD_DESCRIPTION").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTAccountExecutive(ByVal aecode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, aecode, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("ACCT_NAME").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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
    Private Function BuildYearDTJobType(ByVal jtcode As String)
        Try
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jtcode, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Year Opened")
            dtComps.Columns.Add(dateOpened)

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
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Year Opened") = ds.Tables(0).Rows(j)("YEAR_OPENED")
                'Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_START"))
                'Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("MONTH_END"))
                'newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "YEAR_OPENED = '" & ds.Tables(0).Rows(j)("YEAR_OPENED") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("JT_DESC").ToString() Then
                            newrow.Item(x) = dt.Rows(w)("COMPS")
                            total += CInt(dt.Rows(w)("COMPS"))
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

    Private Function buildRGYear()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearSalesClass()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearClient()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearCD()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearCDP()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearAccountExecutive()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGYearJobType()
        Try
            Me.RadGridYear.MasterTableView.Columns.Clear()
            Dim count As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    count += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Year Opened"
            boundColumn.HeaderText = "Year Opened"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub loadyears()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet

            'ds = dash.GetPostPeriods(Now.Date.Year)
            'Me.radMenu2.DataSource = ds.Tables(0)
            'Me.radMenu2.DataTextField = "Year"
            'Me.radMenu2.DataValueField = "Value"
            'Me.radMenu2.DataBind()
            Dim i As Integer = 0
            Dim tbButton As RadToolBarButton
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            tbButton = New RadToolBarButton(Now.Date.AddYears(-1).Date.Year)
            tbButton.Value = 1
            tbButton.AllowSelfUnCheck = True
            tbButton.CheckOnClick = True
            tbButton.Group = "Year" & i + 1
            Me.RadToolbarData.Items.Insert(i, tbButton)
            i += 1
            tbButton = New RadToolBarButton(Now.Date.Year)
            tbButton.Value = 2
            tbButton.AllowSelfUnCheck = True
            tbButton.CheckOnClick = True
            tbButton.Group = "Year" & i + 1
            Me.RadToolbarData.Items.Insert(i, tbButton)
            'Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadmonths()
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            'Dim month As String = Me.DropMonth.SelectedValue
            'ds = dash.GetPostPeriodsProject(year)
            'With Me.DropMonth
            '    .DataSource = ds.Tables(1)
            '    .DataTextField = "PPDESC"
            '    .DataValueField = "PPPERIOD"
            '    .DataBind()
            'End With
            'Me.DropMonth.SelectedValue = month
            Me.DropMonth.Items.Clear()
            With Me.DropMonth
                .DataSource = LoGlo.LoadMonths(True)
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jan"), CStr("1")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Feb"), CStr("2")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Mar"), CStr("3")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Apr"), CStr("4")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("May"), CStr("5")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jun"), CStr("6")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Jul"), CStr("7")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Aug"), CStr("8")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Sep"), CStr("9")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Oct"), CStr("10")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Nov"), CStr("11")))
            'Me.DropMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Dec"), CStr("12")))
            Me.DropMonth.SelectedValue = CStr(Now.Date.Month)
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
            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 0, LoGlo.UserCultureGet())
            With Me.DropWeek
                .DataSource = ds.Tables(0)
                .DataTextField = "WEEK_END"
                .DataValueField = "WEEK_END"
                .DataBind()
            End With
            Me.DropWeek.SelectedValue = week
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
            Me.LoadData()
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Week", "", Me.DropWeek.SelectedValue)

            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            ' Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Level", "", Me.DropLevel.SelectedValue)
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            'Me.LabelProject.Text = "Projects " & project & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Year"
                Else
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " by Year"
                End If
            Else
                Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text & " by Year"
            End If
            Me.LoadData()
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
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Year", "", year)
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
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    LoadData()
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    LoadData()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProject.ButtonClick
        Try
            'Dim type As String
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            Select Case e.Item.Value
                Case "Created"
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
                    LoadData()
                Case "Completed"
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
                    LoadData()
                Case "Due"
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
                    LoadData()
                Case "Pending"
                    Me.Title = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
                    LoadData()
                Case "Cancelled"
                    'Me.LabelProject.Text = "Projects " & e.Item.Value & " by " & Me.DropLevel.SelectedItem.Text & " by Year"
                    If iscancel = False Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text & " by Year"
                    Else
                        Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text & " by Year"
                    End If
                    LoadData()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarNav_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarNav.ButtonClick
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            Select Case e.Item.Value
                Case "Summary"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectComp.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
                Case "Year"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectYear.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                Case "Month"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        .Page = "DashboardProjectMonth.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                Case "Detail"
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", "Y")
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
                Case "Week"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectCompGraph.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectCompGraph.aspx")
                Case "Filter"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProject.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProject.aspx")
                Case "ProjectDetail"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
                    Dim q As New AdvantageFramework.Web.QueryString()
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
                    For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                        If rtb.Checked = True Then
                            project = rtb.Value
                        End If
                    Next
                    With q
                        'the page to go to
                        .Page = "DashboardProjectCompDetail.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("year", year)
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Private Function CreateChart(Optional ByVal code As String = "", Optional ByVal code2 As String = "", Optional ByVal code3 As String = "", Optional ByVal name As String = "") As Telerik.Web.UI.RadHtmlChart

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing

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

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        Select Case Me.DropLevel.SelectedValue

            Case "C"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByClient"), Session("DB_Client_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "CD"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByCD"), Session("DB_CD_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "CDP"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByCDP"), Session("DB_CDP_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "dept"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByDept"), Session("DB_Dept_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "SC"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsBySalesClass"), Session("DB_SalesClass_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "AE"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByAccountExecutive"), Session("DB_AccountExecutive_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

            Case "JT"
                RadHtmlChart = Dashboard.GetColumnChart_Comps(Session("ds_DASH_CompsByJobType"), Session("DB_JobType_Caption"), "month", project, Me.DropLevel.SelectedValue, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, code, type, "year", name)

        End Select

        If RadHtmlChart IsNot Nothing Then

            RadHtmlChart.Height = System.Web.UI.WebControls.Unit.Pixel(300)
            RadHtmlChart.Width = System.Web.UI.WebControls.Unit.Pixel(1100)

            RadHtmlChart.ClientEvents.OnSeriesClick = "RadHtmlChartOnSeriesClick"

        End If

        Return RadHtmlChart

    End Function
    Private Sub CreateCharts_Department(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim DepartmentList As String() = Nothing

        If DeptCode <> "" Then

            DepartmentList = DeptCode.Split(",")

            For Each Department In DepartmentList

                DataTable = BuildYearDT(Department.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByDept") = DataTable
                Session("DB_Dept_Caption") = DataTable.Columns(1).ColumnName

                RadHtmlChart = CreateChart(Department.Replace("&", "").Replace("@", ""), "", "", Department)

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & Department.ToString.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DataSet = Dashboard.GetDepts("", Session("UserCode"))

            If DataSet.Tables(0).Rows.Count > 0 Then

                For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildYearDT(DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByDept") = DataTable
                    Session("DB_Dept_Caption") = DataRow("DP_TM_DESC")

                    RadHtmlChart = CreateChart(DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", ""), "", "", DataRow("DP_TM_DESC"))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("DP_TM_CODE").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub CreateCharts_SalesClass(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim SalesClassList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If sc <> "" Then

            SalesClassList = sc.Split(",")

            For Each SalesClass In SalesClassList

                DataTable = BuildYearDTSalesClass(SalesClass.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsBySalesClass") = DataTable
                Session("DB_SalesClass_Caption") = DataTable.Columns(1).ColumnName

                RadHtmlChart = CreateChart(SalesClass.Replace("&", "").Replace("@", ""), "", "", SalesClass)

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

                    DataTable = BuildYearDTSalesClass(SqlDataReader("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsBySalesClass") = DataTable
                    SalesClassList = SqlDataReader("description").ToString.Split("-")
                    Session("DB_SalesClass_Caption") = SalesClassList(1).Trim

                    RadHtmlChart = CreateChart(SqlDataReader("code").ToString.Replace("&", "").Replace("@", ""), "", "", SalesClassList(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Client(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildYearDTClient(ClientCode.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByClient") = DataTable
                Session("DB_Client_Caption") = DataTable.Columns(1).ColumnName.Replace("'", "")

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

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

                    DataTable = BuildYearDTClient(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByClient") = DataTable
                    ClientList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_Client_Caption") = ClientList(1).Trim.Replace("'", "")

                    RadHtmlChart = CreateChart(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""), "", "", ClientList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Division(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DescriptionList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildYearDTCD(ClientCode.Replace("&", "").Replace("@", ""), "")
                Session("ds_DASH_CompsByCD") = DataTable
                Session("DB_CD_Caption") = DataTable.Columns(1).ColumnName.Replace("'", "")

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetDivisionsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")
                    DataTable = BuildYearDTCD(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByCD") = DataTable
                    DescriptionList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_CD_Caption") = SqlDataReader("Description").Replace("'", "")

                    RadHtmlChart = CreateChart(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), "", DescriptionList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_Product(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim ClientList As String() = Nothing
        Dim DescriptionList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If client <> "" Then

            ClientList = client.Split(",")

            For Each ClientCode In ClientList

                DataTable = BuildYearDTCDP(ClientCode.Replace("&", "").Replace("@", ""), "", "")
                Session("ds_DASH_CompsByCDP") = DataTable
                Session("DB_CDP_Caption") = DataTable.Columns(1).ColumnName.Replace("'", "")

                RadHtmlChart = CreateChart(ClientCode.Replace("&", "").Replace("@", ""), "", "", ClientCode.Replace("'", ""))

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & ClientCode.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetProductsAll(Session("UserCode"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    ClientList = SqlDataReader("Code").ToString.Split(":")
                    DataTable = BuildYearDTCDP(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), ClientList(2).ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByCDP") = DataTable
                    DescriptionList = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_CDP_Caption") = SqlDataReader("Description").Replace("'", "")

                    RadHtmlChart = CreateChart(ClientList(0).ToString.Replace("&", "").Replace("@", ""), ClientList(1).ToString.Replace("&", "").Replace("@", ""), ClientList(2).ToString.Replace("&", "").Replace("@", ""), DescriptionList(1).Trim.Replace("'", ""))

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "").Replace(":", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_AccountExecutive(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim AEList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If ae <> "" Then

            AEList = ae.Split(",")

            For Each AcctExec In AEList

                If AcctExec <> "" Then

                    If AcctExec.Length = 1 Then

                        AcctExec = AcctExec & ","

                    End If

                    DataTable = BuildYearDTAccountExecutive(AcctExec.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Session("DB_AccountExecutive_Caption") = DataTable.Columns(1).ColumnName

                    RadHtmlChart = CreateChart(AcctExec.Replace("&", "").Replace("@", ""), "", "", AcctExec)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & AcctExec.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            SqlDataReader = DropDowns.GetAccountExecutive("", "", "", Session("UserCodE"))

            If SqlDataReader.HasRows Then

                Do While SqlDataReader.Read

                    DataTable = BuildYearDTAccountExecutive(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByAccountExecutive") = DataTable
                    Dim str() As String = SqlDataReader("Description").ToString.Split("-")
                    Session("DB_AccountExecutive_Caption") = str(1).Trim

                    RadHtmlChart = CreateChart(SqlDataReader("Code").ToString.Replace("&", "").Replace("@", ""), "", "", str(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & SqlDataReader("Code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Loop

            End If

        End If

    End Sub
    Private Sub CreateCharts_JobType(ByVal Dashboard As Webvantage.cDashboard)

        'objects
        Dim RadHtmlChart As Telerik.Web.UI.RadHtmlChart = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim JobNameDataTable As System.Data.DataTable = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim JobTypeList As String() = Nothing
        Dim DropDowns As Webvantage.cDropDowns = Nothing

        If jt <> "" Then

            JobTypeList = jt.Split(",")

            For Each JobType In JobTypeList

                DataTable = BuildYearDTJobType(JobType.Replace("&", "").Replace("@", ""))
                Session("ds_DASH_CompsByJobType") = DataTable
                Session("DB_JobType_Caption") = DataTable.Columns(1).ColumnName

                RadHtmlChart = CreateChart(JobType.Replace("&", "").Replace("@", ""), "", "", JobType)

                If RadHtmlChart IsNot Nothing Then

                    RadHtmlChart.ID = "RadHtmlChart" & JobType.Replace("&", "").Replace("@", "")
                    Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                End If

            Next

        Else

            DropDowns = New cDropDowns(_Session.ConnectionString)

            JobNameDataTable = DropDowns.ddJobName()

            If JobNameDataTable.Rows.Count > 0 Then

                For Each DataRow In JobNameDataTable.Rows.OfType(Of System.Data.DataRow)()

                    DataTable = BuildYearDTJobType(DataRow("code").ToString.Replace("&", "").Replace("@", ""))
                    Session("ds_DASH_CompsByJobType") = DataTable
                    Session("DB_JobType_Caption") = DataRow("description").ToString

                    RadHtmlChart = CreateChart(DataRow("code").ToString.Replace("&", "").Replace("@", ""), "", "", Str(1).Trim)

                    If RadHtmlChart IsNot Nothing Then

                        RadHtmlChart.ID = "RadHtmlChart" & DataRow("code").ToString.Replace("&", "").Replace("@", "")
                        Me.PlaceHolderGraph.Controls.Add(RadHtmlChart)

                    End If

                Next

            End If

        End If

    End Sub
    Private Sub LoadData()

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim Literal As System.Web.UI.WebControls.Literal = Nothing

        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing

        For Each RadToolBarButton In Me.RadToolbarData.Items.OfType(Of Telerik.Web.UI.RadToolBarButton)()

            If RadToolBarButton.Checked = True Then

                year = RadToolBarButton.Text

            End If

        Next

        Me.PlaceHolderGraph.Controls.Clear()

        Try

            Select Case Me.DropLevel.SelectedValue

                Case "dept"

                    CreateCharts_Department(Dashboard)

                Case "SC"

                    CreateCharts_SalesClass(Dashboard)

                Case "C"

                    CreateCharts_Client(Dashboard)

                Case "CD"

                    CreateCharts_Division(Dashboard)

                Case "CDP"

                    CreateCharts_Product(Dashboard)

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

#End Region

End Class