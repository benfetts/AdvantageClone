

/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_workload] 
@UserID 	VarChar(100),
@EmpCode 	Varchar(6),
@start_date 	SmallDatetime,
@end_date 	SmallDatetime,
@OfficeCode		varchar(4),
@ClientCode 	Varchar(6),
@DivisionCode 	Varchar(6),
@ProductCode 	Varchar(6),
@JobNum 	Varchar(6),
@JobComp 	Varchar(6),
@ROLES 		VarChar(8000),
@TaskStatus 	Varchar(1),
@ExcludeTempComplete Char(1),
@Manager varchar(6),
@DeptCodes Varchar(8000)

AS






If @OfficeCode IS NULL 
	set @OfficeCode = ''

If @ClientCode IS NULL 
	set @ClientCode = ''	

If	@DivisionCode IS NULL 
	set @DivisionCode = '' 	
	
If	@ProductCode  IS NULL 
	set @ProductCode = ''
		
If	@JobNum  IS NULL 
	set @JobNum = ''	
	
If	@JobComp  IS NULL 
	set @JobComp = ''	
	
If	@ROLES  IS NULL 
	set @ROLES = ''	
		
If	@TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If	@ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = ''

If	@EmpCode IS NULL OR @EmpCode = '%' 
	set @EmpCode = ''
	
If	@Manager  IS NULL OR @Manager = '%' 
	set @Manager = ''

If @DeptCodes IS NULL
	SET @DeptCodes = ''		

Declare @Restrictions 	Int,
	@RestrictionsEmp Int,
	@totaljobsdue 	Int,
	@totaljobsopentasks Int,
	@opentasks 	Int,
	@totalhoursneeded decimal(15,2),
	@hoursallocated decimal(15,2),
	@hoursoff 	decimal(15,2),
	@appthours 	decimal(15,2),
	@holidayhours 	decimal(15,2)

DECLARE @sql 		varchar(4000)
DECLARE @sql_from 	varchar(4000)
DECLARE @sql_where 	varchar(4000)
DECLARE @StartDate 	varchar(12)
DECLARE @EndDate 	varchar(12)


SELECT @StartDate = CAST(@start_date AS Varchar(12))
SELECT @EndDate = CAST(@end_date AS Varchar(12))

CREATE TABLE #workload_rows( 	
	TOTAL_JOBS_DUE		int NULL,
	TOTAL_JOBS_OPEN_TASKS	int NULL,
	OPEN_TASKS      	int NULL,
	TOTAL_HOURS_NEEDED	decimal(15,2) NULL,
	HOURS_ALLOCATED  	decimal(15,2) NULL,
	HOURS_OFF		decimal(15,2) NULL,
	HOLIDAY_HOURS		decimal(15,2) NULL,
	APPT_HOURS		decimal(15,2) NULL	
)

CREATE TABLE #TMP( CT decimal(15,2) NULL)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)


--Total Jobs Due (0)--

SELECT @sql = 'INSERT INTO #TMP '
SELECT @sql = @sql + ' SELECT COUNT(JOB_COMPONENT.JOB_COMPONENT_NBR) '

SELECT @sql_from = ' FROM JOB_COMPONENT 
		INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
		LEFT OUTER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
		                      AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR '

SELECT @sql_where = ' WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
			AND  JOB_COMPONENT.JOB_FIRST_USE_DATE between ''' + @StartDate + ''' AND ''' + @EndDate + '''
			AND JOB_TRAFFIC.TRF_CODE IS NOT NULL '

if @Restrictions > 0	
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
	  		AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
	  		AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

if @RestrictionsEmp > 0	
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON JOB_COMPONENT.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @OfficeCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivisionCode + ''''

If @ProductCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProductCode + ''''

If @JobNum <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNum + ''''

If @JobComp  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + ''''
	
If @Manager <> ''
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '

	
--If @EmpCode <> ''  DO NOT apply employee filter in summary
--	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.EMP_CODE = ''' + @EmpCode + ''''

 
SELECT @sql = @sql + @sql_from + @sql_where

EXEC(@sql)

SELECT @totaljobsdue = CT FROM #TMP


--*************************************
--Total jobs with Open Tasks (1) --

DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
SELECT @sql = @sql + ' SELECT COUNT(*) FROM (SELECT JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR '

SELECT @sql_from = ' FROM JOB_COMPONENT 
	INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
       	       AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
               AND JOB_TRAFFIC.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR 
	INNER JOIN  JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER '
--	LEFT OUTER JOIN TASK_TRAFFIC_ROLE ON TASK_TRAFFIC_ROLE.TRF_CODE = JOB_TRAFFIC_DET.FNC_CODE
--	FULL OUTER JOIN EMP_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
--		AND TASK_TRAFFIC_ROLE.ROLE_CODE = EMP_TRAFFIC_ROLE.ROLE_CODE 

SELECT @sql_where = ' WHERE  
(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL)
	AND V_JOB_TRAFFIC_DET.JOB_REVISED_DATE BETWEEN ''' + @StartDate + ''' AND  ''' + @EndDate + ''''

If @Restrictions > 0	
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
               		AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	End
If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End

--If @Role <> '' DO NOT apply role or employee filters here
--	SELECT @sql_where = @sql_where + ' AND ( TASK_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''' OR EMP_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''')' 
--If @EmpCode <> '' 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''''
	
If @OfficeCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivisionCode + ''''

If @ProductCode  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProductCode + ''''

If @JobNum <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' +  @JobNum + ''''

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' +  @JobComp + ''''
	
If @Manager <> ''
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '

--If @TaskStatus <> '' 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TASK_STATUS = ''' +  @TaskStatus + ''''						 
--if @ExcludeTempComplete = 'Y'
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

SELECT @sql = @sql + @sql_from + @sql_where

SELECT @sql = @sql + ' GROUP BY JOB_COMPONENT.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR) A'

EXEC(@sql)

SELECT @totaljobsopentasks = CT FROM #TMP


--*************************************
--Open Task Assignments Due (2) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
--SELECT @sql = @sql + ' SELECT COUNT(A.OPEN_TASKS) FROM (SELECT COUNT(JOB_COMPONENT.JOB_NUMBER) AS OPEN_TASKS '
SELECT @sql = @sql + ' SELECT COUNT(JOB_COMPONENT.JOB_NUMBER) '

SELECT @sql_from = ' FROM JOB_COMPONENT 
	INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR 
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
		AND JOB_TRAFFIC.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR 
	INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER  '

SELECT @sql_where = ' WHERE 
		(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
		(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL)
		AND V_JOB_TRAFFIC_DET.EMP_CODE IS NOT NULL
		AND V_JOB_TRAFFIC_DET.JOB_REVISED_DATE BETWEEN ''' + @StartDate + ''' AND  ''' + @EndDate + '''' 
 
If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
		AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @ROLES <> '' 
	Begin
	  SELECT @sql_from = @sql_from + '
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
	End
If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End
				
If @EmpCode <> '' 
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''''
	
If @OfficeCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivisionCode + ''''

If @ProductCode  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProductCode + ''''
 
If @JobNum <> '' 										  
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNum + ''''

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + ''''
	
If @Manager <> ''
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '

--If @TaskStatus <> '' 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
--If @ExcludeTempComplete = 'Y'																	 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '


SELECT @sql = @sql + @sql_from + @sql_where

--SELECT @sql = @sql + ' GROUP BY JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
 --                     JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.JOB_HRS, JOB_TRAFFIC_DET.JOB_NUMBER, 
 --                     JOB_TRAFFIC_DET.JOB_COMPONENT_NBR) A'
EXEC(@sql)

SELECT @opentasks = CT FROM #TMP


--*************************************
--Total Hours Needed to Complete Tasks (Task Hours Unassigned) (3) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
--SELECT @sql = @sql + ' SELECT SUM(A.TOTAL_HOURS_NEEDED) FROM (SELECT JOB_TRAFFIC_DET.JOB_HRS AS TOTAL_HOURS_NEEDED '
SELECT @sql = @sql + ' SELECT SUM(V_JOB_TRAFFIC_DET.JOB_HRS)  '

SELECT @sql_from = ' FROM JOB_COMPONENT 
	INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
		AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
               AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR 
	INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER '

SELECT @sql_where = ' WHERE  
		(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
		(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL)
	AND V_JOB_TRAFFIC_DET.EMP_CODE IS NULL 
	AND V_JOB_TRAFFIC_DET.JOB_REVISED_DATE BETWEEN ''' + @StartDate + ''' AND  ''' + @EndDate + ''''  					

If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
       		AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	End

-- Task Only, because no employees
If @ROLES <> '' AND @ROLES IS NOT NULL
	Begin
	  SELECT @sql_from = @sql_from + ' LEFT OUTER JOIN TASK_TRAFFIC_ROLE ON TASK_TRAFFIC_ROLE.TRF_CODE = V_JOB_TRAFFIC_DET.FNC_CODE '
		
	  SELECT @sql_where = @sql_where + ' AND (TASK_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 		
	 End
If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End

If @OfficeCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivisionCode + ''''

If @ProductCode  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProductCode + '''' 
									  
If @JobNum <> '' 										  
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNum + ''''

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + ''''
	
If @Manager <> ''
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '

--If @TaskStatus <> '' 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
--If @ExcludeTempComplete = 'Y'																	 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL ' 


SELECT @sql = @sql + @sql_from + @sql_where
					
--SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, 
 --                     JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, STR(DATEPART(day, 
 --                     JOB_TRAFFIC_DET.TASK_START_DATE)), STR(DATEPART(day, JOB_TRAFFIC_DET.JOB_REVISED_DATE)), 
 --                     ISNULL(JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''('' + JOB_TRAFFIC_DET.FNC_CODE + '')''), JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
 --                     JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.TASK_STATUS, 
 --                     JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.JOB_HRS) A'

EXEC(@sql)

SELECT @totalhoursneeded =  CT FROM #TMP


--*************************************
--Hours Allocated to Jobs (Hours Assigned to Tasks) (5) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
--SELECT @sql = @sql + ' SELECT SUM(A.HOURS_ALLOCATED) FROM (SELECT JOB_TRAFFIC_DET.JOB_HRS AS HOURS_ALLOCATED '
SELECT @sql = @sql + ' SELECT SUM(V_JOB_TRAFFIC_DET.JOB_HRS) '

SELECT @sql_from = ' FROM JOB_COMPONENT 
	INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
			   AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
               AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR 
	INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER '

SELECT @sql_where = ' WHERE 
		(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
		(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL)
AND
V_JOB_TRAFFIC_DET.JOB_REVISED_DATE BETWEEN ''' + @StartDate + ''' AND  ''' + @EndDate + ''''  					

If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
       		AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @ROLES <> ''
	Begin
	  SELECT @sql_from = @sql_from + '
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
	  	End
If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End

If @OfficeCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivisionCode + ''''

If @ProductCode  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProductCode + '''' 
									  
If @JobNum <> '' 									  
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNum + ''''

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + ''''
	
If @EmpCode <> '' 
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''''
	
If @Manager <> ''
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '

--If @TaskStatus <> '' 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
--If @ExcludeTempComplete = 'Y'																	 
--	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL ' 


SELECT @sql = @sql + @sql_from + @sql_where
					
--SELECT @sql = @sql + ' GROUP BY JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
 --                     JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.JOB_HRS, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR) A '

EXEC(@sql)

SELECT @hoursallocated = CT FROM #TMP


--*************************************
--Hours Off (6) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
SELECT @sql = @sql + ' SELECT SUM(A.HOURS) AS HOURS_OFF FROM (
			SELECT EMP_NON_TASKS.TYPE, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, EMP_NON_TASKS.ALL_DAY, 
CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 AND EMP_NON_TASKS.HOURS = 0.00 THEN 8 ELSE EMP_NON_TASKS.HOURS END AS HOURS '

SELECT @sql_from = ' FROM EMP_NON_TASKS 
 INNER JOIN TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY AND VAC_SICK_FLAG IN (1,2,3) '

SELECT @sql_where = ' WHERE TYPE = ''A'' 
                        AND  EMP_NON_TASKS.START_DATE >= ''' + @StartDate + ''' AND END_DATE <= ''' + @EndDate + ''''

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON EMP_NON_TASKS.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @EmpCode <> ''
	SELECT @sql_where = @sql_where + ' AND ( EMP_NON_TASKS.EMP_CODE = ''' + @EmpCode + ''' OR EMP_NON_TASKS.EMP_CODE IS NULL )'


If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON EMP_NON_TASKS.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End

If @ROLES <> '' 
    Begin
	  SELECT @sql_from = @sql_from + ' LEFT OUTER JOIN EMP_TRAFFIC_ROLE ON EMP_NON_TASKS.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '	

	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
    End
	
--SELECT @sql_where = @sql_where + ') A'

SELECT @sql = @sql + @sql_from + @sql_where

SELECT @sql = @sql + ' GROUP BY EMP_NON_TASKS.EMP_CODE, EMP_NON_TASKS.TYPE, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, 
     EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.HOURS ) A'


			
EXEC(@sql)

SELECT @hoursoff = CT FROM #TMP

--*************************************
--Appt Hours Off (8) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
SELECT @sql = @sql + ' SELECT SUM(A.HOURS) AS HOURS_OFF FROM (
			SELECT EMP_NON_TASKS.TYPE, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, EMP_NON_TASKS.ALL_DAY, 
CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 AND EMP_NON_TASKS.HOURS = 0.00 THEN 8 ELSE EMP_NON_TASKS.HOURS END AS HOURS '

SELECT @sql_from = ' FROM EMP_NON_TASKS 
 LEFT OUTER JOIN TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY '

SELECT @sql_where = ' WHERE TYPE = ''A'' AND (TIME_CATEGORY.VAC_SICK_FLAG NOT IN (1, 2, 3) OR TIME_CATEGORY.VAC_SICK_FLAG IS NULL)
                        AND  EMP_NON_TASKS.START_DATE >= ''' + @StartDate + ''' AND END_DATE <= ''' + @EndDate + ''''

If @RestrictionsEmp > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON EMP_NON_TASKS.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @EmpCode <> ''
	SELECT @sql_where = @sql_where + ' AND ( EMP_NON_TASKS.EMP_CODE = ''' + @EmpCode + ''' OR EMP_NON_TASKS.EMP_CODE IS NULL )'


If @DeptCodes <> '' 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMP_DP_TM ON EMP_NON_TASKS.EMP_CODE = EMP_DP_TM.EMP_CODE '
	
      SELECT @sql_where = @sql_where + ' And EMP_DP_TM.DP_TM_CODE IN (' + @DeptCodes + ') '
    End

If @ROLES <> '' 
    Begin
	  SELECT @sql_from = @sql_from + ' LEFT OUTER JOIN EMP_TRAFFIC_ROLE ON EMP_NON_TASKS.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '	

	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
    End
	
SELECT @sql_where = @sql_where + ') A'

SELECT @sql = @sql + @sql_from + @sql_where

--SELECT @sql = @sql + ' GROUP BY EMP_NON_TASKS.EMP_CODE, EMP_NON_TASKS.TYPE, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, 
--     EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.HOURS ) A'


PRINT(@sql)			
EXEC(@sql)

SELECT @appthours = CT FROM #TMP

--*************************************
--Holidays (7) --
DELETE #TMP

SELECT @sql = 'INSERT INTO #TMP '
SELECT @sql = @sql + ' SELECT SUM(A.HOURS) FROM (
		SELECT  CASE WHEN ALL_DAY = 1 AND HOURS = 0.00 THEN 8 ELSE HOURS END AS HOURS
		FROM  EMP_NON_TASKS
		WHERE START_DATE >= ''' + @StartDate + ''' AND END_DATE <= ''' + @EndDate + ''' AND TYPE = ''H'' ) A'

EXEC(@sql)
SELECT @holidayhours = CT FROM #TMP


INSERT INTO #workload_rows
VALUES(ISNULL(@totaljobsdue, 0), ISNULL(@totaljobsopentasks, 0), ISNULL(@opentasks, 0), ISNULL(@totalhoursneeded, 0), ISNULL(@hoursallocated, 0), ISNULL(@hoursoff, 0.0), ISNULL(@holidayhours, 0.0), ISNULL(@appthours, 0.0))

SELECT * FROM #workload_rows


DROP TABLE #workload_rows
DROP TABLE #TMP








