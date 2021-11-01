/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_GetProducts] 
@CDPID int,
@ClientCode varchar(6),
@DivisionCode varchar(6) 

AS

SELECT DISTINCT 
                      dbo.CP_SEC_CLIENT.PRD_CODE AS Code, dbo.PRODUCT.PRD_CODE + ' - ' + ISNULL(dbo.PRODUCT.PRD_DESCRIPTION, '') AS Description, 
                      dbo.CP_SEC_CLIENT.CL_CODE, dbo.CP_SEC_CLIENT.DIV_CODE
FROM         dbo.CP_SEC_CLIENT LEFT OUTER JOIN
                      dbo.PRODUCT ON dbo.CP_SEC_CLIENT.CL_CODE = dbo.PRODUCT.CL_CODE AND dbo.CP_SEC_CLIENT.DIV_CODE = dbo.PRODUCT.DIV_CODE AND 
                      dbo.CP_SEC_CLIENT.PRD_CODE = dbo.PRODUCT.PRD_CODE
WHERE     (dbo.CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) AND (dbo.CP_SEC_CLIENT.DIV_CODE = @DivisionCode) AND (dbo.CP_SEC_CLIENT.CL_CODE = @ClientCode) OR
                      (dbo.CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) AND (dbo.CP_SEC_CLIENT.DIV_CODE = ' ') AND (dbo.CP_SEC_CLIENT.CL_CODE = @ClientCode)



























