﻿CREATE VIEW [dbo].[WV_AP_DOCUMENTS]
AS
	SELECT        
		AP_DOCUMENTS.AP_ID, 
		DOCUMENTS.DOCUMENT_ID, 
		DOCUMENTS.[FILENAME], 
		DOCUMENTS.MIME_TYPE, 
		DOCUMENTS.[DESCRIPTION], 
		DOCUMENTS.KEYWORDS, 
		DOCUMENTS.UPLOADED_DATE, 
		DOCUMENTS.USER_CODE, 
		DOCUMENTS.FILE_SIZE, 
		 dbo.DOCUMENTS.USER_CODE AS [USER_NAME], 
		DOCUMENTS.REPOSITORY_FILENAME, 
		DOCUMENTS.PROOFHQ_URL
	FROM            
		DOCUMENTS 
		INNER JOIN AP_DOCUMENTS ON DOCUMENTS.DOCUMENT_ID = AP_DOCUMENTS.DOCUMENT_ID
