

















/* CHANGE LOG
CP, 20071105 - Added. If PO number not in Purchase Order table, returns a zero
*/
CREATE PROCEDURE [dbo].[usp_wv_validate_PONum]
@PONum INT

AS

SELECT
	COUNT(*)
FROM
	PURCHASE_ORDER
WHERE
	PO_NUMBER = @PONum
















