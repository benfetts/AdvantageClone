



















CREATE PROCEDURE [dbo].[proc_PRODUCT_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[CL_CODE],
		[DIV_CODE],
		[PRD_CODE]
	FROM [PRODUCT_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



















