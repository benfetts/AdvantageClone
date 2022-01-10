IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = object_id(N'[dbo].[advsp_proofing_can_delete_document]')
			AND OBJECTPROPERTY(id, N'IsProcedure') = 1
		)
	DROP PROCEDURE [dbo].[advsp_proofing_can_delete_document]
GO
CREATE PROCEDURE [dbo].[advsp_proofing_can_delete_document] 
@ALERT_ID INT,
@DOCUMENT_ID INT
AS
/*=========== QUERY ===========*/
BEGIN

	--	VARS
	BEGIN
		DECLARE
			@IS_PROOF BIT = 0,
			@CAN_DELETE BIT = 1,
			@CAN_DELETE_MESSAGE VARCHAR(MAX),
			@TOTAL_MARKUP_COUNT INT = 0,
			@TOTAL_COMMENT_COUNT INT = 0,
			@APPROVAL_COUNT INT
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
	END
	--  WORK
	BEGIN
		IF @IS_PROOF = 1
		BEGIN
		SELECT 
			@TOTAL_MARKUP_COUNT = X.TotalMarkups,
			@TOTAL_COMMENT_COUNT = X.TotalComments,
			@APPROVAL_COUNT = X.TotalApproves + X.TotalRejects + X.TotalDefers
		FROM
			[dbo].[advtf_proofing_get_documents_details] (@ALERT_ID) X
		WHERE
			X.DocumentID = @DOCUMENT_ID
		;
		END
	END

	--  MESSAGE
	BEGIN
		IF @CAN_DELETE = 1
		BEGIN
			IF @APPROVAL_COUNT > 0 
			BEGIN
				SELECT @CAN_DELETE = 0;
				IF @APPROVAL_COUNT = 1
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has one approval and cannot be deleted.'
				END
				ELSE
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has ' + CAST(@APPROVAL_COUNT AS VARCHAR)  + ' approvals and cannot be deleted.'
				END
			END
		END
		IF @CAN_DELETE = 1
		BEGIN
			IF @TOTAL_MARKUP_COUNT > 0 
			BEGIN
				SELECT @CAN_DELETE = 0;
				IF @TOTAL_MARKUP_COUNT = 1
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has one markup and cannot be deleted.'
				END
				ELSE
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has ' + CAST(@TOTAL_MARKUP_COUNT AS VARCHAR)  + ' markups and cannot be deleted.'
				END
			END
		END
		IF @CAN_DELETE = 1
		BEGIN
			IF @TOTAL_COMMENT_COUNT > 0 
			BEGIN
				SELECT @CAN_DELETE = 0;
				IF @TOTAL_COMMENT_COUNT = 1
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has one comment and cannot be deleted.'
				END
				ELSE
				BEGIN
					SELECT @CAN_DELETE_MESSAGE = 'Asset has ' + CAST(@TOTAL_COMMENT_COUNT AS VARCHAR)  + ' comments and cannot be deleted.'
				END
			END
		END
	END
	--	RETURN
	BEGIN
		SELECT
			[CanDelete] = CAST(ISNULL(@CAN_DELETE, 1) AS BIT),
			[CanDeleteMessage] = @CAN_DELETE_MESSAGE,
			[TotalMarkupCount] = ISNULL(@TOTAL_MARKUP_COUNT, 0),
			[TotalCommentCount] = ISNULL(@TOTAL_COMMENT_COUNT, 0),
			[ApprovalCount] = ISNULL(@APPROVAL_COUNT, 0)
		;
	END
END
/*=========== QUERY ===========*/