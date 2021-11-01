Namespace Database.Procedures.JobTeam

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByJobAndComponentNumber(DbContext As AdvantageFramework.Database.DbContext,
                                                    JobNumber As Integer, JobComponentNumber As Short, TeamType As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.JobTeamEmployee)

            Dim SqlParameterTeamType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterTeamType = New System.Data.SqlClient.SqlParameter("@TEAM_TYPE", SqlDbType.SmallInt)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)

            SqlParameterTeamType.Value = TeamType
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber

            LoadByJobAndComponentNumber = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.JobTeamEmployee)("exec dbo.advsp_job_team_load @TEAM_TYPE, @JOB_NUMBER, @JOB_COMPONENT_NBR",
                SqlParameterTeamType, SqlParameterJobNumber, SqlParameterJobComponentNumber).ToList

        End Function

#End Region

    End Module

End Namespace