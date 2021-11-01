
CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_header2] ( @user_code varchar(100) )

--Stored procedure to extract NEW BROADCAST HEADER information
-- #00 07/21/09 - initial release
-- #01 07/20/12 - added new columns BILL_COOP_CODE -> FISCAL_PERIOD_CODE
-- #02 11/29/12 - replaced std comment with CL_MFOOTER

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_NBR						int NOT NULL,
	MAX_REV							smallint NULL,
	LINK_ID							int NULL, 
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	ORDER_DATE						smalldatetime NULL, 
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
	[START_DATE]					smalldatetime NULL,
	END_DATE						smalldatetime NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_ACCEPTED					tinyint NULL)


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

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	INSERT INTO #order_header
	SELECT 'R' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.UNITS,
		h.ORDER_NBR,
		0 AS MAX_REV, 
		h.LINK_ID,
		h.OFFICE_CODE,
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.MARKET_CODE, 
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.CREATE_DATE,
		h.[START_DATE],
		h.END_DATE,
		10 AS FONT_SIZE,				--#02
		c.CL_MFOOTER AS CL_FOOTER,		--#02
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.ORDER_ACCEPTED
	FROM dbo.RADIO_HDR AS h
	JOIN #media_orders AS o
		ON h.ORDER_NBR = o.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
END

-- Television------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	INSERT INTO #order_header
	SELECT 'T' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.UNITS,
		h.ORDER_NBR,
		0 AS MAX_REV, 
		h.LINK_ID,
		h.OFFICE_CODE,
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.MARKET_CODE, 
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.CREATE_DATE,
		h.[START_DATE],
		h.END_DATE,
		10 AS FONT_SIZE,				--#02
		c.CL_MFOOTER AS CL_FOOTER,		--#02
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.ORDER_ACCEPTED
	FROM dbo.TV_HDR AS h
	JOIN #media_orders AS o
		ON h.ORDER_NBR = o.ORDER_NBR  
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
END

SELECT * FROM #order_header

END