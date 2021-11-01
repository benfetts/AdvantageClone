



















CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetEstBillRateFlag] 
@Client AS VARCHAR(6),
@Division AS VARCHAR(6),
@Product AS VARCHAR(6)
AS

SELECT ISNULL(USE_EST_BILL_RATE,0) AS USE_EST_BILL_RATE
FROM PRODUCT WITH(NOLOCK)
WHERE CL_CODE = @Client AND DIV_CODE = @Division AND PRD_CODE = @Product



















