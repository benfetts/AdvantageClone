Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleGanttViewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobTrafficID As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobTrafficID As Integer
            Get
                JobTrafficID = _JobTrafficID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal JobTrafficID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _JobTrafficID = JobTrafficID

        End Sub
        Private Sub SetGanttDiagramProperties(ByVal GanttDiagram As DevExpress.XtraCharts.GanttDiagram)

            If GanttDiagram IsNot Nothing Then

                If ButtonItemOptions_Month.Checked = True Then

                    GanttDiagram.AxisY.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Month
                    GanttDiagram.AxisY.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndYear
                    GanttDiagram.AxisY.Label.DateTimeOptions.FormatString = ""
                    GanttDiagram.AxisY.GridLines.MinorVisible = True
                    GanttDiagram.AxisY.MinorCount = 2
                    GanttDiagram.AxisY.GridLines.Visible = True
                    GanttDiagram.AxisY.Interlaced = True
                    GanttDiagram.AxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far
                    GanttDiagram.AxisY.Label.Angle = 0
                    GanttDiagram.AxisY.GridSpacingAuto = True
                    GanttDiagram.AxisY.GridSpacing = 1

                ElseIf ButtonItemOptions_Week.Checked = True Then

                    GanttDiagram.AxisY.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Week
                    GanttDiagram.AxisY.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndDay
                    GanttDiagram.AxisY.Label.DateTimeOptions.FormatString = ""
                    GanttDiagram.AxisY.GridLines.MinorVisible = True
                    GanttDiagram.AxisY.MinorCount = 6
                    GanttDiagram.AxisY.GridLines.Visible = True
                    GanttDiagram.AxisY.Interlaced = True
                    GanttDiagram.AxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far
                    GanttDiagram.AxisY.Label.Angle = 0
                    GanttDiagram.AxisY.GridSpacingAuto = True
                    GanttDiagram.AxisY.GridSpacing = 1

                ElseIf ButtonItemOptions_Day.Checked = True Then

                    GanttDiagram.AxisY.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Day
                    GanttDiagram.AxisY.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.Custom
                    GanttDiagram.AxisY.Label.DateTimeOptions.FormatString = "MMM dd"
                    GanttDiagram.AxisY.GridLines.MinorVisible = True
                    GanttDiagram.AxisY.MinorCount = 2
                    GanttDiagram.AxisY.GridLines.Visible = True
                    GanttDiagram.AxisY.Interlaced = True
                    GanttDiagram.AxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far
                    GanttDiagram.AxisY.Label.Angle = -90
                    GanttDiagram.AxisY.GridSpacingAuto = False
                    GanttDiagram.AxisY.GridSpacing = 3

                Else

                    GanttDiagram.AxisY.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Month
                    GanttDiagram.AxisY.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndYear
                    GanttDiagram.AxisY.Label.DateTimeOptions.FormatString = ""
                    GanttDiagram.AxisY.GridLines.MinorVisible = True
                    GanttDiagram.AxisY.MinorCount = 2
                    GanttDiagram.AxisY.GridLines.Visible = True
                    GanttDiagram.AxisY.Interlaced = True
                    GanttDiagram.AxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far
                    GanttDiagram.AxisY.Label.Angle = 0
                    GanttDiagram.AxisY.GridSpacingAuto = True
                    GanttDiagram.AxisY.GridSpacing = 1

                End If

            End If

        End Sub
        Private Sub CreateSeries(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            'objects
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Series As DevExpress.XtraCharts.Series = Nothing
            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing
            Dim GanttDiagram As DevExpress.XtraCharts.GanttDiagram = Nothing
            Dim SideBySideGanttSeriesView As DevExpress.XtraCharts.SideBySideGanttSeriesView = Nothing
            Dim XYDiagramPane As DevExpress.XtraCharts.XYDiagramPane = Nothing
            Dim SecondaryAxisY As DevExpress.XtraCharts.SecondaryAxisY = Nothing
            Dim SecondaryAxisX As DevExpress.XtraCharts.SecondaryAxisX = Nothing


            Dim PhaseID As Integer = 0

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If CheckBoxItemOptions_Phase.Checked Then

                    ScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(ObjectContext, JobNumber, JobComponentNumber, "phase", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).OrderBy(Function(Task) Task.JobOrder).ToList

                Else

                    ScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(ObjectContext, JobNumber, JobComponentNumber, "", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).OrderBy(Function(Task) Task.JobOrder).ToList

                End If

                If ScheduleTasks IsNot Nothing AndAlso ScheduleTasks.Count > 0 Then

                    Series = New DevExpress.XtraCharts.Series(AdvantageFramework.StringUtilities.PadWithCharacter(JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber.ToString, 2, "0", True), DevExpress.XtraCharts.ViewType.SideBySideGantt)

                    Series.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime
                    Series.LegendPointOptions.ValueDateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.ShortDate

                    If CheckBoxItemOptions_Labels.Checked Then

                        Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
                        Series.Label.LineVisible = True

                    Else

                        Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                        Series.Label.LineVisible = False

                    End If

                    For Counter = 0 To ScheduleTasks.Count - 1

                        ScheduleTask = ScheduleTasks(Counter)

                        If Counter = 0 Then

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(ObjectContext, JobNumber, JobComponentNumber)

                            SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.Number.ToString, 2, "0", True) & " " & JobComponent.Description, New DateTime() {JobComponent.StartDate, JobComponent.DueDate})

                            SeriesPoint.Argument = AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponent.Number.ToString, 2, "0", True) & " " & JobComponent.Description

                            Series.Points.Add(SeriesPoint)

                        End If

                        If CheckBoxItemOptions_Phase.Checked Then

                            If ScheduleTask.PhaseStartDate.HasValue = True AndAlso _
                               (PhaseID = 0 OrElse (PhaseID <> ScheduleTask.TrafficPhaseID AndAlso PhaseID <> 0)) Then

                                SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(ScheduleTask.PhaseDescription, New DateTime() {ScheduleTask.PhaseStartDate, ScheduleTask.PhaseEndDate})

                                SeriesPoint.Argument = ScheduleTask.PhaseDescription & "*"
                                SeriesPoint.Tag = ScheduleTask
                                Series.Points.Add(SeriesPoint)

                                PhaseID = ScheduleTask.TrafficPhaseID

                            End If

                        End If

                        SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(ScheduleTask.SequenceNumber, New DateTime() {ScheduleTask.TaskStartDate, ScheduleTask.JobRevisedDate})

                        SeriesPoint.Argument = ScheduleTask.TaskDescription & " ~ " & ScheduleTask.SequenceNumber.ToString
                        SeriesPoint.Tag = ScheduleTask

                        Series.Points.Add(SeriesPoint)

                    Next

                    ChartControlForm_Gantt.Series.Add(Series)
                    GanttDiagram = CType(ChartControlForm_Gantt.Diagram, DevExpress.XtraCharts.GanttDiagram)

                    If ChartControlForm_Gantt.Series.Count > 1 Then

                        SecondaryAxisY = New DevExpress.XtraCharts.SecondaryAxisY
                        SecondaryAxisX = New DevExpress.XtraCharts.SecondaryAxisX

                        SecondaryAxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far
                        SecondaryAxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Near

                        XYDiagramPane = New DevExpress.XtraCharts.XYDiagramPane("Pane " & ChartControlForm_Gantt.Series.Count.ToString)
                        GanttDiagram.Panes.Add(XYDiagramPane)
                        XYDiagramPane.SizeMode = DevExpress.XtraCharts.PaneSizeMode.UseSizeInPixels

                        'If ButtonItemOptions_Day.Checked = True Then

                        '    XYDiagramPane.SizeInPixels = Series.Points.Count * 40

                        'Else


                        'End If

                        GanttDiagram.SecondaryAxesX.Add(SecondaryAxisX)
                        SideBySideGanttSeriesView = CType(Series.View, DevExpress.XtraCharts.SideBySideGanttSeriesView)
                        SideBySideGanttSeriesView.Pane = XYDiagramPane
                        SecondaryAxisX.Reverse = True
                        SideBySideGanttSeriesView.AxisX = SecondaryAxisX
                        GanttDiagram.PaneDistance = 3

                    Else

                        GanttDiagram.SecondaryAxesY.Clear()
                        GanttDiagram.SecondaryAxesX.Clear()
                        GanttDiagram.DefaultPane.SizeMode = DevExpress.XtraCharts.PaneSizeMode.UseSizeInPixels

                        'If ButtonItemOptions_Day.Checked = True Then

                        '    GanttDiagram.DefaultPane.SizeInPixels = Series.Points.Count * 40

                        'Else


                        'End If

                    End If

                    SetGanttDiagramProperties(GanttDiagram)

                    GanttDiagram.AxisY.MinorCount = 4
                    GanttDiagram.AxisY.GridLines.MinorVisible = True
                    GanttDiagram.AxisY.GridLines.Visible = True
                    GanttDiagram.AxisY.Interlaced = True
                    'GanttDiagram.AxisX.Title.Text = "Tasks"
                    GanttDiagram.EnableAxisXScrolling = True
                    GanttDiagram.EnableAxisYScrolling = True

                End If

            End Using

        End Sub
        Private Sub LoadChart()

            If CheckBoxItemOptions_RelatedJobs.Checked Then

                LoadMultipleSeries()

            Else

                LoadSingleSeries()

            End If

        End Sub
        Private Sub LoadMultipleSeries()

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim Series As DevExpress.XtraCharts.Series = Nothing
            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing
            Dim GanttDiagram As DevExpress.XtraCharts.GanttDiagram = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim PhaseID As Integer = 0
            Dim JobComponents As Generic.List(Of String) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim SecondaryAxisX As DevExpress.XtraCharts.SecondaryAxisX = Nothing
            Dim SecondaryAxisY As DevExpress.XtraCharts.SecondaryAxisY = Nothing
            Dim SideBySideGanttSeriesView As DevExpress.XtraCharts.SideBySideGanttSeriesView = Nothing
            Dim Count As Integer = 0

            ChartControlForm_Gantt.Series.Clear()

            If ChartControlForm_Gantt.Legend IsNot Nothing Then

                ChartControlForm_Gantt.Legend.Visible = False

            End If

            If ChartControlForm_Gantt.Diagram IsNot Nothing Then

                GanttDiagram = CType(ChartControlForm_Gantt.Diagram, DevExpress.XtraCharts.GanttDiagram)

                GanttDiagram.Panes.Clear()
                GanttDiagram.SecondaryAxesX.Clear()
                GanttDiagram.SecondaryAxesY.Clear()

            End If

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(ObjectContext, _JobTrafficID)

                If JobTraffic IsNot Nothing Then

                    JobComponents = New Generic.List(Of String)

                    JobComponents.Add(JobTraffic.JobNumber.ToString & "," & JobTraffic.JobComponentNumber.ToString)

                    For Each JobTrafficPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(ObjectContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                        JobComponents.Add(JobTrafficPredecessor.JobPredecessor.ToString & "," & JobTrafficPredecessor.JobComponentPredecessor.ToString)

                    Next

                    For I = 0 To JobComponents.Count - 1

                        JobNumber = CInt(JobComponents(I).Split(",").FirstOrDefault)
                        JobComponentNumber = CInt(JobComponents(I).Split(",").Last)

                        SecondaryAxisX = New DevExpress.XtraCharts.SecondaryAxisX
                        SecondaryAxisY = New DevExpress.XtraCharts.SecondaryAxisY

                        SecondaryAxisX.Alignment = DevExpress.XtraCharts.AxisAlignment.Near
                        SecondaryAxisY.Alignment = DevExpress.XtraCharts.AxisAlignment.Far

                        ScheduleTasks = LoadScheduleTasks(JobNumber, JobComponentNumber)

                        Series = CreateSeriesFromJobComponent(JobNumber, JobComponentNumber)

                        For Counter = 0 To ScheduleTasks.Count - 1

                            ScheduleTask = ScheduleTasks(Counter)

                            If Counter = 0 Then

                                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(ObjectContext, JobNumber, JobComponentNumber)

                                SeriesPoint = CreateSeriesPointFromJobComponent(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description, JobComponent.StartDate, JobComponent.DueDate)

                                Series.Points.Add(SeriesPoint)

                            End If

                            If CheckBoxItemOptions_Phase.Checked Then

                                If ScheduleTask.PhaseStartDate.HasValue Then

                                    If PhaseID = 0 Then

                                        SeriesPoint = CreatePhaseSeriesPoint(ScheduleTask)

                                    ElseIf PhaseID <> ScheduleTask.TrafficPhaseID Then

                                        SeriesPoint = CreatePhaseSeriesPoint(ScheduleTask)

                                    End If

                                    If SeriesPoint IsNot Nothing Then

                                        Series.Points.Add(SeriesPoint)

                                        PhaseID = ScheduleTask.TrafficPhaseID

                                    End If

                                End If

                            End If

                            SeriesPoint = CreateSeriesPointFromTask(ScheduleTask)

                            Series.Points.Add(SeriesPoint)

                        Next

                        If Count >= 1 Then

                            ChartControlForm_Gantt.Series.Add(Series)
                            GanttDiagram = CType(ChartControlForm_Gantt.Diagram, DevExpress.XtraCharts.GanttDiagram)
                            GanttDiagram.Panes.Add(New DevExpress.XtraCharts.XYDiagramPane("Pane " & Count))
                            GanttDiagram.Panes(Count - 1).SizeMode = DevExpress.XtraCharts.PaneSizeMode.UseSizeInPixels

                            If ButtonItemOptions_Day.Checked Then

                                GanttDiagram.Panes(Count - 1).SizeInPixels = Series.Points.Count * 40
                                'height += Series.Points.Count * 40

                            Else

                                GanttDiagram.Panes(Count - 1).SizeInPixels = Series.Points.Count * 30
                                'height += Series.Points.Count * 30

                            End If

                            GanttDiagram.SecondaryAxesX.Add(SecondaryAxisX)
                            SideBySideGanttSeriesView = CType(Series.View, DevExpress.XtraCharts.SideBySideGanttSeriesView)
                            SideBySideGanttSeriesView.Pane = GanttDiagram.Panes(Count - 1)
                            SecondaryAxisX.Reverse = True
                            SideBySideGanttSeriesView.AxisX = SecondaryAxisX
                            GanttDiagram.PaneDistance = 3

                        Else

                            ChartControlForm_Gantt.Series.Add(Series)
                            GanttDiagram = CType(ChartControlForm_Gantt.Diagram, DevExpress.XtraCharts.GanttDiagram)
                            GanttDiagram.Panes.Clear()
                            GanttDiagram.SecondaryAxesY.Clear()
                            GanttDiagram.SecondaryAxesX.Clear()
                            GanttDiagram.DefaultPane.SizeMode = DevExpress.XtraCharts.PaneSizeMode.UseSizeInPixels

                            If ButtonItemOptions_Day.Checked = True Then

                                GanttDiagram.DefaultPane.SizeInPixels = Series.Points.Count * 40
                                'Height += Series.Points.Count * 40

                            Else

                                GanttDiagram.DefaultPane.SizeInPixels = Series.Points.Count * 40
                                'Height += Series.Points.Count * 40

                            End If

                        End If

                        SetGanttDiagramProperties(GanttDiagram)

                        GanttDiagram.EnableAxisXScrolling = True
                        GanttDiagram.EnableAxisYScrolling = True

                        Count = Count + 1

                    Next

                End If

            End Using

        End Sub
        Private Sub LoadSingleSeries()

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim Series As DevExpress.XtraCharts.Series = Nothing
            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing
            Dim GanttDiagram As DevExpress.XtraCharts.GanttDiagram = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim PhaseID As Integer = 0

            ChartControlForm_Gantt.Series.Clear()

            If ChartControlForm_Gantt.Legend IsNot Nothing Then

                ChartControlForm_Gantt.Legend.Visible = False

            End If

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(ObjectContext, _JobTrafficID)

                If JobTraffic IsNot Nothing Then

                    ScheduleTasks = LoadScheduleTasks(JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                    Series = CreateSeriesFromJobComponent(JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                    For Counter = 0 To ScheduleTasks.Count - 1

                        ScheduleTask = ScheduleTasks(Counter)

                        If Counter = 0 Then

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(ObjectContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                            SeriesPoint = CreateSeriesPointFromJobComponent(JobComponent.JobNumber, JobComponent.Number, JobComponent.Description, JobComponent.StartDate, JobComponent.DueDate)

                            Series.Points.Add(SeriesPoint)

                        End If

                        If CheckBoxItemOptions_Phase.Checked Then

                            If ScheduleTask.PhaseStartDate.HasValue Then

                                If PhaseID = 0 Then

                                    SeriesPoint = CreatePhaseSeriesPoint(ScheduleTask)

                                ElseIf PhaseID <> ScheduleTask.TrafficPhaseID Then

                                    SeriesPoint = CreatePhaseSeriesPoint(ScheduleTask)

                                End If

                                If SeriesPoint IsNot Nothing Then

                                    Series.Points.Add(SeriesPoint)

                                    PhaseID = ScheduleTask.TrafficPhaseID

                                End If

                            End If

                        End If

                        SeriesPoint = CreateSeriesPointFromTask(ScheduleTask)

                        Series.Points.Add(SeriesPoint)

                    Next

                    ChartControlForm_Gantt.Series.Add(Series)

                    GanttDiagram = CType(ChartControlForm_Gantt.Diagram, DevExpress.XtraCharts.GanttDiagram)

                    If GanttDiagram.Panes.Count > 0 Then

                        GanttDiagram.Panes.Clear()

                    End If

                    GanttDiagram.SecondaryAxesY.Clear()
                    GanttDiagram.SecondaryAxesX.Clear()

                    SetGanttDiagramProperties(GanttDiagram)

                End If

            End Using

        End Sub
        Private Function CreateSeriesPointFromTask(ByVal ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) As DevExpress.XtraCharts.SeriesPoint

            'objects
            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing

            Try

                SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(ScheduleTask.SequenceNumber, New DateTime() {ScheduleTask.TaskStartDate, ScheduleTask.JobRevisedDate})

                SeriesPoint.Argument = ScheduleTask.TaskDescription & "~" & ScheduleTask.SequenceNumber.ToString
                SeriesPoint.Tag = ScheduleTask

            Catch ex As Exception
                SeriesPoint = Nothing
            Finally
                CreateSeriesPointFromTask = SeriesPoint
            End Try

        End Function
        Private Function CreateSeriesFromJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As DevExpress.XtraCharts.Series

            Dim Series As DevExpress.XtraCharts.Series = Nothing

            Try

                Series = New DevExpress.XtraCharts.Series(AdvantageFramework.StringUtilities.PadWithCharacter(JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber.ToString, 2, "0", True), DevExpress.XtraCharts.ViewType.SideBySideGantt)

                Series.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime

                If CheckBoxItemOptions_Labels.Checked Then

                    Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
                    Series.Label.LineVisible = True

                Else

                    Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                    Series.Label.LineVisible = False

                End If

                Series.LegendPointOptions.ValueDateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.ShortDate

            Catch ex As Exception
                Series = Nothing
            Finally
                CreateSeriesFromJobComponent = Series
            End Try

        End Function
        Private Function CreateSeriesPointFromJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal JobComponentDescription As String, ByVal StartDate As Date, ByVal DueDate As Date) As DevExpress.XtraCharts.SeriesPoint

            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing

            Try

                SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(AdvantageFramework.StringUtilities.PadWithCharacter(JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber.ToString, 2, "0", True) & " " & JobComponentDescription, New DateTime() {StartDate, DueDate})

                SeriesPoint.Argument = AdvantageFramework.StringUtilities.PadWithCharacter(JobNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber.ToString, 2, "0", True) & " " & JobComponentDescription

            Catch ex As Exception
                SeriesPoint = Nothing
            Finally
                CreateSeriesPointFromJobComponent = SeriesPoint
            End Try

        End Function
        Private Function CreatePhaseSeriesPoint(ByVal ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) As DevExpress.XtraCharts.SeriesPoint

            'objects
            Dim SeriesPoint As DevExpress.XtraCharts.SeriesPoint = Nothing

            Try

                SeriesPoint = New DevExpress.XtraCharts.SeriesPoint(ScheduleTask.PhaseDescription, New DateTime() {ScheduleTask.PhaseStartDate, ScheduleTask.PhaseEndDate})

                SeriesPoint.Argument = ScheduleTask.PhaseDescription & "*"

                SeriesPoint.Tag = ScheduleTask

            Catch ex As Exception
                SeriesPoint = Nothing
            Finally
                CreatePhaseSeriesPoint = SeriesPoint
            End Try

        End Function
        Private Function LoadScheduleTasks(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As IEnumerable(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If CheckBoxItemOptions_Phase.Checked Then

                    LoadScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(ObjectContext, JobNumber, JobComponentNumber, "phase", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).OrderBy(Function(Task) Task.JobOrder).ToList

                Else

                    LoadScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(ObjectContext, JobNumber, JobComponentNumber, "", Me.Session.UserCode, "", "", "", True, False, False, "", "", True).OrderBy(Function(Task) Task.JobOrder).ToList

                End If

            End Using

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobTrafficID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleGanttViewDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleGanttViewDialog = Nothing

            ProjectScheduleGanttViewDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleGanttViewDialog(JobTrafficID)

            ShowFormDialog = ProjectScheduleGanttViewDialog.ShowDialog()

            JobTrafficID = ProjectScheduleGanttViewDialog.JobTrafficID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleGanttViewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            ButtonItemOptions_Day.Image = AdvantageFramework.My.Resources.CalendarDayImage
            ButtonItemOptions_Month.Image = AdvantageFramework.My.Resources.CalendarImage
            ButtonItemOptions_Week.Image = AdvantageFramework.My.Resources.CalendarWeekImage
            ButtonItemOptions_Calculate.Image = AdvantageFramework.My.Resources.PercentageImage

            If _JobTrafficID > 0 Then

                LoadChart()

            Else

                Loaded = False

            End If

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading the project schedule.")
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ChartControlForm_Gantt_CustomDrawAxisLabel(sender As Object, e As DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs)

            'objects
            Dim MyString() As String = Nothing

            Try

                If e.Item.AxisValueInternal = 0.0 Or e.Item.AxisValue.ToString.Contains("*") Then

                    e.Item.Font = New System.Drawing.Font(e.Item.Font.ToString, e.Item.Font.Size, Drawing.FontStyle.Bold)

                Else

                    MyString = e.Item.Text.Split("~")

                    e.Item.Text = MyString(0)

                End If

                If e.Item.AxisValue.ToString.Contains("*") Then

                    e.Item.Text = e.Item.AxisValue.ToString.Replace("*", "")

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ChartControlForm_Gantt_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs)

            'objects
            Dim GanttDrawOptions As DevExpress.XtraCharts.GanttDrawOptions = Nothing
            Dim RectangleGradientFillOptions As DevExpress.XtraCharts.RectangleGradientFillOptions = Nothing

            Try
                If e.SeriesPoint.Argument.Contains(e.Series.Name) Then

                    GanttDrawOptions = CType(e.SeriesDrawOptions, DevExpress.XtraCharts.GanttDrawOptions)
                    GanttDrawOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient
                    RectangleGradientFillOptions = CType(GanttDrawOptions.FillStyle.Options, DevExpress.XtraCharts.RectangleGradientFillOptions)
                    RectangleGradientFillOptions.Color2 = Drawing.Color.FromArgb(51, 51, 255)
                    GanttDrawOptions.Color = Drawing.Color.FromArgb(51, 51, 255)
                    GanttDrawOptions.Border.Color = Drawing.Color.FromArgb(51, 51, 255)

                End If

                If e.SeriesPoint.Argument.Contains("*") Then

                    GanttDrawOptions = CType(e.SeriesDrawOptions, DevExpress.XtraCharts.GanttDrawOptions)
                    GanttDrawOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient
                    RectangleGradientFillOptions = CType(GanttDrawOptions.FillStyle.Options, DevExpress.XtraCharts.RectangleGradientFillOptions)
                    RectangleGradientFillOptions.Color2 = Drawing.Color.FromArgb(51, 153, 255)
                    GanttDrawOptions.Color = Drawing.Color.FromArgb(51, 153, 255)
                    GanttDrawOptions.Border.Color = Drawing.Color.FromArgb(51, 153, 255)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemOptions_Day_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Day.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Day.Checked Then

                    ButtonItemOptions_Week.Checked = False
                    ButtonItemOptions_Month.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemOptions_Week_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Week.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Week.Checked Then

                    ButtonItemOptions_Day.Checked = False
                    ButtonItemOptions_Month.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemOptions_Month_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_Month.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If ButtonItemOptions_Month.Checked Then

                    ButtonItemOptions_Week.Checked = False
                    ButtonItemOptions_Day.Checked = False

                End If

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_Labels_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_Labels.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_Phase_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_Phase.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxItemOptions_RelatedJobs_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemOptions_RelatedJobs.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                LoadChart()

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace