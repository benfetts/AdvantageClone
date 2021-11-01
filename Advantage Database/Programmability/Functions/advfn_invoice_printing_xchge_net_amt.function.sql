CREATE FUNCTION [dbo].[advfn_invoice_printing_xchge_net_amt](
	@net_amt decimal(15,2) = 0, 
	@comm_amt decimal(15,2) = 0,  
	@show_comm_option tinyint = 0,
	@tax_amt decimal(15,2) = 0,  
	@show_tax_option tinyint = 0,	
	@xchge_option tinyint = 1,		
	@xchge_rate decimal(10,6) = 1)	
RETURNS decimal(15,2)
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @xchge_amt decimal(15,2)
	
	SET @xchge_amt = @net_amt
	
	IF @show_comm_option = 0 BEGIN
	
		SET @xchge_amt = @xchge_amt + @comm_amt
				
	END
	
	IF @show_tax_option = 0 BEGIN
	
		SET @xchge_amt = @xchge_amt + @tax_amt	
					
	END
	
	IF @xchge_option = 2 BEGIN
	
		SET @xchge_amt = @xchge_amt * @xchge_rate
				
	END
	
	RETURN @xchge_amt
	
END
GO


