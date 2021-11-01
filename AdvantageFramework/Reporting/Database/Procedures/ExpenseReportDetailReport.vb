Namespace Reporting.Database.Procedures.ExpenseReportDetailReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal InvoiceNumber As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ExpenseReportDetailReport)

            'objects
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@INV_NBR", SqlDbType.Int)
            SqlParameterInvoiceNumber.Value = InvoiceNumber

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.ExpenseReportDetailReport)("EXEC dbo.advsp_exp_rpt_load_dtl_rpt @INV_NBR", SqlParameterInvoiceNumber)

        End Function

#End Region

    End Module

End Namespace



