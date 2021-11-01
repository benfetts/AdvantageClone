
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_comments2] ( @user_code varchar(100) )
AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_comments(
	ORDER_NBR						int NOT NULL, 
	LINE_NBR						smallint NULL,
	INSTRUCTIONS					text,
	ORDER_COPY						text,
	MATL_NOTES						text,
	POSITION_INFO					text, 
	CLOSE_INFO						text, 
	RATE_INFO						text, 
	MISC_INFO						text, 
	IN_HOUSE_CMTS					text)

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

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio-----------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #order_comments
	SELECT
		c.ORDER_NBR, 
		c.LINE_NBR,
		c.INSTRUCTIONS,
		c.ORDER_COPY, 
		c.MATL_NOTES, 
		c.POSITION_INFO, 
		c.CLOSE_INFO, 
		c.RATE_INFO, 
		c.MISC_INFO,
		c.IN_HOUSE_CMTS			
	FROM dbo.RADIO_COMMENTS AS c 		
	JOIN #media_orders AS o
		ON o.ORDER_NBR = c.ORDER_NBR 
END

-- Television--------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #order_comments
	SELECT
		c.ORDER_NBR, 
		c.LINE_NBR,
		c.INSTRUCTIONS,
		c.ORDER_COPY, 
		c.MATL_NOTES, 
		c.POSITION_INFO, 
		c.CLOSE_INFO, 
		c.RATE_INFO, 
		c.MISC_INFO,
		c.IN_HOUSE_CMTS			
	FROM dbo.TV_COMMENTS AS c 		
	JOIN #media_orders AS o
		ON o.ORDER_NBR = c.ORDER_NBR 
END
	SELECT * FROM #order_comments
END
