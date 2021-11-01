IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_can_delete_document]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_can_delete_document];
END
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
			@MESSAGE VARCHAR(MAX) = '',
			@MARKUP_COUNT INT = 0,
			@COMMENT_COUNT INT = 0
		;
	END
	--	INIT
	BEGIN
		SELECT
			@IS_PROOF = CASE
							WHEN A.ALERT_CAT_ID = 79 THEN 1
							ELSE 0
						END
		FROM	
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_ID = @ALERT_ID
		;
		IF @IS_PROOF = 1
		BEGIN
			SELECT 
				@MARKUP_COUNT = COUNT(1) 
			FROM 
				PROOFING_MARKUP PM WITH(NOLOCK) 
			WHERE 
				PM.DOCUMENT_ID = @DOCUMENT_ID
			;
			SELECT 
				@COMMENT_COUNT = COUNT(1) 
			FROM 
				ALERT_COMMENT AC WITH(NOLOCK) 
			WHERE 
				AC.DOCUMENT_ID = @DOCUMENT_ID
			;
		END
	END
	--	MESSAGE
	BEGIN
		IF @IS_PROOF = 1
		BEGIN
			IF @MARKUP_COUNT > 0 --OR @COMMENT_COUNT > 0
			BEGIN
				SELECT @CAN_DELETE = 0;
				IF @MARKUP_COUNT > 0
				BEGIN
					IF @MARKUP_COUNT = 1
					BEGIN
						SELECT @MESSAGE = 'This asset has one markup and cannot be deleted.'
					END
					IF @MARKUP_COUNT > 1 
					BEGIN
						SELECT @MESSAGE = 'This asset has ' + CAST(@MARKUP_COUNT AS VARCHAR) + ' markups and cannot be deleted';
					END
				END
				--IF @COMMENT_COUNT > 0 
				--BEGIN
				--	IF @MARKUP_COUNT > 0
				--	BEGIN
				--		SELECT @MESSAGE = @MESSAGE + '  ';
				--	END
				--	IF @COMMENT_COUNT = 1
				--	BEGIN
				--		SELECT @MESSAGE = 'This asset is associated with one comment and cannot be deleted.'
				--	END
				--	IF @COMMENT_COUNT > 1 
				--	BEGIN
				--		SELECT @MESSAGE = 'This asset is associated with ' + CAST(@COMMENT_COUNT AS VARCHAR) + ' comments and cannot be deleted';
				--	END
				--END
			END
		END
		ELSE
		BEGIN	
			SELECT 
				@CAN_DELETE = 1, 
				@MESSAGE = NULL
			;
		END
	END
	--	RETURN
	BEGIN
		SELECT
			[CanDelete] = ISNULL(@CAN_DELETE, 1),
			[Message] =	CASE
							WHEN ISNULL(@CAN_DELETE, 1) = 1 THEN NULL
							ELSE @MESSAGE
						END
		;
	END
END
/*=========== QUERY ===========*/