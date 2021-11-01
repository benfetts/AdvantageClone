
CREATE FUNCTION [dbo].[advfn_calc_prod_vendor] ( @ext_amt decimal(9,2), @state_pct decimal(7,4), @county_pct decimal(7,4), @city_pct decimal(7,4) )
RETURNS decimal(9,2)
AS
BEGIN
	DECLARE @tax_amt decimal(9,2)
	SELECT @tax_amt = ROUND( @ext_amt * ( @state_pct / 100 ), 2 ) 
					+ ROUND( @ext_amt * ( @county_pct / 100 ), 2 ) 
					+ ROUND( @ext_amt * ( @city_pct / 100 ), 2 )
	RETURN @tax_amt
END
