



















/* CHANGE LOG:
==========================================================
ST, 20050504:
remove control id so that the archived/closed jobs show up in lookups

*/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetJob_timesheet_withClosed]
@CDPID int,
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

If @Rescrictions > 0
	SELECT DISTINCT
		JOB_LOG.JOB_NUMBER AS Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
		+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
	WHERE      (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) AND 
	(CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	AND  (JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, CP_SEC_CLIENT.CDP_CONTACT_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER AS Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') + '(' + JOB_LOG.CL_CODE + ', ' 
		+ JOB_LOG.DIV_CODE + ',' + JOB_LOG.PRD_CODE + ')' AS Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	AND
	(JOB_LOG.CL_CODE Like @ClientCode) 
	AND (JOB_LOG.DIV_CODE Like @DivisionCode) 
	AND (JOB_LOG.PRD_CODE Like @ProductCode)
	ORDER BY JOB_LOG.JOB_NUMBER DESC

















