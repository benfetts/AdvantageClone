



























CREATE PROCEDURE [dbo].[proc_SEC_CLIENTInsert]
(
	@USER_ID varchar(100),
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6),
	@TIME_ENTRY smallint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [SEC_CLIENT]
	(
		[USER_ID],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE],
		[TIME_ENTRY]
	)
	VALUES
	(
		@USER_ID,
		@CL_CODE,
		@DIV_CODE,
		@PRD_CODE,
		@TIME_ENTRY
	)

	SET @Err = @@Error


	RETURN @Err
END



























