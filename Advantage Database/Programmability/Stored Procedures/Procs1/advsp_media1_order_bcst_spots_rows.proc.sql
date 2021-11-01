
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_spots_rows] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #spots_as_rows(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	BRDCAST_YEAR					int NULL,
	WEEK_NBR						smallint NULL,
	SPOTS							int NULL)

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

-- Temp table #spots - stores sum of spots by week------------
CREATE TABLE #spots(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
	REV_NBR							smallint NULL,
	SEQ_NBR							smallint NULL,
	BRDCAST_YEAR					int NULL,
	SPOTS_WK1						int NULL,
	SPOTS_WK2						int NULL,
	SPOTS_WK3						int NULL,
	SPOTS_WK4						int NULL,
	SPOTS_WK5						int NULL,
	SPOTS_WK6						int NULL,
	SPOTS_WK7						int NULL,
	SPOTS_WK8						int NULL,
	SPOTS_WK9						int NULL,
	SPOTS_WK10						int NULL,
	SPOTS_WK11						int NULL,
	SPOTS_WK12						int NULL,
	SPOTS_WK13						int NULL,
	SPOTS_WK14						int NULL,
	SPOTS_WK15						int NULL,
	SPOTS_WK16						int NULL,
	SPOTS_WK17						int NULL,
	SPOTS_WK18						int NULL,
	SPOTS_WK19						int NULL,
	SPOTS_WK20						int NULL,
	SPOTS_WK21						int NULL,
	SPOTS_WK22						int NULL,
	SPOTS_WK23						int NULL,
	SPOTS_WK24						int NULL,
	SPOTS_WK25						int NULL,
	SPOTS_WK26						int NULL,
	SPOTS_WK27						int NULL,
	SPOTS_WK28						int NULL,
	SPOTS_WK29						int NULL,
	SPOTS_WK30						int NULL,
	SPOTS_WK31						int NULL,
	SPOTS_WK32						int NULL,
	SPOTS_WK33						int NULL,
	SPOTS_WK34						int NULL,
	SPOTS_WK35						int NULL,
	SPOTS_WK36						int NULL,
	SPOTS_WK37						int NULL,
	SPOTS_WK38						int NULL,
	SPOTS_WK39						int NULL,
	SPOTS_WK40						int NULL,
	SPOTS_WK41						int NULL,
	SPOTS_WK42						int NULL,
	SPOTS_WK43						int NULL,
	SPOTS_WK44						int NULL,
	SPOTS_WK45						int NULL,
	SPOTS_WK46						int NULL,
	SPOTS_WK47						int NULL,
	SPOTS_WK48						int NULL,
	SPOTS_WK49						int NULL,
	SPOTS_WK50						int NULL,
	SPOTS_WK51						int NULL,
	SPOTS_WK52						int NULL,
	SPOTS_WK53						int NULL)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #spots
	SELECT 'R' AS ORDER_TYPE, 
		a.ORDER_NBR, 
		a.LINE_NBR,
		a.REV_NBR,
		a.SEQ_NBR,
		a.BRDCAST_YEAR,
		ISNULL(a.SPOTS_WK1,0) AS SPOTS_WK1, 
		ISNULL(a.SPOTS_WK2,0) AS SPOTS_WK2, 
		ISNULL(a.SPOTS_WK3,0) AS SPOTS_WK3, 
		ISNULL(a.SPOTS_WK4,0) AS SPOTS_WK4, 
		ISNULL(a.SPOTS_WK5,0) AS SPOTS_WK5, 
		ISNULL(a.SPOTS_WK6,0) AS SPOTS_WK6, 
		ISNULL(a.SPOTS_WK7,0) AS SPOTS_WK7, 
		ISNULL(a.SPOTS_WK8,0) AS SPOTS_WK8, 
		ISNULL(a.SPOTS_WK9,0) AS SPOTS_WK9, 
		ISNULL(a.SPOTS_WK10,0) AS SPOTS_WK10, 
		ISNULL(a.SPOTS_WK11,0) AS SPOTS_WK11, 
		ISNULL(a.SPOTS_WK12,0) AS SPOTS_WK12, 
		ISNULL(a.SPOTS_WK13,0) AS SPOTS_WK13, 
		ISNULL(a.SPOTS_WK14,0) AS SPOTS_WK14, 
		ISNULL(a.SPOTS_WK15,0) AS SPOTS_WK15, 
		ISNULL(a.SPOTS_WK16,0) AS SPOTS_WK16, 
		ISNULL(a.SPOTS_WK17,0) AS SPOTS_WK17, 
		ISNULL(a.SPOTS_WK18,0) AS SPOTS_WK18, 
		ISNULL(a.SPOTS_WK19,0) AS SPOTS_WK19, 
		ISNULL(a.SPOTS_WK20,0) AS SPOTS_WK20, 
		ISNULL(a.SPOTS_WK21,0) AS SPOTS_WK21, 
		ISNULL(a.SPOTS_WK22,0) AS SPOTS_WK22, 
		ISNULL(a.SPOTS_WK23,0) AS SPOTS_WK23, 
		ISNULL(a.SPOTS_WK24,0) AS SPOTS_WK24, 
		ISNULL(a.SPOTS_WK25,0) AS SPOTS_WK25, 
		ISNULL(a.SPOTS_WK26,0) AS SPOTS_WK26, 
		ISNULL(a.SPOTS_WK27,0) AS SPOTS_WK27, 
		ISNULL(a.SPOTS_WK28,0) AS SPOTS_WK28, 
		ISNULL(a.SPOTS_WK29,0) AS SPOTS_WK29, 
		ISNULL(a.SPOTS_WK30,0) AS SPOTS_WK30, 
		ISNULL(a.SPOTS_WK31,0) AS SPOTS_WK31, 
		ISNULL(a.SPOTS_WK32,0) AS SPOTS_WK32, 
		ISNULL(a.SPOTS_WK33,0) AS SPOTS_WK33, 
		ISNULL(a.SPOTS_WK34,0) AS SPOTS_WK34, 
		ISNULL(a.SPOTS_WK35,0) AS SPOTS_WK35, 
		ISNULL(a.SPOTS_WK36,0) AS SPOTS_WK36, 
		ISNULL(a.SPOTS_WK37,0) AS SPOTS_WK37, 
		ISNULL(a.SPOTS_WK38,0) AS SPOTS_WK38, 
		ISNULL(a.SPOTS_WK39,0) AS SPOTS_WK39, 
		ISNULL(a.SPOTS_WK40,0) AS SPOTS_WK40, 
		ISNULL(a.SPOTS_WK41,0) AS SPOTS_WK41, 
		ISNULL(a.SPOTS_WK42,0) AS SPOTS_WK42, 
		ISNULL(a.SPOTS_WK43,0) AS SPOTS_WK43, 
		ISNULL(a.SPOTS_WK44,0) AS SPOTS_WK44, 
		ISNULL(a.SPOTS_WK45,0) AS SPOTS_WK45, 
		ISNULL(a.SPOTS_WK46,0) AS SPOTS_WK46, 
		ISNULL(a.SPOTS_WK47,0) AS SPOTS_WK47, 
		ISNULL(a.SPOTS_WK48,0) AS SPOTS_WK48, 
		ISNULL(a.SPOTS_WK49,0) AS SPOTS_WK49, 
		ISNULL(a.SPOTS_WK50,0) AS SPOTS_WK50, 
		ISNULL(a.SPOTS_WK51,0) AS SPOTS_WK51, 
		ISNULL(a.SPOTS_WK52,0) AS SPOTS_WK52, 
		ISNULL(a.SPOTS_WK53,0) AS SPOTS_WK53
	FROM dbo.RADIO_SPOTS AS a
	INNER JOIN #media_orders AS o
		ON a.ORDER_NBR = o.ORDER_NBR
END

-- Television-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #spots
	SELECT 'T' AS ORDER_TYPE,
		a.ORDER_NBR, 
		a.LINE_NBR,
		a.REV_NBR,
		a.SEQ_NBR,
		a.BRDCAST_YEAR,
		ISNULL(a.SPOTS_WK1,0) AS SPOTS_WK1, 
		ISNULL(a.SPOTS_WK2,0) AS SPOTS_WK2, 
		ISNULL(a.SPOTS_WK3,0) AS SPOTS_WK3, 
		ISNULL(a.SPOTS_WK4,0) AS SPOTS_WK4, 
		ISNULL(a.SPOTS_WK5,0) AS SPOTS_WK5, 
		ISNULL(a.SPOTS_WK6,0) AS SPOTS_WK6, 
		ISNULL(a.SPOTS_WK7,0) AS SPOTS_WK7, 
		ISNULL(a.SPOTS_WK8,0) AS SPOTS_WK8, 
		ISNULL(a.SPOTS_WK9,0) AS SPOTS_WK9, 
		ISNULL(a.SPOTS_WK10,0) AS SPOTS_WK10, 
		ISNULL(a.SPOTS_WK11,0) AS SPOTS_WK11, 
		ISNULL(a.SPOTS_WK12,0) AS SPOTS_WK12, 
		ISNULL(a.SPOTS_WK13,0) AS SPOTS_WK13, 
		ISNULL(a.SPOTS_WK14,0) AS SPOTS_WK14, 
		ISNULL(a.SPOTS_WK15,0) AS SPOTS_WK15, 
		ISNULL(a.SPOTS_WK16,0) AS SPOTS_WK16, 
		ISNULL(a.SPOTS_WK17,0) AS SPOTS_WK17, 
		ISNULL(a.SPOTS_WK18,0) AS SPOTS_WK18, 
		ISNULL(a.SPOTS_WK19,0) AS SPOTS_WK19, 
		ISNULL(a.SPOTS_WK20,0) AS SPOTS_WK20, 
		ISNULL(a.SPOTS_WK21,0) AS SPOTS_WK21, 
		ISNULL(a.SPOTS_WK22,0) AS SPOTS_WK22, 
		ISNULL(a.SPOTS_WK23,0) AS SPOTS_WK23, 
		ISNULL(a.SPOTS_WK24,0) AS SPOTS_WK24, 
		ISNULL(a.SPOTS_WK25,0) AS SPOTS_WK25, 
		ISNULL(a.SPOTS_WK26,0) AS SPOTS_WK26, 
		ISNULL(a.SPOTS_WK27,0) AS SPOTS_WK27, 
		ISNULL(a.SPOTS_WK28,0) AS SPOTS_WK28, 
		ISNULL(a.SPOTS_WK29,0) AS SPOTS_WK29, 
		ISNULL(a.SPOTS_WK30,0) AS SPOTS_WK30, 
		ISNULL(a.SPOTS_WK31,0) AS SPOTS_WK31, 
		ISNULL(a.SPOTS_WK32,0) AS SPOTS_WK32, 
		ISNULL(a.SPOTS_WK33,0) AS SPOTS_WK33, 
		ISNULL(a.SPOTS_WK34,0) AS SPOTS_WK34, 
		ISNULL(a.SPOTS_WK35,0) AS SPOTS_WK35, 
		ISNULL(a.SPOTS_WK36,0) AS SPOTS_WK36, 
		ISNULL(a.SPOTS_WK37,0) AS SPOTS_WK37, 
		ISNULL(a.SPOTS_WK38,0) AS SPOTS_WK38, 
		ISNULL(a.SPOTS_WK39,0) AS SPOTS_WK39, 
		ISNULL(a.SPOTS_WK40,0) AS SPOTS_WK40, 
		ISNULL(a.SPOTS_WK41,0) AS SPOTS_WK41, 
		ISNULL(a.SPOTS_WK42,0) AS SPOTS_WK42, 
		ISNULL(a.SPOTS_WK43,0) AS SPOTS_WK43, 
		ISNULL(a.SPOTS_WK44,0) AS SPOTS_WK44, 
		ISNULL(a.SPOTS_WK45,0) AS SPOTS_WK45, 
		ISNULL(a.SPOTS_WK46,0) AS SPOTS_WK46, 
		ISNULL(a.SPOTS_WK47,0) AS SPOTS_WK47, 
		ISNULL(a.SPOTS_WK48,0) AS SPOTS_WK48, 
		ISNULL(a.SPOTS_WK49,0) AS SPOTS_WK49, 
		ISNULL(a.SPOTS_WK50,0) AS SPOTS_WK50, 
		ISNULL(a.SPOTS_WK51,0) AS SPOTS_WK51, 
		ISNULL(a.SPOTS_WK52,0) AS SPOTS_WK52, 
		ISNULL(a.SPOTS_WK53,0) AS SPOTS_WK53
	FROM dbo.TV_SPOTS AS a
	INNER JOIN #media_orders AS o
		ON a.ORDER_NBR = o.ORDER_NBR
END
--SELECT * FROM #spots
	
--Cursor routine - converts columns to rows--------------------
DECLARE @order_type varchar(1), @order_nbr int, @line_nbr smallint, @rev_nbr smallint, @seq_nbr smallint, @brdcast_year int
DECLARE @spots_wk1 int, @spots_wk2 int, @spots_wk3 int, @spots_wk4 int, @spots_wk5 int, @spots_wk6 int, @spots_wk7 int
DECLARE @spots_wk8 int, @spots_wk9 int, @spots_wk10 int, @spots_wk11 int, @spots_wk12 int, @spots_wk13 int, @spots_wk14 int
DECLARE @spots_wk15 int, @spots_wk16 int, @spots_wk17 int, @spots_wk18 int, @spots_wk19 int, @spots_wk20 int, @spots_wk21 int
DECLARE @spots_wk22 int, @spots_wk23 int, @spots_wk24 int, @spots_wk25 int, @spots_wk26 int, @spots_wk27 int, @spots_wk28 int
DECLARE @spots_wk29 int, @spots_wk30 int, @spots_wk31 int, @spots_wk32 int, @spots_wk33 int, @spots_wk34 int, @spots_wk35 int
DECLARE @spots_wk36 int, @spots_wk37 int, @spots_wk38 int, @spots_wk39 int, @spots_wk40 int, @spots_wk41 int, @spots_wk42 int
DECLARE @spots_wk43 int, @spots_wk44 int, @spots_wk45 int, @spots_wk46 int, @spots_wk47 int, @spots_wk48 int, @spots_wk49 int
DECLARE @spots_wk50 int, @spots_wk51 int, @spots_wk52 int, @spots_wk53 int 

DECLARE spots_cursor CURSOR LOCAL FAST_FORWARD	FOR
SELECT d.ORDER_TYPE, d.ORDER_NBR, d.LINE_NBR, d.REV_NBR, d.SEQ_NBR, d.BRDCAST_YEAR, d.SPOTS_WK1, d.SPOTS_WK2, d.SPOTS_WK3, d.SPOTS_WK4, d.SPOTS_WK5, 
	d.SPOTS_WK6, d.SPOTS_WK7, d.SPOTS_WK8, d.SPOTS_WK9, d.SPOTS_WK10, d.SPOTS_WK11, d.SPOTS_WK12, d.SPOTS_WK13, 
	d.SPOTS_WK14, d.SPOTS_WK15, d.SPOTS_WK16, d.SPOTS_WK17, d.SPOTS_WK18, d.SPOTS_WK19, d.SPOTS_WK20, d.SPOTS_WK21, 
	d.SPOTS_WK22, d.SPOTS_WK23, d.SPOTS_WK24, d.SPOTS_WK25, d.SPOTS_WK26, d.SPOTS_WK27, d.SPOTS_WK28, d.SPOTS_WK29, 
	d.SPOTS_WK30, d.SPOTS_WK31, d.SPOTS_WK32, d.SPOTS_WK33, d.SPOTS_WK34, d.SPOTS_WK35, d.SPOTS_WK36, d.SPOTS_WK37, 
	d.SPOTS_WK38, d.SPOTS_WK39, d.SPOTS_WK40, d.SPOTS_WK41, d.SPOTS_WK42, d.SPOTS_WK43, d.SPOTS_WK44, d.SPOTS_WK45, 
	d.SPOTS_WK46, d.SPOTS_WK47, d.SPOTS_WK48, d.SPOTS_WK49, d.SPOTS_WK50, d.SPOTS_WK51, d.SPOTS_WK52, d.SPOTS_WK53
FROM #spots AS d
OPEN spots_cursor
FETCH NEXT FROM spots_cursor
	INTO @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, @spots_wk1, @spots_wk2, @spots_wk3, @spots_wk4, @spots_wk5,
		@spots_wk6, @spots_wk7, @spots_wk8, @spots_wk9, @spots_wk10, @spots_wk11, @spots_wk12, @spots_wk13,
		@spots_wk14, @spots_wk15, @spots_wk16, @spots_wk17, @spots_wk18, @spots_wk19, @spots_wk20, @spots_wk21,
		@spots_wk22, @spots_wk23, @spots_wk24, @spots_wk25, @spots_wk26, @spots_wk27, @spots_wk28, @spots_wk29,
		@spots_wk30, @spots_wk31, @spots_wk32, @spots_wk33, @spots_wk34, @spots_wk35, @spots_wk36, @spots_wk37,
		@spots_wk38, @spots_wk39, @spots_wk40, @spots_wk41, @spots_wk42, @spots_wk43, @spots_wk44, @spots_wk45,
		@spots_wk46, @spots_wk47, @spots_wk48, @spots_wk49, @spots_wk50, @spots_wk51, @spots_wk52, @spots_wk53
WHILE @@FETCH_STATUS = 0
BEGIN
	-- processing statements
	IF @spots_wk1 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 1, @spots_wk1
	IF @spots_wk2 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 2, @spots_wk2
	IF @spots_wk3 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 3, @spots_wk3
	IF @spots_wk4 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 4, @spots_wk4
	IF @spots_wk5 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 5, @spots_wk5
	IF @spots_wk6 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 6, @spots_wk6
	IF @spots_wk7 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 7, @spots_wk7
	IF @spots_wk8 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 8, @spots_wk8
	IF @spots_wk9 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 9, @spots_wk9
	IF @spots_wk10 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 10, @spots_wk10
	IF @spots_wk11 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 11, @spots_wk11
	IF @spots_wk12 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 12, @spots_wk12
	IF @spots_wk13 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 13, @spots_wk13
	IF @spots_wk14 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 14, @spots_wk14
	IF @spots_wk15 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 15, @spots_wk15
	IF @spots_wk16 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 16, @spots_wk16
	IF @spots_wk17 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 17, @spots_wk17
	IF @spots_wk18 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 18, @spots_wk18
	IF @spots_wk19 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 19, @spots_wk19
	IF @spots_wk20 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 20, @spots_wk20
	IF @spots_wk21 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 21, @spots_wk21
	IF @spots_wk22 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 22, @spots_wk22
	IF @spots_wk23 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 23, @spots_wk23
	IF @spots_wk24 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 24, @spots_wk24
	IF @spots_wk25 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 25, @spots_wk25
	IF @spots_wk26 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 26, @spots_wk26
	IF @spots_wk27 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 27, @spots_wk27
	IF @spots_wk28 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 28, @spots_wk28
	IF @spots_wk29 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 29, @spots_wk29
	IF @spots_wk30 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 30, @spots_wk30
	IF @spots_wk31 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 31, @spots_wk31
	IF @spots_wk32 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 32, @spots_wk32
	IF @spots_wk33 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 33, @spots_wk33
	IF @spots_wk34 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 34, @spots_wk34
	IF @spots_wk35 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 35, @spots_wk35
	IF @spots_wk36 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 36, @spots_wk36
	IF @spots_wk37 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 37, @spots_wk37
	IF @spots_wk38 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 38, @spots_wk38
	IF @spots_wk39 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 39, @spots_wk39
	IF @spots_wk40 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 40, @spots_wk40
	IF @spots_wk41 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 41, @spots_wk41
	IF @spots_wk42 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 42, @spots_wk42
	IF @spots_wk43 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 43, @spots_wk43
	IF @spots_wk44 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 44, @spots_wk44
	IF @spots_wk45 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 45, @spots_wk45
	IF @spots_wk46 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 46, @spots_wk46
	IF @spots_wk47 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 47, @spots_wk47
	IF @spots_wk48 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 48, @spots_wk48
	IF @spots_wk49 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 49, @spots_wk49
	IF @spots_wk50 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 50, @spots_wk50
	IF @spots_wk51 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 51, @spots_wk51
	IF @spots_wk52 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 52, @spots_wk52
	IF @spots_wk53 <> 0 INSERT INTO #spots_as_rows SELECT @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, 53, @spots_wk53
	FETCH NEXT FROM spots_cursor
	INTO @order_type, @order_nbr, @line_nbr, @rev_nbr, @seq_nbr, @brdcast_year, @spots_wk1, @spots_wk2, @spots_wk3, @spots_wk4, @spots_wk5,
		@spots_wk6, @spots_wk7, @spots_wk8, @spots_wk9, @spots_wk10, @spots_wk11, @spots_wk12, @spots_wk13,
		@spots_wk14, @spots_wk15, @spots_wk16, @spots_wk17, @spots_wk18, @spots_wk19, @spots_wk20, @spots_wk21,
		@spots_wk22, @spots_wk23, @spots_wk24, @spots_wk25, @spots_wk26, @spots_wk27, @spots_wk28, @spots_wk29,
		@spots_wk30, @spots_wk31, @spots_wk32, @spots_wk33, @spots_wk34, @spots_wk35, @spots_wk36, @spots_wk37,
		@spots_wk38, @spots_wk39, @spots_wk40, @spots_wk41, @spots_wk42, @spots_wk43, @spots_wk44, @spots_wk45,
		@spots_wk46, @spots_wk47, @spots_wk48, @spots_wk49, @spots_wk50, @spots_wk51, @spots_wk52, @spots_wk53
END
CLOSE spots_cursor
DEALLOCATE spots_cursor

-- Link to fn_BroadcastCal to get broadcast month and week date
SELECT d.ORDER_TYPE, 
	d.ORDER_NBR,
	d.LINE_NBR,
	d.REV_NBR,
	d.SEQ_NBR,
	d.BRDCAST_YEAR,
	d.WEEK_NBR,
	d.SPOTS,
	c.brd_month AS BRDCAST_MONTH, 
	c.weekdate AS WEEK_DATE
FROM #spots_as_rows AS d
JOIN dbo.fn_BroadcastCal() AS c
	ON d.BRDCAST_YEAR = c.brd_year
	AND d.WEEK_NBR = c.weeknum

END
