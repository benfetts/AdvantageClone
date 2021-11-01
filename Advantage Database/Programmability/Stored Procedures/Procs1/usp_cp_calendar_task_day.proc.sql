














/*****************************************************************
Webvatnage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_calendar_task_day] 
@CDPID int,
@EmpCode Varchar(6),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@Role VarChar(6),
@ThisDate Varchar(10),
@TaskStatus Varchar(1), 
@ExcludeTempComplete Char(1),
@Milestone Char(1)
AS
Declare @Restrictions Int
DECLARE @sql 		nvarchar(4000)
DECLARE @sql_from 	nvarchar(2000)
DECLARE @sql_where 	nvarchar(2000)
DECLARE @paramlist nvarchar(4000)

Set NoCount On

Select @Restrictions = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CDPID

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
	
If @Role  IS NULL 
	set @Role = ''	
		
If @TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If @ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = ''

If @EmpCode  IS NULL 
	set @EmpCode = ''	

SELECT @sql = 'SELECT     ''<b>'' + JOB_LOG.CL_CODE + ''</b>|'' + CLIENT.CL_NAME AS client, ''<b>'' + JOB_LOG.DIV_CODE + ''</b>|'' + DIVISION.DIV_NAME AS division, 
							  ''<b>'' + JOB_LOG.PRD_CODE + ''</b>|'' + PRODUCT.PRD_DESCRIPTION AS product, ''<b>'' + STR(JOB_LOG.JOB_NUMBER) + ''</b>|'' + JOB_LOG.JOB_DESC AS job, 
							  ''<b>'' +STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''</b>|'' + JOB_COMPONENT.JOB_COMP_DESC AS jobcomp, 
							  isnull(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + '' ('' + isnull(JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'' AS Task, 
							  ISNULL(V_JOB_TRAFFIC_DET_EMPS.EMP_LFI_LIST,'''') AS employee,
			JOB_TRAFFIC_DET.JOB_NUMBER as JobNo,
			JOB_TRAFFIC_DET.JOB_COMPONENT_NBR as JobCompNo,
			JOB_TRAFFIC_DET.SEQ_NBR as SeqNo,
			JOB_TRAFFIC_DET.JOB_HRS as HoursAllowed,
		   JOB_TRAFFIC_DET.TEMP_COMP_DATE as TempCompDate,
			   JOB_TRAFFIC_DET.TASK_STATUS'
			   
SELECT @sql_from = ' FROM         JOB_LOG INNER JOIN
							  CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE INNER JOIN	                      DIVISION ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND DIVISION.CL_CODE = JOB_LOG.CL_CODE INNER JOIN
							  PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
							  PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
							  JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
							  JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
							  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR LEFT OUTER JOIN
							  EMPLOYEE ON JOB_TRAFFIC_DET.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
								  V_JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = V_JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
								  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND V_JOB_TRAFFIC_DET_EMPS.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR'
		
SELECT @sql_where = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
					AND JOB_TRAFFIC_DET.JOB_REVISED_DATE = ''' + @ThisDate + ''''
		
If @Restrictions > 0
		Begin
		  SELECT @sql_from = @sql_from + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE '

		  SELECT @sql_where = @sql_where + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) '
		End
		
If @Role <> ''
	Begin
	  SELECT @sql_from = @sql_from + ' LEFT OUTER JOIN TASK_TRAFFIC_ROLE ON TASK_TRAFFIC_ROLE.TRF_CODE = JOB_TRAFFIC_DET.FNC_CODE
	    FULL OUTER JOIN EMP_TRAFFIC_ROLE ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
		AND TASK_TRAFFIC_ROLE.ROLE_CODE = EMP_TRAFFIC_ROLE.ROLE_CODE '
		
	  SELECT @sql_where = @sql_where + ' AND ( TASK_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''' OR EMP_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''')' 
	End

If @EmpCode  <> ''  AND @EmpCode <> '%'
	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.EMP_CODE = '''+ @EmpCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode + ''''

If @DivCode  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivCode + ''''

If @ProdCode   <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = '''+ @ProdCode + ''''

If @JobNumber  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNumber + ''''

If @JobComp  <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + ''''

If @TaskStatus <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''

if @ExcludeTempComplete = 'Y'
	SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

If @Milestone = 'Y'
		SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC_DET.MILESTONE = 1 '		
													
SELECT @sql = @sql + @sql_from + @sql_where
  
		SELECT @sql = @sql + ' Group By 
		''<b>'' + JOB_LOG.CL_CODE + ''</b>|'' + CLIENT.CL_NAME, ''<b>'' + JOB_LOG.DIV_CODE + ''</b>|'' + DIVISION.DIV_NAME, 
		''<b>'' + JOB_LOG.PRD_CODE + ''</b>|'' + PRODUCT.PRD_DESCRIPTION, ''<b>'' + STR(JOB_LOG.JOB_NUMBER) + ''</b>|'' + JOB_LOG.JOB_DESC, 
		''<b>'' +STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''</b>|'' + JOB_COMPONENT.JOB_COMP_DESC, 
		isnull(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + '' ('' + isnull(JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'', 
		(isnull(EMPLOYEE.EMP_FNAME, '''') + '' '' + IsNull(EMPLOYEE.EMP_LNAME, '''')),
		JOB_TRAFFIC_DET.JOB_NUMBER,
		JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
		JOB_TRAFFIC_DET.SEQ_NBR,
		JOB_TRAFFIC_DET.JOB_HRS,JOB_TRAFFIC_DET.JOB_REVISED_DATE,
		JOB_TRAFFIC_DET.TEMP_COMP_DATE,
			   JOB_TRAFFIC_DET.TASK_STATUS, V_JOB_TRAFFIC_DET_EMPS.EMP_LFI_LIST
		Order By JOB_TRAFFIC_DET.JOB_REVISED_DATE'	



SELECT @paramlist = '@CDPID Int'
EXEC sp_executesql @sql, @paramlist, @CDPID








