Namespace Database.Classes

    <Serializable()>
    Public Class JobDetailAnalysisQVA

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            DivisionCode
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            EstimateNumber
            EstimateComponentNumber
            EstimateDescription
            EstimateComponentDescription
            EstimateQuoteNumber
            EstimateRevisionNumber
            ClientReference
            FunctionCode
            FunctionDescription
            FunctionType
            FunctionTypeDescription
            FunctionHeading
            ID
            MarkupPercent
            JobComponent
            IsNonBillable
            Hold
            AdvanceBillFlag
            ClientDescription
            DivisionDescription
            AccountExecutive
            AccountExecutiveCode
            SalesClassCode
            ComponentDescription
            JobTypeCode
            FunctionTypeOrder
            Order
            ItemDescription
            ItemDate
            ItemCode
            ClientPO
            StartDate
            DueDate
            SumOfEstimateHours
            SumOfEstimate
            SumOfEstimateCont
            SumOfEstimateNetCost
            SumOfEstimateExtMarkup
            SumOfEstimateVenTax
            SumOfEstimateResaleTax
            SumOfIncomeOnly
            SumOfBillEmpHours
            SumOfTotalBill
            SumOfAPQuantity
            SumOfAPNetCost
            SumOfExtMarkupAmount
            SumOfVenTax
            SumOfResaleTax
            SumOfResaleBilled
            SumOfOpenPOAmount
            SumOfLineTotal
            SumOfNonBillableEmpHours
            SumOfNonBillableAmount
            SumOfNonBillableMarkup
            SumOfBilledAmount
            SumOfAdvanceBilled
            SumOfAdvanceTotal
            SumOfAdvanceResale
            SumOfAdvanceResaleBilled
            SumOfAdvanceFinalBilled
            SumOfBilledCost
            SumOfUnbilled
            ProcessDesc
            JobProcessControl
            Code
            ZeroMU
            IsAdvanceBill
            SumOfEstimateNetEmployeeTime
            SumOfActualNetEmployeeTime
            SumOfEstimateNet
            SumOfActualNet
        End Enum

#End Region

#Region " Variables "

        Private _StartDate As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        Public Property ClientCode() As String

        Public Property DivisionCode() As String

        Public Property ProductCode() As String

        Public Property ProductDescription() As String

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobDescription() As String

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property EstimateNumber() As Nullable(Of Integer)

        Public Property EstimateComponentNumber() As Nullable(Of Short)

        Public Property EstimateDescription() As String

        Public Property EstimateComponentDescription() As String

        Public Property EstimateQuoteNumber() As Short

        Public Property EstimateRevisionNumber() As Short

        Public Property ClientReference() As String

        Public Property FunctionCode() As String

        Public Property FunctionDescription() As String

        Public Property FunctionType() As String

        Public Property FunctionTypeDescription() As String

        Public Property FunctionHeading() As String

        Public Property ID() As Nullable(Of System.Guid)

        Public Property MarkupPercent() As Nullable(Of Decimal)

        Public Property JobComponent() As String

        Public Property IsNonBillable() As String

        Public Property Hold() As String

        Public Property AdvanceBillFlag() As Nullable(Of Short)

        Public Property ClientDescription() As String

        Public Property DivisionDescription() As String

        Public Property AccountExecutive() As String

        Public Property AccountExecutiveCode() As String

        Public Property SalesClassCode() As String

        Public Property ComponentDescription() As String

        Public Property JobTypeCode() As String

        Public Property FunctionTypeOrder() As Nullable(Of Integer)

        Public Property Order() As Nullable(Of Integer)

        Public Property ItemDescription() As String

        Public Property ItemDate() As Nullable(Of Date)

        Public Property ItemCode() As String

        Public Property ClientPO() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property

        Public Property SumOfEstimateHours() As Nullable(Of Decimal)

        Public Property SumOfEstimate() As Nullable(Of Decimal)

        Public Property SumOfEstimateCont() As Nullable(Of Decimal)

        Public Property SumOfEstimateNetCost() As Nullable(Of Decimal)

        Public Property SumOfEstimateExtMarkup() As Nullable(Of Decimal)

        Public Property SumOfEstimateVenTax() As Nullable(Of Decimal)

        Public Property SumOfEstimateResaleTax() As Nullable(Of Decimal)

        Public Property SumOfIncomeOnly() As Nullable(Of Decimal)

        Public Property SumOfBillEmpHours() As Nullable(Of Decimal)

        Public Property SumOfTotalBill() As Nullable(Of Decimal)

        Public Property SumOfAPQuantity() As Nullable(Of Decimal)

        Public Property SumOfAPNetCost() As Nullable(Of Decimal)

        Public Property SumOfExtMarkupAmount() As Nullable(Of Decimal)

        Public Property SumOfVenTax() As Nullable(Of Decimal)

        Public Property SumOfResaleTax() As Nullable(Of Decimal)

        Public Property SumOfResaleBilled() As Nullable(Of Decimal)

        Public Property SumOfOpenPOAmount() As Nullable(Of Decimal)

        Public Property SumOfLineTotal() As Nullable(Of Decimal)

        Public Property SumOfNonBillableEmpHours() As Nullable(Of Decimal)

        Public Property SumOfNonBillableAmount() As Nullable(Of Decimal)

        Public Property SumOfNonBillableMarkup() As Nullable(Of Decimal)

        Public Property SumOfBilledAmount() As Nullable(Of Decimal)

        Public Property SumOfAdvanceBilled() As Nullable(Of Decimal)

        Public Property SumOfAdvanceTotal() As Nullable(Of Decimal)

        Public Property SumOfAdvanceResale() As Nullable(Of Decimal)

        Public Property SumOfAdvanceResaleBilled() As Nullable(Of Decimal)

        Public Property SumOfAdvanceFinalBilled() As Nullable(Of Decimal)

        Public Property SumOfBilledCost() As Nullable(Of Decimal)

        Public Property SumOfUnbilled() As Nullable(Of Decimal)

        Public Property ProcessDesc() As String

        Public Property JobProcessControl() As Nullable(Of Short)

        Public Property Code() As String

        Public Property ZeroMU() As Nullable(Of Decimal)

        Public Property IsAdvanceBill() As String

        Public Property SumOfEstimateNetEmployeeTime() As Nullable(Of Decimal)

        Public Property SumOfActualNetEmployeeTime() As Nullable(Of Decimal)

        Public Property SumOfEstimateNet() As Nullable(Of Decimal)

        Public Property SumOfActualNet() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

    End Class

End Namespace
