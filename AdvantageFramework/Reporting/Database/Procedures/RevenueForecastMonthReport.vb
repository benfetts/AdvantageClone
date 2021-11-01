Namespace Reporting.Database.Procedures.RevenueForecastMonthReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.RevenueForecastMonthReport)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.StartingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.EndingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedOffices.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedSalesClass.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.CurrentPeriod.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.DisplayOption.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.ActualizeDate.ToString))

        End Function

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal StartingPostPeriodCode As String,
                             ByVal EndingPostPeriodCode As String, ByVal SelectedOffices As String, ByVal SelectedSalesClass As String,
                             ByVal CurrentPeriod As String, ByVal DisplayOption As Integer, ByVal ActualizeDate As DateTime) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.RevenueForecastMonthReport)

            Dim SqlParameterStartPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedOffices As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedSalesClass As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCurrentPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDisplayOption As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterActualizeDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterStartPeriod = New System.Data.SqlClient.SqlParameter("@START_PERIOD", SqlDbType.VarChar)
            SqlParameterEndPeriod = New System.Data.SqlClient.SqlParameter("@END_PERIOD", SqlDbType.VarChar)
            SqlParameterDateType = New System.Data.SqlClient.SqlParameter("@DATE_TYPE", SqlDbType.Int)
            SqlParameterSelectedOffices = New System.Data.SqlClient.SqlParameter("@OFFICE_CODES", SqlDbType.VarChar)
            SqlParameterSelectedSalesClass = New System.Data.SqlClient.SqlParameter("@SALES_CLASS_CODES", SqlDbType.VarChar)
            SqlParameterCurrentPeriod = New System.Data.SqlClient.SqlParameter("@CURRENT_PERIOD", SqlDbType.VarChar)
            SqlParameterDisplayOption = New System.Data.SqlClient.SqlParameter("@DISPLAY_OPTION", SqlDbType.SmallInt)
            SqlParameterActualizeDate = New System.Data.SqlClient.SqlParameter("@ACTUALIZE_DATE", SqlDbType.SmallDateTime)

            SqlParameterStartPeriod.Value = StartingPostPeriodCode
            SqlParameterEndPeriod.Value = EndingPostPeriodCode
            SqlParameterDateType.Value = 0
            If SelectedOffices Is Nothing Then
                SqlParameterSelectedOffices.Value = DBNull.Value
            Else
                SqlParameterSelectedOffices.Value = SelectedOffices
            End If
            If SelectedSalesClass Is Nothing Then
                SqlParameterSelectedSalesClass.Value = DBNull.Value
            Else
                SqlParameterSelectedSalesClass.Value = SelectedSalesClass
            End If
            SqlParameterCurrentPeriod.Value = CurrentPeriod
            SqlParameterDisplayOption.Value = DisplayOption
            If ActualizeDate = Nothing Then
                SqlParameterActualizeDate.Value = DBNull.Value
            Else
                SqlParameterActualizeDate.Value = ActualizeDate
            End If

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.RevenueForecastMonthReport)("EXEC dbo.usp_wv_Revenue_Forecast_Month_Report @DATE_TYPE, @START_PERIOD, @END_PERIOD, @OFFICE_CODES, @SALES_CLASS_CODES, @CURRENT_PERIOD, @DISPLAY_OPTION, @ACTUALIZE_DATE",
                SqlParameterDateType, SqlParameterStartPeriod, SqlParameterEndPeriod, SqlParameterSelectedOffices, SqlParameterSelectedSalesClass, SqlParameterCurrentPeriod, SqlParameterDisplayOption, SqlParameterActualizeDate)

        End Function

#End Region

    End Module

End Namespace
