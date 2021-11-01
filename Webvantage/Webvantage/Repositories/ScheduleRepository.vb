Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Webvantage.ViewModels
Imports Webvantage.Interfaces
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Namespace Repositories

    Public Class ScheduleRepository
        Inherits RepositoryBase
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

        Public Function CalculateScheduleDueDates(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Integer
            Dim ParameterJobNumber As SqlParameter = Nothing
            Dim ParameterJobCompNumber As SqlParameter = Nothing
            Dim ParameterUsePredecessor As SqlParameter = Nothing
            Dim ParameterReturnValue As SqlParameter = Nothing

            Dim IsPredecessor As Boolean

            IsPredecessor = GetFollowingJobs(JobNumber, JobComponentNumber).Any()

            ParameterJobNumber = New SqlParameter("@job_number", SqlDbType.Int)
            ParameterJobNumber.Value = JobNumber

            ParameterJobCompNumber = New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            ParameterJobCompNumber.Value = JobComponentNumber

            ParameterUsePredecessor = New SqlParameter("@use_predecessor", SqlDbType.Bit)
            ParameterUsePredecessor.Value = IsPredecessor

            ParameterReturnValue = New SqlParameter("@ret_val", SqlDbType.Int)
            ParameterReturnValue.Direction = ParameterDirection.Output

            Using SQLConnection As New SqlConnection(Session.ConnectionString)
                Using SQLCommand As New SqlCommand
                    With SQLCommand
                        .Connection = SQLConnection
                        .Connection.Open()
                        .CommandText = "advsp_calculate_schedule"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(ParameterJobNumber)
                        .Parameters.Add(ParameterJobCompNumber)
                        .Parameters.Add(ParameterUsePredecessor)
                        .Parameters.Add(ParameterReturnValue)
                    End With

                    SQLCommand.ExecuteNonQuery()
                End Using
            End Using

            CalculateScheduleDueDates = ParameterReturnValue.Value

        End Function

        Public Function CalculateProjectSchedulePredecessors(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Integer
            Dim ParameterJobNumber As SqlParameter = Nothing
            Dim ParameterJobCompNumber As SqlParameter = Nothing
            Dim ParameterUsePredecessor As SqlParameter = Nothing
            Dim ParameterReturnValue As SqlParameter = Nothing

            Dim IsPredecessor As Boolean

            IsPredecessor = GetFollowingJobs(JobNumber, JobComponentNumber).Any()

            ParameterJobNumber = New SqlParameter("@job_number", SqlDbType.Int)
            ParameterJobNumber.Value = JobNumber

            ParameterJobCompNumber = New SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            ParameterJobCompNumber.Value = JobComponentNumber

            ParameterUsePredecessor = New SqlParameter("@use_predecessor", SqlDbType.Bit)
            ParameterUsePredecessor.Value = IsPredecessor

            ParameterReturnValue = New SqlParameter("@ret_val", SqlDbType.Int)
            ParameterReturnValue.Direction = ParameterDirection.Output

            Using SQLConnection As New SqlConnection(Session.ConnectionString)
                Using SQLCommand As New SqlCommand
                    With SQLCommand
                        .Connection = SQLConnection
                        .Connection.Open()
                        .CommandText = "usp_wv_Traffic_Schedule_Calculate_Pred"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(ParameterJobNumber)
                        .Parameters.Add(ParameterJobCompNumber)
                        .Parameters.Add(ParameterUsePredecessor)
                        .Parameters.Add(ParameterReturnValue)
                    End With

                    SQLCommand.ExecuteNonQuery()
                End Using
            End Using

            CalculateProjectSchedulePredecessors = ParameterReturnValue.Value

        End Function

        Public Function GetFollowingJobs(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors)
            Dim JobPredecessors As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                JobPredecessors = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, JobNumber, JobComponentNumber).ToList
            End Using
            GetFollowingJobs = JobPredecessors
        End Function
#End Region
    End Class
End Namespace
