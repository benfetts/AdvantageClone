
CREATE PROCEDURE [dbo].[advsp_media_order_print_header] ( @user_code varchar(100), @order_type varchar(1) )
-- @order_type m=magazine, n=newspaper, i=internet, o=outdoor

AS
BEGIN
	SET NOCOUNT ON;

-- ==========================================================
-- Temp table #media_orders----------------------------------
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

---- ==========================================================
---- Temp table #max_rev_seq----------------------------------
--CREATE TABLE #max_rev_seq(
--	ORDER_NBR				int NULL,
--	LINE_NBR				smallint NULL,
--	MAX_REV_NBR				smallint NULL,
--	MAX_SEQ_NBR				smallint)

-- ==========================================================
-- Magazine (new)--------------------------------------------
If UPPER(@order_type) = 'M'
BEGIN
	SELECT h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		c.CL_NAME,
		h.DIV_CODE,
		dv.DIV_NAME, 
		h.PRD_CODE, 
		p.PRD_DESCRIPTION,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		cmp.CMP_NAME,
		h.MARKET_CODE,
		m.MARKET_DESC,
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
		sc.SC_DESCRIPTION  
	FROM #media_orders AS o 
	JOIN dbo.MAGAZINE_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE 
	JOIN dbo.DIVISION AS dv
		ON h.CL_CODE = dv.CL_CODE
		AND h.DIV_CODE = dv.DIV_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE	
END

-- Newspaper (new)--------------------------------------------
If UPPER(@order_type) = 'N'
BEGIN
	SELECT h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		c.CL_NAME,
		h.DIV_CODE,
		dv.DIV_NAME, 
		h.PRD_CODE, 
		p.PRD_DESCRIPTION,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		cmp.CMP_NAME,
		h.MARKET_CODE,
		m.MARKET_DESC,
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
		sc.SC_DESCRIPTION
	FROM #media_orders AS o 
	JOIN dbo.NEWSPAPER_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE 
	JOIN dbo.DIVISION AS dv
		ON h.CL_CODE = dv.CL_CODE
		AND h.DIV_CODE = dv.DIV_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE		
END

-- Internet--------------------------------------------
If UPPER(@order_type) = 'I'
BEGIN
	SELECT h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		c.CL_NAME,
		h.DIV_CODE,
		dv.DIV_NAME, 
		h.PRD_CODE, 
		p.PRD_DESCRIPTION,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		cmp.CMP_NAME,
		h.MARKET_CODE,
		m.MARKET_DESC,
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
		sc.SC_DESCRIPTION
	FROM #media_orders AS o 
	JOIN dbo.INTERNET_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE 
	JOIN dbo.DIVISION AS dv
		ON h.CL_CODE = dv.CL_CODE
		AND h.DIV_CODE = dv.DIV_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE		
END

-- Outdoor--------------------------------------------
If UPPER(@order_type) = 'O'
BEGIN
	SELECT h.MEDIA_TYPE,
		h.ORDER_NBR,
		h.ORDER_DATE,
		h.MODIFIED_DATE,
		h.REVISED_FLAG,
		h.ORDER_DESC,
		h.OFFICE_CODE, 
		h.CL_CODE, 
		c.CL_NAME,
		h.DIV_CODE,
		dv.DIV_NAME, 
		h.PRD_CODE, 
		p.PRD_DESCRIPTION,
		h.CMP_CODE,
		h.CMP_IDENTIFIER,
		cmp.CMP_NAME,
		h.MARKET_CODE,
		m.MARKET_DESC,
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
		sc.SC_DESCRIPTION
	FROM #media_orders AS o 
	JOIN dbo.OUTDOOR_HEADER AS h 
		ON o.ORDER_NBR = h.ORDER_NBR 
	JOIN dbo.CLIENT AS c
		ON h.CL_CODE = c.CL_CODE 
	JOIN dbo.DIVISION AS dv
		ON h.CL_CODE = dv.CL_CODE
		AND h.DIV_CODE = dv.DIV_CODE
	JOIN dbo.PRODUCT AS p
		ON h.CL_CODE = p.CL_CODE
		AND h.DIV_CODE = p.DIV_CODE
		AND h.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.CAMPAIGN AS cmp
		ON h.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	LEFT JOIN dbo.MARKET AS m
		ON h.MARKET_CODE = m.MARKET_CODE
	JOIN dbo.SALES_CLASS AS sc
		ON h.MEDIA_TYPE = sc.SC_CODE		
END

END
