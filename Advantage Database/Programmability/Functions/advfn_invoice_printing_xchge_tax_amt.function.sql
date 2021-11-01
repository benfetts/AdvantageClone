CREATE FUNCTION [dbo].[advfn_invoice_printing_xchge_tax_amt](
	@amount decimal(15,2) = 0, 
	@show_tax_option tinyint = 0,	
	@xchge_option tinyint = 1,	
	@xchge_rate decimal(10,6) = 1)
RETURNS decimal(15,2)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @xchge_amt decimal(15,2)
	
	IF @show_tax_option = 1 BEGIN
	
		SET @xchge_amt = @amount

	END ELSE BEGIN
	
		SET @xchge_amt = 0	
					
	END
	
	IF @xchge_option = 2 BEGIN
	
		SET @xchge_amt = @xchge_amt * @xchge_rate
				
	END
	
	RETURN @xchge_amt
	
END
GO


