





















CREATE PROCEDURE [dbo].[usp_wv_validate_ad_number] 
@ADNumber VarChar(30)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT AD_NBR, AD_NBR_DESC 
FROM AD_NUMBER
WHERE ACTIVE = 1
AND AD_NBR = @ADNumber
)
	 select 1
Else
	select  0






















