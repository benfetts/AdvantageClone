








CREATE PROCEDURE [dbo].[proc_CP_USERInsert]
(
	@USER_GUID uniqueidentifier,
	@USER_NAME varchar(100),
	@LOWERED_USER_NAME varchar(100),
	@FULL_NAME varchar (100),
	@PASSWORD_HASH varchar(44),
	@LAST_LOGON datetime = NULL,
	@CREATED_BY varchar(6) = NULL,
	@CREATED_TIMESTAMP datetime = NULL,
	@IS_LOCKED bit = NULL,
	@EMAIL_ADDRESS varchar(100) = NULL,
	@LOGIN_TRY_COUNT smallint,
	@UNLOCK_TIME datetime = NULL,
	@MUST_CHANGE_PASSORD bit,
	@THEME varchar(20) = NULL,
	@CDP_CONTACT_ID int,
	@DESKTOP_TEMPLATE int,
	@WEB_ID varchar(50),
	@ADMIN_USER bit,
	@CL_CODE varchar(6),
    @ALERT_GROUP_CODE varchar(50),
	@AGENCY_CONTACT_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @USER_GUID IS NULL
		 SET @USER_GUID = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [CP_USER]
	(
		[USER_GUID],
		[USER_NAME],
		[LOWERED_USER_NAME],
		[FULL_NAME],
		[PASSWORD_HASH],
		[LAST_LOGON],
		[CREATED_BY],
		[CREATED_TIMESTAMP],
		[IS_LOCKED],
		[EMAIL_ADDRESS],
		[LOGIN_TRY_COUNT],
		[UNLOCK_TIME],
		[MUST_CHANGE_PASSORD],
		[THEME],
		[CDP_CONTACT_ID],
		[DESKTOP_TEMPLATE],
		[WEB_ID],
		[ADMIN_USER],
		[CL_CODE],
		[ALERT_GROUP_CODE],
		[AGENCY_CONTACT_CODE]
	)
	VALUES
	(
		@USER_GUID,
		@USER_NAME,
		@LOWERED_USER_NAME,
		@FULL_NAME,
		@PASSWORD_HASH,
		@LAST_LOGON,
		@CREATED_BY,
		@CREATED_TIMESTAMP,
		@IS_LOCKED,
		@EMAIL_ADDRESS,
		@LOGIN_TRY_COUNT,
		@UNLOCK_TIME,
		@MUST_CHANGE_PASSORD,
		@THEME,
		@CDP_CONTACT_ID,
		@DESKTOP_TEMPLATE,
		@WEB_ID,
		@ADMIN_USER,
		@CL_CODE,
		@ALERT_GROUP_CODE,
		@AGENCY_CONTACT_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END







