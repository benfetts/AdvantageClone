Namespace Reporting.Database.Procedures.DigitalResultsComparisonReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.DigitalResultsComparisonReport)

            Dim SelectedOffices As Generic.List(Of String) = Nothing
            Dim SelectedClients As Generic.List(Of String) = Nothing
            Dim SelectedDivisions As Generic.List(Of String) = Nothing
            Dim SelectedProducts As Generic.List(Of String) = Nothing
            Dim BroadcastDates As Boolean = 0

            SelectedOffices = ParameterDictionary("SelectedOffices")

            SelectedClients = ParameterDictionary("SelectedClients")

            SelectedDivisions = ParameterDictionary("SelectedDivisions")

            SelectedProducts = ParameterDictionary("SelectedProducts")

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.DigitalResultsComparisonParameters.OrderStatus.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.DigitalResultsComparisonParameters.StartDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.DigitalResultsComparisonParameters.EndDate.ToString),
                        SelectedOffices, SelectedClients, SelectedDivisions, SelectedProducts, BroadcastDates)

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext,
                             ByVal OrderStatus As String, ByVal StartDate As Date, ByVal EndDate As Date,
                             ByVal SelectedOffices As Generic.List(Of String), ByVal SelectedClients As Generic.List(Of String),
                             ByVal SelectedDivisions As Generic.List(Of String), ByVal SelectedProducts As Generic.List(Of String), BroadcastDates As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.DigitalResultsComparisonReport)

            'objects
            Dim SqlParameterOrderStatus As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductList As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterBroadcastDates As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderStatus = New System.Data.SqlClient.SqlParameter("@order_status", SqlDbType.VarChar)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.DateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.DateTime)
            SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OfficeCodeList", SqlDbType.VarChar)
            SqlParameterClientList = New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            SqlParameterDivisionList = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            SqlParameterProductList = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)

            SqlParameterBroadcastDates = New System.Data.SqlClient.SqlParameter("@broadcast_dates", SqlDbType.Bit)
            SqlParameterBroadcastDates.Value = BroadcastDates.ToString

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = ReportingDbContext.UserCode

            SqlParameterOrderStatus.Value = OrderStatus
            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate

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

                Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.DigitalResultsComparisonReport)("EXEC dbo.advsp_digital_results_comparison_report @order_status, @start_date, @end_date, @OfficeCodeList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @broadcast_dates, @user_id",
                                                                                                                 SqlParameterOrderStatus, SqlParameterStartDate, SqlParameterEndDate, SqlParameterOfficeList, SqlParameterClientList, SqlParameterDivisionList, SqlParameterProductList, SqlParameterBroadcastDates, SqlParameterUserCode)

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
