



























CREATE PROCEDURE [dbo].[proc_AP_DOCUMENTSLoadByPrimaryKey]
(
	@DOCUMENT_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[AP_ID]
	FROM [AP_DOCUMENTS]
	WHERE
		([DOCUMENT_ID] = @DOCUMENT_ID)

	SET @Err = @@Error

	RETURN @Err
END



























