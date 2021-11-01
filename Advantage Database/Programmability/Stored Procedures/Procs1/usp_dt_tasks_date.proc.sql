


























/*****************************************************************
Webvantage Desktop 
Modication Description / Date / Developer
=============================================
This Stored Procedure gets Tasks   / 01-16-04 / Steve Moreno

******************************************************************/
CREATE PROCEDURE [dbo].[usp_dt_tasks_date] 
@EmpCode Varchar(6),
@ThisDate Varchar(10)
AS

SET NOCOUNT ON

SELECT  
	 JOB_LOG.CL_CODE + 
	' / ' + JOB_LOG.DIV_CODE + 
	' / ' + JOB_LOG.PRD_CODE + 
	' - ' + str(JOB_LOG.JOB_NUMBER) + '-' + str(JOB_COMPONENT.JOB_COMPONENT_NBR) +
	' - ' + JOB_TRAFFIC_DET.TASK_DESCRIPTION + 
	'(' + JOB_TRAFFIC_DET.FNC_CODE + ')' as Task, 
	JOB_TRAFFIC_DET.JOB_REVISED_DATE as DueDate, 
	JOB_TRAFFIC_DET.JOB_NUMBER as JobNo, 
	JOB_TRAFFIC_DET.JOB_COMPONENT_NBR as JobComp, 
	JOB_TRAFFIC_DET.SEQ_NBR as SeqNo
   -- JOB_LOG.JOB_DESC as JobDesc,
    --JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
    --JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
    
FROM JOB_LOG
INNER JOIN CLIENT
    ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
INNER JOIN JOB_COMPONENT
    ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
INNER JOIN JOB_TRAFFIC_DET
    ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
    AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
AND (JOB_TRAFFIC_DET.EMP_CODE = @EmpCode)
AND @ThisDate >= JOB_TRAFFIC_DET.TASK_START_DATE
--AND JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @ThisDate
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL
Order By JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER

























