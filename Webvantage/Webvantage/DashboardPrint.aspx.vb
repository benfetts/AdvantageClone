Imports Telerik.Web.UI
Imports InfoSoftGlobal

Public Class DashboardPrint
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

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    ''Protected WithEvents chartCliAging As Infragistics.WebUI.UltraWebChart.UltraChart
    ''Protected WithEvents UltraChart1 As Infragistics.WebUI.UltraWebChart.UltraChart
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Me.AllowFloat = True
    End Sub

#End Region

#Region " Variables and Properties "

    Public OfficeCode As String = ""
    Public DeptCode As String = ""
    Public EmpCode As String = ""
    Public month As String = ""
    Public month2 As String = ""
    Public year As String = ""
    Public dashboard As String = ""
    Public include As Integer = 0
    Public period As Integer = 0
    Public yearValue As String = ""
    Dim client As String = ""
    Dim product As String = ""
    Dim division As String = ""
    Dim job As Integer
    Dim comp As Integer
    Dim dept As Boolean = False
    Dim monthcount As Integer

    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.EmpCode = Request.QueryString("EmpCode")
            Me.OfficeCode = Request.QueryString("Office")
            Me.DeptCode = Request.QueryString("Dept")
            Me.year = Request.QueryString("year")
            Me.yearValue = Request.QueryString("yValue")
            Me.month = Request.QueryString("month")
            Me.month2 = Request.QueryString("month2")
            Me.monthcount = Request.QueryString("monthcount")
            Me.client = Request.QueryString("client")
            Me.division = Request.QueryString("division")
            Me.product = Request.QueryString("product")
            If Request.QueryString("groupDept") <> "" Then
                Me.dept = Request.QueryString("groupDept")
            End If
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                Else
                    'Page.RegisterStartupScript("CloseMe", CloseScript)
                End If
                If Request.QueryString("Data") = "Prod" Then
                    Me.lblTitle.Text = "Productivity Data"
                    LoadGraph()
                End If
                If Request.QueryString("Data") = "Real" Then
                    Me.lblTitle.Text = "Realization Data"
                    LoadGraph()
                End If
                If Request.QueryString("From") = "dashprod" Then
                    Me.lblTitle.Text = "Productivity Summary - Goal vs. Actual"
                    LoadData()
                End If
                If Request.QueryString("From") = "dashproddetail" Then
                    Me.lblTitle.Text = "Productivity Detail"
                    LoadDataProdDetail()
                End If
                If Request.QueryString("From") = "dashreal" Then
                    Me.lblTitle.Text = "Realization Summary"
                    LoadDataReal()
                End If
                If Request.QueryString("From") = "dashrealdetail" Then
                    Me.lblTitle.Text = "Realization Detail"
                    LoadDataRealDetail()
                End If
                If Request.QueryString("From") = "dashrealfee" Then
                    Me.lblTitle.Text = "Realization Fee"
                    LoadDataRealFee()
                End If
                If Request.QueryString("From") = "dashprodemp" Then
                    Me.lblTitle.Text = "Productivity Employee"
                End If
                If Request.QueryString("From") = "dashrealclient" Then
                    Me.lblTitle.Text = "Realization"
                End If
                If Request.QueryString("From") = "dashrealemp" Then
                    Me.lblTitle.Text = "Realization"
                End If
                If Request.QueryString("From") = "dashrealjob" Then
                    Me.lblTitle.Text = "Realization"
                End If
                If Me.OfficeCode = "" Then
                    Me.lblTitle.Text = Me.lblTitle.Text & " for All Offices\"
                Else
                    Me.lblTitle.Text = Me.lblTitle.Text & " for " & Request.QueryString("OName") & "\"
                End If
                If Me.DeptCode = "" Then
                    Me.lblTitle.Text = Me.lblTitle.Text & "All Depts\"
                Else
                    Me.lblTitle.Text = Me.lblTitle.Text & Request.QueryString("DName") & "\"
                End If
                If Me.EmpCode = "" Then
                    Me.lblTitle.Text = Me.lblTitle.Text & "All Employees"
                Else
                    Me.lblTitle.Text = Me.lblTitle.Text & Request.QueryString("EmpName")
                End If
                If Request.QueryString("From") = "dash" Then
                    Me.pnlDash.Visible = True
                    LoadGraph()
                End If
                If Request.QueryString("From") = "dashprod" Then
                    Me.pnlDashProd.Visible = True
                End If
                If Request.QueryString("From") = "dashproddetail" Then
                    Me.pnlDashProdDetail.Visible = True
                End If
                If Request.QueryString("From") = "dashreal" Then
                    Me.pnlDashReal.Visible = True
                End If
                If Request.QueryString("From") = "dashrealdetail" Then
                    Me.pnlDashRealDetail.Visible = True
                    If Request.QueryString("CName") <> "" Then
                        Me.lblClient.Text = lblClient.Text & " for " & Request.QueryString("CName")
                    End If
                    If Request.QueryString("grid") = "product" Then
                        Me.RadGridAvgHourly.Visible = False
                        Me.RadGridAvgHourlyPrd.Visible = True
                    Else
                        Me.RadGridAvgHourlyPrd.Visible = False
                    End If
                End If
                If Request.QueryString("From") = "dashrealfee" Then
                    Me.pnlDashRealFee.Visible = True
                    If Request.QueryString("CName") <> "" Then
                        Me.Label1.Text = Me.Label1.Text & " for " & Request.QueryString("CName")
                    End If
                    If Request.QueryString("grid") = "product" Then
                        Me.RadGridFee.Visible = False
                        Me.RadGridFeePrd.Visible = True
                    Else
                        Me.RadGridFeePrd.Visible = False
                    End If
                End If
                If Request.QueryString("From") = "dashprodemp" Then
                    Me.pnlDashProdEmp.Visible = True
                    Me.Print_Buttons1.Visible = False
                    Me.divPrint.Visible = True
                End If
                If Request.QueryString("From") = "dashrealclient" Then
                    Me.pnlDashRealClient.Visible = True
                    Me.Print_Buttons1.Visible = False
                    Me.divPrint.Visible = True
                    If Request.QueryString("grid") = "product" Then
                        Me.RadGridCl.Visible = False
                        Me.RadGridClientDetail.Visible = True
                    Else
                        Me.RadGridClientDetail.Visible = False
                    End If
                End If
                If Request.QueryString("From") = "dashrealemp" Then
                    Me.pnlDashRealEmp.Visible = True
                    Me.Print_Buttons1.Visible = False
                    Me.divPrint.Visible = True
                End If
                If Request.QueryString("From") = "dashrealjob" Then
                    Me.pnlDashRealJob.Visible = True
                    Me.Print_Buttons1.Visible = False
                    Me.divPrint.Visible = True
                    Me.job = Request.QueryString("job")
                    Me.comp = Request.QueryString("comp")
                End If
                If Request.QueryString("From") = "dashrealjobtime" Then
                    Me.pnlDashRealJobTime.Visible = True
                    Me.Print_Buttons1.Visible = False
                    Me.divPrint.Visible = True
                    Me.job = Request.QueryString("job")
                    Me.comp = Request.QueryString("comp")
                End If
            Else
                'Page.RegisterStartupScript("CloseMe", CloseScript)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

#Region "Dashboard Print"

    Private Sub LoadGraph()
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetOfficeData(Me.OfficeCode, month, year, Session("UserCode"), month2)
            Session("ds_DASH_Offices") = ds
            ds = dash.GetDeptData(Me.OfficeCode, month, year, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_Departments") = ds
            ds = dash.GetEmpData(Me.DeptCode)
            Session("ds_DASH_Employees") = ds

            'FusionCharts.SetRenderer("javascript")
            'Literal1.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLOffice(), "office", "400", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal2.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXML(), "dept", "400", "350", False, True)

            Dim Dashboard As Webvantage.cDashboard = Nothing

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)
            
            Dashboard.GetDirectAndNonDirectColumnChart(RadHtmlChartOffice, Session("ds_DASH_Offices"))
            Dashboard.GetDirectAndNonDirectBarChart(RadHtmlChartDepartmentTeamChart, Session("ds_DASH_Departments"), "", "dept")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Public Function WriteXML() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Departments(Session("ds_DASH_Departments"))
    End Function

    Public Function WriteXMLEmp() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Departments(Session("ds_DASH_Employees"))
    End Function

    Public Function WriteXMLOffice() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Departments(Session("ds_DASH_Offices"))
    End Function

#End Region

#Region "Dashboard Prodution Print"

    Public Function WriteXMLGauge() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_DirectWithTotalGauge"), "", "direct")
    End Function

    Public Function WriteXMLGaugeGoal() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_DirectWithTotalGaugeGoal"), "", "goal")
    End Function

    Public Function WriteXMLGaugeRequired() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_RequiredvsTotalGauge"), "", "required")
    End Function

    Public Function WriteXMLGaugeBillable() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_DirectvsBillableGauge"), "", "billable")
    End Function

    Public Function WriteXMLTotalvsDirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectWithTotal"), "", "direct")
    End Function

    Public Function WriteXMLTotalvsNonDirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_NonDirectWithTotal"), "Total Hours vs. Non Direct Hours", "nondirect")
    End Function

    Public Function WriteXMLDirectvsBillable() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectvsBillable"), "", "bill")
    End Function

    Public Function WriteXMLRequiredvsTotal() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_RequiredvsTotal"), "", "required")
    End Function

    Public Function WriteXMLGoalvsBillable() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_GoalvsBillable"), "", "Goal")
    End Function

    Public Function WriteXMLDirectHoursByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectHoursByClient"), "Direct Hours by Client", "client")
    End Function

    Private Sub LoadData()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        If IsNumeric(Request.QueryString("include")) = True Then
            include = CInt(Request.QueryString("include"))
        End If

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetDirectHoursWithTotal(EmpCode, 0, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, include, yearValue, month2)
            Session("ds_DASH_DirectWithTotal") = ds
            ds = dash.GetDirectHoursWithTotal(EmpCode, 1, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, include, yearValue, month2)
            Session("ds_DASH_DirectWithTotalGauge") = ds
            ds = dash.GetNonDirectHoursWithTotal(EmpCode)
            Session("ds_DASH_NonDirectWithTotal") = ds
            ds = dash.GetDirectHoursWithBillable(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsBillable") = ds
            ds = dash.GetDirectHoursWithBillable(EmpCode, 1, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsBillableGauge") = ds
            ds = dash.GetRequiredHoursWithTotal(EmpCode, 0, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, include, yearValue, month2)
            Session("ds_DASH_RequiredvsTotal") = ds
            ds = dash.GetRequiredHoursWithTotal(EmpCode, 1, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, include, yearValue, month2)
            Session("ds_DASH_RequiredvsTotalGauge") = ds
            ds = dash.GetGoalHoursWithBillable(EmpCode, 0, month, year, include, Me.OfficeCode, Me.DeptCode, Me.yearValue, Session("UserCode"), month2, monthcount)
            Session("ds_DASH_GoalvsBillable") = ds
            ds = dash.GetGoalHoursWithBillable(EmpCode, 1, month, year, include, Me.OfficeCode, Me.DeptCode, Me.yearValue, Session("UserCode"), month2, monthcount)
            Session("ds_DASH_DirectWithTotalGaugeGoal") = ds

            'FusionCharts.SetRenderer("javascript")
            'Literal3.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeRequired(), "Required", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal4.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGauge(), "Gauge", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal5.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeGoal(), "Goal", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal6.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeBillable(), "Billable", "245", "150", False, True)

            'FusionCharts.SetRenderer("javascript")
            'Literal7.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLRequiredvsTotal(), "RequiredBar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal8.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLTotalvsDirect(), "Bar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal9.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLGoalvsBillable(), "GoalBar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal10.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLDirectvsBillable(), "BillableBar", "245", "350", False, True)

            Dim Dashboard As Webvantage.cDashboard = Nothing

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)
            
            Dashboard.GetTotalsColumnChart(RadHtmlChartRequiredHoursVsTotalHoursChart, Session("ds_DASH_RequiredvsTotal"), "", "required")
            Dashboard.GetTotalsColumnChart(RadHtmlChartDirectHoursGoalVsDirectHoursChart, Session("ds_DASH_DirectWithTotal"), "", "direct")
            Dashboard.GetTotalsColumnChart(RadHtmlChartBillableHoursGoalVsBillableHoursChart, Session("ds_DASH_GoalvsBillable"), "", "Goal")
            Dashboard.GetTotalsColumnChart(RadHtmlChartDirectHoursVsBillableHoursChart, Session("ds_DASH_DirectvsBillable"), "", "bill")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region

#Region "Dashboard Production Detail Print"

    Public Function WriteXMLCat() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "", True)
    End Function

    Public Function WriteXMLDirectHoursByClientDetail() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectHoursByClient"), "CL_NAME", "BILLABLE", "", True)
    End Function

    Public Function WriteXMLAgency() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectHoursWithAgency"), "", "agency")
    End Function

    Public Function WriteXMLNewBusiness() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectHoursWithNewBusiness"), "", "newbusiness")
    End Function

    Public Function WriteXMLHours() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_PieDirectHours(Session("ds_DASH_DetailHours"), "", "", "", True)
    End Function

    Public Function WriteXMLDirectvsNondirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Pie(Session("ds_DASH_DirectvsNondirect"), "COL", "HOURS", "", True)
    End Function

    Private Sub LoadDataProdDetail()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetNonDirectHours(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_NonDirect") = ds
            ds = dash.GetBillableHoursByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectHoursByClient") = ds
            ds = dash.GetDirectHoursWithAgency(EmpCode, 0, month, year)
            Session("ds_DASH_DirectHoursWithAgency") = ds
            ds = dash.GetDirectHoursWithNewBusiness(EmpCode, 0, month, year)
            Session("ds_DASH_DirectHoursWithNewBusiness") = ds
            ds = dash.GetDirectWithNonDirect(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsNondirect") = ds
            ds = dash.GetDetailHours(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DetailHours") = ds

            'FusionCharts.SetRenderer("javascript")
            'Literal11.Text = FusionCharts.RenderChart("Flash/Pie3D.swf", "", WriteXMLDirectvsNondirect(), "DirectPie", "400", "350", False, False)
            'FusionCharts.SetRenderer("javascript")
            'Literal12.Text = FusionCharts.RenderChart("Flash/Pie3D.swf", "", WriteXMLHours(), "HoursPie", "400", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal13.Text = FusionCharts.RenderChart("Flash/Pie3D.swf", "", WriteXMLCat(), "CatPie", "400", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal14.Text = FusionCharts.RenderChart("Flash/Pie3D.swf", "", WriteXMLDirectHoursByClientDetail(), "DirectHoursClientPie", "595", "350", False, True)

            Dim Dashboard As Webvantage.cDashboard = Nothing

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)
            
            Dashboard.GetPieChart(RadHtmlChartIndirectHoursVsDirectPieChart, Session("ds_DASH_DirectvsNondirect"), "COL", "HOURS", "")
            Dashboard.GetPieChart_DirectHours(RadHtmlChartDirectHourByTypePieChart, Session("ds_DASH_DetailHours"), "")
            Dashboard.GetPieChart(RadHtmlChartNonDirectHoursByCategoryPieChart, Session("ds_DASH_NonDirect"), "CATEGORY", "NONDIRECT", "")
            Dashboard.GetPieChart(RadHtmlChartDirectHoursByClientPieChart, Session("ds_DASH_DirectHoursByClient"), "CL_NAME", "BILLABLE", "")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region

#Region "Dashboard Production Emp Print"

    Private Sub RadGridProductivity_ExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs) Handles RadGridProductivity.ExportCellFormatting
        Try
            Select Case e.FormattedColumn.UniqueName
                Case "column3"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column34"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column4"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column5"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column6"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column8"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column18"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column7"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column9"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column11"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column12"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridProductivity_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridProductivity.ItemDataBound
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
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
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
            Me.RadGridProductivity.DataSource = dash.GetProductivityData(Me.EmpCode, month, year, Session("UserCode"), Me.OfficeCode, Me.DeptCode, Me.yearValue, include, month2, monthcount)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Dashboard Realization Print"

    Public Function WriteXMLGaugeBilledvsDirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_BilledvsDirectGauge"), "", "directbilled")
    End Function
    Public Function WriteXMLGaugeBilledvsBillable() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_BilledvsBillableGauge"), "", "billedbillable")
    End Function
    Public Function WriteXMLGaugeDirectGoalvsBilled() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_DirectGoalvsBilledGauge"), "", "directgoal")
    End Function
    Public Function WriteXMLGaugeGoalvsStandard() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_GoalvsStandardGauge"), "", "goalstandard")
    End Function
    Public Function WriteXMLGaugeBilledvsGoal() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Gauge(Session("ds_DASH_BilledvsGoalGauge"), "", "billedgoal")
    End Function
    Public Function WriteXMLBilledvsDirect() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_BilledvsDirect"), "", "billed")
    End Function
    Public Function WriteXMLBilledvsBillable() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_BilledvsBillable"), "", "billable")
    End Function
    Public Function WriteXMLGoalvsStandard() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_GoalvsStandard"), "", "standard")
    End Function
    Public Function WriteXMLDirectGoalvsBilled() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_DirectGoalvsBilled"), "", "directgoalbilled")
    End Function
    Public Function WriteXMLBilledvsGoal() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_MultiColumn3D_Totals(Session("ds_DASH_BilledvsGoal"), "", "billedgoal")
    End Function

    Private Sub LoadDataReal()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        If IsNumeric(Request.QueryString("include")) = True Then
            include = CInt(Request.QueryString("include"))
        End If
        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetDirectHoursWithBilled(EmpCode, 1, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_BilledvsDirectGauge") = ds
            ds = dash.GetBilledHoursWithBillable(EmpCode, 1, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_BilledvsBillableGauge") = ds
            'ds = dash.GetBillableHoursGoalWithStandard(EmpCode, 1, month, year, Session("UserCode"), include, Me.OfficeCode, Me.DeptCode, Me.yearValue)
            ds = dash.GetDirectHoursGoalWithBilled(EmpCode, 1, month, year, Session("UserCode"), include, Me.OfficeCode, Me.DeptCode, Me.yearValue, period, month2)
            'Session("ds_DASH_GoalvsStandardGauge") = ds
            Session("ds_DASH_DirectGoalvsBilledGauge") = ds
            ds = dash.GetBilledHoursWithGoal(EmpCode, 1, month, year, include, Me.OfficeCode, Me.DeptCode, period, Me.yearValue, Session("UserCode"), month2, monthcount)
            Session("ds_DASH_BilledvsGoalGauge") = ds
            ds = dash.GetDirectHoursWithBilled(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_BilledvsDirect") = ds
            ds = dash.GetBilledHoursWithBillable(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_BilledvsBillable") = ds
            'ds = dash.GetBillableHoursGoalWithStandard(EmpCode, 0, month, year, Session("UserCode"), include, Me.OfficeCode, Me.DeptCode, Me.yearValue)
            ds = dash.GetDirectHoursGoalWithBilled(EmpCode, 0, month, year, Session("UserCode"), include, Me.OfficeCode, Me.DeptCode, Me.yearValue, period, month2)
            'Session("ds_DASH_GoalvsStandard") = ds
            Session("ds_DASH_DirectGoalvsBilled") = ds
            ds = dash.GetBilledHoursWithGoal(EmpCode, 0, month, year, include, Me.OfficeCode, Me.DeptCode, period, Me.yearValue, Session("UserCode"), month2, monthcount)
            Session("ds_DASH_BilledvsGoal") = ds

            'FusionCharts.SetRenderer("javascript")
            'Literal15.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeDirectGoalvsBilled(), "Required", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal16.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeBilledvsDirect(), "Gauge", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal17.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeBilledvsGoal(), "Goal", "245", "150", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal18.Text = FusionCharts.RenderChart("Flash/AngularGauge.swf", "", WriteXMLGaugeBilledvsBillable(), "Billable", "245", "150", False, True)

            'FusionCharts.SetRenderer("javascript")
            'Literal19.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLDirectGoalvsBilled(), "DirectGoalvsBilledBar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal20.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLBilledvsDirect(), "BilledvsDirectBar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal21.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLBilledvsGoal(), "BilledvsGoalBar", "245", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal22.Text = FusionCharts.RenderChart("Flash/MSColumn3D.swf", "", WriteXMLBilledvsBillable(), "BilledvsBillableBar", "245", "350", False, True)

            Dim Dashboard As Webvantage.cDashboard = Nothing

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetTotalsColumnChart(RadHtmlChartDirectHoursGoalVsBilledHoursChart, Session("ds_DASH_DirectGoalvsBilled"), "", "directgoalbilled")
            Dashboard.GetTotalsColumnChart(RadHtmlChartDirectHoursVsBilledHoursChart, Session("ds_DASH_BilledvsDirect"), "", "billed")
            Dashboard.GetTotalsColumnChart(RadHtmlChartBillableHoursGoalVsBilledHoursChart, Session("ds_DASH_BilledvsGoal"), "", "billedgoal")
            Dashboard.GetTotalsColumnChart(RadHtmlChartBillableHoursVsBilledHoursChart, Session("ds_DASH_BilledvsBillable"), "", "billable")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

#End Region

#Region "Dashboard Realization Detail Print"

    Public Function WriteXMLAvgHourlyRate() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_Bar(Session("ds_DASH_AvgHourlyRateByClient"), "CL_NAME", "AVG_RATE", "", False)
    End Function

    Public Function WriteXMLClientTotals() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_BarClientTotals(Session("ds_DASH_ClientTotals"), "", "", "", False)
    End Function

    Public Function WriteXMLPercentBilledByClient() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_PieRealization(Session("ds_DASH_PercentBilledByClient"), "CL_NAME", "PERCENT_BILLED", "", True, "", month, year, Me.EmpCode, month2)
    End Function

    Private Sub LoadDataRealDetail()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetAvgHourlyRateByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
            Session("ds_DASH_AvgHourlyRateByClient") = ds
            ds = dash.GetDirectWithNonDirect(EmpCode, 0, month, year, Me.OfficeCode, Me.DeptCode, Session("UserCode"), month2)
            Session("ds_DASH_DirectvsNondirect") = ds
            ds = dash.GetPercentBilledByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, Me.period, Session("UserCode"), month2)
            Session("ds_DASH_PercentBilledByClient") = ds
            ds = dash.GetClientTotals(EmpCode, month, year, client, Me.OfficeCode, Me.DeptCode, Me.period, Session("UserCode"), month2)
            Session("ds_DASH_ClientTotals") = ds

            'FusionCharts.SetRenderer("javascript")
            'Literal23.Text = FusionCharts.RenderChart("Flash/Column3D.swf", "", WriteXMLClientTotals(), "ClientTotalsBar", "500", "350", False, True)
            'FusionCharts.SetRenderer("javascript")
            'Literal24.Text = FusionCharts.RenderChart("Flash/Pie3D.swf", "", WriteXMLPercentBilledByClient(), "PercentBilledByClientPie", "600", "350", False, True)

            Dim Dashboard As Webvantage.cDashboard = Nothing

            Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.GetColumnChart_ClientTotals(RadHtmlChartClientTotalsChart, Session("ds_DASH_ClientTotals"), "")
            Dashboard.GetPieChart_Realization(RadHtmlChartPercentBilledByClientPieChart, Session("ds_DASH_PercentBilledByClient"), "CL_NAME", "PERCENT_BILLED", "", month, year, Me.EmpCode, month2)

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Private Sub RadGridAvgHourly_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvgHourly.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridAvgHourly.DataSource = dash.GetAvgHourlyRateByClient(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAvgHourlyPrd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvgHourlyPrd.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridAvgHourlyPrd.DataSource = dash.GetAvgHourlyRateByProduct(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Dashboard Realization Fee Print"

    Public Function WriteXMLLinear() As String
        Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
        Return dash.getFCXMLData_LinearGauge(Session("ds_DASH_FeeDataByClient"), "", "fee")
    End Function

    Private Sub LoadDataRealFee()
        Session("ds_DASH_NonDirect") = ""
        Session("ds_DASH_NonDirect") = Nothing
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        If IsNumeric(Request.QueryString("billed")) = True Then
            period = CInt(Request.QueryString("billed"))
        End If

        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            ds = dash.GetFeeDataByClient(EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, client, Session("UserCode"), month2)
            Session("ds_DASH_FeeDataByClient") = ds

            Dim LinearGaugeString As String = Nothing

            LinearGaugeString = dash.GetLinearGauge(Session("ds_DASH_FeeDataByClient"), "clientTotalsLinearGauge", Nothing)

            If Not [String].IsNullOrWhiteSpace(LinearGaugeString) Then

                Me.AddJavascriptToPage("CreateChart('" & LinearGaugeString & "');")

            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Private Sub RadGridFee_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridFee.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(0).Text
                Dim str2 As String = e.Item.Cells(2).Text
                Dim str3 As String = e.Item.Cells(3).Text
                Dim str4 As String = e.Item.Cells(4).Text 'fee amount
                Dim str5 As String = e.Item.Cells(5).Text


                If e.Item.Cells(4).Text <> "" And e.Item.Cells(4).Text <> "&nbsp;" Then
                    e.Item.Cells(6).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(4).Text) - CDec(e.Item.Cells(5).Text))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFee_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridFee.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridFee.DataSource = dash.GetFeeDataByClient(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, "", Session("UserCode"), month2)
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


                If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
                    e.Item.Cells(10).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(8).Text) - CDec(e.Item.Cells(9).Text))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridFeePrd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridFeePrd.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridFeePrd.DataSource = dash.GetFeeDataByProduct(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, "", "", "", Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Dashboard Realization Client Print"

    Private Sub RadGridClientDetail_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridClientDetail.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridClientDetail.DataSource = dash.GetClientDetail(Me.EmpCode, month, year, client, division, product, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCl_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCl.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridCl.DataSource = dash.GetCliDetail(Me.EmpCode, month, year, client, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Dashboard Realization Employee Print"

    Private Sub RadGridRealization_ExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs) Handles RadGridRealization.ExportCellFormatting
        Try
            Select Case e.FormattedColumn.UniqueName
                Case "column3"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column33"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column4"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column5"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column6"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column8"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column9"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column7"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column18"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column11"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column12"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column13"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
                Case "column14"
                    e.Cell.Style("mso-number-format") = "0\.00"
                    Exit Select
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridRealization_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridRealization.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            If IsNumeric(Request.QueryString("include")) = True Then
                include = CInt(Request.QueryString("include"))
            End If
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
            Me.RadGridRealization.DataSource = dash.GetRealizationData(Me.EmpCode, month, year, Me.OfficeCode, Me.DeptCode, period, Me.yearValue, include, Session("UserCode"), month2, monthcount)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Dashboard Realization Job Print"

    Private Sub RadGridClientTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridClientTime.NeedDataSource
        Try
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            Me.RadGridClientTime.DataSource = dash.GetClientTimeByJob(Me.EmpCode, month, year, client, division, product, 0, 0, Me.OfficeCode, Me.DeptCode, period, Session("UserCode"), month2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobTime_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobTime.NeedDataSource
        Try
            Dim ds As DataSet
            Dim dash As New cDashboard(Session("ConnString"), Session("UserCode"))
            If IsNumeric(Request.QueryString("billed")) = True Then
                period = CInt(Request.QueryString("billed"))
            End If
            If job <> 0 And comp <> 0 Then
                ds = dash.GetJobTimeByEmp(month, year, client, division, product, job, comp, Me.EmpCode, Me.DeptCode, Me.OfficeCode, period, Session("UserCode"), month2)
                Me.RadGridJobTime.DataSource = ds.Tables(1)
            Else
                Me.RadGridJobTime.DataSource = BlankDT()
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                If Request.QueryString("From") = "dashprodemp" Then
                    str = "Production_Emp" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridProductivity, str)
                    RadGridProductivity.MasterTableView.ExportToExcel()
                End If
                If Request.QueryString("From") = "dashrealemp" Then
                    str = "Realization_Emp" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridRealization, str)
                    RadGridRealization.MasterTableView.ExportToExcel()
                End If
                If Request.QueryString("From") = "dashrealclient" Then
                    str = "Realization_Client" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    If Request.QueryString("grid") = "product" Then
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridClientDetail, str)
                        RadGridClientDetail.MasterTableView.ExportToExcel()
                    Else
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridCl, str)
                        RadGridCl.MasterTableView.ExportToExcel()
                    End If
                End If
                If Request.QueryString("From") = "dashrealfee" Then
                    str = "Realization_Fee" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    If Request.QueryString("grid") = "product" Then
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridFeePrd, str)
                        RadGridFeePrd.MasterTableView.ExportToExcel()
                    Else
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridFee, str)
                        RadGridFee.MasterTableView.ExportToExcel()
                    End If
                End If
                If Request.QueryString("From") = "dashrealdetail" Then
                    str = "Realization_Detail" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    If Request.QueryString("grid") = "product" Then
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAvgHourlyPrd, str)
                        RadGridAvgHourlyPrd.MasterTableView.ExportToExcel()
                    Else
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridAvgHourly, str)
                        RadGridAvgHourly.MasterTableView.ExportToExcel()
                    End If
                End If
                If Request.QueryString("From") = "dashrealjob" Then
                    str = "Realization_Job" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridClientTime, str)
                    RadGridClientTime.MasterTableView.ExportToExcel()
                End If
                If Request.QueryString("From") = "dashrealjobtime" Then
                    str = "Realization_Job_Time" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridJobTime, str)
                    RadGridJobTime.MasterTableView.ExportToExcel()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            If Request.QueryString("From") = "dashprodemp" Then
                RadGridProductivity.ExportSettings.ExportOnlyData = True
                RadGridProductivity.ExportSettings.Pdf.PageWidth = 1600
                RadGridProductivity.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                Me.RadGridProductivity.MasterTableView.ExportToPdf()
            End If
            If Request.QueryString("From") = "dashrealemp" Then
                RadGridRealization.ExportSettings.ExportOnlyData = True
                RadGridRealization.ExportSettings.Pdf.PageWidth = 1700
                RadGridRealization.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                Me.RadGridRealization.MasterTableView.ExportToPdf()
            End If
            If Request.QueryString("From") = "dashrealclient" Then
                If Request.QueryString("grid") = "product" Then
                    RadGridClientDetail.ExportSettings.ExportOnlyData = True
                    RadGridClientDetail.ExportSettings.Pdf.PageWidth = 1600
                    RadGridClientDetail.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                    Me.RadGridClientDetail.MasterTableView.ExportToPdf()
                Else
                    RadGridCl.ExportSettings.ExportOnlyData = True
                    RadGridCl.ExportSettings.Pdf.PageWidth = 1600
                    RadGridCl.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                    Me.RadGridCl.MasterTableView.ExportToPdf()
                End If
            End If

            If Request.QueryString("From") = "dashrealjob" Then
                RadGridClientTime.ExportSettings.ExportOnlyData = True
                RadGridClientTime.ExportSettings.Pdf.PageWidth = 1600
                RadGridClientTime.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                Me.RadGridClientTime.MasterTableView.ExportToPdf()
            End If

            If Request.QueryString("From") = "dashrealjobtime" Then
                RadGridJobTime.ExportSettings.ExportOnlyData = True
                RadGridJobTime.ExportSettings.Pdf.PageWidth = 1600
                RadGridJobTime.ExportSettings.Pdf.PaperSize = GridPaperSize.A4
                Me.RadGridJobTime.MasterTableView.ExportToPdf()
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class