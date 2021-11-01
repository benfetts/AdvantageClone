SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_cp_calendar_task_month_rpt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_cp_calendar_task_month_rpt]
GO


/*****************************************************************************************
Webvantage
This Stored Procedure gets  Tasks
Use @GrpLevel = '0' if all tasks are to go into each month
Use @GrpLevel = (1,2,3,4,5) to group by cl/div/prd/job/comp into separate months
********************************************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_calendar_task_month_rpt] 
@CDPID int,
@UserID VarChar(100),
@EmpCode Varchar(6),
@OfficeCode varchar(4),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@ROLES VarChar(8000),
@StartDate smalldatetime,
@EndDate smalldatetime,
@TaskStatus Varchar(1),
@ExcludeTempComplete Char(1),
@MilestonesOnly Char(1),
@Manager VarChar(6),
@GrpLevel VarChar(1),
@DEPTS VarChar(8000),
@IncludeUnassigned bit

AS

DECLARE @Restrictions 	Int
DECLARE @sql 		varchar(8000)
DECLARE @sql_from 	varchar(8000)
DECLARE @sql_where 	varchar(8000)
DECLARE @grp_str  varchar(1000)

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

Select @Restrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

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
	
If @DEPTS IS NULL 
	set @DEPTS = ''
	

Set NoCount On


set @sql = ' SELECT JOB_LOG.CL_CODE as CCode,
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
	isnull(CLIENT.CL_NAME,'''') AS CL_NAME, isnull(DIVISION.DIV_NAME,'''') AS DIV_NAME, isnull(PRODUCT.PRD_DESCRIPTION,'''') AS PRD_DESCRIPTION, ISNULL(TRAFFIC_FNC.TRF_CODE,'''') AS TRF_CODE, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE as RevisedDate, 
	isnull(V_JOB_TRAFFIC_DET.TASK_START_DATE, ''1/1/1900'') as StartDate,
	isnull(V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_LIST,'''') as empcodedispl,
	isnull(V_JOB_TRAFFIC_DET_EMPS.EMP_LFI_LIST,'''') AS empdescdispl, 
	TRAFFIC.TRF_DESCRIPTION, 
	isnull(V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_HOURS_LIST,'''') AS EmployeeCodeAndHours, 
	isnull(V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_FML_NAME_HOURS_LIST,'''') AS EmployeeNameAndHours '

SET @grp_str = ''
SELECT @grp_str = 
CASE @GrpLevel
	WHEN '0' THEN  ', STR(DATEPART(month, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)) AS GROUPING'
	WHEN '1' THEN  ', JOB_LOG.CL_CODE AS GROUPING' 
	WHEN '2' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE AS GROUPING'	
	WHEN '3' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE AS GROUPING'
	WHEN '4' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) AS GROUPING'
	WHEN '5' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS GROUPING '
END
		
set @sql = @sql + @grp_str

set @sql_from = ' FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER 
	       AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
	INNER JOIN DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE 
	INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
	LEFT OUTER JOIN TRAFFIC_FNC ON V_JOB_TRAFFIC_DET.FNC_CODE = TRAFFIC_FNC.TRF_CODE 
	INNER JOIN JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
	INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE 
	LEFT OUTER JOIN V_JOB_TRAFFIC_DET_EMPS ON V_JOB_TRAFFIC_DET.JOB_NUMBER = V_JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND V_JOB_TRAFFIC_DET.SEQ_NBR = V_JOB_TRAFFIC_DET_EMPS.SEQ_NBR  '

SELECT @sql_where = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
			AND JOB_TRAFFIC.COMPLETED_DATE IS NULL
			AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL 
			AND V_JOB_TRAFFIC_DET.TASK_START_DATE <= ''' + Cast(@EndDate AS VARCHAR) + ''' AND ''' + Cast(@StartDate AS VARCHAR) + ''' <= V_JOB_TRAFFIC_DET.JOB_REVISED_DATE ' 
			
If @Restrictions > 0
		Begin
		  SELECT @sql_from = @sql_from + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE '

		  SELECT @sql_where = @sql_where + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CDPID AS VARCHAR(5)) + ''')'
		End
	
If @Manager <> ''
	Begin
	  --SELECT @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	  --     AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR '
	
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
	End

If @ROLES <> ''
	Begin
	  SELECT @sql_from = @sql_from + '
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
		
	End

IF @DEPTS <> ''
BEGIN
      SELECT @sql_from = @sql_from + ' INNER JOIN EMPLOYEE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMPLOYEE.EMP_CODE '
		
      SELECT @sql_where = @sql_where + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) ' 
END	

If @EmpCode <> '' 
BEGIN
	if @IncludeUnassigned = 1
		Begin
			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''' OR V_JOB_TRAFFIC_DET.EMP_CODE IS NULL)'
		End
		Else
		Begin
			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''')'	
		End	
END
ELSE
BEGIN
	if @IncludeUnassigned = 0		
		Begin
			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE IS NOT NULL)'	
		End	
END
	

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
	CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION, TRAFFIC_FNC.TRF_CODE, 
	V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_LIST, V_JOB_TRAFFIC_DET_EMPS.EMP_LFI_LIST,  
	TRAFFIC.TRF_DESCRIPTION,
	V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_HOURS_LIST,
	V_JOB_TRAFFIC_DET_EMPS.EMP_CODE_FML_NAME_HOURS_LIST'

SET @grp_str = ''
SELECT @grp_str = 
CASE @GrpLevel
	WHEN '0' THEN  ''
	WHEN '1' THEN  ', JOB_LOG.CL_CODE ' 
	WHEN '2' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE '	
	WHEN '3' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE '
	WHEN '4' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) '
	WHEN '5' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) '
END
		
set @sql = @sql + @grp_str	
	
If @GrpLevel = '0' 
	set @sql = @sql + ' ORDER BY V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '
Else
	set @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '

EXEC(@sql)
print(@sql)






GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO