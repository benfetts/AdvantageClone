--DROP PROCEDURE [dbo].[advsp_billing_approval_rollup] 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_billing_approval_rollup] 
@JOB_NUMBER AS  INT,
@JOB_COMPONENT_NBR AS SMALLINT,
@CMP_IDENTIFIER INT,
@ROLLUP_TYPE SMALLINT, -- 0 = JOB, 1 = CAMAPAIGN

@BA_ID AS INT,
@BA_BATCH_ID AS INT,

@TEMP_CUTOFF SMALLDATETIME,
@TEMP_CUTOFF_FNC_TYPE VARCHAR(20)
AS
/*================================*/
	
	SET @ROLLUP_TYPE = ISNULL(@ROLLUP_TYPE, 0);
	
	IF @ROLLUP_TYPE = 1 AND @JOB_NUMBER > 0 AND (@CMP_IDENTIFIER IS NULL OR @CMP_IDENTIFIER <= 0)
	BEGIN
		SELECT @CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER FROM JOB_LOG WITH(NOLOCK) WHERE JOB_LOG.JOB_NUMBER = @JOB_NUMBER;
	END

	CREATE TABLE 
		#JOB_LIST (
			[ID] INT  IDENTITY(1,1) NOT NULL,
			[JOB_NUMBER] INT NOT NULL,
			[JOB_COMPONENT_NBR] SMALLINT NOT NULL,
			[BA_BATCH_ID] INT,
			[CMP_IDENTIFIER] INT
		);

	CREATE TABLE 
		#APPROVAL_ROLLUP
		(
			[BA_DTL_ID] [INT] NOT NULL ,
			[BA_ID] [INT] NOT NULL ,
			[JOB_NUMBER] [INT] NOT NULL ,
			[JOB_COMPONENT_NBR] [SMALLINT] NOT NULL ,
			[FNC_TYPE]		[VARCHAR](1) COLLATE SQL_Latin1_General_CP1_CS_AS   NULL, 
			[FNC_TYPE_DESC]		[VARCHAR](15) COLLATE SQL_Latin1_General_CP1_CS_AS   NULL, 
			[FNC_CODE] [VARCHAR] (6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL ,
			[FNC_DESC] [VARCHAR] (30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
			[FNC_DFLT_DESC]		[VARCHAR](30) COLLATE SQL_Latin1_General_CP1_CS_AS   NULL, 
			[QUOTE_AMT] [DECIMAL](15, 2) NULL ,
			[ACTUALS] [DECIMAL](15, 2) NULL ,
			[BILLED_REC] [DECIMAL](15, 2) NULL ,
			[BILL_HOLD] [DECIMAL](15, 2) NULL ,
			[NON_BILL_FEE] [DECIMAL](15, 2) NULL ,
			[UNBILLED] [DECIMAL](15, 2) NULL ,
			[OPEN_PO] [DECIMAL](15, 2) NULL ,
			[QTY_HRS] [DECIMAL](15, 2) NULL ,
			[QUANTITY] [DECIMAL](15, 2) NULL ,
			[RATE] [DECIMAL](15, 2) NULL ,
			[APPROVED_AMT] [DECIMAL](15, 2) NULL ,
			[TEMP_CUTOFF_APPROVED_AMT] [DECIMAL] (15,2) NULL,
			[FNC_COMMENTS] [TEXT] COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
			[CLIENT_COMMENTS] [TEXT] COLLATE SQL_Latin1_General_CP1_CS_AS NULL ,
			[ROW_TYPE] [TINYINT] NULL ,
			[IS_EXISTING_ROW] [INT]  NULL ,
			[ITEM_EXISTS] [BIT] NULL,
			[FNC_HEADING_ID] [INT] NULL,
			[FNC_HEADING_DESC] [VARCHAR] (60)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			[FNC_HEADING_SEQ] [INT],
			[FNC_ORDER] [SMALLINT] NULL,
			[QUOTE_NET] [DECIMAL](15, 2) NULL ,
			[UNBILLED_NET] [DECIMAL](15, 2) NULL ,
			[TEMP_UNBILLED_NET] [DECIMAL](15, 2) NULL ,
			[APPR_NET] [DECIMAL](14, 2) NULL,
			[TEMP_APPR_NET] [DECIMAL](14, 2) NULL,
			[APPR_MARKUP_PCT] [DECIMAL](6, 3) NULL,
			[APPR_MARKUP_AMT] [DECIMAL](15, 2) NULL,
			[APPR_TAX_CODE] [VARCHAR](4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			[APPR_TAX_COMM] [SMALLINT] NULL,
			[APPR_TAX_COMM_ONLY] [SMALLINT] NULL,
			[APPR_TAX_RESALE] [SMALLINT] NULL,
			[APPR_RESALE_TAX] [DECIMAL](14, 2) NULL,
			[APPR_VENDOR_TAX] [DECIMAL](14, 2) NULL,
			[APPR_TAX_STATE_PCT] [DECIMAL](8, 4) NULL,
			[APPR_TAX_COUNTY_PCT] [DECIMAL](8, 4) NULL,
			[APPR_TAX_CITY_PCT] [DECIMAL](8, 4) NULL,
			[QUOTE_MARKUP]			[DECIMAL](15,2) NULL,
			[QUOTE_RESALE_TAX]		[DECIMAL](15,2) NULL,
			[QUOTE_VENDOR_TAX]		[DECIMAL](15,2) NULL,
			[UNBILLED_MARKUP]			[DECIMAL](15,2) NULL,
			[UNBILLED_RESALE_TAX]		[DECIMAL](15,2) NULL,
			[UNBILLED_VENDOR_TAX]		[DECIMAL](15,2) NULL ,
			[IS_USER_ROW] [BIT] NULL,
			[IS_USING_TEMP_APPROVED_AMT] BIT NULL,
			[QUOTE_QTY_HRS] DECIMAL(15,2) NULL,
			[ACTUAL_QTY_HRS] DECIMAL(15,2) NULL,
			[TEMP_MARKUP] DECIMAL (15,2),
			[TEMP_RESALE_TAX] DECIMAL (16,2),
			[TEMP_TOTAL] DECIMAL (16,2),
			[TEMP_UNBILLED_MU] DECIMAL (15,2),
			[TEMP_UNBILLED_TAX] DECIMAL (15,2),
			[TEMP_UNBILLED_NR] DECIMAL (15,2),
			[TEMP_UNBILLED_TOT] DECIMAL (15,2),
			[TEMP_PO] DECIMAL (15,2)
		);

	IF @ROLLUP_TYPE = 0
	BEGIN
		INSERT INTO #JOB_LIST (JOB_NUMBER, JOB_COMPONENT_NBR, BA_BATCH_ID)
		SELECT 
			JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.BA_BATCH_ID
		FROM 
			JOB_COMPONENT WITH(NOLOCK)
		WHERE 
			JOB_COMPONENT.JOB_NUMBER = @JOB_NUMBER 
			--AND JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)
		ORDER BY 
			JOB_COMPONENT.BA_BATCH_ID, JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR;
	END

	IF @ROLLUP_TYPE = 1
	BEGIN
		INSERT INTO #JOB_LIST (JOB_NUMBER, JOB_COMPONENT_NBR, BA_BATCH_ID, CMP_IDENTIFIER)
		SELECT 
			JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.BA_BATCH_ID, JOB_LOG.CMP_IDENTIFIER
		FROM 
			JOB_COMPONENT WITH(NOLOCK) INNER JOIN JOB_LOG WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
		WHERE 
			JOB_LOG.CMP_IDENTIFIER = @CMP_IDENTIFIER
			--AND JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12) 
		ORDER BY 
			JOB_COMPONENT.BA_BATCH_ID, JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR;
	END

	--SELECT * FROM #JOB_LIST;

	DECLARE
		@THIS_ID INT,
		@THIS_JOB_NUMBER INT,
		@THIS_JOB_COMPONENT_NBR SMALLINT,
		@THIS_BA_BATCH_ID INT

	DECLARE JOB_CURSOR CURSOR FOR
		SELECT [ID]
		FROM #JOB_LIST;

		OPEN JOB_CURSOR;
		FETCH NEXT FROM JOB_CURSOR INTO @THIS_ID;

		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			SELECT @THIS_JOB_NUMBER = JOB_NUMBER, @THIS_JOB_COMPONENT_NBR = JOB_COMPONENT_NBR, @THIS_BA_BATCH_ID = BA_BATCH_ID
			FROM #JOB_LIST WHERE #JOB_LIST.ID = @THIS_ID;

			INSERT INTO #APPROVAL_ROLLUP
			EXEC [dbo].[usp_wv_BA_APPROVAL_JC_GET_DETAILS]  @THIS_JOB_NUMBER, @THIS_JOB_COMPONENT_NBR, @BA_ID, @BA_BATCH_ID, 0, @TEMP_CUTOFF, @TEMP_CUTOFF_FNC_TYPE

			FETCH NEXT FROM JOB_CURSOR INTO @THIS_ID;
		
		END

	CLOSE JOB_CURSOR;
	DEALLOCATE JOB_CURSOR;

	DECLARE
		@ROLLUP_ID INT,
		@ROLLUP_CODE VARCHAR(6),
		@ROLLUP_DESC VARCHAR(200),
		@ROLLUP_COUNT INT;

	SELECT @ROLLUP_COUNT = COUNT(1) FROM #JOB_LIST;    

	IF @ROLLUP_TYPE = 0
	BEGIN
		SELECT @ROLLUP_ID = JOB_LOG.JOB_NUMBER, @ROLLUP_DESC = JOB_LOG.JOB_DESC FROM JOB_LOG WITH(NOLOCK) WHERE JOB_LOG.JOB_NUMBER = @JOB_NUMBER;
	END

	IF @ROLLUP_TYPE = 1
	BEGIN
		SELECT @ROLLUP_ID = @CMP_IDENTIFIER, @ROLLUP_CODE = CAMPAIGN.CMP_CODE, @ROLLUP_DESC = CAMPAIGN.CMP_NAME FROM CAMPAIGN WITH(NOLOCK) WHERE CAMPAIGN.CMP_IDENTIFIER = @CMP_IDENTIFIER;
	END

	--SELECT * FROM #APPROVAL_ROLLUP;


	SELECT 
		@ROLLUP_COUNT AS RollupCount,
		@ROLLUP_TYPE AS RollupType,
		@ROLLUP_ID AS RollupID,
		@ROLLUP_ID AS ROLLUP_ID,
		ISNULL(@ROLLUP_CODE, '') AS CampaignCode,
		@ROLLUP_DESC AS [Description],

		FNC_CODE AS FunctionCode,
		FNC_DESC AS FunctionDescription,
		FNC_DFLT_DESC AS FunctionDefaultDescription,

		FNC_TYPE AS FunctionType,
		FNC_TYPE_DESC AS FunctionTypeDescription,
		ISNULL(FNC_HEADING_DESC,'') AS FunctionHeadingDescription,

		SUM(QUOTE_AMT) AS QuoteAmount,
		SUM(ACTUALS) AS Actuals,
		SUM(BILLED_REC) AS BilledReceived,
		SUM(BILL_HOLD) AS BilledHold,
		SUM(NON_BILL_FEE) AS NonBillableFee,
		SUM(UNBILLED) AS Unbilled,
		SUM(OPEN_PO) AS OpenPO,
		SUM(QTY_HRS) AS QuantityHours,
		SUM(QUANTITY) AS Quantity,
		SUM(APPROVED_AMT) AS ApprovedAmount,

		SUM(TEMP_CUTOFF_APPROVED_AMT) AS TempCutoffApprovedAmount,
		SUM(QUOTE_NET) AS QuoteNet,

		SUM(UNBILLED_NET) AS UnbilledNet,
		SUM(TEMP_UNBILLED_NET) AS TempUnbilledNet,

		SUM(APPR_NET) AS ApprovedNet,
		SUM(TEMP_APPR_NET) AS TempApprovedNet,

		SUM(APPR_MARKUP_AMT) AS ApprovedMarkupAmount,

		SUM(APPR_RESALE_TAX) AS ApprovedResaleTax,
		SUM(APPR_VENDOR_TAX) AS ApprovedVendorTax,
		SUM(APPR_RESALE_TAX) + SUM(APPR_VENDOR_TAX) AS ApprovedTax,

		SUM(QUOTE_MARKUP) AS QuoteMarkup,
		SUM(QUOTE_RESALE_TAX) AS QuoteResaleTax,
		SUM(QUOTE_VENDOR_TAX) AS QuoteVendorTax,

		SUM(UNBILLED_MARKUP) AS UnbilledMarkup,

		SUM(UNBILLED_RESALE_TAX) AS UnbilledResaleTax,
		SUM(UNBILLED_VENDOR_TAX) AS UnbilledVendorTax,
		SUM(UNBILLED_RESALE_TAX) + SUM(UNBILLED_RESALE_TAX) AS UnbilledTax,

		SUM(QUOTE_QTY_HRS) AS QuoteQuantityHours,
		SUM(ACTUAL_QTY_HRS) AS ActualQuantityHours,

		SUM(TEMP_MARKUP) AS TempMarkup,
		SUM(TEMP_RESALE_TAX) AS TempResaleTax,
		SUM(TEMP_TOTAL) AS TempTotal,
		SUM(TEMP_UNBILLED_MU) AS TempUnbilledMU,
		SUM(TEMP_UNBILLED_TAX) AS TempUnbilledTax,
		SUM(TEMP_UNBILLED_NR) AS TempUnbilledNR,
		SUM(TEMP_UNBILLED_TOT) AS TempUnbilledTot,
		SUM(TEMP_PO) AS TempUnbilledPO

	FROM #APPROVAL_ROLLUP
	GROUP BY 
		FNC_CODE,
		FNC_DESC,
		FNC_DFLT_DESC,
		FNC_TYPE,
		FNC_TYPE_DESC,
		FNC_HEADING_DESC;

	DROP TABLE #JOB_LIST;
	DROP TABLE #APPROVAL_ROLLUP;
/*================================*/