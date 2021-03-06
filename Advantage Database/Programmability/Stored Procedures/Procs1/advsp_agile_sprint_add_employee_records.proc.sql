
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_sprint_add_employee_records]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_sprint_add_employee_records]
GO
-- exec advsp_agile_sprint_check_employee_records 1927,null,0
CREATE PROCEDURE [dbo].[advsp_agile_sprint_add_employee_records] 
@ALERT_ID INT,
@START_DATE SMALLDATETIME,
@CREATE_PAST BIT
AS
/*=========== QUERY ===========*/
BEGIN
    DECLARE @SPRINT_EMPLOYEE TABLE (SPRINT_DTL_ID INT, WEEK_START SMALLDATETIME, WEEK_END SMALLDATETIME, WEEK_NUM INT, HOURS DECIMAL (18,2), ALERT_ID INT, EMP_CODE VARCHAR(6));
	DECLARE @WEEKS_TABLE TABLE(WEEK_NUMBER INT, WEEK_START SMALLDATETIME);
	DECLARE @CURRENT_ASSIGNEES TABLE (ID INT IDENTITY, EMP_CODE VARCHAR(6));
    DECLARE 
	   @WEEKS INT,
	   @DAYS INT,
	   @ITEM_START_DATE SMALLDATETIME,
	   @DUE_DATE SMALLDATETIME,
	   @TODAY_DATE SMALLDATETIME,
	   @ALERT_LEVEL VARCHAR(100),
	   @IS_BOARD_TASK BIT,
	   @SUCCESS BIT,
	   @MESSAGE VARCHAR(500),
	   @HAS_RECORDS BIT,
	   @ALERT_HOURS DECIMAL (7, 2),
	   @DISBURSED_HOURS DECIMAL (7,2),
	   @TOTAL_WEEKS INT,
	   @TOTAL_ASSIGNEES INT,
	   @JOB_NUMBER INT,
	   @JOB_COMPONENT_NBR SMALLINT,
	   @TASK_SEQ_NBR SMALLINT,
	   @ROW_COUNT INT

	SELECT @ROW_COUNT = count(1) from SPRINT_EMPLOYEE WHERE ALERT_ID = @ALERT_ID

	if @ROW_COUNT <= 0
	BEGIN
		print 'No Rows'
		RETURN
	END

    SELECT 
		@ALERT_LEVEL = ALERT_LEVEL, 
		@ALERT_HOURS = ISNULL(HRS_ALLOWED, 0.00),
		@JOB_NUMBER = JOB_NUMBER,
		@JOB_COMPONENT_NBR = JOB_COMPONENT_NBR,
		@TASK_SEQ_NBR = TASK_SEQ_NBR
	FROM 
		ALERT 
	WHERE ALERT_ID = @ALERT_ID;
	SELECT @TODAY_DATE = CONVERT(VARCHAR(10), GETDATE(), 111), @SUCCESS = 1, @MESSAGE = '';
	SELECT @DISBURSED_HOURS = ISNULL(@DISBURSED_HOURS, 0.00);
    IF @ALERT_LEVEL = 'BRD'
    BEGIN
	   SET @IS_BOARD_TASK = 1;
    END
    ELSE
    BEGIN
	   SET @IS_BOARD_TASK = 0;
    END
	IF @IS_BOARD_TASK = 1
	BEGIN
		SELECT
			@ALERT_HOURS = CASE WHEN ISNULL(J.HOURS_ASSIGNED, 0) <> 0 THEN J.HOURS_ASSIGNED 
										ELSE J.JOB_HRS 
									END
		FROM
			JOB_TRAFFIC_DET J
		WHERE
			J.JOB_NUMBER = @JOB_NUMBER
			AND J.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
			AND J.SEQ_NBR = @TASK_SEQ_NBR;
	END
	--	GET DATES
	BEGIN
		IF @IS_BOARD_TASK = 0
		BEGIN
			SELECT
				@ITEM_START_DATE = [START_DATE],
				@DUE_DATE = DUE_DATE
			FROM
				ALERT A WITH(NOLOCK)
			WHERE
				A.ALERT_ID = @ALERT_ID;
		END
		IF @IS_BOARD_TASK = 1
		BEGIN
			SELECT
				@ITEM_START_DATE = J.TASK_START_DATE,
				@DUE_DATE = ISNULL(J.JOB_REVISED_DATE, J.JOB_DUE_DATE)
			FROM
				ALERT A WITH(NOLOCK)
				INNER JOIN JOB_TRAFFIC_DET J WITH(NOLOCK) ON A.JOB_NUMBER = J.JOB_NUMBER AND A.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = J.SEQ_NBR
			WHERE
				A.ALERT_ID = @ALERT_ID;
		END
		IF @START_DATE IS NULL
		BEGIN
			SELECT @START_DATE = @ITEM_START_DATE
		END
		IF @START_DATE IS NULL
		BEGIN
			SELECT @START_DATE = @TODAY_DATE;
		END
		--  CHECK FOR MAX
		BEGIN
			IF DATEDIFF(WEEK, @START_DATE, @DUE_DATE) > 52
			BEGIN
				SELECT @SUCCESS = 0, @MESSAGE = 'Assignment hours cannot span more than 52 weeks.'
			END
		END
		IF @SUCCESS = 1
		BEGIN
			--  CREATE PAST WEEKS?
			IF (NOT @START_DATE IS NULL) AND (@START_DATE < @TODAY_DATE) AND (@CREATE_PAST IS NULL OR @CREATE_PAST = 0)
			BEGIN
				SELECT @START_DATE = @TODAY_DATE;	--	NO
			END
			IF NOT @START_DATE IS NULL AND NOT @DUE_DATE IS NULL
			BEGIN
				--	CHANGE START DATE TO FIRST OF WEEK?? NEEDED?
				SELECT @START_DATE = DATEADD(WEEK, DATEDIFF(WEEK, '19050101', @START_DATE), '19050101');
				SELECT @DUE_DATE = DATEADD(WEEK, DATEDIFF(WEEK, '19050101', @DUE_DATE), '19050101');
				SELECT @DUE_DATE = DATEADD(WEEK, 1, @DUE_DATE);
				SELECT @DUE_DATE = DATEADD(DAY, -1, @DUE_DATE);
				SELECT @DAYS = DATEDIFF(DAY, @START_DATE, @DUE_DATE);	
				IF NOT @DAYS IS NULL AND @DAYS > 0
				BEGIN
					DECLARE @WEEKS_MOD INT;
					SELECT @WEEKS = @DAYS / 7;
					SELECT @WEEKS_MOD = @DAYS % 7;
					IF NOT @WEEKS_MOD IS NULL AND @WEEKS_MOD <> 0 -- Always round up week
					BEGIN
						SELECT @WEEKS = @WEEKS + 1;
					END
				END
			END
		END
	END
	IF @SUCCESS = 1
	BEGIN
		--	GET DURATION IN WEEKS
		BEGIN
			DECLARE 
				@WK_CT INT;
			SET @WK_CT = 1;
			WHILE @WK_CT <= @WEEKS
			BEGIN
			   INSERT INTO @WEEKS_TABLE (WEEK_NUMBER, WEEK_START)
			   VALUES (@WK_CT, DATEADD(WEEK, @WK_CT - 1, @START_DATE));
			   SET @WK_CT = @WK_CT + 1;
			END
		END	
		--	GET EMPLOYEES
		BEGIN
			IF @IS_BOARD_TASK = 0
			BEGIN
				DECLARE
					@ROUTED_ASSIGNED_EMP_CODE VARCHAR(6),
					@FUBAR INT
				-- ROUTED EMLOYEE
				SELECT
					@ROUTED_ASSIGNED_EMP_CODE = ASSIGNED_EMP_CODE
				FROM
					ALERT 
				WHERE ALERT_ID = @ALERT_ID;

				SELECT @FUBAR = COUNT(1)
					FROM
						ALERT_RCPT AR
					WHERE
						AR.ALERT_ID = @ALERT_ID
						AND AR.CURRENT_NOTIFY = 1;


				IF @ROUTED_ASSIGNED_EMP_CODE IS NOT NULL AND @FUBAR <= 1
				BEGIN
					INSERT INTO @CURRENT_ASSIGNEES (EMP_CODE) VALUES (@ROUTED_ASSIGNED_EMP_CODE);
				END
				ELSE
				BEGIN
					--	NON-ROUTED EMLOYEE(S)
					INSERT INTO @CURRENT_ASSIGNEES
					SELECT AR.EMP_CODE
					FROM
						ALERT_RCPT AR
					WHERE
						AR.ALERT_ID = @ALERT_ID
						AND AR.CURRENT_NOTIFY = 1
						AND AR.EMP_CODE not in (select EMP_CODE from SPRINT_EMPLOYEE where ALERT_ID = @ALERT_ID);
				END
			END
			--	TASK EMPLOYEES
			IF @IS_BOARD_TASK = 1
			BEGIN
				INSERT INTO @CURRENT_ASSIGNEES
				SELECT DISTINCT J.EMP_CODE
				FROM
					JOB_TRAFFIC_DET_EMPS J
					INNER JOIN ALERT A ON A.JOB_NUMBER = J.JOB_NUMBER AND A.JOB_COMPONENT_NBR = J.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = J.SEQ_NBR
				WHERE
					A.ALERT_ID = @ALERT_ID
					AND J.EMP_CODE not in (select EMP_CODE from SPRINT_EMPLOYEE where ALERT_ID = @ALERT_ID);
			END
		END
		--  IF FIRST TIME, DISBURSE HOURS
		BEGIN
			IF EXISTS (SELECT 1 FROM SPRINT_EMPLOYEE WHERE ALERT_ID = @ALERT_ID)
			BEGIN
				SELECT @HAS_RECORDS = 1;
			END
			ELSE
			BEGIN
				SELECT @HAS_RECORDS = 0;
				SELECT @TOTAL_WEEKS = COUNT(1) FROM @WEEKS_TABLE;
				SELECT @TOTAL_ASSIGNEES = COUNT(1) FROM @CURRENT_ASSIGNEES;
			END
			IF @HAS_RECORDS = 0 AND @TOTAL_ASSIGNEES > 0 AND @TOTAL_WEEKS > 0 AND @ALERT_HOURS > 0
			BEGIN
				SELECT @DISBURSED_HOURS = @ALERT_HOURS / (@TOTAL_ASSIGNEES * @TOTAL_WEEKS);
			END
			--SELECT @HAS_RECORDS,@TOTAL_WEEKS,@TOTAL_ASSIGNEES,@DISBURSED_HOURS
		END

		--	GET MISSING RECORDS FOR EACH EMPLOYEE
		BEGIN
			DECLARE
			   @WEEK_COUNT INT,
			   @CURR_WEEK_NUM INT,
			   @CURR_WEEK_START SMALLDATETIME,
			   @CURR_WEEK_END SMALLDATETIME;
			SET @CURR_WEEK_START = @START_DATE;
			SET @CURR_WEEK_NUM = 0;
			SET @WEEK_COUNT = 0;
			DECLARE
				@EMP_COUNT INT,
				@CURR_EMP_COUNT INT,
				@CURR_EMP_CODE VARCHAR(6),
			    @CURR_EMP_HOURS DECIMAL (7,2),
			    @CURR_EMP_DISBURSED_HOURS DECIMAL (7,2);
			SELECT @EMP_COUNT = COUNT(1) FROM @CURRENT_ASSIGNEES;
			SET @CURR_EMP_COUNT = 1;
			WHILE @CURR_EMP_COUNT <= @EMP_COUNT
			BEGIN
				SELECT @CURR_EMP_CODE = NULL, @CURR_EMP_HOURS = NULL, @CURR_EMP_DISBURSED_HOURS = NULL;
				SELECT @CURR_EMP_CODE = EMP_CODE FROM @CURRENT_ASSIGNEES CA WHERE CA.ID = @CURR_EMP_COUNT;
				SET @CURR_EMP_COUNT = @CURR_EMP_COUNT + 1;
				IF NOT @CURR_EMP_CODE IS NULL
				BEGIN
					--	INSERT MISSING WEEKS FOR EACH EMPLOYEE
					BEGIN  
						INSERT INTO SPRINT_EMPLOYEE (WEEK_START, WEEK_END, WEEK_NUM, HOURS, ALERT_ID, EMP_CODE)
						SELECT
							WT.WEEK_START,
							DATEADD(DAY, 6, WT.WEEK_START),
							WT.WEEK_NUMBER,
							@DISBURSED_HOURS,
							@ALERT_ID,
							@CURR_EMP_CODE
						FROM
							@WEEKS_TABLE WT
						WHERE
							WT.WEEK_START NOT IN (SELECT 
													  SE.WEEK_START 
												  FROM 
													  SPRINT_EMPLOYEE SE 
												  WHERE 
													  SE.ALERT_ID = @ALERT_ID 
													  AND SE.EMP_CODE = @CURR_EMP_CODE);
					END	
					--  DISBURSE FROM EMP HOURS TO WEEKLY (WOULD OVERRIDE WHAT IS SET FROM ALERT HOURS IF EMP HOURS EXIST

					BEGIN
					select @CURR_EMP_HOURS = HOURS_ALLOWED FROM(
						SELECT 	AR.HOURS_ALLOWED
						FROM 
							ALERT_RCPT AR
						WHERE
							AR.ALERT_ID = @ALERT_ID
							AND AR.EMP_CODE = @CURR_EMP_CODE
							AND AR.CURRENT_NOTIFY = 1
						union 
						SELECT HOURS_ALLOWED
						 FROM JOB_TRAFFIC_DET_EMPS
							 JOIN ALERT ON JOB_TRAFFIC_DET_EMPS.JOB_NUMBER = ALERT.JOB_NUMBER 
							AND JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR = ALERT.JOB_COMPONENT_NBR
							AND JOB_TRAFFIC_DET_EMPS.SEQ_NBR = ALERT.TASK_SEQ_NBR
						 WHERE 
							ALERT.ALERT_ID = @ALERT_ID
							AND JOB_TRAFFIC_DET_EMPS.EMP_CODE = @CURR_EMP_CODE) a

						IF @CURR_EMP_HOURS IS NOT NULL AND @CURR_EMP_HOURS > 0 AND @WEEKS > 0
						BEGIN
							SELECT @CURR_EMP_DISBURSED_HOURS = @CURR_EMP_HOURS / @WEEKS;
							UPDATE SPRINT_EMPLOYEE SET [HOURS] = @CURR_EMP_DISBURSED_HOURS
							WHERE
								EMP_CODE = @CURR_EMP_CODE
								AND ALERT_ID = @ALERT_ID
								AND SPRINT_DTL_ID IS NULL;
						END
					END

				END

			END
		END
		-- CLEAN UP
		BEGIN
			EXEC [dbo].[advsp_agile_hours_cleanup] @ALERT_ID, @START_DATE, @DUE_DATE;
		END
		--  MESSAGE
		SELECT @SUCCESS = 1;
		SELECT @MESSAGE = CAST((SELECT COUNT(1) FROM @WEEKS_TABLE) AS VARCHAR) + ' WEEKS AND ' + CAST((SELECT COUNT(1) FROM @CURRENT_ASSIGNEES) AS VARCHAR) + ' ASSIGNEES.'
	END
	SELECT 
		[Success] = @SUCCESS, 
		[Message] = @MESSAGE;
END
/*=========== QUERY ===========*/


GO


