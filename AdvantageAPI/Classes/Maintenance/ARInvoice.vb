<DataContract>
Public Class ARInvoices

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property JobNumber As Nullable(Of Integer)
    <DataMember>
    Public Property JobComponentNumber As Nullable(Of Short)
    <DataMember>
    Public Property InvoiceNumber As Integer
    <DataMember>
    Public Property InvoiceSequence As Short
    <DataMember>
    Public Property InvoiceDate As Nullable(Of Date)
    <DataMember>
    Public Property DueDate As Nullable(Of Date)
    <DataMember>
    Public Property PayDays As Integer
    <DataMember>
    Public Property JobComponentInvoiceAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property InvoiceAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property CashReceiptAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property LastCashReceiptDate As Nullable(Of Date)
    <DataMember>
    Public Property InvoiceBalance As Nullable(Of Decimal)
    <DataMember>
    Public Property DaysToPay As Integer
    <DataMember>
    Public Property PendingCashReceipts As Boolean
    <DataMember>
    Public Property SalePostPeriod As String
    <DataMember>
    Public Property CashReceiptPostPeriod As String

#End Region

#Region " Methods "



#End Region

End Class
