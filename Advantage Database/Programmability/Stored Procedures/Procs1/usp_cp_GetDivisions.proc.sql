/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_GetDivisions] 
@CDPID int 

AS

SELECT DISTINCT CP_SEC_CLIENT.DIV_CODE AS Code, DIVISION.DIV_CODE + ' - ' + ISNULL(DIVISION.DIV_NAME, '') AS Description
FROM         CP_SEC_CLIENT LEFT OUTER JOIN
                      DIVISION ON CP_SEC_CLIENT.CL_CODE = DIVISION.CL_CODE AND CP_SEC_CLIENT.DIV_CODE = DIVISION.DIV_CODE
WHERE     (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID)


























