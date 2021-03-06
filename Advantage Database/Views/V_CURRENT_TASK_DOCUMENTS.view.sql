CREATE VIEW [dbo].[V_CURRENT_TASK_DOCUMENTS]
AS

SELECT   
	[LEVEL] = 'Task',  
	[JOB_NUMBER] = JOB_TRAFFIC_DET_DOCS.JOB_NUMBER, 
	[JOB_COMPONENT_NBR] = JOB_TRAFFIC_DET_DOCS.JOB_COMPONENT_NBR, 
	[SEQ_NBR] = JOB_TRAFFIC_DET_DOCS.SEQ_NBR,
	[DOCUMENT_ID] = DOCUMENTS.DOCUMENT_ID, 
	[FILENAME] = DOCUMENTS.[FILENAME], 
	[MIME_TYPE] = DOCUMENTS.MIME_TYPE, 
	[DESCRIPTION] = DOCUMENTS.[DESCRIPTION],
	[KEYWORDS] = DOCUMENTS.KEYWORDS, 
	[UPLOADED_DATE] = DOCUMENTS.UPLOADED_DATE, 
	[USER_CODE] = DOCUMENTS.USER_CODE, 
	[FILE_SIZE] = DOCUMENTS.FILE_SIZE,
	[USER_NAME] = DOCUMENTS.USER_CODE, 
	[REPOSITORY_FILENAME] = DOCUMENTS.REPOSITORY_FILENAME,
	[DOCUMENT_TYPE_DESC] = DOCUMENT_TYPE.DOCUMENT_TYPE_DESC, 
	[PRIVATE_FLAG] = ISNULL(DOCUMENTS.PRIVATE_FLAG, 0),
	[PROOFHQ_URL] = DOCUMENTS.PROOFHQ_URL
FROM
	dbo.DOCUMENTS INNER JOIN
	dbo.JOB_TRAFFIC_DET_DOCS ON DOCUMENTS.DOCUMENT_ID = JOB_TRAFFIC_DET_DOCS.DOCUMENT_ID INNER JOIN
	dbo.DOCUMENT_TYPE ON DOCUMENTS.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID
WHERE     
	(DOCUMENTS.DOCUMENT_ID IN (	SELECT     
									MAX(JOB_TRAFFIC_DET_DOCS_1.DOCUMENT_ID) AS DOCUMENT_ID
								FROM          
									dbo.JOB_TRAFFIC_DET_DOCS AS JOB_TRAFFIC_DET_DOCS_1 INNER JOIN
                                    dbo.DOCUMENTS AS DOCUMENTS_1 ON JOB_TRAFFIC_DET_DOCS_1.DOCUMENT_ID = DOCUMENTS_1.DOCUMENT_ID
								GROUP BY 
									JOB_TRAFFIC_DET_DOCS_1.JOB_NUMBER,
									JOB_TRAFFIC_DET_DOCS_1.JOB_COMPONENT_NBR,
									JOB_TRAFFIC_DET_DOCS_1.SEQ_NBR, 
									DOCUMENTS_1.[FILENAME])
								)

GO
