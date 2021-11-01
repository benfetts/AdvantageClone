
CREATE PROCEDURE [dbo].[sp_calc_prod_resale] @ext_amt decimal(9,2), @mu_amt decimal(9,2), @tax_pct decimal(5,3), 
	@tax decimal(9,2) OUTPUT
	
	AS

SET NOCOUNT ON
	
SELECT @tax = ROUND(( @ext_amt + @mu_amt ) * @tax_pct / 100, 2 ) 
