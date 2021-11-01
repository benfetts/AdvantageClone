
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_amounts] ( @user_code varchar(100), @start_period int = 190001, @end_period int = 219912)
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_monthly(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	MONTH_IND						smallint NULL, 
	MONTH_SHORT						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	BRDCAST_YEAR					int NULL,
	BRDCAST_PER						int NULL, 
	SPOTS							int NULL,
	LINE_NET						decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	DISCOUNT						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	BILLING_AMT						decimal(15,2) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
-- Temp table #media_orders - stores table of orders to be processed
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #media_orders
SELECT [USER_ID], ORDER_NBR, ORDER_TYPE
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)
--SELECT * FROM #media_orders--------------------------------

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE 
FROM #media_orders
--SELECT * FROM #order_type

-- Temp table #ar_info
CREATE TABLE #ar_info(
	AR_INV_NBR						int NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLEXACT							int NULL,
	AR_INV_DATE						smalldatetime NULL,
	AR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

INSERT INTO #ar_info
SELECT ar.AR_INV_NBR,
	ar.AR_TYPE,
	MAX(ar.GLEXACT),
	MAX(ar.AR_INV_DATE),
	MAX(ar.AR_POST_PERIOD)
FROM dbo.ACCT_REC AS ar
GROUP BY ar.AR_INV_NBR, ar.AR_TYPE		--, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD
--SELECT * FROM #ar_info

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #order_monthly
		SELECT 'ORDER' AS REC_TYPE, 
		'R' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.SEQ_NBR,
		d.MONTH_IND, 
		d.MONTH_SHORT, 
		d.BRDCAST_YEAR,  
		d.BRDCAST_PER,
		SUM(d.SPOTS) AS SPOTS,
		SUM(d.[LINE_NET]) AS [LINE_NET],
		SUM(d.[COMM_AMT]) AS [COMM_AMT],
		SUM(d.[REBATE_AMT]) AS [REBATE_AMT],
		SUM(d.[DISCOUNT]) AS [DISCOUNT],
		SUM(d.[VENDOR_TAX]) AS [VENDOR_TAX],
		SUM(d.[STATE_TAX]) AS [STATE_TAX],
		SUM(d.[COUNTY_TAX]) AS [COUNTY_TAX],
		SUM(d.[CITY_TAX]) AS [CITY_TAX],
		SUM(d.LINE_NET + d.DISCOUNT + d.COMM_AMT + d.REBATE_AMT + d.VENDOR_TAX + 
			d.STATE_TAX + d.COUNTY_TAX + d.CITY_TAX) AS [LINE_TOTAL],
		CASE h.BILL_TYPE_FLAG	
			WHEN 1 THEN SUM(d.[BILLING_AMT] + d.[STATE_TAX] + d.[COUNTY_TAX] + d.[CITY_TAX])
			ELSE SUM(d.[BILLING_AMT])
		END AS [BILLING_AMT],	
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
	d.BILLING_USER
	FROM #media_orders AS o
	INNER JOIN dbo.V_RADIO_DETAIL1 AS d 
		ON o.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.RADIO_HEADER AS h
		ON d.ORDER_NBR = h.ORDER_NBR
		AND d.REV_NBR = h.REV_NBR			
	WHERE d.BRDCAST_PER >= @start_period AND d.BRDCAST_PER <= @end_period
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.SEQ_NBR, d.MONTH_IND, d.MONTH_SHORT, 
		d.BRDCAST_YEAR, d.BRDCAST_PER, d.AR_INV_NBR, d.AR_INV_SEQ, d.AR_TYPE,
		d.BILLING_USER, h.BILL_TYPE_FLAG
END

-- Television------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #order_monthly
		SELECT 'ORDER' AS REC_TYPE, 
		'T' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR, 
		d.REV_NBR,
		d.SEQ_NBR,
		d.MONTH_IND, 
		d.MONTH_SHORT, 
		d.BRDCAST_YEAR, 
		d.BRDCAST_PER,
		SUM(d.SPOTS) AS SPOTS,
		SUM(d.[LINE_NET]) AS [LINE_NET],
		SUM(d.[COMM_AMT]) AS [COMM_AMT],
		SUM(d.[REBATE_AMT]) AS [REBATE_AMT],
		SUM(d.[DISCOUNT]) AS [DISCOUNT],
		SUM(d.[VENDOR_TAX]) AS [VENDOR_TAX],
		SUM(d.[STATE_TAX]) AS [STATE_TAX],
		SUM(d.[COUNTY_TAX]) AS [COUNTY_TAX],
		SUM(d.[CITY_TAX]) AS [CITY_TAX],
		SUM(d.LINE_NET + d.DISCOUNT + d.COMM_AMT + d.REBATE_AMT + d.VENDOR_TAX + 
			d.STATE_TAX + d.COUNTY_TAX + d.CITY_TAX) AS [LINE_TOTAL],
		CASE h.BILL_TYPE_FLAG	
			WHEN 1 THEN SUM(d.[BILLING_AMT] + d.[STATE_TAX] + d.[COUNTY_TAX] + d.[CITY_TAX])
			ELSE SUM(d.[BILLING_AMT])
		END AS [BILLING_AMT],	
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o
	INNER JOIN dbo.V_TV_DETAIL1 AS d 
		ON o.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.TV_HEADER AS h
		ON d.ORDER_NBR = h.ORDER_NBR
		AND d.REV_NBR = h.REV_NBR			
	WHERE d.BRDCAST_PER >= @start_period AND d.BRDCAST_PER <= @end_period
	GROUP BY d.ORDER_NBR, d.LINE_NBR,  d.REV_NBR, d.SEQ_NBR, d.MONTH_IND, d.MONTH_SHORT, 
		d.BRDCAST_YEAR, d.BRDCAST_PER, d.AR_INV_NBR, d.AR_INV_SEQ, d.AR_TYPE,
		d.BILLING_USER, h.BILL_TYPE_FLAG
END

SELECT o.*, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD
FROM #order_monthly AS o
LEFT JOIN #ar_info AS ar
	ON o.AR_INV_NBR = ar.AR_INV_NBR
	AND o.AR_TYPE = ar.AR_TYPE

END
