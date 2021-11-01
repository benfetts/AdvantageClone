Namespace Database.Procedures.JobAmountComplexType

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

        Public Function Load(DbContext As AdvantageFramework.BaseClasses.DbContext,
                             Optional ByVal IncludeClientOOP As Boolean = True, Optional ByVal IncludeEmployeeTime As Boolean = True,
                             Optional ByVal IncludeProduction As Boolean = True, Optional ByVal IncludeIncomeOnly As Boolean = True,
                             Optional ByVal IncludeAdvanceBilling As Boolean = True, Optional ByVal IncludeEstimate As Boolean = True,
                             Optional ByVal IncludeOpenPO As Boolean = True, Optional ByVal StartDate As Date? = Nothing,
                             Optional ByVal EndDate As Date? = Nothing, Optional ByVal IsEntity As Boolean = False) As System.Collections.Generic.List(Of Database.Classes.JobAmount)

            'objects
            Dim SqlParameterIncludeClientOOP As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeEmployeeTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeProduction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeIncomeOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeAdvanceBilling As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeEstimate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeOpenPO As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsEntity As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterIncludeClientOOP = New System.Data.SqlClient.SqlParameter("@IncludeClientOOP", SqlDbType.Bit)
            SqlParameterIncludeEmployeeTime = New System.Data.SqlClient.SqlParameter("@IncludeEmployeeTime", SqlDbType.Bit)
            SqlParameterIncludeProduction = New System.Data.SqlClient.SqlParameter("@IncludeProduction", SqlDbType.Bit)
            SqlParameterIncludeIncomeOnly = New System.Data.SqlClient.SqlParameter("@IncludeIncomeOnly", SqlDbType.Bit)
            SqlParameterIncludeAdvanceBilling = New System.Data.SqlClient.SqlParameter("@IncludeAdvanceBilling", SqlDbType.Bit)
            SqlParameterIncludeEstimate = New System.Data.SqlClient.SqlParameter("@IncludeEstimate", SqlDbType.Bit)
            SqlParameterIncludeOpenPO = New System.Data.SqlClient.SqlParameter("@IncludeOpenPO", SqlDbType.Bit)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            SqlParameterIsEntity = New System.Data.SqlClient.SqlParameter("@IsEntity", SqlDbType.Bit)

            SqlParameterIncludeClientOOP.Value = IncludeClientOOP
            SqlParameterIncludeEmployeeTime.Value = IncludeEmployeeTime
            SqlParameterIncludeProduction.Value = IncludeProduction
            SqlParameterIncludeIncomeOnly.Value = IncludeIncomeOnly
            SqlParameterIncludeAdvanceBilling.Value = IncludeAdvanceBilling
            SqlParameterIncludeEstimate.Value = IncludeEstimate
            SqlParameterIncludeOpenPO.Value = IncludeOpenPO
            SqlParameterIsEntity.Value = IsEntity

            If StartDate Is Nothing Then

                SqlParameterStartDate.Value = System.DBNull.Value

            Else

                SqlParameterStartDate.Value = StartDate.Value

            End If

            If EndDate Is Nothing Then

                SqlParameterEndDate.Value = System.DBNull.Value

            Else

                SqlParameterEndDate.Value = EndDate.Value

            End If

            Load = DbContext.Database.SqlQuery(Of Database.Classes.JobAmount)("EXEC dbo.advsp_job_amounts_prod @IncludeClientOOP, @IncludeEmployeeTime, @IncludeProduction, @IncludeIncomeOnly, @IncludeAdvanceBilling, @IncludeEstimate, @IncludeOpenPO, @StartDate, @EndDate, @IsEntity",
                SqlParameterIncludeClientOOP, SqlParameterIncludeEmployeeTime, SqlParameterIncludeProduction, SqlParameterIncludeIncomeOnly, SqlParameterIncludeAdvanceBilling,
                SqlParameterIncludeEstimate, SqlParameterIncludeOpenPO, SqlParameterStartDate, SqlParameterEndDate, SqlParameterIsEntity).ToList

        End Function

#End Region

    End Module

End Namespace

