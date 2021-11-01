if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_bcc_get_production_summary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_bcc_get_production_summary]
GO

CREATE PROC [advsp_bcc_get_production_summary] @BillingCommandCenterID int, @IncludeContingency bit, @SumByFunctionCode bit, @JobNumber int = NULL, @JobComponentNumber smallint = NULL, @debug bit = 0

AS

BEGIN

SET NOCOUNT ON;

IF @debug = 1
	SELECT GETDATE() 'START'

DECLARE @et_date_cutoff smalldatetime, 
		@io_date_cutoff smalldatetime,
		@ap_pp_cutoff varchar(6),
		@prod_lock_selection bit
		
SELECT @et_date_cutoff = P_ET_CUTOFF_DATE, @io_date_cutoff = P_IO_CUTOFF_DATE, @ap_pp_cutoff = P_AP_CUTOFF_PPD, @prod_lock_selection = PROD_LOCK_SELECTION
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @BillingCommandCenterID

DECLARE @JOBCOMPONENTS TABLE (
	JOB_NUMBER int NOT NULL,
	JOB_COMPONENT_NBR smallint NOT NULL,
	AMOUNT_SELECTED_FOR_BILLING decimal(18,2) NULL,
	HAS_BILLING_APPROVAL bit NOT NULL,
	SELECTED_BA_ID int NULL,
	RECONCILE_STATUS int NULL,
	MEDIA_BILL_DATE smalldatetime NULL
)

DECLARE @SUBTOTALS TABLE (
	[JobNumber] int NOT NULL,
	[ComponentNumber] smallint NOT NULL,
	[FunctionCode] varchar(6) NULL,
	[ActualBillableHours] decimal(15,2) NULL,
	[ActualBillableQuantity] decimal(15,2) NULL,
	[ActualBillableNetAmount] decimal(15,2) NULL,
	[ActualBillableMarkupAmount] decimal(15,2) NULL,
	[ActualBillableResaleTax] decimal(15,2) NULL,
	[ActualBillableTotal] decimal(15,2) NULL,
	[BilledHours] decimal(15,2) NULL,
	[BilledQuantity] decimal(15,2) NULL,
	[BilledNet] decimal(15,2) NULL,
	[BilledMarkup] decimal(15,2) NULL,
	[BilledResaleTax] decimal(15,2) NULL,
	[BilledTotal] decimal(15,2) NULL,
	[UnbilledHours] decimal(15,2) NULL,
	[UnbilledQuantity] decimal(15,2) NULL,
	[UnbilledNetAmount] decimal(15,2) NULL,
	[UnbilledMarkupAmount] decimal(15,2) NULL,
	[UnbilledResaleTax] decimal(15,2) NULL,
	[UnbilledTotal] decimal(15,2) NULL,
	[NonBillableHours] decimal(15,2) NULL,
	[NonBillableQuantity] decimal(15,2) NULL,
	[NonBillableNetAmount] decimal(15,2) NULL,
	[NonBillableMarkupAmount] decimal(15,2) NULL,
	[BillHoldAmount] decimal(15,2) NULL,
	[AdvanceHours] decimal(15,2) NULL,
	[AdvanceQuantity] decimal(15,2) NULL,
	[AdvanceBilledNetAmount] decimal(15,2) NULL,
	[AdvanceBilledMarkupAmount] decimal(15,2) NULL,
	[AdvanceBilledAmount] decimal(15,2) NULL,
	[AdvanceBilledResaleTax] decimal(15,2) NULL,
	[AdvanceBilledTotal] decimal(15,2) NULL,
	[UnbilledAdvanceAmount] decimal(15,2) NULL,
	[UnbilledAdvanceResaleTax] decimal(15,2) NULL,
	[UnbilledAdvanceTotal] decimal(15,2) NULL,
	[FlatIncomeRecognized] decimal(15,2) NULL,
	[FeeAmount] decimal(15,2) NULL,
	[FeeResaleTax] decimal(15,2) NULL,
	[FeeTotal] decimal(15,2) NULL,
	[FeeHours] decimal(9,2) NULL,
	[DetailBillHold] smallint NULL,
	[FlatIncomeToRecognize] decimal(15,2) NULL,
	[AmountToBill] decimal(15,2) NULL,
	[UnbilledNetOnly] decimal(15,2) NULL,
	[GrossIncome] decimal(15,2) NULL,
	[AdvanceBillingRetained] decimal(15,2) NULL
)

DECLARE @RESULTS TABLE(
	[OfficeCode] varchar(4) NOT NULL,
	[OfficeDescription] varchar(30) NULL,
	[CampaignID] int NULL,
	[CampaignCode] varchar(6) NULL,
	[CampaignDescription] varchar(128) NULL,
	[ClientCode] varchar(6) NOT NULL,
	[ClientName] varchar(40) NULL,
	[DivisionCode] varchar(6) NULL,
	[DivisionName] varchar(40) NULL,
	[ProductCode] varchar(6) NULL,
	[ProductDescription] varchar(40) NULL,
	[JobNumber] int NOT NULL,
	[JobDescription] varchar(60) NULL,
	[ComponentNumber] smallint NOT NULL,
	[ComponentDescription] varchar(60) NULL,
	[SalesClassCode] varchar(6) NULL,
	[SalesClassDescription] varchar(30) NULL,
	[ClientPO] varchar(40) NULL,
	[ClientReference] varchar(30) NULL,
	[BillingCoopCode] varchar(6) NULL,
	[ScheduleStatus] varchar(30) NULL,
	[ScheduleCompletedDate] smalldatetime NULL,
	[EstimateNumberComponentQuoteRevision] varchar(25) NULL,
	[EstimateApprovedDate] smalldatetime NULL,
	[EstimateHours] decimal(15,2) NULL,
	[EstimateQuantity] decimal(15,2) NULL,
	[EstimateNetAmount] decimal(15,2) NULL,
	[EstimateMarkupAmount] decimal(15,2) NULL,
	[EstimateAmount] decimal(15,2) NULL,
	[EstimateResaleTax] decimal(15,2) NULL,
	[EstimateTotal] decimal(15,2) NULL,
	[BillingApprovalHeaderComment] varchar(max) NULL,
	[BillingApprovalHeaderClientComment] varchar(max) NULL,
	[AdvanceBillRequested] bit NOT NULL,
	[JobBillHoldRequested] bit NOT NULL,
	[ProcessControl] smallint NULL,
	[AmountSelectedforBilling] decimal(18,2) NOT NULL,
	[BillingUser] varchar(100) NULL,
	[ProcessControlDescription] varchar(40) NULL,
	[JobBillHold] smallint NULL,
	[ABFlag] smallint NULL,
	[IsCloseable] bit NOT NULL,
	[IsAdjusted] bit NOT NULL,
	[JobBillComment] varchar(254) NULL,
	[BillingApprovalHeaderID] int NULL,
	[CampaignComment] varchar(max) NULL,
	[JobComment] varchar(max) NULL,
	[JobComponentComment] varchar(max) NULL,
	[AccountExecutive] varchar(61) NULL,
	[JobTypeDescription] varchar(30)
)

DECLARE @FUNCTIONRESULTS TABLE (
	[OfficeCode] varchar(4) NOT NULL,
	[OfficeDescription] varchar(30) NULL,
	[CampaignID] int NULL,
	[CampaignCode] varchar(6) NULL,
	[CampaignDescription] varchar(128) NULL,
	[ClientCode] varchar(6) NOT NULL,
	[ClientName] varchar(40) NULL,
	[DivisionCode] varchar(6) NULL,
	[DivisionName] varchar(40) NULL,
	[ProductCode] varchar(6) NULL,
	[ProductDescription] varchar(40) NULL,
	[JobNumber] int NOT NULL,
	[JobDescription] varchar(60) NULL,
	[ComponentNumber] smallint NOT NULL,
	[ComponentDescription] varchar(60) NULL,
	[SalesClassCode] varchar(6) NULL,
	[SalesClassDescription] varchar(30) NULL,
	[ClientPO] varchar(40) NULL,
	[ClientReference] varchar(30) NULL,
	[BillingCoopCode] varchar(6) NULL,
	[ScheduleStatus] varchar(30) NULL,
	[ScheduleCompletedDate] smalldatetime NULL,
	[EstimateNumberComponentQuoteRevision] varchar(25) NULL,
	[EstimateApprovedDate] smalldatetime NULL,
	[FunctionHeading] varchar(60) NULL,
	[FunctionCode] varchar(6) NULL,
	[FunctionDescription] varchar(30) NULL,
	[EstimateHours] decimal(15,2) NULL,
	[EstimateQuantity] decimal(15,2) NULL,
	[EstimateNetAmount] decimal(15,2) NULL,
	[EstimateMarkupAmount] decimal(15,2) NULL,
	[EstimateAmount] decimal(15,2) NULL,
	[EstimateResaleTax] decimal(15,2) NULL,
	[EstimateTotal] decimal(15,2) NULL,
	[BillingApprovalHeaderComment] varchar(max) NULL,
	[BillingApprovalHeaderClientComment] varchar(max) NULL,
	[AdvanceBillRequested] bit NOT NULL,
	[JobBillHoldRequested] bit NOT NULL,
	[ProcessControl] smallint NULL,
	[AmountSelectedforBilling] decimal(18,2) NOT NULL,
	[BillingUser] varchar(100) NULL,
	[ProcessControlDescription] varchar(40) NULL,
	[JobBillHold] smallint NULL,
	[ABFlag] smallint NULL,
	[IsCloseable] bit NOT NULL,
	[FunctionType] varchar(1) NULL,
	[FunctionOrder] smallint NULL,
	[FunctionConsolidationCode] varchar(6) NULL,
	[FunctionConsolidationDescription] varchar(30) NULL,
	[IsAdjusted] bit NOT NULL,
	[JobBillComment] varchar(254) NULL,
	[BillingApprovalHeaderID] int NULL,
	[CampaignComment] varchar(max) NULL,
	[JobComment] varchar(max) NULL,
	[JobComponentComment] varchar(max) NULL,
	[JobTypeDescription] varchar(30)
)

DECLARE @JOBCOMPONENTFUNCTIONS TABLE (
	JobNumber int NOT NULL,
	ComponentNumber smallint NOT NULL,
	FunctionCode varchar(6) NOT NULL
)

IF @debug = 1
	SELECT GETDATE() 'BEFORE @JOBCOMPONENTS'

INSERT INTO @JOBCOMPONENTS (JOB_NUMBER, JOB_COMPONENT_NBR, AMOUNT_SELECTED_FOR_BILLING, HAS_BILLING_APPROVAL, SELECTED_BA_ID, RECONCILE_STATUS, MEDIA_BILL_DATE)
SELECT JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, dbo.advfn_get_prod_sel_amt(JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR),
	CASE WHEN BAH.BA_ID IS NOT NULL THEN 1 ELSE 0 END, CASE WHEN BAH.BA_ID IS NOT NULL THEN JC.SELECTED_BA_ID ELSE NULL END,
	dbo.advfn_adv_bill_reconcile_status ( JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR), JC.MEDIA_BILL_DATE
FROM dbo.JOB_COMPONENT JC 
	LEFT OUTER JOIN dbo.BILL_APPR_HDR BAH ON JC.JOB_NUMBER = BAH.JOB_NUMBER and JC.JOB_COMPONENT_NBR = BAH.JOB_COMPONENT_NBR AND JC.SELECTED_BA_ID = BAH.BA_ID 
WHERE	JC.BCC_ID = @BillingCommandCenterID
AND		(@JobNumber IS NULL OR JC.JOB_NUMBER = @JobNumber)
AND		(@JobComponentNumber IS NULL OR JC.JOB_COMPONENT_NBR = @JobComponentNumber)

IF @debug = 1
	SELECT GETDATE() 'AFTER @JOBCOMPONENTS'

INSERT @SUBTOTALS (JobNumber, ComponentNumber, FunctionCode, FlatIncomeRecognized)
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, SUM(REC_AMT)
FROM dbo.INCOME_REC IR
WHERE IR.AR_INV_NBR IS NOT NULL
AND EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = IR.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = IR.JOB_COMPONENT_NBR) 
GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE

IF @debug = 1
	SELECT GETDATE() 'AFTER INCOME_REC1'

INSERT @SUBTOTALS (JobNumber, ComponentNumber, FunctionCode, FlatIncomeToRecognize)
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, SUM(REC_AMT)
FROM dbo.INCOME_REC IR
WHERE IR.AR_INV_NBR IS NULL
AND EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = IR.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = IR.JOB_COMPONENT_NBR) 
GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE

IF @debug = 1
	SELECT GETDATE() 'AFTER INCOME_REC2'

INSERT @SUBTOTALS
SELECT
	[JobNumber] = AP.JOB_NUMBER,
	[JobComponentNumber] = AP.JOB_COMPONENT_NBR,
	[FunctionCode] = AP.FNC_CODE,
	[ActualBillableHours] = 0,
	[ActualBillableQuantity] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(AP_PROD_QUANTITY, 0) ELSE 0 END,
	[ActualBillableNetAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[ActualBillableMarkupAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ActualBillableResaleTax] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[ActualBillableTotal] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[BilledHours] = 0,
	[BilledQuantity] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(AP_PROD_QUANTITY, 0) ELSE 0 END,
	[BilledNetAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[BilledMarkupAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BilledResaleTax] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[BilledTotal] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[UnbilledHours] = 0,
	[UnbilledQuantity] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(AP_PROD_QUANTITY, 0) ELSE 0 END,
	[UnbilledNetAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledMarkupAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledResaleTax] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[UnbilledTotal] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[NonBillableHours] = 0,
	[NonBillableQuantity] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 1 THEN COALESCE(AP_PROD_QUANTITY, 0) ELSE 0 END,
	[NonBillableNetAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 1 THEN COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[NonBillableMarkupAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 1 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BillHoldAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND (AP_PROD_BILL_HOLD = 1 OR AP_PROD_BILL_HOLD = 2) AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[AdvanceHours] = 0,
	[AdvanceQuantity] = 0,
	[AdvanceBilledNetAmount] = 0,
	[AdvanceBilledMarkupAmount] = 0,
	[AdvanceBilledAmount] = 0,
	[AdvanceBilledResaleTax] = 0,
	[AdvanceBilledTotal] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[FeeHours] = 0,
	[DetailBillHold] = COALESCE(AP_PROD_BILL_HOLD, 0),
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN 
						COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledNetOnly] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(AP_PROD_EXT_AMT, 0) ELSE 0 END,
	[GrossIncome] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[AdvanceBillingRetained] = 0
FROM dbo.AP_PRODUCTION AP
WHERE	AP.POST_PERIOD <= @ap_pp_cutoff
AND		((@prod_lock_selection = 1 AND AP.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = AP.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = AP.JOB_COMPONENT_NBR) 

IF @debug = 1
	SELECT GETDATE() 'AFTER AP @SUBTOTALS'

INSERT @SUBTOTALS 
SELECT
	[JobNumber],
	[JobComponentNumber],
	[FunctionCode],
	SUM([ActualBillableHours]),
	SUM([ActualBillableQuantity]),
	SUM([ActualBillableNetAmount]),
	SUM([ActualBillableMarkupAmount]),
	SUM([ActualBillableResaleTax]),
	SUM([ActualBillableTotal]),
	SUM([BilledHours]),
	SUM([BilledQuantity]),
	SUM([BilledNetAmount]),
	SUM([BilledMarkupAmount]),
	SUM([BilledResaleTax]),
	SUM([BilledTotal]),
	SUM([UnbilledHours]),
	SUM([UnbilledQuantity]),
	SUM([UnbilledNetAmount]),
	SUM([UnbilledMarkupAmount]),
	SUM([UnbilledResaleTax]),
	SUM([UnbilledTotal]),
	SUM([NonBillableHours]),
	SUM([NonBillableQuantity]),
	SUM([NonBillableNetAmount]),
	SUM([NonBillableMarkupAmount]),
	SUM([BillHoldAmount]),
	[AdvanceHours] = 0,
	[AdvanceQuantity] = 0,
	[AdvanceBilledNetAmount] = 0,
	[AdvanceBilledMarkupAmount] = 0,
	[AdvanceBilledAmount] = 0,
	[AdvanceBilledResaleTax] = 0,
	[AdvanceBilledTotal] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	SUM([FeeAmount]),
	SUM([FeeResaleTax]),
	SUM([FeeTotal]),
	SUM([FeeHours]),
	SUM([DetailBillHold]),
	[FlatIncomeToRecognize] = 0,
	SUM([AmountToBill]),
	SUM([UnbilledNetOnly]),
	COALESCE(SUM([ActualBillableNetAmount]), 0) + COALESCE(SUM([ActualBillableMarkupAmount]), 0),
	[AdvanceBillingRetained] = 0
FROM (
	SELECT
		[JobNumber] = ETD.JOB_NUMBER,
		[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
		[FunctionCode] = ETD.FNC_CODE,
		[ActualBillableHours] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
		[ActualBillableQuantity] = 0,
		[ActualBillableNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
		[ActualBillableMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[ActualBillableResaleTax] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
		[ActualBillableTotal] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[BilledHours] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
		[BilledQuantity] = 0,
		[BilledNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
		[BilledMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[BilledResaleTax] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
		[BilledTotal] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[UnbilledHours] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
		[UnbilledQuantity] = 0,
		[UnbilledNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
		[UnbilledMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[UnbilledResaleTax] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
		[UnbilledTotal] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[NonBillableHours] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) <> 1 THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
		[NonBillableQuantity] = 0,
		[NonBillableNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) <> 1 THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
		[NonBillableMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) <> 1 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[BillHoldAmount] = CASE WHEN (BILL_HOLD_FLG = 1 OR BILL_HOLD_FLG = 2) AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[FeeAmount] = CASE WHEN FEE_TIME = 1 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(TOTAL_BILL, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[FeeResaleTax] = CASE WHEN FEE_TIME = 1 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
		[FeeTotal] = CASE WHEN FEE_TIME = 1 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
		[FeeHours] = CASE WHEN FEE_TIME = 1 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
		[DetailBillHold] = COALESCE(BILL_HOLD_FLG, 0),
		[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN 
							COALESCE(TOTAL_BILL, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
		[UnbilledNetOnly] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END
	FROM dbo.EMP_TIME_DTL ETD
		INNER JOIN dbo.EMP_TIME ET ON ET.ET_ID = ETD.ET_ID 
	WHERE	ET.EMP_DATE <= @et_date_cutoff
	AND		((@prod_lock_selection = 1 AND ETD.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
	AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = ETD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR)) TableA
GROUP BY	[JobNumber],
			[JobComponentNumber],
			[FunctionCode]

IF @debug = 1
	SELECT GETDATE() 'AFTER ET @SUBTOTALS'

INSERT @SUBTOTALS
SELECT
	[JobNumber] = IOnly.JOB_NUMBER,
	[JobComponentNumber] = IOnly.JOB_COMPONENT_NBR,
	[FunctionCode] = IOnly.FNC_CODE,
	[ActualBillableHours] = 0,
	[ActualBillableQuantity] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(IO_QTY, 0) ELSE 0 END,
	[ActualBillableNetAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(IO_AMOUNT, 0) ELSE 0 END,
	[ActualBillableMarkupAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ActualBillableResaleTax] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[ActualBillableTotal] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[BilledHours] = 0,
	[BilledQuantity] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(IO_QTY, 0) ELSE 0 END,
	[BilledNetAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN (COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) - COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BilledMarkupAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BilledResaleTax] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[BilledTotal] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[UnbilledHours] = 0,
	[UnbilledQuantity] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(IO_QTY, 0) ELSE 0 END,
	[UnbilledNetAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN (COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) - COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledMarkupAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledResaleTax] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[UnbilledTotal] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[NonBillableHours] = 0,
	[NonBillableQuantity] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 1 THEN COALESCE(IO_QTY, 0) ELSE 0 END,
	[NonBillableNetAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 1 THEN (COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) - COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[NonBillableMarkupAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 1 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BillHoldAmount] = CASE WHEN (BILL_HOLD_FLAG = 1 OR BILL_HOLD_FLAG = 2) AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[AdvanceHours] = 0,
	[AdvanceQuantity] = 0,
	[AdvanceBilledNetAmount] = 0,
	[AdvanceBilledMarkupAmount] = 0,
	[AdvanceBilledAmount] = 0,
	[AdvanceBilledResaleTax] = 0,
	[AdvanceBilledTotal] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[FeeHours] = 0,
	[DetailBillHold] = COALESCE(BILL_HOLD_FLAG, 0),
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN 
						(COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) ELSE 0 END,
	[UnbilledNetOnly] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN (COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) - COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[GrossIncome] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(IO_AMOUNT, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[AdvanceBillingRetained] = 0
FROM dbo.INCOME_ONLY IOnly
WHERE	IO_INV_DATE <= @io_date_cutoff
AND		((@prod_lock_selection = 1 AND IOnly.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = IOnly.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = IOnly.JOB_COMPONENT_NBR)

IF @debug = 1
	SELECT GETDATE() 'AFTER IO @SUBTOTALS'

INSERT @SUBTOTALS
SELECT
	[JobNumber] = JOB_NUMBER,
	[JobComponentNumber] = JOB_COMPONENT_NBR,
	[FunctionCode] = FNC_CODE,
	[ActualBillableHours] = 0,
	[ActualBillableQuantity] = 0,
	[ActualBillableNetAmount] = 0,
	[ActualBillableMarkupAmount] = 0,
	[ActualBillableResaleTax] = 0,
	[ActualBillableTotal] = 0,
	[BilledHours] = 0,
	[BilledQuantity] = 0,
	[BilledNetAmount] = 0,
	[BilledMarkupAmount] = 0,
	[BilledResaleTax] = 0,
	[BilledTotal] = 0,
	[UnbilledHours] = 0,
	[UnbilledQuantity] = 0,
	[UnbilledNetAmount] = 0,
	[UnbilledMarkupAmount] = 0,
	[UnbilledResaleTax] = 0,
	[UnbilledTotal] = 0,
	[NonBillableHours] = 0,
	[NonBillableQuantity] = 0,
	[NonBillableNetAmount] = 0,
	[NonBillableMarkupAmount] = 0,
	[BillHoldAmount] = 0,
	[AdvanceHours] = 0,
	[AdvanceQuantity] = 0,
	[AdvanceBilledNetAmount] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[AdvanceBilledMarkupAmount] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[AdvanceBilledAmount] = CASE WHEN AR_INV_NBR IS NOT NULL AND AB_FLAG <> 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[AdvanceBilledResaleTax] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[AdvanceBilledTotal] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[UnbilledAdvanceAmount] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledAdvanceResaleTax] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[UnbilledAdvanceTotal] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[FlatIncomeRecognized] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[FeeHours] = 0,
	[DetailBillHold] = 0,
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledNetOnly] = 0,
	[GrossIncome] = 0,
	[AdvanceBillingRetained] = CASE WHEN AR_INV_NBR IS NOT NULL AND AB_FLAG = 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END
FROM dbo.ADVANCE_BILLING AB
WHERE		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = AB.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR)

IF @debug = 1
BEGIN
	SELECT GETDATE() 'AFTER AB @SUBTOTALS'
	--SELECT * INTO ##SUBTOTALS FROM @SUBTOTALS
END

IF @SumByFunctionCode = 1
BEGIN
	INSERT @JOBCOMPONENTFUNCTIONS
	SELECT DISTINCT JobNumber,
					ComponentNumber, 
					FunctionCode 
	FROM @SUBTOTALS
	WHERE FunctionCode IS NOT NULL
	UNION
	SELECT  [JobNumber] = POD.JOB_NUMBER,
			[ComponentNumber] = POD.JOB_COMPONENT_NBR,
			[FunctionCode] = FNC_CODE
	FROM dbo.PURCHASE_ORDER_DET POD
		INNER JOIN dbo.PURCHASE_ORDER PO ON POD.PO_NUMBER = PO.PO_NUMBER
		LEFT OUTER JOIN (
						SELECT AP_PROD_EXT_AMT = SUM(COALESCE(AP_PROD_EXT_AMT, 0)),
								JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
						FROM dbo.AP_PRODUCTION
						WHERE ((@prod_lock_selection = 1 AND BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
						GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
						) Prod ON POD.JOB_NUMBER = Prod.JOB_NUMBER AND POD.JOB_COMPONENT_NBR = Prod.JOB_COMPONENT_NBR AND POD.PO_NUMBER = Prod.PO_NUMBER AND POD.LINE_NUMBER = Prod.PO_LINE_NUMBER  
	WHERE
			FNC_CODE IS NOT NULL
	AND		POD.JOB_NUMBER IS NOT NULL
	AND		POD.JOB_COMPONENT_NBR IS NOT NULL
	AND		(POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0)
	AND		(VOID_FLAG IS NULL OR VOID_FLAG = 0) 
	AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = POD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = POD.JOB_COMPONENT_NBR)
	UNION
	SELECT	[JobNumber] = EA.JOB_NUMBER, 
			[ComponentNumber] = EA.JOB_COMPONENT_NBR, 
			[FunctionCode] = ERT.FNC_CODE
	FROM dbo.ESTIMATE_APPROVAL EA
		INNER JOIN dbo.ESTIMATE_REV_DET ERT ON EA.ESTIMATE_NUMBER = ERT.ESTIMATE_NUMBER AND EA.EST_COMPONENT_NBR = ERT.EST_COMPONENT_NBR 
											AND EA.EST_QUOTE_NBR = ERT.EST_QUOTE_NBR AND EA.EST_REVISION_NBR = ERT.EST_REV_NBR AND ERT.FNC_CODE IS NOT NULL
	WHERE EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = EA.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR)
	UNION
	SELECT	[JobNumber] = BAD.JOB_NUMBER,
			[ComponentNumber] = BAD.JOB_COMPONENT_NBR,
			[FunctionCode] = BAD.FNC_CODE
	FROM dbo.BILL_APPR_DTL BAD
		INNER JOIN @JOBCOMPONENTS JC ON BAD.BA_ID = JC.SELECTED_BA_ID AND BAD.JOB_NUMBER = JC.JOB_NUMBER AND BAD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 

	IF @debug = 1
		SELECT GETDATE() 'AFTER @JOBCOMPONENTFUNCTIONS'
END

IF @SumByFunctionCode = 0
BEGIN
	INSERT INTO @RESULTS 
	SELECT
		[OfficeCode] = JL.OFFICE_CODE,
		[OfficeDescription] = O.OFFICE_NAME,
		[CampaignID] = CMP.CMP_IDENTIFIER,
		[CampaignCode] = CMP.CMP_CODE,
		[CampaignDescription] = CMP.CMP_NAME,
		[ClientCode] = JL.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = JL.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = JL.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[JobNumber] = JL.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[SalesClassCode] = JL.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[ClientPO] = JC.JOB_CL_PO_NBR,
		[ClientReference] = JL.JOB_CLI_REF,
		[BillingCoopCode] = JL.BILL_COOP_CODE,
		[ScheduleStatus] = T.TRF_DESCRIPTION,
		[ScheduleCompletedDate] = JT.COMPLETED_DATE,
		[EstimateNumberComponentQuoteRevision] = RIGHT('000000' + CAST(EA.ESTIMATE_NUMBER AS VARCHAR(15)), 6) + '-' + 
												 RIGHT('00' + CAST(EA.EST_COMPONENT_NBR AS VARCHAR(10)), 2) + '-' + 
												 RIGHT('00' + CAST(EA.EST_QUOTE_NBR AS VARCHAR(10)), 2) + '- REV ' + 
												 RIGHT('00' + CAST(EA.EST_REVISION_NBR AS VARCHAR(10)), 2),
		[EstimateApprovedDate] = EA.EST_APPR_DATE,
		[EstimateHours] = est.EstimateHours,
		[EstimateQuantity] = est.EstimateQuantity,
		[EstimateNetAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateNetAmount, 0) + COALESCE(est.ContingencyNet, 0) ELSE COALESCE(est.EstimateNetAmount, 0) END,
		[EstimateMarkupAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateMarkupAmount, 0) + COALESCE(est.ContingencyMarkup, 0) ELSE COALESCE(est.EstimateMarkupAmount, 0) END,
		[EstimateAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateAmount, 0) + COALESCE(est.ContingencyAmount, 0) ELSE COALESCE(est.EstimateAmount, 0) END,
		[EstimateResaleTax] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateResaleTax, 0) + COALESCE(est.ContingencyResale, 0) ELSE COALESCE(est.EstimateResaleTax,0) END,
		[EstimateTotal] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateTotal, 0) + COALESCE(est.ContingencyTotal, 0) ELSE COALESCE(est.EstimateTotal, 0) END,
		[BillingApprovalHeaderComment] = BAH.APPR_COMMENTS,
		[BillingApprovalHeaderClientComment] = BAH.CLIENT_COMMENTS,
		[AdvanceBillRequested] = CASE WHEN (COALESCE(BAH.BILL_TYPE,0) = 2 OR COALESCE(BAH.BILL_TYPE,0) = 3) AND COALESCE(JC.AB_FLAG, 0) = 0 THEN 1
									  ELSE 0 END,
		[JobBillHoldRequested] = CASE WHEN COALESCE(BAH.BILL_TYPE,0) = 1 THEN 1
									  WHEN BAH.BA_ID IS NOT NULL AND COALESCE(BAH.BILL_TYPE,0) = 0 AND COALESCE(JC.JOB_BILL_HOLD, 0) > 1 THEN 0
									  ELSE 0 END,
		[ProcessControl] = JC.JOB_PROCESS_CONTRL,
		[AmountSelectedforBilling] = JOBS.AMOUNT_SELECTED_FOR_BILLING,
		[BillingUser] = SUBSTRING(JC.BILLING_USER, 1, LEN(JC.BILLING_USER) - 2),
		[ProcessControlDescription] = JPC.JOB_PROCESS_DESC,
		[JobBillHold] = JC.JOB_BILL_HOLD,
		[ABFlag] = JC.AB_FLAG,
		[IsCloseable] = ( SELECT dbo.advfn_bcc_is_job_closeable(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR)),
		[IsAdjusted] = CASE WHEN NULLIF(JC.ADJUST_USER,'') IS NOT NULL THEN 1 ELSE 0 END,
		[JobBillComment] = JL.JOB_BILL_COMMENT,
		[BillingApprovalHeaderID] = BAH.BA_HDR_ID,
		[CampaignComment] = CMP.CMP_COMMENTS,
		[JobComment] = JL.JOB_COMMENTS,
		[JobComponentComment] = JC.JOB_COMP_COMMENTS,
		[AccountExecutive] = [dbo].[advfn_get_emp_name] ( AE.EMP_CODE, 'FML' ),
		[JobTypeDescription] = JTYPE.JT_DESC
FROM	dbo.JOB_LOG JL
	INNER JOIN dbo.JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER
	INNER JOIN @JOBCOMPONENTS JOBS ON JOBS.JOB_NUMBER = JC.JOB_NUMBER AND JOBS.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
	INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON JC.JOB_PROCESS_CONTRL = JPC.JOB_PROCESS_CONTRL 
	LEFT OUTER JOIN dbo.ESTIMATE_APPROVAL EA ON JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR AND JC.JOB_NUMBER = EA.JOB_NUMBER
	LEFT OUTER JOIN dbo.JOB_TRAFFIC JT ON JC.JOB_NUMBER = JT.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
	LEFT OUTER JOIN dbo.TRAFFIC T ON JT.TRF_CODE = T.TRF_CODE
	LEFT OUTER JOIN dbo.CAMPAIGN CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
	INNER JOIN dbo.OFFICE O ON JL.OFFICE_CODE = O.OFFICE_CODE 
	INNER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE 
	INNER JOIN dbo.DIVISION D ON JL.CL_CODE = D.CL_CODE AND JL.DIV_CODE = D.DIV_CODE 
	INNER JOIN dbo.PRODUCT P ON JL.CL_CODE = P.CL_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.PRD_CODE = P.PRD_CODE 
	LEFT OUTER JOIN dbo.SALES_CLASS SC ON JL.SC_CODE = SC.SC_CODE
	LEFT OUTER JOIN (SELECT
						[JobNumber],
						[JobComponentNumber],
						[EstimateHours] = SUM([EstimateHours]),
						[EstimateQuantity] = SUM([EstimateQuantity]),
						[EstimateNetAmount] = SUM([EstimateNetAmount]),
						[EstimateMarkupAmount] = SUM([EstimateMarkupAmount]),
						[EstimateAmount] = SUM([EstimateAmount]),
						[EstimateResaleTax] = SUM([EstimateResaleTax]),
						[EstimateTotal] = SUM([EstimateTotal]),
						[ContingencyNet] = SUM([ContingencyNet]),
						[ContingencyMarkup] = SUM([ContingencyMarkup]),
						[ContingencyAmount] = SUM([ContingencyAmount]),
						[ContingencyResale] = SUM([ContingencyResale]),
						[ContingencyTotal] = SUM([ContingencyTotal])
					FROM (
							SELECT
								[JobNumber] = EA.JOB_NUMBER,
								[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
								[EstimateHours] = CASE WHEN ERT.EST_FNC_TYPE = 'E' THEN COALESCE(ERT.EST_REV_QUANTITY,0) ELSE 0 END,
								[EstimateQuantity] = CASE WHEN ERT.EST_FNC_TYPE <> 'E' THEN COALESCE(ERT.EST_REV_QUANTITY,0) ELSE 0 END,
								[EstimateNetAmount] = COALESCE(ERT.EST_REV_EXT_AMT,0) + COALESCE(ERT.EXT_NONRESALE_TAX,0),
								[EstimateMarkupAmount] = COALESCE(ERT.EXT_MARKUP_AMT,0),
								[EstimateAmount] = COALESCE(ERT.EST_REV_EXT_AMT,0) + COALESCE(ERT.EXT_NONRESALE_TAX,0) + COALESCE(ERT.EXT_MARKUP_AMT,0),
								[EstimateResaleTax] = COALESCE(ERT.EXT_STATE_RESALE, 0) + COALESCE(ERT.EXT_COUNTY_RESALE, 0) + COALESCE(ERT.EXT_CITY_RESALE, 0),
								[EstimateTotal] = COALESCE(ERT.LINE_TOTAL, 0),
								[ContingencyNet] = COALESCE(ERT.EXT_CONTINGENCY, 0) + COALESCE(ERT.EXT_NR_CONT, 0),
								[ContingencyMarkup] = COALESCE(ERT.EXT_MU_CONT, 0),
								[ContingencyAmount] = COALESCE(ERT.EXT_CONTINGENCY, 0) + COALESCE(ERT.EXT_NR_CONT, 0) + COALESCE(ERT.EXT_MU_CONT, 0),
								[ContingencyResale] = COALESCE(ERT.EXT_STATE_CONT, 0) + COALESCE(ERT.EXT_COUNTY_CONT, 0) + COALESCE(ERT.EXT_CITY_CONT, 0),
								[ContingencyTotal] = COALESCE(ERT.LINE_TOTAL_CONT, 0)
							FROM dbo.ESTIMATE_APPROVAL EA
								INNER JOIN dbo.ESTIMATE_REV_DET ERT ON EA.ESTIMATE_NUMBER = ERT.ESTIMATE_NUMBER AND EA.EST_COMPONENT_NBR = ERT.EST_COMPONENT_NBR 
																	AND EA.EST_QUOTE_NBR = ERT.EST_QUOTE_NBR AND EA.EST_REVISION_NBR = ERT.EST_REV_NBR
							WHERE EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = EA.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR)) estdetails
					GROUP BY
						[JobNumber],
						[JobComponentNumber]) est ON est.JobNumber = JC.JOB_NUMBER AND est.JobComponentNumber = JC.JOB_COMPONENT_NBR 
	LEFT OUTER JOIN dbo.BILL_APPR_HDR BAH ON BAH.BA_ID = JC.SELECTED_BA_ID AND BAH.JOB_NUMBER = JC.JOB_NUMBER AND BAH.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
	LEFT OUTER JOIN dbo.ACCOUNT_EXECUTIVE AE ON JL.CL_CODE = AE.CL_CODE AND JL.DIV_CODE = AE.DIV_CODE AND JL.PRD_CODE = AE.PRD_CODE AND JC.EMP_CODE = AE.EMP_CODE AND COALESCE(AE.INACTIVE_FLAG, 0) = 0
	LEFT OUTER JOIN dbo.JOB_TYPE JTYPE ON JTYPE.JT_CODE = JC.JT_CODE
	IF @debug = 1
		SELECT GETDATE() 'AFTER @RESULTS'

END
ELSE
BEGIN
	INSERT INTO @FUNCTIONRESULTS 
	SELECT
			[OfficeCode] = JL.OFFICE_CODE,
			[OfficeDescription] = O.OFFICE_NAME,
			[CampaignID] = CMP.CMP_IDENTIFIER,
			[CampaignCode] = CMP.CMP_CODE,
			[CampaignDescription] = CMP.CMP_NAME,
			[ClientCode] = JL.CL_CODE,
			[ClientName] = C.CL_NAME,
			[DivisionCode] = JL.DIV_CODE,
			[DivisionName] = D.DIV_NAME,
			[ProductCode] = JL.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[JobNumber] = JL.JOB_NUMBER,
			[JobDescription] = JL.JOB_DESC,
			[ComponentNumber] = JC.JOB_COMPONENT_NBR,
			[ComponentDescription] = JC.JOB_COMP_DESC,
			[SalesClassCode] = JL.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[ClientPO] = JC.JOB_CL_PO_NBR,
			[ClientReference] = JL.JOB_CLI_REF,
			[BillingCoopCode] = JL.BILL_COOP_CODE,
			[ScheduleStatus] = T.TRF_DESCRIPTION,
			[ScheduleCompletedDate] = JT.COMPLETED_DATE,
			[EstimateNumberComponentQuoteRevision] = RIGHT('000000' + CAST(EA.ESTIMATE_NUMBER AS VARCHAR(15)), 6) + '-' + 
													 RIGHT('00' + CAST(EA.EST_COMPONENT_NBR AS VARCHAR(10)), 2) + '-' + 
													 RIGHT('00' + CAST(EA.EST_QUOTE_NBR AS VARCHAR(10)), 2) + '- REV ' + 
													 RIGHT('00' + CAST(EA.EST_REVISION_NBR AS VARCHAR(10)), 2),
			[EstimateApprovedDate] = EA.EST_APPR_DATE,
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionCode] = JCF.FunctionCode,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[EstimateHours] = est.EstimateHours,
			[EstimateQuantity] = est.EstimateQuantity,
			[EstimateNetAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateNetAmount, 0) + COALESCE(est.ContingencyNet, 0) ELSE COALESCE(est.EstimateNetAmount, 0) END,
			[EstimateMarkupAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateMarkupAmount, 0) + COALESCE(est.ContingencyMarkup, 0) ELSE COALESCE(est.EstimateMarkupAmount, 0) END,
			[EstimateAmount] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateAmount, 0) + COALESCE(est.ContingencyAmount, 0) ELSE COALESCE(est.EstimateAmount, 0) END,
			[EstimateResaleTax] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateResaleTax, 0) + COALESCE(est.ContingencyResale, 0) ELSE COALESCE(est.EstimateResaleTax,0) END,
			[EstimateTotal] = CASE WHEN @IncludeContingency = 1 THEN COALESCE(est.EstimateTotal, 0) + COALESCE(est.ContingencyTotal, 0) ELSE COALESCE(est.EstimateTotal, 0) END,
			[BillingApprovalHeaderComment] = BAH.APPR_COMMENTS,
			[BillingApprovalHeaderClientComment] = BAH.CLIENT_COMMENTS,
			[AdvanceBillRequested] = CASE WHEN (COALESCE(BAH.BILL_TYPE,0) = 2 OR COALESCE(BAH.BILL_TYPE,0) = 3) AND COALESCE(JC.AB_FLAG, 0) = 0 THEN 1
										  ELSE 0 END,
			[JobBillHoldRequested] = CASE WHEN COALESCE(BAH.BILL_TYPE,0) = 1 THEN 1
										  WHEN BAH.BA_ID IS NOT NULL AND COALESCE(BAH.BILL_TYPE,0) = 0 AND COALESCE(JC.JOB_BILL_HOLD, 0) > 1 THEN 0
										  ELSE 0 END,
			[ProcessControl] = JC.JOB_PROCESS_CONTRL,
			[AmountSelectedforBilling] = JOBS.AMOUNT_SELECTED_FOR_BILLING,
			[BillingUser] = SUBSTRING(JC.BILLING_USER, 1, LEN(JC.BILLING_USER) - 2),
			[ProcessControlDescription] = JPC.JOB_PROCESS_DESC,
			[JobBillHold] = JC.JOB_BILL_HOLD,
			[ABFlag] = JC.AB_FLAG,
			[IsCloseable] = ( SELECT dbo.advfn_bcc_is_job_closeable(JL.JOB_NUMBER, JC.JOB_COMPONENT_NBR)),
			[FunctionType] = F.FNC_TYPE,
			[FunctionOrder] = F.FNC_ORDER,
			[FunctionConsolidationCode] = FC.FNC_CODE, 
			[FunctionConsolidationDescription] = FC.FNC_DESCRIPTION,
			[IsAdjusted] = CASE WHEN NULLIF(JC.ADJUST_USER,'') IS NOT NULL THEN 1 ELSE 0 END,
			[JobBillComment] = JL.JOB_BILL_COMMENT,
			[BillingApprovalHeaderID] = BAH.BA_HDR_ID,
			[CampaignComment] = CMP.CMP_COMMENTS,
			[JobComment] = JL.JOB_COMMENTS,
			[JobComponentComment] = JC.JOB_COMP_COMMENTS,
			[JobTypeDescription] = JTYPE.JT_DESC
	FROM	dbo.JOB_LOG JL
		INNER JOIN dbo.JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER
		INNER JOIN @JOBCOMPONENTS JOBS ON JOBS.JOB_NUMBER = JC.JOB_NUMBER AND JOBS.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN @JOBCOMPONENTFUNCTIONS JCF ON JCF.JobNumber = JC.JOB_NUMBER AND JCF.ComponentNumber = JC.JOB_COMPONENT_NBR
		INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON JC.JOB_PROCESS_CONTRL = JPC.JOB_PROCESS_CONTRL 
		LEFT OUTER JOIN dbo.ESTIMATE_APPROVAL EA ON JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR AND JC.JOB_NUMBER = EA.JOB_NUMBER
		LEFT OUTER JOIN dbo.JOB_TRAFFIC JT ON JC.JOB_NUMBER = JT.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR
		LEFT OUTER JOIN dbo.TRAFFIC T ON JT.TRF_CODE = T.TRF_CODE
		LEFT OUTER JOIN dbo.CAMPAIGN CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
		INNER JOIN dbo.OFFICE O ON JL.OFFICE_CODE = O.OFFICE_CODE 
		INNER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE 
		INNER JOIN dbo.DIVISION D ON JL.CL_CODE = D.CL_CODE AND JL.DIV_CODE = D.DIV_CODE 
		INNER JOIN dbo.PRODUCT P ON JL.CL_CODE = P.CL_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.PRD_CODE = P.PRD_CODE 
		LEFT OUTER JOIN dbo.SALES_CLASS SC ON JL.SC_CODE = SC.SC_CODE
		LEFT OUTER JOIN (SELECT
							[FunctionCode],
							[JobNumber],
							[JobComponentNumber],
							[EstimateHours] = SUM([EstimateHours]),
							[EstimateQuantity] = SUM([EstimateQuantity]),
							[EstimateNetAmount] = SUM([EstimateNetAmount]),
							[EstimateMarkupAmount] = SUM([EstimateMarkupAmount]),
							[EstimateAmount] = SUM([EstimateAmount]),
							[EstimateResaleTax] = SUM([EstimateResaleTax]),
							[EstimateTotal] = SUM([EstimateTotal]),
							[ContingencyNet] = SUM([ContingencyNet]),
							[ContingencyMarkup] = SUM([ContingencyMarkup]),
							[ContingencyAmount] = SUM([ContingencyAmount]),
							[ContingencyResale] = SUM([ContingencyResale]),
							[ContingencyTotal] = SUM([ContingencyTotal])
						FROM (
								SELECT
									[FunctionCode] = ERT.FNC_CODE,
									[JobNumber] = EA.JOB_NUMBER,
									[JobComponentNumber] = EA.JOB_COMPONENT_NBR,
									[EstimateHours] = CASE WHEN ERT.EST_FNC_TYPE = 'E' THEN COALESCE(ERT.EST_REV_QUANTITY,0) ELSE 0 END,
									[EstimateQuantity] = CASE WHEN ERT.EST_FNC_TYPE <> 'E' THEN COALESCE(ERT.EST_REV_QUANTITY,0) ELSE 0 END,
									[EstimateNetAmount] = COALESCE(ERT.EST_REV_EXT_AMT,0) + COALESCE(ERT.EXT_NONRESALE_TAX,0),
									[EstimateMarkupAmount] = COALESCE(ERT.EXT_MARKUP_AMT,0),
									[EstimateAmount] = COALESCE(ERT.EST_REV_EXT_AMT,0) + COALESCE(ERT.EXT_NONRESALE_TAX,0) + COALESCE(ERT.EXT_MARKUP_AMT,0),
									[EstimateResaleTax] = COALESCE(ERT.EXT_STATE_RESALE, 0) + COALESCE(ERT.EXT_COUNTY_RESALE, 0) + COALESCE(ERT.EXT_CITY_RESALE, 0),
									[EstimateTotal] = COALESCE(ERT.LINE_TOTAL, 0),
									[ContingencyNet] = COALESCE(ERT.EXT_CONTINGENCY, 0) + COALESCE(ERT.EXT_NR_CONT, 0),
									[ContingencyMarkup] = COALESCE(ERT.EXT_MU_CONT, 0),
									[ContingencyAmount] = COALESCE(ERT.EXT_CONTINGENCY, 0) + COALESCE(ERT.EXT_NR_CONT, 0) + COALESCE(ERT.EXT_MU_CONT, 0),
									[ContingencyResale] = COALESCE(ERT.EXT_STATE_CONT, 0) + COALESCE(ERT.EXT_COUNTY_CONT, 0) + COALESCE(ERT.EXT_CITY_CONT, 0),
									[ContingencyTotal] = COALESCE(ERT.LINE_TOTAL_CONT, 0)
								FROM dbo.ESTIMATE_APPROVAL EA
									INNER JOIN dbo.ESTIMATE_REV_DET ERT ON EA.ESTIMATE_NUMBER = ERT.ESTIMATE_NUMBER AND EA.EST_COMPONENT_NBR = ERT.EST_COMPONENT_NBR 
																		AND EA.EST_QUOTE_NBR = ERT.EST_QUOTE_NBR AND EA.EST_REVISION_NBR = ERT.EST_REV_NBR AND ERT.FNC_CODE IS NOT NULL
								WHERE EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = EA.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR)) estdetails
						GROUP BY
							[FunctionCode],
							[JobNumber],
							[JobComponentNumber]) est ON est.JobNumber = JCF.JobNumber AND est.JobComponentNumber = JCF.ComponentNumber AND est.FunctionCode = JCF.FunctionCode
		LEFT OUTER JOIN dbo.FUNCTIONS F ON JCF.FunctionCode = F.FNC_CODE 
		LEFT OUTER JOIN dbo.FNC_HEADING FH ON F.FNC_HEADING_ID = FH.FNC_HEADING_ID
		LEFT OUTER JOIN dbo.BILL_APPR_HDR BAH ON BAH.BA_ID = JC.SELECTED_BA_ID AND BAH.JOB_NUMBER = JC.JOB_NUMBER AND BAH.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN dbo.FUNCTIONS FC ON F.FNC_CONSOLIDATION = FC.FNC_CODE
		LEFT OUTER JOIN dbo.JOB_TYPE JTYPE ON JC.JT_CODE = JTYPE.JT_CODE
	IF @debug = 1
		SELECT GETDATE() 'AFTER @FUNCTIONRESULTS'

END

IF @SumByFunctionCode = 1 
	SELECT
		R.[JobNumber],
		R.[ComponentNumber],
		[FunctionHeading],
		R.[FunctionCode],
		[FunctionDescription],
		R.[FunctionConsolidationCode], 
		R.[FunctionConsolidationDescription],
		COALESCE(EstimateHours, 0) AS EstimateHours,
		COALESCE(EstimateQuantity, 0) AS EstimateQuantity,
		COALESCE(EstimateNetAmount, 0) AS EstimateNetAmount,
		COALESCE(EstimateMarkupAmount, 0) AS EstimateMarkupAmount,
		COALESCE(EstimateAmount, 0) AS EstimateAmount,
		COALESCE(EstimateResaleTax, 0) AS EstimateResaleTax,
		COALESCE(EstimateTotal, 0) AS EstimateTotal,
		S.ActualBillableHours,
		S.ActualBillableQuantity,
		S.ActualBillableNetAmount,
		S.ActualBillableMarkupAmount,
		S.ActualBillableAmount,
		S.ActualBillableResaleTax,
		S.ActualBillableTotal,
		S.BilledHours,
		S.BilledQuantity,
		S.BilledNet,
		S.BilledMarkup,
		S.BilledAmount,
		S.BilledResaleTax,
		S.BilledTotal,
		S.UnbilledHours,
		S.UnbilledQuantity,
		S.UnbilledNetAmount,
		S.UnbilledMarkupAmount,
		S.UnbilledAmount,
		S.UnbilledResaleTax,
		S.UnbilledTotal,
		S.AdvanceHours,
		S.AdvanceQuantity,
		S.AdvanceBilledNetAmount,
		S.AdvanceBilledMarkupAmount,
		S.AdvanceBilledAmount,
		S.AdvanceBilledResaleTax,
		S.AdvanceBilledTotal,
		S.UnbilledAdvanceAmount,
		S.UnbilledAdvanceResaleTax,
		S.UnbilledAdvanceTotal,
		S.FlatIncomeRecognized,
		S.NonBillableHours,
		S.NonBillableQuantity,
		S.NonBillableNetAmount,
		S.NonBillableMarkupAmount,
		S.NonBillableAmount,
		S.FeeAmount,
		S.FeeResaleTax,
		S.FeeTotal,
		S.FeeHours,
		S.BillHoldAmount,
		PO.OpenPOAmount,
		[FunctionType],
		[FunctionOrder],
		[BilledOfEstimate] = CASE WHEN COALESCE(EstimateAmount, 0) <> 0 THEN (COALESCE(S.BilledAmount, 0) + COALESCE(S.AdvanceBilledAmount, 0)) / COALESCE(EstimateAmount, 0) * 100 ELSE 0 END,
		[BillingApprovalFunctionAmount] = BAD.ApprovedAmount,
		[BillingApprovalFunctionComment] = BAD.[BillingApprovalFunctionComment],
		[BillingApprovalFunctionClientComment] = BAD.[BillingApprovalFunctionClientComment],
		[AdvanceBillRequested],
		[BillingApprovalDetailID],
		S.[FlatIncomeToRecognize],
		[AmountToBill] = COALESCE(S.AmountToBill, 0),
		[PercentCompleteTime] = CASE WHEN [FunctionType] = 'E' AND (COALESCE(EstimateNetAmount, 0) + COALESCE(EstimateMarkupAmount, 0)) <> 0 THEN
										(COALESCE(ActualBillableNetAmount,0) + COALESCE(ActualBillableMarkupAmount,0) + COALESCE(FeeAmount,0)) / (COALESCE(EstimateNetAmount, 0) + COALESCE(EstimateMarkupAmount, 0)) * 100
									 ELSE NULL END,
		[PercentCompleteAll] = CASE WHEN (COALESCE(EstimateNetAmount, 0) + COALESCE(EstimateMarkupAmount, 0)) <> 0 THEN 
										(COALESCE(ActualBillableNetAmount,0) + COALESCE(ActualBillableMarkupAmount,0) + COALESCE(FeeAmount,0)) / (COALESCE(EstimateNetAmount, 0) + COALESCE(EstimateMarkupAmount, 0)) * 100
									ELSE NULL END,
		S.UnbilledNetOnly,
		R.BillingUser,
		S.GrossIncome,
		S.AdvanceBillingRetained,
		R.[JobTypeDescription]
	FROM @FUNCTIONRESULTS R
		LEFT OUTER JOIN (
						SELECT
							BAD.JOB_NUMBER,
							BAD.JOB_COMPONENT_NBR,
							BAD.FNC_CODE,
							COALESCE(BAD.APPROVED_AMT, 0) AS ApprovedAmount,
							COALESCE(BAD.APPR_NET, 0) + COALESCE(BAD.APPR_VENDOR_TAX, 0) AS ApprovedNetAmount,
							[BillingApprovalFunctionComment] = CAST(BAD.FNC_COMMENTS as varchar(max)),
							[BillingApprovalFunctionClientComment] = CAST(BAD.CLIENT_COMMENTS as varchar(max)),
							[BillingApprovalDetailID] = BAD.BA_DTL_ID
						FROM dbo.BILL_APPR_DTL BAD
							INNER JOIN @JOBCOMPONENTS JC ON BAD.BA_ID = JC.SELECTED_BA_ID AND BAD.JOB_NUMBER = JC.JOB_NUMBER AND BAD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
						) BAD ON R.[JobNumber] = BAD.JOB_NUMBER AND R.[ComponentNumber] = BAD.JOB_COMPONENT_NBR AND R.[FunctionCode] = BAD.FNC_CODE
		LEFT OUTER JOIN (
						SELECT
							JobNumber,
							ComponentNumber,
							FunctionCode,
							[ActualBillableHours] = SUM([ActualBillableHours]),
							[ActualBillableQuantity] = SUM([ActualBillableQuantity]),
							[ActualBillableNetAmount] = SUM([ActualBillableNetAmount]),
							[ActualBillableMarkupAmount] = SUM([ActualBillableMarkupAmount]),
							[ActualBillableAmount] = SUM([ActualBillableNetAmount]) + SUM([ActualBillableMarkupAmount]),
							[ActualBillableResaleTax] = SUM([ActualBillableResaleTax]),
							[ActualBillableTotal] = SUM([ActualBillableTotal]),
							[BilledHours] = SUM([BilledHours]),
							[BilledQuantity] = SUM([BilledQuantity]),
							[BilledNet] = SUM([BilledNet]),
							[BilledMarkup] = SUM([BilledMarkup]),
							[BilledAmount] = SUM([BilledNet]) + SUM([BilledMarkup]),
							[BilledResaleTax] = SUM([BilledResaleTax]),
							[BilledTotal] = SUM([BilledTotal]),
							[UnbilledHours] = SUM([UnbilledHours]),
							[UnbilledQuantity] = SUM([UnbilledQuantity]),
							[UnbilledNetAmount] = SUM([UnbilledNetAmount]),
							[UnbilledMarkupAmount] = SUM([UnbilledMarkupAmount]),
							[UnbilledAmount] = SUM([UnbilledNetAmount]) + SUM([UnbilledMarkupAmount]),
							[UnbilledResaleTax] = SUM([UnbilledResaleTax]),
							[UnbilledTotal] = SUM([UnbilledTotal]),
							[AdvanceHours] = SUM([AdvanceHours]),
							[AdvanceQuantity] = SUM([AdvanceQuantity]),
							[AdvanceBilledNetAmount] = SUM([AdvanceBilledNetAmount]),
							[AdvanceBilledMarkupAmount] = SUM([AdvanceBilledMarkupAmount]),
							[AdvanceBilledAmount] = SUM([AdvanceBilledAmount]),
							[AdvanceBilledResaleTax] = SUM([AdvanceBilledResaleTax]),
							[AdvanceBilledTotal] = SUM([AdvanceBilledTotal]),
							[UnbilledAdvanceAmount] = SUM([UnbilledAdvanceAmount]),
							[UnbilledAdvanceResaleTax] = SUM([UnbilledAdvanceResaleTax]),
							[UnbilledAdvanceTotal] = SUM([UnbilledAdvanceTotal]),
							[NonBillableHours] = SUM([NonBillableHours]),
							[NonBillableQuantity] = SUM([NonBillableQuantity]),
							[NonBillableNetAmount] = SUM([NonBillableNetAmount]),
							[NonBillableMarkupAmount] = SUM([NonBillableMarkupAmount]),
							[NonBillableAmount] = SUM([NonBillableNetAmount]) + SUM([NonBillableMarkupAmount]),
							[BillHoldAmount] = SUM([BillHoldAmount]),
							[FeeAmount] = SUM([FeeAmount]),
							[FeeResaleTax] = SUM([FeeResaleTax]),
							[FeeTotal] = SUM([FeeTotal]),
							[FeeHours] = SUM([FeeHours]),
							[FlatIncomeRecognized] = SUM([FlatIncomeRecognized]),
							[FlatIncomeToRecognize] = SUM([FlatIncomeToRecognize]),
							[AmountToBill] = SUM([AmountToBill]),
							[UnbilledNetOnly] = SUM([UnbilledNetOnly]),
							[GrossIncome] = SUM([GrossIncome]),
							[AdvanceBillingRetained] = SUM([AdvanceBillingRetained])
						FROM @SUBTOTALS S
						WHERE FunctionCode IS NOT NULL
						GROUP BY JobNumber, ComponentNumber, FunctionCode
						) S ON R.JobNumber = S.JobNumber AND R.ComponentNumber = S.ComponentNumber AND R.FunctionCode = S.FunctionCode 
		LEFT OUTER JOIN (
						SELECT	OpenPOAmount = CAST(SUM(OpenPOAmount) AS decimal(14,2)),
								POInfo.JobNumber,
								POInfo.JobComponentNumber,
								POInfo.FunctionCode 
						FROM (
								SELECT  [FunctionCode] = FNC_CODE,
										[JobNumber] = POD.JOB_NUMBER,
										[JobComponentNumber] = POD.JOB_COMPONENT_NBR,
										[OpenPOAmount] = CASE WHEN Prod.AP_PROD_EXT_AMT IS NULL THEN PO_EXT_AMOUNT ELSE PO_EXT_AMOUNT - Prod.AP_PROD_EXT_AMT END
								FROM dbo.PURCHASE_ORDER_DET POD
									INNER JOIN dbo.PURCHASE_ORDER PO ON POD.PO_NUMBER = PO.PO_NUMBER
									LEFT OUTER JOIN (
													SELECT AP_PROD_EXT_AMT = SUM(COALESCE(AP_PROD_EXT_AMT, 0)),
															JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
													FROM dbo.AP_PRODUCTION
													WHERE ((@prod_lock_selection = 1 AND BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
													GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
													) Prod ON POD.JOB_NUMBER = Prod.JOB_NUMBER AND POD.JOB_COMPONENT_NBR = Prod.JOB_COMPONENT_NBR AND POD.PO_NUMBER = Prod.PO_NUMBER AND POD.LINE_NUMBER = Prod.PO_LINE_NUMBER  
								WHERE
										FNC_CODE IS NOT NULL
								AND		POD.JOB_NUMBER IS NOT NULL
								AND		POD.JOB_COMPONENT_NBR IS NOT NULL
								AND		(POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0)
								AND		(VOID_FLAG IS NULL OR VOID_FLAG = 0) 
								AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = POD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = POD.JOB_COMPONENT_NBR)
							) POInfo
						GROUP BY JobNumber, JobComponentNumber, FunctionCode 
						) PO ON R.JobNumber = PO.JobNumber AND R.ComponentNumber = PO.JobComponentNumber AND R.FunctionCode = PO.FunctionCode
	WHERE	R.FunctionCode IS NOT NULL OPTION (RECOMPILE)
	
ELSE  --@SumByFunctionCode = 0
	SELECT
		[BillStatus] = CAST(CASE WHEN COALESCE([JobBillHold], 0) = 1 THEN 4
							WHEN COALESCE([JobBillHold], 0) = 2 THEN 3
							WHEN COALESCE([DetailBillHold],0) > 0 THEN 5
							WHEN [ABFlag] = 2 AND EXISTS(
															SELECT 1 
															FROM dbo.ADVANCE_BILLING ab
															WHERE ab.JOB_NUMBER = R.[JobNumber]
															AND ab.JOB_COMPONENT_NBR = R.[ComponentNumber]
															AND ( ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0 )
															AND ab.FINAL_AB_ID IS NOT NULL
															--AND ab.AR_INV_NBR IS NULL
														) THEN 7
							WHEN JC.RECONCILE_STATUS <> 0 THEN 6
							WHEN [ABFlag] IS NOT NULL AND [ABFlag] <> 0 THEN 2
							ELSE 1 END AS INT),
		[OfficeCode],
		[OfficeDescription],
		[CampaignID],
		[CampaignCode],
		[CampaignDescription],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		R.[JobNumber],
		[JobDescription],
		R.[ComponentNumber],
		[ComponentDescription],
		[SalesClassCode],
		[SalesClassDescription],
		[ClientPO],
		[ClientReference],
		[BillingCoopCode],
		[ScheduleStatus],
		[ScheduleCompletedDate],
		[EstimateNumberComponentQuoteRevision],
		[EstimateApprovedDate],
		COALESCE(EstimateHours, 0) AS EstimateHours,
		COALESCE(EstimateQuantity, 0) AS EstimateQuantity,
		COALESCE(EstimateNetAmount, 0) AS EstimateNetAmount,
		COALESCE(EstimateMarkupAmount, 0) AS EstimateMarkupAmount,
		COALESCE(EstimateAmount, 0) AS EstimateAmount,
		COALESCE(EstimateResaleTax, 0) AS EstimateResaleTax,
		COALESCE(EstimateTotal, 0) AS EstimateTotal,
		S.ActualBillableHours,
		S.ActualBillableQuantity,
		S.ActualBillableNetAmount,
		S.ActualBillableMarkupAmount,
		S.ActualBillableAmount,
		S.ActualBillableResaleTax,
		S.ActualBillableTotal,
		S.BilledHours,
		S.BilledQuantity,
		S.BilledNet,
		S.BilledMarkup,
		S.BilledAmount,
		S.BilledResaleTax,
		S.BilledTotal,
		S.UnbilledHours,
		S.UnbilledQuantity,
		S.UnbilledNetAmount,
		S.UnbilledMarkupAmount,
		S.UnbilledAmount,
		S.UnbilledResaleTax,
		S.UnbilledTotal,
		S.AdvanceHours,
		S.AdvanceQuantity,
		S.AdvanceBilledNetAmount,
		S.AdvanceBilledMarkupAmount,
		S.AdvanceBilledAmount,
		S.AdvanceBilledResaleTax,
		S.AdvanceBilledTotal,
		S.UnbilledAdvanceAmount,
		S.UnbilledAdvanceResaleTax,
		S.UnbilledAdvanceTotal,
		S.FlatIncomeRecognized,
		S.NonBillableHours,
		S.NonBillableQuantity,
		S.NonBillableNetAmount,
		S.NonBillableMarkupAmount,
		S.NonBillableAmount,
		S.FeeAmount,
		S.FeeResaleTax,
		S.FeeTotal,
		S.FeeHours,
		S.BillHoldAmount,
		PO.OpenPOAmount,
		[BillingApprovalAmount] = BA.APPROVED_AMT,
		[BillingApprovalHeaderComment],
		[BillingApprovalHeaderClientComment],
		[AdvanceBillRequested],
		[JobBillHoldRequested],
		[ProcessControl],
		[AmountSelectedforBilling],
		[BillingUser],
		[ProcessControlDescription],
		[IsCloseable],
		[DetailBillHold],
		[BilledOfEstimate] = CASE WHEN COALESCE(EstimateAmount, 0) <> 0 THEN (COALESCE(S.BilledAmount, 0) + COALESCE(S.AdvanceBilledAmount, 0)) / COALESCE(EstimateAmount, 0) * 100 ELSE 0 END,
		[IsAdjusted],
		R.[JobBillComment],
		R.[BillingApprovalHeaderID],
		S.[FlatIncomeToRecognize],
		[AmountToBill] = COALESCE(S.AmountToBill, 0),
		JobBillHold,
		ABFlag,
		[ReconcileResult] = CASE JC.RECONCILE_STATUS
							WHEN 1 THEN 'Reconciled to Actual'
							WHEN 2 THEN 'Reconciled to Quote'
							WHEN 3 THEN 'Intermim Reconciled'
							WHEN 4 THEN 'Reconciled to Billed'
							WHEN 5 THEN 'Intermim Reconciled'
							ELSE
								CASE
								WHEN EXISTS(SELECT 1
											FROM dbo.ADVANCE_BILLING 
											WHERE JOB_NUMBER = R.JobNumber
											AND JOB_COMPONENT_NBR = R.ComponentNumber
											AND AR_INV_NBR IS NULL
											) OR
									EXISTS (SELECT 1
											FROM dbo.INCOME_REC 
											WHERE JOB_NUMBER = R.JobNumber
											AND JOB_COMPONENT_NBR = R.ComponentNumber
											AND AR_INV_NBR IS NULL
											) THEN 'Cannot reconcile due to unbilled advance' ELSE '' END
							END,
		R.[CampaignComment],
		R.[JobComment],
		R.[JobComponentComment],
		S.[GrossIncome],
		[JobMediaDateToBill] = JC.MEDIA_BILL_DATE,
		S.[AdvanceBillingRetained],
		R.[AccountExecutive],
		R.[JobTypeDescription]
	FROM @RESULTS R
		INNER JOIN @JOBCOMPONENTS JC ON R.JobNumber = JC.JOB_NUMBER AND R.ComponentNumber = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN (
						SELECT COALESCE(A.APPROVED_AMT, DTL.DTL_APPROVED) AS APPROVED_AMT, A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.BA_ID 
						FROM dbo.BILL_APPR_HDR A
							INNER JOIN @JOBCOMPONENTS JC ON A.BA_ID = JC.SELECTED_BA_ID AND A.JOB_NUMBER = JC.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
								LEFT OUTER JOIN 
								(	
									SELECT SUM(COALESCE(APPROVED_AMT,0)) AS DTL_APPROVED, BA_ID, JOB_NUMBER, JOB_COMPONENT_NBR 
									FROM dbo.BILL_APPR_DTL
									GROUP BY BA_ID, JOB_NUMBER, JOB_COMPONENT_NBR
								) DTL ON A.BA_ID = DTL.BA_ID AND A.JOB_NUMBER = DTL.JOB_NUMBER AND A.JOB_COMPONENT_NBR = DTL.JOB_COMPONENT_NBR 
						) BA ON JC.SELECTED_BA_ID = BA.BA_ID AND JC.JOB_NUMBER = BA.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = BA.JOB_COMPONENT_NBR
		LEFT OUTER JOIN (
						SELECT
							JobNumber,
							ComponentNumber,
							[ActualBillableHours] = SUM([ActualBillableHours]),
							[ActualBillableQuantity] = SUM([ActualBillableQuantity]),
							[ActualBillableNetAmount] = SUM([ActualBillableNetAmount]),
							[ActualBillableMarkupAmount] = SUM([ActualBillableMarkupAmount]),
							[ActualBillableAmount] = SUM([ActualBillableNetAmount]) + SUM([ActualBillableMarkupAmount]),
							[ActualBillableResaleTax] = SUM([ActualBillableResaleTax]),
							[ActualBillableTotal] = SUM([ActualBillableTotal]),
							[BilledHours] = SUM([BilledHours]),
							[BilledQuantity] = SUM([BilledQuantity]),
							[BilledNet] = SUM([BilledNet]),
							[BilledMarkup] = SUM([BilledMarkup]),
							[BilledAmount] = SUM([BilledNet]) + SUM([BilledMarkup]),
							[BilledResaleTax] = SUM([BilledResaleTax]),
							[BilledTotal] = SUM([BilledTotal]),
							[UnbilledHours] = SUM([UnbilledHours]),
							[UnbilledQuantity] = SUM([UnbilledQuantity]),
							[UnbilledNetAmount] = SUM([UnbilledNetAmount]),
							[UnbilledMarkupAmount] = SUM([UnbilledMarkupAmount]),
							[UnbilledAmount] = SUM([UnbilledNetAmount]) + SUM([UnbilledMarkupAmount]),
							[UnbilledResaleTax] = SUM([UnbilledResaleTax]),
							[UnbilledTotal] = SUM([UnbilledTotal]),
							[AdvanceHours] = SUM([AdvanceHours]),
							[AdvanceQuantity] = SUM([AdvanceQuantity]),
							[AdvanceBilledNetAmount] = SUM([AdvanceBilledNetAmount]),
							[AdvanceBilledMarkupAmount] = SUM([AdvanceBilledMarkupAmount]),
							[AdvanceBilledAmount] = SUM([AdvanceBilledAmount]),
							[AdvanceBilledResaleTax] = SUM([AdvanceBilledResaleTax]),
							[AdvanceBilledTotal] = SUM([AdvanceBilledTotal]),
							[UnbilledAdvanceAmount] = SUM([UnbilledAdvanceAmount]),
							[UnbilledAdvanceResaleTax] = SUM([UnbilledAdvanceResaleTax]),
							[UnbilledAdvanceTotal] = SUM([UnbilledAdvanceTotal]),
							[FlatIncomeRecognized] = SUM([FlatIncomeRecognized]),
							[NonBillableHours] = SUM([NonBillableHours]),
							[NonBillableQuantity] = SUM([NonBillableQuantity]),
							[NonBillableNetAmount] = SUM([NonBillableNetAmount]),
							[NonBillableMarkupAmount] = SUM([NonBillableMarkupAmount]),
							[NonBillableAmount] = SUM([NonBillableNetAmount]) + SUM([NonBillableMarkupAmount]),
							[BillHoldAmount] = SUM([BillHoldAmount]),
							[FeeAmount] = SUM([FeeAmount]),
							[FeeResaleTax] = SUM([FeeResaleTax]),
							[FeeTotal] = SUM([FeeTotal]),
							[FeeHours] = SUM([FeeHours]),
							[DetailBillHold] = SUM([DetailBillHold]),
							[FlatIncomeToRecognize] = SUM([FlatIncomeToRecognize]),
							[AmountToBill] = SUM([AmountToBill]),
							[GrossIncome] = SUM([GrossIncome]),
							[AdvanceBillingRetained] = SUM([AdvanceBillingRetained])
						FROM @SUBTOTALS 
						GROUP BY JobNumber, ComponentNumber
						) S ON R.JobNumber = S.JobNumber AND R.ComponentNumber = S.ComponentNumber
		LEFT OUTER JOIN (
						SELECT	OpenPOAmount = SUM(OpenPOAmount),
								POInfo.JobNumber,
								POInfo.JobComponentNumber   
						FROM (
								SELECT  [FunctionCode] = FNC_CODE,
										[JobNumber] = POD.JOB_NUMBER,
										[JobComponentNumber] = POD.JOB_COMPONENT_NBR,
										[OpenPOAmount] = CASE WHEN Prod.AP_PROD_EXT_AMT IS NULL THEN PO_EXT_AMOUNT ELSE PO_EXT_AMOUNT - Prod.AP_PROD_EXT_AMT END
								FROM dbo.PURCHASE_ORDER_DET POD
									INNER JOIN dbo.PURCHASE_ORDER PO ON POD.PO_NUMBER = PO.PO_NUMBER
									LEFT OUTER JOIN (
													SELECT AP_PROD_EXT_AMT = SUM(COALESCE(AP_PROD_EXT_AMT, 0)),
															JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
													FROM dbo.AP_PRODUCTION
													WHERE ((@prod_lock_selection = 1 AND BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
													GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, PO_NUMBER, PO_LINE_NUMBER
													) Prod ON POD.JOB_NUMBER = Prod.JOB_NUMBER AND POD.JOB_COMPONENT_NBR = Prod.JOB_COMPONENT_NBR AND POD.PO_NUMBER = Prod.PO_NUMBER AND POD.LINE_NUMBER = Prod.PO_LINE_NUMBER  
								WHERE
										FNC_CODE IS NOT NULL
								AND		POD.JOB_NUMBER IS NOT NULL
								AND		POD.JOB_COMPONENT_NBR IS NOT NULL
								AND		(POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0)
								AND		(VOID_FLAG IS NULL OR VOID_FLAG = 0) 
								AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = POD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = POD.JOB_COMPONENT_NBR)
							) POInfo
						GROUP BY JobNumber, JobComponentNumber
						) PO ON R.JobNumber = PO.JobNumber AND R.ComponentNumber = PO.JobComponentNumber OPTION (RECOMPILE)
	
IF @debug = 1
	SELECT GETDATE() 'END'

END
GO
