
CREATE PROCEDURE [dbo].[advsp_production_wip] (
	@office_list varchar(4000),  
	@start_period varchar(6) = '190000',
	@end_period varchar(6) = '219913',
	@glexact_opt tinyint = 0 )					-- 1 = GLEXACT detail, 0 = open items only summarized,
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- Variables to store starting and ending dates for periods
-- ==========================================================
DECLARE @end_date smalldatetime
SET @end_date = (SELECT d.PPENDDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = @end_period ) 
--SELECT @end_date
DECLARE @start_date smalldatetime
SET @start_date = '01/01/1900' 
--SELECT @start_date

-- ==========================================================
-- Main data table [WIP Basic]
-- ==========================================================
CREATE TABLE #wip_basic (
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,							
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_TYPE						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT						int NULL,
	WIP_CODE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ESTIMATE_AMT				decimal(15,2) NULL,
	ESTIMATE_CONT				decimal(15,2) NULL,
	ESTIMATE_HOURS				decimal(15,2) NULL,
	ESTIMATE_HOURS_AMT			decimal(15,2) NULL,
	ADVANCE_AMT					decimal(15,2) NULL,
	ADVANCE_RESALE_TAX			decimal(15,2) NULL,
	ADVANCE_COST				decimal(15,2) NULL,
	ADVANCE_ACCRUED_LIAB		decimal(15,2) NULL,
	ADVANCE_RECON				decimal(15,2) NULL,
	ADVANCE_RECON_COST			decimal(15,2) NULL,
	AP_PROD_EXT_AMT				decimal(15,2) NULL,
	AP_NONRESALE_TAX			decimal(15,2) NULL,
	AP_MARKUP_AMT				decimal(15,2) NULL,
	HOURS						decimal(15,2) NULL,
	HOURS_TOTAL_BILL			decimal(15,2) NULL,
	HOURS_MARKUP_AMT			decimal(15,2) NULL,
	HOURS_TOTAL_COST			decimal(15,2) NULL,
	IO_AMT						decimal(15,2) NULL,
	IO_MARKUP_AMT				decimal(15,2) NULL,
	AP_PMT_FLAG					tinyint NULL,
	AP_PARTIAL_FLAG				tinyint NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- Temp data table [#wip_temp]
-- ==========================================================
CREATE TABLE #wip_temp (
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,							
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_TYPE						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT						int NULL,
	WIP_CODE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ESTIMATE_AMT				decimal(15,2) NULL,
	ESTIMATE_CONT				decimal(15,2) NULL,
	ESTIMATE_HOURS				decimal(15,2) NULL,
	ESTIMATE_HOURS_AMT			decimal(15,2) NULL,
	ADVANCE_AMT					decimal(15,2) NULL,
	ADVANCE_RESALE_TAX			decimal(15,2) NULL,
	ADVANCE_COST				decimal(15,2) NULL,
	ADVANCE_ACCRUED_LIAB		decimal(15,2) NULL,
	ADVANCE_RECON				decimal(15,2) NULL,
	ADVANCE_RECON_COST			decimal(15,2) NULL,
	AP_PROD_EXT_AMT				decimal(15,2) NULL,
	AP_NONRESALE_TAX			decimal(15,2) NULL,
	AP_MARKUP_AMT				decimal(15,2) NULL,
	HOURS						decimal(15,2) NULL,
	HOURS_TOTAL_BILL			decimal(15,2) NULL,
	HOURS_MARKUP_AMT			decimal(15,2) NULL,
	HOURS_TOTAL_COST			decimal(15,2) NULL,
	IO_AMT						decimal(15,2) NULL,
	IO_MARKUP_AMT				decimal(15,2) NULL,
	AP_PMT_FLAG					tinyint NULL,
	AP_PARTIAL_FLAG				tinyint NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- Temp table #wip_total_filter
-- ==========================================================
CREATE TABLE #wip_total_filter (
	JOB_NUMBER					int NOT NULL,
	JOB_COMPONENT_NBR			smallint NULL, 
	GLEXACT						int NULL,
	UNBILLED_AP					decimal(15,2) NULL,
	UNBILLED_TIME				decimal(15,2) NULL,
	UNBILLED_IO					decimal(15,2) NULL,
	UNBILLED_AB					decimal(15,2) NULL )

-- ==========================================================
-- Temp table #wip_emp
-- ==========================================================
CREATE TABLE #wip_emp (
	EMP_CODE					varchar(6),
	JOB_NUMBER					int NOT NULL,
	JOB_COMPONENT_NBR			smallint NULL, 
	PPPERIOD					varchar(6),
	EMP_HOURS					decimal(15,2) NULL,
	TOTAL_COST					decimal(15,2) NULL,
	TOTAL_BILL					decimal(15,2) NULL,
	EXT_MARKUP_AMT				decimal(15,2) NULL,
	WIP_CODE						varchar(1))

-- ==========================================================
-- Temp table #wip_io
-- ==========================================================
CREATE TABLE #wip_io (
	JOB_NUMBER					int NOT NULL,
	JOB_COMPONENT_NBR			smallint NULL, 
	PPPERIOD					varchar(6),
	IO_AMT					decimal(15,2) NULL,
	IO_MARKUP_AMT				decimal(15,2) NULL,
	WIP_CODE						varchar(1))

-- ==========================================================
-- Temp table #job_list for selected offices
-- ==========================================================
CREATE TABLE #job_list (JOB_NUMBER int NOT NULL)
INSERT INTO #job_list
SELECT l.JOB_NUMBER
FROM dbo.JOB_LOG AS l
JOIN dbo.fn_charlist_to_table2(@office_list) AS o
	ON l.OFFICE_CODE = o.vstr
--SELECT * FROM #job_list

-- ==========================================================
-- Temp table #gl_post_period
-- ==========================================================
CREATE TABLE #gl_post_period (
	PPPERIOD					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLYYYYMM						int NULL )			
INSERT INTO #gl_post_period
SELECT 
	p.PPPERIOD,
	YEAR(p.PPSRTDATE) * 100 + MONTH(p.PPSRTDATE)	
FROM dbo.POSTPERIOD AS p
WHERE p.PPGLMONTH NOT IN(13,99)
--SELECT * FROM #gl_post_period

-- ==========================================================
-- Temp table #ap_pmt_history
-- ==========================================================
CREATE TABLE #ap_pmt_history (
	AP_ID						int NOT NULL,
	AP_HIST_AMT					decimal(14,2) NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #ap_pmt_history
SELECT
	d.AP_ID,
	SUM(ISNULL(d.AP_CHK_AMT,0) + ISNULL(d.AP_DISC_AMT,0)),
	CASE COUNT(d.AP_CHK_NBR)
		WHEN 1 THEN CAST(Min(d.AP_CHK_NBR) AS varchar(20))
		ELSE 'Multiple Checks'
	END
FROM dbo.AP_PMT_HIST AS d
GROUP BY d.AP_ID
--SELECT * FROM #ap_pmt_history

-- ==========================================================
-- Temp table #ap_paid_filter
-- ==========================================================
CREATE TABLE #ap_paid_filter (
	AP_ID						int NOT NULL,
	AP_PMT_AMT					decimal(14,2) NULL,
	AP_HIST_AMT					decimal(14,2) NULL,
	AP_PMT_FLAG					tinyint NULL,
	AP_PARTIAL_FLAG				tinyint NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #ap_paid_filter
SELECT
	h.AP_ID,
	SUM(ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0)),
	d.AP_HIST_AMT,
	CASE 
		WHEN ABS(SUM(ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0)) - ISNULL(d.AP_HIST_AMT,0)) >= 0.01 THEN 0
		ELSE 1
	END,
	CASE
		WHEN (ABS(SUM(ISNULL(h.AP_INV_AMT,0) + ISNULL(h.AP_SHIPPING,0) + ISNULL(h.AP_SALES_TAX,0)) - ISNULL(d.AP_HIST_AMT,0)) >= 0.01)
			AND d.AP_HIST_AMT >0.01 THEN 1
		ELSE 0
	END,
	d.AP_PMT_REF
FROM dbo.AP_HEADER AS h
LEFT JOIN #ap_pmt_history AS d
	ON h.AP_ID = d.AP_ID
GROUP BY h.AP_ID, d.AP_HIST_AMT, d.AP_PMT_REF
--SELECT * FROM #ap_paid_filter

-- ==========================================================
-- Temp table #office_def_sales_acct
-- ==========================================================
CREATE TABLE #office_def_sales_acct (
	PGLACODE_DEF_SALES			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #office_def_sales_acct
SELECT DISTINCT d.PGLACODE_DEF_SALES
FROM dbo.OFFICE AS d
--SELECT * FROM #office_def_sales_acct

-- ==========================================================
-- DATA EXTRACTION ROUTINES
-- ==========================================================
-- AP Entry
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
	AP_PARTIAL_FLAG, AP_PMT_REF)
SELECT
	h.VN_FRL_EMP_CODE,
	h.AP_INV_VCHR,
	p.JOB_NUMBER,
	p.JOB_COMPONENT_NBR,
	p.FNC_CODE,
	'AP Entry or Mod',
	p.POST_PERIOD,
	CASE p.AR_TYPE 
		WHEN 'VO' THEN NULL
		ELSE p.GLEXACT
	END,
	SUM(ISNULL(p.AP_PROD_EXT_AMT,0)),
	SUM(ISNULL(p.EXT_NONRESALE_TAX,0)),
	SUM(ISNULL(p.EXT_MARKUP_AMT,0)),
	'D',
	d.AP_PMT_FLAG,
	d.AP_PARTIAL_FLAG,
	d.AP_PMT_REF
FROM dbo.AP_HEADER AS h
JOIN dbo.AP_PRODUCTION AS p
	ON h.AP_ID = p.AP_ID
	AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
WHERE p.POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(p.AP_PROD_NOBILL_FLG,0) = 0
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, p.FNC_CODE,
	p.POST_PERIOD, p.AR_TYPE, p.GLEXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF

-- ==========================================================
-- AP Billing
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
	AP_PARTIAL_FLAG, AP_PMT_REF)
SELECT
	h.VN_FRL_EMP_CODE,
	h.AP_INV_VCHR,
	p.JOB_NUMBER,
	p.JOB_COMPONENT_NBR,
	p.FNC_CODE,
	CASE p.AR_TYPE
		WHEN 'VO' THEN 'Void Inv# ' + LTRIM(CAST(p.AR_INV_NBR AS varchar(6)))
		ELSE 'Billing Inv# ' + LTRIM(CAST(p.AR_INV_NBR AS varchar(6)))
	END,
	a.AR_POST_PERIOD,
	a.GLEXACT,
	SUM(ISNULL(p.AP_PROD_EXT_AMT,0)) * -1,
	SUM(ISNULL(p.EXT_NONRESALE_TAX,0)) * -1,
	SUM(p.EXT_MARKUP_AMT) * -1,
	'C',
	d.AP_PMT_FLAG,
	d.AP_PARTIAL_FLAG,
	d.AP_PMT_REF
FROM dbo.AP_HEADER AS h
JOIN dbo.AP_PRODUCTION AS p
	ON h.AP_ID = p.AP_ID
	AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON p.AR_INV_NBR = a.AR_INV_NBR
	AND p.AR_TYPE = a.AR_TYPE
WHERE ISNULL(p.AB_FLAG,0) <> 3			--12/05/09
	AND a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, p.FNC_CODE,
	p.AR_INV_NBR, p.AR_TYPE, a.AR_POST_PERIOD, a.GLEXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF

-- ==========================================================
-- AP Billing No Bill
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
	AP_PARTIAL_FLAG, AP_PMT_REF)
SELECT
	h.VN_FRL_EMP_CODE,
	h.AP_INV_VCHR,
	p.JOB_NUMBER,
	p.JOB_COMPONENT_NBR,
	NULL,
	'Reconcile No Bill',
	g.GLEHPP,
	g.GLEHXACT,
	SUM(ISNULL(p.AP_PROD_EXT_AMT,0)) * -1,
	SUM(ISNULL(p.EXT_NONRESALE_TAX,0)) * -1,
	SUM(p.EXT_MARKUP_AMT) * -1,
	'C',
	d.AP_PMT_FLAG,
	d.AP_PARTIAL_FLAG,
	d.AP_PMT_REF
FROM dbo.AP_HEADER AS h
JOIN dbo.AP_PRODUCTION AS p
	ON h.AP_ID = p.AP_ID
	AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
JOIN dbo.GLENTHDR AS g
	ON p.GLEXACT_BILL = g.GLEHXACT
WHERE p.AB_FLAG = 3
	AND g.GLEHPP BETWEEN @start_period AND @end_period
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, 
	g.GLEHPP, g.GLEHXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF

-- ==========================================================
-- Open Employee Time with Time Period
-- ==========================================================
INSERT INTO #wip_emp (EMP_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, PPPERIOD, 
	EMP_HOURS, TOTAL_COST, TOTAL_BILL, EXT_MARKUP_AMT, WIP_CODE)
SELECT
	h.EMP_CODE,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	(SELECT PPPERIOD FROM POSTPERIOD WHERE h.EMP_DATE BETWEEN PPSRTDATE AND PPENDDATE AND PPGLMONTH NOT IN (13,99)),--p.PPPERIOD,
	ISNULL(d.EMP_HOURS,0),
	ISNULL(d.TOTAL_COST,0),
	ISNULL(d.TOTAL_BILL,0),
	ISNULL(d.EXT_MARKUP_AMT,0),
	'E'
FROM dbo.EMP_TIME AS h
JOIN dbo.EMP_TIME_DTL AS d
	ON h.ET_ID = d.ET_ID
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT_BILL = g.GLEHXACT
--JOIN #gl_post_period AS p
--	ON YEAR(h.EMP_DATE) * 100 + MONTH(h.EMP_DATE) = p.GLYYYYMM
WHERE
	h.EMP_DATE BETWEEN @start_date AND @end_date	
	AND ISNULL(d.EMP_NON_BILL_FLAG,0) = 0
	AND ( d.GLEXACT_BILL IS NULL OR g.GLEHPP > @end_period )

INSERT INTO #wip_temp (VN_FRL_EMP_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	HOURS, HOURS_TOTAL_COST, HOURS_TOTAL_BILL, HOURS_MARKUP_AMT, WIP_CODE)
SELECT
	h.EMP_CODE,
	h.JOB_NUMBER,
	h.JOB_COMPONENT_NBR,
	h.PPPERIOD,
	SUM(ISNULL(h.EMP_HOURS,0)),
	SUM(ISNULL(h.TOTAL_COST,0)),
	SUM(ISNULL(h.TOTAL_BILL,0)),
	SUM(ISNULL(h.EXT_MARKUP_AMT,0)),
	'E'
FROM #wip_emp AS h
GROUP BY h.EMP_CODE, h.JOB_NUMBER, h.JOB_COMPONENT_NBR, h.PPPERIOD, h.PPPERIOD

-- ==========================================================
-- Open Income Only
-- ==========================================================
INSERT INTO #wip_io (JOB_NUMBER, JOB_COMPONENT_NBR, PPPERIOD, 
	IO_AMT, IO_MARKUP_AMT, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	(SELECT PPPERIOD FROM POSTPERIOD WHERE d.IO_INV_DATE BETWEEN PPSRTDATE AND PPENDDATE AND PPGLMONTH NOT IN (13,99)),--p.PPPERIOD,
	ISNULL(d.IO_AMOUNT,0),
	ISNULL(d.EXT_MARKUP_AMT,0),
	'I'
FROM dbo.INCOME_ONLY AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT_BILL = g.GLEHXACT
--JOIN #gl_post_period AS p
--	ON YEAR(d.IO_INV_DATE) * 100 + MONTH(d.IO_INV_DATE) = p.GLYYYYMM
WHERE 
	d.IO_INV_DATE BETWEEN @start_date AND @end_date
	AND ISNULL(d.NON_BILL_FLAG,0) = 0
	AND ( d.GLEXACT_BILL IS NULL OR g.GLEHPP > @end_period )

INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	IO_AMT, IO_MARKUP_AMT, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	d.PPPERIOD,
	SUM(ISNULL(d.IO_AMT,0)),
	SUM(ISNULL(d.IO_MARKUP_AMT,0)),
	'I'
FROM #wip_io AS d
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.PPPERIOD

-- ==========================================================
-- Advance Billing
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	ADVANCE_AMT, WIP_CODE, ADVANCE_RESALE_TAX, ADVANCE_COST)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	a.AR_POST_PERIOD,
	--SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0)),		--alternative format
	SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.EXT_STATE_RESALE,0) - ISNULL(d.EXT_COUNTY_RESALE,0) - ISNULL(d.EXT_CITY_RESALE,0)),
	'A',
	SUM(ISNULL(d.EXT_STATE_RESALE,0) + ISNULL(d.EXT_COUNTY_RESALE,0) + ISNULL(d.EXT_CITY_RESALE,0)),
	CASE d.FNC_TYPE
		WHEN 'V' THEN SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0))
		ELSE 0
	END
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON d.AR_INV_NBR = a.AR_INV_NBR
	AND d.AR_TYPE = a.AR_TYPE
JOIN #office_def_sales_acct AS o
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(d.AB_FLAG,3) <> 3
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE	

-- ==========================================================
-- Advance Billing NB
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	ADVANCE_AMT, WIP_CODE, ADVANCE_RESALE_TAX)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	g.GLEHPP,
	SUM(ISNULL(d.LINE_TOTAL,0)- ISNULL(d.EXT_STATE_RESALE,0) - ISNULL(d.EXT_COUNTY_RESALE,0) - ISNULL(d.EXT_CITY_RESALE,0)),
	'A',
	SUM(ISNULL(d.EXT_STATE_RESALE,0) + ISNULL(d.EXT_COUNTY_RESALE,0) + ISNULL(d.EXT_CITY_RESALE,0))
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
JOIN #office_def_sales_acct AS o
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT = g.GLEHXACT
WHERE g.GLEHPP BETWEEN @start_period AND @end_period
	AND d.AB_FLAG = 3
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, g.GLEHPP

-- ==========================================================
-- Advance Billing Income Rec
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	ADVANCE_AMT, ADVANCE_RECON, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	a.AR_POST_PERIOD,
	SUM(ISNULL(d.REC_AMT,0)) * -1,
	SUM(ISNULL(d.REC_AMT,0)) * -1,
	'A'
FROM dbo.INCOME_REC AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON d.AR_INV_NBR = a.AR_INV_NBR
	AND d.AR_TYPE = a.AR_TYPE
JOIN #office_def_sales_acct AS o
	ON d.GLACODE_DEF_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD
	
-- ==========================================================
-- Advance Billing Reconcile
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	 ADVANCE_RECON, WIP_CODE, ADVANCE_RESALE_TAX, ADVANCE_COST)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	a.AR_POST_PERIOD,
	--SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0)),		--alternative format
	SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.EXT_STATE_RESALE,0) - ISNULL(d.EXT_COUNTY_RESALE,0) - ISNULL(d.EXT_CITY_RESALE,0)),
	'A',
	SUM(ISNULL(d.EXT_STATE_RESALE,0) + ISNULL(d.EXT_COUNTY_RESALE,0) + ISNULL(d.EXT_CITY_RESALE,0)),
	CASE d.FNC_TYPE
		WHEN 'V' THEN SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0))
		ELSE 0
	END
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON d.AR_INV_NBR = a.AR_INV_NBR
	AND d.AR_TYPE = a.AR_TYPE
JOIN #office_def_sales_acct AS o
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(d.AB_FLAG,3) IN(4,6)
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE	
	
-- ==========================================================
-- Advance Billing Accrued Liability
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	ADVANCE_ACCRUED_LIAB, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	a.AR_POST_PERIOD,
	CASE d.FNC_TYPE
		WHEN 'V' THEN SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0))
		ELSE 0
	END,
	'L'
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON d.AR_INV_NBR = a.AR_INV_NBR
	AND d.AR_TYPE = a.AR_TYPE
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(d.AB_FLAG,0) <> 3
	AND d.GLACODE_ACC_AP IS NOT NULL
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE
	
-- ==========================================================
-- Advance Billing Accrued Liability NB
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	ADVANCE_ACCRUED_LIAB, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	g.GLEHPP,
	CASE d.FNC_TYPE
		WHEN 'V' THEN SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0))
		ELSE 0
	END,
	'L'
FROM dbo.ADVANCE_BILLING AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT = g.GLEHXACT
WHERE g.GLEHPP BETWEEN @start_period AND @end_period
	AND d.AB_FLAG = 3
	AND d.GLACODE_ACC_AP IS NOT NULL
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, g.GLEHPP, d.FNC_TYPE		

--SELECT * FROM #wip_temp ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR

-- ==========================================================
-- Populate #wip_temp completed 
-- Must send data to #wip_basic to send "0's" to mdb)
-- ==========================================================
--Option to print GLEXACT detail
IF @glexact_opt = 1	
	BEGIN
		INSERT INTO #wip_basic
		SELECT
			d.VN_FRL_EMP_CODE,							
			d.AP_INV_VCHR,
			d.JOB_NUMBER,
			d.JOB_COMPONENT_NBR,
			d.FNC_CODE,
			d.AP_TYPE,
			d.POST_PERIOD,
			d.GLEXACT,
			d.WIP_CODE,
			SUM(ISNULL(d.ESTIMATE_AMT,0)) AS ESTIMATE_AMT,
			SUM(ISNULL(d.ESTIMATE_CONT,0)) AS ESTIMATE_CONT,
			SUM(ISNULL(d.ESTIMATE_HOURS,0)) AS ESTIMATE_HOURS,
			SUM(ISNULL(d.ESTIMATE_HOURS_AMT,0)) AS ESTIMATE_HOURS_AMT,
			SUM(ISNULL(d.ADVANCE_AMT,0)) AS ADVANCE_AMT,
			SUM(ISNULL(d.ADVANCE_RESALE_TAX,0)) AS ADVANCE_RESALE_TAX,
			SUM(ISNULL(d.ADVANCE_COST,0)) AS ADVANCE_COST,
			SUM(ISNULL(d.ADVANCE_ACCRUED_LIAB,0)) AS ADVANCE_ACCRUED_LIAB,
			SUM(ISNULL(d.ADVANCE_RECON,0)) AS ADVANCE_RECON,
			SUM(ISNULL(d.ADVANCE_RECON_COST,0)) AS ADVANCE_RECON_COST,
			SUM(ISNULL(d.AP_PROD_EXT_AMT,0)) AS AP_PROD_EXT_AMT,
			SUM(ISNULL(d.AP_NONRESALE_TAX,0)) AS AP_NONRESALE_TAX,
			SUM(ISNULL(d.AP_MARKUP_AMT,0)) AS AP_MARKUP_AMT,
			SUM(ISNULL(d.HOURS,0)) AS HOURS,
			SUM(ISNULL(d.HOURS_TOTAL_BILL,0)) AS HOURS_TOTAL_BILL,
			SUM(ISNULL(d.HOURS_MARKUP_AMT,0)) AS HOURS_MARKUP_AMT,
			SUM(ISNULL(d.HOURS_TOTAL_COST,0)) AS HOURS_TOTAL_COST,
			SUM(ISNULL(d.IO_AMT,0)) AS IO_AMT,
			SUM(ISNULL(d.IO_MARKUP_AMT,0)) AS IO_MARKUP_AMT,
			AP_PMT_FLAG,
			AP_PARTIAL_FLAG,
			AP_PMT_REF
		FROM #wip_temp AS d
		GROUP BY d.VN_FRL_EMP_CODE, d.AP_INV_VCHR, d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.AP_TYPE, d.FNC_CODE, 
			d.POST_PERIOD, d.GLEXACT, d.WIP_CODE, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF
		SELECT * FROM #wip_basic
	END
--Option to print summary of open items
ELSE
	BEGIN
		--Populate #wip_total_filter
		INSERT INTO #wip_total_filter
		SELECT
			JOB_NUMBER,
			JOB_COMPONENT_NBR,
			NULL AS GLEXACT,
			SUM(ISNULL(AP_PROD_EXT_AMT,0) + ISNULL(AP_NONRESALE_TAX,0)) AS UNBILLED_AP,
			SUM(ISNULL(HOURS_TOTAL_BILL,0) + ISNULL(HOURS_MARKUP_AMT,0)) AS UNBILLED_TIME,
			SUM(ISNULL(IO_AMT,0) + ISNULL(IO_MARKUP_AMT,0)) AS UNBILLED_IO,
			SUM(ISNULL(ADVANCE_AMT,0)) AS UNBILLED_AB
		FROM #wip_temp
		GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR	--, GLEXACT
		HAVING
			ABS(SUM(ISNULL(AP_PROD_EXT_AMT,0) + ISNULL(AP_NONRESALE_TAX,0))) >= .01
			OR ABS(SUM(ISNULL(HOURS_TOTAL_BILL,0) + ISNULL(HOURS_MARKUP_AMT,0))) >= .01
			OR ABS(SUM(ISNULL(IO_AMT,0) + ISNULL(IO_MARKUP_AMT,0))) >= .01
			OR ABS(SUM(ISNULL(ADVANCE_AMT,0))) >= .01
		--SELECT * FROM #wip_total_filter ORDER BY JOB_NUMBER

		INSERT INTO #wip_basic
		SELECT
			d.VN_FRL_EMP_CODE,							
			d.AP_INV_VCHR,
			d.JOB_NUMBER,
			d.JOB_COMPONENT_NBR,
			d.FNC_CODE,
			d.AP_TYPE,
			d.POST_PERIOD,
			d.GLEXACT,
			d.WIP_CODE,
			SUM(ISNULL(d.ESTIMATE_AMT,0)) AS ESTIMATE_AMT,
			SUM(ISNULL(d.ESTIMATE_CONT,0)) AS ESTIMATE_CONT,
			SUM(ISNULL(d.ESTIMATE_HOURS,0)) AS ESTIMATE_HOURS,
			SUM(ISNULL(d.ESTIMATE_HOURS_AMT,0)) AS ESTIMATE_HOURS_AMT,
			SUM(ISNULL(d.ADVANCE_AMT,0)) AS ADVANCE_AMT,
			SUM(ISNULL(d.ADVANCE_RESALE_TAX,0)) AS ADVANCE_RESALE_TAX,
			SUM(ISNULL(d.ADVANCE_COST,0)) AS ADVANCE_COST,
			SUM(ISNULL(d.ADVANCE_ACCRUED_LIAB,0)) AS ADVANCE_ACCRUED_LIAB,
			SUM(ISNULL(d.ADVANCE_RECON,0)) AS ADVANCE_RECON,
			SUM(ISNULL(d.ADVANCE_RECON_COST,0)) AS ADVANCE_RECON_COST,
			SUM(ISNULL(d.AP_PROD_EXT_AMT,0)) AS AP_PROD_EXT_AMT,
			SUM(ISNULL(d.AP_NONRESALE_TAX,0)) AS AP_NONRESALE_TAX,
			SUM(ISNULL(d.AP_MARKUP_AMT,0)) AS AP_MARKUP_AMT,
			SUM(ISNULL(d.HOURS,0)) AS HOURS,
			SUM(ISNULL(d.HOURS_TOTAL_BILL,0)) AS HOURS_TOTAL_BILL,
			SUM(ISNULL(d.HOURS_MARKUP_AMT,0)) AS HOURS_MARKUP_AMT,
			SUM(ISNULL(d.HOURS_TOTAL_COST,0)) AS HOURS_TOTAL_COST,
			SUM(ISNULL(d.IO_AMT,0)) AS IO_AMT,
			SUM(ISNULL(d.IO_MARKUP_AMT,0)) AS IO_MARKUP_AMT,
			AP_PMT_FLAG,
			AP_PARTIAL_FLAG,
			AP_PMT_REF
		FROM #wip_temp AS d
		JOIN #wip_total_filter AS f
			ON d.JOB_NUMBER = f.JOB_NUMBER
			AND d.JOB_COMPONENT_NBR = f.JOB_COMPONENT_NBR
		GROUP BY d.VN_FRL_EMP_CODE, d.AP_INV_VCHR, d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.AP_TYPE, 
			d.POST_PERIOD, d.WIP_CODE, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF	, d.FNC_CODE, d.GLEXACT
		SELECT * FROM #wip_basic
	END
END
