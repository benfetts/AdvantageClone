if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_reports_traffic_schedule_byday]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_reports_traffic_schedule_byday]
GO



CREATE PROCEDURE [dbo].[usp_wv_reports_traffic_schedule_byday]  
@ClientCode VarChar(4000),
@StartingDate Datetime, 
@EndingDate Datetime,
@ClosedJobs Char(1),
@ColSort VarChar(10),
@OfficeCode VarChar(4000),
@Manager Varchar(6),--
@CompletedIncl char(1),
@AE VarChar(4000),
@UserID varchar(100)
AS

Declare @Restrictions Int, @sql nvarchar(4000), @sql2 nvarchar(4000),
		@paramlist nvarchar(4000)

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER
DECLARE @SearchByClient BIT,
		@SearchByDivision BIT,
		@SearchByProduct BIT,
		@FirstCode VARCHAR(20)
		
SET @SearchByClient = 0
SET @SearchByDivision = 0
SET @SearchByProduct = 0

IF @ClientCode <> ''
BEGIN

	SET @SearchByClient = 1

	SELECT TOP 1
		@FirstCode = items
	FROM
		dbo.udf_split_list(@ClientCode, ',')
		
	IF LEN(@FirstCode) - LEN(REPLACE(@FirstCode, '|', '')) = 1 
	BEGIN
		
		SET @SearchByClient = 0
		SET @SearchByDivision = 1
		SET @SearchByProduct = 0

	END
	
	IF LEN(@FirstCode) - LEN(REPLACE(@FirstCode, '|', '')) = 2
	BEGIN
		
		SET @SearchByClient = 0
		SET @SearchByDivision = 0
		SET @SearchByProduct = 1

	END
	
END

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

SELECT @sql = 'SELECT JOB_COMPONENT.START_DATE, 
										JOB_LOG.CL_CODE,
										CLIENT.CL_NAME,
										JOB_LOG.DIV_CODE,
										DIVISION.DIV_NAME,
										JOB_LOG.PRD_CODE,
										PRODUCT.PRD_DESCRIPTION,
										JOB_TRAFFIC_DET.JOB_NUMBER as JOB_NUMBER, 
										JOB_LOG.JOB_DESC,
										JOB_COMPONENT.JOB_COMPONENT_NBR,
										JOB_COMPONENT.JOB_COMP_DESC,
										JOB_DESC, 
										JOB_TRAFFIC_DET.EMP_CODE, 
										Convert(VarChar(250), TRF_COMMENTS) as TRF_COMMENTS, 
										TRAFFIC.TRF_CODE AS TRF_CODE, 
										TRAFFIC.TRF_DESCRIPTION AS TRF_DESC,
										ISNULL(JOB_TRAFFIC_DET.FNC_CODE, SubString(TASK_DESCRIPTION, 1, 10)) as FNC_CODE1,
										CASE WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL THEN SubString(TASK_DESCRIPTION, 1, 30) ELSE JOB_TRAFFIC_DET.FNC_CODE END as FNC_CODE2,
										TASK_DESCRIPTION, 
										JOB_REVISED_DATE, 
										SubString(EMPLOYEE.EMP_FNAME, 1, 1) + '' '' + EMPLOYEE.EMP_LNAME as EmpName, 
														JOB_LOG.CL_CODE+JOB_LOG.DIV_CODE+JOB_LOG.PRD_CODE as CLI_DIV_PROD,
										''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE_1.EMP_FNAME + '' '' + ISNULL(EMPLOYEE_1.EMP_MI+''. '','''') + EMPLOYEE_1.EMP_LNAME AS AE,  
										  JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID, TP.PHASE_DESC, 
										''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + EMP.EMP_FNAME + '' '' + ISNULL(EMP.EMP_MI+''. '','''') + EMP.EMP_LNAME AS Manager
									   FROM JOB_TRAFFIC
									 INNER JOIN JOB_TRAFFIC_DET
										 On JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
										AND JOB_TRAFFIC.JOB_COMPONENT_NBR =  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
									 INNER JOIN JOB_LOG
										 On JOB_TRAFFIC_DET.JOB_NUMBER = JOB_LOG.JOB_NUMBER
									 INNER JOIN JOB_COMPONENT
										 On JOB_TRAFFIC_DET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
											AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
									 INNER JOIN TRAFFIC
										 ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
									 INNER JOIN CLIENT
										 ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
									 INNER JOIN DIVISION
										 ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
										AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
									 INNER JOIN PRODUCT
										 ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
										AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
										AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
									 LEFT OUTER JOIN EMPLOYEE
										 ON JOB_TRAFFIC_DET.EMP_CODE = EMPLOYEE.EMP_CODE
									 INNER JOIN
										  EMPLOYEE AS EMPLOYEE_1 ON JOB_COMPONENT.EMP_CODE = EMPLOYEE_1.EMP_CODE 
									 LEFT OUTER JOIN EMPLOYEE EMP
										 ON JOB_TRAFFIC.MGR_EMP_CODE = EMP.EMP_CODE
									 LEFT OUTER JOIN
										  JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'

								IF @SearchByClient = 1
								BEGIN
									
									SELECT @sql = @sql + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT ) c ON JOB_LOG.CL_CODE = c.vstr collate database_default '
									
								END
								ELSE
								BEGIN

									IF @SearchByDivision = 1
									BEGIN
									
										SELECT @sql = @sql + ' INNER JOIN dbo.udf_split_list(''' + @ClientCode + ''', DEFAULT ) c ON (JOB_LOG.CL_CODE + ''|'' + JOB_LOG.DIV_CODE) = c.items collate database_default '
									
									END
									ELSE
									BEGIN

										IF @SearchByProduct = 1
										BEGIN

											SELECT @sql = @sql + ' INNER JOIN dbo.udf_split_list(''' + @ClientCode + ''', DEFAULT ) c ON (JOB_LOG.CL_CODE + ''|'' + JOB_LOG.DIV_CODE + ''|'' + JOB_LOG.PRD_CODE) = c.items collate database_default '
									
										END

									END

								END

								--If @ClientCode <> ''
								--Begin
								--	SELECT @sql = @sql + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT ) c ON JOB_LOG.CL_CODE = c.vstr collate database_default '
								--End
								If @OfficeCode <> ''
								Begin
									SELECT @sql = @sql + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default '
								End
								If @AE <> '%'
								Begin
									SELECT @sql = @sql + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default '
								End
								If @RestrictionsOffice > 0
								Begin
									SELECT @sql = @sql  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
								End
								SELECT @sql = @sql + ' LEFT OUTER JOIN TRAFFIC_FNC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC_FNC.TRF_CODE	
								LEFT OUTER JOIN TRAFFIC_PHASE TP ON TP.TRAFFIC_PHASE_ID = JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID'

SELECT @sql = @sql + ' Where JOB_REVISED_DATE >= ''' + CAST(@StartingDate AS VARCHAR) + '''
						AND JOB_REVISED_DATE <= ''' + CAST(@EndingDate AS VARCHAR) + '''
						 AND CAST(JOB_TRAFFIC_DET.JOB_NUMBER AS VARCHAR) + ''/'' + CAST(JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS VARCHAR) + ''/'' + CAST(JOB_TRAFFIC_DET.SEQ_NBR AS VARCHAR) NOT IN (SELECT DISTINCT CAST(JOB_TRAFFIC_DET.JOB_NUMBER AS VARCHAR) + ''/'' + CAST(JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AS VARCHAR) + ''/'' + CAST(JOB_TRAFFIC_DET.PARENT_TASK_SEQ AS VARCHAR)
												 FROM dbo.JOB_TRAFFIC_DET
												 WHERE PARENT_TASK_SEQ IS NOT NULL)'
If @Manager <> 'All'
Begin
	SELECT @sql = @sql + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''''
End
If @ClosedJobs = 'N'
Begin
	SELECT @sql = @sql + ' AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
End
If @CompletedIncl = '0'
Begin
	SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL  '
End	

If @ColSort = 'emp'
Begin
	SELECT @sql = @sql + ' Order By JOB_TRAFFIC_DET.EMP_CODE'
End
Else
Begin
	SELECT @sql = @sql + ' Order By FNC_EST'
End

PRINT(@sql)
EXEC(@sql)			



	


