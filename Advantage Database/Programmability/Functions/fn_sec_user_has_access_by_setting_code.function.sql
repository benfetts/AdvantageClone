--DROP FUNCTION dbo.fn_sec_user_has_access_by_setting_code
CREATE FUNCTION dbo.fn_sec_user_has_access_by_setting_code
(

@USER_CODE VARCHAR(100),
@SETTING_CODE VARCHAR(100)

)
RETURNS BIT
AS
BEGIN
/*=========== QUERY ===========*/

	DECLARE
		@HAS_ACCESS BIT

	SET @HAS_ACCESS = 0;

	IF EXISTS (
		SELECT 1
		FROM            
			SEC_GROUP_SETTING WITH(NOLOCK) INNER JOIN
			SEC_GROUP_USER WITH(NOLOCK) ON SEC_GROUP_SETTING.SEC_GROUP_ID = SEC_GROUP_USER.SEC_GROUP_ID INNER JOIN
			SEC_USER WITH(NOLOCK) ON SEC_GROUP_USER.SEC_USER_ID = SEC_USER.SEC_USER_ID
		WHERE
			UPPER(SEC_USER.USER_CODE) = UPPER(@USER_CODE) AND SEC_GROUP_SETTING.SETTING_CODE = @SETTING_CODE AND SEC_GROUP_SETTING.STRING_VALUE = 'Y'
		)
	BEGIN
		SET @HAS_ACCESS = 1;
	END

	RETURN @HAS_ACCESS;
	
/*=========== QUERY ===========*/

END
                      

