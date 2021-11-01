
CREATE PROCEDURE [dbo].[usp_wv_delete_missing_time_dtl] 
@EMP_CODE AS Varchar(6)
AS


	DELETE MISSING_TIME_DTL
	WHERE EMP_CODE = @EMP_CODE




