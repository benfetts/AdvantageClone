


















/*
ST, 20060621:
added process controls to where clause; as found, only 6 and 12 were in ther
added order by clause, added the "desc" to job number
*/


/*****************************************************************
Gets All Jobs for Timesheet
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobCompsTimesheet_withClosed] 
@UserID VarChar(100)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	SELECT     ltrim(str(JOB_LOG.JOB_NUMBER)) + '-' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
		ltrim(str(JOB_LOG.JOB_NUMBER)) + '-' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) 
		+ ' | ' + JOB_COMPONENT.JOB_COMP_DESC
	     + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	--GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
ELSE
	SELECT     ltrim(str(JOB_LOG.JOB_NUMBER)) + '-' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code, 
		ltrim(str(JOB_LOG.JOB_NUMBER)) + '-' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) 
		+ ' | ' + JOB_COMPONENT.JOB_COMP_DESC
	     + ' | ' + JOB_LOG.CL_CODE + ' - ' + JOB_LOG.DIV_CODE + ' - ' + JOB_LOG.PRD_CODE + '' AS Description
	FROM         JOB_LOG 
			 INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,9,10,13)) 
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	--GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC,  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC

















