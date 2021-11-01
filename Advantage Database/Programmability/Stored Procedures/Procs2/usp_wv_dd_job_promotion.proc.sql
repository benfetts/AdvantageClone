






















CREATE PROCEDURE [dbo].[usp_wv_dd_job_promotion] 

AS
SELECT DISTINCT PROMO_CODE as code, PROMO_CODE + ' - ' + PROMO_DESC as description
FROM PROMO_TYPE
WHERE ACTIVE = 1






















