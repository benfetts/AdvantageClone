



























CREATE PROCEDURE [dbo].[proc_AGENCY_DESKTOP_DOCUMENTSLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[OFFICE_CODE],
		[DP_TM_CODE]
	FROM [AGENCY_DESKTOP_DOCUMENTS]

	SET @Err = @@Error

	RETURN @Err
END



























