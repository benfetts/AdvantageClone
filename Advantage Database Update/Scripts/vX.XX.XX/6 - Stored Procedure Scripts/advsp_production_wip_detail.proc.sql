SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_production_wip_detail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_production_wip_detail]
GO

CREATE PROCEDURE [dbo].[advsp_production_wip_detail] (
	@end_period varchar(6) = '201712',
	@office_list varchar(4000),
	@CLIENT_LIST AS varchar(Max) = NULL,
	@DIVISION_LIST AS varchar(Max) = NULL,
	@PRODUCT_LIST AS varchar(Max) = NULL,
	@aging_date AS date = '12/31/99',
	@aging_option AS tinyint = 1,
    @UserId varchar(100))
AS

--Stored procedure to extract production wip information
-- #000 JP  12/18/17 - Initial - uses "advsp_production_wip.sql 12/4/12 #01" as base, still includes code for summary but remarked out
-- #001 PJH 06/03/20 - added #office_def_sales_acct back to balance to legacy reports
-- #002 PJH 12/02/20 - 735-2-1030 - Would like to have a WIP dataset in dynamic report writer that will tie to the GL and provide the details of the WIP items ([TotalAging], [AgingPeriod])

BEGIN
SET NOCOUNT ON;

    DECLARE @OfficeRestrictions INT,
			@EMP_CODE AS VARCHAR(6)

    SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserId);
    SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;

-- ==========================================================
-- Variables to store starting and ending dates for periods
-- ==========================================================
	DECLARE @start_period varchar(6)
	SET @start_period = '190000' 
	DECLARE @start_date datetime
	SET @start_date = '01/01/1900' 
	DECLARE @end_date datetime
	SET @end_date = (SELECT d.PPENDDATE FROM dbo.POSTPERIOD AS d WHERE d.PPPERIOD = @end_period ) 
--SELECT @aging_date, @aging_option

-- ==========================================================
-- Main data table [WIP Basic]
-- ==========================================================
CREATE TABLE #wip_basic (
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,							
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
--	FNC_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_TYPE						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
    AP_DATE                     smalldatetime,
--	GLEXACT						int NULL,
	WIP_CODE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ESTIMATE_AMT				decimal(15,2) NULL,
	ESTIMATE_CONT				decimal(15,2) NULL,
	ESTIMATE_HOURS				decimal(15,2) NULL,
	ESTIMATE_HOURS_AMT			decimal(15,2) NULL,
	ESTIMATE_NET_AMT			decimal(15,2) NULL,
	ESTIMATE_NONRESALE_TAX		decimal(15,2) NULL,
	AP_PROD_EXT_AMT				decimal(15,2) NULL,
	AP_NONRESALE_TAX			decimal(15,2) NULL,
	AP_TOTAL					decimal(15,2) NULL,
--	AP_MARKUP_AMT				decimal(15,2) NULL,
	AP_PMT_FLAG					tinyint NULL,
	AP_PARTIAL_FLAG				tinyint NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[HOURS]						decimal(15,2) NULL,
	HOURS_TOTAL_BILL			decimal(15,2) NULL,
	HOURS_MARKUP_AMT			decimal(15,2) NULL,
--	HOURS_TOTAL_COST			decimal(15,2) NULL,
	IO_AMT						decimal(15,2) NULL,
	IO_MARKUP_AMT				decimal(15,2) NULL,
	ADVANCE_AMT					decimal(15,2) NULL,
	ADVANCE_RESALE_TAX			decimal(15,2) NULL,
	ADVANCE_COST				decimal(15,2) NULL,
	ADVANCE_ACCRUED_LIAB		decimal(15,2) NULL,
	ADVANCE_RECON				decimal(15,2) NULL,
	ADVANCE_RECON_COST			decimal(15,2) NULL,
    AGING_FLAG                  tinyint NULL,
    AGING_AP_FLAG               tinyint NULL,
    OPEN_PO_AMT			        decimal(15,2) NULL)

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
    AP_DATE                     smalldatetime,
	GLEXACT						int NULL,
	WIP_CODE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ESTIMATE_AMT				decimal(15,2) NULL,
	ESTIMATE_CONT				decimal(15,2) NULL,
	ESTIMATE_HOURS				decimal(15,2) NULL,
	ESTIMATE_HOURS_AMT			decimal(15,2) NULL,
	ESTIMATE_NET_AMT			decimal(15,2) NULL,
	ESTIMATE_NONRESALE_TAX		decimal(15,2) NULL,	
	ADVANCE_AMT					decimal(15,2) NULL,
	ADVANCE_RESALE_TAX			decimal(15,2) NULL,
	ADVANCE_COST				decimal(15,2) NULL,
	ADVANCE_ACCRUED_LIAB		decimal(15,2) NULL,
	ADVANCE_RECON				decimal(15,2) NULL,
	ADVANCE_RECON_COST			decimal(15,2) NULL,
	AP_PROD_EXT_AMT				decimal(15,2) NULL,
	AP_NONRESALE_TAX			decimal(15,2) NULL,
	AP_MARKUP_AMT				decimal(15,2) NULL,
	[HOURS]						decimal(15,2) NULL,
	HOURS_TOTAL_BILL			decimal(15,2) NULL,
	HOURS_MARKUP_AMT			decimal(15,2) NULL,
	HOURS_TOTAL_COST			decimal(15,2) NULL,
	IO_AMT						decimal(15,2) NULL,
	IO_MARKUP_AMT				decimal(15,2) NULL,
	AP_PMT_FLAG					tinyint NULL,
	AP_PARTIAL_FLAG				tinyint NULL,
	AP_PMT_REF					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- Temp table #job_list for selected offices 
-- ==========================================================
CREATE TABLE #job_list (JOB_NUMBER int NOT NULL)
--IF @office_list IS NULL 
--	INSERT INTO #job_list
--	SELECT l.JOB_NUMBER
--	FROM dbo.JOB_LOG AS l
--ELSE

IF @OfficeRestrictions > 0
BEGIN
    INSERT INTO #job_list
	SELECT l.JOB_NUMBER
	FROM dbo.JOB_LOG AS l INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = l.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
    WHERE
        (l.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL) AND
		(l.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE + '|' + l.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END
ELSE
BEGIN
    INSERT INTO #job_list
	SELECT l.JOB_NUMBER
	FROM dbo.JOB_LOG AS l
    WHERE
        (l.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL) AND
		(l.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE + '|' + l.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END

	
--SELECT * FROM #job_list

-- ==========================================================
-- Temp table #gl_post_period
-- Used to assign GL posting period for employee date/time entries
-- ==========================================================
CREATE TABLE #gl_post_period (
	PPPERIOD					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLYYYYMM					int NULL,
	PPENDDATE					datetime)			
INSERT INTO #gl_post_period
SELECT 
	p.PPPERIOD,
	YEAR(p.PPSRTDATE) * 100 + MONTH(p.PPSRTDATE),
	p.PPENDDATE	
FROM dbo.POSTPERIOD AS p
WHERE p.PPGLMONTH NOT IN(13,99)
--SELECT * FROM #gl_post_period

-- ==========================================================
-- Temp table #ap_pmt_history
-- Sets AP_PMT_REF to invoice # or "Multiple Invoices"
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
-- Sets AP paid and partial flags
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


-- =======================================================================================================
-- DATA EXTRACTION ROUTINES
-- =======================================================================================================
-- 1. AP Entry
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, AP_DATE, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
	AP_PARTIAL_FLAG, AP_PMT_REF)
SELECT
	h.VN_FRL_EMP_CODE,
	h.AP_INV_VCHR,
	p.JOB_NUMBER,
	p.JOB_COMPONENT_NBR,
	p.FNC_CODE,
	'AP Entry or Mod',
	p.POST_PERIOD,
    CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END,
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
	--AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
WHERE p.POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(p.AP_PROD_NOBILL_FLG,0) = 0 AND h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2 WHERE h.AP_ID = h2.AP_ID)
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, p.FNC_CODE,
	p.POST_PERIOD, CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END, p.AR_TYPE, p.GLEXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF 



-- ==========================================================
-- 2. AP Billing
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, AP_DATE, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
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
    CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END,
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
	--AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
JOIN dbo.V_AR_INVOICE_DATES AS a
	ON p.AR_INV_NBR = a.AR_INV_NBR
	AND p.AR_TYPE = a.AR_TYPE
WHERE ISNULL(p.AB_FLAG,0) <> 3			
	AND a.AR_POST_PERIOD BETWEEN @start_period AND @end_period AND h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2 WHERE h.AP_ID = h2.AP_ID)
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, p.FNC_CODE,
	p.AR_INV_NBR, p.AR_TYPE, a.AR_POST_PERIOD, CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END, a.GLEXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF

-- ==========================================================
-- 3. AP Billing No Bill
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, AP_INV_VCHR, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
	AP_TYPE, POST_PERIOD, AP_DATE, GLEXACT, AP_PROD_EXT_AMT, AP_NONRESALE_TAX, AP_MARKUP_AMT, WIP_CODE, AP_PMT_FLAG, 
	AP_PARTIAL_FLAG, AP_PMT_REF)
SELECT
	h.VN_FRL_EMP_CODE,
	h.AP_INV_VCHR,
	p.JOB_NUMBER,
	p.JOB_COMPONENT_NBR,
	NULL,
	'Reconcile No Bill',
	g.GLEHPP,
    CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END,
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
	--AND h.AP_SEQ = p.AP_SEQ
JOIN #job_list AS j
	ON p.JOB_NUMBER = j.JOB_NUMBER
JOIN #ap_paid_filter AS d
	ON h.AP_ID = d.AP_ID
JOIN dbo.GLENTHDR AS g
	ON p.GLEXACT_BILL = g.GLEHXACT
WHERE p.AB_FLAG = 3
	AND g.GLEHPP BETWEEN @start_period AND @end_period AND h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2 WHERE h.AP_ID = h2.AP_ID)
GROUP BY h.VN_FRL_EMP_CODE, h.AP_INV_VCHR, p.JOB_NUMBER, p.JOB_COMPONENT_NBR, 
	g.GLEHPP, CASE WHEN @aging_option = 2 THEN h.AP_DATE_PAY ELSE h.AP_INV_DATE END, g.GLEHXACT, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF

-- ==========================================================
-- 4. Open Employee Time with Time Period
-- ==========================================================
INSERT INTO #wip_temp (VN_FRL_EMP_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, AP_DATE, 
	HOURS, HOURS_TOTAL_COST, HOURS_TOTAL_BILL, HOURS_MARKUP_AMT, WIP_CODE)
SELECT
	h.EMP_CODE,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	p.PPPERIOD,
    h.EMP_DATE,
	SUM(ISNULL(d.EMP_HOURS,0)),
	SUM(ISNULL(d.TOTAL_COST,0)),
	SUM(ISNULL(d.TOTAL_BILL,0)),
	SUM(ISNULL(d.EXT_MARKUP_AMT,0)),
	'E'
FROM dbo.EMP_TIME AS h
JOIN dbo.EMP_TIME_DTL AS d
	ON h.ET_ID = d.ET_ID
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT_BILL = g.GLEHXACT
JOIN #gl_post_period AS p
	ON YEAR(h.EMP_DATE) * 100 + MONTH(h.EMP_DATE) = p.GLYYYYMM
WHERE
	h.EMP_DATE BETWEEN @start_date AND @end_date	
	AND ISNULL(d.EMP_NON_BILL_FLAG,0) = 0
	AND ( d.GLEXACT_BILL IS NULL OR g.GLEHPP > @end_period )
GROUP BY h.EMP_CODE, d.JOB_NUMBER, d.JOB_COMPONENT_NBR, p.PPPERIOD, g.GLEHPP, h.EMP_DATE

-- ==========================================================
-- 5. Open Income Only
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	IO_AMT, IO_MARKUP_AMT, WIP_CODE)
SELECT
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	p.PPPERIOD,
	SUM(ISNULL(d.IO_AMOUNT,0)),
	SUM(ISNULL(d.EXT_MARKUP_AMT,0)),
	'I'
FROM dbo.INCOME_ONLY AS d
JOIN #job_list AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT_BILL = g.GLEHXACT
JOIN #gl_post_period AS p
	ON YEAR(d.IO_INV_DATE) * 100 + MONTH(d.IO_INV_DATE) = p.GLYYYYMM
WHERE 
	d.IO_INV_DATE BETWEEN @start_date AND @end_date
	AND ISNULL(d.NON_BILL_FLAG,0) = 0
	AND ( d.GLEXACT_BILL IS NULL OR g.GLEHPP > @end_period )
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, p.PPPERIOD, g.GLEHPP

-- ==========================================================
-- Temp table #office_def_sales_acct								/* PJH 06/03/2020 - added */
-- ==========================================================
CREATE TABLE #office_def_sales_acct (
	PGLACODE_DEF_SALES			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS )
INSERT INTO #office_def_sales_acct
SELECT DISTINCT d.PGLACODE_DEF_SALES
FROM dbo.OFFICE AS d
--SELECT * FROM #office_def_sales_acct

-- ==========================================================
-- 6. Advance Billing
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
JOIN #office_def_sales_acct AS o			/* PJH 06/03/2020 - added */
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(d.AB_FLAG,3) <> 3
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE	

-- ==========================================================
-- 7. Advance Billing NB
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
JOIN #office_def_sales_acct AS o			/* PJH 06/03/2020 - added */
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
LEFT JOIN dbo.GLENTHDR AS g
	ON d.GLEXACT = g.GLEHXACT
WHERE g.GLEHPP BETWEEN @start_period AND @end_period
	AND d.AB_FLAG = 3
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, g.GLEHPP

-- ==========================================================
-- 8. Advance Billing Income Rec
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
JOIN #office_def_sales_acct AS o			/* PJH 06/03/2020 - added */
	ON d.GLACODE_DEF_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD
	
-- ==========================================================
-- 9. Advance Billing Reconcile
-- ==========================================================
INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
	 ADVANCE_RECON, WIP_CODE, ADVANCE_RESALE_TAX, ADVANCE_RECON_COST)
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
JOIN #office_def_sales_acct AS o			/* PJH 06/03/2020 - added */
	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
	AND ISNULL(d.AB_FLAG,3) IN(4,6)
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE

	
-- ==========================================================
-- 10. Advance Billing Accrued Liability
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
-- 11. Advance Billing Accrued Liability NB
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

-- ==========================================================
-- 12. Advance Billing Reconcile Cost
-- ==========================================================
--INSERT INTO #wip_temp (JOB_NUMBER, JOB_COMPONENT_NBR, POST_PERIOD, 
--	 ADVANCE_RECON_COST)
--SELECT
--	d.JOB_NUMBER,
--	d.JOB_COMPONENT_NBR,
--	a.AR_POST_PERIOD,
--	CASE d.FNC_TYPE
--		WHEN 'V' THEN SUM(ISNULL(d.ADV_BILL_NET_AMT,0) + ISNULL(d.EXT_NONRESALE_TAX,0))
--		ELSE 0
--	END
--FROM dbo.ADVANCE_BILLING AS d
--JOIN #job_list AS j
--	ON d.JOB_NUMBER = j.JOB_NUMBER
--JOIN dbo.V_AR_INVOICE_DATES AS a
--	ON d.AR_INV_NBR = a.AR_INV_NBR
--	AND d.AR_TYPE = a.AR_TYPE
--JOIN #office_def_sales_acct AS o			/* PJH 06/03/2020 - added */
--	ON d.GLACODE_SALES = o.PGLACODE_DEF_SALES
--WHERE a.AR_POST_PERIOD BETWEEN @start_period AND @end_period
--	AND ISNULL(d.AB_FLAG,3) IN(4,6)
--GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, a.AR_POST_PERIOD, d.FNC_TYPE	


--SELECT * FROM #wip_temp WHERE JOB_NUMBER = 24

-- ========================================================================================================
-- Populate #wip_temp completed 
-- Sums amounts and inserts into #wip_basic
-- ========================================================================================================

		INSERT INTO #wip_basic
		SELECT
			d.VN_FRL_EMP_CODE,							
			d.AP_INV_VCHR,
			d.JOB_NUMBER,
			d.JOB_COMPONENT_NBR,
			d.AP_TYPE,
			d.POST_PERIOD,
            d.AP_DATE,
			d.WIP_CODE,
			SUM(ISNULL(d.ESTIMATE_AMT,0)),
			SUM(ISNULL(d.ESTIMATE_CONT,0)),
			SUM(ISNULL(d.ESTIMATE_HOURS,0)),
			SUM(ISNULL(d.ESTIMATE_HOURS_AMT,0)),
			SUM(ISNULL(d.ESTIMATE_NET_AMT,0)),
			SUM(ISNULL(d.ESTIMATE_NONRESALE_TAX,0)),
			SUM(ISNULL(d.AP_PROD_EXT_AMT,0)),
			SUM(ISNULL(d.AP_NONRESALE_TAX,0)),
			SUM(ISNULL(d.AP_PROD_EXT_AMT,0) + ISNULL(d.AP_NONRESALE_TAX,0)),
			--SUM(ISNULL(d.AP_MARKUP_AMT,0)),
			d.AP_PMT_FLAG,
			d.AP_PARTIAL_FLAG,
			d.AP_PMT_REF,			
			SUM(ISNULL(d.[HOURS],0)),
			SUM(ISNULL(d.HOURS_TOTAL_BILL,0)),
			SUM(ISNULL(d.HOURS_MARKUP_AMT,0)),
			--SUM(ISNULL(d.HOURS_TOTAL_COST,0)),
			SUM(ISNULL(d.IO_AMT,0)),
			SUM(ISNULL(d.IO_MARKUP_AMT,0)),			
			SUM(ISNULL(d.ADVANCE_AMT,0)),
			SUM(ISNULL(d.ADVANCE_RESALE_TAX,0)),
			SUM(ISNULL(d.ADVANCE_COST,0)),
			SUM(ISNULL(d.ADVANCE_ACCRUED_LIAB,0)),
			SUM(ISNULL(d.ADVANCE_RECON,0)),
			SUM(ISNULL(d.ADVANCE_RECON_COST,0)),
            0,
            0,
            0
		FROM #wip_temp AS d	
		GROUP BY d.VN_FRL_EMP_CODE, d.AP_INV_VCHR, d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.AP_TYPE,  
			d.POST_PERIOD, d.AP_DATE, d.WIP_CODE, d.AP_PMT_FLAG, d.AP_PARTIAL_FLAG, d.AP_PMT_REF
--SELECT * FROM #wip_basic

-- ==========================================================
-- Temp table to hold AP Voucher open WIP flag
-- ==========================================================
CREATE TABLE #voucher_open_wip_flag (							
	AP_INV_VCHR				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_FRL_EMP_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER				int NULL,
	JOB_COMPONENT_NBR		smallint NULL,
	AP_VCHR_WIP_FLAG		tinyint)		
INSERT INTO #voucher_open_wip_flag
SELECT
	d.AP_INV_VCHR,
	d.VN_FRL_EMP_CODE, 
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	CASE 
		WHEN ABS(SUM(d.AP_TOTAL)) >= .01 THEN 1
		ELSE 0
	END
FROM #wip_basic AS d
WHERE d.WIP_CODE IN('D','C')
GROUP BY d.AP_INV_VCHR, d.VN_FRL_EMP_CODE, d.JOB_NUMBER, d.JOB_COMPONENT_NBR
--SELECT * FROM #voucher_open_wip_flag

----
-- Purchase Order amounts
---=

IF @OfficeRestrictions > 0
BEGIN
    INSERT INTO #job_list
	SELECT l.JOB_NUMBER
	FROM dbo.JOB_LOG AS l INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = l.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
    WHERE
        (l.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL) AND
		(l.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (l.CL_CODE + '|' + l.DIV_CODE + '|' + l.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END

    INSERT INTO #wip_basic (JOB_NUMBER, JOB_COMPONENT_NBR, WIP_CODE, OPEN_PO_AMT, AP_TYPE)
    SELECT POD.JOB_NUMBER, POD.JOB_COMPONENT_NBR, 'P', CASE WHEN (POD.PO_COMPLETE = 1 OR PO.VOID_FLAG = 1) THEN 0 ELSE CASE WHEN (ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0)) < 0 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0) END END,
           'Purchase Order'
    FROM 
		    [dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
		    [dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER INNER JOIN
            JOB_LOG AS JL ON JL.JOB_NUMBER = POD.JOB_NUMBER iNNER JOIN
            EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JL.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE LEFT OUTER JOIN 
		    (SELECT
			    AP.PO_NUMBER,
			    AP.PO_LINE_NUMBER,
			    PO_COMPLETE = MAX(ISNULL(AP.PO_COMPLETE, 0)),
			    AP_NET_AMT = SUM(AP.AP_PROD_EXT_AMT),
			    AP_GROSS_AMT = SUM(AP.AP_PROD_EXT_AMT) + SUM(AP.EXT_MARKUP_AMT)
		    FROM 
			    [dbo].[AP_PRODUCTION] AS AP
		    WHERE 
			    ISNULL(AP.PO_NUMBER, 0) <> 0 AND 
			    ISNULL(AP.DELETE_FLAG, 0) = 0 AND 
			    ISNULL(AP.MODIFY_DELETE, 0) = 0
		    GROUP BY 
			    AP.PO_NUMBER, 
			    AP.PO_LINE_NUMBER
		    HAVING 
			    SUM(AP.AP_PROD_EXT_AMT) <> 0 AND
                MAX(ISNULL(AP.PO_COMPLETE, 0)) = 0) AS AP ON AP.PO_NUMBER = POD.PO_NUMBER AND 
												       AP.PO_LINE_NUMBER = POD.LINE_NUMBER 
            WHERE POD.JOB_NUMBER IS NOT NULL AND (JL.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL) AND
		        (JL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		        1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (JL.CL_CODE + '|' + JL.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		        1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (JL.CL_CODE + '|' + JL.DIV_CODE + '|' + JL.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
END
ELSE
BEGIN
    INSERT INTO #wip_basic (JOB_NUMBER, JOB_COMPONENT_NBR, WIP_CODE, OPEN_PO_AMT, AP_TYPE)
    SELECT POD.JOB_NUMBER, POD.JOB_COMPONENT_NBR, 'P', CASE WHEN (POD.PO_COMPLETE = 1 OR PO.VOID_FLAG = 1) THEN 0 ELSE CASE WHEN (ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0)) < 0 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0) END END,
           'Purchase Order'
    FROM 
		    [dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
		    [dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER LEFT OUTER JOIN
            JOB_LOG AS JL ON JL.JOB_NUMBER = POD.JOB_NUMBER LEFT OUTER JOIN 
		    (SELECT
			    AP.PO_NUMBER,
			    AP.PO_LINE_NUMBER,
			    PO_COMPLETE = MAX(ISNULL(AP.PO_COMPLETE, 0)),
			    AP_NET_AMT = SUM(AP.AP_PROD_EXT_AMT),
			    AP_GROSS_AMT = SUM(AP.AP_PROD_EXT_AMT) + SUM(AP.EXT_MARKUP_AMT)
		    FROM 
			    [dbo].[AP_PRODUCTION] AS AP
		    WHERE 
			    ISNULL(AP.PO_NUMBER, 0) <> 0 AND 
			    ISNULL(AP.DELETE_FLAG, 0) = 0 AND 
			    ISNULL(AP.MODIFY_DELETE, 0) = 0
		    GROUP BY 
			    AP.PO_NUMBER, 
			    AP.PO_LINE_NUMBER
            HAVING 
			    SUM(AP.AP_PROD_EXT_AMT) <> 0 AND
                MAX(ISNULL(AP.PO_COMPLETE, 0)) = 0) AS AP ON AP.PO_NUMBER = POD.PO_NUMBER AND 
												       AP.PO_LINE_NUMBER = POD.LINE_NUMBER 
            WHERE POD.JOB_NUMBER IS NOT NULL AND (JL.OFFICE_CODE IN (SELECT * FROM dbo.udf_split_list(@office_list, ',')) OR @office_list IS NULL) AND
		        (JL.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@CLIENT_LIST, ',')) OR @CLIENT_LIST IS NULL) AND
		        1 = CASE WHEN @DIVISION_LIST IS NULL THEN 1 WHEN (JL.CL_CODE + '|' + JL.DIV_CODE) IN (SELECT * FROM dbo.udf_split_list(@DIVISION_LIST, ',')) THEN 1 ELSE 0 END AND
		        1 = CASE WHEN @PRODUCT_LIST IS NULL THEN 1 WHEN (JL.CL_CODE + '|' + JL.DIV_CODE + '|' + JL.PRD_CODE) IN (SELECT * FROM dbo.udf_split_list(@PRODUCT_LIST, ',')) THEN 1 ELSE 0 END
    
END


	

    --SELECT * FROM #wip_basic WHERE JOB_NUMBER = 322

-- ==========================================================
-- Temp table to hold job/comp open WIP flag
-- ==========================================================
CREATE TABLE #job_comp_open_wip_flag (
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	--TEST0						decimal(15,2) NULL,
	JOB_COMP_AP_WIP_FLAG		tinyint,	
	--TEST1						decimal(15,2) NULL,
	JOB_COMP_TOT_WIP_FLAG		tinyint,	
	JOB_COMP_TOT_WIP_NO_ADV_FLAG		tinyint,		
	JOB_COMP_ADV_WIP_FLAG		tinyint,
	--TEST2						decimal(15,2) NULL,
	JOB_COMP_AGING_WIP_FLAG		tinyint,
    JOB_COMP_AGING_AL_PO_FLAG	tinyint,
    JOB_COMP_PO_ONLY_FLAG	    tinyint)
INSERT INTO #job_comp_open_wip_flag
SELECT 	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	--ABS(SUM(d.AP_TOTAL)),
	CASE  
		WHEN ABS(SUM(d.AP_TOTAL)) >= .01 THEN 1
		ELSE 0
	END,
	--ABS(SUM(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT  
	--	+ d.IO_AMT + d.IO_MARKUP_AMT + d.ADVANCE_AMT)),    
    CASE WHEN ABS(SUM(d.AP_TOTAL)) >= .01 OR
              ABS(SUM(d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT)) >= .01 OR
              ABS(SUM(d.IO_AMT + d.IO_MARKUP_AMT)) >= .01 OR
              ABS(SUM(d.ADVANCE_AMT + d.ADVANCE_COST)) >= .01 THEN 1
        ELSE 0
    END,
	--CASE 
	--	WHEN ABS(SUM(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT  
	--	+ d.IO_AMT + d.IO_MARKUP_AMT + d.ADVANCE_AMT + d.ADVANCE_COST)) >= .01 THEN 1
	--	ELSE 0
	--END,
    CASE WHEN ABS(SUM(d.AP_TOTAL)) >= .01 OR
              ABS(SUM(d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT)) >= .01 OR
              ABS(SUM(d.IO_AMT + d.IO_MARKUP_AMT)) >= .01 OR
              ABS(SUM(d.ADVANCE_AMT)) >= .01 THEN 1
        ELSE 0
    END,
 --   CASE 
	--	WHEN ABS(SUM(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT  
	--	+ d.IO_AMT + d.IO_MARKUP_AMT + d.ADVANCE_AMT)) >= .01 THEN 1
	--	ELSE 0
	--END,
	CASE 
		WHEN ABS(SUM(d.ADVANCE_AMT)) >= .01 THEN 1
		ELSE 0
	END,
	--ABS(SUM(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT + d.ADVANCE_AMT)),
    CASE WHEN ABS(SUM(d.AP_TOTAL)) >= .01 OR
              ABS(SUM(d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT)) >= .01 OR
              ABS(SUM(d.ADVANCE_AMT)) >= .01 THEN 1
        ELSE 0
    END,
	--CASE 
	--	WHEN ABS(SUM(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT + d.ADVANCE_AMT)) >= .01 THEN 1
	--	ELSE 0
	--END, 
    CASE 
		WHEN ABS(SUM(ISNULL(d.AP_TOTAL,0))) >= .01 OR
             ABS(SUM(ISNULL(d.OPEN_PO_AMT,0))) >= .01 OR
             ABS(SUM(ISNULL(d.ADVANCE_ACCRUED_LIAB,0))) >= .01 THEN 1
		ELSE 0
	END,
    CASE WHEN ABS(SUM(ISNULL(d.AP_TOTAL,0))) = 0 AND
              ABS(SUM(ISNULL(d.HOURS_TOTAL_BILL,0) + ISNULL(d.HOURS_MARKUP_AMT,0))) = 0 AND
              ABS(SUM(ISNULL(d.IO_AMT,0) + ISNULL(d.IO_MARKUP_AMT,0))) = 0 AND
              ABS(SUM(ISNULL(d.ADVANCE_AMT,0) + ISNULL(d.ADVANCE_COST,0))) = 0 AND
              ABS(SUM(ISNULL(d.OPEN_PO_AMT,0))) >= .01  THEN 1
        ELSE 0
    END
FROM #wip_basic AS d
GROUP BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR
--SELECT * FROM #job_comp_open_wip_flag WHERE JOB_NUMBER = 1
	
-- ==========================================================
-- Temp table to hold max posting period for each AP invoice
-- Used for AP aging
-- ==========================================================
CREATE TABLE #max_posting_period (
	VN_FRL_EMP_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_INV_VCHR					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	PPPERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PPENDDATE					smalldatetime)
INSERT INTO #max_posting_period
SELECT 	d.VN_FRL_EMP_CODE,
	d.AP_INV_VCHR,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	MAX(d.POST_PERIOD),
	(SELECT g.PPENDDATE FROM dbo.POSTPERIOD AS g WHERE MAX(d.POST_PERIOD) = g.PPPERIOD)
FROM #wip_basic AS d
WHERE d.WIP_CODE = 'D'
GROUP BY d.VN_FRL_EMP_CODE, d.VN_FRL_EMP_CODE, d.AP_INV_VCHR, d.JOB_NUMBER, d.JOB_COMPONENT_NBR
--SELECT * FROM #max_posting_period
	
-- ==========================================================
-- Estimate Amounts - only extracts estimates for jobs in #wip basic
-- ==========================================================
INSERT INTO #wip_basic (JOB_NUMBER, JOB_COMPONENT_NBR, WIP_CODE, ESTIMATE_AMT, ESTIMATE_CONT, 
	ESTIMATE_NET_AMT, ESTIMATE_NONRESALE_TAX, ESTIMATE_HOURS, ESTIMATE_HOURS_AMT)
SELECT
	a.JOB_NUMBER,
	a.JOB_COMPONENT_NBR,
	'Q',
	SUM(ISNULL(d.LINE_TOTAL,0)),
	SUM(ISNULL(d.LINE_TOTAL_CONT,0)),
	SUM(ISNULL(d.EST_REV_EXT_AMT,0)),
	SUM(ISNULL(d.EXT_NONRESALE_TAX,0)),
    0,
	0
FROM dbo.ESTIMATE_APPROVAL AS a
JOIN dbo.ESTIMATE_REV_DET AS d
	ON a.ESTIMATE_NUMBER = d.ESTIMATE_NUMBER
	AND a.EST_COMPONENT_NBR = d.EST_COMPONENT_NBR
	AND a.EST_QUOTE_NBR = d.EST_QUOTE_NBR
	AND a.EST_REVISION_NBR = d.EST_REV_NBR
JOIN FUNCTIONS AS F ON F.FNC_CODE = d.FNC_CODE --AND F.FNC_TYPE = 'E'
JOIN #job_comp_open_wip_flag AS f
	ON a.JOB_NUMBER = f.JOB_NUMBER
	AND a.JOB_COMPONENT_NBR = f.JOB_COMPONENT_NBR
WHERE f. JOB_COMP_TOT_WIP_FLAG = 1		
GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR	
--SELECT * FROM #wip_basic WHERE WIP_CODE = 'Q' ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR 

UPDATE #wip_basic
SET ESTIMATE_HOURS = (SELECT SUM(ISNULL(d.EST_REV_QUANTITY,0))
                      FROM dbo.ESTIMATE_APPROVAL AS a
                        JOIN dbo.ESTIMATE_REV_DET AS d
	                        ON a.ESTIMATE_NUMBER = d.ESTIMATE_NUMBER
	                        AND a.EST_COMPONENT_NBR = d.EST_COMPONENT_NBR
	                        AND a.EST_QUOTE_NBR = d.EST_QUOTE_NBR
	                        AND a.EST_REVISION_NBR = d.EST_REV_NBR
                        JOIN FUNCTIONS AS F ON F.FNC_CODE = d.FNC_CODE AND F.FNC_TYPE = 'E'
                        WHERE #wip_basic.JOB_NUMBER = a.JOB_NUMBER
	                        AND #wip_basic.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR	
                        GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR)
WHERE WIP_CODE = 'Q'

UPDATE #wip_basic
SET ESTIMATE_HOURS_AMT = (SELECT SUM(ISNULL(d.LINE_TOTAL, 0) - ISNULL(d.EXT_STATE_RESALE, 0) - ISNULL(d.EXT_COUNTY_RESALE, 0) - ISNULL(d.EXT_CITY_RESALE, 0))
                      FROM dbo.ESTIMATE_APPROVAL AS a
                        JOIN dbo.ESTIMATE_REV_DET AS d
	                        ON a.ESTIMATE_NUMBER = d.ESTIMATE_NUMBER
	                        AND a.EST_COMPONENT_NBR = d.EST_COMPONENT_NBR
	                        AND a.EST_QUOTE_NBR = d.EST_QUOTE_NBR
	                        AND a.EST_REVISION_NBR = d.EST_REV_NBR
                        JOIN FUNCTIONS AS F ON F.FNC_CODE = d.FNC_CODE AND F.FNC_TYPE = 'E'                        
                        WHERE #wip_basic.JOB_NUMBER = a.JOB_NUMBER
	                        AND #wip_basic.JOB_COMPONENT_NBR = a.JOB_COMPONENT_NBR		
                        GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR)
WHERE WIP_CODE = 'Q'

-- =================================================================================================================
-- Final extraction query
-- =================================================================================================================	

--UPDATE #wip_basic
--SET AGING_FLAG = CASE WHEN (SELECT SUM(ISNULL(ADVANCE_AMT,0)) + SUM(ISNULL(AP_TOTAL,0)) + SUM(ISNULL(HOURS_TOTAL_BILL,0)) + SUM(ISNULL(HOURS_MARKUP_AMT,0))
--                            FROM #wip_basic GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR) <> 0 THEN 1 ELSE 0 END

--SELECT * FROM #wip_basic d LEFT JOIN #job_comp_open_wip_flag AS f
--	ON d.JOB_NUMBER = f.JOB_NUMBER
--	AND d.JOB_COMPONENT_NBR = f.JOB_COMPONENT_NBR

-- ==========================================================
-- Temp data table for aging
-- ==========================================================
CREATE TABLE #wip_aging (
	JOB_NUMBER					int NULL,
	JOB_COMPONENT_NBR			smallint NULL,
	AMT				bit,
	AP_AMT				bit)

INSERT INTO #wip_aging
SELECT JOB_NUMBER, JOB_COMPONENT_NBR,
       CASE WHEN ABS(SUM(ISNULL(AP_TOTAL,0))) >= .01 OR
                 ABS(SUM(ISNULL(HOURS_TOTAL_BILL,0) + ISNULL(HOURS_MARKUP_AMT,0))) >= .01 OR
                 ABS(SUM(ISNULL(ADVANCE_AMT,0))) >= .01 THEN 1
           ELSE 0
       END,
       CASE WHEN ABS(SUM(ISNULL(AP_TOTAL,0))) >= .01 OR
                 ABS(SUM(ISNULL(ADVANCE_AMT,0))) >= .01 THEN 1
           ELSE 0
       END
       --SUM(ISNULL(ADVANCE_AMT,0)) + SUM(ISNULL(AP_TOTAL,0)) + SUM(ISNULL(HOURS_TOTAL_BILL,0)) + SUM(ISNULL(HOURS_MARKUP_AMT,0)),
       --SUM(ISNULL(ADVANCE_AMT,0)) + SUM(ISNULL(AP_TOTAL,0))
FROM #wip_basic GROUP BY JOB_NUMBER, JOB_COMPONENT_NBR ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR


--SELECT * FROM #wip_aging  WHERE JOB_NUMBER = 322   



UPDATE #wip_basic
SET AGING_FLAG = (SELECT AMT FROM #wip_aging WHERE JOB_NUMBER = #wip_basic.JOB_NUMBER AND JOB_COMPONENT_NBR = #wip_basic.JOB_COMPONENT_NBR)

UPDATE #wip_basic
SET AGING_AP_FLAG = (SELECT AP_AMT FROM #wip_aging WHERE JOB_NUMBER = #wip_basic.JOB_NUMBER AND JOB_COMPONENT_NBR = #wip_basic.JOB_COMPONENT_NBR)

--SELECT * FROM #wip_basic              

--CREATE TABLE #po_list (JOB_NUMBER int, JOB_COMPONENT_NBR smallint, OPEN_PO_AMT decimal(15,2))

--INSERT INTO #po_list
--SELECT POD.JOB_NUMBER, POD.JOB_COMPONENT_NBR, CASE WHEN (POD.PO_COMPLETE = 1 OR PO.VOID_FLAG = 1) THEN 0 ELSE CASE WHEN (ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0)) < 0 THEN 0 ELSE ISNULL(POD.PO_EXT_AMOUNT, 0) - ISNULL(AP.AP_NET_AMT, 0) END END FROM 
--		[dbo].[PURCHASE_ORDER] AS PO INNER JOIN 
--		[dbo].[PURCHASE_ORDER_DET] AS POD ON POD.PO_NUMBER = PO.PO_NUMBER LEFT OUTER JOIN 
--		(SELECT
--			AP.PO_NUMBER,
--			AP.PO_LINE_NUMBER,
--			PO_COMPLETE = MAX(ISNULL(AP.PO_COMPLETE, 0)),
--			AP_NET_AMT = SUM(AP.AP_PROD_EXT_AMT),
--			AP_GROSS_AMT = SUM(AP.AP_PROD_EXT_AMT) + SUM(AP.EXT_MARKUP_AMT)
--		FROM 
--			[dbo].[AP_PRODUCTION] AS AP
--		WHERE 
--			ISNULL(AP.PO_NUMBER, 0) <> 0 AND 
--			ISNULL(AP.DELETE_FLAG, 0) = 0 AND 
--			ISNULL(AP.MODIFY_DELETE, 0) = 0
--		GROUP BY 
--			AP.PO_NUMBER, 
--			AP.PO_LINE_NUMBER
--		HAVING 
--			SUM(AP.AP_PROD_EXT_AMT) <> 0) AS AP ON AP.PO_NUMBER = POD.PO_NUMBER AND 
--												   AP.PO_LINE_NUMBER = POD.LINE_NUMBER WHERE POD.JOB_NUMBER IN (SELECT JOB_NUMBER FROM #wip_basic)
                                                   

	
--SELECT * FROM #po_list

--UPDATE #wip_basic
--SET OPEN_PO_AMT = (SELECT SUM(OPEN_PO_AMT) FROM #po_list WHERE #po_list.JOB_NUMBER = #wip_basic.JOB_NUMBER AND #po_list.JOB_COMPONENT_NBR = #wip_basic.JOB_COMPONENT_NBR GROUP BY #po_list.JOB_NUMBER, #po_list.JOB_COMPONENT_NBR)

--SELECT * FROM #wip_temp WHERE JOB_NUMBER = 405

SELECT
	[ID]						= NEWID(),
	[OfficeCode]				= j.OFFICE_CODE,
	[OfficeDescription]			= o.OFFICE_NAME,
	[ClientCode]				= j.CL_CODE,
	[ClientName]				= c.CL_NAME,
	[DivisionCode]				= j.DIV_CODE,
	[DivisionName]				= dv.DIV_NAME,
	[ProductCode]				= j.PRD_CODE,
	[ProductDescription]		= p.PRD_DESCRIPTION,
	[JobNumber]					= d.JOB_NUMBER,
	[JobDescription]			= j.JOB_DESC,
	[JobComponentNumber]		= d.JOB_COMPONENT_NBR,
	[JobComponentDesc]			= jc.JOB_COMP_DESC,
	[ClientPO]					= jc.JOB_CL_PO_NBR,
	[ClientReference]			= j.JOB_CLI_REF,
	[AccountExecutive]			= jc.EMP_CODE,
	[Status]					= pc.JOB_PROCESS_DESC,
	[StatusCode]				= CASE jc.JOB_PROCESS_CONTRL
									WHEN 6 THEN 'C'
									WHEN 12 THEN 'C'
									ELSE 'O'
									END,
    [SalesClass]                = j.SC_CODE,
    [SalesClassDescription]     = sc.SC_DESCRIPTION,
	[JobCompOpenDate]			= jc.JOB_COMP_DATE,
	[JobCompFirstUseDate]		= jc.JOB_FIRST_USE_DATE,
	[JobStartDate]		        = jc.[START_DATE],
	[JobDueDate]		        = jc.JOB_FIRST_USE_DATE,
	[JobCompCloseDate]			= JOBT.COMPLETED_DATE,		
    [LabelFromUDFTable1]        = JUDV1.UDV_DESC, 
	[LabelFromUDFTable2]        = JUDV2.UDV_DESC,
	[LabelFromUDFTable3]        = JUDV3.UDV_DESC,
	[LabelFromUDFTable4]        = JUDV4.UDV_DESC,
	[LabelFromUDFTable5]        = JUDV5.UDV_DESC,
	[VendorCode]				= d.VN_FRL_EMP_CODE,
	[VendorName]				= CASE
									WHEN d.WIP_CODE = 'A' THEN 'Advance Billing'
									WHEN d.WIP_CODE = 'L' THEN 'Advance Billing'
									ELSE v.VN_NAME
									END,
	[APInvoiceNumber]			= d.AP_INV_VCHR,
	[EstimateNetAmount]			= ISNULL(d.ESTIMATE_NET_AMT + d.ESTIMATE_NONRESALE_TAX,0),
	[EstimateAmount]			= ISNULL(d.ESTIMATE_AMT + d.ESTIMATE_CONT,0),
	[EstimateHours]			    = ISNULL(d.ESTIMATE_HOURS,0),
	[EstimateHoursAmount]		= ISNULL(d.ESTIMATE_HOURS_AMT,0),
	[APTotal]					= ISNULL(d.AP_TOTAL,0),
	--[AP Ext Net Amount]		= d.AP_PROD_EXT_AMT,
	--[AP Non Resale Tax]		= d.AP_NONRESALE_TAX,
	--[AP Markup Amount]		= d.AP_MARKUP_AMT,
	[APDebit]					= ISNULL(CASE
									WHEN d.WIP_CODE = 'D' AND d.AP_TOTAL >=0 THEN d.AP_TOTAL
									WHEN d.WIP_CODE = 'C' AND d.AP_TOTAL >=0 THEN d.AP_TOTAL
									ELSE 0
									END,0),
	[APCredit]					= ISNULL(CASE
									WHEN d.WIP_CODE = 'D' AND d.AP_TOTAL <=0 THEN d.AP_TOTAL * -1
									WHEN d.WIP_CODE = 'C' AND d.AP_TOTAL <=0 THEN d.AP_TOTAL * -1
									ELSE 0
									END,0),
	[APType]					= d.AP_TYPE,		--(AP Entry or Mod, Void Inv#, Billing Inv#, Reconcile No Bill)
	[APPaymentFlag]				= CASE
									WHEN d.AP_PMT_FLAG = 1 THEN 'Paid'
									ELSE ''
									END,
	[APPartialFlag]				= CASE
									WHEN d.AP_PARTIAL_FLAG = 1 THEN 'Part'
									ELSE ''
									END,
	[APPaymentRef]				= d.AP_PMT_REF,
	[EmpUnbilledHours]			= ISNULL(d.[HOURS],0),
	[EmpUnbilledAmount]			= ISNULL(d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT,0),
	--[Emp Markup Amount]		= d.HOURS_MARKUP_AMT,
	--[Emp Cost Amount]			= d.HOURS_TOTAL_COST,
	[IncomeOnlyUnbilled]		= ISNULL(d.IO_AMT + d.IO_MARKUP_AMT,0),
	--[IO Markup Amount]		= d.IO_MARKUP_AMT,
	[DeferredSales]				= ISNULL(d.ADVANCE_AMT,0),
	[DefSaleRecognized]			= ISNULL(d.ADVANCE_RECON,0),
	--[Advance Amount]			= d.ADVANCE_AMT,
	--[Advance Reconciliation]	= d.ADVANCE_RECON,
	--[Advance Resale Tax]		= d.ADVANCE_RESALE_TAX,
	[DeferredCost]			    = ISNULL(d.ADVANCE_COST,0),
	[DeferredCostRecognized]    = ISNULL(d.ADVANCE_RECON_COST,0),
	[AdvanceAccruedLiab]		= ISNULL(d.ADVANCE_ACCRUED_LIAB,0),
    [OpenPurchaseOrderAmount]   = ISNULL(d.OPEN_PO_AMT,0),
	[PostPeriod]				= ISNULL(d.POST_PERIOD,''),
    [AgingDate      ]           = d.AP_DATE,
	[AgingPeriod] 				= CASE																		--#002 (Change [PostPeriodforAging] to [AgingPeriod])
									WHEN d.WIP_CODE = 'C' THEN m.PPPERIOD
									WHEN d.WIP_CODE = 'D' THEN m.PPPERIOD
									WHEN d.WIP_CODE = 'E' THEN g.PPPERIOD
									ELSE ''
									END,
	[Current]					= ISNULL(CASE
									WHEN d.AP_DATE >= @aging_date AND d.WIP_CODE = 'C' THEN d.AP_TOTAL 
									WHEN d.AP_DATE >= @aging_date AND d.WIP_CODE = 'D' THEN d.AP_TOTAL
									WHEN d.AP_DATE >= @aging_date AND d.WIP_CODE = 'E' THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),								
	[ThirtyDays]				= ISNULL(CASE
									WHEN (d.AP_DATE >= DATEADD(day, -30, @aging_date)) AND (d.WIP_CODE = 'C') THEN d.AP_TOTAL 
									WHEN (d.AP_DATE >= DATEADD(day, -30, @aging_date)) AND (d.WIP_CODE = 'D') THEN d.AP_TOTAL
									WHEN (d.AP_DATE >= DATEADD(day, -30, @aging_date)) AND (d.WIP_CODE = 'E') THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),									
	[SixtyDays]					= ISNULL(CASE
									WHEN (d.AP_DATE < DATEADD(day, -30, @aging_date) AND d.AP_DATE >= DATEADD(day, -60, @aging_date)) AND (d.WIP_CODE = 'C') THEN d.AP_TOTAL 
									WHEN (d.AP_DATE < DATEADD(day, -30, @aging_date) AND d.AP_DATE >= DATEADD(day, -60, @aging_date)) AND (d.WIP_CODE = 'D') THEN d.AP_TOTAL
									WHEN (d.AP_DATE < DATEADD(day, -30, @aging_date) AND d.AP_DATE >= DATEADD(day, -60, @aging_date)) AND (d.WIP_CODE = 'E') THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),									
	[NinetyDays]				= ISNULL(CASE
									WHEN (d.AP_DATE < DATEADD(day, -60, @aging_date) AND d.AP_DATE >= DATEADD(day, -90, @aging_date)) AND (d.WIP_CODE = 'C') THEN d.AP_TOTAL 
									WHEN (d.AP_DATE < DATEADD(day, -60, @aging_date) AND d.AP_DATE >= DATEADD(day, -90, @aging_date)) AND (d.WIP_CODE = 'D') THEN d.AP_TOTAL
									WHEN (d.AP_DATE < DATEADD(day, -60, @aging_date) AND d.AP_DATE >= DATEADD(day, -90, @aging_date)) AND (d.WIP_CODE = 'E') THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),								
	[OneHundredTwentyDays]		= ISNULL(CASE
									WHEN (d.AP_DATE < DATEADD(day, -90, @aging_date) AND d.AP_DATE >= DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'C') THEN d.AP_TOTAL 
									WHEN (d.AP_DATE < DATEADD(day, -90, @aging_date) AND d.AP_DATE >= DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'D') THEN d.AP_TOTAL
									WHEN (d.AP_DATE < DATEADD(day, -90, @aging_date) AND d.AP_DATE >= DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'E') THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),							
	[Over120Days]				= ISNULL(CASE
									WHEN (d.AP_DATE < DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'C') THEN d.AP_TOTAL 
									WHEN (d.AP_DATE < DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'D') THEN d.AP_TOTAL
									WHEN (d.AP_DATE < DATEADD(day, -120, @aging_date)) AND (d.WIP_CODE = 'E') THEN d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT
									ELSE 0
									END,0),
	[TotalAging]				= ISNULL(d.AP_TOTAL + d.HOURS_TOTAL_BILL + d.HOURS_MARKUP_AMT,0),			--#002 (+ d.ADVANCE_AMT)
	[WIPCode]						= d.WIP_CODE,						--(Q, D, C, E, I, A, L)
	[APVoucherWIPBalanceFlag]	= ISNULL(vo.AP_VCHR_WIP_FLAG,0),		--1 = open or WIP balance exists	
	[JobCompAPWIPBalanceFlag]	= f.JOB_COMP_AP_WIP_FLAG,				--1 = open or WIP balance exists
    [JobCompAgingWIPFlag]       = d.AGING_FLAG,
    [JobCompAPAgingWIPFlag]     = d.AGING_AP_FLAG,
    [JobCompTotalWIPNoAdvCostFlag] = f.JOB_COMP_TOT_WIP_NO_ADV_FLAG,
    [JobCompAgingWIPALPOFlag] = f.JOB_COMP_AGING_AL_PO_FLAG,
    [JobCompTotalAdvFlag] = f.JOB_COMP_ADV_WIP_FLAG,
    [JobCompPurchaseOrderOnlyFlag] = f.JOB_COMP_PO_ONLY_FLAG
FROM #wip_basic AS d
LEFT JOIN dbo.JOB_LOG AS j
	ON d.JOB_NUMBER = j.JOB_NUMBER
LEFT JOIN dbo.JOB_COMPONENT AS jc
	ON d.JOB_NUMBER = jc.JOB_NUMBER
	AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
LEFT JOIN dbo.JOB_PROC_CONTROLS AS pc
	ON	jc.JOB_PROCESS_CONTRL = pc.JOB_PROCESS_CONTRL	
LEFT JOIN dbo.OFFICE AS o
	ON j.OFFICE_CODE = o.OFFICE_CODE
LEFT JOIN dbo.CLIENT AS c
	ON j.CL_CODE = c.CL_CODE
LEFT JOIN dbo.DIVISION AS dv
	ON j.CL_CODE = dv.CL_CODE
	AND j.DIV_CODE = dv.DIV_CODE
LEFT JOIN dbo.PRODUCT AS p
	ON j.CL_CODE = p.CL_CODE
	AND j.DIV_CODE = p.DIV_CODE
	AND j.PRD_CODE = p.PRD_CODE	
LEFT JOIN dbo.SALES_CLASS AS sc
    ON sc.SC_CODE = j.SC_CODE
LEFT OUTER JOIN
		dbo.JOB_LOG_UDV1 AS JUDV1 ON JUDV1.UDV_CODE = j.UDV1_CODE LEFT OUTER JOIN
		dbo.JOB_LOG_UDV2 AS JUDV2 ON JUDV2.UDV_CODE = j.UDV2_CODE LEFT OUTER JOIN
		dbo.JOB_LOG_UDV3 AS JUDV3 ON JUDV3.UDV_CODE = j.UDV3_CODE LEFT OUTER JOIN
		dbo.JOB_LOG_UDV4 AS JUDV4 ON JUDV4.UDV_CODE = j.UDV4_CODE LEFT OUTER JOIN
		dbo.JOB_LOG_UDV5 AS JUDV5 ON JUDV5.UDV_CODE = j.UDV5_CODE
LEFT OUTER JOIN
		dbo.JOB_TRAFFIC AS JOBT ON JOBT.JOB_NUMBER = jc.JOB_NUMBER AND JOBT.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
LEFT JOIN dbo.VENDOR AS v
	ON d.VN_FRL_EMP_CODE = v.VN_CODE
LEFT JOIN #gl_post_period AS g
	ON d.POST_PERIOD = g.PPPERIOD
LEFT JOIN #max_posting_period AS m
	ON d.VN_FRL_EMP_CODE = m.VN_FRL_EMP_CODE
	AND d.AP_INV_VCHR = m.AP_INV_VCHR
	AND d.JOB_NUMBER = m.JOB_NUMBER
	AND d.JOB_COMPONENT_NBR = m.JOB_COMPONENT_NBR	
LEFT JOIN #job_comp_open_wip_flag AS f
	ON d.JOB_NUMBER = f.JOB_NUMBER
	AND d.JOB_COMPONENT_NBR = f.JOB_COMPONENT_NBR
LEFT JOIN #voucher_open_wip_flag AS vo
	ON d.AP_INV_VCHR = vo.AP_INV_VCHR
	AND d.VN_FRL_EMP_CODE = vo.VN_FRL_EMP_CODE
	AND d.JOB_NUMBER = vo.JOB_NUMBER
	AND d.JOB_COMPONENT_NBR = vo.JOB_COMPONENT_NBR
WHERE f.JOB_COMP_TOT_WIP_FLAG = 1 OR f.JOB_COMP_ADV_WIP_FLAG = 1 OR ISNULL(d.OPEN_PO_AMT,0) <> 0 --OR ISNULL(d.ADVANCE_ACCRUED_LIAB,0) <> 0
										
--AND d.WIP_CODE IN ('E', 'I')   /* DEBUG - for matching rows with advsp_production_wip */
			

ORDER BY d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.AP_INV_VCHR	
END
GO


GRANT EXECUTE ON [advsp_production_wip_detail] TO PUBLIC AS dbo
GO