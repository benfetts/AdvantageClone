

















CREATE PROCEDURE [dbo].[usp_wv_required_JobCompDueDate] 

AS

Select ISNULL( JOB_FIRST_USE_DT_R ,0)
FROM AGENCY

















