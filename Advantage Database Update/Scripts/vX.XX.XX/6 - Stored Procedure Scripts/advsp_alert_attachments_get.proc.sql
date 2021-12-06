IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_attachments_get]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[advsp_alert_attachments_get] 
GO
CREATE PROCEDURE [dbo].[advsp_alert_attachments_get]
@ALERT_ID INT,
@EMP_CODE VARCHAR(6),
@OFFSET [DECIMAL](9,3)
AS
/*=========== QUERY ===========*/
BEGIN
	-- VARIABLES
	BEGIN
		DECLARE @ATTACHMENTS TABLE(
			[ROW_ID] INT IDENTITY NOT NULL,
			[ID] [INT] NOT NULL,
			[ALERTID] [INT] NOT NULL,
			[FILENAME] [VARCHAR](300) NULL,
			[GENERATED] [SMALLDATETIME] NULL,
			[EMPLOYEEFULLNAME] [VARCHAR](64) NULL,
			[MIMETYPE] [VARCHAR](255) NOT NULL,
			[REPOSITORYFILENAME] [VARCHAR](200) NOT NULL,
			[DOCUMENTID] [INT] NOT NULL,
			[FILESIZE] [INT] NOT NULL,
			[FILESIZEKB] [INT] NULL,
			[DESCRIPTION] [VARCHAR](200) NULL,
			[USERCODE] [VARCHAR](100) NOT NULL,
			[PRIVATEFLAG] [INT] NOT NULL,
			[ISPRIVATE] [VARCHAR](3) NOT NULL,
			[PROOFHQURL] [VARCHAR](MAX) NULL,
			[HISTORYCOUNT] [INT] NULL,
			[JOBNUMBER] [INT] NULL,
			[JOBCOMPONENTNUMBER] [SMALLINT] NULL,
			[TASK_SEQ_NBR] [SMALLINT] NULL,
			[ISTASKDOCUMENT] [BIT] NULL,
			[UPLOADEDTODOCUMENTMANAGER] [BIT] NULL,
			[THUMBNAILSOURCE] [IMAGE] NULL,
			[VERSIONNUMBER] [SMALLINT] NULL,
			[RAWVERSIONNUMBER] [SMALLINT] NULL,
			[IS_DEFAULT_SELECTED] [BIT] NULL,
			[SELECTED_CSS] [BIT] NULL,
			[FILE_ORDER] INT NULL,
			[TOTAL_VERSIONS] INT NULL,
			[TOTAL_VERSIONS_FOR_ALERT_ID] INT NULL,
			[LAST_MARKUP_DATE] SMALLDATETIME NULL,
			[LAST_MARKUP_FULL_NAME] VARCHAR(500) NULL,
			[TOTAL_APPROVED] INT,
			[TOTAL_REJECTED] INT,
			[TOTAL_DEFERRED] INT,
			[TOTAL_MARKUPS] INT,
			[IS_LATEST] BIT
		);
		DECLARE
			@IS_PROOF BIT,
			@MAX_ATTACHMENT_DOCUMENT_ID INT,
			@ROW_COUNT INT,
			@COUNTER INT,
			@FILENAME VARCHAR(1000),
			@CURRENT_FILENAME VARCHAR(1000),
			@VERSION_COUNTER INT
		;
	END
	--	INIT
	BEGIN
		SELECT
			@IS_PROOF = 
			CASE
				WHEN A.ALERT_CAT_ID = 79 THEN 1
				ELSE 0
			END
		FROM
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_ID = @ALERT_ID
		;
		SELECT 
			@MAX_ATTACHMENT_DOCUMENT_ID = MAX(DOCUMENT_ID) 
		FROM 
			ALERT_ATTACHMENT AA WITH(NOLOCK) 
		WHERE 
			AA.ALERT_ID = @ALERT_ID;
	END
	--	DATA
	IF @IS_PROOF = 0
	BEGIN
		BEGIN
			INSERT INTO @ATTACHMENTS (ID, 
			                          ALERTID, 
									  [FILENAME], 
									  [GENERATED], 
									  EMPLOYEEFULLNAME, 
									  MIMETYPE, 
									  REPOSITORYFILENAME, 
									  DOCUMENTID, 
									  FILESIZE, 
									  FILESIZEKB, 
									  [DESCRIPTION], 
									  USERCODE,
									  PRIVATEFLAG, 
									  ISPRIVATE, 
									  PROOFHQURL, 
									  HISTORYCOUNT, 
									  JOBNUMBER, 
									  JOBCOMPONENTNUMBER, 
									  TASK_SEQ_NBR, 
									  ISTASKDOCUMENT, 
									  UPLOADEDTODOCUMENTMANAGER, 
									  THUMBNAILSOURCE, 
									  VERSIONNUMBER, 
									  RAWVERSIONNUMBER)
			SELECT 
				[ID] = ALERT_ATTACHMENT.ATTACHMENT_ID,
				[AlertID] = ALERT_ATTACHMENT.ALERT_ID,
				[FileName] = DOCUMENTS.FILENAME,
				[Generated] =	CASE
									WHEN @OFFSET IS NULL OR @OFFSET = 0 THEN COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE)
									ELSE ISNULL(DATEADD(mi, (@OFFSET * 60) + (@OFFSET - @OFFSET), COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE)), COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE))
								END, 
				[EmployeeFullName] = CASE 
										WHEN USER_CODE_CP IS NULL OR USER_CODE_CP = 0 THEN ISNULL(EMPLOYEE.EMP_FNAME+' ','') + ISNULL(EMPLOYEE.EMP_MI+'. ','') + ISNULL(EMPLOYEE.EMP_LNAME,'')
										ELSE (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE CDP_CONTACT_ID = USER_CODE_CP) 
									 END,
				[MIMEType] = DOCUMENTS.MIME_TYPE,
				[RepositoryFileName] = DOCUMENTS.REPOSITORY_FILENAME,
				[DocumentID] = DOCUMENTS.DOCUMENT_ID,
				[FileSize] = DOCUMENTS.FILE_SIZE,
				[FileSizeKB] = CASE 
									WHEN DOCUMENTS.FILE_SIZE > 0 THEN CAST(DOCUMENTS.FILE_SIZE / 1024 AS INT)
									ELSE 0
								END,
				[Description] = DOCUMENTS.DESCRIPTION,
				[UserCode] = ALERT_ATTACHMENT.USER_CODE,
				[PrivateFlag] = ISNULL(DOCUMENTS.PRIVATE_FLAG, 0),
				[IsPrivate] = CASE 
								WHEN DOCUMENTS.PRIVATE_FLAG IS NULL OR DOCUMENTS.PRIVATE_FLAG = 0 THEN 	'No'
								ELSE 'Yes'
								END,
				[ProofHQUrl] = DOCUMENTS.PROOFHQ_URL,
				[HistoryCount] = (SELECT COUNT(1) FROM DOCUMENTS DH WHERE DH.[FILENAME] = DOCUMENTS.[FILENAME]),
				[JobNumber] = ALERT.JOB_NUMBER, 
				[JobComponentNumber] = ALERT.JOB_COMPONENT_NBR, 
				[SequenceNumber] = ALERT.TASK_SEQ_NBR,
				[IsTaskDocument] = CAST(0 AS BIT),
				[UploadedToDocumentManager] = CASE
													WHEN DOCUMENTS.REPOSITORY_FILENAME LIKE 'd_%' THEN CAST(1 AS BIT)
													ELSE CAST (0 AS BIT)
												END,
				[ThumbnailSource] = DOCUMENTS.THUMBNAIL,
				NULL,
				DOCUMENTS.VERSION_NUMBER
		FROM 
			EMPLOYEE WITH (NOLOCK) 
			INNER JOIN SEC_USER WITH (NOLOCK) ON EMPLOYEE.EMP_CODE = SEC_USER.EMP_CODE 
			RIGHT OUTER JOIN ALERT_ATTACHMENT WITH (NOLOCK) 
			INNER JOIN DOCUMENTS WITH (NOLOCK) ON ALERT_ATTACHMENT.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID ON UPPER(SEC_USER.USER_CODE) = UPPER(ALERT_ATTACHMENT.USER_CODE)
			INNER JOIN ALERT WITH (NOLOCK) ON ALERT_ATTACHMENT.ALERT_ID = ALERT.ALERT_ID
		WHERE
			ALERT_ATTACHMENT.ALERT_ID = @ALERT_ID 
			AND
			DOCUMENTS.DOCUMENT_ID IN ( SELECT     
											MAX(ALERT_ATTACHMENT_1.DOCUMENT_ID) AS DOCUMENT_ID
										FROM          
											ALERT_ATTACHMENT AS ALERT_ATTACHMENT_1 
											INNER JOIN DOCUMENTS AS DOCUMENTS_1 ON ALERT_ATTACHMENT_1.DOCUMENT_ID = DOCUMENTS_1.DOCUMENT_ID
										GROUP BY 
											ALERT_ATTACHMENT_1.ALERT_ID, 
											DOCUMENTS_1.FILENAME)
		END
		BEGIN
			INSERT INTO @ATTACHMENTS (ID, 
									  ALERTID, 
									  [FILENAME], 
									  [GENERATED], 
									  EMPLOYEEFULLNAME, 
									  MIMETYPE, 
									  REPOSITORYFILENAME, 
									  DOCUMENTID, 
									  FILESIZE, 
									  FILESIZEKB, 
									  [DESCRIPTION],
									  USERCODE,
									  PRIVATEFLAG, 
									  ISPRIVATE, 
									  PROOFHQURL, 
									  HISTORYCOUNT, 
									  JOBNUMBER, 
									  JOBCOMPONENTNUMBER, 
									  TASK_SEQ_NBR, 
									  ISTASKDOCUMENT, 
									  UPLOADEDTODOCUMENTMANAGER, 
									  THUMBNAILSOURCE, 
									  VERSIONNUMBER, 
									  RAWVERSIONNUMBER)
			SELECT
				[ID] = ROWID,  
				[AlertID] = ALERT.ALERT_ID,
				[FileName] = DOCUMENTS.[FILENAME], 
				[Generated] =	CASE
									WHEN @OFFSET IS NULL OR @OFFSET = 0 THEN DOCUMENTS.UPLOADED_DATE
									ELSE ISNULL(DATEADD(mi, (@OFFSET * 60) + (@OFFSET - @OFFSET), DOCUMENTS.UPLOADED_DATE), DOCUMENTS.UPLOADED_DATE)
								END, 
				[EmployeeFullName] = NULL,
				[MIMEType] = DOCUMENTS.MIME_TYPE, 
				[RepositoryFileName] = DOCUMENTS.REPOSITORY_FILENAME,
				[DocumentID] = DOCUMENTS.DOCUMENT_ID, 
				[FileSize] = DOCUMENTS.FILE_SIZE,
				[FileSizeKB] = CASE 
									WHEN DOCUMENTS.FILE_SIZE > 0 THEN CAST(DOCUMENTS.FILE_SIZE / 1024 AS INT)
									ELSE 0
								END,
				[Description] = DOCUMENTS.[DESCRIPTION],
				[UserCode] = DOCUMENTS.USER_CODE,  
				[PrivateFlag] = ISNULL(DOCUMENTS.PRIVATE_FLAG, 0),
				[IsPrivate] = CASE 
								WHEN DOCUMENTS.PRIVATE_FLAG IS NULL OR DOCUMENTS.PRIVATE_FLAG = 0 THEN 	'No'
								ELSE 'Yes'
								END,
				[ProofHQUrl] = DOCUMENTS.PROOFHQ_URL,
				[HistoryCount] = (SELECT COUNT(1) FROM DOCUMENTS DH WHERE DH.[FILENAME] = DOCUMENTS.[FILENAME]),
				[JobNumber] = JOB_TRAFFIC_DET_DOCS.JOB_NUMBER, 
				[JobComponentNumber] = JOB_TRAFFIC_DET_DOCS.JOB_COMPONENT_NBR, 
				[SequenceNumber] = JOB_TRAFFIC_DET_DOCS.SEQ_NBR,
				[IsTaskDocument] = CAST(1 AS BIT),
				[UploadedToDocumentManager] = CASE
													WHEN DOCUMENTS.REPOSITORY_FILENAME LIKE 'd_%' THEN CAST(1 AS BIT)
													ELSE CAST (0 AS BIT)
												END,
				[ThumbnailSource] = DOCUMENTS.THUMBNAIL,
				NULL,
				DOCUMENTS.VERSION_NUMBER
		FROM
			DOCUMENTS WITH (NOLOCK) INNER JOIN
			JOB_TRAFFIC_DET_DOCS WITH (NOLOCK) ON DOCUMENTS.DOCUMENT_ID = JOB_TRAFFIC_DET_DOCS.DOCUMENT_ID INNER JOIN
			DOCUMENT_TYPE WITH (NOLOCK) ON DOCUMENTS.DOCUMENT_TYPE_ID = DOCUMENT_TYPE.DOCUMENT_TYPE_ID INNER JOIN
			ALERT WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET_DOCS.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_DOCS.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET_DOCS.SEQ_NBR
		WHERE 
			ALERT_LEVEL <> 'PST' 
			AND ALERT.ALERT_ID = @ALERT_ID 
			AND  
			(DOCUMENTS.DOCUMENT_ID IN (	SELECT     
											MAX(JOB_TRAFFIC_DET_DOCS_1.DOCUMENT_ID) AS DOCUMENT_ID
										FROM          
											JOB_TRAFFIC_DET_DOCS AS JOB_TRAFFIC_DET_DOCS_1 INNER JOIN
											DOCUMENTS AS DOCUMENTS_1 ON JOB_TRAFFIC_DET_DOCS_1.DOCUMENT_ID = DOCUMENTS_1.DOCUMENT_ID
										GROUP BY 
											JOB_TRAFFIC_DET_DOCS_1.JOB_NUMBER,
											JOB_TRAFFIC_DET_DOCS_1.JOB_COMPONENT_NBR,
											JOB_TRAFFIC_DET_DOCS_1.SEQ_NBR, 
											DOCUMENTS_1.[FILENAME])
										) AND
			DOCUMENTS.DOCUMENT_ID NOT IN (	SELECT     
												MAX(ALERT_ATTACHMENT_1.DOCUMENT_ID) AS DOCUMENT_ID
											FROM          
												ALERT_ATTACHMENT AS ALERT_ATTACHMENT_1 WITH (NOLOCK) 
												INNER JOIN DOCUMENTS AS DOCUMENTS_1 WITH (NOLOCK) ON ALERT_ATTACHMENT_1.DOCUMENT_ID = DOCUMENTS_1.DOCUMENT_ID
											GROUP BY 
												ALERT_ATTACHMENT_1.ALERT_ID, 
												DOCUMENTS_1.FILENAME)
		END
	END
	ELSE
	BEGIN
		INSERT INTO @ATTACHMENTS (ID, 
									ALERTID, 
									[FILENAME], 
									[GENERATED], 
									EMPLOYEEFULLNAME, 
									MIMETYPE, 
									REPOSITORYFILENAME, 
									DOCUMENTID, 
									FILESIZE, 
									FILESIZEKB, 
									[DESCRIPTION],
									USERCODE,
									PRIVATEFLAG, 
									ISPRIVATE, 
									PROOFHQURL, 
									HISTORYCOUNT, 
									JOBNUMBER, 
									JOBCOMPONENTNUMBER, 
									TASK_SEQ_NBR, 
									ISTASKDOCUMENT, 
									UPLOADEDTODOCUMENTMANAGER, 
									THUMBNAILSOURCE, 
									VERSIONNUMBER, 
									RAWVERSIONNUMBER)
		SELECT 
			[ID] = ALERT_ATTACHMENT.ATTACHMENT_ID,
			[AlertID] = ALERT_ATTACHMENT.ALERT_ID,
			[FileName] = DOCUMENTS.[FILENAME],
			[Generated] =	CASE
								WHEN @OFFSET IS NULL OR @OFFSET = 0 THEN COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE)
								ELSE ISNULL(DATEADD(mi, (@OFFSET * 60) + (@OFFSET - @OFFSET), COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE)), COALESCE(ALERT_ATTACHMENT.GENERATED_DATE, DOCUMENTS.UPLOADED_DATE))
							END, 
			[EmployeeFullName] = CASE 
									WHEN USER_CODE_CP IS NULL OR USER_CODE_CP = 0 THEN ISNULL(EMPLOYEE.EMP_FNAME+' ','') + ISNULL(EMPLOYEE.EMP_MI+'. ','') + ISNULL(EMPLOYEE.EMP_LNAME,'')
									ELSE (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE CDP_CONTACT_ID = USER_CODE_CP) 
									END,
			[MIMEType] = DOCUMENTS.MIME_TYPE,
			[RepositoryFileName] = DOCUMENTS.REPOSITORY_FILENAME,
			[DocumentID] = DOCUMENTS.DOCUMENT_ID,
			[FileSize] = DOCUMENTS.FILE_SIZE,
			[FileSizeKB] = CASE 
								WHEN DOCUMENTS.FILE_SIZE > 0 THEN CAST(DOCUMENTS.FILE_SIZE / 1024 AS INT)
								ELSE 0
							END,
			[Description] = DOCUMENTS.DESCRIPTION,
			[UserCode] = ALERT_ATTACHMENT.USER_CODE,
			[PrivateFlag] = ISNULL(DOCUMENTS.PRIVATE_FLAG, 0),
			[IsPrivate] =	CASE 
								WHEN DOCUMENTS.PRIVATE_FLAG IS NULL OR DOCUMENTS.PRIVATE_FLAG = 0 THEN 	'No'
								ELSE 'Yes'
							END,
			[ProofHQUrl] = DOCUMENTS.PROOFHQ_URL,
			[HistoryCount] = (SELECT COUNT(1) FROM DOCUMENTS DH WHERE DH.[FILENAME] = DOCUMENTS.[FILENAME]),
			[JobNumber] = ALERT.JOB_NUMBER, 
			[JobComponentNumber] = ALERT.JOB_COMPONENT_NBR, 
			[SequenceNumber] = ALERT.TASK_SEQ_NBR,
			[IsTaskDocument] = CAST(0 AS BIT),
			[UploadedToDocumentManager] = CASE
												WHEN DOCUMENTS.REPOSITORY_FILENAME LIKE 'd_%' THEN CAST(1 AS BIT)
												ELSE CAST (0 AS BIT)
											END,
			[ThumbnailSource] = DOCUMENTS.THUMBNAIL,
			NULL,
			DOCUMENTS.VERSION_NUMBER
		FROM 
			EMPLOYEE WITH (NOLOCK) 
			INNER JOIN SEC_USER WITH (NOLOCK) ON EMPLOYEE.EMP_CODE = SEC_USER.EMP_CODE 
			RIGHT OUTER JOIN ALERT_ATTACHMENT WITH (NOLOCK) 
			INNER JOIN DOCUMENTS WITH (NOLOCK) ON ALERT_ATTACHMENT.DOCUMENT_ID = DOCUMENTS.DOCUMENT_ID ON UPPER(SEC_USER.USER_CODE) = UPPER(ALERT_ATTACHMENT.USER_CODE)
			INNER JOIN ALERT WITH (NOLOCK) ON ALERT_ATTACHMENT.ALERT_ID = ALERT.ALERT_ID
		WHERE
			ALERT_ATTACHMENT.ALERT_ID = @ALERT_ID
		ORDER BY
			DOCUMENTS.[FILENAME],
			DOCUMENTS.UPLOADED_DATE ASC,
			DOCUMENTS.DOCUMENT_ID ASC
		;
	END
	--	CLEAN UP
	BEGIN
		UPDATE @ATTACHMENTS SET IS_DEFAULT_SELECTED = 1
		WHERE
			DOCUMENTID = @MAX_ATTACHMENT_DOCUMENT_ID
		;
		IF @IS_PROOF = 0
		BEGIN
			--	NO CUSTOM SORT ON NON-PROOFS
			UPDATE @ATTACHMENTS		
			SET 
				VERSIONNUMBER = NULL, 
				RAWVERSIONNUMBER = NULL, 
				FILE_ORDER = NULL
			;
		END
		ELSE
		BEGIN
			--	STATS
			UPDATE @ATTACHMENTS SET
				FILE_ORDER = DD.ID,
				LAST_MARKUP_DATE = DD.LatestMarkupDate,
				LAST_MARKUP_FULL_NAME = DD.LatestMarkupFullName,
				TOTAL_APPROVED = DD.TotalApproves,
				TOTAL_REJECTED = DD.TotalRejects,
				TOTAL_DEFERRED = DD.TotalDefers,
				TOTAL_MARKUPS = DD.TotalMarkups,
				IS_LATEST = DD.IsLatestDocument,
				VERSIONNUMBER = DD.[Version],
				TOTAL_VERSIONS = DD.TotalVersions,
				TOTAL_VERSIONS_FOR_ALERT_ID = DD.TotalVersionsForAlertID
			FROM
				[dbo].[advtf_proofing_get_documents_details] (@ALERT_ID) DD
				INNER JOIN @ATTACHMENTS A ON DD.DocumentID = A.DOCUMENTID
			;
		END
	END
	--	RETURN
	IF @IS_PROOF = 1
	BEGIN
		SELECT 
			[ID] = A.ID,
			[AlertID] = A.ALERTID,
			[FileName] = A.[FILENAME],
			[Generated] = A.[GENERATED],
			[EmployeeFullName] = A.EMPLOYEEFULLNAME,
			[MimeType] = A.MIMETYPE,
			[RepositoryFileName] = A.REPOSITORYFILENAME,
			[DocumentID] = A.DOCUMENTID,
			[FileSize] = A.FILESIZE,
			[FileSizeKB] = A.FILESIZEKB,
			[Description] = A.[DESCRIPTION],
			[UserCode] = A.USERCODE,
			[PrivateFlag] = A.PRIVATEFLAG,
			[IsPrivate] = A.ISPRIVATE,
			[ProofHQUrl] = A.PROOFHQURL,
			[HistoryCount] = A.HISTORYCOUNT	,
			[FileTypeLabel] = NULL,
			[AllowComments] = CAST( 0 AS BIT),
			[JobNumber] = A.JOBNUMBER,
			[JobComponentNumber] = A.JOBCOMPONENTNUMBER,
			[SequenceNumber] = A.TASK_SEQ_NBR,
			[IsTaskDocument] = CAST(ISNULL(A.ISTASKDOCUMENT, 0) AS BIT),
			[UploadedToDocumentManager] = CAST(ISNULL(A.UPLOADEDTODOCUMENTMANAGER, 0) AS BIT),
			[ThumbNailSource] = A.THUMBNAILSOURCE,
			[VersionNumber] = A.VERSIONNUMBER,
			[RawVersionNumber] = A.RAWVERSIONNUMBER,
			[IsDefaultSelected] = ISNULL(A.IS_DEFAULT_SELECTED, 0),
			[SelectedCSS] = A.SELECTED_CSS,
			[FileOrder] = A.FILE_ORDER,
			[TotalVersions] = ISNULL(A.TOTAL_VERSIONS, 0),
			[TotalVersionsForAlertID] = ISNULL(A.TOTAL_VERSIONS_FOR_ALERT_ID, 0),
			[LastMarkupDate] = A.LAST_MARKUP_DATE,
			[LastMarkupFullName] = A.LAST_MARKUP_FULL_NAME,
			[TotalApproved] = ISNULL(A.TOTAL_APPROVED, 0),
			[TotalRejected] = ISNULL(A.TOTAL_REJECTED, 0),
			[TotalDeferred] = ISNULL(A.TOTAL_DEFERRED, 0),
			[TotalMarkups] = ISNULL(A.TOTAL_MARKUPS, 0),
			[IsLatest] = ISNULL(A.IS_LATEST, 0)
		FROM 
			@ATTACHMENTS A 
		ORDER BY 
			A.FILE_ORDER,
			A.VERSIONNUMBER,
			A.[FILENAME],
			A.[GENERATED]
		;
	END
	ELSE
	BEGIN
		SELECT 
			[ID] = A.ID,
			[AlertID] = A.ALERTID,
			[FileName] = A.[FILENAME],
			[Generated] = A.[GENERATED],
			[EmployeeFullName] = A.EMPLOYEEFULLNAME,
			[MimeType] = A.MIMETYPE,
			[RepositoryFileName] = A.REPOSITORYFILENAME,
			[DocumentID] = A.DOCUMENTID,
			[FileSize] = A.FILESIZE,
			[FileSizeKB] = A.FILESIZEKB,
			[Description] = A.[DESCRIPTION],
			[UserCode] = A.USERCODE,
			[PrivateFlag] = A.PRIVATEFLAG,
			[IsPrivate] = A.ISPRIVATE,
			[ProofHQUrl] = A.PROOFHQURL,
			[HistoryCount] = A.HISTORYCOUNT	,
			[FileTypeLabel] = NULL,
			[AllowComments] = CAST( 0 AS BIT),
			[JobNumber] = A.JOBNUMBER,
			[JobComponentNumber] = A.JOBCOMPONENTNUMBER,
			[SequenceNumber] = A.TASK_SEQ_NBR,
			[IsTaskDocument] = CAST(ISNULL(A.ISTASKDOCUMENT, 0) AS BIT),
			[UploadedToDocumentManager] = CAST(ISNULL(A.UPLOADEDTODOCUMENTMANAGER, 0) AS BIT),
			[ThumbNailSource] = A.THUMBNAILSOURCE,
			[VersionNumber] = A.VERSIONNUMBER,
			[RawVersionNumber] = A.RAWVERSIONNUMBER,
			[IsDefaultSelected] = ISNULL(A.IS_DEFAULT_SELECTED, 0),
			[SelectedCSS] = A.SELECTED_CSS,
			[FileOrder] = A.FILE_ORDER,
			[TotalVersions] = ISNULL(A.TOTAL_VERSIONS, 0),
			[TotalVersionsForAlertID] = ISNULL(A.TOTAL_VERSIONS_FOR_ALERT_ID, 0),
			[LastMarkupDate] = A.LAST_MARKUP_DATE,
			[LastMarkupFullName] = A.LAST_MARKUP_FULL_NAME,
			[TotalApproved] = ISNULL(A.TOTAL_APPROVED, 0),
			[TotalRejected] = ISNULL(A.TOTAL_REJECTED, 0),
			[TotalDeferred] = ISNULL(A.TOTAL_DEFERRED, 0),
			[TotalMarkups] = ISNULL(A.TOTAL_MARKUPS, 0),
			[IsLatest] = ISNULL(A.IS_LATEST, 0)
		FROM 
			@ATTACHMENTS A 
		ORDER BY 			
			A.[GENERATED]
		;
	END

END
/*=========== QUERY ===========*/