Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class BillingCommandCenterInvoiceDatePostPeriod

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PostPeriodCode
            InvoiceDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property PostPeriodCode() As String

        Public Property InvoiceDate() As Nullable(Of Date)

        Public Property UseComboBilling As Boolean

        Public Property ComboAssignInvoicesBy As Short

        Public Property ProductionAssignInvoicesBy As String

        Public Property MediaAssignInvoicesBy As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
