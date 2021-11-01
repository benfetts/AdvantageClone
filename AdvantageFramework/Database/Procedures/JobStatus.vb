Namespace Database.Procedures.JobStatus

    <HideModuleName()> _
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
                                                    JobNumber As Integer, JobComponentNumber As Short, UserCode As String) As AdvantageFramework.Database.Classes.JobStatus

            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterUserCode.Value = UserCode

            LoadByJobAndComponentNumber = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.JobStatus)("EXEC dbo.advsp_job_status_load @JOB_NUMBER, @JOB_COMPONENT_NBR, @USER_CODE",
                SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterUserCode).FirstOrDefault()

        End Function

#End Region

    End Module

End Namespace