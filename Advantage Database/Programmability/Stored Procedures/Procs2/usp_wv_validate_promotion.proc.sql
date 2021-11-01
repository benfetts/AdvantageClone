





















CREATE PROCEDURE [dbo].[usp_wv_validate_promotion] 
@PromotionCode VarChar(8)
AS
Set NoCount On
 
If Exists(
SELECT PROMO_CODE
FROM PROMO_TYPE
WHERE ACTIVE = 1
AND PROMO_CODE = @PromotionCode
)
	 select 1
Else
	select  0





















