Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardRealizationEmployee
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
    Public yearValue As String = ""

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            If Not Me.IsPostBack Then
                Dim oSec As New cSecurity(Session("ConnString"))
                Dim UserHasAccessToEUProductivity As Boolean = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1)
                Dim UserHasAccessToEURealization As Boolean = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1)

                If UserHasAccessToEUProductivity = False And UserHasAccessToEURealization = False Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf UserHasAccessToEUProductivity = True And UserHasAccessToEURealization = False Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf UserHasAccessToEUProductivity = False And UserHasAccessToEURealization = True Then
                    Me.RadToolbarDash.Items(3).Enabled = False
                End If

            End If
            If Request.QueryString("client") <> "" Then
                client = Request.QueryString("client")
            End If
            If Request.QueryString("division") <> "" Then
                division = Request.QueryString("division")
            End If
            If Request.QueryString("product") <> "" Then
                product = Request.QueryString("product")
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
            'LoadData()
            'LoadGrid()
            If Me.OfficeCode = "" Then
                Me.Title = "Realization for All Offices\"
            Else
                Me.Title = "Realization for " & Request.QueryString("OName") & "\"
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
            Dim empname As String = Request.QueryString("EmpName")
            Dim officename As String = Request.QueryString("OName")
            Dim deptname As String = Request.QueryString("DName")
            Dim period As Integer
            Dim dash As String
            Dim clname As String
            Dim value As Integer = 0
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim dept As Boolean = False
            Dim btnExport As RadToolBarButton

            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value = "Export" Then
                    btnExport = rtb
                End If
            Next

            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If

            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        yearValue = value
                    End If
                    value += 1
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

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridRealization.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    clname = gridDataItem.GetDataKeyValue("CL_NAME")
                End If
            Next

            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value = "Dept" Then
                    If rtb.Checked = True Then
                        dept = True
                    End If
                End If
            Next

            btnExport.Attributes.Add("onclick", "window.open('DashboardPrint.aspx?From=dashrealemp&export=1&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&yValue=" & yearValue & "&monthCount=" & count & "&month2=" & month2 & "&groupdept=" & dept & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    Private Sub RadGridRealization_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridRealization.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                Case GridItemType.GroupFooter
                    Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        Dim BillableAmt As Decimal = CDec(GrpFtr("column6").Text)
                        Dim MarkUpDownAmt As Decimal = CDec(GrpFtr("column15").Text)
                        Dim BilledHours As Decimal = CDec(GrpFtr("column11").Text)
                        Dim Total As Decimal = CDec(GrpFtr("column9").Text)
                        'Dim agency As Decimal = CDec(GrpFtr("column8").Text)
                        Dim BilledAmount As Decimal = CDec(GrpFtr("column12").Text)
                        Dim DirectHoursGoal As Decimal = CDec(GrpFtr("column3").Text)
                        Dim BillableHoursGoal As Decimal = CDec(GrpFtr("column4").Text)

                        'Percent Write Up/Down
                        If BillableAmt > 0 Then
                            GrpFtr("column16").Text = String.Format("{0:#,##0.00}%", ((MarkUpDownAmt / BillableAmt) * 100))
                        Else
                            GrpFtr("column16").Text = "0.00%"
                        End If

                        'Percent Billed
                        If Total > 0 Then
                            GrpFtr("column17").Text = String.Format("{0:#,##0.00}%", ((BilledHours / Total) * 100))
                        Else
                            GrpFtr("column17").Text = "0.00%"
                        End If

                        'Percent Billed of Direct Hours Goal
                        If DirectHoursGoal > 0 Then
                            GrpFtr("column18").Text = String.Format("{0:#,##0.00}%", ((BilledHours / DirectHoursGoal) * 100))
                        Else
                            GrpFtr("column18").Text = "0.00%"
                        End If

                        'Percent Billed of Billable Hours Goal
                        If BillableHoursGoal > 0 Then
                            GrpFtr("column19").Text = String.Format("{0:#,##0.00}%", ((BilledHours / BillableHoursGoal) * 100))
                        Else
                            GrpFtr("column19").Text = "0.00%"
                        End If

                        'Average Hourly Rate Billed
                        If BilledHours > 0 Then
                            GrpFtr("column20").Text = String.Format("{0:#,##0.00}", ((BilledAmount / BilledHours)))
                        Else
                            GrpFtr("column20").Text = "0.00"
                        End If

                        'Average Hourly Rate Achieved
                        If Total > 0 Then
                            GrpFtr("column21").Text = String.Format("{0:#,##0.00}", ((BilledAmount / Total)))
                        Else
                            GrpFtr("column21").Text = "0.00"
                        End If


                    End If

                Case GridItemType.Footer
                    Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        Dim BillableAmt As Decimal = CDec(GrpFtr("column6").Text)
                        Dim MarkUpDownAmt As Decimal = CDec(GrpFtr("column15").Text)
                        Dim BilledHours As Decimal = CDec(GrpFtr("column11").Text)
                        Dim Total As Decimal = CDec(GrpFtr("column9").Text)
                        'Dim agency As Decimal = CDec(GrpFtr("column8").Text)
                        Dim BilledAmount As Decimal = CDec(GrpFtr("column12").Text)
                        Dim DirectHoursGoal As Decimal = CDec(GrpFtr("column3").Text)
                        Dim BillableHoursGoal As Decimal = CDec(GrpFtr("column4").Text)

                        'Percent Write Up/Down
                        If BillableAmt > 0 Then
                            GrpFtr("column16").Text = String.Format("{0:#,##0.00}%", ((MarkUpDownAmt / BillableAmt) * 100))
                        Else
                            GrpFtr("column16").Text = "0.00%"
                        End If

                        'Percent Billed
                        If Total > 0 Then
                            GrpFtr("column17").Text = String.Format("{0:#,##0.00}%", ((BilledHours / Total) * 100))
                        Else
                            GrpFtr("column17").Text = "0.00%"
                        End If

                        'Percent Billed of Direct Hours Goal
                        If DirectHoursGoal > 0 Then
                            GrpFtr("column18").Text = String.Format("{0:#,##0.00}%", ((BilledHours / DirectHoursGoal) * 100))
                        Else
                            GrpFtr("column18").Text = "0.00%"
                        End If

                        'Percent Billed of Billable Hours Goal
                        If BillableHoursGoal > 0 Then
                            GrpFtr("column19").Text = String.Format("{0:#,##0.00}%", ((BilledHours / BillableHoursGoal) * 100))
                        Else
                            GrpFtr("column19").Text = "0.00%"
                        End If

                        'Average Hourly Rate Billed
                        If BilledHours > 0 Then
                            GrpFtr("column20").Text = String.Format("{0:#,##0.00}", ((BilledAmount / BilledHours)))
                        Else
                            GrpFtr("column20").Text = "0.00"
                        End If

                        'Average Hourly Rate Achieved
                        If Total > 0 Then
                            GrpFtr("column21").Text = String.Format("{0:#,##0.00}", ((BilledAmount / Total)))
                        Else
                            GrpFtr("column21").Text = "0.00"
                        End If


                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridRealization_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridRealization.NeedDataSource
        Try
            Dim value As Integer = 0
            Dim dept As Boolean = False
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        yearValue = value
                    End If
                    value += 1
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
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value = "Dept" Then
                    If rtb.Checked = True Then
                        dept = True
                    End If
                End If
            Next

            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            If dept = True Then
                GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("DP_TM_DESC Department Group By DP_TM_DESC")
                'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                'GrpExpr.GroupByFields.Add(GrpByField)
                With Me.RadGridRealization
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                    .MasterTableView.ShowGroupFooter = True
                    .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                    '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                End With
            Else
                Me.RadGridRealization.MasterTableView.GroupByExpressions.Clear()
            End If
            Me.RadGridRealization.DataSource = dash.GetRealizationData(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Me.yearValue, include, Session("UserCode"), month2, count)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridJobTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobTime.NeedDataSource
    '    Try
    '        Dim ds As DataSet
    '        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
    '        For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu2.Items
    '            If MenuItem.Selected = True Then
    '                year = MenuItem.Text
    '            End If
    '        Next
    '        For Each MenuItem As Telerik.Web.UI.RadMenuItem In Me.radMenu1.Items
    '            If MenuItem.Selected = True Then
    '                month = MenuItem.Value
    '            End If
    '        Next
    '        ds = dash.GetJobTimeByEmp(month, year, client, division, product, 0, 0, "", "")
    '        Me.RadGridJobTime.DataSource = ds.Tables(0)
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
            btn.Value = "Separator1"
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonExportExcel"
            btn.Value = "Export"
            btn.Group = "Export"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = False
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.IsSeparator = True
            btn.Value = "Separator2"
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.Text = "Group by Dept"
            btn.Value = "Dept"
            btn.Group = "Dept"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDash_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDash.ButtonClick
        Try
            Dim value As Integer = 0
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            Dim dept As Boolean = False
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim rb As RadToolBarButton
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        yearValue = value
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", year)
                    End If
                    value += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Text <> "Export" Then
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
                    Exit Sub
                Case "Summary"
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Detail"
                    MiscFN.ResponseRedirect("DashboardRealizationDetail.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Client"
                    MiscFN.ResponseRedirect("DashboardRealizationClient.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Employee"
                    MiscFN.ResponseRedirect("DashboardRealizationEmployee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Fee"
                    MiscFN.ResponseRedirect("DashboardRealizationFee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                    Exit Sub
                Case "Print"
                    Dim empname As String = Request.QueryString("EmpName")
                    Dim officename As String = Request.QueryString("OName")
                    Dim deptname As String = Request.QueryString("DName")
                    Dim dash As String
                    Dim clname As String
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

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridRealization.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("CLIENT")
                            clname = gridDataItem.GetDataKeyValue("CL_NAME")
                        End If
                    Next

                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                        If rtb.Value = "Dept" Then
                            If rtb.Checked = True Then
                                dept = True
                            End If
                        End If
                    Next

                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashrealemp&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&yValue=" & yearValue & "&monthCount=" & count & "&month2=" & month2 & "&groupdept=" & dept)
                Case Else
                    Dim y As String
                    Dim m As String
                    count = 0
                    Dim countyear As Integer = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
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
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
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
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
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
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
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
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Export"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Print"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Dept"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Separator1"))
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Separator2"))
                            loadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" And rtb.Value <> "Export" Then
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
                        Me.RadGridRealization.Rebind()
                    Else
                        Me.RadGridRealization.Rebind()
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "



#End Region




End Class
