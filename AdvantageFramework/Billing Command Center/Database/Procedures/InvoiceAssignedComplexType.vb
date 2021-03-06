Namespace BillingCommandCenter.Database.Procedures.InvoiceAssignedComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingUser As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.InvoiceAssigned)

            'objects
            Dim BillingUserObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingUserObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bill_user_in", BillingUser)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.InvoiceAssigned)("BCCObjectContextConnection.LoadInvoiceAssigned", BillingUserObjectParameter)

        End Function

#End Region

    End Module

End Namespace
