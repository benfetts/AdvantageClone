IF EXISTS ( SELECT * FROM sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_proofing_get_documents_details]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_proofing_get_documents_details]
END
GO
CREATE FUNCTION [dbo].[advtf_proofing_get_documents_details] (
@ALERT_ID INT
)
RETURNS @RETURN_TABLE TABLE (   [ID] INT IDENTITY,
								[DocumentID] INT NULL,
								[IsLatestDocument] BIT NULL,
								[TotalComments] INT NULL,
								[TotalApproves] INT NULL,
								[TotalRejects] INT NULL,
								[TotalDefers] INT NULL,
								[TotalMarkups] INT NULL,
								[Version] INT,
								[TotalVersions] INT NULL,
								[TotalVersionsForAlertID] INT NULL,
								[InternalLatestMarkupFullName] VARCHAR(500) NULL,
								[InternalLatestMarkupDate] SMALLDATETIME NULL,
								[ExternalLatestMarkupFullName] VARCHAR(500) NULL,
								[ExternalLatestMarkupDate] SMALLDATETIME NULL,
								[LatestMarkupFullName] VARCHAR(300) NULL,
								[LatestMarkupDate] SMALLDATETIME NULL
							)
AS
BEGIN
/*=========== QUERY ===========*/
BEGIN
	--  VARS
	BEGIN
		DECLARE @WORKING_TABLE TABLE (	[ID] INT IDENTITY,
									[DocumentID] INT NULL,
									[FileName] VARCHAR(1000) NULL,
									[IsLatestDocument] BIT NULL,
									[TotalComments] INT NULL,
									[TotalApproves] INT NULL,
									[TotalRejects] INT NULL,
									[TotalDefers] INT NULL,
									[TotalMarkups] INT NULL,
									[Version] INT,
									[TotalVersions] INT NULL,
									[TotalVersionsForAlertID] INT NULL,
									[InternalLatestMarkupFullName] VARCHAR(500) NULL,
									[InternalLatestMarkupDate] SMALLDATETIME NULL,
									[ExternalLatestMarkupFullName] VARCHAR(500) NULL,
									[ExternalLatestMarkupDate] SMALLDATETIME NULL,
									[InternalIsLatest] BIT NULL,
									[LatestMarkupFullName] VARCHAR(500) NULL,
									[LatestMarkupDate] SMALLDATETIME NULL,
									[FileOrder] INT NULL
									)
		DECLARE
			@DOCS TABLE (ID INT IDENTITY,
						 DOCUMENT_ID INT)
		;
		DECLARE
			@MAX_DOCUMENT_ID INT,
			@ROW_COUNT INT,
			@COUNTER INT,
			@FILENAME VARCHAR(1000),
			@CURRENT_FILENAME VARCHAR(1000),
			@VERSION_COUNTER INT,
			@IS_PROOF BIT = 0
		;
	END
	--  INIT
	BEGIN
		SELECT
			@IS_PROOF =	CASE
							WHEN A.ALERT_CAT_ID = 79 THEN 1
							ELSE 0
						END
		FROM
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_ID = @ALERT_ID
		;
		INSERT INTO @WORKING_TABLE (DocumentID, [FileName])
		SELECT DISTINCT
			D.DOCUMENT_ID,
			D.[FILENAME]
		FROM
			ALERT_ATTACHMENT AA WITH(NOLOCK)
			INNER JOIN DOCUMENTS D WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID
		WHERE
			AA.ALERT_ID = @ALERT_ID
		ORDER BY
			D.[FILENAME],
			D.DOCUMENT_ID ASC
		;
		SELECT
			@MAX_DOCUMENT_ID = MAX(R.DocumentID)
		FROM
			@WORKING_TABLE R
		;
	END
	--  LATEST DOC
	BEGIN	
		UPDATE @WORKING_TABLE SET IsLatestDocument = 1
		FROM 
			@WORKING_TABLE Y
			INNER JOIN	(
							SELECT
								[DocumentID] = MAX(DocumentID),
								X.[FileName]
							FROM
								@WORKING_TABLE X
							GROUP BY
								[FileName]
						) AS Z ON Y.DocumentID = Z.DocumentID
		;
	END
	--  TOTAL COMMENTS
	BEGIN
		IF @IS_PROOF = 1
		BEGIN
			UPDATE @WORKING_TABLE SET TotalComments = A.CT
			FROM
				(
					SELECT
						AC.DOCUMENT_ID,
						CT = COUNT(1)
					FROM
						ALERT_COMMENT AC WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE X ON AC.DOCUMENT_ID = X.DocumentID
					WHERE
						AC.COMMENT NOT LIKE 'NEW FILE%'
						AND AC.COMMENT NOT LIKE 'NEW VERSION%'
						AND AC.COMMENT NOT LIKE 'APPROVE%'
						AND AC.COMMENT NOT LIKE 'REJECT%'
						AND AC.COMMENT NOT LIKE 'DEFER%'
					GROUP BY
						AC.DOCUMENT_ID
				) AS A INNER JOIN @WORKING_TABLE Y ON A.DOCUMENT_ID = Y.DocumentID
			;
		END
		ELSE
		BEGIN
			UPDATE @WORKING_TABLE SET TotalComments = A.CT
			FROM
				(
					SELECT
						AC.DOCUMENT_ID,
						CT = COUNT(1)
					FROM
						ALERT_COMMENT AC WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE X ON AC.DOCUMENT_ID = X.DocumentID
					WHERE
						(AC.IS_SYSTEM IS NULL OR AC.IS_SYSTEM = 0)
					GROUP BY
						AC.DOCUMENT_ID
				) AS A INNER JOIN @WORKING_TABLE Y ON A.DOCUMENT_ID = Y.DocumentID
			;
		END
	END
	--  PROOF STATS
	IF @IS_PROOF = 1
	BEGIN
		-- TOTAL APPROVES
		BEGIN
			UPDATE @WORKING_TABLE SET TotalApproves = B.CT
			FROM
				(
					SELECT
						AC.DOCUMENT_ID,
						CT = COUNT(1)
					FROM
						ALERT_COMMENT AC WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE R ON AC.DOCUMENT_ID = R.DocumentID
					WHERE
						AC.ALERT_ID = @ALERT_ID
						AND PROOFING_STATUS_ID IS NOT NULL
						AND AC.PROOFING_STATUS_ID = 1
					GROUP BY
						AC.DOCUMENT_ID
				) AS B INNER JOIN @WORKING_TABLE R ON B.DOCUMENT_ID = R.DocumentID
			;
		END
		-- TOTAL REJECTS
		BEGIN
			UPDATE @WORKING_TABLE SET TotalRejects = B.CT
			FROM
				(
					SELECT
						AC.DOCUMENT_ID,
						CT = COUNT(1)
					FROM
						ALERT_COMMENT AC WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE R ON AC.DOCUMENT_ID = R.DocumentID
					WHERE
						AC.ALERT_ID = @ALERT_ID
						AND PROOFING_STATUS_ID IS NOT NULL
						AND AC.PROOFING_STATUS_ID = 2
					GROUP BY
						AC.DOCUMENT_ID
				) AS B INNER JOIN @WORKING_TABLE R ON B.DOCUMENT_ID = R.DocumentID
			;
		END
		-- TOTAL DEFERS
		BEGIN
			UPDATE @WORKING_TABLE SET TotalDefers = B.CT
			FROM
				(
					SELECT
						AC.DOCUMENT_ID,
						CT = COUNT(1)
					FROM
						ALERT_COMMENT AC WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE R ON AC.DOCUMENT_ID = R.DocumentID
					WHERE
						AC.ALERT_ID = @ALERT_ID
						AND PROOFING_STATUS_ID IS NOT NULL
						AND AC.PROOFING_STATUS_ID = 3
					GROUP BY
						AC.DOCUMENT_ID
				) AS B INNER JOIN @WORKING_TABLE R ON B.DOCUMENT_ID = R.DocumentID
			;
		END
		--	TOTAL MARKUPS
		BEGIN
			UPDATE @WORKING_TABLE SET TotalMarkups = A.CT
			FROM
				(
					SELECT 
						CT = COUNT(1),
						PM.DOCUMENT_ID
					FROM 
						PROOFING_MARKUP PM WITH(NOLOCK)
						INNER JOIN @WORKING_TABLE R ON PM.DOCUMENT_ID = R.DocumentID
					GROUP BY
						PM.DOCUMENT_ID
				) AS A INNER JOIN @WORKING_TABLE RR ON A.DOCUMENT_ID = RR.DocumentID
		END
		-- LATEST MARKUP
		BEGIN
			-- INTERNAL
			UPDATE @WORKING_TABLE SET
				InternalLatestMarkupDate = PMM.GENERATED_DATE,
				InternalLatestMarkupFullName = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
			FROM
				(
				SELECT
					PM_ID = MAX(PM.ID),
					PM.DOCUMENT_ID
				FROM
					PROOFING_MARKUP PM WITH(NOLOCK)
					INNER JOIN @WORKING_TABLE R ON PM.DOCUMENT_ID = R.DocumentID
				GROUP BY
					PM.DOCUMENT_ID
				) AS A INNER JOIN @WORKING_TABLE RR ON RR.DocumentID = A.DOCUMENT_ID
				INNER JOIN PROOFING_MARKUP PMM WITH(NOLOCK) ON PMM.DOCUMENT_ID = A.DOCUMENT_ID AND PMM.ID = A.PM_ID
				INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON E.EMP_CODE = PMM.EMP_CODE
			WHERE
				PMM.EMP_CODE IS NOT NULL
				AND PMM.PROOFING_X_REVIEWER_ID IS NULL
				AND InternalLatestMarkupDate IS NULL
			;
			-- EXTERNAL
			UPDATE @WORKING_TABLE SET
				ExternalLatestMarkupDate = PMM.GENERATED_DATE,
				ExternalLatestMarkupFullName = X.[NAME] + ' (XR)'
			FROM
				(
				SELECT
					PM_ID = MAX(PM.ID),
					PM.DOCUMENT_ID
				FROM
					PROOFING_MARKUP PM WITH(NOLOCK)
					INNER JOIN @WORKING_TABLE R ON PM.DOCUMENT_ID = R.DocumentID
				GROUP BY
					PM.DOCUMENT_ID
				) AS A INNER JOIN @WORKING_TABLE RR ON RR.DocumentID = A.DOCUMENT_ID
				INNER JOIN PROOFING_MARKUP PMM WITH(NOLOCK) ON PMM.DOCUMENT_ID = A.DOCUMENT_ID AND PMM.ID = A.PM_ID
				INNER JOIN PROOFING_X_REVIEWER X WITH(NOLOCK) ON X.ID = PMM.PROOFING_X_REVIEWER_ID
			WHERE
				PMM.EMP_CODE IS NULL
				AND PMM.PROOFING_X_REVIEWER_ID IS NOT NULL
				AND ExternalLatestMarkupDate IS NULL
			;
		END
	END
	-- VERSION NUMBER FOR EACH FILE
	BEGIN
		SELECT
			@ROW_COUNT = 0,
			@COUNTER = 0,
			@FILENAME = '',
			@CURRENT_FILENAME = '',
			@VERSION_COUNTER = 0
		;
		SELECT
			@ROW_COUNT = COUNT(1)
		FROM
			@WORKING_TABLE
		;
		IF @ROW_COUNT > 0
		BEGIN
			WHILE @ROW_COUNT > @COUNTER
			BEGIN				
				SELECT @COUNTER = @COUNTER + 1;
				SELECT
					@CURRENT_FILENAME = R.[FileName]
				FROM
					@WORKING_TABLE R
				WHERE
					R.ID = @COUNTER
				;				
				IF @FILENAME <> @CURRENT_FILENAME
				BEGIN
					SELECT @FILENAME = @CURRENT_FILENAME;
					SELECT @VERSION_COUNTER = 0;
				END
				IF @FILENAME = @CURRENT_FILENAME
				BEGIN
					SELECT @VERSION_COUNTER = @VERSION_COUNTER + 1;
					UPDATE @WORKING_TABLE SET 
						[Version] = @VERSION_COUNTER 
					WHERE 
						ID = @COUNTER;
				END
				IF @CURRENT_FILENAME IS NOT NULL
				BEGIN
					UPDATE @WORKING_TABLE SET TotalVersions = B.CT
					FROM
						(
							SELECT
								CT = COUNT(1),
								D.[FILENAME]
							FROM
								DOCUMENTS D WITH(NOLOCK)
							WHERE
								D.[FILENAME] = @CURRENT_FILENAME
							GROUP BY
								D.[FILENAME]
						) AS B INNER JOIN @WORKING_TABLE R ON R.[FileName] = B.[FILENAME]
					;
					UPDATE @WORKING_TABLE SET TotalVersionsForAlertID = B.CT
					FROM
						(
							SELECT
								CT = COUNT(1),
								D.[FILENAME]
							FROM
								DOCUMENTS D WITH(NOLOCK)
								INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID
							WHERE
								D.[FILENAME] = @CURRENT_FILENAME
								AND AA.ALERT_ID = @ALERT_ID
							GROUP BY
								D.[FILENAME]
						) AS B INNER JOIN @WORKING_TABLE R ON R.[FileName] = B.[FILENAME]
					;
				END
			END
		END
	END
	-- CUSTOM SORT
	BEGIN
		DECLARE @DISTINCT_FILENAMES TABLE (DOCUMENT_ID INT, [FILENAME] VARCHAR(MAX))
		DECLARE @FILE_ORDER TABLE (ID INT IDENTITY, DOCUMENT_ID INT, [FILENAME] VARCHAR(MAX))
		INSERT INTO @DISTINCT_FILENAMES ([FILENAME])
		SELECT DISTINCT
			D.[FILENAME]
		FROM
			DOCUMENTS D WITH(NOLOCK)
			INNER JOIN @WORKING_TABLE R ON D.DOCUMENT_ID = R.DocumentID
		;
		UPDATE @DISTINCT_FILENAMES SET DOCUMENT_ID = A.DOCUMENT_ID
		FROM
			(
				SELECT
					DOCUMENT_ID = MIN(DOCUMENT_ID),
					D.[FILENAME]
				FROM
					DOCUMENTS D WITH(NOLOCK)
					INNER JOIN @WORKING_TABLE R ON D.DOCUMENT_ID = R.DocumentID
				GROUP BY
					D.[FILENAME]
			) AS A
			INNER JOIN @DISTINCT_FILENAMES DF ON A.[FILENAME] = DF.[FILENAME]
		;
		INSERT INTO @FILE_ORDER (DOCUMENT_ID, [FILENAME])
		SELECT 
			DF.DOCUMENT_ID,
			DF.[FILENAME]
		FROM 
			@DISTINCT_FILENAMES DF
		ORDER BY
			DF.DOCUMENT_ID
		;
		UPDATE @WORKING_TABLE SET FileOrder = F.ID
		FROM 
			@FILE_ORDER F
			INNER JOIN @WORKING_TABLE R ON F.[FILENAME] = R.[FileName]
		;
	END
	-- CLEAN UP
	BEGIN
		IF @IS_PROOF = 1
		BEGIN
			UPDATE @WORKING_TABLE 
			SET InternalIsLatest =	CASE
										WHEN InternalLatestMarkupDate IS NOT NULL AND ExternalLatestMarkupDate IS NULL THEN 1
										WHEN InternalLatestMarkupDate IS NULL AND ExternalLatestMarkupDate IS NOT NULL THEN 0
										WHEN InternalLatestMarkupDate IS NOT NULL AND ExternalLatestMarkupDate IS NOT NULL AND InternalLatestMarkupDate > ExternalLatestMarkupDate THEN 1
										WHEN InternalLatestMarkupDate IS NOT NULL AND ExternalLatestMarkupDate IS NOT NULL AND InternalLatestMarkupDate < ExternalLatestMarkupDate THEN 0
										ELSE NULL
									END
			;
			UPDATE @WORKING_TABLE
			SET
				LatestMarkupDate =	CASE
										WHEN InternalIsLatest = 1 THEN InternalLatestMarkupDate
										WHEN InternalIsLatest = 0 THEN ExternalLatestMarkupDate
									END,
				LatestMarkupFullName =	CASE
											WHEN InternalIsLatest = 1 THEN InternalLatestMarkupFullName
											WHEN InternalIsLatest = 0 THEN ExternalLatestMarkupFullName
										END
			;
		END
	END
	-- INTO RETURN TABLE
	BEGIN
		INSERT INTO @RETURN_TABLE (DocumentID, 
								   IsLatestDocument, 
								   TotalApproves, 
								   TotalRejects, 
								   TotalDefers, 
								   TotalMarkups, 
								   [Version], 
								   TotalVersions, 
								   TotalVersionsForAlertID, 
								   InternalLatestMarkupFullName, 
								   InternalLatestMarkupDate,
								   ExternalLatestMarkupFullName, 
								   ExternalLatestMarkupDate,
								   LatestMarkupFullName,
								   LatestMarkupDate,
								   TotalComments)
		SELECT
			W.DocumentID,
			ISNULL(W.IsLatestDocument, 0),
			ISNULL(W.TotalApproves, 0),
			ISNULL(W.TotalRejects, 0),
			ISNULL(W.TotalDefers, 0),
			ISNULL(W.TotalMarkups, 0),
			ISNULL(W.[Version], 1),
			ISNULL(W.TotalVersions, 0),
			ISNULL(W.TotalVersionsForAlertID, 0),
			W.InternalLatestMarkupFullName,
			W.InternalLatestMarkupDate,
			W.ExternalLatestMarkupFullName,
			W.ExternalLatestMarkupDate,
			W.LatestMarkupFullName,
			W.LatestMarkupDate,
			ISNULL(W.TotalComments, 0)
		FROM
			@WORKING_TABLE W
		ORDER BY
			W.FileOrder,
			W.[Version]
		;
	END
END
/*=========== QUERY ===========*/

RETURN

END