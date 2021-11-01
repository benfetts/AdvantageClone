﻿






/* CHANGE LOG:
==========================================================

*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobs_JobSpecs_withClosed] 
@UserID VarChar(100)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	SELECT     JOB_LOG.JOB_NUMBER AS Code, REPLACE(STR(JOB_LOG.JOB_NUMBER),'''','') + ' - ' +REPLACE(isnull(JOB_LOG.JOB_DESC, ''),'''','') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE AS Description
	FROM         JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
						  JOB_SPECS ON JOB_COMPONENT.JOB_NUMBER = JOB_SPECS.JOB_NUMBER AND 
							  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_SPECS.JOB_COMPONENT_NBR INNER JOIN
	                      SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE		
	WHERE   (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID,JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC
ELSE
	SELECT     JOB_LOG.JOB_NUMBER as Code, REPLACE(STR(JOB_LOG.JOB_NUMBER),'''','') + ' - ' + REPLACE(isnull(JOB_LOG.JOB_DESC, ''),'''','') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE as Description
	FROM         JOB_LOG 
			 INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
						  JOB_SPECS ON JOB_COMPONENT.JOB_NUMBER = JOB_SPECS.JOB_NUMBER AND 
							  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_SPECS.JOB_COMPONENT_NBR  		 
	--WHERE     (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12))
	--And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	Group By JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE
	ORDER BY JOB_LOG.JOB_NUMBER DESC


















