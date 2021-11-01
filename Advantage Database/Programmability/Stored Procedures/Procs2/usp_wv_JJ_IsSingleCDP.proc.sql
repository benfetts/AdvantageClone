

















/*
ST:
	Created 2006/06/02
	Check whether a client has only one division and one product
	using natural inner join to count recs, if only one row, means only one cdp combo
	return the combo with colon as delimiter
	else if there is more than one record, it means there is more than one cdp combo 
	return zero (as false) if more than one cdp
*/

CREATE PROCEDURE [dbo].[usp_wv_JJ_IsSingleCDP] 
@ClientCode VARCHAR(6)
AS
 
IF
(
SELECT COUNT(*) AS ct
FROM CLIENT INNER JOIN
DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
WHERE (CLIENT.CL_CODE LIKE @ClientCode+'%')
) = 1
	BEGIN
		SELECT CLIENT.CL_CODE+':'+DIVISION.DIV_CODE+':'+PRODUCT.PRD_CODE AS ReturnVal
		FROM  CLIENT INNER JOIN
		DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
		PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
		WHERE (CLIENT.CL_CODE LIKE @ClientCode+'%')
	END
ELSE
	BEGIN	
		SELECT 0 AS ReturnVal
	END

















