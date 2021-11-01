
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_detail] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_detail(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL, 
	BRDCAST_YEAR					int NULL,
	DAYS							varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS,
	START_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	END_TIME						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[LENGTH]						smallint NULL,
	CLOSE_DATE						smalldatetime NULL,
	MATL_CLOSE_DATE					smalldatetime NULL,   
	MAT_COMP						smalldatetime NULL,  
	PROGRAMMING						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS,
	TAG								varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	REMARKS							varchar(254) COLLATE SQL_Latin1_General_CP1_CS_AS,
	GROSS_RATE						decimal(15,2) NULL,
	NET_RATE						decimal(15,2) NULL,
	JOB_NUMBER						int NULL,
	JOB_COMPONENT_NBR				smallint NULL, 
	LINE_CANCELLED					smallint NULL,
	NON_BILL_FLAG					smallint NULL,
	RECONCILE_LINE					smallint NULL,
	DO_NOT_BILL						smallint NULL,
	PRINTED							smallint NULL,
	ORDER_COMMENT					text, 
	POSITION_INFO					text, 
	RATE_INFO						text, 
	CLOSE_INFO						text, 
	MISC_INFO						text, 
	MATL_NOTES						text,
	HOUSE_COMMENT					text)

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

-- Temp table #max_rev_seq------------------------------------
CREATE TABLE #max_rev_seq(
	[ORDER_NBR] int NULL,
	[LINE_NBR] smallint NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL)

-- Temp table #min_year (cannot group on text fields, need this as a work around)-----
CREATE TABLE #min_year(
	[ORDER_NBR] int NULL,
	[LINE_NBR] smallint NULL,
	[REV_NBR] smallint NULL,
	[SEQ_NBR] smallint NULL,
	[BRDCAST_YEAR] int NULL)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	--Insert into temp table #max_rev_seq
	INSERT INTO #max_rev_seq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR)								--Selects one record only
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.RADIO_DETAIL1 AS d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR	
	-- SELECT * FROM #max_rev_seq

	-- Detail query
	INSERT INTO #order_detail
	SELECT 'R' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.BRDCAST_YEAR,
		CASE
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 AND s.SATURDAY = 1 AND  s.SUNDAY = 1 THEN 'M-Su'
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 AND s.SATURDAY = 1 THEN 'M-Sa'
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 THEN 'M-F'
			ELSE
				CASE s.MONDAY
					WHEN 1 THEN 'M'
					ELSE ''
				END +
				CASE s.TUESDAY
					WHEN 1 THEN 'Tu'
					ELSE ''
				END +
				CASE s.WEDNESDAY
					WHEN 1 THEN 'W'
					ELSE ''
				END +
				CASE s.THURSDAY
					WHEN 1 THEN 'Th'
					ELSE ''
				END +
				CASE s.FRIDAY
					WHEN 1 THEN 'F'
					ELSE ''
				END +
				CASE s.SATURDAY
					WHEN 1 THEN 'Sa'
					ELSE ''
				END +
				CASE s.SUNDAY
					WHEN 1 THEN 'Su'
					ELSE ''
				END
			END AS DAYS,
		d.START_TIME, 
		d.END_TIME, 
		d.LENGTH,
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE,
		d.MAT_COMP,   
		d.PROGRAMMING,
		d.TAG, 
		d.REMARKS,
		d.GROSS_RATE,
		d.NET_RATE,
		d.JOB_NUMBER, 
		d.JOB_COMPONENT_NBR,
		ISNULL(d.LINE_CANCELLED,0),
		0 AS NON_BILL_FLAG,
		ISNULL(d.RECONCILE_LINE,0),
		ISNULL(d.DO_NOT_BILL,0),
		d.PRINTED,
		d2.ORDER_COMMENT, 
		d2.POSITION_INFO, 
		d2.RATE_INFO, 
		d2.CLOSE_INFO, 
		d2.MISC_INFO, 
		d2.MATL_NOTES,
		d2.HOUSE_COMMENT			
	FROM #max_rev_seq AS rs
	INNER JOIN dbo.RADIO_DETAIL1 AS d 
		ON rs.SEQ_NBR = d.SEQ_NBR 
		AND rs.REV_NBR = d.REV_NBR 
		AND rs.LINE_NBR = d.LINE_NBR
		AND rs.ORDER_NBR = d.ORDER_NBR 
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

	--Clear temp tables
	DELETE FROM #max_rev_seq
END

-- Television--------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	--Insert into temp table #max_rev_seq
	INSERT INTO #max_rev_seq
	SELECT d.ORDER_NBR,
		d.LINE_NBR,
		d.REV_NBR,
		MAX(d.SEQ_NBR)								--Selects one record only
	FROM #media_orders AS o
	INNER JOIN dbo.TV_DETAIL1 AS d
		ON o.ORDER_NBR = d.ORDER_NBR
	WHERE d.REV_NBR = (SELECT Max(d2.REV_NBR) FROM dbo.TV_DETAIL1 AS d2
		WHERE d.ORDER_NBR = d2.ORDER_NBR
		AND d.LINE_NBR = d2.LINE_NBR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR	
--	SELECT * FROM #max_rev_seq

	-- Detail query
	INSERT INTO #order_detail
	SELECT 'T' AS ORDER_TYPE, 
		d.ORDER_NBR, 
		d.LINE_NBR,
		d.REV_NBR,
		d.SEQ_NBR,
		d.BRDCAST_YEAR, 
		CASE
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 AND s.SATURDAY = 1 AND  s.SUNDAY = 1 THEN 'M-Su'
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 AND s.SATURDAY = 1 THEN 'M-Sa'
			WHEN s.MONDAY = 1 AND s.TUESDAY = 1 AND s.WEDNESDAY = 1 AND s.THURSDAY = 1 AND s.FRIDAY = 1 THEN 'M-F'
			ELSE
				CASE s.MONDAY
					WHEN 1 THEN 'M'
					ELSE ''
				END +
				CASE s.TUESDAY
					WHEN 1 THEN 'Tu'
					ELSE ''
				END +
				CASE s.WEDNESDAY
					WHEN 1 THEN 'W'
					ELSE ''
				END +
				CASE s.THURSDAY
					WHEN 1 THEN 'Th'
					ELSE ''
				END +
				CASE s.FRIDAY
					WHEN 1 THEN 'F'
					ELSE ''
				END +
				CASE s.SATURDAY
					WHEN 1 THEN 'Sa'
					ELSE ''
				END +
				CASE s.SUNDAY
					WHEN 1 THEN 'Su'
					ELSE ''
				END
			END AS DAYS,
		d.START_TIME, 
		d.END_TIME, 
		d.LENGTH,
		d.CLOSE_DATE,
		d.MATL_CLOSE_DATE, 
		d.MAT_COMP,  
		d.PROGRAMMING,
		d.TAG, 
		d.REMARKS,
		d.GROSS_RATE,
		d.NET_RATE,
		d.JOB_NUMBER,
		d.JOB_COMPONENT_NBR,
		ISNULL(d.LINE_CANCELLED,0),
		0 AS NON_BILL_FLAG,
		ISNULL(d.RECONCILE_LINE,0),
		ISNULL(d.DO_NOT_BILL,0),
		d.PRINTED,
		d2.ORDER_COMMENT, 
		d2.POSITION_INFO, 
		d2.RATE_INFO, 
		d2.CLOSE_INFO, 
		d2.MISC_INFO, 
		d2.MATL_NOTES,
		d2.HOUSE_COMMENT	
	FROM #max_rev_seq AS rs
	INNER JOIN dbo.TV_DETAIL1 AS d 
		ON rs.SEQ_NBR = d.SEQ_NBR 
		AND rs.REV_NBR = d.REV_NBR 
		AND rs.LINE_NBR = d.LINE_NBR
		AND rs.ORDER_NBR = d.ORDER_NBR 
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

	--Clear temp tables
	DELETE FROM #max_rev_seq
END

-- Get a unique record for each order/line (minimum year)
	INSERT INTO #min_year
	SELECT ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, MIN(BRDCAST_YEAR)
	FROM #order_detail
	GROUP BY ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR
--	SELECT * FROM #min_year

SELECT ORDER_TYPE, d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.SEQ_NBR, d.BRDCAST_YEAR, DAYS, START_TIME, END_TIME, 
	[LENGTH], CLOSE_DATE, MATL_CLOSE_DATE, MAT_COMP, PROGRAMMING, TAG, REMARKS, GROSS_RATE, NET_RATE,
	JOB_NUMBER, JOB_COMPONENT_NBR, LINE_CANCELLED, NON_BILL_FLAG, RECONCILE_LINE, DO_NOT_BILL,
	PRINTED, ORDER_COMMENT, POSITION_INFO, RATE_INFO, CLOSE_INFO, MISC_INFO, MATL_NOTES, HOUSE_COMMENT
FROM #order_detail AS d
JOIN #min_year AS y
	ON d.ORDER_NBR = y.ORDER_NBR
	AND d.LINE_NBR = y.LINE_NBR
	AND d.REV_NBR = y.REV_NBR
	AND d.SEQ_NBR = y.SEQ_NBR
	AND d.BRDCAST_YEAR = y.BRDCAST_YEAR

END
