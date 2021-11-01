

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_job_CheckAR]
@JobNum INT,
@JobComp INT

AS

SELECT COUNT(*)
FROM  ARINV_JOB
WHERE (JOB_NUMBER = @JobNum) AND (JOB_COMPONENT_NBR = @JobComp)
















