



























CREATE PROCEDURE [dbo].[proc_EXEC_DESKTOP_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(4),
	@EMP_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [EXEC_DESKTOP_DOCUMENTS]
	SET
		[OFFICE_CODE] = @OFFICE_CODE,
		[EMP_CODE] = @EMP_CODE
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



























