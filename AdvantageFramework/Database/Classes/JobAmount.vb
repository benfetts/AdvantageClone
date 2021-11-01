Namespace Database.Classes

    <Serializable()>
    Public Class JobAmount

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobAmountType
            JobNumber
            JobComponentNumber
            FunctionType
            FunctionCode
            FunctionDescription
            JobAmountID
            JobAmountSequenceNumber
            JobAmountDate
            PostPeriodCode
            JobAmountCode
            JobAmountDescription
            JobAmountComment
            JobAmountExtra
            FeeTime
            Hours
            TotalBillAmount
            BillAmount
            ExtMarkupAmount
            NonResaleTaxAmount
            ResaleTaxAmount
            JobAmountTotal
            CostAmount
            AccountsRecievablePostPeriodCode
            AccountsRecievableInvoiceNumber
            AccountsRecievableType
            IsAdvanceBilling
            IsNonBillable
            GlexActBill
            EstimateHours
            EstimateTotalAmount
            EstimateContTotalAmount
            EstimateNonResaleTaxAmount
            EstimateResaleTaxAmount
            EstimateMarkupAmount
            EstimateCostAmount
            IsEstimateNonBillable
            EstimateFeeTime
            ApproximateHours
            ApproximateCostAmount
            ApproximateExtNetAmount
            ApproximateTotalAmount
            PurchaseOrderNumber
            OpenPurchaseOrderAmount
            OpenPurchaseOrderGrossAmount
            ClientCode
            ClientName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobAmountType() As String

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property FunctionType() As String

        Public Property FunctionCode() As String

        Public Property FunctionDescription() As String

        Public Property JobAmountID() As Nullable(Of Integer)

        Public Property JobAmountSequenceNumber() As Nullable(Of Integer)

        Public Property JobAmountDate() As Nullable(Of Date)

        Public Property PostPeriodCode() As String

        Public Property JobAmountCode() As String

        Public Property JobAmountDescription() As String

        Public Property JobAmountComment() As String

        Public Property JobAmountExtra() As String

        Public Property FeeTime() As Nullable(Of Byte)

        Public Property Hours() As Nullable(Of Decimal)

        Public Property TotalBillAmount() As Nullable(Of Decimal)

        Public Property BillAmount() As Nullable(Of Decimal)

        Public Property ExtMarkupAmount() As Nullable(Of Decimal)

        Public Property NonResaleTaxAmount() As Nullable(Of Decimal)

        Public Property ResaleTaxAmount() As Nullable(Of Decimal)

        Public Property JobAmountTotal() As Nullable(Of Decimal)

        Public Property CostAmount() As Nullable(Of Decimal)

        Public Property AccountsRecievablePostPeriodCode() As String

        Public Property AccountsRecievableInvoiceNumber() As Nullable(Of Integer)

        Public Property AccountsRecievableType() As String

        Public Property IsAdvanceBilling() As Nullable(Of Byte)

        Public Property IsNonBillable() As Nullable(Of Byte)

        Public Property GlexActBill() As Nullable(Of Integer)

        Public Property EstimateHours() As Nullable(Of Decimal)

        Public Property EstimateTotalAmount() As Nullable(Of Decimal)

        Public Property EstimateContTotalAmount() As Nullable(Of Decimal)

        Public Property EstimateNonResaleTaxAmount() As Nullable(Of Decimal)

        Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)

        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)

        Public Property EstimateCostAmount() As Nullable(Of Decimal)

        Public Property IsEstimateNonBillable() As Nullable(Of Byte)

        Public Property EstimateFeeTime() As Nullable(Of Byte)

        Public Property ApproximateHours() As Nullable(Of Decimal)

        Public Property ApproximateCostAmount() As Nullable(Of Decimal)

        Public Property ApproximateExtNetAmount() As Nullable(Of Decimal)

        Public Property ApproximateTotalAmount() As Nullable(Of Decimal)

        Public Property PurchaseOrderNumber() As Nullable(Of Integer)

        Public Property OpenPurchaseOrderAmount() As Nullable(Of Decimal)

        Public Property OpenPurchaseOrderGrossAmount() As Nullable(Of Decimal)

        Public Property ClientCode() As String
        Public Property ClientName() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobAmountType

        End Function

#End Region

    End Class

End Namespace
