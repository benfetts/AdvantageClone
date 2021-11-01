




CREATE PROCEDURE [dbo].[usp_cp_user_update_lock]
	@CDPCode int,
	@IsLocked bit,
	@LoginTryCount smallint,
	@UnlockTime datetime
AS

UPDATE [dbo].[CP_USER] SET
			[IS_LOCKED] = @IsLocked
           ,[LOGIN_TRY_COUNT] = @LoginTryCount
           ,[UNLOCK_TIME] = @UnlockTime
WHERE
	[CDP_CONTACT_ID] = @CDPCode



















