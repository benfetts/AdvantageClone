Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardClientTimeCompDetail
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
            Me.DropLevel = Me.RadToolbarDashProject.Items(9).FindControl("DropDownListLevel")
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
                    Dim rtb As RadToolBarButton = Me.RadToolbarDashProject.Items(3)
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
            End With

            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            'LoadData(type)

            Me.Title = "Hours By " & Me.DropLevel.SelectedItem.Text
            'LoadGrid()
            If Me.DropLevel.SelectedValue = "C" Then
                Me.buildRGClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.buildRGDivision()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.buildRGProduct()
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.buildRG()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.buildRGSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.buildRGAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.buildRGJobType()
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    'Me.RadWindowManagerEstimate.Windows(0).VisibleOnPageLoad = False
                    'Me.GetEstimateData(Me.EstNum, Me.EstComp, Me.JobNum, Me.JobComp)
                    Me.RefreshGrid()
                Case "Data"
                    'Dim download As Boolean
                    'Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
                    ''If e.Item.Value = "Data" Then                    
                    'download = dash.GetDataRefreshProject("", "")
                    ''End If
                    ''Me.radMenu1.Items(0).Selected = False
                    'Me.buildRG()
                    'Me.buildRGMonth()
                    'Me.buildRGYear()
                    'Me.RadGridComps.Rebind()
                    'Me.RadGridMonth.Rebind()
                    'Me.RadGridYear.Rebind()
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

            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashclienttimecompdetail&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashclienttimecompdetail&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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

    Private Sub RadGridComps_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComps.ItemDataBound
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
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
            Dim total As Decimal
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                'e.Item.Cells(3).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(3).Text))

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("DP_TM_DESC") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(2).Rows(j)("HOURS")
                                total += ds.Tables(2).Rows(j)("HOURS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("SC_DESCRIPTION") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(2).Rows(j)("HOURS")
                                total += ds.Tables(2).Rows(j)("HOURS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("HOURS")
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("HOURS")
                    Next
                    e.Item.Cells(4).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("HOURS")
                    Next
                    e.Item.Cells(5).Text = total
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("ACCT_NAME") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(2).Rows(j)("HOURS")
                                total += ds.Tables(2).Rows(j)("HOURS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("JT_DESC") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(2).Rows(j)("HOURS")
                                total += ds.Tables(2).Rows(j)("HOURS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridComps_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComps.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
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
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridComps.DataSource = Me.BuildClientDT
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridComps.DataSource = Me.BuildDivisionDT
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridComps.DataSource = Me.BuildProductDT
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridComps.DataSource = Me.BuildAccountExecutiveDT()
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridComps.DataSource = Me.BuildDeptDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridComps.DataSource = Me.BuildSalesClassDT()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridComps.DataSource = Me.BuildJobTypeDT()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function buildRGClient()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "HOURS"
            boundColumn.HeaderText = "Hours"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'boundColumn.DataFormatString = "{0:#,##0.00}"
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildClientDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add("HOURS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("HOURS") = ds.Tables(0).Rows(u)("HOURS")
                dtComps.Rows.Add(newrow)
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function buildRGDivision()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "HOURS"
            boundColumn.HeaderText = "Hours"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildDivisionDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            dtComps.Columns.Add("HOURS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                newrow.Item("HOURS") = ds.Tables(0).Rows(u)("HOURS")
                dtComps.Rows.Add(newrow)
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function buildRGProduct()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "HOURS"
            boundColumn.HeaderText = "Hours"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildProductDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(product)
            dtComps.Columns.Add("HOURS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(0).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("HOURS") = ds.Tables(0).Rows(u)("HOURS")
                dtComps.Rows.Add(newrow)
            Next

            Return dtComps
        Catch ex As Exception

        End Try
    End Function

    Private Function buildRG()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("DP_TM_DESC")
                    'boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildDeptDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("DP_TM_DESC"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(3).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(3).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(3).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(3).Rows(u)("PRD_DESCRIPTION")
                dtComps.Rows.Add(newrow)
            Next

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim total As Decimal = 0
            For k As Integer = 0 To dtComps.Rows.Count - 1
                For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dtWeek = ds.Tables(1).DefaultView
                    dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
                    dt = dtWeek.ToTable
                    For w As Integer = 0 To dt.Rows.Count - 1
                        For x As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString() Then
                                dtComps.Rows(k)(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                        Next
                    Next
                    dtComps.Rows(k)("Total") = total
                    total = 0
                Next
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

    Private Function buildRGAccountExecutive()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("ACCT_NAME")
                    'boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildAccountExecutiveDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("ACCT_NAME"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(3).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(3).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(3).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(3).Rows(u)("PRD_DESCRIPTION")
                dtComps.Rows.Add(newrow)
            Next

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim total As Decimal = 0
            For k As Integer = 0 To dtComps.Rows.Count - 1
                For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dtWeek = ds.Tables(1).DefaultView
                    dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
                    dt = dtWeek.ToTable
                    For w As Integer = 0 To dt.Rows.Count - 1
                        For x As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(x).ColumnName = dt.Rows(w)("ACCT_NAME").ToString() Then
                                dtComps.Rows(k)(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                        Next
                    Next
                    dtComps.Rows(k)("Total") = total
                    total = 0
                Next
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

    Private Function buildRGSalesClass()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("SC_DESCRIPTION")
                    'boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildSalesClassDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("SC_DESCRIPTION"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(3).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(3).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(3).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(3).Rows(u)("PRD_DESCRIPTION")
                dtComps.Rows.Add(newrow)
            Next

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim total As Decimal = 0
            For k As Integer = 0 To dtComps.Rows.Count - 1
                For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dtWeek = ds.Tables(1).DefaultView
                    dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
                    dt = dtWeek.ToTable
                    For w As Integer = 0 To dt.Rows.Count - 1
                        For x As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString() Then
                                dtComps.Rows(k)(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                        Next
                    Next
                    dtComps.Rows(k)("Total") = total
                    total = 0
                Next
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

    Private Function buildRGJobType()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("JT_DESC")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("JT_DESC")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("JT_DESC")
                    'boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

        Catch ex As Exception

        End Try
    End Function
    Private Function BuildJobTypeDT()
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
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetHours("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("JT_DESC"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(3).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(3).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(3).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(3).Rows(u)("PRD_DESCRIPTION")
                dtComps.Rows.Add(newrow)
            Next

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim total As Decimal = 0
            For k As Integer = 0 To dtComps.Rows.Count - 1
                For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dtWeek = ds.Tables(1).DefaultView
                    dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
                    dt = dtWeek.ToTable
                    For w As Integer = 0 To dt.Rows.Count - 1
                        For x As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(x).ColumnName = dt.Rows(w)("JT_DESC").ToString() Then
                                dtComps.Rows(k)(x) = dt.Rows(w)("HOURS")
                                total += CDec(dt.Rows(w)("HOURS"))
                            End If
                        Next
                    Next
                    dtComps.Rows(k)("Total") = total
                    total = 0
                Next
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
            'For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
            '    If MenuItem.Selected = True Then
            '        year = MenuItem.Text
            '    End If
            'Next
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim month As String = Me.DropMonth.SelectedValue
            ds = dash.GetPostPeriodsProject(year)
            With Me.DropMonth
                .DataSource = ds.Tables(1)
                .DataTextField = "PPDESC"
                .DataValueField = "PPPERIOD"
                .DataBind()
            End With
            Me.DropMonth.SelectedValue = month
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For j As Integer = 0 To Me.DropMonth.Items.Count - 1
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    If Me.DropMonth.Items(i).Value = ds.Tables(1).Rows(i)("PPPERIOD") Then
                        Dim d As New DateTime(DateTime.Now.Year, ds.Tables(1).Rows(i)("PPGLMONTH"), 1)
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
            'For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
            '    If MenuItem.Selected = True Then
            '        year = MenuItem.Text
            '    End If
            'Next
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                End If
            Next
            Dim week As String = Me.DropWeek.SelectedValue
            ds = dash.GetWeeks(Me.DropMonth.SelectedValue, year, 1, LoGlo.UserCultureGet())
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
            loadweeks()
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.buildRG()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.buildRGSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.buildRGAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.buildRGJobType()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.buildRGClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.buildRGDivision()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.buildRGProduct()
            End If
            Me.RadGridComps.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
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
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.buildRG()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.buildRGSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.buildRGAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.buildRGJobType()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.buildRGClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.buildRGDivision()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.buildRGProduct()
            End If
            Me.RadGridComps.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            ' Dim type As String
            For Each rtb As RadToolBarButton In Me.RadToolbarDashProject.Items
                If rtb.Checked = True And rtb.Value = "Month" Then
                    type = rtb.Value
                End If
                If rtb.Checked = True And rtb.Value = "YeartoDate" Then
                    type = rtb.Value
                End If
            Next
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.buildRG()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.buildRGSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.buildRGAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.buildRGJobType()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.buildRGClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.buildRGDivision()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.buildRGProduct()
            End If
            Me.RadGridComps.Rebind()
            Me.Title = "Projects By " & Me.DropLevel.SelectedItem.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Data"
                    Dim download As Boolean
                    Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
                    'If e.Item.Value = "Data" Then                    
                    download = dash.GetDataRefreshProject("", "")
                    If Me.DropLevel.SelectedValue = "dept" Then
                        Me.buildRG()
                    End If
                    If Me.DropLevel.SelectedValue = "SC" Then
                        Me.buildRGSalesClass()
                    End If
                    If Me.DropLevel.SelectedValue = "AE" Then
                        Me.buildRGAccountExecutive()
                    End If
                    If Me.DropLevel.SelectedValue = "JT" Then
                        Me.buildRGJobType()
                    End If
                    If Me.DropLevel.SelectedValue = "C" Then
                        Me.buildRGClient()
                    End If
                    If Me.DropLevel.SelectedValue = "CD" Then
                        Me.buildRGDivision()
                    End If
                    If Me.DropLevel.SelectedValue = "CDP" Then
                        Me.buildRGProduct()
                    End If
                    Me.RadGridComps.Rebind()
                Case Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                        If rtb.Checked = True Then
                            year = rtb.Text
                        End If
                    Next
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
                    If Me.DropLevel.SelectedValue = "dept" Then
                        Me.buildRG()
                    End If
                    If Me.DropLevel.SelectedValue = "SC" Then
                        Me.buildRGSalesClass()
                    End If
                    If Me.DropLevel.SelectedValue = "AE" Then
                        Me.buildRGAccountExecutive()
                    End If
                    If Me.DropLevel.SelectedValue = "JT" Then
                        Me.buildRGJobType()
                    End If
                    If Me.DropLevel.SelectedValue = "C" Then
                        Me.buildRGClient()
                    End If
                    If Me.DropLevel.SelectedValue = "CD" Then
                        Me.buildRGDivision()
                    End If
                    If Me.DropLevel.SelectedValue = "CDP" Then
                        Me.buildRGProduct()
                    End If
                    Me.RadGridComps.Rebind()
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Month"
                    If Me.DropLevel.SelectedValue = "dept" Then
                        Me.buildRG()
                    End If
                    If Me.DropLevel.SelectedValue = "SC" Then
                        Me.buildRGSalesClass()
                    End If
                    If Me.DropLevel.SelectedValue = "AE" Then
                        Me.buildRGAccountExecutive()
                    End If
                    If Me.DropLevel.SelectedValue = "JT" Then
                        Me.buildRGJobType()
                    End If
                    If Me.DropLevel.SelectedValue = "C" Then
                        Me.buildRGClient()
                    End If
                    If Me.DropLevel.SelectedValue = "CD" Then
                        Me.buildRGDivision()
                    End If
                    If Me.DropLevel.SelectedValue = "CDP" Then
                        Me.buildRGProduct()
                    End If
                    Me.RadGridComps.Rebind()
                Case "YeartoDate"
                    If Me.DropLevel.SelectedValue = "dept" Then
                        Me.buildRG()
                    End If
                    If Me.DropLevel.SelectedValue = "SC" Then
                        Me.buildRGSalesClass()
                    End If
                    If Me.DropLevel.SelectedValue = "AE" Then
                        Me.buildRGAccountExecutive()
                    End If
                    If Me.DropLevel.SelectedValue = "JT" Then
                        Me.buildRGJobType()
                    End If
                    If Me.DropLevel.SelectedValue = "C" Then
                        Me.buildRGClient()
                    End If
                    If Me.DropLevel.SelectedValue = "CD" Then
                        Me.buildRGDivision()
                    End If
                    If Me.DropLevel.SelectedValue = "CDP" Then
                        Me.buildRGProduct()
                    End If
                    Me.RadGridComps.Rebind()
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
                        'the page to go to                        
                        .Page = "DashboardClientTime.aspx"
                        'setting some properties of the class
                        '.Year = year
                        'adding a "one time" value that doesn't need to be in the class
                        .Add("month", Me.DropMonth.SelectedValue)
                        .Add("year", year)
                        .Add("range", type)
                        .Add("week", Me.DropWeek.SelectedValue)
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectComp.aspx")
                Case "Detail"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
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
                        .Add("project", project)
                        .Add("dash", dash)
                        .Go()
                    End With
                    'MiscFN.ResponseRedirect("DashboardProjectDetail.aspx")
                Case "Graphs"
                    qs = qs.FromCurrent()
                    With Response
                        dash = qs.GetValue("dash")
                    End With
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

#End Region

















End Class