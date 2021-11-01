

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_job_CheckAP]
@JobNum INT,
@Office Varchar(6)

AS

SELECT COUNT(*)
FROM AP_PRODUCTION 
WHERE (JOB_NUMBER = @JobNum) AND (OFFICE_CODE = @Office)
















