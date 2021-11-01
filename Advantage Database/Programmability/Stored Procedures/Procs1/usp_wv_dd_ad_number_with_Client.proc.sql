
























CREATE PROCEDURE [dbo].[usp_wv_dd_ad_number_with_Client] 
@CL_CODE VARCHAR(6)
AS
SELECT DISTINCT AD_NBR as code, AD_NBR + ' - ' + AD_NBR_DESC as description
FROM AD_NUMBER
WHERE ACTIVE = 1 AND (CL_CODE = @CL_CODE OR (CL_CODE IS NULL));






















