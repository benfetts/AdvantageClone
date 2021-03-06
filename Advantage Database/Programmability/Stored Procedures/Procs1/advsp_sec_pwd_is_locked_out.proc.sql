IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[advsp_sec_pwd_is_locked_out]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_sec_pwd_is_locked_out]
GO
CREATE PROCEDURE [dbo].[advsp_sec_pwd_is_locked_out]
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
BEGIN

	--  VARS
	BEGIN
		DECLARE @REC TABLE (ID INT, USER_CODE VARCHAR(100), ATTEMPTS INT, LOCK_DATE SMALLDATETIME);
		DECLARE
			@ID INT,
			@CT INT,
			@IS_USER_LOCKED_OUT AS BIT,
			@LOCKOUT_MINUTES AS INT,
			@FAILED_ATTEMPTS INT,
			@NOW SMALLDATETIME,
			@LOCKED_DATE SMALLDATETIME,
			@MAX_FAILS INT,
			@MINUTES_SINCE_LOCKOUT INT
			;
	END
	--  INIT
	BEGIN
		SELECT
			@ID = 0,
			@CT = 0,
			@IS_USER_LOCKED_OUT = 0,
			@LOCKOUT_MINUTES = 0,
			@MINUTES_SINCE_LOCKOUT = 0,
			@FAILED_ATTEMPTS = 0,
			@MAX_FAILS = 0,
			@NOW = GETDATE()
			;

		INSERT INTO @REC
		EXEC [dbo].[advsp_sec_pwd_lock_load] @USER_CODE;

		SELECT @CT = COUNT(1) FROM @REC;

		IF @CT IS NOT NULL AND @CT > 0
		BEGIN

			SELECT @ID = (SELECT TOP 1 ID FROM @REC);

			IF @ID IS NOT NULL AND @ID > 0
			BEGIN

				SELECT
					@MAX_FAILS = CAST(ISNULL(A.AGY_SETTINGS_VALUE, 0) AS INT)
				FROM 
					AGY_SETTINGS A WITH(NOLOCK)
				WHERE 
					A.AGY_SETTINGS_CODE = 'PWD_MAX_FAIL';
				IF @MAX_FAILS  > 0
				BEGIN

					SELECT
						@FAILED_ATTEMPTS = ISNULL(R.ATTEMPTS, 0),
						@IS_USER_LOCKED_OUT =	CASE
													WHEN R.LOCK_DATE IS NOT NULL THEN CAST(1 AS BIT)
													WHEN ISNULL(R.ATTEMPTS, 0) >= ISNULL(@MAX_FAILS, 0) THEN CAST(1 AS BIT)
													ELSE CAST(0 AS BIT)
												END,
						@LOCKED_DATE = R.LOCK_DATE
					FROM
						@REC R
					WHERE
						R.ID = @ID;

					SELECT
						@LOCKOUT_MINUTES = CAST(COALESCE(A.AGY_SETTINGS_VALUE, A.AGY_SETTINGS_DEF, 0) AS INT)
					FROM 
						AGY_SETTINGS A WITH(NOLOCK)
					WHERE 
						A.AGY_SETTINGS_CODE = 'PWD_LO_TO';

				END

			END

		END

	END
	--	UNLOCK IF EXPIRED
	BEGIN
		IF @IS_USER_LOCKED_OUT = 1 AND @LOCKOUT_MINUTES > 0 AND @LOCKED_DATE IS NOT NULL
		BEGIN
			
			SELECT @MINUTES_SINCE_LOCKOUT = DATEDIFF(mi, @LOCKED_DATE, @NOW);

			IF @MINUTES_SINCE_LOCKOUT >= @LOCKOUT_MINUTES
			BEGIN
				EXEC [dbo].[advsp_sec_pwd_lock_clear] @USER_CODE;
				SELECT @IS_USER_LOCKED_OUT = 0;
			END

		END
	END
	--  RETURN
	BEGIN
		SELECT
			@IS_USER_LOCKED_OUT;
	END
END
/*=========== QUERY ===========*/
