
CREATE PROCEDURE [dbo].[advsp_media_order_tv] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- Temp table #media_orders
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
-- Temp table TVOrderDtlFilterMaxSeq
CREATE TABLE #TVOrderDtlFilterMaxSeq(
	[ORDER_NBR] int NULL,
	[LINE_NBR] smallint NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL,
	[BRDCAST_YEAR] smallint NULL)

INSERT INTO #TVOrderDtlFilterMaxSeq
SELECT d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	MAX(d.SEQ_NBR),
	d.BRDCAST_YEAR
FROM #media_orders AS o
INNER JOIN dbo.TV_DETAIL1 AS d
	ON o.ORDER_NBR = d.ORDER_NBR
WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.TV_DETAIL1 AS d2
	WHERE d.ORDER_NBR = d2.ORDER_NBR
	AND d.LINE_NBR = d2.LINE_NBR
	AND d.BRDCAST_YEAR = d2.BRDCAST_YEAR)
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.BRDCAST_YEAR

-- SELECT * FROM #TVOrderDtlFilterMaxSeq

-- ==========================================================
-- Temp table detail_order_amounts
CREATE TABLE #detail_order_amounts(
	ORDER_NBR					int NOT NULL,
	LINE_NBR					int NOT NULL,
	BRDCAST_YEAR				smallint NOT NULL, 
	TOTAL_SPOTS					int NULL,
	EXT_NET_AMT					decimal(15,2) NULL,
	COMM_AMT					decimal(15,2) NULL,
	VENDOR_TAX					decimal(15,2) NULL,
	STATE_TAX					decimal(15,2) NULL,
	COUNTY_TAX					decimal(15,2) NULL,
	CITY_TAX					decimal(15,2) NULL)

INSERT INTO #detail_order_amounts(ORDER_NBR, LINE_NBR, BRDCAST_YEAR, TOTAL_SPOTS, EXT_NET_AMT,
	COMM_AMT, VENDOR_TAX, STATE_TAX, COUNTY_TAX, CITY_TAX)
SELECT d.ORDER_NBR,
	d.LINE_NBR,
	d.BRDCAST_YEAR,
	SUM(d.TOTAL_SPOTS),
	SUM(d.EXT_NET_AMT),
	SUM(d.COMM_AMT),
	SUM(d.VENDOR_TAX),
	SUM(d.STATE_TAX),
	SUM(d.COUNTY_TAX),
	SUM(d.CITY_TAX)
FROM #media_orders AS o
INNER JOIN dbo.TV_DETAIL1 AS d
	ON o.ORDER_NBR = d.ORDER_NBR
GROUP BY d.ORDER_NBR, d.LINE_NBR, d.BRDCAST_YEAR

-- SELECT * FROM #detail_order_amounts

-- ==========================================================
-- Main data query
SELECT h.ORDER_DATE AS OrderDate, 
	h.CREATE_DATE AS CreateDate, 
	h.MEDIA_TYPE AS [Media Type], 
	h.CLIENT_PO AS [Prod Contact], 
	h.BUYER AS Buyer, 
	h.ORDER_NBR AS [IO], 
	h.MARKET_CODE AS Market, 
	d.LINE_NBR AS Line, 
	d.REV_NBR AS Rev, 
	d.BRDCAST_YEAR AS [Year], 
	h.ORDER_DESC AS [Order Desc], 
	h.VN_CODE AS Vendor, 
	h.VR_CODE AS Rep1, 
	h.VR_CODE2 AS Rep2, 
	h.CL_CODE AS Client, 
	h.DIV_CODE AS Division, 
	h.PRD_CODE AS Product, 
	h.FLIGHT_FROM AS FlightFrm, 
	h.FLIGHT_TO AS FlightTo, 
	d.JOB_NUMBER AS [Job Number], 
	d.JOB_COMPONENT_NBR AS [Comp Number], 
	h.NET_GROSS AS [Net/Gross Flg],
	CASE h.[NET_GROSS] 
		WHEN 1 THEN a.[EXT_NET_AMT] + a.[COMM_AMT]
		ELSE a.[EXT_NET_AMT]	--Rate
	END AS Rate,
	CASE h.[NET_GROSS] 
		WHEN 1 THEN d.[GROSS_RATE]
		ELSE d.[NET_RATE]		--UnitRate
	END AS UnitRate, 
	a.VENDOR_TAX AS [Vendor Tax], 
	a.STATE_TAX AS [State Tax], 
	a.COUNTY_TAX AS [County Tax], 
	a.CITY_TAX AS [City Tax], 
	CASE h.[NET_GROSS]
		WHEN 1 THEN ISNULL(a.[COMM_AMT],0)
		ELSE 0 --Commission
	END AS Commission, 
	d2.ORDER_COMMENT AS [Det Order Comment], 
	d2.POSITION_INFO AS [Position], 
	d2.RATE_INFO AS [Rate Info], 
	d2.CLOSE_INFO AS [Close Info], 
	d2.MISC_INFO AS [Misc Info], 
	d2.MATL_NOTES AS [Material Info], 
	h.ORDER_COMMENT AS [Header Comments], 
	a.TOTAL_SPOTS AS Spots, 
	d.LENGTH AS Length, 
	d.LINE_NET_DISC AS LineNetDiscount, 
	ISNULL(d.[NETCHARGES],0) AS NC1, 
	d.MATL_CLOSE_DATE AS MaterialCloseDate, 
	d.START_TIME AS StartTime, 
	d.END_TIME AS EndTime, 
	d.PROGRAMMING AS Programming, 
	h.CMP_IDENTIFIER AS Campaign, 
	d.REMARKS AS Remarks, 
	d.TAG AS Tag, 
	d.CLOSE_DATE AS Close_Date, 
	d.MATL_CLOSE_DATE AS Mat_Close_Date, 
	0 AS NC2, 
	0 AS NC3, 
	0 AS NC4, 
	0 AS NC5, 
	0 AS NC6, 
	0 AS LineGrossDiscount, 
	0 AS NetChargeDiscount, 
	Null AS IOFlightFrm, 
	Null AS IOFlightTo,
	--'- - - - - - -' AS [DAYS]	--ScheduleDays([MONDAY],[TUESDAY],[WEDNESDAY],[THURSDAY],[FRIDAY],[SATURDAY],[SUNDAY]) AS DAYS
	CASE s.MONDAY
		WHEN 1 THEN 'M '
		ELSE '- '
	END +
	CASE s.TUESDAY
		WHEN 1 THEN 'T '
		ELSE '- '
	END +
	CASE s.WEDNESDAY
		WHEN 1 THEN 'W '
		ELSE '- '
	END +
	CASE s.THURSDAY
		WHEN 1 THEN 'Th '
		ELSE '- '
	END +
	CASE s.FRIDAY
		WHEN 1 THEN 'F '
		ELSE '- '
	END +
	CASE s.SATURDAY
		WHEN 1 THEN 'Sa '
		ELSE '- '
	END +
	CASE s.SUNDAY
		WHEN 1 THEN 'Su'
		ELSE '-'
	END AS DAYS	
FROM #TVOrderDtlFilterMaxSeq AS f
INNER JOIN dbo.TV_DETAIL1 AS d
	ON f.BRDCAST_YEAR = d.BRDCAST_YEAR 
	AND f.SEQ_NBR = d.SEQ_NBR 
	AND f.REV_NBR = d.REV_NBR 
	AND f.LINE_NBR = d.LINE_NBR
	AND f.ORDER_NBR = d.ORDER_NBR 
INNER JOIN dbo.TV_HEADER AS h 
	ON h.ORDER_NBR = d.ORDER_NBR 
INNER JOIN dbo.TV_DETAIL2 AS d2
	ON d.BRDCAST_YEAR = d2.BRDCAST_YEAR 
	AND d.SEQ_NBR = d2.SEQ_NBR
	AND d.REV_NBR = d2.REV_NBR 
	AND d.LINE_NBR = d2.LINE_NBR 
	AND d.ORDER_NBR = d2.ORDER_NBR 
INNER JOIN dbo.TV_SPOTS AS s
	ON d.BRDCAST_YEAR = s.BRDCAST_YEAR
	AND d.SEQ_NBR = s.SEQ_NBR
	AND d.REV_NBR = s.REV_NBR 
	AND d.LINE_NBR = s.LINE_NBR 
	AND d.ORDER_NBR = s.ORDER_NBR
INNER JOIN #detail_order_amounts AS a
	ON d.ORDER_NBR = a.ORDER_NBR
	AND d.LINE_NBR = a.LINE_NBR
	AND d.BRDCAST_YEAR = a.BRDCAST_YEAR 
WHERE ISNULL(d.LINE_CANCELLED,0) = 0 
	AND ISNULL(d.DELETE_FLAG,0)= 0 
	AND h.ORD_PROCESS_CONTRL <> 6
	AND h.REV_NBR = (SELECT MAX(h2.REV_NBR) FROM dbo.TV_HEADER AS h2 WHERE h.ORDER_NBR = h2.ORDER_NBR)

END
