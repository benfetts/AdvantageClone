Imports System.Collections.Generic

Namespace Recents

    Public Module Methods

        Public Const RecentAssignmentsSessionKey As String = "LOLT20150321RASK"
        Public Const RecentJobsSessionKey As String = "PBTT20071002RJSK"
        Public Const RecentsLength As Long = 10

#Region " Recents Assignments "

        Public Function GetRecentAssignments() As IEnumerable(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

            Dim RecentAssignmentsQueue As Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel) = Nothing

            Try

                If HttpContext.Current.Session(RecentAssignmentsSessionKey) Is Nothing Then

                    RecentAssignmentsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

                Else

                    RecentAssignmentsQueue = CType(HttpContext.Current.Session(RecentAssignmentsSessionKey), Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel))

                End If

            Catch ex As Exception
                RecentAssignmentsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)
            End Try

            Return RecentAssignmentsQueue.ToArray

        End Function
        Public Function AddToRecentAssignments(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As Boolean

            Dim RecentAssignmentsQueue As Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel) = Nothing
            Dim Recent As New AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel
            Dim Added As Boolean = True

            If Alert IsNot Nothing AndAlso
                Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso
                Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 Then

                Try

                    If HttpContext.Current.Session(RecentAssignmentsSessionKey) Is Nothing Then

                        RecentAssignmentsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

                    Else

                        RecentAssignmentsQueue = CType(HttpContext.Current.Session(RecentAssignmentsSessionKey), Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel))

                    End If
                    If RecentAssignmentsQueue IsNot Nothing Then

                        Dim i As Integer = 0
                        i = (From Entity In RecentAssignmentsQueue
                             Where Entity.AlertID = Alert.ID).Count

                        If i = 0 Then

                            If RecentAssignmentsQueue.Count = RecentsLength Then

                                RecentAssignmentsQueue.Dequeue()

                            End If

                            Recent.LastUsed = Now
                            Recent.AlertID = Alert.ID
                            Recent.ClientCode = Alert.ClientCode
                            Recent.DivisionCode = Alert.DivisionCode
                            Recent.ProductCode = Alert.ProductCode
                            Recent.ClientName = Alert.ClientName
                            Recent.DivisionName = Alert.DivisionName
                            Recent.ProductName = Alert.ProductName
                            If Alert.JobNumber IsNot Nothing Then Recent.JobNumber = Alert.JobNumber
                            If Alert.JobComponentNumber IsNot Nothing Then Recent.JobComponentNumber = Alert.JobComponentNumber
                            If Alert.TaskSequenceNumber IsNot Nothing Then Recent.TaskSequenceNumber = Alert.TaskSequenceNumber
                            Recent.JobDescription = Alert.JobDescription
                            Recent.JobComponentDescription = Alert.JobComponentDescription
                            Recent.Title = Alert.Subject

                            RecentAssignmentsQueue.Enqueue(Recent)

                        End If

                        HttpContext.Current.Session(RecentAssignmentsSessionKey) = RecentAssignmentsQueue

                    End If

                Catch ex As Exception
                    Added = False
                End Try

            End If

            Return Added

        End Function

#End Region
#Region " Recents Jobs "

        Public Function GetRecentJobs() As IEnumerable(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

            Dim RecentJobsQueue As Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel) = Nothing

            Try

                If HttpContext.Current.Session(RecentJobsSessionKey) Is Nothing Then

                    RecentJobsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

                Else

                    RecentJobsQueue = CType(HttpContext.Current.Session(RecentJobsSessionKey), Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel))

                End If

            Catch ex As Exception
                RecentJobsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)
            End Try

            Return RecentJobsQueue.ToArray

        End Function
        Public Function AddToRecentJobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                        ByVal JobComponentDescription As String) As Boolean

            Dim RecentJobsQueue As Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel) = Nothing
            Dim Recent As New AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel
            Dim Added As Boolean = True

            Try

                If HttpContext.Current.Session(RecentJobsSessionKey) Is Nothing Then

                    RecentJobsQueue = New Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel)

                Else

                    RecentJobsQueue = CType(HttpContext.Current.Session(RecentJobsSessionKey), Queue(Of AdvantageFramework.ViewModels.Employee.Timesheet.RecentViewModel))

                End If
                If RecentJobsQueue IsNot Nothing Then

                    Dim i As Integer = 0
                    i = (From Entity In RecentJobsQueue
                         Where Entity.JobNumber = JobNumber And Entity.JobComponentNumber = JobComponentNumber).Count

                    If i = 0 Then

                        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

                        Job = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client").Include("Division").Include("Product")
                               Where Entity.Number = JobNumber
                               Select Entity).SingleOrDefault

                        If String.IsNullOrWhiteSpace(JobComponentDescription) = True Then

                            Try

                                JobComponentDescription = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT JC.JOB_COMP_DESC FROM JOB_COMPONENT JC WITH(NOLOCK) WHERE JC.JOB_NUMBER = {0} AND JC.JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNumber)).SingleOrDefault

                            Catch ex As Exception
                                JobComponentDescription = String.Empty
                            End Try

                        End If

                        If RecentJobsQueue.Count = RecentsLength Then

                            RecentJobsQueue.Dequeue()

                        End If
                        Recent.LastUsed = Now
                        Recent.JobNumber = JobNumber
                        Recent.JobComponentNumber = JobComponentNumber
                        If Job IsNot Nothing Then

                            If Job.Client IsNot Nothing Then

                                Recent.ClientCode = Job.Client.Code
                                Recent.ClientName = Job.Client.Name

                            End If
                            If Job.Division IsNot Nothing Then

                                Recent.DivisionCode = Job.Division.Code
                                Recent.DivisionName = Job.Division.Name

                            End If
                            If Job.Product IsNot Nothing Then

                                Recent.ProductCode = Job.Product.Code
                                Recent.ProductName = Job.Product.Name

                            End If

                            If String.IsNullOrWhiteSpace(JobComponentDescription) = False AndAlso JobComponentDescription <> Job.Description Then

                                Recent.Title = Job.Description & " | " & JobComponentDescription

                            Else

                                Recent.Title = Job.Description

                            End If

                        End If

                        RecentJobsQueue.Enqueue(Recent)

                    End If

                    HttpContext.Current.Session(RecentJobsSessionKey) = RecentJobsQueue

                End If

            Catch ex As Exception
                Added = False
            End Try

            Return Added

        End Function

#End Region

    End Module

End Namespace
