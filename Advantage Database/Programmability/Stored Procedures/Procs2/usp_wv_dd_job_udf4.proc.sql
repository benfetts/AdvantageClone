

















/* CHANGE LOG:
==========================================================
Sam, 20060501:
	Add the ISNULL check to both active query and the original.
	Tried different parts of the INACTIVE_FLAG filter to get results expected.


*/

CREATE PROCEDURE [dbo].[usp_wv_dd_job_udf4] 

AS
SELECT DISTINCT UDV_CODE as code, UDV_CODE + ' - ' + ISNULL(UDV_DESC,'(No description set!)')  as description
FROM JOB_LOG_UDV4
WHERE  (INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG <> 1)

















