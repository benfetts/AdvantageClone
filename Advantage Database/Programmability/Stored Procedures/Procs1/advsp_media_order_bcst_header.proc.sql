
CREATE PROCEDURE [dbo].[advsp_media_order_bcst_header] ( @user_code varchar(100), @order_type varchar(1) )
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

-- Temp table OrderHdrMaxRev
CREATE TABLE #OrderHdrMaxRev(
	[ORDER_NBR] int NULL,
	[REV_NBR] smallint NULL)

-- Extraction routines========================================
-- Radio------------------------------------------------------
If UPPER(@order_type) = 'R'
BEGIN
	-- Insert into temp table OrderHdrMaxRev
	INSERT INTO #OrderHdrMaxRev
	SELECT h.ORDER_NBR,
		Max(h.REV_NBR)
	FROM #media_orders AS o
	INNER JOIN dbo.RADIO_HEADER AS h
		ON o.ORDER_NBR = h.ORDER_NBR
	GROUP BY h.ORDER_NBR
	-- SELECT * FROM #OrderHdrMaxRev
	
	-- Header query
	SELECT h.ORDER_NBR,
		h.REV_NBR AS MAX_REV, 
		h.CL_CODE,
		c.CL_NAME, 
		h.DIV_CODE,
		d.DIV_NAME, 
		h.PRD_CODE,
		p.PRD_DESCRIPTION, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER, 
		cmp.CMP_NAME,
		h.MEDIA_TYPE, 
		h.NET_GROSS,
		h.MARKET_CODE,
		m.MARKET_DESC, 
		h.FLIGHT_FROM, 
		h.FLIGHT_TO,
		h.BRD_YEAR1,
		h.BRD_YEAR2,
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.CREATE_DATE,
		sc.SC_DESCRIPTION
	FROM #OrderHdrMaxRev AS o
	INNER JOIN dbo.RADIO_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
		AND o.REV_NBR = h.REV_NBR 
	INNER JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
	INNER JOIN dbo.DIVISION AS d
		ON h.CL_CODE = d.CL_CODE
		AND h.DIV_CODE = d.DIV_CODE
	INNER JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE	
	--WHERE h.ORD_PROCESS_CONTRL <> 6
END

-- Television------------------------------------------------------
If UPPER(@order_type) = 'T'
BEGIN
	-- Insert into temp table OrderHdrMaxRev
	INSERT INTO #OrderHdrMaxRev
	SELECT h.ORDER_NBR,
		Max(h.REV_NBR)
	FROM #media_orders AS o
	INNER JOIN dbo.TV_HEADER AS h
		ON o.ORDER_NBR = h.ORDER_NBR
	GROUP BY h.ORDER_NBR
	-- SELECT * FROM #OrderHdrMaxRev
	
	-- Header query
	SELECT h.ORDER_NBR,
		h.REV_NBR AS MAX_REV, 
		h.CL_CODE,
		c.CL_NAME, 
		h.DIV_CODE,
		d.DIV_NAME, 
		h.PRD_CODE,
		p.PRD_DESCRIPTION, 
		h.ORDER_DESC, 
		h.ORDER_DATE, 
		h.VN_CODE, 
		h.VR_CODE, 
		h.VR_CODE2,
		h.CMP_IDENTIFIER, 
		cmp.CMP_NAME,
		h.MEDIA_TYPE, 
		h.NET_GROSS,
		h.MARKET_CODE,
		m.MARKET_DESC, 
		h.FLIGHT_FROM, 
		h.FLIGHT_TO,
		h.BRD_YEAR1,
		h.BRD_YEAR2,
		h.ORD_PROCESS_CONTRL,
		h.STATION,
		h.REP1,
		h.REP2,
		h.BUYER,  
		h.CLIENT_PO,
		h.ORDER_COMMENT,
		h.CREATE_DATE,
		sc.SC_DESCRIPTION
	FROM #OrderHdrMaxRev AS o
	INNER JOIN dbo.TV_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
		AND o.REV_NBR = h.REV_NBR  
	INNER JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE
	INNER JOIN dbo.DIVISION AS d
		ON h.CL_CODE = d.CL_CODE
		AND h.DIV_CODE = d.DIV_CODE
	INNER JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE	 
	--WHERE h.ORD_PROCESS_CONTRL <> 6
END

END
