if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetRealizationData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetRealizationData]
GO

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetRealizationData]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Month int,
	@Office varchar(4000),
	@Dept varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Include int,
	@CurrentDate SmallDateTime,
	@UserID varchar(100)
)
AS
Declare @Restrictions Int, @StdHours as decimal(9,3), @PercentDirect as decimal(9,3),
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @PPEndDate datetime, @TimeOff decimal(9,3), @DirectHrsPct decimal(7,4), @NumberRecords int, @RowCount int,
		@emp_code varchar(6), @DirectHrsGoal decimal(9,3),
		@RestrictionsOffice Int,
		@EmployeeCode varchar(6)

Select @EmployeeCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmployeeCode

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

SELECT @PPEndDate = PPENDDATE
FROM POSTPERIOD
WHERE PPSRTDATE <= @CurrentDate AND PPENDDATE >= @CurrentDate

CREATE TABLE #emp(
	RowID int IDENTITY(1, 1), 
	EMP_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BILLED decimal(15,2),
	BILLED_AMT decimal(15,2))

CREATE TABLE #wip(
	RowID int IDENTITY(1, 1), 
	EMP_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	WIP_HOURS decimal(15,2),
	WIP_AMT decimal(15,2))

CREATE TABLE #mud(
	RowID int IDENTITY(1, 1), 
	EMP_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MARK_UP_DOWN_HRS decimal(15,5),
	MARK_UP_DOWN_AMT decimal(15,2))

CREATE TABLE #direct(
	RowID int IDENTITY(1, 1), 
	EMP_CODE varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	STD_HOURS decimal(9,3),
	DIRECT_HRS_PER decimal(7,4),
	TIME_OFF decimal(9,3),
	DIRECT_HRS_GOAL decimal(9,3))

--CREATE TABLE #WORK_DAY --Table of employee workdays
--        (
--	        [ROW_ID] [int] IDENTITY(1,1) NOT NULL,
--	        [EMP_CODE]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
--	        [WORK_DATE]               SMALLDATETIME,
--	        [STD_HRS]  DECIMAL(18,6),
--			[EMP_DATE] SMALLDATETIME,
--			[MTH_GOAL_HRS_PER_DAY] DECIMAL(18,6),
--			[WORK_DAY_CT] INT,
--			[WORK_DAY_MONTH] INT
--        );

----GENERATE LIST OF DISTINCT EMPS:
--DECLARE @EMPS VARCHAR(8000)
--SET @EMPS = '';
--SELECT @EMPS = @EMPS + A.EMP_CODE + ','
-- FROM   (
--			SELECT     
--				 DISTINCT EMPLOYEE.EMP_CODE AS EMP_CODE
--			FROM         
--				EMPLOYEE
--			WHERE     
--				EMP_DATE BETWEEN @StartDate AND @EndDate
--		) AS A;
--SELECT @EMPS

--INSERT INTO #WORK_DAY (EMP_CODE, WORK_DATE, STD_HRS)
--				SELECT fn.emp_code, fn.workday, fn.std_hours
--				FROM [dbo].[udf_get_std_hrs_wl] ( @StartDate, @EndDate, @EMPS) fn
--	 			WHERE (fn.std_hours <> 0.00 )	

--UPDATE #WORK_DAY SET MTH_GOAL_HRS_PER_DAY = (SELECT MTH_HRS_GOAL FROM EMPLOYEE WHERE EMPLOYEE.EMP_CODE = #WORK_DAY.EMP_CODE)/
--											 (SELECT COUNT(WORK_DATE) FROM #WORK_DAY W WHERE W.EMP_CODE = #WORK_DAY.EMP_CODE
--											 AND WORK_DATE BETWEEN 
--														(SELECT DATEADD(dd,-(DAY(EMP_DATE)-1),EMP_DATE) FROM EMPLOYEE WHERE EMPLOYEE.EMP_CODE = #WORK_DAY.EMP_CODE) AND
--														(SELECT DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,EMP_DATE)+1,0)) FROM EMPLOYEE WHERE EMPLOYEE.EMP_CODE = #WORK_DAY.EMP_CODE))
--											WHERE WORK_DATE BETWEEN 
--														(SELECT DATEADD(dd,-(DAY(EMP_DATE)-1),EMP_DATE) FROM EMPLOYEE WHERE EMPLOYEE.EMP_CODE = #WORK_DAY.EMP_CODE) AND
--														(SELECT DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,EMP_DATE)+1,0)) FROM EMPLOYEE WHERE EMPLOYEE.EMP_CODE = #WORK_DAY.EMP_CODE)
														

--SELECT * FROM #WORK_DAY

SELECT @sql = 'INSERT INTO #emp
	SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(BILLED_HOURS), SUM(BILLED_AMT) FROM DASH_DATA_EMP_TIME 
	LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
			if @Office <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				End			
			if @Dept <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				End								
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
				End			
			SELECT @sql = @sql + ' WHERE REC_TYPE = ''B'' AND DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate) '			
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End		
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE '
SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode

--SELECT @sql = 'INSERT INTO #emp
--	SELECT EMP_CODE, 0, 0 FROM EMPLOYEE'
--			if @Office <> ''
--				Begin
--					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
--				End			
--			if @Dept <> ''
--				Begin
--					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
--				End								
--			if @RestrictionsOffice > 0
--				Begin
--					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
--				End			
--			SELECT @sql = @sql + ' WHERE EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE FROM #emp) '			
--			if @RestrictionsOffice > 0
--				Begin
--					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
--				End
--			if @EmpCode <> ''
--				Begin
--				   SELECT @sql = @sql + ' AND (EMPLOYEE.EMP_CODE = @EmpCode)'
--				End		
----SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE '
--SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
--print @sql
--EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode

SET @sql = ''

--SELECT * FROM #emp

SELECT @sql = 'INSERT INTO #mud
	SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(MARK_UP_DOWN_HRS), SUM(MARK_UP_DOWN_AMT) FROM DASH_DATA_EMP_TIME 
	LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
			if @Office <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				End			
			if @Dept <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				End								
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
				End			
			SELECT @sql = @sql + ' WHERE DASH_DATA_EMP_TIME.AR_PERIOD IN (SELECT PPPERIOD FROM POSTPERIOD WHERE PPSRTDATE >= @StartDate AND PPENDDATE <= @EndDate)'			
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End	
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End		
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode
SET @sql = ''

SELECT @sql = 'INSERT INTO #wip
	SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(DASH_DATA_EMP_TIME.WIP_HOURS), SUM(DASH_DATA_EMP_TIME.WIP_AMT) FROM DASH_DATA_EMP_TIME 
	LEFT OUTER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = DASH_DATA_EMP_TIME.EMP_CODE'
			if @Office <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				End			
			if @Dept <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				End									
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
				End			
			SELECT @sql = @sql + ' WHERE REC_TYPE = ''W'''			
			if @RestrictionsOffice > 0
				Begin
					SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
				End	
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End	
SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE'

SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @EmployeeCode varchar(6)'
print @sql
EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @EmployeeCode
SET @sql = ''
--SELECT * FROM #emp

if @Month = 0 and @YearValue = 2
Begin
	--INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
	--VALUES(@UserID, @StartDate, @PPEndDate)
	if @EmpCode <> ''
	Begin
		SELECT @StdHours = SUM(STD_HOURS) 
		FROM DASH_DATA_EMP_TIME
		WHERE REC_TYPE = 'S' AND EMP_CODE = @EmpCode AND EMP_DATE >= @StartDate AND EMP_DATE <= @PPEndDate

		SELECT @DirectHrsPct = ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000)
		FROM EMPLOYEE
		WHERE EMP_CODE = @EmpCode

		SELECT @TimeOff = ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0)
		FROM EMP_TIME_NP INNER JOIN
			 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
			 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
             TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
		WHERE (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @PPEndDate) AND EMP_TIME.EMP_CODE = @EmpCode AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3)

		SET @PercentDirect = ((@StdHours - @TimeOff) * (@DirectHrsPct * 0.010000))
	End
	Else
	Begin
		if @Include = 1
		Begin
			SELECT @sql = 'INSERT INTO #direct SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(STD_HOURS), ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000), 0, 0
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
					End								
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
					End			
				SELECT @sql = @sql + ' WHERE 1=1'			
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @PPEndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate, @EmployeeCode
		End
		Else
		Begin
			SELECT @sql = 'INSERT INTO #direct SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(STD_HOURS), ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000), 0, 0
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
					End								
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
					End			
				SELECT @sql = @sql + ' WHERE EMPLOYEE.EMP_TERM_DATE IS NULL'		
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End		
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @PPEndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @PPEndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @PPEndDate, @EmployeeCode
		End
	End
End
Else
Begin
	--INSERT INTO W_EMP_STD_HOURS (USERID, START_DATE, END_DATE)
	--VALUES(@UserID, @StartDate, @EndDate)
	if @EmpCode <> ''
	Begin
		SELECT @StdHours = SUM(STD_HOURS) 
		FROM DASH_DATA_EMP_TIME
		WHERE REC_TYPE = 'S' AND EMP_CODE = @EmpCode AND EMP_DATE >= @StartDate AND EMP_DATE <= @EndDate

		SELECT @DirectHrsPct = ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000)
		FROM EMPLOYEE
		WHERE EMP_CODE = @EmpCode

		SELECT @TimeOff = ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0)
		FROM EMP_TIME_NP INNER JOIN
			 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
			 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
             TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
		WHERE (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @EndDate) AND EMP_TIME.EMP_CODE = @EmpCode AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3)

		SET @PercentDirect = ((@StdHours - @TimeOff) * (@DirectHrsPct * 0.010000))
	End
	Else
	Begin
		if @Include = 1
		Begin
			SELECT @sql = 'INSERT INTO #direct SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(STD_HOURS), ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000), 0, 0
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
					End								
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
					End			
				SELECT @sql = @sql + ' WHERE 1=1'			
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate, @EmployeeCode
		End
		Else
		Begin
			SELECT @sql = 'INSERT INTO #direct SELECT DASH_DATA_EMP_TIME.EMP_CODE, SUM(STD_HOURS), ISNULL(EMPLOYEE.DIRECT_HRS_PER,0.000000), 0, 0
			FROM DASH_DATA_EMP_TIME LEFT OUTER JOIN
				 EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE'
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
					End			
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON EMPLOYEE.DP_TM_CODE = d.vstr collate database_default'
					End								
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
					End			
				SELECT @sql = @sql + ' WHERE EMPLOYEE.EMP_TERM_DATE IS NULL'			
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End		
				if @StartDate <> '' and @PPEndDate <> ''
					Begin
						SELECT @sql = @sql + ' AND DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate AND DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate'
					End
					SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMPLOYEE.DIRECT_HRS_PER'           
			SELECT @paramlist = '@Dept varchar(4000), @Office varchar(4000), @StdHours as decimal(15,2) OUTPUT, @StartDate SmallDateTime, @EndDate SmallDateTime, @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @Dept, @Office, @StdHours OUTPUT, @StartDate, @EndDate, @EmployeeCode
		End
	End
End

if @EmpCode = '' or @EmpCode IS NULL
BEGIN
	SELECT @NumberRecords = COUNT(*) FROM #direct
	SET @RowCount = 1

	WHILE @RowCount <= @NumberRecords
	BEGIN
		SELECT @StdHours = STD_HOURS, @emp_code = EMP_CODE, @DirectHrsPct = DIRECT_HRS_PER FROM #direct
		WHERE RowID = @RowCount

		if @Month = 0 and @YearValue = 2
		BEGIN
			UPDATE #direct SET TIME_OFF = (SELECT ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0) AS EMP_HOURS
							FROM EMP_TIME_NP INNER JOIN
								 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
								 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
								 TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
							WHERE (EMP_TIME.EMP_CODE = @emp_code) AND (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @PPEndDate) AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3))
			WHERE RowID = @RowCount
		END
		Else
		BEGIN
			UPDATE #direct SET TIME_OFF = (SELECT ISNULL(SUM(EMP_TIME_NP.EMP_HOURS),0) AS EMP_HOURS
							FROM EMP_TIME_NP INNER JOIN
								 EMP_TIME ON EMP_TIME_NP.ET_ID = EMP_TIME.ET_ID INNER JOIN
								 EMPLOYEE ON EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
								 TIME_CATEGORY ON EMP_TIME_NP.CATEGORY = TIME_CATEGORY.CATEGORY
							WHERE (EMP_TIME.EMP_CODE = @emp_code) AND (EMP_TIME.EMP_DATE BETWEEN @StartDate AND @EndDate) AND TIME_CATEGORY.VAC_SICK_FLAG IN(1,2,3))
			WHERE RowID = @RowCount
		END
		
		SELECT @TimeOff = TIME_OFF
		FROM #direct
		WHERE RowID = @RowCount
		--SELECT @StdHours,@TimeOff,@DirectHrsPct
		UPDATE #direct SET DIRECT_HRS_GOAL = (@StdHours - @TimeOff) * (@DirectHrsPct * 0.010000)
		WHERE RowID = @RowCount

		SET @RowCount = @RowCount + 1
	END
END

--SELECT * FROM #direct

SELECT @sql = 'SELECT DASH_DATA_EMP_TIME.EMP_CODE, isnull(EMP_FNAME,'''') + '' '' + isnull(EMP_MI,'''') + case when EMP_MI is not null then ''. '' else '''' end +  isnull(EMP_LNAME,'''') AS EMP_NAME, EMP_LNAME, EMPLOYEE.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC,
				 CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END AS GOAL,
					  ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS),0) AS BILLABLE_HOURS, ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) AS BILLABLE_AMT,
					  ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_HOURS),0) AS DIRECT_NONBILL_HOURS, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_AMT),0) AS DIRECT_NONBILL_AMT, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_AGENCY_HOURS),0) AS AGENCY_HOURS,
					  ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_AGENCY_AMT),0) AS AGENCY_AMOUNT, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_NEW_BUS_HOURS),0) AS NEW_BUS_HOURS, ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_NEW_BUS_AMT),0) AS NEW_BUS_AMOUNT,
					  ISNULL((SUM(DASH_DATA_EMP_TIME.BILLABLE_HOURS) + SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_HOURS) + SUM(DASH_DATA_EMP_TIME.DIRECT_AGENCY_HOURS) + SUM(DASH_DATA_EMP_TIME.DIRECT_NEW_BUS_HOURS)),0) AS TOTAL_DIRECT_HOURS,
				      ISNULL((SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT) + SUM(DASH_DATA_EMP_TIME.DIRECT_NONBILL_AMT)),0) AS TOTAL_DIRECT_AMT,'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' ISNULL(#emp.BILLED,0) AS BILLED_HOURS, ISNULL(#emp.BILLED_AMT,0) AS BILLED_AMT,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_HOURS),0) AS BILLED_HOURS, ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_AMT),0) AS BILLED_AMT,'
						 End
					  SELECT @sql = @sql + ' ISNULL(#wip.WIP_HOURS,0) AS WIP_HOURS, ISNULL(#wip.WIP_AMT,0) AS WIP_AMT,'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' ISNULL(#mud.MARK_UP_DOWN_AMT,0) AS MARK_UP_DOWN_AMT,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' ISNULL(SUM(DASH_DATA_EMP_TIME.MARK_UP_DOWN_AMT),0) AS MARK_UP_DOWN_AMT,'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) <> 0 THEN ISNULL(#mud.MARK_UP_DOWN_AMT/SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) * 100 ELSE 0 END AS PERCENT_WRITE,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT),0) <> 0 THEN ISNULL((SUM(DASH_DATA_EMP_TIME.MARK_UP_DOWN_AMT)/SUM(DASH_DATA_EMP_TIME.BILLABLE_AMT)),0) * 100 ELSE 0 END AS PERCENT_WRITE,'
						 End					  
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) <> 0 THEN ISNULL((#emp.BILLED/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS)),0) * 100 ELSE 0 END AS PERCENT_BILLED,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN ISNULL(SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) <> 0 THEN ISNULL((SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS)),0) * 100 ELSE 0 END AS PERCENT_BILLED,'
						 End	
					  --SELECT @sql = @sql + ' 0 AS PERCENT_BILLED_GOAL,'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 100 WHEN EMPLOYEE.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((#emp.BILLED/ISNULL(CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END,1)),0) * 100 END AS PERCENT_BILLED_GOAL,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN EMPLOYEE.MTH_HRS_GOAL IS NULL THEN 100 WHEN EMPLOYEE.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/ISNULL(CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) WHEN @Month > 1 THEN (EMPLOYEE.MTH_HRS_GOAL * @Month) ELSE EMPLOYEE.MTH_HRS_GOAL END,1)),0) * 100 END AS PERCENT_BILLED_GOAL,'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN #emp.BILLED = 0 THEN 0 ELSE ISNULL(#emp.BILLED_AMT/ISNULL(#emp.BILLED,1),0) END AS AVG_HOURLY_RATE_BILLED,'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN SUM(DASH_DATA_EMP_TIME.BILLED_HOURS) = 0 THEN 0 ELSE ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_AMT)/SUM(DASH_DATA_EMP_TIME.BILLED_HOURS),0) END AS AVG_HOURLY_RATE_BILLED,'
						 End
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ' CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) = 0 THEN 0 ELSE ISNULL(#emp.BILLED_AMT/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) END AS AVG_HOURLY_RATE_ACHIEVED'
						 End	
					  Else
						 Begin
							SELECT @sql = @sql + ' CASE WHEN SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS) = 0 THEN 0 ELSE ISNULL(SUM(DASH_DATA_EMP_TIME.BILLED_AMT)/SUM(DASH_DATA_EMP_TIME.DIRECT_HOURS),0) END AS AVG_HOURLY_RATE_ACHIEVED'
						 End
					  if @EmpCode <> ''
						Begin
							SELECT @sql = @sql + ', @PercentDirect AS DIRECT_HRS_GOAL'
						End
					  Else
						Begin
							SELECT @sql = @sql + ', ISNULL(#direct.DIRECT_HRS_GOAL,0) AS DIRECT_HRS_GOAL'
						End
					  If @Period = 1
						 Begin
							if @EmpCode <> ''
								Begin
									SELECT @sql = @sql + ', CASE WHEN @PercentDirect = 0 THEN 0 ELSE ISNULL((#emp.BILLED/(@PercentDirect)),0) * 100 END AS PERCENT_BILLED_DIRECT_GOAL'
								End
							  Else
								Begin
									SELECT @sql = @sql + ', CASE WHEN ISNULL(#direct.DIRECT_HRS_GOAL,0) = 0 THEN 0 ELSE ISNULL((#emp.BILLED/#direct.DIRECT_HRS_GOAL),0) * 100 END AS PERCENT_BILLED_DIRECT_GOAL'
								End
							--SELECT @sql = @sql + ' CASE WHEN EMPLOYEE.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((#emp.BILLED/ISNULL(CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) ELSE EMPLOYEE.MTH_HRS_GOAL END,1)),0) * 100 END AS PERCENT_BILLED_GOAL,'
						 End	
					  Else
						 Begin
							if @EmpCode <> ''
								Begin
									SELECT @sql = @sql + ', CASE WHEN @PercentDirect = 0 THEN 0 ELSE ISNULL((SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/(@PercentDirect)),0) * 100 END AS PERCENT_BILLED_DIRECT_GOAL'
								End
							  Else
								Begin
									SELECT @sql = @sql + ', CASE WHEN ISNULL(#direct.DIRECT_HRS_GOAL,0) = 0 THEN 0 ELSE ISNULL((SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/#direct.DIRECT_HRS_GOAL),0) * 100 END AS PERCENT_BILLED_DIRECT_GOAL'
								End
							--SELECT @sql = @sql + ' CASE WHEN EMPLOYEE.MTH_HRS_GOAL = 0 THEN 0 ELSE ISNULL((SUM(DASH_DATA_EMP_TIME.BILLED_HOURS)/ISNULL(CASE WHEN @Month = 0 THEN (EMPLOYEE.MTH_HRS_GOAL * @PPMonth) ELSE EMPLOYEE.MTH_HRS_GOAL END,1)),0) * 100 END AS PERCENT_BILLED_GOAL,'
						 End		 	
					  SELECT @sql = @sql + ' FROM DASH_DATA_EMP_TIME INNER JOIN EMPLOYEE ON DASH_DATA_EMP_TIME.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN #wip ON DASH_DATA_EMP_TIME.EMP_CODE = #wip.EMP_CODE LEFT OUTER JOIN
								  DEPT_TEAM ON DEPT_TEAM.DP_TM_CODE = EMPLOYEE.DP_TM_CODE'
			If @Period = 1
					Begin
						SELECT @sql = @sql + ' LEFT OUTER JOIN #emp ON DASH_DATA_EMP_TIME.EMP_CODE = #emp.EMP_CODE'
						SELECT @sql = @sql + ' LEFT OUTER JOIN #mud ON DASH_DATA_EMP_TIME.EMP_CODE = #mud.EMP_CODE'
					End
			if @EmpCode = '' OR @EmpCode IS NULL
				Begin
					SELECT @sql = @sql + ' LEFT OUTER JOIN #direct ON DASH_DATA_EMP_TIME.EMP_CODE = #direct.EMP_CODE'
				End
			if @Office <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) c ON EMPLOYEE.OFFICE_CODE = c.vstr collate database_default'
				End			
			if @Dept <> ''
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_EMP_TIME.DP_TM_CODE = d.vstr collate database_default'
				End								
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE'
					End			
				SELECT @sql = @sql + ' WHERE 1=1'			
				if @RestrictionsOffice > 0
					Begin
						SELECT @sql = @sql + ' AND EMP_OFFICE.EMP_CODE = @EmployeeCode'
					End
			if @EmpCode <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_CODE = @EmpCode)'
				End
			if @StartDate <> '' and @EndDate <> ''
				Begin
				   SELECT @sql = @sql + ' AND (DASH_DATA_EMP_TIME.EMP_DATE >= @StartDate) AND (DASH_DATA_EMP_TIME.EMP_DATE <= @EndDate)'
				End
			if @Include = 0
				Begin
					SELECT @sql = @sql + ' AND EMPLOYEE.EMP_TERM_DATE IS NULL'
				End
			SELECT @sql = @sql + ' GROUP BY DASH_DATA_EMP_TIME.EMP_CODE, EMP_FNAME, EMP_MI, EMP_LNAME, EMPLOYEE.DP_TM_CODE, DEPT_TEAM.DP_TM_DESC, EMPLOYEE.MTH_HRS_GOAL, #wip.WIP_HOURS, #wip.WIP_AMT'
					  If @Period = 1
						 Begin
							SELECT @sql = @sql + ', #emp.BILLED, #emp.BILLED_AMT, #mud.MARK_UP_DOWN_AMT'
						 End
					  if @EmpCode = '' OR @EmpCode IS NULL
						 Begin
							SELECT @sql = @sql + ', #direct.DIRECT_HRS_GOAL'
						 End
			SELECT @sql = @sql + ' ORDER BY EMP_LNAME,EMP_FNAME,EMP_MI'
			SELECT @paramlist = '@EmpCode varchar(6), @StartDate SmallDateTime, @EndDate SmallDateTime, @Office varchar(4000), @Dept varchar(4000), @Month int, @PPMonth int, @PercentDirect as decimal(9,3), @EmployeeCode varchar(6)'
			print @sql
			EXEC sp_executesql @sql, @paramlist, @EmpCode, @StartDate, @EndDate, @Office, @Dept, @Month, @PPMonth, @PercentDirect, @EmployeeCode
	
	





