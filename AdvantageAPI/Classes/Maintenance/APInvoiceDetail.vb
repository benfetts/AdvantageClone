<DataContract>
Public Class APInvoiceDetails

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property ID As Integer
    <DataMember>
    Public Property VendorCode As String
    <DataMember>
    Public Property VendorName As String
    <DataMember>
    Public Property InvoiceNumber As String
    <DataMember>
    Public Property InvoiceDescription As String
    <DataMember>
    Public Property InvoiceDate As Nullable(Of Date)
    <DataMember>
    Public Property MediaType As String
    <DataMember>
    Public Property DisbursedAmount As Decimal
    <DataMember>
    Public Property ClientCode As String
    <DataMember>
    Public Property ClientName As String
    <DataMember>
    Public Property JobNumber As Nullable(Of Integer)
    <DataMember>
    Public Property JobComponentNumber As Nullable(Of Short)
    <DataMember>
    Public Property FunctionCode As String
    <DataMember>
    Public Property GLAccountCode As String

#End Region

#Region " Methods "



#End Region

End Class
