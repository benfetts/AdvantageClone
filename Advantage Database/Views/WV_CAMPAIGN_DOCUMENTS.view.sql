
CREATE VIEW dbo.WV_CAMPAIGN_DOCUMENTS
AS
	SELECT     
		dbo.CAMPAIGN_DOCUMENTS.CMP_IDENTIFIER, 
		dbo.DOCUMENTS.DOCUMENT_ID, 
		dbo.DOCUMENTS.FILENAME, 
		dbo.DOCUMENTS.MIME_TYPE, 
		dbo.DOCUMENTS.DESCRIPTION, 
		dbo.DOCUMENTS.KEYWORDS, 
		dbo.DOCUMENTS.UPLOADED_DATE, 
		dbo.DOCUMENTS.USER_CODE, 
		dbo.DOCUMENTS.FILE_SIZE, 
		 dbo.DOCUMENTS.USER_CODE AS [USER_NAME], 
		dbo.DOCUMENTS.REPOSITORY_FILENAME, 
		dbo.CAMPAIGN.CMP_CODE,
		dbo.DOCUMENTS.PROOFHQ_URL
	FROM         
		dbo.DOCUMENTS 
		INNER JOIN dbo.CAMPAIGN_DOCUMENTS ON dbo.DOCUMENTS.DOCUMENT_ID = dbo.CAMPAIGN_DOCUMENTS.DOCUMENT_ID  
		INNER JOIN dbo.CAMPAIGN ON dbo.CAMPAIGN_DOCUMENTS.CMP_IDENTIFIER = dbo.CAMPAIGN.CMP_IDENTIFIER


