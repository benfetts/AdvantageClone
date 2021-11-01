



























CREATE PROCEDURE [dbo].[proc_JOB_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[JOB_NUMBER]
	FROM [JOB_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























