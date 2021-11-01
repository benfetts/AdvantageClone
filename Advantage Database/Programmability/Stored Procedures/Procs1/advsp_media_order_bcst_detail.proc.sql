
CREATE PROCEDURE [dbo].[advsp_media_order_bcst_detail] ( @user_code varchar(100), @order_type varchar(1) )
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

-- Temp table OrderDtlMaxSeq
CREATE TABLE #OrderDtlMaxSeq(
	[ORDER_NBR] int NULL,
	[LINE_NBR] smallint NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL,
	[BRDCAST_YEAR] int NULL)

-- Temp table order_amounts
CREATE TABLE #order_amounts(
	ORDER_NBR					int NOT NULL,
	LINE_NBR					int NOT NULL,
	COMM_AMT					decimal(15,2) NULL,
	REBATE_AMT					decimal(15,2) NULL,
	EXT_NET_AMT					decimal(15,2) NULL,
	TOTAL_SPOTS					int NULL,
	VENDOR_TAX					decimal(15,2) NULL,
	STATE_TAX					decimal(15,2) NULL,
	COUNTY_TAX					decimal(15,2) NULL,
	CITY_TAX					decimal(15,2) NULL,
	LINE_NET_DISC				decimal(15,2) NULL,
	NETCHARGES					decimal(15,2) NULL,
	VENDOR_TAX_NC				decimal(15,2) NULL,
	STATE_TAX_NC				decimal(15,2) NULL,
	COUNTY_TAX_NC				decimal(15,2) NULL,
	CITY_TAX_NC					decimal(15,2) NULL,
	LINE_TOTAL					decimal(15,2) NULL)

-- ==========================================================
-- Radio-----------------------------------------------------
If UPPER(@order_type) = 'R'
BEGIN
	--Insert into temp table OrderDtlMaxSeq
	INSERT INTO #OrderDtlMaxSeq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR),
		MIN(d.BRDCAST_YEAR)			--Selects one record only
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.RADIO_DETAIL1 AS d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR
		AND d.BRDCAST_YEAR = d2.BRDCAST_YEAR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR	
	-- SELECT * FROM #OrderDtlMaxSeq

	-- Insert into temp table #order_amounts
	INSERT INTO #order_amounts
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		SUM(d.COMM_AMT),
		SUM(d.REBATE_AMT),
		SUM(d.EXT_NET_AMT),
		SUM(d.TOTAL_SPOTS),
		SUM(d.VENDOR_TAX),
		SUM(d.STATE_TAX),
		SUM(d.COUNTY_TAX),
		SUM(d.CITY_TAX),
		SUM(d.LINE_NET_DISC),
		SUM(d.NETCHARGES),
		SUM(d.VENDOR_TAX_NC),
		SUM(d.STATE_TAX_NC),
		SUM(d.COUNTY_TAX_NC),
		SUM(d.CITY_TAX_NC),
		SUM(d.LINE_TOTAL)
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	GROUP BY d.ORDER_NBR, d.LINE_NBR
	-- SELECT * FROM #order_amounts
	
	-- Detail query
	SELECT d.ORDER_NBR, 
		d.LINE_NBR, 
		d.REV_NBR AS MAX_REV,
		d.SEQ_NBR AS MAX_SEQ,
		CASE s.MONDAY
			WHEN 1 THEN 'M'
			ELSE ' '
		END +
		CASE s.TUESDAY
			WHEN 1 THEN 'T'
			ELSE ' '
		END +
		CASE s.WEDNESDAY
			WHEN 1 THEN 'W'
			ELSE ' '
		END +
		CASE s.THURSDAY
			WHEN 1 THEN 'T'
			ELSE ' '
		END +
		CASE s.FRIDAY
			WHEN 1 THEN 'F'
			ELSE ' '
		END +
		CASE s.SATURDAY
			WHEN 1 THEN 'S'
			ELSE ' '
		END +
		CASE s.SUNDAY
			WHEN 1 THEN 'S'
			ELSE ' '
		END AS DAYS,
		d.START_TIME, 
		d.END_TIME, 
		d.LENGTH,
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,   
		d.PROGRAMMING,
		d.TAG, 
		d.REMARKS,
		d.JOB_COMPONENT_NBR,
		d.GROSS_RATE,
		d.NET_RATE,
		a.COMM_AMT,
		a.REBATE_AMT,
		a.EXT_NET_AMT,
		a.TOTAL_SPOTS,
		a.VENDOR_TAX,
		a.STATE_TAX,
		a.COUNTY_TAX,
		a.CITY_TAX,
		a.LINE_NET_DISC,
		a.NETCHARGES,
		a.VENDOR_TAX_NC,
		a.STATE_TAX_NC,
		a.COUNTY_TAX_NC,
		a.CITY_TAX_NC,
		a.LINE_TOTAL,    
		d.JOB_NUMBER, 
		d2.ORDER_COMMENT, 
		d2.POSITION_INFO, 
		d2.RATE_INFO, 
		d2.CLOSE_INFO, 
		d2.MISC_INFO, 
		d2.MATL_NOTES	
	FROM #OrderDtlMaxSeq AS o
	INNER JOIN dbo.RADIO_DETAIL1 AS d
		ON o.BRDCAST_YEAR = d.BRDCAST_YEAR 
		AND o.SEQ_NBR = d.SEQ_NBR 
		AND o.REV_NBR = d.REV_NBR 
		AND o.LINE_NBR = d.LINE_NBR
		AND o.ORDER_NBR = d.ORDER_NBR 
	INNER JOIN dbo.RADIO_DETAIL2 AS d2
		ON d.BRDCAST_YEAR = d2.BRDCAST_YEAR 
		AND d.SEQ_NBR = d2.SEQ_NBR
		AND d.REV_NBR = d2.REV_NBR 
		AND d.LINE_NBR = d2.LINE_NBR 
		AND d.ORDER_NBR = d2.ORDER_NBR 
	INNER JOIN dbo.RADIO_SPOTS AS s
		ON d.BRDCAST_YEAR = s.BRDCAST_YEAR
		AND d.SEQ_NBR = s.SEQ_NBR
		AND d.REV_NBR = s.REV_NBR 
		AND d.LINE_NBR = s.LINE_NBR 
		AND d.ORDER_NBR = s.ORDER_NBR
	INNER JOIN #order_amounts AS a
		ON o.ORDER_NBR = a.ORDER_NBR
		AND o.LINE_NBR = a.LINE_NBR 
	WHERE ISNULL(d.LINE_CANCELLED,0) = 0 
		AND ISNULL(d.DELETE_FLAG,0)= 0 
		--AND h.ORD_PROCESS_CONTRL <> 6
END

-- Television-----------------------------------------------------
If UPPER(@order_type) = 'T'
BEGIN
	--Insert into temp table OrderDtlMaxSeq
	INSERT INTO #OrderDtlMaxSeq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR),
		MIN(d.BRDCAST_YEAR)			--Selects one record only
	FROM #media_orders AS o
	INNER JOIN dbo.TV_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.TV_DETAIL1 AS d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR
		AND d.BRDCAST_YEAR = d2.BRDCAST_YEAR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR	
	-- SELECT * FROM #OrderDtlMaxSeq

	-- Insert into temp table #order_amounts
	INSERT INTO #order_amounts
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		SUM(d.COMM_AMT),
		SUM(d.REBATE_AMT),
		SUM(d.EXT_NET_AMT),
		SUM(d.TOTAL_SPOTS),
		SUM(d.VENDOR_TAX),
		SUM(d.STATE_TAX),
		SUM(d.COUNTY_TAX),
		SUM(d.CITY_TAX),
		SUM(d.LINE_NET_DISC),
		SUM(d.NETCHARGES),
		SUM(d.VENDOR_TAX_NC),
		SUM(d.STATE_TAX_NC),
		SUM(d.COUNTY_TAX_NC),
		SUM(d.CITY_TAX_NC),
		SUM(d.LINE_TOTAL)
	FROM #media_orders AS o
	INNER JOIN dbo.TV_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	GROUP BY d.ORDER_NBR, d.LINE_NBR
	-- SELECT * FROM #order_amounts
	
	-- Detail query
	SELECT d.ORDER_NBR, 
		d.LINE_NBR, 
		d.REV_NBR AS MAX_REV,
		d.SEQ_NBR AS MAX_SEQ,
		CASE s.MONDAY
			WHEN 1 THEN 'M'
			ELSE ' '
		END +
		CASE s.TUESDAY
			WHEN 1 THEN 'T'
			ELSE ' '
		END +
		CASE s.WEDNESDAY
			WHEN 1 THEN 'W'
			ELSE ' '
		END +
		CASE s.THURSDAY
			WHEN 1 THEN 'T'
			ELSE ' '
		END +
		CASE s.FRIDAY
			WHEN 1 THEN 'F'
			ELSE ' '
		END +
		CASE s.SATURDAY
			WHEN 1 THEN 'S'
			ELSE ' '
		END +
		CASE s.SUNDAY
			WHEN 1 THEN 'S'
			ELSE ' '
		END AS DAYS,
		d.START_TIME, 
		d.END_TIME, 
		d.LENGTH,
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,   
		d.PROGRAMMING,
		d.TAG, 
		d.REMARKS,
		d.JOB_COMPONENT_NBR,
		d.GROSS_RATE,
		d.NET_RATE,
		a.COMM_AMT,
		a.REBATE_AMT,
		a.EXT_NET_AMT,
		a.TOTAL_SPOTS,
		a.VENDOR_TAX,
		a.STATE_TAX,
		a.COUNTY_TAX,
		a.CITY_TAX,
		a.LINE_NET_DISC,
		a.NETCHARGES,
		a.VENDOR_TAX_NC,
		a.STATE_TAX_NC,
		a.COUNTY_TAX_NC,
		a.CITY_TAX_NC,
		a.LINE_TOTAL,    
		d.JOB_NUMBER, 
		d2.ORDER_COMMENT, 
		d2.POSITION_INFO, 
		d2.RATE_INFO, 
		d2.CLOSE_INFO, 
		d2.MISC_INFO, 
		d2.MATL_NOTES	
	FROM #OrderDtlMaxSeq AS o
	INNER JOIN dbo.TV_DETAIL1 AS d
		ON o.BRDCAST_YEAR = d.BRDCAST_YEAR 
		AND o.SEQ_NBR = d.SEQ_NBR 
		AND o.REV_NBR = d.REV_NBR 
		AND o.LINE_NBR = d.LINE_NBR
		AND o.ORDER_NBR = d.ORDER_NBR 
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
	INNER JOIN #order_amounts AS a
		ON o.ORDER_NBR = a.ORDER_NBR
		AND o.LINE_NBR = a.LINE_NBR  
	WHERE ISNULL(d.LINE_CANCELLED,0) = 0 
		AND ISNULL(d.DELETE_FLAG,0)= 0 
		--AND h.ORD_PROCESS_CONTRL <> 6
END

END
