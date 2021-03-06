--insert the next statement at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_print_amounts_ap_addl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_print_amounts_ap_addl]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_print_amounts_ap_addl] ( @user_code varchar(100) )
AS

-- #01 01/30/15 - (v670) filter by non-zero amounts, and replace #order_line_maxrev_maxseq with ACTIVE_REV

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
	AP_BILLING_AMT					decimal(15,2) NULL)

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

-- Temp table #ap_order_line
CREATE TABLE #ap_order_line(
	ORDER_NBR				int NOT NULL,
	LINE_NBR				smallint NULL)

-- ===========================================================================
-- EXTRACTION ROUTINES
-- ===========================================================================
-- Magazine A/P Amounts 
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
BEGIN

	INSERT INTO #ap_order_line
	SELECT DISTINCT ap.ORDER_NBR, ap.ORDER_LINE_NBR
	FROM dbo.AP_MAGAZINE AS ap

	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'M' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		0 AS AP_NET_AMT,
		0 AS AP_NETCHARGES,
		0 AS AP_DISCOUNT_AMT,
		d.ADDL_CHARGE,
		0 AS AP_COMM_AMT,
		0 AS AP_REBATE_AMT,
		0 AS AP_VENDOR_TAX,
		0 AS AP_STATE_TAX,
		0 AS AP_COUNTY_TAX,
		0 AS AP_CITY_TAX,
		0 AS AP_DISBURSED_AMT,
		0 AS AP_LINE_TOTAL,
		d.ADDL_CHARGE AS AP_BILLING_AMT
	FROM #media_orders AS o
	JOIN #ap_order_line AS ap
		ON o.ORDER_NBR = ap.ORDER_NBR
	JOIN dbo.MAGAZINE_DETAIL AS d
		ON ap.ORDER_NBR = d.ORDER_NBR
		AND ap.LINE_NBR = d.LINE_NBR
	WHERE d.ACTIVE_REV = 1																	--#01
		AND d.ADDL_CHARGE <> 0																--#01

	DELETE FROM #ap_order_line
END

-- Newspaper A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
BEGIN

	INSERT INTO #ap_order_line
	SELECT DISTINCT ap.ORDER_NBR, ap.ORDER_LINE_NBR
	FROM dbo.AP_NEWSPAPER AS ap
	
	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'N' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		0 AS AP_NET_AMT,
		0 AS AP_NETCHARGES,
		0 AS AP_DISCOUNT_AMT,
		d.ADDL_CHARGE,
		0 AS AP_COMM_AMT,
		0 AS AP_REBATE_AMT,
		0 AS AP_VENDOR_TAX,
		0 AS AP_STATE_TAX,
		0 AS AP_COUNTY_TAX,
		0 AS AP_CITY_TAX,
		0 AS AP_DISBURSED_AMT,
		0 AS AP_LINE_TOTAL,
		d.ADDL_CHARGE AS AP_BILLING_AMT
	FROM #media_orders AS o
	JOIN #ap_order_line AS ap
		ON o.ORDER_NBR = ap.ORDER_NBR
	JOIN dbo.NEWSPAPER_DETAIL AS d
		ON ap.ORDER_NBR = d.ORDER_NBR
		AND ap.LINE_NBR = d.LINE_NBR
	WHERE d.ACTIVE_REV = 1																	--#01
		AND d.ADDL_CHARGE <> 0																--#01	

	DELETE FROM #ap_order_line
END

-- Internet A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
BEGIN

	INSERT INTO #ap_order_line
	SELECT DISTINCT ap.ORDER_NBR, ap.ORDER_LINE_NBR
	FROM dbo.AP_INTERNET AS ap
	
	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'I' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		0 AS AP_NET_AMT,
		0 AS AP_NETCHARGES,
		0 AS AP_DISCOUNT_AMT,
		d.ADDL_CHARGE,
		0 AS AP_COMM_AMT,
		0 AS AP_REBATE_AMT,
		0 AS AP_VENDOR_TAX,
		0 AS AP_STATE_TAX,
		0 AS AP_COUNTY_TAX,
		0 AS AP_CITY_TAX,
		0 AS AP_DISBURSED_AMT,
		0 AS AP_LINE_TOTAL,
		d.ADDL_CHARGE AS AP_BILLING_AMT
	FROM #media_orders AS o
	JOIN #ap_order_line AS ap
		ON o.ORDER_NBR = ap.ORDER_NBR
	JOIN dbo.INTERNET_DETAIL AS d
		ON ap.ORDER_NBR = d.ORDER_NBR
		AND ap.LINE_NBR = d.LINE_NBR
	WHERE d.ACTIVE_REV = 1																	--#01
		AND d.ADDL_CHARGE <> 0																--#01	

	DELETE FROM #ap_order_line
END

-- Outdoor A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
BEGIN
	INSERT INTO #ap_order_line
	SELECT DISTINCT ap.ORDER_NBR, ap.ORDER_LINE_NBR
	FROM dbo.AP_OUTDOOR AS ap
	
	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'O' AS ORDER_TYPE,
		d.ORDER_NBR,
		d.LINE_NBR,
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		NULL AS [MONTH],
		NULL AS [YEAR],
		0 AS AP_NET_AMT,
		0 AS AP_NETCHARGES,
		0 AS AP_DISCOUNT_AMT,
		d.ADDL_CHARGE,
		0 AS AP_COMM_AMT,
		0 AS AP_REBATE_AMT,
		0 AS AP_VENDOR_TAX,
		0 AS AP_STATE_TAX,
		0 AS AP_COUNTY_TAX,
		0 AS AP_CITY_TAX,
		0 AS AP_DISBURSED_AMT,
		0 AS AP_LINE_TOTAL,
		d.ADDL_CHARGE AS AP_BILLING_AMT
	FROM #media_orders AS o
	JOIN #ap_order_line AS ap
		ON o.ORDER_NBR = ap.ORDER_NBR
	JOIN dbo.OUTDOOR_DETAIL AS d
		ON ap.ORDER_NBR = d.ORDER_NBR
		AND ap.LINE_NBR = d.LINE_NBR
	WHERE d.ACTIVE_REV = 1																	--#01
		AND d.ADDL_CHARGE <> 0																--#01	

	DELETE FROM #ap_order_line
END

SELECT * FROM #order_ap

END
