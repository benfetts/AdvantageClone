CREATE FUNCTION [dbo].[advfn_is_user_logged_in](@user_code varchar(100))
	
RETURNS bit
AS
BEGIN
	DECLARE @is_logged_in bit

	SET @is_logged_in = 0

	IF EXISTS(
			SELECT 1 
			FROM dbo.LAME_SESSION 
			WHERE SEC_USER_ID = (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER(@user_code))
			AND convert(varchar(10), SESSION_START, 102) = convert(varchar(10), getdate(), 102))

		SET @is_logged_in = 1

	RETURN @is_logged_in
END
