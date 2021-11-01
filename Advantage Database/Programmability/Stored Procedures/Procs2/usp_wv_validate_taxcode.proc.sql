


















CREATE PROCEDURE [dbo].[usp_wv_validate_taxcode] 
@TaxCode VarChar(4)

AS
SET NOCOUNT ON
 
IF EXISTS(
	SELECT 
		DISTINCT TAX_CODE
	FROM 
		SALES_TAX
	WHERE 
		(NOT (INACTIVE_FLAG = 1) 
		OR (INACTIVE_FLAG IS NULL))
		AND TAX_CODE = @TaxCode
	)	
	SELECT 1
Else
	SELECT 0


















