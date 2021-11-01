



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_REPORTSLoadByPrimaryKey]
(
	@REPORTID int,
	@TABNO int,
	@USERID varchar(100)
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[USERID],
		[TABNO],
		[REPORTID]
	FROM [WV_USER_QUICK_LAUNCH_REPORTS]
	WHERE
		([REPORTID] = @REPORTID) AND
		([TABNO] = @TABNO) AND
		(UPPER([USERID]) = UPPER(@USERID))

	SET @Err = @@Error

	RETURN @Err
END



























