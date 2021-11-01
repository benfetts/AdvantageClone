IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_delete]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_delete] /*WITH ENCRYPTION*/
@et_id INT, 
@etd_id INT, 
@time_type CHAR(1), 
@error_text VARCHAR(500) OUTPUT
AS
/*=========== QUERY ===========*/
BEGIN
	-- INIT
	BEGIN
		DECLARE 
			@row_count INT, 
			@error_code INT, 
			@emp_code VARCHAR(6), 
			@emp_date SMALLDATETIME,
			@USER_CODE VARCHAR(100),
			@DELETED BIT;
		SET @DELETED = 0;
		SET @error_code = 0;
		SET @error_text = '';
		SELECT 
			@emp_code = EMP_CODE 
		FROM 
			EMP_TIME WITH (NOLOCK) 
		WHERE 
			ET_ID = @et_id;
	END
	IF @time_type = 'D'
	BEGIN
		--GET EDIT 
		DECLARE 
			@CAN_DELETE_THIS SMALLINT,
			@EDIT_MESSAGE_THIS VARCHAR(100);           
		SELECT 
			@CAN_DELETE_THIS = CAN_EDIT, 
			@EDIT_MESSAGE_THIS = RETURN_MESSAGE 
		FROM 
			[dbo].[wvfn_ts_can_edit] (@emp_code, @et_id, @etd_id, NULL);
		SET @CAN_DELETE_THIS = ISNULL(@CAN_DELETE_THIS, 0);
		IF @CAN_DELETE_THIS = 0
		BEGIN
				IF EXISTS (
					SELECT 
						E.ET_ID 
					FROM 
						EMP_TIME_DTL E WITH (NOLOCK)
					WHERE 
						E.ET_ID = @et_id 
						AND E.ET_DTL_ID = @etd_id
						AND (E.EDIT_FLAG = 0 OR E.EDIT_FLAG IS NULL)
						AND E.AR_INV_NBR IS NULL
						AND ISNULL(E.EMP_HOURS, 0.0) = 0
					)
				BEGIN
					SET @CAN_DELETE_THIS = 1;
				END
		END
		IF @CAN_DELETE_THIS = 1
		BEGIN
			DECLARE
				@SEQ_NBR SMALLINT,
				@SUMMARIZED_REC_COUNT INT
			SELECT 
				@SUMMARIZED_REC_COUNT = COUNT(1)
			FROM   
				EMP_TIME_DTL AS etd WITH (NOLOCK)
			WHERE  
				etd.ET_ID = @et_id
				AND etd.ET_DTL_ID = @etd_id;
			IF @SUMMARIZED_REC_COUNT > 1
			BEGIN
				-- FIND EDITABLE RECORD
				BEGIN
					SELECT 
						@SEQ_NBR = MAX(SEQ_NBR) 
					FROM 
						EMP_TIME_DTL WITH(NOLOCK) 
					WHERE 
						ET_ID = @et_id 
						AND ET_DTL_ID = @etd_id 
						AND (EDIT_FLAG <> 1 OR EDIT_FLAG IS NULL);
				END
				IF @SEQ_NBR IS NULL --HAS NO EDITABLE SUMMARY RECORD
				BEGIN
					SELECT 
						@SEQ_NBR = MAX(SEQ_NBR) 
					FROM 
						EMP_TIME_DTL WITH(NOLOCK) 
					WHERE 
						ET_ID = @et_id 
						AND ET_DTL_ID = @etd_id 
						AND (EDIT_FLAG = 0 OR EDIT_FLAG IS NULL);
				END
				IF NOT @SEQ_NBR IS NULL --HAS EDITABLE SUMMARY RECORD; IF NO SEQ NUMBER, DON'T DELETE ANYTHING
				BEGIN
					DELETE FROM EMP_TIME_DTL WITH (ROWLOCK)
					WHERE 
						ET_ID = @et_id 
						AND ET_DTL_ID = @etd_id
						AND SEQ_NBR = @SEQ_NBR
						AND (EDIT_FLAG = 0 OR EDIT_FLAG IS NULL)
						AND AR_INV_NBR IS NULL;
					SET @DELETED = 1;
				END
			END
			ELSE
			BEGIN
				DELETE FROM EMP_TIME_DTL WITH (ROWLOCK)
				WHERE 
					ET_ID = @et_id 
					AND ET_DTL_ID = @etd_id
					AND (EDIT_FLAG = 0 OR EDIT_FLAG IS NULL)
					AND AR_INV_NBR IS NULL;
				SET @DELETED = 1;
			END
			SELECT 
				@USER_CODE = [USER_ID] 
			FROM 
				EMP_TIME_DTL 
			WHERE 
				ET_ID = @et_id 
				AND ET_DTL_ID = @etd_id;
			IF @@ERROR <> 0
			BEGIN
				SELECT @error_code = @@ERROR;
				SELECT @error_text = 'Delete record failed';
			END
		END
		ELSE
		BEGIN
			SELECT @error_code = -1;
			SELECT @error_text = @EDIT_MESSAGE_THIS;
		END
	END	
	ELSE IF @time_type = 'N' -- Delete non-productive time
	BEGIN
		SELECT @row_count = (SELECT 
								COUNT(1) 
							 FROM 
								EMP_TIME_NP WITH (NOLOCK) 
							 WHERE 
								ET_ID = @et_id 
								AND ET_DTL_ID = @etd_id);
		IF @row_count = 1
		BEGIN
			SELECT 
				@USER_CODE = [USER_ID] 
			FROM 
				EMP_TIME_NP 
			WHERE 
				ET_ID = @et_id 
   				AND ET_DTL_ID = @etd_id;
			DELETE FROM EMP_TIME_NP WITH (ROWLOCK)
			WHERE 
				ET_ID = @et_id 
   				AND ET_DTL_ID = @etd_id;
			SET @DELETED = 1;
			IF @@ERROR <> 0
			BEGIN
				SELECT @error_code = @@ERROR;
				SELECT @error_text = 'Delete record failed';
			END
		END
		ELSE -- Cannot delete multiple row records
		BEGIN
			SELECT @error_code = -1;
			SELECT @error_text = 'Cannot delete summary records';
		END
	END	
	IF @error_code = 0 AND @DELETED = 1
	BEGIN
		IF @SEQ_NBR IS NULL
		BEGIN
			DELETE FROM EMP_TIME_DTL_CMTS WITH (ROWLOCK)
			WHERE 
				ET_ID = @et_id 
   				AND ET_DTL_ID = @etd_id;
		END
		ELSE
		BEGIN
			DELETE FROM EMP_TIME_DTL_CMTS WITH (ROWLOCK)
			WHERE 
				ET_ID = @et_id 
   				AND ET_DTL_ID = @etd_id
				AND SEQ_NBR = @SEQ_NBR;
		END
		-- STOP ANY RELATED STOPWATCH
		BEGIN TRY
			DECLARE @CREATE_DATE SMALLDATETIME
			SET @CREATE_DATE = GETDATE();

			EXEC usp_wv_ts_StopwatchStop @EMP_CODE = @emp_code, 
							 			 @ET_ID = @et_id, 
										 @ET_DTL_ID = @etd_id, 
										 @COMMENT = NULL,
										 @USER_CODE = @USER_CODE, 
										 @CREATE_DATE = @CREATE_DATE;
		END TRY
		BEGIN CATCH
			SELECT @error_code = -1;
		END CATCH
	END
END
/*=========== QUERY ===========*/