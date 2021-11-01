Namespace Database.Procedures.DirectTime

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

        Public Function LoadByEmployee(DbContext As AdvantageFramework.Database.DbContext,
                                                    StartDate As String, EndDate As String, EmployeeCode As String, ByVal clientcode As String, ByVal job As Integer, ByVal comp As Integer, ByVal UserID As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.DirectTime)

            Dim SqlParameterDateType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterDateType = New System.Data.SqlClient.SqlParameter("@DATE_TYPE", SqlDbType.Int)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmployeeCode", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@ClientCode", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@Job", SqlDbType.Int)
            SqlParameterComponentNumber = New System.Data.SqlClient.SqlParameter("@Comp", SqlDbType.SmallInt)
            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)

            SqlParameterDateType.Value = 0
            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterClientCode.Value = clientcode
            SqlParameterJobNumber.Value = job
            SqlParameterComponentNumber.Value = comp
            SqlParameterUserID.Value = UserID

            LoadByEmployee = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.DirectTime)("EXEC dbo.advsp_direct_time_load_do @DATE_TYPE, @START_DATE, @END_DATE, @EmployeeCode, @ClientCode, @Job, @Comp, @UserID",
                SqlParameterDateType, SqlParameterStartDate, SqlParameterEndDate, SqlParameterEmployeeCode, SqlParameterClientCode, SqlParameterJobNumber, SqlParameterComponentNumber, SqlParameterUserID).ToList

        End Function

#End Region

    End Module

End Namespace