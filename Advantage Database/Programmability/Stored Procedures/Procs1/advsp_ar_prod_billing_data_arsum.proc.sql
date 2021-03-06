IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_ar_prod_billing_data_arsum]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_ar_prod_billing_data_arsum]
GO

CREATE PROCEDURE [dbo].[advsp_ar_prod_billing_data_arsum] 
	@all_comp_amt tinyint = 0,			--#17
	@user_id varchar(100)

AS
SET NOCOUNT ON

-- ============================================================================
-- advsp_ar_prod_billing_data_arsum ARSUM
-- populates table PROD_BILLING_DATA
-- #00 08/17/12 - v650 initial - based on (#08 12/21/11)
-- #05 03/31/13 - v660 added CDP and OFFICE codes
-- #06 04/02/13 - v660 added filter for AR_INV_SEQ <> 99
-- #07 05/07/13 - v660 corrected entry location for std function in prior amunts
-- #08 05/08/13 - v660 fixes for co-op billing, plus new #estimate_seq_nbrs
-- #09 05/13/13 - v660 clean up code
-- #10 08/15/13 - v660 clean up code
-- #11 08/15/13 - v660 set estimate EXT_NONRESALE_TAX to 0, and include in net amount
-- #12 08/21/13 - v660 fixes for advances billing amounts
-- #13 03/06/14 - v660 fixed @use_function_opt - should not get value from RPT_RUNTIME_SPECS but V_PROD_INV_DEF
-- #14 03/13/14 - v660 separated vendor tax (NON_RESALE_AMT and AB_NONRESALE_AMT) from net amount
-- #15 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308)
-- #16 07/01/14 - v660 re-dimensioned sequence number to (4) digits 522-308) - fix for prior  and estimate data
-- #17 09/22/14 - v660 enabled all component amounts from v650 (661-61)
-- #18 02/23/16 - v660/v670 changes to enable type "C invoices
-- #19 10/15/16 - v660/v670 removed case sensitivity for [USER_ID] via "SQL_Latin1_General_CP1_CI_AS" (344-1371)
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

SELECT * INTO #ar_prod_inv_def FROM [dbo].[advtf_ar_prod_inv_def](@user_id)

-- Clears data records for this USER_ID from the main data table
DELETE dbo.PROD_BILLING_DATA WHERE UPPER([USER_ID]) COLLATE SQL_Latin1_General_CP1_CI_AS = UPPER(@user_id) AND APP_TYPE = 'PI'	--@19

-- This variable is for later use: 0 = bill hist for cur job/comp only, 1 = alljob/comps	--#17
--DECLARE @all_comp_amt tinyint
--SET @all_comp_amt = 0
----SELECT @all_comp_amt

-- Gets the invoice date for use in setting "prior" amounts
DECLARE @ar_inv_date smalldatetime
SELECT @ar_inv_date = SEL_DATE FROM dbo.RPT_RUNTIME_SPECS WHERE UPPER([USER_ID]) = UPPER(@user_id) AND APP_TYPE = 'PI'
--SELECT @ar_inv_date

---- Determines whether to use std on consol function
--DECLARE @use_function_opt tinyint
--SELECT @use_function_opt = FUNCTION_OPT FROM dbo.RPT_RUNTIME_SPECS WHERE [USER_ID] = @user_id AND APP_TYPE = 'PI'
----SELECT @use_function_opt

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
	JOIN dbo.RPT_SEL_NBRS AS i
		ON arj.AR_INV_NBR = i.AR_INV_NBR
	WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)														--#05
		AND i.APP_TYPE = 'PI'
END
ELSE
BEGIN
INSERT INTO #ar_list_all
	SELECT DISTINCT i.AR_INV_NBR, arj.JOB_NUMBER, jc.JOB_COMPONENT_NBR
	FROM dbo.ARINV_JOB arj
	JOIN dbo.RPT_SEL_NBRS AS i
		ON arj.AR_INV_NBR = i.AR_INV_NBR
	JOIN dbo.JOB_COMPONENT AS jc
		ON arj.JOB_NUMBER = jc.JOB_NUMBER
	WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)														--#05
		AND i.APP_TYPE = 'PI'
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

-- Temporary table to hold a list of invoices the jobs above appear on					--#05
CREATE TABLE #ar_inv_invlist( 
	[AR_INV_NBR]					integer NULL,
	[CL_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[DIV_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRD_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[OFFICE_CODE]					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS )

INSERT INTO #ar_inv_invlist
	SELECT DISTINCT arj.AR_INV_NBR,
		ar.CL_CODE,																		--#05
		ar.DIV_CODE,																	--#05
		ar.PRD_CODE,																	--#05
		ar.OFFICE_CODE																	--#05
	FROM #ar_inv_joblist arinvjob
	INNER JOIN dbo.ARINV_JOB arj 
		ON arinvjob.JOB_NUMBER = arj.JOB_NUMBER
		AND arinvjob.JOB_COMPONENT_NBR = arj.JOB_COMPONENT_NBR
	INNER JOIN dbo.ACCT_REC ar
	    ON arj.AR_INV_SEQ = ar.AR_INV_SEQ
	    AND arj.AR_INV_NBR = ar.AR_INV_NBR 
	    WHERE arj.AR_INV_DATE <= @ar_inv_date
		AND ar.MANUAL_INV IS NULL
    GROUP BY arj.AR_INV_NBR, ar.CL_CODE, ar.DIV_CODE, ar.PRD_CODE, ar.OFFICE_CODE		--#05
		HAVING MAX( ar.AR_TYPE ) <> 'VO'
--SELECT * FROM #ar_inv_invlist

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
JOIN dbo.ACCT_REC AS s
	ON arl.AR_INV_NBR = s.AR_INV_NBR
WHERE s.AR_INV_SEQ <> 99	
--SELECT * FROM #estimate_seq_nbrs	

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
	[IO_INV_NBR]					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_INV_DATE]					smalldatetime NULL,
	[IO_DESC]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				smallint NULL,
	[EMPLOYEE_TITLE_ID]				integer NULL)

-- Source data is AR_SUMMARY for current and prior, regular and co-op invoices
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
			- ISNULL(s.CITY_TAX_AMT,0) - ISNULL(s.COMMISSION_AMT,0) - ISNULL(s.AB_COMMISSION_AMT,0)			--#12
			- ISNULL(s.NON_RESALE_AMT,0) - ISNULL(s.AB_NONRESALE_AMT,0)										--#14
		ELSE ISNULL(s.TOTAL_BILL,0) - ISNULL(s.STATE_TAX_AMT,0) - ISNULL(s.CNTY_TAX_AMT,0)
			- ISNULL(s.CITY_TAX_AMT,0)	
	END,
	CASE f.FNC_TYPE										--#10									
		WHEN 'V' THEN ISNULL(s.COMMISSION_AMT,0) + ISNULL(s.AB_COMMISSION_AMT,0)							--#12
		ELSE 0
	END,
	s.TAX_CODE,
	ISNULL(s.NON_RESALE_AMT,0) + ISNULL(s.AB_NONRESALE_AMT,0),												--#14 (used to be 0)
	ISNULL(s.STATE_TAX_AMT,0),
	ISNULL(s.CNTY_TAX_AMT,0),
	ISNULL(s.CITY_TAX_AMT,0),
	ISNULL(s.TOTAL_BILL,0)
FROM dbo.AR_SUMMARY AS s
JOIN dbo.V_AR_INVOICE_DATES AS d
	ON s.AR_INV_NBR = d.AR_INV_NBR
	AND s.AR_TYPE = d.AR_TYPE	
JOIN #ar_inv_invlist ai
	ON s.AR_INV_NBR = ai.AR_INV_NBR
JOIN dbo.FUNCTIONS AS f
	ON s.FNC_CODE = f.FNC_CODE	
WHERE s.AR_INV_SEQ <> 99			--#06	
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
	[Item]							varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
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
				--CASE
				--	WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
				--		p.PRD_CONSOL_FUNC = 1) THEN 'C'
				--	ELSE 'S'
				--END AS [Function Code Type],
				--CASE
				--	WHEN @use_function_opt = 3 OR (@use_function_opt = 1 AND
				--		p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
				--	ELSE bia.FNC_CODE
				--END AS [Function Code],
				CASE														--#13
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code Type],
				CASE														--#13
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
					ELSE bia.FNC_CODE
				END AS [Function Code],
				f.CONSOL_FNC AS [Consol Fnc Code],
				ISNULL(p.PRD_CONSOL_FUNC, '0') AS [PrdConsol],		
				bia.AR_INV_NBR, 
				bia.AR_INV_SEQ,
				bia.AR_INV_DATE,
				bia.DET_TYPE AS [Item Type],
				NULL AS [Item Id],									
				NULL AS [ItemSeq Nbr],
				NULL AS [Item Line Nbr],
				NULL AS [Item Code],
				NULL AS [Item],				 
				NULL AS [Item Date],				 				 
				NULL AS [Item Detail],
				NULL AS AP_DESC, 
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
				NULL AS IO_FEE_INVOICE,
				NULL AS EMPLOYEE_TITLE_ID
		FROM #bill_invoice_amts AS bia 
		JOIN dbo.JOB_LOG AS jl
			ON bia.JOB_NUMBER = jl.JOB_NUMBER
		JOIN dbo.PRODUCT AS p
			ON jl.CL_CODE = p.CL_CODE
			AND jl.DIV_CODE = p.DIV_CODE
			AND jl.PRD_CODE = p.PRD_CODE
		JOIN #function_codes f
			ON bia.FNC_CODE = f.FNC_CODE
		JOIN dbo.#ar_prod_inv_def AS v
			ON bia.CL_CODE = v.CL_CODE	
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
					btwsmq.[CL_CODE],
					btwsmq.[DIV_CODE],
					btwsmq.[PRD_CODE],
					btwsmq.[OFFICE_CODE], 
					btwsmq.[Std Function Code],
					btwsmq.[Function Code Type], 
					btwsmq.[Function Code],
					NULL,		--btwsmq.[Consol Fnc Code], 
					NULL,		--btwsmq.PrdConsol, 
					btwsmq.AR_INV_NBR, 
					CAST( btwsmq.AR_INV_NBR AS varchar(12)),
					RIGHT('000000' + CAST(btwsmq.AR_INV_NBR AS varchar(6)), 6) + '-' + 
						RIGHT('0000' + CAST(btwsmq.AR_INV_SEQ AS varchar(4)), 4),					--#15
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
					AND btwsmq.CL_CODE = i.CL_CODE			--#08
			WHERE UPPER(i.[USER_ID]) = UPPER(@user_id)
					AND i.APP_TYPE = 'PI'					--#18
--SELECT * FROM dbo.PROD_BILLING_DATA      

--[Prior Filter by Job Number] select query to identify qualifying invoice numbers for prior data for selected invoices to print
CREATE TABLE #prior_filter_by_job ( 
	AR_INV_NBR 				integer NULL,
	JOB_NUMBER				integer NULL,
	JOB_COMPONENT_NBR		integer NULL,
	AR_INV_DATE 			smalldatetime NULL)
INSERT INTO #prior_filter_by_job
		SELECT DISTINCT
				bia.AR_INV_NBR,
				bia.JOB_NUMBER, 
				CASE @all_comp_amt
					WHEN 0 THEN bia.JOB_COMPONENT_NBR
					ELSE 0
				END	, 
				bia.AR_INV_DATE
		FROM #bill_invoice_amts bia
		JOIN dbo.RPT_SEL_NBRS AS i
				ON bia.AR_INV_NBR = i.AR_INV_NBR	
		GROUP BY bia.AR_INV_NBR,
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
				btwsmq.[CL_CODE],
				btwsmq.[DIV_CODE],
				btwsmq.[PRD_CODE],
				btwsmq.[OFFICE_CODE],
				btwsmq.[Std Function Code],				--#07
				btwsmq.[Function Code Type],
				btwsmq.[Function Code],
				NULL,		--btwsmq.[Consol FncCode], 
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
				CASE															--#13
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN 'C'
					ELSE 'S'
				END AS [Function Code],
				CASE															--#13
					WHEN v.FNC_FNC_CODE = 3 OR (v.FNC_FNC_CODE = 1 AND
						p.PRD_CONSOL_FUNC = 1) THEN f.CONSOL_FNC
					ELSE bea.FNC_CODE
				END AS [Function Code],
				NULL,		--[Consol Fnc Code] = f.CONSOL_FNC,
				NULL,		--COALESCE( p.PRD_CONSOL_FUNC, '0' ) AS [PrdConsol], 
				arl.AR_INV_NBR,
				CONVERT( varchar(12), arl.AR_INV_NBR ),
				RIGHT('000000' + CAST(arl.AR_INV_NBR AS varchar(6)), 6) + '-' + 
					RIGHT('0000' + CAST(arl.AR_INV_SEQ AS varchar(4)), 4),												--#16
				arl.AR_INV_SEQ,	
				CONVERT( varchar(12), arl.AR_INV_NBR ) + CONVERT( varchar(4), arl.AR_INV_SEQ ),	
				@ar_inv_date,
				bea.EST_REV_QUANTITY,				
				CASE f.FNC_TYPE										--#11
					WHEN 'V' THEN bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE - bea.EST_REV_EXT_MARKUP_AMT - bea.EST_REV_EXT_NONRESALE_TAX			--#14
					ELSE bea.EST_REV_LINE_TOTAL - bea.EST_REV_EXT_STATE_RESALE - bea.EST_REV_EXT_COUNTY_RESALE
						- bea.EST_REV_EXT_CITY_RESALE	
				END,
				CASE f.FNC_TYPE										--#11								
					WHEN 'V' THEN bea.EST_REV_EXT_MARKUP_AMT
					ELSE 0
				END,
				bea.EST_REV_EXT_NONRESALE_TAX,													--#11, #14 
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
		JOIN dbo.#ar_prod_inv_def AS v									--#13
			ON arl.CL_CODE = v.CL_CODE	
end_tran:

SELECT * FROM dbo.PROD_BILLING_DATA

DROP TABLE #bill_invoice_amts
DROP TABLE #prior_filter_by_job
DROP TABLE #billing_table_with_seq_mt_query
DROP TABLE #ar_inv_joblist
DROP TABLE #ar_inv_invlist
DROP TABLE #bill_estimate_amts
DROP TABLE #estimate_seq_nbrs
GO


