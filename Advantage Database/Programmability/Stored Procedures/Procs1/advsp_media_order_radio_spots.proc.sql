﻿
CREATE PROCEDURE [dbo].[advsp_media_order_radio_spots] ( @user_code varchar(100) )
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

-- Main select statement for sp
SELECT a.ORDER_NBR, 
	a.LINE_NBR, 
	Max(a.SEQ_NBR) AS MaxOfSEQ_NBR, 
	a.BRDCAST_YEAR,
	Sum(a.SPOTS_WK1) AS SPOTS_WK1, 
	Sum(a.SPOTS_WK2) AS SPOTS_WK2, 
	Sum(a.SPOTS_WK3) AS SPOTS_WK3, 
	Sum(a.SPOTS_WK4) AS SPOTS_WK4, 
	Sum(a.SPOTS_WK5) AS SPOTS_WK5, 
	Sum(a.SPOTS_WK6) AS SPOTS_WK6, 
	Sum(a.SPOTS_WK7) AS SPOTS_WK7, 
	Sum(a.SPOTS_WK8) AS SPOTS_WK8, 
	Sum(a.SPOTS_WK9) AS SPOTS_WK9, 
	Sum(a.SPOTS_WK10) AS SPOTS_WK10, 
	Sum(a.SPOTS_WK11) AS SPOTS_WK11, 
	Sum(a.SPOTS_WK12) AS SPOTS_WK12, 
	Sum(a.SPOTS_WK13) AS SPOTS_WK13, 
	Sum(a.SPOTS_WK14) AS SPOTS_WK14, 
	Sum(a.SPOTS_WK15) AS SPOTS_WK15, 
	Sum(a.SPOTS_WK16) AS SPOTS_WK16, 
	Sum(a.SPOTS_WK17) AS SPOTS_WK17, 
	Sum(a.SPOTS_WK18) AS SPOTS_WK18, 
	Sum(a.SPOTS_WK19) AS SPOTS_WK19, 
	Sum(a.SPOTS_WK20) AS SPOTS_WK20, 
	Sum(a.SPOTS_WK21) AS SPOTS_WK21, 
	Sum(a.SPOTS_WK22) AS SPOTS_WK22, 
	Sum(a.SPOTS_WK23) AS SPOTS_WK23, 
	Sum(a.SPOTS_WK24) AS SPOTS_WK24, 
	Sum(a.SPOTS_WK25) AS SPOTS_WK25, 
	Sum(a.SPOTS_WK26) AS SPOTS_WK26, 
	Sum(a.SPOTS_WK27) AS SPOTS_WK27, 
	Sum(a.SPOTS_WK28) AS SPOTS_WK28, 
	Sum(a.SPOTS_WK29) AS SPOTS_WK29, 
	Sum(a.SPOTS_WK30) AS SPOTS_WK30, 
	Sum(a.SPOTS_WK31) AS SPOTS_WK31, 
	Sum(a.SPOTS_WK32) AS SPOTS_WK32, 
	Sum(a.SPOTS_WK33) AS SPOTS_WK33, 
	Sum(a.SPOTS_WK34) AS SPOTS_WK34, 
	Sum(a.SPOTS_WK35) AS SPOTS_WK35, 
	Sum(a.SPOTS_WK36) AS SPOTS_WK36, 
	Sum(a.SPOTS_WK37) AS SPOTS_WK37, 
	Sum(a.SPOTS_WK38) AS SPOTS_WK38, 
	Sum(a.SPOTS_WK39) AS SPOTS_WK39, 
	Sum(a.SPOTS_WK40) AS SPOTS_WK40, 
	Sum(a.SPOTS_WK41) AS SPOTS_WK41, 
	Sum(a.SPOTS_WK42) AS SPOTS_WK42, 
	Sum(a.SPOTS_WK43) AS SPOTS_WK43, 
	Sum(a.SPOTS_WK44) AS SPOTS_WK44, 
	Sum(a.SPOTS_WK45) AS SPOTS_WK45, 
	Sum(a.SPOTS_WK46) AS SPOTS_WK46, 
	Sum(a.SPOTS_WK47) AS SPOTS_WK47, 
	Sum(a.SPOTS_WK48) AS SPOTS_WK48, 
	Sum(a.SPOTS_WK49) AS SPOTS_WK49, 
	Sum(a.SPOTS_WK50) AS SPOTS_WK50, 
	Sum(a.SPOTS_WK51) AS SPOTS_WK51, 
	Sum(a.SPOTS_WK52) AS SPOTS_WK52, 
	Sum(a.SPOTS_WK53) AS SPOTS_WK53
FROM dbo.RADIO_SPOTS AS a
INNER JOIN #media_orders AS o
	ON a.ORDER_NBR = o.ORDER_NBR
GROUP BY a.ORDER_NBR, a.LINE_NBR, a.BRDCAST_YEAR

END
