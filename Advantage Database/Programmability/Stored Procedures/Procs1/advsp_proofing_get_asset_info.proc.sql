IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_get_asset_info]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_get_asset_info];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_get_asset_info] 
@ALERT_ID INT = NULL,
@DOCUMENT_ID INT = NULL
AS
/*=========== QUERY ===========*/
BEGIN
	--	INIT
	BEGIN
		DECLARE @ASSET_INFO TABLE (	[ID] INT IDENTITY,
									[DocumentId] INT,
									[FileName] VARCHAR(1000),
									[Description] VARCHAR(1000),
									[Version] INT,
									[UploadDate] SMALLDATETIME,
									[UserCode] VARCHAR(100),
									[UserFullName] VARCHAR(1000),
									[Tags] VARCHAR(MAX),
									[MimeType] VARCHAR(100),
									[FileSize] INT,
									[Thumbnail] IMAGE,
									[IsLatestDocument] BIT NULL,
									[TotalApproves] INT NULL,
									[TotalRejects] INT NULL,
									[TotalDefers] INT NULL,
									[TotalMarkups] INT NULL,
									[TotalVersions] INT NULL,
									[TotalVersionsForAlertID] INT NULL,
									[LatestMarkupFullName] VARCHAR(300) NULL,
									[LatestMarkupDate] SMALLDATETIME NULL
									);
	END
	--	DATA
	IF @ALERT_ID IS NOT NULL
	BEGIN
		--	DOCUMENT DATA
		BEGIN
			INSERT INTO @ASSET_INFO (DocumentId, [FileName], [Description], UploadDate, UserCode, UserFullName, MimeType, FileSize, Thumbnail)
			SELECT 
				D.DOCUMENT_ID,
				D.[FILENAME],
				D.[DESCRIPTION],
				D.UPLOADED_DATE,
				D.USER_CODE,
				ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				D.MIME_TYPE,
				D.FILE_SIZE,
				D.THUMBNAIL
			FROM
				DOCUMENTS D WITH(NOLOCK)
				INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID
				INNER JOIN SEC_USER SU WITH(NOLOCK) ON D.USER_CODE = SU.USER_CODE
				INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON SU.EMP_CODE = E.EMP_CODE
			WHERE
				AA.ALERT_ID = @ALERT_ID
			;
		END
		--	STATS
		BEGIN
			UPDATE @ASSET_INFO SET
				[Version] = D.[Version],
				IsLatestDocument = D.IsLatestDocument,
				TotalApproves = D.TotalApproves,
				TotalRejects = D.TotalRejects,
				TotalDefers = D.TotalDefers,
				TotalMarkups = D.TotalMarkups,
				LatestMarkupFullName = D.LatestMarkupFullName,
				LatestMarkupDate = D.LatestMarkupDate,
				TotalVersions = D.TotalVersions,
				TotalVersionsForAlertID = D.TotalVersionsForAlertID
			FROM 
				@ASSET_INFO AI
				INNER JOIN [dbo].[advtf_proofing_get_documents_details] (@ALERT_ID) D ON AI.DocumentId = D.DocumentID
			;
		END
	END
	--	RETURN
	BEGIN
		SELECT
			AI.[DocumentId],
			AI.[FileName],
			AI.[Description],
			AI.[Version],
			AI.[UploadDate],
			AI.[UserCode],
			AI.[UserFullName],
			AI.[Tags],
			AI.[MimeType],
			AI.[FileSize],
			AI.[Thumbnail],
			AI.[IsLatestDocument],
			AI.[TotalApproves],
			AI.[TotalRejects],
			AI.[TotalDefers],
			AI.[TotalMarkups],
			AI.[LatestMarkupFullName],
			AI.[LatestMarkupDate],
			AI.[TotalVersions],
			AI.[TotalVersionsForAlertID]
		FROM
			@ASSET_INFO AI
		WHERE
			1 =	CASE
					WHEN @DOCUMENT_ID IS NULL THEN 1
					WHEN @DOCUMENT_ID IS NOT NULL AND AI.DocumentId = @DOCUMENT_ID THEN 1
					ELSE 0
				END
	END

END
/*=========== QUERY ===========*/
