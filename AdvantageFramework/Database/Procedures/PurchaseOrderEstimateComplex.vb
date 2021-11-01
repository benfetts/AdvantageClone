Namespace Database.Procedures.PurchaseOrderEstimateComplex

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

        Public Function Load(DbContext As AdvantageFramework.Database.DbContext, [Function] As Integer,
                             JobNumber As Integer, JobComponentNumber As Integer, FunctionCode As String) As System.Collections.Generic.List(Of Database.Classes.PurchaseOrderEstimate)

            'objects
            Dim SqlParameterFunction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterFunction = New System.Data.SqlClient.SqlParameter("@funct", SqlDbType.Int)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.Int)
            SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@fnc_code", SqlDbType.VarChar)

            SqlParameterFunction.Value = [Function]
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterFunctionCode.Value = FunctionCode

            Try

                Load = DbContext.Database.SqlQuery(Of Database.Classes.PurchaseOrderEstimate)("EXEC dbo.proc_WV_PO_Estimate_LoadByJobComp @funct, @job_number, @job_component_nbr, @fnc_code",
                    SqlParameterFunction, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterFunctionCode).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
