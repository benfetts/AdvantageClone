IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = object_id(N'[dbo].[advsp_alert_system_complete_dismiss]')
			AND OBJECTPROPERTY(id, N'IsProcedure') = 1
		)
	DROP PROCEDURE [dbo].[advsp_alert_system_complete_dismiss]
GO
CREATE PROCEDURE [dbo].[advsp_alert_system_complete_dismiss]
@CUT_OFF_DATE SMALLDATETIME,
@INCL_ASSIGNMENTS BIT,
@INCL_ALERTS BIT,
@EMP_CODE VARCHAR(6)
AS
BEGIN
	IF @EMP_CODE = ''
	BEGIN
		SET @EMP_CODE = NULL;
	END
	ELSE
	BEGIN
		SET @EMP_CODE = RTRIM(LTRIM(@EMP_CODE));
	END
	DECLARE @RECS TABLE (ID INT IDENTITY, ALERT_ID INT, ALERT_RCPT_ID INT, EMP_CODE VARCHAR(6), IS_WORK_ITEM BIT, IS_CC BIT);
	DECLARE @ERRORS TABLE (ID INT IDENTITY, ALERT_ID INT, ALERT_RCPT_ID INT, EMP_CODE VARCHAR(6), IS_WORK_ITEM BIT, IS_CC BIT);
	DECLARE
		@REC_COUNT INT,
		@CTR INT,
		@CURR_ALERT_ID INT,
		@CURR_EMP_CODE VARCHAR(6),
		@CURR_CURRENT_NOTIFY BIT,
		@CURR_ALERT_RCPT_ID INT,
		@MAX_ALERT_RCPT_ID INT,
		@ROWS_AFFECTED INT,
		@ERROR_COUNT INT,
		@MESSAGE VARCHAR(MAX)
		;
	SET @ROWS_AFFECTED = 0;
	SET @ERROR_COUNT = 0;
	DELETE FROM ALERT_RCPT WHERE EMP_CODE IS NULL;
	INSERT INTO @RECS(ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC)
	SELECT
		A.ALERT_ID,
		AR.ALERT_RCPT_ID,
		AR.EMP_CODE,
		CAST(ISNULL(A.IS_WORK_ITEM, 0) AS BIT),
		CASE
			WHEN (AR.CURRENT_NOTIFY IS NULL OR AR.CURRENT_NOTIFY = 0) THEN CAST(1 AS BIT)
			WHEN (AR.CURRENT_NOTIFY = 1) THEN CAST(0 AS BIT)
		END
	FROM
		ALERT_RCPT AR WITH(NOLOCK)
		INNER JOIN ALERT A WITH(NOLOCK) ON AR.ALERT_ID = A.ALERT_ID
	WHERE
		A.[GENERATED] <= @CUT_OFF_DATE
		AND (A.ALERT_CAT_ID <> 71 AND (A.ALERT_LEVEL <> 'BRD' OR A.ALERT_LEVEL IS NULL))
		AND (A.ASSIGN_COMPLETED IS NULL OR A.ASSIGN_COMPLETED = 0)
	;
	SELECT @REC_COUNT = COUNT(1) FROM @RECS;
	IF @REC_COUNT IS NOT NULL AND @REC_COUNT > 0
	BEGIN
		SELECT @CTR = 0, @CURR_ALERT_ID = NULL, @CURR_EMP_CODE = NULL;
		WHILE @REC_COUNT > @CTR
		BEGIN
			SELECT @CTR = @CTR + 1, @CURR_ALERT_ID = NULL, @CURR_EMP_CODE = NULL;
			SELECT @CURR_ALERT_ID = R.ALERT_ID, @CURR_EMP_CODE = R.EMP_CODE, @CURR_ALERT_RCPT_ID = R.ALERT_RCPT_ID FROM @RECS R WHERE R.ID = @CTR;
			SELECT
				@CURR_ALERT_RCPT_ID = AR.ALERT_RCPT_ID, 
				@CURR_CURRENT_NOTIFY = CAST(ISNULL(AR.CURRENT_NOTIFY, 0) AS BIT) 
			FROM 
				ALERT_RCPT AR WITH(NOLOCK) 
			WHERE 
				AR.EMP_CODE = @CURR_EMP_CODE AND AR.ALERT_ID = @CURR_ALERT_ID;
			IF EXISTS (SELECT 1 FROM ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) WHERE ARD.ALERT_ID = @CURR_ALERT_ID AND ARD.ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID AND ARD.EMP_CODE = @CURR_EMP_CODE)
			BEGIN
				SELECT @MAX_ALERT_RCPT_ID = MAX(ALERT_RCPT_ID) + 1 FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = @CURR_ALERT_ID;
				BEGIN TRY
					INSERT INTO ALERT_RCPT_DISMISSED(ALERT_ID, ALERT_RCPT_ID, EMP_CODE, EMAIL_ADDRESS, PROCESSED, NEW_ALERT, READ_ALERT, CURRENT_RCPT, CURRENT_NOTIFY, CARD_SEQ_NBR, CS_IS_REVIEWER)
					SELECT
						AR.ALERT_ID,
						@MAX_ALERT_RCPT_ID,
						AR.EMP_CODE,
						AR.EMAIL_ADDRESS,
						AR.PROCESSED,
						AR.NEW_ALERT,
						AR.READ_ALERT,
						AR.CURRENT_RCPT,
						AR.CURRENT_NOTIFY,
						AR.CARD_SEQ_NBR,
						AR.CS_IS_REVIEWER
					FROM
						ALERT_RCPT AR
					WHERE
						AR.ALERT_ID = @CURR_ALERT_ID
						AND AR.EMP_CODE = @CURR_EMP_CODE
						AND AR.ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;
					DELETE FROM ALERT_RCPT WITH(ROWLOCK)
					WHERE
						ALERT_ID = @CURR_ALERT_ID
						AND EMP_CODE = @CURR_EMP_CODE
						AND ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;
					SELECT @ROWS_AFFECTED = @ROWS_AFFECTED + 1;
				END TRY
				BEGIN CATCH
					SET @ERROR_COUNT = @ERROR_COUNT + 1;
					INSERT INTO @ERRORS (ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC)
					SELECT
						ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC
					FROM
						@RECS WHERE ID = @CTR;
				END CATCH
			END
			ELSE
			BEGIN
				BEGIN TRY
					INSERT INTO ALERT_RCPT_DISMISSED(ALERT_ID, ALERT_RCPT_ID, EMP_CODE, EMAIL_ADDRESS, PROCESSED, NEW_ALERT, READ_ALERT, CURRENT_RCPT, CURRENT_NOTIFY, CARD_SEQ_NBR, CS_IS_REVIEWER)
					SELECT
						AR.ALERT_ID,
						AR.ALERT_RCPT_ID,
						AR.EMP_CODE,
						AR.EMAIL_ADDRESS,
						AR.PROCESSED,
						AR.NEW_ALERT,
						AR.READ_ALERT,
						AR.CURRENT_RCPT,
						AR.CURRENT_NOTIFY,
						AR.CARD_SEQ_NBR,
						AR.CS_IS_REVIEWER
					FROM
						ALERT_RCPT AR
					WHERE
						AR.ALERT_ID = @CURR_ALERT_ID
						AND AR.EMP_CODE = @CURR_EMP_CODE
						AND AR.ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;
					DELETE FROM ALERT_RCPT WITH(ROWLOCK)
					WHERE
						ALERT_ID = @CURR_ALERT_ID
						AND EMP_CODE = @CURR_EMP_CODE
						AND ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;				
					SELECT @ROWS_AFFECTED = @ROWS_AFFECTED + 1;
				END TRY
				BEGIN CATCH
					SET @ERROR_COUNT = @ERROR_COUNT + 1;
					INSERT INTO @ERRORS (ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC)
					SELECT
						ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC
					FROM
						@RECS WHERE ID = @CTR;
				END CATCH
			END
			--	COMPLETE THE ASSIGNMENT
			BEGIN
				DECLARE
					@RCPT_CT INT,
					@IS_WORK_ITEM BIT
				SELECT @RCPT_CT = COUNT(1) FROM ALERT_RCPT WHERE ALERT_ID = @CURR_ALERT_ID AND CURRENT_NOTIFY = 1;
				SELECT @IS_WORK_ITEM = CAST(ISNULL(IS_WORK_ITEM, 0) AS BIT) FROM ALERT WHERE ALERT_ID = @CURR_ALERT_ID;
				IF @RCPT_CT = 0 AND @IS_WORK_ITEM = 1
				BEGIN
					UPDATE ALERT SET ASSIGN_COMPLETED = 1 WHERE ALERT_ID = @CURR_ALERT_ID;
				END
			END
		END
	END
	--IF @ERROR_COUNT > 0
	--BEGIN
	--	SET @MESSAGE = 'FK error.  Please re-run this script until this message changes.';
	--END
	--ELSE
	--BEGIN
	--	SET @MESSAGE = 'Good to go!';
	--END
	--SELECT @ROWS_AFFECTED AS ROWS_AFFECTED, @MESSAGE AS [MESSAGE];
	SELECT @REC_COUNT = COUNT(1) FROM @ERRORS;
	SELECT @CTR = 0;
	IF @REC_COUNT > 0
	BEGIN
		WHILE @REC_COUNT > @CTR
		BEGIN
			SELECT @CTR = @CTR + 1, @CURR_ALERT_ID = NULL, @CURR_EMP_CODE = NULL;
			SELECT @CURR_ALERT_ID = R.ALERT_ID, @CURR_EMP_CODE = R.EMP_CODE, @CURR_ALERT_RCPT_ID = R.ALERT_RCPT_ID FROM @ERRORS R WHERE R.ID = @CTR;
			SELECT
				@CURR_ALERT_RCPT_ID = AR.ALERT_RCPT_ID, 
				@CURR_CURRENT_NOTIFY = CAST(ISNULL(AR.CURRENT_NOTIFY, 0) AS BIT) 
			FROM 
				ALERT_RCPT AR WITH(NOLOCK) 
			WHERE 
				AR.EMP_CODE = @CURR_EMP_CODE AND AR.ALERT_ID = @CURR_ALERT_ID;
				SELECT @MAX_ALERT_RCPT_ID = MAX(ALERT_RCPT_ID) + 1 FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = @CURR_ALERT_ID;
				BEGIN TRY
					INSERT INTO ALERT_RCPT_DISMISSED(ALERT_ID, ALERT_RCPT_ID, EMP_CODE, EMAIL_ADDRESS, PROCESSED, NEW_ALERT, READ_ALERT, CURRENT_RCPT, CURRENT_NOTIFY, CARD_SEQ_NBR, CS_IS_REVIEWER)
					SELECT
						AR.ALERT_ID,
						@MAX_ALERT_RCPT_ID,
						AR.EMP_CODE,
						AR.EMAIL_ADDRESS,
						AR.PROCESSED,
						AR.NEW_ALERT,
						AR.READ_ALERT,
						AR.CURRENT_RCPT,
						AR.CURRENT_NOTIFY,
						AR.CARD_SEQ_NBR,
						AR.CS_IS_REVIEWER
					FROM
						ALERT_RCPT AR
					WHERE
						AR.ALERT_ID = @CURR_ALERT_ID
						AND AR.EMP_CODE = @CURR_EMP_CODE
						AND AR.ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;
					DELETE FROM ALERT_RCPT WITH(ROWLOCK)
					WHERE
						ALERT_ID = @CURR_ALERT_ID
						AND EMP_CODE = @CURR_EMP_CODE
						AND ALERT_RCPT_ID = @CURR_ALERT_RCPT_ID;
					SELECT @ROWS_AFFECTED = @ROWS_AFFECTED + 1;
				END TRY
				BEGIN CATCH
					SET @ERROR_COUNT = @ERROR_COUNT + 1;
					INSERT INTO @ERRORS (ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC)
					SELECT
						ALERT_ID, ALERT_RCPT_ID, EMP_CODE, IS_WORK_ITEM, IS_CC
					FROM
						@RECS WHERE ID = @CTR;
				END CATCH

		END
	END
	SELECT @ERROR_COUNT = COUNT(1) FROM @ERRORS;
	--PRINT ''
	--PRINT ''
	IF @ERROR_COUNT = 0
	BEGIN
		--PRINT '======================'
		--PRINT 'All done.  Good to go!'
		SELECT [Message] = 'All done.  Good to go!'
	END
	IF @ERROR_COUNT > 0
	BEGIN
	 --   PRINT '===================================================================================='
		--PRINT 'Please run this script again until this message goes away.'
		--PRINT 'If after a couple times, this message doesn''t go away; contact Advantage Dev (Sam).'
		SELECT [Message] = 'Please run this script again until this message goes away.  If after a couple times, this message doesn''t go away; contact Advantage.'
	END
END
GO
