if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_analysis_cdp_load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_analysis_cdp_load]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_analysis_cdp_load]
	@OPEN_JOB_ONLY AS bit = 1,
	@EXCLUDE_NONBILL_HRS AS bit = 0,
	@OFFICE_LIST AS varchar(MAX) = NULL,
	@CLIENT_LIST AS varchar(MAX) = NULL,
	@DIVISION_LIST AS varchar(MAX) = NULL,
	@PRODUCT_LIST AS varchar(MAX) = NULL,
	@JOB_LIST AS varchar(MAX) = NULL,
	@ACCT_EXEC_LIST AS varchar(MAX) = NULL,
	@SALES_CLASS_LIST AS varchar(MAX) = NULL,
	@USER_CODE AS varchar(100)

AS
BEGIN

	if @OFFICE_LIST = ''
	Begin
		SET @OFFICE_LIST = NULL
	End
	if @CLIENT_LIST = ''
	Begin
		SET @CLIENT_LIST = NULL
	End
	if @DIVISION_LIST = ''
	Begin
		SET @DIVISION_LIST = NULL
	End
	if @PRODUCT_LIST = ''
	Begin
		SET @PRODUCT_LIST = NULL
	End
	if @JOB_LIST = ''
	Begin
		SET @JOB_LIST = NULL
	End
	if @ACCT_EXEC_LIST = ''
	Begin
		SET @ACCT_EXEC_LIST = NULL
	End
	if @SALES_CLASS_LIST = ''
	Begin
		SET @SALES_CLASS_LIST = NULL
	End


	SELECT
		[ID] = ISNULL(NEWID(), NEWID()),
		[ClientCode] = SJDA.[ClientCode],
		[ClientDescription] = SJDA.[ClientDescription],
		[DivisionCode] = SJDA.[DivisionCode],
		[DivisionDescription] = SJDA.[DivisionDescription],
		[ProductCode] = SJDA.[ProductCode],
		[ProductDescription] = SJDA.[ProductDescription],
		[AccountExecutiveCode] = SJDA.[AccountExecutiveCode],
		[AccountExecutive] = SJDA.[AccountExecutive],
		[SumOfEstimateHours] = SJDA.SumOfESTIMATE_HRS_QTY,
		[SumOfEstimate] = SJDA.SumOfESTIMATE,
		[SumOfEstimateCont] = SJDA.SumOfESTCONT,
		[SumOfEstimateNetCost] = SJDA.SumOfEST_NET_COST,
		[SumOfEstimateNetAmount] = SJDA.SumOfEST_NET_AMT,
		[SumOfEstimateExtMarkup] = SJDA.SumOfEST_EXT_MARKUP,
		[SumOfEstimateVenTax] = SJDA.SumOfEST_VEN_TAX,
		[SumOfEstimateResaleTax] = SJDA.SumOfEST_RESALE_TAX,
		[SumOfIncomeOnly] = SJDA.SumOfINCOME_ONLY,
		[SumOfBillEmpHours] = SJDA.SumOfBILL_EMP_HOURS,
		[SumOfTotalBill] = SJDA.SumOfTOTAL_BILL,
		[SumOfAPQuantity] = SJDA.SumOfAP_QUANTITY,
		[SumOfAPNetCost] = SJDA.SumOfAP_NET_COST,
		[SumOfExtMarkupAmount] = SJDA.SumOfEXT_MARKUP_AMT,
		[SumOfVenTax] = SJDA.SumOfVEN_TAX,
		[SumOfResaleTax] = SJDA.SumOfRESALE_TAX,
		[SumOfResaleBilled] = SJDA.SumOfRESALE_BILLED,
		[SumOfOpenPOAmount] = SJDA.SumOfOPEN_PO_AMT,
		[SumOfLineTotal] = SJDA.SumOfLINE_TOTAL,
		[SumOfNonBillableEmpHours] = SJDA.SumOfNB_EMP_HOURS,
		[SumOfNonBillableAmount] = SJDA.SumOfNB_AMOUNT,
		[SumOfNonBillableMarkupAmount] = SJDA.SumOfNB_MARKUP_AMT,
		[SumOfBilledAmount] = SJDA.SumOfAMT_BILLED,
		[SumOfAdvanceBilled] = SJDA.SumOfADVANCE_BILLED,
		[SumOfAdvanceTotal] = SJDA.SumOfADVANCE_TOTAL,
		[SumOfAdvanceResale] = SJDA.SumOfADVANCE_RESALE,
		[SumOfAdvanceResaleBilled] = SJDA.SumOfADVANCE_RESALE_BILLED,
		[SumOfAdvanceFinalBilled] = SJDA.SumOfADVANCE_FINAL_BILLED,
		[SumOfBilledCost] = SJDA.SumOfCOST_BILLED,
		[SumOfUnbilled] = SJDA.SumOfUNBILLED
	FROM
		(SELECT
			[SumOfESTIMATE_HRS_QTY] = SUM(JDA.ESTIMATE_HRS_QTY),
			[SumOfESTIMATE] = SUM(JDA.ESTIMATE),
			[SumOfESTCONT] = SUM(JDA.ESTCONT),
			[SumOfEST_NET_COST] = SUM(JDA.EST_NET_COST),
			[SumOfEST_NET_AMT] = SUM(JDA.EST_NET_AMT),
			[SumOfEST_EXT_MARKUP] = SUM(JDA.EST_EXT_MARKUP),
			[SumOfEST_VEN_TAX] = SUM(JDA.EST_VEN_TAX),
			[SumOfEST_RESALE_TAX] = SUM(JDA.EST_RESALE_TAX),
			[SumOfBILL_EMP_HOURS] = SUM(JDA.BILL_EMP_HOURS),
			[SumOfNB_EMP_HOURS] = SUM(JDA.NB_EMP_HOURS),
			[SumOfINCOME_ONLY] = SUM(JDA.INCOME_ONLY),
			[SumOfAP_QUANTITY] = SUM(JDA.AP_QUANTITY),
			[SumOfAP_NET_COST] = SUM(JDA.AP_NET_COST),
			[SumOfEXT_MARKUP_AMT] = SUM(JDA.EXT_MARKUP_AMT),
			[SumOfTOTAL_BILL] = SUM(JDA.TOTAL_BILL),
			[SumOfLINE_TOTAL] = SUM(JDA.LINE_TOTAL),
			[SumOfNB_AMOUNT] = SUM(JDA.NB_AMOUNT),
			[SumOfNB_MARKUP_AMT] = SUM(JDA.NB_MARKUP_AMT),
			[SumOfAMT_BILLED] = SUM(JDA.AMT_BILLED),
			[SumOfRESALE_TAX] = SUM(JDA.RESALE_TAX),
			[SumOfRESALE_BILLED] = SUM(JDA.RESALE_BILLED),
			[SumOfVEN_TAX] = SUM(JDA.VEN_TAX),
			[SumOfAMT_BILLED_NORTAX] = SUM(JDA.AMT_BILLED - JDA.RESALE_BILLED),
			[SumOfADVANCE_BILLED] = SUM(JDA.ADVANCE_BILLED),
			[SumOfADVANCE_BILLED_NOTAX] = SUM(JDA.ADVANCE_BILLED_NOTAX),
			[SumOfADVANCE_TOTAL] = SUM(JDA.ADVANCE_TOTAL),
			[SumOfADVANCE_TOTAL_NOTAX] = SUM(JDA.ADVANCE_TOTAL_NOTAX),
			[SumOfADVANCE_RESALE] = SUM(JDA.ADVANCE_RESALE),
			[SumOfADVANCE_RESALE_BILLED] = SUM(JDA.ADVANCE_RESALE_BILLED),
			[SumOfADVANCE_FINAL_BILLED] =  SUM(JDA.ADVANCE_FINAL),--SUM(CASE JDA.AB_FLAG WHEN 5 THEN JDA.AMT_BILLED ELSE 0 END),
			[SumOfOPEN_PO_AMT] = SUM(JDA.OPEN_PO_AMT),
			[SumOfCOST_BILLED] = SUM(JDA.COST_BILLED),
			[SumOfUNBILLED] = SUM(JDA.UNBILLED),
			JDA.[ClientCode],
			JDA.[ClientDescription],
			JDA.[DivisionCode],
			JDA.[DivisionDescription],
			JDA.[ProductCode],
			JDA.[ProductDescription],
			JDA.[AccountExecutiveCode],
			JDA.[AccountExecutive]
		FROM
			(SELECT
				[REC_SOURCE] = JD.[ResourceType],
				[JOB_NUMBER] = JD.[JobNumber],
				[JOB_COMPONENT_NBR] = JD.[JobComponentNumber],
				[FNC_TYPE] = JD.[FunctionType],
				[FNC_CODE] = JD.[FunctionCode],
				[FNC_DESC]	= JD.[FunctionDescription],
				[POST_PERIOD] = JD.[PostPeriodCode],
				[DATE] = JD.[ItemDate],
				[NONAP_DATE] = CASE JD.[FunctionType] WHEN 'E' THEN JD.[ItemDate] ELSE NULL END,
				[ITEM_ID] = JD.	[ItemID],
				[ITEM_SEQ] = JD.[ItemSequenceNumber],
				[AP_ID] = NULL,
				[VN_EMP_CODE] = JD.[ItemCode],
				[ITEM_DESC] = JD.[ItemDescription],
				[ITEM_CODE] = CASE JD.[ResourceType] WHEN 'AB' THEN CAST(JD.[ItemID] AS varchar) WHEN 'E' THEN NULL WHEN 'I' THEN NULL WHEN 'V' THEN JD.[ItemExtra] WHEN 'PO' THEN 'PO #: ' + CAST(JD.[PurchaseOrderNumber] AS varchar) END,
				[BILL_EMP_HOURS] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN JD.[Hours] ELSE 0 END,
				[NB_EMP_HOURS] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 1 THEN JD.[Hours] ELSE 0 END,
				[BILLED_EMP_HOURS] = CASE WHEN (JD.[ResourceType] = 'E' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[Hours] ELSE 0 END,
				[AP_QUANTITY] = CASE JD.[ResourceType] WHEN 'V' THEN JD.[Quantity] ELSE 0 END,
				[AP_NET_COST] = CASE WHEN JD.[ResourceType] = 'V' OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[CostAmount] ELSE 0 END,
				[EXT_MARKUP_AMT] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[ExtMarkupAmount] ELSE 0 END,
				[EXT_MARKUP_BILLED] = CASE WHEN (JD.[ResourceType] IN('E','I','V') AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[ExtMarkupAmount] ELSE 0 END,
				[TOTAL_BILL] = CASE WHEN JD.[ResourceType] = 'E' AND JD.[IsNonBillable] = 0 THEN JD.[BillableLessResale] ELSE 0 END,
				[INCOME_ONLY] = CASE WHEN JD.[ResourceType] = 'I' THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
				[LINE_TOTAL] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[Total] ELSE 0 END,
				[CLIENT_OOP_AMT] = NULL,
				[NB_AMOUNT] = CASE WHEN JD.[ResourceType] IN('E','V') AND JD.[IsNonBillable] = 1 THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
				[NB_AP_NET_COST] = CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 1 THEN ISNULL(JD.[CostAmount],0) ELSE 0 END,
				[NB_NET_TAX] = CASE JD.[IsNonBillable] WHEN 1 THEN ISNULL(JD.[NonResaleTaxAmount],0) ELSE 0 END,
				[NB_MARKUP_AMT] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 1 THEN ISNULL(JD.[ExtMarkupAmount],0) ELSE 0 END,
				[COST_BILLED] = CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 0 AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN JD.[CostAmount] + JD.[NonResaleTaxAmount] ELSE 0 END,
				[AMT_BILLED] = CASE WHEN JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[Total] ELSE 0 END,
				[ACT_STATE_TAX] = NULL,
				[ACT_COUNTY_TAX] = NULL,
				[ACT_CITY_TAX] = NULL,
				[RESALE_TAX] = CASE WHEN JD.[ResourceType] IN('E','I','V') AND JD.[IsNonBillable] = 0 THEN JD.[ResaleTaxAmount] ELSE 0 END,
				[RESALE_BILLED] = CASE WHEN (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) AND JD.[IsNonBillable] = 0  THEN JD.[ResaleTaxAmount] ELSE 0 END,
				[VEN_TAX] = CASE WHEN JD.[ResourceType] = 'V' AND JD.[IsNonBillable] = 0 AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN JD.[NonResaleTaxAmount] ELSE 0 END,
				[ADVANCE_BILLED] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[BilledAmount] ELSE 0 END,
				[ADVANCE_TOTAL] = CASE JD.[ResourceType] WHEN 'AB' THEN JD.[Total] ELSE 0 END,
				[ADVANCE_TOTAL_NOTAX] = CASE JD.[ResourceType] WHEN 'AB' THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_BILLED_NOTAX] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[Total] - JD.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_RESALE] = CASE JD.[ResourceType] WHEN 'AB' THEN JD.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_RESALE_BILLED] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL) OR JD.[AdvanceBillFlagDetail] = 3 THEN JD.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_ADJUSTED] = NULL,
				[ADVANCE_COST_BILLED] = CASE WHEN (JD.[ResourceType] = 'AB' AND JD.[FunctionType] = 'V') AND (JD.[AccountsReceivableInvoiceNumber] IS NOT NULL OR JD.[AdvanceBillFlagDetail] = 3) THEN JD.[Total] - JD.[ExtMarkupAmount] - JD.[ResaleTaxAmount] ELSE 0 END,
				[ADVANCE_FINAL] = CASE WHEN JD.[ResourceType] = 'AB' AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL AND JD.[AdvanceBillFlagDetail] = 5 THEN JD.[BilledAmount] ELSE 0 END,
				[PO_EXT_AMT] = NULL,
				[OPEN_PO_AMT] = ISNULL(JD.[OpenPurchaseOrderAmount],0),
				[ESTIMATE] = ISNULL(JD.[EstimateTotalAmount],0) + ISNULL(JD.[EstimateContTotalAmount],0),
				[ESTIMATE_HRS_QTY] = CASE WHEN (JD.[ResourceType] IN('ES','EI') AND JD.[FunctionType] IN('V')) THEN JD.[EstimateQuantity] ELSE JD.[EstimateHours] END,
				[ESTCONT] = JD.[EstimateContTotalAmount],
				[EST_NET_COST] = JD.[EstimateCostAmount],
				[EST_NET_AMT] = JD.[EstimateNetAmount],
				[EST_EXT_MARKUP] = JD.[EstimateMarkupAmount],
				[EST_VEN_TAX] = JD.[EstimateNonResaleTaxAmount],
				[EST_RESALE_TAX] = JD.[EstimateResaleTaxAmount],
				[NB_FLAG] = JD.[IsNonBillable],
				[ORDER] = CASE JD.[ResourceType] WHEN 'ES' THEN 1 WHEN 'AB' THEN 2 WHEN 'E' THEN 3 WHEN 'I' THEN 4 WHEN 'V' THEN 5 WHEN 'PO' THEN 6 END,
				[AR_INV_NBR] = JD.[AccountsReceivableInvoiceNumber],
				[AR_INV_TYPE] = JD.[AccountsReceivableInvoiceType],
				[GL_XACT_BILL] = NULL,
				[BILL_TYPE] = CASE WHEN (JD.[ResourceType] IN('V','I') OR (JD.[ResourceType] = 'E' AND JD.[FeeTime] = 0)) AND JD.[AccountsReceivableInvoiceNumber] IS NOT NULL THEN 'P' WHEN JD.[ResourceType] = 'AB' AND JD.[AdvanceBillFlagDetail] IN(1,2) THEN 'A' WHEN JD.[ResourceType] = 'AB' AND JD.[AdvanceBillFlagDetail] = 5 THEN 'F' WHEN JD.[ResourceType] = 'AB' THEN 'R' ELSE NULL END,
				[AB_FLAG] = JD.[AdvanceBillFlagDetail],
				[BILL_PERIOD] = JD.[AccountsReceivablePostPeriodCode],
				[EMP_BILL_RATE] = NULL,
				[SELECT_FLAG] = CASE WHEN JD.[ResourceType] = 'C' OR (JD.[ResourceType] = 'I' AND JD.[IsNonBillable] = 1) THEN 0 ELSE 1 END,
				[UNBILLED] = CASE WHEN JD.[AccountsReceivableInvoiceNumber] IS NULL THEN JD.[UnbilledAmount] ELSE 0 END,
				JD.[JobProcessControl],
				JD.[MarkupPercent],
				JD.[ClientPO],
				JD.[BillHold],
				JD.[AdvanceBillFlag],
				JD.[ClientCode],
				JD.[ClientDescription],
				JD.[DivisionCode],
				JD.[DivisionDescription],
				JD.[ProductCode],
				JD.[ProductDescription],
				JD.[AccountExecutiveCode],
				JD.[AccountExecutive],
				JD.[ClientReference],
				JD.[JobDescription],
				JD.[SalesClassCode],
				JD.[ComponentDescription],
				JD.[JobTypeCode],
				JD.[EstimateNumber],
				JD.[EstimateComponentNumber],
				JD.[JobComponent],
				JD.[FunctionDescription]
			FROM
				(SELECT	
					C.[ResourceType],
					C.[JobNumber],
					C.[JobComponentNumber],
					C.[FunctionType],
					C.[FunctionConsolidationCode],
					C.[FunctionConsolidation],
					C.[FunctionHeading],
					C.[FunctionCode],
					C.[FunctionDescription],
					C.[ItemID],
					C.[ItemSequenceNumber],
					C.[ItemDate],
					C.[PostPeriodCode],
					C.[ItemCode],
					C.[ItemDescription],
					C.[ItemComment],
					C.[ItemExtra],
					C.[FeeTime],
					C.[Hours],
					C.[Quantity],
					C.[BillableLessResale],
					C.[BillableTotal],
					C.[ExtMarkupAmount],
					C.[NonResaleTaxAmount],
					C.[ResaleTaxAmount],
					C.[Total],
					C.[CostAmount],
					C.[NetAmount],
					C.[AccountsReceivablePostPeriodCode],
					C.[AccountsReceivableInvoiceNumber],
					C.[AccountsReceivableInvoiceType],
					C.[AdvanceBillFlagDetail],
					C.[IsNonBillable],
					C.[GlexActBill],
					C.[EstimateHours],
					C.[EstimateQuantity],
					C.[EstimateTotalAmount],
					C.[EstimateContTotalAmount],
					C.[EstimateNonResaleTaxAmount],
					C.[EstimateResaleTaxAmount],
					C.[EstimateMarkupAmount],
					C.[EstimateCostAmount],
					C.[IsEstimateNonBillable],
					C.[EstimateFeeTime],
					C.[EstimateNetAmount],
					C.[PurchaseOrderNumber],
					C.[OpenPurchaseOrderAmount],
					C.[OpenPurchaseOrderGrossAmount],
					C.[BilledAmount],
					C.[BilledWithResale],
					C.[BilledHours],
					C.[BilledQuantity],
					C.[FeeTimeAmount],
					C.[FeeTimeHours],
					C.[UnbilledAmount],
					C.[UnbilledAmountLessResale],
					C.[UnbilledHours],
					C.[UnbilledQuantity],
					C.[NonBillableAmount],
					C.[NonBillableHours],
					C.[NonBillableQuantity],
					C.[IsNewBusiness],
					C.[Agency],
					C.[BillingApprovalHours],
					C.[BillingApprovalCostAmount],
					C.[BillingApprovalExtNetAmount],
					C.[BillingApprovalTotalAmount],
					C.[JobProcessControl],
					C.[MarkupPercent],
					C.[ClientPO],
					C.[BillHold],
					C.[AdvanceBillFlag],
					C.[ClientCode],
					C.[ClientDescription],
					C.[DivisionCode],
					C.[DivisionDescription],
					C.[ProductCode],
					C.[ProductDescription],
					C.[AccountExecutiveCode],
					C.[AccountExecutive],
					C.[ClientReference],
					C.[JobDescription],
					C.[SalesClassCode],
					C.[ComponentDescription],
					C.[JobTypeCode],
					C.[EstimateNumber],
					C.[EstimateComponentNumber],
					C.[JobComponent]
				FROM 
					[dbo].[V_DRPT_JOB_DETAILS_ITEM_E] AS C INNER JOIN dbo.advtf_user_job_limits(@USER_CODE) JL ON C.JobNumber = JL.JOB_NUMBER
				WHERE
					1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (C.[JobProcessControl] = 'Closed' OR C.[JobProcessControl] = 'Archive') THEN 0 ELSE 1 END AND
					1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND C.[IsNonBillable] = 1 THEN 0 ELSE 1 END AND
					(C.OfficeCode IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
					(C.ClientCode IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
					1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (C.ClientCode + '|' + C.DivisionCode) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
					1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (C.ClientCode + '|' + C.DivisionCode + '|' + C.ProductCode) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
					(C.JobNumber IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
					(C.AccountExecutiveCode IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
					(C.SalesClassCode IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL)
					-- AND (C.[Hours] > 0)
					
				
				) AS JD) AS JDA
		GROUP BY 
			JDA.[ClientCode],
			JDA.[ClientDescription],
			JDA.[DivisionCode],
			JDA.[DivisionDescription],
			JDA.[ProductCode],
			JDA.[ProductDescription],
			JDA.[AccountExecutiveCode],
			JDA.[AccountExecutive]
			) AS SJDA

END

