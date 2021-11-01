





CREATE PROCEDURE [dbo].[proc_CP_SEC_CLIENTInsert]
(
	@CDP_CONTACT_ID int,
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6) = NULL,
	@PRD_CODE varchar(6) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	
	INSERT
	INTO [CP_SEC_CLIENT]
	(
		[CDP_CONTACT_ID],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE]
	)
	VALUES
	(
		@CDP_CONTACT_ID,
		@CL_CODE,
		@DIV_CODE,
		@PRD_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END





