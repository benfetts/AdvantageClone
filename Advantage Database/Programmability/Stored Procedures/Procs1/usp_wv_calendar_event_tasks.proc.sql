

/*****************************************************************************************
Webvantage
This Stored Procedure gets Events
********************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_event_tasks] 
@UserID VarChar(100),
@OfficeCode varchar(4),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@StartDate Smalldatetime,
@EndDate Smalldatetime,
@GrpLevel VarChar(1)
AS

DECLARE @Restrictions 	Int
DECLARE @RestrictionsEmp Int
DECLARE @sql 		nvarchar(4000)
DECLARE @sql_from 	nvarchar(4000)
DECLARE @sql_where 	nvarchar(4000)
DECLARE @grp_str  varchar(300) 

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

Set NoCount On

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsEmp = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)

--SELECT EVENT.RESOURCE_CODE, EVENT_TASK.TASK_CODE, EVENT_TASK.START_TIME, EVENT_TASK.END_TIME
--FROM EVENT
-- INNER JOIN EVENT_TASK ON EVENT.EVENT_ID = EVENT_TASK.EVENT_ID
--WHERE EVENT_TASK.START_DATE >= @StartDate AND (EVENT_TASK.END_DATE <= DATEADD(day, 1, @EndDate))

set @sql = ' SELECT ISNULL(EVENT.RESOURCE_CODE,''''), EVENT_TASK.TASK_CODE, EVENT_TASK.START_TIME, EVENT_TASK.END_TIME,
	STR(DATEPART(day, EVENT_TASK.START_TIME)) as Day,
	JOB_LOG.CL_CODE as CCode,
	JOB_LOG.DIV_CODE as DCode,
	JOB_LOG.PRD_CODE as PCode,
	JOB_LOG.JOB_NUMBER as JobNum,
	JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum '

SET @grp_str = ''
SELECT @grp_str = 
CASE @GrpLevel
	WHEN '0' THEN  ', EVENT.EVENT_DATE AS GROUPING'
	WHEN '1' THEN  ', JOB_LOG.CL_CODE AS GROUPING' 
	WHEN '2' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE AS GROUPING'	
	WHEN '3' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE AS GROUPING'
	WHEN '4' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) AS GROUPING'
	WHEN '5' THEN  ', JOB_LOG.CL_CODE + JOB_LOG.DIV_CODE + JOB_LOG.PRD_CODE + LTRIM(STR(JOB_LOG.JOB_NUMBER)) + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS GROUPING'
END
		
set @sql = @sql + @grp_str

set @sql_from = ' FROM EVENT
 INNER JOIN EVENT_TASK ON EVENT.EVENT_ID = EVENT_TASK.EVENT_ID
 INNER JOIN JOB_LOG ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER 
 INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
 INNER JOIN JOB_COMPONENT ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
 INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
 INNER JOIN DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE '

SELECT @sql_where = ' WHERE EVENT_TASK.START_DATE >= ''' + Cast(@StartDate as varchar) + ''' AND (EVENT_TASK.END_DATE < DATEADD(day, 1,  ''' + Cast(@EndDate as varchar) + '''))'
	

If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

If @RestrictionsEmp > 0 
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN [dbo].[advtf_sec_emp] (''' + @UserID + ''') AS SEC_EMP ON EVENT_TASK.EMP_CODE = SEC_EMP.EMP_CODE '

	End

If @RestrictionsOffice > 0 
	Begin
	  SELECT @sql_from = @sql_from  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
	End	
	
If @OfficeCode  <> ''
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.CL_CODE = ''' + @ClientCode  + ''''

If @DivCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.DIV_CODE = ''' + @DivCode + '''' 

If @ProdCode <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.PRD_CODE = ''' + @ProdCode + '''' 

If @JobNumber <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_LOG.JOB_NUMBER = ''' + @JobNumber + '''' 

If @JobComp <> '' 
	SELECT @sql_where = @sql_where + ' AND JOB_COMPONENT.JOB_COMPONENT_NBR = ''' + @JobComp + '''' 
	

SELECT @sql = @sql + @sql_from + @sql_where
	
	
If @GrpLevel = '0' 
	set @sql = @sql + ' ORDER BY EVENT.RESOURCE_CODE, EVENT.START_TIME '
Else
	set @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, EVENT.RESOURCE_CODE, EVENT.START_TIME '

EXEC(@sql)
--print(@sql)


