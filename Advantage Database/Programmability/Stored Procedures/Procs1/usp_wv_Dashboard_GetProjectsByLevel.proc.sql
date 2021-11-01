if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetProjectsByLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetProjectsByLevel]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetProjectsByLevel]
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
	@Level varchar(10),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10),
	@Project varchar(20)
)
AS
Declare @sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_Days int, @NumberRecords int, @RowCount int, @average decimal(5,2), @comps1 int, @comps2 int, @comps3 int, @comps4 int,
		@ws datetime, @dpname varchar(50)

DECLARE @Restrictions INT
DECLARE @OfficeRestrictions INT
DECLARE @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE


-- CLIENT
if @Level = 'C'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, 
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, 
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

-- CLIENT/DIVISION
if @Level = 'CD'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, 
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

-- CLIENT/DIVISION/PRODUCT
if @Level = 'CDP'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION,
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

--Account Executive
if @Level = 'AE'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME,
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME,
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.ACCT_EXEC'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

--DEPARTMENT
if @Level = 'dept'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC,
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT ISNULL(DASH_DATA_PROJ_HDR.DP_TM_CODE, ''None'') AS DP_TM_CODE, ISNULL(DASH_DATA_PROJ_HDR.DP_TM_DESC, ''None'') AS DP_TM_DESC,
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DASH_DATA_PROJ_HDR.DP_TM_DESC'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

--SALES CLASS
if @Level = 'SC'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION,
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION,
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode)'
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, DASH_DATA_PROJ_HDR.SC_DESCRIPTION'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End

--JOB TYPE
if @Level = 'JT'
Begin
	If @Project = 'Created'
	Begin
		--Get jobs created:
		SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC,
						COUNT(*) AS Created
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate) '
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Completed'
	Begin
		--Get jobs completed:
		SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC,
						COUNT(*) AS Completed
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate) '
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Due'
	Begin
		--Get jobs due:
		SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC,
						COUNT(*) AS Due
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
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE <= @EndDate) AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) '
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Pending'
	Begin
		--Get jobs in progress:
		SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC,
						COUNT(*) AS Pending
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
		SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) '
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
	End
	If @Project = 'Cancelled'
	Begin
		--Check custom column:
		IF @IsCancelled = 'true'
		Begin
			SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC, 
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (JOB_TRAFFIC.TRF_CODE = @CancelledCode) AND (NOT (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL)) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE <= @EndDate) '
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
		Else
		Begin
			SELECT @sql = 'SELECT CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END AS JOB_TYPE, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END AS JT_DESC,
							COUNT(*) AS Cancelled
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
			SELECT @sql = @sql + ' WHERE (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND 
									(JOB_TRAFFIC.TRF_CODE = @CancelledCode) '
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End
			SELECT @sql = @sql + ' GROUP BY CASE WHEN DASH_DATA_PROJ_HDR.JOB_TYPE = '''' THEN ''None'' ELSE ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') END, CASE WHEN DASH_DATA_PROJ_HDR.JT_DESC IS NULL THEN ISNULL(DASH_DATA_PROJ_HDR.JOB_TYPE, ''None'') ELSE ISNULL(DASH_DATA_PROJ_HDR.JT_DESC, ''None'') END'
			SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @CancelledCode VARCHAR(100), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @CancelledCode, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
		End
	End
End



GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

