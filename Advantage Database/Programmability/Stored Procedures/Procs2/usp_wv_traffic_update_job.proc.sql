




















CREATE PROCEDURE [dbo].[usp_wv_traffic_update_job] 
@RowID Int, 
@CompDate smalldatetime, 
@Status VarChar(10)
--@Comments ntext
AS

Update JOB_TRAFFIC
Set       TRF_CODE = @Status, 
	COMPLETED_DATE = @CompDate
	--TRF_COMMENTS = @Comments
Where ROWID = @RowID




















