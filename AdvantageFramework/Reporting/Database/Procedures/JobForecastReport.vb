Namespace Reporting.Database.Procedures.JobForecastReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.JobForecastReport)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.SearchDate.ToString))

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext,
                             ByVal SearchDate As Date) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.JobForecastReport)

            'objects
            Dim SqlParameterPostPeriodStart As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterPostPeriodStart = New System.Data.SqlClient.SqlParameter("@SEARCH_DATE", SqlDbType.SmallDateTime)
            SqlParameterPostPeriodStart.Value = SearchDate

            Try

                Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.JobForecastReport)("EXEC dbo.advsp_job_forecast_report @SEARCH_DATE", SqlParameterPostPeriodStart)

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
