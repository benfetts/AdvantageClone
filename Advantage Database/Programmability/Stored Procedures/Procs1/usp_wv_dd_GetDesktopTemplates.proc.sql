
CREATE PROCEDURE [dbo].[usp_wv_dd_GetDesktopTemplates] 
    @IS_ADMIN SMALLINT,
    @USER_ID VARCHAR(100)
AS

    IF @IS_ADMIN = 1
        BEGIN
            SELECT     
	            WV_TMPLT_HDR_ID AS code, 
	            ISNULL(WV_TMPLT_DESC+' ('+CREATE_USER+')','') AS description
            FROM        
	            WV_DESK_TMPLT_HDR WITH(NOLOCK)
	        ORDER BY
	            CREATE_USER,WV_TMPLT_DESC;
	            
	    END
	ELSE
	    BEGIN
            SELECT     
	            WV_TMPLT_HDR_ID AS code, 
	            WV_TMPLT_DESC AS description
            FROM        
	            WV_DESK_TMPLT_HDR WITH(NOLOCK)
	        WHERE
	            CREATE_USER = @USER_ID
	        ORDER BY
	            CREATE_USER,WV_TMPLT_DESC;
	    END
	
