
CREATE PROCEDURE [dbo].[usp_wv_job_GetDefaultTaxCode] 

@Client VarChar(6),
@Division VarChar(6),
@Product VarChar(6)
 
AS

SET NOCOUNT ON

    SELECT 
	    ISNULL(PRD_PROD_TAX_CODE,'') AS PRD_PROD_TAX_CODE
    FROM 
	    PRODUCT WITH(NOLOCK)
    WHERE
        CL_CODE = @Client AND 
        DIV_CODE = @Division AND
        PRD_CODE = @Product

