























CREATE PROCEDURE [dbo].[usp_wv_traffic_GetMinMaxChartDate]

@JobNumber int,
@JobComponent smallint

AS

Declare @minStartDate as datetime
Declare @maxEndDate as datetime

--Get the maximum date from the end date to create the timeline.

SELECT  @maxEndDate = max(ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE))
FROM JOB_TRAFFIC_DET INNER JOIN JOB_LOG ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN JOB_COMPONENT ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
WHERE JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber and JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComponent


--Get the minimum date from the start dates to create the timeline

SELECT @minStartDate = min(JOB_TRAFFIC_DET.TASK_START_DATE)
FROM JOB_TRAFFIC_DET INNER JOIN JOB_LOG ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN JOB_COMPONENT ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
WHERE JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber and JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobComponent

Select @minStartDate as minStartDate, @maxEndDate as maxEndDate























