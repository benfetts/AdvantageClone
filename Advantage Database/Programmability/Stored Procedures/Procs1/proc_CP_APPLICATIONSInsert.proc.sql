


CREATE PROCEDURE [dbo].[proc_CP_APPLICATIONSInsert]
(
	@APPID int = NULL output,
	@CATID int,
	@APPNAME varchar(50),
	@URL varchar(50),
	@IMAGEPATH varchar(50) = NULL,
	@ACTIVE bit,
	@SORTORDER varchar(1) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [CP_APPLICATIONS]
	(
		[CATID],
		[APPNAME],
		[URL],
		[IMAGEPATH],
		[ACTIVE],
		[SORTORDER]
	)
	VALUES
	(
		@CATID,
		@APPNAME,
		@URL,
		@IMAGEPATH,
		@ACTIVE,
		@SORTORDER
	)

	SET @Err = @@Error

	SELECT @APPID = SCOPE_IDENTITY()

	RETURN @Err
END





