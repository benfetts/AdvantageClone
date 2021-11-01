Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProjectCompDetail
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
            If q.GetValue("project") = "Pending" Or (q.GetValue("project") = "Cancelled" And iscancel = False) Then
                Me.RadToolbarNav.Items(4).Enabled = False
                Me.RadToolbarNav.Items(6).Enabled = False
                Me.RadToolbarNav.Items(8).Enabled = False
                Me.RadToolbarDashProject.Items(1).Enabled = False
                Me.RadToolbarDashProject.Items(3).Enabled = False
                Me.RadToolbarDashProject.Items(5).Enabled = False
                Me.RadToolbarDashProject.Items(7).Enabled = False
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
            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.Title = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text
            End If
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
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojcompdetail&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojcompdetail&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&dash=" & dash & "&level=" & Me.DropLevel.SelectedValue & "&ln=" & Me.DropLevel.SelectedItem.Text & "&eopt=" & Me.CheckBoxExport.Checked & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, "", "", "", "", "", "", 0, 1, Me.DropLevel.SelectedValue, "", False, Session("UserCode"), type, project, countyear)
            Dim total As Integer
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then


            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                If Me.DropLevel.SelectedValue = "dept" Then
                    e.Item.Cells(3).Text = "Totals:"
                    ' For i As Integer = 0 To Me.RadGridComps.MasterTableView.Columns.Count - 1
                    For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                        total += ds.Tables(2).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(6).Text = total.ToString
                    'Next
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                        total += ds.Tables(2).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(6).Text = total.ToString
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(4).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        total += ds.Tables(0).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(5).Text = total
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                        total += ds.Tables(2).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(6).Text = total.ToString
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    e.Item.Cells(3).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(2).Rows.Count - 1
                        total += ds.Tables(2).Rows(j)("COMPS")
                    Next
                    e.Item.Cells(6).Text = total.ToString
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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clcodecol)
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("CL_CODE")
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("COMPS") = ds.Tables(0).Rows(u)("COMPS")
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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("CL_CODE")
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                newrow.Item("COMPS") = ds.Tables(0).Rows(u)("COMPS")
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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim total As Integer = 0
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(product)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("CL_CODE")
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(0).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("COMPS") = ds.Tables(0).Rows(u)("COMPS")
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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DP_TM_DESC"
            boundColumn.HeaderText = "Department"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
            boundColumn.UniqueName = "col" & "DP_TM_DESC"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            '    Next
            'End If
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridComps.MasterTableView.Columns.Add(boundColumn)

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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            dc = New DataColumn("DP_TM_DESC")
            dtComps.Columns.Add(dc)
            dc = New DataColumn("COMPS")
            dtComps.Columns.Add(dc)
            '    Next
            'End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(1).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(1).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(1).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("DP_TM_DESC") = ds.Tables(1).Rows(u)("DP_TM_DESC")
                newrow.Item("COMPS") = ds.Tables(1).Rows(u)("COMPS")
                dtComps.Rows.Add(newrow)
            Next

            'Dim dtWeek As DataView
            'Dim dt As DataTable
            'Dim total As Integer = 0
            'For k As Integer = 0 To dtComps.Rows.Count - 1
            '    For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '        dtWeek = ds.Tables(1).DefaultView
            '        dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
            '        dt = dtWeek.ToTable
            '        For w As Integer = 0 To dt.Rows.Count - 1
            '            For x As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(x).ColumnName = dt.Rows(w)("DP_TM_DESC").ToString() Then
            '                    dtComps.Rows(k)(x) = dt.Rows(w)("COMPS")
            '                    total += CInt(dt.Rows(w)("COMPS"))
            '                End If
            '            Next
            '        Next
            '        dtComps.Rows(k)("Total") = total
            '        total = 0
            '    Next
            'Next

            'For p As Integer = 0 To dtComps.Rows.Count - 1
            '    For q As Integer = 0 To dtComps.Columns.Count - 1
            '        If dtComps.Rows(p)(q).ToString() = "" Then
            '            dtComps.Rows(p)(q) = 0
            '        End If
            '    Next
            'Next


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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "ACCT_NAME"
            boundColumn.HeaderText = "Account Executive"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
            boundColumn.UniqueName = "col" & "ACCT_NAME"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            '    Next
            'End If
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridComps.MasterTableView.Columns.Add(boundColumn)

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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            dc = New DataColumn("ACCT_NAME")
            dtComps.Columns.Add(dc)
            dc = New DataColumn("COMPS")
            dtComps.Columns.Add(dc)
            '    Next
            'End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(1).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(1).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(1).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("ACCT_NAME") = ds.Tables(1).Rows(u)("ACCT_NAME")
                newrow.Item("COMPS") = ds.Tables(1).Rows(u)("COMPS")
                dtComps.Rows.Add(newrow)
            Next

            'Dim dtWeek As DataView
            'Dim dt As DataTable
            'Dim total As Integer = 0
            'For k As Integer = 0 To dtComps.Rows.Count - 1
            '    For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '        dtWeek = ds.Tables(1).DefaultView
            '        dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
            '        dt = dtWeek.ToTable
            '        For w As Integer = 0 To dt.Rows.Count - 1
            '            For x As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(x).ColumnName = dt.Rows(w)("ACCT_NAME").ToString() Then
            '                    dtComps.Rows(k)(x) = dt.Rows(w)("COMPS")
            '                    total += CInt(dt.Rows(w)("COMPS"))
            '                End If
            '            Next
            '        Next
            '        dtComps.Rows(k)("Total") = total
            '        total = 0
            '    Next
            'Next

            'For p As Integer = 0 To dtComps.Rows.Count - 1
            '    For q As Integer = 0 To dtComps.Columns.Count - 1
            '        If dtComps.Rows(p)(q).ToString() = "" Then
            '            dtComps.Rows(p)(q) = 0
            '        End If
            '    Next
            'Next


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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "SC_DESCRIPTION"
            boundColumn.HeaderText = "Sales Class"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
            boundColumn.UniqueName = "col" & "SC_DESCRIPTION"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            '    Next
            'End If
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridComps.MasterTableView.Columns.Add(boundColumn)

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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            dc = New DataColumn("SC_DESCRIPTION")
            dtComps.Columns.Add(dc)
            dc = New DataColumn("COMPS")
            dtComps.Columns.Add(dc)

            '    Next
            'End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(1).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(1).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(1).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("SC_DESCRIPTION") = ds.Tables(1).Rows(u)("SC_DESCRIPTION")
                newrow.Item("COMPS") = ds.Tables(1).Rows(u)("COMPS")
                dtComps.Rows.Add(newrow)
            Next

            'Dim dtWeek As DataView
            'Dim dt As DataTable
            'Dim total As Integer = 0
            'For k As Integer = 0 To dtComps.Rows.Count - 1
            '    For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '        dtWeek = ds.Tables(1).DefaultView
            '        dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
            '        dt = dtWeek.ToTable
            '        For w As Integer = 0 To dt.Rows.Count - 1
            '            For x As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(x).ColumnName = dt.Rows(w)("SC_DESCRIPTION").ToString() Then
            '                    dtComps.Rows(k)(x) = dt.Rows(w)("COMPS")
            '                    total += CInt(dt.Rows(w)("COMPS"))
            '                End If
            '            Next
            '        Next
            '        dtComps.Rows(k)("Total") = total
            '        total = 0
            '    Next
            'Next

            'For p As Integer = 0 To dtComps.Rows.Count - 1
            '    For q As Integer = 0 To dtComps.Columns.Count - 1
            '        If dtComps.Rows(p)(q).ToString() = "" Then
            '            dtComps.Rows(p)(q) = 0
            '        End If
            '    Next
            'Next


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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIV_NAME"
            boundColumn.HeaderText = "Division"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRD_DESCRIPTION"
            boundColumn.HeaderText = "Product"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)

            'Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "JT_DESC"
            boundColumn.HeaderText = "Job Type"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75)
            boundColumn.UniqueName = "col" & "JT_DESC"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            '    Next
            'End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridComps.MasterTableView.Columns.Add(boundColumn)

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
            ds = dash.GetComps("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(clientcol)
            dtComps.Columns.Add(division)
            dtComps.Columns.Add(product)

            Dim dc As DataColumn
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            dc = New DataColumn("JT_DESC")
            dtComps.Columns.Add(dc)
            dc = New DataColumn("COMPS")
            dtComps.Columns.Add(dc)

            '    Next
            'End If

            dtComps.Columns.Add("Total")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(1).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CL_NAME") = ds.Tables(1).Rows(u)("CL_NAME")
                newrow.Item("DIV_NAME") = ds.Tables(1).Rows(u)("DIV_NAME")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(1).Rows(u)("PRD_DESCRIPTION")
                newrow.Item("JT_DESC") = ds.Tables(1).Rows(u)("JT_DESC")
                newrow.Item("COMPS") = ds.Tables(1).Rows(u)("COMPS")
                dtComps.Rows.Add(newrow)
            Next

            'Dim dtWeek As DataView
            'Dim dt As DataTable
            'Dim total As Integer = 0
            'For k As Integer = 0 To dtComps.Rows.Count - 1
            '    For j As Integer = 0 To ds.Tables(1).Rows.Count - 1
            '        dtWeek = ds.Tables(1).DefaultView
            '        dtWeek.RowFilter = "CL_NAME = '" & dtComps.Rows(k)("CL_NAME") & "' AND DIV_NAME = '" & dtComps.Rows(k)("DIV_NAME") & "' AND PRD_DESCRIPTION = '" & dtComps.Rows(k)("PRD_DESCRIPTION") & "'"
            '        dt = dtWeek.ToTable
            '        For w As Integer = 0 To dt.Rows.Count - 1
            '            For x As Integer = 0 To dtComps.Columns.Count - 1
            '                If dtComps.Columns(x).ColumnName = dt.Rows(w)("JT_DESC").ToString() Then
            '                    dtComps.Rows(k)(x) = dt.Rows(w)("COMPS")
            '                    total += CInt(dt.Rows(w)("COMPS"))
            '                End If
            '            Next
            '        Next
            '        dtComps.Rows(k)("Total") = total
            '        total = 0
            '    Next
            'Next

            'For p As Integer = 0 To dtComps.Rows.Count - 1
            '    For q As Integer = 0 To dtComps.Columns.Count - 1
            '        If dtComps.Rows(p)(q).ToString() = "" Then
            '            dtComps.Rows(p)(q) = 0
            '        End If
            '    Next
            'Next


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
            'Dim type As String
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Month", "", Me.DropMonth.SelectedValue)
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
            Dim otask As cTasks = New cTasks(Session("ConnString"))
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
            otask.setAppVars(Session("UserCode"), "DashboardProject", "Level", "", Me.DropLevel.SelectedValue)
            'Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
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

    Private Sub CheckBoxExport_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExport.CheckedChanged
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.Title = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
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
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Select Case e.Item.Value
                Case "Month"
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
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
                    otask.setAppVars(Session("UserCode"), "DashboardProject", "Range", "", e.Item.Value)
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
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                Case "Completed"
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
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                Case "Due"
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
                    Me.RadToolbarNav.Items(4).Enabled = True
                    Me.RadToolbarNav.Items(6).Enabled = True
                    Me.RadToolbarNav.Items(8).Enabled = True
                    Me.RadToolbarDashProject.Items(1).Enabled = True
                    Me.RadToolbarDashProject.Items(3).Enabled = True
                    Me.RadToolbarDashProject.Items(5).Enabled = True
                    Me.RadToolbarDashProject.Items(7).Enabled = True
                Case "Pending"
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
                    Me.RadToolbarNav.Items(4).Enabled = False
                    Me.RadToolbarNav.Items(6).Enabled = False
                    Me.RadToolbarNav.Items(8).Enabled = False
                    Me.RadToolbarDashProject.Items(1).Enabled = False
                    Me.RadToolbarDashProject.Items(3).Enabled = False
                    Me.RadToolbarDashProject.Items(5).Enabled = False
                    Me.RadToolbarDashProject.Items(7).Enabled = False
                Case "Cancelled"
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
                    If iscancel = False Then
                        Me.RadToolbarNav.Items(4).Enabled = False
                        Me.RadToolbarNav.Items(6).Enabled = False
                        Me.RadToolbarNav.Items(8).Enabled = False
                        Me.RadToolbarDashProject.Items(1).Enabled = False
                        Me.RadToolbarDashProject.Items(3).Enabled = False
                        Me.RadToolbarDashProject.Items(5).Enabled = False
                        Me.RadToolbarDashProject.Items(7).Enabled = False
                    Else
                        Me.RadToolbarNav.Items(4).Enabled = True
                        Me.RadToolbarNav.Items(6).Enabled = True
                        Me.RadToolbarNav.Items(8).Enabled = True
                        Me.RadToolbarDashProject.Items(1).Enabled = True
                        Me.RadToolbarDashProject.Items(3).Enabled = True
                        Me.RadToolbarDashProject.Items(5).Enabled = True
                        Me.RadToolbarDashProject.Items(7).Enabled = True
                    End If
                    If iscancel = False Then
                        Me.Title = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                    Else
                        Me.Title = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
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
                        .Page = "DashboardProjectDetail.aspx"
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

    Private Sub RadGridComps_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridComps.SortCommand
        Try
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
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

#End Region



















End Class
