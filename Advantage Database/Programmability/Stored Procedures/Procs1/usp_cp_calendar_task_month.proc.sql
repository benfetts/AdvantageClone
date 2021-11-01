IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_cp_calendar_task_month]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_cp_calendar_task_month]
GO


/*****************************************************************
Webvantage
This Stored Procedure gets a Tasks By a Date, 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_calendar_task_month] 
@CDPID int,
@EmpCode Varchar(6),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@JobComp VarChar(6),
@ROLES VarChar(8000),
@StartDate SMALLDATETIME,
@EndDate SMALLDATETIME,
@TaskStatus Varchar(1),
@ExcludeTempComplete Char(1),
@Milestone Char(1),
@Manager VARCHAR(6),
@GrpLevel VARCHAR(1),
@DEPTS VARCHAR(8000),
@TRF_CODE VARCHAR(10),
@FuncRoles VarChar(8000)
AS
Declare @Restrictions Int
DECLARE @sql 		nvarchar(4000)
DECLARE @sql_from 	nvarchar(4000)
DECLARE @sql_where 	nvarchar(4000)
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
	
If @ROLES  IS NULL 
	set @ROLES = ''	

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
		
If @TaskStatus  IS NULL 
	set @TaskStatus = ''	
	
If @ExcludeTempComplete  IS NULL 
	set @ExcludeTempComplete = ''

If @EmpCode  IS NULL 
	set @EmpCode = ''
	
	
     SELECT @sql = 'SELECT JOB_LOG.CL_CODE as CCode,
	     JOB_LOG.DIV_CODE as DCode,
	     JOB_LOG.PRD_CODE as PCode,
	     JOB_LOG.JOB_NUMBER as JobNum,
	     JOB_LOG.JOB_DESC as JobDesc,
	     JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
	     JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
	     STR(DATEPART(day, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)) as ThisDay,
	     isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''('' + V_JOB_TRAFFIC_DET.FNC_CODE + '')'') as Task,
	     isnull(V_JOB_TRAFFIC_DET.TEMP_COMP_DATE, ''1/1/1900'') as TempCompDate,
             V_JOB_TRAFFIC_DET.TASK_STATUS, STR(DATEPART(day, V_JOB_TRAFFIC_DET.TASK_START_DATE)) as ThisDayStart, V_JOB_TRAFFIC_DET.SEQ_NBR,
             CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION, TRAFFIC_FNC.TRF_CODE, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE as RevisedDate,
             isnull(V_JOB_TRAFFIC_DET.TASK_START_DATE, ''1/1/1900'') as StartDate,
			 isnull(V_JOB_TRAFFIC_DET.EMP_CODE,'''') as empcodedispl,
			 isnull(dbo.udf_get_empl_name( V_JOB_TRAFFIC_DET.EMP_CODE, ''FML'' ),'''') AS empdescdispl,TRAFFIC.TRF_DESCRIPTION, ISNULL(V_JOB_TRAFFIC_DET.DUE_TIME, '''') AS DUE_TIME '
	
	SELECT @sql_from = ' FROM JOB_LOG INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
	             INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	             INNER JOIN V_JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER AND
	                                           JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
	             INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
									   JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE 
				 INNER JOIN DIVISION ON JOB_LOG.DIV_CODE = DIVISION.DIV_CODE 
				 LEFT OUTER JOIN TRAFFIC_FNC ON V_JOB_TRAFFIC_DET.FNC_CODE = TRAFFIC_FNC.TRF_CODE 
	INNER JOIN JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
	INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE '
				 
	SELECT @sql_where = ' WHERE 
(JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND
(V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL)
			AND ((V_JOB_TRAFFIC_DET.JOB_REVISED_DATE BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
			OR (V_JOB_TRAFFIC_DET.TASK_START_DATE BETWEEN ''' + CAST(@StartDate AS VARCHAR) + ''' AND  ''' + CAST(@EndDate AS VARCHAR) + ''')
			OR (''' + CAST(@StartDate AS VARCHAR) + ''' >= V_JOB_TRAFFIC_DET.TASK_START_DATE AND ''' + CAST(@EndDate AS VARCHAR) + ''' <= V_JOB_TRAFFIC_DET.JOB_REVISED_DATE))'
						 
	
	If @Restrictions > 0
		Begin
		  SELECT @sql_from = @sql_from + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE '

		  SELECT @sql_where = @sql_where + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CDPID) '
		End
	If @Manager <> ''
		Begin
		  SELECT @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC JT ON JOB_COMPONENT.JOB_NUMBER = JT.JOB_NUMBER 
			   AND JOB_COMPONENT.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR '
	
		  SELECT @sql_where = @sql_where + ' AND JT.MGR_EMP_CODE = ''' + @Manager + ''' '
		End	
	If @ROLES <> ''
		Begin
		  SELECT @sql_from = @sql_from + 'LEFT OUTER JOIN EMP_TRAFFIC_ROLE  ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE '
			
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
		SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''''


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

	If @Milestone = 'Y'
		SELECT @sql_where = @sql_where + ' AND V_JOB_TRAFFIC_DET.MILESTONE = 1 '


	SELECT @sql = @sql + @sql_from + @sql_where
	
    SELECT @sql = @sql + 'GROUP BY JOB_LOG.CL_CODE,

	     JOB_LOG.DIV_CODE,
	     JOB_LOG.PRD_CODE,
	     JOB_LOG.JOB_NUMBER,
	     JOB_LOG.JOB_DESC,
	     JOB_COMPONENT.JOB_COMPONENT_NBR,
	     JOB_COMPONENT.JOB_COMP_DESC,
	     STR(DATEPART(day, V_JOB_TRAFFIC_DET.TASK_START_DATE)),
	     STR(DATEPART(day, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE)),
	     isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''('' + V_JOB_TRAFFIC_DET.FNC_CODE + '')'') ,
	     V_JOB_TRAFFIC_DET.JOB_REVISED_DATE,
	     V_JOB_TRAFFIC_DET.TASK_START_DATE,
	     V_JOB_TRAFFIC_DET.TEMP_COMP_DATE,
             V_JOB_TRAFFIC_DET.TASK_STATUS,
             V_JOB_TRAFFIC_DET.SEQ_NBR,
             CLIENT.CL_NAME, DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION, TRAFFIC_FNC.TRF_CODE, V_JOB_TRAFFIC_DET.EMP_CODE, 
	TRAFFIC.TRF_DESCRIPTION,V_JOB_TRAFFIC_DET.DUE_TIME '

  If @GrpLevel = '0' 
	set @sql = @sql + ' ORDER BY V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '
 Else
	set @sql = @sql + ' ORDER BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.JOB_NUMBER, JOB_COMPONENT.JOB_COMPONENT_NBR, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE '

SELECT @paramlist = '@CDPID Int'
EXEC sp_executesql @sql, @paramlist, @CDPID











