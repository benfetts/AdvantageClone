IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_load_workitemhours_emp]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_load_workitemhours_emp]
GO
-- exec advsp_agile_load_workitemhours_emp 1907
CREATE PROCEDURE [dbo].[advsp_agile_load_workitemhours_emp] 
@ALERT_ID INT,
@USER_CODE VARCHAR(100),
@SHOW_AVAILABILITY bit
AS
/*=========== QUERY ===========*/
BEGIN
	--	TABLES
	BEGIN
		DECLARE @WEEKLY_HRS TABLE (	
									ID INT IDENTITY(1,1) NOT NULL, 
									AlertID INT,
									SprintDetailID INT,
									SprintEmployeeID INT,
									Title VARCHAR(254),
									EmployeeCode VARCHAR(6),
									FullName VARCHAR(50),
									WeekNumber INT,
									WeekStart SMALLDATETIME,
									WeekEnd SMALLDATETIME,
									HoursAssigned DECIMAL (7,3),
									HoursAvailableForWeek DECIMAL (7,3),
									HoursAssignedForWeek DECIMAL (7,3),
									HoursBalance DECIMAL (7,3),
									HoursPostedTotal DECIMAL (7,3),
									HoursPostedPrior DECIMAL (7,3),
									HoursPostedThis DECIMAL (7,3),
									HoursLeft DECIMAL (7,3),
									Complete SMALLINT
								  );
		CREATE TABLE  #EMPLOYEES  (	
									EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
									TOTAL_WEEK_HRS DECIMAL( 18, 2), 
									TOTAL_NON_TASK_HOURS DECIMAL( 18, 2)
								 );
		CREATE TABLE #NON_TASK_TIME (
										[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
										EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
										WeekNumber INT,
										WorkDay SMALLDATETIME,
										Holiday INT,
										TOTAL_HOURS DECIMAL(18,2)
									);
		DECLARE @ALERT_HOURS_BY_WEEK TABLE (
										EMP_CODE VARCHAR(6),
										EMP_HOURS DECIMAL (7, 3),
										WEEK_OF SMALLDATETIME
										);
		CREATE TABLE #EMP_WORK_DAY --Table of employee workdays
			(
				[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
				[EMP_CODE]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
				[WORK_DATE]               SMALLDATETIME,
				[STD_HRS]  DECIMAL(18,6),
				[NON_TASK_DAY] INT
			);

		CREATE TABLE #MY_DATA_ASSIGNED 
		(
			ROW_ID						INT IDENTITY(1,1) NOT NULL,
			--JOB_NUMBER					INT NULL,
			--JOB_COMPONENT_NBR			SMALLINT NULL,
			--FNC_CODE					VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--TASK_DESCRIPTION			VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--JOB_COMP_DESC				VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--TASK_START_DATE				SMALLDATETIME NULL,
			--JOB_REVISED_DATE			SMALLDATETIME NULL,
			EMP_CODE					VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--JOB_DESC					VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--OFFICE_CODE					VARCHAR(4) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--DP_TM_CODE					VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--DEF_TRF_CODE				VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--CL_CODE						VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--CL_NAME						VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--DIV_CODE					VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--PRD_CODE					VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--SORT						SMALLDATETIME NULL,
			--JOB_HRS						DECIMAL(18,6) NULL,
			--JB							DECIMAL(18,6) NULL,
			--SEQ_NBR						SMALLINT NULL,
			--EMP_FML_NAME				VARCHAR(2000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			--IS_EVENT_TASK				SMALLINT NULL,
			--TASK_TOTAL_WORKING_DAYS				INT NULL,
			--HOURS_PER_DAY				DECIMAL(18,6) NULL,
			--ADJ_JOB_HRS					DECIMAL(18,6) NULL,
			--REC_TYPE					VARCHAR(5),
			--NON_TASK_ID					SMALLINT NULL,
			--HRS_USED_NON_TASK			DECIMAL(18,6) NULL,
			HRS_AVAIL					DECIMAL(18,6) NULL,
			--HRS_ASSIGNED_TASK			DECIMAL(18,6) NULL,
			--HRS_ASSIGNED_EVENT			DECIMAL(18,6) NULL,
			--TOTAL_HRS_ASSIGNED			DECIMAL(18,6) NULL,
			--HRS_BALANCE_AVAIL			DECIMAL(18,6) NULL,
			--VARIANCE					DECIMAL(18,6) NULL,
			--STD_HRS_AVAIL				DECIMAL(18,6) NULL,
			--RED_FLAG					INT,
			--HRS_PER_DAY_WITH_ASSN		DECIMAL(18,6),
			--ADJ_JOB_HRS_WITH_ASSN		DECIMAL(18,6) NULL,
			--ALERT_ID					INT,
			--HRS_BEGIN					DECIMAL(18,6) NULL,
			--HRS_POSTED					DECIMAL(18,6) NULL,
			--HRS_LEFT					DECIMAL(18,6) NULL,
			--SPRINT_ID					INT,
			--ALERT_CAT_ID				INT,
			DISTRIBUTED_HRS				DECIMAL(18,6) NULL
		
		);

	END
	--	VARIABLES
	BEGIN
		DECLARE
			@FIRST_DAY_OF_THIS_WEEK SMALLDATETIME,
			@START_WEEK_ON TINYINT,
			@HOURS_ALLOWED DECIMAL(7,2),
			@IS_TASK BIT,
			@START_DATE SMALLDATETIME,
			@DUE_DATE SMALLDATETIME,
			@HAS_DATE_RANGE BIT,
			@JOB_NUMBER INT,
			@JOB_COMPONENT_NBR INT,
			@SEQ_NUMBER INT,
			@START_DATE_TASK SMALLDATETIME,
			@DUE_DATE_TASK SMALLDATETIME

	END
	--	INIT
	BEGIN

		--SET @START_WEEK_ON = (SELECT [dbo].[advfn_StartWeekOnDay](@USER_CODE)); // FACTOR IN START OF WEEK NOT SUNDAY??
		SET @START_WEEK_ON = 1;
		SELECT @FIRST_DAY_OF_THIS_WEEK = (SELECT DATEADD(DAY, @START_WEEK_ON - DATEPART(WEEKDAY, GETDATE()), GETDATE()));
		SELECT 
			@HOURS_ALLOWED = A.HRS_ALLOWED,
			@IS_TASK =
				CASE
					WHEN A.ALERT_LEVEL = 'BRD' THEN CAST(1 AS BIT)
					ELSE CAST(0 AS BIT)
				END,
			@START_DATE = A.[START_DATE],
			@DUE_DATE = A.DUE_DATE,
			@JOB_NUMBER = A.JOB_NUMBER,
			@JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR,
			@SEQ_NUMBER = A.TASK_SEQ_NBR
		FROM 
			ALERT A 
		WHERE 
			ALERT_ID = @ALERT_ID;
		IF NOT @START_DATE IS NULL AND NOT @DUE_DATE IS NULL
		BEGIN
			SET @HAS_DATE_RANGE = 1;
		END
		ELSE
		BEGIN			
			SET @HAS_DATE_RANGE = 0;
		END
		IF @IS_TASK = 1
		BEGIN
			SELECT 
				@HOURS_ALLOWED = JTD.HOURS_ASSIGNED, @START_DATE_TASK = TASK_START_DATE, @DUE_DATE_TASK = JOB_REVISED_DATE
			FROM
				JOB_TRAFFIC_DET JTD
				INNER JOIN ALERT A ON JTD.JOB_NUMBER = A.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = A.TASK_SEQ_NBR 
			WHERE
				A.ALERT_ID = @ALERT_ID AND A.ALERT_LEVEL = 'BRD';
		END
		SET @HOURS_ALLOWED = ISNULL(@HOURS_ALLOWED, 0.00);
		
		IF @START_DATE IS NULL AND @DUE_DATE IS NULL AND @IS_TASK = 1
		BEGIN
			SET @START_DATE = @START_DATE_TASK
			SET @DUE_DATE = @DUE_DATE_TASK

			IF NOT @START_DATE_TASK IS NULL AND NOT @DUE_DATE_TASK IS NULL
			BEGIN
				SET @HAS_DATE_RANGE = 1;
			END

		END
		
		IF @START_DATE IS NULL AND @DUE_DATE IS NOT NULL AND @IS_TASK = 1
		BEGIN
			SET @START_DATE = @START_DATE_TASK
			SET @DUE_DATE = @DUE_DATE_TASK

			IF NOT @START_DATE_TASK IS NULL AND NOT @DUE_DATE_TASK IS NULL
			BEGIN
				SET @HAS_DATE_RANGE = 1;
			END

		END

	END
	
	--	EMPLOYEE HOURS
	BEGIN
		INSERT INTO @WEEKLY_HRS (AlertID, EmployeeCode, FullName, HoursAssigned, Complete)
		SELECT
			@ALERT_ID ALERT_ID,
			A.EMP_CODE,
			ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, ''),
			A.HOURS_ASSIGNED,
			A.COMPLETE
		FROM
			(
				SELECT
					AR.EMP_CODE, 
					ISNULL(SUM(HOURS_ALLOWED), 0.00) AS [HOURS_ASSIGNED],
					0 COMPLETE
				FROM
					ALERT_RCPT AR
				WHERE
					ALERT_ID = @ALERT_ID
					AND AR.CURRENT_NOTIFY = 1
				GROUP BY
					AR.EMP_CODE
				UNION
				SELECT
					AR.EMP_CODE, 
					ISNULL(SUM(HOURS_ALLOWED), 0.00) AS [HOURS_ASSIGNED],
					1 COMPLETE
				FROM
					ALERT_RCPT_DISMISSED AR
				WHERE
					ALERT_ID = @ALERT_ID
					AND AR.CURRENT_NOTIFY = 1
				GROUP BY
				AR.EMP_CODE
				UNION
				SELECT EMP_CODE,
					ISNULL(SUM(HOURS_ALLOWED), 0.00) AS [HOURS_ASSIGNED],
					CASE WHEN TEMP_COMP_DATE is not null then 1
					else 0
					end COMPLETE
				 FROM 
					JOB_TRAFFIC_DET_EMPS
				WHERE JOB_NUMBER = @JOB_NUMBER
					AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
					AND SEQ_NBR = @SEQ_NUMBER
				GROUP BY
					EMP_CODE,TEMP_COMP_DATE
			) AS A
			INNER JOIN EMPLOYEE E ON A.EMP_CODE = E.EMP_CODE;
	END	
	--	HOURS BY WEEK
	BEGIN
		INSERT INTO @ALERT_HOURS_BY_WEEK (EMP_CODE, EMP_HOURS, WEEK_OF)
		SELECT A.EMP_CODE, SUM(A.EMP_HOURS) AS SUM_HOURS, A.WEEK_OF
		FROM
				(
					SELECT ET.EMP_CODE, ETD.EMP_HOURS, DATEADD(DAY, @START_WEEK_ON - DATEPART(WEEKDAY,  ET.EMP_DATE),  ET.EMP_DATE) AS WEEK_OF
					FROM
						EMP_TIME ET
						INNER JOIN EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID
						INNER JOIN @WEEKLY_HRS WH ON ET.EMP_CODE = WH.EmployeeCode
					WHERE
						ET.EMP_CODE = WH.EmployeeCode
						AND WH.AlertID = ETD.ALERT_ID
				) AS A
		GROUP BY
			A.EMP_CODE, A.WEEK_OF;
	END
	--SELECT * FROM @WEEKLY_HRS
	
	BEGIN
		DECLARE @START_DATE_MIN SMALLDATETIME, 
				@DUE_DATE_MAX SMALLDATETIME
		IF @START_DATE IS NULL
		BEGIN
		   SELECT @START_DATE_MIN = MIN(WeekStart) FROM @WEEKLY_HRS;
		END
		ELSE
		BEGIN
		   SET @START_DATE_MIN = @START_DATE;
		END
		IF @DUE_DATE IS NULL
		BEGIN
			SELECT @DUE_DATE_MAX = MAX(WeekEnd) FROM @WEEKLY_HRS;
		END
		ELSE
		BEGIN
		   SET @DUE_DATE_MAX = @DUE_DATE;
		END
	END
	--	WORK DAYS
	--BEGIN
	--	CREATE TABLE #WORK_DAYS ( workyear INT, workdate SMALLDATETIME, holiday BIT, weekend BIT, dayoff BIT )
	--	DECLARE @cur_date SMALLDATETIME, @emp_start_date SMALLDATETIME, @day_count2 INT, @start_year INT, @end_year INT, @cur_year INT
	--	DECLARE @year_start_date SMALLDATETIME, @year_end_date SMALLDATETIME, @holiday BIT, @weekend BIT, @dayoff BIT 
	--	IF ( @START_DATE_MIN IS NOT NULL ) AND ( @DUE_DATE_MAX IS NOT NULL ) AND ( @START_DATE_MIN <= @DUE_DATE_MAX )
	--	BEGIN
	--		-- Create a table holding the average workday by year for each employee		
	--		DECLARE 
	--			@std_hours decimal(9,3);
	--		SET @start_year = DATEPART(yyyy, @START_DATE_MIN);		
	--		SET @end_year = DATEPART(yyyy, @DUE_DATE_MAX);		
	--		SET @cur_year = @start_year;
	--		WHILE ( @cur_year <= @end_year )
	--		BEGIN
	--			SET @day_count2 = 0;
	--			SET @year_start_date = @START_DATE_MIN;
	--			SET @year_end_date = @DUE_DATE_MAX;
	--			SET @cur_date = @year_start_date;			
	--			WHILE ( @cur_date <= @year_end_date )
	--			BEGIN
	--				SET @weekend = 0;
	--				IF (( DATEPART( dw, @cur_date )) IN ( 1, 7 ))
	--				BEGIN
	--					SET @weekend = 1;
	--				END
	--				ELSE
	--				BEGIN
	--					SET @day_count2 = @day_count2 + 1;
	--				END									 
	--				SET @holiday = 0;					
	--				IF ( SELECT COUNT(1) 
	--					   FROM dbo.EMP_NON_TASKS ent 
	--					  WHERE ent.[TYPE] = 'H' 
	--						AND ent.ALL_DAY = 1 
	--						AND ( @cur_date BETWEEN ent.[START_DATE] AND ent.[END_DATE] )) > 0
	--				BEGIN
	--					SELECT @holiday = 1;			
	--				END				
	--				INSERT INTO #WORK_DAYS( workyear, workdate, holiday, weekend ) VALUES ( @cur_year, @cur_date, @holiday, @weekend );				
	--				SET @cur_date = DATEADD(day, 1, @cur_date);
	--			END			
	--			SET @cur_year = @cur_year + 1;
	--		END	
	--	END	

		--SELECT * FROM #WORK_DAYS
	--END
	
	--	STANDARD HOURS
	--SELECT @START_DATE,@DUE_DATE
	--BEGIN
	--	INSERT INTO #EMPLOYEES (EMP_CODE)
	--	SELECT DISTINCT EmployeeCode FROM @WEEKLY_HRS;		

	--	INSERT INTO #EMP_WORK_DAY (EMP_CODE,WORK_DATE)
	--	SELECT DISTINCT EmployeeCode, wd.workdate FROM @WEEKLY_HRS CROSS JOIN #WORK_DAYS wd

	--	UPDATE #EMP_WORK_DAY
	--	SET STD_HRS = ( SELECT CASE DATEPART( dw, WORK_DATE ) 
	--								WHEN 1 THEN e.SUN_HRS
	--								WHEN 2 THEN e.MON_HRS
	--								WHEN 3 THEN e.TUE_HRS
	--								WHEN 4 THEN e.WED_HRS
	--								WHEN 5 THEN e.THU_HRS
	--								WHEN 6 THEN e.FRI_HRS
	--								WHEN 7 THEN e.SAT_HRS
	--							END FROM EMPLOYEE e WHERE e.EMP_CODE = #EMP_WORK_DAY.EMP_CODE)
								
	--	IF @HAS_DATE_RANGE = 1
	--	BEGIN   
	--		--DECLARE
	--		--	@NUM_OF_WEEKS INT
	--		--SELECT @NUM_OF_WEEKS = DATEDIFF(ww, @START_DATE, @DUE_DATE);
	--		--IF @NUM_OF_WEEKS > 0
	--		--BEGIN
	--			UPDATE #EMPLOYEES 
	--			SET TOTAL_WEEK_HRS = (SELECT SUM(ISNULL(STD_HRS,0)) FROM #EMP_WORK_DAY WHERE #EMPLOYEES.EMP_CODE = #EMP_WORK_DAY.EMP_CODE AND #EMP_WORK_DAY.WORK_DATE >= @START_DATE AND #EMP_WORK_DAY.WORK_DATE <= @DUE_DATE )
	--			--FROM
	--			--   EMPLOYEE E
	--			--   INNER JOIN #EMPLOYEES EE ON E.EMP_CODE = EE.EMP_CODE;
	--		--END
	--		--ELSE
	--		--BEGIN
	--		--	PRINT 'GET NUMBER OF DAYS?'
	--		--END
	--	END
	--END
	--SELECT * FROM #EMPLOYEES
	--SELECT * FROM #EMP_WORK_DAY
	DECLARE @EMP_LIST AS VARCHAR(MAX), @JOB INT, @JC SMALLINT, @SEQ_NBR SMALLINT
	SET @EMP_LIST = NULL;
	SELECT @EMP_LIST = COALESCE(@EMP_LIST + ''',', '') + A.EMP_CODE
	FROM   (
			    SELECT DISTINCT  '''' + EMP_CODE AS EMP_CODE
			    FROM ALERT_RCPT WHERE ALERT_ID = @ALERT_ID AND CURRENT_NOTIFY = 1
				UNION
				SELECT DISTINCT '''' + EMP_CODE AS EMP_CODE
			    FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = @ALERT_ID AND CURRENT_NOTIFY = 1
	       ) AS A;
    SET @EMP_LIST = @EMP_LIST + ''''
	--SELECT @EMP_LIST

	IF @EMP_LIST IS NULL AND @IS_TASK = 1
	BEGIN
		SELECT @JOB = JOB_NUMBER, @JC = JOB_COMPONENT_NBR, @SEQ_NBR = TASK_SEQ_NBR
		FROM ALERT
		WHERE ALERT_ID = @ALERT_ID
		SELECT @EMP_LIST = COALESCE(@EMP_LIST + ''',', '') + A.EMP_CODE
		FROM   (
					SELECT DISTINCT  '''' + EMP_CODE AS EMP_CODE
					FROM JOB_TRAFFIC_DET_EMPS WHERE JOB_NUMBER = @JOB AND JOB_COMPONENT_NBR = @JC AND SEQ_NBR = @SEQ_NBR
			   ) AS A;
		SET @EMP_LIST = @EMP_LIST + ''''
	END
	--SELECT @EMP_LIST
	--	NON TASK TIME
	--BEGIN
	--	INSERT INTO #NON_TASK_TIME
	--	SELECT 
	--			[EmployeeCode] = e.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS, 
	--			[WeekNumber] = DATEPART( w, wd.workdate ),
	--			[WorkDate] = wd.workdate,
	--			wd.holiday,
	--			CASE WHEN holiday = 1 THEN CASE DATEPART(dw,wd.workdate)
	--										WHEN 1 THEN (SELECT SUN_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 2 THEN (SELECT MON_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 3 THEN (SELECT TUE_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 4 THEN (SELECT WED_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 5 THEN (SELECT THU_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 6 THEN (SELECT FRI_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										WHEN 7 THEN (SELECT SAT_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
	--										END 
	--								  ELSE 0 END
	--		FROM 
	--			#EMPLOYEES e CROSS JOIN #WORK_DAYS wd;	
	--	UPDATE #NON_TASK_TIME
	--	SET TOTAL_HOURS = ISNULL((SELECT TOP 1 CASE WHEN ALL_DAY = 1 THEN CASE DATEPART(dw,WorkDay)
	--										WHEN 1 THEN (SELECT SUN_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 2 THEN (SELECT MON_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 3 THEN (SELECT TUE_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 4 THEN (SELECT WED_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 5 THEN (SELECT THU_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 6 THEN (SELECT FRI_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										WHEN 7 THEN (SELECT SAT_HRS FROM EMPLOYEE WHERE EMP_CODE = #NON_TASK_TIME.EMP_CODE)
	--										END   
	--								ELSE [HOURS] END
	--					  FROM EMP_NON_TASKS LEFT OUTER JOIN 
	--						   EMP_NON_TASKS_EMPS ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
	--					  WHERE EMP_NON_TASKS_EMPS.EMP_CODE = #NON_TASK_TIME.EMP_CODE
	--						AND WorkDay BETWEEN [START_DATE] AND [END_DATE] AND EMP_NON_TASKS_EMPS.EMP_CODE IN (@EMP_LIST)),0) 
	--	WHERE Holiday = 0;
	--END
	--	HOURS POSTED (TO DATE PRIOR TO WEEK OF DATE)
	BEGIN
		UPDATE @WEEKLY_HRS SET HoursPostedPrior = (SELECT SUM(AH.EMP_HOURS) FROM @ALERT_HOURS_BY_WEEK AH WHERE AH.EMP_CODE = EmployeeCode)
	END
	--	HOURS LEFT
	BEGIN
		UPDATE @WEEKLY_HRS SET HoursLeft = ISNULL(@HOURS_ALLOWED, 0.00) - ISNULL(HoursPostedPrior, 0.00);
	END

	if @SHOW_AVAILABILITY = 1
	BEGIN
		--	HOURS AVAILABLE
		--BEGIN
		--	UPDATE @WEEKLY_HRS
		--	SET HoursAvailableForWeek = TOTAL_WEEK_HRS - (SELECT SUM(TOTAL_HOURS) FROM #NON_TASK_TIME WHERE EmployeeCode = EMP_CODE)
		--	FROM
		--	   #EMPLOYEES E
		--	   INNER JOIN @WEEKLY_HRS WH ON E.EMP_CODE = WH.EmployeeCode;  
		--END
		--	HOURS ASSIGNED	
		--BEGIN
			--IF NOT @START_DATE IS NULL AND NOT @DUE_DATE IS NULL
			--BEGIN
				--UPDATE @WEEKLY_HRS SET HoursAssignedForWeek = A.HRS 
				--FROM
				--	(	 
				--		SELECT 
				--			SUM(SE.HOURS) AS HRS, SE.EMP_CODE, SE.WEEK_START, SE.WEEK_NUM
				--		FROM
				--			SPRINT_EMPLOYEE SE
				--			INNER JOIN #EMPLOYEES E ON SE.EMP_CODE = E.EMP_CODE
				--		GROUP BY
				--			SE.EMP_CODE, WEEK_START, WEEK_NUM
				--	) AS A
				--INNER JOIN @WEEKLY_HRS WH
				--	ON WH.EmployeeCode = A.EMP_CODE AND WH.WeekStart = A.WEEK_START AND WH.WeekNumber = A.WEEK_NUM;

				--UPDATE @WEEKLY_HRS SET	HoursAssignedForWeek = ISNULL(WH.HoursAssignedForWeek, 0) + ISNULL(A.HRS, 0)
				--FROM
				--(
				--	SELECT
				--		AR.EMP_CODE, SUM(AR.HOURS_ALLOWED) AS HRS
				--	FROM
				--		ALERT_RCPT AR WITH(NOLOCK)
				--		INNER JOIN #EMPLOYEES E ON AR.EMP_CODE = E.EMP_CODE
				--		INNER JOIN ALERT A WITH(NOLOCK) ON AR.ALERT_ID = A.ALERT_ID
				--	WHERE
				--		A.[START_DATE] >= @START_DATE
				--		AND A.DUE_DATE <= @DUE_DATE
				--	GROUP BY
				--		AR.EMP_CODE
				--) AS A
				--INNER JOIN @WEEKLY_HRS WH
				--	ON WH.EmployeeCode = A.EMP_CODE;
			--SELECT @START_DATE,@DUE_DATE
			--SELECT @EMP_LIST
			BEGIN
				INSERT INTO #MY_DATA_ASSIGNED  
				EXEC usp_wv_RESOURCES_EMP_ASSIGNED_WEEKLY @EMP_CODE = '', @ROLES = '', @START_DATE = @START_DATE, @END_DATE = @DUE_DATE, @SUMMARY_LEVEL = 1, @DEPTS = '', @EMP_LIST = @EMP_LIST, @UserID = @USER_CODE, @OfficeCode = NULL, @ClientCode = NULL, @DivisionCode = NULL, @ProductCode = NULL, @JobNum = NULL, @JobComp = NULL,  @TaskStatus = NULL, @ExcludeTempComplete ='N', @Manager = NULL, @QUERY_TYPE = NULL, @PSWL_JOB_NUMBER = NULL, @PSWL_JOB_COMPONENT_NBR = NULL, @JC_LIST = NULL, @OVERRIDE_EMP_SEC = 0, @OMIT_BEGINNING_BALANCE = 1;
			END
				
				--SELECT * FROM #MY_DATA_ASSIGNED
				UPDATE @WEEKLY_HRS SET HoursAssignedForWeek = (SELECT SUM(DISTRIBUTED_HRS) FROM #MY_DATA_ASSIGNED  WHERE EmployeeCode = #MY_DATA_ASSIGNED .EMP_CODE)

				UPDATE @WEEKLY_HRS SET HoursAvailableForWeek = (SELECT SUM(HRS_AVAIL) FROM #MY_DATA_ASSIGNED  WHERE EmployeeCode = #MY_DATA_ASSIGNED .EMP_CODE)
	

			--END
		--END
		--	AVAILABLE BALANCE
		BEGIN
		   UPDATE @WEEKLY_HRS 
		   SET HoursBalance = ISNULL(HoursAvailableForWeek, 0.00) - ISNULL(HoursAssignedForWeek, 0.00);
		END
	END

	--	HOURS POSTED THIS WEEK
	BEGIN
		UPDATE @WEEKLY_HRS
		SET HoursPostedThis = ISNULL(HW.EMP_HOURS, 0.00)
		FROM
			@WEEKLY_HRS WH 
			INNER JOIN @ALERT_HOURS_BY_WEEK HW ON WH.EmployeeCode = HW.EMP_CODE;
	END
	--	CLEAN UP
	BEGIN
		DROP TABLE #NON_TASK_TIME;
		--DROP TABLE #WORK_DAYS;
		--DROP TABLE #EMP_WORK_DAY;
	END
	--	RETURN
	BEGIN
		SELECT 
		   [ID] = WH.ID,
		   [AlertID] = ISNULL(WH.AlertID, 0),
		   [SprintDetailID] = ISNULL(WH.SprintDetailID, 0),
		   [SprintEmployeeID] = ISNULL(WH.SprintEmployeeID, 0),
		   [EmployeeCode] = WH.EmployeeCode,
		   [FullName] = WH.FullName,
		   [WeekNumber] = ISNULL(WH.WeekNumber, 0),
		   [WeekStart] = WH.WeekStart,
		   [WeekEnd] = WH.WeekEnd,
		   [HoursAssigned] = ISNULL(WH.HoursAssigned, 0.00),
		   [HoursAvailableForWeek] = ISNULL(WH.HoursAvailableForWeek, 0.00),
		   [HoursAssignedForWeek] = ISNULL(WH.HoursAssignedForWeek, 0.00),
		   [HoursBalance] = ISNULL(WH.HoursBalance, 0.00),
		   [HoursPostedTotal] = ISNULL(WH.HoursPostedTotal, 0.00),
		   [HoursPostedPrior] = ISNULL(WH.HoursPostedPrior, 0.00),
		   [HoursPostedThis] = ISNULL(WH.HoursPostedThis, 0.00),
		   [HoursLeft] = ISNULL(WH.HoursLeft, 0.00),
		   [Complete] = ISNULL(WH.Complete,0)
		FROM
		   @WEEKLY_HRS WH --WHERE WH.WeekStart is not null
		ORDER BY
		   WH.WeekStart, WH.FullName;
	END
END
/*=========== QUERY ===========*/


GO


