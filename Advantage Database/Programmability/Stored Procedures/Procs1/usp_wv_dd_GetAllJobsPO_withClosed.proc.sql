




















/* CHANGE LOG:
==========================================================
ST, 20060613:
	Following the pattern I see last dev was taking.
	This is a duplicate of the sproc with the same name except "timesheet" instead of "JobJacket" in the sproc name
	sproc's created to filter job lookup on jobjacket
	did not modify base sproc's; duplicated and changed name instead;still fearful of breaking something somewhere else
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobsPO_withClosed] 
@UserID VarChar(100)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	SELECT     JOB_LOG.JOB_NUMBER AS Code, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') 
		     + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	WHERE   
	(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,5,6,7,10,11,12)) AND 
	(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT     JOB_LOG.JOB_NUMBER AS Code, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') 
		     + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE   
	 (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,5,6,7,10,11,12)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC,  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC

















