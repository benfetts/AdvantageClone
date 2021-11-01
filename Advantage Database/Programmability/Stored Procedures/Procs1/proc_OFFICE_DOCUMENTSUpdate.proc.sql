



























CREATE PROCEDURE [dbo].[proc_OFFICE_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@OFFICE_CODE varchar(6)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [OFFICE_DOCUMENTS]
	SET
		[OFFICE_CODE] = @OFFICE_CODE
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



























