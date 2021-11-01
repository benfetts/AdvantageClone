Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Web
Imports System.Globalization
Imports System.Data.SqlClient

Public Class TrafficSchedule_Gantt2
    Inherits Webvantage.BaseChildPage

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public SeqNbr As Integer = -1

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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DevExpress.Web.ASPxWebControl.RegisterBaseScript(Me.Page)
        Try
            If Me.IsPostBack = False Then

            Else
                Select Case Me.EventArgument
                    Case ""

                End Select
            End If
            'LoadChart()
            'LoadChartOneGraph()
            LoadChartPanes()
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
                AddHandler chartControl1.ObjectSelected, AddressOf chartObjectSelected
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
                        Dim ser1 As New DevExpress.XtraCharts.Series(j(0).ToString.PadLeft(6, "0") & "-" & j(1).ToString.PadLeft(2, "0"), ViewType.SideBySideGantt)
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

    Private Sub LoadChartPanes()
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
                Dim view As DevExpress.XtraCharts.SideBySideGanttSeriesView
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
                        If count >= 1 Then
                            WebChartControl1.Series.Add(ser1)
                            myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                            myDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & count))
                            view = CType(ser1.View, SideBySideGanttSeriesView)
                            view.Pane = myDiagram.Panes(count - 1)
                            myDiagram.PaneDistance = 3
                        Else
                            WebChartControl1.Series.Add(ser1)
                            myDiagram = CType(WebChartControl1.Diagram, GanttDiagram)
                        End If
                        myDiagram.AxisY.DateTimeGridAlignment = DateTimeMeasurementUnit.Month
                        myDiagram.AxisY.DateTimeOptions.Format = DateTimeFormat.MonthAndYear
                        myDiagram.AxisY.MinorCount = 4
                        myDiagram.AxisY.GridLines.MinorVisible = True
                        myDiagram.AxisY.GridLines.Visible = True
                        myDiagram.AxisY.Interlaced = True

                        myDiagram.AxisX.Title.Text = "Tasks"

                        count += 1
                    End If
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebChartControl1_CustomCallback1(sender As Object, e As DevExpress.XtraCharts.Web.CustomCallbackEventArgs) Handles WebChartControl1.CustomCallback
        Try
            'If HandleEditPointCallbackCommand(e.Parameter) Then
            '    Return
            'End If
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

    Private Sub chartObjectSelected(sender As Object, e As DevExpress.XtraCharts.HotTrackEventArgs)
        Try
            Dim StrEditURL As String = ""
            Dim sp As SeriesPoint = e.AdditionalObject
            Dim rowView As DataRow = CType(sp.Tag, DataRow)
            Dim j As New Job(Session("ConnString"))
            j.GetJob(rowView.Item("JOB_NUMBER"), rowView.Item("JOB_COMPONENT_NBR"))
            Dim str As String = rowView.Item("SEQ_NBR").ToString
            StrEditURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & rowView.Item("JOB_NUMBER").ToString & "&JobComp=" & rowView.Item("JOB_COMPONENT_NBR").ToString & "&SeqNum=" & rowView.Item("SEQ_NBR").ToString & "&Client=" & j.CL_CODE & "&Division=" & j.DIV_CODE & "&Product=" & j.PRD_CODE
            Me.OpenWindow("", StrEditURL, 0, 0, False, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PerformCustomCallback(ByVal e As CustomCallbackEventArgs)
        Try
            Dim SQL As New System.Text.StringBuilder
            If e.Parameter = "Palette" OrElse e.Parameter = "Appearance" Then
                Return
            End If
            Dim parameters() As String = e.Parameter.Split(";")
            Dim seriesName As String = parameters(0)
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
                Return
            End If
            Dim i As Integer = 0
            Do While i < series.Points.Count
                Dim point As SeriesPoint = series.Points(i)
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
                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Dim MyCmd As New SqlCommand()
                        If values(0) <> valuesOrig(0) And values(1) <> valuesOrig(1) Then
                            SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET TASK_START_DATE = '" & values(0).ToShortDateString & "', SET JOB_REVISED_DATE = '" & values(1).ToShortDateString & "'")
                        ElseIf values(0) <> valuesOrig(0) Then
                            SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET TASK_START_DATE = '" & values(0).ToShortDateString & "'")
                        ElseIf values(1) <> valuesOrig(1) Then
                            SQL.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET JOB_REVISED_DATE = '" & values(1).ToShortDateString & "'")
                        End If

                        SQL.Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;")

                        Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJOB_NUMBER.Value = CInt(jc(0))
                        MyCmd.Parameters.Add(pJOB_NUMBER)

                        Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        pJOB_COMPONENT_NBR.Value = CInt(jc(1))
                        MyCmd.Parameters.Add(pJOB_COMPONENT_NBR)

                        Dim rowView As DataRow = CType(point.Tag, DataRow)
                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = rowView.Item("SEQ_NBR")
                        MyCmd.Parameters.Add(pSEQ_NBR)

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
                    End Using
                    Return
                End If
                i += 1
            Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Function HandleEditPointCallbackCommand(ByVal p As String)
        Try
            Dim parameters() As String = p.Split("|")
            If parameters(0) <> "EditPointCallbackCommand" Then
                Return False
            End If

            Session("arg") = parameters(0)

            Me.WebChartControl1.JSProperties.Add("cpEditPointCallbackCommandHandled", True)
            Return True
        Catch ex As Exception

        End Try
    End Function


End Class