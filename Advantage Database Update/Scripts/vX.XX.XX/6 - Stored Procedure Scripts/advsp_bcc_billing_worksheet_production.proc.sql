CREATE PROC [dbo].[advsp_bcc_billing_worksheet_production]
	@et_date_cutoff smalldatetime,
	@io_date_cutoff smalldatetime, 
	@ap_pp_cutoff varchar(6), 
	@job_type smallint, 
	@job_option smallint, 
	@include_non_billable_time_detail bit, 
	@include_non_billable_ap_io_detail bit,
	@print_item_detail smallint,
	@IncludeContingency bit,
	@user_code varchar(100),
	@ClientCodeList varchar(max),
	@ClientDivisionCodeList varchar(max),
	@ClientDivisionProductCodeList varchar(max),
	@AECodeList varchar(max),
	@BillingCommandCenterID int,
	@SelectedJobList varchar(max) = null,
	@non_billable_from_date smalldatetime,
	@non_billable_to_date smalldatetime,
	@populate_time_comments bit,
	@populate_ap_comments bit,
	@populate_io_comments bit,
	@debug bit = NULL
AS

BEGIN

SET NOCOUNT ON;

/*
DECLARE @et_date_cutoff smalldatetime,
		@io_date_cutoff smalldatetime, 
		@ap_pp_cutoff varchar(6), 
		@job_type smallint, 
		@job_option smallint, 
		@include_non_billable_time_detail bit, 
		@include_non_billable_ap_io_detail bit,
		@print_item_detail smallint,
		@IncludeContingency bit,
		@debug bit = NULL

	SET @et_date_cutoff = '10/31/2015'
	SET @io_date_cutoff = '10/31/2015' 
	SET @ap_pp_cutoff = '201510'
	SET @job_type = 0
	SET @job_option = 3
	SET @include_non_billable_time_detail = 1
	SET @include_non_billable_ap_io_detail = 1
	SET @print_item_detail = 1
	SET @IncludeContingency = 0
	SET @debug = 1
*/

IF @debug = 1
	SELECT GETDATE() 'START'

DECLARE	@prod_lock_selection bit


SELECT @prod_lock_selection = PROD_LOCK_SELECTION
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @BillingCommandCenterID

IF @prod_lock_selection IS NULL
	SET @prod_lock_selection = 0

DECLARE @JOBCOMPONENTS TABLE (
	JOB_NUMBER int NOT NULL,
	JOB_COMPONENT_NBR smallint NOT NULL,
	HAS_BILLING_APPROVAL bit NOT NULL,
	SELECTED_BA_ID int NULL,
	RECONCILE_STATUS int NULL,
	AB_FLAG smallint NULL,
	SERVICE_FEE_FLAG smallint NULL,
	BA_BATCH_ID int NULL,
	BA_BATCH_DESC varchar(50) NULL
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
    [UnbilledMarkupPercent] decimal(9,3) NULL,
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
	[UnbilledAdvanceNetAmount] decimal(15,2) NULL,
	[UnbilledAdvanceMarkupAmount] decimal(15,2) NULL,
	[UnbilledAdvanceAmount] decimal(15,2) NULL,
	[UnbilledAdvanceResaleTax] decimal(15,2) NULL,
	[UnbilledAdvanceTotal] decimal(15,2) NULL,
	[FlatIncomeRecognized] decimal(15,2) NULL,
	[FeeTimeHours] decimal(7,2) NULL,
	[FeeAmount] decimal(15,2) NULL,
	[FeeResaleTax] decimal(15,2) NULL,
	[FeeTotal] decimal(15,2) NULL,
	[DetailBillHold] smallint NULL,
	[FlatIncomeToRecognize] decimal(15,2) NULL,
	[AmountToBill] decimal(15,2) NULL,
	[UnbilledNetOnly] decimal(15,2) NULL,

	[ItemBillingTransferFromJob] int NULL,
	[ItemBillingTransferFromJobComponent] smallint NULL,
	[ItemBillingTransferFromFunctionCode] varchar(6) NULL,
	[ItemBillingTransferToJob] int NULL,
	[ItemBillingTransferToJobComponent] smallint NULL,
	[ItemBillingTransferToFunctionCode] varchar(6) NULL,
	[ItemBillingAdjustmentWriteOffFlag] smallint NULL,
	[ItemBillingTransferAdjustmentUser] varchar(100) NULL,
	[ItemBillingTransferAdjustmentDate] smalldatetime NULL,
	[ItemBillingTransferAdjustmentComment] varchar(max) NULL,
	[ItemID] int NULL,
	[ItemDate] smalldatetime NULL,
	[ItemPostPeriodCode] varchar(6) NULL,
	[ItemCode] varchar(6) NULL,
	[ItemDescription] varchar(max) NULL,
	[ItemComment] varchar(max) NULL,
	[ItemFeeFlag] varchar(30) NULL,
	[ItemBillable] bit NOT NULL DEFAULT(0),
	[ItemApprovalAmount] decimal(15,2) NULL,
	[ItemInvoiceNumber] varchar(26) NULL,
	[GrossIncome] decimal(15,2) NULL,
	AR_INV_NBR int NULL,
	[AdvanceBillingRetained] decimal(15,2) NULL
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
	--[AmountSelectedforBilling] decimal(18,2) NOT NULL,
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
	[BillingCoopDescription] varchar(30) NULL,
	[AccountExecutive] varchar(65) NULL,
	RECONCILE_STATUS int NULL,
	[AECode] varchar(6) NULL,
	[AEFirstName] varchar(30) NULL,
	[AELastName] varchar(30) NULL,
	[JobMediaDateToBill] smalldatetime NULL,
	[BillingCommandCenterID] int NULL,
	[EstimateNumber] int NULL,
	[EstimateDescription] varchar(60) NULL,
	[EstimateComponentNumber] smallint NULL,
	[EstimateComponentDescription] varchar(60) NULL,
	[BillingApprovalBatchID] int NULL,
	[BillingApprovalBatchDescription] varchar(50) NULL
)

DECLARE @JOBCOMPONENTFUNCTIONS TABLE (
	JobNumber int NOT NULL,
	ComponentNumber smallint NOT NULL,
	FunctionCode varchar(6) NOT NULL
)

DECLARE @income_only TABLE (
	[ID] int NOT NULL,
	[SequenceNumber] smallint NOT NULL,
	[ClientCode] varchar(6) NOT NULL,
	[ClientName] varchar(40) NULL,
	[DivisionCode] varchar(6) NOT NULL,
	[DivisionName] varchar(40) NULL,
	[ProductCode] varchar(6) NOT NULL,
	[ProductName] varchar(40) NULL,
	[JobNumber] int NOT NULL,
	[JobDescription] varchar(60) NULL,
	[JobComponentNumber] smallint NOT NULL,
	[JobComponentID] int NOT NULL,
	[JobComponentDescription] varchar(60) NULL,
	[FunctionCode] varchar(6) NULL,
	[FunctionDescription] varchar(30) NULL,
	[InvoiceDate] smalldatetime NULL,
	[Quantity] decimal(14,2) NULL,
	[Rate] decimal(12,4) NULL,
	[Amount] decimal(14,2) NULL,
	[CommissionPercent] decimal(9,3) NULL,
	[MarkupAmount] decimal(14,2) NULL,
	[LineTotal] decimal(14,2) NULL,
	[Description] varchar(100) NULL,
	[ReferenceNumber] varchar(26) NULL,
	[Comment] varchar(max) NULL,
	[BillingUser] varchar(100) NULL,
	[TaxCode] varchar(4) NULL,
	[TaxStatePercent] decimal(8,4) NULL,
	[TaxCountyPercent] decimal(8,4) NULL,
	[TaxCityPercent] decimal(8,4) NULL,
	[TaxCommission] smallint NULL,
	[TaxCommissionOnly] smallint NULL,
	[CityTaxAmount] decimal(14,2) NULL,
	[CountyTaxAmount] decimal(14,2) NULL,
	[StateTaxAmount] decimal(14,2) NULL,
	[TaxResale] smallint NULL,
	[IsServiceFee] bit NOT NULL,
	[IsBilled] bit NOT NULL,
	[NonBillable] bit NOT NULL,
	[SalesClassCode] varchar(6) NULL,
	[DepartmentTeamCode] varchar(4) NULL,
	[IsDeleted] bit NOT NULL,
	[JobServiceFeeID] int NULL,
	[EverBilled] bit NOT NULL
)

IF @debug = 1
	SELECT GETDATE() 'BEFORE @JOBCOMPONENTS'

-- SELECT * FROM dbo.udf_split_list('1', ',')

INSERT INTO @JOBCOMPONENTS (JOB_NUMBER, JOB_COMPONENT_NBR, HAS_BILLING_APPROVAL, SELECTED_BA_ID, RECONCILE_STATUS, AB_FLAG, SERVICE_FEE_FLAG)
SELECT JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, 
	CASE WHEN BAH.BA_ID IS NOT NULL THEN 1 ELSE 0 END, CASE WHEN BAH.BA_ID IS NOT NULL THEN JC.SELECTED_BA_ID ELSE NULL END,
	dbo.advfn_adv_bill_reconcile_status ( JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR),
	JC.AB_FLAG, JC.SERVICE_FEE_FLAG
FROM dbo.JOB_COMPONENT JC 
	LEFT OUTER JOIN dbo.BILL_APPR_HDR BAH ON JC.JOB_NUMBER = BAH.JOB_NUMBER and JC.JOB_COMPONENT_NBR = BAH.JOB_COMPONENT_NBR AND JC.SELECTED_BA_ID = BAH.BA_ID 
WHERE (1=1)
	AND (JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ))
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND JC.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
AND		(
		( @job_option = 1 AND dbo.advfn_job_has_qual_records( JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, @et_date_cutoff, @io_date_cutoff, @ap_pp_cutoff) = 1 )
		OR
		( @job_option = 2 AND ( dbo.advfn_is_job_billed_w_cutoffs( JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR, @et_date_cutoff, @io_date_cutoff, @ap_pp_cutoff) = 0 ))
		OR
		( @job_option = 3 )
		)


DECLARE @EmployeeCode varchar(6)

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@user_code)

CREATE TABLE #Jobs (
	JOB_NUMBER int NOT NULL
)

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_code)) > 0
	INSERT #Jobs
	SELECT jl.JOB_NUMBER
	FROM dbo.JOB_LOG jl
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = UPPER(@user_code) 
										AND jl.CL_CODE = sc.CL_CODE
										AND jl.DIV_CODE = sc.DIV_CODE
										AND jl.PRD_CODE = sc.PRD_CODE
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND jl.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
ELSE
	INSERT #Jobs
	SELECT jl.JOB_NUMBER
	FROM dbo.JOB_LOG jl
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND jl.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))

DELETE @JOBCOMPONENTS WHERE JOB_NUMBER NOT IN (SELECT JOB_NUMBER FROM #Jobs)

UPDATE @JOBCOMPONENTS SET SELECTED_BA_ID =
										(
										SELECT MIN(bah.BA_ID)
										FROM dbo.BILL_APPR_HDR bah
											INNER JOIN dbo.BILL_APPR ba ON bah.BA_ID = ba.BA_ID
											LEFT OUTER JOIN dbo.BILL_APPR_BATCH bab ON ba.BA_BATCH_ID = bab.BA_BATCH_ID
										WHERE bah.JOB_NUMBER = jc.JOB_NUMBER AND bah.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
										AND bah.AR_INV_NBR IS NULL
										AND bah.APPR_STATUS IS NULL
										AND (bab.BA_BATCH_ID IS NULL OR bab.APPROVED = 1)
										)
FROM @JOBCOMPONENTS jc
WHERE jc.SELECTED_BA_ID IS NULL

IF ( @job_type = 2 )
	DELETE @JOBCOMPONENTS
	WHERE COALESCE(AB_FLAG, 0) = 0

IF ( @job_type = 3 )
	DELETE @JOBCOMPONENTS
	WHERE COALESCE(SERVICE_FEE_FLAG, 0) <> 1

UPDATE @JOBCOMPONENTS SET BA_BATCH_ID = BAB.BA_BATCH_ID, BA_BATCH_DESC = BAB.BA_BATCH_DESC
FROM @JOBCOMPONENTS jc
	LEFT OUTER JOIN dbo.BILL_APPR BA ON jc.SELECTED_BA_ID = BA.BA_ID
	LEFT OUTER JOIN dbo.BILL_APPR_BATCH BAB ON BA.BA_BATCH_ID = BAB.BA_BATCH_ID

IF @debug = 1
	SELECT GETDATE() 'AFTER @JOBCOMPONENTS'

INSERT @SUBTOTALS (JobNumber, ComponentNumber, FunctionCode, FlatIncomeRecognized)
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, SUM(REC_AMT)
FROM dbo.INCOME_REC IR
WHERE IR.AR_INV_NBR IS NOT NULL
AND EXISTS (SELECT 1 
			FROM @JOBCOMPONENTS JC 
			WHERE JC.JOB_NUMBER = IR.JOB_NUMBER 
				AND JC.JOB_COMPONENT_NBR = IR.JOB_COMPONENT_NBR
				AND	(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND JC.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
				) 
GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE

IF @debug = 1
	SELECT GETDATE() 'AFTER INCOME_REC1'

INSERT @SUBTOTALS (JobNumber, ComponentNumber, FunctionCode, FlatIncomeToRecognize)
SELECT JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, SUM(REC_AMT)
FROM dbo.INCOME_REC IR
WHERE IR.AR_INV_NBR IS NULL
AND EXISTS (SELECT 1 
			FROM @JOBCOMPONENTS JC 
			WHERE JC.JOB_NUMBER = IR.JOB_NUMBER 
			AND JC.JOB_COMPONENT_NBR = IR.JOB_COMPONENT_NBR)
			AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND IR.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
			 
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
    [UnbilledMarkupPercent] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(AP_PROD_COMM_PCT, 0) ELSE 0 END,
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
	[UnbilledAdvanceNetAmount] = 0,
	[UnbilledAdvanceMarkupAmount] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	[FeeTimeHours] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[DetailBillHold] = COALESCE(AP_PROD_BILL_HOLD, 0),
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN 
						COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledNetOnly] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 AND COALESCE(AP_PROD_BILL_HOLD, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(AP_PROD_EXT_AMT, 0) ELSE 0 END,
	[ItemBillingTransferFromJob] = AP.XFER_FROM_JOB,
	[ItemBillingTransferFromJobComponent] = AP.XFER_FROM_JOB_COMP,
	[ItemBillingTransferFromFunctionCode] = AP.XFER_FROM_FNC,
	[ItemBillingTransferToJob] = CASE WHEN AP.XFER_FROM_JOB IS NOT NULL THEN AP.JOB_NUMBER END,
	[ItemBillingTransferToJobComponent] = CASE WHEN AP.XFER_FROM_JOB_COMP IS NOT NULL THEN AP.JOB_COMPONENT_NBR END,
	[ItemBillingTransferToFunctionCode] = CASE WHEN AP.XFER_FROM_FNC IS NOT NULL THEN AP.FNC_CODE END,
	[ItemBillingAdjustmentWriteOffFlag] = AP.WRITE_OFF,
	[ItemBillingTransferAdjustmentUser] = AP.XFER_ADJ_USER,
	[ItemBillingTransferAdjustmentDate] = AP.XFER_ADJ_DATE,
	[ItemBillingTransferAdjustmentComment] = AP.ADJ_COMMENTS,
	[ItemID] = AP.AP_ID,
	[ItemDate] = APH.AP_INV_DATE,
	[ItemPostPeriodCode] = AP.POST_PERIOD,
	[ItemCode] = (SELECT TOP 1 VN_FRL_EMP_CODE FROM dbo.AP_HEADER WHERE AP_ID = AP.AP_ID ORDER BY AP_SEQ DESC),
	[ItemDescription] = (SELECT VN_NAME FROM dbo.VENDOR WHERE VN_CODE = APH.VN_FRL_EMP_CODE),
	[ItemComment] = CASE WHEN @populate_ap_comments = 1 THEN APC.AP_COMMENT ELSE NULL END,
	[ItemFeeFlag] = NULL,
	[ItemBillable] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 1 THEN 0 ELSE 1 END,
	[ItemApprovalAmount] = BA.APPROVED_AMT,
	[ItemInvoiceNumber] = APH.AP_INV_VCHR,
	[GrossIncome] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	AR_INV_NBR,
	[AdvanceBillingRetained] = 0
FROM dbo.AP_PRODUCTION AP
	LEFT OUTER JOIN dbo.AP_HEADER APH ON APH.AP_ID = AP.AP_ID AND APH.MODIFY_FLAG IS NULL
	LEFT OUTER JOIN dbo.AP_PROD_COMMENTS APC ON APC.AP_ID = AP.AP_ID AND APC.FNC_CODE = AP.FNC_CODE AND APC.JOB_COMPONENT_NBR = AP.JOB_COMPONENT_NBR 
											 AND APC.JOB_NUMBER = AP.JOB_NUMBER AND APC.LINE_NUMBER = AP.LINE_NUMBER
	LEFT OUTER JOIN (SELECT D.JOB_NUMBER, D.JOB_COMPONENT_NBR, D.FNC_CODE, D.BA_ID, I.REC_ID, I.APPROVED_AMT, I.REC_DTL_ID 
					 FROM dbo.BILL_APPR_DTL D 
						INNER JOIN dbo.BILL_APPR_ITEM I ON D.BA_DTL_ID = I.BA_DTL_ID 
						INNER JOIN @JOBCOMPONENTS JC ON D.JOB_NUMBER = JC.JOB_NUMBER AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR AND D.BA_ID = JC.SELECTED_BA_ID 
					 WHERE I.REC_TYPE = 'V'
					) BA ON BA.JOB_NUMBER = AP.JOB_NUMBER AND BA.JOB_COMPONENT_NBR = AP.JOB_COMPONENT_NBR AND BA.FNC_CODE = AP.FNC_CODE AND BA.REC_ID = AP.AP_ID AND BA.REC_DTL_ID = AP.LINE_NUMBER
WHERE	AP.POST_PERIOD <= @ap_pp_cutoff
AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND AP.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
AND		((@prod_lock_selection = 1 AND AP.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
AND		(
		(AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0)
		OR
		(AP_PROD_NOBILL_FLG = 1 AND @include_non_billable_ap_io_detail = 1)
		)
AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = AP.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = AP.JOB_COMPONENT_NBR) 
AND		(AP.IS_BILLED_REVERSAL = 1 OR (AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0))


IF @debug = 1
	SELECT GETDATE() 'AFTER AP @SUBTOTALS'

INSERT @SUBTOTALS 
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
    [UnbilledMarkupPercent] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EMP_COMM_PCT, 0) ELSE 0 END,
	[UnbilledMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledResaleTax] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[UnbilledTotal] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[NonBillableHours] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) = 0 THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
	[NonBillableQuantity] = 0,
	[NonBillableNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) = 0 THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
	[NonBillableMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 AND COALESCE(FEE_TIME, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[BillHoldAmount] = CASE WHEN (BILL_HOLD_FLG = 1 OR BILL_HOLD_FLG = 2) AND AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[AdvanceHours] = 0,
	[AdvanceQuantity] = 0,
	[AdvanceBilledNetAmount] = 0,
	[AdvanceBilledMarkupAmount] = 0,
	[AdvanceBilledAmount] = 0,
	[AdvanceBilledResaleTax] = 0,
	[AdvanceBilledTotal] = 0,
	[UnbilledAdvanceNetAmount] = 0,
	[UnbilledAdvanceMarkupAmount] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	[FeeTimeHours] = CASE WHEN COALESCE(FEE_TIME, 0) <> 0 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(EMP_HOURS, 0) ELSE 0 END,
	[FeeAmount] = CASE WHEN COALESCE(FEE_TIME, 0) <> 0 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(TOTAL_BILL, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[FeeResaleTax] = CASE WHEN COALESCE(FEE_TIME, 0) <> 0 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[FeeTotal] = CASE WHEN COALESCE(FEE_TIME, 0) <> 0 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[DetailBillHold] = COALESCE(BILL_HOLD_FLG, 0),
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN 
						COALESCE(TOTAL_BILL, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledNetOnly] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
	[ItemBillingTransferFromJob] = ETD.XFER_FROM_JOB,
	[ItemBillingTransferFromJobComponent] = ETD.XFER_FROM_JOB_COMP,
	[ItemBillingTransferFromFunctionCode] = ETD.XFER_FROM_FNC,
	[ItemBillingTransferToJob] = CASE WHEN ETD.XFER_FROM_JOB IS NOT NULL THEN ETD.JOB_NUMBER END,
	[ItemBillingTransferToJobComponent] = CASE WHEN ETD.XFER_FROM_JOB_COMP IS NOT NULL THEN ETD.JOB_COMPONENT_NBR END,
	[ItemBillingTransferToFunctionCode] = CASE WHEN ETD.XFER_FROM_FNC IS NOT NULL THEN ETD.FNC_CODE END,
	[ItemBillingAdjustmentWriteOffFlag] = 0,
	[ItemBillingTransferAdjustmentUser] = ETD.XFER_ADJ_USER,
	[ItemBillingTransferAdjustmentDate] = ETD.XFER_ADJ_DATE,
	[ItemBillingTransferAdjustmentComment] = ETD.ADJ_COMMENTS,
	[ItemID] = ETD.ET_ID,
	[ItemDate] = ET.EMP_DATE,
	[ItemPostPeriodCode] = NULL,
	[ItemCode] = ET.EMP_CODE,
	[ItemDescription] = COALESCE(EC.EMP_FNAME,'') + ' ' + COALESCE(EC.EMP_LNAME,''),
	[ItemComment] = CASE WHEN @populate_time_comments = 1 THEN
					(SELECT TOP 1 ETDC.EMP_COMMENT
					 FROM dbo.EMP_TIME_DTL_CMTS ETDC
					 WHERE ETDC.ET_ID = ETD.ET_ID
					 AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID
					 AND ETDC.ET_SOURCE = 'D')
					ELSE NULL END,
	[ItemFeeFlag] = CASE COALESCE(ETD.FEE_TIME, 0)
					WHEN 1 THEN 'Time Against Fee'
					WHEN 2 THEN 'Time Against Commission (P)'
					WHEN 3 THEN 'Time Against Commission (M)'
					ELSE 'No' END,
	[ItemBillable] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END,
	[ItemApprovalAmount] = BA.APPROVED_AMT,
	[ItemInvoiceNumber] = '',
	[GrossIncome] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(TOTAL_BILL, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	AR_INV_NBR,
	[AdvanceBillingRetained] = 0
FROM dbo.EMP_TIME_DTL ETD
	INNER JOIN dbo.EMP_TIME ET ON ET.ET_ID = ETD.ET_ID 
	LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK EC ON ET.EMP_CODE = EC.EMP_CODE
	LEFT OUTER JOIN (SELECT D.JOB_NUMBER, D.JOB_COMPONENT_NBR, D.FNC_CODE, D.BA_ID, I.REC_ID, I.APPROVED_AMT, I.REC_DTL_ID 
					 FROM dbo.BILL_APPR_DTL D 
						INNER JOIN dbo.BILL_APPR_ITEM I ON D.BA_DTL_ID = I.BA_DTL_ID 
						INNER JOIN @JOBCOMPONENTS JC ON D.JOB_NUMBER = JC.JOB_NUMBER AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR AND D.BA_ID = JC.SELECTED_BA_ID 
					 WHERE I.REC_TYPE = 'E'
					) BA ON BA.JOB_NUMBER = ETD.JOB_NUMBER AND BA.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR AND BA.FNC_CODE = ETD.FNC_CODE AND BA.REC_ID = ETD.ET_ID AND BA.REC_DTL_ID = ETD.SEQ_NBR
WHERE	((@prod_lock_selection = 1 AND ETD.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
AND		(
			(COALESCE(ETD.EMP_NON_BILL_FLAG, 0) = 0 AND ET.EMP_DATE <= @et_date_cutoff)
			OR
			(ETD.EMP_NON_BILL_FLAG = 1 AND @include_non_billable_time_detail = 1 AND ET.EMP_DATE BETWEEN @non_billable_from_date AND @non_billable_to_date)
		)
AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = ETD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR)
AND		(ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0)
AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND ETD.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))

IF @debug = 1
	SELECT GETDATE() 'AFTER ET @SUBTOTALS'



INSERT @income_only 
SELECT  
		[ID] = INCOME_ONLY.IO_ID,
		[SequenceNumber] = INCOME_ONLY.SEQ_NBR,
		[ClientCode] = JOB_LOG.CL_CODE,
		[ClientName] = CLIENT.CL_NAME,
		[DivisionCode] = JOB_LOG.DIV_CODE,
		[DivisionName] = DIVISION.DIV_NAME,
		[ProductCode] = JOB_LOG.PRD_CODE,
		[ProductName] = PRODUCT.PRD_DESCRIPTION,
		[JobNumber] = INCOME_ONLY.JOB_NUMBER,
		[JobDescription] = JOB_LOG.JOB_DESC,
		[JobComponentNumber] = INCOME_ONLY.JOB_COMPONENT_NBR,
		[JobComponentID] = JOB_COMPONENT.ROWID,
		[JobComponentDescription] = JOB_COMPONENT.JOB_COMP_DESC,
		[FunctionCode] = INCOME_ONLY.FNC_CODE,
		[FunctionDescription] = FUNCTIONS.FNC_DESCRIPTION,
		[InvoiceDate] = INCOME_ONLY.IO_INV_DATE,
		[Quantity] = INCOME_ONLY.IO_QTY,
		[Rate] = INCOME_ONLY.IO_RATE,
		[Amount] = INCOME_ONLY.IO_AMOUNT,
		[CommissionPercent] = INCOME_ONLY.IO_COMM_PCT,
		[MarkupAmount] = INCOME_ONLY.EXT_MARKUP_AMT,
		[LineTotal] = INCOME_ONLY.LINE_TOTAL,
		[Description] = INCOME_ONLY.IO_DESC,
		[ReferenceNumber] = INCOME_ONLY.IO_INV_NBR,
		[Comment] = INCOME_ONLY.IO_COMMENT,
		[BillingUser] = INCOME_ONLY.BILLING_USER,
		[TaxCode] = INCOME_ONLY.TAX_CODE, 
		[TaxStatePercent] = INCOME_ONLY.TAX_STATE_PCT, 
		[TaxCountyPercent] = INCOME_ONLY.TAX_COUNTY_PCT, 
		[TaxCityPercent] = INCOME_ONLY.TAX_CITY_PCT,
		[TaxCommission] = INCOME_ONLY.TAX_COMM, 
		[TaxCommissionOnly] = INCOME_ONLY.TAX_COMM_ONLY,
		[CityTaxAmount] = INCOME_ONLY.EXT_CITY_RESALE,
		[CountyTaxAmount] = INCOME_ONLY.EXT_COUNTY_RESALE,
		[StateTaxAmount] = INCOME_ONLY.EXT_STATE_RESALE,
		[TaxResale] = INCOME_ONLY.TAX_RESALE,
		[IsServiceFee] = CONVERT(BIT, ISNULL(INCOME_ONLY.FEE_INVOICE, 0)),
		[IsBilled] = CONVERT(BIT, CASE WHEN INCOME_ONLY.AR_INV_NBR IS NULL THEN 0 ELSE 1 END),
		[NonBillable] = CONVERT(BIT, ISNULL(INCOME_ONLY.NON_BILL_FLAG, 0)),
		[SalesClassCode] = JOB_LOG.SC_CODE,
		[DepartmentTeamCode] = INCOME_ONLY.DP_TM_CODE,
		[IsDeleted] = CONVERT(BIT, ISNULL(INCOME_ONLY.DELETE_FLAG, 0)),
		[JobServiceFeeID] = INCOME_ONLY.JOB_SERVICE_FEE_ID,
		[EverBilled] = CONVERT(BIT, CASE WHEN BILLED_INCOME_ONLY.IO_ID IS NOT NULL THEN 1 ELSE 0 END)
	FROM
		dbo.INCOME_ONLY JOIN
		(SELECT
 			INCOME_ONLY.IO_ID,
 			INCOME_ONLY.SEQ_NBR
		 FROM
 			dbo.INCOME_ONLY
		 WHERE
 			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0 AND
 			ISNULL(INCOME_ONLY.MODIFY_FLAG, 0) = 0
		 UNION
		 SELECT
 			INCOME_ONLY.IO_ID,
 			INCOME_ONLY.SEQ_NBR
		 FROM
 			dbo.INCOME_ONLY JOIN
 			(SELECT
  				[IO_ID] = INCOME_ONLY.IO_ID,
  				[SEQ_NBR] = MAX(INCOME_ONLY.SEQ_NBR)
 			 FROM
  				dbo.INCOME_ONLY
 			 GROUP BY
  				INCOME_ONLY.IO_ID) IO_MAX ON INCOME_ONLY.IO_ID = IO_MAX.IO_ID AND
 											   INCOME_ONLY.SEQ_NBR = IO_MAX.SEQ_NBR
		 WHERE
 			ISNULL(INCOME_ONLY.MODIFY_FLAG, 0) = 1 AND
			INCOME_ONLY.IS_BILLED_REVERSAL = 1 AND
 			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0) IO_CURRENT ON INCOME_ONLY.IO_ID = IO_CURRENT.IO_ID AND
																  INCOME_ONLY.SEQ_NBR = IO_CURRENT.SEQ_NBR LEFT OUTER JOIN
		(SELECT
			INCOME_ONLY.IO_ID
		 FROM
			dbo.INCOME_ONLY
		 WHERE 
			INCOME_ONLY.AR_INV_NBR IS NOT NULL
		 GROUP BY
			INCOME_ONLY.IO_ID) BILLED_INCOME_ONLY ON INCOME_ONLY.IO_ID = BILLED_INCOME_ONLY.IO_ID JOIN
		dbo.JOB_COMPONENT ON INCOME_ONLY.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND
							 INCOME_ONLY.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR JOIN
		dbo.JOB_LOG ON INCOME_ONLY.JOB_NUMBER = JOB_LOG.JOB_NUMBER JOIN
		dbo.CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE JOIN
		dbo.DIVISION ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND
						JOB_LOG.DIV_CODE = DIVISION.DIV_CODE JOIN
		dbo.PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND
					   JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND
					   JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE JOIN
		dbo.FUNCTIONS ON INCOME_ONLY.FNC_CODE = FUNCTIONS.FNC_CODE
WHERE	(1=1)
	AND (IO_INV_DATE <= @io_date_cutoff)
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND INCOME_ONLY.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
AND		(
		(NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0)
		OR
		(NON_BILL_FLAG = 1 AND @include_non_billable_ap_io_detail = 1)
		)
AND		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JOB_COMPONENT_NBR)

IF @debug = 1
	SELECT GETDATE() 'AFTER @income_only'


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
	[UnbilledMarkupPercent] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN COALESCE(IO_COMM_PCT, 0) ELSE 0 END,
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
	[UnbilledAdvanceNetAmount] = 0,
	[UnbilledAdvanceMarkupAmount] = 0,
	[UnbilledAdvanceAmount] = 0,
	[UnbilledAdvanceResaleTax] = 0,
	[UnbilledAdvanceTotal] = 0,
	[FlatIncomeRecognized] = 0,
	[FeeTimeHours] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[DetailBillHold] = COALESCE(BILL_HOLD_FLAG, 0),
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN COALESCE(AB_FLAG, 0) <> 2 AND COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN 
						(COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) ELSE 0 END,
	[UnbilledNetOnly] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 AND COALESCE(BILL_HOLD_FLAG, 0) = 0 AND AR_INV_NBR IS NULL THEN (COALESCE(LINE_TOTAL, 0) - COALESCE(EXT_STATE_RESALE, 0) - COALESCE(EXT_COUNTY_RESALE, 0) - COALESCE(EXT_CITY_RESALE, 0)) - COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ItemBillingTransferFromJob] = XFER_FROM_JOB,
	[ItemBillingTransferFromJobComponent] = XFER_FROM_JOB_COMP,
	[ItemBillingTransferFromFunctionCode] = XFER_FROM_FNC,
	[ItemBillingTransferToJob] = CASE WHEN XFER_FROM_JOB IS NOT NULL THEN IOnly.JOB_NUMBER END,
	[ItemBillingTransferToJobComponent] = CASE WHEN XFER_FROM_JOB_COMP IS NOT NULL THEN IOnly.JOB_COMPONENT_NBR END,
	[ItemBillingTransferToFunctionCode] = CASE WHEN XFER_FROM_FNC IS NOT NULL THEN IOnly.FNC_CODE END,
	[ItemBillingAdjustmentWriteOffFlag] = 0,
	[ItemBillingTransferAdjustmentUser] = XFER_ADJ_USER,
	[ItemBillingTransferAdjustmentDate] = XFER_ADJ_DATE,
	[ItemBillingTransferAdjustmentComment] = ADJ_COMMENTS,
	[ItemID] = IO_ID,
	[ItemDate] = IO_INV_DATE,
	[ItemPostPeriodCode] = NULL,
	[ItemCode] = NULL,
	[ItemDescription] = IO_DESC,
	[ItemComment] = CASE WHEN @populate_io_comments = 1 THEN IOnly.IO_COMMENT ELSE NULL END,
	[ItemFeeFlag] = NULL,
	[ItemBillable] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 1 THEN 0 ELSE 1 END,
	[ItemApprovalAmount] = BA.APPROVED_AMT,
	[ItemInvoiceNumber] = IOnly.IO_INV_NBR,
	[GrossIncome] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(IO_AMOUNT, 0) + COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	AR_INV_NBR,
	[AdvanceBillingRetained] = 0
FROM @income_only IOO
	INNER JOIN dbo.INCOME_ONLY IOnly ON IOO.ID = IOnly.IO_ID AND IOO.SequenceNumber = IOnly.SEQ_NBR 
	LEFT OUTER JOIN (SELECT D.JOB_NUMBER, D.JOB_COMPONENT_NBR, D.FNC_CODE, D.BA_ID, I.REC_ID, I.APPROVED_AMT, I.REC_DTL_ID 
					 FROM dbo.BILL_APPR_DTL D 
						INNER JOIN dbo.BILL_APPR_ITEM I ON D.BA_DTL_ID = I.BA_DTL_ID 
						INNER JOIN @JOBCOMPONENTS JC ON D.JOB_NUMBER = JC.JOB_NUMBER AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR AND D.BA_ID = JC.SELECTED_BA_ID 
					 WHERE I.REC_TYPE = 'I'
					) BA ON BA.JOB_NUMBER = IOnly.JOB_NUMBER AND BA.JOB_COMPONENT_NBR = IOnly.JOB_COMPONENT_NBR AND BA.FNC_CODE = IOnly.FNC_CODE AND BA.REC_ID = IOnly.IO_ID AND BA.REC_DTL_ID = IOnly.SEQ_NBR
WHERE	(1=1)
	AND (IO_INV_DATE <= @io_date_cutoff)
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND IOnly.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
AND		((@prod_lock_selection = 1 AND IOnly.BCC_ID = @BillingCommandCenterID) OR @prod_lock_selection = 0)
AND		(
		(NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0)
		OR
		(NON_BILL_FLAG = 1 AND @include_non_billable_ap_io_detail = 1)
		)
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
    [UnbilledMarkupPercent] = 0,
	[UnbilledMarkupAmount] = 0,
	[UnbilledResaleTax] = 0,
	[UnbilledTotal] = 0,
	[NonBillableHours] = 0,
	[NonBillableQuantity] = 0,
	[NonBillableNetAmount] = 0,
	[NonBillableMarkupAmount] = 0,
	[BillHoldAmount] = 0,
	[AdvanceHours] = CASE WHEN FNC_TYPE = 'E' THEN QTY_HOURS ELSE NULL END,
	[AdvanceQuantity] = CASE WHEN FNC_TYPE <> 'E' THEN QTY_HOURS ELSE NULL END,
	[AdvanceBilledNetAmount] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[AdvanceBilledMarkupAmount] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[AdvanceBilledAmount] = CASE WHEN AR_INV_NBR IS NOT NULL AND AB_FLAG <> 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[AdvanceBilledResaleTax] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[AdvanceBilledTotal] = CASE WHEN AR_INV_NBR IS NOT NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[UnbilledAdvanceNetAmount] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledAdvanceMarkupAmount] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[UnbilledAdvanceAmount] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledAdvanceResaleTax] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(EXT_STATE_RESALE, 0) + COALESCE(EXT_COUNTY_RESALE, 0) + COALESCE(EXT_CITY_RESALE, 0) ELSE 0 END,
	[UnbilledAdvanceTotal] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(LINE_TOTAL, 0) ELSE 0 END,
	[FlatIncomeRecognized] = 0,
	[FeeTimeHours] = 0,
	[FeeAmount] = 0,
	[FeeResaleTax] = 0,
	[FeeTotal] = 0,
	[DetailBillHold] = 0,
	[FlatIncomeToRecognize] = 0,
	[AmountToBill] = CASE WHEN AR_INV_NBR IS NULL THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[UnbilledNetOnly] = 0,
	[ItemBillingTransferFromJob] = NULL,
	[ItemBillingTransferFromJobComponent] = NULL,
	[ItemBillingTransferFromFunctionCode] = NULL,
	[ItemBillingTransferToJob] = NULL,
	[ItemBillingTransferToJobComponent] = NULL,
	[ItemBillingTransferToFunctionCode] = NULL,
	[ItemBillingAdjustmentWriteOffFlag] = NULL,
	[ItemBillingTransferAdjustmentUser] = NULL,
	[ItemBillingTransferAdjustmentDate] = NULL,
	[ItemBillingTransferAdjustmentComment] = NULL,
	[ItemID] = NULL,
	[ItemDate] = NULL,
	[ItemPostPeriodCode] = NULL,
	[ItemCode] = NULL,
	[ItemDescription] = NULL,
	[ItemComment] = NULL,
	[ItemFeeFlag] = NULL,
	[ItemBillable] = 1,
	[ItemApprovalAmount] = NULL,
	[ItemInvoiceNumber] = NULL,
	[GrossIncome] = 0,
	AR_INV_NBR,
	[AdvanceBillingRetained] = CASE WHEN AR_INV_NBR IS NOT NULL AND AB_FLAG = 5 THEN COALESCE(ADV_BILL_NET_AMT, 0) + COALESCE(EXT_MARKUP_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END
FROM dbo.ADVANCE_BILLING AB
WHERE		EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = AB.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = AB.JOB_COMPONENT_NBR)
AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND AB.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))

IF @debug = 1
BEGIN
	SELECT GETDATE() 'AFTER AB @SUBTOTALS'
	--SELECT * INTO ##SUBTOTALS FROM @SUBTOTALS
END

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
	WHERE (1=1)
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND BAD.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
	IF @debug = 1
		SELECT GETDATE() 'AFTER @JOBCOMPONENTFUNCTIONS'

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
			[BillingCoopDescription] = BC.BILL_COOP_DESC,
			[AccountExecutive] = AE.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(AE.EMP_MI, '') + ' ') + AE.EMP_LNAME,
			JOBS.RECONCILE_STATUS,
			[AECode] = AE.EMP_CODE,
			[AEFirstName] = AE.EMP_FNAME ,
			[AELastName] = AE.EMP_LNAME,
			[JobMediaDateToBill] = JC.MEDIA_BILL_DATE,
			[BillingCommandCenterID] = JC.BCC_ID,
			[EstimateNumber],
			[EstimateDescription],
			[EstimateComponentNumber],
			[EstimateComponentDescription],
			[BillingApprovalBatchID] = JOBS.BA_BATCH_ID,
			[BillingApprovalBatchDescription] = JOBS.BA_BATCH_DESC
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
		INNER JOIN dbo.EMPLOYEE_CLOAK AE ON JC.EMP_CODE = AE.EMP_CODE
		LEFT OUTER JOIN dbo.SALES_CLASS SC ON JL.SC_CODE = SC.SC_CODE
		LEFT OUTER JOIN (SELECT
							[FunctionCode],
							[JobNumber],
							[JobComponentNumber],
							[EstimateNumber],
							[EstimateDescription],
							[EstimateComponentNumber],
							[EstimateComponentDescription],
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
									[EstimateNumber] = EA.ESTIMATE_NUMBER,
									[EstimateDescription] = EL.EST_LOG_DESC,
									[EstimateComponentNumber] = EA.EST_COMPONENT_NBR,
									[EstimateComponentDescription] = EC.EST_COMP_DESC,
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
									INNER JOIN dbo.ESTIMATE_COMPONENT EC ON EA.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND EA.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR
									INNER JOIN dbo.ESTIMATE_LOG EL ON EA.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER
								WHERE EXISTS (SELECT 1 FROM @JOBCOMPONENTS JC WHERE JC.JOB_NUMBER = EA.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = EA.JOB_COMPONENT_NBR)) estdetails
						GROUP BY
							[FunctionCode],
							[JobNumber],
							[JobComponentNumber],
							[EstimateNumber],
							[EstimateDescription],
							[EstimateComponentNumber],
							[EstimateComponentDescription]) est ON est.JobNumber = JCF.JobNumber AND est.JobComponentNumber = JCF.ComponentNumber AND est.FunctionCode = JCF.FunctionCode
		LEFT OUTER JOIN dbo.FUNCTIONS F ON JCF.FunctionCode = F.FNC_CODE 
		LEFT OUTER JOIN dbo.FNC_HEADING FH ON F.FNC_HEADING_ID = FH.FNC_HEADING_ID
		LEFT OUTER JOIN dbo.BILL_APPR_HDR BAH ON BAH.BA_ID = JOBS.SELECTED_BA_ID AND BAH.JOB_NUMBER = JC.JOB_NUMBER AND BAH.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN dbo.FUNCTIONS FC ON F.FNC_CONSOLIDATION = FC.FNC_CODE
		LEFT OUTER JOIN (
						SELECT DISTINCT BILL_COOP_CODE, BILL_COOP_DESC
						FROM dbo.BILLING_COOP
						) BC ON JL.BILL_COOP_CODE = BC.BILL_COOP_CODE
		WHERE (1=1)
		AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND JL.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))

	IF @debug = 1
		SELECT GETDATE() 'AFTER @FUNCTIONRESULTS'

--SELECT * FROM @FUNCTIONRESULTS ORDER BY JobNumber, ComponentNumber
--SELECT * FROM @SUBTOTALS ORDER BY JobNumber, ComponentNumber
	
	SELECT
		[ID] = NewID(),
		[BillStatus] = CASE WHEN COALESCE(R.[JobBillHold], 0) = 1 THEN 'Job on Temporary Bill Hold'
							WHEN COALESCE(R.[JobBillHold], 0) = 2 THEN 'Job on Permanent Bill Hold'
							--WHEN COALESCE(Det.[DetailBillHold], 0) > 0 THEN 'Job Details on Hold'
							WHEN EXISTS (
										SELECT 1
										FROM @SUBTOTALS st
										WHERE R.JobNumber = st.JobNumber 
										AND R.ComponentNumber = st.ComponentNumber 
										AND R.FunctionCode = st.FunctionCode
										AND COALESCE(st.[DetailBillHold], 0) > 0
										) THEN 'Job Details on Hold'
							WHEN R.[ABFlag] = 2 AND EXISTS(
															SELECT 1 
															FROM dbo.ADVANCE_BILLING ab
															WHERE ab.JOB_NUMBER = R.[JobNumber]
															AND ab.JOB_COMPONENT_NBR = R.[ComponentNumber]
															AND ( ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0 )
															AND ab.FINAL_AB_ID IS NOT NULL
														) THEN 'Final Reconciled w/Pending Advance Bill'
							WHEN R.RECONCILE_STATUS <> 0 THEN 'Reconciled'
							WHEN R.[ABFlag] IS NOT NULL AND R.[ABFlag] <> 0 THEN 'Advance Bill'
							ELSE 'Progress Bill' END,
		R.[ClientCode],
		R.[ClientName],
		R.[DivisionCode],
		R.[DivisionName],
		R.[ProductCode],
		R.[ProductDescription],
		R.[JobNumber],
		R.[JobDescription],
		R.[ComponentNumber],
		R.[ComponentDescription],
		R.[OfficeCode],
		R.[OfficeDescription],
		R.[CampaignID],
		R.[CampaignCode],
		R.[CampaignDescription],
		R.[SalesClassCode],
		R.[SalesClassDescription],
		R.[ClientPO],
		R.[ClientReference],
		R.[BillingCoopCode],
		R.[BillingCoopDescription],
		R.[ScheduleStatus],
		R.[ScheduleCompletedDate],
		R.[FunctionHeading],
		R.[FunctionCode],
		R.[FunctionDescription],
		R.[FunctionType],
		R.[FunctionOrder],
		R.[AdvanceBillRequested],
		R.BillingUser,
		R.FunctionConsolidationCode,
		R.FunctionConsolidationDescription,
		R.[AccountExecutive],
		R.[AECode],
		R.[AEFirstName],
		R.[AELastName],
		R.[JobMediaDateToBill],
		R.[BillingApprovalBatchID],
		R.[BillingApprovalBatchDescription],
		R.[BillingApprovalHeaderComment],
		R.[BillingApprovalHeaderClientComment],
		R.[EstimateNumber],
		R.[EstimateDescription],
		R.[EstimateComponentNumber],
		R.[EstimateComponentDescription],

		COALESCE(R.EstimateHours, 0) AS EstimateHours,
		COALESCE(R.EstimateQuantity, 0) AS EstimateQuantity,
		COALESCE(R.EstimateNetAmount, 0) AS EstimateNetAmount,
		COALESCE(R.EstimateMarkupAmount, 0) AS EstimateMarkupAmount,
		COALESCE(R.EstimateAmount, 0) AS EstimateAmount,
		COALESCE(R.EstimateResaleTax, 0) AS EstimateResaleTax,
		COALESCE(R.EstimateTotal, 0) AS EstimateTotal,

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
        S.UnbilledMarkupPercent,
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
		S.UnbilledAdvanceNetAmount,
		S.UnbilledAdvanceMarkupAmount,
		S.UnbilledAdvanceAmount,
		S.UnbilledAdvanceResaleTax,
		S.UnbilledAdvanceTotal,
		S.FlatIncomeRecognized,
		S.NonBillableHours,
		S.NonBillableQuantity,
		S.NonBillableNetAmount,
		S.NonBillableMarkupAmount,
		S.NonBillableAmount,
		S.FeeTimeHours,
		S.FeeAmount,
		S.FeeResaleTax,
		S.FeeTotal,
		S.BillHoldAmount,
		S.FlatIncomeToRecognize,
		S.UnbilledNetOnly,
		S.[GrossIncome],

		[BilledOfEstimate] = CASE WHEN COALESCE(R.EstimateAmount, 0) <> 0 THEN (COALESCE(S.BilledAmount, 0) + COALESCE(S.AdvanceBilledAmount, 0)) / COALESCE(R.EstimateAmount, 0) * 100 ELSE 0 END,
		[AmountToBill] = COALESCE(S.AmountToBill, 0),
		[PercentCompleteTime] = CASE WHEN R.[FunctionType] = 'E' AND (COALESCE(R.EstimateNetAmount, 0) + COALESCE(R.EstimateMarkupAmount, 0)) <> 0 THEN
										(COALESCE(S.ActualBillableNetAmount,0) + COALESCE(S.ActualBillableMarkupAmount,0) + COALESCE(S.FeeAmount,0)) / (COALESCE(R.EstimateNetAmount, 0) + COALESCE(R.EstimateMarkupAmount, 0)) * 100
									 ELSE NULL END,
		[PercentCompleteAll] = CASE WHEN (COALESCE(R.EstimateNetAmount, 0) + COALESCE(R.EstimateMarkupAmount, 0)) <> 0 THEN 
										(COALESCE(S.ActualBillableNetAmount,0) + COALESCE(S.ActualBillableMarkupAmount,0) + COALESCE(S.FeeAmount,0)) / (COALESCE(R.EstimateNetAmount, 0) + COALESCE(R.EstimateMarkupAmount, 0)) * 100
									ELSE NULL END,
		
		PO.OpenPOAmount,
		
		[BillingApprovalFunctionAmount] = BAD.ApprovedAmount,
		[BillingApprovalFunctionComment] = BAD.[BillingApprovalFunctionComment],
		[BillingApprovalFunctionClientComment] = BAD.[BillingApprovalFunctionClientComment],
		BAD.[BillingApprovalDetailID],

		[ItemUnbilledHours] = NULL,
		[ItemUnbilledQuantity] = NULL,
		[ItemUnbilledNetAmount] = NULL,
		[ItemUnbilledMarkupAmount] = NULL,
		[ItemUnbilledResaleTax] = NULL,
		[ItemUnbilledTotal] = NULL,
		[ItemNonBillableHours] = NULL,
		[ItemNonBillableQuantity] = NULL,
		[ItemNonBillableMarkupAmount] = NULL,
		[ItemNonBillableNetAmount] = NULL,
		[ItemNonBillableTotalAmount] = NULL,
		[ItemBillingTransferFromJob] = NULL,
		[ItemBillingTransferFromJobComponent] = NULL,
		[ItemBillingTransferFromFunctionCode] = NULL,
		[ItemBillingTransferToJob] = NULL,
		[ItemBillingTransferToJobComponent] = NULL,
		[ItemBillingTransferToFunctionCode] = NULL,
		[ItemBillingAdjustmentWriteOffFlag] = CAST(0 as bit),
		[ItemBillingTransferAdjustmentUser] = NULL,
		[ItemBillingTransferAdjustmentDate] = NULL,
		[ItemBillingTransferAdjustmentComment] = NULL,
		[ItemID] = NULL,
		[ItemDate] = NULL,
		[ItemPostPeriodCode] = NULL,
		[ItemCode] = NULL,
		[ItemDescription] = NULL,
		[ItemComment] = NULL,
		[ItemFeeFlag] = NULL,
		[ItemBillable] = CAST(0 as bit),
		[ItemApprovalAmount] = NULL,
		[ItemInvoiceNumber] = NULL,
		IsDetail = 0,
		BillingBatchName = BCC.BATCH_NAME,
		S.AdvanceBillingRetained,
        R.ProcessControlDescription
	FROM @FUNCTIONRESULTS R
		LEFT OUTER JOIN dbo.BILLING_CMD_CENTER BCC ON R.BillingCommandCenterID = BCC.BCC_ID
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
                            [UnbilledMarkupPercent] = SUM([UnbilledMarkupPercent]),
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
							[UnbilledAdvanceNetAmount] = SUM([UnbilledAdvanceNetAmount]),
							[UnbilledAdvanceMarkupAmount] = SUM([UnbilledAdvanceMarkupAmount]),
							[UnbilledAdvanceAmount] = SUM([UnbilledAdvanceAmount]),
							[UnbilledAdvanceResaleTax] = SUM([UnbilledAdvanceResaleTax]),
							[UnbilledAdvanceTotal] = SUM([UnbilledAdvanceTotal]),
							[NonBillableHours] = SUM([NonBillableHours]),
							[NonBillableQuantity] = SUM([NonBillableQuantity]),
							[NonBillableNetAmount] = SUM([NonBillableNetAmount]),
							[NonBillableMarkupAmount] = SUM([NonBillableMarkupAmount]),
							[NonBillableAmount] = SUM([NonBillableNetAmount]) + SUM([NonBillableMarkupAmount]),
							[BillHoldAmount] = SUM([BillHoldAmount]),
							[FeeTimeHours] = SUM([FeeTimeHours]),
							[FeeAmount] = SUM([FeeAmount]),
							[FeeResaleTax] = SUM([FeeResaleTax]),
							[FeeTotal] = SUM([FeeTotal]),
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
	WHERE	(
			(R.FunctionCode IS NOT NULL AND @job_option <> 3)
	OR		
			@job_option = 3
			)
	AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ClientCode IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode + '|' + ProductCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND		(@AECodeList IS NULL OR (@AECodeList IS NOT NULL AND AECode IN (SELECT * from dbo.udf_split_list(@AECodeList, ','))))
	AND		(@BillingCommandCenterID IS NULL OR (@BillingCommandCenterID IS NOT NULL AND BillingCommandCenterID = @BillingCommandCenterID))
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND R.JobNumber IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))

	UNION
	
	SELECT
		[ID] = NewID(),
		[BillStatus] = CASE WHEN COALESCE(R.[JobBillHold], 0) = 1 THEN 'Job on Temporary Bill Hold'
							WHEN COALESCE(R.[JobBillHold], 0) = 2 THEN 'Job on Permanent Bill Hold'
							--WHEN COALESCE(Det.[DetailBillHold], 0) > 0 THEN 'Job Details on Hold'
							WHEN EXISTS (
										SELECT 1
										FROM @SUBTOTALS st
										WHERE R.JobNumber = st.JobNumber 
										AND R.ComponentNumber = st.ComponentNumber 
										AND R.FunctionCode = st.FunctionCode
										AND COALESCE(st.[DetailBillHold], 0) > 0
										) THEN 'Job Details on Hold'
							WHEN R.[ABFlag] = 2 AND EXISTS(
															SELECT 1 
															FROM dbo.ADVANCE_BILLING ab
															WHERE ab.JOB_NUMBER = R.[JobNumber]
															AND ab.JOB_COMPONENT_NBR = R.[ComponentNumber]
															AND ( ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0 )
															AND ab.FINAL_AB_ID IS NOT NULL
														) THEN 'Final Reconciled w/Pending Advance Bill'
							WHEN R.RECONCILE_STATUS <> 0 THEN 'Reconciled'
							WHEN R.[ABFlag] IS NOT NULL AND R.[ABFlag] <> 0 THEN 'Advance Bill'
							ELSE 'Progress Bill' END,
		R.[ClientCode],
		R.[ClientName],
		R.[DivisionCode],
		R.[DivisionName],
		R.[ProductCode],
		R.[ProductDescription],
		R.[JobNumber],
		R.[JobDescription],
		R.[ComponentNumber],
		R.[ComponentDescription],
		R.[OfficeCode],
		R.[OfficeDescription],
		R.[CampaignID],
		R.[CampaignCode],
		R.[CampaignDescription],
		R.[SalesClassCode],
		R.[SalesClassDescription],
		R.[ClientPO],
		R.[ClientReference],
		R.[BillingCoopCode],
		R.[BillingCoopDescription],
		R.[ScheduleStatus],
		R.[ScheduleCompletedDate],
		R.[FunctionHeading],
		R.[FunctionCode],
		R.[FunctionDescription],
		R.[FunctionType],
		R.[FunctionOrder],
		R.[AdvanceBillRequested],
		R.BillingUser,
		R.FunctionConsolidationCode,
		R.FunctionConsolidationDescription,
		R.[AccountExecutive],
		R.[AECode],
		R.[AEFirstName],
		R.[AELastName],
		R.[JobMediaDateToBill],
		R.[BillingApprovalBatchID],
		R.[BillingApprovalBatchDescription],
		R.[BillingApprovalHeaderComment],
		R.[BillingApprovalHeaderClientComment],
		R.[EstimateNumber],
		R.[EstimateDescription],
		R.[EstimateComponentNumber],
		R.[EstimateComponentDescription],

		0, 0, 0, 0, 0, 0, 0,

		NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,
		NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,

		0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL,

		[ItemUnbilledHours] = Det.UnbilledHours,
		[ItemUnbilledQuantity] = Det.UnbilledQuantity,
		[ItemUnbilledNetAmount] = Det.UnbilledNetAmount,
		[ItemUnbilledMarkupAmount] = Det.UnbilledMarkupAmount,
		[ItemUnbilledResaleTax] = Det.UnbilledResaleTax,
		[ItemUnbilledTotal] = Det.UnbilledTotal,
		[ItemNonBillableHours] = COALESCE(Det.NonBillableHours, 0) + COALESCE(Det.FeeTimeHours, 0),
		[ItemNonBillableQuantity] = Det.NonBillableQuantity,
		[ItemNonBillableMarkupAmount] = Det.NonBillableMarkupAmount,
		[ItemNonBillableNetAmount] = COALESCE(Det.NonBillableNetAmount, 0) + COALESCE(Det.FeeAmount, 0),
		[ItemNonBillableTotalAmount] = COALESCE(Det.NonBillableNetAmount, 0) + COALESCE(Det.NonBillableMarkupAmount, 0) + COALESCE(Det.FeeTotal, 0),

		Det.[ItemBillingTransferFromJob],
		Det.[ItemBillingTransferFromJobComponent],
		Det.[ItemBillingTransferFromFunctionCode],
		Det.[ItemBillingTransferToJob],
		Det.[ItemBillingTransferToJobComponent],
		Det.[ItemBillingTransferToFunctionCode],
		[ItemBillingAdjustmentWriteOffFlag] = CAST(COALESCE(Det.[ItemBillingAdjustmentWriteOffFlag], 0) as bit),
		Det.[ItemBillingTransferAdjustmentUser],
		Det.[ItemBillingTransferAdjustmentDate],
		Det.[ItemBillingTransferAdjustmentComment],
		Det.[ItemID],
		Det.[ItemDate],
		Det.[ItemPostPeriodCode],
		Det.[ItemCode],
		Det.[ItemDescription],
		Det.[ItemComment],
		Det.[ItemFeeFlag],
		Det.[ItemBillable],
		Det.[ItemApprovalAmount],
		Det.[ItemInvoiceNumber],
		IsDetail = 1,
		BillingBatchName = BCC.BATCH_NAME,
		[AdvanceBillingRetained] = NULL,
        R.ProcessControlDescription
	FROM @FUNCTIONRESULTS R
		LEFT OUTER JOIN dbo.BILLING_CMD_CENTER BCC ON R.BillingCommandCenterID = BCC.BCC_ID
		INNER JOIN @SUBTOTALS Det ON R.JobNumber = Det.JobNumber AND R.ComponentNumber = Det.ComponentNumber AND R.FunctionCode = Det.FunctionCode 
											AND @print_item_detail = 1 AND Det.ItemID IS NOT NULL
	WHERE (Det.AR_INV_NBR IS NULL 
	OR		Det.ItemBillable = 0)
	AND		(@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND ClientCode IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
	AND		(@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
	AND		(@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND ClientCode + '|' + DivisionCode + '|' + ProductCode IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
	AND		(@AECodeList IS NULL OR (@AECodeList IS NOT NULL AND AECode IN (SELECT * from dbo.udf_split_list(@AECodeList, ','))))
	AND		(@BillingCommandCenterID IS NULL OR (@BillingCommandCenterID IS NOT NULL AND BillingCommandCenterID = @BillingCommandCenterID))
	AND		(@SelectedJobList IS NULL OR (@SelectedJobList IS NOT NULL AND R.JobNumber IN (SELECT * FROM dbo.udf_split_list(@SelectedJobList, ','))))
	ORDER BY IsDetail, R.ClientCode, R.DivisionCode, R.ProductCode, R.JobNumber, R.ComponentNumber, R.FunctionType, ItemDate, ItemDescription
	OPTION (RECOMPILE)
	
IF @debug = 1
	SELECT GETDATE() 'END'

END

GO


