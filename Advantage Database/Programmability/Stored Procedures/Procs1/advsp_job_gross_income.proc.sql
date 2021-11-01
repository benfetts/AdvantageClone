
CREATE PROCEDURE [dbo].[advsp_job_gross_income]

AS
BEGIN
	SET NOCOUNT ON;
		
	--Main data table #job_amounts==========================================================
	CREATE TABLE #job_amounts(
		REC_SOURCE								varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER								int NULL,
		JOB_COMPONENT_NBR						smallint NULL,
		FNC_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FNC_TYPE								varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		GROSS_BILLINGS							decimal(15,2) NULL,
		COST_AMT								decimal(15,2) NULL,
		NB_COST									decimal(15,2) NULL,
		HOURS_COST								decimal(15,2) NULL,
		AR_INV_NBR								int NULL,
		AR_POST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)	
	
	--Temp table #sales_accts===================================================================
	CREATE TABLE #sales_accts_dtl(PGLACODE_SALES varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #sales_accts_dtl
	SELECT DISTINCT PGLACODE_SALES FROM dbo.OFFICE
	INSERT INTO #sales_accts_dtl
	SELECT DISTINCT PGLACODE_SALES FROM dbo.OFF_SC_ACCTS
	INSERT INTO #sales_accts_dtl
	SELECT DISTINCT PGLACODE_SALES FROM dbo.OFF_SC_FNC_ACCTS
	INSERT INTO #sales_accts_dtl
	SELECT DISTINCT PGLACODE_SALES FROM dbo.OFF_FNC_ACCTS
	
	CREATE TABLE #sales_accts(PGLACODE_SALES varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #sales_accts
	SELECT DISTINCT PGLACODE_SALES FROM #sales_accts_dtl
	WHERE PGLACODE_SALES IS NOT NULL
	
	--SELECT * FROM #sales_accts
	
	--Temp table #cost_accts===================================================================
	CREATE TABLE #cost_accts(PGLACODE_ACC_COS varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #cost_accts
	SELECT DISTINCT PGLACODE_ACC_COS FROM dbo.OFFICE
	WHERE PGLACODE_ACC_COS IS NOT NULL
	
	--SELECT * FROM #cost_accts
		
	--MAIN EXTRACTION ROUTINE===================================================================
	--Advance Billing - Cost--------------------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'ab cost',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.FNC_TYPE,
		0,
		ISNULL(a.ADV_BILL_NET_AMT,0)+ISNULL(a.EXT_NONRESALE_TAX,0),
		0,
		0,
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.ADVANCE_BILLING AS a
	JOIN #cost_accts AS c
		ON a.GLACODE_COS = c.PGLACODE_ACC_COS
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
	WHERE ISNULL(a.AB_FLAG,0)<>3
	AND a.FNC_TYPE<>'V'			
				
	--Advance Billing - Billings----------------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'ab billings',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.FNC_TYPE,
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		0,
		0,
		0,
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.ADVANCE_BILLING AS a
	JOIN #sales_accts AS s
		ON a.GLACODE_SALES = s.PGLACODE_SALES
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
			
	--Advance Billing - Inc Rec------------------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'ab inc rec',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		NULL,
		NULL,
		ISNULL(a.REC_AMT,0),
		0,
		0,
		0,
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.INCOME_REC AS a
	JOIN #sales_accts AS s
		ON a.GLACODE_SALES = s.PGLACODE_SALES
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
						
	--Advance Billing - NoBill Billings-----------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'ab NoBill Bill',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.FNC_TYPE,
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		0,
		0,
		0,
		a.AR_INV_NBR,
		g.GLEHPP		
	FROM dbo.ADVANCE_BILLING AS a
	JOIN #sales_accts AS s
		ON a.GLACODE_SALES = s.PGLACODE_SALES
	JOIN dbo.GLENTHDR AS g
		ON a.GLEXACT=g.GLEHXACT
	WHERE a.AB_FLAG=3	
						
	--Advance Billing - NoB Cost-----------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'ab NoB Cost',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.FNC_TYPE,
		0,
		ISNULL(a.ADV_BILL_NET_AMT,0)+ISNULL(a.EXT_NONRESALE_TAX,0),
		0,
		0,
		a.AR_INV_NBR,
		g.GLEHPP		
	FROM dbo.ADVANCE_BILLING AS a
	JOIN #cost_accts AS c
		ON a.GLACODE_COS = c.PGLACODE_ACC_COS
	JOIN dbo.GLENTHDR AS g
		ON a.GLEXACT=g.GLEHXACT
	WHERE a.AB_FLAG=3
		AND a.FNC_TYPE='V'			
				
	--Employee Time - Billings & Cost-------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'emp time',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'E',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		0,
		0,
		ISNULL(a.TOTAL_COST,0),
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.EMP_TIME_DTL AS a
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
	WHERE ISNULL(a.AB_FLAG,0)<>3			
				
	--Income Only - Billings----------------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'io bill',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'I',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		0,
		0,
		0,
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.INCOME_ONLY AS a
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
	WHERE ISNULL(a.AB_FLAG,0)<>3			
				
	--Production - Billings & Cost-----------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'prod',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'V',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		ISNULL(a.AP_PROD_EXT_AMT,0)+ISNULL(a.EXT_NONRESALE_TAX,0),
		0,
		0,
		a.AR_INV_NBR,
		d.AR_POST_PERIOD		
	FROM dbo.AP_PRODUCTION AS a
	JOIN dbo.V_AR_INVOICE_DATES AS d
		ON a.AR_INV_NBR=d.AR_INV_NBR
		AND a.AR_TYPE=d.AR_TYPE	
	WHERE ISNULL(a.AB_FLAG,0)<>3
						
	--Income Only - NoB Billings-----------------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'io NoB Bill',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'I',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		0,
		0,
		0,
		a.AR_INV_NBR,
		g.GLEHPP		
	FROM dbo.INCOME_ONLY AS a
	JOIN dbo.GLENTHDR AS g
		ON a.GLEXACT_BILL=g.GLEHXACT
	WHERE a.AB_FLAG=3	
						
	--Employee Time - NoB Billings & Cost----------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'emp time NoB',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'E',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		ISNULL(a.TOTAL_COST,0),
		0,
		0,
		a.AR_INV_NBR,
		g.GLEHPP		
	FROM dbo.EMP_TIME_DTL AS a
	JOIN dbo.GLENTHDR AS g
		ON a.GLEXACT_BILL=g.GLEHXACT
	WHERE a.AB_FLAG=3	
						
	--Production - NoB Billings & Cost----------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'prod NoB',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		'V',
		ISNULL(a.LINE_TOTAL,0)+ISNULL(a.EXT_STATE_RESALE,0)+ISNULL(a.EXT_COUNTY_RESALE,0)+ISNULL(a.EXT_CITY_RESALE,0),
		ISNULL(a.AP_PROD_EXT_AMT,0)+ISNULL(a.EXT_NONRESALE_TAX,0),
		0,
		0,
		a.AR_INV_NBR,
		g.GLEHPP		
	FROM dbo.AP_PRODUCTION AS a
	JOIN dbo.GLENTHDR AS g
		ON a.GLEXACT_BILL=g.GLEHXACT
	WHERE a.AB_FLAG=3
						
	--Production - NonBill Cost-----------------------------------------------------
	INSERT INTO #job_amounts
	SELECT
		'prod nb cost',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
	    'V',
		0,
		0,
		ISNULL(a.AP_PROD_EXT_AMT,0)+ISNULL(a.EXT_NONRESALE_TAX,0),
		0,
		a.AR_INV_NBR,
	    a.POST_PERIOD		
	FROM dbo.AP_PRODUCTION AS a
	WHERE a.AP_PROD_NOBILL_FLG=1
	
	--SELECT * FROM #job_amounts
	
	--Summarize detail data and add DP_TM_CODE========================================================
	SELECT
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		a.FNC_CODE,
		a.FNC_TYPE,
		f.DP_TM_CODE,
		SUM(a.GROSS_BILLINGS) AS GROSS_BILLINGS,
		SUM(a.COST_AMT) AS COST_AMT,
		SUM(a.NB_COST) AS NB_COST,
		SUM(a.HOURS_COST) AS HOURS_COST,
		a.AR_INV_NBR,
		a.AR_POST_PERIOD
	FROM #job_amounts AS a	
	LEFT JOIN dbo.FUNCTIONS AS f
		ON a.FNC_CODE=f.FNC_CODE
	GROUP BY a.JOB_NUMBER, a.JOB_COMPONENT_NBR, a.FNC_CODE, a.FNC_TYPE, f.DP_TM_CODE,
		a.AR_INV_NBR, a.AR_POST_PERIOD	
		
END
