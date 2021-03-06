
----------------------
CREATE FUNCTION [dbo].udf_ap_get_prod_adv_amt (@al_ap_id INT)  
RETURNS decimal(14,2)  /*Returns production advance bill amount for given AP */  
AS  BEGIN  	

DECLARE @ldec_prod_amt decimal(14,2)    	

SET @ldec_prod_amt = (SELECT COALESCE(SUM(ADV_BILL_NET_AMT), 0) + COALESCE(SUM(EXT_NONRESALE_TAX), 0) + COALESCE(SUM(EXT_MARKUP_AMT), 0) 
FROM ADVANCE_BILLING 
WHERE AR_INV_NBR IS NOT NULL
AND AR_INV_VOID IS NULL 
AND EXISTS (SELECT AP_PRODUCTION.AP_ID 
	FROM AP_PRODUCTION 
	WHERE AP_PRODUCTION.JOB_NUMBER = ADVANCE_BILLING.JOB_NUMBER 
	AND AP_PRODUCTION.JOB_COMPONENT_NBR = ADVANCE_BILLING.JOB_COMPONENT_NBR 
	AND AP_PRODUCTION.AP_ID = @al_ap_id) )

IF @ldec_prod_amt IS NULL 
	SET @ldec_prod_amt = 0  

RETURN @ldec_prod_amt
END
