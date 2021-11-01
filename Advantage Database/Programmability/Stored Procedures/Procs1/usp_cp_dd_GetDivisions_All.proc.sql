/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetDivisions_All] 
@CDPID int, 
@ClientCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

If @Rescrictions > 0
	SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '')  AS Description
	FROM         CLIENT INNER JOIN
                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
                      CP_SEC_CLIENT ON DIVISION.CL_CODE = CP_SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = CP_SEC_CLIENT.DIV_CODE
	WHERE     (CLIENT.CL_CODE = @ClientCode) AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID)
	--ORDER BY  DIVISION.DIV_CODE, DIVISION.DIV_NAME

ELSE
	SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + isnull(DIVISION.DIV_NAME, '')  AS Description
	FROM         CLIENT INNER JOIN
	                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
	WHERE     (CLIENT.CL_CODE = @ClientCode)
	--ORDER BY  DIVISION.DIV_CODE, DIVISION.DIV_NAME

























