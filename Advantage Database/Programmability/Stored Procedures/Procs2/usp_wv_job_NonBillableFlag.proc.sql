






CREATE PROCEDURE [dbo].[usp_wv_job_NonBillableFlag] 
@JobNumber Int,
@JobCompNumber Int
AS



Select ISNULL(NOBILL_FLAG,0)
FROM JOB_COMPONENT
WHERE JOB_NUMBER = @JobNumber and JOB_COMPONENT_NBR = @JobCompNumber

















