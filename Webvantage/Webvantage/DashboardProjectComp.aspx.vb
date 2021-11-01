Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProjectComp
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
            Me.CheckBoxPrintAll = Me.RadToolbarPE.Items(7).FindControl("CheckBoxPrintAll")
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
            If q.GetValue("project") = "Pending" Or (q.GetValue("project") = "Cancelled" And iscancel = False) Then
                Me.RadToolbarNav.Items(4).Enabled = False
                Me.RadToolbarNav.Items(6).Enabled = False
                Me.RadToolbarNav.Items(8).Enabled = False
                Me.RadToolbarDashProject.Items(1).Enabled = False
                Me.RadToolbarDashProject.Items(3).Enabled = False
                Me.RadToolbarDashProject.Items(5).Enabled = False
                Me.RadToolbarDashProject.Items(7).Enabled = False
            End If
            LoadData(type)

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
            If iscancel = False Then
                Me.RadToolbarProject.Items(9).Text = "Projects in Status"
            End If
            If q.GetValue("project") = "Cancelled" Then
                If iscancel = False Then
                    Me.LabelByLevel.Text = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.LabelByLevel.Text = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.LabelByLevel.Text = "Projects " & q.GetValue("project") & " By " & Me.DropLevel.SelectedItem.Text
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
            Dim printall As Integer = 0
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
            If Me.CheckBoxPrintAll.Checked = True Then
                printall = 1
            End If

            For Each rtb As RadToolBarButton In Me.RadToolbarPE.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojcomp&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "&printall=" & printall & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
                If rtb.Value = "Export" Then
                    rtb.Attributes.Add("onclick", "window.open('DashboardProjectPrint.aspx?From=dashprojcomp&export=1&count=" & count & "&range=" & type & "&month=" & Me.DropMonth.SelectedValue & "&year=" & year & "&week=" & Me.DropWeek.SelectedValue & "&project=" & project & "&ln=" & Me.DropLevel.SelectedItem.Text & "&level=" & Me.DropLevel.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RadGridComps_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComps.ItemDataBound
        Try
            Dim countyear As Integer
            For Each rtb As RadToolBarButton In Me.RadToolbarData.Items
                If rtb.Checked = True Then
                    year = rtb.Text
                    countyear += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, countyear)
            Dim total As Integer
            Dim count As Integer
            Dim fourweektotal As Integer
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then


            ElseIf e.Item.ItemType = GridItemType.Footer Then
                e.Item.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                If Me.DropLevel.SelectedValue = "dept" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "SC" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "C" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CD" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(4).Text = total
                End If
                If Me.DropLevel.SelectedValue = "CDP" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(5).Text = total
                End If
                If Me.DropLevel.SelectedValue = "AE" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(3).Text = total
                End If
                If Me.DropLevel.SelectedValue = "JT" Then
                    e.Item.Cells(2).Text = "Totals:"
                    For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If project = "Created" Then
                            total += ds.Tables(0).Rows(j)("Created")
                        End If
                        If project = "Completed" Then
                            total += ds.Tables(0).Rows(j)("Completed")
                        End If
                        If project = "Due" Then
                            total += ds.Tables(0).Rows(j)("Due")
                        End If
                        If project = "Pending" Then
                            total += ds.Tables(0).Rows(j)("Pending")
                        End If
                        If project = "Cancelled" Then
                            total += ds.Tables(0).Rows(j)("Cancelled")
                        End If
                    Next
                    e.Item.Cells(3).Text = total
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

    Private Sub RadGridComps_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridComps.SelectedIndexChanged
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
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CD" Then
                level = "div"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(5).Text
                        divname = gridDataItem.Cells(3).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "CDP" Then
                level = "prd"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                        divcode = gridDataItem.Cells(6).Text
                        divname = gridDataItem.Cells(3).Text
                        prdcode = gridDataItem.Cells(7).Text
                        prdname = gridDataItem.Cells(4).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "dept" Then
                level = "dept"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "SC" Then
                level = "sc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "AE" Then
                level = "acc"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        code = gridDataItem.GetDataKeyValue("CODE") & ","
                        name = gridDataItem.Cells(2).Text
                    End If
                Next
            End If
            If Me.DropLevel.SelectedValue = "JT" Then
                level = "jt"
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridComps.MasterTableView.Items
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

    Private Function buildRGClient()
        Try
            Me.RadGridComps.MasterTableView.Columns.Clear()
            'Me.RadGridComps.MasterTableView.DataKeyNames = New String() {"CODE"}
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "CL_NAME"
            boundColumn.HeaderText = "Client"
            boundColumn.SortExpression = "CL_NAME"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "COMPS"
            boundColumn.HeaderText = "Projects"
            boundColumn.SortExpression = "COMPS"
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "CODE"
            'boundColumn.HeaderText = ""
            'boundColumn.Visible = False
            'boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            'RadGridComps.MasterTableView.Columns.Add(boundColumn)

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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

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
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

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
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("CL_CODE")
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(0).Rows(u)("DIV_CODE")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

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
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DIVCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
            RadGridComps.MasterTableView.Columns.Add(boundColumn)
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "PRDCODE"
            boundColumn.HeaderText = ""
            boundColumn.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            boundColumn.Visible = False
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim clcodecol As DataColumn = New DataColumn("CODE")
            dtComps.Columns.Add(clcodecol)
            Dim clientcol As DataColumn = New DataColumn("CL_NAME")
            dtComps.Columns.Add(clientcol)
            Dim divcodecol As DataColumn = New DataColumn("DIVCODE")
            dtComps.Columns.Add(divcodecol)
            Dim division As DataColumn = New DataColumn("DIV_NAME")
            dtComps.Columns.Add(division)
            Dim prdcodecol As DataColumn = New DataColumn("PRDCODE")
            dtComps.Columns.Add(prdcodecol)
            Dim product As DataColumn = New DataColumn("PRD_DESCRIPTION")
            dtComps.Columns.Add(product)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("CL_CODE")
                newrow.Item("CL_NAME") = ds.Tables(0).Rows(u)("CL_NAME")
                newrow.Item("DIVCODE") = ds.Tables(0).Rows(u)("DIV_CODE")
                newrow.Item("DIV_NAME") = ds.Tables(0).Rows(u)("DIV_NAME")
                newrow.Item("PRDCODE") = ds.Tables(0).Rows(u)("PRD_CODE")
                newrow.Item("PRD_DESCRIPTION") = ds.Tables(0).Rows(u)("PRD_DESCRIPTION")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "DP_TM_DESC"
            boundColumn.HeaderText = "Department"
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dcol As DataColumn = New DataColumn("DP_TM_DESC")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dcol)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("DP_TM_CODE")
                newrow.Item("DP_TM_DESC") = ds.Tables(0).Rows(u)("DP_TM_DESC")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
                dtComps.Rows.Add(newrow)
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "ACCT_NAME"
            boundColumn.HeaderText = "Account Executive"
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dcol As DataColumn = New DataColumn("ACCT_NAME")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dcol)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("ACCT_EXEC")
                newrow.Item("ACCT_NAME") = ds.Tables(0).Rows(u)("ACCT_NAME")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
                dtComps.Rows.Add(newrow)
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "SC_DESCRIPTION"
            boundColumn.HeaderText = "Sales Class"
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dcol As DataColumn = New DataColumn("SC_DESCRIPTION")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dcol)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("SC_CODE")
                newrow.Item("SC_DESCRIPTION") = ds.Tables(0).Rows(u)("SC_DESCRIPTION")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
                dtComps.Rows.Add(newrow)
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            boundColumn.DataField = "JT_DESC"
            boundColumn.HeaderText = "Job Type"
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
            ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, Me.DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), type, project, count)

            Dim deptcol As DataColumn = New DataColumn("CODE")
            Dim dcol As DataColumn = New DataColumn("JT_DESC")
            dtComps.Columns.Add(deptcol)
            dtComps.Columns.Add(dcol)
            dtComps.Columns.Add("COMPS")

            Dim newrow As DataRow
            For u As Integer = 0 To ds.Tables(0).Rows.Count - 1
                newrow = dtComps.NewRow
                newrow.Item("CODE") = ds.Tables(0).Rows(u)("JOB_TYPE")
                newrow.Item("JT_DESC") = ds.Tables(0).Rows(u)("JT_DESC")
                If project = "Created" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Created")
                End If
                If project = "Completed" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Completed")
                End If
                If project = "Due" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Due")
                End If
                If project = "Pending" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Pending")
                End If
                If project = "Cancelled" Then
                    newrow.Item("COMPS") = ds.Tables(0).Rows(u)("Cancelled")
                End If
                dtComps.Rows.Add(newrow)
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
            Me.LoadData(type)
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
            Me.LoadData(type)
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
            Me.LoadData(type)
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.LabelByLevel.Text = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
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
                    LoadData(type)
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
                    LoadData("Month")
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
                    LoadData("YeartoDate")
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
                    LoadData(type)
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
                    Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Completed"
                    LoadData(type)
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
                    Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Due"
                    LoadData(type)
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
                    Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Pending"
                    LoadData(type)
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
                    Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                Case "Cancelled"
                    LoadData(type)
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
                    'Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                    If iscancel = False Then
                        Me.LabelByLevel.Text = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                        Me.RadToolbarNav.Items(4).Enabled = False
                        Me.RadToolbarNav.Items(6).Enabled = False
                        Me.RadToolbarNav.Items(8).Enabled = False
                        Me.RadToolbarDashProject.Items(1).Enabled = False
                        Me.RadToolbarDashProject.Items(3).Enabled = False
                        Me.RadToolbarDashProject.Items(5).Enabled = False
                        Me.RadToolbarDashProject.Items(7).Enabled = False
                    Else
                        Me.LabelByLevel.Text = "Projects " & e.Item.Value & " By " & Me.DropLevel.SelectedItem.Text
                        Me.RadToolbarNav.Items(4).Enabled = True
                        Me.RadToolbarNav.Items(6).Enabled = True
                        Me.RadToolbarNav.Items(8).Enabled = True
                        Me.RadToolbarDashProject.Items(1).Enabled = True
                        Me.RadToolbarDashProject.Items(3).Enabled = True
                        Me.RadToolbarDashProject.Items(5).Enabled = True
                        Me.RadToolbarDashProject.Items(7).Enabled = True
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
            For Each rtb As RadToolBarButton In Me.RadToolbarProject.Items
                If rtb.Checked = True Then
                    project = rtb.Value
                End If
            Next
            Me.LoadData(type)
            If project = "Cancelled" Then
                If iscancel = False Then
                    Me.LabelByLevel.Text = "Projects in Status [" & cancelDesc & "] By " & Me.DropLevel.SelectedItem.Text
                Else
                    Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
                End If
            Else
                Me.LabelByLevel.Text = "Projects " & project & " By " & Me.DropLevel.SelectedItem.Text
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

    Public Function WriteXMLPieSelection() As String
        Dim das As New cDashboard(Session("ConnString"), Session("UserCode"))
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
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "CL_NAME", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "CD" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "DIV_NAME", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "CDP" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "PRD_DESCRIPTION", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "AE" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "ACCT_NAME", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "dept" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "DP_TM_DESC", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "SC" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "SC_DESCRIPTION", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If
        If Me.DropLevel.SelectedValue = "JT" Then
            Return das.getFCXMLData_PieByLevel(Session("ds_DASH_Comps_Pie_ByLevel"), "JT_DESC", project, "", True, Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")
        End If

    End Function

    Private Sub LoadData(Optional ByVal type As String = "Month")

        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable
        Dim dtWeek As DataView
        Dim count As Integer = 0

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

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))

            If type = "Month" Then
                ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "Month", project, count)
            Else
                ds = dash.GetProjectsByLevel("", Me.DropMonth.SelectedValue, year, DropWeek.SelectedValue, OfficeCode, ae, client, DeptCode, sc, jt, 0, 1, Me.DropLevel.SelectedValue, cancel, iscancel, Session("UserCode"), "YeartoDate", project, count)
            End If

            Session("ds_DASH_Comps_Pie_ByLevel") = ds

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        CreateChart()

    End Sub
    Private Sub CreateChart()

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing

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

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Select Case Me.DropLevel.SelectedValue

            Case "C"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "CL_NAME", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "CD"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "DIV_NAME", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "CDP"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "PRD_DESCRIPTION", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "AE"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "ACCT_NAME", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "dept"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "DP_TM_DESC", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "SC"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "SC_DESCRIPTION", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

            Case "JT"

                Dashboard.GetPieChart_ByLevel(RadHtmlChartPieSelection, Session("ds_DASH_Comps_Pie_ByLevel"), "JT_DESC", project, "", Me.DropWeek.SelectedValue, Me.DropMonth.SelectedValue, year, type, Me.DropLevel.SelectedValue, "Projects")

        End Select

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

End Class
