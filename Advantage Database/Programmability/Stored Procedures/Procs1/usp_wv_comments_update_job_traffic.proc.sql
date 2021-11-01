

























CREATE PROCEDURE [dbo].[usp_wv_comments_update_job_traffic] 
@RowID Int, 
@Comments ntext
AS

Update JOB_TRAFFIC
Set     TRF_COMMENTS = @Comments
Where ROWID = @RowID

























