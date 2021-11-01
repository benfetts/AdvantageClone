



























CREATE PROCEDURE [dbo].[proc_WV_USER_QUICK_LAUNCH_REPORTSInsert]
(
	@USERID varchar(100),
	@TABNO int,
	@REPORTID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [WV_USER_QUICK_LAUNCH_REPORTS]
	(
		[USERID],
		[TABNO],
		[REPORTID]
	)
	VALUES
	(
		@USERID,
		@TABNO,
		@REPORTID
	)

	SET @Err = @@Error


	RETURN @Err
END



























