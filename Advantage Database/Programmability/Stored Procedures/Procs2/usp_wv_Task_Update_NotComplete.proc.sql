


























CREATE PROCEDURE [dbo].[usp_wv_Task_Update_NotComplete] 
@JobNo Int, 
@JobComp Int, 
@SeqNo Int,
@EmpCode VARCHAR(6)
AS
UPDATE JOB_TRAFFIC_DET_EMPS
SET JOB_TRAFFIC_DET_EMPS.TEMP_COMP_DATE = NULL
WHERE (JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = @JobNo) 
AND   (JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = @JobComp) 
AND   (JOB_TRAFFIC_DET_EMPS.SEQ_NBR = @SeqNo)
AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @EmpCode)


























