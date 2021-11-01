IF EXISTS ( SELECT *
            FROM dbo.sysobjects
            WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_load_external_reviewers]')
                  AND 
                  OBJECTPROPERTY(id , N'IsProcedure') = 1
          ) 
BEGIN
	DROP PROCEDURE [dbo].[advsp_proofing_load_external_reviewers]
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_load_external_reviewers] 
@ALERT_ID INT = NULL,
@TEXT VARCHAR(MAX) = NULL,
@SHOW_ALL SMALLINT = NULL
AS
/*=========== QUERY ===========*/
BEGIN
	/*
		@SHOW_ALL:
		0/NULL = SHOW ACTUAL ON ASSIGNMENT
		1 = By Client/Division/Product
		2 = By Job
		3 = "Truly all"
		4 = By Client
	*/	
	--	VARS
	BEGIN
		DECLARE
			@EXTERNAL_REVIEWERS TABLE ([RowID] INT IDENTITY,
									   [ProofingExternalReviewerID] INT,
									   [Name] VARCHAR(300),
									   [Email] VARCHAR(1000),
									   [ClientCode] VARCHAR(6),
									   [DivisionCode] VARCHAR(6),
									   [ProductCode] VARCHAR(6),
									   [ClientName] VARCHAR(100),
									   [DivisionName] VARCHAR(100),
									   [ProductDescription] VARCHAR(100),
									   [ProofingStatusID] INT,
									   [ProofingStatusName] VARCHAR(100),
									   [IsSelected] BIT,
									   [CanDelete] BIT,
									   [ProofingStatusDate] SMALLDATETIME NULL,
									   [TotalMarkupCount] INT
									  )
		;
		DECLARE
			@CL_CODE VARCHAR(6),
			@DIV_CODE VARCHAR(6),
			@PRD_CODE VARCHAR(6),
			@JOB_NUMBER INT,
			@JOB_COMPONENT_NBR SMALLINT
		;
	END
	--	INIT
	BEGIN
		SELECT
			@CL_CODE = COALESCE(A.CL_CODE, J.CL_CODE),
			@DIV_CODE = COALESCE(A.DIV_CODE, J.DIV_CODE),
			@PRD_CODE = COALESCE(A.PRD_CODE, J.PRD_CODE),
			@JOB_NUMBER = COALESCE(A.JOB_NUMBER, J.JOB_NUMBER),
			@JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
		FROM
			ALERT A WITH(NOLOCK)
			LEFT OUTER JOIN JOB_LOG J WITH(NOLOCK) ON A.JOB_NUMBER = A.JOB_COMPONENT_NBR
		WHERE
			A.ALERT_ID = @ALERT_ID
		;
	END
	--	CURRENT ON ASSIGNMENT
	IF @ALERT_ID IS NOT NULL AND @ALERT_ID > 0
	BEGIN
		INSERT INTO @EXTERNAL_REVIEWERS (ProofingExternalReviewerID, [Name], Email, ProofingStatusID, ProofingStatusName, IsSelected, ClientCode, DivisionCode, ProductCode)
		SELECT
			PX.ID,
			PX.[NAME],
			PX.EMAIL,
			AX.PROOFING_STATUS_ID,
			CASE
				WHEN AX.PROOFING_STATUS_ID = 1 THEN 'Approved'
				WHEN AX.PROOFING_STATUS_ID = 2 THEN 'Rejected'
				WHEN AX.PROOFING_STATUS_ID = 3 THEN 'Deferred'
			END,
			1,
			PX.CL_CODE,
			PX.DIV_CODE,
			PX.PRD_CODE
		FROM
			ALERT_RCPT_X_REVIEWER AX WITH(NOLOCK)
			INNER JOIN PROOFING_X_REVIEWER PX WITH(NOLOCK) ON AX.PROOFING_EXTERNAL_REVIEWER_ID = PX.ID
		WHERE
			AX.ALERT_ID = @ALERT_ID
		UNION
		SELECT
			PX.ID,
			PX.[NAME],
			PX.EMAIL,
			AXD.PROOFING_STATUS_ID,
			CASE
				WHEN AXD.PROOFING_STATUS_ID = 1 THEN 'Approved'
				WHEN AXD.PROOFING_STATUS_ID = 2 THEN 'Rejected'
				WHEN AXD.PROOFING_STATUS_ID = 3 THEN 'Deferred'
			END,
			1,
			PX.CL_CODE,
			PX.DIV_CODE,
			PX.PRD_CODE
		FROM
			ALERT_RCPT_X_REVIEWER_DISMISSED AXD WITH(NOLOCK)
			INNER JOIN PROOFING_X_REVIEWER PX WITH(NOLOCK) ON AXD.PROOFING_EXTERNAL_REVIEWER_ID = PX.ID
		WHERE
			AXD.ALERT_ID = @ALERT_ID
	END
	--  SHOW ALL
	IF @SHOW_ALL IS NOT NULL
	BEGIN
			INSERT INTO @EXTERNAL_REVIEWERS (ProofingExternalReviewerID, [Name], Email, ProofingStatusID, ProofingStatusName, IsSelected, ClientCode, DivisionCode, ProductCode)
			SELECT 
				PX.ID,
				PX.[NAME],
				PX.EMAIL,
				NULL,
				NULL,
				0,
				PX.CL_CODE,
				PX.DIV_CODE,
				PX.PRD_CODE
			FROM
				PROOFING_X_REVIEWER PX WITH(NOLOCK)
				LEFT OUTER JOIN @EXTERNAL_REVIEWERS XR ON PX.ID = XR.ProofingExternalReviewerID
			WHERE
				XR.ProofingExternalReviewerID IS NULL
				AND (PX.IS_ACTIVE IS NULL OR PX.IS_ACTIVE = 1)
				AND	1 = CASE
							WHEN @SHOW_ALL = 1 AND (PX.CL_CODE = @CL_CODE
													AND PX.DIV_CODE = @DIV_CODE
													AND PX.PRD_CODE = @PRD_CODE) THEN 1
							WHEN @SHOW_ALL = 2 AND (PX.JOB_NUMBER = @JOB_NUMBER) THEN 1
							WHEN @SHOW_ALL = 3 THEN 1
							WHEN @SHOW_ALL = 4 AND (PX.CL_CODE = @CL_CODE) THEN 1
							ELSE 0
						END
			;
	END
	--  CLEANUP
	BEGIN
		UPDATE @EXTERNAL_REVIEWERS SET ProductDescription = C.CL_NAME
		FROM
			@EXTERNAL_REVIEWERS XR
			INNER JOIN CLIENT C WITH(NOLOCK) ON XR.ClientCode = C.CL_CODE
		;
		UPDATE @EXTERNAL_REVIEWERS SET DivisionName = D.DIV_NAME
		FROM
			@EXTERNAL_REVIEWERS XR
			INNER JOIN DIVISION D WITH(NOLOCK) ON XR.ClientCode = D.CL_CODE AND XR.DivisionCode = D.DIV_CODE
		;
		UPDATE @EXTERNAL_REVIEWERS SET ProductDescription = P.PRD_DESCRIPTION
		FROM
			@EXTERNAL_REVIEWERS XR
			INNER JOIN PRODUCT P WITH(NOLOCK) ON XR.ClientCode = P.CL_CODE AND XR.DivisionCode = P.DIV_CODE AND XR.ProductCode = P.PRD_CODE
		;
		UPDATE @EXTERNAL_REVIEWERS SET
			ProofingStatusID = A.ProofingStatusID,
			ProofingStatusName = A.ProofingStatus,
			ProofingStatusDate = A.ApproveDate,
			TotalMarkupCount = A.TotalMarkupCount
		FROM 
			[dbo].[advtf_proofing_get_approvals_list] (@ALERT_ID, NULL) AS A
			INNER JOIN @EXTERNAL_REVIEWERS X ON A.ProofingStatusExternalReviewerID = X.ProofingExternalReviewerID
		WHERE
			A.ProofingStatusExternalReviewerID IS NOT NULL
			AND X.ProofingExternalReviewerID IS NOT NULL
			--AND A.ProofingStatusID IS NOT NULL
		;
		--UPDATE @EXTERNAL_REVIEWERS SET
		--	CanDelete = 0
		--WHERE
		--	TotalMarkupCount IS NOT NULL AND TotalMarkupCount > 0
		--;
	END
	--	RETURN
	BEGIN
		SELECT
			[ProofingExternalReviewerID] = XR.ProofingExternalReviewerID,
			[Name] = XR.[Name],
			[Email] = XR.Email,
			[ProofingStatusID] = XR.ProofingStatusID,
			[ProofingStatusName] = XR.ProofingStatusName,
			[IsSelected] = ISNULL(XR.IsSelected, 0),
			[CanDelete] = ISNULL(XR.CanDelete, 1),
			[ClientCode] = XR.ClientCode,
			[ClientName] = XR.ClientName,
			[DivisionCode] = XR.DivisionCode,
			[DivisionName] = XR.DivisionName,
			[ProductCode] = XR.ProductCode,
			[ProductDescription] = XR.ProductDescription,
			[CDP] =	CASE	
						WHEN DATALENGTH(ClientCode) > 0 AND  DATALENGTH(DivisionCode) > 0 AND  DATALENGTH(ProductCode) > 0 THEN '(' + ClientCode + ' | ' + DivisionCode + ' | ' + ProductCode + ')'
						WHEN DATALENGTH(ClientCode) > 0 AND  DATALENGTH(DivisionCode) > 0 AND  DATALENGTH(ProductCode) = 0 THEN '(' + ClientCode + ' | ' + DivisionCode + ')'
						WHEN DATALENGTH(ClientCode) > 0 AND  DATALENGTH(DivisionCode) = 0 AND  DATALENGTH(ProductCode) = 0 THEN '(' + ClientCode + ')'
						ELSE NULL
					END,
			[ProofingStatusDate] = XR.ProofingStatusDate,
			[TotalMarkupCount] = XR.TotalMarkupCount
		FROM
			@EXTERNAL_REVIEWERS XR
		WHERE
			1 = CASE
					WHEN @TEXT IS NULL THEN 1
					WHEN @TEXT IS NOT NULL AND (
													(UPPER(XR.[Name]) LIKE '%' + UPPER(@TEXT) + '%') 
													OR (UPPER(XR.[Email]) LIKE '%' + UPPER(@TEXT) + '%')
												) THEN 1
					ELSE 0
				END
		ORDER BY
			XR.[Name]
		;
	END
END
/*=========== QUERY ===========*/