Namespace Database.Procedures.EmployeeTimeComplex

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

        Public Function Load(DbContext As Database.DbContext, EmployeeCode As String,
                             StartDate As Date, EndDate As Date, SortColumn As String,
                             UserCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex)

            'objects
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSortColumn As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
            SqlParameterSortColumn = New System.Data.SqlClient.SqlParameter("@SortColumn", SqlDbType.VarChar)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterSortColumn.Value = If(SortColumn Is Nothing, "", SortColumn)
            SqlParameterUserCode.Value = UserCode

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex)("EXEC dbo.usp_wv_ts_GetTimeSheet @emp_code, @StartDate, @EndDate, @SortColumn, @USER_CODE",
                SqlParameterEmployeeCode, SqlParameterStartDate, SqlParameterEndDate, SqlParameterSortColumn, SqlParameterUserCode).ToList

        End Function

#End Region

    End Module

End Namespace
