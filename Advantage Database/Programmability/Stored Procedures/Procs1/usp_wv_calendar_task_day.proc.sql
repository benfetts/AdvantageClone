
/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_task_day] 
@UserID VarChar(100),
@EmpCode Varchar(6),
@OfficeCode	varchar(4),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@Role VarChar(6),
@ThisDate Varchar(10),
@TaskStatus Varchar(1), 
@ExcludeTempComplete Char(1),
@Manager varchar(6)
AS

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
	
If @Role  IS NULL 
	set @Role = ''	
		
If @TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If @ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = ''

If @EmpCode  IS NULL 
	set @EmpCode = ''	
	
If @Manager  IS NULL 
	set @Manager = ''

DECLARE @Restrictions 	Int
DECLARE @RestrictionsEmp Int
DECLARE @sql 		nvarchar(4000)
DECLARE @sql_from 	nvarchar(2000)
DECLARE @sql_where 	nvarchar(2000)

Set NoCount On

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)


SELECT @sql = ' SELECT ''<b>'' + JOB_LOG.CL_CODE + ''</b>|'' + CLIENT.CL_NAME AS client, 
	''<b>'' + JOB_LOG.DIV_CODE + ''</b>|'' + DIVISION.DIV_NAME AS division, 
        ''<b>'' + JOB_LOG.PRD_CODE + ''</b>|'' + PRODUCT.PRD_DESCRIPTION AS product, 
	''<b>'' + STR(JOB_LOG.JOB_NUMBER) + ''</b>|'' + JOB_LOG.JOB_DESC AS job, 
        ''<b>'' +STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''</b>|'' + JOB_COMPONENT.JOB_COMP_DESC AS jobcomp, 
         isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + '' ('' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'' AS Task, 
         dbo.udf_get_empl_name(V_JOB_TRAFFIC_DET.EMP_CODE,''FML'')   AS employee, V_JOB_TRAFFIC_DET.EMP_CODE,
         V_JOB_TRAFFIC_DET.JOB_NUMBER        as JobNo,
         V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR as JobCompNo,
         V_JOB_TRAFFIC_DET.SEQ_NBR           as SeqNo,
         V_JOB_TRAFFIC_DET.JOB_HRS           as HoursAllowed,
         V_JOB_TRAFFIC_DET.TEMP_COMP_DATE    as TempCompDate,
         V_JOB_TRAFFIC_DET.TASK_STATUS '

SELECT @sql_from = ' FROM JOB_LOG 
	INNER JOIN CLIENT    ON CLIENT.CL_CODE = JOB_LOG.CL_CODE 
     	INNER JOIN DIVISION  ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND 
                                DIVISION.CL_CODE = JOB_LOG.CL_CODE 
        INNER JOIN PRODUCT   ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND 
                                PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
                                PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE 
        INNER JOIN JOB_COMPONENT     ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
        INNER JOIN V_JOB_TRAFFIC_DET   ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND 
	                                JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR  '


SELECT @sql_where = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
	AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL 
	AND V_JOB_TRAFFIC_DET.JOB_REVISED_DATE = ''' + @ThisDate + ''''
 

 If @Restrictions > 0	
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
                                        JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End


If @RestrictionsEmp > 0 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '

	End
	
If @Manager <> ''
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER 
	       AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR '
	
	  SELECT @sql_where = @sql_where + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
	End
	
If @Role <> ''
	Begin
	  SELECT @sql_from = @sql_from + 'LEFT OUTER JOIN TASK_TRAFFIC_ROLE ON TASK_TRAFFIC_ROLE.TRF_CODE = V_JOB_TRAFFIC_DET.FNC_CODE
	FULL OUTER JOIN EMP_TRAFFIC_ROLE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
		AND TASK_TRAFFIC_ROLE.ROLE_CODE = EMP_TRAFFIC_ROLE.ROLE_CODE '
		
	  SELECT @sql_where = @sql_where + ' AND ( TASK_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''' OR EMP_TRAFFIC_ROLE.ROLE_CODE = ''' + @Role + ''')' 
	End

If @EmpCode  <> ''  AND @EmpCode <> '%'
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.EMP_CODE = '''+ @EmpCode + ''''

If @OfficeCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

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
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TASK_STATUS = ''' + @TaskStatus + ''''

if @ExcludeTempComplete = 'Y'
	SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NULL '

SELECT @sql = @sql + @sql_from + @sql_where
  
SELECT @sql = @sql + ' GROUP BY ''<b>'' + JOB_LOG.CL_CODE + ''</b>|'' + CLIENT.CL_NAME, ''<b>'' + JOB_LOG.DIV_CODE + ''</b>|'' + DIVISION.DIV_NAME, 
	   ''<b>'' + JOB_LOG.PRD_CODE + ''</b>|'' + PRODUCT.PRD_DESCRIPTION, ''<b>'' + STR(JOB_LOG.JOB_NUMBER) + ''</b>|'' + JOB_LOG.JOB_DESC, 
	   ''<b>'' +STR(JOB_COMPONENT.JOB_COMPONENT_NBR) + ''</b>|'' + JOB_COMPONENT.JOB_COMP_DESC, 
	   isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + '' ('' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'', 
	   dbo.udf_get_empl_name(V_JOB_TRAFFIC_DET.EMP_CODE,''FML''), V_JOB_TRAFFIC_DET.EMP_CODE,
           V_JOB_TRAFFIC_DET.JOB_NUMBER,
	   V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
           V_JOB_TRAFFIC_DET.SEQ_NBR,
	   V_JOB_TRAFFIC_DET.JOB_HRS,V_JOB_TRAFFIC_DET.JOB_REVISED_DATE,
	   V_JOB_TRAFFIC_DET.TEMP_COMP_DATE,
           V_JOB_TRAFFIC_DET.TASK_STATUS
  ORDER BY V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '

EXEC( @sql )

