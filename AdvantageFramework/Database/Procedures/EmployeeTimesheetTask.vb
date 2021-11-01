Namespace Database.Procedures.EmployeeTimesheetTask

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

        Public Function Load(DbContext As Database.DbContext,
                             UserCode As String, EmployeeCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimesheetTask)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)

            SqlParameterUserCode.Value = UserCode
            SqlParameterEmployeeCode.Value = EmployeeCode

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EmployeeTimesheetTask)("EXEC dbo.advsp_ts_select_tasks @USER_CODE, @EMP_CODE",
                SqlParameterUserCode, SqlParameterEmployeeCode).ToList

        End Function

#End Region

    End Module

End Namespace
