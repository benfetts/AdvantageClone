



























CREATE PROCEDURE [dbo].[proc_OFFICE_DOCUMENTSDelete]
(
	@DOCUMENT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [OFFICE_DOCUMENTS]
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID
	SET @Err = @@Error

	RETURN @Err
END



























