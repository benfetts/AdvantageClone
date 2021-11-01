



























CREATE PROCEDURE [dbo].[proc_AP_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[AP_ID]
	FROM [AP_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























