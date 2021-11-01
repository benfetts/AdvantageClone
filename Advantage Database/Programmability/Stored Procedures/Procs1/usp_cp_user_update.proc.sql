




CREATE PROCEDURE [dbo].[usp_cp_user_update]
	@UserName varchar(100),
	@LoweredUsername varchar(100),
	@FullName varchar(100),
	@PassHash varchar(44),
	@Email varchar(100),
	@Theme varchar(20),
	@CDPCode int,
	@Template int,
	@Admin bit,
	@ClientCode varchar(6),
	@AlertGroup varchar(50),
	@ContactCode varchar(6)
AS

UPDATE [dbo].[CP_USER] SET
			[USER_NAME] = @UserName
           ,[LOWERED_USER_NAME] = @LoweredUsername
           ,[FULL_NAME] = @FullName
           ,[PASSWORD_HASH] = @PassHash
           ,[EMAIL_ADDRESS] = @Email
           ,[THEME] = @Theme
           ,[CDP_CONTACT_ID] = @CDPCode
           ,[DESKTOP_TEMPLATE] = @Template
           ,[ADMIN_USER] = @Admin
           ,[CL_CODE] = @ClientCode
		   ,[ALERT_GROUP_CODE] = @AlertGroup
		   ,[AGENCY_CONTACT_CODE] = @ContactCode
WHERE
	[CDP_CONTACT_ID] = @CDPCode



















