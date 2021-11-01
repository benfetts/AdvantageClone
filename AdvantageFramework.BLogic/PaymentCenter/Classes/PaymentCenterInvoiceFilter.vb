Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterInvoiceFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            BatchStatus
            BatchId
            BankCode
            APAccountCode
            VendorCode
            ClientCode
            DateToPayCutoff
            CheckDate
            PaidByClient
            Production
            GLDist
            Television
            Radio
            Newspaper
            Magazine
            Internet
            Outdoor
            'VCCStatus
            'DefaultBankStatus

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BatchStatus As String = String.Empty
        Public Property BatchId As Short? = 0
        Public Property BankCode As String = String.Empty
        Public Property APAccountCode As String = String.Empty
        Public Property VendorCode As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DateToPayCutoff As Date?
        Public Property CheckDate As Date?
        Public Property PaidByClient As Short? = 0
        Public Property Production As Short? = 0
        Public Property GLDist As Short? = 0
        Public Property Television As Short? = 0
        Public Property Radio As Short? = 0
        Public Property Newspaper As Short? = 0
        Public Property Magazine As Short? = 0
        Public Property Internet As Short? = 0
        Public Property Outdoor As Short? = 0
        'Public Property VCCStatus As Integer
        'Public Property DefaultBankStatus As String

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

