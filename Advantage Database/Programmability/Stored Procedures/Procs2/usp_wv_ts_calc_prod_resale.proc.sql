--DROP PROCEDURE [dbo].[usp_wv_ts_calc_prod_resale] 
CREATE PROCEDURE [dbo].[usp_wv_ts_calc_prod_resale] 
@ext_amt decimal(9,3), 
@mu_amt decimal(9,3), 
@tax_pct decimal(5,3), 
@tax decimal(9,3) OUTPUT
	
AS

SET NOCOUNT ON
	
SELECT @tax = ROUND(
			  (ISNULL(@ext_amt,0.000) + ISNULL(@mu_amt,0.000)) 
			  * ISNULL(@tax_pct,0.000) / 100.000
		      , 3);