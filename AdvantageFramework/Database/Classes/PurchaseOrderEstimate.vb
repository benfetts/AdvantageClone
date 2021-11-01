Namespace Database.Classes

    <Serializable()>
    Public Class PurchaseOrderEstimate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            JobNumber
            JobComponentNumber
            FunctionType
            FunctionDescription
            FunctionCode
            EstimateApprovalQuoteNumber
            EstimateRevisionQuantity
            EstimateRevisionRate
            EstimateRevisionExtendedAmount
            EstimateRevisionCommissionPercent
            VendorName
            VendorCode
            ClientCode
            DivisionCode
            ProductCode
            ExtendedMarkupAmount
            LineTotal
            PurchaseOrderExistingAmount
            Balance
            UseCPM
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EstimateNumber() As Integer

        Public Property EstimateComponentNumber() As Short

        Public Property EstimateQuoteNumber() As Short

        Public Property EstimateRevisionNumber() As Short

        Public Property JobNumber() As Integer

        Public Property JobComponentNumber() As Short

        Public Property FunctionType() As String

        Public Property FunctionDescription() As String

        Public Property FunctionCode() As String

        Public Property EstimateApprovalQuoteNumber() As Short

        Public Property EstimateRevisionQuantity() As Decimal

        Public Property EstimateRevisionRate() As Decimal

        Public Property EstimateRevisionExtendedAmount() As Nullable(Of Decimal)

        Public Property EstimateRevisionCommissionPercent() As Decimal

        Public Property VendorName() As String

        Public Property VendorCode() As String

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)

        Public Property LineTotal() As Nullable(Of Decimal)

        Public Property PurchaseOrderExistingAmount() As Decimal

        Public Property Balance() As Nullable(Of Decimal)

        Public Property UseCPM() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace
