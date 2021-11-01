Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterAccountsPayablePaymentHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            APId
            APSequence
            BankCode
            APCheckNumber
            CheckSequence
            APCheckDate
            APAmount
            APDiscountAmount
            APCashAccount
            GLAccountCode
            GLId
            GLCashSequence
            GLAPSequence
            PostingPeriod
            CreateDate
            UserId
            VendorTaxableAmount
            VendorServiceTaxRate
            VendorServiceTaxAmount
            PaymentType

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property APId As Integer?
        Public Property APSequence As Integer?
        Public Property BankCode As String = Nothing
        Public Property APCheckNumber As Integer?
        Public Property CheckSequence As Integer?
        Public Property APCheckDate As Date?
        Public Property APAmount As Decimal?
        Public Property APDiscountAmount As Decimal?
        Public Property APCashAccount As String = Nothing
        Public Property GLAccountCode As String = Nothing
        Public Property GLId As Integer?
        Public Property GLCashSequence As Integer?
        Public Property GLAPSequence As Integer?
        Public Property PostingPeriod As String = Nothing
        Public Property CreateDate As Date?
        Public Property UserId As String = Nothing
        Public Property VendorTaxableAmount As Decimal?
        Public Property VendorServiceTaxRate As Decimal?
        Public Property VendorServiceTaxAmount As Decimal?
        Public Property PaymentType As String = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

