



















CREATE PROCEDURE [dbo].[proc_DIVISION_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[CL_CODE],
		[DIV_CODE]
	FROM [DIVISION_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



















