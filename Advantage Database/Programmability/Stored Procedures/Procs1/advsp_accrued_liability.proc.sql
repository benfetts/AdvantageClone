
CREATE PROCEDURE [dbo].[advsp_accrued_liability] (
	@office_list varchar(4000) = '',
	@end_period varchar(6) = '999912')
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #accr_liab (
	GLACODE_ACC_AP					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JOB_NUMBER						int NOT NULL,
	JOB_COMPONENT_NBR				smallint NOT NULL,
	FNC_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ADV_BILL_NET_AMT				decimal(14,2) NULL,
	EXT_NONRESALE_TAX				decimal(14,2) NULL,
	POST_PERIOD						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	INVOICE_DATE					smalldatetime)

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
-- EXTRACTION ROUTINE
-- ==========================================================
INSERT INTO #accr_liab
SELECT
	d.GLACODE_ACC_AP,
	d.JOB_NUMBER,
	d.JOB_COMPONENT_NBR,
	d.FNC_CODE,
	ISNULL(ADV_BILL_NET_AMT,0),
	ISNULL(EXT_NONRESALE_TAX,0),
	CASE ISNULL(d.AB_FLAG,0)
		WHEN 3 THEN g.GLEHPP
		ELSE v.AR_POST_PERIOD
	END,
	CASE ISNULL(d.AB_FLAG,0)
		WHEN 3 THEN g.GLEHENTDATE
		ELSE v.AR_INV_DATE
	END	
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

SELECT * FROM #accr_liab

END
