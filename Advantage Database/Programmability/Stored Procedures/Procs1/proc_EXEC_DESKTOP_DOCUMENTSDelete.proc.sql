



























CREATE PROCEDURE [dbo].[proc_EXEC_DESKTOP_DOCUMENTSDelete]
(
	@DOCUMENT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [EXEC_DESKTOP_DOCUMENTS]
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID
	SET @Err = @@Error

	RETURN @Err
END



























