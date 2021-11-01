<DataContract>
Public Class APInvoices

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property AP_ID As Nullable(Of Integer)
    <DataMember>
    Public Property VendorCode As String
    <DataMember>
    Public Property InvoiceNumber As String
    <DataMember>
    Public Property InvoiceDescription As String
    <DataMember>
    Public Property InvoiceAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property InvoiceDate As Nullable(Of Date)
    <DataMember>
    Public Property InvoiceDateToPay As Nullable(Of Date)
    <DataMember>
    Public Property TaxAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property DiscountPercent As Nullable(Of Decimal)
    <DataMember>
    Public Property TermsCode As String
    <DataMember>
    Public Property HoldFlag As Nullable(Of Integer)
    <DataMember>
    Public Property VCCStatus As Nullable(Of Short)
    <DataMember>
    Public Property PaymentStatus As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
