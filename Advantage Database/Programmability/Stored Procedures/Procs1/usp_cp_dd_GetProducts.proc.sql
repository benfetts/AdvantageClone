

















/* CHANGE LOG:
==========================================================
ST, 20060609:
Added the "UPPER"  to wrap around @UserID
Done for filtering lookup on job jacket.

*/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetProducts] 
@CDPID int , 
@ClientCode VarChar(6), 
@DivisionCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID

If @Rescrictions > 0
	SELECT     PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + CLIENT.CL_CODE + ', ' + DIVISION.DIV_CODE  AS Description
	FROM         CLIENT INNER JOIN
                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE INNER JOIN
                      CP_SEC_CLIENT ON PRODUCT.CL_CODE = CP_SEC_CLIENT.CL_CODE AND PRODUCT.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
                      PRODUCT.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
	WHERE     (PRODUCT.ACTIVE_FLAG = 1) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode)
		AND CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID

ELSE
	SELECT     PRODUCT.PRD_CODE AS Code, PRODUCT.PRD_CODE + ' - ' + ISNULL(PRODUCT.PRD_DESCRIPTION, '') + ' | ' + CLIENT.CL_CODE + ', ' + DIVISION.DIV_CODE  AS Description
	FROM         CLIENT INNER JOIN
	                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
	                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
	WHERE     (PRODUCT.ACTIVE_FLAG = 1) AND (PRODUCT.CL_CODE = @ClientCode) AND (PRODUCT.DIV_CODE = @DivisionCode)

















