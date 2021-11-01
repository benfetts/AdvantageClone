Namespace Reporting.Database.Procedures.MediaPlanReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Reporting.Database.Classes.MediaPlanReport)

            Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SelectedOffices As Generic.List(Of String) = Nothing
            Dim SelectedClients As Generic.List(Of String) = Nothing
            Dim SelectedDivisions As Generic.List(Of String) = Nothing
            Dim SelectedProducts As Generic.List(Of String) = Nothing

            Dim SqlParameterBroadcastDates As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SelectedOffices = ParameterDictionary(AdvantageFramework.Reporting.MediaPlanParameters.SelectedOffices.ToString)
            SelectedClients = ParameterDictionary(AdvantageFramework.Reporting.MediaPlanParameters.SelectedClients.ToString)
            SelectedDivisions = ParameterDictionary(AdvantageFramework.Reporting.MediaPlanParameters.SelectedDivisions.ToString)
            SelectedProducts = ParameterDictionary(AdvantageFramework.Reporting.MediaPlanParameters.SelectedProducts.ToString)

            SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OfficeCodeList", SqlDbType.VarChar)
            SqlParameterClientList = New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            SqlParameterDivisionList = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            SqlParameterProductList = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)

            SqlParameterBroadcastDates = New System.Data.SqlClient.SqlParameter("@broadcast_dates", SqlDbType.Bit)
            SqlParameterBroadcastDates.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaPlanParameters.BroadcastDates.ToString)

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = ReportingDbContext.UserCode

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


            Load = ReportingDbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.MediaPlanReport)("exec dbo.advsp_media_plan_report @OfficeCodeList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @broadcast_dates, @user_id",
                                                 SqlParameterOfficeList, SqlParameterClientList, SqlParameterDivisionList, SqlParameterProductList, SqlParameterBroadcastDates, SqlParameterUserCode)


        End Function

#End Region

    End Module

End Namespace
