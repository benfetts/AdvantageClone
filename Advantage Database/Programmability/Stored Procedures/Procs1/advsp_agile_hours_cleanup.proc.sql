IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_hours_cleanup]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_hours_cleanup]
GO
CREATE PROCEDURE [dbo].[advsp_agile_hours_cleanup] 
@ALERT_ID INT,
@START_DATE SMALLDATETIME,
@DUE_DATE SMALLDATETIME
AS
/*=========== QUERY ===========*/
BEGIN
	IF NOT @ALERT_ID IS NULL AND @ALERT_ID > 0 
	BEGIN
		-- INIT VARIABLES
		DECLARE
			@JOB_NUMBER INT,
			@JOB_COMPONENT_NBR SMALLINT,
			@TASK_SEQ_NBR SMALLINT
		-- GET DATES
		IF @START_DATE IS NULL OR @DUE_DATE IS NULL
		BEGIN
			SELECT
				@START_DATE = A.[START_DATE],
				@DUE_DATE = A.[DUE_DATE],
				@JOB_NUMBER = A.[JOB_NUMBER],
				@JOB_COMPONENT_NBR = A.[JOB_COMPONENT_NBR],
				@TASK_SEQ_NBR = A.[TASK_SEQ_NBR]
			FROM
				ALERT A WITH(NOLOCK)
			WHERE 
				A.ALERT_ID = @ALERT_ID;
			--  OVERRIDE DATES IF TASK
			IF NOT @JOB_NUMBER IS NULL AND NOT @JOB_COMPONENT_NBR IS NULL AND NOT @TASK_SEQ_NBR IS NULL
			BEGIN
				IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 AND @TASK_SEQ_NBR >= 0
				BEGIN
					SELECT
						@START_DATE = J.TASK_START_DATE,
						@DUE_DATE = ISNULL(J.JOB_REVISED_DATE, J.JOB_DUE_DATE)
					FROM
						JOB_TRAFFIC_DET J WITH(NOLOCK)
					WHERE
						J.JOB_NUMBER = @JOB_NUMBER
						AND J.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
						AND J.SEQ_NBR = @TASK_SEQ_NBR;
				END
			END
		END
		-- CLEAN UP REMOVED RECIPIENTS
		BEGIN
			EXEC [dbo].[advsp_agile_remove_hrs_deleted_rcpt] @ALERT_ID;
		END
		--  CLEAN UP DATE CHANGES
		IF NOT @START_DATE IS NULL AND NOT @DUE_DATE IS NULL
		BEGIN
			DELETE
			FROM 
				SPRINT_EMPLOYEE WITH(ROWLOCK)
			WHERE 
				ALERT_ID = @ALERT_ID
				AND (
						(WEEK_START < @START_DATE)
						OR (WEEK_END > @DUE_DATE)
					);
		END
		--  REMOVE HOURS IF DATE MISSING (???)
		IF @START_DATE IS NULL OR @DUE_DATE IS NULL
		BEGIN
			DELETE FROM SPRINT_EMPLOYEE WITH(ROWLOCK) WHERE ALERT_ID = @ALERT_ID;
		END
	END
END
/*=========== QUERY ===========*/