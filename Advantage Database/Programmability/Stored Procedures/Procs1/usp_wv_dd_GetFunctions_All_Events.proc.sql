

CREATE PROCEDURE [dbo].[usp_wv_dd_GetFunctions_All_Events] 
AS

    SELECT 
	    FNC_CODE as Code, 
	    FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') as Description
    FROM
	    FUNCTIONS WITH(NOLOCK)
    WHERE 
        ((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0)) AND (FNC_TYPE = 'I')
    ORDER BY FNC_CODE;    
		


