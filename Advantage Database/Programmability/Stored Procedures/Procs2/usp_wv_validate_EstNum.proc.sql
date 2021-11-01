

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_validate_EstNum]
@EstNum INT

AS

SELECT
	COUNT(*)
FROM
	ESTIMATE_LOG WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum
















