Namespace Reporting.Database.Procedures.GeneralLedgerDetailByAccountReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.GeneralLedgerDetailByAccountReport)

            Load = Load(ReportingDbContext, ReportingDbContext.UserCode,
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.RecordSourceID.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Offices.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Departments.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.OtherCodes.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.BaseCodes.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentAssets.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentAssets.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeFixedAssets.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentLiabilities.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentLiabilities.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeEquity.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncome.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncomeOther.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseCOS.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOperating.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOther.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseTaxes.ToString))

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal UserCode As String,
                             ByVal FromPostPeriod As String, ByVal ToPostPeriod As String, ByVal RecordSourceID As Short, ByVal Offices As String,
                             ByVal Departments As String, ByVal Others As String, ByVal Bases As String, ByVal IncludeCurrentAssets As Boolean,
                             ByVal IncludeNonCurrentAssets As Boolean, ByVal IncludeFixedAssets As Boolean, ByVal IncludeCurrentLiabilities As Boolean,
                             ByVal IncludeNonCurrentLiabilities As Boolean, ByVal IncludeEquity As Boolean, ByVal IncludeIncome As Boolean,
                             ByVal IncludeIncomeOther As Boolean, ByVal IncludeExpeseCOS As Boolean, ByVal IncludeExpenseOperating As Boolean,
                             ByVal IncludeExpenseOther As Boolean, ByVal IncludeExpenseTaxes As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.GeneralLedgerDetailByAccountReport)

            'objects
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim FromPostPeriodSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ToPostPeriodSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RecordSourceIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OfficesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DepartmentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OthersSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim BasesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeCurrentAssetsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeNonCurrentAssetsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeFixedAssetsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeCurrentLiabilitiesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeNonCurrentLiabilitiesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeEquitySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeIncomeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeIncomeOtherSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeExpeseCOSSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeExpenseOperatingSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeExpenseOtherSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IncludeExpenseTaxesSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            FromPostPeriodSqlParameter = New System.Data.SqlClient.SqlParameter("@FROM_PPPERIOD", SqlDbType.VarChar)
            ToPostPeriodSqlParameter = New System.Data.SqlClient.SqlParameter("@TO_PPPERIOD", SqlDbType.VarChar)
            RecordSourceIDSqlParameter = New System.Data.SqlClient.SqlParameter("@RECORD_SOURCE_ID", SqlDbType.Int)
            OfficesSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFICES", SqlDbType.VarChar)
            DepartmentsSqlParameter = New System.Data.SqlClient.SqlParameter("@DEPARTMENTS", SqlDbType.VarChar)
            OthersSqlParameter = New System.Data.SqlClient.SqlParameter("@OTHERS", SqlDbType.VarChar)
            BasesSqlParameter = New System.Data.SqlClient.SqlParameter("@BASES", SqlDbType.VarChar)
            IncludeCurrentAssetsSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_CURRENT_ASSESTS", SqlDbType.Bit)
            IncludeNonCurrentAssetsSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_NON_CURRENT_ASSESTS", SqlDbType.Bit)
            IncludeFixedAssetsSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_FIXED_ASSESTS", SqlDbType.Bit)
            IncludeCurrentLiabilitiesSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_CURRENT_LIABILITIES", SqlDbType.Bit)
            IncludeNonCurrentLiabilitiesSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_NON_CURRENT_LIABILITIES", SqlDbType.Bit)
            IncludeEquitySqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_EQUITY", SqlDbType.Bit)
            IncludeIncomeSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_INCOME", SqlDbType.Bit)
            IncludeIncomeOtherSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_INCOME_OTHER", SqlDbType.Bit)
            IncludeExpeseCOSSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_EXPENSE_COS", SqlDbType.Bit)
            IncludeExpenseOperatingSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_EXPENSE_OPERATING", SqlDbType.Bit)
            IncludeExpenseOtherSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_EXPENSE_OTHER", SqlDbType.Bit)
            IncludeExpenseTaxesSqlParameter = New System.Data.SqlClient.SqlParameter("@INCL_EXPENSE_TAXES", SqlDbType.Bit)

            UserCodeSqlParameter.Value = UserCode
            FromPostPeriodSqlParameter.Value = FromPostPeriod
            ToPostPeriodSqlParameter.Value = ToPostPeriod
            RecordSourceIDSqlParameter.Value = RecordSourceID
            OfficesSqlParameter.Value = Offices
            DepartmentsSqlParameter.Value = Departments
            OthersSqlParameter.Value = Others
            BasesSqlParameter.Value = Bases
            IncludeCurrentAssetsSqlParameter.Value = IncludeCurrentAssets
            IncludeNonCurrentAssetsSqlParameter.Value = IncludeNonCurrentAssets
            IncludeFixedAssetsSqlParameter.Value = IncludeFixedAssets
            IncludeCurrentLiabilitiesSqlParameter.Value = IncludeCurrentLiabilities
            IncludeNonCurrentLiabilitiesSqlParameter.Value = IncludeNonCurrentLiabilities
            IncludeEquitySqlParameter.Value = IncludeEquity
            IncludeIncomeSqlParameter.Value = IncludeIncome
            IncludeIncomeOtherSqlParameter.Value = IncludeIncomeOther
            IncludeExpeseCOSSqlParameter.Value = IncludeExpeseCOS
            IncludeExpenseOperatingSqlParameter.Value = IncludeExpenseOperating
            IncludeExpenseOtherSqlParameter.Value = IncludeExpenseOther
            IncludeExpenseTaxesSqlParameter.Value = IncludeExpenseTaxes

            Try

                Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.GeneralLedgerDetailByAccountReport)("
                            EXEC dbo.advsp_gl_detail_by_account_dataset_load @USER_CODE, @FROM_PPPERIOD, @TO_PPPERIOD, @RECORD_SOURCE_ID, @OFFICES, @DEPARTMENTS, @OTHERS, @BASES, 
                                            @INCL_CURRENT_ASSESTS, @INCL_NON_CURRENT_ASSESTS, @INCL_FIXED_ASSESTS, @INCL_CURRENT_LIABILITIES, 
                                            @INCL_NON_CURRENT_LIABILITIES, @INCL_EQUITY, @INCL_INCOME, @INCL_INCOME_OTHER, @INCL_EXPENSE_COS, 
                                            @INCL_EXPENSE_OPERATING, @INCL_EXPENSE_OTHER, @INCL_EXPENSE_TAXES",
                UserCodeSqlParameter, FromPostPeriodSqlParameter, ToPostPeriodSqlParameter,
                RecordSourceIDSqlParameter, OfficesSqlParameter, DepartmentsSqlParameter,
                OthersSqlParameter, BasesSqlParameter, IncludeCurrentAssetsSqlParameter,
                IncludeNonCurrentAssetsSqlParameter, IncludeFixedAssetsSqlParameter, IncludeCurrentLiabilitiesSqlParameter,
                IncludeNonCurrentLiabilitiesSqlParameter, IncludeEquitySqlParameter, IncludeIncomeSqlParameter,
                IncludeIncomeOtherSqlParameter, IncludeExpeseCOSSqlParameter, IncludeExpenseOperatingSqlParameter,
                IncludeExpenseOtherSqlParameter, IncludeExpenseTaxesSqlParameter)

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
