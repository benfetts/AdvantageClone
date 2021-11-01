Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterInvoiceHeader

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            APId
            InvoiceNumber
            PayMethod
            InvoiceType
            ApprovedAmount
            DiscApprovedAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property APId As Integer
        Public Property InvoiceNumber As String = String.Empty
        Public Property PayMethod As String = String.Empty
        Public Property InvoiceType As String = String.Empty
        Public Property ApprovedAmount As Decimal?
        Public Property DiscApprovedAmount As Decimal?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

