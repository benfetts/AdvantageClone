CREATE PROC advsp_bcc_job_details_get_vendor_ap
	@JobNumber int, @JobComponentNumber smallint, @APPostPeriodCodeCutoff varchar(6), @FunctionCodeList varchar(max),
	@SelectMode smallint, -- 1: Transfer, 2: Reconcile, 3: JobDetailGrid
	@ProductionLock bit
AS

SET NOCOUNT ON;

SELECT
	[InvoiceNumber] = APH.AP_INV_VCHR,
	[PostPeriod] = APP.POST_PERIOD,
	[LineNumber] = APP.LINE_NUMBER,
	[VendorName] = V.VN_NAME,
	[InvoiceDate] = APH.AP_INV_DATE,
	[Quantity] = APP.AP_PROD_QUANTITY,
	[Rate] = APP.AP_PROD_RATE,
	[ExtendedAmount] = COALESCE(APP.AP_PROD_EXT_AMT, 0),
	[CommissionPercent] = COALESCE(APP.AP_PROD_COMM_PCT, 0),
	[ExtendedMarkupAmount] = COALESCE(APP.EXT_MARKUP_AMT, 0),
	[SalesTaxCode] = APP.TAX_CODE,
	[IsResaleTax] = APP.TAX_RESALE,
	[TaxCommissions] = APP.TAX_COMMISSIONS,
	[TaxCommissionsOnly] = APP.TAX_COMM_ONLY,
	[StateTaxPercent] = COALESCE(APP.TAX_STATE_PCT, 0),
	[CountyTaxPercent] = COALESCE(APP.TAX_COUNTY_PCT, 0),
	[CityTaxPercent] = COALESCE(APP.TAX_CITY_PCT, 0),
	[ExtendedStateResale] = COALESCE(APP.EXT_STATE_RESALE, 0),
	[ExtendedCountyResale] = COALESCE(APP.EXT_COUNTY_RESALE, 0),
	[ExtendedCityResale] = COALESCE(APP.EXT_CITY_RESALE, 0),
	[ExtendedNonResaleTax] = COALESCE(APP.EXT_NONRESALE_TAX, 0),
	[IsNonBillable] = APP.AP_PROD_NOBILL_FLG,
	[IsBillOnHold] = CASE WHEN APP.AP_PROD_BILL_HOLD <> 0 THEN APP.AP_PROD_BILL_HOLD END,
	[Comment] = APC.AP_COMMENT,
	[HasDocuments] = CAST(CASE WHEN APP.EXPDETAILID IS NOT NULL THEN 1
							   WHEN EXISTS(SELECT 1 FROM dbo.AP_DOCUMENTS WHERE AP_ID = APP.AP_ID) THEN 1
							   ELSE 0 END AS bit),
	[NetApprovedAmount] = BAI.APPROVED_AMT,
	[ApprovalComment] = BAI.ITEM_COMMENTS,
	[Instruction] = CASE BAI.INSTR
						WHEN 1 THEN 'Bill/Reconcile'
						WHEN 2 THEN 'Adjust'
						WHEN 3 THEN 'Transfer'
						WHEN 4 THEN 'Hold'
						END,
	[AccountPayableID] = APP.AP_ID,
	[JobNumber] = APP.JOB_NUMBER,
	[JobComponentNumber] = APP.JOB_COMPONENT_NBR,
	[ExpenseReportDetailID] = APP.EXPDETAILID,
	[FunctionCode] = APP.FNC_CODE,
	[VendorCode] = APH.VN_FRL_EMP_CODE,
	[BillingCommandCenterID] = APP.BCC_ID,
	[FunctionDescription] = F.FNC_DESCRIPTION,
	[ABFlag] = APP.AB_FLAG,
	[WriteOff] = APP.WRITE_OFF,
	[TransferFromJob] = APP.XFER_FROM_JOB,
	[TransferFromJobComponent] = APP.XFER_FROM_JOB_COMP,
	[TransferFromFunctionCode] = APP.XFER_FROM_FNC,
	[AdjustmentTransferUserCode] = APP.XFER_ADJ_USER,
	[AdjustmentTransferDate] = APP.XFER_ADJ_DATE,
	[AdjustmentTransferComment] = APP.ADJ_COMMENTS,
	[ModifyDelete] = CAST(COALESCE(APP.MODIFY_DELETE,0) as bit),
	[IsBilledReversal] = CAST(COALESCE(APP.IS_BILLED_REVERSAL,0) as bit)
FROM
	dbo.AP_PRODUCTION APP
		INNER JOIN dbo.AP_HEADER APH ON APP.AP_ID = APH.AP_ID AND APP.AP_SEQ = APH.AP_SEQ
		INNER JOIN dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE
		INNER JOIN dbo.JOB_COMPONENT JC ON JC.JOB_NUMBER = @JobNumber AND JC.JOB_COMPONENT_NBR = @JobComponentNumber
		LEFT OUTER JOIN dbo.AP_PROD_COMMENTS APC ON APP.AP_ID = APC.AP_ID AND APP.LINE_NUMBER = APC.LINE_NUMBER 
		LEFT OUTER JOIN dbo.BILL_APPR_DTL BAD ON BAD.BA_ID = JC.SELECTED_BA_ID AND APP.FNC_CODE = BAD.FNC_CODE AND BAD.JOB_NUMBER = JC.JOB_NUMBER AND BAD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN dbo.BILL_APPR_ITEM BAI ON BAI.REC_ID = APP.AP_ID AND BAI.REC_TYPE = 'V' AND BAD.BA_DTL_ID = BAI.BA_DTL_ID AND BAI.REC_DTL_ID = APP.LINE_NUMBER
		INNER JOIN dbo.FUNCTIONS F ON APP.FNC_CODE = F.FNC_CODE
WHERE
		APP.JOB_NUMBER = @JobNumber
AND		APP.JOB_COMPONENT_NBR = @JobComponentNumber
AND		((@FunctionCodeList IS NULL) OR APP.FNC_CODE IN (SELECT * FROM dbo.udf_split_list(@FunctionCodeList, '|')))
AND		AR_INV_NBR IS NULL
AND		APP.POST_PERIOD <= @APPostPeriodCodeCutoff
AND		-- 1: Transfer, 2: Reconcile, 3: JobDetailGrid
		(
			(@SelectMode = 1 AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0))
		OR
			(@SelectMode IN( 2, 3 ) AND (APP.IS_BILLED_REVERSAL = 1 OR (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)))
		)
AND		(
			(@SelectMode IN ( 2, 3 ) AND @ProductionLock = 1 AND APP.BCC_ID IS NOT NULL)
		OR
			(@ProductionLock = 0)
		)
ORDER BY APH.AP_INV_DATE, APP.LINE_NUMBER
GO
