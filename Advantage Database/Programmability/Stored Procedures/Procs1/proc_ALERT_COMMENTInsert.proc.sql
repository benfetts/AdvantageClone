﻿--DROP PROCEDURE [dbo].[proc_ALERT_COMMENTInsert]
CREATE PROCEDURE [dbo].[proc_ALERT_COMMENTInsert]
(
	@COMMENT_ID int = NULL output,
	@ALERT_ID int,
	@USER_CODE varchar(100) = NULL,
	@GENERATED_DATE smalldatetime = NULL,
	@COMMENT text = NULL,
	@EMAILSENT bit,
	@USER_CODE_CP int = NULL,
	@DOCUMENT_LIST varchar(max)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	IF NOT @COMMENT IS NULL
	BEGIN
		INSERT
		INTO [ALERT_COMMENT]
		(
			[ALERT_ID],
			[USER_CODE],
			[GENERATED_DATE],
			[COMMENT],
			[EMAILSENT],
			[USER_CODE_CP],
			[DOCUMENT_LIST]
		)
		VALUES
		(
			@ALERT_ID,
			@USER_CODE,
			@GENERATED_DATE,
			@COMMENT,
			@EMAILSENT,
			@USER_CODE_CP,
			@DOCUMENT_LIST
		)

		SET @Err = @@Error

		SELECT @COMMENT_ID = SCOPE_IDENTITY()

		RETURN @Err
	END

END