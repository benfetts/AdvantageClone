SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_calendar_assign_month_rpt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_calendar_assign_month_rpt]
GO


/*****************************************************************************************
Webvantage
This Stored Procedure gets  Tasks
Use @GrpLevel = '0' if all tasks are to go into each month
Use @GrpLevel = (1,2,3,4,5) to group by cl/div/prd/job/comp into separate months
********************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_assign_month_rpt] 
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
DECLARE @RestrictionsEmp Int
DECLARE @sql 		varchar(8000)
DECLARE @sql_from 	varchar(8000)
DECLARE @sql_where 	varchar(8000)
DECLARE @grp_str  varchar(1000)
DECLARE @sql2 		varchar(8000)
DECLARE @sql_from2 	varchar(8000)
DECLARE @sql_where2 	varchar(8000)
DECLARE @grp_str2  varchar(1000)
DECLARE @sql_order 		varchar(8000)

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
	
If @DEPTS IS NULL 
	set @DEPTS = ''
	

Set NoCount On

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)

--NonRouted

set @sql = ' SELECT ALERT.CL_CODE as CCode,
	ALERT.DIV_CODE as DCode,
	ALERT.PRD_CODE as PCode,
	ALERT.JOB_NUMBER as JobNum,
	JOB_LOG.JOB_DESC as JobDesc,
	ALERT.JOB_COMPONENT_NBR as CompNum,
	JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
	STR(DATEPART(day, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END)) as ThisDay,
	ALERT.[SUBJECT] as Task, 
	''1/1/1900'' as TempCompDate,
	NULL AS TASK_STATUS, STR(DATEPART(day, CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END)) as ThisDayStart, ALERT.TASK_SEQ_NBR,
	isnull(C.CL_NAME,'''') AS CL_NAME, isnull(D.DIV_NAME,'''') AS DIV_NAME, isnull(P.PRD_DESCRIPTION,'''') AS PRD_DESCRIPTION, '''' AS TRF_CODE, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END as RevisedDate, 
	isnull(CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END, ''1/1/1900'') as StartDate,
	ALERT_RCPT.EMP_CODE as empcodedispl,
	coalesce((rtrim(EMP_FNAME) + '' ''),'''') + coalesce((EMP_MI + ''. ''),'''') + coalesce(EMP_LNAME,'''') AS empdescdispl, 
	NULL AS TRF_DESCRIPTION, 
	ALERT_RCPT.EMP_CODE + ''('' + CAST(ISNULL(ALERT_RCPT.HOURS_ALLOWED,0) AS VARCHAR(10)) + '')'' AS EmployeeCodeAndHours, 
	coalesce((rtrim(EMP_FNAME) + '' ''),'''') + coalesce((EMP_MI + ''. ''),'''') + coalesce(EMP_LNAME,'''') + ''('' + CAST(ISNULL(ALERT_RCPT.HOURS_ALLOWED,0) AS VARCHAR(10)) + '')'' AS EmployeeNameAndHours '

SET @grp_str = ''
SELECT @grp_str = 
CASE @GrpLevel
	WHEN '0' THEN  ', STR(DATEPART(month, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END)) AS GROUPING'
	WHEN '1' THEN  ', ALERT.CL_CODE AS GROUPING' 
	WHEN '2' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE AS GROUPING'	
	WHEN '3' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE AS GROUPING'
	WHEN '4' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) AS GROUPING'
	WHEN '5' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) + LTRIM(STR(ALERT.JOB_COMPONENT_NBR)) AS GROUPING '
END
		
set @sql = @sql + @grp_str

set @sql_from = ' FROM ALERT LEFT OUTER JOIN
						 ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID LEFT OUTER JOIN
						 JOB_COMPONENT WITH(NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						 ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
						 JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
						 LEFT OUTER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
						 LEFT OUTER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
						 --LEFT OUTER JOIN SPRINT_EMPLOYEE ON ALERT_RCPT.ALERT_ID = SPRINT_EMPLOYEE.ALERT_ID AND ALERT_RCPT.EMP_CODE = SPRINT_EMPLOYEE.EMP_CODE AND SPRINT_EMPLOYEE.[HOURS] > 0
						 LEFT OUTER JOIN V_INACTIVE_WORK_ITEMS IWI ON ALERT.ALERT_ID = IWI.ALERT_ID   
						 LEFT OUTER JOIN PRODUCT P ON P.PRD_CODE = ALERT.PRD_CODE AND P.DIV_CODE = ALERT.PRD_CODE AND P.CL_CODE = ALERT.CL_CODE
						 LEFT OUTER JOIN DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE
						 LEFT OUTER JOIN CLIENT C ON C.CL_CODE = D.CL_CODE
						 LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT_RCPT.EMP_CODE
					  '

SELECT @sql_where = 'WHERE ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND IS_WORK_ITEM = 1 AND ALERT_LEVEL <> ''BRD'' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND (IWI.ALERT_ID IS NULL)
			AND CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END <= ''' + Cast(@EndDate AS VARCHAR) + ''' AND ''' + Cast(@StartDate AS VARCHAR) + ''' <= CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END ' 
If @EmpCode <> '' 
	Begin
		if @IncludeUnassigned = 1
		Begin
			SELECT @sql_where = @sql_where + ' AND ((CURRENT_NOTIFY = 1 AND ALERT_RCPT.EMP_CODE = ''' + @EmpCode + ''') OR ALERT_RCPT.EMP_CODE IS NULL)'
		End
		Else
		Begin
			SELECT @sql_where = @sql_where + ' AND ((CURRENT_NOTIFY = 1 AND ALERT_RCPT.EMP_CODE = ''' + @EmpCode + '''))'	
		End		
	End
	Else
	Begin
		if @IncludeUnassigned = 1
		Begin
			SELECT @sql_where = @sql_where + ' AND (CURRENT_NOTIFY = 1 OR ALERT_RCPT.EMP_CODE IS NULL)'
		End
		Else
		Begin
			SELECT @sql_where = @sql_where + ' AND (CURRENT_NOTIFY = 1)'
		End		
	End					
If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ALERT.CL_CODE = SEC_CLIENT.CL_CODE AND ALERT.DIV_CODE = SEC_CLIENT.DIV_CODE AND ALERT.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

If @RestrictionsEmp > 0 
	Begin

	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON ALERT_RCPT.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @RestrictionsOffice > 0 
	Begin
	  SELECT @sql_from = @sql_from  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = ALERT.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
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
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON ALERT_RCPT.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where = @sql_where + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
		
	End

IF @DEPTS <> ''
BEGIN
      --SELECT @sql_from = @sql_from + ' INNER JOIN EMPLOYEE ON ALERT_RCPT.EMP_CODE = EMPLOYEE.EMP_CODE '
		
      SELECT @sql_where = @sql_where + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) ' 
END	

--If @EmpCode <> '' 
--	SELECT @sql_where = @sql_where + ' AND ALERT_RCPT.EMP_CODE = ''' + @EmpCode + ''''

If @OfficeCode  <> ''
	SELECT @sql_where = @sql_where + ' AND ALERT.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' And @ClientCode IS Not NULL
	SELECT @sql_where = @sql_where + ' AND ALERT.CL_CODE = ''' + @ClientCode  + ''''

If @DivCode <> '' 
	SELECT @sql_where = @sql_where + ' AND ALERT.DIV_CODE = ''' + @DivCode + '''' 

If @ProdCode <> '' 
	SELECT @sql_where = @sql_where + ' AND ALERT.PRD_CODE = ''' + @ProdCode + '''' 

If @JobNumber <> '' 
	SELECT @sql_where = @sql_where + ' AND ALERT.JOB_NUMBER = ''' + @JobNumber + '''' 

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND ALERT.JOB_COMPONENT_NBR = ''' + @JobComp + '''' 
	
--If @TaskStatus <> '' 
--	BEGIN
--		If @TaskStatus = 'P'
--			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''' OR V_JOB_TRAFFIC_DET.TASK_STATUS IS NULL) '
--		Else
--			SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
--	END

--if @ExcludeTempComplete = 'Y'
--	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

--If @MilestonesOnly = 'Y'
--	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.MILESTONE = 1 '

SELECT @sql = @sql + @sql_from + @sql_where

SELECT @sql = @sql + ' GROUP BY ALERT.CL_CODE, ALERT.DIV_CODE, ALERT.PRD_CODE,
	ALERT.JOB_NUMBER,JOB_LOG.JOB_DESC, ALERT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
	ALERT.[START_DATE],ALERT.DUE_DATE,[SUBJECT], TASK_SEQ_NBR,	
	C.CL_NAME, D.DIV_NAME, P.PRD_DESCRIPTION, ALERT_RCPT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, HOURS_ALLOWED'

SET @grp_str = ''
SELECT @grp_str = 
CASE @GrpLevel
	WHEN '0' THEN  ''
	WHEN '1' THEN  ', ALERT.CL_CODE ' 
	WHEN '2' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE '	
	WHEN '3' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE '
	WHEN '4' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) '
	WHEN '5' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) + LTRIM(STR(ALERT.JOB_COMPONENT_NBR)) '
END

--PRINT(@sql)
set @sql = @sql + @grp_str	
PRINT(@sql)

--Routed

set @sql2 = ' UNION ALL 
SELECT ALERT.CL_CODE as CCode,
	ALERT.DIV_CODE as DCode,
	ALERT.PRD_CODE as PCode,
	ALERT.JOB_NUMBER as JobNum,
	JOB_LOG.JOB_DESC as JobDesc,
	ALERT.JOB_COMPONENT_NBR as CompNum,
	JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
	STR(DATEPART(day, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END)) as ThisDay,
	ALERT.[SUBJECT] as Task, 
	''1/1/1900'' as TempCompDate,
	NULL AS TASK_STATUS, STR(DATEPART(day, CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END)) as ThisDayStart, ALERT.TASK_SEQ_NBR,
	isnull(C.CL_NAME,'''') AS CL_NAME, isnull(D.DIV_NAME,'''') AS DIV_NAME, isnull(P.PRD_DESCRIPTION,'''') AS PRD_DESCRIPTION, '''' AS TRF_CODE, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END as RevisedDate, 
	isnull(CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END, ''1/1/1900'') as StartDate,
	ALERT_RCPT.EMP_CODE as empcodedispl,
	coalesce((rtrim(EMP_FNAME) + '' ''),'''') + coalesce((EMP_MI + ''. ''),'''') + coalesce(EMP_LNAME,'''') AS empdescdispl, 
	NULL AS TRF_DESCRIPTION, 
	ALERT_RCPT.EMP_CODE + ''('' + CAST(ISNULL(ALERT_RCPT.HOURS_ALLOWED,0) AS VARCHAR(10)) + '')'' AS EmployeeCodeAndHours, 
	coalesce((rtrim(EMP_FNAME) + '' ''),'''') + coalesce((EMP_MI + ''. ''),'''') + coalesce(EMP_LNAME,'''') + ''('' + CAST(ISNULL(ALERT_RCPT.HOURS_ALLOWED,0) AS VARCHAR(10)) + '')'' AS EmployeeNameAndHours '

SET @grp_str2 = ''
SELECT @grp_str2 = 
CASE @GrpLevel
	WHEN '0' THEN  ', STR(DATEPART(month, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END)) AS GROUPING'
	WHEN '1' THEN  ', ALERT.CL_CODE AS GROUPING' 
	WHEN '2' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE AS GROUPING'	
	WHEN '3' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE AS GROUPING'
	WHEN '4' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) AS GROUPING'
	WHEN '5' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) + LTRIM(STR(ALERT.JOB_COMPONENT_NBR)) AS GROUPING '
END
		
set @sql2 = @sql2 + @grp_str2

set @sql_from2 = ' FROM ALERT LEFT OUTER JOIN
						 ALERT_RCPT ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID LEFT OUTER JOIN
						 JOB_COMPONENT WITH(NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						 ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
						 JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
						 LEFT OUTER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER 
						 LEFT OUTER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
						 --LEFT OUTER JOIN SPRINT_EMPLOYEE ON ALERT_RCPT.ALERT_ID = SPRINT_EMPLOYEE.ALERT_ID AND ALERT_RCPT.EMP_CODE = SPRINT_EMPLOYEE.EMP_CODE AND SPRINT_EMPLOYEE.[HOURS] > 0
						 LEFT OUTER JOIN V_INACTIVE_WORK_ITEMS IWI ON ALERT.ALERT_ID = IWI.ALERT_ID   
						 LEFT OUTER JOIN PRODUCT P ON P.PRD_CODE = ALERT.PRD_CODE AND P.DIV_CODE = ALERT.PRD_CODE AND P.CL_CODE = ALERT.CL_CODE
						 LEFT OUTER JOIN DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE
						 LEFT OUTER JOIN CLIENT C ON C.CL_CODE = D.CL_CODE
						 LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT_RCPT.EMP_CODE
					  '

SELECT @sql_where2 = 'WHERE ALERT.ALRT_NOTIFY_HDR_ID IS NOT NULL AND IS_WORK_ITEM = 1 AND ALERT_LEVEL <> ''BRD'' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND (IWI.ALERT_ID IS NULL)
			AND CASE WHEN ALERT.[START_DATE] is NULL THEN ALERT.DUE_DATE ELSE ALERT.[START_DATE] END <= ''' + Cast(@EndDate AS VARCHAR) + ''' AND ''' + Cast(@StartDate AS VARCHAR) + ''' <= CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END' 
			
If @EmpCode <> '' 
	Begin
		if @IncludeUnassigned = 1
		Begin
			SELECT @sql_where2 = @sql_where2 + ' AND ((CURRENT_NOTIFY = 1 AND ALERT_RCPT.EMP_CODE = ''' + @EmpCode + ''') OR ALERT_RCPT.EMP_CODE IS NULL)'
		End
		Else
		Begin
			SELECT @sql_where2 = @sql_where2 + ' AND ((CURRENT_NOTIFY = 1 AND ALERT_RCPT.EMP_CODE = ''' + @EmpCode + '''))'	
		End		
	End
	Else
	Begin
		if @IncludeUnassigned = 1
		Begin
			SELECT @sql_where2 = @sql_where2 + ' AND (CURRENT_NOTIFY = 1 OR ALERT_RCPT.EMP_CODE IS NULL)'
		End
		Else
		Begin
			SELECT @sql_where2 = @sql_where2 + ' AND (CURRENT_NOTIFY = 1)'
		End		
	End				
If @Restrictions > 0
	Begin
	  SELECT @sql_from2 = @sql_from2 + ' INNER JOIN SEC_CLIENT ON ALERT.CL_CODE = SEC_CLIENT.CL_CODE AND ALERT.DIV_CODE = SEC_CLIENT.DIV_CODE AND ALERT.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where2 = @sql_where2 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

If @RestrictionsEmp > 0 
	Begin

	  SELECT @sql_from2 = @sql_from2 + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON ALERT_RCPT.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @RestrictionsOffice > 0 
	Begin
	  SELECT @sql_from2 = @sql_from2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = ALERT.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
	End	
	
If @Manager <> ''
	Begin
	  --SELECT @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	  --     AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR '
	
	  SELECT @sql_where2 = @sql_where2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
	End

If @ROLES <> ''
	Begin
	  SELECT @sql_from2 = @sql_from2 + '
           LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON ALERT_RCPT.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
	  SELECT @sql_where2 = @sql_where2 + ' AND (EMP_TRAFFIC_ROLE.ROLE_CODE IN ('+ @ROLES +')) ' 	
		
	End

IF @DEPTS <> ''
BEGIN
      --SELECT @sql_from = @sql_from + ' INNER JOIN EMPLOYEE ON ALERT_RCPT.EMP_CODE = EMPLOYEE.EMP_CODE '
		
      SELECT @sql_where2 = @sql_where2 + ' AND (EMPLOYEE.DP_TM_CODE IN ('+ @DEPTS +')) ' 
END	

If @OfficeCode  <> ''
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' And @ClientCode IS Not NULL
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.CL_CODE = ''' + @ClientCode  + ''''

If @DivCode <> '' 
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.DIV_CODE = ''' + @DivCode + '''' 

If @ProdCode <> '' 
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.PRD_CODE = ''' + @ProdCode + '''' 

If @JobNumber <> '' 
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.JOB_NUMBER = ''' + @JobNumber + '''' 

If @JobComp <> '' 
	SELECT @sql_where2 = @sql_where2 + ' AND ALERT.JOB_COMPONENT_NBR = ''' + @JobComp + '''' 
	
--If @TaskStatus <> '' 
--	BEGIN
--		If @TaskStatus = 'P'
--			SELECT @sql_where = @sql_where + ' AND (V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''' OR V_JOB_TRAFFIC_DET.TASK_STATUS IS NULL) '
--		Else
--			SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''
--	END

--if @ExcludeTempComplete = 'Y'
--	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

--If @MilestonesOnly = 'Y'
--	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.MILESTONE = 1 '

SELECT @sql2 = @sql2 + @sql_from2 + @sql_where2

SELECT @sql2 = @sql2 + ' GROUP BY ALERT.CL_CODE, ALERT.DIV_CODE, ALERT.PRD_CODE,
	ALERT.JOB_NUMBER,JOB_LOG.JOB_DESC, ALERT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
	ALERT.[START_DATE],ALERT.DUE_DATE,[SUBJECT], TASK_SEQ_NBR,	
	C.CL_NAME, D.DIV_NAME, P.PRD_DESCRIPTION, ALERT_RCPT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, HOURS_ALLOWED'

SET @grp_str2 = ''
SELECT @grp_str2 = 
CASE @GrpLevel
	WHEN '0' THEN  ''
	WHEN '1' THEN  ', ALERT.CL_CODE ' 
	WHEN '2' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE '	
	WHEN '3' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE '
	WHEN '4' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) '
	WHEN '5' THEN  ', ALERT.CL_CODE + ALERT.DIV_CODE + ALERT.PRD_CODE + LTRIM(STR(ALERT.JOB_NUMBER)) + LTRIM(STR(ALERT.JOB_COMPONENT_NBR)) '
END
		
set @sql2 = @sql2 + @grp_str2


	
If @GrpLevel = '0' 
	set @sql_order = @sql_order + ' ORDER BY CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END '
Else
	set @sql_order = @sql_order + ' ORDER BY ALERT.CL_CODE, ALERT.DIV_CODE, ALERT.PRD_CODE, ALERT.JOB_NUMBER, ALERT.JOB_COMPONENT_NBR, CASE WHEN ALERT.DUE_DATE is NULL THEN ALERT.[START_DATE] ELSE ALERT.DUE_DATE END '

EXEC(@sql+@sql2+@sql_order)
--print(@sql)
print(@sql2)
--print(@sql_order)






GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO