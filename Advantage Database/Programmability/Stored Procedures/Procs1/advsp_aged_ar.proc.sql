IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_aged_ar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_aged_ar]
GO

CREATE PROCEDURE [dbo].[advsp_aged_ar] (@office_list varchar(4000) = NULL, @end_period varchar(6) = '999912')
AS
--Stored procedure to extract Aged AR information
-- #00 11/03/09 - initial release
-- #00 12/16/09 - added "HAVING ABS(SUM(ISNULL(d.AR_INV_AMOUNT,0))) >= .01" to aged ar (may not be correct, but ties with Adassist)
-- #00 01/04/10 - added office filter based on GLACODE, similar to AP
-- #00 01/04/10 - added "on account" to the sp, to use GLACODE's
-- #01 01/20/10 - added GLACODE to the SELECT statement
-- #02 08/27/10 - added DUE_DATE to calculated due date and added column INV_CAT
-- #03 12/07/11 - re-dimensioned AR_INV_SEQ to smallint
-- #04 12/03/12 - added code for #sel_office to select all offices if @office_list is null
-- #04 12/03/12 - added breakout for CR_PAY_AMT and CR_ADJ_AMT used by V_ACCT_REC_AGING
-- #05 03/04/15 - select CR posted before AR was posted (735-1664)
-- #06 03/26/15 - set AR_INV_AMOUNT to 0 when AR_POST_PERIOD > @end_period
-- #07 04/29/15 - removed grouping on CR POST_PERIOD - was causing balance amounts to not "0" out (1797-269)
-- #08 05/04/15 - removed incorrect c.STATUS = 'D' filter
-- #09 05/06/15 - found second occurrance c.STATUS = 'D' filter needed to be removed
-- #10 05/14/15 - fixed issue with CR for different offices posted to the same invoice (968-141)
-- #11 02/15/18 - Removed AR_POST_PERIOD from ##aged_ar and limited by @end_period

BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #ar_amounts(
	CUTOFF_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE						smalldatetime,
	INVOICE_DUE_DATE				smalldatetime,
	CL_PAYDAYS						smallint NULL,
	PART_PMT_IND					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_DESCRIPTION					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_AMOUNT					decimal(15,2) NULL,
	CR_PAY_AMT						decimal(15,2) NULL,
	CR_ADJ_AMT						decimal(15,2) NULL,
	CR_TOT_AMT						decimal(15,2) NULL,
	CR_CHK_NBR						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CR_OA_AMT						decimal(15,2) NULL,
	BAL_AMOUNT						decimal(15,2) NULL,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	INV_CAT							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #ar_amounts_total(
	CUTOFF_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE						smalldatetime,
	INVOICE_DUE_DATE				smalldatetime,
	CL_PAYDAYS						smallint NULL,
	PART_PMT_IND					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_DESCRIPTION					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_AMOUNT					decimal(15,2) NULL,
	CR_PAY_AMT						decimal(15,2) NULL,
	CR_ADJ_AMT						decimal(15,2) NULL,
	CR_TOT_AMT						decimal(15,2) NULL,
	CR_CHK_NBR						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CR_OA_AMT						decimal(15,2) NULL,
	BAL_AMOUNT						decimal(15,2) NULL,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	INV_CAT							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- #sel_office (table of selected offices)
-- ==========================================================
CREATE TABLE #sel_office (OFFICE_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)		
IF @office_list IS NOT NULL
	BEGIN
		INSERT INTO #sel_office
		SELECT vstr FROM dbo.fn_charlist_to_table2(@office_list)
	END	
ELSE
	BEGIN	
		INSERT INTO #sel_office
		SELECT OFFICE_CODE FROM dbo.OFFICE
	END	
--SELECT * FROM #sel_office

-- ==========================================================
-- #sel_glacode (table of GLACODE's for selected office(s))
-- ==========================================================
CREATE TABLE #sel_glacode (
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLAOFFICE						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

IF NOT EXISTS (SELECT GLOXGLOFFICE FROM dbo.GLOXREF)
--Select GLACODEs for all offices if there are no records in GLOXREF
BEGIN
	INSERT INTO #sel_glacode
	SELECT 
		g.GLACODE,
		g.GLAOFFICE,
		NULL AS OFFICE_CODE
	FROM dbo.GLACCOUNT AS g
END
ELSE
--Select GLACODEs for only offices where records exist in GLOXREF
BEGIN
	INSERT INTO #sel_glacode
	SELECT 
		g.GLACODE,
		g.GLAOFFICE,
		o.OFFICE_CODE
	FROM dbo.GLACCOUNT AS g
	LEFT JOIN dbo.GLOXREF AS r
		ON g.GLAOFFICE = r.GLOXGLOFFICE
	LEFT JOIN #sel_office AS o
		ON r.GLOXOFFICE = o.OFFICE_CODE
	WHERE o.OFFICE_CODE IS NOT NULL
--		OR G.GLAOFFICE IS NULL			--optional, depending on whether or not null records should be extracted
END
--SELECT * FROM #sel_glacode

--==========================================================
-- Aged AR Extraction Routine
--==========================================================
--1. #ar_invoices (select all AR/CR invoices <= @end_period)											--#05
--==========================================================
CREATE TABLE #ar_invoices (	
	AR_INV_NBR int NOT NULL)

INSERT INTO #ar_invoices
SELECT DISTINCT a.AR_INV_NBR
FROM dbo.ACCT_REC AS a
LEFT JOIN dbo.CR_CLIENT_DTL AS d
	ON a.AR_INV_NBR = d.AR_INV_NBR
LEFT JOIN dbo.CR_CLIENT AS c
	ON c.REC_ID = d.REC_ID
	AND c.SEQ_NBR =d.SEQ_NBR
WHERE (a.AR_POST_PERIOD <= @end_period
	OR COALESCE(d.POST_PERIOD,c.POST_PERIOD) <= @end_period)
	--AND ISNULL(c.[STATUS],'') <> 'D'																	--#08
--SELECT * FROM #ar_invoices WHERE AR_INV_NBR = 1254 ORDER BY AR_INV_NBR

--2. #aged_ar (get AR info for all invoices)
--==========================================================
CREATE TABLE #aged_ar (
	AR_INV_NBR							int NOT NULL,
	AR_INV_SEQ							smallint NULL,
	OFFICE_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_DATE							smalldatetime,
	AR_POST_PERIOD						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_PAYDAYS							smallint NULL,
	INVOICE_DUE_DATE					smalldatetime,
	PART_PMT_IND						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_DESCRIPTION						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REC_TYPE							varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_AMOUNT						decimal(15,2),	--NULL),
	GLACODE								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	INV_CAT								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
	 
INSERT INTO #aged_ar
SELECT
	d.AR_INV_NBR,
	d.AR_INV_SEQ,
	d.OFFICE_CODE,
	d.CL_CODE,
	d.DIV_CODE,
	d.PRD_CODE,
	d.AR_INV_DATE,
	NULL, --d.AR_POST_PERIOD,													--#05
	CASE 
		WHEN d.REC_TYPE IN('P','S') THEN ISNULL(c.CL_P_PAYDAYS,0)
		ELSE ISNULL(c.CL_M_PAYDAYS,0)
	END AS CL_PAYDAYS,
	CASE 
		WHEN d.DUE_DATE IS NOT NULL THEN d.DUE_DATE 
		WHEN d.REC_TYPE IN('P','S') AND d.DUE_DATE IS NULL THEN d.AR_INV_DATE + ISNULL(c.CL_P_PAYDAYS,0)
		ELSE d.AR_INV_DATE + ISNULL(c.CL_M_PAYDAYS,0)
	END AS AR_INV_DATE_DUE,
	NULL AS PART_PMT_IND,
	d.AR_DESCRIPTION,
	d.REC_TYPE,
	--CASE																--#06
	--	WHEN d.AR_POST_PERIOD > @end_period THEN 0						--#11
		--ELSE
	SUM(ISNULL(d.AR_INV_AMOUNT,0)),
	--END,
	d.GLACODE_AR,
	d.INV_CAT
FROM dbo.ACCT_REC AS d
JOIN #ar_invoices AS a													--#05
	ON d.AR_INV_NBR = a.AR_INV_NBR
JOIN #sel_glacode AS g
	ON d.GLACODE_AR = g.GLACODE
JOIN dbo.CLIENT AS c
	ON d.CL_CODE = c.CL_CODE
--WHERE d.AR_INV_SEQ <> 99
WHERE d.AR_INV_SEQ <> 99 AND d.AR_POST_PERIOD <= @end_period
GROUP BY d.AR_INV_NBR, d.AR_INV_SEQ, d.CL_CODE, d.DIV_CODE, d.PRD_CODE,
	d.OFFICE_CODE, d.AR_INV_DATE, d.DUE_DATE, d.AR_DESCRIPTION, d.REC_TYPE,--d.AR_POST_PERIOD,
	c.CL_P_PAYDAYS, c.CL_M_PAYDAYS, d.GLACODE_AR, d.INV_CAT
HAVING ABS(SUM(ISNULL(d.AR_INV_AMOUNT,0))) >= .01	
			
--SELECT * FROM #aged_ar --WHERE AR_INV_NBR = 1254


--3. #cash_receipts (get CR info for invoices <= @end_period)
--==========================================================

CREATE TABLE #cash_receipts (
	OFFICE_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AR_INV_NBR							int NOT NULL,
	AR_INV_SEQ							smallint NULL,
	CR_PAY_AMT							decimal(15,2) NULL,
	CR_ADJ_AMT							decimal(15,2) NULL,
	CR_TOT_AMT							decimal(15,2) NULL,
	GLACODE								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
	
INSERT INTO #cash_receipts
SELECT
	NULL,																		--#10 c.OFFICE_CODE,
	NULL,																		--#10 c.CL_CODE,
	NULL,																		--#10 d.DIV_CODE,
	NULL,																		--#10 d.PRD_CODE,
	d.AR_INV_NBR,
	ISNULL(d.AR_INV_SEQ,0),
	SUM(ISNULL(d.CR_PAY_AMT,0)),
	SUM(ISNULL(d.CR_ADJ_AMT,0)),
	SUM(ISNULL(d.CR_PAY_AMT,0)) + SUM(ISNULL(d.CR_ADJ_AMT,0)),
	d.GLACODE_AR,
	NULL																		--#07 COALESCE(d.POST_PERIOD,c.POST_PERIOD)
FROM dbo.CR_CLIENT_DTL AS d
JOIN dbo.CR_CLIENT AS c
	ON d.REC_ID = c.REC_ID
	AND d.SEQ_NBR = c.SEQ_NBR
JOIN #ar_invoices AS a															--#05																	
	ON d.AR_INV_NBR = a.AR_INV_NBR
JOIN #sel_glacode AS g
	ON d.GLACODE_AR = g.GLACODE
WHERE COALESCE(d.POST_PERIOD,c.POST_PERIOD) <= @end_period 
	--AND ISNULL(c.[STATUS],'') <> 'D'											--#09
GROUP BY d.AR_INV_NBR, d.AR_INV_SEQ	, d.GLACODE_AR								--#07, #10 removed fields from grouping

UPDATE #cash_receipts 
SET OFFICE_CODE = (SELECT DISTINCT OFFICE_CODE FROM ACCT_REC AR WHERE #cash_receipts.AR_INV_NBR = AR.AR_INV_NBR AND #cash_receipts.AR_INV_SEQ = AR.AR_INV_SEQ)

UPDATE #cash_receipts 
SET CL_CODE = (SELECT DISTINCT CL_CODE FROM ACCT_REC AR WHERE #cash_receipts.AR_INV_NBR = AR.AR_INV_NBR AND #cash_receipts.AR_INV_SEQ = AR.AR_INV_SEQ)

UPDATE #cash_receipts 
SET DIV_CODE = (SELECT DISTINCT DIV_CODE FROM ACCT_REC AR WHERE #cash_receipts.AR_INV_NBR = AR.AR_INV_NBR AND #cash_receipts.AR_INV_SEQ = AR.AR_INV_SEQ)

UPDATE #cash_receipts 
SET PRD_CODE = (SELECT DISTINCT PRD_CODE FROM ACCT_REC AR WHERE #cash_receipts.AR_INV_NBR = AR.AR_INV_NBR AND #cash_receipts.AR_INV_SEQ = AR.AR_INV_SEQ)

--SELECT * FROM #cash_receipts --WHERE AR_INV_NBR = 1254
-- ORDER BY AR_INV_NBR



--4. #ar_amounts for invoices (set AR_INV_AMOUNT = 0 for AR POST_PERIOD > @end_period)
--==========================================================

INSERT INTO #ar_amounts
SELECT
	@end_period AS CUTOFF_PERIOD,
	a.AR_INV_NBR,
	a.AR_INV_SEQ,
	a.OFFICE_CODE,
	a.CL_CODE,
	a.DIV_CODE,
	a.PRD_CODE,
	a.AR_INV_DATE,
	a.INVOICE_DUE_DATE,
	a.CL_PAYDAYS,
	a.PART_PMT_IND,
	a.AR_DESCRIPTION,
	a.REC_TYPE,
	a.AR_INV_AMOUNT,																
	0 AS CR_PAY_AMT,
	0 AS CR_ADJ_AMT,
	0 AS CR_TOT_AMT,
	NULL AS CR_CHK_NBR,
	0 AS CR_OA_AMT,
	0 AS BAL_AMOUNT,									
	a.GLACODE,
	a.INV_CAT
FROM #aged_ar AS a

--SELECT * FROM #ar_amounts


INSERT INTO #ar_amounts
SELECT
	@end_period AS CUTOFF_PERIOD,
	c.AR_INV_NBR,
	c.AR_INV_SEQ,
	c.OFFICE_CODE,
	c.CL_CODE,
	c.DIV_CODE,
	c.PRD_CODE,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	0 AS AR_INV_AMOUNT,														
	ISNULL(c.CR_PAY_AMT,0) AS CR_PAY_AMT,
	ISNULL(c.CR_ADJ_AMT,0) AS CR_ADJ_AMT,
	ISNULL(c.CR_TOT_AMT,0) AS CR_TOT_AMT,
	NULL AS CR_CHK_NBR,
	0 AS CR_OA_AMT,
	0 AS BAL_AMOUNT,								
	c.GLACODE,
	NULL
FROM #cash_receipts AS c
--WHERE c.AR_INV_NBR IN (SELECT AR_INV_NBR FROM #aged_ar)

--SELECT * FROM #ar_amounts ORDER BY AR_INV_NBR --WHERE AR_INV_NBR = 1254

UPDATE #ar_amounts 
SET AR_INV_DATE = (SELECT DISTINCT AR_INV_DATE FROM ACCT_REC AR WHERE #ar_amounts.AR_INV_NBR = AR.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = AR.AR_INV_SEQ)

UPDATE #ar_amounts 
SET AR_DESCRIPTION = (SELECT DISTINCT AR_DESCRIPTION FROM ACCT_REC AR WHERE #ar_amounts.AR_INV_NBR = AR.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = AR.AR_INV_SEQ)

UPDATE #ar_amounts 
SET INVOICE_DUE_DATE = (SELECT DISTINCT CASE WHEN d.DUE_DATE IS NOT NULL THEN d.DUE_DATE 
								    WHEN d.REC_TYPE IN('P','S') AND d.DUE_DATE IS NULL THEN d.AR_INV_DATE + ISNULL(c.CL_P_PAYDAYS,0)
								    ELSE d.AR_INV_DATE + ISNULL(c.CL_M_PAYDAYS,0) END
						FROM ACCT_REC d JOIN dbo.CLIENT AS c ON d.CL_CODE = c.CL_CODE
						WHERE #ar_amounts.AR_INV_NBR = d.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = d.AR_INV_SEQ)
WHERE INVOICE_DUE_DATE IS NULL

UPDATE #ar_amounts 
SET CL_PAYDAYS = (SELECT DISTINCT CASE WHEN d.REC_TYPE IN('P','S') THEN ISNULL(c.CL_P_PAYDAYS,0)
								   ELSE ISNULL(c.CL_M_PAYDAYS,0) END
						FROM ACCT_REC d JOIN dbo.CLIENT AS c ON d.CL_CODE = c.CL_CODE
						WHERE #ar_amounts.AR_INV_NBR = d.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = d.AR_INV_SEQ)
WHERE CL_PAYDAYS IS NULL

UPDATE #ar_amounts 
SET REC_TYPE = (SELECT DISTINCT d.REC_TYPE FROM ACCT_REC d WHERE #ar_amounts.AR_INV_NBR = d.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = d.AR_INV_SEQ)
WHERE REC_TYPE IS NULL

UPDATE #ar_amounts 
SET INV_CAT = (SELECT DISTINCT INV_CAT FROM #ar_amounts AR WHERE #ar_amounts.AR_INV_NBR = AR.AR_INV_NBR AND #ar_amounts.AR_INV_SEQ = AR.AR_INV_SEQ AND INV_CAT IS NOT NULL)
WHERE INV_CAT IS NULL


--SELECT * FROM #ar_amounts WHERE AR_INV_NBR = 254


--INSERT INTO #ar_amounts
--SELECT
--	@end_period AS CUTOFF_PERIOD,
--	a.AR_INV_NBR,
--	a.AR_INV_SEQ,
--	a.OFFICE_CODE,
--	a.CL_CODE,
--	a.DIV_CODE,
--	a.PRD_CODE,
--	a.AR_INV_DATE,
--	a.INVOICE_DUE_DATE,
--	a.CL_PAYDAYS,
--	a.PART_PMT_IND,
--	a.AR_DESCRIPTION,
--	a.REC_TYPE,
--	a.AR_INV_AMOUNT,															
--	ISNULL(c.CR_PAY_AMT,0) AS CR_PAY_AMT,
--	ISNULL(c.CR_ADJ_AMT,0) AS CR_ADJ_AMT,
--	ISNULL(c.CR_TOT_AMT,0) AS CR_TOT_AMT,
--	NULL AS CR_CHK_NBR,
--	0 AS CR_OA_AMT,
--	a.AR_INV_AMOUNT - ISNULL(c.CR_TOT_AMT,0),									
--	a.GLACODE,
--	a.INV_CAT
--FROM #aged_ar AS a
--LEFT JOIN #cash_receipts AS c
--	ON a.AR_INV_NBR = c.AR_INV_NBR
--	AND a.AR_INV_SEQ = c.AR_INV_SEQ
--	AND a.GLACODE = c.GLACODE
--WHERE ABS(a.AR_INV_AMOUNT - ISNULL(c.CR_TOT_AMT,0)) >= .01
--SELECT * FROM #ar_amounts WHERE AR_INV_NBR = 12104


--SELECT * FROM #ar_amounts


INSERT INTO #ar_amounts_total
SELECT
    CUTOFF_PERIOD,		
	AR_INV_NBR,			
	AR_INV_SEQ,			
	OFFICE_CODE,			
	CL_CODE	,			
	DIV_CODE,			
	PRD_CODE,			
	AR_INV_DATE,			
	INVOICE_DUE_DATE,	
	CL_PAYDAYS,			
	PART_PMT_IND,		
	AR_DESCRIPTION,		
	REC_TYPE,			
	SUM(AR_INV_AMOUNT) AS AR_INV_AMOUNT,		
	SUM(CR_PAY_AMT) AS CR_PAY_AMT,			
	SUM(CR_ADJ_AMT) AS CR_ADJ_AMT,			
	SUM(CR_TOT_AMT) AS CR_TOT_AMT,			
	CR_CHK_NBR,			
	SUM(CR_OA_AMT) AS CR_OA_AMT,			
	SUM(AR_INV_AMOUNT) - SUM(CR_TOT_AMT) AS BAL_AMOUNT,			
	GLACODE,				
	INV_CAT		 
FROM #ar_amounts 
--WHERE AR_INV_NBR = 12104
GROUP BY  
	CUTOFF_PERIOD,		
	AR_INV_NBR,			
	AR_INV_SEQ,			
	OFFICE_CODE,			
	CL_CODE	,			
	DIV_CODE,			
	PRD_CODE,			
	AR_INV_DATE,			
	INVOICE_DUE_DATE,	
	CL_PAYDAYS,			
	PART_PMT_IND,		
	AR_DESCRIPTION,		
	REC_TYPE,				
	CR_CHK_NBR,				
	GLACODE,				
	INV_CAT				
HAVING ABS(SUM(AR_INV_AMOUNT) - ISNULL(SUM(CR_TOT_AMT),0)) >= .01

--5. #ar_amounts for on-account amounts
--==========================================================
INSERT INTO #ar_amounts_total (CUTOFF_PERIOD, OFFICE_CODE, CL_CODE, DIV_CODE, PRD_CODE, AR_INV_DATE,
	CR_CHK_NBR, CR_OA_AMT, BAL_AMOUNT, GLACODE)
SELECT
	@end_period,
	p.OFFICE_CODE,
	c.CL_CODE,
	o.DIV_CODE,
	o.PRD_CODE,
	c.CR_DEP_DATE,
	MAX(c.CR_CHECK_NBR),
	-SUM(ISNULL(o.CR_OA_AMT,0)),
	-SUM(ISNULL(o.CR_OA_AMT,0)),
	o.GLACODE_OA
FROM dbo.CR_CLIENT AS c
JOIN dbo.CR_ON_ACCT AS o
	ON c.REC_ID = o.REC_ID
	AND c.SEQ_NBR = o.SEQ_NBR
JOIN #sel_glacode AS g
	ON o.GLACODE_OA = g.GLACODE
LEFT JOIN dbo.PRODUCT AS p
	ON o.CL_CODE = p.CL_CODE
	AND o.DIV_CODE = p.DIV_CODE
	AND o.PRD_CODE = p.PRD_CODE
WHERE COALESCE(o.POST_PERIOD, c.POST_PERIOD, '999912') <= @end_period
GROUP BY p.OFFICE_CODE, c.CL_CODE, o.DIV_CODE, o.PRD_CODE, c.CR_DEP_DATE, o.GLACODE_OA
HAVING ABS(SUM(ISNULL(o.CR_OA_AMT,0))) >= .01


SELECT * FROM #ar_amounts_total

END
GO

GRANT ALL ON [advsp_aged_ar] TO PUBLIC AS dbo
GO