
CREATE PROCEDURE [dbo].[usp_wv_DocumentManager_Limit_Get] 
@TYPE AS SMALLINT
AS


    IF @TYPE = 0 --REPOSITORY LIMIT
    BEGIN
        IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'REPOSITORY_LIMIT')
            BEGIN
            		INSERT INTO AGY_SETTINGS WITH
	          (
		        ROWLOCK
	          )(
			   AGY_SETTINGS_CODE,
			   AGY_SETTINGS_DESC,
			   AGY_SETTINGS_VALUE,
			   AGY_SETTINGS_DEF,
			   AGY_SETTINGS_MIN,
			   AGY_SETTINGS_MAX,
			   AGY_SETTINGS_APP,
			   AGY_SETTINGS_TAB,
			   AGY_SETTINGS_GRP,
			   AGY_SETTINGS_ORDER,
			   DTYPE_ID
		       )
		    VALUES
		      (
			    'REPOSITORY_LIMIT',
			    'Max repository in bytes',
			    '-1073741824',
			    0,
			    0,
			    0,
			    NULL,
			    NULL,
			    NULL,
			    NULL,
			    11
		      );

            END
        ELSE
            BEGIN
	            SELECT ISNULL(AGY_SETTINGS_VALUE, -1) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'REPOSITORY_LIMIT';
            END
    END	
    
    IF @TYPE = 1 --FILE SIZE LIMIT
    BEGIN
	    --SELECT ISNULL(AGY_SETTINGS_VALUE, -1) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'FILE_UPLOAD_LIMIT';
        IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'FILE_UPLOAD_LIMIT')
            BEGIN
            		INSERT INTO AGY_SETTINGS WITH
	          (
		        ROWLOCK
	          )(
			   AGY_SETTINGS_CODE,
			   AGY_SETTINGS_DESC,
			   AGY_SETTINGS_VALUE,
			   AGY_SETTINGS_DEF,
			   AGY_SETTINGS_MIN,
			   AGY_SETTINGS_MAX,
			   AGY_SETTINGS_APP,
			   AGY_SETTINGS_TAB,
			   AGY_SETTINGS_GRP,
			   AGY_SETTINGS_ORDER,
			   DTYPE_ID
		       )
		    VALUES
		      (
			    'FILE_UPLOAD_LIMIT',
			    'Max file size for uploads in bytes',
			    '-1048576',
			    0,
			    0,
			    0,
			    NULL,
			    NULL,
			    NULL,
			    NULL,
			    11
		      );

            END
        ELSE
            BEGIN
	            SELECT ISNULL(AGY_SETTINGS_VALUE, -1) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'FILE_UPLOAD_LIMIT';
            END
    END



