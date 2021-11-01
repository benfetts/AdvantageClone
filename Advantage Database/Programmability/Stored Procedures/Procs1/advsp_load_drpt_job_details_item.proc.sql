CREATE PROCEDURE [dbo].[advsp_load_drpt_job_details_item]

AS
BEGIN

	DELETE FROM [dbo].[DRPT_JOB_DETAILS_ITEM]
	
	DBCC CHECKIDENT (DRPT_JOB_DETAILS_ITEM, reseed, 0)
	
	INSERT INTO [dbo].[DRPT_JOB_DETAILS_ITEM]
	SELECT 
		[ResourceType] = JDI.[ResourceType],
		[JobNumber] = JDI.[JobNumber],
		[JobComponentNumber] = JDI.[JobComponentNumber],
		[FunctionType] = JDI.[FunctionType],
		[FunctionCode] = JDI.[FunctionCode],
		[FunctionDescription] = JDI.[FunctionDescription],
		[ItemID] = JDI.[ItemID],
		[ItemSequenceNumber] = JDI.[ItemSequenceNumber],
		[ItemDate] = JDI.[ItemDate],
		[PostPeriodCode] = JDI.[PostPeriodCode],
		[ItemCode] = JDI.[ItemCode],
		[ItemDescription] = JDI.[ItemDescription],
		[ItemComment] = JDI.[ItemComment],
		[ItemExtra] = JDI.[ItemExtra],
		[FeeTime] = JDI.[FeeTime],
		[Hours] = JDI.[Hours],
		[Quantity] = JDI.[Quantity],
		[BillableLessResale] = JDI.[BillableLessResale],
		[BillableTotal] = JDI.[BillableTotal],
		[ExtMarkupAmount] = JDI.[ExtMarkupAmount],
		[NonResaleTaxAmount] = JDI.[NonResaleTaxAmount],
		[ResaleTaxAmount] = JDI.[ResaleTaxAmount],
		[Total] = JDI.[Total],
		[CostAmount] = JDI.[CostAmount],
		[NetAmount] = JDI.[NetAmount],
		[AccountsReceivablePostPeriodCode] = JDI.[AccountsReceivablePostPeriodCode],
		[AccountsReceivableInvoiceNumber] = JDI.[AccountsReceivableInvoiceNumber],
		[AccountsReceivableInvoiceType] = JDI.[AccountsReceivableInvoiceType],
		[AdvanceBillFlagDetail] = JDI.[AdvanceBillFlagDetail],
		[IsNonBillable] = JDI.[IsNonBillable],
		[GlexActBill] = JDI.[GlexActBill],
		[EstimateHours] = JDI.[EstimateHours],
		[EstimateQuantity] = JDI.[EstimateQuantity],
		[EstimateTotalAmount] = JDI.[EstimateTotalAmount],
		[EstimateContTotalAmount] = JDI.[EstimateContTotalAmount],
		[EstimateNonResaleTaxAmount] = JDI.[EstimateNonResaleTaxAmount],
		[EstimateResaleTaxAmount] = JDI.[EstimateResaleTaxAmount],
		[EstimateMarkupAmount] = JDI.[EstimateMarkupAmount],
		[EstimateCostAmount] = JDI.[EstimateCostAmount],
		[IsEstimateNonBillable] = JDI.[IsEstimateNonBillable],
		[EstimateFeeTime] = JDI.[EstimateFeeTime],
		[EstimateNetAmount] = JDI.[EstimateNetAmount],
		[PurchaseOrderNumber] = JDI.[PurchaseOrderNumber],
		[OpenPurchaseOrderAmount] = JDI.[OpenPurchaseOrderAmount],
		[OpenPurchaseOrderGrossAmount] = JDI.[OpenPurchaseOrderGrossAmount],
		[BilledAmount] = JDI.[BilledAmount],
		[BilledWithResale] = JDI.[BilledWithResale],
		[BilledHours] = JDI.[BilledHours],
		[BilledQuantity] = JDI.[BilledQuantity],
		[FeeTimeAmount] = JDI.[FeeTimeAmount],
		[FeeTimeHours] = JDI.[FeeTimeHours],
		[UnbilledAmount] = JDI.[UnbilledAmount],
		[UnbilledAmountLessResale] = JDI.[UnbilledAmountLessResale],
		[UnbilledHours] = JDI.[UnbilledHours],
		[UnbilledQuantity] = JDI.[UnbilledQuantity],
		[NonBillableAmount] = JDI.[NonBillableAmount],
		[NonBillableHours] = JDI.[NonBillableHours],
		[NonBillableQuantity] = JDI.[NonBillableQuantity],
		[IsNewBusiness] = JDI.[IsNewBusiness],
		[Agency] = JDI.[Agency],
		[BillingApprovalHours] = JDI.[BillingApprovalHours],
		[BillingApprovalCostAmount] = JDI.[BillingApprovalCostAmount],
		[BillingApprovalExtNetAmount] = JDI.[BillingApprovalExtNetAmount],
		[BillingApprovalTotalAmount] = JDI.[BillingApprovalTotalAmount]
	FROM
		(SELECT
			[ResourceType] = 'C',
			[JobNumber] = a.JOB_NUMBER,
			[JobComponentNumber] = a.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = a.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = a.INV_DATE,
			[PostPeriodCode] = NULL,
			[ItemCode] = NULL,
			[ItemDescription] = a.[DESCRIPTION],
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = ISNULL(a.AMOUNT, 0),
			[CostAmount] = ISNULL(a.AMOUNT, 0),
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = NULL,
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = NULL,
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.CLIENT_OOP AS a INNER JOIN 
			dbo.FUNCTIONS AS f ON a.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = a.JOB_NUMBER INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = a.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR INNER JOIN
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
			
		UNION ALL
		
		SELECT
			[ResourceType] = 'E',
			[JobNumber] = e.JOB_NUMBER,
			[JobComponentNumber] = e.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = e.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = e.ET_ID,
			[ItemSequenceNumber] = e.ET_DTL_ID,
			[ItemDate] = et.EMP_DATE,
			[PostPeriodCode] = NULL,
			[ItemCode] = et.EMP_CODE,
			[ItemDescription] = emp.EmployeeName,
			[ItemComment] = ec.EMP_COMMENT,
			[ItemExtra] = NULL,
			[FeeTime] = ISNULL(e.FEE_TIME, 0),
			[Hours] = CASE WHEN f.FNC_TYPE = 'E' THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
			[Quantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
			[BillableLessResale] = CASE WHEN ISNULL(e.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) END,
			[BillableTotal] = CASE WHEN ISNULL(e.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(e.LINE_TOTAL, 0) END,
			[ExtMarkupAmount] = ISNULL(e.EXT_MARKUP_AMT, 0),
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = ISNULL(e.EXT_STATE_RESALE, 0) + ISNULL(e.EXT_COUNTY_RESALE, 0) + ISNULL(e.EXT_CITY_RESALE, 0),
			[Total] = ISNULL(e.LINE_TOTAL, 0),
			[CostAmount] = 0,
			[NetAmount] = ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) - ISNULL(e.EXT_MARKUP_AMT, 0),
			[AccountsReceivablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
			[AccountsReceivableInvoiceNumber] = e.AR_INV_NBR,
			[AccountsReceivableInvoiceType] = e.AR_TYPE,
			[AdvanceBillFlagDetail] = e.AB_FLAG,
			[IsNonBillable] = ISNULL(e.EMP_NON_BILL_FLAG, 0),
			[GlexActBill] = e.GLEXACT_BILL,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
			[BilledWithResale] = CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.LINE_TOTAL, 0) ELSE 0 END,
			[BilledHours] = CASE WHEN f.FNC_TYPE = 'E' THEN CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[BilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[FeeTimeAmount] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
			[FeeTimeHours] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
			[UnbilledAmount] = CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL, 0) ELSE 0 END,
			[UnbilledAmountLessResale] = CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
			[UnbilledHours] = CASE WHEN f.FNC_TYPE = 'E' THEN CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[UnbilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[NonBillableAmount] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
			[NonBillableHours] = CASE WHEN f.FNC_TYPE = 'E' THEN CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[NonBillableQuantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.EMP_TIME_DTL AS e INNER JOIN 
			dbo.EMP_TIME AS et ON e.ET_ID = et.ET_ID INNER JOIN 
			dbo.FUNCTIONS AS f ON e.FNC_CODE = f.FNC_CODE INNER JOIN 
			[dbo].[advtf_emp_names]() AS emp ON et.EMP_CODE = emp.EmployeeCode LEFT JOIN 
			dbo.EMP_TIME_DTL_CMTS AS ec ON e.ET_ID = ec.ET_ID AND
										   e.ET_DTL_ID = ec.ET_DTL_ID INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = e.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT 
				DISTINCT 
				a.AR_POST_PERIOD,
				a.AR_INV_NBR, 
				a.AR_TYPE
			FROM 
				dbo.ACCT_REC AS a) AS a ON a.AR_INV_NBR = e.AR_INV_NBR AND 
										   a.AR_TYPE = e.AR_TYPE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = e.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = e.JOB_COMPONENT_NBR
							  
		UNION ALL
		
		SELECT
			[ResourceType] = 'V',
			[JobNumber] = a.JOB_NUMBER,
			[JobComponentNumber] = a.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = a.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = a.AP_ID,
			[ItemSequenceNumber] = a.AP_SEQ,
			[ItemDate] = ah.AP_INV_DATE,
			[PostPeriodCode] = a.POST_PERIOD,
			[ItemCode] = ah.VN_FRL_EMP_CODE,
			[ItemDescription] = v.VN_NAME + ' (' + ah.VN_FRL_EMP_CODE + ')',
			[ItemComment] = NULL,
			[ItemExtra] = ah.AP_INV_VCHR,
			[FeeTime] = 0,
			[Hours] = CASE WHEN f.FNC_TYPE = 'E' THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[Quantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[BillableLessResale] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) END,
			[BillableTotal] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(a.LINE_TOTAL, 0) END,
			[ExtMarkupAmount] = ISNULL(a.EXT_MARKUP_AMT, 0),
			[NonResaleTaxAmount] = ISNULL(a.EXT_NONRESALE_TAX, 0),
			[ResaleTaxAmount] = ISNULL(a.EXT_STATE_RESALE, 0) + ISNULL(a.EXT_COUNTY_RESALE, 0) + ISNULL(a.EXT_CITY_RESALE, 0),
			[Total] = ISNULL(a.LINE_TOTAL, 0),
			[CostAmount] = a.AP_PROD_EXT_AMT,
			[NetAmount] = (ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0)) - ISNULL(a.EXT_MARKUP_AMT, 0),
			[AccountsReceivablePostPeriodCode] = ISNULL(ar.AR_POST_PERIOD, ''),
			[AccountsReceivableInvoiceNumber] = a.AR_INV_NBR,
			[AccountsReceivableInvoiceType] = a.AR_TYPE,
			[AdvanceBillFlagDetail] = a.AB_FLAG,
			[IsNonBillable] = ISNULL(a.AP_PROD_NOBILL_FLG, 0),
			[GlexActBill] = a.GLEXACT_BILL,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) ELSE 0 END,
			[BilledWithResale] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL, 0) ELSE 0 END,
			[BilledHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[BilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NULL THEN ISNULL(a.LINE_TOTAL, 0) ELSE 0 END,
			[UnbilledAmountLessResale] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NULL THEN ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) ELSE 0 END,
			[UnbilledHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NULL THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[UnbilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) <> 1 AND a.AR_INV_NBR IS NULL THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[NonBillableAmount] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) ELSE 0 END,
			[NonBillableHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[NonBillableQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.AP_PRODUCTION AS a INNER JOIN 
			dbo.AP_HEADER AS ah ON a.AP_ID = ah.AP_ID AND 
								   a.AP_SEQ = ah.AP_SEQ INNER JOIN 
			dbo.FUNCTIONS AS f ON a.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.VENDOR AS v ON ah.VN_FRL_EMP_CODE = v.VN_CODE LEFT JOIN 
			dbo.AP_PROD_COMMENTS AS ac ON a.AP_ID = ac.AP_ID AND 
										  a.LINE_NUMBER = ac.LINE_NUMBER INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = a.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT 
				DISTINCT 
				a.AR_POST_PERIOD,
				a.AR_INV_NBR, 
				a.AR_TYPE
			FROM 
				dbo.ACCT_REC AS a) AS ar ON ar.AR_INV_NBR = a.AR_INV_NBR AND 
											ar.AR_TYPE = a.AR_TYPE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = a.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR
			
		UNION ALL
		
		SELECT
			[ResourceType] = 'I',
			[JobNumber] = ino.JOB_NUMBER,
			[JobComponentNumber] = ino.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = ino.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = ino.IO_ID,
			[ItemSequenceNumber] = ino.SEQ_NBR,
			[ItemDate] = ino.IO_INV_DATE,
			[PostPeriodCode] = NULL,
			[ItemCode] = NULL,
			[ItemDescription] = ino.IO_DESC,
			[ItemComment] = ino.IO_COMMENT,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = CASE WHEN f.FNC_TYPE = 'E' THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[Quantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[BillableLessResale] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0) END,
			[BillableTotal] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ino.LINE_TOTAL, 0) END,
			[ExtMarkupAmount] = ISNULL(ino.EXT_MARKUP_AMT, 0),
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = ISNULL(ino.EXT_STATE_RESALE, 0) + ISNULL(ino.EXT_COUNTY_RESALE, 0) + ISNULL(ino.EXT_CITY_RESALE, 0),
			[Total] = ISNULL(ino.LINE_TOTAL, 0),
			[CostAmount] = 0,			
			[NetAmount] = (ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0)) - ISNULL(ino.EXT_MARKUP_AMT, 0),
			[AccountsReceivablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
			[AccountsReceivableInvoiceNumber] = ino.AR_INV_NBR,
			[AccountsReceivableInvoiceType] = ino.AR_TYPE,
			[AdvanceBillFlagDetail] = ino.AB_FLAG,
			[IsNonBillable] = ISNULL(ino.NON_BILL_FLAG, 0),
			[GlexActBill] = ino.GLEXACT_BILL,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = CASE WHEN ino.AR_INV_NBR IS NOT NULL THEN ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0) ELSE 0 END,
			[BilledWithResale] = CASE WHEN ino.AR_INV_NBR IS NOT NULL THEN ISNULL(ino.LINE_TOTAL, 0) ELSE 0 END,
			[BilledHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NOT NULL THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[BilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NOT NULL THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NULL THEN ISNULL(ino.LINE_TOTAL, 0) ELSE 0 END,
			[UnbilledAmountLessResale] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NULL THEN ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0) ELSE 0 END,
			[UnbilledHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NULL THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[UnbilledQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) <> 1 AND ino.AR_INV_NBR IS NULL THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[NonBillableAmount] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0) ELSE 0 END,
			[NonBillableHours] = CASE WHEN f.FNC_TYPE = 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[NonBillableQuantity] = CASE WHEN f.FNC_TYPE <> 'E' AND ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN ISNULL(ino.IO_QTY, 0) ELSE 0 END,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.INCOME_ONLY AS ino INNER JOIN 
			dbo.FUNCTIONS AS f ON ino.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = ino.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT 
				DISTINCT 
				a.AR_POST_PERIOD,
				a.AR_INV_NBR, 
				a.AR_TYPE
			FROM 
				dbo.ACCT_REC AS a) AS a ON a.AR_INV_NBR = ino.AR_INV_NBR AND 
											a.AR_TYPE = ino.AR_TYPE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = ino.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = ino.JOB_COMPONENT_NBR
			
		UNION ALL
			
		SELECT
			[ResourceType] = 'A',
			[JobNumber] = ab.JOB_NUMBER,
			[JobComponentNumber] = ab.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = ab.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = ab.AB_ID,
			[ItemSequenceNumber] = ab.SEQ_NBR,
			[ItemDate] = ab.BILL_DATE,
			[PostPeriodCode] = NULL,
			[ItemCode] = NULL,
			[ItemDescription] = 'Advance Billing',
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
			[AccountsReceivableInvoiceNumber] = ab.AR_INV_NBR,
			[AccountsReceivableInvoiceType] = ab.AR_TYPE,
			[AdvanceBillFlagDetail] = ab.AB_FLAG,
			[IsNonBillable] = 0,
			[GlexActBill] = ab.GLEXACT,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = CASE WHEN ab.AR_INV_NBR IS NOT NULL THEN ISNULL(ab.LINE_TOTAL, 0) - ISNULL(ab.EXT_CITY_RESALE, 0) - ISNULL(ab.EXT_STATE_RESALE, 0) - ISNULL(ab.EXT_COUNTY_RESALE, 0) ELSE 0 END,
			[BilledWithResale] = CASE WHEN ab.AR_INV_NBR IS NOT NULL THEN ISNULL(ab.LINE_TOTAL, 0) ELSE 0 END,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.ADVANCE_BILLING AS ab INNER JOIN 
			dbo.FUNCTIONS f ON ab.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = ab.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT 
				DISTINCT 
				a.AR_POST_PERIOD,
				a.AR_INV_NBR, 
				a.AR_TYPE
			FROM 
				dbo.ACCT_REC AS a) AS a ON a.AR_INV_NBR = ab.AR_INV_NBR AND 
										   a.AR_TYPE = ab.AR_TYPE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = ab.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = ab.JOB_COMPONENT_NBR
			
		UNION ALL
		
		SELECT
			[ResourceType] = 'ES',
			[JobNumber] = ea.JOB_NUMBER,
			[JobComponentNumber] = ea.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = ed.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = NULL,
			[PostPeriodCode] = NULL,
			[ItemCode] = NULL,
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = NULL,
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = NULL,
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN f.FNC_TYPE = 'E' THEN ISNULL(ed.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN ISNULL(ed.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ed.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ed.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ed.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ed.EXT_STATE_RESALE, 0) + ISNULL(ed.EXT_COUNTY_RESALE, 0) + ISNULL(ed.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ed.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN f.FNC_TYPE = 'V' THEN ISNULL(ed.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ed.LINE_TOTAL, 0) - ISNULL(ed.EXT_STATE_RESALE, 0) - ISNULL(ed.EXT_COUNTY_RESALE, 0) - ISNULL(ed.EXT_CITY_RESALE, 0)) - ISNULL(ed.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.ESTIMATE_APPROVAL AS ea INNER JOIN 
			dbo.ESTIMATE_REV_DET AS ed ON ea.ESTIMATE_NUMBER =ed.ESTIMATE_NUMBER AND 
										  ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR AND 
										  ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR AND 
										  ea.EST_REVISION_NBR = ed.EST_REV_NBR INNER JOIN 
			dbo.FUNCTIONS f ON ed.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = ea.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = ea.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR
			
		UNION ALL
		
		SELECT
			[ResourceType] = 'EI',
			[JobNumber] = ea.JOB_NUMBER,
			[JobComponentNumber] = ea.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = ed.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = NULL,
			[PostPeriodCode] = NULL,
			[ItemCode] = NULL,
			[ItemDescription] = 'Estimate Amount',
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = NULL,
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = NULL,
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = CASE WHEN f.FNC_TYPE = 'E' THEN ISNULL(ed.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateQuantity] = CASE WHEN f.FNC_TYPE <> 'E' THEN ISNULL(ed.EST_REV_QUANTITY, 0) ELSE 0 END,
			[EstimateTotalAmount] = ISNULL(ed.LINE_TOTAL, 0),
			[EstimateContTotalAmount] = ISNULL(ed.LINE_TOTAL_CONT, 0),
			[EstimateNonResaleTaxAmount] = ISNULL(ed.EXT_NONRESALE_TAX, 0),
			[EstimateResaleTaxAmount] = ISNULL(ed.EXT_STATE_RESALE, 0) + ISNULL(ed.EXT_COUNTY_RESALE, 0) + ISNULL(ed.EXT_CITY_RESALE, 0),
			[EstimateMarkupAmount] = ISNULL(ed.EXT_MARKUP_AMT, 0),
			[EstimateCostAmount] = CASE WHEN f.FNC_TYPE = 'V' THEN ISNULL(ed.EST_REV_EXT_AMT, 0) ELSE 0 END,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = (ISNULL(ed.LINE_TOTAL, 0) - ISNULL(ed.EXT_STATE_RESALE, 0) - ISNULL(ed.EXT_COUNTY_RESALE, 0) - ISNULL(ed.EXT_CITY_RESALE, 0)) - ISNULL(ed.EXT_MARKUP_AMT, 0),
			[PurchaseOrderNumber] = 0,
			[OpenPurchaseOrderAmount] = 0,
			[OpenPurchaseOrderGrossAmount] = 0,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.ESTIMATE_INT_APPR AS ea INNER JOIN 
			(SELECT
				eii.ESTIMATE_NUMBER,
				eii.EST_COMPONENT_NBR,
				eii.EST_QUOTE_NBR,
				eii.EST_REVISION_NBR
			FROM 
				dbo.ESTIMATE_INT_APPR AS eii LEFT JOIN 
				dbo.ESTIMATE_APPROVAL AS eai ON eii.ESTIMATE_NUMBER = eai.ESTIMATE_NUMBER AND
											   eii.EST_COMPONENT_NBR = eai.EST_COMPONENT_NBR AND 
											   eii.EST_QUOTE_NBR = eai.EST_QUOTE_NBR AND 
											   eii.EST_REVISION_NBR = eai.EST_REVISION_NBR
			WHERE 
				eai.EST_APPR_BY IS NULL) AS ei ON ea.ESTIMATE_NUMBER = ei.ESTIMATE_NUMBER AND 
												  ea.EST_COMPONENT_NBR = ei.EST_COMPONENT_NBR AND 
												  ea.EST_QUOTE_NBR = ei.EST_QUOTE_NBR AND 
												  ea.EST_REVISION_NBR = ei.EST_REVISION_NBR INNER JOIN 
			dbo.ESTIMATE_REV_DET AS ed ON ea.ESTIMATE_NUMBER = ed.ESTIMATE_NUMBER AND 
										  ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR AND 
										  ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR AND 
										  ea.EST_REVISION_NBR = ed.EST_REV_NBR INNER JOIN 
			dbo.FUNCTIONS f ON ed.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = ea.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = ea.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR
			
		UNION ALL
		
		SELECT
			[ResourceType] = 'PO',
			[JobNumber] = pd.JOB_NUMBER,
			[JobComponentNumber] = pd.JOB_COMPONENT_NBR,
			[FunctionType] = f.FNC_TYPE,
			[FunctionCode] = pd.FNC_CODE,
			[FunctionDescription] = f.FNC_DESCRIPTION,
			[ItemID] = 0,
			[ItemSequenceNumber] = 0,
			[ItemDate] = p.PO_DATE,
			[PostPeriodCode] = NULL,
			[ItemCode] = p.VN_CODE,
			[ItemDescription] = p.VN_CODE,
			[ItemComment] = NULL,
			[ItemExtra] = NULL,
			[FeeTime] = 0,
			[Hours] = 0,
			[Quantity] = 0,
			[BillableLessResale] = 0,
			[BillableTotal] = 0,
			[ExtMarkupAmount] = 0,
			[NonResaleTaxAmount] = 0,
			[ResaleTaxAmount] = 0,
			[Total] = 0,
			[CostAmount] = 0,
			[NetAmount] = 0,
			[AccountsReceivablePostPeriodCode] = NULL,
			[AccountsReceivableInvoiceNumber] = 0,
			[AccountsReceivableInvoiceType] = NULL,
			[AdvanceBillFlagDetail] = 0,
			[IsNonBillable] = 0,
			[GlexActBill] = 0,
			[EstimateHours] = 0,
			[EstimateQuantity] = 0,
			[EstimateTotalAmount] = 0,
			[EstimateContTotalAmount] = 0,
			[EstimateNonResaleTaxAmount] = 0,
			[EstimateResaleTaxAmount] = 0,
			[EstimateMarkupAmount] = 0,
			[EstimateCostAmount] = 0,
			[IsEstimateNonBillable] = 0,
			[EstimateFeeTime] = 0,
			[EstimateNetAmount] = 0,
			[PurchaseOrderNumber] = p.PO_NUMBER,
			[OpenPurchaseOrderAmount] = CASE WHEN ap.PO_COMPLETE = 1 THEN 0 ELSE ISNULL(pd.PO_EXT_AMOUNT, 0) - ISNULL(ap.AP_NET_AMT, 0) END,
			[OpenPurchaseOrderGrossAmount] = CASE WHEN ap.PO_COMPLETE = 1 THEN 0 ELSE ISNULL(pd.PO_EXT_AMOUNT, 0) + ISNULL(pd.EXT_MARKUP_AMT, 0) - ISNULL(ap.AP_GROSS_AMT, 0) END,
			[BilledAmount] = 0,
			[BilledWithResale] = 0,
			[BilledHours] = 0,
			[BilledQuantity] = 0,
			[FeeTimeAmount] = 0,
			[FeeTimeHours] = 0,
			[UnbilledAmount] = 0,
			[UnbilledAmountLessResale] = 0,
			[UnbilledHours] = 0,
			[UnbilledQuantity] = 0,
			[NonBillableAmount] = 0,
			[NonBillableHours] = 0,
			[NonBillableQuantity] = 0,
			[IsNewBusiness] = c.NEW_BUSINESS,
			[Agency] = CASE WHEN acl.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
			[BillingApprovalHours] = 0, 
			[BillingApprovalCostAmount] = 0,  
			[BillingApprovalExtNetAmount] = 0,  
			[BillingApprovalTotalAmount] = 0
		FROM 
			dbo.PURCHASE_ORDER p INNER JOIN 
			dbo.PURCHASE_ORDER_DET pd ON p.PO_NUMBER = pd.PO_NUMBER LEFT JOIN 
			(SELECT
				ap.PO_NUMBER,
				ap.PO_LINE_NUMBER,
				PO_COMPLETE = MAX(ISNULL(ap.PO_COMPLETE, 0)),
				AP_NET_AMT = SUM(ap.AP_PROD_EXT_AMT),
				AP_GROSS_AMT = SUM(ap.AP_PROD_EXT_AMT) + SUM(ap.EXT_MARKUP_AMT)
			FROM 
				dbo.AP_PRODUCTION ap
			WHERE 
				ISNULL(ap.PO_NUMBER, 0) <> 0 AND 
				ISNULL(ap.DELETE_FLAG, 0) = 0 AND 
				ISNULL(ap.MODIFY_DELETE, 0) = 0
			GROUP BY 
				ap.PO_NUMBER, 
				ap.PO_LINE_NUMBER 
			HAVING 
				SUM(ap.AP_PROD_EXT_AMT) <> 0) ap ON pd.PO_NUMBER = ap.PO_NUMBER AND 
													pd.LINE_NUMBER = ap.PO_LINE_NUMBER INNER JOIN 
			dbo.FUNCTIONS f ON pd.FNC_CODE = f.FNC_CODE INNER JOIN 
			dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = pd.JOB_NUMBER INNER JOIN 
			dbo.CLIENT AS c ON c.CL_CODE = jl.CL_CODE LEFT OUTER JOIN
			(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE INNER JOIN
			dbo.JOB_COMPONENT jc ON jc.JOB_NUMBER = pd.JOB_NUMBER AND
							  jc.JOB_COMPONENT_NBR = pd.JOB_COMPONENT_NBR
		WHERE
			pd.JOB_NUMBER IS NOT NULL AND
			pd.JOB_COMPONENT_NBR IS NOT NULL AND
			pd.FNC_CODE IS NOT NULL AND 
			(pd.PO_COMPLETE IS NULL OR 
			 pd.PO_COMPLETE = 0) AND 
			(p.VOID_FLAG IS NULL OR 
			 p.VOID_FLAG = 0) AND
			(ISNULL(pd.PO_EXT_AMOUNT, 0) - ISNULL(ap.AP_NET_AMT, 0)) <> 0) AS JDI

END
