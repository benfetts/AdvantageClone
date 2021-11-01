

























CREATE PROCEDURE [dbo].[usp_wv_comments_get_traffic_detail] 
@RowID Int
AS
Select FNC_COMMENTS From JOB_TRAFFIC_DET
Where ROWID = @RowID

























