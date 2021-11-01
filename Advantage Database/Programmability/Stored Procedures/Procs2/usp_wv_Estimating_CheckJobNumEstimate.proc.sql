

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_Estimating_CheckJobNumEstimate]
@EstNum INT

AS

SELECT
	JOB_NUMBER, JOB_COMPONENT_NBR
FROM
	JOB_COMPONENT WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum 
	
















