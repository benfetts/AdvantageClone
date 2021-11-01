Namespace BillingCommandCenter.Database.Procedures.InvoiceAssignedProductionCoopComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingUser As String, ByVal JobNumber As Integer, JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.InvoiceAssignedCoop)

            'objects
            Dim BillingUserObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim JobNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim JobComponentNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingUserObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("billing_user_in", BillingUser)
            JobNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("job_number", JobNumber)
            JobComponentNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("job_component_nbr", JobComponentNumber)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.InvoiceAssignedCoop)("BCCObjectContextConnection.LoadInvoiceAssignedCoop", BillingUserObjectParameter, JobNumberObjectParameter, JobComponentNumberObjectParameter)

        End Function

#End Region

    End Module

End Namespace