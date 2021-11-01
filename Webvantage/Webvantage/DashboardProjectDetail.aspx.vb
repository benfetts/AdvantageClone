Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProjectDetail
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
    Protected WithEvents CheckBoxExport As CheckBox
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
            Me.CheckBoxExport = Me.RadToolbarPE.Items(7).FindControl("CheckBoxExport")
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
                    Dim rtb As RadToolBarButton = Me.RadToolbarProject.Items(11)
                    rtb.Checked = True
                End If
                dash = q.GetValue("dash")
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
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridComps.Visible = False
                Me.RadGridYear.Visible = False

            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridMonth.Visible = False
                Me.RadGridYear.Visible = False

            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridMonth.Visible = False
                Me.RadGridComps.Visible = False

            End If
            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
                Me.RadToolbarProject.Items(9).Enabled = False
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    If dash = "M" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Week By " & Me.DropLevel.SelectedItem.Text
                        Me.CheckBoxExport.Visible = False
                    End If
                    If dash = "Y" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Else
                    If dash = "M" Then
                        Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
                        Me.CheckBoxExport.Visible = False
                    End If
                    If dash = "Y" Then
                        Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                End If
            Else
                If dash = "M" Then
                    Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
                End If
                If dash = "W" Then
                    Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    Me.CheckBoxExport.Visible = False
                End If
                If dash = "Y" Then
                    Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
                End If
            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    Me.RefreshGrid()
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
            If dash = "W" Then
                Me.CheckBoxExport.Checked = True
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojdetail&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojdetail&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
            Dim total As Integer
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then


            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                e.Item.Cells(3).Text = "Totals:"
                If Me.DropLevel.SelectedValue = "dept" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
                            End If
                            If Me.RadGridComps.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                    Next
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                        For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                            If Me.RadGridComps.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                                e.Item.Cells(Me.RadGridComps.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                                total += ds.Tables(3).Rows(j)("COMPS")
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
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridComps.DataSource = BuildWeekDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridComps.DataSource = BuildWeekDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridComps.DataSource = BuildWeekDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridComps.DataSource = BuildWeekDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridComps.DataSource = BuildWeekDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridComps.DataSource = BuildWeekDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridComps.DataSource = BuildWeekDTJobType()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridMonth_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMonth.ItemDataBound
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
            Dim total As Integer
            Dim totalmonth As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                e.Item.Cells(2).Text = "Totals:"
                If Me.DropLevel.SelectedValue = "dept" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Department" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Product" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    For i As Integer = 0 To Me.RadGridMonth.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalmonth = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridMonth.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("MONTH_OPENED") Then
                                totalmonth += CDec(ds.Tables(2).Rows(j)("COMPS"))
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridMonth.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                            e.Item.Cells(Me.RadGridMonth.MasterTableView.Columns(i).OrderIndex).Text = totalmonth
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridMonth_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMonth.NeedDataSource
        Try
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridMonth.DataSource = BuildMonthDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridMonth.DataSource = BuildMonthDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridMonth.DataSource = BuildMonthDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridMonth.DataSource = BuildMonthDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridMonth.DataSource = BuildMonthDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridMonth.DataSource = BuildMonthDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridMonth.DataSource = BuildMonthDTJobType()
            End If

        Catch ex As Exception

        End Try
    End Sub

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
            Dim totalyear As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                e.Item.Cells(2).Text = "Totals:"
                If Me.DropLevel.SelectedValue = "dept" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("DP_TM_DESC") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Department" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("SC_DESCRIPTION") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Sales Class" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("CL_NAME").ToString() & "/" & ds.Tables(3).Rows(j)("DIV_NAME") & "/" & ds.Tables(3).Rows(j)("PRD_DESCRIPTION") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Client" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Division" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Product" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(3).Rows(j)("ACCT_NAME") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Account Executive" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    For i As Integer = 0 To Me.RadGridYear.MasterTableView.Columns.Count - 1
                        'For j As Integer = 0 To ds.Tables(3).Rows.Count - 1
                        '    Dim str As String = Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "")
                        '    If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Substring(3) = ds.Tables(3).Rows(j)("JT_DESC") Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = ds.Tables(3).Rows(j)("COMPS")
                        '        total += ds.Tables(3).Rows(j)("COMPS")
                        '    End If
                        '    If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                        '        e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                        '    End If
                        'Next
                        totalyear = 0
                        For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                            If Me.RadGridYear.MasterTableView.Columns(i).UniqueName.Replace("col", "") = ds.Tables(2).Rows(j)("YEAR_OPENED") Then
                                totalyear += ds.Tables(2).Rows(j)("COMPS")
                                total += ds.Tables(2).Rows(j)("COMPS")
                            End If
                            If Me.RadGridYear.MasterTableView.Columns(i).HeaderText = "Total" Then
                                e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = total
                            End If
                        Next
                        If Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Total" And Me.RadGridYear.MasterTableView.Columns(i).HeaderText <> "Job Type" Then
                            e.Item.Cells(Me.RadGridYear.MasterTableView.Columns(i).OrderIndex).Text = totalyear
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridYear_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridYear.NeedDataSource
        Try
            If Me.DropLevel.SelectedValue = "dept" Then
                Me.RadGridYear.DataSource = BuildYearDT()
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                Me.RadGridYear.DataSource = BuildYearDTSalesClass()
            End If
            If Me.DropLevel.SelectedValue = "C" Then
                Me.RadGridYear.DataSource = BuildYearDTClient()
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                Me.RadGridYear.DataSource = BuildYearDTCD()
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                Me.RadGridYear.DataSource = BuildYearDTCDP()
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                Me.RadGridYear.DataSource = BuildYearDTAccountExecutive()
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                Me.RadGridYear.DataSource = BuildYearDTJobType()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridYear.SelectedIndexChanged
        Try
            Dim code As String
            Dim name As String
            Dim level As String
            Dim divcode As String = ""
            Dim prdcode As String = ""
            Dim divname As String = ""
            Dim prdname As String = ""
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            If Me.DropLevel.SelectedValue = "C" Then
                level = "cli"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                level = "div"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        'name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(4).Text
                        name = gridDataItem.Cells(3).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                level = "prd"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        'name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(4).Text
                        divname = gridDataItem.Cells(3).Text
                        prdcode = gridDataItem.Cells(6).Text
                        name = gridDataItem.Cells(5).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                level = "dept"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                level = "sc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                level = "acc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                level = "jt"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridYear.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            With q
                'the page to go to
                .Page = "DashboardProjectList.aspx"
                'setting some properties of the class
                '.Year = year
                'adding a "one time" value that doesn't need to be in the class
                .Add("year", year)
                .Add("month", Me.DropMonth.SelectedValue)
                .Add("range", type)
                .Add("week", Me.DropWeek.SelectedValue)
                .Add("project", project)
                .Add("type", level)
                .Add("code", code)
                .Add("name", name)
                .Add("divcode", divcode)
                .Add("prdcode", prdcode)
                .Add("divname", divname)
                .Add("prdname", prdname)
                .Go()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridMonth.SelectedIndexChanged
        Try
            Dim code As String
            Dim name As String
            Dim level As String
            Dim divcode As String = ""
            Dim prdcode As String = ""
            Dim divname As String = ""
            Dim prdname As String = ""
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            If Me.DropLevel.SelectedValue = "C" Then
                level = "cli"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                level = "div"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        'name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(4).Text
                        name = gridDataItem.Cells(3).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                level = "prd"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        'name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(4).Text
                        divname = gridDataItem.Cells(3).Text
                        prdcode = gridDataItem.Cells(6).Text
                        name = gridDataItem.Cells(5).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                level = "dept"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                level = "sc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                level = "acc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                level = "jt"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMonth.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            With q
                'the page to go to
                .Page = "DashboardProjectList.aspx"
                'setting some properties of the class
                '.Year = year
                'adding a "one time" value that doesn't need to be in the class
                .Add("year", year)
                .Add("month", Me.DropMonth.SelectedValue)
                .Add("range", type)
                .Add("week", Me.DropWeek.SelectedValue)
                .Add("project", project)
                .Add("type", level)
                .Add("code", code)
                .Add("name", name)
                .Add("divcode", divcode)
                .Add("prdcode", prdcode)
                .Add("divname", divname)
                .Add("prdname", prdname)
                .Go()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridComps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridComps.SelectedIndexChanged
        Try
            Dim code As String
            Dim name As String
            Dim level As String
            Dim divcode As String = ""
            Dim prdcode As String = ""
            Dim divname As String = ""
            Dim prdname As String = ""
            Dim ddstart As String = ""
            Dim ddend As String = ""
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            If Me.DropLevel.SelectedValue = "C" Then
                level = "cli"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                level = "div"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                level = "prd"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                level = "dept"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                level = "sc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                level = "acc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                level = "jt"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        ddstart = gridDataItem.GetDataKeyValue("WS")
                        ddend = gridDataItem.GetDataKeyValue("WE")
                    End If
                Next
            End If
            With q
                'the page to go to
                .Page = "DashboardProjectList.aspx"
                'setting some properties of the class
                '.Year = year
                'adding a "one time" value that doesn't need to be in the class
                .Add("year", year)
                .Add("month", Me.DropMonth.SelectedValue)
                .Add("range", type)
                .Add("week", Me.DropWeek.SelectedValue)
                .Add("project", project)
                .Add("type", level)
                .Add("code", code)
                .Add("name", name)
                .Add("divcode", divcode)
                .Add("prdcode", prdcode)
                .Add("divname", divname)
                .Add("prdname", prdname)
                .Add("page", "week")
                .Add("ddstart", ddstart)
                .Add("ddend", ddend)
                .Go()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Function BuildYearDT()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Department")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("DP_TM_CODE")
                newrow.Item("Department") = ds.Tables(1).Rows(j)("DP_TM_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "DP_TM_CODE = '" & ds.Tables(1).Rows(j)("DP_TM_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTSalesClass()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Sales Class")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("SC_CODE")
                newrow.Item("Sales Class") = ds.Tables(1).Rows(j)("SC_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "SC_CODE = '" & ds.Tables(1).Rows(j)("SC_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTClient()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim dateOpened As DataColumn = New DataColumn("Client")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTCD()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            dtComps.Columns.Add(colclient)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            dtComps.Columns.Add(coldivision)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(1).Rows(j)("DIV_CODE")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTCDP()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            Dim colproduct As DataColumn = New DataColumn("Product")
            dtComps.Columns.Add(colclient)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            dtComps.Columns.Add(coldivision)
            Dim prdcodecol As DataColumn = New DataColumn("PRDCODE")
            dtComps.Columns.Add(prdcodecol)
            dtComps.Columns.Add(colproduct)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(1).Rows(j)("DIV_CODE")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                newrow.Item("PRDCODE") = ds.Tables(1).Rows(j)("PRD_CODE")
                newrow.Item("Product") = ds.Tables(1).Rows(j)("PRD_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "' AND PRD_CODE = '" & ds.Tables(1).Rows(j)("PRD_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTAccountExecutive()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Account Executive")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("ACCT_EXEC")
                newrow.Item("Account Executive") = ds.Tables(1).Rows(j)("ACCT_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "ACCT_EXEC = '" & ds.Tables(1).Rows(j)("ACCT_EXEC") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
    Private Function BuildYearDTJobType()
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
            ds = dash.GetCompsByYearByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dateOpened As DataColumn = New DataColumn("Job Type")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("YEAR_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("JOB_TYPE")
                newrow.Item("Job Type") = ds.Tables(1).Rows(j)("JT_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "JOB_TYPE = '" & ds.Tables(1).Rows(j)("JOB_TYPE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("YEAR_OPENED").ToString() Then
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
            boundColumn.DataField = "Department"
            boundColumn.HeaderText = "Department"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Sales Class"
            boundColumn.HeaderText = "Sales Class"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Product"
            boundColumn.HeaderText = "Product"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRDCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridYear.MasterTableView.Columns.Add(boundColumn)
            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Account Executive"
            boundColumn.HeaderText = "Account Executive"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            boundColumn.DataField = "Job Type"
            boundColumn.HeaderText = "Job Type"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.HeaderText = ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("YEAR_OPENED")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridYear.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridYear.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function

    Private Function BuildWeekDT()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC"), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 2 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", ds.Tables(1).Rows(i)("DP_TM_CODE"), "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("DP_TM_DESC").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDT()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Department")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("DP_TM_CODE")
                newrow.Item("Department") = ds.Tables(1).Rows(j)("DP_TM_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "DP_TM_CODE = '" & ds.Tables(1).Rows(j)("DP_TM_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTSalesClass()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION"), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", ds.Tables(1).Rows(i)("SC_CODE"), "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("SC_DESCRIPTION").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTSalesClass()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Sales Class")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("SC_CODE")
                newrow.Item("Sales Class") = ds.Tables(1).Rows(j)("SC_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "SC_CODE = '" & ds.Tables(1).Rows(j)("SC_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTClient()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME"), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTClient()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim dateOpened As DataColumn = New DataColumn("Client")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTCD()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString(), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString() & "/" & dt.Rows(j)("DIV_NAME").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCD()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            dtComps.Columns.Add(colclient)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            dtComps.Columns.Add(coldivision)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(1).Rows(j)("DIV_CODE")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTCDP()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString(), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString() & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", ds.Tables(1).Rows(i)("CL_CODE"), "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("CL_NAME").ToString() & "/" & dt.Rows(j)("DIV_NAME").ToString() & "/" & dt.Rows(j)("PRD_DESCRIPTION").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTCDP()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim colclient As DataColumn = New DataColumn("Client")
            Dim coldivision As DataColumn = New DataColumn("Division")
            Dim colproduct As DataColumn = New DataColumn("Product")
            dtComps.Columns.Add(colclient)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            dtComps.Columns.Add(coldivision)
            Dim prdcodecol As DataColumn = New DataColumn("PRDCODE")
            dtComps.Columns.Add(prdcodecol)
            dtComps.Columns.Add(colproduct)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("CL_CODE")
                newrow.Item("Client") = ds.Tables(1).Rows(j)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(1).Rows(j)("DIV_CODE")
                newrow.Item("Division") = ds.Tables(1).Rows(j)("DIV_NAME")
                newrow.Item("PRDCODE") = ds.Tables(1).Rows(j)("PRD_CODE")
                newrow.Item("Product") = ds.Tables(1).Rows(j)("PRD_DESCRIPTION")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "CL_CODE = '" & ds.Tables(1).Rows(j)("CL_CODE") & "' AND DIV_CODE = '" & ds.Tables(1).Rows(j)("DIV_CODE") & "' AND PRD_CODE = '" & ds.Tables(1).Rows(j)("PRD_CODE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTAccountExecutive()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("ACCT_NAME"), System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(1).Rows(i)("ACCT_NAME") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", ds.Tables(1).Rows(i)("ACCT_EXEC"), "", "", "", "", 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("ACCT_NAME").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTAccountExecutive()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(deptcol)
            Dim dateOpened As DataColumn = New DataColumn("Account Executive")
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("ACCT_EXEC")
                newrow.Item("Account Executive") = ds.Tables(1).Rows(j)("ACCT_NAME")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "ACCT_EXEC = '" & ds.Tables(1).Rows(j)("ACCT_EXEC") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
    Private Function BuildWeekDTJobType()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim dateOpened As DataColumn = New DataColumn("Date Opened")
            Dim dateRange As DataColumn = New DataColumn("Range")
            Dim ws As DataColumn = New DataColumn("WS")
            Dim we As DataColumn = New DataColumn("WE")
            dtComps.Columns.Add(dateOpened)
            dtComps.Columns.Add(dateRange)
            dtComps.Columns.Add(ws)
            dtComps.Columns.Add(we)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    If IsDBNull(ds.Tables(1).Rows(i)("JT_DESC")) = False Then
                        dc = New DataColumn(ds.Tables(1).Rows(i)("JT_DESC"), System.Type.GetType("System.Int32"))
                    Else
                        dc = New DataColumn(ds.Tables(1).Rows(i)("JOB_TYPE"), System.Type.GetType("System.Int32"))
                    End If
                    dtComps.Columns.Add(dc)

                Next
            End If

            dtComps.Columns.Add("Total")

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    If IsDBNull(ds.Tables(1).Rows(i)("JT_DESC")) = False Then
                        dc = New DataColumn(ds.Tables(1).Rows(i)("JT_DESC") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    Else
                        dc = New DataColumn(ds.Tables(1).Rows(i)("JOB_TYPE") & " (4 Week Avg)", System.Type.GetType("System.Int32"))
                    End If
                    dtComps.Columns.Add(dc)

                Next
            End If

            Dim dtWeek As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("Date Opened") = ds.Tables(0).Rows(j)("DATE_OPENED")
                Dim sdate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_START"))
                Dim edate As DateTime = CDate(ds.Tables(0).Rows(j)("WEEK_END"))
                If LoGlo.UserCultureGet() = "en-US" Or LoGlo.UserCultureGet = "zh-CN" Then
                    newrow.Item("Range") = sdate.Month & "/" & sdate.Day & " - " & edate.Month & "/" & edate.Day
                ElseIf LoGlo.UserCultureGet = "fr-FR" Or LoGlo.UserCultureGet = "es-ES" Then
                    newrow.Item("Range") = sdate.Day & "/" & sdate.Month & " - " & edate.Day & "/" & edate.Month
                Else
                    newrow.Item("Range") = sdate.Day & "." & sdate.Month & " - " & edate.Day & "." & edate.Month
                End If
                newrow.Item("WS") = ds.Tables(0).Rows(j)("WEEK_START")
                newrow.Item("WE") = ds.Tables(0).Rows(j)("WEEK_END")
                dtWeek = ds.Tables(2).DefaultView
                dtWeek.RowFilter = "DATE_OPENED = " & ds.Tables(0).Rows(j)("DATE_OPENED") & " AND WEEK_START = '" & ds.Tables(0).Rows(j)("WEEK_START") & "'"
                dt = dtWeek.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 3 To dtComps.Columns.Count - 1
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

            Dim dsAvg As DataSet
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                dsAvg = dash.GetCompsByWeekByDeptAvg("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", "", ds.Tables(1).Rows(i)("JOB_TYPE"), 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)
                For p As Integer = 0 To dtComps.Rows.Count - 1
                    dtWeek = dsAvg.Tables(0).DefaultView
                    dtWeek.RowFilter = "DATE_OPENED = " & dtComps.Rows(p)("Date Opened") & " AND WEEK_START = '" & dtComps.Rows(p)("WS") & "'"
                    dt = dtWeek.ToTable
                    For j As Integer = 0 To dt.Rows.Count - 1
                        For q As Integer = 0 To dtComps.Columns.Count - 1
                            If dtComps.Columns(q).ColumnName = dt.Rows(j)("JT_DESC").ToString() Then
                                dtComps.Rows(p)(q) = dt.Rows(j)("AVERAGE")
                            End If
                        Next
                    Next
                Next
            Next



            Return dtComps
        Catch ex As Exception

        End Try
    End Function
    Private Function BuildMonthDTJobType()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dateOpened As DataColumn = New DataColumn("Job Type")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dateOpened)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(ds.Tables(0).Rows(i)("MONTH_OPENED"))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Integer = 0
            For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(1).Rows(j)("JOB_TYPE")
                newrow.Item("Job Type") = ds.Tables(1).Rows(j)("JT_DESC")
                dtMonth = ds.Tables(2).DefaultView
                dtMonth.RowFilter = "JOB_TYPE = '" & ds.Tables(1).Rows(j)("JOB_TYPE") & "'"
                dt = dtMonth.ToTable
                For w As Integer = 0 To dt.Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = dt.Rows(w)("MONTH_OPENED").ToString() Then
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("DP_TM_DESC").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("DP_TM_DESC") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonth()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Department"
            boundColumn.HeaderText = "Department"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("SC_DESCRIPTION").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("SC_DESCRIPTION") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthSalesClass()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Sales Class"
            boundColumn.HeaderText = "Sales Class"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthClient()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGCD()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString().ToString.Replace(" ", "") & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthCD()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGCDP()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("CL_NAME").ToString().ToString.Replace(" ", "") & "/" & ds.Tables(1).Rows(i)("DIV_NAME").ToString.Replace(" ", "") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("CL_NAME").ToString() & "/" & ds.Tables(1).Rows(i)("DIV_NAME") & "/" & ds.Tables(1).Rows(i)("PRD_DESCRIPTION") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthCDP()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Client"
            boundColumn.HeaderText = "Client"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Division"
            boundColumn.HeaderText = "Division"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Product"
            boundColumn.HeaderText = "Product"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRDCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("ACCT_NAME")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("ACCT_NAME").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("ACCT_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("ACCT_NAME") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthAccountExecutive()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Account Executive"
            boundColumn.HeaderText = "Account Executive"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


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
            ds = dash.GetCompsByWeekByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Date Opened"
            boundColumn.HeaderText = "Date Opened"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.Visible = False
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Range"
            boundColumn.HeaderText = "Range"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(70)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("JT_DESC")
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.UniqueName = "col" & ds.Tables(1).Rows(i)("JT_DESC").ToString.Replace(" ", "")
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If


            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            If ds.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(1).Rows(i)("JT_DESC") & " (4 Week Avg)"
                    boundColumn.HeaderText = ds.Tables(1).Rows(i)("JT_DESC") & " (4 Week Avg)"
                    boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)
                    boundColumn.DataType = System.Type.GetType("System.Int32")
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    RadGridComps.MasterTableView.Columns.Add(boundColumn)
                Next
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGMonthJobType()
        Try
            Me.RadGridMonth.MasterTableView.Columns.Clear()
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
            ds = dash.GetCompsByMonthByDept("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Job Type"
            boundColumn.HeaderText = "Job Type"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = ds.Tables(0).Rows(i)("MONTH_OPENED")
                    Dim str() As String = ds.Tables(0).Rows(i)("MONTH_OPENED").ToString.Split("-")
                    Dim d As New DateTime(str(1), ds.Tables(0).Rows(i)("MTH"), 1)
                    boundColumn.HeaderText = String.Format(c, "{0:MMM}", d) & "-" & str(1)
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH_OPENED")
                    RadGridMonth.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridMonth.MasterTableView.Columns.Add(boundColumn)


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
            'Dim month As String = Me.DropMonth.SelectedValue
            'ds = dash.GetPostPeriodsProject(year)
            'With Me.DropMonth
            '    .DataSource = ds.Tables(1)
            '    .DataTextField = "PPDESC"
            '    .DataValueField = "PPPERIOD"
            '    .DataBind()
            'End With
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
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            loadweeks()
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropWeek.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Week", "", Me.DropWeek.SelectedValue)
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DropLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropLevel.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Level", "", Me.DropLevel.SelectedValue)
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
                'Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
                ' Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
                'Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
            End If
            If project = "Cancelled" Then
                If iscancel = False Then
                    If dash = "M" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Else
                    If dash = "M" Then
                        Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                End If
            Else
                If dash = "M" Then
                    Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
                End If
                If dash = "W" Then
                    Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
                End If
                If dash = "Y" Then
                    Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarData_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarData.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Data"
                    Dim download As Boolean
                    Dim dashdata As New cDashboard(Session("ConnString"), Session("UserCode"))
                    'If e.Item.Value = "Data" Then                    
                    download = dashdata.GetDataRefreshProject("", "")
                    'End If
                    'Me.radMenu1.Items(0).Selected = False
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If
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
                    Dim q As New AdvantageFramework.Web.QueryString()
                    q = q.FromCurrent()
                    With Response
                        dash = q.GetValue("dash")
                    End With
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If
            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashProject.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If
                Case "YeartoDate"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarProject_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProject.ButtonClick
        Try
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            With Response
                dash = q.GetValue("dash")
            End With
            Select Case e.Item.Value
                Case "Created"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Case "Completed"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Case "Due"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Case "Pending"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                        Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                Case "Cancelled"
                    If dash = "M" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGMonth()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGMonthSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGMonthClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGMonthCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGMonthCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGMonthAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGMonthJobType()
                        End If
                        Me.RadGridMonth.Rebind()
                        'Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "W" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRG()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGJobType()
                        End If
                        Me.RadGridComps.Rebind()
                        'Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If dash = "Y" Then
                        If Me.DropLevel.SelectedValue = "dept" Then
                            Me.buildRGYear()
                        End If
                        If Me.DropLevel.SelectedValue = "SC" Then
                            Me.buildRGYearSalesClass()
                        End If
                        If Me.DropLevel.SelectedValue = "C" Then
                            Me.buildRGYearClient()
                        End If
                        If Me.DropLevel.SelectedValue = "CD" Then
                            Me.buildRGYearCD()
                        End If
                        If Me.DropLevel.SelectedValue = "CDP" Then
                            Me.buildRGYearCDP()
                        End If
                        If Me.DropLevel.SelectedValue = "AE" Then
                            Me.buildRGYearAccountExecutive()
                        End If
                        If Me.DropLevel.SelectedValue = "JT" Then
                            Me.buildRGYearJobType()
                        End If
                        Me.RadGridYear.Rebind()
                        'Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                    End If
                    If iscancel = False Then
                        If dash = "M" Then
                            Me.Title = "Projects in Status [" & cancelDesc & "] Each Month By " & Me.DropLevel.SelectedItem.Text
                        End If
                        If dash = "W" Then
                            Me.Title = "Projects in Status [" & cancelDesc & "] Each Week By " & Me.DropLevel.SelectedItem.Text
                        End If
                        If dash = "Y" Then
                            Me.Title = "Projects in Status [" & cancelDesc & "] Each Year By " & Me.DropLevel.SelectedItem.Text
                        End If
                    Else
                        If dash = "M" Then
                            Me.Title = "Projects " & e.Item.Value & " Each Month By " & Me.DropLevel.SelectedItem.Text
                        End If
                        If dash = "W" Then
                            Me.Title = "Projects " & e.Item.Value & " Each Week By " & Me.DropLevel.SelectedItem.Text
                        End If
                        If dash = "Y" Then
                            Me.Title = "Projects " & e.Item.Value & " Each Year By " & Me.DropLevel.SelectedItem.Text
                        End If
                    End If
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

    Private Sub CheckBoxExport_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExport.CheckedChanged
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
            If dash = "M" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If
                Me.RadGridMonth.Rebind()
                'Me.Title = "Projects " & project & " Each Month By " & Me.DropLevel.SelectedItem.Text
            End If
            If dash = "W" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If
                Me.RadGridComps.Rebind()
                ' Me.Title = "Projects " & project & " Each Week By " & Me.DropLevel.SelectedItem.Text
            End If
            If dash = "Y" Then
                If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If
                Me.RadGridYear.Rebind()
                'Me.Title = "Projects " & project & " Each Year By " & Me.DropLevel.SelectedItem.Text
            End If

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojdetail&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojdetail&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridMonth_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridMonth.SortCommand
        Try

            If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGMonth()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGMonthSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGMonthClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGMonthCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGMonthCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGMonthAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGMonthJobType()
                End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridYear_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridYear.SortCommand
        Try

            If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRGYear()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGYearSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGYearClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGYearCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGYearCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGYearAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGYearJobType()
                End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridComps_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridComps.SortCommand
        Try

            If Me.DropLevel.SelectedValue = "dept" Then
                    Me.buildRG()
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    Me.buildRGSalesClass()
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    Me.buildRGClient()
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    Me.buildRGCD()
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    Me.buildRGCDP()
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    Me.buildRGAccountExecutive()
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    Me.buildRGJobType()
                End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "


#End Region



















End Class
