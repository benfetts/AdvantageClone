if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_nontask_GetTasks]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_nontask_GetTasks]
GO
CREATE PROCEDURE [dbo].[usp_wv_nontask_GetTasks]
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@EmpCode varchar(10),
	@Type varchar(2),
	@UserID varchar(100),
	@ROLES varchar(8000),
	@DEPTS VARCHAR(8000),
	@ClientCode VARCHAR(6),
	@DivCode VARCHAR(6),
	@ProdCode VARCHAR(6),
	@JobNumber VARCHAR(6),
	@JobComp VARCHAR(6),
	@Level VARCHAR(1),
	@Grouping VARCHAR(10),
	@FromApp VARCHAR(10)


AS


DECLARE @RestrictionsEmp Int
DECLARE @sql 		varchar(8000)
DECLARE @sql2 		varchar(8000)
DECLARE @sql_from 	varchar(8000)
DECLARE @sql_where1 	varchar(8000)
DECLARE @sql_where2 	varchar(8000)
DECLARE @sql_where3 	varchar(8000)
DECLARE @sql_where4 	varchar(8000)
DECLARE @sql_where5 	varchar(8000)
DECLARE @sql_where6 	varchar(8000)
DECLARE @start_date	varchar(12)
DECLARE @end_date	varchar(12)

Set NoCount On

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)


If @EmpCode IS NULL 
	set @EmpCode = ''

If @Type IS NULL 
	set @Type = ''

If @ROLES IS NULL 
	set @ROLES = ''

If @DEPTS IS NULL 
	set @DEPTS = ''


SELECT @start_date = CAST(@StartDate AS Varchar(12))
SELECT @end_date = CAST(@EndDate AS Varchar(12))

If @Level = 'T'
Begin
		if @Grouping = 'emp'
		Begin
			set @sql = 'SELECT DISTINCT EMP_NON_TASKS.NON_TASK_ID, EMP_NON_TASKS_EMPS.EMP_CODE, 
			ISNULL(EMPLOYEE.EMP_FNAME, '''') AS EMP_FNAME, 
			ISNULL(EMPLOYEE.EMP_MI, '''') AS EMP_MI, 
			ISNULL(EMPLOYEE.EMP_LNAME, '''') AS EMP_LNAME, 
			EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME,  
			EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
			STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
			EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
			EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,'''') AS REMINDER, ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
			EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
			CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION '
		End
		Else
		Begin
			set @sql = 'SELECT EMP_NON_TASKS.NON_TASK_ID, '''','''','''','''',
			EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME, 
			EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
			STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
			EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
			EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,'''') AS REMINDER, ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
			EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
			CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION '
		End	
End
Else
Begin
	set @sql = 'SELECT DISTINCT EMP_NON_TASKS.NON_TASK_ID, 
		EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME, 
		EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
		STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
		EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
		EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,'''') AS REMINDER, ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
		EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
		CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION '
End



set @sql_from = ' FROM EMP_NON_TASKS
	LEFT OUTER JOIN EMP_NON_TASKS_EMPS ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID
	LEFT OUTER JOIN EMPLOYEE ON EMP_NON_TASKS_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE 
	LEFT OUTER JOIN TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
	LEFT OUTER JOIN CDP_CONTACT_HDR ON EMP_NON_TASKS.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
	LEFT OUTER JOIN PRODUCT ON PRODUCT.CL_CODE = EMP_NON_TASKS.CL_CODE AND PRODUCT.DIV_CODE = EMP_NON_TASKS.DIV_CODE AND PRODUCT.PRD_CODE = EMP_NON_TASKS.PRD_CODE
	LEFT OUTER JOIN DIVISION ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
	LEFT OUTER JOIN CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE '

If @RestrictionsEmp > 0 AND @Type <> 'H'
	set @sql_from = @sql_from  + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON EMP_NON_TASKS_EMPS.EMP_CODE = SEC_EMP.EMP_CODE '

If @RestrictionsOffice > 0 AND @Type <> 'H' 
	set @sql_from = @sql_from  + ' LEFT OUTER JOIN JOB_LOG ON (JOB_LOG.JOB_NUMBER = EMP_NON_TASKS.JOB_NUMBER OR EMP_NON_TASKS.JOB_NUMBER IS NULL)
									LEFT OUTER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''


IF (@Type = 'A' Or @Type = '')
	set @sql_from = @sql_from  + ' LEFT OUTER JOIN EMP_TRAFFIC_ROLE ON EMP_TRAFFIC_ROLE.EMP_CODE = EMP_NON_TASKS_EMPS.EMP_CODE '


set @sql_where1 = ' WHERE (EMP_NON_TASKS.START_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.START_DATE <= ''' + @end_date + '''' 
set @sql_where2 = ' OR (EMP_NON_TASKS.END_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.END_DATE <= ''' + @end_date + '''' 
--set @sql_where3 = ' OR (EMP_NON_TASKS.START_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.START_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.EMP_CODE IS NULL '
--set @sql_where4 = ' OR (EMP_NON_TASKS.END_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.END_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.EMP_CODE IS NULL '
set @sql_where5 = ' OR (''' + @start_date + ''' >= EMP_NON_TASKS.START_DATE AND ''' + @end_date + ''' <= EMP_NON_TASKS.END_DATE ' 
--set @sql_where6 = ' OR (''' + @start_date + ''' >= EMP_NON_TASKS.START_DATE AND ''' + @end_date + ''' <= EMP_NON_TASKS.END_DATE AND EMP_NON_TASKS.EMP_CODE IS NULL '


If @EmpCode <> '' AND @Type <> 'H'
  Begin	
	set @sql_where1 = @sql_where1 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''
	set @sql_where2 = @sql_where2 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''
	set @sql_where5 = @sql_where5 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''	
  End


If @Type = 'A'
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'' OR EMP_NON_TASKS.TYPE = ''EL'')'
	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'' OR EMP_NON_TASKS.TYPE = ''EL'')'
	--set @sql_where3 = @sql_where3 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'')'
	--set @sql_where4 = @sql_where4 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'')'
	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'' OR EMP_NON_TASKS.TYPE = ''EL'')'
	--set @sql_where6 = @sql_where6 + ' AND (EMP_NON_TASKS.TYPE = ''' + @Type + ''' OR EMP_NON_TASKS.TYPE = ''C'' OR EMP_NON_TASKS.TYPE = ''M'' OR EMP_NON_TASKS.TYPE = ''TD'' OR EMP_NON_TASKS.TYPE = ''NA'')'
  End

If @Type = 'H'
  Begin
	set @sql_where1 = @sql_where1 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
	set @sql_where2 = @sql_where2 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
	--set @sql_where3 = @sql_where3 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
	--set @sql_where4 = @sql_where4 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
	set @sql_where5 = @sql_where5 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
	--set @sql_where6 = @sql_where6 + ' AND EMP_NON_TASKS.TYPE = ''' + @Type + ''''
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @ROLES <> ''
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	set @sql_where2 = @sql_where2 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	--set @sql_where3 = @sql_where3 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	--set @sql_where4 = @sql_where4 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	set @sql_where5 = @sql_where5 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
	--set @sql_where6 = @sql_where6 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) '
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @DEPTS <> ''
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	set @sql_where2 = @sql_where2 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	set @sql_where5 = @sql_where5 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @ClientCode <> ''
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.CL_CODE = '''+ @ClientCode +''' OR EMP_NON_TASKS.CL_CODE = '''' OR EMP_NON_TASKS.CL_CODE IS NULL) '
	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.CL_CODE = '''+ @ClientCode +''' OR EMP_NON_TASKS.CL_CODE = '''' OR EMP_NON_TASKS.CL_CODE IS NULL) '
	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.CL_CODE = '''+ @ClientCode +''' OR EMP_NON_TASKS.CL_CODE = '''' OR EMP_NON_TASKS.CL_CODE IS NULL) '
	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @DivCode <> ''
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.DIV_CODE = '''+ @DivCode +''' OR EMP_NON_TASKS.DIV_CODE = '''' OR EMP_NON_TASKS.DIV_CODE IS NULL) '
	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.DIV_CODE = '''+ @DivCode +''' OR EMP_NON_TASKS.DIV_CODE = '''' OR EMP_NON_TASKS.DIV_CODE IS NULL) '
	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.DIV_CODE = '''+ @DivCode +''' OR EMP_NON_TASKS.DIV_CODE = '''' OR EMP_NON_TASKS.DIV_CODE IS NULL) '
	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @ProdCode <> ''
  Begin
	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.PRD_CODE = '''+ @ProdCode +''' OR EMP_NON_TASKS.PRD_CODE = '''' OR EMP_NON_TASKS.PRD_CODE IS NULL) '
	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.PRD_CODE = '''+ @ProdCode +''' OR EMP_NON_TASKS.PRD_CODE = '''' OR EMP_NON_TASKS.PRD_CODE IS NULL) '
	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.PRD_CODE = '''+ @ProdCode +''' OR EMP_NON_TASKS.PRD_CODE = '''' OR EMP_NON_TASKS.PRD_CODE IS NULL) '
	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @JobNumber <> ''
  Begin
	--If @FromApp = 'PS' OR @FromApp = 'PSMV'
	--Begin
	--	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +') '
	--	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +') '
	--	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +') '
	--	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--End
	--Else
	--Begin
			set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +' OR EMP_NON_TASKS.JOB_NUMBER IS NULL) '
			set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +' OR EMP_NON_TASKS.JOB_NUMBER IS NULL) '
	--	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
			set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.JOB_NUMBER = '+ @JobNumber +' OR EMP_NON_TASKS.JOB_NUMBER IS NULL) '
	--	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--End	
  End

If ( @Type = 'A' Or @Type = '' Or @Type = 'C' Or @Type = 'M' Or @Type = 'TD' Or @Type = 'NA' Or @Type = 'EL') And @JobComp <> ''
  Begin
	--If @FromApp = 'PS' OR @FromApp = 'PSMV'
	--Begin
	--	set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +') '
	--	set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +') '
	--	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +') '
	--	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--End
	--Else
	--Begin
			set @sql_where1 = @sql_where1 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +' OR EMP_NON_TASKS.JOB_COMPONENT_NBR IS NULL) '
			set @sql_where2 = @sql_where2 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +' OR EMP_NON_TASKS.JOB_COMPONENT_NBR IS NULL) '
	--	--set @sql_where3 = @sql_where3 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--	--set @sql_where4 = @sql_where4 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
			set @sql_where5 = @sql_where5 + ' AND (EMP_NON_TASKS.JOB_COMPONENT_NBR = '+ @JobComp +' OR EMP_NON_TASKS.JOB_COMPONENT_NBR IS NULL) '
	--	--set @sql_where6 = @sql_where6 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) '
	--End	
  End
  
set @sql_where1 = @sql_where1 + ')'
set @sql_where2 = @sql_where2 + ')'
--set @sql_where3 = @sql_where3 + ')'
--set @sql_where4 = @sql_where4 + ')'
set @sql_where5 = @sql_where5 + ')'
--set @sql_where6 = @sql_where6 + ')'

--set @sql = @sql + @sql_from + @sql_where1 + @sql_where2 + @sql_where3 + @sql_where4 + @sql_where5 + @sql_where6
set @sql = @sql + @sql_from + @sql_where1 + @sql_where2 + @sql_where5

If @Type = ''
Begin
	If @Level = 'T'
	Begin
		if @Grouping = 'emp'
		Begin
			set @sql = @sql + ' UNION
			SELECT   EMP_NON_TASKS.NON_TASK_ID,  CASE WHEN EMP_NON_TASKS.TYPE = ''H'' THEN NULL ELSE EMP_NON_TASKS_EMPS.EMP_CODE END, 
				ISNULL(EMPLOYEE.EMP_FNAME, '''') AS EMP_FNAME, 
				ISNULL(EMPLOYEE.EMP_MI, '''') AS EMP_MI, 
				ISNULL(EMPLOYEE.EMP_LNAME, '''') AS EMP_LNAME, 
				EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME, 
				EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
				STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
				EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
				EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,''''), ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
				EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
		CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
			FROM  EMP_NON_TASKS LEFT OUTER JOIN EMP_NON_TASKS_EMPS ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
				LEFT OUTER JOIN
				EMPLOYEE ON EMP_NON_TASKS_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
				TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
				LEFT OUTER JOIN CDP_CONTACT_HDR ON EMP_NON_TASKS.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
				LEFT OUTER JOIN PRODUCT ON PRODUCT.CL_CODE = EMP_NON_TASKS.CL_CODE AND PRODUCT.DIV_CODE = EMP_NON_TASKS.DIV_CODE AND PRODUCT.PRD_CODE = EMP_NON_TASKS.PRD_CODE
				LEFT OUTER JOIN DIVISION ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
				LEFT OUTER JOIN CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE '
		End
		Else
		Begin
			set @sql = @sql + ' UNION
			SELECT   EMP_NON_TASKS.NON_TASK_ID, '''','''','''','''',
				EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME, 
				EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
				STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
				EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
				EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,''''), ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
				EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
		CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
			FROM  EMP_NON_TASKS LEFT OUTER JOIN EMP_NON_TASKS_EMPS ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
				LEFT OUTER JOIN
				EMPLOYEE ON EMP_NON_TASKS_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
				TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
				LEFT OUTER JOIN CDP_CONTACT_HDR ON EMP_NON_TASKS.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
				LEFT OUTER JOIN PRODUCT ON PRODUCT.CL_CODE = EMP_NON_TASKS.CL_CODE AND PRODUCT.DIV_CODE = EMP_NON_TASKS.DIV_CODE AND PRODUCT.PRD_CODE = EMP_NON_TASKS.PRD_CODE
				LEFT OUTER JOIN DIVISION ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
				LEFT OUTER JOIN CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE '
		End
		
	End
	Else
	Begin
		set @sql = @sql + ' UNION
		SELECT   EMP_NON_TASKS.NON_TASK_ID,
			EMP_NON_TASKS.TYPE, EMP_NON_TASKS.NON_TASK_DESC, EMP_NON_TASKS.START_TIME, CASE WHEN EMP_NON_TASKS.ALL_DAY = 1 THEN DATEADD(dd, DATEDIFF(dd, 0, EMP_NON_TASKS.END_TIME), 0) ELSE EMP_NON_TASKS.END_TIME END AS END_TIME,  
			EMP_NON_TASKS.HOURS, ISNULL(EMP_NON_TASKS.CATEGORY,''''), STR(DATEPART(day, EMP_NON_TASKS.START_DATE)) as ThisStartDay,
			STR(DATEPART(day, EMP_NON_TASKS.END_DATE)) as ThisEndDay,
			EMP_NON_TASKS.ALL_DAY, EMP_NON_TASKS.START_DATE, EMP_NON_TASKS.END_DATE, TIME_CATEGORY.DESCRIPTION,
			EMP_NON_TASKS.PRIORITY, ISNULL(EMP_NON_TASKS.REMINDER,''''), ISNULL(EMP_NON_TASKS.RECURRENCE,'''') AS RECURRENCE, EMP_NON_TASKS.RECURRENCE_PARENT,
		    EMP_NON_TASKS.CL_CODE, EMP_NON_TASKS.DIV_CODE, EMP_NON_TASKS.PRD_CODE, EMP_NON_TASKS.JOB_NUMBER, EMP_NON_TASKS.JOB_COMPONENT_NBR, EMP_NON_TASKS.CDP_CONTACT_ID,
		CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
		FROM  EMP_NON_TASKS LEFT OUTER JOIN EMP_NON_TASKS_EMPS ON EMP_NON_TASKS.NON_TASK_ID = EMP_NON_TASKS_EMPS.NON_TASK_ID 
			LEFT OUTER JOIN
			EMPLOYEE ON EMP_NON_TASKS_EMPS.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
			TIME_CATEGORY ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
			LEFT OUTER JOIN CDP_CONTACT_HDR ON EMP_NON_TASKS.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
				LEFT OUTER JOIN PRODUCT ON PRODUCT.CL_CODE = EMP_NON_TASKS.CL_CODE AND PRODUCT.DIV_CODE = EMP_NON_TASKS.DIV_CODE AND PRODUCT.PRD_CODE = EMP_NON_TASKS.PRD_CODE
				LEFT OUTER JOIN DIVISION ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
				LEFT OUTER JOIN CLIENT ON CLIENT.CL_CODE = DIVISION.CL_CODE '
	End
	

	set @sql_where1 = ' WHERE (EMP_NON_TASKS.START_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.START_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.TYPE = ''H''' 
	set @sql_where2 = ' OR (EMP_NON_TASKS.END_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.END_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.TYPE = ''H''' 
	set @sql_where3 = ' OR (EMP_NON_TASKS.START_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.START_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.TYPE = ''H'' AND EMP_NON_TASKS.EMP_CODE IS NULL '
	set @sql_where4 = ' OR (EMP_NON_TASKS.END_DATE >= ''' + @start_date + ''' AND EMP_NON_TASKS.END_DATE <= ''' + @end_date + ''' AND EMP_NON_TASKS.TYPE = ''H'' AND EMP_NON_TASKS.EMP_CODE IS NULL '
	set @sql_where5 = ' OR (''' + @start_date + ''' >= EMP_NON_TASKS.START_DATE AND ''' + @end_date + ''' <= EMP_NON_TASKS.END_DATE AND EMP_NON_TASKS.TYPE = ''H''' 
	set @sql_where6 = ' OR (''' + @start_date + ''' >= EMP_NON_TASKS.START_DATE AND ''' + @end_date + ''' <= EMP_NON_TASKS.END_DATE AND EMP_NON_TASKS.TYPE = ''H'' AND EMP_NON_TASKS.EMP_CODE IS NULL '

	--If @EmpCode <> ''
	--  Begin
	--	set @sql_where1 = @sql_where1 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''
	--	set @sql_where2 = @sql_where2 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''
	--	set @sql_where5 = @sql_where5 + ' AND EMP_NON_TASKS_EMPS.EMP_CODE = ''' + @EmpCode + ''''
	--  End

	set @sql_where1 = @sql_where1 + ')'
	set @sql_where2 = @sql_where2 + ')'
	set @sql_where3 = @sql_where3 + ')'
	set @sql_where4 = @sql_where4 + ')'
	set @sql_where5 = @sql_where5 + ')'
	set @sql_where6 = @sql_where6 + ')'

	set @sql = @sql + @sql_where1 + @sql_where2 + @sql_where3 + @sql_where4 + @sql_where5 + @sql_where6
End

set @sql = @sql + ' ORDER BY EMP_NON_TASKS.START_TIME'

EXEC(@sql)
PRINT(@sql)

