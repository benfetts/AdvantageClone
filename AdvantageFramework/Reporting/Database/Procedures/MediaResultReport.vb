Namespace Reporting.Database.Procedures.MediaResultReport

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

        Public Function Load(ByVal DbContext As Database.DbContext, ByVal Criteria As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal SelectedOffices As Generic.List(Of String), ByVal SelectedClients As Generic.List(Of String), ByVal SelectedDivisions As Generic.List(Of String), ByVal SelectedProducts As Generic.List(Of String), BroadcastDates As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.MediaResultReport)

            'objects            
            Dim SqlParameterFromDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterToDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCriteria As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductList As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterBroadcastDates As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterFromDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            SqlParameterToDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            SqlParameterCriteria = New System.Data.SqlClient.SqlParameter("@CRITERIA", SqlDbType.SmallInt)
            SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OfficeCodeList", SqlDbType.VarChar)
            SqlParameterClientList = New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            SqlParameterDivisionList = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            SqlParameterProductList = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)

            SqlParameterBroadcastDates = New System.Data.SqlClient.SqlParameter("@broadcast_dates", SqlDbType.Bit)
            SqlParameterBroadcastDates.Value = BroadcastDates.ToString

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = DbContext.UserCode

            SqlParameterFromDate.Value = FromDate.ToShortDateString
            SqlParameterToDate.Value = ToDate.ToShortDateString
            SqlParameterCriteria.Value = Criteria

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

            Load = DbContext.Database.SqlQuery(Of Database.Classes.MediaResultReport)("EXEC dbo.advsp_digital_results_rpt @START_DATE, @END_DATE, @CRITERIA, @OfficeCodeList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @broadcast_dates, @user_id",
                                                                                       SqlParameterFromDate, SqlParameterToDate, SqlParameterCriteria, SqlParameterOfficeList, SqlParameterClientList, SqlParameterDivisionList, SqlParameterProductList, SqlParameterBroadcastDates, SqlParameterUserCode)

        End Function

#End Region

    End Module

End Namespace

