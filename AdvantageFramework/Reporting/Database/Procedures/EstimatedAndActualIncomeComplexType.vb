Namespace Reporting.Database.Procedures.EstimatedAndActualIncomeComplexType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.EstimatedAndActualIncome)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.StartDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.EndDate.ToString), ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.DateType.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.EstimatedAndActualIncomeParameters.Standard.ToString))

        End Function

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal StartDate As DateTime, ByVal EndDate As DateTime,
                             ByVal DateType As Integer, ByVal Type As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.EstimatedAndActualIncome)

            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStandard As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            SqlParameterDateType = New System.Data.SqlClient.SqlParameter("@DateType", SqlDbType.Int)
            SqlParameterStandard = New System.Data.SqlClient.SqlParameter("@Standard", SqlDbType.Int)

            SqlParameterStartDate.Value = StartDate.ToShortDateString
            SqlParameterEndDate.Value = CDate(EndDate.ToShortDateString).AddDays(1).AddSeconds(-1)
            SqlParameterDateType.Value = DateType
            SqlParameterStandard.Value = Type

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.EstimatedAndActualIncome)("EXEC dbo.usp_wv_Gross_Income @StartDate, @EndDate, @DateType, @Standard",
                SqlParameterStartDate, SqlParameterEndDate, SqlParameterDateType, SqlParameterStandard)

        End Function

#End Region

    End Module

End Namespace
