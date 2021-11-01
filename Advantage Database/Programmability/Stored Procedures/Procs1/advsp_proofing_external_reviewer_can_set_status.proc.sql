IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_external_reviewer_can_set_status]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_external_reviewer_can_set_status];
END
GO

CREATE PROCEDURE [dbo].[advsp_proofing_external_reviewer_can_set_status] 
@ALERT_ID INT,
@PROOFING_EXTERNAL_REVIEWER_ID INT,
@DOCUMENT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN
	--	VARIABLES
	BEGIN
		DECLARE
			@CAN_SET_STATUS BIT,
			@IS_COMPLETE BIT = 0,
			@IS_ROUTED BIT,
			@IS_LATEST_DOCUMENT BIT = 0
		;
	END
	--	INIT
	BEGIN
		SELECT
			@CAN_SET_STATUS = 0,
			@IS_LATEST_DOCUMENT = 0
		;
		BEGIN
			SELECT
				@IS_COMPLETE =
					CASE
						WHEN A.ASSIGN_COMPLETED IS NOT NULL AND A.ASSIGN_COMPLETED = 1 THEN 1
						ELSE 0
					END,
				@IS_ROUTED =
					CASE
						WHEN A.ALERT_STATE_ID IS NOT NULL AND A.ALERT_STATE_ID > 0 THEN 1
						ELSE 0
					END
			FROM
				ALERT A WITH(NOLOCK)
			WHERE
				A.ALERT_ID = @ALERT_ID
			;
		END
		IF @IS_COMPLETE = 0
		BEGIN
			SELECT 
				@IS_LATEST_DOCUMENT = A.IsLatestDocument
			FROM
				[dbo].[advtf_proofing_get_documents_details] (@ALERT_ID) AS A
			WHERE
				A.DocumentID = @DOCUMENT_ID
			;
		END
	END
	--	DATA
	IF @IS_LATEST_DOCUMENT = 1 AND @IS_COMPLETE = 0
	BEGIN
		IF EXISTS	(	SELECT 1 
						FROM 
							ALERT_RCPT_X_REVIEWER AR WITH(NOLOCK)
						WHERE
							AR.ALERT_ID = @ALERT_ID
							AND AR.PROOFING_EXTERNAL_REVIEWER_ID = @PROOFING_EXTERNAL_REVIEWER_ID
					)
		BEGIN
			SELECT 
				@CAN_SET_STATUS = 1
			;
		END
		ELSE
		BEGIN
			SELECT 
				@CAN_SET_STATUS = 0
			;
		END
	END
	ELSE
	BEGIN
		SELECT 
			@CAN_SET_STATUS = 0
		;
	END
	--	RETURN
	BEGIN
		SELECT
			[CanSetStatus] = ISNULL(@CAN_SET_STATUS, 0)
		;
	END
END
/*=========== QUERY ===========*/
