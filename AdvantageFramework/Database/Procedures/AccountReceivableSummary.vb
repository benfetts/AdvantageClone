Namespace Database.Procedures.AccountReceivableSummary

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

        Public Function LoadByARInvoiceSeqType(ByVal DbContext As Database.DbContext, ByVal ARInvoiceNumber As Integer, ByVal ARInvoiceSequence As Short, ByVal ARType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableSummary)

            LoadByARInvoiceSeqType = From AccountReceivableSummary In DbContext.GetQuery(Of Database.Entities.AccountReceivableSummary)
                                     Where AccountReceivableSummary.ARInvoiceNumber = ARInvoiceNumber AndAlso
                                           AccountReceivableSummary.ARInvoiceSequence = ARInvoiceSequence AndAlso
                                           AccountReceivableSummary.ARType = ARType
                                     Select AccountReceivableSummary

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountReceivableSummary)

            Load = From AccountReceivableSummary In DbContext.GetQuery(Of Database.Entities.AccountReceivableSummary)
                   Select AccountReceivableSummary

        End Function

#End Region

    End Module

End Namespace
