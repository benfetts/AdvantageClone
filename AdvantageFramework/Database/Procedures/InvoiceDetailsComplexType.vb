Namespace Database.Procedures.InvoiceDetailsComplexType

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
                             InvoiceNumber As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.InvoiceDetails)

            'objects
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar)
            SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@inv_nbr", SqlDbType.Int)

            SqlParameterEmployeeCode.Value = EmployeeCode
            SqlParameterInvoiceNumber.Value = InvoiceNumber

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.InvoiceDetails)("EXEC dbo.usp_wv_get_inv_dtl @emp_code, @inv_nbr",
                SqlParameterEmployeeCode, SqlParameterInvoiceNumber).ToList

        End Function
#End Region

    End Module

End Namespace