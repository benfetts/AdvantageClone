if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_RESOURCES_EMP_FINDER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_RESOURCES_EMP_FINDER]
GO

CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_EMP_FINDER] 
    @JOB_NUMBER         AS INT,
    @JOB_COMPONENT_NBR  AS SMALLINT,
    @TASK_TYPE          AS SMALLINT,	-- 0 = EVENT TASKS, 1 = PROJECT SCHEDULE (TRAFFIC) TASKS, 2 = EVENT TASKS COMING FROM EVENT TASK SCHEDULER
    @TRF_ROLE_CODE      AS VARCHAR(10),
    @START_DATE			AS SMALLDATETIME,
    @END_DATE	        AS SMALLDATETIME,
	@SAVE_FOUND_EMPLOYEES AS TINYINT,
	@UserCode varchar(100)
AS

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CDE AS varchar(6)

SELECT @EMP_CDE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserCode)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE


--        IF @TASK_TYPE = 0
--        BEGIN
--        	
--        END
--        IF @TASK_TYPE = 1
--        BEGIN
--        	
--        END
--        IF @TASK_TYPE = 2
--        BEGIN
--        	
--        END



         /* OBJECTIVES:
        *  1. GET EVENTS (AND TRAFFIC TASKS?)
        *  2. GET EMPLOYEES THAT ARE AVAILABLE
        *  3. ASSIGN BASED ON ROLE OF TASK	
        */
        
        

        DECLARE @MIN_DATE  AS SMALLDATETIME,
                @MAX_DATE  AS SMALLDATETIME,
                @S_TRF_ROLE_CODE AS VARCHAR(15) 

        SET @S_TRF_ROLE_CODE = ''''+@TRF_ROLE_CODE+'''';
               	
                --HOLD EMPLOYEE DATA:
        CREATE TABLE #EMP_AVAILABILITY
        (
	        [ROW_ID]                     INT NOT NULL,
	        [EMP_CODE]                   VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	        [S_DAY_OF_WEEK]              VARCHAR(3) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [EMP_DEF_TRF_ROLE]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [EMP_SENIORITY]              SMALLINT,
	        [EMP_START_TIME]             SMALLDATETIME NULL,
	        [EMP_END_TIME]               SMALLDATETIME NULL,
	        --[EMP_START_TIME_SUN]         SMALLDATETIME,
	        --[EMP_END_TIME_SUN]           SMALLDATETIME,
	        --[EMP_START_TIME_MON]         SMALLDATETIME,
	        --[EMP_END_TIME_MON]           SMALLDATETIME,
	        --[EMP_START_TIME_TUE]         SMALLDATETIME,
	        --[EMP_END_TIME_TUE]           SMALLDATETIME,
	        --[EMP_START_TIME_WED]         SMALLDATETIME,
	        --[EMP_END_TIME_WED]           SMALLDATETIME,
	        --[EMP_START_TIME_THU]         SMALLDATETIME,
	        --[EMP_END_TIME_THU]           SMALLDATETIME,
	        --[EMP_START_TIME_FRI]         SMALLDATETIME,
	        --[EMP_END_TIME_FRI]           SMALLDATETIME,
	        --[EMP_START_TIME_SAT]         SMALLDATETIME,
	        --[EMP_END_TIME_SAT]           SMALLDATETIME,
	        [EMP_DIRECT_HRS_GOAL_PERC]   DECIMAL(18, 6) NULL,
	        [DATE]                       SMALLDATETIME NOT NULL,
	        [DAY_OF_WEEK]                INT NOT NULL,
	        [DAY_OF_YEAR]                INT NOT NULL,
	        [WEEK_OF_YEAR]               SMALLDATETIME NOT NULL,
	        [MONTH_OF_YEAR]              INT NOT NULL,
	        [YEAR]                       INT NOT NULL,
	        [STD_HRS_AVAIL]              DECIMAL(18, 6) NULL,
	        [EMP_DIRECT_HRS_GOAL_HOURS]  DECIMAL(18, 6) NULL,
	        [HRS_USED_NON_TASK]          DECIMAL(18, 6) NULL,
	        [HRS_AVAIL]                  DECIMAL(18, 6) NULL,
	        [HRS_ASSIGNED_TASK]          DECIMAL(18, 6) NULL,
	        [HRS_ASSIGNED_ASSIGN]          DECIMAL(18, 6) NULL,
	        [HRS_ASSIGNED_EVENT]         DECIMAL(18, 6) NULL,
	        [HRS_BALANCE_AVAIL]          DECIMAL(18, 6) NULL,
	        [NOTE]                       VARCHAR(100) COLLATE SQL_Latin1_General_CP1_CS_AS  NULL,
	        [IS_FULL_DAY_OFF]            BIT,
	        [HAS_TIME_CONFLICT]          BIT,
	        [IS_FIRST_CHOICE]            BIT,
			[HRS_APPTS]			 DECIMAL(18,6)
        );

                --MASTER TABLE TO RETURN:
                --CALC HOURS!?!
        CREATE TABLE #TASKS_AND_EVENTS
        (
	        [ROW_ID]                    INT IDENTITY(1, 1) NOT NULL,
	        [JOB_NUMBER]                INT NULL,
	        [JOB_COMPONENT_NBR]         SMALLINT NULL,
	        [SEQ_NBR]                   SMALLINT NULL,
	        [EVENT_TASK_ID]             INT NULL,
	        [EVENT_TASK_DESC]           VARCHAR(100)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [EVENT_ID]                  INT NULL,
	        [EVENT_TASK_HOURS_ALLOWED]  DECIMAL(15, 2) NULL,
	        [TRF_TASK_CODE]             VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [TRF_TASK_DESC]             VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [TRF_ROLE_CODE]             VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [TRF_ROLE_DESC]             VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [IS_EVENT_TASK]             BIT NOT NULL,
	        [START_DATE]                SMALLDATETIME NULL,
	        [END_DATE]                  SMALLDATETIME NULL,
	        [START_TIME]                SMALLDATETIME NULL,
	        [END_TIME]                  SMALLDATETIME NULL,
	        [EMP_CODE_FIRST_CHOICE]     VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS  NULL,
	        [EMP_SENIORITY]             SMALLINT NULL,
	        [CURR_EMP_CODE]             VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS  NULL,
	        [HAS_EMP_ASSIGNED]          SMALLINT NULL,
	        [TOTAL_WORK_DAYS]           INT NULL,
	        [HRS_PER_DAY]               DECIMAL(18, 2)
        );
        		
		        --THIS WILL HOLD TASKS AND EVENTS FOR THE SAME EMPS IN SAME DATE RANGE
		        --NEED THIS TO MAKE SURE TASK/EVENTS DON'T CONFLICT WITHOUT COMPARING ENTIRE EVENT_TASKS TABLE...?
        CREATE TABLE #OTHER_TASKS_AND_EVENTS
        (
	        [ROW_ID]                    INT IDENTITY(1, 1) NOT NULL,
	        [JOB_NUMBER]                INT NULL,
	        [JOB_COMPONENT_NBR]         SMALLINT NULL,
	        [SEQ_NBR]                   SMALLINT NULL,
	        [EVENT_TASK_ID]             INT NULL,
	        [EVENT_ID]                  INT NULL,
	        [EVENT_TASK_HOURS_ALLOWED]  DECIMAL(15, 2) NULL,
	        [TRF_TASK_CODE]             VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [TRF_ROLE_CODE]             VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	        [IS_EVENT_TASK]             BIT NOT NULL,
	        [START_DATE]                SMALLDATETIME NULL,
	        [END_DATE]                  SMALLDATETIME NULL,
	        [START_TIME]                SMALLDATETIME NULL,
	        [END_TIME]                  SMALLDATETIME NULL,
	        [EMP_CODE]                  VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS  NULL,
	        [EMP_SENIORITY]             SMALLINT NULL
        );
                
                --HOLD THE "NON FIRST CHOICE" EMPLOYEES:
        CREATE TABLE #OTHER_TASK_EMPS
        (
	        [JOB_NUMBER]                INT NULL,
	        [JOB_COMPONENT_NBR]         SMALLINT NULL,
	        [SEQ_NBR]                   SMALLINT NULL,
	        [EVENT_TASK_ID]              INT NULL,
	        [EMP_CODE]                   VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS  NOT NULL,
	        [EMP_SENIORITY]              SMALLINT,
	        [EMP_START_TIME]             SMALLDATETIME NULL,
	        [EMP_END_TIME]               SMALLDATETIME NULL,
	        [EMP_START_TIME_SUN]         SMALLDATETIME,
	        [EMP_END_TIME_SUN]           SMALLDATETIME,
	        [EMP_START_TIME_MON]         SMALLDATETIME,
	        [EMP_END_TIME_MON]           SMALLDATETIME,
	        [EMP_START_TIME_TUE]         SMALLDATETIME,
	        [EMP_END_TIME_TUE]           SMALLDATETIME,
	        [EMP_START_TIME_WED]         SMALLDATETIME,
	        [EMP_END_TIME_WED]           SMALLDATETIME,
	        [EMP_START_TIME_THU]         SMALLDATETIME,
	        [EMP_END_TIME_THU]           SMALLDATETIME,
	        [EMP_START_TIME_FRI]         SMALLDATETIME,
	        [EMP_END_TIME_FRI]           SMALLDATETIME,
	        [EMP_START_TIME_SAT]         SMALLDATETIME,
	        [EMP_END_TIME_SAT]           SMALLDATETIME,
	        [EMP_DIRECT_HRS_GOAL_PERC]   DECIMAL(18, 6) NULL,
	        [STD_HRS_AVAIL]              DECIMAL(18, 6) NULL,
	        [EMP_DIRECT_HRS_GOAL_HOURS]  DECIMAL(18, 6) NULL,
	        [HRS_USED_NON_TASK]          DECIMAL(18, 6) NULL,
	        [HRS_AVAIL]                  DECIMAL(18, 6) NULL,
	        [HRS_ASSIGNED_TASK]          DECIMAL(18, 6) NULL,
	        [HRS_BALANCE_AVAIL]          DECIMAL(18, 6) NULL,
	        [TOTAL_HRS_BALANCE_AVAIL]          DECIMAL(18, 6) NULL,
	        [HAS_TIME_CONFLICT]          BIT,
	        [IS_FIRST_CHOICE]            BIT
        );


        --NEED TO RESTRICT THESE TO ROLE CODE TOO!!??
        IF @TASK_TYPE = 0
        BEGIN
            SELECT @MIN_DATE = MIN(EVENT_TASK.START_TIME),
                   @MAX_DATE = MAX(EVENT_TASK.END_TIME)
            FROM   EVENT_TASK WITH (NOLOCK)
                   INNER JOIN EVENT WITH (NOLOCK)
                        ON  EVENT_TASK.EVENT_ID = EVENT.EVENT_ID
                   INNER JOIN TASK_TRAFFIC_ROLE WITH (NOLOCK)
                        ON  EVENT_TASK.TASK_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            WHERE  (EVENT.JOB_NUMBER = @JOB_NUMBER)
                   AND (EVENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
                   AND (EVENT_TASK.EMP_CODE IS NULL)
                   AND (TASK_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS );
        END

        IF @TASK_TYPE = 1
        BEGIN
            SELECT @MIN_DATE = MIN(JOB_TRAFFIC_DET.TASK_START_DATE),
                   @MAX_DATE = MAX(JOB_TRAFFIC_DET.JOB_REVISED_DATE)
            FROM   JOB_TRAFFIC_DET
                   INNER JOIN TASK_TRAFFIC_ROLE
                        ON  JOB_TRAFFIC_DET.FNC_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
                   LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS
                        ON  JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER
                            AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR
                            AND JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
            WHERE  (JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER)
                   AND (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
                   AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE IS NULL)
                   AND 1 = CASE WHEN @TRF_ROLE_CODE <> '' AND (TASK_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) THEN 1
				                WHEN @TRF_ROLE_CODE = '' THEN 1 END;
        END
        
        IF @TASK_TYPE = 2
        BEGIN
        	SET @MIN_DATE = @START_DATE;
        	SET @MAX_DATE = @END_DATE;
        END
                               
        SET @MIN_DATE = CONVERT(
                DATETIME,
                CONVERT(CHAR(10), DATEPART(yyyy, @MIN_DATE), 101) 
                +
                '-' +
                CONVERT(CHAR(10), DATEPART(mm, @MIN_DATE), 101) +
                '-' +
                CONVERT(CHAR(10), DATEPART(dd, @MIN_DATE), 101) +
                ' 00:00:00'
            );
        SET @MAX_DATE = CONVERT(
                DATETIME,
                CONVERT(CHAR(10), DATEPART(yyyy, @MAX_DATE), 101) 
                +
                '-' +
                CONVERT(CHAR(10), DATEPART(mm, @MAX_DATE), 101) +
                '-' +
                CONVERT(CHAR(10), DATEPART(dd, @MAX_DATE), 101) +
                ' 23:59:59'
            );
        --		               
        
        --SELECT @MIN_DATE AS MIN_DATE, @MAX_DATE AS MAX_DATE	               
                --GET EVENT TASKS THAT NEED EMPS:
        IF @TASK_TYPE = 0
        BEGIN
            INSERT INTO #TASKS_AND_EVENTS
              (
                EVENT_TASK_ID,
                EVENT_ID,
                EVENT_TASK_HOURS_ALLOWED,
                TRF_TASK_CODE,
                IS_EVENT_TASK,
                [START_DATE],
                END_DATE,
                START_TIME,
                END_TIME,
                TRF_ROLE_CODE,
                JOB_NUMBER,
                JOB_COMPONENT_NBR,
                EVENT_TASK_DESC,
                CURR_EMP_CODE
              )
            SELECT EVENT_TASK.EVENT_TASK_ID,
                   EVENT_TASK.EVENT_ID,
                   EVENT_TASK.HOURS_ALLOWED,
                   EVENT_TASK.TASK_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ,
                   1,
                   EVENT_TASK.START_DATE,
                   EVENT_TASK.END_DATE,
                   EVENT_TASK.START_TIME,
                   EVENT_TASK.END_TIME,
                   NULL,
                   @JOB_NUMBER,
                   @JOB_COMPONENT_NBR,
                   EVENT.EVENT_LABEL,
                   EVENT_TASK.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            FROM   EVENT WITH (NOLOCK)
                   INNER JOIN EVENT_TASK WITH (NOLOCK)
                        ON  EVENT.EVENT_ID = EVENT_TASK.EVENT_ID
                   INNER JOIN TASK_TRAFFIC_ROLE WITH (NOLOCK)
                        ON  EVENT_TASK.TASK_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            WHERE  (EVENT.JOB_NUMBER = @JOB_NUMBER)
                   AND (EVENT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
                   AND (TASK_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS )
        END
        --
        IF @TASK_TYPE = 1
        BEGIN
            INSERT INTO #TASKS_AND_EVENTS
            SELECT DISTINCT JOB_TRAFFIC_DET.JOB_NUMBER,
                   JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
                   JOB_TRAFFIC_DET.SEQ_NBR,
                   NULL,
                   NULL,
                   NULL,
                   JOB_TRAFFIC_DET.JOB_HRS,
                   JOB_TRAFFIC_DET.FNC_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ,
                   JOB_TRAFFIC_DET.TASK_DESCRIPTION,
                   TASK_TRAFFIC_ROLE.ROLE_CODE,
                   NULL,
                   0,
                   JOB_TRAFFIC_DET.TASK_START_DATE,
                   JOB_TRAFFIC_DET.JOB_REVISED_DATE,
                   JOB_TRAFFIC_DET.TASK_START_DATE,
                   JOB_TRAFFIC_DET.JOB_REVISED_DATE,
                   NULL,
                   NULL,
                   NULL,
                   NULL,
                   NULL,
                   NULL
            FROM   JOB_TRAFFIC_DET
                   LEFT OUTER JOIN TASK_TRAFFIC_ROLE
                        ON  JOB_TRAFFIC_DET.FNC_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
                   LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS
                        ON  JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER
                            AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR
                            AND JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR
            WHERE  (JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER)
                   AND (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
                   AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  IS NULL)
                   AND 1 = CASE WHEN @TRF_ROLE_CODE <> '' AND (TASK_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) THEN 1
				                WHEN @TRF_ROLE_CODE = '' THEN 1 END;
        END
        --SELECT * FROM #TASKS_AND_EVENTS
        IF @TASK_TYPE = 2
        BEGIN
            INSERT INTO #TASKS_AND_EVENTS
              (
                EVENT_TASK_ID,
                EVENT_ID,
                EVENT_TASK_HOURS_ALLOWED,
                TRF_TASK_CODE,
                IS_EVENT_TASK,
                [START_DATE],
                END_DATE,
                START_TIME,
                END_TIME,
                TRF_ROLE_CODE,
                JOB_NUMBER,
                JOB_COMPONENT_NBR,
                EVENT_TASK_DESC,
                CURR_EMP_CODE
              )
            SELECT EVENT_TASK.EVENT_TASK_ID,
                   EVENT_TASK.EVENT_ID,
                   EVENT_TASK.HOURS_ALLOWED,
                   EVENT_TASK.TASK_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ,
                   1,
                   EVENT_TASK.START_DATE,
                   EVENT_TASK.END_DATE,
                   EVENT_TASK.START_TIME,
                   EVENT_TASK.END_TIME,
                   NULL,
                   @JOB_NUMBER,
                   @JOB_COMPONENT_NBR,
                   EVENT.EVENT_LABEL,
                   EVENT_TASK.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            FROM   EVENT WITH (NOLOCK)
                   INNER JOIN EVENT_TASK WITH (NOLOCK)
                        ON  EVENT.EVENT_ID = EVENT_TASK.EVENT_ID
                   INNER JOIN TASK_TRAFFIC_ROLE WITH (NOLOCK)
                        ON  EVENT_TASK.TASK_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            WHERE  (EVENT.EVENT_DATE BETWEEN @MIN_DATE AND @MAX_DATE)
                   AND (TASK_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS )
        END
		
		if @TRF_ROLE_CODE = ''
		BEGIN
			SELECT @S_TRF_ROLE_CODE = NULL
		END
        
        --	
        --SELECT @MIN_DATE, @MAX_DATE, @TRF_ROLE_CODE	
        --    --GET EMPLOYEES:
        INSERT INTO #EMP_AVAILABILITY
          (
            [ROW_ID],
            [EMP_CODE],
            [S_DAY_OF_WEEK],
            [EMP_START_TIME],
            [EMP_END_TIME],
            --[EMP_START_TIME_SUN],
            --[EMP_END_TIME_SUN],
            --[EMP_START_TIME_MON],
            --[EMP_END_TIME_MON],
            --[EMP_START_TIME_TUE],
            --[EMP_END_TIME_TUE],
            --[EMP_START_TIME_WED],
            --[EMP_END_TIME_WED],
            --[EMP_START_TIME_THU],
            --[EMP_END_TIME_THU],
            --[EMP_START_TIME_FRI],
            --[EMP_END_TIME_FRI],
            --[EMP_START_TIME_SAT],
            --[EMP_END_TIME_SAT],
            [EMP_DIRECT_HRS_GOAL_PERC],
            [DATE],
            [DAY_OF_WEEK],
            [DAY_OF_YEAR],
            [WEEK_OF_YEAR],
            [MONTH_OF_YEAR],
            [YEAR],
            [STD_HRS_AVAIL],
            [EMP_DIRECT_HRS_GOAL_HOURS],
            [HRS_USED_NON_TASK],
            [HRS_AVAIL],
            [HRS_ASSIGNED_TASK],
			[HRS_ASSIGNED_ASSIGN],
			[HRS_APPTS],
            [HRS_ASSIGNED_EVENT],
            [HRS_BALANCE_AVAIL],
            [NOTE],
            [IS_FULL_DAY_OFF],
            [IS_FIRST_CHOICE]
          )
        EXEC usp_wv_RESOURCES_EMP_AVAILABILITY @EMP_CODE='', @ROLES=@S_TRF_ROLE_CODE,@START_DATE=@MIN_DATE,@END_DATE=@MAX_DATE,@SUMMARY_LEVEL=0,@DEPTS=NULL,@EMP_LIST=NULL, @UserID=NULL,
									@OfficeCode=NULL,
									@ClientCode=NULL,
									@DivisionCode=NULL,
									@ProductCode=NULL,
									@JobNum=NULL,
									@JobComp=NULL,
									@TaskStatus=NULL,
									@ExcludeTempComplete='N',
									@Manager=NULL,
									@QUERY_TYPE=NULL,
									@PSWL_JOB_NUMBER=NULL,
									@PSWL_JOB_COMPONENT_NBR=NULL,
									@JC_LIST=NULL,
									@OVERRIDE_EMP_SEC=0;
        --    
		
        --UPDATE EXISTING DATA
        UPDATE #EMP_AVAILABILITY
        SET 
	        #EMP_AVAILABILITY.EMP_SENIORITY = EMPLOYEE.SENIORITY,
	        #EMP_AVAILABILITY.EMP_START_TIME = EMPLOYEE.EMP_START_TIME,
	        #EMP_AVAILABILITY.EMP_END_TIME = EMPLOYEE.EMP_END_TIME
	        --#EMP_AVAILABILITY.EMP_START_TIME_SUN = EMPLOYEE.EMP_START_TIME_SUN,
	        --#EMP_AVAILABILITY.EMP_END_TIME_SUN = EMPLOYEE.EMP_END_TIME_SUN,
	        --#EMP_AVAILABILITY.EMP_START_TIME_MON = EMPLOYEE.EMP_START_TIME_MON,
	        --#EMP_AVAILABILITY.EMP_END_TIME_MON = EMPLOYEE.EMP_END_TIME_MON,
	        --#EMP_AVAILABILITY.EMP_START_TIME_TUE = EMPLOYEE.EMP_START_TIME_TUE,
	        --#EMP_AVAILABILITY.EMP_END_TIME_TUE = EMPLOYEE.EMP_END_TIME_TUE,
	        --#EMP_AVAILABILITY.EMP_START_TIME_WED = EMPLOYEE.EMP_START_TIME_WED,
	        --#EMP_AVAILABILITY.EMP_END_TIME_WED = EMPLOYEE.EMP_END_TIME_WED,
	        --#EMP_AVAILABILITY.EMP_START_TIME_THU = EMPLOYEE.EMP_START_TIME_THU,
	        --#EMP_AVAILABILITY.EMP_END_TIME_THU = EMPLOYEE.EMP_END_TIME_THU,
	        --#EMP_AVAILABILITY.EMP_START_TIME_FRI = EMPLOYEE.EMP_START_TIME_FRI,
	        --#EMP_AVAILABILITY.EMP_END_TIME_FRI = EMPLOYEE.EMP_END_TIME_FRI,
	        --#EMP_AVAILABILITY.EMP_START_TIME_SAT = EMPLOYEE.EMP_START_TIME_SAT,
	        --#EMP_AVAILABILITY.EMP_END_TIME_SAT = EMPLOYEE.EMP_END_TIME_SAT
        FROM 
	        #EMP_AVAILABILITY INNER JOIN EMPLOYEE ON #EMP_AVAILABILITY.EMP_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = EMPLOYEE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ;

        
		--SELECT * FROM #EMP_AVAILABILITY;


        IF @TASK_TYPE = 0 OR @TASK_TYPE = 2
        BEGIN
            --GET EVENT TASKS TO CHECK CONFLICT:
            INSERT INTO #OTHER_TASKS_AND_EVENTS
              (
                EVENT_TASK_ID,
                EVENT_ID,
                EVENT_TASK_HOURS_ALLOWED,
                TRF_TASK_CODE,
                IS_EVENT_TASK,
                [START_DATE],
                END_DATE,
                START_TIME,
                END_TIME,
                TRF_ROLE_CODE,
                JOB_NUMBER,
                JOB_COMPONENT_NBR,
                EMP_CODE
              )
            SELECT EVENT_TASK.EVENT_TASK_ID,
                   EVENT_TASK.EVENT_ID,
                   EVENT_TASK.HOURS_ALLOWED,
                   EVENT_TASK.TASK_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ,
                   1,
                   EVENT_TASK.START_DATE,
                   EVENT_TASK.END_DATE,
                   EVENT_TASK.START_TIME,
                   EVENT_TASK.END_TIME,
                   NULL,
                   EVENT.JOB_NUMBER,
                   EVENT.JOB_COMPONENT_NBR,
                   EVENT_TASK.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
            FROM   EVENT WITH (NOLOCK)
                   INNER JOIN EVENT_TASK WITH (NOLOCK)
                        ON  EVENT.EVENT_ID = EVENT_TASK.EVENT_ID
            WHERE
			--  CONVERT(VARCHAR(100), EVENT.JOB_NUMBER) + '|' + CONVERT(VARCHAR(100), EVENT.JOB_COMPONENT_NBR) 
            --       <> CONVERT(VARCHAR(100), @JOB_NUMBER) + '|' + CONVERT(VARCHAR(100), @JOB_COMPONENT_NBR)
                   --AND
				    (NOT EVENT_TASK.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  IS NULL)
                   AND EVENT_TASK.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  IN (SELECT 
                                                                                            DISTINCT 
                                                                                            EMP_CODE 
                                                                                            COLLATE 
                                                                                            SQL_Latin1_General_CP1_CS_AS
                                                                                     FROM   
                                                                                            #EMP_AVAILABILITY)
                   AND EVENT_TASK.[START_TIME] >= @MIN_DATE
                   AND EVENT_TASK.[END_TIME] <= @MAX_DATE;
            
            UPDATE #OTHER_TASKS_AND_EVENTS
            SET    START_DATE = CONVERT(
                       DATETIME,
                       CONVERT(CHAR(10), DATEPART(yyyy, START_DATE), 101) 
                       +
                       '-' +
                       CONVERT(CHAR(10), DATEPART(mm, START_DATE), 101) +
                       '-' +
                       CONVERT(CHAR(10), DATEPART(dd, START_DATE), 101) +
                       ' 00:00:00'
                   ),
                   END_DATE = CONVERT(
                       DATETIME,
                       CONVERT(CHAR(10), DATEPART(yyyy, END_DATE), 101) 
                       +
                       '-' +
                       CONVERT(CHAR(10), DATEPART(mm, END_DATE), 101) +
                       '-' +
                       CONVERT(CHAR(10), DATEPART(dd, END_DATE), 101) +
                       ' 23:59:59'
                   );
        END
        IF @TASK_TYPE = 1 --NEED TO CALC,DON'T HAVE AN EMP, SO NEED TO JUST GET BASED ON NUM DAYS AND HOURS
        BEGIN
	        UPDATE #TASKS_AND_EVENTS SET HRS_PER_DAY = 
	        CASE 
		        WHEN DATEDIFF(dd,START_DATE,END_DATE) > 0 THEN EVENT_TASK_HOURS_ALLOWED / DATEDIFF(dd,START_DATE,END_DATE)
		        ELSE 0
	        END	
	        FROM #TASKS_AND_EVENTS;
        END

		--SELECT * FROM #TASKS_AND_EVENTS

        --GET EMPS
                --START THE ACTUAL SELECTION OF EMPS:
                --don't need "fully available" like resource finder because we are going one job at a time, one day at a time...

                --1. UPDATE BY GETTING HIGHEST PRIORITY:
		                /*
		                * LOOP THROUGH EACH TASK
		                */
		                DECLARE @ROW_ID                   AS INT,
						        @ROW_EVENT_TASK_ID			AS INT,
				                @ROW_DATE                 AS DATETIME,
				                @ROW_TRF_ROLE AS VARCHAR(6) ,
				                @ROW_START_TIME AS DATETIME,
				                @ROW_END_TIME AS DATETIME,
				                @ROW_HRS_PER_DAY AS DECIMAL(18,6),
				                @THIS_EMP VARCHAR(6),
        --				        @ROW_JOB_NUMBER AS INT,
        --				        @ROW_JOB_COMPONENT_NBR AS SMALLINT,
				                @ROW_SEQ_NBR AS INT,
				                @ROW_START_DATE AS DATETIME,
				                @ROW_END_DATE AS DATETIME

                		        	
		                DECLARE MY_ROWS                         CURSOR  
		                FOR
			                SELECT ROW_ID
			                FROM   #TASKS_AND_EVENTS
		                ;

						                OPEN MY_ROWS;
							                FETCH NEXT FROM MY_ROWS INTO @ROW_ID;
		                WHILE @@FETCH_STATUS = 0
		                BEGIN
			                --SET VARIABLES:
			                SELECT 
						        @ROW_EVENT_TASK_ID = EVENT_TASK_ID,@ROW_DATE = START_DATE, @ROW_TRF_ROLE = TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS , @ROW_START_TIME = START_TIME, 
						        @ROW_END_TIME = END_TIME, @ROW_HRS_PER_DAY = HRS_PER_DAY,
        --						@ROW_JOB_NUMBER = JOB_NUMBER,
        --						@ROW_JOB_COMPONENT_NBR = JOB_COMPONENT_NBR,
								@ROW_START_DATE = [START_DATE],
								@ROW_END_DATE = END_DATE,
						        @ROW_SEQ_NBR = SEQ_NBR
			                FROM   #TASKS_AND_EVENTS
			                WHERE  ROW_ID = @ROW_ID
			                ;
        			       
        			        --SELECT @ROW_TRF_ROLE
			                IF @TASK_TYPE = 0 OR @TASK_TYPE = 2
					        BEGIN
							 --FULL BEST EMP BASED ON SENIORITY:
								if @OfficeRestrictions > 0
								Begin
									UPDATE #TASKS_AND_EVENTS SET #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE = A.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS , 
							        #TASKS_AND_EVENTS.EMP_SENIORITY = A.EMP_SENIORITY 
							        FROM
							        (
								        SELECT 
									        TOP 1 #EMP_AVAILABILITY.EMP_CODE, #EMP_AVAILABILITY.EMP_SENIORITY 
								        FROM         
									        #EMP_AVAILABILITY INNER JOIN 
									        EMP_TRAFFIC_ROLE WITH(NOLOCK) ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        EMPLOYEE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMPLOYEE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        TASK_TRAFFIC_ROLE WITH(NOLOCK) ON EMP_TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = TASK_TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        #TASKS_AND_EVENTS ON TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = #TASKS_AND_EVENTS.TRF_TASK_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
												EMP_OFFICE ON EMPLOYEE.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = EMP_OFFICE.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS AND EMP_OFFICE.EMP_CODE = @EMP_CDE
								        WHERE 
									        [DATE] = @ROW_DATE
									        AND #TASKS_AND_EVENTS.EVENT_TASK_ID = @ROW_EVENT_TASK_ID
									        AND #EMP_AVAILABILITY.HRS_BALANCE_AVAIL > 0
									        --MAKE SURE IT IS WITHIN THE EMP'S WORKING HOURS:
									        --right now, it just makes sure the start time is within range...
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_START_TIME,0) >= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_START_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_START_TIME IS NULL)
									        )
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_START_TIME,0) <= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_END_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_END_TIME IS NULL)
									        )
									        --this might need to make sure the end time is also within range?
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_END_TIME,0) <= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_END_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_START_TIME IS NULL)
									        )
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_END_TIME,0) >= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_START_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_END_TIME IS NULL)
									        )
									        --MAKE SURE DOESN'T CONFLICT WITH EXISTING EVENT TASK:
									        AND #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  NOT IN (
										        SELECT 
											        DISTINCT EMP_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS 
										        FROM 
											        #OTHER_TASKS_AND_EVENTS
										        WHERE 
											        (#OTHER_TASKS_AND_EVENTS.START_TIME BETWEEN @ROW_START_TIME AND @ROW_END_TIME)
											        OR
											        (#OTHER_TASKS_AND_EVENTS.END_TIME BETWEEN @ROW_START_TIME AND @ROW_END_TIME)
										        )
								        ORDER BY #EMP_AVAILABILITY.EMP_SENIORITY
							        ) AS A	
							        WHERE #TASKS_AND_EVENTS.EVENT_TASK_ID = @ROW_EVENT_TASK_ID;
    						        SELECT @THIS_EMP = EMP_CODE_FIRST_CHOICE COLLATE SQL_Latin1_General_CP1_CS_AS  FROM #TASKS_AND_EVENTS WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;

        					        
							        --PUT THE OTHERS INTO THE "SECONDARY EMPS" TABLE:
							        INSERT INTO #OTHER_TASK_EMPS (EVENT_TASK_ID,EMP_CODE,EMP_SENIORITY,EMP_START_TIME,EMP_END_TIME,EMP_DIRECT_HRS_GOAL_PERC,STD_HRS_AVAIL,EMP_DIRECT_HRS_GOAL_HOURS,HRS_USED_NON_TASK,HRS_AVAIL,HRS_ASSIGNED_TASK,HRS_BALANCE_AVAIL)
							        SELECT @ROW_EVENT_TASK_ID,#EMP_AVAILABILITY.EMP_CODE,EMP_SENIORITY,#EMP_AVAILABILITY.EMP_START_TIME,#EMP_AVAILABILITY.EMP_END_TIME,EMP_DIRECT_HRS_GOAL_PERC,STD_HRS_AVAIL,EMP_DIRECT_HRS_GOAL_HOURS,HRS_USED_NON_TASK,HRS_AVAIL,HRS_ASSIGNED_TASK,HRS_BALANCE_AVAIL
							        FROM #EMP_AVAILABILITY INNER JOIN
							          EMP_TRAFFIC_ROLE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
										 EMPLOYEE E ON E.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
										 EMP_OFFICE ON E.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = EMP_OFFICE.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS AND EMP_OFFICE.EMP_CODE = @EMP_CDE  
							        WHERE [DATE] = @ROW_DATE
							        AND 1 = CASE WHEN @TRF_ROLE_CODE <> '' AND (EMP_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) THEN 1
												 WHEN @TRF_ROLE_CODE = '' THEN 1 END;
								End
								Else
								Begin
									UPDATE #TASKS_AND_EVENTS SET #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE = A.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS , 
							        #TASKS_AND_EVENTS.EMP_SENIORITY = A.EMP_SENIORITY 
							        FROM
							        (
								        SELECT 
									        TOP 1 #EMP_AVAILABILITY.EMP_CODE, #EMP_AVAILABILITY.EMP_SENIORITY 
								        FROM         
									        #EMP_AVAILABILITY INNER JOIN 
									        EMP_TRAFFIC_ROLE WITH(NOLOCK) ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        EMPLOYEE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMPLOYEE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        TASK_TRAFFIC_ROLE WITH(NOLOCK) ON EMP_TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = TASK_TRAFFIC_ROLE.ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  INNER JOIN
									        #TASKS_AND_EVENTS ON TASK_TRAFFIC_ROLE.TRF_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = #TASKS_AND_EVENTS.TRF_TASK_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
								        WHERE 
									        [DATE] = @ROW_DATE
									        AND #TASKS_AND_EVENTS.EVENT_TASK_ID = @ROW_EVENT_TASK_ID
									        AND #EMP_AVAILABILITY.HRS_BALANCE_AVAIL > 0
									        --MAKE SURE IT IS WITHIN THE EMP'S WORKING HOURS:
									        --right now, it just makes sure the start time is within range...
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_START_TIME,0) >= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_START_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_START_TIME IS NULL)
									        )
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_START_TIME,0) <= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_END_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_END_TIME IS NULL)
									        )
									        --this might need to make sure the end time is also within range?
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_END_TIME,0) <= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_END_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_START_TIME IS NULL)
									        )
									        AND 
									        (
										        [dbo].[wvfn_timeserial](@ROW_END_TIME,0) >= [dbo].[wvfn_timeserial](#EMP_AVAILABILITY.EMP_START_TIME,0)
										        OR (#EMP_AVAILABILITY.EMP_END_TIME IS NULL)
									        )
									        --MAKE SURE DOESN'T CONFLICT WITH EXISTING EVENT TASK:
									        AND #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  NOT IN (
										        SELECT 
											        DISTINCT EMP_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS 
										        FROM 
											        #OTHER_TASKS_AND_EVENTS
										        WHERE 
											        (#OTHER_TASKS_AND_EVENTS.START_TIME BETWEEN @ROW_START_TIME AND @ROW_END_TIME)
											        OR
											        (#OTHER_TASKS_AND_EVENTS.END_TIME BETWEEN @ROW_START_TIME AND @ROW_END_TIME)
										        )
								        ORDER BY #EMP_AVAILABILITY.EMP_SENIORITY
							        ) AS A	
							        WHERE #TASKS_AND_EVENTS.EVENT_TASK_ID = @ROW_EVENT_TASK_ID;
    						        SELECT @THIS_EMP = EMP_CODE_FIRST_CHOICE COLLATE SQL_Latin1_General_CP1_CS_AS  FROM #TASKS_AND_EVENTS WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;

        					        
							        --PUT THE OTHERS INTO THE "SECONDARY EMPS" TABLE:
							        INSERT INTO #OTHER_TASK_EMPS (EVENT_TASK_ID,EMP_CODE,EMP_SENIORITY,EMP_START_TIME,EMP_END_TIME,EMP_DIRECT_HRS_GOAL_PERC,STD_HRS_AVAIL,EMP_DIRECT_HRS_GOAL_HOURS,HRS_USED_NON_TASK,HRS_AVAIL,HRS_ASSIGNED_TASK,HRS_BALANCE_AVAIL)
							        SELECT @ROW_EVENT_TASK_ID,#EMP_AVAILABILITY.EMP_CODE,EMP_SENIORITY,EMP_START_TIME,EMP_END_TIME,EMP_DIRECT_HRS_GOAL_PERC,STD_HRS_AVAIL,EMP_DIRECT_HRS_GOAL_HOURS,HRS_USED_NON_TASK,HRS_AVAIL,HRS_ASSIGNED_TASK,HRS_BALANCE_AVAIL
							        FROM #EMP_AVAILABILITY INNER JOIN
							          EMP_TRAFFIC_ROLE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  
							        WHERE [DATE] = @ROW_DATE
							        AND 1 = CASE WHEN @TRF_ROLE_CODE <> '' AND (EMP_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) THEN 1
												 WHEN @TRF_ROLE_CODE = '' THEN 1 END;
								End
							       
							        
					        END	

					        IF @TASK_TYPE = 1
					        BEGIN
								if @OfficeRestrictions > 0
								Begin
									UPDATE #TASKS_AND_EVENTS
									SET #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE = 
									A.TOP_EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS , #TASKS_AND_EVENTS.EMP_SENIORITY = A.TOP_EMP_CODE_SENIORITY
									FROM (
											SELECT TOP 1
					        					#EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  AS TOP_EMP_CODE, 
					        					ISNULL(EMP_SENIORITY,9999) AS TOP_EMP_CODE_SENIORITY
					        					--,  ISNULL(SUM(HRS_BALANCE_AVAIL),00.000000) AS HRS_BALANCE_AVAIL
											FROM
					        					#EMP_AVAILABILITY INNER JOIN EMPLOYEE E ON E.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
												EMP_OFFICE ON E.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = EMP_OFFICE.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS AND EMP_OFFICE.EMP_CODE = @EMP_CDE
											WHERE
												#EMP_AVAILABILITY.DATE >= @ROW_START_DATE 
												AND  #EMP_AVAILABILITY.DATE <= @ROW_END_DATE
											GROUP BY
		        								#EMP_AVAILABILITY.EMP_CODE,
		        								EMP_SENIORITY
											ORDER BY ISNULL(SUM(HRS_BALANCE_AVAIL),00.000000) DESC,EMP_SENIORITY,#EMP_AVAILABILITY.EMP_CODE	
									) AS A			
									WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;	
									SELECT @THIS_EMP = EMP_CODE_FIRST_CHOICE COLLATE SQL_Latin1_General_CP1_CS_AS  FROM #TASKS_AND_EVENTS WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;
									IF NOT @THIS_EMP IS NULL
									BEGIN
										--CAN ADD MORE HERE:
										INSERT INTO #OTHER_TASK_EMPS (EMP_CODE,EMP_SENIORITY,JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR, IS_FIRST_CHOICE--,
										--EMP_START_TIME,EMP_END_TIME,EMP_START_TIME_SUN,EMP_END_TIME_SUN,EMP_START_TIME_MON,EMP_END_TIME_MON,EMP_START_TIME_TUE,
										--EMP_END_TIME_TUE,EMP_START_TIME_WED,EMP_END_TIME_WED,EMP_START_TIME_THU,EMP_END_TIME_THU,EMP_START_TIME_FRI,EMP_END_TIME_FRI,
										--EMP_START_TIME_SAT,EMP_END_TIME_SAT
										)
										SELECT DISTINCT #EMP_AVAILABILITY.EMP_CODE,ISNULL(EMP_SENIORITY,9999),@JOB_NUMBER,@JOB_COMPONENT_NBR,@ROW_SEQ_NBR,
										CASE WHEN #EMP_AVAILABILITY.EMP_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @THIS_EMP COLLATE SQL_Latin1_General_CP1_CS_AS  THEN 1
										ELSE 0
										END--,
										--#EMP_AVAILABILITY.EMP_START_TIME,#EMP_AVAILABILITY.EMP_END_TIME,#EMP_AVAILABILITY.EMP_START_TIME_SUN,#EMP_AVAILABILITY.EMP_END_TIME_SUN,
										--#EMP_AVAILABILITY.EMP_START_TIME_MON,#EMP_AVAILABILITY.EMP_END_TIME_MON,#EMP_AVAILABILITY.EMP_START_TIME_TUE,#EMP_AVAILABILITY.EMP_END_TIME_TUE,
										--#EMP_AVAILABILITY.EMP_START_TIME_WED,#EMP_AVAILABILITY.EMP_END_TIME_WED,#EMP_AVAILABILITY.EMP_START_TIME_THU,#EMP_AVAILABILITY.EMP_END_TIME_THU,
										--#EMP_AVAILABILITY.EMP_START_TIME_FRI,#EMP_AVAILABILITY.EMP_END_TIME_FRI,#EMP_AVAILABILITY.EMP_START_TIME_SAT,#EMP_AVAILABILITY.EMP_END_TIME_SAT
										FROM #EMP_AVAILABILITY INNER JOIN
										EMP_TRAFFIC_ROLE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
										 EMPLOYEE E ON E.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS INNER JOIN
										 EMP_OFFICE ON E.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = EMP_OFFICE.OFFICE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS AND EMP_OFFICE.EMP_CODE = @EMP_CDE
										WHERE (EMP_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ) ;
									END
								End
								Else
								Begin
									UPDATE #TASKS_AND_EVENTS
									SET #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE = 
									A.TOP_EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS , #TASKS_AND_EVENTS.EMP_SENIORITY = A.TOP_EMP_CODE_SENIORITY
									FROM (
											SELECT TOP 1
					        					#EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  AS TOP_EMP_CODE, 
					        					ISNULL(EMP_SENIORITY,9999) AS TOP_EMP_CODE_SENIORITY
					        					--,  ISNULL(SUM(HRS_BALANCE_AVAIL),00.000000) AS HRS_BALANCE_AVAIL
											FROM
					        					#EMP_AVAILABILITY 
												LEFT OUTER JOIN EMP_TRAFFIC_ROLE ETR ON ETR.EMP_CODE = #EMP_AVAILABILITY.EMP_CODE
											WHERE
												#EMP_AVAILABILITY.DATE >= @ROW_START_DATE 
												AND #EMP_AVAILABILITY.DATE <= @ROW_END_DATE
												AND ETR.ROLE_CODE = @ROW_TRF_ROLE
											GROUP BY
		        								#EMP_AVAILABILITY.EMP_CODE,
		        								EMP_SENIORITY
											ORDER BY ISNULL(SUM(HRS_BALANCE_AVAIL),00.000000) DESC,EMP_SENIORITY,#EMP_AVAILABILITY.EMP_CODE	
									) AS A			
									WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;	
									SELECT @THIS_EMP = EMP_CODE_FIRST_CHOICE COLLATE SQL_Latin1_General_CP1_CS_AS  FROM #TASKS_AND_EVENTS WHERE #TASKS_AND_EVENTS.ROW_ID = @ROW_ID;
									IF NOT @THIS_EMP IS NULL
									BEGIN
										--CAN ADD MORE HERE:
										INSERT INTO #OTHER_TASK_EMPS (EMP_CODE,EMP_SENIORITY,JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR, IS_FIRST_CHOICE--,
										--EMP_START_TIME,EMP_END_TIME,EMP_START_TIME_SUN,EMP_END_TIME_SUN,EMP_START_TIME_MON,EMP_END_TIME_MON,EMP_START_TIME_TUE,
										--EMP_END_TIME_TUE,EMP_START_TIME_WED,EMP_END_TIME_WED,EMP_START_TIME_THU,EMP_END_TIME_THU,EMP_START_TIME_FRI,EMP_END_TIME_FRI,
										--EMP_START_TIME_SAT,EMP_END_TIME_SAT
										)
										SELECT DISTINCT #EMP_AVAILABILITY.EMP_CODE,ISNULL(EMP_SENIORITY,9999),@JOB_NUMBER,@JOB_COMPONENT_NBR,@ROW_SEQ_NBR,
										CASE WHEN #EMP_AVAILABILITY.EMP_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @THIS_EMP COLLATE SQL_Latin1_General_CP1_CS_AS  THEN 1
										ELSE 0
										END--,
										--#EMP_AVAILABILITY.EMP_START_TIME,#EMP_AVAILABILITY.EMP_END_TIME,#EMP_AVAILABILITY.EMP_START_TIME_SUN,#EMP_AVAILABILITY.EMP_END_TIME_SUN,
										--#EMP_AVAILABILITY.EMP_START_TIME_MON,#EMP_AVAILABILITY.EMP_END_TIME_MON,#EMP_AVAILABILITY.EMP_START_TIME_TUE,#EMP_AVAILABILITY.EMP_END_TIME_TUE,
										--#EMP_AVAILABILITY.EMP_START_TIME_WED,#EMP_AVAILABILITY.EMP_END_TIME_WED,#EMP_AVAILABILITY.EMP_START_TIME_THU,#EMP_AVAILABILITY.EMP_END_TIME_THU,
										--#EMP_AVAILABILITY.EMP_START_TIME_FRI,#EMP_AVAILABILITY.EMP_END_TIME_FRI,#EMP_AVAILABILITY.EMP_START_TIME_SAT,#EMP_AVAILABILITY.EMP_END_TIME_SAT
										FROM #EMP_AVAILABILITY INNER JOIN
										EMP_TRAFFIC_ROLE ON #EMP_AVAILABILITY.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS  = EMP_TRAFFIC_ROLE.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS
										WHERE (EMP_TRAFFIC_ROLE.ROLE_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = @TRF_ROLE_CODE COLLATE SQL_Latin1_General_CP1_CS_AS );
									END
								End
						        
					        END
					        
					        --SELECT * FROM #EMP_AVAILABILITY;
					        
			                --GO TO NEXT EVENT
			                SET @THIS_EMP = NULL
			                FETCH NEXT FROM MY_ROWS INTO @ROW_ID;
		                END
						                CLOSE MY_ROWS;
				                DEALLOCATE MY_ROWS;






        ----IF @TASK_TYPE = 1
        ----BEGIN
        ----	
        ----	
        ----	
        ----END
        ----
        --
        --
        --
        --


				IF @SAVE_FOUND_EMPLOYEES = 1
				BEGIN
					SELECT COUNT(1)
					FROM EVENT_TASK INNER JOIN #TASKS_AND_EVENTS ON EVENT_TASK.EVENT_TASK_ID = #TASKS_AND_EVENTS.EVENT_TASK_ID
					WHERE EVENT_TASK.EMP_CODE IS NULL AND (NOT(#TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE IS NULL));
					
					UPDATE EVENT_TASK WITH(ROWLOCK) SET EVENT_TASK.EMP_CODE = #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE 
					FROM EVENT_TASK INNER JOIN #TASKS_AND_EVENTS ON EVENT_TASK.EVENT_TASK_ID = #TASKS_AND_EVENTS.EVENT_TASK_ID
					WHERE EVENT_TASK.EMP_CODE IS NULL AND (NOT(#TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE IS NULL));
				END

				IF @SAVE_FOUND_EMPLOYEES = 0
				BEGIN					
					
					 --UPDATE #TASKS_AND_EVENTS
					 --SET TRF_ROLE_CODE = (SELECT ROLE_CODE FROM EMP_TRAFFIC_ROLE WHERE EMP_TRAFFIC_ROLE.EMP_CODE = #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE)

					SELECT
						DISTINCT
    					ISNULL(JOB_NUMBER,-1) AS JOB_NUMBER,
    					ISNULL(JOB_COMPONENT_NBR,-1) AS JOB_COMPONENT_NBR,
    					ISNULL(SEQ_NBR,-1) AS SEQ_NBR,
						ISNULL(EVENT_TASK_ID,-1) AS EVENT_TASK_ID,
						EVENT_TASK_DESC,
						ISNULL(EVENT_ID,-1) AS EVENT_ID,
						EVENT_TASK_HOURS_ALLOWED,
						TRF_TASK_CODE,
						TRF_TASK_DESC,
				        TRF_ROLE_CODE,--- = (SELECT ROLE_CODE FROM EMP_TRAFFIC_ROLE WHERE EMP_TRAFFIC_ROLE.EMP_CODE = #TASKS_AND_EVENTS.EMP_CODE_FIRST_CHOICE),
			--	        TRF_ROLE_DESC,
						IS_EVENT_TASK,
						START_DATE,
						END_DATE,
						START_TIME,
						END_TIME,
						EMP_CODE_FIRST_CHOICE,
						EMP_SENIORITY,
						CURR_EMP_CODE,
						HAS_EMP_ASSIGNED,
						TOTAL_WORK_DAYS,
						HRS_PER_DAY,
						CONVERT(VARCHAR(10), [START_DATE], 101) AS TEXT_START,
						CASE DATEPART(dw,[START_DATE])
							WHEN 1 THEN 'Sun'
							WHEN 2 THEN 'Mon'
							WHEN 3 THEN 'Tue'
							WHEN 4 THEN 'Wed'
							WHEN 5 THEN 'Thu'
							WHEN 6 THEN 'Fri'
							WHEN 7 THEN 'Sat'
						END AS DAY_OF_WEEK    
					FROM #TASKS_AND_EVENTS ORDER BY  START_TIME, END_TIME,EVENT_TASK_DESC,EVENT_ID;

			--SELECT *
			--FROM   #OTHER_TASKS_AND_EVENTS

			--SELECT *
			--FROM   #EMP_AVAILABILITY
			--
			SELECT *
			FROM   #OTHER_TASK_EMPS;
					
					
			END

        DROP TABLE #TASKS_AND_EVENTS;
        DROP TABLE #OTHER_TASKS_AND_EVENTS;
        DROP TABLE #EMP_AVAILABILITY;
        DROP TABLE #OTHER_TASK_EMPS;

 
        
        

