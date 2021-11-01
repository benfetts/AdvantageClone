
CREATE PROCEDURE [dbo].[sp_media_dtl_radio] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ======================================================================================
-- MAIN DATA TABLE - MEDIA ORDER DETAIL (Modified 8/7/08 - JR)
-- ======================================================================================
CREATE TABLE #MediaOrderDetail(
	[REC_TYPE]				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	[ORDER_NBR]				int NOT NULL,
	[LINE_NBR]				int NULL,
	[REV_NBR]				smallint NULL,
	[SEQ_NBR]				smallint NULL,
	[MONTH]					smallint NULL,
	[YEAR]					int NULL,
	[INSERT_DATE]			datetime NULL,
	[START_DATE]			datetime NULL,
	[END_DATE]				datetime NULL,
	[DATE_TO_BILL]			datetime NULL,
	[CLOSE_DATE]			datetime NULL,
	[EXT_CLOSE_DATE]		datetime NULL,
	[MATL_CLOSE_DATE]		datetime NULL,
	[EXT_MATL_DATE]			datetime NULL,
	[MAT_COMP]				datetime NULL,
	[SIZE_CODE]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AD_SIZE]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRINT_COLUMNS]			decimal(6,2) NULL,
	[PRINT_INCHES]			decimal(6,2) NULL,
	[PRINT_LINES]			decimal(11,2) NULL,
	[PRODUCTION_SIZE]		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[HEADLINE]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		
	[EDITION_ISSUE]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SECTION]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PLACEMENT_1]			varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PLACEMENT_2]			varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[LOCATION]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MATERIAL]				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,		
	[MATL_NOTES]			varchar(8000) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]			int NULL,
	[JOB_COMPONENT_NBR]		smallint NULL,
	[BILLED_TYPE_FLAG]		smallint NULL, --various sources for different media types
	[LINE_CANCELLED]		smallint NULL,
	[NON_BILL_FLAG]			smallint NULL, --Added 8/7/08 - JR
	[RECONCILE_LINE]		smallint NULL,
	[DO_NOT_BILL]			smallint NULL,
	[EXT_NET_AMT]			decimal(15,2) NULL,
	[NETCHARGES]			decimal(15,2) NULL,
	[DISCOUNTS]				decimal(15,2) NULL,
	[ADDL_CHARGE]			decimal(15,2) NULL,
	[COMM_AMT]				decimal(15,2) NULL,
	[REBATE_AMT]			decimal(15,2) NULL,
	[NON_RESALE_TAX]		decimal(15,2) NULL,
	[STATE_AMT]				decimal(15,2) NULL,
	[COUNTY_AMT]			decimal(15,2) NULL,
	[CITY_AMT]				decimal(15,2) NULL,
	[LINE_TOTAL]			decimal(15,2) NULL,
	[BILLING_AMT]			decimal(15,2) NULL,
	[BILLED_EXT_NET_AMT]	decimal(15,2) NULL,
	[BILLED_NETCHARGES]		decimal(15,2) NULL,
	[BILLED_DISCOUNTS]		decimal(15,2) NULL,
	[BILLED_ADDL_CHARGE]	decimal(15,2) NULL,
	[BILLED_COMM_AMT]		decimal(15,2) NULL,
	[BILLED_REBATE_AMT]		decimal(15,2) NULL,
	[BILLED_NON_RESALE_AMT]	decimal(15,2) NULL,
	[BILLED_STATE_AMT]		decimal(15,2) NULL,
	[BILLED_COUNTY_AMT]		decimal(15,2) NULL,
	[BILLED_CITY_AMT]		decimal(15,2) NULL,
	[BILLED_BILLING_AMT]	decimal(15,2) NULL,
	[AR_INV_NBR]			int NULL,
	[AR_SEQ]				tinyint NULL,
	[AR_TYPE]				varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_GLEXACT]			int NULL,
	[AR_INV_DATE]			datetime NULL,
	[AR_POST_PERIOD]		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AP_NET_AMT]			decimal(15,2) NULL,
	[AP_NETCHARGES]			decimal(15,2) NULL,
	[AP_DISCOUNT_AMT]		decimal(15,2) NULL,
	[AP_ADDL_CHARGE]		decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	[AP_COMM_AMT]			decimal(15,2) NULL,
	[AP_REBATE_AMT]			decimal(15,2) NULL,
	[AP_VENDOR_TAX]			decimal(15,2) NULL,
	[AP_STATE_TAX]			decimal(15,2) NULL,
	[AP_COUNTY_TAX]			decimal(15,2) NULL,
	[AP_CITY_TAX]			decimal(15,2) NULL,
	[AP_LINE_TOTAL]			decimal(15,2) NULL,		
	[AP_INV_VCHR]			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AP_GLEXACT]			int NULL,
	[AP_INV_DATE]			datetime NULL,
	[AP_POST_PERIOD]		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ==========================================================
-- SECONDARY TABLES
-- ==========================================================
-- Table #media_orders (filtered by @user_code JP 9/4/08)
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL)
INSERT INTO #media_orders
SELECT
	[USER_ID],
	ORDER_NBR
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)

-- SELECT * FROM #media_orders

-- ==========================================================
-- Table DtlMaxSeq
CREATE TABLE #DtlMaxSeq(
	[ORDER_NBR] int NULL,
	[LINE_NBR] smallint NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL)

INSERT INTO #DtlMaxSeq
SELECT d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR)
FROM dbo.RADIO_DETAIL1 AS d
WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.RADIO_DETAIL1 AS d2
	WHERE d.ORDER_NBR = d2.ORDER_NBR
	AND d.LINE_NBR = d2.LINE_NBR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR

-- SELECT * FROM #DtlMaxSeq

-- ==========================================================
-- Table MaxSeq
CREATE TABLE #MaxSeq(
	[ORDER_NBR] int NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL)

INSERT INTO #MaxSeq
SELECT d.ORDER_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR)
FROM #DtlMaxSeq d
WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM #DtlMaxSeq AS d2
	WHERE d.ORDER_NBR = d2.ORDER_NBR)
GROUP BY d.ORDER_NBR, d.REV_NBR

-- SELECT * FROM #MaxSeq

-- ==========================================================
-- Table MEDIA AMTS
CREATE TABLE #MediaAmts ( 
	ORDER_NBR						int NULL, 
	LINE_NBR						smallint NULL, 
	REV_NBR							smallint NULL, 
	SEQ_NBR							smallint NULL, 
	LINE_NET						decimal(15,2) NULL, 
	COMM_AMT						decimal(15,2) NULL, 
	REBATE_AMT						decimal(15,2) NULL, 
	LINE_DISC						decimal(15,2) NULL, 
	VENDOR_TAX						decimal(15,2) NULL, 
	STATE_TAX						decimal(15,2) NULL, 
	COUNTY_TAX						decimal(15,2) NULL, 
	CITY_TAX						decimal(15,2) NULL, 
	SPOTS							smallint NULL, 
	BILL_AMT						decimal(15,2) NULL, 
	AR_INV_NBR						int NULL, 
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	AR_INV_SEQ						smallint NULL, 
	[MONTH]							smallint NULL, --Changed to store smallint from view 10/10/08 JP
	[YEAR]							int NULL, 
	BILLING_USER					varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	MEDIA_TYPE						varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	GLEXACT							int NULL, 
	RECONCILE_LINE					smallint NULL, 
	DO_NOT_BILL						smallint NULL,  
	BILL_TYPE_FLAG					smallint NULL,
	LINE_CANCELLED					smallint NULL)

INSERT INTO #MediaAmts
SELECT 
	d.ORDER_NBR, 
	d.LINE_NBR, 
	d.REV_NBR, 
	d.SEQ_NBR, 
	d.LINE_NET, 
	d.COMM_AMT, 
	d.REBATE_AMT, 
	d.DISCOUNT, 
	d.VENDOR_TAX, 
	d.STATE_TAX, 
	d.COUNTY_TAX, 
	d.CITY_TAX, 
	d.SPOTS, 
	d.BILLING_AMT, 
	d.AR_INV_NBR, 
	d.AR_TYPE, 
	d.AR_INV_SEQ, 
	d.MONTH_IND, 
	d.BRDCAST_YEAR, 
	d.BILLING_USER, 
	'RADIO', 
	g.GLEXACT, 
	d.RECONCILE_LINE, 
	d.DO_NOT_BILL,
	h.BILL_TYPE_FLAG,
	d.LINE_CANCELLED
FROM dbo.V_RADIO_DETAIL1 AS d 
JOIN #media_orders AS rd
	ON (d.ORDER_NBR = rd.ORDER_NBR) 
INNER JOIN dbo.V_RADIO_GL AS g 
	ON (d.ORDER_NBR = g.ORDER_NBR) 
		AND (d.REV_NBR = g.REV_NBR) 
		AND (d.LINE_NBR = g.LINE_NBR) 
		AND (d.SEQ_NBR = g.SEQ_NBR) 
		AND (d.BRDCAST_YEAR = g.BRDCAST_YEAR)
		AND (d.MONTH_IND = g.MONTH_IND)
INNER JOIN dbo.RADIO_HEADER AS h
	ON (d.ORDER_NBR = h.ORDER_NBR)
		AND (d.REV_NBR = h.REV_NBR)

-- SELECT * FROM #MediaAmts

-- ==========================================================
-- Table #BrdcastNCYrMo (Used to assign unbilled broadcast NC month/year)
CREATE TABLE #BrdcastNCYrMo (
	[ORDER_NBR]		int NULL,
	[LINE_NBR]		int NULL,
	[REV_NBR]		smallint NULL,
	[SEQ_NBR]		smallint NULL,
	[YEAR]			int NULL,
	[MONTH]			smallint NULL)

INSERT INTO #BrdcastNCYrMo
SELECT ma.ORDER_NBR,
	ma.LINE_NBR,
	ma.REV_NBR,
	ma.SEQ_NBR,
	ma.[YEAR],
	MIN(ma.[MONTH])
FROM #MediaAmts AS ma
WHERE ma.BILL_AMT <> 0
AND ma.[YEAR] = (SELECT MIN(ma2.[YEAR]) FROM #MediaAmts AS ma2
		WHERE ma.ORDER_NBR = ma2.ORDER_NBR
		AND ma.LINE_NBR = ma2.LINE_NBR
		AND ma.REV_NBR = ma2.REV_NBR
		AND ma.SEQ_NBR = ma2.SEQ_NBR
		AND [MONTH] = ma2.[MONTH]
		AND ma2.BILL_AMT <> 0)
GROUP BY ma.ORDER_NBR, ma.LINE_NBR, ma.REV_NBR, ma.SEQ_NBR, ma.[YEAR]

-- SELECT * FROM #BrdcastNCYrMo

-- ==========================================================
-- Table #ARInvNCYrMo (Used to assign billed broadcast NC month/year)
CREATE TABLE #ARInvNCYrMo(
	[ORDER_NBR]		int NULL,
	[LINE_NBR]		int NULL,
	[REV_NBR]		smallint NULL,
	[SEQ_NBR]		smallint NULL,
	[YEAR]			int NULL,
	[MONTH]			smallint NULL,
	[AR_INV_NBR]	int NULL)

INSERT INTO #ARInvNCYrMo
SELECT ma.ORDER_NBR,
	ma.LINE_NBR,
	ma.REV_NBR,
	ma.SEQ_NBR,
	ma.[YEAR],
	MIN(ma.[MONTH]),
	ma.AR_INV_NBR
FROM #MediaAmts AS ma
WHERE ma.AR_INV_NBR IS NOT NULL
AND ma.[YEAR] = (SELECT MIN(ma2.[YEAR]) FROM #MediaAmts AS ma2
		WHERE ma.ORDER_NBR = ma2.ORDER_NBR
		AND ma.LINE_NBR = ma2.LINE_NBR
		AND ma.REV_NBR = ma2.REV_NBR
		AND ma.SEQ_NBR = ma2.SEQ_NBR
		AND [MONTH] = ma2.[MONTH]
		AND ma2.AR_INV_NBR IS NOT NULL)
GROUP BY ma.ORDER_NBR, ma.LINE_NBR, ma.REV_NBR, ma.SEQ_NBR, ma.[YEAR], ma.AR_INV_NBR

-- SELECT * FROM #ARInvNCYrMo

-- ==========================================================
-- Table #ARInfo
CREATE TABLE #ARInfo(
	[AR_INV_NBR] int NULL,
	[AR_TYPE] varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[GLEXACT] int NULL,
	[AR_INV_DATE] datetime NULL,
	[AR_POST_PERIOD] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

INSERT INTO #ARInfo
SELECT ar.AR_INV_NBR,
	ar.AR_TYPE,
	ar.GLEXACT,
	ar.AR_INV_DATE,
	ar.AR_POST_PERIOD
FROM dbo.ACCT_REC AS ar
GROUP BY ar.AR_INV_NBR, ar.AR_TYPE, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD

-- SELECT * FROM #ARInfo

-- ==========================================================
-- Table DETAIL MAX DATES
CREATE TABLE #DetailMaxDates (
	[ORDER_NBR]			int NULL,
	[LINE_NBR]			int NULL,
	[REV_NBR]			smallint NULL, --Active Rev
	[SEQ_NBR]			smallint NULL, --Max Seq of Active Rev
	[MONTH]				smallint NULL,
	[YEAR]				int NULL,
	[INSERT_DATE]		datetime NULL,
	[START_DATE]		datetime NULL,
	[END_DATE]			datetime NULL,
	[DATE_TO_BILL]		datetime NULL,
	[CLOSE_DATE]		datetime NULL,
	[EXT_CLOSE_DATE]	datetime NULL,
	[MATL_CLOSE_DATE]	datetime NULL,
	[EXT_MATL_DATE]		datetime NULL,
	[MAT_COMP]			datetime NULL,
	[SIZE_CODE]			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AD_SIZE]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PRINT_COLUMNS]		decimal(6,2), --Newspaper detail only
	[PRINT_INCHES]		decimal(6,2), --Newspaper detail only
	[PRINT_LINES]		decimal(11,2), --Newspaper detail only
	[PRODUCTION_SIZE]	varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[HEADLINE]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[EDITION_ISSUE]		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[SECTION]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[PLACEMENT_1]		varchar(256) COLLATE SQL_Latin1_General_CP1_CS_AS, --Internet detail only
	[PLACEMENT_2]		varchar(160) COLLATE SQL_Latin1_General_CP1_CS_AS, --Internet detail only
	[LOCATION]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, --Outdoor detail only
	[MATERIAL]			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[MATL_NOTES]		varchar(8000) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]		int NULL,
	[JOB_COMPONENT_NBR]	smallint NULL,
	[BILLED_TYPE_FLAG]	smallint NULL,
	[LINE_CANCELLED]	smallint NULL,
	[NON_BILL_FLAG]		smallint NULL) --Added 8/7/08 - JR

INSERT INTO #DetailMaxDates (ORDER_NBR, [MONTH], [YEAR], CLOSE_DATE, EXT_CLOSE_DATE, MATL_CLOSE_DATE, EXT_MATL_DATE,  
	MAT_COMP, JOB_NUMBER, JOB_COMPONENT_NBR, BILLED_TYPE_FLAG, LINE_CANCELLED, NON_BILL_FLAG)
SELECT ma.ORDER_NBR,
	ma.[MONTH],
	ma.[YEAR],
	MIN(d.CLOSE_DATE),
	MIN(d.EXT_CLOSE_DATE),
	MIN(d.MATL_CLOSE_DATE),
	MIN(d.EXT_MATL_DATE),
	MIN(d.MAT_COMP),
	MIN(d.JOB_NUMBER),
	MIN(d.JOB_COMPONENT_NBR),
	MIN(ma.BILL_TYPE_FLAG),
	MIN(ma.LINE_CANCELLED),
	0 --NON_BILL_FLAG	Added 8/7/08 - JR	
FROM #MediaAmts AS ma
JOIN #DtlMaxSeq AS ms
	ON ms.ORDER_NBR = ma.ORDER_NBR
	AND ms.LINE_NBR = ma.LINE_NBR
	AND ms.REV_NBR = ma.REV_NBR
	AND ms.SEQ_NBR = ma.SEQ_NBR
JOIN dbo.RADIO_DETAIL1 AS d
	ON ma.ORDER_NBR = d.ORDER_NBR
	AND ma.LINE_NBR = d.LINE_NBR
	AND ma.REV_NBR = d.REV_NBR
	AND ma.SEQ_NBR = d.SEQ_NBR
	AND ma.[YEAR] = d.BRDCAST_YEAR
GROUP BY ma.ORDER_NBR, ma.[MONTH], ma.[YEAR]

-- SELECT * FROM #DetailMaxDates

-- ==========================================================
-- Table #MediaOrderDetailTemp (summarizes data from #MediaAmts
-- without linking to #DetailMaxDates and #MaxRev. Links are one-time at end of routine
-- after sums are computed, so grouping on the add'l fields are not needed.
CREATE TABLE #MediaOrderDetailTemp(
	[REC_TYPE]				varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 		
	[ORDER_NBR]				int NOT NULL,
	[MONTH]					smallint NULL,
	[YEAR]					int NULL,
	[LINE_CANCELLED]		smallint NULL,
	[NON_BILL_FLAG]			smallint NULL, --Added 8/7/08 - JR
	[RECONCILE_LINE]		smallint NULL,
	[DO_NOT_BILL]			smallint NULL,
	[EXT_NET_AMT]			decimal(15,2) NULL,
	[NETCHARGES]			decimal(15,2) NULL,
	[DISCOUNTS]				decimal(15,2) NULL,
	[ADDL_CHARGE]			decimal(15,2) NULL,
	[COMM_AMT]				decimal(15,2) NULL,
	[REBATE_AMT]			decimal(15,2) NULL,
	[NON_RESALE_TAX]		decimal(15,2) NULL,
	[STATE_AMT]				decimal(15,2) NULL,
	[COUNTY_AMT]			decimal(15,2) NULL,
	[CITY_AMT]				decimal(15,2) NULL,
	[LINE_TOTAL]			decimal(15,2) NULL,
	[BILLING_AMT]			decimal(15,2) NULL,
	[BILLED_EXT_NET_AMT]	decimal(15,2) NULL,
	[BILLED_NETCHARGES]		decimal(15,2) NULL,
	[BILLED_DISCOUNTS]		decimal(15,2) NULL,
	[BILLED_ADDL_CHARGE]	decimal(15,2) NULL,
	[BILLED_COMM_AMT]		decimal(15,2) NULL,
	[BILLED_REBATE_AMT]		decimal(15,2) NULL,
	[BILLED_NON_RESALE_AMT]	decimal(15,2) NULL,
	[BILLED_STATE_AMT]		decimal(15,2) NULL,
	[BILLED_COUNTY_AMT]		decimal(15,2) NULL,
	[BILLED_CITY_AMT]		decimal(15,2) NULL,
	[BILLED_BILLING_AMT]	decimal(15,2) NULL,
	[AR_INV_NBR]			int NULL,
	[AR_SEQ]				tinyint NULL,
	[AR_TYPE]				varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_GLEXACT]			int NULL,
	[AR_INV_DATE]			datetime NULL,
	[AR_POST_PERIOD]		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AP_NET_AMT]			decimal(15,2) NULL,
	[AP_NETCHARGES]			decimal(15,2) NULL,
	[AP_DISCOUNT_AMT]		decimal(15,2) NULL,
	[AP_ADDL_CHARGE]		decimal(15,2) NULL, --order addl chg where a/p exists for a/p bill amt
	[AP_COMM_AMT]			decimal(15,2) NULL,
	[AP_REBATE_AMT]			decimal(15,2) NULL,
	[AP_VENDOR_TAX]			decimal(15,2) NULL,
	[AP_STATE_TAX]			decimal(15,2) NULL,
	[AP_COUNTY_TAX]			decimal(15,2) NULL,
	[AP_CITY_TAX]			decimal(15,2) NULL,
	[AP_LINE_TOTAL]			decimal(15,2) NULL,		
	[AP_INV_VCHR]			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AP_GLEXACT]			int NULL,
	[AP_INV_DATE]			datetime NULL,
	[AP_POST_PERIOD]		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS)

-- ORDERED AMOUNTS
-- ==========================================================
-- (1a) Order Amounts
INSERT INTO #MediaOrderDetailTemp
SELECT 'ORDER', --REC_TYPE
	ma.ORDER_NBR,
	ma.[MONTH],
	ma.[YEAR],
	0, --md.LINE_CANCELLED,
	0, --NON_BILL_FLAG	Added 8/7/08 - JR
	ma.RECONCILE_LINE,
	ma.DO_NOT_BILL,
	SUM(ISNULL(ma.LINE_NET,0)),
	0, --NETCHARGES not in temp table
	SUM(ISNULL(ma.LINE_DISC,0)),
	0, --ADDL CHARGE
	SUM(ISNULL(ma.COMM_AMT,0)),
	SUM(ISNULL(ma.REBATE_AMT,0)),
	SUM(ISNULL(ma.VENDOR_TAX,0)),
	SUM(ISNULL(ma.STATE_TAX,0)),
	SUM(ISNULL(ma.COUNTY_TAX,0)),
	SUM(ISNULL(ma.CITY_TAX,0)),
	SUM((ISNULL(ma.LINE_NET,0)+ISNULL(ma.LINE_DISC,0)+ISNULL(ma.COMM_AMT,0)+ISNULL(ma.REBATE_AMT,0)+
		ISNULL(ma.VENDOR_TAX,0)+ISNULL(ma.STATE_TAX,0)+ISNULL(ma.COUNTY_TAX,0)+ISNULL(ma.CITY_TAX,0))) AS [LINE_TOTAL],
	SUM(ISNULL(ma.BILL_AMT,0)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL
FROM #MediaAmts AS ma
GROUP BY ma.ORDER_NBR, ma.[MONTH], ma.[YEAR], ma.RECONCILE_LINE, ma.DO_NOT_BILL

-- (1b) Order Amounts - All Net Charges 
-- All netcharges are calculated on one pass by links to both #BrdcastNCYrMo and #ARInvNCYrMo
-- and testing the value of h.BILL_TYPE_FLAG for BILLING_AMT
INSERT INTO #MediaOrderDetailTemp
SELECT 'ORDER', --REC_TYPE
	d.ORDER_NBR,
	CASE ISNULL(d.AR_INV_NBR,0)
		WHEN 0 THEN my.[MONTH]
		ELSE my2.[MONTH]
	END,
	CASE ISNULL(d.AR_INV_NBR,0)
		WHEN 0 THEN my.[YEAR]
		ELSE my2.[YEAR]
	END,
	0, --MIN(d.LINE_CANCELLED),
	0, --NON_BILL_FLAG	Added 8/7/08 - JR
	NULL,
	NULL,
	0, --LINE_NET
	SUM(ISNULL(d.NETCHARGES,0)),
	0, --LINE_DISC
	0, --ADDL CHARGE
	0, --COMM_AMT
	0, --REBATE_AMT
	SUM(ISNULL(d.VENDOR_TAX_NC,0)),
	SUM(ISNULL(d.STATE_TAX_NC,0)),
	SUM(ISNULL(d.COUNTY_TAX_NC,0)),
	SUM(ISNULL(d.CITY_TAX_NC,0)),
	SUM((ISNULL(d.NETCHARGES,0)+ISNULL(d.VENDOR_TAX_NC,0)+ISNULL(d.STATE_TAX_NC,0)+ISNULL(d.COUNTY_TAX_NC,0)+
		ISNULL(d.CITY_TAX_NC,0))) AS [LINE_TOTAL],
	CASE h.BILL_TYPE_FLAG
		WHEN 1 THEN 0
		ELSE SUM((ISNULL(d.NETCHARGES,0)+ISNULL(d.VENDOR_TAX_NC,0)+ISNULL(d.STATE_TAX_NC,0)+ISNULL(d.COUNTY_TAX_NC,0)+ISNULL(d.CITY_TAX_NC,0)))
	END,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL
FROM RADIO_DETAIL1 AS d
JOIN #media_orders AS rd
	ON (d.ORDER_NBR = rd.ORDER_NBR)
JOIN #MaxSeq ms
	ON rd.ORDER_NBR = ms.ORDER_NBR  
JOIN RADIO_HEADER AS h
	ON h.ORDER_NBR = ms.ORDER_NBR
	AND h.REV_NBR = ms.REV_NBR
LEFT JOIN #BrdcastNCYrMo AS my
	ON d.ORDER_NBR = my.ORDER_NBR
	AND d.LINE_NBR = my.LINE_NBR
	AND d.REV_NBR = my.REV_NBR
	AND d.SEQ_NBR = my.SEQ_NBR
	AND d.BRDCAST_YEAR = my.[YEAR]
LEFT JOIN #ARInvNCYrMo AS my2
	ON d.ORDER_NBR = my2.ORDER_NBR
	AND d.LINE_NBR = my2.LINE_NBR
	AND d.REV_NBR = my2.REV_NBR
	AND d.SEQ_NBR = my2.SEQ_NBR
	AND d.BRDCAST_YEAR = my2.[YEAR]
	AND d.AR_INV_NBR = my2.AR_INV_NBR
WHERE ([LINE_TOTAL]<=-0.01 OR [LINE_TOTAL]>=0.01)
GROUP BY d.ORDER_NBR, my.[YEAR], my.[MONTH], my2.[YEAR], my2.[MONTH], h.BILL_TYPE_FLAG, d.AR_INV_NBR

-- BILLED AMOUNTS
-- ======================================================
-- (2a) Billed Amounts
INSERT INTO #MediaOrderDetailTemp
SELECT 'BILLING', --REC_TYPE
	ma.ORDER_NBR,
	ma.[MONTH],
	ma.[YEAR],
	0, --ma.LINE_CANCELLED,
	0, --NON_BILL_FLAG	Added 8/7/08 - JR
	ma.RECONCILE_LINE,
	ma.DO_NOT_BILL,
	0, --LINE_NET
	0, --NETCHARGES not in temp table
	0, --LINE_DISC
	0, --ADDL CHARGE
	0, --COMM_AMT
	0, --REBATE_AMT
	0, --VENDOR_TAX
	0, --STATE_TAX
	0, --COUNTY_TAX
	0, --CITY_TAX
	0, --LINE_TOTAL
	0, --BILL_AMT
	SUM(ISNULL(ma.LINE_NET,0)),
	0, --NETCHARGES not in temp table
	SUM(ISNULL(ma.LINE_DISC,0)),
	0, --ADDL CHARGE
	SUM(ISNULL(ma.COMM_AMT,0)),
	SUM(ISNULL(ma.REBATE_AMT,0)),
	SUM(ISNULL(ma.VENDOR_TAX,0)),
	SUM(ISNULL(ma.STATE_TAX,0)),
	SUM(ISNULL(ma.COUNTY_TAX,0)),
	SUM(ISNULL(ma.CITY_TAX,0)),
	SUM(ISNULL(ma.BILL_AMT,0)),
	ma.AR_INV_NBR,
	ma.AR_INV_SEQ,
	ma.AR_TYPE,
	ar.GLEXACT,
	ar.AR_INV_DATE,
	ar.AR_POST_PERIOD,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL
FROM #MediaAmts AS ma
JOIN #ARInfo AS ar
	ON ma.AR_INV_NBR = ar.AR_INV_NBR
	AND ma.AR_TYPE = ar.AR_TYPE
GROUP BY ma.ORDER_NBR, ma.[MONTH], ma.[YEAR], ma.RECONCILE_LINE, ma.DO_NOT_BILL, ma.AR_INV_NBR, ma.AR_INV_SEQ, 
	ma.AR_TYPE, ar.GLEXACT, ar.AR_INV_DATE, ar.AR_POST_PERIOD

-- (2b) Billed Amounts - All Net Charges
-- All netcharges are calculated on one pass by testing the value of h.BILL_TYPE_FLAG for BILLING_AMT
INSERT INTO #MediaOrderDetailTemp
SELECT 'BILLING', --REC_TYPE
	d.ORDER_NBR,
	my.[MONTH],
	my.[YEAR],
	MIN(d.LINE_CANCELLED),
	0, --NON_BILL_FLAG	Added 8/7/08 - JR
	NULL,
	NULL,
	0, --LINE_NET
	0, --NETCHARGES
	0, --LINE_DISC
	0, --ADDL CHARGE
	0, --COMM_AMT
	0, --REBATE_AMT
	0, --VENDOR_TAX
	0, --STATE_TAX
	0, --COUNTY_TAX
	0, --CITY_TAX
	0, --LINE_TOTAL
	0, --BILL_AMT
	0, --BILLED_EXT_NET_AMT
	SUM(ISNULL(d.NETCHARGES,0)) AS NETCHARGES,
	0,
	0,
	0,
	0,
	SUM(ISNULL(d.VENDOR_TAX_NC,0)) AS VENDOR_TAX,
	SUM(ISNULL(d.STATE_TAX_NC,0)) AS STATE_TAX,
	SUM(ISNULL(d.COUNTY_TAX_NC,0)) AS COUNTY_TAX,
	SUM(ISNULL(d.CITY_TAX_NC,0)) AS CITY_TAX,
	CASE h.BILL_TYPE_FLAG
		WHEN 1 THEN 0
		ELSE SUM((ISNULL(d.NETCHARGES,0)+ISNULL(d.VENDOR_TAX_NC,0)+ISNULL(d.STATE_TAX_NC,0)+
			ISNULL(d.COUNTY_TAX_NC,0)+ISNULL(d.CITY_TAX_NC,0)))
	END,
	d.AR_INV_NBR,
	d.AR_INV_SEQ,
	d.AR_TYPE,
	ar.GLEXACT,
	ar.AR_INV_DATE,
	ar.AR_POST_PERIOD,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL
FROM RADIO_DETAIL1 AS d
JOIN #MaxSeq ms
	ON d.ORDER_NBR = ms.ORDER_NBR
JOIN RADIO_HEADER AS h
	ON h.ORDER_NBR = ms.ORDER_NBR
	AND h.REV_NBR = ms.REV_NBR
JOIN #ARInvNCYrMo AS my
	ON d.ORDER_NBR = my.ORDER_NBR
	AND d.LINE_NBR = my.LINE_NBR
	AND d.REV_NBR = my.REV_NBR
	AND d.SEQ_NBR = my.SEQ_NBR
	AND d.BRDCAST_YEAR = my.[YEAR]
	AND d.AR_INV_NBR = my.AR_INV_NBR
JOIN #ARInfo AS ar
	ON d.AR_INV_NBR = ar.AR_INV_NBR
	AND d.AR_TYPE = ar.AR_TYPE
WHERE ([NETCHARGES]+[VENDOR_TAX]+[STATE_TAX]+[COUNTY_TAX]+[CITY_TAX])<>0
GROUP BY d.ORDER_NBR, my.[YEAR], my.[MONTH], d.AR_INV_NBR, d.AR_INV_SEQ, d.AR_TYPE, ar.GLEXACT, 
	ar.AR_INV_DATE, ar.AR_POST_PERIOD, h.BILL_TYPE_FLAG

-- ACCOUNTS PAYABLE AMOUNTS
-- ======================================================
-- A/P Amounts
INSERT INTO #MediaOrderDetailTemp
SELECT 'AP', --REC_TYPE
	d.ORDER_NBR,
	md.[MONTH], --dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH),
	md.[YEAR], --d.BRDCAST_YEAR,
	0, --md.LINE_CANCELLED,
	0, --NON_BILL_FLAG	Added 8/7/08 - JR
	d.RECONCILE_FLAG,
	0,
	0, --LINE_NET
	0, --NETCHARGES not in temp table
	0, --LINE_DISC
	0, --ADDL CHARGE
	0, --COMM_AMT
	0, --REBATE_AMT
	0, --VENDOR_TAX
	0, --STATE_TAX
	0, --COUNTY_TAX
	0, --CITY_TAX
	0, --LINE_TOTAL
	0, --BILL_AMT
	0,
	0, --NETCHARGES not in temp table
	0,
	0, --ADDL CHARGE
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
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
	h.AP_INV_VCHR,
	d.GLEXACT,
	h.AP_INV_DATE,
	d.POST_PERIOD
FROM dbo.AP_RADIO AS d
JOIN dbo.AP_HEADER AS h
	ON d.AP_ID = h.AP_ID
	AND d.AP_SEQ = h.AP_SEQ
JOIN #MaxSeq AS ms
	ON d.ORDER_NBR = ms.ORDER_NBR
JOIN #DetailMaxDates AS md
	ON d.ORDER_NBR = md.ORDER_NBR
	AND dbo.fn_month_abbr_nbr(d.BRDCAST_MONTH) = md.[MONTH]
	AND d.BRDCAST_YEAR = md.[YEAR]
WHERE (h.DELETE_FLAG IS NULL OR h.DELETE_FLAG = 0)
	AND (d.DELETE_FLAG IS NULL OR d.DELETE_FLAG = 0)
	--AND (d.RECONCILE_FLAG IS NULL OR d.RECONCILE_FLAG = 0)	--Deleted 10/24/08 JP
GROUP BY d.ORDER_NBR, d.RECONCILE_FLAG, h.AP_INV_VCHR, d.GLEXACT, h.AP_INV_DATE, d.POST_PERIOD, md.[MONTH], md.[YEAR]

-- SELECT * FROM #MediaOrderDetailTemp

-- LINK TO #DetailMaxDates AND #MaxSeq TO POPULATE REMAINING COLUMNS
-- ==========================================================
INSERT INTO #MediaOrderDetail
SELECT d.REC_TYPE,
	d.ORDER_NBR,
	0, --LINE_NBR
	ms.REV_NBR,
	ms.SEQ_NBR,
	CASE d.REC_TYPE
		WHEN 'ORDER' THEN d.[MONTH]
		ELSE md.[MONTH]
	END,
	CASE d.REC_TYPE
		WHEN 'ORDER' THEN d.[YEAR]
		ELSE md.[YEAR]
	END,
	md.INSERT_DATE,
	md.START_DATE,
	md.END_DATE,
	md.DATE_TO_BILL,
	md.CLOSE_DATE,
	md.EXT_CLOSE_DATE,
	md.MATL_CLOSE_DATE,
	md.EXT_MATL_DATE,
	md.MAT_COMP,
	md.SIZE_CODE,
	md.AD_SIZE,
	md.PRINT_COLUMNS,
	md.PRINT_INCHES,
	md.PRINT_LINES,
	md.PRODUCTION_SIZE,
	md.HEADLINE,
	md.EDITION_ISSUE,
	md.SECTION,
	md.PLACEMENT_1,
	md.PLACEMENT_2,
	md.LOCATION,
	md.MATERIAL,
	md.MATL_NOTES,
	md.JOB_NUMBER,
	md.JOB_COMPONENT_NBR,
	md.BILLED_TYPE_FLAG,
	md.LINE_CANCELLED,
	d.NON_BILL_FLAG,
	d.RECONCILE_LINE,
	d.DO_NOT_BILL,
	d.EXT_NET_AMT,
	d.NETCHARGES,
	d.DISCOUNTS,
	d.ADDL_CHARGE,
	d.COMM_AMT,
	d.REBATE_AMT,
	d.NON_RESALE_TAX,
	d.STATE_AMT,
	d.COUNTY_AMT,
	d.CITY_AMT,
	d.LINE_TOTAL,
	d.BILLING_AMT,
	d.BILLED_EXT_NET_AMT,
	d.BILLED_NETCHARGES,
	d.BILLED_DISCOUNTS,
	d.BILLED_ADDL_CHARGE,
	d.BILLED_COMM_AMT,
	d.BILLED_REBATE_AMT,
	d.BILLED_NON_RESALE_AMT,
	d.BILLED_STATE_AMT,
	d.BILLED_COUNTY_AMT,
	d.BILLED_CITY_AMT,
	d.BILLED_BILLING_AMT,
	d.AR_INV_NBR,
	d.AR_SEQ,
	d.AR_TYPE,
	d.AR_GLEXACT,
	d.AR_INV_DATE,
	d.AR_POST_PERIOD,
	d.AP_NET_AMT,
	d.AP_NETCHARGES,
	d.AP_DISCOUNT_AMT,
	d.AP_ADDL_CHARGE,
	d.AP_COMM_AMT,
	d.AP_REBATE_AMT,
	d.AP_VENDOR_TAX,
	d.AP_STATE_TAX,
	d.AP_COUNTY_TAX,
	d.AP_CITY_TAX,
	d.AP_LINE_TOTAL,
	d.AP_INV_VCHR,
	d.AP_GLEXACT,
	d.AP_INV_DATE,
	d.AP_POST_PERIOD
FROM #MediaOrderDetailTemp AS d
JOIN #MaxSeq AS ms
	ON d.ORDER_NBR = ms.ORDER_NBR
JOIN #DetailMaxDates AS md
	ON d.ORDER_NBR = md.ORDER_NBR
	AND d.[MONTH] = md.[MONTH]
	AND d.[YEAR] = md.[YEAR]

SELECT * FROM #MediaOrderDetail

END
