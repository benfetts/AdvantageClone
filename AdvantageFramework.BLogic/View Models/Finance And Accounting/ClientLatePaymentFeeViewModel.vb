Namespace ViewModels.FinanceAndAccounting

    Public Class ClientLatePaymentFeeViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property OpenARPostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)

        Public Property ClientLateFeeInvoices As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)

        Public Property AgingDate As Date
        Public Property PostPeriodCode As String

        Public Property FeeInvoiceDate As Date
        Public Property FeePostPeriodCode As String

        Public Property CurrentARPostPeriod As AdvantageFramework.Database.Entities.PostPeriod

#End Region

#Region " Methods "

        Public Sub New()

            OpenARPostPeriods = New Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)

            ClientLateFeeInvoices = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.ClientLateFeeInvoice)

        End Sub

#End Region

    End Class

End Namespace
