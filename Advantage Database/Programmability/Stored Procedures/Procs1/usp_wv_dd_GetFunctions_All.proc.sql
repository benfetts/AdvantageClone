















































CREATE PROCEDURE [dbo].[usp_wv_dd_GetFunctions_All] 

AS
/*
		SELECT FNC_CODE as Code, ISNULL(FNC_DESCRIPTION,'') as Description
		FROM FUNCTIONS
		WHERE FNC_TYPE='E'  and (FUNCTIONS.FNC_INACTIVE = 0 or FUNCTIONS.FNC_INACTIVE IS NULL)

		SELECT FNC_CODE as Code, ISNULL(FNC_DESCRIPTION,'') as Description
		FROM FUNCTIONS
		WHERE FNC_TYPE='V'  and (FUNCTIONS.FNC_INACTIVE = 0 or FUNCTIONS.FNC_INACTIVE IS NULL)
		AND (EX_FLAG = 1)
*/
SELECT 
	FNC_CODE as Code, 
	FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') as Description
FROM
	FUNCTIONS
WHERE 
		((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0))
		-- Needed to restrict for use on expense
		AND ((FNC_TYPE = 'E') OR  (FNC_TYPE = 'V'))
		AND (EX_FLAG = 1)











































