Namespace Repositories
    Public MustInherit Class GanttRepositoryBase
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property Session As AdvantageFramework.Security.Session = Nothing
#End Region

#Region " Methods "
        Public Sub New()

        End Sub

        Public Sub New(SecuritySession As AdvantageFramework.Security.Session)
            Me.Session = SecuritySession
        End Sub

        Public Function GetScheduleTasks(JobNumber As Integer, JobComponentNumber As Integer, Optional ShowPhases As Boolean = False) As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            Dim ProjectScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim PhaseFilter As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                If (ShowPhases) Then
                    PhaseFilter = "phase"
                End If
                ProjectScheduleTasks = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber, PhaseFilter, Session.UserCode, "", "", "", True, False, False, "", "", True)

            End Using

            GetScheduleTasks = ProjectScheduleTasks
        End Function

        Public Function AddScheduleTask(JobNumber As Integer, JobComponentNumber As Integer, Task As ViewModels.Gantt.GanttTask) As Boolean
            Dim TaskAdded As Boolean

            Dim TaskDetail As AdvantageFramework.ProjectSchedule.Classes.TaskDetail = Nothing

            TaskDetail = New AdvantageFramework.ProjectSchedule.Classes.TaskDetail()
            TaskDetail.TaskDescription = Task.Title

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                TaskAdded = AdvantageFramework.ProjectSchedule.AddTaskToSchedule(DbContext, TaskDetail, JobNumber, JobComponentNumber, False, False)
            End Using

            AddScheduleTask = TaskAdded
        End Function

        Public Sub UpdateScheduleTask(JobNumber As Integer, JobComponentNumber As Integer, Task As ViewModels.Gantt.GanttTask)
            Dim CalculatedJobDays As Integer
            Dim CalculatedWeekendDays As Integer
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            CalculatedJobDays = Task.End.GetValueOrDefault().Subtract(Task.Start.GetValueOrDefault()).Days + 1 'treats days as full days

            For DayCounter As Integer = 0 To CalculatedJobDays - 1

                If Task.Start.GetValueOrDefault().AddDays(DayCounter).DayOfWeek = DayOfWeek.Sunday OrElse
                   Task.Start.GetValueOrDefault().AddDays(DayCounter).DayOfWeek = DayOfWeek.Saturday Then

                    CalculatedWeekendDays += 1

                End If

            Next

            'For DayCounter As Integer = 0 To CalculatedJobDays - 1
            '    If Task.Start.GetValueOrDefault().AddDays(DayCounter).DayOfWeek = DayOfWeek.Sunday Then
            '        CalculatedWeekendDays += 1
            '    End If
            '    If Task.Start.GetValueOrDefault().AddDays(DayCounter).DayOfWeek = DayOfWeek.Saturday Then
            '        CalculatedWeekendDays += 1
            '    End If
            'Next

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobComponentTaskID(DbContext, Task.ID)
                If JobComponentTask.StartDate <> Task.Start OrElse JobComponentTask.DueDate <> Task.End Then
                    JobComponentTask.StartDate = Task.Start
                    JobComponentTask.DueDate = Task.End
                    JobComponentTask.Days = CalculatedJobDays - CalculatedWeekendDays
                    AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)
                End If

            End Using
        End Sub
#End Region

    End Class
End Namespace

