CREATE PROC advsp_bcc_job_details_get_employee_time
	@JobNumber int, @JobComponentNumber smallint, @EmployeeTimeDateCutoff smalldatetime, @FunctionCodeList varchar(max),
	@ProductionLock bit
AS

SET NOCOUNT ON;

SELECT
	[EmployeeTimeID] = ETD.ET_ID,
	[EmployeeTimeDetailID] = ETD.ET_DTL_ID,
	[SequenceNumber] = ETD.SEQ_NBR,
	[EmployeeName] = COALESCE((RTRIM(EMP_FNAME) + ' '),'') + COALESCE((EMP_MI + '. '),'') + COALESCE(EMP_LNAME,''),
	[EmployeeDate] = ET.EMP_DATE,
	[Hours] = ETD.EMP_HOURS,
	[BillableRate] = COALESCE(ETD.EMP_BILL_RATE, 0),
	[TotalBill] = COALESCE(ETD.TOTAL_BILL, 0),
	[CommissionPercentage] = COALESCE(ETD.EMP_COMM_PCT, 0),
	[MarkupAmount] = COALESCE(ETD.EXT_MARKUP_AMT, 0),
	[Total] = ETD.LINE_TOTAL,
	[SalesTaxCode] = ETD.TAX_CODE,
	[TaxCommission] = ETD.TAX_COMM,
	[TaxCommissionOnly] = ETD.TAX_COMM_ONLY,
	[SalesTaxStatePercentage] = COALESCE(ETD.TAX_STATE_PCT, 0),
	[SalesTaxCountyPercentage] = COALESCE(ETD.TAX_COUNTY_PCT, 0),
	[SalesTaxCityPercentage] = COALESCE(ETD.TAX_CITY_PCT, 0),
	[StateResaleAmount] = COALESCE(ETD.EXT_STATE_RESALE, 0),
	[CountyResaleAmount] = COALESCE(ETD.EXT_COUNTY_RESALE, 0),
	[CityResaleAmount] = COALESCE(ETD.EXT_CITY_RESALE, 0),
	[IsNonBillable] = ETD.EMP_NON_BILL_FLAG,
	[IsBillOnHold] = CASE WHEN ETD.BILL_HOLD_FLG <> 0 THEN ETD.BILL_HOLD_FLG END, 
	[FeeTimeType] = CAST(COALESCE(ETD.FEE_TIME, 0) AS smallint),
	--[Comment] = CASE WHEN ETDC.EMP_COMMENT IS NOT NULL THEN ETDC.EMP_COMMENT 
    --              ELSE
    --              (SELECT TOP 1 ETDC.EMP_COMMENT
	--			 FROM dbo.EMP_TIME_DTL_CMTS ETDC
	--			 WHERE ETDC.ET_ID = ETD.ET_ID
	--			 AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID
	--			 AND ETDC.ET_SOURCE = 'D')
    --               END,
 	[Comment] = ETDC.EMP_COMMENT,
	[EmployeeCode] = E.EMP_CODE,
	[EmployeeTimeFlag] = CAST(CASE WHEN (ETD.AB_FLAG IS NULL OR (ETD.AB_FLAG <> 3 AND ETD.AB_FLAG <> 6)) AND 
									(ETD.AR_INV_NBR IS NULL OR ETD.AR_INV_NBR = 0) AND
									(ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0) THEN 0
							  ELSE 1
							  END AS smallint),
	[JobNumber] = ETD.JOB_NUMBER,
	[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
	[FunctionCode] = ETD.FNC_CODE,
	[NetApprovedAmount] = BAI.APPROVED_AMT,
	[ApprovalComment] = BAI.ITEM_COMMENTS,
	[Instruction] = CASE BAI.INSTR
						WHEN 1 THEN 'Bill/Reconcile'
						WHEN 2 THEN 'Adjust'
						WHEN 3 THEN 'Transfer'
						WHEN 4 THEN 'Hold'
						END,
	[BillingCommandCenterID] = ETD.BCC_ID,
	[EmployeeRateFrom] = ETD.EMP_RATE_FROM,
	[FunctionDescription] = F.FNC_DESCRIPTION,
	[ABFlag] = ETD.AB_FLAG,
	[TransferFromJob] = ETD.XFER_FROM_JOB,
	[TransferFromJobComponent] = ETD.XFER_FROM_JOB_COMP,
	[TransferFromFunctionCode] = ETD.XFER_FROM_FNC,
	[AdjustmentTransferUserCode] = ETD.XFER_ADJ_USER,
	[AdjustmentTransferDate] = ETD.XFER_ADJ_DATE,
	[AdjustmentTransferComment] = ETD.ADJ_COMMENTS,
	[TaskCode] = ETD.TRF_CODE
FROM
	dbo.EMP_TIME_DTL ETD
		INNER JOIN dbo.EMP_TIME ET ON ETD.ET_ID = ET.ET_ID AND ET.EMP_DATE <= @EmployeeTimeDateCutoff
		INNER JOIN dbo.EMPLOYEE_CLOAK E ON ET.EMP_CODE = E.EMP_CODE 
		INNER JOIN dbo.JOB_COMPONENT JC ON JC.JOB_NUMBER = @JobNumber AND JC.JOB_COMPONENT_NBR = @JobComponentNumber
		LEFT OUTER JOIN dbo.BILL_APPR_DTL BAD ON BAD.BA_ID = JC.SELECTED_BA_ID AND ETD.FNC_CODE = BAD.FNC_CODE AND BAD.JOB_NUMBER = JC.JOB_NUMBER AND BAD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN dbo.BILL_APPR_ITEM BAI ON BAI.REC_ID = ETD.ET_ID AND BAI.REC_TYPE = 'E' AND BAD.BA_DTL_ID = BAI.BA_DTL_ID AND BAI.REC_DTL_ID = ETD.ET_DTL_ID
		INNER JOIN dbo.FUNCTIONS F ON ETD.FNC_CODE = F.FNC_CODE
        LEFT OUTER JOIN dbo.EMP_TIME_DTL_CMTS ETDC ON ETDC.ET_ID = ETD.ET_ID AND ETDC.ET_DTL_ID = ETD.ET_DTL_ID AND ETDC.SEQ_NBR = ETD.SEQ_NBR AND ETDC.ET_SOURCE = 'D'
WHERE	ETD.JOB_NUMBER = @JobNumber
AND		ETD.JOB_COMPONENT_NBR = @JobComponentNumber
AND		((@FunctionCodeList IS NULL) OR ETD.FNC_CODE IN (SELECT * FROM dbo.udf_split_list(@FunctionCodeList, '|')))
AND		ETD.AR_INV_NBR IS NULL
AND		(ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0)
AND		ETD.EMP_HOURS <> 0
AND		(
			(@ProductionLock = 1 AND ETD.BCC_ID IS NOT NULL)
		OR
			(@ProductionLock = 0)
		)
ORDER BY 5, 4
GO
