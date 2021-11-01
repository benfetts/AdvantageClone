



























CREATE PROCEDURE [dbo].[proc_JOB_COMPONENT_DOCUMENTSDelete]
(
	@DOCUMENT_ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [JOB_COMPONENT_DOCUMENTS]
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID
	SET @Err = @@Error

	RETURN @Err
END



























