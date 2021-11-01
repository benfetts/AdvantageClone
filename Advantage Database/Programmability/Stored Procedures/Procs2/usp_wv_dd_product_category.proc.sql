























CREATE PROCEDURE [dbo].[usp_wv_dd_product_category]
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6)
 AS

SELECT     PROD_CAT_CODE as Code, PROD_CAT_CODE + ' - ' + PROD_CAT_DESC as Description,  PROD_CAT_DESC as DescriptionOnly
FROM         PRODUCT_CATEGORY
Where CL_CODE = @Client
AND DIV_CODE = @Division
AND PRD_CODE = @Product
AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)























