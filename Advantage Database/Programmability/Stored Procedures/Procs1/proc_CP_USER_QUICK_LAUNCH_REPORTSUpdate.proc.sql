





CREATE PROCEDURE [dbo].[proc_CP_USER_QUICK_LAUNCH_REPORTSUpdate]
(
	@CDP_CONTACT_ID int,
	@TAB_ID int,
	@REPORT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [CP_USER_QUICK_LAUNCH_REPORTS]
	SET
		[TAB_ID] = @TAB_ID,
		[REPORT_ID] = @REPORT_ID
	WHERE
		[CDP_CONTACT_ID] = @CDP_CONTACT_ID


	SET @Err = @@Error


	RETURN @Err
END





