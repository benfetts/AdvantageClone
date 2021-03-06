CREATE VIEW dbo.WV_CURRENT_AGENCY_DESKTOP_DOCUMENTS
AS
	SELECT 
		CASE 
			WHEN dbo.AGENCY_DESKTOP_DOCUMENTS.OFFICE_CODE IS NOT NULL
				AND dbo.AGENCY_DESKTOP_DOCUMENTS.DP_TM_CODE IS NULL
				THEN 'Office'
			WHEN dbo.AGENCY_DESKTOP_DOCUMENTS.OFFICE_CODE IS NULL
				AND dbo.AGENCY_DESKTOP_DOCUMENTS.DP_TM_CODE IS NOT NULL
				THEN 'Dept'
			WHEN dbo.AGENCY_DESKTOP_DOCUMENTS.OFFICE_CODE IS NOT NULL
				AND dbo.AGENCY_DESKTOP_DOCUMENTS.DP_TM_CODE IS NOT NULL
				THEN 'Office, Dept'
			ELSE 'Agency Desktop'
		END AS [LEVEL],
		dbo.AGENCY_DESKTOP_DOCUMENTS.OFFICE_CODE,
		dbo.AGENCY_DESKTOP_DOCUMENTS.DP_TM_CODE,
		dbo.DOCUMENTS.DOCUMENT_ID,
		dbo.DOCUMENTS.FILENAME,
		dbo.DOCUMENTS.REPOSITORY_FILENAME,
		dbo.DOCUMENTS.MIME_TYPE,
		dbo.DOCUMENTS.DESCRIPTION,
		dbo.DOCUMENTS.KEYWORDS,
		dbo.DOCUMENTS.UPLOADED_DATE,
		dbo.DOCUMENTS.USER_CODE,
		dbo.DOCUMENTS.FILE_SIZE,
		 dbo.DOCUMENTS.USER_CODE AS [USER_NAME], 
		dbo.DOCUMENT_TYPE.DOCUMENT_TYPE_DESC,
		ISNULL(dbo.DOCUMENTS.PRIVATE_FLAG, 0) AS PRIVATE_FLAG,
		dbo.DOCUMENTS.PROOFHQ_URL
	FROM 
		dbo.AGENCY_DESKTOP_DOCUMENTS
		INNER JOIN dbo.DOCUMENTS ON dbo.AGENCY_DESKTOP_DOCUMENTS.DOCUMENT_ID = dbo.DOCUMENTS.DOCUMENT_ID
		INNER JOIN dbo.DOCUMENT_TYPE ON dbo.DOCUMENTS.DOCUMENT_TYPE_ID = dbo.DOCUMENT_TYPE.DOCUMENT_TYPE_ID
	WHERE (
			dbo.DOCUMENTS.DOCUMENT_ID IN (
				SELECT MAX(AGENCY_DESKTOP_DOCUMENTS_1.DOCUMENT_ID) AS DOCUMENT_ID
				FROM dbo.AGENCY_DESKTOP_DOCUMENTS AS AGENCY_DESKTOP_DOCUMENTS_1
				INNER JOIN dbo.DOCUMENTS AS DOCUMENTS_1 ON AGENCY_DESKTOP_DOCUMENTS_1.DOCUMENT_ID = DOCUMENTS_1.DOCUMENT_ID
				GROUP BY AGENCY_DESKTOP_DOCUMENTS_1.OFFICE_CODE,
					DOCUMENTS_1.FILENAME
				)
			)
