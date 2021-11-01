



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_APPSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[USERID],
		[TABNO],
		[APPID]
	FROM [WV_USER_QUICK_LAUNCH_APPS]

	SET @Err = @@Error

	RETURN @Err
END



























