
CREATE FUNCTION [dbo].[advtf_job_details_function]
(
	@JOB_NUMBER int, 
	@JOB_COMPONENT_NBR smallint
)
RETURNS @JOB_DETAILS_FUNCTION TABLE 
(
	ID bigint IDENTITY(1,1) NOT NULL,
	JobNumber int NULL,
	JobComponentNumber smallint NULL,
	FunctionType varchar(1) NULL,
	FunctionCode varchar(6) NULL,
	FunctionDescription varchar(30) NULL,
	[Hours] decimal NULL,
	BillableLessResale decimal NULL,
	BillableTotal decimal NULL,
	ExtMarkupAmount decimal NULL,
	NonResaleTaxAmount decimal NULL,
	ResaleTaxAmount decimal NULL,
	Total decimal NULL,
	NetAmount decimal NULL,
	EstimateHours decimal NULL,
	EstimateTotalAmount decimal NULL,
	EstimateContTotalAmount decimal NULL,
	EstimateNonResaleTaxAmount decimal NULL,
	EstimateResaleTaxAmount decimal NULL,
	EstimateMarkupAmount decimal NULL,
	EstimateCostAmount int NULL,
	IsEstimateNonBillable int NULL,
	EstimateFeeTime int NULL,
	EstimateNetAmount decimal NULL,
	BillingApprovalHours int NULL,
	BillingApprovalCostAmount int NULL,
	BillingApprovalExtNetAmount int NULL,
	BillingApprovalTotalAmount int NULL,
	OpenPurchaseOrderAmount decimal NULL,
	OpenPurchaseOrderGrossAmount decimal NULL,
	BilledAmount decimal NULL,
	BilledWithResale decimal NULL,
	BilledHours decimal NULL,
	FeeTimeAmount decimal NULL,
	FeeTimeHours decimal NULL,
	UnbilledAmount decimal NULL,
	UnbilledAmountResale decimal NULL,
	UnbilledHours decimal NULL,
	NonBillableAmount decimal NULL,
	NonBillableHours decimal NULL,
	IsNewBusiness int NULL,
	Agency int NULL
)
AS
BEGIN

	INSERT INTO @JOB_DETAILS_FUNCTION
	SELECT
		[JobNumber] = JDI.[JobNumber],
		[JobComponentNumber] = JDI.[JobComponentNumber],
		[FunctionType]	=	JDI.[FunctionType],
		[FunctionCode]	=	JDI.[FunctionCode],
		[FunctionDescription]	=	JDI.[FunctionDescription], 
		[Hours] = SUM(ISNULL(JDI.[Hours], 0)),
		[BillableLessResale] = SUM(ISNULL(JDI.[BillableLessResale], 0)),
		[BillableTotal] = SUM(ISNULL(JDI.[BillableTotal], 0)),
		[ExtMarkupAmount] = SUM(ISNULL(JDI.[ExtMarkupAmount], 0)),
		[NonResaleTaxAmount] = SUM(ISNULL(JDI.[NonResaleTaxAmount], 0)),
		[ResaleTaxAmount] = SUM(ISNULL(JDI.[ResaleTaxAmount], 0)),
		[Total] = SUM(ISNULL(JDI.[Total], 0)),
		[NetAmount] = SUM(ISNULL(JDI.[NetAmount], 0)), 
		[EstimateHours] = SUM(ISNULL(JDI.[EstimateHours], 0)),
		[EstimateTotalAmount] = SUM(ISNULL(JDI.[EstimateTotalAmount], 0)),
		[EstimateContTotalAmount] = SUM(ISNULL(JDI.[EstimateContTotalAmount], 0)),
		[EstimateNonResaleTaxAmount] = SUM(ISNULL(JDI.[EstimateNonResaleTaxAmount], 0)),
		[EstimateResaleTaxAmount] = SUM(ISNULL(JDI.[EstimateResaleTaxAmount], 0)),
		[EstimateMarkupAmount] = SUM(ISNULL(JDI.[EstimateMarkupAmount], 0)),
		[EstimateCostAmount] = SUM(ISNULL(JDI.[EstimateCostAmount], 0)),
		[IsEstimateNonBillable] = ISNULL(JDI.[IsEstimateNonBillable], 0),
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
		[FeeTimeAmount] = SUM(ISNULL(JDI.[FeeTimeAmount], 0)),
		[FeeTimeHours] = SUM(ISNULL(JDI.[FeeTimeHours], 0)),
		[UnbilledAmount] = SUM(ISNULL(JDI.[UnbilledAmount], 0)),
		[UnbilledAmountResale] = SUM(ISNULL(JDI.[UnbilledAmountResale], 0)),
		[UnbilledHours] = SUM(ISNULL(JDI.[UnbilledHours], 0)),
		[NonBillableAmount] = SUM(ISNULL(JDI.[NonBillableAmount], 0)),
		[NonBillableHours] = SUM(ISNULL(JDI.[NonBillableHours], 0)),
		[IsNewBusiness] = ISNULL(JDI.[IsNewBusiness], 0), 
		[Agency] = ISNULL(JDI.[Agency], 0)
	FROM
		[dbo].[advtf_job_details_items](@JOB_NUMBER, @JOB_COMPONENT_NBR) AS JDI
	GROUP BY
		JDI.[FunctionType],
		JDI.[FunctionCode],
		JDI.[FunctionDescription], 
		JDI.[JobNumber],
		JDI.[JobComponentNumber],
		ISNULL(JDI.[IsEstimateNonBillable], 0), 
		ISNULL(JDI.[IsNewBusiness], 0),
		ISNULL(JDI.[Agency], 0)
		
	RETURN

END
