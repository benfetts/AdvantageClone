CREATE PROC [dbo].[advsp_job_forecast_actuals]
	@RevisionID int = 0
AS

BEGIN

SET NOCOUNT ON;

DECLARE @et_date_cutoff smalldatetime,
		@io_date_cutoff smalldatetime, 
		@ap_pp_cutoff varchar(6)

SELECT @et_date_cutoff = MAX(EMP_DATE) FROM dbo.EMP_TIME
SELECT @io_date_cutoff = MAX(IO_INV_DATE) FROM dbo.INCOME_ONLY
SELECT @ap_pp_cutoff = MAX(PPPERIOD) FROM dbo.POSTPERIOD

DECLARE @JOBCOMPONENTS TABLE (
	JOB_NUMBER int NOT NULL,
	JOB_COMPONENT_NBR smallint NOT NULL
)

DECLARE @SUBTOTALS TABLE (
	[JobNumber] int NOT NULL,
	[ComponentNumber] smallint NOT NULL,
	[FunctionCode] varchar(6) NULL,
	[ActualBillableNetAmount] decimal(15,2) NULL,
	[ActualBillableMarkupAmount] decimal(15,2) NULL,
	[ItemID] int NULL,
	[ItemDate] smalldatetime NULL,
	[ItemPostPeriodCode] varchar(6) NULL
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
	[FunctionCode] varchar(6) NULL,
	[FunctionDescription] varchar(30) NULL,
	[FunctionType] varchar(1) NULL
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

INSERT INTO 
	@JOBCOMPONENTS (JOB_NUMBER, JOB_COMPONENT_NBR)
SELECT DISTINCT
	JC.JOB_NUMBER, JC.JOB_COMPONENT_NBR
FROM 
	dbo.JOB_COMPONENT JC 
LEFT OUTER JOIN
	dbo.JF_JOB JF ON JC.JOB_NUMBER = JF.JOB_NUMBER AND
					 JC.JOB_COMPONENT_NBR = JF.JOB_COMPONENT_NBR
WHERE 
	JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) AND
	1 = CASE WHEN ISNULL(@RevisionID, 0) = 0 THEN 1 WHEN JF.JF_REV_ID = @RevisionID THEN 1 ELSE 0 END

INSERT @SUBTOTALS
SELECT
	[JobNumber] = AP.JOB_NUMBER,
	[JobComponentNumber] = AP.JOB_COMPONENT_NBR,
	[FunctionCode] = AP.FNC_CODE,
	[ActualBillableNetAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(AP_PROD_EXT_AMT, 0) + COALESCE(EXT_NONRESALE_TAX, 0) ELSE 0 END,
	[ActualBillableMarkupAmount] = CASE WHEN COALESCE(AP_PROD_NOBILL_FLG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ItemID] = AP.AP_ID,
	[ItemDate] = APH.AP_INV_DATE,
	[ItemPostPeriodCode] = AP.POST_PERIOD
FROM	
	dbo.AP_PRODUCTION AP LEFT OUTER JOIN 
	dbo.AP_HEADER APH ON APH.AP_ID = AP.AP_ID AND APH.MODIFY_FLAG IS NULL JOIN
	@JOBCOMPONENTS JC ON AP.JOB_NUMBER = JC.JOB_NUMBER AND
							  AP.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
WHERE	AP.POST_PERIOD <= @ap_pp_cutoff
AND		(
		(AP_PROD_NOBILL_FLG IS NULL OR AP_PROD_NOBILL_FLG = 0)
		)
AND		(AP.MODIFY_DELETE IS NULL OR AP.MODIFY_DELETE = 0)

INSERT @SUBTOTALS 
SELECT
	[JobNumber] = ETD.JOB_NUMBER,
	[JobComponentNumber] = ETD.JOB_COMPONENT_NBR,
	[FunctionCode] = ETD.FNC_CODE,
	[ActualBillableNetAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(TOTAL_BILL, 0) ELSE 0 END,
	[ActualBillableMarkupAmount] = CASE WHEN COALESCE(EMP_NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ItemID] = ETD.ET_ID,
	[ItemDate] = ET.EMP_DATE,
	[ItemPostPeriodCode] = NULL
FROM 
	dbo.EMP_TIME_DTL ETD INNER JOIN 
	dbo.EMP_TIME ET ON ET.ET_ID = ETD.ET_ID INNER JOIN
	@JOBCOMPONENTS JC ON ETD.JOB_NUMBER = JC.JOB_NUMBER AND
							  ETD.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
WHERE	ET.EMP_DATE <= @et_date_cutoff
AND		(
			(ETD.EMP_NON_BILL_FLAG IS NULL OR ETD.EMP_NON_BILL_FLAG = 0)
		)
AND		(ETD.EDIT_FLAG IS NULL OR ETD.EDIT_FLAG = 0)

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
		dbo.FUNCTIONS ON INCOME_ONLY.FNC_CODE = FUNCTIONS.FNC_CODE JOIN
		@JOBCOMPONENTS JC ON INCOME_ONLY.JOB_NUMBER = JC.JOB_NUMBER AND
								  INCOME_ONLY.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
WHERE	IO_INV_DATE <= @io_date_cutoff
AND		(
		(NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0)
		)

INSERT @SUBTOTALS
SELECT
	[JobNumber] = IOnly.JOB_NUMBER,
	[JobComponentNumber] = IOnly.JOB_COMPONENT_NBR,
	[FunctionCode] = IOnly.FNC_CODE,
	[ActualBillableNetAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(IO_AMOUNT, 0) ELSE 0 END,
	[ActualBillableMarkupAmount] = CASE WHEN COALESCE(NON_BILL_FLAG, 0) = 0 THEN COALESCE(EXT_MARKUP_AMT, 0) ELSE 0 END,
	[ItemID] = IO_ID,
	[ItemDate] = IO_INV_DATE,
	[ItemPostPeriodCode] = NULL 
FROM 
	@income_only IOO INNER JOIN 
	dbo.INCOME_ONLY IOnly ON IOO.ID = IOnly.IO_ID AND IOO.SequenceNumber = IOnly.SEQ_NBR INNER JOIN
	@JOBCOMPONENTS JC ON IOnly.JOB_NUMBER = JC.JOB_NUMBER AND
							  IOnly.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
WHERE	IO_INV_DATE <= @io_date_cutoff
AND		(
		(NON_BILL_FLAG IS NULL OR NON_BILL_FLAG = 0)
		)


	INSERT @JOBCOMPONENTFUNCTIONS
	SELECT DISTINCT JobNumber,
					ComponentNumber, 
					FunctionCode 
	FROM @SUBTOTALS
	WHERE FunctionCode IS NOT NULL
	
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
			[FunctionCode] = JCF.FunctionCode,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE
	FROM	dbo.JOB_LOG JL
		INNER JOIN dbo.JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER
		INNER JOIN @JOBCOMPONENTS JOBS ON JOBS.JOB_NUMBER = JC.JOB_NUMBER AND JOBS.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR 
		LEFT OUTER JOIN @JOBCOMPONENTFUNCTIONS JCF ON JCF.JobNumber = JC.JOB_NUMBER AND JCF.ComponentNumber = JC.JOB_COMPONENT_NBR
		INNER JOIN dbo.JOB_PROC_CONTROLS JPC ON JC.JOB_PROCESS_CONTRL = JPC.JOB_PROCESS_CONTRL
		LEFT OUTER JOIN dbo.CAMPAIGN CMP ON JL.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
		INNER JOIN dbo.OFFICE O ON JL.OFFICE_CODE = O.OFFICE_CODE 
		INNER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE 
		INNER JOIN dbo.DIVISION D ON JL.CL_CODE = D.CL_CODE AND JL.DIV_CODE = D.DIV_CODE 
		INNER JOIN dbo.PRODUCT P ON JL.CL_CODE = P.CL_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.PRD_CODE = P.PRD_CODE 
		LEFT OUTER JOIN dbo.SALES_CLASS SC ON JL.SC_CODE = SC.SC_CODE
		LEFT OUTER JOIN dbo.FUNCTIONS F ON JCF.FunctionCode = F.FNC_CODE 

	SELECT
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
		R.[FunctionCode],
		[FunctionDescription],
		S.ActualBillableNetAmount,
		S.ActualBillableMarkupAmount,
		[ActualBillableAmount] = S.ActualBillableNetAmount + S.ActualBillableMarkupAmount,
		[ActualRevenueAmount] = Case When R.FunctionType IN ('E', 'I') THEN S.ActualBillableNetAmount + S.ActualBillableMarkupAmount WHEN R.FunctionType = 'V' THEN S.ActualBillableMarkupAmount END,
		[FunctionType],
		S.[ItemID],
		S.[ItemDate],
		S.[ItemPostPeriodCode]
	FROM @FUNCTIONRESULTS R 
		LEFT OUTER JOIN @SUBTOTALS S ON R.JobNumber = S.JobNumber AND
										R.ComponentNumber = S.ComponentNumber AND
										R.FunctionCode = S.FunctionCode
	WHERE S.FunctionCode IS NOT NULL AND R.FunctionCode IS NOT NULL OPTION (RECOMPILE)
	
END