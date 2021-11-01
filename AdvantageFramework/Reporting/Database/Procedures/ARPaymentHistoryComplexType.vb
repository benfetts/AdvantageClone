Namespace Reporting.Database.Procedures.ARPaymentHistoryComplexType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ARPaymentHistoryReport)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.ARPaymentHistoryParameters.StartingPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ARPaymentHistoryParameters.EndingPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ARPaymentHistoryParameters.AgingOption.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ARPaymentHistoryParameters.IncludeOnAccount.ToString))

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal PostPeriodStart As String,
                             ByVal PostPeriodEnd As String, ByVal AgingOption As Short,
                             ByVal IncludeOnAccount As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ARPaymentHistoryReport)

            'objects
            Dim SqlParameterPostPeriodStart As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPostPeriodEnd As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAgingOption As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeOnAccount As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterPostPeriodStart = New System.Data.SqlClient.SqlParameter("@PostPeriodStart", SqlDbType.VarChar)
            SqlParameterPostPeriodEnd = New System.Data.SqlClient.SqlParameter("@PostPeriodEnd", SqlDbType.VarChar)
            SqlParameterAgingOption = New System.Data.SqlClient.SqlParameter("@AgingOption", SqlDbType.SmallInt)
            SqlParameterIncludeOnAccount = New System.Data.SqlClient.SqlParameter("@IncludeOnAccount", SqlDbType.Bit)

            SqlParameterPostPeriodStart.Value = PostPeriodStart
            SqlParameterPostPeriodEnd.Value = PostPeriodEnd
            SqlParameterAgingOption.Value = AgingOption
            SqlParameterIncludeOnAccount.Value = IncludeOnAccount

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.ARPaymentHistoryReport)("EXEC dbo.advsp_ar_payment_history_report @PostPeriodStart, @PostPeriodEnd, @AgingOption, @IncludeOnAccount",
                SqlParameterPostPeriodStart, SqlParameterPostPeriodEnd, SqlParameterAgingOption, SqlParameterIncludeOnAccount)

        End Function

#End Region

    End Module

End Namespace
