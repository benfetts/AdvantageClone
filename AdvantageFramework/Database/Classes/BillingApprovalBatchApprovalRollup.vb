Namespace Database.Classes

    <Serializable()>
    Public Class BillingApprovalBatchApprovalRollup

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RollupCount
            RollupType
            RollupID
            CampaignCode
            Description
            FunctionCode
            FunctionDescription
            FunctionDefaultDescription
            FunctionType
            FunctionTypeDescription
            FunctionHeadingDescription
            QuoteAmount
            Actuals
            BilledReceived
            BilledHold
            NonBillableFee
            Unbilled
            OpenPO
            QuantityHours
            Quantity
            ApprovedAmount
            TempCutoffApprovedAmount
            QuoteNet
            UnbilledNet
            TempUnbilledNet
            ApprovedNet
            TempApprovedNet
            ApprovedMarkupAmount
            ApprovedResaleTax
            ApprovedVendorTax
            ApprovedTax
            QuoteMarkup
            QuoteResaleTax
            QuoteVendorTax
            UnbilledMarkup
            UnbilledResaleTax
            UnbilledVendorTax
            UnbilledTax
            QuoteQuantityHours
            ActualQuantityHours
            TempMarkup
            TempResaleTax
            TempTotal
            TempUnbilledMU
            TempUnbilledTax
            TempUnbilledNR
            TempUnbilledTot
            TempUnbilledPO
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RollupCount() As Nullable(Of Integer)

        Public Property RollupType() As Nullable(Of Short)

        Public Property RollupID() As Nullable(Of Integer)

        Public Property CampaignCode() As String

        Public Property Description() As String

        Public Property FunctionCode() As String

        Public Property FunctionDescription() As String

        Public Property FunctionDefaultDescription() As String

        Public Property FunctionType() As String

        Public Property FunctionTypeDescription() As String

        Public Property FunctionHeadingDescription() As String

        Public Property QuoteAmount() As Nullable(Of Decimal)

        Public Property Actuals() As Nullable(Of Decimal)

        Public Property BilledReceived() As Nullable(Of Decimal)

        Public Property BilledHold() As Nullable(Of Decimal)

        Public Property NonBillableFee() As Nullable(Of Decimal)

        Public Property Unbilled() As Nullable(Of Decimal)

        Public Property OpenPO() As Nullable(Of Decimal)

        Public Property QuantityHours() As Nullable(Of Decimal)

        Public Property Quantity() As Nullable(Of Decimal)

        Public Property ApprovedAmount() As Nullable(Of Decimal)

        Public Property TempCutoffApprovedAmount() As Nullable(Of Decimal)

        Public Property QuoteNet() As Nullable(Of Decimal)

        Public Property UnbilledNet() As Nullable(Of Decimal)

        Public Property TempUnbilledNet() As Nullable(Of Decimal)

        Public Property ApprovedNet() As Nullable(Of Decimal)

        Public Property TempApprovedNet() As Nullable(Of Decimal)

        Public Property ApprovedMarkupAmount() As Nullable(Of Decimal)

        Public Property ApprovedResaleTax() As Nullable(Of Decimal)

        Public Property ApprovedVendorTax() As Nullable(Of Decimal)

        Public Property ApprovedTax() As Nullable(Of Decimal)

        Public Property QuoteMarkup() As Nullable(Of Decimal)

        Public Property QuoteResaleTax() As Nullable(Of Decimal)

        Public Property QuoteVendorTax() As Nullable(Of Decimal)

        Public Property UnbilledMarkup() As Nullable(Of Decimal)

        Public Property UnbilledResaleTax() As Nullable(Of Decimal)

        Public Property UnbilledVendorTax() As Nullable(Of Decimal)

        Public Property UnbilledTax() As Nullable(Of Decimal)

        Public Property QuoteQuantityHours() As Nullable(Of Decimal)

        Public Property ActualQuantityHours() As Nullable(Of Decimal)

        Public Property TempMarkup() As Nullable(Of Decimal)

        Public Property TempResaleTax() As Nullable(Of Decimal)

        Public Property TempTotal() As Nullable(Of Decimal)

        Public Property TempUnbilledMU() As Nullable(Of Decimal)

        Public Property TempUnbilledTax() As Nullable(Of Decimal)

        Public Property TempUnbilledNR() As Nullable(Of Decimal)

        Public Property TempUnbilledTot() As Nullable(Of Decimal)

        Public Property TempUnbilledPO() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RollupCount.ToString

        End Function

#End Region

    End Class

End Namespace
