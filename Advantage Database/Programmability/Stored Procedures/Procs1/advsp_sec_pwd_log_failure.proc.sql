IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[advsp_sec_pwd_log_failure]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_sec_pwd_log_failure]
GO
CREATE PROCEDURE [dbo].[advsp_sec_pwd_log_failure]
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
BEGIN
	--	INIT
	BEGIN
		DECLARE
			@CT INT,
			@RIGHT_NOW SMALLDATETIME,
			@ATTEMPT_COUNT INT,
			@MAX_FAILS AS INT,
			@FAILED_ATTEMPTS AS INT
		;
		SELECT
			@RIGHT_NOW = GETDATE();
		SELECT
			@MAX_FAILS = CAST(ISNULL(A.AGY_SETTINGS_VALUE, 0) AS INT)
		FROM 
			AGY_SETTINGS A WITH(NOLOCK)
		WHERE 
			A.AGY_SETTINGS_CODE = 'PWD_MAX_FAIL';
	END
	--	LOG FAILS
	IF @MAX_FAILS > 0
	BEGIN
		DECLARE @REC TABLE (ID INT, USER_CODE VARCHAR(100), ATTEMPTS INT, LOCK_DATE SMALLDATETIME);
		INSERT INTO @REC
		EXEC [dbo].[advsp_sec_pwd_lock_load] @USER_CODE;	
		SELECT @CT = COUNT(1) FROM @REC;
		IF ISNULL(@CT, 0) > 0
		BEGIN
			--  LOG FAILURE
			BEGIN
				-- CURRENT FAILS
				SELECT 
					@ATTEMPT_COUNT = ISNULL(S.ATTEMPTS, 0)
				FROM
					SEC_PWD_LOCK S WITH(NOLOCK)
				WHERE
					S.USER_CODE = @USER_CODE;
				--  PLUS THIS FAIL
				SELECT @FAILED_ATTEMPTS = ISNULL(@ATTEMPT_COUNT, 0) + 1;
				--  UPDATE
				UPDATE SEC_PWD_LOCK WITH(ROWLOCK)
				SET 
					ATTEMPTS = @FAILED_ATTEMPTS,
					LOCK_DATE =	CASE
									WHEN @FAILED_ATTEMPTS >= @MAX_FAILS THEN @RIGHT_NOW
									ELSE NULL
								END
				WHERE
					USER_CODE = @USER_CODE;
			END
		END
	END
	--	RETURN
	SELECT ISNULL(@FAILED_ATTEMPTS, 0);
END
/*=========== QUERY ===========*/
