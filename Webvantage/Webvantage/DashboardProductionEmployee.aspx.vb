Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class DashboardProductionEmployee
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
    Public include As Integer = 0
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
                If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 1 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 0 Then
                    Me.RadToolbarDashEmp.Items(3).Enabled = False
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                    Server.Transfer("NoAccess.aspx")
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
                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                    If rtb.Group = "Year" Then
                        If rtb.Value = Request.QueryString("year") Then
                            rtb.Checked = True
                        End If
                    End If
                Next
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                    If rtb.Group = "Year" Then
                        rtb.Checked = True
                        Exit For
                    End If
                Next
            End If
            loadMenus()
            If Request.QueryString("month") <> "" Then
                If Request.QueryString("month2") = "0" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value = Request.QueryString("month") Then
                                rtb.Checked = True
                            End If
                        End If
                    Next
                Else
                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                        If rtb.Value.Length = 6 Then
                            If rtb.Value >= Request.QueryString("month") And rtb.Value <= Request.QueryString("month2") Then
                                rtb.Checked = True
                            Else
                                rtb.Checked = False
                            End If
                        End If
                    Next
                End If
            Else
                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                    If rtb.Text = "All" Then
                        rtb.Checked = True
                    End If
                Next
            End If
            loadOtherButtons()
            If Me.OfficeCode = "" Then
                Me.Title = "Productivity Employee for All Offices\"
            Else
                Me.Title = "Productivity Employee for " & Request.QueryString("OName") & "\"
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
            Dim value As Integer = 0
            Dim dept As Boolean = False
            Dim btnExport As RadToolBarButton

            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Value = "Export" Then
                    btnExport = rtb
                End If
            Next

            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        yearValue = value
                    End If
                    value += 1
                End If
            Next
            Dim count As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Value = "Dept" Then
                    If rtb.Checked = True Then
                        dept = True
                    End If
                End If
            Next
            btnExport.Attributes.Add("onclick", "window.open('DashboardPrint.aspx?From=dashprodemp&export=1&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&yValue=" & yearValue & "&month2=" & month2 & "&groupDept=" & dept & "&monthcount=" & count & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    Private Sub RadGridProductivity_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProductivity.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                Case GridItemType.GroupFooter
                    Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        Dim stdhrs As Decimal = CDec(GrpFtr("column3").Text)
                        Dim bill As Decimal = CDec(GrpFtr("column5").Text)
                        Dim nonbill As Decimal = CDec(GrpFtr("column6").Text)
                        Dim nonprod As Decimal = CDec(GrpFtr("column9").Text)
                        Dim agency As Decimal = CDec(GrpFtr("column8").Text)
                        Dim newbusiness As Decimal = CDec(GrpFtr("column18").Text)
                        Dim goal As Decimal = CDec(GrpFtr("column4").Text)
                        Dim directgoal As Decimal = CDec(GrpFtr("column34").Text)

                        Dim total As Decimal = bill + nonbill + nonprod + agency + newbusiness
                        Dim direct As Decimal = bill + nonbill + agency + newbusiness

                        'Variance
                        GrpFtr("column12").Text = String.Format("{0:#,##0.00}", (stdhrs - (bill + nonbill + nonprod + agency + newbusiness)))

                        'Direct Percent, NonDirect Percent
                        If total > 0 Then
                            GrpFtr("column13").Text = String.Format("{0:#,##0.00}%", (direct / total) * 100)
                            GrpFtr("column14").Text = String.Format("{0:#,##0.00}%", (nonprod / total) * 100)
                        End If
                        'Billable Percent
                        If goal > 0 Then
                            GrpFtr("column15").Text = String.Format("{0:#,##0.00}%", (bill / goal) * 100)
                        End If
                        'Std Hours Percent
                        If stdhrs > 0 Then
                            GrpFtr("column16").Text = String.Format("{0:#,##0.00}%", (total / stdhrs) * 100)
                        End If
                        'Direct Hours Goal Percent
                        If stdhrs > 0 Then
                            GrpFtr("column17").Text = String.Format("{0:#,##0.00}%", (direct / directgoal) * 100)
                        End If
                    End If

                Case GridItemType.Footer
                    Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                    GrpFtr = e.Item

                    If Not GrpFtr Is Nothing Then

                        Dim stdhrs As Decimal = CDec(GrpFtr("column3").Text)
                        Dim bill As Decimal = CDec(GrpFtr("column5").Text)
                        Dim nonbill As Decimal = CDec(GrpFtr("column6").Text)
                        Dim nonprod As Decimal = CDec(GrpFtr("column9").Text)
                        Dim agency As Decimal = CDec(GrpFtr("column8").Text)
                        Dim newbusiness As Decimal = CDec(GrpFtr("column18").Text)
                        Dim goal As Decimal = CDec(GrpFtr("column4").Text)
                        Dim directgoal As Decimal = CDec(GrpFtr("column34").Text)

                        Dim total As Decimal = bill + nonbill + nonprod + agency + newbusiness
                        Dim direct As Decimal = bill + nonbill + agency + newbusiness

                        'Variance
                        GrpFtr("column12").Text = String.Format("{0:#,##0.00}", (stdhrs - (bill + nonbill + nonprod + agency + newbusiness)))

                        'Direct Percent, NonDirect Percent
                        If total > 0 Then
                            GrpFtr("column13").Text = String.Format("{0:#,##0.00}%", (direct / total) * 100)
                            GrpFtr("column14").Text = String.Format("{0:#,##0.00}%", (nonprod / total) * 100)
                        End If
                        'Billable Percent
                        If goal > 0 Then
                            GrpFtr("column15").Text = String.Format("{0:#,##0.00}%", (bill / goal) * 100)
                        End If
                        'Std Hours Percent
                        If stdhrs > 0 Then
                            GrpFtr("column16").Text = String.Format("{0:#,##0.00}%", (total / stdhrs) * 100)
                        End If
                        'Direct Hours Goal Percent
                        If stdhrs > 0 Then
                            GrpFtr("column17").Text = String.Format("{0:#,##0.00}%", (direct / directgoal) * 100)
                        End If


                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridProductivity_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProductivity.NeedDataSource
        Try
            Dim value As Integer = 1
            Dim count As Integer = 0
            Dim dept As Boolean = False
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        yearValue = value
                    End If
                    value += 1
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
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
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
                With Me.RadGridProductivity
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                    .MasterTableView.ShowGroupFooter = True
                    .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                    '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                End With
            Else
                Me.RadGridProductivity.MasterTableView.GroupByExpressions.Clear()
            End If

            

            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            Me.RadGridProductivity.DataSource = dash.GetProductivityData(Me.EmpCode, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, Me.yearValue, include, month2, count)
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
                            Me.RadToolbarDashEmp.Items.Add(btn)
                        End If
                    End If
                    If dt.Rows(i)("FIELD_NAME").ToString = "YEAR_2" Then
                        If IsDBNull(dt.Rows(i)("FIELD_DESCRIPTION")) = False AndAlso dt.Rows(i)("FIELD_DESCRIPTION").ToString <> "" Then
                            btn = New RadToolBarButton(dt.Rows(i)("FIELD_DESCRIPTION"))
                            btn.Value = ds.Tables(0).Rows(i)("Year")
                            btn.Group = "Year"
                            btn.AllowSelfUnCheck = False
                            btn.CheckOnClick = True
                            Me.RadToolbarDashEmp.Items.Add(btn)
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
                        Me.RadToolbarDashEmp.Items.Add(btn)
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
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
                    Me.RadToolbarDashEmp.Items.Add(btn)
                Next
            End If
            btn = New RadToolBarButton("All")
            btn.Value = ""
            btn.Group = "All"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDashEmp.Items.Add(btn)

            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
            Me.RadToolbarDashEmp.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = False
            Me.RadToolbarDashEmp.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonExportExcel"
            btn.Value = "Export"
            btn.Group = "Export"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = False
            Me.RadToolbarDashEmp.Items.Add(btn)

            btn = New RadToolBarButton()
            btn.IsSeparator = True
            btn.Value = "Separator2"
            Me.RadToolbarDashEmp.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.Text = "Group by Dept"
            btn.Value = "Dept"
            btn.Group = "Dept"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDashEmp.Items.Add(btn)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDashEmp_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDashEmp.ButtonClick
        Try
            Dim rb As RadToolBarButton
            Dim value As Integer = 0
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            Dim dept As Boolean = False
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", year)
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
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
            Select Case e.Item.Value
                Case "Selection"
                    MiscFN.ResponseRedirect("Dashboard.aspx?month=" & min & "&year=" & year & "&include=" & include & "&month2=" & max)
                Case "Summary"
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Detail"
                    MiscFN.ResponseRedirect("DashboardProductionDetail.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Employee"
                    MiscFN.ResponseRedirect("DashboardProductionEmployee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Print"
                    Dim empname As String = Request.QueryString("EmpName")
                    Dim officename As String = Request.QueryString("OName")
                    Dim deptname As String = Request.QueryString("DName")
                    Dim period As Integer
                    Dim dash As String
                    count = 0

                    If IsNumeric(Request.QueryString("include")) = True Then
                        include = CInt(Request.QueryString("include"))
                    End If

                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                        If rtb.Group = "Year" Then
                            If rtb.Checked = True Then
                                year = rtb.Value
                                yearValue = value
                            End If
                            value += 1
                        End If
                    Next

                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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

                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                        If rtb.Value = "Dept" Then
                            If rtb.Checked = True Then
                                dept = True
                            End If
                        End If
                    Next

                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashprodemp&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&yValue=" & yearValue & "&monthCount=" & count & "&month2=" & month2 & "&groupdept=" & dept)
                    'Case "Export"
                    '    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashprodemp&export=1&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash)
                Case Else
                    Dim y As String
                    Dim m As String
                    Dim countyear As Integer = 0
                    count = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
                                If rtb.Checked = True Then
                                    rtb.Checked = False
                                End If
                            End If
                        Next
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Min", "", "")
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Max", "", "")
                    End If
                    If e.Item.Value.Length = 6 Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
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
                            For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
                                        If CInt(rtb.Value) >= min And CInt(rtb.Value) < max Then
                                            rtb.Checked = True
                                        Else
                                            rtb.Checked = False
                                        End If
                                    End If
                                Next
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
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
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
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
                        For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
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
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("1"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("2"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("3"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("4"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("5"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("6"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("7"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("8"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("9"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("10"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("11"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindButtonByCommandName("12"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByText("All"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByValue("Export"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByValue("Print"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByValue("Dept"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByValue("Separator1"))
                            Me.RadToolbarDashEmp.Items.Remove(Me.RadToolbarDashEmp.FindItemByValue("Separator2"))
                            loadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Value <> "Export" Then
                                            If CInt(rtb.Value) >= min And CInt(rtb.Value) <= max Then
                                                rtb.Checked = True
                                            Else
                                                rtb.Checked = False
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDashEmp.Items
                                    If rtb.Text = "All" Then
                                        rtb.Checked = True
                                    End If
                                Next
                            End If

                        End If
                        Me.RadGridProductivity.Rebind()
                    Else
                        Me.RadGridProductivity.Rebind()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarPie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Public Function WriteXMLDirectHoursByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectHoursByClient"), "CL_NAME", "BILLABLE", "", True)
    End Function

    Public Function WriteXMLAgency() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarPie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Public Function WriteXMLNewBusiness() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarPie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Private Sub LoadData()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            'ds = dash.GetNonDirectHours(EmpCode)
            'Session("ds_DASH_NonDirect") = ds
            'ds = dash.GetDirectHoursByClient(EmpCode)
            'Session("ds_DASH_DirectHoursByClient") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region




End Class
