Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Web
Imports System.Globalization
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraCharts.Native
Imports System.IO
Imports System.Drawing

Public Class TrafficSchedule_Gantt
    Inherits Webvantage.BaseChildPage

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public SeqNbr As Integer = -1
    Private cbAppearance As ASPxComboBox
    Private cbPalette As ASPxComboBox
    Private sbJobs As String = ""
    Private strJobs As String = ""

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
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
        'Dim mnuAppearance As MenuItem = mnuToolbar.Items.FindByName("mnuAppearance")
        'If mnuAppearance IsNot Nothing Then
        '    cbAppearance = TryCast(mnuAppearance.FindControl("cbAppearance"), ASPxComboBox)
        '    If cbAppearance IsNot Nothing Then
        '        PrepareComboBox(cbAppearance, WebChartControl1.GetAppearanceNames(), WebChartControl1.AppearanceName)
        '    End If
        'End If
        'Dim mnuPalette As MenuItem = mnuToolbar.Items.FindByName("mnuPalette")
        'If mnuPalette IsNot Nothing Then
        '    cbPalette = TryCast(mnuPalette.FindControl("cbPalette"), ASPxComboBox)
        '    If cbPalette IsNot Nothing Then
        '        PrepareComboBox(cbPalette, WebChartControl1.GetPaletteNames(), WebChartControl1.PaletteName)
        '    End If
        'End If
    End Sub

    Private Sub PrepareComboBox(ByVal comboBox As ASPxComboBox, ByVal items() As String, ByVal defaultItem As String)
        comboBox.Items.Clear()
        comboBox.Items.AddRange(items)
        If defaultItem IsNot Nothing Then
            comboBox.SelectedIndex = comboBox.Items.IndexOfText(defaultItem)
        Else
            comboBox.SelectedIndex = 0
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DevExpress.Web.ASPxWebControl.RegisterBaseScript(Me.Page)
        Me.Title = "Gantt Chart"
        CheckForPredecessors()
        Try
            LoadChartPanes()
            If Me.IsPostBack = False Then
                'LoadChartPanes()
            Else
                Select Case Me.EventArgument
                    Case ""

                End Select
            End If
            'LoadChart()
            'LoadChartOneGraph()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadChart()
        Try
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As DataTable
            Dim count As Integer = 0
            Dim chartControl1 As DevExpress.XtraCharts.Web.WebChartControl
            If Request.QueryString("from") = "ps" Then
                chartControl1 = New DevExpress.XtraCharts.Web.WebChartControl()
                dt = oTrafficSchedule.GetScheduleTasks(Me.JobNumber, Me.JobComponentNbr, "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                Dim ser1 As New DevExpress.XtraCharts.Series(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(2, "0"), ViewType.Gantt)
                ser1.ValueScaleType = ScaleType.DateTime
                ser1.Label.Visible = False
                ser1.Label.LineVisible = True
                ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                Dim sp As DevExpress.XtraCharts.SeriesPoint
                For i As Integer = 0 To dt.Rows.Count - 1
                    sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("SEQ_NBR").ToString, New DateTime() {dt.Rows(i)("TASK_START_DATE"), dt.Rows(i)("JOB_REVISED_DATE")})
                    sp.Argument = dt.Rows(i)("TASK_DESCRIPTION").ToString
                    sp.Tag = dt.Rows(i)
                    sp.CreateSeriesPointWithId(dt.Rows(i)("TASK_DESCRIPTION").ToString, i)
                    ser1.Points.Add(sp)
                Next
                chartControl1.Series.Add(ser1)
                chartControl1.Width = Unit.Pixel(1000)
                chartControl1.Height = Unit.Pixel(500)
                'Me.phGantt.Controls.Add(chartControl1)
                Dim myDiagram As GanttDiagram = CType(chartControl1.Diagram, GanttDiagram)
                'myDiagram.AxisY.Label.Angle = -40

                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                myDiagram.AxisY.MinorCount = 4
                myDiagram.AxisY.GridLines.MinorVisible = True
                myDiagram.AxisY.GridLines.Visible = True
                myDiagram.AxisY.Interlaced = True
                myDiagram.AxisX.Title.Text = "Tasks"
                'AddHandler chartControl1.ObjectSelected, AddressOf chartObjectSelected
                chartControl1.EnableCallBacks = False
                chartControl1.EnableClientSideAPI = True
                chartControl1.EnableClientSidePointToDiagram = True
                chartControl1.ClientInstanceName = "chartGantt"
            Else
                Dim myDiagram As GanttDiagram
                'Dim view As DevExpress.XtraCharts.SideBySideGanttSeriesView
                'myDiagram.AxisY.Label.Angle = -40

                Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                For i As Integer = 0 To JC.Length - 1
                    Dim j() As String = JC(i).Split(",")
                    If j(0) <> "" Then
                        chartControl1 = New DevExpress.XtraCharts.Web.WebChartControl()
                        dt = oTrafficSchedule.GetScheduleTasks(j(0), j(1), "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                        Dim ser1 As New DevExpress.XtraCharts.Series(j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0"), ViewType.Gantt)
                        ser1.ValueScaleType = ScaleType.DateTime
                        'ser1.Label.Visible = False
                        'ser1.Label.LineVisible = True
                        ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                        Dim sp As DevExpress.XtraCharts.SeriesPoint
                        For x As Integer = 0 To dt.Rows.Count - 1
                            sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("SEQ_NBR").ToString, New DateTime() {dt.Rows(x)("TASK_START_DATE"), dt.Rows(x)("JOB_REVISED_DATE")})
                            sp.Argument = dt.Rows(x)("TASK_DESCRIPTION").ToString
                            sp.Tag = dt.Rows(x)
                            sp.CreateSeriesPointWithId(dt.Rows(x)("TASK_DESCRIPTION").ToString, x)
                            ser1.Points.Add(sp)
                        Next
                        'If count >= 1 Then
                        chartControl1.Series.Add(ser1)
                        chartControl1.Width = Unit.Pixel(1000)
                        chartControl1.Height = Unit.Pixel(500)
                        'Me.phGantt.Controls.Add(chartControl1)
                        myDiagram = CType(chartControl1.Diagram, GanttDiagram)
                        'myDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & count))
                        'view = CType(ser1.View, SideBySideGanttSeriesView)
                        'view.Pane = myDiagram.Panes(count - 1)
                        'Else
                        'chartControl1.Series.Add(ser1)
                        'myDiagram = CType(chartControl1.Diagram, GanttDiagram)
                        'End If
                        myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                        myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                        myDiagram.AxisY.MinorCount = 4
                        myDiagram.AxisY.GridLines.MinorVisible = True
                        myDiagram.AxisY.GridLines.Visible = True
                        myDiagram.AxisY.Interlaced = True

                        myDiagram.AxisX.Title.Text = "Tasks"

                        'count += 1
                    End If
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadChartOneGraph()
        Try
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As DataTable
            Dim count As Integer = 0
            If Request.QueryString("from") = "ps" Then
                dt = oTrafficSchedule.GetScheduleTasks(Me.JobNumber, Me.JobComponentNbr, "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                Dim ser1 As New DevExpress.XtraCharts.Series(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(2, "0"), ViewType.Gantt)
                ser1.ValueScaleType = ScaleType.DateTime
                ser1.Label.Visible = False
                ser1.Label.LineVisible = True
                ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                Dim sp As DevExpress.XtraCharts.SeriesPoint
                For i As Integer = 0 To dt.Rows.Count - 1
                    sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("SEQ_NBR").ToString, New DateTime() {dt.Rows(i)("TASK_START_DATE"), dt.Rows(i)("JOB_REVISED_DATE")})
                    sp.Argument = dt.Rows(i)("TASK_DESCRIPTION").ToString
                    sp.Tag = dt.Rows(i)
                    sp.CreateSeriesPointWithId(dt.Rows(i)("TASK_DESCRIPTION").ToString, i)
                    ser1.Points.Add(sp)
                Next
                WebChartControl1.Series.Add(ser1)
                Dim myDiagram As GanttDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                'myDiagram.AxisY.Label.Angle = -40

                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                myDiagram.AxisY.MinorCount = 4
                myDiagram.AxisY.GridLines.MinorVisible = True
                myDiagram.AxisY.GridLines.Visible = True
                myDiagram.AxisY.Interlaced = True
                myDiagram.AxisX.Title.Text = "Tasks"

            Else
                Dim myDiagram As GanttDiagram
                'Dim view As DevExpress.XtraCharts.SideBySideGanttSeriesView
                'myDiagram.AxisY.Label.Angle = -40

                Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                For i As Integer = 0 To JC.Length - 1
                    Dim j() As String = JC(i).Split(",")
                    If j(0) <> "" Then
                        dt = oTrafficSchedule.GetScheduleTasks(j(0), j(1), "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                        Dim ser1 As New DevExpress.XtraCharts.Series(j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0"), ViewType.SideBySideGantt)
                        ser1.ValueScaleType = ScaleType.DateTime
                        ser1.Label.Visible = False
                        ser1.Label.LineVisible = True
                        ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                        Dim sp As DevExpress.XtraCharts.SeriesPoint
                        For x As Integer = 0 To dt.Rows.Count - 1
                            sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("SEQ_NBR").ToString, New DateTime() {dt.Rows(x)("TASK_START_DATE"), dt.Rows(x)("JOB_REVISED_DATE")})
                            sp.Argument = dt.Rows(x)("TASK_DESCRIPTION").ToString
                            sp.Tag = dt.Rows(x)
                            sp.CreateSeriesPointWithId(dt.Rows(x)("TASK_DESCRIPTION").ToString, x)
                            ser1.Points.Add(sp)
                        Next
                        'If count >= 1 Then
                        WebChartControl1.Series.Add(ser1)
                        myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                        'myDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & count))
                        'view = CType(ser1.View, SideBySideGanttSeriesView)
                        'view.Pane = myDiagram.Panes(count - 1)
                        'Else
                        'chartControl1.Series.Add(ser1)
                        'myDiagram = CType(chartControl1.Diagram, GanttDiagram)
                        'End If
                        myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                        myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                        myDiagram.AxisY.MinorCount = 4
                        myDiagram.AxisY.GridLines.MinorVisible = True
                        myDiagram.AxisY.GridLines.Visible = True
                        myDiagram.AxisY.Interlaced = True

                        myDiagram.AxisX.Title.Text = "Tasks"

                        'count += 1
                    End If
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadChartPanes(Optional ByVal showlabels As Boolean = False, Optional ByVal jobs As String = "")
        Try
            Me.WebChartControl1.Series.Clear()
            Me.WebChartControl1.Legend.Visible = False
            Dim chartControl1 As DevExpress.XtraCharts.Web.WebChartControl
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim dt As DataTable
            Dim sd As DateTime
            Dim ed As DateTime
            Dim months As Integer
            Dim count As Integer = 0
            Dim phase As Integer = 0
            Dim enddate As Date
            If Request.QueryString("from") = "ps" And jobs = "" Then
                Dim myDiagram As GanttDiagram
                If Me.RadToolbarButtonShowPhase.Checked Then
                    dt = oTrafficSchedule.GetScheduleTasks(Me.JobNumber, Me.JobComponentNbr, "phase", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                Else
                    dt = oTrafficSchedule.GetScheduleTasks(Me.JobNumber, Me.JobComponentNbr, "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                End If
                Dim ser1 As New DevExpress.XtraCharts.Series(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(2, "0"), ViewType.SideBySideGantt)
                ser1.ValueScaleType = ScaleType.DateTime
                If showlabels = True Then
                    ser1.Label.Visible = True
                    ser1.Label.LineVisible = True
                Else
                    ser1.Label.Visible = False
                    ser1.Label.LineVisible = False
                End If
                ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                Dim sp As DevExpress.XtraCharts.SeriesPoint
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNbr)
                            If JobComp.StartDate Is Nothing And JobComp.DueDate Is Nothing Then
                                sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {Now, Now})
                            ElseIf JobComp.StartDate Is Nothing Then
                                sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.DueDate, JobComp.DueDate})
                            ElseIf JobComp.DueDate Is Nothing Then
                                sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.StartDate, JobComp.StartDate})
                            Else
                                sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.StartDate, JobComp.DueDate})
                            End If
                            sp.Argument = JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description
                            'sp.Tag = dt.Rows(x)
                            sp.CreateSeriesPointWithId(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, i)
                            ser1.Points.Add(sp)
                        End Using
                    End If
                    If Me.RadToolbarButtonShowPhase.Checked Then
                        If phase = 0 And IsDBNull(dt.Rows(i)("PHASE_START_DATE")) = False Then
                            If IsDBNull(dt.Rows(i)("PHASE_END_DATE")) = False Then
                                sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("PHASE_DESC").ToString, New DateTime() {dt.Rows(i)("PHASE_START_DATE"), dt.Rows(i)("PHASE_END_DATE")})
                                sp.Argument = dt.Rows(i)("PHASE_DESC").ToString & "*"
                                sp.Tag = dt.Rows(i)
                                sp.CreateSeriesPointWithId(dt.Rows(i)("PHASE_DESC").ToString, i)
                                ser1.Points.Add(sp)
                                phase = dt.Rows(i)("TRAFFIC_PHASE_ID").ToString
                            End If
                        ElseIf phase <> dt.Rows(i)("TRAFFIC_PHASE_ID").ToString And IsDBNull(dt.Rows(i)("PHASE_START_DATE")) = False Then
                            If IsDBNull(dt.Rows(i)("PHASE_END_DATE")) = False Then
                                sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("PHASE_DESC").ToString, New DateTime() {dt.Rows(i)("PHASE_START_DATE"), dt.Rows(i)("PHASE_END_DATE")})
                                sp.Argument = dt.Rows(i)("PHASE_DESC").ToString & "*"
                                sp.Tag = dt.Rows(i)
                                sp.CreateSeriesPointWithId(dt.Rows(i)("PHASE_DESC").ToString, i)
                                ser1.Points.Add(sp)
                                phase = dt.Rows(i)("TRAFFIC_PHASE_ID").ToString
                            End If
                        End If
                    End If
                    If IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) = False Then
                        If dt.Rows(i)("TASK_START_DATE") = dt.Rows(i)("JOB_REVISED_DATE") Then
                            enddate = CDate(dt.Rows(i)("JOB_REVISED_DATE")) '.AddHours(24)
                        Else
                            enddate = CDate(dt.Rows(i)("JOB_REVISED_DATE"))
                        End If
                        sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("SEQ_NBR").ToString, New DateTime() {dt.Rows(i)("TASK_START_DATE"), enddate})
                        sp.Argument = dt.Rows(i)("TASK_DESCRIPTION").ToString & "~" & dt.Rows(i)("SEQ_NBR").ToString
                        sp.Tag = dt.Rows(i)
                        sp.CreateSeriesPointWithId(dt.Rows(i)("SEQ_NBR").ToString, i)
                        ser1.Points.Add(sp)
                    End If
                Next

                WebChartControl1.Series.Add(ser1)
                'If dt.Rows.Count = 0 Then
                '    WebChartControl1.Height = Unit.Pixel(300)
                'Else
                '    If Me.RadToolbarButtonDay.Checked = True Then
                '        If dt.Rows.Count = 1 Then
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                '        ElseIf dt.Rows.Count <= 5 Then
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                '        Else
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 40)
                '        End If
                '    Else
                '        If dt.Rows.Count = 1 Then
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                '        ElseIf dt.Rows.Count <= 5 Then
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                '        Else
                '            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 40)
                '        End If
                '    End If
                'End If

                Dim pointCount As Integer = 0
                For j As Integer = 0 To Me.WebChartControl1.Series.Count - 1
                    If pointCount < Me.WebChartControl1.Series(j).Points.Count Then
                        pointCount = Me.WebChartControl1.Series(j).Points.Count
                    End If
                Next
                If pointCount = 0 Then
                    WebChartControl1.Height = Unit.Pixel(300)
                Else
                    If Me.RadToolbarButtonDay.Checked = True Then
                        If pointCount = 1 Then
                            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                        ElseIf pointCount <= 5 Then
                            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                        Else
                            WebChartControl1.Height = Unit.Pixel(pointCount * 40)
                        End If
                    Else
                        If pointCount = 1 Then
                            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                        ElseIf pointCount <= 5 Then
                            WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                        Else
                            WebChartControl1.Height = Unit.Pixel(pointCount * 40)
                        End If
                    End If
                End If

                Dim dtDates As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                If dtDates.Rows.Count > 0 Then
                    If IsDBNull(dtDates.Rows(0)("START_DATE")) = False Then
                        sd = cGlobals.wvCDate(dtDates.Rows(0)("START_DATE"))
                    End If
                    If IsDBNull(dtDates.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                        ed = cGlobals.wvCDate(dtDates.Rows(0)("JOB_FIRST_USE_DATE"))
                    End If
                    months = DateDiff(DateInterval.Month, sd, ed)
                    If months > 0 Then
                        WebChartControl1.Width = Unit.Pixel(months * 400)
                        If (months * 400) < 1200 Then
                            WebChartControl1.Width = Unit.Pixel(1200)
                        End If
                    Else
                        WebChartControl1.Width = Unit.Pixel(1200)
                    End If
                End If

                'WebChartControl1.Series.AddRange(New Series() {ser1, ser2})
                'Dim monthAxisY As New SecondaryAxisY()
                'Dim monthAxisX As New SecondaryAxisX()
                myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                If myDiagram.Panes.Count > 0 Then
                    Dim cnt As Integer = myDiagram.Panes.Count - 1
                    While cnt >= 0
                        myDiagram.Panes.RemoveAt(cnt)
                        cnt -= 1
                    End While
                End If

                myDiagram.SecondaryAxesY.Clear()
                myDiagram.SecondaryAxesX.Clear()
                If Me.RadToolbarButtonMonth.Checked = True Then
                    'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                    myDiagram.AxisY.Label.Angle = 0
                ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                    'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Week
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Week
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndDay
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.MinorCount = 6
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                    myDiagram.AxisY.Label.Angle = 0
                ElseIf Me.RadToolbarButtonDay.Checked = True Then
                    'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Day
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.Custom
                    myDiagram.AxisY.DateTimeOptions.FormatString = "MMM dd"
                    myDiagram.AxisY.Label.Angle = -90
                    myDiagram.AxisY.GridSpacingAuto = False
                    myDiagram.AxisY.GridSpacing = 3
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                    myDiagram.AxisY.MinorCount = 2
                Else
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                    myDiagram.AxisY.Label.Angle = 0
                End If
                'myDiagram.AxisX.Label.Font = New Font("Arial", 9)
                'myDiagram.EnableAxisXScrolling = True
                'myDiagram.EnableAxisYScrolling = True
                'myDiagram.AxisY.Range.MaxValueInternal = 2.0
                'myDiagram.AxisY.Range.MinValueInternal = 0.1
                'myDiagram.AxisY.Range.ScrollingRange.Auto = False
                'myDiagram.AxisY.Range.ScrollingRange.MaxValueInternal = 5.0
                'myDiagram.AxisY.Range.ScrollingRange.MinValueInternal = 0.1
                'myDiagram.ScrollingOptions.UseMouse = True
                'myDiagram.ScrollingOptions.UseScrollBars = True                

                'Dim progress As New ConstantLine("Current Date", Date.Now)
                'progress.ShowInLegend = False
                'progress.Title.Alignment = ConstantLineTitleAlignment.Near
                'progress.Title.ShowBelowLine = True
                'myDiagram.AxisY.ConstantLines.Add(progress)

            Else
                Dim myDiagram As GanttDiagram
                Dim view As DevExpress.XtraCharts.SideBySideGanttSeriesView
                Dim ct As Integer = 0
                Dim height As Integer
                Me.WebChartControl1.Series.Clear()

                ' myDiagram.SecondaryAxesX.Clear()
                Dim JC() As String
                If jobs <> "" Then
                    JC = jobs.ToString.Split("|")
                Else
                    JC = Session("TrafficScheduleMVJobs").ToString.Split("|")
                End If

                For i As Integer = 0 To JC.Length - 1
                    Dim j() As String = JC(i).Split(",")
                    If j(0) <> "" Then
                        Dim monthAxisX As New SecondaryAxisX()
                        Dim monthAxisY As New SecondaryAxisY()
                        monthAxisX.Alignment = AxisAlignment.Near
                        monthAxisY.Alignment = AxisAlignment.Far
                        If Me.RadToolbarButtonShowPhase.Checked Then
                            dt = oTrafficSchedule.GetScheduleTasks(j(0), j(1), "phase", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                        Else
                            dt = oTrafficSchedule.GetScheduleTasks(j(0), j(1), "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                        End If
                        Dim ser1 As New DevExpress.XtraCharts.Series(j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0"), ViewType.SideBySideGantt)
                        ser1.ValueScaleType = ScaleType.DateTime
                        If showlabels = True Then
                            ser1.Label.Visible = True
                            ser1.Label.LineVisible = True
                        Else
                            ser1.Label.Visible = False
                            ser1.Label.LineVisible = False
                        End If
                        ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                        Dim sp As DevExpress.XtraCharts.SeriesPoint
                        If dt.Rows.Count > 0 Then
                            For x As Integer = 0 To dt.Rows.Count - 1
                                If x = 0 Then
                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                        JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, j(0), j(1))
                                        If JobComp.StartDate Is Nothing And JobComp.DueDate Is Nothing Then
                                            sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {Now, Now})
                                        ElseIf JobComp.StartDate Is Nothing Then
                                            sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.DueDate, JobComp.DueDate})
                                        ElseIf JobComp.DueDate Is Nothing Then
                                            sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.StartDate, JobComp.StartDate})
                                        Else
                                            sp = New DevExpress.XtraCharts.SeriesPoint(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, New DateTime() {JobComp.StartDate, JobComp.DueDate})
                                        End If
                                        sp.Argument = JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description
                                        'sp.Tag = dt.Rows(x)
                                        sp.CreateSeriesPointWithId(JobComp.JobNumber.ToString.PadLeft(6, "0") & "-" & JobComp.Number.ToString.PadLeft(2, "0") & " " & JobComp.Description, x)
                                        ser1.Points.Add(sp)
                                    End Using
                                End If
                                If Me.RadToolbarButtonShowPhase.Checked Then
                                    If phase = 0 And IsDBNull(dt.Rows(x)("PHASE_START_DATE")) = False Then
                                        If IsDBNull(dt.Rows(x)("PHASE_END_DATE")) = False Then
                                            sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("PHASE_DESC").ToString, New DateTime() {dt.Rows(x)("PHASE_START_DATE"), dt.Rows(x)("PHASE_END_DATE")})
                                            sp.Argument = dt.Rows(x)("PHASE_DESC").ToString & "*"
                                            sp.Tag = dt.Rows(x)
                                            sp.CreateSeriesPointWithId(dt.Rows(x)("PHASE_DESC").ToString, x)
                                            ser1.Points.Add(sp)
                                            phase = dt.Rows(x)("TRAFFIC_PHASE_ID").ToString
                                        End If
                                    ElseIf phase <> dt.Rows(x)("TRAFFIC_PHASE_ID").ToString And IsDBNull(dt.Rows(x)("PHASE_START_DATE")) = False Then
                                        If IsDBNull(dt.Rows(x)("PHASE_END_DATE")) = False Then
                                            sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("PHASE_DESC").ToString, New DateTime() {dt.Rows(x)("PHASE_START_DATE"), dt.Rows(x)("PHASE_END_DATE")})
                                            sp.Argument = dt.Rows(x)("PHASE_DESC").ToString & "*"
                                            sp.Tag = dt.Rows(x)
                                            sp.CreateSeriesPointWithId(dt.Rows(x)("PHASE_DESC").ToString, x)
                                            ser1.Points.Add(sp)
                                            phase = dt.Rows(x)("TRAFFIC_PHASE_ID").ToString
                                        End If
                                    End If
                                End If
                                If IsDBNull(dt.Rows(x)("JOB_REVISED_DATE")) = False Then
                                    sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("SEQ_NBR").ToString, New DateTime() {dt.Rows(x)("TASK_START_DATE"), dt.Rows(x)("JOB_REVISED_DATE")})
                                    sp.Argument = dt.Rows(x)("TASK_DESCRIPTION").ToString & "~" & dt.Rows(x)("SEQ_NBR").ToString
                                    sp.Tag = dt.Rows(x)
                                    sp.CreateSeriesPointWithId(dt.Rows(x)("SEQ_NBR").ToString, x)
                                    ser1.Points.Add(sp)
                                End If
                            Next

                            If count >= 1 Then
                                WebChartControl1.Series.Add(ser1)
                                myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                                myDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & count))
                                myDiagram.Panes(count - 1).SizeMode = PaneSizeMode.UseSizeInPixels
                                If Me.RadToolbarButtonDay.Checked = True Then
                                    myDiagram.Panes(count - 1).SizeInPixels = ser1.Points.Count * 60
                                    height += ser1.Points.Count * 60
                                ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                                    myDiagram.Panes(count - 1).SizeInPixels = ser1.Points.Count * 50
                                    height += ser1.Points.Count * 50
                                Else
                                    myDiagram.Panes(count - 1).SizeInPixels = ser1.Points.Count * 40
                                    height += ser1.Points.Count * 40
                                End If
                                myDiagram.SecondaryAxesX.Add(monthAxisX)
                                view = CType(ser1.View, SideBySideGanttSeriesView)
                                view.Pane = myDiagram.Panes(count - 1)
                                monthAxisX.Reverse = True
                                view.AxisX = monthAxisX
                                'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                '    JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, j(0), j(1))
                                '    view.AxisX.Title.Text = j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0") & " " & JobComp.Description
                                '    view.AxisX.Title.Visible = True
                                '    view.AxisX.Title.Font = New Font("Ariel", 8, FontStyle.Bold)
                                'End Using
                                myDiagram.PaneDistance = 3
                            Else
                                WebChartControl1.Series.Add(ser1)
                                myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                                myDiagram.SecondaryAxesY.Clear()
                                myDiagram.SecondaryAxesX.Clear()
                                myDiagram.DefaultPane.SizeMode = PaneSizeMode.UseSizeInPixels
                                If Me.RadToolbarButtonDay.Checked = True Then
                                    myDiagram.DefaultPane.SizeInPixels = ser1.Points.Count * 60
                                    height += ser1.Points.Count * 60
                                ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                                    myDiagram.DefaultPane.SizeInPixels = ser1.Points.Count * 50
                                    height += ser1.Points.Count * 50
                                Else
                                    myDiagram.DefaultPane.SizeInPixels = ser1.Points.Count * 40
                                    height += ser1.Points.Count * 40
                                End If
                                'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                '    JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, j(0), j(1))
                                '    myDiagram.AxisX.Title.Text = j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0") & " " & JobComp.Description
                                '    myDiagram.AxisX.Title.Visible = True
                                '    myDiagram.AxisX.Title.Font = New Font("Ariel", 8, FontStyle.Bold)
                                'End Using
                                ct = myDiagram.Panes.Count
                            End If

                            If Me.RadToolbarButtonMonth.Checked = True Then
                                'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month
                                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                                myDiagram.AxisY.GridLines.MinorVisible = True
                                myDiagram.AxisY.GridLines.Visible = True
                                myDiagram.AxisY.Interlaced = True
                                myDiagram.AxisY.Alignment = AxisAlignment.Far
                                myDiagram.AxisY.Label.Angle = 0
                            ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                                'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Week
                                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Week
                                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndDay
                                myDiagram.AxisY.GridLines.MinorVisible = True
                                myDiagram.AxisY.GridLines.Visible = True
                                myDiagram.AxisY.MinorCount = 6
                                myDiagram.AxisY.Interlaced = True
                                myDiagram.AxisY.Alignment = AxisAlignment.Far
                                myDiagram.AxisY.Label.Angle = 0
                                myDiagram.AxisY.Label.Staggered = True
                            ElseIf Me.RadToolbarButtonDay.Checked = True Then
                                'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day
                                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Day
                                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.Custom
                                myDiagram.AxisY.DateTimeOptions.FormatString = "MMM dd"
                                myDiagram.AxisY.Label.Angle = -90
                                myDiagram.AxisY.GridSpacingAuto = False
                                myDiagram.AxisY.GridSpacing = 3
                                myDiagram.AxisY.GridLines.MinorVisible = True
                                myDiagram.AxisY.GridLines.Visible = True
                                myDiagram.AxisY.Interlaced = True
                                myDiagram.AxisY.Alignment = AxisAlignment.Far
                                myDiagram.AxisY.MinorCount = 2
                                'myDiagram.AxisY.Tickmarks.MinorVisible = False

                                ' myDiagram.AxisY.WorkdaysOnly = True
                            Else
                                myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                                myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                                myDiagram.AxisY.GridLines.MinorVisible = True
                                myDiagram.AxisY.GridLines.Visible = True
                                myDiagram.AxisY.Interlaced = True
                                myDiagram.AxisY.Alignment = AxisAlignment.Far
                            End If
                            'myDiagram.AxisX.Title.Text = "Tasks"

                            myDiagram.EnableAxisXScrolling = True
                            myDiagram.EnableAxisYScrolling = True
                            'myDiagram.AxisY.Label.Staggered = True

                            count += 1
                        End If
                    End If
                Next
                myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)

                Dim pointCount As Integer = 0
                For j As Integer = 0 To Me.WebChartControl1.Series.Count - 1
                    If pointCount < Me.WebChartControl1.Series(j).Points.Count Then
                        pointCount = Me.WebChartControl1.Series(j).Points.Count
                    End If
                Next
                If pointCount = 0 Then
                    WebChartControl1.Height = Unit.Pixel(300)
                Else
                    If myDiagram.Panes.Count = 0 Then
                        If Me.RadToolbarButtonDay.Checked = True Then
                            If pointCount = 1 Then
                                WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                            ElseIf pointCount <= 5 Then
                                WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                            Else
                                WebChartControl1.Height = Unit.Pixel(pointCount * 40)
                            End If
                        Else
                            If pointCount = 1 Then
                                WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 100)
                            ElseIf pointCount <= 5 Then
                                WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 60)
                            Else
                                WebChartControl1.Height = Unit.Pixel(pointCount * 40)
                            End If
                        End If
                    Else
                        WebChartControl1.Height = Unit.Pixel(height)
                    End If
                End If


                For i As Integer = 0 To JC.Length - 1
                    Dim strJC() As String = JC(i).Split(",")
                    If strJC(0) <> "" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, strJC(0), strJC(1))
                            If sd <> Nothing Then
                                If sd > JobComp.StartDate Then
                                    If Not JobComp.StartDate Is Nothing Then
                                        sd = JobComp.StartDate
                                    End If
                                End If
                            Else
                                If Not JobComp.StartDate Is Nothing Then
                                    sd = JobComp.StartDate
                                End If
                            End If
                            If ed <> Nothing Then
                                If ed < JobComp.DueDate Then
                                    If Not JobComp.DueDate Is Nothing Then
                                        ed = JobComp.DueDate
                                    End If
                                End If
                            Else
                                If Not JobComp.DueDate Is Nothing Then
                                    ed = JobComp.DueDate
                                End If
                            End If
                        End Using
                    End If
                Next
                If sd = Nothing Or ed = Nothing Then
                    months = 3
                Else
                    months = DateDiff(DateInterval.Month, sd, ed)
                End If
                If months > 0 Then
                    WebChartControl1.Width = Unit.Pixel(months * 400)
                    If (months * 400) < 1200 Then
                        WebChartControl1.Width = Unit.Pixel(1200)
                    End If
                Else
                    WebChartControl1.Width = Unit.Pixel(1200)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadChartPanesGantt(Optional ByVal showlabels As Boolean = False)
        Try
            Me.WebChartControl1.Series.Clear()
            Dim chartControl1 As DevExpress.XtraCharts.Web.WebChartControl
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As DataTable
            Dim sd As DateTime
            Dim ed As DateTime
            Dim months As Integer
            Dim count As Integer = 0
            If Request.QueryString("from") = "ps" Then
                dt = oTrafficSchedule.GetScheduleTasks(Me.JobNumber, Me.JobComponentNbr, "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                Dim ser1 As New DevExpress.XtraCharts.Series(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(2, "0"), ViewType.Gantt)
                ser1.ValueScaleType = ScaleType.DateTime
                If showlabels = True Then
                    ser1.Label.Visible = True
                    ser1.Label.LineVisible = True
                Else
                    ser1.Label.Visible = False
                    ser1.Label.LineVisible = False
                End If
                ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                Dim sp As DevExpress.XtraCharts.SeriesPoint
                For i As Integer = 0 To dt.Rows.Count - 1
                    sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(i)("SEQ_NBR").ToString, New DateTime() {dt.Rows(i)("TASK_START_DATE"), dt.Rows(i)("JOB_REVISED_DATE")})
                    sp.Argument = dt.Rows(i)("TASK_DESCRIPTION").ToString
                    sp.Tag = dt.Rows(i)
                    sp.CreateSeriesPointWithId(dt.Rows(i)("TASK_DESCRIPTION").ToString, i)
                    ser1.Points.Add(sp)
                Next
                Dim ser2 As New Series(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(2, "0"), ViewType.Gantt)
                ser2 = ser1
                WebChartControl1.Series.Add(ser1)
                If dt.Rows.Count = 0 Then
                    WebChartControl1.Height = Unit.Pixel(500)
                Else
                    WebChartControl1.Height = Unit.Pixel(dt.Rows.Count * 50)
                End If
                Dim dtDates As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                If dtDates.Rows.Count > 0 Then
                    If IsDBNull(dtDates.Rows(0)("START_DATE")) = False Then
                        sd = cGlobals.wvCDate(dtDates.Rows(0)("START_DATE"))
                    End If
                    If IsDBNull(dtDates.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                        ed = cGlobals.wvCDate(dtDates.Rows(0)("JOB_FIRST_USE_DATE"))
                    End If
                    months = DateDiff(DateInterval.Month, sd, ed)
                    If months > 0 Then
                        WebChartControl1.Width = Unit.Pixel(months * 500)
                    Else
                        WebChartControl1.Width = Unit.Pixel(1000)
                    End If
                End If

                'WebChartControl1.Series.AddRange(New Series() {ser1, ser2})
                Dim monthAxisY As New SecondaryAxisY()
                Dim monthAxisX As New SecondaryAxisX()
                Dim myDiagram As GanttDiagram = CType(WebChartControl1.Diagram, GanttDiagram)

                myDiagram.SecondaryAxesY.Clear()
                myDiagram.SecondaryAxesX.Clear()
                If Me.RadToolbarButtonMonth.Checked = True Then
                    'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                    'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Week
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Week
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndDay
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.MinorCount = 6
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                ElseIf Me.RadToolbarButtonDay.Checked = True Then
                    myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Day
                    'myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.Custom
                    'myDiagram.AxisY.DateTimeOptions.FormatString = "MMM dd"
                    myDiagram.AxisY.Label.Angle = -90
                    'myDiagram.AxisY.GridSpacingAuto = False
                    'myDiagram.AxisY.GridSpacing = 1
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                    myDiagram.AxisY.MinorCount = 2
                    'myDiagram.AxisY.Tickmarks.MinorVisible = False
                    'Secondary Y Axis 
                    'monthAxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Week
                    'monthAxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndDay
                    'monthAxisY.Alignment = AxisAlignment.Far
                    'monthAxisY.Tickmarks.MinorVisible = False '

                    'myDiagram.SecondaryAxesY.Add(monthAxisY)
                    'myDiagram.SecondaryAxesX.Add(monthAxisX)
                    'CType(ser1.View, GanttSeriesView).AxisX = monthAxisX
                    'CType(ser1.View, GanttSeriesView).AxisY = monthAxisY
                    ' myDiagram.AxisY.WorkdaysOnly = True
                Else
                    myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                    myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                    myDiagram.AxisY.GridLines.MinorVisible = True
                    myDiagram.AxisY.GridLines.Visible = True
                    myDiagram.AxisY.Interlaced = True
                    myDiagram.AxisY.Alignment = AxisAlignment.Far
                End If

                'myDiagram.EnableAxisXScrolling = True
                'myDiagram.EnableAxisYScrolling = True
                'myDiagram.AxisY.Range.MaxValueInternal = 2.0
                'myDiagram.AxisY.Range.MinValueInternal = 0.1
                'myDiagram.AxisY.Range.ScrollingRange.Auto = False
                'myDiagram.AxisY.Range.ScrollingRange.MaxValueInternal = 5.0
                'myDiagram.AxisY.Range.ScrollingRange.MinValueInternal = 0.1
                'myDiagram.ScrollingOptions.UseMouse = True
                'myDiagram.ScrollingOptions.UseScrollBars = True
                myDiagram.AxisX.Title.Text = "Tasks"

                Dim progress As New ConstantLine("Current Date", Date.Now)
                progress.ShowInLegend = False
                progress.Title.Alignment = ConstantLineTitleAlignment.Far
                myDiagram.AxisY.ConstantLines.Add(progress)

            Else
                Dim myDiagram As GanttDiagram
                Dim view As DevExpress.XtraCharts.SideBySideGanttSeriesView
                Dim ct As Integer = 0

                Me.WebChartControl1.Visible = False

                Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                For i As Integer = 0 To JC.Length - 1
                    Dim j() As String = JC(i).Split(",")
                    If j(0) <> "" Then
                        chartControl1 = New DevExpress.XtraCharts.Web.WebChartControl()
                        dt = oTrafficSchedule.GetScheduleTasks(j(0), j(1), "", CStr(Session("UserCode")), "", "", "", True, False, False, "", "", True)
                        Dim ser1 As New DevExpress.XtraCharts.Series(j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0"), ViewType.Gantt)
                        ser1.ValueScaleType = ScaleType.DateTime
                        If showlabels = True Then
                            ser1.Label.Visible = True
                            ser1.Label.LineVisible = True
                        Else
                            ser1.Label.Visible = False
                            ser1.Label.LineVisible = False
                        End If
                        ser1.PointOptions.ValueDateTimeOptions.Format = DateTimeFormat.ShortDate
                        Dim sp As DevExpress.XtraCharts.SeriesPoint
                        For x As Integer = 0 To dt.Rows.Count - 1
                            sp = New DevExpress.XtraCharts.SeriesPoint(dt.Rows(x)("SEQ_NBR").ToString, New DateTime() {dt.Rows(x)("TASK_START_DATE"), dt.Rows(x)("JOB_REVISED_DATE")})
                            sp.Argument = dt.Rows(x)("TASK_DESCRIPTION").ToString
                            sp.Tag = dt.Rows(x)
                            sp.CreateSeriesPointWithId(dt.Rows(x)("TASK_DESCRIPTION").ToString, x)
                            ser1.Points.Add(sp)
                        Next
                        chartControl1.Series.Add(ser1)
                        'chartControl1.Width = Unit.Pixel(1000)
                        'chartControl1.Height = Unit.Pixel(500)
                        Me.phGantt.Controls.Add(chartControl1)
                        If dt.Rows.Count = 0 Then
                            chartControl1.Height = Unit.Pixel(500)
                        Else
                            chartControl1.Height = Unit.Pixel(dt.Rows.Count * 50)
                        End If
                        Dim dtDates As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                        If dtDates.Rows.Count > 0 Then
                            If IsDBNull(dtDates.Rows(0)("START_DATE")) = False Then
                                sd = cGlobals.wvCDate(dtDates.Rows(0)("START_DATE"))
                            End If
                            If IsDBNull(dtDates.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                                ed = cGlobals.wvCDate(dtDates.Rows(0)("JOB_FIRST_USE_DATE"))
                            End If
                            months = DateDiff(DateInterval.Month, sd, ed)
                            If months > 0 Then
                                chartControl1.Width = Unit.Pixel(months * 500)
                            Else
                                chartControl1.Width = Unit.Pixel(1000)
                            End If
                        End If
                        myDiagram = CType(chartControl1.Diagram, GanttDiagram)
                        'If count >= 1 Then
                        '    WebChartControl1.Series.Add(ser1)
                        '    myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                        '    myDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & count))
                        '    view = CType(ser1.View, SideBySideGanttSeriesView)
                        '    view.Pane = myDiagram.Panes(count - 1)
                        '    myDiagram.PaneDistance = 3
                        'Else
                        '    WebChartControl1.Series.Add(ser1)
                        '    myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                        '    ct = myDiagram.Panes.Count
                        'End If

                        If Me.RadToolbarButtonMonth.Checked = True Then
                            'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month
                            myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                            myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                            myDiagram.AxisY.GridLines.MinorVisible = True
                            myDiagram.AxisY.GridLines.Visible = True
                            myDiagram.AxisY.Interlaced = True
                            myDiagram.AxisY.Alignment = AxisAlignment.Far
                        ElseIf Me.RadToolbarButtonWeek.Checked = True Then
                            'myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Week
                            myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Week
                            myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndDay
                            myDiagram.AxisY.GridLines.MinorVisible = True
                            myDiagram.AxisY.GridLines.Visible = True
                            myDiagram.AxisY.MinorCount = 6
                            myDiagram.AxisY.Interlaced = True
                            myDiagram.AxisY.Alignment = AxisAlignment.Far
                            myDiagram.AxisY.Label.Staggered = True
                        ElseIf Me.RadToolbarButtonDay.Checked = True Then
                            myDiagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day
                            myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Day
                            'myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.Custom
                            'myDiagram.AxisY.DateTimeOptions.FormatString = "MMM dd"
                            myDiagram.AxisY.Label.Angle = -90
                            'myDiagram.AxisY.GridSpacingAuto = False
                            'myDiagram.AxisY.GridSpacing = 1
                            myDiagram.AxisY.GridLines.MinorVisible = True
                            myDiagram.AxisY.GridLines.Visible = True
                            myDiagram.AxisY.Interlaced = True
                            myDiagram.AxisY.Alignment = AxisAlignment.Far
                            myDiagram.AxisY.MinorCount = 1
                            'myDiagram.AxisY.Tickmarks.MinorVisible = False

                            ' myDiagram.AxisY.WorkdaysOnly = True
                        Else
                            myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                            myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                            myDiagram.AxisY.GridLines.MinorVisible = True
                            myDiagram.AxisY.GridLines.Visible = True
                            myDiagram.AxisY.Interlaced = True
                            myDiagram.AxisY.Alignment = AxisAlignment.Far
                        End If
                        myDiagram.AxisX.Title.Text = "Tasks"

                        myDiagram.EnableAxisXScrolling = True
                        myDiagram.EnableAxisYScrolling = True
                        'myDiagram.AxisY.Label.Staggered = True

                        count += 1
                    End If
                Next
                'myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                'If Me.WebChartControl1.Series(0).Points.Count = 0 Then
                '    WebChartControl1.Height = Unit.Pixel(1000)
                'Else
                '    WebChartControl1.Height = Unit.Pixel(Me.WebChartControl1.Series(0).Points.Count * 35 * myDiagram.Panes.Count)
                'End If
                'Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
                'For i As Integer = 0 To JC.Length - 1
                '    Dim strJC() As String = JC(i).Split(",")
                '    If strJC(0) <> "" Then
                '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                '            JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, strJC(0), strJC(1))
                '            If sd <> Nothing Then
                '                If sd > JobComp.StartDate Then
                '                    sd = JobComp.StartDate
                '                End If
                '            Else
                '                sd = JobComp.StartDate
                '            End If
                '            If ed <> Nothing Then
                '                If ed < JobComp.DueDate Then
                '                    ed = JobComp.DueDate
                '                End If
                '            Else
                '                ed = JobComp.DueDate
                '            End If
                '        End Using
                '    End If
                'Next
                'months = DateDiff(DateInterval.Month, sd, ed)
                'If months > 0 Then
                '    WebChartControl1.Width = Unit.Pixel(months * 400)
                'Else
                '    WebChartControl1.Width = Unit.Pixel(1000)
                'End If
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckForPredecessors()
        Try
            Dim JobPred As AdvantageFramework.Database.Entities.JobTrafficPredecessors = Nothing
            Dim JobTrafficPreds As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If Request.QueryString("from") = "ps" Then
                    JobTrafficPreds = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Load(DbContext).ToList.Where(Function(JobTrafficPredecessors) JobTrafficPredecessors.JobPredecessor = Me.JobNumber And JobTrafficPredecessors.JobComponentPredecessor = Me.JobComponentNbr).ToList
                    If JobTrafficPreds.Count > 0 Then
                        Me.RadToolbarButtonCalculateDates.CommandName = "CalculateDates"
                    Else
                        Me.RadToolbarButtonCalculateDates.CommandName = "Calculate"
                    End If
                Else
                    Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                    For x As Integer = 0 To JC.Length - 1
                        Dim j() As String = JC(x).Split(",")
                        If j(0) <> "" Then
                            JobTrafficPreds = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Load(DbContext).ToList.Where(Function(JobTrafficPredecessors) JobTrafficPredecessors.JobPredecessor = j(0) And JobTrafficPredecessors.JobComponentPredecessor = j(1)).ToList
                            If JobTrafficPreds.Count > 0 Then
                                Me.RadToolbarButtonCalculateDates.CommandName = "CalculateDates"
                                Exit Sub
                            Else
                                Me.RadToolbarButtonCalculateDates.CommandName = "Calculate"
                            End If
                        End If
                    Next
                End If

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebChartControl1_CustomCallback1(sender As Object, e As DevExpress.XtraCharts.Web.CustomCallbackEventArgs) Handles WebChartControl1.CustomCallback
        Try
            Select Case e.Parameter
                Case "Palette"
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked)
                    If cbPalette IsNot Nothing Then
                        WebChartControl1.PaletteName = cbPalette.Text
                    End If
                Case "Appearance"
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked)
                    If cbAppearance IsNot Nothing Then
                        WebChartControl1.AppearanceName = cbAppearance.Text
                        If cbPalette IsNot Nothing Then
                            cbPalette.SelectedIndex = cbPalette.Items.IndexOfText(WebChartControl1.PaletteName)
                        End If
                    End If
                Case Else
                    Dim str() As String = e.Parameter.Split("|")
                    Dim sp As SeriesPoint
                    Dim i As Integer = 0
                    If str(0) = "EditPointCallbackCommand" Then
                        Dim StrEditURL As String = ""
                        Dim series As Series = WebChartControl1.GetSeriesByName(str(1))
                        Do While i < series.Points.Count
                            Dim point As SeriesPoint = series.Points(i)
                            If point.Argument = str(2) Then
                                Dim rowView As DataRow = CType(sp.Tag, DataRow)
                                Dim j As New Job(Session("ConnString"))
                                j.GetJob(rowView.Item("JOB_NUMBER"), rowView.Item("JOB_COMPONENT_NBR"))
                                ' Dim str As String = rowView.Item("SEQ_NBR").ToString
                                StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & rowView.Item("JOB_NUMBER").ToString & "&JobComp=" & rowView.Item("JOB_COMPONENT_NBR").ToString & "&SeqNum=" & rowView.Item("SEQ_NBR").ToString & "&Client=" & j.CL_CODE & "&Division=" & j.DIV_CODE & "&Product=" & j.PRD_CODE
                                Me.OpenWindow("", StrEditURL, 0, 0, False, True)
                            End If
                        Loop
                    End If
                    PerformCustomCallback(e)
                    'strJobs = GetRelatedJobs()
                    'LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
            End Select

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub WebChartControl1_ObjectSelected(sender As Object, e As DevExpress.XtraCharts.HotTrackEventArgs) Handles WebChartControl1.ObjectSelected
    '    Try
    '        Dim StrEditURL As String = ""
    '        Dim sp As SeriesPoint = e.AdditionalObject
    '        Dim rowView As DataRow = CType(sp.Tag, DataRow)
    '        Dim j As New Job(Session("ConnString"))
    '        j.GetJob(rowView.Item("JOB_NUMBER"), rowView.Item("JOB_COMPONENT_NBR"))
    '        Dim str As String = rowView.Item("SEQ_NBR").ToString
    '        StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & rowView.Item("JOB_NUMBER").ToString & "&JobComp=" & rowView.Item("JOB_COMPONENT_NBR").ToString & "&SeqNum=" & rowView.Item("SEQ_NBR").ToString & "&Client=" & j.CL_CODE & "&Division=" & j.DIV_CODE & "&Product=" & j.PRD_CODE
    '        Me.OpenWindow("", StrEditURL, 0, 0, False, True)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub WebChartControl2_ObjectSelected(sender As Object, e As DevExpress.XtraCharts.HotTrackEventArgs) Handles WebChartControl2.ObjectSelected
    '    Try
    '        Dim StrEditURL As String = ""
    '        Dim sp As SeriesPoint = e.AdditionalObject
    '        Dim rowView As DataRow = CType(sp.Tag, DataRow)
    '        Dim j As New Job(Session("ConnString"))
    '        j.GetJob(rowView.Item("JOB_NUMBER"), rowView.Item("JOB_COMPONENT_NBR"))
    '        Dim str As String = rowView.Item("SEQ_NBR").ToString
    '        StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & rowView.Item("JOB_NUMBER").ToString & "&JobComp=" & rowView.Item("JOB_COMPONENT_NBR").ToString & "&SeqNum=" & rowView.Item("SEQ_NBR").ToString & "&Client=" & j.CL_CODE & "&Division=" & j.DIV_CODE & "&Product=" & j.PRD_CODE
    '        Me.OpenWindow("", StrEditURL, 0, 0, False, True)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub PerformCustomCallback(ByVal e As CustomCallbackEventArgs)
        Try
            strJobs = GetRelatedJobs()
            LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
            Dim SQL As New System.Text.StringBuilder
            If e.Parameter = "Palette" OrElse e.Parameter = "Appearance" Then
                Return
            End If
            Dim parameters() As String = e.Parameter.Split(";")
            Dim seriesName As String = parameters(0)
            If seriesName.Contains("*") Then
                Return
            End If
            Dim argument As String = parameters(1)
            Dim valueIndex As Integer = Convert.ToInt32(parameters(1))
            Dim [date] As DateTime = Convert.ToDateTime(parameters(2), CultureInfo.InvariantCulture)
            Dim date2 As DateTime
            Dim series As Series
            Dim jc() As String
            If valueIndex = 2 Then
                date2 = Convert.ToDateTime(parameters(3), CultureInfo.InvariantCulture)
                series = WebChartControl1.GetSeriesByName(parameters(4))
                jc = parameters(4).Split("-")
            Else
                series = WebChartControl1.GetSeriesByName(parameters(3))
                jc = parameters(3).Split("-")
            End If

            If series Is Nothing Then

            End If
            Dim i As Integer = 0
            Dim jobdays As Integer
            Dim daysdiff As Integer = 0
            Dim wkenddays As Integer = 0
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            Do While i < series.Points.Count
                Dim point As SeriesPoint = series.Points(i)
                Dim rowView As DataRow = CType(point.Tag, DataRow)
                If point.Argument = seriesName Then
                    Dim values() As DateTime = CType(point.DateTimeValues.Clone(), DateTime())
                    Dim valuesOrig() As DateTime = CType(point.DateTimeValues, DateTime())
                    If valueIndex = 2 Then
                        values(0) = [date]
                        values(1) = date2
                    Else
                        values(valueIndex) = [date]
                    End If
                    Dim modifiedPoint As New SeriesPoint(point.Argument, values)
                    series.Points.RemoveAt(i)
                    series.Points.Insert(i, modifiedPoint)


                    oTask.Where.JOB_NUMBER.Value = CInt(jc(0))
                    oTask.Where.JOB_COMPONENT_NBR.Value = CInt(jc(1))
                    oTask.Where.SEQ_NBR.Value = rowView.Item("SEQ_NBR")

                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand()
                        If values(0) <> valuesOrig(0) And values(1) <> valuesOrig(1) Then
                            oTask.Query.Load()
                            daysdiff = values(1).Subtract(values(0)).Days
                            For j As Integer = 0 To daysdiff - 1
                                If values(0).AddDays(j).DayOfWeek = DayOfWeek.Sunday Then
                                    wkenddays += 1
                                End If
                                If values(0).AddDays(j).DayOfWeek = DayOfWeek.Saturday Then
                                    wkenddays += 1
                                End If
                            Next
                            jobdays = daysdiff - wkenddays
                            SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET TASK_START_DATE = '" & values(0).ToShortDateString & "', JOB_REVISED_DATE = '" & values(1).ToShortDateString & "', JOB_DAYS = " & jobdays)
                        ElseIf values(0) <> valuesOrig(0) Then
                            oTask.Query.Load()
                            If valuesOrig(0) = valuesOrig(1) Then
                                If valuesOrig(0) > values(0) Then
                                    daysdiff = valuesOrig(0).Subtract(values(0)).Days
                                    For j As Integer = 0 To daysdiff - 1
                                        If valuesOrig(0).AddDays(-j).DayOfWeek = DayOfWeek.Sunday Then
                                            wkenddays += 1
                                        End If
                                        If valuesOrig(0).AddDays(-j).DayOfWeek = DayOfWeek.Saturday Then
                                            wkenddays += 1
                                        End If
                                    Next
                                    jobdays = daysdiff - wkenddays
                                    SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET TASK_START_DATE = '" & values(0).ToShortDateString & "', JOB_DAYS = " & jobdays)
                                ElseIf valuesOrig(0) < values(0) Then
                                    daysdiff = values(0).Subtract(valuesOrig(0)).Days
                                    For j As Integer = 0 To daysdiff - 1
                                        If valuesOrig(0).AddDays(j).DayOfWeek = DayOfWeek.Sunday Then
                                            wkenddays += 1
                                        End If
                                        If valuesOrig(0).AddDays(j).DayOfWeek = DayOfWeek.Saturday Then
                                            wkenddays += 1
                                        End If
                                    Next
                                    jobdays = daysdiff - wkenddays
                                    SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET JOB_REVISED_DATE = '" & values(0).ToShortDateString & "', JOB_DAYS = " & jobdays)
                                End If
                            Else
                                daysdiff = valuesOrig(1).Subtract(values(0)).Days
                                For j As Integer = 0 To daysdiff - 1
                                    If values(0).AddDays(j).DayOfWeek = DayOfWeek.Sunday Then
                                        wkenddays += 1
                                    End If
                                    If values(0).AddDays(j).DayOfWeek = DayOfWeek.Saturday Then
                                        wkenddays += 1
                                    End If
                                Next
                                jobdays = daysdiff - wkenddays
                                SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET TASK_START_DATE = '" & values(0).ToShortDateString & "', JOB_DAYS = " & jobdays)
                            End If
                        ElseIf values(1) <> valuesOrig(1) Then
                            If valuesOrig(1) > values(1) Then
                                daysdiff = valuesOrig(1).Subtract(values(1)).Days
                                If oTask.Query.Load Then
                                    For j As Integer = 1 To daysdiff
                                        If valuesOrig(1).AddDays(-j).DayOfWeek = DayOfWeek.Sunday Then
                                            wkenddays += 1
                                        End If
                                        If valuesOrig(1).AddDays(-j).DayOfWeek = DayOfWeek.Saturday Then
                                            wkenddays += 1
                                        End If
                                    Next
                                    jobdays = oTask.JOB_DAYS - daysdiff + wkenddays
                                End If
                            ElseIf valuesOrig(1) < values(1) Then
                                daysdiff = values(1).Subtract(valuesOrig(1)).Days
                                If oTask.Query.Load Then
                                    For j As Integer = 0 To daysdiff - 1
                                        If valuesOrig(1).AddDays(j).DayOfWeek = DayOfWeek.Sunday Then
                                            wkenddays += 1
                                        End If
                                        If valuesOrig(1).AddDays(j).DayOfWeek = DayOfWeek.Saturday Then
                                            wkenddays += 1
                                        End If
                                    Next
                                    jobdays = oTask.JOB_DAYS + daysdiff - wkenddays
                                End If
                            End If
                            SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET JOB_REVISED_DATE = '" & values(1).ToShortDateString & "', JOB_DAYS = " & jobdays)
                        End If

                        SQL.Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;")

                        Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJOB_NUMBER.Value = CInt(jc(0))
                        MyCmd.Parameters.Add(pJOB_NUMBER)

                        Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        pJOB_COMPONENT_NBR.Value = CInt(jc(1))
                        MyCmd.Parameters.Add(pJOB_COMPONENT_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = rowView.Item("SEQ_NBR")
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
                        If access = 1 Then
                            If oTask.s_DUE_DATE_LOCK <> "" AndAlso oTask.DUE_DATE_LOCK = 1 Then
                                Me.ShowMessage("Task is locked and cannot be edited.")
                                Return
                            Else
                                Try
                                    With MyCmd
                                        .CommandText = SQL.ToString()
                                        .CommandType = CommandType.Text
                                        .Connection = MyConn
                                        .Transaction = MyTrans
                                        .ExecuteNonQuery()
                                    End With
                                    MyTrans.Commit()

                                Catch ex As Exception
                                    MyTrans.Rollback()
                                Finally
                                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                End Try
                            End If
                        Else
                            Me.ShowMessage("You do not have permission to edit tasks")
                            Return
                        End If


                    End Using
                    Return
                End If
                i += 1
            Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetGridColumnsToDisplay() As DataTable
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = s.GetScheduleColumns(Session("EmpCode"), False, False, False)
        Return dt
    End Function

    Private Function GetRelatedJobs()
        Try
            Dim sb As New System.Text.StringBuilder
            Dim strJobs As String
            Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim JobComp As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim row As DataRow
            Dim dtJobs As New DataTable
            Dim dv As DataView
            Dim ct As Integer = 0
            Dim colJob As DataColumn = New DataColumn("Job")
            Dim colComp As DataColumn = New DataColumn("Comp")
            Dim colsd As DataColumn = New DataColumn("START_DATE", System.Type.GetType("System.DateTime"))
            dtJobs.Columns.Add(colJob)
            dtJobs.Columns.Add(colComp)
            dtJobs.Columns.Add(colsd)
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                If Me.RadToolbarButtonShowJobs.Checked = True Then
                    If Request.QueryString("from") = "ps" Then
                        JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNbr)
                        row = dtJobs.NewRow
                        row.Item("Job") = JobNumber.ToString
                        row.Item("Comp") = JobComponentNbr.ToString
                        row.Item("START_DATE") = JobComp.StartDate
                        dtJobs.Rows.Add(row)
                        Do While ct < dtJobs.Rows.Count
                            JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).Include("JobTraffic").ToList
                            If JobPred.Count > 0 Then
                                For x As Integer = 0 To JobPred.Count - 1
                                    If ct >= 1 Then
                                        dv = dtJobs.DefaultView
                                        dv.RowFilter = "Job = '" & JobPred(x).JobNumber.ToString & "' AND Comp = '" & JobPred(x).JobComponentNumber.ToString & "'"
                                        If dv.Count = 0 Then
                                            row = dtJobs.NewRow
                                            row.Item("Job") = JobPred(x).JobNumber.ToString
                                            row.Item("Comp") = JobPred(x).JobComponentNumber.ToString
                                            row.Item("START_DATE") = JobPred(x).JobTraffic.JobComponent.StartDate
                                            dtJobs.Rows.Add(row)
                                        End If
                                    Else
                                        row = dtJobs.NewRow
                                        row.Item("Job") = JobPred(x).JobNumber.ToString
                                        row.Item("Comp") = JobPred(x).JobComponentNumber.ToString
                                        row.Item("START_DATE") = JobPred(x).JobTraffic.JobComponent.StartDate
                                        dtJobs.Rows.Add(row)
                                    End If
                                Next
                            End If
                            JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).ToList
                            If JobPred.Count > 0 Then
                                For x As Integer = 0 To JobPred.Count - 1
                                    If ct >= 1 Then
                                        dv = dtJobs.DefaultView
                                        dv.RowFilter = "Job = '" & JobPred(x).JobPredecessor.ToString & "' AND Comp = '" & JobPred(x).JobComponentPredecessor.ToString & "'"
                                        If dv.Count = 0 Then
                                            JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(x).JobPredecessor, JobPred(x).JobComponentPredecessor)
                                            row = dtJobs.NewRow
                                            row.Item("Job") = JobPred(x).JobPredecessor.ToString
                                            row.Item("Comp") = JobPred(x).JobComponentPredecessor.ToString
                                            row.Item("START_DATE") = JobComp.StartDate
                                            dtJobs.Rows.Add(row)
                                        End If
                                    Else
                                        row = dtJobs.NewRow
                                        JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(x).JobPredecessor, JobPred(x).JobComponentPredecessor)
                                        row.Item("Job") = JobPred(x).JobPredecessor.ToString
                                        row.Item("Comp") = JobPred(x).JobComponentPredecessor.ToString
                                        row.Item("START_DATE") = JobComp.StartDate
                                        dtJobs.Rows.Add(row)
                                    End If
                                Next
                            End If
                            ct += 1
                        Loop
                    Else
                        Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                        For x As Integer = 0 To JC.Length - 1
                            Dim j() As String = JC(x).Split(",")
                            If j(0) <> "" Then
                                JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, j(0), j(1))
                                row = dtJobs.NewRow
                                row.Item("Job") = j(0).ToString
                                row.Item("Comp") = j(1).ToString
                                row.Item("START_DATE") = JobComp.StartDate
                                dtJobs.Rows.Add(row)
                                Do While ct < dtJobs.Rows.Count
                                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).Include("JobTraffic").ToList
                                    If JobPred.Count > 0 Then
                                        For z As Integer = 0 To JobPred.Count - 1
                                            If ct >= 1 Then
                                                dv = dtJobs.DefaultView
                                                dv.RowFilter = "Job = '" & JobPred(z).JobNumber.ToString & "' AND Comp = '" & JobPred(z).JobComponentNumber.ToString & "'"
                                                If dv.Count = 0 Then
                                                    row = dtJobs.NewRow
                                                    row.Item("Job") = JobPred(z).JobNumber.ToString
                                                    row.Item("Comp") = JobPred(z).JobComponentNumber.ToString
                                                    row.Item("START_DATE") = JobPred(z).JobTraffic.JobComponent.StartDate
                                                    dtJobs.Rows.Add(row)
                                                End If
                                            Else
                                                row = dtJobs.NewRow
                                                row.Item("Job") = JobPred(z).JobNumber.ToString
                                                row.Item("Comp") = JobPred(z).JobComponentNumber.ToString
                                                row.Item("START_DATE") = JobPred(z).JobTraffic.JobComponent.StartDate
                                                dtJobs.Rows.Add(row)
                                            End If
                                        Next
                                    End If
                                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, dtJobs.Rows(ct)("Job"), dtJobs.Rows(ct)("Comp")).Include("JobTraffic").ToList
                                    If JobPred.Count > 0 Then
                                        For z As Integer = 0 To JobPred.Count - 1
                                            If ct >= 1 Then
                                                dv = dtJobs.DefaultView
                                                dv.RowFilter = "Job = '" & JobPred(z).JobPredecessor.ToString & "' AND Comp = '" & JobPred(z).JobComponentPredecessor.ToString & "'"
                                                If dv.Count = 0 Then
                                                    JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(z).JobPredecessor, JobPred(z).JobComponentPredecessor)
                                                    row = dtJobs.NewRow
                                                    row.Item("Job") = JobPred(z).JobPredecessor.ToString
                                                    row.Item("Comp") = JobPred(z).JobComponentPredecessor.ToString
                                                    row.Item("START_DATE") = JobComp.StartDate
                                                    dtJobs.Rows.Add(row)
                                                End If
                                            Else
                                                row = dtJobs.NewRow
                                                JobComp = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobPred(z).JobPredecessor, JobPred(z).JobComponentPredecessor)
                                                row.Item("Job") = JobPred(z).JobPredecessor.ToString
                                                row.Item("Comp") = JobPred(z).JobComponentPredecessor.ToString
                                                row.Item("START_DATE") = JobComp.StartDate
                                                dtJobs.Rows.Add(row)
                                            End If
                                        Next
                                    End If
                                    ct += 1
                                Loop
                            End If
                        Next
                    End If
                    Dim dv2 As DataView = Nothing
                    If dtJobs.Rows.Count > 0 Then
                        dtJobs.DefaultView.RowFilter = ""
                        dv2 = dtJobs.DefaultView
                        dv2.Sort = "START_DATE, Job, Comp"
                        dtJobs = dv2.ToTable
                        For i As Integer = 0 To dtJobs.Rows.Count - 1
                            With sb
                                .Append(dtJobs.Rows(i)("Job").ToString)
                                .Append(",")
                                .Append(dtJobs.Rows(i)("Comp").ToString)
                                .Append("|")
                            End With
                        Next
                    End If
                    strJobs = MiscFN.RemoveDuplicatesFromString(sb.ToString, "|", True)
                    Return strJobs
                Else
                    Return strJobs
                End If
            End Using

        Catch ex As Exception

        End Try
    End Function

    Private Sub RadToolbarGantt_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarGantt.ButtonClick
        Try
            Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim i As Integer = 0
            Dim str As String = ""
            Dim dt As DataTable = Me.GetGridColumnsToDisplay
            Dim pred As Integer = 0
            Dim dtHeader As DataTable
            Select Case e.Item.Value
                Case "CalculateDates"
                    If Request.QueryString("from") = "ps" Then
                        dtHeader = s.GetScheduleHeader(JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                        Dim BoolCalcByDueDate As Boolean = False
                        Dim CalcBy As Integer = 0 '1 is start, zero/null is due
                        If IsDBNull(dtHeader.Rows(0)("TRF_SCHEDULE_BY")) = False Then
                            CalcBy = CType(dtHeader.Rows(0)("TRF_SCHEDULE_BY"), Integer)
                            If CalcBy = 0 Then
                                BoolCalcByDueDate = True
                            Else
                                BoolCalcByDueDate = False
                            End If
                        Else
                            BoolCalcByDueDate = True
                        End If
                        If BoolCalcByDueDate = True Then
                            If IsDBNull(dtHeader.Rows(0)("JOB_FIRST_USE_DATE")) = True Then
                                Me.ShowMessage("Due date required.")
                                Exit Sub
                            End If
                        Else
                            If IsDBNull(dtHeader.Rows(0)("START_DATE")) = True Then
                                Me.ShowMessage("Start date required.")
                                Exit Sub
                            End If
                        End If
                        If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                            pred = 1
                        ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                            pred = 0
                        Else
                            For j As Integer = 0 To dt.Rows.Count - 1
                                If dt.Rows(j)("COLUMN_NAME") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(j)("SHOW_ON_GRID") = "True" Then
                                    pred = 1
                                End If
                            Next
                        End If
                        If pred = 1 Then
                            i = s.CalculateDueDatesPred(Me.JobNumber, Me.JobComponentNbr, 1)
                        Else
                            i = s.CalculateDueDates(Me.JobNumber, Me.JobComponentNbr, 0)
                        End If
                        Select Case i
                            Case -1
                                str = "Could not get start date."
                            Case -2
                                str = "Schedule is not feasible for calculation."
                        End Select
                        If i = -1 Or i = -2 Then
                            Me.ShowMessage(str)
                            Exit Sub
                        End If

                        Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, Me.JobNumber, Me.JobComponentNbr).ToList
                            If JobPred.Count > 0 Then
                                i = s.CalculateJobPreds(Me.JobNumber, Me.JobComponentNbr, 0, Session("EmpCode"))
                            End If
                        End Using

                    Else
                        Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
                        For x As Integer = 0 To JC.Length - 1
                            Dim j() As String = JC(x).Split(",")
                            If j(0) <> "" Then
                                dtHeader = s.GetScheduleHeader(j(0), j(1), Session("UserCode").ToString(), False).Tables(0)

                                If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                                    pred = 1
                                ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                                    pred = 0
                                Else
                                    For z As Integer = 0 To dt.Rows.Count - 1
                                        If dt.Rows(z)("COLUMN_NAME") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(z)("SHOW_ON_GRID") = "True" Then
                                            pred = 1
                                        End If
                                    Next
                                End If
                                If pred = 1 Then
                                    i = s.CalculateDueDatesPred(j(0), j(1), 1)
                                Else
                                    i = s.CalculateDueDates(j(0), j(1), 0)
                                End If
                                Select Case i
                                    Case -1
                                        str = "Could not get start date."
                                    Case -2
                                        str = "Schedule is not feasible for calculation."
                                End Select
                                If i = -1 Or i = -2 Then
                                    Me.ShowMessage(str)
                                    Exit Sub
                                End If

                                Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, j(0), j(1)).ToList
                                    If JobPred.Count > 0 Then
                                        i = s.CalculateJobPreds(j(0), j(1), 0, Session("EmpCode"))
                                    End If
                                End Using
                            End If
                        Next
                    End If
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
                Case "Month", "Week", "Day", "Refresh"
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
                Case "Phase"
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
                Case "Print"
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
                    Dim ps As New PrintingSystemBase()

                    Dim link3 As New PrintableComponentLinkBase(ps)
                    link3.Component = (CType(WebChartControl1, IChartContainer)).Chart
                    link3.CreateDocument(False)

                    Using stream As New MemoryStream()
                        link3.ExportToXlsx(stream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                        System.Web.HttpContext.Current.Response.Clear()

                        System.Web.HttpContext.Current.Response.Buffer = True
                        'System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                        'System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                        'System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=Gantt.xls")

                        System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                        System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=Gantt.xlsx")

                        System.Web.HttpContext.Current.Response.BinaryWrite(stream.ToArray)
                        HttpContext.Current.ApplicationInstance.CompleteRequest()

                        Try

                            System.Web.HttpContext.Current.Response.End()

                        Catch ex As Exception

                        End Try

                    End Using
                    ps.Dispose()

                    
                Case "ShowLabels"
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
                    If cbPalette IsNot Nothing Then
                        WebChartControl1.PaletteName = cbPalette.Text
                    End If
                    If cbAppearance IsNot Nothing Then
                        WebChartControl1.AppearanceName = cbAppearance.Text
                        If cbPalette IsNot Nothing Then
                            cbPalette.SelectedIndex = cbPalette.Items.IndexOfText(WebChartControl1.PaletteName)
                        End If
                    End If
                Case "ShowJobs"
                    strJobs = GetRelatedJobs()
                    LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebChartControl1_CustomDrawAxisLabel(sender As Object, e As DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs) Handles WebChartControl1.CustomDrawAxisLabel
        Try
            If e.Item.AxisValueInternal = 0.0 Or e.Item.AxisValue.ToString.Contains("*") Then
                e.Item.Font = New Font(e.Item.Font.ToString, e.Item.Font.Size, FontStyle.Bold)
            Else
                Dim str() As String = e.Item.Text.Split("~")
                e.Item.Text = str(0)
            End If
            If e.Item.AxisValue.ToString.Contains("*") Then
                e.Item.Text = e.Item.AxisValue.ToString.Replace("*", "")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebChartControl1_CustomDrawSeries(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesEventArgs) Handles WebChartControl1.CustomDrawSeries
        Try
           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebChartControl1_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs) Handles WebChartControl1.CustomDrawSeriesPoint
        Try
            If e.SeriesPoint.Argument.Contains(e.Series.Name) Then
                Dim drawOptions = CType(e.SeriesDrawOptions, GanttDrawOptions)
                drawOptions.FillStyle.FillMode = FillMode.Gradient
                Dim options = CType(drawOptions.FillStyle.Options, RectangleGradientFillOptions)
                'options.Color2 = Color.FromArgb(154, 196, 84)
                'drawOptions.Color = Color.FromArgb(81, 137, 3)
                'drawOptions.Border.Color = Color.FromArgb(100, 39, 91, 1)
                options.Color2 = Color.FromArgb(51, 51, 255)
                drawOptions.Color = Color.FromArgb(51, 51, 255)
                drawOptions.Border.Color = Color.FromArgb(51, 51, 255)
            End If
            If e.SeriesPoint.Argument.Contains("*") Then
                Dim drawOptions = CType(e.SeriesDrawOptions, GanttDrawOptions)
                drawOptions.FillStyle.FillMode = FillMode.Gradient
                Dim options = CType(drawOptions.FillStyle.Options, RectangleGradientFillOptions)
                'options.Color2 = Color.FromArgb(154, 196, 84)
                'drawOptions.Color = Color.FromArgb(81, 137, 3)
                'drawOptions.Border.Color = Color.FromArgb(100, 39, 91, 1)
                options.Color2 = Color.FromArgb(51, 153, 255)
                drawOptions.Color = Color.FromArgb(51, 153, 255)
                drawOptions.Border.Color = Color.FromArgb(51, 153, 255)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles ASPxCallbackPanel1.Callback
    '    Try
    '        Dim str As String = e.Parameter
    '        Me.ASPxLabel1.Text = e.Parameter
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Try
            'strJobs = GetRelatedJobs()
            'LoadChartPanes(Me.RadToolbarButtonShowLabels.Checked, strJobs)
        Catch ex As Exception

        End Try
    End Sub
End Class