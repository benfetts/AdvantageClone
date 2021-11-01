



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_APPSInsert]
(
	@USERID varchar(100),
	@TABNO int,
	@APPID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [WV_USER_QUICK_LAUNCH_APPS]
	(
		[USERID],
		[TABNO],
		[APPID]
	)
	VALUES
	(
		@USERID,
		@TABNO,
		@APPID
	)

	SET @Err = @@Error


	RETURN @Err
END



























