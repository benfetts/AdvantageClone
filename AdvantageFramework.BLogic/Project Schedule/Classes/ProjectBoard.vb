Namespace ProjectSchedule.Classes

    Public Class ProjectBoard

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Short
        Public Property IsJobDashboard As Boolean
        Public Property IsClientPortal As Boolean

        Public Property Schedule As AdvantageFramework.ProjectSchedule.Classes.Schedule = Nothing
        Public Property Tasks As Generic.List(Of TaskCard)

#End Region

#Region " Methods "

        Public Sub Load()

            Schedule = New AdvantageFramework.ProjectSchedule.Classes.Schedule(_Session)

            Schedule.JobNumber = Me.JobNumber
            Schedule.JobComponentNumber = Me.JobComponentNumber
            Schedule.IsClientPortal = Me.IsClientPortal
            Schedule.Load()

            LoadTasks()

        End Sub
        Private Sub LoadTasks()

            Try

                Dim DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Configuration.ProxyCreationEnabled = False

                Tasks = (From JobComponentTask In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobComponentTask).Include("Phase")
                         Where JobComponentTask.JobNumber = JobNumber AndAlso
                           JobComponentTask.JobComponentNumber = JobComponentNumber
                         Select New With {.StatusCode = JobComponentTask.StatusCode,
                                      .Description = JobComponentTask.Description,
                                      .JobNumber = JobComponentTask.JobNumber,
                                      .JobComponentNumber = JobComponentTask.JobComponentNumber,
                                      .SequenceNumber = JobComponentTask.SequenceNumber,
                                      .TaskCode = JobComponentTask.TaskCode,
                                      .PhaseDescription = JobComponentTask.Phase.Description,
                                      .StartDate = JobComponentTask.StartDate,
                                      .CompletedDate = JobComponentTask.CompletedDate,
                                      .DueDate = JobComponentTask.DueDate,
                                      .OriginalDueDate = JobComponentTask.OriginalDueDate,
                                      .Days = JobComponentTask.Days,
                                      .Comment = JobComponentTask.Comment,
                                      .DueDateComment = JobComponentTask.DueDateComment,
                                      .IsMilestone = JobComponentTask.IsMilestone,
                                      .TrafficRoleCode = JobComponentTask.RoleCode}).AsEnumerable().Select(Function(x) New TaskCard With {.SwimLane = "", .StatusCode = IIf(x.CompletedDate IsNot Nothing, "D", x.StatusCode),
                                                                                                                                 .Description = x.Description,
                                                                                                                                 .JobNumber = x.JobNumber,
                                                                                                                                 .JobComponentNumber = x.JobComponentNumber,
                                                                                                                                 .SequenceNumber = x.SequenceNumber,
                                                                                                                                 .TaskCode = x.TaskCode,
                                                                                                                                 .PhaseDescription = x.PhaseDescription,
                                                                                                                                 .Comment = IIf(String.IsNullOrWhiteSpace(x.Comment), "--", x.Comment),
                                                                                                                                 .DueDateComment = IIf(String.IsNullOrWhiteSpace(x.DueDateComment), "--", x.DueDateComment),
                                                                                                                                 .Days = IIf(x.Days Is Nothing, 0, x.Days),
                                                                                                                                 .IsMilestone = x.IsMilestone,
                                                                                                                                 .StartDate = x.StartDate,
                                                                                                                                 .CompletedDate = x.CompletedDate,
                                                                                                                                 .DueDate = x.DueDate,
                                                                                                                                 .IsMilestoneDisplay = IIf(x.IsMilestone Is Nothing OrElse x.IsMilestone = 0, "No", "Yes"),
                                                                                                                                 .StartDateDisplay = ToShortDateString(x.StartDate),
                                                                                                                                 .CompletedDateDisplay = ToShortDateString(x.CompletedDate),
                                                                                                                                 .DueDateDisplay = IIf(ToShortDateString(x.DueDate) = "--", ToShortDateString(x.OriginalDueDate), ToShortDateString(x.DueDate)),
                                                                                                                                 .TrafficRoleCode = IIf(x.TrafficRoleCode Is Nothing, "NoRoleCode", x.TrafficRoleCode)}).ToList

            Catch ex As Exception
                Tasks = New List(Of TaskCard)
            End Try

        End Sub
        Public Sub New()


        End Sub
        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Me.New
            _Session = Session

        End Sub

#End Region

#Region " Classes "

        Public Class TaskCard

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property SwimLane As String = String.Empty
            Public Property StatusCode As String = String.Empty
            Public Property Description As String = String.Empty
            Public Property JobNumber As Integer = 0
            Public Property JobComponentNumber As Short = 0
            Public Property SequenceNumber As Short = 0
            Public Property TaskCode As String = String.Empty
            Public Property PhaseDescription As String = String.Empty
            Public Property Comment As String = String.Empty
            Public Property DueDateComment As String = String.Empty
            Public Property Days As Integer = 0

            Public Property IsMilestone As Boolean? = False
            Public Property StartDate As Date? = Nothing
            Public Property CompletedDate As Date? = Nothing
            Public Property DueDate As Date? = Nothing

            Public Property IsMilestoneDisplay As String = String.Empty
            Public Property StartDateDisplay As String = String.Empty
            Public Property CompletedDateDisplay As String = String.Empty
            Public Property DueDateDisplay As String = String.Empty

            Public Property TrafficRoleCode As String = String.Empty

#End Region

#Region " Methods "



#End Region

        End Class

#End Region

    End Class

End Namespace
