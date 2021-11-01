Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterBankDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            BankCode
            BankDescription
            BankCashAccount
            BankCashAccountDescription
            BankDiscountAccount
            BankDiscountAccountDescription
            BankLastCheckCompleted
            OpenBatchFlag

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BankCode As String = String.Empty
        Public Property BankDescription As String = String.Empty
        Public Property BankCashAccountDescription As String = String.Empty
        Public Property BankCashAccount As String = String.Empty
        Public Property BankDiscountAccount As String = String.Empty
        Public Property BankDiscountAccountDescription As String = String.Empty
        Public Property BankLastCheckCompleted As Integer?
        Public Property OpenBatchFlag As Integer?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

