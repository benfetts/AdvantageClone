Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal.InfoSoftGlobal



Partial Public Class DashboardRealizationFee
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
                    Server.Transfer("NoAccess.aspx")
                ElseIf Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationProductivityDQ, False) = 0 And Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_DashboardQueries_EmployeeUtilizationRealizationDQ, False) = 1 Then
                    Me.RadToolbarDash.Items(3).Enabled = False
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
            LoadData()
            'updateChart()
            'LoadGrid()
            Me.RadGridFeePrd.Visible = False
            If Me.OfficeCode = "" Then
                Me.Title = "Realization Fee for All Offices\"
            Else
                Me.Title = "Realization Fee for " & Request.QueryString("OName") & "\"
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
            Dim grid As String = ""
            Dim count As Integer = 0
            Dim max As Integer = 0

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

            If Me.cbShowProducts.Checked = True Then
                grid = "product"
            End If

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridFee.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    clname = gridDataItem.GetDataKeyValue("CL_NAME")
                End If
            Next
            Me.butExport.Attributes.Add("onclick", "window.open('DashboardPrint.aspx?From=dashrealfee&export=1&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&grid=" & grid & "&monthCount=" & count & "&month2=" & month2 & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RefreshGrid()
        Me.Session("_ds") = Nothing
    End Sub

    Private Sub RadGridFee_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridFee.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(0).Text
                Dim str2 As String = e.Item.Cells(2).Text
                Dim str3 As String = e.Item.Cells(3).Text
                Dim str4 As String = e.Item.Cells(4).Text 'fee amount
                Dim str5 As String = e.Item.Cells(5).Text


                'If e.Item.Cells(4).Text <> "" And e.Item.Cells(4).Text <> "&nbsp;" Then
                '    e.Item.Cells(6).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(4).Text) - CDec(e.Item.Cells(5).Text))
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFee_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridFee.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
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
            'If IsNumeric(Request.QueryString("billed")) = True Then
            '    period = CInt(Request.QueryString("billed"))
            'End If
            Me.RadGridFee.DataSource = dash.GetFeeDataByClient(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, "", Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridFee.SelectedIndexChanged
        Try
            Dim clname As String
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridFee.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    clname = gridDataItem.GetDataKeyValue("CL_NAME")
                    'division = gridDataItem.GetDataKeyValue("DIVISION")
                    'product = gridDataItem.GetDataKeyValue("PRODUCT")
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                    If rtb.Checked = True Then
                        month = rtb.Value
                    End If
                End If
            Next
            LoadData()
            Me.lblClient.Text = "Fee Amounts for " & clname
            'updateChart()
            'MiscFN.ResponseRedirect("DashboardRealizationJob.aspx?client=" & client & "&division=" & division & "&product=" & product & "&month=" & month & "&year=" & year)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFeePrd_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridFeePrd.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(0).Text
                Dim str2 As String = e.Item.Cells(2).Text
                Dim str3 As String = e.Item.Cells(3).Text
                Dim str4 As String = e.Item.Cells(4).Text 'fee amount
                Dim str5 As String = e.Item.Cells(5).Text


                'If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
                '    e.Item.Cells(10).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(8).Text) - CDec(e.Item.Cells(9).Text))
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFeePrd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridFeePrd.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
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
            Me.RadGridFeePrd.DataSource = dash.GetFeeDataByProduct(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, "", "", "", Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFeePrd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridFeePrd.SelectedIndexChanged
        Try
            'Dim client As String
            'Dim division As String
            'Dim product As String
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridFeePrd.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("CLIENT")
                    division = gridDataItem.GetDataKeyValue("DIVISION")
                    product = gridDataItem.GetDataKeyValue("PRODUCT")
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
            LoadData()
            MiscFN.ResponseRedirect("DashboardRealizationJob.aspx?EmpCode=" & Me.EmpCode & "&client=" & client & "&division=" & division & "&product=" & product & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&EmpName=" & Request.QueryString("EmpName") & "&billed=" & Request.QueryString("billed") & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)

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
            btn.Value = "Separator"
            Me.RadToolbarDash.Items.Add(btn)
            btn = New RadToolBarButton()
            btn.SkinID = "RadToolBarButtonPrint"
            btn.Value = "Print"
            btn.Group = "Print"
            btn.AllowSelfUnCheck = True
            btn.CheckOnClick = True
            Me.RadToolbarDash.Items.Add(btn)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarDash_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDash.ButtonClick
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim rb As RadToolBarButton
            Dim count As Integer = 0
            Dim max As Integer = 0
            Dim min As Integer = 0
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Group = "Year" Then
                    If rtb.Checked = True Then
                        year = rtb.Value
                        otask.setAppVars(Session("UserCode"), "DashboardEmp", "Year", "", year)
                    End If
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                Case "Summary"
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Detail"
                    MiscFN.ResponseRedirect("DashboardRealizationDetail.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Client"
                    MiscFN.ResponseRedirect("DashboardRealizationClient.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Employee"
                    MiscFN.ResponseRedirect("DashboardRealizationEmployee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Fee"
                    MiscFN.ResponseRedirect("DashboardRealizationFee.aspx?EmpCode=" & Me.EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Productivity"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Productivity")
                    MiscFN.ResponseRedirect("DashboardProduction.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Realization"
                    otask.setAppVars(Session("UserCode"), "DashboardEmp", "Dash", "", "Realization")
                    MiscFN.ResponseRedirect("DashboardRealization.aspx?EmpCode=" & EmpCode & "&EmpName=" & Request.QueryString("EmpName") & "&month=" & min & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & Request.QueryString("OName") & "&DName=" & Request.QueryString("DName") & "&month2=" & max)
                Case "Print"
                    Dim empname As String = Request.QueryString("EmpName")
                    Dim officename As String = Request.QueryString("OName")
                    Dim deptname As String = Request.QueryString("DName")
                    Dim period As Integer
                    Dim dash As String
                    Dim clname As String
                    Dim grid As String = ""
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

                    If Me.cbShowProducts.Checked = True Then
                        grid = "product"
                    End If

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridFee.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("CLIENT")
                            clname = gridDataItem.GetDataKeyValue("CL_NAME")
                        End If
                    Next

                    LoadLinearGauge()
                    Me.OpenWindow("Employee Utilization Print", "DashboardPrint.aspx?From=dashrealfee&EmpCode=" & EmpCode & "&EmpName=" & empname & "&month=" & month & "&year=" & year & "&include=" & include & "&Office=" & Me.OfficeCode & "&Dept=" & Me.DeptCode & "&billed=" & period & "&OName=" & officename & "&DName=" & deptname & "&Data=" & dash & "&client=" & client & "&CName=" & clname & "&grid=" & grid & "&monthCount=" & count & "&month2=" & month2)
                Case Else
                    Dim y As String
                    Dim m As String
                    Dim countyear As Integer = 0
                    count = 0
                    rb = e.Item
                    If e.Item.Text = "All" Then
                        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                                    If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                            If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
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
                            Me.RadToolbarDash.Items.Remove(Me.RadToolbarDash.FindItemByValue("Separator"))
                            loadMenus()
                            loadOtherButtons()
                            If min <> 0 Then
                                If count = 1 Then
                                    For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                        If rtb.Value.Length = 6 And rtb.Text <> "Detail" And rtb.Text <> "Client" Then
                                            If rtb.Value = min Then
                                                rtb.Checked = True
                                            End If
                                        End If
                                    Next
                                ElseIf count > 1 Then
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
                            Else
                                For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
                                    If rtb.Text = "All" Then
                                        rtb.Checked = True
                                    End If
                                Next
                            End If

                        End If
                        LoadData()
                        Me.RadGridFee.Rebind()
                        Me.RadGridFeePrd.Rebind()
                    Else
                        LoadData()
                        Me.RadGridFee.Rebind()
                        Me.RadGridFeePrd.Rebind()
                    End If
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbShowProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowProducts.CheckedChanged
        Try
            If Me.cbShowProducts.Checked = True Then
                Me.RadGridFee.Visible = False
                Me.RadGridFeePrd.Visible = True
            Else
                Me.RadGridFee.Visible = True
                Me.RadGridFeePrd.Visible = False
            End If
            Me.RadGridFee.Rebind()
            Me.RadGridFeePrd.Rebind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "

    Public Function WriteXMLFeeDataByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Bar3D_Totals(Session("ds_DASH_FeeDataByClient"), "", "fee")
    End Function

    Public Function WriteXMLLinear() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_LinearGauge(Session("ds_DASH_FeeDataByClient"), "", "fee")
    End Function

    Public Function WriteXMLAvgHourlyRate() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Bar(Session("ds_DASH_AvgHourlyRateByClient"), "CL_NAME", "AVG_RATE", "", False)
    End Function

    Public Function WriteXMLClientTotals() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarClientTotals(Session("ds_DASH_ClientTotals"), "", "", "", False)
    End Function

    Private Sub LoadData()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        For Each rtb As RadToolBarButton In Me.RadToolbarDash.Items
            If rtb.Group = "Year" Then
                If rtb.Checked = True Then
                    year = rtb.Value
                End If
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

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetFeeDataByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, client, Session("UserCode"), month2)
            Session("ds_DASH_FeeDataByClient") = ds
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

        LoadLinearGauge()

    End Sub

    Private Sub LoadLinearGauge()

        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim LinearGaugeString As String = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        LinearGaugeString = Dashboard.GetLinearGauge(Session("ds_DASH_FeeDataByClient"), "clientTotalsLinearGauge", Nothing)

        If Not [String].IsNullOrWhiteSpace(LinearGaugeString) Then

            Me.AddJavascriptToPage("CreateChart('" & LinearGaugeString & "');")

        End If

    End Sub

    'Private Sub updateChart()
    '    Try
    '        Dim strXML As String
    '        Dim output As String

    '        strXML = WriteXMLClientTotals()

    '        If Not Me.IsPostBack Then
    '            output = FusionCharts.RenderChartHTML("../Flash/Column3D.swf", "", strXML.ToString(), "chart" & Now.Millisecond.ToString(), "400", "350", False)
    '        Else
    '            output = FusionCharts.RenderChart("../Flash/Column3D.swf", "", strXML.ToString(), "chart" & Now.Millisecond.ToString(), "400", "350", False, False)
    '        End If

    '        Me.lit.Text = output

    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

End Class

Namespace FC.LinearGauge


End Namespace

