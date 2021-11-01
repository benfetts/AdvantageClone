Namespace Database.Procedures.EmployeeTimeTemplateComplex

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

        Public Function Load(DbContext As Database.DbContext, EmployeeCode As String, UserCode As String) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeTemplateComplex)

            'objects
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterUserCode.Value = UserCode

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EmployeeTimeTemplateComplex)("EXEC dbo.advsp_ts_get_emp_time_template @EMP_CODE, @USER_CODE",
                SqlParameterEmployeeCode, SqlParameterUserCode).ToList

        End Function

#End Region

    End Module

End Namespace

