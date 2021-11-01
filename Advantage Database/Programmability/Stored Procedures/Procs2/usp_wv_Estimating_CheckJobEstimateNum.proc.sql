

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_Estimating_CheckJobEstimateNum]
@EstNum INT

AS

SELECT
	COUNT(*)
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum 
	
















