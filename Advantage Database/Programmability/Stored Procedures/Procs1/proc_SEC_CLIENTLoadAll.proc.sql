



























CREATE PROCEDURE [dbo].[proc_SEC_CLIENTLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[USER_ID],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE],
		[TIME_ENTRY]
	FROM [SEC_CLIENT]

	SET @Err = @@Error

	RETURN @Err
END



























