





















CREATE PROCEDURE [dbo].[usp_wv_validate_market] 
@MarketCode VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT MARKET_CODE, MARKET_DESC 
FROM MARKET
WHERE INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0
AND MARKET_CODE = @MarketCode
)
	 select 1
Else
	select  0






















