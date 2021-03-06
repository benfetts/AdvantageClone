


CREATE PROCEDURE [dbo].[proc_CP_APPLICATIONSUpdate]
(
	@APPID int,
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

	UPDATE [CP_APPLICATIONS]
	SET
		[CATID] = @CATID,
		[APPNAME] = @APPNAME,
		[URL] = @URL,
		[IMAGEPATH] = @IMAGEPATH,
		[ACTIVE] = @ACTIVE,
		[SORTORDER] = @SORTORDER
	WHERE
		[APPID] = @APPID


	SET @Err = @@Error


	RETURN @Err
END




