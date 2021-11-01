

















/* CHANGE LOG:
==========================================================
ST, 20060626:
	- created this sproc to check if client is required when inserting a job
*/
CREATE PROCEDURE [dbo].[usp_wv_required_job_unique_client_ref] 
AS

SELECT
	ISNULL(CLIENT_REF,0)
FROM
	AGENCY



















