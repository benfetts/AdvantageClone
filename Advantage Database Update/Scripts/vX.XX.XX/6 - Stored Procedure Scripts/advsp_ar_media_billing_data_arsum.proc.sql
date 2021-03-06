SET ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_media_billing_data_arsum]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_media_billing_data_arsum]
GO

CREATE PROCEDURE [dbo].[advsp_ar_media_billing_data_arsum]
		@user_id varchar(100)
AS
SET NOCOUNT ON

-- ============================================================================
-- advsp_ar_prod_billing_data_arsum ARSUM
-- populates table MEDIA_BILLING_DATA
-- #00 03/25/13 - v660 initial - based on (production 3/25/13)
-- #01 03/28/13 - v660 added BILL_COMM_NET
-- #02 04/27/13 - v660 enabled HRS_QTY
-- #03 04/29/13 - v660 added missing fields START_DATE -> PERIOD
-- #04 08/22/13 - v660 added NON_RESALE_AMT to net (had been excluded)
-- #05 01/03/14 - v660 removed NON_RESALE_AMT from net (incorrectly included 617-343)
-- #06 03/19/14 - v660 added join to RPT_SEL_NBRS.CL_CODE, was doubling amounts for co-op invoices (735-1099) - orig fixed on 2/21/14.
-- #07 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
-- #08 02/23/16 - v660/v670 changes to enable type "C invoices
-- #09 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
-- #10 09/17/21 - v670 limit by current USER
-- ============================================================================

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
DELETE dbo.MEDIA_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'MI'	--#09

---- This variable is for later use: 0 = bill hist for cur job/comp only, 1 = alljob/comps
--DECLARE @all_comp_amt tinyint
--SET @all_comp_amt = 0
----SELECT @all_comp_amt

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'MI'
--SELECT @ar_inv_date

---- Temporary master table of all orders for all invoices selected in RPT_SEL_NBRS
CREATE TABLE #ar_list_all( 
	[AR_INV_NBR] integer NOT NULL,
	[ORDER_NBR] integer NULL) 
--	[JOB_COMPONENT_NBR] smallint NULL)
	
INSERT INTO #ar_list_all
	SELECT DISTINCT 
		i.AR_INV_NBR, 
		arm.ORDER_NBR
	FROM dbo.ARINV_MEDIA arm
	JOIN dbo.RPT_SEL_NBRS AS i
		ON arm.AR_INV_NBR = i.AR_INV_NBR
	WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)
		AND i.APP_TYPE = 'MI'
--SELECT * FROM #ar_list_all

-- Temporary table to hold a list of all DISTINCT orders
CREATE TABLE #ar_inv_orderlist( 
	[ORDER_NBR] integer NULL )
	--[JOB_COMPONENT_NBR] smallint NULL)

INSERT INTO #ar_inv_orderlist
	SELECT DISTINCT arl.ORDER_NBR
	FROM #ar_list_all AS arl
--SELECT * FROM #ar_inv_orderlist

-- Temporary table to hold a list of invoices the orders above appear on
CREATE TABLE #ar_inv_invlist( [AR_INV_NBR] integer NULL )

INSERT INTO #ar_inv_invlist
	SELECT arm.AR_INV_NBR
	FROM #ar_inv_orderlist o
	INNER JOIN dbo.ARINV_MEDIA arm 
		ON o.ORDER_NBR = arm.ORDER_NBR
		--AND arinvjob.JOB_COMPONENT_NBR = arj.JOB_COMPONENT_NBR
	INNER JOIN dbo.ACCT_REC ar
	    ON arm.AR_INV_SEQ = ar.AR_INV_SEQ
	    AND arm.AR_INV_NBR = ar.AR_INV_NBR 
    WHERE arm.AR_INV_DATE <= @ar_inv_date
	AND ar.MANUAL_INV IS NULL
    GROUP BY arm.AR_INV_NBR
		HAVING MAX( ar.AR_TYPE ) <> 'VO'
--SELECT * FROM #ar_inv_invlist

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
	[TAX_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
	[PERIOD]						int NULL)		

-- Source data is AR_SUMMARY
INSERT INTO #bill_invoice_amts(
	DET_TYPE,
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
	ISNULL(s.COST_AMT,0),			--#04, #05
	ISNULL(s.COMMISSION_AMT,0),
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0),		--#05
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
JOIN #ar_inv_invlist ai
	ON s.AR_INV_NBR = ai.AR_INV_NBR

---- Main data table used to populate "MEDIA_BILLING_DATA" with billing amounts
--Append query to populate columns with CURRENT data 
INSERT INTO dbo.MEDIA_BILLING_DATA ( [USER_ID], [APP_TYPE],
	[REC_TYPE], [MEDIA_TYPE], [ORDER_NBR], [LINE_NBR], [OFFICE_CODE], [CL_CODE], [DIV_CODE], [PRD_CODE], 
	[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [HOURS_QTY], [BILL_COMM_NET],
	[NET], [COMMISSION], [TAX_CODE], [EXT_NONRESALE_TAX], [EXT_CITY_RESALE], [EXT_COUNTY_RESALE], [EXT_STATE_RESALE], 
	[REBATE], [NET_CHARGE], [DISCOUNT], [ADDITIONAL],
	[LINE_TOTAL], [PRIOR_INV_NBR], [PRIOR_INV_DATE], [START_DATE], [END_DATE], [MEDIA_MONTH], [MEDIA_YEAR], [PERIOD])
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
	btwsmq.AR_INV_NBR, 
	CAST( btwsmq.AR_INV_NBR AS varchar(12)),
	RIGHT('000000' + CAST(btwsmq.AR_INV_NBR AS varchar(6)), 6) + '-' +			
		RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)), 4),							--#07
	btwsmq.AR_INV_SEQ, 
	CAST( btwsmq.AR_INV_NBR AS varchar(12)) + CAST( btwsmq.AR_INV_SEQ AS varchar(4)),					
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
	btwsmq.AR_INV_NBR,		--maybe NULL
	btwsmq.AR_INV_DATE,		--maybe NULL
	btwsmq.[START_DATE],
	btwsmq.END_DATE,
	btwsmq.MEDIA_MONTH,
	btwsmq.MEDIA_YEAR,
	btwsmq.PERIOD
FROM #bill_invoice_amts AS btwsmq
JOIN dbo.RPT_SEL_NBRS AS i						
	ON btwsmq.AR_INV_NBR = i.AR_INV_NBR
	AND btwsmq.CL_CODE = i.CL_CODE				--#06
	AND btwsmq.MEDIA_TYPE = i.ORDER_TYPE		--#08
WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)
--SELECT * FROM dbo.MEDIA_BILLING_DATA      

--[Prior Filter by Job Number] select query to identify qualifying invoice numbers for prior data for selected invoices to print
CREATE TABLE #prior_filter_by_order ( 
	AR_INV_NBR 				integer NULL,
	AR_INV_SEQ 				integer NULL,
	ORDER_NBR				integer NULL,
	LINE_NBR		integer NULL,
	AR_INV_DATE 			smalldatetime NULL)
INSERT INTO #prior_filter_by_order
SELECT DISTINCT
	bia.AR_INV_NBR,
	0, 
	bia.ORDER_NBR, 
	bia.LINE_NBR,
	bia.AR_INV_DATE
FROM #bill_invoice_amts bia
JOIN dbo.RPT_SEL_NBRS AS i
	ON bia.AR_INV_NBR = i.AR_INV_NBR
	AND bia.CL_CODE = i.CL_CODE				--#06
	AND bia.MEDIA_TYPE = i.ORDER_TYPE		--#08
	AND UPPER(i.[USER_ID]) = UPPER(@user_id) --#10
GROUP BY bia.AR_INV_NBR,
	bia.AR_INV_SEQ, 
	bia.ORDER_NBR, 
	bia.LINE_NBR, 
	bia.AR_INV_DATE
--SELECT * FROM #prior_filter_by_order

--Append query to populate columns with PRIOR data 
INSERT INTO dbo.MEDIA_BILLING_DATA ( [USER_ID], [APP_TYPE],
	[REC_TYPE], [MEDIA_TYPE], [ORDER_NBR], [LINE_NBR], [OFFICE_CODE], [CL_CODE], [DIV_CODE], [PRD_CODE], 
	[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [PRIOR_HOURS_QTY], [BILL_COMM_NET], 
	[PRIOR_NET], [PRIOR_COMMISSION], [TAX_CODE], [PRIOR_EXT_NONRESALE_TAX], [PRIOR_EXT_CITY_RESALE], 
	[PRIOR_EXT_COUNTY_RESALE], [PRIOR_EXT_STATE_RESALE], 
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
	pfbo.AR_INV_NBR, 
	CONVERT( varchar(12), pfbo.AR_INV_NBR ), 				
	RIGHT('000000' + CAST(pfbo.AR_INV_NBR AS varchar(6)), 6) + '-' + 
		RIGHT('00' + CAST(pfbo.AR_INV_SEQ AS varchar(2)), 2),								
	btwsmq.AR_INV_SEQ,																		
	CONVERT( varchar(12), pfbo.AR_INV_NBR ) + CONVERT( varchar(4), btwsmq.AR_INV_SEQ ),		
	pfbo.AR_INV_DATE, 
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
FROM #prior_filter_by_order pfbo
JOIN	#bill_invoice_amts btwsmq 
	ON pfbo.ORDER_NBR = btwsmq.ORDER_NBR
	AND pfbo.LINE_NBR = btwsmq.LINE_NBR
WHERE btwsmq.AR_INV_DATE <= pfbo.AR_INV_DATE 
	AND btwsmq.AR_INV_NBR < pfbo.AR_INV_NBR
SELECT * FROM dbo.MEDIA_BILLING_DATA				
			   
DROP TABLE #bill_invoice_amts

GO

GRANT EXECUTE ON [advsp_ar_media_billing_data_arsum] TO PUBLIC AS dbo

GO