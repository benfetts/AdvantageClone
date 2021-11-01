



























CREATE PROCEDURE [dbo].[proc_CLIENT_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[CL_CODE]
	FROM [CLIENT_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























