



















CREATE PROCEDURE [dbo].[usp_wv_job_component_next_number]
@JobNumber Integer
 AS

Select Max(JOB_COMPONENT_NBR) + 1
From JOB_COMPONENT
WHERE JOB_NUMBER = @JobNumber



















