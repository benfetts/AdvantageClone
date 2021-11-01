

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_validate_EstimateCompNum]
@EstNum INT,
@EstCompNum SMALLINT

AS

SELECT
	COUNT(*)
FROM
	ESTIMATE_COMPONENT WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum
	AND EST_COMPONENT_NBR = @EstCompNum
















