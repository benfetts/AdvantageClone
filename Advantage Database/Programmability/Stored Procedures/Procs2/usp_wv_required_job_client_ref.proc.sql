

















/* CHANGE LOG:
==========================================================
ST, 20050505:
	- created this sproc to check if client is required when inserting a job
*/
CREATE PROCEDURE [dbo].[usp_wv_required_job_client_ref]
AS

SELECT
	ISNULL(JOB_CLI_REF_R,0)
FROM
	AGENCY

















