
CREATE PROCEDURE [dbo].[advsp_media1_order_print_amounts] ( @user_code varchar(100) )
-- @order_type m=magazine, n=newspaper, i=internet, o=outdoor

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_amounts(
	REC_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	ACTIVE_REV						smallint NULL,
	COLOR_CHARGE					decimal(15,4) NULL,
	COLOR_DESC						varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BLEED_AMT						decimal(15,2) NULL,
	POSITION_AMT					decimal(15,2) NULL,
	PREMIUM_AMT						decimal(15,2) NULL,
	NON_BILL_FLAG					smallint NULL,
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL,								 
	FLAT_GROSS						decimal(15,2) NULL, 								 
	FLAT_NET						decimal(15,2) NULL,
	GROSS_RATE						decimal(16,4) NULL,
	NET_RATE						decimal(16,4) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL, 
	NETCHARGE						decimal(15,2) NULL, 
	NETCHARGE_DESC					varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	NON_RESALE_AMT					decimal(15,2) NULL, 
	STATE_AMT						decimal(15,2) NULL, 
	COUNTY_AMT						decimal(15,2) NULL, 
	CITY_AMT						decimal(15,2) NULL, 
	COMM_AMT						decimal(15,2) NULL, 
	REBATE_AMT						decimal(15,2) NULL, 
	EXT_NET_AMT						decimal(15,2) NULL, 
	EXT_GROSS_AMT					decimal(15,2) NULL, 
	LINE_TOTAL						decimal(15,2) NULL, 
	BILLING_AMT						decimal(15,2) NULL,
	PRINT_QUANTITY					decimal(14,3) NULL,
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
-- SELECT * FROM #media_orders--------------------------------

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

---- Temp table #acct_rec_unvoided_list for old MAG/NEWS
--CREATE TABLE #acct_rec_unvoided_list(
--	AR_INV_NBR						int NOT NULL)
--INSERT INTO #acct_rec_unvoided_list
--SELECT ar.AR_INV_NBR
--FROM dbo.ACCT_REC AS ar
--WHERE ISNULL(ar.VOID_FLAG,0) = 0
--	AND ar.AR_INV_SEQ <> 99
--GROUP BY ar.AR_INV_NBR
--
---- Temp table #print_max_rev for old MAG/NEWS
--CREATE TABLE #print_max_rev(
--	ORDER_NBR						int NOT NULL,
--	LINE_NBR						smallint NULL,
--	REV_NBR							smallint NULL)
--INSERT INTO #print_max_rev
--SELECT ba.ORDER_NBR,
--	ba.LINE_NBR,
--	MAX(ba.REV_NBR)
--FROM dbo.MEDIA_BILL_AMTS AS ba
--JOIN #acct_rec_unvoided_list AS ul
--	ON ba.AR_INV_NBR = ul.AR_INV_NBR
--GROUP BY ba.ORDER_NBR, ba.LINE_NBR
--
---- Temp table #print_max_rev_billed for old MAG/NEWS
--CREATE TABLE #print_max_rev_billed(
--	ORDER_NBR						int NOT NULL,
--	LINE_NBR						smallint NULL,
--	REV_NBR							smallint NULL,
--	SEQ_NBR							smallint NULL,
--	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
--	BILLING_SEQ						smallint NULL)
--INSERT INTO #print_max_rev_billed
--SELECT ba.ORDER_NBR,
--	ba.LINE_NBR,
--	ba.REV_NBR,
--	MAX(ba.SEQ_NBR),
--	MAX(ba.BILLING_USER),
--	MAX(ba.BILLING_SEQ)
--FROM dbo.MEDIA_BILL_AMTS AS ba
--JOIN #acct_rec_unvoided_list AS ul
--	ON ba.AR_INV_NBR = ul.AR_INV_NBR
--JOIN #print_max_rev AS mr
--	ON ba.ORDER_NBR = mr.ORDER_NBR
--	AND ba.LINE_NBR = mr.LINE_NBR
--	AND ba.REV_NBR = mr.REV_NBR
--GROUP BY ba.ORDER_NBR, ba.LINE_NBR, ba.REV_NBR
--
---- Temp table #print_billed_type_flag for old MAG/NEWS
--CREATE TABLE #print_billed_type_flag(
--	ORDER_NBR						int NOT NULL,
--	LINE_NBR						smallint NULL,
--	BILL_COMM_NET					smallint NULL)
--INSERT INTO #print_billed_type_flag
--SELECT ba.ORDER_NBR,
--	ba.LINE_NBR,
--	ba.BILL_COMM_NET
--FROM dbo.MEDIA_BILL_AMTS AS ba
--JOIN #print_max_rev_billed AS mr
--	ON ba.ORDER_NBR = mr.ORDER_NBR
--	AND ba.LINE_NBR = mr.LINE_NBR
--	AND ba.REV_NBR = mr.REV_NBR
--	AND ba.SEQ_NBR = mr.SEQ_NBR
--	AND ba.BILLING_USER = mr.BILLING_USER
--	AND ba.BILLING_SEQ = mr.BILLING_SEQ	
--
----SELECT * FROM #print_billed_type_flag						
--
---- Temp table #max_rev_seq - used for old MAG/NEWS
--CREATE TABLE #max_rev_seq(
--	ORDER_NBR						int NOT NULL,
--	LINE_NBR						smallint NULL,
--	REV_NBR							smallint NULL,
--	SEQ_NBR							smallint NULL)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
BEGIN
	-- Magazine (new)--------------------------------------------
	INSERT INTO #order_amounts
	SELECT 'ORDER' AS REC_TYPE, 
		'M' AS ORDER_TYPE, 
		d.ORDER_NBR,
		d.LINE_NBR,
		d.ACTIVE_REV,
		IsNull(d.[COLOR_CHARGE],0) AS [COLOR_CHARGE],	--magazine/newspaper
		d.COLOR_DESC,									--magazine/newspaper
		IsNull(d.[BLEED_AMT],0) AS [BLEED_AMT],			--magazine only
		IsNull(d.[POSITION_AMT],0) AS [POSITION_AMT],	--magazine only
		IsNull(d.[PREMIUM_AMT],0) AS PREMIUM_AMT,		--magazine only
		d.NON_BILL_FLAG,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.[FLAT_GROSS],0),
		ISNULL(d.[FLAT_NET],0),
		d.[GROSS_RATE],
		d.[NET_RATE],
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[ADDL_CHARGE],0) AS [ADDL_CHARGE], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		d.NETCHARGE_DESC, 
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT],  
		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT],  
		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT], 
		IsNull(d.[EXT_GROSS_AMT],0) AS [EXT_GROSS_AMT],  
		IsNull(d.[LINE_TOTAL],0) AS [LINE_TOTAL], 
		IsNull(d.[BILLING_AMT],0) AS [BILLING_AMT], 
		0 as PRINT_QUANTITY,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o
	JOIN dbo.MAGAZINE_DETAIL AS d
		ON o.ORDER_NBR = d.ORDER_NBR 

--	-- Mag (old)--------------------------------------------
--	--Populate table #max_rev_seq
--	INSERT INTO #max_rev_seq
--	SELECT d.ORDER_NBR,
--		d.LINE_NBR,
--		d.REV_NBR,
--		MAX(d.SEQ_NBR)
--	FROM dbo.MAG_DETAIL AS d
--	JOIN #media_orders AS o
--		ON d.ORDER_NBR = o.ORDER_NBR
--	WHERE d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.MAG_DETAIL AS d2
--		WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
--	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--	--SELECT * FROM #max_rev_seq
--
--	--Extract data from MAG_DETAIL
--	INSERT INTO #order_amounts
--	SELECT 'ORDER' AS REC_TYPE, 
--		'M' AS ORDER_TYPE, 
--		d.ORDER_NBR,
--		d.LINE_NBR, 
--		IsNull(d.[COLOR_AMT],0) AS [COLOR_CHARGE],		--magazine/newspaper
--		d.COLORDESC AS COLOR_DESC,						--magazine/newspaper
--		IsNull(d.[BLEED_AMT],0) AS [BLEED_AMT],			--magazine only
--		IsNull(d.[POSITION_AMT],0) AS [POSITION_AMT],	--magazine only
--		IsNull(d.[PREMIUM_AMT],0) AS PREMIUM_AMT,		--magazine only
--		d.NET_GROSS, 
--		0 AS NON_BILL_FLAG,
--		RATE = CASE d.[NET_GROSS]
--			WHEN 1 THEN d.[FLAT_GROSS]
--			ELSE d.[FLAT_NET]
--		END, 
--		UNIT_RATE = CASE d.[NET_GROSS]
--			WHEN 1 THEN d.[GROSS_RATE]
--			ELSE d.[NET_RATE]
--		END, 
--		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT],  
--		IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0) AS [DISCOUNT_AMT],
--		0 AS [ADDL_CHARGE],  
--		IsNull(n.[NETCHARGE1],0) + IsNull(n.[NETCHARGE2],0) + IsNull(n.[NETCHARGE3],0) +  
--			IsNull(n.[NETCHARGE4],0) + IsNull(n.[NETCHARGE5],0) + IsNull(n.[NETCHARGE6],0) AS [NETCHARGE], 
--		n.NCDESC1 AS NETCHARGE_DESC, 
--		IsNull(t.[VENDOR_TAX],0) AS [NON_RESALE_AMT], 
--		IsNull(t.[STATE_TAX],0) AS [STATE_AMT], 
--		IsNull(t.[COUNTY_TAX],0) AS [COUNTY_AMT], 
--		IsNull(t.[CITY_TAX],0) AS [CITY_AMT], 
--		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
--		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT], 
--		d.EXT_NET_AMT, 
--		d.EXT_GROSS_AMT, 
--		d.LINE_TOTAL,
--		CASE ISNULL(f.BILL_COMM_NET,0)			-- Same as Adassist BILLED_TYPE_FLAG
--			WHEN 0 THEN
--				CASE  
--					WHEN p.PRD_MAG_COM_ONLY = 1 THEN IsNull(d.[COMM_AMT],0) + IsNull(d.[REBATE_AMT],0)
--					WHEN p.PRD_MAG_BILL_NET = 1 THEN IsNull(d.[EXT_NET_AMT],0) 
--						+ IsNull(n.[NETCHARGE1],0) + IsNull(n.[NETCHARGE2],0) + IsNull(n.[NETCHARGE3],0)  
--						+ IsNull(n.[NETCHARGE4],0) + IsNull(n.[NETCHARGE5],0) + IsNull(n.[NETCHARGE6],0)
--						+ IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0) 
--						+ IsNull(t.[STATE_TAX],0) + IsNull(t.[COUNTY_TAX],0) + IsNull(t.[CITY_TAX],0)
--						+ IsNull(t.[VENDOR_TAX],0)
--					ELSE IsNull(d.[LINE_TOTAL],0) 
--				END
--			WHEN 1 THEN IsNull(d.[COMM_AMT],0) + IsNull(d.[REBATE_AMT],0)
--			WHEN 2 THEN IsNull(d.[EXT_NET_AMT],0) 
--				+ IsNull(n.[NETCHARGE1],0) + IsNull(n.[NETCHARGE2],0) + IsNull(n.[NETCHARGE3],0)  
--				+ IsNull(n.[NETCHARGE4],0) + IsNull(n.[NETCHARGE5],0) + IsNull(n.[NETCHARGE6],0)
--				+ IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0)
--				+ IsNull(t.[STATE_TAX],0) + IsNull(t.[COUNTY_TAX],0) + IsNull(t.[CITY_TAX],0)
--				+ IsNull(t.[VENDOR_TAX],0)
--			ELSE IsNull(d.[LINE_TOTAL],0) 
--		END AS BILLING_AMT,
--		d.AR_INV_NBR,
--		d.AR_INV_SEQ,
--		d.AR_TYPE 
--	FROM #max_rev_seq AS s  
--	JOIN dbo.MAG_DETAIL AS d
--		ON s.ORDER_NBR = d.ORDER_NBR
--		AND s.LINE_NBR = d.LINE_NBR
--		AND s.REV_NBR = d.REV_NBR
--		AND s.SEQ_NBR = d.SEQ_NBR  
--	JOIN dbo.MAG_TAXES AS t
--		ON s.ORDER_NBR = t.ORDER_NBR
--		AND s.LINE_NBR = t.LINE_NBR
--		AND s.REV_NBR = t.REV_NBR
--		AND s.SEQ_NBR = t.SEQ_NBR  
--	JOIN dbo.MAG_DISC AS disc
--		ON s.ORDER_NBR = disc.ORDER_NBR
--		AND s.LINE_NBR = disc.LINE_NBR
--		AND s.REV_NBR = disc.REV_NBR
--		AND s.SEQ_NBR = disc.SEQ_NBR 
--	JOIN dbo.MAG_NET_CHG AS n
--		ON s.ORDER_NBR = n.ORDER_NBR
--		AND s.LINE_NBR = n.LINE_NBR
--		AND s.REV_NBR = n.REV_NBR
--		AND s.SEQ_NBR = n.SEQ_NBR
--	JOIN dbo.MAG_HEADER AS h
--		ON s.ORDER_NBR = h.ORDER_NBR
--	JOIN dbo.PRODUCT AS p
--		ON h.CL_CODE = p.CL_CODE
--		AND h.DIV_CODE = p.DIV_CODE
--		AND h.PRD_CODE = p.PRD_CODE
--	LEFT JOIN #print_billed_type_flag AS f
--		ON d.ORDER_NBR = f.ORDER_NBR
--		AND d.LINE_NBR = f.LINE_NBR 
--	WHERE  IsNull(d.[LINE_CANCELLED],0) = 0 
--
--	--Clear records from #max_rev_seq
--	DELETE FROM #max_rev_seq
END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
BEGIN
	-- Newspaper (new)--------------------------------------------
	INSERT INTO #order_amounts
	SELECT 'ORDER' AS REC_TYPE, 
		'N' AS ORDER_TYPE, 
		d.ORDER_NBR,
		d.LINE_NBR,
		d.ACTIVE_REV,
		IsNull(d.[COLOR_CHARGE],0) AS [COLOR_CHARGE], 
		d.COLOR_DESC,
		0 AS [BLEED_AMT],								--magazine only
		0 AS [POSITION_AMT],							--magazine only
		0 AS [PREMIUM_AMT],								--magazine only
		d.NON_BILL_FLAG,
		d.BILL_TYPE_FLAG, 
		ISNULL(d.LINE_CANCELLED,0),
		ISNULL(d.[FLAT_GROSS],0),
		ISNULL(d.[FLAT_NET],0),
		ISNULL(d.[GROSS_RATE],0) - ISNULL(d.[COLOR_CHARGE],0),
		ISNULL(d.[NET_RATE],0) - ISNULL(d.[COLOR_CHARGE],0),
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT],
		IsNull(d.[ADDL_CHARGE],0) AS [ADDL_CHARGE],  
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		d.NETCHARGE_DESC,
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT],  
		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT], 
		IsNull(d.[EXT_GROSS_AMT],0) AS [EXT_GROSS_AMT],  
		IsNull(d.[LINE_TOTAL],0) AS [LINE_TOTAL], 
		IsNull(d.[BILLING_AMT],0) AS [BILLING_AMT], 
		0 as PRINT_QUANTITY,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o 
	JOIN dbo.NEWSPAPER_DETAIL AS d
		ON o.ORDER_NBR = d.ORDER_NBR

--	-- News (old)--------------------------------------------
--	--Populate table #max_rev_seq
--	INSERT INTO #max_rev_seq
--	SELECT d.ORDER_NBR,
--		d.LINE_NBR,
--		d.REV_NBR,
--		MAX(d.SEQ_NBR)
--	FROM dbo.NEWS_DETAIL AS d
--	JOIN #media_orders AS o
--		ON d.ORDER_NBR = o.ORDER_NBR
--	WHERE d.REV_NBR = (SELECT MAX(d2.REV_NBR) FROM dbo.NEWS_DETAIL AS d2
--		WHERE d.ORDER_NBR = d2.ORDER_NBR AND d.LINE_NBR = d2.LINE_NBR)
--	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR
--	--SELECT * FROM #max_rev_seq
--
--	--Extract data from NEWS_DETAIL
--	INSERT INTO #order_amounts
--	SELECT 'ORDER' AS REC_TYPE, 
--		'N' AS ORDER_TYPE, 
--		d.ORDER_NBR,
--		d.LINE_NBR, 
--		IsNull(d.[COLOR_AMT],0) AS [COLOR_CHARGE],			--magazine/newspaper
--		d.COLORDESC AS COLOR_DESC,							--magazine/newspaper
--		0 AS [BLEED_AMT],									--magazine only
--		0 AS [POSITION_AMT],								--magazine only
--		0 AS PREMIUM_AMT,									--magazine only
--		d.NET_GROSS,
--		0 AS NON_BILL_FLAG, 
--		RATE = CASE d.[NET_GROSS]
--			WHEN 1 THEN d.[EXT_GROSS_FLAT]
--			ELSE d.[EXT_NET_FLAT]
--		END, 
--		UNIT_RATE = CASE d.[NET_GROSS]
--			WHEN 1 THEN d.[GROSS_RATE]
--			ELSE d.[NET_RATE]
--		END, 
--		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT],  
--		IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0) AS [DISCOUNT_AMT],
--		0 AS [ADDL_CHARGE],  
--		IsNull(n.[PROD_CHARGE],0) + IsNull(n.[BOX_COMM],0) + IsNull(n.[FAX_PHONE],0) + 
--			IsNull(n.[DELY_CHARGE],0) + IsNull(n.[CREATIVE_FEE],0) + IsNull(n.[SERVICE_FEE],0) AS [NETCHARGE], 
--		NULL AS NETCHARGE_DESC, 
--		IsNull(t.[VENDOR_TAX],0) AS [NON_RESALE_AMT], 
--		IsNull(t.[STATE_TAX],0) AS [STATE_AMT], 
--		IsNull(t.[COUNTY_TAX],0) AS [COUNTY_AMT], 
--		IsNull(t.[CITY_TAX],0) AS [CITY_AMT], 
--		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
--		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT], 
--		d.EXT_NET_AMT, 
--		d.EXT_GROSS_AMT, 
--		d.LINE_TOTAL,
--		CASE ISNULL(f.BILL_COMM_NET,0)			-- Same as Adassist BILLED_TYPE_FLAG
--			WHEN 0 THEN
--				CASE  
--					WHEN p.PRD_NEWS_COM_ONLY = 1 THEN IsNull(d.[COMM_AMT],0) + IsNull(d.[REBATE_AMT],0)
--					WHEN p.PRD_NEWS_BILL_NET = 1 THEN IsNull(d.[EXT_NET_AMT],0) 
--						+ IsNull(n.[PROD_CHARGE],0) + IsNull(n.[BOX_COMM],0) + IsNull(n.[FAX_PHONE],0)
--						+ IsNull(n.[DELY_CHARGE],0) + IsNull(n.[CREATIVE_FEE],0) + IsNull(n.[SERVICE_FEE],0)
--						+ IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0)
--						+ IsNull(t.[STATE_TAX],0) + IsNull(t.[COUNTY_TAX],0) + IsNull(t.[CITY_TAX],0)
--						+ IsNull(t.[VENDOR_TAX],0)
--					ELSE IsNull(d.[LINE_TOTAL],0) 
--				END
--			WHEN 1 THEN IsNull(d.[COMM_AMT],0) + IsNull(d.[REBATE_AMT],0)
--			WHEN 2 THEN IsNull(d.[EXT_NET_AMT],0)  
--				+ IsNull(n.[PROD_CHARGE],0) + IsNull(n.[BOX_COMM],0) + IsNull(n.[FAX_PHONE],0)
--				+ IsNull(n.[DELY_CHARGE],0) + IsNull(n.[CREATIVE_FEE],0) + IsNull(n.[SERVICE_FEE],0)
--				+ IsNull(disc.[LINE_NET_DISC],0) + IsNull(disc.NETCHARGES_DISC,0)
--				+ IsNull(t.[STATE_TAX],0) + IsNull(t.[COUNTY_TAX],0) + IsNull(t.[CITY_TAX],0)
--				+ IsNull(t.[VENDOR_TAX],0)
--			ELSE IsNull(d.[LINE_TOTAL],0) 
--		END AS BILLING_AMT,
--		d.AR_INV_NBR,
--		d.AR_INV_SEQ,
--		d.AR_TYPE 
--	FROM #max_rev_seq AS s  
--	JOIN dbo.NEWS_DETAIL AS d
--		ON s.ORDER_NBR = d.ORDER_NBR
--		AND s.LINE_NBR = d.LINE_NBR
--		AND s.REV_NBR = d.REV_NBR
--		AND s.SEQ_NBR = d.SEQ_NBR  
--	JOIN dbo.NEWS_TAXES AS t
--		ON s.ORDER_NBR = t.ORDER_NBR
--		AND s.LINE_NBR = t.LINE_NBR
--		AND s.REV_NBR = t.REV_NBR
--		AND s.SEQ_NBR = t.SEQ_NBR  
--	JOIN dbo.NEWS_DISC AS disc
--		ON s.ORDER_NBR = disc.ORDER_NBR
--		AND s.LINE_NBR = disc.LINE_NBR
--		AND s.REV_NBR = disc.REV_NBR
--		AND s.SEQ_NBR = disc.SEQ_NBR 
--	JOIN dbo.NEWS_NET_CHG AS n
--		ON s.ORDER_NBR = n.ORDER_NBR
--		AND s.LINE_NBR = n.LINE_NBR
--		AND s.REV_NBR = n.REV_NBR
--		AND s.SEQ_NBR = n.SEQ_NBR
--	JOIN dbo.NEWS_HEADER AS h
--		ON s.ORDER_NBR = h.ORDER_NBR
--	JOIN dbo.PRODUCT AS p
--		ON h.CL_CODE = p.CL_CODE
--		AND h.DIV_CODE = p.DIV_CODE
--		AND h.PRD_CODE = p.PRD_CODE
--	LEFT JOIN #print_billed_type_flag AS f
--		ON d.ORDER_NBR = f.ORDER_NBR
--		AND d.LINE_NBR = f.LINE_NBR   
--	WHERE  IsNull(d.[LINE_CANCELLED],0) = 0
--
--	--Clear records from #max_rev_seq
--	DELETE FROM #max_rev_seq
END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
BEGIN
	-- Internet -----------------------------------------------
	INSERT INTO #order_amounts
	SELECT 'ORDER' AS REC_TYPE, 
		'I' AS ORDER_TYPE,
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.ACTIVE_REV, 
		0 AS [COLOR_CHARGE],							--magazine/newspaper
		NULL AS COLOR_DESC,								--magazine/newspaper
		0 AS BLEED_AMT,									--magazine only
		0 AS [POSITION_AMT],							--magazine only
		0 AS [PREMIUM_AMT],								--magazine only
		d.NON_BILL_FLAG, 
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.[GROSS_RATE],
		d.[NET_RATE],
		NULL AS GROSS_RATE,
		NULL AS NET_RATE,
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT],
		IsNull(d.[ADDL_CHARGE],0) AS [ADDL_CHARGE],  
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		NULL AS NETCHARGE_DESC, 
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT], 
		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT], 
		IsNull(d.[EXT_GROSS_AMT],0) AS [EXT_GROSS_AMT],  
		IsNull(d.[LINE_TOTAL],0) AS [LINE_TOTAL], 
		IsNull(d.[BILLING_AMT],0) AS [BILLING_AMT], 
		0 as PRINT_QUANTITY,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o 
	JOIN dbo.INTERNET_DETAIL AS d
		ON o.ORDER_NBR = d.ORDER_NBR 
END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
BEGIN
	-- Outdoor -----------------------------------------------
	INSERT INTO #order_amounts
	SELECT 'ORDER' AS REC_TYPE, 
		'O' AS ORDER_TYPE, 
		d.ORDER_NBR,
		d.LINE_NBR, 
		d.ACTIVE_REV,
		0 AS [COLOR_CHARGE],							--magazine/newspaper
		NULL AS COLOR_DESC,								--magazine/newspaper
		0 AS [BLEED_AMT],								--magazine only
		0 AS [POSITION_AMT],							--magazine only
		0 AS [PREMIUM_AMT],								--magazine only
		d.NON_BILL_FLAG,
		d.BILL_TYPE_FLAG,
		ISNULL(d.LINE_CANCELLED,0),
		d.[GROSS_RATE],
		d.[NET_RATE],
		NULL AS GROSS_RATE,
		NULL AS NET_RATE,
		IsNull(d.[DISCOUNT_AMT],0) AS [DISCOUNT_AMT], 
		IsNull(d.[ADDL_CHARGE],0) AS [ADDL_CHARGE], 
		IsNull(d.[NETCHARGE],0) AS [NETCHARGE], 
		NULL AS NETCHARGE_DESC,
		IsNull(d.[NON_RESALE_AMT],0) AS [NON_RESALE_AMT], 
		IsNull(d.[STATE_AMT],0) AS [STATE_AMT], 
		IsNull(d.[COUNTY_AMT],0) AS [COUNTY_AMT], 
		IsNull(d.[CITY_AMT],0) AS [CITY_AMT], 
		IsNull(d.[COMM_AMT],0) AS [COMM_AMT], 
		IsNull(d.[REBATE_AMT],0) AS [REBATE_AMT], 
		IsNull(d.[EXT_NET_AMT],0) AS [EXT_NET_AMT], 
		IsNull(d.[EXT_GROSS_AMT],0) AS [EXT_GROSS_AMT],  
		IsNull(d.[LINE_TOTAL],0) AS [LINE_TOTAL], 
		IsNull(d.[BILLING_AMT],0) AS [BILLING_AMT], 
		0 as PRINT_QUANTITY,
		d.AR_INV_NBR,
		d.AR_INV_SEQ,
		d.AR_TYPE,
		d.BILLING_USER
	FROM #media_orders AS o 
	JOIN dbo.OUTDOOR_DETAIL AS d
		ON o.ORDER_NBR = d.ORDER_NBR
END

SELECT o.*, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD
FROM #order_amounts AS o
LEFT JOIN #ar_info AS ar
	ON o.AR_INV_NBR = ar.AR_INV_NBR
	AND o.AR_TYPE = ar.AR_TYPE
END
