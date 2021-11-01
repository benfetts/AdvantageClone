Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterExistingBatchDetail

#Region " Constants "



#End Region

#Region " Enum "

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BatchHeader As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader = Nothing
        Public Property Accounts As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail) = Nothing
        Public Property Vendors As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail) = Nothing
        Public Property Clients As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail) = Nothing
        Public Property Invoices As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail) = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

