/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetDivisions] 
@CDPID int, 
@ClientCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

If @Rescrictions > 0
	SELECT     DISTINCT DIVISION.DIV_CODE AS Code, DIVISION.DIV_CODE + ' - ' + ISNULL(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'')  AS Description
	FROM         CLIENT INNER JOIN
                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
                      CP_SEC_CLIENT ON DIVISION.CL_CODE = CP_SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = CP_SEC_CLIENT.DIV_CODE
	WHERE     (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.CL_CODE = @ClientCode) AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) AND (CLIENT.ACTIVE_FLAG = 1)
	--ORDER BY  DIVISION.DIV_CODE, DIVISION.DIV_NAME

ELSE
	SELECT     DISTINCT DIVISION.DIV_CODE AS Code,  DIVISION.DIV_CODE + ' - ' + ISNULL(DIVISION.DIV_NAME, '') + ' | ' + ISNULL(CLIENT.CL_CODE,'')  AS Description
	FROM         CLIENT INNER JOIN
	                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
	WHERE     (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.CL_CODE = @ClientCode) AND (CLIENT.ACTIVE_FLAG = 1)
	--ORDER BY  DIVISION.DIV_CODE, DIVISION.DIV_NAME

























