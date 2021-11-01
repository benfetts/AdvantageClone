Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterCompletedBatchCheckDetails

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            APId
            CheckNumber
            PaymentType
            PaymentTypeDetail
            GLAccount
            CheckDate
            PayToVendorName
            PayToVendorCode
            CheckAmount
            DiscountAmount

        End Enum
#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property APId As Integer?
        Public Property CheckNumber As String = String.Empty
        Public Property PaymentType As String = String.Empty
        Public Property PaymentTypeDetail As String = String.Empty
        Public Property GLAccount As String = String.Empty
        Public Property CheckDate As Date?
        Public Property PayToVendorName As String = String.Empty
        Public Property PayToVendorCode As String = String.Empty
        Public Property CheckAmount As Decimal?
        Public Property DiscountAmount As Decimal?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

