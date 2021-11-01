Namespace Services.QvAAlert.Classes

	Public Class JobDetailAnalysis

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MarkupPercent
			JobComponent
			IsNonBillableJob
			IsNonBillable
			Hold
			AdvanceBillFlag
			ClientCode
			ClientDescription
			DivisionCode
			DivisionDescription
			ProductCode
			ProductDescription
			AccountExecutiveCode
			AccountExecutive
			ClientReference
			JobNumber
			JobDescription
			SalesClassCode
			JobComponentNumber
			ComponentDescription
			JobTypeCode
			FunctionTypeOrder
			FunctionType
			FunctionTypeDescription
			Order
			FunctionCode
			FunctionDescription
			ItemDescription
			ItemDate
			ItemCode
			ClientPO
			SumOfEstimate
			SumOfEstimateHours
			SumOfEstimateCont
			SumOfEstimateNetCost
			SumOfEstimateNetAmount
			SumOfEstimateExtMarkup
			SumOfEstimateVenTax
			SumOfEstimateResaleTax
			SumOfIncomeOnly
			SumOfBillEmpHours
			SumOfTotalBill
			SumOfAPNetCost
			SumOfAPQuantity
			SumOfExtMarkupAmount
			SumOfVenTax
			SumOfResaleTax
			SumOfResaleBilled
			SumOfOpenPOAmount
			SumOfLineTotal
			SumOfNonBillableEmpHours
			SumOfNonBillableAmount
			SumOfBilledAmount
			SumOfAdvanceBilled
			SumOfAdvanceResale
			SumOfAdvanceResaleBilled
			SumOfAdvanceFinalBilled
			SumOfAdvanceTotal
			SumOfBilledCost
			SumOfUnbilled
			ProcessDesc
			JobProcessControl
			Code
			ZeroMU
			IsAdvanceBill
			EstimateNumber
			EstimateComponentNumber
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property ID As Nullable(Of System.Guid) = Nothing
		Public Property MarkupPercent As Nullable(Of Decimal) = Nothing
		Public Property JobComponent As String = Nothing
		Public Property IsNonBillableJob As String = Nothing
		Public Property IsNonBillable As String = Nothing
		Public Property Hold As String = Nothing
		Public Property AdvanceBillFlag As Nullable(Of Short) = Nothing
		Public Property ClientCode As String = Nothing
		Public Property ClientDescription As String = Nothing
		Public Property DivisionCode As String = Nothing
		Public Property DivisionDescription As String = Nothing
		Public Property ProductCode As String = Nothing
		Public Property ProductDescription As String = Nothing
		Public Property AccountExecutiveCode As String = Nothing
		Public Property AccountExecutive As String = Nothing
		Public Property ClientReference As String = Nothing
		Public Property JobNumber As Nullable(Of Integer) = Nothing
		Public Property JobDescription As String = Nothing
		Public Property SalesClassCode As String = Nothing
		Public Property JobComponentNumber As Nullable(Of Short) = Nothing
		Public Property ComponentDescription As String = Nothing
		Public Property JobTypeCode As String = Nothing
		Public Property FunctionTypeOrder As Nullable(Of Integer) = Nothing
		Public Property FunctionType As String = Nothing
		Public Property FunctionTypeDescription As String = Nothing
		Public Property Order As Nullable(Of Integer) = Nothing
		Public Property FunctionCode As String = Nothing
		Public Property FunctionDescription As String = Nothing
		Public Property ItemDescription As String = Nothing
		Public Property ItemDate As Nullable(Of Date) = Nothing
		Public Property ItemCode As String = Nothing
		Public Property ClientPO As String = Nothing
		Public Property SumOfEstimate As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateHours As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateCont As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
		Public Property SumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
		Public Property SumOfIncomeOnly As Nullable(Of Decimal) = Nothing
		Public Property SumOfBillEmpHours As Nullable(Of Decimal) = Nothing
		Public Property SumOfTotalBill As Nullable(Of Decimal) = Nothing
		Public Property SumOfAPNetCost As Nullable(Of Decimal) = Nothing
		Public Property SumOfAPQuantity As Nullable(Of Decimal) = Nothing
		Public Property SumOfExtMarkupAmount As Nullable(Of Decimal) = Nothing
		Public Property SumOfVenTax As Nullable(Of Decimal) = Nothing
		Public Property SumOfResaleTax As Nullable(Of Decimal) = Nothing
		Public Property SumOfResaleBilled As Nullable(Of Decimal) = Nothing
		Public Property SumOfOpenPOAmount As Nullable(Of Decimal) = Nothing
		Public Property SumOfLineTotal As Nullable(Of Decimal) = Nothing
		Public Property SumOfNonBillableEmpHours As Nullable(Of Decimal) = Nothing
		Public Property SumOfNonBillableAmount As Nullable(Of Decimal) = Nothing
		Public Property SumOfBilledAmount As Nullable(Of Decimal) = Nothing
		Public Property SumOfAdvanceBilled As Nullable(Of Decimal) = Nothing
		Public Property SumOfAdvanceResale As Nullable(Of Decimal) = Nothing
		Public Property SumOfAdvanceResaleBilled As Nullable(Of Decimal) = Nothing
		Public Property SumOfAdvanceFinalBilled As Nullable(Of Decimal) = Nothing
		Public Property SumOfAdvanceTotal As Nullable(Of Decimal) = Nothing
		Public Property SumOfBilledCost As Nullable(Of Decimal) = Nothing
		Public Property SumOfUnbilled As Nullable(Of Decimal) = Nothing
		Public Property ProcessDesc As String = Nothing
		Public Property JobProcessControl As Nullable(Of Short) = Nothing
		Public Property Code As String = Nothing
		Public Property ZeroMU As Nullable(Of Decimal) = Nothing
		Public Property IsAdvanceBill As String = Nothing
		Public Property EstimateNumber As Nullable(Of Integer) = Nothing
		Public Property EstimateComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
