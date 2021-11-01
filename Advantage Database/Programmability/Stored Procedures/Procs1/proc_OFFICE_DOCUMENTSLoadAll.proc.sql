



























CREATE PROCEDURE [dbo].[proc_OFFICE_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[OFFICE_CODE]
	FROM [OFFICE_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























