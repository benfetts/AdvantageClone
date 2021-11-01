
























CREATE PROCEDURE [dbo].[usp_wv_dd_ad_number] 

AS
SELECT DISTINCT AD_NBR as code, AD_NBR + ' - ' + AD_NBR_DESC as description
FROM AD_NUMBER
WHERE ACTIVE = 1






















