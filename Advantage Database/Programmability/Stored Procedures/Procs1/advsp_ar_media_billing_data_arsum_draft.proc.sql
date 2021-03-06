SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_media_billing_data_arsum_draft]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_media_billing_data_arsum_draft]
GO

CREATE PROCEDURE [dbo].[advsp_ar_media_billing_data_arsum_draft]
		@user_id varchar(100)
AS
SET NOCOUNT ON

 -- ==========================================================================
 -- advsp_ar_media_billing_data - ARSUM DRAFT
 -- #00 03/25/13 - v660 initial - based on (production 3/25/13)
 -- #01 03/28/13 - v660 added BILL_COMM_NET
 -- #02 04/02/13 - v660 added MEDIA_TYPE and BU_INV_NBR
 -- #03 04/27/13 - v660 enabled HRS_QTY
 -- #04 04/30/13 - v660 added missing fields START_DATE -> BU_INV_NBR
 -- #05 08/22/13 - v660 added NON_RESALE_AMT to net (had been excluded)
 -- #06 11/26/13 - v660 Redo to use DRAFT_INV_NBR from AR_FUNCTION
 -- #07 01/03/14 - v660 removed NON_RESALE_AMT from net (incorrectly included 617-343)
 -- #08 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
 -- #09 07/08/14 - v660 re-dimensioned sequence number to (4) digits 522-308) - fix for prior data
 -- #10 07/31/14 - v660 added join to ORDER_TYPE for #draft_orderlist (735-1311)
 -- #11 09/17/14 - v660 removed join to ORDER_TYPE (484-367)
 -- #12 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
 -- ==========================================================================

/* NOT USED IN .Net AT THIS POINT */

-- Identify the current Advantage user
	IF ISNULL(@user_id, '') > '' BEGIN
		SET @user_id = UPPER(@user_id)
	END
	ELSE BEGIN
		SET @user_id = ''
		--SELECT @user_id = UPPER(dbo.78())
	END

-- Clears data records for this USER_ID from the main data table
DELETE dbo.MEDIA_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'MI'	--#12

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'MI'
--SELECT @ar_inv_date

-- Temporary table to hold a list of all orders using a list of billing users
CREATE TABLE #draft_orderlist( 
	[ORDER_NBR]				integer NULL, 
	[LINE_NBR]				smallint NULL,
	[BU_INV_NBR]			varchar(110) COLLATE SQL_Latin1_General_CP1_CS_AS,		--#02
	[AR_INV_NBR]			integer NULL)
INSERT INTO #draft_orderlist
	SELECT DISTINCT o.ORDER_NBR, 
		o.ORDER_LINE_NBR,
		o.DRAFT_INV_NBR,
		o.AR_INV_NBR
	FROM dbo.AR_FUNCTION AS o
	JOIN dbo.RPT_SEL_NBRS AS s
		ON o.BILLING_USER  = s.BILLING_USER		
		--AND o.MEDIA_TYPE = s.ORDER_TYPE												--#10, #11
	WHERE UPPER(s.[USER_ID]) = UPPER(@user_id)	
--SELECT * FROM #draft_orderlist

--Temporary table to hold billing invoice amounts
CREATE TABLE #bill_invoice_amts( 	
	[DET_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MEDIA_TYPE]					varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[ORDER_NBR]						integer NULL,
	[LINE_NBR]						smallint NULL,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					integer NULL,
	[AR_INV_SEQ]					smallint NULL,
	[AR_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_DATE]					smalldatetime NULL,
	[HRS_QTY]						decimal(15,2) NULL,
	[BILL_COMM_NET]					smallint NULL,
	[EXT_AMT]			 			decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EXT_NONRESALE_TAX]				decimal(15,2) NULL, 
	[EXT_STATE_RESALE]				decimal(15,2) NULL, 
	[EXT_COUNTY_RESALE]				decimal(15,2) NULL, 
	[EXT_CITY_RESALE]				decimal(15,2) NULL, 
	[REBATE]						decimal(15,2) NULL,
	[NET_CHARGE]					decimal(15,2) NULL,
	[DISCOUNT]						decimal(15,2) NULL,
	[ADDITIONAL]					decimal(15,2) NULL,	 
	[LINE_TOTAL]					decimal(15,2) NULL,
	[START_DATE]					smalldatetime NULL,
	[END_DATE]						smalldatetime NULL,
	[MEDIA_MONTH]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MEDIA_YEAR]					smallint NULL,
	[PERIOD]						int NULL,
	[BILLING_USER]					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[BU_INV_NBR]					varchar(150) COLLATE SQL_Latin1_General_CP1_CS_AS)		

-- Uses table AR_FUNCTION
-- Insert the data for DRAFT billing
INSERT INTO #bill_invoice_amts(
	[DET_TYPE],
	[MEDIA_TYPE],
	[ORDER_NBR],
	[LINE_NBR],
	[OFFICE_CODE],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[AR_INV_NBR],
	[AR_INV_SEQ],
	[AR_TYPE],
	[AR_INV_DATE],
	[HRS_QTY],
	[BILL_COMM_NET], 
	[EXT_AMT], 
	[EXT_MARKUP_AMT], 
	[TAX_CODE], 
	[EXT_NONRESALE_TAX], 
	[EXT_STATE_RESALE], 
	[EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], 
	[REBATE],
	[NET_CHARGE],
	[DISCOUNT],
	[ADDITIONAL],
	[LINE_TOTAL],
	[START_DATE],
	[END_DATE],
	[MEDIA_MONTH],
	[MEDIA_YEAR],
	[PERIOD],
	[BILLING_USER],
	[BU_INV_NBR])
SELECT
	NULL,	
	s.MEDIA_TYPE,
	s.ORDER_NBR,
	s.ORDER_LINE_NBR,
	s.OFFICE_CODE,
	s.CL_CODE,
	s.DIV_CODE,
	s.PRD_CODE,
	NULL,	--s.AR_INV_NBR,
	s.DRAFT_INV_SEQ,
	NULL,	--s.AR_TYPE,
	NULL,	--d.AR_INV_DATE,
	s.HRS_QTY,
	s.BILL_COMM_NET,
	ISNULL(s.COST_AMT,0),			--#04, #07
	ISNULL(s.COMMISSION_AMT,0),
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0),		--#07
	ISNULL(s.STATE_TAX_AMT,0),
	ISNULL(s.CNTY_TAX_AMT,0),
	ISNULL(s.CITY_TAX_AMT,0),
	ISNULL(s.REBATE_AMT,0),
	ISNULL(s.NET_CHARGE_AMT,0),
	ISNULL(s.DISCOUNT_AMT,0),
	ISNULL(s.ADDITIONAL_AMT,0),
	ISNULL(s.TOTAL_BILL,0),
	ISNULL(s.[START_DATE],0),
	ISNULL(s.END_DATE,0),
	LEFT(DATENAME(month, CAST(s.MEDIA_MONTH AS varchar) + '/1/2013'),3),
	ISNULL(s.MEDIA_YEAR,0),
	ISNULL(s.MEDIA_YEAR,0) * 100 + ISNULL(s.MEDIA_MONTH,0),
	s.BILLING_USER,
	dbo.advfn_billing_user_invoice_number_media(s.INV_BY, s.CL_CODE, s.DIV_CODE, s.PRD_CODE,
		s.MEDIA_TYPE, h.MARKET_CODE, h.CMP_CODE, s.CLIENT_PO, s.ORDER_NBR)
FROM dbo.AR_FUNCTION AS s
JOIN dbo.V_MEDIA_HDR AS h
	ON s.ORDER_NBR = h.ORDER_NBR
--SELECT * FROM #bill_invoice_amts

-- Insert the data for prior INVOICE billing
INSERT INTO #bill_invoice_amts(
	[DET_TYPE],
	[MEDIA_TYPE],
	[ORDER_NBR],
	[LINE_NBR],
	[OFFICE_CODE],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[AR_INV_NBR],
	[AR_INV_SEQ],
	[AR_TYPE],
	[AR_INV_DATE],
	[HRS_QTY],
	[BILL_COMM_NET], 
	[EXT_AMT], 
	[EXT_MARKUP_AMT], 
	[TAX_CODE], 
	[EXT_NONRESALE_TAX], 
	[EXT_STATE_RESALE], 
	[EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], 
	[REBATE],
	[NET_CHARGE],
	[DISCOUNT],
	[ADDITIONAL],
	[LINE_TOTAL],
	[START_DATE],
	[END_DATE],
	[MEDIA_MONTH],
	[MEDIA_YEAR],
	[PERIOD])
SELECT
	NULL,	
	s.MEDIA_TYPE,
	s.ORDER_NBR,
	s.ORDER_LINE_NBR,
	s.OFFICE_CODE,
	s.CL_CODE,
	s.DIV_CODE,
	s.PRD_CODE,
	s.AR_INV_NBR,
	s.AR_INV_SEQ,
	s.AR_TYPE,
	d.AR_INV_DATE,
	s.HRS_QTY,
	s.BILL_COMM_NET,
	ISNULL(s.COST_AMT,0),			--#07 Note: did not include NON_RESALE_AMT in #06
	ISNULL(s.COMMISSION_AMT,0),
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0),		--#07 Note: was = 0 in #06
	ISNULL(s.STATE_TAX_AMT,0),
	ISNULL(s.CNTY_TAX_AMT,0),
	ISNULL(s.CITY_TAX_AMT,0),
	ISNULL(s.REBATE_AMT,0),
	ISNULL(s.NET_CHARGE_AMT,0),
	ISNULL(s.DISCOUNT_AMT,0),
	ISNULL(s.ADDITIONAL_AMT,0),	
	ISNULL(s.TOTAL_BILL,0),
	ISNULL(s.[START_DATE],0),
	ISNULL(s.END_DATE,0),
	LEFT(DATENAME(month, CAST(s.MEDIA_MONTH AS varchar) + '/1/2013'),3),
	ISNULL(s.MEDIA_YEAR,0),
	ISNULL(s.MEDIA_YEAR,0) * 100 + ISNULL(s.MEDIA_MONTH,0)
FROM dbo.AR_SUMMARY AS s
JOIN dbo.V_AR_INVOICE_DATES AS d
	ON s.AR_INV_NBR = d.AR_INV_NBR
	AND s.AR_TYPE = d.AR_TYPE	
JOIN #draft_orderlist AS o
	ON s.ORDER_NBR = o.ORDER_NBR
	AND s.ORDER_LINE_NBR = o.LINE_NBR
WHERE s.AR_INV_SEQ <> 99									--#06	
--SELECT * FROM #bill_invoice_amts

--Append query to populate columns with CURRENT data based on [Billing Table with Seq MT-Query]
INSERT INTO dbo.MEDIA_BILLING_DATA ( [USER_ID], [APP_TYPE],
	[REC_TYPE], [MEDIA_TYPE], [ORDER_NBR], [LINE_NBR], [OFFICE_CODE], [CL_CODE], [DIV_CODE], [PRD_CODE], 
	[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [HOURS_QTY], [BILL_COMM_NET], 
	[NET], [COMMISSION], [TAX_CODE], 
	[EXT_NONRESALE_TAX], [EXT_CITY_RESALE], [EXT_COUNTY_RESALE], [EXT_STATE_RESALE], 
	[REBATE], [NET_CHARGE], [DISCOUNT], [ADDITIONAL],
	[LINE_TOTAL], [PRIOR_INV_NBR], [PRIOR_INV_DATE], [START_DATE], [END_DATE], [MEDIA_MONTH], [MEDIA_YEAR], [PERIOD],
	[BILLING_USER], [BU_INV_NBR])
SELECT 
	@user_id,
	'MI', 
	'C',
	btwsmq.MEDIA_TYPE,
	btwsmq.ORDER_NBR, 
	btwsmq.LINE_NBR, 
	btwsmq.OFFICE_CODE,
	btwsmq.CL_CODE,
	btwsmq.DIV_CODE,
	btwsmq.PRD_CODE,
	o.AR_INV_NBR,																	--#06
	o.BU_INV_NBR,																	--#02	
	'DRAFT ' + RIGHT('0000000' + CAST(o.AR_INV_NBR AS varchar(7)),6) + '-' + 
		RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),					--#08
	btwsmq.AR_INV_SEQ,																--#02
	CAST(o.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#06				
	btwsmq.AR_INV_DATE,  
	btwsmq.HRS_QTY, 
	btwsmq.BILL_COMM_NET,
	btwsmq.EXT_AMT, 
	btwsmq.EXT_MARKUP_AMT, 
	btwsmq.TAX_CODE, 
	btwsmq.EXT_NONRESALE_TAX, 
	btwsmq.EXT_CITY_RESALE, 
	btwsmq.EXT_COUNTY_RESALE, 
	btwsmq.EXT_STATE_RESALE, 
	btwsmq.REBATE, 
	btwsmq.NET_CHARGE, 
	btwsmq.DISCOUNT, 
	btwsmq.ADDITIONAL, 
	btwsmq.LINE_TOTAL,
	NULL,			--btwsmq.AR_INV_NBR
	NULL,			--btwsmq.AR_INV_DATE
	btwsmq.[START_DATE],
	btwsmq.END_DATE,
	btwsmq.MEDIA_MONTH,
	btwsmq.MEDIA_YEAR,
	btwsmq.PERIOD,
	btwsmq.BILLING_USER,
		btwsmq.BU_INV_NBR
FROM #bill_invoice_amts AS btwsmq
JOIN #draft_orderlist o
	ON btwsmq.ORDER_NBR = o.ORDER_NBR
	AND btwsmq.LINE_NBR = o.LINE_NBR
WHERE btwsmq.AR_INV_NBR IS NULL
--SELECT * FROM dbo.MEDIA_BILLING_DATA      

--Append query to populate columns with PRIOR data based on [Billing Table with Seq MT-Query]
INSERT INTO dbo.MEDIA_BILLING_DATA ( [USER_ID], [APP_TYPE],
	[REC_TYPE], [MEDIA_TYPE], [ORDER_NBR], [LINE_NBR], [OFFICE_CODE], [CL_CODE], [DIV_CODE], [PRD_CODE],  
	[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [PRIOR_HOURS_QTY], [BILL_COMM_NET], 
	[PRIOR_NET], [PRIOR_COMMISSION],
	[TAX_CODE], [PRIOR_EXT_NONRESALE_TAX], [PRIOR_EXT_CITY_RESALE], [PRIOR_EXT_COUNTY_RESALE], [PRIOR_EXT_STATE_RESALE], 
	[PRIOR_REBATE], [PRIOR_NET_CHARGE], [PRIOR_DISCOUNT], [PRIOR_ADDITIONAL],
	[PRIOR_LINE_TOTAL],[PRIOR_INV_NBR], 
	[PRIOR_INV_DATE], [START_DATE], [END_DATE], [MEDIA_MONTH], [MEDIA_YEAR], [PERIOD] )
SELECT 
	@user_id,
	'MI',
	'P',
	btwsmq.MEDIA_TYPE, 
	btwsmq.ORDER_NBR, 
	btwsmq.LINE_NBR,
	btwsmq.OFFICE_CODE,
	btwsmq.CL_CODE,
	btwsmq.DIV_CODE,
	btwsmq.PRD_CODE,
	o.AR_INV_NBR,																	--#06
	o.BU_INV_NBR,																	--#02	
	'DRAFT ' + RIGHT('0000000' + CAST(o.AR_INV_NBR AS varchar(7)),6) + '-' + 
		RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),					--#09
	btwsmq.AR_INV_SEQ,																--#02
	CAST(o.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#06
	NULL,	
	btwsmq.HRS_QTY,
	btwsmq.BILL_COMM_NET, 
	btwsmq.EXT_AMT, 
	btwsmq.EXT_MARKUP_AMT, 
	NULL AS TAX_CODE, 
	btwsmq.EXT_NONRESALE_TAX, 
	btwsmq.EXT_CITY_RESALE, 
	btwsmq.EXT_COUNTY_RESALE, 
	btwsmq.EXT_STATE_RESALE,
	btwsmq.REBATE, 
	btwsmq.NET_CHARGE, 
	btwsmq.DISCOUNT, 
	btwsmq.ADDITIONAL,  
	btwsmq.LINE_TOTAL,
	btwsmq.AR_INV_NBR,
	btwsmq.AR_INV_DATE,
	btwsmq.[START_DATE],
	btwsmq.END_DATE,
	btwsmq.MEDIA_MONTH,
	btwsmq.MEDIA_YEAR,
	btwsmq.PERIOD
FROM #bill_invoice_amts AS btwsmq
JOIN #draft_orderlist AS o
	ON btwsmq.ORDER_NBR = o.ORDER_NBR
	AND btwsmq.LINE_NBR = o.LINE_NBR
WHERE btwsmq.AR_INV_NBR IS NOT NULL	
--SELECT * FROM dbo.MEDIA_BILLING_DATA				

SELECT * FROM dbo.MEDIA_BILLING_DATA

DROP TABLE #bill_invoice_amts
DROP TABLE #draft_orderlist
GO


