﻿











CREATE PROCEDURE [dbo].[usp_cp_OpenMilestoneTasks] 
@CDPID int,
@TaskStatus VarChar(10) 
--@DivisionCode VarChar(6), 
--@ProductCode VarChar(6)
AS

Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

Select @Rescrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID


If @Rescrictions > 0
BEGIN
		SELECT @sql = 'SELECT    JOB_LOG.CL_CODE + '' / '' + JOB_LOG.DIV_CODE + '' / '' + JOB_LOG.PRD_CODE as CDP, str(JOB_LOG.JOB_NUMBER) + ''('' + JOB_LOG.JOB_DESC + '')'' + ''-'' + str(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''('' + JOB_COMPONENT.JOB_COMP_DESC + '')'' as JobData,
					  isnull(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') as Task, JOB_TRAFFIC_DET.FNC_CODE, 
                      JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, JOB_TRAFFIC_DET.REVISED_DUE_TIME AS DueTime, 
                      JOB_TRAFFIC_DET.JOB_NUMBER AS JobNo, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, 
                      JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
                      JOB_TRAFFIC_DET.TEMP_COMP_DATE AS TempCompleteDate, JOB_TRAFFIC_DET.MILESTONE, JOB_TRAFFIC_DET.TASK_STATUS
						FROM         JOB_LOG INNER JOIN
										  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
										  JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
										  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
										  CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND 
										  JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
						WHERE     (JOB_TRAFFIC_DET.MILESTONE = 1) AND (JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL) AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID)'
					
					if @TaskStatus = 'Projected'
						   SELECT @sql = @sql + ' AND (JOB_TRAFFIC_DET.TASK_STATUS = ''P'')'
					if @TaskStatus = 'Active'
						   SELECT @sql = @sql + ' AND (JOB_TRAFFIC_DET.TASK_STATUS = ''A'')'
END						  
ELSE
BEGIN

		SELECT @sql = 'SELECT     JOB_LOG.CL_CODE + '' / '' + JOB_LOG.DIV_CODE + '' / '' + JOB_LOG.PRD_CODE as CDP, str(JOB_LOG.JOB_NUMBER) + ''('' + JOB_LOG.JOB_DESC + '')'' + ''-'' + str(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''('' + JOB_COMPONENT.JOB_COMP_DESC + '')'' as JobData,
					  isnull(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') as Task, JOB_TRAFFIC_DET.FNC_CODE, 
                      JOB_TRAFFIC_DET.JOB_REVISED_DATE AS DueDate, JOB_TRAFFIC_DET.REVISED_DUE_TIME AS DueTime, 
                      JOB_TRAFFIC_DET.JOB_NUMBER AS JobNo, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS JobComp, 
                      JOB_TRAFFIC_DET.JOB_HRS AS HoursAllowed, JOB_TRAFFIC_DET.SEQ_NBR AS SeqNo, 
                      JOB_TRAFFIC_DET.TEMP_COMP_DATE AS TempCompleteDate, JOB_TRAFFIC_DET.MILESTONE, JOB_TRAFFIC_DET.TASK_STATUS
						FROM         JOB_LOG INNER JOIN
										  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
										  JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
										  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
						WHERE     (JOB_TRAFFIC_DET.MILESTONE = 1) AND (JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL) AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)'


END


SELECT @paramlist = '@CDPID int, @TaskStatus varchar(10)'

EXEC sp_executesql @sql, @paramlist, @CDPID, @TaskStatus 
 



	





