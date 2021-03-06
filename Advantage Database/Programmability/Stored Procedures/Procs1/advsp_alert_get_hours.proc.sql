IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_alert_get_hours]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_alert_get_hours]
GO
-- exec advsp_alert_get_hours 1937
CREATE PROCEDURE [dbo].[advsp_alert_get_hours] 
@ALERT_ID INT
AS
BEGIN

	DECLARE 
		@POSTED_HOURS DECIMAL (9,3),
		@ALLOCATED_HOURS DECIMAL (9,3),
		@HOURS_ALLOWED DECIMAL (9,3),
		@HAS_CALCULATED_HOURS BIT,
		@IS_BOARD_TASK BIT,
		@IS_TASK BIT,
		@SUM_EMP_HOURS DECIMAL(10, 2),
		@HAS_WEEKLY_HOURS BIT,
		@START_DATE SMALLDATETIME,
		@DUE_DATE SMALLDATETIME,
		@ALERT_CAT_ID INT,
		@ALERT_LEVEL VARCHAR(50),
		@JOB_NUMBER INT,
		@JOB_COMPONENT_NBR SMALLINT,
		@TASK_SEQ_NBR SMALLINT

	IF EXISTS (SELECT 1 FROM SPRINT_EMPLOYEE WHERE ALERT_ID = @ALERT_ID)
	BEGIN
		SET @HAS_CALCULATED_HOURS = 1;
		SET @HAS_WEEKLY_HOURS = 1;
	END
	ELSE
	BEGIN
		SET @HAS_CALCULATED_HOURS = 0;
		SET @HAS_WEEKLY_HOURS = 0;
	END
	IF NOT @ALERT_ID IS NULL
	BEGIN
		SELECT
			@ALERT_LEVEL = A.ALERT_LEVEL,
			@ALERT_CAT_ID = A.ALERT_CAT_ID,
			@JOB_NUMBER = A.JOB_NUMBER,
			@JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR,
			@TASK_SEQ_NBR = A.TASK_SEQ_NBR
		FROM
			ALERT A WITH(NOLOCK)
		WHERE
			A.ALERT_ID = @ALERT_ID;
	END
	--IF @HAS_CALCULATED_HOURS = 0
	--BEGIN
	--	SELECT
	--		@SUM_EMP_HOURS = SUM(HOURS_ALLOWED)
	--	FROM
	--		ALERT_RCPT
	--	WHERE
	--		ALERT_ID = @ALERT_ID
	--		AND CURRENT_NOTIFY = 1
	--		AND NOT HOURS_ALLOWED IS NULL;
	--	IF NOT @SUM_EMP_HOURS IS NULL AND @SUM_EMP_HOURS > 0
	--	BEGIN
	--		SET @HAS_CALCULATED_HOURS = 1;
	--	END
	--END
	IF @ALERT_LEVEL = 'BRD'
	BEGIN
		SET @IS_BOARD_TASK = 1;
	END
	ELSE
	BEGIN
		SET @IS_BOARD_TASK = 0;
	END
	IF @ALERT_CAT_ID = 71 OR @ALERT_LEVEL = 'BRD'
	BEGIN
		SET @IS_TASK = 1;
	END
	ELSE
	BEGIN
		SET @IS_TASK = 0;
	END
	IF @HAS_CALCULATED_HOURS = 0 OR @IS_BOARD_TASK = 1 OR @HAS_WEEKLY_HOURS = 0
	BEGIN
		SELECT
			@HOURS_ALLOWED = CASE 
								WHEN ALERT.ALERT_CAT_ID = 71 THEN 
										JOB_TRAFFIC_DET.JOB_HRS 
								ELSE ALERT.HRS_ALLOWED 
								END
		FROM
			ALERT WITH(NOLOCK)
			LEFT OUTER JOIN
				JOB_TRAFFIC_DET WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
														ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND
														ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR
		WHERE
			ALERT.ALERT_ID = @ALERT_ID;

	END
	ELSE
	BEGIN
		IF @HAS_WEEKLY_HOURS = 1
		BEGIN
			--SELECT
			--	@HOURS_ALLOWED = SUM(ISNULL([HOURS], 0))
			--FROM
			--	SPRINT_EMPLOYEE SE WITH(NOLOCK)
			--WHERE
			--	SE.ALERT_ID = @ALERT_ID;
			SELECT @HOURS_ALLOWED = ALERT.HRS_ALLOWED FROM ALERT WHERE ALERT_ID = @ALERT_ID
		END
		ELSE
		BEGIN
			--SELECT
			--	@HOURS_ALLOWED = SUM(ISNULL(HOURS_ALLOWED, 0))
			--FROM
			--	ALERT_RCPT AR WITH(NOLOCK)
			--WHERE
			--	AR.ALERT_ID = @ALERT_ID
			--	AND CURRENT_NOTIFY = 1
			--	AND NOT HOURS_ALLOWED IS NULL

			--DECLARE @TEMP_HOURS_ALLOWED DECIMAL
			--SELECT
			--	@TEMP_HOURS_ALLOWED = SUM(ISNULL(HOURS_ALLOWED, 0))
			--FROM
			--	ALERT_RCPT_DISMISSED ARD WITH(NOLOCK)
			--WHERE
			--	ARD.ALERT_ID = @ALERT_ID
			--	AND CURRENT_NOTIFY = 1
			--	AND NOT HOURS_ALLOWED IS NULL

			--SET @HOURS_ALLOWED = @HOURS_ALLOWED + @TEMP_HOURS_ALLOWED

			SELECT @HOURS_ALLOWED = ALERT.HRS_ALLOWED FROM ALERT  WHERE ALERT_ID = @ALERT_ID


		END
	END

	SELECT	
		@POSTED_HOURS = SUM(EMP_HOURS)
	FROM
		EMP_TIME_DTL WITH(NOLOCK)
	WHERE
		ALERT_ID = @ALERT_ID
	GROUP BY
		ALERT_ID;
		
	IF @HAS_WEEKLY_HOURS = 1
	BEGIN
		SELECT	
			@ALLOCATED_HOURS = SUM(ISNULL([HOURS], 0))
		FROM
			SPRINT_EMPLOYEE WITH(NOLOCK)
		WHERE
			ALERT_ID = @ALERT_ID
		GROUP BY
			ALERT_ID;
	END
	ELSE
	BEGIN
		IF @IS_TASK = 1
		BEGIN
		 SELECT @ALLOCATED_HOURS = SUM(ISNULL(HOURS_ALLOWED, 0)) 
		 FROM JOB_TRAFFIC_DET_EMPS
		 JOIN ALERT ON JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = ALERT.JOB_NUMBER 
			AND JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = ALERT.JOB_COMPONENT_NBR
			AND JOB_TRAFFIC_DET_EMPS.SEQ_NBR = ALERT.TASK_SEQ_NBR
		 WHERE 
			ALERT.ALERT_ID = @ALERT_ID
			
		END
		ELSE
		BEGIN
			SELECT
				@ALLOCATED_HOURS = SUM(ISNULL(HOURS_ALLOWED, 0))
			FROM
				ALERT_RCPT AR WITH(NOLOCK)
			WHERE
				AR.ALERT_ID = @ALERT_ID
				AND CURRENT_NOTIFY = 1
				AND NOT HOURS_ALLOWED IS NULL;

			set @ALLOCATED_HOURS = isnull(@ALLOCATED_HOURS,0)

			DECLARE @TEMP_ALLOCATED_HOURS DECIMAL
			SELECT
				@TEMP_ALLOCATED_HOURS = SUM(ISNULL(HOURS_ALLOWED, 0))
			FROM
				ALERT_RCPT_DISMISSED ARD WITH(NOLOCK)
			WHERE
				ARD.ALERT_ID = @ALERT_ID
				AND CURRENT_NOTIFY = 1
				AND NOT HOURS_ALLOWED IS NULL;

			SET @ALLOCATED_HOURS = @ALLOCATED_HOURS + ISNULL(@TEMP_ALLOCATED_HOURS,0);

		END
	END

	IF NOT @ALERT_ID IS NULL AND @ALERT_ID > 0
	BEGIN
		IF @IS_TASK = 0
		BEGIN
			SELECT
				@START_DATE = A.[START_DATE],
				@DUE_DATE = A.DUE_DATE
			FROM
				ALERT A WITH(NOLOCK)
			WHERE
				A.ALERT_ID = @ALERT_ID;
		END
		ELSE
		BEGIN
			SELECT
				@START_DATE = J.TASK_START_DATE,
				@DUE_DATE = J.JOB_REVISED_DATE
			FROM
				ALERT A WITH(NOLOCK)
				INNER JOIN JOB_TRAFFIC_DET J ON A.JOB_NUMBER = J.JOB_NUMBER AND A.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = J.SEQ_NBR
			WHERE
				A.ALERT_ID = @ALERT_ID;
		END
	END

	SELECT
		[HoursAllowed] = ISNULL(@HOURS_ALLOWED, 0.00),
		[HoursPosted] = ISNULL(@POSTED_HOURS, 0.00),
		[HoursAllocated] = ISNULL(@ALLOCATED_HOURS, 0.00),
		[HoursBalance] = ISNULL(@ALLOCATED_HOURS, 0.00) - ISNULL(@POSTED_HOURS, 0.00),
		[HoursAllocatedBalance] = ISNULL(@ALLOCATED_HOURS, 0.00) - ISNULL(@ALLOCATED_HOURS, 0.00),
		[HasCalculatedHours] = ISNULL(@HAS_CALCULATED_HOURS, 0),
		[AlertID] = ISNULL(@ALERT_ID, 0),
		[StartDate] = @START_DATE,
		[DueDate] = @DUE_DATE;

END


GO


