if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_analysis_cdp_load_report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_analysis_cdp_load_report]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_analysis_cdp_load_report]
	@OPEN_JOB_ONLY AS bit = 1,
	@EXCLUDE_NONBILL_HRS AS bit = 0,
	@OFFICE_LIST AS varchar(MAX) = NULL,
	@CLIENT_LIST AS varchar(MAX) = NULL,
	@DIVISION_LIST AS varchar(MAX) = NULL,
	@PRODUCT_LIST AS varchar(MAX) = NULL,
	@JOB_LIST AS varchar(MAX) = NULL,
	@ACCT_EXEC_LIST AS varchar(MAX) = NULL,
	@SALES_CLASS_LIST AS varchar(MAX) = NULL,
	@DATE_CUTOFF AS VARCHAR(6),
	@USER_CODE AS varchar(100)

AS
BEGIN
				
	
	DECLARE @StartDate smalldatetime, @EndDate smalldatetime

	SELECT @StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @DATE_CUTOFF

	SELECT @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @DATE_CUTOFF	

	DECLARE @RESTRICTIONS INT
	
	SELECT @RESTRICTIONS = COUNT(*) FROM dbo.SEC_CLIENT WHERE SEC_CLIENT.[USER_ID] = @USER_CODE

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

	if @RESTRICTIONS > 0
	BEGIN
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
						[ResourceType] = 'E',
						[JobNumber] = ETD.JOB_NUMBER,
						[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
						[OfficeCode] = J.OFFICE_CODE,
						[OfficeDescription] = O.OFFICE_NAME,
						[ClientCode] = J.CL_CODE,
						[ClientDescription] = C.CL_NAME,
						[DivisionCode] = J.DIV_CODE,
						[DivisionDescription] = D.DIV_NAME,
						[ProductCode] = J.PRD_CODE,
						[ProductDescription] = P.PRD_DESCRIPTION,
						[CampaignID] = CAMP.CMP_IDENTIFIER,
						[CampaignCode] = J.CMP_CODE, 
						[CampaignName] = CAMP.CMP_NAME,
						[SalesClassCode] = J.SC_CODE,
						[SalesClassDescription] = SC.SC_DESCRIPTION,
						[UserCode] = J.[USER_ID],
						[JobCreateDate] = J.CREATE_DATE,
						[JobDescription] = J.JOB_DESC,
						[JobDateOpened] = J.JOB_DATE_OPENED,
						[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
						[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
						[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
						[ClientReference] = J.JOB_CLI_REF,
						[BillingCoopCode] = J.BILL_COOP_CODE,
						[SalesClassFormatCode] = J.FORMAT_SC_CODE,
						[ComplexityCode] = J.COMPLEX_CODE,
						[PromotionCode] = J.PROMO_CODE,
						[BillingComment] = J.JOB_BILL_COMMENT,
						[LabelFromUDFTable1] = JUDV1.UDV_DESC,
						[LabelFromUDFTable2] = JUDV2.UDV_DESC,
						[LabelFromUDFTable3] = JUDV3.UDV_DESC,
						[LabelFromUDFTable4] = JUDV4.UDV_DESC,
						[LabelFromUDFTable5] = JUDV5.UDV_DESC,
						[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
						[ComponentNumber] = JC.JOB_COMPONENT_NBR,
						[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
						[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
						[AccountExecutiveCode] = JC.EMP_CODE,
						[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
						[ComponentDateOpened] = JC.JOB_COMP_DATE,
						[DueDate] = JC.JOB_FIRST_USE_DATE,
						[StartDate] = JC.[START_DATE],
						[AdSize] = JC.JOB_AD_SIZE,
						[DepartmentTeamCode] = JC.DP_TM_CODE,
						[DepartmentTeam] = DT.DP_TM_DESC,
						[MarkupPercent] = JC.JOB_MARKUP_PCT,
						[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
						[JobProcessControl] = JPC.JOB_PROCESS_DESC,
						[ComponentDescription] = JC.JOB_COMP_DESC,
						[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
						[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
						[EstimateNumber] = JC.ESTIMATE_NUMBER,
						[EstimateDescription] = EL.EST_LOG_DESC,
						[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
						[EstimateComponentDescription] = EC.EST_COMP_DESC,
						[BillingUser] = JC.BILLING_USER,
						[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
						[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
						[JobTypeCode] = JC.JT_CODE,
						[JobTypeDescription] = JT.JT_DESC,
						[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[TaxCode] = JC.TAX_CODE,
						[TaxCodeDescription] = ST.TAX_DESCRIPTION,
						[NonBillable] = JC.NOBILL_FLAG,
						[AlertGroup] = JC.EMAIL_GR_CODE,
						[AdNumber] = JC.AD_NBR,
						[AccountNumber] = JC.ACCT_NBR,
						[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
						[MarketCode] = JC.MARKET_CODE,
						[MarketDescription] = M.MARKET_DESC,
						[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[ServiceFeeTypeCode] = SFT.CODE,
						[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
						[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
						[ClientPO] = JC.JOB_CL_PO_NBR,
						[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
						[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
						[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
						[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
						[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
						[JobTemplateCode] = JC.JOB_TMPLT_CODE,
						[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
						[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
						[JobQuantity] = JC.JOB_QTY,
						[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
						[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
						[ClientContactCode] = JC.CDP_CONTACT_ID,
						[ClientContactID] = JC.PRD_CONT_CODE,
						[BABatchID] = JC.BA_BATCH_ID,
						[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
						[SelectedBABatchID] = JC.SELECTED_BA_ID,
						[BillingCommandCenterID] = JC.BCC_ID,
						[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
						[FunctionType] = F.FNC_TYPE,
						[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
						[FunctionConsolidation] = CF.FNC_DESCRIPTION,
						[FunctionHeading] = FH.FNC_HEADING_DESC,
						[FunctionCode] = ETD.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[ItemID] = ETD.ET_ID,
						[ItemSequenceNumber] = ETD.ET_DTL_ID,
						[ItemLineNumber] = ETD.SEQ_NBR,
						[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
						[PostPeriodCode] = CAST(NULL AS varchar(8)),
						[ItemCode] = ET.EMP_CODE,
						[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
						--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
						[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
						[ItemExtra] = CAST(NULL AS varchar(20)),
						[FeeTime] = ISNULL(ETD.FEE_TIME, 0),
						[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[BillableLessResale] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END,
						[BillableTotal] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) END,
						[ExtMarkupAmount] = ISNULL(ETD.EXT_MARKUP_AMT, 0),
						[NonResaleTaxAmount] = 0,
						[ResaleTaxAmount] = ISNULL(ETD.EXT_STATE_RESALE, 0) + ISNULL(ETD.EXT_COUNTY_RESALE, 0) + ISNULL(ETD.EXT_CITY_RESALE, 0),
						[Total] = ISNULL(ETD.LINE_TOTAL, 0),
						[CostAmount] = 0,
						[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
						[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
						[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
						[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
						[AdvanceBillFlagDetail] = ETD.AB_FLAG,
						[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
						[GlexActBill] = ETD.GLEXACT_BILL,
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
						[EstimateQuoteNumber] = 0,
						[EstimateRevisionNumber] = 0,
						[PurchaseOrderNumber] = 0,
						[OpenPurchaseOrderAmount] = 0,
						[OpenPurchaseOrderGrossAmount] = 0,
						[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
						[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[UnbilledAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
						[UnbilledAmountLessResale] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[UnbilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[UnbilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[IsNewBusiness] = C.NEW_BUSINESS,
						[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
						[BillingApprovalHours] = 0, 
						[BillingApprovalCostAmount] = 0,  
						[BillingApprovalExtNetAmount] = 0,  
						[BillingApprovalTotalAmount] = 0,
						[ProductUDF1] = P.USER_DEFINED1,
						[ProductUDF2] = P.USER_DEFINED2,
						[ProductUDF3] = P.USER_DEFINED3,
						[ProductUDF4] = P.USER_DEFINED4,
						[TransferAdjustmentUserCode] = ETD.XFER_ADJ_USER,
						ETD.EDIT_FLAG
					FROM 
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
						[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
						--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND
						--									 ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
						--										 ETDC.ET_SOURCE = 'D' INNER JOIN 
						[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ETD.JOB_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE INNER JOIN
						[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
													JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR LEFT OUTER JOIN
						[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
						[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
						[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
												 D.DIV_CODE = J.DIV_CODE INNER JOIN
						[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
												P.DIV_CODE = J.DIV_CODE AND
												P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
						[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
						[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
						[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
						[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
						[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
						[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
						[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
						[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
						[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
						[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
						(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
						[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
						[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
						[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
						[dbo].[ESTIMATE_LOG] AS EL ON EL.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER LEFT OUTER JOIN
						[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER AND
													EC.EST_COMPONENT_NBR = JC.EST_COMPONENT_NBR INNER JOIN dbo.advtf_user_job_limits(@USER_CODE) JL ON J.JOB_NUMBER = JL.JOB_NUMBER LEFT OUTER JOIN 
						(SELECT SEC_CLIENT.CL_CODE,
										SEC_CLIENT.DIV_CODE,
										SEC_CLIENT.PRD_CODE,
										SEC_CLIENT.[USER_ID],
										SEC_CLIENT.TIME_ENTRY 
								 FROM dbo.SEC_CLIENT WITH(NOLOCK)
								 WHERE SEC_CLIENT.[USER_ID] = @USER_CODE) AS SEC_CLIENT ON J.CL_CODE = SEC_CLIENT.CL_CODE AND
																						 J.DIV_CODE = SEC_CLIENT.DIV_CODE AND
																						 J.PRD_CODE = SEC_CLIENT.PRD_CODE
					WHERE 
						1 = CASE WHEN @RESTRICTIONS = 0 THEN 1 WHEN SEC_CLIENT.[USER_ID] = @USER_CODE AND (SEC_CLIENT.TIME_ENTRY IS NULL OR SEC_CLIENT.TIME_ENTRY = 0) THEN 1 ELSE 0 END AND
					    (ETD.EDIT_FLAG <> 1 OR ETD.EDIT_FLAG IS NULL) AND
						1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
						1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
						(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
						(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
						1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
						1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
						(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
						(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
						(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
						1 = CASE WHEN ET.EMP_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END

					
				
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
	ELSE
	BEGIN
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
						[ResourceType] = 'E',
						[JobNumber] = ETD.JOB_NUMBER,
						[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
						[OfficeCode] = J.OFFICE_CODE,
						[OfficeDescription] = O.OFFICE_NAME,
						[ClientCode] = J.CL_CODE,
						[ClientDescription] = C.CL_NAME,
						[DivisionCode] = J.DIV_CODE,
						[DivisionDescription] = D.DIV_NAME,
						[ProductCode] = J.PRD_CODE,
						[ProductDescription] = P.PRD_DESCRIPTION,
						[CampaignID] = CAMP.CMP_IDENTIFIER,
						[CampaignCode] = J.CMP_CODE, 
						[CampaignName] = CAMP.CMP_NAME,
						[SalesClassCode] = J.SC_CODE,
						[SalesClassDescription] = SC.SC_DESCRIPTION,
						[UserCode] = J.[USER_ID],
						[JobCreateDate] = J.CREATE_DATE,
						[JobDescription] = J.JOB_DESC,
						[JobDateOpened] = J.JOB_DATE_OPENED,
						[RushChargesApproved] = CASE WHEN J.JOB_RUSH_CHARGES = 1 THEN 'Yes' ELSE 'No' END,
						[ApprovedEstimateRequired] = CASE WHEN J.JOB_ESTIMATE_REQ = 1 THEN 'Yes' ELSE 'No' END,
						[Comment] = CAST(J.JOB_COMMENTS AS varchar(MAX)),
						[ClientReference] = J.JOB_CLI_REF,
						[BillingCoopCode] = J.BILL_COOP_CODE,
						[SalesClassFormatCode] = J.FORMAT_SC_CODE,
						[ComplexityCode] = J.COMPLEX_CODE,
						[PromotionCode] = J.PROMO_CODE,
						[BillingComment] = J.JOB_BILL_COMMENT,
						[LabelFromUDFTable1] = JUDV1.UDV_DESC,
						[LabelFromUDFTable2] = JUDV2.UDV_DESC,
						[LabelFromUDFTable3] = JUDV3.UDV_DESC,
						[LabelFromUDFTable4] = JUDV4.UDV_DESC,
						[LabelFromUDFTable5] = JUDV5.UDV_DESC,
						[JobOpen] = CASE WHEN J.COMP_OPEN = 0 THEN 'No' ELSE 'Yes' END,
						[ComponentNumber] = JC.JOB_COMPONENT_NBR,
						[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 2),
						[BillHold] = CASE WHEN JC.JOB_BILL_HOLD <> 0 AND JC.JOB_BILL_HOLD IS NOT NULL THEN 'Yes' ELSE 'No' END,
						[AccountExecutiveCode] = JC.EMP_CODE,
						[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
						[ComponentDateOpened] = JC.JOB_COMP_DATE,
						[DueDate] = JC.JOB_FIRST_USE_DATE,
						[StartDate] = JC.[START_DATE],
						[AdSize] = JC.JOB_AD_SIZE,
						[DepartmentTeamCode] = JC.DP_TM_CODE,
						[DepartmentTeam] = DT.DP_TM_DESC,
						[MarkupPercent] = JC.JOB_MARKUP_PCT,
						[CreativeInstructions] = CAST(JC.CREATIVE_INSTR AS varchar(MAX)),
						[JobProcessControl] = JPC.JOB_PROCESS_DESC,
						[ComponentDescription] = JC.JOB_COMP_DESC,
						[ComponentComments] = CAST(JC.JOB_COMP_COMMENTS AS varchar(MAX)),
						[ComponentBudget] = JC.JOB_COMP_BUDGET_AM,
						[EstimateNumber] = JC.ESTIMATE_NUMBER,
						[EstimateDescription] = EL.EST_LOG_DESC,
						[EstimateComponentNumber] = JC.EST_COMPONENT_NBR,
						[EstimateComponentDescription] = EC.EST_COMP_DESC,
						[BillingUser] = JC.BILLING_USER,
						[AdvanceBillFlag] = CASE WHEN JC.AB_FLAG = 1 THEN 'Advance Billed to Include Actual' WHEN JC.AB_FLAG = 2 THEN 'Advance Billed' ELSE NULL END,
						[DeliveryInstructions] = CAST(JC.JOB_DEL_INSTRUCT AS varchar(MAX)),
						[JobTypeCode] = JC.JT_CODE,
						[JobTypeDescription] = JT.JT_DESC,
						[Taxable] = CASE WHEN JC.TAX_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[TaxCode] = JC.TAX_CODE,
						[TaxCodeDescription] = ST.TAX_DESCRIPTION,
						[NonBillable] = JC.NOBILL_FLAG,
						[AlertGroup] = JC.EMAIL_GR_CODE,
						[AdNumber] = JC.AD_NBR,
						[AccountNumber] = JC.ACCT_NBR,
						[IncomeRecognitionMethod] = CASE WHEN JC.PRD_AB_INCOME = 1 THEN 'Upon Reconciliation' WHEN JC.PRD_AB_INCOME = 2 THEN 'Initial Billing' ELSE NULL END,
						[MarketCode] = JC.MARKET_CODE,
						[MarketDescription] = M.MARKET_DESC,
						[ServiceFeeJob] = CASE WHEN JC.SERVICE_FEE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[ServiceFeeTypeCode] = SFT.CODE,
						[ServiceFeeTypeDescription] = SFT.[DESCRIPTION],
						[Archived] = CASE WHEN JC.ARCHIVE_FLAG = 1 THEN 'Yes' ELSE 'No' END,
						[TrafficScheduleRequired] = CASE WHEN JC.TRF_SCHEDULE_REQ = 1 THEN 'Yes' ELSE 'No' END,
						[ClientPO] = JC.JOB_CL_PO_NBR,
						[CompLabelFromUDFTable1] = JCUDV1.UDV_DESC,
						[CompLabelFromUDFTable2] = JCUDV2.UDV_DESC,
						[CompLabelFromUDFTable3] = JCUDV3.UDV_DESC,
						[CompLabelFromUDFTable4] = JCUDV4.UDV_DESC,
						[CompLabelFromUDFTable5] = JCUDV5.UDV_DESC,
						[JobTemplateCode] = JC.JOB_TMPLT_CODE,
						[FiscalPeriodCode] = JC.FISCAL_PERIOD_CODE,
						[FiscalPeriodDescription] = FP.FISCAL_PERIOD_DESC,
						[JobQuantity] = JC.JOB_QTY,
						[BlackplateVersionCode] = JC.BLACKPLT_VER_CODE,
						[BlackplateVersionDesc] = JC.BLACKPLT_VER_DESC,
						[ClientContactCode] = JC.CDP_CONTACT_ID,
						[ClientContactID] = JC.PRD_CONT_CODE,
						[BABatchID] = JC.BA_BATCH_ID,
						[ClientContact] = CASE WHEN CC.CONT_MI IS NULL OR CC.CONT_MI = '' THEN CC.CONT_FNAME + ' ' + CC.CONT_LNAME ELSE CC.CONT_FNAME + ' ' + CC.CONT_MI + '. ' + CC.CONT_LNAME END,
						[SelectedBABatchID] = JC.SELECTED_BA_ID,
						[BillingCommandCenterID] = JC.BCC_ID,
						[AlertAssignmentTemplate] = AA.ALERT_NOTIFY_NAME,
						[FunctionType] = F.FNC_TYPE,
						[FunctionConsolidationCode] = F.FNC_CONSOLIDATION,
						[FunctionConsolidation] = CF.FNC_DESCRIPTION,
						[FunctionHeading] = FH.FNC_HEADING_DESC,
						[FunctionCode] = ETD.FNC_CODE,
						[FunctionDescription] = F.FNC_DESCRIPTION,
						[ItemID] = ETD.ET_ID,
						[ItemSequenceNumber] = ETD.ET_DTL_ID,
						[ItemLineNumber] = ETD.SEQ_NBR,
						[ItemDate] = CASE WHEN ET.EMP_DATE IS NOT NULL THEN ET.EMP_DATE ELSE NULL END,
						[PostPeriodCode] = CAST(NULL AS varchar(8)),
						[ItemCode] = ET.EMP_CODE,
						[ItemDescription] = COALESCE((RTRIM(ET_EMP.EMP_FNAME) + ' '),'') + COALESCE((ET_EMP.EMP_MI + '. '),'') + COALESCE(ET_EMP.EMP_LNAME,''),
						--[ItemComment] = CAST(ETDC.EMP_COMMENT AS varchar(MAX)),
						[ItemComment] = (SELECT TOP 1 CAST(ETDC.EMP_COMMENT AS varchar(MAX)) FROM [dbo].[EMP_TIME_DTL_CMTS] AS ETDC WHERE ETD.ET_ID = ETDC.ET_ID AND ETD.ET_DTL_ID = ETDC.ET_DTL_ID AND ETDC.ET_SOURCE = 'D' ORDER BY ETDC.SEQ_NBR DESC),
						[ItemExtra] = CAST(NULL AS varchar(20)),
						[FeeTime] = ISNULL(ETD.FEE_TIME, 0),
						[Hours] = CASE WHEN F.FNC_TYPE = 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[Quantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[BillableLessResale] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) END,
						[BillableTotal] = CASE WHEN ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE ISNULL(ETD.LINE_TOTAL, 0) END,
						[ExtMarkupAmount] = ISNULL(ETD.EXT_MARKUP_AMT, 0),
						[NonResaleTaxAmount] = 0,
						[ResaleTaxAmount] = ISNULL(ETD.EXT_STATE_RESALE, 0) + ISNULL(ETD.EXT_COUNTY_RESALE, 0) + ISNULL(ETD.EXT_CITY_RESALE, 0),
						[Total] = ISNULL(ETD.LINE_TOTAL, 0),
						[CostAmount] = 0,
						[NetAmount] = ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) - ISNULL(ETD.EXT_MARKUP_AMT, 0),
						[AccountsReceivablePostPeriodCode] = ISNULL(AR.AR_POST_PERIOD, ''),
						[AccountsReceivableInvoiceNumber] = ETD.AR_INV_NBR,
						[AccountsReceivableInvoiceType] = ETD.AR_TYPE,
						[AdvanceBillFlagDetail] = ETD.AB_FLAG,
						[IsNonBillable] = ISNULL(ETD.EMP_NON_BILL_FLAG, 0),
						[GlexActBill] = ETD.GLEXACT_BILL,
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
						[EstimateQuoteNumber] = 0,
						[EstimateRevisionNumber] = 0,
						[PurchaseOrderNumber] = 0,
						[OpenPurchaseOrderAmount] = 0,
						[OpenPurchaseOrderGrossAmount] = 0,
						[BilledAmount] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[BilledWithResale] = CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
						[BilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[BilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.AR_INV_NBR IS NOT NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[FeeTimeAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[FeeTimeHours] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME = 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END,
						[UnbilledAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) ELSE 0 END,
						[UnbilledAmountLessResale] = CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[UnbilledHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[UnbilledQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG <> 1 AND ETD.FEE_TIME <> 1 AND ETD.AR_INV_NBR IS NULL THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[NonBillableAmount] = CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.LINE_TOTAL, 0) - ISNULL(ETD.EXT_STATE_RESALE, 0) - ISNULL(ETD.EXT_COUNTY_RESALE, 0) - ISNULL(ETD.EXT_CITY_RESALE, 0) ELSE 0 END,
						[NonBillableHours] = CASE WHEN F.FNC_TYPE = 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[NonBillableQuantity] = CASE WHEN F.FNC_TYPE <> 'E' THEN CASE WHEN ETD.EMP_NON_BILL_FLAG = 1 AND ETD.FEE_TIME <> 1 THEN ISNULL(ETD.EMP_HOURS, 0) ELSE 0 END ELSE 0 END,
						[IsNewBusiness] = C.NEW_BUSINESS,
						[Agency] = CASE WHEN ACL.CL_CODE IS NOT NULL THEN 1 ELSE 0 END,
						[BillingApprovalHours] = 0, 
						[BillingApprovalCostAmount] = 0,  
						[BillingApprovalExtNetAmount] = 0,  
						[BillingApprovalTotalAmount] = 0,
						[ProductUDF1] = P.USER_DEFINED1,
						[ProductUDF2] = P.USER_DEFINED2,
						[ProductUDF3] = P.USER_DEFINED3,
						[ProductUDF4] = P.USER_DEFINED4,
						[TransferAdjustmentUserCode] = ETD.XFER_ADJ_USER,
						ETD.EDIT_FLAG
					FROM 
						[dbo].[EMP_TIME_DTL] AS ETD INNER JOIN 
						[dbo].[EMP_TIME] AS ET ON ET.ET_ID = ETD.ET_ID INNER JOIN 
						[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = ETD.FNC_CODE INNER JOIN 
						[dbo].[EMPLOYEE_CLOAK] AS ET_EMP ON ET_EMP.EMP_CODE = ET.EMP_CODE LEFT JOIN 
						--[dbo].[EMP_TIME_DTL_CMTS] AS ETDC ON ETDC.ET_ID = ETD.ET_ID AND
						--									 ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND 
						--										 ETDC.ET_SOURCE = 'D' INNER JOIN 
						[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = ETD.JOB_NUMBER LEFT OUTER JOIN
						(SELECT 
							DISTINCT 
							AR.AR_POST_PERIOD,
							AR.AR_INV_NBR, 
							AR.AR_TYPE
						FROM 
							[dbo].[ACCT_REC] AS AR) AS AR ON AR.AR_INV_NBR = ETD.AR_INV_NBR AND 
															 AR.AR_TYPE = ETD.AR_TYPE INNER JOIN
						[dbo].[JOB_COMPONENT] JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND
													JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR LEFT OUTER JOIN
						[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
						[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
						[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
												 D.DIV_CODE = J.DIV_CODE INNER JOIN
						[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
												P.DIV_CODE = J.DIV_CODE AND
												P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
						[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN
						[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
						[dbo].[JOB_TYPE] AS JT ON JT.JT_CODE = JC.JT_CODE LEFT OUTER JOIN
						[dbo].[DEPT_TEAM] AS DT ON DT.DP_TM_CODE = JC.DP_TM_CODE LEFT OUTER JOIN
						[dbo].[CDP_CONTACT_HDR] AS CC ON CC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID LEFT OUTER JOIN
						[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL LEFT OUTER JOIN
						[dbo].[SALES_TAX] AS ST ON ST.TAX_CODE = JC.TAX_CODE LEFT OUTER JOIN
						[dbo].[MARKET] AS M ON M.MARKET_CODE = JC.MARKET_CODE LEFT OUTER JOIN
						[dbo].[FISCAL_PERIOD] AS FP ON FP.FISCAL_PERIOD_CODE = JC.FISCAL_PERIOD_CODE LEFT OUTER JOIN
						[dbo].[ALERT_NOTIFY_HDR] AS AA ON AA.ALRT_NOTIFY_HDR_ID = JC.ALRT_NOTIFY_HDR_ID LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = J.UDV1_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = J.UDV2_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = J.UDV3_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = J.UDV4_CODE LEFT OUTER JOIN
						[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = J.UDV5_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
						[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN 
						[dbo].[CAMPAIGN] AS CAMP ON J.CMP_IDENTIFIER = CAMP.CMP_IDENTIFIER LEFT OUTER JOIN
						(SELECT CL_CODE FROM [dbo].[AGENCY_CLIENTS]) AS ACL ON ACL.CL_CODE = C.CL_CODE LEFT OUTER JOIN
						[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
						[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION LEFT OUTER JOIN 
						[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
						[dbo].[ESTIMATE_LOG] AS EL ON EL.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER LEFT OUTER JOIN
						[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER AND
													EC.EST_COMPONENT_NBR = JC.EST_COMPONENT_NBR INNER JOIN dbo.advtf_user_job_limits(@USER_CODE) JL ON J.JOB_NUMBER = JL.JOB_NUMBER
					WHERE (ETD.EDIT_FLAG <> 1 OR ETD.EDIT_FLAG IS NULL) AND
						1 = CASE WHEN @OPEN_JOB_ONLY = 1 AND (JC.JOB_PROCESS_CONTRL = 6 OR JC.JOB_PROCESS_CONTRL = 12) THEN 0 ELSE 1 END AND
						1 = CASE WHEN @EXCLUDE_NONBILL_HRS = 1 AND ISNULL(ETD.EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END AND
						(J.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@OFFICE_LIST, ',')) OR @OFFICE_LIST IS NULL) AND
						(J.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
						1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
						1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (J.CL_CODE + '|' + J.DIV_CODE + '|' + J.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END AND
						(J.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JOB_LIST, ',')) OR @JOB_LIST IS NULL) AND
						(JC.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@ACCT_EXEC_LIST, ',')) OR @ACCT_EXEC_LIST IS NULL) AND
						(J.SC_CODE IN (SELECT * FROM dbo.udf_split_list(@SALES_CLASS_LIST, ',')) OR @SALES_CLASS_LIST IS NULL) AND
						1 = CASE WHEN ET.EMP_DATE <= CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END

					
				
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

	

END

