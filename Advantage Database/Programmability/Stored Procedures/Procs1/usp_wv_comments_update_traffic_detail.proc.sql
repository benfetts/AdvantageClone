

























CREATE PROCEDURE [dbo].[usp_wv_comments_update_traffic_detail] 
@RowID Int, 
@TaskComments nText
AS
Update JOB_TRAFFIC_DET
SET     	FNC_COMMENTS = @TaskComments
Where ROWID = @RowID

























