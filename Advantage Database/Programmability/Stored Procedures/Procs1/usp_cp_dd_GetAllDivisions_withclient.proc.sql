





















/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetAllDivisions_withclient] 
@CPID Int  
AS
Declare @Restrictions Int

Set NoCount On

Select @Restrictions = Count(*) 
FROM CP_SEC_CLIENT
WHERE CDP_CONTACT_ID = @CPID

If @Restrictions > 0
	SELECT DISTINCT CLIENT.CL_CODE + ':' + DIVISION.DIV_CODE AS Code, CLIENT.CL_CODE + ' | ' + DIVISION.DIV_CODE  + ' - ' + isnull(DIVISION.DIV_NAME, '')  AS Description
	FROM         CLIENT INNER JOIN
	                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
		INNER JOIN       CP_SEC_CLIENT
			 ON DIVISION.CL_CODE = CP_SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = CP_SEC_CLIENT.DIV_CODE
	WHERE     (DIVISION.ACTIVE_FLAG = 1) AND CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID AND (CLIENT.ACTIVE_FLAG = 1)
	Order By CLIENT.CL_CODE + ':' + DIVISION.DIV_CODE,CLIENT.CL_CODE + ' | ' + DIVISION.DIV_CODE  + ' - ' + isnull(DIVISION.DIV_NAME, '')

ELSE
	SELECT     CLIENT.CL_CODE + ':' + DIVISION.DIV_CODE AS Code, CLIENT.CL_CODE + ' | ' + DIVISION.DIV_CODE  + ' - ' + isnull(DIVISION.DIV_NAME, '')  AS Description
	FROM         CLIENT INNER JOIN
	                      DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
	WHERE     (DIVISION.ACTIVE_FLAG = 1)  AND (CLIENT.ACTIVE_FLAG = 1)
	Order By CLIENT.CL_CODE, DIVISION.DIV_CODE





















