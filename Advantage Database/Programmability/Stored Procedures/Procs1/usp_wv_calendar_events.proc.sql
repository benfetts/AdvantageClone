

/*****************************************************************************************
Webvantage
This Stored Procedure gets Events
********************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_calendar_events] 
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
--DECLARE @RestrictionsEmp Int
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

--Select @RestrictionsEmp = Count(*) 
--FROM SEC_EMP
--WHERE UPPER(USER_ID) = UPPER(@UserID)

--SELECT ISNULL(C.CL_CODE,''), ISNULL(E.RESOURCE_CODE,''), START_TIME, END_TIME, E.EVENT_DATE,
--	STR(DATEPART(day, E.EVENT_DATE)) as Day
--FROM EVENT E
-- INNER JOIN JOB_LOG JL ON JL.JOB_NUMBER = E.JOB_NUMBER 
-- INNER JOIN CLIENT C ON C.CL_CODE = JL.CL_CODE
--WHERE E.EVENT_DATE BETWEEN @StartDate AND @EndDate
--ORDER BY E.RESOURCE_CODE, START_TIME

set @sql = ' SELECT ISNULL(EVENT.RESOURCE_CODE,''''), EVENT.START_TIME, EVENT.END_TIME, EVENT.EVENT_DATE,
	STR(DATEPART(day, EVENT.EVENT_DATE)) as Day,
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
 INNER JOIN JOB_LOG ON JOB_LOG.JOB_NUMBER = EVENT.JOB_NUMBER 
 INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
 INNER JOIN JOB_COMPONENT ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
 INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
 INNER JOIN DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE '

SELECT @sql_where = ' WHERE EVENT.EVENT_DATE BETWEEN ''' + Cast(@StartDate as varchar) + ''' AND  ''' + Cast(@EndDate as varchar) + ''''
	

If @Restrictions > 0
	Begin
	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '

	  SELECT @sql_where = @sql_where + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) '
	End

If @RestrictionsOffice > 0 
	Begin
	  SELECT @sql_from = @sql_from  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
	End	

--If @RestrictionsEmp > 0 
--	Begin
--	  SELECT @sql_from = @sql_from + ' INNER JOIN SEC_EMP ON V_JOB_TRAFFIC_DET.EMP_CODE = SEC_EMP.EMP_CODE '
--
--	  SELECT @sql_where = @sql_where + ' AND (UPPER(SEC_EMP.USER_ID) = UPPER(''' + @UserID + ''')) '
--	End
	
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
	

SELECT @sql = @sql + @sql_from + @sql_where
	
	
If @GrpLevel = '0' 
	set @sql = @sql + ' ORDER BY EVENT.RESOURCE_CODE, EVENT.START_TIME '
Else
	set @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, EVENT.RESOURCE_CODE, EVENT.START_TIME '

EXEC(@sql)
--print(@sql)

