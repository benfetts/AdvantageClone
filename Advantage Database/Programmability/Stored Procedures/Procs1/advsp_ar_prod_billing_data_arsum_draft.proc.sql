IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_prod_billing_data_arsum_draft]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_prod_billing_data_arsum_draft]
GO

CREATE PROCEDURE [dbo].[advsp_ar_prod_billing_data_arsum_draft] 
	@all_comp_amt tinyint = 0,			--#20
	@user_id varchar(100)

AS
SET NOCOUNT ON

 -- ==========================================================================
 -- advsp_ar_prod_billing_data - ARSUM DRAFT
 -- #00 08/17/12 - v650 initial - based on (#08 12/21/11)
 -- #07 04/01/13 - v660 added CDP and OFFICE codes
 -- #08 04/02/13 - v660 added DRAFT_INV_SEQ and corrected CDP codes to come from SUMMARY/FUNCTION tables, not job log
 -- #09 05/02/13 - v660 enabled HRS_QTY
 -- #10 05/13/13 - v660 fixes for co-op billing, plus new #draft_joblist_with_seq, clean up code
 -- #11 08/15/13 - v660 clean up code
 -- #12 08/15/13 - v660 set estimate EXT_NONRESALE_TAX to 0, and include in net amount
 -- #13 08/16/13 - v660 advance billing fix for amounts
 -- #14 08/21/13 - v660 more advance billing fixes
 -- #15 11/26/13 - v660 Redo to use AR_INV_NBR from AR_FUNCTION
 -- #16 03/06/14 - v660 fixed @use_function_opt - should not get value from RPT_RUNTIME_SPECS but V_PROD_INV_DEF
 -- #17 03/13/14 - v660 separated vendor tax (NON_RESALE_AMT and AB_NONRESALE_AMT) from net amount
 -- #18 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
 -- #19 07/08/14 - v660 re-dimensioned sequence number to (4) digits 522-308) - fix for prior and estimate data
 -- #20 09/22/14 - v660 enabled all component amounts from v650 (661-61)
 -- #21 09/30/14 - v660 fix - enabled all component amounts (661-61)
 -- #22 10/01/14 - v660 fix (2)-(661-61)
 -- #23 07/25/15 - v660 fix (3)- @all_comp_amt filter needed to be added to estimate amounts (302-621)
 -- #24 10/22/15 - v660 fix (4)- revert to old #draft_joblist for current/prior data and #draft_joblist_with_seq for estimate
 -- #25 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
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

SELECT * INTO #ar_prod_inv_def FROM [dbo].[advtf_ar_prod_inv_def](@user_id)

--SELECT * FROM #ar_prod_inv_def

-- Clears data records for this USER_ID from the main data table
DELETE dbo.PROD_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'PI'	--#25

-- This variable is for later use: 0 = bill hist for cur job/comp only, 1 = alljob/comps			--#20
--DECLARE @all_comp_amt tinyint
--SET @all_comp_amt = 0
--SELECT @all_comp_amt

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @ar_inv_date

---- Determines whether to use std on consol function
--DECLARE @use_function_opt tinyint
--SELECT @use_function_opt = FUNCTION_OPT FROM dbo.RPT_RUNTIME_SPECS WHERE [USER_ID] = @user_id AND APP_TYPE = 'PI'
----SELECT @use_function_opt

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
	[AR_INV_NBR]					integer NULL)						--#15
INSERT INTO #draft_joblist_with_seq
SELECT DISTINCT 
	--dbo.fn_billing_user_invoice_number(af.INV_BY, af.CL_CODE, af.DIV_CODE, af.PRD_CODE,
	--	af.SC_CODE, af.CMP_IDENTIFIER, af.CLIENT_PO, af.JOB_NUMBER, af.JOB_COMPONENT_NBR),
	af.DRAFT_INV_NBR,
	af.DRAFT_INV_SEQ,
	af.CL_CODE,
	af.DIV_CODE,
	af.PRD_CODE,
	af.OFFICE_CODE,	
	af.JOB_NUMBER,
	--af.JOB_COMPONENT_NBR,
	CASE @all_comp_amt													--#22, #24
		WHEN 0 THEN af.JOB_COMPONENT_NBR
		ELSE 0
	END,
	af.AR_INV_NBR
FROM dbo.AR_FUNCTION AS af
JOIN #billing_user AS bu
	ON af.BILLING_USER  = bu.BILLING_USER
--SELECT * FROM #draft_joblist_with_seq

-- Temporary table to hold a list of all jobs/comps using a list of billing users	#04
-- From version #22 reinstated in #24, to replace the incorrect changes in #23
CREATE TABLE #draft_joblist( 
	[JOB_NUMBER]					integer NULL, 
	[JOB_COMPONENT_NBR]				smallint NULL,
	[BU_INV_NBR]					varchar(100) NULL,
	[AR_INV_NBR]					integer NULL)						--#15
INSERT INTO #draft_joblist 
SELECT DISTINCT 
	af.JOB_NUMBER, 
	CASE @all_comp_amt													--#22
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

-- Temporary table to hold a list of invoices the jobs above appear on
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
		COALESCE(f2.FNC_TYPE, f.FNC_TYPE, f.FNC_TYPE)
	FROM dbo.FUNCTIONS f
	LEFT JOIN dbo.FUNCTIONS f2
		 ON f.FNC_CONSOLIDATION = f2.FNC_CODE
	LEFT JOIN dbo.FNC_HEADING fh 
		ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID
	ORDER BY f.FNC_TYPE, f.FNC_ORDER
--SELECT * FROM #function_codes

--Temporary table to hold billing invoice amounts
CREATE TABLE #bill_invoice_amts( 	
	[DET_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]				smallint NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[FNC_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					integer NULL,
	[AR_INV_SEQ]					smallint NULL,
	[AR_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_DATE]					smalldatetime NULL,
	[HRS_QTY]						decimal(15,2) NULL,
	[RATE]							decimal(15,2) NULL, 
	[EXT_AMT]			 			decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
	[IO_INV_NBR]					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_INV_DATE]					smalldatetime NULL,
	[IO_DESC]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				smallint NULL,
	[EMPLOYEE_TITLE_ID]				integer NULL)

-- Current data for draft billing,regular and co-op invoices, uses AR_FUNCTION
INSERT INTO #bill_invoice_amts(
	DET_TYPE,
	[JOB_NUMBER],
	[JOB_COMPONENT_NBR],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[OFFICE_CODE],
	[FNC_CODE],
	[AR_INV_NBR],
	[AR_INV_SEQ],
	[AR_TYPE],
	[AR_INV_DATE],
	[HRS_QTY],
	[RATE], 
	[EXT_AMT], 
	[EXT_MARKUP_AMT], 
	[TAX_CODE], 
	[EXT_NONRESALE_TAX], 
	[EXT_STATE_RESALE], 
	[EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], 
	[LINE_TOTAL])
SELECT
	s.FNC_TYPE,
	s.JOB_NUMBER,
	s.JOB_COMPONENT_NBR,
	s.CL_CODE,
	s.DIV_CODE,
	s.PRD_CODE,
	s.OFFICE_CODE,
	s.FNC_CODE,
	NULL,	--s.AR_INV_NBR,
	s.DRAFT_INV_SEQ,			--#08
	NULL,	--s.AR_TYPE,
	NULL,	--d.AR_INV_DATE,
	s.HRS_QTY,					--#09
	0,
	CASE f.FNC_TYPE
		WHEN 'V' THEN ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0) - ISNULL(s.AB_COMMISSION_AMT,0)			--#13
			- ISNULL(s.NON_RESALE_AMT,0) - ISNULL(s.AB_NONRESALE_AMT,0)										--#17
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END,
	CASE f.FNC_TYPE										--#11									
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#13
		ELSE 0
	END,
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0) + ISNULL(s.AB_NONRESALE_AMT,0),												--#17
	ISNULL(s.STATE_TAX_AMT,0),
	ISNULL(s.CNTY_TAX_AMT,0),
	ISNULL(s.CITY_TAX_AMT,0),
	ISNULL(s.TOTAL_BILL,0)
FROM dbo.AR_FUNCTION AS s
JOIN dbo.FUNCTIONS AS f
	ON s.FNC_CODE = f.FNC_CODE	
--SELECT * FROM #bill_invoice_amts

--Insert the data for prior INVOICE billing, all invoices uses AR_SUMMARY
INSERT INTO #bill_invoice_amts(
	DET_TYPE,
	[JOB_NUMBER],
	[JOB_COMPONENT_NBR],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[OFFICE_CODE],
	[FNC_CODE],
	[AR_INV_NBR],
	[AR_INV_SEQ],
	[AR_TYPE],
	[AR_INV_DATE],
	[HRS_QTY],
	[RATE], 
	[EXT_AMT], 
	[EXT_MARKUP_AMT], 
	[TAX_CODE], 
	[EXT_NONRESALE_TAX], 
	[EXT_STATE_RESALE], 
	[EXT_COUNTY_RESALE], 
	[EXT_CITY_RESALE], 
	[LINE_TOTAL])
SELECT
	f.FNC_TYPE,
	s.JOB_NUMBER,
	s.JOB_COMPONENT_NBR,
	s.CL_CODE,
	s.DIV_CODE,
	s.PRD_CODE,
	s.OFFICE_CODE,
	s.FNC_CODE,
	s.AR_INV_NBR,
	s.AR_INV_SEQ,
	s.AR_TYPE,
	d.AR_INV_DATE,
	s.HRS_QTY,
	0,
	CASE f.FNC_TYPE
		WHEN 'V' THEN ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0) - ISNULL(s.AB_COMMISSION_AMT,0)			--#14			
			- ISNULL(s.NON_RESALE_AMT,0) - ISNULL(s.AB_NONRESALE_AMT,0)										--#17
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END,
	CASE f.FNC_TYPE										--#11									
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#14
		ELSE 0
	END,
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0) + ISNULL(s.AB_NONRESALE_AMT,0),												--#17
	s.STATE_TAX_AMT,
	s.CNTY_TAX_AMT,
	s.CITY_TAX_AMT,
	s.TOTAL_BILL
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

-- Main data table used to populate "PROD_BILLING_DATA" with billing amounts
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
	[Item]							varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item Date]						smalldatetime NULL, 
	[Item Detail]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	 		
	[AP_DESC]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[HRS_QTY]						decimal(15,2) NULL, 
	[RATE]							decimal(15,2) NULL, 
	[EXT_AMT]						decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
				CASE															--#16
					WHEN vp.FNC_FNC_CODE = 3 OR (vp.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code Type],
				CASE															--#16
					WHEN vp.FNC_FNC_CODE = 3 OR (vp.FNC_FNC_CODE = 1 AND
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
				bia.RATE,			--CAST( 0 AS decimal( 15,2 )) AS [Rate], 
				bia.EXT_AMT, 
				bia.EXT_MARKUP_AMT, 
				bia.TAX_CODE, 
				bia.EXT_NONRESALE_TAX, 
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
		JOIN dbo.#ar_prod_inv_def AS vp
			ON bia.CL_CODE = vp.CL_CODE	
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
					dj.AR_INV_NBR,																	--#15
					dj.BU_INV_NBR,
					'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
						RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),					--#15, #18
					btwsmq.AR_INV_SEQ,																--#08
					CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#15					
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
				NULL,		--btwsmq.[Consol Fnc Code], 
				NULL,		--btwsmq.[PrdConsol], 
				dj.AR_INV_NBR,																		--#15
					dj.BU_INV_NBR,
					'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
						RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)),4),						--#15, #19
					btwsmq.AR_INV_SEQ,																--#08
					CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(btwsmq.AR_INV_SEQ AS varchar(2)),		--#15
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
		FROM #billing_table_with_seq_mt_query btwsmq
		JOIN #draft_joblist dj																--#21, #22
			ON btwsmq.JOB_NUMBER = dj.JOB_NUMBER
			AND (@all_comp_amt <> 0 OR btwsmq.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)		--#21, #22
		WHERE btwsmq.AR_INV_NBR IS NOT NULL
		
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
		INNER JOIN #draft_joblist dj															--#23
				ON ea.JOB_NUMBER = dj.JOB_NUMBER												--#23
				AND (@all_comp_amt <> 0 OR ea.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)			--#23
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
				dj.CL_CODE,
				dj.DIV_CODE,
				dj.PRD_CODE,
				dj.OFFICE_CODE,
				bea.FNC_CODE,
				CASE																			--#16
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code],
				CASE																			--#16
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
					ELSE bea.FNC_CODE
				END AS [Function Code],
				NULL,		--[Consol Fnc Code] = f.CONSOL_FNC,
				NULL,		--COALESCE( p.PRD_CONSOL_FUNC, '0' ) AS [PrdConsol], 
				dj.AR_INV_NBR,
				dj.BU_INV_NBR,
				'DRAFT ' + RIGHT('0000000' + CAST(dj.AR_INV_NBR AS varchar(7)),6) + '-' + 
					RIGHT('0000' + CAST(dj.BU_INV_SEQ AS varchar(4)),4),							--#15, #19
				dj.BU_INV_SEQ,
				CAST(dj.AR_INV_NBR AS varchar(7)) + CAST(dj.BU_INV_SEQ AS varchar(2)),			--#15
				NULL,	--@ar_inv_date,
				bea.EST_REV_QUANTITY, 
				CASE f.FNC_TYPE										--#12
					WHEN 'V' THEN bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE - bea.EST_REV_EXT_MARKUP_AMT - bea.EST_REV_EXT_NONRESALE_TAX		--#17
					ELSE bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE	
				END,
				CASE f.FNC_TYPE										--#12								
					WHEN 'V' THEN bea.EST_REV_EXT_MARKUP_AMT
					ELSE 0
				END,
				bea.EST_REV_EXT_NONRESALE_TAX,													--#12, #17 
				bea.EST_REV_EXT_CITY_RESALE, 
				bea.EST_REV_EXT_COUNTY_RESALE, 
				bea.EST_REV_EXT_STATE_RESALE, 
				bea.EST_REV_LINE_TOTAL,
				0 AS [Estimate Total NC]	
	 	FROM #bill_estimate_amts bea
		JOIN #draft_joblist_with_seq dj																--#23, #24
				ON bea.JOB_NUMBER = dj.JOB_NUMBER													--#23
				AND (@all_comp_amt <> 0 OR bea.JOB_COMPONENT_NBR = dj.JOB_COMPONENT_NBR)			--#23
	 	JOIN dbo.PRODUCT p
				ON dj.CL_CODE = p.CL_CODE
				AND dj.DIV_CODE = p.DIV_CODE
				AND dj.PRD_CODE = p.PRD_CODE
	 	JOIN #function_codes f
				ON bea.FNC_CODE = f.FNC_CODE
		JOIN dbo.#ar_prod_inv_def AS v															--#16
			ON dj.CL_CODE = v.CL_CODE	
end_tran:
	
--SELECT * FROM dbo.PROD_BILLING_DATA WHERE [USER_ID] = 'SYSADM'

DROP TABLE #bill_invoice_amts
DROP TABLE #billing_table_with_seq_mt_query
DROP TABLE #draft_joblist
DROP TABLE #ar_inv_invlist
DROP TABLE #bill_estimate_amts
DROP TABLE #draft_joblist_with_seq
GO

GRANT EXECUTE ON advsp_ar_prod_billing_data_arsum_draft TO PUBLIC
EXEC usp_grant_execute_on_sp_to_public

