IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_calendar_task_month]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_calendar_task_month]
GO

/*****************************************************************************************
Webvantage
This Stored Procedure gets  Tasks
Use @GrpLevel = '0' if all tasks are to go into each month
Use @GrpLevel = (1,2,3,4,5) to group by cl/div/prd/job/comp into separate months
********************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_task_month] 
@UserID VarChar(100),
@EmpCode Varchar(6),
@OfficeCode varchar(4),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@ROLES VarChar(8000),
@StartDate SMALLDATETIME,
@EndDate  SMALLDATETIME,
@TaskStatus Varchar(1),
@ExcludeTempComplete Char(1),
@MilestonesOnly Char(1),
@Manager VarChar(6),
@GrpLevel VarChar(1),
@DEPTS VARCHAR(8000),
@TRF_CODE VARCHAR(10),
@FuncRoles VarChar(8000)
AS


DECLARE @Restrictions 	Int
DECLARE @RestrictionsEmp Int
DECLARE @sql 		varchar(8000)
DECLARE @sql_from 	varchar(8000)
DECLARE @sql_where 	varchar(8000)

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

If @OfficeCode IS NULL 
	set @OfficeCode = ''
	
If @ClientCode IS NULL 
	set @ClientCode = ''	

If @DivCode IS NULL 
	set @DivCode = '' 	
	
If @ProdCode  IS NULL 
	set @ProdCode = ''
		
If @JobNumber  IS NULL 
	set @JobNumber = ''	
	
If @JobComp  IS NULL 
	set @JobComp = ''	
	
If @ROLES  IS NULL 
	set @ROLES = ''	
		
If @TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If @ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = 'N'

If @EmpCode  IS NULL 
	set @EmpCode = ''
	
If @Manager  IS NULL 
	set @Manager = ''
	
IF @DEPTS IS NULL
BEGIN
    SET @DEPTS = ''
END
IF @TRF_CODE IS NULL
BEGIN
	SET @TRF_CODE = '';
END



Set NoCount On

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)


--set @sql = ' DECLARE @ParentTasks TABLE (JOB_NUMBER VARCHAR(20));

--INSERT INTO @ParentTasks 
--SELECT DISTINCT CAST(JOB_TRAFFIC_DET.JOB_NUMBER AS VARCHAR) + ''/'' + CAST(JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS VARCHAR) + ''/'' + CAST(PARENT_TASK_SEQ AS VARCHAR)
--FROM dbo.JOB_TRAFFIC_DET INNER JOIN JOB_COMPONENT ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
--INNER JOIN JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
-- WHERE PARENT_TASK_SEQ IS NOT NULL AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND ((CONVERT(Date,JOB_TRAFFIC_DET.JOB_REVISED_DATE) BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
--			OR (CONVERT(Date,JOB_TRAFFIC_DET.TASK_START_DATE) BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
--			OR (''' + CAST(@StartDate AS VARCHAR) + ''' >= CONVERT(Date,JOB_TRAFFIC_DET.TASK_START_DATE) AND ''' + CAST(@EndDate AS VARCHAR) + ''' <= CONVERT(Date,JOB_TRAFFIC_DET.JOB_REVISED_DATE)))'


set  @sql = ' SELECT JOB_LOG.CL_CODE as CCode,
	JOB_LOG.DIV_CODE as DCode,
	JOB_LOG.PRD_CODE as PCode,
	JOB_LOG.JOB_NUMBER as JobNum,
	JOB_LOG.JOB_DESC as JobDesc,
	JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
	JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
	STR(DATEPART(day, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)) as ThisDay,
	isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''('' + ISNULL(V_JOB_TRAFFIC_DET.FNC_CODE,'''') + '')'') as Task, 
	isnull(V_JOB_TRAFFIC_DET.TEMP_COMP_DATE, ''1/1/1900'') as TempCompDate,
	V_JOB_TRAFFIC_DET.TASK_STATUS, STR(DATEPART(day, V_JOB_TRAFFIC_DET.TASK_START_DATE)) as ThisDayStart, V_JOB_TRAFFIC_DET.SEQ_NBR,
	CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION, TRAFFIC_FNC.TRF_CODE, CONVERT(Date,V_JOB_TRAFFIC_DET.JOB_REVISED_DATE) as RevisedDate, 
	isnull(CONVERT(Date,V_JOB_TRAFFIC_DET.TASK_START_DATE), ''1/1/1900'') as StartDate,
	isnull(V_JOB_TRAFFIC_DET.EMP_CODE,'''') as empcodedispl,
	isnull(dbo.udf_get_empl_name( V_JOB_TRAFFIC_DET.EMP_CODE, ''FML'' ),'''') AS empdescdispl, 
	TRAFFIC.TRF_DESCRIPTION, ISNULL(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME, '''') AS DUE_TIME '


set @sql_from = ' FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
	       AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
	INNER JOIN DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE 
	INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
	LEFT OUTER JOIN TRAFFIC_FNC ON V_JOB_TRAFFIC_DET.FNC_CODE = TRAFFIC_FNC.TRF_CODE 
	INNER JOIN JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
	INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE '

SELECT @sql_where = ' WHERE 
(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
			AND ((CONVERT(Date,V_JOB_TRAFFIC_DET.JOB_REVISED_DATE) BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
			OR (CONVERT(Date,V_JOB_TRAFFIC_DET.TASK_START_DATE) BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
			OR (''' + CAST(@StartDate AS VARCHAR) + ''' >= CONVERT(Date,V_JOB_TRAFFIC_DET.TASK_START_DATE) AND ''' + CAST(@EndDate AS VARCHAR) + ''' <= CONVERT(Date,V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)))'
			--AND CAST(V_JOB_TRAFFIC_DET.JOB_NUMBER AS VARCHAR) + ''/'' + CAST(V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS VARCHAR) + ''/'' + CAST(V_JOB_TRAFFIC_DET.SEQ_NBR AS VARCHAR) NOT IN (SELECT JOB_NUMBER FROM @ParentTasks)'
	
If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

If @RestrictionsEmp > 0 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	  --SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE IS NULL) '
	End

If @RestrictionsOffice > 0 
	Begin
	  SELECT @sql_from = @sql_from  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
	End	
	
If @Manager <> ''
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC JT ON JOB_COMPONENT.JOB_NUMBER = JT.JOB_NUMBER 
	       AND JOB_COMPONENT.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR '
	
	  SELECT @sql_where = @sql_where + ' AND JT.MGR_EMP_CODE = ''' + @Manager + ''' '
	End

If @ROLES <> ''
	Begin
	  SELECT @sql_from = @sql_from + '
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
	End

If @FuncRoles <> ''
	Begin
	  SELECT @sql_from = @sql_from + 'LEFT OUTER JOIN TASK_TRAFFIC_ROLE ON TASK_TRAFFIC_ROLE.TRF_CODE = V_JOB_TRAFFIC_DET.FNC_CODE '
	  SELECT @sql_where = @sql_where + ' AND (TASK_TRAFFIC_ROLE.ROLE_CODE IN ('+ @FuncRoles +')) '		
	End	

IF @DEPTS <> ''
BEGIN
	  SELECT @sql_from = @sql_from + ' INNER JOIN EMPLOYEE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMPLOYEE.EMP_CODE '
		
	  SELECT @sql_where = @sql_where + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) ' 
END	

IF @TRF_CODE <> ''
BEGIN
	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.TRF_CODE = ''' + @TRF_CODE + ''''
END

If @EmpCode <> '' 
	SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''' OR V_JOB_TRAFFIC_DET.EMP_CODE IS NULL)'

If @OfficeCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' And @ClientCode IS Not NULL
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode  + ''''

If @DivCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivCode + '''' 

If @ProdCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProdCode + '''' 

If @JobNumber <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNumber + '''' 

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + '''' 

If @TaskStatus <> '' 
	BEGIN
		If @TaskStatus = 'P'
			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''' OR V_JOB_TRAFFIC_DET.TASK_STATUS IS NULL) '
		Else
			SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
	END

if @ExcludeTempComplete = 'Y'
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

If @MilestonesOnly = 'Y'
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.MILESTONE = 1 '

SELECT @sql = @sql + @sql_from + @sql_where

SELECT @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,
	JOB_LOG.JOB_NUMBER,JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
	STR(DATEPART(day, V_JOB_TRAFFIC_DET.TASK_START_DATE)),
	STR(DATEPART(day, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)),
	ISNULL(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''('' + ISNULL(V_JOB_TRAFFIC_DET.FNC_CODE,'''') + '')'') ,
	V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
	V_JOB_TRAFFIC_DET.TASK_START_DATE,
	V_JOB_TRAFFIC_DET.TEMP_COMP_DATE,
	V_JOB_TRAFFIC_DET.TASK_STATUS,
	V_JOB_TRAFFIC_DET.SEQ_NBR,
	CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION, TRAFFIC_FNC.TRF_CODE, V_JOB_TRAFFIC_DET.EMP_CODE, 
	TRAFFIC.TRF_DESCRIPTION,V_JOB_TRAFFIC_DET.REVISED_DUE_TIME '

	
If @GrpLevel = '0' 
	set @sql = @sql + ' ORDER BY V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '
Else
	set @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '

PRINT(@sql)
EXEC(@sql)





