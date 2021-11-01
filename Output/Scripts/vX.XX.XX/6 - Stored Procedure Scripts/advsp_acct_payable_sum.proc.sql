-- stored procedure advsp_acct_payable_sum to extract summary AP amounts
-- #00 12/31/09 - initial release
-- #00 01/05/10 - added GLACODE filter
-- v620 ************************************************************
-- #01 08/19/10 - added filter DELETE_FLAG <> 1 AND MODIFY_FLAG <> 1 via #ap_id_include
-- #02 08/18/12 - removed filter (#01) above, was incorrectly removing records (748-148)

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_acct_payable_sum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_acct_payable_sum]
GO

CREATE PROCEDURE [dbo].[advsp_acct_payable_sum] (
	@office_list					varchar(4000) = NULL, 
	@end_period						varchar(6) = '999912',
	@open_flag						tinyint = 0 )
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #ap_sum (
	[TYPE]							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_ID							int NOT NULL,
	AP_SEQ							smallint NOT NULL,
	VN_FRL_EMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE						smalldatetime,
	AP_DATE_PAY						smalldatetime,
	AP_TOT_AMT						decimal(14,2) NULL,
	PAYMENT_HOLD					smallint NULL,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	GLESEQ							smallint NULL,
	AP_CHK_NBR						int NULL,
	AP_CHK_DATE						smalldatetime,
	AP_CHK_AMT						decimal(14,2) NULL,
	AP_DISC_AMT						decimal(14,2) NULL,
	VENDOR_SERVICE_TAX				decimal(14,2) NULL,
	VN_PAY_TO_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EXCHANGE_AMOUNT_APPLIED			decimal(14,2) NULL,
	CURRENCY_RATE					decimal(12,6) NULL)

-- ==========================================================
-- TEMP TABLE #sel_office (table of selected offices)
-- ==========================================================
CREATE TABLE #sel_office (
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #sel_office
SELECT vstr FROM dbo.fn_charlist_to_table2(@office_list)
--SELECT * FROM #sel_office

-- ==========================================================
-- TEMP TABLE #sel_glacode (table of GLACODE's for selected office(s))
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
		r.GLOXOFFICE
	FROM dbo.GLACCOUNT AS g
	LEFT JOIN dbo.GLOXREF AS r
		ON g.GLAOFFICE = r.GLOXGLOFFICE
	--LEFT JOIN #sel_office AS o
	--	ON r.GLOXOFFICE = o.OFFICE_CODE
	WHERE r.GLOXOFFICE IS NOT NULL AND (r.GLOXOFFICE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL)
--		OR G.GLAOFFICE IS NULL			--optional, depending on whether or not null records should be extracted
END
--SELECT * FROM #sel_glacode


-- ==========================================================
-- TEMP TABLE #ap_header (AP_ID's and header info for max AP_SEQ for selected vendors)
-- ==========================================================
CREATE TABLE #ap_header (
	OFFICE_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_ID							int	NOT NULL,
	AP_SEQ							smallint NOT NULL,
	VN_FRL_EMP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_DATE						smalldatetime,
	AP_DATE_PAY						smalldatetime,
	PAYMENT_HOLD					smallint NULL,
	VN_PAY_TO_CODE					varchar(6),
	CURRENCY_RATE					decimal(12,6) NULL )
INSERT INTO #ap_header
SELECT DISTINCT
	g.OFFICE_CODE,	
	h.AP_ID, 
	h.AP_SEQ,
	h.VN_FRL_EMP_CODE, 
	h.AP_INV_VCHR, 
	h.AP_INV_DATE,
	h.AP_DATE_PAY,
	ISNULL(h.PAYMENT_HOLD,0),
	v.VN_PAY_TO_CODE,
	ISNULL(h.CURRENCY_RATE,0)
FROM dbo.AP_HEADER AS h
LEFT OUTER JOIN VENDOR v ON v.VN_PAY_TO_CODE = h.VN_FRL_EMP_CODE
JOIN #sel_glacode AS g
	ON h.GLACODE = g.GLACODE
WHERE h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2 WHERE h.AP_ID = h2.AP_ID)
--SELECT * FROM #ap_header

-- #ap_id_include (selects AP_ID's where DELETE_FLAG and MODIFY_FLAG are <> 1
CREATE TABLE #ap_id_include (AP_ID int NOT NULL, AP_SEQ smallint NOT NULL)
INSERT INTO #ap_id_include
SELECT h.AP_ID, h.AP_SEQ
FROM dbo.AP_HEADER AS h
--removed line below 8/18/12, but left #ap_id_include in script in case it is needed later
--WHERE ISNULL(h.DELETE_FLAG,0) <> 1 AND ISNULL(h.MODIFY_FLAG,0) <> 1
--SELECT * FROM #ap_id_include

-- ==========================================================
-- AP EXTRACTION ROUTINE
-- ==========================================================
INSERT INTO #ap_sum
SELECT
	'AP',
	a.OFFICE_CODE,
	a.AP_ID,
	a.AP_SEQ,
	a.VN_FRL_EMP_CODE,
	a.AP_INV_VCHR,
	a.AP_INV_DATE,
	a.AP_DATE_PAY,
	ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0),
	a.PAYMENT_HOLD,
	h.GLACODE,
	h.POST_PERIOD,
	h.GLEXACT,
	h.GLESEQ,
	NULL AS AP_CHK_NBR,
	NULL AS AP_CHK_DATE,
	0 AS AP_CHK_AMT,
	0 AS AD_DISC_AMT,
	0 AS VENDOR_SERVICE_TAX,
	a.VN_PAY_TO_CODE,
	0 AS EXCHANGE_AMOUNT_APPLIED,
	0 AS CURRENCY_RATE
FROM #ap_id_include AS i	
JOIN dbo.AP_HEADER AS h
	ON i.AP_ID = h.AP_ID
	AND i.AP_SEQ = h.AP_SEQ
JOIN dbo.GLACCOUNT AS g
	ON h.GLACODE = g.GLACODE
JOIN #ap_header AS a
	ON h.AP_ID = a.AP_ID
WHERE h.POST_PERIOD <= @end_period
	AND ABS(ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0)) >= .01
	AND g.GLATYPE IN('4','5')

-- ==========================================================
-- CK EXTRACTION ROUTINE
-- ==========================================================
INSERT INTO #ap_sum
SELECT
	'CK',
	a.OFFICE_CODE,
	a.AP_ID,
	a.AP_SEQ,
	a.VN_FRL_EMP_CODE,
	a.AP_INV_VCHR,
	a.AP_INV_DATE,
	a.AP_DATE_PAY,
	0 AS AP_TOT_AMT,
	a.PAYMENT_HOLD,
	h.GLACODE_AP,
	h.POST_PERIOD,
	h.GLEXACT,
	h.GLESEQ_AP,
	h.AP_CHK_NBR,
	h.AP_CHK_DATE,
	SUM(ISNULL(h.AP_CHK_AMT,0)),
	SUM(ISNULL(h.AP_DISC_AMT,0)),
	SUM(ISNULL(h.VENDOR_SERVICE_TAX,0)),
	a.VN_PAY_TO_CODE,
	SUM(ISNULL(h.EXCHANGE_AMOUNT_APPLIED,0)),
	a.CURRENCY_RATE
FROM dbo.AP_PMT_HIST AS h
JOIN #ap_header AS a
	ON h.AP_ID = a.AP_ID
--JOIN dbo.CHECK_REGISTER r
--	ON h.BK_CODE = r.BK_CODE AND h.AP_CHK_NBR = r.CHECK_NBR
JOIN dbo.GLACCOUNT AS g
	ON h.GLACODE_AP = g.GLACODE
WHERE g.GLATYPE IN('4','5')
GROUP BY a.OFFICE_CODE,
	     a.AP_ID,
	     a.AP_SEQ,
	     a.VN_FRL_EMP_CODE,
	     a.AP_INV_VCHR,
	     a.AP_INV_DATE,
	     a.AP_DATE_PAY,
         a.PAYMENT_HOLD,
	     h.GLACODE_AP,
	     h.POST_PERIOD,
	     h.GLEXACT,
	     h.GLESEQ_AP,
	     h.AP_CHK_NBR,
	     h.AP_CHK_DATE,
	     a.VN_PAY_TO_CODE,
	     a.CURRENCY_RATE
HAVING h.POST_PERIOD <= @end_period AND ABS(SUM(ISNULL(h.AP_CHK_AMT,0) + ISNULL(h.AP_DISC_AMT,0))) > = .01

/* PJH 09/05/20 - Added VST and EXCH AMT to CHK AMT */
UPDATE #ap_sum
SET AP_CHK_AMT = AP_CHK_AMT + CASE WHEN ISNULL(CURRENCY_RATE,0) > 0 THEN (ISNULL(EXCHANGE_AMOUNT_APPLIED,0) * -1) ELSE (ISNULL(EXCHANGE_AMOUNT_APPLIED,0)) END + (ISNULL(VENDOR_SERVICE_TAX,0))

--SELECT * FROM #ap_sum

-- ==========================================================
-- SELECT DATA FOR ALL OR OPEN INVOICES
-- ==========================================================
--Select data for all invoices
IF @open_flag = 0
	SELECT * FROM #ap_sum AS h
--Select data for open invoices
ELSE
	BEGIN
		--Create a temp table of open invoices
		CREATE TABLE #ap_open(
			AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
			AP_BAL_AMT						decimal(15,2) NULL)

		--Populate the open invoice table
		INSERT INTO #ap_open
		SELECT 
			AP_INV_VCHR,
			SUM(AP_TOT_AMT) - SUM(AP_CHK_AMT)
		FROM #ap_sum
		GROUP BY AP_INV_VCHR
		HAVING ABS(SUM(AP_TOT_AMT) - SUM(AP_CHK_AMT)) >= .01
		
		--SELECT * FROM #ap_open

		--Filter #ap_sum records based on open invoices
		SELECT * FROM #ap_sum AS h
		JOIN #ap_open AS o
			ON h.AP_INV_VCHR = o.AP_INV_VCHR
	END

END
GO

IF ( @@ERROR = 0 )
	GRANT EXECUTE ON [advsp_acct_payable_sum] TO PUBLIC AS dbo
GO	