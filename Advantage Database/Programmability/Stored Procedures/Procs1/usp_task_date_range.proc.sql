


























/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_task_date_range] 
@EmpCode Varchar(6),
@StartDate Varchar(10),
@EndDate Varchar(10)
AS

SET NOCOUNT ON

SELECT  
    JOB_LOG.CL_CODE as CCode,
    JOB_LOG.DIV_CODE as DCode,
    JOB_LOG.PRD_CODE as PCode,
    JOB_LOG.JOB_NUMBER as JobNum,
    JOB_LOG.JOB_DESC as JobDesc,
    JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
    JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
    STR(DATEPART(day, JOB_TRAFFIC_DET.JOB_REVISED_DATE)) as ThisDay,
   -- JOB_TRAFFIC_DET.TASK_DESCRIPTION + '(' + JOB_TRAFFIC_DET.FNC_CODE + ')' as Task
   JOB_TRAFFIC_DET.TASK_DESCRIPTION as Task
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
AND JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate
AND JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate
Order By JOB_TRAFFIC_DET.JOB_REVISED_DATE

























