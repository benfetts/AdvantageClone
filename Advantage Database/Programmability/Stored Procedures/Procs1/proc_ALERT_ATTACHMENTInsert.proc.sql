﻿


























CREATE PROCEDURE [dbo].[proc_ALERT_ATTACHMENTInsert]
(
	@ATTACHMENT_ID int = NULL output,
	@ALERT_ID int,
	@USER_CODE varchar(100),
	@GENERATED_DATE smalldatetime,
	@EMAILSENT bit,
	@DOCUMENT_ID int,
	@USER_CODE_CP int
)
AS
if @USER_CODE IS NULL
BEGIN
	SET @USER_CODE = ''
END

BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ALERT_ATTACHMENT]
	(
		[ALERT_ID],
		[USER_CODE],
		[GENERATED_DATE],
		[EMAILSENT],
		[DOCUMENT_ID],
		[USER_CODE_CP]
	)
	VALUES
	(
		@ALERT_ID,
		@USER_CODE,
		@GENERATED_DATE,
		@EMAILSENT,
		@DOCUMENT_ID,
		@USER_CODE_CP
	)

	SET @Err = @@Error

	SELECT @ATTACHMENT_ID = SCOPE_IDENTITY()

	RETURN @Err
END


























