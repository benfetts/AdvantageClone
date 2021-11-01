Namespace Database.Procedures.TimesheetQuoteVsActual

    <HideModuleName()> _
    Public Module Methods

        Public Function Load(DbContext As Database.DbContext, JobNumber As Integer, JobComponentNumber As Integer,
                             FunctionCode As String, EmployeeCode As String, EmployeeOnly As Boolean, View As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.TimesheetQuoteVsActual)

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobCompNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterView As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobCompNumber = New System.Data.SqlClient.SqlParameter("@JobCompNumber", SqlDbType.Int)
            SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@FunctionCode", SqlDbType.VarChar)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
            SqlParameterEmployeeOnly = New System.Data.SqlClient.SqlParameter("@EmpOnly", SqlDbType.Bit)
            SqlParameterView = New System.Data.SqlClient.SqlParameter("@View", SqlDbType.Int)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobCompNumber.Value = JobComponentNumber
            SqlParameterFunctionCode.Value = FunctionCode
            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterEmployeeOnly.Value = If(EmployeeOnly, 1, 0)
            SqlParameterView.Value = View

            'Load = DbContext.Database.SqlQuery(Of Database.Classes.TimesheetQuoteVsActual)("LoadTimesheetQuoteVsActualData",
            '    SqlParameterJobNumber).ToList

            Load = DbContext.Database.SqlQuery(Of Database.Classes.TimesheetQuoteVsActual)("EXEC dbo.usp_wv_ts_ddQuoteVsActual @JobNumber, @JobCompNumber, @FunctionCode, @EmpCode, @EmpOnly, @View",
                SqlParameterJobNumber, SqlParameterJobCompNumber, SqlParameterFunctionCode, SqlParameterEmployeeCode, SqlParameterEmployeeOnly, SqlParameterView).ToList


        End Function

    End Module

End Namespace