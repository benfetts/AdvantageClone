/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_GetProductsTest] 
@CDPID int,
@ClientCode varchar(6),
@DivisionCode varchar(6) 

AS

SELECT DISTINCT 
                      CP_SEC_CLIENT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') AS Description, 
                      CP_SEC_CLIENT.CL_CODE
FROM         CP_SEC_CLIENT LEFT OUTER JOIN
                      PRODUCT ON CP_SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND CP_SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND 
                      CP_SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE
WHERE     (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) AND (CP_SEC_CLIENT.CL_CODE = @ClientCode)




























