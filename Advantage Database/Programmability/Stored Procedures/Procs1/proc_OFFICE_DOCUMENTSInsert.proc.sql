



























CREATE PROCEDURE [dbo].[proc_OFFICE_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [OFFICE_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[OFFICE_CODE]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@OFFICE_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END



























