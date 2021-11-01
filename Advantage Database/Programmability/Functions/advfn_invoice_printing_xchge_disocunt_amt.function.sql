CREATE FUNCTION [dbo].[advfn_invoice_printing_xchge_disocunt_amt](
	@total_amount decimal(15,2),
	@fnc_code varchar(6),
	@client_discount_code varchar(6) = NULL,
	@jobcomp_discount_code varchar(6) = NULL, 
	@xchge_option tinyint = 1,
	@xchge_rate decimal(10,6) = 1)
RETURNS decimal(15,2)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @xchge_amt decimal(15,2)
	DECLARE @discount_amt decimal(15,2)
	DECLARE @client_discount_percentage decimal(3,2)
	DECLARE @client_discount_amt decimal(15,2)
	DECLARE @jobcomp_discount_percentage decimal(3,2)
	DECLARE @jobcomp_discount_amt decimal(15,2)
		
	SET @client_discount_amt = 0
	SET @jobcomp_discount_amt = 0

	IF ISNULL(@fnc_code, '') <> '' BEGIN
	
		IF ISNULL(@client_discount_code, '') <> '' BEGIN
	
			IF NOT EXISTS(SELECT CLIENT_DISCOUNT_EXCLUSION_ID FROM dbo.CLIENT_DISCOUNT_EXCLUSION WHERE CLIENT_DISCOUNT_CODE = @client_discount_code AND FNC_CODE = @fnc_code) BEGIN
			
				SET @client_discount_percentage = 0

				SELECT 
					@client_discount_percentage = [PERCENT]
				FROM
					dbo.CLIENT_DISCOUNT
				WHERE
					CLIENT_DISCOUNT_CODE = @client_discount_code
					
				IF ISNULL(@client_discount_percentage, 0) <> 0 BEGIN
	
					SET @client_discount_amt = @total_amount * @client_discount_percentage
				
				END

			END
		
		END
	
		IF ISNULL(@jobcomp_discount_code, '') <> '' BEGIN
	
			IF NOT EXISTS(SELECT CLIENT_DISCOUNT_EXCLUSION_ID FROM dbo.CLIENT_DISCOUNT_EXCLUSION WHERE CLIENT_DISCOUNT_CODE = @jobcomp_discount_code AND FNC_CODE = @fnc_code) BEGIN
			
				SET @jobcomp_discount_percentage = 0

				SELECT 
					@jobcomp_discount_percentage = [PERCENT]
				FROM
					dbo.CLIENT_DISCOUNT
				WHERE
					CLIENT_DISCOUNT_CODE = @jobcomp_discount_code
					
				IF ISNULL(@jobcomp_discount_percentage, 0) <> 0 BEGIN
	
					SET @jobcomp_discount_amt = @total_amount * @jobcomp_discount_percentage
				
				END

			END
		
		END
	
	END
	
	SET @discount_amt = @client_discount_amt + @jobcomp_discount_amt

	IF @xchge_option = 2 BEGIN
	
		SET @xchge_amt = @discount_amt * @xchge_rate
		
	END ELSE BEGIN
	
		SET @xchge_amt = @discount_amt	
				
	END
	
	RETURN @xchge_amt
	
END


GO