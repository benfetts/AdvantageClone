


























/* CHANGE LOG:
==========================================================
BJL, 20060502:
	Changed ORDER BY to descending
*/

CREATE PROCEDURE [dbo].[usp_cp_dd_GetAllJobs] 
@CDPID int
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

If @Rescrictions > 0
	SELECT     JOB_LOG.JOB_NUMBER AS Code, STR(JOB_LOG.JOB_NUMBER) + ' - ' +isnull(JOB_LOG.JOB_DESC, '') AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT     JOB_LOG.JOB_NUMBER as Code, str(JOB_LOG.JOB_NUMBER) + ' - ' + isnull(JOB_LOG.JOB_DESC, '') as Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	Group By JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC
	ORDER BY JOB_LOG.JOB_NUMBER DESC


















