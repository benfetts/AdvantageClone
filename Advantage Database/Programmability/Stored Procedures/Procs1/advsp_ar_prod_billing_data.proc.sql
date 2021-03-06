IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_prod_billing_data]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_prod_billing_data]
GO	

CREATE PROCEDURE [dbo].[advsp_ar_prod_billing_data] 
	@all_comp_amt tinyint = 0,			--#20
	@user_id varchar(100)
AS
SET NOCOUNT ON

-- ==================================================================================
-- advsp_ar_prod_billing_data 
-- populates table PROD_BILLING_DATA which replaces "Billing Table with Seq" in Access shell
-- #00 08/17/12 - v650 initial - based on (#08 12/21/11), adds field [ITEM_TYPE]
-- #03 03/31/13 - v660 added CDP and OFFICE codes
-- #04 05/13/13 - v660 replaced AR_COOP_LOG ad AR_COOP_DTL with AR_SUMMARY, added #estimate_seq_nbrs
-- #05 05/15/13 - v660 various fixes to #ar_list and prior seq nbrs
-- #06 07/31/13 - v660 set non_resale_tax to 0 and include in net
-- #07 08/13/13 - v660 include commission in net amount for FNC_TYPE "E" and "I"
-- #08 08/15/13 = v660 include non resale tax in AP and AB net amount
-- #09 08/15/13 - v660 set estimate EXT_NONRESALE_TAX to 0, and include in net amount
-- #10 08/21/13 - v660 various advance billing amount fixes
-- #11 09/27/13 - v660 re-enabled "BILL_HOLD_FLG,0) = 0" in AP,IO,ET and AB for #BillInvoiceAmounts
-- #12 03/13/14 - v660 separated vendor tax (NON_RESALE_AMT and AB_NONRESALE_AMT) from net amount
-- #13 03/14/14 - v660 set bia.EXT_NONRESALE_TAX not 0
-- #14 06/11/14 - v660 new temp table #ar_cdplist to extract CDP codes from AR_SUMMARY not ACCT_REC
-- #15 06/26/14 - v660 removed EXT_NONRESALE_TAX from net amount (incorrectly included)
-- #16 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
-- #17 07/08/14 - v660 re-dimensioned sequence number to (4) digits 522-308) - fix for current and estimate data
-- #18 08/19/14 - v660 moved join from btwsq to CURRENT for @ar_cdplist and added join for PRIOR records, was dropping prior records (1312-410)
-- #19 08/26/14 - v660 added JOB_NUMBER to #ar_cdplist, duplicate CDP codes otherwise (521-216)
-- #20 09/22/14 - v660 enabled all component amounts from v650 (661-61)
-- #21 01/30/15 - v660 re-dimensioned IO_DESC from 40 to 100 chars (1864-163)
-- #22 02/05/15 - v660 re-dimensioned IO_INV_NBR from 20 to 26 chars
-- #23 02/23/16 - v660/v670 changes to enable type "C invoices
-- #24 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
-- ==================================================================================

-- Identify the current Advantage user
--DECLARE @user_id varchar(100)

/* NOT USED IN .Net AT THIS POINT */

IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

--SELECT @user_id

-- Clears data records for this USER_ID from the main data table
DELETE dbo.PROD_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'PI'	--#24

-- This variable is for later use: 0 = bill hist for cur job/comp only, 1 = alljob/comps		--#20
--DECLARE @all_comp_amt tinyint
--SET @all_comp_amt = 0
--SELECT @all_comp_amt

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @ar_inv_date

-- Determines whether to use std on consol function
DECLARE @use_function_opt tinyint
SELECT @use_function_opt = FUNCTION_OPT FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @use_function_opt

-- Temporary master table of for all invoices selected in RPT_SEL_NBRS
CREATE TABLE #ar_list( 
	[AR_INV_NBR] integer NOT NULL)
INSERT INTO #ar_list
SELECT DISTINCT i.AR_INV_NBR
FROM dbo.RPT_SEL_NBRS AS i
WHERE i.APP_TYPE = 'PI' AND UPPER(i.[USER_ID]) = UPPER(@user_id)
--SELECT * FROM #ar_list

-- Temporary master table of all job/comps for all invoices selected in RPT_SEL_NBRS (with option using @all_comp_amt)
CREATE TABLE #ar_list_all( 
	[AR_INV_NBR] integer NOT NULL,
	[JOB_NUMBER] integer NULL, 
	[JOB_COMPONENT_NBR] smallint NULL)	
IF @all_comp_amt = 0
BEGIN
INSERT INTO #ar_list_all
	SELECT DISTINCT i.AR_INV_NBR, arj.JOB_NUMBER, arj.JOB_COMPONENT_NBR
	FROM dbo.ARINV_JOB arj
	JOIN #ar_list AS i
	ON arj.AR_INV_NBR = i.AR_INV_NBR
END
ELSE
BEGIN
INSERT INTO #ar_list_all
	SELECT DISTINCT i.AR_INV_NBR, arj.JOB_NUMBER, jc.JOB_COMPONENT_NBR
	FROM dbo.ARINV_JOB arj
	JOIN #ar_list AS i
	ON arj.AR_INV_NBR = i.AR_INV_NBR
	JOIN dbo.JOB_COMPONENT AS jc
	ON arj.JOB_NUMBER = jc.JOB_NUMBER
END
--SELECT * FROM #ar_list_all

-- Temporary table to hold a list of all DISTINCT job/comps
CREATE TABLE #ar_inv_joblist( 
	[JOB_NUMBER] integer NULL, 
	[JOB_COMPONENT_NBR] smallint NULL)
INSERT INTO #ar_inv_joblist
	SELECT DISTINCT arl.JOB_NUMBER, arl.JOB_COMPONENT_NBR
	FROM #ar_list_all AS arl
--SELECT * FROM #ar_inv_joblist

-- Temporary table to hold a list of invoices the jobs above appear on, including prior invoices
CREATE TABLE #ar_inv_invlist( 
	[AR_INV_NBR]					integer NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #ar_inv_invlist
	SELECT DISTINCT arj.AR_INV_NBR,
		ar.CL_CODE,			--#03
		ar.DIV_CODE,		--#03
		ar.PRD_CODE,		--#03
		ar.OFFICE_CODE		--#03
	FROM #ar_inv_joblist arinvjob
	JOIN dbo.ARINV_JOB arj 
		ON arinvjob.JOB_NUMBER = arj.JOB_NUMBER
		AND arinvjob.JOB_COMPONENT_NBR = arj.JOB_COMPONENT_NBR
	JOIN dbo.ACCT_REC ar
	    ON arj.AR_INV_SEQ = ar.AR_INV_SEQ
	    AND arj.AR_INV_NBR = ar.AR_INV_NBR 
	    WHERE arj.AR_INV_DATE <= @ar_inv_date
		AND ar.MANUAL_INV IS NULL
    GROUP BY arj.AR_INV_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE		--#03
	HAVING MAX( ar.AR_TYPE ) <> 'VO'		
--SELECT * FROM #ar_inv_invlist

--Temporary table to hold a list of function codes
CREATE TABLE #function_codes(
	FNC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CONSOL_FNC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FNC_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #function_codes
	SELECT 
		f.FNC_CODE, 
		COALESCE(f2.FNC_CONSOLIDATION, f.FNC_CONSOLIDATION, f.FNC_CODE),
		COALESCE(f2.FNC_TYPE, f.FNC_TYPE, f.FNC_TYPE)
	FROM dbo.FUNCTIONS f
	LEFT JOIN dbo.FUNCTIONS f2
		 ON f.FNC_CONSOLIDATION = f2.FNC_CODE
	LEFT JOIN dbo.FNC_HEADING fh 
		ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID
	ORDER BY f.FNC_TYPE, f.FNC_ORDER
--SELECT * FROM #function_codes

-- ==============================================================================
-- Temporary table to hold a list of invoice CDP codes from AR_SUMMARY		--#14
CREATE TABLE #ar_cdplist( 
	[AR_INV_NBR]					integer NULL,
	[AR_INV_SEQ]					smallint NULL,
	[JOB_NUMBER]					integer NULL,							--#19
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #ar_cdplist
	SELECT DISTINCT 
		ar.AR_INV_NBR,
		ar.AR_INV_SEQ,
		ar.JOB_NUMBER,														--#19
		ar.CL_CODE,			
		ar.DIV_CODE,		
		ar.PRD_CODE,		
		ar.OFFICE_CODE		
	FROM dbo.AR_SUMMARY AS ar
	JOIN dbo.RPT_SEL_NBRS AS n 
		ON ar.AR_INV_NBR = n.AR_INV_NBR 
	    WHERE n.APP_TYPE = 'PI'
	    AND UPPER(n.[USER_ID]) = UPPER(@user_id)
    GROUP BY ar.AR_INV_NBR, ar.AR_INV_SEQ, ar.JOB_NUMBER, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE		
--SELECT * FROM #ar_cdplist
-- ===============================================================================

-- Temporary table to hold a list of sequence numbers, used for creating co-op estimates
CREATE TABLE #estimate_seq_nbrs( 
	[AR_INV_NBR]					integer NOT NULL,
	[AR_INV_SEQ]					smallint NOT NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					integer NULL, 
	[JOB_COMPONENT_NBR]				smallint NULL)
INSERT INTO #estimate_seq_nbrs
SELECT DISTINCT
	arl.AR_INV_NBR,
	s.AR_INV_SEQ,
	s.CL_CODE,
	s.DIV_CODE,
	s.PRD_CODE,
	s.OFFICE_CODE,
	arl.JOB_NUMBER,
	arl.JOB_COMPONENT_NBR
FROM #ar_list_all AS arl
--JOIN dbo.ACCT_REC AS s
--	ON arl.AR_INV_NBR = s.AR_INV_NBR
JOIN #ar_cdplist AS s											--#14
	ON arl.AR_INV_NBR = s.AR_INV_NBR
WHERE s.AR_INV_SEQ <> 99	
--SELECT * FROM #estimate_seq_nbrs	

--Temporary table to hold billing invoice amounts
CREATE TABLE #bill_invoice_amts( 	
	[DET_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]				smallint NULL,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[FNC_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					integer NULL,
	[AR_INV_SEQ]					smallint NULL,
	[AR_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_DATE]					smalldatetime NULL,
	[HRS_QTY]						decimal(15,2) NULL,
	[RATE]							decimal(15,2) NULL, 
	[EXT_AMT]			 			decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EXT_NONRESALE_TAX]				decimal(15,2) NULL, 
	[EXT_STATE_RESALE]				decimal(15,2) NULL, 
	[EXT_COUNTY_RESALE]				decimal(15,2) NULL, 
	[EXT_CITY_RESALE]				decimal(15,2) NULL, 
	[LINE_TOTAL]					decimal(15,2) NULL, 
	[ET_ID]							integer NULL, 
	[AP_ID]							integer NULL, 
	[AP_SEQ]						smallint NULL, 
	[AP_LINE_NBR]					smallint NULL,
	[IO_ID]							integer NULL, 
	[IO_INV_NBR]					varchar(26) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_INV_DATE]					smalldatetime NULL,
	[IO_DESC]						varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				smallint NULL,
	[EMPLOYEE_TITLE_ID]				integer NULL)

--Extracts current data for regular invoices (non co-op) from detail tables (same as v650)
INSERT INTO #bill_invoice_amts								--#08, #12
		SELECT 'AP', ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE, ap.FNC_CODE, ap.AR_INV_NBR, ap.AR_INV_SEQ, NULL, 
				ar.AR_INV_DATE, ISNULL(ap.AP_PROD_QUANTITY, 0), ISNULL(ap.AP_PROD_RATE, 0), ISNULL(ap.AP_PROD_EXT_AMT,0), 
				ISNULL(ap.EXT_MARKUP_AMT,0), ap.TAX_CODE,  ISNULL(ap.EXT_NONRESALE_TAX,0), ISNULL(ap.EXT_STATE_RESALE,0), ISNULL(ap.EXT_COUNTY_RESALE,0), 
				ISNULL(ap.EXT_CITY_RESALE,0), ISNULL(ap.LINE_TOTAL,0), 0, ap.AP_ID, ap.AP_SEQ, ap.LINE_NUMBER, NULL, '0', NULL, NULL, 0, NULL
		FROM dbo.AP_PRODUCTION ap 
		INNER JOIN dbo.ACCT_REC ar 
				ON ap.AR_TYPE = ar.AR_TYPE 
				AND ap.AR_INV_SEQ = ar.AR_INV_SEQ 
				AND ap.AR_INV_NBR = ar.AR_INV_NBR
	    JOIN #ar_list ai
				ON ar.AR_INV_NBR = ai.AR_INV_NBR		
		--WHERE ap.AR_INV_SEQ <> 99
		WHERE ISNULL(ap.AP_PROD_NOBILL_FLG,0) = 0			--#11
				AND ISNULL(ap.AP_PROD_BILL_HOLD,0) = 0		--#11
				AND ISNULL(ap.AR_INV_SEQ, 0) <> 99			--#11

INSERT INTO #bill_invoice_amts								--#07
		SELECT 'IO', ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE, ico.FNC_CODE, ico.AR_INV_NBR, ico.AR_INV_SEQ, NULL, 
				ar.AR_INV_DATE, ISNULL(ico.IO_QTY, 0), ISNULL(ico.IO_RATE, 0), ISNULL(ico.IO_AMOUNT,0) + ISNULL(ico.EXT_MARKUP_AMT,0), 0, 
				NULL, 0, ISNULL(ico.EXT_STATE_RESALE,0), ISNULL(ico.EXT_COUNTY_RESALE,0), ISNULL(ico.EXT_CITY_RESALE,0), ISNULL(ico.LINE_TOTAL,0), 
				0, 0, 0, 0, ico.IO_ID, ico.IO_INV_NBR, ico.IO_INV_DATE, ico.IO_DESC, ico.FEE_INVOICE, NULL
		FROM dbo.INCOME_ONLY ico 
		INNER JOIN dbo.ACCT_REC ar
				ON ico.AR_TYPE = ar.AR_TYPE 
				AND ico.AR_INV_SEQ = ar.AR_INV_SEQ 
				AND ico.AR_INV_NBR = ar.AR_INV_NBR
	    JOIN #ar_list ai
				ON ar.AR_INV_NBR = ai.AR_INV_NBR
		--WHERE (ico.AR_INV_SEQ <> 99)	
		WHERE ISNULL(ico.BILL_HOLD_FLAG,0) = 0				--#11
				AND ISNULL(ico.AR_INV_SEQ, 0) <>99			--#11

INSERT INTO #bill_invoice_amts								--#08
		SELECT 'AB', ab.JOB_NUMBER, ab.JOB_COMPONENT_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE, ab.FNC_CODE, ab.AR_INV_NBR, ab.AR_INV_SEQ, NULL, 
				ar.AR_INV_DATE, 0, 0,
				CASE f.FNC_TYPE								--#07
					WHEN 'V' THEN ISNULL(ab.LINE_TOTAL,0) - ISNULL(ab.EXT_STATE_RESALE,0) - ISNULL(ab.EXT_COUNTY_RESALE,0) - ISNULL(ab.EXT_CITY_RESALE,0)
						- ISNULL(ab.EXT_MARKUP_AMT,0) - ISNULL(ab.EXT_NONRESALE_TAX,0)
					ELSE ISNULL(ab.LINE_TOTAL,0) - ISNULL(ab.EXT_STATE_RESALE,0) - ISNULL(ab.EXT_COUNTY_RESALE,0) - ISNULL(ab.EXT_CITY_RESALE,0)
				END	,
				CASE f.FNC_TYPE								--#08, #12
					WHEN 'V' THEN ISNULL(ab.EXT_MARKUP_AMT,0)
					ELSE 0
				END,	
				ab.TAX_CODE,  ISNULL(ab.EXT_NONRESALE_TAX,0), ISNULL(ab.EXT_STATE_RESALE,0), ISNULL(ab.EXT_COUNTY_RESALE,0), ISNULL(ab.EXT_CITY_RESALE,0), 
				ISNULL(ab.LINE_TOTAL,0), 0, 0, 0, 0, NULL, '0', NULL, NULL, 0, NULL
		FROM dbo.ADVANCE_BILLING ab 
		INNER JOIN dbo.ACCT_REC ar 
				ON ab.AR_INV_NBR = ar.AR_INV_NBR 
				AND ab.AR_INV_SEQ = ar.AR_INV_SEQ 
				AND ab.AR_TYPE = ar.AR_TYPE
	    JOIN #ar_list ai
				ON ar.AR_INV_NBR = ai.AR_INV_NBR
	 	JOIN #function_codes f
				ON ab.FNC_CODE = f.FNC_CODE
		WHERE (ab.AR_INV_SEQ <> 99)	

INSERT INTO #bill_invoice_amts								--#07
		SELECT 'ET', etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE, etd.FNC_CODE, etd.AR_INV_NBR, etd.AR_INV_SEQ, NULL, 
				ar.AR_INV_DATE, ISNULL(etd.EMP_HOURS,0), ISNULL(etd.EMP_BILL_RATE,0), ISNULL(etd.TOTAL_BILL,0) + ISNULL(etd.EXT_MARKUP_AMT,0), 0, 
				ISNULL(etd.TAX_CODE,0), 0, ISNULL(etd.EXT_STATE_RESALE,0), ISNULL(etd.EXT_COUNTY_RESALE,0), ISNULL(etd.EXT_CITY_RESALE,0), 
				ISNULL(etd.LINE_TOTAL,0), etd.ET_ID, 0, 0, 0, NULL, '0', NULL, NULL, 0, etd.EMPLOYEE_TITLE_ID
		FROM dbo.EMP_TIME_DTL etd 
		INNER JOIN dbo.ACCT_REC ar
				ON etd.AR_INV_NBR = ar.AR_INV_NBR 
				AND etd.AR_INV_SEQ = ar.AR_INV_SEQ 
				AND etd.AR_TYPE = ar.AR_TYPE
	    JOIN #ar_list ai
				ON ar.AR_INV_NBR = ai.AR_INV_NBR
		--WHERE (etd.AR_INV_SEQ <> 99)
		WHERE ISNULL(etd.BILL_HOLD_FLG,0) = 0				--#11
				AND (etd.AR_INV_SEQ <> 99)					--#11
--SELECT * FROM #bill_invoice_amts		

--Extracts current data for co-op invoices, and prior data for all invoices - uses AR_SUMMARY
INSERT INTO #bill_invoice_amts(
	DET_TYPE, [JOB_NUMBER], [JOB_COMPONENT_NBR], [CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], [FNC_CODE], [AR_INV_NBR], [AR_INV_SEQ], [AR_TYPE],
	[AR_INV_DATE], [HRS_QTY], [RATE], [EXT_AMT], [EXT_MARKUP_AMT], 
	[TAX_CODE], [EXT_NONRESALE_TAX], [EXT_STATE_RESALE], [EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], [LINE_TOTAL])
SELECT
	f.FNC_TYPE, s.JOB_NUMBER, s.JOB_COMPONENT_NBR, s.CL_CODE, s.DIV_CODE, s.PRD_CODE, s.OFFICE_CODE, s.FNC_CODE, s.AR_INV_NBR, s.AR_INV_SEQ, s.AR_TYPE,
	d.AR_INV_DATE, s.HRS_QTY, 0,
	CASE f.FNC_TYPE
		WHEN 'V' THEN ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0) - ISNULL(s.AB_COMMISSION_AMT,0)			--#10
			- ISNULL(s.NON_RESALE_AMT,0) - ISNULL(s.AB_NONRESALE_AMT,0)										--#12
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END,
	CASE f.FNC_TYPE																			
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#10
		ELSE 0
	END, 
	s.TAX_CODE, ISNULL(s.NON_RESALE_AMT,0) + ISNULL(s.AB_NONRESALE_AMT,0), ISNULL(s.STATE_TAX_AMT,0), 	ISNULL(s.CNTY_TAX_AMT,0),			--#12
	ISNULL(s.CITY_TAX_AMT,0), ISNULL(s.TOTAL_BILL,0)
FROM dbo.AR_SUMMARY AS s
JOIN dbo.V_AR_INVOICE_DATES AS d
	ON s.AR_INV_NBR = d.AR_INV_NBR
	AND s.AR_TYPE = d.AR_TYPE	
JOIN #ar_inv_invlist ai
	ON s.AR_INV_NBR = ai.AR_INV_NBR
LEFT JOIN #ar_list	AS i
	ON ai.AR_INV_NBR = i.AR_INV_NBR
JOIN dbo.FUNCTIONS AS f
	ON s.FNC_CODE = f.FNC_CODE	
WHERE s.AR_INV_SEQ <> 99		
	AND (i.AR_INV_NBR IS NULL			--extracts non-current records
	OR s.AR_INV_SEQ <> 0)				--extracts current coop records
--SELECT * FROM #bill_invoice_amts

-- Main data table used to populate "PROD_BILLING_DATA" with billing amounts	
CREATE TABLE #billing_table_with_seq_mt_query( 	
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]				integer NULL,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Std Function Code]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Function Code Type]			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Function Code]					varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Consol Fnc Code]				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	[PrdConsol]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					integer NULL, 
	[AR_INV_SEQ]					smallint NULL, 
	[AR_INV_DATE]					smalldatetime NULL,
	[Item Type]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[Item Id]						integer NULL, 
	[ItemSeq Nbr]					integer NULL, 
	[Item Line Nbr]					integer NULL, 
	[Item Code]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item]							varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item Date]						smalldatetime NULL, 
	[Item Detail]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	 		
	[AP_DESC]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[HRS_QTY]						decimal(15,2) NULL, 
	[RATE]							decimal(15,2) NULL, 
	[EXT_AMT]						decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EXT_NONRESALE_TAX]				decimal(15,2) NULL, 
	[EXT_CITY_RESALE]				decimal(15,2) NULL, 
	[EXT_COUNTY_RESALE]				decimal(15,2) NULL, 
	[EXT_STATE_RESALE]				decimal(15,2) NULL, 
	[LINE_TOTAL]					decimal(15,2) NULL, 
	[IO_FEE_INVOICE]				integer NULL,
	[EMPLOYEE_TITLE_ID]				integer NULL)
	
--Underlying select query for current and prior data linking to related SYSADM tables
INSERT INTO #billing_table_with_seq_mt_query
		SELECT bia.JOB_NUMBER, 
				bia.JOB_COMPONENT_NBR, 
				bia.CL_CODE,							
				NULL,				--c.DIV_CODE,		--#18
				NULL,				--c.PRD_CODE,		--#18
				NULL,				--c.OFFICE_CODE,	--#18
				bia.FNC_CODE AS [Std Function Code],
				CASE
					WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code Type],
				CASE
					WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
					ELSE bia.FNC_CODE
				END AS [Function Code],
				[Consol Fnc Code] = f.CONSOL_FNC,
				ISNULL(p.PRD_CONSOL_FUNC, '0') AS [PrdConsol],		
				bia.AR_INV_NBR, 
				bia.AR_INV_SEQ,
				bia.AR_INV_DATE,
				bia.DET_TYPE,
				[Item Id] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN bia.AP_ID 
										WHEN 'ET' THEN bia.ET_ID
										WHEN 'IO' THEN bia.IO_ID
									END,
				[ItemSeq Id] = CASE bia.DET_TYPE WHEN 'AP' THEN bia.AP_SEQ END,
				bia.AP_LINE_NBR AS [Item Line Nbr],
				[Item Code] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN aph.VN_FRL_EMP_CODE
										WHEN 'ET' THEN et.EMP_CODE
									END,
				[Item] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN v.VN_NAME
										WHEN 'ET' THEN e.EMP_FNAME + ' ' + e.EMP_LNAME
										WHEN 'IO' THEN bia.IO_DESC
										WHEN 'AB' THEN 'Advance Billing'
									END,				 
				[Item Date] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN aph.AP_INV_DATE
										WHEN 'ET' THEN et.EMP_DATE
										WHEN 'IO' THEN bia.IO_INV_DATE
										WHEN 'AB' THEN bia.AR_INV_DATE
									END,				 				 
				[Item Detail] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN aph.AP_INV_VCHR
										WHEN 'IO' THEN bia.IO_INV_NBR 
									END,
				aph.AP_DESC, 
				bia.HRS_QTY, 
				bia.RATE,													--CAST( 0 AS decimal( 15,2 )) AS [Rate], 
				bia.EXT_AMT,												-- + bia.EXT_NONRESALE_TAX,	--#06, #15
				bia.EXT_MARKUP_AMT, 
				bia.TAX_CODE, 
				bia.EXT_NONRESALE_TAX,										--bia.EXT_NONRESALE_TAX,	--#06, #13
				bia.EXT_CITY_RESALE, 
				bia.EXT_COUNTY_RESALE, 
				bia.EXT_STATE_RESALE, 
				bia.LINE_TOTAL, 
				bia.IO_FEE_INVOICE,
				bia.EMPLOYEE_TITLE_ID
		FROM #bill_invoice_amts AS bia 
		JOIN dbo.JOB_LOG AS jl
			ON bia.JOB_NUMBER = jl.JOB_NUMBER
		JOIN dbo.JOB_COMPONENT AS jc
			ON bia.JOB_NUMBER = jc.JOB_NUMBER
			AND bia.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		JOIN dbo.PRODUCT AS p
			ON jl.CL_CODE = p.CL_CODE
			AND jl.DIV_CODE = p.DIV_CODE
			AND jl.PRD_CODE = p.PRD_CODE
		JOIN #function_codes f
			ON bia.FNC_CODE = f.FNC_CODE
 		LEFT JOIN dbo.AP_HEADER aph
			ON bia.AP_ID = aph.AP_ID
			AND bia.AP_SEQ = aph.AP_SEQ
		LEFT JOIN dbo.VENDOR v
			ON aph.VN_FRL_EMP_CODE = v.VN_CODE
		LEFT JOIN dbo.EMP_TIME et
			ON bia.ET_ID = et.ET_ID
		LEFT JOIN dbo.EMPLOYEE e
			ON et.EMP_CODE = e.EMP_CODE	
--SELECT * FROM #billing_table_with_seq_mt_query

--Append query to populate columns with CURRENT data based on [Billing Table with Seq MT-Query]
	INSERT INTO dbo.PROD_BILLING_DATA ( [USER_ID], [APP_TYPE],
					[REC_TYPE], [JOB_NUMBER], [JOB_COMPONENT_NBR], [CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], [STD_FNC_CODE], [FNC_CODE_TYPE], [FNC_CODE], [CONSOL_FNC_CODE], [PRD_CONSOL], 
					[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [ITEM_TYPE], [ITEM_ID], [ITEM_SEQ_NBR], [ITEM_LINE_NBR], 
					[ITEM_CODE], [ITEM], [ITEM_DATE], [ITEM_DETAIL], [AP_DESC], [HOURS_QTY], [RATE], [NET], [COMMISSION], [TAX_CODE], 
					[EXT_NONRESALE_TAX], [EXT_CITY_RESALE], [EXT_COUNTY_RESALE], [EXT_STATE_RESALE], [LINE_TOTAL], [PRIOR_INV_NBR], [PRIOR_INV_DATE], [EMPLOYEE_TITLE_ID] )
		  SELECT 
					@user_id,
					'PI', 
					'C',
					btwsmq.JOB_NUMBER, 
					btwsmq.JOB_COMPONENT_NBR, 
					c.[CL_CODE],																		--#18
					c.[DIV_CODE],																		--#18
					c.[PRD_CODE],																		--#18
					c.[OFFICE_CODE],																	--#18 
					btwsmq.[Std Function Code],
					btwsmq.[Function Code Type], 
					btwsmq.[Function Code],
					NULL,		--btwsmq.[Consol Fnc Code], 
					NULL,		--btwsmq.PrdConsol, 
					btwsmq.AR_INV_NBR, 
					CAST( btwsmq.AR_INV_NBR AS varchar(12)),
					RIGHT('000000' + CAST(btwsmq.AR_INV_NBR AS varchar(6)), 6) + '-' + 
						RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)), 4),						--#17
					btwsmq.AR_INV_SEQ, 
					CAST( btwsmq.AR_INV_NBR AS varchar(12)) + CAST( btwsmq.AR_INV_SEQ AS varchar(4)),					
					btwsmq.AR_INV_DATE,  
					btwsmq.[Item Type], 
					btwsmq.[Item Id], 
					btwsmq.[ItemSeq Nbr], 
					btwsmq.[Item Line Nbr], 
					btwsmq.[Item Code], 
					btwsmq.[Item], 
					btwsmq.[Item Date], 
					btwsmq.[Item Detail], 		
					btwsmq.AP_DESC, 
					btwsmq.HRS_QTY, 
					btwsmq.RATE, 
					btwsmq.EXT_AMT, 
					btwsmq.EXT_MARKUP_AMT, 
					btwsmq.TAX_CODE, 
					btwsmq.EXT_NONRESALE_TAX,
					btwsmq.EXT_CITY_RESALE, 
					btwsmq.EXT_COUNTY_RESALE, 
					btwsmq.EXT_STATE_RESALE, 
					btwsmq.LINE_TOTAL,
					NULL,			--btwsmq.AR_INV_NBR,
					NULL,			--btwsmq.AR_INV_DATE,
					btwsmq.[EMPLOYEE_TITLE_ID]
			FROM #billing_table_with_seq_mt_query AS btwsmq
			JOIN dbo.RPT_SEL_NBRS AS i															
					ON btwsmq.AR_INV_NBR = i.AR_INV_NBR	
					AND btwsmq.CL_CODE = i.CL_CODE													--#08
			JOIN #ar_cdplist AS c																	--#14, #18
					ON btwsmq.AR_INV_NBR = c.AR_INV_NBR
					AND btwsmq.AR_INV_SEQ = c.AR_INV_SEQ
					AND btwsmq.JOB_NUMBER = c.JOB_NUMBER											--#19
			WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)															
					AND i.APP_TYPE = 'PI'															--#23						
--SELECT * FROM dbo.PROD_BILLING_DATA      

--[Prior Filter by Job Number] select query to identify qualifying invoice numbers for prior data for selected invoices to print
CREATE TABLE #prior_filter_by_job ( 
	AR_INV_NBR 				integer NULL,
	AR_INV_SEQ 				integer NULL,
	JOB_NUMBER				integer NULL,
	JOB_COMPONENT_NBR		integer NULL,
	AR_INV_DATE 			smalldatetime NULL)
INSERT INTO #prior_filter_by_job
		SELECT DISTINCT
				bia.AR_INV_NBR,
				0, 
				bia.JOB_NUMBER, 
				CASE @all_comp_amt
					WHEN 0 THEN bia.JOB_COMPONENT_NBR
					ELSE 0
				END	, 
				bia.AR_INV_DATE
		FROM #bill_invoice_amts bia
		JOIN #ar_list AS i
				ON bia.AR_INV_NBR = i.AR_INV_NBR	
		GROUP BY bia.AR_INV_NBR,
				bia.AR_INV_SEQ, 
				bia.JOB_NUMBER, 
				bia.JOB_COMPONENT_NBR, 
				bia.AR_INV_DATE
--SELECT * FROM #prior_filter_by_job

--Append query to populate columns with PRIOR data based on [Billing Table with Seq MT-Query]
INSERT INTO dbo.PROD_BILLING_DATA ( [USER_ID], [APP_TYPE],
				[REC_TYPE], [JOB_NUMBER], [JOB_COMPONENT_NBR], [CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], [STD_FNC_CODE], [FNC_CODE_TYPE], [FNC_CODE], [CONSOL_FNC_CODE], [PRD_CONSOL], 
				[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [ITEM_TYPE], [ITEM_ID], [ITEM_SEQ_NBR], [ITEM_LINE_NBR], 
				[ITEM_CODE], [ITEM], [ITEM_DATE], [ITEM_DETAIL], [AP_DESC], [PRIOR_HOURS_QTY], [PRIOR_RATE], [PRIOR_NET], [PRIOR_COMMISSION],
				[TAX_CODE], [PRIOR_EXT_NONRESALE_TAX], [PRIOR_EXT_CITY_RESALE], [PRIOR_EXT_COUNTY_RESALE], [PRIOR_EXT_STATE_RESALE], [PRIOR_LINE_TOTAL],[PRIOR_INV_NBR], 
				[PRIOR_INV_DATE], [EMPLOYEE_TITLE_ID] )
		SELECT 
				@user_id,
				'PI',
				'P', 
				btwsmq.JOB_NUMBER, 
				btwsmq.JOB_COMPONENT_NBR,
				c.[CL_CODE],																			--#18
				c.[DIV_CODE],																			--#18
				c.[PRD_CODE],																			--#18
				c.[OFFICE_CODE],																		--#18
				btwsmq.[Std Function Code], 
				btwsmq.[Function Code Type],
				btwsmq.[Function Code],
				NULL,		--btwsmq.[Consol Fnc Code], 
				NULL,		--btwsmq.[PrdConsol], 
				pfbj.AR_INV_NBR, 
				CONVERT( varchar(12), pfbj.AR_INV_NBR ), 				
				RIGHT('000000' + CAST(pfbj.AR_INV_NBR AS varchar(6)), 6) + '-' + 
					RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)), 4),							--#16
				btwsmq.AR_INV_SEQ,																		--changed pfbj.AR_INV_SEQ to btwsmq.AR_INV_SEQ JP 2/08
				CONVERT( varchar(12), pfbj.AR_INV_NBR ) + CONVERT( varchar(4), btwsmq.AR_INV_SEQ ),		--changed pfbj.AR_INV_SEQ to btwsmq.AR_INV_SEQ JP 2/08
				pfbj.AR_INV_DATE, 
				btwsmq.[Item Type],  
				btwsmq.[Item Id], 
				btwsmq.[ItemSeq Nbr], 
				btwsmq.[Item Line Nbr], 
				btwsmq.[Item Code], 
				btwsmq.[Item], 
				btwsmq.[Item Date], 
				btwsmq.[Item Detail], 
				btwsmq.AP_DESC, 
				btwsmq.HRS_QTY,
				btwsmq.RATE, 
				btwsmq.EXT_AMT, 
				btwsmq.EXT_MARKUP_AMT, 
				NULL AS TAX_CODE, 
				btwsmq.EXT_NONRESALE_TAX, 
				btwsmq.EXT_CITY_RESALE, 
				btwsmq.EXT_COUNTY_RESALE, 
				btwsmq.EXT_STATE_RESALE, 
				btwsmq.LINE_TOTAL,
				btwsmq.AR_INV_NBR,
				btwsmq.AR_INV_DATE,
				btwsmq.[EMPLOYEE_TITLE_ID]
		FROM #prior_filter_by_job pfbj
		JOIN	#billing_table_with_seq_mt_query btwsmq 
				ON pfbj.JOB_NUMBER = btwsmq.JOB_NUMBER
				AND ( @all_comp_amt <> 0 OR pfbj.JOB_COMPONENT_NBR = btwsmq.JOB_COMPONENT_NBR )
		JOIN #ar_cdplist AS c																			--#18
				ON pfbj.AR_INV_NBR = c.AR_INV_NBR
				AND btwsmq.AR_INV_SEQ = c.AR_INV_SEQ
				AND btwsmq.JOB_NUMBER = c.JOB_NUMBER	
		WHERE btwsmq.AR_INV_DATE <= pfbj.AR_INV_DATE 
				AND btwsmq.AR_INV_NBR < pfbj.AR_INV_NBR
--SELECT * FROM dbo.PROD_BILLING_DATA				
			   
--Append query to populate columns with estimate data
CREATE TABLE #bill_estimate_amts ( 
	JOB_NUMBER 						integer NULL,
	JOB_COMPONENT_NBR				integer NULL,
	FNC_CODE 						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EST_REV_QUANTITY				decimal(15,2) NULL,
	EST_REV_RATE					decimal(15,3) NULL,
	EST_REV_EXT_AMT					decimal(15,2) NULL,
	EST_REV_EXT_MARKUP_AMT			decimal(15,2) NULL,
	EST_REV_EXT_NONRESALE_TAX		decimal(15,2) NULL,
	EST_REV_EXT_STATE_RESALE		decimal(15,2) NULL,
	EST_REV_EXT_COUNTY_RESALE		decimal(15,2) NULL,
	EST_REV_EXT_CITY_RESALE			decimal(15,2) NULL,
	EST_REV_LINE_TOTAL				decimal(15,2) NULL )
INSERT INTO #bill_estimate_amts
		SELECT ea.JOB_NUMBER, 
				ea.JOB_COMPONENT_NBR, 
				erd.FNC_CODE,
				CAST( SUM( COALESCE( erd.EST_REV_QUANTITY, 0 )) AS decimal(15,2)) AS EST_REV_QUANTITY, 
				CAST( 0 AS decimal(15,3)) AS EST_REV_RATE, 
				CAST( SUM( COALESCE( erd.EST_REV_EXT_AMT, 0 ) + COALESCE( erd.EXT_CONTINGENCY, 0 )) AS decimal(15,2)) AS EST_REV_EXT_AMT, 
				CAST( SUM( COALESCE( erd.EXT_MARKUP_AMT, 0 ) + COALESCE( erd.EXT_MU_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_MARKUP_AMT, 
				CAST( SUM( COALESCE( erd.EXT_NONRESALE_TAX, 0 ) + COALESCE( erd.EXT_NR_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_NONRESALE_TAX, 
				CAST( SUM( COALESCE( erd.EXT_STATE_RESALE, 0 ) + COALESCE( erd.EXT_STATE_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_STATE_RESALE, 
				CAST( SUM( COALESCE( erd.EXT_COUNTY_RESALE, 0 ) + COALESCE( erd.EXT_COUNTY_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_COUNTY_RESALE, 
				CAST( SUM( COALESCE( erd.EXT_CITY_RESALE, 0 ) + COALESCE( erd.EXT_CITY_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_CITY_RESALE, 
				CAST( SUM( COALESCE( erd.LINE_TOTAL, 0 ) + COALESCE( erd.LINE_TOTAL_CONT, 0 )) AS decimal(15,2)) AS EST_REV_LINE_TOTAL
		FROM dbo.ESTIMATE_APPROVAL ea 
		INNER JOIN dbo.ESTIMATE_REV_DET erd
				ON ea.EST_REVISION_NBR = erd.EST_REV_NBR 
				AND ea.EST_QUOTE_NBR = erd.EST_QUOTE_NBR 
				AND ea.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR 
				AND ea.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER
		INNER JOIN dbo.ESTIMATE_LOG el
				ON ea.ESTIMATE_NUMBER = el.ESTIMATE_NUMBER
		INNER JOIN dbo.FUNCTIONS f
				ON erd.FNC_CODE = f.FNC_CODE
		INNER JOIN #ar_inv_joblist arij
				ON ea.JOB_NUMBER = arij.JOB_NUMBER
				AND ea.JOB_COMPONENT_NBR = arij.JOB_COMPONENT_NBR
		GROUP BY ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, erd.FNC_CODE
		--SELECT * FROM #bill_estimate_amts		

-- Populate "PROD_BILLING_DATA" with estimate amounts
INSERT INTO dbo.PROD_BILLING_DATA ( [USER_ID], [APP_TYPE],
				[REC_TYPE], [JOB_NUMBER], [JOB_COMPONENT_NBR], [CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], [STD_FNC_CODE], [FNC_CODE_TYPE], [FNC_CODE], [CONSOL_FNC_CODE], [PRD_CONSOL], 
				[AR_INV_NBR], [AR_INV_NBR_STR], [INVOICE_NUMBER], [AR_INV_SEQ], [INV_SEQ_LINK], [INVOICE_DATE], [EST_QTY], [EST_NET], [EST_COMM], [EST_EXT_NONRESALE_TAX], 
				[EST_EXT_CITY_RESALE], [EST_EXT_COUNTY_RESALE], [EST_EXT_STATE_RESALE], [EST_LINE_TOTAL], [EST_TOTAL_NC] )
		SELECT 
				@user_id,
				'PI',
				'E', 
				bea.JOB_NUMBER, 
				bea.JOB_COMPONENT_NBR,
				arl.CL_CODE,
				arl.DIV_CODE,
				arl.PRD_CODE,
				arl.OFFICE_CODE, 
				bea.FNC_CODE,
				CASE
					WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code],
				CASE
					WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
					ELSE bea.FNC_CODE
				END AS [Function Code],
				NULL,		--[Consol Fnc Code] = f.CONSOL_FNC,
				NULL,		--COALESCE( p.PRD_CONSOL_FUNC, '0' ) AS [PrdConsol], 
				arl.AR_INV_NBR,
				CONVERT( varchar(12), arl.AR_INV_NBR ),
				--RIGHT('000000' + CAST(arl.AR_INV_NBR AS varchar(6)), 6) + '-00', 
				--0 AS [Inv Nbr Seq],
				--CONVERT( varchar(12), arl.AR_INV_NBR ) + '0',CONVERT( varchar(12), arl.AR_INV_NBR ),
				RIGHT('000000' + CAST(arl.AR_INV_NBR AS varchar(6)), 6) + '-' + 
					RIGHT('0000' + CAST(arl.AR_INV_SEQ AS varchar(4)), 4),									--#17
				arl.AR_INV_SEQ,	
				CONVERT( varchar(12), arl.AR_INV_NBR ) + CONVERT( varchar(4), arl.AR_INV_SEQ ),	 
				@ar_inv_date,
				bea.EST_REV_QUANTITY,
				CASE f.FNC_TYPE										--#09, #12
					WHEN 'V' THEN bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE - bea.EST_REV_EXT_MARKUP_AMT - bea.EST_REV_EXT_NONRESALE_TAX
					ELSE bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE	
				END,
				CASE f.FNC_TYPE										--#09								
					WHEN 'V' THEN bea.EST_REV_EXT_MARKUP_AMT
					ELSE 0
				END,
				bea.EST_REV_EXT_NONRESALE_TAX,													--#09, #12
				bea.EST_REV_EXT_CITY_RESALE, 
				bea.EST_REV_EXT_COUNTY_RESALE, 
				bea.EST_REV_EXT_STATE_RESALE, 
				bea.EST_REV_LINE_TOTAL,
				0 AS [Estimate Total NC]
		FROM #estimate_seq_nbrs arl
	 	JOIN #bill_estimate_amts bea
				ON arl.JOB_NUMBER = bea.JOB_NUMBER
				AND arl.JOB_COMPONENT_NBR = bea.JOB_COMPONENT_NBR
		JOIN dbo.JOB_COMPONENT jc
				ON bea.JOB_NUMBER = jc.JOB_NUMBER
				AND bea.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	 	JOIN dbo.JOB_LOG jl 
				ON jc.JOB_NUMBER = jl.JOB_NUMBER
		JOIN dbo.SALES_CLASS sc
				ON jl.SC_CODE = sc.SC_CODE
	 	JOIN dbo.PRODUCT p
				ON jl.CL_CODE = p.CL_CODE
				AND jl.DIV_CODE = p.DIV_CODE
				AND jl.PRD_CODE = p.PRD_CODE
	 	JOIN #function_codes f
				ON bea.FNC_CODE = f.FNC_CODE
		--JOIN dbo.RPT_SEL_NBRS AS i
		--		ON arl.AR_INV_NBR = i.AR_INV_NBR
		--JOIN #ar_inv_invlist AS ai					--#03
		--		ON	arl.AR_INV_NBR = ai.AR_INV_NBR		
		--WHERE i.[USER_ID] = @user_id
end_tran:

SELECT * FROM dbo.PROD_BILLING_DATA

DROP TABLE #bill_invoice_amts
DROP TABLE #prior_filter_by_job
DROP TABLE #billing_table_with_seq_mt_query
DROP TABLE #ar_inv_joblist
DROP TABLE #ar_inv_invlist
DROP TABLE #bill_estimate_amts
DROP TABLE #ar_list
GO
