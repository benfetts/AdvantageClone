﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetJob_ForTraffic]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetJob_ForTraffic]
GO



/* CHANGE LOG:
==========================================================
BJL, 20060502: Changed ORDER BY to descending
BJL, 20060622: Fixed duplicate rows
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetJob_ForTraffic] 
@UserID VarChar(100),
@ClientCode VarChar(6), 
@DivisionCode VarChar(6), 
@ProductCode VarChar(6)
AS
Declare @Rescrictions Int

Set NoCount On

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

If @Rescrictions > 0
	If @OfficeCount = 0
	Begin
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
     INNER JOIN JOB_TRAFFIC 
	     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	    AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
	  WHERE ( JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) 
	    AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	    --And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	    AND (JOB_LOG.CL_CODE Like @ClientCode + '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC
	End
	Else
	Begin
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
     INNER JOIN JOB_TRAFFIC 
	     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	    AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
			INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
	  WHERE ( JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) 
	    AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	    --And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	    AND (JOB_LOG.CL_CODE Like @ClientCode + '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC
	End
	 
ELSE
	If @OfficeCount = 0
	Begin
		SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER as Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE as Description
	   FROM JOB_LOG 
     INNER JOIN JOB_COMPONENT 
	     ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
     INNER JOIN JOB_TRAFFIC 
	     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	    AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
	  WHERE ( JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12) ) 
	    --And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	    AND(JOB_LOG.CL_CODE Like @ClientCode+ '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC
	End
	Else
	Begin
		SELECT DISTINCT 
		JOB_LOG.JOB_NUMBER as Code, 
		STR(JOB_LOG.JOB_NUMBER) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' | ' + JOB_LOG.CL_CODE +' - '+ JOB_LOG.DIV_CODE+' - '+JOB_LOG.PRD_CODE as Description
	   FROM JOB_LOG 
     INNER JOIN JOB_COMPONENT 
	     ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
     INNER JOIN JOB_TRAFFIC 
	     ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	    AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
	 INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE 
	  WHERE ( JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12) ) 
	    --And JOB_TRAFFIC.COMPLETED_DATE IS NULL
	    AND(JOB_LOG.CL_CODE Like @ClientCode+ '%') 
	    AND (JOB_LOG.DIV_CODE Like @DivisionCode+ '%') 
	    AND (JOB_LOG.PRD_CODE Like @ProductCode+ '%')
       Order By JOB_LOG.JOB_NUMBER DESC
	End
	 

















