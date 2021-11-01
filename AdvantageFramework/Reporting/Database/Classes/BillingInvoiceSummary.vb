Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BillingInvoiceSummary

#Region " Constants "

#End Region

#Region " Enum "
        Public Enum Properties
            Market
            Station
            Vendor
            Client
            Division
            Product
            OrderNumber
            MediaType
            InvoiceNumber
            InvoiceDate
            EntryDate
            InvoiceMonth
            InvoiceStatus
            Gross
            Net
            Spots
            '----
            VendorNumber
            VendorCode
        End Enum
#End Region

#Region " Variables "
        Public Property Market As String
        Public Property Station As String
        Public Property Vendor As String
        Public Property Client As String
        Public Property Division As String
        Public Property Product As String
        Public Property OrderNumber As String
        Public Property MediaType As String
        Public Property InvoiceNumber As String
        Public Property InvoiceDate As Date
        Public Property EntryDate As Date
        Public Property InvoiceMonth As String
        Public Property InvoiceStatus As String
        Public Property Gross As Decimal
        Public Property Net As Decimal
        Public Property Spots As Integer
        '----
        Public Property VendorNumber As String
        Public Property VendorCode As String
#End Region

#Region " Properties "

#End Region

#Region " Methods "

#End Region

    End Class
End Namespace


