
CREATE FUNCTION [dbo].[advfn_calc_prod_resale] ( @ext_amt decimal(9,2), @mu_amt decimal(9,2), @tax_pct decimal(8,4) )
RETURNS decimal(9,2)
AS
BEGIN
	DECLARE @tax_amt decimal(9,2)
	SELECT @tax_amt = ( ROUND(( @ext_amt + @mu_amt ) * @tax_pct / 100, 2 ) )
	RETURN @tax_amt
END
