IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_get_list]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_get_list];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_get_list] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@SHOW_COMPLETED BIT
AS
/*=========== QUERY ===========*/
BEGIN
	-- VARS
	BEGIN
		DECLARE
			@DATA TABLE	(	ID INT IDENTITY,
							AlertID INT NULL,
							[Title] VARCHAR(MAX) NULL,
							[Description] VARCHAR(MAX) NULL,
							[IsRouted] BIT NULL,
							[Created] SMALLDATETIME NULL,
							[CreatedByUserCode] VARCHAR(100) NULL,
							[CreatedByName] VARCHAR(300) NULL,
							[IsCompleted] BIT DEFAULT(0) NULL,
							[Completed] SMALLDATETIME NULL,
							[LastUpdatedName] VARCHAR(300) NULL,
							[InternalTotalReviewers] INT DEFAULT(0) NULL,
							[InternalTotalApproved] INT DEFAULT(0) NULL,
							[InternalTotalDeferred] INT DEFAULT(0) NULL,
							[InternalTotalRejected] INT DEFAULT(0) NULL,
							[ExternalTotalApproved] INT DEFAULT(0) NULL,
							[ExternalTotalDeferred] INT DEFAULT(0) NULL,
							[ExternalTotalRejected] INT DEFAULT(0) NULL,
							[ExternalTotalReviewers] INT DEFAULT(0) NULL,
							[TotalApproved] INT DEFAULT(0) NULL,
							[TotalDeferred] INT DEFAULT(0) NULL,
							[TotalRejected] INT DEFAULT(0) NULL,
							[TotalReviewers] INT DEFAULT(0) NULL,
							[TotalMarkups] INT DEFAULT(0) NULL,
							[TotalComments] INT DEFAULT(0) NULL,
							[InternalLastCommentDate] SMALLDATETIME NULL,
							[InternalLastCommentFullName] VARCHAR(1000) NULL,
							[InternalLastMarkupDate] SMALLDATETIME NULL,
							[InternalLastMarkupFullName] VARCHAR(1000) NULL,
							[ExternalLastCommentDate] SMALLDATETIME NULL,
							[ExternalLastCommentFullName] VARCHAR(1000) NULL,
							[ExternalLastMarkupDate] SMALLDATETIME NULL,
							[ExternalLastMarkupFullName] VARCHAR(1000) NULL,
							[InternalStatusDisplay]  VARCHAR(500) NULL,
							[ExternalStatusDisplay]  VARCHAR(500) NULL,
							[StatusDisplay]  VARCHAR(500) NULL,
							[TotalDocuments] INT DEFAULT(0) NULL,
							[LatestDocumentID] INT DEFAULT(0) NULL,
							[LatestThumbnail] IMAGE NULL,
							[AlertTemplateID] INT NULL,
							[AlertTemplateName] VARCHAR(1000) NULL,
							[AlertStateID] INT NULL,
							[AlertStateName] VARCHAR(1000) NULL,
							[CompletedText] VARCHAR(10) NULL,
							[RoutedText] VARCHAR(10) NULL							
						)
			;	
		DECLARE
			@ALERT_ID INT = 0,
			@IS_ROUTED BIT = 0,
			@INTERNAL_TOTAL_REVIEWERS INT = 0,
			@INTERNAL_TOTAL_REJECTED INT = 0,
			@INTERNAL_TOTAL_APPROVED INT = 0,
			@INTERNAL_TOTAL_DEFERRED INT = 0,
			@X_TOTAL_REVIEWERS INT = 0,
			@X_TOTAL_REJECTED INT = 0,
			@X_TOTAL_APPROVED INT = 0,
			@X_TOTAL_DEFERRED INT = 0,
			@TOTAL_MARKUPS INT = 0,
			@TOTAL_COMMENTS INT = 0,
			@TOTAL_DOCUMENTS INT = 0,
			@INTERNAL_LAST_MARKUP_DATE SMALLDATETIME = NULL,
			@INTERNAL_LAST_MARKUP_FULL_NAME VARCHAR(1000) = NULL,
			@INTERNAL_LAST_COMMENT_DATE SMALLDATETIME = NULL,
			@INTERNAL_LAST_COMMENT_FULL_NAME VARCHAR(1000) = NULL,
			@EXTERNAL_LAST_MARKUP_DATE SMALLDATETIME = NULL,
			@EXTERNAL_LAST_MARKUP_FULL_NAME VARCHAR(1000) = NULL,
			@EXTERNAL_LAST_COMMENT_DATE SMALLDATETIME = NULL,
			@EXTERNAL_LAST_COMMENT_FULL_NAME VARCHAR(1000) = NULL,
			@LATEST_DOCUMENT_ID INT = NULL,
			@ALRT_NOTIFY_HDR INT = 0,
			@ALERT_STATE_ID INT = 0
		;
	END
	--	BASE 
	BEGIN
		INSERT INTO @DATA (AlertID, [Title], [Description], [IsCompleted], [Created], [CreatedByUserCode], [LastUpdatedName], IsRouted, AlertTemplateID, AlertStateID)
		SELECT
			A.ALERT_ID,
			A.[SUBJECT],
			A.BODY,
			CAST(ISNULL(A.ASSIGN_COMPLETED, 0) AS BIT),
			A.[GENERATED],
			A.ALERT_USER,
			A.LAST_UPDATED_FML,
			CASE
				WHEN	A.ALRT_NOTIFY_HDR_ID IS NOT NULL AND A.ALRT_NOTIFY_HDR_ID > 0 
						AND A.ALERT_STATE_ID IS NOT NULL AND A.ALERT_STATE_ID > 0 THEN 1
				ELSE 0
			END,
			A.ALRT_NOTIFY_HDR_ID,
			A.ALERT_STATE_ID
		FROM
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_CAT_ID = 79
			AND 1 =	CASE
						WHEN @JOB_NUMBER IS NULL OR @JOB_NUMBER = 0 THEN 1
						WHEN @JOB_NUMBER IS NOT NULL AND A.JOB_NUMBER = @JOB_NUMBER THEN 
							CASE
								WHEN @JOB_COMPONENT_NBR IS NULL OR @JOB_COMPONENT_NBR = 0 THEN 1
								WHEN @JOB_COMPONENT_NBR IS NOT NULL AND A.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR THEN 1
								ELSE 0
							END
						ELSE 0
					END
		;
	END
	--	EACH PROOF
	BEGIN
		DECLARE
			@REC_COUNT INT,
			@REC_COUNTER INT
		;
		SELECT
			@REC_COUNT = 0,
			@REC_COUNTER = 0
		;
		SELECT
			@REC_COUNT = COUNT(1)
		FROM
			@DATA D
		;
		IF @REC_COUNT > 0
		BEGIN
			WHILE @REC_COUNT > @REC_COUNTER
			BEGIN
				SELECT
					@REC_COUNTER = @REC_COUNTER + 1,
					@ALERT_ID = 0,
					@IS_ROUTED = 0,
					@INTERNAL_TOTAL_REVIEWERS = 0,
					@INTERNAL_TOTAL_APPROVED = 0,
					@INTERNAL_TOTAL_REJECTED = 0,
					@INTERNAL_TOTAL_DEFERRED = 0,
					@X_TOTAL_REVIEWERS = 0,
					@X_TOTAL_APPROVED = 0,
					@X_TOTAL_REJECTED = 0,
					@X_TOTAL_DEFERRED = 0,
					@INTERNAL_TOTAL_APPROVED = 0,
					@TOTAL_MARKUPS = 0,
					@TOTAL_COMMENTS = 0,
					@TOTAL_DOCUMENTS = 0,
					@INTERNAL_LAST_MARKUP_DATE = NULL,--
					@INTERNAL_LAST_MARKUP_FULL_NAME = NULL,--
					@INTERNAL_LAST_COMMENT_DATE = NULL,--
					@INTERNAL_LAST_COMMENT_FULL_NAME = NULL,--
					@EXTERNAL_LAST_MARKUP_DATE = NULL,--
					@EXTERNAL_LAST_MARKUP_FULL_NAME = NULL,--
					@EXTERNAL_LAST_COMMENT_DATE = NULL,--
					@EXTERNAL_LAST_COMMENT_FULL_NAME = NULL,--
					@LATEST_DOCUMENT_ID = NULL
				;
				SELECT
					@ALERT_ID = ISNULL(D.AlertID, 0),
					@IS_ROUTED = ISNULL(D.IsRouted, 0)
				FROM
					@DATA D
				WHERE
					D.ID = @REC_COUNTER
				;
				IF @ALERT_ID > 0
				BEGIN
					-- GATHER INTERNAL REVIEWERS STATS
					IF @IS_ROUTED = 0
					BEGIN
						--	TOTAL REVIEWERS
						BEGIN							
							SELECT @INTERNAL_TOTAL_REVIEWERS = 0;
							SELECT @INTERNAL_TOTAL_REVIEWERS = @INTERNAL_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
							)
							SELECT @INTERNAL_TOTAL_REVIEWERS = @INTERNAL_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
							)
							UPDATE @DATA SET InternalTotalReviewers = @INTERNAL_TOTAL_REVIEWERS WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL APPROVED
						BEGIN							
							SELECT @INTERNAL_TOTAL_APPROVED = 0;
							SELECT @INTERNAL_TOTAL_APPROVED = @INTERNAL_TOTAL_APPROVED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.PROOFING_STATUS_ID = 1
							)
							UPDATE @DATA SET InternalTotalApproved = @INTERNAL_TOTAL_APPROVED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL REJECTED
						BEGIN							
							SELECT @INTERNAL_TOTAL_REJECTED = 0;
							SELECT @INTERNAL_TOTAL_REJECTED = @INTERNAL_TOTAL_REJECTED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.PROOFING_STATUS_ID = 2
							)
							UPDATE @DATA SET InternalTotalRejected = @INTERNAL_TOTAL_REJECTED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL DEFERRED
						BEGIN							
							SELECT @INTERNAL_TOTAL_DEFERRED = 0;
							SELECT @INTERNAL_TOTAL_DEFERRED = @INTERNAL_TOTAL_DEFERRED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.PROOFING_STATUS_ID = 3
							)
							UPDATE @DATA SET InternalTotalDeferred = @INTERNAL_TOTAL_DEFERRED WHERE AlertID = @ALERT_ID;
						END
					END
					ELSE
					BEGIN
						SELECT
							@ALRT_NOTIFY_HDR = A.ALRT_NOTIFY_HDR_ID,
							@ALERT_STATE_ID = A.ALERT_STATE_ID
						FROM
							ALERT A WITH(NOLOCK)
						WHERE
							A.ALERT_ID = @ALERT_ID
						;
						--	TOTAL REVIEWERS
						BEGIN							
							SELECT @INTERNAL_TOTAL_REVIEWERS = 0;
							SELECT @INTERNAL_TOTAL_REVIEWERS = @INTERNAL_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR
									AND R.ALERT_STATE_ID = @ALERT_STATE_ID
							)
							SELECT @INTERNAL_TOTAL_REVIEWERS = @INTERNAL_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR
									AND R.ALERT_STATE_ID = @ALERT_STATE_ID
							)
							UPDATE @DATA SET InternalTotalReviewers = @INTERNAL_TOTAL_REVIEWERS WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL APPROVED
						BEGIN							
							SELECT @INTERNAL_TOTAL_APPROVED = 0;
							SELECT @INTERNAL_TOTAL_APPROVED = @INTERNAL_TOTAL_APPROVED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR
									AND R.ALERT_STATE_ID = @ALERT_STATE_ID
									AND R.PROOFING_STATUS_ID = 1
							)
							UPDATE @DATA SET InternalTotalApproved = @INTERNAL_TOTAL_APPROVED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL REJECTED
						BEGIN							
							SELECT @INTERNAL_TOTAL_REJECTED = 0;
							SELECT @INTERNAL_TOTAL_REJECTED = @INTERNAL_TOTAL_REJECTED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR
									AND R.ALERT_STATE_ID = @ALERT_STATE_ID
									AND R.PROOFING_STATUS_ID = 2
							)
							UPDATE @DATA SET InternalTotalRejected = @INTERNAL_TOTAL_REJECTED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL DEFERRED
						BEGIN							
							SELECT @INTERNAL_TOTAL_DEFERRED = 0;
							SELECT @INTERNAL_TOTAL_DEFERRED = @INTERNAL_TOTAL_DEFERRED + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_DISMISSED R WITH(NOLOCK)
								WHERE
									R.ALERT_ID = @ALERT_ID
									AND R.CURRENT_NOTIFY = 1
									AND R.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR
									AND R.ALERT_STATE_ID = @ALERT_STATE_ID
									AND R.PROOFING_STATUS_ID = 3
							)
							UPDATE @DATA SET InternalTotalDeferred = @INTERNAL_TOTAL_DEFERRED WHERE AlertID = @ALERT_ID;
						END
					END
					-- ABSOLUTE LATEST DOCUMENT ID
					BEGIN
						SELECT
							@LATEST_DOCUMENT_ID = MAX(AA.DOCUMENT_ID)
						FROM
							ALERT_ATTACHMENT AA WITH(NOLOCK)
						WHERE
							AA.ALERT_ID = @ALERT_ID
						;
						UPDATE @DATA SET LatestDocumentID = @LATEST_DOCUMENT_ID
						WHERE
							AlertID = @ALERT_ID
						;
					END
					-- EXTERNAL REVIEWERS STATS
					BEGIN
						--	TOTAL EXTERNAL REVIEWERS
						BEGIN							
							SELECT @X_TOTAL_REVIEWERS = 0;
							SELECT @X_TOTAL_REVIEWERS = @X_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_X_REVIEWER XR WITH(NOLOCK)
								WHERE
									XR.ALERT_ID = @ALERT_ID
							)
							SELECT @X_TOTAL_REVIEWERS = @X_TOTAL_REVIEWERS + (
								SELECT
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_X_REVIEWER_DISMISSED XR WITH(NOLOCK)
								WHERE
									XR.ALERT_ID = @ALERT_ID
							)
							UPDATE @DATA SET ExternalTotalReviewers = @X_TOTAL_REVIEWERS WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL EXTERNAL APPROVED
						BEGIN							
							SELECT @X_TOTAL_APPROVED = 0;
							SELECT @X_TOTAL_APPROVED = @X_TOTAL_APPROVED + (
								SELECT	
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_X_REVIEWER_DISMISSED X WITH(NOLOCK)
								WHERE
									X.ALERT_ID = @ALERT_ID
									AND X.PROOFING_STATUS_ID = 1
							)
							UPDATE @DATA SET ExternalTotalApproved = @X_TOTAL_APPROVED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL EXTERNAL REJECTED
						BEGIN							
							SELECT @X_TOTAL_REJECTED = 0;
							SELECT @X_TOTAL_REJECTED = @X_TOTAL_REJECTED + (
								SELECT	
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_X_REVIEWER_DISMISSED X WITH(NOLOCK)
								WHERE
									X.ALERT_ID = @ALERT_ID
									AND X.PROOFING_STATUS_ID = 2
							)
							UPDATE @DATA SET ExternalTotalRejected = @X_TOTAL_REJECTED WHERE AlertID = @ALERT_ID;
						END
						--	TOTAL EXTERNAL DEFERRED
						BEGIN							
							SELECT @X_TOTAL_DEFERRED = 0;
							SELECT @X_TOTAL_DEFERRED = @X_TOTAL_DEFERRED + (
								SELECT	
									COUNT(1) AS CT
								FROM
									ALERT_RCPT_X_REVIEWER_DISMISSED X WITH(NOLOCK)
								WHERE
									X.ALERT_ID = @ALERT_ID
									AND X.PROOFING_STATUS_ID = 3
							)
							UPDATE @DATA SET ExternalTotalDeferred = @X_TOTAL_DEFERRED WHERE AlertID = @ALERT_ID;
						END
					END
					-- DOCUMENT COUNT
					BEGIN
						SELECT @TOTAL_DOCUMENTS = COUNT(1)
						FROM
							ALERT_ATTACHMENT AA WITH(NOLOCK)
						WHERE
							AA.ALERT_ID = @ALERT_ID
						;
						UPDATE @DATA SET TotalDocuments = @TOTAL_DOCUMENTS WHERE AlertID = @ALERT_ID;
					END
					-- NON-SYSTEM COMMENT COUNT
					BEGIN
						SELECT @TOTAL_COMMENTS = COUNT(1)
						FROM
							ALERT_COMMENT AC WITH(NOLOCK)
						WHERE
							AC.ALERT_ID = @ALERT_ID
							AND (AC.IS_SYSTEM IS NULL OR AC.IS_SYSTEM = 0)
						;
						UPDATE @DATA SET TotalComments = @TOTAL_COMMENTS WHERE AlertID = @ALERT_ID;
					END
					-- MARKUP COUNT
					BEGIN
						SELECT @TOTAL_MARKUPS = COUNT(1) 
						FROM
							PROOFING_MARKUP PM WITH(NOLOCK)
							INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON PM.COMMENT_ID = AC.COMMENT_ID
						WHERE
							AC.ALERT_ID = @ALERT_ID
						;
						UPDATE @DATA SET TotalMarkups = @TOTAL_MARKUPS WHERE AlertID = @ALERT_ID;
					END
					-- LATEST COMMENT BY
					BEGIN
						--	INTERNAL
						BEGIN
							SELECT 
								@INTERNAL_LAST_COMMENT_DATE = ACC.GENERATED_DATE,
								@INTERNAL_LAST_COMMENT_FULL_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
							FROM
								ALERT_COMMENT ACC WITH(NOLOCK)
								INNER JOIN SEC_USER SU WITH(NOLOCK) ON ACC.USER_CODE = SU.USER_CODE
								INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON E.EMP_CODE = SU.EMP_CODE
							WHERE
								ACC.COMMENT_ID =	(
														SELECT 
															MAX(AC.COMMENT_ID)
														FROM
															ALERT_COMMENT AC WITH(NOLOCK)
														WHERE
															AC.ALERT_ID = @ALERT_ID
															AND (AC.IS_SYSTEM IS NULL OR AC.IS_SYSTEM = 0)
															AND AC.PROOFING_X_REVIEWER_ID IS NULL
													)
							;
							UPDATE @DATA SET
								InternalLastCommentDate = @INTERNAL_LAST_COMMENT_DATE,
								InternalLastCommentFullName = @INTERNAL_LAST_COMMENT_FULL_NAME
							WHERE
								AlertID = @ALERT_ID
							;
						END
						--	EXTERNAL
						BEGIN
							SELECT 
								@EXTERNAL_LAST_COMMENT_DATE = ACC.GENERATED_DATE,
								@EXTERNAL_LAST_COMMENT_FULL_NAME = X.[NAME]
							FROM
								ALERT_COMMENT ACC WITH(NOLOCK)
								INNER JOIN PROOFING_X_REVIEWER X WITH(NOLOCK) ON ACC.PROOFING_X_REVIEWER_ID = X.ID
							WHERE
								ACC.COMMENT_ID =	(
														SELECT 
															MAX(AC.COMMENT_ID)
														FROM
															ALERT_COMMENT AC WITH(NOLOCK)
														WHERE
															AC.ALERT_ID = @ALERT_ID
															AND (AC.IS_SYSTEM IS NULL OR AC.IS_SYSTEM = 0)
															AND AC.PROOFING_X_REVIEWER_ID IS NOT NULL
													)
							;
							UPDATE @DATA SET
								ExternalLastCommentDate = @EXTERNAL_LAST_COMMENT_DATE,
								ExternalLastCommentFullName = @EXTERNAL_LAST_COMMENT_FULL_NAME
							WHERE
								AlertID = @ALERT_ID
							;
						END
					END
					-- LATEST MARKUP BY
					BEGIN
						-- INTERNAL
						BEGIN
							SELECT
								@INTERNAL_LAST_MARKUP_DATE = P.GENERATED_DATE,
								@INTERNAL_LAST_MARKUP_FULL_NAME = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
							FROM
								PROOFING_MARKUP P WITH(NOLOCK)
								INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON P.EMP_CODE = E.EMP_CODE
							WHERE
								P.ID =	(
											SELECT
												MAX(PM.ID)
											FROM
												PROOFING_MARKUP PM WITH(NOLOCK)
												INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON PM.COMMENT_ID = AC.COMMENT_ID
											WHERE
												AC.ALERT_ID = @ALERT_ID
												AND PM.EMP_CODE IS NOT NULL
												AND PM.PROOFING_X_REVIEWER_ID IS NULL
										)
							;
							UPDATE @DATA SET
								InternalLastMarkupDate = @INTERNAL_LAST_MARKUP_DATE,
								InternalLastMarkupFullName = @INTERNAL_LAST_MARKUP_FULL_NAME
							WHERE
								AlertID = @ALERT_ID
							;
						END
						-- EXTERNAL
						BEGIN
							SELECT
								@EXTERNAL_LAST_MARKUP_DATE = P.GENERATED_DATE,
								@EXTERNAL_LAST_MARKUP_FULL_NAME = X.[NAME]
							FROM
								PROOFING_MARKUP P WITH(NOLOCK)
								INNER JOIN PROOFING_X_REVIEWER X WITH(NOLOCK) ON P.PROOFING_X_REVIEWER_ID = X.ID
							WHERE
								P.ID =	(
											SELECT
												MAX(PM.ID)
											FROM
												PROOFING_MARKUP PM WITH(NOLOCK)
												INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON PM.COMMENT_ID = AC.COMMENT_ID
											WHERE
												AC.ALERT_ID = @ALERT_ID
												AND PM.EMP_CODE IS NULL
												AND PM.PROOFING_X_REVIEWER_ID IS NOT NULL
										)
							;
							UPDATE @DATA SET
								ExternalLastMarkupDate = @EXTERNAL_LAST_MARKUP_DATE,
								ExternalLastMarkupFullName = @EXTERNAL_LAST_MARKUP_FULL_NAME
							WHERE
								AlertID = @ALERT_ID
							;
						END



					END
				END
			END
		END
	END
	--	CLEANUP
	BEGIN
		UPDATE @DATA SET AlertTemplateName = ANH.ALERT_NOTIFY_NAME
		FROM
			@DATA D
			INNER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON D.AlertTemplateID = ANH.ALRT_NOTIFY_HDR_ID
		;
		UPDATE @DATA SET AlertStateName = AA.ALERT_STATE_NAME
		FROM
			@DATA D
			INNER JOIN ALERT_STATES AA WITH(NOLOCK) ON D.AlertStateID = AA.ALERT_STATE_ID
		;
		UPDATE @DATA SET CreatedByName = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + ' .', '') + ISNULL(E.EMP_LNAME, '')
		FROM
			@DATA D 
			INNER JOIN SEC_USER S WITH(NOLOCK) ON D.CreatedByUserCode = S.USER_CODE
			INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON E.EMP_CODE = S.EMP_CODE
		;		
		UPDATE @DATA SET LatestThumbnail = DD.THUMBNAIL
		FROM
			@DATA D
			INNER JOIN DOCUMENTS DD WITH(NOLOCK) ON D.LatestDocumentID = DD.DOCUMENT_ID
		WHERE
			DD.THUMBNAIL IS NOT NULL
		;
		UPDATE @DATA SET InternalStatusDisplay =  CAST(ISNULL(InternalTotalApproved, 0) + ISNULL(InternalTotalDeferred, 0) + ISNULL(InternalTotalRejected, 0) AS VARCHAR) 
			+ '/' + CAST(ISNULL(InternalTotalReviewers, 0) AS VARCHAR);
		UPDATE @DATA SET ExternalStatusDisplay =  CAST(ISNULL(ExternalTotalApproved, 0) + ISNULL(ExternalTotalDeferred, 0) + ISNULL(ExternalTotalRejected, 0) AS VARCHAR) 
			+ '/' + CAST(ISNULL(ExternalTotalReviewers, 0) AS VARCHAR);
		UPDATE @DATA SET StatusDisplay =  CAST(ISNULL(InternalTotalApproved, 0) + ISNULL(InternalTotalDeferred, 0) + ISNULL(InternalTotalRejected, 0) + ISNULL(ExternalTotalApproved, 0) + ISNULL(ExternalTotalDeferred, 0) + ISNULL(ExternalTotalRejected, 0) AS VARCHAR) 
			+ '/' + CAST(ISNULL(InternalTotalReviewers, 0) + ISNULL(ExternalTotalReviewers, 0) AS VARCHAR);
		UPDATE @DATA SET [Description] = NULL WHERE DATALENGTH([Description]) = 0;
		UPDATE @DATA SET [CompletedText] =	CASE
												WHEN IsCompleted IS NULL OR IsCompleted = 0 then 'No'
												ELSE 'Yes'
											END;
		UPDATE @DATA SET [RoutedText] =	CASE
											WHEN IsRouted IS NULL OR IsRouted = 0 then 'No'
											ELSE 'Yes'
										END;
		UPDATE @DATA SET 
			TotalApproved = ISNULL(InternalTotalApproved, 0) + ISNULL(ExternalTotalApproved, 0),
			TotalRejected = ISNULL(InternalTotalRejected, 0) + ISNULL(ExternalTotalRejected, 0),
			TotalDeferred = ISNULL(InternalTotalDeferred, 0) + ISNULL(ExternalTotalDeferred, 0),
			TotalReviewers = ISNULL(InternalTotalReviewers, 0) + ISNULL(ExternalTotalReviewers, 0)
		;
		--UPDATE @DATA SET [AlertTemplateName] = 'NA' WHERE  [AlertTemplateID] IS NULL OR [AlertTemplateID] = 0;
		--UPDATE @DATA SET [AlertStateName] = 'NA' WHERE  [AlertStateID] IS NULL OR [AlertStateID] = 0;
	END
	--	RETURN
	BEGIN
		SELECT
			[ID] = D.ID,
			[AlertID] = D.AlertID,
			[Title] = D.Title,
			[Description] = D.[Description],
			[Created] = D.Created,
			[CreatedByUserCode] = D.CreatedByUserCode,
			[CreatedByName] = D.CreatedByName,
			[IsRouted] = D.IsRouted,
			[IsCompleted] = D.IsCompleted,
			[LastUpdatedName] = D.LastUpdatedName,
			[InternalTotalReviewers] = D.InternalTotalReviewers,
			[InternalTotalApproved] = D.InternalTotalApproved,
			[InternalTotalRejected] = D.InternalTotalRejected,
			[InternalTotalDeferred] = D.InternalTotalDeferred,
			[ExternalTotalReviewers] = D.ExternalTotalReviewers,
			[ExternalTotalApproved] = D.ExternalTotalApproved,
			[ExternalTotalRejected] = D.ExternalTotalRejected,
			[ExternalTotalDeferred] = D.ExternalTotalDeferred,
			[TotalReviewers] = D.TotalReviewers,
			[TotalApproved] = D.TotalApproved,
			[TotalRejected] = D.TotalRejected,
			[TotalDeferred] = D.TotalDeferred,
			[InternalStatusDisplay] = D.InternalStatusDisplay,
			[ExternalStatusDisplay] = D.ExternalStatusDisplay,
			[StatusDisplay] = D.StatusDisplay,
			[LatestDocumentID] = ISNULL(D.LatestDocumentID, 0),
			[LatestThumbnail] = D.LatestThumbnail,
			[AlertTemplateID] = D.AlertTemplateID,
			[AlertTemplateName] = D.AlertTemplateName,
			[AlertStateID] = D.AlertStateID,
			[AlertStateName] = D.AlertStateName,
			[CompletedText] = D.CompletedText,
			[RoutedText] = D.RoutedText,
			[InternalLastCommentDate] = D.InternalLastCommentDate,
			[InternalLastCommentFullName] = D.InternalLastCommentFullName,
			[ExternalLastCommentDate] = D.ExternalLastCommentDate,
			[ExternalLastCommentFullName] = D.ExternalLastCommentFullName,
			[InternalLastMarkupDate] = D.InternalLastMarkupDate,
			[InternalLastMarkupFullName] = D.InternalLastMarkupFullName,
			[ExternalLastMarkupDate] = D.ExternalLastMarkupDate,
			[ExternalLastMarkupFullName] = D.ExternalLastMarkupFullName,
			[TotalDocuments] = D.TotalDocuments,
			[TotalMarkups] = D.TotalMarkups,
			[TotalComments] = D.TotalComments
		FROM
			@DATA D
		WHERE
			1 =	CASE
					WHEN (@SHOW_COMPLETED IS NULL OR @SHOW_COMPLETED = 0) AND ISNULL(D.IsCompleted, 0) = 0 THEN 1
					WHEN @SHOW_COMPLETED = 1 THEN 1
					ELSE 0
				END
		ORDER BY
			D.Created DESC
		;
	END
END
/*=========== QUERY ===========*/