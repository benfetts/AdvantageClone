

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_Estimating_CheckJobEstimateCompNum]
@EstNum INT,
@EstComp INT

AS

SELECT
	COUNT(*)
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum AND EST_COMPONENT_NBR = @EstComp
	
















