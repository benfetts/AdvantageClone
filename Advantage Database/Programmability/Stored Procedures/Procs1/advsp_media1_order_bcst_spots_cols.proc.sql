﻿
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_spots_cols] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #spots(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	LINE_NBR						smallint NULL,
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
-- SECONDARY TABLES
-- ==========================================================
-- Temp table #media_orders - stores table of orders to be processed
CREATE TABLE #media_orders(
	[USER_ID]				varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR				int NULL,
	ORDER_TYPE				varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #media_orders
SELECT
	[USER_ID], 
	ORDER_NBR,
	ORDER_TYPE
FROM dbo.MEDIA_RPT_ORDERS AS rd
WHERE UPPER(rd.[USER_ID]) = UPPER(@user_code)
-- SELECT * FROM #media_orders--------------------------------

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE FROM #media_orders

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #spots
	SELECT 'R ' AS ORDER_TYPE, 
		a.ORDER_NBR, 
		a.LINE_NBR, 
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

SELECT * FROM #spots


END
