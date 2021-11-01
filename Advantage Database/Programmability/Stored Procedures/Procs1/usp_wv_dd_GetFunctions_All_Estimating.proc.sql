

CREATE PROCEDURE [dbo].[usp_wv_dd_GetFunctions_All_Estimating] 
AS

    SELECT 
	    FNC_CODE as Code, 
	    CASE WHEN FNC_TYPE = 'E' THEN FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') + ' - Employee'
			 WHEN FNC_TYPE = 'C' THEN FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') + ' - Client OOP'
			 WHEN FNC_TYPE = 'I' THEN FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') + ' - Income Only'	
			 WHEN FNC_TYPE = 'V' THEN FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') + ' - Vendor'
		END as Description
    FROM
	    FUNCTIONS WITH(NOLOCK)
    WHERE 
        ((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0))
    ORDER BY FNC_TYPE, FNC_CODE
		


