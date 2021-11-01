
CREATE PROCEDURE [dbo].[advsp_media1_invoice_coop_amounts] @user_code varchar(100)
AS
BEGIN
SET NOCOUNT ON;

-- ==========================================================
-- MAIN DATA TABLE
-- ==========================================================
CREATE TABLE #med_inv_amts_coop (
	ORDER_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	COOP_ID							int NULL,
	BILL_COOP_CODE					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DIV_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	PRD_CODE						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
--	REC_TYPE						varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ORDER_NBR						int NULL,
	LINE_NBR						smallint NULL,
	COOP_PCT						decimal(7,3) NULL,
	AR_INV_NBR						int NULL,
	AR_INV_SEQ						smallint NULL,
	AR_TYPE							varchar(3) COLLATE SQL_Latin1_General_CP1_CS_AS,
	NET_AMT							decimal(15,2) NULL,
	NETCHARGES						decimal(15,2) NULL,
	DISCOUNT_AMT					decimal(15,2) NULL,
	COMM_AMT						decimal(15,2) NULL,
	REBATE_AMT						decimal(15,2) NULL,
	STATE_TAX						decimal(15,2) NULL,
	COUNTY_TAX						decimal(15,2) NULL,
	CITY_TAX						decimal(15,2) NULL,
	VENDOR_TAX						decimal(15,2) NULL,
	LINE_TOTAL						decimal(15,2) NULL,
	ADDL_CHARGE						decimal(15,2) NULL)

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

-- ==========================================================
-- EXTRACTION ROUTINES
-- ==========================================================
INSERT INTO #med_inv_amts_coop  
SELECT
	o.ORDER_TYPE,
	cl.COOP_ID,
	cl.BILL_COOP_CODE,
	cl.CL_CODE,
	cl.DIV_CODE,
	cl.PRD_CODE,
	cl.ORDER_NBR,
	COALESCE(cd.LINE_NBR, cl.LINE_NBR),
	cl.COOP_PCT, 
	cl.AR_INV_NBR,
	cl.AR_INV_SEQ,
	cl.AR_TYPE,
	SUM(cd.NET_AMT),
	SUM(ISNULL(cd.NETCHARGE1, 0) + ISNULL(cd.NETCHARGE2, 0) + ISNULL(cd.NETCHARGE3, 0) + 
		ISNULL(cd.NETCHARGE4, 0) + ISNULL(cd.NETCHARGE5, 0) + ISNULL(cd.NETCHARGE6, 0)) AS NETCHARGES,  
	SUM(ISNULL(cd.LINE_DISCOUNT,0)), 
	SUM(ISNULL(cd.COMM_AMT,0)), 
	SUM(ISNULL(cd.REBATE_AMT,0)),
	SUM(ISNULL(cd.STATE_TAX,0)),
	SUM(ISNULL(cd.COUNTY_TAX,0)), 
	SUM(ISNULL(cd.CITY_TAX,0)),
	SUM(ISNULL(cd.VENDOR_TAX,0)),
	SUM(ISNULL(cd.LINE_TOTAL,0)),
	SUM(ISNULL(cd.ADDL_CHARGE,0))
FROM  #media_orders o 
INNER JOIN dbo.AR_COOP_LOG cl
	ON o.ORDER_NBR = cl.ORDER_NBR
INNER JOIN dbo.AR_COOP_DTL cd
	ON cl.COOP_ID = cd.COOP_ID
WHERE ISNULL(cl.AR_INV_SEQ, 0) NOT IN(0,99)
GROUP BY o.ORDER_TYPE, cl.COOP_ID, cl.BILL_COOP_CODE, cl.CL_CODE, cl.DIV_CODE, cl.PRD_CODE, cl.ORDER_NBR, 
	COALESCE(cd.LINE_NBR, cl.LINE_NBR), cl.COOP_PCT, cl.AR_INV_NBR,	cl.AR_INV_SEQ, cl.AR_TYPE 

END

SELECT * FROM #med_inv_amts_coop 

DROP TABLE #med_inv_amts_coop, #media_orders
