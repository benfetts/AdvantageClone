﻿























/* CHANGE LOG:

*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetJob_JobVersion] 
@UserID VarChar(100),
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	 SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER AS Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE as Description
	   FROM JOB_LOG 
     INNER JOIN JOB_COMPONENT 
	     ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
     INNER JOIN SEC_CLIENT 
	     ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
	    AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
	    AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE  
	 INNER JOIN
		JOB_VER_HDR ON dbo.JOB_COMPONENT.JOB_NUMBER = JOB_VER_HDR.JOB_NUMBER AND 
        JOB_COMPONENT.JOB_COMPONENT_NBR =  JOB_VER_HDR.JOB_COMPONENT_NBR 
	  WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 
	    --And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	    AND (JOB_LOG.CL_CODE Like @ClientCode + '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC
ELSE
	 SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER as Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE as Description
	   FROM JOB_LOG 
     INNER JOIN JOB_COMPONENT 
	     ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER  
	 INNER JOIN
		JOB_VER_HDR ON dbo.JOB_COMPONENT.JOB_NUMBER = JOB_VER_HDR.JOB_NUMBER AND 
        JOB_COMPONENT.JOB_COMPONENT_NBR =  JOB_VER_HDR.JOB_COMPONENT_NBR
	  WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_LOG.CL_CODE Like @ClientCode+ '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC

















