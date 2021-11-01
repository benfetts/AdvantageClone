
























CREATE PROCEDURE [dbo].[usp_wv_dd_market] 

AS
SELECT DISTINCT MARKET_CODE as code, cast(MARKET_CODE as VarChar(10)) + ' - ' + ISNULL(MARKET_DESC, '') as description
FROM MARKET
WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0





















