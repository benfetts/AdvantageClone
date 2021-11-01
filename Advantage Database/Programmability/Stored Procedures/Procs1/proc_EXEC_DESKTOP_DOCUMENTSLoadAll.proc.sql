



























CREATE PROCEDURE [dbo].[proc_EXEC_DESKTOP_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[OFFICE_CODE],
		[EMP_CODE]
	FROM [EXEC_DESKTOP_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























