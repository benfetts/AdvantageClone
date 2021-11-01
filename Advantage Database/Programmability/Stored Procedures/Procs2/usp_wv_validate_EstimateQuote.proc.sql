

















/* CHANGE LOG

*/
CREATE PROCEDURE [dbo].[usp_wv_validate_EstimateQuote]
@EstNum INT,
@EstCompNum SMALLINT,
@QuoteNum SMALLINT

AS

SELECT
	COUNT(*)
FROM
	ESTIMATE_QUOTE WITH (NOLOCK)
WHERE
	ESTIMATE_NUMBER = @EstNum
	AND EST_COMPONENT_NBR = @EstCompNum
	AND EST_QUOTE_NBR = @QuoteNum
















