

















CREATE PROCEDURE [dbo].[usp_wv_required_JobCompDateOpened] 

AS

Select ISNULL( JOB_DATE_OPENED_R ,0)
FROM AGENCY

















