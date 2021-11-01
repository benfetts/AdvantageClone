CREATE PROCEDURE [dbo].[advsp_load_drpt_job_details_function]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_JOB_DETAILS_FUNCTION]
	
	DBCC CHECKIDENT (DRPT_JOB_DETAILS_FUNCTION, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_JOB_DETAILS_FUNCTION]
	SELECT 
		[JobNumber] = JDI.[JobNumber],
		[JobComponentNumber] = JDI.[JobComponentNumber],
		[FunctionType]	=	JDI.[FunctionType],
		[FunctionCode]	=	JDI.[FunctionCode],
		[FunctionDescription]	=	JDI.[FunctionDescription], 
		[Hours] = SUM(ISNULL(JDI.[Hours], 0)),
		[Quantity] = SUM(ISNULL(JDI.[Quantity], 0)),
		[BillableLessResale] = SUM(ISNULL(JDI.[BillableLessResale], 0)),
		[BillableTotal] = SUM(ISNULL(JDI.[BillableTotal], 0)),
		[ExtMarkupAmount] = SUM(ISNULL(JDI.[ExtMarkupAmount], 0)),
		[NonResaleTaxAmount] = SUM(ISNULL(JDI.[NonResaleTaxAmount], 0)),
		[ResaleTaxAmount] = SUM(ISNULL(JDI.[ResaleTaxAmount], 0)),
		[Total] = SUM(ISNULL(JDI.[Total], 0)),
		[NetAmount] = SUM(ISNULL(JDI.[NetAmount], 0)),
		[CostAmount] = SUM(ISNULL(JDI.[CostAmount], 0)), 
		[EstimateHours] = SUM(ISNULL(JDI.[EstimateHours], 0)),
		[EstimateQuantity] = SUM(ISNULL(JDI.[EstimateQuantity], 0)),
		[EstimateTotalAmount] = SUM(ISNULL(JDI.[EstimateTotalAmount], 0)),
		[EstimateContTotalAmount] = SUM(ISNULL(JDI.[EstimateContTotalAmount], 0)),
		[EstimateNonResaleTaxAmount] = SUM(ISNULL(JDI.[EstimateNonResaleTaxAmount], 0)),
		[EstimateResaleTaxAmount] = SUM(ISNULL(JDI.[EstimateResaleTaxAmount], 0)),
		[EstimateMarkupAmount] = SUM(ISNULL(JDI.[EstimateMarkupAmount], 0)),
		[EstimateCostAmount] = SUM(ISNULL(JDI.[EstimateCostAmount], 0)),
		[IsEstimateNonBillable]	= ISNULL(JDI.[IsEstimateNonBillable], 0),	
		[EstimateFeeTime] = SUM(ISNULL(JDI.[EstimateFeeTime], 0)),
		[EstimateNetAmount] = SUM(ISNULL(JDI.[EstimateNetAmount], 0)),
		[BillingApprovalHours] = SUM(ISNULL(JDI.[BillingApprovalHours], 0)),
		[BillingApprovalCostAmount] = SUM(ISNULL(JDI.[BillingApprovalCostAmount], 0)),
		[BillingApprovalExtNetAmount] = SUM(ISNULL(JDI.[BillingApprovalExtNetAmount], 0)),
		[BillingApprovalTotalAmount] = SUM(ISNULL(JDI.[BillingApprovalTotalAmount], 0)),
		[OpenPurchaseOrderAmount] = SUM(ISNULL(JDI.[OpenPurchaseOrderAmount], 0)),
		[OpenPurchaseOrderGrossAmount] = SUM(ISNULL(JDI.[OpenPurchaseOrderGrossAmount], 0)),
		[BilledAmount] = SUM(ISNULL(JDI.[BilledAmount], 0)),
		[BilledWithResale] = SUM(ISNULL(JDI.[BilledWithResale], 0)),
		[BilledHours] = SUM(ISNULL(JDI.[BilledHours], 0)),
		[BilledQuantity] = SUM(ISNULL(JDI.[BilledQuantity], 0)),
		[FeeTimeAmount] = SUM(ISNULL(JDI.[FeeTimeAmount], 0)),
		[FeeTimeHours] = SUM(ISNULL(JDI.[FeeTimeHours], 0)),
		[UnbilledAmount] = SUM(ISNULL(JDI.[UnbilledAmount], 0)),
		[UnbilledAmountLessResale] = SUM(ISNULL(JDI.[UnbilledAmountLessResale], 0)),
		[UnbilledHours] = SUM(ISNULL(JDI.[UnbilledHours], 0)),
		[UnbilledQuantity] = SUM(ISNULL(JDI.[UnbilledQuantity], 0)),
		[NonBillableAmount] = SUM(ISNULL(JDI.[NonBillableAmount], 0)),
		[NonBillableHours] = SUM(ISNULL(JDI.[NonBillableHours], 0)),
		[NonBillableQuantity] = SUM(ISNULL(JDI.[NonBillableQuantity], 0)),
		[IsNewBusiness]	= ISNULL(JDI.[IsNewBusiness], 0),	
		[Agency] = ISNULL(JDI.[Agency], 0)
	FROM
		[dbo].[DRPT_JOB_DETAILS_ITEM] AS JDI
	GROUP BY
		JDI.[JobNumber],
		JDI.[JobComponentNumber],
		JDI.[FunctionType],
		JDI.[FunctionCode],
		JDI.[FunctionDescription],
		ISNULL(JDI.[IsEstimateNonBillable], 0),	
		ISNULL(JDI.[IsNewBusiness], 0),	
		ISNULL(JDI.[Agency], 0)

END
