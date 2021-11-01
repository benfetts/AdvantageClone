Namespace Reporting.Database.Procedures.MediaResultsComparisonByClientAndType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaResultsComparisonByClientAndTypeReport)

            'objects
            Dim SelectedOffices As Generic.List(Of String) = Nothing
            Dim SelectedClients As Generic.List(Of String) = Nothing
            Dim SelectedDivisions As Generic.List(Of String) = Nothing
            Dim SelectedProducts As Generic.List(Of String) = Nothing

            SelectedOffices = ParameterDictionary("SelectedOffices")

            SelectedClients = ParameterDictionary("SelectedClients")

            SelectedDivisions = ParameterDictionary("SelectedDivisions")

            SelectedProducts = ParameterDictionary("SelectedProducts")

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.StartDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.EndDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeVendor.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeSalesClass.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludePeriod.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeAdNumber.ToString),
                        SelectedOffices, SelectedClients, SelectedDivisions, SelectedProducts)

        End Function
        Public Function Load(ReportingDbContext As Reporting.Database.DbContext,
                             StartDate As Date, EndDate As Date,
                             IncludeVendor As Boolean, IncludeSalesClass As Boolean, IncludePeriod As Boolean, IncludeAdNumber As Boolean,
                             ByVal SelectedOffices As Generic.List(Of String), ByVal SelectedClients As Generic.List(Of String),
                             ByVal SelectedDivisions As Generic.List(Of String), ByVal SelectedProducts As Generic.List(Of String)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaResultsComparisonByClientAndTypeReport)

            'objects
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeVendor As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeSalesClass As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludePeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeAdNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductList As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = ReportingDbContext.UserCode

            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.DateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.DateTime)
            SqlParameterIncludeVendor = New System.Data.SqlClient.SqlParameter("@include_vendor", SqlDbType.Bit)
            SqlParameterIncludeSalesClass = New System.Data.SqlClient.SqlParameter("@include_salesclass", SqlDbType.Bit)
            SqlParameterIncludePeriod = New System.Data.SqlClient.SqlParameter("@include_period", SqlDbType.Bit)
            SqlParameterIncludeAdNumber = New System.Data.SqlClient.SqlParameter("@include_ad", SqlDbType.Bit)
            SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OfficeCodeList", SqlDbType.VarChar)
            SqlParameterClientList = New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            SqlParameterDivisionList = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            SqlParameterProductList = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)

            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterIncludeVendor.Value = IncludeVendor
            SqlParameterIncludeSalesClass.Value = IncludeSalesClass
            SqlParameterIncludePeriod.Value = IncludePeriod
            SqlParameterIncludeAdNumber.Value = IncludeAdNumber

            If SelectedOffices Is Nothing Then

                SqlParameterOfficeList.Value = System.DBNull.Value

            ElseIf SelectedOffices.Count = 0 Then

                SqlParameterOfficeList.Value = System.DBNull.Value

            Else

                SqlParameterOfficeList.Value = Join(SelectedOffices.ToArray, ",")

            End If

            If SelectedClients Is Nothing Then

                SqlParameterClientList.Value = System.DBNull.Value

            ElseIf SelectedClients.Count = 0 Then

                SqlParameterClientList.Value = System.DBNull.Value

            Else

                SqlParameterClientList.Value = Join(SelectedClients.ToArray, ",")

            End If

            If SelectedDivisions Is Nothing Then

                SqlParameterDivisionList.Value = System.DBNull.Value

            ElseIf SelectedDivisions.Count = 0 Then

                SqlParameterDivisionList.Value = System.DBNull.Value

            Else

                SqlParameterDivisionList.Value = Join(SelectedDivisions.ToArray, ",")

            End If

            If SelectedProducts Is Nothing Then

                SqlParameterProductList.Value = System.DBNull.Value

            ElseIf SelectedProducts.Count = 0 Then

                SqlParameterProductList.Value = System.DBNull.Value

            Else

                SqlParameterProductList.Value = Join(SelectedProducts.ToArray, ",")

            End If

            Try

                Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.MediaResultsComparisonByClientAndTypeReport)("EXEC dbo.advsp_media_results_comparison_by_client_and_type_report @start_date, @end_date, @include_vendor, @include_salesclass, @include_period, @include_ad, @OfficeCodeList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @user_id",
                    SqlParameterStartDate, SqlParameterEndDate, SqlParameterIncludeVendor, SqlParameterIncludeSalesClass, SqlParameterIncludePeriod, SqlParameterIncludeAdNumber, SqlParameterOfficeList, SqlParameterClientList, SqlParameterDivisionList, SqlParameterProductList, SqlParameterUserCode)

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
