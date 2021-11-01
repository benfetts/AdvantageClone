
CREATE PROCEDURE [dbo].[advsp_media_order_bcst_monthly] ( @user_code varchar(100), @order_type varchar(1) )
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

-- Extraction routines========================================
-- Radio------------------------------------------------------
If UPPER(@order_type) = 'R'
BEGIN
	SELECT d.ORDER_NBR,
		d.LINE_NBR, 
		d.MONTH_IND, 
		d.MONTH_SHORT, 
		d.BRDCAST_YEAR, 
		SUM(d.SPOTS) AS SPOTS,
		h.NET_GROSS AS [NET_GROSS1],
		SUM(d.[LINE_NET]) AS [LINE_NET],
		SUM(d.[COMM_AMT]) AS [COMM_AMT],
		SUM(d.[REBATE_AMT]) AS [REBATE_AMT],
		SUM(d.[DISCOUNT]) AS [DISCOUNT],
		SUM(d.[VENDOR_TAX]) AS [VENDOR_TAX],
		SUM(d.[STATE_TAX] + d.[COUNTY_TAX] + d.[CITY_TAX]) AS [SALES_TAX],
		SUM(d.BILLING_AMT) AS [BILLING_AMT]
	FROM #media_orders AS o
	INNER JOIN dbo.V_RADIO_DETAIL1 AS d 
		ON o.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.RADIO_HEADER AS h 
		ON (d.REV_NBR = h.REV_NBR) 
		AND (d.ORDER_NBR = h.ORDER_NBR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.MONTH_IND, d.MONTH_SHORT, d.BRDCAST_YEAR, h.NET_GROSS
	HAVING (((SUM(d.SPOTS))<>0))
END

-- Television------------------------------------------------------
If UPPER(@order_type) = 'T'
BEGIN
	SELECT d.ORDER_NBR,
		d.LINE_NBR, 
		d.MONTH_IND, 
		d.MONTH_SHORT, 
		d.BRDCAST_YEAR,
		SUM(d.SPOTS) AS SPOTS,
		h.NET_GROSS AS [NET_GROSS1],
		SUM(d.[LINE_NET]) AS [LINE_NET],
		SUM(d.[COMM_AMT]) AS [COMM_AMT],
		SUM(d.[REBATE_AMT]) AS [REBATE_AMT],
		SUM(d.[DISCOUNT]) AS [DISCOUNT],
		SUM(d.[VENDOR_TAX]) AS [VENDOR_TAX],
		SUM(d.[STATE_TAX] + d.[COUNTY_TAX] + d.[CITY_TAX]) AS [SALES_TAX],
		SUM(d.BILLING_AMT) AS [BILLING_AMT]
	FROM #media_orders AS o
	INNER JOIN dbo.V_TV_DETAIL1 AS d 
		ON o.ORDER_NBR = d.ORDER_NBR
	INNER JOIN dbo.TV_HEADER AS h 
		ON (d.REV_NBR = h.REV_NBR) 
		AND (d.ORDER_NBR = h.ORDER_NBR)
	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.MONTH_IND, d.MONTH_SHORT, d.BRDCAST_YEAR, h.NET_GROSS
	HAVING (((SUM(d.SPOTS))<>0))
END

END
