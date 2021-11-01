﻿Namespace BillingCommandCenter.Database.Procedures.InvoiceAssignedJournalEntryComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingUser As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.InvoiceAssignedJournalEntry)

            'objects
            Dim BillingUserObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim ReturnValueObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingUserObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bill_user_in", BillingUser)
            ReturnValueObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ret_val", 0)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.InvoiceAssignedJournalEntry)("BCCObjectContextConnection.LoadInvoiceAssignedJournalEntry", BillingUserObjectParameter, ReturnValueObjectParameter)

        End Function

#End Region

    End Module

End Namespace