CREATE FUNCTION [dbo].[advfn_crm_total_contract_value](
	@contract_id	int)
		
RETURNS decimal(18,2)
WITH SCHEMABINDING 
AS
BEGIN
	DECLARE @total_contract_value decimal(18,2)
	
	SELECT @total_contract_value = SUM(ISNULL(FEE_RETAINER,0) + 
			ISNULL(FEE_INCENTIVE_BONUS,0) + 
			ISNULL(FEE_ROYALTY,0) + 
			ISNULL(FEE_PROJECT_HOURLY,0) + 
			ISNULL(MEDIA_COMMISSION,0) + 
			ISNULL(PRODUCTION_COMMISSION,0))
	FROM dbo.[CONTRACT]
	WHERE CONTRACT_ID = @contract_id
	
	RETURN @total_contract_value 	
END

GO




