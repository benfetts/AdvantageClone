IF EXISTS ( SELECT * FROM sysobjects WHERE id = OBJECT_ID( N'[dbo].[advtf_proofing_get_approvals_list]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advtf_proofing_get_approvals_list]
END
GO
CREATE FUNCTION [dbo].[advtf_proofing_get_approvals_list] (
@ALERT_ID INT,
@DOCUMENT_ID INT = NULL
)
RETURNS @RET_TABLE TABLE (
							[AlertStateID] INT,
							[AlertStateName] VARCHAR(100),
							[EmployeeCode] VARCHAR(6),
							[Name] VARCHAR(500),
							[ProofingStatusID] INT,
							[ProofingStatus] VARCHAR(100),
							[ApproveDate] SMALLDATETIME,
							[IsCurrentState] BIT,
							[SequenceNumber] SMALLINT,
							[DocumentID] INT,
							[ProofingStatusExternalReviewerID] INT,
							[TotalMarkupCount] INT
							)
AS
BEGIN
/*=========== QUERY ===========*/
	--  VARS
	BEGIN
		DECLARE @APPROVALS TABLE (	[ID] INT IDENTITY,
									[AlertStateID] INT,
									[AlertStateName] VARCHAR(100),
									[EmployeeCode] VARCHAR(6),
									[Name] VARCHAR(500),
									[ProofingStatusID] SMALLINT,
									[ProofingStatus] VARCHAR(100),
									[ApproveDate] SMALLDATETIME,
									[IsCurrentState] BIT,
									[SequenceNumber] SMALLINT,
									[DocumentID] INT,
									[ProofingStatusExternalReviewerID] INT,
									[AlertCommentID] INT,
									[TotalMarkupCount] INT
									);
		DECLARE @CURRENT_STATE TABLE (	[ID] INT IDENTITY,
										[AlertStateID] INT,
										[AlertStateName] VARCHAR(100),
										[EmployeeCode] VARCHAR(6),
										[Name] VARCHAR(500),
										[ProofingStatusID] SMALLINT,
										[ProofingStatus] VARCHAR(100),
										[ApproveDate] SMALLDATETIME,
										[IsCurrentState] BIT,
										[SequenceNumber] SMALLINT,
										[DocumentID] INT
										);
		DECLARE
			@ALRT_NOTIFY_ID INT,
			@ALERT_STATE_ID INT,
			@ALERT_STATE_NAME VARCHAR(100),
			@SHOW_ALL BIT,
			@IS_CURRENT_DOC BIT,
			@IS_ROUTED BIT
		;
	END
	--  INIT
	BEGIN
		IF @DOCUMENT_ID IS NULL OR @DOCUMENT_ID = 0
		BEGIN
			SELECT 
				@SHOW_ALL = 1, 
				@IS_CURRENT_DOC = 1
			;
		END
		ELSE
		BEGIN
			SELECT @SHOW_ALL = 0;
			SELECT 
				@IS_CURRENT_DOC =	CASE 
										WHEN MAX(D.DOCUMENT_ID) = @DOCUMENT_ID THEN 1 
										ELSE 0 
									END  
			FROM 
				DOCUMENTS D WITH(NOLOCK)
				INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID
			WHERE 
				D.DOCUMENT_ID = @DOCUMENT_ID
				AND AA.ALERT_ID = @ALERT_ID
			;
		END
		BEGIN
			SELECT
				@ALRT_NOTIFY_ID = A.ALRT_NOTIFY_HDR_ID,
				@ALERT_STATE_ID = A.ALERT_STATE_ID,
				@IS_ROUTED =	CASE
									WHEN A.ALRT_NOTIFY_HDR_ID > 0 AND A.ALERT_STATE_ID > 0 THEN 1
									ELSE 0
								END
			FROM
				ALERT A WITH(NOLOCK)
			WHERE
				A.ALERT_ID = @ALERT_ID
			;
			IF @ALERT_STATE_ID IS NOT NULL AND @ALERT_STATE_ID > 0
			BEGIN
				SELECT
					@ALERT_STATE_NAME = A.ALERT_STATE_NAME
				FROM	
					ALERT_STATES A WITH(NOLOCK)
				WHERE
					A.ALERT_STATE_ID = @ALERT_STATE_ID
			END
		END
	END
	--  GET ALL ASSIGNEES AT CURRENT STATE
	IF @IS_ROUTED = 1 AND @IS_CURRENT_DOC = 1
	BEGIN
		INSERT INTO @CURRENT_STATE (
			[AlertStateID],
			[AlertStateName], 
			[EmployeeCode], 
			[Name], 
			[IsCurrentState], 
			[SequenceNumber],
			[ProofingStatusID]
		)
		SELECT DISTINCT 
			A.[AlertStateID],
			A.[AlertStateName], 
			A.[EmployeeCode], 
			A.[EmployeeName], 
			A.[IsCurrentState], 
			A.[SequenceNumber],
			A.[ProofingStatusID]
		FROM
			(
				SELECT 
					[AlertStateID] = ANS.ALERT_STATE_ID,
					[AlertStateName] = STS.ALERT_STATE_NAME,
					[EmployeeCode] = AR.EMP_CODE,
					[EmployeeName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
					[IsCurrentState] = 1,
					[SequenceNumber] = ANS.SORT_ORDER,
					[ProofingStatusID] = NULL
				FROM
					ALERT A WITH(NOLOCK)
					INNER JOIN ALERT_RCPT AR WITH(NOLOCK) ON A.ALERT_ID = AR.ALERT_ID 
					INNER JOIN ALERT_NOTIFY_STATES ANS WITH(NOLOCK) ON AR.ALRT_NOTIFY_HDR_ID = ANS.ALRT_NOTIFY_HDR_ID AND AR.ALERT_STATE_ID = ANS.ALERT_STATE_ID
					INNER JOIN ALERT_STATES STS WITH(NOLOCK) ON ANS.ALERT_STATE_ID = STS.ALERT_STATE_ID
					INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
				WHERE
					A.ALERT_ID = @ALERT_ID
					AND ANS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_ID
					AND ANS.ALERT_STATE_ID = @ALERT_STATE_ID
                    AND AR.CURRENT_NOTIFY = 1
					AND E.EMP_TERM_DATE IS NULL
				UNION
				SELECT 
					[AlertStateID] = ANS.ALERT_STATE_ID,
					[AlertStateName] = STS.ALERT_STATE_NAME,
					[EmployeeCode] = AR.EMP_CODE,
					[EmployeeName] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
					[IsCurrentState] = 1,
					[SequenceNumber] = ANS.SORT_ORDER,
					[ProofingStatusID] = AR.PROOFING_STATUS_ID
				FROM
					ALERT A WITH(NOLOCK)
					INNER JOIN ALERT_RCPT_DISMISSED AR WITH(NOLOCK) ON A.ALERT_ID = AR.ALERT_ID 
					INNER JOIN ALERT_NOTIFY_STATES ANS WITH(NOLOCK) ON AR.ALRT_NOTIFY_HDR_ID = ANS.ALRT_NOTIFY_HDR_ID AND AR.ALERT_STATE_ID = ANS.ALERT_STATE_ID
					INNER JOIN ALERT_STATES STS WITH(NOLOCK) ON ANS.ALERT_STATE_ID = STS.ALERT_STATE_ID
                    AND ANS.ALERT_STATE_ID = AR.ALERT_STATE_ID
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON AR.EMP_CODE = E.EMP_CODE
				WHERE
					A.ALERT_ID = @ALERT_ID
					AND ANS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_ID
					AND ANS.ALERT_STATE_ID = @ALERT_STATE_ID
                    AND AR.CURRENT_NOTIFY = 1
					AND E.EMP_TERM_DATE IS NULL
			) AS A
		;
	END
	--	INTERNAL EMPLOYEES
	BEGIN
        --  GET EXISTING APPROVE/DEFER/REJECTS
		IF @IS_ROUTED = 0
		BEGIN
			INSERT INTO @APPROVALS (AlertStateID, [Name], ProofingStatusID, EmployeeCode, DocumentID)
			SELECT
				A.ALERT_STATE_ID, 
				ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + ', ', '') + ISNULL(E.EMP_LNAME, ''),
				A.PROOFING_STATUS_ID,
				A.EMP_CODE,
				@DOCUMENT_ID			
			FROM
				(
					SELECT
						AR.ALERT_STATE_ID,
						AR.PROOFING_STATUS_ID,
						AR.EMP_CODE
					FROM
						ALERT_RCPT AR WITH(NOLOCK)
					WHERE
						AR.ALERT_ID = @ALERT_ID
						AND AR.CURRENT_NOTIFY = 1
					UNION
					SELECT
						ARD.ALERT_STATE_ID,
						ARD.PROOFING_STATUS_ID,
						ARD.EMP_CODE
					FROM
						ALERT_RCPT_DISMISSED ARD WITH(NOLOCK)
					WHERE
						ARD.ALERT_ID = @ALERT_ID
						AND ARD.CURRENT_NOTIFY = 1
				) AS A INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON A.EMP_CODE = E.EMP_CODE
			;
			UPDATE @APPROVALS SET ProofingStatusID = ARD.PROOFING_STATUS_ID
			FROM
				ALERT_RCPT_DISMISSED ARD WITH(NOLOCK)
				INNER JOIN @APPROVALS A ON A.EmployeeCode = ARD.EMP_CODE
			WHERE
				ARD.ALERT_ID = @ALERT_ID
				AND ARD.PROOFING_STATUS_ID IS NOT NULL
			;
		END
		ELSE
		BEGIN -- ROUTED, ONLY OTHER STATES
			INSERT INTO @APPROVALS ([EmployeeCode], [Name], [ProofingStatusID], [ApproveDate], [AlertStateID], [AlertStateName], [IsCurrentState], [DocumentID], [AlertCommentID])
			SELECT
				E.EMP_CODE,
				ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				AC.PROOFING_STATUS_ID,
				AC.GENERATED_DATE,
				AC.ALERT_STATE_ID,
				NULL,
				CASE
					WHEN AC.ALERT_STATE_ID = @ALERT_STATE_ID THEN 1
					ELSE 0
				END,
				AC.DOCUMENT_ID,
				AC.COMMENT_ID
			FROM
				ALERT_COMMENT AC WITH(NOLOCK)
				INNER JOIN SEC_USER SU WITH(NOLOCK) ON AC.USER_CODE = SU.USER_CODE
				INNER JOIN EMPLOYEE E WITH(NOLOCK) ON SU.EMP_CODE = E.EMP_CODE
				LEFT JOIN DOCUMENTS D WITH(NOLOCK) ON AC.DOCUMENT_ID = D.DOCUMENT_ID
			WHERE
				AC.ALERT_ID = @ALERT_ID
				AND AC.ALERT_STATE_ID <> @ALERT_STATE_ID
				AND AC.PROOFING_STATUS_ID IS NOT NULL
				AND (AC.DOCUMENT_ID = @DOCUMENT_ID OR ISNULL(@DOCUMENT_ID, 0) = 0)
				--AND AC.COMMENT_ID  = (	SELECT MAX(COMMENT_ID) FROM ALERT_COMMENT ACC WITH(NOLOCK) WHERE ACC.USER_CODE = SU.USER_CODE AND AC.ALERT_STATE_ID = ACC.ALERT_STATE_ID)
			;
		END

	END
	--	EXTERNAL REVIEWERS
	BEGIN
		INSERT INTO @APPROVALS (AlertStateID, [Name], ProofingStatusID, ProofingStatusExternalReviewerID, DocumentID)
		SELECT
			A.ALERT_STATE_ID, 
			X.[NAME],
			A.PROOFING_STATUS_ID,
			A.PROOFING_EXTERNAL_REVIEWER_ID,
			@DOCUMENT_ID			
		FROM
			(
				SELECT
					AR.ALERT_STATE_ID,
					AR.PROOFING_STATUS_ID,
					AR.PROOFING_EXTERNAL_REVIEWER_ID
				FROM
					ALERT_RCPT_X_REVIEWER AR WITH(NOLOCK)
				WHERE
					AR.ALERT_ID = @ALERT_ID
				UNION
				SELECT
					ARD.ALERT_STATE_ID,
					ARD.PROOFING_STATUS_ID,
					ARD.PROOFING_EXTERNAL_REVIEWER_ID
				FROM
					ALERT_RCPT_X_REVIEWER_DISMISSED ARD WITH(NOLOCK)
				WHERE
					ARD.ALERT_ID = @ALERT_ID
			) AS A INNER JOIN PROOFING_X_REVIEWER X WITH(NOLOCK) ON A.PROOFING_EXTERNAL_REVIEWER_ID = X.ID
		;
		UPDATE @APPROVALS SET ProofingStatusID = ARD.PROOFING_STATUS_ID
		FROM
			ALERT_RCPT_X_REVIEWER_DISMISSED ARD WITH(NOLOCK)
			INNER JOIN @APPROVALS A ON A.ProofingStatusExternalReviewerID = ARD.PROOFING_EXTERNAL_REVIEWER_ID
		WHERE
			ARD.ALERT_ID = @ALERT_ID
			AND ARD.PROOFING_STATUS_ID IS NOT NULL
		;
	END
	--	ADD IN EMPLOYEES THAT HAVE NEVER APPROVE/DEFER/REJECT
	BEGIN
		IF @IS_ROUTED = 1	-- AT CURRENT STATE
		BEGIN
			DECLARE
				@CURR_STATE_CT INT = 0
			;
			SELECT @CURR_STATE_CT = COUNT(1) FROM @CURRENT_STATE;
			IF @CURR_STATE_CT > 0
			BEGIN
				INSERT INTO @APPROVALS ([AlertStateID], [AlertStateName], [EmployeeCode], [Name], [IsCurrentState])
				SELECT
					CS.AlertStateID,
					CS.AlertStateName,
					CS.EmployeeCode,
					ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
					1
				FROM
					@CURRENT_STATE CS
					LEFT OUTER JOIN @APPROVALS A ON CS.AlertStateID = A.AlertStateID AND CS.EmployeeCode = A.EmployeeCode
					INNER JOIN EMPLOYEE E WITH(NOLOCK) ON CS.EmployeeCode = E.EMP_CODE
				WHERE
					A.ID IS NULL
					AND E.EMP_TERM_DATE IS NULL
				;	
			END
			ELSE
			BEGIN
				INSERT INTO @APPROVALS ([AlertStateID], [AlertStateName], [EmployeeCode], [Name], [IsCurrentState])
				VALUES (@ALERT_STATE_ID, @ALERT_STATE_NAME, '', 'Unassigned', 1); 
			END
		END
		ELSE
		BEGIN
			INSERT INTO @APPROVALS([EmployeeCode], [Name], IsCurrentState)
			SELECT
				X.EMP_CODE,
				X.[NAME],
				1
			FROM
				(
					SELECT
						[EMP_CODE] = R.EMP_CODE,
						[NAME] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
					FROM
						ALERT_RCPT R WITH(NOLOCK)
						LEFT OUTER JOIN @APPROVALS A ON R.EMP_CODE = A.EmployeeCode
						INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON R.EMP_CODE = E.EMP_CODE
					WHERE
						A.ID IS NULL
						AND R.ALERT_ID = @ALERT_ID
						AND R.CURRENT_NOTIFY = 1
						AND E.EMP_TERM_DATE IS NULL
					UNION
					SELECT
						[EMP_CODE] = R.EMP_CODE,
						[NAME] = ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, '')
					FROM
						ALERT_RCPT_DISMISSED R WITH(NOLOCK)
						LEFT OUTER JOIN @APPROVALS A ON R.EMP_CODE = A.EmployeeCode
						INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON R.EMP_CODE = E.EMP_CODE
					WHERE
						A.ID IS NULL
						AND R.ALERT_ID = @ALERT_ID
						AND R.CURRENT_NOTIFY = 1
						AND E.EMP_TERM_DATE IS NULL
				) AS X
		END
	END
	--	ROUTED CURRENT STATE GET CORRECT STATUS
	IF @IS_ROUTED = 1
	BEGIN
		UPDATE @APPROVALS SET ProofingStatusID = C.ProofingStatusID
		FROM
			@APPROVALS A
			INNER JOIN @CURRENT_STATE C ON A.AlertStateID = C.AlertStateID AND A.EmployeeCode = C.EmployeeCode
		WHERE
			C.ProofingStatusID IS NOT NULL
		;
	END
	--	LATEST APPROVAL FOR PREVIOUS STATES
	BEGIN
		-- ROUTED
		IF @IS_ROUTED = 1
		BEGIN
			DECLARE
				@REC_COUNT INT = 0,
				@REC_CTR INT = 0,
				@CURR_STATE_ID INT
			;
			DECLARE @STATES TABLE (	ID INT IDENTITY, 
									ALERT_STATE_ID INT)
			;
			INSERT INTO @STATES (ALERT_STATE_ID)
			SELECT
				DISTINCT A.AlertStateID
			FROM
				@APPROVALS A
			WHERE
				A.AlertStateID IS NOT NULL
			;
			SELECT
				@REC_COUNT = COUNT(1) 
			FROM
				@STATES S
			WHERE
				S.ALERT_STATE_ID <> @ALERT_STATE_ID
			;
			IF @REC_COUNT > 0
			BEGIN
				WHILE @REC_COUNT > @REC_CTR
				BEGIN
					SELECT
						@REC_CTR = @REC_CTR + 1,
						@CURR_STATE_ID = NULL
					;
					SELECT
						@CURR_STATE_ID = ALERT_STATE_ID
					FROM
						@STATES S
					WHERE
						S.ID = @REC_CTR
					;
					DELETE FROM @APPROVALS
					WHERE
						AlertStateID = @CURR_STATE_ID
						AND ID NOT IN
						(	
						SELECT
								AA.ID
							FROM
								@APPROVALS AA
								INNER JOIN (
												SELECT 
													ID = MAX(A.ID),
													A.EmployeeCode
												FROM 
													@APPROVALS A
												WHERE
													A.AlertStateID = @CURR_STATE_ID
												GROUP BY
													A.EmployeeCode
											) AS AAA ON AA.ID = AAA.ID
						) 
					;
				END
			END
		END
	END
	--	CLEAN UP
	BEGIN
		--	Get correct status date
		BEGIN
			--	Get the comment id
			IF @IS_ROUTED = 1
			BEGIN
				UPDATE @APPROVALS SET AlertCommentID = B.COMMENT_ID
				FROM
					@APPROVALS A
					INNER JOIN (
						SELECT
							MAX(AC.COMMENT_ID) AS COMMENT_ID,
							SU.EMP_CODE,
							AC.ALERT_STATE_ID,
							AC.PROOFING_STATUS_ID
						FROM
							ALERT_COMMENT AC WITH(NOLOCK)
							INNER JOIN SEC_USER SU WITH(NOLOCK) ON AC.USER_CODE = SU.USER_CODE
						WHERE
							AC.ALERT_ID = @ALERT_ID
							AND AC.PROOFING_STATUS_ID IS NOT NULL
						GROUP BY
							SU.EMP_CODE,
							AC.ALERT_STATE_ID,
							AC.PROOFING_STATUS_ID
					) AS B ON A.EmployeeCode = B.EMP_CODE AND A.ProofingStatusID = B.PROOFING_STATUS_ID AND A.AlertStateID = B.ALERT_STATE_ID
				WHERE
					A.ProofingStatusID IS NOT NULL
					AND A.ApproveDate IS NULL
				;
			END
			ELSE
			BEGIN
				UPDATE @APPROVALS SET AlertCommentID = B.COMMENT_ID
				FROM
					@APPROVALS A
					INNER JOIN (
						SELECT
							MAX(AC.COMMENT_ID) AS COMMENT_ID,
							SU.EMP_CODE,
							AC.PROOFING_STATUS_ID
						FROM
							ALERT_COMMENT AC WITH(NOLOCK)
							INNER JOIN SEC_USER SU WITH(NOLOCK) ON AC.USER_CODE = SU.USER_CODE
						WHERE
							AC.ALERT_ID = @ALERT_ID
							AND AC.PROOFING_STATUS_ID IS NOT NULL
						GROUP BY
							SU.EMP_CODE,
							AC.PROOFING_STATUS_ID
					) AS B ON A.EmployeeCode = B.EMP_CODE AND A.ProofingStatusID = B.PROOFING_STATUS_ID
				WHERE
					A.ProofingStatusID IS NOT NULL
					AND A.ApproveDate IS NULL
				;
			END
			--	Update the date
			BEGIN
				UPDATE @APPROVALS SET ApproveDate = AC.GENERATED_DATE
				FROM
					@APPROVALS A
					INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON A.AlertCommentID = AC.COMMENT_ID
				WHERE
					A.ApproveDate IS NULL
			END

		END
		IF @IS_ROUTED = 1
		BEGIN
			UPDATE @APPROVALS SET SequenceNumber = ANS.SORT_ORDER
			FROM
				@APPROVALS A
				INNER JOIN ALERT_NOTIFY_STATES ANS WITH(NOLOCK) ON ANS.ALERT_STATE_ID = A.AlertStateID 
					AND ANS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_ID
			;
			UPDATE @APPROVALS SET AlertStateName = ANS.ALERT_STATE_NAME
			FROM
				@APPROVALS A
				INNER JOIN ALERT_STATES ANS WITH(NOLOCK) ON ANS.ALERT_STATE_ID = A.AlertStateID 
			;
			UPDATE @APPROVALS SET IsCurrentState = 1
			WHERE
				AlertStateID = @ALERT_STATE_ID
			;
		END
		--	Status text
		BEGIN
			UPDATE @APPROVALS SET ProofingStatus = 	CASE
														WHEN ProofingStatusID = 1 THEN 'Approved'
														WHEN ProofingStatusID = 2 THEN 'Rejected'
														WHEN ProofingStatusID = 3 THEN 'Deferred'
													END
		END
		--	Current state default
		BEGIN
			UPDATE @APPROVALS SET IsCurrentState = 0
			WHERE
				IsCurrentState IS NULL
			;
		END
		--  Latest status for XR
		BEGIN
			DECLARE @XR TABLE (ID INT IDENTITY, PROOFING_EXTERNAL_REVIEWER_ID INT)
			DECLARE
				@CT INT = 0,
				@CTR INT = 0,
				@COMMENT_ID INT = NULL,
				@XR_ID INT = NULL
			;
			INSERT INTO @XR (PROOFING_EXTERNAL_REVIEWER_ID)
			SELECT
				ProofingStatusExternalReviewerID
			FROM 
				@APPROVALS 
			WHERE 
				ProofingStatusExternalReviewerID IS NOT NULL AND ProofingStatusID IS NOT NULL
			;
			SELECT
				@CT = COUNT(1)
			FROM
				@XR
			;
			IF @CT > 0
			BEGIN
				WHILE @CT > @CTR
				BEGIN
					SELECT 
						@CTR = @CTR + 1,
						@COMMENT_ID = NULL,
						@XR_ID = NULL
					;
					SELECT 
						@XR_ID = PROOFING_EXTERNAL_REVIEWER_ID
					FROM
						@XR
					WHERE
						ID = @CTR
					;
					IF @XR_ID IS NOT NULL
					BEGIN
						UPDATE @APPROVALS SET ProofingStatusID = A.PROOFING_STATUS_ID, ApproveDate = A.GENERATED_DATE
						FROM
							(
								SELECT 
									TOP 1 *
								FROM
									ALERT_COMMENT AC WITH(NOLOCK)
								WHERE
									AC.ALERT_ID = @ALERT_ID
									AND AC.PROOFING_X_REVIEWER_ID = @XR_ID
									AND AC.PROOFING_STATUS_ID IS NOT NULL
								ORDER BY
									AC.COMMENT_ID DESC
							) AS A
							INNER JOIN @APPROVALS AP ON A.PROOFING_X_REVIEWER_ID = AP.ProofingStatusExternalReviewerID
						;
					END
				END
			END
		END
		--  Non routed
		BEGIN
			IF @IS_ROUTED = 0
			BEGIN
				UPDATE @APPROVALS SET IsCurrentState = 1
			END
		END
		--  Markup count
		BEGIN
			-- ASSIGNEES
			BEGIN
				UPDATE @APPROVALS SET TotalMarkupCount = ISNULL(B.TOTAL_MARK_UP_COUNT, 0)
				FROM
					@APPROVALS A
					INNER JOIN	(
						SELECT 
							COUNT(1) AS TOTAL_MARK_UP_COUNT,
							PM.EMP_CODE
						FROM 
							PROOFING_MARKUP PM WITH(NOLOCK)
							INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON PM.COMMENT_ID = AC.COMMENT_ID
						WHERE
							AC.ALERT_ID = @ALERT_ID
						GROUP BY
							PM.EMP_CODE
								) AS B ON A.EmployeeCode = B.EMP_CODE
				WHERE
					B.EMP_CODE IS NOT NULL
				;
			END
			-- ASSIGNEES
			BEGIN
				UPDATE @APPROVALS SET TotalMarkupCount = ISNULL(B.TOTAL_MARK_UP_COUNT, 0)
				FROM
					@APPROVALS A
					INNER JOIN	(
						SELECT 
							COUNT(1) AS TOTAL_MARK_UP_COUNT,
							PM.PROOFING_X_REVIEWER_ID
						FROM 
							PROOFING_MARKUP PM WITH(NOLOCK)
							INNER JOIN ALERT_COMMENT AC WITH(NOLOCK) ON PM.COMMENT_ID = AC.COMMENT_ID
						WHERE
							AC.ALERT_ID = @ALERT_ID
						GROUP BY
							PM.PROOFING_X_REVIEWER_ID
								) AS B ON A.ProofingStatusExternalReviewerID = B.PROOFING_X_REVIEWER_ID
				WHERE
					B.PROOFING_X_REVIEWER_ID IS NOT NULL
				;
			END
		END
	END
	--	FINAL
	BEGIN
		INSERT INTO @RET_TABLE(	AlertStateID, 
								AlertStateName, 
								EmployeeCode, 
								[Name], 
								ProofingStatusID, 
								ProofingStatus, 
								ApproveDate, 
								IsCurrentState, 
								DocumentID, 
								SequenceNumber, 
								ProofingStatusExternalReviewerID,
								TotalMarkupCount)
		SELECT DISTINCT
			A.[AlertStateID],
			A.[AlertStateName],
			A.[EmployeeCode],
			A.[Name],
			A.[ProofingStatusID],
			A.[ProofingStatus],
			A.[ApproveDate],
			A.[IsCurrentState],
			A.[DocumentID],
			A.[SequenceNumber],
			A.ProofingStatusExternalReviewerID,
			ISNULL(A.TotalMarkupCount, 0)
		FROM
			@APPROVALS A
			LEFT OUTER JOIN DOCUMENTS D WITH(NOLOCK) ON D.DOCUMENT_ID = A.DocumentID
		WHERE
			1 =	CASE
					WHEN @SHOW_ALL = 1 THEN 1
					ELSE	
						CASE
							WHEN A.IsCurrentState = 1 THEN 1
							WHEN @DOCUMENT_ID IS NULL AND D.DOCUMENT_ID IS NULL THEN 1 -- SHOULD NEVER HIT THIS, BUT MAYBE NEED?
							WHEN @DOCUMENT_ID IS NOT NULL AND D.DOCUMENT_ID = @DOCUMENT_ID THEN 1
							ELSE 0
						END
				END
		ORDER BY
			A.[SequenceNumber],
			A.[ApproveDate],
			A.[Name]
		;
		--	CLEAN UP
		BEGIN
			IF @IS_ROUTED = 0
			BEGIN
				UPDATE @RET_TABLE SET SequenceNumber = A.ID
				FROM
					@APPROVALS A
					INNER JOIN @RET_TABLE R ON A.EmployeeCode = R.EmployeeCode
				WHERE
					R.SequenceNumber IS NULL
				;
			END
		END
	END
/*=========== QUERY ===========*/

	RETURN

END