CREATE PROC advsp_bcc_job_details_get_income_only
	@JobNumber int, @JobComponentNumber smallint, @IncomeOnlyDateCutoff smalldatetime, @FunctionCodeList varchar(max),
	@ProductionLock bit,
	@SelectMode smallint -- 1: Transfer, 2: Reconcile, 3: JobDetailGrid
AS

SET NOCOUNT ON;

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
 			ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0
		 UNION
		 SELECT
 			INCOME_ONLY.IO_ID,
 			INCOME_ONLY.SEQ_NBR
		 FROM
 			dbo.INCOME_ONLY
		 WHERE
 			@SelectMode IN (2, 3)
		 --AND ISNULL(INCOME_ONLY.MODIFY_FLAG, 0) = 1
		 AND INCOME_ONLY.IS_BILLED_REVERSAL = 1
		 --AND ISNULL(INCOME_ONLY.DELETE_FLAG, 0) = 0
		) IO_CURRENT ON INCOME_ONLY.IO_ID = IO_CURRENT.IO_ID AND
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
WHERE
		dbo.JOB_COMPONENT.JOB_NUMBER = @JobNumber
AND		dbo.JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComponentNumber

SELECT
	[InvoiceNumber] = COALESCE(NULLIF(I.[ReferenceNumber],''), CAST(IOnly.IO_ID as varchar(26))),
	[SequenceNumber] = I.[SequenceNumber],
	[InvoiceDate] = I.[InvoiceDate],
	[Quantity]= CASE WHEN I.[Quantity] = 0 THEN NULL
				ELSE I.[Quantity] END,
	[Rate] = CASE WHEN I.[Rate] = 0 THEN NULL
			 ELSE I.[Rate] END,
	[Amount] = COALESCE(I.[Amount], 0),
	[CommissionPercent] = COALESCE(I.[CommissionPercent], 0),
	[MarkupAmount] = COALESCE(I.[MarkupAmount], 0),
	[Total]= COALESCE(I.[LineTotal], 0),
	[SalesTaxCode]= I.[TaxCode],
	[TaxCommission] = CAST(COALESCE(I.[TaxCommission], 0) as bit),
	[TaxCommissionOnly] = CAST(COALESCE(I.[TaxCommissionOnly], 0) as bit),
	[StateTaxPercent] = COALESCE(I.[TaxStatePercent], 0),
	[CountyTaxPercent] = COALESCE(I.[TaxCountyPercent], 0),
	[CityTaxPercent]= COALESCE(I.[TaxCityPercent], 0),
	[StateResaleTaxAmount] = COALESCE(I.[StateTaxAmount], 0),
	[CountyResaleTaxAmount] = COALESCE(I.[CountyTaxAmount], 0),
	[CityResaleTaxAmount] = COALESCE(I.[CityTaxAmount], 0),
	[IsNonBillable] = I.[NonBillable],
	[IsBillOnHold] = CASE WHEN IOnly.BILL_HOLD_FLAG <> 0 THEN IOnly.BILL_HOLD_FLAG END,
	[Comment] = I.[Comment],
	[NetApprovedAmount] = BAI.APPROVED_AMT,
	[ApprovalComment] = BAI.ITEM_COMMENTS,
	[Instruction] = CASE BAI.INSTR
						WHEN 1 THEN 'Bill/Reconcile'
						WHEN 2 THEN 'Adjust'
						WHEN 3 THEN 'Transfer'
						WHEN 4 THEN 'Hold'
						END,
	[ID] = I.[ID],
	[JobNumber] = I.[JobNumber],
	[JobComponentNumber] = I.[JobComponentNumber],
	[FunctionCode] = I.[FunctionCode],
	[Description] = I.[Description],
	[BillingCommandCenterID] = IOnly.BCC_ID,
	[FunctionDescription] = F.FNC_DESCRIPTION,
	[ABFlag] = IOnly.AB_FLAG,
	[TransferFromJob] = IOnly.XFER_FROM_JOB,
	[TransferFromJobComponent] = IOnly.XFER_FROM_JOB_COMP,
	[TransferFromFunctionCode] = IOnly.XFER_FROM_FNC,
	[AdjustmentTransferUserCode] = IOnly.XFER_ADJ_USER,
	[AdjustmentTransferDate] = IOnly.XFER_ADJ_DATE,
	[AdjustmentTransferComment] = IOnly.ADJ_COMMENTS
FROM @income_only I
	INNER JOIN dbo.INCOME_ONLY IOnly ON I.ID = IOnly.IO_ID AND I.SequenceNumber = IOnly.SEQ_NBR 
	INNER JOIN dbo.JOB_COMPONENT JC ON JC.JOB_NUMBER = @JobNumber AND JC.JOB_COMPONENT_NBR = @JobComponentNumber
	LEFT OUTER JOIN dbo.BILL_APPR_DTL BAD ON BAD.BA_ID = JC.SELECTED_BA_ID AND IOnly.FNC_CODE = BAD.FNC_CODE AND BAD.JOB_NUMBER = JC.JOB_NUMBER AND BAD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
	LEFT OUTER JOIN dbo.BILL_APPR_ITEM BAI ON BAI.REC_ID = I.ID AND BAI.REC_TYPE = 'I' AND BAD.BA_DTL_ID = BAI.BA_DTL_ID AND BAI.REC_DTL_ID = I.SequenceNumber
	INNER JOIN dbo.FUNCTIONS F ON I.FunctionCode = F.FNC_CODE
WHERE
		IOnly.JOB_NUMBER = @JobNumber
AND		IOnly.JOB_COMPONENT_NBR = @JobComponentNumber
AND		((@FunctionCodeList IS NULL) OR IOnly.FNC_CODE IN (SELECT * FROM dbo.udf_split_list(@FunctionCodeList, '|')))
AND		I.[InvoiceDate] <= @IncomeOnlyDateCutoff
AND		IOnly.AR_INV_NBR IS NULL
AND		NOT (COALESCE(I.[Amount], 0) = 0 AND COALESCE(I.[MarkupAmount], 0) = 0)
AND		(
			(@ProductionLock = 1 AND IOnly.BCC_ID IS NOT NULL)
		OR
			(@ProductionLock = 0)
		)
ORDER BY I.[InvoiceDate], I.[ID]
GO
