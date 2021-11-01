--insert the next (3) statements at the top of the script while debugging
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_bcst_amounts_ap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_media1_order_bcst_amounts_ap]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_amounts_ap] ( @user_code varchar(100) )

-- Stored procedure to extract broadcast media ACCOUNTS PAYABLE amounts
-- #00 05/27/09 - initial release
-- #01 12/03/10 - deleted "AND (d.RECONCILE_FLAG IS NULL OR d.RECONCILE_FLAG = 0)" from where clauses per JR #213343
-- #02 12/11/12 - added TOTAL_SPOTS
-- #04 12/17/14 - added column AP_ID

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
	AP_LINE_TOTAL					decimal(15,2) NULL,	
	AP_BILLING_AMT					decimal(15,2) NULL,		
	AP_INV_VCHR						varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	AP_GLEXACT						int NULL,
	AP_INV_DATE						datetime NULL,
	AP_PAYMENT_HOLD					smallint NULL,
	AP_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TOTAL_SPOTS						smallint,
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

-- ===========================================================================
-- EXTRACTION ROUTINES
-- ===========================================================================
-- Radio A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'R' AS ORDER_TYPE,
		d.ORDER_NBR,
		0,	--LINE_NBR
		NULL AS REV_NBR,	--Max rev for order
		NULL AS SEQ_NBR,	--Max seq for order
		dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH),
		d.BRDCAST_YEAR,
		SUM(ISNULL(d.EXT_NET_AMT,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.DISC_AMT,0)),
		0, --ADDL CHARGE
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(ISNULL(d.LINE_TOTAL,0)),
--		0 AS AP_BILLING_AMT,
		CASE h2.BILL_TYPE_FLAG
			WHEN 3 THEN SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.NETCHARGES,0))
			ELSE SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0) + ISNULL(d.NETCHARGES,0))
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		SUM(ISNULL(d.TOTAL_SPOTS,0)),
		d.AP_ID
	FROM dbo.AP_RADIO AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND d.AP_SEQ = h.AP_SEQ
	JOIN dbo.RADIO_HEADER AS h2
		ON o.ORDER_NBR = h2.ORDER_NBR
	WHERE (h.DELETE_FLAG IS NULL OR h.DELETE_FLAG = 0)
		AND (d.DELETE_FLAG IS NULL OR d.DELETE_FLAG = 0)
		--AND (d.RECONCILE_FLAG IS NULL OR d.RECONCILE_FLAG = 0)		-- JP 12/3/10
		AND (h2.REV_NBR = (SELECT MAX(h3.REV_NBR) FROM dbo.RADIO_HEADER AS h3 WHERE h2.ORDER_NBR = h3.ORDER_NBR))
	GROUP BY d.ORDER_NBR, dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH), d.BRDCAST_YEAR, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, h2.BILL_TYPE_FLAG, d.AP_ID
END

-- Television A/P Amounts
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #order_ap
		SELECT 'AP' AS REC_TYPE, 
		'T' AS ORDER_TYPE,
		d.ORDER_NBR,
		0, --LINE_NBR
		NULL AS REV_NBR,
		NULL AS SEQ_NBR,
		dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH),
		d.BRDCAST_YEAR,
		SUM(ISNULL(d.EXT_NET_AMT,0)),
		SUM(ISNULL(d.NETCHARGES,0)),
		SUM(ISNULL(d.DISC_AMT,0)),
		0, --ADDL CHARGE
		SUM(ISNULL(d.COMM_AMT,0)),
		SUM(ISNULL(d.REBATE_AMT,0)),
		SUM(ISNULL(d.VENDOR_TAX,0)),
		SUM(ISNULL(d.STATE_TAX,0)),
		SUM(ISNULL(d.COUNTY_TAX,0)),
		SUM(ISNULL(d.CITY_TAX,0)),
		SUM(ISNULL(d.LINE_TOTAL,0)),
		CASE h2.BILL_TYPE_FLAG
			WHEN 3 THEN SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.NETCHARGES,0))
			ELSE SUM(ISNULL(d.LINE_TOTAL,0) - ISNULL(d.COMM_AMT,0) + ISNULL(d.REBATE_AMT,0) + ISNULL(d.NETCHARGES,0))
		END AS AP_BILLING_AMT,
		h.AP_INV_VCHR,
		d.GLEXACT,
		h.AP_INV_DATE,
		h.PAYMENT_HOLD,
		d.POST_PERIOD,
		SUM(ISNULL(d.TOTAL_SPOTS,0)),
		d.AP_ID
	FROM dbo.AP_TV AS d
	JOIN #media_orders AS o
		ON d.ORDER_NBR = o.ORDER_NBR
	JOIN dbo.AP_HEADER AS h
		ON d.AP_ID = h.AP_ID
		AND d.AP_SEQ = h.AP_SEQ
	JOIN dbo.TV_HEADER AS h2
		ON o.ORDER_NBR = h2.ORDER_NBR
	WHERE (h.DELETE_FLAG IS NULL OR h.DELETE_FLAG = 0)
		AND (d.DELETE_FLAG IS NULL OR d.DELETE_FLAG = 0)
		--AND (d.RECONCILE_FLAG IS NULL OR d.RECONCILE_FLAG = 0)		-- JP 12/3/10
		AND (h2.REV_NBR = (SELECT MAX(h3.REV_NBR) FROM dbo.TV_HEADER AS h3 WHERE h2.ORDER_NBR = h3.ORDER_NBR))
	GROUP BY d.ORDER_NBR, dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH), d.BRDCAST_YEAR, h.AP_INV_VCHR, h.PAYMENT_HOLD, 
		d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, h2.BILL_TYPE_FLAG, d.AP_ID
END

SELECT * FROM #order_ap

END
