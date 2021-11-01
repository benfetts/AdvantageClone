Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class InvoiceAssignedCoop

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorkARFunctionID
            JobNumber
            JobComponentNumber
            JobComponentDescription
            ClientCode
            DivisionCode
            ProductCode
            FunctionCode
            FunctionDescription
            FunctionType
            CoopPercent
            CostAmount
            CCCostAmount
            IncomeAmount
            CCIncomeAmount
            SalesTaxCode
            DetailTaxFlag
            InvoiceTaxFlag
            CoopCode
            CostPercent
            IncomePercent
            JobDescription
            JobAdvanceBillingFlag
            IsSummaryFlag
            FromAdv
            EmployeeTimeAmount
            IncomeOnlyAmount
            AdvanceBillIncomeAmount
            AdvanceBillCostAmount
            MarkupAmount
            AdvanceBillMarkupAmount
            AdvanceBillSaleAmount
            AdvanceBillNonResaleTaxAmount
            StateTaxAmount
            CountyTaxAmount
            CityTaxAmount
            NonResaleTaxAmount
            TotalBill
            IsModified
            CCBalancedFlag
            CCAmountModified
            CCVariance
            CCInterimReconcile
            FunctionRowCount
            NewspaperCoopSplit
            CampaignID
            SummaryRowId
            ClientName
            DivisionName
            ProductName
            CampaignCode
            CampaignName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property WorkARFunctionID() As Integer

        Public Property JobNumber() As Integer

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property JobComponentDescription() As String

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        Public Property FunctionCode() As String

        Public Property FunctionDescription() As String

        Public Property FunctionType() As String

        Public Property CoopPercent() As Nullable(Of Decimal)

        Public Property CostAmount() As Nullable(Of Decimal)

        Public Property CCCostAmount() As Nullable(Of Decimal)

        Public Property IncomeAmount() As Nullable(Of Decimal)

        Public Property CCIncomeAmount() As Nullable(Of Decimal)

        Public Property SalesTaxCode() As String

        Public Property DetailTaxFlag() As Nullable(Of Boolean)

        Public Property InvoiceTaxFlag() As Nullable(Of Boolean)

        Public Property CoopCode() As String

        Public Property CostPercent() As Nullable(Of Decimal)

        Public Property IncomePercent() As Nullable(Of Decimal)

        Public Property JobDescription() As String

        Public Property JobAdvanceBillingFlag() As Nullable(Of Byte)

        Public Property IsSummaryFlag() As Nullable(Of Boolean)

        Public Property FromAdv() As Nullable(Of Boolean)

        Public Property EmployeeTimeAmount() As Nullable(Of Decimal)

        Public Property IncomeOnlyAmount() As Nullable(Of Decimal)

        Public Property AdvanceBillIncomeAmount() As Nullable(Of Decimal)

        Public Property AdvanceBillCostAmount() As Nullable(Of Decimal)

        Public Property MarkupAmount() As Nullable(Of Decimal)

        Public Property AdvanceBillMarkupAmount() As Nullable(Of Decimal)

        Public Property AdvanceBillSaleAmount() As Nullable(Of Decimal)

        Public Property AdvanceBillNonResaleTaxAmount() As Nullable(Of Decimal)

        Public Property StateTaxAmount() As Nullable(Of Decimal)

        Public Property CountyTaxAmount() As Nullable(Of Decimal)

        Public Property CityTaxAmount() As Nullable(Of Decimal)

        Public Property NonResaleTaxAmount() As Nullable(Of Decimal)

        Public Property TotalBill() As Nullable(Of Decimal)

        Public Property IsModified() As Nullable(Of Boolean)

        Public Property CCBalancedFlag() As Nullable(Of Boolean)

        Public Property CCAmountModified() As Nullable(Of Boolean)

        Public Property CCVariance() As Nullable(Of Decimal)

        Public Property CCInterimReconcile() As Nullable(Of Boolean)

        Public Property FunctionRowCount() As Nullable(Of Integer)

        Public Property NewspaperCoopSplit() As Nullable(Of Short)

        Public Property CampaignID() As Nullable(Of Integer)

        Public Property SummaryRowId() As Nullable(Of Integer)

        Public Property ClientName() As String

        Public Property DivisionName() As String

        Public Property ProductName() As String

        Public Property CampaignCode() As String

        Public Property CampaignName() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.WorkARFunctionID.ToString

        End Function

#End Region

    End Class

End Namespace
