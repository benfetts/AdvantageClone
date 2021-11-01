Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterInvoiceDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            APId
            Pay
            PayMethod
            PayToVendorCode
            PayToVendorName
            PayToVendorEmail
            PayToVendorNotes
            InvoiceNumber
            InvoiceType
            DateToPay
            BalanceToPay
            ApprovedAmount
            GLAccount
            VendorCode
            VendorName
            ClientCode
            InvoiceDescription
            InvoiceDate
            InvoiceTotal
            InvoiceBalance
            InvoicePaidAmount
            DiscountPercentage
            DiscountAvailable
            DiscountApproved
            WithholdingTax
            PaidPreviously
            NonBillableAmount
            BillableAmount
            DirectBillAmount
            ProdAdvanceBalance
            CashReceived
            TotalQualified
            PaidByClientAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property APId As Integer?
        Public Property Pay As Integer?
        Public Property PayMethod As String = String.Empty
        Public Property PayToVendorCode As String = String.Empty
        Public Property PayToVendorName As String = String.Empty
        Public Property PayToVendorNotes As String = String.Empty
        Public Property InvoiceNumber As String = String.Empty
        Public Property InvoiceType As String = String.Empty
        Public Property DateToPay As Date?
        Public Property BalanceToPay As Decimal?
        Public Property ApprovedAmount As Decimal?
        Public Property GLAccount As String = String.Empty
        Public Property VendorCode As String = String.Empty
        Public Property VendorName As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property InvoiceDescription As String = String.Empty
        Public Property InvoiceDate As Date?
        Public Property InvoiceTotal As Decimal?
        Public Property InvoiceBalance As Decimal?
        Public Property InvoicePaidAmount As Decimal?
        Public Property DiscountPercentage As String = String.Empty
        Public Property DiscountAvailable As Decimal?
        Public Property DiscountApproved As Decimal?
        Public Property WithholdingTax As Decimal?
        Public Property PaidPreviously As Decimal?
        Public Property NonBillableAmount As Decimal?
        Public Property BillableAmount As Decimal?
        Public Property DirectBillAmount As Decimal?
        Public Property ProdAdvanceBalance As Decimal?
        Public Property CashReceived As Decimal?
        Public Property TotalQualified As Decimal?
        Public Property PaidByClientAmount As Decimal?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

