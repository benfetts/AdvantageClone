



























CREATE PROCEDURE [dbo].[proc_JOB_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@JOB_NUMBER int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [JOB_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[JOB_NUMBER]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@JOB_NUMBER
	)

	SET @Err = @@Error


	RETURN @Err
END



























