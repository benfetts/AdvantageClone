SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_media1_order_bcst_header]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_media1_order_bcst_header]
GO

CREATE PROCEDURE [dbo].[advsp_media1_order_bcst_header] ( @user_code varchar(100) )

--Stored procedure to extract OLD BROADCAST HEADER information
-- #00 05/27/09 - initial release
-- #01 08/04/09 - added HOUSE_COMMENT
-- #02 02/05/11 - added FIRST_MTH**, LAST_MTH** etc.
-- #03 02/09/11 - added standard invoice footer comment (CL_FOOTER)
-- #04 03/11/11 - added FONT_SIZE
-- #05 07/20/12 - added new columns BILL_COOP_CODE -> FISCAL_PERIOD_CODE
-- #06 11/01/12 - added join to product table to get OFFICE_CODE
-- #07 01/06/14 - v660 replaced std comment with CL_MFOOTER (orig v650 on 11/29/12)

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
	BILL_TYPE_FLAG					smallint NULL,
	NET_GROSS						smallint NULL,
	MARKET_CODE						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS,
	FLIGHT_FROM						smalldatetime NULL, 
	FLIGHT_TO						smalldatetime NULL,
	BRD_YEAR1						smallint NULL,
	BRD_YEAR2						smallint NULL,
	FIRST_MTH_YR1					smallint NULL,
	LAST_MTH_YR1					smallint NULL,
	FIRST_MTH_YR2					smallint NULL,
	LAST_MTH_YR2					smallint NULL,
	ORD_PROCESS_CONTRL				smallint NULL,
	STATION							smallint NULL,
	REP1							smallint NULL,
	REP2							smallint NULL,
	BUYER							varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,  
	CLIENT_PO						varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_COMMENT					text,
	HOUSE_COMMENT					text,
	CREATE_DATE						smalldatetime NULL,
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

-- Temp table OrderHdrMaxRev----------------------------------
CREATE TABLE #max_rev(
	[ORDER_NBR] int NULL,
	[REV_NBR] smallint NULL)

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
-- Radio------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'R')
BEGIN
	-- Insert into temp table OrderHdrMaxRev
	INSERT INTO #max_rev
	SELECT h.ORDER_NBR,
		Max(h.REV_NBR)
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_HEADER AS h
		ON o.ORDER_NBR = h.ORDER_NBR
	GROUP BY h.ORDER_NBR
	-- SELECT * FROM #max_rev
	
	-- Header query
	INSERT INTO #order_header
	SELECT 'R' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.REV_NBR AS MAX_REV, 
		h.LINK_ID,
		p.OFFICE_CODE,			--#06
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER,
		h.BILL_TYPE_FLAG,
		h.NET_GROSS,
		h.MARKET_CODE, 
		h.FLIGHT_FROM, 
		h.FLIGHT_TO,
		h.BRD_YEAR1,
		h.BRD_YEAR2,
		h.FIRST_MTH_YR1,
		h.LAST_MTH_YR1,
		h.FIRST_MTH_YR2,
		h.LAST_MTH_YR1,
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.CREATE_DATE,
		10 AS FONT_SIZE,				--#07
		c.CL_MFOOTER AS CL_FOOTER,		--#07
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		ORDER_ACCEPTED = NULL
	FROM #max_rev AS o
	INNER JOIN dbo.RADIO_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
		AND o.REV_NBR = h.REV_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE	

	--Clear temp tables
	DELETE FROM #max_rev
END

-- Television------------------------------------------------------
IF EXISTS (SELECT ORDER_TYPE FROM #order_type WHERE ORDER_TYPE = 'T')
BEGIN
	-- Insert into temp table #max_rev
	INSERT INTO #max_rev
	SELECT h.ORDER_NBR,
		Max(h.REV_NBR)
	FROM #media_orders AS o
	INNER JOIN dbo.TV_HEADER AS h
		ON o.ORDER_NBR = h.ORDER_NBR
	GROUP BY h.ORDER_NBR
	-- SELECT * FROM #max_rev
	
	-- Header query
	INSERT INTO #order_header
	SELECT 'T' AS ORDER_TYPE, 
		h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.REV_NBR AS MAX_REV,
		h.LINK_ID,
		p.OFFICE_CODE,			--#06
		h.CL_CODE, 
		h.DIV_CODE, 
		h.PRD_CODE, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER,
		h.BILL_TYPE_FLAG,
		h.NET_GROSS,
		h.MARKET_CODE, 
		h.FLIGHT_FROM, 
		h.FLIGHT_TO,
		h.BRD_YEAR1,
		h.BRD_YEAR2,
		h.FIRST_MTH_YR1,
		h.LAST_MTH_YR1,
		h.FIRST_MTH_YR2,
		h.LAST_MTH_YR1,
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.HOUSE_COMMENT,
		h.CREATE_DATE,
		10 AS FONT_SIZE,				--#07
		c.CL_MFOOTER AS CL_FOOTER,		--#07
		h.BILL_COOP_CODE,
		h.FISCAL_PERIOD_CODE,
		ORDER_ACCEPTED = NULL
	FROM #max_rev AS o
	INNER JOIN dbo.TV_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
		AND o.REV_NBR = h.REV_NBR  
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE	

	--Clear temp tables
	DELETE FROM #max_rev
END

SELECT * FROM #order_header

END
