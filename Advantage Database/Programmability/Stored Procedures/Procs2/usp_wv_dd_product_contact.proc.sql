





















CREATE PROCEDURE [dbo].[usp_wv_dd_product_contact] 
@Client VarChar(6), 
@Division VarChar(6),
@Product VarChar(6)
AS
SELECT DISTINCT CONT_CODE as code, CONT_CODE + ' - ' + CONT_FML  as description
FROM PRD_CONTACT 
WHERE CL_CODE = @Client
AND DIV_CODE = @Division
AND PRD_CODE = @Product





















