IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_agile_load_dataset]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_agile_load_dataset]
GO

CREATE PROCEDURE [dbo].[advsp_agile_load_dataset] 
@OFFICE_LIST AS varchar(MAX) = NULL,
@DEPT_LIST AS varchar(MAX) = NULL,
@STARTING_WEEK as smalldatetime,
@NUM_WEEKS as int
AS
/*=========== QUERY ===========*/
BEGIN

	DECLARE @START_DATE SMALLDATETIME, 
		    @END_DATE SMALLDATETIME,  @sql varchar(MAX), @END_DATE_Weeks SMALLDATETIME

	SET @START_DATE = DATEADD(dd, -(DATEPART(dw, @STARTING_WEEK)-1), @STARTING_WEEK)
	SET @END_DATE = DATEADD(week, @NUM_WEEKS - 1, @STARTING_WEEK);
	SET @END_DATE = DATEADD(dd, 7-(DATEPART(dw, @END_DATE)), @END_DATE)
	SET @END_DATE_Weeks = DATEADD(week, 8 - 1, @STARTING_WEEK);
	SET @END_DATE_Weeks = DATEADD(dd, 7-(DATEPART(dw, @END_DATE_Weeks)), @END_DATE_Weeks)

	--SELECT @START_DATE,@END_DATE

    CREATE TABLE #WEEKLY_HRS (ID INT IDENTITY(1,1) NOT NULL, 
						 SprintEmployeeID INT,
						 EmployeeCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
						 EmployeeName VARCHAR(100),
						 EmployeeFirstName VARCHAR(30),
						 EmployeeLastName VARCHAR(30),
						 EmployeeOfficeCode VARCHAR(6),
						 EmployeeOfficeName VARCHAR(30),
						 EmployeeDepartmentCode VARCHAR(6),
						 EmployeeDepartmentName VARCHAR(30),
						 WeekNumber INT,
						 WeekStart SMALLDATETIME,
						 WeekEnd SMALLDATETIME,
						 HoursAvailable DECIMAL (9,3),
						 HoursAllocated DECIMAL (9,3),
						 AvailableBalance DECIMAL (9,3),
						 HoursPosted DECIMAL (9,3),
						 PriorHoursPosted DECIMAL (9,3),
						 AllocatedBalance DECIMAL (9,3),
						 SprintDetailID INT,
						 AlertID INT,
						 AlertLevel varchar(50),
						 PriorHoursAllowed DECIMAL (9,3),
						 AssignmentHoursAllowed DECIMAL (9,3),
						 TotalHoursAllocated DECIMAL (9,3),
						 HoursAllocatedBalance DECIMAL (9,3),
						 NotAssigned BIT,
						 RecordType varchar(10)
						);

	CREATE TABLE #WEEKLY_HRS_NUM (ID INT IDENTITY(1,1) NOT NULL, 
						 EmployeeCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
						 WeekStart SMALLDATETIME,
						 HoursAvailable DECIMAL (9,3),
						 HoursAllocated DECIMAL (9,3),
						 HoursPosted DECIMAL (9,3),
						);

	CREATE TABLE #WEEKLY_HRS_TOTAL (ID INT IDENTITY(1,1) NOT NULL, 
						 EmployeeCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
						 EmployeeName VARCHAR(100),
						 EmployeeFirstName VARCHAR(30),
						 EmployeeLastName VARCHAR(30),
						 EmployeeOfficeCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
						 EmployeeOfficeName VARCHAR(30),
						 EmployeeDepartmentCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
						 EmployeeDepartmentName VARCHAR(30),
						 --WeekStart SMALLDATETIME,
						 --WeekEnd SMALLDATETIME,
						 HoursAvailable DECIMAL (9,3),
						 HoursAllocated DECIMAL (9,3),
						 AvailableBalance DECIMAL (9,3),
						 HoursPosted DECIMAL (9,3),
						 PriorHoursPosted DECIMAL (9,3),
						 AllocatedBalance DECIMAL (9,3),
						 PriorHoursAllocated DECIMAL (9,3),
						 PriorHoursAllowed DECIMAL (9,3),
						 AssignmentHoursAllowed DECIMAL (9,3),
						 TotalHoursAllocated DECIMAL (9,3),
						 HoursAllocatedBalance DECIMAL (9,3),
						 BurnRate DECIMAL (9,3),
						 HoursPostedTask DECIMAL (9,3),
						 HoursAllowedTask DECIMAL (9,3),
						 HoursAllowedOpen DECIMAL (9,3)
						);

	CREATE TABLE #TOTALS (ID INT IDENTITY(1,1) NOT NULL, 
						 EmployeeCode VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,  
						 AlertID INT,
						 AlertLevel varchar(50),
						 PriorAssignmentHoursAllowed DECIMAL (9,3),
						 AssignmentHoursAllowed DECIMAL (9,3),
						 TotalHoursAllocated DECIMAL (9,3),
						 HoursAllocatedBalance DECIMAL (9,3),
						 PriorHoursPosted DECIMAL (9,3)
						);

    CREATE TABLE #EMPLOYEES (EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, TOTAL_WEEK_HRS DECIMAL( 18, 2), TOTAL_NON_TASK_HOURS DECIMAL( 18, 2))

	CREATE TABLE #NON_TASK_TIME ([ROW_ID] [int] IDENTITY(1,1) NOT NULL,
								 EMP_CODE VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
								  WeekNumber INT,
								  WorkDay SMALLDATETIME,
								  Holiday INT,
								  STD_HOURS  DECIMAL(18,2),
								  TOTAL_HOURS DECIMAL(18,2));

    CREATE TABLE #JOBS 
	(
		[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
		[OFFICE_CODE]		VARCHAR(4) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[CL_CODE]			VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[DIV_CODE]		VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[PRD_CODE]		VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JOB_NUMBER] INT,
		[JOB_COMPONENT_NBR] INT,
		[SEQ_NBR] INT,
		[EMP_CODE]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[TASK_START_DATE]    SMALLDATETIME,
		[JOB_REVISED_DATE]   SMALLDATETIME,
		[FNC_CODE]			 VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JOB_HRS]          DECIMAL(18,6),
		[WORKDAY_COUNT]         INT,
		[HRS_PER_DAY]	DECIMAL(18,6),
		[WORKDAY_COUNT_IN_RANGE] INT,	        
		[TRF_DESCRIPTION]		VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JOB_DESC]		VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JOB_COMP_DESC]	VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
		[JOB_FIRST_USE_DATE]	SMALLDATETIME,
		[HRS_PER_DAY_WITH_ASSN]	DECIMAL(18,6),
		[WORKDAY_COUNT_IN_RANGE_WITH_ASSN] INT,
		[HRS_POSTED]   DECIMAL(18,6),
		[WEEK_OF_YEAR] SMALLDATETIME

	)

	INSERT INTO #EMPLOYEES
	SELECT EMP_CODE, NULL, NULL FROM EMPLOYEE WITH(NOLOCK)
	WHERE EMP_TERM_DATE IS NULL

	--INSERT INTO #WEEKLY_HRS

    --INSERT INTO #WEEKLY_HRS (SprintEmployeeID, EmployeeCode, EmployeeName, EmployeeFirstName, EmployeeLastName, EmployeeOfficeCode, EmployeeDepartmentCode, WeekNumber, WeekStart, WeekEnd, HoursAllocated, SprintDetailID, AlertID, AlertLevel)
    --SELECT 
	   --SE.ID, SE.EMP_CODE, ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, ''), E.EMP_FNAME, E.EMP_LNAME, E.OFFICE_CODE, E.DP_TM_CODE, SE.WEEK_NUM, SE.WEEK_START, SE.WEEK_END, SE.HOURS, SD.ID, SD.ALERT_ID, A.ALERT_LEVEL
    --FROM
	   --SPRINT_EMPLOYEE SE
	   --INNER JOIN SPRINT_DTL SD
		  --ON SE.SPRINT_DTL_ID = SD.ID
	   --INNER JOIN ALERT A
		  --ON SD.ALERT_ID = A.ALERT_ID
	   --INNER JOIN EMPLOYEE E
		  --ON SE.EMP_CODE = E.EMP_CODE
	   --LEFT OUTER JOIN EMPLOYEE_PICTURE EP
		  --ON E.EMP_CODE = EP.EMP_CODE	   
	   --LEFT OUTER JOIN V_INACTIVE_WORK_ITEMS IWI ON SD.ALERT_ID = IWI.ALERT_ID   
    --WHERE WEEK_START BETWEEN @START_DATE AND @END_DATE AND (IWI.ALERT_ID IS NULL) 


	INSERT INTO #WEEKLY_HRS (SprintEmployeeID, EmployeeCode, EmployeeOfficeCode, WeekNumber, WeekStart, WeekEnd, HoursAllocated, SprintDetailID, AlertID, AlertLevel, NotAssigned, RecordType)
    SELECT 
	   SPRINT_EMPLOYEE.ID, ALERT_RCPT.EMP_CODE, ALERT.OFFICE_CODE, 
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_NUM IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_NUM ELSE CASE WHEN ALERT.[START_DATE] IS NULL THEN DATEPART(wk,ALERT.DUE_DATE) ELSE DATEPART(wk,ALERT.[START_DATE]) END END,
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_START IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_START ELSE 
					CASE WHEN ALERT.[START_DATE] is NULL THEN DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.DUE_DATE)) , 104 ) ) + (DATEPART(wk,ALERT.DUE_DATE)-1), 6) 
							ELSE DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.[START_DATE])) , 104 ) ) + (DATEPART(wk,ALERT.[START_DATE])-1), 6)  END END,
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_END IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_END ELSE 
					CASE WHEN ALERT.DUE_DATE is NULL THEN DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.[START_DATE])) , 104 ) ) + (DATEPART(wk,ALERT.[START_DATE])-1), 6)
							ELSE DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.DUE_DATE)) , 104 ) ) + (DATEPART(wk,ALERT.DUE_DATE)-1), 6)  END END,
	   ISNULL(CASE WHEN ISNULL(SPRINT_EMPLOYEE.[HOURS],0) = 0 THEN 0 ELSE SPRINT_EMPLOYEE.[HOURS] END,0),
	   NULL, ALERT.ALERT_ID, ALERT.ALERT_LEVEL,0,'AS'
	FROM ALERT WITH(NOLOCK) INNER JOIN
					 ALERT_RCPT WITH(NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID LEFT OUTER JOIN
					 JOB_COMPONENT WITH(NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
					 ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
					 JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
					 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
					 LEFT OUTER JOIN JOB_LOG WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
					 LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
					 LEFT OUTER JOIN SPRINT_EMPLOYEE WITH(NOLOCK) ON ALERT_RCPT.ALERT_ID = SPRINT_EMPLOYEE.ALERT_ID AND ALERT_RCPT.EMP_CODE = SPRINT_EMPLOYEE.EMP_CODE AND SPRINT_EMPLOYEE.[HOURS] > 0
					 --LEFT OUTER JOIN V_INACTIVE_WORK_ITEMS IWI ON ALERT.ALERT_ID = IWI.ALERT_ID
				WHERE IS_WORK_ITEM = 1 AND ALERT_LEVEL <> 'BRD' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) 
						AND (HRS_ALLOWED <> 0 OR [HOURS] <> 0) AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND (ALERT.ASSIGN_COMPLETED IS NULL OR ALERT.ASSIGN_COMPLETED = 0) AND (CURRENT_NOTIFY = 1)

	INSERT INTO #WEEKLY_HRS (SprintEmployeeID, EmployeeCode, EmployeeOfficeCode, WeekNumber, WeekStart, WeekEnd, HoursAllocated, SprintDetailID, AlertID, AlertLevel, NotAssigned, RecordType)
    SELECT 
	   SPRINT_EMPLOYEE.ID, ALERT.ASSIGNED_EMP_CODE, ALERT.OFFICE_CODE, 
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_NUM IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_NUM ELSE CASE WHEN ALERT.[START_DATE] IS NULL THEN DATEPART(wk,ALERT.DUE_DATE) ELSE DATEPART(wk,ALERT.[START_DATE]) END END,
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_START IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_START ELSE 
					CASE WHEN ALERT.[START_DATE] is NULL THEN DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.DUE_DATE)) , 104 ) ) + (DATEPART(wk,ALERT.DUE_DATE)-1), 6) 
							ELSE DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.[START_DATE])) , 104 ) ) + (DATEPART(wk,ALERT.[START_DATE])-1), 6)  END END,
	   CASE WHEN SPRINT_EMPLOYEE.WEEK_END IS NOT NULL THEN SPRINT_EMPLOYEE.WEEK_END ELSE 
					CASE WHEN ALERT.DUE_DATE is NULL THEN DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.[START_DATE])) , 104 ) ) + (DATEPART(wk,ALERT.[START_DATE])-1), 6)
							ELSE DATEADD(wk, DATEDIFF(wk, 6, convert( datetime , '1.1.' + convert( varchar , DATEPART(yy,ALERT.DUE_DATE)) , 104 ) ) + (DATEPART(wk,ALERT.DUE_DATE)-1), 6)  END END,
	   ISNULL(CASE WHEN ISNULL(SPRINT_EMPLOYEE.[HOURS],0) = 0 THEN 0 ELSE SPRINT_EMPLOYEE.[HOURS] END,0),
	   NULL, ALERT.ALERT_ID, ALERT.ALERT_LEVEL,0,'AS'
	FROM ALERT WITH(NOLOCK) LEFT OUTER JOIN
					 --ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID LEFT OUTER JOIN
					 JOB_COMPONENT WITH(NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
					 ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
					 JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
					 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
					 LEFT OUTER JOIN JOB_LOG WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
					 LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
					 LEFT OUTER JOIN SPRINT_EMPLOYEE WITH(NOLOCK) ON ALERT.ALERT_ID = SPRINT_EMPLOYEE.ALERT_ID AND ALERT.ASSIGNED_EMP_CODE = SPRINT_EMPLOYEE.EMP_CODE AND SPRINT_EMPLOYEE.[HOURS] > 0
					 --LEFT OUTER JOIN V_INACTIVE_WORK_ITEMS IWI ON ALERT.ALERT_ID = IWI.ALERT_ID
				WHERE IS_WORK_ITEM = 1 AND ALERT_LEVEL <> 'BRD' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) 
						AND (HRS_ALLOWED <> 0 OR [HOURS] <> 0) AND ALERT.ALRT_NOTIFY_HDR_ID IS NOT NULL AND (ALERT.ASSIGN_COMPLETED IS NULL OR ALERT.ASSIGN_COMPLETED = 0)

	--SELECT * FROM #WEEKLY_HRS

	INSERT INTO #WEEKLY_HRS 
	SELECT SPRINT_EMPLOYEE.ID,
			V_JOB_TRAFFIC_DET.EMP_CODE,NULL,NULL,NULL,
			JOB_LOG.OFFICE_CODE,NULL,NULL,NULL,			
				 CASE WHEN WEEK_START IS NULL THEN DATEPART(wk,V_JOB_TRAFFIC_DET.TASK_START_DATE) ELSE DATEPART(wk,ALERT.[START_DATE]) END,
				 CASE WHEN WEEK_START IS NOT NULL THEN WEEK_START ELSE CONVERT(Date,V_JOB_TRAFFIC_DET.TASK_START_DATE) END,
				 CASE WHEN WEEK_END IS NOT NULL THEN WEEK_END ELSE  CONVERT(
				       DATETIME,
				       CONVERT(CHAR(10), DATEPART(yyyy, JOB_REVISED_DATE), 101) 
				       +
				       '-' +
				       CONVERT(CHAR(10), DATEPART(mm, JOB_REVISED_DATE), 101) +
				       '-' +
				       CONVERT(CHAR(10), DATEPART(dd, JOB_REVISED_DATE), 101) +
				       ' 23:59:00' 
				       ) END,0,					 
					 ISNULL(CASE WHEN ISNULL(SPRINT_EMPLOYEE.[HOURS],0) = 0 THEN 0 ELSE SPRINT_EMPLOYEE.[HOURS] END,0),0,0,0,0,0,
					 ALERT.ALERT_ID,
					 ALERT.ALERT_LEVEL,0,0,0,0,0,'T'				 					
					FROM         
						V_JOB_TRAFFIC_DET WITH(NOLOCK) INNER JOIN
						JOB_COMPONENT WITH(NOLOCK) ON V_JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
						JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
						JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
						INNER JOIN JOB_LOG WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
						INNER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
						LEFT OUTER JOIN ALERT WITH(NOLOCK) ON ALERT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = V_JOB_TRAFFIC_DET.SEQ_NBR
						LEFT OUTER JOIN SPRINT_EMPLOYEE WITH(NOLOCK) ON ALERT.ALERT_ID = SPRINT_EMPLOYEE.ALERT_ID AND V_JOB_TRAFFIC_DET.EMP_CODE = SPRINT_EMPLOYEE.EMP_CODE AND SPRINT_EMPLOYEE.[HOURS] > 0	
						WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
								AND (V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL) AND V_JOB_TRAFFIC_DET.EMP_CODE IS NOT NULL AND ISNULL(SPRINT_EMPLOYEE.[HOURS],0) > 0
								--AND ((TASK_START_DATE >= @START_DATE AND TASK_START_DATE <= @END_DATE) OR
								--	(JOB_REVISED_DATE >= @START_DATE AND JOB_REVISED_DATE <= @END_DATE) OR
								--	(@START_DATE >= TASK_START_DATE AND @END_DATE <= JOB_REVISED_DATE))	
	
	INSERT INTO #WEEKLY_HRS (SprintEmployeeID, EmployeeCode, EmployeeName, EmployeeFirstName, EmployeeLastName, EmployeeOfficeCode, EmployeeDepartmentCode, WeekNumber, WeekStart, WeekEnd, HoursAllocated, SprintDetailID, AlertID, AlertLevel, NotAssigned)
	SELECT NULL, #EMPLOYEES.EMP_CODE, ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, ''), E.EMP_FNAME, E.EMP_LNAME, E.OFFICE_CODE, E.DP_TM_CODE, NULL, NULL, NULL, 0, NULL, NULL, NULL,0
	FROM #EMPLOYEES INNER JOIN EMPLOYEE E WITH(NOLOCK) ON E.EMP_CODE = #EMPLOYEES.EMP_CODE
	WHERE #EMPLOYEES.EMP_CODE NOT IN (SELECT DISTINCT EmployeeCode FROM #WEEKLY_HRS)

	--SELECT * FROM #WEEKLY_HRS


	UPDATE #WEEKLY_HRS
	SET EmployeeName = dbo.udf_get_empl_name(EmployeeCode,'FML')
	WHERE Employeename IS NULL

	UPDATE #WEEKLY_HRS
	SET EmployeeFirstName = (SELECT EMP_FNAME FROM EMPLOYEE E WHERE E.EMP_CODE = #WEEKLY_HRS.EmployeeCode)
	WHERE EmployeeFirstName IS NULL

	UPDATE #WEEKLY_HRS
	SET EmployeeLastName = (SELECT EMP_LNAME FROM EMPLOYEE E WHERE E.EMP_CODE = #WEEKLY_HRS.EmployeeCode)
	WHERE EmployeeLastName IS NULL

	UPDATE #WEEKLY_HRS
	SET EmployeeDepartmentCode = (SELECT DP_TM_CODE FROM EMPLOYEE E WHERE E.EMP_CODE = #WEEKLY_HRS.EmployeeCode)
	WHERE EmployeeDepartmentCode IS NULL

	UPDATE #WEEKLY_HRS
	SET EmployeeOfficeCode = (SELECT OFFICE_CODE FROM EMPLOYEE E WHERE E.EMP_CODE = #WEEKLY_HRS.EmployeeCode)
	WHERE EmployeeOfficeCode IS NULL
	

	   --1 = CASE WHEN @SPRINT_ID IS NULL OR @SPRINT_ID = 0 THEN 1 WHEN SD.SPRINT_HDR_ID = @SPRINT_ID THEN 1 ELSE 0 END 
	   --AND
	   --1 = CASE WHEN @ALERT_ID IS NULL OR @ALERT_ID = 0 THEN 1 WHEN SD.ALERT_ID = @ALERT_ID THEN 1 ELSE 0 END
	   --AND
	   --1 = CASE WHEN @EMP_CODE IS NULL OR @EMP_CODE = '' THEN 1 WHEN SE.EMP_CODE = @EMP_CODE THEN 1 ELSE 0 END

	--SELECT * FROM #WEEKLY_HRS ORDER BY EmployeeCode,WeekNumber
	
	--Standard week hours

	--INSERT INTO #EMPLOYEES (EMP_CODE)
	--SELECT DISTINCT EmployeeCode FROM #WEEKLY_HRS;		

	UPDATE #EMPLOYEES
    SET TOTAL_WEEK_HRS = ISNULL(MON_HRS, 0.00) + ISNULL(TUE_HRS, 0.00) + ISNULL(WED_HRS, 0.00) + ISNULL(THU_HRS, 0.00) + ISNULL(FRI_HRS, 0.00) + ISNULL(SAT_HRS, 0.00) + ISNULL(SUN_HRS, 0.00) 
    FROM
	   EMPLOYEE E
	   INNER JOIN #EMPLOYEES EE 
		  ON E.EMP_CODE = EE.EMP_CODE;

	--Non Task Hours
	DECLARE @START_DATE_MIN SMALLDATETIME, 
		    @END_DATE_MAX SMALLDATETIME

    SELECT @START_DATE_MIN = MIN(WeekStart) FROM #WEEKLY_HRS
	SELECT @END_DATE_MAX = MAX(WeekEnd) FROM #WEEKLY_HRS

	IF @START_DATE_MIN IS NULL
	BEGIN
		SET @START_DATE_MIN = @START_DATE
	END

	IF @END_DATE_MAX IS NULL
	BEGIN
		SET @END_DATE_MAX = @END_DATE
	END

	if @START_DATE < @START_DATE_MIN
	BEGIN
		SET @START_DATE_MIN = @START_DATE
	END

	if @END_DATE > @END_DATE_MAX
	BEGIN
		SET @END_DATE_MAX = @END_DATE
	END


	--SELECT @START_DATE_MIN,@END_DATE_MAX
	--SELECT * FROM #EMPLOYEES
	CREATE TABLE #work_days ( workyear integer, workdate smalldatetime, holiday bit, weekend bit, dayoff bit )

	DECLARE @cur_date smalldatetime, @emp_start_date smalldatetime, @day_count2 integer, @start_year integer, @end_year integer, @cur_year integer
	DECLARE @year_start_date smalldatetime, @year_end_date smalldatetime, @holiday bit, @weekend bit, @dayoff bit 
	IF ( @START_DATE_MIN IS NOT NULL ) AND ( @END_DATE_MAX IS NOT NULL ) AND ( @START_DATE_MIN <= @END_DATE_MAX )
	BEGIN
		-- Create a table holding the average workday by year for each employee		
		DECLARE @std_hours decimal(9,3)
		
		SET @start_year = DATEPART(yyyy, @START_DATE_MIN)		
		SET @end_year = DATEPART(yyyy, @END_DATE_MAX)		
		SET @cur_year = @start_year
		WHILE ( @cur_year <= @end_year )
		BEGIN
			SET @day_count2 = 0
			SET @year_start_date = CONVERT( smalldatetime, '01/01/' + CAST( @cur_year AS varchar(4)) )
			SET @year_end_date = CONVERT( smalldatetime, '12/31/' + CAST( @cur_year AS varchar(4)) )
			SET @cur_date = @year_start_date
			
			WHILE ( @cur_date <= @year_end_date )
			BEGIN
				SET @weekend = 0
				IF (( DATEPART( dw, @cur_date )) IN ( 1, 7 ))
					SET @weekend = 1
				ELSE
					SET @day_count2 = @day_count2 + 1
									 
				SET @holiday = 0					
				IF ( SELECT COUNT( 1 ) 
				       FROM dbo.EMP_NON_TASKS ent  WITH(NOLOCK)
				      WHERE ent.[TYPE] = 'H' 
				        AND ent.ALL_DAY = 1 
						AND ( @cur_date BETWEEN ent.[START_DATE] AND ent.[END_DATE] )) > 0
					SELECT @holiday = 1			
				
				INSERT INTO #work_days( workyear, workdate, holiday, weekend ) VALUES ( @cur_year, @cur_date, @holiday, @weekend )
				
				SET @cur_date = DATEADD( day, 1, @cur_date )
			END					

			SET @cur_year = @cur_year + 1
		END	
	END

	--SELECT * FROM #work_days WHERE workdate = '12/12/2019'

    INSERT INTO #NON_TASK_TIME
	SELECT 
			[EmployeeCode] = e.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS, 
			[WeekNumber] = DATEPART( w, wd.workdate ),
			[WorkDate] = wd.workdate,
			wd.holiday,
			CASE DATEPART(dw,wd.workdate)
					WHEN 1 THEN (SELECT ISNULL(SUN_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 2 THEN (SELECT ISNULL(MON_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 3 THEN (SELECT ISNULL(TUE_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 4 THEN (SELECT ISNULL(WED_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 5 THEN (SELECT ISNULL(THU_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 6 THEN (SELECT ISNULL(FRI_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
					WHEN 7 THEN (SELECT ISNULL(SAT_HRS,0) FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										END,
			CASE WHEN holiday = 1 THEN CASE DATEPART(dw,wd.workdate)
										WHEN 1 THEN (SELECT SUN_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 2 THEN (SELECT MON_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 3 THEN (SELECT TUE_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 4 THEN (SELECT WED_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 5 THEN (SELECT THU_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 6 THEN (SELECT FRI_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										WHEN 7 THEN (SELECT SAT_HRS FROM EMPLOYEE WHERE EMP_CODE = e.EMP_CODE)
										END 
								  ELSE 0 END
		FROM 
			#EMPLOYEES e CROSS JOIN #work_days wd	
	
    --SELECT * FROM #NON_TASK_TIME --WHERE WorkDay = '12/12/2019'

	UPDATE #NON_TASK_TIME
	SET TOTAL_HOURS = ISNULL((SELECT SUM([HOURS]) 
					  FROM EMP_NON_TASKS WITH(NOLOCK) LEFT OUTER JOIN 
					       EMP_NON_TASKS_EMPS WITH(NOLOCK) ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
					  WHERE EMP_NON_TASKS_EMPS.EMP_CODE = #NON_TASK_TIME.EMP_CODE
					    AND WorkDay BETWEEN [START_DATE] AND [END_DATE] AND ALL_DAY = 0
                        GROUP BY EMP_NON_TASKS_EMPS.EMP_CODE,[START_DATE],[END_DATE],ALL_DAY),0)
	WHERE Holiday = 0

    UPDATE #NON_TASK_TIME
	SET TOTAL_HOURS = ISNULL((SELECT SUM([HOURS]) 
					  FROM EMP_NON_TASKS WITH(NOLOCK) LEFT OUTER JOIN 
					       EMP_NON_TASKS_EMPS WITH(NOLOCK) ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
					  WHERE EMP_NON_TASKS_EMPS.EMP_CODE = #NON_TASK_TIME.EMP_CODE
					    AND WorkDay BETWEEN [START_DATE] AND [END_DATE] AND ALL_DAY = 1
                        GROUP BY EMP_NON_TASKS_EMPS.EMP_CODE,[START_DATE],[END_DATE],ALL_DAY),0)
	WHERE Holiday = 0


	--UPDATE HOURS POSTED
	BEGIN
		UPDATE #WEEKLY_HRS
		SET HoursPosted = ISNULL((SELECT SUM(EMP_HOURS) 
									FROM EMP_TIME_DTL AS ETD INNER JOIN EMP_TIME AS ET ON ETD.ET_ID = ET.ET_ID
								   WHERE ETD.ALERT_ID = AlertID AND ET.EMP_CODE = EmployeeCode --AND EMP_DATE BETWEEN WeekStart AND WeekEnd
								   GROUP BY ET.EMP_CODE, ETD.ALERT_ID),0)

		--UPDATE #WEEKLY_HRS
		--SET PriorHoursPosted = ISNULL((SELECT SUM(EMP_HOURS) 
		--							FROM EMP_TIME_DTL AS ETD INNER JOIN EMP_TIME AS ET ON ETD.ET_ID = ET.ET_ID
		--						   WHERE ETD.ALERT_ID = AlertID AND ET.EMP_CODE = EmployeeCode AND EMP_DATE < @START_DATE
		--						   GROUP BY ET.EMP_CODE, ETD.ALERT_ID),0)

		--UPDATE #WEEKLY_HRS
		--SET PriorHoursAllowed = (SELECT ISNULL(SUM(HOURS_ALLOWED),SUM(JTD.JOB_HRS))
		--									FROM ALERT A LEFT OUTER JOIN JOB_TRAFFIC_DET JTD ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
		--									 LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE ON A.JOB_NUMBER = JTDE.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTDE.SEQ_NBR
		--									WHERE #WEEKLY_HRS.AlertID = A.ALERT_ID AND JTDE.EMP_CODE = EmployeeCode AND WeekStart < @START_DATE)
	END	
	
	--SELECT * FROM #NON_TASK_TIME --WHERE EMP_CODE = 'ama'
	--SELECT * FROM #EMPLOYEES E
	--   INNER JOIN #WEEKLY_HRS WH ON E.EMP_CODE = WH.EmployeeCode
	-- WHERE EMP_CODE = 'ama'
	--Hours Available
    UPDATE #WEEKLY_HRS
	SET HoursAvailable = E.TOTAL_WEEK_HRS - ISNULL((SELECT SUM(TOTAL_HOURS) FROM #NON_TASK_TIME WHERE EmployeeCode = EMP_CODE AND WorkDay BETWEEN WeekStart and WeekEnd),0)
    FROM
	   #EMPLOYEES E WITH(NOLOCK)
	   INNER JOIN #WEEKLY_HRS WH ON E.EMP_CODE = WH.EmployeeCode;  

	--SELECT * FROM #WEEKLY_HRS
	--SELECT * FROM #EMPLOYEES

	INSERT INTO #WEEKLY_HRS_NUM
	SELECT EmployeeCode, WeekStart, 0, SUM(HoursAllocated), SUM(HoursPosted)
	FROM #WEEKLY_HRS
	GROUP BY EmployeeCode, WeekStart
	ORDER BY EmployeeCode, WeekStart

	UPDATE #WEEKLY_HRS_NUM
	SET HoursAvailable = (SELECT DISTINCT HoursAvailable FROM #WEEKLY_HRS W WHERE W.EmployeeCode = #WEEKLY_HRS_NUM.EmployeeCode AND (W.WeekStart = #WEEKLY_HRS_NUM.WeekStart OR #WEEKLY_HRS_NUM.WeekStart IS NULL))

	--SELECT * FROM #WEEKLY_HRS_NUM


	DECLARE @ECode varchar(6), @PrevECode varchar(6), @AvailableAmount decimal(18,3), @AllocatedAmount decimal(18,3), @PostedAmount decimal(18,3), @RowCount INT, @NumberRecords INT
	SET @PrevECode = ''

	SELECT @NumberRecords = COUNT(*) FROM #WEEKLY_HRS_NUM
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN
		SELECT @ECode = EmployeeCode
		FROM #WEEKLY_HRS_NUM
		WHERE ID = @RowCount

		if @PrevECode = ''
		Begin
			SET @AvailableAmount = (SELECT HoursAvailable FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @AllocatedAmount = (SELECT HoursAllocated FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @PostedAmount = (SELECT HoursPosted FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)

			SET @PrevECode = @ECode
		End
		Else if @PrevECode = @ECode
		Begin			
			UPDATE #WEEKLY_HRS_NUM
			SET HoursAvailable += @AvailableAmount WHERE ID = @RowCount
			UPDATE #WEEKLY_HRS_NUM
			SET HoursAllocated += @AllocatedAmount WHERE ID = @RowCount
			UPDATE #WEEKLY_HRS_NUM
			SET HoursPosted += @PostedAmount WHERE ID = @RowCount

			SET @AvailableAmount = (SELECT HoursAvailable FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @AllocatedAmount = (SELECT HoursAllocated FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @PostedAmount = (SELECT HoursPosted FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)

			SET @PrevECode = @ECode
		End
		Else
		Begin
			SET @AvailableAmount = (SELECT HoursAvailable FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @AllocatedAmount = (SELECT HoursAllocated FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)
			SET @PostedAmount = (SELECT HoursPosted FROM #WEEKLY_HRS_NUM WHERE ID = @RowCount)

			SET @PrevECode = @ECode
		End
		
	 	 SET @RowCount = @RowCount + 1
	END

	--SELECT * FROM #WEEKLY_HRS_NUM


		-- Assignment Hours Allowed / Total Hours Allocated
	BEGIN

		INSERT INTO #TOTALS
		SELECT DISTINCT EmployeeCode, AlertID,AlertLevel,0,0,0,0,0
		FROM #WEEKLY_HRS

		UPDATE #TOTALS
		SET TotalHoursAllocated = (SELECT SUM([HOURS]) FROM SPRINT_EMPLOYEE WITH(NOLOCK) WHERE ALERT_ID = AlertID AND EMP_CODE = EmployeeCode)

		UPDATE #TOTALS
		SET AssignmentHoursAllowed = (SELECT ISNULL(SUM(HOURS_ALLOWED),SUM(JTD.JOB_HRS))
										FROM ALERT A WITH(NOLOCK) LEFT OUTER JOIN JOB_TRAFFIC_DET JTD ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
										 LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON A.JOB_NUMBER = JTDE.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTDE.SEQ_NBR
										WHERE #TOTALS.AlertID = A.ALERT_ID)
        WHERE AlertLevel = 'BRD'
		
		UPDATE #TOTALS
		SET AssignmentHoursAllowed = (SELECT ISNULL(SUM(HRS_ALLOWED),TotalHoursAllocated)
										FROM ALERT A WITH(NOLOCK)
										WHERE #TOTALS.AlertID = A.ALERT_ID)
        WHERE AlertLevel <> 'BRD'
		 
		UPDATE #TOTALS
		SET PriorAssignmentHoursAllowed = (SELECT ISNULL(SUM(HOURS_ALLOWED),SUM(JTD.JOB_HRS))
											FROM ALERT A WITH(NOLOCK) LEFT OUTER JOIN JOB_TRAFFIC_DET JTD ON A.JOB_NUMBER = JTD.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTD.SEQ_NBR
											 LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTDE WITH(NOLOCK) ON A.JOB_NUMBER = JTDE.JOB_NUMBER AND A.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND A.TASK_SEQ_NBR = JTDE.SEQ_NBR
											WHERE #TOTALS.AlertID = A.ALERT_ID AND JTD.TEMP_COMP_DATE IS NULL AND JOB_COMPLETED_DATE IS NULL)
		
		UPDATE #TOTALS
		SET PriorHoursPosted = ISNULL((SELECT SUM(EMP_HOURS) 
									FROM EMP_TIME_DTL AS ETD WITH(NOLOCK) INNER JOIN EMP_TIME AS ET WITH(NOLOCK) ON ETD.ET_ID = ET.ET_ID
								   WHERE ETD.ALERT_ID = AlertID AND ET.EMP_CODE = EmployeeCode AND EMP_DATE < @START_DATE
								   GROUP BY ET.EMP_CODE, ETD.ALERT_ID),0)

	END
	--SELECT * FROM #WEEKLY_HRS
	--SELECT * FROM #TOTALS

	INSERT INTO #WEEKLY_HRS_TOTAL
	 SELECT 
		EmployeeCode, 
		EmployeeName,
		EmployeeFirstName,
		EmployeeLastName,
		EmployeeOfficeCode,
		EmployeeOfficeName,
		EmployeeDepartmentCode,
		EmployeeDepartmentName,
		--WeekStart,
		--WeekEnd,
		SUM(HoursAvailable),
		SUM(HoursAllocated),
		0,
		SUM(HoursPosted),
		SUM(PriorHoursPosted),
		0,
		0,
		0,
		SUM(AssignmentHoursAllowed),
		SUM(TotalHoursAllocated),
		0,
		0,0,0,0
	FROM #WEEKLY_HRS WH
	GROUP BY 
		EmployeeCode, 
		EmployeeName,
		EmployeeFirstName,
		EmployeeLastName,
		EmployeeOfficeCode,
		EmployeeOfficeName,
		EmployeeDepartmentCode,
		EmployeeDepartmentName--,
		--WeekStart,
		--WeekEnd

	--SELECT Weekstart,SUM(AssignmentHoursAllowed)
	--FROM #WEEKLY_HRS WH
	--GROUP BY Weekstart	

	--SELECT * FROM @EMPLOYEES				  
	--SELECT * FROM #NON_TASK_TIME	
	DECLARE @label_text varchar(40), @advan_dtype varchar(20), @dtype_prec smallint, @dtype_scale smallint, @dtype_id smallint,@pos int, @pos2 int, @ct int,
			 @alter_sql varchar(4000), @update_sql varchar(4000), @alter_sql2 varchar(4000), @update_sql2 varchar(4000), @alter_sql3 varchar(4000), @update_sql3 varchar(4000), @alter_sql4 varchar(4000), @update_sql4 varchar(4000), @alter_sql5 varchar(4000), @update_sql5 varchar(4000), @alter_sql6 varchar(4000), @update_sql6 varchar(4000),
			 @cat varchar(10), @select_sql varchar(4000), @wkst varchar(40), @wked varchar(40), @CumulativeHourAvailable decimal(18,3), @CumulativeHourAllocated decimal(18,3), @CumulativeHourPosted decimal(18,3),@prevwkst varchar(40), @prev_label_text varchar(40), @no_of_days int,@prevwked varchar(40)
			 
	--SELECT * FROM #WEEKLY_HRS
	--SELECT * FROM #WEEKLY_HRS_TOTAL

	SET @select_sql = ''
	SET @prevwkst = ''
	SET @prevwked = ''
	SET @CumulativeHourAvailable = 0
	SET @CumulativeHourAllocated = 0
	SET @CumulativeHourPosted = 0

	CREATE TABLE #weeks(
			RowID int IDENTITY(1, 1), 
			DATE_OPENED int,
			WEEK_START Datetime,
			WEEK_END Datetime)

	set @no_of_days = datediff(dd,@START_DATE,@END_DATE_Weeks) + 1
	set rowcount @no_of_days
	select identity(int,0,1) as dy into #temp from sysobjects a, sysobjects b
	set rowcount 0

	--SELECT @START_DATE, @END_DATE

	INSERT INTO #weeks
	SELECT datepart(ww, dateadd(dd,dy,@START_DATE)) AS DATE_OPENED, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6) AS WEEK_START,
			DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@START_DATE)), 5) AS WEEK_END 
	FROM #temp
	GROUP BY datepart(ww, dateadd(dd,dy,@START_DATE)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@START_DATE)), 5)
	ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@START_DATE)), 6), datepart(ww, dateadd(dd,dy,@START_DATE)) DESC

	--SELECT * FROM #weeks

	--SELECT DISTINCT Convert(varchar(20),WeekStart,101), WeekStart
	--FROM #WEEKLY_HRS 

	DECLARE np_col_cursor CURSOR FOR 
			 SELECT RowID, WEEK_START, WEEK_END
			   FROM #weeks  	  
		   ORDER BY RowID ASC

	OPEN np_col_cursor

	FETCH NEXT FROM np_col_cursor INTO @label_text, @wkst, @wked
	
	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN	
		
		--SET @CumulativeHourAvailable += (SELECT TOP 1 ISNULL(#WEEKLY_HRS.HoursAvailable,0) FROM #WEEKLY_HRS INNER JOIN #WEEKLY_HRS_TOTAL ON #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode WHERE #WEEKLY_HRS.WeekStart = @wkst)
		--SET @CumulativeHourAllocated += (SELECT DISTINCT ISNULL(SUM(#WEEKLY_HRS.HoursAllocated),0) FROM #WEEKLY_HRS INNER JOIN #WEEKLY_HRS_TOTAL ON #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode WHERE #WEEKLY_HRS.WeekStart = @wkst)
		--SET @CumulativeHourPosted += (SELECT DISTINCT ISNULL(SUM(#WEEKLY_HRS.HoursPosted),0) FROM #WEEKLY_HRS INNER JOIN #WEEKLY_HRS_TOTAL ON #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode WHERE #WEEKLY_HRS.WeekStart = @wkst)

		--INSERT INTO

		--SELECT  @wkst, @wked

		SELECT @pos2 = ISNULL(ORDINAL_POSITION,0) FROM tempdb.information_schema.columns where table_name like '#emp_util_time_data_total%' and column_name like @label_text
		If exists (Select * from tempdb.information_schema.columns where table_name like '#WEEKLY_HRS_TOTAL%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin			
			SELECT @alter_sql = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursAvailableWeek' + @label_text + '] decimal(15,2)'		
			SELECT @alter_sql2 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursAllocatedWeek' + @label_text + '] decimal(15,2)'				
			SELECT @alter_sql4 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursPostedWeek' + @label_text + '] decimal(15,2)'					
			SELECT @alter_sql6 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursLeftWeek' + @label_text + '] decimal(15,2)'		
			SELECT @alter_sql3 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [AvailableBalanceWeek' + @label_text + '] decimal(15,2)'				
			SELECT @alter_sql5 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [BurnRateWeek' + @label_text + '] decimal(15,2)'		
			SELECT @select_sql = @select_sql + 'ISNULL([HoursAvailableWeek' + @label_text + '],0) AS [HoursAvailableWeek' + @label_text + '],'			
			SELECT @select_sql = @select_sql + 'ISNULL([HoursAllocatedWeek' + @label_text + '],0) AS [HoursAllocatedWeek' + @label_text + '],'			
			SELECT @select_sql = @select_sql + 'ISNULL([HoursPostedWeek' + @label_text + '],0) AS [HoursPostedWeek' + @label_text + '],'			
			SELECT @select_sql = @select_sql + 'ISNULL([HoursLeftWeek' + @label_text + '],0) AS [HoursLeftWeek' + @label_text + '],'		
			SELECT @select_sql = @select_sql + 'ISNULL([AvailableBalanceWeek' + @label_text + '],0) AS [AvailableBalanceWeek' + @label_text + '],'					
			SELECT @select_sql = @select_sql + 'ISNULL([BurnRateWeek' + @label_text + '],0) AS [BurnRateWeek' + @label_text + '],'									
		End
		Else
		Begin
			SELECT @alter_sql = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursAvailableWeek' + @label_text + '] decimal(15,2)'
			SELECT @alter_sql2 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursAllocatedWeek' + @label_text + '] decimal(15,2)'
			SELECT @alter_sql4 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursPostedWeek' + @label_text + '] decimal(15,2)'
			SELECT @alter_sql6 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [HoursLeftWeek' + @label_text + '] decimal(15,2)'
			SELECT @alter_sql3 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [AvailableBalanceWeek' + @label_text + '] decimal(15,2)'
			SELECT @alter_sql5 = 'ALTER TABLE #WEEKLY_HRS_TOTAL ADD [BurnRateWeek' + @label_text + '] decimal(15,2)'
			SELECT @select_sql = @select_sql + 'ISNULL([HoursAvailableWeek' + @label_text + '],0) AS [HoursAvailableWeek' + @label_text + '],'
			SELECT @select_sql = @select_sql + 'ISNULL([HoursAllocatedWeek' + @label_text + '],0) AS [HoursAllocatedWeek' + @label_text + '],'
			SELECT @select_sql = @select_sql + 'ISNULL([HoursPostedWeek' + @label_text + '],0) AS [HoursPostedWeek' + @label_text + '],'
			SELECT @select_sql = @select_sql + 'ISNULL([HoursLeftWeek' + @label_text + '],0) AS [HoursLeftWeek' + @label_text + '],'
			SELECT @select_sql = @select_sql + 'ISNULL([AvailableBalanceWeek' + @label_text + '],0) AS [AvailableBalanceWeek' + @label_text + '],'
			SELECT @select_sql = @select_sql + 'ISNULL([BurnRateWeek' + @label_text + '],0) AS [BurnRateWeek' + @label_text + '],'
		End
		--SELECT @select_sql
		If exists (Select * from tempdb.information_schema.columns where table_name like '#emp_util_time_data_total%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin			
			SELECT @update_sql = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursAvailableWeek' + @label_text + '] = '
			SELECT @update_sql2 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursAllocatedWeek' + @label_text + '] = '
			SELECT @update_sql4 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursPostedWeek' + @label_text + '] = ' 
			SELECT @update_sql6 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursLeftWeek' + @label_text + '] = ' 
			SELECT @update_sql3 = 'UPDATE #WEEKLY_HRS_TOTAL SET [AvailableBalanceWeek' + @label_text + '] = '
			SELECT @update_sql5 = 'UPDATE #WEEKLY_HRS_TOTAL SET [BurnRateWeek' + @label_text + '] = ' 
		End
		Else
		Begin
			SELECT @update_sql = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursAvailableWeek' + @label_text + '] = '
			SELECT @update_sql2 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursAllocatedWeek' + @label_text + '] = '
			SELECT @update_sql4 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursPostedWeek' + @label_text + '] = '
			SELECT @update_sql6 = 'UPDATE #WEEKLY_HRS_TOTAL SET [HoursLeftWeek' + @label_text + '] = '
			SELECT @update_sql3 = 'UPDATE #WEEKLY_HRS_TOTAL SET [AvailableBalanceWeek' + @label_text + '] = '
			SELECT @update_sql5 = 'UPDATE #WEEKLY_HRS_TOTAL SET [BurnRateWeek' + @label_text + '] = '
		End		
		
		SELECT @select_sql = @select_sql + ''

		SELECT @alter_sql = @alter_sql + ' NULL'
		SELECT @alter_sql2 = @alter_sql2 + ' NULL'
		SELECT @alter_sql3 = @alter_sql3 + ' NULL'
		SELECT @alter_sql4 = @alter_sql4 + ' NULL'
		SELECT @alter_sql5 = @alter_sql5 + ' NULL'
		SELECT @alter_sql6 = @alter_sql6 + ' NULL'

		SELECT @update_sql = @update_sql + 'ISNULL((SELECT SUM(STD_HOURS) ' 
		SELECT @update_sql = @update_sql + '	  FROM #NON_TASK_TIME '	
		SELECT @update_sql = @update_sql + '	 WHERE (Workday BETWEEN ''' + @wkst + ''' AND ''' + @wked + ''') AND #NON_TASK_TIME.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql = @update_sql + '	 ),0)'

		SELECT @update_sql2 = @update_sql2 + 'ISNULL((SELECT ISNULL(SUM(HoursAllocated),0) ' 
		SELECT @update_sql2 = @update_sql2 + '	  FROM #WEEKLY_HRS '	
		SELECT @update_sql2 = @update_sql2 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql2 = @update_sql2 + '	 GROUP BY WeekStart,EmployeeCode),0)'
		
		SELECT @update_sql3 = @update_sql3 + 'ISNULL((SELECT SUM(STD_HOURS) ' 
		SELECT @update_sql3 = @update_sql3 + '	  FROM #NON_TASK_TIME '	
		SELECT @update_sql3 = @update_sql3 + '	 WHERE (Workday BETWEEN ''' + @wkst + ''' AND ''' + @wked + ''') AND #NON_TASK_TIME.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql3 = @update_sql3 + '	 ),0) - '
		SELECT @update_sql3 = @update_sql3 + 'ISNULL((SELECT ISNULL(SUM(HoursAllocated),0) ' 
		SELECT @update_sql3 = @update_sql3 + '	  FROM #WEEKLY_HRS '	
		SELECT @update_sql3 = @update_sql3 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql3 = @update_sql3 + '	 GROUP BY WeekStart,EmployeeCode),0)'
		--SELECT @update_sql3 = @update_sql3 + 'ISNULL((SELECT ISNULL(SUM(HoursPosted),0) ' 
		--SELECT @update_sql3 = @update_sql3 + '	  FROM #WEEKLY_HRS '	
		--SELECT @update_sql3 = @update_sql3 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		--SELECT @update_sql3 = @update_sql3 + '	 GROUP BY WeekStart,EmployeeCode),0)'


		SELECT @update_sql4 = @update_sql4 + 'ISNULL((SELECT ISNULL(SUM(HoursPosted),0) ' 
		SELECT @update_sql4 = @update_sql4 + '	  FROM #WEEKLY_HRS '	
		SELECT @update_sql4 = @update_sql4 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql4 = @update_sql4 + '	 GROUP BY WeekStart,EmployeeCode),0)'	

		--SELECT @update_sql = @update_sql + 'ISNULL((SELECT HoursAvailable ' 
		--SELECT @update_sql = @update_sql + '	  FROM #WEEKLY_HRS_NUM '	
		--SELECT @update_sql = @update_sql + '	 WHERE #WEEKLY_HRS_NUM.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS_NUM.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		--SELECT @update_sql = @update_sql + '	 ),0)'

		--SELECT @update_sql2 = @update_sql2 + 'ISNULL((SELECT HoursAllocated ' 
		--SELECT @update_sql2 = @update_sql2 + '	  FROM #WEEKLY_HRS_NUM '	
		--SELECT @update_sql2 = @update_sql2 + '	 WHERE #WEEKLY_HRS_NUM.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS_NUM.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode),0)'

		--SELECT @update_sql3 = @update_sql3 + 'ISNULL((SELECT HoursAvailable - HoursAllocated' 
		--SELECT @update_sql3 = @update_sql3 + '	  FROM #WEEKLY_HRS_NUM '	
		--SELECT @update_sql3 = @update_sql3 + '	 WHERE #WEEKLY_HRS_NUM.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS_NUM.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		--SELECT @update_sql3 = @update_sql3 + '	 ),0)'

		--SELECT @update_sql4 = @update_sql4 + 'ISNULL((SELECT HoursPosted ' 
		--SELECT @update_sql4 = @update_sql4 + '	  FROM #WEEKLY_HRS_NUM '	
		--SELECT @update_sql4 = @update_sql4 + '	 WHERE #WEEKLY_HRS_NUM.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS_NUM.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode),0)'		

		SELECT @update_sql5 = @update_sql5 + 'ISNULL((SELECT CASE WHEN HoursAllocated > 0 THEN (HoursPosted/HoursAllocated) ELSE 0 END ' 
		SELECT @update_sql5 = @update_sql5 + '	  FROM #WEEKLY_HRS_NUM '	
		SELECT @update_sql5 = @update_sql5 + '	 WHERE #WEEKLY_HRS_NUM.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS_NUM.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode),0)'
		
		SELECT @update_sql6 = @update_sql6 + 'ISNULL((SELECT SUM(STD_HOURS) ' 
		SELECT @update_sql6 = @update_sql6 + '	  FROM #NON_TASK_TIME '	
		SELECT @update_sql6 = @update_sql6 + '	 WHERE (Workday BETWEEN ''' + @wkst + ''' AND ''' + @wked + ''') AND #NON_TASK_TIME.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql6 = @update_sql6 + '	 ),0) - '
		SELECT @update_sql6 = @update_sql6 + 'ISNULL((SELECT ISNULL(SUM(HoursAllocated),0) ' 
		SELECT @update_sql6 = @update_sql6 + '	  FROM #WEEKLY_HRS '	
		SELECT @update_sql6 = @update_sql6 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql6 = @update_sql6 + '	 ),0) - '
		SELECT @update_sql6 = @update_sql6 + 'ISNULL((SELECT ISNULL(SUM(HoursPosted),0) ' 
		SELECT @update_sql6 = @update_sql6 + '	  FROM #WEEKLY_HRS '	
		SELECT @update_sql6 = @update_sql6 + '	 WHERE #WEEKLY_HRS.WeekStart = ''' + @wkst + ''' AND #WEEKLY_HRS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode'
		SELECT @update_sql6 = @update_sql6 + '	 GROUP BY WeekStart,EmployeeCode),0)'

		
		
					
				
		--PRINT @alter_sql;
		PRINT @update_sql;
		PRINT @update_sql2;
		PRINT @update_sql3;
		PRINT @update_sql4;
		PRINT @update_sql5;

		BEGIN TRY
			EXECUTE ( @alter_sql )
			EXECUTE ( @alter_sql2 )
			EXECUTE ( @alter_sql3 )
			EXECUTE ( @alter_sql4 )
			EXECUTE ( @alter_sql6 )
			EXECUTE ( @alter_sql5 )
		END TRY
		
		BEGIN CATCH
			GOTO FNEXT
		END CATCH
		
		FNEXT:
		EXECUTE ( @update_sql )
		EXECUTE ( @update_sql2 )
		EXECUTE ( @update_sql3 )
		EXECUTE ( @update_sql4 )
		EXECUTE ( @update_sql5 )
		EXECUTE ( @update_sql6 )
		
		--SET @ct = @ct + 1
		--SELECT @pos,@pos2
		--SELECT @label_text, @cat
		SET @prevwkst = @wkst
		SET @prevwked = @wked
		FETCH NEXT FROM np_col_cursor INTO @label_text, @wkst, @wked
	END

	CLOSE np_col_cursor
	DEALLOCATE np_col_cursor
	PRINT (@select_sql)
	IF @select_sql <> ''
	BEGIN
		SET @select_sql = LEFT(@select_sql, LEN(@select_sql) - 1)
	END

	--SELECT * FROM #WEEKLY_HRS_TOTAL
	--SELECT * FROM #NON_TASK_TIME
	
	--Hours Available
    UPDATE #WEEKLY_HRS_TOTAL
    SET HoursAvailable = (SELECT SUM(STD_HOURS) FROM #NON_TASK_TIME WHERE EmployeeCode = EMP_CODE) - (SELECT SUM(TOTAL_HOURS) FROM #NON_TASK_TIME WHERE EmployeeCode = EMP_CODE)
    FROM
	   #EMPLOYEES E
	   INNER JOIN #WEEKLY_HRS_TOTAL WH ON E.EMP_CODE = WH.EmployeeCode;    

	UPDATE #WEEKLY_HRS_TOTAL SET HoursPostedTask = (ISNULL((SELECT SUM(EMP_HOURS) 
									FROM EMP_TIME_DTL AS ETD WITH(NOLOCK) INNER JOIN 
									     EMP_TIME AS ET WITH(NOLOCK) ON ETD.ET_ID = ET.ET_ID INNER JOIN
												JOB_COMPONENT WITH(NOLOCK) ON ETD.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
												ETD.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
												JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
												JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR LEFT OUTER JOIN
												ALERT AS A WITH(NOLOCK) ON A.ALERT_ID = ETD.ALERT_ID
								   WHERE ET.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND ETD.ALERT_ID NOT IN (SELECT DISTINCT ISNULL(AlertID,0) FROM #WEEKLY_HRS) AND ETD.ALERT_ID IS NOT NULL
										 --AND ETD.ALERT_ID NOT IN (SELECT ALERT.ALERT_ID FROM V_JOB_TRAFFIC_DET JTD INNER JOIN
											--									ALERT ON ALERT.JOB_NUMBER = JTD.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTD.SEQ_NBR WHERE ALERT.ALERT_ID = A.ALERT_ID)
								   GROUP BY ET.EMP_CODE),0)) 

	UPDATE #WEEKLY_HRS_TOTAL SET HoursAllowedTask = (ISNULL((SELECT SUM(JOB_HRS) 
											FROM V_JOB_TRAFFIC_DET INNER JOIN
												JOB_COMPONENT WITH(NOLOCK) ON V_JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
												V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
												JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
												JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
										   WHERE V_JOB_TRAFFIC_DET.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
												 AND (V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL)
										   GROUP BY V_JOB_TRAFFIC_DET.EMP_CODE),0))	 

	UPDATE #WEEKLY_HRS_TOTAL SET HoursAllowedOpen = (ISNULL((SELECT SUM(ALERT.HRS_ALLOWED)
														FROM ALERT WITH(NOLOCK) INNER JOIN
															 ALERT_RCPT WITH(NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID LEFT OUTER JOIN
															 JOB_COMPONENT WITH(NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
															 ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
															 JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
															 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
														WHERE ALERT_RCPT.EMP_CODE = #WEEKLY_HRS_TOTAL.EmployeeCode AND IS_WORK_ITEM = 1 AND ALERT_LEVEL <> 'BRD' 
														AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND ISNULL(ASSIGN_COMPLETED,0) <> 1 AND BOARD_STATE_ID IS NULL),0))	 

    
    BEGIN
	   UPDATE #WEEKLY_HRS_TOTAL SET AvailableBalance = ISNULL(HoursAvailable, 0.00) - ISNULL(HoursAllocated, 0.00)
    END

	UPDATE #WEEKLY_HRS_TOTAL
	SET EmployeeOfficeName = (SELECT OFFICE_NAME FROM OFFICE O WHERE O.OFFICE_CODE = EmployeeOfficeCode)

	UPDATE #WEEKLY_HRS_TOTAL
	SET EmployeeDepartmentName = (SELECT DP_TM_DESC FROM DEPT_TEAM D WHERE D.DP_TM_CODE = EmployeeDepartmentCode)

	UPDATE #WEEKLY_HRS_TOTAL
	SET AssignmentHoursAllowed = (SELECT SUM(AssignmentHoursAllowed) FROM #TOTALS WHERE #TOTALS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode GROUP BY #TOTALS.EmployeeCode)-- + HoursAllowedOpen

	UPDATE #WEEKLY_HRS_TOTAL SET PriorHoursPosted = (SELECT SUM(PriorHoursPosted) FROM #TOTALS WHERE #TOTALS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode GROUP BY #TOTALS.EmployeeCode)

	-- Allocated Balance
    BEGIN
	   UPDATE #WEEKLY_HRS_TOTAL SET AllocatedBalance = ISNULL(AssignmentHoursAllowed, 0.00) + ISNULL(HoursAllowedTask, 0.00) - ISNULL(HoursPosted, 0.00) - ISNULL(HoursPostedTask, 0.00)
    END

	UPDATE #WEEKLY_HRS_TOTAL
	SET TotalHoursAllocated = (SELECT SUM(TotalHoursAllocated) FROM #TOTALS WHERE #TOTALS.EmployeeCode = #WEEKLY_HRS_TOTAL.EmployeeCode GROUP BY #TOTALS.EmployeeCode)
		
	UPDATE #WEEKLY_HRS_TOTAL SET HoursAllocatedBalance = ISNULL(AssignmentHoursAllowed, 0.00) + HoursAllowedTask - ISNULL(HoursAllocated, 0.00)
    
	UPDATE #WEEKLY_HRS_TOTAL SET PriorHoursAllocated = (SELECT ISNULL(SUM([HOURS]),0) FROM SPRINT_EMPLOYEE SE WITH(NOLOCK) WHERE EmployeeCode = SE.EMP_CODE AND WEEK_START < @START_DATE)
	
	UPDATE #WEEKLY_HRS_TOTAL SET BurnRate = CASE WHEN AssignmentHoursAllowed > 0 THEN (HoursPosted - HoursPostedTask) / (AssignmentHoursAllowed + HoursAllowedTask) ELSE 0 END
	
	
	--SELECT 
	--   WH.*
 --   FROM
	--   #WEEKLY_HRS_TOTAL WH
    

	
	SELECT @sql = 'SELECT ID, EmployeeCode,EmployeeName as Employee,EmployeeFirstName,EmployeeLastName,EmployeeOfficeCode AS OfficeCode,
		EmployeeOfficeName AS Office,EmployeeDepartmentCode AS DepartmentCode,EmployeeDepartmentName AS Department,	
		AssignmentHoursAllowed + HoursAllowedTask AS HoursAllowed,
		HoursAllocated,
		HoursAllocatedBalance AS AllocatedBalance,		
		HoursPosted + HoursPostedTask AS HoursPosted,
		CASE WHEN AllocatedBalance < 0 THEN 0 ELSE AllocatedBalance END AS HoursLeft,BurnRate'
			if @select_sql <> ''
			Begin
				SELECT @sql = @sql + ', ' + @select_sql
			End

		SELECT @sql = @sql + '   FROM #WEEKLY_HRS_TOTAL ORDER BY EmployeeName'
		PRINT @sql
		EXEC(@sql)	

    --SELECT 
	   --WH.*
    --FROM
	   --#WEEKLY_HRS_TOTAL WH
    --ORDER BY
	   --WH.EmployeeName
END
/*=========== QUERY ===========*/