﻿



























CREATE PROCEDURE [dbo].[proc_OFFICE_DOCUMENTSLoadByPrimaryKey]
(
	@DOCUMENT_ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[DOCUMENT_ID],
		[OFFICE_CODE]
	FROM [OFFICE_DOCUMENTS]
	WHERE
		([DOCUMENT_ID] = @DOCUMENT_ID)

	SET @Err = @@Error

	RETURN @Err
END



























