

















/* CHANGE LOG
ST, 20060629 - Added, job/jobcomp combo doesn't exist, count returns zero
*/
CREATE PROCEDURE [dbo].[usp_wv_validate_JobCompNum]
@JobNum INT,
@JobCompNum SMALLINT

AS

SELECT
	COUNT(*)
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	JOB_NUMBER = @JobNum
	AND JOB_COMPONENT_NBR = @JobCompNum
















