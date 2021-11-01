





















CREATE PROCEDURE [dbo].[usp_wv_validate_product_category] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6),
@ProductCategory VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT PROD_CAT_CODE
FROM         PRODUCT_CATEGORY WITH (NOLOCK)
Where CL_CODE = @Client
AND DIV_CODE = @Division
AND PRD_CODE = @Product
AND PROD_CAT_CODE = @ProductCategory
AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
)
	 select 1
Else
	select  0





















