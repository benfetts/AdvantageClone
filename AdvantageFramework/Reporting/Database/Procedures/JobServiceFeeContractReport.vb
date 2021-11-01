Namespace Reporting.Database.Procedures.JobServiceFeeContractReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal Criteria As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.JobServiceFeeContractReport)

            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateType As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@FROM_DATE", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@TO_DATE", SqlDbType.SmallDateTime)
            SqlParameterDateType = New System.Data.SqlClient.SqlParameter("@CRITERIA", SqlDbType.SmallInt)

            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterDateType.Value = Criteria

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.JobServiceFeeContractReport)("EXEC dbo.advsp_load_drpt_job_service_fee @CRITERIA, @FROM_DATE, @TO_DATE",
                SqlParameterStartDate, SqlParameterEndDate, SqlParameterDateType)

        End Function

#End Region

    End Module

End Namespace
