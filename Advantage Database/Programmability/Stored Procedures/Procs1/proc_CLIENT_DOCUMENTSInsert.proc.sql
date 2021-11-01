



























CREATE PROCEDURE [dbo].[proc_CLIENT_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@CL_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [CLIENT_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[CL_CODE]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@CL_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END



























