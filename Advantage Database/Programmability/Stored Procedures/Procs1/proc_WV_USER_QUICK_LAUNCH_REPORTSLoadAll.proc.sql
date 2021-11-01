



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_REPORTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[USERID],
		[TABNO],
		[REPORTID]
	FROM [WV_USER_QUICK_LAUNCH_REPORTS]

	SET @Err = @@Error

	RETURN @Err
END



























