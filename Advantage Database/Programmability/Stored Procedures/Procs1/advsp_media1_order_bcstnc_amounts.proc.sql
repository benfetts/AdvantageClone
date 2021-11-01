
CREATE PROCEDURE [dbo].[advsp_media1_order_bcstnc_amounts] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_amounts(
	REC_TYPE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE					varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR					int NOT NULL,
	LINE_NBR					int NOT NULL,
	REV_NBR						smallint NOT NULL,
	SEQ_NBR						smallint NOT NULL,
	BRDCAST_PER					int NULL,
	NETCHARGES					decimal(15,2) NULL,
	VENDOR_TAX_NC				decimal(15,2) NULL,
	STATE_TAX_NC				decimal(15,2) NULL,
	COUNTY_TAX_NC				decimal(15,2) NULL,
	CITY_TAX_NC					decimal(15,2) NULL,
	LINE_TOTAL_NC				decimal(15,2) NULL,
	BILLING_AMT_NC				decimal(15,2) NULL,
	AR_INV_NBR					int NULL,
	AR_INV_SEQ					smallint NULL,
	AR_TYPE						varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BILLING_USER				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)

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
-- SELECT * FROM #media_orders

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
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #order_amounts
	SELECT 'ORDNC' AS REC_TYPE,
		'R' AS ORDER_TYPE, 
		d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		dbo.fn_bcst_netcharge_mindate(d.ORDER_NBR, 'R'),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.VENDOR_TAX_NC,0)),
		SUM(ISNULL(d.STATE_TAX_NC,0)),
		SUM(ISNULL(d.COUNTY_TAX_NC,0)),
		SUM(ISNULL(d.CITY_TAX_NC,0)),
		SUM(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0) + ISNULL(d.STATE_TAX_NC,0) + ISNULL(d.COUNTY_TAX_NC,0) 
			+ ISNULL(d.CITY_TAX_NC,0)),
		NULL AS BILLING_AMT_NC,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR 
	WHERE ISNULL(d.LINE_CANCELLED,0) = 0 
		AND ISNULL(d.DELETE_FLAG,0)= 0
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.SEQ_NBR, d.AR_INV_NBR, d.AR_INV_SEQ, d.AR_TYPE, d.BILLING_USER
	HAVING SUM(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0) + ISNULL(d.STATE_TAX_NC,0) + ISNULL(d.COUNTY_TAX_NC,0) 
		+ ISNULL(d.CITY_TAX_NC,0)) <> 0
	-- SELECT * FROM #order_amounts
END

-- Television--------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #order_amounts
	SELECT 'ORDNC' AS REC_TYPE,
		'T' AS ORDER_TYPE,
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		dbo.fn_bcst_netcharge_mindate(d.ORDER_NBR, 'T'),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.VENDOR_TAX_NC,0)),
		SUM(ISNULL(d.STATE_TAX_NC,0)),
		SUM(ISNULL(d.COUNTY_TAX_NC,0)),
		SUM(ISNULL(d.CITY_TAX_NC,0)),
		SUM(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0) + ISNULL(d.STATE_TAX_NC,0) + ISNULL(d.COUNTY_TAX_NC,0) 
			+ ISNULL(d.CITY_TAX_NC,0)),
		NULL AS BILLING_AMT_NC,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o
	INNER JOIN dbo.TV_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR 
	WHERE ISNULL(d.LINE_CANCELLED,0) = 0 
		AND ISNULL(d.DELETE_FLAG,0)= 0
	GROUP BY d.ORDER_NBR, d.LINE_NBR,  d.REV_NBR, d.SEQ_NBR,d.AR_INV_NBR, d.AR_INV_SEQ, d.AR_TYPE, d.BILLING_USER
	HAVING SUM(ISNULL(d.NETCHARGES,0) + ISNULL(d.VENDOR_TAX_NC,0) + ISNULL(d.STATE_TAX_NC,0) + ISNULL(d.COUNTY_TAX_NC,0) 
		+ ISNULL(d.CITY_TAX_NC,0)) <> 0
END

SELECT o.*, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD
FROM #order_amounts AS o
LEFT JOIN #ar_info AS ar
	ON o.AR_INV_NBR = ar.AR_INV_NBR
	AND o.AR_TYPE = ar.AR_TYPE

END
