--insert the next (3) statements at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_print_amounts_ap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_print_amounts_ap]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_print_amounts_ap] ( @user_code varchar(100) )

-- ===============================================================================
-- advsp_media1_order_print_amounts_ap
-- #00 02/20/13 - version history lost (JP)
-- #01 02/20/13 - added column AP_PRINT_QUANTITY for newspaper and internet use
-- #02 12/17/14 - added column AP_ID
-- ==============================================================================

AS
BEGIN
	SET NOCOUNT ON;

-- ======================================================================================
-- MAIN DATA TABLE
-- ======================================================================================
CREATE TABLE #order_ap(
	REC_TYPE						varchar(5) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	ORDER_NBR						int NOT NULL,
	LINE_NBR						int NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	[MONTH]							smallint NULL,
	[YEAR]							int NULL,
	AP_NET_AMT						decimal(15,2) NULL,
	AP_NETCHARGES					decimal(15,2) NULL,
	AP_DISCOUNT_AMT					decimal(15,2) NULL,
	AP_ADDL_CHARGE					decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	AP_COMM_AMT						decimal(15,2) NULL,
	AP_REBATE_AMT					decimal(15,2) NULL,
	AP_VENDOR_TAX					decimal(15,2) NULL,
	AP_STATE_TAX					decimal(15,2) NULL,
	AP_COUNTY_TAX					decimal(15,2) NULL,
	AP_CITY_TAX						decimal(15,2) NULL,
	AP_DISBURSED_AMT				decimal(15,2) NULL,	
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,			
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_PRINT_QUANTITY				decimal(14,3) NULL,
	AP_ID							int NULL)

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
--SELECT * FROM #media_orders

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE 
FROM #media_orders
--SELECT * FROM #order_type

-- Temp table #order_line_maxrev_maxseq
CREATE TABLE #order_line_maxrev_maxseq(
	ORDER_NBR				int NOT NULL,
	LINE_NBR				smallint NULL,
	MAX_REV					smallint NULL,
	MAX_SEQ					smallint NULL)

-- ===========================================================================
-- EXTRACTION ROUTINES
-- ===========================================================================
-- Magazine A/P Amounts 
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
BEGIN
	INSERT INTO #order_line_maxrev_maxseq
	SELECT h.ORDER_NBR,
		h.LINE_NBR,
		h.REV_NBR,
		MAX(h.SEQ_NBR)
	FROM dbo.MAGAZINE_DETAIL AS h
	WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.MAGAZINE_DETAIL AS h2 
		WHERE h.ORDER_NBR = h2.ORDER_NBR AND h.LINE_NBR = h2.LINE_NBR)
	GROUP BY h.ORDER_NBR, h.LINE_NBR, h.REV_NBR

	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'M' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.ORDER_LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		SUM(ISNULL(d.NET_PLUS,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		(SUM(ISNULL(d.DISCOUNT_LN,0))+SUM(ISNULL(d.DISCOUNT_NC,0))) AS [AP_DISCOUNT_AMT],
		0 AS ADDL_CHARGE,
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(ISNULL(d.DISBURSED_AMT,0)),
		SUM(ISNULL(d.LINE_TOTAL,0)),
		CASE d2.BILL_TYPE_FLAG
			WHEN 1 THEN SUM(ISNULL(d.[COMM_AMT],0) + ISNULL(d.[REBATE_AMT],0))
			WHEN 2 THEN SUM(ISNULL(d.NET_PLUS,0) + ISNULL(d.NETCHARGES,0) + ISNULL(d.DISCOUNT_LN,0) + ISNULL(d.DISCOUNT_NC,0) + ISNULL(d.VENDOR_TAX,0) + 
				ISNULL(d.[STATE_TAX],0) + ISNULL(d.[COUNTY_TAX],0) + ISNULL(d.[CITY_TAX],0))
			ELSE SUM(ISNULL(d.[LINE_TOTAL],0)) 
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		0,
		d.AP_ID
	FROM dbo.AP_MAGAZINE AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN #order_line_maxrev_maxseq AS md
		ON d.ORDER_NBR = md.ORDER_NBR
		AND d.ORDER_LINE_NBR = md.LINE_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND d.AP_SEQ = h.AP_SEQ
		AND (h.DELETE_FLAG IS NULL OR h.DELETE_FLAG = 0)		--*******************************************************
	JOIN dbo.MAGAZINE_DETAIL AS d2								--changed from LEFT JOIN to eliminate old MAG
		ON md.ORDER_NBR = d2.ORDER_NBR
		AND md.LINE_NBR = d2.LINE_NBR
		AND md.MAX_REV = d2.REV_NBR
		AND md.MAX_SEQ = d2.SEQ_NBR
	GROUP BY d.ORDER_NBR, d.ORDER_LINE_NBR, md.MAX_REV, md.MAX_SEQ, d2.LINE_CANCELLED, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, d2.BILL_TYPE_FLAG, d.AP_ID

	DELETE FROM #order_line_maxrev_maxseq
END

-- Newspaper A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
BEGIN
	INSERT INTO #order_line_maxrev_maxseq
	SELECT h.ORDER_NBR,
		h.LINE_NBR,
		h.REV_NBR,
		MAX(h.SEQ_NBR)
	FROM dbo.NEWSPAPER_DETAIL AS h
	WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.NEWSPAPER_DETAIL AS h2 
		WHERE h.ORDER_NBR = h2.ORDER_NBR AND h.LINE_NBR = h2.LINE_NBR)
	GROUP BY h.ORDER_NBR, h.LINE_NBR, h.REV_NBR

	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'N' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.ORDER_LINE_NBR,
		md.MAX_REV AS REV_NBR,
		md.MAX_SEQ AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		SUM(ISNULL(d.NET_PLUS,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		(SUM(ISNULL(d.DISCOUNT_LN,0))+SUM(ISNULL(d.DISCOUNT_NC,0))) AS [AP_DISCOUNT_AMT],
		0 AS ADDL_CHARGE,
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(ISNULL(d.DISBURSED_AMT,0)),
		SUM(ISNULL(d.LINE_TOTAL,0)),
		CASE d2.BILL_TYPE_FLAG
			WHEN 1 THEN SUM(ISNULL(d.[COMM_AMT],0) + ISNULL(d.[REBATE_AMT],0))
			WHEN 2 THEN	SUM(ISNULL(d.NET_PLUS,0) + ISNULL(d.NETCHARGES,0) + ISNULL(d.DISCOUNT_LN,0) + ISNULL(d.DISCOUNT_NC,0) + 
				ISNULL(d.VENDOR_TAX,0) + ISNULL(d.[STATE_TAX],0) + ISNULL(d.[COUNTY_TAX],0) + ISNULL(d.[CITY_TAX],0))
			ELSE SUM(ISNULL(d.[LINE_TOTAL],0))
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		SUM(ISNULL(d.PRINT_LINES,0)),
		d.AP_ID
	FROM dbo.AP_NEWSPAPER AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN #order_line_maxrev_maxseq AS md
		ON d.ORDER_NBR = md.ORDER_NBR
		AND d.ORDER_LINE_NBR = md.LINE_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND d.AP_SEQ = h.AP_SEQ
		AND (h.DELETE_FLAG IS NULL OR h.DELETE_FLAG = 0)		--*******************************************************
	JOIN dbo.NEWSPAPER_DETAIL AS d2								----changed from LEFT JOIN to eliminate old NEWS
		ON md.ORDER_NBR = d2.ORDER_NBR
		AND md.LINE_NBR = d2.LINE_NBR
		AND md.MAX_REV = d2.REV_NBR
		AND md.MAX_SEQ = d2.SEQ_NBR
	GROUP BY d.ORDER_NBR, d.ORDER_LINE_NBR, md.MAX_REV, md.MAX_SEQ, d2.LINE_CANCELLED, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, d2.BILL_TYPE_FLAG, d.AP_ID

	DELETE FROM #order_line_maxrev_maxseq
END

-- Internet A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
BEGIN
	INSERT INTO #order_line_maxrev_maxseq
	SELECT h.ORDER_NBR,
		h.LINE_NBR,
		h.REV_NBR,
		MAX(h.SEQ_NBR)
	FROM dbo.INTERNET_DETAIL AS h
	WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.INTERNET_DETAIL AS h2 
		WHERE h.ORDER_NBR = h2.ORDER_NBR AND h.LINE_NBR = h2.LINE_NBR)
	GROUP BY h.ORDER_NBR, h.LINE_NBR, h.REV_NBR

	INSERT INTO #order_ap
	SELECT 'AP' AS REC_TYPE, 
		'I' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.ORDER_LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		SUM(ISNULL(d.NET_AMT,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.DISCOUNT_AMT,0)),
		0 AS ADDL_CHARGE,
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(ISNULL(d.NET_AMT,0) + ISNULL(d.NETCHARGES,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.VENDOR_TAX,0)) AS AP_DISBURSED_AMT,
		SUM(ISNULL(d.LINE_TOTAL,0)),
		CASE d2.BILL_TYPE_FLAG
			WHEN 1 THEN SUM(ISNULL(d.[COMM_AMT],0) + ISNULL(d.[REBATE_AMT],0))
			WHEN 2 THEN	SUM(ISNULL(d.NET_AMT,0) + ISNULL(d.NETCHARGES,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.VENDOR_TAX,0) + 
				ISNULL(d.[STATE_TAX],0) + ISNULL(d.[COUNTY_TAX],0) + ISNULL(d.[CITY_TAX],0))
			ELSE SUM(ISNULL(d.[LINE_TOTAL],0))
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		SUM(ISNULL(d.IMPRESSIONS,0)),
		d.AP_ID
	FROM dbo.AP_INTERNET AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN #order_line_maxrev_maxseq AS md
		ON d.ORDER_NBR = md.ORDER_NBR
		AND d.ORDER_LINE_NBR = md.LINE_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2
			WHERE h.AP_ID = h2.AP_ID)
	LEFT JOIN dbo.INTERNET_DETAIL AS d2
		ON md.ORDER_NBR = d2.ORDER_NBR
		AND md.LINE_NBR = d2.LINE_NBR
		AND md.MAX_REV = d2.REV_NBR
		AND md.MAX_SEQ = d2.SEQ_NBR
	GROUP BY d.ORDER_NBR, d.ORDER_LINE_NBR, md.MAX_REV, md.MAX_SEQ, d2.LINE_CANCELLED, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, d2.BILL_TYPE_FLAG, d.AP_ID

	DELETE FROM #order_line_maxrev_maxseq
END

-- Outdoor A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
BEGIN
	INSERT INTO #order_line_maxrev_maxseq
	SELECT h.ORDER_NBR,
		h.LINE_NBR,
		h.REV_NBR,
		MAX(h.SEQ_NBR)
	FROM dbo.OUTDOOR_DETAIL AS h
	WHERE h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.OUTDOOR_DETAIL AS h2 
		WHERE h.ORDER_NBR = h2.ORDER_NBR AND h.LINE_NBR = h2.LINE_NBR)
	GROUP BY h.ORDER_NBR, h.LINE_NBR, h.REV_NBR

	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'O' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.ORDER_LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		SUM(ISNULL(d.NET_AMT,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.DISCOUNT_AMT,0)),
		0 AS ADDL_CHARGE,
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(d.NET_AMT + d.NETCHARGES + d.DISCOUNT_AMT + d.VENDOR_TAX) AS AP_DISBURSED_AMT,
		SUM(ISNULL(d.LINE_TOTAL,0)),
		CASE d2.BILL_TYPE_FLAG
			WHEN 1 THEN SUM(ISNULL(d.[COMM_AMT],0) + ISNULL(d.[REBATE_AMT],0))
			WHEN 2 THEN	SUM(ISNULL(d.NET_AMT,0) + ISNULL(d.NETCHARGES,0) + ISNULL(d.DISCOUNT_AMT,0) + ISNULL(d.VENDOR_TAX,0) + 
				ISNULL(d.[STATE_TAX],0) + ISNULL(d.[COUNTY_TAX],0) + ISNULL(d.[CITY_TAX],0)) 
			ELSE SUM(ISNULL(d.[LINE_TOTAL],0))
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		0,
		d.AP_ID
	FROM dbo.AP_OUTDOOR AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN #order_line_maxrev_maxseq AS md
		ON d.ORDER_NBR = md.ORDER_NBR
		AND d.ORDER_LINE_NBR = md.LINE_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND h.AP_SEQ = (SELECT MAX(h2.AP_SEQ) FROM dbo.AP_HEADER AS h2
			WHERE h.AP_ID = h2.AP_ID)
	LEFT JOIN dbo.OUTDOOR_DETAIL AS d2
		ON md.ORDER_NBR = d2.ORDER_NBR
		AND md.LINE_NBR = d2.LINE_NBR
		AND md.MAX_REV = d2.REV_NBR
		AND md.MAX_SEQ = d2.SEQ_NBR
	GROUP BY d.ORDER_NBR, d.ORDER_LINE_NBR, md.MAX_REV, md.MAX_SEQ, d2.LINE_CANCELLED, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, d2.BILL_TYPE_FLAG, d.AP_ID

	DELETE FROM #order_line_maxrev_maxseq
END

SELECT * FROM #order_ap

END

GO

