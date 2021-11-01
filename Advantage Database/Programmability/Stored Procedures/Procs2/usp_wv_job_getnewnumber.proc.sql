



















CREATE PROCEDURE [dbo].[usp_wv_job_getnewnumber] 

AS
Select LAST_NBR + 1
From ASSIGN_NBR
Where COLUMNNAME = 'JOB_NUMBER'



















