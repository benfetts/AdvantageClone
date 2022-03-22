CREATE FUNCTION [dbo].[advfn_invoice_printing_xchge_rate_amt](
	@amount decimal(16,4) = 0, 
	@xchge_option tinyint = 1,
	@xchge_rate decimal(10,6) = 1)
RETURNS decimal(16,4)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @xchge_amt decimal(16,4)
		
	IF @xchge_option = 2 BEGIN
	
		SET @xchge_amt = @amount * @xchge_rate
		
	END ELSE BEGIN
	
		SET @xchge_amt = @amount	
				
	END
	
	RETURN @xchge_amt
	
END
GO


