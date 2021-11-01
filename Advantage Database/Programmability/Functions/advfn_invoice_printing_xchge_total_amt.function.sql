CREATE FUNCTION [dbo].[advfn_invoice_printing_xchge_total_amt](
	@amount decimal(15,2) = 0, 
	@xchge_option tinyint = 1,
	@xchge_rate decimal(10,6) = 1)
RETURNS decimal(15,2)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @xchge_amt decimal(15,2)
		
	IF @xchge_option = 2 BEGIN
	
		SET @xchge_amt = @amount * @xchge_rate
		
	END ELSE BEGIN
	
		SET @xchge_amt = @amount	
				
	END
	
	RETURN @xchge_amt
	
END
GO


