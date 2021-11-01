﻿


CREATE PROCEDURE [dbo].[proc_CP_DESKTOP_OBJECTSInsert]
(
	@ID int = NULL output,
	@CATEGORY_ID int,
	@NAME varchar(50),
	@DESCRIPTION varchar(100),
	@SECURITY_LEVEL int,
	@ACTIVE bit,
	@ASCX_FILENAME varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [CP_DESKTOP_OBJECTS]
	(
		[CATEGORY_ID],
		[NAME],
		[DESCRIPTION],
		[SECURITY_LEVEL],
		[ACTIVE],
		[ASCX_FILENAME]
	)
	VALUES
	(
		@CATEGORY_ID,
		@NAME,
		@DESCRIPTION,
		@SECURITY_LEVEL,
		@ACTIVE,
		@ASCX_FILENAME
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END




