

CREATE PROCEDURE [dbo].[usp_cp_user_new]
	@UserName varchar(100),
	@LoweredUsername varchar(100),
	@FullName varchar(100),
	@PassHash varchar(44),
	@LastLogin datetime,
	@CreatedbyEmpCode varchar(6),
	@CreatedTime datetime,
	@IsLocked bit,
	@Email varchar(100),
	@LoginTryCount smallint,
	@UnlockTime datetime,
	@MustChangePassword bit,
	@Theme varchar(20),
	@CDPCode int,
	@Template int,
	@Admin bit,
	@ClientCode varchar(6),
	@AlertGroup varchar(50),
	@ContactCode varchar(6)
AS

INSERT INTO [dbo].[CP_USER] (
			[USER_NAME]
           ,[LOWERED_USER_NAME]
           ,[FULL_NAME]
           ,[PASSWORD_HASH]
           ,[LAST_LOGON]
           ,[CREATED_BY]
           ,[CREATED_TIMESTAMP]
           ,[IS_LOCKED]
           ,[EMAIL_ADDRESS]
           ,[LOGIN_TRY_COUNT]
           ,[UNLOCK_TIME]
           ,[MUST_CHANGE_PASSORD]
           ,[THEME]
           ,[CDP_CONTACT_ID]
           ,[DESKTOP_TEMPLATE]
           ,[ADMIN_USER]
           ,[CL_CODE]
		   ,[ALERT_GROUP_CODE]
	       ,[AGENCY_CONTACT_CODE]
) 
VALUES (
	@UserName,
	@LoweredUsername,
	@FullName,
	@PassHash,
	@LastLogin,
	@CreatedbyEmpCode,
	@CreatedTime,
	@IsLocked,
	@Email,
	@LoginTryCount,
	@UnlockTime,
	@MustChangePassword,
	@Theme,
	@CDPCode,
	@Template,
	@Admin,
	@ClientCode,
	@AlertGroup,
	@ContactCode
)


