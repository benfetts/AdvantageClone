

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_validate_JobEstimateNum]
@JobNum INT,
@JobCompNum SMALLINT,
@EstNum INT,
@EstCompNum SMALLINT

AS

SELECT
	COUNT(*)
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	JOB_NUMBER = @JobNum 
	AND JOB_COMPONENT_NBR = @JobCompNum
	AND ESTIMATE_NUMBER = @EstNum
	AND EST_COMPONENT_NBR = @EstCompNum
















