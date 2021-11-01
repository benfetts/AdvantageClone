

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetEstimateNumJob]
@JobNum INT

AS

SELECT
	ISNULL(ESTIMATE_NUMBER,0) AS ESTIMATE_NUMBER
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	JOB_NUMBER = @JobNum 
	
















