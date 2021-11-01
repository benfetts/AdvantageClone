

















/* CHANGE LOG
ST, 20060629 - Added. If job num not in job log, returns a zero
*/
CREATE PROCEDURE [dbo].[usp_wv_validate_JobNum]
@JobNum INT

AS

SELECT
	COUNT(*)
FROM
	JOB_LOG WITH (NOLOCK)
WHERE
	JOB_NUMBER = @JobNum
















