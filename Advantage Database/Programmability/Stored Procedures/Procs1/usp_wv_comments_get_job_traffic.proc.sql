

























CREATE PROCEDURE [dbo].[usp_wv_comments_get_job_traffic] 
@RowID Int
AS
Select TRF_COMMENTS From JOB_TRAFFIC
Where ROWID = @RowID

























