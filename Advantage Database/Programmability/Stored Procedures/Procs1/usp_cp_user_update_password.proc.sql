




CREATE PROCEDURE [dbo].[usp_cp_user_update_password]
	@CDPCode int,
	@PassHash varchar(44)	
AS

UPDATE [dbo].[CP_USER] SET
			[PASSWORD_HASH] = @PassHash
           
WHERE
	[CDP_CONTACT_ID] = @CDPCode






SET QUOTED_IDENTIFIER ON 
