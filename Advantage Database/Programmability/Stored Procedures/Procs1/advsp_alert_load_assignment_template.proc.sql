IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_alert_load_assignment_template]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_alert_load_assignment_template];
END
GO
CREATE PROCEDURE [dbo].[advsp_alert_load_assignment_template] 
@ALERT_ID INT,
@GET_STATES BIT,
@ACTIVE_EMPS BIT,
@DOCUMENT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	--	VARS
	BEGIN
		DECLARE
			@DATA TABLE (RowID INT NULL, 
						 AlertID INT NULL, 
						 AlertTemplateID INT NULL, 
						 AlertTemplateName VARCHAR(100) NULL,
						 AlertStateID INT NULL,
						 AlertStateName VARCHAR(100) NULL,
						 EmployeeCode VARCHAR(6) NULL,
						 EmployeeFullName VARCHAR(100) NULL,
						 IsDefaultEmployee BIT NULL,
						 IsEmployeeSelected BIT NULL,
						 ProofingStatusID INT NULL,
						 StateOrder SMALLINT NULL,
						 IsCurrentState BIT NULL,
						 CanEditStateEmployees BIT NULL,
						 CanDeleteEmployee BIT NULL,
						 TotalAssignees INT NULL,
						 ApprovedAssignees INT NULL,
						 RejectedAssignees INT NULL,
						 DeferredAssignees INT NULL,
						 ProofingStatusReviewerID INT NULL,
						 StatusDate SMALLDATETIME NULL,
						 DocumentID INT NULL,
						 TemporaryID VARCHAR(MAX) NULL,
						 IsAssignee BIT NULL,
						 TotalMarkupCount INT
						 )
			;
		DECLARE
			@STATES_ORDER TABLE (	ID INT IDENTITY, 
									ALERT_STATE_ID INT, 
									SORT_ORDER INT)
			;
		DECLARE
			@SET_STATUSES TABLE (	ID INT IDENTITY,
									EMP_CODE VARCHAR(6) NULL,
									ALRT_NOTIFY_HDR_ID INT NULL,
									ALERT_STATE_ID INT NULL,
									PROOFING_STATUS_ID INT NULL,
									PROOFING_STATUS_EXTERNAL_REVIEWER_ID INT NULL
								)
			;
		DECLARE
			@ALRT_NOTIFY_HDR_ID INT,
			@ALERT_STATE_ID INT,
			@IS_PROOF BIT
		;
		DECLARE
			@STATES TABLE (	ID INT NULL,
							AlertTemplateID INT NULL,
							AlertStateID INT NULL,
							AlertTemplateName VARCHAR(100) NULL,
							AlertStateName VARCHAR(100) NULL,
							SortOrder SMALLINT NULL,
							CanEditAssignees BIT NULL,
							IsCurrentState BIT NULL,
							TemporaryID VARCHAR(MAX))	END
	--	INIT
	BEGIN
		SELECT
			@ALRT_NOTIFY_HDR_ID = COALESCE(@ALRT_NOTIFY_HDR_ID, A.ALRT_NOTIFY_HDR_ID),
			@ALERT_STATE_ID = COALESCE(@ALERT_STATE_ID, A.ALERT_STATE_ID),
			@IS_PROOF =	CASE
							WHEN A.ALERT_CAT_ID = 79 THEN 1
							ELSE 0
						END
		FROM
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_ID = @ALERT_ID;
		SELECT
			@GET_STATES = ISNULL(@GET_STATES, 0),
			@ACTIVE_EMPS = ISNULL(@ACTIVE_EMPS, 0)
		;
		INSERT INTO @STATES_ORDER (ALERT_STATE_ID, SORT_ORDER)
		SELECT
			ALERT_STATE_ID, SORT_ORDER
		FROM
			ALERT_NOTIFY_STATES ANS WITH(NOLOCK)
		WHERE
			ANS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
		ORDER BY
			ANS.SORT_ORDER
		;
		INSERT INTO @STATES(ID, AlertTemplateID, AlertStateID, AlertTemplateName, AlertStateName, SortOrder, CanEditAssignees, IsCurrentState)
		SELECT
			S.ID,
			S.AlertTemplateID,
			S.AlertStateID,
			S.AlertTemplateName,
			S.AlertStateName,
			S.SortOrder,
			S.CanEditAssignees,
			S.IsCurrentState
		FROM
			[dbo].[advtf_alert_get_states] (@ALERT_ID) AS S
		ORDER BY
			S.SortOrder
		;	
		--IF @DOCUMENT_ID IS NULL OR @DOCUMENT_ID = 0 
		--BEGIN
			SELECT 
				@DOCUMENT_ID = MAX(DOCUMENT_ID)
			FROM
				ALERT_ATTACHMENT AA WITH(NOLOCK)
			WHERE
				AA.ALERT_ID = @ALERT_ID
			;
		--END
	END
	--	CREATE RECS IF NOT EXIST
	IF NOT EXISTS (SELECT 1 FROM ALERT_NOTIFY_EMPS_ASSIGNMENT A WITH(NOLOCK) WHERE A.ALERT_ID = @ALERT_ID)
	BEGIN
		INSERT INTO ALERT_NOTIFY_EMPS_ASSIGNMENT WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE, IS_DEFAULT, ALERT_ID)
		SELECT 
			A.ALERT_STATE_ID,
			A.ALRT_NOTIFY_HDR_ID,
			A.EMP_CODE,
			CAST(ISNULL(A.IS_DFLT, 0) AS BIT),
			@ALERT_ID
		FROM
			ALERT_NOTIFY_EMPS A WITH(NOLOCK)
			INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON A.EMP_CODE = E.EMP_CODE
		WHERE
			A.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
			AND E.EMP_TERM_DATE IS NULL
		;	
	END
	--	ADD DATA
	BEGIN --	ALL DATA
		IF @GET_STATES IS NULL OR @GET_STATES = 0
		BEGIN
			INSERT INTO @DATA (RowID, AlertID, AlertTemplateID, AlertTemplateName, AlertStateID, AlertStateName, EmployeeCode, EmployeeFullName, IsDefaultEmployee, IsEmployeeSelected, StateOrder, TemporaryID)
			SELECT 
				[RowID] = ANEA.ID,
				[AlertID] = ANEA.ALERT_ID,
				[AlertTemplateID] = ANEA.ALRT_NOTIFY_HDR_ID,
				[AlertTemplateName] = ANH.ALERT_NOTIFY_NAME,
				[AlertStateID] = ANEA.ALERT_STATE_ID,
				[AlertStateName] = STS.ALERT_STATE_NAME,
				[EmployeeCode] = ANEA.EMP_CODE,
				[EmployeeFullName] = ISNULL(E.EMP_FNAME + ' ','') + ISNULL(E.EMP_MI + '. ', '') + ISNULL(E.EMP_LNAME, ''),
				[IsDefaultEmployee] = CAST(ISNULL(ANEA.IS_DEFAULT, 0) AS BIT),
				[IsEmployeeSelected] = CAST(ISNULL(ANEA.IS_SELECTED, 0) AS BIT),
				[StateOrder] = CAST(ISNULL(ANS.SORT_ORDER, 0) AS SMALLINT),
				[TemporaryID] = ANEA.TEMP_ID
			FROM
				ALERT_NOTIFY_EMPS_ASSIGNMENT ANEA WITH(NOLOCK)
				INNER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON ANEA.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID
				INNER JOIN ALERT_STATES STS WITH(NOLOCK) ON ANEA.ALERT_STATE_ID = STS.ALERT_STATE_ID
				INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON ANEA.EMP_CODE = E.EMP_CODE
				INNER JOIN ALERT_NOTIFY_STATES ANS WITH(NOLOCK) ON ANEA.ALRT_NOTIFY_HDR_ID = ANS.ALRT_NOTIFY_HDR_ID 
					AND ANEA.ALERT_STATE_ID = ANS.ALERT_STATE_ID
			WHERE
				ANEA.ALERT_ID = @ALERT_ID
				AND ANEA.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
				AND E.EMP_TERM_DATE IS NULL
			ORDER BY
				ANS.SORT_ORDER,
				CAST(ISNULL(ANEA.IS_DEFAULT, 0) AS BIT) DESC,
				ANEA.EMP_CODE
			;
			IF @ACTIVE_EMPS IS NOT NULL AND @ACTIVE_EMPS = 1
			BEGIN
				DECLARE
					@STATE_COUNT INT,
					@CURRENT_ALERT_STATE_ID INT,
					@CURRENT_STATE_ORDER SMALLINT,
					@CURRENT_IS_CURRENT_STATE BIT,
					@STATE_COUNTER INT
				SELECT
					@STATE_COUNT = 0,
					@STATE_COUNTER = 0
				;
				SELECT @STATE_COUNT = COUNT(1) FROM @STATES;
				IF @STATE_COUNT > 0
				BEGIN
					WHILE @STATE_COUNT > @STATE_COUNTER
					BEGIN
						SELECT 
							@CURRENT_ALERT_STATE_ID = NULL,
							@CURRENT_STATE_ORDER = NULL,
							@CURRENT_IS_CURRENT_STATE = NULL,
							@STATE_COUNTER = @STATE_COUNTER + 1
						;
						SELECT
							@CURRENT_ALERT_STATE_ID = S.AlertStateID,
							@CURRENT_STATE_ORDER = S.SortOrder,
							@CURRENT_IS_CURRENT_STATE = S.IsCurrentState
						FROM
							@STATES S
						WHERE
							S.ID = @STATE_COUNTER
						;
						INSERT INTO @DATA (AlertID, AlertTemplateID, AlertStateID, EmployeeCode, EmployeeFullName, IsDefaultEmployee, IsEmployeeSelected, ProofingStatusID, StateOrder, IsCurrentState)
						SELECT
							@ALERT_ID,
							@ALRT_NOTIFY_HDR_ID,
							@CURRENT_ALERT_STATE_ID,
							E.EMP_CODE,
							ISNULL(E.EMP_FNAME + ' ','') + ISNULL(E.EMP_MI + '. ','') + ISNULL(E.EMP_LNAME, ''),
							0,
							0,
							0,
							@CURRENT_STATE_ORDER,
							@CURRENT_IS_CURRENT_STATE
						FROM
							EMPLOYEE_CLOAK E WITH(NOLOCK)
						WHERE
							E.EMP_TERM_DATE IS NULL
							AND E.EMP_CODE NOT IN (SELECT EmployeeCode FROM @DATA D WHERE D.AlertStateID = @CURRENT_ALERT_STATE_ID)
						;
					END
				END
			END	
		END
		IF @GET_STATES IS NOT NULL AND @GET_STATES = 1
		BEGIN --	ONLY STATES
			INSERT INTO @DATA (AlertTemplateID, AlertTemplateName, AlertStateID, AlertStateName, StateOrder, IsCurrentState)
			SELECT
				S.AlertTemplateID,
				S.AlertTemplateName,
				S.AlertStateID,
				S.AlertStateName,
				S.SortOrder,
				S.IsCurrentState
			FROM
				@STATES AS S
			;	
		END
	END
	--  ASSIGNEES
	BEGIN		
		INSERT INTO @SET_STATUSES (EMP_CODE, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, PROOFING_STATUS_ID)
		SELECT
			A.EMP_CODE,
			A.ALRT_NOTIFY_HDR_ID,
			A.ALERT_STATE_ID,
			A.PROOFING_STATUS_ID
		FROM
			(
				SELECT
					AR.EMP_CODE,
					AR.ALRT_NOTIFY_HDR_ID,
					AR.ALERT_STATE_ID,
					AR.PROOFING_STATUS_ID
				FROM
					ALERT_RCPT AR WITH(NOLOCK)
				WHERE
					AR.ALERT_ID = @ALERT_ID
					AND (AR.CURRENT_NOTIFY IS NOT NULL AND AR.CURRENT_NOTIFY = 1)
				UNION
				SELECT
					AR.EMP_CODE,
					AR.ALRT_NOTIFY_HDR_ID,
					AR.ALERT_STATE_ID,
					AR.PROOFING_STATUS_ID
				FROM
					ALERT_RCPT_DISMISSED AR WITH(NOLOCK)
				WHERE
					AR.ALERT_ID = @ALERT_ID
					AND (AR.CURRENT_NOTIFY IS NOT NULL AND AR.CURRENT_NOTIFY = 1)
				UNION
				SELECT
					S.EMP_CODE,
					ALRT_NOTIFY_HDR_ID,
					ALERT_STATE_ID,
					PROOFING_STATUS_ID
				FROM
					ALERT_COMMENT AC WITH(NOLOCK)
					INNER JOIN SEC_USER S WITH(NOLOCK) ON AC.USER_CODE = S.USER_CODE
				WHERE
					AC.ALERT_ID = @ALERT_ID
					AND AC.PROOFING_STATUS_ID IS NOT NULL
			) AS A
				INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON A.EMP_CODE = E.EMP_CODE
			WHERE
				E.EMP_TERM_DATE IS NULL
			;
		INSERT @SET_STATUSES (PROOFING_STATUS_EXTERNAL_REVIEWER_ID, ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, PROOFING_STATUS_ID)
		SELECT
			B.PROOFING_EXTERNAL_REVIEWER_ID,
			B.ALRT_NOTIFY_HDR_ID,
			B.ALERT_STATE_ID,
			B.PROOFING_STATUS_ID
		FROM
			(
				SELECT
					X.PROOFING_EXTERNAL_REVIEWER_ID,
					X.ALERT_ID,
					X.ALRT_NOTIFY_HDR_ID,
					X.ALERT_STATE_ID,
					X.PROOFING_STATUS_ID
				FROM
					ALERT_RCPT_X_REVIEWER X WITH(NOLOCK)
				WHERE
					X.ALERT_ID = @ALERT_ID
				UNION
				SELECT
					XD.PROOFING_EXTERNAL_REVIEWER_ID,
					XD.ALERT_ID,
					XD.ALRT_NOTIFY_HDR_ID,
					XD.ALERT_STATE_ID,
					XD.PROOFING_STATUS_ID
				FROM
					ALERT_RCPT_X_REVIEWER_DISMISSED XD WITH(NOLOCK)
				WHERE
					XD.ALERT_ID = @ALERT_ID
			) AS B
	END
	--	CLEANUP
	BEGIN
		--	MISSING TEMPLATE NAME WHEN SHOWING ALL EMPLOYEES
		BEGIN
			UPDATE @DATA SET AlertTemplateName = A.ALERT_NOTIFY_NAME
			FROM
				ALERT_NOTIFY_HDR A WITH(NOLOCK)
				INNER JOIN @DATA D ON A.ALRT_NOTIFY_HDR_ID = D.AlertTemplateID
			WHERE
				D.AlertTemplateName IS NULL
			;
		END
		--	MISSING STATE NAME WHEN SHOWING ALL EMPLOYEES
		BEGIN
			UPDATE @DATA SET AlertStateName = S.ALERT_STATE_NAME
			FROM
				ALERT_STATES S WITH(NOLOCK)
				INNER JOIN @DATA D ON S.ALERT_STATE_ID = D.AlertStateID
			WHERE
				D.AlertStateName IS NULL
			;
		END
		--  CURRENT "REAL" ASSIGNEES
		BEGIN
			UPDATE @DATA SET IsEmployeeSelected = 1
			FROM
				(
					SELECT
						R.EMP_CODE, R.ALRT_NOTIFY_HDR_ID, R.ALERT_STATE_ID
					FROM
						ALERT_RCPT R WITH(NOLOCK)
					WHERE
						R.ALERT_ID = @ALERT_ID
						AND R.CURRENT_NOTIFY = 1
					UNION
					SELECT
						R.EMP_CODE, R.ALRT_NOTIFY_HDR_ID, R.ALERT_STATE_ID
					FROM
						ALERT_RCPT_DISMISSED R WITH(NOLOCK)
					WHERE
						R.ALERT_ID = @ALERT_ID
						AND R.CURRENT_NOTIFY = 1
				) A INNER JOIN @DATA D ON A.EMP_CODE = D.EmployeeCode 
					AND A.ALRT_NOTIFY_HDR_ID = D.AlertTemplateID 
					AND A.ALERT_STATE_ID = D.AlertStateID
			;
			UPDATE @DATA SET TemporaryID = A.TEMP_ID
			FROM
				ALERT_NOTIFY_EMPS_ASSIGNMENT A WITH(NOLOCK)
				INNER JOIN @DATA D ON A.ALERT_ID = D.AlertID 
					AND A.ALERT_STATE_ID = D.AlertStateID
					AND A.ALRT_NOTIFY_HDR_ID = D.AlertTemplateID
					AND A.EMP_CODE = D.EmployeeCode
			WHERE
				A.ALERT_ID = @ALERT_ID
			;
		END
	END
	--	CLEAN UP
	BEGIN
		UPDATE @DATA SET IsCurrentState = SFN.IsCurrentState, CanEditStateEmployees = SFN.CanEditAssignees
		FROM
			@STATES AS SFN
			INNER JOIN @DATA D ON SFN.AlertStateID = D.AlertStateID
		;
	END
	--  PROOFING STATUS ID
	BEGIN
		IF (@GET_STATES IS NULL OR @GET_STATES = 0)
		BEGIN
			UPDATE @DATA SET	
				ProofingStatusID = A.ProofingStatusID, 
				StatusDate = A.ApproveDate,
				TotalMarkupCount = A.TotalMarkupCount
			FROM 
				[dbo].[advtf_proofing_get_approvals_list] (@ALERT_ID, NULL) AS A
				INNER JOIN @DATA D ON A.AlertStateID = D.AlertStateID AND A.EmployeeCode = D.EmployeeCode
			;
		END
	END
	--	FINAL UPDATES AND CLEANUP
	BEGIN
		UPDATE @DATA SET CanDeleteEmployee = CanEditStateEmployees;
		UPDATE @DATA SET CanDeleteEmployee = 0
		WHERE
			ProofingStatusID IS NOT NULL AND ProofingStatusID > 0
		;
		UPDATE @DATA SET IsAssignee =  1
		FROM
			ALERT_RCPT X WITH(NOLOCK)
			INNER JOIN @DATA D ON
				X.ALERT_ID = D.AlertID
				AND X.ALRT_NOTIFY_HDR_ID = D.AlertTemplateID
				AND X.ALERT_STATE_ID = D.AlertStateID
				AND X.EMP_CODE = D.EmployeeCode
		WHERE
			X.ALERT_ID = @ALERT_ID
			AND X.CURRENT_NOTIFY = 1
		;
		UPDATE @DATA SET IsAssignee =  1
		FROM
			ALERT_RCPT_DISMISSED X WITH(NOLOCK)
			INNER JOIN @DATA D ON
				X.ALERT_ID = D.AlertID
				AND X.ALRT_NOTIFY_HDR_ID = D.AlertTemplateID
				AND X.ALERT_STATE_ID = D.AlertStateID
				AND X.EMP_CODE = D.EmployeeCode
		WHERE
			X.ALERT_ID = @ALERT_ID
			AND X.CURRENT_NOTIFY = 1
		;
		-- CLEANUP CURRENT STATE REAL RECORD
		UPDATE ALERT_NOTIFY_EMPS_ASSIGNMENT SET IS_SELECTED = NULL
		FROM
			@DATA D
			INNER JOIN ALERT A WITH(NOLOCK) ON D.AlertID = A.ALERT_ID AND D.AlertTemplateID = A.ALRT_NOTIFY_HDR_ID AND D.AlertStateID = A.ALERT_STATE_ID
			INNER JOIN ALERT_NOTIFY_EMPS_ASSIGNMENT ANEA WITH(NOLOCK) ON D.AlertID = ANEA.ALERT_ID AND D.AlertTemplateID = ANEA.ALRT_NOTIFY_HDR_ID AND D.AlertStateID = ANEA.ALERT_STATE_ID
				AND D.EmployeeCode = ANEA.EMP_CODE
		WHERE
			D.IsEmployeeSelected = 1
			AND D.IsAssignee IS NULL
		;
		-- CLEANUP CURRENT STATE THIS DATA RECORD
		UPDATE @DATA SET IsEmployeeSelected = NULL
		FROM
			@DATA D
			INNER JOIN ALERT A WITH(NOLOCK) ON D.AlertID = A.ALERT_ID AND D.AlertTemplateID = A.ALRT_NOTIFY_HDR_ID AND D.AlertStateID = A.ALERT_STATE_ID
			INNER JOIN ALERT_NOTIFY_EMPS_ASSIGNMENT ANEA WITH(NOLOCK) ON D.AlertID = ANEA.ALERT_ID AND D.AlertTemplateID = ANEA.ALRT_NOTIFY_HDR_ID AND D.AlertStateID = ANEA.ALERT_STATE_ID
				AND D.EmployeeCode = ANEA.EMP_CODE
		WHERE
			D.IsEmployeeSelected = 1
			AND D.IsAssignee IS NULL
		;
		--UPDATE @DATA SET CanDeleteEmployee = 0
		--WHERE
		--	TotalMarkupCount IS NOT NULL AND TotalMarkupCount > 0
		--;
	END
	--	RETURN DATA
	BEGIN
		IF @GET_STATES IS NULL OR @GET_STATES = 0
		BEGIN
			SELECT
				[RowID] = ISNULL(RowID, 0),
				[AlertID] = ISNULL(AlertID, 0),
				[AlertTemplateID] = ISNULL(AlertTemplateID, 0),
				[AlertTemplateName] = AlertTemplateName,
				[AlertStateID] = ISNULL(AlertStateID, 0),
				[AlertStateName] = AlertStateName,
				[EmployeeCode] = EmployeeCode,
				[EmployeeFullName] = EmployeeFullName,
				[IsDefaultEmployee] = CAST(ISNULL(IsDefaultEmployee, 0) AS BIT),
				[IsEmployeeSelected] = CAST(ISNULL(IsEmployeeSelected, 0) AS BIT),
				[IsAssignee] = CAST(ISNULL(IsAssignee, 0) AS BIT),
				[ProofingStatusID] = CAST(ISNULL(ProofingStatusID, 0) AS INT),
				[ProofingStatusDate] = D.StatusDate,
				[StateOrder] = CAST(ISNULL(StateOrder, 0) AS SMALLINT),
				[IsCurrentState] = CAST(ISNULL(IsCurrentState, 0) AS BIT),
				[CanEditStateEmployees] = CAST(ISNULL(CanEditStateEmployees, 0) AS BIT),
				[CanDeleteEmployee] = CAST(ISNULL(CanDeleteEmployee, 1) AS BIT),
				[TemporaryID] = TemporaryID,
				[TotalMarkupCount] = TotalMarkupCount
			FROM
				@DATA D
				INNER JOIN EMPLOYEE_CLOAK E WITH(NOLOCK) ON D.EmployeeCode = E.EMP_CODE
			WHERE
				E.EMP_TERM_DATE IS NULL
			ORDER BY
				D.StateOrder,
				D.IsEmployeeSelected,
				D.EmployeeFullName
			;
		END
		ELSE
		BEGIN
			SELECT
				[RowID] = ISNULL(RowID, 0),
				[AlertID] = ISNULL(AlertID, 0),
				[AlertTemplateID] = ISNULL(AlertTemplateID, 0),
				[AlertTemplateName] = AlertTemplateName,
				[AlertStateID] = ISNULL(AlertStateID, 0),
				[AlertStateName] = AlertStateName,
				[EmployeeCode] = EmployeeCode,
				[EmployeeFullName] = EmployeeFullName,
				[IsDefaultEmployee] = CAST(ISNULL(IsDefaultEmployee, 0) AS BIT),
				[IsEmployeeSelected] = CAST(ISNULL(IsEmployeeSelected, 0) AS BIT),
				[ProofingStatusID] = CAST(ISNULL(ProofingStatusID, 0) AS INT),
				[ProofingStatusDate] = D.StatusDate,
				[StateOrder] = CAST(ISNULL(StateOrder, 0) AS SMALLINT),
				[IsCurrentState] = CAST(ISNULL(IsCurrentState, 0) AS BIT),
				[CanEditStateEmployees] = CAST(ISNULL(CanEditStateEmployees, 0) AS BIT),
				[CanDeleteEmployee] = CAST(ISNULL(CanDeleteEmployee, 0) AS BIT),
				[TemporaryID] = TemporaryID
			FROM
				@DATA D
			ORDER BY
				D.StateOrder,
				D.IsEmployeeSelected,
				D.EmployeeFullName
			;
		END
	END
END
/*=========== QUERY ===========*/