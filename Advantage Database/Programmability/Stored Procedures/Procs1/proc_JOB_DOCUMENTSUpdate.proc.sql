



























CREATE PROCEDURE [dbo].[proc_JOB_DOCUMENTSUpdate]
(
	@DOCUMENT_ID int,
	@JOB_NUMBER int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [JOB_DOCUMENTS]
	SET
		[JOB_NUMBER] = @JOB_NUMBER
	WHERE
		[DOCUMENT_ID] = @DOCUMENT_ID


	SET @Err = @@Error


	RETURN @Err
END



























