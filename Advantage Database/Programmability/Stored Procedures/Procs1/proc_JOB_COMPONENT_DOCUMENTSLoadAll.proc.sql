



























CREATE PROCEDURE [dbo].[proc_JOB_COMPONENT_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[JOB_COMPONENT_NUMBER],
		[JOB_NUMBER]
	FROM [JOB_COMPONENT_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























