Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterVendorSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            PayToVendorCode
            PayToVendorName
            InvoiceType
            InvoiceBalance
            InvoiceTotal
            ApprovedAmount
            VendorEmail
            VendorPaymentManagerEmail
            SpecialTerms
            VendorNotes

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PayToVendorCode As String = String.Empty
        Public Property PayToVendorName As String = String.Empty
        Public Property InvoiceType As String = String.Empty
        Public Property InvoiceBalance As Decimal?
        Public Property InvoiceTotal As Decimal?
        Public Property ApprovedAmount As Decimal?
        Public Property VendorEmail As String = String.Empty
        Public Property VendorPaymentManagerEmail As String = String.Empty
        Public Property SpecialTerms As Integer?
        Public Property VendorNotes As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

