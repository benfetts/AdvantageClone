CREATE PROCEDURE [dbo].[advsp_media_manager_delete_other_user_selection]
	@sec_user_id int
AS

DECLARE	@USER_CODE varchar(100)

IF NOT EXISTS(SELECT 1 
				FROM dbo.LAME_SESSION 
				WHERE SEC_USER_ID = @sec_user_id 
				AND convert(varchar(10), SESSION_START, 102) = convert(varchar(10), getdate(), 102)) BEGIN
	
	SELECT @USER_CODE = USER_CODE
	FROM dbo.SEC_USER
	WHERE SEC_USER_ID = @sec_user_id 

	EXEC dbo.advsp_media_manager_delete_selections @USER_CODE

	DELETE dbo.MEDIA_MGR_SEARCH_SETTING
	WHERE UPPER(MEDIA_MGR_SEARCH_SETTING_USER_CODE) = UPPER(@USER_CODE) 

	SELECT 1

END ELSE
	SELECT 0
