



























CREATE PROCEDURE [dbo].[proc_JOB_DOCUMENTSLoadByPrimaryKey]
(
	@DOCUMENT_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[JOB_NUMBER]
	FROM [JOB_DOCUMENTS]
	WHERE
		([DOCUMENT_ID] = @DOCUMENT_ID)

	SET @Err = @@Error

	RETURN @Err
END



























