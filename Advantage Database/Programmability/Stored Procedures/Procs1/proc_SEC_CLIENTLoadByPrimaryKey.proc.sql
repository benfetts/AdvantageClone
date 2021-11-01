



























CREATE PROCEDURE [dbo].[proc_SEC_CLIENTLoadByPrimaryKey]
(
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6),
	@USER_ID varchar(100)
)
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
	WHERE
		([CL_CODE] = @CL_CODE) AND
		([DIV_CODE] = @DIV_CODE) AND
		([PRD_CODE] = @PRD_CODE) AND
		([USER_ID] = @USER_ID)

	SET @Err = @@Error

	RETURN @Err
END



























