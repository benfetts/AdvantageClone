
CREATE PROCEDURE [dbo].[advsp_job_detail_cost_and_billing_prod]

AS
BEGIN
	SET NOCOUNT ON;
	
	--Main data table #job_detail_cost_and_billing
	CREATE TABLE #job_detail_cost_and_billing(
		REC_SOURCE								varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		JOB_NUMBER								int NULL,
		JOB_COMPONENT_NBR						smallint NULL,
		ORDER_NBR								int NULL,
		LINE_NBR								smallint NULL,
		FNC_TYPE								varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FNC_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FNC_DESC								varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		ITEM_DATE								smalldatetime,
		POST_PERIOD								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		VN_FRL_EMP_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		FEE_TIME								tinyint NULL,
		EMP_HOURS								decimal(15,2) NULL,
		BILL_AMT								decimal(15,2) NULL,
		EXT_MARKUP_AMT							decimal(15,2) NULL,
		NONRESALE_TAX							decimal(15,2) NULL,
		RESALE_TAX								decimal(15,2) NULL,
		CHARGES_AMT								decimal(15,2) NULL,
		COST_AMT								decimal(15,2) NULL,
		AR_POST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AR_INV_NBR								int NULL,
		AR_TYPE									varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		AB_FLAG									tinyint NULL,
		NON_BILL_FLAG							tinyint NULL,
		EST_EMP_HOURS							decimal(15,2) NULL,
		EST_AMT									decimal(15,2) NULL,
		EST_NONRESALE_TAX						decimal(15,2) NULL,
		EST_RESALE_TAX							decimal(15,2) NULL,
		EST_MARKUP_AMT							decimal(15,2) NULL,
		OPEN_PO_AMT								decimal(15,2) NULL,
		OPEN_PO_GROSS_AMT						decimal(15,2) NULL)
		
	--PRODUCTION======================================================================================
	--Client OOP--------------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		POST_PERIOD,
		VN_FRL_EMP_CODE,
		EMP_HOURS,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG)
	
	SELECT
		'OOP',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		f.FNC_TYPE,
		a.FNC_CODE,
		f.FNC_DESCRIPTION,
		a.INV_DATE,
		NULL,
		NULL,
		0,
		0,
		0,
		0,
		0,
		ISNULL(a.AMOUNT,0),
		ISNULL(a.AMOUNT,0),
		NULL,
		NULL,
		NULL,
		0
	FROM dbo.CLIENT_OOP AS a
	INNER JOIN dbo.FUNCTIONS AS f
		ON a.FNC_CODE = f.FNC_CODE
	
	--Employee Time-----------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		POST_PERIOD,
		VN_FRL_EMP_CODE,
		FEE_TIME,
		EMP_HOURS,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG)
	
	SELECT
		'ET',
		e.JOB_NUMBER,
		e.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		e.FNC_CODE,
		f.FNC_DESCRIPTION,
		et.EMP_DATE,
		NULL,
		et.EMP_CODE,
		ISNULL(e.FEE_TIME,0),
		ISNULL(e.EMP_HOURS,0),
		ISNULL(e.LINE_TOTAL,0),
		ISNULL(e.EXT_MARKUP_AMT,0),
		0,
		ISNULL(e.EXT_STATE_RESALE,0) + ISNULL(e.EXT_COUNTY_RESALE,0) + ISNULL(e.EXT_CITY_RESALE,0),
		ISNULL(e.LINE_TOTAL,0),
		ISNULL(e.TOTAL_COST,0),
		dbo.advfn_invoice_post_period(ISNULL(e.AR_INV_NBR,0),ISNULL(e.AR_TYPE,'')),
		e.AR_INV_NBR,
		e.AR_TYPE,
		ISNULL(e.EMP_NON_BILL_FLAG,0)
	FROM dbo.EMP_TIME_DTL AS e
	INNER JOIN dbo.EMP_TIME AS et
		ON e.ET_ID = et.ET_ID	
	INNER JOIN dbo.FUNCTIONS AS f
		ON e.FNC_CODE = f.FNC_CODE

	--Production--------------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		POST_PERIOD,
		VN_FRL_EMP_CODE,
		EMP_HOURS,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG)
	
	SELECT
		'AP',
		a.JOB_NUMBER,
		a.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		a.FNC_CODE,
		f.FNC_DESCRIPTION,
		NULL,
		ah.POST_PERIOD,
		ah.VN_FRL_EMP_CODE,
		0,
		ISNULL(a.LINE_TOTAL,0),
		ISNULL(a.EXT_MARKUP_AMT,0),
		ISNULL(a.EXT_NONRESALE_TAX,0),
		ISNULL(a.EXT_STATE_RESALE,0) + ISNULL(a.EXT_COUNTY_RESALE,0) + ISNULL(a.EXT_CITY_RESALE,0),
		ISNULL(a.LINE_TOTAL,0),
		a.AP_PROD_EXT_AMT + a.EXT_NONRESALE_TAX,
		dbo.advfn_invoice_post_period(ISNULL(a.AR_INV_NBR,0), ISNULL(a.AR_TYPE,'')),
		a.AR_INV_NBR,
		a.AR_TYPE,
		ISNULL(a.AP_PROD_NOBILL_FLG,0)
	FROM dbo.AP_PRODUCTION AS a
	INNER JOIN dbo.AP_HEADER AS ah
		ON a.AP_ID = ah.AP_ID
		AND a.AP_SEQ = ah.AP_SEQ	
	INNER JOIN dbo.FUNCTIONS AS f
		ON a.FNC_CODE = f.FNC_CODE

--Income Only--------------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		POST_PERIOD,
		VN_FRL_EMP_CODE,
		EMP_HOURS,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG)
	
	SELECT
		'IO',
		io.JOB_NUMBER,
		io.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		io.FNC_CODE,
		f.FNC_DESCRIPTION,
		io.IO_INV_DATE,
		NULL,
		NULL,
		0,
		ISNULL(io.LINE_TOTAL,0),
		ISNULL(io.EXT_MARKUP_AMT,0),
		0,
		ISNULL(io.EXT_STATE_RESALE,0) + ISNULL(io.EXT_COUNTY_RESALE,0) + ISNULL(io.EXT_CITY_RESALE,0),
		ISNULL(io.LINE_TOTAL,0),
		0,
		dbo.advfn_invoice_post_period(ISNULL(io.AR_INV_NBR,0), ISNULL(io.AR_TYPE,'')),
		io.AR_INV_NBR,
		io.AR_TYPE,
		ISNULL(io.NON_BILL_FLAG,0)
	FROM dbo.INCOME_ONLY AS io
	INNER JOIN dbo.FUNCTIONS AS f
		ON io.FNC_CODE = f.FNC_CODE

--Advance Billing----------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		POST_PERIOD,
		VN_FRL_EMP_CODE,
		EMP_HOURS,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		AB_FLAG,
		NON_BILL_FLAG)
	
	SELECT
		'AB',
		ab.JOB_NUMBER,
		ab.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		ab.FNC_CODE,
		f.FNC_DESCRIPTION,
		NULL,
		NULL,
		NULL,
		0,
		ISNULL(ab.LINE_TOTAL,0),
		ISNULL(ab.EXT_MARKUP_AMT,0),
		0,
		ISNULL(ab.EXT_STATE_RESALE,0) + ISNULL(ab.EXT_COUNTY_RESALE,0) + ISNULL(ab.EXT_CITY_RESALE,0),
		ISNULL(ab.LINE_TOTAL,0),
		0,
		dbo.advfn_invoice_post_period(ISNULL(ab.AR_INV_NBR,0), ISNULL(ab.AR_TYPE,'')),
		ab.AR_INV_NBR,
		ab.AR_TYPE,
		ab.AB_FLAG,
		0
	FROM dbo.ADVANCE_BILLING AS ab
	INNER JOIN dbo.FUNCTIONS f
		ON ab.FNC_CODE = f.FNC_CODE
	WHERE ab.AR_INV_NBR IS NOT NULL	

--Estimate/Quote-----------------------------------------------------------------------------------
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		FNC_DESC,
		NON_BILL_FLAG,
		EST_EMP_HOURS,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'EST',
		ea.JOB_NUMBER,
		ea.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		ed.FNC_CODE,
		f.FNC_DESCRIPTION,
		0,
		CASE f.FNC_TYPE
			WHEN 'E' THEN ed.EST_REV_QUANTITY
			ELSE 0
		END,
		ISNULL(ed.LINE_TOTAL,0),
		ISNULL(ed.EXT_NONRESALE_TAX,0),
		ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
		ISNULL(ed.EXT_MARKUP_AMT,0)
	FROM dbo.ESTIMATE_APPROVAL AS ea
	INNER JOIN dbo.ESTIMATE_REV_DET AS ed
		ON ea.ESTIMATE_NUMBER =ed.ESTIMATE_NUMBER
		AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
		AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
		AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
	INNER JOIN dbo.FUNCTIONS f
		ON ed.FNC_CODE = f.FNC_CODE
		

----Estimate/Quote (Internal) Not Used ----------------------------------------
--	INSERT INTO #job_detail_cost_and_billing(
--		REC_SOURCE,
--		JOB_NUMBER,
--		JOB_COMPONENT_NBR,
--		FNC_TYPE,
--		FNC_CODE,
--		EST_EMP_HOURS,
--		EST_AMT,
--		EST_NONRESALE_TAX,
--		EST_RESALE_TAX,
--		EST_MARKUP_AMT)
	
--	SELECT
--		'ESTI',
--		ea.JOB_NUMBER,
--		ea.JOB_COMPONENT_NBR,
--		f.FNC_TYPE,	
--		ed.FNC_CODE,
--		CASE f.FNC_TYPE
--			WHEN 'E' THEN ed.EST_REV_QUANTITY
--			ELSE 0
--		END,
--		ISNULL(ed.LINE_TOTAL,0),
--		0,
--		ISNULL(ed.EXT_STATE_RESALE,0) + ISNULL(ed.EXT_COUNTY_RESALE,0) + ISNULL(ed.EXT_CITY_RESALE,0),
--		ISNULL(ed.EXT_MARKUP_AMT,0)
--	FROM dbo.ESTIMATE_INT_APPR AS ea
--	INNER JOIN advfn_intlist_to_table(@job_list) AS i
--		ON ea.JOB_NUMBER = i.number
--	INNER JOIN dbo.ESTIMATE_REV_DET AS ed
--		ON ea.ESTIMATE_NUMBER =ed.ESTIMATE_NUMBER
--		AND ea.EST_COMPONENT_NBR = ed.EST_COMPONENT_NBR
--		AND ea.EST_QUOTE_NBR = ed.EST_QUOTE_NBR
--		AND ea.EST_REVISION_NBR = ed.EST_REV_NBR
--	INNER JOIN dbo.FUNCTIONS f
--		ON ed.FNC_CODE = f.FNC_CODE

--Open POs----------------------------------------------------------------------------------
--Temp table to store AP amounts
	CREATE TABLE #ap_amounts(
		PO_NUMBER								int NULL,
		PO_LINE_NUMBER							int NULL,
		AP_NET_AMT								decimal(15,2),
		AP_GROSS_AMT							decimal(15,2))
	INSERT INTO #ap_amounts(PO_NUMBER, PO_LINE_NUMBER, AP_NET_AMT, AP_GROSS_AMT)
	SELECT
		ap.PO_NUMBER,
		ap.PO_LINE_NUMBER,
		SUM(ap.AP_PROD_EXT_AMT),
		SUM(ap.AP_PROD_EXT_AMT) + SUM(ap.EXT_MARKUP_AMT)
	FROM dbo.AP_PRODUCTION ap
	WHERE ISNULL(ap.PO_NUMBER,0) <> 0 AND ISNULL(ap.DELETE_FLAG,0) = 0 
	GROUP BY ap.PO_NUMBER, ap.PO_LINE_NUMBER 
	HAVING SUM(ap.AP_PROD_EXT_AMT) <> 0

--	SELECT * FROM #ap_amounts

	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		FNC_TYPE,
		FNC_CODE,
		ITEM_DATE,
		--ITEM_PERIOD,
		VN_FRL_EMP_CODE,
		OPEN_PO_AMT,
		OPEN_PO_GROSS_AMT)
	
	SELECT
		'PO',
		pd.JOB_NUMBER,
		pd.JOB_COMPONENT_NBR,
		f.FNC_TYPE,	
		pd.FNC_CODE,
		p.PO_DATE,
		--NULL,
		p.VN_CODE,
		SUM(ISNULL(pd.PO_EXT_AMOUNT,0)) - SUM(ISNULL(ap.AP_NET_AMT,0)),
		SUM(ISNULL(pd.PO_EXT_AMOUNT,0)) + SUM(ISNULL(pd.EXT_MARKUP_AMT,0)) - SUM(ISNULL(ap.AP_GROSS_AMT,0))
	FROM dbo.PURCHASE_ORDER p
	INNER JOIN dbo.PURCHASE_ORDER_DET pd
		ON p.PO_NUMBER = pd.PO_NUMBER
	LEFT JOIN #ap_amounts ap
		ON pd.PO_NUMBER = ap.PO_NUMBER
		AND pd.LINE_NUMBER = ap.PO_LINE_NUMBER
	INNER JOIN dbo.FUNCTIONS f
		ON pd.FNC_CODE = f.FNC_CODE
	WHERE ISNULL(p.VOID_FLAG,0) = 0 AND (pd.PO_COMPLETE <> 1 OR pd.PO_COMPLETE IS NULL)	
	GROUP BY f.FNC_TYPE, pd.JOB_NUMBER, pd.JOB_COMPONENT_NBR, pd.FNC_CODE, p.PO_DATE, p.VN_CODE
	HAVING SUM(ISNULL(pd.PO_EXT_AMOUNT,0)) - SUM(ISNULL(ap.AP_NET_AMT,0)) <> 0		

	SELECT * FROM #job_detail_cost_and_billing

END
