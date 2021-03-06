IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_prod_billing_data_draft]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_prod_billing_data_draft]
GO

CREATE PROCEDURE [dbo].[advsp_ar_prod_billing_data_draft] 
	@all_comp_amt tinyint = 0,			--#20
	@user_id varchar(100)
AS

-- =================================================================================
-- advsp_ar_prod_billing_data_draft DRAFT
-- populates table PROD_BILLING_DATA which replaces "Billing Table with Seq" in Access shell
-- #00 02/22/13 - initial (uses #11 01/03/13 as source)
-- #01 03/20/13 - v650 modified SET statement for @user_id for 2005 compatability
-- #02 04/01/13 - v660 added CDP and OFFICE codes
-- #03 05/13/13 - v660 replaced AR_COOP_LOG ad AR_COOP_DTL with AR_SUMMARY, added #estimate_seq_nbrs
-- #04 07/31/13 - v660 set non_resale_tax to 0 and include in net
-- #05 08/05/13 - v660 set NULL AR_INV_SEQ to 0, in WHERE  for FNC_TYPE "E" and "I"
-- #06 08/13/13 - v660 include commission in net amount for FNC_TYPE "E" and "I"
-- #07 08/15/13 = v660 include non resale tax in AP and AB net amount
-- #08 08/15/13 - v660 set estimate EXT_NONRESALE_TAX to 0, and include in net amount
-- #09 08/16/13 - v660 fixed advance billing sums
-- #10 08/21/13 - v660 more advance billing fixes
-- #11 09/27/13 - v660 re-enabled "WHERE ISNULL(etd.BILL_HOLD_FLG,0) = 0"
-- #12 10/07/13 - v660 set to ISNULL(etd.AR_INV_SEQ,0)
-- #13 11/26/13 - v660 Redo using AR_INV_NBR from AR_SUMMARY 
-- #14 12/13/13 - v660 changed "where" detail filter for non co-op invoices
-- #15 03/13/14 - v660 separated vendor tax (NON_RESALE_AMT and AB_NONRESALE_AMT) from net amount
-- #16 03/14/14 - v660 set bia.EXT_NONRESALE_TAX not 0
-- #17 06/26/14 - v660 removed EXT_NONRESALE_TAX from net amount (incorrectly included)
-- #18 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
-- #19 07/08/14 - v660 re-dimensioned sequence number to (4) digits 522-308) - fix for prior and estimate data
-- #20 09/22/14 - v660 enabled all component amounts from v650 (661-61)
-- #21 09/30/14 - v660 fix - enabled all component amounts (661-61)
-- #22 10/01/14 - v660 fix (2)-(661-61)
-- #23 01/30/15 - v660 re-dimensioned IO_DESC from 40 to 100 chars (1864-163)
-- #24 02/05/15 - v660 re-dimensioned IO_INV_NBR from 20 to 26 chars
-- #25 07/25/15 - v660 fix (3)- @all_comp_amt filter needed to be added to estimate amounts (302-621)
-- #26 10/22/15 - v660 fix (4)- revert to old #draft_joblist for current/prior data and #draft_joblist_with_seq for estimate
-- #27 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
-- =================================================================================

SET NOCOUNT ON

/* NOT USED IN .Net AT THIS POINT */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END
--SELECT @user_id

-- Clears data records for this USER_ID from the main data table
DELETE dbo.PROD_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'PI'	--#27

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @ar_inv_date

-- Determines whether to use std on consol function
DECLARE @use_function_opt tinyint
SELECT @use_function_opt = FUNCTION_OPT FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @use_function_opt

-- This variable is for later use: 0 = bill hist for cur job/comp only, 1 = alljob/comps			--#20
--DECLARE @all_comp_amt tinyint
--SET @all_comp_amt = 0
--SELECT @all_comp_amt

--Temporary table of billing users in the print run
CREATE TABLE #billing_user (
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #billing_user
	SELECT DISTINCT bu.BILLING_USER
	FROM dbo.RPT_SEL_NBRS AS bu
	WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT * FROM #billing_user

-- Temporary table to hold a list of all jobs/comps with seq, for estimates
CREATE TABLE #draft_joblist_with_seq( 
	[BU_INV_NBR]					varchar(100) NULL,
	[BU_INV_SEQ]					smallint NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					integer NULL, 
	[JOB_COMPONENT_NBR]				smallint NULL,
	[AR_INV_NBR]					integer NULL)						--#13
INSERT INTO #draft_joblist_with_seq
SELECT DISTINCT 
	af.DRAFT_INV_NBR,
	af.DRAFT_INV_SEQ,
	af.CL_CODE,
	af.DIV_CODE,
	af.PRD_CODE,
	af.OFFICE_CODE,	
	af.JOB_NUMBER, 
	--af.JOB_COMPONENT_NBR,
	CASE @all_comp_amt													--#26
		WHEN 0 THEN af.JOB_COMPONENT_NBR
		ELSE 0
	END,
	af.AR_INV_NBR
FROM dbo.AR_FUNCTION AS af
JOIN #billing_user AS bu
	ON af.BILLING_USER  = bu.BILLING_USER
--SELECT * FROM #draft_joblist_with_seq

-- Temporary table to hold a list of all jobs/comps using a list of billing users	#04
-- From version #24 reinstated in #26, to replace the incorrect changes in #25
CREATE TABLE #draft_joblist( 
	[JOB_NUMBER]					integer NULL, 
	[JOB_COMPONENT_NBR]				smallint NULL,
	[BU_INV_NBR]					varchar(100) NULL,
	[AR_INV_NBR]					integer NULL)						
INSERT INTO #draft_joblist 
SELECT DISTINCT 
	af.JOB_NUMBER, 
	CASE @all_comp_amt													
		WHEN 0 THEN af.JOB_COMPONENT_NBR
		ELSE 0
	END,
	af.BU_INV_NBR,
	af.AR_INV_NBR	
FROM #draft_joblist_with_seq AS af
--SELECT * FROM #draft_joblist

-- Temporary table to hold a list of all jobs (job level) for use when @all_comp_amt=1
CREATE TABLE #draft_jobs( [JOB_NUMBER] integer NULL )
INSERT INTO #draft_jobs
	SELECT DISTINCT dj.JOB_NUMBER
	FROM #draft_joblist dj
--SELECT * FROM #draft_jobs

--- Temporary table to hold a list of invoices the jobs above appear on
-- Added 10/31/11 JP to filter prior data correctly for void invoices
CREATE TABLE #ar_inv_invlist( [AR_INV_NBR] integer NULL )
INSERT INTO #ar_inv_invlist
	SELECT arj.AR_INV_NBR
	FROM #draft_jobs dj
	INNER JOIN dbo.ARINV_JOB arj 
		ON dj.JOB_NUMBER = arj.JOB_NUMBER
	INNER JOIN dbo.ACCT_REC ar
	    ON arj.AR_INV_SEQ = ar.AR_INV_SEQ
	    AND arj.AR_INV_NBR = ar.AR_INV_NBR 
	    WHERE arj.AR_INV_DATE <= @ar_inv_date
		AND ar.MANUAL_INV IS NULL
    GROUP BY arj.AR_INV_NBR
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
		f.FNC_TYPE			
	FROM dbo.FUNCTIONS f
	LEFT JOIN dbo.FUNCTIONS f2
		 ON f.FNC_CONSOLIDATION = f2.FNC_CODE
	LEFT JOIN dbo.FNC_HEADING fh 
		ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID
	ORDER BY f.FNC_TYPE, f.FNC_ORDER
--SELECT * FROM #function_codes

--Temporary table to hold a list of billing invoice amounts
CREATE TABLE #bill_invoice_amts( 	
	[DET_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					int NULL,
	[JOB_COMPONENT_NBR]				smallint NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[FNC_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					int NULL,
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
	[IO_COMMENT]					text COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				smallint NULL,
	[BILLING_USER]					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[EMPLOYEE_TITLE_ID]				integer NULL )

--Extracts current detail records for regular (non co-op) invoices
--Accounts Payable												--#07
INSERT INTO #bill_invoice_amts
SELECT 'AP', ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR, 
		j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE,
		ap.FNC_CODE, ap.AR_INV_NBR, ISNULL(ap.AR_INV_SEQ,0), NULL, 
		NULL, SUM(ISNULL(ap.AP_PROD_QUANTITY, 0)), 0, SUM(ap.AP_PROD_EXT_AMT ), 
		SUM(ap.EXT_MARKUP_AMT), ap.TAX_CODE, SUM(ap.EXT_NONRESALE_TAX), SUM(ap.EXT_STATE_RESALE), SUM(ap.EXT_COUNTY_RESALE),			--#15
		SUM(ap.EXT_CITY_RESALE), SUM(ap.LINE_TOTAL), 0, ap.AP_ID, ap.AP_SEQ, ap.LINE_NUMBER, NULL, '0', NULL, NULL, NULL, 0, ap.BILLING_USER, NULL
FROM dbo.AP_PRODUCTION ap 
JOIN #billing_user AS b
	ON b.BILLING_USER = ap.BILLING_USER	
JOIN dbo.JOB_LOG AS j
	ON ap.JOB_NUMBER = j.JOB_NUMBER	
WHERE ISNULL(ap.AP_PROD_NOBILL_FLG,0) = 0
		AND ISNULL(ap.AP_PROD_BILL_HOLD,0) = 0
		--AND ap.AR_INV_SEQ <> 99									--#13
		--AND ap.AR_INV_SEQ IS NOT NULL							--#13
		AND j.BILL_COOP_CODE IS NULL							--#14
GROUP BY ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR, ap.FNC_CODE, ap.AR_INV_NBR, ap.AR_INV_SEQ, ap.AP_ID, 
		ap.AP_SEQ, ap.TAX_CODE, ap.LINE_NUMBER, ap.BILLING_USER, j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE

--Income Only
INSERT INTO #bill_invoice_amts									--#06
SELECT 'IO', ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR, 
		j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE,
		ico.FNC_CODE, ico.AR_INV_NBR, ISNULL(ico.AR_INV_SEQ,0), NULL, 
		NULL, SUM(ISNULL(ico.IO_QTY, 0)), 0, SUM(ico.IO_AMOUNT + ico.EXT_MARKUP_AMT), 0, 
		NULL, 0, SUM(ico.EXT_STATE_RESALE), SUM(ico.EXT_COUNTY_RESALE), SUM(ico.EXT_CITY_RESALE), SUM(ico.LINE_TOTAL), 
		0, 0, 0, 0, ico.IO_ID, ico.IO_INV_NBR, ico.IO_INV_DATE, ico.IO_DESC, NULL, ico.FEE_INVOICE, ico.BILLING_USER, NULL
FROM dbo.INCOME_ONLY ico 
JOIN #billing_user AS b
	ON b.BILLING_USER = ico.BILLING_USER
JOIN dbo.JOB_LOG AS j
	ON ico.JOB_NUMBER =j.JOB_NUMBER		
WHERE ISNULL(ico.BILL_HOLD_FLAG,0) = 0
		--AND ico.AR_INV_SEQ <> 99								--#13
		--AND ico.AR_INV_SEQ IS NOT NULL						--#13
		AND j.BILL_COOP_CODE IS NULL							--#14
GROUP BY ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR, ico.FNC_CODE, ico.AR_INV_NBR, ico.AR_INV_SEQ, ico.IO_ID, ico.IO_INV_NBR, 
		ico.IO_INV_DATE, ico.IO_DESC, ico.FEE_INVOICE, ico.BILLING_USER, j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE

--Advance Billing												--#07
INSERT INTO #bill_invoice_amts
SELECT 'AB', ab.JOB_NUMBER, ab.JOB_COMPONENT_NBR, 
		j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE,
		ab.FNC_CODE, ab.AR_INV_NBR, ISNULL(ab.AR_INV_SEQ,0), NULL, 
		NULL, 0, 0, 
		CASE f.FNC_TYPE											--#06
			WHEN 'V' THEN SUM(ISNULL(ab.LINE_TOTAL,0) - ISNULL(ab.EXT_STATE_RESALE,0) - ISNULL(ab.EXT_COUNTY_RESALE,0) - ISNULL(ab.EXT_CITY_RESALE,0)
				- ISNULL(ab.EXT_MARKUP_AMT,0))
			ELSE SUM(ISNULL(ab.LINE_TOTAL,0) - ISNULL(ab.EXT_STATE_RESALE,0) - ISNULL(ab.EXT_COUNTY_RESALE,0) - ISNULL(ab.EXT_CITY_RESALE,0))
		END,
		CASE f.FNC_TYPE											--#06
			WHEN 'V' THEN SUM(ISNULL(ab.EXT_MARKUP_AMT,0))
			ELSE 0
		END,	 
		ab.TAX_CODE, 0, SUM(ab.EXT_STATE_RESALE), SUM(ab.EXT_COUNTY_RESALE), SUM(ab.EXT_CITY_RESALE), 
		SUM(ab.LINE_TOTAL), 0, 0, 0, 0, NULL, '0', NULL, NULL, NULL, 0, ab.BILLING_USER, NULL
FROM dbo.ADVANCE_BILLING ab 
JOIN #billing_user AS b
	ON b.BILLING_USER = ab.BILLING_USER	
JOIN dbo.JOB_LOG AS j
	ON ab.JOB_NUMBER =j.JOB_NUMBER
JOIN #function_codes f
	ON ab.FNC_CODE = f.FNC_CODE		
--WHERE ab.AR_INV_SEQ <> 99										--#13
--	AND ab.AR_INV_SEQ IS NOT NULL								--#13
WHERE j.BILL_COOP_CODE IS NULL									--#14
GROUP BY ab.JOB_NUMBER, ab.JOB_COMPONENT_NBR, ab.FNC_CODE, ab.AR_INV_NBR, ab.AR_INV_SEQ, ab.TAX_CODE, ab.BILLING_USER,
	j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE, f.FNC_TYPE	

--Employee Time													--#06
INSERT INTO #bill_invoice_amts
SELECT 'ET', etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, 
		j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE,
		etd.FNC_CODE, etd.AR_INV_NBR, ISNULL(etd.AR_INV_SEQ,0), NULL, 
		NULL, SUM(etd.EMP_HOURS), etd.EMP_BILL_RATE, SUM(etd.TOTAL_BILL + etd.EXT_MARKUP_AMT), 0, 
		etd.TAX_CODE, 0, SUM(etd.EXT_STATE_RESALE), SUM(etd.EXT_COUNTY_RESALE), SUM(etd.EXT_CITY_RESALE), 
		SUM(etd.LINE_TOTAL), etd.ET_ID, 0, 0, 0, NULL, '0', NULL, NULL, NULL, 0, etd.BILLING_USER, etd.[EMPLOYEE_TITLE_ID]
FROM dbo.EMP_TIME_DTL etd 
JOIN #billing_user AS b
	ON b.BILLING_USER = etd.BILLING_USER
JOIN dbo.JOB_LOG AS j
	ON etd.JOB_NUMBER =j.JOB_NUMBER		
WHERE ISNULL(etd.BILL_HOLD_FLG,0) = 0							--#11
	--AND etd.AR_INV_SEQ <> 99									--#13
	--AND etd.AR_INV_SEQ IS NOT NULL							--#13
	AND j.BILL_COOP_CODE IS NULL								--#14
GROUP BY etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, etd.FNC_CODE, etd.AR_INV_NBR, etd.AR_INV_SEQ, etd.ET_ID, 
	etd.EMP_BILL_RATE, etd.TAX_CODE, etd.BILLING_USER, etd.[EMPLOYEE_TITLE_ID], j.CL_CODE, j.DIV_CODE, j.PRD_CODE, j.OFFICE_CODE
--SELECT * FROM #bill_invoice_amts

--Extracts current data for co-op invoices from AR_FUNCTION
INSERT INTO #bill_invoice_amts(
	DET_TYPE, [JOB_NUMBER], [JOB_COMPONENT_NBR], 
	[CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], 
	[FNC_CODE], [AR_INV_NBR], [AR_INV_SEQ], [AR_TYPE],
	[AR_INV_DATE], [HRS_QTY], [RATE], [EXT_AMT], [EXT_MARKUP_AMT], 
	[TAX_CODE], [EXT_NONRESALE_TAX], [EXT_STATE_RESALE], [EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], [LINE_TOTAL])
SELECT
	s.FNC_TYPE, s.JOB_NUMBER, s.JOB_COMPONENT_NBR, 
	s.CL_CODE, s.DIV_CODE, s.PRD_CODE, s.OFFICE_CODE, 
	s.FNC_CODE, NULL,	s.DRAFT_INV_SEQ, NULL,
	NULL, s.HRS_QTY, 0,
	CASE s.FNC_TYPE
		WHEN 'V' THEN ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0)- ISNULL(s.AB_COMMISSION_AMT,0)				--#10
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END,
	CASE s.FNC_TYPE																			
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#10
		ELSE 0
	END,
	s.TAX_CODE, 0, ISNULL(s.STATE_TAX_AMT,0), ISNULL(s.CNTY_TAX_AMT,0), ISNULL(s.CITY_TAX_AMT,0), ISNULL(s.TOTAL_BILL,0)
FROM dbo.AR_FUNCTION AS s
WHERE s.DRAFT_INV_SEQ <> 0 AND s.DRAFT_INV_SEQ <> 99
--SELECT * FROM #bill_invoice_amts

--Extracts the prior data from AR_SUMMARY
INSERT INTO #bill_invoice_amts(
	DET_TYPE, [JOB_NUMBER], [JOB_COMPONENT_NBR], 
	[CL_CODE], [DIV_CODE], [PRD_CODE], [OFFICE_CODE], 
	[FNC_CODE], [AR_INV_NBR], [AR_INV_SEQ], [AR_TYPE],
	[AR_INV_DATE], [HRS_QTY], [RATE], [EXT_AMT], [EXT_MARKUP_AMT], 
	[TAX_CODE], [EXT_NONRESALE_TAX], [EXT_STATE_RESALE], [EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], [LINE_TOTAL])
SELECT
	f.FNC_TYPE, s.JOB_NUMBER, s.JOB_COMPONENT_NBR, 
	s.CL_CODE, s.DIV_CODE, s.PRD_CODE, s.OFFICE_CODE, 
	s.FNC_CODE, s.AR_INV_NBR, s.AR_INV_SEQ, s.AR_TYPE,
	d.AR_INV_DATE, s.HRS_QTY, 0,
	CASE f.FNC_TYPE
		WHEN 'V' THEN ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0)
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END, 
	CASE s.FNC_TYPE																			
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#10
		ELSE 0
	END,
	s.TAX_CODE, 0, 	ISNULL(s.STATE_TAX_AMT,0), 	ISNULL(s.CNTY_TAX_AMT,0),
	ISNULL(s.CITY_TAX_AMT,0), ISNULL(s.TOTAL_BILL,0)
FROM dbo.AR_SUMMARY AS s
JOIN dbo.V_AR_INVOICE_DATES AS d
	ON s.AR_INV_NBR = d.AR_INV_NBR
	AND s.AR_TYPE = d.AR_TYPE	
JOIN #draft_jobs AS dj
	ON s.JOB_NUMBER = dj.JOB_NUMBER
JOIN dbo.FUNCTIONS AS f
	ON s.FNC_CODE = f.FNC_CODE	
WHERE s.AR_INV_SEQ <> 99
--SELECT * FROM #bill_invoice_amts

-- Main temp table used to populate "PROD_BILLING_DATA" with billing amounts
CREATE TABLE #billing_table_with_seq_mt_query( 	
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]				integer NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
				bia.DIV_CODE,
				bia.PRD_CODE,
				bia.OFFICE_CODE, 
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
				bia.RATE,										--CAST( 0 AS decimal( 15,2 )) AS [Rate], 
				bia.EXT_AMT,									-- + bia.EXT_NONRESALE_TAX,		--#04, #17
				bia.EXT_MARKUP_AMT, 
				bia.TAX_CODE, 
				bia.EXT_NONRESALE_TAX,							--bia.EXT_NONRESALE_TAX,	--#04, #16
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
					btwsmq.CL_CODE,
					btwsmq.DIV_CODE,
					btwsmq.PRD_CODE,
					btwsmq.OFFICE_CODE,
					btwsmq.[Std Function Code],
					btwsmq.[Function Code Type], 
					btwsmq.[Function Code],
					NULL,		--btwsmq.[Consol Fnc Code], 
					NULL,		--btwsmq.PrdConsol, 
					dj.AR_INV_NBR,																	--#13
					dj.BU_INV_NBR,
					'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
						RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),					--#13, #18
					btwsmq.AR_INV_SEQ,																
					CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#13					
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
					0,
					NULL,
					btwsmq.[EMPLOYEE_TITLE_ID]
			FROM #billing_table_with_seq_mt_query AS btwsmq
			JOIN #draft_joblist dj																--#22
				ON btwsmq.JOB_NUMBER = dj.JOB_NUMBER
				AND (@all_comp_amt <> 0 OR btwsmq.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)		--#22
			WHERE btwsmq.AR_INV_NBR IS NULL
--SELECT * FROM dbo.PROD_BILLING_DATA      

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
				btwsmq.CL_CODE,
				btwsmq.DIV_CODE,
				btwsmq.PRD_CODE,
				btwsmq.OFFICE_CODE,
				btwsmq.[Std Function Code], 
				btwsmq.[Function Code Type],
				btwsmq.[Function Code],
				btwsmq.[Consol Fnc Code], 
				btwsmq.[PrdConsol], 
				dj.AR_INV_NBR,																	--#13
				dj.BU_INV_NBR,
				'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
					RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),						--#13, #19
				btwsmq.AR_INV_SEQ,																
				CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#13,
				NULL,		
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
		FROM #billing_table_with_seq_mt_query AS btwsmq
		JOIN #ar_inv_invlist arj															--JP 10/31/11 to filter voids
			ON btwsmq.AR_INV_NBR = arj.AR_INV_NBR		
		JOIN #draft_joblist dj																--#21, #22
			ON btwsmq.JOB_NUMBER = dj.JOB_NUMBER
			AND (@all_comp_amt <> 0 OR btwsmq.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)		--#21, #221					
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
		INNER JOIN #draft_joblist dj															--#25
				ON ea.JOB_NUMBER = dj.JOB_NUMBER												--#25
				AND (@all_comp_amt <> 0 OR ea.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)			--#25
		GROUP BY ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, erd.FNC_CODE
		--SELECT * FROM #bill_estimate_amts		

-- Populate "PROD_BILLING_DATA" with estimate amounts, enter full estimate for each co-op split
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
				dj.CL_CODE,
				dj.DIV_CODE,
				dj.PRD_CODE,
				dj.OFFICE_CODE,
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
				dj.AR_INV_NBR,
				dj.BU_INV_NBR,
				'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
					RIGHT('0000' + CAST(dj.BU_INV_SEQ AS varchar(4)),4),							--#13, #19
				dj.BU_INV_SEQ,
				CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(dj.BU_INV_SEQ AS varchar(2)),			--#13
				NULL,	--@ar_inv_date,
				bea.EST_REV_QUANTITY,
				--bea.EST_REV_EXT_AMT, 
				--bea.EST_REV_EXT_MARKUP_AMT, 
				--bea.EST_REV_EXT_NONRESALE_TAX, 
				CASE f.FNC_TYPE										--#08
					WHEN 'V' THEN bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE - bea.EST_REV_EXT_MARKUP_AMT - bea.EST_REV_EXT_NONRESALE_TAX		--#15
					ELSE bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE	
				END,
				CASE f.FNC_TYPE										--#08								
					WHEN 'V' THEN bea.EST_REV_EXT_MARKUP_AMT
					ELSE 0
				END,
				bea.EST_REV_EXT_NONRESALE_TAX,													--#08, #15
				bea.EST_REV_EXT_CITY_RESALE, 
				bea.EST_REV_EXT_COUNTY_RESALE, 
				bea.EST_REV_EXT_STATE_RESALE, 
				bea.EST_REV_LINE_TOTAL,
				0 AS [Estimate Total NC]	
	 	FROM #bill_estimate_amts bea
		JOIN #draft_joblist_with_seq dj																--#25, #26
				ON bea.JOB_NUMBER = dj.JOB_NUMBER													--#25
				AND (@all_comp_amt <> 0 OR bea.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)			--#25
	 	JOIN dbo.PRODUCT p
				ON dj.CL_CODE = p.CL_CODE
				AND dj.DIV_CODE = p.DIV_CODE
				AND dj.PRD_CODE = p.PRD_CODE
	 	JOIN #function_codes f
				ON bea.FNC_CODE = f.FNC_CODE
end_tran:

--SELECT * FROM dbo.PROD_BILLING_DATA WHERE [USER_ID] = 'SYSADM'

DROP TABLE #bill_invoice_amts
DROP TABLE #billing_table_with_seq_mt_query
DROP TABLE #draft_joblist
DROP TABLE #bill_estimate_amts
GO

GRANT EXECUTE ON usp_grant_execute_on_sp_to_public TO PUBLIC
EXEC usp_grant_execute_on_sp_to_public

