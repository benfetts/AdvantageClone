----------------------
CREATE FUNCTION [dbo].udf_ap_get_billable_amt (@al_ap_id INT, @as_vn_category VARCHAR(1))  RETURNS decimal(14,2)  
/*Returns billable amount for given AP */  
AS  
BEGIN     

DECLARE @ldec_prod_amt decimal(14,2)     
DECLARE @ldec_media_amt decimal(14,2)     
DECLARE @ldec_total_amt decimal(14,2) 
   
SET @ldec_prod_amt = (  
	SELECT COALESCE(SUM(AP.AP_PROD_EXT_AMT), 0) + COALESCE(SUM(AP.EXT_NONRESALE_TAX), 0)  
	FROM AP_PRODUCTION AP  
	WHERE  AP.AP_ID = @al_ap_id  	
	AND (AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL)  )    

IF @as_vn_category = 'N'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(DISBURSED_AMT), 0)
	FROM AP_NEWSPAPER WHERE AP_ID = @al_ap_id )  

ELSE  IF @as_vn_category = 'M'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(DISBURSED_AMT), 0)
	FROM AP_MAGAZINE WHERE AP_ID = @al_ap_id )  

ELSE  IF @as_vn_category = 'R'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(EXT_NET_AMT), 0) + COALESCE(SUM(VENDOR_TAX), 0) + 
		COALESCE(SUM(NETCHARGES), 0)+ COALESCE(SUM(DISC_AMT), 0)
	FROM AP_RADIO WHERE AP_ID = @al_ap_id )  

ELSE  IF @as_vn_category = 'T'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(EXT_NET_AMT), 0) + COALESCE(SUM(VENDOR_TAX), 0) + 
		COALESCE(SUM(NETCHARGES), 0)+ COALESCE(SUM(DISC_AMT), 0)
	FROM AP_TV WHERE AP_ID = @al_ap_id )  

ELSE  IF @as_vn_category = 'O'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(NET_AMT), 0) + COALESCE(SUM(VENDOR_TAX), 0)  + 
		COALESCE(SUM(NETCHARGES), 0) + COALESCE(SUM(DISCOUNT_AMT), 0)
	FROM AP_OUTDOOR WHERE AP_ID = @al_ap_id )  

ELSE  IF @as_vn_category = 'I'  	
	SET @ldec_media_amt = (
	SELECT COALESCE(SUM(NET_AMT), 0) + COALESCE(SUM(VENDOR_TAX), 0)  + 
		COALESCE(SUM(NETCHARGES), 0) + COALESCE(SUM(DISCOUNT_AMT), 0)
	FROM AP_INTERNET WHERE AP_ID = @al_ap_id )    

IF @ldec_media_amt IS NULL  	
	SET @ldec_media_amt = 0    
IF @ldec_prod_amt IS NULL  	
	SET @ldec_prod_amt = 0    

SET @ldec_total_amt = @ldec_media_amt + @ldec_prod_amt    

RETURN @ldec_total_amt  

END
