Imports System.Collections.Generic
Imports Webvantage.ViewModels.Gantt
Imports System.Data.SqlClient

Namespace Repositories
    Public Class GanttTaskRepository
        Inherits GanttRepositoryBase
        Private Const HeaderHeight As Integer = 220
        Private Const MinimumChartHeight As Integer = 450
        Private Const MaximumChartHeight As Integer = 1150
        Private Const ChartRowItemHeight As Integer = 48

        Private UpdateDatabase As Boolean = False

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)
            MyBase.New(SecuritySession)
        End Sub

        Public Function All(JobNumber As Integer, JobComponentNumber As Integer, Optional ShowPhases As Boolean = False) As IList(Of GanttTask)

            Dim CacheTitle As String = String.Format("Tasks_{0}_{1}_{2}", JobNumber, JobComponentNumber, ShowPhases)

            Dim Results = TryCast(HttpContext.Current.Session(CacheTitle), IList(Of GanttTask))
            Dim StartMissing As Boolean
            Dim EndMissing As Boolean

            If Results Is Nothing Then
                Dim ProjectScheduleItems As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing

                ProjectScheduleItems = Me.GetScheduleTasks(JobNumber, JobComponentNumber, ShowPhases)

                Results = New List(Of GanttTask)

                For Each ProjectScheduleItem In ProjectScheduleItems
                    StartMissing = Not ProjectScheduleItem.TaskStartDate.HasValue

                    If (ProjectScheduleItem.TaskStartDate.HasValue = False AndAlso ProjectScheduleItems.Any(Function(Item) Item.TaskStartDate.HasValue)) Then
                        ProjectScheduleItem.TaskStartDate = ProjectScheduleItems.Where(Function(Item) Item.TaskStartDate.HasValue).OrderBy(Function(Item) Item.TaskStartDate.GetValueOrDefault()).FirstOrDefault().TaskStartDate
                    End If

                    EndMissing = Not ProjectScheduleItem.JobRevisedDate.HasValue

                    If (ProjectScheduleItem.JobRevisedDate.HasValue = False AndAlso ProjectScheduleItems.Any(Function(Item) Item.JobRevisedDate.HasValue)) Then
                        ProjectScheduleItem.JobRevisedDate = ProjectScheduleItems.Where(Function(Item) Item.JobRevisedDate.HasValue).OrderBy(Function(Item) Item.JobRevisedDate.GetValueOrDefault()).FirstOrDefault().JobRevisedDate
                    End If

                    If (ShowPhases AndAlso String.IsNullOrWhiteSpace(ProjectScheduleItem.PhaseDescription) = False) Then
                        If Not (Results.Any(Function(Result) Result.IsPhase AndAlso Result.Title = ProjectScheduleItem.PhaseDescription)) Then
                            Results.Add(New GanttTask With {.IsPhase = True, .ID = Results.Count + 10, .Title = ProjectScheduleItem.PhaseDescription, .OrderID = Results.Count + 1, .PercentComplete = 0, .Expanded = True, .Start = ProjectScheduleItem.PhaseStartDate, .End = ProjectScheduleItem.PhaseEndDate})
                        End If
                        Dim ParentTask = Results.Single(Function(Task) Task.IsPhase AndAlso Task.Title = ProjectScheduleItem.PhaseDescription)
                        Results.Add(New GanttTask(ProjectScheduleItem) With {.ParentID = ParentTask.ID, .StartMissing = StartMissing, .EndMissing = EndMissing, .AssignedEmployees = GetEmployeeAssignments(ProjectScheduleItem.JobNumber, ProjectScheduleItem.JobComponentNumber, ProjectScheduleItem.SequenceNumber)})

                    Else
                        Results.Add(New GanttTask(ProjectScheduleItem) With {.OrderID = Results.Count + 1, .StartMissing = StartMissing, .EndMissing = EndMissing, .AssignedEmployees = GetEmployeeAssignments(ProjectScheduleItem.JobNumber, ProjectScheduleItem.JobComponentNumber, ProjectScheduleItem.SequenceNumber)})
                    End If
                Next

                For Each ResultPhase In Results.Where(Function(Result) Result.IsPhase)
                    If (Results.Any(Function(Result) Result.ParentID.HasValue AndAlso Result.ParentID = ResultPhase.ID)) Then
                        ResultPhase.DispersedHours = Results.Where(Function(Result) Result.ParentID.HasValue AndAlso Result.ParentID = ResultPhase.ID).Sum(Function(Child) Child.DispersedHours)
                        ResultPhase.PostedHours = Results.Where(Function(Result) Result.ParentID.HasValue AndAlso Result.ParentID = ResultPhase.ID).Sum(Function(Child) Child.PostedHours)
                        If (ResultPhase.PostedHours > 0) AndAlso (ResultPhase.DispersedHours > 0) Then
                            ResultPhase.PercentComplete = ResultPhase.PostedHours / ResultPhase.DispersedHours
                        End If
                    End If
                Next

                'HttpContext.Current.Session(CacheTitle) = Results
            End If

            Return Results

        End Function

        Public Sub Insert(JobNumber As Integer, JobComponentNumber As Integer, tasks As IEnumerable(Of GanttTask))
            For Each task In tasks
                Insert(JobNumber, JobComponentNumber, task)
            Next
        End Sub

        Public Sub Insert(JobNumber As Integer, JobComponentNumber As Integer, task As GanttTask)
            Dim first = All(JobNumber, JobComponentNumber).OrderByDescending(Function(e) e.ID).FirstOrDefault()

            Dim id = 0

            If first IsNot Nothing Then
                id = first.ID
            End If

            task.ID = id + 1

            All(JobNumber, JobComponentNumber).Insert(0, task)
        End Sub

        Public Sub Update(JobNumber As Integer, JobComponentNumber As Integer, tasks As IEnumerable(Of GanttTask))
            For Each task In tasks
                Update(JobNumber, JobComponentNumber, task)
            Next
        End Sub

        Public Sub Update(JobNumber As Integer, JobComponentNumber As Integer, task As GanttTask)
            Dim target = All(JobNumber, JobComponentNumber).SingleOrDefault(Function(t) t.ID = task.ID)

            If target IsNot Nothing Then
                target.Title = task.Title
                target.Start = task.Start
                target.[End] = task.[End]
                target.PercentComplete = task.PercentComplete
                target.OrderID = task.OrderID
                target.ParentID = task.ParentID
                target.Summary = task.Summary
                target.Expanded = task.Expanded
            End If

            Me.UpdateScheduleTask(JobNumber, JobComponentNumber, task)
        End Sub

        Public Sub Delete(JobNumber As Integer, JobComponentNumber As Integer, tasks As IEnumerable(Of GanttTask))
            For Each task In tasks
                Delete(JobNumber, JobComponentNumber, task)
            Next
        End Sub

        Public Sub Delete(JobNumber As Integer, JobComponentNumber As Integer, task As GanttTask)
            Dim target = All(JobNumber, JobComponentNumber).SingleOrDefault(Function(t) t.ID = task.ID)
            If IsNothing(target) = False Then
                All(JobNumber, JobComponentNumber).Remove(target)
            End If
        End Sub

        Public Function GetJobDescription(ByVal JobInfo As GanttJobInfo) As String
            Dim JobDescription As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                JobDescription = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobInfo.JobNumber, JobInfo.JobComponentNumber).Description()
            End Using

            GetJobDescription = JobDescription
        End Function

        Public Function GetRelatedJobs(ByVal JobInfo As GanttJobInfo) As List(Of GanttJobInfo)
            Dim Results As List(Of ViewModels.Gantt.GanttJobInfo) = Nothing
            Dim JobTrafficPredecessors As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobsDataRow As DataRow
            Dim JobsDataTable As New DataTable
            Dim JobsDataView As DataView
            Dim JobCount As Integer = 0
            Dim JobColumn As DataColumn = New DataColumn("Job")
            Dim ComponentColumn As DataColumn = New DataColumn("Comp")
            Dim DescriptionColumn As DataColumn = New DataColumn("Description")
            Dim StartDateColumn As DataColumn = New DataColumn("START_DATE", System.Type.GetType("System.DateTime"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

            Results = New List(Of ViewModels.Gantt.GanttJobInfo)

            JobsDataTable.Columns.Add(JobColumn)
            JobsDataTable.Columns.Add(ComponentColumn)
            JobsDataTable.Columns.Add(DescriptionColumn)
            JobsDataTable.Columns.Add(StartDateColumn)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobInfo.JobNumber, JobInfo.JobComponentNumber)
                    JobsDataRow = JobsDataTable.NewRow
                    JobsDataRow.Item("Job") = JobInfo.JobNumber.ToString
                    JobsDataRow.Item("Comp") = JobInfo.JobComponentNumber.ToString
                    JobsDataRow.Item("Description") = JobComponent.Job.Description
                    JobsDataRow.Item("START_DATE") = JobComponent.StartDate
                    JobsDataTable.Rows.Add(JobsDataRow)
                    Do While JobCount < JobsDataTable.Rows.Count
                        JobTrafficPredecessors = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobsDataTable.Rows(JobCount)("Job"), JobsDataTable.Rows(JobCount)("Comp")).Include("JobTraffic").ToList
                        If JobTrafficPredecessors.Count > 0 Then
                            For PredecessorIndex As Integer = 0 To JobTrafficPredecessors.Count - 1
                                If JobCount >= 1 Then
                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobNumber)
                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Session.User.EmployeeCode, JobTrafficPredecessors(PredecessorIndex).JobNumber) = True AndAlso
                                       AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.ValidateJobCDP(SecurityDbContext, Session.UserCode, jobdata.ProductCode, jobdata.DivisionCode, jobdata.ClientCode) = True Then
                                        JobsDataView = JobsDataTable.DefaultView
                                        JobsDataView.RowFilter = String.Format("Job = '{0}' AND Comp = '{1}'", JobTrafficPredecessors(PredecessorIndex).JobNumber, JobTrafficPredecessors(PredecessorIndex).JobComponentNumber)
                                        If JobsDataView.Count = 0 Then
                                            JobsDataRow = JobsDataTable.NewRow
                                            JobsDataRow.Item("Job") = JobTrafficPredecessors(PredecessorIndex).JobNumber.ToString
                                            JobsDataRow.Item("Comp") = JobTrafficPredecessors(PredecessorIndex).JobComponentNumber.ToString
                                            JobsDataRow.Item("Description") = JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.Job.Description
                                            If JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.StartDate IsNot Nothing Then
                                                JobsDataRow.Item("START_DATE") = JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.StartDate
                                            Else
                                                JobsDataRow.Item("START_DATE") = DBNull.Value
                                            End If
                                            JobsDataTable.Rows.Add(JobsDataRow)
                                        End If
                                    End If
                                Else
                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobNumber)
                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Session.User.EmployeeCode, JobTrafficPredecessors(PredecessorIndex).JobNumber) = True AndAlso
                                       AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.ValidateJobCDP(SecurityDbContext, Session.UserCode, jobdata.ProductCode, jobdata.DivisionCode, jobdata.ClientCode) = True Then
                                        JobsDataRow = JobsDataTable.NewRow
                                        JobsDataRow.Item("Job") = JobTrafficPredecessors(PredecessorIndex).JobNumber.ToString
                                        JobsDataRow.Item("Comp") = JobTrafficPredecessors(PredecessorIndex).JobComponentNumber.ToString
                                        JobsDataRow.Item("Description") = JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.Job.Description
                                        If JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.StartDate IsNot Nothing Then
                                            JobsDataRow.Item("START_DATE") = JobTrafficPredecessors(PredecessorIndex).JobTraffic.JobComponent.StartDate
                                        Else
                                            JobsDataRow.Item("START_DATE") = DBNull.Value
                                        End If
                                        JobsDataTable.Rows.Add(JobsDataRow)
                                    End If
                                End If
                            Next
                        End If

                        JobTrafficPredecessors = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, JobsDataTable.Rows(JobCount)("Job"), JobsDataTable.Rows(JobCount)("Comp")).ToList

                        If JobTrafficPredecessors.Count > 0 Then
                            For PredecessorIndex As Integer = 0 To JobTrafficPredecessors.Count - 1
                                If JobCount >= 1 Then
                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobPredecessor)
                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Session.User.EmployeeCode, JobTrafficPredecessors(PredecessorIndex).JobPredecessor) = True AndAlso
                                       AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.ValidateJobCDP(SecurityDbContext, Session.UserCode, jobdata.ProductCode, jobdata.DivisionCode, jobdata.ClientCode) = True Then
                                        JobsDataView = JobsDataTable.DefaultView
                                        JobsDataView.RowFilter = String.Format("Job = '{0}' AND Comp = '{1}'", JobTrafficPredecessors(PredecessorIndex).JobPredecessor, JobTrafficPredecessors(PredecessorIndex).JobComponentPredecessor)
                                        If JobsDataView.Count = 0 Then
                                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobPredecessor, JobTrafficPredecessors(PredecessorIndex).JobComponentPredecessor)
                                            JobsDataRow = JobsDataTable.NewRow
                                            JobsDataRow.Item("Job") = JobTrafficPredecessors(PredecessorIndex).JobPredecessor.ToString
                                            JobsDataRow.Item("Comp") = JobTrafficPredecessors(PredecessorIndex).JobComponentPredecessor.ToString
                                            JobsDataRow.Item("Description") = JobComponent.Job.Description
                                            If JobComponent.StartDate IsNot Nothing Then
                                                JobsDataRow.Item("START_DATE") = JobComponent.StartDate
                                            Else
                                                JobsDataRow.Item("START_DATE") = DBNull.Value
                                            End If
                                            JobsDataTable.Rows.Add(JobsDataRow)
                                        End If
                                    End If

                                Else
                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobPredecessor)
                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Session.User.EmployeeCode, JobTrafficPredecessors(PredecessorIndex).JobPredecessor) = True AndAlso
                                       AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.ValidateJobCDP(SecurityDbContext, Session.UserCode, jobdata.ProductCode, jobdata.DivisionCode, jobdata.ClientCode) = True Then
                                        JobsDataRow = JobsDataTable.NewRow
                                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTrafficPredecessors(PredecessorIndex).JobPredecessor, JobTrafficPredecessors(PredecessorIndex).JobComponentPredecessor)
                                        JobsDataRow.Item("Job") = JobTrafficPredecessors(PredecessorIndex).JobPredecessor.ToString
                                        JobsDataRow.Item("Comp") = JobTrafficPredecessors(PredecessorIndex).JobComponentPredecessor.ToString
                                        JobsDataRow.Item("Description") = JobComponent.Job.Description
                                        If JobComponent.StartDate IsNot Nothing Then
                                            JobsDataRow.Item("START_DATE") = JobComponent.StartDate
                                        Else
                                            JobsDataRow.Item("START_DATE") = DBNull.Value
                                        End If
                                        JobsDataTable.Rows.Add(JobsDataRow)
                                    End If

                                End If
                            Next
                        End If
                        JobCount += 1
                    Loop

                    For RowIndex As Integer = 0 To JobsDataTable.Rows.Count - 1
                        If RowIndex = 0 Then
                            Results.Add(New GanttJobInfo With {.IsRelatedJob = RowIndex > 0, .JobNumber = JobsDataTable.Rows(RowIndex)("Job"), .JobComponentNumber = JobsDataTable.Rows(RowIndex)("Comp"), .JobDescription = JobsDataTable.Rows(RowIndex)("Description"), .StartDate = CDate(JobsDataTable.Rows(RowIndex)("START_DATE"))})
                        Else
                            If IsDBNull(JobsDataTable.Rows(RowIndex)("START_DATE")) Then
                                Dim ResultToAdd As New GanttJobInfo With {.IsRelatedJob = RowIndex > 0, .JobNumber = JobsDataTable.Rows(RowIndex)("Job"), .JobComponentNumber = JobsDataTable.Rows(RowIndex)("Comp"), .JobDescription = JobsDataTable.Rows(RowIndex)("Description"), .StartDate = Nothing}
                                If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, ResultToAdd.JobNumber, ResultToAdd.JobComponentNumber).Any() Then
                                    Results.Add(ResultToAdd)
                                End If
                            Else
                                Dim ResultToAdd As New GanttJobInfo With {.IsRelatedJob = RowIndex > 0, .JobNumber = JobsDataTable.Rows(RowIndex)("Job"), .JobComponentNumber = JobsDataTable.Rows(RowIndex)("Comp"), .JobDescription = JobsDataTable.Rows(RowIndex)("Description"), .StartDate = IIf(IsDBNull(JobsDataTable.Rows(RowIndex)("START_DATE")), Nothing, CDate(JobsDataTable.Rows(RowIndex)("START_DATE")))}
                                If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, ResultToAdd.JobNumber, ResultToAdd.JobComponentNumber).Any() Then
                                    Results.Add(ResultToAdd)
                                End If
                            End If

                        End If
                    Next

                    For Each ResultItem In Results

                        With AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, ResultItem.JobNumber, ResultItem.JobComponentNumber).ToList

                            ResultItem.HasNullTaskDates = .Any(Function(item) item.StartDate.HasValue = False OrElse item.DueDate.HasValue = False)
                            ResultItem.CalculatedHeight = HeaderHeight + ((.Count() + .Select(Function(item) item.PhaseID.GetValueOrDefault(0)).Distinct().Count) * ChartRowItemHeight)

                            If (ResultItem.CalculatedHeight < MinimumChartHeight) Then
                                ResultItem.CalculatedHeight = MinimumChartHeight
                            End If

                            If (ResultItem.CalculatedHeight > MaximumChartHeight) Then
                                ResultItem.CalculatedHeight = MaximumChartHeight
                            End If

                        End With

                    Next

                    Results = Results.Distinct().OrderByDescending(Function(Result) Not Result.IsRelatedJob).ThenBy(Function(Result) Result.JobNumber).ThenBy(Function(Result) Result.JobComponentNumber).ToList()

                    GetRelatedJobs = Results

                End Using

            End Using
        End Function

        Public Function GetEmployeeAssignments(JobNumber As Integer, JobComponentNumber As Integer, Sequence As Integer) As String
            Dim EmployeeResults As List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                EmployeeResults = AdvantageFramework.ProjectSchedule.GetScheduleTaskEmployees(DbContext, JobNumber, JobComponentNumber, Sequence).ToList()
                GetEmployeeAssignments = String.Join(", ", EmployeeResults.Select(Function(Employee) Employee.FirstName + " " + If(String.IsNullOrWhiteSpace(Employee.MiddleInitial), String.Empty, Employee.MiddleInitial + ". " + Employee.LastName)))
            End Using
        End Function

        Public Function GetQuickAddTasks(ByVal ShowPreset As Boolean) As List(Of ViewModels.ProjectScheduleQuickAddTask)
            Dim Results As List(Of ViewModels.ProjectScheduleQuickAddTask) = Nothing

            Results = New List(Of ViewModels.ProjectScheduleQuickAddTask)

            Using SQLConnection As New SqlConnection(Session.ConnectionString)
                Using SQLCommand As New SqlCommand
                    With SQLCommand
                        .Connection = SQLConnection
                        .Connection.Open()
                        .CommandText = "usp_wv_Traffic_Schedule_GetQuickAdd"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@SHOW_PRESET", ShowPreset))
                    End With

                    SQLCommand.ExecuteNonQuery()

                    Using Reader As SqlDataReader = SQLCommand.ExecuteReader()
                        While Reader.Read()
                            Results.Add(New ViewModels.ProjectScheduleQuickAddTask() With {.ID = Reader("ROWID"), .RowQuantity = 0, .TaskCode = "", .TaskDescription = "", .Order = 0, .Days = 0, .Hours = 0, .Milestone = False})
                        End While
                    End Using
                End Using
            End Using

            Return Results
        End Function
    End Class
End Namespace