Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal
Imports InfoSoftGlobal.InfoSoftGlobal
Public Class TrafficSchedule_Status_Graph
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private export As Integer = 0

#End Region

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

        Me.AllowFloat = True

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me.JobNumber = qs.JobNumber
        Me.JobComponentNbr = qs.JobComponentNumber

        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Dim v As New cValidations(Session("ConnString"))
            If v.ValidateJobCompIsViewable(Session("UserCode"), Me.JobNumber, Me.JobComponentNbr) = False Then
                'Server.Transfer("NoAccess.aspx")
                Me.ShowMessage("Access to this job/comp is denied")
                Me.CloseThisWindow()
                Exit Sub
            End If

        End If

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.InitializeLineChart(RadHtmlChartHoursLineChart, "")
        Dashboard.InitializeLineChart(RadHtmlChartBurnRateChart, "")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.RadToolbarHours.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        If Not Me.IsPostBack Then

            Me.Title = "Risk Analysis"
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()

            Dim s As String = ""
            s = oAppVars.getAppVar("GraphHB")
            If s <> "" Then
                If s = "Hours" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "HoursGraph" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.PanelStatus.Visible = True
                    Me.PanelBurnRate.Visible = False
                ElseIf s = "Burn" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "BurnRateGraph" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.PanelStatus.Visible = False
                    Me.PanelBurnRate.Visible = True
                End If
            Else
                Me.PanelStatus.Visible = False
            End If
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                If s = "Hours" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Text = "Dollars Graph" Then
                            rtb.Text = "Hours Graph"
                        End If
                        If rtb.Value = "Hours" Then
                            rtb.Checked = True
                        End If
                    Next
                ElseIf s = "Dollars" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Text = "Hours Graph" Then
                            rtb.Text = "Dollars Graph"
                        End If
                        If rtb.Value = "Dollars" Then
                            rtb.Checked = True
                        End If
                    Next
                End If
            End If
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                If s = "ETF" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "ETF" Then
                            rtb.Checked = True
                        End If
                    Next
                ElseIf s = "Allowed" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Allowed" Then
                            rtb.Checked = True
                        End If
                    Next
                End If
            End If
            s = oAppVars.getAppVar("GraphSC")
            If s <> "" Then
                If s = "Stepped" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Monthly" Then
                            rtb.Checked = True
                        End If
                    Next
                ElseIf s = "Cumulative" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Cumulative" Then
                            rtb.Checked = True
                        End If
                    Next
                End If
            End If
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                If s = "Quoted" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Quoted" Then
                            rtb.Checked = True
                        End If
                    Next
                ElseIf s = "Planned" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Planned" Then
                            rtb.Checked = True
                        End If
                    Next
                End If
            End If
            s = oAppVars.getAppVar("GraphMW")
            If s <> "" Then
                If s = "Month" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Month" Then
                            rtb.Checked = True
                        End If
                    Next
                    buildRGStatus()
                    buildRGStatusCumulative()
                ElseIf s = "Week" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "Week" Then
                            rtb.Checked = True
                        End If
                    Next
                    buildRGStatusWeek()
                    buildRGStatusCumulativeWeek()
                End If
            Else
                buildRGStatusWeek()
                buildRGStatusCumulativeWeek()
            End If

            LoadData()

            If Not Request.QueryString("From") Is Nothing AndAlso Request.QueryString("From") = "ras" Then

                If Not Request.QueryString("burn") Is Nothing Then

                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items

                        If rtb.Text = Request.QueryString("burn") Then

                            rtb.Checked = True

                        End If
                    Next

                End If

            End If

        End If

    End Sub

    Private Sub LoadData()
        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim group As String
            Dim charthours As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                    group = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    charthours = rtb.Value
                End If
            Next
            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            If group = "Month" Then
                If burn = "Quoted" Then
                    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
                Else
                    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
                End If
            ElseIf group = "Week" Then
                If burn = "Quoted" Then
                    ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 0)
                Else
                    ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 1)
                End If
            End If
            Session("ds_Traffic_Schedule_Status") = ds

            LoadStatusLineChart(ds)
            LoadBurnRateLineChart(ds)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Public Function WriteXMLStatus() As String
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        j.GetJob(Me.JobNumber)
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                chart = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                charthours = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Stepped" Or rtb.Text = "Cumulative") Then
                charttype = rtb.Value
            End If
        Next
        Dim burn As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                burn = rtb.Value
            End If
        Next
        Dim group As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                group = rtb.Value
            End If
        Next
        Return proj.getFCXMLData_MultiColumn3D_ProjectStatus(Session("ds_Traffic_Schedule_Status"), "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 0, chart, charthours, charttype, burn, group)
    End Function

    Public Sub LoadStatusLineChart(ByVal ds As DataSet)
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        j.GetJob(Me.JobNumber)
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                chart = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                charthours = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Stepped" Or rtb.Text = "Cumulative") Then
                charttype = rtb.Value
            End If
        Next
        Dim burn As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                burn = rtb.Value
            End If
        Next
        Dim group As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                group = rtb.Value
            End If
        Next

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        'Me.LabelByLevel.Text = Me.RadComboBoxByEmployee.SelectedItem.Text

        Dashboard.GetLineChart_Status(RadHtmlChartHoursLineChart, ds, "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 0, chart, charthours, charttype, burn, group)

        Me.Label2.Text = "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC

    End Sub

    Public Function WriteXMLBurnRate() As String
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        j.GetJob(Me.JobNumber)
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                chart = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                charthours = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Stepped" Or rtb.Text = "Cumulative") Then
                charttype = rtb.Value
            End If
        Next
        Dim burn As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                burn = rtb.Value
            End If
        Next
        Dim group As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                group = rtb.Value
            End If
        Next
        Return proj.getFCXMLData_MultiColumn3D_ProjectStatus(Session("ds_Traffic_Schedule_Status"), "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 1, chart, charthours, charttype, burn, group)
    End Function

    Public Sub LoadBurnRateLineChart(ByVal ds As DataSet)
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        j.GetJob(Me.JobNumber)
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                chart = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                charthours = rtb.Value
            End If
        Next
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Stepped" Or rtb.Text = "Cumulative") Then
                charttype = rtb.Value
            End If
        Next
        Dim burn As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                burn = rtb.Value
            End If
        Next
        Dim group As String
        For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
            If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                group = rtb.Value
            End If
        Next

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

        'Me.LabelByLevel.Text = Me.RadComboBoxByEmployee.SelectedItem.Text

        Dashboard.GetLineChart_Status(RadHtmlChartBurnRateChart, ds, "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 1, chart, charthours, charttype, burn, group)

        Me.Label2.Text = "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC

    End Sub

#Region " RadGrid "

    Private Function BuildStatusDT(ByVal hoursdata As String)
        Try
            Dim count As Integer
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim charthours As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    charthours = rtb.Value
                End If
            Next

            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next

            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            Else
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            End If

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim hours As DataColumn = New DataColumn("Project Hours")
            Dim dollars As DataColumn = New DataColumn("Project Dollars")
            If datatype = "Hours" Then
                dtComps.Columns.Add(hours)
            ElseIf datatype = "Dollars" Then
                dtComps.Columns.Add(dollars)
            End If


            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(MonthName(ds.Tables(0).Rows(i)(2)).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)(3))
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim actual As Decimal = 0
            Dim planned As Decimal = 0
            Dim quoted As Decimal = 0
            If datatype = "Hours" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    If CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                End If
                                If hoursdata = "Allowed" Then
                                    If CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                End If
                            ElseIf burn = "Quoted" Then
                                If CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS")) > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS")))
                                End If
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = String.Format("{0:#,##0.00}", actual / planned)
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Quoted"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("QUOTED_HOURS")
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Planned/Adj"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If hoursdata = "ETF" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("FORECAST_HOURS")
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                            End If
                            If hoursdata = "Allowed" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("HOURS_ALLOWED")
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Actual"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("ACTUAL_HOURS")
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            ElseIf datatype = "Dollars" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    If CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                End If
                                If hoursdata = "Allowed" Then
                                    If CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                End If
                            ElseIf burn = "Quoted" Then
                                If CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")) > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")))
                                End If
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = String.Format("{0:#,##0.00}", actual / planned)
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Quoted"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Planned/Adj"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If hoursdata = "ETF" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                            End If
                            If hoursdata = "Allowed" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Actual"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            End If


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
    Private Function BuildStatusDTWeek(ByVal hoursdata As String)
        Try
            Dim count As Integer
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next

            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 0)
            Else
                ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 1)
            End If

            Dim hours As DataColumn = New DataColumn("Project Hours")
            Dim dollars As DataColumn = New DataColumn("Project Dollars")
            If datatype = "Hours" Then
                dtComps.Columns.Add(hours)
            ElseIf datatype = "Dollars" Then
                dtComps.Columns.Add(dollars)
            End If


            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString)
                    dtComps.Columns.Add(dc)
                Next
            End If

            dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim total As Decimal = 0
            Dim actual As Decimal = 0
            Dim planned As Decimal = 0
            Dim quoted As Decimal = 0
            If datatype = "Hours" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    If CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                End If
                                If hoursdata = "Allowed" Then
                                    If CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                End If
                            ElseIf burn = "Quoted" Then
                                If CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS")) > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS")) / CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS")))
                                End If
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                            End If
                        End If
                    Next
                Next
                If planned > 0 Then
                    newrow.Item("Total") = String.Format("{0:#,##0.00}", actual / planned)
                End If
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Quoted"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("QUOTED_HOURS")
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Planned/Adj"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If hoursdata = "ETF" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("FORECAST_HOURS")
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                            End If
                            If hoursdata = "Allowed" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("HOURS_ALLOWED")
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Actual"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("ACTUAL_HOURS")
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            ElseIf datatype = "Dollars" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    If CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                End If
                                If hoursdata = "Allowed" Then
                                    If CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")) > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")))
                                    End If
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                End If
                            ElseIf burn = "Quoted" Then
                                If CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")) > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")) / CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")))
                                End If
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                            End If
                        End If
                    Next
                Next
                If planned > 0 Then
                    newrow.Item("Total") = String.Format("{0:#,##0.00}", actual / planned)
                End If
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Quoted"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("QUOTED_HRS_AMT")
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Planned/Adj"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If hoursdata = "ETF" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("FORECAST_HRS_AMT")
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                            End If
                            If hoursdata = "Allowed" Then
                                newrow.Item(x) = ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT")
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                            End If
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Actual"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            newrow.Item(x) = ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT")
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                        End If
                    Next
                Next
                newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            End If


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

    Private Function buildRGStatus()
        Try
            Me.RadGridStatusHours.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim charthours As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    charthours = rtb.Value
                End If
            Next
            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next
            ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours)
            'If burn = "Quoted" Then
            '    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            'Else
            '    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            'End If

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            If datatype = "Hours" Then
                boundColumn.DataField = "Project Hours"
            ElseIf datatype = "Dollars" Then
                boundColumn.DataField = "Project Dollars"
            End If
            boundColumn.HeaderText = ""
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = MonthName(ds.Tables(0).Rows(i)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    boundColumn.HeaderText = MonthName(ds.Tables(0).Rows(i)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH") & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)



        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGStatusWeek()
        Try
            Me.RadGridStatusHours.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr)

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            If datatype = "Hours" Then
                boundColumn.DataField = "Project Hours"
            ElseIf datatype = "Dollars" Then
                boundColumn.DataField = "Project Dollars"
            End If
            boundColumn.HeaderText = ""
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString
                    boundColumn.HeaderText = CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString
                    boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("WEEK")
                    RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)



        Catch ex As Exception

        End Try
    End Function

    Private Sub RadGridStatusHours_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridStatusHours.ItemDataBound
        Try
            'If Me.RadioButtonDollars.Checked = True Then
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                For i As Integer = 1 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                    End If
                Next
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridStatusHours_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridStatusHours.NeedDataSource
        Try
            Dim hourtype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    hourtype = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                    If rtb.Text = "Month" Then
                        Me.RadGridStatusHours.DataSource = BuildStatusDT(hourtype)
                    ElseIf rtb.Text = "Week" Then
                        Me.RadGridStatusHours.DataSource = BuildStatusDTWeek(hourtype)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function BuildStatusDTCumulative(ByVal hoursdata As String)
        Try
            Dim count As Integer
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim charthours As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    charthours = rtb.Value
                End If
            Next

            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next

            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            Else
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            End If

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next



            Dim hours As DataColumn = New DataColumn("Project Hours")
            Dim dollars As DataColumn = New DataColumn("Project Dollars")
            If datatype = "Hours" Then
                dtComps.Columns.Add(hours)
            ElseIf datatype = "Dollars" Then
                dtComps.Columns.Add(dollars)
            End If

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(MonthName(ds.Tables(0).Rows(i)(2)).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)(3).ToString)
                    dtComps.Columns.Add(dc)
                Next
            End If

            'dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim cumulative As Decimal = 0
            Dim actual As Decimal = 0
            Dim planned As Decimal = 0
            Dim total As Decimal = 0
            If datatype = "Hours" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                                If hoursdata = "Allowed" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                                If planned > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                End If
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = ""
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Quoted CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Planned/Adj CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If hoursdata = "ETF" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                            End If
                            If hoursdata = "Allowed" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Actual CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            ElseIf datatype = "Dollars" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                                If hoursdata = "Allowed" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                                If planned > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                End If
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = ""
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Quoted CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Planned/Adj CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            If hoursdata = "ETF" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                            End If
                            If hoursdata = "Allowed" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Actual CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = MonthName(ds.Tables(0).Rows(j)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(j)("YEAR").ToString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            End If


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
    Private Function BuildStatusDTCumulativeWeek(ByVal hoursdata As String)
        Try
            Dim count As Integer
            Dim ds As DataSet
            Dim dtComps As DataTable
            dtComps = New DataTable("comps")

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next

            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 0)
            Else
                ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr, 1)
            End If

            Dim hours As DataColumn = New DataColumn("Project Hours")
            Dim dollars As DataColumn = New DataColumn("Project Dollars")
            If datatype = "Hours" Then
                dtComps.Columns.Add(hours)
            ElseIf datatype = "Dollars" Then
                dtComps.Columns.Add(dollars)
            End If

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dc = New DataColumn(CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString)
                    dtComps.Columns.Add(dc)
                Next
            End If

            'dtComps.Columns.Add("Total")

            Dim dtMonth As DataView
            Dim dt As DataTable
            Dim newrow As DataRow
            Dim cumulative As Decimal = 0
            Dim actual As Decimal = 0
            Dim planned As Decimal = 0
            Dim total As Decimal = 0
            If datatype = "Hours" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                                If hoursdata = "Allowed" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                                If planned > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                End If
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = ""
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Quoted CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HOURS"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Planned/Adj CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If hoursdata = "ETF" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HOURS"))
                            End If
                            If hoursdata = "Allowed" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED"))
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Hours") = "Actual CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HOURS"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            ElseIf datatype = "Dollars" Then
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Burn Rate"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If burn = "Planned" Then
                                If hoursdata = "ETF" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                                If hoursdata = "Allowed" Then
                                    actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                    planned += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                    If planned > 0 Then
                                        newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                    End If
                                End If
                            ElseIf burn = "Quoted" Then
                                actual += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                                planned += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                                If planned > 0 Then
                                    newrow.Item(x) = String.Format("{0:#,##0.00}", actual / planned)
                                End If
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = ""
                total = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Quoted CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("QUOTED_HRS_AMT"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Planned/Adj CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            If hoursdata = "ETF" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("FORECAST_HRS_AMT"))
                            End If
                            If hoursdata = "Allowed" Then
                                cumulative += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                                newrow.Item(x) = cumulative
                                total += CDec(ds.Tables(0).Rows(j)("HOURS_ALLOWED_AMT"))
                            End If
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                cumulative = 0
                dtComps.Rows.Add(newrow)
                newrow = dtComps.NewRow
                newrow.Item("Project Dollars") = "Actual CM"
                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    For x As Integer = 1 To dtComps.Columns.Count - 1
                        If dtComps.Columns(x).ColumnName = CDate(ds.Tables(0).Rows(j)("WEEK_START").ToString).ToShortDateString Then
                            cumulative += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                            newrow.Item(x) = cumulative
                            total += CDec(ds.Tables(0).Rows(j)("ACTUAL_HRS_AMT"))
                        End If
                    Next
                Next
                'newrow.Item("Total") = total
                total = 0
                dtComps.Rows.Add(newrow)
            End If


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

    Private Function buildRGStatusCumulative()
        Try
            Me.RadGridStatusHoursCumulative.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim charthours As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    charthours = rtb.Value
                End If
            Next

            Dim burn As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    burn = rtb.Value
                End If
            Next
            ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours)
            'If burn = "Quoted" Then
            '    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            'Else
            '    ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            'End If

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            If datatype = "Hours" Then
                boundColumn.DataField = "Project Hours"
            ElseIf datatype = "Dollars" Then
                boundColumn.DataField = "Project Dollars"
            End If
            boundColumn.HeaderText = ""
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = MonthName(ds.Tables(0).Rows(i)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    boundColumn.HeaderText = MonthName(ds.Tables(0).Rows(i)("MONTH")).Substring(0, 3) & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH") & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)



        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGStatusCumulativeWeek()
        Try
            Me.RadGridStatusHoursCumulative.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr)

            Dim datatype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Hours" Or rtb.Text = "Dollars") Then
                    datatype = rtb.Value
                End If
            Next

            Dim boundColumn As GridBoundColumn
            boundColumn = New GridBoundColumn
            If datatype = "Hours" Then
                boundColumn.DataField = "Project Hours"
            ElseIf datatype = "Dollars" Then
                boundColumn.DataField = "Project Dollars"
            End If
            boundColumn.HeaderText = ""
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)

            Dim dc As DataColumn
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    boundColumn = New GridBoundColumn
                    boundColumn.DataField = CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString
                    boundColumn.HeaderText = CDate(ds.Tables(0).Rows(i)("WEEK_START").ToString).ToShortDateString
                    boundColumn.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("WEEK")
                    RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            'boundColumn = New GridBoundColumn
            'boundColumn.DataField = "Total"
            'boundColumn.HeaderText = "Total"
            'boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            'RadGridStatusHoursCumulative.MasterTableView.Columns.Add(boundColumn)



        Catch ex As Exception

        End Try
    End Function

    Private Sub RadGridStatusHoursCumulative_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridStatusHoursCumulative.ItemDataBound
        Try
            'If Me.RadioButtonDollars.Checked = True Then
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                For i As Integer = 1 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                    End If
                Next
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridStatusHoursCumulative_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridStatusHoursCumulative.NeedDataSource
        Try
            Dim hourtype As String
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Value = "ETF" Or rtb.Value = "Allowed") Then
                    hourtype = rtb.Value
                End If
            Next
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                    If rtb.Text = "Month" Then
                        Me.RadGridStatusHoursCumulative.DataSource = BuildStatusDTCumulative(hourtype)
                    ElseIf rtb.Text = "Week" Then
                        Me.RadGridStatusHoursCumulative.DataSource = BuildStatusDTCumulativeWeek(hourtype)
                    End If
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls "

    'Private Sub RadioButtonHours_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonHours.CheckedChanged
    '    Try
    '        If Me.RadioButtonHours.Checked = True Then
    '            Me.PanelStatus.Visible = True
    '            Me.PanelBurnRate.Visible = False
    '        End If
    '        buildRGStatus()
    '        buildRGStatusCumulative()
    '        Me.RadGridStatusHours.Rebind()
    '        Me.RadGridStatusHoursCumulative.Rebind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadioButtonBurnRate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonBurnRate.CheckedChanged
    '    Try
    '        If Me.RadioButtonBurnRate.Checked = True Then
    '            Me.PanelStatus.Visible = False
    '            Me.PanelBurnRate.Visible = True
    '        End If
    '        buildRGStatus()
    '        buildRGStatusCumulative()
    '        Me.RadGridStatusHours.Rebind()
    '        Me.RadGridStatusHoursCumulative.Rebind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadioButtonHoursData_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonHoursData.CheckedChanged
    '    Try
    '        buildRGStatus()
    '        buildRGStatusCumulative()
    '        Me.RadGridStatusHours.Rebind()
    '        Me.RadGridStatusHoursCumulative.Rebind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub RadioButtonDollars_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonDollars.CheckedChanged
    '    Try
    '        buildRGStatus()
    '        buildRGStatusCumulative()
    '        Me.RadGridStatusHours.Rebind()
    '        Me.RadGridStatusHoursCumulative.Rebind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub RadToolbarHours_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarHours.ButtonClick
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Select Case e.Item.Value
                Case "HoursGraph"
                    Me.PanelStatus.Visible = True
                    Me.PanelBurnRate.Visible = False
                    oAppVars.setAppVarDB("GraphHB", "Hours")
                Case "BurnRateGraph"
                    Me.PanelStatus.Visible = False
                    Me.PanelBurnRate.Visible = True
                    oAppVars.setAppVarDB("GraphHB", "Burn")
                Case "Month"
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "ETF" Then
                            rtb.Enabled = True
                        End If
                        If rtb.Value = "Allowed" Then
                            rtb.Checked = True
                        End If
                    Next
                    LoadData()
                    oAppVars.setAppVarDB("GraphMW", "Month")
                Case "Week"
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Value = "ETF" Then
                            rtb.Checked = False
                            rtb.Enabled = False
                        End If
                    Next
                    LoadData()
                    oAppVars.setAppVarDB("GraphMW", "Week")
                Case "Hours"
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Text = "Dollars Graph" Then
                            rtb.Text = "Hours Graph"
                        End If
                    Next
                    LoadData()
                    oAppVars.setAppVarDB("GraphHD", "Hours")
                Case "Dollars"
                    For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                        If rtb.Text = "Hours Graph" Then
                            rtb.Text = "Dollars Graph"
                        End If
                    Next
                    LoadData()
                    oAppVars.setAppVarDB("GraphHD", "Dollars")
                Case "ETF"
                    oAppVars.setAppVarDB("GraphEA", "ETF")
                Case "Allowed"
                    Me.LoadData()
                    oAppVars.setAppVarDB("GraphEA", "Allowed")
                Case "Monthly"
                    oAppVars.setAppVarDB("GraphSC", "Stepped")
                Case "Cumulative"
                    oAppVars.setAppVarDB("GraphSC", "Cumulative")
                Case "Quoted"
                    oAppVars.setAppVarDB("GraphQP", "Quoted")
                Case "Planned"
                    oAppVars.setAppVarDB("GraphQP", "Planned")
                Case "Refresh"

                Case "Bookmark"

                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Dim jc As New AdvantageFramework.Database.Entities.JobComponent
                    Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)
                        jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNbr)
                    End Using

                    qs = qs.FromCurrent()

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_RiskAnalysisGraph
                        .UserCode = Session("UserCode")
                        .Name = "Risk Analysis for " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNbr.ToString().PadLeft(2, "0")
                        .Description = "Risk Analysis for " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & " - " & jc.Description
                        .PageURL = "TrafficSchedule_Status_Graph.aspx" & qs.ToString()

                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then

                        Me.ShowMessage(s)

                    Else

                        Me.RefreshBookmarksDesktopObject()

                    End If
                    'Case "Print"
                    'Me.OpenFloatingWindow("", "TrafficSchedule_Status_Graph_Print.aspx?JobNum=" & Me.JobNumber & "&JobComp=" & Me.JobComponentNbr, 800, 1200)
                    'Me.OpenWindow("", "TrafficSchedule_Status_Graph_Print.aspx?JobNum=" & Me.JobNumber & "&JobComp=" & Me.JobComponentNbr)
            End Select
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Checked = True And (rtb.Text = "Month" Or rtb.Text = "Week") Then
                    If rtb.Text = "Month" Then
                        buildRGStatus()
                        buildRGStatusCumulative()
                    ElseIf rtb.Text = "Week" Then
                        buildRGStatusWeek()
                        buildRGStatusCumulativeWeek()
                    End If
                End If
            Next
            RadGridStatusHours.Rebind()
            RadGridStatusHoursCumulative.Rebind()
            Me.LoadData()
        Catch ex As Exception

        End Try
    End Sub

#End Region


    Private Sub TrafficSchedule_Status_Graph_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Try
            For Each rtb As RadToolBarButton In Me.RadToolbarHours.Items
                If rtb.Value = "Print" Then
                    rtb.Attributes.Add("onclick", "window.open('TrafficSchedule_Status_Graph_Print.aspx?JobNum=" & Me.JobNumber & "&JobComp=" & Me.JobComponentNbr & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1100,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub


End Class
