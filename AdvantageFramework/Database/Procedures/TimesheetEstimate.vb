Namespace Database.Procedures.TimesheetEstimate

    <HideModuleName()> _
    Public Module Methods

        Public Function Load(DbContext As Database.DbContext, JobNumber As Integer, JobComponentNumber As Integer,
                             FunctionCode As String, EmployeeCode As String, EmployeeOnly As Boolean) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.TimesheetEstimate)

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobCompNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeOnly As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobCompNumber = New System.Data.SqlClient.SqlParameter("@JobCompNumber", SqlDbType.Int)
            SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@FunctionCode", SqlDbType.VarChar)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
            SqlParameterEmployeeOnly = New System.Data.SqlClient.SqlParameter("@EmpOnly", SqlDbType.Bit)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobCompNumber.Value = JobComponentNumber
            SqlParameterFunctionCode.Value = FunctionCode
            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterEmployeeOnly.Value = If(EmployeeOnly, 1, 0)

            Load = DbContext.Database.SqlQuery(Of Database.Classes.TimesheetEstimate)("EXEC dbo.usp_wv_ts_ddEstimate @JobNumber, @JobCompNumber, @FunctionCode, @EmpCode, @EmpOnly",
                SqlParameterJobNumber, SqlParameterJobCompNumber, SqlParameterFunctionCode, SqlParameterEmployeeCode, SqlParameterEmployeeOnly).ToList

        End Function

    End Module

End Namespace