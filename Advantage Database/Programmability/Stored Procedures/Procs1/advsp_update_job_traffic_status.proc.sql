
CREATE PROCEDURE [dbo].[advsp_update_job_traffic_status]
	@job_number integer, @job_component_nbr smallint, @trf_code_in varchar(10), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON


UPDATE dbo.JOB_TRAFFIC 
   SET TRF_CODE = @trf_code_in,
	   COMPLETED_DATE = CASE WHEN COMPLETED_DATE IS NULL THEN CONVERT(varchar(10),getdate(),101) ELSE COMPLETED_DATE END
 WHERE JOB_NUMBER = @job_number 
   AND JOB_COMPONENT_NBR = @job_component_nbr
		   
IF ( @@ERROR <> 0 )
	SELECT @ret_val = -11 
ELSE	 
	SELECT @ret_val = 0
