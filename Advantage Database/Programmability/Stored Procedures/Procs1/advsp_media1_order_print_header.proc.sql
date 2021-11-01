CREATE PROCEDURE [dbo].[advsp_media1_order_print_header] ( @user_code varchar(100) )
-- @order_type m=magazine, n=newspaper, i=internet, o=outdoor

-- Stored procedure to extract PRINT MEDIA ORDER HEADER information
-- #00 05/27/09 - initial release
-- #01 08/04/09 - added HOUSE_COMMENT
-- #02 02/09/11 - added invoice footer comment (CL_FOOTER)
-- #03 03/11/11 - added FONT_SIZE
-- #04 07/20/12 - added new columns BILL_COOP_CODE -> NBR_OF_UNITS
-- #05 11/29/12 - replaced std comment with CL_MFOOTER (V2 - REDO)

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #order_header(
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	MEDIA_TYPE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NOT NULL,
	ORDER_DATE						smalldatetime NULL,
	MODIFIED_DATE					smalldatetime NULL,
	REVISED_FLAG					smallint NULL,
	ORDER_DESC						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	LINK_ID							int NULL,
	OFFICE_CODE						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CMP_IDENTIFIER					int NULL,
	NET_GROSS						smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CLIENT_REF						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VN_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PUB								smallint NULL,
	VR_CODE							varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP1							smallint NULL,
	VR_CODE2						varchar(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
	REP2							smallint NULL,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	PRINTED							smallint NULL,
	FONT_SIZE						smallint NULL,
	CL_FOOTER						text,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FISCAL_PERIOD_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	UNITS							varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
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
-- SELECT * FROM #media_orders

-- Temp table #order_type-------------------------------------
CREATE TABLE #order_type(ORDER_TYPE varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS)
INSERT INTO #order_type
SELECT DISTINCT ORDER_TYPE 
FROM #media_orders
-- SELECT * FROM #order_type

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'M')
BEGIN
	-- Magazine (new)--------------------------------------------
	INSERT INTO #order_header
	SELECT o.ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.LINK_ID,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.ORD_PROCESS_CONTRL,
		h.MARKET_CODE,
		h.CLIENT_PO,
		h.CLIENT_REF,
		h.BUYER,
		h.VN_CODE,
		h.PUB,
		h.VR_CODE,
		h.REP1,
		h.VR_CODE2,
		h.REP2,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.PRINTED,
		10 AS FONT_SIZE,				--#05
		c.CL_MFOOTER AS CL_FOOTER,		--#05
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.UNITS,
		h.ORDER_ACCEPTED
	FROM #media_orders AS o 
	JOIN dbo.MAGAZINE_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE

END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'N')
BEGIN
	-- Newspaper (new)--------------------------------------------
	INSERT INTO #order_header
	SELECT o.ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.LINK_ID,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.ORD_PROCESS_CONTRL,
		h.MARKET_CODE,
		h.CLIENT_PO,
		h.CLIENT_REF,
		h.BUYER,
		h.VN_CODE,
		h.PUB,
		h.VR_CODE,
		h.REP1,
		h.VR_CODE2,
		h.REP2,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.PRINTED,
		10 AS FONT_SIZE,				--#05
		c.CL_MFOOTER AS CL_FOOTER,		--#05
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.UNITS,
		h.ORDER_ACCEPTED
	FROM #media_orders AS o 
	JOIN dbo.NEWSPAPER_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE	

END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'I')
BEGIN
	-- Internet--------------------------------------------
	INSERT INTO #order_header
	SELECT o.ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.LINK_ID,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.ORD_PROCESS_CONTRL,
		h.MARKET_CODE,
		h.CLIENT_PO,
		h.CLIENT_REF,
		h.BUYER,
		h.VN_CODE,
		h.PUB,
		h.VR_CODE,
		h.REP1,
		h.VR_CODE2,
		h.REP2,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.PRINTED,
		10 AS FONT_SIZE,				--#05
		c.CL_MFOOTER AS CL_FOOTER,		--#05
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.UNITS,
		h.ORDER_ACCEPTED
	FROM #media_orders AS o 
	JOIN dbo.INTERNET_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 	
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
END

IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'O')
BEGIN
	-- Outdoor--------------------------------------------
	INSERT INTO #order_header
	SELECT o.ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.LINK_ID,
		h.OFFICE_CODE, 
		h.CL_CODE,
		h.DIV_CODE, 
		h.PRD_CODE,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		h.NET_GROSS,
		h.ORD_PROCESS_CONTRL,
		h.MARKET_CODE,
		h.CLIENT_PO,
		h.CLIENT_REF,
		h.BUYER,
		h.VN_CODE,
		h.PUB,
		h.VR_CODE,
		h.REP1,
		h.VR_CODE2,
		h.REP2,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.PRINTED,
		10 AS FONT_SIZE,				--#05
		c.CL_MFOOTER AS CL_FOOTER,		--#05
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		h.UNITS,
		h.ORDER_ACCEPTED
	FROM #media_orders AS o 
	JOIN dbo.OUTDOOR_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
END

SELECT * FROM #order_header

END
