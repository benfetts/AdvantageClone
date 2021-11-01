Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports InfoSoftGlobal

Public Class TrafficSchedule_Status_Graph_Print
    Inherits Webvantage.BaseChildPage

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private export As Integer = 0

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

        Dim Dashboard As Webvantage.cDashboard = Nothing

        Dashboard = New Webvantage.cDashboard(_Session.ConnectionString, _Session.UserCode)

        Dashboard.InitializeLineChart(RadHtmlChartHoursLineChart, "")
        Dashboard.InitializeLineChart(RadHtmlChartBurnRateChart, "")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Request.QueryString("JobNum")) Then
                Me.JobNumber = CType(Request.QueryString("JobNum"), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) Then
                Me.JobComponentNbr = CType(Request.QueryString("JobComp"), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        If Not Me.IsPostBack Then
            Me.Title = "Risk Analysis"
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()

            Dim s As String = ""
            s = oAppVars.getAppVar("GraphHB")
            If s <> "" Then
                If s = "Hours" Then
                    Me.PanelStatus.Visible = True
                    Me.PanelBurnRate.Visible = False
                ElseIf s = "Burn" Then
                    Me.PanelStatus.Visible = False
                    Me.PanelBurnRate.Visible = True
                End If
            Else
                Me.PanelStatus.Visible = False
            End If
            s = oAppVars.getAppVar("GraphMW")
            If s <> "" Then
                If s = "Month" Then
                    buildRGStatus()
                    buildRGStatusCumulative()
                ElseIf s = "Week" Then
                    buildRGStatusWeek()
                    buildRGStatusCumulativeWeek()
                End If
            Else
                buildRGStatusWeek()
                buildRGStatusCumulativeWeek()
            End If

            LoadData()


        End If
    End Sub

    Private Sub LoadData()
        Dim oDTO As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ds As New System.Data.DataSet
        Dim dt As New System.Data.DataTable

        Try
            Dim s As String = ""
            Dim group As String
            Dim charthours As String
            Dim burn As String
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            s = oAppVars.getAppVar("GraphMW")
            If s <> "" Then
                group = s
            Else
                group = "Week"
            End If
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                charthours = s
            Else
                charthours = "Allowed"
            End If
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                burn = s
            Else
                burn = "Quoted"
            End If

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
        Dim group As String
        Dim burn As String
        Dim s As String = ""
        j.GetJob(Me.JobNumber)

        Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
        oAppVars.getAllAppVars()
        s = oAppVars.getAppVar("GraphHD")
        If s <> "" Then
            chart = s
        Else
            chart = "Hours"
        End If
        s = oAppVars.getAppVar("GraphEA")
        If s <> "" Then
            charthours = s
        Else
            charthours = "Allowed"
        End If
        s = oAppVars.getAppVar("GraphSC")
        If s <> "" Then
            charttype = s
        Else
            charttype = "Cumulative"
        End If
        s = oAppVars.getAppVar("GraphQP")
        If s <> "" Then
            burn = s
        Else
            burn = "Quoted"
        End If
        s = oAppVars.getAppVar("GraphMW")
        If s <> "" Then
            group = s
        Else
            group = "Week"
        End If
        Return proj.getFCXMLData_MultiColumn3D_ProjectStatus(Session("ds_Traffic_Schedule_Status"), "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 0, chart, charthours, charttype, burn, group)
    End Function

    Public Sub LoadStatusLineChart(ByVal ds As DataSet)
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        Dim group As String
        Dim burn As String
        Dim s As String = ""
        j.GetJob(Me.JobNumber)

        Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
        oAppVars.getAllAppVars()
        s = oAppVars.getAppVar("GraphHD")
        If s <> "" Then
            chart = s
        Else
            chart = "Hours"
        End If
        s = oAppVars.getAppVar("GraphEA")
        If s <> "" Then
            charthours = s
        Else
            charthours = "Allowed"
        End If
        s = oAppVars.getAppVar("GraphSC")
        If s <> "" Then
            charttype = s
            If charttype = "Stepped" Then
                charttype = "Monthly"
            End If
        Else
            charttype = "Cumulative"
        End If
        s = oAppVars.getAppVar("GraphQP")
        If s <> "" Then
            burn = s
        Else
            burn = "Quoted"
        End If
        s = oAppVars.getAppVar("GraphMW")
        If s <> "" Then
            group = s
        Else
            group = "Week"
        End If

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
        Dim group As String
        Dim burn As String
        Dim s As String = ""
        j.GetJob(Me.JobNumber)

        Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
        oAppVars.getAllAppVars()
        s = oAppVars.getAppVar("GraphHD")
        If s <> "" Then
            chart = s
        Else
            chart = "Hours"
        End If
        s = oAppVars.getAppVar("GraphEA")
        If s <> "" Then
            charthours = s
        Else
            charthours = "Allowed"
        End If
        s = oAppVars.getAppVar("GraphSC")
        If s <> "" Then
            charttype = s
        Else
            charttype = "Cumulative"
        End If
        s = oAppVars.getAppVar("GraphQP")
        If s <> "" Then
            burn = s
        Else
            burn = "Quoted"
        End If
        s = oAppVars.getAppVar("GraphMW")
        If s <> "" Then
            group = s
        Else
            group = "Week"
        End If
        Return proj.getFCXMLData_MultiColumn3D_ProjectStatus(Session("ds_Traffic_Schedule_Status"), "Job " & Me.JobNumber.ToString.PadLeft(6, "0") & " - " & j.JOB_DESC, 1, chart, charthours, charttype, burn, group)
    End Function

    Public Sub LoadBurnRateLineChart(ByVal ds As DataSet)
        Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim j As New Job(Session("ConnString"))
        Dim chart As String = "Hours"
        Dim charthours As String
        Dim charttype As String
        Dim group As String
        Dim burn As String
        Dim s As String = ""
        j.GetJob(Me.JobNumber)

        Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
        oAppVars.getAllAppVars()
        s = oAppVars.getAppVar("GraphHD")
        If s <> "" Then
            chart = s
        Else
            chart = "Hours"
        End If
        s = oAppVars.getAppVar("GraphEA")
        If s <> "" Then
            charthours = s
        Else
            charthours = "Allowed"
        End If
        s = oAppVars.getAppVar("GraphSC")
        If s <> "" Then
            charttype = s
        Else
            charttype = "Cumulative"
        End If
        s = oAppVars.getAppVar("GraphQP")
        If s <> "" Then
            burn = s
        Else
            burn = "Quoted"
        End If
        s = oAppVars.getAppVar("GraphMW")
        If s <> "" Then
            group = s
        Else
            group = "Week"
        End If

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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Dim charthours As String
            Dim burn As String
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                charthours = s
            Else
                charthours = "Allowed"
            End If
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                burn = s
            Else
                burn = "Quoted"
            End If

            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            Else
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            End If

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

            Dim burn As String
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                burn = s
            Else
                burn = "Quoted"
            End If

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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Dim charthours As String
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                charthours = s
            Else
                charthours = "Allowed"
            End If
            ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours)

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

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
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("MONTH") & "-" & ds.Tables(0).Rows(i)("YEAR").ToString
                    RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
            RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)



        Catch ex As Exception

        End Try
    End Function
    Private Function buildRGStatusWeek()
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Me.RadGridStatusHours.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr)

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

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
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
                    boundColumn.UniqueName = "col" & ds.Tables(0).Rows(i)("WEEK")
                    RadGridStatusHours.MasterTableView.Columns.Add(boundColumn)
                Next
            End If

            boundColumn = New GridBoundColumn
            boundColumn.DataField = "Total"
            boundColumn.HeaderText = "Total"
            boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Dim hourtype As String
            Dim group As String
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                hourtype = s
            Else
                hourtype = "Allowed"
            End If
            s = oAppVars.getAppVar("GraphMW")
            If s <> "" Then
                group = s
            Else
                group = "Week"
            End If
            If group = "Month" Then
                Me.RadGridStatusHours.DataSource = BuildStatusDT(hourtype)
            ElseIf group = "Week" Then
                Me.RadGridStatusHours.DataSource = BuildStatusDTWeek(hourtype)
            End If

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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Dim charthours As String
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                charthours = s
            Else
                charthours = "Allowed"
            End If

            Dim burn As String
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                burn = s
            Else
                burn = "Quoted"
            End If

            If burn = "Quoted" Then
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 0)
            Else
                ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours, 1)
            End If

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

            Dim burn As String
            s = oAppVars.getAppVar("GraphQP")
            If s <> "" Then
                burn = s
            Else
                burn = "Quoted"
            End If

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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""

            Me.RadGridStatusHoursCumulative.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim charthours As String
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                charthours = s
            Else
                charthours = "Allowed"
            End If
            ds = proj.GetScheduleStatusTasks(Me.JobNumber, Me.JobComponentNbr, charthours)

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

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
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Me.RadGridStatusHoursCumulative.MasterTableView.Columns.Clear()
            Dim count As Integer
            Dim ds As DataSet
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))
            ds = proj.GetScheduleStatusTasksWeek(Me.JobNumber, Me.JobComponentNbr)

            Dim datatype As String
            s = oAppVars.getAppVar("GraphHD")
            If s <> "" Then
                datatype = s
            Else
                datatype = "Hours"
            End If

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
                    boundColumn.ItemStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left
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
            Dim group As String
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_GRAPH)
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("GraphEA")
            If s <> "" Then
                hourtype = s
            Else
                hourtype = "Allowed"
            End If
            s = oAppVars.getAppVar("GraphMW")
            If s <> "" Then
                group = s
            Else
                group = "Week"
            End If
            If group = "Month" Then
                Me.RadGridStatusHoursCumulative.DataSource = BuildStatusDTCumulative(hourtype)
            ElseIf group = "Week" Then
                Me.RadGridStatusHoursCumulative.DataSource = BuildStatusDTCumulativeWeek(hourtype)
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class
