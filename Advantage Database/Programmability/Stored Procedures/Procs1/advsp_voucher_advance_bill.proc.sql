
CREATE PROCEDURE [dbo].[advsp_voucher_advance_bill] (
	@office_list varchar(4000) = '',
	@end_period varchar(6) = '999912')
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #adv_bill (
	JOB_NUMBER						int NOT NULL,
	JOB_COMPONENT_NBR				smallint NOT NULL,
	AP_PROD_TOT_AMT					decimal(14,2) NULL,
	ADV_BILL_TOT_AMT				decimal(14,2) NULL,
	ADV_BILL_TAX_AMT				decimal(14,2) NULL,
	GLACODE							varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- Temp table #job_list for selected offices
-- ==========================================================
CREATE TABLE #job_list (JOB_NUMBER int NOT NULL)
INSERT INTO #job_list
SELECT l.JOB_NUMBER
FROM dbo.JOB_LOG AS l
--JOIN dbo.fn_charlist_to_table2(@office_list) AS o
--	ON l.OFFICE_CODE = o.vstr
--SELECT * FROM #job_list

-- ==========================================================
-- TEMP TABLE - #adv_bill_filter
-- ==========================================================
CREATE TABLE #adv_bill_filter (
	JOB_NUMBER						int NOT NULL,
	JOB_COMPONENT_NBR				smallint NOT NULL)

-- ==========================================================
-- EXTRACTION ROUTINE
-- ==========================================================
--Insert the records from the ADVANCE_BILLING table
INSERT INTO #adv_bill
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	0 AS AP_PROD_TOT_AMT,
	ISNULL(ADV_BILL_NET_AMT,0),
	ISNULL(EXT_NONRESALE_TAX,0),
	d.GLACODE_ACC_AP
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.V_AR_INVOICE_DATES AS v
	ON d.AR_INV_NBR = v.AR_INV_NBR
	AND d.AR_TYPE = v.AR_TYPE
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT = g.GLEHXACT
WHERE d.GLACODE_ACC_AP IS NOT NULL
	AND ((ISNULL(d.AB_FLAG,0) <> 3 AND v.AR_POST_PERIOD <= @end_period)
	OR (d.AB_FLAG = 3 AND g.GLEHPP <= @end_period))

--Populate #adv_bill_filter
INSERT INTO #adv_bill_filter
SELECT DISTINCT 
	JOB_NUMBER,
	JOB_COMPONENT_NBR
FROM #adv_bill
--SELECT * FROM #adv_bill_filter

--Insert the records from the AP_PRODUCTION table
INSERT INTO #adv_bill
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	ISNULL(d.AP_PROD_EXT_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0),
	0 AS ADV_BILL_TOT_AMT,
	0 AS ADV_BILL_TAX_AMT,
	d.GLACODE
FROM dbo.AP_PRODUCTION AS d
JOIN #adv_bill_filter AS f
	ON d.JOB_NUMBER = f.JOB_NUMBER
	AND d.JOB_COMPONENT_NBR = f.JOB_COMPONENT_NBR
LEFT JOIN dbo.V_AR_INVOICE_DATES AS v
	ON d.AR_INV_NBR = v.AR_INV_NBR
	AND d.AR_TYPE = v.AR_TYPE
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT = g.GLEHXACT
WHERE ISNULL(d.AP_PROD_NOBILL_FLG,0) = 0
	AND ((ISNULL(d.AB_FLAG,0) <> 3 AND d.AR_INV_NBR IS NULL AND d.POST_PERIOD <= @end_period)
	OR (d.POST_PERIOD <= @end_period AND v.AR_POST_PERIOD > @end_period)
	OR (d.AB_FLAG = 3 AND d.POST_PERIOD <= @end_period AND g.GLEHPP > @end_period))

SELECT * FROM #adv_bill

END

