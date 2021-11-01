



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_APPSDelete]
(
	@APPID int,
	@TABNO int,
	@USERID varchar(100)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [WV_USER_QUICK_LAUNCH_APPS]
	WHERE
		[APPID] = @APPID AND
		[TABNO] = @TABNO AND
		UPPER([USERID]) = UPPER(@USERID)
	SET @Err = @@Error

	RETURN @Err
END



























