
CREATE PROCEDURE [dbo].[advsp_job_detail_cost_and_billing_media]

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
		BRDCAST_PERIOD							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		VN_FRL_EMP_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
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
		EST_AMT									decimal(15,2) NULL,
		EST_NONRESALE_TAX						decimal(15,2) NULL,
		EST_RESALE_TAX							decimal(15,2) NULL,
		EST_MARKUP_AMT							decimal(15,2) NULL,
		OPEN_PO_AMT								decimal(15,2) NULL,
		OPEN_PO_GROSS_AMT						decimal(15,2) NULL)
			
	--Temp table to store MaxRev for each OrderLine----------------------------------------------------------
	CREATE TABLE #max_rev(
		ORDER_NBR							int NOT NULL,
		LINE_NBR							smallint NOT NULL,
		MAX_REV_NBR							smallint NOT NULL)
		
	--Temp table to store MaxSeq for OrderLineMaxRev----------------------------------------------------------	
	CREATE TABLE #max_rev_seq(
		ORDER_NBR							int NOT NULL,
		LINE_NBR							smallint NOT NULL,
		MAX_REV_NBR							smallint NOT NULL,
		MAX_SEQ_NBR							smallint NOT NULL)
		
	--Temp table to store data for each OrderLineMaxRevMaxSeq---------------------------------------------------		
	CREATE TABLE #job_data(
		ORDER_NBR							int NOT NULL,
		LINE_NBR							smallint NOT NULL,
		JOB_NUMBER							int NOT NULL,
		JOB_COMPONENT_NBR					smallint NOT NULL,
		CL_CODE								varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		DIV_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		PRD_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		BILL_COMM_NET						tinyint NULL)
		
--MEDIA============================================================================================
----Mag (old)	
--	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
--	SELECT d.ORDER_NBR,
--		d.LINE_NBR,
--		MAX(d.REV_NBR)
--	FROM dbo.MAG_DETAIL d
--	GROUP BY d.ORDER_NBR, d.LINE_NBR

--	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
--	SELECT mr.ORDER_NBR,
--		mr.LINE_NBR,
--		mr.MAX_REV_NBR,
--		MAX(d.SEQ_NBR)
--	FROM dbo.MAG_DETAIL d
--	INNER JOIN #max_rev mr
--		ON d.ORDER_NBR = mr.ORDER_NBR
--		AND d.LINE_NBR = mr.LINE_NBR
--		AND d.REV_NBR = mr.MAX_REV_NBR
--	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR
	
--	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, CL_CODE, DIV_CODE, PRD_CODE, BILL_COMM_NET)
--	SELECT DISTINCT
--		ms.ORDER_NBR,
--		ms.LINE_NBR,
--		d.JOB_NUMBER,
--		d.JOB_COMPONENT_NBR,
--		l.CL_CODE,
--		l.DIV_CODE,
--		l.PRD_CODE,
--		b.BILL_COMM_NET
--	FROM #max_rev_seq ms
--	INNER JOIN dbo.MAG_DETAIL d
--		ON d.ORDER_NBR = ms.ORDER_NBR
--		AND d.LINE_NBR = ms.LINE_NBR
--		AND d.REV_NBR = ms.MAX_REV_NBR
--		AND d.SEQ_NBR = ms.MAX_SEQ_NBR
--	INNER JOIN dbo.JOB_LOG l
--		ON d.JOB_NUMBER = l.JOB_NUMBER
--	INNER JOIN dbo.MEDIA_BILL_AMTS b
--		ON b.ORDER_NBR = ms.ORDER_NBR
--		AND b.LINE_NBR = ms.LINE_NBR
--		AND b.REV_NBR = ms.MAX_REV_NBR
--		AND b.SEQ_NBR = ms.MAX_SEQ_NBR

----Insert Mag (old) data into main table
----Billing
--	INSERT INTO #job_detail_cost_and_billing(
--		REC_SOURCE,
--		JOB_NUMBER,
--		JOB_COMPONENT_NBR,
--		FNC_CODE,
--		ITEM_DATE,
--		ITEM_PERIOD,
--		VN_FRL_EMP_CODE,
--		EMP_HOURS,
--		BILL_AMT,
--		NONRESALE_TAX,
--		RESALE_TAX,
--		CHARGES_AMT,
--		COST_AMT,
--		AR_POST_PERIOD,
--		AR_INV_NBR,
--		AR_TYPE,
--		NON_BILL_FLAG,
--		EST_EMP_HOURS,
--		EST_AMT,
--		EST_NONRESALE_TAX,
--		EST_RESALE_TAX,
--		EST_MARKUP_AMT)	
--	SELECT
--		'MM',
--		j.JOB_NUMBER,
--		j.JOB_COMPONENT_NBR,
--		NULL,
--		NULL,
--		NULL,
--		NULL,
--		0,
--		ISNULL(b.BILL_AMT,0),
--		0,
--		0,
--		0,
--		0,
--		dbo.advfn_invoice_post_period(ISNULL(b.AR_INV_NBR,0),ISNULL(b.AR_TYPE,'')),
--		b.AR_INV_NBR,
--		b.AR_TYPE,
--		0,
--		0,
--		0,
--		0,
--		0,
--		0		
--	FROM #max_rev_seq ms
--	INNER JOIN #job_data AS j
--		ON ms.ORDER_NBR = j.ORDER_NBR
--		AND ms.LINE_NBR = j.LINE_NBR
--	INNER JOIN dbo.MEDIA_BILL_AMTS b
--		ON j.ORDER_NBR = b.ORDER_NBR
--		AND j.LINE_NBR = b.LINE_NBR
	
--	--Charges
--	INSERT INTO #job_detail_cost_and_billing(
--		REC_SOURCE,
--		JOB_NUMBER,
--		JOB_COMPONENT_NBR,
--		FNC_CODE,
--		ITEM_DATE,
--		ITEM_PERIOD,
--		VN_FRL_EMP_CODE,
--		EMP_HOURS,
--		BILL_AMT,
--		NONRESALE_TAX,
--		RESALE_TAX,
--		CHARGES_AMT,
--		COST_AMT,
--		AR_POST_PERIOD,
--		AR_INV_NBR,
--		AR_TYPE,
--		NON_BILL_FLAG,
--		EST_EMP_HOURS,
--		EST_AMT,
--		EST_NONRESALE_TAX,
--		EST_RESALE_TAX,
--		EST_MARKUP_AMT)	
--	SELECT
--		'MM',
--		j.JOB_NUMBER,
--		j.JOB_COMPONENT_NBR,
--		NULL,
--		d.INSERT_DATE,
--		NULL,
--		NULL,
--		0,
--		0,
--		0,
--		0,
--		ISNULL(d.EXT_NET_AMT,0) +
--				ISNULL(nc.NETCHARGE1,0) + ISNULL(nc.NETCHARGE2,0) + ISNULL(nc.NETCHARGE3,0) + 
--				ISNULL(nc.NETCHARGE4,0) + ISNULL(nc.NETCHARGE5,0) + ISNULL(nc.NETCHARGE6,0) - 
--				ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--				ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--				ISNULL(t.VENDOR_TAX,0),
--		0,
--		NULL,
--		NULL,
--		NULL,
--		0,
--		0,
--		CASE j.BILL_COMM_NET
--			WHEN NULL THEN 
--				CASE
--					WHEN p.PRD_MAG_COM_ONLY = 1 THEN ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0)
--					WHEN p.PRD_MAG_BILL_NET = 1 THEN ISNULL(d.EXT_NET_AMT,0) +
--						ISNULL(nc.NETCHARGE1,0) + ISNULL(nc.NETCHARGE2,0) + ISNULL(nc.NETCHARGE3,0) + 
--						ISNULL(nc.NETCHARGE4,0) + ISNULL(nc.NETCHARGE5,0) + ISNULL(nc.NETCHARGE6,0) - 
--						ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--						ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--						ISNULL(t.VENDOR_TAX,0) +
--						ISNULL(t.STATE_TAX,0) + ISNULL(t.COUNTY_TAX,0) + ISNULL(t.CITY_TAX,0)  
--					ELSE ISNULL(d.LINE_TOTAL,0)
--				END
--			WHEN 1 THEN ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0)
--			WHEN 2 THEN ISNULL(d.EXT_NET_AMT,0) +
--				ISNULL(nc.NETCHARGE1,0) + ISNULL(nc.NETCHARGE2,0) + ISNULL(nc.NETCHARGE3,0) + 
--				ISNULL(nc.NETCHARGE4,0) + ISNULL(nc.NETCHARGE5,0) + ISNULL(nc.NETCHARGE6,0) - 
--				ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--				ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--				ISNULL(t.VENDOR_TAX,0) +
--				ISNULL(t.STATE_TAX,0) + ISNULL(t.COUNTY_TAX,0) + ISNULL(t.CITY_TAX,0)
--			ELSE ISNULL(d.LINE_TOTAL,0)   
--		END,
--		0,
--		0,
--		0		
--	FROM #max_rev_seq ms
--	INNER JOIN dbo.MAG_DETAIL d
--		ON ms.ORDER_NBR = d.ORDER_NBR
--		AND ms.LINE_NBR = d.LINE_NBR
--		AND ms.MAX_REV_NBR = d.REV_NBR
--		AND ms.MAX_SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.MAG_DISC di
--		ON di.ORDER_NBR = d.ORDER_NBR
--		AND di.LINE_NBR = d.LINE_NBR
--		AND di.REV_NBR = d.REV_NBR
--		AND di.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.MAG_NET_CHG nc
--		ON nc.ORDER_NBR = d.ORDER_NBR
--		AND nc.LINE_NBR = d.LINE_NBR
--		AND nc.REV_NBR = d.REV_NBR
--		AND nc.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.MAG_TAXES t
--		ON t.ORDER_NBR = d.ORDER_NBR
--		AND t.LINE_NBR = d.LINE_NBR
--		AND t.REV_NBR = d.REV_NBR
--		AND t.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN #job_data AS j
--		ON ms.ORDER_NBR = j.ORDER_NBR
--		AND ms.LINE_NBR = j.LINE_NBR
--	INNER JOIN dbo.MAG_HEADER h
--		ON ms.ORDER_NBR = h.ORDER_NBR
--	INNER JOIN dbo.PRODUCT p
--		ON h.CL_CODE = p.CL_CODE
--		AND h.DIV_CODE = p.DIV_CODE
--		AND h.PRD_CODE = p.PRD_CODE		

----News (old)
----Temp table to store job data for OrderLine MaxRevSeq---------------------------------------------------------
--	DELETE FROM #max_rev
--	DELETE FROM #max_rev_seq
--	DELETE FROM #job_data

--	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
--	SELECT d.ORDER_NBR,
--		d.LINE_NBR,
--		MAX(d.REV_NBR)
--	FROM dbo.NEWS_DETAIL d
--	GROUP BY d.ORDER_NBR, d.LINE_NBR

--	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
--	SELECT mr.ORDER_NBR,
--		mr.LINE_NBR,
--		mr.MAX_REV_NBR,
--		MAX(d.SEQ_NBR)
--	FROM dbo.NEWS_DETAIL d
--	INNER JOIN #max_rev mr
--		ON d.ORDER_NBR = mr.ORDER_NBR
--		AND d.LINE_NBR = mr.LINE_NBR
--		AND d.REV_NBR = mr.MAX_REV_NBR
--	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

--	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, CL_CODE, DIV_CODE, PRD_CODE, BILL_COMM_NET)
--	SELECT DISTINCT
--		ms.ORDER_NBR,
--		ms.LINE_NBR,
--		d.JOB_NUMBER,
--		d.JOB_COMPONENT_NBR,
--		l.CL_CODE,
--		l.DIV_CODE,
--		l.PRD_CODE,
--		b.BILL_COMM_NET
--	FROM #max_rev_seq ms
--	INNER JOIN dbo.NEWS_DETAIL d
--		ON d.ORDER_NBR = ms.ORDER_NBR
--		AND d.LINE_NBR = ms.LINE_NBR
--		AND d.REV_NBR = ms.MAX_REV_NBR
--		AND d.SEQ_NBR = ms.MAX_SEQ_NBR
--	INNER JOIN dbo.JOB_LOG l
--		ON d.JOB_NUMBER = l.JOB_NUMBER
--	INNER JOIN dbo.MEDIA_BILL_AMTS b
--		ON b.ORDER_NBR = ms.ORDER_NBR
--		AND b.LINE_NBR = ms.LINE_NBR
--		AND b.REV_NBR = ms.MAX_REV_NBR
--		AND b.SEQ_NBR = ms.MAX_SEQ_NBR

----Insert News (old) data into main table
----Billing
--	INSERT INTO #job_detail_cost_and_billing(
--		REC_SOURCE,
--		JOB_NUMBER,
--		JOB_COMPONENT_NBR,
--		FNC_CODE,
--		ITEM_DATE,
--		ITEM_PERIOD,
--		VN_FRL_EMP_CODE,
--		EMP_HOURS,
--		BILL_AMT,
--		NONRESALE_TAX,
--		RESALE_TAX,
--		CHARGES_AMT,
--		COST_AMT,
--		AR_POST_PERIOD,
--		AR_INV_NBR,
--		AR_TYPE,
--		NON_BILL_FLAG,
--		EST_EMP_HOURS,
--		EST_AMT,
--		EST_NONRESALE_TAX,
--		EST_RESALE_TAX,
--		EST_MARKUP_AMT)	
--	SELECT
--		'MN',
--		j.JOB_NUMBER,
--		j.JOB_COMPONENT_NBR,
--		NULL,
--		NULL,
--		NULL,
--		NULL,
--		0,
--		ISNULL(b.BILL_AMT,0),
--		0,
--		0,
--		0,
--		0,
--		dbo.advfn_invoice_post_period(ISNULL(b.AR_INV_NBR,0),ISNULL(b.AR_TYPE,'')),
--		b.AR_INV_NBR,
--		b.AR_TYPE,
--		0,
--		0,
--		0,
--		0,
--		0,
--		0		
--	FROM #max_rev_seq ms
--	INNER JOIN #job_data AS j
--		ON ms.ORDER_NBR = j.ORDER_NBR
--		AND ms.LINE_NBR = j.LINE_NBR
--	INNER JOIN dbo.MEDIA_BILL_AMTS b
--		ON j.ORDER_NBR = b.ORDER_NBR
--		AND j.LINE_NBR = b.LINE_NBR

--	--Charges
--	INSERT INTO #job_detail_cost_and_billing(
--		REC_SOURCE,
--		JOB_NUMBER,
--		JOB_COMPONENT_NBR,
--		FNC_CODE,
--		ITEM_DATE,
--		ITEM_PERIOD,
--		VN_FRL_EMP_CODE,
--		EMP_HOURS,
--		BILL_AMT,
--		NONRESALE_TAX,
--		RESALE_TAX,
--		CHARGES_AMT,
--		COST_AMT,
--		AR_POST_PERIOD,
--		AR_INV_NBR,
--		AR_TYPE,
--		NON_BILL_FLAG,
--		EST_EMP_HOURS,
--		EST_AMT,
--		EST_NONRESALE_TAX,
--		EST_RESALE_TAX,
--		EST_MARKUP_AMT)
	
--	SELECT
--		'MN',
--		j.JOB_NUMBER,
--		j.JOB_COMPONENT_NBR,
--		NULL,
--		d.INSERT_DATE,
--		NULL,
--		NULL,
--		0,
--		0,
--		0,
--		0,
--		ISNULL(d.EXT_NET_AMT,0) +
--				ISNULL(nc.PROD_CHARGE,0) + ISNULL(nc.BOX_COMM,0) + ISNULL(nc.FAX_PHONE,0) + 
--				ISNULL(nc.DELY_CHARGE,0) + ISNULL(nc.CREATIVE_FEE,0) + ISNULL(nc.SERVICE_FEE,0) - 
--				ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--				ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--				ISNULL(t.VENDOR_TAX,0),
--		0,
--		NULL,
--		NULL,
--		NULL,
--		0,
--		0,
--		CASE j.BILL_COMM_NET
--			WHEN NULL THEN 
--				CASE
--					WHEN p.PRD_NEWS_COM_ONLY = 1 THEN ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0)
--					WHEN p.PRD_NEWS_BILL_NET = 1 THEN ISNULL(d.EXT_NET_AMT,0) +
--						ISNULL(nc.PROD_CHARGE,0) + ISNULL(nc.BOX_COMM,0) + ISNULL(nc.FAX_PHONE,0) + 
--						ISNULL(nc.DELY_CHARGE,0) + ISNULL(nc.CREATIVE_FEE,0) + ISNULL(nc.SERVICE_FEE,0) - 
--						ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--						ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--						ISNULL(t.VENDOR_TAX,0) +
--						ISNULL(t.STATE_TAX,0) + ISNULL(t.COUNTY_TAX,0) + ISNULL(t.CITY_TAX,0)  
--					ELSE ISNULL(d.LINE_TOTAL,0)
--				END
--			WHEN 1 THEN ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0)
--			WHEN 2 THEN ISNULL(d.EXT_NET_AMT,0) +
--				ISNULL(nc.PROD_CHARGE,0) + ISNULL(nc.BOX_COMM,0) + ISNULL(nc.FAX_PHONE,0) + 
--				ISNULL(nc.DELY_CHARGE,0) + ISNULL(nc.CREATIVE_FEE,0) + ISNULL(nc.SERVICE_FEE,0) - 
--				ISNULL(di.DISC1,0) - ISNULL(di.DISC2,0) - ISNULL(di.DISC3,0) - ISNULL(di.DISC4,0) - 
--				ISNULL(di.DISC5,0) - ISNULL(di.DISC6,0) - ISNULL(di.DISC7,0) - ISNULL(di.DISC8,0) + 
--				ISNULL(t.VENDOR_TAX,0) +
--				ISNULL(t.STATE_TAX,0) + ISNULL(t.COUNTY_TAX,0) + ISNULL(t.CITY_TAX,0)   
--		END,
--		0,
--		0,
--		0		
--	FROM #max_rev_seq ms
--	INNER JOIN dbo.NEWS_DETAIL d
--		ON ms.ORDER_NBR = d.ORDER_NBR
--		AND ms.LINE_NBR = d.LINE_NBR
--		AND ms.MAX_REV_NBR = d.REV_NBR
--		AND ms.MAX_SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.NEWS_DISC di
--		ON di.ORDER_NBR = d.ORDER_NBR
--		AND di.LINE_NBR = d.LINE_NBR
--		AND di.REV_NBR = d.REV_NBR
--		AND di.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.NEWS_NET_CHG nc
--		ON nc.ORDER_NBR = d.ORDER_NBR
--		AND nc.LINE_NBR = d.LINE_NBR
--		AND nc.REV_NBR = d.REV_NBR
--		AND nc.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN dbo.NEWS_TAXES t
--		ON t.ORDER_NBR = d.ORDER_NBR
--		AND t.LINE_NBR = d.LINE_NBR
--		AND t.REV_NBR = d.REV_NBR
--		AND t.SEQ_NBR = d.SEQ_NBR
--	INNER JOIN #job_data AS j
--		ON ms.ORDER_NBR = j.ORDER_NBR
--		AND ms.LINE_NBR = j.LINE_NBR
--	INNER JOIN dbo.NEWS_HEADER h
--		ON ms.ORDER_NBR = h.ORDER_NBR
--	INNER JOIN dbo.PRODUCT p
--		ON h.CL_CODE = p.CL_CODE
--		AND h.DIV_CODE = p.DIV_CODE
--		AND h.PRD_CODE = p.PRD_CODE

--	DELETE FROM #max_rev
--	DELETE FROM #max_rev_seq
--	DELETE FROM #job_data

--Magazine (new)-----------------------------------------------------------------------------------
--Temp table(s) to store job data for OrderLine MaxRevSeq------------------------------------------
	DELETE FROM #max_rev
	DELETE FROM #max_rev_seq
	DELETE FROM #job_data

	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.MAGAZINE_DETAIL d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.MAGAZINE_DETAIL d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR
	FROM #max_rev_seq ms
	INNER JOIN dbo.MAGAZINE_DETAIL d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR

--Insert Magazine (new) data into main table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,	
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MM',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Magazine',
		d.[START_DATE],
		NULL,
		NULL,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
		CASE
			WHEN d.ACTIVE_REV = 1 THEN ISNULL(d.EXT_NET_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NON_RESALE_AMT,0)
			ELSE 0
		END,
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		CASE d.ACTIVE_REV
			WHEN 1 THEN d.BILLING_AMT
			ELSE 0
		END,
		0,
		0,
		0		
	FROM dbo.MAGAZINE_DETAIL AS d
	INNER JOIN #job_data AS j
		ON d.ORDER_NBR = j.ORDER_NBR
		AND d.LINE_NBR = j.LINE_NBR
	WHERE (d.ACTIVE_REV = 1 AND ISNULL(d.LINE_CANCELLED, 0) = 0) OR ISNULL(d.AR_INV_NBR,0) <> 0

--Newspaper (new)----------------------------------------------------------------------------------
--Temp table(s) to store job data for OrderLine MaxRevSeq---------------------------------------------------------
	DELETE FROM #max_rev
	DELETE FROM #max_rev_seq
	DELETE FROM #job_data

	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.NEWSPAPER_DETAIL d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.NEWSPAPER_DETAIL d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR
	FROM #max_rev_seq ms
	INNER JOIN dbo.NEWSPAPER_DETAIL d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR

--Insert Newspaper (new) data into main table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MN',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Newspaper',
		d.[START_DATE],
		NULL,
		NULL,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
		CASE
			WHEN d.ACTIVE_REV = 1 THEN ISNULL(d.EXT_NET_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NON_RESALE_AMT,0)
			ELSE 0
		END,
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		CASE d.ACTIVE_REV
			WHEN 1 THEN d.BILLING_AMT
			ELSE 0
		END,
		0,
		0,
		0		
	FROM dbo.NEWSPAPER_DETAIL AS d
	INNER JOIN #job_data AS j
		ON d.ORDER_NBR = j.ORDER_NBR
		AND d.LINE_NBR = j.LINE_NBR
	WHERE (d.ACTIVE_REV = 1 AND ISNULL(d.LINE_CANCELLED, 0) = 0) OR ISNULL(d.AR_INV_NBR,0) <> 0

--Outdoor------------------------------------------------------------------------------------------
--Temp table(s) to store job data for OrderLine MaxRevSeq---------------------------------------------------------
	DELETE FROM #max_rev
	DELETE FROM #max_rev_seq
	DELETE FROM #job_data

	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.OUTDOOR_DETAIL d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.OUTDOOR_DETAIL d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR
	FROM #max_rev_seq ms
	INNER JOIN dbo.OUTDOOR_DETAIL d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR

--Insert Outdoor data into main table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MO',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Outdoor',
		d.POST_DATE,
		NULL,
		NULL,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
		CASE
			WHEN d.ACTIVE_REV = 1 THEN ISNULL(d.EXT_NET_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NON_RESALE_AMT,0)
			ELSE 0
		END,
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		CASE d.ACTIVE_REV
			WHEN 1 THEN d.BILLING_AMT
			ELSE 0
		END,
		0,
		0,
		0		
	FROM dbo.OUTDOOR_DETAIL AS d
	INNER JOIN #job_data AS j
		ON d.ORDER_NBR = j.ORDER_NBR
		AND d.LINE_NBR = j.LINE_NBR
	WHERE (d.ACTIVE_REV = 1 AND ISNULL(d.LINE_CANCELLED, 0) = 0) OR ISNULL(d.AR_INV_NBR,0) <> 0

--Internet-----------------------------------------------------------------------------------------
--Temp table(s) to store job data for OrderLine MaxRevSeq---------------------------------------------------------
	DELETE FROM #max_rev
	DELETE FROM #max_rev_seq
	DELETE FROM #job_data

	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.INTERNET_DETAIL d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.INTERNET_DETAIL d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR
	FROM #max_rev_seq ms
	INNER JOIN dbo.INTERNET_DETAIL d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR

--Insert Internet data into main data table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MI',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Internet',
		d.[START_DATE],
		NULL,
		NULL,
		ISNULL(d.BILLING_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.NON_RESALE_AMT,0),
		ISNULL(d.STATE_AMT,0) + ISNULL(d.COUNTY_AMT,0) + ISNULL(d.CITY_AMT,0),
		CASE
			WHEN d.ACTIVE_REV = 1 THEN ISNULL(d.EXT_NET_AMT,0) + ISNULL(d.NETCHARGE,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.NON_RESALE_AMT,0)
			ELSE 0
		END,
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		CASE d.ACTIVE_REV
			WHEN 1 THEN d.BILLING_AMT
			ELSE 0
		END,
		0,
		0,
		0		
	FROM dbo.INTERNET_DETAIL AS d
	INNER JOIN #job_data AS j
		ON d.ORDER_NBR = j.ORDER_NBR
		AND d.LINE_NBR = j.LINE_NBR
	WHERE (d.ACTIVE_REV = 1 AND ISNULL(d.LINE_CANCELLED, 0) = 0) OR ISNULL(d.AR_INV_NBR,0) <> 0

--Radio
--Temp table(s) to store job data for OrderLine MaxRevSeq---------------------------------------------------------
	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.RADIO_DETAIL1 d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.RADIO_DETAIL1 d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, CL_CODE, DIV_CODE, PRD_CODE)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR,
		l.CL_CODE,
		l.DIV_CODE,
		l.PRD_CODE
	FROM #max_rev_seq ms
	INNER JOIN dbo.RADIO_DETAIL1 d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR
	INNER JOIN dbo.JOB_LOG l
		ON d.JOB_NUMBER = l.JOB_NUMBER

--Insert Radio data into main table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MR',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Radio',
		NULL,			--dbo.fn_year_monthabbrev_to_date(d.[YEAR], d.[MONTH]),
		d.BRDCAST_PERIOD,
		NULL,
		ISNULL(d.BILL_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.VENDOR_TAX,0),
		ISNULL(d.STATE_TAX,0) - ISNULL(d.COUNTY_TAX,0) + ISNULL(d.CITY_TAX,0),
		ISNULL(d.LINE_NET,0) - ISNULL(d.LINE_DISC,0) + ISNULL(d.VENDOR_TAX,0),
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		ISNULL(d.BILL_AMT,0),
		0,
		0,
		0		
	FROM #job_data j
	INNER JOIN dbo.V_RADIO_AMOUNTS d
		ON j.ORDER_NBR = d.ORDER_NBR
		AND j.LINE_NBR = d.LINE_NBR
	WHERE ( ABS(d.LINE_NET) + ABS(d.COMM_AMT) + ABS(d.REBATE_AMT) + ABS(d.LINE_DISC) + ABS(d.VENDOR_TAX)
		+ ABS(d.STATE_TAX) + ABS(d.COUNTY_TAX) + ABS(d.CITY_TAX) + ABS(d.BILL_AMT) ) <> 0		

	DELETE FROM #max_rev
	DELETE FROM #max_rev_seq
	DELETE FROM #job_data

--Television
--Temp table(s) to store job data for OrderLine MaxRevSeq---------------------------------------------------------
	INSERT INTO #max_rev(ORDER_NBR, LINE_NBR, MAX_REV_NBR)
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		MAX(d.REV_NBR)
	FROM dbo.TV_DETAIL1 d
	WHERE d.JOB_NUMBER IS NOT NULL
	GROUP BY d.ORDER_NBR, d.LINE_NBR

	INSERT INTO #max_rev_seq(ORDER_NBR, LINE_NBR, MAX_REV_NBR, MAX_SEQ_NBR)
	SELECT mr.ORDER_NBR,
		mr.LINE_NBR,
		mr.MAX_REV_NBR,
		MAX(d.SEQ_NBR)
	FROM dbo.TV_DETAIL1 d
	INNER JOIN #max_rev mr
		ON d.ORDER_NBR = mr.ORDER_NBR
		AND d.LINE_NBR = mr.LINE_NBR
		AND d.REV_NBR = mr.MAX_REV_NBR
	GROUP BY mr.ORDER_NBR, mr.LINE_NBR, mr.MAX_REV_NBR

	INSERT INTO #job_data(ORDER_NBR, LINE_NBR, JOB_NUMBER, JOB_COMPONENT_NBR, CL_CODE, DIV_CODE, PRD_CODE)
	SELECT 
		ms.ORDER_NBR,
		ms.LINE_NBR,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR,
		l.CL_CODE,
		l.DIV_CODE,
		l.PRD_CODE
	FROM #max_rev_seq ms
	INNER JOIN dbo.TV_DETAIL1 d
		ON d.ORDER_NBR = ms.ORDER_NBR
		AND d.LINE_NBR = ms.LINE_NBR
		AND d.REV_NBR = ms.MAX_REV_NBR
		AND d.SEQ_NBR = ms.MAX_SEQ_NBR
	INNER JOIN dbo.JOB_LOG l
		ON d.JOB_NUMBER = l.JOB_NUMBER

--Insert Television data into main table
	INSERT INTO #job_detail_cost_and_billing(
		REC_SOURCE,
		JOB_NUMBER,
		JOB_COMPONENT_NBR,
		ORDER_NBR,
		LINE_NBR,
		FNC_CODE,
		FNC_DESC,
		ITEM_DATE,
		BRDCAST_PERIOD,
		VN_FRL_EMP_CODE,
		BILL_AMT,
		EXT_MARKUP_AMT,
		NONRESALE_TAX,
		RESALE_TAX,
		CHARGES_AMT,
		COST_AMT,
		AR_POST_PERIOD,
		AR_INV_NBR,
		AR_TYPE,
		NON_BILL_FLAG,
		EST_AMT,
		EST_NONRESALE_TAX,
		EST_RESALE_TAX,
		EST_MARKUP_AMT)
	
	SELECT
		'MT',
		j.JOB_NUMBER,
		j.JOB_COMPONENT_NBR,
		j.ORDER_NBR,
		j.LINE_NBR,
		NULL,
		'Television',
		NULL,		--dbo.fn_year_monthabbrev_to_date(d.[YEAR], d.[MONTH]),
		d.BRDCAST_PERIOD,
		NULL,
		ISNULL(d.BILL_AMT,0),
		ISNULL(d.COMM_AMT,0),
		ISNULL(d.VENDOR_TAX,0),
		ISNULL(d.STATE_TAX,0) - ISNULL(d.COUNTY_TAX,0) + ISNULL(d.CITY_TAX,0),
		ISNULL(d.LINE_NET,0) - ISNULL(d.LINE_DISC,0) + ISNULL(d.VENDOR_TAX,0),
		0,
		dbo.advfn_invoice_post_period(ISNULL(d.AR_INV_NBR,0),ISNULL(d.AR_TYPE,'')),
		d.AR_INV_NBR,
		d.AR_TYPE,
		0,
		ISNULL(d.BILL_AMT,0),
		0,
		0,
		0		
	FROM #job_data j
	INNER JOIN dbo.V_TV_AMOUNTS d
		ON j.ORDER_NBR = d.ORDER_NBR
		AND j.LINE_NBR = d.LINE_NBR
	WHERE ( ABS(d.LINE_NET) + ABS(d.COMM_AMT) + ABS(d.REBATE_AMT) + ABS(d.LINE_DISC) + ABS(d.VENDOR_TAX)
		+ ABS(d.STATE_TAX) + ABS(d.COUNTY_TAX) + ABS(d.CITY_TAX) + ABS(d.BILL_AMT) ) <> 0

	SELECT * FROM #job_detail_cost_and_billing

END
