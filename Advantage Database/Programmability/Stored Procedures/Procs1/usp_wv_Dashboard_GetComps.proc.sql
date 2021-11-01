if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetComps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetComps]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetComps]
(
	@EmpCode varchar(6),
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@Month int,
	@Office varchar(4000),
	@AE varchar(4000),
	@Client varchar(4000),	
	@Dept varchar(4000),
	@SalesClass varchar(4000),
	@JobType varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Level varchar(5),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10),
	@Project varchar(20)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_Days int, @NumberRecords int, @RowCount int, @OfficeRestrictions int, @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE
		
if @YearValue = '0'
Begin
	SET @PPMonth = 12
End
Else
Begin
	SELECT @PPMonth = PPGLMONTH 
	FROM POSTPERIOD
	WHERE PPSRTDATE <= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) AND PPENDDATE >= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))
End

--Client
if @Level = 'C'
Begin
	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End						
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
	
End

--Client/Division
if @Level = 'CD'
Begin
	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End								
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID		
	SET @sql = ''	
End

--Client/Division/Product
if @Level = 'CDP'
Begin
	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID		
	SET @sql = ''	
End

--AE
if @Level = 'AE'
Begin
	SELECT @sql = 'SELECT DISTINCT ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End									

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End								
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, ACCT_EXEC'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End					
					SELECT @sql = @sql + ' GROUP BY ACCT_EXEC '	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

	SELECT @sql = 'SELECT DISTINCT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End								

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
End

--Department
if @Level = 'dept'
Begin
	SELECT @sql = 'SELECT DISTINCT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DP_TM_DESC, ''None'') AS DP_TM_DESC
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DP_TM_DESC, ''None'') AS DP_TM_DESC, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End								
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, DASH_DATA_PROJ_HDR.DP_TM_CODE, DP_TM_DESC'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DP_TM_DESC, ''None'') AS DP_TM_DESC, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End			
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DP_TM_DESC '	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

	SELECT @sql = 'SELECT DISTINCT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
End

--Sales Class
if @Level = 'SC'
Begin
	SELECT @sql = 'SELECT DISTINCT ISNULL(DASH_DATA_PROJ_HDR.SC_CODE, ''None'') AS SC_CODE, ISNULL(SC_DESCRIPTION, ''None'') AS SC_DESCRIPTION
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End				
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End						

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, ISNULL(DASH_DATA_PROJ_HDR.SC_CODE, ''None'') AS SC_CODE, ISNULL(SC_DESCRIPTION, ''None'') AS SC_DESCRIPTION, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End		
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, DASH_DATA_PROJ_HDR.SC_CODE, SC_DESCRIPTION'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.SC_CODE, ''None'') AS SC_CODE, ISNULL(SC_DESCRIPTION, ''None'') AS SC_DESCRIPTION, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End			
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, SC_DESCRIPTION '	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

	SELECT @sql = 'SELECT DISTINCT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
End

--Job Type
if @Level = 'JT'
Begin
	SELECT @sql = 'SELECT DISTINCT ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE,''None'') AS JOB_TYPE, ISNULL(JT_DESC,''None'') AS JT_DESC
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End							

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''

	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE,''None'') AS JOB_TYPE, ISNULL(JT_DESC,''None'') AS JT_DESC, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End					
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, DASH_DATA_PROJ_HDR.JOB_TYPE, JT_DESC'	
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

		
	SET @sql = ''

	SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE,''None'') AS JOB_TYPE, ISNULL(JT_DESC,''None'') AS JT_DESC, COUNT(*) AS COMPS
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.JOB_TYPE, JT_DESC '	
			
	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID

	SELECT @sql = 'SELECT DISTINCT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION
					FROM DASH_DATA_PROJ_HDR'
					if @Project = 'Due' OR @Project = 'Pending' OR @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' INNER JOIN JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
						End
					if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
					if @Client <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
						End
					if @AE <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
						End
					if @Dept <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
						End
					if @SalesClass <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
						End
					if @JobType <> ''
						Begin
							SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
						End
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End
					IF @OfficeRestrictions > 0
						Begin
							SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
						End
					SELECT @sql = @sql + ' WHERE 1=1'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
						End
					if @Project = 'Completed'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End
					if @Project = 'Pending'
						Begin
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
						End	
					if @Project = 'Cancelled'
						Begin
							IF @IsCancelled = 'true'
								Begin
									SELECT @sql = @sql + ' AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
								End
							Else
								Begin
									SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
								End							
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End						

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID
	SET @sql = ''
End




GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

