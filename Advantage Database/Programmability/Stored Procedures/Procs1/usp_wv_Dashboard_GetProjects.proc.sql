if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetProjects]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetProjects]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetProjects]
(
	@EmpCode varchar(6),
	@StartDate varchar(12),
	@EndDate varchar(12),
	@Month int,
	@Office varchar(4000),
	@AE varchar(4000),
	@Client varchar(4000),	
	@Dept varchar(4000),
	@SalesClass varchar(4000),
	@JobType varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Level varchar(10),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10)
)
AS
Declare @sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_Days int, @NumberRecords int, @RowCount int, @average decimal(5,2), @comps1 int, @comps2 int, @comps3 int, @comps4 int,
		@ws datetime, @dpname varchar(50)

CREATE TABLE #JOB_STATS
(
	PROJECTS varchar(6),
	JOBS_CREATED INT NOT NULL,
	JOBS_COMPLETED INT NOT NULL,
	JOBS_CANCELLED INT NOT NULL,
	JOBS_DUE INT NOT NULL,
	JOBS_IN_PROGRESS INT NOT NULL
)

DECLARE @Restrictions INT
DECLARE @OfficeRestrictions INT
DECLARE @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

INSERT INTO #JOB_STATS SELECT 'Projs',0,0,0,0,0

--Get jobs created:
SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_CREATED = T1.JOBS_CREATED
			FROM (
			SELECT 
				COUNT(*) AS JOBS_CREATED
			FROM
				DASH_DATA_PROJ_HDR'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
			End
		IF @OfficeRestrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End
SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType

--Get jobs completed:
SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_COMPLETED = T1.JOBS_COMPLETED
			FROM (
			SELECT 
				COUNT(*) AS JOBS_COMPLETED
			FROM
				DASH_DATA_PROJ_HDR'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
			End
		IF @OfficeRestrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End
SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType


--Check custom column:
IF @IsCancelled = 'true'
Begin
	SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_CANCELLED = T1.JOBS_CANCELLED
				FROM (
				SELECT 
					COUNT(*) AS JOBS_CANCELLED
				FROM
					DASH_DATA_PROJ_HDR INNER JOIN
					JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER'
			IF @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			IF @OfficeRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
	SELECT @sql = @sql + ' WHERE (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)'
			IF @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End
	SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

	SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType
End
Else
Begin
	SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_CANCELLED = T1.JOBS_CANCELLED
				FROM (
				SELECT 
					COUNT(*) AS JOBS_CANCELLED
				FROM
					DASH_DATA_PROJ_HDR INNER JOIN
					 JOB_TRAFFIC ON DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND 
					 DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
			IF @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			IF @OfficeRestrictions > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
	SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND 
							(((DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND 
							(DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate)) OR DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
							(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
			IF @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End
	SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

	SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType
End

--Get jobs due:
SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_DUE = T1.JOBS_DUE
			FROM (
			SELECT 
				COUNT(*) AS JOBS_DUE
			FROM
				DASH_DATA_PROJ_HDR INNER JOIN JOB_TRAFFIC ON
				DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
			End
		IF @OfficeRestrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End
SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType


--Get jobs in progress:
SELECT @sql = 'UPDATE #JOB_STATS SET JOBS_IN_PROGRESS = T1.JOBS_IN_PROGRESS
			FROM (
			SELECT 
				COUNT(*) AS JOBS_IN_PROGRESS
			FROM
				DASH_DATA_PROJ_HDR INNER JOIN JOB_TRAFFIC ON
				DASH_DATA_PROJ_HDR.JOB = JOB_TRAFFIC.JOB_NUMBER AND DASH_DATA_PROJ_HDR.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
			End
		IF @OfficeRestrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
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
SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
		IF @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End
SELECT @sql = @sql + ' ) T1 WHERE #JOB_STATS.PROJECTS = ''Projs'''

SELECT @paramlist = '@StartDate Datetime, @EndDate Datetime, @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Month, @Level, @UserID, @EMP_CODE, @Office, @Dept, @AE, @Client, @SalesClass, @JobType





SELECT PROJECTS, JOBS_CREATED AS Created,
	JOBS_COMPLETED AS Completed,
	JOBS_CANCELLED AS Cancelled,
	JOBS_DUE AS Due,
	JOBS_IN_PROGRESS AS Pending FROM #JOB_STATS
--Drop temporary table:
DROP TABLE #JOB_STATS


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

