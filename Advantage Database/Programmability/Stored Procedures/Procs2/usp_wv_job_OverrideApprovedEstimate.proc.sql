

















CREATE PROCEDURE [dbo].[usp_wv_job_OverrideApprovedEstimate] 

AS

Select ISNULL( EDIT_JOB_REQ_EST ,0)
FROM AGENCY

















