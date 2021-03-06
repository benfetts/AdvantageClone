CREATE VIEW [dbo].[VENDOR_CONTRACT_DOCUMENTS_ALL]
AS

	SELECT 
		[VENDOR_CONTRACT_ID] = VENDOR_CONTRACT_DOCUMENTS.VENDOR_CONTRACT_ID,
		[DOCUMENT_ID] = DOCUMENTS.DOCUMENT_ID, 
		[FILENAME] = DOCUMENTS.[FILENAME], 
		[MIME_TYPE] = DOCUMENTS.MIME_TYPE,
		[DESCRIPTION] = DOCUMENTS.[DESCRIPTION],
		[KEYWORDS] = DOCUMENTS.KEYWORDS,
		[UPLOADED_DATE] = DOCUMENTS.UPLOADED_DATE,
		[USER_CODE] = DOCUMENTS.USER_CODE,
		[FILE_SIZE] = DOCUMENTS.FILE_SIZE, 
		[USER_NAME] = DOCUMENTS.USER_CODE,
		[REPOSITORY_FILENAME] = DOCUMENTS.REPOSITORY_FILENAME
	FROM
		dbo.DOCUMENTS INNER JOIN
		dbo.VENDOR_CONTRACT_DOCUMENTS ON DOCUMENTS.DOCUMENT_ID = VENDOR_CONTRACT_DOCUMENTS.DOCUMENT_ID

GO
