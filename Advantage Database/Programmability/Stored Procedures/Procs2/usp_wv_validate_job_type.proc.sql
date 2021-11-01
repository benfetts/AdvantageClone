





















CREATE PROCEDURE [dbo].[usp_wv_validate_job_type] 
@JobTypeCode VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT JT_CODE, JT_DESC 
FROM JOB_TYPE
WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
AND JT_CODE = @JobTypeCode
)
	 select 1
Else
	select  0





















