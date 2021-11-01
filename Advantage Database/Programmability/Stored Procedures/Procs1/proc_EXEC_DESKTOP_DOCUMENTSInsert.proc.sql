



























CREATE PROCEDURE [dbo].[proc_EXEC_DESKTOP_DOCUMENTSInsert]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(4),
	@EMP_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [EXEC_DESKTOP_DOCUMENTS]
	(
		[DOCUMENT_ID],
		[OFFICE_CODE],
		[EMP_CODE]
	)
	VALUES
	(
		@DOCUMENT_ID,
		@OFFICE_CODE,
		@EMP_CODE
	)

	SET @Err = @@Error


	RETURN @Err
END



























