



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_REPORTSDelete]
(
	@REPORTID int,
	@TABNO int,
	@USERID varchar(100)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [WV_USER_QUICK_LAUNCH_REPORTS]
	WHERE
		[REPORTID] = @REPORTID AND
		[TABNO] = @TABNO AND
		UPPER([USERID]) = UPPER(@USERID)
	SET @Err = @@Error

	RETURN @Err
END



























