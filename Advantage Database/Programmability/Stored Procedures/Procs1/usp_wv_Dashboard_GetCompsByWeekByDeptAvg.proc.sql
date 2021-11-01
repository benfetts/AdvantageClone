if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetCompsByWeekByDeptAvg]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetCompsByWeekByDeptAvg]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetCompsByWeekByDeptAvg]
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
	@Project varchar(20),
	@Division varchar(6),
	@Product varchar(6)
)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_days int, @NumberRecords int, @RowCount int, @average decimal(5,2), @comps1 int, @comps2 int, @comps3 int, @comps4 int,
		@c varchar(6), @cname varchar(50), @d varchar(6), @dname varchar(50), @p varchar(6), @pname varchar(50), @aecode varchar(6), @aename varchar(50), 
		@dp varchar(6), @dpname varchar(50), @sc varchar(6), @scname varchar(50), @jt varchar(6), @jtname varchar(50), @OfficeRestrictions int, @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

CREATE TABLE #weeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime)

CREATE TABLE #c(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	CL_CODE varchar(6),
	CL_NAME varchar(50),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #cweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	CL_CODE varchar(6),
	CL_NAME varchar(60),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #cd(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	CL_CODE varchar(6),
	CL_NAME varchar(40),
	DIV_CODE varchar(6),
	DIV_NAME varchar(40),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #cdweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	CL_CODE varchar(6),
	CL_NAME varchar(60),
	DIV_CODE varchar(6),
	DIV_NAME varchar(60),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #cdp(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	CL_CODE varchar(6),
	CL_NAME varchar(40),
	DIV_CODE varchar(6),
	DIV_NAME varchar(40),
	PRD_CODE varchar(6),
	PRD_DESCRIPTION varchar(40),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #cdpweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	CL_CODE varchar(6),
	CL_NAME varchar(60),
	DIV_CODE varchar(6),
	DIV_NAME varchar(60),
	PRD_CODE varchar(6),
	PRD_DESCRIPTION varchar(60),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #ae(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	ACCT_EXEC varchar(6),
	ACCT_NAME varchar(50),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #aeweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	ACCT_EXEC varchar(6),
	ACCT_NAME varchar(70),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #depts(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	DP_TM_CODE varchar(6),
	DP_TM_DESC varchar(30),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #deptweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	DP_TM_CODE varchar(6),
	DP_TM_DESC varchar(50),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #sc(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	SC_CODE varchar(6),
	SC_DESCRIPTION varchar(60),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #scweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	SC_CODE varchar(6),
	SC_DESCRIPTION varchar(80),
	COMPS int,
	AVERAGE decimal(15,2))

CREATE TABLE #jt(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	JOB_TYPE varchar(6),
	JT_DESC varchar(60),
	COMPS int,
	WEEK_START Datetime)

CREATE TABLE #jtweeks(
	RowID int IDENTITY(1, 1), 
	DATE_OPENED int,
	WEEK_START Datetime,
	WEEK_END Datetime,
	JOB_TYPE varchar(6),
	JT_DESC varchar(80),
	COMPS int,
	AVERAGE decimal(15,2))

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

set @no_of_days = datediff(dd,@StartDate,@EndDate) + 1
set rowcount @no_of_days
select identity(int,0,1) as dy into #temp from sysobjects a, sysobjects b
set rowcount 0

--select dateadd(dd,dy,@StartDate) as [days]
--,       datepart(dy, dateadd(dd,dy,@StartDate)) [day of year]
--,       datename(dw, dateadd(dd,dy,@StartDate)) [day]
--,       datepart(dw, dateadd(dd,dy,@StartDate)-1) [day of week]
--,       datepart(dd, dateadd(dd,dy,@StartDate)) [day of month]
--,       datepart(ww, dateadd(dd,dy,@StartDate)) [week]
--,       datepart(mm, dateadd(dd,dy,@StartDate)) [month]
--,       datename(mm, dateadd(dd,dy,@StartDate)) [month]
--,       datepart(qq, dateadd(dd,dy,@StartDate)) [quarter]
--,       datepart(yy, dateadd(dd,dy,@StartDate)) [year]
--from #temp


INSERT INTO #weeks
SELECT datepart(ww, dateadd(dd,dy,@StartDate)) AS DATE_OPENED, DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6) AS WEEK_START,
		DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5) AS WEEK_END 
FROM #temp
GROUP BY datepart(ww, dateadd(dd,dy,@StartDate)), DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6),DATEADD(wk, DATEDIFF(wk, 0, dateadd(dd,dy,@StartDate)), 5)
ORDER BY DATEADD(wk, DATEDIFF(wk, 6, dateadd(dd,dy,@StartDate)), 6), datepart(ww, dateadd(dd,dy,@StartDate)) DESC


if @Level = 'C'
Begin
	SELECT @sql = 'INSERT INTO #c '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID


	INSERT INTO #cweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #c.CL_CODE, #c.CL_NAME + ' (4 Week Avg)' , ISNULL(#c.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #c ON #weeks.DATE_OPENED = #c.DATE_OPENED AND #weeks.WEEK_START = #c.WEEK_START
	ORDER BY #weeks.WEEK_START

	--SELECT * FROM #c
	--SELECT * FROM #cweeks

	SELECT @NumberRecords = COUNT(*) FROM #cweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #cweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #cweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #cweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #cweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #cweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @c = CL_CODE, @cname = CL_NAME FROM #cweeks WHERE CL_CODE IS NOT NULL
	 UPDATE #cweeks
	 SET CL_CODE = @c, CL_NAME = @cname
	 WHERE RowID = @RowCount AND CL_CODE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #cweeks
End

if @Level = 'CD'
Begin
	SELECT @sql = 'INSERT INTO #cd '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND DASH_DATA_PROJ_HDR.DIV_CODE = @Division'
						End				
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End				
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End			
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100), @Division varchar(6)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID, @Division


	INSERT INTO #cdweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #cd.CL_CODE, #cd.CL_NAME, #cd.DIV_CODE, #cd.DIV_NAME + ' (4 Week Avg)' , ISNULL(#cd.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #cd ON #weeks.DATE_OPENED = #cd.DATE_OPENED AND #weeks.WEEK_START = #cd.WEEK_START
	ORDER BY #weeks.WEEK_START



	SELECT @NumberRecords = COUNT(*) FROM #cdweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #cdweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #cdweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #cdweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #cdweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #cdweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @c = CL_CODE, @cname = CL_NAME, @d = DIV_CODE, @dname = DIV_NAME FROM #cdweeks WHERE CL_CODE IS NOT NULL
	 UPDATE #cdweeks
	 SET CL_CODE = @c, CL_NAME = @cname, DIV_CODE = @d, DIV_NAME = @dname
	 WHERE RowID = @RowCount AND CL_CODE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #cdweeks
End

if @Level = 'CDP'
Begin
	SELECT @sql = 'INSERT INTO #cdp '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
					if @Division <> ''
						Begin
							SELECT @sql = @sql + ' AND DASH_DATA_PROJ_HDR.DIV_CODE = @Division'
						End	
					if @Product <> ''
						Begin
							SELECT @sql = @sql + ' AND DASH_DATA_PROJ_HDR.PRD_CODE = @Product'
						End			
					IF @Restrictions > 0
						Begin
							SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End			
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.CL_CODE, DASH_DATA_PROJ_HDR.DIV_CODE, DASH_DATA_PROJ_HDR.PRD_CODE, DASH_DATA_PROJ_HDR.CL_NAME, DASH_DATA_PROJ_HDR.DIV_NAME, DASH_DATA_PROJ_HDR.PRD_DESCRIPTION'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End				
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100), @Division varchar(6), @Product varchar(6)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID, @Division, @Product


	INSERT INTO #cdpweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #cdp.CL_CODE, #cdp.CL_NAME, #cdp.DIV_CODE, #cdp.DIV_NAME, #cdp.PRD_CODE, #cdp.PRD_DESCRIPTION + ' (4 Week Avg)' , ISNULL(#cdp.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #cdp ON #weeks.DATE_OPENED = #cdp.DATE_OPENED AND #weeks.WEEK_START = #cdp.WEEK_START
	ORDER BY #weeks.WEEK_START



	SELECT @NumberRecords = COUNT(*) FROM #cdpweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #cdpweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #cdpweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #cdpweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #cdpweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #cdpweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @c = CL_CODE, @cname = CL_NAME, @d = DIV_CODE, @dname = DIV_NAME, @p = PRD_CODE, @pname = PRD_DESCRIPTION FROM #cdpweeks WHERE CL_CODE IS NOT NULL
	 UPDATE #cdpweeks
	 SET CL_CODE = @c, CL_NAME = @cname, DIV_CODE = @d, DIV_NAME = @dname, PRD_CODE = @p, PRD_DESCRIPTION = @pname
	 WHERE RowID = @RowCount AND CL_CODE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #cdpweeks
End

if @Level = 'AE'
Begin
	SELECT @sql = 'INSERT INTO #ae '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'') AS ACCT_NAME, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
				
				SELECT @sql = @sql + ' GROUP BY ACCT_EXEC, dbo.udf_get_empl_name(DASH_DATA_PROJ_HDR.ACCT_EXEC, ''FML'')'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End			
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End			
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID


	INSERT INTO #aeweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #ae.ACCT_EXEC, #ae.ACCT_NAME + ' (4 Week Avg)' , ISNULL(#ae.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #ae ON #weeks.DATE_OPENED = #ae.DATE_OPENED AND #weeks.WEEK_START = #ae.WEEK_START
	ORDER BY #weeks.WEEK_START



	SELECT @NumberRecords = COUNT(*) FROM #aeweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #aeweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #aeweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #aeweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #aeweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #aeweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @aecode = ACCT_EXEC, @aename = ACCT_NAME FROM #aeweeks WHERE ACCT_EXEC IS NOT NULL
	 UPDATE #aeweeks
	 SET ACCT_EXEC = @aecode, ACCT_NAME = @aename
	 WHERE RowID = @RowCount AND ACCT_EXEC IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #aeweeks
End

if @Level = 'dept'
Begin
	SELECT @sql = 'INSERT INTO #depts '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.DP_TM_CODE, DP_TM_DESC, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
					SELECT @sql = @sql + ' WHERE DASH_DATA_PROJ_HDR.DP_TM_CODE IS NOT NULL'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
				
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.DP_TM_CODE, DP_TM_DESC'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End				
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID


	INSERT INTO #deptweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #depts.DP_TM_CODE, #depts.DP_TM_DESC + ' (4 Week Avg)' , ISNULL(#depts.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #depts ON #weeks.DATE_OPENED = #depts.DATE_OPENED AND #weeks.WEEK_START = #depts.WEEK_START
	ORDER BY #weeks.WEEK_START

	--SELECT * FROM #weeks

	SELECT @NumberRecords = COUNT(*) FROM #deptweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #deptweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #deptweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #deptweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #deptweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #deptweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @dp = DP_TM_CODE, @dpname = DP_TM_DESC FROM #deptweeks WHERE DP_TM_CODE IS NOT NULL
	 UPDATE #deptweeks
	 SET DP_TM_CODE = @dp, DP_TM_DESC = @dpname
	 WHERE RowID = @RowCount AND DP_TM_CODE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #deptweeks
End

if @Level = 'SC'
Begin
	SELECT @sql = 'INSERT INTO #sc '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.SC_CODE, SC_DESCRIPTION, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
					SELECT @sql = @sql + ' WHERE DASH_DATA_PROJ_HDR.SC_CODE IS NOT NULL'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.SC_CODE, SC_DESCRIPTION'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End			
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End			
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID


	INSERT INTO #scweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #sc.SC_CODE, #sc.SC_DESCRIPTION + ' (4 Week Avg)' , ISNULL(#sc.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #sc ON #weeks.DATE_OPENED = #sc.DATE_OPENED AND #weeks.WEEK_START = #sc.WEEK_START
	ORDER BY #weeks.WEEK_START



	SELECT @NumberRecords = COUNT(*) FROM #scweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #scweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #scweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #scweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #scweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #scweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @sc = SC_CODE, @scname = SC_DESCRIPTION FROM #scweeks WHERE SC_CODE IS NOT NULL
	 UPDATE #scweeks
	 SET SC_CODE = @sc, SC_DESCRIPTION = @scname
	 WHERE RowID = @RowCount AND SC_CODE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #scweeks
End

if @Level = 'JT'
Begin
	SELECT @sql = 'INSERT INTO #jt '
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_COMP_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE) AS DATE_OPENED,'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + 'SELECT DATEPART(week,JOB_FIRST_USE_DATE) AS DATE_OPENED,'
						End	
	SELECT @sql = @sql + ' DASH_DATA_PROJ_HDR.JOB_TYPE, JT_DESC, COUNT(*) AS COMPS'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End					   	
    SELECT @sql = @sql + ' FROM DASH_DATA_PROJ_HDR'
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
					SELECT @sql = @sql + ' WHERE DASH_DATA_PROJ_HDR.JOB_TYPE IS NOT NULL'
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
							SELECT @sql = @sql + ' AND (NOT (DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL IN (6, 12))) AND (DASH_DATA_PROJ_HDR.COMPLETED_DATE IS NULL) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
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
				SELECT @sql = @sql + ' GROUP BY DASH_DATA_PROJ_HDR.JOB_TYPE, JT_DESC'	
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_COMP_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.COMPLETED_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ', DATEPART(week,DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End				
				SELECT @sql = @sql + ' ORDER BY'
					if @Project = 'Created'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_COMP_DATE), 6)'
						End
					if @Project = 'Completed' or @Project = 'Pending' or @Project = 'Cancelled'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.COMPLETED_DATE), 6)'
						End
					if @Project = 'Due'
						Begin
							SELECT @sql = @sql + ' DATEADD(wk, DATEDIFF(wk, 6, DASH_DATA_PROJ_HDR.JOB_FIRST_USE_DATE), 6)'
						End		
			

	SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDatetime, @EndDate SmallDatetime, @Office varchar(4000), @Dept varchar(4000), @AE varchar(4000), @Client varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000), @CancelledCode VARCHAR(100), @EMP_CODE AS VARCHAR(6), @UserID varchar(100)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @AE, @Client, @SalesClass, @JobType, @CancelledCode, @EMP_CODE, @UserID


	INSERT INTO #jtweeks	
	SELECT #weeks.DATE_OPENED, #weeks.WEEK_START, #weeks.WEEK_END, #jt.JOB_TYPE, #jt.JT_DESC + ' (4 Week Avg)' , ISNULL(#jt.COMPS,0), 0
	FROM #weeks LEFT OUTER JOIN #jt ON #weeks.DATE_OPENED = #jt.DATE_OPENED AND #weeks.WEEK_START = #jt.WEEK_START
	ORDER BY #weeks.WEEK_START



	SELECT @NumberRecords = COUNT(*) FROM #jtweeks
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN

	 SELECT @comps1 = COMPS FROM #jtweeks WHERE RowID = @RowCount
	 SELECT @comps2 = COMPS FROM #jtweeks WHERE RowID = @RowCount + 1
	 SELECT @comps3 = COMPS FROM #jtweeks WHERE RowID = @RowCount + 2
	 SELECT @comps4 = COMPS FROM #jtweeks WHERE RowID = @RowCount + 3

	 SET @average = (@comps1 + @comps2 + @comps3 + @comps4) / 4.0

	--SELECT @comps1,@comps2,@comps3,@comps4,@average

	 UPDATE #jtweeks
	 SET AVERAGE = ROUND(@average,0)
	 WHERE RowID = @RowCount + 3

	 SELECT DISTINCT @jt = JOB_TYPE, @jtname = JT_DESC FROM #jtweeks WHERE JOB_TYPE IS NOT NULL
	 UPDATE #jtweeks
	 SET JOB_TYPE = @jt, JT_DESC = @jtname
	 WHERE RowID = @RowCount AND JOB_TYPE IS NULL
			
	 SET @RowCount = @RowCount + 1
	END

	SELECT * FROM #jtweeks
End


drop table #temp
drop table #weeks
drop table #c
drop table #cweeks
drop table #cd
drop table #cdweeks
drop table #cdp
drop table #cdpweeks
drop table #ae
drop table #aeweeks
drop table #depts
drop table #deptweeks
drop table #sc
drop table #scweeks
drop table #jt
drop table #jtweeks

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

