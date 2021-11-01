
CREATE VIEW [dbo].[V_RPT_JOB_ANALYSIS_DETAIL]
AS

	SELECT
		[ID] = ISNULL(ROW_NUMBER() OVER(ORDER BY j3.JOB_NUMBER, j3.JOB_COMPONENT_NBR), 0),
		jc.JOB_MARKUP_PCT,
		ISNULL(CAST(ISNULL(j3.JOB_NUMBER, '') AS varchar(10)) + CAST(ISNULL(j3.JOB_COMPONENT_NBR, '') AS varchar(10)), '') AS JobComp,
		CASE jc.NOBILL_FLAG
			WHEN 1 THEN 'Non-Billable'
			ELSE 'Billable'
		END AS NB,
		CASE jc.JOB_BILL_HOLD
			WHEN 1 THEN 'Temporary'
			WHEN 2 THEN 'Permanent'
			ELSE 'None'
		END AS Hold,
		jc.AB_FLAG AS ABFlag,
		jl.CL_CODE,
		c.CL_NAME,
		jl.DIV_CODE,
		d.DIV_NAME,
		jl.PRD_CODE,
		p.PRD_DESCRIPTION,
		jc.EMP_CODE,
		e.EMP_FNAME,
		e.EMP_LNAME,
		jl.JOB_CLI_REF,
		jl.JOB_NUMBER,
		jl.JOB_DESC,
		jl.SC_CODE,
		jc.JOB_COMPONENT_NBR,
		jc.JOB_COMP_DESC,
		jc.JT_CODE,
		CASE f.FNC_TYPE
			WHEN 'E' THEN 1
			WHEN 'V' THEN 2
			WHEN 'I' THEN 3
		END AS [Function Type Order],
		f.FNC_TYPE,
		CASE f.FNC_TYPE
			WHEN 'E' THEN 'Employee Time'
			WHEN 'V' THEN 'Vendor'
			WHEN 'I' THEN ' Income Only'
		END AS [Function Type Desc],
		j3.[ORDER],
		f.FNC_CODE,
		f.FNC_DESCRIPTION,		
		j3.ITEM_DESC,
		j3.[DATE],	
		j3.ITEM_CODE,
		jc.JOB_CL_PO_NBR,
		j3.SumOfESTIMATE,
		j3.SumOfESTCONT,
		j3.SumOfEST_NET_COST,
		j3.SumOfEST_EXT_MARKUP,
		j3.SumOfEST_VEN_TAX,
		j3.SumOfEST_RESALE_TAX,
		j3.SumOfINCOME_ONLY,
		j3.SumOfBILL_EMP_HOURS,
		j3.SumOfTOTAL_BILL,
		j3.SumOfAP_NET_COST,
		j3.SumOfEXT_MARKUP_AMT,
		j3.SumOfVEN_TAX,
		j3.SumOfRESALE_TAX,
		j3.SumOfRESALE_BILLED,
		j3.SumOfOPEN_PO_AMT,
		j3.SumOfLINE_TOTAL,
		j3.SumOfNB_EMP_HOURS,
		j3.SumOfNB_AMOUNT,
		j3.SumOfAMT_BILLED,
		j3.SumOfADVANCE_BILLED,
		j3.SumOfADVANCE_TOTAL,
		j3.SumOfCOST_BILLED,
		CASE jc.JOB_PROCESS_CONTRL
			WHEN 1 THEN 'All Processing'
			WHEN 2 THEN 'No Processing'
			WHEN 3 THEN 'A/P and Billing'
			WHEN 4 THEN 'A/P Time and Billing'
			WHEN 5 THEN 'Billing Only'
			WHEN 6 THEN 'Closed'
			WHEN 7 THEN 'Time and Billing'
			WHEN 8 THEN 'A/P, Time, IO and Billing'
			WHEN 9 THEN 'A/P, I/O and Billing'
			WHEN 10 THEN 'I/O and Billing'
			WHEN 11 THEN 'Time, I/O and Billing'
			WHEN 12 THEN 'Archive'
		END AS [Process Desc],
		jc.JOB_PROCESS_CONTRL,
		CASE
			WHEN j3.SumOfESTIMATE = 0 AND j3.SumOfTOTAL_BILL = 0 AND j3.SumOfLINE_TOTAL = 0
				AND j3.SumOfOPEN_PO_AMT = 0 AND j3.SumOfADVANCE_TOTAL = 0 AND j3.SumOfAMT_BILLED = 0
				AND j3.SumOfADVANCE_BILLED = 0 AND j3.SumOfNB_AMOUNT = 0 AND j3.SumOfCOST_BILLED = 0
				AND j3.SumOfBILL_EMP_HOURS = 0 THEN 'X'
			ELSE NULL	
		END AS Code,	
		j3.SumOfEXT_MARKUP_AMT AS ZeroMU,
		CASE 
			WHEN j3.SumOfADVANCE_TOTAL >0 THEN 'Y'
			ELSE ''
		END AS Adv,
		jc.ESTIMATE_NUMBER,
		jc.EST_COMPONENT_NBR
	FROM
		(SELECT
			[JOB_NUMBER] = j2.JOB_NUMBER,
			[JOB_COMPONENT_NBR] = j2.JOB_COMPONENT_NBR,
			[ORDER] = j2.[ORDER],
			[FNC_TYPE] = j2.FNC_TYPE,
			[FNC_CODE] = j2.FNC_CODE,
			[ITEM_DESC] = j2.ITEM_DESC,
			[DATE] = j2.[DATE],
			[ITEM_CODE] = j2.ITEM_CODE,
			[BILL_PERIOD] = j2.BILL_PERIOD,
			[NONAP_DATE] = j2.NONAP_DATE,
			[NB_FLAG] = j2.NB_FLAG,
			[SumOfESTIMATE_HRS_QTY] = SUM(j2.ESTIMATE_HRS_QTY),
			[SumOfESTIMATE] = SUM(j2.ESTIMATE),
			[SumOfESTCONT] = SUM(j2.ESTCONT),
			[SumOfEST_NET_COST] = SUM(j2.EST_NET_COST),
			[SumOfEST_EXT_MARKUP] = SUM(j2.EST_EXT_MARKUP),
			[SumOfEST_VEN_TAX] = SUM(j2.EST_VEN_TAX),
			[SumOfEST_RESALE_TAX] = SUM(j2.EST_RESALE_TAX),
			[SumOfBILL_EMP_HOURS] = SUM(j2.BILL_EMP_HOURS),
			[SumOfNB_EMP_HOURS] = SUM(j2.NB_EMP_HOURS),
			[SumOfINCOME_ONLY] = SUM(j2.INCOME_ONLY),
			[SumOfAP_QUANTITY] = SUM(j2.AP_QUANTITY),
			[SumOfAP_NET_COST] = SUM(j2.AP_NET_COST),
			[SumOfEXT_MARKUP_AMT] = SUM(j2.EXT_MARKUP_AMT),
			[SumOfTOTAL_BILL] = SUM(j2.TOTAL_BILL),
			[SumOfLINE_TOTAL] = SUM(j2.LINE_TOTAL),
			[SumOfNB_AMOUNT] = SUM(j2.NB_AMOUNT),
			[SumOfAMT_BILLED] = SUM(j2.AMT_BILLED),
			[SumOfRESALE_TAX] = SUM(j2.RESALE_TAX),
			[SumOfRESALE_BILLED] = SUM(j2.RESALE_BILLED),
			[SumOfVEN_TAX] = SUM(j2.VEN_TAX),
			[SumOfAMT_BILLED_NORTAX] = SUM(j2.AMT_BILLED - j2.RESALE_BILLED),
			[SumOfADVANCE_BILLED] = SUM(j2.ADVANCE_BILLED),
			[SumOfADVANCE_BILLED_NOTAX] = SUM(j2.ADVANCE_BILLED_NOTAX),
			[SumOfADVANCE_TOTAL] = SUM(j2.ADVANCE_TOTAL),
			[SumOfADVANCE_TOTAL_NOTAX] = SUM(j2.ADVANCE_TOTAL_NOTAX),
			[SumOfADVANCE_FINAL_BILLED] = SUM(CASE j2.AB_FLAG WHEN 5 THEN j2.AMT_BILLED ELSE 0 END),
			[SumOfOPEN_PO_AMT] = SUM(j2.OPEN_PO_AMT),
			[SumOfCOST_BILLED] = SUM(j2.COST_BILLED)	
		FROM
			(SELECT
				[REC_SOURCE] = j.[ResourceType],
				[JOB_NUMBER] = j.[JobNumber],
				[JOB_COMPONENT_NBR] = j.[JobComponentNumber],
				[FNC_TYPE] = j.[FunctionType],
				[FNC_CODE] = j.[FunctionCode],
				[FNC_DESC]	= j.[FunctionDescription],
				[POST_PERIOD] = j.[PostPeriodCode],
				[DATE] = j.[ItemDate],
				[NONAP_DATE] = CASE j.[FunctionType] WHEN 'E' THEN j.[ItemDate] ELSE NULL END,
				[ITEM_ID] = j.	[ItemID],
				[ITEM_SEQ] = j.[ItemSequenceNumber],
				[AP_ID] = NULL,
				[VN_EMP_CODE] = j.[ItemCode],
				[ITEM_DESC] = j.[ItemDescription],
				[ITEM_CODE] = CASE j.[ResourceType] WHEN 'A' THEN CAST(j.[ItemID] AS varchar) WHEN 'E' THEN NULL WHEN 'I' THEN NULL WHEN 'V' THEN j.[ItemExtra] WHEN 'PO' THEN 'PO #: ' + CAST(j.[PurchaseOrderNumber] AS varchar) END,
				[BILL_EMP_HOURS] = CASE WHEN j.[ResourceType] = 'E' AND j.[IsNonBillable] = 0 THEN j.[Hours] ELSE 0 END,
				[NB_EMP_HOURS] = CASE WHEN j.[ResourceType] = 'E' AND j.[IsNonBillable] = 1 THEN j.[Hours] ELSE 0 END,
				[BILLED_EMP_HOURS] = CASE WHEN (j.[ResourceType] = 'E' AND j.[AccountsRecievableInvoiceNumber] IS NOT NULL) OR j.[AdvanceBillFlagDetail] = 3 THEN j.[Hours] ELSE 0 END,
				[AP_QUANTITY] = CASE j.[ResourceType] WHEN 'V' THEN j.[Hours] ELSE 0 END,
				[AP_NET_COST] = CASE WHEN j.[ResourceType] = 'V' AND j.[IsNonBillable] = 0 THEN j.[CostAmount] ELSE 0 END,
				[EXT_MARKUP_AMT] = CASE WHEN j.[ResourceType] IN('E','I','V') AND j.[IsNonBillable] = 0 THEN j.[ExtMarkupAmount] ELSE 0 END,
				[EXT_MARKUP_BILLED] = CASE WHEN (j.[ResourceType] IN('E','I','V') AND j.[AccountsRecievableInvoiceNumber] IS NOT NULL) OR j.[AdvanceBillFlagDetail] = 3 THEN j.[ExtMarkupAmount] ELSE 0 END,
				[TOTAL_BILL] = CASE WHEN j.[ResourceType] = 'E' AND j.[IsNonBillable] = 0 THEN j.[BillableLessResale] ELSE 0 END,
				[INCOME_ONLY] = CASE WHEN j.[ResourceType] = 'I' THEN j.[Total] - j.[ResaleTaxAmount] ELSE 0 END,
				[LINE_TOTAL] = CASE WHEN j.[ResourceType] IN('E','I','V') AND j.[IsNonBillable] = 0 THEN j.[Total] ELSE 0 END,
				[CLIENT_OOP_AMT] = NULL,
				[NB_AMOUNT] = CASE WHEN j.[ResourceType] IN('E','V') AND j.[IsNonBillable] = 1 THEN j.[Total] - j.[ResaleTaxAmount] ELSE 0 END,
				[NB_AP_NET_COST] = CASE WHEN j.[ResourceType] = 'V' AND j.[IsNonBillable] = 1 THEN ISNULL(j.[CostAmount],0) ELSE 0 END,
				[NB_NET_TAX] = CASE j.[IsNonBillable] WHEN 1 THEN ISNULL(j.[NonResaleTaxAmount],0) ELSE 0 END,
				[NB_MARKUP_AMT] = CASE WHEN j.[ResourceType] IN('E','I','V') AND j.[IsNonBillable] = 1 THEN ISNULL(j.[ExtMarkupAmount],0) ELSE 0 END,
				[COST_BILLED] = CASE WHEN j.[ResourceType] = 'V' AND j.[IsNonBillable] = 0 AND (j.[AccountsRecievableInvoiceNumber] IS NOT NULL OR j.[AdvanceBillFlagDetail] = 3) THEN j.[CostAmount] + j.[NonResaleTaxAmount] ELSE 0 END,
				[AMT_BILLED] = CASE WHEN j.[AccountsRecievableInvoiceNumber] IS NOT NULL OR j.[AdvanceBillFlagDetail] = 3 THEN j.[Total] ELSE 0 END,
				[ACT_STATE_TAX] = NULL,
				[ACT_COUNTY_TAX] = NULL,
				[ACT_CITY_TAX] = NULL,
				[RESALE_TAX] = CASE WHEN j.[ResourceType] IN('E','I','V') AND j.[IsNonBillable] = 0 THEN j.[ResaleTaxAmount] ELSE 0 END,
				[RESALE_BILLED] = CASE WHEN (j.[AccountsRecievableInvoiceNumber] IS NOT NULL OR j.[AdvanceBillFlagDetail] = 3) AND j.[IsNonBillable] = 0  THEN j.[ResaleTaxAmount] ELSE 0 END,
				[VEN_TAX] = CASE WHEN j.[ResourceType] = 'V' AND j.[IsNonBillable] = 0 THEN j.[NonResaleTaxAmount] ELSE 0 END,
				[ADVANCE_BILLED] = 0,
				[ADVANCE_TOTAL] = CASE j.[ResourceType] WHEN 'A' THEN j.[Total] ELSE 0 END,
				[ADVANCE_TOTAL_NOTAX] = CASE j.[ResourceType] WHEN 'A' THEN j.[Total] - j.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_BILLED_NOTAX] = CASE WHEN (j.[ResourceType] = 'A' AND j.[AccountsRecievableInvoiceNumber] IS NOT NULL) OR j.[AdvanceBillFlagDetail] = 3 THEN j.[Total] - j.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_RESALE] = CASE j.[ResourceType] WHEN 'A' THEN j.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_RESALE_BILLED] = CASE WHEN (j.[ResourceType] = 'A' AND j.[AccountsRecievableInvoiceNumber] IS NOT NULL) OR j.[AdvanceBillFlagDetail] = 3 THEN j.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_ADJUSTED] = NULL,
				[ADVANCE_COST_BILLED] = CASE WHEN (j.[ResourceType] = 'A' AND j.[FunctionType] = 'V') AND (j.[AccountsRecievableInvoiceNumber] IS NOT NULL OR j.[AdvanceBillFlagDetail] = 3) THEN j.[Total] - j.[ExtMarkupAmount] - j.[ResaleTaxAmount] ELSE 0 END,
				[PO_EXT_AMT] = NULL,
				[OPEN_PO_AMT] = ISNULL(j.[OpenPurchaseOrderAmount],0),
				[ESTIMATE] = ISNULL(j.[EstimateTotalAmount],0) + ISNULL(j.[EstimateContTotalAmount],0),
				[ESTIMATE_HRS_QTY] = j.[EstimateHours],
				[ESTCONT] = j.[EstimateContTotalAmount],
				[EST_NET_COST] = j.[EstimateCostAmount],
				[EST_EXT_MARKUP] = j.[EstimateMarkupAmount],
				[EST_VEN_TAX] = j.[EstimateNonResaleTaxAmount],
				[EST_RESALE_TAX] = j.[EstimateResaleTaxAmount],
				[NB_FLAG] = j.[IsNonBillable],
				[ORDER] = CASE j.[ResourceType] WHEN 'ES' THEN 1 WHEN 'A' THEN 2 WHEN 'E' THEN 3 WHEN 'I' THEN 4 WHEN 'V' THEN 5 WHEN 'PO' THEN 6 END,
				[AR_INV_NBR] = j.[AccountsRecievableInvoiceNumber],
				[AR_INV_TYPE] = j.[AccountsRecievableInvoiceType],
				[GL_XACT_BILL] = NULL,
				[BILL_TYPE] = CASE WHEN (j.[ResourceType] IN('V','I') OR (j.[ResourceType] = 'E' AND j.[FeeTime] = 0)) AND j.[AccountsRecievableInvoiceNumber] IS NOT NULL THEN 'P' WHEN j.[ResourceType] = 'A' AND j.[AdvanceBillFlagDetail] IN(1,2) THEN 'A' WHEN j.[ResourceType] = 'A' AND j.[AdvanceBillFlagDetail] = 5 THEN 'F' WHEN j.[ResourceType] = 'A' THEN 'R' ELSE NULL END,
				[AB_FLAG] = j.[AdvanceBillFlagDetail],
				[BILL_PERIOD] = j.[AccountsRecievablePostPeriodCode],
				[EMP_BILL_RATE] = NULL,
				[SELECT_FLAG] = CASE WHEN j.[ResourceType] = 'C' OR (j.[ResourceType] = 'I' AND j.[IsNonBillable] = 1) THEN 0 ELSE 1 END
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
					[BillableLessResale] = 0,
					[BillableTotal] = 0,
					[ExtMarkupAmount] = 0,
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = 0,
					[Total] = ISNULL(a.AMOUNT, 0),
					[CostAmount] = ISNULL(a.AMOUNT, 0),
					[NetAmount] = 0,
					[AccountsRecievablePostPeriodCode] = NULL,
					[AccountsRecievableInvoiceNumber] = 0,
					[AccountsRecievableInvoiceType] = NULL,
					[AdvanceBillFlagDetail] = 0,
					[IsNonBillable] = 0,
					[GlexActBill] = 0,
					[EstimateHours] = 0,
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
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
					[IsNewBusiness] = 0,
					[Agency] = NULL,
					[BillingApprovalHours] = 0, 
					[BillingApprovalCostAmount] = 0,  
					[BillingApprovalExtNetAmount] = 0,  
					[BillingApprovalTotalAmount] = 0
				FROM 
					dbo.CLIENT_OOP AS a INNER JOIN 
					dbo.FUNCTIONS AS f ON a.FNC_CODE = f.FNC_CODE INNER JOIN 
					dbo.JOB_LOG AS jl ON jl.JOB_NUMBER = a.JOB_NUMBER
					
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
					[Hours] = ISNULL(e.EMP_HOURS, 0),
					[BillableLessResale] = CASE WHEN ISNULL(e.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) END,
					[BillableTotal] = CASE WHEN ISNULL(e.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(e.LINE_TOTAL, 0) END,
					[ExtMarkupAmount] = ISNULL(e.EXT_MARKUP_AMT, 0),
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = ISNULL(e.EXT_STATE_RESALE, 0) + ISNULL(e.EXT_COUNTY_RESALE, 0) + ISNULL(e.EXT_CITY_RESALE, 0),
					[Total] = ISNULL(e.LINE_TOTAL, 0),
					[CostAmount] = 0,
					[NetAmount] = ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) - ISNULL(e.EXT_MARKUP_AMT, 0),
					[AccountsRecievablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
					[AccountsRecievableInvoiceNumber] = e.AR_INV_NBR,
					[AccountsRecievableInvoiceType] = e.AR_TYPE,
					[AdvanceBillFlagDetail] = e.AB_FLAG,
					[IsNonBillable] = ISNULL(e.EMP_NON_BILL_FLAG, 0),
					[GlexActBill] = e.GLEXACT_BILL,
					[EstimateHours] = 0,
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
					[BilledHours] = CASE WHEN e.AR_INV_NBR IS NOT NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
					[FeeTimeAmount] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
					[FeeTimeHours] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME = 1 THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
					[UnbilledAmount] = CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL, 0) ELSE 0 END,
					[UnbilledAmountResale] = CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
					[UnbilledHours] = CASE WHEN e.EMP_NON_BILL_FLAG <> 1 AND e.FEE_TIME <> 1 AND e.AR_INV_NBR IS NULL THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
					[NonBillableAmount] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.LINE_TOTAL, 0) - ISNULL(e.EXT_STATE_RESALE, 0) - ISNULL(e.EXT_COUNTY_RESALE, 0) - ISNULL(e.EXT_CITY_RESALE, 0) ELSE 0 END,
					[NonBillableHours] = CASE WHEN e.EMP_NON_BILL_FLAG = 1 AND e.FEE_TIME <> 1 THEN ISNULL(e.EMP_HOURS, 0) ELSE 0 END,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[Hours] = ISNULL(a.AP_PROD_QUANTITY, 0),
					[BillableLessResale] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) END,
					[BillableTotal] = CASE WHEN ISNULL(a.AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE ISNULL(a.LINE_TOTAL, 0) END,
					[ExtMarkupAmount] = ISNULL(a.EXT_MARKUP_AMT, 0),
					[NonResaleTaxAmount] = ISNULL(a.EXT_NONRESALE_TAX, 0),
					[ResaleTaxAmount] = ISNULL(a.EXT_STATE_RESALE, 0) + ISNULL(a.EXT_COUNTY_RESALE, 0) + ISNULL(a.EXT_CITY_RESALE, 0),
					[Total] = ISNULL(a.LINE_TOTAL, 0),
					[CostAmount] = a.AP_PROD_EXT_AMT,
					[NetAmount] = (ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0)) - ISNULL(a.EXT_MARKUP_AMT, 0),
					[AccountsRecievablePostPeriodCode] = ISNULL(ar.AR_POST_PERIOD, ''),
					[AccountsRecievableInvoiceNumber] = a.AR_INV_NBR,
					[AccountsRecievableInvoiceType] = a.AR_TYPE,
					[AdvanceBillFlagDetail] = a.AB_FLAG,
					[IsNonBillable] = ISNULL(a.AP_PROD_NOBILL_FLG, 0),
					[GlexActBill] = a.GLEXACT_BILL,
					[EstimateHours] = 0,
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
					[BilledAmount] = CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL, 0) - ISNULL(a.EXT_STATE_RESALE, 0) - ISNULL(a.EXT_COUNTY_RESALE, 0) - ISNULL(a.EXT_CITY_RESALE, 0) ELSE 0 END,
					[BilledWithResale] = CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.LINE_TOTAL, 0) ELSE 0 END,
					[BilledHours] = CASE WHEN a.AR_INV_NBR IS NOT NULL THEN ISNULL(a.AP_PROD_QUANTITY, 0) ELSE 0 END,
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[Hours] = 0,
					[BillableLessResale] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0) END,
					[BillableTotal] = CASE WHEN ISNULL(ino.NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ino.LINE_TOTAL, 0) END,
					[ExtMarkupAmount] = ISNULL(ino.EXT_MARKUP_AMT, 0),
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = ISNULL(ino.EXT_STATE_RESALE, 0) + ISNULL(ino.EXT_COUNTY_RESALE, 0) + ISNULL(ino.EXT_CITY_RESALE, 0),
					[Total] = ISNULL(ino.LINE_TOTAL, 0),
					[CostAmount] = 0,			
					[NetAmount] = (ISNULL(ino.LINE_TOTAL, 0) - ISNULL(ino.EXT_STATE_RESALE, 0) - ISNULL(ino.EXT_COUNTY_RESALE, 0) - ISNULL(ino.EXT_CITY_RESALE, 0)) - ISNULL(ino.EXT_MARKUP_AMT, 0),
					[AccountsRecievablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
					[AccountsRecievableInvoiceNumber] = ino.AR_INV_NBR,
					[AccountsRecievableInvoiceType] = ino.AR_TYPE,
					[AdvanceBillFlagDetail] = ino.AB_FLAG,
					[IsNonBillable] = ISNULL(ino.NON_BILL_FLAG, 0),
					[GlexActBill] = ino.GLEXACT_BILL,
					[EstimateHours] = 0,
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
					[BilledHours] = 0,
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[BillableLessResale] = 0,
					[BillableTotal] = 0,
					[ExtMarkupAmount] = 0,
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = 0,
					[Total] = 0,
					[CostAmount] = 0,
					[NetAmount] = 0,
					[AccountsRecievablePostPeriodCode] = ISNULL(a.AR_POST_PERIOD, ''),
					[AccountsRecievableInvoiceNumber] = ab.AR_INV_NBR,
					[AccountsRecievableInvoiceType] = ab.AR_TYPE,
					[AdvanceBillFlagDetail] = ab.AB_FLAG,
					[IsNonBillable] = 0,
					[GlexActBill] = ab.GLEXACT,
					[EstimateHours] = 0,
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
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[BillableLessResale] = 0,
					[BillableTotal] = 0,
					[ExtMarkupAmount] = 0,
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = 0,
					[Total] = 0,
					[CostAmount] = 0,
					[NetAmount] = 0,
					[AccountsRecievablePostPeriodCode] = NULL,
					[AccountsRecievableInvoiceNumber] = 0,
					[AccountsRecievableInvoiceType] = NULL,
					[AdvanceBillFlagDetail] = 0,
					[IsNonBillable] = 0,
					[GlexActBill] = 0,
					[EstimateHours] = ISNULL(ed.EST_REV_QUANTITY, 0),
					[EstimateTotalAmount] = ISNULL(ed.LINE_TOTAL, 0),
					[EstimateContTotalAmount] = ISNULL(ed.LINE_TOTAL_CONT, 0),
					[EstimateNonResaleTaxAmount] = ISNULL(ed.EXT_NONRESALE_TAX, 0),
					[EstimateResaleTaxAmount] = ISNULL(ed.EXT_STATE_RESALE, 0) + ISNULL(ed.EXT_COUNTY_RESALE, 0) + ISNULL(ed.EXT_CITY_RESALE, 0),
					[EstimateMarkupAmount] = ISNULL(ed.EXT_MARKUP_AMT, 0),
					[EstimateCostAmount] = 0,
					[IsEstimateNonBillable] = 0,
					[EstimateFeeTime] = 0,
					[EstimateNetAmount] = (ISNULL(ed.LINE_TOTAL, 0) - ISNULL(ed.EXT_STATE_RESALE, 0) - ISNULL(ed.EXT_COUNTY_RESALE, 0) - ISNULL(ed.EXT_CITY_RESALE, 0)) - ISNULL(ed.EXT_MARKUP_AMT, 0),
					[PurchaseOrderNumber] = 0,
					[OpenPurchaseOrderAmount] = 0,
					[OpenPurchaseOrderGrossAmount] = 0,
					[BilledAmount] = 0,
					[BilledWithResale] = 0,
					[BilledHours] = 0,
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[BillableLessResale] = 0,
					[BillableTotal] = 0,
					[ExtMarkupAmount] = 0,
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = 0,
					[Total] = 0,
					[CostAmount] = 0,
					[NetAmount] = 0,
					[AccountsRecievablePostPeriodCode] = NULL,
					[AccountsRecievableInvoiceNumber] = 0,
					[AccountsRecievableInvoiceType] = NULL,
					[AdvanceBillFlagDetail] = 0,
					[IsNonBillable] = 0,
					[GlexActBill] = 0,
					[EstimateHours] = ISNULL(ed.EST_REV_QUANTITY, 0),
					[EstimateTotalAmount] = ISNULL(ed.LINE_TOTAL, 0),
					[EstimateContTotalAmount] = ISNULL(ed.LINE_TOTAL_CONT, 0),
					[EstimateNonResaleTaxAmount] = ISNULL(ed.EXT_NONRESALE_TAX, 0),
					[EstimateResaleTaxAmount] = ISNULL(ed.EXT_STATE_RESALE, 0) + ISNULL(ed.EXT_COUNTY_RESALE, 0) + ISNULL(ed.EXT_CITY_RESALE, 0),
					[EstimateMarkupAmount] = ISNULL(ed.EXT_MARKUP_AMT, 0),
					[EstimateCostAmount] = 0,
					[IsEstimateNonBillable] = 0,
					[EstimateFeeTime] = 0,
					[EstimateNetAmount] = (ISNULL(ed.LINE_TOTAL, 0) - ISNULL(ed.EXT_STATE_RESALE, 0) - ISNULL(ed.EXT_COUNTY_RESALE, 0) - ISNULL(ed.EXT_CITY_RESALE, 0)) - ISNULL(ed.EXT_MARKUP_AMT, 0),
					[PurchaseOrderNumber] = 0,
					[OpenPurchaseOrderAmount] = 0,
					[OpenPurchaseOrderGrossAmount] = 0,
					[BilledAmount] = 0,
					[BilledWithResale] = 0,
					[BilledHours] = 0,
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
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
					(SELECT CL_CODE FROM AGENCY_CLIENTS) AS acl ON acl.CL_CODE = c.CL_CODE
					
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
					[BillableLessResale] = 0,
					[BillableTotal] = 0,
					[ExtMarkupAmount] = 0,
					[NonResaleTaxAmount] = 0,
					[ResaleTaxAmount] = 0,
					[Total] = 0,
					[CostAmount] = 0,
					[NetAmount] = 0,
					[AccountsRecievablePostPeriodCode] = NULL,
					[AccountsRecievableInvoiceNumber] = 0,
					[AccountsRecievableInvoiceType] = NULL,
					[AdvanceBillFlagDetail] = 0,
					[IsNonBillable] = 0,
					[GlexActBill] = 0,
					[EstimateHours] = 0,
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
					[FeeTimeAmount] = 0,
					[FeeTimeHours] = 0,
					[UnbilledAmount] = 0,
					[UnbilledAmountResale] = 0,
					[UnbilledHours] = 0,
					[NonBillableAmount] = 0,
					[NonBillableHours] = 0,
					[IsNewBusiness] = 0,
					[Agency] = NULL,
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
						ISNULL(ap.DELETE_FLAG, 0) = 0  AND 
						ISNULL(ap.MODIFY_DELETE, 0) = 0
					GROUP BY 
						ap.PO_NUMBER, 
						ap.PO_LINE_NUMBER 
					HAVING 
						SUM(ap.AP_PROD_EXT_AMT) <> 0) ap ON pd.PO_NUMBER = ap.PO_NUMBER AND 
															pd.LINE_NUMBER = ap.PO_LINE_NUMBER INNER JOIN 
					dbo.FUNCTIONS f ON pd.FNC_CODE = f.FNC_CODE
				WHERE
					pd.JOB_NUMBER IS NOT NULL AND
					pd.JOB_COMPONENT_NBR IS NOT NULL AND
					pd.FNC_CODE IS NOT NULL AND 
					(pd.PO_COMPLETE IS NULL OR 
					 pd.PO_COMPLETE = 0) AND 
					(p.VOID_FLAG IS NULL OR 
					 p.VOID_FLAG = 0) AND
					(ISNULL(pd.PO_EXT_AMOUNT, 0) - ISNULL(ap.AP_NET_AMT, 0)) <> 0) AS j) AS j2
		GROUP BY 
			j2.JOB_NUMBER, 
			j2.JOB_COMPONENT_NBR, 
			j2.[ORDER], 
			j2.FNC_TYPE, 
			j2.FNC_CODE, 
			j2.ITEM_DESC,
			j2.[DATE], 
			j2.ITEM_CODE,
			j2.BILL_PERIOD, 
			j2.NONAP_DATE, 
			j2.NB_FLAG) AS j3 JOIN 
		dbo.JOB_LOG AS jl ON j3.JOB_NUMBER = jl.JOB_NUMBER JOIN 
		dbo.JOB_COMPONENT AS jc ON j3.JOB_NUMBER = jc.JOB_NUMBER AND 
								   j3.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR JOIN 
		dbo.CLIENT AS c ON jl.CL_CODE = c.CL_CODE JOIN 
		dbo.DIVISION AS d ON jl.CL_CODE = d.CL_CODE AND 
							 jl.DIV_CODE = d.DIV_CODE JOIN 
		dbo.PRODUCT AS p ON jl.CL_CODE = p.CL_CODE AND 
							jl.DIV_CODE = p.DIV_CODE AND 
							jl.PRD_CODE = p.PRD_CODE JOIN 
		dbo.EMPLOYEE AS e ON jc.EMP_CODE = e.EMP_CODE JOIN 
		dbo.FUNCTIONS AS f ON j3.FNC_CODE = f.FNC_CODE	

