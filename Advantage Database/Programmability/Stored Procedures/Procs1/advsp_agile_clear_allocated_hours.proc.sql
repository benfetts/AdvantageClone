IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_clear_allocated_hours]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_clear_allocated_hours]
GO

CREATE PROCEDURE [dbo].[advsp_agile_clear_allocated_hours]
@ALERT_ID INT,
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT,
@TASK_SEQ_NBR SMALLINT,
@EMP_CODE VARCHAR(6),
@IS_TEMP_COMPLETE BIT
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE
		@IS_TASK BIT,
		@IS_COMPLETED BIT

	SET @IS_TASK = 0;
	SET @IS_TEMP_COMPLETE = ISNULL(@IS_TEMP_COMPLETE, 0);
	SET @IS_COMPLETED = 0;

	IF NOT @ALERT_ID IS NULL AND @ALERT_ID > 0
	BEGIN
		IF EXISTS (SELECT 1 FROM ALERT WHERE ALERT_ID = @ALERT_ID AND ALERT_LEVEL = 'BRD')
		BEGIN
			SELECT
			@JOB_NUMBER = JOB_NUMBER, @JOB_COMPONENT_NBR = JOB_COMPONENT_NBR, @TASK_SEQ_NBR = TASK_SEQ_NBR, @IS_COMPLETED = ASSIGN_COMPLETED FROM ALERT WHERE ALERT_ID = @ALERT_ID;	
			SET @IS_TASK = 1;
			SET @IS_COMPLETED = ISNULL(@IS_COMPLETED, 0);
		END
	END

	IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0 AND @TASK_SEQ_NBR > 0
	BEGIN
		IF @IS_TASK = 0
		BEGIN
			IF EXISTS (SELECT 1 FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @TASK_SEQ_NBR)
			BEGIN
				SELECT @IS_COMPLETED = CASE WHEN JOB_COMPLETED_DATE IS NULL THEN 0 ELSE 1 END
				FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @TASK_SEQ_NBR;
				SET @IS_TASK = 1;
			END
		END
		IF @ALERT_ID IS NULL OR @ALERT_ID = 0
		BEGIN
			SELECT @ALERT_ID = ALERT_ID 
			FROM ALERT 
			WHERE 
			JOB_NUMBER = @JOB_NUMBER 
			AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR 
			AND TASK_SEQ_NBR = @TASK_SEQ_NBR AND ALERT_LEVEL = 'BRD'
		END
	END

	IF NOT @ALERT_ID IS NULL AND @ALERT_ID > 0
	BEGIN
		IF @IS_TASK = 1 AND @IS_TEMP_COMPLETE = 1 AND @IS_COMPLETED = 0
		BEGIN
			DELETE FROM
			SPRINT_EMPLOYEE
			WHERE
				(ALERT_ID = @ALERT_ID
				OR
				SPRINT_DTL_ID IN (SELECT ID FROM SPRINT_DTL WHERE ALERT_ID = @ALERT_ID))
				AND SPRINT_EMPLOYEE.EMP_CODE = @EMP_CODE;
		END
		ELSE
		BEGIN
			DELETE FROM
			SPRINT_EMPLOYEE
			WHERE
				(ALERT_ID = @ALERT_ID
				OR
				SPRINT_DTL_ID IN (SELECT ID FROM SPRINT_DTL WHERE ALERT_ID = @ALERT_ID));
		END
	END

END
/*=========== QUERY ===========*/